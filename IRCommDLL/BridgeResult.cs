namespace IRCommDLL;

public class BridgeResult
{
	public string commandId { get; set; }

	public bool success { get; set; }

	public object data { get; set; }

	public object requestHeaders { get; set; }

	public object responseHeaders { get; set; }

	public string message { get; set; }
}
