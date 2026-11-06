namespace NEXUS;

public class EnableHighSecurityConfirmServiceResponseBody
{
	public string uId { get; set; }

	public string jSessionId { get; set; }

	public bool isValidOTP { get; set; }

	public string securityKey { get; set; }

	public string mobAppKey { get; set; }
}
