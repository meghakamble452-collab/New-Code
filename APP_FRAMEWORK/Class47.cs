using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using Driver;
using Driver.intern.hook;
using Microsoft.VisualBasic;
using NEXUS.Booking;

namespace APP_FRAMEWORK;

internal class Class47
{
	public static WebProxy prx0;

	public static string X_data;

	public static bool CheckingAvl;

	public static string usr;

	public static string Pwd;

	public static CookieContainer IrctcCookie_0;

	public static int batchId;

	public static string httpsession;

	public static string scriptsession;

	public static CookieContainer BkMyTrncc;

	private static Predicate<string> predicate_0;

	private static Predicate<string> predicate_1;

	private static Predicate<string> predicate_2;

	private static HttpWebRequest httpWebRequest_0;

	public static int ncjSBxobKsFNmqxXMlSusuazICCG;

	static Class47()
	{
		CheckingAvl = false;
		usr = "";
		Pwd = "";
		IrctcCookie_0 = new CookieContainer();
		batchId = 0;
		BkMyTrncc = new CookieContainer();
		ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
		try
		{
			foreach (string key in Program.dictionary_0.Keys)
			{
				usr = key;
			}
			Pwd = Program.dictionary_0[usr];
		}
		catch
		{
		}
	}

	public static string[,] method_1A(string string_0, string string_1, string string_2, DateTime value, string string_7, string string_8)
	{
		string[,] array = new string[200, 13];
		try
		{
			string text = "ddd";
			string text2 = value.ToString(text);
			if (text2 != null)
			{
				int length = text2.Length;
				if (length == 3)
				{
					switch (text2[1])
					{
					case 'h':
					{
						string text12 = text2;
						string text13 = "Thu";
						if (text12 == text13)
						{
							string text14 = "TH";
							text2 = text14;
						}
						break;
					}
					case 'e':
					{
						string text6 = text2;
						string text7 = "Wed";
						if (text6 == text7)
						{
							string text8 = "W";
							text2 = text8;
						}
						break;
					}
					case 'a':
					{
						string text21 = text2;
						string text22 = "Sat";
						if (text21 == text22)
						{
							string text23 = "S";
							text2 = text23;
						}
						break;
					}
					case 'u':
					{
						string text15 = text2;
						string text16 = "Tue";
						if (!(text15 == text16))
						{
							string text17 = text2;
							string text18 = "Sun";
							if (text17 == text18)
							{
								string text19 = "SU";
								text2 = text19;
							}
						}
						else
						{
							string text20 = "T";
							text2 = text20;
						}
						break;
					}
					case 'r':
					{
						string text9 = text2;
						string text10 = "Fri";
						if (text9 == text10)
						{
							string text11 = "F";
							text2 = text11;
						}
						break;
					}
					case 'o':
					{
						string text3 = text2;
						string text4 = "Mon";
						if (text3 == text4)
						{
							string text5 = "M";
							text2 = text5;
						}
						break;
					}
					}
				}
			}
			string[] array2 = new string[5];
			string text24 = "https://erail.in/rail/getTrains.aspx?Station_From=";
			array2[0] = text24;
			array2[1] = string_0;
			string text25 = "&Station_To=";
			array2[2] = text25;
			array2[3] = string_1;
			string text26 = "&DataSource=0&Language=0&Cache=true";
			array2[4] = text26;
			string[] array3 = smethod_1(string.Concat(array2), "", "", "").Split('^');
			int num = Information.UBound(array3);
			int num2 = 0;
			for (int i = 1; i <= num; i++)
			{
				string[] array4 = array3[i].ToString().Split('~');
				string text27 = array4[13];
				string text28 = "";
				string text29 = "";
				for (int j = 0; j <= 6; j++)
				{
					string text30 = text27.Substring(j, 1);
					string text31 = "1";
					if (text30 == text31)
					{
						switch (j)
						{
						case 0:
						{
							string text38 = "M ";
							text28 = text38;
							break;
						}
						case 1:
						{
							string text37 = "T ";
							text28 = text37;
							break;
						}
						case 2:
						{
							string text36 = "W ";
							text28 = text36;
							break;
						}
						case 3:
						{
							string text35 = "TH ";
							text28 = text35;
							break;
						}
						case 4:
						{
							string text34 = "F ";
							text28 = text34;
							break;
						}
						case 5:
						{
							string text33 = "S ";
							text28 = text33;
							break;
						}
						case 6:
						{
							string text32 = "SU";
							text28 = text32;
							break;
						}
						}
					}
					else
					{
						string text39 = "- ";
						text28 = text39;
						if (j == 6)
						{
							string text40 = "-";
							text28 = text40;
						}
					}
					text29 += text28;
				}
				string text41 = array4[21];
				string text42 = array4[0];
				string text43 = "12009";
				_ = text42 == text43;
				string text44 = "";
				string text45 = "";
				for (int k = 0; k <= 11; k++)
				{
					string text46 = text41.Substring(k, 1);
					string text47 = "1";
					if (text46 == text47)
					{
						switch (k)
						{
						case 0:
						{
							string text58 = "1A ";
							text44 = text58;
							break;
						}
						case 1:
						{
							string text57 = "2A ";
							text44 = text57;
							break;
						}
						case 2:
						{
							string text56 = "3A ";
							text44 = text56;
							break;
						}
						case 3:
						{
							string text55 = "CC ";
							text44 = text55;
							break;
						}
						case 4:
						{
							string text54 = "FC ";
							text44 = text54;
							break;
						}
						case 5:
						{
							string text53 = "SL ";
							text44 = text53;
							break;
						}
						case 6:
						{
							string text52 = "2S ";
							text44 = text52;
							break;
						}
						case 7:
						{
							string text51 = "3E ";
							text44 = text51;
							break;
						}
						case 8:
							text44 = "";
							break;
						case 9:
						{
							string text50 = "EA ";
							text44 = text50;
							break;
						}
						case 10:
						{
							string text49 = "EC ";
							text44 = text49;
							break;
						}
						case 11:
						{
							string text48 = "EV ";
							text44 = text48;
							break;
						}
						}
					}
					else
					{
						text44 = "";
					}
					text45 += text44;
				}
				if (text29.Contains(text2))
				{
					array[num2, 0] = array4[0];
					array[num2, 1] = array4[1];
					array[num2, 2] = array4[7];
					array[num2, 3] = array4[9];
					array[num2, 4] = array4[10];
					array[num2, 5] = array4[11];
					array[num2, 6] = array4[12];
					array[num2, 7] = text29;
					array[num2, 8] = text45;
					array[num2, 9] = array4[32];
					array[num2, 10] = array4[41];
					array[num2, 11] = array4[33];
					array[num2, 12] = array4[58];
					num2++;
				}
			}
			return array;
		}
		catch (Exception)
		{
		}
		bool flag = false;
		long num3 = DateTime.Now.Hour * 10000 + DateTime.Now.Minute * 100 + DateTime.Now.Second;
		if ((75000 <= num3 && num3 <= 81500) || (95000 <= num3 && num3 <= 101500) || (105000 <= num3 && num3 <= 111500))
		{
			flag = true;
		}
		string text59 = usr;
		string pwd = Pwd;
		string text60 = "";
		if (!flag)
		{
			text60 = method_1C(string_0, string_1, string_2, value, string_7, string_8);
		}
		if (text60 == "")
		{
			string[] array5 = new string[12];
			string text61 = "TrainInfo:";
			array5[0] = text61;
			array5[1] = string_0;
			string text62 = "||";
			array5[2] = text62;
			array5[3] = string_1;
			string text63 = "||";
			array5[4] = text63;
			array5[5] = string_2;
			string text64 = "||";
			array5[6] = text64;
			string text65 = "yyyMMdd";
			array5[7] = value.ToString(text65);
			string text66 = "||";
			array5[8] = text66;
			array5[9] = string_7;
			string text67 = "||";
			array5[10] = text67;
			array5[11] = string_8;
			string errMessage = string.Concat(array5);
			text60 = Program.mcommInstance_.isLV(text59.Trim(), pwd.Trim(), ref errMessage);
		}
		string text68 = text60;
		string text69 = text60;
		string value2 = "trainBtwnStnsList";
		string text70 = text68.Substring(text69.IndexOf(value2));
		string value3 = "[";
		string text71 = text70.Substring(text70.IndexOf(value3) + 1);
		string value4 = "]";
		string text72 = text71.Substring(0, text71.LastIndexOf(value4));
		string[] array6 = new string[2];
		string text73 = "{";
		array6[0] = text73;
		string text74 = "},";
		array6[1] = text74;
		List<string> list = new List<string>(text72.Split(array6, StringSplitOptions.None));
		list.RemoveAll(smethod_0);
		int num4 = 0;
		for (int l = 0; l < list.Count; l++)
		{
			string text75 = list[l].ToString();
			string[] array7 = text75.Split(',');
			int num5 = num4;
			string text76 = array7[0];
			string text77 = array7[0];
			string value5 = ":";
			string text78 = text76.Substring(text77.IndexOf(value5) + 2);
			string oldValue = "\"";
			array[num5, 5] = text78.Replace(oldValue, "");
			string value6 = "avlClasses\":[";
			if (text75.IndexOf(value6) <= 0)
			{
				int num6 = num4;
				string text79 = array7[2];
				string text80 = array7[2];
				string value7 = ":";
				string text81 = text79.Substring(text80.IndexOf(value7) + 2);
				string oldValue2 = "\"";
				string text82 = text81.Replace(oldValue2, "");
				string oldValue3 = ",";
				string newValue = " ";
				array[num6, 8] = text82.Replace(oldValue3, newValue);
			}
			else
			{
				string value8 = "avlClasses";
				string text83 = text75.Substring(text75.IndexOf(value8));
				string value9 = "[";
				string text84 = text83.Substring(text83.IndexOf(value9) + 1);
				string value10 = "]";
				string text85 = text84.Substring(0, text84.IndexOf(value10));
				int num7 = num4;
				string oldValue4 = "\"";
				string text86 = text85.Replace(oldValue4, "");
				string oldValue5 = ",";
				string newValue2 = " ";
				array[num7, 8] = text86.Replace(oldValue5, newValue2);
			}
			string value11 = "departureTime";
			string text87 = text75.Substring(text75.IndexOf(value11) - 1);
			string[] array8 = text87.Split(',');
			int num8 = num4;
			string text88 = array8[14];
			string text89 = array8[14];
			string value12 = ":";
			string text90 = text88.Substring(text89.IndexOf(value12) + 2);
			string oldValue6 = "\"";
			array[num8, 0] = text90.Replace(oldValue6, "");
			int num9 = num4;
			string text91 = array8[13];
			string text92 = array8[13];
			string value13 = ":";
			string text93 = text91.Substring(text92.IndexOf(value13) + 2);
			string oldValue7 = "\"";
			array[num9, 1] = text93.Replace(oldValue7, "");
			int num10 = num4;
			string text94 = array8[4];
			string text95 = array8[4];
			string value14 = ":";
			string text96 = text94.Substring(text95.IndexOf(value14) + 2);
			string oldValue8 = "\"";
			array[num10, 2] = text96.Replace(oldValue8, "");
			int num11 = num4;
			string text97 = array8[12];
			string text98 = array8[12];
			string value15 = ":";
			string text99 = text97.Substring(text98.IndexOf(value15) + 2);
			string oldValue9 = "\"";
			array[num11, 3] = text99.Replace(oldValue9, "");
			int num12 = num4;
			string text100 = array8[0];
			string text101 = array8[0];
			string value16 = ":";
			string text102 = text100.Substring(text101.IndexOf(value16) + 2);
			string oldValue10 = "\"";
			array[num12, 4] = text102.Replace(oldValue10, "");
			int num13 = num4;
			string text103 = array8[2];
			string text104 = array8[2];
			string value17 = ":";
			string text105 = text103.Substring(text104.IndexOf(value17) + 2);
			string oldValue11 = "\"";
			array[num13, 6] = text105.Replace(oldValue11, "");
			int num14 = num4;
			string[] array9 = new string[7];
			string value18 = "\"runningMon\":\"Y\"";
			string text107;
			if (!text87.Contains(value18))
			{
				string text106 = "- ";
				text107 = text106;
			}
			else
			{
				string text108 = "M ";
				text107 = text108;
			}
			array9[0] = text107;
			string value19 = "\"runningTue\":\"Y\"";
			string text110;
			if (!text87.Contains(value19))
			{
				string text109 = "- ";
				text110 = text109;
			}
			else
			{
				string text111 = "T ";
				text110 = text111;
			}
			array9[1] = text110;
			string value20 = "\"runningWed\":\"Y\"";
			string text113;
			if (!text87.Contains(value20))
			{
				string text112 = "- ";
				text113 = text112;
			}
			else
			{
				string text114 = "W ";
				text113 = text114;
			}
			array9[2] = text113;
			string value21 = "\"runningThu\":\"Y\"";
			string text116;
			if (!text87.Contains(value21))
			{
				string text115 = "- ";
				text116 = text115;
			}
			else
			{
				string text117 = "TH ";
				text116 = text117;
			}
			array9[3] = text116;
			string value22 = "\"runningFri\":\"Y\"";
			string text119;
			if (!text87.Contains(value22))
			{
				string text118 = "- ";
				text119 = text118;
			}
			else
			{
				string text120 = "F ";
				text119 = text120;
			}
			array9[4] = text119;
			string value23 = "\"runningSat\":\"Y\"";
			string text122;
			if (!text87.Contains(value23))
			{
				string text121 = "- ";
				text122 = text121;
			}
			else
			{
				string text123 = "S ";
				text122 = text123;
			}
			array9[5] = text122;
			string value24 = "\"runningSun\":\"Y\"";
			string text125;
			if (!text87.Contains(value24))
			{
				string text124 = "-";
				text125 = text124;
			}
			else
			{
				string text126 = "SU";
				text125 = text126;
			}
			array9[6] = text125;
			array[num14, 7] = string.Concat(array9);
			array[num4, 9] = "";
			array[num4, 10] = "";
			array[num4, 11] = "";
			num4++;
		}
		return array;
	}

	public static string GetString(string string_86, string string_87)
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

	internal static Image method_101(string string_86, string string_87, CookieContainer cookieContainer_2)
	{
		int num = 0;
		while (true)
		{
			HttpWebResponse httpWebResponse = null;
			int num2 = 0;
			int num3 = 0;
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string_86);
				ServicePointManager.DefaultConnectionLimit = 9999;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
				httpWebRequest.ProtocolVersion = HttpVersion.Version11;
				httpWebRequest.Timeout = 15000;
				if (cookieContainer_2 == null)
				{
					cookieContainer_2 = new CookieContainer();
				}
				httpWebRequest.CookieContainer = cookieContainer_2;
				string method = "GET";
				httpWebRequest.Method = method;
				string accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";
				httpWebRequest.Accept = accept;
				WebHeaderCollection headers = httpWebRequest.Headers;
				string name = "Upgrade-Insecure-Requests";
				string value = "1";
				headers.Add(name, value);
				httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				if (httpWebResponse.StatusCode != HttpStatusCode.Found && httpWebResponse.StatusCode != HttpStatusCode.MovedPermanently)
				{
					goto IL_0140;
				}
				WebHeaderCollection headers2 = httpWebResponse.Headers;
				string name2 = "Location";
				string text = headers2[name2].ToString();
				string value2 = "errors.html";
				if (!text.Contains(value2) || num >= 10)
				{
					goto IL_0140;
				}
				httpWebResponse.Close();
				httpWebResponse = null;
				goto end_IL_000f;
				IL_0140:
				Image result;
				if (num2 != 0)
				{
					MemoryStream memoryStream = new MemoryStream();
					using (Stream stream = httpWebResponse.GetResponseStream())
					{
						byte[] array = new byte[4096];
						int num4;
						while ((num4 = stream.Read(array, 0, array.Length)) != 0)
						{
							num3 += num4;
							memoryStream.Write(array, 0, num4);
						}
					}
					memoryStream.Flush();
					result = new Bitmap(memoryStream);
				}
				else
				{
					result = new Bitmap(httpWebResponse.GetResponseStream());
				}
				httpWebResponse.Close();
				return result;
				end_IL_000f:;
			}
			catch (WebException)
			{
				break;
			}
			catch (Exception)
			{
				break;
			}
			finally
			{
				try
				{
					httpWebResponse?.Dispose();
				}
				catch
				{
				}
			}
		}
		return null;
	}

	public static string method_102(string url, string data, string reff, CookieContainer cookieContainer_2)
	{
		string result = "";
		HttpWebResponse httpWebResponse = null;
		try
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
			httpWebRequest.Proxy = null;
			httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
			httpWebRequest.Timeout = 35000;
			httpWebRequest.ReadWriteTimeout = 35000;
			if (cookieContainer_2 == null)
			{
				cookieContainer_2 = new CookieContainer();
			}
			httpWebRequest.CookieContainer = cookieContainer_2;
			httpWebRequest.KeepAlive = true;
			string connection = "keepalive";
			httpWebRequest.Connection = connection;
			WebHeaderCollection headers = httpWebRequest.Headers;
			string name = "X-Requested-With";
			string value = "XMLHttpRequest";
			headers.Add(name, value);
			WebHeaderCollection headers2 = httpWebRequest.Headers;
			string name2 = "Accept-Language";
			string value2 = "en-IN,en-GB;q=0.9,en-US;q=0.8,en;q=0.7,hi;q=0.6";
			headers2.Add(name2, value2);
			httpWebRequest.Referer = reff;
			string accept = "*/*";
			httpWebRequest.Accept = accept;
			string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/141.0.0.0 Safari/537.36";
			httpWebRequest.UserAgent = userAgent;
			if (string.IsNullOrEmpty(data))
			{
				string method = "GET";
				httpWebRequest.Method = method;
			}
			else
			{
				using Stream stream = httpWebRequest.GetRequestStream();
				string method2 = "POST";
				httpWebRequest.Method = method2;
				byte[] bytes = Encoding.UTF8.GetBytes(data);
				stream.Write(bytes, 0, bytes.Length);
			}
			httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			switch (httpWebResponse.StatusCode)
			{
			default:
			{
				Stream responseStream = httpWebResponse.GetResponseStream();
				StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);
				foreach (Cookie cookie3 in httpWebResponse.Cookies)
				{
					string name3 = cookie3.Name;
					string text = "f5avraaaaaaaaaaaaaaaa_session_";
					if (name3 == text)
					{
						CookieContainer cookieContainer = cookieContainer_2;
						string name4 = "f5avraaaaaaaaaaaaaaaa_session_";
						Cookie cookie2 = new Cookie(name4, cookie3.Value);
						string domain = "indianrail.gov.in";
						cookie2.Domain = domain;
						cookieContainer.Add(cookie2);
					}
				}
				result = streamReader.ReadToEnd();
				streamReader.Close();
				responseStream.Close();
				break;
			}
			case HttpStatusCode.MovedPermanently:
			case HttpStatusCode.Found:
			case HttpStatusCode.SeeOther:
			case HttpStatusCode.TemporaryRedirect:
			{
				HttpWebResponse httpWebResponse2 = httpWebResponse;
				string headerName = "Location";
				httpWebResponse2.GetResponseHeader(headerName);
				break;
			}
			case HttpStatusCode.NotModified:
			case HttpStatusCode.UseProxy:
			case HttpStatusCode.Unused:
				break;
			}
		}
		catch (WebException)
		{
		}
		catch (Exception)
		{
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
		return result;
	}

	private static string BitmapToBase64(Image bitmap)
	{
		using MemoryStream memoryStream = new MemoryStream();
		bitmap.Save(memoryStream, ImageFormat.Png);
		return Convert.ToBase64String(memoryStream.ToArray());
	}

	private static string req(string url, string data)
	{
		HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
		ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
		string contentType = "application/json";
		httpWebRequest.ContentType = contentType;
		string method = "POST";
		httpWebRequest.Method = method;
		httpWebRequest.Timeout = 15000;
		httpWebRequest.ReadWriteTimeout = 15000;
		using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
		{
			streamWriter.Write(data);
		}
		using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
		return streamReader.ReadToEnd();
	}

	private static string ocr(Image bb2)
	{
		string result = string.Empty;
		try
		{
			string path = "myfile.png";
			if (File.Exists(path))
			{
				string path2 = "myfile.png";
				File.Delete(path2);
			}
			string filename = "myfile.png";
			bb2.Save(filename, ImageFormat.Png);
			string text = "myfile.png";
			string arguments = text;
			Process process = new Process();
			ProcessStartInfo startInfo = process.StartInfo;
			string fileName = "HitmanTesseract.exe";
			startInfo.FileName = fileName;
			process.StartInfo.Arguments = arguments;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardOutput = true;
			process.Start();
			StreamReader standardOutput = process.StandardOutput;
			process.WaitForExit(3500);
			result = standardOutput.ReadLine();
			if (!process.HasExited)
			{
				process.Kill();
			}
		}
		catch (Exception)
		{
		}
		return result;
	}

	public static string method_2A(string _from, string _to, string trainNum, DateTime value, string _class, string _quota)
	{
		string text = "";
		string text2 = "";
		bool flag = false;
		int num = DateTime.Now.Hour * 10000;
		int num2 = DateTime.Now.Minute * 100;
		int num3 = num + num2;
		int second = DateTime.Now.Second;
		long num4 = num3 + second;
		if (73000 <= num4 && num4 <= 113000)
		{
			flag = true;
		}
		int num5 = 0;
		string text3 = "";
		if (CheckingAvl)
		{
			return "Wait...";
		}
		try
		{
			string text4 = "dd-M";
			value.ToString(text4);
			if (!flag)
			{
				CheckingAvl = true;
				text3 = method_3C(_from, _to, trainNum, value, _class, _quota);
				CheckingAvl = false;
			}
			if (string.IsNullOrEmpty(text3))
			{
				while (true)
				{
					CheckingAvl = true;
					CookieContainer cookieContainer_ = new CookieContainer();
					DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
					string text5 = ((long)(DateTime.UtcNow - dateTime).TotalMilliseconds).ToString();
					string text6 = "https://www.indianrail.gov.in/enquiry/CaptchaConfig?_=";
					string url = text6 + text5;
					string reff = "https://www.indianrail.gov.in/enquiry/SEAT/SeatAvailability.html?locale=en";
					method_102(url, "", reff, cookieContainer_);
					string text8;
					do
					{
						dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
						text5 = ((long)(DateTime.UtcNow - dateTime).TotalMilliseconds).ToString();
						string text7 = "https://www.indianrail.gov.in/enquiry/captchaDraw.png?";
						text8 = ocr(method_101(text7 + text5, "", cookieContainer_));
					}
					while (string.IsNullOrEmpty(text8) | (text8.Length > 3));
					dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
					text5 = ((long)(DateTime.UtcNow - dateTime).TotalMilliseconds).ToString();
					string text9 = ClassStationData.dic_Station[_from];
					string oldValue = " ";
					string newValue = "+";
					string text10 = text9.Replace(oldValue, newValue);
					string text11 = "+-+";
					string text12 = text10 + text11 + _from;
					string text13 = ClassStationData.dic_Station[_to];
					string oldValue2 = " ";
					string newValue2 = "+";
					string text14 = text13.Replace(oldValue2, newValue2);
					string text15 = "+-+";
					string text16 = text14 + text15 + _to;
					string text17 = "+-+";
					string text18 = ClassStationData.dic_Train[trainNum];
					string oldValue3 = " ";
					string newValue3 = "+";
					string text19 = trainNum + text17 + text18.Replace(oldValue3, newValue3);
					string[] array = new string[16];
					string text20 = "https://www.indianrail.gov.in/enquiry/CommonCaptcha?inputCaptcha=";
					array[0] = text20;
					array[1] = text8;
					string text21 = "&trainNo=";
					array[2] = text21;
					array[3] = text19;
					string text22 = "&dt=";
					array[4] = text22;
					string text23 = "dd-MM-yyyy";
					array[5] = value.ToString(text23);
					string text24 = "&sourceStation=";
					array[6] = text24;
					array[7] = text12;
					string text25 = "&destinationStation=";
					array[8] = text25;
					array[9] = text16;
					string text26 = "&classc=";
					array[10] = text26;
					array[11] = _class;
					string text27 = "&quota=";
					array[12] = text27;
					array[13] = _quota;
					string text28 = "&inputPage=SEAT&language=en&_=";
					array[14] = text28;
					array[15] = text5;
					string url2 = string.Concat(array);
					string reff2 = "https://www.indianrail.gov.in/enquiry/SEAT/SeatAvailability.html?locale=en";
					string text29 = method_102(url2, "", reff2, cookieContainer_);
					string value2 = "availablityStatus";
					if (!text29.Contains(value2))
					{
						string string_ = "errorMessage";
						GetString(text29, string_);
						string value3 = "Captcha not matched";
						bool flag2 = text29.Contains(value3);
						string value4 = "Please enter a valid train number";
						if (!(flag2 | text29.Contains(value4)))
						{
							num5++;
							if (num5 >= 4)
							{
								break;
							}
						}
						continue;
					}
					string string_2 = "availablityStatus";
					text = GetString(text29, string_2);
					try
					{
						dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
						text5 = ((long)(DateTime.UtcNow - dateTime).TotalMilliseconds).ToString();
						string[] array2 = new string[16];
						string text30 = "https://www.indianrail.gov.in/enquiry/CommonCaptcha?inputCaptcha=";
						array2[0] = text30;
						array2[1] = text8;
						string text31 = "&trainNo=";
						array2[2] = text31;
						array2[3] = text19;
						string text32 = "&dt=";
						array2[4] = text32;
						string text33 = "dd-MM-yyyy";
						array2[5] = value.ToString(text33);
						string text34 = "&sourceStation=";
						array2[6] = text34;
						array2[7] = text12;
						string text35 = "&destinationStation=";
						array2[8] = text35;
						array2[9] = text16;
						string text36 = "&classc=";
						array2[10] = text36;
						array2[11] = _class;
						string text37 = "&quota=";
						array2[12] = text37;
						array2[13] = _quota;
						string text38 = "&inputPage=FARE&language=en&_=";
						array2[14] = text38;
						array2[15] = text5;
						string url3 = string.Concat(array2);
						string reff3 = "https://www.indianrail.gov.in/enquiry/FARE/FareEnquiry.html?locale=en";
						string text39 = method_102(url3, "", reff3, cookieContainer_);
						string value5 = "totalFare";
						if (text39.Contains(value5))
						{
							string value6 = "totalFare";
							string text40 = text39.Substring(text39.IndexOf(value6) + 11);
							string value7 = ",";
							text2 = text40.Substring(0, text40.IndexOf(value7));
						}
					}
					catch (Exception)
					{
					}
					string[] array3 = new string[7] { trainNum, null, null, null, null, null, null };
					string text41 = "||";
					array3[1] = text41;
					string text42 = "yyyMMdd";
					array3[2] = value.ToString(text42);
					string text43 = "||";
					array3[3] = text43;
					array3[4] = _class;
					string text44 = "||";
					array3[5] = text44;
					array3[6] = _quota;
					text3 = string.Concat(array3);
					break;
				}
			}
			if (text3 == "")
			{
				string[] array4 = new string[7] { trainNum, null, null, null, null, null, null };
				string text45 = "||";
				array4[1] = text45;
				string text46 = "yyyMMdd";
				array4[2] = value.ToString(text46);
				string text47 = "||";
				array4[3] = text47;
				array4[4] = _class;
				string text48 = "||";
				array4[5] = text48;
				array4[6] = _quota;
				text3 = string.Concat(array4);
				string text49 = "Book";
				text = text49;
				string text50 = "0.0";
				text2 = text50;
			}
			CheckingAvl = false;
			string text51 = text3;
			string value8 = "avlDayList";
			if (text51.IndexOf(value8) > 0)
			{
				string string_3 = text3;
				string string_4 = "availablityStatus";
				text = GetString(string_3, string_4);
				string string_5 = text3;
				string string_6 = "totalFare";
				text2 = GetString(string_5, string_6);
			}
			else
			{
				string text52 = text3;
				string value9 = "errorMessage";
				if (text52.IndexOf(value9) > 0)
				{
					string text53 = text3;
					string text54 = text3;
					string value10 = "errorMessage";
					string text55 = text53.Substring(text54.IndexOf(value10) + 15);
					string value11 = "\"";
					text = text55.Substring(0, text55.IndexOf(value11));
				}
			}
			CheckingAvl = false;
			string text56 = text;
			string text57 = "~";
			return text56 + text57 + text2;
		}
		catch (Exception)
		{
			string[] array5 = new string[7] { trainNum, null, null, null, null, null, null };
			string text58 = "||";
			array5[1] = text58;
			string text59 = "yyyMMdd";
			array5[2] = value.ToString(text59);
			string text60 = "||";
			array5[3] = text60;
			array5[4] = _class;
			string text61 = "||";
			array5[5] = text61;
			array5[6] = _quota;
			text3 = string.Concat(array5);
			CheckingAvl = false;
			return "Book~0.0";
		}
	}

	public static string method_3A(string string_0, string string_1, string string_2, DateTime value, string string_7, string string_8)
	{
		bool flag = false;
		int num = DateTime.Now.Hour * 10000;
		int num2 = DateTime.Now.Minute * 100;
		int num3 = num + num2;
		int second = DateTime.Now.Second;
		long num4 = num3 + second;
		if ((75000 <= num4 && num4 <= 81500) || (94000 <= num4 && num4 <= 101500) || (104000 <= num4 && num4 <= 111500))
		{
			flag = true;
		}
		string text = "";
		if (!flag)
		{
			text = method_2C(string_0, string_1, string_2, value, string_7, string_8);
		}
		string text2 = "1";
		string text3 = text2;
		string text4 = "";
		bool flag2 = false;
		string text5 = text;
		string text6 = text;
		string value2 = "stationList";
		string text7 = text5.Substring(text6.IndexOf(value2));
		string value3 = "[";
		string text8 = text7.Substring(text7.IndexOf(value3) + 1);
		string value4 = "]";
		string text9 = text8.Substring(0, text8.LastIndexOf(value4));
		string[] array = new string[2];
		string text10 = "{";
		array[0] = text10;
		string text11 = "},";
		array[1] = text11;
		List<string> list = new List<string>(text9.Split(array, StringSplitOptions.None));
		list.RemoveAll(smethod_0);
		int count = list.Count;
		int num5 = 0;
		for (int i = 0; i < count; i++)
		{
			string[] array2 = list[i].ToString().Split(',');
			string text12 = array2[0];
			string text13 = array2[0];
			string value5 = ":";
			string text14 = text12.Substring(text13.IndexOf(value5) + 2);
			string oldValue = "\"";
			string text15 = text14.Replace(oldValue, "");
			if (text15 == string_0)
			{
				string text16 = array2[4];
				string text17 = array2[4];
				string value6 = ":";
				string text18 = text16.Substring(text17.IndexOf(value6) + 2);
				string oldValue2 = "\"";
				text3 = text18.Replace(oldValue2, "");
				flag2 = true;
			}
			if (flag2)
			{
				text4 += text15;
			}
			string text19 = text4;
			string text20 = ",";
			text4 = text19 + text20;
			num5++;
		}
		string text21 = text3;
		string text22 = "~";
		return text21 + text22 + text4;
	}

	private static bool smethod_0(string string_0)
	{
		return string_0 == "";
	}

	public static string method_1C(string string_0, string string_1, string string_2, DateTime value, string string_7, string string_8)
	{
		string result = "";
		try
		{
			string[] array = new string[7];
			string text = "https://www.irctc.co.in/eticketing/protected/mapps1/tbstns/";
			array[0] = text;
			array[1] = string_0;
			string text2 = "/";
			array[2] = text2;
			array[3] = string_1;
			string text3 = "/";
			array[4] = text3;
			string text4 = "yyyMMdd";
			array[5] = value.ToString(text4);
			string text5 = "?dateSpecific=N&ftBooking=N&redemBooking=N";
			array[6] = text5;
			string requestUriString = string.Concat(array);
			HttpWebResponse httpWebResponse = null;
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
				httpWebRequest.Proxy = null;
				httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
				httpWebRequest.Timeout = 35000;
				httpWebRequest.ReadWriteTimeout = 35000;
				string method = "GET";
				httpWebRequest.Method = method;
				string accept = "application/json, text/plain, */*";
				httpWebRequest.Accept = accept;
				httpWebRequest.KeepAlive = true;
				httpWebRequest.CookieContainer = IrctcCookie_0;
				string contentType = "application/x-www-form-urlencoded";
				httpWebRequest.ContentType = contentType;
				WebHeaderCollection headers = httpWebRequest.Headers;
				string name = "greq";
				string value2 = "DM02AP07MS1-9756aa4d-0789-4ae3-880c-2fdf97ebdfde";
				headers.Add(name, value2);
				string userAgent = "Mozilla/5.0 (Windows T 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/27.0.1453.116 Safari/537.36";
				httpWebRequest.UserAgent = userAgent;
				WebHeaderCollection headers2 = httpWebRequest.Headers;
				string name2 = "Cache-Control";
				string value3 = "no-cache";
				headers2.Set(name2, value3);
				WebHeaderCollection headers3 = httpWebRequest.Headers;
				string name3 = "Accept-Language";
				string value4 = "en-US,en;q=0.8";
				headers3.Set(name3, value4);
				WebHeaderCollection headers4 = httpWebRequest.Headers;
				string name4 = "X-Requested-With";
				string value5 = "XMLHttpRequest";
				headers4.Set(name4, value5);
				string referer = "http://www.indianrail.gov.in/seat_Avail.htm/";
				httpWebRequest.Referer = referer;
				httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				switch (httpWebResponse.StatusCode)
				{
				default:
				{
					Stream responseStream = httpWebResponse.GetResponseStream();
					StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);
					result = streamReader.ReadToEnd();
					streamReader.Close();
					responseStream.Close();
					break;
				}
				case HttpStatusCode.MovedPermanently:
				case HttpStatusCode.Found:
				case HttpStatusCode.SeeOther:
				case HttpStatusCode.TemporaryRedirect:
				{
					HttpWebResponse httpWebResponse2 = httpWebResponse;
					string headerName = "Location";
					httpWebResponse2.GetResponseHeader(headerName);
					break;
				}
				case HttpStatusCode.NotModified:
				case HttpStatusCode.UseProxy:
				case HttpStatusCode.Unused:
					break;
				}
			}
			catch (Exception ex)
			{
				string string_9 = "WebRequestPost";
				Class28.smethod_26(string_9, ex.Message);
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
		catch
		{
		}
		return result;
	}

	public static string method_2C(string string_0, string string_1, string string_2, DateTime value, string string_7, string string_8)
	{
		string result = "";
		try
		{
			string text = "https://www.irctc.co.in/eticketing/protected/mapps1/trnscheduleenquiry/";
			string text2 = "?journeyDate=";
			string text3 = "yyyMMdd";
			string requestUriString = text + string_2 + text2 + value.ToString(text3);
			HttpWebResponse httpWebResponse = null;
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
				if (prx0 == null)
				{
					httpWebRequest.Proxy = null;
				}
				else
				{
					httpWebRequest.Proxy = prx0;
				}
				httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
				httpWebRequest.Timeout = 35000;
				httpWebRequest.ReadWriteTimeout = 35000;
				string method = "GET";
				httpWebRequest.Method = method;
				string accept = "application/json, text/plain, */*";
				httpWebRequest.Accept = accept;
				httpWebRequest.KeepAlive = true;
				httpWebRequest.CookieContainer = IrctcCookie_0;
				string contentType = "application/x-www-form-urlencoded";
				httpWebRequest.ContentType = contentType;
				WebHeaderCollection headers = httpWebRequest.Headers;
				string name = "greq";
				string value2 = "DM02AP07MS1-9756aa4d-0789-4ae3-880c-2fdf97ebdfde";
				headers.Add(name, value2);
				string userAgent = "Mozilla/5.0 (Windows T 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/27.0.1453.116 Safari/537.36";
				httpWebRequest.UserAgent = userAgent;
				WebHeaderCollection headers2 = httpWebRequest.Headers;
				string name2 = "Cache-Control";
				string value3 = "no-cache";
				headers2.Set(name2, value3);
				WebHeaderCollection headers3 = httpWebRequest.Headers;
				string name3 = "Accept-Language";
				string value4 = "en-US,en;q=0.8";
				headers3.Set(name3, value4);
				WebHeaderCollection headers4 = httpWebRequest.Headers;
				string name4 = "X-Requested-With";
				string value5 = "XMLHttpRequest";
				headers4.Set(name4, value5);
				string referer = "http://www.indianrail.gov.in/seat_Avail.htm/";
				httpWebRequest.Referer = referer;
				httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				switch (httpWebResponse.StatusCode)
				{
				default:
				{
					Stream responseStream = httpWebResponse.GetResponseStream();
					StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);
					result = streamReader.ReadToEnd();
					streamReader.Close();
					responseStream.Close();
					break;
				}
				case HttpStatusCode.MovedPermanently:
				case HttpStatusCode.Found:
				case HttpStatusCode.SeeOther:
				case HttpStatusCode.TemporaryRedirect:
				{
					HttpWebResponse httpWebResponse2 = httpWebResponse;
					string headerName = "Location";
					httpWebResponse2.GetResponseHeader(headerName);
					break;
				}
				case HttpStatusCode.NotModified:
				case HttpStatusCode.UseProxy:
				case HttpStatusCode.Unused:
					break;
				}
			}
			catch (Exception ex)
			{
				string string_9 = "WebRequestPost";
				Class28.smethod_26(string_9, ex.Message);
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
		catch
		{
		}
		return result;
	}

	public static string method_3C(string string_0, string string_1, string string_2, DateTime value, string string_7, string string_8)
	{
		string result = "";
		string[] array = new string[13];
		string text = "https://www.irctc.co.in/eticketing/protected/mapps1/avlFareenquiry/";
		array[0] = text;
		array[1] = string_2;
		string text2 = "/";
		array[2] = text2;
		string text3 = "yyyMMdd";
		array[3] = value.ToString(text3);
		string text4 = "/";
		array[4] = text4;
		array[5] = string_0;
		string text5 = "/";
		array[6] = text5;
		array[7] = string_1;
		string text6 = "/";
		array[8] = text6;
		array[9] = string_7;
		string text7 = "/";
		array[10] = text7;
		array[11] = string_8;
		string text8 = "/N";
		array[12] = text8;
		string requestUriString = string.Concat(array);
		string text9 = "{\"enquiryType\":\"3\",\"clusterFlag\":\"N\",\"onwardFlag\":\"N\",\"cod\":false,\"reservationMode\":\"N_MOBILE_ANDROID\",\"autoUpgradationSelected\":false,\"ticketChoiceSameCoach\":false,\"reservationChoice\":99,\"ignoreChoiceIfWl\":true,\"concessionBooking\":false,\"generalistChildConfirm\":false,\"ftBooking\":false,\"loyaltyRedemptionBooking\":false,\"nosbBooking\":false,\"returnJourney\":false,\"connectingJourney\":false,\"paymentType\":1,\"moreThanOneDay\":true,\"ticketType\":\"E\",\"mainJourneyPnr\":\"\"}";
		string s = text9;
		HttpWebResponse httpWebResponse = null;
		try
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
			httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
			httpWebRequest.Timeout = 35000;
			httpWebRequest.ReadWriteTimeout = 35000;
			string method = "POST";
			httpWebRequest.Method = method;
			string accept = "application/json, text/plain, */*";
			httpWebRequest.Accept = accept;
			httpWebRequest.KeepAlive = true;
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			string contentType = "application/json; charset=UTF-8";
			httpWebRequest.ContentType = contentType;
			WebHeaderCollection headers = httpWebRequest.Headers;
			string name = "greq";
			string value2 = "DM02AP07MS1-9756aa4d-0789-4ae3-880c-2fdf97ebdfde";
			headers.Add(name, value2);
			string userAgent = "Mozilla/5.0 (Windows T 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/27.0.1453.116 Safari/537.36";
			httpWebRequest.UserAgent = userAgent;
			WebHeaderCollection headers2 = httpWebRequest.Headers;
			string name2 = "Cache-Control";
			string value3 = "no-cache";
			headers2.Set(name2, value3);
			WebHeaderCollection headers3 = httpWebRequest.Headers;
			string name3 = "Accept-Language";
			string value4 = "en-US,en;q=0.8";
			headers3.Set(name3, value4);
			WebHeaderCollection headers4 = httpWebRequest.Headers;
			string name4 = "X-Requested-With";
			string value5 = "XMLHttpRequest";
			headers4.Set(name4, value5);
			WebHeaderCollection headers5 = httpWebRequest.Headers;
			string name5 = "bmirak";
			string value6 = "webbm";
			headers5.Add(name5, value6);
			using (Stream stream = httpWebRequest.GetRequestStream())
			{
				stream.Write(bytes, 0, bytes.Length);
			}
			string referer = "http://www.indianrail.gov.in/seat_Avail.htm/";
			httpWebRequest.Referer = referer;
			httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			switch (httpWebResponse.StatusCode)
			{
			default:
			{
				Stream responseStream = httpWebResponse.GetResponseStream();
				StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);
				result = streamReader.ReadToEnd();
				streamReader.Close();
				responseStream.Close();
				break;
			}
			case HttpStatusCode.MovedPermanently:
			case HttpStatusCode.Found:
			case HttpStatusCode.SeeOther:
			case HttpStatusCode.TemporaryRedirect:
			{
				HttpWebResponse httpWebResponse2 = httpWebResponse;
				string headerName = "Location";
				httpWebResponse2.GetResponseHeader(headerName);
				break;
			}
			case HttpStatusCode.NotModified:
			case HttpStatusCode.UseProxy:
			case HttpStatusCode.Unused:
				break;
			}
		}
		catch (WebException)
		{
		}
		catch (Exception)
		{
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
		return result;
	}

	public static string method_9C(string url, string data)
	{
		string result = "";
		HttpWebResponse httpWebResponse = null;
		try
		{
			string value = new ChromeUser().buildChromeHeader(HookEvent.Webmtoken);
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
			WebHeaderCollection headers = httpWebRequest.Headers;
			string name = "X-acf-sensor-data";
			headers.Add(name, value);
			string userAgent = "IRCTC Rail Connect/3.1.27iOS";
			httpWebRequest.UserAgent = userAgent;
			WebHeaderCollection headers2 = httpWebRequest.Headers;
			string name2 = "bmirak";
			string value2 = "androidbm";
			headers2.Add(name2, value2);
			httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
			httpWebRequest.Timeout = 35000;
			httpWebRequest.ReadWriteTimeout = 35000;
			string method = "POST";
			httpWebRequest.Method = method;
			string contentType = "application/json; charset=UTF-8";
			httpWebRequest.ContentType = contentType;
			string accept = "application/json, text/plain, */*";
			httpWebRequest.Accept = accept;
			httpWebRequest.KeepAlive = true;
			byte[] bytes = Encoding.UTF8.GetBytes(data);
			DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
			long num = (long)(DateTime.UtcNow - dateTime).TotalMilliseconds;
			WebHeaderCollection headers3 = httpWebRequest.Headers;
			string name3 = "greq";
			headers3.Add(name3, num.ToString());
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
			WebHeaderCollection headers4 = httpWebRequest.Headers;
			string name4 = "bmirak";
			string value3 = "webbm";
			headers4.Add(name4, value3);
			string userAgent2 = "IRCTC Rail Connect/3.1.27iOS";
			httpWebRequest.UserAgent = userAgent2;
			WebHeaderCollection headers5 = httpWebRequest.Headers;
			string name5 = "Accept-Language";
			string value4 = "en-US,en;q=0.8";
			headers5.Set(name5, value4);
			using (Stream stream = httpWebRequest.GetRequestStream())
			{
				stream.Write(bytes, 0, bytes.Length);
			}
			string referer = "https://www.irctc.co.in/nget/train-list";
			httpWebRequest.Referer = referer;
			httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			switch (httpWebResponse.StatusCode)
			{
			default:
			{
				Stream responseStream = httpWebResponse.GetResponseStream();
				StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);
				result = streamReader.ReadToEnd();
				streamReader.Close();
				responseStream.Close();
				break;
			}
			case HttpStatusCode.MovedPermanently:
			case HttpStatusCode.Found:
			case HttpStatusCode.SeeOther:
			case HttpStatusCode.TemporaryRedirect:
			{
				HttpWebResponse httpWebResponse2 = httpWebResponse;
				string headerName = "Location";
				httpWebResponse2.GetResponseHeader(headerName);
				break;
			}
			case HttpStatusCode.NotModified:
			case HttpStatusCode.UseProxy:
			case HttpStatusCode.Unused:
				break;
			}
		}
		catch (WebException)
		{
		}
		catch (Exception)
		{
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
		return result;
	}

	public static string method_9C_Irctc(string url, string data)
	{
		string result = "";
		HttpWebResponse httpWebResponse = null;
		try
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
			httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
			httpWebRequest.Timeout = 35000;
			httpWebRequest.ReadWriteTimeout = 35000;
			string method = "POST";
			httpWebRequest.Method = method;
			string contentType = "application/json; charset=UTF-8";
			httpWebRequest.ContentType = contentType;
			string accept = "application/json";
			httpWebRequest.Accept = accept;
			httpWebRequest.KeepAlive = true;
			byte[] bytes = Encoding.UTF8.GetBytes(data);
			DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
			long num = (long)(DateTime.UtcNow - dateTime).TotalMilliseconds;
			WebHeaderCollection headers = httpWebRequest.Headers;
			string name = "greq";
			headers.Add(name, num.ToString());
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
			WebHeaderCollection headers2 = httpWebRequest.Headers;
			string name2 = "bmirak";
			string value = "webbm";
			headers2.Add(name2, value);
			string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.0.0 Safari/537.36";
			httpWebRequest.UserAgent = userAgent;
			WebHeaderCollection headers3 = httpWebRequest.Headers;
			string name3 = "Accept-Language";
			string value2 = "en-US,en;q=0.8";
			headers3.Set(name3, value2);
			string x_data = X_data;
			string oldValue = " ";
			string newValue = "+";
			X_data = x_data.Replace(oldValue, newValue);
			WebHeaderCollection headers4 = httpWebRequest.Headers;
			string name4 = "X-acf-sensor-data";
			headers4.Add(name4, X_data);
			string userAgent2 = "IRCTC Rail Connect/3.1.27iOS";
			httpWebRequest.UserAgent = userAgent2;
			WebHeaderCollection headers5 = httpWebRequest.Headers;
			string name5 = "bmirak";
			string value3 = "androidbm";
			headers5.Add(name5, value3);
			using (Stream stream = httpWebRequest.GetRequestStream())
			{
				stream.Write(bytes, 0, bytes.Length);
			}
			string referer = "https://www.irctc.co.in/nget/train-list";
			httpWebRequest.Referer = referer;
			httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			switch (httpWebResponse.StatusCode)
			{
			default:
			{
				Stream responseStream = httpWebResponse.GetResponseStream();
				StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);
				result = streamReader.ReadToEnd();
				streamReader.Close();
				responseStream.Close();
				break;
			}
			case HttpStatusCode.MovedPermanently:
			case HttpStatusCode.Found:
			case HttpStatusCode.SeeOther:
			case HttpStatusCode.TemporaryRedirect:
			{
				HttpWebResponse httpWebResponse2 = httpWebResponse;
				string headerName = "Location";
				httpWebResponse2.GetResponseHeader(headerName);
				break;
			}
			case HttpStatusCode.NotModified:
			case HttpStatusCode.UseProxy:
			case HttpStatusCode.Unused:
				break;
			}
		}
		catch (WebException)
		{
		}
		catch (Exception)
		{
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
		return result;
	}

	private static string Akamai_Sensor_Data_Test()
	{
		string result = "";
		try
		{
			string[] array = new string[5];
			string text = "{\"data\":\"";
			array[0] = text;
			array[1] = Program.clientID;
			string text2 = "\",\"macAddress\":\"";
			array[2] = text2;
			array[3] = Program.mac;
			string text3 = "\",\"MSG\":\"false\"}";
			array[4] = text3;
			string text4 = string.Concat(array);
			string requestUriString = "https://akamai-data.com/api/kk/DTS";
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
			httpWebRequest.Timeout = 60000;
			httpWebRequest.ReadWriteTimeout = 60000;
			string contentType = "application/json";
			httpWebRequest.ContentType = contentType;
			string method = "POST";
			httpWebRequest.Method = method;
			using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
			{
				string value = text4;
				streamWriter.Write(value);
			}
			using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
			string text5 = streamReader.ReadToEnd();
			if (text5.Length > 100)
			{
				string oldValue = "\"";
				result = text5.Replace(oldValue, "");
			}
		}
		catch (Exception)
		{
		}
		return result;
	}

	public static string Datestr(string jda, string jda2)
	{
		string[] array = new string[22];
		string text = "<html>";
		array[0] = text;
		array[1] = Strings.ChrW(10).ToString();
		string text2 = "<head>";
		array[2] = text2;
		array[3] = Strings.ChrW(10).ToString();
		string text3 = "<script type=\"text/javascript\">";
		array[4] = text3;
		array[5] = Strings.ChrW(10).ToString();
		array[6] = Strings.ChrW(9).ToString();
		string text4 = "function DateToStr(date) \n{ \nvar dmy = date.split(\"/\"); \nvar d = new Date(Date.UTC(dmy[2], dmy[1]-1, dmy[0])); \nreturn (d.getTime()); \n} \nfunction StrToDate(timestamp) \n{ \nif(!(isNaN(timestamp))){ \ntimestamp = Number(timestamp); \n} \nvar date = util.getDelhiGMT(timestamp); \nvar day = date.getDate(); \nvar month = date.getMonth()+1; \nvar year = date.getFullYear(); \nvar formattedTime = day + '/' + month + '/' + year; \n return formattedTime; \n} \nvar util={\ngetDelhiGMT:function(datePar){\nvar date = new Date(datePar);\nreturn new Date(date.getTime() +  ( ( date.getTimezoneOffset() + 330)*60* 1000 ) );\t\n}\n}\n</script>";
		array[7] = text4;
		array[8] = Strings.ChrW(10).ToString();
		array[9] = Strings.ChrW(10).ToString();
		string text5 = "</head>";
		array[10] = text5;
		array[11] = Strings.ChrW(10).ToString();
		array[12] = Strings.ChrW(10).ToString();
		string text6 = "<body>";
		array[13] = text6;
		array[14] = Strings.ChrW(10).ToString();
		array[15] = Strings.ChrW(10).ToString();
		array[16] = Strings.ChrW(10).ToString();
		array[17] = Strings.ChrW(10).ToString();
		string text7 = "</body>";
		array[18] = text7;
		array[19] = Strings.ChrW(10).ToString();
		array[20] = Strings.ChrW(10).ToString();
		string text8 = "</html> ";
		array[21] = text8;
		string text9 = string.Concat(array);
		WebBrowser webBrowser = new WebBrowser();
		string urlString = "about:blank";
		webBrowser.Navigate(urlString);
		webBrowser.Document.Write(text9);
		HtmlDocument document = webBrowser.Document;
		string scriptName = "DateToStr";
		string result = document.InvokeScript(scriptName, new object[1] { jda }).ToString();
		HtmlDocument document2 = webBrowser.Document;
		string scriptName2 = "StrToDate";
		document2.InvokeScript(scriptName2, new object[1] { jda2 }).ToString();
		webBrowser.Dispose();
		return result;
	}

	public static string ChkTrain_Method(string frm, string to, string train, DateTime value, string cls, string qt, int TT)
	{
		string[,] array = new string[200, 12];
		string text = "retry";
		string text2 = text;
		string text3 = "http://www.bookmytrain.com";
		string text4 = text3;
		string text5 = text4;
		string format = "{0:dd/MM/yyyy}";
		string text6 = string.Format(format, value);
		string oldValue = "-";
		string newValue = "/";
		string jda;
		string text7 = Datestr(jda = text6.Replace(oldValue, newValue), jda);
		string[] array2 = new string[7];
		string text8 = "/railways/pages/nget/index.html?";
		array2[0] = text8;
		array2[1] = frm;
		string text9 = "&";
		array2[2] = text9;
		array2[3] = to;
		string text10 = "&";
		array2[4] = text10;
		array2[5] = text7;
		string text11 = "&&";
		array2[6] = text11;
		string text12 = string.Concat(array2);
		string text13 = HttpUtility.UrlEncode(text12);
		if (batchId == 0)
		{
			BkMyTrncc = new CookieContainer();
			string string_ = text5;
			string string_2 = text4 + text12;
			string string_3 = "";
			string text14;
			string text15;
			do
			{
				string string_4 = "Check";
				text14 = method_bookmytrain(string_2, string_, string_3, string_4);
				text15 = "retry";
			}
			while (text14 == text15);
			batchId++;
			string text16 = "/railways/j_spring_security_check";
			string text17 = text4 + text16;
			string text18 = "j_username=riloh%40flurred.com&j_password=810470";
			string string_5 = text18;
			string text19 = "http://www.bookmytrain.com/railways/pages/ngetportalhome.html";
			string string_6 = text19;
			string text20;
			string text21;
			do
			{
				string string_7 = "SELTR";
				text20 = method_bookmytrain(text17, string_6, string_5, string_7);
				text21 = "retry";
			}
			while (text20 == text21);
			batchId++;
			string value2 = "jorba";
			string text22 = text20.Substring(text20.IndexOf(value2) + 8);
			string value3 = "\"";
			text22.Substring(0, text22.IndexOf(value3));
			string value4 = "ashta";
			string text23 = text20.Substring(text20.IndexOf(value4) + 8);
			string value5 = "\"";
			text23.Substring(0, text23.IndexOf(value5));
			CookieCollection cookies = BkMyTrncc.GetCookies(new Uri(text4));
			for (int i = 0; i < cookies.Count; i++)
			{
				Cookie cookie = cookies[i];
				if (i == 0)
				{
					httpsession = cookie.Value;
				}
			}
			string string_8 = text17;
			string text24 = "/railways/dwr/call/plaincall/RemoteService.getPortalLocalCache.dwr";
			string string_9 = text4 + text24;
			string[] array3 = new string[8];
			string text25 = "callCount=1&windowName=&c0-scriptName=RemoteService&c0-methodName=getPortalLocalCache&c0-id=0&batchId=";
			array3[0] = text25;
			array3[1] = batchId.ToString();
			string text26 = "&page=";
			array3[2] = text26;
			array3[3] = text13;
			string text27 = "&httpSessionId=";
			array3[4] = text27;
			array3[5] = httpsession;
			string text28 = "&scriptSessionId=";
			array3[6] = text28;
			array3[7] = scriptsession;
			string string_10 = string.Concat(array3);
			string text29;
			string text30;
			do
			{
				string string_11 = "Check";
				text2 = method_bookmytrain(string_9, string_8, string_10, string_11);
				text29 = text2;
				text30 = "retry";
			}
			while (text29 == text30);
			batchId++;
			string text31 = text2;
			string value6 = "handleNewScriptSession";
			if (text31.IndexOf(value6) > 0)
			{
				string text32 = text2;
				string text33 = text2;
				string value7 = "Session(";
				string text34 = text32.Substring(text33.IndexOf(value7) + 9);
				string value8 = ")";
				scriptsession = text34.Substring(0, text34.IndexOf(value8) - 1);
			}
		}
		switch (TT)
		{
		case 1:
		{
			string string_16 = text4 + text12;
			string text53 = "/railways/dwr/call/plaincall/IRCTCEnquiryService.getTrainList.dwr";
			string string_17 = text4 + text53;
			string[] array5 = new string[14];
			string text54 = "callCount=1&windowName=&c0-scriptName=IRCTCEnquiryService&c0-methodName=getTrainList&c0-id=0&c0-e2=string:";
			array5[0] = text54;
			array5[1] = frm;
			string text55 = "&c0-e1=Object_Object:{stationCode:reference:c0-e2}&c0-e4=string:";
			array5[2] = text55;
			array5[3] = to;
			string text56 = "&c0-e3=Object_Object:{stationCode:reference:c0-e4}&c0-e5=string:";
			array5[4] = text56;
			array5[5] = text7;
			string text57 = "&c0-param0=Object_Object:{sourceStation:reference:c0-e1, destinationStation:reference:c0-e3, journeyDate:reference:c0-e5}&batchId=";
			array5[6] = text57;
			array5[7] = batchId.ToString();
			string text58 = "&page=";
			array5[8] = text58;
			array5[9] = text13;
			string text59 = "&httpSessionId=";
			array5[10] = text59;
			array5[11] = httpsession;
			string text60 = "&scriptSessionId=";
			array5[12] = text60;
			array5[13] = scriptsession;
			string string_18 = string.Concat(array5);
			string text61;
			string text62;
			do
			{
				string string_19 = "Check";
				text2 = method_bookmytrain(string_17, string_16, string_18, string_19);
				text61 = text2;
				text62 = "retry";
			}
			while (text61 == text62);
			batchId++;
			int num2 = 0;
			string text63 = text2;
			string value18 = "trainList";
			if (text63.IndexOf(value18) > -1)
			{
				string text64 = text2;
				string text65 = text2;
				string value19 = "trainList";
				text2 = text64.Substring(text65.IndexOf(value19) + 10);
				string text93;
				string value30;
				do
				{
					string text66 = text2;
					string text67 = text2;
					string value20 = "{arrivalTime";
					string text68 = text66.Substring(text67.IndexOf(value20) + 13);
					string[] array6 = text68.Split(',');
					int num3 = num2;
					string text69 = array6[8];
					string text70 = array6[8];
					string value21 = ":";
					string text71 = text69.Substring(text70.IndexOf(value21) + 2);
					string oldValue2 = "\"";
					array[num3, 2] = text71.Replace(oldValue2, "");
					int num4 = num2;
					string text72 = array6[20];
					string text73 = array6[20];
					string value22 = ":";
					string text74 = text72.Substring(text73.IndexOf(value22) + 2);
					string oldValue3 = "\"";
					array[num4, 3] = text74.Replace(oldValue3, "");
					int num5 = num2;
					string text75 = array6[9];
					string text76 = array6[9];
					string value23 = ":";
					string text77 = text75.Substring(text76.IndexOf(value23) + 2);
					string oldValue4 = "\"";
					array[num5, 4] = text77.Replace(oldValue4, "");
					int num6 = num2;
					string text78 = array6[14];
					string text79 = array6[14];
					string value24 = ":";
					string text80 = text78.Substring(text79.IndexOf(value24) + 2);
					string oldValue5 = "\"";
					array[num6, 5] = text80.Replace(oldValue5, "");
					int num7 = num2;
					string text81 = array6[5];
					string text82 = array6[5];
					string value25 = ":";
					string text83 = text81.Substring(text82.IndexOf(value25) + 2);
					string oldValue6 = "\"";
					array[num7, 6] = text83.Replace(oldValue6, "");
					int num8 = num2;
					string text84 = array6[2];
					string text85 = array6[2];
					string value26 = ":";
					string text86 = text84.Substring(text85.IndexOf(value26) + 2);
					string oldValue7 = "\"";
					array[num8, 7] = text86.Replace(oldValue7, "");
					string value27 = "trainNO";
					text2 = text68.Substring(text68.IndexOf(value27));
					string[] array7 = text2.Split(',');
					int num9 = num2;
					string text87 = array7[0];
					string text88 = array7[0];
					string value28 = ":";
					string text89 = text87.Substring(text88.IndexOf(value28) + 2);
					string oldValue8 = "\"";
					array[num9, 0] = text89.Replace(oldValue8, "");
					int num10 = num2;
					string text90 = array7[1];
					string text91 = array7[1];
					string value29 = ":";
					string text92 = text90.Substring(text91.IndexOf(value29) + 2);
					string oldValue9 = "\"";
					array[num10, 1] = text92.Replace(oldValue9, "");
					num2++;
					text93 = text2;
					value30 = "{arrivalTime";
				}
				while (text93.IndexOf(value30) > 0);
			}
			goto default;
		}
		default:
			text2.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
			return text2;
		case 2:
		{
			string string_20 = text4 + text12;
			string text94 = "/railways/dwr/call/plaincall/IRCTCEnquiryService.getFareAccommodationAvailability.dwr";
			string string_21 = text4 + text94;
			string[] array8 = new string[14];
			string text95 = "callCount=1&windowName=&c0-scriptName=IRCTCEnquiryService&c0-methodName=getRouteDetailoftrainOnJrneyDate&c0-id=0&c0-e1=string:";
			array8[0] = text95;
			array8[1] = train;
			string text96 = "&c0-e2=string:";
			array8[2] = text96;
			array8[3] = frm;
			string text97 = "&c0-e3=string:";
			array8[4] = text97;
			array8[5] = text7;
			string text98 = "&c0-param0=Object_Object:{trainNO:reference:c0-e1, fromStationCode:reference:c0-e2, journeyDate:reference:c0-e3}&batchId=";
			array8[6] = text98;
			array8[7] = batchId.ToString();
			string text99 = "&page=";
			array8[8] = text99;
			array8[9] = text13;
			string text100 = "&httpSessionId=";
			array8[10] = text100;
			array8[11] = httpsession;
			string text101 = "&scriptSessionId=";
			array8[12] = text101;
			array8[13] = scriptsession;
			string string_22 = string.Concat(array8);
			string text102;
			string text103;
			do
			{
				string string_23 = "Check";
				text102 = method_bookmytrain(string_21, string_20, string_22, string_23);
				text103 = "retry";
			}
			while (text102 == text103);
			batchId++;
			string text104 = "1";
			string result2 = text104;
			string value31 = "routeDetail";
			if (text102.IndexOf(value31) > -1)
			{
				string[] array9 = new string[2];
				string text105 = "{";
				array9[0] = text105;
				string text106 = "},";
				array9[1] = text106;
				List<string> list = new List<string>(text102.Split(array9, StringSplitOptions.None));
				if (predicate_0 == null)
				{
					predicate_0 = smethod_0;
				}
				list.RemoveAll(predicate_0);
				for (int j = 2; j < list.Count; j++)
				{
					string[] array10 = list[j].Split(',');
					if (array10.Length == 9)
					{
						string text107 = array10[0];
						string text108 = array10[0];
						string value32 = ":";
						string text109 = text107.Substring(text108.IndexOf(value32) + 2);
						string oldValue10 = "\"";
						result2 = text109.Replace(oldValue10, "");
						string text110 = array10[6];
						string text111 = array10[6];
						string value33 = ":";
						string text112 = text110.Substring(text111.IndexOf(value33) + 2);
						string oldValue11 = "\"";
						if (text112.Replace(oldValue11, "") == frm)
						{
							break;
						}
					}
					else if (array10.Length == 11)
					{
						string text113 = array10[1];
						string text114 = array10[1];
						string value34 = ":";
						string text115 = text113.Substring(text114.IndexOf(value34) + 2);
						string oldValue12 = "\"";
						result2 = text115.Replace(oldValue12, "");
						string text116 = array10[8];
						string text117 = array10[8];
						string value35 = ":";
						string text118 = text116.Substring(text117.IndexOf(value35) + 2);
						string oldValue13 = "\"";
						if (text118.Replace(oldValue13, "") == frm)
						{
							break;
						}
					}
				}
			}
			return result2;
		}
		case 3:
		{
			string string_12 = text4 + text12;
			string text35 = "/railways/dwr/call/plaincall/IRCTCEnquiryService.getFareAccommodationAvailability.dwr";
			string string_13 = text4 + text35;
			string[] array4 = new string[22];
			string text36 = "callCount=1&windowName=&c0-scriptName=IRCTCEnquiryService&c0-methodName=getFareAccommodationAvailability&c0-id=0&c0-e2=string:";
			array4[0] = text36;
			array4[1] = train;
			string text37 = "&c0-e3=string:";
			array4[2] = text37;
			array4[3] = train;
			string text38 = "&c0-e5=string:";
			array4[4] = text38;
			array4[5] = frm;
			string text39 = "&c0-e4=Object_Object:{stationCode:reference:c0-e5}&c0-e7=string:";
			array4[6] = text39;
			array4[7] = to;
			string text40 = "&c0-e6=Object_Object:{stationCode:reference:c0-e7}&c0-e1=Object_Object:{trainID:reference:c0-e2, trainNO:reference:c0-e3, sourceStation:reference:c0-e4, destinationStation:reference:c0-e6}&c0-e8=string:";
			array4[8] = text40;
			array4[9] = text7;
			string text41 = "&c0-e9=string:";
			array4[10] = text41;
			array4[11] = qt;
			string text42 = "&c0-e12=string:";
			array4[12] = text42;
			array4[13] = cls;
			string text43 = "&c0-e11=Object_Object:{classCode:reference:c0-e12}&c0-e10=Object_Object:{classCode:reference:c0-e11}&c0-param0=Object_Object:{train:reference:c0-e1, journeyDate:reference:c0-e8, quota:reference:c0-e9, trainClass:reference:c0-e10}&batchId=";
			array4[14] = text43;
			array4[15] = batchId.ToString();
			string text44 = "&page=";
			array4[16] = text44;
			array4[17] = text13;
			string text45 = "&httpSessionId=";
			array4[18] = text45;
			array4[19] = httpsession;
			string text46 = "&scriptSessionId=";
			array4[20] = text46;
			array4[21] = scriptsession;
			string string_14 = string.Concat(array4);
			string text47;
			string text48;
			do
			{
				string string_15 = "Check";
				text47 = method_bookmytrain(string_13, string_12, string_14, string_15);
				text48 = "retry";
			}
			while (text47 == text48);
			batchId++;
			string text49 = "error";
			string result = text49;
			string value9 = "accommodationStatus";
			if (text47.IndexOf(value9) > -1)
			{
				string value10 = "accommodationStatus:[{";
				int startIndex = text47.IndexOf(value10);
				string value11 = "}]";
				int num = text47.IndexOf(value11);
				string value12 = "accommodationStatus:[{";
				string text50 = text47.Substring(startIndex, num - text47.IndexOf(value12));
				string value13 = "status";
				string text51 = text50.Substring(text50.IndexOf(value13) + 8);
				string value14 = ",";
				result = text51.Substring(0, text51.IndexOf(value14) - 1).Trim();
			}
			else
			{
				string value15 = "errorMsgs";
				if (text47.IndexOf(value15) > -1)
				{
					string value16 = "errorMsgs:";
					string text52 = text47.Substring(text47.IndexOf(value16) + 12);
					string value17 = "\"";
					result = text52.Substring(0, text52.IndexOf(value17));
				}
			}
			return result;
		}
		}
	}

	public static string method_bookmytrain(string string_0, string string_1, string string_2, string string_3)
	{
		string text = "";
		HttpWebRequest httpWebRequest = null;
		Stream stream = null;
		HttpWebResponse httpWebResponse = null;
		Stream stream2 = null;
		try
		{
			GC.Collect();
			httpWebRequest = (HttpWebRequest)WebRequest.Create(new Uri(string_0));
			httpWebRequest.CachePolicy = new HttpRequestCachePolicy(HttpCacheAgeControl.MaxAge, TimeSpan.FromDays(1.0));
			httpWebRequest.Proxy = null;
			WebRequest.DefaultWebProxy = null;
			httpWebRequest.CookieContainer = BkMyTrncc;
			httpWebRequest.Referer = string_1;
			httpWebRequest.KeepAlive = true;
			httpWebRequest.Pipelined = false;
			httpWebRequest.ReadWriteTimeout = 50000;
			HttpWebRequest httpWebRequest2 = httpWebRequest;
			string connection = "keepalive";
			httpWebRequest2.Connection = connection;
			WebHeaderCollection headers = httpWebRequest.Headers;
			string value = "gzip, deflate";
			headers.Add(HttpRequestHeader.AcceptEncoding, value);
			httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
			HttpWebRequest httpWebRequest3 = httpWebRequest;
			string accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
			httpWebRequest3.Accept = accept;
			HttpWebRequest httpWebRequest4 = httpWebRequest;
			string userAgent = "Mozilla/5.0 (Windows T 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/27.0.1453.116 Safari/537.36";
			httpWebRequest4.UserAgent = userAgent;
			WebHeaderCollection headers2 = httpWebRequest.Headers;
			string name = "Cache-Control";
			string value2 = "no-cache";
			headers2.Set(name, value2);
			WebHeaderCollection headers3 = httpWebRequest.Headers;
			string name2 = "Cache-Control";
			string value3 = "max-age=0";
			headers3.Set(name2, value3);
			string text2 = "SELTR";
			if (string_3 == text2)
			{
				WebHeaderCollection headers4 = httpWebRequest.Headers;
				string name3 = "X-Ajax-call";
				string value4 = "true";
				headers4.Add(name3, value4);
				WebHeaderCollection headers5 = httpWebRequest.Headers;
				string name4 = "X-Requested-With";
				string value5 = "XMLHttpRequest";
				headers5.Add(name4, value5);
			}
			httpWebRequest.UnsafeAuthenticatedConnectionSharing = true;
			httpWebRequest.Timeout = 90000;
			httpWebRequest.AllowAutoRedirect = false;
			httpWebRequest.PreAuthenticate = true;
			httpWebRequest.AllowWriteStreamBuffering = false;
			httpWebRequest.ProtocolVersion = HttpVersion.Version11;
			HttpWebRequest httpWebRequest5 = httpWebRequest;
			string method = "GET";
			httpWebRequest5.Method = method;
			if (string_2 != "")
			{
				HttpWebRequest httpWebRequest6 = httpWebRequest;
				string method2 = "POST";
				httpWebRequest6.Method = method2;
				byte[] bytes = Encoding.ASCII.GetBytes(string_2);
				HttpWebRequest httpWebRequest7 = httpWebRequest;
				string contentType = "application/x-www-form-urlencoded";
				httpWebRequest7.ContentType = contentType;
				httpWebRequest.ContentLength = bytes.Length;
				stream = httpWebRequest.GetRequestStream();
				stream.Write(bytes, 0, bytes.Length);
				stream.Flush();
				stream.Close();
			}
			httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			switch (httpWebResponse.StatusCode)
			{
			default:
			{
				stream2 = httpWebResponse.GetResponseStream();
				StreamReader streamReader = new StreamReader(stream2, Encoding.UTF8);
				text = streamReader.ReadToEnd();
				if (text == "")
				{
					string text4 = "retry";
					text = text4;
				}
				foreach (Cookie cookie in httpWebResponse.Cookies)
				{
					CookieContainer bkMyTrncc = BkMyTrncc;
					string uriString = "http://www.bookmytrain.com";
					bkMyTrncc.Add(new Uri(uriString), new Cookie(cookie.Name, cookie.Value));
				}
				streamReader.Close();
				break;
			}
			case HttpStatusCode.NotModified:
			case HttpStatusCode.UseProxy:
			case HttpStatusCode.Unused:
			{
				string text3 = "retry";
				text = text3;
				break;
			}
			case HttpStatusCode.MovedPermanently:
			case HttpStatusCode.Found:
			case HttpStatusCode.SeeOther:
			case HttpStatusCode.TemporaryRedirect:
			{
				HttpWebResponse httpWebResponse2 = httpWebResponse;
				string headerName = "Location";
				text = httpWebResponse2.GetResponseHeader(headerName);
				break;
			}
			}
			httpWebResponse.Close();
			httpWebResponse = null;
			httpWebRequest = null;
		}
		catch (WebException ex)
		{
			GC.Collect();
			string text5 = "retry";
			text = text5;
			string message = ex.Message;
			string value6 = "The remote name could not be resolved:";
			message.Contains(value6);
			string message2 = ex.Message;
			string value7 = "Unable to connect to the remote server";
			message2.Contains(value7);
		}
		catch (Exception)
		{
			GC.Collect();
			string text6 = "retry";
			text = text6;
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
			httpWebRequest?.Abort();
		}
		return text;
	}

	private static string smethod_1(string string_0, string string_1, string string_2, string string_3)
	{
		while (true)
		{
			httpWebRequest_0 = null;
			Stream stream = null;
			HttpWebResponse httpWebResponse = null;
			Stream stream2 = null;
			try
			{
				GC.Collect();
				httpWebRequest_0 = (HttpWebRequest)WebRequest.Create(new Uri(string_0));
				HttpRequestCachePolicy cachePolicy = new HttpRequestCachePolicy(HttpCacheAgeControl.MaxAge, TimeSpan.FromDays(1.0));
				httpWebRequest_0.CachePolicy = cachePolicy;
				httpWebRequest_0.ServicePoint.ConnectionLeaseTimeout = 100000;
				httpWebRequest_0.ServicePoint.UseNagleAlgorithm = false;
				httpWebRequest_0.ServicePoint.Expect100Continue = false;
				httpWebRequest_0.ServicePoint.ConnectionLimit = 65000;
				httpWebRequest_0.ServicePoint.MaxIdleTime = 100000;
				httpWebRequest_0.Referer = string_1;
				httpWebRequest_0.KeepAlive = true;
				httpWebRequest_0.Pipelined = false;
				httpWebRequest_0.ReadWriteTimeout = 30000;
				HttpWebRequest httpWebRequest = httpWebRequest_0;
				string connection = "keepalive";
				httpWebRequest.Connection = connection;
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
				string text = "SELTR";
				if (string_3 != text)
				{
					WebHeaderCollection headers3 = httpWebRequest_0.Headers;
					string name2 = "Cache-Control";
					string value3 = "max-age=0";
					headers3.Set(name2, value3);
				}
				else
				{
					WebHeaderCollection headers4 = httpWebRequest_0.Headers;
					string name3 = "Faces-Request";
					string value4 = "partial/ajax";
					headers4.Add(name3, value4);
					WebHeaderCollection headers5 = httpWebRequest_0.Headers;
					string name4 = "Cache-Control";
					string value5 = "no-cache";
					headers5.Set(name4, value5);
					WebHeaderCollection headers6 = httpWebRequest_0.Headers;
					string name5 = "Pragma";
					string value6 = "no-cache";
					headers6.Set(name5, value6);
				}
				string value7 = "fcuiopxxy";
				if (string_3.Contains(value7))
				{
					WebHeaderCollection headers7 = httpWebRequest_0.Headers;
					string value8 = "ISO-8859-1,utf-8;q=0.7,*;q=0.3";
					headers7.Add(HttpRequestHeader.AcceptCharset, value8);
					WebHeaderCollection headers8 = httpWebRequest_0.Headers;
					string value9 = "no-cache";
					headers8.Add(HttpRequestHeader.Pragma, value9);
					WebHeaderCollection headers9 = httpWebRequest_0.Headers;
					string name6 = "Cache-Control";
					string value10 = "no-cache";
					headers9.Add(name6, value10);
				}
				httpWebRequest_0.UnsafeAuthenticatedConnectionSharing = true;
				httpWebRequest_0.Timeout = 30000;
				httpWebRequest_0.AllowAutoRedirect = false;
				httpWebRequest_0.PreAuthenticate = true;
				httpWebRequest_0.AllowWriteStreamBuffering = false;
				httpWebRequest_0.ProtocolVersion = HttpVersion.Version11;
				if (!(string_2 != ""))
				{
					HttpWebRequest httpWebRequest4 = httpWebRequest_0;
					string method = "GET";
					httpWebRequest4.Method = method;
					string value11 = "fcuiopxxy";
					bool flag = string_3.Contains(value11);
					string value12 = "asdasd";
					if (flag | string_3.Contains(value12))
					{
						HttpWebRequest httpWebRequest5 = httpWebRequest_0;
						string method2 = "POST";
						httpWebRequest5.Method = method2;
						byte[] bytes = Encoding.ASCII.GetBytes(string_2);
						HttpWebRequest httpWebRequest6 = httpWebRequest_0;
						string contentType = "application/x-www-form-urlencoded";
						httpWebRequest6.ContentType = contentType;
						httpWebRequest_0.ContentLength = bytes.Length;
						stream = httpWebRequest_0.GetRequestStream();
						stream.Write(bytes, 0, bytes.Length);
						stream.Flush();
						stream.Close();
					}
				}
				else
				{
					HttpWebRequest httpWebRequest7 = httpWebRequest_0;
					string method3 = "POST";
					httpWebRequest7.Method = method3;
					byte[] bytes2 = Encoding.ASCII.GetBytes(string_2);
					HttpWebRequest httpWebRequest8 = httpWebRequest_0;
					string contentType2 = "application/x-www-form-urlencoded";
					httpWebRequest8.ContentType = contentType2;
					httpWebRequest_0.ContentLength = bytes2.Length;
					stream = httpWebRequest_0.GetRequestStream();
					stream.Write(bytes2, 0, bytes2.Length);
					stream.Flush();
					stream.Close();
				}
				httpWebResponse = (HttpWebResponse)httpWebRequest_0.GetResponse();
				HttpWebResponse httpWebResponse2 = httpWebResponse;
				string text3;
				switch (httpWebResponse2.StatusCode)
				{
				default:
				{
					stream2 = httpWebResponse2.GetResponseStream();
					StreamReader streamReader = new StreamReader(stream2, Encoding.UTF8);
					text3 = smethod_2(streamReader);
					streamReader.Close();
					stream2.Close();
					stream2 = null;
					break;
				}
				case HttpStatusCode.NotModified:
				case HttpStatusCode.UseProxy:
				case HttpStatusCode.Unused:
				{
					string text4 = "retry";
					text3 = text4;
					break;
				}
				case HttpStatusCode.MovedPermanently:
				case HttpStatusCode.Found:
				case HttpStatusCode.SeeOther:
				case HttpStatusCode.TemporaryRedirect:
				{
					string headerName = "Location";
					string responseHeader = httpWebResponse2.GetResponseHeader(headerName);
					string value13 = "err200.html";
					if (responseHeader.Contains(value13))
					{
						string text2 = "retry";
						text3 = text2;
						break;
					}
					text3 = responseHeader;
					string_0 = text3;
					goto end_IL_0013;
				}
				}
				httpWebResponse.Close();
				httpWebResponse = null;
				httpWebRequest_0 = null;
				if (text3 == "")
				{
					return "retry";
				}
				return text3;
				end_IL_0013:;
			}
			catch (WebException)
			{
				GC.Collect();
				return "retry";
			}
			catch (Exception)
			{
				GC.Collect();
				return "retry";
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
		}
	}

	private static string smethod_2(TextReader textReader_0)
	{
		return textReader_0.ReadToEnd();
	}

	public static bool method_1(string string_14, string string_15, string string_16, int int_0, WebProxy webProxy_0, ref CookieContainer cookieContainer_1, bool bool_1, int int_1, ref string string_17, ref string string_18)
	{
		int num = 0;
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
				httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				if (int_1 > 0)
				{
					httpWebRequest.Timeout = int_1;
					httpWebRequest.ReadWriteTimeout = int_1;
				}
				ServicePointManager.Expect100Continue = true;
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
				string value = "json";
				if (string_16.Contains(value))
				{
					string contentType2 = "application/json";
					httpWebRequest.ContentType = contentType2;
				}
				httpWebRequest.KeepAlive = true;
				string value2 = "midentity.onlinesbi.com";
				if (string_14.Contains(value2))
				{
					ServicePointManager.Expect100Continue = false;
					string connection = "keepalive";
					httpWebRequest.Connection = connection;
					WebHeaderCollection headers = httpWebRequest.Headers;
					string name = "Accept-Language";
					string value3 = "en-US,en;q=0.9";
					headers.Set(name, value3);
					WebHeaderCollection headers2 = httpWebRequest.Headers;
					string name2 = "Accept-Encoding";
					string value4 = "gzip,deflate,br";
					headers2.Set(name2, value4);
					WebHeaderCollection headers3 = httpWebRequest.Headers;
					string name3 = "X-Kony-App-Key";
					string value5 = "aaee6accb1b00d19ddf0efb0f66a393";
					headers3.Set(name3, value5);
					WebHeaderCollection headers4 = httpWebRequest.Headers;
					string name4 = "X-Kony-App-Secret";
					string value6 = "2f9b36d1f6f5c3e940cd940af1e59d4e";
					headers4.Set(name4, value6);
					WebHeaderCollection headers5 = httpWebRequest.Headers;
					string name5 = "X-Kony-Platform-Type";
					string value7 = "android";
					headers5.Set(name5, value7);
					WebHeaderCollection headers6 = httpWebRequest.Headers;
					string name6 = "X-Kony-SDK-Type";
					string value8 = "js";
					headers6.Set(name6, value8);
					WebHeaderCollection headers7 = httpWebRequest.Headers;
					string name7 = "X-Kony-SDK-Version";
					string value9 = "SDK-GA-7.3.0.39";
					headers7.Set(name7, value9);
				}
				string text2 = "Apache-HttpClient/android/";
				httpWebRequest.UserAgent = text2 + string_16;
				string value10 = "txn";
				if (string_16.Contains(value10))
				{
					string contentType3 = "application/x-www-form-urlencoded";
					httpWebRequest.ContentType = contentType3;
					httpWebRequest.KeepAlive = true;
					string userAgent = "Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/74.0.3729.108 Safari/537.36";
					httpWebRequest.UserAgent = userAgent;
					string accept = "application/json, text/plain, */*";
					httpWebRequest.Accept = accept;
					string contentType4 = "text/plain";
					httpWebRequest.ContentType = contentType4;
					WebHeaderCollection headers8 = httpWebRequest.Headers;
					string name8 = "Accept-Language";
					string value11 = "en-US,en;q=0.9";
					headers8.Set(name8, value11);
				}
				if (int_0 == 2)
				{
					WebHeaderCollection headers9 = httpWebRequest.Headers;
					string name9 = "Authorization";
					string value12 = "Basic bWFya2V0LWFwcDo5YTA3MTc2Mi1hNDk5LTRiZDktOTE0YS00MzYxZTdjM2Y0YmM=";
					headers9.Set(name9, value12);
				}
				if (int_0 == 3)
				{
					WebHeaderCollection headers10 = httpWebRequest.Headers;
					string name10 = "Cookie2";
					string text3 = "$Version=";
					headers10.Set(name10, text3 + int_0);
				}
				if (int_0 == 4)
				{
					WebHeaderCollection headers11 = httpWebRequest.Headers;
					string name11 = "Authorization";
					string value13 = "Basic bWFya2V0LWFwcDo5YTA3MTc2Mi1hNDk5LTRiZDktOTE0YS00MzYxZTdjM2Y0YmM=";
					headers11.Set(name11, value13);
					WebHeaderCollection headers12 = httpWebRequest.Headers;
					string name12 = "risk_extended_info";
					string value14 = "{\"deviceAccounts\":[],\"isContact\":false,\"isRooted\":false,\"lci\":[\"7021509836\"],\"lcic\":[true],\"lco\":[\"+917021509836\"],\"otpReadFlag\":false,\"transactionType\":\"login\",\"userLbsLatitude\":\"18.5786275\",\"userLbsLongitude\":\"73.8814163\",\"wifissid\":[\"<unknown ssid>\"]}";
					headers12.Set(name12, value14);
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
				using (StreamReader textReader_ = smethod_3(httpWebResponse.GetResponseStream()))
				{
					text = smethod_4(textReader_);
				}
				string_17 = text;
				flag = true;
			}
			catch (Exception ex)
			{
				flag = false;
				string_18 = ex.Message;
				string string_19 = "SBIOTPByPass: WebRequestPost";
				Class28.smethod_26(string_19, string_18);
				string text4 = string_18.ToUpper();
				string value15 = "CONNECTION WAS CLOSED";
				if (!text4.Contains(value15))
				{
					string text5 = string_18.ToUpper();
					string value16 = "SERVICEUNAVAILABLE";
					text5.Contains(value16);
				}
				string text6 = string_18;
				string value17 = "The underlying connection was closed";
				text6.Contains(value17);
				string text7 = string_18;
				string value18 = "The underlying connection was closed";
				if (text7.Contains(value18) && num >= 1)
				{
					proxy = Program.PrivateProxy;
				}
				if (num >= 3)
				{
					return result = flag;
				}
				num++;
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
			int[,,,,] array = new int[2, 1, 1, 1, 5]
			{
				{ { { { 1222348700, 356100172, 1749597019, 2068220652, -2076811740 } } } },
				{ { { { 1060241121, -1174794741, 629760281, 743687180, -2119632546 } } } }
			};
			switch ((array[1, 0, 0, 0, 3] ^ 0x3562B7F6) * 1786506069)
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

	public static bool method_11(string string_14, string string_15, string string_16, int int_0, WebProxy webProxy_0, ref CookieContainer cookieContainer_1, bool bool_1, int int_1, ref string string_17, ref string string_18)
	{
		int num = 0;
		bool result;
		while (true)
		{
			string_18 = "";
			string_17 = "";
			result = false;
			HttpWebResponse httpWebResponse = null;
			string text = "";
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string_14);
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				httpWebRequest.Proxy = webProxy_0;
				httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
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
				httpWebRequest.Referer = string_16;
				string method = "POST";
				httpWebRequest.Method = method;
				httpWebRequest.ContentLength = bytes.Length;
				string contentType = "application/x-www-form-urlencoded";
				httpWebRequest.ContentType = contentType;
				httpWebRequest.KeepAlive = true;
				string userAgent = "Mozilla/5.0 (Windows T 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36";
				httpWebRequest.UserAgent = userAgent;
				if (int_0 > 0)
				{
					WebHeaderCollection headers = httpWebRequest.Headers;
					string name = "Accept-Language";
					string value = "en-US,en;q=0.5";
					headers.Set(name, value);
					WebHeaderCollection headers2 = httpWebRequest.Headers;
					string name2 = "Upgrade-Insecure-Requests";
					string value2 = "1";
					headers2.Set(name2, value2);
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
				using (StreamReader textReader_ = smethod_3(httpWebResponse.GetResponseStream()))
				{
					text = smethod_4(textReader_);
				}
				string_17 = text;
				result = true;
			}
			catch (Exception ex)
			{
				result = false;
				string_18 = ex.Message;
				string string_19 = "SBIOTPByPass: WebRequestPost";
				Class28.smethod_26(string_19, string_18);
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
			if (num >= 3)
			{
				break;
			}
			string text2 = string_18.ToUpper();
			string value3 = "CONNECTION WAS CLOSED";
			if (!text2.Contains(value3))
			{
				string text3 = string_18.ToUpper();
				string value4 = "SERVICEUNAVAILABLE";
				if (!text3.Contains(value4))
				{
					break;
				}
			}
			string text4 = string_18.ToUpper();
			string value5 = "SERVICEUNAVAILABLE";
			if (text4.Contains(value5))
			{
				Thread.Sleep(2000);
			}
			num++;
		}
		return result;
	}

	private static StreamReader smethod_3(Stream stream_0)
	{
		return new StreamReader(stream_0);
	}

	private static string smethod_4(TextReader textReader_0)
	{
		return textReader_0.ReadToEnd();
	}
}
