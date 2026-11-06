using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web;
using Newtonsoft.Json;

namespace IRCommDLL;

internal class clsSbiOTP2
{
	private class SbiUser
	{
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

		public string androidId;

		public string phoneModel;

		public string userAgent;

		public string userId = "";

		public string osVersion;

		public string smsEncryptedText;

		public string username;

		public string password;

		public string mpinCode;

		public AuthServiceResponse authServiceResponse;

		public FetchDateTimeResponseBody dateTimeResponseBody;

		public SecurityServiceResponseBody securityServiceResponseBody;

		public LoginValidateResponseBody loginValidateResponseBody;

		public EnableHighSecurityServiceResponseBody enableHighSecurityServiceResponseBody;

		public EnableHighSecurityConfirmServiceResponseBody enableHighSecurityConfirmServiceResponseBody;

		public LoginValidateResponseBody loginValidateResponseBodyForSecureLogin;

		private CookieContainer cookieContainer = new CookieContainer();

		public bool isFiddlerProxyUseMust;

		public string ProxyHost;

		public int ProxyPort;

		public string ProxyUsername;

		public string ProxyPassword;

		public void authServiceRequest()
		{
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
			string text = SERVER_HOST + AUTH_SERVICE_PATH;
			Console.WriteLine(text);
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
			httpWebRequest.CookieContainer = cookieContainer;
			if (!isFiddlerProxyUseMust)
			{
				if (!string.IsNullOrEmpty(ProxyHost))
				{
					string format = "{0}:{1}";
					httpWebRequest.Proxy = new WebProxy(string.Format(format, ProxyHost, ProxyPort), BypassOnLocal: true, null, new NetworkCredential(ProxyUsername, ProxyPassword));
				}
			}
			else
			{
				string host = "127.0.0.1";
				httpWebRequest.Proxy = new WebProxy(host, 8888);
			}
			string method = "POST";
			httpWebRequest.Method = method;
			httpWebRequest.KeepAlive = true;
			httpWebRequest.UserAgent = userAgent;
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
			httpWebRequest.ServicePoint.Expect100Continue = false;
			WebHeaderCollection headers2 = httpWebRequest.Headers;
			string name2 = "Cache-Control";
			string value2 = "no-cache";
			headers2[name2] = value2;
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
			string format2 = "Response for authServiceRequest request\n{0}";
			Console.WriteLine(format2, text2);
			responseStream.Close();
			if (httpWebResponse.StatusCode == HttpStatusCode.OK)
			{
				AuthServiceResponse authServiceResponse = JsonConvert.DeserializeObject<AuthServiceResponse>(text2);
				if (authServiceResponse.claims_token == null || authServiceResponse.claims_token.value == null || authServiceResponse.refresh_token == null)
				{
					string text3 = "Something wrong in authServiceRequest request\n";
					throw new IOException(text3 + text2);
				}
				this.authServiceResponse = authServiceResponse;
				return;
			}
			string text4 = "Something wrong in vpaListRequest\n";
			throw new IOException(text4 + text2);
		}

		public void fetchDateTimeRequest()
		{
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
			string text = SERVER_HOST + FETCH_DATE_TIME_PATH;
			Console.WriteLine(text);
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			string key = "events";
			string value = "[]";
			dictionary.Add(key, value);
			string key2 = "serviceID";
			string value2 = "FetchDateTime";
			dictionary.Add(key2, value2);
			Header value3 = new Header
			{
				bankCode = "",
				token = "",
				userName = ""
			};
			Console.WriteLine(JsonConvert.SerializeObject(value3));
			string key3 = "header";
			dictionary.Add(key3, Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value3))));
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
			dictionary.Add(key11, getKonyReportingParams(form, serviceId));
			string formBody = getFormBody(dictionary);
			Console.WriteLine(formBody);
			byte[] bytes = Encoding.UTF8.GetBytes(formBody);
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
			httpWebRequest.CookieContainer = cookieContainer;
			if (!isFiddlerProxyUseMust)
			{
				if (!string.IsNullOrEmpty(ProxyHost))
				{
					string format = "{0}:{1}";
					httpWebRequest.Proxy = new WebProxy(string.Format(format, ProxyHost, ProxyPort), BypassOnLocal: true, null, new NetworkCredential(ProxyUsername, ProxyPassword));
				}
			}
			else
			{
				string host = "127.0.0.1";
				httpWebRequest.Proxy = new WebProxy(host, 8888);
			}
			string method = "POST";
			httpWebRequest.Method = method;
			httpWebRequest.KeepAlive = true;
			httpWebRequest.UserAgent = userAgent;
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
			headers3[name3] = authServiceResponse.claims_token.value;
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
			string format2 = "Response for fetchDateTimeRequest request\n{0}";
			Console.WriteLine(format2, text2);
			responseStream.Close();
			if (httpWebResponse.StatusCode != HttpStatusCode.OK)
			{
				string text3 = "Something wrong in fetchDateTimeRequest\n";
				throw new IOException(text3 + text2);
			}
			BaseResponseBody baseResponseBody = JsonConvert.DeserializeObject<BaseResponseBody>(text2);
			string code = baseResponseBody.code;
			string text4 = "null";
			if (code != text4 || baseResponseBody.encData == null || baseResponseBody.status == null || baseResponseBody.httpStatusCode != 200)
			{
				string text5 = "Something wrong in fetchDateTimeRequest request\n";
				throw new IOException(text5 + text2);
			}
			dateTimeResponseBody = JsonConvert.DeserializeObject<FetchDateTimeResponseBody>(SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, "", MPIN_MAIN, APP_KEY_MAIN));
			Console.WriteLine(JsonConvert.SerializeObject(dateTimeResponseBody));
		}

		public string securityServiceRequest()
		{
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
			string text = SERVER_HOST + SECURITY_SERVICE_PATH;
			Console.WriteLine(text);
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			string key = "events";
			string value = "[]";
			dictionary.Add(key, value);
			string key2 = "serviceID";
			string value2 = "SecurityService";
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
			string form = "frmRegister";
			string serviceId = "SecurityService";
			dictionary.Add(key12, getKonyReportingParams(form, serviceId));
			string formBody = getFormBody(dictionary);
			Console.WriteLine(formBody);
			byte[] bytes = Encoding.UTF8.GetBytes(formBody);
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
			httpWebRequest.CookieContainer = cookieContainer;
			if (isFiddlerProxyUseMust)
			{
				string host = "127.0.0.1";
				httpWebRequest.Proxy = new WebProxy(host, 8888);
			}
			else if (!string.IsNullOrEmpty(ProxyHost))
			{
				string format = "{0}:{1}";
				httpWebRequest.Proxy = new WebProxy(string.Format(format, ProxyHost, ProxyPort), BypassOnLocal: true, null, new NetworkCredential(ProxyUsername, ProxyPassword));
			}
			string method = "POST";
			httpWebRequest.Method = method;
			httpWebRequest.KeepAlive = true;
			httpWebRequest.UserAgent = userAgent;
			WebHeaderCollection headers = httpWebRequest.Headers;
			string name = "Accept-Encoding";
			string value5 = "gzip,deflate";
			headers.Add(name, value5);
			httpWebRequest.ContentLength = bytes.Length;
			string contentType = "application/json";
			httpWebRequest.ContentType = contentType;
			httpWebRequest.ServicePoint.Expect100Continue = true;
			httpWebRequest.ServicePoint.Expect100Continue = false;
			WebHeaderCollection headers2 = httpWebRequest.Headers;
			string name2 = "Cache-Control";
			string value6 = "no-cache";
			headers2[name2] = value6;
			WebHeaderCollection headers3 = httpWebRequest.Headers;
			string name3 = "X-Kony-Authorizationn";
			headers3[name3] = authServiceResponse.claims_token.value;
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
			string format2 = "Response for securityServiceRequest request\n{0}";
			Console.WriteLine(format2, text2);
			responseStream.Close();
			if (httpWebResponse.StatusCode != HttpStatusCode.OK)
			{
				string text3 = "Something wrong in securityServiceRequest\n";
				throw new IOException(text3 + text2);
			}
			BaseResponseBody baseResponseBody = JsonConvert.DeserializeObject<BaseResponseBody>(text2);
			string code = baseResponseBody.code;
			string text4 = "null";
			if (code != text4 || baseResponseBody.encData == null || baseResponseBody.status == null || baseResponseBody.httpStatusCode != 200)
			{
				string text5 = "Something wrong in securityServiceRequest request\n";
				throw new IOException(text5 + text2);
			}
			securityServiceResponseBody = JsonConvert.DeserializeObject<SecurityServiceResponseBody>(SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, "", MPIN_MAIN, APP_KEY_MAIN));
			Console.WriteLine(JsonConvert.SerializeObject(securityServiceResponseBody));
			return SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, "", MPIN_MAIN, APP_KEY_MAIN);
		}

		public string loginValidateRequest()
		{
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
			string text = SERVER_HOST + LOGIN_VALIDATE_PATH;
			Console.WriteLine(text);
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			string key = "events";
			string value = "[]";
			dictionary.Add(key, value);
			string key2 = "serviceID";
			string value2 = "LoginValidate";
			dictionary.Add(key2, value2);
			Header header = new Header();
			string bankCode = "0";
			header.bankCode = bankCode;
			header.token = "";
			header.userName = username;
			Console.WriteLine(JsonConvert.SerializeObject(header));
			string key3 = "header";
			dictionary.Add(key3, Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(header))));
			BaseRequestBody baseRequestBody = new BaseRequestBody();
			baseRequestBody.body = new Body();
			baseRequestBody.body.md5Password = SBISecureCrypt.md5Password(username, password, securityServiceResponseBody.keyId);
			baseRequestBody.body.shaPassword = SBISecureCrypt.shaPassword(username, password, securityServiceResponseBody.keyId);
			baseRequestBody.body.serviceId = securityServiceResponseBody.serviceId;
			baseRequestBody.body.deviceName = phoneModel;
			baseRequestBody.body.imeiNo = androidId;
			baseRequestBody.body.osName = KONY_PLATFORM;
			baseRequestBody.body.mobileAppVersion = APP_VERSION;
			baseRequestBody.body.oSversion = osVersion;
			baseRequestBody.body.encKeyValue = smsEncryptedText;
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
			dictionary.Add(key4, SBISecureCrypt.EncryptEncData(JsonConvert.SerializeObject(baseRequestBody), username, MPIN_MAIN, APP_KEY_MAIN));
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
			dictionary.Add(key13, getKonyReportingParams(form, serviceId));
			string formBody = getFormBody(dictionary);
			Console.WriteLine(formBody);
			byte[] bytes = Encoding.UTF8.GetBytes(formBody);
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
			httpWebRequest.CookieContainer = cookieContainer;
			if (!isFiddlerProxyUseMust)
			{
				if (!string.IsNullOrEmpty(ProxyHost))
				{
					string format = "{0}:{1}";
					httpWebRequest.Proxy = new WebProxy(string.Format(format, ProxyHost, ProxyPort), BypassOnLocal: true, null, new NetworkCredential(ProxyUsername, ProxyPassword));
				}
			}
			else
			{
				string host = "127.0.0.1";
				httpWebRequest.Proxy = new WebProxy(host, 8888);
			}
			string method = "POST";
			httpWebRequest.Method = method;
			httpWebRequest.KeepAlive = true;
			httpWebRequest.UserAgent = userAgent;
			WebHeaderCollection headers = httpWebRequest.Headers;
			string name2 = "Accept-Encoding";
			string value3 = "gzip,deflate";
			headers.Add(name2, value3);
			httpWebRequest.ContentLength = bytes.Length;
			string contentType = "application/json";
			httpWebRequest.ContentType = contentType;
			httpWebRequest.ServicePoint.Expect100Continue = true;
			WebHeaderCollection headers2 = httpWebRequest.Headers;
			string name3 = "Cache-Control";
			string value4 = "no-cache";
			headers2[name3] = value4;
			WebHeaderCollection headers3 = httpWebRequest.Headers;
			string name4 = "X-Kony-Authorizationn";
			headers3[name4] = authServiceResponse.claims_token.value;
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
			string text3 = new StreamReader(responseStream).ReadToEnd();
			string format2 = "Response for loginValidateRequest request\n{0}";
			Console.WriteLine(format2, text3);
			responseStream.Close();
			if (httpWebResponse.StatusCode != HttpStatusCode.OK)
			{
				string text4 = "Something wrong in loginValidateRequest\n";
				throw new IOException(text4 + text3);
			}
			BaseResponseBody baseResponseBody = JsonConvert.DeserializeObject<BaseResponseBody>(text3);
			string code = baseResponseBody.code;
			string text5 = "null";
			if (code != text5 || baseResponseBody.encData == null || baseResponseBody.status == null || baseResponseBody.httpStatusCode != 200)
			{
				string text6 = "Something wrong in loginValidateRequest request\n";
				throw new IOException(text6 + text3);
			}
			string result = SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, username, MPIN_MAIN, APP_KEY_MAIN);
			loginValidateResponseBody = JsonConvert.DeserializeObject<LoginValidateResponseBody>(SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, username, MPIN_MAIN, APP_KEY_MAIN));
			Console.WriteLine(JsonConvert.SerializeObject(loginValidateResponseBody));
			return result;
		}

		public string enableHighSecurityServiceRequest()
		{
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
			string text = SERVER_HOST + ENABLE_HIGH_SECURITY_SERVICE_PATH;
			Console.WriteLine(text);
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			string key = "events";
			string value = "[]";
			dictionary.Add(key, value);
			string key2 = "serviceID";
			string value2 = "EnableHighSecurityService";
			dictionary.Add(key2, value2);
			Header header = new Header();
			string bankCode = "0";
			header.bankCode = bankCode;
			header.token = "";
			header.userName = username;
			Console.WriteLine(JsonConvert.SerializeObject(header));
			string key3 = "header";
			dictionary.Add(key3, Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(header))));
			BaseRequestBody baseRequestBody = new BaseRequestBody();
			baseRequestBody.body = new Body();
			baseRequestBody.security = new Security();
			baseRequestBody.security.appkey = APP_KEY_MAIN;
			baseRequestBody.security.mpin = MPIN_MAIN;
			baseRequestBody.security.token1 = loginValidateResponseBody.jSessionId;
			baseRequestBody.security.token2 = loginValidateResponseBody.uId;
			Console.WriteLine(JsonConvert.SerializeObject(baseRequestBody));
			string key4 = "encData";
			dictionary.Add(key4, SBISecureCrypt.EncryptEncData(JsonConvert.SerializeObject(baseRequestBody), username, MPIN_MAIN, APP_KEY_MAIN));
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
			dictionary.Add(key11, getKonyReportingParams(form, serviceId));
			string formBody = getFormBody(dictionary);
			Console.WriteLine(formBody);
			byte[] bytes = Encoding.UTF8.GetBytes(formBody);
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
			httpWebRequest.CookieContainer = cookieContainer;
			if (isFiddlerProxyUseMust)
			{
				string host = "127.0.0.1";
				httpWebRequest.Proxy = new WebProxy(host, 8888);
			}
			else if (!string.IsNullOrEmpty(ProxyHost))
			{
				string format = "{0}:{1}";
				httpWebRequest.Proxy = new WebProxy(string.Format(format, ProxyHost, ProxyPort), BypassOnLocal: true, null, new NetworkCredential(ProxyUsername, ProxyPassword));
			}
			string method = "POST";
			httpWebRequest.Method = method;
			httpWebRequest.KeepAlive = true;
			httpWebRequest.UserAgent = userAgent;
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
			headers3[name3] = authServiceResponse.claims_token.value;
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
			string format2 = "Response for enableHighSecurityServiceRequest request\n{0}";
			Console.WriteLine(format2, text2);
			responseStream.Close();
			if (httpWebResponse.StatusCode != HttpStatusCode.OK)
			{
				string text3 = "Something wrong in enableHighSecurityServiceRequest\n";
				throw new IOException(text3 + text2);
			}
			BaseResponseBody baseResponseBody = JsonConvert.DeserializeObject<BaseResponseBody>(text2);
			string code = baseResponseBody.code;
			string text4 = "null";
			if (code != text4 || baseResponseBody.encData == null || baseResponseBody.status == null || baseResponseBody.httpStatusCode != 200)
			{
				string text5 = "Something wrong in enableHighSecurityServiceRequest request\n";
				throw new IOException(text5 + text2);
			}
			enableHighSecurityServiceResponseBody = JsonConvert.DeserializeObject<EnableHighSecurityServiceResponseBody>(SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, username, MPIN_MAIN, APP_KEY_MAIN));
			Console.WriteLine(JsonConvert.SerializeObject(enableHighSecurityServiceResponseBody));
			return SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, username, MPIN_MAIN, APP_KEY_MAIN);
		}

		public void enableHighSecurityConfirmServiceRequest(string otpCode)
		{
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
			string text = SERVER_HOST + ENABLE_HIGH_SECURITY_CONFIRM_SERVICE_PATH;
			Console.WriteLine(text);
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			string key = "events";
			string value = "[]";
			dictionary.Add(key, value);
			string key2 = "serviceID";
			string value2 = "EnableHighSecurityConfirmService";
			dictionary.Add(key2, value2);
			Header header = new Header();
			string bankCode = "0";
			header.bankCode = bankCode;
			header.token = "";
			header.userName = username;
			Console.WriteLine(JsonConvert.SerializeObject(header));
			string key3 = "header";
			dictionary.Add(key3, Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(header))));
			BaseRequestBody baseRequestBody = new BaseRequestBody();
			baseRequestBody.body = new Body();
			baseRequestBody.body.deviceId = androidId;
			baseRequestBody.body.otp = otpCode;
			baseRequestBody.security = new Security();
			baseRequestBody.security.appkey = APP_KEY_MAIN;
			baseRequestBody.security.mpin = MPIN_MAIN;
			baseRequestBody.security.token1 = loginValidateResponseBody.jSessionId;
			baseRequestBody.security.token2 = loginValidateResponseBody.uId;
			Console.WriteLine(JsonConvert.SerializeObject(baseRequestBody));
			string key4 = "encData";
			dictionary.Add(key4, SBISecureCrypt.EncryptEncData(JsonConvert.SerializeObject(baseRequestBody), username, MPIN_MAIN, APP_KEY_MAIN));
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
			dictionary.Add(key11, getKonyReportingParams(form, serviceId));
			string formBody = getFormBody(dictionary);
			Console.WriteLine(formBody);
			byte[] bytes = Encoding.UTF8.GetBytes(formBody);
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
			httpWebRequest.CookieContainer = cookieContainer;
			if (!isFiddlerProxyUseMust)
			{
				if (!string.IsNullOrEmpty(ProxyHost))
				{
					string format = "{0}:{1}";
					httpWebRequest.Proxy = new WebProxy(string.Format(format, ProxyHost, ProxyPort), BypassOnLocal: true, null, new NetworkCredential(ProxyUsername, ProxyPassword));
				}
			}
			else
			{
				string host = "127.0.0.1";
				httpWebRequest.Proxy = new WebProxy(host, 8888);
			}
			string method = "POST";
			httpWebRequest.Method = method;
			httpWebRequest.KeepAlive = true;
			httpWebRequest.UserAgent = userAgent;
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
			headers3[name3] = authServiceResponse.claims_token.value;
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
			string format2 = "Response for enableHighSecurityConfirmServiceRequest request\n{0}";
			Console.WriteLine(format2, text2);
			responseStream.Close();
			if (httpWebResponse.StatusCode != HttpStatusCode.OK)
			{
				string text3 = "Something wrong in enableHighSecurityConfirmServiceRequest\n";
				throw new IOException(text3 + text2);
			}
			BaseResponseBody baseResponseBody = JsonConvert.DeserializeObject<BaseResponseBody>(text2);
			string code = baseResponseBody.code;
			string text4 = "null";
			if (code != text4 || baseResponseBody.encData == null || baseResponseBody.status == null || baseResponseBody.httpStatusCode != 200)
			{
				string text5 = "Something wrong in enableHighSecurityConfirmServiceRequest request\n";
				throw new IOException(text5 + text2);
			}
			enableHighSecurityConfirmServiceResponseBody = JsonConvert.DeserializeObject<EnableHighSecurityConfirmServiceResponseBody>(SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, username, MPIN_MAIN, APP_KEY_MAIN));
			Console.WriteLine(JsonConvert.SerializeObject(enableHighSecurityConfirmServiceResponseBody));
		}

		public string questionSubmitServiceRequest(string mpinCode)
		{
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
			this.mpinCode = mpinCode;
			string text = SERVER_HOST + QUESTION_SUBMIT_SERVICE_PATH;
			Console.WriteLine(text);
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			string key = "events";
			string value = "[]";
			dictionary.Add(key, value);
			string key2 = "serviceID";
			string value2 = "QuestionSubmitService";
			dictionary.Add(key2, value2);
			Header header = new Header();
			string bankCode = "0";
			header.bankCode = bankCode;
			header.token = "";
			header.userName = username;
			Console.WriteLine(JsonConvert.SerializeObject(header));
			string key3 = "header";
			dictionary.Add(key3, Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(header))));
			BaseRequestBody baseRequestBody = new BaseRequestBody();
			baseRequestBody.body = new Body();
			baseRequestBody.body.deviceId = androidId;
			Body body = baseRequestBody.body;
			string answer = "andanswers";
			body.answer = answer;
			Body body2 = baseRequestBody.body;
			string question = "stop sending questions";
			body2.question = question;
			baseRequestBody.body.shaMpin = SBISecureCrypt.shaMpinSet(username, mpinCode);
			baseRequestBody.body.securityKey = enableHighSecurityConfirmServiceResponseBody.securityKey;
			baseRequestBody.security = new Security();
			baseRequestBody.security.appkey = enableHighSecurityConfirmServiceResponseBody.securityKey;
			baseRequestBody.security.mpin = androidId;
			baseRequestBody.security.token1 = loginValidateResponseBody.jSessionId;
			baseRequestBody.security.token2 = loginValidateResponseBody.uId;
			Console.WriteLine(JsonConvert.SerializeObject(baseRequestBody));
			string key4 = "encData";
			dictionary.Add(key4, SBISecureCrypt.EncryptEncData(JsonConvert.SerializeObject(baseRequestBody), username, androidId, enableHighSecurityConfirmServiceResponseBody.mobAppKey));
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
			dictionary.Add(key11, getKonyReportingParams(form, serviceId));
			string formBody = getFormBody(dictionary);
			Console.WriteLine(formBody);
			byte[] bytes = Encoding.UTF8.GetBytes(formBody);
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
			httpWebRequest.CookieContainer = cookieContainer;
			if (isFiddlerProxyUseMust)
			{
				string host = "127.0.0.1";
				httpWebRequest.Proxy = new WebProxy(host, 8888);
			}
			else if (!string.IsNullOrEmpty(ProxyHost))
			{
				string format = "{0}:{1}";
				httpWebRequest.Proxy = new WebProxy(string.Format(format, ProxyHost, ProxyPort), BypassOnLocal: true, null, new NetworkCredential(ProxyUsername, ProxyPassword));
			}
			string method = "POST";
			httpWebRequest.Method = method;
			httpWebRequest.KeepAlive = true;
			httpWebRequest.UserAgent = userAgent;
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
			headers3[name3] = authServiceResponse.claims_token.value;
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
			string format2 = "Response for questionSubmitServiceRequest request\n{0}";
			Console.WriteLine(format2, text2);
			responseStream.Close();
			if (httpWebResponse.StatusCode != HttpStatusCode.OK)
			{
				string text3 = "Something wrong in questionSubmitServiceRequest\n";
				throw new IOException(text3 + text2);
			}
			BaseResponseBody baseResponseBody = JsonConvert.DeserializeObject<BaseResponseBody>(text2);
			string code = baseResponseBody.code;
			string text4 = "null";
			if (!(code != text4) && baseResponseBody.encData != null && baseResponseBody.status != null && baseResponseBody.httpStatusCode == 200)
			{
				string text5 = SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, username, androidId, enableHighSecurityConfirmServiceResponseBody.mobAppKey);
				QuestionSubmitServiceResponseBody questionSubmitServiceResponseBody = JsonConvert.DeserializeObject<QuestionSubmitServiceResponseBody>(text5);
				if (questionSubmitServiceResponseBody != null)
				{
					string status = questionSubmitServiceResponseBody.status;
					string value5 = "success";
					if (status.Equals(value5))
					{
						return text5;
					}
				}
				string text6 = "Something wrong in questionSubmitServiceRequest request\n";
				throw new IOException(text6 + text2);
			}
			string text7 = "Something wrong in questionSubmitServiceRequest request\n";
			throw new IOException(text7 + text2);
		}

		public void smartSecServiceRequest()
		{
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
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
			dictionary.Add(key12, getKonyReportingParams(form, serviceId));
			string formBody = getFormBody(dictionary);
			Console.WriteLine(formBody);
			byte[] bytes = Encoding.UTF8.GetBytes(formBody);
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
			httpWebRequest.CookieContainer = cookieContainer;
			if (isFiddlerProxyUseMust)
			{
				string host = "127.0.0.1";
				httpWebRequest.Proxy = new WebProxy(host, 8888);
			}
			else if (!string.IsNullOrEmpty(ProxyHost))
			{
				string format = "{0}:{1}";
				httpWebRequest.Proxy = new WebProxy(string.Format(format, ProxyHost, ProxyPort), BypassOnLocal: true, null, new NetworkCredential(ProxyUsername, ProxyPassword));
			}
			string method = "POST";
			httpWebRequest.Method = method;
			httpWebRequest.KeepAlive = true;
			httpWebRequest.UserAgent = userAgent;
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
			headers3[name3] = authServiceResponse.claims_token.value;
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
			string format2 = "Response for smartSecServiceRequest request\n{0}";
			Console.WriteLine(format2, text2);
			responseStream.Close();
			if (httpWebResponse.StatusCode != HttpStatusCode.OK)
			{
				string text3 = "Something wrong in smartSecServiceRequest\n";
				throw new IOException(text3 + text2);
			}
			BaseResponseBody baseResponseBody = JsonConvert.DeserializeObject<BaseResponseBody>(text2);
			string code = baseResponseBody.code;
			string text4 = "null";
			if (code != text4 || baseResponseBody.encData == null || baseResponseBody.status == null || baseResponseBody.httpStatusCode != 200)
			{
				string text5 = "Something wrong in smartSecServiceRequest request\n";
				throw new IOException(text5 + text2);
			}
			securityServiceResponseBody = JsonConvert.DeserializeObject<SecurityServiceResponseBody>(SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, "", MPIN_MAIN, APP_KEY_MAIN));
			Console.WriteLine(JsonConvert.SerializeObject(securityServiceResponseBody));
		}

		public void secureLoginServiceRequest()
		{
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
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
			header.userName = username;
			Console.WriteLine(JsonConvert.SerializeObject(header));
			string key3 = "header";
			dictionary.Add(key3, Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(header))));
			BaseRequestBody baseRequestBody = new BaseRequestBody();
			baseRequestBody.body = new Body();
			baseRequestBody.body.secretKey = enableHighSecurityConfirmServiceResponseBody.securityKey;
			baseRequestBody.body.shaMpin = SBISecureCrypt.shaMpin(username, mpinCode, securityServiceResponseBody.keyId);
			baseRequestBody.body.serviceId = securityServiceResponseBody.serviceId;
			baseRequestBody.body.deviceName = phoneModel;
			baseRequestBody.body.imeiNo = androidId;
			baseRequestBody.body.osName = KONY_PLATFORM;
			baseRequestBody.body.mobileAppVersion = APP_VERSION;
			baseRequestBody.body.oSversion = osVersion;
			baseRequestBody.security = new Security();
			baseRequestBody.security.appkey = "";
			baseRequestBody.security.mpin = "";
			baseRequestBody.security.token1 = "";
			baseRequestBody.security.token2 = "";
			Console.WriteLine(JsonConvert.SerializeObject(baseRequestBody));
			string key4 = "encData";
			dictionary.Add(key4, SBISecureCrypt.EncryptEncData(JsonConvert.SerializeObject(baseRequestBody), username, androidId, enableHighSecurityConfirmServiceResponseBody.mobAppKey));
			string key5 = "requestKey";
			dictionary.Add(key5, SBISecureCrypt.calcRequestKey(JsonConvert.SerializeObject(baseRequestBody)));
			string key6 = "jSessionId";
			dictionary.Add(key6, loginValidateResponseBody.jSessionId);
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
			dictionary.Add(key13, getKonyReportingParams(form, serviceId));
			string formBody = getFormBody(dictionary);
			Console.WriteLine(formBody);
			byte[] bytes = Encoding.UTF8.GetBytes(formBody);
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
			httpWebRequest.CookieContainer = cookieContainer;
			if (!isFiddlerProxyUseMust)
			{
				if (!string.IsNullOrEmpty(ProxyHost))
				{
					string format = "{0}:{1}";
					httpWebRequest.Proxy = new WebProxy(string.Format(format, ProxyHost, ProxyPort), BypassOnLocal: true, null, new NetworkCredential(ProxyUsername, ProxyPassword));
				}
			}
			else
			{
				string host = "127.0.0.1";
				httpWebRequest.Proxy = new WebProxy(host, 8888);
			}
			string method = "POST";
			httpWebRequest.Method = method;
			httpWebRequest.KeepAlive = true;
			httpWebRequest.UserAgent = userAgent;
			WebHeaderCollection headers = httpWebRequest.Headers;
			string name = "Accept-Encoding";
			string value3 = "gzip,deflate";
			headers.Add(name, value3);
			httpWebRequest.ContentLength = bytes.Length;
			string contentType = "application/json";
			httpWebRequest.ContentType = contentType;
			httpWebRequest.ServicePoint.Expect100Continue = true;
			httpWebRequest.ServicePoint.Expect100Continue = false;
			WebHeaderCollection headers2 = httpWebRequest.Headers;
			string name2 = "Cache-Control";
			string value4 = "no-cache";
			headers2[name2] = value4;
			WebHeaderCollection headers3 = httpWebRequest.Headers;
			string name3 = "X-Kony-Authorizationn";
			headers3[name3] = authServiceResponse.claims_token.value;
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
			string format2 = "Response for secureLoginServiceRequest request\n{0}";
			Console.WriteLine(format2, text2);
			responseStream.Close();
			if (httpWebResponse.StatusCode != HttpStatusCode.OK)
			{
				string text3 = "Something wrong in secureLoginServiceRequest\n";
				throw new IOException(text3 + text2);
			}
			BaseResponseBody baseResponseBody = JsonConvert.DeserializeObject<BaseResponseBody>(text2);
			string code = baseResponseBody.code;
			string text4 = "null";
			if (!(code != text4) && baseResponseBody.encData != null && baseResponseBody.status != null && baseResponseBody.httpStatusCode == 200)
			{
				loginValidateResponseBodyForSecureLogin = JsonConvert.DeserializeObject<LoginValidateResponseBody>(SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, username, androidId, enableHighSecurityConfirmServiceResponseBody.mobAppKey));
				Console.WriteLine(JsonConvert.SerializeObject(loginValidateResponseBodyForSecureLogin));
				if (loginValidateResponseBodyForSecureLogin.status)
				{
					loginValidateResponseBody.jSessionId = loginValidateResponseBodyForSecureLogin.jSessionId;
					loginValidateResponseBody.uId = loginValidateResponseBodyForSecureLogin.uId;
				}
				return;
			}
			string text5 = "Something wrong in secureLoginServiceRequest request\n";
			throw new IOException(text5 + text2);
		}

		public string fetchOnlineOTPRequest()
		{
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
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
			header.userName = username;
			Console.WriteLine(JsonConvert.SerializeObject(header));
			string key3 = "header";
			dictionary.Add(key3, Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(header))));
			BaseRequestBody baseRequestBody = new BaseRequestBody();
			baseRequestBody.body = new Body();
			baseRequestBody.body.secretKey = enableHighSecurityConfirmServiceResponseBody.securityKey;
			baseRequestBody.security = new Security();
			baseRequestBody.security.appkey = enableHighSecurityConfirmServiceResponseBody.mobAppKey;
			baseRequestBody.security.mpin = androidId;
			baseRequestBody.security.token1 = loginValidateResponseBody.jSessionId;
			baseRequestBody.security.token2 = loginValidateResponseBody.uId;
			Console.WriteLine(JsonConvert.SerializeObject(baseRequestBody));
			string key4 = "encData";
			dictionary.Add(key4, SBISecureCrypt.EncryptEncData(JsonConvert.SerializeObject(baseRequestBody), username, androidId, enableHighSecurityConfirmServiceResponseBody.mobAppKey));
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
			dictionary.Add(key11, getKonyReportingParams(form, serviceId));
			string formBody = getFormBody(dictionary);
			Console.WriteLine(formBody);
			byte[] bytes = Encoding.UTF8.GetBytes(formBody);
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
			httpWebRequest.CookieContainer = cookieContainer;
			if (isFiddlerProxyUseMust)
			{
				string host = "127.0.0.1";
				httpWebRequest.Proxy = new WebProxy(host, 8888);
			}
			else if (!string.IsNullOrEmpty(ProxyHost))
			{
				string format = "{0}:{1}";
				httpWebRequest.Proxy = new WebProxy(string.Format(format, ProxyHost, ProxyPort), BypassOnLocal: true, null, new NetworkCredential(ProxyUsername, ProxyPassword));
			}
			string method = "POST";
			httpWebRequest.Method = method;
			httpWebRequest.KeepAlive = true;
			httpWebRequest.UserAgent = userAgent;
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
			headers3[name3] = authServiceResponse.claims_token.value;
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
			string format2 = "Response for fetchOnlineOTPRequest request\n{0}";
			Console.WriteLine(format2, text2);
			responseStream.Close();
			if (httpWebResponse.StatusCode != HttpStatusCode.OK)
			{
				string text3 = "Something wrong in fetchOnlineOTPRequest\n";
				throw new IOException(text3 + text2);
			}
			BaseResponseBody baseResponseBody = JsonConvert.DeserializeObject<BaseResponseBody>(text2);
			string code = baseResponseBody.code;
			string text4 = "null";
			if (code != text4 || baseResponseBody.encData == null || baseResponseBody.status == null || baseResponseBody.httpStatusCode != 200)
			{
				string text5 = "Something wrong in fetchOnlineOTPRequest request\n";
				throw new IOException(text5 + text2);
			}
			return SBISecureCrypt.DecryptResponseEncData(baseResponseBody.encData, username, androidId, enableHighSecurityConfirmServiceResponseBody.mobAppKey);
		}

		private DateTime getIndiaDateTime()
		{
			DateTime dateTime = DateTime.Now.ToUniversalTime();
			string id = "India Standard Time";
			TimeZoneInfo destinationTimeZone = TimeZoneInfo.FindSystemTimeZoneById(id);
			return TimeZoneInfo.ConvertTimeFromUtc(dateTime, destinationTimeZone);
		}

		private string getKonyReportingParams(string form, string serviceId)
		{
			ReportParams reportParams = new ReportParams
			{
				os = osVersion,
				dm = phoneModel,
				did = androidId,
				ua = phoneModel,
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

		public static void saveUserInFile(string pathToFile, SbiUser user)
		{
			string contents = JsonConvert.SerializeObject(user, Formatting.Indented);
			File.WriteAllText(pathToFile, contents);
		}

		public static SbiUser createUserFromFile(string pathToFile)
		{
			return JsonConvert.DeserializeObject<SbiUser>(File.ReadAllText(pathToFile));
		}

		static SbiUser()
		{
			string sALT = "c8f4a4536cabfe8233d8d234d005d93e6a91702853cb2d93cb3c846e7ac6c322";
			SALT = sALT;
			string sECRET_KEY = "daf225199b408bdd641d8a8d4e8136c3900c37e1705853b9517a6393aab9b7eaccf1bc8763dabbcf08dd8af07c362774a9ccfe8494f7dcda8c6981d6950428f0";
			SECRET_KEY = sECRET_KEY;
			string mPIN_MAIN = "$652@!#*SaWeQ@";
			MPIN_MAIN = mPIN_MAIN;
			string aPP_KEY_MAIN = "$*|@%$B!$E@u^#@A%!";
			APP_KEY_MAIN = aPP_KEY_MAIN;
			string sERVER_HOST = "https://midentity.onlinesbi.com";
			SERVER_HOST = sERVER_HOST;
			SERVER_PORT = 443;
			string kONY_APP_KEY = "aaee6accb1b00d19ddf0efb0f66a393";
			KONY_APP_KEY = kONY_APP_KEY;
			string kONY_APP_SECRET = "2f9b36d1f6f5c3e940cd940af1e59d4e";
			KONY_APP_SECRET = kONY_APP_SECRET;
			string kONY_SDK_VERSION = "SDK-GA-7.3.0.45";
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
			string aPP_VERSION = "2.2.9";
			APP_VERSION = aPP_VERSION;
			string cHANNEL = "rc";
			CHANNEL = cHANNEL;
			string cONFIG_APP_ID = "6200df4d-2986-4de4-bf3f-44973800fb0a";
			CONFIG_APP_ID = cONFIG_APP_ID;
			string cONFIG_BASE_ID = "06aaa59d-3531-4eb0-8be6-899fcf2554de";
			CONFIG_BASE_ID = cONFIG_BASE_ID;
			string cONFIG_APP_NAME = "SBISmartOTPChe";
			CONFIG_APP_NAME = cONFIG_APP_NAME;
			string kONY_RSID = "1666015648453-f86b-8242-a917";
			KONY_RSID = kONY_RSID;
			string pHONE_AUTHORIZATION = "+917304459011";
			PHONE_AUTHORIZATION = pHONE_AUTHORIZATION;
			string aUTH_SERVICE_PATH = "/authService/100000022/login";
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

	private class SBISecureCrypt
	{
		public static string EncryptEncData(string plnData, string userId, string mpin, string appKey)
		{
			return Base64Encode(EncryptAESCBC(plnData, HexStrToBytes(GetKey(mpin, appKey)), HexStrToBytes(GetIV(userId, mpin))), isUrlSafe: false);
		}

		public static string DecryptRequestEncData(string encData, string userId, string mpin, string appKey)
		{
			byte[] bytes = DecryptAESCBC(Base64Decode(HttpUtility.UrlDecode(encData)), HexStrToBytes(GetKey(mpin, appKey)), HexStrToBytes(GetIV(userId, mpin)));
			return Encoding.UTF8.GetString(bytes);
		}

		public static string DecryptResponseEncData(string encData, string userId, string mpin, string appKey)
		{
			byte[] bytes = DecryptAESCBC(Base64Decode(encData), HexStrToBytes(GetKey(mpin, appKey)), HexStrToBytes(GetIV(userId, mpin)));
			string @string = Encoding.UTF8.GetString(bytes);
			Console.WriteLine(@string);
			return @string;
		}

		internal static string GetKey(string mpin, string appKey)
		{
			return SHA256(mpin + appKey).ToUpper();
		}

		internal static string GetIV(string userId, string mpin)
		{
			return SHA256(Reverse(FormatUserId(userId)) + Reverse(mpin)).Substring(0, 32).ToUpper();
		}

		public static string Reverse(string s)
		{
			char[] array = s.ToCharArray();
			Array.Reverse(array);
			return new string(array);
		}

		internal static string FormatUserId(string userId)
		{
			return (userId + userId).Substring(0, (userId.Length >= 5) ? 10 : (userId.Length * 2));
		}

		private static string SHA256(string input)
		{
			string hashName = "SHA-256";
			HashAlgorithm hashAlgorithm = HashAlgorithm.Create(hashName);
			byte[] bytes = Encoding.UTF8.GetBytes(input);
			return BytesToHexStr(hashAlgorithm.ComputeHash(bytes));
		}

		public static string calcRequestKey(string postBody)
		{
			string text = "#";
			return SHA256(postBody + text + SbiUser.SALT);
		}

		private static string MD5(string input)
		{
			string hashName = "MD5";
			HashAlgorithm hashAlgorithm = HashAlgorithm.Create(hashName);
			byte[] bytes = Encoding.UTF8.GetBytes(input);
			return BytesToHexStr(hashAlgorithm.ComputeHash(bytes));
		}

		public static string SHA512(string input)
		{
			string hashName = "SHA-512";
			HashAlgorithm hashAlgorithm = HashAlgorithm.Create(hashName);
			byte[] bytes = Encoding.UTF8.GetBytes(input);
			return BytesToHexStr(hashAlgorithm.ComputeHash(bytes));
		}

		internal static byte[] EncryptAESCBC(string plainText, byte[] aesKeyBytes, byte[] ivBytes)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(plainText);
			return GetCBCRijndaelManaged(aesKeyBytes, ivBytes).CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length);
		}

		internal static byte[] DecryptAESCBC(byte[] encTextBytes, byte[] aesKeyBytes, byte[] ivBytes)
		{
			return GetCBCRijndaelManaged(aesKeyBytes, ivBytes).CreateDecryptor().TransformFinalBlock(encTextBytes, 0, encTextBytes.Length);
		}

		public static RijndaelManaged GetCBCRijndaelManaged(byte[] secretKeyBytes, byte[] ivBytes)
		{
			return new RijndaelManaged
			{
				Mode = CipherMode.CBC,
				Padding = PaddingMode.PKCS7,
				KeySize = 256,
				BlockSize = 128,
				Key = secretKeyBytes,
				IV = ivBytes
			};
		}

		public static string UpperCaseUrlEncode(string s, Encoding encoding)
		{
			char[] array = HttpUtility.UrlEncode(s, encoding).ToCharArray();
			for (int i = 0; i < array.Length - 2; i++)
			{
				if (array[i] == '%')
				{
					array[i + 1] = char.ToUpper(array[i + 1]);
					array[i + 2] = char.ToUpper(array[i + 2]);
				}
			}
			return new string(array);
		}

		public static string ConvertStringToHexString(string text)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(text);
			StringBuilder stringBuilder = new StringBuilder();
			byte[] array = bytes;
			byte[] array2 = array;
			byte[] array3 = array2;
			foreach (byte b in array3)
			{
				string text2 = "x";
				stringBuilder.Append(b.ToString(text2));
			}
			return stringBuilder.ToString();
		}

		public static string BytesToHexStr(byte[] bArr)
		{
			if (bArr == null)
			{
				return null;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < bArr.Length; i++)
			{
				string format = "{0:x2}";
				stringBuilder.Append(string.Format(format, bArr[i]));
			}
			return stringBuilder.ToString();
		}

		public static byte[] HexStrToBytes(string text)
		{
			byte[] array = new byte[text.Length / 2];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = byte.Parse(text.Substring(i * 2, 2), NumberStyles.HexNumber);
			}
			return array;
		}

		public static string Base64Encode(string plainText, bool isUrlSafe)
		{
			string text = Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
			if (isUrlSafe)
			{
				text = text.Replace('+', '-').Replace('/', '_');
			}
			return text;
		}

		public static string Base64Encode(byte[] plainTextBytes, bool isUrlSafe)
		{
			string text = Convert.ToBase64String(plainTextBytes);
			if (isUrlSafe)
			{
				text = text.Replace('+', '-').Replace('/', '_');
			}
			return text;
		}

		public static byte[] Base64Decode(string base64EncodedData)
		{
			return Convert.FromBase64String(base64EncodedData);
		}

		public static string md5Password(string username, string password, string keyId)
		{
			string text = "#";
			string text2 = MD5(username + text + password);
			string text3 = "#";
			return MD5(text2 + text3 + keyId);
		}

		public static string shaPassword(string username, string password, string keyId)
		{
			string text = "#";
			string text2 = SHA512(username + text + password);
			string text3 = "#";
			return SHA512(text2 + text3 + keyId);
		}

		public static string shaMpin(string username, string mPin, string keyId)
		{
			string text = "~";
			string text2 = SHA512(username + text + mPin);
			string text3 = "#";
			return SHA512(text2 + text3 + keyId);
		}

		public static string shaMpinSet(string username, string mPin)
		{
			string text = "~";
			return SHA512(username + text + mPin);
		}
	}

	public class AuthServiceResponse
	{
		public Claims_Token claims_token { get; set; }

		public string refresh_token { get; set; }
	}

	public class Claims_Token
	{
		public string value { get; set; }

		public long exp { get; set; }
	}

	public class BaseRequestBody
	{
		public Body body { get; set; }

		public Security security { get; set; }
	}

	public class Body
	{
		public string md5Password { get; set; }

		public string shaPassword { get; set; }

		public string serviceId { get; set; }

		public string deviceName { get; set; }

		public string imeiNo { get; set; }

		public string osName { get; set; }

		public string mobileAppVersion { get; set; }

		public string oSversion { get; set; }

		public string encKeyValue { get; set; }

		public string currentDate { get; set; }

		public string deviceId { get; set; }

		public string otp { get; set; }

		public string secretKey { get; set; }

		public string shaMpin { get; set; }

		public string securityKey { get; set; }

		public string answer { get; set; }

		public string question { get; set; }
	}

	public class Security
	{
		public string appkey { get; set; }

		public string mpin { get; set; }

		public string token1 { get; set; }

		public string token2 { get; set; }
	}

	public class BaseResponseBody
	{
		public string code { get; set; }

		public string encData { get; set; }

		public int opstatus { get; set; }

		public string status { get; set; }

		public int httpStatusCode { get; set; }
	}

	public class EnableHighSecurityConfirmServiceResponseBody
	{
		public string uId { get; set; }

		public string jSessionId { get; set; }

		public bool isValidOTP { get; set; }

		public string securityKey { get; set; }

		public string mobAppKey { get; set; }
	}

	public class EnableHighSecurityServiceResponseBody
	{
		public string uId { get; set; }

		public string jSessionId { get; set; }

		public bool isSecureUser { get; set; }

		public string status { get; set; }
	}

	public class FetchDateTimeResponseBody
	{
		public string currentDate { get; set; }
	}

	public class Header
	{
		public string userName { get; set; }

		public string bankCode { get; set; }

		public string token { get; set; }
	}

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

	public class QuestionSubmitServiceResponseBody
	{
		public string errorCode { get; set; }

		public string maxUserCount { get; set; }

		public string userType { get; set; }

		public string errorMsg { get; set; }

		public string status { get; set; }
	}

	public class ReportParams
	{
		public string os { get; set; }

		public string dm { get; set; }

		public string did { get; set; }

		public string ua { get; set; }

		public string aid { get; set; }

		public string aname { get; set; }

		public string chnl { get; set; }

		public string plat { get; set; }

		public string aver { get; set; }

		public string atype { get; set; }

		public string stype { get; set; }

		public string kuid { get; set; }

		public string mfaid { get; set; }

		public string mfbaseid { get; set; }

		public string mfaname { get; set; }

		public string sdkversion { get; set; }

		public string sdktype { get; set; }

		public string fid { get; set; }

		public string rsid { get; set; }

		public string svcid { get; set; }
	}

	public class SecurityServiceResponseBody
	{
		public string keyId { get; set; }

		public string serviceId { get; set; }
	}

	public static bool seassion;

	private SbiUser SbiUser0;

	internal void start()
	{
	}

	internal string GetOTP(string user)
	{
		string result = "";
		try
		{
			string[] array = new string[1];
			string text = "||";
			array[0] = text;
			string text2 = user.Split(array, StringSplitOptions.None)[0].Trim();
			string text3 = "./SBI";
			string text4 = "SBI_";
			string text5 = text4 + text2;
			string text6 = "\\";
			string text7 = ".rg";
			string text8 = text3 + text6 + text5 + text7;
			if (File.Exists(text8))
			{
				if (!seassion)
				{
					SbiUser0 = new SbiUser();
					SbiUser0 = SbiUser.createUserFromFile(text8);
				}
				if (SbiUser0.authServiceResponse.claims_token.exp < DateTimeOffset.Now.ToUnixTimeMilliseconds())
				{
					SbiUser0.authServiceRequest();
					SbiUser0.smartSecServiceRequest();
					SbiUser0.secureLoginServiceRequest();
					seassion = true;
				}
				int num = 0;
				while (true)
				{
					string text9 = SbiUser0.fetchOnlineOTPRequest();
					string value = "status\":\"Success\"";
					if (!text9.Contains(value))
					{
						num++;
						if (num <= 5)
						{
							Thread.Sleep(754);
							continue;
						}
						break;
					}
					string value2 = "onlineOtp";
					string text10 = text9.Substring(text9.IndexOf(value2) + 12);
					string value3 = "\"";
					result = text10.Substring(0, text10.IndexOf(value3));
					break;
				}
			}
		}
		catch
		{
		}
		return result;
	}
}
