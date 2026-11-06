using System;

namespace NEXUS;

public class SBISecureOtpService
{
	public SBIPaymentRequest getOtp(SBIPaymentRequest sbiPaymentRequest)
	{
		SbiSecureService sbiSecureService = new SbiSecureService();
		sbiPaymentRequest.currentStatus = false;
		sbiPaymentRequest.currentMessage = "";
		sbiPaymentRequest.currentOtp = "";
		long unixTimeMilliseconds = GetUnixTimeMilliseconds(DateTime.Now);
		if (sbiPaymentRequest.claimsToken.exp < unixTimeMilliseconds)
		{
			sbiPaymentRequest = sbiSecureService.authServiceRequest(sbiPaymentRequest);
		}
		sbiPaymentRequest.currentStatus = false;
		sbiPaymentRequest.currentMessage = "";
		sbiPaymentRequest = sbiSecureService.smartSecServiceRequest(sbiPaymentRequest);
		if (!sbiPaymentRequest.currentStatus)
		{
			return sbiPaymentRequest;
		}
		sbiPaymentRequest.currentStatus = false;
		sbiPaymentRequest.currentMessage = "";
		sbiPaymentRequest = sbiSecureService.secureLoginServiceRequest(sbiPaymentRequest);
		if (!sbiPaymentRequest.currentStatus)
		{
			return sbiPaymentRequest;
		}
		sbiPaymentRequest.currentMessage = "";
		sbiPaymentRequest.currentStatus = false;
		sbiPaymentRequest.currentOtp = "";
		sbiPaymentRequest = sbiSecureService.fetchOnlineOTPRequest(sbiPaymentRequest);
		_ = sbiPaymentRequest.currentStatus;
		return sbiPaymentRequest;
	}

	internal static long GetUnixTimeMilliseconds(DateTime datetime)
	{
		long result = 0L;
		try
		{
			DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
			result = (long)(datetime.ToUniversalTime() - dateTime).TotalMilliseconds;
		}
		catch
		{
		}
		return result;
	}
}
