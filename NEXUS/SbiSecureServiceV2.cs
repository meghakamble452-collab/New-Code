using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace NEXUS;

public class SbiSecureServiceV2
{
	private CookieContainer cookieContainer = new CookieContainer();

	public static string SALT;

	public static string SECRET_KEY;

	public static string MPIN_MAIN;

	public static string APP_KEY_MAIN;

	public static string SERVER_HOST;

	public static int SERVER_PORT;

	public static string KONY_APP_KEY;

	public static string KONY_APP_SECRET;

	public static string KONY_SDK_VERSION;

	public static string KONY_PLATFORM;

	public static string KONY_SDK_TYPE;

	public static string KONY_API_VERSION;

	public static string APP_ID;

	public static string APP_NAME;

	public static string APP_VERSION;

	public static string CHANNEL;

	public static string CONFIG_APP_ID;

	public static string CONFIG_BASE_ID;

	public static string CONFIG_APP_NAME;

	public static string KONY_RSID;

	public static string PHONE_AUTHORIZATION;

	public static string AUTH_SERVICE_PATH;

	public static string FETCH_DATE_TIME_PATH;

	public static string SECURITY_SERVICE_PATH;

	public static string LOGIN_VALIDATE_PATH;

	public static string ENABLE_HIGH_SECURITY_SERVICE_PATH;

	public static string ENABLE_HIGH_SECURITY_CONFIRM_SERVICE_PATH;

	public static string QUESTION_SUBMIT_SERVICE_PATH;

	public static string SMART_SEC_SERVICE_PATH;

	public static string SECURITY_LOGIN_SERVICE_PATH;

	public static string FETCH_ONLINE_OTP_PATH;

	public SBIPaymentRequest authServiceRequest(SBIPaymentRequest sbiPaymentRequest)
	{
		string value = "===============================authServiceRequest==========================";
		Console.WriteLine(value);
		string text = SERVER_HOST + AUTH_SERVICE_PATH;
		Console.WriteLine(text);
		try
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
			string method = "POST";
			httpWebRequest.Method = method;
			httpWebRequest.KeepAlive = true;
			httpWebRequest.UserAgent = sbiPaymentRequest.userAgent;
			WebHeaderCollection headers = httpWebRequest.Headers;
			string name = "Accept-Encoding";
			string value2 = "gzip,deflate";
			headers.Add(name, value2);
			httpWebRequest.ContentLength = 0L;
			string contentType = "application/x-www-form-urlencoded";
			httpWebRequest.ContentType = contentType;
			string accept = "application/json";
			httpWebRequest.Accept = accept;
			httpWebRequest.ServicePoint.Expect100Continue = true;
			WebHeaderCollection headers2 = httpWebRequest.Headers;
			string name2 = "Cache-Control";
			string value3 = "no-cache";
			headers2[name2] = value3;
			WebHeaderCollection headers3 = httpWebRequest.Headers;
			string name3 = "X-Kony-SDK-Version";
			headers3[name3] = KONY_SDK_VERSION;
			WebHeaderCollection headers4 = httpWebRequest.Headers;
			string name4 = "X-Kony-App-Key";
			headers4[name4] = KONY_APP_KEY;
			WebHeaderCollection headers5 = httpWebRequest.Headers;
			string name5 = "X-Kony-App-Secret";
			headers5[name5] = KONY_APP_SECRET;
			WebHeaderCollection headers6 = httpWebRequest.Headers;
			string name6 = "X-Kony-Platform";
			headers6[name6] = KONY_PLATFORM;
			WebHeaderCollection headers7 = httpWebRequest.Headers;
			string name7 = "X-Kony-SDK-Type";
			headers7[name7] = KONY_SDK_TYPE;
			HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			Stream responseStream = httpWebResponse.GetResponseStream();
			string text2 = new StreamReader(responseStream).ReadToEnd();
			string text3 = "Response for authServiceRequest request\n{0}";
			Console.WriteLine(text3 + text2);
			responseStream.Close();
			if (httpWebResponse.StatusCode != HttpStatusCode.OK)
			{
				string text4 = "Something wrong in authServiceRequest \n";
				Console.WriteLine(text4 + text2);
				sbiPaymentRequest.currentStatus = false;
				string currentMessage = "Something wrong";
				sbiPaymentRequest.currentMessage = currentMessage;
			}
			else
			{
				AuthServiceResponse authServiceResponse = JsonConvert.DeserializeObject<AuthServiceResponse>(text2);
				if (authServiceResponse.claims_token != null && authServiceResponse.claims_token.value != null && authServiceResponse.refresh_token != null)
				{
					sbiPaymentRequest.claimsToken = authServiceResponse.claims_token;
					sbiPaymentRequest.currentStatus = true;
				}
				else
				{
					string value4 = "Something wrong in authServiceRequest request\n";
					Console.WriteLine(value4);
					sbiPaymentRequest.currentStatus = false;
					string currentMessage2 = "Something wrong";
					sbiPaymentRequest.currentMessage = currentMessage2;
				}
			}
		}
		catch (Exception ex)
		{
			string text5 = "Error ";
			Console.WriteLine(text5 + ex.Message);
			sbiPaymentRequest.currentStatus = false;
			string currentMessage3 = "Something wrong ex";
			sbiPaymentRequest.currentMessage = currentMessage3;
		}
		return sbiPaymentRequest;
	}

	public SBIPaymentRequest fetchDateTimeRequest(SBIPaymentRequest sbiPaymentRequest)
	{
		string value = "===============================fetchDateTimeRequest==========================";
		Console.WriteLine(value);
		string text = SERVER_HOST + FETCH_DATE_TIME_PATH;
		Console.WriteLine(text);
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		string key = "events";
		string value2 = "[]";
		dictionary.Add(key, value2);
		string key2 = "serviceID";
		string value3 = "FetchDateTime";
		dictionary.Add(key2, value3);
		try
		{
			Header header = new Header();
			header.bankCode = "";
			header.token = "";
			header.userName = "";
			Console.WriteLine(JsonConvert.SerializeObject(header));
			string key3 = "header";
			dictionary.Add(key3, Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(header))));
			BaseRequestBody baseRequestBody = new BaseRequestBody();
			baseRequestBody.body = new Body();
			baseRequestBody.security = new Security();
			baseRequestBody.security.appkey = "";
			baseRequestBody.security.mpin = "";
			baseRequestBody.security.token1 = "";
			baseRequestBody.security.token2 = "";
			Console.WriteLine(JsonConvert.SerializeObject(baseRequestBody));
			string key4 = "encData";
			dictionary.Add(key4, SBISecureCrypt.EncryptEncData(JsonConvert.SerializeObject(baseRequestBody), "", MPIN_MAIN, APP_KEY_MAIN));
			string key5 = "requestKey";
			dictionary.Add(key5, SBISecureCrypt.calcRequestKey(JsonConvert.SerializeObject(baseRequestBody)));
			string key6 = "appID";
			dictionary.Add(key6, APP_ID);
			string key7 = "appver";
			dictionary.Add(key7, APP_VERSION);
			string key8 = "channel";
			dictionary.Add(key8, CHANNEL);
			string key9 = "platform";
			dictionary.Add(key9, KONY_PLATFORM);
			string key10 = "cacheid";
			dictionary.Add(key10, "");
			string key11 = "konyreportingparams";
			string form = "frmSimRegister";
			string serviceId = "FetchDateTime";
			dictionary.Add(key11, getKonyReportingParams(sbiPaymentRequest, form, serviceId));
			string formBody = getFormBody(dictionary);
			Console.WriteLine(formBody);
			byte[] bytes = Encoding.UTF8.GetBytes(formBody);
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
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
			string text2 = new StreamReader(responseStream).ReadToEnd();
			string text3 = "Response for fetchDateTimeRequest request\n{0}";
			Console.WriteLine(text3 + text2);
			responseStream.Close();
			if (httpWebResponse.StatusCode != HttpStatusCode.OK)
			{
				string text4 = "Something wrong in fetchDateTimeRequest\n";
				throw new IOException(text4 + text2);
			}
			BaseResponseBody baseResponseBody = JsonConvert.DeserializeObject<BaseResponseBody>(text2);
			string code = baseResponseBody.code;
			string text5 = "null";
			if (code != text5 || baseResponseBody.encData == null || baseResponseBody.status == null || baseResponseBody.httpStatusCode != 200)
			{
				string text6 = "Something wrong in fetchDateTimeRequest request\n";
				throw new IOException(text6 + text2);
			}
			Console.WriteLine(JsonConvert.SerializeObject(JsonConvert.DeserializeObject<FetchDateTimeResponseBody>(SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, "", MPIN_MAIN, APP_KEY_MAIN))));
			sbiPaymentRequest.phoneNumberForSmsSend = PHONE_AUTHORIZATION;
			sbiPaymentRequest.smsText = getSmsText(sbiPaymentRequest);
		}
		catch (Exception ex)
		{
			string text7 = "Error ";
			Console.WriteLine(text7 + ex.Message);
			sbiPaymentRequest.currentStatus = false;
			string currentMessage = "Something wrong fetchDateTimeRequest";
			sbiPaymentRequest.currentMessage = currentMessage;
		}
		return sbiPaymentRequest;
	}

	public SBIPaymentRequest securityServiceRequest(SBIPaymentRequest sbiPaymentRequest)
	{
		string value = "===============================securityServiceRequest==========================";
		Console.WriteLine(value);
		string text = SERVER_HOST + SECURITY_SERVICE_PATH;
		Console.WriteLine(text);
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		string key = "events";
		string value2 = "[]";
		dictionary.Add(key, value2);
		string key2 = "serviceID";
		string value3 = "SecurityService";
		dictionary.Add(key2, value3);
		string key3 = "optionalFlagFomUI";
		string value4 = "false";
		dictionary.Add(key3, value4);
		Header value5 = new Header
		{
			bankCode = "",
			token = "",
			userName = ""
		};
		Console.WriteLine(JsonConvert.SerializeObject(value5));
		string key4 = "header";
		dictionary.Add(key4, Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value5))));
		BaseRequestBody baseRequestBody = new BaseRequestBody();
		baseRequestBody.body = new Body();
		baseRequestBody.security = new Security();
		baseRequestBody.security.appkey = "";
		baseRequestBody.security.mpin = "";
		baseRequestBody.security.token1 = "";
		baseRequestBody.security.token2 = "";
		Console.WriteLine(JsonConvert.SerializeObject(baseRequestBody));
		string key5 = "encData";
		dictionary.Add(key5, SBISecureCrypt.EncryptEncData(JsonConvert.SerializeObject(baseRequestBody), "", MPIN_MAIN, APP_KEY_MAIN));
		string key6 = "requestKey";
		dictionary.Add(key6, SBISecureCrypt.calcRequestKey(JsonConvert.SerializeObject(baseRequestBody)));
		string key7 = "appID";
		dictionary.Add(key7, APP_ID);
		string key8 = "appver";
		dictionary.Add(key8, APP_VERSION);
		string key9 = "channel";
		dictionary.Add(key9, CHANNEL);
		string key10 = "platform";
		dictionary.Add(key10, KONY_PLATFORM);
		string key11 = "cacheid";
		dictionary.Add(key11, "");
		string key12 = "konyreportingparams";
		string form = "frmRegister";
		string serviceId = "SecurityService";
		dictionary.Add(key12, getKonyReportingParams(sbiPaymentRequest, form, serviceId));
		string formBody = getFormBody(dictionary);
		Console.WriteLine(formBody);
		byte[] bytes = Encoding.UTF8.GetBytes(formBody);
		HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
		httpWebRequest.CookieContainer = cookieContainer;
		string method = "POST";
		httpWebRequest.Method = method;
		httpWebRequest.KeepAlive = true;
		httpWebRequest.UserAgent = sbiPaymentRequest.userAgent;
		WebHeaderCollection headers = httpWebRequest.Headers;
		string name = "Accept-Encoding";
		string value6 = "gzip,deflate";
		headers.Add(name, value6);
		httpWebRequest.ContentLength = bytes.Length;
		string contentType = "application/json";
		httpWebRequest.ContentType = contentType;
		httpWebRequest.ServicePoint.Expect100Continue = true;
		WebHeaderCollection headers2 = httpWebRequest.Headers;
		string name2 = "Cache-Control";
		string value7 = "no-cache";
		headers2[name2] = value7;
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
		string text2 = new StreamReader(responseStream).ReadToEnd();
		string text3 = "Response for securityServiceRequest request\n{0}";
		Console.WriteLine(text3 + text2);
		responseStream.Close();
		if (httpWebResponse.StatusCode != HttpStatusCode.OK)
		{
			string text4 = "Something wrong in securityServiceRequest\n";
			throw new IOException(text4 + text2);
		}
		BaseResponseBody baseResponseBody = JsonConvert.DeserializeObject<BaseResponseBody>(text2);
		string code = baseResponseBody.code;
		string text5 = "null";
		if (code != text5 || baseResponseBody.encData == null || baseResponseBody.status == null || baseResponseBody.httpStatusCode != 200)
		{
			string text6 = "Something wrong in securityServiceRequest request\n";
			throw new IOException(text6 + text2);
		}
		string text7 = "securityServiceRequest encData==>";
		Console.WriteLine(text7 + SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, "", MPIN_MAIN, APP_KEY_MAIN));
		string text8 = "securityServiceRequest status ==>";
		Console.WriteLine(text8 + SBISecureCrypt.DecryptResponseEncData(baseResponseBody.status, "", MPIN_MAIN, APP_KEY_MAIN));
		SecurityServiceResponseBody securityServiceResponseBody = JsonConvert.DeserializeObject<SecurityServiceResponseBody>(SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, "", MPIN_MAIN, APP_KEY_MAIN));
		Console.WriteLine(JsonConvert.SerializeObject(securityServiceResponseBody));
		sbiPaymentRequest.keyId = securityServiceResponseBody.keyId;
		sbiPaymentRequest.serviceId = securityServiceResponseBody.serviceId;
		return sbiPaymentRequest;
	}

	public SBIPaymentRequest loginValidateRequest(SBIPaymentRequest sbiPaymentRequest)
	{
		string value = "===============================loginValidateRequest==========================";
		Console.WriteLine(value);
		string text = SERVER_HOST + LOGIN_VALIDATE_PATH;
		Console.WriteLine(text);
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		string key = "events";
		string value2 = "[]";
		dictionary.Add(key, value2);
		string key2 = "serviceID";
		string value3 = "LoginValidate";
		dictionary.Add(key2, value3);
		Header header = new Header();
		string bankCode = "0";
		header.bankCode = bankCode;
		header.token = "";
		header.userName = sbiPaymentRequest.Username;
		Console.WriteLine(JsonConvert.SerializeObject(header));
		string key3 = "header";
		dictionary.Add(key3, Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(header))));
		BaseRequestBody baseRequestBody = new BaseRequestBody();
		baseRequestBody.body = new Body();
		baseRequestBody.body.md5Password = SBISecureCrypt.md5Password(sbiPaymentRequest.Username, sbiPaymentRequest.Password, sbiPaymentRequest.keyId);
		baseRequestBody.body.shaPassword = SBISecureCrypt.shaPassword(sbiPaymentRequest.Username, sbiPaymentRequest.Password, sbiPaymentRequest.keyId);
		baseRequestBody.body.serviceId = sbiPaymentRequest.serviceId;
		baseRequestBody.body.deviceName = sbiPaymentRequest.phoneModel;
		baseRequestBody.body.imeiNo = sbiPaymentRequest.androidId;
		baseRequestBody.body.osName = KONY_PLATFORM;
		baseRequestBody.body.mobileAppVersion = APP_VERSION;
		baseRequestBody.body.oSversion = sbiPaymentRequest.osVersion;
		baseRequestBody.body.encKeyValue = sbiPaymentRequest.smsText;
		Body body = baseRequestBody.body;
		DateTime indiaDateTime = getIndiaDateTime();
		string text2 = "MM/dd/yyyy HH:mm:ss";
		string name = "en-US";
		body.currentDate = indiaDateTime.ToString(text2, CultureInfo.CreateSpecificCulture(name));
		baseRequestBody.security = new Security();
		baseRequestBody.security.appkey = "";
		baseRequestBody.security.mpin = "";
		baseRequestBody.security.token1 = "";
		baseRequestBody.security.token2 = "";
		Console.WriteLine(JsonConvert.SerializeObject(baseRequestBody));
		string key4 = "encData";
		dictionary.Add(key4, SBISecureCrypt.EncryptEncData(JsonConvert.SerializeObject(baseRequestBody), sbiPaymentRequest.Username, MPIN_MAIN, APP_KEY_MAIN));
		string key5 = "requestKey";
		dictionary.Add(key5, SBISecureCrypt.calcRequestKey(JsonConvert.SerializeObject(baseRequestBody)));
		string key6 = "jSessionId";
		dictionary.Add(key6, "");
		string key7 = "ipAddress";
		dictionary.Add(key7, "");
		string key8 = "appID";
		dictionary.Add(key8, APP_ID);
		string key9 = "appver";
		dictionary.Add(key9, APP_VERSION);
		string key10 = "channel";
		dictionary.Add(key10, CHANNEL);
		string key11 = "platform";
		dictionary.Add(key11, KONY_PLATFORM);
		string key12 = "cacheid";
		dictionary.Add(key12, "");
		string key13 = "konyreportingparams";
		string form = "frmRegister";
		string serviceId = "LoginValidate";
		dictionary.Add(key13, getKonyReportingParams(sbiPaymentRequest, form, serviceId));
		string formBody = getFormBody(dictionary);
		string text3 = "LoginValidate PsotData ==> ";
		Console.WriteLine(text3 + formBody);
		byte[] bytes = Encoding.UTF8.GetBytes(formBody);
		HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
		httpWebRequest.CookieContainer = cookieContainer;
		string method = "POST";
		httpWebRequest.Method = method;
		httpWebRequest.KeepAlive = true;
		httpWebRequest.UserAgent = sbiPaymentRequest.userAgent;
		WebHeaderCollection headers = httpWebRequest.Headers;
		string name2 = "Accept-Encoding";
		string value4 = "gzip,deflate";
		headers.Add(name2, value4);
		httpWebRequest.ContentLength = bytes.Length;
		string contentType = "application/json";
		httpWebRequest.ContentType = contentType;
		httpWebRequest.ServicePoint.Expect100Continue = true;
		WebHeaderCollection headers2 = httpWebRequest.Headers;
		string name3 = "Cache-Control";
		string value5 = "no-cache";
		headers2[name3] = value5;
		WebHeaderCollection headers3 = httpWebRequest.Headers;
		string name4 = "X-Kony-Authorizationn";
		headers3[name4] = sbiPaymentRequest.claimsToken.value;
		WebHeaderCollection headers4 = httpWebRequest.Headers;
		string name5 = "X-Kony-API-Version";
		headers4[name5] = KONY_API_VERSION;
		using (Stream stream = httpWebRequest.GetRequestStream())
		{
			stream.Write(bytes, 0, bytes.Length);
			stream.Close();
		}
		HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
		Stream responseStream = httpWebResponse.GetResponseStream();
		string text4 = new StreamReader(responseStream).ReadToEnd();
		string text5 = "Response for loginValidateRequest request\n{0}";
		Console.WriteLine(text5 + text4);
		responseStream.Close();
		if (httpWebResponse.StatusCode != HttpStatusCode.OK)
		{
			string text6 = "Something wrong in loginValidateRequest\n";
			throw new IOException(text6 + text4);
		}
		BaseResponseBody baseResponseBody = JsonConvert.DeserializeObject<BaseResponseBody>(text4);
		string code = baseResponseBody.code;
		string text7 = "null";
		if (code != text7 || baseResponseBody.encData == null || baseResponseBody.status == null || baseResponseBody.httpStatusCode != 200)
		{
			string text8 = "Something wrong in loginValidateRequest request\n";
			throw new IOException(text8 + text4);
		}
		string text9 = "securityServiceRequest encData";
		Console.WriteLine(text9 + SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, sbiPaymentRequest.Username, MPIN_MAIN, APP_KEY_MAIN));
		string text10 = "securityServiceRequest status";
		Console.WriteLine(text10 + SBISecureCrypt.DecryptResponseEncData(baseResponseBody.status, sbiPaymentRequest.Username, MPIN_MAIN, APP_KEY_MAIN));
		LoginValidateResponseBody loginValidateResponseBody = JsonConvert.DeserializeObject<LoginValidateResponseBody>(SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, sbiPaymentRequest.Username, MPIN_MAIN, APP_KEY_MAIN));
		Console.WriteLine(JsonConvert.SerializeObject(loginValidateResponseBody));
		sbiPaymentRequest.jSessionId = loginValidateResponseBody.jSessionId;
		sbiPaymentRequest.uId = loginValidateResponseBody.uId;
		return sbiPaymentRequest;
	}

	public SBIPaymentRequest enableHighSecurityServiceRequest(SBIPaymentRequest sbiPaymentRequest)
	{
		string value = "===============================enableHighSecurityServiceRequest==========================";
		Console.WriteLine(value);
		string text = SERVER_HOST + ENABLE_HIGH_SECURITY_SERVICE_PATH;
		Console.WriteLine(text);
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		string key = "events";
		string value2 = "[]";
		dictionary.Add(key, value2);
		string key2 = "serviceID";
		string value3 = "EnableHighSecurityService";
		dictionary.Add(key2, value3);
		Header header = new Header();
		string bankCode = "0";
		header.bankCode = bankCode;
		header.token = "";
		header.userName = sbiPaymentRequest.Username;
		Console.WriteLine(JsonConvert.SerializeObject(header));
		string key3 = "header";
		dictionary.Add(key3, Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(header))));
		BaseRequestBody baseRequestBody = new BaseRequestBody();
		baseRequestBody.body = new Body();
		baseRequestBody.security = new Security();
		baseRequestBody.security.appkey = APP_KEY_MAIN;
		baseRequestBody.security.mpin = MPIN_MAIN;
		baseRequestBody.security.token1 = sbiPaymentRequest.jSessionId;
		baseRequestBody.security.token2 = sbiPaymentRequest.uId;
		Console.WriteLine(JsonConvert.SerializeObject(baseRequestBody));
		string key4 = "encData";
		dictionary.Add(key4, SBISecureCrypt.EncryptEncData(JsonConvert.SerializeObject(baseRequestBody), sbiPaymentRequest.Username, MPIN_MAIN, APP_KEY_MAIN));
		string key5 = "requestKey";
		dictionary.Add(key5, SBISecureCrypt.calcRequestKey(JsonConvert.SerializeObject(baseRequestBody)));
		string key6 = "appID";
		dictionary.Add(key6, APP_ID);
		string key7 = "appver";
		dictionary.Add(key7, APP_VERSION);
		string key8 = "channel";
		dictionary.Add(key8, CHANNEL);
		string key9 = "platform";
		dictionary.Add(key9, KONY_PLATFORM);
		string key10 = "cacheid";
		dictionary.Add(key10, "");
		string key11 = "konyreportingparams";
		string form = "frmAgree";
		string serviceId = "EnableHighSecurityService";
		dictionary.Add(key11, getKonyReportingParams(sbiPaymentRequest, form, serviceId));
		string formBody = getFormBody(dictionary);
		Console.WriteLine(formBody);
		byte[] bytes = Encoding.UTF8.GetBytes(formBody);
		HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
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
		string text2 = new StreamReader(responseStream).ReadToEnd();
		string text3 = "Response for enableHighSecurityServiceRequest request\n";
		Console.WriteLine(text3 + text2);
		responseStream.Close();
		if (httpWebResponse.StatusCode != HttpStatusCode.OK)
		{
			string text4 = "Something wrong in enableHighSecurityServiceRequest\n";
			throw new IOException(text4 + text2);
		}
		BaseResponseBody baseResponseBody = JsonConvert.DeserializeObject<BaseResponseBody>(text2);
		string code = baseResponseBody.code;
		string text5 = "null";
		if (code != text5 || baseResponseBody.encData == null || baseResponseBody.status == null || baseResponseBody.httpStatusCode != 200)
		{
			string text6 = "Something wrong in enableHighSecurityServiceRequest request\n";
			throw new IOException(text6 + text2);
		}
		string text7 = "enableHighSecurityServiceRequest encData";
		Console.WriteLine(text7 + SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, sbiPaymentRequest.Username, MPIN_MAIN, APP_KEY_MAIN));
		string text8 = "enableHighSecurityServiceRequest status";
		Console.WriteLine(text8 + SBISecureCrypt.DecryptResponseEncData(baseResponseBody.status, sbiPaymentRequest.Username, MPIN_MAIN, APP_KEY_MAIN));
		Console.WriteLine(JsonConvert.SerializeObject(JsonConvert.DeserializeObject<EnableHighSecurityServiceResponseBody>(SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, sbiPaymentRequest.Username, MPIN_MAIN, APP_KEY_MAIN))));
		return sbiPaymentRequest;
	}

	public EnableHighSecurityConfirmServiceResponseBody enableHighSecurityConfirmServiceRequest(SBIPaymentRequest sbiPaymentRequest)
	{
		string value = "===============================enableHighSecurityConfirmServiceRequest==========================";
		Console.WriteLine(value);
		string text = SERVER_HOST + ENABLE_HIGH_SECURITY_CONFIRM_SERVICE_PATH;
		Console.WriteLine(text);
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		string key = "events";
		string value2 = "[]";
		dictionary.Add(key, value2);
		string key2 = "serviceID";
		string value3 = "EnableHighSecurityConfirmService";
		dictionary.Add(key2, value3);
		Header header = new Header();
		string bankCode = "0";
		header.bankCode = bankCode;
		header.token = "";
		header.userName = sbiPaymentRequest.Username;
		Console.WriteLine(JsonConvert.SerializeObject(header));
		string key3 = "header";
		dictionary.Add(key3, Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(header))));
		BaseRequestBody baseRequestBody = new BaseRequestBody();
		baseRequestBody.body = new Body();
		baseRequestBody.body.deviceId = sbiPaymentRequest.androidId;
		baseRequestBody.body.otp = sbiPaymentRequest.otp;
		baseRequestBody.security = new Security();
		baseRequestBody.security.appkey = APP_KEY_MAIN;
		baseRequestBody.security.mpin = MPIN_MAIN;
		baseRequestBody.security.token1 = sbiPaymentRequest.jSessionId;
		baseRequestBody.security.token2 = sbiPaymentRequest.uId;
		Console.WriteLine(JsonConvert.SerializeObject(baseRequestBody));
		string key4 = "encData";
		dictionary.Add(key4, SBISecureCrypt.EncryptEncData(JsonConvert.SerializeObject(baseRequestBody), sbiPaymentRequest.Username, MPIN_MAIN, APP_KEY_MAIN));
		string key5 = "requestKey";
		dictionary.Add(key5, SBISecureCrypt.calcRequestKey(JsonConvert.SerializeObject(baseRequestBody)));
		string key6 = "appID";
		dictionary.Add(key6, APP_ID);
		string key7 = "appver";
		dictionary.Add(key7, APP_VERSION);
		string key8 = "channel";
		dictionary.Add(key8, CHANNEL);
		string key9 = "platform";
		dictionary.Add(key9, KONY_PLATFORM);
		string key10 = "cacheid";
		dictionary.Add(key10, "");
		string key11 = "konyreportingparams";
		string form = "frmOTPConfirm";
		string serviceId = "EnableHighSecurityConfirmService";
		dictionary.Add(key11, getKonyReportingParams(sbiPaymentRequest, form, serviceId));
		string formBody = getFormBody(dictionary);
		Console.WriteLine(formBody);
		byte[] bytes = Encoding.UTF8.GetBytes(formBody);
		HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
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
		string text2 = new StreamReader(responseStream).ReadToEnd();
		string text3 = "Response for enableHighSecurityConfirmServiceRequest request\n{0}";
		Console.WriteLine(text3 + text2);
		responseStream.Close();
		if (httpWebResponse.StatusCode != HttpStatusCode.OK)
		{
			string text4 = "Something wrong in enableHighSecurityConfirmServiceRequest\n";
			throw new IOException(text4 + text2);
		}
		BaseResponseBody baseResponseBody = JsonConvert.DeserializeObject<BaseResponseBody>(text2);
		string code = baseResponseBody.code;
		string text5 = "null";
		if (code != text5 || baseResponseBody.encData == null || baseResponseBody.status == null || baseResponseBody.httpStatusCode != 200)
		{
			string text6 = "Something wrong in enableHighSecurityConfirmServiceRequest request\n";
			throw new IOException(text6 + text2);
		}
		string text7 = "enableHighSecurityConfirmServiceRequest encData";
		Console.WriteLine(text7 + SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, sbiPaymentRequest.Username, MPIN_MAIN, APP_KEY_MAIN));
		string text8 = "enableHighSecurityConfirmServiceRequest status";
		Console.WriteLine(text8 + SBISecureCrypt.DecryptResponseEncData(baseResponseBody.status, sbiPaymentRequest.Username, MPIN_MAIN, APP_KEY_MAIN));
		EnableHighSecurityConfirmServiceResponseBody enableHighSecurityConfirmServiceResponseBody = JsonConvert.DeserializeObject<EnableHighSecurityConfirmServiceResponseBody>(SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, sbiPaymentRequest.Username, MPIN_MAIN, APP_KEY_MAIN));
		Console.WriteLine(JsonConvert.SerializeObject(enableHighSecurityConfirmServiceResponseBody));
		sbiPaymentRequest.securityKey = enableHighSecurityConfirmServiceResponseBody.securityKey;
		sbiPaymentRequest.mobAppKey = enableHighSecurityConfirmServiceResponseBody.mobAppKey;
		sbiPaymentRequest.KONY_SDK_VERSION = KONY_SDK_VERSION;
		WebHeaderCollection headers5 = httpWebRequest.Headers;
		string name5 = "X-Kony-App-Key";
		headers5[name5] = sbiPaymentRequest.KONY_APP_KEY;
		WebHeaderCollection headers6 = httpWebRequest.Headers;
		string name6 = "X-Kony-App-Secret";
		headers6[name6] = sbiPaymentRequest.KONY_APP_SECRET;
		WebHeaderCollection headers7 = httpWebRequest.Headers;
		string name7 = "X-Kony-Platform";
		headers7[name7] = sbiPaymentRequest.KONY_PLATFORM;
		WebHeaderCollection headers8 = httpWebRequest.Headers;
		string name8 = "X-Kony-SDK-Type";
		headers8[name8] = sbiPaymentRequest.KONY_SDK_TYPE;
		return enableHighSecurityConfirmServiceResponseBody;
	}

	public QuestionSubmitServiceResponseBody questionSubmitServiceRequest(SBIPaymentRequest sbiPaymentRequest)
	{
		string value = "===============================questionSubmitServiceRequest==========================";
		Console.WriteLine(value);
		string text = SERVER_HOST + QUESTION_SUBMIT_SERVICE_PATH;
		Console.WriteLine(text);
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		string key = "events";
		string value2 = "[]";
		dictionary.Add(key, value2);
		string key2 = "serviceID";
		string value3 = "QuestionSubmitService";
		dictionary.Add(key2, value3);
		Header header = new Header();
		string bankCode = "0";
		header.bankCode = bankCode;
		header.token = "";
		header.userName = sbiPaymentRequest.Username;
		Console.WriteLine(JsonConvert.SerializeObject(header));
		string key3 = "header";
		dictionary.Add(key3, Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(header))));
		BaseRequestBody baseRequestBody = new BaseRequestBody();
		baseRequestBody.body = new Body();
		baseRequestBody.body.deviceId = sbiPaymentRequest.androidId;
		Body body = baseRequestBody.body;
		string answer = "andanswers";
		body.answer = answer;
		Body body2 = baseRequestBody.body;
		string question = "stop sending questions";
		body2.question = question;
		if (string.IsNullOrEmpty(sbiPaymentRequest.mpinCode))
		{
			string mpinCode = "0786";
			sbiPaymentRequest.mpinCode = mpinCode;
		}
		baseRequestBody.body.shaMpin = SBISecureCrypt.shaMpinSet(sbiPaymentRequest.Username, sbiPaymentRequest.mpinCode);
		baseRequestBody.body.securityKey = sbiPaymentRequest.securityKey;
		baseRequestBody.security = new Security();
		baseRequestBody.security.appkey = sbiPaymentRequest.securityKey;
		baseRequestBody.security.mpin = sbiPaymentRequest.androidId;
		baseRequestBody.security.token1 = sbiPaymentRequest.jSessionId;
		baseRequestBody.security.token2 = sbiPaymentRequest.uId;
		Console.WriteLine(JsonConvert.SerializeObject(baseRequestBody));
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
		dictionary.Add(key9, KONY_PLATFORM);
		string key10 = "cacheid";
		dictionary.Add(key10, "");
		string key11 = "konyreportingparams";
		string form = "frmSetPINNew";
		string serviceId = "QuestionSubmitService";
		dictionary.Add(key11, getKonyReportingParams(sbiPaymentRequest, form, serviceId));
		string formBody = getFormBody(dictionary);
		Console.WriteLine(formBody);
		byte[] bytes = Encoding.UTF8.GetBytes(formBody);
		HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
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
		string text2 = new StreamReader(responseStream).ReadToEnd();
		string text3 = "Response for questionSubmitServiceRequest request\n{0}";
		Console.WriteLine(text3 + text2);
		responseStream.Close();
		if (httpWebResponse.StatusCode != HttpStatusCode.OK)
		{
			string text4 = "Something wrong in questionSubmitServiceRequest\n";
			throw new IOException(text4 + text2);
		}
		BaseResponseBody baseResponseBody = JsonConvert.DeserializeObject<BaseResponseBody>(text2);
		string code = baseResponseBody.code;
		string text5 = "null";
		if (!(code != text5) && baseResponseBody.encData != null && baseResponseBody.status != null && baseResponseBody.httpStatusCode == 200)
		{
			string value6 = SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, sbiPaymentRequest.Username, sbiPaymentRequest.androidId, sbiPaymentRequest.mobAppKey);
			string text6 = "questionSubmitServiceRequest encData";
			Console.WriteLine(text6 + SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, sbiPaymentRequest.Username, sbiPaymentRequest.androidId, sbiPaymentRequest.mobAppKey));
			string text7 = "questionSubmitServiceRequest status";
			Console.WriteLine(text7 + SBISecureCrypt.DecryptResponseEncData(baseResponseBody.status, sbiPaymentRequest.Username, sbiPaymentRequest.androidId, sbiPaymentRequest.mobAppKey));
			QuestionSubmitServiceResponseBody questionSubmitServiceResponseBody = JsonConvert.DeserializeObject<QuestionSubmitServiceResponseBody>(value6);
			if (questionSubmitServiceResponseBody != null)
			{
				string status = questionSubmitServiceResponseBody.status;
				string value7 = "success";
				if (status.Equals(value7))
				{
					sbiPaymentRequest.KONY_SDK_VERSION = KONY_SDK_VERSION;
					sbiPaymentRequest.KONY_APP_KEY = KONY_APP_KEY;
					sbiPaymentRequest.KONY_APP_SECRET = KONY_APP_SECRET;
					sbiPaymentRequest.KONY_PLATFORM = KONY_PLATFORM;
					sbiPaymentRequest.KONY_SDK_TYPE = KONY_SDK_TYPE;
					sbiPaymentRequest.MPIN_MAIN = MPIN_MAIN;
					sbiPaymentRequest.APP_KEY_MAIN = APP_KEY_MAIN;
					return questionSubmitServiceResponseBody;
				}
			}
			string text8 = "Something wrong in questionSubmitServiceRequest request\n";
			throw new IOException(text8 + text2);
		}
		string text9 = "Something wrong in questionSubmitServiceRequest request\n";
		throw new IOException(text9 + text2);
	}

	public SecurityServiceResponseBody smartSecServiceRequest(SBIPaymentRequest sbiPaymentRequest)
	{
		string text = SERVER_HOST + SMART_SEC_SERVICE_PATH;
		Console.WriteLine(text);
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
		Header value4 = new Header
		{
			bankCode = "",
			token = "",
			userName = ""
		};
		Console.WriteLine(JsonConvert.SerializeObject(value4));
		string key4 = "header";
		dictionary.Add(key4, Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value4))));
		BaseRequestBody baseRequestBody = new BaseRequestBody();
		baseRequestBody.body = new Body();
		baseRequestBody.security = new Security();
		baseRequestBody.security.appkey = "";
		baseRequestBody.security.mpin = "";
		baseRequestBody.security.token1 = "";
		baseRequestBody.security.token2 = "";
		Console.WriteLine(JsonConvert.SerializeObject(baseRequestBody));
		string key5 = "encData";
		dictionary.Add(key5, SBISecureCrypt.EncryptEncData(JsonConvert.SerializeObject(baseRequestBody), "", MPIN_MAIN, APP_KEY_MAIN));
		string key6 = "requestKey";
		dictionary.Add(key6, SBISecureCrypt.calcRequestKey(JsonConvert.SerializeObject(baseRequestBody)));
		string key7 = "appID";
		dictionary.Add(key7, APP_ID);
		string key8 = "appver";
		dictionary.Add(key8, APP_VERSION);
		string key9 = "channel";
		dictionary.Add(key9, CHANNEL);
		string key10 = "platform";
		dictionary.Add(key10, KONY_PLATFORM);
		string key11 = "cacheid";
		dictionary.Add(key11, "");
		string key12 = "konyreportingparams";
		string form = "frmLoginWithMPin";
		string serviceId = "SmartSecService";
		dictionary.Add(key12, getKonyReportingParams(sbiPaymentRequest, form, serviceId));
		string formBody = getFormBody(dictionary);
		Console.WriteLine(formBody);
		byte[] bytes = Encoding.UTF8.GetBytes(formBody);
		HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
		httpWebRequest.CookieContainer = cookieContainer;
		string method = "POST";
		httpWebRequest.Method = method;
		httpWebRequest.KeepAlive = true;
		httpWebRequest.UserAgent = sbiPaymentRequest.userAgent;
		WebHeaderCollection headers = httpWebRequest.Headers;
		string name = "Accept-Encoding";
		string value5 = "gzip,deflate";
		headers.Add(name, value5);
		httpWebRequest.ContentLength = bytes.Length;
		string contentType = "application/json";
		httpWebRequest.ContentType = contentType;
		httpWebRequest.ServicePoint.Expect100Continue = true;
		WebHeaderCollection headers2 = httpWebRequest.Headers;
		string name2 = "Cache-Control";
		string value6 = "no-cache";
		headers2[name2] = value6;
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
		string text2 = new StreamReader(responseStream).ReadToEnd();
		string text3 = "Response for smartSecServiceRequest request\n{0}";
		Console.WriteLine(text3 + text2);
		responseStream.Close();
		if (httpWebResponse.StatusCode != HttpStatusCode.OK)
		{
			string text4 = "Something wrong in smartSecServiceRequest\n";
			throw new IOException(text4 + text2);
		}
		BaseResponseBody baseResponseBody = JsonConvert.DeserializeObject<BaseResponseBody>(text2);
		string code = baseResponseBody.code;
		string text5 = "null";
		if (code != text5 || baseResponseBody.encData == null || baseResponseBody.status == null || baseResponseBody.httpStatusCode != 200)
		{
			string text6 = "Something wrong in smartSecServiceRequest request\n";
			throw new IOException(text6 + text2);
		}
		string text7 = "smartSecServiceRequest encData";
		Console.WriteLine(text7 + SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, "", MPIN_MAIN, APP_KEY_MAIN));
		string text8 = "smartSecServiceRequest status";
		Console.WriteLine(text8 + SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, "", MPIN_MAIN, APP_KEY_MAIN));
		SecurityServiceResponseBody securityServiceResponseBody = JsonConvert.DeserializeObject<SecurityServiceResponseBody>(SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, "", MPIN_MAIN, APP_KEY_MAIN));
		Console.WriteLine(JsonConvert.SerializeObject(securityServiceResponseBody));
		return securityServiceResponseBody;
	}

	public LoginValidateResponseBody secureLoginServiceRequest(SBIPaymentRequest sbiPaymentRequest)
	{
		string text = SERVER_HOST + SECURITY_LOGIN_SERVICE_PATH;
		Console.WriteLine(text);
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
		Console.WriteLine(JsonConvert.SerializeObject(header));
		string key3 = "header";
		dictionary.Add(key3, Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(header))));
		BaseRequestBody baseRequestBody = new BaseRequestBody();
		baseRequestBody.body = new Body();
		baseRequestBody.body.secretKey = sbiPaymentRequest.securityKey;
		baseRequestBody.body.shaMpin = SBISecureCrypt.shaMpin(sbiPaymentRequest.Username, sbiPaymentRequest.mpinCode, sbiPaymentRequest.keyId);
		baseRequestBody.body.serviceId = sbiPaymentRequest.serviceId;
		baseRequestBody.body.deviceName = sbiPaymentRequest.phoneModel;
		baseRequestBody.body.imeiNo = sbiPaymentRequest.androidId;
		baseRequestBody.body.osName = KONY_PLATFORM;
		baseRequestBody.body.mobileAppVersion = APP_VERSION;
		baseRequestBody.body.oSversion = sbiPaymentRequest.osVersion;
		baseRequestBody.security = new Security();
		baseRequestBody.security.appkey = "";
		baseRequestBody.security.mpin = "";
		baseRequestBody.security.token1 = "";
		baseRequestBody.security.token2 = "";
		Console.WriteLine(JsonConvert.SerializeObject(baseRequestBody));
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
		dictionary.Add(key11, KONY_PLATFORM);
		string key12 = "cacheid";
		dictionary.Add(key12, "");
		string key13 = "konyreportingparams";
		string form = "frmLoginWithMPin";
		string serviceId = "SecureLoginService";
		dictionary.Add(key13, getKonyReportingParams(sbiPaymentRequest, form, serviceId));
		string formBody = getFormBody(dictionary);
		Console.WriteLine(formBody);
		byte[] bytes = Encoding.UTF8.GetBytes(formBody);
		HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
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
		string text2 = new StreamReader(responseStream).ReadToEnd();
		string text3 = "Response for secureLoginServiceRequest request\n{0}";
		Console.WriteLine(text3 + text2);
		responseStream.Close();
		if (httpWebResponse.StatusCode != HttpStatusCode.OK)
		{
			string text4 = "Something wrong in secureLoginServiceRequest\n";
			throw new IOException(text4 + text2);
		}
		BaseResponseBody baseResponseBody = JsonConvert.DeserializeObject<BaseResponseBody>(text2);
		string code = baseResponseBody.code;
		string text5 = "null";
		if (!(code != text5) && baseResponseBody.encData != null && baseResponseBody.status != null && baseResponseBody.httpStatusCode == 200)
		{
			LoginValidateResponseBody loginValidateResponseBody = JsonConvert.DeserializeObject<LoginValidateResponseBody>(SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, sbiPaymentRequest.Username, sbiPaymentRequest.androidId, sbiPaymentRequest.mobAppKey));
			Console.WriteLine(JsonConvert.SerializeObject(loginValidateResponseBody));
			if (loginValidateResponseBody.status)
			{
				sbiPaymentRequest.jSessionId = loginValidateResponseBody.jSessionId;
				sbiPaymentRequest.uId = loginValidateResponseBody.uId;
			}
			return loginValidateResponseBody;
		}
		string text6 = "Something wrong in secureLoginServiceRequest request\n";
		throw new IOException(text6 + text2);
	}

	public string fetchOnlineOTPRequest(SBIPaymentRequest sbiPaymentRequest)
	{
		string text = SERVER_HOST + FETCH_ONLINE_OTP_PATH;
		Console.WriteLine(text);
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
		Console.WriteLine(JsonConvert.SerializeObject(header));
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
		Console.WriteLine(JsonConvert.SerializeObject(baseRequestBody));
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
		dictionary.Add(key9, KONY_PLATFORM);
		string key10 = "cacheid";
		dictionary.Add(key10, "");
		string key11 = "konyreportingparams";
		string form = "frmLandingPageNew";
		string serviceId = "FetchOnlineOTP";
		dictionary.Add(key11, getKonyReportingParams(sbiPaymentRequest, form, serviceId));
		string formBody = getFormBody(dictionary);
		Console.WriteLine(formBody);
		byte[] bytes = Encoding.UTF8.GetBytes(formBody);
		HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
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
		string text2 = new StreamReader(responseStream).ReadToEnd();
		string text3 = "Response for fetchOnlineOTPRequest request\n{0}";
		Console.WriteLine(text3 + text2);
		responseStream.Close();
		if (httpWebResponse.StatusCode != HttpStatusCode.OK)
		{
			string text4 = "Something wrong in fetchOnlineOTPRequest\n";
			throw new IOException(text4 + text2);
		}
		BaseResponseBody baseResponseBody = JsonConvert.DeserializeObject<BaseResponseBody>(text2);
		string code = baseResponseBody.code;
		string text5 = "null";
		if (code != text5 || baseResponseBody.encData == null || baseResponseBody.status == null || baseResponseBody.httpStatusCode != 200)
		{
			string text6 = "Something wrong in fetchOnlineOTPRequest request\n";
			throw new IOException(text6 + text2);
		}
		Console.WriteLine(SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, sbiPaymentRequest.Username, sbiPaymentRequest.androidId, sbiPaymentRequest.mobAppKey));
		return text2;
	}

	public string getSmsText(SBIPaymentRequest sbiPaymentRequest)
	{
		string format = "{0}#{1}#{2}";
		string arg = "1";
		string androidId = sbiPaymentRequest.androidId;
		string arg2 = "1";
		string text = string.Format(format, arg, androidId, arg2);
		string text2 = "Plain SMS ";
		Console.WriteLine(text2 + text);
		text = SBISecureCrypt.SHA512(text);
		Console.WriteLine(text);
		string format2 = "{0}#{1}#{2}";
		string arg3 = text;
		string sECRET_KEY = SECRET_KEY;
		DateTime indiaDateTime = getIndiaDateTime();
		string text3 = "ddd MMM dd yyyy HHmmss \"GMT\"zzz";
		string name = "en-US";
		string text4 = indiaDateTime.ToString(text3, CultureInfo.CreateSpecificCulture(name));
		string oldValue = ",";
		string text5 = text4.Replace(oldValue, "");
		string oldValue2 = ":";
		string text6 = text5.Replace(oldValue2, "");
		string oldValue3 = "+";
		text = string.Format(format2, arg3, sECRET_KEY, text6.Replace(oldValue3, ""));
		Console.WriteLine(text);
		return SBISecureCrypt.SHA512(text);
	}

	public string encryptSmsText(string smsText)
	{
		SBISecureCrypt.SHA512(smsText);
		return smsText;
	}

	private DateTime getIndiaDateTime()
	{
		DateTime dateTime = DateTime.Now.ToUniversalTime();
		string id = "India Standard Time";
		TimeZoneInfo destinationTimeZone = TimeZoneInfo.FindSystemTimeZoneById(id);
		return TimeZoneInfo.ConvertTimeFromUtc(dateTime, destinationTimeZone);
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
		reportParams.plat = KONY_PLATFORM;
		reportParams.aver = APP_VERSION;
		string atype = "native";
		reportParams.atype = atype;
		string stype = "b2c";
		reportParams.stype = stype;
		reportParams.kuid = "";
		reportParams.mfaid = CONFIG_APP_ID;
		reportParams.mfbaseid = CONFIG_BASE_ID;
		reportParams.mfaname = CONFIG_APP_NAME;
		reportParams.sdkversion = KONY_SDK_VERSION;
		reportParams.sdktype = KONY_SDK_TYPE;
		reportParams.fid = form;
		reportParams.rsid = KONY_RSID;
		reportParams.svcid = serviceId;
		string text = JsonConvert.SerializeObject(reportParams);
		Console.WriteLine(text);
		return text;
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

	static SbiSecureServiceV2()
	{
		string sALT = "c8f4a4536cabfe8233d8d234d005d93e6a91702853cb2d93cb3c846e7ac6c322";
		SALT = sALT;
		string sECRET_KEY = "daf225199b408bdd641d8a8d4e8136c3900c37e1705853b9517a6393aab9b7eaccf1bc8763dabbcf08dd8af07c362774a9ccfe8494f7dcda8c6981d6950428f0";
		SECRET_KEY = sECRET_KEY;
		string mPIN_MAIN = "$652@!#*SaWeQ@";
		MPIN_MAIN = mPIN_MAIN;
		string aPP_KEY_MAIN = "$*|@%$B!$E@u^#@A%!";
		APP_KEY_MAIN = aPP_KEY_MAIN;
		string sERVER_HOST = "https://api.yonobusinessmobile.sbi";
		SERVER_HOST = sERVER_HOST;
		SERVER_PORT = 443;
		string kONY_APP_KEY = "a4fbd0c9fc874ff7cfb70a04681e8340";
		KONY_APP_KEY = kONY_APP_KEY;
		string kONY_APP_SECRET = "a1c3fd7b48a0baa353b10f43cb3df3cc";
		KONY_APP_SECRET = kONY_APP_SECRET;
		string kONY_SDK_VERSION = "8.4.147";
		KONY_SDK_VERSION = kONY_SDK_VERSION;
		string kONY_PLATFORM = "android";
		KONY_PLATFORM = kONY_PLATFORM;
		string kONY_SDK_TYPE = "js";
		KONY_SDK_TYPE = kONY_SDK_TYPE;
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
		string cONFIG_APP_ID = "93483612-56bd-4eea-a1d4-b512b4cc1fb2";
		CONFIG_APP_ID = cONFIG_APP_ID;
		string cONFIG_BASE_ID = "b8e9763f-9194-4962-92c9-34df58dc3e3c";
		CONFIG_BASE_ID = cONFIG_BASE_ID;
		string cONFIG_APP_NAME = "SBISmartOTPChe";
		CONFIG_APP_NAME = cONFIG_APP_NAME;
		string kONY_RSID = "1666015648453-f86b-8242-a917";
		KONY_RSID = kONY_RSID;
		string pHONE_AUTHORIZATION = "+917304459011";
		PHONE_AUTHORIZATION = pHONE_AUTHORIZATION;
		string aUTH_SERVICE_PATH = "/authService/100000002/login";
		AUTH_SERVICE_PATH = aUTH_SERVICE_PATH;
		string fETCH_DATE_TIME_PATH = "/services1/SBISmartOTPCheService1/FetchDateTime";
		FETCH_DATE_TIME_PATH = fETCH_DATE_TIME_PATH;
		string sECURITY_SERVICE_PATH = "/services1/SBISmartOTPCheService1/SecurityService";
		SECURITY_SERVICE_PATH = sECURITY_SERVICE_PATH;
		string lOGIN_VALIDATE_PATH = "/services1/SBISmartOTPCheService1/LoginValidate";
		LOGIN_VALIDATE_PATH = lOGIN_VALIDATE_PATH;
		string eNABLE_HIGH_SECURITY_SERVICE_PATH = "/services1/SBISmartOTPCheService1/EnableHighSecurityService";
		ENABLE_HIGH_SECURITY_SERVICE_PATH = eNABLE_HIGH_SECURITY_SERVICE_PATH;
		string eNABLE_HIGH_SECURITY_CONFIRM_SERVICE_PATH = "/services1/SBISmartOTPCheService1/EnableHighSecurityConfirmService";
		ENABLE_HIGH_SECURITY_CONFIRM_SERVICE_PATH = eNABLE_HIGH_SECURITY_CONFIRM_SERVICE_PATH;
		string qUESTION_SUBMIT_SERVICE_PATH = "/services1/SBISmartOTPCheService1/QuestionSubmitService";
		QUESTION_SUBMIT_SERVICE_PATH = qUESTION_SUBMIT_SERVICE_PATH;
		string sMART_SEC_SERVICE_PATH = "/services1/SBISmartOTPCheService1/SmartSecService";
		SMART_SEC_SERVICE_PATH = sMART_SEC_SERVICE_PATH;
		string sECURITY_LOGIN_SERVICE_PATH = "/services1/SBISmartOTPCheService1/SecureLoginService";
		SECURITY_LOGIN_SERVICE_PATH = sECURITY_LOGIN_SERVICE_PATH;
		string fETCH_ONLINE_OTP_PATH = "/services1/SBISmartOTPCheService1/FetchOnlineOTP";
		FETCH_ONLINE_OTP_PATH = fETCH_ONLINE_OTP_PATH;
	}
}
