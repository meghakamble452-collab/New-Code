namespace NEXUS;

public class FetchOTPResponse
{
	public string onlineOtp { get; set; }

	public string transactionType { get; set; }

	public string amount { get; set; }

	public string beneficiaryNickName { get; set; }

	public string maxUserCount { get; set; }

	public string otpMessage { get; set; }

	public string errorMsg { get; set; }

	public string status { get; set; }
}
