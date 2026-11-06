namespace NEXUS;

public class LoginValidateResponseBody
{
	public string uId { get; set; }

	public string jSessionId { get; set; }

	public string displayName { get; set; }

	public string systemDate { get; set; }

	public string errorCode { get; set; }

	public string keyId { get; set; }

	public object promoMessage { get; set; }

	public string lastLoginDate { get; set; }

	public string serviceId { get; set; }

	public string userName { get; set; }

	public bool status { get; set; }
}
