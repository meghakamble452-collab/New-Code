using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Newtonsoft.Json;

namespace IRCommDLL;

internal class TLSSession
{
	private string sessionID;

	private RequestPayload sessionPayload;

	[DllImport("./HttpClient.dll", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr request(byte[] requestPayload, string sessionID);

	[DllImport("./HttpClient.dll", CallingConvention = CallingConvention.Cdecl)]
	public static extern void freeMemory(string sessionID);

	public TLSSession(Dictionary<string, string> headers = null, string TlsClientIdentifier = "chrome_133", int TimeoutSeconds = 60, bool FollowRedirects = false, string proxy = null)
	{
		sessionID = Guid.NewGuid().ToString();
		sessionPayload = new RequestPayload
		{
			TlsClientIdentifier = TlsClientIdentifier,
			FollowRedirects = FollowRedirects,
			InsecureSkipVerify = false,
			IsByteRequest = false,
			ForceHttp1 = false,
			WithDebug = false,
			CatchPanics = false,
			WithRandomTLSExtensionOrder = false,
			sessionId = sessionID,
			TimeoutSeconds = TimeoutSeconds,
			TimeoutMilliseconds = 0,
			CertificatePinningHosts = new Dictionary<string, string>(),
			ProxyUrl = "",
			IsRotatingProxy = false,
			Headers = (headers ?? new Dictionary<string, string>()),
			HeaderOrder = ((headers != null) ? new List<string>(headers.Keys) : new List<string>()),
			RequestUrl = "",
			RequestMethod = "",
			RequestBody = ""
		};
		if (proxy != null)
		{
			Console.WriteLine(proxy);
			sessionPayload.ProxyUrl = proxy;
		}
	}

	public RequestResult Get(string url, Dictionary<string, string> additionalHeaders = null)
	{
		string method = "GET";
		return MakeRequest(method, url, MergeHeaders(sessionPayload.Headers, additionalHeaders));
	}

	public RequestResult Post(string url, Dictionary<string, string> additionalHeaders = null, string body = "")
	{
		string method = "POST";
		return MakeRequest(method, url, MergeHeaders(sessionPayload.Headers, additionalHeaders), body);
	}

	public RequestResult Patch(string url, Dictionary<string, string> additionalHeaders = null, string body = "")
	{
		string method = "PATCH";
		return MakeRequest(method, url, MergeHeaders(sessionPayload.Headers, additionalHeaders), body);
	}

	public RequestResult Put(string url, Dictionary<string, string> additionalHeaders = null, string body = "")
	{
		string method = "PUT";
		return MakeRequest(method, url, MergeHeaders(sessionPayload.Headers, additionalHeaders), body);
	}

	public RequestResult Delete(string url, Dictionary<string, string> additionalHeaders = null)
	{
		string method = "DELETE";
		return MakeRequest(method, url, MergeHeaders(sessionPayload.Headers, additionalHeaders));
	}

	private RequestResult MakeRequest(string method, string url, Dictionary<string, string> headers, string body = "")
	{
		sessionPayload.RequestMethod = method;
		sessionPayload.RequestUrl = url;
		sessionPayload.Headers = headers;
		sessionPayload.RequestBody = body;
		string s = JsonConvert.SerializeObject(sessionPayload);
		RequestResult requestResult = JsonConvert.DeserializeObject<RequestResult>(Marshal.PtrToStringAnsi(request(Encoding.UTF8.GetBytes(s), sessionID)));
		freeMemory(requestResult.Id);
		return requestResult;
	}

	private Dictionary<string, string> MergeHeaders(Dictionary<string, string> originalHeaders, Dictionary<string, string> additionalHeaders)
	{
		if (additionalHeaders != null)
		{
			foreach (KeyValuePair<string, string> additionalHeader in additionalHeaders)
			{
				originalHeaders[additionalHeader.Key] = additionalHeader.Value;
			}
			return originalHeaders;
		}
		return originalHeaders;
	}
}
