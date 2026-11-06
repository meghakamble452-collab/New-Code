using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Web.Script.Serialization;

namespace IRCommDLL;

public class LocalBridgeServer
{
	private class PendingResult
	{
		public ManualResetEventSlim Event = new ManualResetEventSlim(initialState: false);

		public BridgeResult Result;
	}

	private readonly HttpListener _listener;

	private readonly int _port;

	private readonly ConcurrentQueue<BridgeCommand> _commandQueue = new ConcurrentQueue<BridgeCommand>();

	private readonly ConcurrentDictionary<string, PendingResult> _pendingResults = new ConcurrentDictionary<string, PendingResult>();

	private readonly JavaScriptSerializer _json = new JavaScriptSerializer();

	private Thread _listenerThread;

	private bool _running;

	public LocalBridgeServer(int port = 8181)
	{
		_port = port;
		_listener = new HttpListener();
		HttpListenerPrefixCollection prefixes = _listener.Prefixes;
		string format = "http://localhost:{0}/";
		prefixes.Add(string.Format(format, _port));
	}

	public void Start()
	{
		_running = true;
		_listener.Start();
		_listenerThread = new Thread(ListenLoop)
		{
			IsBackground = true
		};
		_listenerThread.Start();
	}

	public void Stop()
	{
		_running = false;
		try
		{
			_listener.Stop();
		}
		catch
		{
		}
	}

	private void ListenLoop()
	{
		while (_running)
		{
			try
			{
				HttpListenerContext context = _listener.GetContext();
				HandleContext(context);
			}
			catch (Exception)
			{
				if (_running)
				{
					continue;
				}
				break;
			}
		}
	}

	private void HandleContext(HttpListenerContext ctx)
	{
		try
		{
			HttpListenerResponse response = ctx.Response;
			string name = "Access-Control-Allow-Origin";
			string value = "*";
			response.AddHeader(name, value);
			HttpListenerResponse response2 = ctx.Response;
			string name2 = "Access-Control-Allow-Methods";
			string value2 = "GET, POST, OPTIONS";
			response2.AddHeader(name2, value2);
			HttpListenerResponse response3 = ctx.Response;
			string name3 = "Access-Control-Allow-Headers";
			string value3 = "Content-Type";
			response3.AddHeader(name3, value3);
			string httpMethod = ctx.Request.HttpMethod;
			string text = "OPTIONS";
			if (httpMethod == text)
			{
				ctx.Response.StatusCode = 200;
				ctx.Response.Close();
				return;
			}
			string text2 = ctx.Request.Url.AbsolutePath.TrimEnd('/').ToLowerInvariant();
			string text3 = "/command";
			if (text2 == text3)
			{
				string httpMethod2 = ctx.Request.HttpMethod;
				string text4 = "GET";
				if (httpMethod2 == text4)
				{
					BridgeCommand bridgeCommand = WaitForCommand(60000);
					if (bridgeCommand == null)
					{
						ctx.Response.StatusCode = 204;
						ctx.Response.Close();
						return;
					}
					string s = _json.Serialize(bridgeCommand);
					byte[] bytes = Encoding.UTF8.GetBytes(s);
					HttpListenerResponse response4 = ctx.Response;
					string contentType = "application/json";
					response4.ContentType = contentType;
					ctx.Response.ContentLength64 = bytes.Length;
					ctx.Response.OutputStream.Write(bytes, 0, bytes.Length);
					ctx.Response.Close();
					return;
				}
			}
			string text5 = "/result";
			if (text2 == text5)
			{
				string httpMethod3 = ctx.Request.HttpMethod;
				string text6 = "POST";
				if (httpMethod3 == text6)
				{
					string input;
					using (StreamReader streamReader = new StreamReader(ctx.Request.InputStream, ctx.Request.ContentEncoding))
					{
						input = streamReader.ReadToEnd();
					}
					BridgeResult bridgeResult = _json.Deserialize<BridgeResult>(input);
					if (bridgeResult != null && !string.IsNullOrEmpty(bridgeResult.commandId) && _pendingResults.TryGetValue(bridgeResult.commandId, out var value4))
					{
						value4.Result = bridgeResult;
						value4.Event.Set();
					}
					ctx.Response.StatusCode = 200;
					ctx.Response.Close();
					return;
				}
			}
			ctx.Response.StatusCode = 404;
			ctx.Response.Close();
		}
		catch
		{
			try
			{
				ctx.Response.StatusCode = 500;
				ctx.Response.Close();
			}
			catch
			{
			}
		}
	}

	private BridgeCommand WaitForCommand(int timeoutMs)
	{
		Stopwatch stopwatch = Stopwatch.StartNew();
		BridgeCommand result;
		while (true)
		{
			if (stopwatch.ElapsedMilliseconds < timeoutMs)
			{
				if (_commandQueue.TryDequeue(out result))
				{
					break;
				}
				Thread.Sleep(50);
				continue;
			}
			return null;
		}
		return result;
	}

	private string NewCommandId()
	{
		Guid guid = Guid.NewGuid();
		string text = "N";
		return guid.ToString(text);
	}

	public BridgeResult ProcessLoadLoginPage(int timeoutMs = 120000)
	{
		BridgeCommand bridgeCommand = new BridgeCommand
		{
			commandId = NewCommandId()
		};
		string command = "LoadLoginPage";
		bridgeCommand.command = command;
		BridgeCommand cmd = bridgeCommand;
		return EnqueueAndWait(cmd, timeoutMs);
	}

	public BridgeResult ProcessLogin(string username, string password, string captcha, int timeoutMs = 120000)
	{
		BridgeCommand bridgeCommand = new BridgeCommand
		{
			commandId = NewCommandId()
		};
		string command = "Login";
		bridgeCommand.command = command;
		bridgeCommand.payload = new { username, password, captcha };
		BridgeCommand cmd = bridgeCommand;
		return EnqueueAndWait(cmd, timeoutMs);
	}

	public BridgeResult ProcessStep(string step, string url, string body, object extraHeaders, int timeoutMs = 120000)
	{
		BridgeCommand cmd = new BridgeCommand
		{
			commandId = NewCommandId(),
			command = step,
			payload = new { url, body, extraHeaders }
		};
		return EnqueueAndWait(cmd, timeoutMs);
	}

	private BridgeResult EnqueueAndWait(BridgeCommand cmd, int timeoutMs)
	{
		PendingResult pendingResult = new PendingResult();
		_pendingResults[cmd.commandId] = pendingResult;
		_commandQueue.Enqueue(cmd);
		PendingResult value;
		if (!pendingResult.Event.Wait(timeoutMs))
		{
			_pendingResults.TryRemove(cmd.commandId, out value);
			BridgeResult bridgeResult = new BridgeResult
			{
				commandId = cmd.commandId,
				success = false
			};
			string message = "Timeout waiting for extension";
			bridgeResult.message = message;
			return bridgeResult;
		}
		_pendingResults.TryRemove(cmd.commandId, out value);
		return pendingResult.Result;
	}
}
