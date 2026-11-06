using System.Collections.Generic;

namespace IRCommDLL;

internal class RequestPayload
{
	public string TlsClientIdentifier { get; set; } = "FireFox110";

	public bool FollowRedirects { get; set; } = true;

	public bool InsecureSkipVerify { get; set; }

	public bool WithoutCookieJar { get; set; }

	public bool WithDefaultCookieJar { get; set; }

	public bool IsByteRequest { get; set; }

	public bool ForceHttp1 { get; set; }

	public bool WithDebug { get; set; }

	public bool CatchPanics { get; set; }

	public bool WithRandomTLSExtensionOrder { get; set; }

	public string sessionId { get; set; } = "Nada";

	public int TimeoutSeconds { get; set; } = 2000;

	public int TimeoutMilliseconds { get; set; }

	public Dictionary<string, string> CertificatePinningHosts { get; set; } = new Dictionary<string, string>();

	public string ProxyUrl { get; set; } = "";

	public bool IsRotatingProxy { get; set; }

	public Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();

	public List<string> HeaderOrder { get; set; }

	public string RequestUrl { get; set; }

	public string RequestMethod { get; set; }

	public string RequestBody { get; set; }
}
