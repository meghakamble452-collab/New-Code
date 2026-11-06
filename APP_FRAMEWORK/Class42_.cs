using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using Microsoft.VisualBasic;

namespace APP_FRAMEWORK;

public class Class42_
{
	private CookieContainer cookieContainer_0;

	internal string text = "";

	internal string text2 = "";

	internal string string_1;

	internal string string_2;

	internal string string_3;

	internal string Brwpath;

	internal string UserAgent = "okhttp/3.12.1";

	internal string str_6;

	internal string str_7;

	internal string str_8;

	internal string string_6;

	internal string string_7;

	internal string string_8;

	internal string string_9;

	internal string string_10;

	internal string string_11;

	internal string string_12;

	internal string string_13;

	internal string string_63i;

	internal string string_63Ai;

	internal string string_14;

	internal string string_15;

	internal string string_16;

	internal string string_17;

	internal string string_18;

	internal string string_19;

	internal string string_20;

	internal string string_21;

	internal string string_34;

	internal string string_35;

	internal string string_36;

	internal string string_37;

	internal string string_38;

	internal string string_39;

	internal string string_40;

	public Class42_()
	{
		ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
	}

	public string smethod_GenrateSecureOTP(string str_3)
	{
		WebProxy webProxy_ = null;
		this.string_3 = str_3;
		string text = this.string_3;
		string[] array = new string[1];
		string text2 = "||";
		array[0] = text2;
		string[] array2 = text.Split(array, StringSplitOptions.None);
		string_34 = array2[0].Trim();
		string_35 = array2[1];
		string_36 = array2[2];
		string_37 = array2[3];
		string_38 = array2[4];
		string_39 = array2[5];
		string_40 = array2[6];
		string text3 = array2[7];
		string text4 = array2[8];
		string text5 = string_40;
		string[] array3 = new string[1];
		string text6 = "-";
		array3[0] = text6;
		string[] array4 = text5.Split(array3, StringSplitOptions.None);
		str_7 = array4[0];
		this.string_7 = str_7;
		str_8 = array4[1];
		this.string_8 = str_8;
		str_6 = array4[2];
		this.string_6 = string_40;
		string text7 = "10.9.0";
		this.string_9 = text7;
		string text8 = "5.1.1";
		this.string_10 = text8;
		this.string_11 = "";
		this.string_12 = "";
		this.string_13 = "";
		long num = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
		long num2 = num / 1000;
		int num3 = 1;
		string text9 = string_38;
		string text10 = string_38;
		string value = ":";
		string text11 = text9.Substring(text10.IndexOf(value) + 1);
		string value2 = ",";
		string text12 = text11.Substring(0, text11.IndexOf(value2));
		string[] array5 = new string[7] { str_6, null, null, null, null, null, null };
		string text13 = ":";
		array5[1] = text13;
		array5[2] = num2.ToString();
		string text14 = ":";
		array5[3] = text14;
		array5[4] = num3.ToString();
		string text15 = ":";
		array5[5] = text15;
		array5[6] = num3.ToString();
		string_15 = string.Concat(array5);
		string_18 = num2.ToString();
		string text16 = str_6 + num;
		string text17 = "";
		string text18 = "ssotoken#";
		string text19 = "||x-app-rid#";
		string_63i = text18 + text12 + text19 + string_15;
		string[] array6 = new string[13];
		string text20 = "https://securegw.paytm.in/theia/api/v1/fetchQRPaymentDetails?appVersion=";
		array6[0] = text20;
		array6[1] = this.string_9;
		string text21 = "&client=androidapp&networkType=WIFI&deviceIdentifier=";
		array6[2] = text21;
		array6[3] = this.string_6;
		string text22 = "&playStore=false&client=androidapp&locale=en-IN&version=";
		array6[4] = text22;
		array6[5] = this.string_9;
		string text23 = "&osVersion=";
		array6[6] = text23;
		array6[7] = this.string_10;
		string text24 = "&language=en&deviceManufacturer=";
		array6[8] = text24;
		array6[9] = this.string_7;
		string text25 = "&deviceName=";
		array6[10] = text25;
		array6[11] = this.string_8;
		string text26 = "&lang_id=1&child_site_id=1&site_id=1";
		array6[12] = text26;
		string text27 = string.Concat(array6);
		string[] array7 = new string[11];
		string text28 = "{\"head\":{\"requestTimestamp\":\"";
		array7[0] = text28;
		array7[1] = string_18;
		string text29 = "\",\"token\":\"";
		array7[2] = text29;
		array7[3] = text12;
		string text30 = "\",\"tokenType\":\"SSO\",\"version\":\"";
		array7[4] = text30;
		array7[5] = this.string_9;
		string text31 = "\",\"channelId\":\"APP\",\"requestId\":\"";
		array7[6] = text31;
		array7[7] = text16;
		string text32 = "\"},\"body\":{\"qrCodeId\":\"";
		array7[8] = text32;
		array7[9] = text4;
		string text33 = "\",\"mlvSupported\":true}}";
		array7[10] = text33;
		if (!method_1(text27, string.Concat(array7), text17, 2, webProxy_, ref cookieContainer_0, bool_1: true, 50000, ref this.text, ref this.text2))
		{
			return "";
		}
		string text34 = this.text;
		string value3 = "statusCode\":\"SUCCESS";
		if (text34.IndexOf(value3) < 0)
		{
			return "";
		}
		int num4 = num3 + 1;
		long num5 = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
		long num6 = num5 / 1000;
		string text35 = str_6 + num5;
		string[] array8 = new string[7] { str_6, null, null, null, null, null, null };
		string text36 = ":";
		array8[1] = text36;
		array8[2] = num6.ToString();
		string text37 = ":";
		array8[3] = text37;
		array8[4] = num4.ToString();
		string text38 = ":";
		array8[5] = text38;
		array8[6] = num4.ToString();
		string_15 = string.Concat(array8);
		string_18 = num6.ToString();
		string text39 = "57836188";
		string text40 = text39;
		string text41 = str_6;
		string string_ = this.text;
		string string_2 = "MERCHANT_GUID";
		string text42 = method_0(string_, string_2);
		string string_3 = this.text;
		string string_4 = "mappingId";
		string text43 = method_0(string_3, string_4);
		string string_5 = this.text;
		string string_6 = "MERCHANT_NAME";
		string text44 = method_0(string_5, string_6);
		string string_7 = this.text;
		string string_8 = "ORDER_ID";
		string text45 = method_0(string_7, string_8);
		string string_9 = this.text;
		string string_10 = "TXN_AMOUNT";
		string text46 = method_0(string_9, string_10);
		string string_11 = this.text;
		string string_12 = "chargeAmount";
		string text47 = method_0(string_11, string_12);
		string string_13 = this.text;
		string string_14 = "EXPIRY_DATE";
		string text48 = method_0(string_13, string_14);
		string text49 = "x-app-rid#";
		string_63i = text49 + string_15;
		string[] array9 = new string[13];
		string text50 = "https://securegw.paytm.in/theia/api/v1/fetchPcfDetails?mid=";
		array9[0] = text50;
		array9[1] = text43;
		string text51 = "&networkType=WIFI&deviceIdentifier=";
		array9[2] = text51;
		array9[3] = this.string_6;
		string text52 = "&playStore=false&client=androidapp&locale=en-IN&version=";
		array9[4] = text52;
		array9[5] = this.string_9;
		string text53 = "&osVersion=";
		array9[6] = text53;
		array9[7] = this.string_10;
		string text54 = "&language=en&deviceManufacturer=";
		array9[8] = text54;
		array9[9] = this.string_7;
		string text55 = "&deviceName=";
		array9[10] = text55;
		array9[11] = this.string_8;
		string text56 = "&lang_id=1&child_site_id=1&site_id=1";
		array9[12] = text56;
		string text57 = string.Concat(array9);
		string[] array10 = new string[13];
		string text58 = "{\"head\":{\"requestTimestamp\":\"";
		array10[0] = text58;
		array10[1] = string_18;
		string text59 = "\",\"token\":\"";
		array10[2] = text59;
		array10[3] = text12;
		string text60 = "\",\"tokenType\":\"SSO\",\"version\":\"";
		array10[4] = text60;
		array10[5] = this.string_9;
		string text61 = "\",\"channelId\":\"APP\",\"requestId\":\"";
		array10[6] = text61;
		array10[7] = text35;
		string text62 = "\"},\"body\":{\"mid\":\"";
		array10[8] = text62;
		array10[9] = text43;
		string text63 = "\",\"txnAmount\":\"";
		array10[10] = text63;
		array10[11] = text46;
		string text64 = "\",\"payMethods\":[{\"payMethod\":\"BALANCE\"}]}}";
		array10[12] = text64;
		method_1(text57, string.Concat(array10), text17, 2, webProxy_, ref cookieContainer_0, bool_1: true, 50000, ref this.text, ref this.text2);
		string[] array11 = new string[17];
		string text65 = "ssotoken#";
		array11[0] = text65;
		array11[1] = text12;
		string text66 = "||x-app-rid#";
		array11[2] = text66;
		array11[3] = string_15;
		string text67 = "||risk_extended_info#{\"CHANNEL_ID\":\"WEB\",\"IMEI\":\"";
		array11[4] = text67;
		array11[5] = text3;
		string text68 = "\",\"appVersion\":\"";
		array11[6] = text68;
		array11[7] = this.string_9;
		string text69 = "\",\"clientIp\":\"192.168.2.10\",\"contactCreateTime\":\"0\",\"deviceAccounts\":[{\"type\":\"com.google\",\"value\":\"ifigeneia84@gmail.com\"},{\"type\":\"com.google\",\"value\":\"tasos.test.acnt@gmail.com\"}],\"deviceId\":\"";
		array11[8] = text69;
		array11[9] = text41;
		string text70 = "\",\"deviceLanguage\":\"en\",\"deviceManufacturer\":\"";
		array11[10] = text70;
		array11[11] = this.string_7;
		string text71 = "\",\"displayName\":\"IRCTC+E+Ticketing\",\"fuzzyDeviceId\":\"";
		array11[12] = text71;
		array11[13] = text41;
		string text72 = "\",\"isContact\":false,\"isGalleryScan\":false,\"isOfflineMerchant\":true,\"isOnlineMerchant\":false,\"isRooted\":false,\"lcic\":[],\"mode\":\"qrBackEnd\",\"operationOrigin\":\"consumer app\",\"operationType\":\"PAYMENT\",\"osType\":\"Android\",\"otpReadFlag\":false,\"paymentFlow\":\"\",\"phoneModel\":\"";
		array11[14] = text72;
		array11[15] = this.string_8;
		string text73 = "\",\"requestType\":\"QR dynamic\",\"routerMac\":\"00:05:59:36:37:82\",\"scanType\":\"active\",\"screenResolution\":\"720x1280\",\"terminalType\":\"APP\",\"timeZone\":\"GMT+05:30\",\"transactionType\":\"p2m\",\"userLBSLatitude\":\"\",\"userLBSLongitude\":\"\",\"versionCode\":\"710715\",\"wifissid\":[\"%22router%22\"]}";
		array11[16] = text73;
		string_63i = string.Concat(array11);
		string[] array12 = new string[21];
		string text74 = "https://securegw.paytm.in/theia/HANDLER_IVR/CLW_APP_PAY/APP?deviceIdentifier=";
		array12[0] = text74;
		array12[1] = this.string_6;
		string text75 = "&deviceManufacturer=";
		array12[2] = text75;
		array12[3] = this.string_7;
		string text76 = "&deviceName=";
		array12[4] = text76;
		array12[5] = this.string_8;
		string text77 = "&client=androidapp&version=";
		array12[6] = text77;
		array12[7] = this.string_9;
		string text78 = "&playStore=false&lat=0.0&long=0.0&language=en&networkType=WIFI&osVersion=";
		array12[8] = text78;
		array12[9] = this.string_10;
		string text79 = "&locale=en-IN&networkType=WIFI&deviceIdentifier=";
		array12[10] = text79;
		array12[11] = this.string_6;
		string text80 = "&playStore=false&client=androidapp&locale=en-IN&version=";
		array12[12] = text80;
		array12[13] = this.string_9;
		string text81 = "&osVersion=";
		array12[14] = text81;
		array12[15] = this.string_10;
		string text82 = "&language=en&deviceManufacturer=";
		array12[16] = text82;
		array12[17] = this.string_7;
		string text83 = "&deviceName=";
		array12[18] = text83;
		array12[19] = this.string_8;
		string text84 = "&lang_id=1&child_site_id=1&site_id=1";
		array12[20] = text84;
		string text85 = string.Concat(array12);
		string[] array13 = new string[41];
		string text86 = "{\"body\":{\"authMode\":\"USRPWD\",\"channel\":\"WAP\",\"currency\":\"INR\",\"customerId\":\"";
		array13[0] = text86;
		array13[1] = text40;
		string text87 = "\",\"deviceId\":\"";
		array13[2] = text87;
		array13[3] = text41;
		string text88 = "\",\"extendInfo\":{\"additionalInfo\":\"payeeType:MERCHANT|currencyCode:INR|category:Transport|subCategory:Local Train|service:P2M|mode:QR_CODE|offlinePostConvenience:false|mappingId:";
		array13[4] = text88;
		array13[5] = text43;
		string text89 = "|pgEnabled:true|qrCodeId:";
		array13[6] = text89;
		array13[7] = text4;
		string text90 = "|merchantTransId:";
		array13[8] = text90;
		array13[9] = text45;
		string text91 = "|merchantVerified:false|orderAlreadyCreated:true|chargeAmount:";
		array13[10] = text91;
		array13[11] = text47;
		string text92 = "|orderQr:true|REQUEST_TYPE:QR_ORDER|EXPIRY_DATE:";
		array13[12] = text92;
		array13[13] = text48;
		string text93 = "|MERCHANT_NAME:";
		array13[14] = text93;
		array13[15] = text44;
		string text94 = "|NAME:";
		array13[16] = text94;
		array13[17] = text44;
		string text95 = "|MOBILE_NO:9999999999|TXN_AMOUNT:";
		array13[18] = text95;
		array13[19] = text46;
		string text96 = "|INDUSTRY_TYPE_ID:Retail|MERCHANT_GUID:";
		array13[20] = text96;
		array13[21] = text42;
		string text97 = "|ORDER_ID:";
		array13[22] = text97;
		array13[23] = text45;
		string text98 = "|CHANNEL_ID:WEB|qr_code_id:";
		array13[24] = text98;
		array13[25] = text4;
		string text99 = "|comment:\",\"udf1\":\"\",\"merchantUniqueReference\":\"";
		array13[26] = text99;
		array13[27] = text4;
		string text100 = "\"},\"industryType\":\"Retail\",\"orderId\":\"";
		array13[28] = text100;
		array13[29] = text45;
		string text101 = "\",\"paymentMode\":\"PPI\",\"reqType\":\"CLW_APP_PAY\",\"txnAmount\":\"";
		array13[30] = text101;
		array13[31] = text46;
		string text102 = "\"},\"head\":{\"clientId\":\"market-app\",\"mid\":\"";
		array13[32] = text102;
		array13[33] = text43;
		string text103 = "\",\"requestId\":\"";
		array13[34] = text103;
		array13[35] = text35;
		string text104 = "\",\"requestTimestamp\":\"";
		array13[36] = text104;
		array13[37] = string_18;
		string text105 = "\",\"token\":\"";
		array13[38] = text105;
		array13[39] = text12;
		string text106 = "\",\"tokenType\":\"SSO\",\"version\":\"v1\"}}";
		array13[40] = text106;
		object obj;
		if (method_1(text85, string.Concat(array13), text17, 2, webProxy_, ref cookieContainer_0, bool_1: true, 50000, ref this.text, ref this.text2))
		{
			string text107 = this.text;
			string value4 = "prn";
			obj = ((text107.IndexOf(value4) >= 0) ? this.text : "");
		}
		else
		{
			obj = "";
		}
		return (string)obj;
	}

	private string method_0(string string_0, string string_4)
	{
		string result = "";
		try
		{
			string text = "\"";
			string text2 = "\"";
			int startIndex = string_0.IndexOf(text + string_4 + text2, StringComparison.CurrentCultureIgnoreCase);
			string text3 = string_0.Substring(startIndex);
			string value = ":\"";
			string text4 = text3.Substring(text3.IndexOf(value) + 2);
			string value2 = "\"";
			result = HttpUtility.UrlEncode(text4.Substring(0, text4.IndexOf(value2)));
		}
		catch
		{
		}
		return result;
	}

	internal bool method_1(string string_14, string string_15, string string_16, int int_0, WebProxy webProxy_0, ref CookieContainer cookieContainer_1, bool bool_1, int int_1, ref string string_17, ref string string_18)
	{
		int num = 0;
		if (!string.IsNullOrEmpty(string_63i))
		{
			string_63Ai = string_63i;
		}
		WebProxy proxy = null;
		bool result = false;
		bool flag;
		do
		{
			string_18 = "";
			string_17 = "";
			flag = false;
			HttpWebResponse httpWebResponse = null;
			string text = "";
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string_14);
				httpWebRequest.Proxy = webProxy_0;
				httpWebRequest.Proxy = proxy;
				httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip;
				ServicePointManager.ServerCertificateValidationCallback = smethod_1;
				if (int_1 > 0)
				{
					httpWebRequest.Timeout = int_1;
					httpWebRequest.ReadWriteTimeout = int_1;
				}
				byte[] bytes = Encoding.UTF8.GetBytes(string_15);
				if (bool_1)
				{
					if (cookieContainer_1 == null)
					{
						cookieContainer_1 = new CookieContainer();
					}
					httpWebRequest.CookieContainer = cookieContainer_1;
				}
				string method = "POST";
				httpWebRequest.Method = method;
				httpWebRequest.ContentLength = bytes.Length;
				string contentType = "application/x-www-form-urlencoded";
				httpWebRequest.ContentType = contentType;
				string value = "{\"";
				if (string_15.Contains(value))
				{
					string contentType2 = "application/json";
					httpWebRequest.ContentType = contentType2;
				}
				httpWebRequest.UserAgent = UserAgent;
				if (!string.IsNullOrEmpty(string_63Ai))
				{
					string expression = string_63Ai;
					string delimiter = "||";
					string[] array = Strings.Split(expression, delimiter);
					int num2 = Information.UBound(array);
					for (int i = 0; i <= num2; i++)
					{
						string expression2 = array[i];
						string delimiter2 = "#";
						string[] array2 = Strings.Split(expression2, delimiter2);
						httpWebRequest.Headers.Set(array2[0], array2[1]);
					}
					string_63i = "";
				}
				if (string_15.Length > 0)
				{
					using Stream stream = httpWebRequest.GetRequestStream();
					stream.Write(bytes, 0, bytes.Length);
				}
				else
				{
					string method2 = "GET";
					httpWebRequest.Method = method2;
				}
				httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				using (StreamReader textReader_ = smethod_0(httpWebResponse.GetResponseStream()))
				{
					text = smethod_2(textReader_);
				}
				string_17 = text;
				flag = true;
			}
			catch (Exception ex)
			{
				flag = false;
				string_18 = ex.Message;
				string text2 = "SBIOTPByPass: WebRequestPost";
				Class28.smethod_26(text2, string_18);
				string text3 = string_18.ToUpper();
				string value2 = "CONNECTION WAS CLOSED";
				if (!text3.Contains(value2))
				{
					string text4 = string_18.ToUpper();
					string value3 = "SERVICEUNAVAILABLE";
					text4.Contains(value3);
				}
				string text5 = string_18;
				string value4 = "The underlying connection was closed";
				text5.Contains(value4);
				string text6 = string_18;
				string value5 = "The underlying connection was closed";
				if (text6.Contains(value5) && num >= 1)
				{
					proxy = Program.PrivateProxy;
				}
				if (num < 3)
				{
					num++;
					continue;
				}
				return result = flag;
			}
			finally
			{
				try
				{
					httpWebResponse?.Close();
				}
				catch
				{
				}
			}
		}
		while (!(string_17 != ""));
		while (true)
		{
			int[,,] array3 = new int[2, 1, 5]
			{
				{ { -220835034, -183641261, 518673815, 399048733, 1528838015 } },
				{ { 933827564, 344711766, -892835813, 771599478, 1700557384 } }
			};
			switch ((array3[1, 0, 0] * 1501500169) ^ 0x6F80374E)
			{
			default:
				return result;
			case 2:
				return flag;
			case 0:
				break;
			}
		}
	}

	public static bool smethod_1(object A_0, X509Certificate A_1, X509Chain A_2, SslPolicyErrors A_3)
	{
		return true;
	}

	private static StreamReader smethod_0(Stream stream_0)
	{
		return new StreamReader(stream_0);
	}

	private static string smethod_2(TextReader textReader_0)
	{
		return textReader_0.ReadToEnd();
	}
}
