using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Ionic.Zip;
using Microsoft.Win32;

namespace APP_FRAMEWORK;

internal class StatClass
{
	private static bool drag;

	private static int posX;

	private static int posY;

	internal static bool BoolIsNgetCust;

	internal static bool NxtDay;

	public static bool WebLogin;

	public static bool ApptLogin;

	public static bool DishaLogin;

	public static int webPair;

	public static int appPair;

	public static int Slot_;

	public static bool firstpair;

	internal static string ClipBordVal;

	public static bool IsFileDownloaing;

	public static List<string> Tktlist_0;

	public static DateTime SoftOpenDateTime;

	internal static int TotalOpendWindow;

	internal static int TotalOpendTicket;

	public static int int_1;

	public static int int_3;

	public static int int_MaxPair;

	public static int int_TotalNoOfPair;

	public static int int_NoOfConnect;

	public static bool VPair;

	public static bool HPair;

	public static bool CloseOnPnr;

	public static bool IsReadydll;

	public static bool ResetReq;

	public static bool MicroWindow;

	public static bool VideoMode;

	public static string stopipblock;

	public static bool operalogin;

	public static bool manualclick;

	public static bool unverifiedbook;

	public static bool cometlogin;

	public static bool app1;

	public static bool directlogin;

	public static bool betalogin;

	public static bool stopipblocknew;

	public static bool IsUsedAllID;

	public static string TransferData;

	public static string TimeStr;

	public static string Wind;

	public static string strCommandLine;

	public static int TopMargin;

	public static int LeftMargin;

	public static int int_31;

	public static string lblTktName;

	public static TimeSpan timeSpan_0;

	public static TimeSpan timeSpan_1;

	private static bool bool_0;

	private static int int_0;

	private static int BAAAA;

	public static string emegencyurl;

	public static string IRPWD { get; set; }

	public static string Quota { get; set; }

	public static string Class { get; set; }

	public static string TrNo { get; set; }

	public static string AllNEWS { get; internal set; }

	internal static List<string> GetPType()
	{
		List<string> list = new List<string>();
		string item = "Select Payment Method";
		list.Add(item);
		string item2 = "Netbanking / Wallet";
		list.Add(item2);
		string item3 = "Credit / Debit Cards";
		list.Add(item3);
		return list;
	}

	public static Dictionary<string, string> GetNet()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		string key = "SBI";
		string value = "User Name|Password|MobileNo";
		dictionary.Add(key, value);
		string key2 = "BHIMUPI";
		string value2 = "UPI Id|UPI Pin|UPI MobileNo";
		dictionary.Add(key2, value2);
		string key3 = "PHONEPE";
		string value3 = "UPI Id|UPI MobileNo";
		dictionary.Add(key3, value3);
		string key4 = "AUTOPAY_UPI";
		string value4 = "UPI Id|UPI MobileNo";
		dictionary.Add(key4, value4);
		string key5 = "HDFCUPI";
		string value5 = "UPI Id|UPI MobileNo";
		dictionary.Add(key5, value5);
		string key6 = "RAZORPAYUPI";
		string value6 = "UPI Id|UPI MobileNo";
		dictionary.Add(key6, value6);
		string key7 = "iPay-QR";
		string value7 = "UPI Id";
		dictionary.Add(key7, value7);
		string key8 = "PayTM-QR";
		string value8 = "UPI Id";
		dictionary.Add(key8, value8);
		string key9 = "PHONEPE-QR";
		string value9 = "UPI Id";
		dictionary.Add(key9, value9);
		string key10 = "IRCTC_WALLET";
		string value10 = "Irctc ID";
		dictionary.Add(key10, value10);
		foreach (KeyValuePair<string, string> item in GetWallet())
		{
			dictionary.Add(item.Key, item.Value);
		}
		return dictionary;
	}

	public static Dictionary<string, string> GetWallet()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		string key = "AIRTELMONEY";
		string value = "Mobile|mPIN";
		dictionary.Add(key, value);
		string key2 = "PAYTM";
		string value2 = "Mobile|Password";
		dictionary.Add(key2, value2);
		return dictionary;
	}

	public static Dictionary<string, string> GetDebit()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		string key = "HDFC";
		string value = "Card No.|Holder Name|Exp Month|Exp Year|ATM Pin";
		dictionary.Add(key, value);
		string key2 = "PAYZAP";
		string value2 = "Card No.|Holder Name|Exp Month|Exp Year|ATM Pin";
		dictionary.Add(key2, value2);
		string key3 = "AXIS";
		string value3 = "Card No.|Holder Name|Exp Month|Exp Year|ATM Pin";
		dictionary.Add(key3, value3);
		string key4 = "ICICIVERTUAL";
		string value4 = "Card No.|Holder Name|Exp Month|Exp Year|ATM Pin";
		dictionary.Add(key4, value4);
		string key5 = "NSDL";
		string value5 = "Card No.|Holder Name|Exp Month|Exp Year|ATM Pin";
		dictionary.Add(key5, value5);
		foreach (KeyValuePair<string, string> item in GetCredit())
		{
			dictionary.Add(item.Key, item.Value);
		}
		return dictionary;
	}

	public static bool start_apche()
	{
		bool result = false;
		string path = "C:\\xampp\\apache\\bin\\httpd.exe";
		if (!File.Exists(path))
		{
			Form owner = Program.smethod_7();
			string text = "Please Download and Install XAMPP Server";
			string caption = "Installation Required";
			MessageBox.Show(owner, text, caption, MessageBoxButtons.OK);
			string fileName = "https://downloadsapachefriends.global.ssl.fastly.net/8.0.3/xampp-windows-x64-8.0.3-0-VS16-installer.exe?from_af=true";
			Process.Start(fileName);
			Application.Exit();
			Environment.Exit(0);
		}
		try
		{
			string eNCkey = frmLogin.ENCkey;
			string text2 = "active";
			if (eNCkey == text2)
			{
				extract_extension(0);
				extract_extension_Chromium(0);
			}
		}
		catch
		{
		}
		string path2 = "C:\\xampp\\apache\\bin\\httpd.exe";
		if (File.Exists(path2))
		{
			Check_db(0);
			Check_php(0);
			string processName = "httpd";
			Process[] processesByName = Process.GetProcessesByName(processName);
			if (processesByName.Length == 0)
			{
				Process process = new Process();
				ProcessStartInfo startInfo = process.StartInfo;
				string fileName2 = "C:\\xampp\\apache\\bin\\httpd.exe";
				startInfo.FileName = fileName2;
				process.StartInfo.CreateNoWindow = true;
				process.StartInfo.UseShellExecute = false;
				process.Start();
			}
			string processName2 = "mysqld";
			Process.GetProcessesByName(processName2);
			if (processesByName.Length == 0)
			{
				Process process2 = new Process();
				ProcessStartInfo startInfo2 = process2.StartInfo;
				string fileName3 = "C:\\xampp\\mysql\\bin\\mysqld.exe";
				startInfo2.FileName = fileName3;
				process2.StartInfo.CreateNoWindow = true;
				process2.StartInfo.UseShellExecute = false;
				process2.Start();
			}
			result = true;
		}
		return result;
	}

	public static void extract_extension(object j)
	{
		try
		{
			string path = "recaptcha";
			if (Directory.Exists(path))
			{
				string path2 = "recaptcha";
				DirectoryInfo directoryInfo = new DirectoryInfo(path2);
				FileInfo[] files = directoryInfo.GetFiles();
				for (int i = 0; i < files.Length; i++)
				{
					files[i].Delete();
				}
				DirectoryInfo[] directories = directoryInfo.GetDirectories();
				for (int k = 0; k < directories.Length; k++)
				{
					directories[k].Delete(recursive: true);
				}
				string path3 = "recaptcha";
				if (Directory.Exists(path3))
				{
					string path4 = "recaptcha";
					Directory.Delete(path4);
				}
			}
			string path5 = "reCaptcha - Direct";
			if (Directory.Exists(path5))
			{
				string path6 = "reCaptcha - Direct";
				DirectoryInfo directoryInfo2 = new DirectoryInfo(path6);
				FileInfo[] files2 = directoryInfo2.GetFiles();
				for (int l = 0; l < files2.Length; l++)
				{
					files2[l].Delete();
				}
				DirectoryInfo[] directories2 = directoryInfo2.GetDirectories();
				for (int m = 0; m < directories2.Length; m++)
				{
					directories2[m].Delete(recursive: true);
				}
				string path7 = "reCaptcha - Direct";
				if (Directory.Exists(path7))
				{
					string path8 = "reCaptcha - Direct";
					Directory.Delete(path8);
				}
			}
			string path9 = "reCaptcha_Chrome";
			if (Directory.Exists(path9))
			{
				string path10 = "reCaptcha_Chrome";
				DirectoryInfo directoryInfo3 = new DirectoryInfo(path10);
				FileInfo[] files3 = directoryInfo3.GetFiles();
				for (int n = 0; n < files3.Length; n++)
				{
					files3[n].Delete();
				}
				DirectoryInfo[] directories3 = directoryInfo3.GetDirectories();
				for (int num = 0; num < directories3.Length; num++)
				{
					directories3[num].Delete(recursive: true);
				}
				string path11 = "reCaptcha_Chrome";
				if (Directory.Exists(path11))
				{
					string path12 = "reCaptcha_Chrome";
					Directory.Delete(path12);
				}
			}
			string path13 = "reCaptcha_Chrome Beta";
			if (Directory.Exists(path13))
			{
				string path14 = "reCaptcha_Chrome Beta";
				DirectoryInfo directoryInfo4 = new DirectoryInfo(path14);
				FileInfo[] files4 = directoryInfo4.GetFiles();
				for (int num2 = 0; num2 < files4.Length; num2++)
				{
					files4[num2].Delete();
				}
				DirectoryInfo[] directories4 = directoryInfo4.GetDirectories();
				for (int num3 = 0; num3 < directories4.Length; num3++)
				{
					directories4[num3].Delete(recursive: true);
				}
				string path15 = "reCaptcha_Chrome Beta";
				if (Directory.Exists(path15))
				{
					string path16 = "reCaptcha_Chrome Beta";
					Directory.Delete(path16);
				}
			}
			string path17 = "reCaptcha_Chromium";
			if (Directory.Exists(path17))
			{
				string path18 = "reCaptcha_Chromium";
				DirectoryInfo directoryInfo5 = new DirectoryInfo(path18);
				FileInfo[] files5 = directoryInfo5.GetFiles();
				for (int num4 = 0; num4 < files5.Length; num4++)
				{
					files5[num4].Delete();
				}
				DirectoryInfo[] directories5 = directoryInfo5.GetDirectories();
				for (int num5 = 0; num5 < directories5.Length; num5++)
				{
					directories5[num5].Delete(recursive: true);
				}
				string path19 = "reCaptcha_Chromium";
				if (Directory.Exists(path19))
				{
					string path20 = "reCaptcha_Chromium";
					Directory.Delete(path20);
				}
			}
			string path21 = "Chrome";
			if (Directory.Exists(path21))
			{
				string path22 = "Chrome";
				DirectoryInfo directoryInfo6 = new DirectoryInfo(path22);
				FileInfo[] files6 = directoryInfo6.GetFiles();
				for (int num6 = 0; num6 < files6.Length; num6++)
				{
					files6[num6].Delete();
				}
				DirectoryInfo[] directories6 = directoryInfo6.GetDirectories();
				for (int num7 = 0; num7 < directories6.Length; num7++)
				{
					directories6[num7].Delete(recursive: true);
				}
			}
			string startupPath = Application.StartupPath;
			string text = "Chrome.dll";
			string text2 = text;
			string text3 = "Chrome.zip";
			string text4 = text3;
			if (!File.Exists(text2))
			{
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				string name = "^.Booking.include.Chrome.dll";
				Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(name);
				if (manifestResourceStream != null)
				{
					FileStream fileStream = new FileStream(text2, FileMode.CreateNew);
					for (int num8 = 0; num8 < manifestResourceStream.Length; num8++)
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
					zipFile.ExtractAll(startupPath, ExtractExistingFileAction.OverwriteSilently);
				}
				File.Delete(text4);
			}
			catch (Exception ex)
			{
				File.Delete(text4);
				MessageBox.Show(ex.Message);
			}
		}
		catch (Exception)
		{
		}
	}

	public static void extract_extension_Chromium(object j)
	{
		try
		{
			string path = "Beta";
			if (Directory.Exists(path))
			{
				string path2 = "Beta";
				DirectoryInfo directoryInfo = new DirectoryInfo(path2);
				FileInfo[] files = directoryInfo.GetFiles();
				for (int i = 0; i < files.Length; i++)
				{
					files[i].Delete();
				}
				DirectoryInfo[] directories = directoryInfo.GetDirectories();
				for (int k = 0; k < directories.Length; k++)
				{
					directories[k].Delete(recursive: true);
				}
			}
			string startupPath = Application.StartupPath;
			string text = "Beta.dll";
			string text2 = text;
			string text3 = "Beta.zip";
			string text4 = text3;
			if (!File.Exists(text2))
			{
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				string name = "NEXUS.Extention..Beta.dll";
				Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(name);
				if (manifestResourceStream != null)
				{
					FileStream fileStream = new FileStream(text2, FileMode.CreateNew);
					for (int l = 0; l < manifestResourceStream.Length; l++)
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
					zipFile.ExtractAll(startupPath, ExtractExistingFileAction.OverwriteSilently);
				}
				File.Delete(text4);
			}
			catch (Exception ex)
			{
				File.Delete(text4);
				MessageBox.Show(ex.Message);
			}
		}
		catch
		{
		}
	}

	public static void Check_php(object j)
	{
		try
		{
			string text = "C:\\xampp\\htdocs";
			string text2 = text;
			bool flag = false;
			string path = "check.php";
			if (File.Exists(Path.Combine(text2, path)))
			{
				string path2 = "get.php";
				if (!File.Exists(Path.Combine(text2, path2)))
				{
					flag = true;
				}
				else
				{
					string path3 = "set.php";
					if (File.Exists(Path.Combine(text2, path3)))
					{
						string path4 = "db_connection.php";
						if (!File.Exists(Path.Combine(text2, path4)))
						{
							flag = true;
						}
					}
					else
					{
						flag = true;
					}
				}
			}
			else
			{
				flag = true;
			}
			string path5 = "php.dll";
			string text3 = Path.Combine(text2, path5);
			string path6 = "php.zip";
			string text4 = Path.Combine(text2, path6);
			if (flag && !File.Exists(text3))
			{
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				string name = "^.Booking.include.php.dll";
				Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(name);
				if (manifestResourceStream != null)
				{
					FileStream fileStream = new FileStream(text3, FileMode.CreateNew);
					for (int i = 0; i < manifestResourceStream.Length; i++)
					{
						fileStream.WriteByte((byte)manifestResourceStream.ReadByte());
					}
					fileStream.Close();
					new FileInfo(text3).Attributes = FileAttributes.Hidden;
				}
			}
			if (!File.Exists(text3))
			{
				return;
			}
			if (!File.Exists(text4))
			{
				File.Copy(text3, text4, overwrite: true);
			}
			File.Delete(text3);
			try
			{
				using (ZipFile zipFile = ZipFile.Read(text4))
				{
					zipFile.ExtractAll(text2, ExtractExistingFileAction.OverwriteSilently);
				}
				File.Delete(text4);
			}
			catch (Exception ex)
			{
				File.Delete(text4);
				MessageBox.Show(ex.Message);
			}
		}
		catch
		{
		}
	}

	public static void Check_db(object j)
	{
		try
		{
			string text = "C:\\xampp\\mysql\\data";
			string text2 = text;
			string text3 = "C:\\xampp\\mysql";
			string text4 = text3;
			bool flag = false;
			string path = "phpmyadmin\\pma__empty.frm";
			if (!File.Exists(Path.Combine(text2, path)))
			{
				flag = true;
			}
			string path2 = "data.dll";
			string text5 = Path.Combine(text4, path2);
			string path3 = "data.zip";
			string text6 = Path.Combine(text4, path3);
			if (flag && !File.Exists(text5))
			{
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				string name = "NEXUS.Extention..data.dll";
				Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(name);
				if (manifestResourceStream != null)
				{
					FileStream fileStream = new FileStream(text5, FileMode.CreateNew);
					for (int i = 0; i < manifestResourceStream.Length; i++)
					{
						fileStream.WriteByte((byte)manifestResourceStream.ReadByte());
					}
					fileStream.Close();
					new FileInfo(text5).Attributes = FileAttributes.Hidden;
				}
			}
			if (!File.Exists(text5))
			{
				return;
			}
			if (!File.Exists(text6))
			{
				File.Copy(text5, text6, overwrite: true);
			}
			File.Delete(text5);
			try
			{
				string processName = "httpd";
				Process[] processesByName = Process.GetProcessesByName(processName);
				for (int k = 0; k < processesByName.Length; k++)
				{
					processesByName[k].Kill();
				}
				string processName2 = "xampp-control";
				processesByName = Process.GetProcessesByName(processName2);
				for (int l = 0; l < processesByName.Length; l++)
				{
					processesByName[l].Kill();
				}
				Thread.Sleep(1000);
				if (Directory.Exists(text2))
				{
					Directory.Delete(text2, recursive: true);
				}
				if (!Directory.Exists(text2))
				{
					Directory.CreateDirectory(text2);
				}
				using (ZipFile zipFile = ZipFile.Read(text6))
				{
					zipFile.ExtractAll(text4, ExtractExistingFileAction.OverwriteSilently);
				}
				File.Delete(text6);
				string path4 = "C:\\xampp\\htdocs\\check.php";
				if (File.Exists(path4))
				{
					string path5 = "C:\\xampp\\htdocs\\check.php";
					File.Delete(path5);
				}
			}
			catch (Exception ex)
			{
				File.Delete(text6);
				MessageBox.Show(ex.Message);
			}
		}
		catch
		{
		}
	}

	internal static void checkBrowser()
	{
		string path = "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe";
		if (!File.Exists(path))
		{
			Form owner = new Form
			{
				TopMost = true
			};
			string text = "Please Download and Install Google Chrome Web Browser";
			string caption = "Installation Required";
			MessageBox.Show(owner, text, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			Environment.Exit(0);
		}
		string path2 = "C:\\Program Files\\Google\\Chrome Beta\\Application";
		string path3 = "chrome.exe";
		if (!File.Exists(Path.Combine(path2, path3)))
		{
			Form owner2 = new Form
			{
				TopMost = true
			};
			string text2 = "Please Download and Install Beta Version of Chrome Web Browser";
			string caption2 = "Installation Required";
			MessageBox.Show(owner2, text2, caption2, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			string fileName = "chrome.exe";
			string arguments = "https://dl.google.com/tag/s/appguid%3D%7B8237E44A-0054-442C-B6B6-EA0509993955%7D%26iid%3D%7B4DA4021A-13D4-1F1E-E21E-D86C47426A42%7D%26lang%3Den-GB%26browser%3D4%26usagestats%3D1%26appname%3DGoogle%2520Chrome%2520Beta%26needsadmin%3Dprefers%26ap%3D-arch_x64-statsdef_1%26installdataindex%3Dempty/update2/installers/ChromeSetup.exe";
			Process.Start(fileName, arguments);
			Environment.Exit(0);
		}
		string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
		string path4 = "Google\\Chrome\\User Data";
		if (!Directory.Exists(Path.Combine(folderPath, path4)))
		{
			Form owner3 = new Form
			{
				TopMost = true
			};
			string text3 = "Aapke System me Google Chrome Properly install nahi he, uninstall karke dobara install karen";
			string caption3 = "ReInstallation Required";
			MessageBox.Show(owner3, text3, caption3, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			Environment.Exit(0);
		}
		string path5 = "Google\\Chrome Beta\\User Data";
		if (!Directory.Exists(Path.Combine(folderPath, path5)))
		{
			Form owner4 = new Form
			{
				TopMost = true
			};
			string text4 = "Aapke System me Chrome Beta Properly install nahi he, uninstall karke dobara install karen";
			string caption4 = "ReInstallation Required";
			MessageBox.Show(owner4, text4, caption4, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			Environment.Exit(0);
		}
	}

	private static string smethod_0()
	{
		string result = "";
		try
		{
			RegistryKey currentUser = Registry.CurrentUser;
			string name = "Software\\Google\\Chrome\\BLBeacon";
			using RegistryKey registryKey = currentUser.OpenSubKey(name);
			if (registryKey != null)
			{
				string name2 = "version";
				object value = registryKey.GetValue(name2);
				if (value != null)
				{
					result = value.ToString();
				}
			}
		}
		catch (Exception)
		{
		}
		return result;
	}

	public static Dictionary<string, string> GetCredit()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		string key = "SBI_HDF_CC";
		string value = "Card No.|Visa Pin|Exp Month|Exp Year|Visa/Master|CVV|Pin";
		dictionary.Add(key, value);
		string key2 = "HDFC_HDF_CC";
		string value2 = "Card No.|Visa Pin|Exp Month|Exp Year|Visa/Master|CVV|Pin";
		dictionary.Add(key2, value2);
		string key3 = "FEDRAL_HDF_CC";
		string value3 = "Card No.|Visa Pin|Exp Month|Exp Year|Visa/Master|CVV|Pin";
		dictionary.Add(key3, value3);
		string key4 = "IDBI_HDF_CC";
		string value4 = "Card No.|Visa Pin|Exp Month|Exp Year|Visa/Master|CVV|Pin";
		dictionary.Add(key4, value4);
		string key5 = "KOTAK_HDF_CC";
		string value5 = "Card No.|Visa Pin|Exp Month|Exp Year|Visa/Master|CVV|Pin";
		dictionary.Add(key5, value5);
		string key6 = "UNION_HDF_CC";
		string value6 = "Card No.|Visa Pin|Exp Month|Exp Year|Visa/Master|CVV|Pin";
		dictionary.Add(key6, value6);
		string key7 = "AXIS_HDF_CC";
		string value7 = "Card No.|Visa Pin|Exp Month|Exp Year|Visa/Master|CVV|Pin";
		dictionary.Add(key7, value7);
		string key8 = "SBI_ICI_CC";
		string value8 = "Card No.|Visa Pin|Exp Month|Exp Year|Visa/Master|CVV|Pin";
		dictionary.Add(key8, value8);
		string key9 = "HDFC_ICI_CC";
		string value9 = "Card No.|Visa Pin|Exp Month|Exp Year|Visa/Master|CVV|Pin";
		dictionary.Add(key9, value9);
		string key10 = "SBI_CIT_CC";
		string value10 = "Card No.|Visa Pin|Exp Month|Exp Year|Visa/Master|CVV|Pin";
		dictionary.Add(key10, value10);
		string key11 = "HDFC_CIT_CC";
		string value11 = "Card No.|Visa Pin|Exp Month|Exp Year|Visa/Master|CVV|Pin";
		dictionary.Add(key11, value11);
		string key12 = "SBI_PTM_CC";
		string value12 = "Card No.|Visa Pin|Exp Month|Exp Year|Visa/Master|CVV|Pin";
		dictionary.Add(key12, value12);
		string key13 = "HDFC_PTM_CC";
		string value13 = "Card No.|Visa Pin|Exp Month|Exp Year|Visa/Master|CVV|Pin";
		dictionary.Add(key13, value13);
		foreach (KeyValuePair<string, string> item in GetVirtual())
		{
			dictionary.Add(item.Key, item.Value);
		}
		return dictionary;
	}

	public static Dictionary<string, string> GetVirtual()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		string key = "AIRTEL_CIT_CC";
		string value = "Card No.|Visa Pin|Exp Month|Exp Year|Visa/Master|CVV|Pin";
		dictionary.Add(key, value);
		string key2 = "OXIGEN_CIT_CC";
		string value2 = "Card No.|Visa Pin|Exp Month|Exp Year|Visa/Master|CVV|Pin";
		dictionary.Add(key2, value2);
		return dictionary;
	}

	internal static void method_35()
	{
		string string_ = "Program.Main";
		string string_2 = "Loading details";
		Class28.smethod_26(string_, string_2);
		smethod_1();
		Program.dictionary_01 = new Dictionary<string, string>();
		try
		{
			DataTable dataTable = new DataTable();
			string commandText = "SELECT * FROM TBL_USER";
			new SQLiteDataAdapter(commandText, Class34.string_Database).Fill(dataTable);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				foreach (DataRow row in dataTable.Rows)
				{
					Dictionary<string, string> dictionary_ = Program.dictionary_01;
					string columnName = "UserName";
					string key = row[columnName].ToString();
					string columnName2 = "strPwd";
					dictionary_.Add(key, row[columnName2].ToString());
				}
			}
		}
		catch
		{
		}
		Program.dictionary_0 = new Dictionary<string, string>();
		try
		{
			DataTable dataTable2 = new DataTable();
			string commandText2 = "SELECT * FROM TBL_USER WHERE UserState LIKE 'Active||%'";
			new SQLiteDataAdapter(commandText2, Class34.string_Database).Fill(dataTable2);
			if (dataTable2 != null && dataTable2.Rows.Count > 0)
			{
				foreach (DataRow row2 in dataTable2.Rows)
				{
					Dictionary<string, string> dictionary_2 = Program.dictionary_0;
					string columnName3 = "UserName";
					string key2 = row2[columnName3].ToString();
					string columnName4 = "strPwd";
					dictionary_2.Add(key2, row2[columnName4].ToString());
				}
			}
		}
		catch
		{
		}
		method_36();
	}

	private static void smethod_1()
	{
	}

	public static void method_36()
	{
		DataTable dataTable = new DataTable();
		Program.dictionary_00 = new Dictionary<string, string>();
		try
		{
			string commandText = "SELECT BANK_SAVEAS, BANK_DETAILS FROM TBL_BANK";
			new SQLiteDataAdapter(commandText, Class34.string_Database).Fill(dataTable);
			if (dataTable == null || dataTable.Rows.Count <= 0)
			{
				return;
			}
			foreach (DataRow row in dataTable.Rows)
			{
				Dictionary<string, string> dictionary_ = Program.dictionary_00;
				string columnName = "BANK_SAVEAS";
				string key = row[columnName].ToString();
				string columnName2 = "BANK_DETAILS";
				dictionary_.Add(key, row[columnName2].ToString());
			}
		}
		catch (Exception)
		{
		}
	}

	public static void Header_MouseDown(object sender, MouseEventArgs e)
	{
		Control parent = ((Panel)sender).Parent;
		if (e.Button == MouseButtons.Left)
		{
			drag = true;
			posX = Cursor.Position.X - parent.Left;
			posY = Cursor.Position.Y - parent.Top;
		}
	}

	public static void Header_MouseMove(object sender, MouseEventArgs e)
	{
		Control parent = ((Panel)sender).Parent;
		if (drag)
		{
			parent.Top = Cursor.Position.Y - posY;
			parent.Left = Cursor.Position.X - posX;
		}
		parent.Cursor = Cursors.Default;
	}

	public static void Header_MouseUp(object sender, MouseEventArgs e)
	{
		drag = false;
	}

	public static void Headerr_MouseDown(object sender, MouseEventArgs e)
	{
		Control parent = ((Label)sender).Parent.Parent;
		if (e.Button == MouseButtons.Left)
		{
			drag = true;
			posX = Cursor.Position.X - parent.Left;
			posY = Cursor.Position.Y - parent.Top;
		}
	}

	public static void Headerr_MouseMove(object sender, MouseEventArgs e)
	{
		Control parent = ((Label)sender).Parent.Parent;
		if (drag)
		{
			parent.Top = Cursor.Position.Y - posY;
			parent.Left = Cursor.Position.X - posX;
		}
		parent.Cursor = Cursors.Default;
	}

	static StatClass()
	{
		ClipBordVal = "";
		TotalOpendWindow = 0;
		TotalOpendTicket = 0;
		int_1 = 1;
		int_3 = 0;
		int_MaxPair = 20;
		string wind = "Wind.txt";
		Wind = wind;
		timeSpan_0 = new TimeSpan(0, 0, 0);
		timeSpan_1 = new TimeSpan(0, 0, 0);
		emegencyurl = "";
	}
}
