using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using APP_FRAMEWORK;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.Win32;
using Newtonsoft.Json;
using NEXUS.IRCommDLL;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V145;
using OpenQA.Selenium.DevTools.V145.Network;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumUndetectedChromeDriver;
using Titanium.Web.Proxy;
using Titanium.Web.Proxy.Models;

namespace IRCommDLL;

internal class WebDriverNew
{
	internal clsMain clsM;

	internal clsPostData class3_0;

	internal DevToolsSessionDomains devTools;

	internal bool allDone;

	internal UndetectedChromeDriver driver;

	internal readonly string PrefixL = "mb";

	internal readonly string DigitsL = "0123456789";

	internal readonly string LowercaseLettersL = "abcdefghijklmnopqrstuvwxyz";

	internal readonly string AllLettersL = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

	internal bool invalidCaptcha;

	internal bool ipBlock_onLogin;

	internal bool capture_sensor;

	internal Random RandomL = new Random();

	private bool _injected;

	internal bool passngerSubmit;

	internal string responseBody;

	internal string postBody;

	private readonly Random _rnd = new Random();

	internal readonly Random R = new Random();

	[ThreadStatic]
	private static Random _localRnd;

	private string PassengerResponse;

	internal bool Web2;

	internal bool invalidUser;

	internal UndetectedChromeDriver undetectedChromeDriver_0;

	private Random Rnd_0 => _localRnd ?? (_localRnd = new Random(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId));

	internal WebDriverNew(clsMain clsMain0, clsPostData clsPostData0)
	{
		clsM = clsMain0;
		class3_0 = clsPostData0;
	}

	internal char RandomCharL(string charset)
	{
		int index = RandomL.Next(charset.Length);
		return charset[index];
	}

	internal string GenerateClientTransactionId()
	{
		return PrefixL + RandomCharL(DigitsL) + RandomCharL(LowercaseLettersL) + RandomCharL(LowercaseLettersL) + RandomCharL(DigitsL) + RandomCharL(AllLettersL) + RandomCharL(AllLettersL);
	}

	internal string SolveCaptcha(string str)
	{
		new CookieContainer();
		string text = string.Empty;
		try
		{
			string text2 = "|NGET|";
			string arguments = str + text2;
			Process process = new Process();
			ProcessStartInfo startInfo = process.StartInfo;
			string pks = frmCaptcha.pks;
			string path = "XCaptchaRecog.exe";
			startInfo.FileName = Path.Combine(pks, path);
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
		}
		catch (Exception)
		{
		}
		if (string.IsNullOrEmpty(text))
		{
			try
			{
				string pks2 = frmCaptcha.pks;
				string path2 = "XCaptchaRecog.exe";
				string path3 = Path.Combine(pks2, path2);
				if (!File.Exists(path3))
				{
					frmCaptcha.smethod_12(0);
				}
				else
				{
					File.Delete(path3);
				}
			}
			catch
			{
			}
		}
		return text;
	}

	internal string PostUsingBrowserFetch(string url, string reff, string body)
	{
		string result = "";
		new HumanMouseHelper(driver).ClickNextField();
		string text = "\r\nvar callback = arguments[arguments.length - 1];\r\nvar url = arguments[0];\r\nvar payloadJson = arguments[1];\r\nvar headersIn = arguments[2] || {};\r\n\r\n(async function() {\r\n  try {\r\n    var payload = null;\r\n    try { payload = JSON.parse(payloadJson); } catch(e) {\r\n      callback(JSON.stringify({ ok:false, error:'bad-payload:'+String(e) }));\r\n      return;\r\n    }\r\n\r\n    var fetchHeaders = Object.assign({ 'Content-Type': 'application/json; charset=UTF-8' }, headersIn);\r\n\r\n    var resp = await fetch(url, {\r\n      method: 'POST',\r\n      headers: fetchHeaders,\r\n      credentials: 'include',\r\n      body: JSON.stringify(payload)\r\n    });\r\n\r\n    var text = await resp.text(); // ✅ full body as text\r\n\r\n    callback(JSON.stringify({\r\n      ok: true,\r\n      status: resp.status,\r\n      statusText: resp.statusText,\r\n      headersRequested: fetchHeaders,\r\n      body: text // ✅ full body (no truncation)\r\n    }));\r\n  } catch (err) {\r\n    try { callback(JSON.stringify({ ok:false, error: String(err) })); } catch(e) {}\r\n  }\r\n})();\r\n";
		string script = text;
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		string key = "Accept-Language";
		string value = "en-US,en;q=0.0";
		dictionary.Add(key, value);
		string key2 = "Content-Language";
		string value2 = "en";
		dictionary.Add(key2, value2);
		string key3 = "Authorization";
		dictionary.Add(key3, clsM._Authrization);
		string key4 = "bmiyek";
		dictionary.Add(key4, clsM.bmiyek);
		string key5 = "greq";
		dictionary.Add(key5, clsM.greq);
		string key6 = "spa-csrf-token";
		dictionary.Add(key6, clsM.csrf_token);
		string key7 = "accept";
		string value3 = "application/json, text/plain, */*";
		dictionary.Add(key7, value3);
		string key8 = "bmirak";
		string value4 = "webbm";
		dictionary.Add(key8, value4);
		string key9 = "Referer";
		dictionary.Add(key9, reff);
		Dictionary<string, string> dictionary2 = dictionary;
		clsM.csrf_token = null;
		UndetectedChromeDriver undetectedChromeDriver = driver;
		if (undetectedChromeDriver == null)
		{
			string message = "Driver does not support JavaScript execution.";
			throw new InvalidOperationException(message);
		}
		object obj = ((IJavaScriptExecutor)undetectedChromeDriver).ExecuteAsyncScript(script, new object[3] { url, body, dictionary2 });
		try
		{
			string text2 = (obj as string) ?? obj?.ToString();
			if (!string.IsNullOrEmpty(text2))
			{
				Dictionary<string, object> dictionary3 = new JavaScriptSerializer().Deserialize<Dictionary<string, object>>(text2);
				string key10 = "body";
				result = dictionary3[key10].ToString();
				string text3 = "ok: ";
				string key11 = "ok";
				Console.WriteLine(text3 + dictionary3[key11]);
				string text4 = "status: ";
				string key12 = "status";
				Console.WriteLine(text4 + dictionary3[key12]);
				string text5 = "body: ";
				string key13 = "body";
				Console.WriteLine(text5 + dictionary3[key13]);
			}
		}
		catch (Exception)
		{
		}
		return result;
	}

	internal bool PostUsingBrowser(IWebDriver driver, string url, string reff, string body, ref string _response)
	{
		bool result = false;
		try
		{
			string text = " \r\nvar callback = arguments[arguments.length - 1];\r\nvar url = arguments[0];\r\nvar payloadJson = arguments[1];\r\nvar headersIn = arguments[2] || {};\r\n\r\n(async function() {\r\n  try {\r\n    var payload = null;\r\n    try { \r\n      payload = JSON.parse(payloadJson); \r\n    } catch(e) {\r\n      callback(JSON.stringify({ ok:false, error:'bad-payload:'+String(e) }));\r\n      return;\r\n    }\r\n\r\n    // clone headersIn and force Content-Type\r\n    var fetchHeaders = Object.assign({}, headersIn);\r\n    fetchHeaders['Content-Type'] = 'application/json; charset=UTF-8';\r\n\r\n    var resp = await fetch(url, {\r\n      method: 'POST',\r\n      headers: fetchHeaders,\r\n      credentials: 'include',\r\n      body: JSON.stringify(payload)\r\n    });\r\n\r\n    var text = await resp.text();\r\n\r\n    // collect response headers\r\n    var respHeaders = {};\r\n    resp.headers.forEach((v, k) => { respHeaders[k] = v; });\r\n\r\n    callback(JSON.stringify({\r\n      ok: true,\r\n      status: resp.status,\r\n      statusText: resp.statusText,\r\n      headersRequested: fetchHeaders,\r\n      headersReceived: respHeaders,   // ✅ response headers\r\n      body: text\r\n    }));\r\n  } catch (err) {\r\n    try { \r\n      callback(JSON.stringify({ ok:false, error: String(err) })); \r\n    } catch(e) {}\r\n  }\r\n})();\r\n";
			string script = text;
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			string key = "Accept-Language";
			string value = "en-US,en;q=0.0";
			dictionary.Add(key, value);
			string key2 = "Content-Language";
			string value2 = "en";
			dictionary.Add(key2, value2);
			string key3 = "Authorization";
			dictionary.Add(key3, clsM._Authrization);
			string key4 = "bmiyek";
			dictionary.Add(key4, clsM.bmiyek);
			string key5 = "greq";
			dictionary.Add(key5, clsM.greq);
			string key6 = "spa-csrf-token";
			dictionary.Add(key6, clsM.csrf_token);
			string key7 = "accept";
			string value3 = "application/json, text/plain, */*";
			dictionary.Add(key7, value3);
			string key8 = "bmirak";
			string value4 = "webbm";
			dictionary.Add(key8, value4);
			string key9 = "Referer";
			dictionary.Add(key9, reff);
			Dictionary<string, string> dictionary2 = dictionary;
			clsM.csrf_token = null;
			if (!(driver is IJavaScriptExecutor javaScriptExecutor))
			{
				string message = "Driver does not support JavaScript execution.";
				throw new InvalidOperationException(message);
			}
			object obj = javaScriptExecutor.ExecuteAsyncScript(script, url, body, dictionary2);
			try
			{
				string text2 = (obj as string) ?? obj?.ToString();
				if (!string.IsNullOrEmpty(text2))
				{
					Dictionary<string, object> dictionary3 = new JavaScriptSerializer().Deserialize<Dictionary<string, object>>(text2);
					string key10 = "body";
					_response = dictionary3[key10].ToString();
					string text3 = "response headers: ";
					string key11 = "headersReceived";
					Console.WriteLine(text3 + dictionary3[key11]);
					string text4 = "ok: ";
					string key12 = "ok";
					Console.WriteLine(text4 + dictionary3[key12]);
					string text5 = "ok: ";
					string key13 = "ok";
					Console.WriteLine(text5 + dictionary3[key13]);
					string text6 = "status: ";
					string key14 = "status";
					Console.WriteLine(text6 + dictionary3[key14]);
					string text7 = "body: ";
					string key15 = "body";
					Console.WriteLine(text7 + dictionary3[key15]);
					result = true;
				}
			}
			catch (Exception)
			{
			}
		}
		catch (Exception)
		{
		}
		return result;
	}

	internal void Network_RequestWillBeSent(object sender, RequestWillBeSentEventArgs e)
	{
		string url = e.Request.Url;
		string value = "irctc.co.in/eticketing/protected/mapps1/altAvlEnq/TC";
		if (url.Contains(value))
		{
			string value2 = "===========================";
			Console.WriteLine(value2);
			foreach (KeyValuePair<string, string> header in e.Request.Headers)
			{
				string key = header.Key;
				string text = "Authorization";
				if (key == text)
				{
					clsM._Authrization = header.Value;
				}
				string key2 = header.Key;
				string text2 = "greq";
				if (key2 == text2)
				{
					clsM.greq = header.Value;
				}
				string key3 = header.Key;
				string text3 = "bmiyek";
				if (key3 == text3)
				{
					clsM.bmiyek = header.Value;
				}
			}
		}
		string url2 = e.Request.Url;
		string value3 = "eticketing/protected/mapps1/allLapAvlFareEnq/Y";
		if (url2.Contains(value3))
		{
			try
			{
				GetRequestPostDataCommandResponse result = devTools.Network.GetRequestPostData(new GetRequestPostDataCommandSettings
				{
					RequestId = e.RequestId
				}, default(CancellationToken), null).GetAwaiter().GetResult();
				postBody = result.PostData;
			}
			catch
			{
			}
		}
		string url3 = e.Request.Url;
		string value4 = "webtoken";
		if (!url3.Contains(value4))
		{
			return;
		}
		try
		{
			string postData = devTools.Network.GetRequestPostData(new GetRequestPostDataCommandSettings
			{
				RequestId = e.RequestId
			}, default(CancellationToken), null).GetAwaiter().GetResult()
				.PostData;
			string value5 = "uid";
			string text4 = postData.Substring(postData.IndexOf(value5) + 4);
			clsMain clsMain = clsM;
			string value6 = "&";
			clsMain.greq = text4.Substring(0, text4.IndexOf(value6));
		}
		catch
		{
		}
		foreach (KeyValuePair<string, string> header2 in e.Request.Headers)
		{
			string key4 = header2.Key;
			string text5 = "User-Agent";
			if (key4 == text5)
			{
				clsM.User_Agent = header2.Value;
			}
		}
	}

	internal void Network_ResponseReceived(object sender, ResponseReceivedEventArgs e)
	{
		foreach (KeyValuePair<string, string> header in e.Response.Headers)
		{
			string text = header.Key.ToLower();
			string text2 = "csrf-token";
			if (text == text2)
			{
				clsM.csrf_token = header.Value;
			}
		}
		string url = e.Response.Url;
		string value = "altAvlEnq/TC";
		if (url.Contains(value) && !Web2)
		{
			while (true)
			{
				try
				{
					GetResponseBodyCommandResponse result = devTools.Network.GetResponseBody(new GetResponseBodyCommandSettings
					{
						RequestId = e.RequestId
					}, default(CancellationToken), null).GetAwaiter().GetResult();
					if (result != null)
					{
						string body = result.Body;
						clsM.response = result.Body;
						clsM.Res_Received = true;
						break;
					}
				}
				catch
				{
				}
			}
		}
		string value2 = "avlFarenquiry";
		if (url.Contains(value2) && !Web2)
		{
			while (true)
			{
				try
				{
					GetResponseBodyCommandResponse result2 = devTools.Network.GetResponseBody(new GetResponseBodyCommandSettings
					{
						RequestId = e.RequestId
					}, default(CancellationToken), null).GetAwaiter().GetResult();
					if (result2 == null)
					{
						continue;
					}
					clsM.response = result2.Body;
					clsM.Res_Received = true;
					break;
				}
				catch (Exception)
				{
				}
			}
		}
		string value3 = "boardingStationEnq";
		if (url.Contains(value3) && !Web2)
		{
			while (true)
			{
				try
				{
					GetResponseBodyCommandResponse result3 = devTools.Network.GetResponseBody(new GetResponseBodyCommandSettings
					{
						RequestId = e.RequestId
					}, default(CancellationToken), null).GetAwaiter().GetResult();
					if (result3 == null)
					{
						continue;
					}
					clsM.response = result3.Body;
					clsM.Res_Received = true;
					break;
				}
				catch
				{
				}
			}
		}
		string value4 = "allLapAvlFareEnq/Y";
		if (url.Contains(value4) && !Web2)
		{
			while (true)
			{
				try
				{
					GetResponseBodyCommandResponse result4 = devTools.Network.GetResponseBody(new GetResponseBodyCommandSettings
					{
						RequestId = e.RequestId
					}, default(CancellationToken), null).GetAwaiter().GetResult();
					if (result4 != null)
					{
						capture_sensor = false;
						clsM.response = result4.Body;
						clsM.Res_Received = true;
						break;
					}
				}
				catch
				{
				}
			}
		}
		string value5 = "addonServices";
		if (url.Contains(value5) && !Web2)
		{
			string text3 = "";
			while (true)
			{
				try
				{
					GetResponseBodyCommandResponse result5 = devTools.Network.GetResponseBody(new GetResponseBodyCommandSettings
					{
						RequestId = e.RequestId
					}, default(CancellationToken), null).GetAwaiter().GetResult();
					text3 = (result5.Base64Encoded ? Encoding.UTF8.GetString(Convert.FromBase64String(result5.Body)) : result5.Body);
					clsM.response = text3;
					clsM.Res_Received = true;
				}
				catch
				{
					continue;
				}
				break;
			}
		}
		string url2 = e.Response.Url;
		string value6 = "eticketing/protected/mapps1/validateUser";
		if (url2.Contains(value6) && !Web2)
		{
			foreach (KeyValuePair<string, string> header2 in e.Response.Headers)
			{
				string key = header2.Key;
				string text4 = "csrf-token";
				if (key == text4)
				{
					clsM.csrf_token = header2.Value;
				}
			}
			string text5 = "";
			while (true)
			{
				try
				{
					GetResponseBodyCommandResponse result6 = devTools.Network.GetResponseBody(new GetResponseBodyCommandSettings
					{
						RequestId = e.RequestId
					}, default(CancellationToken), null).GetAwaiter().GetResult();
					if (result6 != null)
					{
						string body2 = result6.Body;
						string value7 = "userIdHash";
						if (body2.Contains(value7))
						{
							text5 = result6.Body;
							break;
						}
					}
				}
				catch (Exception)
				{
				}
			}
			string text6 = text5;
			string value8 = "userIdHash";
			if (text6.Contains(value8))
			{
				clsM.response = text5;
				class3_0.Validate_Response = text5;
				clsMain clsMain = clsM;
				string string_ = text5;
				string string_2 = "userIdHash";
				clsMain.bmiyek = GetString(string_, string_2);
				string string_3 = text5;
				string string_4 = "minmPsgnInputTime";
				string text7 = GetString(string_3, string_4).ToUpper();
				string[] array = new string[1];
				string text8 = "#";
				array[0] = text8;
				string[] array2 = text7.Split(array, StringSplitOptions.None);
				double.TryParse(array2[0], out clsM.minmPsgnInputTime2);
				double.TryParse(array2[2], out clsM.minmPsgnInputTime4);
				double.TryParse(array2[4], out clsM.minmPsgnInputTime6);
				clsMain clsMain2 = clsM;
				string string_5 = text5;
				string string_6 = "gender";
				clsMain2.UserGender = GetString(string_5, string_6);
				string string_7 = text5;
				string string_8 = "minmPaymentTime";
				double.TryParse(GetString(string_7, string_8).ToUpper(), out clsM.minmPaymentTime);
				_ = DateTime.Now.Hour;
				_ = DateTime.Now.Minute;
				_ = DateTime.Now.Second;
				string text9 = text5;
				string value9 = "Aadhaar authentication of IRCTC user profile is mandatory to book Tatkal and Premium Tatkal";
				if (text9.IndexOf(value9) <= 0)
				{
					clsM.AadharVerifyied = true;
				}
				else
				{
					clsM.AadharVerifyied = false;
				}
				string text10 = text5;
				string value10 = "userEnableState\"";
				if (text10.IndexOf(value10) > 0)
				{
					string text11 = text5;
					string value11 = "userEnableState\":\"5";
					text11.IndexOf(value11);
					string text12 = text5;
					string value12 = "userEnableState\":\"3";
					if (text12.IndexOf(value12) > 0)
					{
						string string_9 = "TBL_USER";
						string string_10 = "UserState";
						string text13 = "Suspend||";
						Class11.smethod_1(string_9, string_10, text13 + class3_0.string_3, class3_0.IRCTC_ID);
					}
					string text14 = text5;
					string value13 = "userEnableState\":\"1";
					text14.IndexOf(value13);
					string text15 = text5;
					string value14 = "verified\":\"false";
					if (text15.IndexOf(value14) > 0)
					{
						clsM.Un_Verifyied = true;
					}
				}
				allDone = true;
			}
		}
		string url3 = e.Response.Url;
		string value15 = "irctc.co.in/eticketing/protected/mapps1/loginCaptcha";
		if (url3.Contains(value15))
		{
			while (true)
			{
				try
				{
					GetResponseBodyCommandResponse result7 = devTools.Network.GetResponseBody(new GetResponseBodyCommandSettings
					{
						RequestId = e.RequestId
					}, default(CancellationToken), null).GetAwaiter().GetResult();
					if (result7 == null)
					{
						continue;
					}
					string body3 = result7.Body;
					string value16 = "status";
					if (!body3.Contains(value16))
					{
						continue;
					}
					clsMain clsMain3 = clsM;
					string body4 = result7.Body;
					string string_11 = "status";
					clsMain3.greq = GetString(body4, string_11);
					string body5 = result7.Body;
					string value17 = "captchaQuestion";
					if (body5.IndexOf(value17) <= 0)
					{
						break;
					}
					string body6 = result7.Body;
					string body7 = result7.Body;
					string value18 = "captchaQuestion";
					string text16 = body6.Substring(body7.IndexOf(value18) + 18);
					clsMain clsMain4 = clsM;
					string value19 = "\"";
					clsMain4.CaptchaBase64 = text16.Substring(0, text16.IndexOf(value19));
					clsM.dateTime_2 = DateTime.Now;
					string body8 = result7.Body;
					string value20 = "timeStamp";
					if (!body8.Contains(value20))
					{
						break;
					}
					string body9 = result7.Body;
					string body10 = result7.Body;
					string value21 = "timeStamp";
					string text17 = body9.Substring(body10.IndexOf(value21) + 23);
					string text18 = text17;
					string text19 = text17;
					string value22 = "\"";
					text17 = text18.Substring(0, text19.IndexOf(value22));
					DateTime dateTime = DateTime.Parse(text17);
					clsM.int_TimeDiff = (int)new TimeSpan(dateTime.Ticks - DateTime.Now.Ticks).TotalMilliseconds;
					Dictionary<string, string> dictionary_TimeP = clsM.dictionary_TimeP;
					string key2 = "TimeDiff";
					dictionary_TimeP[key2] = clsM.int_TimeDiff.ToString();
					if (class3_0.TKT_ISADV)
					{
						break;
					}
					long num = dateTime.Hour * 10000 + dateTime.Minute * 100 + dateTime.Second;
					if ((num < 75511 || num > 80511) && (num < 95511 || num > 101511) && (num < 105522 || num > 111500))
					{
						string variable = "clientID";
						string environmentVariable = Environment.GetEnvironmentVariable(variable);
						string text20 = "SGX9777";
						bool flag = environmentVariable == text20;
						string variable2 = "clientID";
						string environmentVariable2 = Environment.GetEnvironmentVariable(variable2);
						string text21 = "SGX9778";
						bool flag2 = flag | (environmentVariable2 == text21);
						string variable3 = "clientID";
						string environmentVariable3 = Environment.GetEnvironmentVariable(variable3);
						string text22 = "SGX9779";
						if (!(flag2 | (environmentVariable3 == text22)))
						{
							clsM.CloseTesting = true;
						}
					}
					break;
				}
				catch (Exception)
				{
				}
			}
		}
		string url4 = e.Response.Url;
		string value23 = "webtoken";
		if (url4.Contains(value23))
		{
			string text23 = "";
			while (true)
			{
				try
				{
					GetResponseBodyCommandResponse result8 = devTools.Network.GetResponseBody(new GetResponseBodyCommandSettings
					{
						RequestId = e.RequestId
					}, default(CancellationToken), null).GetAwaiter().GetResult();
					if (result8 == null)
					{
						continue;
					}
					text23 = result8.Body;
					string body11 = result8.Body;
					string value24 = "Invalid Captcha";
					if (body11.Contains(value24))
					{
						invalidCaptcha = true;
					}
					string body12 = result8.Body;
					string value25 = "Incorrect UserName or Password";
					if (body12.Contains(value25))
					{
						invalidUser = true;
					}
					string body13 = result8.Body;
					string value26 = "Unable to Process Request !!";
					if (body13.Contains(value26))
					{
						string body14 = result8.Body;
						string value27 = "Client IP:";
						if (body14.Contains(value27))
						{
							ipBlock_onLogin = true;
						}
					}
					break;
				}
				catch (Exception)
				{
				}
			}
			string text24 = text23;
			string value28 = "Access Denied";
			if (!text24.Contains(value28))
			{
				string text25 = text23;
				string value29 = "unauthorized";
				if (!text25.Contains(value29))
				{
					string text26 = text23;
					string value30 = "Unable to Process Request !!";
					if (!text26.Contains(value30))
					{
						clsPostData clsPostData = class3_0;
						string text27 = text23;
						string text28 = text23;
						string value31 = "access_token";
						clsPostData.string_61 = text27.Substring(text28.IndexOf(value31) + 15, 36);
						clsPostData clsPostData2 = class3_0;
						string text29 = "Bearer ";
						clsPostData2._Authorization = text29 + class3_0.string_61;
						clsM._Authrization = class3_0._Authorization;
					}
				}
			}
		}
		string url5 = e.Response.Url;
		string value32 = "https://www.irctc.co.in";
		if (!url5.Contains(value32) || !capture_sensor)
		{
			return;
		}
		try
		{
			string reqId = e.RequestId;
			Task.Run(async delegate
			{
				GetRequestPostDataCommandResponse responseBody = await devTools.Network.GetRequestPostData(new GetRequestPostDataCommandSettings
				{
					RequestId = reqId
				}, default(CancellationToken), null);
				string text30 = responseBody.PostData.ToString();
				string value34 = "sensor_data";
				if (text30.Contains(value34))
				{
					string text31 = (await devTools.Network.GetResponseBody(new GetResponseBodyCommandSettings
					{
						RequestId = reqId
					}, default(CancellationToken), null)).Body.ToString();
					string value35 = "success\": true";
					if (text31.Contains(value35))
					{
						capture_sensor = false;
						clsM.SensorURL = e.Response.Url;
						clsM.SensorData = responseBody.PostData.ToString();
						clsM.SensorValidate = true;
					}
				}
			});
		}
		catch (Exception)
		{
		}
	}

	internal void Network_ResponseReceivedchrome(object sender, ResponseReceivedEventArgs e)
	{
		foreach (KeyValuePair<string, string> header in e.Response.Headers)
		{
			string text = header.Key.ToLower();
			string text2 = "csrf-token";
			if (text == text2)
			{
				clsM.csrf_token = header.Value;
			}
		}
		string url = e.Response.Url;
		string value = "altAvlEnq/TC";
		if (url.Contains(value))
		{
			while (true)
			{
				try
				{
					GetResponseBodyCommandResponse result = devTools.Network.GetResponseBody(new GetResponseBodyCommandSettings
					{
						RequestId = e.RequestId
					}, default(CancellationToken), null).GetAwaiter().GetResult();
					if (result != null)
					{
						string body = result.Body;
						clsM.response = result.Body;
						clsM.Res_Received = true;
						break;
					}
				}
				catch
				{
				}
			}
		}
		string value2 = "avlFarenquiry";
		if (url.Contains(value2))
		{
			while (true)
			{
				try
				{
					GetResponseBodyCommandResponse result2 = devTools.Network.GetResponseBody(new GetResponseBodyCommandSettings
					{
						RequestId = e.RequestId
					}, default(CancellationToken), null).GetAwaiter().GetResult();
					if (result2 == null)
					{
						continue;
					}
					clsM.response = result2.Body;
					clsM.Res_Received = true;
					break;
				}
				catch (Exception)
				{
				}
			}
		}
		string value3 = "boardingStationEnq";
		if (url.Contains(value3))
		{
			while (true)
			{
				try
				{
					GetResponseBodyCommandResponse result3 = devTools.Network.GetResponseBody(new GetResponseBodyCommandSettings
					{
						RequestId = e.RequestId
					}, default(CancellationToken), null).GetAwaiter().GetResult();
					if (result3 == null)
					{
						continue;
					}
					clsM.response = result3.Body;
					clsM.Res_Received = true;
					break;
				}
				catch
				{
				}
			}
		}
		string value4 = "allLapAvlFareEnq/Y";
		if (url.Contains(value4))
		{
			while (true)
			{
				try
				{
					GetResponseBodyCommandResponse result4 = devTools.Network.GetResponseBody(new GetResponseBodyCommandSettings
					{
						RequestId = e.RequestId
					}, default(CancellationToken), null).GetAwaiter().GetResult();
					if (result4 != null)
					{
						capture_sensor = false;
						clsM.response = result4.Body;
						clsM.Res_Received = true;
						break;
					}
				}
				catch
				{
				}
			}
		}
		string value5 = "addonServices";
		if (url.Contains(value5))
		{
			string text3 = "";
			while (true)
			{
				try
				{
					GetResponseBodyCommandResponse result5 = devTools.Network.GetResponseBody(new GetResponseBodyCommandSettings
					{
						RequestId = e.RequestId
					}, default(CancellationToken), null).GetAwaiter().GetResult();
					text3 = (result5.Base64Encoded ? Encoding.UTF8.GetString(Convert.FromBase64String(result5.Body)) : result5.Body);
					clsM.response = text3;
					clsM.Res_Received = true;
				}
				catch
				{
					continue;
				}
				break;
			}
		}
		string url2 = e.Response.Url;
		string value6 = "eticketing/protected/mapps1/validateUser";
		if (url2.Contains(value6))
		{
			foreach (KeyValuePair<string, string> header2 in e.Response.Headers)
			{
				string key = header2.Key;
				string text4 = "csrf-token";
				if (key == text4)
				{
					clsM.csrf_token = header2.Value;
				}
			}
			string text5 = "";
			while (true)
			{
				try
				{
					GetResponseBodyCommandResponse result6 = devTools.Network.GetResponseBody(new GetResponseBodyCommandSettings
					{
						RequestId = e.RequestId
					}, default(CancellationToken), null).GetAwaiter().GetResult();
					if (result6 != null)
					{
						string body2 = result6.Body;
						string value7 = "userIdHash";
						if (body2.Contains(value7))
						{
							text5 = result6.Body;
							break;
						}
					}
				}
				catch (Exception)
				{
				}
			}
			string text6 = text5;
			string value8 = "userIdHash";
			if (text6.Contains(value8))
			{
				clsM.response = text5;
				class3_0.Validate_Response = text5;
				clsMain clsMain = clsM;
				string string_ = text5;
				string string_2 = "userIdHash";
				clsMain.bmiyek = GetString(string_, string_2);
				string string_3 = text5;
				string string_4 = "minmPsgnInputTime";
				string text7 = GetString(string_3, string_4).ToUpper();
				string[] array = new string[1];
				string text8 = "#";
				array[0] = text8;
				string[] array2 = text7.Split(array, StringSplitOptions.None);
				double.TryParse(array2[0], out clsM.minmPsgnInputTime2);
				double.TryParse(array2[2], out clsM.minmPsgnInputTime4);
				double.TryParse(array2[4], out clsM.minmPsgnInputTime6);
				clsMain clsMain2 = clsM;
				string string_5 = text5;
				string string_6 = "gender";
				clsMain2.UserGender = GetString(string_5, string_6);
				string string_7 = text5;
				string string_8 = "minmPaymentTime";
				double.TryParse(GetString(string_7, string_8).ToUpper(), out clsM.minmPaymentTime);
				_ = DateTime.Now.Hour;
				_ = DateTime.Now.Minute;
				_ = DateTime.Now.Second;
				string text9 = text5;
				string value9 = "Aadhaar authentication of IRCTC user profile is mandatory to book Tatkal and Premium Tatkal";
				if (text9.IndexOf(value9) <= 0)
				{
					clsM.AadharVerifyied = true;
				}
				else
				{
					clsM.AadharVerifyied = false;
				}
				string text10 = text5;
				string value10 = "userEnableState\"";
				if (text10.IndexOf(value10) > 0)
				{
					string text11 = text5;
					string value11 = "userEnableState\":\"5";
					text11.IndexOf(value11);
					string text12 = text5;
					string value12 = "userEnableState\":\"3";
					if (text12.IndexOf(value12) > 0)
					{
						string string_9 = "TBL_USER";
						string string_10 = "UserState";
						string text13 = "Suspend||";
						Class11.smethod_1(string_9, string_10, text13 + class3_0.string_3, class3_0.IRCTC_ID);
					}
					string text14 = text5;
					string value13 = "userEnableState\":\"1";
					text14.IndexOf(value13);
					string text15 = text5;
					string value14 = "verified\":\"false";
					if (text15.IndexOf(value14) > 0)
					{
						clsM.Un_Verifyied = true;
					}
				}
				allDone = true;
			}
		}
		string url3 = e.Response.Url;
		string value15 = "irctc.co.in/eticketing/protected/mapps1/loginCaptcha";
		if (url3.Contains(value15))
		{
			while (true)
			{
				try
				{
					GetResponseBodyCommandResponse result7 = devTools.Network.GetResponseBody(new GetResponseBodyCommandSettings
					{
						RequestId = e.RequestId
					}, default(CancellationToken), null).GetAwaiter().GetResult();
					if (result7 == null)
					{
						continue;
					}
					string body3 = result7.Body;
					string value16 = "status";
					if (!body3.Contains(value16))
					{
						continue;
					}
					clsMain clsMain3 = clsM;
					string body4 = result7.Body;
					string string_11 = "status";
					clsMain3.greq = GetString(body4, string_11);
					string body5 = result7.Body;
					string value17 = "captchaQuestion";
					if (body5.IndexOf(value17) <= 0)
					{
						break;
					}
					string body6 = result7.Body;
					string body7 = result7.Body;
					string value18 = "captchaQuestion";
					string text16 = body6.Substring(body7.IndexOf(value18) + 18);
					clsMain clsMain4 = clsM;
					string value19 = "\"";
					clsMain4.CaptchaBase64 = text16.Substring(0, text16.IndexOf(value19));
					clsM.dateTime_2 = DateTime.Now;
					string body8 = result7.Body;
					string value20 = "timeStamp";
					if (!body8.Contains(value20))
					{
						break;
					}
					string body9 = result7.Body;
					string body10 = result7.Body;
					string value21 = "timeStamp";
					string text17 = body9.Substring(body10.IndexOf(value21) + 23);
					string text18 = text17;
					string text19 = text17;
					string value22 = "\"";
					text17 = text18.Substring(0, text19.IndexOf(value22));
					DateTime dateTime = DateTime.Parse(text17);
					clsM.int_TimeDiff = (int)new TimeSpan(dateTime.Ticks - DateTime.Now.Ticks).TotalMilliseconds;
					Dictionary<string, string> dictionary_TimeP = clsM.dictionary_TimeP;
					string key2 = "TimeDiff";
					dictionary_TimeP[key2] = clsM.int_TimeDiff.ToString();
					if (class3_0.TKT_ISADV)
					{
						break;
					}
					long num = dateTime.Hour * 10000 + dateTime.Minute * 100 + dateTime.Second;
					if ((num < 75511 || num > 80511) && (num < 95511 || num > 101511) && (num < 105522 || num > 111500))
					{
						string variable = "clientID";
						string environmentVariable = Environment.GetEnvironmentVariable(variable);
						string text20 = "SGX9777";
						bool flag = environmentVariable == text20;
						string variable2 = "clientID";
						string environmentVariable2 = Environment.GetEnvironmentVariable(variable2);
						string text21 = "SGX9778";
						bool flag2 = flag | (environmentVariable2 == text21);
						string variable3 = "clientID";
						string environmentVariable3 = Environment.GetEnvironmentVariable(variable3);
						string text22 = "SGX9779";
						if (!(flag2 | (environmentVariable3 == text22)))
						{
							clsM.CloseTesting = true;
						}
					}
					break;
				}
				catch (Exception)
				{
				}
			}
		}
		string url4 = e.Response.Url;
		string value23 = "webtoken";
		if (url4.Contains(value23))
		{
			string text23 = "";
			while (true)
			{
				try
				{
					GetResponseBodyCommandResponse result8 = devTools.Network.GetResponseBody(new GetResponseBodyCommandSettings
					{
						RequestId = e.RequestId
					}, default(CancellationToken), null).GetAwaiter().GetResult();
					if (result8 == null)
					{
						continue;
					}
					text23 = result8.Body;
					string body11 = result8.Body;
					string value24 = "Invalid Captcha";
					if (body11.Contains(value24))
					{
						invalidCaptcha = true;
					}
					string body12 = result8.Body;
					string value25 = "Incorrect UserName or Password";
					if (body12.Contains(value25))
					{
						invalidUser = true;
					}
					string body13 = result8.Body;
					string value26 = "Unable to Process Request !!";
					if (body13.Contains(value26))
					{
						string body14 = result8.Body;
						string value27 = "Client IP:";
						if (body14.Contains(value27))
						{
							ipBlock_onLogin = true;
						}
					}
					break;
				}
				catch (Exception)
				{
				}
			}
			string text24 = text23;
			string value28 = "Access Denied";
			if (!text24.Contains(value28))
			{
				string text25 = text23;
				string value29 = "unauthorized";
				if (!text25.Contains(value29))
				{
					string text26 = text23;
					string value30 = "Unable to Process Request !!";
					if (!text26.Contains(value30))
					{
						clsPostData clsPostData = class3_0;
						string text27 = text23;
						string text28 = text23;
						string value31 = "access_token";
						clsPostData.string_61 = text27.Substring(text28.IndexOf(value31) + 15, 36);
						clsPostData clsPostData2 = class3_0;
						string text29 = "Bearer ";
						clsPostData2._Authorization = text29 + class3_0.string_61;
						clsM._Authrization = class3_0._Authorization;
					}
				}
			}
		}
		string url5 = e.Response.Url;
		string value32 = "https://www.irctc.co.in";
		if (!url5.Contains(value32) || !capture_sensor)
		{
			return;
		}
		try
		{
			string reqId = e.RequestId;
			Task.Run(async delegate
			{
				GetRequestPostDataCommandResponse responseBody = await devTools.Network.GetRequestPostData(new GetRequestPostDataCommandSettings
				{
					RequestId = reqId
				}, default(CancellationToken), null);
				string text30 = responseBody.PostData.ToString();
				string value34 = "sensor_data";
				if (text30.Contains(value34))
				{
					string text31 = (await devTools.Network.GetResponseBody(new GetResponseBodyCommandSettings
					{
						RequestId = reqId
					}, default(CancellationToken), null)).Body.ToString();
					string value35 = "success\": true";
					if (text31.Contains(value35))
					{
						capture_sensor = false;
						clsM.SensorURL = e.Response.Url;
						clsM.SensorData = responseBody.PostData.ToString();
						clsM.SensorValidate = true;
					}
				}
			});
		}
		catch (Exception)
		{
		}
	}

	internal void Network_ResponseReceivedbrave(object sender, ResponseReceivedEventArgs e)
	{
		foreach (KeyValuePair<string, string> header in e.Response.Headers)
		{
			string text = header.Key.ToLower();
			string text2 = "csrf-token";
			if (text == text2)
			{
				clsM.csrf_token = header.Value;
			}
		}
		string url = e.Response.Url;
		string value = "altAvlEnq/TC";
		if (url.Contains(value))
		{
			while (true)
			{
				try
				{
					GetResponseBodyCommandResponse result = devTools.Network.GetResponseBody(new GetResponseBodyCommandSettings
					{
						RequestId = e.RequestId
					}, default(CancellationToken), null).GetAwaiter().GetResult();
					if (result != null)
					{
						string body = result.Body;
						clsM.response = result.Body;
						clsM.Res_Received = true;
						break;
					}
				}
				catch
				{
				}
			}
		}
		string value2 = "avlFarenquiry";
		if (url.Contains(value2))
		{
			while (true)
			{
				try
				{
					GetResponseBodyCommandResponse result2 = devTools.Network.GetResponseBody(new GetResponseBodyCommandSettings
					{
						RequestId = e.RequestId
					}, default(CancellationToken), null).GetAwaiter().GetResult();
					if (result2 == null)
					{
						continue;
					}
					clsM.response = result2.Body;
					clsM.Res_Received = true;
					break;
				}
				catch (Exception)
				{
				}
			}
		}
		string value3 = "boardingStationEnq";
		if (url.Contains(value3))
		{
			while (true)
			{
				try
				{
					GetResponseBodyCommandResponse result3 = devTools.Network.GetResponseBody(new GetResponseBodyCommandSettings
					{
						RequestId = e.RequestId
					}, default(CancellationToken), null).GetAwaiter().GetResult();
					if (result3 == null)
					{
						continue;
					}
					clsM.response = result3.Body;
					clsM.Res_Received = true;
					break;
				}
				catch
				{
				}
			}
		}
		string value4 = "allLapAvlFareEnq/Y";
		if (url.Contains(value4))
		{
			while (true)
			{
				try
				{
					GetResponseBodyCommandResponse result4 = devTools.Network.GetResponseBody(new GetResponseBodyCommandSettings
					{
						RequestId = e.RequestId
					}, default(CancellationToken), null).GetAwaiter().GetResult();
					if (result4 != null)
					{
						capture_sensor = false;
						clsM.response = result4.Body;
						clsM.Res_Received = true;
						break;
					}
				}
				catch
				{
				}
			}
		}
		string value5 = "addonServices";
		if (url.Contains(value5))
		{
			string text3 = "";
			while (true)
			{
				try
				{
					GetResponseBodyCommandResponse result5 = devTools.Network.GetResponseBody(new GetResponseBodyCommandSettings
					{
						RequestId = e.RequestId
					}, default(CancellationToken), null).GetAwaiter().GetResult();
					text3 = (result5.Base64Encoded ? Encoding.UTF8.GetString(Convert.FromBase64String(result5.Body)) : result5.Body);
					clsM.response = text3;
					clsM.Res_Received = true;
				}
				catch
				{
					continue;
				}
				break;
			}
		}
		string url2 = e.Response.Url;
		string value6 = "eticketing/protected/mapps1/validateUser";
		if (url2.Contains(value6))
		{
			foreach (KeyValuePair<string, string> header2 in e.Response.Headers)
			{
				string key = header2.Key;
				string text4 = "csrf-token";
				if (key == text4)
				{
					clsM.csrf_token = header2.Value;
				}
			}
			string text5 = "";
			while (true)
			{
				try
				{
					GetResponseBodyCommandResponse result6 = devTools.Network.GetResponseBody(new GetResponseBodyCommandSettings
					{
						RequestId = e.RequestId
					}, default(CancellationToken), null).GetAwaiter().GetResult();
					if (result6 != null)
					{
						string body2 = result6.Body;
						string value7 = "userIdHash";
						if (body2.Contains(value7))
						{
							text5 = result6.Body;
							break;
						}
					}
				}
				catch (Exception)
				{
				}
			}
			string text6 = text5;
			string value8 = "userIdHash";
			if (text6.Contains(value8))
			{
				clsM.response = text5;
				class3_0.Validate_Response = text5;
				clsMain clsMain = clsM;
				string string_ = text5;
				string string_2 = "userIdHash";
				clsMain.bmiyek = GetString(string_, string_2);
				string string_3 = text5;
				string string_4 = "minmPsgnInputTime";
				string text7 = GetString(string_3, string_4).ToUpper();
				string[] array = new string[1];
				string text8 = "#";
				array[0] = text8;
				string[] array2 = text7.Split(array, StringSplitOptions.None);
				double.TryParse(array2[0], out clsM.minmPsgnInputTime2);
				double.TryParse(array2[2], out clsM.minmPsgnInputTime4);
				double.TryParse(array2[4], out clsM.minmPsgnInputTime6);
				clsMain clsMain2 = clsM;
				string string_5 = text5;
				string string_6 = "gender";
				clsMain2.UserGender = GetString(string_5, string_6);
				string string_7 = text5;
				string string_8 = "minmPaymentTime";
				double.TryParse(GetString(string_7, string_8).ToUpper(), out clsM.minmPaymentTime);
				_ = DateTime.Now.Hour;
				_ = DateTime.Now.Minute;
				_ = DateTime.Now.Second;
				string text9 = text5;
				string value9 = "Aadhaar authentication of IRCTC user profile is mandatory to book Tatkal and Premium Tatkal";
				if (text9.IndexOf(value9) <= 0)
				{
					clsM.AadharVerifyied = true;
				}
				else
				{
					clsM.AadharVerifyied = false;
				}
				string text10 = text5;
				string value10 = "userEnableState\"";
				if (text10.IndexOf(value10) > 0)
				{
					string text11 = text5;
					string value11 = "userEnableState\":\"5";
					text11.IndexOf(value11);
					string text12 = text5;
					string value12 = "userEnableState\":\"3";
					if (text12.IndexOf(value12) > 0)
					{
						string string_9 = "TBL_USER";
						string string_10 = "UserState";
						string text13 = "Suspend||";
						Class11.smethod_1(string_9, string_10, text13 + class3_0.string_3, class3_0.IRCTC_ID);
					}
					string text14 = text5;
					string value13 = "userEnableState\":\"1";
					text14.IndexOf(value13);
					string text15 = text5;
					string value14 = "verified\":\"false";
					if (text15.IndexOf(value14) > 0)
					{
						clsM.Un_Verifyied = true;
					}
				}
				allDone = true;
			}
		}
		string url3 = e.Response.Url;
		string value15 = "irctc.co.in/eticketing/protected/mapps1/loginCaptcha";
		if (url3.Contains(value15))
		{
			while (true)
			{
				try
				{
					GetResponseBodyCommandResponse result7 = devTools.Network.GetResponseBody(new GetResponseBodyCommandSettings
					{
						RequestId = e.RequestId
					}, default(CancellationToken), null).GetAwaiter().GetResult();
					if (result7 == null)
					{
						continue;
					}
					string body3 = result7.Body;
					string value16 = "status";
					if (!body3.Contains(value16))
					{
						continue;
					}
					clsMain clsMain3 = clsM;
					string body4 = result7.Body;
					string string_11 = "status";
					clsMain3.greq = GetString(body4, string_11);
					string body5 = result7.Body;
					string value17 = "captchaQuestion";
					if (body5.IndexOf(value17) <= 0)
					{
						break;
					}
					string body6 = result7.Body;
					string body7 = result7.Body;
					string value18 = "captchaQuestion";
					string text16 = body6.Substring(body7.IndexOf(value18) + 18);
					clsMain clsMain4 = clsM;
					string value19 = "\"";
					clsMain4.CaptchaBase64 = text16.Substring(0, text16.IndexOf(value19));
					clsM.dateTime_2 = DateTime.Now;
					string body8 = result7.Body;
					string value20 = "timeStamp";
					if (!body8.Contains(value20))
					{
						break;
					}
					string body9 = result7.Body;
					string body10 = result7.Body;
					string value21 = "timeStamp";
					string text17 = body9.Substring(body10.IndexOf(value21) + 23);
					string text18 = text17;
					string text19 = text17;
					string value22 = "\"";
					text17 = text18.Substring(0, text19.IndexOf(value22));
					DateTime dateTime = DateTime.Parse(text17);
					clsM.int_TimeDiff = (int)new TimeSpan(dateTime.Ticks - DateTime.Now.Ticks).TotalMilliseconds;
					Dictionary<string, string> dictionary_TimeP = clsM.dictionary_TimeP;
					string key2 = "TimeDiff";
					dictionary_TimeP[key2] = clsM.int_TimeDiff.ToString();
					if (class3_0.TKT_ISADV)
					{
						break;
					}
					long num = dateTime.Hour * 10000 + dateTime.Minute * 100 + dateTime.Second;
					if ((num < 75511 || num > 80511) && (num < 95511 || num > 101511) && (num < 105522 || num > 111500))
					{
						string variable = "clientID";
						string environmentVariable = Environment.GetEnvironmentVariable(variable);
						string text20 = "SGX9777";
						bool flag = environmentVariable == text20;
						string variable2 = "clientID";
						string environmentVariable2 = Environment.GetEnvironmentVariable(variable2);
						string text21 = "SGX9778";
						bool flag2 = flag | (environmentVariable2 == text21);
						string variable3 = "clientID";
						string environmentVariable3 = Environment.GetEnvironmentVariable(variable3);
						string text22 = "SGX9779";
						if (!(flag2 | (environmentVariable3 == text22)))
						{
							clsM.CloseTesting = true;
						}
					}
					break;
				}
				catch (Exception)
				{
				}
			}
		}
		string url4 = e.Response.Url;
		string value23 = "webtoken";
		if (url4.Contains(value23))
		{
			string text23 = "";
			while (true)
			{
				try
				{
					GetResponseBodyCommandResponse result8 = devTools.Network.GetResponseBody(new GetResponseBodyCommandSettings
					{
						RequestId = e.RequestId
					}, default(CancellationToken), null).GetAwaiter().GetResult();
					if (result8 == null)
					{
						continue;
					}
					text23 = result8.Body;
					string body11 = result8.Body;
					string value24 = "Invalid Captcha";
					if (body11.Contains(value24))
					{
						invalidCaptcha = true;
					}
					string body12 = result8.Body;
					string value25 = "Incorrect UserName or Password";
					if (body12.Contains(value25))
					{
						invalidUser = true;
					}
					string body13 = result8.Body;
					clsM.Res_Received = true;
					string value26 = "Unable to Process Request !!";
					if (body13.Contains(value26))
					{
						string body14 = result8.Body;
						string value27 = "Client IP:";
						if (body14.Contains(value27))
						{
							ipBlock_onLogin = true;
						}
					}
					break;
				}
				catch (Exception)
				{
				}
			}
			string text24 = text23;
			string value28 = "Access Denied";
			if (!text24.Contains(value28))
			{
				string text25 = text23;
				string value29 = "unauthorized";
				if (!text25.Contains(value29))
				{
					string text26 = text23;
					string value30 = "Unable to Process Request !!";
					if (!text26.Contains(value30))
					{
						clsPostData clsPostData = class3_0;
						string text27 = text23;
						string text28 = text23;
						string value31 = "access_token";
						clsPostData.string_61 = text27.Substring(text28.IndexOf(value31) + 15, 36);
						clsPostData clsPostData2 = class3_0;
						string text29 = "Bearer ";
						clsPostData2._Authorization = text29 + class3_0.string_61;
						clsM._Authrization = class3_0._Authorization;
					}
				}
			}
		}
		string url5 = e.Response.Url;
		string value32 = "https://www.irctc.co.in";
		if (!url5.Contains(value32) || !capture_sensor)
		{
			return;
		}
		try
		{
			string reqId = e.RequestId;
			Task.Run(async delegate
			{
				GetRequestPostDataCommandResponse responseBody = await devTools.Network.GetRequestPostData(new GetRequestPostDataCommandSettings
				{
					RequestId = reqId
				}, default(CancellationToken), null);
				string text30 = responseBody.PostData.ToString();
				string value34 = "sensor_data";
				if (text30.Contains(value34))
				{
					string text31 = (await devTools.Network.GetResponseBody(new GetResponseBodyCommandSettings
					{
						RequestId = reqId
					}, default(CancellationToken), null)).Body.ToString();
					string value35 = "success\": true";
					if (text31.Contains(value35))
					{
						capture_sensor = false;
						clsM.SensorURL = e.Response.Url;
						clsM.SensorData = responseBody.PostData.ToString();
						clsM.SensorValidate = true;
					}
				}
			});
		}
		catch (Exception)
		{
		}
	}

	internal string GetString(string string_86, string string_87)
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

	internal void HumanClickButton0(IWebDriver driver, By locator, int timeoutSeconds = 20)
	{
		Random random = new Random();
		IWebElement webElement2 = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds)).Until(delegate(IWebDriver drv)
		{
			try
			{
				IWebElement webElement = drv.FindElement(locator);
				return (!webElement.Displayed || !webElement.Enabled) ? null : webElement;
			}
			catch
			{
				return (IWebElement?)null;
			}
		});
		IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;
		string text = "\r\n    var el = arguments[0];\r\n    if(!el) return false;\r\n\r\n    var rect = el.getBoundingClientRect();\r\n    // Random click position inside element\r\n    var x = rect.left + rect.width * (0.25 + Math.random() * 0.5);\r\n    var y = rect.top + rect.height * (0.35 + Math.random() * 0.4);\r\n\r\n    function fire(type, x, y, delay) {\r\n        setTimeout(function(){\r\n            var evt = new MouseEvent(type, {\r\n              bubbles: true,\r\n              cancelable: true,\r\n              clientX: x,\r\n              clientY: y,\r\n              view: window,\r\n              button: 0\r\n            });\r\n            el.dispatchEvent(evt);\r\n        }, delay);\r\n    }\r\n\r\n    var baseDelay = Math.floor(40 + Math.random()*90);\r\n\r\n    fire('mousemove', x-3, y-3, baseDelay);\r\n    fire('mouseover', x, y, baseDelay+60);\r\n    fire('mousemove', x, y, baseDelay+120);\r\n    fire('mousedown', x, y, baseDelay+180);\r\n    fire('mouseup', x, y, baseDelay+220 + Math.random()*80);\r\n    fire('click', x, y, baseDelay+250 + Math.random()*120);\r\n\r\n    return true;\r\n    ";
		string script = text;
		javaScriptExecutor.ExecuteScript(script, webElement2);
		Thread.Sleep(random.Next(300, 600));
	}

	internal void WaitCloseDisha(UndetectedChromeDriver driver, By locator, int timeoutSeconds = 30)
	{
		new Random();
		new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds)).Until(delegate(IWebDriver drv)
		{
			try
			{
				IWebElement webElement = drv.FindElement(locator);
				return (!webElement.Displayed || !webElement.Enabled) ? null : webElement;
			}
			catch
			{
				return (IWebElement?)null;
			}
		});
	}

	internal void DisableAllIrctcAdsAndPopups(IWebDriver driver)
	{
		IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;
		string script = "\r\n(function() {\r\n\r\n    // ---- 1) JS popups / window.open क\u094b disable कर\u094b (optional) ----\r\n    try {\r\n        window.alert = function() { return null; };\r\n        window.confirm = function() { return false; };\r\n        window.prompt = function() { return null; };\r\n\r\n        // अगर bank page / payment window नह\u0940\u0902 ख\u0941ल रह\u0940 ह\u094b त\u094b इसक\u094b comment कर द\u0947न\u093e\r\n        window.open = function() { return null; };\r\n    } catch(e) {}\r\n\r\n    function removeKnownStuff() {\r\n        // ---- 2) Known IRCTC ads / bots / widgets ----\r\n\r\n        var selectors = [\r\n            // AskDisha cards & widgets\r\n    '#disha-placeholder-card',\r\n    '#askDishaSdk',\r\n    '#corover-askDisha',\r\n    '#askDishaLuncher',\r\n    '#Disha-Bot',\r\n    '#messageDialog',\r\n    '#messageDialogClose',\r\n\r\n    // Adgebra cuboid\r\n    '#adg_cuboid_container',\r\n    '#companionAd00220',\r\n\r\n    // VDO.AI / instream container\r\n    '#instream_js_adcode',\r\n    '.mainTrackElem',\r\n    '.mainDetachElem',\r\n    '.mainAdContainer',\r\n    '.powered_ads',\r\n\r\n    // vdo bottom banner type\r\n    'div[id^=b_irctc_co_in_320x50_ATF_]',\r\n    '#b_irctc_co_in_320x50_ATF_268ecbf55ad467',\r\n\r\n    // generic ad wrapper classes\r\n    'div[class^=del-TR-]',\r\n\r\n    // \ud83d\udc49 NEW: Amazon DEALS button\r\n    '#dod'\r\n        ];\r\n\r\n        selectors.forEach(function(sel) {\r\n            try {\r\n                var nodes = document.querySelectorAll(sel);\r\n                nodes.forEach(function(n) { n.remove(); });\r\n            } catch(e) {}\r\n        });\r\n\r\n        // ---- 3) Iframe based ad providers / AskDisha iframes ----\r\n        var iframeHosts = [\r\n            'askdisha.irctc.co.in',\r\n            'vdo.ai',\r\n            'adgebra',\r\n            'imasdk.googleapis.com',\r\n            'googleads',\r\n            'doubleclick.net'\r\n        ];\r\n\r\n        iframeHosts.forEach(function(host) {\r\n            try {\r\n                var iframes = document.querySelectorAll('iframe[src*=' + host + ']');\r\n                iframes.forEach(function(f) { f.remove(); });\r\n            } catch(e) {}\r\n        });\r\n\r\n        // ---- 4) Generic AskDisha / Corover fallback ----\r\n        try {\r\n            document.querySelectorAll('[id*=Disha], [id*=disha], [class*=Disha], [class*=disha], [id*=corover], [class*=corover]')\r\n                .forEach(function(e) { e.remove(); });\r\n        } catch(e) {}\r\n\r\n        // ---- 5) Generic fixed-position overlays near edges (ads / nudges) ----\r\n        try {\r\n            document.querySelectorAll('div, section').forEach(function(e) {\r\n                var style = e.style || {};\r\n                if (!style) return;\r\n\r\n                if (style.position === 'fixed') {\r\n                    var txt = (e.innerText || '').toLowerCase();\r\n\r\n                    var looksLikeAd =\r\n                        txt.indexOf('advert') >= 0 ||\r\n                        txt.indexOf('advt') >= 0 ||\r\n                        txt.indexOf('sponsored') >= 0;\r\n\r\n                    var nearEdge =\r\n                        (style.bottom && style.bottom.indexOf('0') >= 0) ||\r\n                        (style.top && parseInt(style.top) <= 200) ||\r\n                        (style.right && style.right.indexOf('0') >= 0) ||\r\n                        (style.left && style.left.indexOf('0') >= 0);\r\n\r\n                    if (looksLikeAd || nearEdge) {\r\n                        try { e.remove(); } catch(_) {}\r\n                    }\r\n                }\r\n            });\r\n        } catch(e) {}\r\n    }\r\n\r\n    // initial clean\r\n    removeKnownStuff();\r\n\r\n    // ---- 6) MutationObserver – द\u0941ब\u093eर\u093e inject ह\u094bन\u0947 पर भ\u0940 स\u093eफ कर\u094b ----\r\n    try {\r\n        var obs = new MutationObserver(function(mutations) {\r\n            removeKnownStuff();\r\n        });\r\n\r\n        obs.observe(document.body || document.documentElement, {\r\n            childList: true,\r\n            subtree: true\r\n        });\r\n    } catch(e) {\r\n        // fallback: अगर observer fail ह\u094b ज\u093eए त\u094b भ\u0940 कम स\u0947 कम अभ\u0940 स\u093eफ ह\u094b च\u0941क\u093e ह\u0948\r\n    }\r\n\r\n})();\r\n";
		javaScriptExecutor.ExecuteScript(script);
		string script2 = "\r\n(function () {\r\n    try {\r\n        // 1) PrimeNG / IRCTC overlay masks remove karo\r\n        var overlays = document.querySelectorAll(\r\n            '.ui-widget-overlay, .ui-dialog-mask, .cdk-overlay-backdrop, .cdk-overlay-dark-backdrop'\r\n        );\r\n        for (var i = 0; i < overlays.length; i++) {\r\n            var o = overlays[i];\r\n            if (o && o.parentNode) {\r\n                o.parentNode.removeChild(o);\r\n            }\r\n        }\r\n\r\n        // 2) Koi full-screen fixed transparent layer ho to usko bhi hatao\r\n        var divs = document.querySelectorAll('div');\r\n        for (var j = 0; j < divs.length; j++) {\r\n            var e = divs[j];\r\n            if (!e || !e.style) continue;\r\n\r\n            if (e.style.position === 'fixed') {\r\n                var w = e.style.width || '';\r\n                var h = e.style.height || '';\r\n\r\n                // full screen overlay approx\r\n                if (\r\n                    (w.indexOf('100%') >= 0 || w.indexOf('100vw') >= 0 || w === '') &&\r\n                    (h.indexOf('100%') >= 0 || h.indexOf('100vh') >= 0 || h === '')\r\n                ) {\r\n                    // agar andar dialog text / aadhaar text ho to remove\r\n                    var txt = (e.innerText || '').toLowerCase();\r\n                    if (\r\n                        txt.indexOf('aadhaar') >= 0 ||\r\n                        txt.indexOf('with effect from') >= 0 ||\r\n                        txt.indexOf('28 october') >= 0\r\n                    ) {\r\n                        if (e.parentNode) e.parentNode.removeChild(e);\r\n                    }\r\n                }\r\n            }\r\n        }\r\n\r\n        // 3) Body par interaction wapas enable karo\r\n        document.body.style.pointerEvents = 'auto';\r\n        document.body.style.overflow = 'auto';\r\n\r\n    } catch (e) {}\r\n})();\r\n";
		javaScriptExecutor.ExecuteScript(script2);
	}

	internal bool ExistsWithWait(IWebDriver driver, By selector, int seconds = 5)
	{
		try
		{
			new WebDriverWait(driver, TimeSpan.FromSeconds(seconds)).Until((IWebDriver d) => d.FindElements(selector).Count > 0);
			return true;
		}
		catch
		{
			return false;
		}
	}

	internal void HumanClickButton(UndetectedChromeDriver driver, By locator, int timeoutSeconds = 20)
	{
		Random random = new Random();
		IWebElement webElement2 = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds)).Until(delegate(IWebDriver drv)
		{
			try
			{
				IWebElement webElement = drv.FindElement(locator);
				return (!webElement.Displayed || !webElement.Enabled) ? null : webElement;
			}
			catch
			{
				return (IWebElement?)null;
			}
		});
		string text = "\r\n    (function(el) {\r\n        if(!el) return false;\r\n\r\n        var rect = el.getBoundingClientRect();\r\n        var pageX = window.pageXOffset || document.documentElement.scrollLeft || 0;\r\n        var pageY = window.pageYOffset || document.documentElement.scrollTop || 0;\r\n\r\n        // Random click position inside element\r\n        var clickX = rect.left + rect.width * (0.25 + Math.random() * 0.5);\r\n        var clickY = rect.top + rect.height * (0.35 + Math.random() * 0.4);\r\n\r\n        // Choose a start position (a bit away from element for visible travel)\r\n        var startX = rect.left - 30 + (Math.random() * (rect.width + 60));\r\n        var startY = rect.top - 80 + (Math.random() * 40);\r\n\r\n        // Convert to page coordinates\r\n        startX = startX + pageX;\r\n        startY = startY + pageY;\r\n        clickX = clickX + pageX;\r\n        clickY = clickY + pageY;\r\n\r\n        // Create bubble element\r\n        var bubble = document.createElement('div');\r\n        bubble.style.position = 'absolute';\r\n        bubble.style.zIndex = 2147483647; // very top\r\n        bubble.style.pointerEvents = 'none';\r\n        var size = 12 + Math.floor(Math.random()*10); // 12-21px\r\n        bubble.style.width = size + 'px';\r\n        bubble.style.height = size + 'px';\r\n        bubble.style.borderRadius = '50%';\r\n        bubble.style.boxShadow = '0 0 6px rgba(0,0,0,0.25)';\r\n        bubble.style.background = 'rgba(0,0,0,0.65)';\r\n        bubble.style.opacity = '0.95';\r\n        bubble.style.transition = 'none';\r\n        bubble.style.transform = 'translate(' + startX + 'px,' + startY + 'px)';\r\n        bubble.style.left = '0px';\r\n        bubble.style.top = '0px';\r\n        bubble.style.willChange = 'transform';\r\n\r\n        document.documentElement.appendChild(bubble);\r\n\r\n        // Animation parameters\r\n        var duration = 300 + Math.floor(Math.random()*400); // 300-700ms\r\n        var startTime = null;\r\n\r\n        function step(timestamp) {\r\n            if (!startTime) startTime = timestamp;\r\n            var t = Math.min(1, (timestamp - startTime) / duration);\r\n            // easeOut cubic\r\n            var ease = 1 - Math.pow(1 - t, 3);\r\n\r\n            var curX = startX + (clickX - startX) * ease;\r\n            var curY = startY + (clickY - startY) * ease;\r\n\r\n            bubble.style.transform = 'translate(' + Math.round(curX) + 'px,' + Math.round(curY) + 'px)';\r\n\r\n            if (t < 1) {\r\n                window.requestAnimationFrame(step);\r\n            } else {\r\n                // small bounce (scale) effect\r\n                bubble.style.transition = 'transform 120ms ease';\r\n                bubble.style.transform = 'translate(' + Math.round(clickX) + 'px,' + Math.round(clickY) + 'px) scale(0.9)';\r\n                setTimeout(function(){ bubble.style.transform = 'translate(' + Math.round(clickX) + 'px,' + Math.round(clickY) + 'px) scale(1)'; }, 120);\r\n                // After animation ends, fire mouse events with realistic timing\r\n                scheduleMouseEvents();\r\n            }\r\n        }\r\n\r\n        // Mouse event helper (page -> client coords)\r\n        function fireMouse(type, pageXPos, pageYPos, delay) {\r\n            setTimeout(function(){\r\n                var clientX = pageXPos - (window.pageXOffset || document.documentElement.scrollLeft || 0);\r\n                var clientY = pageYPos - (window.pageYOffset || document.documentElement.scrollTop || 0);\r\n                var evt = new MouseEvent(type, {\r\n                    bubbles: true,\r\n                    cancelable: true,\r\n                    clientX: clientX,\r\n                    clientY: clientY,\r\n                    view: window,\r\n                    button: 0\r\n                });\r\n                // Try dispatch on element; fallback to document.elementFromPoint\r\n                try {\r\n                    el.dispatchEvent(evt);\r\n                } catch(e) {\r\n                    var target = document.elementFromPoint(clientX, clientY);\r\n                    if (target) target.dispatchEvent(evt);\r\n                }\r\n            }, delay);\r\n        }\r\n\r\n        function scheduleMouseEvents() {\r\n            var baseDelay = Math.floor(40 + Math.random()*90); // 40-130ms after animation end\r\n\r\n            // Slight offsets to make events more human (relative small jitter)\r\n            var jitterX = (Math.random()*6 - 3);\r\n            var jitterY = (Math.random()*6 - 3);\r\n            var px = clickX + jitterX;\r\n            var py = clickY + jitterY;\r\n\r\n            fireMouse('mousemove', px-3, py-3, baseDelay);\r\n            fireMouse('mouseover', px, py, baseDelay + 60);\r\n            fireMouse('mousemove', px, py, baseDelay + 120);\r\n            fireMouse('mousedown', px, py, baseDelay + 180);\r\n            fireMouse('mouseup', px, py, baseDelay + 220 + Math.floor(Math.random()*80));\r\n            fireMouse('click', px, py, baseDelay + 250 + Math.floor(Math.random()*120));\r\n\r\n            // remove bubble after a short delay once events fired\r\n            setTimeout(function(){\r\n                if (bubble && bubble.parentNode) {\r\n                    bubble.parentNode.removeChild(bubble);\r\n                }\r\n            }, baseDelay + 700 + Math.floor(Math.random()*300));\r\n        }\r\n\r\n        // Start the animation\r\n        window.requestAnimationFrame(step);\r\n\r\n        // Safety: remove bubble if it lingers too long (2.5s)\r\n        setTimeout(function(){\r\n            if (bubble && bubble.parentNode) {\r\n                bubble.parentNode.removeChild(bubble);\r\n            }\r\n        }, 2500);\r\n\r\n        return true;\r\n    })(arguments[0]);\r\n    ";
		string script = text;
		try
		{
			((IJavaScriptExecutor)driver).ExecuteScript(script, new object[1] { webElement2 });
		}
		catch (Exception)
		{
			try
			{
				new Actions(driver).MoveToElement(webElement2).Pause(TimeSpan.FromMilliseconds(random.Next(200, 450))).Click()
					.Perform();
			}
			catch
			{
			}
		}
		Thread.Sleep(random.Next(300, 600));
	}

	internal void HumanClickButton1(UndetectedChromeDriver driver, By locator, int timeoutSeconds = 20)
	{
		Random random = new Random();
		IWebElement webElement2 = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds)).Until(delegate(IWebDriver drv)
		{
			try
			{
				IWebElement webElement = drv.FindElement(locator);
				return (!webElement.Displayed || !webElement.Enabled) ? null : webElement;
			}
			catch
			{
				return (IWebElement?)null;
			}
		});
		string text = "\r\n(function(el){\r\n    try {\r\n        if(!el) return 'no-element';\r\n\r\n        var rect = el.getBoundingClientRect();\r\n        if (!rect || rect.width === 0 || rect.height === 0) return 'bad-rect';\r\n\r\n        var pageX = window.pageXOffset || document.documentElement.scrollLeft || 0;\r\n        var pageY = window.pageYOffset || document.documentElement.scrollTop || 0;\r\n\r\n        var clickX = rect.left + rect.width * (0.25 + Math.random() * 0.5) + pageX;\r\n        var clickY = rect.top + rect.height * (0.35 + Math.random() * 0.4) + pageY;\r\n\r\n        // choose start a bit away\r\n        var startX = rect.left - 40 + (Math.random() * (rect.width + 80)) + pageX;\r\n        var startY = rect.top - 100 + (Math.random() * 60) + pageY;\r\n\r\n        // helper to create overlay element\r\n        function makeElem(styleObj){\r\n            var d = document.createElement('div');\r\n            Object.keys(styleObj).forEach(function(k){ d.style[k] = styleObj[k]; });\r\n            d.setAttribute('data-human-cursor','1');\r\n            return d;\r\n        }\r\n\r\n        // Clean up any previous leftover\r\n        try {\r\n            var prevs = document.querySelectorAll('[data-human-cursor]');\r\n            for(var i=0;i<prevs.length;i++){ prevs[i].parentNode.removeChild(prevs[i]); }\r\n        } catch(e){ /* ignore */ }\r\n\r\n        // We'll attempt two styles: circle then arrow. Prefer circle.\r\n        var useCircle = true;\r\n        // But if CSS clip-path is unsupported, prefer circle (safe). We'll still create arrow fallback.\r\n\r\n        // Create circle first (safe)\r\n        var circle = makeElem({\r\n            position: 'fixed',\r\n            left: '0px',\r\n            top: '0px',\r\n            width: (12 + Math.floor(Math.random()*10)) + 'px',\r\n            height: (12 + Math.floor(Math.random()*10)) + 'px',\r\n            borderRadius: '50%',\r\n            background: 'rgba(0,0,0,0.65)',\r\n            boxShadow: '0 0 6px rgba(0,0,0,0.25)',\r\n            zIndex: '2147483647',\r\n            pointerEvents: 'none',\r\n            transform: 'translate3d(' + Math.round(startX) + 'px,' + Math.round(startY) + 'px,0)',\r\n            transition: 'none',\r\n            willChange: 'transform, opacity'\r\n        });\r\n\r\n        document.body.appendChild(circle);\r\n\r\n        // Animation params\r\n        var duration = 300 + Math.floor(Math.random()*400);\r\n        var started = null;\r\n\r\n        function animateTo(elem, sx, sy, tx, ty, cb) {\r\n            var start = null;\r\n            function step(ts){\r\n                if (!start) start = ts;\r\n                var t = Math.min(1, (ts - start) / duration);\r\n                var ease = 1 - Math.pow(1 - t, 3);\r\n                var curX = sx + (tx - sx) * ease;\r\n                var curY = sy + (ty - sy) * ease;\r\n                elem.style.transform = 'translate3d(' + Math.round(curX) + 'px,' + Math.round(curY) + 'px,0)';\r\n                if (t < 1) {\r\n                    window.requestAnimationFrame(step);\r\n                } else {\r\n                    if (cb) cb();\r\n                }\r\n            }\r\n            window.requestAnimationFrame(step);\r\n        }\r\n\r\n        function dispatchMouse(type, pageXPos, pageYPos) {\r\n            var clientX = pageXPos - (window.pageXOffset || document.documentElement.scrollLeft || 0);\r\n            var clientY = pageYPos - (window.pageYOffset || document.documentElement.scrollTop || 0);\r\n            var evt = new MouseEvent(type, {\r\n                bubbles: true,\r\n                cancelable: true,\r\n                clientX: clientX,\r\n                clientY: clientY,\r\n                view: window,\r\n                button: 0\r\n            });\r\n            try {\r\n                el.dispatchEvent(evt);\r\n            } catch(e) {\r\n                var tgt = document.elementFromPoint(clientX, clientY);\r\n                if (tgt) tgt.dispatchEvent(evt);\r\n            }\r\n        }\r\n\r\n        function scheduleEvents(px, py) {\r\n            var base = Math.floor(40 + Math.random()*90);\r\n            var jitterX = (Math.random()*6 - 3);\r\n            var jitterY = (Math.random()*6 - 3);\r\n            var px2 = px + jitterX;\r\n            var py2 = py + jitterY;\r\n\r\n            setTimeout(function(){ dispatchMouse('mousemove', px2-3, py2-3); }, base);\r\n            setTimeout(function(){ dispatchMouse('mouseover', px2, py2); }, base+60);\r\n            setTimeout(function(){ dispatchMouse('mousemove', px2, py2); }, base+120);\r\n            setTimeout(function(){ dispatchMouse('mousedown', px2, py2); }, base+180);\r\n            setTimeout(function(){ dispatchMouse('mouseup', px2, py2); }, base+220 + Math.floor(Math.random()*80));\r\n            setTimeout(function(){ dispatchMouse('click', px2, py2); }, base+250 + Math.floor(Math.random()*120));\r\n        }\r\n\r\n        // Start circle animation -> when done, schedule events then remove element\r\n        animateTo(circle, startX, startY, clickX, clickY, function(){\r\n            // small scale bounce\r\n            circle.style.transition = 'transform 120ms ease';\r\n            circle.style.transform = 'translate3d(' + Math.round(clickX) + 'px,' + Math.round(clickY) + 'px,0) scale(0.92)';\r\n            setTimeout(function(){ circle.style.transform = 'translate3d(' + Math.round(clickX) + 'px,' + Math.round(clickY) + 'px,0) scale(1)'; }, 120);\r\n\r\n            scheduleEvents(clickX, clickY);\r\n\r\n            setTimeout(function(){\r\n                try { if (circle && circle.parentNode) circle.parentNode.removeChild(circle); } catch(e) {}\r\n            }, 700 + Math.floor(Math.random()*300));\r\n        });\r\n\r\n        // Safety: if circle gets removed or doesn't render (some pages), create arrow fallback after short delay\r\n        setTimeout(function(){\r\n            if (!document.body.contains(circle)) return;\r\n            // If circle exists but page styles hide it (computed size 0), create arrow fallback too\r\n            var cs = window.getComputedStyle(circle);\r\n            if (!cs || cs.display === 'none' || parseFloat(cs.opacity) === 0) {\r\n                // remove circle if invisible\r\n                try { if (circle && circle.parentNode) circle.parentNode.removeChild(circle); } catch(e){}\r\n                // create arrow fallback\r\n                var arrow = makeElem({\r\n                    position: 'fixed',\r\n                    left: '0px',\r\n                    top: '0px',\r\n                    width: '16px',\r\n                    height: '24px',\r\n                    zIndex: '2147483647',\r\n                    pointerEvents: 'none',\r\n                    background: 'black',\r\n                    clipPath: 'polygon(0 0, 100% 50%, 0 100%, 22% 62%, 22% 38%)',\r\n                    transform: 'translate3d(' + Math.round(startX) + 'px,' + Math.round(startY) + 'px,0) rotate(-15deg)',\r\n                    willChange: 'transform',\r\n                    transition: 'none'\r\n                });\r\n                document.body.appendChild(arrow);\r\n                animateTo(arrow, startX, startY, clickX, clickY, function(){\r\n                    scheduleEvents(clickX, clickY);\r\n                    setTimeout(function(){ try{ if(arrow && arrow.parentNode) arrow.parentNode.removeChild(arrow); }catch(e){} }, 800);\r\n                });\r\n            }\r\n        }, 120);\r\n\r\n        // Safety removal after 3s\r\n        setTimeout(function(){\r\n            try {\r\n                var nodes = document.querySelectorAll('[data-human-cursor]');\r\n                for(var i=0;i<nodes.length;i++){ if(nodes[i] && nodes[i].parentNode) nodes[i].parentNode.removeChild(nodes[i]); }\r\n            } catch(e) {}\r\n        }, 3000);\r\n\r\n        return 'ok';\r\n    } catch(err) {\r\n        return 'js-err: ' + (err && err.message ? err.message : String(err));\r\n    }\r\n})(arguments[0]);\r\n";
		string script = text;
		try
		{
			object obj2 = ((IJavaScriptExecutor)driver).ExecuteScript(script, new object[1] { webElement2 });
			string text2 = "HumanClickButton JS result: ";
			object obj3 = obj2;
			if (obj3 == null)
			{
				string text3 = "null";
				obj3 = text3;
				if (obj3 != null)
				{
					goto IL_0092;
				}
			}
			else if (obj3 != null)
			{
				goto IL_0092;
			}
			object obj4 = null;
			goto IL_009d;
			IL_009d:
			Console.WriteLine(text2 + (string)obj4);
			goto end_IL_003c;
			IL_0092:
			obj4 = obj3.ToString();
			goto IL_009d;
			end_IL_003c:;
		}
		catch (Exception ex)
		{
			string text4 = "HumanClickButton JS error: ";
			Console.WriteLine(text4 + ex.Message);
			try
			{
				new Actions(driver).MoveToElement(webElement2).Pause(TimeSpan.FromMilliseconds(random.Next(200, 450))).Click()
					.Perform();
			}
			catch (Exception)
			{
			}
		}
		Thread.Sleep(random.Next(300, 600));
	}

	internal void TypeHumanLike(UndetectedChromeDriver driver, IWebElement element, string text)
	{
		Actions actions = new Actions(driver);
		Dictionary<char, char> dictionary = new Dictionary<char, char>
		{
			{ '!', '1' },
			{ '@', '2' },
			{ '#', '3' },
			{ '$', '4' },
			{ '%', '5' },
			{ '^', '6' },
			{ '&', '7' },
			{ '*', '8' },
			{ '(', '9' },
			{ ')', '0' },
			{ '_', '-' },
			{ '+', '=' },
			{ '{', '[' },
			{ '}', ']' },
			{ '|', '\\' },
			{ ':', ';' },
			{ '"', '\'' },
			{ '<', ',' },
			{ '>', '.' },
			{ '?', '/' }
		};
		element.Click();
		Thread.Sleep(200);
		Random random = new Random();
		for (int i = 0; i < text.Length; i++)
		{
			char c = text[i];
			actions = new Actions(driver);
			if (!char.IsUpper(c))
			{
				if (dictionary.ContainsKey(c))
				{
					char c2 = dictionary[c];
					actions.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(c2.ToString()).KeyUp(OpenQA.Selenium.Keys.Shift);
				}
				else
				{
					actions.SendKeys(c.ToString());
				}
			}
			else
			{
				actions.KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(c.ToString().ToUpper()).KeyUp(OpenQA.Selenium.Keys.Shift);
			}
			actions.Perform();
			Thread.Sleep(random.Next(80, 200));
		}
	}

	internal void ShowPointerLabel(IWebDriver driver, IWebElement element, string message)
	{
		string text = "\r\n        (function(el, msg) {\r\n            try {\r\n                var old = document.getElementById('selenium-tip');\r\n                if (old) old.remove();\r\n\r\n                var zoom = 0.60; // ⭐ your zoom = 60%\r\n                var rect = el.getBoundingClientRect();\r\n\r\n                var bubbleWidth = 420;\r\n                var bubbleHeight = 65;\r\n\r\n                // ⭐ UNZOOM coordinates (corrected)\r\n                var realLeft = (rect.left + (rect.width / 2) - (bubbleWidth / 2)) / zoom;\r\n                var realTop  = (rect.top  - bubbleHeight - 20) / zoom;  // 20px above button\r\n\r\n                var div = document.createElement('div');\r\n                div.id = 'selenium-tip';\r\n                div.innerHTML = msg;\r\n\r\n                div.style.position = 'absolute';\r\n                div.style.left = realLeft + 'px';\r\n                div.style.top  = realTop + 'px';\r\n\r\n                div.style.width = bubbleWidth + 'px';\r\n                div.style.textAlign = 'center';\r\n                div.style.padding = '10px';\r\n                div.style.background = '#FFF200';\r\n                div.style.border = '3px solid black';\r\n                div.style.borderRadius = '6px';\r\n                div.style.fontSize = '32px';\r\n                div.style.color = 'black';\r\n                div.style.fontWeight = '700';\r\n                div.style.fontFamily = 'Segoe UI, sans-serif';\r\n                div.style.zIndex = '999999999';\r\n                div.style.boxShadow = '0 4px 12px rgba(0,0,0,0.25)';\r\n\r\n                // ⭐ ARROW under tooltip\r\n                var arrow = document.createElement('div');\r\n                arrow.style.position = 'absolute';\r\n                arrow.style.left = ((bubbleWidth / 2) - 35) + 'px';\r\n                arrow.style.top = '100%';\r\n                arrow.style.width = '0';\r\n                arrow.style.height = '0';\r\n                arrow.style.borderLeft = '35px solid transparent';\r\n                arrow.style.borderRight = '35px solid transparent';\r\n                arrow.style.borderTop = '35px solid black';\r\n\r\n                var arrowFill = document.createElement('div');\r\n                arrowFill.style.position = 'absolute';\r\n                arrowFill.style.left = '-33px';\r\n                arrowFill.style.top = '-33px';\r\n                arrowFill.style.width = '0';\r\n                arrowFill.style.height = '0';\r\n                arrowFill.style.borderLeft = '33px solid transparent';\r\n                arrowFill.style.borderRight = '33px solid transparent';\r\n                arrowFill.style.borderTop = '33px solid #FFF200';\r\n\r\n                arrow.appendChild(arrowFill);\r\n                div.appendChild(arrow);\r\n\r\n                document.body.appendChild(div);\r\n\r\n            } catch(e){}\r\n        })(arguments[0], arguments[1]);\r\n    ";
		string script = text;
		((IJavaScriptExecutor)driver).ExecuteScript(script, element, message);
	}

	internal void TypeHumanLikeWithMousePath(UndetectedChromeDriver driver, IWebElement element, string text, double errorRate = 0.04, int minDelay = 60, int maxDelay = 220, double longPauseProbability = 0.04, double hoverProbability = 0.25, int pathStepsMin = 6, int pathStepsMax = 12)
	{
		Random random = new Random();
		string script = "arguments[0].scrollIntoView({block:'center', inline:'center'});";
		((IJavaScriptExecutor)driver).ExecuteScript(script, new object[1] { element });
		Thread.Sleep(SampleDelay(random, 120, 240));
		SimulateMousePathToElement(driver, element, random, pathStepsMin, pathStepsMax);
		if (random.NextDouble() < hoverProbability)
		{
			Thread.Sleep(SampleDelay(random, 200, 900));
		}
		DispatchMouseClick(driver, element, random);
		Thread.Sleep(SampleDelay(random, 80, 220));
		TypeHumanLikeAdvancedInternal(driver, element, text, errorRate, minDelay, maxDelay, longPauseProbability, random);
	}

	private void TypeHumanLikeAdvancedInternal(UndetectedChromeDriver driver, IWebElement element, string text, double errorRate, int minDelay, int maxDelay, double longPauseProbability, Random rng)
	{
		Dictionary<char, char> shiftChars = new Dictionary<char, char>
		{
			{ '!', '1' },
			{ '@', '2' },
			{ '#', '3' },
			{ '$', '4' },
			{ '%', '5' },
			{ '^', '6' },
			{ '&', '7' },
			{ '*', '8' },
			{ '(', '9' },
			{ ')', '0' },
			{ '_', '-' },
			{ '+', '=' },
			{ '{', '[' },
			{ '}', ']' },
			{ '|', '\\' },
			{ ':', ';' },
			{ '"', '\'' },
			{ '<', ',' },
			{ '>', '.' },
			{ '?', '/' }
		};
		try
		{
			element.Click();
		}
		catch
		{
		}
		Thread.Sleep(SampleDelay(rng, minDelay / 2, minDelay + 50));
		foreach (char c in text)
		{
			if (rng.NextDouble() < longPauseProbability)
			{
				Thread.Sleep(SampleDelay(rng, 350, 900));
			}
			if (rng.NextDouble() < errorRate && !char.IsWhiteSpace(c))
			{
				char c2 = RandomNearbyChar(c, rng);
				SendChar(driver, element, c2, shiftChars, rng);
				Thread.Sleep(SampleDelay(rng, minDelay, maxDelay / 2));
				new Actions(driver).SendKeys(OpenQA.Selenium.Keys.Backspace).Perform();
				Thread.Sleep(SampleDelay(rng, 80, 200));
			}
			SendChar(driver, element, c, shiftChars, rng);
			Thread.Sleep(SampleDelay(rng, minDelay, maxDelay));
		}
		Thread.Sleep(SampleDelay(rng, 80, 250));
	}

	private void SimulateMousePathToElement(UndetectedChromeDriver driver, IWebElement element, Random rng, int pathStepsMin, int pathStepsMax)
	{
		int num = Math.Max(2, element.Size.Width);
		int num2 = Math.Max(2, element.Size.Height);
		int num3 = rng.Next(num / 6, Math.Max(num / 6 + 1, num - num / 6));
		int num4 = rng.Next(num2 / 6, Math.Max(num2 / 6 + 1, num2 - num2 / 6));
		int num5 = rng.Next(pathStepsMin, pathStepsMax + 1);
		List<Tuple<int, int>> list = new List<Tuple<int, int>>();
		int num6 = num3 + rng.Next(-Math.Max(60, num), -Math.Max(20, num / 4));
		int num7 = num4 + rng.Next(-Math.Max(60, num2), Math.Max(60, num2));
		for (int i = 0; i < num5; i++)
		{
			double t = (double)(i + 1) / (double)num5;
			double num8 = EaseInOut(t);
			int num9 = (int)Math.Round((double)num6 + num8 * (double)(num3 - num6));
			int num10 = (int)Math.Round((double)num7 + num8 * (double)(num4 - num7));
			num9 += rng.Next(-6, 7);
			num10 += rng.Next(-6, 7);
			list.Add(Tuple.Create(num9 - num / 2, num10 - num2 / 2));
		}
		Actions actions = new Actions(driver);
		foreach (Tuple<int, int> item in list)
		{
			actions.MoveToElement(element, item.Item1, item.Item2).Perform();
			DispatchMouseMoveAtElement(driver, element, item.Item1 + num / 2, item.Item2 + num2 / 2);
			Thread.Sleep(SampleDelay(rng, 35, 120));
			if (rng.NextDouble() < 0.18)
			{
				int offsetX = rng.Next(-3, 4);
				int offsetY = rng.Next(-3, 4);
				actions.MoveByOffset(offsetX, offsetY).Perform();
				Thread.Sleep(SampleDelay(rng, 12, 45));
			}
		}
	}

	private double EaseInOut(double t)
	{
		if (!(t < 0.5))
		{
			int num2;
			do
			{
				int[,,] array = new int[2, 5, 1]
				{
					{
						{ -1825730410 },
						{ 667451786 },
						{ -442773995 },
						{ 356369424 },
						{ -1333653145 }
					},
					{
						{ -1825730409 },
						{ -626160714 },
						{ -1713383183 },
						{ 290274032 },
						{ -624088694 }
					}
				};
				int num = array[1, 0, 0];
				num2 = num;
				if (num2 == -1825730409)
				{
					return -1.0 + (4.0 - 2.0 * t) * t;
				}
			}
			while (num2 == -1825730408);
		}
		return 2.0 * t * t;
	}

	private void DispatchMouseMoveAtElement(UndetectedChromeDriver driver, IWebElement element, int relativeX, int relativeY)
	{
		string text = "\r\n            var el = arguments[0];\r\n            var rx = arguments[1];\r\n            var ry = arguments[2];\r\n            var rect = el.getBoundingClientRect();\r\n            var ev = new MouseEvent('mousemove', {\r\n                view: window,\r\n                bubbles: true,\r\n                cancelable: true,\r\n                clientX: Math.round(rect.left + rx),\r\n                clientY: Math.round(rect.top + ry)\r\n            });\r\n            el.dispatchEvent(ev);\r\n        ";
		string script = text;
		try
		{
			((IJavaScriptExecutor)driver).ExecuteScript(script, new object[3] { element, relativeX, relativeY });
		}
		catch
		{
		}
	}

	private void DispatchMouseDownUp(UndetectedChromeDriver driver, IWebElement element)
	{
		string text = "\r\n            var el = arguments[0];\r\n            var rect = el.getBoundingClientRect();\r\n            function dispatch(type){\r\n                var ev = new MouseEvent(type, {view: window, bubbles:true, cancelable:true, clientX: rect.left + rect.width/2, clientY: rect.top + rect.height/2});\r\n                el.dispatchEvent(ev);\r\n            }\r\n            dispatch('mousedown'); dispatch('mouseup');\r\n        ";
		string script = text;
		try
		{
			((IJavaScriptExecutor)driver).ExecuteScript(script, new object[1] { element });
		}
		catch
		{
		}
	}

	private void DispatchMouseClick(UndetectedChromeDriver driver, IWebElement element, Random rng)
	{
		try
		{
			if (rng.NextDouble() < 0.35)
			{
				new Actions(driver).MoveToElement(element, rng.Next(-3, 4), rng.Next(-3, 4)).Perform();
				Thread.Sleep(SampleDelay(rng, 20, 80));
			}
			new Actions(driver).Click(element).Perform();
			Thread.Sleep(SampleDelay(rng, 40, 120));
			DispatchMouseDownUp(driver, element);
			string script = "arguments[0].dispatchEvent(new MouseEvent('click', {bubbles:true, cancelable:true}));";
			((IJavaScriptExecutor)driver).ExecuteScript(script, new object[1] { element });
			if (rng.NextDouble() < 0.06)
			{
				Thread.Sleep(SampleDelay(rng, 80, 160));
				new Actions(driver).DoubleClick(element).Perform();
			}
		}
		catch
		{
			try
			{
				string script2 = "arguments[0].click();";
				((IJavaScriptExecutor)driver).ExecuteScript(script2, new object[1] { element });
			}
			catch
			{
			}
		}
	}

	private void SendChar(UndetectedChromeDriver driver, IWebElement element, char c, Dictionary<char, char> shiftChars, Random rng)
	{
		bool flag = char.IsUpper(c) || shiftChars.ContainsKey(c);
		char c2 = c;
		if (shiftChars.ContainsKey(c))
		{
			c2 = shiftChars[c];
		}
		int num = rng.Next(0, 100);
		if (!flag || num >= 65)
		{
			if (flag && num < 85)
			{
				new Actions(driver).SendKeys(c.ToString()).Perform();
			}
			else
			{
				new Actions(driver).SendKeys(c2.ToString()).Perform();
			}
		}
		else
		{
			new Actions(driver).KeyDown(OpenQA.Selenium.Keys.Shift).SendKeys(c2.ToString()).KeyUp(OpenQA.Selenium.Keys.Shift)
				.Perform();
		}
	}

	private int SampleDelay(Random rng, int minMs, int maxMs)
	{
		if (minMs >= maxMs)
		{
			return minMs;
		}
		double d = 1.0 - rng.NextDouble();
		double num = 1.0 - rng.NextDouble();
		double num2 = Math.Sqrt(-2.0 * Math.Log(d)) * Math.Sin(Math.PI * 2.0 * num);
		double num3 = (double)(minMs + maxMs) / 2.0;
		double num4 = (double)(maxMs - minMs) / 6.0;
		double num5 = num3 + num4 * num2;
		if (num5 < (double)minMs)
		{
			num5 = minMs;
		}
		if (num5 > (double)maxMs)
		{
			num5 = maxMs;
		}
		return (int)Math.Round(num5);
	}

	private char RandomNearbyChar(char target, Random rng)
	{
		if (char.IsLetter(target))
		{
			string text = "abcdefghijklmnopqrstuvwxyz";
			string text2 = text;
			int num = text2.IndexOf(char.ToLower(target));
			if (num >= 0)
			{
				int num2 = rng.Next(-2, 3);
				int index = Math.Max(0, Math.Min(text2.Length - 1, num + num2));
				char c = text2[index];
				if (char.IsUpper(target) && rng.NextDouble() < 0.5)
				{
					c = char.ToUpper(c);
				}
				return c;
			}
		}
		if (!char.IsDigit(target))
		{
			string text3 = "abcdefghijklmnopqrstuvwxyz0123456789";
			string text4 = text3;
			return text4[rng.Next(0, text4.Length)];
		}
		int num3 = (int)char.GetNumericValue(target);
		int num4 = Math.Max(0, Math.Min(9, num3 + rng.Next(-2, 3)));
		return (char)(48 + num4);
	}

	internal void RealisticJsClick(IWebDriver driver, By by, int timeoutSec = 10)
	{
		IWebElement webElement = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSec)).Until((IWebDriver drv) => drv.FindElement(by));
		IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;
		string text = "\r\n            (function simulateHumanClick(el) {\r\n                if (!el) return;\r\n                const rect = el.getBoundingClientRect();\r\n                const x = rect.left + (rect.width / 2) + (Math.random() * 4 - 2);\r\n                const y = rect.top + (rect.height / 2) + (Math.random() * 4 - 2);\r\n\r\n                function fire(type) {\r\n                    const evt = new MouseEvent(type, {\r\n                        view: window,\r\n                        bubbles: true,\r\n                        cancelable: true,\r\n                        composed: true,\r\n                        clientX: x,\r\n                        clientY: y,\r\n                        screenX: x + window.screenX,\r\n                        screenY: y + window.screenY\r\n                    });\r\n                    el.dispatchEvent(evt);\r\n                }\r\n\r\n                fire('mouseover');\r\n                fire('mousemove');\r\n                fire('mousedown');\r\n                fire('mouseup');\r\n                fire('click');\r\n            })(arguments[0]);\r\n        ";
		string script = text;
		javaScriptExecutor.ExecuteScript(script, webElement);
	}

	internal void ClickIfExistsOrSkip(IWebDriver driver, By by, int searchTimeoutMs = 3000)
	{
		IWebElement webElement = null;
		DateTime dateTime = DateTime.UtcNow.AddMilliseconds(searchTimeoutMs);
		while (DateTime.UtcNow < dateTime)
		{
			try
			{
				webElement = driver.FindElements(by).FirstOrDefault((IWebElement e) => e.Displayed);
				if (webElement != null)
				{
					break;
				}
			}
			catch
			{
			}
			Thread.Sleep(100);
		}
		if (webElement != null)
		{
			try
			{
				IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;
				string text = "\r\n                    (function(el){\r\n                        try { el.scrollIntoView({block:'center', inline:'center'}); } catch(e){}\r\n                        const r = el.getBoundingClientRect();\r\n                        const x = r.left + r.width/2 + (Math.random()*4-2);\r\n                        const y = r.top  + r.height/2 + (Math.random()*4-2);\r\n                        function fire(t){\r\n                            el.dispatchEvent(new MouseEvent(t,{\r\n                                view: window, bubbles:true, cancelable:true, composed:true,\r\n                                clientX:x, clientY:y, screenX:x+window.screenX, screenY:y+window.screenY\r\n                            }));\r\n                        }\r\n                        fire('mouseover'); fire('mousemove'); fire('mousedown'); fire('mouseup'); fire('click');\r\n                    })(arguments[0]);";
				string script = text;
				javaScriptExecutor.ExecuteScript(script, webElement);
				return;
			}
			catch
			{
				try
				{
					webElement.Click();
					return;
				}
				catch
				{
					return;
				}
			}
		}
		Thread.Sleep(2000);
	}

	internal void ClickCloseButtonIfExists(UndetectedChromeDriver driver)
	{
		string xpathToFind = "//button[contains(@aria-label,'Last Transaction Detail') and contains(@aria-label,'Close')]";
		By by = By.XPath(xpathToFind);
		IWebElement webElement = null;
		for (DateTime dateTime = DateTime.UtcNow.AddMilliseconds(2000.0); DateTime.UtcNow < dateTime; Thread.Sleep(100))
		{
			try
			{
				webElement = driver.FindElements(by).FirstOrDefault((IWebElement e) => e.Displayed);
				if (webElement == null)
				{
					continue;
				}
			}
			catch
			{
				continue;
			}
			break;
		}
		if (webElement != null)
		{
			try
			{
				string text = "\r\n                    (function(el){\r\n                        try { el.scrollIntoView({block:'center', inline:'center'}); } catch(e){}\r\n                        const r = el.getBoundingClientRect();\r\n                        const x = r.left + r.width/2 + (Math.random()*4-2);\r\n                        const y = r.top  + r.height/2 + (Math.random()*4-2);\r\n                        function fire(t){\r\n                            el.dispatchEvent(new MouseEvent(t,{\r\n                                view: window, bubbles:true, cancelable:true, composed:true,\r\n                                clientX:x, clientY:y, screenX:x+window.screenX, screenY:y+window.screenY\r\n                            }));\r\n                        }\r\n                        fire('mouseover'); fire('mousemove'); fire('mousedown'); fire('mouseup'); fire('click');\r\n                    })(arguments[0]);\r\n                ";
				string script = text;
				((IJavaScriptExecutor)driver).ExecuteScript(script, new object[1] { webElement });
				return;
			}
			catch
			{
				try
				{
					webElement.Click();
					return;
				}
				catch
				{
					return;
				}
			}
		}
		Thread.Sleep(500);
	}

	internal void ClickIfTextExists(UndetectedChromeDriver driver, string textToClick, int timeoutMs = 2000)
	{
		if (string.IsNullOrWhiteSpace(textToClick))
		{
			return;
		}
		string text = "//span[normalize-space()='";
		string text2 = "']";
		By by = By.XPath(text + textToClick + text2);
		IWebElement webElement = null;
		DateTime dateTime = DateTime.UtcNow.AddMilliseconds(timeoutMs);
		while (DateTime.UtcNow < dateTime)
		{
			try
			{
				webElement = driver.FindElements(by).FirstOrDefault((IWebElement e) => e.Displayed);
				if (webElement != null)
				{
					break;
				}
			}
			catch
			{
			}
			Thread.Sleep(100);
		}
		if (webElement != null)
		{
			try
			{
				string text3 = "\r\n                    (function(el){\r\n                        try { el.scrollIntoView({block:'center', inline:'center'}); } catch(e){}\r\n                        const r = el.getBoundingClientRect();\r\n                        const x = r.left + r.width/2 + (Math.random()*4-2);\r\n                        const y = r.top  + r.height/2 + (Math.random()*4-2);\r\n                        function fire(t){\r\n                            el.dispatchEvent(new MouseEvent(t,{\r\n                                view: window, bubbles:true, cancelable:true, composed:true,\r\n                                clientX:x, clientY:y, screenX:x+window.screenX, screenY:y+window.screenY\r\n                            }));\r\n                        }\r\n                        fire('mouseover'); fire('mousemove'); fire('mousedown'); fire('mouseup'); fire('click');\r\n                    })(arguments[0]);\r\n                ";
				string script = text3;
				((IJavaScriptExecutor)driver).ExecuteScript(script, new object[1] { webElement });
				return;
			}
			catch
			{
				try
				{
					webElement.Click();
					return;
				}
				catch
				{
					return;
				}
			}
		}
		Thread.Sleep(200);
	}

	internal void ShowChromeMessage(UndetectedChromeDriver driver, string message)
	{
		string text = "\r\n        (function(msg){\r\n            try {\r\n                // Purana label remove\r\n                var old = document.getElementById('selenium-top-label');\r\n                if (old) old.remove();\r\n\r\n                var div = document.createElement('div');\r\n                div.id = 'selenium-top-label';\r\n                div.innerText = msg;\r\n\r\n                div.style.position = 'fixed';\r\n                div.style.top = '0';\r\n                div.style.left = '0';\r\n                div.style.width = '100%';\r\n                div.style.zIndex = '999999999';\r\n                div.style.background = '#212121';\r\n                div.style.color = 'white';\r\n                div.style.padding = '10px 15px';\r\n                div.style.fontSize = '38px';\r\n                div.style.fontFamily = 'Segoe UI, sans-serif';\r\n                div.style.textAlign = 'center';\r\n                div.style.boxShadow = '0 2px 8px rgba(0,0,0,0.25)';\r\n                div.style.opacity = '0';\r\n                div.style.transition = 'opacity 0.4s ease';\r\n\r\n                document.body.appendChild(div);\r\n\r\n                setTimeout(function(){\r\n                    div.style.opacity = '1';\r\n                }, 50);\r\n\r\n                // 5 second baad remove\r\n                setTimeout(function(){\r\n                    if(div) div.remove();\r\n                }, 15000);\r\n\r\n            } catch(e){ console.log(e); }\r\n        })(arguments[0]);\r\n    ";
		string script = text;
		((IJavaScriptExecutor)driver).ExecuteScript(script, new object[1] { message });
	}

	internal void TypeLikeHuman(UndetectedChromeDriver driver, By by, string text, int timeoutSeconds = 40)
	{
		Random random = new Random();
		IWebElement webElement = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds)).Until(ExpectedConditions.ElementIsVisible(by));
		string text2 = "\r\n            arguments[0].scrollIntoView({behavior: 'smooth', block: 'center'});\r\n        ";
		string script = text2;
		((IJavaScriptExecutor)driver).ExecuteScript(script, new object[1] { webElement });
		Thread.Sleep(random.Next(500, 900));
		string text3 = "\r\n            var el = arguments[0];\r\n            var rect = el.getBoundingClientRect();\r\n            var startX = Math.floor(Math.random() * window.innerWidth); \r\n            var startY = Math.floor(Math.random() * window.innerHeight); \r\n            var endX = rect.left + rect.width / 2;\r\n            var endY = rect.top + rect.height / 2;\r\n\r\n            function fire(type, x, y){\r\n                el.dispatchEvent(new MouseEvent(type,{\r\n                    bubbles:true,\r\n                    cancelable:true,\r\n                    view:window,\r\n                    clientX:x, clientY:y,\r\n                    screenX:window.screenX+x,\r\n                    screenY:window.screenY+y,\r\n                    button:0\r\n                }));\r\n            }\r\n\r\n            var steps = 20;\r\n            var cx = (startX + endX) / 2 + (Math.random()*50 - 25);\r\n            var cy = (startY + endY) / 2 + (Math.random()*50 - 25);\r\n\r\n            for (var i = 0; i <= steps; i++) {\r\n                var t = i / steps;\r\n                var x = Math.pow(1-t, 2) * startX + 2*(1-t)*t*cx + Math.pow(t,2)*endX;\r\n                var y = Math.pow(1-t, 2) * startY + 2*(1-t)*t*cy + Math.pow(t,2)*endY;\r\n                fire('mousemove', x, y);\r\n            }\r\n\r\n            fire('mousedown', endX, endY);\r\n            fire('mouseup', endX, endY);\r\n            fire('click', endX, endY);\r\n        ";
		string script2 = text3;
		((IJavaScriptExecutor)driver).ExecuteScript(script2, new object[1] { webElement });
		Thread.Sleep(random.Next(200, 400));
		string control = OpenQA.Selenium.Keys.Control;
		string text4 = "a";
		webElement.SendKeys(control + text4);
		Thread.Sleep(random.Next(100, 250));
		webElement.SendKeys(OpenQA.Selenium.Keys.Backspace);
		Thread.Sleep(random.Next(200, 350));
		for (int i = 0; i < text.Length; i++)
		{
			webElement.SendKeys(text[i].ToString());
			Thread.Sleep(random.Next(120, 280));
		}
	}

	internal void Past_LikeHuman(UndetectedChromeDriver driver, By by, string text, int timeoutSeconds = 40)
	{
		Random random = new Random();
		IWebElement webElement = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds)).Until(ExpectedConditions.ElementIsVisible(by));
		string text2 = "\r\n            arguments[0].scrollIntoView({behavior: 'smooth', block: 'center'});\r\n        ";
		string script = text2;
		((IJavaScriptExecutor)driver).ExecuteScript(script, new object[1] { webElement });
		Thread.Sleep(random.Next(500, 900));
		string text3 = "\r\n            var el = arguments[0];\r\n            var rect = el.getBoundingClientRect();\r\n            var startX = Math.floor(Math.random() * window.innerWidth); \r\n            var startY = Math.floor(Math.random() * window.innerHeight); \r\n            var endX = rect.left + rect.width / 2;\r\n            var endY = rect.top + rect.height / 2;\r\n\r\n            function fire(type, x, y){\r\n                el.dispatchEvent(new MouseEvent(type,{\r\n                    bubbles:true,\r\n                    cancelable:true,\r\n                    view:window,\r\n                    clientX:x, clientY:y,\r\n                    screenX:window.screenX+x,\r\n                    screenY:window.screenY+y,\r\n                    button:0\r\n                }));\r\n            }\r\n\r\n            var steps = 20;\r\n            var cx = (startX + endX) / 2 + (Math.random()*50 - 25);\r\n            var cy = (startY + endY) / 2 + (Math.random()*50 - 25);\r\n\r\n            for (var i = 0; i <= steps; i++) {\r\n                var t = i / steps;\r\n                var x = Math.pow(1-t, 2) * startX + 2*(1-t)*t*cx + Math.pow(t,2)*endX;\r\n                var y = Math.pow(1-t, 2) * startY + 2*(1-t)*t*cy + Math.pow(t,2)*endY;\r\n                fire('mousemove', x, y);\r\n            }\r\n\r\n            fire('mousedown', endX, endY);\r\n            fire('mouseup', endX, endY);\r\n            fire('click', endX, endY);\r\n        ";
		string script2 = text3;
		((IJavaScriptExecutor)driver).ExecuteScript(script2, new object[1] { webElement });
		Thread.Sleep(random.Next(200, 400));
		string control = OpenQA.Selenium.Keys.Control;
		string text4 = "a";
		webElement.SendKeys(control + text4);
		Thread.Sleep(random.Next(100, 250));
		webElement.SendKeys(OpenQA.Selenium.Keys.Backspace);
		Thread.Sleep(random.Next(200, 350));
		Clipboard.SetText(text);
		string control2 = OpenQA.Selenium.Keys.Control;
		string text5 = "v";
		webElement.SendKeys(control2 + text5);
	}

	internal void TypeLikeHuman_onclick(IWebDriver driver, By by, string text, int timeoutSeconds = 240)
	{
		Random random = new Random();
		WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
		IWebElement element = webDriverWait.Until(ExpectedConditions.ElementIsVisible(by));
		string text2 = "\r\n        arguments[0].scrollIntoView({behavior: 'smooth', block: 'center'});\r\n    ";
		string script = text2;
		((IJavaScriptExecutor)driver).ExecuteScript(script, element);
		Thread.Sleep(random.Next(500, 900));
		string text3 = "\r\n        var el = arguments[0];\r\n\r\n        // sirf ek hi baar listener lagao\r\n        if (!el.__clickListenerAttached) {\r\n            el.__userClicked = false;\r\n            el.addEventListener('mousedown', function(e) {\r\n                el.__userClicked = true;\r\n            });\r\n            el.__clickListenerAttached = true;\r\n        }\r\n    ";
		string script2 = text3;
		((IJavaScriptExecutor)driver).ExecuteScript(script2, element);
		webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
		webDriverWait.Until(delegate(IWebDriver d)
		{
			try
			{
				IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)d;
				string script3 = "return arguments[0].__userClicked === true;";
				return (bool?)javaScriptExecutor.ExecuteScript(script3, element) == true;
			}
			catch (StaleElementReferenceException)
			{
				return false;
			}
		});
		Thread.Sleep(random.Next(150, 300));
		IWebElement webElement = element;
		string control = OpenQA.Selenium.Keys.Control;
		string text4 = "a";
		webElement.SendKeys(control + text4);
		Thread.Sleep(random.Next(100, 250));
		element.SendKeys(OpenQA.Selenium.Keys.Backspace);
		Thread.Sleep(random.Next(200, 350));
		foreach (char c in text)
		{
			element.SendKeys(c.ToString());
			Thread.Sleep(random.Next(120, 280));
		}
	}

	internal void ClickByViewport(UndetectedChromeDriver driver, By locator, int timeoutMs = 8000)
	{
		WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeoutMs));
		Random random = new Random();
		IWebElement webElement2 = webDriverWait.Until(delegate(IWebDriver d)
		{
			try
			{
				IWebElement webElement = d.FindElement(locator);
				return (!webElement.Displayed || !webElement.Enabled) ? null : webElement;
			}
			catch
			{
				return (IWebElement?)null;
			}
		});
		if (webElement2 == null)
		{
			throw new NoSuchElementException(locator.ToString());
		}
		string script = "arguments[0].scrollIntoView({block:'center', inline:'center'});";
		((IJavaScriptExecutor)driver).ExecuteScript(script, new object[1] { webElement2 });
		Thread.Sleep(random.Next(80, 150));
		string script2 = "\r\n            const el = arguments[0];\r\n            const pad = 4;\r\n            const r = el.getBoundingClientRect();\r\n            const rx = Math.floor(Math.random() * Math.max(1, r.width  - 2*pad)) + pad;\r\n            const ry = Math.floor(Math.random() * Math.max(1, r.height - 2*pad)) + pad;\r\n            const cx = Math.floor(r.left + rx);\r\n            const cy = Math.floor(r.top  + ry);\r\n\r\n            // find the topmost node at that point\r\n            const top = document.elementFromPoint(cx, cy);\r\n            if (!top) return false;\r\n\r\n            // small hover chain\r\n            for (const type of ['mouseover','mousemove']) {\r\n              top.dispatchEvent(new MouseEvent(type,{bubbles:true,cancelable:true,clientX:cx,clientY:cy,view:window}));\r\n            }\r\n            // press & release\r\n            top.dispatchEvent(new MouseEvent('mousedown',{bubbles:true,cancelable:true,clientX:cx,clientY:cy,button:0,view:window}));\r\n            top.dispatchEvent(new MouseEvent('mouseup'  ,{bubbles:true,cancelable:true,clientX:cx,clientY:cy,button:0,view:window}));\r\n            // click\r\n            top.dispatchEvent(new MouseEvent('click'    ,{bubbles:true,cancelable:true,clientX:cx,clientY:cy,button:0,view:window}));\r\n\r\n            return true;\r\n        ";
		if (!(bool)((IJavaScriptExecutor)driver).ExecuteScript(script2, new object[1] { webElement2 }))
		{
			string message = "Viewport click failed (elementFromPoint null).";
			throw new WebDriverException(message);
		}
		Thread.Sleep(random.Next(120, 220));
	}

	internal bool AutocompleteTypeAndSelectFirst(UndetectedChromeDriver _driver, By inputBy, string text, int timeoutSeconds = 12)
	{
		InjectIfNeeded(_driver);
		WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutSeconds));
		Random random = new Random();
		try
		{
			IWebElement webElement = webDriverWait.Until(ExpectedConditions.ElementIsVisible(inputBy));
			if (webElement == null)
			{
				return false;
			}
			string script = "arguments[0].scrollIntoView({block:'center'});";
			((IJavaScriptExecutor)_driver).ExecuteScript(script, new object[1] { webElement });
			Thread.Sleep(random.Next(150, 350));
			string text2 = "\r\n                (function(el){\r\n                  function fire(type,x,y){\r\n                    var ev = new MouseEvent(type, { bubbles:true, cancelable:true, view:window, clientX: x, clientY: y, button:0});\r\n                    (document.elementFromPoint(x,y) || el).dispatchEvent(ev);\r\n                  }\r\n                  var rect = el.getBoundingClientRect();\r\n                  var endX = Math.round(rect.left + rect.width/2);\r\n                  var endY = Math.round(rect.top + rect.height/2);\r\n                  var startX = Math.floor(Math.random()*window.innerWidth);\r\n                  var startY = Math.floor(Math.random()*window.innerHeight);\r\n                  var cx = Math.round((startX + endX)/2 + (Math.random()*60 - 30));\r\n                  var cy = Math.round((startY + endY)/2 + (Math.random()*60 - 30));\r\n                  var steps = 12;\r\n                  for(var i=0;i<=steps;i++){\r\n                    var t = i/steps;\r\n                    var x = Math.round(Math.pow(1-t,2)*startX + 2*(1-t)*t*cx + Math.pow(t,2)*endX);\r\n                    var y = Math.round(Math.pow(1-t,2)*startY + 2*(1-t)*t*cy + Math.pow(t,2)*endY);\r\n                    fire('mousemove', x, y);\r\n                  }\r\n                  fire('mousedown', endX, endY);\r\n                  fire('mouseup', endX, endY);\r\n                  fire('click', endX, endY);\r\n                  return true;\r\n                })(arguments[0]);\r\n                ";
			string script2 = text2;
			try
			{
				((IJavaScriptExecutor)_driver).ExecuteScript(script2, new object[1] { webElement });
			}
			catch
			{
				try
				{
					webElement.Click();
				}
				catch
				{
				}
			}
			Thread.Sleep(random.Next(120, 260));
			try
			{
				string control = OpenQA.Selenium.Keys.Control;
				string text3 = "a";
				webElement.SendKeys(control + text3);
				Thread.Sleep(60);
				webElement.SendKeys(OpenQA.Selenium.Keys.Backspace);
			}
			catch
			{
			}
			Thread.Sleep(random.Next(80, 150));
			for (int i = 0; i < text.Length; i++)
			{
				webElement.SendKeys(text[i].ToString());
				string script3 = "arguments[0].dispatchEvent(new Event('input',{bubbles:true}));";
				((IJavaScriptExecutor)_driver).ExecuteScript(script3, new object[1] { webElement });
				Thread.Sleep(random.Next(60, 140));
			}
			string script4 = "arguments[0].focus(); arguments[0].dispatchEvent(new Event('input',{bubbles:true}));";
			((IJavaScriptExecutor)_driver).ExecuteScript(script4, new object[1] { webElement });
			Thread.Sleep(random.Next(160, 340));
			int num = 3;
			int num2 = 0;
			while (true)
			{
				if (num2 < num)
				{
					IWebElement webElement2 = null;
					DateTime dateTime = DateTime.UtcNow.AddSeconds(timeoutSeconds);
					while (DateTime.UtcNow < dateTime)
					{
						try
						{
							string attributeName = "aria-controls";
							string attribute = webElement.GetAttribute(attributeName);
							IWebElement webElement3 = null;
							if (!string.IsNullOrEmpty(attribute))
							{
								IWebElement webElement4 = _driver.FindElements(By.Id(attribute)).FirstOrDefault((IWebElement e) => e.Displayed);
								if (webElement4 != null)
								{
									webElement3 = webElement4;
								}
							}
							if (webElement3 == null)
							{
								string cssSelectorToFind = ".ui-autocomplete-items, .ui-autocomplete-panel, .p-autocomplete-panel, ul[role='listbox']";
								webElement3 = _driver.FindElements(By.CssSelector(cssSelectorToFind)).FirstOrDefault((IWebElement e) => e.Displayed);
							}
							if (webElement3 != null)
							{
								IWebElement webElement5 = webElement3;
								string cssSelectorToFind2 = "li[role='option'], li, [role='option'], .ui-autocomplete-item, .p-autocomplete-item";
								List<IWebElement> list = webElement5.FindElements(By.CssSelector(cssSelectorToFind2)).Where(delegate(IWebElement e)
								{
									if (e.Displayed)
									{
										while (true)
										{
											int[,,,,] array = new int[2, 5, 1, 1, 1]
											{
												{
													{ { { -1657755090 } } },
													{ { { -1157277550 } } },
													{ { { 82966551 } } },
													{ { { -541863166 } } },
													{ { { -1689194389 } } }
												},
												{
													{ { { -1657755091 } } },
													{ { { 254651824 } } },
													{ { { -1895857120 } } },
													{ { { 1569789202 } } },
													{ { { 1220032220 } } }
												}
											};
											switch (~(array[1, 0, 0, 0, 0] ^ 0x62CF55D0))
											{
											case 2:
												return SafeEnabled(e);
											case 0:
												continue;
											}
											break;
										}
									}
									return false;
								}).ToList();
								if (list.Count > 0)
								{
									webElement2 = list[0];
									break;
								}
							}
						}
						catch (StaleElementReferenceException)
						{
						}
						catch
						{
						}
						Thread.Sleep(120);
					}
					if (webElement2 == null)
					{
						Thread.Sleep(180);
						try
						{
							webElement.SendKeys(OpenQA.Selenium.Keys.ArrowDown);
							Thread.Sleep(120);
							webElement.SendKeys(OpenQA.Selenium.Keys.Enter);
						}
						catch
						{
						}
					}
					else
					{
						try
						{
							new Actions(_driver).MoveToElement(webElement2).Pause(TimeSpan.FromMilliseconds(random.Next(60, 160))).Click()
								.Perform();
						}
						catch
						{
							try
							{
								((IJavaScriptExecutor)_driver).ExecuteScript(script2, new object[1] { webElement2 });
							}
							catch
							{
								try
								{
									webElement.SendKeys(OpenQA.Selenium.Keys.ArrowDown);
									Thread.Sleep(80);
									webElement.SendKeys(OpenQA.Selenium.Keys.Enter);
									goto end_IL_039c;
								}
								catch
								{
									goto end_IL_039c;
								}
								end_IL_039c:;
							}
						}
					}
					Thread.Sleep(220);
					string text4 = "";
					try
					{
						string attributeName2 = "value";
						text4 = webElement.GetAttribute(attributeName2) ?? webElement.Text ?? "";
					}
					catch
					{
					}
					string text5 = "";
					try
					{
						string attributeName3 = "aria-activedescendant";
						text5 = webElement.GetAttribute(attributeName3) ?? "";
					}
					catch
					{
					}
					if (!string.IsNullOrEmpty(text4) && !text4.Equals(text, StringComparison.OrdinalIgnoreCase))
					{
						break;
					}
					if (!string.IsNullOrEmpty(text5))
					{
						try
						{
							if (_driver.FindElement(By.Id(text5)) != null)
							{
								return true;
							}
						}
						catch
						{
						}
					}
					try
					{
						webElement.SendKeys(OpenQA.Selenium.Keys.ArrowDown);
						Thread.Sleep(120);
						webElement.SendKeys(OpenQA.Selenium.Keys.Enter);
						Thread.Sleep(200);
						string attributeName4 = "value";
						text4 = webElement.GetAttribute(attributeName4) ?? "";
						if (!string.IsNullOrEmpty(text4) && !text4.Equals(text, StringComparison.OrdinalIgnoreCase))
						{
							return true;
						}
					}
					catch
					{
					}
					Thread.Sleep(300 + random.Next(0, 200));
					num2++;
					continue;
				}
				string value = "Autocomplete selection attempts exhausted.";
				Console.WriteLine(value);
				return false;
			}
			return true;
		}
		catch (WebDriverTimeoutException)
		{
			string value2 = "Timeout waiting for autocomplete.";
			Console.WriteLine(value2);
			return false;
		}
		catch (Exception ex3)
		{
			string text6 = "Error: ";
			Console.WriteLine(text6 + ex3.Message);
			return false;
		}
	}

	internal bool SelectDateFromPrimeNgCalendar(UndetectedChromeDriver driver, string calendarInputSelector, int day, int month, int year, int timeoutSeconds = 10)
	{
		DateTime target;
		try
		{
			target = new DateTime(year, month, day);
		}
		catch
		{
			string value = "Invalid date.";
			Console.WriteLine(value);
			return false;
		}
		IWebElement input = null;
		try
		{
			IWebElement webElement = driver.FindElement(By.CssSelector(calendarInputSelector));
			string tagName = webElement.TagName;
			string value2 = "input";
			if (tagName.Equals(value2, StringComparison.OrdinalIgnoreCase))
			{
				input = webElement;
			}
			else
			{
				string cssSelectorToFind = "input.ui-inputtext, input.p-inputtext, input";
				input = webElement.FindElement(By.CssSelector(cssSelectorToFind));
			}
		}
		catch
		{
			string text = "Calendar input not found for selector: ";
			Console.WriteLine(text + calendarInputSelector);
			return false;
		}
		UndetectedChromeDriver undetectedChromeDriver = driver;
		string script = "\r\n        var el = arguments[0], cb = arguments[arguments.length-1];\r\n        if(window.__humanMouse && window.__humanMouse.humanMoveAndLeftClick){\r\n            window.__humanMouse.humanMoveAndLeftClick(el).then(()=>cb(true)).catch(()=>cb(false));\r\n        } else { try { el.click(); cb(true); } catch(e){ cb(false); } }\r\n    ";
		((IJavaScriptExecutor)undetectedChromeDriver).ExecuteAsyncScript(script, new object[1] { input });
		WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
		Func<IWebElement> GetPanel = delegate
		{
			UndetectedChromeDriver undetectedChromeDriver2 = driver;
			string cssSelectorToFind2 = ".p-datepicker, .ui-datepicker";
			return undetectedChromeDriver2.FindElements(By.CssSelector(cssSelectorToFind2)).FirstOrDefault(delegate(IWebElement p)
			{
				try
				{
					return p.Displayed && p.Size.Height > 0 && p.Size.Width > 0;
				}
				catch
				{
					return false;
				}
			});
		};
		IWebElement panel = webDriverWait.Until((IWebDriver d) => GetPanel());
		if (panel != null)
		{
			Func<(int y, int m)> ReadMonthYear = delegate
			{
				IWebElement webElement2 = null;
				try
				{
					IWebElement webElement3 = panel;
					string cssSelectorToFind3 = ".p-datepicker-group .p-datepicker-title, .ui-datepicker-group .ui-datepicker-title, .p-datepicker-title, .ui-datepicker-title";
					webElement2 = webElement3.FindElement(By.CssSelector(cssSelectorToFind3));
				}
				catch
				{
				}
				string text2 = null;
				string text3 = null;
				try
				{
					IWebElement webElement4 = webElement2;
					string cssSelectorToFind4 = ".p-datepicker-month";
					text2 = webElement4.FindElement(By.CssSelector(cssSelectorToFind4)).Text.Trim();
					IWebElement webElement5 = webElement2;
					string cssSelectorToFind5 = ".p-datepicker-year";
					text3 = webElement5.FindElement(By.CssSelector(cssSelectorToFind5)).Text.Trim();
				}
				catch
				{
					try
					{
						IWebElement webElement6 = webElement2;
						string cssSelectorToFind6 = ".ui-datepicker-month";
						text2 = webElement6.FindElement(By.CssSelector(cssSelectorToFind6)).Text.Trim();
						IWebElement webElement7 = webElement2;
						string cssSelectorToFind7 = ".ui-datepicker-year";
						text3 = webElement7.FindElement(By.CssSelector(cssSelectorToFind7)).Text.Trim();
					}
					catch
					{
						string text4 = webElement2?.Text?.Trim();
						if (!string.IsNullOrEmpty(text4))
						{
							string[] array = text4.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
							if (array.Length >= 2)
							{
								text2 = array[0];
								text3 = array[1];
							}
						}
					}
				}
				string text5 = text2;
				string text6 = " ";
				string s = text5 + text6 + text3;
				string format = "MMMM yyyy";
				if (DateTime.TryParseExact(s, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var result))
				{
					return (y: result.Year, m: result.Month);
				}
				string text7 = text2;
				string text8 = " 1, ";
				if (!DateTime.TryParse(text7 + text8 + text3, out var result2))
				{
					string[] array2 = new string[5];
					string text9 = "Cannot parse month/year: '";
					array2[0] = text9;
					array2[1] = text2;
					string text10 = " ";
					array2[2] = text10;
					array2[3] = text3;
					string text11 = "'.";
					array2[4] = text11;
					throw new InvalidOperationException(string.Concat(array2));
				}
				return (y: result2.Year, m: result2.Month);
			};
			int num = 0;
			while (num++ < 48)
			{
				panel = GetPanel();
				(int, int) tuple = ReadMonthYear();
				if (tuple.Item1 == target.Year && tuple.Item2 == target.Month)
				{
					break;
				}
				bool flag = tuple.Item1 < target.Year || (tuple.Item1 == target.Year && tuple.Item2 < target.Month);
				string text12 = ".p-datepicker-next, .ui-datepicker-next";
				string text13 = text12;
				string text14 = ".p-datepicker-prev, .ui-datepicker-prev";
				string text15 = text14;
				panel.FindElement(By.CssSelector(flag ? text13 : text15)).Click();
				(int y, int m) before = tuple;
				webDriverWait.Until(delegate
				{
					try
					{
						panel = GetPanel();
						(int, int) tuple2 = ReadMonthYear();
						return tuple2.Item1 != before.y || tuple2.Item2 != before.m;
					}
					catch
					{
						return false;
					}
				});
			}
			panel = GetPanel();
			IWebElement webElement8 = panel;
			string text16 = ".//table[contains(@class,'datepicker-calendar') or contains(@class,'ui-datepicker-calendar')]//td[not(contains(@class,'p-disabled')) and not(contains(@class,'ui-state-disabled')) and not(contains(@class,'p-datepicker-other-month')) and not(contains(@class,'ui-datepicker-other-month'))]";
			string format2 = "//*[self::span or self::a][normalize-space(text())='{0}']";
			IWebElement webElement9 = webElement8.FindElements(By.XPath(text16 + string.Format(format2, target.Day))).FirstOrDefault();
			if (webElement9 != null)
			{
				UndetectedChromeDriver undetectedChromeDriver3 = driver;
				string script2 = "\r\n        var el = arguments[0], cb = arguments[arguments.length-1];\r\n        if(window.__humanMouse && window.__humanMouse.humanMoveAndLeftClick){\r\n            window.__humanMouse.humanMoveAndLeftClick(el).then(()=>cb(true)).catch(()=>cb(false));\r\n        } else { try { el.click(); cb(true); } catch(e){ cb(false); } }\r\n    ";
				((IJavaScriptExecutor)undetectedChromeDriver3).ExecuteAsyncScript(script2, new object[1] { webElement9 });
				try
				{
					ref DateTime reference = ref target;
					string text17 = "dd'/'MM'/'yyyy";
					string expected = reference.ToString(text17);
					IWebElement webElement10 = input;
					string attributeName = "value";
					string oldVal = webElement10.GetAttribute(attributeName);
					webDriverWait.Until(delegate
					{
						try
						{
							IWebElement webElement11 = input;
							string attributeName2 = "value";
							string text18 = webElement11.GetAttribute(attributeName2) ?? "";
							int num2;
							if (text18 != oldVal)
							{
								ref DateTime reference2 = ref target;
								string text19 = "dd'/'MM'/'yy";
								num2 = ((text18.Contains(reference2.ToString(text19)) || text18.Contains(expected)) ? 1 : 0);
							}
							else
							{
								num2 = 0;
							}
							return (byte)num2 != 0;
						}
						catch (StaleElementReferenceException)
						{
							return true;
						}
					});
				}
				catch
				{
				}
				return true;
			}
			string value3 = "Day not found or disabled in this month (PrimeNG).";
			Console.WriteLine(value3);
			return false;
		}
		string value4 = "Datepicker panel not visible.";
		Console.WriteLine(value4);
		return false;
	}

	internal bool SelectDropdownOptionByMouse(UndetectedChromeDriver _driver, string dropdownSelector, string optionText, int timeoutSeconds = 8)
	{
		InjectIfNeeded(_driver);
		Random random = new Random();
		try
		{
			IWebElement webElement = null;
			try
			{
				webElement = FindBestInput(_driver, dropdownSelector);
			}
			catch
			{
				webElement = null;
			}
			if (webElement != null)
			{
				string tagName = webElement.TagName;
				string value = "input";
				if (tagName.Equals(value, StringComparison.OrdinalIgnoreCase))
				{
					try
					{
						IWebElement webElement2 = webElement;
						string xpathToFind = "ancestor::p-dropdown | ancestor::div[contains(@class,'ui-dropdown')]";
						IWebElement webElement3 = webElement2.FindElement(By.XPath(xpathToFind));
						if (webElement3 != null)
						{
							webElement = webElement3;
						}
					}
					catch
					{
					}
				}
			}
			if (webElement == null)
			{
				try
				{
					webElement = _driver.FindElement(By.CssSelector(dropdownSelector));
				}
				catch
				{
				}
			}
			if (webElement == null)
			{
				string text = "SelectDropdownOptionByMouse: dropdown wrapper not found for selector: ";
				Console.WriteLine(text + dropdownSelector);
				return false;
			}
			IWebElement webElement4 = null;
			try
			{
				IWebElement webElement5 = webElement;
				string cssSelectorToFind = ".ui-dropdown-trigger, .ui-dropdown-label-container, .ui-dropdown";
				webElement4 = webElement5.FindElements(By.CssSelector(cssSelectorToFind)).FirstOrDefault((IWebElement e) => e.Displayed);
			}
			catch
			{
			}
			if (webElement4 == null)
			{
				try
				{
					IWebElement webElement6 = webElement;
					string cssSelectorToFind2 = "div,span,button";
					webElement4 = webElement6.FindElements(By.CssSelector(cssSelectorToFind2)).FirstOrDefault(delegate(IWebElement e)
					{
						if (e.Displayed)
						{
							string attributeName = "role";
							string attribute = e.GetAttribute(attributeName);
							string text2 = "button";
							if (!(attribute == text2))
							{
								string attributeName2 = "class";
								string attribute2 = e.GetAttribute(attributeName2);
								if (attribute2 == null)
								{
									return false;
								}
								string value2 = "trigger";
								return attribute2.Contains(value2);
							}
							return true;
						}
						return false;
					});
				}
				catch
				{
				}
			}
			if (webElement4 == null)
			{
				webElement4 = webElement;
			}
			try
			{
				string script = "\r\nvar el = arguments[0], cb = arguments[arguments.length-1];\r\nif(window.__humanMouse && window.__humanMouse.humanMoveAndLeftClick){\r\n    window.__humanMouse.humanMoveAndLeftClick(el).then(()=>cb(true)).catch(()=>cb(false));\r\n}else{ try{ el.click(); cb(true);}catch(e){cb(false);} }";
				((IJavaScriptExecutor)_driver).ExecuteAsyncScript(script, new object[1] { webElement4 });
			}
			catch
			{
				try
				{
					webElement4.Click();
				}
				catch
				{
				}
			}
			Thread.Sleep(random.Next(180, 300));
			WebDriverWait webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutSeconds));
			IWebElement webElement7 = null;
			try
			{
				webElement7 = webDriverWait.Until(delegate(IWebDriver d)
				{
					string[] array = new string[4];
					string text3 = ".ui-dropdown-panel";
					array[0] = text3;
					string text4 = ".ui-dropdown-items-wrapper";
					array[1] = text4;
					string text5 = ".ui-dropdown-list";
					array[2] = text5;
					string text6 = ".ui-dropdown-panel.ui-widget";
					array[3] = text6;
					string[] array2 = array;
					string[] array3 = array2;
					string[] array4 = array3;
					foreach (string cssSelectorToFind3 in array4)
					{
						try
						{
							IWebElement webElement8 = d.FindElements(By.CssSelector(cssSelectorToFind3)).FirstOrDefault((IWebElement x) => x.Displayed);
							if (webElement8 != null)
							{
								return webElement8;
							}
						}
						catch
						{
						}
					}
					try
					{
						string cssSelectorToFind4 = "ul[role='listbox'], ul.ui-dropdown-items";
						IWebElement webElement9 = d.FindElements(By.CssSelector(cssSelectorToFind4)).FirstOrDefault((IWebElement x) => x.Displayed);
						if (webElement9 != null)
						{
							return webElement9;
						}
					}
					catch
					{
					}
					return (IWebElement?)null;
				});
			}
			catch (WebDriverTimeoutException)
			{
				string value3 = "SelectDropdownOptionByMouse: dropdown panel did not appear.";
				Console.WriteLine(value3);
				return false;
			}
			if (webElement7 == null)
			{
				string value4 = "SelectDropdownOptionByMouse: panel null after wait.";
				Console.WriteLine(value4);
				return false;
			}
			IWebElement webElement10 = null;
			try
			{
				string[] array5 = new string[7];
				string text7 = ".//li[normalize-space(.) = \"";
				string text8 = "\"]";
				array5[0] = text7 + optionText + text8;
				string text9 = ".//li[.//span[normalize-space(.) = \"";
				string text10 = "\"]]";
				array5[1] = text9 + optionText + text10;
				string text11 = ".//li[contains(translate(., 'ABCDEFGHIJKLMNOPQRSTUVWXYZ','abcdefghijklmnopqrstuvwxyz'), '";
				string text12 = optionText.ToLower();
				string text13 = "')]";
				array5[2] = text11 + text12 + text13;
				string text14 = ".//*[(@role='option' or name() = 'li' or name() = 'p-dropdownitem') and normalize-space(.) = \"";
				string text15 = "\"]";
				array5[3] = text14 + optionText + text15;
				string text16 = ".//*[normalize-space(@aria-label) = \"";
				string text17 = "\"]";
				array5[4] = text16 + optionText + text17;
				string text18 = ".//span[normalize-space(.) = \"";
				string text19 = "\"]";
				array5[5] = text18 + optionText + text19;
				string text20 = ".//a[normalize-space(.) = \"";
				string text21 = "\"]";
				array5[6] = text20 + optionText + text21;
				string[] array6 = array5;
				string[] array7 = array6;
				string[] array8 = array7;
				foreach (string xpathToFind2 in array8)
				{
					try
					{
						IWebElement webElement11 = webElement7.FindElements(By.XPath(xpathToFind2)).FirstOrDefault((IWebElement e) => e.Displayed);
						if (webElement11 == null)
						{
							continue;
						}
						webElement10 = webElement11;
						break;
					}
					catch
					{
					}
				}
			}
			catch
			{
			}
			if (webElement10 == null)
			{
				try
				{
					IWebElement webElement12 = webElement7;
					string cssSelectorToFind5 = "li, .ui-dropdown-item, p-dropdownitem, [role='option']";
					foreach (IWebElement item in webElement12.FindElements(By.CssSelector(cssSelectorToFind5)))
					{
						try
						{
							string text22 = (item.Text ?? "").Trim();
							string attributeName3 = "aria-label";
							string a = (item.GetAttribute(attributeName3) ?? "").Trim();
							if (string.Equals(text22, optionText, StringComparison.OrdinalIgnoreCase) || string.Equals(a, optionText, StringComparison.OrdinalIgnoreCase) || text22.IndexOf(optionText, StringComparison.OrdinalIgnoreCase) >= 0)
							{
								webElement10 = item;
								break;
							}
						}
						catch
						{
						}
					}
				}
				catch
				{
				}
			}
			if (webElement10 == null)
			{
				string text23 = "SelectDropdownOptionByMouse: option '";
				string text24 = "' not found in panel.";
				Console.WriteLine(text23 + optionText + text24);
				return false;
			}
			try
			{
				string script2 = "\r\nvar el = arguments[0], cb = arguments[arguments.length-1];\r\nif(window.__humanMouse && window.__humanMouse.humanMoveAndLeftClick){\r\n    window.__humanMouse.humanMoveAndLeftClick(el).then(()=>cb(true)).catch(()=>cb(false));\r\n}else{ try{ el.click(); cb(true);}catch(e){cb(false);} }";
				((IJavaScriptExecutor)_driver).ExecuteAsyncScript(script2, new object[1] { webElement10 });
			}
			catch
			{
				try
				{
					webElement10.Click();
				}
				catch
				{
				}
			}
			Thread.Sleep(random.Next(120, 260));
			try
			{
				string script3 = "if(document.activeElement) document.activeElement.blur(); document.body.click();";
				((IJavaScriptExecutor)_driver).ExecuteScript(script3, Array.Empty<object>());
			}
			catch
			{
			}
			return true;
		}
		catch (Exception ex2)
		{
			string text25 = "SelectDropdownOptionByMouse error: ";
			Console.WriteLine(text25 + ex2);
			return false;
		}
	}

	private bool SafeEnabled(IWebElement el)
	{
		try
		{
			return el?.Enabled ?? false;
		}
		catch
		{
			return false;
		}
	}

	internal void ClickSleeperForTrain(UndetectedChromeDriver driver, string trainNumber, string coachType = "SL")
	{
		Random random = new Random();
		WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(20.0));
		try
		{
			coachType = ClassCodeToText(coachType);
			string[] array = new string[5];
			string text = "Searching for train ";
			array[0] = text;
			array[1] = trainNumber;
			string text2 = " and clicking ";
			array[2] = text2;
			array[3] = coachType;
			string text3 = "...";
			array[4] = text3;
			Console.WriteLine(string.Concat(array));
			webDriverWait.Until(delegate
			{
				UndetectedChromeDriver undetectedChromeDriver = driver;
				string script = "return document.readyState";
				object obj = ((IJavaScriptExecutor)undetectedChromeDriver).ExecuteScript(script, Array.Empty<object>());
				string obj2 = "complete";
				return obj.Equals(obj2);
			});
			IWebElement webElement = null;
			string[] array2 = new string[4];
			string text4 = "//app-train-avl-enq[.//strong[contains(., '";
			string text5 = "')]]";
			array2[0] = text4 + trainNumber + text5;
			string text6 = "//div[contains(@class, 'bull-back')][.//strong[contains(., '";
			string text7 = "')]]";
			array2[1] = text6 + trainNumber + text7;
			string text8 = "//*[contains(text(), '";
			string text9 = "')]/ancestor::app-train-avl-enq[1]";
			array2[2] = text8 + trainNumber + text9;
			string text10 = "//*[contains(text(), '(";
			string text11 = ")')]";
			array2[3] = text10 + trainNumber + text11;
			string[] array3 = array2;
			string[] array4 = array3;
			string[] array5 = array4;
			foreach (string text12 in array5)
			{
				try
				{
					webElement = driver.FindElement(By.XPath(text12));
					if (webElement == null || !webElement.Displayed)
					{
						continue;
					}
					string text13 = "Train found using: ";
					Console.WriteLine(text13 + text12);
					break;
				}
				catch
				{
				}
			}
			if (webElement == null)
			{
				string text14 = "Train ";
				string text15 = " not found on page";
				throw new Exception(text14 + trainNumber + text15);
			}
			UndetectedChromeDriver undetectedChromeDriver2 = driver;
			string script2 = "arguments[0].scrollIntoView({behavior: 'smooth', block: 'center'});";
			((IJavaScriptExecutor)undetectedChromeDriver2).ExecuteScript(script2, new object[1] { webElement });
			Thread.Sleep(random.Next(10, 50));
			IWebElement webElement2 = null;
			string[] array6 = new string[5];
			string text16 = ".//li[contains(@class, 'ui-tabmenuitem')]//strong//span[contains(@class, 'hidden-xs') and text()='";
			string text17 = coachType;
			string text18 = "']";
			array6[0] = text16 + text17 + text18;
			string text19 = ".//strong[contains(., '";
			string text20 = coachType;
			string text21 = "')]";
			array6[1] = text19 + text20 + text21;
			string text22 = ".//span[contains(text(), '";
			string text23 = coachType;
			string text24 = "')]";
			array6[2] = text22 + text23 + text24;
			string text25 = ".//*[contains(text(), '";
			string text26 = coachType.Split(' ')[0];
			string text27 = "')]";
			array6[3] = text25 + text26 + text27;
			string text28 = ".//li[contains(@class, 'ui-state-active')]//strong";
			array6[4] = text28;
			array3 = array6;
			string[] array7 = array3;
			string[] array8 = array7;
			foreach (string text29 in array8)
			{
				try
				{
					webElement2 = webElement.FindElement(By.XPath(text29));
					if (webElement2 != null && webElement2.Displayed)
					{
						string text30 = "Coach element found using: ";
						Console.WriteLine(text30 + text29);
						break;
					}
				}
				catch
				{
				}
			}
			if (webElement2 != null)
			{
				Thread.Sleep(random.Next(5, 10));
				webDriverWait.Until(ExpectedConditions.ElementToBeClickable(webElement2));
				new Actions(driver).MoveToElement(webElement2, random.Next(-10, 10), random.Next(-10, 10)).Perform();
				Thread.Sleep(random.Next(5, 10));
				try
				{
					new Actions(driver).MoveToElement(webElement2, random.Next(-10, 10), random.Next(-10, 10)).Click().Perform();
					return;
				}
				catch
				{
					try
					{
						UndetectedChromeDriver undetectedChromeDriver3 = driver;
						string script3 = "arguments[0].click();";
						((IJavaScriptExecutor)undetectedChromeDriver3).ExecuteScript(script3, new object[1] { webElement2 });
						return;
					}
					catch
					{
						webElement2.Click();
						return;
					}
				}
			}
			string text31 = "Coach type '";
			string text32 = coachType;
			string text33 = "' not found for train ";
			throw new Exception(text31 + text32 + text33 + trainNumber);
		}
		catch (Exception ex)
		{
			string[] array9 = new string[6];
			string text34 = "❌ Failed to click ";
			array9[0] = text34;
			array9[1] = coachType;
			string text35 = " for train ";
			array9[2] = text35;
			array9[3] = trainNumber;
			string text36 = ": ";
			array9[4] = text36;
			array9[5] = ex.Message;
			Console.WriteLine(string.Concat(array9));
			try
			{
				string pageSource = driver.PageSource;
				if (pageSource.Contains(trainNumber))
				{
					string value = "✓ Train number found in page source";
					Console.WriteLine(value);
				}
				else
				{
					string value2 = "✗ Train number NOT found in page source";
					Console.WriteLine(value2);
				}
				if (pageSource.Contains(coachType))
				{
					string text37 = "✓ ";
					string text38 = coachType;
					string text39 = " found in page source";
					Console.WriteLine(text37 + text38 + text39);
				}
				else
				{
					string text40 = "✗ ";
					string text41 = coachType;
					string text42 = " NOT found in page source";
					Console.WriteLine(text40 + text41 + text42);
				}
			}
			catch
			{
			}
		}
	}

	private void InjectIfNeeded(UndetectedChromeDriver driver)
	{
		if (!_injected)
		{
			string text = "\r\n(function(){\r\n    if (window.__humanMouse && window.__humanMouse.humanMoveAndLeftClick) return;\r\n    let lastMouse = { x: window.innerWidth/2, y: window.innerHeight/2 };\r\n    document.addEventListener('mousemove', e => { lastMouse.x = e.clientX; lastMouse.y = e.clientY; }, { passive:true });\r\n\r\n    function rand(min,max){ return Math.floor(Math.random()*(max-min+1))+min; }\r\n    function sleep(ms){ return new Promise(res=>setTimeout(res,ms)); }\r\n\r\n    function dispatchMouseEvent(el, type, clientX, clientY, button = 0) {\r\n        const ev = new MouseEvent(type, {\r\n            bubbles: true, cancelable: true, view: window,\r\n            clientX: clientX, clientY: clientY,\r\n            screenX: window.screenX + clientX, screenY: window.screenY + clientY,\r\n            button: button\r\n        });\r\n        const target = document.elementFromPoint(clientX,clientY) || el || document.body;\r\n        try { target.dispatchEvent(ev); } catch(e) { /* ignore */ }\r\n    }\r\n\r\n    function pathPoints(startX, startY, endX, endY, steps) {\r\n        const pts = [];\r\n        for (let i=1;i<=steps;i++){\r\n            const t = i/steps;\r\n            const ease = t*(2-t);\r\n            const x = Math.round(startX + (endX - startX)*ease + (Math.random()-0.5)*2);\r\n            const y = Math.round(startY + (endY - startY)*ease + (Math.random()-0.5)*2);\r\n            pts.push({x,y});\r\n        }\r\n        return pts;\r\n    }\r\n\r\n    async function humanMoveAndLeftClick(el, options = {}) {\r\n        if (!el) return;\r\n        const rect = el.getBoundingClientRect();\r\n        const targetX = options.x ?? Math.round(rect.left + rect.width*(0.3 + Math.random()*0.4));\r\n        const targetY = options.y ?? Math.round(rect.top + rect.height*(0.3 + Math.random()*0.4));\r\n        const startX = options.startX ?? lastMouse.x;\r\n        const startY = options.startY ?? lastMouse.y;\r\n        const steps = options.steps ?? Math.max(2, Math.floor(4 + Math.random()*6));\r\n        const pts = pathPoints(startX, startY, targetX, targetY, steps);\r\n        for (const p of pts) {\r\n            dispatchMouseEvent(el, 'mousemove', p.x, p.y);\r\n            await sleep(Math.floor(8 + Math.random()*22));\r\n        }\r\n        dispatchMouseEvent(el, 'mousemove', targetX + (Math.random()>0.5?1:-1), targetY + (Math.random()>0.5?1:-1));\r\n        await sleep(Math.floor(18 + Math.random()*40));\r\n        dispatchMouseEvent(el, 'mousedown', targetX, targetY, 0);\r\n        await sleep(Math.floor(40 + Math.random()*100));\r\n        dispatchMouseEvent(el, 'mouseup', targetX, targetY, 0);\r\n        dispatchMouseEvent(el, 'click', targetX, targetY, 0);\r\n    }\r\n\r\n    window.__humanMouse = {\r\n        humanMoveAndLeftClick: humanMoveAndLeftClick\r\n    };\r\n})();\r\n";
			string script = text;
			((IJavaScriptExecutor)driver).ExecuteScript(script, Array.Empty<object>());
			_injected = true;
		}
	}

	private IWebElement FindBestInput(UndetectedChromeDriver _driver, string inputSelector)
	{
		try
		{
			List<IWebElement> list = _driver.FindElements(By.CssSelector(inputSelector)).ToList().Where(delegate(IWebElement e)
			{
				if (e.Displayed)
				{
					while (true)
					{
						int[,] array = new int[2, 3]
						{
							{ -515822773, 2123582997, 1442708577 },
							{ 138280992, -1793180601, -1759830523 }
						};
						switch (array[1, 2] * -781133843)
						{
						case -511640159:
							return e.Enabled;
						case -511640161:
							continue;
						}
						break;
					}
				}
				return false;
			})
				.ToList();
			string text2;
			string value2;
			if (list.Count != 1)
			{
				string value = ExtractIdFromSelector(inputSelector);
				if (!string.IsNullOrEmpty(value))
				{
					foreach (IWebElement item in list)
					{
						try
						{
							string script = "var el = arguments[0]; var p = el.closest('p-autocomplete'); return p ? p.id : null;";
							string text = ((IJavaScriptExecutor)_driver).ExecuteScript(script, new object[1] { item }) as string;
							if (!string.IsNullOrEmpty(text) && text.Equals(value, StringComparison.OrdinalIgnoreCase))
							{
								return item;
							}
						}
						catch
						{
						}
					}
				}
				text2 = (inputSelector ?? "").ToLower();
				value2 = null;
				string value3 = "from";
				if (!text2.Contains(value3))
				{
					string value4 = "enter from";
					if (!text2.Contains(value4))
					{
						string value5 = "origin";
						if (!text2.Contains(value5))
						{
							goto IL_016c;
						}
					}
				}
				string text3 = "from";
				value2 = text3;
				goto IL_016c;
			}
			return list[0];
			IL_016c:
			string value6 = "to";
			if (!text2.Contains(value6))
			{
				string value7 = "enter to";
				if (!text2.Contains(value7))
				{
					string value8 = "destination";
					if (!text2.Contains(value8))
					{
						goto IL_01c6;
					}
				}
			}
			string text4 = "to";
			value2 = text4;
			goto IL_01c6;
			IL_01c6:
			if (!string.IsNullOrEmpty(value2))
			{
				foreach (IWebElement item2 in list)
				{
					try
					{
						string attributeName = "aria-label";
						if ((item2.GetAttribute(attributeName) ?? "").ToLower().Contains(value2))
						{
							return item2;
						}
					}
					catch
					{
					}
				}
			}
			if (list.Count > 1)
			{
				string script2 = "\r\n                    var els = arguments[0];\r\n                    var vw = window.innerWidth/2, vh = window.innerHeight/2;\r\n                    var best = {i:0,d:1e9};\r\n                    for(var i=0;i<els.length;i++){\r\n                      try{\r\n                        var r = els[i].getBoundingClientRect();\r\n                        var cx = r.left + r.width/2, cy = r.top + r.height/2;\r\n                        var d = Math.hypot(cx - vw, cy - vh);\r\n                        if(d < best.d){ best.d = d; best.i = i; }\r\n                      }catch(e){}\r\n                    }\r\n                    return best.i;\r\n                    ";
				object[] array2 = list.ToArray();
				object[] array3 = array2;
				object[] args = array3;
				object value9 = ((IJavaScriptExecutor)_driver).ExecuteScript(script2, args);
				try
				{
					int num = Convert.ToInt32(value9);
					if (num >= 0 && num < list.Count)
					{
						return list[num];
					}
				}
				catch
				{
				}
			}
			if (list.Count > 0)
			{
				return list[0];
			}
		}
		catch
		{
		}
		try
		{
			IWebElement webElement = _driver.FindElement(By.CssSelector(inputSelector));
			string cssSelectorToFind = "input";
			IWebElement webElement2 = webElement.FindElements(By.CssSelector(cssSelectorToFind)).FirstOrDefault(delegate(IWebElement e)
			{
				if (e.Displayed)
				{
					while (true)
					{
						int[,,,] array4 = new int[2, 1, 1, 5]
						{
							{ { { 945679198, -1896120466, -1953108622, -911466403, -1973187053 } } },
							{ { { 540038596, 1553009665, 945679197, -907121655, -1018614206 } } }
						};
						switch (array4[0, 0, 0, 0])
						{
						case 945679198:
							return e.Enabled;
						case 945679196:
							continue;
						}
						break;
					}
				}
				return false;
			});
			if (webElement2 != null)
			{
				return webElement2;
			}
		}
		catch
		{
		}
		return null;
	}

	private string ExtractIdFromSelector(string sel)
	{
		try
		{
			string[] array = sel.Split(new char[3] { ' ', ',', '>' }, StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i].Trim();
				int num = text.IndexOf('#');
				if (num >= 0)
				{
					string text2 = text.Substring(num + 1).Trim();
					int num2 = text2.IndexOfAny(new char[3] { '.', '[', ':' });
					if (num2 > 0)
					{
						text2 = text2.Substring(0, num2);
					}
					return text2;
				}
			}
		}
		catch
		{
		}
		return null;
	}

	internal void BookTrainClassOnDate(UndetectedChromeDriver driver, string trainNo, string classCode, DateTime journeyDate, bool bookOnly, int timeoutSec = 20)
	{
		try
		{
			WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSec));
			IWebElement train = webDriverWait.Until(delegate(IWebDriver d)
			{
				string cssSelectorToFind = "app-train-avl-enq";
				return d.FindElements(By.CssSelector(cssSelectorToFind)).FirstOrDefault((IWebElement x) => (x.Text ?? "").Contains(trainNo));
			});
			if (train != null)
			{
				string text = ClassCodeToText(classCode);
				if (!bookOnly)
				{
					IWebElement webElement = train;
					string text2 = ".//strong[normalize-space(text())='";
					string text3 = "']";
					if (webElement.FindElements(By.XPath(text2 + text + text3)).FirstOrDefault() == null)
					{
						string text4 = "Class ";
						string text5 = " not found for train ";
						throw new Exception(text4 + classCode + text5 + trainNo);
					}
					string[] array = new string[5];
					string text6 = ".//app-train-avl-enq[.//*[contains(normalize-space(),'";
					array[0] = text6;
					array[1] = trainNo;
					string text7 = "')]]//strong[normalize-space(text())='";
					array[2] = text7;
					array[3] = text;
					string text8 = "']";
					array[4] = text8;
					HumanClickButton(driver, By.XPath(string.Concat(array)));
				}
				webDriverWait.Until(delegate
				{
					IWebElement webElement2 = train;
					string cssSelectorToFind2 = "div[style*='overflow-x'] table";
					return webElement2.FindElements(By.CssSelector(cssSelectorToFind2)).FirstOrDefault();
				});
				string text9 = FormatIrctcTileLabel(journeyDate);
				if (TryClickDateTile(driver, train, text9, 12))
				{
					if (webDriverWait.Until(delegate
					{
						try
						{
							IWebElement webElement3 = train;
							string xpathToFind = ".//button[contains(.,'Book Now')]";
							return webElement3.FindElements(By.XPath(xpathToFind)).FirstOrDefault(delegate(IWebElement b)
							{
								if (b.Displayed && b.Enabled)
								{
									string attributeName = "class";
									string text10 = b.GetAttribute(attributeName) ?? "";
									string value = "disable-book";
									return !text10.Contains(value);
								}
								return false;
							});
						}
						catch
						{
							return (IWebElement?)null;
						}
					}) == null)
					{
						string message = "Book Now button not enabled after selecting date.";
						throw new Exception(message);
					}
					string text11 = ".//app-train-avl-enq[.//*[contains(normalize-space(),'";
					string text12 = trainNo;
					string text13 = "')]]//button[contains(.,'Book Now')]";
					HumanClickButton(driver, By.XPath(text11 + text12 + text13));
					return;
				}
				string[] array2 = new string[5];
				string text14 = "Date tile '";
				array2[0] = text14;
				array2[1] = text9;
				string text15 = "' not found for train ";
				array2[2] = text15;
				array2[3] = trainNo;
				string text16 = ".";
				array2[4] = text16;
				throw new Exception(string.Concat(array2));
			}
			string text17 = "Train ";
			string text18 = trainNo;
			string text19 = " not found.";
			throw new Exception(text17 + text18 + text19);
		}
		catch (Exception)
		{
		}
	}

	internal string FormatIrctcTileLabel(DateTime dt)
	{
		string text = "ddd, dd MMM";
		return dt.ToString(text, CultureInfo.InvariantCulture);
	}

	private bool TryClickDateTile(UndetectedChromeDriver driver, IWebElement trainBlock, string label, int maxMoves)
	{
		if (ClickVisibleTile(driver, trainBlock, label))
		{
			return true;
		}
		string cssSelectorToFind = ".fa.fa-chevron-right";
		IWebElement webElement = trainBlock.FindElements(By.CssSelector(cssSelectorToFind)).FirstOrDefault();
		string cssSelectorToFind2 = ".fa.fa-chevron-left";
		IWebElement webElement2 = trainBlock.FindElements(By.CssSelector(cssSelectorToFind2)).FirstOrDefault();
		int num = 0;
		while (true)
		{
			if (num < maxMoves && webElement != null)
			{
				string xpathToFind = ".//app-train-avl-enq[.//*[(contains(normalize-space(),'Runs On') or contains(normalize-space(),'Train Schedule'))]]//span[contains(@class,'fa-chevron-right')]";
				HumanClickButton(driver, By.XPath(xpathToFind));
				Thread.Sleep(150);
				if (ClickVisibleTile(driver, trainBlock, label))
				{
					break;
				}
				num++;
				continue;
			}
			for (int i = 0; i < maxMoves; i++)
			{
				if (webElement2 == null)
				{
					break;
				}
				string xpathToFind2 = ".//app-train-avl-enq[.//*[(contains(normalize-space(),'Runs On') or contains(normalize-space(),'Train Schedule'))]]//span[contains(@class,'fa-chevron-left')]";
				HumanClickButton(driver, By.XPath(xpathToFind2));
				Thread.Sleep(150);
				if (ClickVisibleTile(driver, trainBlock, label))
				{
					return true;
				}
			}
			return false;
		}
		return true;
	}

	private bool ClickVisibleTile(UndetectedChromeDriver driver, IWebElement trainBlock, string label)
	{
		string text = ".//div[contains(@class,'pre-avl')]//strong[translate(normalize-space(.), '\u00a0', ' ') = '";
		string text2 = "']";
		string text3 = text + label + text2;
		string text4 = "/ancestor::div[contains(@class,'pre-avl')]";
		HumanClickButton(driver, By.XPath(text3 + text4));
		return true;
	}

	internal string ClassCodeToText(string code)
	{
		code = code.ToUpperInvariant().Trim();
		string result = "";
		string text = code;
		string text2 = "SL";
		if (!(text == text2))
		{
			string text3 = code;
			string text4 = "3A";
			if (text3 == text4)
			{
				string text5 = "AC 3 Tier (3A)";
				result = text5;
			}
			else
			{
				string text6 = code;
				string text7 = "2A";
				if (text6 == text7)
				{
					string text8 = "AC 2 Tier (2A)";
					result = text8;
				}
				else
				{
					string text9 = code;
					string text10 = "CC";
					if (!(text9 == text10))
					{
						string text11 = code;
						string text12 = "2S";
						if (text11 == text12)
						{
							string text13 = "Second Sitting (2S)";
							result = text13;
						}
					}
					else
					{
						string text14 = "AC Chair Car (CC)";
						result = text14;
					}
				}
			}
		}
		else
		{
			string text15 = "Sleeper (SL)";
			result = text15;
		}
		return result;
	}

	internal void SelectGenderDropdown_HumanLike(IWebDriver driver, string genderText = "Male")
	{
		string text = "select[formcontrolname='passengerGender']";
		string cssSelectorToFind = text;
		IWebElement webElement = driver.FindElement(By.CssSelector(cssSelectorToFind));
		IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;
		string script = "arguments[0].scrollIntoView({block:'center'})";
		javaScriptExecutor.ExecuteScript(script, webElement);
		IJavaScriptExecutor javaScriptExecutor2 = (IJavaScriptExecutor)driver;
		string script2 = "\r\n        const el = arguments[0];\r\n        const r = el.getBoundingClientRect();\r\n        const x = r.left + r.width/2;\r\n        const y = r.top + r.height/2;\r\n        ['mouseover','mousemove','mouseenter'].forEach(t=>{\r\n            el.dispatchEvent(new MouseEvent(t,{bubbles:true,clientX:x,clientY:y,view:window}));\r\n        });\r\n    ";
		javaScriptExecutor2.ExecuteScript(script2, webElement);
		Thread.Sleep(new Random().Next(120, 220));
		IJavaScriptExecutor javaScriptExecutor3 = (IJavaScriptExecutor)driver;
		string script3 = "\r\n        const el = arguments[0];\r\n        const r = el.getBoundingClientRect();\r\n        const x = r.left + r.width/2;\r\n        const y = r.top + r.height/2;\r\n        ['mousedown','mouseup','click'].forEach(t=>{\r\n            el.dispatchEvent(new MouseEvent(t,{bubbles:true,clientX:x,clientY:y,view:window}));\r\n        });\r\n    ";
		javaScriptExecutor3.ExecuteScript(script3, webElement);
		Thread.Sleep(new Random().Next(150, 300));
		int num = 0;
		string text2 = genderText.ToLower();
		string text3 = "male";
		if (text2 == text3)
		{
			num = 1;
		}
		else
		{
			string text4 = "female";
			if (text2 == text4)
			{
				num = 2;
			}
			else
			{
				string text5 = "transgender";
				if (text2 == text5)
				{
					num = 3;
				}
			}
		}
		for (int i = 0; i < num; i++)
		{
			webElement.SendKeys(OpenQA.Selenium.Keys.ArrowDown);
			Thread.Sleep(new Random().Next(80, 140));
		}
		webElement.SendKeys(OpenQA.Selenium.Keys.Enter);
	}

	internal void SelectGender_Humanish2(UndetectedChromeDriver driver, int index1Based, string genderText, int timeoutSec = 8)
	{
		if (index1Based < 1)
		{
			index1Based = 1;
		}
		string text = genderText;
		string text2 = "M";
		if (!(text == text2))
		{
			string text3 = "F";
			if (!(text == text3))
			{
				string text4 = "T";
				if (text == text4)
				{
					string text5 = "Transgender";
					genderText = text5;
				}
			}
			else
			{
				string text6 = "Female";
				genderText = text6;
			}
		}
		else
		{
			string text7 = "Male";
			genderText = text7;
		}
		WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSec));
		string format = "(//app-passenger//select[@formcontrolname='passengerGender'])[{0}]";
		By locator = By.XPath(string.Format(format, index1Based));
		IWebElement webElement = webDriverWait.Until(delegate(IWebDriver d)
		{
			string cssSelectorToFind = "select[formcontrolname='passengerGender']";
			ReadOnlyCollection<IWebElement> readOnlyCollection = d.FindElements(By.CssSelector(cssSelectorToFind));
			return (readOnlyCollection == null || readOnlyCollection.Count < index1Based) ? null : readOnlyCollection[index1Based - 1];
		});
		string script = "arguments[0].scrollIntoView({block:'center'})";
		((IJavaScriptExecutor)driver).ExecuteScript(script, new object[1] { webElement });
		try
		{
			HumanClickButton(driver, locator);
		}
		catch
		{
		}
		try
		{
			new Actions(driver).MoveToElement(webElement, 2, Math.Max(2, webElement.Size.Height / 2 - 2)).Pause(TimeSpan.FromMilliseconds(120 + new Random().Next(120))).Click()
				.Perform();
		}
		catch
		{
		}
		Thread.Sleep(150 + new Random().Next(120));
		string text8 = (genderText ?? "").Trim().ToLower();
		int num = -1;
		string text9 = "male";
		if (!(text8 == text9))
		{
			string text10 = "female";
			if (text8 == text10)
			{
				string visibleText = "Female";
				num = IndexOfOption(webElement, visibleText);
			}
			else
			{
				string text11 = "transgender";
				if (!(text8 == text11))
				{
					num = IndexOfOption(webElement, genderText);
				}
				else
				{
					string visibleText2 = "Transgender";
					num = IndexOfOption(webElement, visibleText2);
				}
			}
		}
		else
		{
			string visibleText3 = "Male";
			num = IndexOfOption(webElement, visibleText3);
		}
		if (num >= 0)
		{
			int selectedIndex = GetSelectedIndex(webElement);
			int num2 = num - selectedIndex;
			if (num2 != 0)
			{
				string text12 = ((num2 > 0) ? OpenQA.Selenium.Keys.ArrowDown : OpenQA.Selenium.Keys.ArrowUp);
				num2 = Math.Abs(num2);
				for (int i = 0; i < num2; i++)
				{
					webElement.SendKeys(text12);
					Thread.Sleep(60 + new Random().Next(70));
				}
				webElement.SendKeys(OpenQA.Selenium.Keys.Enter);
			}
			else
			{
				webElement.SendKeys(OpenQA.Selenium.Keys.Enter);
			}
		}
		if (!IsSelectedText(webElement, genderText))
		{
			TryCdpClickCenter(driver, webElement);
			Thread.Sleep(150);
			string tagNameToFind = "option";
			webElement.FindElements(By.TagName(tagNameToFind)).FirstOrDefault((IWebElement o) => (o.Text ?? "").Trim().Equals(genderText, StringComparison.OrdinalIgnoreCase))?.Click();
		}
		if (!IsSelectedText(webElement, genderText))
		{
			string text13 = null;
			string text14 = "male";
			if (!(text8 == text14))
			{
				string text15 = "female";
				if (text8 == text15)
				{
					string text16 = "F";
					text13 = text16;
				}
				else
				{
					string text17 = "transgender";
					if (!(text8 == text17))
					{
						text13 = FindOptionValue(webElement, genderText);
					}
					else
					{
						string text18 = "T";
						text13 = text18;
					}
				}
			}
			else
			{
				string text19 = "M";
				text13 = text19;
			}
			if (text13 != null)
			{
				string script2 = "\r\n                var sel=arguments[0], val=arguments[1];\r\n                sel.value = val;\r\n                sel.dispatchEvent(new Event('input',{bubbles:true}));\r\n                sel.dispatchEvent(new Event('change',{bubbles:true}));\r\n            ";
				((IJavaScriptExecutor)driver).ExecuteScript(script2, new object[2] { webElement, text13 });
			}
		}
		if (!IsSelectedText(webElement, genderText))
		{
			string[] array = new string[5];
			string text20 = "Gender select failed for row ";
			array[0] = text20;
			array[1] = index1Based.ToString();
			string text21 = ": '";
			array[2] = text21;
			array[3] = genderText;
			string text22 = "'.";
			array[4] = text22;
			throw new Exception(string.Concat(array));
		}
	}

	internal void SelectGender_Humanish(UndetectedChromeDriver driver, string genderText = "Male", int timeoutSec = 8)
	{
		WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSec));
		string cssSelectorToFind = "select[formcontrolname='passengerGender']";
		By selBy = By.CssSelector(cssSelectorToFind);
		IWebElement webElement = webDriverWait.Until((IWebDriver d) => d.FindElement(selBy));
		string script = "arguments[0].scrollIntoView({block:'center'})";
		((IJavaScriptExecutor)driver).ExecuteScript(script, new object[1] { webElement });
		try
		{
			HumanClickButton(driver, selBy);
		}
		catch
		{
		}
		try
		{
			new Actions(driver).MoveToElement(webElement, 2, webElement.Size.Height / 2 - 2).Pause(TimeSpan.FromMilliseconds(120 + new Random().Next(120))).Click()
				.Perform();
		}
		catch
		{
		}
		Thread.Sleep(150 + new Random().Next(120));
		string text = genderText.Trim().ToLower();
		int num = -1;
		string text2 = text;
		string text3 = "male";
		if (!(text2 == text3))
		{
			string text4 = text;
			string text5 = "female";
			if (!(text4 == text5))
			{
				string text6 = text;
				string text7 = "transgender";
				if (text6 == text7)
				{
					string visibleText = "Transgender";
					num = IndexOfOption(webElement, visibleText);
				}
				else
				{
					num = IndexOfOption(webElement, genderText);
				}
			}
			else
			{
				string visibleText2 = "Female";
				num = IndexOfOption(webElement, visibleText2);
			}
		}
		else
		{
			string visibleText3 = "Male";
			num = IndexOfOption(webElement, visibleText3);
		}
		if (num >= 0)
		{
			int selectedIndex = GetSelectedIndex(webElement);
			int num2 = num - selectedIndex;
			if (num2 != 0)
			{
				string text8 = ((num2 > 0) ? OpenQA.Selenium.Keys.ArrowDown : OpenQA.Selenium.Keys.ArrowUp);
				num2 = Math.Abs(num2);
				for (int i = 0; i < num2; i++)
				{
					webElement.SendKeys(text8);
					Thread.Sleep(60 + new Random().Next(70));
				}
				webElement.SendKeys(OpenQA.Selenium.Keys.Enter);
			}
			else
			{
				webElement.SendKeys(OpenQA.Selenium.Keys.Enter);
			}
		}
		if (!IsSelectedText(webElement, genderText))
		{
			TryCdpClickCenter(driver, webElement);
			Thread.Sleep(150);
			string tagNameToFind = "option";
			webElement.FindElements(By.TagName(tagNameToFind)).FirstOrDefault((IWebElement o) => (o.Text ?? "").Trim().Equals(genderText, StringComparison.OrdinalIgnoreCase))?.Click();
		}
		if (!IsSelectedText(webElement, genderText))
		{
			text = genderText.Trim().ToLower();
			string text9 = null;
			string text10 = text;
			string text11 = "male";
			if (!(text10 == text11))
			{
				string text12 = text;
				string text13 = "female";
				if (!(text12 == text13))
				{
					string text14 = text;
					string text15 = "transgender";
					if (!(text14 == text15))
					{
						text9 = FindOptionValue(webElement, genderText);
					}
					else
					{
						string text16 = "T";
						text9 = text16;
					}
				}
				else
				{
					string text17 = "F";
					text9 = text17;
				}
			}
			else
			{
				string text18 = "M";
				text9 = text18;
			}
			if (text9 != null)
			{
				string script2 = "\r\n               var sel=arguments[0], val=arguments[1];\r\n               sel.value = val;\r\n               sel.dispatchEvent(new Event('input',{bubbles:true}));\r\n               sel.dispatchEvent(new Event('change',{bubbles:true}));\r\n            ";
				((IJavaScriptExecutor)driver).ExecuteScript(script2, new object[2] { webElement, text9 });
			}
		}
		if (!IsSelectedText(webElement, genderText))
		{
			string text19 = "Gender select failed: '";
			string text20 = genderText;
			string text21 = "'.";
			throw new Exception(text19 + text20 + text21);
		}
	}

	internal int IndexOfOption(IWebElement selectEl, string visibleText)
	{
		string tagNameToFind = "option";
		List<IWebElement> list = selectEl.FindElements(By.TagName(tagNameToFind)).ToList();
		int num = 0;
		while (true)
		{
			if (num < list.Count)
			{
				if ((list[num].Text ?? "").Trim().Equals(visibleText, StringComparison.OrdinalIgnoreCase))
				{
					break;
				}
				num++;
				continue;
			}
			return -1;
		}
		return num;
	}

	internal string FindOptionValue(IWebElement selectEl, string visibleText)
	{
		string tagNameToFind = "option";
		IWebElement webElement = selectEl.FindElements(By.TagName(tagNameToFind)).FirstOrDefault((IWebElement o) => (o.Text ?? "").Trim().Equals(visibleText, StringComparison.OrdinalIgnoreCase));
		if (webElement == null)
		{
			return null;
		}
		string attributeName = "value";
		return webElement.GetAttribute(attributeName);
	}

	internal int GetSelectedIndex(IWebElement selectEl)
	{
		string cssSelectorToFind = "option:checked";
		IWebElement selected = selectEl.FindElements(By.CssSelector(cssSelectorToFind)).FirstOrDefault();
		if (selected != null)
		{
			string tagNameToFind = "option";
			return selectEl.FindElements(By.TagName(tagNameToFind)).ToList().FindIndex((IWebElement o) => o.Equals(selected));
		}
		return 0;
	}

	internal bool IsSelectedText(IWebElement selectEl, string expectedText)
	{
		string cssSelectorToFind = "option:checked";
		IWebElement webElement = selectEl.FindElements(By.CssSelector(cssSelectorToFind)).FirstOrDefault();
		if (webElement == null)
		{
			return false;
		}
		return (webElement.Text ?? "").Trim().Equals(expectedText.Trim(), StringComparison.OrdinalIgnoreCase);
	}

	internal void TryCdpClickCenter(UndetectedChromeDriver driver, IWebElement el)
	{
		try
		{
			string script = "\r\n            var r = arguments[0].getBoundingClientRect();\r\n            return {left:r.left, top:r.top, width:r.width, height:r.height};\r\n        ";
			IDictionary dictionary = (IDictionary)((IJavaScriptExecutor)driver).ExecuteScript(script, new object[1] { el });
			string key = "left";
			double num = Convert.ToDouble(dictionary[key]);
			string key2 = "top";
			double num2 = Convert.ToDouble(dictionary[key2]);
			string key3 = "width";
			double num3 = Convert.ToDouble(dictionary[key3]);
			string key4 = "height";
			double num4 = Convert.ToDouble(dictionary[key4]);
			int num5 = (int)(num + num3 / 2.0);
			int num6 = (int)(num2 + num4 / 2.0);
			string commandName = "Input.dispatchMouseEvent";
			Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
			string key5 = "type";
			string value = "mouseMoved";
			dictionary2[key5] = value;
			string key6 = "x";
			dictionary2[key6] = num5;
			string key7 = "y";
			dictionary2[key7] = num6;
			string key8 = "buttons";
			dictionary2[key8] = 1;
			driver.ExecuteCdpCommand(commandName, dictionary2);
			string commandName2 = "Input.dispatchMouseEvent";
			Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
			string key9 = "type";
			string value2 = "mousePressed";
			dictionary3[key9] = value2;
			string key10 = "x";
			dictionary3[key10] = num5;
			string key11 = "y";
			dictionary3[key11] = num6;
			string key12 = "button";
			string value3 = "left";
			dictionary3[key12] = value3;
			string key13 = "clickCount";
			dictionary3[key13] = 1;
			driver.ExecuteCdpCommand(commandName2, dictionary3);
			string commandName3 = "Input.dispatchMouseEvent";
			Dictionary<string, object> dictionary4 = new Dictionary<string, object>();
			string key14 = "type";
			string value4 = "mouseReleased";
			dictionary4[key14] = value4;
			string key15 = "x";
			dictionary4[key15] = num5;
			string key16 = "y";
			dictionary4[key16] = num6;
			string key17 = "button";
			string value5 = "left";
			dictionary4[key17] = value5;
			string key18 = "clickCount";
			dictionary4[key18] = 1;
			driver.ExecuteCdpCommand(commandName3, dictionary4);
		}
		catch
		{
		}
	}

	internal void HumanTickPaymentRadio(UndetectedChromeDriver driver)
	{
		WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10.0));
		string cssSelectorToFind = "label[for='2'] div[role='radio']";
		IWebElement webElement = webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(cssSelectorToFind)));
		string script = "arguments[0].scrollIntoView({behavior:'smooth', block:'center'});";
		((IJavaScriptExecutor)driver).ExecuteScript(script, new object[1] { webElement });
		Thread.Sleep(new Random().Next(200, 400));
		Size size = webElement.Size;
		Point location = webElement.Location;
		int num = location.X - new Random().Next(20, 50);
		int num2 = location.Y - new Random().Next(10, 30);
		int num3 = location.X + size.Width / 2;
		int num4 = location.Y + size.Height / 2;
		Actions actions = new Actions(driver);
		int num5 = new Random().Next(7, 14);
		for (int i = 0; i <= num5; i++)
		{
			int num6 = num + (int)((double)((num3 - num) * i) / (double)num5);
			int num7 = num2 + (int)((double)((num4 - num2) * i) / (double)num5);
			actions.MoveByOffset(num6 - ((i == 0) ? num : num6), num7 - ((i == 0) ? num2 : num7)).Perform();
			Thread.Sleep(new Random().Next(15, 40));
		}
		actions.MoveToElement(webElement).Perform();
		Thread.Sleep(new Random().Next(80, 180));
		actions.Click().Perform();
	}

	internal void FillPassengerBasic(UndetectedChromeDriver driver, int slotIndex, string name, string age, string gender)
	{
		string format = "(//app-passenger//div[contains(@class,'container-fluid')])[{0}]";
		string text = string.Format(format, slotIndex);
		string text2 = "//p-autocomplete[@formcontrolname='passengerName']//input[@placeholder='Name']";
		TypeLikeHuman(driver, By.XPath(text + text2), name);
		string text3 = "//input[@formcontrolname='passengerAge' and @placeholder='Age']";
		TypeLikeHuman(driver, By.XPath(text + text3), age);
		SelectGender_Humanish2(driver, slotIndex, gender);
	}

	internal void HumanLikeCheckBox(UndetectedChromeDriver driver, string formControlName)
	{
		string text = "\r\n        var el=document.querySelector('input[formcontrolname=\"";
		string text2 = "\"]');\r\n        if(!el) return false; // element not found\r\n\r\n        if(el.checked) return true; // already ticked\r\n\r\n        var r=el.getBoundingClientRect();\r\n        var x=Math.floor(r.left + r.width/2);\r\n        var y=Math.floor(r.top + r.height/2);\r\n\r\n        function fire(type, delay){\r\n            setTimeout(function(){\r\n                var evt=new MouseEvent(type,{\r\n                  bubbles:true,cancelable:true,clientX:x,clientY:y,view:window,button:0});\r\n                el.dispatchEvent(evt);\r\n            }, delay);\r\n        }\r\n\r\n        var base = Math.floor(40+Math.random()*90);\r\n        fire('mousemove', base);\r\n        fire('mouseover', base+60);\r\n        fire('mousedown', base+120);\r\n        fire('mouseup', base+180);\r\n        fire('click', base+220);\r\n\r\n        // set checked + dispatch Angular events\r\n        setTimeout(function(){\r\n            el.checked = true;\r\n            el.dispatchEvent(new Event('input',{bubbles:true}));\r\n            el.dispatchEvent(new Event('change',{bubbles:true}));\r\n        }, base+250);\r\n\r\n        return true;\r\n    ";
		string script = text + formControlName + text2;
		object obj = ((IJavaScriptExecutor)driver).ExecuteScript(script, Array.Empty<object>());
		if (obj != null)
		{
			string text3 = obj.ToString();
			string text4 = "true";
			if (text3 == text4)
			{
				string text5 = " checkbox ticked.";
				Console.WriteLine(formControlName + text5);
				return;
			}
		}
		string text6 = " checkbox not found.";
		Console.WriteLine(formControlName + text6);
	}

	internal bool HumanLikeRadioByFormControl(IWebDriver driver, string formControlName, string value)
	{
		string text = "\r\n    (function(){\r\n      var host = document.querySelector('p-radiobutton[formcontrolname=\"__FC__\"] input[type=\"radio\"][value=\"__VAL__\"]');\r\n      if(!host){\r\n        // in some templates, p-radiobutton is sibling; broaden search:\r\n        host = Array.from(document.querySelectorAll('p-radiobutton[formcontrolname=\"__FC__\"]'))\r\n               .map(function(pr){ return pr.querySelector('input[type=\"radio\"][value=\"__VAL__\"]'); })\r\n               .filter(Boolean)[0] || null;\r\n      }\r\n      if(!host) return 'NF'; // not found\r\n\r\n      var box = host.closest('.ui-radiobutton');\r\n      if(!box){ return 'NOBOX'; }\r\n\r\n      var uiBox = box.querySelector('.ui-radiobutton-box') || box;\r\n\r\n      // if already selected, done\r\n      if(host.checked) return 'OK';\r\n\r\n      // bring into view\r\n      try { uiBox.scrollIntoView({block:'center'}); } catch(e){}\r\n\r\n      // fire a human-ish pointer sequence on the visible box\r\n      var r = uiBox.getBoundingClientRect();\r\n      var x = Math.floor(r.left + r.width  * (0.40 + Math.random()*0.2));\r\n      var y = Math.floor(r.top  + r.height * (0.40 + Math.random()*0.2));\r\n      function fire(type, delay){\r\n        setTimeout(function(){\r\n          var evt = new MouseEvent(type,{bubbles:true,cancelable:true,clientX:x,clientY:y,view:window,button:0});\r\n          uiBox.dispatchEvent(evt);\r\n        }, delay);\r\n      }\r\n      var base = 40 + Math.floor(Math.random()*90);\r\n      fire('mousemove', base);\r\n      fire('mouseover', base+60);\r\n      fire('mousemove', base+120);\r\n      fire('mousedown', base+180);\r\n      fire('mouseup',   base+220);\r\n      fire('click',     base+260);\r\n\r\n      // verify after a short delay; if not selected, force-set + Angular events\r\n      setTimeout(function(){\r\n        if(!host.checked){\r\n          try { uiBox.click(); } catch(e){}\r\n        }\r\n        setTimeout(function(){\r\n          if(!host.checked){\r\n            host.checked = true;\r\n            host.dispatchEvent(new Event('input', {bubbles:true}));\r\n            host.dispatchEvent(new Event('change',{bubbles:true}));\r\n            // nudge UI box so PrimeNG updates classes/aria\r\n            try { uiBox.dispatchEvent(new Event('click', {bubbles:true})); } catch(e){}\r\n          }\r\n        }, 120);\r\n      }, 140);\r\n\r\n      return 'PEND';\r\n    })();\r\n    ";
		string oldValue = "__FC__";
		string text2 = text.Replace(oldValue, formControlName);
		string oldValue2 = "__VAL__";
		string script = text2.Replace(oldValue2, value);
		string text3 = (driver as IJavaScriptExecutor).ExecuteScript(script) as string;
		string text4 = "OK";
		if (!(text3 == text4))
		{
			string text5 = "PEND";
			return text3 == text5;
		}
		return true;
	}

	private void Pause(int min = 80, int max = 180)
	{
		Thread.Sleep(_rnd.Next(min, max));
	}

	private IWebElement WaitVisible(IWebDriver d, By by, int sec = 8)
	{
		return new WebDriverWait(d, TimeSpan.FromSeconds(sec)).Until(delegate(IWebDriver dr)
		{
			IWebElement webElement = dr.FindElements(by).FirstOrDefault();
			return (webElement == null || !webElement.Displayed || !webElement.Enabled) ? null : webElement;
		});
	}

	private void ScrollCenter(IWebDriver d, IWebElement el)
	{
		IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)d;
		string script = "arguments[0].scrollIntoView({block:'center'})";
		javaScriptExecutor.ExecuteScript(script, el);
	}

	private bool IsOccluded(IWebDriver d, IWebElement el)
	{
		try
		{
			IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)d;
			string script = "\r\n                var el=arguments[0], r=el.getBoundingClientRect();\r\n                var cx=Math.floor(r.left+r.width/2), cy=Math.floor(r.top+r.height/2);\r\n                var top=document.elementFromPoint(cx,cy);\r\n                return top && !el.contains(top) && top!==el;";
			return (bool)javaScriptExecutor.ExecuteScript(script, el);
		}
		catch
		{
			return false;
		}
	}

	private void HumanActionsClick(IWebDriver d, IWebElement el)
	{
		Actions actions = new Actions(d);
		IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)d;
		string script = "\r\n            var r=arguments[0].getBoundingClientRect(); return {w:r.width,h:r.height};";
		Dictionary<string, object> dictionary = (Dictionary<string, object>)javaScriptExecutor.ExecuteScript(script, el);
		string key = "w";
		int num = Convert.ToInt32(dictionary[key]);
		string key2 = "h";
		int num2 = Convert.ToInt32(dictionary[key2]);
		int offsetX = _rnd.Next(num / 3, 2 * num / 3) - num / 2;
		int offsetY = _rnd.Next(num2 / 3, 2 * num2 / 3) - num2 / 2;
		actions.MoveToElement(el, offsetX, offsetY).Pause(TimeSpan.FromMilliseconds(_rnd.Next(90, 220))).MoveByOffset(_rnd.Next(-3, 4), _rnd.Next(-2, 3))
			.Pause(TimeSpan.FromMilliseconds(_rnd.Next(70, 160)))
			.Click()
			.Perform();
	}

	private void JsMouseSequence(IWebDriver d, IWebElement el)
	{
		IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)d;
		string script = "\r\n            var el=arguments[0];\r\n            var r=el.getBoundingClientRect();\r\n            var x = Math.floor(r.left + r.width  * (0.40 + Math.random()*0.2));\r\n            var y = Math.floor(r.top  + r.height * (0.40 + Math.random()*0.2));\r\n            function fire(t,delay){ setTimeout(function(){\r\n              var evt=new MouseEvent(t,{bubbles:true,cancelable:true,clientX:x,clientY:y,view:window,button:0});\r\n              el.dispatchEvent(evt); }, delay); }\r\n            var base = 40 + Math.floor(Math.random()*90);\r\n            fire('mousemove', base);\r\n            fire('mouseover', base+60);\r\n            fire('mousemove', base+120);\r\n            fire('mousedown', base+180);\r\n            fire('mouseup',   base+220);\r\n            fire('click',     base+260);\r\n        ";
		javaScriptExecutor.ExecuteScript(script, el);
		Pause(40, 150);
	}

	private void JsDirectClick(IWebDriver d, IWebElement el)
	{
		IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)d;
		string script = "arguments[0].click()";
		javaScriptExecutor.ExecuteScript(script, el);
	}

	internal IWebElement FindTrainCardByNumber(IWebDriver driver, string trainNumber, int timeoutSec = 8)
	{
		string text = "//strong[contains(normalize-space(.), '(";
		string text2 = ")')]";
		string xpathToFind = text + trainNumber + text2;
		IWebElement webElement = WaitVisible(driver, By.XPath(xpathToFind), timeoutSec);
		if (webElement == null)
		{
			return null;
		}
		try
		{
			string xpathToFind2 = "ancestor::app-train-avl-enq[1]";
			return webElement.FindElement(By.XPath(xpathToFind2));
		}
		catch
		{
			try
			{
				string xpathToFind3 = "ancestor::*[@class[contains(.,'border-all') or contains(.,'train-heading')]][1]";
				return webElement.FindElement(By.XPath(xpathToFind3));
			}
			catch
			{
				return null;
			}
		}
	}

	internal bool ClickClassTabOnTrain(UndetectedChromeDriver driver, string trainNumber, string classCode = "SL", int timeoutSec = 8)
	{
		IWebElement webElement = FindTrainCardByNumber(driver, trainNumber, timeoutSec);
		if (webElement == null)
		{
			return false;
		}
		string[] array = new string[5];
		string text = ".//li[contains(@class,'ui-tabmenuitem')]//div[contains(@class,'ui-menuitem-text')][.//span[contains(@class,'hidden-xs')][contains(normalize-space(.), '(";
		array[0] = text;
		array[1] = classCode;
		string text2 = ")')]  or .//span[contains(@class,'hidden-lg') or contains(@class,'hidden-md') or contains(@class,'hidden-sm')][normalize-space(.)='";
		array[2] = text2;
		array[3] = classCode;
		string text3 = "']]";
		array[4] = text3;
		string xpathToFind = string.Concat(array);
		IWebElement webElement2 = null;
		try
		{
			string cssSelectorToFind = ".ui-tabmenu";
			webElement2 = webElement.FindElement(By.CssSelector(cssSelectorToFind)).FindElements(By.XPath(xpathToFind)).FirstOrDefault();
		}
		catch
		{
		}
		if (webElement2 == null)
		{
			string[] array2 = new string[5];
			string text4 = ".//*[self::strong or self::span][contains(normalize-space(.), '(";
			array2[0] = text4;
			array2[1] = classCode;
			string text5 = ")')]| .//span[normalize-space(.)='";
			array2[2] = text5;
			array2[3] = classCode;
			string text6 = "']";
			array2[4] = text6;
			string xpathToFind2 = string.Concat(array2);
			webElement2 = webElement.FindElements(By.XPath(xpathToFind2)).FirstOrDefault();
			if (webElement2 == null)
			{
				return false;
			}
		}
		try
		{
			ScrollCenter(driver, webElement2);
			for (int i = 0; i < 3; i++)
			{
				if (!IsOccluded(driver, webElement2))
				{
					break;
				}
				Pause(180, 320);
			}
			try
			{
				HumanActionsClick(driver, webElement2);
			}
			catch
			{
			}
			Pause(5, 40);
			if (IsTabActive(webElement2))
			{
				return true;
			}
			try
			{
				JsMouseSequence(driver, webElement2);
			}
			catch
			{
			}
			if (IsTabActive(webElement2))
			{
				return true;
			}
			try
			{
				JsDirectClick(driver, webElement2);
			}
			catch
			{
			}
			Pause(5, 40);
			if (!IsTabActive(webElement2))
			{
				try
				{
					webElement2.SendKeys(OpenQA.Selenium.Keys.Enter);
				}
				catch
				{
				}
				Pause(5, 40);
				return IsTabActive(webElement2);
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private bool IsTabActive(IWebElement anyInsideTab)
	{
		try
		{
			string xpathToFind = "ancestor::li[contains(@class,'ui-tabmenuitem')][1]";
			IWebElement webElement = anyInsideTab.FindElement(By.XPath(xpathToFind));
			string attributeName = "class";
			string text = webElement.GetAttribute(attributeName) ?? "";
			string value = "ui-state-active";
			return text.IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0;
		}
		catch
		{
			return false;
		}
	}

	internal bool WaitUsingWhileBrvrave(UndetectedChromeDriver driver, int timeoutSec = 180)
	{
		if (driver == null)
		{
			return false;
		}
		WebDriverWait webDriverWait = new WebDriverWait(new SystemClock(), driver, TimeSpan.FromSeconds(timeoutSec), TimeSpan.FromMilliseconds(200.0));
		try
		{
			return webDriverWait.Until(delegate(IWebDriver d)
			{
				try
				{
					string text = ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState")?.ToString();
					return text == "complete";
				}
				catch
				{
					return false;
				}
			});
		}
		catch
		{
			return false;
		}
	}

	internal void WaitUsingWhile(UndetectedChromeDriver driver, int timeoutSec = 180)
	{
		DateTime now = DateTime.Now;
		while (true)
		{
			try
			{
				string script = "return document.readyState;";
				string text = ((IJavaScriptExecutor)driver).ExecuteScript(script, Array.Empty<object>()).ToString();
				string text2 = "complete";
				if (text == text2)
				{
					while (true)
					{
						int[,,] array = new int[2, 5, 1]
						{
							{
								{ 1210445055 },
								{ 1569254949 },
								{ -856688188 },
								{ -1714799676 },
								{ -422997259 }
							},
							{
								{ -595076614 },
								{ -1112111879 },
								{ 1963541817 },
								{ -1531731771 },
								{ 1569254948 }
							}
						};
						switch (-(array[1, 4, 0] ^ -1569254950))
						{
						case 2:
							return;
						case 1:
							break;
						case 0:
							continue;
						}
						break;
					}
				}
			}
			catch
			{
			}
			if ((DateTime.Now - now).TotalSeconds <= (double)timeoutSec)
			{
				Thread.Sleep(100);
				continue;
			}
			break;
		}
	}

	internal bool GetWindow_X_Y(int chrome_Window, ref int X, ref int Y, ref int W, ref int H)
	{
		if (chrome_Window >= 1 && chrome_Window <= 4)
		{
			string variable = "BookWindowSize";
			string environmentVariable = Environment.GetEnvironmentVariable(variable);
			int num = 250;
			if (!string.IsNullOrEmpty(environmentVariable) && int.TryParse(environmentVariable, out var result))
			{
				num = result;
			}
			int width = Screen.PrimaryScreen.Bounds.Width;
			int height = Screen.PrimaryScreen.Bounds.Height;
			int num2 = Math.Max(0, width - num);
			int num3 = num2 / 4;
			int num4 = num2 % 4;
			int num5 = chrome_Window - 1;
			X = num + num5 * num3;
			Y = 0;
			W = num3;
			H = height;
			if (chrome_Window == 4)
			{
				W = num3 + num4;
			}
			return true;
		}
		return false;
	}

	private static string JsStringEscape(string s)
	{
		if (s == null)
		{
			while (true)
			{
				int[,,,] array = new int[2, 5, 1, 1]
				{
					{
						{ { 450304044 } },
						{ { -28319308 } },
						{ { 1012270426 } },
						{ { 1012270425 } },
						{ { 2128569674 } }
					},
					{
						{ { 65896985 } },
						{ { 1150985771 } },
						{ { 1748659431 } },
						{ { 682947667 } },
						{ { -1524568847 } }
					}
				};
				switch (-(array[0, 3, 0, 0] + -1012270427))
				{
				case 2:
					return "";
				case 0:
					continue;
				}
				break;
			}
		}
		string oldValue = "\\";
		string newValue = "\\\\";
		string text = s.Replace(oldValue, newValue);
		string oldValue2 = "'";
		string newValue2 = "\\'";
		string text2 = text.Replace(oldValue2, newValue2);
		string oldValue3 = "\r";
		string newValue3 = "\\r";
		string text3 = text2.Replace(oldValue3, newValue3);
		string oldValue4 = "\n";
		string newValue4 = "\\n";
		return text3.Replace(oldValue4, newValue4);
	}

	internal void SelectSLAndBook(UndetectedChromeDriver driver, string trainNumber, int timeoutSeconds = 15)
	{
		WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
		string text = "//strong[contains(.,'(";
		string text2 = ")')]/ancestor::app-train-avl-enq[1]";
		string containerXPath = text + trainNumber + text2;
		IWebElement container = webDriverWait.Until((IWebDriver d) => d.FindElement(By.XPath(containerXPath)));
		IWebElement webElement = container;
		string xpathToFind = ".//span[contains(.,'SL')]";
		webElement.FindElement(By.XPath(xpathToFind)).Click();
		IWebElement webElement3 = webDriverWait.Until(delegate
		{
			try
			{
				IWebElement webElement2 = container;
				string xpathToFind2 = ".//div[contains(@class,'avlAndFare') or contains(@class,'col-xs-12')][.//strong or .//span][1]";
				return webElement2.FindElement(By.XPath(xpathToFind2));
			}
			catch (NoSuchElementException)
			{
				return (IWebElement?)null;
			}
		});
		if (webElement3 != null)
		{
			webElement3.Click();
			IWebElement webElement6 = webDriverWait.Until(delegate
			{
				try
				{
					IWebElement webElement4 = container;
					string xpathToFind3 = ".//button[contains(text(),'Book Now')]";
					IWebElement webElement5 = webElement4.FindElement(By.XPath(xpathToFind3));
					if (webElement5.Enabled && webElement5.Displayed)
					{
						string attributeName = "class";
						string attribute = webElement5.GetAttribute(attributeName);
						string value = "disable-book";
						if (!attribute.Contains(value))
						{
							return webElement5;
						}
					}
					return (IWebElement?)null;
				}
				catch (NoSuchElementException)
				{
					return (IWebElement?)null;
				}
			});
			try
			{
				webElement6.Click();
				return;
			}
			catch (ElementClickInterceptedException)
			{
				string script = "arguments[0].click();";
				((IJavaScriptExecutor)driver).ExecuteScript(script, new object[1] { webElement6 });
				return;
			}
		}
		string message = "No availability option found in SL tab.";
		throw new Exception(message);
	}

	internal void SmoothResizeViaCDP(UndetectedChromeDriver driver, int targetWidth, int targetHeight, int steps = 30)
	{
		try
		{
			Dictionary<string, object> commandParameters = new Dictionary<string, object>();
			string commandName = "Browser.getWindowForTarget";
			Dictionary<string, object> dictionary = (Dictionary<string, object>)driver.ExecuteCdpCommand(commandName, commandParameters);
			string key = "windowId";
			int num = Convert.ToInt32(dictionary[key]);
			Size size = driver.Manage().Window.Size;
			double num2 = (double)(targetWidth - size.Width) / (double)steps;
			double num3 = (double)(targetHeight - size.Height) / (double)steps;
			Random random = new Random();
			for (int i = 1; i <= steps; i++)
			{
				int val = (int)Math.Round((double)size.Width + num2 * (double)i);
				int val2 = (int)Math.Round((double)size.Height + num3 * (double)i);
				Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
				string key2 = "windowId";
				dictionary2[key2] = num;
				string key3 = "bounds";
				Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
				string key4 = "width";
				dictionary3[key4] = Math.Max(300, val);
				string key5 = "height";
				dictionary3[key5] = Math.Max(300, val2);
				string key6 = "windowState";
				string value = "normal";
				dictionary3[key6] = value;
				dictionary2[key3] = dictionary3;
				Dictionary<string, object> commandParameters2 = dictionary2;
				string commandName2 = "Browser.setWindowBounds";
				driver.ExecuteCdpCommand(commandName2, commandParameters2);
				Thread.Sleep(random.Next(8, 18));
			}
		}
		catch
		{
		}
	}

	internal void SmoothMoveToTopRight(UndetectedChromeDriver driver, int steps = 40, int minDelayMs = 7, int maxDelayMs = 18)
	{
		try
		{
			Random random = new Random();
			int? num = null;
			try
			{
				string commandName = "Browser.getWindowForTarget";
				Dictionary<string, object> dictionary = (Dictionary<string, object>)driver.ExecuteCdpCommand(commandName, new Dictionary<string, object>());
				string key = "windowId";
				num = Convert.ToInt32(dictionary[key]);
				string commandName2 = "Browser.setWindowBounds";
				Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
				string key2 = "windowId";
				dictionary2[key2] = num.Value;
				string key3 = "bounds";
				Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
				string key4 = "windowState";
				string value = "normal";
				dictionary3[key4] = value;
				dictionary2[key3] = dictionary3;
				driver.ExecuteCdpCommand(commandName2, dictionary2);
			}
			catch
			{
			}
			Point position = driver.Manage().Window.Position;
			Size size = driver.Manage().Window.Size;
			Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
			int num2 = workingArea.Right - size.Width;
			int top = workingArea.Top;
			num2 += random.Next(-2, 3);
			top += random.Next(-2, 3);
			int num3 = random.Next(0, 3);
			int num4 = random.Next(steps / 3, Math.Max(steps / 3 + 2, steps - 6));
			int num5 = random.Next(120, 220);
			for (int i = 1; i <= steps; i++)
			{
				double t2 = Ease(Math.Min(1.0, (double)(i + num3) / (double)(steps + num3)));
				double t3 = Ease((double)i / (double)steps);
				int num6 = Lerp(position.X, num2, t2);
				int num7 = Lerp(position.Y, top, t3);
				if (i % 9 == 0)
				{
					num6 += random.Next(-1, 2);
				}
				if (i % 11 == 0)
				{
					num7 += random.Next(-1, 2);
				}
				if (num6 < workingArea.Left)
				{
					num6 = workingArea.Left;
				}
				if (num7 < workingArea.Top)
				{
					num7 = workingArea.Top;
				}
				bool flag = false;
				if (num.HasValue)
				{
					try
					{
						string commandName3 = "Browser.setWindowBounds";
						Dictionary<string, object> dictionary4 = new Dictionary<string, object>();
						string key5 = "windowId";
						dictionary4[key5] = num.Value;
						string key6 = "bounds";
						Dictionary<string, object> dictionary5 = new Dictionary<string, object>();
						string key7 = "left";
						dictionary5[key7] = num6;
						string key8 = "top";
						dictionary5[key8] = num7;
						string key9 = "width";
						dictionary5[key9] = size.Width;
						string key10 = "height";
						dictionary5[key10] = size.Height;
						string key11 = "windowState";
						string value2 = "normal";
						dictionary5[key11] = value2;
						dictionary4[key6] = dictionary5;
						driver.ExecuteCdpCommand(commandName3, dictionary4);
						flag = true;
					}
					catch
					{
						flag = false;
					}
				}
				if (!flag)
				{
					driver.Manage().Window.Position = new Point(num6, num7);
					driver.Manage().Window.Size = new Size(size.Width, size.Height);
				}
				int num8 = random.Next(minDelayMs, maxDelayMs + 1);
				if (i == num4)
				{
					num8 += num5;
				}
				if (i % 13 == 0 && random.NextDouble() < 0.3)
				{
					num8 += random.Next(25, 60);
				}
				Thread.Sleep(num8);
			}
		}
		catch
		{
		}
		static double Ease(double t)
		{
			return t * t * (3.0 - 2.0 * t);
		}
		static int Lerp(int a, int b, double t)
		{
			if (t < 0.0)
			{
				t = 0.0;
			}
			if (t > 1.0)
			{
				t = 1.0;
			}
			return a + (int)Math.Round((double)(b - a) * t, MidpointRounding.AwayFromZero);
		}
	}

	internal void SmoothMoveTo(ChromeDriver driver, int targetLeft, int targetTop, int steps = 40, int minDelayMs = 7, int maxDelayMs = 18)
	{
		try
		{
			Random random = new Random();
			int? num = null;
			try
			{
				string commandName = "Browser.getWindowForTarget";
				Dictionary<string, object> dictionary = (Dictionary<string, object>)driver.ExecuteCdpCommand(commandName, new Dictionary<string, object>());
				string key = "windowId";
				num = Convert.ToInt32(dictionary[key]);
				string commandName2 = "Browser.setWindowBounds";
				Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
				string key2 = "windowId";
				dictionary2[key2] = num.Value;
				string key3 = "bounds";
				Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
				string key4 = "windowState";
				string value = "normal";
				dictionary3[key4] = value;
				dictionary2[key3] = dictionary3;
				driver.ExecuteCdpCommand(commandName2, dictionary2);
			}
			catch
			{
			}
			Point position = driver.Manage().Window.Position;
			Size size = driver.Manage().Window.Size;
			Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
			int num2 = targetLeft;
			int num3 = targetTop;
			if (num2 < workingArea.Left)
			{
				num2 = workingArea.Left;
			}
			if (num3 < workingArea.Top)
			{
				num3 = workingArea.Top;
			}
			if (num2 + size.Width > workingArea.Right)
			{
				num2 = workingArea.Right - size.Width;
			}
			if (num3 + size.Height > workingArea.Bottom)
			{
				num3 = workingArea.Bottom - size.Height;
			}
			num2 += random.Next(-2, 3);
			num3 += random.Next(-2, 3);
			int num4 = random.Next(0, 3);
			int num5 = random.Next(steps / 3, Math.Max(steps / 3 + 2, steps - 6));
			int num6 = random.Next(120, 220);
			for (int i = 1; i <= steps; i++)
			{
				double t2 = Ease(Math.Min(1.0, (double)(i + num4) / (double)(steps + num4)));
				double t3 = Ease((double)i / (double)steps);
				int num7 = Lerp(position.X, num2, t2);
				int num8 = Lerp(position.Y, num3, t3);
				if (i % 9 == 0)
				{
					num7 += random.Next(-1, 2);
				}
				if (i % 11 == 0)
				{
					num8 += random.Next(-1, 2);
				}
				if (num7 < workingArea.Left)
				{
					num7 = workingArea.Left;
				}
				if (num8 < workingArea.Top)
				{
					num8 = workingArea.Top;
				}
				bool flag = false;
				if (num.HasValue)
				{
					try
					{
						string commandName3 = "Browser.setWindowBounds";
						Dictionary<string, object> dictionary4 = new Dictionary<string, object>();
						string key5 = "windowId";
						dictionary4[key5] = num.Value;
						string key6 = "bounds";
						Dictionary<string, object> dictionary5 = new Dictionary<string, object>();
						string key7 = "left";
						dictionary5[key7] = num7;
						string key8 = "top";
						dictionary5[key8] = num8;
						string key9 = "width";
						dictionary5[key9] = size.Width;
						string key10 = "height";
						dictionary5[key10] = size.Height;
						string key11 = "windowState";
						string value2 = "normal";
						dictionary5[key11] = value2;
						dictionary4[key6] = dictionary5;
						driver.ExecuteCdpCommand(commandName3, dictionary4);
						flag = true;
					}
					catch
					{
						flag = false;
					}
				}
				if (!flag)
				{
					try
					{
						driver.Manage().Window.Position = new Point(num7, num8);
						driver.Manage().Window.Size = new Size(size.Width, size.Height);
					}
					catch
					{
					}
				}
				int num9 = new Random().Next(minDelayMs, maxDelayMs + 1);
				if (i == num5)
				{
					num9 += num6;
				}
				if (i % 13 == 0 && new Random().NextDouble() < 0.3)
				{
					num9 += new Random().Next(25, 60);
				}
				Thread.Sleep(num9);
			}
		}
		catch
		{
		}
		static double Ease(double t)
		{
			return t * t * (3.0 - 2.0 * t);
		}
		static int Lerp(int a, int b, double t)
		{
			if (t < 0.0)
			{
				t = 0.0;
			}
			if (t > 1.0)
			{
				t = 1.0;
			}
			return a + (int)Math.Round((double)(b - a) * t, MidpointRounding.AwayFromZero);
		}
	}

	private double Ease(double t)
	{
		return t * t * (3.0 - 2.0 * t);
	}

	internal void HumanDragLeftEdge(UndetectedChromeDriver driver, int deltaX, int steps = 40, int minDelay = 7, int maxDelay = 20)
	{
		int? num = null;
		try
		{
			string commandName = "Browser.getWindowForTarget";
			Dictionary<string, object> dictionary = (Dictionary<string, object>)driver.ExecuteCdpCommand(commandName, new Dictionary<string, object>());
			string key = "windowId";
			num = Convert.ToInt32(dictionary[key]);
			string commandName2 = "Browser.setWindowBounds";
			Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
			string key2 = "windowId";
			dictionary2[key2] = num.Value;
			string key3 = "bounds";
			Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
			string key4 = "windowState";
			string value = "normal";
			dictionary3[key4] = value;
			dictionary2[key3] = dictionary3;
			driver.ExecuteCdpCommand(commandName2, dictionary2);
		}
		catch
		{
		}
		Point position = driver.Manage().Window.Position;
		Size size = driver.Manage().Window.Size;
		int num2 = position.X + size.Width;
		int num3 = position.X + deltaX;
		int val = num2 - num3;
		val = Math.Max(640, val);
		num3 = Math.Max(0, num2 - val);
		for (int i = 1; i <= steps; i++)
		{
			double t = Ease((double)i / (double)steps);
			int num4 = Lerp(position.X, num3, t);
			if (i % 9 == 0)
			{
				num4 += R.Next(-1, 2);
			}
			int val2 = num2 - num4;
			val2 = Math.Max(640, val2);
			num4 = Math.Max(0, num2 - val2);
			bool flag = false;
			if (num.HasValue)
			{
				try
				{
					string commandName3 = "Browser.setWindowBounds";
					Dictionary<string, object> dictionary4 = new Dictionary<string, object>();
					string key5 = "windowId";
					dictionary4[key5] = num.Value;
					string key6 = "bounds";
					Dictionary<string, object> dictionary5 = new Dictionary<string, object>();
					string key7 = "left";
					dictionary5[key7] = num4;
					string key8 = "top";
					dictionary5[key8] = position.Y;
					string key9 = "width";
					dictionary5[key9] = val2;
					string key10 = "height";
					dictionary5[key10] = size.Height;
					string key11 = "windowState";
					string value2 = "normal";
					dictionary5[key11] = value2;
					dictionary4[key6] = dictionary5;
					driver.ExecuteCdpCommand(commandName3, dictionary4);
					flag = true;
				}
				catch
				{
					flag = false;
				}
			}
			if (!flag)
			{
				driver.Manage().Window.Position = new Point(num4, position.Y);
				driver.Manage().Window.Size = new Size(val2, size.Height);
			}
			int num5 = R.Next(minDelay, maxDelay + 1);
			if (i % 13 == 0 && R.NextDouble() < 0.3)
			{
				num5 += R.Next(30, 80);
			}
			Thread.Sleep(num5);
		}
	}

	internal string RandomizeSixIntBlock(string sensorData, int occurrence = 0)
	{
		if (string.IsNullOrEmpty(sensorData))
		{
			return sensorData;
		}
		Dictionary<int, (int, int)> dictionary = new Dictionary<int, (int, int)>
		{
			{
				0,
				(5, 15)
			},
			{
				4,
				(1, 4)
			},
			{
				5,
				(101, 499)
			}
		};
		string pattern = "(?<=;)(\\d+,\\d+,\\d+,\\d+,\\d+,\\d+)(?=;)";
		MatchCollection matchCollection = new Regex(pattern, RegexOptions.Compiled).Matches(sensorData);
		if (matchCollection.Count == 0 || occurrence < 0 || occurrence >= matchCollection.Count)
		{
			return sensorData;
		}
		Match match = matchCollection[occurrence];
		string[] array = match.Value.Split(',').ToArray();
		foreach (KeyValuePair<int, (int, int)> item in dictionary)
		{
			int key = item.Key;
			if (key >= 0 && key < array.Length)
			{
				var (minValue, num) = item.Value;
				array[key] = Rnd_0.Next(minValue, num + 1).ToString();
			}
		}
		string separator = ",";
		string value = string.Join(separator, array);
		return sensorData.Remove(match.Index, match.Length).Insert(match.Index, value);
	}

	private int Lerp(int a, int b, double t)
	{
		if (t < 0.0)
		{
			t = 0.0;
		}
		if (t > 1.0)
		{
			t = 1.0;
		}
		return a + (int)Math.Round((double)(b - a) * t, MidpointRounding.AwayFromZero);
	}

	public static string CreateProxyExtension(string host, int port, string user, string pass)
	{
		string tempPath = Path.GetTempPath();
		string text = "proxy_ext_";
		Guid guid = Guid.NewGuid();
		string text2 = "N";
		string text3 = Path.Combine(tempPath, text + guid.ToString(text2));
		Directory.CreateDirectory(text3);
		string path = "manifest.json";
		string path2 = Path.Combine(text3, path);
		string contents = "\r\n{\r\n  \"manifest_version\": 2,\r\n  \"name\": \"ProxyAuth\",\r\n  \"version\": \"1.0\",\r\n  \"permissions\": [\r\n    \"proxy\",\r\n    \"tabs\",\r\n    \"unlimitedStorage\",\r\n    \"storage\",\r\n    \"<all_urls>\",\r\n    \"webRequest\",\r\n    \"webRequestBlocking\"\r\n  ],\r\n  \"background\": {\r\n    \"scripts\": [\"background.js\"]\r\n  }\r\n}\r\n";
		File.WriteAllText(path2, contents);
		string text4 = "\r\nvar config = {\r\n  mode: 'fixed_servers',\r\n  rules: {\r\n    singleProxy: {\r\n      scheme: 'http',\r\n      host: 'b5978d8b0cb1d584.uvb.as.pyproxy.io',\r\n      port: 16666\r\n    },\r\n    bypassList: ['localhost']\r\n  }\r\n};\r\n\r\nchrome.proxy.settings.set({value: config, scope: 'regular'}, function() {});\r\n\r\nchrome.webRequest.onAuthRequired.addListener(\r\n  function(details) {\r\n    return {\r\n      authCredentials: {\r\n        username: 'SpaxeX121-zone-resi-region-in',\r\n        password: 'xfce4t5vhbdvr'\r\n      }\r\n    };\r\n  },\r\n  {urls: ['<all_urls>']},\r\n  ['blocking']\r\n);\r\n";
		string contents2 = text4;
		string path3 = "background.js";
		File.WriteAllText(Path.Combine(text3, path3), contents2);
		string text5 = ".zip";
		string text6 = text3 + text5;
		CreateZipSharp(text3, text6);
		return text6;
	}

	public static void CreateZipSharp(string sourceDir, string zipPath)
	{
		try
		{
			using FileStream baseOutputStream = File.Create(zipPath);
			using ZipOutputStream zipOutputStream = new ZipOutputStream(baseOutputStream);
			zipOutputStream.SetLevel(3);
			string[] files = Directory.GetFiles(sourceDir);
			string[] array = files;
			string[] array2 = array;
			foreach (string text in array2)
			{
				FileInfo fileInfo = new FileInfo(text);
				ZipEntry entry = new ZipEntry(fileInfo.Name)
				{
					DateTime = fileInfo.LastWriteTime,
					Size = fileInfo.Length
				};
				zipOutputStream.PutNextEntry(entry);
				byte[] array3 = File.ReadAllBytes(text);
				zipOutputStream.Write(array3, 0, array3.Length);
				zipOutputStream.CloseEntry();
			}
			zipOutputStream.IsStreamOwner = true;
		}
		catch (Exception)
		{
		}
	}

	public static List<string> GetChromeProfiles(string userDataDir)
	{
		List<string> list = new List<string>();
		string[] directories = Directory.GetDirectories(userDataDir);
		for (int i = 0; i < directories.Length; i++)
		{
			string fileName = Path.GetFileName(directories[i]);
			string text = "Default";
			if (!(fileName == text))
			{
				string value = "Profile";
				if (!fileName.StartsWith(value))
				{
					continue;
				}
			}
			list.Add(fileName);
		}
		return list;
	}

	public static void CloseChromeUsingProfile(string userDataDir, string profile)
	{
		string text = "--profile-directory=";
		_ = text + profile;
		string queryString = "SELECT ProcessId, CommandLine FROM Win32_Process WHERE Name='chrome.exe'";
		foreach (ManagementObject item in new ManagementObjectSearcher(queryString).Get())
		{
			string propertyName = "CommandLine";
			string text2 = item[propertyName]?.ToString();
			if (!string.IsNullOrEmpty(text2) && text2.Contains(userDataDir) && text2.Contains(profile))
			{
				string propertyName2 = "ProcessId";
				int processId = Convert.ToInt32(item[propertyName2]);
				try
				{
					Process.GetProcessById(processId).Kill();
				}
				catch
				{
				}
			}
		}
	}

	private void KillAllBraveProcesses()
	{
		try
		{
			Process[] processesByName = Process.GetProcessesByName("brave");
			Process[] array = processesByName;
			foreach (Process process in array)
			{
				try
				{
					int id = process.Id;
					process.Kill();
					process.WaitForExit(2000);
					Console.WriteLine($"[Success] Brave Process (PID: {id}) killed.");
				}
				catch (Exception ex)
				{
					Console.WriteLine($"[Kill Error] PID {process.Id}: {ex.Message}");
				}
			}
		}
		catch (Exception ex2)
		{
			Console.WriteLine("[Cleanup Error]: " + ex2.Message);
		}
	}

	private void KillOldBraveByProfile(string profilePath)
	{
		if (string.IsNullOrEmpty(profilePath))
		{
			return;
		}
		try
		{
			Console.WriteLine("[Cleanup] " + profilePath + " wali Brave profile ko close kar rahe hain...");
			string queryString = "SELECT ProcessId, CommandLine FROM Win32_Process WHERE Name='brave.exe'";
			using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(queryString);
			foreach (ManagementObject item in managementObjectSearcher.Get())
			{
				string text = item["CommandLine"]?.ToString() ?? "";
				if (text.IndexOf(profilePath, StringComparison.OrdinalIgnoreCase) >= 0)
				{
					int num = Convert.ToInt32(item["ProcessId"]);
					try
					{
						Process processById = Process.GetProcessById(num);
						processById.Kill();
						processById.WaitForExit(1000);
						Console.WriteLine($"[Success] Brave Process (PID: {num}) killed.");
					}
					catch (Exception ex)
					{
						Console.WriteLine($"[Kill Error] PID {num}: {ex.Message}");
					}
				}
			}
		}
		catch (Exception ex2)
		{
			Console.WriteLine("[Cleanup Error]: " + ex2.Message);
		}
	}

	private void KillOldChromeByProfile(string profilePath)
	{
		if (string.IsNullOrEmpty(profilePath))
		{
			return;
		}
		try
		{
			Console.WriteLine("[Cleanup] " + profilePath + " wali profile ko close kar rahe hain...");
			string queryString = "SELECT ProcessId, CommandLine FROM Win32_Process WHERE Name='chrome.exe'";
			using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(queryString);
			foreach (ManagementObject item in managementObjectSearcher.Get())
			{
				string text = item["CommandLine"]?.ToString() ?? "";
				if (text.IndexOf(profilePath, StringComparison.OrdinalIgnoreCase) >= 0)
				{
					int num = Convert.ToInt32(item["ProcessId"]);
					try
					{
						Process processById = Process.GetProcessById(num);
						processById.Kill();
						processById.WaitForExit(1000);
						Console.WriteLine($"[Success] Chrome Process (PID: {num}) killed.");
					}
					catch (Exception ex)
					{
						Console.WriteLine($"[Kill Error] PID {num}: {ex.Message}");
					}
				}
			}
		}
		catch (Exception ex2)
		{
			Console.WriteLine("[Cleanup Error]: " + ex2.Message);
		}
	}

	public static void CopyDirectorySafe(string sourceDir, string targetDir)
	{
		Directory.CreateDirectory(targetDir);
		string[] files = Directory.GetFiles(sourceDir);
		string[] array = files;
		string[] array2 = array;
		foreach (string text in array2)
		{
			try
			{
				string fileName = Path.GetFileName(text);
				string value = "Cookies";
				if (fileName.Contains(value))
				{
					continue;
				}
				string value2 = "History";
				if (fileName.Contains(value2))
				{
					continue;
				}
				string value3 = "Login Data";
				if (!fileName.Contains(value3))
				{
					string value4 = "Web Data";
					if (!fileName.Contains(value4))
					{
						string destFileName = Path.Combine(targetDir, fileName);
						File.Copy(text, destFileName, overwrite: true);
					}
				}
			}
			catch
			{
			}
		}
		files = Directory.GetDirectories(sourceDir);
		string[] array3 = files;
		string[] array4 = array3;
		foreach (string text2 in array4)
		{
			string fileName2 = Path.GetFileName(text2);
			string text3 = "Cache";
			if (fileName2 == text3)
			{
				continue;
			}
			string text4 = "Code Cache";
			if (fileName2 == text4)
			{
				continue;
			}
			string text5 = "GPUCache";
			if (!(fileName2 == text5))
			{
				string text6 = "Crashpad";
				if (!(fileName2 == text6))
				{
					string targetDir2 = Path.Combine(targetDir, fileName2);
					CopyDirectorySafe(text2, targetDir2);
				}
			}
		}
	}

	internal UndetectedChromeDriver loadDriver0(ref string userDataDir00, Rectangle rect)
	{
		Guid guid = Guid.NewGuid();
		string text = "N";
		string text2 = guid.ToString(text);
		string tempPath = Path.GetTempPath();
		string text3 = "uc_";
		userDataDir00 = Path.Combine(tempPath, text3 + text2);
		Random random = new Random();
		ChromeOptions chromeOptions = new ChromeOptions();
		string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
		string text4 = "\\Google\\Chrome\\User Data";
		CopyDirectorySafe(folderPath + text4, userDataDir00);
		GetChromeProfiles(userDataDir00);
		string text5 = "Default";
		string text6 = text5;
		string text7 = "--user-data-dir=";
		chromeOptions.AddArgument(text7 + userDataDir00);
		string text8 = "--profile-directory=";
		chromeOptions.AddArgument(text8 + text6);
		string text9 = Path.Combine(userDataDir00, text6);
		Directory.CreateDirectory(text9);
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		string key = "credentials_enable_service";
		dictionary[key] = false;
		string key2 = "profile";
		Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
		string key3 = "password_manager_enabled";
		dictionary2[key3] = false;
		string key4 = "default_content_setting_values";
		Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
		string key5 = "notifications";
		dictionary3[key5] = 2;
		string key6 = "geolocation";
		dictionary3[key6] = 2;
		string key7 = "media_stream_mic";
		dictionary3[key7] = 2;
		string key8 = "media_stream_camera";
		dictionary3[key8] = 2;
		dictionary2[key4] = dictionary3;
		dictionary[key2] = dictionary2;
		string key9 = "offer_to_save_passwords";
		dictionary[key9] = false;
		string key10 = "autofill";
		Dictionary<string, object> dictionary4 = new Dictionary<string, object>();
		string key11 = "profile_enabled";
		dictionary4[key11] = false;
		string key12 = "credit_card_enabled";
		dictionary4[key12] = false;
		string key13 = "address_enabled";
		dictionary4[key13] = false;
		dictionary[key10] = dictionary4;
		Dictionary<string, object> value = dictionary;
		string path = "Preferences";
		string path2 = Path.Combine(text9, path);
		if (!File.Exists(path2))
		{
			string contents = JsonConvert.SerializeObject(value, Formatting.Indented);
			File.WriteAllText(path2, contents);
		}
		string argument = "--disable-blink-features=AutomationControlled";
		chromeOptions.AddArgument(argument);
		string argument2 = "--ignore-certificate-errors";
		chromeOptions.AddArgument(argument2);
		string argument3 = "--ignore-certificate-errors-spki-list";
		chromeOptions.AddArgument(argument3);
		string startupPath = Application.StartupPath;
		string path3 = "chromedriver.exe";
		string driverExecutablePath = Path.Combine(startupPath, path3);
		driver = UndetectedChromeDriver.Create(chromeOptions, null, driverExecutablePath, null, 0, 0, headless: false, noSandbox: true, suppressWelcome: true, hideCommandPromptWindow: false, null, null, delegate(ChromeDriverService service)
		{
			service.HideCommandPromptWindow = true;
			service.SuppressInitialDiagnosticInformation = true;
		});
		IJavaScriptExecutor javaScriptExecutor = driver;
		string script = "Object.defineProperty(navigator, 'webdriver', {get: () => undefined})";
		javaScriptExecutor.ExecuteScript(script);
		string clientID = Program.clientID;
		string text10 = "SGX9777";
		if (clientID != text10)
		{
			string script2 = "\r\n        document.addEventListener('contextmenu', e => e.preventDefault());\r\n        document.onkeydown = function(e) {\r\n            if (e.keyCode == 123 || \r\n                (e.ctrlKey && e.shiftKey && (e.keyCode == 73 || e.keyCode == 74)) ||\r\n                (e.ctrlKey && e.keyCode == 85)) {\r\n                e.preventDefault();\r\n                return false;\r\n            }\r\n        };\r\n        ";
			javaScriptExecutor.ExecuteScript(script2);
		}
		IntPtr intPtr = ChromeTaskbarHider.FindBrowserWindowByUserDataDir(userDataDir00);
		if (intPtr != IntPtr.Zero)
		{
			ChromeTaskbarHider.HideFromTaskbar(intPtr);
		}
		int height = Screen.PrimaryScreen.WorkingArea.Height - random.Next(225, 250);
		driver.Manage().Window.Size = new Size(rect.Width, height);
		return driver;
	}

	internal UndetectedChromeDriver LoadCometDriver(ref string userDataDir, Rectangle rect)
	{
		Random random = new Random();
		userDataDir = Path.Combine(Path.GetTempPath(), "uc_" + Guid.NewGuid().ToString("N"));
		Directory.CreateDirectory(userDataDir);
		ChromeOptions chromeOptions = new ChromeOptions();
		string text = "C:\\Program Files\\Perplexity\\Comet\\Application\\comet.exe";
		if (!File.Exists(text))
		{
			MessageBox.Show("Comet Browser not found. Please install it in the default path.");
			return null;
		}
		chromeOptions.BinaryLocation = text;
		chromeOptions.AddArgument("--app=https://www.irctc.co.in");
		chromeOptions.AddArgument("--disable-infobars");
		chromeOptions.AddArgument("--disable-blink-features=AutomationControlled");
		chromeOptions.AddArgument("--ignore-certificate-errors");
		chromeOptions.AddArgument("--ignore-certificate-errors-spki-list");
		chromeOptions.AddArgument($"--window-position={rect.Left},0");
		chromeOptions.AddArgument("--user-data-dir=" + userDataDir);
		string text2 = Path.Combine(userDataDir, "Default");
		Directory.CreateDirectory(text2);
		Dictionary<string, object> value = new Dictionary<string, object>
		{
			["credentials_enable_service"] = false,
			["profile"] = new Dictionary<string, object>
			{
				["password_manager_enabled"] = false,
				["default_content_setting_values"] = new Dictionary<string, object>
				{
					["notifications"] = 2,
					["geolocation"] = 2,
					["media_stream_mic"] = 2,
					["media_stream_camera"] = 2
				}
			},
			["offer_to_save_passwords"] = false,
			["autofill"] = new Dictionary<string, object>
			{
				["profile_enabled"] = false,
				["credit_card_enabled"] = false,
				["address_enabled"] = false
			}
		};
		File.WriteAllText(Path.Combine(text2, "Preferences"), JsonConvert.SerializeObject(value, Formatting.Indented));
		chromeOptions.AddAdditionalOption("webrtc.ip_handling_policy", "disable_non_proxied_udp");
		chromeOptions.AddAdditionalOption("webrtc.multiple_routes_enabled", false);
		chromeOptions.AddAdditionalOption("webrtc.nonproxied_udp_enabled", false);
		string text3 = Path.Combine(Application.StartupPath, "chromedriver_comet.exe");
		if (!File.Exists(text3))
		{
			MessageBox.Show("Chromedriver for Comet not found! Make sure the version matches Comet's Chromium.");
			return null;
		}
		UndetectedChromeDriver undetectedChromeDriver = UndetectedChromeDriver.Create(chromeOptions, null, text3, null, 0, 0, headless: false, noSandbox: true, suppressWelcome: true, hideCommandPromptWindow: true, null, null, delegate(ChromeDriverService service)
		{
			service.HideCommandPromptWindow = true;
			service.SuppressInitialDiagnosticInformation = true;
		});
		((IJavaScriptExecutor)undetectedChromeDriver).ExecuteScript("Object.defineProperty(navigator, 'webdriver', {get: () => undefined})", Array.Empty<object>());
		if (Program.clientID != "SGX9777")
		{
			((IJavaScriptExecutor)undetectedChromeDriver).ExecuteScript("\r\n            document.addEventListener('contextmenu', e => e.preventDefault());\r\n            document.onkeydown = function(e) {\r\n                if (e.keyCode == 123 || \r\n                    (e.ctrlKey && e.shiftKey && (e.keyCode == 73 || e.keyCode == 74)) ||\r\n                    (e.ctrlKey && e.keyCode == 85)) {\r\n                    e.preventDefault();\r\n                    return false;\r\n                }\r\n            };\r\n        ", Array.Empty<object>());
		}
		IntPtr intPtr = ChromeTaskbarHider.FindBrowserWindowByUserDataDir(userDataDir);
		if (intPtr != IntPtr.Zero)
		{
			ChromeTaskbarHider.HideFromTaskbar(intPtr);
		}
		int height = Screen.PrimaryScreen.WorkingArea.Height - random.Next(225, 250);
		undetectedChromeDriver.Manage().Window.Size = new Size(rect.Width, height);
		LoadCookiesIntoSelenium_comet(undetectedChromeDriver);
		return undetectedChromeDriver;
	}

	internal UndetectedChromeDriver loadDriver(ref string userDataDir00, string directlogin, Rectangle rect, string empty)
	{
		if (!string.IsNullOrEmpty(userDataDir00))
		{
			KillOldChromeByProfile(userDataDir00);
		}
		string text = "";
		Random random = new Random();
		userDataDir00 = Path.Combine(Path.GetTempPath(), "uc_" + Guid.NewGuid().ToString("N"));
		ChromeOptions chromeOptions = new ChromeOptions();
		string text2 = "<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n <meta charset=\"UTF-8\">\r\n <title>Hitman</title>\r\n <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n\r\n <style>\r\n body {\r\n margin: 0;\r\n padding: 0;\r\n background: radial-gradient(circle at top, #111 0%, #000 70%);\r\n display: flex;\r\n justify-content: center;\r\n align-items: center;\r\n height: 100vh;\r\n font-family: Arial, Helvetica, sans-serif;\r\n color: white;\r\n }\r\n\r\n .container {\r\n text-align: center;\r\n }\r\n\r\n .container img {\r\n max-width: 420px;\r\n width: 80%;\r\n filter: drop-shadow(0 0 25px rgba(255,255,255,0.25));\r\n }\r\n\r\n .title {\r\n margin-top: 20px;\r\n font-size: 28px;\r\n letter-spacing: 3px;\r\n }\r\n\r\n .subtitle {\r\n margin-top: 6px;\r\n font-size: 14px;\r\n color: #aaa;\r\n }\r\n </style>\r\n</head>\r\n<body>\r\n\r\n <div class=\"container\">\r\n <!-- Hitman Logo Image -->\r\n <img src=\"data:image/jpeg;base64,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\" alt=\"Hitman Logo\">\r\n\r\n <div class=\"subtitle\">Trusted Software Solutions for Secure and Fast Bookings</div>\r\n </div>\r\n\r\n</body>\r\n</html>\r\n";
		string s = text2;
		Convert.ToBase64String(Encoding.UTF8.GetBytes(s));
		string argument = "--app=https://www.irctc.co.in";
		chromeOptions.AddArgument(argument);
		string argument2 = "--disable-infobars";
		chromeOptions.AddArgument(argument2);
		string path = userDataDir00;
		string path2 = "Default";
		string text3 = Path.Combine(path, path2);
		Directory.CreateDirectory(text3);
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		string key = "credentials_enable_service";
		dictionary[key] = false;
		string key2 = "profile";
		Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
		string key3 = "password_manager_enabled";
		dictionary2[key3] = false;
		string key4 = "default_content_setting_values";
		Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
		string key5 = "notifications";
		dictionary3[key5] = 2;
		string key6 = "geolocation";
		dictionary3[key6] = 2;
		string key7 = "media_stream_mic";
		dictionary3[key7] = 2;
		string key8 = "media_stream_camera";
		dictionary3[key8] = 2;
		dictionary2[key4] = dictionary3;
		dictionary[key2] = dictionary2;
		string key9 = "offer_to_save_passwords";
		dictionary[key9] = false;
		string key10 = "autofill";
		Dictionary<string, object> dictionary4 = new Dictionary<string, object>();
		string key11 = "profile_enabled";
		dictionary4[key11] = false;
		string key12 = "credit_card_enabled";
		dictionary4[key12] = false;
		string key13 = "address_enabled";
		dictionary4[key13] = false;
		dictionary[key10] = dictionary4;
		Dictionary<string, object> value = dictionary;
		if (clsMain.WB_ChromeBeta)
		{
			text = GetChromeBetaPath();
			if (string.IsNullOrEmpty(text))
			{
				string text4 = "Chrome Beta nahi mila! Please install karein.";
				MessageBox.Show(text4);
				return null;
			}
		}
		string path3 = "Preferences";
		string path4 = Path.Combine(text3, path3);
		string contents = JsonConvert.SerializeObject(value, Formatting.Indented);
		File.WriteAllText(path4, contents);
		string argument3 = "--disable-blink-features=AutomationControlled";
		chromeOptions.AddArgument(argument3);
		string argument4 = "--ignore-certificate-errors";
		chromeOptions.AddArgument(argument4);
		string argument5 = "--ignore-certificate-errors-spki-list";
		chromeOptions.AddArgument(argument5);
		string text5 = "--window-position=";
		string text6 = rect.Left.ToString();
		string text7 = ",0";
		chromeOptions.AddArgument(text5 + text6 + text7);
		string text8 = "--user-data-dir=";
		chromeOptions.AddArgument(text8 + userDataDir00);
		if (empty.Length > 10 && File.Exists("Titanium.Web.Proxy.dll"))
		{
			string[] array = empty.Split(new string[1] { "||" }, StringSplitOptions.None);
			string host = array[0];
			int port = int.Parse(array[1]);
			string user = array[2];
			string pass = array[3];
			int num = 5555;
			num = GetFreePort();
			ProxyServer proxyServer = StartLocalProxy(host, port, user, pass, num);
			chromeOptions.AddArgument($"--proxy-server=http://127.0.0.1:{num}");
		}
		Dictionary<string, object> dictionary5 = new Dictionary<string, object>();
		string key14 = "webrtc.ip_handling_policy";
		string value2 = "disable_non_proxied_udp";
		dictionary5[key14] = value2;
		string key15 = "webrtc.multiple_routes_enabled";
		dictionary5[key15] = false;
		string key16 = "webrtc.nonproxied_udp_enabled";
		dictionary5[key16] = false;
		string startupPath = Application.StartupPath;
		string path5 = "chromedriver.exe";
		string driverExecutablePath = Path.Combine(startupPath, path5);
		driver = UndetectedChromeDriver.Create(chromeOptions, null, driverExecutablePath, null, 0, 0, headless: false, noSandbox: true, suppressWelcome: true, hideCommandPromptWindow: false, null, null, delegate(ChromeDriverService service)
		{
			service.HideCommandPromptWindow = true;
			service.SuppressInitialDiagnosticInformation = true;
		});
		IJavaScriptExecutor javaScriptExecutor = driver;
		IJavaScriptExecutor javaScriptExecutor2 = javaScriptExecutor;
		string script = "Object.defineProperty(navigator, 'webdriver', {get: () => undefined})";
		javaScriptExecutor2.ExecuteScript(script);
		javaScriptExecutor = driver;
		string clientID = Program.clientID;
		string text9 = "SGX9777";
		if (clientID != text9)
		{
			IJavaScriptExecutor javaScriptExecutor3 = javaScriptExecutor;
			string script2 = "\r\n    document.addEventListener('contextmenu', e => e.preventDefault());\r\n    document.onkeydown = function(e) {\r\n        if (e.keyCode == 123 || \r\n            (e.ctrlKey && e.shiftKey && (e.keyCode == 73 || e.keyCode == 74)) ||\r\n            (e.ctrlKey && e.keyCode == 85)) {\r\n            e.preventDefault();\r\n            return false;\r\n        }\r\n    };\r\n";
			javaScriptExecutor3.ExecuteScript(script2);
		}
		IntPtr intPtr = ChromeTaskbarHider.FindBrowserWindowByUserDataDir(userDataDir00);
		if (intPtr != IntPtr.Zero)
		{
			ChromeTaskbarHider.HideFromTaskbar(intPtr);
		}
		int height = Screen.PrimaryScreen.WorkingArea.Height - random.Next(225, 250);
		driver.Manage().Window.Size = new Size(rect.Width, height);
		if (directlogin != "True")
		{
			LoadCookiesIntoSelenium(driver);
		}
		return driver;
	}

	internal UndetectedChromeDriver loadDriverbrvvvvv(ref string userDataDir00, Rectangle rect)
	{
		string text = "";
		KillAllBraveProcesses();
		Random random = new Random();
		userDataDir00 = Path.Combine(Path.GetTempPath(), "uc_" + Guid.NewGuid().ToString("N"));
		ChromeOptions chromeOptions = new ChromeOptions();
		string bravePath = GetBravePath();
		if (!File.Exists(bravePath))
		{
			MessageBox.Show("Brave Browser install nahi hai.");
			return null;
		}
		chromeOptions.BinaryLocation = bravePath;
		string text2 = Path.Combine(userDataDir00, "Default");
		Directory.CreateDirectory(text2);
		Dictionary<string, object> value = new Dictionary<string, object>
		{
			["credentials_enable_service"] = false,
			["profile"] = new Dictionary<string, object>
			{
				["password_manager_enabled"] = false,
				["default_content_setting_values"] = new Dictionary<string, object>
				{
					["notifications"] = 2,
					["geolocation"] = 2,
					["media_stream_mic"] = 2,
					["media_stream_camera"] = 2
				}
			},
			["offer_to_save_passwords"] = false,
			["autofill"] = new Dictionary<string, object>
			{
				["profile_enabled"] = false,
				["credit_card_enabled"] = false,
				["address_enabled"] = false
			}
		};
		string path = Path.Combine(text2, "Preferences");
		string contents = JsonConvert.SerializeObject(value, Formatting.Indented);
		File.WriteAllText(path, contents);
		chromeOptions.AddArgument("--app=[irctc.co.in](https://www.irctc.co.in)");
		chromeOptions.AddArgument("--disable-infobars");
		chromeOptions.AddArgument("--disable-blink-features=AutomationControlled");
		chromeOptions.AddArgument("--ignore-certificate-errors");
		chromeOptions.AddArgument("--window-position=" + rect.Left + ",0");
		chromeOptions.AddArgument("--user-data-dir=" + userDataDir00);
		chromeOptions.AddArgument("--no-default-browser-check");
		chromeOptions.AddArgument("--disable-default-apps");
		string driverExecutablePath = Path.Combine(Application.StartupPath, "chromedriver.exe");
		driver = UndetectedChromeDriver.Create(chromeOptions, userDataDir00, driverExecutablePath, bravePath, 0, 0, headless: false, noSandbox: true, suppressWelcome: true, hideCommandPromptWindow: true, null);
		IJavaScriptExecutor javaScriptExecutor = driver;
		javaScriptExecutor.ExecuteScript("Object.defineProperty(navigator, 'webdriver', {get: () => undefined})");
		if (Program.clientID != "SGX9777")
		{
			string script = "\r\n            document.addEventListener('contextmenu', e => e.preventDefault());\r\n            document.onkeydown = function(e) {\r\n                if (e.keyCode == 123 || (e.ctrlKey && e.shiftKey && (e.keyCode == 73 || e.keyCode == 74)) || (e.ctrlKey && e.keyCode == 85)) {\r\n                    e.preventDefault();\r\n                    return false;\r\n                }\r\n            };";
			javaScriptExecutor.ExecuteScript(script);
		}
		IntPtr intPtr = ChromeTaskbarHider.FindBrowserWindowByUserDataDir(userDataDir00);
		if (intPtr != IntPtr.Zero)
		{
			ChromeTaskbarHider.HideFromTaskbar(intPtr);
		}
		int height = Screen.PrimaryScreen.WorkingArea.Height - random.Next(225, 250);
		driver.Manage().Window.Size = new Size(rect.Width, height);
		return driver;
	}

	internal UndetectedChromeDriver loadDriverbrv(ref string userDataDir00, Rectangle rect)
	{
		string text = "";
		KillAllBraveProcesses();
		Random random = new Random();
		userDataDir00 = Path.Combine(Path.GetTempPath(), "uc_" + Guid.NewGuid().ToString("N"));
		ChromeOptions chromeOptions = new ChromeOptions();
		string bravePath = GetBravePath();
		if (!File.Exists(bravePath))
		{
			MessageBox.Show("Brave Browser install nahi hai.");
			return null;
		}
		chromeOptions.BinaryLocation = bravePath;
		string text2 = "<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n <meta charset=\"UTF-8\">\r\n <title>Hitman</title>\r\n <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n\r\n <style>\r\n body {\r\n margin: 0;\r\n padding: 0;\r\n background: radial-gradient(circle at top, #111 0%, #000 70%);\r\n display: flex;\r\n justify-content: center;\r\n align-items: center;\r\n height: 100vh;\r\n font-family: Arial, Helvetica, sans-serif;\r\n color: white;\r\n }\r\n\r\n .container {\r\n text-align: center;\r\n }\r\n\r\n .container img {\r\n max-width: 420px;\r\n width: 80%;\r\n filter: drop-shadow(0 0 25px rgba(255,255,255,0.25));\r\n }\r\n\r\n .title {\r\n margin-top: 20px;\r\n font-size: 28px;\r\n letter-spacing: 3px;\r\n }\r\n\r\n .subtitle {\r\n margin-top: 6px;\r\n font-size: 14px;\r\n color: #aaa;\r\n }\r\n </style>\r\n</head>\r\n<body>\r\n\r\n <div class=\"container\">\r\n <!-- Hitman Logo Image -->\r\n <img src=\"data:image/jpeg;base64,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\" alt=\"Hitman Logo\">\r\n\r\n <div class=\"subtitle\">Trusted Software Solutions for Secure and Fast Bookings</div>\r\n </div>\r\n\r\n</body>\r\n</html>\r\n";
		string s = text2;
		Convert.ToBase64String(Encoding.UTF8.GetBytes(s));
		string argument = "--app=https://www.irctc.co.in";
		chromeOptions.AddArgument(argument);
		string argument2 = "--disable-infobars";
		chromeOptions.AddArgument(argument2);
		string path = userDataDir00;
		string path2 = "Default";
		string text3 = Path.Combine(path, path2);
		Directory.CreateDirectory(text3);
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		string key = "credentials_enable_service";
		dictionary[key] = false;
		string key2 = "profile";
		Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
		string key3 = "password_manager_enabled";
		dictionary2[key3] = false;
		string key4 = "default_content_setting_values";
		Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
		string key5 = "notifications";
		dictionary3[key5] = 2;
		string key6 = "geolocation";
		dictionary3[key6] = 2;
		string key7 = "media_stream_mic";
		dictionary3[key7] = 2;
		string key8 = "media_stream_camera";
		dictionary3[key8] = 2;
		dictionary2[key4] = dictionary3;
		dictionary[key2] = dictionary2;
		string key9 = "offer_to_save_passwords";
		dictionary[key9] = false;
		string key10 = "autofill";
		Dictionary<string, object> dictionary4 = new Dictionary<string, object>();
		string key11 = "profile_enabled";
		dictionary4[key11] = false;
		string key12 = "credit_card_enabled";
		dictionary4[key12] = false;
		string key13 = "address_enabled";
		dictionary4[key13] = false;
		dictionary[key10] = dictionary4;
		Dictionary<string, object> value = dictionary;
		string path3 = "Preferences";
		string path4 = Path.Combine(text3, path3);
		string contents = JsonConvert.SerializeObject(value, Formatting.Indented);
		File.WriteAllText(path4, contents);
		string argument3 = "--disable-blink-features=AutomationControlled";
		chromeOptions.AddArgument(argument3);
		string argument4 = "--ignore-certificate-errors";
		chromeOptions.AddArgument(argument4);
		string argument5 = "--ignore-certificate-errors-spki-list";
		chromeOptions.AddArgument(argument5);
		string text4 = "--window-position=";
		string text5 = rect.Left.ToString();
		string text6 = ",0";
		chromeOptions.AddArgument(text4 + text5 + text6);
		string text7 = "--user-data-dir=";
		chromeOptions.AddArgument(text7 + userDataDir00);
		Dictionary<string, object> dictionary5 = new Dictionary<string, object>();
		string key14 = "webrtc.ip_handling_policy";
		string value2 = "disable_non_proxied_udp";
		dictionary5[key14] = value2;
		string key15 = "webrtc.multiple_routes_enabled";
		dictionary5[key15] = false;
		string key16 = "webrtc.nonproxied_udp_enabled";
		dictionary5[key16] = false;
		string startupPath = Application.StartupPath;
		string path5 = "chromedriver.exe";
		string driverExecutablePath = Path.Combine(startupPath, path5);
		driver = UndetectedChromeDriver.Create(chromeOptions, null, driverExecutablePath, null, 0, 0, headless: false, noSandbox: true, suppressWelcome: true, hideCommandPromptWindow: false, null, null, delegate(ChromeDriverService service)
		{
			service.HideCommandPromptWindow = true;
			service.SuppressInitialDiagnosticInformation = true;
		});
		IJavaScriptExecutor javaScriptExecutor = driver;
		IJavaScriptExecutor javaScriptExecutor2 = javaScriptExecutor;
		string script = "Object.defineProperty(navigator, 'webdriver', {get: () => undefined})";
		javaScriptExecutor2.ExecuteScript(script);
		javaScriptExecutor = driver;
		string clientID = Program.clientID;
		string text8 = "SGX9777";
		if (clientID != text8)
		{
			IJavaScriptExecutor javaScriptExecutor3 = javaScriptExecutor;
			string script2 = "\r\n    document.addEventListener('contextmenu', e => e.preventDefault());\r\n    document.onkeydown = function(e) {\r\n        if (e.keyCode == 123 || \r\n            (e.ctrlKey && e.shiftKey && (e.keyCode == 73 || e.keyCode == 74)) ||\r\n            (e.ctrlKey && e.keyCode == 85)) {\r\n            e.preventDefault();\r\n            return false;\r\n        }\r\n    };\r\n";
			javaScriptExecutor3.ExecuteScript(script2);
		}
		IntPtr intPtr = ChromeTaskbarHider.FindBrowserWindowByUserDataDir(userDataDir00);
		if (intPtr != IntPtr.Zero)
		{
			ChromeTaskbarHider.HideFromTaskbar(intPtr);
		}
		int height = Screen.PrimaryScreen.WorkingArea.Height - random.Next(225, 250);
		driver.Manage().Window.Size = new Size(rect.Width, height);
		return driver;
	}

	private static ProxyServer StartLocalProxy(string host, int port, string user, string pass, int localPort)
	{
		ProxyServer proxyServer = new ProxyServer();
		ExplicitProxyEndPoint endPoint = new ExplicitProxyEndPoint(IPAddress.Any, localPort, decryptSsl: false);
		proxyServer.AddEndPoint(endPoint);
		proxyServer.CertificateManager.CreateRootCertificate(persistToFile: false);
		string text = GenerateAndSaveRootCertificate(proxyServer);
		X509Certificate2 x509Certificate = new X509Certificate2(text);
		if (!IsCertificateInstalled(x509Certificate.Thumbprint))
		{
			InstallCertificate(text);
		}
		proxyServer.UpStreamHttpProxy = new ExternalProxy
		{
			HostName = host,
			Port = port,
			UserName = user,
			Password = pass
		};
		proxyServer.Start();
		return proxyServer;
	}

	public static void InstallCertificate(string certPath)
	{
		X509Certificate2 certificate = new X509Certificate2(certPath);
		using X509Store x509Store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
		x509Store.Open(OpenFlags.ReadWrite);
		x509Store.Add(certificate);
		x509Store.Close();
	}

	public static bool IsCertificateInstalled(string thumbprint)
	{
		using (X509Store x509Store = new X509Store(StoreName.Root, StoreLocation.LocalMachine))
		{
			x509Store.Open(OpenFlags.ReadOnly);
			X509Certificate2Enumerator enumerator = x509Store.Certificates.GetEnumerator();
			while (enumerator.MoveNext())
			{
				X509Certificate2 current = enumerator.Current;
				if (current.Thumbprint.Equals(thumbprint, StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}
		}
		return false;
	}

	public static string GenerateAndSaveRootCertificate(ProxyServer proxyServer)
	{
		proxyServer.CertificateManager.CreateRootCertificate(persistToFile: false);
		X509Certificate2 rootCertificate = proxyServer.CertificateManager.RootCertificate;
		string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Titanium.Web.Proxy");
		Directory.CreateDirectory(text);
		string text2 = Path.Combine(text, "rootCert.pfx");
		File.WriteAllBytes(text2, rootCertificate.Export(X509ContentType.Pfx));
		return text2;
	}

	internal UndetectedChromeDriver loadDriverBBBBB(ref string userDataDir00, Rectangle rect, string proxyString = "")
	{
		string text = "";
		Random random = new Random();
		userDataDir00 = Path.Combine(Path.GetTempPath(), "uc_" + Guid.NewGuid().ToString("N"));
		ChromeOptions chromeOptions = new ChromeOptions();
		chromeOptions.AddArgument("--app=https://www.irctc.co.in");
		chromeOptions.AddArgument("--disable-infobars");
		chromeOptions.AddArgument("--disable-blink-features=AutomationControlled");
		chromeOptions.AddArgument("--ignore-certificate-errors");
		chromeOptions.AddArgument("--ignore-certificate-errors-spki-list");
		chromeOptions.AddArgument("--disable-notifications");
		chromeOptions.AddArgument("--disable-popup-blocking");
		chromeOptions.AddArgument("--no-default-browser-check");
		chromeOptions.AddArgument("--disable-dev-shm-usage");
		chromeOptions.AddArgument("--no-first-run");
		chromeOptions.AddArgument("--disable-default-apps");
		chromeOptions.AddArgument("--disable-background-networking");
		chromeOptions.AddArgument("--disable-sync");
		chromeOptions.AddArgument("--window-position=" + rect.Left + ",0");
		chromeOptions.AddArgument("--user-data-dir=" + userDataDir00);
		chromeOptions.AddArgument("--start-maximized");
		if (!string.IsNullOrWhiteSpace(proxyString))
		{
			try
			{
				if (File.Exists("Titanium.Web.Proxy.dll"))
				{
					string[] array = proxyString.Split(new string[1] { "||" }, StringSplitOptions.None);
					if (array.Length >= 4)
					{
						string host = array[0];
						int port = int.Parse(array[1]);
						string user = array[2];
						string pass = array[3];
						int freePort = GetFreePort();
						ProxyServer proxyServer = StartLocalProxy(host, port, user, pass, freePort);
						chromeOptions.AddArgument($"--proxy-server=http://127.0.0.1:{freePort}");
					}
				}
			}
			catch
			{
			}
		}
		string text2 = Path.Combine(userDataDir00, "Default");
		Directory.CreateDirectory(text2);
		Dictionary<string, object> value = new Dictionary<string, object>
		{
			["credentials_enable_service"] = false,
			["profile"] = new Dictionary<string, object>
			{
				["password_manager_enabled"] = false,
				["default_content_setting_values"] = new Dictionary<string, object>
				{
					["notifications"] = 2,
					["geolocation"] = 2,
					["media_stream_mic"] = 2,
					["media_stream_camera"] = 2
				}
			},
			["offer_to_save_passwords"] = false,
			["autofill"] = new Dictionary<string, object>
			{
				["profile_enabled"] = false,
				["credit_card_enabled"] = false,
				["address_enabled"] = false
			},
			["webrtc"] = new Dictionary<string, object>
			{
				["ip_handling_policy"] = "disable_non_proxied_udp",
				["multiple_routes_enabled"] = false,
				["nonproxied_udp_enabled"] = false
			}
		};
		File.WriteAllText(Path.Combine(text2, "Preferences"), JsonConvert.SerializeObject(value, Formatting.Indented));
		string driverExecutablePath = Path.Combine(Application.StartupPath, "chromedriver.exe");
		driver = UndetectedChromeDriver.Create(chromeOptions, null, driverExecutablePath, null, 0, 0, headless: false, noSandbox: true, suppressWelcome: true, hideCommandPromptWindow: false, null, null, delegate(ChromeDriverService service)
		{
			service.HideCommandPromptWindow = true;
			service.SuppressInitialDiagnosticInformation = true;
		});
		IJavaScriptExecutor javaScriptExecutor = driver;
		javaScriptExecutor.ExecuteScript("\r\n        Object.defineProperty(\r\n            navigator,\r\n            'webdriver',\r\n            {\r\n                get: () => undefined\r\n            }\r\n        );\r\n    ");
		javaScriptExecutor.ExecuteScript("\r\n        document.addEventListener(\r\n            'contextmenu',\r\n            e => e.preventDefault()\r\n        );\r\n\r\n        document.onkeydown = function(e)\r\n        {\r\n            if (\r\n                e.keyCode == 123 ||\r\n                (\r\n                    e.ctrlKey &&\r\n                    e.shiftKey &&\r\n                    (\r\n                        e.keyCode == 73 ||\r\n                        e.keyCode == 74\r\n                    )\r\n                ) ||\r\n                (\r\n                    e.ctrlKey &&\r\n                    e.keyCode == 85\r\n                )\r\n            )\r\n            {\r\n                e.preventDefault();\r\n                return false;\r\n            }\r\n        };\r\n    ");
		IntPtr intPtr = ChromeTaskbarHider.FindBrowserWindowByUserDataDir(userDataDir00);
		if (intPtr != IntPtr.Zero)
		{
			ChromeTaskbarHider.HideFromTaskbar(intPtr);
		}
		int height = Screen.PrimaryScreen.WorkingArea.Height - random.Next(225, 250);
		driver.Manage().Window.Size = new Size(rect.Width, height);
		LoadCookiesIntoSelenium(driver);
		return driver;
	}

	private int GetFreePort()
	{
		TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 0);
		tcpListener.Start();
		int port = ((IPEndPoint)tcpListener.LocalEndpoint).Port;
		tcpListener.Stop();
		return port;
	}

	internal UndetectedChromeDriver loadDriverBrave(ref string userDataDir00, Rectangle rect)
	{
		string text = "";
		Random random = new Random();
		Guid guid = Guid.NewGuid();
		string text2 = "N";
		string text3 = guid.ToString(text2);
		string tempPath = Path.GetTempPath();
		string text4 = "uc_";
		userDataDir00 = Path.Combine(tempPath, text4 + text3);
		ChromeOptions chromeOptions = new ChromeOptions();
		text = GetBravePath();
		if (!string.IsNullOrEmpty(text))
		{
			if (!string.IsNullOrEmpty(text))
			{
				chromeOptions.BinaryLocation = text;
			}
			string path = userDataDir00;
			string path2 = "Default";
			string text5 = Path.Combine(path, path2);
			Directory.CreateDirectory(text5);
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			string key = "credentials_enable_service";
			dictionary[key] = false;
			string key2 = "profile";
			Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
			string key3 = "password_manager_enabled";
			dictionary2[key3] = false;
			string key4 = "default_content_setting_values";
			Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
			string key5 = "notifications";
			dictionary3[key5] = 2;
			string key6 = "geolocation";
			dictionary3[key6] = 2;
			string key7 = "media_stream_mic";
			dictionary3[key7] = 2;
			string key8 = "media_stream_camera";
			dictionary3[key8] = 2;
			dictionary2[key4] = dictionary3;
			dictionary[key2] = dictionary2;
			string key9 = "offer_to_save_passwords";
			dictionary[key9] = false;
			string key10 = "autofill";
			Dictionary<string, object> dictionary4 = new Dictionary<string, object>();
			string key11 = "profile_enabled";
			dictionary4[key11] = false;
			string key12 = "credit_card_enabled";
			dictionary4[key12] = false;
			string key13 = "address_enabled";
			dictionary4[key13] = false;
			dictionary[key10] = dictionary4;
			string path3 = "Preferences";
			string path4 = Path.Combine(text5, path3);
			string contents = JsonConvert.SerializeObject(dictionary, Formatting.Indented);
			File.WriteAllText(path4, contents);
			string argument = "--app=https://www.irctc.co.in/nget/assets/images/logo.png";
			chromeOptions.AddArgument(argument);
			string argument2 = "--disable-blink-features=AutomationControlled";
			chromeOptions.AddArgument(argument2);
			string argument3 = "--ignore-certificate-errors";
			chromeOptions.AddArgument(argument3);
			string text6 = "--user-data-dir=";
			chromeOptions.AddArgument(text6 + userDataDir00);
			string text7 = "--window-position=";
			string text8 = rect.Left.ToString();
			string text9 = ",0";
			chromeOptions.AddArgument(text7 + text8 + text9);
			string bravePath = GetBravePath();
			string startupPath = Application.StartupPath;
			string path5 = "chromedriver.exe";
			string driverExecutablePath = Path.Combine(startupPath, path5);
			driver = UndetectedChromeDriver.Create(chromeOptions, null, driverExecutablePath, bravePath, 0, 0, headless: false, noSandbox: true, suppressWelcome: true, hideCommandPromptWindow: false, null, null, delegate(ChromeDriverService service)
			{
				service.HideCommandPromptWindow = true;
				service.SuppressInitialDiagnosticInformation = true;
			});
			UndetectedChromeDriver undetectedChromeDriver = driver;
			string script = "Object.defineProperty(navigator, 'webdriver', {get: () => undefined})";
			((IJavaScriptExecutor)undetectedChromeDriver).ExecuteScript(script, Array.Empty<object>());
			IntPtr intPtr = ChromeTaskbarHider.FindBrowserWindowByUserDataDir(userDataDir00);
			if (intPtr != IntPtr.Zero)
			{
				ChromeTaskbarHider.HideFromTaskbar(intPtr);
			}
			int height = Screen.PrimaryScreen.WorkingArea.Height - random.Next(225, 250);
			driver.Manage().Window.Size = new Size(rect.Width, height);
			LoadCookiesIntoSelenium(driver);
			return driver;
		}
		string text10 = "Brave Browser nahi mila!";
		MessageBox.Show(text10);
		return null;
	}

	private string GetEdgePath()
	{
		string[] array = new string[3];
		string text = "C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe";
		array[0] = text;
		string text2 = "C:\\Program Files\\Microsoft\\Edge\\Application\\msedge.exe";
		array[1] = text2;
		string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
		string path = "Microsoft\\Edge\\Application\\msedge.exe";
		array[2] = Path.Combine(folderPath, path);
		string[] array2 = array;
		string[] array3 = array2;
		foreach (string text3 in array3)
		{
			if (File.Exists(text3))
			{
				return text3;
			}
		}
		return "";
	}

	internal UndetectedChromeDriver loadDriverForOthers(ref string userDataDir00, Rectangle rect)
	{
		string text = "";
		Random random = new Random();
		Guid guid = Guid.NewGuid();
		string text2 = "N";
		string text3 = guid.ToString(text2);
		string tempPath = Path.GetTempPath();
		string text4 = "uc_";
		userDataDir00 = Path.Combine(tempPath, text4 + text3);
		ChromeOptions chromeOptions = new ChromeOptions();
		string argument = "--app=https://www.irctc.co.in/nget/assets/images/logo.png";
		chromeOptions.AddArgument(argument);
		string argument2 = "--disable-infobars";
		chromeOptions.AddArgument(argument2);
		string path = userDataDir00;
		string path2 = "Default";
		string text5 = Path.Combine(path, path2);
		Directory.CreateDirectory(text5);
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		string key = "credentials_enable_service";
		dictionary[key] = false;
		string key2 = "profile";
		Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
		string key3 = "password_manager_enabled";
		dictionary2[key3] = false;
		string key4 = "default_content_setting_values";
		Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
		string key5 = "notifications";
		dictionary3[key5] = 2;
		string key6 = "geolocation";
		dictionary3[key6] = 2;
		string key7 = "media_stream_mic";
		dictionary3[key7] = 2;
		string key8 = "media_stream_camera";
		dictionary3[key8] = 2;
		dictionary2[key4] = dictionary3;
		dictionary[key2] = dictionary2;
		string key9 = "offer_to_save_passwords";
		dictionary[key9] = false;
		string key10 = "autofill";
		Dictionary<string, object> dictionary4 = new Dictionary<string, object>();
		string key11 = "profile_enabled";
		dictionary4[key11] = false;
		string key12 = "credit_card_enabled";
		dictionary4[key12] = false;
		string key13 = "address_enabled";
		dictionary4[key13] = false;
		dictionary[key10] = dictionary4;
		Dictionary<string, object> value = dictionary;
		string path3 = "Preferences";
		string path4 = Path.Combine(text5, path3);
		string contents = JsonConvert.SerializeObject(value, Formatting.Indented);
		File.WriteAllText(path4, contents);
		string argument3 = "--disable-blink-features=AutomationControlled";
		chromeOptions.AddArgument(argument3);
		string argument4 = "--ignore-certificate-errors";
		chromeOptions.AddArgument(argument4);
		string argument5 = "--ignore-certificate-errors-spki-list";
		chromeOptions.AddArgument(argument5);
		string text6 = "--window-position=";
		string text7 = rect.Left.ToString();
		string text8 = ",0";
		chromeOptions.AddArgument(text6 + text7 + text8);
		string text9 = "--user-data-dir=";
		chromeOptions.AddArgument(text9 + userDataDir00);
		Dictionary<string, object> dictionary5 = new Dictionary<string, object>();
		string key14 = "webrtc.ip_handling_policy";
		string value2 = "disable_non_proxied_udp";
		dictionary5[key14] = value2;
		string key15 = "webrtc.multiple_routes_enabled";
		dictionary5[key15] = false;
		string key16 = "webrtc.nonproxied_udp_enabled";
		dictionary5[key16] = false;
		string startupPath = Application.StartupPath;
		string path5 = "chromedriver.exe";
		string driverExecutablePath = Path.Combine(startupPath, path5);
		driver = UndetectedChromeDriver.Create(chromeOptions, null, driverExecutablePath, null, 0, 0, headless: false, noSandbox: true, suppressWelcome: true, hideCommandPromptWindow: false, null, null, delegate(ChromeDriverService service)
		{
			service.HideCommandPromptWindow = true;
			service.SuppressInitialDiagnosticInformation = true;
		});
		IJavaScriptExecutor javaScriptExecutor = driver;
		IJavaScriptExecutor javaScriptExecutor2 = javaScriptExecutor;
		string script = "Object.defineProperty(navigator, 'webdriver', {get: () => undefined})";
		javaScriptExecutor2.ExecuteScript(script);
		javaScriptExecutor = driver;
		string clientID = Program.clientID;
		string text10 = "SGX9777";
		if (clientID != text10)
		{
			IJavaScriptExecutor javaScriptExecutor3 = javaScriptExecutor;
			string script2 = "\r\n    document.addEventListener('contextmenu', e => e.preventDefault());\r\n    document.onkeydown = function(e) {\r\n        if (e.keyCode == 123 || \r\n            (e.ctrlKey && e.shiftKey && (e.keyCode == 73 || e.keyCode == 74)) ||\r\n            (e.ctrlKey && e.keyCode == 85)) {\r\n            e.preventDefault();\r\n            return false;\r\n        }\r\n    };\r\n";
			javaScriptExecutor3.ExecuteScript(script2);
		}
		IntPtr intPtr = ChromeTaskbarHider.FindBrowserWindowByUserDataDir(userDataDir00);
		if (intPtr != IntPtr.Zero)
		{
			ChromeTaskbarHider.HideFromTaskbar(intPtr);
		}
		int height = Screen.PrimaryScreen.WorkingArea.Height - random.Next(225, 250);
		driver.Manage().Window.Size = new Size(rect.Width, height);
		return driver;
	}

	private string GetBravePath()
	{
		string[] array = new string[3]
		{
			"C:\\Program Files\\BraveSoftware\\Brave-Browser\\Application\\brave.exe",
			"C:\\Program Files (x86)\\BraveSoftware\\Brave-Browser\\Application\\brave.exe",
			Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BraveSoftware\\Brave-Browser\\Application\\brave.exe")
		};
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (File.Exists(text))
			{
				return text;
			}
		}
		try
		{
			using RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\brave.exe");
			if (registryKey != null)
			{
				object value = registryKey.GetValue("");
				if (value != null)
				{
					string text2 = value.ToString();
					if (File.Exists(text2))
					{
						return text2;
					}
				}
			}
		}
		catch
		{
		}
		try
		{
			using RegistryKey registryKey2 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\brave.exe");
			if (registryKey2 != null)
			{
				object value2 = registryKey2.GetValue("");
				if (value2 != null)
				{
					string text3 = value2.ToString();
					if (File.Exists(text3))
					{
						return text3;
					}
				}
			}
		}
		catch
		{
		}
		return null;
	}

	private string GetChromeBetaPath()
	{
		string[] array = new string[3];
		string text = "C:\\Program Files\\Google\\Chrome Beta\\Application\\chrome.exe";
		array[0] = text;
		string text2 = "C:\\Program Files (x86)\\Google\\Chrome Beta\\Application\\chrome.exe";
		array[1] = text2;
		string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
		string path = "Google\\Chrome Beta\\Application\\chrome.exe";
		array[2] = Path.Combine(folderPath, path);
		string[] array2 = array;
		string[] array3 = array2;
		foreach (string text3 in array3)
		{
			if (File.Exists(text3))
			{
				return text3;
			}
		}
		try
		{
			RegistryKey localMachine = Registry.LocalMachine;
			string name = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\chrome.exe";
			using RegistryKey registryKey = localMachine.OpenSubKey(name);
			if (registryKey != null)
			{
				object value = registryKey.GetValue("");
				if (value != null)
				{
					string text4 = value.ToString();
					string value2 = "Chrome Beta";
					if (text4.Contains(value2))
					{
						return value.ToString();
					}
				}
			}
		}
		catch
		{
		}
		return null;
	}

	public void LoadCookiesIntoSelenium_comet(UndetectedChromeDriver driver)
	{
		try
		{
			string text = "Check_IP_Block_comet";
			string path = text;
			if (File.Exists(path))
			{
				string encryptedInput = File.ReadAllText(path);
				string text2 = "ec3104c5318c8f0753fdc13faa540020cae645c4b43f3795a0f2f9fc94328326";
				string symmetricKey = text2;
				List<Playwright_Automation.ChromeCookie> list = JsonConvert.DeserializeObject<List<Playwright_Automation.ChromeCookie>>(Staticm.DecryptAES(encryptedInput, symmetricKey));
				if (list == null || list.Count == 0)
				{
					return;
				}
				foreach (Playwright_Automation.ChromeCookie item in list)
				{
					try
					{
						DateTime? expiry = null;
						if (item.expirationDate.HasValue)
						{
							expiry = DateTimeOffset.FromUnixTimeSeconds((long)item.expirationDate.Value).UtcDateTime;
						}
						string text3 = item.domain;
						if (!string.IsNullOrEmpty(text3))
						{
							string text4 = text3;
							string value = ".";
							if (text4.StartsWith(value))
							{
								text3 = text3.Substring(1);
							}
						}
						OpenQA.Selenium.Cookie cookie = new OpenQA.Selenium.Cookie(item.name, item.value, text3, item.path, expiry);
						driver.Manage().Cookies.AddCookie(cookie);
					}
					catch (Exception ex)
					{
						string[] array = new string[6];
						string text5 = "[Warning] Skipped cookie '";
						array[0] = text5;
						array[1] = item.name;
						string text6 = "' (Domain: ";
						array[2] = text6;
						array[3] = item.domain;
						string text7 = "). Error: ";
						array[4] = text7;
						array[5] = ex.Message;
						Console.WriteLine(string.Concat(array));
					}
				}
				driver.Navigate().Refresh();
				string value2 = "[Success] Cookies Selenium mein successfully load ho gayi hain!";
				Console.WriteLine(value2);
			}
			else
			{
				string value3 = "[Error] Cookie file nahi mili!";
				Console.WriteLine(value3);
			}
		}
		catch (Exception ex2)
		{
			string text8 = "Error loading cookies in Selenium: ";
			Console.WriteLine(text8 + ex2.Message);
		}
	}

	public void LoadCookiesIntoSelenium(UndetectedChromeDriver driver)
	{
		try
		{
			string text = "Check_IP_Block_Chrome";
			string path = text;
			if (File.Exists(path))
			{
				string encryptedInput = File.ReadAllText(path);
				string text2 = "ec3104c5318c8f0753fdc13faa540020cae645c4b43f3795a0f2f9fc94328326";
				string symmetricKey = text2;
				List<Playwright_Automation.ChromeCookie> list = JsonConvert.DeserializeObject<List<Playwright_Automation.ChromeCookie>>(Staticm.DecryptAES(encryptedInput, symmetricKey));
				if (list == null || list.Count == 0)
				{
					return;
				}
				foreach (Playwright_Automation.ChromeCookie item in list)
				{
					try
					{
						DateTime? expiry = null;
						if (item.expirationDate.HasValue)
						{
							expiry = DateTimeOffset.FromUnixTimeSeconds((long)item.expirationDate.Value).UtcDateTime;
						}
						string text3 = item.domain;
						if (!string.IsNullOrEmpty(text3))
						{
							string text4 = text3;
							string value = ".";
							if (text4.StartsWith(value))
							{
								text3 = text3.Substring(1);
							}
						}
						OpenQA.Selenium.Cookie cookie = new OpenQA.Selenium.Cookie(item.name, item.value, text3, item.path, expiry);
						driver.Manage().Cookies.AddCookie(cookie);
					}
					catch (Exception ex)
					{
						string[] array = new string[6];
						string text5 = "[Warning] Skipped cookie '";
						array[0] = text5;
						array[1] = item.name;
						string text6 = "' (Domain: ";
						array[2] = text6;
						array[3] = item.domain;
						string text7 = "). Error: ";
						array[4] = text7;
						array[5] = ex.Message;
						Console.WriteLine(string.Concat(array));
					}
				}
				driver.Navigate().Refresh();
				string value2 = "[Success] Cookies Selenium mein successfully load ho gayi hain!";
				Console.WriteLine(value2);
			}
			else
			{
				string value3 = "[Error] Cookie file nahi mili!";
				Console.WriteLine(value3);
			}
		}
		catch (Exception ex2)
		{
			string text8 = "Error loading cookies in Selenium: ";
			Console.WriteLine(text8 + ex2.Message);
		}
	}
}
