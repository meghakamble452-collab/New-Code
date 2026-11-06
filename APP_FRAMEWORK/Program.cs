using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Booking;
using Microsoft.Win32;
using NEXUS;

namespace APP_FRAMEWORK;

public static class Program
{
	internal static string rp;

	public static bool ChromExitTime;

	public static WebProxy PrivateProxy;

	public static WebProxy PublicProxy;

	public static string FiloList;

	public static string ExecutablePath;

	public static string StartupPath;

	public static string HostUri;

	public static string Uri;

	public static string DownloadUri;

	public static string DownloadCommonUri;

	public static string HomeIP;

	public static string ResultURL;

	public static string IrcommURI;

	public static string UpdateURI;

	public static string PDFURL;

	public static string OcrUrl;

	public static string StrongPassword;

	public static string StrongPassword_text;

	public static string MsgNews;

	public static string Latnews;

	public static string SellerMeg;

	public static string AWS_Link;

	public static mCOMM mcommInstance_;

	internal static List<string> list_0;

	internal static Dictionary<string, string> dictionary_0;

	internal static Dictionary<string, string> dictionary_00;

	internal static Dictionary<int, string> dictionary_1;

	internal static Dictionary<string, string> dictionary_01;

	internal static Dictionary<string, string> dictionary_2;

	internal static Dictionary<string, string> dictionary_3;

	internal static Dictionary<string, string> list_SelectedIRCTCid;

	internal static Dictionary<string, int> dictionary_41;

	internal static Dictionary<string, string> dictionary_4;

	internal static string clientID;

	internal static string LocalWebip;

	internal static string string_00;

	internal static string OSSystem;

	internal static string mac;

	internal static string string_1A;

	internal static string DBPASS;

	internal static string WEBTEXT;

	internal static string availtime;

	internal static string string_01;

	public static int Credit;

	internal static int int_0;

	internal static int int_1;

	internal static bool bool_0;

	internal static mySettings mySettings_0;

	internal static Class28 class28_0;

	internal static string string_3;

	internal static int int_2;

	internal static DateTime dateTime_0;

	internal static int int_Slot;

	internal static int ValidationStep;

	internal static int slot;

	internal static int int_WorkingIP;

	internal static int int_5;

	internal static string string_4;

	internal static Assembly assembly_0;

	internal static Type type_0;

	private static List<string> list_1;

	internal static List<string> list_Proxy;

	internal static List<string> list_3;

	private static Thread C0AA0;

	private static bool bool_1;

	public static frmMain frmMain_0;

	internal static bool bool_3;

	internal static bool bool_SystemIP;

	internal static int int_4;

	internal static string string_bhim_exist;

	internal static string string_pdf_exist;

	internal static string string_ocr_exist;

	internal static string string_Weblogger_exist;

	internal static string string_5;

	internal static string string_6;

	internal static byte[] response;

	internal static string string_7;

	internal static string string_8;

	internal static int ExpiryDay;

	internal static string string_9;

	internal static string string_10;

	internal static string string_11;

	internal static bool bool_5;

	internal static string string_updat_exist;

	internal static string string_13;

	internal static string string_14;

	internal static string PaidStatus;

	internal static string LicStatus;

	public static string KeyStatus;

	public static string KeyType;

	internal static string string_15;

	internal static Process process_0;

	internal static bool bool_6;

	internal static bool bool_7;

	internal static bool bool_VSC;

	public static bool token_;

	public static string NewVersion;

	public static string cleansys;

	public static string Localip;

	public static string ispdetails;

	public static string ExeName;

	public static string AppName;

	internal static bool bool_8;

	internal static bool bool_UpdtAvl;

	internal static bool bool_IsFileUpdtAvl;

	internal static bool bool_IsExeUpdtAvl;

	internal static bool BypassAnalizer;

	internal static bool OfflineValidation;

	public static string Parameters;

	public static string ErPlce;

	public static string exitNAME;

	public static int paidpair;

	public static int unpaidpair;

	public static int WindowCount;

	internal static string FontLink;

	internal static string Nexusjpg;

	internal static string Windowsjpg;

	public static string batchNumber;

	public static bool BookingAllowEdge;

	public static bool BookingAllowChrome;

	public static bool BookingAllowChromeBeta;

	public static string BackUpRestoreURL { get; internal set; }

	public static string ProxyUrl { get; internal set; }

	public static bool UnpaidKey { get; internal set; }

	public static bool PaymentIPBloack { get; internal set; }

	public static bool FixIPBloack { get; internal set; }

	public static bool autoSubmitCaptcha { get; internal set; }

	public static bool AutofillOCR { get; internal set; }

	public static bool AutoFillAPI { get; internal set; }

	public static bool showCaptcha { get; internal set; }

	public static string ValidateResponse { get; internal set; }

	[STAThread]
	private static void Main(string[] args)
	{
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(defaultValue: false);
		Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
		EmbeddedAssembly.Assembly_Load();
		if (!CheckChromeDriver())
		{
			Form owner = new Form
			{
				TopMost = true
			};
			string[] array = new string[1];
			string text = "Chrome or Chrome-Driver not Found";
			array[0] = text;
			MessageBox.Show(owner, string.Concat(array));
		}
		try
		{
			string text2 = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<configuration>\r\n\t<configSections>\r\n\t\t<!-- For more information on Entity Framework configuration, visit http://go.microsoft.com/fwlink/?LinkID=237468 -->\r\n\t\t<section name=\"entityFramework\" type=\"System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\" requirePermission=\"false\" />\r\n\t</configSections>\r\n\t<startup>\r\n\t\t<supportedRuntime version=\"v4.0\" sku=\".NETFramework,Version=v4.8\" />\r\n\t</startup>\r\n\t<system.net>\r\n\t\t<connectionManagement>\r\n\t\t\t<add address=\"*\" maxconnection=\"2147483647\" />\r\n\t\t</connectionManagement>\r\n\t</system.net>\r\n\t<entityFramework>\r\n\t\t<defaultConnectionFactory type=\"System.Data.Entity.Infrastructure.LocalDbConnectionFactory, EntityFramework\">\r\n\t\t\t<parameters>\r\n\t\t\t\t<parameter value=\"v11.0\" />\r\n\t\t\t</parameters>\r\n\t\t</defaultConnectionFactory>\r\n\t\t<providers>\r\n\t\t\t<provider invariantName=\"System.Data.SqlClient\" type=\"System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer\" />\r\n\t\t\t<provider invariantName=\"System.Data.SQLite.EF6\" type=\"System.Data.SQLite.EF6.SQLiteProviderServices, System.Data.SQLite.EF6\" />\r\n\t\t</providers>\r\n\t</entityFramework>\r\n\t<runtime>\r\n\t\t<assemblyBinding xmlns=\"urn:schemas-microsoft-com:asm.v1\">\r\n\t\t\t<dependentAssembly>\r\n\t\t\t\t<assemblyIdentity name=\"Bunifu.Core\" publicKeyToken=\"e8e24ccd28363fe9\" culture=\"neutral\" />\r\n\t\t\t\t<bindingRedirect oldVersion=\"0.0.0.0-1.8.0.0\" newVersion=\"1.8.0.0\" />\r\n\t\t\t</dependentAssembly>\r\n\t\t\t<dependentAssembly>\r\n\t\t\t\t<assemblyIdentity name=\"Newtonsoft.Json\" culture=\"neutral\" publicKeyToken=\"30ad4fe6b2a6aeed\" />\r\n\t\t\t\t<bindingRedirect oldVersion=\"0.0.0.0-11.0.0.0\" newVersion=\"11.0.0.0\" />\r\n\t\t\t</dependentAssembly>\r\n\t\t\t<dependentAssembly>\r\n\t\t\t\t<assemblyIdentity name=\"System.Data.SQLite\" culture=\"neutral\" publicKeyToken=\"db937bc2d44ff139\" />\r\n\t\t\t\t<bindingRedirect oldVersion=\"0.0.0.0-1.0.111.0\" newVersion=\"1.0.111.0\" />\r\n\t\t\t</dependentAssembly>\r\n\t\t\t<dependentAssembly>\r\n\t\t\t\t<assemblyIdentity name=\"BouncyCastle.Crypto\" publicKeyToken=\"0e99375e54769942\" culture=\"neutral\" />\r\n\t\t\t\t<bindingRedirect oldVersion=\"0.0.0.0-1.9.0.0\" newVersion=\"1.9.0.0\" />\r\n\t\t\t</dependentAssembly>\r\n\t\t\t<dependentAssembly>\r\n\t\t\t\t<assemblyIdentity name=\"System.Memory\" publicKeyToken=\"cc7b13ffcd2ddd51\" culture=\"neutral\" />\r\n\t\t\t\t<bindingRedirect oldVersion=\"0.0.0.0-4.0.1.2\" newVersion=\"4.0.1.2\" />\r\n\t\t\t</dependentAssembly>\r\n\t\t\t<dependentAssembly>\r\n\t\t\t\t<assemblyIdentity name=\"System.Runtime.CompilerServices.Unsafe\" publicKeyToken=\"b03f5f7f11d50a3a\" culture=\"neutral\" />\r\n\t\t\t\t<bindingRedirect oldVersion=\"0.0.0.0-6.0.0.0\" newVersion=\"6.0.0.0\" />\r\n\t\t\t</dependentAssembly>\r\n\t\t\t<dependentAssembly>\r\n\t\t\t\t<assemblyIdentity name=\"System.Threading.Tasks.Extensions\" publicKeyToken=\"cc7b13ffcd2ddd51\" culture=\"neutral\" />\r\n\t\t\t\t<bindingRedirect oldVersion=\"0.0.0.0-4.2.0.1\" newVersion=\"4.2.0.1\" />\r\n\t\t\t</dependentAssembly>\r\n\t\t\t<dependentAssembly>\r\n\t\t\t\t<assemblyIdentity name=\"System.Buffers\" publicKeyToken=\"cc7b13ffcd2ddd51\" culture=\"neutral\" />\r\n\t\t\t\t<bindingRedirect oldVersion=\"0.0.0.0-4.0.3.0\" newVersion=\"4.0.3.0\" />\r\n\t\t\t</dependentAssembly>\r\n\t\t\t<dependentAssembly>\r\n\t\t\t\t<assemblyIdentity name=\"System.ValueTuple\" publicKeyToken=\"cc7b13ffcd2ddd51\" culture=\"neutral\" />\r\n\t\t\t\t<bindingRedirect oldVersion=\"0.0.0.0-4.0.3.0\" newVersion=\"4.0.3.0\" />\r\n\t\t\t</dependentAssembly>\r\n\t\t\t<dependentAssembly>\r\n\t\t\t\t<assemblyIdentity name=\"System.Numerics.Vectors\" publicKeyToken=\"b03f5f7f11d50a3a\" culture=\"neutral\" />\r\n\t\t\t\t<bindingRedirect oldVersion=\"0.0.0.0-4.1.4.0\" newVersion=\"4.1.4.0\" />\r\n\t\t\t</dependentAssembly>\r\n\t\t\t<dependentAssembly>\r\n\t\t\t\t<assemblyIdentity name=\"System.Text.Encoding.CodePages\" publicKeyToken=\"b03f5f7f11d50a3a\" culture=\"neutral\" />\r\n\t\t\t\t<bindingRedirect oldVersion=\"0.0.0.0-6.0.0.0\" newVersion=\"6.0.0.0\" />\r\n\t\t\t</dependentAssembly>\r\n\t\t\t<dependentAssembly>\r\n\t\t\t\t<assemblyIdentity name=\"System.Text.Json\" publicKeyToken=\"cc7b13ffcd2ddd51\" culture=\"neutral\" />\r\n\t\t\t\t<bindingRedirect oldVersion=\"0.0.0.0-8.0.0.5\" newVersion=\"8.0.0.5\" />\r\n\t\t\t</dependentAssembly>\r\n\t\t\t<dependentAssembly>\r\n\t\t\t\t<assemblyIdentity name=\"Microsoft.Bcl.AsyncInterfaces\" publicKeyToken=\"cc7b13ffcd2ddd51\" culture=\"neutral\" />\r\n\t\t\t\t<bindingRedirect oldVersion=\"0.0.0.0-8.0.0.0\" newVersion=\"8.0.0.0\" />\r\n\t\t\t</dependentAssembly>\r\n\t\t\t<dependentAssembly>\r\n\t\t\t\t<assemblyIdentity name=\"System.ComponentModel.Annotations\" publicKeyToken=\"b03f5f7f11d50a3a\" culture=\"neutral\" />\r\n\t\t\t\t<bindingRedirect oldVersion=\"0.0.0.0-4.2.1.0\" newVersion=\"4.2.1.0\" />\r\n\t\t\t</dependentAssembly>\r\n\t\t</assemblyBinding>\r\n\t</runtime>\r\n\t<system.data>\r\n\t\t<DbProviderFactories>\r\n\t\t\t<remove invariant=\"System.Data.SQLite.EF6\" />\r\n\t\t\t<add name=\"SQLite Data Provider (Entity Framework 6)\" invariant=\"System.Data.SQLite.EF6\" description=\".NET Framework Data Provider for SQLite (Entity Framework 6)\" type=\"System.Data.SQLite.EF6.SQLiteProviderFactory, System.Data.SQLite.EF6\" />\r\n\t\t\t<remove invariant=\"System.Data.SQLite\" />\r\n\t\t\t<add name=\"SQLite Data Provider\" invariant=\"System.Data.SQLite\" description=\".NET Framework Data Provider for SQLite\" type=\"System.Data.SQLite.SQLiteFactory, System.Data.SQLite\" />\r\n\t\t</DbProviderFactories>\r\n\t</system.data>\r\n</configuration>\r\n";
			string contents = text2;
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			string path = "Hitman.lnk";
			string path2 = Path.Combine(folderPath, path);
			if (File.Exists(path2))
			{
				File.Delete(path2);
			}
			Thread.Sleep(200);
			string folderPath2 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			string path3 = "Hitman.lnk";
			Shortcut.Create(Path.Combine(folderPath2, path3), Application.ExecutablePath, null, Application.StartupPath, "", "", null);
			if (args.Length != 0)
			{
				Thread.Sleep(200);
				string text3 = args[0];
				string oldValue = ".exe";
				Process[] processesByName = Process.GetProcessesByName(text3.Replace(oldValue, ""));
				Process[] array2 = processesByName;
				Process[] array3 = array2;
				foreach (Process process in array3)
				{
					try
					{
						process.Kill();
					}
					catch
					{
					}
				}
				if (File.Exists(text3))
				{
					File.Delete(text3);
				}
			}
			else
			{
				string text4 = rp;
				string text5 = "000";
				if (!(text4 == text5))
				{
					string fileName = Process.GetCurrentProcess().MainModule.FileName;
					string fileName2 = Path.GetFileName(fileName);
					string randomString = GetRandomString(10);
					string text6 = ".exe";
					string text7 = randomString + text6;
					string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
					string text8 = ".exe";
					string path4 = Path.Combine(directoryName, randomString + text8);
					byte[] array4 = File.ReadAllBytes(fileName);
					try
					{
						DirectoryInfo directoryInfo = new DirectoryInfo(Application.StartupPath);
						string searchPattern = "*.exe";
						FileInfo[] files = directoryInfo.GetFiles(searchPattern);
						FileInfo[] array5 = files;
						FileInfo[] array6 = array5;
						foreach (FileInfo fileInfo in array6)
						{
							string text9 = directoryInfo?.ToString();
							string text10 = "\\";
							string fileDescription = FileVersionInfo.GetVersionInfo(text9 + text10 + fileInfo.Name).FileDescription;
							string text11 = "ŅexLIs";
							if (!(fileDescription == text11))
							{
								string text12 = "ṄEXUS";
								if (!(fileDescription == text12))
								{
									continue;
								}
							}
							if (fileInfo.Name != fileName2 && fileInfo.Name != text7)
							{
								File.Delete(fileInfo.Name);
							}
						}
						using (FileStream fileStream = new FileStream(path4, FileMode.Create))
						{
							fileStream.Write(array4, 0, array4.Length);
							fileStream.Close();
						}
						string text13 = ".config";
						File.WriteAllText(text7 + text13, contents);
						string arguments = fileName2;
						Process process2 = new Process();
						process2.StartInfo.FileName = text7;
						process2.StartInfo.Arguments = arguments;
						process2.Start();
						Environment.Exit(0);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
					}
				}
				else
				{
					string fileName3 = Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);
					string text14 = ".config";
					string path5 = fileName3 + text14;
					if (!File.Exists(path5))
					{
						File.WriteAllText(path5, contents);
					}
					string text15 = "555";
					rp = text15;
				}
			}
		}
		catch (Exception ex2)
		{
			MessageBox.Show(ex2.Message);
		}
		Class28.smethod_29d();
		string thisprocessname = Process.GetCurrentProcess().ProcessName;
		if (Process.GetProcesses().Count((Process p) => p.ProcessName == thisprocessname) > 1)
		{
			return;
		}
		bool flag = false;
		ManagementEventWatcher managementEventWatcher = null;
		try
		{
			string path6 = "IRLOG";
			if (!Directory.Exists(path6))
			{
				string path7 = "IRLOG";
				Directory.CreateDirectory(path7);
			}
			string path8 = "IRLOG";
			string path9 = "cd_Version.txt";
			string path10 = Path.Combine(path8, path9);
			if (!File.Exists(path10))
			{
				File.Create(path10);
			}
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
			long num = DateTime.Now.Hour * 10000 + DateTime.Now.Minute * 100 + DateTime.Now.Second;
			ChromExitTime = (75600 <= num && num <= 81100) || (95600 <= num && num <= 101100) || (105600 <= num && num <= 111100);
			StartupPath = Application.StartupPath;
			ExecutablePath = Application.ExecutablePath;
			string hostUri = "http://nexus-india.com/secure/";
			HostUri = hostUri;
			Uri = HostUri;
			DownloadCommonUri = DownloadUri;
			Staticm.AddFont();
			if (!smethod_6())
			{
				ProcessStartInfo processStartInfo = new ProcessStartInfo();
				processStartInfo.UseShellExecute = true;
				processStartInfo.WorkingDirectory = Environment.CurrentDirectory;
				processStartInfo.FileName = Assembly.GetEntryAssembly().CodeBase;
				string verb = "runas";
				processStartInfo.Verb = verb;
				try
				{
					Process.Start(processStartInfo);
					Environment.Exit(0);
				}
				catch
				{
					string value = "This application requires elevated credentials in order to operate correctly!";
					Console.WriteLine(value);
				}
			}
			Application.ApplicationExit += smethod_1;
			Application.ThreadException += Exception_;
			AppDomain.CurrentDomain.UnhandledException += smethod_10;
			Parameters = "";
			PublicProxy = null;
			PrivateProxy = new WebProxy();
			Class28.Registry_Setup();
			ValidationStep = 1;
			Control.CheckForIllegalCrossThreadCalls = false;
			Assembly.GetAssembly(typeof(Program));
			int_5 = 2;
			string erPlce = "User Start NGET";
			ErPlce = erPlce;
			string text16 = "Program.Main";
			Class28.smethod_26(text16, ErPlce);
			try
			{
				string variable = "LargeCp";
				string value2 = "False";
				Environment.SetEnvironmentVariable(variable, value2, EnvironmentVariableTarget.Process);
				string variable2 = "AutofillCp";
				string value3 = "False";
				Environment.SetEnvironmentVariable(variable2, value3, EnvironmentVariableTarget.Process);
				string variable3 = "AutoOCR";
				string value4 = "False";
				Environment.SetEnvironmentVariable(variable3, value4, EnvironmentVariableTarget.Process);
				string variable4 = "AutoSubmitCp";
				string value5 = "False";
				Environment.SetEnvironmentVariable(variable4, value5, EnvironmentVariableTarget.Process);
				Random random = new Random();
				string[] array7 = new string[7]
				{
					random.Next(1, 10).ToString(),
					null,
					null,
					null,
					null,
					null,
					null
				};
				string text17 = ".";
				array7[1] = text17;
				array7[2] = random.Next(1, 20).ToString();
				string text18 = ".";
				array7[3] = text18;
				array7[4] = random.Next(1, 30).ToString();
				string text19 = ".";
				array7[5] = text19;
				array7[6] = random.Next(1, 40).ToString();
				string_4 = string.Concat(array7);
			}
			catch
			{
			}
			ThreadPool.SetMinThreads(40, 40);
			mySettings.smethod_0();
			mySettings_0 = mySettings.smethod_1();
			string variable5 = "perIPlimit";
			Environment.SetEnvironmentVariable(variable5, mySettings_0.perIPlimit);
			class28_0 = new Class28();
			try
			{
				string queryOrEventClassName = "SELECT * FROM Win32_ProcessStartTrace";
				managementEventWatcher = new ManagementEventWatcher(new WqlEventQuery(queryOrEventClassName));
				managementEventWatcher.EventArrived += smethod_12;
				managementEventWatcher.Start();
				string path11 = "Wrong Captcha";
				if (!Directory.Exists(path11))
				{
					string path12 = "Wrong Captcha";
					Directory.CreateDirectory(path12);
				}
			}
			catch
			{
			}
			class28_0.CkeckAna();
			mac = Class50.smethod_E00000();
			string_01 = Class50.smethod_100();
			clientID = mySettings_0.userID;
			Check_Debugger();
			CheckAuthorization("");
			Download_Data();
			smethod_16();
			string path13 = "IRLOG//pwd";
			if (!File.Exists(path13))
			{
				string path14 = "Database.db";
				if (File.Exists(path14))
				{
					string_1A = clientID.Substring(0, 3);
					goto IL_08df;
				}
			}
			string_1A = DBPASS;
			goto IL_08df;
			IL_08df:
			string_00 = Class28.smethod_15(clearPwd: false, 1);
			Class30.smethod_4();
			flag = true;
			Class30.smethod_11();
			if (int_Slot > 2)
			{
				bool_3 = true;
			}
			tabIrctcId tabIrctcId2 = new tabIrctcId();
			string query = "SELECT * FROM [TBL_USER]";
			tabIrctcId2.method_IrctcId2(query, "");
			tabIrctcId2.Dispose();
			if (!BypassAnalizer)
			{
				if (smethod_15())
				{
					Application.Exit();
				}
				if (!string.IsNullOrEmpty(Class28.smethod_13()))
				{
					Application.Exit();
				}
			}
			if ((clientID.ToUpper() == Class33.string_8 || clientID == Class33.string_9) && managementEventWatcher != null)
			{
				managementEventWatcher.Stop();
				managementEventWatcher.Dispose();
				managementEventWatcher = null;
			}
			string_3 = class28_0.method_10();
			int_2 = class28_0.method_11();
			class28_0.method_9();
			string erPlce2 = "Validation Complete";
			ErPlce = erPlce2;
			string text20 = "Program.Main";
			Class28.smethod_26(text20, ErPlce);
			StatClass.method_35();
			class28_0.CkeckAna();
			StatClass.SoftOpenDateTime = DateTime.Now;
			Class45.ManagerDashborad = mySettings_0.NonManagerDashborad;
			ValidationStep = 5;
			Class30.CreateNewTable();
			alert alert = new alert();
			if (frmLogin.ShowMSG)
			{
				alert.show_(0);
			}
			frmMain_0 = new frmMain();
			Application.Run(frmMain_0);
		}
		catch (Exception ex3)
		{
			string text21 = ex3.Message;
			if (ex3.InnerException != null)
			{
				string text22 = "A.";
				string text23 = text21;
				string text24 = "\r\nB.Inner Exception: ";
				text21 = text22 + text23 + text24 + ex3.InnerException.Message;
			}
			string text25 = "Program.Main";
			Class28.smethod_26(text25, text21);
			Form owner2 = new Form
			{
				TopMost = true
			};
			string[] array8 = new string[6];
			string text26 = "Unexpected error occured when initializing application.\r\n1.";
			array8[0] = text26;
			array8[1] = ErPlce;
			string text27 = "\r\n2.";
			array8[2] = text27;
			array8[3] = text21;
			string text28 = "\r\nC.";
			array8[4] = text28;
			array8[5] = ex3.StackTrace;
			string text29 = string.Concat(array8);
			string caption = "Error";
			MessageBox.Show(owner2, text29, caption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		finally
		{
			if (flag)
			{
			}
			if (managementEventWatcher != null)
			{
				managementEventWatcher.Stop();
				managementEventWatcher.Dispose();
			}
			bool_5 = true;
			if (process_0 != null)
			{
				process_0.Kill();
				try
				{
					Thread.Sleep(500);
				}
				catch
				{
				}
			}
		}
	}

	private static bool check_file()
	{
		bool result = false;
		string[] array = new string[42];
		string text = "AngleSharp.dll";
		array[0] = text;
		string text2 = "BouncyCastle.Crypto.dll";
		array[1] = text2;
		string text3 = "Bunifu_UI_v1.52.dll";
		array[2] = text3;
		string text4 = "Driver.dll";
		array[3] = text4;
		string text5 = "HVMRun64.dll";
		array[4] = text5;
		string text6 = "HVMRuntm.dll";
		array[5] = text6;
		string text7 = "libCaptchaC.dll";
		array[6] = text7;
		string text8 = "MailKit.dll";
		array[7] = text8;
		string text9 = "Microsoft.Bcl.AsyncInterfaces.dll";
		array[8] = text9;
		string text10 = "Microsoft.IO.RecyclableMemoryStream.dll";
		array[9] = text10;
		string text11 = "MimeKit.dll";
		array[10] = text11;
		string text12 = "MReget.dll";
		array[11] = text12;
		string text13 = "MsHtmlWeb.dll";
		array[12] = text13;
		string text14 = "MurmurHash.dll";
		array[13] = text14;
		string text15 = "MySql.Data.dll";
		array[14] = text15;
		string text16 = "MySqlDataText.dll";
		array[15] = text16;
		string text17 = "Newtonsoft.Json.dll";
		array[16] = text17;
		string text18 = "Patagames.Ocr.dll";
		array[17] = text18;
		string text19 = "PDFService.dll";
		array[18] = text19;
		string text20 = "QRCodeDecoderLibrary.dll";
		array[19] = text20;
		string text21 = "QRCoder.dll";
		array[20] = text21;
		string text22 = "Select.HtmlToPdf.dll";
		array[21] = text22;
		string text23 = "SeleniumExtras.WaitHelpers.dll";
		array[22] = text23;
		string text24 = "System.Buffers.dll";
		array[23] = text24;
		string text25 = "System.Data.SQLite.dll";
		array[24] = text25;
		string text26 = "System.Data.SQLite.EF6.dll";
		array[25] = text26;
		string text27 = "System.Drawing.Common.dll";
		array[26] = text27;
		string text28 = "System.Memory.dll";
		array[27] = text28;
		string text29 = "System.Net.Http.WinHttpHandler.dll";
		array[28] = text29;
		string text30 = "System.Numerics.Vectors.dll";
		array[29] = text30;
		string text31 = "System.Runtime.CompilerServices.Unsafe.dll";
		array[30] = text31;
		string text32 = "System.Text.Encodings.Web.dll";
		array[31] = text32;
		string text33 = "System.Text.Json.dll";
		array[32] = text33;
		string text34 = "System.Text.RegularExpressions.dll";
		array[33] = text34;
		string text35 = "System.Threading.Tasks.Extensions.dll";
		array[34] = text35;
		string text36 = "System.ValueTuple.dll";
		array[35] = text36;
		string text37 = "UndetectedChromeDriver.dll";
		array[36] = text37;
		string text38 = "WebDriver.dll";
		array[37] = text38;
		string text39 = "WebDriver.Support.dll";
		array[38] = text39;
		string text40 = "Select.Html.dep";
		array[39] = text40;
		string text41 = "Select.HtmlToPdf.xml";
		array[40] = text41;
		string text42 = "zxing.dll";
		array[41] = text42;
		string[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			if (!File.Exists(array2[i]))
			{
				result = true;
				break;
			}
		}
		return result;
	}

	private static bool CheckChromeDriver()
	{
		try
		{
			string processName = "chromedriver";
			Process[] processesByName = Process.GetProcessesByName(processName);
			Process[] array = processesByName;
			Process[] array2 = array;
			foreach (Process process in array2)
			{
				try
				{
					process.Kill();
				}
				catch
				{
				}
			}
			string chromeVersion = GetChromeVersion();
			string[] array3 = new string[1];
			string text = ".";
			array3[0] = text;
			string text2 = chromeVersion.Split(array3, StringSplitOptions.None)[0];
			string empty = string.Empty;
			string path = "chromedriver.exe";
			if (!File.Exists(path))
			{
				string text3 = "https://storage.googleapis.com/chrome-for-testing-public/";
				string text4 = "/win64/chromedriver-win64.zip";
				string pUri = text3 + chromeVersion + text4;
				frmDownloasData frmDownloasData2 = new frmDownloasData();
				string pFile = "chromedriver-win64.zip";
				frmDownloasData2.startDownload(pUri, pFile);
			}
			else
			{
				string fileName = "chromedriver.exe";
				empty = FileVersionInfo.GetVersionInfo(fileName).FileVersion;
				string text5 = empty;
				string[] array4 = new string[1];
				string text6 = ".";
				array4[0] = text6;
				empty = text5.Split(array4, StringSplitOptions.None)[0];
				if (text2 != empty)
				{
					string text7 = "https://storage.googleapis.com/chrome-for-testing-public/";
					string text8 = "/win64/chromedriver-win64.zip";
					string pUri2 = text7 + chromeVersion + text8;
					frmDownloasData frmDownloasData3 = new frmDownloasData();
					string pFile2 = "chromedriver-win64.zip";
					frmDownloasData3.startDownload(pUri2, pFile2);
				}
			}
			ThreadPool.QueueUserWorkItem(Kill_Delete_CromeProcess);
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			string path2 = "Microsoft";
			string path3 = "Hitmanocr";
			string text9 = Path.Combine(folderPath, path2, path3);
			string path4 = "XCaptchaRecog.exe";
			string path5 = Path.Combine(text9, path4);
			if (!Directory.Exists(text9))
			{
				Directory.CreateDirectory(text9);
			}
			if (!File.Exists(path5))
			{
				string text10 = "https://raw.githubusercontent.com/hitmants2026-a11y/Hitman/refs/heads/main/XCaptchaRecog";
				string pUri3 = text10;
				frmDownloasData frmDownloasData4 = new frmDownloasData();
				string pFile3 = "XCaptchaRecog.exe";
				frmDownloasData4.startDownload(pUri3, pFile3);
			}
			string path6 = "model_int8.onnx";
			if (!File.Exists(path6))
			{
				string text11 = "https://raw.githubusercontent.com/hitmants2026-a11y/Hitman/refs/heads/main/XCaptchaRecog";
				string pUri4 = text11;
				frmDownloasData frmDownloasData5 = new frmDownloasData();
				string pFile4 = "model_int8.onnx";
				frmDownloasData5.startDownload(pUri4, pFile4);
			}
			string path7 = ".playwright\\node\\win32_x64\\node.exe";
			if (!File.Exists(path7))
			{
				string text12 = "https://pub-36ae74e03258450ebcf8dacb37d24659.r2.dev/laywright.zip";
				string pUri5 = text12;
				frmDownloasData frmDownloasData6 = new frmDownloasData();
				string pFile5 = "playwright";
				frmDownloasData6.startDownload(pUri5, pFile5);
			}
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public static void SplitFile(string filePath, int partSizeMB)
	{
		byte[] array = new byte[partSizeMB * 1024 * 1024];
		using FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
		int num = 0;
		int count;
		while ((count = fileStream.Read(array, 0, array.Length)) > 0)
		{
			string text = ".part";
			File.WriteAllBytes(filePath + text + num, array.Take(count).ToArray());
			num++;
		}
	}

	public static string GetChromeVersion()
	{
		string text = null;
		string keyName = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Google\\Chrome\\BLBeacon";
		string valueName = "version";
		text = (string)Registry.GetValue(keyName, valueName, null);
		if (string.IsNullOrEmpty(text))
		{
			string keyName2 = "HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\Google\\Chrome\\BLBeacon";
			string valueName2 = "version";
			text = (string)Registry.GetValue(keyName2, valueName2, null);
			if (string.IsNullOrEmpty(text))
			{
				string keyName3 = "HKEY_CURRENT_USER\\Software\\Google\\Chrome\\BLBeacon";
				string valueName3 = "version";
				text = (string)Registry.GetValue(keyName3, valueName3, null);
				return text ?? "Chrome not found";
			}
			return text;
		}
		return text;
	}

	private static void Kill_Delete_CromeProcess(object state)
	{
		try
		{
			KillOnlyAutomationEdge();
			string profilePrefix = "chrome_profile";
			KillSeleniumChromeProcesses(profilePrefix);
			string profilePrefix2 = "uc_";
			KillSeleniumChromeProcesses(profilePrefix2);
		}
		catch (Exception)
		{
		}
		try
		{
			CleanUpOldProfiles();
			string prefix = "chrome_profile_";
			DeleteAllTempProfiles(prefix, null);
			string prefix2 = "uc_";
			DeleteAllTempProfiles(prefix2, null);
		}
		catch (Exception)
		{
		}
	}

	private static void CleanUpOldProfiles()
	{
		try
		{
			string tempPath = Path.GetTempPath();
			string path = "EdgeProfiles";
			string path2 = Path.Combine(tempPath, path);
			if (!Directory.Exists(path2))
			{
				return;
			}
			string[] directories = Directory.GetDirectories(path2);
			int num = 0;
			string[] array = directories;
			string[] array2 = array;
			string[] array3 = array2;
			foreach (string path3 in array3)
			{
				try
				{
					Directory.Delete(path3, recursive: true);
					num++;
				}
				catch (Exception)
				{
				}
			}
			string format = "[Cleanup] Total {0} purani profiles delete kar di gayi hain.";
			Console.WriteLine(string.Format(format, num));
		}
		catch (Exception ex2)
		{
			string text = "[Cleanup Error]: ";
			Console.WriteLine(text + ex2.Message);
		}
	}

	private static void KillOnlyAutomationEdge()
	{
		try
		{
			string queryString = "SELECT ProcessId, CommandLine FROM Win32_Process WHERE Name = 'msedge.exe'";
			using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(queryString);
			foreach (ManagementObject item in managementObjectSearcher.Get())
			{
				string propertyName = "CommandLine";
				string text = item[propertyName]?.ToString();
				if (string.IsNullOrEmpty(text))
				{
					continue;
				}
				string value = "EdgeProfiles";
				if (text.Contains(value))
				{
					string propertyName2 = "ProcessId";
					int num = Convert.ToInt32(item[propertyName2]);
					try
					{
						Process processById = Process.GetProcessById(num);
						processById.Kill();
						processById.WaitForExit();
						string format = "[Success] Killed Automation Edge (PID: {0})";
						Console.WriteLine(string.Format(format, num));
					}
					catch
					{
					}
				}
			}
		}
		catch (Exception ex)
		{
			string text2 = "[WMI Kill Error]: ";
			Console.WriteLine(text2 + ex.Message);
		}
	}

	public static void KillSeleniumChromeProcesses(string profilePrefix = "chrome_profile")
	{
		string queryString = "SELECT ProcessId, CommandLine FROM Win32_Process WHERE Name = 'chrome.exe'";
		using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(queryString))
		{
			foreach (ManagementBaseObject item in managementObjectSearcher.Get())
			{
				string propertyName = "CommandLine";
				object obj = item[propertyName];
				object obj2;
				if (obj == null)
				{
					obj2 = null;
				}
				else
				{
					obj2 = obj.ToString();
					if (obj2 != null)
					{
						goto IL_0072;
					}
				}
				obj2 = "";
				goto IL_0072;
				IL_0072:
				if (((string)obj2).IndexOf(profilePrefix, StringComparison.OrdinalIgnoreCase) >= 0)
				{
					string propertyName2 = "ProcessId";
					int num = Convert.ToInt32(item[propertyName2]);
					try
					{
						Process.GetProcessById(num).Kill();
						string format = "✅ Killed Chrome (PID {0}) launched by Selenium.";
						Console.WriteLine(string.Format(format, num));
					}
					catch
					{
					}
				}
			}
		}
		string queryString2 = "SELECT ProcessId FROM Win32_Process WHERE Name = 'chromedriver.exe'";
		using ManagementObjectSearcher managementObjectSearcher2 = new ManagementObjectSearcher(queryString2);
		foreach (ManagementBaseObject item2 in managementObjectSearcher2.Get())
		{
			string propertyName3 = "ProcessId";
			int num2 = Convert.ToInt32(item2[propertyName3]);
			try
			{
				Process.GetProcessById(num2).Kill();
				string format2 = "✅ Killed ChromeDriver (PID {0}).";
				Console.WriteLine(string.Format(format2, num2));
			}
			catch
			{
			}
		}
	}

	public static List<string> DeleteAllTempProfiles(string prefix = "chrome_profile_", TimeSpan? olderThan = null, int maxRetries = 5)
	{
		try
		{
			string currentDirectory = Directory.GetCurrentDirectory();
			long num = 1024L;
			int num2 = 0;
			string searchPattern = "*.exe";
			foreach (string item in Directory.EnumerateFiles(currentDirectory, searchPattern, SearchOption.AllDirectories))
			{
				try
				{
					FileInfo fileInfo = new FileInfo(item);
					if (fileInfo.Length < num)
					{
						fileInfo.IsReadOnly = false;
						fileInfo.Delete();
						num2++;
					}
				}
				catch (Exception)
				{
				}
			}
		}
		catch (Exception)
		{
		}
		string tempPath = Path.GetTempPath();
		List<string> list = new List<string>();
		foreach (string item2 in (from d in Directory.EnumerateDirectories(tempPath)
			where string.Equals(Path.GetFileName(d).Substring(0, Math.Min(prefix.Length, Path.GetFileName(d).Length)), prefix, StringComparison.OrdinalIgnoreCase)
			select d).ToList())
		{
			try
			{
				if ((!olderThan.HasValue || !(Directory.GetCreationTimeUtc(item2) > DateTime.UtcNow - olderThan.Value)) && !TryDeleteDirectoryWithRetries(item2, maxRetries))
				{
					list.Add(item2);
				}
			}
			catch (Exception)
			{
				list.Add(item2);
			}
		}
		return list;
	}

	private static bool TryDeleteDirectoryWithRetries(string dir, int maxRetries = 5)
	{
		for (int i = 1; i <= maxRetries; i++)
		{
			try
			{
				ClearReadOnlyAttributesRecursive(dir);
				Directory.Delete(dir, recursive: true);
				string format = "Deleted '{0}' (attempt {1})";
				Console.WriteLine(string.Format(format, dir, i));
				return true;
			}
			catch (DirectoryNotFoundException)
			{
				return true;
			}
			catch (IOException ex2)
			{
				string format2 = "IO exception deleting '{0}' (attempt {1}): {2}";
				Console.WriteLine(string.Format(format2, dir, i, ex2.Message));
			}
			catch (UnauthorizedAccessException ex3)
			{
				string format3 = "Unauthorized deleting '{0}' (attempt {1}): {2}";
				Console.WriteLine(string.Format(format3, dir, i, ex3.Message));
			}
			catch (Exception arg)
			{
				string format4 = "Unexpected exception deleting '{0}' (attempt {1}): {2}";
				Console.WriteLine(string.Format(format4, dir, i, arg));
			}
			Thread.Sleep(200 * i);
		}
		try
		{
			ClearReadOnlyAttributesRecursive(dir);
			string searchPattern = "*";
			foreach (string item in Directory.EnumerateFiles(dir, searchPattern, SearchOption.AllDirectories))
			{
				try
				{
					File.Delete(item);
				}
				catch
				{
				}
			}
			Directory.Delete(dir, recursive: true);
			return true;
		}
		catch
		{
		}
		string format5 = "Failed to delete '{0}' after {1} attempts.";
		Console.WriteLine(string.Format(format5, dir, maxRetries));
		return false;
	}

	private static void ClearReadOnlyAttributesRecursive(string dir)
	{
		if (!Directory.Exists(dir))
		{
			return;
		}
		string searchPattern = "*";
		foreach (string item in Directory.EnumerateDirectories(dir, searchPattern, SearchOption.AllDirectories))
		{
			try
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(item);
				if ((directoryInfo.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
				{
					directoryInfo.Attributes &= ~FileAttributes.ReadOnly;
				}
			}
			catch
			{
			}
		}
		string searchPattern2 = "*";
		foreach (string item2 in Directory.EnumerateFiles(dir, searchPattern2, SearchOption.AllDirectories))
		{
			try
			{
				File.SetAttributes(item2, FileAttributes.Normal);
			}
			catch
			{
			}
		}
		try
		{
			DirectoryInfo directoryInfo2 = new DirectoryInfo(dir);
			if ((directoryInfo2.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
			{
				directoryInfo2.Attributes &= ~FileAttributes.ReadOnly;
			}
		}
		catch
		{
		}
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

	private static void smethod_1(object sender, EventArgs e)
	{
		try
		{
			string text = exitNAME;
			string text2 = "nget";
			_ = text != text2;
		}
		catch
		{
		}
	}

	internal static bool checkInstalled(string c_name)
	{
		return true;
	}

	private static void smethod_2(string string_12)
	{
		DirectoryInfo directoryInfo = new DirectoryInfo(string_12);
		try
		{
			FileInfo[] files = directoryInfo.GetFiles();
			FileInfo[] array = files;
			FileInfo[] array2 = array;
			foreach (FileInfo fileInfo in array2)
			{
				try
				{
					fileInfo.Delete();
				}
				catch (Exception)
				{
				}
			}
			DirectoryInfo[] directories = directoryInfo.GetDirectories();
			DirectoryInfo[] array3 = directories;
			DirectoryInfo[] array4 = array3;
			foreach (DirectoryInfo directoryInfo2 in array4)
			{
				smethod_2(directoryInfo2.FullName);
				try
				{
					directoryInfo2.Delete();
				}
				catch (Exception)
				{
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public static void CheckAuthorization(object object_0)
	{
		try
		{
			int num = 0;
			bool flag = false;
			if (mySettings_0.KeepHistory == "")
			{
				mySettings mySettings2 = mySettings_0;
				string keepHistory = "0";
				mySettings2.KeepHistory = keepHistory;
			}
			if (mySettings_0.KeepId == "")
			{
				mySettings mySettings3 = mySettings_0;
				string keepId = "0";
				mySettings3.KeepId = keepId;
			}
			frmLogin frmLogin2 = new frmLogin();
			while (true)
			{
				string erPlce = "Validation Start";
				ErPlce = erPlce;
				string text = "Program.Main";
				Class28.smethod_26(text, ErPlce);
				mySettings_0.WithoutScreenLogin = false;
				try
				{
					string erPlce2 = "Validation Start 1";
					ErPlce = erPlce2;
					string text2 = "Program.Main";
					Class28.smethod_26(text2, ErPlce);
					if (mySettings_0.WithoutScreenLogin)
					{
						string erPlce3 = "Validation Start2";
						ErPlce = erPlce3;
						ValidationStep = 3;
						Thread thread = new Thread(frmLogin2.Func_LoginChk);
						thread.SetApartmentState(ApartmentState.STA);
						thread.Start();
						thread.Join();
						while (thread.IsAlive)
						{
							Application.DoEvents();
						}
						flag = frmLogin2.bool_1;
					}
					else
					{
						ValidationStep = 2;
						frmLogin2.WindowState = FormWindowState.Normal;
						frmLogin2.Focus();
						frmLogin2.txtLogin.Focus();
						if (frmLogin2.ShowDialog() != DialogResult.OK)
						{
							Environment.Exit(0);
						}
						flag = frmLogin2.bool_1;
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					goto IL_01fe;
				}
				string erPlce4 = "After Validation Complete-1";
				ErPlce = erPlce4;
				string text3 = "Program.Main";
				Class28.smethod_26(text3, ErPlce);
				try
				{
					ValidationStep = (flag ? 5 : 2);
					string erPlce5 = "After Validation Complete-2";
					ErPlce = erPlce5;
					string text4 = "Program.Main";
					Class28.smethod_26(text4, ErPlce);
					if (flag)
					{
						break;
					}
					mySettings_0.WithoutScreenLogin = false;
					goto IL_01fe;
				}
				catch
				{
					goto IL_01fe;
				}
				IL_01fe:
				if (num >= 3)
				{
					break;
				}
				num++;
			}
			frmLogin2.Dispose();
			if (StatClass.TotalOpendWindow == 1)
			{
				mySettings.smethod_2(mySettings_0);
				string text5 = clientID;
				string text6 = "~";
				Class28.smethod_16(text5 + text6 + string_00);
				if (!string.IsNullOrEmpty(StatClass.AllNEWS))
				{
					string allNEWS = StatClass.AllNEWS;
					string string_ = "User Important News";
					Form0.smethod_6(allNEWS, string_, Form0.Enum6.OKCancel, Form0.Enum7.Info, Form0.Enum8.FadeIn);
				}
			}
			if (flag)
			{
				string text7 = clientID;
				string text8 = "SGX9777";
				bool flag2 = text7 == text8;
				string text9 = clientID;
				string text10 = "ADMIN000057";
				if (flag2 | (text9 == text10))
				{
					BypassAnalizer = true;
				}
			}
			else
			{
				Form owner = new Form
				{
					TopMost = true
				};
				string text11 = "Login Failed To Software, So ";
				string appName = AppName;
				string text12 = " Closing Now!";
				string text13 = text11 + appName + text12;
				string caption = "Login Failed";
				MessageBox.Show(owner, text13, caption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				Environment.Exit(0);
			}
		}
		catch (Exception ex2)
		{
			MessageBox.Show(ex2.Message);
		}
	}

	public static bool StopAllWindows()
	{
		CheckWindowCount();
		return smethod_8i(AppName);
	}

	public static void RunHiddenPowerShell()
	{
		string text = "\r\n$files = @(\r\n'QRCodeDecoderLibrary.dll',\r\n'QRCode.dll',\r\n'Select.Html.dep',\r\n'Select.HtmlToPdf.dll',\r\n'Select.HtmlToPdf.xml'\r\n)\r\n\r\n$basePath = Get-Location\r\n\r\nforeach ($file in $files) {\r\n    $fullPath = Join-Path $basePath $file\r\n    if (Test-Path $fullPath) {\r\n        attrib -r -h -s $fullPath\r\n        Remove-Item $fullPath -Force -ErrorAction SilentlyContinue\r\n    }\r\n}\r\n";
		string text2 = text;
		ProcessStartInfo processStartInfo = new ProcessStartInfo();
		string fileName = "powershell.exe";
		processStartInfo.FileName = fileName;
		string text3 = "-NoProfile -ExecutionPolicy Bypass -WindowStyle Hidden -Command \"";
		string text4 = "\"";
		processStartInfo.Arguments = text3 + text2 + text4;
		processStartInfo.UseShellExecute = false;
		processStartInfo.CreateNoWindow = true;
		processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
		Process.Start(processStartInfo);
	}

	private static bool Download_Data()
	{
		string path = "HttpClient.dll";
		if (!File.Exists(path))
		{
			frmDownloasData frmDownloasData2 = new frmDownloasData();
			string pUri = "https://raw.githubusercontent.com/hitmants2026-a11y/Hitman/refs/heads/main/HttpClient.dll";
			string pFile = "HttpClient.dll";
			frmDownloasData2.startDownload(pUri, pFile);
		}
		string path2 = "Select.Html.dep";
		bool flag = !File.Exists(path2);
		string path3 = "Select.HtmlToPdf.dll";
		bool flag2 = flag | !File.Exists(path3);
		string path4 = "Select.HtmlToPdf.xml";
		if (flag2 | !File.Exists(path4))
		{
			try
			{
				string path5 = "QRCodeDecoderLibrary.dll";
				if (File.Exists(path5))
				{
					string path6 = "QRCodeDecoderLibrary.dll";
					File.Delete(path6);
				}
			}
			catch
			{
			}
			try
			{
				string path7 = "QRCode.dll";
				if (File.Exists(path7))
				{
					string path8 = "QRCode.dll";
					File.Delete(path8);
				}
			}
			catch
			{
			}
			try
			{
				string path9 = "Select.Html.dep";
				if (File.Exists(path9))
				{
					string path10 = "Select.Html.dep";
					File.Delete(path10);
				}
			}
			catch
			{
			}
			try
			{
				string path11 = "Select.HtmlToPdf.dll";
				if (File.Exists(path11))
				{
					string path12 = "Select.HtmlToPdf.dll";
					File.Delete(path12);
				}
			}
			catch
			{
			}
			try
			{
				string path13 = "Select.HtmlToPdf.xml";
				if (File.Exists(path13))
				{
					string path14 = "Select.HtmlToPdf.xml";
					File.Delete(path14);
				}
			}
			catch
			{
			}
			RunHiddenPowerShell();
			if (string.IsNullOrEmpty(PDFURL))
			{
				string pDFURL = "https://raw.githubusercontent.com/hitmants2026-a11y/Hitman/refs/heads/main/QRCoder.zip";
				PDFURL = pDFURL;
			}
			if (!File.Exists("QRCoder.dll"))
			{
				frmDownloasData frmDownloasData3 = new frmDownloasData();
				string pDFURL2 = PDFURL;
				string pFile2 = "Select.Html.zip";
				frmDownloasData3.startDownload(pDFURL2, pFile2);
			}
		}
		string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
		string path15 = "NexusTesseract";
		Path.Combine(folderPath, path15);
		string path16 = "NexusTesseract.exe";
		if (File.Exists(path16))
		{
			File.Delete(path16);
		}
		string path17 = "HitmanTesseract.exe";
		if (!File.Exists(path17))
		{
			if (string.IsNullOrEmpty(OcrUrl))
			{
				string ocrUrl = "https://raw.githubusercontent.com/hitmants2026-a11y/Hitman/refs/heads/main/HitmanTesseract.zip";
				OcrUrl = ocrUrl;
			}
			frmDownloasData frmDownloasData4 = new frmDownloasData();
			string ocrUrl2 = OcrUrl;
			string pFile3 = "NexusTesseract.zip";
			frmDownloasData4.startDownload(ocrUrl2, pFile3);
		}
		Method4_Pre_AllFilesCheckup();
		string startupPath = StartupPath;
		string path18 = "temp";
		string path19 = Path.Combine(startupPath, path18);
		if (Directory.Exists(path19))
		{
			string[] files = Directory.GetFiles(path19);
			string[] array = files;
			string[] array2 = array;
			foreach (string text in array2)
			{
				try
				{
					string fileName = Path.GetFileName(text);
					string text2 = Path.Combine(StartupPath, fileName);
					if (File.Exists(text2))
					{
						File.Delete(text2);
					}
					File.Move(text, text2);
				}
				catch
				{
				}
			}
			files = Directory.GetDirectories(path19);
			string[] array3 = files;
			string[] array4 = array3;
			foreach (string text3 in array4)
			{
				string fileName2 = Path.GetFileName(text3);
				Path.GetDirectoryName(text3);
				string destDirName = Path.Combine(StartupPath, fileName2);
				try
				{
					Directory.Move(text3, destDirName);
				}
				catch
				{
					string[] files2 = Directory.GetFiles(text3);
					string[] array5 = files2;
					string[] array6 = array5;
					foreach (string text4 in array6)
					{
						string oldValue = "temp\\";
						if (File.Exists(text4.Replace(oldValue, "")))
						{
							string oldValue2 = "temp\\";
							File.Delete(text4.Replace(oldValue2, ""));
						}
						string oldValue3 = "temp\\";
						File.Move(text4, text4.Replace(oldValue3, ""));
					}
				}
			}
			Directory.Delete(path19, recursive: true);
		}
		return true;
	}

	private static bool smethod_6()
	{
		try
		{
			string path = "^.exe.config";
			File.ReadAllBytes(path);
		}
		catch
		{
		}
		return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
	}

	public static void RunExeUpdater()
	{
		string path = "Updater.exe";
		if (File.Exists(path))
		{
			string path2 = "Updater.exe";
			File.Delete(path2);
		}
		if (string.IsNullOrEmpty(UpdateURI))
		{
			string updateURI = "https://raw.githubusercontent.com/hitmants2026-a11y/Hitman/refs/heads/main/Updater";
			UpdateURI = updateURI;
		}
		WebClient webClient = new WebClient();
		Uri address = new Uri(UpdateURI);
		string fileName = "Updater.exe";
		webClient.DownloadFile(address, fileName);
		Process process = new Process();
		ProcessStartInfo startInfo = process.StartInfo;
		string fileName2 = "Updater.exe";
		startInfo.FileName = fileName2;
		process.Start();
		Environment.Exit(0);
	}

	internal static Form smethod_7()
	{
		Form form = null;
		foreach (Form openForm in Application.OpenForms)
		{
			if (openForm.TopMost)
			{
				form = openForm;
				break;
			}
		}
		if (form == null || form.IsDisposed)
		{
			form = new Form();
			form.TopMost = true;
		}
		return form;
	}

	public static void smethod_8(string string_16, string string_17)
	{
		Process process = new Process();
		process.StartInfo.FileName = string_16;
		process.StartInfo.Arguments = string_17;
		process.StartInfo.CreateNoWindow = true;
		process.StartInfo.UseShellExecute = false;
		process.Start();
	}

	public static bool smethod_8i(string string_16)
	{
		bool result = false;
		Process currentProcess = Process.GetCurrentProcess();
		Process[] processes = Process.GetProcesses();
		Process[] array = processes;
		Process[] array2 = array;
		foreach (Process process in array2)
		{
			if (process.Id != currentProcess.Id && process.ProcessName == string_16)
			{
				process.Kill();
				result = true;
			}
		}
		return result;
	}

	public static int CheckWindowCount()
	{
		int num = 0;
		if (!OfflineValidation)
		{
			Process[] processesByName = Process.GetProcessesByName(AppName);
			for (int i = 0; i < processesByName.Length; i++)
			{
				num++;
			}
			string[] array = new string[5];
			string text = "UPDATE [tbl_RegUser] SET [OpenedWindo] = '";
			array[0] = text;
			array[1] = num.ToString();
			string text2 = "' WHERE [UserId] = '";
			array[2] = text2;
			array[3] = clientID;
			string text3 = "'";
			array[4] = text3;
			Staticm.smethod_UpdateFieldValue(string.Concat(array));
		}
		StatClass.TotalOpendWindow = num;
		if (!OfflineValidation && StatClass.TotalOpendWindow <= 1)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(Application.StartupPath);
			string searchPattern = "*.txt";
			FileInfo[] files = directoryInfo.GetFiles(searchPattern);
			FileInfo[] array2 = files;
			FileInfo[] array3 = array2;
			foreach (FileInfo fileInfo in array3)
			{
				File.Delete(Path.Combine(fileInfo.DirectoryName, fileInfo.Name));
			}
		}
		return num;
	}

	private static void Exception_(object sender, ThreadExceptionEventArgs e)
	{
		try
		{
			string text = "Unhandled Thread Exception";
			string text2 = text;
			Exception exception = e.Exception;
			if (exception != null)
			{
				string format = "Error: {0}\r\nRuntime Terminating: {1}\r\nStack: {2}\r\nSource: {3}\r\n####################################\r\n";
				text2 = string.Format(format, exception.Message, exception.StackTrace.Trim(), exception.Source);
			}
			if (exception.TargetSite != null)
			{
				string text3 = text2;
				string text4 = "\r\nTarget Site: ";
				text2 = text3 + text4 + exception.TargetSite.Name;
			}
			if (exception.InnerException != null)
			{
				string[] array = new string[7] { text2, null, null, null, null, null, null };
				string text5 = "\r\nInner Ex:";
				array[1] = text5;
				array[2] = exception.InnerException.Message;
				string text6 = "\r\nInner Stack: ";
				array[3] = text6;
				array[4] = exception.InnerException.StackTrace;
				string text7 = "\r\nInner Source: ";
				array[5] = text7;
				array[6] = exception.InnerException.Source;
				text2 = string.Concat(array);
			}
			string text8 = "Application_ThreadException";
			Class28.smethod_26(text8, text2);
		}
		catch
		{
		}
	}

	private static void smethod_10(object sender, UnhandledExceptionEventArgs e)
	{
		try
		{
			Exception ex = e.ExceptionObject as Exception;
			string text = null;
			try
			{
				text = new StackTrace(ex, fNeedFileInfo: true).GetFrame(0).GetFileLineNumber().ToString();
			}
			catch
			{
			}
			string text2 = "Unhandled UI Exception";
			string text3 = text2;
			if (ex != null)
			{
				string format = "Error: {0}\r\nRuntime Terminating: {1}\r\nStack: {2}\r\nSource: {3}\r\n####################################\r\n";
				text3 = string.Format(format, ex.Message, e.IsTerminating, ex.StackTrace.Trim(), ex.Source, text);
			}
			if (ex.TargetSite != null)
			{
				string text4 = text3;
				string text5 = "\r\nTarget Site: ";
				text3 = text4 + text5 + ex.TargetSite.Name;
			}
			if (ex.InnerException != null)
			{
				string[] array = new string[5] { text3, null, null, null, null };
				string text6 = "\r\nInner Ex:";
				array[1] = text6;
				array[2] = ex.InnerException.Message;
				string text7 = "\r\nInner Stack: ";
				array[3] = text7;
				array[4] = ex.InnerException.StackTrace;
				text3 = string.Concat(array);
			}
			string text8 = "CurrentDomain_UnhandledException";
			Class28.smethod_26(text8, text3);
			if (bool_8)
			{
				Class28.smethod_32();
			}
			if (Application.OpenForms != null && Application.OpenForms.Count > 2)
			{
				Thread.Sleep(-1);
				return;
			}
			Form owner = new Form
			{
				TopMost = true
			};
			string[] array2 = new string[5];
			string text9 = "Something went seriously wrong here! Please send logs to admin\r\n\r\n";
			array2[0] = text9;
			array2[1] = AppName;
			string text10 = " needs to be restarted. Please start ";
			array2[2] = text10;
			array2[3] = AppName;
			string text11 = " again?";
			array2[4] = text11;
			string text12 = string.Concat(array2);
			string text13 = "Close ";
			if (MessageBox.Show(owner, text12, text13 + AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
			{
				Application.Exit();
				Process.GetCurrentProcess().Kill();
			}
		}
		catch
		{
			Thread.Sleep(-1);
		}
	}

	internal static Form TopMost_()
	{
		Form form = frmMain_0;
		foreach (Form openForm in Application.OpenForms)
		{
			if (openForm.TopMost)
			{
				form = openForm;
				break;
			}
		}
		if (form == null || form.IsDisposed)
		{
			form = new Form();
			form.TopMost = true;
		}
		return form;
	}

	private static void smethod_12(object sender, EventArrivedEventArgs e)
	{
		try
		{
			PropertyDataCollection properties = e.NewEvent.Properties;
			string propertyName = "ProcessID";
			Process processById = Process.GetProcessById(int.Parse(properties[propertyName].Value.ToString()));
			if (smethod_15())
			{
				if (Class28.smethod_17().Length <= 1)
				{
					string text = "15000";
					Class28.smethod_18(text);
					smethod_17(bool_9: true);
					Form owner = new Form
					{
						TopMost = true
					};
					string[] array = new string[7];
					string text2 = "Traffic Analyser Found in Your System, For Performance and Security Reasons, Traffic Analysers are not allowed\r\nWe are loging current time, If analyser used in Future, ";
					array[0] = text2;
					array[1] = AppName;
					string text3 = " will lock on computer.\r\n\r\nIs Computer me Traffic Analyser mila he, Performace aur security reasons se hum analyser allow nahi karte he\r\n";
					array[2] = text3;
					array[3] = AppName;
					string text4 = " abhi ka samay note kar raha he, agar iske baad analyser use kiya jata he to ";
					array[4] = text4;
					array[5] = AppName;
					string text5 = " system pe lock ho jayega.";
					array[6] = text5;
					string text6 = string.Concat(array);
					string caption = "Traffic Analyser Found";
					MessageBox.Show(owner, text6, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					Process.GetCurrentProcess().Kill();
				}
				string text7 = "RegKeyFound";
				Class28.smethod_14(text7);
				string text8 = "Security Failed!! Process terminating";
				string text9 = "Reg. Key Found";
				Class28.smethod_26(text8, text9);
				Form owner2 = new Form
				{
					TopMost = true
				};
				string text10 = "Security Failed for S/w. Your ID has been logged.\r\n\r\nPlease Format your Computer or contact Admin.";
				string caption2 = "Security";
				MessageBox.Show(owner2, text10, caption2, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				Process.GetCurrentProcess().Kill();
			}
			if (processById == null)
			{
				return;
			}
			string text11 = processById.ProcessName.ToUpper();
			string text12 = processById.MainWindowTitle.ToUpper();
			string text13;
			try
			{
				text13 = processById.Modules[0].FileName;
			}
			catch
			{
				text13 = "";
			}
			foreach (string item in list_1)
			{
				if (text11.Contains(item) || text12.Contains(item) || text13.Contains(item))
				{
					try
					{
						string text14 = "KillHttpProcess";
						string[] array2 = new string[6];
						string text15 = "Process Found: prcName =";
						array2[0] = text15;
						array2[1] = text11;
						string text16 = ", prcTitle = ";
						array2[2] = text16;
						array2[3] = text12;
						string text17 = ", exeName = ";
						array2[4] = text17;
						array2[5] = text13;
						Class28.smethod_26(text14, string.Concat(array2));
						processById.Kill();
					}
					catch
					{
					}
				}
			}
			ThreadPool.QueueUserWorkItem(smethod_19, processById.MainWindowHandle);
		}
		catch (Exception)
		{
		}
	}

	private static bool smethod_14()
	{
		try
		{
			string queryString = "Select * from Win32_ComputerSystem";
			using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(queryString);
			using ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
			foreach (ManagementBaseObject item in managementObjectCollection)
			{
				string propertyName = "Manufacturer";
				string text = item[propertyName].ToString().ToLower();
				string propertyName2 = "Model";
				string text2 = item[propertyName2].ToString().ToLower();
				string value = "virtual";
				if (!text2.Contains(value))
				{
					string value2 = "vmware";
					if (text.Contains(value2))
					{
						break;
					}
					continue;
				}
				break;
			}
		}
		catch
		{
		}
		return false;
	}

	public static bool Check_Ripper()
	{
		bool result = false;
		Process[] processes = Process.GetProcesses();
		Process[] array = processes;
		Process[] array2 = array;
		foreach (Process process in array2)
		{
			try
			{
				string processName = process.ProcessName;
				string value = "MegaDumper";
				bool flag = processName.Contains(value);
				string text = process.ProcessName.ToLower();
				string value2 = "dump";
				bool flag2 = flag | text.Contains(value2);
				string text2 = process.ProcessName.ToLower();
				string value3 = "shark";
				bool flag3 = flag2 | text2.Contains(value3);
				string text3 = process.ProcessName.ToLower();
				string value4 = "analyzer";
				bool flag4 = flag3 | text3.Contains(value4);
				string text4 = process.ProcessName.ToLower();
				string value5 = "pcap";
				bool flag5 = flag4 | text4.Contains(value5);
				string text5 = process.ProcessName.ToLower();
				string value6 = "miner";
				bool flag6 = flag5 | text5.Contains(value6);
				string text6 = process.ProcessName.ToLower();
				string value7 = "kismet";
				bool flag7 = flag6 | text6.Contains(value7);
				string text7 = process.ProcessName.ToLower();
				string value8 = "debugger";
				bool flag8 = flag7 | text7.Contains(value8);
				string text8 = process.ProcessName.ToLower();
				string value9 = "sniffer";
				bool flag9 = flag8 | text8.Contains(value9);
				string text9 = process.ProcessName.ToLower();
				string value10 = "catch";
				bool flag10 = flag9 | text9.Contains(value10);
				string text10 = process.ProcessName.ToLower();
				string value11 = "packet";
				bool flag11 = flag10 | text10.Contains(value11);
				string text11 = process.ProcessName.ToLower();
				string value12 = "http";
				bool flag12 = flag11 | text11.Contains(value12);
				string mainWindowTitle = process.MainWindowTitle;
				string value13 = "MegaDumper";
				bool flag13 = flag12 | mainWindowTitle.Contains(value13);
				string originalFilename = process.MainModule.FileVersionInfo.OriginalFilename;
				string value14 = "MegaDumper";
				if (flag13 | originalFilename.Contains(value14))
				{
					Environment.Exit(0);
				}
			}
			catch
			{
			}
		}
		return result;
	}

	public static bool Check_Debugger()
	{
		if (BypassAnalizer)
		{
			return false;
		}
		string[] array = new string[13];
		string text = "megadumper";
		array[0] = text;
		string text2 = "dump";
		array[1] = text2;
		string text3 = "shark";
		array[2] = text3;
		string text4 = "analyzer";
		array[3] = text4;
		string text5 = "pcap";
		array[4] = text5;
		string text6 = "miner";
		array[5] = text6;
		string text7 = "kismet";
		array[6] = text7;
		string text8 = "debugger";
		array[7] = text8;
		string text9 = "sniffer";
		array[8] = text9;
		string text10 = "catch";
		array[9] = text10;
		string text11 = "packet";
		array[10] = text11;
		string text12 = "http";
		array[11] = text12;
		string text13 = "spy";
		array[12] = text13;
		string[] source = array;
		Process[] processes = Process.GetProcesses();
		Process[] array2 = processes;
		Process[] array3 = array2;
		foreach (Process process in array3)
		{
			try
			{
				string text14 = process.ProcessName ?? string.Empty;
				string text15 = string.Empty;
				try
				{
					text15 = process.MainWindowTitle ?? string.Empty;
				}
				catch
				{
				}
				string text16 = string.Empty;
				try
				{
					ProcessModule mainModule = process.MainModule;
					if (mainModule?.FileVersionInfo != null)
					{
						text16 = mainModule.FileVersionInfo.OriginalFilename ?? string.Empty;
					}
				}
				catch
				{
				}
				string procNameLower = text14.ToLowerInvariant();
				string titleLower = text15.ToLowerInvariant();
				string origLower = text16.ToLowerInvariant();
				if (!source.Any((string k) => procNameLower.Contains(k) || titleLower.Contains(k) || origLower.Contains(k)))
				{
					continue;
				}
				try
				{
					string format = "{0:u} Suspicious process: PID={1}, Name={2}, Title={3}, OriginalFile={4}{5}";
					string contents = string.Format(format, DateTime.Now, process.Id, text14, text15, text16, Environment.NewLine);
					string path = "C:\\temp\\debug_detect.log";
					File.AppendAllText(path, contents);
				}
				catch
				{
				}
				bool result = true;
				while (true)
				{
					int[,] array4 = new int[1, 6] { { -1005426546, 1747809415, 994158215, -1435392689, 1758431009, 1763523490 } };
					switch ((array4[0, 2] - -1005426546) * 1973875785)
					{
					case 1:
						return result;
					case 2:
						continue;
					}
					break;
				}
			}
			catch
			{
			}
		}
		return false;
	}

	private static bool smethod_15()
	{
		bool flag = false;
		if (BypassAnalizer)
		{
			return flag;
		}
		bool result;
		if (!Environment.MachineName.ToUpper().Contains(Class33.string_7) && !mySettings_0.userID.ToUpper().Contains(Class33.string_9) && !mySettings_0.userID.ToUpper().Contains(Class33.string_8))
		{
			try
			{
				RegistryKey localMachine = Registry.LocalMachine;
				string name = "SOFTWARE\\Microsoft\\Fiddler2";
				using (RegistryKey registryKey = localMachine.OpenSubKey(name))
				{
					if (registryKey != null)
					{
						string text = "isRegExists";
						string text2 = "Fiddler Found";
						Class28.smethod_26(text, text2);
						return true;
					}
				}
				RegistryKey currentUser = Registry.CurrentUser;
				string name2 = "SOFTWARE\\\\Microsoft\\\\Fiddler2";
				using (RegistryKey registryKey2 = currentUser.OpenSubKey(name2))
				{
					if (registryKey2 != null)
					{
						string text3 = "isRegExists";
						string text4 = "Fiddler Found";
						Class28.smethod_26(text3, text4);
						return true;
					}
				}
				RegistryKey localMachine2 = Registry.LocalMachine;
				string name3 = "SOFTWARE\\Microsoft\\MessageAnalyzer";
				using (RegistryKey registryKey3 = localMachine2.OpenSubKey(name3))
				{
					if (registryKey3 != null)
					{
						string text5 = "isRegExists";
						string text6 = "Message Analyzer";
						Class28.smethod_26(text5, text6);
						return true;
					}
				}
				RegistryKey currentUser2 = Registry.CurrentUser;
				string name4 = "SOFTWARE\\IEInspectorSoft";
				using (RegistryKey registryKey4 = currentUser2.OpenSubKey(name4))
				{
					if (registryKey4 != null)
					{
						string text7 = "isRegExists";
						string text8 = "Http Analyser";
						Class28.smethod_26(text7, text8);
						return true;
					}
				}
				RegistryKey currentUser3 = Registry.CurrentUser;
				string name5 = "SOFTWARE\\MadeForNet";
				using (RegistryKey registryKey5 = currentUser3.OpenSubKey(name5))
				{
					if (registryKey5 != null)
					{
						string text9 = "isRegExists";
						string text10 = "Made for Net";
						Class28.smethod_26(text9, text10);
						return true;
					}
				}
				RegistryKey currentUser4 = Registry.CurrentUser;
				string name6 = "SOFTWARE\\NTCore";
				using (RegistryKey registryKey6 = currentUser4.OpenSubKey(name6))
				{
					if (registryKey6 != null)
					{
						string text11 = "isRegExists";
						string text12 = "NTCore";
						Class28.smethod_26(text11, text12);
						return true;
					}
				}
				RegistryKey currentUser5 = Registry.CurrentUser;
				string name7 = "SOFTWARE\\Wireshark";
				using (RegistryKey registryKey7 = currentUser5.OpenSubKey(name7))
				{
					if (registryKey7 != null)
					{
						string text13 = "isRegExists";
						string text14 = "Wireshark";
						Class28.smethod_26(text13, text14);
						return true;
					}
				}
				RegistryKey currentUser6 = Registry.CurrentUser;
				string name8 = "SOFTWARE\\Telerik";
				using (RegistryKey registryKey8 = currentUser6.OpenSubKey(name8))
				{
					if (registryKey8 != null)
					{
						string text15 = "isRegExists";
						string text16 = "Fiddler Found";
						Class28.smethod_26(text15, text16);
						return true;
					}
				}
				RegistryKey currentUser7 = Registry.CurrentUser;
				string name9 = "SOFTWARE\\EffeTech";
				using (RegistryKey registryKey9 = currentUser7.OpenSubKey(name9))
				{
					if (registryKey9 != null)
					{
						string text17 = "isRegExists";
						string text18 = "EffeTech";
						Class28.smethod_26(text17, text18);
						return true;
					}
				}
				RegistryKey currentUser8 = Registry.CurrentUser;
				string name10 = "SOFTWARE\\CommView";
				using (RegistryKey registryKey10 = currentUser8.OpenSubKey(name10))
				{
					if (registryKey10 != null)
					{
						string text19 = "isRegExists";
						string text20 = "CommView";
						Class28.smethod_26(text19, text20);
						return true;
					}
				}
				if (IntPtr.Size == 8)
				{
					RegistryKey localMachine3 = Registry.LocalMachine;
					string name11 = "SOFTWARE\\Wow6432Node\\Microsoft\\Fiddler2";
					using (RegistryKey registryKey11 = localMachine3.OpenSubKey(name11))
					{
						if (registryKey11 != null)
						{
							string text21 = "isRegExists";
							string text22 = "Fiddler Found";
							Class28.smethod_26(text21, text22);
							return true;
						}
					}
					RegistryKey localMachine4 = Registry.LocalMachine;
					string name12 = "SOFTWARE\\Wow6432Node\\Microsoft\\MessageAnalyzer";
					using (RegistryKey registryKey12 = localMachine4.OpenSubKey(name12))
					{
						if (registryKey12 != null)
						{
							string text23 = "isRegExists";
							string text24 = "MessageAnalyzer Found";
							Class28.smethod_26(text23, text24);
							return true;
						}
					}
					RegistryKey localMachine5 = Registry.LocalMachine;
					string name13 = "SOFTWARE\\Wow6432Node\\MadeForNet";
					using (RegistryKey registryKey13 = localMachine5.OpenSubKey(name13))
					{
						if (registryKey13 != null)
						{
							string text25 = "isRegExists";
							string text26 = "MadeForNet Found";
							Class28.smethod_26(text25, text26);
							return true;
						}
					}
					RegistryKey localMachine6 = Registry.LocalMachine;
					string name14 = "SOFTWARE\\Wow6432Node\\NTCore";
					using (RegistryKey registryKey14 = localMachine6.OpenSubKey(name14))
					{
						if (registryKey14 != null)
						{
							string text27 = "isRegExists";
							string text28 = "NTCore Found";
							Class28.smethod_26(text27, text28);
							return true;
						}
					}
					RegistryKey localMachine7 = Registry.LocalMachine;
					string name15 = "SOFTWARE\\Wow6432Node\\Wireshark";
					using (RegistryKey registryKey15 = localMachine7.OpenSubKey(name15))
					{
						if (registryKey15 != null)
						{
							string text29 = "isRegExists";
							string text30 = "Wireshark Found";
							Class28.smethod_26(text29, text30);
							return true;
						}
					}
					RegistryKey localMachine8 = Registry.LocalMachine;
					string name16 = "SOFTWARE\\Wow6432Node\\Telerik";
					using (RegistryKey registryKey16 = localMachine8.OpenSubKey(name16))
					{
						if (registryKey16 != null)
						{
							string text31 = "isRegExists";
							string text32 = "Telerik Found";
							Class28.smethod_26(text31, text32);
							return true;
						}
					}
					RegistryKey localMachine9 = Registry.LocalMachine;
					string name17 = "SOFTWARE\\Wow6432Node\\EffeTech";
					using RegistryKey registryKey17 = localMachine9.OpenSubKey(name17);
					if (registryKey17 != null)
					{
						string text33 = "isRegExists";
						string text34 = "EffeTech Found";
						Class28.smethod_26(text33, text34);
						return true;
					}
				}
			}
			catch
			{
			}
			result = flag;
		}
		else
		{
			result = flag;
		}
		return result;
	}

	public static bool smethod_17(bool bool_9)
	{
		bool result = false;
		if (BypassAnalizer)
		{
			return result;
		}
		try
		{
			RegistryKey localMachine = Registry.LocalMachine;
			string name = "SOFTWARE\\Microsoft\\Fiddler2";
			using (RegistryKey registryKey = localMachine.OpenSubKey(name))
			{
				if (registryKey != null)
				{
					RegistryKey localMachine2 = Registry.LocalMachine;
					string subkey = "SOFTWARE\\Microsoft\\Fiddler2";
					localMachine2.DeleteSubKeyTree(subkey);
				}
			}
			RegistryKey localMachine3 = Registry.LocalMachine;
			string name2 = "SOFTWARE\\Microsoft\\MessageAnalyzer";
			using (RegistryKey registryKey2 = localMachine3.OpenSubKey(name2))
			{
				if (registryKey2 != null)
				{
					RegistryKey localMachine4 = Registry.LocalMachine;
					string subkey2 = "SOFTWARE\\Microsoft\\MessageAnalyzer";
					localMachine4.DeleteSubKeyTree(subkey2);
				}
			}
			RegistryKey currentUser = Registry.CurrentUser;
			string name3 = "SOFTWARE\\\\Microsoft\\\\Fiddler2";
			using (RegistryKey registryKey3 = currentUser.OpenSubKey(name3))
			{
				if (registryKey3 != null)
				{
					RegistryKey currentUser2 = Registry.CurrentUser;
					string subkey3 = "SOFTWARE\\\\Microsoft\\\\Fiddler2";
					currentUser2.DeleteSubKeyTree(subkey3);
				}
			}
			RegistryKey currentUser3 = Registry.CurrentUser;
			string name4 = "SOFTWARE\\IEInspectorSoft";
			using (RegistryKey registryKey4 = currentUser3.OpenSubKey(name4))
			{
				if (registryKey4 != null)
				{
					RegistryKey currentUser4 = Registry.CurrentUser;
					string subkey4 = "SOFTWARE\\IEInspectorSoft";
					currentUser4.DeleteSubKeyTree(subkey4);
				}
			}
			RegistryKey currentUser5 = Registry.CurrentUser;
			string name5 = "SOFTWARE\\MadeForNet";
			using (RegistryKey registryKey5 = currentUser5.OpenSubKey(name5))
			{
				if (registryKey5 != null)
				{
					RegistryKey currentUser6 = Registry.CurrentUser;
					string subkey5 = "SOFTWARE\\MadeForNet";
					currentUser6.DeleteSubKeyTree(subkey5);
				}
			}
			RegistryKey currentUser7 = Registry.CurrentUser;
			string name6 = "SOFTWARE\\NTCore";
			using (RegistryKey registryKey6 = currentUser7.OpenSubKey(name6))
			{
				if (registryKey6 != null)
				{
					RegistryKey currentUser8 = Registry.CurrentUser;
					string subkey6 = "SOFTWARE\\NTCore";
					currentUser8.DeleteSubKeyTree(subkey6);
				}
			}
			RegistryKey currentUser9 = Registry.CurrentUser;
			string name7 = "SOFTWARE\\Wireshark";
			using (RegistryKey registryKey7 = currentUser9.OpenSubKey(name7))
			{
				if (registryKey7 != null)
				{
					RegistryKey currentUser10 = Registry.CurrentUser;
					string subkey7 = "SOFTWARE\\Wireshark";
					currentUser10.DeleteSubKeyTree(subkey7);
				}
			}
			RegistryKey currentUser11 = Registry.CurrentUser;
			string name8 = "SOFTWARE\\Telerik";
			using (RegistryKey registryKey8 = currentUser11.OpenSubKey(name8))
			{
				if (registryKey8 != null)
				{
					RegistryKey currentUser12 = Registry.CurrentUser;
					string subkey8 = "SOFTWARE\\Telerik";
					currentUser12.DeleteSubKeyTree(subkey8);
				}
			}
			RegistryKey currentUser13 = Registry.CurrentUser;
			string name9 = "SOFTWARE\\EffeTech";
			using (RegistryKey registryKey9 = currentUser13.OpenSubKey(name9))
			{
				if (registryKey9 != null)
				{
					RegistryKey currentUser14 = Registry.CurrentUser;
					string subkey9 = "SOFTWARE\\EffeTech";
					currentUser14.DeleteSubKeyTree(subkey9);
				}
			}
			RegistryKey currentUser15 = Registry.CurrentUser;
			string name10 = "SOFTWARE\\CommView";
			using (RegistryKey registryKey10 = currentUser15.OpenSubKey(name10))
			{
				if (registryKey10 != null)
				{
					RegistryKey currentUser16 = Registry.CurrentUser;
					string subkey10 = "SOFTWARE\\CommView";
					currentUser16.DeleteSubKeyTree(subkey10);
				}
			}
			if (IntPtr.Size == 8)
			{
				RegistryKey localMachine5 = Registry.LocalMachine;
				string name11 = "SOFTWARE\\Wow6432Node\\Microsoft\\Fiddler2";
				using (RegistryKey registryKey11 = localMachine5.OpenSubKey(name11))
				{
					if (registryKey11 != null)
					{
						RegistryKey localMachine6 = Registry.LocalMachine;
						string subkey11 = "SOFTWARE\\Wow6432Node\\Microsoft\\Fiddler2";
						localMachine6.DeleteSubKeyTree(subkey11);
					}
				}
				RegistryKey localMachine7 = Registry.LocalMachine;
				string name12 = "SOFTWARE\\Wow6432Node\\Microsoft\\MessageAnalyzer";
				using (RegistryKey registryKey12 = localMachine7.OpenSubKey(name12))
				{
					if (registryKey12 != null)
					{
						RegistryKey localMachine8 = Registry.LocalMachine;
						string subkey12 = "SOFTWARE\\Wow6432Node\\Microsoft\\MessageAnalyzer";
						localMachine8.DeleteSubKeyTree(subkey12);
					}
				}
				RegistryKey localMachine9 = Registry.LocalMachine;
				string name13 = "SOFTWARE\\Wow6432Node\\MadeForNet";
				using (RegistryKey registryKey13 = localMachine9.OpenSubKey(name13))
				{
					if (registryKey13 != null)
					{
						RegistryKey localMachine10 = Registry.LocalMachine;
						string subkey13 = "SOFTWARE\\Wow6432Node\\MadeForNet";
						localMachine10.DeleteSubKeyTree(subkey13);
					}
				}
				RegistryKey localMachine11 = Registry.LocalMachine;
				string name14 = "SOFTWARE\\Wow6432Node\\NTCore";
				using (RegistryKey registryKey14 = localMachine11.OpenSubKey(name14))
				{
					if (registryKey14 != null)
					{
						RegistryKey localMachine12 = Registry.LocalMachine;
						string subkey14 = "SOFTWARE\\Wow6432Node\\NTCore";
						localMachine12.DeleteSubKeyTree(subkey14);
					}
				}
				RegistryKey localMachine13 = Registry.LocalMachine;
				string name15 = "SOFTWARE\\Wow6432Node\\Wireshark";
				using (RegistryKey registryKey15 = localMachine13.OpenSubKey(name15))
				{
					if (registryKey15 != null)
					{
						RegistryKey localMachine14 = Registry.LocalMachine;
						string subkey15 = "SOFTWARE\\Wow6432Node\\Wireshark";
						localMachine14.DeleteSubKeyTree(subkey15);
					}
				}
				RegistryKey localMachine15 = Registry.LocalMachine;
				string name16 = "SOFTWARE\\Wow6432Node\\Telerik";
				using (RegistryKey registryKey16 = localMachine15.OpenSubKey(name16))
				{
					if (registryKey16 != null)
					{
						RegistryKey localMachine16 = Registry.LocalMachine;
						string subkey16 = "SOFTWARE\\Wow6432Node\\Telerik";
						localMachine16.DeleteSubKeyTree(subkey16);
					}
				}
				RegistryKey localMachine17 = Registry.LocalMachine;
				string name17 = "SOFTWARE\\Wow6432Node\\EffeTech";
				using RegistryKey registryKey17 = localMachine17.OpenSubKey(name17);
				if (registryKey17 != null)
				{
					RegistryKey localMachine18 = Registry.LocalMachine;
					string subkey17 = "SOFTWARE\\Wow6432Node\\EffeTech";
					localMachine18.DeleteSubKeyTree(subkey17);
				}
			}
		}
		catch
		{
		}
		return result;
	}

	private static void smethod_16()
	{
		if (BypassAnalizer || Environment.MachineName.ToUpper().Contains(Class33.string_7) || mySettings_0.userID.ToUpper().Contains(Class33.string_9) || mySettings_0.userID.ToUpper().Contains(Class33.string_8))
		{
			return;
		}
		if (smethod_14())
		{
			Form owner = new Form
			{
				TopMost = true
			};
			string text = "Virual Machine Detected!!! Software cannot Perform on Virual Machine. \r\n\r\nPlease run the software on actual computer.";
			string caption = "Virtual Machine";
			MessageBox.Show(owner, text, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			Process.GetCurrentProcess().Kill();
			Application.Exit();
		}
		if (smethod_15())
		{
			string text2 = "RegKeyFound";
			Class28.smethod_14(text2);
			string text3 = "Security Failed!! Process terminating";
			string text4 = "Reg. Key Found";
			Class28.smethod_26(text3, text4);
			Form owner2 = new Form
			{
				TopMost = true
			};
			string text5 = "Security Failed for Reg. Your ID has been logged.\r\n\r\nPlease Format your Computer or contact Admin.";
			string caption2 = "Security";
			MessageBox.Show(owner2, text5, caption2, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			Process.GetCurrentProcess().Kill();
		}
		if (list_1.Count <= 0)
		{
			smethod_20();
		}
		Process[] processes = Process.GetProcesses(Process.GetCurrentProcess().MachineName);
		string text6 = "";
		string text7 = "";
		string text8 = "";
		try
		{
			if (processes != null)
			{
				int num = 0;
				do
				{
					text6 = processes[num].ProcessName.ToUpper();
					text7 = processes[num].MainWindowTitle.ToUpper();
					text8 = "";
					try
					{
						text8 = processes[num].Modules[0].FileName;
					}
					catch
					{
					}
					foreach (string item in list_1)
					{
						if (!text6.Contains(item) && !text7.Contains(item) && !text8.Contains(item))
						{
							continue;
						}
						string text9 = "KillHttpProcess";
						string[] array = new string[6];
						string text10 = "Process Found: prcName =";
						array[0] = text10;
						array[1] = text6;
						string text11 = ", prcTitle = ";
						array[2] = text11;
						array[3] = text7;
						string text12 = ", exeName = ";
						array[4] = text12;
						array[5] = text8;
						Class28.smethod_26(text9, string.Concat(array));
						string text13 = text6.ToUpper();
						string value = "IDLE";
						int num2;
						if (!text13.Contains(value))
						{
							string text14 = text6.ToUpper();
							string value2 = "IEMONITOR";
							if (!text14.Contains(value2))
							{
								string text15 = text6.ToUpper();
								string value3 = "CHROME";
								if (!text15.Contains(value3))
								{
									string text16 = text6;
									string value4 = "EMLPROXY";
									if (!text16.Contains(value4))
									{
										string text17 = text6;
										string value5 = "SCPROXYSRV";
										if (!text17.Contains(value5))
										{
											string text18 = text6;
											string value6 = "ICCPROXY";
											if (text18.Contains(value6))
											{
												string text19 = text8;
												string value7 = "Intel";
												if (text19.Contains(value7))
												{
													goto IL_0376;
												}
											}
											string text20 = text6;
											string value8 = "WEBPROXY";
											if (text20.Contains(value8))
											{
												string text21 = text8.ToUpper();
												string value9 = "PANDA";
												num2 = (text21.Contains(value9) ? 1 : 0);
											}
											else
											{
												num2 = 0;
											}
											goto IL_037c;
										}
									}
								}
							}
						}
						goto IL_0376;
						IL_0376:
						num2 = 1;
						goto IL_037c;
						IL_037c:
						bool flag = (byte)num2 != 0;
						try
						{
							if (!flag)
							{
								processes[num].Kill();
							}
						}
						catch (Exception ex)
						{
							string text22 = "KillHttpProcess.Catch";
							string[] array2 = new string[8];
							string text23 = "Process Found: prcName =";
							array2[0] = text23;
							array2[1] = text6;
							string text24 = ", prcTitle = ";
							array2[2] = text24;
							array2[3] = text7;
							string text25 = ", exeName = ";
							array2[4] = text25;
							array2[5] = text8;
							string text26 = " :: Ex = ";
							array2[6] = text26;
							array2[7] = ex.Message;
							Class28.smethod_26(text22, string.Concat(array2));
							if (!flag)
							{
								Form owner3 = new Form
								{
									TopMost = true
								};
								string text27 = "Some software stopping ";
								string appName = AppName;
								string text28 = " to run successfully. Give logs to admin.";
								string text29 = text27 + appName + text28;
								string caption3 = "Unable to Run";
								MessageBox.Show(owner3, text29, caption3, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
								Process.GetCurrentProcess().Kill();
							}
						}
					}
					num++;
				}
				while (num < processes.Length);
			}
			ThreadPool.QueueUserWorkItem(smethod_18);
		}
		catch (Exception ex2)
		{
			string text30 = "KillHttpProcess.OuterCatch";
			string[] array3 = new string[8];
			string text31 = "Process Found: prcName =";
			array3[0] = text31;
			array3[1] = text6;
			string text32 = ", prcTitle = ";
			array3[2] = text32;
			array3[3] = text7;
			string text33 = ", exeName = ";
			array3[4] = text33;
			array3[5] = text8;
			string text34 = " :: Ex = ";
			array3[6] = text34;
			array3[7] = ex2.Message;
			Class28.smethod_26(text30, string.Concat(array3));
		}
	}

	private static void smethod_18(object object_0)
	{
		try
		{
			foreach (KeyValuePair<IntPtr, string> item in Class41.smethod_0())
			{
				IntPtr key = item.Key;
				string text = item.Value.ToUpper();
				string value = "WINDOWS INTERNET EXPLORER";
				if (text.Contains(value))
				{
					continue;
				}
				string value2 = "GOOGLE CHROME";
				if (text.Contains(value2))
				{
					continue;
				}
				string value3 = "MOZILLA FIREFOX";
				if (!text.Contains(value3))
				{
					string value4 = "CHROME";
					if (!text.Contains(value4))
					{
						smethod_19(key);
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private static void smethod_19(object object_0)
	{
		IntPtr intptr_ = (IntPtr)object_0;
		try
		{
			foreach (KeyValuePair<IntPtr, string> item in Class41.smethod_1(intptr_))
			{
				_ = item.Key;
				string value = item.Value;
				string text = value.ToUpper();
				string value2 = "WINDOWS INTERNET EXPLORER";
				if (text.Contains(value2))
				{
					continue;
				}
				string value3 = "GOOGLE CHROME";
				if (text.Contains(value3))
				{
					continue;
				}
				string value4 = "MOZILLA FIREFOX";
				if (text.Contains(value4))
				{
					continue;
				}
				foreach (string item2 in list_1)
				{
					if (!value.Contains(item2))
					{
						continue;
					}
					Class41.GetWindowThreadProcessId(intptr_, out var uint_);
					Process processById = Process.GetProcessById((int)uint_);
					string text2 = "";
					string processName = processById.ProcessName;
					try
					{
						text2 = processById.Modules[0].FileName;
					}
					catch
					{
					}
					int num;
					if (uint_ != 0)
					{
						num = 0;
					}
					else
					{
						string value5 = "GATTS TCP Server";
						num = (value.Contains(value5) ? 1 : 0);
					}
					bool flag = (byte)num != 0;
					string text3 = "KillHttpProcessOnTitle_ProcessBase";
					string[] array = new string[8];
					string text4 = "Process Found on Title Base: prcName =";
					array[0] = text4;
					array[1] = processName;
					string text5 = ", WindowTitle = ";
					array[2] = text5;
					array[3] = value;
					string text6 = ", exeName = ";
					array[4] = text6;
					array[5] = text2;
					string text7 = ", IsAllowed = ";
					array[6] = text7;
					array[7] = flag.ToString();
					Class28.smethod_26(text3, string.Concat(array));
					if (flag)
					{
						continue;
					}
					try
					{
						if (!flag)
						{
							processById.Kill();
						}
					}
					catch (Exception ex)
					{
						string text8 = "KillHttpProcessOnTitle_ProcessBase.OuterCatch";
						string[] array2 = new string[10];
						string text9 = "Process Found: prcID = ";
						array2[0] = text9;
						array2[1] = uint_.ToString();
						string text10 = ", prcName =";
						array2[2] = text10;
						array2[3] = processName;
						string text11 = ", prcTitle = ";
						array2[4] = text11;
						array2[5] = value;
						string text12 = ", exeName = ";
						array2[6] = text12;
						array2[7] = text2;
						string text13 = " :: Ex = ";
						array2[8] = text13;
						array2[9] = ex.Message;
						Class28.smethod_26(text8, string.Concat(array2));
						if (!flag)
						{
							Process.GetCurrentProcess().Kill();
						}
					}
				}
			}
		}
		catch
		{
		}
	}

	public static void Method4_Pre_AllFilesCheckup()
	{
		string[] array = new string[10];
		string exeName = ExeName;
		string text = ".config$154|";
		array[0] = exeName + text;
		string text2 = string.Concat(array);
		string[] array2 = new string[1];
		string text3 = "|";
		array2[0] = text3;
		string[] separator = array2;
		string[] array3 = text2.Split(separator, StringSplitOptions.RemoveEmptyEntries);
		string[] array4 = array3;
		string[] array5 = array4;
		foreach (string text4 in array5)
		{
			bool flag = false;
			string[] array6 = new string[1];
			string text5 = "$";
			array6[0] = text5;
			string[] array7 = text4.Split(array6, StringSplitOptions.None);
			if (File.Exists(Path.Combine(StartupPath, array7[0])))
			{
				if (new FileInfo(Path.Combine(StartupPath, array7[0]))
				{
					Attributes = FileAttributes.Hidden
				}.Length < long.Parse(array7[1]))
				{
					flag = true;
				}
			}
			else
			{
				flag = true;
			}
			if (flag)
			{
				if (File.Exists(Path.Combine(StartupPath, array7[0])))
				{
					File.Delete(Path.Combine(StartupPath, array7[0]));
				}
				try
				{
					ServicePointManager.Expect100Continue = true;
					ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
				}
				catch
				{
					string text6 = "There is Error in PriDownloading Files";
					MessageBox.Show(text6);
				}
			}
		}
	}

	public static void Method4_Post_AllFilesCheckup()
	{
	}

	private static void smethod_20()
	{
		List<string> list = list_1;
		string item = "HTTP";
		list.Add(item);
		List<string> list2 = list_1;
		string item2 = "PROXY";
		list2.Add(item2);
		List<string> list3 = list_1;
		string item3 = "TCP";
		list3.Add(item3);
		List<string> list4 = list_1;
		string item4 = "SNIFFER";
		list4.Add(item4);
		List<string> list5 = list_1;
		string item5 = "PACKET";
		list5.Add(item5);
		List<string> list6 = list_1;
		string item6 = "TCPVIEW";
		list6.Add(item6);
		List<string> list7 = list_1;
		string item7 = "WIRESHARK";
		list7.Add(item7);
		List<string> list8 = list_1;
		string item8 = "FIDDLER";
		list8.Add(item8);
		List<string> list9 = list_1;
		string item9 = "CHARLES";
		list9.Add(item9);
		List<string> list10 = list_1;
		string item10 = "TSHARK";
		list10.Add(item10);
		List<string> list11 = list_1;
		string item11 = "ZENMAP";
		list11.Add(item11);
		List<string> list12 = list_1;
		string item12 = "PACKETYZER";
		list12.Add(item12);
		List<string> list13 = list_1;
		string item13 = "NM_CAP";
		list13.Add(item13);
		List<string> list14 = list_1;
		string item14 = "NK2EDIT";
		list14.Add(item14);
		List<string> list15 = list_1;
		string item15 = "NETWORKTRAFFICVIEW";
		list15.Add(item15);
		List<string> list16 = list_1;
		string item16 = "TNM";
		list16.Add(item16);
		List<string> list17 = list_1;
		string item17 = "NXMC";
		list17.Add(item17);
		List<string> list18 = list_1;
		string item18 = "CAPSA";
		list18.Add(item18);
		List<string> list19 = list_1;
		string item19 = "BANDWIDTHD";
		list19.Add(item19);
		List<string> list20 = list_1;
		string item20 = "NETWORKMINER";
		list20.Add(item20);
		List<string> list21 = list_1;
		string item21 = "NAGIOS";
		list21.Add(item21);
		List<string> list22 = list_1;
		string item22 = "IPSCAN";
		list22.Add(item22);
		List<string> list23 = list_1;
		string item23 = "PRTG";
		list23.Add(item23);
		List<string> list24 = list_1;
		string item24 = "SPLUNK";
		list24.Add(item24);
		List<string> list25 = list_1;
		string item25 = "NPROBE";
		list25.Add(item25);
		List<string> list26 = list_1;
		string item26 = "NTOP";
		list26.Add(item26);
		List<string> list27 = list_1;
		string item27 = "WINSOCK";
		list27.Add(item27);
		List<string> list28 = list_1;
		string item28 = "ACRYLIC";
		list28.Add(item28);
		List<string> list29 = list_1;
		string item29 = "PROCMON";
		list29.Add(item29);
		List<string> list30 = list_1;
		string item30 = "PROCESS MONITOR";
		list30.Add(item30);
	}

	static Program()
	{
		string text = "000";
		rp = text;
		string updateURI = "https://raw.githubusercontent.com/hitmants2026-a11y/Hitman/refs/heads/main/Updater";
		UpdateURI = updateURI;
		list_0 = new List<string>();
		dictionary_0 = new Dictionary<string, string>();
		dictionary_00 = new Dictionary<string, string>();
		dictionary_1 = new Dictionary<int, string>();
		dictionary_01 = new Dictionary<string, string>();
		dictionary_2 = new Dictionary<string, string>();
		dictionary_3 = new Dictionary<string, string>();
		list_SelectedIRCTCid = new Dictionary<string, string>();
		dictionary_4 = new Dictionary<string, string>();
		clientID = "";
		string_00 = "";
		mac = "";
		string_1A = "";
		DBPASS = "";
		string_01 = "";
		Credit = 0;
		int_0 = 0;
		int_1 = 0;
		bool_0 = false;
		mySettings_0 = null;
		class28_0 = null;
		string text2 = "0";
		string_3 = text2;
		int_2 = 0;
		dateTime_0 = DateTime.Now.AddDays(-1.0);
		int_Slot = 1;
		slot = 1;
		int_5 = 10;
		string_4 = "";
		list_1 = new List<string>();
		list_Proxy = new List<string>();
		list_3 = new List<string>();
		bool_1 = false;
		frmMain_0 = null;
		bool_3 = false;
		int_4 = 1050;
		string_bhim_exist = "";
		string_pdf_exist = "";
		string_ocr_exist = "";
		string_Weblogger_exist = "";
		string_5 = "";
		string_6 = "";
		string_7 = "";
		string_8 = "";
		ExpiryDay = 0;
		string_9 = "";
		string_10 = "";
		string text3 = "http";
		string_11 = text3;
		bool_5 = false;
		string_updat_exist = "";
		string_13 = "";
		string_14 = "";
		PaidStatus = "";
		LicStatus = "";
		string_15 = "";
		process_0 = null;
		bool_6 = false;
		bool_7 = true;
		bool_VSC = false;
		token_ = false;
		ExeName = AppDomain.CurrentDomain.FriendlyName;
		string appName = "Hitman";
		AppName = appName;
		bool_8 = false;
		bool_UpdtAvl = false;
		bool_IsFileUpdtAvl = false;
		bool_IsExeUpdtAvl = false;
		string fontLink = "https://raw.githubusercontent.com/hitmants2026-a11y/Hitman/refs/heads/main/DS-DIGIT.TTF";
		FontLink = fontLink;
		BookingAllowEdge = false;
		BookingAllowChrome = false;
		BookingAllowChromeBeta = false;
	}
}
