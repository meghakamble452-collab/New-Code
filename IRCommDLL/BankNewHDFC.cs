using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using NEXUS;

namespace IRCommDLL;

internal class BankNewHDFC
{
	private string string_52;

	private string string_29;

	private bool bool_11;

	private string string_16;

	private bool bool_29;

	private bool bool_30;

	private WebException Exception_;

	private string Status;

	private string HeaderString;

	private clsPostData class3_0;

	public string Encrypt(string string_0, string string_4)
	{
		byte[] rgbIV = new byte[8] { 18, 52, 86, 120, 144, 171, 205, 239 };
		byte[] bytes = Encoding.UTF8.GetBytes(Strings.Left(string_4, 8));
		DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
		byte[] bytes2 = Encoding.UTF8.GetBytes(string_0);
		MemoryStream memoryStream = new MemoryStream();
		CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(bytes, rgbIV), CryptoStreamMode.Write);
		cryptoStream.Write(bytes2, 0, bytes2.Length);
		cryptoStream.FlushFinalBlock();
		return Convert.ToBase64String(memoryStream.ToArray());
	}

	public string Decrypt(string string_0, string string_4)
	{
		byte[] rgbIV = new byte[8] { 18, 52, 86, 120, 144, 171, 205, 239 };
		try
		{
			byte[] bytes = Encoding.UTF8.GetBytes(string_4.Substring(0, 8));
			DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
			byte[] array = Convert.FromBase64String(string_0);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(bytes, rgbIV), CryptoStreamMode.Write);
			cryptoStream.Write(array, 0, array.Length);
			cryptoStream.FlushFinalBlock();
			return Encoding.UTF8.GetString(memoryStream.ToArray());
		}
		catch (Exception ex)
		{
			return ex.Message;
		}
	}

	private string encrypt_Password(string RequestToken, string data, string action)
	{
		string text = string.Empty;
		try
		{
			RequestBody requestBody = new RequestBody
			{
				Action = action
			};
			string string_ = "$rv8l3#2qz1";
			requestBody.data = Encrypt(data, string_);
			requestBody.RequestToken = RequestToken;
			try
			{
				string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
				string text2 = "/EncryptHDFC/EncryptHDFC.exe";
				if (!File.Exists(folderPath + text2))
				{
					Class60.EncryptHDFC_Extrte(0);
				}
				string[] array = new string[5] { RequestToken, null, null, null, null };
				string text3 = "||";
				array[1] = text3;
				string string_2 = "$rv8l3#2qz1";
				array[2] = Encrypt(data, string_2);
				string text4 = "||";
				array[3] = text4;
				array[4] = action;
				string arguments = string.Concat(array);
				Process process = new Process();
				ProcessStartInfo startInfo = process.StartInfo;
				string folderPath2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
				string path = "EncryptHDFC/EncryptHDFC.exe";
				startInfo.FileName = Path.Combine(folderPath2, path);
				process.StartInfo.Arguments = arguments;
				process.StartInfo.CreateNoWindow = true;
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.RedirectStandardOutput = true;
				process.Start();
				StreamReader standardOutput = process.StandardOutput;
				process.WaitForExit(3500);
				text = standardOutput.ReadLine();
				if (!process.HasExited)
				{
					process.Kill();
				}
				string text5 = text;
				string oldValue = "\"";
				text = text5.Replace(oldValue, "");
				string string_3 = text;
				string string_4 = "$rv8l3#2qz1";
				text = Decrypt(string_3, string_4);
				return text;
			}
			catch
			{
			}
			if (string.IsNullOrEmpty(text))
			{
				string[] array2 = new string[7];
				string text6 = "{\"RequestToken\":\"";
				array2[0] = text6;
				array2[1] = RequestToken;
				string text7 = "\",\"data\":\"";
				array2[2] = text7;
				string string_5 = "$rv8l3#2qz1";
				array2[3] = Encrypt(data, string_5);
				string text8 = "\",\"Action\":\"";
				array2[4] = text8;
				array2[5] = action;
				string text9 = "\"}";
				array2[6] = text9;
				string text10 = string.Concat(array2);
				string apiLink = clsMain.apiLink;
				string text11 = ":8080/Secure/DataEncrypt";
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(apiLink + text11);
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				string contentType = "application/json";
				httpWebRequest.ContentType = contentType;
				httpWebRequest.Timeout = 25000;
				httpWebRequest.ReadWriteTimeout = 25000;
				string method = "POST";
				httpWebRequest.Method = method;
				using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
				{
					string value = text10;
					streamWriter.Write(value);
				}
				using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
				text = streamReader.ReadToEnd();
				string text12 = text;
				string oldValue2 = "\"";
				text = text12.Replace(oldValue2, "");
				string string_6 = text;
				string string_7 = "$rv8l3#2qz1";
				text = Decrypt(string_6, string_7);
			}
		}
		catch (Exception)
		{
		}
		return text;
	}

	internal bool HdfcByPass(string string_86, ref string string_87, CookieContainer cookieContainer)
	{
		bool flag = false;
		string text = "https://netportal.hdfcbank.com/nb-login/login.jsp";
		string string_88 = text;
		string text2 = "";
		string text3 = "https://www.irctc.co.in/eticketing/jpInput.jsf?cid=1";
		string string_89 = text3;
		string string_90 = "";
		string string_91 = "";
		string_87 = "";
		string status = "Enter ProcessHDFC :- 1";
		Status = status;
		string[] array = new string[1];
		string text4 = "||";
		array[0] = text4;
		string[] array2 = string_86.Split(array, StringSplitOptions.None);
		string text5 = array2[0].Trim();
		string text6 = "123456789112233";
		string text7 = text6;
		text7 = array2[1];
		string text8 = array2[2];
		string text9 = array2[3];
		string text10 = array2[4];
		string text11 = "";
		string text12 = "";
		string text13 = "";
		string text14 = "";
		try
		{
			if (text5.Length < 10)
			{
				string text15 = "00";
				text14 = text15 + text5.Length;
			}
			else
			{
				string text16 = "0";
				text14 = text16 + text5.Length;
			}
			if (text7.Length < 10)
			{
				string text17 = text14;
				string text18 = "00";
				text14 = text17 + text18 + text7.Length;
			}
			else
			{
				string text19 = text14;
				string text20 = "0";
				text14 = text19 + text20 + text7.Length;
			}
			text13 = text5 + text7 + text14;
			string[] array3 = new string[3];
			string text21 = "fldLoginUserId=";
			array3[0] = text21;
			array3[1] = text5;
			string text22 = "&fldPassword=";
			array3[2] = text22;
			text2 = string.Concat(array3);
			if (!_Request(string_88, text2, string_89, ref cookieContainer, bool_64: true, 60000, 60000, ref string_90, ref string_91, ref Exception_))
			{
				string text23 = "HDFC Not Working : ";
				string_87 = text23 + Status;
				string text24 = string_87;
				string text25 = "\n";
				MessageBox.Show(text24 + text25 + string_91);
				return false;
			}
			string text26 = string_90;
			string text27 = string_90;
			string value = "name>page";
			string text28 = text26.Substring(text27.IndexOf(value) + 10);
			string text29 = text28;
			string text30 = text28;
			string value2 = "<";
			string text31 = text29.Substring(0, text30.IndexOf(value2));
			DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
			string text32 = (DateTime.UtcNow - dateTime).TotalMilliseconds.ToString();
			string text33 = text32.Substring(0, 13);
			string text34 = text32.Substring(0, 12);
			string text35 = "XXXX";
			text11 = ConvertToBase64(text34 + text35);
			string requestToken = text11;
			string action = "Encrypt";
			string text36 = encrypt_Password(requestToken, text5, action);
			string text37 = "https://netportal.hdfcbank.com/services/epiproxy/current/customerValidate";
			string_88 = text37;
			text2 = "";
			string status2 = "Enter ProcessHDFC :- 2";
			Status = status2;
			string[] array4 = new string[5];
			string text38 = "Channelindicator#NB&Fldappid#RS&Bnkcustid#";
			array4[0] = text38;
			array4[1] = text36;
			string text39 = "&Ans#";
			array4[2] = text39;
			array4[3] = text33;
			string text40 = "&Flextobbloginflag#true&Isflagrsa#Y&Openmarketflag#true&Req-X-Auth-Token#JWT_COOKIE";
			array4[4] = text40;
			HeaderString = string.Concat(array4);
			if (!_Request(string_88, text2, string_89, ref cookieContainer, bool_64: true, 60000, 60000, ref string_90, ref string_91, ref Exception_))
			{
				goto IL_1cec;
			}
			string text41 = string_90;
			string value3 = "custId";
			if (!text41.Contains(value3))
			{
				goto IL_1cec;
			}
			string text42 = string_90;
			string text43 = string_90;
			string value4 = "outEncryptValue";
			text28 = text42.Substring(text43.IndexOf(value4) + 18);
			string text44 = text28;
			string text45 = text28;
			string value5 = "\"";
			string text46 = text44.Substring(0, text45.IndexOf(value5));
			string requestToken2 = text11;
			string data = text13;
			string action2 = "Encrypt";
			string value6 = encrypt_Password(requestToken2, data, action2);
			string text47 = "https://netportal.hdfcbank.com/j_spring_security_check";
			string_88 = text47;
			string[] array5 = new string[6];
			string text48 = "data_encrypt=";
			array5[0] = text48;
			array5[1] = WebUtility.UrlEncode(value6);
			string text49 = "&portal_name=portal&page_name=page_";
			array5[2] = text49;
			array5[3] = text31;
			string text50 = "&secretAnswer=";
			array5[4] = text50;
			array5[5] = text33;
			text2 = string.Concat(array5);
			bool_29 = true;
			string status3 = "Enter ProcessHDFC :- 3";
			Status = status3;
			string text51 = "Channelindicator#NB&fldAppId#RS&hasUserIdUsedForLogin#N&modeOfAuthenticationLogin#Password&inEncryptValue#";
			string text52 = text46;
			string text53 = "&Flextobbloginflag#true&openMarketFlag#true&sourceId#netBankingLogin&Req-X-Auth-Token#JWT_COOKIE";
			HeaderString = text51 + text52 + text53;
			if (!_Request(string_88, text2, string_89, ref cookieContainer, bool_64: true, 60000, 60000, ref string_90, ref string_91, ref Exception_))
			{
				string text54 = "HDFC Not Working : ";
				string_87 = text54 + Status;
				string text55 = string_87;
				string text56 = "\n";
				MessageBox.Show(text55 + text56 + string_91);
				return false;
			}
			string text57 = string_90;
			string text58 = string_90;
			string value7 = "outEncryptValue";
			text28 = text57.Substring(text58.IndexOf(value7) + 18);
			string text59 = text28;
			string text60 = text28;
			string value8 = "\"";
			text46 = text59.Substring(0, text60.IndexOf(value8));
			bool_30 = true;
			string text61 = "https://netportal.hdfcbank.com/services/proxy/current/authenticateRSALogin";
			string_88 = text61;
			string text62 = "https://netportal.hdfcbank.com";
			string_89 = text62;
			string[] array6 = new string[5];
			string text63 = "{\"bnkCustId\":\"";
			array6[0] = text63;
			array6[1] = text5;
			string text64 = "\",\"secretAnswer\":\"";
			array6[2] = text64;
			array6[3] = text33;
			string text65 = "\"}";
			array6[4] = text65;
			text2 = string.Concat(array6);
			text2 = getPostData(text11, text2);
			string status4 = "Enter ProcessHDFC :- 4";
			Status = status4;
			string text66 = "channelIndicator#NB&fldAppId#RS&inEncryptValue#";
			string text67 = text46;
			string text68 = "&openMarketFlag#true";
			HeaderString = text66 + text67 + text68;
			if (!_Request(string_88, text2, string_89, ref cookieContainer, bool_64: true, 60000, 60000, ref string_90, ref string_91, ref Exception_))
			{
				string text69 = "HDFC Not Working : ";
				string_87 = text69 + Status;
				string text70 = string_87;
				string text71 = "\n";
				MessageBox.Show(text70 + text71 + string_91);
				return false;
			}
			string text72 = string_90;
			string text73 = string_90;
			string value9 = "outEncryptValue";
			text28 = text72.Substring(text73.IndexOf(value9) + 18);
			string text74 = text28;
			string text75 = text28;
			string value10 = "\"";
			text46 = text74.Substring(0, text75.IndexOf(value10));
			bool_30 = true;
			string text76 = "https://netportal.hdfcbank.com/services/proxy/current/personal";
			string_88 = text76;
			text2 = "";
			string status5 = "Enter ProcessHDFC :- 5";
			Status = status5;
			string text77 = "channelIndicator#NB&fldAppId#RS&inEncryptValue#";
			string text78 = text46;
			string text79 = "&openMarketFlag#true";
			HeaderString = text77 + text78 + text79;
			if (!_Request(string_88, text2, string_89, ref cookieContainer, bool_64: true, 60000, 60000, ref string_90, ref string_91, ref Exception_))
			{
				string text80 = "HDFC Not Working : ";
				string_87 = text80 + Status;
				string text81 = string_87;
				string text82 = "\n";
				MessageBox.Show(text81 + text82 + string_91);
				return false;
			}
			string text83 = string_90;
			string text84 = string_90;
			string value11 = "outEncryptValue";
			text28 = text83.Substring(text84.IndexOf(value11) + 18);
			string text85 = text28;
			string text86 = text28;
			string value12 = "\"";
			text46 = text85.Substring(0, text86.IndexOf(value12));
			bool_30 = true;
			string text87 = "https://netportal.hdfcbank.com/services/proxy/current/ChangeSecurityQuestionsAnswers";
			string_88 = text87;
			string[] array7 = new string[5];
			string text88 = "{\"eventType\":\"";
			array7[0] = text88;
			string text89 = "GET_USER_QA";
			array7[1] = text89;
			string text90 = "\",\"secretAnswer\":\"";
			array7[2] = text90;
			array7[3] = text33;
			string text91 = "\"}";
			array7[4] = text91;
			text2 = string.Concat(array7);
			text2 = getPostData(text11, text2);
			string status6 = "Enter ProcessHDFC :- 6";
			Status = status6;
			string text92 = "channelIndicator#NB&fldAppId#RS&inEncryptValue#";
			string text93 = text46;
			string text94 = "&openMarketFlag#true";
			HeaderString = text92 + text93 + text94;
			if (!_Request(string_88, text2, string_89, ref cookieContainer, bool_64: true, 60000, 60000, ref string_90, ref string_91, ref Exception_))
			{
				string text95 = "HDFC Not Working : ";
				string_87 = text95 + Status;
				string text96 = string_87;
				string text97 = "\n";
				MessageBox.Show(text96 + text97 + string_91);
				return false;
			}
			string text98 = string_90;
			string text99 = string_90;
			string value13 = "outEncryptValue";
			text28 = text98.Substring(text99.IndexOf(value13) + 18);
			string text100 = text28;
			string text101 = text28;
			string value14 = "\"";
			text46 = text100.Substring(0, text101.IndexOf(value14));
			string text102 = string_90;
			string text103 = string_90;
			string value15 = "challengeQuestions\":[";
			string text104 = text102.Substring(text103.IndexOf(value15) + 21);
			string value16 = "]";
			string text105 = text104.Substring(0, text104.IndexOf(value16));
			string[] array8 = new string[1];
			string text106 = ",{";
			array8[0] = text106;
			string[] array9 = text105.Split(array8, StringSplitOptions.None);
			int num = 0;
			string text107 = "{\"eventType\":\"SET_USER_QNA\",\"partyType\":\"I\",\"challengeQuestionsList\":[";
			string text108 = text107;
			string[] array10 = array9;
			string[] array11 = array10;
			string[] array12 = array11;
			foreach (string text109 in array12)
			{
				num++;
				string value17 = "questionId";
				string text110 = text109.Substring(text109.IndexOf(value17) + 13);
				string text111 = text110;
				string text112 = text110;
				string value18 = "\"";
				string text113 = text111.Substring(0, text112.IndexOf(value18));
				string value19 = "questionText";
				text110 = text109.Substring(text109.IndexOf(value19) + 15);
				string text114 = text110;
				string text115 = text110;
				string value20 = "\"";
				string text116 = text114.Substring(0, text115.IndexOf(value20));
				if (num >= 5)
				{
					if (num == 5)
					{
						string text117 = text12;
						string text118 = "=NX2c13jn";
						text12 = text117 + text116 + text118;
						string[] array13 = new string[6] { text108, null, null, null, null, null };
						string text119 = "{\"questionId\":\"";
						array13[1] = text119;
						array13[2] = text113;
						string text120 = "\",\"questionText\":\"";
						array13[3] = text120;
						array13[4] = text116;
						string text121 = "\",\"userAnswer\":\"NX2c13jn\"}";
						array13[5] = text121;
						text108 = string.Concat(array13);
					}
				}
				else
				{
					string text122 = text12;
					string text123 = "=NX2c13jn&&";
					text12 = text122 + text116 + text123;
					string[] array14 = new string[6] { text108, null, null, null, null, null };
					string text124 = "{\"questionId\":\"";
					array14[1] = text124;
					array14[2] = text113;
					string text125 = "\",\"questionText\":\"";
					array14[3] = text125;
					array14[4] = text116;
					string text126 = "\",\"userAnswer\":\"NX2c13jn\"},";
					array14[5] = text126;
					text108 = string.Concat(array14);
				}
			}
			string text127 = text108;
			string text128 = "],\"secretAnswer\":\"";
			string text129 = "\"}";
			text108 = text127 + text128 + text33 + text129;
			text2 = getPostData(text11, text108);
			bool_30 = true;
			string text130 = "https://netportal.hdfcbank.com/services/proxy/current/setUserQuestionAns";
			string_88 = text130;
			string status7 = "Enter ProcessHDFC :- 7";
			Status = status7;
			string text131 = "channelIndicator#NB&fldAppId#RS&inEncryptValue#";
			string text132 = text46;
			string text133 = "&openMarketFlag#true";
			HeaderString = text131 + text132 + text133;
			if (!_Request(string_88, text2, string_89, ref cookieContainer, bool_64: true, 60000, 60000, ref string_90, ref string_91, ref Exception_))
			{
				string text134 = "HDFC Not Working : ";
				string_87 = text134 + Status;
				string text135 = string_87;
				string text136 = "\n";
				MessageBox.Show(text135 + text136 + string_91);
				return false;
			}
			bool_30 = true;
			string text137 = string_90;
			string text138 = string_90;
			string value21 = "outEncryptValue";
			text28 = text137.Substring(text138.IndexOf(value21) + 18);
			string text139 = text28;
			string text140 = text28;
			string value22 = "\"";
			text46 = text139.Substring(0, text140.IndexOf(value22));
			string string_92 = string_90;
			string string_93 = "secretAnswer";
			text28 = GetString(string_92, string_93);
			string text141 = text28.Substring(0, 12);
			string text142 = "XXXX";
			string text143 = ConvertToBase64(text141 + text142);
			string text144 = string_90;
			string text145 = string_90;
			string value23 = "rc\":";
			text28 = text144.Substring(text145.IndexOf(value23) + 4);
			string text146 = text28;
			string text147 = text28;
			string value24 = "}";
			string text148 = text146.Substring(0, text147.IndexOf(value24));
			string text149 = "}";
			string text150 = text148 + text149;
			string string_94 = string_90;
			string string_95 = "customer_encrypt_string";
			string @string = GetString(string_94, string_95);
			string string_96 = string_90;
			string string_97 = "input_encrypt_string";
			string string2 = GetString(string_96, string_97);
			string string_98 = string_90;
			string string_99 = "auth_encrypt_string";
			string string3 = GetString(string_98, string_99);
			string text151 = "https://netportal.hdfcbank.com/services/proxy/current/auth/otpRelayDynamicAuth";
			string_88 = text151;
			string[] array15 = new string[5] { @string, null, null, null, null };
			string text152 = "|||";
			array15[1] = text152;
			array15[2] = string2;
			string text153 = "|||";
			array15[3] = text153;
			array15[4] = string3;
			string text154 = string.Concat(array15);
			string requestToken3 = text143;
			string data2 = text154;
			string action3 = "DeCrypt";
			string text155 = encrypt_Password(requestToken3, data2, action3);
			string[] array16 = new string[1];
			string text156 = "|||";
			array16[0] = text156;
			string[] array17 = text155.Split(array16, StringSplitOptions.None);
			string[] array18 = new string[7] { text150, null, null, null, null, null, null };
			string text157 = "|||";
			array18[1] = text157;
			array18[2] = array17[0];
			string text158 = " |||";
			array18[3] = text158;
			array18[4] = array17[1];
			string text159 = "|||";
			array18[5] = text159;
			array18[6] = array17[2];
			text154 = string.Concat(array18);
			string requestToken4 = text11;
			string data3 = text154;
			string action4 = "Encrypt";
			string text160 = encrypt_Password(requestToken4, data3, action4);
			string[] array19 = new string[1];
			string text161 = "|||";
			array19[0] = text161;
			string[] array20 = text160.Split(array19, StringSplitOptions.None);
			string[] array21 = new string[11];
			string text162 = "{\"rc_encrypt_string\":\"";
			array21[0] = text162;
			array21[1] = array20[0];
			string text163 = "\",\"secretAnswer\":\"";
			array21[2] = text163;
			array21[3] = text33;
			string text164 = "\",\"customer_encrypt_string\":\"";
			array21[4] = text164;
			array21[5] = array20[1];
			string text165 = "\",\"input_encrypt_string\":\"";
			array21[6] = text165;
			array21[7] = array20[2];
			string text166 = "\",\"auth_encrypt_string\":\"";
			array21[8] = text166;
			array21[9] = array20[3];
			string text167 = "\"}";
			array21[10] = text167;
			text2 = string.Concat(array21);
			text2 = getPostData(text11, text2);
			string status8 = "Enter ProcessHDFC :- 8";
			Status = status8;
			string text168 = "channelIndicator#NB&fldAppId#RS&inEncryptValue#";
			string text169 = text46;
			string text170 = "&openMarketFlag#true";
			HeaderString = text168 + text169 + text170;
			if (!_Request(string_88, text2, string_89, ref cookieContainer, bool_64: true, 60000, 60000, ref string_90, ref string_91, ref Exception_))
			{
				string text171 = "HDFC Not Working : ";
				string_87 = text171 + Status;
				string text172 = string_87;
				string text173 = "\n";
				MessageBox.Show(text172 + text173 + string_91);
				return false;
			}
			string prompt = "Enter HDFC Bypass OTP Received on your Mobile.";
			string title = "Enter HDFC OTP";
			string text174 = Interaction.InputBox(prompt, title);
			bool_30 = true;
			string text175 = string_90;
			string text176 = string_90;
			string value25 = "outEncryptValue";
			text28 = text175.Substring(text176.IndexOf(value25) + 18);
			string text177 = text28;
			string text178 = text28;
			string value26 = "\"";
			text46 = text177.Substring(0, text178.IndexOf(value26));
			string text179 = "channelIndicator#NB&fldAppId#RS&inEncryptValue#";
			string text180 = text46;
			string text181 = "&openMarketFlag#true";
			HeaderString = text179 + text180 + text181;
			string string_100 = string_90;
			string string_101 = "secretAnswer";
			text28 = GetString(string_100, string_101);
			string text182 = text28.Substring(0, 12);
			string text183 = "XXXX";
			text143 = ConvertToBase64(text182 + text183);
			string text184 = string_90;
			string text185 = string_90;
			string value27 = "rc\":";
			text28 = text184.Substring(text185.IndexOf(value27) + 4);
			string text186 = text28;
			string text187 = text28;
			string value28 = "}";
			string text188 = text186.Substring(0, text187.IndexOf(value28));
			string text189 = "}";
			text150 = text188 + text189;
			string text190 = "https://netportal.hdfcbank.com/services/proxy/current/auth/sendOtpQnADynamicAuth";
			string_88 = text190;
			string text191 = array17[2];
			string oldValue = "mobile\":null";
			string text192 = "mobile\":\"";
			string text193 = "\"";
			string text194 = text191.Replace(oldValue, text192 + text174 + text193);
			string[] array22 = new string[7] { text150, null, null, null, null, null, null };
			string text195 = "|||";
			array22[1] = text195;
			array22[2] = array17[0];
			string text196 = " |||";
			array22[3] = text196;
			array22[4] = array17[1];
			string text197 = "|||";
			array22[5] = text197;
			array22[6] = text194;
			text154 = string.Concat(array22);
			string requestToken5 = text11;
			string data4 = text154;
			string action5 = "Encrypt";
			string text198 = encrypt_Password(requestToken5, data4, action5);
			string[] array23 = new string[1];
			string text199 = "|||";
			array23[0] = text199;
			array20 = text198.Split(array23, StringSplitOptions.None);
			string[] array24 = new string[11];
			string text200 = "{\"rc_encrypt_string\":\"";
			array24[0] = text200;
			array24[1] = array20[0];
			string text201 = "\",\"secretAnswer\":\"";
			array24[2] = text201;
			array24[3] = text33;
			string text202 = "\",\"customer_encrypt_string\":\"";
			array24[4] = text202;
			array24[5] = array20[1];
			string text203 = "\",\"input_encrypt_string\":\"";
			array24[6] = text203;
			array24[7] = array20[2];
			string text204 = "\",\"auth_encrypt_string\":\"";
			array24[8] = text204;
			array24[9] = array20[3];
			string text205 = "\"}";
			array24[10] = text205;
			text2 = string.Concat(array24);
			text2 = getPostData(text11, text2);
			string status9 = "Enter ProcessHDFC :- 9";
			Status = status9;
			string text206 = "channelIndicator#NB&fldAppId#RS&inEncryptValue#";
			string text207 = text46;
			string text208 = "&openMarketFlag#true";
			HeaderString = text206 + text207 + text208;
			if (!_Request(string_88, text2, string_89, ref cookieContainer, bool_64: true, 60000, 60000, ref string_90, ref string_91, ref Exception_))
			{
				string text209 = "HDFC Not Working : ";
				string_87 = text209 + Status;
				string text210 = string_87;
				string text211 = "\n";
				MessageBox.Show(text210 + text211 + string_91);
				return false;
			}
			bool_30 = true;
			string text212 = "https://netportal.hdfcbank.com/services/proxy/current/auth/verifyDynamicAuth";
			string_88 = text212;
			string text213 = string_90;
			string text214 = string_90;
			string value29 = "outEncryptValue";
			text28 = text213.Substring(text214.IndexOf(value29) + 18);
			string text215 = text28;
			string text216 = text28;
			string value30 = "\"";
			text46 = text215.Substring(0, text216.IndexOf(value30));
			string text217 = "channelIndicator#NB&fldAppId#RS&inEncryptValue#";
			string text218 = text46;
			string text219 = "&openMarketFlag#true";
			HeaderString = text217 + text218 + text219;
			string string_102 = string_90;
			string string_103 = "secretAnswer";
			text28 = GetString(string_102, string_103);
			string text220 = text28.Substring(0, 12);
			string text221 = "XXXX";
			text143 = ConvertToBase64(text220 + text221);
			string text222 = string_90;
			string text223 = string_90;
			string value31 = "rc\":";
			text28 = text222.Substring(text223.IndexOf(value31) + 4);
			string text224 = text28;
			string text225 = text28;
			string value32 = "}";
			string text226 = text224.Substring(0, text225.IndexOf(value32));
			string text227 = "}";
			text150 = text226 + text227;
			string string_104 = string_90;
			string string_105 = "transaction_encrypt_string";
			string string4 = GetString(string_104, string_105);
			string string_106 = string_90;
			string string_107 = "customerDetails_encrypt_string";
			string string5 = GetString(string_106, string_107);
			string string_108 = string_90;
			string string_109 = "auth_encrypt_string";
			string3 = GetString(string_108, string_109);
			string[] array25 = new string[5] { string4, null, null, null, null };
			string text228 = "|||";
			array25[1] = text228;
			array25[2] = string5;
			string text229 = "|||";
			array25[3] = text229;
			array25[4] = string3;
			text154 = string.Concat(array25);
			string requestToken6 = text143;
			string data5 = text154;
			string action6 = "DeCrypt";
			string text230 = encrypt_Password(requestToken6, data5, action6);
			string[] array26 = new string[1];
			string text231 = "|||";
			array26[0] = text231;
			array17 = text230.Split(array26, StringSplitOptions.None);
			string text232 = array17[2];
			string string_110 = text232;
			string string_111 = "name";
			string string6 = GetString(string_110, string_111);
			string string_112 = text232;
			string string_113 = "number";
			string string7 = GetString(string_112, string_113);
			string text233 = text232;
			string text234 = text232;
			string value33 = "txnId";
			text232 = text233.Substring(text234.IndexOf(value33) + 10);
			string string_114 = text232;
			string string_115 = "txnId";
			string string8 = GetString(string_114, string_115);
			string[] array27 = new string[13];
			string text235 = "{\"cq\":null,\"otp\":null,\"digitalCertificate\":null,\"dc\":{\"number\":\"";
			array27[0] = text235;
			array27[1] = string7;
			string text236 = "\",\"name\":\"";
			array27[2] = text236;
			array27[3] = string6;
			string text237 = "\",\"pin\":\"";
			array27[4] = text237;
			array27[5] = text10;
			string text238 = "\",\"year\":\"";
			array27[6] = text238;
			array27[7] = text9;
			string text239 = "\",\"month\":\"";
			array27[8] = text239;
			array27[9] = text8;
			string text240 = "\"},\"cc\":{},\"extras\":{\"userStatus\":\"UNLOCKED\",\"eventType\":\"CHANGE_AUTH_DATA\",\"ruleName\":\"Change Auth Data Authenticate using OTP and PIN\",\"riskScore\":\"310\",\"credentialType\":\"SMS\",\"statusCode\":\"200\",\"ipAddress\":\"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/69.0.3497.100 Safari/537.36\",\"requestType\":\"Analyze\",\"fromRouteId\":\"changeUserQuestionAns\",\"rsaTransactionId\":null,\"accept\":null,\"referrer\":null,\"acceptLanguage\":null,\"rsauser\":null,\"rsacredential\":null,\"parentKey\":\"transaction\",\"nextMode\":null,\"txnId\":null,\"isChallengeCalled\":\"Y\",\"authMethods\":[\"5\"],\"otherAccountType\":null,\"transferMode\":null,\"ethnicity\":null,\"isDynamicAuth\":\"Y\",\"enstageExtRefNo\":null,\"enstageRRN\":null},\"dynamicAuthenticationModel\":{\"txnId\":\"";
			array27[10] = text240;
			array27[11] = string8;
			string text241 = "\",\"twoFactorFlag\":\"N\",\"currentMode\":\"DebitCard\",\"parentKey\":\"transaction\",\"indexValue\":\"1\",\"authList\":[\"2\",\"4\"],\"deliveryMode\":{\"Channel\":\"SMS\"},\"modeList\":[\"RSA\",\"DebitCard\"],\"nilTxnMode\":null},\"rsaUserStatus\":null,\"rsaEventType\":null,\"rsaRuleName\":null,\"rsaRiskScore\":null,\"rsaStatusCode\":null,\"rsaIpAddress\":null,\"rsaRequestType\":null,\"rc\":{\"errorcode\":\"5\",\"message\":\"Debit Card pin authentication.\",\"returncode\":\"5\",\"dcStatus\":null,\"otpStatus\":null,\"tptLimitExhausted\":0.0},\"rsaCredentialType\":null}";
			array27[12] = text241;
			string text242 = string.Concat(array27);
			string[] array28 = new string[7] { text150, null, null, null, null, null, null };
			string text243 = "|||";
			array28[1] = text243;
			array28[2] = array17[0];
			string text244 = " |||";
			array28[3] = text244;
			array28[4] = array17[1];
			string text245 = "|||";
			array28[5] = text245;
			array28[6] = text242;
			text154 = string.Concat(array28);
			string requestToken7 = text11;
			string data6 = text154;
			string action7 = "Encrypt";
			string text246 = encrypt_Password(requestToken7, data6, action7);
			string[] array29 = new string[1];
			string text247 = "|||";
			array29[0] = text247;
			array20 = text246.Split(array29, StringSplitOptions.None);
			string[] array30 = new string[11];
			string text248 = "{\"rc_encrypt_string\":\"";
			array30[0] = text248;
			array30[1] = array20[0];
			string text249 = "\",\"secretAnswer\":\"";
			array30[2] = text249;
			array30[3] = text33;
			string text250 = "\",\"transaction_encrypt_string\":\"";
			array30[4] = text250;
			array30[5] = array20[1];
			string text251 = "\",\"customerDetails_encrypt_string\":\"";
			array30[6] = text251;
			array30[7] = array20[2];
			string text252 = "\",\"auth_encrypt_string\":\"";
			array30[8] = text252;
			array30[9] = array20[3];
			string text253 = "\"}";
			array30[10] = text253;
			text2 = string.Concat(array30);
			text2 = getPostData(text11, text2);
			string status10 = "Enter ProcessHDFC :- 10";
			Status = status10;
			string text254 = "channelIndicator#NB&fldAppId#RS&inEncryptValue#";
			string text255 = text46;
			string text256 = "&openMarketFlag#true";
			HeaderString = text254 + text255 + text256;
			if (!_Request(string_88, text2, string_89, ref cookieContainer, bool_64: true, 60000, 60000, ref string_90, ref string_91, ref Exception_))
			{
				goto IL_1df4;
			}
			string text257 = string_90;
			string value34 = "answers have been successfully updated";
			if (!text257.Contains(value34))
			{
				goto IL_1df4;
			}
			string text258 = string_90;
			string value35 = "Your secure access question and answers have been successfully updated";
			if (text258.Contains(value35))
			{
				string_87 = text12;
				string text259 = "Your OTP Bypassed Successfully! Please use HDFC after 15 minutes.\r\n\r\nAapka OTP bypass ho gaya he par kam se kam 15 minutes ke baad HDFC use kijiye.";
				MessageBox.Show(text259);
				flag = true;
			}
			goto end_IL_00aa;
			IL_1cec:
			string string_116 = string_90;
			string string_117 = "secretAnswer";
			text28 = GetString(string_116, string_117);
			string text260 = text28.Substring(0, 12);
			string text261 = "XXXX";
			string requestToken8 = ConvertToBase64(text260 + text261);
			string string_118 = string_90;
			string string_119 = "rc_encrypt_string";
			text28 = GetString(string_118, string_119);
			string data7 = text28;
			string action8 = "DeCrypt";
			encrypt_Password(requestToken8, data7, action8);
			string text262 = "HDFC Not Working : ";
			string_87 = text262 + Status;
			string text263 = string_87;
			string text264 = "\n";
			MessageBox.Show(text263 + text264 + string_91);
			return false;
			IL_1df4:
			string text265 = string.Empty;
			string text266 = string_90;
			string value36 = "Failure";
			if (text266.IndexOf(value36) > 0)
			{
				string string_120 = string_90;
				string string_121 = "message";
				text28 = GetString(string_120, string_121);
				text265 = ConvertToBase64(text28.Substring(0, 12));
			}
			string text267 = "HDFC Not Working : ";
			string_87 = text267 + Status;
			string text268 = string_87;
			string text269 = "\n";
			MessageBox.Show(text268 + text269 + text265);
			return false;
			end_IL_00aa:;
		}
		catch (Exception ex)
		{
			string_87 = ex.Message;
		}
		if (!flag)
		{
			bool_30 = true;
			string text270 = "https://netportal.hdfcbank.com/j_spring_security_logout?portalName=portal";
			string_88 = text270;
			string text271 = string_90;
			string text272 = string_90;
			string value37 = "outEncryptValue";
			string text273 = text271.Substring(text272.IndexOf(value37) + 18);
			string value38 = "\"";
			string text274 = text273.Substring(0, text273.IndexOf(value38));
			string text275 = "channelIndicator#NB&fldAppId#RS&inEncryptValue#";
			string text276 = "&openMarketFlag#true";
			HeaderString = text275 + text274 + text276;
			_Request(string_88, "", string_89, ref cookieContainer, bool_64: true, 60000, 60000, ref string_90, ref string_91, ref Exception_);
		}
		return flag;
	}

	private string getPostData(string token, string data)
	{
		string result = "";
		try
		{
			string action = "Encrypt";
			string text = encrypt_Password(token, data, action);
			string text2 = text.Substring(text.Length - 10);
			string text3 = "\"content_length\":\"";
			string text4 = "\"";
			string newString = text3 + text2 + text4;
			result = AddStringToJson(data, newString);
		}
		catch
		{
		}
		return result;
	}

	private bool _Request(string string_86, string string_87, string string_88, ref CookieContainer cookieContainer_2, bool bool_64, int int_28, int int_29, ref string string_89, ref string string_90, ref WebException webException_1)
	{
		int num = 0;
		int num2 = 0;
		int num3;
		while (true)
		{
			string_90 = "";
			string_89 = "";
			webException_1 = null;
			num3 = 0;
			HttpWebResponse httpWebResponse = null;
			string text = "";
			try
			{
				ServicePointManager.Expect100Continue = false;
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string_86);
				httpWebRequest.ProtocolVersion = HttpVersion.Version11;
				ServicePointManager.ServerCertificateValidationCallback = (object object_0, X509Certificate x509Certificate_0, X509Chain x509Chain_0, SslPolicyErrors sslPolicyErrors_0) => true;
				HttpRequestCachePolicy cachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
				httpWebRequest.CachePolicy = cachePolicy;
				httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				httpWebRequest.Timeout = int_28;
				httpWebRequest.ReadWriteTimeout = int_29;
				if (cookieContainer_2 == null)
				{
					cookieContainer_2 = new CookieContainer();
				}
				httpWebRequest.CookieContainer = cookieContainer_2;
				httpWebRequest.KeepAlive = true;
				string accept = "text/html, application/xhtml+xml, application/xml; q=0.9, image/webp, image/apng, */*; q=0.8";
				httpWebRequest.Accept = accept;
				string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/69.0.3497.100 Safari/537.36";
				httpWebRequest.UserAgent = userAgent;
				WebHeaderCollection headers = httpWebRequest.Headers;
				string name = "Accept-Language";
				string value = "en-GB, en-US; q=0.9, en; q=0.8";
				headers.Add(name, value);
				string contentType = "application/x-www-form-urlencoded;";
				httpWebRequest.ContentType = contentType;
				if (bool_29)
				{
					bool_29 = false;
					string accept2 = "application/json";
					httpWebRequest.Accept = accept2;
					string contentType2 = "application/x-www-form-urlencoded; charset=utf-8";
					httpWebRequest.ContentType = contentType2;
				}
				if (bool_30)
				{
					bool_30 = false;
					string accept3 = "text/html, application/xhtml+xml, application/xml; q=0.9, image/webp, image/apng, */*; q=0.8, application/json";
					httpWebRequest.Accept = accept3;
					string contentType3 = "application/json; charset=utf-8";
					httpWebRequest.ContentType = contentType3;
				}
				if (!string.IsNullOrEmpty(HeaderString))
				{
					string headerString = HeaderString;
					string delimiter = "&";
					string[] array = Strings.Split(headerString, delimiter);
					int num4 = Information.UBound(array);
					for (int i = 0; i <= num4; i++)
					{
						string expression = array[i];
						string delimiter2 = "#";
						string[] array2 = Strings.Split(expression, delimiter2);
						httpWebRequest.Headers.Set(array2[0], array2[1]);
					}
				}
				if (!string.IsNullOrEmpty(string_88))
				{
					httpWebRequest.Referer = string_88;
				}
				if (string.IsNullOrEmpty(string_87))
				{
					string method = "GET";
					httpWebRequest.Method = method;
				}
				else
				{
					string method2 = "POST";
					httpWebRequest.Method = method2;
					byte[] bytes = Encoding.UTF8.GetBytes(string_87);
					httpWebRequest.ContentLength = bytes.Length;
					httpWebRequest.GetRequestStream().Write(bytes, 0, bytes.Length);
				}
				httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				if (httpWebResponse.StatusCode == HttpStatusCode.Found || httpWebResponse.StatusCode == HttpStatusCode.MovedPermanently)
				{
					WebHeaderCollection headers2 = httpWebResponse.Headers;
					string name2 = "Location";
					string text2 = headers2[name2].ToString();
					string value2 = "error";
					if (text2.Contains(value2) && num2 < 20)
					{
						Thread.Sleep(200);
						num2++;
						HttpWebResponse httpWebResponse2 = httpWebResponse;
						string headerName = "Location";
						text = httpWebResponse2.GetResponseHeader(headerName);
						httpWebResponse.Close();
						httpWebResponse = null;
						continue;
					}
				}
				string string_91 = "";
				method_96(httpWebResponse, ref string_91);
				foreach (Cookie cookie3 in httpWebResponse.Cookies)
				{
					string name3 = cookie3.Name;
					string text3 = "Authorization";
					if (name3 == text3)
					{
						CookieContainer cookieContainer = cookieContainer_2;
						string name4 = "Authorization";
						Cookie cookie2 = new Cookie(name4, cookie3.Value);
						string domain = "hdfcbank.com";
						cookie2.Domain = domain;
						string path = "/";
						cookie2.Path = path;
						cookieContainer.Add(cookie2);
					}
				}
				if (bool_11)
				{
					bool_11 = false;
					HttpWebResponse httpWebResponse3 = httpWebResponse;
					string headerName2 = "Location";
					string_16 = httpWebResponse3.GetResponseHeader(headerName2);
				}
				using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
				{
					if (bool_64)
					{
						text = streamReader.ReadToEnd();
					}
					else
					{
						httpWebRequest.Abort();
					}
				}
				string_89 = text;
				num3 = 1;
			}
			catch (WebException ex)
			{
				num3 = 0;
				webException_1 = ex;
				string message = ex.Message;
				bool flag = ex.Response != null;
				string text4 = "";
				num++;
				HttpStatusCode httpStatusCode = HttpStatusCode.OK;
				if (flag)
				{
					httpStatusCode = ((HttpWebResponse)ex.Response).StatusCode;
					try
					{
						string text5 = ":";
						text4 = text5 + new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
					}
					catch
					{
					}
				}
				string[] array3 = new string[7];
				string text6 = "<StatusCode>";
				array3[0] = text6;
				array3[1] = httpStatusCode.ToString();
				string text7 = "</StatusCode>\t<ErrorCode>";
				array3[2] = text7;
				array3[3] = message;
				string text8 = "</ErrorCode>\t<ResponseCode>";
				array3[4] = text8;
				array3[5] = text4;
				string text9 = "</ResponseCode>";
				array3[6] = text9;
				string_90 = string.Concat(array3);
				if (num >= 9)
				{
					break;
				}
				string value3 = "The remote name could not be resolved";
				bool flag2 = message.Contains(value3);
				string value4 = "Unable to connect to the remote server";
				if (flag2 | message.Contains(value4))
				{
					string text10 = message.ToUpper();
					string value5 = "SERVICEUNAVAILABLE";
					if (!text10.Contains(value5))
					{
						Thread.Sleep(1000);
						break;
					}
					Thread.Sleep(2000);
					continue;
				}
				string value6 = "The underlying connection was closed:";
				if (!message.Contains(value6))
				{
					string value7 = "The request was aborted: Could not create SSL/TLS secure channel.";
					if (message.Contains(value7))
					{
						if (num % 2 == 0)
						{
							string text11 = "Tls12";
							string_52 = text11;
						}
						if (num >= 5)
						{
							break;
						}
						continue;
					}
					string value8 = "The operation has timed out";
					if (!message.Contains(value8))
					{
						string value9 = "(406) Not Acceptable";
						if (message.Contains(value9))
						{
							break;
						}
						string value10 = "(401) Unauthorized";
						if (message.Contains(value10))
						{
							break;
						}
						string value11 = "(400) Bad Request";
						if (message.Contains(value11))
						{
							break;
						}
						string value12 = "(404) Not Found";
						bool flag3 = message.Contains(value12);
						string value13 = "(409) Conflict";
						if (!(flag3 | message.Contains(value13)))
						{
							string value14 = "(500) Internal Server Error";
							if (message.Contains(value14))
							{
								continue;
							}
							string value15 = "(502) Bad Gateway";
							if (message.Contains(value15))
							{
								continue;
							}
							string value16 = "(503) Server Unavailable";
							if (message.Contains(value16))
							{
								continue;
							}
							string value17 = "(504) Gateway Timeout";
							if (message.Contains(value17))
							{
								continue;
							}
						}
					}
					else if (num < 5)
					{
						continue;
					}
					break;
				}
				string value18 = "An unexpected error occurred on a send";
				if (!message.Contains(value18))
				{
					string value19 = "A connection that was expected to be kept alive was closed by the server";
					if (!message.Contains(value19))
					{
						string value20 = "An unexpected error occurred on a receive";
						message.Contains(value20);
					}
				}
				if (num % 2 == 0)
				{
					string text12 = "Tls12";
					string_52 = text12;
				}
				if (num >= 5)
				{
					break;
				}
				continue;
			}
			catch (Exception ex2)
			{
				num3 = 0;
				string_90 = ex2.Message;
				if (num < 3)
				{
					string text13 = string_90;
					string value21 = "String reference not set to an instance";
					if (text13.Contains(value21))
					{
						string_90 = "";
						num++;
						continue;
					}
				}
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
			break;
		}
		return num3 != 0;
	}

	private string method_96(HttpWebResponse httpWebResponse_0, ref string string_86)
	{
		string text = "";
		try
		{
			foreach (Cookie cookie in httpWebResponse_0.Cookies)
			{
				string name = cookie.Name;
				string text2 = "=";
				string text3 = name + text2 + cookie.Value;
				if (cookie.Name == string_86)
				{
					string_86 = cookie.Value;
				}
				string text4 = text;
				string text5 = "&&";
				text = text4 + text3 + text5;
			}
			return text;
		}
		catch
		{
			return text;
		}
	}

	private static string ConvertToBase64(string originalString)
	{
		if (string.IsNullOrEmpty(originalString))
		{
			return string.Empty;
		}
		byte[] bytes = Encoding.UTF8.GetBytes(originalString);
		return Convert.ToBase64String(bytes);
	}

	private string GetString(string string_86, string string_87)
	{
		string result = "";
		try
		{
			string text = "\"";
			string text2 = string_86.Substring(string_86.IndexOf(text + string_87));
			string text3 = text2.Substring(text2.IndexOf(string_87) + (string_87.Length + 3));
			string text4 = text3;
			string text5 = text3;
			string value = "\"";
			text3 = text4.Substring(0, text5.IndexOf(value));
			result = text3;
			return result;
		}
		catch
		{
			return result;
		}
	}

	private static string AddStringToJson(string originalJson, string newString)
	{
		int num = originalJson.LastIndexOf('}');
		if (num == -1)
		{
			return originalJson;
		}
		StringBuilder stringBuilder = new StringBuilder(originalJson);
		string text = ",";
		stringBuilder.Insert(num, text + newString);
		return stringBuilder.ToString();
	}

	internal bool PayProcess(string text4, string string_87, ref string string_89, ref string string_90, ref CookieContainer cookieContainer, UpdateTStatus updateTStatus_2, string tCntrlName_)
	{
		if (class3_0 == null)
		{
			class3_0 = new clsPostData();
		}
		string[] array = new string[1];
		string text5 = "||";
		array[0] = text5;
		string[] array2 = string_87.Split(array, StringSplitOptions.None);
		string text6 = array2[0].Trim();
		string text7 = array2[1];
		if (array2.Length > 2)
		{
		}
		string text8 = "";
		string string_91 = "";
		string text9 = "";
		string text10 = "https://www.irctc.co.in/eticketing/jpInput.jsf?cid=1";
		string string_92 = text10;
		string string_93 = "";
		string string_94 = "";
		string text11 = "";
		string text12 = "";
		string text13 = "";
		bool flag = false;
		try
		{
			string text14 = "";
			if (text6.Length < 10)
			{
				string text15 = "00";
				text14 = text15 + text6.Length;
			}
			else
			{
				string text16 = "0";
				text14 = text16 + text6.Length;
			}
			if (text7.Length < 10)
			{
				string text17 = text14;
				string text18 = "00";
				text14 = text17 + text18 + text7.Length;
			}
			else
			{
				string text19 = text14;
				string text20 = "0";
				text14 = text19 + text20 + text7.Length;
			}
			text13 = text6 + text7 + text14;
			if (updateTStatus_2 != null)
			{
				string status = "Init. HDFC_NB(3/8)";
				updateTStatus_2.BeginInvoke(1, status, tCntrlName_, null, null);
			}
			text9 = class3_0.Method_SerialInp(text4, ref string_91, bool_14: false);
			if (_Request(string_91, text9, string_92, ref cookieContainer, bool_64: true, 60000, 60000, ref string_93, ref string_94, ref Exception_))
			{
				string text21 = string_93;
				string value = "merchantData";
				if (text21.Contains(value))
				{
					string text22 = string_93;
					string text23 = string_93;
					string value2 = "name>page";
					string text24 = text22.Substring(text23.IndexOf(value2) + 10);
					string text25 = text24;
					string text26 = text24;
					string value3 = "<";
					string text27 = text25.Substring(0, text26.IndexOf(value3));
					string text28 = string_93;
					string text29 = string_93;
					string value4 = "ClientCode";
					text24 = text28.Substring(text29.IndexOf(value4) + 13);
					string text30 = text24;
					string text31 = text24;
					string value5 = "\"";
					string text32 = text30.Substring(0, text31.IndexOf(value5));
					string text33 = string_93;
					string text34 = string_93;
					string value6 = "DynamicUrl";
					text24 = text33.Substring(text34.IndexOf(value6) + 13);
					string text35 = text24;
					string text36 = text24;
					string value7 = "\"";
					string text37 = text35.Substring(0, text36.IndexOf(value7));
					string text38 = text37;
					string oldValue = "\\";
					text37 = text38.Replace(oldValue, "");
					DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
					string text39 = (DateTime.UtcNow - dateTime).TotalMilliseconds.ToString();
					text11 = text39.Substring(0, 13);
					string text40 = text39.Substring(0, 12);
					string text41 = "XXXX";
					text8 = ConvertToBase64(text40 + text41);
					string text42 = string_93;
					string text43 = string_93;
					string value8 = "merchantData";
					text24 = text42.Substring(text43.IndexOf(value8) + 1);
					string text44 = text24;
					string text45 = text24;
					string value9 = "var data =";
					text24 = text44.Substring(text45.IndexOf(value9) + 12);
					string text46 = text24;
					string text47 = text24;
					string value10 = "';";
					text9 = text46.Substring(0, text47.IndexOf(value10));
					string text48 = text9;
					string oldValue2 = "\\";
					text9 = text48.Replace(oldValue2, "");
					string text49 = "\"secretAnswer\":\"";
					string text50 = text39.Substring(0, 13);
					string text51 = "\"";
					string newString = text49 + text50 + text51;
					text9 = AddStringToJson(text9, newString);
					string text52 = text9;
					string text53 = text9;
					string value11 = "DisplayDetails\":\"\",\"Date";
					text24 = text52.Substring(text53.IndexOf(value11) + 27);
					string text54 = text24;
					string text55 = text24;
					string value12 = "\"";
					string text56 = text54.Substring(0, text55.IndexOf(value12));
					string string_95 = text9;
					string string_96 = "TxnAmount";
					string @string = GetString(string_95, string_96);
					string string_97 = text9;
					string string_98 = "MerchantRefNo";
					text12 = GetString(string_97, string_98);
					text9 = getPostData(text8, text9);
					bool_30 = true;
					string text57 = "https://netportal.hdfcbank.com/services/epiproxy/current/epiMerchantValidator";
					string_91 = text57;
					string status2 = "Enter ProcessHDFC :- 2";
					Status = status2;
					string headerString = "channelIndicator#NB&fldAppId#XT";
					HeaderString = headerString;
					if (updateTStatus_2 != null)
					{
						string status3 = "Init. HDFC_NB(4/8)";
						updateTStatus_2.BeginInvoke(1, status3, tCntrlName_, null, null);
					}
					if (_Request(string_91, text9, string_92, ref cookieContainer, bool_64: true, 60000, 60000, ref string_93, ref string_94, ref Exception_))
					{
						string text58 = string_93;
						string value13 = "dateString";
						if (text58.Contains(value13))
						{
							string text59 = "https://netportal.hdfcbank.com/services/epiproxy/current/customerValidate";
							string_91 = text59;
							text9 = "";
							bool_30 = true;
							string[] array3 = new string[7];
							string text60 = "channelIndicator#NB&fldAppId#XT&Merchantcode#PAYTMIRCTCEC&Merchantrefno#";
							array3[0] = text60;
							array3[1] = text12;
							string text61 = "&Ans#";
							array3[2] = text61;
							array3[3] = text11;
							string text62 = "&Bnkcustid#";
							array3[4] = text62;
							string requestToken = text8;
							string action = "Encrypt";
							array3[5] = encrypt_Password(requestToken, text6, action);
							string text63 = "&Flextobbloginflag#true&Isflagrsa#Y&Openmarketflag#true&Req-X-Auth-Token#JWT_COOKIE";
							array3[6] = text63;
							HeaderString = string.Concat(array3);
							if (_Request(string_91, text9, string_92, ref cookieContainer, bool_64: true, 60000, 60000, ref string_93, ref string_94, ref Exception_))
							{
								string text64 = string_93;
								string value14 = "custId";
								if (text64.Contains(value14))
								{
									string text65 = string_93;
									string value15 = "altText";
									if (text65.Contains(value15))
									{
										string text66 = string_93;
										string text67 = string_93;
										string value16 = "outEncryptValue";
										text24 = text66.Substring(text67.IndexOf(value16) + 18);
										string text68 = text24;
										string text69 = text24;
										string value17 = "\"";
										string text70 = text68.Substring(0, text69.IndexOf(value17));
										string text71 = string_93;
										string text72 = string_93;
										string value18 = "rc_encrypt_string";
										text24 = text71.Substring(text72.IndexOf(value18) + 20);
										string text73 = text24;
										string text74 = text24;
										string value19 = "\"";
										text73.Substring(0, text74.IndexOf(value19));
										string string_99 = string_93;
										string string_100 = "secretAnswer";
										text24 = GetString(string_99, string_100);
										string text75 = text24.Substring(0, 12);
										string text76 = "XXXX";
										string text77 = ConvertToBase64(text75 + text76);
										string requestToken2 = text8;
										string data = text13;
										string action2 = "Encrypt";
										string value20 = encrypt_Password(requestToken2, data, action2);
										string text78 = "https://netportal.hdfcbank.com/j_spring_security_check_epi";
										string_91 = text78;
										string[] array4 = new string[6];
										string text79 = "data_encrypt=";
										array4[0] = text79;
										array4[1] = WebUtility.UrlEncode(value20);
										string text80 = "&portal_name=portal&page_name=page_";
										array4[2] = text80;
										array4[3] = text27;
										string text81 = "&secretAnswer=";
										array4[4] = text81;
										array4[5] = text11;
										text9 = string.Concat(array4);
										bool_29 = true;
										string[] array5 = new string[6];
										string text82 = "channelIndicator#NB&fldAppId#XT&Merchantcode#PAYTMIRCTCEC&Merchantrefno#";
										array5[0] = text82;
										array5[1] = text12;
										string text83 = "&Ans#";
										array5[2] = text83;
										array5[3] = text11;
										string text84 = "&inEncryptValue#";
										array5[4] = text84;
										array5[5] = text70;
										HeaderString = string.Concat(array5);
										if (updateTStatus_2 != null)
										{
											string status4 = "Init. HDFC_NB(5/8)";
											updateTStatus_2.BeginInvoke(1, status4, tCntrlName_, null, null);
										}
										if (_Request(string_91, text9, string_92, ref cookieContainer, bool_64: true, 60000, 60000, ref string_93, ref string_94, ref Exception_))
										{
											string text85 = string_93;
											string value21 = "fullname";
											if (text85.Contains(value21))
											{
												string string_101 = string_93;
												string string_102 = "outEncryptValue";
												text70 = GetString(string_101, string_102);
												string text86 = string_93;
												string text87 = string_93;
												string value22 = "registrationDateNB";
												text24 = text86.Substring(text87.IndexOf(value22) + 20);
												string text88 = text24;
												string text89 = text24;
												string value23 = ",";
												string text90 = text88.Substring(0, text89.IndexOf(value23));
												string text91 = string_93;
												string text92 = string_93;
												string value24 = "lastLoggedIn";
												text24 = text91.Substring(text92.IndexOf(value24) + 14);
												string text93 = text24;
												string text94 = text24;
												string value25 = "}";
												string text95 = text93.Substring(0, text94.IndexOf(value25));
												string text96 = string_93;
												string text97 = string_93;
												string value26 = "mobileNumber";
												text24 = text96.Substring(text97.IndexOf(value26) + 14);
												string text98 = text24;
												string text99 = text24;
												string value27 = "\"";
												string text100 = text98.Substring(0, text99.IndexOf(value27));
												string text101 = string_93;
												string text102 = string_93;
												string value28 = "email";
												text24 = text101.Substring(text102.IndexOf(value28) + 7);
												string text103 = text24;
												string text104 = text24;
												string value29 = "\"";
												string text105 = text103.Substring(0, text104.IndexOf(value29));
												bool_30 = true;
												string text106 = "https://netportal.hdfcbank.com/services/epiproxy/current/authenticateRSALogin";
												string_91 = text106;
												string text107 = "https://netportal.hdfcbank.com";
												string_92 = text107;
												string[] array6 = new string[7];
												string text108 = "{\"bnkCustId\":\"";
												array6[0] = text108;
												array6[1] = text6;
												string text109 = "\",\"MerchantCode\":\"PAYTMIRCTCEC\",\"MerchantRefNo\":\"";
												array6[2] = text109;
												array6[3] = text12;
												string text110 = "\",\"secretAnswer\":\"";
												array6[4] = text110;
												array6[5] = text11;
												string text111 = "\"}";
												array6[6] = text111;
												text9 = string.Concat(array6);
												text9 = getPostData(text8, text9);
												string[] array7 = new string[6];
												string text112 = "channelIndicator#NB&fldAppId#XT&Merchantcode#PAYTMIRCTCEC&Merchantrefno#";
												array7[0] = text112;
												array7[1] = text12;
												string text113 = "&Ans#";
												array7[2] = text113;
												array7[3] = text11;
												string text114 = "&inEncryptValue#";
												array7[4] = text114;
												array7[5] = text70;
												HeaderString = string.Concat(array7);
												if (updateTStatus_2 != null)
												{
													string status5 = "Init. HDFC_NB(6/8)";
													updateTStatus_2.BeginInvoke(1, status5, tCntrlName_, null, null);
												}
												if (_Request(string_91, text9, string_92, ref cookieContainer, bool_64: true, 60000, 60000, ref string_93, ref string_94, ref Exception_))
												{
													string text115 = string_93;
													string value30 = "errorcode\":\"0\",\"message\":\"\",\"returncode";
													if (text115.Contains(value30))
													{
														bool_30 = true;
														string text116 = string_93;
														string text117 = string_93;
														string value31 = "outEncryptValue";
														text24 = text116.Substring(text117.IndexOf(value31) + 18);
														string text118 = text24;
														string text119 = text24;
														string value32 = "\"";
														text70 = text118.Substring(0, text119.IndexOf(value32));
														string text120 = "https://netportal.hdfcbank.com/services/epiproxy/current/fetchCustAndMerchantDetails";
														string_91 = text120;
														string[] array8 = new string[35];
														string text121 = "{\"isCUGValidationRequired\":\"N\",\"merchantCode\":\"PAYTMIRCTCEC\",\"rsaReqDynamicURL\":\"";
														array8[0] = text121;
														array8[1] = text37;
														string text122 = "\",\"rsaResDynamicFlg\":\"Y\",\"rsaResDynaSuccessURL\":null,\"rsaResDynaFailureURL\":null,\"rsaResStaticSucUrl\":null,\"rsaResStaticFailUrl\":null,\"typeCheckSum\":\"B\",\"clientCode\":\"";
														array8[2] = text122;
														array8[3] = text32;
														string text123 = "\",\"mercDatTxn\":\"";
														array8[4] = text123;
														array8[5] = text56;
														string text124 = "\",\"mercRefNo\":\"";
														array8[6] = text124;
														array8[7] = text12;
														string text125 = "\",\"txnAmt\":\"";
														array8[8] = text125;
														array8[9] = @string;
														string text126 = "\",\"txnAmtSc\":\"0\",\"txnCodCcy\":\"INR\",\"failureStaticFlg\":\"N\",\"successStaticFlg\":\"N\",\"MerchantCode\":\"PAYTMIRCTCEC\",\"MerchantRefNo\":\"";
														array8[10] = text126;
														array8[11] = text12;
														string text127 = "\",\"toAccountNo\":\"\",\"totalAmount\":\"";
														array8[12] = text127;
														array8[13] = @string;
														string text128 = "\",\"PrmRequest\":{\"ACHBatchType\":\"\",\"AcctStat\":\"N\",\"AuthorizationType\":\"D\",\"CashInd\":\"\",\"ClientLanguage\":\"false\",\"CreditorAliasLastUpdateDate\":\"";
														array8[14] = text128;
														array8[15] = text56;
														string text129 = "\",\"CustTranAmt1\":null,\"EventDetail1\":\"";
														array8[16] = text129;
														array8[17] = text32;
														string text130 = "\",\"EventTyp\":\"\",\"MsgSrc\":\"PAYTMIRCTCEC\",\"OrgnlCrncyCode\":\"INR\",\"PostDate\":\"";
														array8[18] = text130;
														array8[19] = text56;
														string text131 = "\",\"PriAcctNum\":\"\",\"RETLID\":\"PAYTMIRCTCEC\",\"RefNum\":\"";
														array8[20] = text131;
														array8[21] = text12;
														string text132 = "\",\"RegulatoryReporting\":\"\",\"TranAmt1\":\"";
														array8[22] = text132;
														array8[23] = @string;
														string text133 = "\",\"TranAmt2\":\"0\",\"TranAmt4\":\"\",\"TranAuthSrc\":\"Y\",\"TranRsncode\":\"\",\"TrckIndx\":\"Y\",\"SecAcctNum\":\"\",\"WireCreationDateTime\":\"";
														array8[24] = text133;
														array8[25] = text90;
														string text134 = "\",\"LastAdrsChngDate\":\"";
														array8[26] = text134;
														array8[27] = text95;
														string text135 = "\",\"UnstructuredRemittanceInfo2\":\"";
														array8[28] = text135;
														array8[29] = text37;
														string text136 = "\",\"UnstructuredRemittanceInfo1\":\"";
														array8[30] = text136;
														array8[31] = text37;
														string text137 = "\"},\"secretAnswer\":\"";
														array8[32] = text137;
														array8[33] = text11;
														string text138 = "\"}";
														array8[34] = text138;
														text9 = string.Concat(array8);
														text9 = getPostData(text8, text9);
														string[] array9 = new string[6];
														string text139 = "channelIndicator#NB&fldAppId#XT&Merchantcode#PAYTMIRCTCEC&Merchantrefno#";
														array9[0] = text139;
														array9[1] = text12;
														string text140 = "&Ans#";
														array9[2] = text140;
														array9[3] = text11;
														string text141 = "&inEncryptValue#";
														array9[4] = text141;
														array9[5] = text70;
														HeaderString = string.Concat(array9);
														if (updateTStatus_2 != null)
														{
															string status6 = "Init. HDFC_NB(7/8)";
															updateTStatus_2.BeginInvoke(1, status6, tCntrlName_, null, null);
														}
														if (_Request(string_91, text9, string_92, ref cookieContainer, bool_64: true, 60000, 60000, ref string_93, ref string_94, ref Exception_))
														{
															string text142 = string_93;
															string value33 = "branch";
															if (text142.Contains(value33))
															{
																bool_30 = true;
																string text143 = string_93;
																string text144 = string_93;
																string value34 = "outEncryptValue";
																text24 = text143.Substring(text144.IndexOf(value34) + 18);
																string text145 = text24;
																string text146 = text24;
																string value35 = "\"";
																text70 = text145.Substring(0, text146.IndexOf(value35));
																string text147 = string_93;
																string text148 = string_93;
																string value36 = "codAcctNo";
																text24 = text147.Substring(text148.IndexOf(value36) + 12);
																string text149 = text24;
																string text150 = text24;
																string value37 = "\"";
																string text151 = text149.Substring(0, text150.IndexOf(value37));
																string string_103 = string_93;
																string string_104 = "number_encrypt";
																string string2 = GetString(string_103, string_104);
																string string_105 = string_93;
																string string_106 = "balance_encrypt";
																string string3 = GetString(string_105, string_106);
																string string_107 = string_93;
																string string_108 = "secretAnswer";
																text24 = GetString(string_107, string_108);
																string text152 = text24.Substring(0, 12);
																string text153 = "XXXX";
																text77 = ConvertToBase64(text152 + text153);
																string requestToken3 = text77;
																string text154 = string3;
																string text155 = "|||";
																string data2 = text154 + text155 + string2;
																string action3 = "DeCrypt";
																string3 = encrypt_Password(requestToken3, data2, action3);
																string text156 = string3;
																string[] array10 = new string[1];
																string text157 = "|||";
																array10[0] = text157;
																string[] array11 = text156.Split(array10, StringSplitOptions.None);
																string text158 = array11[0];
																string oldValue3 = " ";
																string3 = text158.Replace(oldValue3, string.Empty);
																string text159 = array11[1];
																string oldValue4 = " ";
																string2 = text159.Replace(oldValue4, string.Empty);
																string text160 = "https://netportal.hdfcbank.com/services/epiproxy/current/fundtransfer";
																string_91 = text160;
																string[] array12 = new string[47];
																string text161 = "{\"transaction\":{\"clientCode\":\"";
																array12[0] = text161;
																array12[1] = text32;
																string text162 = "\",\"custAcctNo\":\"";
																array12[2] = text162;
																array12[3] = string2;
																string text163 = "\",\"mercDatTxn\":\"";
																array12[4] = text163;
																array12[5] = text56;
																string text164 = "\",\"mercRefNo\":\"";
																array12[6] = text164;
																array12[7] = text12;
																string text165 = "\",\"merchantCode\":\"PAYTMIRCTCEC\",\"txnAmt\":\"";
																array12[8] = text165;
																array12[9] = @string;
																string text166 = "\",\"toaccountno\":\"";
																array12[10] = text166;
																array12[11] = text151;
																string text167 = "\",\"txnAmtSc\":\"0\",\"txnCodCcy\":\"INR\",\"successStaticFlg\":\"N\",\"failureStaticFlg\":\"N\",\"date\":\"";
																array12[12] = text167;
																array12[13] = text56;
																string text168 = "\",\"rsaReqDynamicURL\":\"";
																array12[14] = text168;
																array12[15] = text37;
																string text169 = "\",\"rsaResDynamicFlg\":\"Y\",\"rsaResDynaSuccessURL\":null,\"rsaResDynaFailureURL\":null,\"rsaResStaticSucUrl\":null,\"rsaResStaticFailUrl\":null,\"typeCheckSum\":\"B\",\"rsaRedirectionReqFlg\":\"Y\",\"flgRsaSec\":\"Y\",\"merchantName\":\"PAYTMIRCTCEC\",\"totalAmnt\":\"";
																array12[16] = text169;
																array12[17] = @string;
																string text170 = "\",\"MerchantCode\":\"PAYTMIRCTCEC\",\"MerchantRefNo\":\"";
																array12[18] = text170;
																array12[19] = text12;
																string text171 = "\",\"PrmRequest\":{\"AcctStat\":\"N\",\"AuthorizationType\":\"D\",\"CashInd\":\"N\",\"ClientLanguage\":\"false\",\"CreditorAliasLastUpdateDate\":\"";
																array12[20] = text171;
																array12[21] = text56;
																string text172 = "\",\"CustTranAmt1\":null,\"EventDetail1\":\"";
																array12[22] = text172;
																array12[23] = text32;
																string text173 = "\",\"MsgSrc\":\"PAYTMIRCTCEC\",\"OrgnlCrncyCode\":\"INR\",\"PostDate\":\"";
																array12[24] = text173;
																array12[25] = text56;
																string text174 = "\",\"RETLID\":\"PAYTMIRCTCEC\",\"RefNum\":\"";
																array12[26] = text174;
																array12[27] = text12;
																string text175 = "\",\"TranAmt1\":\"";
																array12[28] = text175;
																array12[29] = @string;
																string text176 = "\",\"TranAmt2\":\"0\",\"TranAuthSrc\":\"Y\",\"TrckIndx\":\"Y\",\"SecAcctNum\":\"";
																array12[30] = text176;
																array12[31] = text151;
																string text177 = "\",\"WireCreationDateTime\":\"";
																array12[32] = text177;
																array12[33] = text90;
																string text178 = "\",\"LastAdrsChngDate\":\"";
																array12[34] = text178;
																array12[35] = text95;
																string text179 = "\",\"UnstructuredRemittanceInfo2\":\"";
																array12[36] = text179;
																array12[37] = text37;
																string text180 = "\",\"UnstructuredRemittanceInfo1\":\"";
																array12[38] = text180;
																array12[39] = text37;
																string text181 = "\",\"EventTyp\":\"\",\"PriAcctNum\":\"";
																array12[40] = text181;
																array12[41] = string2;
																string text182 = "\",\"ACHBatchType\":\"8\",\"RegulatoryReporting\":\"SOW\",\"TranAmt4\":\"";
																array12[42] = text182;
																array12[43] = string3;
																string text183 = "\",\"TranRsncode\":\"100\"}},\"secretAnswer\":\"";
																array12[44] = text183;
																array12[45] = text11;
																string text184 = "\"}";
																array12[46] = text184;
																text9 = string.Concat(array12);
																text9 = getPostData(text8, text9);
																bool_30 = true;
																string text185 = "channelIndicator#NB&fldAppId#XT&Merchantcode#PAYTMIRCTCEC&Merchantrefno#";
																string text186 = text12;
																string text187 = "&inEncryptValue#";
																HeaderString = text185 + text186 + text187 + text70;
																if (updateTStatus_2 != null)
																{
																	string status7 = "Init. HDFC_NB(8/8)";
																	updateTStatus_2.BeginInvoke(1, status7, tCntrlName_, null, null);
																}
																if (_Request(string_91, text9, string_92, ref cookieContainer, bool_64: true, 60000, 60000, ref string_93, ref string_94, ref Exception_))
																{
																	string text188 = string_93;
																	string value38 = "errorcode\":\"1";
																	if (text188.Contains(value38))
																	{
																		bool_30 = true;
																		string text189 = string_93;
																		string text190 = string_93;
																		string value39 = "outEncryptValue";
																		text24 = text189.Substring(text190.IndexOf(value39) + 18);
																		string text191 = text24;
																		string text192 = text24;
																		string value40 = "\"";
																		text70 = text191.Substring(0, text192.IndexOf(value40));
																		string string_109 = string_93;
																		string string_110 = "secretAnswer";
																		text24 = GetString(string_109, string_110);
																		string text193 = text24.Substring(0, 12);
																		string text194 = "XXXX";
																		text77 = ConvertToBase64(text193 + text194);
																		string string_111 = string_93;
																		string string_112 = "auth_encrypt_string";
																		string string4 = GetString(string_111, string_112);
																		string string_113 = string_93;
																		string string_114 = "input_encrypt_string";
																		string string5 = GetString(string_113, string_114);
																		string requestToken4 = text77;
																		string text195 = "|||";
																		string data3 = string4 + text195 + string5;
																		string action4 = "DeCrypt";
																		string text196 = encrypt_Password(requestToken4, data3, action4);
																		string[] array13 = new string[1];
																		string text197 = "|||";
																		array13[0] = text197;
																		string[] array14 = text196.Split(array13, StringSplitOptions.None);
																		string text198 = array14[0];
																		string oldValue5 = "userAnswer\":null";
																		string newValue = "userAnswer\":\"NX2c13jn\"";
																		string text199 = text198.Replace(oldValue5, newValue);
																		string text200 = array14[1];
																		string oldValue6 = "auth\":null";
																		string newValue2 = "auth\":null,\"input\":null,\"customer\":null,\"total_amt\":null";
																		string string_115 = text200.Replace(oldValue6, newValue2);
																		string string_116 = "creditorAliasLastUpdateDate";
																		string string6 = GetString(string_115, string_116);
																		string oldValue7 = "/";
																		string newValue3 = "-";
																		string6.Replace(oldValue7, newValue3);
																		string text201 = "https://netportal.hdfcbank.com/services/epiproxy/current/auth/sendOtpQnA";
																		string_91 = text201;
																		string[] array15 = new string[45];
																		string text202 = "{\"transaction\":{\"auth\":";
																		array15[0] = text202;
																		array15[1] = text199;
																		string text203 = ",\"input\":{\"transaction\":{\"auth\":null,\"input\":null,\"customer\":null,\"total_amt\":null,\"bankCode\":null,\"channel\":null,\"transactingPartyCode\":null,\"transactionBranch\":null,\"userId\":null,\"externalReferenceNo\":null,\"codReply\":0,\"custAcctNo\":\"";
																		array15[2] = text203;
																		array15[3] = string2;
																		string text204 = "\",\"datTxn\":0.0,\"fwRefNo\":null,\"mercDatTxn\":\"";
																		array15[4] = text204;
																		array15[5] = text56;
																		string text205 = "\",\"mercRefNo\":\"";
																		array15[6] = text205;
																		array15[7] = text12;
																		string text206 = "\",\"txnAmt\":";
																		array15[8] = text206;
																		array15[9] = @string;
																		string text207 = ",\"txnAmtSc\":0.0,\"txnCodCcy\":\"INR\",\"txnNrrtv\":null,\"operation\":null,\"flagForceDebit\":null,\"toaccountno\":\"00000000000000\",\"transactionType\":null,\"uniqueReferenceNumber\":null,\"flgRsaSec\":\"Y\",\"clientCode\":\"";
																		array15[10] = text207;
																		array15[11] = text32;
																		string text208 = "\",\"merchantCode\":\"PAYTMIRCTCEC\",\"merchantRefNo\":null,\"date\":\"";
																		array15[12] = text208;
																		string text209 = "1/22/2024 12:32:27";
																		array15[13] = text209;
																		string text210 = "\",\"txnCurrency\":null,\"txnAmount\":null,\"txnScAmount\":null,\"successStaticFlg\":\"N\",\"failureStaticFlg\":\"N\",\"date1\":null,\"date2\":null,\"ref1\":null,\"ref2\":null,\"ref3\":null,\"ref4\":null,\"ref5\":null,\"ref6\":null,\"ref7\":null,\"ref8\":null,\"ref9\":null,\"ref10\":null,\"ref11\":null,\"displayDetails\":null,\"details1\":null,\"details2\":null,\"details3\":null,\"accountNumber\":null,\"dynamicURL\":null,\"checkSum\":null,\"bankRefNo\":null,\"message\":null,\"typeCheckSum\":\"B\",\"rsaRedirectionReqFlg\":\"Y\",\"rsaResDynamicFlg\":\"Y\",\"rsaReqDynamicURL\":\"";
																		array15[14] = text210;
																		array15[15] = text37;
																		string text211 = "\",\"rsaResDynaSuccessURL\":null,\"rsaResDynaFailureURL\":null,\"typeOTP\":null,\"deliveryMode\":null,\"totalAmnt\":\"";
																		array15[16] = text211;
																		array15[17] = @string;
																		string text212 = "\",\"merchantName\":\"PAYTMIRCTCECATERING\",\"rsaResStaticFailUrl\":null,\"rsaResStaticSucUrl\":null,\"maskedAcctNo\":null,\"prmRequest\":{\"acctNum\":null,\"priAcctNum\":\"";
																		array15[18] = text212;
																		array15[19] = string2;
																		string text213 = "\",\"tranDateTime\":null,\"custTranAmt1\":null,\"abanum\":null,\"msgSrc\":\"PAYTMIRCTCECATERING\",\"tranAuthSrc\":\"Y\",\"postDate\":\"";
																		array15[20] = text213;
																		string text214 = "24/01/2024 12:31:48";
																		array15[21] = text214;
																		string text215 = "\",\"addenda\":null,\"refNum\":\"PAYTMIRCTCEC\",\"retlid\":\"PAYTMIRCTCEC\",\"mmbrNum\":null,\"xfwdedFor\":null,\"ibk1AcctIdent\":null,\"orgnlCrncyCode\":\"INR\",\"tranAmt1\":\"";
																		array15[22] = text215;
																		string text216 = "204.5";
																		array15[23] = text216;
																		string text217 = "\",\"tranAmt2\":\"0\",\"extAuthResult\":null,\"userAgent\":null,\"emvusrFlr\":null,\"custScore\":null,\"acceptLanguage\":null,\"extAuthType\":null,\"clientIP\":null,\"clientLanguage\":\"false\",\"achbatchType\":\"8\",\"regulatoryReporting\":\"SOW\",\"tranAmt4\":\"18428.54\",\"cashInd\":\"N\",\"creditorAliasLastUpdateDate\":\"";
																		array15[24] = text217;
																		string text218 = "2023-10-10 12:30:59";
																		array15[25] = text218;
																		string text219 = "\",\"sessionId\":null,\"eventTyp\":\"\",\"deviceBrwsPlgin\":null,\"authorizationType\":\"D\",\"chckSerlNum\":null,\"emvcardVrfyRslts\":null,\"tranRsnCode\":\"100\",\"lastAdrsChngDate\":\"";
																		array15[26] = text219;
																		array15[27] = text95;
																		string text220 = "\",\"wireCreationDateTime\":\"";
																		array15[28] = text220;
																		array15[29] = text90;
																		string text221 = "\",\"creditorAliasRegisteredDate\":null,\"endToEndIdentification\":null,\"eventDetail1\":\"";
																		array15[30] = text221;
																		array15[31] = text32;
																		string text222 = "\",\"secAcctNum\":\"00000000000000\",\"unstructuredRemittanceInfo2\":\"";
																		array15[32] = text222;
																		string text223 = "https://securegw.paytm.in/instaproxy/bankresponse/HDFC/NB/RESP";
																		array15[33] = text223;
																		string text224 = "\",\"unstructuredRemittanceInfo1\":\"";
																		array15[34] = text224;
																		string text225 = "https://securegw.paytm.in/instaproxy/bankresponse/HDFC/NB/RESP";
																		array15[35] = text225;
																		string text226 = "\",\"trckIndx\":\"Y\",\"acctStat\":\"N\",\"msgType\":null,\"riskMsgType\":null,\"realTimeRuleFrd\":null,\"realTimeRuleDsps\":null,\"realTimeDsps\":null,\"realTimeScore3\":null}}},\"customer\":{\"email\":\"";
																		array15[36] = text226;
																		array15[37] = text100;
																		string text227 = "\",\"mobile\":\"";
																		array15[38] = text227;
																		array15[39] = text105;
																		string text228 = "\"},\"total_amt\":null,\"bankCode\":null,\"channel\":null,\"transactingPartyCode\":null,\"transactionBranch\":null,\"userId\":null,\"externalReferenceNo\":null,\"codReply\":0,\"custAcctNo\":null,\"datTxn\":0.0,\"fwRefNo\":null,\"mercDatTxn\":null,\"mercRefNo\":null,\"txnAmt\":0.0,\"txnAmtSc\":0.0,\"txnCodCcy\":null,\"txnNrrtv\":null,\"operation\":null,\"flagForceDebit\":null,\"toaccountno\":null,\"transactionType\":null,\"uniqueReferenceNumber\":null,\"flgRsaSec\":null,\"clientCode\":\"";
																		array15[40] = text228;
																		array15[41] = text32;
																		string text229 = "\",\"merchantCode\":null,\"merchantRefNo\":null,\"date\":null,\"txnCurrency\":null,\"txnAmount\":null,\"txnScAmount\":null,\"successStaticFlg\":\"N\",\"failureStaticFlg\":null,\"date1\":null,\"date2\":null,\"ref1\":null,\"ref2\":null,\"ref3\":null,\"ref4\":null,\"ref5\":null,\"ref6\":null,\"ref7\":null,\"ref8\":null,\"ref9\":null,\"ref10\":null,\"ref11\":null,\"displayDetails\":null,\"details1\":null,\"details2\":null,\"details3\":null,\"accountNumber\":null,\"dynamicURL\":null,\"checkSum\":null,\"bankRefNo\":null,\"message\":null,\"typeCheckSum\":null,\"rsaRedirectionReqFlg\":null,\"rsaResDynamicFlg\":null,\"rsaReqDynamicURL\":null,\"rsaResDynaSuccessURL\":null,\"rsaResDynaFailureURL\":null,\"typeOTP\":null,\"deliveryMode\":null,\"totalAmnt\":null,\"merchantName\":\"PAYTMIRCTCEC\",\"rsaResStaticFailUrl\":null,\"rsaResStaticSucUrl\":null,\"maskedAcctNo\":null,\"prmRequest\":null},\"secretAnswer\":\"";
																		array15[42] = text229;
																		array15[43] = text11;
																		string text230 = "\"}";
																		array15[44] = text230;
																		text9 = string.Concat(array15);
																		text9 = getPostData(text8, text9);
																		string[] array16 = new string[6];
																		string text231 = "channelIndicator#NB&fldAppId#XT&Merchantcode#PAYTMIRCTCEC&Merchantrefno#";
																		array16[0] = text231;
																		array16[1] = text12;
																		string text232 = "&Ans#";
																		array16[2] = text232;
																		array16[3] = text11;
																		string text233 = "&inEncryptValue#";
																		array16[4] = text233;
																		array16[5] = text70;
																		HeaderString = string.Concat(array16);
																		if (updateTStatus_2 != null)
																		{
																			string status8 = "Init. HDFC_NB(9/9)";
																			updateTStatus_2.BeginInvoke(1, status8, tCntrlName_, null, null);
																		}
																		bool flag2 = !_Request(string_91, text9, string_92, ref cookieContainer, bool_64: true, 60000, 60000, ref string_93, ref string_94, ref Exception_);
																		string text234 = string_93;
																		string value41 = "securepay.paytmpayments";
																		if (flag2 | !text234.Contains(value41))
																		{
																			string text235 = "HDFC Not Working - Payment Failed";
																			string_90 = text235;
																			return false;
																		}
																		string_89 = string_93;
																		string_90 = string_91;
																		bool_30 = true;
																		string text236 = string_93;
																		string text237 = string_93;
																		string value42 = "outEncryptValue";
																		text24 = text236.Substring(text237.IndexOf(value42) + 18);
																		string text238 = text24;
																		string text239 = text24;
																		string value43 = "\"";
																		text70 = text238.Substring(0, text239.IndexOf(value43));
																		string text240 = "https://netportal.hdfcbank.com/j_spring_security_logout?portalName=epi-portal";
																		string_91 = text240;
																		string[] array17 = new string[6];
																		string text241 = "channelIndicator#NB&fldAppId#XT&Merchantcode#PAYTMIRCTCEC&Merchantrefno#";
																		array17[0] = text241;
																		array17[1] = text12;
																		string text242 = "&Ans#";
																		array17[2] = text242;
																		array17[3] = text11;
																		string text243 = "&inEncryptValue#";
																		array17[4] = text243;
																		array17[5] = text70;
																		HeaderString = string.Concat(array17);
																		_Request(string_91, "", "", ref cookieContainer, bool_64: true, 60000, 60000, ref string_93, ref string_94, ref Exception_);
																		return true;
																	}
																}
																string text244 = "HDFC Not Working - Payment Failed";
																string_90 = text244;
																return false;
															}
														}
														string text245 = "HDFC Not Working - Payment Failed";
														string_90 = text245;
														return false;
													}
												}
												string text246 = "HDFC Not Working - Payment Failed";
												string_90 = text246;
												return false;
											}
										}
										string text247 = "HDFC Not Working - Payment Failed";
										string_90 = text247;
										return false;
									}
								}
							}
							string text248 = "HDFC Not Working - Payment Failed";
							string_90 = text248;
							return false;
						}
					}
					string text249 = "HDFC Not Working - Payment Failed";
					string_90 = text249;
					return false;
				}
			}
			string text250 = "HDFC Not Working - Payment Failed";
			string_90 = text250;
			return false;
		}
		catch (Exception)
		{
			string text251 = "HDFC Not Working - Payment Failed";
			string_90 = text251;
		}
		if (flag)
		{
			bool_30 = true;
			string text252 = "https://netportal.hdfcbank.com/j_spring_security_logout?portalName=epi-portal";
			string_91 = text252;
			string text253 = "channelIndicator#NB&fldAppId#XT&Merchantcode#PAYTMIRCTCEC&Merchantrefno#";
			HeaderString = text253 + text12;
			_Request(string_91, "", "", ref cookieContainer, bool_64: true, 60000, 60000, ref string_93, ref string_94, ref Exception_);
		}
		return flag;
	}
}
