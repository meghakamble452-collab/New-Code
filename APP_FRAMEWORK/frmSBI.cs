using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Newtonsoft.Json;
using NEXUS;

namespace APP_FRAMEWORK;

public class frmSBI : Form
{
	private class Class0
	{
		public static string smethod_0(string string_0, string string_1, string string_2, string string_3)
		{
			return smethod_16(smethod_9(string_0, smethod_14(GetKey(string_2, string_3)), smethod_14(smethod_3(string_1, string_2))), bool_0: false);
		}

		public static string smethod_1(string string_0, string string_1, string string_2, string string_3)
		{
			byte[] bytes = bcyHxthGv0(Convert.FromBase64String(HttpUtility.UrlDecode(string_0)), smethod_14(GetKey(string_2, string_3)), smethod_14(smethod_3(string_1, string_2)));
			return Encoding.UTF8.GetString(bytes);
		}

		public static string smethod_2(string string_0, string string_1, string string_2, string string_3)
		{
			byte[] bytes = bcyHxthGv0(Convert.FromBase64String(string_0), smethod_14(GetKey(string_2, string_3)), smethod_14(smethod_3(string_1, string_2)));
			string @string = Encoding.UTF8.GetString(bytes);
			Console.WriteLine(@string);
			return @string;
		}

		internal static string GetKey(string mpin, string appKey)
		{
			return smethod_6(mpin + appKey).ToUpper();
		}

		internal static string smethod_3(string string_0, string string_1)
		{
			return smethod_6(smethod_4(smethod_5(string_0)) + smethod_4(string_1)).Substring(0, 32).ToUpper();
		}

		public static string smethod_4(string string_0)
		{
			char[] array = string_0.ToCharArray();
			Array.Reverse(array);
			return new string(array);
		}

		internal static string smethod_5(string string_0)
		{
			return (string_0 + string_0).Substring(0, (string_0.Length < 5) ? (string_0.Length * 2) : 10);
		}

		private static string smethod_6(string string_0)
		{
			HashAlgorithm hashAlgorithm = HashAlgorithm.Create("SHA-256");
			byte[] bytes = Encoding.UTF8.GetBytes(string_0);
			return smethod_13(hashAlgorithm.ComputeHash(bytes));
		}

		public static string smethod_7(string string_0)
		{
			return smethod_6(string_0 + "#" + Class1.string_0);
		}

		private static string MD5(string input)
		{
			HashAlgorithm hashAlgorithm = HashAlgorithm.Create("MD5");
			byte[] bytes = Encoding.UTF8.GetBytes(input);
			return smethod_13(hashAlgorithm.ComputeHash(bytes));
		}

		public static string smethod_8(string string_0)
		{
			HashAlgorithm hashAlgorithm = HashAlgorithm.Create("SHA-512");
			byte[] bytes = Encoding.UTF8.GetBytes(string_0);
			return smethod_13(hashAlgorithm.ComputeHash(bytes));
		}

		internal static byte[] smethod_9(string string_0, byte[] byte_0, byte[] byte_1)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(string_0);
			return smethod_10(byte_0, byte_1).CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length);
		}

		internal static byte[] bcyHxthGv0(byte[] byte_0, byte[] byte_1, byte[] byte_2)
		{
			return smethod_10(byte_1, byte_2).CreateDecryptor().TransformFinalBlock(byte_0, 0, byte_0.Length);
		}

		public static RijndaelManaged smethod_10(byte[] byte_0, byte[] byte_1)
		{
			return new RijndaelManaged
			{
				Mode = CipherMode.CBC,
				Padding = PaddingMode.PKCS7,
				KeySize = 256,
				BlockSize = 128,
				Key = byte_0,
				IV = byte_1
			};
		}

		public static string smethod_11(string string_0, Encoding encoding_0)
		{
			char[] array = HttpUtility.UrlEncode(string_0, encoding_0).ToCharArray();
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

		public static string smethod_12(string string_0)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(string_0);
			StringBuilder stringBuilder = new StringBuilder();
			byte[] array = bytes;
			byte[] array2 = array;
			byte[] array3 = array2;
			byte[] array4 = array3;
			byte[] array5 = array4;
			byte[] array6 = array5;
			foreach (byte b in array6)
			{
				stringBuilder.Append(b.ToString("x"));
			}
			return stringBuilder.ToString();
		}

		public static string smethod_13(object object_0)
		{
			if (object_0 == null)
			{
				return null;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < ((Array)object_0).Length; i++)
			{
				stringBuilder.Append($"{((byte[])object_0)[i]:x2}");
			}
			return stringBuilder.ToString();
		}

		public static byte[] smethod_14(string string_0)
		{
			byte[] array = new byte[string_0.Length / 2];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = byte.Parse(string_0.Substring(i * 2, 2), NumberStyles.HexNumber);
			}
			return array;
		}

		public static string smethod_15(string string_0, bool bool_0)
		{
			string text = Convert.ToBase64String(Encoding.UTF8.GetBytes(string_0));
			if (bool_0)
			{
				text = text.Replace('+', '-').Replace('/', '_');
			}
			return text;
		}

		public static string smethod_16(byte[] byte_0, bool bool_0)
		{
			string text = Convert.ToBase64String(byte_0);
			if (bool_0)
			{
				text = text.Replace('+', '-').Replace('/', '_');
			}
			return text;
		}

		public static byte[] smethod_17(string string_0)
		{
			return Convert.FromBase64String(string_0);
		}

		public static string smethod_18(string string_0, string string_1, string string_2)
		{
			return MD5(MD5(string_0 + "#" + string_1) + "#" + string_2);
		}

		public static string smethod_19(string string_0, string string_1, string string_2)
		{
			return smethod_8(smethod_8(string_0 + "#" + string_1) + "#" + string_2);
		}

		public static string smethod_20(string string_0, string string_1, string string_2)
		{
			return smethod_8(smethod_8(string_0 + "~" + string_1) + "#" + string_2);
		}

		public static string smethod_21(string string_0, string string_1)
		{
			return smethod_8(string_0 + "~" + string_1);
		}
	}

	private class Class1
	{
		public static string string_0;

		public static string string_1;

		public static string string_2;

		public static string string_3;

		public static string string_4;

		public static int int_0;

		public static string string_5;

		public static string string_6;

		public static string string_7;

		public static string string_8;

		public static string string_9;

		public static string string_10;

		public static string string_11;

		public static string string_12;

		public static string string_13;

		public static string string_14;

		public static string string_15;

		public static string string_16;

		public static string string_17;

		public static string string_18;

		public static string string_19;

		public static string string_20;

		public static string string_21;

		public static string string_22;

		public static string string_23;

		public static string string_24;

		public static string string_25;

		public static string string_26;

		public static string string_27;

		public static string string_28;

		public static string string_29;

		public string string_30;

		public string string_31;

		public string string_32;

		public string string_33 = "";

		public string string_34;

		public string string_35;

		public string string_36;

		public string string_37;

		public string string_38;

		public AuthServiceResponse authServiceResponse_0;

		private string string_;

		public object object_0;

		public SecurityServiceResponseBody securityServiceResponseBody_0;

		public LoginValidateResponseBody loginValidateResponseBody_0;

		public object object_1;

		public EnableHighSecurityConfirmServiceResponseBody enableHighSecurityConfirmServiceResponseBody_0;

		public LoginValidateResponseBody loginValidateResponseBody_1;

		private CookieContainer cookieContainer_0 = new CookieContainer();

		public bool bool_0;

		public string string_39;

		public int int_1;

		public string string_40;

		public string string_41;

		public string string_42;

		private WebProxy Proxy;

		private string currentdate;

		private string messagetxt;

		internal string dataerrormsg;

		public static string SECRET_KEY;

		public Class1()
		{
			string_30 = Class3.smethod_13();
			string_31 = Class3.smethod_0();
			string_32 = "URLConnection/android/" + string_31;
			string_34 = Class3.smethod_10();
			string_42 = RandomString(16, "abcdefghijklmnopqrstuvwxyz1234567890");
		}

		public void method_0S()
		{
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
			string text = "https://api.yonobusinessmobile.sbi/authService/100000002/appconfig";
			Console.WriteLine(text);
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
			httpWebRequest.CookieContainer = cookieContainer_0;
			if (!bool_0)
			{
				if (!string.IsNullOrEmpty(string_39))
				{
					httpWebRequest.Proxy = new WebProxy($"{string_39}:{int_1}", BypassOnLocal: true, null, new NetworkCredential(string_40, string_41));
				}
			}
			else
			{
				httpWebRequest.Proxy = new WebProxy("127.0.0.1", 8888);
			}
			httpWebRequest.Method = "POST";
			httpWebRequest.KeepAlive = true;
			httpWebRequest.UserAgent = string_32;
			httpWebRequest.Headers.Add("Accept-Encoding", "gzip,deflate");
			httpWebRequest.ContentLength = 0L;
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";
			httpWebRequest.Accept = "*/*";
			httpWebRequest.ServicePoint.Expect100Continue = true;
			httpWebRequest.ServicePoint.Expect100Continue = false;
			httpWebRequest.Headers["Cache-Control"] = "no-cache";
			httpWebRequest.Headers["X-Kony-App-Key"] = string_5;
			httpWebRequest.Headers["X-Kony-App-Secret"] = string_6;
			httpWebRequest.ReadWriteTimeout = 5000;
			httpWebRequest.Headers["X-Kony-App-Version"] = "1.0";
			httpWebRequest.Headers["X-Kony-SDK-Type"] = string_9;
			httpWebRequest.Headers["X-Kony-Integrity"] = "BZLN6ZCLN;37A7DB36154B6885C56CF391EEA743EEE09E11BDA7C718010AD8468796F3EC9E";
			httpWebRequest.Headers["X-HTTP-Method-Override"] = "GET";
			HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			Stream responseStream = httpWebResponse.GetResponseStream();
			string arg = new StreamReader(responseStream).ReadToEnd();
			Console.WriteLine("Response for authServiceRequest request\n{0}", arg);
			responseStream.Close();
		}

		public void method_0()
		{
			Class0.smethod_2("qca83KtQtfaopG1R2/F0ZyZHbitY4zPpRUu0CTmDeSXtpbnF7v81uFQHRP5nmembJWF1SOeL+1AdwFeeYNq6xH+HVoA/7AYvqdS7NSBvvSd8DvRNnJgJqdHKkezudwPKxpVwLorJtiOrw0vq5KpeSslKMq+3S3yvZOo57FSYCN+qLU0Fw1gkqP5xA0CCroUpITE0MGPMoSgUzxv/ADJ+fW9ezLrFZIc/eJsqoZm4leI1AF0UidHqLEhlEuz7TGxofrMy3HALEQAAzLx3CKZEMjCuRMTDLgGzGd06r9YdvCzhfY7kMqRWMiiIcD+sZTkLkvFLLRdgcGUJRfoMlP3laA+aVKatqJL1HF7ys/7Pge721LDqMN7GB29/O80LlddimPNthrUOf6R6P2ZB/8nQJYyNQLbggIi2NjCTk4v+iencU5RrbEXejXkRBuQqFdiz", "AMIRAZIM", "f826f3c99f74be9e", "5bU1rye3gbPA3LuT3Ur0v1x8rUpfs0di");
			Class0.smethod_2("mkHIw3Wz3CE6sk41hyC1SVd4SAzgP40E0AhiXs3fIEc91z3BH79RdOoqyG56VjtM", "", string_2, string_3);
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
			string text = "https://api.yonobusinessmobile.sbi/authService/100000002/login";
			Console.WriteLine(text);
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
			httpWebRequest.CookieContainer = cookieContainer_0;
			if (!bool_0)
			{
				if (!string.IsNullOrEmpty(string_39))
				{
					httpWebRequest.Proxy = new WebProxy($"{string_39}:{int_1}", BypassOnLocal: true, null, new NetworkCredential(string_40, string_41));
				}
			}
			else
			{
				httpWebRequest.Proxy = new WebProxy("127.0.0.1", 8888);
			}
			httpWebRequest.ServerCertificateValidationCallback = CertificateValidation;
			httpWebRequest.Method = "POST";
			httpWebRequest.KeepAlive = true;
			httpWebRequest.UserAgent = string_32;
			httpWebRequest.Headers.Add("Accept-Encoding", "gzip,deflate");
			httpWebRequest.ContentLength = 0L;
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";
			httpWebRequest.Accept = "application/json";
			httpWebRequest.ServicePoint.Expect100Continue = true;
			httpWebRequest.ServicePoint.Expect100Continue = false;
			httpWebRequest.Headers["Cache-Control"] = "no-cache";
			httpWebRequest.Headers["X-Kony-SDK-Version"] = string_7;
			httpWebRequest.Headers["X-Kony-App-Key"] = string_5;
			httpWebRequest.Headers["X-Kony-App-Secret"] = string_6;
			httpWebRequest.Headers["X-Kony-Platform"] = string_8;
			httpWebRequest.Headers["X-Kony-SDK-Type"] = string_9;
			string value = method_12("frmSimRegister", "login_$anonymousProvider");
			httpWebRequest.Headers["X-Kony-ReportingParams"] = value;
			httpWebRequest.ReadWriteTimeout = 5000;
			HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			Stream responseStream = httpWebResponse.GetResponseStream();
			string text2 = new StreamReader(responseStream).ReadToEnd();
			Console.WriteLine("Response for authServiceRequest request\n{0}", text2);
			responseStream.Close();
			if (httpWebResponse.StatusCode != HttpStatusCode.OK)
			{
				throw new IOException("Something wrong in vpaListRequest\n" + text2);
			}
			AuthServiceResponse authServiceResponse = JsonConvert.DeserializeObject<AuthServiceResponse>(text2);
			if (authServiceResponse.claims_token == null || authServiceResponse.claims_token.value == null || authServiceResponse.refresh_token == null)
			{
				throw new IOException("Something wrong in authServiceRequest request\n" + text2);
			}
			authServiceResponse_0 = authServiceResponse;
		}

		public static bool CertificateValidation(object object_18, X509Certificate x509Certificate_0, X509Chain x509Chain_0, SslPolicyErrors sslPolicyErrors_0)
		{
			bool result = false;
			try
			{
				if (!(object_18 is HttpWebRequest httpWebRequest) || !httpWebRequest.Address.ToString().ToLower().Contains("{https://raw.githubusercontent.com}") || x509Certificate_0.Issuer.StartsWith("CN=DigiCert"))
				{
					if (x509Certificate_0.Issuer.ToLower().Contains("httpanalyze") || x509Certificate_0.Issuer.ToLower().Contains("charles") || x509Certificate_0.Issuer.ToLower().Contains("fiddler") || x509Certificate_0.Issuer.ToLower().Contains("commview") || x509Certificate_0.Issuer.ToLower().Contains("debugger") || x509Certificate_0.Issuer.ToLower().Contains("debug") || x509Certificate_0.Issuer.ToLower().Contains("sniffer") || x509Certificate_0.Issuer.ToUpper().Contains("IEINSPECTOR"))
					{
						Environment.Exit(0);
						Application.Exit();
						return result;
					}
					return true;
				}
				Environment.Exit(0);
				Application.Exit();
				return result;
			}
			catch (Exception)
			{
				return true;
			}
		}

		internal string GetHash(ref string mup)
		{
			string text = RandomString(9, "abcdeflmno0123456789pqrstuvwxyz").ToUpper();
			string text2 = RandomString(5, "abcdefghijklstu0123456789vwxyz").ToUpper();
			string text3 = RandomString(5, "abcdefghijklmnopqrstuvwxyz1234567890").ToUpper();
			string text4 = RandomString(5, "0123456789");
			string text5 = RandomString(13, "opqrst0123456789abcdefghijklmn").ToUpper();
			string result = text + "=" + text2 + "=" + text3 + "=" + text4 + "=" + text5;
			mup = text.Remove(text.Length - 1) + "-" + text2.Remove(text2.Length - 1) + "-" + text3.Remove(text3.Length - 1) + "-" + text4.Remove(text4.Length - 1) + "-" + text5.Remove(text5.Length - 1);
			return result;
		}

		public void method_1()
		{
			while (true)
			{
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				string text = string_4 + string_21;
				Console.WriteLine(text);
				Dictionary<string, string> dictionary = new Dictionary<string, string> { { "optionalFlagFormUI", "false" } };
				Header value = new Header
				{
					bankCode = "",
					token = "",
					userName = ""
				};
				Console.WriteLine(JsonConvert.SerializeObject(value));
				dictionary.Add("header", Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value))));
				BaseRequestBody baseRequestBody = new BaseRequestBody();
				baseRequestBody.body = new Body();
				baseRequestBody.security = new Security();
				baseRequestBody.security.appkey = "";
				baseRequestBody.security.mpin = "";
				baseRequestBody.security.token1 = "";
				baseRequestBody.security.token2 = "";
				Console.WriteLine(JsonConvert.SerializeObject(baseRequestBody));
				dictionary.Add("encData", Class0.smethod_0(JsonConvert.SerializeObject(baseRequestBody), "", string_2, string_3));
				dictionary.Add("requestKey", Class0.smethod_7(JsonConvert.SerializeObject(baseRequestBody)));
				dictionary.Add("platform", string_8);
				string value2 = method_12("frmSimRegister", "FetchDateTime");
				string text2 = method_13(dictionary);
				Console.WriteLine(text2);
				byte[] bytes = Encoding.UTF8.GetBytes(text2);
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
				httpWebRequest.CookieContainer = cookieContainer_0;
				if (!bool_0)
				{
					if (!string.IsNullOrEmpty(string_39))
					{
						httpWebRequest.Proxy = new WebProxy($"{string_39}:{int_1}", BypassOnLocal: true, null, new NetworkCredential(string_40, string_41));
					}
				}
				else
				{
					httpWebRequest.Proxy = new WebProxy("127.0.0.1", 8888);
				}
				httpWebRequest.Method = "POST";
				httpWebRequest.KeepAlive = true;
				httpWebRequest.UserAgent = string_32;
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip,deflate");
				httpWebRequest.ContentLength = bytes.Length;
				httpWebRequest.ContentType = "application/json";
				httpWebRequest.Headers["X-Kony-ReportingParams"] = value2;
				httpWebRequest.ServicePoint.Expect100Continue = true;
				httpWebRequest.Headers["Cache-Control"] = "no-cache";
				httpWebRequest.ReadWriteTimeout = 5000;
				httpWebRequest.Headers["X-Kony-Authorizationn"] = authServiceResponse_0.claims_token.value;
				httpWebRequest.Headers["X-Kony-API-Version"] = string_10;
				httpWebRequest.Headers["X-Kony-DeviceId"] = string_42;
				using (Stream stream = httpWebRequest.GetRequestStream())
				{
					stream.Write(bytes, 0, bytes.Length);
					stream.Close();
				}
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				Stream responseStream = httpWebResponse.GetResponseStream();
				string text3 = new StreamReader(responseStream).ReadToEnd();
				Console.WriteLine("Response for fetchDateTimeRequest request\n{0}", text3);
				responseStream.Close();
				if (httpWebResponse.StatusCode == HttpStatusCode.OK)
				{
					BaseResponseBody baseResponseBody = JsonConvert.DeserializeObject<BaseResponseBody>(text3);
					if (!(baseResponseBody.code != "null") && baseResponseBody.encData != null && baseResponseBody.status != null && baseResponseBody.httpStatusCode == 200)
					{
						break;
					}
				}
			}
			messagetxt = getSmsText(string_30);
		}

		private string GetString(string string_86, string string_87)
		{
			string result = "";
			try
			{
				string text = string_86.Substring(string_86.IndexOf("\"" + string_87));
				string text2 = text.Substring(text.IndexOf(string_87) + (string_87.Length + 3));
				text2 = text2.Substring(0, text2.IndexOf("\""));
				result = text2;
				return result;
			}
			catch
			{
				return result;
			}
		}

		public string method_2()
		{
			BaseResponseBody baseResponseBody;
			while (true)
			{
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				string text = string_4 + string_22;
				Console.WriteLine(text);
				Dictionary<string, string> dictionary = new Dictionary<string, string> { { "optionalFlagFomUI", "false" } };
				Header value = new Header
				{
					bankCode = "",
					token = "",
					userName = ""
				};
				Console.WriteLine(JsonConvert.SerializeObject(value));
				dictionary.Add("header", Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value))));
				BaseRequestBody baseRequestBody = new BaseRequestBody();
				baseRequestBody.body = new Body();
				baseRequestBody.security = new Security();
				baseRequestBody.security.appkey = "";
				baseRequestBody.security.mpin = "";
				baseRequestBody.security.token1 = "";
				baseRequestBody.security.token2 = "";
				Console.WriteLine(JsonConvert.SerializeObject(baseRequestBody));
				dictionary.Add("encData", Class0.smethod_0(JsonConvert.SerializeObject(baseRequestBody), "", string_2, string_3));
				dictionary.Add("requestKey", Class0.smethod_7(JsonConvert.SerializeObject(baseRequestBody)));
				dictionary.Add("appver", string_13);
				dictionary.Add("platform", string_8);
				string value2 = method_12("frmRegister", "SecurityService");
				string text2 = method_13(dictionary);
				Console.WriteLine(text2);
				byte[] bytes = Encoding.UTF8.GetBytes(text2);
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
				httpWebRequest.CookieContainer = cookieContainer_0;
				if (bool_0)
				{
					httpWebRequest.Proxy = new WebProxy("127.0.0.1", 8888);
				}
				else if (!string.IsNullOrEmpty(string_39))
				{
					httpWebRequest.Proxy = new WebProxy($"{string_39}:{int_1}", BypassOnLocal: true, null, new NetworkCredential(string_40, string_41));
				}
				httpWebRequest.Proxy = Proxy;
				httpWebRequest.Method = "POST";
				httpWebRequest.KeepAlive = true;
				httpWebRequest.UserAgent = string_32;
				httpWebRequest.ReadWriteTimeout = 5000;
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip,deflate");
				httpWebRequest.Headers["X-Kony-ReportingParams"] = value2;
				httpWebRequest.ContentLength = bytes.Length;
				httpWebRequest.ContentType = "application/json";
				httpWebRequest.ServicePoint.Expect100Continue = true;
				httpWebRequest.Headers["Cache-Control"] = "no-cache";
				httpWebRequest.Headers["X-Kony-Authorizationn"] = authServiceResponse_0.claims_token.value;
				httpWebRequest.Headers["X-Kony-API-Version"] = string_10;
				httpWebRequest.Headers["X-Kony-DeviceId"] = string_42;
				using (Stream stream = httpWebRequest.GetRequestStream())
				{
					stream.Write(bytes, 0, bytes.Length);
					stream.Close();
				}
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				Stream responseStream = httpWebResponse.GetResponseStream();
				string text3 = new StreamReader(responseStream).ReadToEnd();
				Console.WriteLine("Response for securityServiceRequest request\n{0}", text3);
				responseStream.Close();
				if (httpWebResponse.StatusCode == HttpStatusCode.OK)
				{
					baseResponseBody = JsonConvert.DeserializeObject<BaseResponseBody>(text3);
					if (!(baseResponseBody.code != "null") && baseResponseBody.encData != null && baseResponseBody.status != null && baseResponseBody.httpStatusCode == 200)
					{
						break;
					}
				}
			}
			securityServiceResponseBody_0 = JsonConvert.DeserializeObject<SecurityServiceResponseBody>(Class0.smethod_2(baseResponseBody.encData, "", string_2, string_3));
			Class0.smethod_2(baseResponseBody.status, "", string_2, string_3);
			Console.WriteLine(JsonConvert.SerializeObject(securityServiceResponseBody_0));
			return Class0.smethod_2(baseResponseBody.encData, "", string_2, string_3);
		}

		public string method_3()
		{
			BaseResponseBody baseResponseBody;
			while (true)
			{
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				string text = string_4 + string_23;
				Console.WriteLine(text);
				Dictionary<string, string> dictionary = new Dictionary<string, string> { { "optionalFlagFomUI", "false" } };
				Header value = new Header
				{
					bankCode = "0",
					token = "",
					userName = string_36
				};
				Console.WriteLine(JsonConvert.SerializeObject(value));
				dictionary.Add("header", Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value))));
				BaseRequestBody baseRequestBody = new BaseRequestBody();
				baseRequestBody.body = new Body();
				baseRequestBody.body.md5Password = Class0.smethod_18(string_36, string_37, securityServiceResponseBody_0.keyId);
				baseRequestBody.body.shaPassword = Class0.smethod_19(string_36, string_37, securityServiceResponseBody_0.keyId);
				baseRequestBody.body.serviceId = securityServiceResponseBody_0.serviceId;
				baseRequestBody.body.deviceName = string_31;
				baseRequestBody.body.imeiNo = string_30;
				baseRequestBody.body.osName = string_8;
				baseRequestBody.body.mobileAppVersion = string_13;
				baseRequestBody.body.oSversion = "12";
				baseRequestBody.body.encKeyValue = string_35;
				baseRequestBody.body.currentDate = currentdate;
				baseRequestBody.security = new Security();
				baseRequestBody.security.appkey = "";
				baseRequestBody.security.mpin = "";
				baseRequestBody.security.token1 = "";
				baseRequestBody.security.token2 = "";
				Console.WriteLine(JsonConvert.SerializeObject(baseRequestBody));
				dictionary.Add("encData", Class0.smethod_0(JsonConvert.SerializeObject(baseRequestBody), string_36, string_2, string_3));
				dictionary.Add("requestKey", Class0.smethod_7(JsonConvert.SerializeObject(baseRequestBody)));
				dictionary.Add("appver", string_13);
				dictionary.Add("platform", "android");
				string value2 = method_12("frmRegister", "LoginValidate");
				string text2 = method_13(dictionary);
				Console.WriteLine(text2);
				byte[] bytes = Encoding.UTF8.GetBytes(text2);
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
				httpWebRequest.CookieContainer = cookieContainer_0;
				if (!bool_0)
				{
					if (!string.IsNullOrEmpty(string_39))
					{
						httpWebRequest.Proxy = new WebProxy($"{string_39}:{int_1}", BypassOnLocal: true, null, new NetworkCredential(string_40, string_41));
					}
				}
				else
				{
					httpWebRequest.Proxy = new WebProxy("127.0.0.1", 8888);
				}
				httpWebRequest.Method = "POST";
				httpWebRequest.KeepAlive = true;
				httpWebRequest.ReadWriteTimeout = 5000;
				httpWebRequest.UserAgent = string_32;
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip,deflate");
				httpWebRequest.ContentLength = bytes.Length;
				httpWebRequest.ContentType = "application/json";
				httpWebRequest.ServicePoint.Expect100Continue = true;
				httpWebRequest.Headers["Cache-Control"] = "no-cache";
				httpWebRequest.Headers["X-Kony-Authorizationn"] = authServiceResponse_0.claims_token.value;
				httpWebRequest.Headers["X-Kony-API-Version"] = string_10;
				httpWebRequest.Headers["X-Kony-ReportingParams"] = value2;
				httpWebRequest.Headers["X-Kony-DeviceId"] = string_42;
				using (Stream stream = httpWebRequest.GetRequestStream())
				{
					stream.Write(bytes, 0, bytes.Length);
					stream.Close();
				}
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				Stream responseStream = httpWebResponse.GetResponseStream();
				string text3 = new StreamReader(responseStream).ReadToEnd();
				Console.WriteLine("Response for loginValidateRequest request\n{0}", text3);
				responseStream.Close();
				if (httpWebResponse.StatusCode == HttpStatusCode.OK)
				{
					baseResponseBody = JsonConvert.DeserializeObject<BaseResponseBody>(text3);
					if (!(baseResponseBody.code != "null") && baseResponseBody.encData != null && baseResponseBody.status != null && baseResponseBody.httpStatusCode == 200)
					{
						break;
					}
				}
			}
			dataerrormsg = Class0.smethod_2(baseResponseBody.status, string_36, string_2, string_3);
			string result = Class0.smethod_2(baseResponseBody.encData, string_36, string_2, string_3);
			loginValidateResponseBody_0 = JsonConvert.DeserializeObject<LoginValidateResponseBody>(Class0.smethod_2(baseResponseBody.encData, string_36, string_2, string_3));
			Console.WriteLine(JsonConvert.SerializeObject(loginValidateResponseBody_0));
			return result;
		}

		public string method_4()
		{
			BaseResponseBody baseResponseBody;
			while (true)
			{
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				string text = string_4 + string_24;
				Console.WriteLine(text);
				Dictionary<string, string> dictionary = new Dictionary<string, string> { { "optionalFlagFomUI", "false" } };
				Header value = new Header
				{
					bankCode = "0",
					token = "",
					userName = string_36
				};
				Console.WriteLine(JsonConvert.SerializeObject(value));
				dictionary.Add("header", Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value))));
				BaseRequestBody baseRequestBody = new BaseRequestBody();
				baseRequestBody.body = new Body();
				baseRequestBody.security = new Security();
				baseRequestBody.security.appkey = string_3;
				baseRequestBody.security.mpin = string_2;
				baseRequestBody.security.token1 = loginValidateResponseBody_0.jSessionId;
				baseRequestBody.security.token2 = loginValidateResponseBody_0.uId;
				Console.WriteLine(JsonConvert.SerializeObject(baseRequestBody));
				dictionary.Add("encData", Class0.smethod_0(JsonConvert.SerializeObject(baseRequestBody), string_36, string_2, string_3));
				dictionary.Add("requestKey", Class0.smethod_7(JsonConvert.SerializeObject(baseRequestBody)));
				dictionary.Add("appver", string_13);
				dictionary.Add("platform", "android");
				string value2 = method_12("frmAgree", "EnableHighSecurityService");
				string text2 = method_13(dictionary);
				Console.WriteLine(text2);
				byte[] bytes = Encoding.UTF8.GetBytes(text2);
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
				httpWebRequest.CookieContainer = cookieContainer_0;
				if (bool_0)
				{
					httpWebRequest.Proxy = new WebProxy("127.0.0.1", 8888);
				}
				else if (!string.IsNullOrEmpty(string_39))
				{
					httpWebRequest.Proxy = new WebProxy($"{string_39}:{int_1}", BypassOnLocal: true, null, new NetworkCredential(string_40, string_41));
				}
				httpWebRequest.Method = "POST";
				httpWebRequest.ReadWriteTimeout = 5000;
				httpWebRequest.Headers["X-Kony-ReportingParams"] = value2;
				httpWebRequest.KeepAlive = true;
				httpWebRequest.Headers["X-Kony-DeviceId"] = string_42;
				httpWebRequest.UserAgent = string_32;
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip,deflate");
				httpWebRequest.ContentLength = bytes.Length;
				httpWebRequest.ContentType = "application/json";
				httpWebRequest.ServicePoint.Expect100Continue = true;
				httpWebRequest.Headers["Cache-Control"] = "no-cache";
				httpWebRequest.Headers["X-Kony-Authorizationn"] = authServiceResponse_0.claims_token.value;
				httpWebRequest.Headers["X-Kony-API-Version"] = string_10;
				using (Stream stream = httpWebRequest.GetRequestStream())
				{
					stream.Write(bytes, 0, bytes.Length);
					stream.Close();
				}
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				Stream responseStream = httpWebResponse.GetResponseStream();
				string text3 = new StreamReader(responseStream).ReadToEnd();
				Console.WriteLine("Response for enableHighSecurityServiceRequest request\n{0}", text3);
				responseStream.Close();
				if (httpWebResponse.StatusCode == HttpStatusCode.OK)
				{
					baseResponseBody = JsonConvert.DeserializeObject<BaseResponseBody>(text3);
					if (!(baseResponseBody.code != "null") && baseResponseBody.encData != null && baseResponseBody.status != null && baseResponseBody.httpStatusCode == 200)
					{
						break;
					}
				}
			}
			object_1 = JsonConvert.DeserializeObject<EnableHighSecurityServiceResponseBody>(Class0.smethod_2(baseResponseBody.encData, string_36, string_2, string_3));
			Console.WriteLine(JsonConvert.SerializeObject(object_1));
			return Class0.smethod_2(baseResponseBody.encData, string_36, string_2, string_3);
		}

		public void method_5(string string_42)
		{
			BaseResponseBody baseResponseBody;
			while (true)
			{
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				string text = string_4 + string_25;
				Console.WriteLine(text);
				Dictionary<string, string> dictionary = new Dictionary<string, string> { { "optionalFlagFomUI", "false" } };
				Header value = new Header
				{
					bankCode = "0",
					token = "",
					userName = string_36
				};
				Console.WriteLine(JsonConvert.SerializeObject(value));
				dictionary.Add("header", Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value))));
				BaseRequestBody baseRequestBody = new BaseRequestBody();
				baseRequestBody.body = new Body();
				baseRequestBody.body.deviceId = string_30;
				baseRequestBody.body.otp = string_42;
				baseRequestBody.security = new Security();
				baseRequestBody.security.appkey = string_3;
				baseRequestBody.security.mpin = string_2;
				baseRequestBody.security.token1 = loginValidateResponseBody_0.jSessionId;
				baseRequestBody.security.token2 = loginValidateResponseBody_0.uId;
				Console.WriteLine(JsonConvert.SerializeObject(baseRequestBody));
				dictionary.Add("encData", Class0.smethod_0(JsonConvert.SerializeObject(baseRequestBody), string_36, string_2, string_3));
				dictionary.Add("requestKey", Class0.smethod_7(JsonConvert.SerializeObject(baseRequestBody)));
				dictionary.Add("appID", string_11);
				dictionary.Add("appver", string_13);
				dictionary.Add("channel", string_14);
				dictionary.Add("platform", string_8);
				dictionary.Add("cacheid", "");
				string value2 = method_12("frmRegister", "SecurityService");
				string text2 = method_13(dictionary);
				Console.WriteLine(text2);
				byte[] bytes = Encoding.UTF8.GetBytes(text2);
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
				httpWebRequest.CookieContainer = cookieContainer_0;
				if (!bool_0)
				{
					if (!string.IsNullOrEmpty(string_39))
					{
						httpWebRequest.Proxy = new WebProxy($"{string_39}:{int_1}", BypassOnLocal: true, null, new NetworkCredential(string_40, string_41));
					}
				}
				else
				{
					httpWebRequest.Proxy = new WebProxy("127.0.0.1", 8888);
				}
				httpWebRequest.Headers["X-Kony-ReportingParams"] = value2;
				httpWebRequest.Method = "POST";
				httpWebRequest.KeepAlive = true;
				httpWebRequest.UserAgent = string_32;
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip,deflate");
				httpWebRequest.ContentLength = bytes.Length;
				httpWebRequest.ContentType = "application/json";
				httpWebRequest.ServicePoint.Expect100Continue = true;
				httpWebRequest.Headers["Cache-Control"] = "no-cache";
				httpWebRequest.ReadWriteTimeout = 5000;
				httpWebRequest.Headers["X-Kony-Authorizationn"] = authServiceResponse_0.claims_token.value;
				httpWebRequest.Headers["X-Kony-API-Version"] = string_10;
				using (Stream stream = httpWebRequest.GetRequestStream())
				{
					stream.Write(bytes, 0, bytes.Length);
					stream.Close();
				}
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				Stream responseStream = httpWebResponse.GetResponseStream();
				string text3 = new StreamReader(responseStream).ReadToEnd();
				Console.WriteLine("Response for enableHighSecurityConfirmServiceRequest request\n{0}", text3);
				responseStream.Close();
				if (httpWebResponse.StatusCode == HttpStatusCode.OK)
				{
					baseResponseBody = JsonConvert.DeserializeObject<BaseResponseBody>(text3);
					if (!(baseResponseBody.code != "null") && baseResponseBody.encData != null && baseResponseBody.status != null && baseResponseBody.httpStatusCode == 200)
					{
						break;
					}
				}
			}
			enableHighSecurityConfirmServiceResponseBody_0 = JsonConvert.DeserializeObject<EnableHighSecurityConfirmServiceResponseBody>(Class0.smethod_2(baseResponseBody.encData, string_36, string_2, string_3));
			Console.WriteLine(JsonConvert.SerializeObject(enableHighSecurityConfirmServiceResponseBody_0));
		}

		public string method_6(string string_42)
		{
			string text4;
			while (true)
			{
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				string_38 = string_42;
				string text = string_4 + string_26;
				Console.WriteLine(text);
				Dictionary<string, string> dictionary = new Dictionary<string, string> { { "optionalFlagFomUI", "false" } };
				Header value = new Header
				{
					bankCode = "0",
					token = "",
					userName = string_36
				};
				Console.WriteLine(JsonConvert.SerializeObject(value));
				dictionary.Add("header", Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value))));
				BaseRequestBody baseRequestBody = new BaseRequestBody();
				baseRequestBody.body = new Body();
				baseRequestBody.body.deviceId = string_30;
				baseRequestBody.body.answer = "andanswers";
				baseRequestBody.body.question = "stop sending questions";
				baseRequestBody.body.shaMpin = Class0.smethod_21(string_36, string_42);
				baseRequestBody.body.securityKey = enableHighSecurityConfirmServiceResponseBody_0.securityKey;
				baseRequestBody.security = new Security();
				baseRequestBody.security.appkey = enableHighSecurityConfirmServiceResponseBody_0.securityKey;
				baseRequestBody.security.mpin = string_30;
				baseRequestBody.security.token1 = loginValidateResponseBody_0.jSessionId;
				baseRequestBody.security.token2 = loginValidateResponseBody_0.uId;
				Console.WriteLine(JsonConvert.SerializeObject(baseRequestBody));
				string value2 = method_12("frmSetPINNew", "RegisterConfirmService");
				dictionary.Add("encData", Class0.smethod_0(JsonConvert.SerializeObject(baseRequestBody), string_36, string_30, enableHighSecurityConfirmServiceResponseBody_0.mobAppKey));
				dictionary.Add("requestKey", Class0.smethod_7(JsonConvert.SerializeObject(baseRequestBody)));
				dictionary.Add("appID", string_11);
				dictionary.Add("appver", string_13);
				dictionary.Add("channel", string_14);
				dictionary.Add("platform", string_8);
				dictionary.Add("cacheid", "");
				dictionary.Add("konyreportingparams", method_12("frmSetPINNew", "QuestionSubmitService"));
				string text2 = method_13(dictionary);
				Console.WriteLine(text2);
				byte[] bytes = Encoding.UTF8.GetBytes(text2);
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
				httpWebRequest.CookieContainer = cookieContainer_0;
				if (bool_0)
				{
					httpWebRequest.Proxy = new WebProxy("127.0.0.1", 8888);
				}
				else if (!string.IsNullOrEmpty(string_39))
				{
					httpWebRequest.Proxy = new WebProxy($"{string_39}:{int_1}", BypassOnLocal: true, null, new NetworkCredential(string_40, string_41));
				}
				httpWebRequest.Method = "POST";
				httpWebRequest.KeepAlive = true;
				httpWebRequest.UserAgent = string_32;
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip,deflate");
				httpWebRequest.ReadWriteTimeout = 5000;
				httpWebRequest.ContentLength = bytes.Length;
				httpWebRequest.ReadWriteTimeout = 5000;
				httpWebRequest.ContentType = "application/json";
				httpWebRequest.ServicePoint.Expect100Continue = true;
				httpWebRequest.Headers["Cache-Control"] = "no-cache";
				httpWebRequest.Headers["X-Kony-Authorizationn"] = authServiceResponse_0.claims_token.value;
				httpWebRequest.Headers["X-Kony-API-Version"] = string_10;
				httpWebRequest.Headers["X-Kony-ReportingParams"] = value2;
				using (Stream stream = httpWebRequest.GetRequestStream())
				{
					stream.Write(bytes, 0, bytes.Length);
					stream.Close();
				}
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				Stream responseStream = httpWebResponse.GetResponseStream();
				string text3 = new StreamReader(responseStream).ReadToEnd();
				Console.WriteLine("Response for questionSubmitServiceRequest request\n{0}", text3);
				responseStream.Close();
				if (httpWebResponse.StatusCode != HttpStatusCode.OK)
				{
					continue;
				}
				BaseResponseBody baseResponseBody = JsonConvert.DeserializeObject<BaseResponseBody>(text3);
				if (!(baseResponseBody.code != "null") && baseResponseBody.encData != null && baseResponseBody.status != null && baseResponseBody.httpStatusCode == 200)
				{
					text4 = Class0.smethod_2(baseResponseBody.encData, string_36, string_30, enableHighSecurityConfirmServiceResponseBody_0.mobAppKey);
					QuestionSubmitServiceResponseBody questionSubmitServiceResponseBody = JsonConvert.DeserializeObject<QuestionSubmitServiceResponseBody>(text4);
					if (questionSubmitServiceResponseBody != null && questionSubmitServiceResponseBody.status.Equals("success"))
					{
						break;
					}
				}
			}
			return text4;
		}

		public void method_7()
		{
			BaseResponseBody baseResponseBody;
			while (true)
			{
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				string text = string_4 + string_27;
				Console.WriteLine(text);
				Dictionary<string, string> dictionary = new Dictionary<string, string> { { "optionalFlagFomUI", "false" } };
				Header value = new Header
				{
					bankCode = "",
					token = "",
					userName = ""
				};
				Console.WriteLine(JsonConvert.SerializeObject(value));
				dictionary.Add("header", Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value))));
				BaseRequestBody baseRequestBody = new BaseRequestBody();
				baseRequestBody.body = new Body();
				baseRequestBody.security = new Security();
				baseRequestBody.security.appkey = "";
				baseRequestBody.security.mpin = "";
				baseRequestBody.security.token1 = "";
				baseRequestBody.security.token2 = "";
				Console.WriteLine(JsonConvert.SerializeObject(baseRequestBody));
				dictionary.Add("encData", Class0.smethod_0(JsonConvert.SerializeObject(baseRequestBody), "", string_2, string_3));
				dictionary.Add("requestKey", Class0.smethod_7(JsonConvert.SerializeObject(baseRequestBody)));
				dictionary.Add("appID", string_11);
				dictionary.Add("appver", string_13);
				dictionary.Add("channel", string_14);
				dictionary.Add("platform", string_8);
				dictionary.Add("cacheid", "");
				string value2 = method_12("frmLoginWithMPin", "SmartSecService");
				string text2 = method_13(dictionary);
				Console.WriteLine(text2);
				byte[] bytes = Encoding.UTF8.GetBytes(text2);
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
				httpWebRequest.CookieContainer = cookieContainer_0;
				if (!bool_0)
				{
					if (!string.IsNullOrEmpty(string_39))
					{
						httpWebRequest.Proxy = new WebProxy($"{string_39}:{int_1}", BypassOnLocal: true, null, new NetworkCredential(string_40, string_41));
					}
				}
				else
				{
					httpWebRequest.Proxy = new WebProxy("127.0.0.1", 8888);
				}
				httpWebRequest.Method = "POST";
				httpWebRequest.KeepAlive = true;
				httpWebRequest.UserAgent = string_32;
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip,deflate");
				httpWebRequest.ContentLength = bytes.Length;
				httpWebRequest.ReadWriteTimeout = 5000;
				httpWebRequest.ContentType = "application/json";
				httpWebRequest.ServicePoint.Expect100Continue = true;
				httpWebRequest.Headers["Cache-Control"] = "no-cache";
				httpWebRequest.Headers["X-Kony-Authorizationn"] = authServiceResponse_0.claims_token.value;
				httpWebRequest.Headers["X-Kony-API-Version"] = string_10;
				httpWebRequest.Headers["X-Kony-ReportingParams"] = value2;
				using (Stream stream = httpWebRequest.GetRequestStream())
				{
					stream.Write(bytes, 0, bytes.Length);
					stream.Close();
				}
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				Stream responseStream = httpWebResponse.GetResponseStream();
				string text3 = new StreamReader(responseStream).ReadToEnd();
				Console.WriteLine("Response for smartSecServiceRequest request\n{0}", text3);
				responseStream.Close();
				if (httpWebResponse.StatusCode == HttpStatusCode.OK)
				{
					baseResponseBody = JsonConvert.DeserializeObject<BaseResponseBody>(text3);
					if (!(baseResponseBody.code != "null") && baseResponseBody.encData != null && baseResponseBody.status != null && baseResponseBody.httpStatusCode == 200)
					{
						break;
					}
				}
			}
			securityServiceResponseBody_0 = JsonConvert.DeserializeObject<SecurityServiceResponseBody>(Class0.smethod_2(baseResponseBody.encData, "", string_2, string_3));
			Console.WriteLine(JsonConvert.SerializeObject(securityServiceResponseBody_0));
		}

		public void method_8()
		{
			BaseResponseBody baseResponseBody;
			while (true)
			{
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				string text = string_4 + string_28;
				Console.WriteLine(text);
				Dictionary<string, string> dictionary = new Dictionary<string, string> { { "optionalFlagFomUI", "false" } };
				Header value = new Header
				{
					bankCode = "0",
					token = "",
					userName = string_36
				};
				Console.WriteLine(JsonConvert.SerializeObject(value));
				dictionary.Add("header", Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value))));
				BaseRequestBody baseRequestBody = new BaseRequestBody();
				baseRequestBody.body = new Body();
				baseRequestBody.body.secretKey = enableHighSecurityConfirmServiceResponseBody_0.securityKey;
				baseRequestBody.body.shaMpin = Class0.smethod_20(string_36, string_38, securityServiceResponseBody_0.keyId);
				baseRequestBody.body.serviceId = securityServiceResponseBody_0.serviceId;
				baseRequestBody.body.deviceName = string_31;
				baseRequestBody.body.imeiNo = string_30;
				baseRequestBody.body.osName = string_8;
				baseRequestBody.body.mobileAppVersion = string_13;
				baseRequestBody.body.oSversion = "12";
				baseRequestBody.security = new Security();
				baseRequestBody.security.appkey = "";
				baseRequestBody.security.mpin = "";
				baseRequestBody.security.token1 = "";
				baseRequestBody.security.token2 = "";
				Console.WriteLine(JsonConvert.SerializeObject(baseRequestBody));
				dictionary.Add("encData", Class0.smethod_0(JsonConvert.SerializeObject(baseRequestBody), string_36, string_30, enableHighSecurityConfirmServiceResponseBody_0.mobAppKey));
				dictionary.Add("requestKey", Class0.smethod_7(JsonConvert.SerializeObject(baseRequestBody)));
				dictionary.Add("jSessionId", loginValidateResponseBody_0.jSessionId);
				dictionary.Add("ipAddress", "");
				dictionary.Add("appID", string_11);
				dictionary.Add("appver", string_13);
				dictionary.Add("channel", string_14);
				dictionary.Add("platform", string_8);
				dictionary.Add("cacheid", "");
				method_12("konyreportingparams", "SecureLoginService");
				string text2 = method_13(dictionary);
				Console.WriteLine(text2);
				byte[] bytes = Encoding.UTF8.GetBytes(text2);
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
				httpWebRequest.CookieContainer = cookieContainer_0;
				if (!bool_0)
				{
					if (!string.IsNullOrEmpty(string_39))
					{
						httpWebRequest.Proxy = new WebProxy($"{string_39}:{int_1}", BypassOnLocal: true, null, new NetworkCredential(string_40, string_41));
					}
				}
				else
				{
					httpWebRequest.Proxy = new WebProxy("127.0.0.1", 8888);
				}
				httpWebRequest.Method = "POST";
				httpWebRequest.KeepAlive = true;
				httpWebRequest.UserAgent = string_32;
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip,deflate");
				httpWebRequest.ContentLength = bytes.Length;
				httpWebRequest.ContentType = "application/json";
				httpWebRequest.ServicePoint.Expect100Continue = true;
				httpWebRequest.ServicePoint.Expect100Continue = false;
				httpWebRequest.Headers["Cache-Control"] = "no-cache";
				httpWebRequest.Headers["X-Kony-Authorizationn"] = authServiceResponse_0.claims_token.value;
				httpWebRequest.Headers["X-Kony-API-Version"] = string_10;
				using (Stream stream = httpWebRequest.GetRequestStream())
				{
					stream.Write(bytes, 0, bytes.Length);
					stream.Close();
				}
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				Stream responseStream = httpWebResponse.GetResponseStream();
				string text3 = new StreamReader(responseStream).ReadToEnd();
				Console.WriteLine("Response for secureLoginServiceRequest request\n{0}", text3);
				responseStream.Close();
				if (httpWebResponse.StatusCode == HttpStatusCode.OK)
				{
					baseResponseBody = JsonConvert.DeserializeObject<BaseResponseBody>(text3);
					if (!(baseResponseBody.code != "null") && baseResponseBody.encData != null && baseResponseBody.status != null && baseResponseBody.httpStatusCode == 200)
					{
						break;
					}
				}
			}
			loginValidateResponseBody_1 = JsonConvert.DeserializeObject<LoginValidateResponseBody>(Class0.smethod_2(baseResponseBody.encData, string_36, string_30, enableHighSecurityConfirmServiceResponseBody_0.mobAppKey));
			Console.WriteLine(JsonConvert.SerializeObject(loginValidateResponseBody_1));
			if (loginValidateResponseBody_1.status)
			{
				loginValidateResponseBody_0.jSessionId = loginValidateResponseBody_1.jSessionId;
				loginValidateResponseBody_0.uId = loginValidateResponseBody_1.uId;
			}
		}

		public string method_9()
		{
			BaseResponseBody baseResponseBody;
			while (true)
			{
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				string text = string_4 + string_29;
				Console.WriteLine(text);
				Dictionary<string, string> dictionary = new Dictionary<string, string> { { "optionalFlagFomUI", "false" } };
				Header value = new Header
				{
					bankCode = "0",
					token = "",
					userName = string_36
				};
				Console.WriteLine(JsonConvert.SerializeObject(value));
				dictionary.Add("header", Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value))));
				BaseRequestBody baseRequestBody = new BaseRequestBody();
				baseRequestBody.body = new Body();
				baseRequestBody.body.secretKey = enableHighSecurityConfirmServiceResponseBody_0.securityKey;
				baseRequestBody.security = new Security();
				baseRequestBody.security.appkey = enableHighSecurityConfirmServiceResponseBody_0.mobAppKey;
				baseRequestBody.security.mpin = string_30;
				baseRequestBody.security.token1 = loginValidateResponseBody_0.jSessionId;
				baseRequestBody.security.token2 = loginValidateResponseBody_0.uId;
				Console.WriteLine(JsonConvert.SerializeObject(baseRequestBody));
				dictionary.Add("encData", Class0.smethod_0(JsonConvert.SerializeObject(baseRequestBody), string_36, string_30, enableHighSecurityConfirmServiceResponseBody_0.mobAppKey));
				dictionary.Add("requestKey", Class0.smethod_7(JsonConvert.SerializeObject(baseRequestBody)));
				dictionary.Add("appID", string_11);
				dictionary.Add("appver", string_13);
				dictionary.Add("channel", string_14);
				dictionary.Add("platform", string_8);
				dictionary.Add("cacheid", "");
				string value2 = method_12("frmLandingPageNew", "FetchOnlineOTP");
				string text2 = method_13(dictionary);
				Console.WriteLine(text2);
				byte[] bytes = Encoding.UTF8.GetBytes(text2);
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
				httpWebRequest.CookieContainer = cookieContainer_0;
				if (bool_0)
				{
					httpWebRequest.Proxy = new WebProxy("127.0.0.1", 8888);
				}
				else if (!string.IsNullOrEmpty(string_39))
				{
					httpWebRequest.Proxy = new WebProxy($"{string_39}:{int_1}", BypassOnLocal: true, null, new NetworkCredential(string_40, string_41));
				}
				httpWebRequest.Method = "POST";
				httpWebRequest.ReadWriteTimeout = 5000;
				httpWebRequest.KeepAlive = true;
				httpWebRequest.UserAgent = string_32;
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip,deflate");
				httpWebRequest.ContentLength = bytes.Length;
				httpWebRequest.ContentType = "application/json";
				httpWebRequest.ServicePoint.Expect100Continue = true;
				httpWebRequest.Headers["X-Kony-ReportingParams"] = value2;
				httpWebRequest.Headers["Cache-Control"] = "no-cache";
				httpWebRequest.Headers["X-Kony-Authorizationn"] = authServiceResponse_0.claims_token.value;
				httpWebRequest.Headers["X-Kony-API-Version"] = string_10;
				using (Stream stream = httpWebRequest.GetRequestStream())
				{
					stream.Write(bytes, 0, bytes.Length);
					stream.Close();
				}
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				Stream responseStream = httpWebResponse.GetResponseStream();
				string text3 = new StreamReader(responseStream).ReadToEnd();
				Console.WriteLine("Response for fetchOnlineOTPRequest request\n{0}", text3);
				responseStream.Close();
				if (httpWebResponse.StatusCode == HttpStatusCode.OK)
				{
					baseResponseBody = JsonConvert.DeserializeObject<BaseResponseBody>(text3);
					if (!(baseResponseBody.code != "null") && baseResponseBody.encData != null && baseResponseBody.status != null && baseResponseBody.httpStatusCode == 200)
					{
						break;
					}
				}
			}
			return Class0.smethod_2(baseResponseBody.encData, string_36, string_30, enableHighSecurityConfirmServiceResponseBody_0.mobAppKey);
		}

		private DateTime getIndiaDateTime()
		{
			DateTime dateTime = DateTime.Now.ToUniversalTime();
			TimeZoneInfo destinationTimeZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
			return TimeZoneInfo.ConvertTimeFromUtc(dateTime, destinationTimeZone);
		}

		public string getSmsText(string sbiPaymentRequest)
		{
			string text = string.Format("{0}#{1}#{2}", "1", sbiPaymentRequest, "1");
			Console.WriteLine("Plain SMS " + text);
			text = SBISecureCrypt.SHA512(text);
			Console.WriteLine(text);
			text = string.Format("{0}#{1}#{2}", text, SECRET_KEY, getIndiaDateTime().ToString("ddd MMM dd yyyy HHmmss \"GMT\"zzz", CultureInfo.CreateSpecificCulture("en-US")).Replace(",", "").Replace(":", "")
				.Replace("+", ""));
			Console.WriteLine(text);
			return SBISecureCrypt.SHA512(text);
		}

		public string method_10()
		{
			string result = messagetxt;
			try
			{
				string plainText = string_4 + string_28 + "||##||" + currentdate;
				plainText = EncryptDataWithAes(plainText);
				plainText = "base64=" + plainText;
			}
			catch (WebException)
			{
			}
			return result;
		}

		private static string DecryptDataWithAes(string cipherText, string keyBase64)
		{
			using Aes aes = Aes.Create();
			aes.Key = Encoding.UTF8.GetBytes(keyBase64);
			aes.IV = new byte[16];
			Console.WriteLine($"Aes Cipher Mode : {aes.Mode}");
			Console.WriteLine($"Aes Padding Mode: {aes.Padding}");
			Console.WriteLine($"Aes Key Size : {aes.KeySize}");
			Console.WriteLine($"Aes Block Size : {aes.BlockSize}");
			ICryptoTransform transform = aes.CreateDecryptor();
			byte[] buffer = Convert.FromBase64String(cipherText);
			using MemoryStream stream = new MemoryStream(buffer);
			using CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
			using StreamReader streamReader = new StreamReader(stream2);
			return streamReader.ReadToEnd();
		}

		public static string EncryptDataWithAes(string plainText)
		{
			using Aes aes = Aes.Create();
			Console.WriteLine($"Aes Cipher Mode : {aes.Mode}");
			Console.WriteLine($"Aes Padding Mode: {aes.Padding}");
			Console.WriteLine($"Aes Key Size : {aes.KeySize}");
			Console.WriteLine($"Aes Block Size : {aes.BlockSize}");
			aes.Key = Encoding.UTF8.GetBytes("b14ca4040a4e4133bbce2ea2315a1000");
			byte[] iV = new byte[16];
			aes.IV = iV;
			ICryptoTransform transform = aes.CreateEncryptor();
			byte[] inArray;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using CryptoStream stream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
				using (StreamWriter streamWriter = new StreamWriter(stream))
				{
					streamWriter.Write(plainText);
				}
				inArray = memoryStream.ToArray();
			}
			return Convert.ToBase64String(inArray);
		}

		private static string GenerateOTP(string secretKey, string dateTimeStr)
		{
			DateTime dateTime = DateTime.ParseExact(dateTimeStr, "MM/dd/yyyy HH:mm:ss", null);
			string s = secretKey + (long)(dateTime - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			using SHA512 sHA = SHA512.Create();
			byte[] array = sHA.ComputeHash(bytes);
			StringBuilder stringBuilder = new StringBuilder();
			byte[] array2 = array;
			byte[] array3 = array2;
			byte[] array4 = array3;
			byte[] array5 = array4;
			foreach (byte b in array5)
			{
				stringBuilder.Append(b.ToString("x2"));
			}
			return stringBuilder.ToString();
		}

		private string myMethod(int length)
		{
			StringBuilder stringBuilder = new StringBuilder();
			while (stringBuilder.Length < length)
			{
				stringBuilder.Append(Guid.NewGuid().ToString().Replace("-", ""));
			}
			return stringBuilder.ToString(0, length);
		}

		internal string RandomString(int int_28, string string_86)
		{
			char[] array = new char[int_28];
			Random random = new Random();
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = string_86[random.Next(string_86.Length)];
			}
			return new string(array);
		}

		private DateTime method_11()
		{
			DateTime dateTime = DateTime.Now.ToUniversalTime();
			TimeZoneInfo destinationTimeZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
			return TimeZoneInfo.ConvertTimeFromUtc(dateTime, destinationTimeZone);
		}

		private string method_12(string string_42, string string_43)
		{
			string text = JsonConvert.SerializeObject(new ReportParams
			{
				os = "22",
				dm = string_31,
				did = string_30,
				ua = string_31,
				aid = "OnlineOTP",
				aname = "SBI Secure OTP",
				chnl = "mobile",
				plat = "android",
				aver = "3.2.0",
				atype = "native",
				stype = "b2c",
				kuid = "",
				mfaid = string_15,
				mfbaseid = string_16,
				mfaname = "SBISmartOTPChe",
				sdkversion = "8.4.147",
				sdktype = "js",
				fid = string_42,
				sessiontype = "I",
				rsid = string_18,
				svcid = string_43
			});
			Console.WriteLine(text);
			return HttpUtility.UrlEncode(text);
		}

		private string method_13(Dictionary<string, string> dictionary_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (KeyValuePair<string, string> item in dictionary_0)
			{
				stringBuilder.Append(Class0.smethod_11(item.Key, Encoding.UTF8)).Append("=").Append(Class0.smethod_11(item.Value, Encoding.UTF8))
					.Append("&");
			}
			return stringBuilder.Remove(stringBuilder.Length - 1, 1).ToString();
		}

		public static void smethod_0(string string_42, object object_2)
		{
			string contents = JsonConvert.SerializeObject(object_2, Formatting.Indented);
			File.WriteAllText(string_42, contents);
		}

		public static Class1 smethod_1(string string_42)
		{
			return JsonConvert.DeserializeObject<Class1>(File.ReadAllText(string_42));
		}

		static Class1()
		{
			SECRET_KEY = "daf225199b408bdd641d8a8d4e8136c3900c37e1705853b9517a6393aab9b7eaccf1bc8763dabbcf08dd8af07c362774a9ccfe8494f7dcda8c6981d6950428f0";
			string_0 = "c8f4a4536cabfe8233d8d234d005d93e6a91702853cb2d93cb3c846e7ac6c322";
			string_1 = "daf225199b408bdd641d8a8d4e8136c3900c37e1705853b9517a6393aab9b7eaccf1bc8763dabbcf08dd8af07c362774a9ccfe8494f7dcda8c6981d6950428f0";
			string_2 = "$652@!#*SaWeQ@";
			string_3 = "$*|@%$B!$E@u^#@A%!";
			string_4 = "https://api.yonobusinessmobile.sbi";
			int_0 = 443;
			string_5 = "a4fbd0c9fc874ff7cfb70a04681e8340";
			string_6 = "a1c3fd7b48a0baa353b10f43cb3df3cc";
			string_7 = "8.4.147";
			string_8 = "android";
			string_9 = "js";
			string_10 = "1.0";
			string_11 = "OnlineOTP";
			string_12 = "SBI Secure OTP";
			string_13 = "3.2.0";
			string_14 = "rc";
			string_15 = "93483612-56bd-4eea-a1d4-b512b4cc1fb2";
			string_16 = "b8e9763f-9194-4962-92c9-34df58dc3e3c";
			string_17 = "SBISmartOTPChe";
			string_18 = "1705923871854-ac2a-583f-39d0";
			string_19 = "+917304459011";
			string_20 = "/authService/100000002/login";
			string_21 = "/services1/SBISmartOTPCheService1/FetchDateTime";
			string_22 = "/services1/SBISmartOTPCheService1/SecurityService";
			string_23 = "/services1/SBISmartOTPCheService1/LoginValidate";
			string_24 = "/services1/SBISmartOTPCheService1/EnableHighSecurityOTPService";
			string_25 = "/services1/SBISmartOTPCheService1/EnableHighSecurityConfirmService";
			string_26 = "/services1/SBISmartOTPCheService1/RegisterConfirmService";
			string_27 = "/services1/SBISmartOTPCheService1/SmartSecService";
			string_28 = "/services1/SBISmartOTPCheService1/SecureLoginService";
			string_29 = "/services1/SBISmartOTPCheService1/FetchOnlineOTP";
		}
	}

	private class Class2
	{
		private static Random random_0;

		public static bool smethod_0(string string_0)
		{
			if (string_0 != null && string_0.Length != 0)
			{
				return false;
			}
			return true;
		}

		public static char smethod_1()
		{
			char[] array = "QWERTYUIOPASDFGHJKLZXCVBNM".ToCharArray();
			return array[random_0.Next(array.Length)];
		}

		public static int smethod_2()
		{
			int[] array = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			return array[random_0.Next(array.Length)];
		}

		public static long smethod_3(int int_0)
		{
			int[] array = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			long num = 0L;
			for (int i = 0; i < int_0; i++)
			{
				num += (long)Math.Pow(10.0, i) * array[random_0.Next(array.Length)];
			}
			return num;
		}

		public static string smethod_4(int int_0)
		{
			char[] array = new char[int_0];
			string text = "abcdefghijklmnopqrstuvwxyz0123456789";
			for (int i = 0; i < int_0; i++)
			{
				array[i] = text[random_0.Next((i == 0) ? "abcdefghijklmnopqrstuvwxyz".Length : text.Length)];
			}
			return new string(array);
		}

		public static string smethod_5(int int_0)
		{
			char[] array = new char[int_0];
			string text = "QAZWSXEDCRFVTGBYHNUJMIKOLP0123456789";
			for (int i = 0; i < int_0; i++)
			{
				array[i] = text[random_0.Next(text.Length)];
			}
			return new string(array);
		}

		public static string smethod_6(int int_0)
		{
			char[] array = new char[int_0];
			string text = "qazwsxedcrfvtgbyhnujmikolpQAZWSXEDCRFVTGBYHNUJMIKOLP0123456789";
			for (int i = 0; i < int_0; i++)
			{
				array[i] = text[random_0.Next(text.Length)];
			}
			return new string(array);
		}

		public static string smethod_7(int int_0)
		{
			char[] array = new char[int_0];
			string text = "abcdefghijklmnopqrstuvwxyz0123456789";
			for (int i = 0; i < int_0; i++)
			{
				array[i] = text[random_0.Next(text.Length)];
			}
			return new string(array) + smethod_2();
		}

		private static int smethod_8(int int_0, int int_1)
		{
			int[] array = new int[int_1 - int_0 + 1];
			for (int i = int_0; i <= int_1; i++)
			{
				array[i - int_0] = i;
			}
			return array[random_0.Next(array.Length)];
		}

		static Class2()
		{
			random_0 = new Random();
		}
	}

	private class Class3
	{
		private static char[] char_0;

		private static string[] string_0;

		private static string[] string_1;

		private static string[] string_2;

		private static string[] string_3;

		private static Dictionary<string, string> dictionary_0;

		private static Dictionary<string, string> dictionary_1;

		private static Random random_0;

		static Class3()
		{
			char_0 = new char[10] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
			string_0 = new string[10] { "SM-J100H", "U900-Soul", "SGH-N100", "SGH-X510", "GT-I9060", "GT-I8262", "SGH-Z170", "SGH-T408", "SGH-S300", "SM-G925F" };
			string_1 = new string[10] { "35301007", "35599002", "35009791", "35463301", "35559106", "35283806", "35488901", "35106500", "35046790", "35952006" };
			string_2 = new string[13]
			{
				"5.0", "5.0.1", "5.0.2", "5.1", "5.1.1", "6.0", "6.0.1", "7.0", "7.1", "7.1.1",
				"7.1.2", "8.0", "8.1"
			};
			string_3 = new string[13]
			{
				"21", "21", "21", "22", "22", "23", "23", "24", "25", "25",
				"25", "26", "27"
			};
			dictionary_0 = new Dictionary<string, string>();
			dictionary_1 = new Dictionary<string, string>();
			random_0 = new Random();
			for (int i = 0; i < string_0.Length; i++)
			{
				dictionary_0[string_0[i]] = string_1[i];
			}
			for (int j = 0; j < string_2.Length; j++)
			{
				dictionary_1[string_2[j]] = string_3[j];
			}
		}

		public static string smethod_0()
		{
			return string_0[random_0.Next(string_0.Length)];
		}

		public static string smethod_1(object object_0)
		{
			string text = dictionary_0[(string)object_0];
			string text2 = smethod_2();
			string text3 = text + text2;
			int num = 0;
			string text4;
			while (true)
			{
				if (num < char_0.Length)
				{
					text4 = text3 + char_0[num];
					if (Check(text4))
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return text4;
		}

		private static string smethod_2()
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < 6; i++)
			{
				stringBuilder.Append(char_0[random_0.Next(char_0.Length)]);
			}
			return stringBuilder.ToString();
		}

		public static bool Check(string ccNumber)
		{
			int num = 0;
			bool flag = false;
			for (int num2 = ccNumber.Length - 1; num2 >= 0; num2--)
			{
				int num3 = int.Parse(ccNumber.Substring(num2, 1));
				if (flag)
				{
					num3 *= 2;
					if (num3 > 9)
					{
						num3 = num3 % 10 + 1;
					}
				}
				num += num3;
				flag = !flag;
			}
			return num % 10 == 0;
		}

		public static string smethod_3()
		{
			return Guid.NewGuid().ToString().Replace("-", "")
				.Substring(0, 16);
		}

		public static string smethod_4()
		{
			return "samsung";
		}

		public static string smethod_5()
		{
			return smethod_6() + smethod_6() + smethod_6() + "/" + smethod_6() + smethod_7() + smethod_6() + smethod_6();
		}

		public static char smethod_6()
		{
			char[] array = "QWERTYUIOPASDFGHJKLZXCVBNM".ToCharArray();
			return array[random_0.Next(array.Length)];
		}

		public static int smethod_7()
		{
			int[] array = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			return array[random_0.Next(array.Length)];
		}

		public static string smethod_8()
		{
			return $"{smethod_7()}{smethod_6()}{smethod_6()}.{smethod_6()}{smethod_7()}{smethod_7()}{smethod_7()}{smethod_7()} release-keys";
		}

		public static string smethod_9()
		{
			return $"Mozilla/5.0 (Linux; Android {smethod_10()}; {smethod_0()} Build/{smethod_6()}{smethod_6()}B{smethod_7()}{smethod_7()}M; wv) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/59.0.3071.125 Safari/537.36";
		}

		public static string smethod_10()
		{
			return string_2[random_0.Next(string_2.Length)];
		}

		public static string smethod_11(string string_4)
		{
			int i;
			for (i = 0; i < string_2.Length && !string_2[i].Equals(string_4); i++)
			{
			}
			return string_3[i];
		}

		public static string smethod_12()
		{
			string text = "c_HgNKaAFHE:APA91bHO4OIMgJEuLHoN-KSNuIrbuHnzTmvp2PpqFSQ5FVtrY3ukGkH3WtEfMc74DMtGDynu0U9LOHiHIwMNAv8T_CdE_Wer-sfGnqyrOPBr9xCkOxsW6sceze8WreFIRr_GGxHeLN6I";
			return Class2.smethod_6("c_HgNKaAFHE".Length) + ":" + text.Substring("c_HgNKaAFHE:".Length, "APA91bHO4OIMgJEuLHoN-KSNuIrbuHnzTmvp2PpqFSQ5FVtrY3ukGkH3WtEfMc74DMtGDynu0U9LOHiHIwMNAv8T_CdE_Wer-".Length) + Class2.smethod_6("sfGnqyrOPBr9xCkOxsW6sceze8WreFIRr".Length) + "_" + Class2.smethod_6("GGxHeLN6I".Length);
		}

		public static string smethod_13()
		{
			long num = Math.Abs(random_0.NextLong(1152921504606846976L, long.MaxValue));
			return $"{num:x16}";
		}
	}

	public class AuthServiceResponse
	{
		[CompilerGenerated]
		private Claims_Token claims_Token_0;

		[CompilerGenerated]
		private string string_0;

		public Claims_Token claims_token
		{
			[CompilerGenerated]
			get
			{
				return claims_Token_0;
			}
			[CompilerGenerated]
			set
			{
				claims_Token_0 = value;
			}
		}

		public string refresh_token
		{
			[CompilerGenerated]
			get
			{
				return string_0;
			}
			[CompilerGenerated]
			set
			{
				string_0 = value;
			}
		}
	}

	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class Claims_Token
	{
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private long long_0;

		public string value
		{
			[CompilerGenerated]
			get
			{
				return string_0;
			}
			[CompilerGenerated]
			set
			{
				string_0 = value;
			}
		}

		public long exp
		{
			[CompilerGenerated]
			get
			{
				return long_0;
			}
			[CompilerGenerated]
			set
			{
				long_0 = value;
			}
		}
	}

	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class BaseRequestBody
	{
		[CompilerGenerated]
		private Body body_0;

		[CompilerGenerated]
		private Security security_0;

		public Body body
		{
			[CompilerGenerated]
			get
			{
				return body_0;
			}
			[CompilerGenerated]
			set
			{
				body_0 = value;
			}
		}

		public Security security
		{
			[CompilerGenerated]
			get
			{
				return security_0;
			}
			[CompilerGenerated]
			set
			{
				security_0 = value;
			}
		}
	}

	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class Body
	{
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private string string_1;

		[CompilerGenerated]
		private string string_2;

		[CompilerGenerated]
		private string string_3;

		[CompilerGenerated]
		private string string_4;

		[CompilerGenerated]
		private string string_5;

		[CompilerGenerated]
		private string string_6;

		[CompilerGenerated]
		private string string_7;

		[CompilerGenerated]
		private string string_8;

		[CompilerGenerated]
		private string string_9;

		[CompilerGenerated]
		private string string_10;

		[CompilerGenerated]
		private string string_11;

		[CompilerGenerated]
		private string string_12;

		[CompilerGenerated]
		private string string_13;

		[CompilerGenerated]
		private string string_14;

		[CompilerGenerated]
		private string string_15;

		[CompilerGenerated]
		private string string_16;

		public string md5Password
		{
			[CompilerGenerated]
			get
			{
				return string_0;
			}
			[CompilerGenerated]
			set
			{
				string_0 = value;
			}
		}

		public string shaPassword
		{
			[CompilerGenerated]
			get
			{
				return string_1;
			}
			[CompilerGenerated]
			set
			{
				string_1 = value;
			}
		}

		public string serviceId
		{
			[CompilerGenerated]
			get
			{
				return string_2;
			}
			[CompilerGenerated]
			set
			{
				string_2 = value;
			}
		}

		public string deviceName
		{
			[CompilerGenerated]
			get
			{
				return string_3;
			}
			[CompilerGenerated]
			set
			{
				string_3 = value;
			}
		}

		public string imeiNo
		{
			[CompilerGenerated]
			get
			{
				return string_4;
			}
			[CompilerGenerated]
			set
			{
				string_4 = value;
			}
		}

		public string osName
		{
			[CompilerGenerated]
			get
			{
				return string_5;
			}
			[CompilerGenerated]
			set
			{
				string_5 = value;
			}
		}

		public string mobileAppVersion
		{
			[CompilerGenerated]
			get
			{
				return string_6;
			}
			[CompilerGenerated]
			set
			{
				string_6 = value;
			}
		}

		public string oSversion
		{
			[CompilerGenerated]
			get
			{
				return string_7;
			}
			[CompilerGenerated]
			set
			{
				string_7 = value;
			}
		}

		public string encKeyValue
		{
			[CompilerGenerated]
			get
			{
				return string_8;
			}
			[CompilerGenerated]
			set
			{
				string_8 = value;
			}
		}

		public string currentDate
		{
			[CompilerGenerated]
			get
			{
				return string_9;
			}
			[CompilerGenerated]
			set
			{
				string_9 = value;
			}
		}

		public string deviceId
		{
			[CompilerGenerated]
			get
			{
				return string_10;
			}
			[CompilerGenerated]
			set
			{
				string_10 = value;
			}
		}

		public string otp
		{
			[CompilerGenerated]
			get
			{
				return string_11;
			}
			[CompilerGenerated]
			set
			{
				string_11 = value;
			}
		}

		public string secretKey
		{
			[CompilerGenerated]
			get
			{
				return string_12;
			}
			[CompilerGenerated]
			set
			{
				string_12 = value;
			}
		}

		public string shaMpin
		{
			[CompilerGenerated]
			get
			{
				return string_13;
			}
			[CompilerGenerated]
			set
			{
				string_13 = value;
			}
		}

		public string securityKey
		{
			[CompilerGenerated]
			get
			{
				return string_14;
			}
			[CompilerGenerated]
			set
			{
				string_14 = value;
			}
		}

		public string answer
		{
			[CompilerGenerated]
			get
			{
				return string_15;
			}
			[CompilerGenerated]
			set
			{
				string_15 = value;
			}
		}

		public string question
		{
			[CompilerGenerated]
			get
			{
				return string_16;
			}
			[CompilerGenerated]
			set
			{
				string_16 = value;
			}
		}
	}

	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class Security
	{
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private string string_1;

		[CompilerGenerated]
		private string string_2;

		[CompilerGenerated]
		private string string_3;

		public string appkey
		{
			[CompilerGenerated]
			get
			{
				return string_0;
			}
			[CompilerGenerated]
			set
			{
				string_0 = value;
			}
		}

		public string mpin
		{
			[CompilerGenerated]
			get
			{
				return string_1;
			}
			[CompilerGenerated]
			set
			{
				string_1 = value;
			}
		}

		public string token1
		{
			[CompilerGenerated]
			get
			{
				return string_2;
			}
			[CompilerGenerated]
			set
			{
				string_2 = value;
			}
		}

		public string token2
		{
			[CompilerGenerated]
			get
			{
				return string_3;
			}
			[CompilerGenerated]
			set
			{
				string_3 = value;
			}
		}
	}

	public class BaseResponseBody
	{
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private string string_1;

		[CompilerGenerated]
		private int int_0;

		[CompilerGenerated]
		private string string_2;

		[CompilerGenerated]
		private int int_1;

		public string code
		{
			[CompilerGenerated]
			get
			{
				return string_0;
			}
			[CompilerGenerated]
			set
			{
				string_0 = value;
			}
		}

		public string encData
		{
			[CompilerGenerated]
			get
			{
				return string_1;
			}
			[CompilerGenerated]
			set
			{
				string_1 = value;
			}
		}

		public int opstatus
		{
			[CompilerGenerated]
			get
			{
				return int_0;
			}
			[CompilerGenerated]
			set
			{
				int_0 = value;
			}
		}

		public string status
		{
			[CompilerGenerated]
			get
			{
				return string_2;
			}
			[CompilerGenerated]
			set
			{
				string_2 = value;
			}
		}

		public int httpStatusCode
		{
			[CompilerGenerated]
			get
			{
				return int_1;
			}
			[CompilerGenerated]
			set
			{
				int_1 = value;
			}
		}
	}

	public class EnableHighSecurityConfirmServiceResponseBody
	{
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private string string_1;

		[CompilerGenerated]
		private bool bool_0;

		[CompilerGenerated]
		private string string_2;

		[CompilerGenerated]
		private string string_3;

		public string uId
		{
			[CompilerGenerated]
			get
			{
				return string_0;
			}
			[CompilerGenerated]
			set
			{
				string_0 = value;
			}
		}

		public string jSessionId
		{
			[CompilerGenerated]
			get
			{
				return string_1;
			}
			[CompilerGenerated]
			set
			{
				string_1 = value;
			}
		}

		public bool Boolean_0
		{
			[CompilerGenerated]
			get
			{
				return bool_0;
			}
			[CompilerGenerated]
			set
			{
				bool_0 = value;
			}
		}

		public string securityKey
		{
			[CompilerGenerated]
			get
			{
				return string_2;
			}
			[CompilerGenerated]
			set
			{
				string_2 = value;
			}
		}

		public string mobAppKey
		{
			[CompilerGenerated]
			get
			{
				return string_3;
			}
			[CompilerGenerated]
			set
			{
				string_3 = value;
			}
		}
	}

	public class EnableHighSecurityServiceResponseBody
	{
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private string string_1;

		[CompilerGenerated]
		private bool bool_0;

		[CompilerGenerated]
		private string string_2;

		public string uId
		{
			[CompilerGenerated]
			get
			{
				return string_0;
			}
			[CompilerGenerated]
			set
			{
				string_0 = value;
			}
		}

		public string jSessionId
		{
			[CompilerGenerated]
			get
			{
				return string_1;
			}
			[CompilerGenerated]
			set
			{
				string_1 = value;
			}
		}

		public bool isSecureUser
		{
			[CompilerGenerated]
			get
			{
				return bool_0;
			}
			[CompilerGenerated]
			set
			{
				bool_0 = value;
			}
		}

		public string status
		{
			[CompilerGenerated]
			get
			{
				return string_2;
			}
			[CompilerGenerated]
			set
			{
				string_2 = value;
			}
		}
	}

	public class FetchDateTimeResponseBody
	{
		[CompilerGenerated]
		private string string_0;

		public string currentDate
		{
			[CompilerGenerated]
			get
			{
				return string_0;
			}
			[CompilerGenerated]
			set
			{
				string_0 = value;
			}
		}
	}

	public class Header
	{
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private string string_1;

		[CompilerGenerated]
		private string string_2;

		public string userName
		{
			[CompilerGenerated]
			get
			{
				return string_0;
			}
			[CompilerGenerated]
			set
			{
				string_0 = value;
			}
		}

		public string bankCode
		{
			[CompilerGenerated]
			get
			{
				return string_1;
			}
			[CompilerGenerated]
			set
			{
				string_1 = value;
			}
		}

		public string token
		{
			[CompilerGenerated]
			get
			{
				return string_2;
			}
			[CompilerGenerated]
			set
			{
				string_2 = value;
			}
		}
	}

	public class LoginValidateResponseBody
	{
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private string string_1;

		[CompilerGenerated]
		private string string_2;

		[CompilerGenerated]
		private string string_3;

		[CompilerGenerated]
		private string string_4;

		[CompilerGenerated]
		private string string_5;

		[CompilerGenerated]
		private object object_0;

		[CompilerGenerated]
		private string string_6;

		[CompilerGenerated]
		private string string_7;

		[CompilerGenerated]
		private string string_8;

		[CompilerGenerated]
		private bool bool_0;

		public string uId
		{
			[CompilerGenerated]
			get
			{
				return string_0;
			}
			[CompilerGenerated]
			set
			{
				string_0 = value;
			}
		}

		public string jSessionId
		{
			[CompilerGenerated]
			get
			{
				return string_1;
			}
			[CompilerGenerated]
			set
			{
				string_1 = value;
			}
		}

		public string displayName
		{
			[CompilerGenerated]
			get
			{
				return string_2;
			}
			[CompilerGenerated]
			set
			{
				string_2 = value;
			}
		}

		public string systemDate
		{
			[CompilerGenerated]
			get
			{
				return string_3;
			}
			[CompilerGenerated]
			set
			{
				string_3 = value;
			}
		}

		public string errorCode
		{
			[CompilerGenerated]
			get
			{
				return string_4;
			}
			[CompilerGenerated]
			set
			{
				string_4 = value;
			}
		}

		public string keyId
		{
			[CompilerGenerated]
			get
			{
				return string_5;
			}
			[CompilerGenerated]
			set
			{
				string_5 = value;
			}
		}

		public object promoMessage
		{
			[CompilerGenerated]
			get
			{
				return object_0;
			}
			[CompilerGenerated]
			set
			{
				object_0 = value;
			}
		}

		public string lastLoginDate
		{
			[CompilerGenerated]
			get
			{
				return string_6;
			}
			[CompilerGenerated]
			set
			{
				string_6 = value;
			}
		}

		public string serviceId
		{
			[CompilerGenerated]
			get
			{
				return string_7;
			}
			[CompilerGenerated]
			set
			{
				string_7 = value;
			}
		}

		public string userName
		{
			[CompilerGenerated]
			get
			{
				return string_8;
			}
			[CompilerGenerated]
			set
			{
				string_8 = value;
			}
		}

		public bool status
		{
			[CompilerGenerated]
			get
			{
				return bool_0;
			}
			[CompilerGenerated]
			set
			{
				bool_0 = value;
			}
		}
	}

	public class QuestionSubmitServiceResponseBody
	{
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private string string_1;

		[CompilerGenerated]
		private string string_2;

		[CompilerGenerated]
		private string string_3;

		[CompilerGenerated]
		private string string_4;

		public string errorCode
		{
			[CompilerGenerated]
			get
			{
				return string_0;
			}
			[CompilerGenerated]
			set
			{
				string_0 = value;
			}
		}

		public string maxUserCount
		{
			[CompilerGenerated]
			get
			{
				return string_1;
			}
			[CompilerGenerated]
			set
			{
				string_1 = value;
			}
		}

		public string userType
		{
			[CompilerGenerated]
			get
			{
				return string_2;
			}
			[CompilerGenerated]
			set
			{
				string_2 = value;
			}
		}

		public string errorMsg
		{
			[CompilerGenerated]
			get
			{
				return string_3;
			}
			[CompilerGenerated]
			set
			{
				string_3 = value;
			}
		}

		public string status
		{
			[CompilerGenerated]
			get
			{
				return string_4;
			}
			[CompilerGenerated]
			set
			{
				string_4 = value;
			}
		}
	}

	public class ReportParams
	{
		internal string sessiontype;

		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private string string_1;

		[CompilerGenerated]
		private string string_2;

		[CompilerGenerated]
		private string string_3;

		[CompilerGenerated]
		private string string_4;

		[CompilerGenerated]
		private string string_5;

		[CompilerGenerated]
		private string string_6;

		[CompilerGenerated]
		private string string_7;

		[CompilerGenerated]
		private string string_8;

		[CompilerGenerated]
		private string string_9;

		[CompilerGenerated]
		private string string_10;

		[CompilerGenerated]
		private string string_11;

		[CompilerGenerated]
		private string string_12;

		[CompilerGenerated]
		private string string_13;

		[CompilerGenerated]
		private string string_14;

		[CompilerGenerated]
		private string string_15;

		[CompilerGenerated]
		private string string_16;

		[CompilerGenerated]
		private string string_17;

		[CompilerGenerated]
		private string string_18;

		[CompilerGenerated]
		private string string_19;

		public string os
		{
			[CompilerGenerated]
			get
			{
				return string_0;
			}
			[CompilerGenerated]
			set
			{
				string_0 = value;
			}
		}

		public string dm
		{
			[CompilerGenerated]
			get
			{
				return string_1;
			}
			[CompilerGenerated]
			set
			{
				string_1 = value;
			}
		}

		public string did
		{
			[CompilerGenerated]
			get
			{
				return string_2;
			}
			[CompilerGenerated]
			set
			{
				string_2 = value;
			}
		}

		public string ua
		{
			[CompilerGenerated]
			get
			{
				return string_3;
			}
			[CompilerGenerated]
			set
			{
				string_3 = value;
			}
		}

		public string aid
		{
			[CompilerGenerated]
			get
			{
				return string_4;
			}
			[CompilerGenerated]
			set
			{
				string_4 = value;
			}
		}

		public string aname
		{
			[CompilerGenerated]
			get
			{
				return string_5;
			}
			[CompilerGenerated]
			set
			{
				string_5 = value;
			}
		}

		public string chnl
		{
			[CompilerGenerated]
			get
			{
				return string_6;
			}
			[CompilerGenerated]
			set
			{
				string_6 = value;
			}
		}

		public string plat
		{
			[CompilerGenerated]
			get
			{
				return string_7;
			}
			[CompilerGenerated]
			set
			{
				string_7 = value;
			}
		}

		public string aver
		{
			[CompilerGenerated]
			get
			{
				return string_8;
			}
			[CompilerGenerated]
			set
			{
				string_8 = value;
			}
		}

		public string atype
		{
			[CompilerGenerated]
			get
			{
				return string_9;
			}
			[CompilerGenerated]
			set
			{
				string_9 = value;
			}
		}

		public string stype
		{
			[CompilerGenerated]
			get
			{
				return string_10;
			}
			[CompilerGenerated]
			set
			{
				string_10 = value;
			}
		}

		public string kuid
		{
			[CompilerGenerated]
			get
			{
				return string_11;
			}
			[CompilerGenerated]
			set
			{
				string_11 = value;
			}
		}

		public string mfaid
		{
			[CompilerGenerated]
			get
			{
				return string_12;
			}
			[CompilerGenerated]
			set
			{
				string_12 = value;
			}
		}

		public string mfbaseid
		{
			[CompilerGenerated]
			get
			{
				return string_13;
			}
			[CompilerGenerated]
			set
			{
				string_13 = value;
			}
		}

		public string mfaname
		{
			[CompilerGenerated]
			get
			{
				return string_14;
			}
			[CompilerGenerated]
			set
			{
				string_14 = value;
			}
		}

		public string sdkversion
		{
			[CompilerGenerated]
			get
			{
				return string_15;
			}
			[CompilerGenerated]
			set
			{
				string_15 = value;
			}
		}

		public string sdktype
		{
			[CompilerGenerated]
			get
			{
				return string_16;
			}
			[CompilerGenerated]
			set
			{
				string_16 = value;
			}
		}

		public string fid
		{
			[CompilerGenerated]
			get
			{
				return string_17;
			}
			[CompilerGenerated]
			set
			{
				string_17 = value;
			}
		}

		public string rsid
		{
			[CompilerGenerated]
			get
			{
				return string_18;
			}
			[CompilerGenerated]
			set
			{
				string_18 = value;
			}
		}

		public string svcid
		{
			[CompilerGenerated]
			get
			{
				return string_19;
			}
			[CompilerGenerated]
			set
			{
				string_19 = value;
			}
		}
	}

	public class SecurityServiceResponseBody
	{
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private string string_1;

		public string keyId
		{
			[CompilerGenerated]
			get
			{
				return string_0;
			}
			[CompilerGenerated]
			set
			{
				string_0 = value;
			}
		}

		public string serviceId
		{
			[CompilerGenerated]
			get
			{
				return string_1;
			}
			[CompilerGenerated]
			set
			{
				string_1 = value;
			}
		}
	}

	private Dictionary<string, string> dictionary_0;

	private Class1 class1_0;

	private string qiTywGsEe;

	[CompilerGenerated]
	private string string_0;

	private IContainer icontainer_0;

	private ComboBox cmbBanks1;

	private Label label1;

	private Panel pnlsms;

	private Panel pnlGenotp;

	private TextBox txtGetotp;

	private Button btnCopy;

	private RichTextBox txtSms;

	private Button btngetotp;

	private Panel pnlOTP;

	private TextBox txtOtp;

	private Button btnSubmitOTP;

	private Button Bypass;

	private Button btnNext;

	private BunifuElipse bunifuElipse_0;

	private Panel pnlHeader;

	private BunifuImageButton btnClose;

	private Label lblinfo;

	private IContainer components;

	private Label label3;

	private Label label4;

	private Label label5;

	private LinkLabel linkLabel1;

	private Label label2;

	public string Path_
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		private set
		{
			string_0 = value;
		}
	}

	[DllImport("dnsapi.dll")]
	private static extern uint DnsFlushResolverCache();

	public frmSBI()
	{
		InitializeComponent();
		pnlHeader.MouseDown += StatClass.Header_MouseDown;
		pnlHeader.MouseMove += StatClass.Header_MouseMove;
		pnlHeader.MouseUp += StatClass.Header_MouseUp;
		ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
	}

	private void frmSBI_Load(object sender, EventArgs e)
	{
		dictionary_0 = new Dictionary<string, string>();
		method_0();
		pnlsms.Visible = false;
		pnlGenotp.Visible = false;
		pnlOTP.Visible = false;
		class1_0 = new Class1();
	}

	private void method_0()
	{
		new DataTable();
		cmbBanks1.Items.Clear();
		cmbBanks1.Items.Add("Select Bank Account");
		Dictionary<string, string> dictionary = Staticm.SBI();
		foreach (string key in dictionary.Keys)
		{
			dictionary_0.Add(key, dictionary[key]);
			cmbBanks1.Items.Add(key);
		}
		cmbBanks1.SelectedIndex = 0;
	}

	private void cmbBanks1_SelectedIndexChanged(object sender, EventArgs e)
	{
		pnlsms.Visible = false;
		pnlGenotp.Visible = false;
		pnlOTP.Visible = false;
		if (cmbBanks1.SelectedIndex > 0)
		{
			qiTywGsEe = cmbBanks1.SelectedItem.ToString();
			string[] array = dictionary_0[qiTywGsEe].Split(new string[1] { "||" }, StringSplitOptions.None);
			class1_0.string_36 = array[0].Trim();
			class1_0.string_37 = array[1];
			string text = "./SBI";
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			Path_ = text + "\\" + qiTywGsEe + ".rg";
			if (!File.Exists(Path_))
			{
				Bypass.Visible = true;
				return;
			}
			pnlGenotp.Visible = true;
			class1_0 = Class1.smethod_1(Path_);
		}
	}

	private void Bypass_Click(object sender, EventArgs e)
	{
		try
		{
			FlushMyCache();
			flushDNS();
		}
		catch
		{
		}
		qiTywGsEe = cmbBanks1.SelectedItem.ToString();
		string[] array = dictionary_0[qiTywGsEe].Split(new string[1] { "||" }, StringSplitOptions.None);
		class1_0.string_36 = array[0].Trim();
		class1_0.string_37 = array[1];
		string text = "./SBI";
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		Path_ = text + "\\" + qiTywGsEe + ".rg";
		if (File.Exists(Path_))
		{
			switch (MessageBox.Show("Your Account Allready Bypass\r\nDo You Want to Delete And Bypass Again", "Bypass Found", MessageBoxButtons.YesNo))
			{
			case DialogResult.Yes:
				File.Delete(Path_);
				break;
			case DialogResult.No:
				return;
			}
		}
		class1_0.method_0();
		class1_0.method_0S();
		class1_0.method_1();
		string string_ = class1_0.method_10();
		class1_0.string_35 = string_;
		txtSms.Text = string_;
		pnlsms.Visible = true;
	}

	public static void FlushMyCache()
	{
		DnsFlushResolverCache();
	}

	private static void flushDNS()
	{
		string text = "/C ipconfig /flushdns";
		try
		{
			Process process = new Process
			{
				StartInfo = new ProcessStartInfo("cmd.exe", text)
			};
			process.Start();
			process.WaitForExit();
			Console.WriteLine("Successfully Flushed DNS:'" + text + "'", EventLogEntryType.Information);
		}
		catch (Exception ex)
		{
			Console.WriteLine("Failed to Flush DNS:'" + text + "' . Error:" + ex.Message, EventLogEntryType.Error);
		}
	}

	private void btnNext_Click(object sender, EventArgs e)
	{
		class1_0.method_2();
		if (!class1_0.method_3().Contains("errorCode\":\"SBS"))
		{
			class1_0.method_4();
			pnlOTP.Visible = true;
		}
		else
		{
			MessageBox.Show("Something wrong! Please close this window and start bypass again \r\n" + class1_0.dataerrormsg);
			Close();
		}
	}

	private void btnCopy_Click(object sender, EventArgs e)
	{
		Clipboard.SetText(txtSms.Text);
	}

	private void btnSubmitOTP_Click(object sender, EventArgs e)
	{
		string string_ = txtOtp.Text.Trim();
		class1_0.method_5(string_);
		string string_2 = "6826";
		string text = class1_0.method_6(string_2);
		string contents = JsonConvert.SerializeObject(class1_0, Formatting.Indented);
		File.WriteAllText(Path_, contents);
		if (text.Contains("success"))
		{
			MessageBox.Show("*********Dhyan se Padh*********\r\nBypass ka ek step Sucessfull ho gaya kripya dusra step follow kare.\r\n Complete Browser steps...\r\n apke phone par ek SBI SECURE Activation code aya hoga use ap apne netbanking login par jaakr , profile , highsecurity option me ye otp enter kare.");
			label2.Left = 5;
			Bypass.Visible = false;
			Close();
		}
	}

	private void btngetotp_Click(object sender, EventArgs e)
	{
		try
		{
			FlushMyCache();
			flushDNS();
		}
		catch
		{
		}
		class1_0.method_0();
		class1_0.method_7();
		class1_0.method_8();
		string text = class1_0.method_9();
		if (text.Contains("status\":\"Success\""))
		{
			string text2 = text.Substring(text.IndexOf("onlineOtp") + 12);
			text = text2.Substring(0, text2.IndexOf("\""));
			txtGetotp.Text = text;
		}
		else
		{
			MessageBox.Show("Please Click Get OTP Again ..... Otp Not Found on server \r\n " + text);
		}
	}

	internal string method_1(string string_1)
	{
		string result = "";
		try
		{
			class1_0 = new Class1();
			string[] array = string_1.Split(new string[1] { "||" }, StringSplitOptions.None);
			class1_0.string_36 = array[0].Trim();
			class1_0.string_37 = array[1];
			string text = "./SBI";
			string text2 = "SBI_" + class1_0.string_36;
			Path_ = text + "\\" + text2 + ".rg";
			if (File.Exists(Path_))
			{
				pnlGenotp.Visible = true;
				class1_0 = Class1.smethod_1(Path_);
				if (class1_0.authServiceResponse_0.claims_token.exp < DateTimeOffset.Now.ToUnixTimeMilliseconds())
				{
					class1_0.method_0();
					class1_0.method_7();
					class1_0.method_8();
				}
				string text3 = class1_0.method_9();
				if (text3.Contains("status\":\"Success\""))
				{
					string text4 = text3.Substring(text3.IndexOf("onlineOtp") + 12);
					result = text4.Substring(0, text4.IndexOf("\""));
					return result;
				}
				return result;
			}
			return result;
		}
		catch
		{
			return result;
		}
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		Close();
		Dispose();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(APP_FRAMEWORK.frmSBI));
		this.cmbBanks1 = new System.Windows.Forms.ComboBox();
		this.label1 = new System.Windows.Forms.Label();
		this.pnlsms = new System.Windows.Forms.Panel();
		this.label2 = new System.Windows.Forms.Label();
		this.btnNext = new System.Windows.Forms.Button();
		this.btnCopy = new System.Windows.Forms.Button();
		this.txtSms = new System.Windows.Forms.RichTextBox();
		this.pnlGenotp = new System.Windows.Forms.Panel();
		this.label4 = new System.Windows.Forms.Label();
		this.btngetotp = new System.Windows.Forms.Button();
		this.txtGetotp = new System.Windows.Forms.TextBox();
		this.pnlOTP = new System.Windows.Forms.Panel();
		this.label3 = new System.Windows.Forms.Label();
		this.btnSubmitOTP = new System.Windows.Forms.Button();
		this.txtOtp = new System.Windows.Forms.TextBox();
		this.Bypass = new System.Windows.Forms.Button();
		this.bunifuElipse_0 = new Bunifu.Framework.UI.BunifuElipse(this.components);
		this.pnlHeader = new System.Windows.Forms.Panel();
		this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
		this.lblinfo = new System.Windows.Forms.Label();
		this.label5 = new System.Windows.Forms.Label();
		this.linkLabel1 = new System.Windows.Forms.LinkLabel();
		this.pnlsms.SuspendLayout();
		this.pnlGenotp.SuspendLayout();
		this.pnlOTP.SuspendLayout();
		this.pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.btnClose).BeginInit();
		base.SuspendLayout();
		this.cmbBanks1.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
		this.cmbBanks1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbBanks1.ForeColor = System.Drawing.Color.Black;
		this.cmbBanks1.FormattingEnabled = true;
		this.cmbBanks1.Location = new System.Drawing.Point(16, 46);
		this.cmbBanks1.Margin = new System.Windows.Forms.Padding(4);
		this.cmbBanks1.Name = "cmbBanks1";
		this.cmbBanks1.Size = new System.Drawing.Size(495, 24);
		this.cmbBanks1.TabIndex = 1174;
		this.cmbBanks1.SelectedIndexChanged += new System.EventHandler(cmbBanks1_SelectedIndexChanged);
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.Location = new System.Drawing.Point(4, 95);
		this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(502, 40);
		this.label1.TabIndex = 1176;
		this.label1.Text = "Yeh Text Registered Mobile se  { +917304459011 }Per Send karen\r\nSend Success hone ke Baad Next Button Click Karen";
		this.pnlsms.BackColor = System.Drawing.Color.White;
		this.pnlsms.Controls.Add(this.label2);
		this.pnlsms.Controls.Add(this.btnNext);
		this.pnlsms.Controls.Add(this.btnCopy);
		this.pnlsms.Controls.Add(this.txtSms);
		this.pnlsms.Controls.Add(this.label1);
		this.pnlsms.Location = new System.Drawing.Point(8, 86);
		this.pnlsms.Margin = new System.Windows.Forms.Padding(4);
		this.pnlsms.Name = "pnlsms";
		this.pnlsms.Size = new System.Drawing.Size(664, 158);
		this.pnlsms.TabIndex = 1177;
		this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label2.Location = new System.Drawing.Point(699, -10);
		this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(427, 171);
		this.label2.TabIndex = 1211;
		this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.btnNext.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
		this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnNext.Location = new System.Drawing.Point(512, 43);
		this.btnNext.Margin = new System.Windows.Forms.Padding(4);
		this.btnNext.Name = "btnNext";
		this.btnNext.Size = new System.Drawing.Size(148, 41);
		this.btnNext.TabIndex = 1180;
		this.btnNext.Text = "Next";
		this.btnNext.UseVisualStyleBackColor = false;
		this.btnNext.Click += new System.EventHandler(btnNext_Click);
		this.btnCopy.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
		this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.btnCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnCopy.Location = new System.Drawing.Point(512, 4);
		this.btnCopy.Margin = new System.Windows.Forms.Padding(4);
		this.btnCopy.Name = "btnCopy";
		this.btnCopy.Size = new System.Drawing.Size(148, 32);
		this.btnCopy.TabIndex = 1180;
		this.btnCopy.Text = "Copy";
		this.btnCopy.UseVisualStyleBackColor = false;
		this.btnCopy.Click += new System.EventHandler(btnCopy_Click);
		this.txtSms.Location = new System.Drawing.Point(4, 4);
		this.txtSms.Margin = new System.Windows.Forms.Padding(4);
		this.txtSms.Name = "txtSms";
		this.txtSms.Size = new System.Drawing.Size(499, 79);
		this.txtSms.TabIndex = 1179;
		this.txtSms.Text = "";
		this.txtSms.TextChanged += new System.EventHandler(txtSms_TextChanged);
		this.pnlGenotp.Controls.Add(this.label4);
		this.pnlGenotp.Controls.Add(this.btngetotp);
		this.pnlGenotp.Controls.Add(this.txtGetotp);
		this.pnlGenotp.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
		this.pnlGenotp.Location = new System.Drawing.Point(8, 251);
		this.pnlGenotp.Margin = new System.Windows.Forms.Padding(4);
		this.pnlGenotp.Name = "pnlGenotp";
		this.pnlGenotp.Size = new System.Drawing.Size(291, 107);
		this.pnlGenotp.TabIndex = 1178;
		this.label4.AutoSize = true;
		this.label4.BackColor = System.Drawing.Color.Transparent;
		this.label4.Enabled = false;
		this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label4.ForeColor = System.Drawing.Color.Black;
		this.label4.Location = new System.Drawing.Point(8, 4);
		this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(139, 40);
		this.label4.TabIndex = 1212;
		this.label4.Text = "OTP GET FOR \r\nOTHER TXN";
		this.btngetotp.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
		this.btngetotp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.btngetotp.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btngetotp.Location = new System.Drawing.Point(187, 60);
		this.btngetotp.Margin = new System.Windows.Forms.Padding(4);
		this.btngetotp.Name = "btngetotp";
		this.btngetotp.Size = new System.Drawing.Size(100, 37);
		this.btngetotp.TabIndex = 1181;
		this.btngetotp.Text = "Get OTP";
		this.btngetotp.UseVisualStyleBackColor = false;
		this.btngetotp.Click += new System.EventHandler(btngetotp_Click);
		this.txtGetotp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtGetotp.Location = new System.Drawing.Point(9, 62);
		this.txtGetotp.Margin = new System.Windows.Forms.Padding(4);
		this.txtGetotp.Name = "txtGetotp";
		this.txtGetotp.Size = new System.Drawing.Size(168, 27);
		this.txtGetotp.TabIndex = 1175;
		this.pnlOTP.Controls.Add(this.label3);
		this.pnlOTP.Controls.Add(this.btnSubmitOTP);
		this.pnlOTP.Controls.Add(this.txtOtp);
		this.pnlOTP.ForeColor = System.Drawing.Color.Black;
		this.pnlOTP.Location = new System.Drawing.Point(337, 251);
		this.pnlOTP.Margin = new System.Windows.Forms.Padding(4);
		this.pnlOTP.Name = "pnlOTP";
		this.pnlOTP.Size = new System.Drawing.Size(303, 107);
		this.pnlOTP.TabIndex = 1179;
		this.label3.AutoSize = true;
		this.label3.BackColor = System.Drawing.Color.Transparent;
		this.label3.Enabled = false;
		this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label3.ForeColor = System.Drawing.Color.Black;
		this.label3.Location = new System.Drawing.Point(3, 16);
		this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(180, 20);
		this.label3.TabIndex = 1211;
		this.label3.Text = "Enter OTP Received";
		this.btnSubmitOTP.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
		this.btnSubmitOTP.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.btnSubmitOTP.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnSubmitOTP.Location = new System.Drawing.Point(183, 57);
		this.btnSubmitOTP.Margin = new System.Windows.Forms.Padding(4);
		this.btnSubmitOTP.Name = "btnSubmitOTP";
		this.btnSubmitOTP.Size = new System.Drawing.Size(100, 37);
		this.btnSubmitOTP.TabIndex = 1182;
		this.btnSubmitOTP.Text = "Submit OTP";
		this.btnSubmitOTP.UseVisualStyleBackColor = false;
		this.btnSubmitOTP.Click += new System.EventHandler(btnSubmitOTP_Click);
		this.txtOtp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2f);
		this.txtOtp.Location = new System.Drawing.Point(8, 59);
		this.txtOtp.Margin = new System.Windows.Forms.Padding(4);
		this.txtOtp.Name = "txtOtp";
		this.txtOtp.Size = new System.Drawing.Size(165, 27);
		this.txtOtp.TabIndex = 1175;
		this.Bypass.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
		this.Bypass.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.Bypass.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.Bypass.Location = new System.Drawing.Point(520, 36);
		this.Bypass.Margin = new System.Windows.Forms.Padding(4);
		this.Bypass.Name = "Bypass";
		this.Bypass.Size = new System.Drawing.Size(148, 41);
		this.Bypass.TabIndex = 1182;
		this.Bypass.Text = "ByPass";
		this.Bypass.UseVisualStyleBackColor = false;
		this.Bypass.Click += new System.EventHandler(Bypass_Click);
		this.bunifuElipse_0.ElipseRadius = 5;
		this.bunifuElipse_0.TargetControl = this;
		this.pnlHeader.BackColor = System.Drawing.Color.BurlyWood;
		this.pnlHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.pnlHeader.Controls.Add(this.btnClose);
		this.pnlHeader.Controls.Add(this.lblinfo);
		this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
		this.pnlHeader.ForeColor = System.Drawing.Color.Black;
		this.pnlHeader.Location = new System.Drawing.Point(0, 0);
		this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
		this.pnlHeader.Name = "pnlHeader";
		this.pnlHeader.Size = new System.Drawing.Size(687, 27);
		this.pnlHeader.TabIndex = 1210;
		((System.Windows.Forms.Control)this.btnClose).Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		((System.Windows.Forms.Control)this.btnClose).BackColor = System.Drawing.Color.Transparent;
		((System.Windows.Forms.Control)this.btnClose).Cursor = System.Windows.Forms.Cursors.Hand;
		((System.Windows.Forms.Control)this.btnClose).Location = new System.Drawing.Point(651, 0);
		((System.Windows.Forms.Control)this.btnClose).Margin = new System.Windows.Forms.Padding(4);
		((System.Windows.Forms.Control)this.btnClose).Name = "btnClose";
		((System.Windows.Forms.Control)this.btnClose).Size = new System.Drawing.Size(35, 25);
		((System.Windows.Forms.PictureBox)this.btnClose).SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		((System.Windows.Forms.PictureBox)this.btnClose).TabIndex = 1;
		((System.Windows.Forms.PictureBox)this.btnClose).TabStop = false;
		this.btnClose.Zoom = 10;
		((System.Windows.Forms.Control)this.btnClose).Click += new System.EventHandler(btnClose_Click);
		this.lblinfo.AutoSize = true;
		this.lblinfo.BackColor = System.Drawing.Color.Transparent;
		this.lblinfo.Enabled = false;
		this.lblinfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblinfo.ForeColor = System.Drawing.Color.Black;
		this.lblinfo.Location = new System.Drawing.Point(4, 5);
		this.lblinfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.lblinfo.Name = "lblinfo";
		this.lblinfo.Size = new System.Drawing.Size(159, 20);
		this.lblinfo.TabIndex = 0;
		this.lblinfo.Text = "SBI OTP By-Pass";
		this.lblinfo.Click += new System.EventHandler(lblinfo_Click);
		this.label5.AutoSize = true;
		this.label5.BackColor = System.Drawing.Color.Transparent;
		this.label5.Enabled = false;
		this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label5.ForeColor = System.Drawing.Color.Black;
		this.label5.Location = new System.Drawing.Point(7, 374);
		this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(461, 100);
		this.label5.TabIndex = 1213;
		this.label5.Text = "SBI OTP BYPASS SUCESS KE BAAD APKA ALL OTP\r\nAP YAHA SE GENERATE KAR SAKTE HAI.\r\n\r\nBYPASS KE SAMAY DHEERAJ RAKH KAR BYPASS KARE\r\n\r\n";
		this.linkLabel1.AutoSize = true;
		this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.linkLabel1.Location = new System.Drawing.Point(68, 523);
		this.linkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.linkLabel1.Name = "linkLabel1";
		this.linkLabel1.Size = new System.Drawing.Size(403, 29);
		this.linkLabel1.TabIndex = 1214;
		this.linkLabel1.TabStop = true;
		this.linkLabel1.Text = "Steps to Bypass SBI Netgbanking";
		this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(687, 464);
		base.Controls.Add(this.linkLabel1);
		base.Controls.Add(this.label5);
		base.Controls.Add(this.pnlHeader);
		base.Controls.Add(this.Bypass);
		base.Controls.Add(this.pnlOTP);
		base.Controls.Add(this.pnlGenotp);
		base.Controls.Add(this.pnlsms);
		base.Controls.Add(this.cmbBanks1);
		this.ForeColor = System.Drawing.Color.Black;
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(4);
		base.Name = "frmSBI";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "ByPass SBI";
		base.Load += new System.EventHandler(frmSBI_Load);
		this.pnlsms.ResumeLayout(false);
		this.pnlsms.PerformLayout();
		this.pnlGenotp.ResumeLayout(false);
		this.pnlGenotp.PerformLayout();
		this.pnlOTP.ResumeLayout(false);
		this.pnlOTP.PerformLayout();
		this.pnlHeader.ResumeLayout(false);
		this.pnlHeader.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.btnClose).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private void txtSms_TextChanged(object sender, EventArgs e)
	{
	}

	private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Process.Start("https://drive.google.com/file/d/191qx7HhzLtaOM5yN1hu0KkSH3CLG_8SS/view?usp=sharing");
	}

	private void lblinfo_Click(object sender, EventArgs e)
	{
	}
}
