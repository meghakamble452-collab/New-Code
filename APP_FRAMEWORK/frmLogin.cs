using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Security;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Booking;
using Bunifu.Framework.UI;
using BunifuAnimatorNS;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using NEXUS.Booking;

namespace APP_FRAMEWORK;

public class frmLogin : Form
{
	public static bool isPremium;

	public static string appversion;

	private int int_0;

	public string ErMsg;

	public bool bool_1;

	public bool bunifuButton1_Clik;

	public static string ENCkey;

	public static DateTime openDate;

	public static bool ShowMSG;

	public static string key;

	private IContainer C0AA0;

	private BunifuTransition bunifuTransition_0;

	private ToolTip toolTip_0;

	private BunifuImageButton B2AAA;

	internal CheckBox checkBox1;

	private BunifuFlatButton bunifuFlatButton1;

	internal CheckBox chkRemember;

	private System.Windows.Forms.Timer timer_0;

	private Panel panel2;

	private BunifuFlatButton bunifuFlatButton2;

	private Label label4;

	private PictureBox pictureBox2;

	private IContainer components;

	internal TextBox txtLogin;

	private BunifuElipse bunifuElipse1;

	private Label B1AAA;

	private Button C2AA0;

	private Panel pnlFooter;

	private CheckBox chkLoginScreenShow;

	private BunifuFlatButton bunifuButton1;

	private Label label5;

	private Label label6;

	private BunifuSwitch bunifuToggleAppModeSwitch;

	private BunifuProgressBar bunifuProgressBar1;

	private BunifuSeparator bunifuSeparator2;

	private BunifuProgressBar bunifuProgressBar2;

	private TextBox InfoList2;

	private BunifuImageButton C1AA0;

	private BunifuSwitch bunifuToggleAutoLoginSwitch;

	private Label label3;

	private Label label2;

	public BunifuSwitch bunifuToggleRememberSwitch;

	private BunifuFlatButton btnLogin;

	private BunifuTextbox txtPassword;

	public BunifuTextbox txtUserName;

	private BunifuSeparator bunifuSeparator1;

	internal TextBox encP;

	private Label label7;

	private Label label1;

	private Panel panel1;

	private Label label50;

	private BunifuImageButton btnClose;

	private PictureBox pictureBox1;

	private Label label8;

	internal WebProxy Proxy_BACKUP;

	internal WebProxy Proxy_;

	[DllImport("kernel32.dll")]
	public static extern void ExitProcess(uint A_0);

	public static bool smethod_1(object A_0, X509Certificate A_1, X509Chain A_2, SslPolicyErrors A_3)
	{
		return true;
	}

	public frmLogin()
	{
		InitializeComponent();
		panel1.MouseDown += StatClass.Header_MouseDown;
		panel1.MouseMove += StatClass.Header_MouseMove;
		panel1.MouseUp += StatClass.Header_MouseUp;
		pnlFooter.Visible = false;
		mySettings.bool_1 = Program.mySettings_0.isRememberPassword;
		mySettings.bool_2 = Program.mySettings_0.isAutoLogin;
		mySettings.bool_3 = Program.mySettings_0.NonManagerDashborad;
	}

	public void Func_LoginChk(object sender)
	{
		StatClass.TotalOpendWindow = Process.GetProcessesByName(Program.AppName).Length;
		openDate = DateTime.Now;
		Program.list_3.Clear();
		Program.int_Slot = 2;
		bool_1 = ValidateUser();
		if (Program.list_3.Count > 0)
		{
			Program.int_Slot += Program.list_3.Count * 2;
		}
		if (Class34.dictionary_0 == null)
		{
			Class34.dictionary_0 = new Dictionary<int, string>();
		}
		if (!bool_1)
		{
			btnLogin.Enabled = true;
			Application.Exit();
			Environment.Exit(0);
		}
		else
		{
			Program.Method4_Post_AllFilesCheckup();
			base.DialogResult = DialogResult.OK;
		}
	}

	private void method_0(object object_0, int int_1)
	{
		try
		{
			if (int_1 == 0)
			{
				Invoke((Action)delegate
				{
					TextBox infoList = InfoList2;
					string text = infoList.Text;
					infoList.Text = text + object_0?.ToString() + Environment.NewLine;
				});
				return;
			}
			label5.Invoke((Action)delegate
			{
				Label label = label5;
				string text2 = "(Application Closes Automatically in ";
				string text3 = text2;
				string text4 = object_0?.ToString();
				string text5 = " Seconds)";
				label.Text = text3 + text4 + text5;
			});
		}
		catch
		{
		}
	}

	private string method_1(string string_0, string string_1, string string_2)
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

	public static bool CertificateValidation(object object_18, X509Certificate x509Certificate_0, X509Chain x509Chain_0, SslPolicyErrors sslPolicyErrors_0)
	{
		bool result = false;
		if (Program.BypassAnalizer)
		{
			return true;
		}
		try
		{
			string text = x509Certificate_0.Issuer.ToLower();
			string value = "httpanalyze";
			if (text.Contains(value))
			{
				goto IL_012b;
			}
			string text2 = x509Certificate_0.Issuer.ToLower();
			string value2 = "fiddler";
			if (text2.Contains(value2))
			{
				goto IL_012b;
			}
			string text3 = x509Certificate_0.Issuer.ToLower();
			string value3 = "commview";
			if (text3.Contains(value3))
			{
				goto IL_012b;
			}
			string text4 = x509Certificate_0.Issuer.ToLower();
			string value4 = "debugger";
			if (text4.Contains(value4))
			{
				goto IL_012b;
			}
			string text5 = x509Certificate_0.Issuer.ToLower();
			string value5 = "debug";
			if (text5.Contains(value5))
			{
				goto IL_012b;
			}
			string text6 = x509Certificate_0.Issuer.ToLower();
			string value6 = "sniffer";
			if (text6.Contains(value6))
			{
				goto IL_012b;
			}
			string text7 = x509Certificate_0.Issuer.ToUpper();
			string value7 = "IEINSPECTOR";
			if (text7.Contains(value7))
			{
				goto IL_012b;
			}
			result = true;
			goto end_IL_0015;
			IL_012b:
			Environment.Exit(0);
			Application.Exit();
			end_IL_0015:;
		}
		catch (Exception)
		{
			result = true;
		}
		return result;
	}

	private void DeleteCogif()
	{
		string fileName = Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);
		FileInfo[] files = new DirectoryInfo(Application.StartupPath).GetFiles();
		FileInfo[] array = files;
		FileInfo[] array2 = array;
		foreach (FileInfo fileInfo in array2)
		{
			if (!(fileInfo.Name != fileName))
			{
				continue;
			}
			string name = fileInfo.Name;
			string value = "exe.config";
			if (name.Contains(value))
			{
				string text = File.ReadAllText(fileInfo.Name);
				string value2 = "For more information on Entitty Framework configuration";
				if (text.Contains(value2) && !fileInfo.Name.Contains(fileName))
				{
					File.Delete(fileInfo.Name);
				}
			}
		}
	}

	public static string Encrypt(string plainText)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(plainText);
		string password = "B@@Sw1rt";
		Encoding aSCII = Encoding.ASCII;
		string s = "B@LT&KFY";
		byte[] bytes2 = new Rfc2898DeriveBytes(password, aSCII.GetBytes(s)).GetBytes(32);
		RijndaelManaged rijndaelManaged = new RijndaelManaged
		{
			Mode = CipherMode.CBC,
			Padding = PaddingMode.Zeros
		};
		Encoding aSCII2 = Encoding.ASCII;
		string s2 = "@1B2c3D4e5T6g7K8";
		ICryptoTransform transform = rijndaelManaged.CreateEncryptor(bytes2, aSCII2.GetBytes(s2));
		byte[] inArray;
		using (MemoryStream memoryStream = new MemoryStream())
		{
			using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
			{
				cryptoStream.Write(bytes, 0, bytes.Length);
				cryptoStream.FlushFinalBlock();
				inArray = memoryStream.ToArray();
				cryptoStream.Close();
			}
			memoryStream.Close();
		}
		return Convert.ToBase64String(inArray);
	}

	private string getLink()
	{
		string text = "";
		string text2 = "https://raw.githubusercontent.com/hitmants2026-a11y/Hitman/refs/heads/main/HTMNEWENG";
		string requestUriString = text2;
		int num = 0;
		while (true)
		{
			try
			{
				string text3 = "";
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
				httpWebRequest.ServerCertificateValidationCallback = CertificateValidation;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				string method = "GET";
				httpWebRequest.Method = method;
				httpWebRequest.Timeout = 65000;
				httpWebRequest.ReadWriteTimeout = 65000;
				using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
				text3 = streamReader.ReadToEnd();
				if (string.IsNullOrEmpty(text3))
				{
					text3 = "https://hitmanxxx.com/Hitman/StartApi|--|https://raw.githubusercontent.com/hitmants2026-a11y/Hitman/refs/heads/main/NewIRCOMM.txt|--|https://raw.githubusercontent.com/hitmants2026-a11y/Hitman/refs/heads/main/main/Updater|--|https://raw.githubusercontent.com/hitmants2026-a11y/Hitman/refs/heads/main/QRCoder.zip|--|https://raw.githubusercontent.com/hitmants2026-a11y/Hitman/refs/heads/main/DS-DIGIT.TTF|--|https://raw.githubusercontent.com/hitmants2026-a11y/Hitman/refs/heads/main/Hitman.jpg|--|https://raw.githubusercontent.com/hitmants2026-a11y/Hitman/refs/heads/main/Windows.jpg|--|https://hitmanxxx.com/Hitman/success.php|--|http://nget.in:8080/api/Password|--|https://raw.githubusercontent.com/hitmants2026-a11y/Hitman/refs/heads/main/HitmanTesseract.zip|--|https://raw.githubusercontent.com/hitmants2026-a11y/Hitman/refs/heads/main/dtsProxt|--|BB#7U9$SQ88|--|KKKKKKK|--|OFF\r\n";
				}
				string text4 = text3;
				string[] array = new string[1];
				string text5 = "|--|";
				array[0] = text5;
				string[] array2 = text4.Split(array, StringSplitOptions.None);
				text = array2[0];
				Program.IrcommURI = array2[1];
				Program.UpdateURI = array2[2];
				Program.PDFURL = array2[3];
				Program.FontLink = array2[4];
				Program.Nexusjpg = array2[5];
				Program.Windowsjpg = array2[6];
				Program.ResultURL = array2[7];
				Program.BackUpRestoreURL = array2[8];
				Program.OcrUrl = array2[9];
				Program.ProxyUrl = array2[10];
				string variable = "PhonePeHost";
				string value = "http://54.237.63.250";
				Environment.SetEnvironmentVariable(variable, value);
				string variable2 = "EncyptionKey";
				Environment.SetEnvironmentVariable(variable2, array2[11]);
				return text;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				Application.DoEvents();
				Thread.Sleep(500);
				if (num == 0)
				{
					string text6 = "https://hitmanxxx.com/Link.txt";
					requestUriString = text6;
				}
				if (num == 1)
				{
					string text7 = "https://raw.githubusercontent.com/hitmants2026-a11y/Hitman/refs/heads/main/Link.txt";
					requestUriString = text7;
				}
				num++;
			}
		}
	}

	private bool ValidateUser()
	{
		string link = getLink();
		string[] array = new string[5];
		string text = "{\"userName\":\"";
		array[0] = text;
		array[1] = Program.clientID;
		string text2 = "\",\"macAddress\":\"";
		array[2] = text2;
		array[3] = Program.mac;
		string text3 = "\",\"MSG\":\"true\"}";
		array[4] = text3;
		string text4 = string.Concat(array);
		string text5 = null;
		string variable = "clientID";
		Environment.SetEnvironmentVariable(variable, Program.clientID, EnvironmentVariableTarget.Process);
		string variable2 = "mac";
		Environment.SetEnvironmentVariable(variable2, Program.mac, EnvironmentVariableTarget.Process);
		string variable3 = "auth_url";
		Environment.SetEnvironmentVariable(variable3, link, EnvironmentVariableTarget.Process);
		string variable4 = "ProxyUrl";
		Environment.SetEnvironmentVariable(variable4, Program.ProxyUrl, EnvironmentVariableTarget.Process);
		bool result = false;
		if (!NetworkInterface.GetIsNetworkAvailable())
		{
			Form owner = Program.smethod_7();
			string text6 = "Internet Not Connected! Please Connect Internet";
			string caption = "Restart Application";
			MessageBox.Show(owner, text6, caption, MessageBoxButtons.OK);
			Environment.Exit(0);
		}
		string object_ = "Connecting To Server.......";
		method_0(object_, 0);
		string[] array2 = new string[1];
		string text7 = ":";
		array2[0] = text7;
		string text8 = "gw.dataimpulse.com:823:657c7798ee9a5416cd54__cr.in:3649f6c96375bd81";
		string[] array3 = text8.Split(array2, StringSplitOptions.None);
		if (array3.Length > 3)
		{
			Proxy_BACKUP = new WebProxy(array3[0].Trim(), int.Parse(array3[1].Trim()));
			Proxy_BACKUP.BypassProxyOnLocal = true;
			Proxy_BACKUP.Credentials = new NetworkCredential(array3[2].Trim(), array3[3].Trim());
		}
		int num = 0;
		while (true)
		{
			try
			{
				num++;
				DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
				string text9 = ((long)(DateTime.UtcNow - dateTime).TotalMilliseconds).ToString();
				string text10 = ":";
				string s = text9 + text10 + Program.clientID;
				s = Convert.ToBase64String(Encoding.UTF8.GetBytes(s));
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(link);
				httpWebRequest.ServerCertificateValidationCallback = CertificateValidation;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
				string contentType = "application/json";
				httpWebRequest.Proxy = Proxy_;
				httpWebRequest.ContentType = contentType;
				WebHeaderCollection headers = httpWebRequest.Headers;
				string name = "Authorization";
				string text11 = "Basic ";
				headers.Add(name, text11 + s);
				string method = "POST";
				httpWebRequest.Method = method;
				httpWebRequest.Timeout = 10000;
				httpWebRequest.ReadWriteTimeout = 10000;
				using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
				{
					string value = text4;
					streamWriter.Write(value);
				}
				using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
				if ((text5 = streamReader.ReadToEnd()).Length < 3)
				{
					Form owner2 = Program.smethod_7();
					string text12 = "Internet Not Connected! Please Connect Internet";
					string caption2 = "Restart Application";
					MessageBox.Show(owner2, text12, caption2, MessageBoxButtons.OK);
					Environment.Exit(0);
				}
				string string_ = "Program.Main";
				string string_2 = "APi Seccess";
				Class28.smethod_26(string_, string_2);
			}
			catch (WebException)
			{
				if (num > 2)
				{
					text5 = user_RegistryRead();
				}
				Proxy_ = Proxy_BACKUP;
				continue;
			}
			catch (Exception)
			{
				if (num > 2)
				{
					text5 = user_RegistryRead();
				}
				Proxy_ = Proxy_BACKUP;
				continue;
			}
			while (true)
			{
				if (!string.IsNullOrEmpty(text5))
				{
					try
					{
						Program.ValidateResponse = text5;
						string text13 = text5;
						string text14 = text5;
						string value2 = "success\":false";
						if (text14.Contains(value2))
						{
							string string_3 = text5;
							string string_4 = "message\"";
							string string_5 = "\"";
							string text15 = method_1(string_3, string_4, string_5);
							Form owner3 = Program.TopMost_();
							string caption3 = "DeActivate";
							MessageBox.Show(owner3, text15, caption3, MessageBoxButtons.OK, MessageBoxIcon.Hand);
							Environment.Exit(0);
						}
						string text16 = text5;
						string value3 = "success\":true";
						if (text16.Contains(value3))
						{
							string string_6 = text5;
							string string_7 = "success";
							string string_8 = ",";
							bool flag = Convert.ToBoolean(method_1(string_6, string_7, string_8));
							string string_9 = text5;
							string string_10 = "message\"";
							string string_11 = "\"";
							string text17 = method_1(string_9, string_10, string_11);
							string string_12 = text5;
							string string_13 = "leftDays";
							string string_14 = ",";
							string s2 = method_1(string_12, string_13, string_14);
							string string_15 = text5;
							string string_16 = "ipList\"";
							string string_17 = "\"";
							string text18 = method_1(string_15, string_16, string_17);
							if (text18.Length < 10)
							{
								text18 = string.Empty;
							}
							string string_18 = text5;
							string string_19 = "appVersion\"";
							string string_20 = "\"";
							Program.NewVersion = method_1(string_18, string_19, string_20);
							string string_21 = text5;
							string string_22 = "cleansystem\"";
							string string_23 = "\"";
							Program.cleansys = method_1(string_21, string_22, string_23);
							string string_24 = text5;
							string string_25 = "ShortMessage\"";
							string string_26 = "\"";
							string text19 = method_1(string_24, string_25, string_26);
							string string_27 = text5;
							string string_28 = "KeyType\"";
							string string_29 = "\"";
							Program.KeyType = method_1(string_27, string_28, string_29);
							string string_30 = text5;
							string string_31 = "paid\"";
							string string_32 = "\"";
							string text20 = method_1(string_30, string_31, string_32);
							string string_33 = text5;
							string string_34 = "loginallow\"";
							string string_35 = "\"";
							StatClass.stopipblock = method_1(string_33, string_34, string_35);
							string string_36 = text5;
							string string_37 = "edata\"";
							string string_38 = "\"";
							Staticm.edata = method_1(string_36, string_37, string_38);
							string string_39 = text5;
							string string_40 = "S3URL\"";
							string string_41 = "\"";
							Program.DownloadUri = method_1(string_39, string_40, string_41);
							string string_42 = text5;
							string string_43 = "pass\"";
							string string_44 = "\"";
							Program.DBPASS = method_1(string_42, string_43, string_44);
							string string_45 = text5;
							string string_46 = "availtime\"";
							string string_47 = "\"";
							Program.availtime = method_1(string_45, string_46, string_47);
							string string_48 = text5;
							string string_49 = "webtext\"";
							string string_50 = "\"";
							Program.WEBTEXT = method_1(string_48, string_49, string_50);
							string string_51 = text5;
							string string_52 = "sdata\"";
							string string_53 = "\"";
							method_1(string_51, string_52, string_53);
							string string_54 = text5;
							string string_55 = "BatchNo\"";
							string string_56 = "\"";
							Program.batchNumber = method_1(string_54, string_55, string_56);
							string value4 = "@";
							if (text19.Contains(value4))
							{
								ShowMSG = true;
								string oldValue = "@";
								alert.m1 = text19.Replace(oldValue, Environment.NewLine);
							}
							string keyType = Program.KeyType;
							string text21 = "demo";
							if (keyType == text21)
							{
								alert.demo = true;
								Form owner4 = Program.TopMost_();
								string text22 = "Demo ID per 1 Time Pe Sirf 1 Hi Ticket Process Hoga\r\n2nd Ticket Book Karne ke Liye Software Restart Karna Padega";
								string caption4 = "Demo Version";
								MessageBox.Show(owner4, text22, caption4, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							}
							string newVersion = Program.NewVersion;
							string value5 = "||";
							if (newVersion.Contains(value5))
							{
								string newVersion2 = Program.NewVersion;
								string[] array4 = new string[1];
								string text23 = "||";
								array4[0] = text23;
								Program.NewVersion = newVersion2.Split(array4, StringSplitOptions.None)[0];
							}
							string keyType2 = Program.KeyType;
							string text24 = "monthly";
							if (keyType2 == text24)
							{
								bool flag2 = int.Parse(s2) < 29;
								string text25 = "Paid";
								if (flag2 & (text20 != text25))
								{
									Form owner5 = Program.TopMost_();
									string text26 = "ID Deactivated\nID Un-Paid hone ki Wajeh se De-Activate ho gai hai\nAgar Aapka Payment Clear hai to Seller se Bolke Paid Karayen";
									string caption5 = "UNPAID KEY";
									MessageBox.Show(owner5, text26, caption5, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
									Environment.Exit(0);
									Application.Exit();
								}
								string text27 = "  Status : ";
								Program.KeyStatus = text27 + text20;
								string text28 = "Unpaid";
								if (text20 == text28)
								{
									Program.UnpaidKey = true;
									Form owner6 = Program.TopMost_();
									string text29 = "Aapki ID Unpaid hai\nUnpaid ID Kabhi bhi Deactivate ho sakti hai\nAgar Aapka Payment Clear hai to Seller se Bolke Paid Karayen";
									string caption6 = "UNPAID KEY";
									MessageBox.Show(owner6, text29, caption6, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
								}
							}
							Program.KeyStatus = text20;
							text5 = text13;
							string expression = text5;
							string delimiter = "#";
							Strings.Split(expression, delimiter);
							if (!flag)
							{
								Form owner7 = Program.smethod_7();
								string caption7 = "Hitman";
								MessageBox.Show(owner7, text17, caption7, MessageBoxButtons.OK);
								Environment.Exit(0);
							}
							if (!flag)
							{
								MessageBox.Show(text5);
								Environment.Exit(0);
							}
							else
							{
								result = true;
								string path = "key.dll";
								if (!File.Exists(path))
								{
									mySettings mySettings_ = Program.mySettings_0;
									string keepId = "5";
									mySettings_.KeepId = keepId;
									Program.mySettings_0.OcrPath = "";
									Program.mySettings_0.CloseOnPnr = true;
									mySettings mySettings_2 = Program.mySettings_0;
									string keepHistory = "30";
									mySettings_2.KeepHistory = keepHistory;
									mySettings mySettings_3 = Program.mySettings_0;
									string proxy_use = "system";
									mySettings_3.Proxy_use = proxy_use;
									mySettings mySettings_4 = Program.mySettings_0;
									string ac_avl = "47";
									mySettings_4.Ac_avl = ac_avl;
									mySettings mySettings_5 = Program.mySettings_0;
									string sl_avl = "39";
									mySettings_5.Sl_avl = sl_avl;
									Program.mySettings_0.isAutoCaptcha = true;
									Program.mySettings_0.isMicroWindow = false;
									Program.mySettings_0.strCaptchaService = "";
									Program.mySettings_0.isLargeCaptcha = false;
									Program.mySettings_0.isAutoSubmitCaptcha = true;
									Program.mySettings_0.NonManagerDashborad = true;
									Program.mySettings_0.SpeedUP = true;
									mySettings.smethod_2(Program.mySettings_0);
								}
							}
							Program.ExpiryDay = int.Parse(s2);
							if (Program.ExpiryDay < 0)
							{
								string text30 = "THIS ID IS HAS BEEN EXPIRED. PLEASE RENEW YOUR ID Validity Left -" + Program.ExpiryDay;
								MessageBox.Show(text30);
								string text31 = "THIS ID IS HAS BEEN EXPIRED. PLEASE RENEW YOUR ID";
								method_0(text31 + Program.clientID, 0);
								string path2 = "key.dll";
								if (File.Exists(path2))
								{
									string path3 = "key.dll";
									File.Delete(path3);
								}
								result = false;
							}
							StatClass.AllNEWS = Program.Latnews;
							if (!string.IsNullOrEmpty(Program.MsgNews))
							{
								string allNEWS = StatClass.AllNEWS;
								string text32 = "\n1.";
								StatClass.AllNEWS = allNEWS + text32 + Program.MsgNews;
							}
							if (!string.IsNullOrEmpty(Program.SellerMeg))
							{
								string allNEWS2 = StatClass.AllNEWS;
								string text33 = "\n2.";
								StatClass.AllNEWS = allNEWS2 + text33 + Program.SellerMeg;
							}
							Class28.smethod_9(Program.DownloadUri);
							Program.dateTime_0.AddDays(31.0).Ticks.ToString();
							Class28.smethod_12(Program.dateTime_0.AddDays(Program.ExpiryDay).Ticks.ToString());
							if (!string.IsNullOrEmpty(text18))
							{
								Program.list_Proxy.Clear();
								string text34 = (new string[1] { text18 })[0].Trim();
								string[] array5 = new string[1];
								string text35 = "|--|";
								array5[0] = text35;
								string[] array6 = text34.Split(array5, StringSplitOptions.RemoveEmptyEntries);
								if (array6 != null && array6.Length != 0)
								{
									for (int i = 0; i < array6.Length; i++)
									{
										if (string.IsNullOrEmpty(array6[i]) || array6[i].Length <= 24)
										{
											continue;
										}
										try
										{
											string text36 = array6[i];
											string[] array7 = new string[1];
											string text37 = "||";
											array7[0] = text37;
											if (text36.Split(array7, StringSplitOptions.None).Length == 4)
											{
												Program.list_Proxy.Add(array6[i].Trim());
											}
										}
										catch
										{
										}
									}
								}
							}
							if (appversion != Program.NewVersion)
							{
								string clientID = Program.clientID;
								string text38 = "SGX9777";
								if (clientID != text38)
								{
									Program.bool_IsExeUpdtAvl = true;
									string filoList = Program.FiloList;
									string exeName = Program.ExeName;
									string text39 = "|";
									Program.FiloList = filoList + exeName + text39;
									Program.RunExeUpdater();
									goto IL_0cd5;
								}
							}
							Staticm.Check_File2(0);
							Staticm.Method_3500();
							user_Registry(text5);
							goto IL_0cd5;
						}
						pictureBox2.Visible = false;
						string string_57 = text5;
						string string_58 = "message\"";
						string string_59 = "\"";
						string text40 = method_1(string_57, string_58, string_59);
						Form owner8 = Program.smethod_7();
						string caption8 = "Hitman";
						MessageBox.Show(owner8, text40, caption8, MessageBoxButtons.OK);
						result = false;
						goto end_IL_03a8;
						IL_0cd5:
						new frmProxySetting().ipAdd();
						CAAA0();
						end_IL_03a8:;
					}
					catch (Exception ex3)
					{
						pictureBox2.Visible = false;
						MessageBox.Show(ex3.Message);
						result = false;
						goto IL_0d1a;
					}
					goto IL_0d13;
				}
				goto IL_0d1a;
				IL_0d13:
				return result;
				IL_0d1a:
				if (num <= 6)
				{
					break;
				}
				int num3;
				do
				{
					int[,,] array8 = new int[2, 1, 5]
					{
						{ { -89592267, 1152184389, -1175893326, -1914810477, -1826459725 } },
						{ { 1659236237, 457233588, -89592264, -838556134, -1542306092 } }
					};
					int num2 = -array8[0, 0, 0] ^ 0x55711C9;
					num3 = num2;
				}
				while (num3 == 0);
				if (num3 != 2)
				{
					continue;
				}
				goto IL_0d13;
			}
		}
	}

	public string user_RegistryRead()
	{
		string text = "";
		string text2 = "";
		string requestUriString = "https://raw.githubusercontent.com/hitmants2026-a11y/Hitman/refs/heads/main/offlineallow";
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
			text2 = streamReader.ReadToEnd().Trim();
			if (string.IsNullOrEmpty(text2))
			{
				text2 = "true";
			}
		}
		catch (Exception)
		{
			text2 = "true";
		}
		if (text2 != "false")
		{
			try
			{
				string text3 = "Software\\Microsoft\\Windows\\Shell";
				string name = text3;
				string text4 = "NgetData";
				string name2 = text4;
				using RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(name);
				if (registryKey != null)
				{
					object value = registryKey.GetValue(name2);
					if (value != null)
					{
						string string_ = value.ToString();
						string string_2 = "4d4#r7%55";
						string text5 = Class2.Decrypt(string_, string_2);
						string[] array = new string[1];
						string text6 = "___";
						array[0] = text6;
						string[] array2 = text5.Split(array, StringSplitOptions.None);
						string s = array2[0];
						string text7 = "dd-MMM-yyyy HH:mm:ss";
						string format = text7;
						DateTime dateTime = DateTime.ParseExact(s, format, CultureInfo.InvariantCulture);
						string string_3 = array2[1];
						string string_4 = "leftDays";
						string string_5 = ",";
						string s2 = method_1(string_3, string_4, string_5);
						dateTime = dateTime.AddDays(int.Parse(s2));
						if (!(dateTime >= DateTime.Now))
						{
							string text8 = "{\"success\":false,\"message\":\"Licence Key Expire\",\"leftDays\":0,\"tokens\":null,\"appVersion\":null,\"ipList\":null,\"ShortMessage\":null,\"News\":null,\"KeyType\":null,\"paid\":null,\"DllVersion\":null,\"ChromeDriver\":null,\"SaltKey\":null,\"ChromeVersion\":null,\"SellerId\":null,\"Premium\":false,\"S3URL\":null,\"edata\":null,\"sdata\":null,\"adata\":null,\"SuperSeller\":null,\"Admin\":null,\"pass\":null}";
							text = text8;
						}
						else
						{
							text = array2[1];
							string string_6 = text;
							string string_7 = "appVersion\"";
							string string_8 = "\"";
							string text9 = method_1(string_6, string_7, string_8);
							string[] array3 = new string[1];
							string text10 = "||";
							array3[0] = text10;
							array2 = text9.Split(array3, StringSplitOptions.None);
							appversion = array2[0];
						}
					}
				}
			}
			catch
			{
			}
		}
		return text;
	}

	public void user_Registry(string text3)
	{
		string text4 = "Software\\Microsoft\\Windows\\Shell";
		string subkey = text4;
		string text5 = "NgetData";
		string name = text5;
		DateTime now = DateTime.Now;
		string text6 = "dd-MMM-yyyy HH:mm:ss";
		string text7 = now.ToString(text6);
		string text8 = "___";
		string string_ = text7 + text8 + text3;
		string string_2 = "4d4#r7%55";
		object value = Class2.Encrypt(string_, string_2);
		try
		{
			RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(subkey);
			registryKey.SetValue(name, value);
			registryKey.Close();
		}
		catch (Exception)
		{
		}
	}

	private void bunifuButton1_Click(object sender, EventArgs e)
	{
		bunifuButton1_Clik = true;
	}

	private void btnLogin_Click(object sender, EventArgs e)
	{
		if ((txtUserName.Text == "") | (txtPassword.Text == ""))
		{
			return;
		}
		int_0++;
		CAAA0();
		Process[] processesByName = Process.GetProcessesByName(Program.AppName);
		if ((processesByName == null || processesByName.Length > 1) && !Program.mySettings_0.NonManagerDashborad)
		{
			try
			{
				Form owner = new Form
				{
					TopMost = true
				};
				string text = "An instance of ";
				string appName = Program.AppName;
				string text2 = " is already running! Do you want to close All Opended Window and run this Again?";
				string text3 = text + appName + text2;
				string text4 = "Close Running ";
				if (MessageBox.Show(owner, text3, text4 + Program.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					if (!Program.StopAllWindows() && !processesByName[0].HasExited)
					{
						Form owner2 = new Form
						{
							TopMost = true
						};
						string text5 = "Could not close existing instance of ";
						string appName2 = Program.AppName;
						string text6 = "! Please Wait We are Alternative going for Close";
						string text7 = text5 + appName2 + text6;
						string text8 = "Closing ";
						MessageBox.Show(owner2, text7, text8 + Program.AppName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
				}
				else
				{
					Environment.Exit(0);
				}
			}
			catch
			{
				Environment.Exit(0);
			}
		}
		bunifuFlatButton1.Enabled = false;
		if (!string.IsNullOrEmpty(txtUserName.Text) && !string.IsNullOrEmpty(txtPassword.Text))
		{
			Program.clientID = txtUserName.Text.Trim();
			Program.string_00 = txtPassword.Text.Trim();
			if (int_0 > 0)
			{
				mySettings.bool_1 = bunifuToggleRememberSwitch.Value;
			}
			if (bunifuToggleAutoLoginSwitch.Value)
			{
				mySettings.bool_2 = true;
			}
			Program.mySettings_0.userID = Program.clientID;
			if (mySettings.bool_1)
			{
				string clientID = Program.clientID;
				string text9 = "~";
				Class28.smethod_16(clientID + text9 + Program.string_00);
			}
			string erPlce = "Validation Start3";
			Program.ErPlce = erPlce;
			string object_ = "Start Login Credital Checkup And Validation..........";
			method_0(object_, 0);
			string string_ = "Program.Main";
			string string_2 = "Vld Bkg Start";
			Class28.smethod_26(string_, string_2);
			ThreadPool.QueueUserWorkItem(Func_LoginChk);
		}
	}

	private void frmLogin_Load(object sender, EventArgs e)
	{
		DeleteCogif();
		ThreadPool.QueueUserWorkItem(ClassStationData.load);
		txtLogin.Text = Program.mySettings_0.userID;
		bool clearPwd = false;
		if (txtUserName.Text == "")
		{
			clearPwd = true;
		}
		txtPassword.Text = Class28.smethod_15(clearPwd, 1);
		mySettings.bool_1 = txtPassword.Text != "";
		method_4();
		txtUserName.Focus();
		base.WindowState = FormWindowState.Normal;
		base.TopMost = false;
		Focus();
		if (mySettings.bool_2)
		{
			bunifuToggleRememberSwitch.Value = true;
			btnLogin_Click(sender, e);
		}
	}

	private void C1AA0_Click(object sender, EventArgs e)
	{
		try
		{
			string value = Class28.smethod_15(clearPwd: false, 0);
			if (string.IsNullOrEmpty(value))
			{
				string text = "Unable to retrive User ID.";
				string caption = "User";
				MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				txtUserName.Text = value;
				string text2 = "User ID retrived successfully!";
				string caption2 = "User";
				MessageBox.Show(text2, caption2, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
		catch
		{
		}
	}

	private void CAAA0()
	{
		mySettings.bool_1 = bunifuToggleRememberSwitch.Value;
		mySettings.bool_2 = bunifuToggleAutoLoginSwitch.Value;
		Program.mySettings_0.isRememberPassword = mySettings.bool_1;
		Program.mySettings_0.isAutoLogin = mySettings.bool_2;
		Program.mySettings_0.NonManagerDashborad = mySettings.bool_3;
		Program.mySettings_0.WithoutScreenLogin = true;
		if (!(Program.mySettings_0.NonManagerDashborad & (StatClass.TotalOpendWindow > 1)))
		{
			if (!bunifuToggleAppModeSwitch.Value)
			{
				mySettings.bool_3 = true;
			}
			else
			{
				mySettings.bool_3 = false;
			}
		}
	}

	private void B2AAA_Click(object sender, EventArgs e)
	{
		string fileName = "https://www.Ngetsoftware.in";
		Process.Start(fileName);
	}

	private void chkLoginScreenShow_CheckedChanged(object sender, EventArgs e)
	{
		Program.mySettings_0.WithoutScreenLogin = chkLoginScreenShow.Checked;
	}

	private void C2AA0_Click(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(txtUserName.Text))
		{
			string text = "Please Enter Your Userid For Complaint";
			MessageBox.Show(text);
			return;
		}
		Program.clientID = txtUserName.Text.Trim();
		Program.string_00 = txtPassword.Text.Trim();
		string format = "{0}?Id={1}";
		object[] array = new object[2];
		string uri = Program.Uri;
		string text2 = "GetMailId.php";
		array[0] = uri + text2;
		array[1] = Program.clientID;
		string uriString = string.Format(format, array);
		try
		{
			string prm_key = "trrueolkdiwpoidaanjweolkvkwpoiMv";
			string prm_iv = "49201112549354092144548505456500";
			WebClient webClient = new WebClient();
			WebHeaderCollection headers = webClient.Headers;
			string value = "My app";
			headers.Add(HttpRequestHeader.UserAgent, value);
			webClient.Proxy = Program.PublicProxy;
			string text3 = Class2.DecryptRJ256(prm_key, prm_iv, webClient.DownloadString(new Uri(uriString))).Trim();
			string oldValue = "\0";
			string expression = text3.Replace(oldValue, "");
			string delimiter = "#";
			string[] array2 = Strings.Split(expression, delimiter);
			Program.string_13 = array2[0].ToString();
			Program.string_14 = array2[1].ToString();
		}
		catch
		{
			Program.PublicProxy = Program.PrivateProxy;
			string text4 = "There Are Some Issue With Internet, Please Retry Once Again It.";
			MessageBox.Show(text4);
			return;
		}
		new frmComplaint().ShowDialog();
	}

	private void bunifuFlatButton1_Click(object sender, EventArgs e)
	{
		Program.StrongPassword_text = encP.Text;
		txtUserName.Text = txtLogin.Text;
		BunifuTextbox bunifuTextbox = txtPassword;
		string text = "";
		if (encP.Text.Length < 4)
		{
			Form owner = new Form
			{
				TopMost = true
			};
			string text2 = "Enter Valid Password , Default Password is  123456";
			string caption = "Hitman";
			MessageBox.Show(owner, text2, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		text = ((encP.Text.Length >= 4) ? encP.Text : "123456");
		bunifuTextbox.Text = text;
		pictureBox2.Width = base.Width;
		pictureBox2.Location = new Point(0, 24);
		pictureBox2.Visible = true;
		btnLogin_Click(sender, e);
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
	}

	private void bunifuFlatButton2_Click(object sender, EventArgs e)
	{
		Close();
		Application.Exit();
	}

	private void method_4()
	{
		bunifuToggleRememberSwitch.Value = mySettings.bool_1;
		bunifuToggleAutoLoginSwitch.Value = mySettings.bool_2;
		if (!mySettings.bool_3)
		{
			bunifuToggleAppModeSwitch.Value = true;
		}
		else
		{
			bunifuToggleAppModeSwitch.Value = false;
		}
	}

	private void Label4_MouseHover(object sender, EventArgs e)
	{
		new ToolTip().SetToolTip(label4, Program.mac);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && C0AA0 != null)
		{
			C0AA0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		BunifuAnimatorNS.Animation animation = new BunifuAnimatorNS.Animation();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(APP_FRAMEWORK.frmLogin));
		this.bunifuTransition_0 = new BunifuAnimatorNS.BunifuTransition(this.components);
		this.checkBox1 = new System.Windows.Forms.CheckBox();
		this.panel2 = new System.Windows.Forms.Panel();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.label1 = new System.Windows.Forms.Label();
		this.txtLogin = new System.Windows.Forms.TextBox();
		this.label4 = new System.Windows.Forms.Label();
		this.label7 = new System.Windows.Forms.Label();
		this.bunifuFlatButton2 = new Bunifu.Framework.UI.BunifuFlatButton();
		this.chkRemember = new System.Windows.Forms.CheckBox();
		this.encP = new System.Windows.Forms.TextBox();
		this.bunifuFlatButton1 = new Bunifu.Framework.UI.BunifuFlatButton();
		this.pictureBox2 = new System.Windows.Forms.PictureBox();
		this.label8 = new System.Windows.Forms.Label();
		this.B2AAA = new Bunifu.Framework.UI.BunifuImageButton();
		this.C1AA0 = new Bunifu.Framework.UI.BunifuImageButton();
		this.B1AAA = new System.Windows.Forms.Label();
		this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
		this.txtUserName = new Bunifu.Framework.UI.BunifuTextbox();
		this.txtPassword = new Bunifu.Framework.UI.BunifuTextbox();
		this.btnLogin = new Bunifu.Framework.UI.BunifuFlatButton();
		this.bunifuToggleRememberSwitch = new Bunifu.Framework.UI.BunifuSwitch();
		this.label2 = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.bunifuToggleAutoLoginSwitch = new Bunifu.Framework.UI.BunifuSwitch();
		this.InfoList2 = new System.Windows.Forms.TextBox();
		this.bunifuProgressBar2 = new Bunifu.Framework.UI.BunifuProgressBar();
		this.bunifuSeparator2 = new Bunifu.Framework.UI.BunifuSeparator();
		this.bunifuProgressBar1 = new Bunifu.Framework.UI.BunifuProgressBar();
		this.C2AA0 = new System.Windows.Forms.Button();
		this.bunifuToggleAppModeSwitch = new Bunifu.Framework.UI.BunifuSwitch();
		this.label6 = new System.Windows.Forms.Label();
		this.label5 = new System.Windows.Forms.Label();
		this.bunifuButton1 = new Bunifu.Framework.UI.BunifuFlatButton();
		this.chkLoginScreenShow = new System.Windows.Forms.CheckBox();
		this.pnlFooter = new System.Windows.Forms.Panel();
		this.panel1 = new System.Windows.Forms.Panel();
		this.label50 = new System.Windows.Forms.Label();
		this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
		this.toolTip_0 = new System.Windows.Forms.ToolTip(this.components);
		this.timer_0 = new System.Windows.Forms.Timer(this.components);
		this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
		this.panel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.B2AAA).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.C1AA0).BeginInit();
		this.pnlFooter.SuspendLayout();
		this.panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.btnClose).BeginInit();
		base.SuspendLayout();
		this.bunifuTransition_0.AnimationType = BunifuAnimatorNS.AnimationType.VertSlide;
		this.bunifuTransition_0.Cursor = null;
		animation.AnimateOnlyDifferences = true;
		animation.BlindCoeff = (System.Drawing.PointF)resources.GetObject("animation5.BlindCoeff");
		animation.LeafCoeff = 0f;
		animation.MaxTime = 1f;
		animation.MinTime = 0f;
		animation.MosaicCoeff = (System.Drawing.PointF)resources.GetObject("animation5.MosaicCoeff");
		animation.MosaicShift = (System.Drawing.PointF)resources.GetObject("animation5.MosaicShift");
		animation.MosaicSize = 0;
		animation.Padding = new System.Windows.Forms.Padding(0);
		animation.RotateCoeff = 0f;
		animation.RotateLimit = 0f;
		animation.ScaleCoeff = (System.Drawing.PointF)resources.GetObject("animation5.ScaleCoeff");
		animation.SlideCoeff = (System.Drawing.PointF)resources.GetObject("animation5.SlideCoeff");
		animation.TimeCoeff = 0f;
		animation.TransparencyCoeff = 0f;
		this.bunifuTransition_0.DefaultAnimation = animation;
		this.checkBox1.AutoSize = true;
		this.bunifuTransition_0.SetDecoration(this.checkBox1, BunifuAnimatorNS.DecorationType.None);
		this.checkBox1.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.checkBox1.ForeColor = System.Drawing.Color.Black;
		this.checkBox1.Location = new System.Drawing.Point(557, 206);
		this.checkBox1.Name = "checkBox1";
		this.checkBox1.Size = new System.Drawing.Size(87, 19);
		this.checkBox1.TabIndex = 212;
		this.checkBox1.Text = "&Auto Login";
		this.checkBox1.UseVisualStyleBackColor = true;
		this.panel2.BackColor = System.Drawing.Color.Transparent;
		this.panel2.Controls.Add(this.pictureBox1);
		this.panel2.Controls.Add(this.label1);
		this.panel2.Controls.Add(this.txtLogin);
		this.panel2.Controls.Add(this.label4);
		this.panel2.Controls.Add(this.label7);
		this.panel2.Controls.Add(this.bunifuFlatButton2);
		this.panel2.Controls.Add(this.chkRemember);
		this.panel2.Controls.Add(this.encP);
		this.panel2.Controls.Add(this.bunifuFlatButton1);
		this.bunifuTransition_0.SetDecoration(this.panel2, BunifuAnimatorNS.DecorationType.None);
		this.panel2.Location = new System.Drawing.Point(0, 24);
		this.panel2.Margin = new System.Windows.Forms.Padding(2);
		this.panel2.Name = "panel2";
		this.panel2.Size = new System.Drawing.Size(422, 177);
		this.panel2.TabIndex = 214;
		this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
		this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.bunifuTransition_0.SetDecoration(this.pictureBox1, BunifuAnimatorNS.DecorationType.None);
		this.pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
		this.pictureBox1.Location = new System.Drawing.Point(2, 4);
		this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new System.Drawing.Size(140, 166);
		this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pictureBox1.TabIndex = 218;
		this.pictureBox1.TabStop = false;
		this.label1.AutoSize = true;
		this.bunifuTransition_0.SetDecoration(this.label1, BunifuAnimatorNS.DecorationType.None);
		this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
		this.label1.Location = new System.Drawing.Point(160, 55);
		this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(35, 17);
		this.label1.TabIndex = 217;
		this.label1.Text = "Key";
		this.bunifuTransition_0.SetDecoration(this.txtLogin, BunifuAnimatorNS.DecorationType.None);
		this.txtLogin.Font = new System.Drawing.Font("Microsoft YaHei UI", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtLogin.Location = new System.Drawing.Point(237, 48);
		this.txtLogin.Name = "txtLogin";
		this.txtLogin.Size = new System.Drawing.Size(166, 28);
		this.txtLogin.TabIndex = 215;
		this.txtLogin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.label4.AutoSize = true;
		this.bunifuTransition_0.SetDecoration(this.label4, BunifuAnimatorNS.DecorationType.None);
		this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label4.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.label4.Location = new System.Drawing.Point(158, 11);
		this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(96, 16);
		this.label4.TabIndex = 213;
		this.label4.Text = "MAC DETAIL";
		this.label4.MouseHover += new System.EventHandler(Label4_MouseHover);
		this.label7.AutoSize = true;
		this.bunifuTransition_0.SetDecoration(this.label7, BunifuAnimatorNS.DecorationType.None);
		this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label7.ForeColor = System.Drawing.SystemColors.WindowText;
		this.label7.Location = new System.Drawing.Point(160, 92);
		this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(77, 17);
		this.label7.TabIndex = 218;
		this.label7.Text = "Password";
		this.bunifuFlatButton2.Activecolor = System.Drawing.Color.FromArgb(46, 139, 87);
		this.bunifuFlatButton2.BackColor = System.Drawing.Color.Red;
		this.bunifuFlatButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.bunifuFlatButton2.BorderRadius = 5;
		this.bunifuFlatButton2.ButtonText = "Exit";
		this.bunifuFlatButton2.Cursor = System.Windows.Forms.Cursors.Hand;
		this.bunifuTransition_0.SetDecoration(this.bunifuFlatButton2, BunifuAnimatorNS.DecorationType.None);
		this.bunifuFlatButton2.DisabledColor = System.Drawing.Color.Gray;
		this.bunifuFlatButton2.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.bunifuFlatButton2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.bunifuFlatButton2.Iconcolor = System.Drawing.Color.Transparent;
		this.bunifuFlatButton2.Iconimage = null;
		this.bunifuFlatButton2.Iconimage_right = null;
		this.bunifuFlatButton2.Iconimage_right_Selected = null;
		this.bunifuFlatButton2.Iconimage_Selected = null;
		this.bunifuFlatButton2.IconMarginLeft = 0;
		this.bunifuFlatButton2.IconMarginRight = 0;
		this.bunifuFlatButton2.IconRightVisible = true;
		this.bunifuFlatButton2.IconRightZoom = 0.0;
		this.bunifuFlatButton2.IconVisible = true;
		this.bunifuFlatButton2.IconZoom = 40.0;
		this.bunifuFlatButton2.IsTab = false;
		this.bunifuFlatButton2.Location = new System.Drawing.Point(163, 146);
		this.bunifuFlatButton2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		this.bunifuFlatButton2.Name = "bunifuFlatButton2";
		this.bunifuFlatButton2.Normalcolor = System.Drawing.Color.Red;
		this.bunifuFlatButton2.OnHovercolor = System.Drawing.Color.MintCream;
		this.bunifuFlatButton2.OnHoverTextColor = System.Drawing.Color.Black;
		this.bunifuFlatButton2.selected = false;
		this.bunifuFlatButton2.Size = new System.Drawing.Size(90, 24);
		this.bunifuFlatButton2.TabIndex = 212;
		this.bunifuFlatButton2.Text = "Exit";
		this.bunifuFlatButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.bunifuFlatButton2.Textcolor = System.Drawing.Color.White;
		this.bunifuFlatButton2.TextFont = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.bunifuFlatButton2.Click += new System.EventHandler(bunifuFlatButton2_Click);
		this.chkRemember.AutoSize = true;
		this.chkRemember.Checked = true;
		this.chkRemember.CheckState = System.Windows.Forms.CheckState.Checked;
		this.bunifuTransition_0.SetDecoration(this.chkRemember, BunifuAnimatorNS.DecorationType.None);
		this.chkRemember.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.chkRemember.ForeColor = System.Drawing.Color.Black;
		this.chkRemember.Location = new System.Drawing.Point(163, 117);
		this.chkRemember.Name = "chkRemember";
		this.chkRemember.Size = new System.Drawing.Size(155, 21);
		this.chkRemember.TabIndex = 210;
		this.chkRemember.Text = "&Remember My Login ID";
		this.chkRemember.UseVisualStyleBackColor = true;
		this.bunifuTransition_0.SetDecoration(this.encP, BunifuAnimatorNS.DecorationType.None);
		this.encP.Enabled = false;
		this.encP.Font = new System.Drawing.Font("Microsoft YaHei UI", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.encP.Location = new System.Drawing.Point(237, 86);
		this.encP.Name = "encP";
		this.encP.Size = new System.Drawing.Size(166, 28);
		this.encP.TabIndex = 216;
		this.encP.Text = "123456";
		this.encP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.bunifuFlatButton1.Activecolor = System.Drawing.Color.FromArgb(46, 139, 87);
		this.bunifuFlatButton1.BackColor = System.Drawing.Color.Teal;
		this.bunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.bunifuFlatButton1.BorderRadius = 5;
		this.bunifuFlatButton1.ButtonText = "SUBMIT";
		this.bunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand;
		this.bunifuTransition_0.SetDecoration(this.bunifuFlatButton1, BunifuAnimatorNS.DecorationType.None);
		this.bunifuFlatButton1.DisabledColor = System.Drawing.Color.Gray;
		this.bunifuFlatButton1.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.bunifuFlatButton1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.bunifuFlatButton1.Iconcolor = System.Drawing.Color.Transparent;
		this.bunifuFlatButton1.Iconimage = null;
		this.bunifuFlatButton1.Iconimage_right = null;
		this.bunifuFlatButton1.Iconimage_right_Selected = null;
		this.bunifuFlatButton1.Iconimage_Selected = null;
		this.bunifuFlatButton1.IconMarginLeft = 0;
		this.bunifuFlatButton1.IconMarginRight = 0;
		this.bunifuFlatButton1.IconRightVisible = true;
		this.bunifuFlatButton1.IconRightZoom = 0.0;
		this.bunifuFlatButton1.IconVisible = true;
		this.bunifuFlatButton1.IconZoom = 40.0;
		this.bunifuFlatButton1.IsTab = false;
		this.bunifuFlatButton1.Location = new System.Drawing.Point(261, 146);
		this.bunifuFlatButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
		this.bunifuFlatButton1.Name = "bunifuFlatButton1";
		this.bunifuFlatButton1.Normalcolor = System.Drawing.Color.Teal;
		this.bunifuFlatButton1.OnHovercolor = System.Drawing.Color.MintCream;
		this.bunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.Black;
		this.bunifuFlatButton1.selected = false;
		this.bunifuFlatButton1.Size = new System.Drawing.Size(142, 24);
		this.bunifuFlatButton1.TabIndex = 211;
		this.bunifuFlatButton1.Text = "SUBMIT";
		this.bunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.bunifuFlatButton1.Textcolor = System.Drawing.Color.White;
		this.bunifuFlatButton1.TextFont = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.bunifuFlatButton1.Click += new System.EventHandler(bunifuFlatButton1_Click);
		this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
		this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.bunifuTransition_0.SetDecoration(this.pictureBox2, BunifuAnimatorNS.DecorationType.None);
		this.pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
		this.pictureBox2.Location = new System.Drawing.Point(0, 24);
		this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
		this.pictureBox2.Name = "pictureBox2";
		this.pictureBox2.Size = new System.Drawing.Size(205, 179);
		this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pictureBox2.TabIndex = 214;
		this.pictureBox2.TabStop = false;
		this.pictureBox2.Visible = false;
		this.label8.AutoSize = true;
		this.bunifuTransition_0.SetDecoration(this.label8, BunifuAnimatorNS.DecorationType.None);
		this.label8.Location = new System.Drawing.Point(460, 145);
		this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(255, 26);
		this.label8.TabIndex = 219;
		this.label8.Text = "Note :- Password Set Karne ke Liye Option me Jake \r\n           Strong Password Per Click Karen";
		this.B2AAA.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.B2AAA.BackColor = System.Drawing.Color.Silver;
		this.B2AAA.Cursor = System.Windows.Forms.Cursors.Hand;
		this.bunifuTransition_0.SetDecoration(this.B2AAA, BunifuAnimatorNS.DecorationType.None);
		this.B2AAA.Image = (System.Drawing.Image)resources.GetObject("B2AAA.Image");
		this.B2AAA.ImageActive = null;
		this.B2AAA.Location = new System.Drawing.Point(548, 70);
		this.B2AAA.Name = "B2AAA";
		this.B2AAA.Size = new System.Drawing.Size(39, 33);
		this.B2AAA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.B2AAA.TabIndex = 2;
		this.B2AAA.TabStop = false;
		this.B2AAA.Zoom = 10;
		this.B2AAA.Click += new System.EventHandler(B2AAA_Click);
		this.C1AA0.BackColor = System.Drawing.Color.FromArgb(42, 42, 49);
		this.C1AA0.Cursor = System.Windows.Forms.Cursors.Hand;
		this.bunifuTransition_0.SetDecoration(this.C1AA0, BunifuAnimatorNS.DecorationType.None);
		this.C1AA0.Image = (System.Drawing.Image)resources.GetObject("C1AA0.Image");
		this.C1AA0.ImageActive = null;
		this.C1AA0.Location = new System.Drawing.Point(963, 101);
		this.C1AA0.Name = "C1AA0";
		this.C1AA0.Size = new System.Drawing.Size(46, 62);
		this.C1AA0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.C1AA0.TabIndex = 30;
		this.C1AA0.TabStop = false;
		this.C1AA0.Zoom = 10;
		this.C1AA0.Click += new System.EventHandler(C1AA0_Click);
		this.B1AAA.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.B1AAA.AutoSize = true;
		this.B1AAA.BackColor = System.Drawing.Color.FromArgb(219, 58, 108);
		this.bunifuTransition_0.SetDecoration(this.B1AAA, BunifuAnimatorNS.DecorationType.None);
		this.B1AAA.ForeColor = System.Drawing.Color.White;
		this.B1AAA.Location = new System.Drawing.Point(332, 279);
		this.B1AAA.Name = "B1AAA";
		this.B1AAA.Size = new System.Drawing.Size(19, 13);
		this.B1AAA.TabIndex = 3;
		this.B1AAA.Text = "10";
		this.bunifuSeparator1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
		this.bunifuTransition_0.SetDecoration(this.bunifuSeparator1, BunifuAnimatorNS.DecorationType.None);
		this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(105, 105, 105);
		this.bunifuSeparator1.LineThickness = 1;
		this.bunifuSeparator1.Location = new System.Drawing.Point(514, 227);
		this.bunifuSeparator1.Margin = new System.Windows.Forms.Padding(4);
		this.bunifuSeparator1.Name = "bunifuSeparator1";
		this.bunifuSeparator1.Size = new System.Drawing.Size(419, 21);
		this.bunifuSeparator1.TabIndex = 16;
		this.bunifuSeparator1.Transparency = 255;
		this.bunifuSeparator1.Vertical = false;
		this.txtUserName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtUserName.BackColor = System.Drawing.Color.Silver;
		this.txtUserName.BackgroundImage = (System.Drawing.Image)resources.GetObject("txtUserName.BackgroundImage");
		this.txtUserName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.bunifuTransition_0.SetDecoration(this.txtUserName, BunifuAnimatorNS.DecorationType.None);
		this.txtUserName.ForeColor = System.Drawing.Color.White;
		this.txtUserName.Icon = (System.Drawing.Image)resources.GetObject("txtUserName.Icon");
		this.txtUserName.Location = new System.Drawing.Point(691, 56);
		this.txtUserName.Margin = new System.Windows.Forms.Padding(4);
		this.txtUserName.MaximumSize = new System.Drawing.Size(375, 102);
		this.txtUserName.MinimumSize = new System.Drawing.Size(94, 36);
		this.txtUserName.Name = "txtUserName";
		this.txtUserName.Size = new System.Drawing.Size(94, 41);
		this.txtUserName.TabIndex = 7;
		this.txtUserName.text = "Bunifu TextBox";
		this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtPassword.BackColor = System.Drawing.Color.Silver;
		this.txtPassword.BackgroundImage = (System.Drawing.Image)resources.GetObject("txtPassword.BackgroundImage");
		this.txtPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.bunifuTransition_0.SetDecoration(this.txtPassword, BunifuAnimatorNS.DecorationType.None);
		this.txtPassword.ForeColor = System.Drawing.Color.White;
		this.txtPassword.Icon = (System.Drawing.Image)resources.GetObject("txtPassword.Icon");
		this.txtPassword.Location = new System.Drawing.Point(691, 104);
		this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
		this.txtPassword.MaximumSize = new System.Drawing.Size(375, 102);
		this.txtPassword.MinimumSize = new System.Drawing.Size(94, 36);
		this.txtPassword.Name = "txtPassword";
		this.txtPassword.Size = new System.Drawing.Size(94, 36);
		this.txtPassword.TabIndex = 13;
		this.txtPassword.text = "Bunifu TextBox";
		this.btnLogin.Activecolor = System.Drawing.Color.FromArgb(46, 139, 87);
		this.btnLogin.BackColor = System.Drawing.Color.FromArgb(46, 139, 87);
		this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.btnLogin.BorderRadius = 0;
		this.btnLogin.ButtonText = "Login Raffels";
		this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
		this.bunifuTransition_0.SetDecoration(this.btnLogin, BunifuAnimatorNS.DecorationType.None);
		this.btnLogin.DisabledColor = System.Drawing.Color.Gray;
		this.btnLogin.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
		this.btnLogin.Iconcolor = System.Drawing.Color.Transparent;
		this.btnLogin.Iconimage = (System.Drawing.Image)resources.GetObject("btnLogin.Iconimage");
		this.btnLogin.Iconimage_right = null;
		this.btnLogin.Iconimage_right_Selected = null;
		this.btnLogin.Iconimage_Selected = null;
		this.btnLogin.IconMarginLeft = 0;
		this.btnLogin.IconMarginRight = 0;
		this.btnLogin.IconRightVisible = true;
		this.btnLogin.IconRightZoom = 0.0;
		this.btnLogin.IconVisible = true;
		this.btnLogin.IconZoom = 90.0;
		this.btnLogin.IsTab = false;
		this.btnLogin.Location = new System.Drawing.Point(838, 188);
		this.btnLogin.Margin = new System.Windows.Forms.Padding(4);
		this.btnLogin.Name = "btnLogin";
		this.btnLogin.Normalcolor = System.Drawing.Color.FromArgb(46, 139, 87);
		this.btnLogin.OnHovercolor = System.Drawing.Color.FromArgb(36, 129, 77);
		this.btnLogin.OnHoverTextColor = System.Drawing.Color.White;
		this.btnLogin.selected = false;
		this.btnLogin.Size = new System.Drawing.Size(158, 41);
		this.btnLogin.TabIndex = 20;
		this.btnLogin.Text = "Login Raffels";
		this.btnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnLogin.Textcolor = System.Drawing.Color.White;
		this.btnLogin.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.btnLogin.Click += new System.EventHandler(btnLogin_Click);
		this.bunifuToggleRememberSwitch.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
		this.bunifuToggleRememberSwitch.BorderRadius = 0;
		this.bunifuToggleRememberSwitch.Cursor = System.Windows.Forms.Cursors.Hand;
		this.bunifuTransition_0.SetDecoration(this.bunifuToggleRememberSwitch, BunifuAnimatorNS.DecorationType.None);
		this.bunifuToggleRememberSwitch.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
		this.bunifuToggleRememberSwitch.Location = new System.Drawing.Point(886, 142);
		this.bunifuToggleRememberSwitch.Margin = new System.Windows.Forms.Padding(4);
		this.bunifuToggleRememberSwitch.Name = "bunifuToggleRememberSwitch";
		this.bunifuToggleRememberSwitch.Oncolor = System.Drawing.Color.SeaGreen;
		this.bunifuToggleRememberSwitch.Onoffcolor = System.Drawing.Color.DarkGray;
		this.bunifuToggleRememberSwitch.Size = new System.Drawing.Size(51, 19);
		this.bunifuToggleRememberSwitch.TabIndex = 25;
		this.bunifuToggleRememberSwitch.Textcolor = System.Drawing.Color.FromArgb(224, 224, 224);
		this.bunifuToggleRememberSwitch.Value = true;
		this.label2.AutoSize = true;
		this.bunifuTransition_0.SetDecoration(this.label2, BunifuAnimatorNS.DecorationType.None);
		this.label2.Font = new System.Drawing.Font("Segoe UI Light", 11.25f, System.Drawing.FontStyle.Bold);
		this.label2.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
		this.label2.Location = new System.Drawing.Point(692, 142);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(161, 20);
		this.label2.TabIndex = 26;
		this.label2.Text = "Save user credentials";
		this.label3.AutoSize = true;
		this.bunifuTransition_0.SetDecoration(this.label3, BunifuAnimatorNS.DecorationType.None);
		this.label3.Font = new System.Drawing.Font("Segoe UI Light", 11.25f, System.Drawing.FontStyle.Bold);
		this.label3.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
		this.label3.Location = new System.Drawing.Point(692, 171);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(86, 20);
		this.label3.TabIndex = 28;
		this.label3.Text = "Auto Login";
		this.bunifuToggleAutoLoginSwitch.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
		this.bunifuToggleAutoLoginSwitch.BorderRadius = 0;
		this.bunifuToggleAutoLoginSwitch.Cursor = System.Windows.Forms.Cursors.Hand;
		this.bunifuTransition_0.SetDecoration(this.bunifuToggleAutoLoginSwitch, BunifuAnimatorNS.DecorationType.None);
		this.bunifuToggleAutoLoginSwitch.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
		this.bunifuToggleAutoLoginSwitch.Location = new System.Drawing.Point(774, 171);
		this.bunifuToggleAutoLoginSwitch.Margin = new System.Windows.Forms.Padding(4);
		this.bunifuToggleAutoLoginSwitch.Name = "bunifuToggleAutoLoginSwitch";
		this.bunifuToggleAutoLoginSwitch.Oncolor = System.Drawing.Color.SeaGreen;
		this.bunifuToggleAutoLoginSwitch.Onoffcolor = System.Drawing.Color.DarkGray;
		this.bunifuToggleAutoLoginSwitch.Size = new System.Drawing.Size(51, 19);
		this.bunifuToggleAutoLoginSwitch.TabIndex = 27;
		this.bunifuToggleAutoLoginSwitch.Textcolor = System.Drawing.Color.FromArgb(224, 224, 224);
		this.bunifuToggleAutoLoginSwitch.Value = true;
		this.bunifuTransition_0.SetDecoration(this.InfoList2, BunifuAnimatorNS.DecorationType.None);
		this.InfoList2.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.InfoList2.ForeColor = System.Drawing.Color.Maroon;
		this.InfoList2.Location = new System.Drawing.Point(519, 250);
		this.InfoList2.Multiline = true;
		this.InfoList2.Name = "InfoList2";
		this.InfoList2.Size = new System.Drawing.Size(484, 113);
		this.InfoList2.TabIndex = 33;
		this.bunifuProgressBar2.BackColor = System.Drawing.Color.Silver;
		this.bunifuProgressBar2.BorderRadius = 5;
		this.bunifuTransition_0.SetDecoration(this.bunifuProgressBar2, BunifuAnimatorNS.DecorationType.None);
		this.bunifuProgressBar2.Location = new System.Drawing.Point(512, 237);
		this.bunifuProgressBar2.Margin = new System.Windows.Forms.Padding(4);
		this.bunifuProgressBar2.MaximumValue = 100;
		this.bunifuProgressBar2.Name = "bunifuProgressBar2";
		this.bunifuProgressBar2.ProgressColor = System.Drawing.Color.Teal;
		this.bunifuProgressBar2.Size = new System.Drawing.Size(506, 10);
		this.bunifuProgressBar2.TabIndex = 34;
		this.bunifuProgressBar2.Value = 0;
		this.bunifuSeparator2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
		this.bunifuTransition_0.SetDecoration(this.bunifuSeparator2, BunifuAnimatorNS.DecorationType.None);
		this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(105, 105, 105);
		this.bunifuSeparator2.LineThickness = 1;
		this.bunifuSeparator2.Location = new System.Drawing.Point(511, 350);
		this.bunifuSeparator2.Margin = new System.Windows.Forms.Padding(4);
		this.bunifuSeparator2.Name = "bunifuSeparator2";
		this.bunifuSeparator2.Size = new System.Drawing.Size(419, 21);
		this.bunifuSeparator2.TabIndex = 36;
		this.bunifuSeparator2.Transparency = 255;
		this.bunifuSeparator2.Vertical = false;
		this.bunifuProgressBar1.BackColor = System.Drawing.Color.Silver;
		this.bunifuProgressBar1.BorderRadius = 5;
		this.bunifuTransition_0.SetDecoration(this.bunifuProgressBar1, BunifuAnimatorNS.DecorationType.None);
		this.bunifuProgressBar1.Location = new System.Drawing.Point(510, 349);
		this.bunifuProgressBar1.Margin = new System.Windows.Forms.Padding(4);
		this.bunifuProgressBar1.MaximumValue = 100;
		this.bunifuProgressBar1.Name = "bunifuProgressBar1";
		this.bunifuProgressBar1.ProgressColor = System.Drawing.Color.Teal;
		this.bunifuProgressBar1.Size = new System.Drawing.Size(507, 10);
		this.bunifuProgressBar1.TabIndex = 22;
		this.bunifuProgressBar1.Value = 0;
		this.bunifuTransition_0.SetDecoration(this.C2AA0, BunifuAnimatorNS.DecorationType.None);
		this.C2AA0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold);
		this.C2AA0.Location = new System.Drawing.Point(712, 206);
		this.C2AA0.Name = "C2AA0";
		this.C2AA0.Size = new System.Drawing.Size(92, 24);
		this.C2AA0.TabIndex = 208;
		this.C2AA0.Text = "Send Complaint";
		this.C2AA0.UseVisualStyleBackColor = true;
		this.C2AA0.Click += new System.EventHandler(C2AA0_Click);
		this.bunifuToggleAppModeSwitch.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
		this.bunifuToggleAppModeSwitch.BorderRadius = 0;
		this.bunifuToggleAppModeSwitch.Cursor = System.Windows.Forms.Cursors.Hand;
		this.bunifuTransition_0.SetDecoration(this.bunifuToggleAppModeSwitch, BunifuAnimatorNS.DecorationType.None);
		this.bunifuToggleAppModeSwitch.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
		this.bunifuToggleAppModeSwitch.Location = new System.Drawing.Point(263, 58);
		this.bunifuToggleAppModeSwitch.Margin = new System.Windows.Forms.Padding(4);
		this.bunifuToggleAppModeSwitch.Name = "bunifuToggleAppModeSwitch";
		this.bunifuToggleAppModeSwitch.Oncolor = System.Drawing.Color.SeaGreen;
		this.bunifuToggleAppModeSwitch.Onoffcolor = System.Drawing.Color.DarkGray;
		this.bunifuToggleAppModeSwitch.Size = new System.Drawing.Size(51, 19);
		this.bunifuToggleAppModeSwitch.TabIndex = 23;
		this.bunifuToggleAppModeSwitch.Textcolor = System.Drawing.Color.FromArgb(224, 224, 224);
		this.bunifuToggleAppModeSwitch.Value = true;
		this.label6.AutoSize = true;
		this.bunifuTransition_0.SetDecoration(this.label6, BunifuAnimatorNS.DecorationType.None);
		this.label6.Font = new System.Drawing.Font("Segoe UI Light", 11.25f, System.Drawing.FontStyle.Bold);
		this.label6.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
		this.label6.Location = new System.Drawing.Point(3, 58);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(269, 20);
		this.label6.TabIndex = 24;
		this.label6.Text = "Start ..Bull As Manager Base Window";
		this.label5.AutoSize = true;
		this.bunifuTransition_0.SetDecoration(this.label5, BunifuAnimatorNS.DecorationType.None);
		this.label5.Font = new System.Drawing.Font("Segoe UI Light", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label5.ForeColor = System.Drawing.Color.White;
		this.label5.Location = new System.Drawing.Point(94, 4);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(362, 20);
		this.label5.TabIndex = 32;
		this.label5.Text = "(This Window Closes Automatically in 10 Seconds)";
		this.bunifuButton1.Activecolor = System.Drawing.Color.FromArgb(46, 139, 87);
		this.bunifuButton1.BackColor = System.Drawing.Color.FromArgb(46, 139, 87);
		this.bunifuButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.bunifuButton1.BorderRadius = 0;
		this.bunifuButton1.ButtonText = "Proceed";
		this.bunifuButton1.Cursor = System.Windows.Forms.Cursors.Hand;
		this.bunifuTransition_0.SetDecoration(this.bunifuButton1, BunifuAnimatorNS.DecorationType.None);
		this.bunifuButton1.DisabledColor = System.Drawing.Color.Gray;
		this.bunifuButton1.ForeColor = System.Drawing.Color.White;
		this.bunifuButton1.Iconcolor = System.Drawing.Color.Transparent;
		this.bunifuButton1.Iconimage = (System.Drawing.Image)resources.GetObject("bunifuButton1.Iconimage");
		this.bunifuButton1.Iconimage_right = null;
		this.bunifuButton1.Iconimage_right_Selected = null;
		this.bunifuButton1.Iconimage_Selected = null;
		this.bunifuButton1.IconMarginLeft = 0;
		this.bunifuButton1.IconMarginRight = 0;
		this.bunifuButton1.IconRightVisible = true;
		this.bunifuButton1.IconRightZoom = 0.0;
		this.bunifuButton1.IconVisible = true;
		this.bunifuButton1.IconZoom = 90.0;
		this.bunifuButton1.IsTab = false;
		this.bunifuButton1.Location = new System.Drawing.Point(345, 70);
		this.bunifuButton1.Margin = new System.Windows.Forms.Padding(4);
		this.bunifuButton1.Name = "bunifuButton1";
		this.bunifuButton1.Normalcolor = System.Drawing.Color.FromArgb(46, 139, 87);
		this.bunifuButton1.OnHovercolor = System.Drawing.Color.FromArgb(36, 129, 77);
		this.bunifuButton1.OnHoverTextColor = System.Drawing.Color.White;
		this.bunifuButton1.selected = false;
		this.bunifuButton1.Size = new System.Drawing.Size(156, 41);
		this.bunifuButton1.TabIndex = 33;
		this.bunifuButton1.Text = "Proceed";
		this.bunifuButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.bunifuButton1.Textcolor = System.Drawing.Color.White;
		this.bunifuButton1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bunifuButton1.Click += new System.EventHandler(bunifuButton1_Click);
		this.chkLoginScreenShow.AutoSize = true;
		this.bunifuTransition_0.SetDecoration(this.chkLoginScreenShow, BunifuAnimatorNS.DecorationType.None);
		this.chkLoginScreenShow.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.chkLoginScreenShow.ForeColor = System.Drawing.Color.White;
		this.chkLoginScreenShow.Location = new System.Drawing.Point(7, 93);
		this.chkLoginScreenShow.Name = "chkLoginScreenShow";
		this.chkLoginScreenShow.Size = new System.Drawing.Size(173, 18);
		this.chkLoginScreenShow.TabIndex = 36;
		this.chkLoginScreenShow.Text = "Don't Show This At Startup";
		this.chkLoginScreenShow.UseVisualStyleBackColor = true;
		this.chkLoginScreenShow.CheckedChanged += new System.EventHandler(chkLoginScreenShow_CheckedChanged);
		this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(42, 42, 49);
		this.pnlFooter.Controls.Add(this.chkLoginScreenShow);
		this.pnlFooter.Controls.Add(this.bunifuButton1);
		this.pnlFooter.Controls.Add(this.label5);
		this.pnlFooter.Controls.Add(this.label6);
		this.pnlFooter.Controls.Add(this.bunifuToggleAppModeSwitch);
		this.bunifuTransition_0.SetDecoration(this.pnlFooter, BunifuAnimatorNS.DecorationType.None);
		this.pnlFooter.Location = new System.Drawing.Point(514, 365);
		this.pnlFooter.Name = "pnlFooter";
		this.pnlFooter.Size = new System.Drawing.Size(501, 117);
		this.pnlFooter.TabIndex = 35;
		this.panel1.BackColor = System.Drawing.Color.MediumSlateBlue;
		this.panel1.Controls.Add(this.label50);
		this.panel1.Controls.Add(this.btnClose);
		this.bunifuTransition_0.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
		this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
		this.panel1.ForeColor = System.Drawing.Color.FromArgb(17, 17, 18);
		this.panel1.Location = new System.Drawing.Point(0, 0);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(422, 23);
		this.panel1.TabIndex = 1213;
		this.label50.AutoSize = true;
		this.label50.BackColor = System.Drawing.Color.Transparent;
		this.bunifuTransition_0.SetDecoration(this.label50, BunifuAnimatorNS.DecorationType.None);
		this.label50.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label50.Location = new System.Drawing.Point(3, 2);
		this.label50.Name = "label50";
		this.label50.Size = new System.Drawing.Size(60, 20);
		this.label50.TabIndex = 0;
		this.label50.Text = "Hitman";
		this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.btnClose.BackColor = System.Drawing.Color.Transparent;
		this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
		this.bunifuTransition_0.SetDecoration(this.btnClose, BunifuAnimatorNS.DecorationType.None);
		this.btnClose.Image = (System.Drawing.Image)resources.GetObject("btnClose.Image");
		this.btnClose.ImageActive = null;
		this.btnClose.Location = new System.Drawing.Point(397, 0);
		this.btnClose.Margin = new System.Windows.Forms.Padding(2);
		this.btnClose.Name = "btnClose";
		this.btnClose.Size = new System.Drawing.Size(23, 23);
		this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.btnClose.TabIndex = 1;
		this.btnClose.TabStop = false;
		this.btnClose.Zoom = 10;
		this.btnClose.Click += new System.EventHandler(btnClose_Click);
		this.timer_0.Tick += new System.EventHandler(timer_0_Tick);
		this.bunifuElipse1.ElipseRadius = 5;
		this.bunifuElipse1.TargetControl = this;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		base.ClientSize = new System.Drawing.Size(422, 204);
		base.Controls.Add(this.pictureBox2);
		base.Controls.Add(this.panel1);
		base.Controls.Add(this.label8);
		base.Controls.Add(this.panel2);
		base.Controls.Add(this.checkBox1);
		base.Controls.Add(this.B1AAA);
		base.Controls.Add(this.C2AA0);
		base.Controls.Add(this.B2AAA);
		base.Controls.Add(this.pnlFooter);
		base.Controls.Add(this.bunifuProgressBar1);
		base.Controls.Add(this.bunifuSeparator2);
		base.Controls.Add(this.bunifuProgressBar2);
		base.Controls.Add(this.InfoList2);
		base.Controls.Add(this.C1AA0);
		base.Controls.Add(this.bunifuToggleAutoLoginSwitch);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.bunifuToggleRememberSwitch);
		base.Controls.Add(this.btnLogin);
		base.Controls.Add(this.txtPassword);
		base.Controls.Add(this.txtUserName);
		base.Controls.Add(this.bunifuSeparator1);
		this.bunifuTransition_0.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "frmLogin";
		base.Load += new System.EventHandler(frmLogin_Load);
		this.panel2.ResumeLayout(false);
		this.panel2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.B2AAA).EndInit();
		((System.ComponentModel.ISupportInitialize)this.C1AA0).EndInit();
		this.pnlFooter.ResumeLayout(false);
		this.pnlFooter.PerformLayout();
		this.panel1.ResumeLayout(false);
		this.panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.btnClose).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	static frmLogin()
	{
		string text = "2026.09.25.0";
		appversion = text;
		ENCkey = "";
		string text2 = "vfugejd7";
		key = text2;
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		Close();
	}
}
