using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace NEXUS;

public class SbiSecureService
{
	private CookieContainer cookieContainer = new CookieContainer();

	public static string SERVER_HOST;

	public static int SERVER_PORT;

	public static string AUTH_SERVICE_PATH;

	public static string SMART_SEC_SERVICE_PATH;

	public static string SECURITY_LOGIN_SERVICE_PATH;

	public static string FETCH_ONLINE_OTP_PATH;

	public static string KONY_API_VERSION;

	public static string APP_ID;

	public static string APP_NAME;

	public static string APP_VERSION;

	public static string CHANNEL;

	public SBIPaymentRequest authServiceRequest(SBIPaymentRequest sbiPaymentRequest)
	{
		try
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(SERVER_HOST + AUTH_SERVICE_PATH);
			string method = "POST";
			httpWebRequest.Method = method;
			httpWebRequest.KeepAlive = true;
			httpWebRequest.UserAgent = sbiPaymentRequest.userAgent;
			WebHeaderCollection headers = httpWebRequest.Headers;
			string name = "Accept-Encoding";
			string value = "gzip,deflate";
			headers.Add(name, value);
			httpWebRequest.ContentLength = 0L;
			string contentType = "application/x-www-form-urlencoded";
			httpWebRequest.ContentType = contentType;
			string accept = "application/json";
			httpWebRequest.Accept = accept;
			httpWebRequest.ServicePoint.Expect100Continue = true;
			WebHeaderCollection headers2 = httpWebRequest.Headers;
			string name2 = "Cache-Control";
			string value2 = "no-cache";
			headers2[name2] = value2;
			WebHeaderCollection headers3 = httpWebRequest.Headers;
			string name3 = "X-Kony-SDK-Version";
			headers3[name3] = sbiPaymentRequest.KONY_SDK_VERSION;
			WebHeaderCollection headers4 = httpWebRequest.Headers;
			string name4 = "X-Kony-App-Key";
			headers4[name4] = sbiPaymentRequest.KONY_APP_KEY;
			WebHeaderCollection headers5 = httpWebRequest.Headers;
			string name5 = "X-Kony-App-Secret";
			headers5[name5] = sbiPaymentRequest.KONY_APP_SECRET;
			WebHeaderCollection headers6 = httpWebRequest.Headers;
			string name6 = "X-Kony-Platform";
			headers6[name6] = sbiPaymentRequest.KONY_PLATFORM;
			WebHeaderCollection headers7 = httpWebRequest.Headers;
			string name7 = "X-Kony-SDK-Type";
			headers7[name7] = sbiPaymentRequest.KONY_SDK_TYPE;
			HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			Stream responseStream = httpWebResponse.GetResponseStream();
			string value3 = new StreamReader(responseStream).ReadToEnd();
			responseStream.Close();
			if (httpWebResponse.StatusCode != HttpStatusCode.OK)
			{
				sbiPaymentRequest.currentStatus = false;
				string currentMessage = "Something wrong";
				sbiPaymentRequest.currentMessage = currentMessage;
			}
			else
			{
				AuthServiceResponse authServiceResponse = JsonConvert.DeserializeObject<AuthServiceResponse>(value3);
				if (authServiceResponse.claims_token != null && authServiceResponse.claims_token.value != null && authServiceResponse.refresh_token != null)
				{
					sbiPaymentRequest.claimsToken = authServiceResponse.claims_token;
					sbiPaymentRequest.currentStatus = true;
				}
				else
				{
					sbiPaymentRequest.currentStatus = false;
					string currentMessage2 = "Something wrong";
					sbiPaymentRequest.currentMessage = currentMessage2;
				}
			}
		}
		catch (Exception)
		{
			sbiPaymentRequest.currentStatus = false;
			string currentMessage3 = "Something wrong ex";
			sbiPaymentRequest.currentMessage = currentMessage3;
		}
		return sbiPaymentRequest;
	}

	public SBIPaymentRequest smartSecServiceRequest(SBIPaymentRequest sbiPaymentRequest)
	{
		string requestUriString = SERVER_HOST + SMART_SEC_SERVICE_PATH;
		try
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			string key = "events";
			string value = "[]";
			dictionary.Add(key, value);
			string key2 = "serviceID";
			string value2 = "SmartSecService";
			dictionary.Add(key2, value2);
			string key3 = "optionalFlagFomUI";
			string value3 = "false";
			dictionary.Add(key3, value3);
			Header header = new Header();
			header.bankCode = "";
			header.token = "";
			header.userName = "";
			string key4 = "header";
			dictionary.Add(key4, Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(header))));
			BaseRequestBody baseRequestBody = new BaseRequestBody();
			baseRequestBody.body = new Body();
			baseRequestBody.security = new Security();
			baseRequestBody.security.appkey = "";
			baseRequestBody.security.mpin = "";
			baseRequestBody.security.token1 = "";
			baseRequestBody.security.token2 = "";
			string key5 = "encData";
			dictionary.Add(key5, SBISecureCrypt.EncryptEncData(JsonConvert.SerializeObject(baseRequestBody), "", getMpinMain(sbiPaymentRequest), getAppKeyMain(sbiPaymentRequest)));
			string key6 = "requestKey";
			dictionary.Add(key6, SBISecureCrypt.calcRequestKey(JsonConvert.SerializeObject(baseRequestBody)));
			string key7 = "appID";
			dictionary.Add(key7, APP_ID);
			string key8 = "appver";
			dictionary.Add(key8, APP_VERSION);
			string key9 = "channel";
			dictionary.Add(key9, CHANNEL);
			string key10 = "platform";
			dictionary.Add(key10, sbiPaymentRequest.KONY_PLATFORM);
			string key11 = "cacheid";
			dictionary.Add(key11, "");
			string key12 = "konyreportingparams";
			string form = "frmLoginWithMPin";
			string serviceId = "SmartSecService";
			dictionary.Add(key12, getKonyReportingParams(sbiPaymentRequest, form, serviceId));
			string formBody = getFormBody(dictionary);
			byte[] bytes = Encoding.UTF8.GetBytes(formBody);
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
			httpWebRequest.CookieContainer = cookieContainer;
			string method = "POST";
			httpWebRequest.Method = method;
			httpWebRequest.KeepAlive = true;
			httpWebRequest.UserAgent = sbiPaymentRequest.userAgent;
			WebHeaderCollection headers = httpWebRequest.Headers;
			string name = "Accept-Encoding";
			string value4 = "gzip,deflate";
			headers.Add(name, value4);
			httpWebRequest.ContentLength = bytes.Length;
			string contentType = "application/json";
			httpWebRequest.ContentType = contentType;
			httpWebRequest.ServicePoint.Expect100Continue = true;
			WebHeaderCollection headers2 = httpWebRequest.Headers;
			string name2 = "Cache-Control";
			string value5 = "no-cache";
			headers2[name2] = value5;
			WebHeaderCollection headers3 = httpWebRequest.Headers;
			string name3 = "X-Kony-Authorizationn";
			headers3[name3] = sbiPaymentRequest.claimsToken.value;
			WebHeaderCollection headers4 = httpWebRequest.Headers;
			string name4 = "X-Kony-API-Version";
			headers4[name4] = KONY_API_VERSION;
			using (Stream stream = httpWebRequest.GetRequestStream())
			{
				stream.Write(bytes, 0, bytes.Length);
				stream.Close();
			}
			HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			Stream responseStream = httpWebResponse.GetResponseStream();
			string value6 = new StreamReader(responseStream).ReadToEnd();
			responseStream.Close();
			if (httpWebResponse.StatusCode != HttpStatusCode.OK)
			{
				sbiPaymentRequest.currentStatus = false;
				string currentMessage = "Something wrong -S1";
				sbiPaymentRequest.currentMessage = currentMessage;
				return sbiPaymentRequest;
			}
			BaseResponseBody baseResponseBody = JsonConvert.DeserializeObject<BaseResponseBody>(value6);
			string code = baseResponseBody.code;
			string text = "null";
			if (code != text || baseResponseBody.encData == null || baseResponseBody.status == null || baseResponseBody.httpStatusCode != 200)
			{
				sbiPaymentRequest.currentStatus = false;
				string currentMessage2 = "Something wrong -S2";
				sbiPaymentRequest.currentMessage = currentMessage2;
				return sbiPaymentRequest;
			}
			SecurityServiceResponseBody securityServiceResponseBody = JsonConvert.DeserializeObject<SecurityServiceResponseBody>(SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, "", getMpinMain(sbiPaymentRequest), getAppKeyMain(sbiPaymentRequest)));
			sbiPaymentRequest.keyId = securityServiceResponseBody.keyId;
			sbiPaymentRequest.serviceId = securityServiceResponseBody.serviceId;
			sbiPaymentRequest.currentStatus = true;
		}
		catch (Exception)
		{
			sbiPaymentRequest.currentStatus = false;
			string currentMessage3 = "Something wrong ex";
			sbiPaymentRequest.currentMessage = currentMessage3;
		}
		return sbiPaymentRequest;
	}

	public SBIPaymentRequest secureLoginServiceRequest(SBIPaymentRequest sbiPaymentRequest)
	{
		string requestUriString = SERVER_HOST + SECURITY_LOGIN_SERVICE_PATH;
		try
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			string key = "events";
			string value = "[]";
			dictionary.Add(key, value);
			string key2 = "serviceID";
			string value2 = "SecureLoginService";
			dictionary.Add(key2, value2);
			Header header = new Header();
			string bankCode = "0";
			header.bankCode = bankCode;
			header.token = "";
			header.userName = sbiPaymentRequest.Username;
			string key3 = "header";
			dictionary.Add(key3, Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(header))));
			BaseRequestBody baseRequestBody = new BaseRequestBody();
			baseRequestBody.body = new Body();
			baseRequestBody.body.secretKey = sbiPaymentRequest.securityKey;
			baseRequestBody.body.shaMpin = SBISecureCrypt.shaMpin(sbiPaymentRequest.Username, sbiPaymentRequest.mpinCode, sbiPaymentRequest.keyId);
			baseRequestBody.body.serviceId = sbiPaymentRequest.serviceId;
			baseRequestBody.body.deviceName = sbiPaymentRequest.phoneModel;
			baseRequestBody.body.imeiNo = sbiPaymentRequest.androidId;
			baseRequestBody.body.osName = sbiPaymentRequest.KONY_PLATFORM;
			baseRequestBody.body.mobileAppVersion = APP_VERSION;
			baseRequestBody.body.oSversion = sbiPaymentRequest.osVersion;
			baseRequestBody.security = new Security();
			baseRequestBody.security.appkey = "";
			baseRequestBody.security.mpin = "";
			baseRequestBody.security.token1 = "";
			baseRequestBody.security.token2 = "";
			string key4 = "encData";
			dictionary.Add(key4, SBISecureCrypt.EncryptEncData(JsonConvert.SerializeObject(baseRequestBody), sbiPaymentRequest.Username, sbiPaymentRequest.androidId, sbiPaymentRequest.mobAppKey));
			string key5 = "requestKey";
			dictionary.Add(key5, SBISecureCrypt.calcRequestKey(JsonConvert.SerializeObject(baseRequestBody)));
			string key6 = "jSessionId";
			dictionary.Add(key6, sbiPaymentRequest.jSessionId);
			string key7 = "ipAddress";
			dictionary.Add(key7, "");
			string key8 = "appID";
			dictionary.Add(key8, APP_ID);
			string key9 = "appver";
			dictionary.Add(key9, APP_VERSION);
			string key10 = "channel";
			dictionary.Add(key10, CHANNEL);
			string key11 = "platform";
			dictionary.Add(key11, sbiPaymentRequest.KONY_PLATFORM);
			string key12 = "cacheid";
			dictionary.Add(key12, "");
			string key13 = "konyreportingparams";
			string form = "frmLoginWithMPin";
			string serviceId = "SecureLoginService";
			dictionary.Add(key13, getKonyReportingParams(sbiPaymentRequest, form, serviceId));
			string formBody = getFormBody(dictionary);
			byte[] bytes = Encoding.UTF8.GetBytes(formBody);
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
			httpWebRequest.CookieContainer = cookieContainer;
			string method = "POST";
			httpWebRequest.Method = method;
			httpWebRequest.KeepAlive = true;
			httpWebRequest.UserAgent = sbiPaymentRequest.userAgent;
			WebHeaderCollection headers = httpWebRequest.Headers;
			string name = "Accept-Encoding";
			string value3 = "gzip,deflate";
			headers.Add(name, value3);
			httpWebRequest.ContentLength = bytes.Length;
			string contentType = "application/json";
			httpWebRequest.ContentType = contentType;
			httpWebRequest.ServicePoint.Expect100Continue = true;
			WebHeaderCollection headers2 = httpWebRequest.Headers;
			string name2 = "Cache-Control";
			string value4 = "no-cache";
			headers2[name2] = value4;
			WebHeaderCollection headers3 = httpWebRequest.Headers;
			string name3 = "X-Kony-Authorizationn";
			headers3[name3] = sbiPaymentRequest.claimsToken.value;
			WebHeaderCollection headers4 = httpWebRequest.Headers;
			string name4 = "X-Kony-API-Version";
			headers4[name4] = KONY_API_VERSION;
			using (Stream stream = httpWebRequest.GetRequestStream())
			{
				stream.Write(bytes, 0, bytes.Length);
				stream.Close();
			}
			HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			Stream responseStream = httpWebResponse.GetResponseStream();
			string value5 = new StreamReader(responseStream).ReadToEnd();
			responseStream.Close();
			if (httpWebResponse.StatusCode != HttpStatusCode.OK)
			{
				sbiPaymentRequest.currentStatus = false;
				string currentMessage = "Something wrong -L0";
				sbiPaymentRequest.currentMessage = currentMessage;
				return sbiPaymentRequest;
			}
			BaseResponseBody baseResponseBody = JsonConvert.DeserializeObject<BaseResponseBody>(value5);
			string code = baseResponseBody.code;
			string text = "null";
			if (code != text || baseResponseBody.encData == null || baseResponseBody.status == null || baseResponseBody.httpStatusCode != 200)
			{
				sbiPaymentRequest.currentStatus = false;
				string currentMessage2 = "Something wrong -L1";
				sbiPaymentRequest.currentMessage = currentMessage2;
				BaseResponseBodyStatus baseResponseBodyStatus = JsonConvert.DeserializeObject<BaseResponseBodyStatus>(baseResponseBody.status);
				if (baseResponseBodyStatus != null)
				{
					sbiPaymentRequest.currentMessage = baseResponseBodyStatus.statusDesc;
				}
				return sbiPaymentRequest;
			}
			SBISecureCrypt.DecryptResponseEncData(baseResponseBody.status, sbiPaymentRequest.Username, sbiPaymentRequest.androidId, sbiPaymentRequest.mobAppKey);
			LoginValidateResponseBody loginValidateResponseBody = JsonConvert.DeserializeObject<LoginValidateResponseBody>(SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, sbiPaymentRequest.Username, sbiPaymentRequest.androidId, sbiPaymentRequest.mobAppKey));
			if (loginValidateResponseBody.status)
			{
				sbiPaymentRequest.jSessionId = loginValidateResponseBody.jSessionId;
				sbiPaymentRequest.uId = loginValidateResponseBody.uId;
				sbiPaymentRequest.currentStatus = true;
			}
			else
			{
				sbiPaymentRequest.currentStatus = false;
				string currentMessage3 = "Something wrong -L2";
				sbiPaymentRequest.currentMessage = currentMessage3;
			}
		}
		catch (Exception)
		{
			sbiPaymentRequest.currentStatus = false;
			string currentMessage4 = "Something wrong ex";
			sbiPaymentRequest.currentMessage = currentMessage4;
		}
		return sbiPaymentRequest;
	}

	public SBIPaymentRequest fetchOnlineOTPRequest(SBIPaymentRequest sbiPaymentRequest)
	{
		string requestUriString = SERVER_HOST + FETCH_ONLINE_OTP_PATH;
		try
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			string key = "events";
			string value = "[]";
			dictionary.Add(key, value);
			string key2 = "serviceID";
			string value2 = "FetchOnlineOTP";
			dictionary.Add(key2, value2);
			Header header = new Header();
			string bankCode = "0";
			header.bankCode = bankCode;
			header.token = "";
			header.userName = sbiPaymentRequest.Username;
			string key3 = "header";
			dictionary.Add(key3, Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(header))));
			BaseRequestBody baseRequestBody = new BaseRequestBody();
			baseRequestBody.body = new Body();
			baseRequestBody.body.secretKey = sbiPaymentRequest.securityKey;
			baseRequestBody.security = new Security();
			baseRequestBody.security.appkey = sbiPaymentRequest.mobAppKey;
			baseRequestBody.security.mpin = sbiPaymentRequest.androidId;
			baseRequestBody.security.token1 = sbiPaymentRequest.jSessionId;
			baseRequestBody.security.token2 = sbiPaymentRequest.uId;
			string key4 = "encData";
			dictionary.Add(key4, SBISecureCrypt.EncryptEncData(JsonConvert.SerializeObject(baseRequestBody), sbiPaymentRequest.Username, sbiPaymentRequest.androidId, sbiPaymentRequest.mobAppKey));
			string key5 = "requestKey";
			dictionary.Add(key5, SBISecureCrypt.calcRequestKey(JsonConvert.SerializeObject(baseRequestBody)));
			string key6 = "appID";
			dictionary.Add(key6, APP_ID);
			string key7 = "appver";
			dictionary.Add(key7, APP_VERSION);
			string key8 = "channel";
			dictionary.Add(key8, CHANNEL);
			string key9 = "platform";
			dictionary.Add(key9, sbiPaymentRequest.KONY_PLATFORM);
			string key10 = "cacheid";
			dictionary.Add(key10, "");
			string key11 = "konyreportingparams";
			string form = "frmLandingPageNew";
			string serviceId = "FetchOnlineOTP";
			dictionary.Add(key11, getKonyReportingParams(sbiPaymentRequest, form, serviceId));
			string formBody = getFormBody(dictionary);
			byte[] bytes = Encoding.UTF8.GetBytes(formBody);
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
			httpWebRequest.CookieContainer = cookieContainer;
			string method = "POST";
			httpWebRequest.Method = method;
			httpWebRequest.KeepAlive = true;
			httpWebRequest.UserAgent = sbiPaymentRequest.userAgent;
			WebHeaderCollection headers = httpWebRequest.Headers;
			string name = "Accept-Encoding";
			string value3 = "gzip,deflate";
			headers.Add(name, value3);
			httpWebRequest.ContentLength = bytes.Length;
			string contentType = "application/json";
			httpWebRequest.ContentType = contentType;
			httpWebRequest.ServicePoint.Expect100Continue = true;
			WebHeaderCollection headers2 = httpWebRequest.Headers;
			string name2 = "Cache-Control";
			string value4 = "no-cache";
			headers2[name2] = value4;
			WebHeaderCollection headers3 = httpWebRequest.Headers;
			string name3 = "X-Kony-Authorizationn";
			headers3[name3] = sbiPaymentRequest.claimsToken.value;
			WebHeaderCollection headers4 = httpWebRequest.Headers;
			string name4 = "X-Kony-API-Version";
			headers4[name4] = KONY_API_VERSION;
			using (Stream stream = httpWebRequest.GetRequestStream())
			{
				stream.Write(bytes, 0, bytes.Length);
				stream.Close();
			}
			HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			Stream responseStream = httpWebResponse.GetResponseStream();
			string value5 = new StreamReader(responseStream).ReadToEnd();
			responseStream.Close();
			if (httpWebResponse.StatusCode != HttpStatusCode.OK)
			{
				sbiPaymentRequest.currentStatus = false;
				string currentMessage = "Something wrong";
				sbiPaymentRequest.currentMessage = currentMessage;
			}
			BaseResponseBody baseResponseBody = JsonConvert.DeserializeObject<BaseResponseBody>(value5);
			string code = baseResponseBody.code;
			string text = "null";
			if (code != text || baseResponseBody.encData == null || baseResponseBody.status == null || baseResponseBody.httpStatusCode != 200)
			{
				sbiPaymentRequest.currentStatus = false;
				string currentMessage2 = "Something wrong";
				sbiPaymentRequest.currentMessage = currentMessage2;
			}
			string value6 = SBISecureCrypt.DecryptResponseEncData(baseResponseBody.status, sbiPaymentRequest.Username, sbiPaymentRequest.androidId, sbiPaymentRequest.mobAppKey);
			string value7 = SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, sbiPaymentRequest.Username, sbiPaymentRequest.androidId, sbiPaymentRequest.mobAppKey);
			FetchOTPResponseStatus fetchOTPResponseStatus = JsonConvert.DeserializeObject<FetchOTPResponseStatus>(value6);
			string text2 = "Session Expired";
			if (text2.Equals(fetchOTPResponseStatus.statusDesc))
			{
				sbiPaymentRequest.currentStatus = false;
				string currentMessage3 = "Try again";
				sbiPaymentRequest.currentMessage = currentMessage3;
				return sbiPaymentRequest;
			}
			FetchOTPResponse fetchOTPResponse = JsonConvert.DeserializeObject<FetchOTPResponse>(value7);
			string text3 = "Success";
			if (text3.Equals(fetchOTPResponse.status))
			{
				sbiPaymentRequest.currentStatus = true;
				sbiPaymentRequest.currentMessage = fetchOTPResponse.otpMessage;
				sbiPaymentRequest.currentOtp = fetchOTPResponse.onlineOtp;
				sbiPaymentRequest.otpTransactionType = fetchOTPResponse.transactionType;
				string otpTransactionType = sbiPaymentRequest.otpTransactionType;
				string value8 = "MP";
				if (otpTransactionType.Equals(value8))
				{
					sbiPaymentRequest.otpAmount = fetchOTPResponse.amount;
				}
			}
			else
			{
				sbiPaymentRequest.currentStatus = true;
				sbiPaymentRequest.currentMessage = fetchOTPResponse.errorMsg;
			}
		}
		catch (Exception)
		{
			sbiPaymentRequest.currentStatus = false;
			string currentMessage4 = "Something wrong ex";
			sbiPaymentRequest.currentMessage = currentMessage4;
		}
		return sbiPaymentRequest;
	}

	private string getFormBody(Dictionary<string, string> map)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (KeyValuePair<string, string> item in map)
		{
			StringBuilder stringBuilder2 = stringBuilder.Append(SBISecureCrypt.UpperCaseUrlEncode(item.Key, Encoding.UTF8));
			string value = "=";
			StringBuilder stringBuilder3 = stringBuilder2.Append(value).Append(SBISecureCrypt.UpperCaseUrlEncode(item.Value, Encoding.UTF8));
			string value2 = "&";
			stringBuilder3.Append(value2);
		}
		return stringBuilder.Remove(stringBuilder.Length - 1, 1).ToString();
	}

	private string getKonyReportingParams(SBIPaymentRequest sbiPaymentRequest, string form, string serviceId)
	{
		ReportParams reportParams = new ReportParams
		{
			os = sbiPaymentRequest.osVersion,
			dm = sbiPaymentRequest.phoneModel,
			did = sbiPaymentRequest.androidId,
			ua = sbiPaymentRequest.phoneModel,
			aid = APP_ID,
			aname = APP_NAME
		};
		string chnl = "mobile";
		reportParams.chnl = chnl;
		reportParams.plat = sbiPaymentRequest.KONY_PLATFORM;
		reportParams.aver = APP_VERSION;
		string atype = "native";
		reportParams.atype = atype;
		string stype = "b2c";
		reportParams.stype = stype;
		reportParams.kuid = "";
		reportParams.mfaid = sbiPaymentRequest.CONFIG_APP_ID;
		reportParams.mfbaseid = sbiPaymentRequest.CONFIG_BASE_ID;
		reportParams.mfaname = sbiPaymentRequest.CONFIG_APP_NAME;
		reportParams.sdkversion = sbiPaymentRequest.KONY_SDK_VERSION;
		reportParams.sdktype = sbiPaymentRequest.KONY_SDK_TYPE;
		reportParams.fid = form;
		reportParams.rsid = sbiPaymentRequest.KONY_RSID;
		reportParams.svcid = serviceId;
		return JsonConvert.SerializeObject(reportParams);
	}

	public string getMpinMain(SBIPaymentRequest sbiPaymentRequest)
	{
		return sbiPaymentRequest.MPIN_MAIN;
	}

	public string getAppKeyMain(SBIPaymentRequest sbiPaymentRequest)
	{
		return sbiPaymentRequest.APP_KEY_MAIN;
	}

	static SbiSecureService()
	{
		string sERVER_HOST = "https://api.yonobusinessmobile.sbi";
		SERVER_HOST = sERVER_HOST;
		SERVER_PORT = 443;
		string aUTH_SERVICE_PATH = "/authService/100000002/login";
		AUTH_SERVICE_PATH = aUTH_SERVICE_PATH;
		string sMART_SEC_SERVICE_PATH = "/services1/SBISmartOTPCheService1/SmartSecService";
		SMART_SEC_SERVICE_PATH = sMART_SEC_SERVICE_PATH;
		string sECURITY_LOGIN_SERVICE_PATH = "/services1/SBISmartOTPCheService1/SecureLoginService";
		SECURITY_LOGIN_SERVICE_PATH = sECURITY_LOGIN_SERVICE_PATH;
		string fETCH_ONLINE_OTP_PATH = "/services1/SBISmartOTPCheService1/FetchOnlineOTP";
		FETCH_ONLINE_OTP_PATH = fETCH_ONLINE_OTP_PATH;
		string kONY_API_VERSION = "1.0";
		KONY_API_VERSION = kONY_API_VERSION;
		string aPP_ID = "OnlineOTP";
		APP_ID = aPP_ID;
		string aPP_NAME = "SBI Secure OTP";
		APP_NAME = aPP_NAME;
		string aPP_VERSION = "2.3.3";
		APP_VERSION = aPP_VERSION;
		string cHANNEL = "mobile";
		CHANNEL = cHANNEL;
	}
}
