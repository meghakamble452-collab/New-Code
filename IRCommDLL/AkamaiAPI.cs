using System;
using System.IO;
using System.Net;

namespace IRCommDLL;

internal class AkamaiAPI
{
	internal bool akm_App(string user, string pass, ref CookieContainer cc, ref string resp)
	{
		bool result = false;
		string text = "";
		while (true)
		{
			try
			{
				string[] array = new string[5];
				string text2 = "https://api.stage.crawless.com/project/8685b583-4198-43ef-bf20-a7e09c952cfa/workflow/e60451c0-7135-4ad2-bd4c-cef61e8917c1/task/api:prashant_no_login/run?args[username]=";
				array[0] = text2;
				array[1] = user;
				string text3 = "&args[password]=";
				array[2] = text3;
				array[3] = pass;
				string text4 = "&token=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJhY2NvdW50SWQiOiJiOGZiM2Y2Yi1lNDkzLTQ0NzYtYWQzZS04NzIzYTE5Y2NiMWEiLCJpYXQiOjE2NjgxMTE3OTMsImV4cCI6MTY5OTY2OTM5M30.3Y5XiZAo1h16YGPUdzIYzOr_Z4f6U51Bdi2gxBfaFCs";
				array[4] = text4;
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Concat(array));
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				httpWebRequest.Timeout = 180000;
				httpWebRequest.ReadWriteTimeout = 180000;
				string method = "GET";
				httpWebRequest.Method = method;
				using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
				text = streamReader.ReadToEnd();
				if (text.Length < 500)
				{
					continue;
				}
				string text5 = text;
				string text6 = text;
				string value = "body_response";
				string text7 = text5.Substring(text6.IndexOf(value) + 15);
				string text8 = text7;
				string text9 = text7;
				string value2 = "},";
				resp = text8.Substring(0, text9.IndexOf(value2));
				string text10 = text;
				string text11 = text;
				string value3 = "[";
				text7 = text10.Substring(text11.IndexOf(value3) + 1);
				string text12 = text7;
				string text13 = text7;
				string value4 = "]";
				text = text12.Substring(0, text13.IndexOf(value4));
				string text14 = text;
				string[] array2 = new string[1];
				string text15 = "},";
				array2[0] = text15;
				string[] array3 = text14.Split(array2, StringSplitOptions.None);
				string[] array4 = array3;
				string[] array5 = array4;
				foreach (string text16 in array5)
				{
					string string_ = "name\":";
					string @string = GetString(text16, string_);
					string string_2 = "value\":";
					string string2 = GetString(text16, string_2);
					string string_3 = "domain\":";
					string string3 = GetString(text16, string_3);
					string string_4 = "path\":";
					string string4 = GetString(text16, string_4);
					string value5 = "secure\":true";
					bool secure = text16.Contains(value5);
					string value6 = "httpOnly\":true";
					bool httpOnly = text16.Contains(value6);
					Cookie cookie = new Cookie(@string, string2)
					{
						Domain = string3,
						Path = string4,
						Secure = secure,
						HttpOnly = httpOnly
					};
					cc.Add(cookie);
				}
				return result;
			}
			catch
			{
			}
		}
	}

	internal bool akm_Web(string user, string pass, ref CookieContainer cc, ref string greq, ref string token, ref string authorization)
	{
		bool result = false;
		string text = "";
		while (true)
		{
			try
			{
				string[] array = new string[5];
				string text2 = "https://api.stage.crawless.com/project/8685b583-4198-43ef-bf20-a7e09c952cfa/workflow/e60451c0-7135-4ad2-bd4c-cef61e8917c1/task/api:prashant/run?args%5Busername%5D=";
				array[0] = text2;
				array[1] = user;
				string text3 = "&args%5Bpassword%5D=";
				array[2] = text3;
				array[3] = pass;
				string text4 = "&token=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJhY2NvdW50SWQiOiJiOGZiM2Y2Yi1lNDkzLTQ0NzYtYWQzZS04NzIzYTE5Y2NiMWEiLCJpYXQiOjE2NjgxMTE3OTMsImV4cCI6MTY5OTY2OTM5M30.3Y5XiZAo1h16YGPUdzIYzOr_Z4f6U51Bdi2gxBfaFCs";
				array[4] = text4;
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Concat(array));
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				httpWebRequest.Timeout = 180000;
				httpWebRequest.ReadWriteTimeout = 180000;
				string method = "GET";
				httpWebRequest.Method = method;
				using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
				text = streamReader.ReadToEnd();
				if (text.Length < 500)
				{
					continue;
				}
				string string_ = text;
				string string_2 = "csrf-token\":";
				token = GetString(string_, string_2);
				string string_3 = text;
				string string_4 = "authorization\":";
				authorization = GetString(string_3, string_4);
				string string_5 = text;
				string string_6 = "greq\":";
				greq = GetString(string_5, string_6);
				string string_7 = text;
				string string_8 = "_abck\",\"value\":";
				GetString(string_7, string_8);
				string string_9 = text;
				string string_10 = "ak_bmsc\",\"value\":";
				GetString(string_9, string_10);
				string string_11 = text;
				string string_12 = "bm_sz\",\"value\":";
				GetString(string_11, string_12);
				string string_13 = text;
				string string_14 = "bm_sv\",\"value\":";
				GetString(string_13, string_14);
				string string_15 = text;
				string string_16 = "JSESSIONID\",\"value\":";
				GetString(string_15, string_16);
				string text5 = text;
				string text6 = text;
				string value = "[";
				string text7 = text5.Substring(text6.IndexOf(value) + 1);
				string value2 = "]";
				text = text7.Substring(0, text7.IndexOf(value2));
				string text8 = text;
				string[] array2 = new string[1];
				string text9 = "},";
				array2[0] = text9;
				string[] array3 = text8.Split(array2, StringSplitOptions.None);
				string[] array4 = array3;
				string[] array5 = array4;
				foreach (string text10 in array5)
				{
					string string_17 = "name\":";
					string @string = GetString(text10, string_17);
					string string_18 = "value\":";
					string string2 = GetString(text10, string_18);
					string string_19 = "domain\":";
					string string3 = GetString(text10, string_19);
					string string_20 = "path\":";
					string string4 = GetString(text10, string_20);
					string value3 = "secure\":true";
					bool secure = text10.Contains(value3);
					string value4 = "httpOnly\":true";
					bool httpOnly = text10.Contains(value4);
					Cookie cookie = new Cookie(@string, string2)
					{
						Domain = string3,
						Path = string4,
						Secure = secure,
						HttpOnly = httpOnly
					};
					cc.Add(cookie);
				}
				return result;
			}
			catch
			{
			}
		}
	}

	private string GetString(string string_86, string string_87)
	{
		string result = "";
		try
		{
			string text = "\"";
			string text2 = string_86.Substring(string_86.IndexOf(text + string_87));
			string text3 = text2.Substring(text2.IndexOf(string_87) + (string_87.Length + 1));
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

	private string Gettext(string string_86, string string_87)
	{
		string result = "";
		try
		{
			string text = string_86.Substring(string_86.IndexOf(string_87));
			string text2 = text.Substring(text.IndexOf(string_87) + string_87.Length + 1);
			string text3 = text2;
			string text4 = text2;
			string value = ",";
			text2 = text3.Substring(0, text4.IndexOf(value));
			result = text2;
			return result;
		}
		catch
		{
			return result;
		}
	}
}
