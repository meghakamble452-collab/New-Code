using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace APP_FRAMEWORK;

internal static class Class18
{
	public class Class19
	{
		public byte[] Byte_0 { get; set; }

		public string String_0 { get; set; }

		public string String_1 { get; set; }

		public Class19(byte[] byte_1)
			: this(byte_1, null)
		{
		}

		public Class19(byte[] byte_1, string string_2)
			: this(byte_1, string_2, null)
		{
		}

		public Class19(byte[] byte_1, string string_2, string string_3)
		{
			Byte_0 = byte_1;
			String_0 = string_2;
			String_1 = string_3;
		}
	}

	private static readonly Encoding encoding_0 = Encoding.UTF8;

	public static HttpWebResponse smethod_0(string string_0, string string_1, Dictionary<string, object> dictionary_0)
	{
		string format = "----------{0:N}";
		string.Format(format, Guid.NewGuid());
		string text = "----WebKitFormBoundaryOaJaYBToliFtvgUE";
		string text2 = text;
		string text3 = "multipart/form-data; boundary=";
		string string_2 = text3 + text2;
		byte[] byte_ = smethod_2(dictionary_0, text2);
		return smethod_1(string_0, string_1, string_2, byte_);
	}

	private static HttpWebResponse smethod_1(string string_0, string string_1, string string_2, byte[] byte_0)
	{
		try
		{
			if (WebRequest.Create(string_0) is HttpWebRequest httpWebRequest)
			{
				string method = "POST";
				httpWebRequest.Method = method;
				httpWebRequest.ContentType = string_2;
				string referer = "https://www.irctcipay.com/pgui/jsp/surchargePaymentPage.jsp";
				httpWebRequest.Referer = referer;
				httpWebRequest.UserAgent = string_1;
				httpWebRequest.CookieContainer = new CookieContainer();
				httpWebRequest.ContentLength = byte_0.Length;
				using (Stream stream = httpWebRequest.GetRequestStream())
				{
					stream.Write(byte_0, 0, byte_0.Length);
					stream.Close();
				}
				return httpWebRequest.GetResponse() as HttpWebResponse;
			}
			string message = "request is not a http request";
			throw new NullReferenceException(message);
		}
		catch (WebException ex)
		{
			if (ex.Response != null)
			{
				_ = ((HttpWebResponse)ex.Response).StatusCode;
				return (HttpWebResponse)ex.Response;
			}
		}
		return null;
	}

	public static HttpWebResponse smethod_11(string string_0)
	{
		try
		{
			if (!(WebRequest.Create(string_0) is HttpWebRequest httpWebRequest))
			{
				string message = "request is not a http request";
				throw new NullReferenceException(message);
			}
			string method = "GET";
			httpWebRequest.Method = method;
			string contentType = "application/x-www-form-urlencoded";
			httpWebRequest.ContentType = contentType;
			string userAgent = "Mozilla/5.0 (Windows T 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36";
			httpWebRequest.UserAgent = userAgent;
			httpWebRequest.CookieContainer = new CookieContainer();
			return httpWebRequest.GetResponse() as HttpWebResponse;
		}
		catch (WebException ex)
		{
			if (ex.Response != null)
			{
				_ = ((HttpWebResponse)ex.Response).StatusCode;
				return (HttpWebResponse)ex.Response;
			}
		}
		return null;
	}

	private static byte[] smethod_2(Dictionary<string, object> dictionary_0, string string_0)
	{
		Stream stream = new MemoryStream();
		bool flag = false;
		foreach (KeyValuePair<string, object> item in dictionary_0)
		{
			if (flag)
			{
				Encoding encoding = encoding_0;
				string s = "\r\n";
				byte[] bytes = encoding.GetBytes(s);
				Encoding encoding2 = encoding_0;
				string s2 = "\r\n";
				stream.Write(bytes, 0, encoding2.GetByteCount(s2));
			}
			flag = true;
			if (!(item.Value is Class19))
			{
				string format = "--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n{2}";
				string s3 = string.Format(format, string_0, item.Key, item.Value);
				stream.Write(encoding_0.GetBytes(s3), 0, encoding_0.GetByteCount(s3));
				continue;
			}
			Class19 @class = (Class19)item.Value;
			string format2 = "--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\";\r\nContent-Type: {3}\r\n\r\n";
			string s4 = string.Format(format2, string_0, item.Key, @class.String_0 ?? item.Key, @class.String_1 ?? "application/octet-stream");
			stream.Write(encoding_0.GetBytes(s4), 0, encoding_0.GetByteCount(s4));
			stream.Write(@class.Byte_0, 0, @class.Byte_0.Length);
		}
		string text = "\r\n--";
		string text2 = "--\r\n";
		string s5 = text + string_0 + text2;
		stream.Write(encoding_0.GetBytes(s5), 0, encoding_0.GetByteCount(s5));
		stream.Position = 0L;
		byte[] array = new byte[stream.Length];
		stream.Read(array, 0, array.Length);
		stream.Close();
		return array;
	}

	public static string GetBankRedirectInp(string A_0, ref string A_1, bool A_2)
	{
		string text = "";
		string oldValue = "'";
		string newValue = "\"";
		string text2 = A_0.Replace(oldValue, newValue);
		string value = "action=";
		int num = text2.IndexOf(value, StringComparison.CurrentCultureIgnoreCase);
		if (num <= 0)
		{
			string value2 = "action =";
			num = text2.IndexOf(value2, StringComparison.CurrentCultureIgnoreCase);
		}
		string value3 = "\"";
		int num2 = text2.IndexOf(value3, num) + 1;
		string value4 = "\"";
		int num3 = text2.IndexOf(value4, num2);
		A_1 = text2.Substring(num2, num3 - num2);
		string value5 = "/form";
		int num4 = text2.IndexOf(value5, StringComparison.CurrentCultureIgnoreCase);
		string value6 = "hidden";
		int num5 = text2.IndexOf(value6, num2, StringComparison.CurrentCultureIgnoreCase);
		while (num5 > 0 && num5 < num4)
		{
			string text6;
			int num10;
			if (A_2)
			{
				string value7 = "<";
				int startIndex = text2.LastIndexOf(value7, num5, StringComparison.CurrentCultureIgnoreCase);
				string value8 = "name";
				int startIndex2 = text2.IndexOf(value8, startIndex, StringComparison.CurrentCultureIgnoreCase);
				string value9 = "\"";
				int num6 = text2.IndexOf(value9, startIndex2) + 1;
				string value10 = "\"";
				int num7 = text2.IndexOf(value10, num6);
				string text3 = text2.Substring(num6, num7 - num6);
				string value11 = "<";
				int startIndex3 = text2.LastIndexOf(value11, num6, StringComparison.CurrentCultureIgnoreCase);
				string value12 = "value";
				int startIndex4 = text2.IndexOf(value12, startIndex3, StringComparison.CurrentCultureIgnoreCase);
				string value13 = "\"";
				int num8 = text2.IndexOf(value13, startIndex4) + 1;
				string value14 = "\"";
				int num9 = text2.IndexOf(value14, num8);
				string text4 = "=";
				string text5 = text2.Substring(num8, num9 - num8);
				string oldValue2 = "&amp;";
				string newValue2 = "&";
				text6 = text3 + text4 + HttpUtility.UrlEncode(text5.Replace(oldValue2, newValue2));
				string value15 = ">";
				num10 = text2.IndexOf(value15, num8, StringComparison.CurrentCultureIgnoreCase) + 1;
			}
			else
			{
				string value16 = "name";
				int startIndex5 = text2.IndexOf(value16, num5, StringComparison.CurrentCultureIgnoreCase);
				string value17 = "\"";
				int num11 = text2.IndexOf(value17, startIndex5) + 1;
				string value18 = "\"";
				int num12 = text2.IndexOf(value18, num11);
				string text7 = text2.Substring(num11, num12 - num11);
				string value19 = "value";
				int startIndex6 = text2.IndexOf(value19, num11, StringComparison.CurrentCultureIgnoreCase);
				string value20 = "\"";
				num10 = text2.IndexOf(value20, startIndex6) + 1;
				string value21 = "\"";
				int num13 = text2.IndexOf(value21, num10);
				string text8 = "=";
				string text9 = text2.Substring(num10, num13 - num10);
				string oldValue3 = "&amp;";
				string newValue3 = "&";
				text6 = text7 + text8 + HttpUtility.UrlEncode(text9.Replace(oldValue3, newValue3));
			}
			string text10;
			if (string.IsNullOrEmpty(text))
			{
				text10 = text6;
			}
			else
			{
				string text11 = text;
				string text12 = "&";
				text10 = text11 + text12 + text6;
			}
			text = text10;
			string value22 = "hidden";
			num5 = text2.IndexOf(value22, num10, StringComparison.CurrentCultureIgnoreCase);
		}
		return text;
	}
}
