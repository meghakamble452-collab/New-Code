using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;

namespace APP_FRAMEWORK;

public class SBISecureLogin_OTP_Deregister
{
	internal bool Logged_In;

	internal string string_1;

	internal string string_2;

	internal string string_3;

	internal string string_4;

	internal string string_5;

	internal string string_6;

	internal string Brwpath;

	internal string IpAddres;

	internal string string_7;

	internal string string_8;

	internal string string_9;

	internal string string_10;

	internal string string_11;

	internal string string_12;

	internal string string_13;

	internal string string_14;

	internal string string_15;

	private CookieContainer cookieContainer_0;

	private WebProxy webProxy_0;

	public bool smethod_LoginForOTP()
	{
		if (Logged_In)
		{
			return Logged_In;
		}
		string text = string_3;
		string[] array = new string[1];
		string text2 = "||";
		array[0] = text2;
		string[] array2 = text.Split(array, StringSplitOptions.None);
		string_4 = array2[0].Trim();
		string_5 = array2[1];
		string_6 = array2[2];
		string_7 = array2[3];
		string_8 = array2[4];
		string_9 = array2[5];
		string_10 = array2[6];
		bool result = false;
		string string_ = "";
		string string_2 = "";
		string text3 = "https://midentity.onlinesbi.com/services1/SBISmartOTPCheService0/SmartSecService";
		string_13 = text3;
		string text4 = "2.2.9";
		string text5 = text4;
		string text6 = "6.5.QA_v201904231830_r5aa";
		string text7 = text6;
		string text8 = string_4;
		string text9 = "$652@!#*SaWeQ@";
		string mpin = text9;
		string text10 = "$*|@%$B!$E@u^#@A%!";
		string appKey = text10;
		string plnData = "{\"body\":{},\"security\":{\"appkey\":\"\",\"mpin\":\"\",\"token1\":\"\",\"token2\":\"\"}}";
		string text11 = SBISecure2_0_1.EncryptEncData(plnData, text8, mpin, appKey);
		string text12 = "{\"userName\":\"";
		string text13 = string_4;
		string text14 = "\",\"bankCode\":\"0\",\"token\":\"\"}";
		string str = SBISecure2_0_1.Base64Encode(text12 + text13 + text14, isUrlSafe: false);
		string request = SBISecure2_0_1.GetRequest(plnData);
		string[] array3 = new string[10];
		string text15 = "platform=android&encData=";
		array3[0] = text15;
		array3[1] = text11;
		string text16 = "&appID=OnlineOTP&requestKey=";
		array3[2] = text16;
		array3[3] = request;
		string text17 = "&appver=";
		array3[4] = text17;
		array3[5] = text5;
		string text18 = "&optionalFlagFomUI=false&header=";
		array3[6] = text18;
		array3[7] = HttpUtility.UrlEncode(str);
		string text19 = "&channel=rc&serviceID=SmartSecService&cacheid=&platformver=";
		array3[8] = text19;
		array3[9] = text7;
		string_12 = string.Concat(array3);
		string text20 = string_13;
		string text21 = string_12;
		string text22 = string_8;
		string text23 = "json";
		if (!Class47.method_1(text20, text21, text22 + text23, 1, webProxy_0, ref cookieContainer_0, bool_1: true, 50000, ref string_, ref string_2))
		{
			return result;
		}
		string text24 = string_;
		string value = "encData";
		int startIndex = text24.IndexOf(value);
		string text25 = string_;
		string value2 = ":\"";
		int num = text25.IndexOf(value2, startIndex) + 2;
		string text26 = string_;
		string value3 = "\"";
		int length = text26.IndexOf(value3, num) - num;
		string text27 = SBISecure2_0_1.DecryptResponseEncData(string_.Substring(num, length), text8, mpin, appKey);
		string text28 = string_;
		string value4 = "200";
		if (text28.Contains(value4))
		{
			string value5 = "serviceId";
			if (text27.Contains(value5))
			{
				string value6 = "serviceId";
				int startIndex2 = text27.IndexOf(value6);
				string value7 = ":\"";
				int num2 = text27.IndexOf(value7, startIndex2) + 2;
				string value8 = "\"";
				int length2 = text27.IndexOf(value8, num2) - num2;
				string text29 = text27.Substring(num2, length2);
				string value9 = "keyId";
				int startIndex3 = text27.IndexOf(value9);
				string value10 = ":\"";
				int num3 = text27.IndexOf(value10, startIndex3) + 2;
				string value11 = "\"";
				int length3 = text27.IndexOf(value11, num3) - num3;
				string text30 = text27.Substring(num3, length3);
				string text31 = "~9413";
				string text32 = smethod_2(text8 + text31);
				string text33 = "#";
				string text34 = smethod_2(text32 + text33 + text30);
				string text35 = "https://midentity.onlinesbi.com/services1/SBISmartOTPCheService0/SecureLoginService";
				string_13 = text35;
				string[] array4 = new string[11];
				string text36 = "{\"body\":{\"secretKey\":\"";
				array4[0] = text36;
				array4[1] = string_10;
				string text37 = "\",\"shaMpin\":\"";
				array4[2] = text37;
				array4[3] = text34;
				string text38 = "\",\"serviceId\":\"";
				array4[4] = text38;
				array4[5] = text29;
				string text39 = "\",\"deviceName\":\"";
				array4[6] = text39;
				array4[7] = string_8;
				string text40 = "\",\"imeiNo\":\"";
				array4[8] = text40;
				array4[9] = string_7;
				string text41 = "\",\"osName\":\"android\"},\"security\":{\"appkey\":\"\",\"mpin\":\"\",\"token1\":\"\",\"token2\":\"\"}}";
				array4[10] = text41;
				string plnData2 = string.Concat(array4);
				string text42 = SBISecure2_0_1.EncryptEncData(plnData2, text8, string_7, string_9);
				string text43 = "{\"userName\":\"";
				string text44 = string_4;
				string text45 = "\",\"bankCode\":\"0\",\"token\":\"\"}";
				string str2 = SBISecure2_0_1.Base64Encode(text43 + text44 + text45, isUrlSafe: false);
				string request2 = SBISecure2_0_1.GetRequest(plnData2);
				string[] array5 = new string[10];
				string text46 = "platform=android&encData=";
				array5[0] = text46;
				array5[1] = text42;
				string text47 = "&appID=OnlineOTP&requestKey=";
				array5[2] = text47;
				array5[3] = request2;
				string text48 = "&appver=";
				array5[4] = text48;
				array5[5] = text5;
				string text49 = "&jSessionId=&header=";
				array5[6] = text49;
				array5[7] = HttpUtility.UrlEncode(str2);
				string text50 = "&channel=rc&serviceID=SecureLoginService&cacheid=&ipAddress=&platformver=";
				array5[8] = text50;
				array5[9] = text7;
				string_12 = string.Concat(array5);
				string text51 = string_13;
				string text52 = string_12;
				string text53 = string_8;
				string text54 = "json";
				if (!Class47.method_1(text51, text52, text53 + text54, 1, webProxy_0, ref cookieContainer_0, bool_1: true, 50000, ref string_, ref string_2))
				{
					return result;
				}
				string text55 = string_;
				string value12 = "encData";
				int startIndex4 = text55.IndexOf(value12);
				string text56 = string_;
				string value13 = ":\"";
				int num4 = text56.IndexOf(value13, startIndex4) + 2;
				string text57 = string_;
				string value14 = "\"";
				int length4 = text57.IndexOf(value14, num4) - num4;
				string text58 = SBISecure2_0_1.DecryptResponseEncData(string_.Substring(num4, length4), text8, string_7, string_9);
				string text59 = string_;
				string value15 = "200";
				if (text59.Contains(value15))
				{
					string value16 = "serviceId";
					if (!text58.Contains(value16))
					{
						string value17 = "jSessionId";
						if (!text58.Contains(value17))
						{
							goto IL_0779;
						}
					}
					if (text58.Length >= 20)
					{
						string value18 = "jSessionId";
						int startIndex5 = text58.IndexOf(value18);
						string value19 = ":\"";
						int num5 = text58.IndexOf(value19, startIndex5) + 2;
						string value20 = "\"";
						int length5 = text58.IndexOf(value20, num5) - num5;
						string_14 = text58.Substring(num5, length5);
						IpAddres = string_14;
						string value21 = "uId";
						int startIndex6 = text58.IndexOf(value21);
						string value22 = ":\"";
						int num6 = text58.IndexOf(value22, startIndex6) + 2;
						string value23 = "\"";
						int length6 = text58.IndexOf(value23, num6) - num6;
						string_15 = text58.Substring(num6, length6);
						Logged_In = true;
						return true;
					}
					string text60 = string_;
					string value24 = "status";
					int startIndex7 = text60.IndexOf(value24);
					string text61 = string_;
					string value25 = ":\"";
					int num7 = text61.IndexOf(value25, startIndex7) + 2;
					string text62 = string_;
					string value26 = "\"";
					int length7 = text62.IndexOf(value26, num7) - num7;
					string text63 = SBISecure2_0_1.DecryptResponseEncData(string_.Substring(num7, length7), text8, string_7, string_9);
					string value27 = "statusDesc";
					int startIndex8 = text63.IndexOf(value27);
					string value28 = ":\"";
					int num8 = text63.IndexOf(value28, startIndex8) + 2;
					string value29 = "\"";
					int length8 = text63.IndexOf(value29, num8) - num8;
					text63.Substring(num8, length8);
					return result;
				}
				goto IL_0779;
			}
		}
		string text64 = "Invalid Login Data-1";
		MessageBox.Show(text64);
		return result;
		IL_0779:
		return result;
	}

	public string smethod_GenrateSecureOTP(string str_3)
	{
		string_3 = str_3;
		if (smethod_LoginForOTP())
		{
			string string_ = "";
			string string_2 = "";
			string text = "https://midentity.onlinesbi.com/services1/SBISmartOTPCheService0/FetchOnlineOTP";
			string_13 = text;
			string text2 = "2.2.9";
			string text3 = text2;
			string text4 = "6.5.QA_v201904231830_r5aa";
			string text5 = text4;
			string userId = string_4;
			string[] array = new string[11];
			string text6 = "{\"body\":{\"secretKey\":\"";
			array[0] = text6;
			array[1] = string_10;
			string text7 = "\"},\"security\":{\"appkey\":\"";
			array[2] = text7;
			array[3] = string_9;
			string text8 = "\",\"mpin\":\"";
			array[4] = text8;
			array[5] = string_7;
			string text9 = "\",\"token1\":\"";
			array[6] = text9;
			array[7] = string_14;
			string text10 = "\",\"token2\":\"";
			array[8] = text10;
			array[9] = string_15;
			string text11 = "\"}}";
			array[10] = text11;
			string plnData = string.Concat(array);
			string text12 = SBISecure2_0_1.EncryptEncData(plnData, userId, string_7, string_9);
			string text13 = "{\"userName\":\"";
			string text14 = string_4;
			string text15 = "\",\"bankCode\":\"0\",\"token\":\"\"}";
			string str = SBISecure2_0_1.Base64Encode(text13 + text14 + text15, isUrlSafe: false);
			string request = SBISecure2_0_1.GetRequest(plnData);
			string[] array2 = new string[10];
			string text16 = "platform=android&encData=";
			array2[0] = text16;
			array2[1] = text12;
			string text17 = "&appID=OnlineOTP&requestKey=";
			array2[2] = text17;
			array2[3] = request;
			string text18 = "&appver=";
			array2[4] = text18;
			array2[5] = text3;
			string text19 = "&header=";
			array2[6] = text19;
			array2[7] = HttpUtility.UrlEncode(str);
			string text20 = "&channel=rc&serviceID=FetchOnlineOTP&cacheid=&platformver=";
			array2[8] = text20;
			array2[9] = text5;
			string_12 = string.Concat(array2);
			string text21 = string_13;
			string text22 = string_12;
			string text23 = string_8;
			string text24 = "json";
			if (Class47.method_1(text21, text22, text23 + text24, 1, webProxy_0, ref cookieContainer_0, bool_1: true, 50000, ref string_, ref string_2))
			{
				string text25 = string_;
				string value = "encData";
				int startIndex = text25.IndexOf(value);
				string text26 = string_;
				string value2 = ":\"";
				int num = text26.IndexOf(value2, startIndex) + 2;
				string text27 = string_;
				string value3 = "\"";
				int length = text27.IndexOf(value3, num) - num;
				string text28 = SBISecure2_0_1.DecryptResponseEncData(string_.Substring(num, length), userId, string_7, string_9);
				string text29 = string_;
				string value4 = "200";
				if (!text29.Contains(value4))
				{
					string value5 = "status\":";
					if (!text28.Contains(value5))
					{
						Logged_In = false;
						return "Check-OTP Get Failed";
					}
				}
				string value6 = "status\":\"Success\"";
				string result;
				if (text28.Contains(value6))
				{
					string value7 = "onlineOtp";
					string text30 = text28.Substring(text28.IndexOf(value7) + 12);
					string value8 = "\"";
					result = text30.Substring(0, text30.IndexOf(value8));
				}
				else
				{
					string text31 = "Currently No OTP is Availiable, You can Try after some time.";
					result = text31;
				}
				return result;
			}
			Logged_In = false;
			return "Step-OTP Get Failed";
		}
		return "";
	}

	public bool btnDeregs_Click(string str_3)
	{
		string_3 = str_3;
		if (!smethod_LoginForOTP())
		{
			return false;
		}
		string string_ = "";
		string string_2 = "";
		string text = "https://m.onlinesbi.com/middleware/MWServlet";
		string_13 = text;
		string text2 = "2.2.5";
		string text3 = text2;
		string text4 = "6.5.QA_v201904231830_r5";
		string text5 = text4;
		string userId = string_4;
		string[] array = new string[15];
		string text6 = "{\"body\":{\"deviceId\":\"";
		array[0] = text6;
		array[1] = string_7;
		string text7 = "\",\"secretKey\":\"";
		array[2] = text7;
		array[3] = string_10;
		string text8 = "\",\"ipAddress\":\"";
		array[4] = text8;
		array[5] = IpAddres;
		string text9 = "\"},\"security\":{\"appkey\":\"";
		array[6] = text9;
		array[7] = string_9;
		string text10 = "\",\"mpin\":\"";
		array[8] = text10;
		array[9] = string_7;
		string text11 = "\",\"token1\":\"";
		array[10] = text11;
		array[11] = string_14;
		string text12 = "\",\"token2\":\"";
		array[12] = text12;
		array[13] = string_15;
		string text13 = "\"}}";
		array[14] = text13;
		string plnData = string.Concat(array);
		string text14 = SBISecure2_0_1.EncryptEncData(plnData, userId, string_7, string_9);
		string text15 = "{\"userName\":\"";
		string text16 = string_4;
		string text17 = "\",\"bankCode\":\"0\",\"token\":\"\"}";
		string str = SBISecure2_0_1.Base64Encode(text15 + text16 + text17, isUrlSafe: false);
		string request = SBISecure2_0_1.GetRequest(plnData);
		string[] array2 = new string[10];
		string text18 = "platform=android&encData=";
		array2[0] = text18;
		array2[1] = text14;
		string text19 = "&appID=OnlineOTP&requestKey=";
		array2[2] = text19;
		array2[3] = request;
		string text20 = "&appver=";
		array2[4] = text20;
		array2[5] = text3;
		string text21 = "&header=";
		array2[6] = text21;
		array2[7] = HttpUtility.UrlEncode(str);
		string text22 = "&channel=rc&serviceID=DeRegisterService&cacheid=&platformver=";
		array2[8] = text22;
		array2[9] = text5;
		string_12 = string.Concat(array2);
		string text23 = string_13;
		string text24 = string_12;
		string text25 = string_8;
		string text26 = "json";
		if (!Class47.method_1(text23, text24, text25 + text26, 1, webProxy_0, ref cookieContainer_0, bool_1: true, 50000, ref string_, ref string_2))
		{
			string text27 = "Step-OTP Get Failed";
			MessageBox.Show(text27);
		}
		string text28 = string_;
		string value = "encData";
		int startIndex = text28.IndexOf(value);
		string text29 = string_;
		string value2 = ":\"";
		int num = text29.IndexOf(value2, startIndex) + 2;
		string text30 = string_;
		string value3 = "\"";
		int length = text30.IndexOf(value3, num) - num;
		SBISecure2_0_1.DecryptResponseEncData(string_.Substring(num, length), userId, string_7, string_9);
		string text31 = "DeRegister Account! Do you want to DeRegister SBI ?\r\n\r\nAfter This Please Derigster your service form online netbanking also.";
		string caption = "DeRegister";
		MessageBox.Show(text31, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		return true;
	}

	public string getOffline_Token(string str_3, string randomNumber)
	{
		string_3 = str_3;
		if (smethod_LoginForOTP())
		{
			string text = string_7;
			string text2 = string_10;
			object obj;
			if (text2 == "")
			{
				obj = "";
			}
			else
			{
				string input = smethod_0(randomNumber + text + text2);
				string pattern = "\\D";
				obj = Regex.Replace(input, pattern, "").Substring(0, 8);
			}
			return (string)obj;
		}
		return "";
	}

	private static string smethod_0(string string_0)
	{
		string hashName = "SHA-256";
		byte[] array = HashAlgorithm.Create(hashName).ComputeHash(Encoding.UTF8.GetBytes(string_0));
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.Length; i++)
		{
			string format = "{0:x2}";
			stringBuilder.Append(string.Format(format, array[i]));
		}
		return stringBuilder.ToString();
	}

	private static string smethod_1(string string_0)
	{
		byte[] array = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(string_0));
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.Length; i++)
		{
			ref byte reference = ref array[i];
			string text = "x2";
			stringBuilder.Append(reference.ToString(text));
		}
		return stringBuilder.ToString();
	}

	private static string smethod_2(string string_0)
	{
		byte[] array = new SHA512Managed().ComputeHash(Encoding.UTF8.GetBytes(string_0));
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.Length; i++)
		{
			ref byte reference = ref array[i];
			string text = "x2";
			stringBuilder.Append(reference.ToString(text));
		}
		return stringBuilder.ToString();
	}
}
