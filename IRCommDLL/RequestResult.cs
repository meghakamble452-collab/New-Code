using System.Collections.Generic;

namespace IRCommDLL;

internal class RequestResult
{
	public string Id { get; set; }

	public string Body { get; set; }

	public object Cookies { get; set; }

	public Dictionary<string, List<string>> Headers { get; set; }

	public int Status { get; set; }

	public string Target { get; set; }

	public string UsedProtocol { get; set; }
}
