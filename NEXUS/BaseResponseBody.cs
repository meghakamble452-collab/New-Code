namespace NEXUS;

public class BaseResponseBody
{
	public string code { get; set; }

	public string encData { get; set; }

	public int opstatus { get; set; }

	public string status { get; set; }

	public int httpStatusCode { get; set; }
}
