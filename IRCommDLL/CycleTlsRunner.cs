using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IRCommDLL;

public class CycleTlsRunner
{
	private static Process _nodeProcess;

	public static void StartNodeServer(string serverJsPath)
	{
		try
		{
			if (_nodeProcess != null && !_nodeProcess.HasExited)
			{
				return;
			}
			ProcessStartInfo processStartInfo = new ProcessStartInfo();
			string fileName = "node";
			processStartInfo.FileName = fileName;
			string text = "\"";
			string text2 = "\"";
			processStartInfo.Arguments = text + serverJsPath + text2;
			processStartInfo.UseShellExecute = false;
			processStartInfo.RedirectStandardOutput = true;
			processStartInfo.RedirectStandardError = true;
			processStartInfo.CreateNoWindow = true;
			ProcessStartInfo startInfo = processStartInfo;
			_nodeProcess = new Process
			{
				StartInfo = startInfo
			};
			_nodeProcess.OutputDataReceived += delegate(object s, DataReceivedEventArgs e)
			{
				if (e.Data != null)
				{
					string text3 = "[node] ";
					Console.WriteLine(text3 + e.Data);
				}
			};
			_nodeProcess.ErrorDataReceived += delegate(object s, DataReceivedEventArgs e)
			{
				if (e.Data != null)
				{
					string text4 = "[node-err] ";
					Console.WriteLine(text4 + e.Data);
				}
			};
			_nodeProcess.Start();
			_nodeProcess.BeginOutputReadLine();
			_nodeProcess.BeginErrorReadLine();
			Thread.Sleep(2000);
		}
		catch (Exception)
		{
		}
	}

	public static async Task<Tuple<int, string, string>> CallCycleTlsAsync(object payload, string helperUrl = "http://127.0.0.1:3001/fetch")
	{
		HttpClient http = new HttpClient();
		try
		{
			string content = JsonConvert.SerializeObject(payload);
			Encoding uTF = Encoding.UTF8;
			string mediaType = "application/json";
			StringContent content2 = new StringContent(content, uTF, mediaType);
			try
			{
				HttpResponseMessage resp = await http.PostAsync(helperUrl, (HttpContent)content2);
				string text = await resp.Content.ReadAsStringAsync();
				try
				{
					JObject jObject = JObject.Parse(text);
					string propertyName = "status";
					int item;
					if (jObject[propertyName] == null)
					{
						item = (int)resp.StatusCode;
					}
					else
					{
						string propertyName2 = "status";
						item = (int)jObject[propertyName2];
					}
					string propertyName3 = "body";
					object obj;
					if (jObject[propertyName3] == null)
					{
						obj = "";
					}
					else
					{
						string propertyName4 = "body";
						obj = jObject[propertyName4].ToString();
					}
					string item2 = (string)obj;
					string propertyName5 = "error";
					object obj2;
					if (jObject[propertyName5] == null)
					{
						obj2 = "";
					}
					else
					{
						string propertyName6 = "error";
						obj2 = jObject[propertyName6].ToString();
					}
					string item3 = (string)obj2;
					return Tuple.Create(item, item2, item3);
				}
				catch
				{
					return Tuple.Create((int)resp.StatusCode, text, "");
				}
			}
			catch (Exception ex)
			{
				Exception ex2 = ex;
				Exception ex3 = ex2;
				string text2 = "Helper call failed: ";
				return Tuple.Create(0, "", text2 + ex3.Message);
			}
		}
		finally
		{
			((IDisposable)http)?.Dispose();
		}
	}
}
