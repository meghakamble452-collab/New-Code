using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V143;
using OpenQA.Selenium.DevTools.V143.Network;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumUndetectedChromeDriver;

namespace IRCommDLL;

internal class ChromeControlNew
{
	private static readonly Random rnd = new Random();

	private DevToolsSessionDomains devTools;

	internal string SolveCaptcha(string bs64)
	{
		string text = string.Empty;
		try
		{
			string text2 = "|NGET|";
			string arguments = bs64 + text2;
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
				if (File.Exists(path3))
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

	public static void TypeLikeHuman(IWebElement element, string text)
	{
		for (int i = 0; i < text.Length; i++)
		{
			element.SendKeys(text[i].ToString());
			Thread.Sleep(rnd.Next(100, 250));
		}
	}

	public Task handleAsync()
	{
		try
		{
			ChromeOptions chromeOptions = new ChromeOptions();
			string preferenceName = "profile.default_content_setting_values.notifications";
			chromeOptions.AddUserProfilePreference(preferenceName, 2);
			string preferenceName2 = "profile.default_content_setting_values.geolocation";
			chromeOptions.AddUserProfilePreference(preferenceName2, 2);
			string preferenceName3 = "profile.default_content_setting_values.media_stream_mic";
			chromeOptions.AddUserProfilePreference(preferenceName3, 2);
			string preferenceName4 = "profile.default_content_setting_values.media_stream_camera";
			chromeOptions.AddUserProfilePreference(preferenceName4, 2);
			string startupPath = Application.StartupPath;
			string path = "chromedriver.exe";
			string driverExecutablePath = Path.Combine(startupPath, path);
			using UndetectedChromeDriver undetectedChromeDriver = UndetectedChromeDriver.Create(chromeOptions, null, driverExecutablePath, null, 0, 0, headless: false, noSandbox: true, suppressWelcome: true, hideCommandPromptWindow: false, null);
			try
			{
				string text = "https://www.irctc.co.in/nget/train-search";
				string text2 = text;
				string text3 = "Navigating to: ";
				Console.WriteLine(text3 + text2);
				undetectedChromeDriver.Navigate().GoToUrl(text2);
				string value = "Waiting for page to load... (simulating human pause)";
				Console.WriteLine(value);
				Task.Delay(5000).Wait();
				string cssSelectorToFind = "button[type='submit'][aria-label*='Press OK to confirm']";
				undetectedChromeDriver.FindElement(By.CssSelector(cssSelectorToFind)).Click();
				WebDriverWait webDriverWait = new WebDriverWait(undetectedChromeDriver, TimeSpan.FromSeconds(5.0));
				string cssSelectorToFind2 = "a.search_btn.loginText";
				webDriverWait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(cssSelectorToFind2))).Click();
				string cssSelectorToFind3 = "input[formcontrolname='userid']";
				IWebElement webElement = webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(cssSelectorToFind3)));
				webElement.Clear();
				string text4 = "Malik1947";
				TypeLikeHuman(webElement, text4);
				string cssSelectorToFind4 = "input[formcontrolname='password']";
				IWebElement webElement2 = webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(cssSelectorToFind4)));
				webElement2.Clear();
				string text5 = "Salman!1122";
				TypeLikeHuman(webElement2, text5);
				string cssSelectorToFind5 = "img.captcha-img";
				IWebElement webElement3 = undetectedChromeDriver.FindElement(By.CssSelector(cssSelectorToFind5));
				string attributeName = "src";
				string bs = webElement3.GetAttribute(attributeName).Split(',')[1];
				string text6 = SolveCaptcha(bs);
				string cssSelectorToFind6 = "input[formcontrolname='captcha']";
				IWebElement webElement4 = webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(cssSelectorToFind6)));
				webElement4.Clear();
				TypeLikeHuman(webElement4, text6);
				Thread.Sleep(2000);
				try
				{
					string cssSelectorToFind7 = "button.search_btn.train_Search.train_Search_custom_hover";
					webDriverWait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(cssSelectorToFind7))).Click();
					foreach (OpenQA.Selenium.Cookie allCookie in undetectedChromeDriver.Manage().Cookies.AllCookies)
					{
						string name = allCookie.Name;
						string text7 = " = ";
						Console.WriteLine(name + text7 + allCookie.Value);
					}
				}
				catch (Exception)
				{
				}
				string value2 = "Successfully loaded the page. You are ready to automate!";
				Console.WriteLine(value2);
			}
			catch (Exception ex2)
			{
				string text8 = "An error occurred: ";
				Console.WriteLine(text8 + ex2.Message);
			}
			finally
			{
				string value3 = "Closing the browser.";
				Console.WriteLine(value3);
			}
		}
		catch (Exception)
		{
		}
		return Task.CompletedTask;
	}

	private void Network_RequestWillBeSent(object sender, RequestWillBeSentEventArgs e)
	{
		string url = e.Request.Url;
		string value = "eticketing/protected/mapps1/recentTxnsDetails";
		if (url.Contains(value))
		{
			string value2 = "===========================";
			Console.WriteLine(value2);
			foreach (KeyValuePair<string, string> header in e.Request.Headers)
			{
			}
		}
		string url2 = e.Request.Url;
		string value3 = "https://www.irctc.co.in/PkQcS/7nI/ggw0/EtU9EP/kc/YttuX8mt/RSlQbENwKAI/IB/pgYFtuVmsB";
		if (url2.Contains(value3))
		{
			string reqId = e.RequestId;
			Task.Run(async delegate
			{
				string text = (await devTools.Network.GetRequestPostData(new GetRequestPostDataCommandSettings
				{
					RequestId = reqId
				}, default(CancellationToken), null)).PostData.ToString();
				string value4 = "sensor_data";
				text.Contains(value4);
			});
		}
	}

	private void Network_ResponseReceived_App(object sender, ResponseReceivedEventArgs e)
	{
		string url = e.Response.Url;
		string value = "eticketing/protected/mapps1/validateUser?source=3";
		if (url.Contains(value))
		{
			foreach (KeyValuePair<string, string> header in e.Response.Headers)
			{
			}
			string reqId3 = e.RequestId;
			Task.Run(async delegate
			{
				(await devTools.Network.GetResponseBody(new GetResponseBodyCommandSettings
				{
					RequestId = reqId3
				}, default(CancellationToken), null)).Body.ToString();
			});
		}
		string url2 = e.Response.Url;
		string value2 = "irctc.co.in/eticketing/protected/mapps1/loginCaptcha";
		if (url2.Contains(value2))
		{
			string reqId4 = e.RequestId;
			Task.Run(async delegate
			{
				string text2 = (await devTools.Network.GetResponseBody(new GetResponseBodyCommandSettings
				{
					RequestId = reqId4
				}, default(CancellationToken), null)).Body.ToString();
				string value5 = "status";
				text2.Contains(value5);
			});
		}
		string url3 = e.Response.Url;
		string value6 = "irctc.co.in/authprovider/webtoken";
		if (url3.Contains(value6))
		{
			string reqId5 = e.RequestId;
			Task.Run(async delegate
			{
				string text3 = (await devTools.Network.GetResponseBody(new GetResponseBodyCommandSettings
				{
					RequestId = reqId5
				}, default(CancellationToken), null)).Body.ToString();
				string value7 = "Access Denied";
				text3.Contains(value7);
			});
		}
	}
}
