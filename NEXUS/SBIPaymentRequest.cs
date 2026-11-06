namespace NEXUS;

public class SBIPaymentRequest
{
	public string Username { get; set; }

	public string Password { get; set; }

	public string serviceId { get; set; } = "test";

	public string keyId { get; set; }

	public string jSessionId { get; set; }

	public string uId { get; set; }

	public Claims_Token claimsToken { get; set; }

	public string securityKey { get; set; } = "abcd";

	public string mobAppKey { get; set; } = "pqrst";

	public string otp { get; set; }

	public string smsText { get; set; }

	public string phoneNumberForSmsSend { get; set; } = "pqrst";

	public string androidId { get; set; }

	public string phoneModel { get; set; }

	public string userAgent { get; set; }

	public string userId { get; set; }

	public string osVersion { get; set; }

	public string mpinCode { get; set; }

	public string KONY_SDK_VERSION { get; set; }

	public string KONY_APP_KEY { get; set; }

	public string KONY_APP_SECRET { get; set; }

	public string KONY_PLATFORM { get; set; }

	public string KONY_SDK_TYPE { get; set; }

	public string MPIN_MAIN { get; set; }

	public string APP_KEY_MAIN { get; set; }

	public string CONFIG_APP_ID { get; set; } = "6200df4d-2986-4de4-bf3f-44973800fb0a";

	public string CONFIG_BASE_ID { get; set; } = "06aaa59d-3531-4eb0-8be6-899fcf2554de";

	public string CONFIG_APP_NAME { get; set; } = "SBISmartOTPChe";

	public string KONY_RSID { get; set; } = "1666015648453-f86b-8242-a917";

	public bool currentStatus { get; set; }

	public string currentMessage { get; set; }

	public string currentOtp { get; set; }

	public string otpTransactionType { get; set; }

	public string otpAmount { get; set; }
}
