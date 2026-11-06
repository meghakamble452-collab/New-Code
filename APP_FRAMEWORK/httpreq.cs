using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Text;
using Microsoft.VisualBasic;

namespace APP_FRAMEWORK;

public class httpreq
{
	private HttpWebRequest httpWebRequest_0;

	protected static int int_0 = 5001;

	public static Image image_0;

	public string method_12(string string_21, string string_22, string string_23, string string_24, ref CookieContainer Cookie, int id)
	{
		string text = "";
		httpWebRequest_0 = null;
		Stream stream = null;
		HttpWebResponse httpWebResponse = null;
		Stream stream2 = null;
		try
		{
			GC.Collect();
			Uri uri = new Uri(string_21);
			httpWebRequest_0 = (HttpWebRequest)WebRequest.Create(uri);
			httpWebRequest_0.CachePolicy = new HttpRequestCachePolicy(HttpCacheAgeControl.MaxAge, TimeSpan.FromDays(1.0));
			httpWebRequest_0.ServicePoint.ConnectionLeaseTimeout = 100000;
			httpWebRequest_0.ServicePoint.UseNagleAlgorithm = false;
			httpWebRequest_0.ServicePoint.Expect100Continue = false;
			httpWebRequest_0.ServicePoint.ConnectionLimit = 65000;
			httpWebRequest_0.ServicePoint.MaxIdleTime = 100000;
			httpWebRequest_0.Referer = string_22;
			httpWebRequest_0.KeepAlive = true;
			httpWebRequest_0.Pipelined = false;
			httpWebRequest_0.ReadWriteTimeout = 50000;
			HttpWebRequest httpWebRequest = httpWebRequest_0;
			string connection = "keepalive";
			httpWebRequest.Connection = connection;
			httpWebRequest_0.CookieContainer = Cookie;
			WebHeaderCollection headers = httpWebRequest_0.Headers;
			string value = "gzip,deflate";
			headers.Add(HttpRequestHeader.AcceptEncoding, value);
			httpWebRequest_0.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
			HttpWebRequest httpWebRequest2 = httpWebRequest_0;
			string accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
			httpWebRequest2.Accept = accept;
			HttpWebRequest httpWebRequest3 = httpWebRequest_0;
			string userAgent = "Mozilla/5.0 (Windows T 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/27.0.1453.116 Safari/537.36";
			httpWebRequest3.UserAgent = userAgent;
			WebHeaderCollection headers2 = httpWebRequest_0.Headers;
			string name = "Cache-Control";
			string value2 = "no-cache";
			headers2.Set(name, value2);
			string text2 = "SELTR";
			if (string_24 == text2)
			{
				WebHeaderCollection headers3 = httpWebRequest_0.Headers;
				string name2 = "Faces-Request";
				string value3 = "partial/ajax";
				headers3.Add(name2, value3);
				WebHeaderCollection headers4 = httpWebRequest_0.Headers;
				string name3 = "Cache-Control";
				string value4 = "no-cache";
				headers4.Set(name3, value4);
				WebHeaderCollection headers5 = httpWebRequest_0.Headers;
				string name4 = "Pragma";
				string value5 = "no-cache";
				headers5.Set(name4, value5);
			}
			else
			{
				HttpWebRequest httpWebRequest4 = httpWebRequest_0;
				string accept2 = "*/*";
				httpWebRequest4.Accept = accept2;
				WebHeaderCollection headers6 = httpWebRequest_0.Headers;
				string name5 = "Cache-Control";
				string value6 = "no-cache";
				headers6.Set(name5, value6);
				WebHeaderCollection headers7 = httpWebRequest_0.Headers;
				string name6 = "Pragma";
				string value7 = "no-cache";
				headers7.Set(name6, value7);
				WebHeaderCollection headers8 = httpWebRequest_0.Headers;
				string name7 = "X-user-agent";
				string value8 = "Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.186 Safari/537.36 FKUA/website/41/website/Desktop";
				headers8.Set(name7, value8);
			}
			string value9 = "fcuiopxxy";
			if (string_24.Contains(value9))
			{
				WebHeaderCollection headers9 = httpWebRequest_0.Headers;
				string value10 = "ISO-8859-1,utf-8;q=0.7,*;q=0.3";
				headers9.Add(HttpRequestHeader.AcceptCharset, value10);
				WebHeaderCollection headers10 = httpWebRequest_0.Headers;
				string value11 = "no-cache";
				headers10.Add(HttpRequestHeader.Pragma, value11);
				WebHeaderCollection headers11 = httpWebRequest_0.Headers;
				string name8 = "Cache-Control";
				string value12 = "no-cache";
				headers11.Add(name8, value12);
			}
			httpWebRequest_0.UnsafeAuthenticatedConnectionSharing = true;
			httpWebRequest_0.Timeout = 90000;
			httpWebRequest_0.AllowAutoRedirect = false;
			httpWebRequest_0.PreAuthenticate = true;
			httpWebRequest_0.AllowWriteStreamBuffering = false;
			httpWebRequest_0.ProtocolVersion = HttpVersion.Version11;
			if (!(string_23 != ""))
			{
				HttpWebRequest httpWebRequest5 = httpWebRequest_0;
				string method = "GET";
				httpWebRequest5.Method = method;
				string value13 = "fcuiopxxy";
				bool flag = string_24.Contains(value13);
				string value14 = "asdasd";
				if (flag | string_24.Contains(value14))
				{
					HttpWebRequest httpWebRequest6 = httpWebRequest_0;
					string method2 = "POST";
					httpWebRequest6.Method = method2;
					byte[] bytes = Encoding.ASCII.GetBytes(string_23);
					HttpWebRequest httpWebRequest7 = httpWebRequest_0;
					string contentType = "application/x-www-form-urlencoded";
					httpWebRequest7.ContentType = contentType;
					httpWebRequest_0.ContentLength = bytes.Length;
					stream = httpWebRequest_0.GetRequestStream();
					stream.Write(bytes, 0, bytes.Length);
					stream.Flush();
					stream.Close();
				}
			}
			else
			{
				HttpWebRequest httpWebRequest8 = httpWebRequest_0;
				string method3 = "POST";
				httpWebRequest8.Method = method3;
				byte[] bytes2 = Encoding.ASCII.GetBytes(string_23);
				HttpWebRequest httpWebRequest9 = httpWebRequest_0;
				string contentType2 = "application/x-www-form-urlencoded";
				httpWebRequest9.ContentType = contentType2;
				string text3 = "json";
				if (string_24 == text3)
				{
					HttpWebRequest httpWebRequest10 = httpWebRequest_0;
					string contentType3 = "application/json";
					httpWebRequest10.ContentType = contentType3;
				}
				httpWebRequest_0.ContentLength = bytes2.Length;
				stream = httpWebRequest_0.GetRequestStream();
				stream.Write(bytes2, 0, bytes2.Length);
				stream.Flush();
				stream.Close();
			}
			httpWebResponse = (HttpWebResponse)httpWebRequest_0.GetResponse();
			HttpWebResponse httpWebResponse2 = httpWebResponse;
			switch (httpWebResponse2.StatusCode)
			{
			default:
			{
				string value16 = "image";
				if (!string_24.Contains(value16))
				{
					stream2 = httpWebResponse2.GetResponseStream();
					StreamReader streamReader = new StreamReader(stream2, Encoding.UTF8);
					text = streamReader.ReadToEnd();
					streamReader.Close();
					stream2.Close();
					stream2 = null;
				}
				else
				{
					image_0 = Image.FromStream(httpWebResponse2.GetResponseStream());
					string text7 = "Finish";
					text = text7;
				}
				break;
			}
			case HttpStatusCode.NotModified:
			case HttpStatusCode.UseProxy:
			case HttpStatusCode.Unused:
			{
				string text6 = "retry";
				text = text6;
				break;
			}
			case HttpStatusCode.MovedPermanently:
			case HttpStatusCode.Found:
			case HttpStatusCode.SeeOther:
			case HttpStatusCode.TemporaryRedirect:
			{
				string headerName = "Location";
				string responseHeader = httpWebResponse2.GetResponseHeader(headerName);
				string value15 = "err200.html";
				string text4;
				if (!responseHeader.Contains(value15))
				{
					text4 = responseHeader;
				}
				else
				{
					string text5 = "retry";
					text4 = text5;
				}
				text = text4;
				break;
			}
			}
			WebHeaderCollection headers12 = httpWebResponse.Headers;
			string name9 = "Set-Cookie";
			string text8 = headers12[name9];
			if (text8 != null)
			{
				string[] array = new string[1];
				string text9 = ",";
				array[0] = text9;
				string[] array2 = text8.Split(array, StringSplitOptions.RemoveEmptyEntries);
				for (int i = 0; i < array2.Length; i++)
				{
					try
					{
						string text10 = array2[i];
						string text11 = array2[i];
						string value17 = ";";
						string text12 = text10.Substring(0, text11.IndexOf(value17));
						string delimiter = "=";
						string[] array3 = Strings.Split(text12, delimiter);
						if (array3.Length > 2)
						{
							string text13 = array3[0];
							string text14 = "=";
							array3[1] = text12.Replace(text13 + text14, "");
						}
						if (array3.Length >= 2)
						{
							Cookie.Add(new Cookie(array3[0], array3[1])
							{
								Domain = uri.Host
							});
						}
					}
					catch
					{
					}
				}
			}
			httpWebResponse.Close();
			httpWebResponse = null;
			httpWebRequest_0 = null;
			if (text == "")
			{
				string text15 = "retry";
				text = text15;
			}
		}
		catch (WebException ex)
		{
			string text16 = "";
			try
			{
				text16 = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
				string text17 = ":";
				text16 = text17 + text16;
			}
			catch
			{
			}
			GC.Collect();
			string text18 = "retry";
			text = text18 + text16;
		}
		catch (Exception)
		{
			GC.Collect();
			string text19 = "retry";
			text = text19;
		}
		finally
		{
			if (stream != null)
			{
				stream.Close();
				stream.Dispose();
			}
			if (stream2 != null)
			{
				stream2.Close();
				stream2.Dispose();
			}
			httpWebResponse?.Close();
			if (httpWebRequest_0 != null)
			{
				httpWebRequest_0.Abort();
				httpWebRequest_0 = null;
			}
		}
		return text;
	}
}
