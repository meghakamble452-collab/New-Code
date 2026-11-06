using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using BunifuAnimatorNS;
using Ionic.Zip;
using Microsoft.Playwright;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using Newtonsoft.Json;
using NEXUS;
using NEXUS.APP_FRAMEWORK;

namespace APP_FRAMEWORK;

public class frmMain : Form
{
	internal delegate void Delegate12(int statusCode, string cntrlName);

	public static Point App_Loc;

	private int int_0;

	private static List<TCntrl> list_0;

	public static bool bool_0;

	public static bool bool_news;

	public static bool chAuto;

	public static int int_3;

	public static int int_4;

	public static int PWid;

	public static int PHei;

	public static int PWid2;

	private bool bool_1;

	private string string_0;

	private bool mProcess;

	private bool isChrome;

	private bool isExtensionActive;

	private HttpListener _cookieListener;

	private bool chBeta;

	private IContainer B3AAA;

	private Button C3AA0;

	private Label lblUsrMsg;

	private BunifuTransition bunifuTransition_0;

	private BunifuElipse bunifuElipse_0;

	private BunifuDragControl bunifuDragControl_0;

	private ImageList imageList_0;

	private Panel pnlHeader;

	private BunifuImageButton btnClose;

	private BunifuTransition bunifuTransition_1;

	private BunifuCustomLabel lbl_Date;

	private MenuStrip menuStrip1;

	private ToolStripMenuItem B4AAA;

	private ToolStripMenuItem C4AA0;

	private ToolStripMenuItem aboutUSToolStripMenuItem;

	public ToolStripMenuItem AutoFillCaptchaToolStripMenuItem;

	public ToolStripMenuItem AutoSubmitCaptchaAfterFill;

	private ToolStripMenuItem googleOCRToolStripMenuItem;

	private ToolStripMenuItem showHistoryToolStripMenuItem;

	private System.Windows.Forms.Timer timer_0;

	private ToolStripMenuItem extractReCaptchaExtensionToolStripMenuItem;

	private ToolStripMenuItem clearCacheToolStripMenuItem;

	private ToolStripMenuItem B6AAA;

	private ToolStripMenuItem C6AA0;

	private ToolStripMenuItem uPIPayByOtherIDToolStripMenuItem;

	private IContainer components;

	private BunifuFlatButton bunifuFlatButton3;

	private BunifuFlatButton bunifuFlatButton4;

	private BunifuFlatButton bunifuFlatButton5;

	private BunifuFlatButton bunifuFlatButton6;

	private BunifuFlatButton bunifuFlatButton7;

	private BunifuFlatButton bunifuFlatButton2;

	private ToolStripMenuItem toolStripSpeedUP;

	private CheckBox chkADV;

	private ToolStripMenuItem enableStrongPasswordToolStripMenuItem;

	private ToolStripMenuItem autoChangeDestinationStationToolStripMenuItem;

	private ToolStripMenuItem autoChangeSourceStationToolStripMenuItem;

	private ToolStripMenuItem reInstallChromeToolStripMenuItem;

	private ToolStripMenuItem solveToolStripMenuItem;

	internal ToolStripMenuItem fixIPBlockManuallyClickSIGNINButtonToolStripMenuItem;

	public ToolStripMenuItem autoFillCaptchaByAPIToolStripMenuItem;

	private ToolStripMenuItem showPassengerCaptchaWindowToolStripMenuItem;

	private BunifuFlatButton bunifuFlatButton1;

	private Panel panel1;

	private BunifuFlatButton bunifuFlatButton8;

	private CheckBox checkBox1;

	private CheckBox checkBox2;

	private BunifuCustomLabel bunifuCustomLabel3;

	private BunifuCustomLabel bunifuCustomLabel4;

	private BunifuCustomLabel bunifuCustomLabel2;

	private Panel panel3;

	private Panel panel2;

	private BunifuCustomLabel bunifuCustomLabel6;

	private BunifuCustomLabel bunifuCustomLabel5;

	private Panel panel4;

	private CheckBox checkBox3;

	private CheckBox checkBox4;

	private CheckBox checkBox5;

	private CheckBox checkBox6;

	private CheckBox checkBox8;

	private CheckBox checkBox7;

	private CheckBox checkBox9;

	private LinkLabel linkLabel1;

	private CheckBox checkBox10;

	private Label label50;

	private bool isUpdating = false;

	private bool isUpdating1 = false;

	[DllImport("kernel32.dll")]
	internal static extern void ExitProcess(uint uint_0);

	public frmMain()
	{
		InitializeComponent();
		StatClass.TotalOpendWindow--;
		panel1.MouseDown += StatClass.Header_MouseDown;
		panel1.MouseMove += StatClass.Header_MouseMove;
		panel1.MouseUp += StatClass.Header_MouseUp;
		Control.CheckForIllegalCrossThreadCalls = false;
		Class28.bool_1 = true;
		Program.mySettings_0.isNewWindowPair = true;
		try
		{
			Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
		}
		catch
		{
		}
		string variable = "Userid";
		Environment.SetEnvironmentVariable(variable, Program.clientID, EnvironmentVariableTarget.Process);
		string variable2 = "BtechDegree";
		string value = "Nget";
		Environment.SetEnvironmentVariable(variable2, value, EnvironmentVariableTarget.Process);
		string variable3 = "BankRejectFix";
		string value2 = "False";
		Environment.SetEnvironmentVariable(variable3, value2, EnvironmentVariableTarget.Process);
		StatClass.TotalOpendTicket = 0;
	}

	static frmMain()
	{
		Class28.int_0 = 0;
		int_3 = 0;
		Class28.int_4 = 0;
		list_0 = new List<TCntrl>();
		Class28.list_2 = new List<string>();
		Class28.dictionary_0 = new Dictionary<int, int>();
		Class28.dictionary_8 = new Dictionary<string, int>();
		Class28.dictionary_9 = new Dictionary<string, int>();
	}

	public void CheckForAutoFill(object object_0)
	{
		lblUsrMsg.Text = Program.SellerMeg;
		mySettings mySettings_ = Program.mySettings_0;
		string formAlign = "Hpair";
		mySettings_.FormAlign = formAlign;
		string formAlign2 = Program.mySettings_0.FormAlign;
		string text = "Hpair";
		if (!(formAlign2 == text))
		{
			StatClass.VPair = true;
		}
		else
		{
			StatClass.HPair = true;
		}
		if (Program.mySettings_0.isAutoCaptcha)
		{
			AutoFillCaptchaToolStripMenuItem.PerformClick();
			if (Program.mySettings_0.isAutoSubmitCaptcha && Program.mySettings_0.isAutoSubmitCaptcha)
			{
				AutoSubmitCaptchaAfterFill.PerformClick();
			}
		}
		Program.mySettings_0.isMicroWindow = true;
		string variable = "LargeCp";
		string environmentVariable = Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.Process);
		string text2 = "True";
		if (environmentVariable == text2)
		{
			Program.mySettings_0.isLargeCaptcha = true;
		}
	}

	public void CheckForAutoFilll(object object_0)
	{
		string query = "DELETE from [TBL_LOG]";
		Staticm.smethod_UpdateFieldValue(query);
	}

	private void frmMain_Load(object sender, EventArgs e)
	{
		string erPlce = "Loading Main Windows";
		Program.ErPlce = erPlce;
		string string_ = "Program.Main";
		Class28.smethod_26(string_, Program.ErPlce);
		int num = Screen.PrimaryScreen.WorkingArea.Width / 2;
		int_0 = Screen.PrimaryScreen.WorkingArea.Width - num;
		Rectangle workingArea = Screen.GetWorkingArea(this);
		pnlHeader.Width = base.Width;
		base.Left = num / 2;
		BunifuCustomLabel bunifuCustomLabel = lbl_Date;
		DateTime now = DateTime.Now;
		string text = "dd-MM-yyyy HH:mm:ss";
		bunifuCustomLabel.Text = now.ToString(text);
		base.Top = workingArea.Height - base.Height;
		App_Loc = base.Location;
		StatClass.TopMargin = PHei;
		StatClass.LeftMargin = 0;
		Staticm.AfterDllDownload(0);
		CheckForAutoFill("");
		ThreadPool.QueueUserWorkItem(CheckForAutoFilll, "");
		ThreadPool.QueueUserWorkItem(method_1);
		uPIPayByOtherIDToolStripMenuItem.PerformClick();
		Program.ExpiryDay++;
		Label label = bunifuCustomLabel5;
		label.Text = string.Concat(null, Program.mySettings_0.userID, null, null, null);
		if (Program.mySettings_0.CloseOnPnr)
		{
			checkBox1.Checked = true;
			StatClass.CloseOnPnr = true;
		}
		bunifuCustomLabel2.Text = Program.ExpiryDay + " Days";
		if (Program.KeyStatus == "Paid")
		{
			bunifuCustomLabel3.Text = "Recived";
		}
		else
		{
			bunifuCustomLabel3.Text = "UNPAID";
		}
		timer_0.Enabled = true;
		string path = "IRLOG";
		if (!Directory.Exists(path))
		{
			string path2 = "IRLOG";
			Directory.CreateDirectory(path2);
		}
		StatClass.operalogin = false;
		string strongPassword = Program.StrongPassword;
		string text2 = "0";
		if (strongPassword != text2)
		{
			enableStrongPasswordToolStripMenuItem.Checked = true;
		}
		StatClass.VideoMode = false;
		checkBox1.Checked = false;
		checkBox6.Checked = true;
		checkBox8.Checked = true;
		checkBox10.Checked = false;
		checkBox9.Checked = true;
	}

	public static void IntervalInDays(int hour, int min, double interval, Action task)
	{
		interval *= 24.0;
		SchedulerService.Instance.ScheduleTask(hour, min, interval, task);
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		BunifuCustomLabel bunifuCustomLabel = lbl_Date;
		int minute = DateTime.Now.Minute;
		if (minute > 45 && (linkLabel1.Enabled = true))
		{
			linkLabel1.Enabled = false;
		}
		DateTime now = DateTime.Now;
		string text = "dd-MM-yyyy HH:mm:ss";
		bunifuCustomLabel.Text = now.ToString(text);
	}

	private void method_0()
	{
		string text = "dd-MMM-yyyy";
		string value = text;
		RegistryKey currentUser = Registry.CurrentUser;
		string name = "Control Panel\\International";
		RegistryKey registryKey = currentUser.OpenSubKey(name, writable: true);
		string name2 = "sShortDate";
		registryKey.SetValue(name2, value);
		registryKey.Close();
	}

	private void method_1(object object_0)
	{
		try
		{
			method_0();
			string systemTimeZone = "India Standard Time";
			SetSystemTimeZone(systemTimeZone);
			string errMessage = "";
			mCOMM mcommInstance_ = Program.mcommInstance_;
			string userID = "update_time";
			string pwd = "update_time";
			mcommInstance_.isLV(userID, pwd, ref errMessage);
			mCOMM mcommInstance_2 = Program.mcommInstance_;
			string key = "test";
			mcommInstance_2.GetData(key);
		}
		catch (Exception)
		{
		}
	}

	public void SetSystemTimeZone(string timeZoneId)
	{
		string text = "";
		try
		{
			text = TimeZone.CurrentTimeZone.StandardName;
		}
		catch
		{
		}
		if (!(text != timeZoneId))
		{
			return;
		}
		try
		{
			ProcessStartInfo processStartInfo = new ProcessStartInfo();
			string fileName = "tzutil.exe";
			processStartInfo.FileName = fileName;
			string text2 = "/s \"";
			string text3 = "\"";
			processStartInfo.Arguments = text2 + timeZoneId + text3;
			processStartInfo.UseShellExecute = false;
			processStartInfo.CreateNoWindow = true;
			Process process = Process.Start(processStartInfo);
			if (process != null)
			{
				process.WaitForExit();
				TimeZoneInfo.ClearCachedData();
			}
		}
		catch
		{
		}
	}

	private string method_14()
	{
		DateTime utcNow = DateTime.UtcNow;
		DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
		return ((long)(utcNow - dateTime).TotalMilliseconds).ToString();
	}

	private void Update_Time00()
	{
		try
		{
			string requestUriString = "https://www.contents.irctc.co.in/eticketing/protected/mapps1/loginCaptcha?nlpCaptchaException=nil";
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
			httpWebRequest.ServerCertificateValidationCallback = frmLogin.CertificateValidation;
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
			string userAgent = "IRCTC Rail Connect/3.1.64iOS";
			httpWebRequest.UserAgent = userAgent;
			string contentType = "application/json; charset=utf-8";
			httpWebRequest.ContentType = contentType;
			string accept = "application/json";
			httpWebRequest.Accept = accept;
			WebHeaderCollection headers = httpWebRequest.Headers;
			string name = "accept-language";
			string value = "en-IN,en;q=0.9";
			headers.Add(name, value);
			WebHeaderCollection headers2 = httpWebRequest.Headers;
			string name2 = "bmirak";
			string value2 = "iosbm";
			headers2.Add(name2, value2);
			WebHeaderCollection headers3 = httpWebRequest.Headers;
			string name3 = "mup";
			string value3 = "C40E54B7-A374-4EF7-B184-73F6905B4E6C";
			headers3.Add(name3, value3);
			WebHeaderCollection headers4 = httpWebRequest.Headers;
			string name4 = "greq";
			string value4 = "irC40E54B76=A3744=4EF70=B1841=73F6905B4E6C3";
			headers4.Add(name4, value4);
			WebHeaderCollection headers5 = httpWebRequest.Headers;
			string name5 = "Content-Language";
			string value5 = "en";
			headers5.Add(name5, value5);
			string method = "GET";
			httpWebRequest.Method = method;
			httpWebRequest.Timeout = 10000;
			httpWebRequest.ReadWriteTimeout = 10000;
			using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
			string text = streamReader.ReadToEnd();
			string value6 = "timeStamp";
			string text2 = text.Substring(text.IndexOf(value6) + 23);
			string text3 = text2;
			string text4 = text2;
			string value7 = "\"";
			text2 = text3.Substring(0, text4.IndexOf(value7));
			_ = new TimeSpan(DateTime.Parse(text2).Ticks - DateTime.Now.Ticks).TotalMilliseconds;
		}
		catch (Exception)
		{
		}
	}

	internal static void smethod_0(object sender, EventArgs e)
	{
		try
		{
			frmProcessTicket frmProcessTicket2 = (frmProcessTicket)sender;
			if (frmProcessTicket2.Tag != null)
			{
				int key = (int)frmProcessTicket2.Tag;
				if (Class28.dictionary_0[key] <= 0)
				{
					Interlocked.Decrement(ref Class28.int_4);
					Class28.dictionary_0.Remove(key);
				}
			}
		}
		catch
		{
		}
	}

	private bool method_2(string string_1)
	{
		try
		{
			int num = frmProcessTicket.WindowCount();
			if (num < Program.WindowCount)
			{
				if (Class28.int_4 >= Program.int_2)
				{
					Form owner = Program.TopMost_();
					string text = "Sorry, you do not have sufficient credits!";
					string caption = "Limitation";
					MessageBox.Show(owner, text, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return false;
				}
				string delimiter = "^#^";
				string[] array = Strings.Split(string_1, delimiter);
				if (array.Length > 4)
				{
					StatClass.lblTktName = array[0];
					StatClass.int_TotalNoOfPair = int.Parse(array[1]);
					StatClass.int_NoOfConnect = int.Parse(array[2]);
					chAuto = bool.Parse(array[3]);
					StatClass.TimeStr = array[4];
				}
				if (Class28.dictionary_9.ContainsKey(StatClass.lblTktName))
				{
					int value = (int_3 = Class28.dictionary_9[StatClass.lblTktName] + 1);
					Class28.dictionary_9[StatClass.lblTktName] = value;
					int_4 = Class28.dictionary_8[StatClass.lblTktName];
				}
				else
				{
					Interlocked.Increment(ref StatClass.TotalOpendTicket);
					int_4 = StatClass.TotalOpendTicket;
					Class28.dictionary_8.Add(StatClass.lblTktName, StatClass.TotalOpendTicket);
					int_3 = 0;
					Class28.dictionary_9.Add(StatClass.lblTktName, int_3);
				}
				Color color_ = Color.FromArgb(255, 255, 255);
				switch (StatClass.TotalOpendTicket)
				{
				case 11:
					color_ = Color.Azure;
					break;
				case 10:
					color_ = Color.Turquoise;
					break;
				}
				if (Class28.int_4 + 1 > Program.int_Slot)
				{
				}
				frmProcessTicket frmProcessTicket2 = new frmProcessTicket(string_1, color_, bool_1: false, int_4, int_3);
				frmProcessTicket2.FormClosed += smethod_0;
				frmProcessTicket2.Show();
				frmProcessTicket2.Activate();
				frmProcessTicket2.ThreadProcUnsafe(0);
				Interlocked.Increment(ref Class28.int_4);
				return true;
			}
			Form owner2 = Program.TopMost_();
			string text2 = "You cannot Open more Than ";
			string text3 = num.ToString();
			string text4 = " Tickets Window at same time.";
			string text5 = text2 + text3 + text4;
			string caption2 = "Hitman Limitation";
			MessageBox.Show(owner2, text5, caption2, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			return false;
		}
		catch (Exception)
		{
			return false;
		}
	}

	private void bunifuFlatButton5_Click(object sender, EventArgs e)
	{
		if (Program.UnpaidKey)
		{
			string text = "Booking Karne ke Liye ID PAID karayen";
			string caption = "ID UnPaid";
			MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		else if (!StatClass.ResetReq)
		{
			if (StatClass.IsReadydll)
			{
				frmManageTicket frmManageTicket2 = new frmManageTicket();
				try
				{
					if (frmManageTicket2.ShowDialog() != DialogResult.OK)
					{
						return;
					}
					foreach (string item in StatClass.Tktlist_0)
					{
						if (!method_2(item))
						{
							break;
						}
					}
					return;
				}
				catch
				{
					return;
				}
				finally
				{
					frmManageTicket2.Dispose();
				}
			}
			string text2 = "Some Files Have Been Downloading, Wait Some Time.\r\nPlease Wait We Are Checking Your System File And Updating is Pending.";
			string caption2 = "Hitman Manager";
			MessageBox.Show(text2, caption2, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		else
		{
			string text3 = "Restart Application Before Open Ticket";
			string caption3 = "Restart Required";
			MessageBox.Show(text3, caption3, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void bunifuFlatButton7_Click(object sender, EventArgs e)
	{
		Form2 form = new Form2();
		form.Show();
		form.Activate();
	}

	private void bunifuFlatButton8_Click(object sender, EventArgs e)
	{
		frmBypass frmBypass2 = new frmBypass();
		frmBypass2.Show();
		frmBypass2.Activate();
	}

	private void frmMain_KeyDown(object sender, KeyEventArgs e)
	{
		string text = e.KeyCode.ToString();
		string text2 = "F6";
		if (!(text == text2))
		{
			string text3 = e.KeyCode.ToString();
			string text4 = "F7";
			if (text3 == text4)
			{
				BunifuFlatButton3_Click(sender, e);
				return;
			}
			string text5 = e.KeyCode.ToString();
			string text6 = "F8";
			if (text5 == text6)
			{
				bunifuFlatButton7_Click(sender, e);
				return;
			}
			string text7 = e.KeyCode.ToString();
			string text8 = "F9";
			if (text7 == text8)
			{
				bunifuFlatButton8_Click(sender, e);
				return;
			}
			string text9 = e.KeyCode.ToString();
			string text10 = "F10";
			if (text9 == text10)
			{
				C3AA0.PerformClick();
			}
		}
		else
		{
			bunifuFlatButton5_Click(sender, e);
		}
	}

	public void Disalbed_Form_Click(bool Cond)
	{
	}

	private void AutoFillCaptchaToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Program.mySettings_0.isAutoCaptcha = AutoFillCaptchaToolStripMenuItem.Checked;
		Program.AutofillOCR = AutoFillCaptchaToolStripMenuItem.Checked;
		mCOMM mcommInstance_ = Program.mcommInstance_;
		string key = "AutofillCp";
		mcommInstance_.SetData(key, AutoFillCaptchaToolStripMenuItem.Checked.ToString());
		string variable = "AutofillCp";
		Environment.SetEnvironmentVariable(variable, AutoFillCaptchaToolStripMenuItem.Checked.ToString(), EnvironmentVariableTarget.Process);
		if (Program.AutofillOCR)
		{
			Program.AutoFillAPI = false;
			autoFillCaptchaByAPIToolStripMenuItem.Checked = false;
		}
	}

	private void AutoSubmitCaptchaAfterFill_Click(object sender, EventArgs e)
	{
		Program.mySettings_0.isAutoSubmitCaptcha = AutoSubmitCaptchaAfterFill.Checked;
		Program.autoSubmitCaptcha = AutoSubmitCaptchaAfterFill.Checked;
		mCOMM mcommInstance_ = Program.mcommInstance_;
		string key = "AutoSubmitCp";
		mcommInstance_.SetData(key, AutoSubmitCaptchaAfterFill.Checked.ToString());
		string variable = "AutoSubmitCp";
		Environment.SetEnvironmentVariable(variable, AutoSubmitCaptchaAfterFill.Checked.ToString(), EnvironmentVariableTarget.Process);
	}

	private void autoFillCaptchaByAPIToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Program.AutoFillAPI = autoFillCaptchaByAPIToolStripMenuItem.Checked;
		if (Program.AutoFillAPI)
		{
			Program.AutofillOCR = false;
			AutoFillCaptchaToolStripMenuItem.Checked = false;
		}
	}

	private void C0AA0(object sender, EventArgs e)
	{
		frmNotes frmNotes2 = new frmNotes(3, 0);
		frmNotes2.Activate();
		frmNotes2.Show();
	}

	private void googleOCRToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
	{
		if (googleOCRToolStripMenuItem.Checked)
		{
			string variable = "OCR";
			string value = "0";
			Environment.SetEnvironmentVariable(variable, value, EnvironmentVariableTarget.Process);
		}
	}

	private void googleOCRToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (!googleOCRToolStripMenuItem.Checked)
		{
			return;
		}
		string c_name = "Microsoft Visual C++";
		Program.bool_VSC = Program.checkInstalled(c_name);
		if (!Program.bool_VSC)
		{
			googleOCRToolStripMenuItem.Checked = false;
			Form owner = new Form
			{
				TopMost = true
			};
			string text = "Google OCR use Karne Ke Liye Kuch File Aapke System me Zaroori hoti hai, Agar Aapne Abhi Tak File Download Karke Install Nahi ki hai to YES Button Ko Click karke Download Karke Install Kariye\r\nAgar Aapne File Install Kar di hai to NO Button Click Kariye";
			string caption = "nlpCaptcha OCR Extention";
			if (MessageBox.Show(owner, text, caption, MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				string fileName = "https://download.microsoft.com/download/6/A/A/6AA4EDFF-645B-48C5-81CC-ED5963AEAD48/vc_redist.x86.exe";
				Process.Start(fileName);
			}
		}
	}

	private void showHistoryToolStripMenuItem_Click(object sender, EventArgs e)
	{
		frmShowHistory frmShowHistory2 = new frmShowHistory();
		frmShowHistory2.Show();
		frmShowHistory2.Activate();
	}

	private void B6AAA_Click(object sender, EventArgs e)
	{
		ThreadPool.QueueUserWorkItem(method_3);
	}

	private void method_3(object object_0)
	{
		string path = "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe";
		if (File.Exists(path))
		{
			new Stopwatch().Start();
			mCOMM mcommInstance_ = Program.mcommInstance_;
			string key = "check_reCaptcha";
			mcommInstance_.GetData(key);
		}
	}

	private void C6AA0_Click(object sender, EventArgs e)
	{
	}

	public void method_4(object object_0)
	{
		string text = "C:\\Program Files\\Google\\Chrome Beta\\Application\\chrome.exe";
		string text2 = text;
		if (!File.Exists(text2))
		{
			Form owner = new Form
			{
				TopMost = true
			};
			string text3 = "Please Install Chromium Web Browser";
			string caption = "Chromium";
			MessageBox.Show(owner, text3, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			return;
		}
		Form owner2 = new Form
		{
			TopMost = true
		};
		string text4 = "Do you Want to Open IRCTC Home Page on Chromium for reCaptcha Check";
		string caption2 = "reCaptcha Checking";
		DialogResult dialogResult = MessageBox.Show(owner2, text4, caption2, MessageBoxButtons.YesNo);
		if (dialogResult != DialogResult.Yes)
		{
			return;
		}
		string processName = "chrome";
		Process[] processesByName = Process.GetProcessesByName(processName);
		for (int i = 0; i < processesByName.Length; i++)
		{
			processesByName[i].Kill();
		}
		Thread.Sleep(500);
		string arguments = "https://www.irctc.co.in/nget/assets/images/secondry-logo.png";
		Process.Start(text2, arguments);
		Form owner3 = new Form
		{
			TopMost = true
		};
		string text5 = "Click on YES Button After Load IRCTC on Chromium";
		string caption3 = "Wait Untill Page Load";
		MessageBox.Show(owner3, text5, caption3, MessageBoxButtons.YesNo);
		if (dialogResult == DialogResult.Yes)
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			mCOMM mcommInstance_ = Program.mcommInstance_;
			string key = "check_reCaptcha2";
			string data = mcommInstance_.GetData(key);
			stopwatch.Stop();
			double totalMilliseconds = stopwatch.Elapsed.TotalMilliseconds;
			string text6 = "Solve";
			if (data == text6)
			{
				Form owner4 = new Form
				{
					TopMost = true
				};
				string text7 = "reCaptcha Solved Successfully, you can Proceed for Booking";
				string caption4 = "Success";
				MessageBox.Show(owner4, text7, caption4, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				Form owner5 = new Form
				{
					TopMost = true
				};
				string text8 = "reCaptcha Solving Time :- ";
				string text9 = totalMilliseconds.ToString();
				string text10 = "   Milliseconds";
				string text11 = text8 + text9 + text10;
				string caption5 = "Time";
				MessageBox.Show(owner5, text11, caption5, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				Form owner6 = new Form
				{
					TopMost = true
				};
				string text12 = "reCaptcha Fail, Please Reinstall XAMPP and SQL Connector and Install reCaptcha Solver Extesion on chrome";
				string caption6 = "Fail";
				MessageBox.Show(owner6, text12, caption6, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}

	private void B1AAA(object sender, EventArgs e)
	{
		string variable = "UPI_AUTO";
		Environment.SetEnvironmentVariable(variable, Convert.ToBoolean(uPIPayByOtherIDToolStripMenuItem.CheckState).ToString());
	}

	private void B2AAA(object sender, EventArgs e)
	{
		frmAboutUS frmAboutUS2 = new frmAboutUS();
		frmAboutUS2.Show();
		frmAboutUS2.Activate();
	}

	private void C2AA0(object sender, EventArgs e)
	{
		StatClass.extract_extension(0);
		StatClass.extract_extension_Chromium(0);
	}

	private void clearCacheToolStripMenuItem_Click(object sender, EventArgs e)
	{
		try
		{
			Class28.smethod_31();
			if (Program.bool_8)
			{
				string text = "Optimization Successful!";
				string caption = "Optimized";
				MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				string text2 = "Optimization not Required or Failed.";
				string caption2 = "Optimized";
				MessageBox.Show(text2, caption2, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		catch
		{
		}
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		string text = "Kya AAP Hitman Software Close Karna Chahte Ho.\r\n\r\nPress Yes To Close Othwise Press No?";
		string caption = "Exit";
		if (MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
		{
			string exitNAME = "2nget";
			Program.exitNAME = exitNAME;
			string text2 = "nget";
			string_0 = text2;
			Environment.Exit(0);
		}
	}

	private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
	{
		try
		{
			mySettings.smethod_2(Program.mySettings_0);
			string text = string_0;
			string text2 = "nget";
			if (text != text2)
			{
				e.Cancel = true;
			}
			string text3 = e.CloseReason.ToString();
			string text4 = "\t\t     ";
			string string_ = text3 + text4 + sender.ToString();
			string path = "Recog_CShape.exe";
			if (File.Exists(path))
			{
				string path2 = "Recog_CShape.exe";
				File.Delete(path2);
			}
			DirectoryInfo directoryInfo = new DirectoryInfo(Application.StartupPath);
			string searchPattern = "*.txt";
			FileInfo[] files = directoryInfo.GetFiles(searchPattern);
			FileInfo[] array = files;
			FileInfo[] array2 = array;
			foreach (FileInfo fileInfo in array2)
			{
				File.Delete(Path.Combine(fileInfo.DirectoryName, fileInfo.Name));
			}
			string string_2 = "frmMain_FormClosing";
			Class28.smethod_26(string_2, string_);
		}
		catch
		{
		}
	}

	private void bunifuFlatButton1_Click(object sender, EventArgs e)
	{
		options options2 = new options();
		options2.Show();
		options2.Activate();
	}

	private void BunifuFlatButton2_Click(object sender, EventArgs e)
	{
		new frmAddID().Show();
	}

	private void BunifuFlatButton3_Click(object sender, EventArgs e)
	{
		frmAddTkt frmAddTkt2 = new frmAddTkt();
		frmAddTkt2.dictionary_1 = Program.dictionary_0;
		frmAddTkt2.ShowDialog();
		frmAddTkt2.Dispose();
	}

	private void NewTicketToolStripMenuItem_Click(object sender, EventArgs e)
	{
		frmAddTkt frmAddTkt2 = new frmAddTkt();
		frmAddTkt2.dictionary_1 = Program.dictionary_0;
		frmAddTkt2.ShowDialog();
		frmAddTkt2.Dispose();
	}

	private void AddPaymentOptionToolStripMenuItem_Click(object sender, EventArgs e)
	{
		new frmCombine().ShowDialog();
	}

	private void AddIRCTCIDToolStripMenuItem_Click(object sender, EventArgs e)
	{
		new frmAddID().Show();
	}

	private void SBIOTPByPassToolStripMenuItem_Click(object sender, EventArgs e)
	{
		new frmNewSBI().Show();
	}

	private void HDFCOTPBYPassToolStripMenuItem_Click(object sender, EventArgs e)
	{
		new frmByPassHDFC().Show();
	}

	private void ProxyIPSettingToolStripMenuItem_Click(object sender, EventArgs e)
	{
		new frmProxySetting().Show();
	}

	private void PayTMOTPByPassToolStripMenuItem_Click(object sender, EventArgs e)
	{
		new frmPaytmB().Show();
	}

	private void ToolStripSpeedUP_Click(object sender, EventArgs e)
	{
		string variable = "S_Window";
		Environment.SetEnvironmentVariable(variable, Convert.ToBoolean(toolStripSpeedUP.CheckState).ToString());
	}

	private void chkADV_CheckedChanged(object sender, EventArgs e)
	{
		if (!isUpdating)
		{
			isUpdating = true;
			if (chkADV.Checked)
			{
				checkBox3.Checked = false;
			}
			checkBox5.Checked = false;
			StatClass.cometlogin = false;
			StatClass.operalogin = chkADV.Checked;
			isUpdating = false;
		}
	}

	private void enableStrongPasswordToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (!enableStrongPasswordToolStripMenuItem.Checked)
		{
			string prompt = "Enter Strong Password";
			string title = "Password";
			string text = Interaction.InputBox(prompt, title);
			string prompt2 = "Re-Enter Strong Password";
			string title2 = "Password";
			string text2 = Interaction.InputBox(prompt2, title2);
			if (text != text2)
			{
				string text3 = "Password Mismatch";
				MessageBox.Show(text3);
				enableStrongPasswordToolStripMenuItem.Checked = false;
			}
			else
			{
				Program.StrongPassword = text;
				Class30.UpdateStrongPassword(Program.StrongPassword);
				enableStrongPasswordToolStripMenuItem.Checked = true;
				string text4 = "Strong Password Set Successfully";
				MessageBox.Show(text4);
			}
		}
		else
		{
			string text5 = "Do You Want to Remove Strong Password";
			string caption = "Password";
			if (MessageBox.Show(text5, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				string strongPassword = "0";
				Program.StrongPassword = strongPassword;
				string pass = "0";
				Class30.UpdateStrongPassword(pass);
				enableStrongPasswordToolStripMenuItem.Checked = false;
				string text6 = "Strong Password Removed Successfully";
				MessageBox.Show(text6);
			}
		}
	}

	private void freeChargeUPIByPassToolStripMenuItem_Click(object sender, EventArgs e)
	{
		new Freecharge().ShowDialog();
	}

	private void aXISBhimUPIAddByPassToolStripMenuItem_Click(object sender, EventArgs e)
	{
		mCOMM mcommInstance_ = Program.mcommInstance_;
		string key = "StartAxisBhim";
		mcommInstance_.SetData(key, "");
	}

	private void phonePeUPIByPassToolStripMenuItem1_Click(object sender, EventArgs e)
	{
		mCOMM mcommInstance_ = Program.mcommInstance_;
		string key = "StartPhonePe";
		mcommInstance_.SetData(key, "");
	}

	private void autoChangeDestinationStationToolStripMenuItem_Click(object sender, EventArgs e)
	{
		string value = autoChangeDestinationStationToolStripMenuItem.Checked.ToString();
		string variable = "SwitchDEST";
		Environment.SetEnvironmentVariable(variable, value);
	}

	private void autoChangeSourceStationToolStripMenuItem_Click(object sender, EventArgs e)
	{
		string variable = "SwitchSRC";
		Environment.SetEnvironmentVariable(variable, autoChangeSourceStationToolStripMenuItem.Checked.ToString());
	}

	private void nPCIUPIByPassToolStripMenuItem_Click(object sender, EventArgs e)
	{
		new frmNPCI().ShowDialog();
	}

	private void reInstallChromeToolStripMenuItem_Click(object sender, EventArgs e)
	{
		ChromeResetRunner.Run();
	}

	private void sBIUPIByPassToolStripMenuItem_Click(object sender, EventArgs e)
	{
		new SbiUpiByPass().ShowDialog();
	}

	private void solveToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Program.PaymentIPBloack = solveToolStripMenuItem.Checked;
	}

	private void fixIPBlockManuallyClickSIGNINButtonToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Program.FixIPBloack = fixIPBlockManuallyClickSIGNINButtonToolStripMenuItem.Checked;
	}

	private void aDDAadhar4DigitToolStripMenuItem_Click(object sender, EventArgs e)
	{
		new frmAddAadhar().ShowDialog();
	}

	private void showPassengerCaptchaWindowToolStripMenuItem_Click(object sender, EventArgs e)
	{
		Program.showCaptcha = showPassengerCaptchaWindowToolStripMenuItem.Checked;
	}

	private void checkTokenToolStripMenuItem_Click(object sender, EventArgs e)
	{
		frmToken frmToken = new frmToken();
		frmToken.Show();
		frmToken.Activate();
	}

	internal async Task StartEdgeAndConnect()
	{
		isChrome = false;
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
		catch (Exception)
		{
		}
	}

	internal void CaptureIRCTCRequests(IPage page)
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
						string text2 = "Check_IP_Block";
						string fileName = text2;
						if (isChrome)
						{
							string text3 = "Check_IP_Block_Chrome";
							fileName = text3;
						}
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

	private async void checkIPBlockToolStripMenuItem_Click_1(object sender, EventArgs e)
	{
		string path = "Check_IP_Block";
		if (File.Exists(path))
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
				string name = "NEXUS.Extention.Hitman IP Block Fixer.dll";
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && B3AAA != null)
		{
			B3AAA.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		BunifuAnimatorNS.Animation animation = new BunifuAnimatorNS.Animation();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(APP_FRAMEWORK.frmMain));
		BunifuAnimatorNS.Animation animation2 = new BunifuAnimatorNS.Animation();
		this.lblUsrMsg = new System.Windows.Forms.Label();
		this.bunifuElipse_0 = new Bunifu.Framework.UI.BunifuElipse(this.components);
		this.bunifuTransition_0 = new BunifuAnimatorNS.BunifuTransition(this.components);
		this.C3AA0 = new System.Windows.Forms.Button();
		this.pnlHeader = new System.Windows.Forms.Panel();
		this.checkBox10 = new System.Windows.Forms.CheckBox();
		this.linkLabel1 = new System.Windows.Forms.LinkLabel();
		this.checkBox9 = new System.Windows.Forms.CheckBox();
		this.checkBox8 = new System.Windows.Forms.CheckBox();
		this.checkBox7 = new System.Windows.Forms.CheckBox();
		this.checkBox5 = new System.Windows.Forms.CheckBox();
		this.checkBox4 = new System.Windows.Forms.CheckBox();
		this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
		this.bunifuCustomLabel5 = new Bunifu.Framework.UI.BunifuCustomLabel();
		this.checkBox6 = new System.Windows.Forms.CheckBox();
		this.bunifuCustomLabel6 = new Bunifu.Framework.UI.BunifuCustomLabel();
		this.checkBox3 = new System.Windows.Forms.CheckBox();
		this.panel4 = new System.Windows.Forms.Panel();
		this.panel3 = new System.Windows.Forms.Panel();
		this.bunifuFlatButton5 = new Bunifu.Framework.UI.BunifuFlatButton();
		this.panel2 = new System.Windows.Forms.Panel();
		this.checkBox2 = new System.Windows.Forms.CheckBox();
		this.checkBox1 = new System.Windows.Forms.CheckBox();
		this.bunifuFlatButton8 = new Bunifu.Framework.UI.BunifuFlatButton();
		this.bunifuFlatButton1 = new Bunifu.Framework.UI.BunifuFlatButton();
		this.chkADV = new System.Windows.Forms.CheckBox();
		this.menuStrip1 = new System.Windows.Forms.MenuStrip();
		this.B4AAA = new System.Windows.Forms.ToolStripMenuItem();
		this.autoFillCaptchaByAPIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.AutoFillCaptchaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.AutoSubmitCaptchaAfterFill = new System.Windows.Forms.ToolStripMenuItem();
		this.showPassengerCaptchaWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.C4AA0 = new System.Windows.Forms.ToolStripMenuItem();
		this.aboutUSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.googleOCRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.showHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.extractReCaptchaExtensionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.clearCacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.B6AAA = new System.Windows.Forms.ToolStripMenuItem();
		this.C6AA0 = new System.Windows.Forms.ToolStripMenuItem();
		this.uPIPayByOtherIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripSpeedUP = new System.Windows.Forms.ToolStripMenuItem();
		this.enableStrongPasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.autoChangeDestinationStationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.autoChangeSourceStationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.reInstallChromeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.solveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.fixIPBlockManuallyClickSIGNINButtonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.bunifuFlatButton2 = new Bunifu.Framework.UI.BunifuFlatButton();
		this.bunifuFlatButton7 = new Bunifu.Framework.UI.BunifuFlatButton();
		this.bunifuFlatButton6 = new Bunifu.Framework.UI.BunifuFlatButton();
		this.bunifuFlatButton4 = new Bunifu.Framework.UI.BunifuFlatButton();
		this.bunifuFlatButton3 = new Bunifu.Framework.UI.BunifuFlatButton();
		this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
		this.bunifuCustomLabel4 = new Bunifu.Framework.UI.BunifuCustomLabel();
		this.panel1 = new System.Windows.Forms.Panel();
		this.lbl_Date = new Bunifu.Framework.UI.BunifuCustomLabel();
		this.label50 = new System.Windows.Forms.Label();
		this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
		this.bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
		this.imageList_0 = new System.Windows.Forms.ImageList(this.components);
		this.bunifuTransition_1 = new BunifuAnimatorNS.BunifuTransition(this.components);
		this.timer_0 = new System.Windows.Forms.Timer(this.components);
		this.pnlHeader.SuspendLayout();
		this.menuStrip1.SuspendLayout();
		this.panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.btnClose).BeginInit();
		base.SuspendLayout();
		this.lblUsrMsg.AutoSize = true;
		this.lblUsrMsg.BackColor = System.Drawing.Color.Transparent;
		this.bunifuTransition_0.SetDecoration(this.lblUsrMsg, BunifuAnimatorNS.DecorationType.None);
		this.bunifuTransition_1.SetDecoration(this.lblUsrMsg, BunifuAnimatorNS.DecorationType.None);
		this.lblUsrMsg.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblUsrMsg.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
		this.lblUsrMsg.Location = new System.Drawing.Point(183, 714);
		this.lblUsrMsg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.lblUsrMsg.Name = "lblUsrMsg";
		this.lblUsrMsg.Size = new System.Drawing.Size(380, 16);
		this.lblUsrMsg.TabIndex = 1173;
		this.lblUsrMsg.Text = "Dear Users More Features And Updates Coming Soon.........";
		this.bunifuElipse_0.ElipseRadius = 5;
		this.bunifuElipse_0.TargetControl = this;
		this.bunifuTransition_0.AnimationType = BunifuAnimatorNS.AnimationType.VertSlide;
		this.bunifuTransition_0.Cursor = null;
		animation.AnimateOnlyDifferences = true;
		animation.BlindCoeff = (System.Drawing.PointF)resources.GetObject("animation3.BlindCoeff");
		animation.LeafCoeff = 0f;
		animation.MaxTime = 1f;
		animation.MinTime = 0f;
		animation.MosaicCoeff = (System.Drawing.PointF)resources.GetObject("animation3.MosaicCoeff");
		animation.MosaicShift = (System.Drawing.PointF)resources.GetObject("animation3.MosaicShift");
		animation.MosaicSize = 0;
		animation.Padding = new System.Windows.Forms.Padding(0);
		animation.RotateCoeff = 0f;
		animation.RotateLimit = 0f;
		animation.ScaleCoeff = (System.Drawing.PointF)resources.GetObject("animation3.ScaleCoeff");
		animation.SlideCoeff = (System.Drawing.PointF)resources.GetObject("animation3.SlideCoeff");
		animation.TimeCoeff = 0f;
		animation.TransparencyCoeff = 0f;
		this.bunifuTransition_0.DefaultAnimation = animation;
		this.C3AA0.BackColor = System.Drawing.Color.Transparent;
		this.bunifuTransition_0.SetDecoration(this.C3AA0, BunifuAnimatorNS.DecorationType.None);
		this.C3AA0.FlatAppearance.BorderSize = 0;
		this.C3AA0.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(128, 128, 255);
		this.C3AA0.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(128, 128, 255);
		this.C3AA0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.C3AA0.ForeColor = System.Drawing.Color.Black;
		this.C3AA0.Location = new System.Drawing.Point(195, 650);
		this.C3AA0.Name = "C3AA0";
		this.C3AA0.Size = new System.Drawing.Size(11, 17);
		this.C3AA0.TabIndex = 161;
		this.C3AA0.Text = "F10";
		this.C3AA0.UseVisualStyleBackColor = false;
		this.pnlHeader.BackColor = System.Drawing.Color.Snow;
		this.pnlHeader.Controls.Add(this.checkBox10);
		this.pnlHeader.Controls.Add(this.linkLabel1);
		this.pnlHeader.Controls.Add(this.checkBox9);
		this.pnlHeader.Controls.Add(this.checkBox8);
		this.pnlHeader.Controls.Add(this.checkBox7);
		this.pnlHeader.Controls.Add(this.checkBox5);
		this.pnlHeader.Controls.Add(this.checkBox4);
		this.pnlHeader.Controls.Add(this.bunifuCustomLabel2);
		this.pnlHeader.Controls.Add(this.bunifuCustomLabel5);
		this.pnlHeader.Controls.Add(this.checkBox6);
		this.pnlHeader.Controls.Add(this.bunifuCustomLabel6);
		this.pnlHeader.Controls.Add(this.checkBox3);
		this.pnlHeader.Controls.Add(this.panel4);
		this.pnlHeader.Controls.Add(this.panel3);
		this.pnlHeader.Controls.Add(this.bunifuFlatButton5);
		this.pnlHeader.Controls.Add(this.panel2);
		this.pnlHeader.Controls.Add(this.checkBox2);
		this.pnlHeader.Controls.Add(this.checkBox1);
		this.pnlHeader.Controls.Add(this.bunifuFlatButton8);
		this.pnlHeader.Controls.Add(this.bunifuFlatButton1);
		this.pnlHeader.Controls.Add(this.chkADV);
		this.pnlHeader.Controls.Add(this.menuStrip1);
		this.pnlHeader.Controls.Add(this.bunifuFlatButton2);
		this.pnlHeader.Controls.Add(this.bunifuFlatButton7);
		this.pnlHeader.Controls.Add(this.bunifuFlatButton6);
		this.pnlHeader.Controls.Add(this.bunifuFlatButton4);
		this.pnlHeader.Controls.Add(this.bunifuFlatButton3);
		this.bunifuTransition_0.SetDecoration(this.pnlHeader, BunifuAnimatorNS.DecorationType.None);
		this.pnlHeader.Location = new System.Drawing.Point(-1, 24);
		this.pnlHeader.Margin = new System.Windows.Forms.Padding(2);
		this.pnlHeader.Name = "pnlHeader";
		this.pnlHeader.Size = new System.Drawing.Size(578, 114);
		this.pnlHeader.TabIndex = 1207;
		this.pnlHeader.Paint += new System.Windows.Forms.PaintEventHandler(pnlHeader_Paint);
		this.checkBox10.AutoSize = true;
		this.bunifuTransition_0.SetDecoration(this.checkBox10, BunifuAnimatorNS.DecorationType.None);
		this.checkBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.checkBox10.ForeColor = System.Drawing.Color.Black;
		this.checkBox10.Location = new System.Drawing.Point(279, 87);
		this.checkBox10.Name = "checkBox10";
		this.checkBox10.Size = new System.Drawing.Size(111, 19);
		this.checkBox10.TabIndex = 1260;
		this.checkBox10.Text = "Stop IP Block";
		this.checkBox10.UseVisualStyleBackColor = true;
		this.checkBox10.CheckedChanged += new System.EventHandler(checkBox10_CheckedChanged_1);
		this.linkLabel1.AutoSize = true;
		this.bunifuTransition_0.SetDecoration(this.linkLabel1, BunifuAnimatorNS.DecorationType.None);
		this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.linkLabel1.Location = new System.Drawing.Point(515, 59);
		this.linkLabel1.Name = "linkLabel1";
		this.linkLabel1.Size = new System.Drawing.Size(57, 20);
		this.linkLabel1.TabIndex = 1259;
		this.linkLabel1.TabStop = true;
		this.linkLabel1.Text = "Reset";
		this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
		this.checkBox9.AutoSize = true;
		this.bunifuTransition_0.SetDecoration(this.checkBox9, BunifuAnimatorNS.DecorationType.None);
		this.checkBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.checkBox9.ForeColor = System.Drawing.Color.Black;
		this.checkBox9.Location = new System.Drawing.Point(452, 61);
		this.checkBox9.Name = "checkBox9";
		this.checkBox9.Size = new System.Drawing.Size(55, 19);
		this.checkBox9.TabIndex = 1258;
		this.checkBox9.Text = "Beta";
		this.checkBox9.UseVisualStyleBackColor = true;
		this.checkBox9.CheckedChanged += new System.EventHandler(checkBox9_CheckedChanged);
		this.checkBox8.AutoSize = true;
		this.bunifuTransition_0.SetDecoration(this.checkBox8, BunifuAnimatorNS.DecorationType.None);
		this.checkBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.checkBox8.ForeColor = System.Drawing.Color.Black;
		this.checkBox8.Location = new System.Drawing.Point(169, 87);
		this.checkBox8.Name = "checkBox8";
		this.checkBox8.Size = new System.Drawing.Size(104, 19);
		this.checkBox8.TabIndex = 1257;
		this.checkBox8.Text = "Direct Login";
		this.checkBox8.UseVisualStyleBackColor = true;
		this.checkBox8.CheckedChanged += new System.EventHandler(checkBox8_CheckedChanged);
		this.checkBox7.AutoSize = true;
		this.bunifuTransition_0.SetDecoration(this.checkBox7, BunifuAnimatorNS.DecorationType.None);
		this.checkBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.checkBox7.ForeColor = System.Drawing.Color.Black;
		this.checkBox7.Location = new System.Drawing.Point(376, 60);
		this.checkBox7.Name = "checkBox7";
		this.checkBox7.Size = new System.Drawing.Size(65, 19);
		this.checkBox7.TabIndex = 1216;
		this.checkBox7.Text = "APP-2";
		this.checkBox7.UseVisualStyleBackColor = true;
		this.checkBox7.CheckedChanged += new System.EventHandler(checkBox7_CheckedChanged);
		this.checkBox5.AutoSize = true;
		this.bunifuTransition_0.SetDecoration(this.checkBox5, BunifuAnimatorNS.DecorationType.None);
		this.checkBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.checkBox5.ForeColor = System.Drawing.Color.Black;
		this.checkBox5.Location = new System.Drawing.Point(203, 60);
		this.checkBox5.Name = "checkBox5";
		this.checkBox5.Size = new System.Drawing.Size(102, 19);
		this.checkBox5.TabIndex = 1256;
		this.checkBox5.Text = "WEB-Comet";
		this.checkBox5.UseVisualStyleBackColor = true;
		this.checkBox5.CheckedChanged += new System.EventHandler(checkBox5_CheckedChanged);
		this.checkBox4.AutoSize = true;
		this.bunifuTransition_0.SetDecoration(this.checkBox4, BunifuAnimatorNS.DecorationType.None);
		this.checkBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.checkBox4.ForeColor = System.Drawing.Color.Black;
		this.checkBox4.Location = new System.Drawing.Point(3, 86);
		this.checkBox4.Name = "checkBox4";
		this.checkBox4.Size = new System.Drawing.Size(76, 19);
		this.checkBox4.TabIndex = 1255;
		this.checkBox4.Text = "Alt Avail";
		this.checkBox4.UseVisualStyleBackColor = true;
		this.checkBox4.CheckedChanged += new System.EventHandler(checkBox4_CheckedChanged);
		this.bunifuCustomLabel2.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.bunifuCustomLabel2.AutoSize = true;
		this.bunifuCustomLabel2.BackColor = System.Drawing.Color.Transparent;
		this.bunifuTransition_0.SetDecoration(this.bunifuCustomLabel2, BunifuAnimatorNS.DecorationType.None);
		this.bunifuCustomLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14f);
		this.bunifuCustomLabel2.ForeColor = System.Drawing.Color.Red;
		this.bunifuCustomLabel2.Location = new System.Drawing.Point(531, 84);
		this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
		this.bunifuCustomLabel2.Size = new System.Drawing.Size(40, 24);
		this.bunifuCustomLabel2.TabIndex = 1217;
		this.bunifuCustomLabel2.Text = "310";
		this.bunifuCustomLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.bunifuCustomLabel5.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.bunifuCustomLabel5.AutoSize = true;
		this.bunifuCustomLabel5.BackColor = System.Drawing.Color.Transparent;
		this.bunifuTransition_0.SetDecoration(this.bunifuCustomLabel5, BunifuAnimatorNS.DecorationType.None);
		this.bunifuCustomLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bunifuCustomLabel5.ForeColor = System.Drawing.Color.Red;
		this.bunifuCustomLabel5.Location = new System.Drawing.Point(440, 84);
		this.bunifuCustomLabel5.Name = "bunifuCustomLabel5";
		this.bunifuCustomLabel5.Size = new System.Drawing.Size(80, 24);
		this.bunifuCustomLabel5.TabIndex = 1218;
		this.bunifuCustomLabel5.Text = "XXXXX";
		this.bunifuCustomLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.checkBox6.AutoSize = true;
		this.bunifuTransition_0.SetDecoration(this.checkBox6, BunifuAnimatorNS.DecorationType.None);
		this.checkBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.checkBox6.ForeColor = System.Drawing.Color.Black;
		this.checkBox6.Location = new System.Drawing.Point(310, 60);
		this.checkBox6.Name = "checkBox6";
		this.checkBox6.Size = new System.Drawing.Size(65, 19);
		this.checkBox6.TabIndex = 1215;
		this.checkBox6.Text = "APP-1";
		this.checkBox6.UseVisualStyleBackColor = true;
		this.checkBox6.CheckedChanged += new System.EventHandler(checkBox6_CheckedChanged);
		this.bunifuCustomLabel6.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.bunifuCustomLabel6.AutoSize = true;
		this.bunifuCustomLabel6.BackColor = System.Drawing.Color.Transparent;
		this.bunifuTransition_0.SetDecoration(this.bunifuCustomLabel6, BunifuAnimatorNS.DecorationType.None);
		this.bunifuCustomLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14f);
		this.bunifuCustomLabel6.ForeColor = System.Drawing.Color.Navy;
		this.bunifuCustomLabel6.Location = new System.Drawing.Point(392, 84);
		this.bunifuCustomLabel6.Name = "bunifuCustomLabel6";
		this.bunifuCustomLabel6.Size = new System.Drawing.Size(52, 24);
		this.bunifuCustomLabel6.TabIndex = 1251;
		this.bunifuCustomLabel6.Text = "Key :";
		this.bunifuCustomLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.checkBox3.AutoSize = true;
		this.bunifuTransition_0.SetDecoration(this.checkBox3, BunifuAnimatorNS.DecorationType.None);
		this.checkBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.checkBox3.ForeColor = System.Drawing.Color.Black;
		this.checkBox3.Location = new System.Drawing.Point(104, 60);
		this.checkBox3.Name = "checkBox3";
		this.checkBox3.Size = new System.Drawing.Size(97, 19);
		this.checkBox3.TabIndex = 1254;
		this.checkBox3.Text = "WEB-Brave";
		this.checkBox3.UseVisualStyleBackColor = true;
		this.checkBox3.CheckedChanged += new System.EventHandler(checkBox3_CheckedChanged);
		this.panel4.BackColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.bunifuTransition_0.SetDecoration(this.panel4, BunifuAnimatorNS.DecorationType.None);
		this.panel4.Location = new System.Drawing.Point(-12, 54);
		this.panel4.Name = "panel4";
		this.panel4.Size = new System.Drawing.Size(590, 2);
		this.panel4.TabIndex = 1253;
		this.panel3.BackColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.bunifuTransition_0.SetDecoration(this.panel3, BunifuAnimatorNS.DecorationType.None);
		this.panel3.Location = new System.Drawing.Point(-13, 81);
		this.panel3.Name = "panel3";
		this.panel3.Size = new System.Drawing.Size(590, 2);
		this.panel3.TabIndex = 1250;
		this.bunifuFlatButton5.Activecolor = System.Drawing.Color.FromArgb(46, 139, 87);
		this.bunifuFlatButton5.BackColor = System.Drawing.Color.FromArgb(46, 139, 87);
		this.bunifuFlatButton5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.bunifuFlatButton5.BorderRadius = 0;
		this.bunifuFlatButton5.ButtonText = "Ip Block Check && Token";
		this.bunifuFlatButton5.Cursor = System.Windows.Forms.Cursors.Hand;
		this.bunifuTransition_0.SetDecoration(this.bunifuFlatButton5, BunifuAnimatorNS.DecorationType.None);
		this.bunifuFlatButton5.DisabledColor = System.Drawing.Color.Gray;
		this.bunifuFlatButton5.Iconcolor = System.Drawing.Color.Transparent;
		this.bunifuFlatButton5.Iconimage = null;
		this.bunifuFlatButton5.Iconimage_right = null;
		this.bunifuFlatButton5.Iconimage_right_Selected = null;
		this.bunifuFlatButton5.Iconimage_Selected = null;
		this.bunifuFlatButton5.IconMarginLeft = 0;
		this.bunifuFlatButton5.IconMarginRight = 0;
		this.bunifuFlatButton5.IconRightVisible = true;
		this.bunifuFlatButton5.IconRightZoom = 0.0;
		this.bunifuFlatButton5.IconVisible = true;
		this.bunifuFlatButton5.IconZoom = 90.0;
		this.bunifuFlatButton5.IsTab = false;
		this.bunifuFlatButton5.Location = new System.Drawing.Point(431, 29);
		this.bunifuFlatButton5.Margin = new System.Windows.Forms.Padding(5);
		this.bunifuFlatButton5.Name = "bunifuFlatButton5";
		this.bunifuFlatButton5.Normalcolor = System.Drawing.Color.FromArgb(46, 139, 87);
		this.bunifuFlatButton5.OnHovercolor = System.Drawing.Color.FromArgb(36, 129, 77);
		this.bunifuFlatButton5.OnHoverTextColor = System.Drawing.Color.White;
		this.bunifuFlatButton5.selected = false;
		this.bunifuFlatButton5.Size = new System.Drawing.Size(145, 23);
		this.bunifuFlatButton5.TabIndex = 1206;
		this.bunifuFlatButton5.Text = "Ip Block Check && Token";
		this.bunifuFlatButton5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.bunifuFlatButton5.Textcolor = System.Drawing.Color.White;
		this.bunifuFlatButton5.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bunifuFlatButton5.Click += new System.EventHandler(bunifuFlatButton7_Click);
		this.panel2.BackColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.bunifuTransition_0.SetDecoration(this.panel2, BunifuAnimatorNS.DecorationType.None);
		this.panel2.Location = new System.Drawing.Point(-21, 111);
		this.panel2.Name = "panel2";
		this.panel2.Size = new System.Drawing.Size(610, 2);
		this.panel2.TabIndex = 1249;
		this.checkBox2.AutoSize = true;
		this.bunifuTransition_0.SetDecoration(this.checkBox2, BunifuAnimatorNS.DecorationType.None);
		this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.checkBox2.ForeColor = System.Drawing.Color.Black;
		this.checkBox2.Location = new System.Drawing.Point(113, 137);
		this.checkBox2.Name = "checkBox2";
		this.checkBox2.Size = new System.Drawing.Size(94, 19);
		this.checkBox2.TabIndex = 1215;
		this.checkBox2.Text = "Auto Close";
		this.checkBox2.UseVisualStyleBackColor = true;
		this.checkBox2.CheckedChanged += new System.EventHandler(checkBox2_CheckedChanged);
		this.checkBox1.AutoSize = true;
		this.bunifuTransition_0.SetDecoration(this.checkBox1, BunifuAnimatorNS.DecorationType.None);
		this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.checkBox1.ForeColor = System.Drawing.Color.Black;
		this.checkBox1.Location = new System.Drawing.Point(86, 86);
		this.checkBox1.Name = "checkBox1";
		this.checkBox1.Size = new System.Drawing.Size(74, 19);
		this.checkBox1.TabIndex = 1214;
		this.checkBox1.Text = "V Mode";
		this.checkBox1.UseVisualStyleBackColor = true;
		this.checkBox1.CheckedChanged += new System.EventHandler(checkBox1_CheckedChanged);
		this.bunifuFlatButton8.Activecolor = System.Drawing.Color.FromArgb(46, 139, 87);
		this.bunifuFlatButton8.BackColor = System.Drawing.Color.FromArgb(46, 139, 87);
		this.bunifuFlatButton8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.bunifuFlatButton8.BorderRadius = 0;
		this.bunifuFlatButton8.ButtonText = "BackUp && Restore";
		this.bunifuFlatButton8.Cursor = System.Windows.Forms.Cursors.Hand;
		this.bunifuTransition_0.SetDecoration(this.bunifuFlatButton8, BunifuAnimatorNS.DecorationType.None);
		this.bunifuFlatButton8.DisabledColor = System.Drawing.Color.Gray;
		this.bunifuFlatButton8.Iconcolor = System.Drawing.Color.Transparent;
		this.bunifuFlatButton8.Iconimage = null;
		this.bunifuFlatButton8.Iconimage_right = null;
		this.bunifuFlatButton8.Iconimage_right_Selected = null;
		this.bunifuFlatButton8.Iconimage_Selected = null;
		this.bunifuFlatButton8.IconMarginLeft = 0;
		this.bunifuFlatButton8.IconMarginRight = 0;
		this.bunifuFlatButton8.IconRightVisible = true;
		this.bunifuFlatButton8.IconRightZoom = 0.0;
		this.bunifuFlatButton8.IconVisible = true;
		this.bunifuFlatButton8.IconZoom = 90.0;
		this.bunifuFlatButton8.IsTab = false;
		this.bunifuFlatButton8.Location = new System.Drawing.Point(289, 29);
		this.bunifuFlatButton8.Margin = new System.Windows.Forms.Padding(5);
		this.bunifuFlatButton8.Name = "bunifuFlatButton8";
		this.bunifuFlatButton8.Normalcolor = System.Drawing.Color.FromArgb(46, 139, 87);
		this.bunifuFlatButton8.OnHovercolor = System.Drawing.Color.FromArgb(36, 129, 77);
		this.bunifuFlatButton8.OnHoverTextColor = System.Drawing.Color.White;
		this.bunifuFlatButton8.selected = false;
		this.bunifuFlatButton8.Size = new System.Drawing.Size(140, 23);
		this.bunifuFlatButton8.TabIndex = 1213;
		this.bunifuFlatButton8.Text = "BackUp && Restore";
		this.bunifuFlatButton8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.bunifuFlatButton8.Textcolor = System.Drawing.Color.White;
		this.bunifuFlatButton8.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bunifuFlatButton8.Click += new System.EventHandler(bunifuFlatButton8_Click_1);
		this.bunifuFlatButton1.Activecolor = System.Drawing.Color.FromArgb(46, 139, 87);
		this.bunifuFlatButton1.BackColor = System.Drawing.Color.FromArgb(46, 139, 87);
		this.bunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.bunifuFlatButton1.BorderRadius = 0;
		this.bunifuFlatButton1.ButtonText = "Add Bank";
		this.bunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand;
		this.bunifuTransition_0.SetDecoration(this.bunifuFlatButton1, BunifuAnimatorNS.DecorationType.None);
		this.bunifuFlatButton1.DisabledColor = System.Drawing.Color.Gray;
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
		this.bunifuFlatButton1.IconZoom = 90.0;
		this.bunifuFlatButton1.IsTab = false;
		this.bunifuFlatButton1.Location = new System.Drawing.Point(3, 29);
		this.bunifuFlatButton1.Margin = new System.Windows.Forms.Padding(5);
		this.bunifuFlatButton1.Name = "bunifuFlatButton1";
		this.bunifuFlatButton1.Normalcolor = System.Drawing.Color.FromArgb(46, 139, 87);
		this.bunifuFlatButton1.OnHovercolor = System.Drawing.Color.FromArgb(36, 129, 77);
		this.bunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.White;
		this.bunifuFlatButton1.selected = false;
		this.bunifuFlatButton1.Size = new System.Drawing.Size(140, 23);
		this.bunifuFlatButton1.TabIndex = 1211;
		this.bunifuFlatButton1.Text = "Add Bank";
		this.bunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.bunifuFlatButton1.Textcolor = System.Drawing.Color.White;
		this.bunifuFlatButton1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bunifuFlatButton1.Click += new System.EventHandler(bunifuFlatButton1_Click_1);
		this.chkADV.AutoSize = true;
		this.bunifuTransition_0.SetDecoration(this.chkADV, BunifuAnimatorNS.DecorationType.None);
		this.chkADV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.chkADV.ForeColor = System.Drawing.Color.Black;
		this.chkADV.Location = new System.Drawing.Point(3, 60);
		this.chkADV.Name = "chkADV";
		this.chkADV.Size = new System.Drawing.Size(100, 19);
		this.chkADV.TabIndex = 1210;
		this.chkADV.Text = "WEB-Opera";
		this.chkADV.UseVisualStyleBackColor = true;
		this.chkADV.CheckedChanged += new System.EventHandler(chkADV_CheckedChanged);
		this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
		this.bunifuTransition_0.SetDecoration(this.menuStrip1, BunifuAnimatorNS.DecorationType.None);
		this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
		this.menuStrip1.Font = new System.Drawing.Font("Cambria", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
		this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.B4AAA });
		this.menuStrip1.Location = new System.Drawing.Point(378, 249);
		this.menuStrip1.Name = "menuStrip1";
		this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
		this.menuStrip1.Size = new System.Drawing.Size(85, 24);
		this.menuStrip1.TabIndex = 166;
		this.menuStrip1.Text = "menuStrip1";
		this.B4AAA.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[20]
		{
			this.autoFillCaptchaByAPIToolStripMenuItem, this.AutoFillCaptchaToolStripMenuItem, this.AutoSubmitCaptchaAfterFill, this.showPassengerCaptchaWindowToolStripMenuItem, this.C4AA0, this.aboutUSToolStripMenuItem, this.googleOCRToolStripMenuItem, this.showHistoryToolStripMenuItem, this.extractReCaptchaExtensionToolStripMenuItem, this.clearCacheToolStripMenuItem,
			this.B6AAA, this.C6AA0, this.uPIPayByOtherIDToolStripMenuItem, this.toolStripSpeedUP, this.enableStrongPasswordToolStripMenuItem, this.autoChangeDestinationStationToolStripMenuItem, this.autoChangeSourceStationToolStripMenuItem, this.reInstallChromeToolStripMenuItem, this.solveToolStripMenuItem, this.fixIPBlockManuallyClickSIGNINButtonToolStripMenuItem
		});
		this.B4AAA.Font = new System.Drawing.Font("Georgia", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.B4AAA.Name = "B4AAA";
		this.B4AAA.Size = new System.Drawing.Size(79, 20);
		this.B4AAA.Text = "Option's";
		this.autoFillCaptchaByAPIToolStripMenuItem.CheckOnClick = true;
		this.autoFillCaptchaByAPIToolStripMenuItem.Name = "autoFillCaptchaByAPIToolStripMenuItem";
		this.autoFillCaptchaByAPIToolStripMenuItem.Size = new System.Drawing.Size(407, 22);
		this.autoFillCaptchaByAPIToolStripMenuItem.Text = "Auto Fill Captcha by API";
		this.autoFillCaptchaByAPIToolStripMenuItem.Click += new System.EventHandler(autoFillCaptchaByAPIToolStripMenuItem_Click);
		this.AutoFillCaptchaToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
		this.AutoFillCaptchaToolStripMenuItem.CheckOnClick = true;
		this.AutoFillCaptchaToolStripMenuItem.Name = "AutoFillCaptchaToolStripMenuItem";
		this.AutoFillCaptchaToolStripMenuItem.Size = new System.Drawing.Size(407, 22);
		this.AutoFillCaptchaToolStripMenuItem.Text = "Auto Fill Captcha by OCR";
		this.AutoFillCaptchaToolStripMenuItem.Click += new System.EventHandler(AutoFillCaptchaToolStripMenuItem_Click);
		this.AutoSubmitCaptchaAfterFill.CheckOnClick = true;
		this.AutoSubmitCaptchaAfterFill.Name = "AutoSubmitCaptchaAfterFill";
		this.AutoSubmitCaptchaAfterFill.Size = new System.Drawing.Size(407, 22);
		this.AutoSubmitCaptchaAfterFill.Text = "AutoSubmit Captcha After Fill";
		this.AutoSubmitCaptchaAfterFill.Click += new System.EventHandler(AutoSubmitCaptchaAfterFill_Click);
		this.showPassengerCaptchaWindowToolStripMenuItem.CheckOnClick = true;
		this.showPassengerCaptchaWindowToolStripMenuItem.Name = "showPassengerCaptchaWindowToolStripMenuItem";
		this.showPassengerCaptchaWindowToolStripMenuItem.Size = new System.Drawing.Size(407, 22);
		this.showPassengerCaptchaWindowToolStripMenuItem.Text = "Show Passenger Captcha Window";
		this.showPassengerCaptchaWindowToolStripMenuItem.Click += new System.EventHandler(showPassengerCaptchaWindowToolStripMenuItem_Click);
		this.C4AA0.Name = "C4AA0";
		this.C4AA0.Size = new System.Drawing.Size(407, 22);
		this.C4AA0.Text = "Show NEWS";
		this.C4AA0.Click += new System.EventHandler(C0AA0);
		this.aboutUSToolStripMenuItem.Name = "aboutUSToolStripMenuItem";
		this.aboutUSToolStripMenuItem.Size = new System.Drawing.Size(407, 22);
		this.aboutUSToolStripMenuItem.Text = "Key Info";
		this.aboutUSToolStripMenuItem.Click += new System.EventHandler(B2AAA);
		this.googleOCRToolStripMenuItem.CheckOnClick = true;
		this.googleOCRToolStripMenuItem.Name = "googleOCRToolStripMenuItem";
		this.googleOCRToolStripMenuItem.Size = new System.Drawing.Size(407, 22);
		this.googleOCRToolStripMenuItem.Text = "Google OCR";
		this.googleOCRToolStripMenuItem.Visible = false;
		this.googleOCRToolStripMenuItem.CheckedChanged += new System.EventHandler(googleOCRToolStripMenuItem_CheckedChanged);
		this.googleOCRToolStripMenuItem.Click += new System.EventHandler(googleOCRToolStripMenuItem_Click);
		this.showHistoryToolStripMenuItem.Name = "showHistoryToolStripMenuItem";
		this.showHistoryToolStripMenuItem.Size = new System.Drawing.Size(407, 22);
		this.showHistoryToolStripMenuItem.Text = "Show History";
		this.showHistoryToolStripMenuItem.Click += new System.EventHandler(showHistoryToolStripMenuItem_Click);
		this.extractReCaptchaExtensionToolStripMenuItem.Name = "extractReCaptchaExtensionToolStripMenuItem";
		this.extractReCaptchaExtensionToolStripMenuItem.Size = new System.Drawing.Size(407, 22);
		this.extractReCaptchaExtensionToolStripMenuItem.Text = "Extract reCaptcha Extension";
		this.extractReCaptchaExtensionToolStripMenuItem.Click += new System.EventHandler(C2AA0);
		this.clearCacheToolStripMenuItem.Name = "clearCacheToolStripMenuItem";
		this.clearCacheToolStripMenuItem.Size = new System.Drawing.Size(407, 22);
		this.clearCacheToolStripMenuItem.Text = "Clear Cache";
		this.clearCacheToolStripMenuItem.Click += new System.EventHandler(clearCacheToolStripMenuItem_Click);
		this.B6AAA.Name = "B6AAA";
		this.B6AAA.Size = new System.Drawing.Size(407, 22);
		this.B6AAA.Text = "Check reCaptcha Connection";
		this.B6AAA.Visible = false;
		this.B6AAA.Click += new System.EventHandler(B6AAA_Click);
		this.C6AA0.Name = "C6AA0";
		this.C6AA0.Size = new System.Drawing.Size(407, 22);
		this.C6AA0.Text = "Check reCaptcha Connection Chrome Beta";
		this.C6AA0.Visible = false;
		this.C6AA0.Click += new System.EventHandler(C6AA0_Click);
		this.uPIPayByOtherIDToolStripMenuItem.CheckOnClick = true;
		this.uPIPayByOtherIDToolStripMenuItem.Name = "uPIPayByOtherIDToolStripMenuItem";
		this.uPIPayByOtherIDToolStripMenuItem.Size = new System.Drawing.Size(407, 22);
		this.uPIPayByOtherIDToolStripMenuItem.Text = "BHIMUPI Direct Pay";
		this.uPIPayByOtherIDToolStripMenuItem.Visible = false;
		this.uPIPayByOtherIDToolStripMenuItem.Click += new System.EventHandler(B1AAA);
		this.toolStripSpeedUP.CheckOnClick = true;
		this.toolStripSpeedUP.Name = "toolStripSpeedUP";
		this.toolStripSpeedUP.Size = new System.Drawing.Size(407, 22);
		this.toolStripSpeedUP.Text = "Small Booking Window";
		this.toolStripSpeedUP.Click += new System.EventHandler(ToolStripSpeedUP_Click);
		this.enableStrongPasswordToolStripMenuItem.Name = "enableStrongPasswordToolStripMenuItem";
		this.enableStrongPasswordToolStripMenuItem.Size = new System.Drawing.Size(407, 22);
		this.enableStrongPasswordToolStripMenuItem.Text = "Enable Strong Password";
		this.enableStrongPasswordToolStripMenuItem.Click += new System.EventHandler(enableStrongPasswordToolStripMenuItem_Click);
		this.autoChangeDestinationStationToolStripMenuItem.CheckOnClick = true;
		this.autoChangeDestinationStationToolStripMenuItem.Name = "autoChangeDestinationStationToolStripMenuItem";
		this.autoChangeDestinationStationToolStripMenuItem.Size = new System.Drawing.Size(407, 22);
		this.autoChangeDestinationStationToolStripMenuItem.Text = "Auto Change Destination Station";
		this.autoChangeDestinationStationToolStripMenuItem.Click += new System.EventHandler(autoChangeDestinationStationToolStripMenuItem_Click);
		this.autoChangeSourceStationToolStripMenuItem.CheckOnClick = true;
		this.autoChangeSourceStationToolStripMenuItem.Name = "autoChangeSourceStationToolStripMenuItem";
		this.autoChangeSourceStationToolStripMenuItem.Size = new System.Drawing.Size(407, 22);
		this.autoChangeSourceStationToolStripMenuItem.Text = "Auto Change Source Station";
		this.autoChangeSourceStationToolStripMenuItem.Click += new System.EventHandler(autoChangeSourceStationToolStripMenuItem_Click);
		this.reInstallChromeToolStripMenuItem.Name = "reInstallChromeToolStripMenuItem";
		this.reInstallChromeToolStripMenuItem.Size = new System.Drawing.Size(407, 22);
		this.reInstallChromeToolStripMenuItem.Text = "Re-Install Chrome";
		this.reInstallChromeToolStripMenuItem.Click += new System.EventHandler(reInstallChromeToolStripMenuItem_Click);
		this.solveToolStripMenuItem.CheckOnClick = true;
		this.solveToolStripMenuItem.Name = "solveToolStripMenuItem";
		this.solveToolStripMenuItem.Size = new System.Drawing.Size(407, 22);
		this.solveToolStripMenuItem.Text = "Solve IP Block on Payment";
		this.solveToolStripMenuItem.Click += new System.EventHandler(solveToolStripMenuItem_Click);
		this.fixIPBlockManuallyClickSIGNINButtonToolStripMenuItem.CheckOnClick = true;
		this.fixIPBlockManuallyClickSIGNINButtonToolStripMenuItem.Name = "fixIPBlockManuallyClickSIGNINButtonToolStripMenuItem";
		this.fixIPBlockManuallyClickSIGNINButtonToolStripMenuItem.Size = new System.Drawing.Size(407, 22);
		this.fixIPBlockManuallyClickSIGNINButtonToolStripMenuItem.Text = "Fix IP Block ( Manually Click SIGN-IN Button )";
		this.fixIPBlockManuallyClickSIGNINButtonToolStripMenuItem.Click += new System.EventHandler(fixIPBlockManuallyClickSIGNINButtonToolStripMenuItem_Click);
		this.bunifuFlatButton2.Activecolor = System.Drawing.Color.FromArgb(46, 139, 87);
		this.bunifuFlatButton2.BackColor = System.Drawing.Color.FromArgb(46, 139, 87);
		this.bunifuFlatButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.bunifuFlatButton2.BorderRadius = 0;
		this.bunifuFlatButton2.ButtonText = "Histry && Proxy";
		this.bunifuFlatButton2.Cursor = System.Windows.Forms.Cursors.Hand;
		this.bunifuTransition_0.SetDecoration(this.bunifuFlatButton2, BunifuAnimatorNS.DecorationType.None);
		this.bunifuFlatButton2.DisabledColor = System.Drawing.Color.Gray;
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
		this.bunifuFlatButton2.IconZoom = 90.0;
		this.bunifuFlatButton2.IsTab = false;
		this.bunifuFlatButton2.Location = new System.Drawing.Point(431, 3);
		this.bunifuFlatButton2.Margin = new System.Windows.Forms.Padding(5);
		this.bunifuFlatButton2.Name = "bunifuFlatButton2";
		this.bunifuFlatButton2.Normalcolor = System.Drawing.Color.FromArgb(46, 139, 87);
		this.bunifuFlatButton2.OnHovercolor = System.Drawing.Color.FromArgb(36, 129, 77);
		this.bunifuFlatButton2.OnHoverTextColor = System.Drawing.Color.White;
		this.bunifuFlatButton2.selected = false;
		this.bunifuFlatButton2.Size = new System.Drawing.Size(145, 22);
		this.bunifuFlatButton2.TabIndex = 1209;
		this.bunifuFlatButton2.Text = "Histry && Proxy";
		this.bunifuFlatButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.bunifuFlatButton2.Textcolor = System.Drawing.Color.White;
		this.bunifuFlatButton2.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bunifuFlatButton2.Click += new System.EventHandler(bunifuFlatButton1_Click);
		this.bunifuFlatButton7.Activecolor = System.Drawing.Color.FromArgb(46, 139, 87);
		this.bunifuFlatButton7.BackColor = System.Drawing.Color.FromArgb(46, 139, 87);
		this.bunifuFlatButton7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.bunifuFlatButton7.BorderRadius = 0;
		this.bunifuFlatButton7.ButtonText = "Add IRCTC";
		this.bunifuFlatButton7.Cursor = System.Windows.Forms.Cursors.Hand;
		this.bunifuTransition_0.SetDecoration(this.bunifuFlatButton7, BunifuAnimatorNS.DecorationType.None);
		this.bunifuFlatButton7.DisabledColor = System.Drawing.Color.Gray;
		this.bunifuFlatButton7.Iconcolor = System.Drawing.Color.Transparent;
		this.bunifuFlatButton7.Iconimage = null;
		this.bunifuFlatButton7.Iconimage_right = null;
		this.bunifuFlatButton7.Iconimage_right_Selected = null;
		this.bunifuFlatButton7.Iconimage_Selected = null;
		this.bunifuFlatButton7.IconMarginLeft = 0;
		this.bunifuFlatButton7.IconMarginRight = 0;
		this.bunifuFlatButton7.IconRightVisible = true;
		this.bunifuFlatButton7.IconRightZoom = 0.0;
		this.bunifuFlatButton7.IconVisible = true;
		this.bunifuFlatButton7.IconZoom = 90.0;
		this.bunifuFlatButton7.IsTab = false;
		this.bunifuFlatButton7.Location = new System.Drawing.Point(3, 3);
		this.bunifuFlatButton7.Margin = new System.Windows.Forms.Padding(5);
		this.bunifuFlatButton7.Name = "bunifuFlatButton7";
		this.bunifuFlatButton7.Normalcolor = System.Drawing.Color.FromArgb(46, 139, 87);
		this.bunifuFlatButton7.OnHovercolor = System.Drawing.Color.FromArgb(36, 129, 77);
		this.bunifuFlatButton7.OnHoverTextColor = System.Drawing.Color.White;
		this.bunifuFlatButton7.selected = false;
		this.bunifuFlatButton7.Size = new System.Drawing.Size(140, 23);
		this.bunifuFlatButton7.TabIndex = 1208;
		this.bunifuFlatButton7.Text = "Add IRCTC";
		this.bunifuFlatButton7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.bunifuFlatButton7.Textcolor = System.Drawing.Color.White;
		this.bunifuFlatButton7.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bunifuFlatButton7.Click += new System.EventHandler(BunifuFlatButton2_Click);
		this.bunifuFlatButton6.Activecolor = System.Drawing.Color.FromArgb(46, 139, 87);
		this.bunifuFlatButton6.BackColor = System.Drawing.Color.FromArgb(46, 139, 87);
		this.bunifuFlatButton6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.bunifuFlatButton6.BorderRadius = 0;
		this.bunifuFlatButton6.ButtonText = "   OTP-ByPASS";
		this.bunifuFlatButton6.Cursor = System.Windows.Forms.Cursors.Hand;
		this.bunifuTransition_0.SetDecoration(this.bunifuFlatButton6, BunifuAnimatorNS.DecorationType.None);
		this.bunifuFlatButton6.DisabledColor = System.Drawing.Color.Gray;
		this.bunifuFlatButton6.Iconcolor = System.Drawing.Color.Transparent;
		this.bunifuFlatButton6.Iconimage = null;
		this.bunifuFlatButton6.Iconimage_right = null;
		this.bunifuFlatButton6.Iconimage_right_Selected = null;
		this.bunifuFlatButton6.Iconimage_Selected = null;
		this.bunifuFlatButton6.IconMarginLeft = 0;
		this.bunifuFlatButton6.IconMarginRight = 0;
		this.bunifuFlatButton6.IconRightVisible = true;
		this.bunifuFlatButton6.IconRightZoom = 0.0;
		this.bunifuFlatButton6.IconVisible = true;
		this.bunifuFlatButton6.IconZoom = 90.0;
		this.bunifuFlatButton6.IsTab = false;
		this.bunifuFlatButton6.Location = new System.Drawing.Point(146, 30);
		this.bunifuFlatButton6.Margin = new System.Windows.Forms.Padding(5);
		this.bunifuFlatButton6.Name = "bunifuFlatButton6";
		this.bunifuFlatButton6.Normalcolor = System.Drawing.Color.FromArgb(46, 139, 87);
		this.bunifuFlatButton6.OnHovercolor = System.Drawing.Color.FromArgb(36, 129, 77);
		this.bunifuFlatButton6.OnHoverTextColor = System.Drawing.Color.White;
		this.bunifuFlatButton6.selected = false;
		this.bunifuFlatButton6.Size = new System.Drawing.Size(140, 23);
		this.bunifuFlatButton6.TabIndex = 1207;
		this.bunifuFlatButton6.Text = "   OTP-ByPASS";
		this.bunifuFlatButton6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.bunifuFlatButton6.Textcolor = System.Drawing.Color.White;
		this.bunifuFlatButton6.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bunifuFlatButton6.Click += new System.EventHandler(bunifuFlatButton8_Click);
		this.bunifuFlatButton4.Activecolor = System.Drawing.Color.FromArgb(46, 139, 87);
		this.bunifuFlatButton4.BackColor = System.Drawing.Color.FromArgb(46, 139, 87);
		this.bunifuFlatButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.bunifuFlatButton4.BorderRadius = 0;
		this.bunifuFlatButton4.ButtonText = " OpenTicket";
		this.bunifuFlatButton4.Cursor = System.Windows.Forms.Cursors.Hand;
		this.bunifuTransition_0.SetDecoration(this.bunifuFlatButton4, BunifuAnimatorNS.DecorationType.None);
		this.bunifuFlatButton4.DisabledColor = System.Drawing.Color.Gray;
		this.bunifuFlatButton4.Iconcolor = System.Drawing.Color.Transparent;
		this.bunifuFlatButton4.Iconimage = null;
		this.bunifuFlatButton4.Iconimage_right = null;
		this.bunifuFlatButton4.Iconimage_right_Selected = null;
		this.bunifuFlatButton4.Iconimage_Selected = null;
		this.bunifuFlatButton4.IconMarginLeft = 0;
		this.bunifuFlatButton4.IconMarginRight = 0;
		this.bunifuFlatButton4.IconRightVisible = true;
		this.bunifuFlatButton4.IconRightZoom = 0.0;
		this.bunifuFlatButton4.IconVisible = true;
		this.bunifuFlatButton4.IconZoom = 90.0;
		this.bunifuFlatButton4.IsTab = false;
		this.bunifuFlatButton4.Location = new System.Drawing.Point(289, 3);
		this.bunifuFlatButton4.Margin = new System.Windows.Forms.Padding(5);
		this.bunifuFlatButton4.Name = "bunifuFlatButton4";
		this.bunifuFlatButton4.Normalcolor = System.Drawing.Color.FromArgb(46, 139, 87);
		this.bunifuFlatButton4.OnHovercolor = System.Drawing.Color.FromArgb(36, 129, 77);
		this.bunifuFlatButton4.OnHoverTextColor = System.Drawing.Color.White;
		this.bunifuFlatButton4.selected = false;
		this.bunifuFlatButton4.Size = new System.Drawing.Size(140, 23);
		this.bunifuFlatButton4.TabIndex = 1205;
		this.bunifuFlatButton4.Text = " OpenTicket";
		this.bunifuFlatButton4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.bunifuFlatButton4.Textcolor = System.Drawing.Color.White;
		this.bunifuFlatButton4.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bunifuFlatButton4.Click += new System.EventHandler(bunifuFlatButton5_Click);
		this.bunifuFlatButton3.Activecolor = System.Drawing.Color.FromArgb(46, 139, 87);
		this.bunifuFlatButton3.BackColor = System.Drawing.Color.FromArgb(46, 139, 87);
		this.bunifuFlatButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.bunifuFlatButton3.BorderRadius = 0;
		this.bunifuFlatButton3.ButtonText = "   New Ticket";
		this.bunifuFlatButton3.Cursor = System.Windows.Forms.Cursors.Hand;
		this.bunifuTransition_0.SetDecoration(this.bunifuFlatButton3, BunifuAnimatorNS.DecorationType.None);
		this.bunifuFlatButton3.DisabledColor = System.Drawing.Color.Gray;
		this.bunifuFlatButton3.Iconcolor = System.Drawing.Color.Transparent;
		this.bunifuFlatButton3.Iconimage = null;
		this.bunifuFlatButton3.Iconimage_right = null;
		this.bunifuFlatButton3.Iconimage_right_Selected = null;
		this.bunifuFlatButton3.Iconimage_Selected = null;
		this.bunifuFlatButton3.IconMarginLeft = 0;
		this.bunifuFlatButton3.IconMarginRight = 0;
		this.bunifuFlatButton3.IconRightVisible = true;
		this.bunifuFlatButton3.IconRightZoom = 0.0;
		this.bunifuFlatButton3.IconVisible = true;
		this.bunifuFlatButton3.IconZoom = 90.0;
		this.bunifuFlatButton3.IsTab = false;
		this.bunifuFlatButton3.Location = new System.Drawing.Point(146, 3);
		this.bunifuFlatButton3.Margin = new System.Windows.Forms.Padding(5);
		this.bunifuFlatButton3.Name = "bunifuFlatButton3";
		this.bunifuFlatButton3.Normalcolor = System.Drawing.Color.FromArgb(46, 139, 87);
		this.bunifuFlatButton3.OnHovercolor = System.Drawing.Color.FromArgb(36, 129, 77);
		this.bunifuFlatButton3.OnHoverTextColor = System.Drawing.Color.White;
		this.bunifuFlatButton3.selected = false;
		this.bunifuFlatButton3.Size = new System.Drawing.Size(140, 23);
		this.bunifuFlatButton3.TabIndex = 1204;
		this.bunifuFlatButton3.Text = "   New Ticket";
		this.bunifuFlatButton3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.bunifuFlatButton3.Textcolor = System.Drawing.Color.White;
		this.bunifuFlatButton3.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.bunifuFlatButton3.Click += new System.EventHandler(BunifuFlatButton3_Click);
		this.bunifuCustomLabel3.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.bunifuCustomLabel3.AutoSize = true;
		this.bunifuCustomLabel3.BackColor = System.Drawing.Color.Transparent;
		this.bunifuTransition_0.SetDecoration(this.bunifuCustomLabel3, BunifuAnimatorNS.DecorationType.None);
		this.bunifuCustomLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14f, System.Drawing.FontStyle.Bold);
		this.bunifuCustomLabel3.ForeColor = System.Drawing.Color.Green;
		this.bunifuCustomLabel3.Location = new System.Drawing.Point(466, 0);
		this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
		this.bunifuCustomLabel3.Size = new System.Drawing.Size(86, 24);
		this.bunifuCustomLabel3.TabIndex = 1219;
		this.bunifuCustomLabel3.Text = "Recived";
		this.bunifuCustomLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.bunifuCustomLabel4.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.bunifuCustomLabel4.AutoSize = true;
		this.bunifuCustomLabel4.BackColor = System.Drawing.Color.Transparent;
		this.bunifuTransition_0.SetDecoration(this.bunifuCustomLabel4, BunifuAnimatorNS.DecorationType.None);
		this.bunifuCustomLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14f);
		this.bunifuCustomLabel4.ForeColor = System.Drawing.Color.White;
		this.bunifuCustomLabel4.Location = new System.Drawing.Point(378, -1);
		this.bunifuCustomLabel4.Name = "bunifuCustomLabel4";
		this.bunifuCustomLabel4.Size = new System.Drawing.Size(93, 24);
		this.bunifuCustomLabel4.TabIndex = 1218;
		this.bunifuCustomLabel4.Text = "Payment :";
		this.bunifuCustomLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.panel1.BackColor = System.Drawing.Color.MediumSlateBlue;
		this.panel1.Controls.Add(this.lbl_Date);
		this.panel1.Controls.Add(this.label50);
		this.panel1.Controls.Add(this.btnClose);
		this.panel1.Controls.Add(this.bunifuCustomLabel3);
		this.panel1.Controls.Add(this.bunifuCustomLabel4);
		this.bunifuTransition_0.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
		this.panel1.ForeColor = System.Drawing.Color.FromArgb(17, 17, 18);
		this.panel1.Location = new System.Drawing.Point(-3, 0);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(582, 23);
		this.panel1.TabIndex = 1212;
		this.lbl_Date.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.lbl_Date.AutoSize = true;
		this.lbl_Date.BackColor = System.Drawing.Color.Transparent;
		this.bunifuTransition_0.SetDecoration(this.lbl_Date, BunifuAnimatorNS.DecorationType.None);
		this.lbl_Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lbl_Date.ForeColor = System.Drawing.Color.Black;
		this.lbl_Date.Location = new System.Drawing.Point(195, 178);
		this.lbl_Date.Name = "lbl_Date";
		this.lbl_Date.Size = new System.Drawing.Size(177, 24);
		this.lbl_Date.TabIndex = 169;
		this.lbl_Date.Text = "22-09-2022 22:23:55";
		this.lbl_Date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
		this.btnClose.Location = new System.Drawing.Point(557, 0);
		this.btnClose.Margin = new System.Windows.Forms.Padding(2);
		this.btnClose.Name = "btnClose";
		this.btnClose.Size = new System.Drawing.Size(23, 23);
		this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.btnClose.TabIndex = 1;
		this.btnClose.TabStop = false;
		this.btnClose.Zoom = 10;
		this.btnClose.Click += new System.EventHandler(btnClose_Click);
		this.bunifuDragControl_0.Fixed = true;
		this.bunifuDragControl_0.Horizontal = true;
		this.bunifuDragControl_0.TargetControl = this.pnlHeader;
		this.bunifuDragControl_0.Vertical = true;
		this.imageList_0.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
		this.imageList_0.ImageSize = new System.Drawing.Size(16, 16);
		this.imageList_0.TransparentColor = System.Drawing.Color.Transparent;
		this.bunifuTransition_1.AnimationType = BunifuAnimatorNS.AnimationType.HorizSlide;
		this.bunifuTransition_1.Cursor = null;
		animation2.AnimateOnlyDifferences = true;
		animation2.BlindCoeff = (System.Drawing.PointF)resources.GetObject("animation4.BlindCoeff");
		animation2.LeafCoeff = 0f;
		animation2.MaxTime = 1f;
		animation2.MinTime = 0f;
		animation2.MosaicCoeff = (System.Drawing.PointF)resources.GetObject("animation4.MosaicCoeff");
		animation2.MosaicShift = (System.Drawing.PointF)resources.GetObject("animation4.MosaicShift");
		animation2.MosaicSize = 0;
		animation2.Padding = new System.Windows.Forms.Padding(0);
		animation2.RotateCoeff = 0f;
		animation2.RotateLimit = 0f;
		animation2.ScaleCoeff = (System.Drawing.PointF)resources.GetObject("animation4.ScaleCoeff");
		animation2.SlideCoeff = (System.Drawing.PointF)resources.GetObject("animation4.SlideCoeff");
		animation2.TimeCoeff = 0f;
		animation2.TransparencyCoeff = 0f;
		this.bunifuTransition_1.DefaultAnimation = animation2;
		this.timer_0.Interval = 1000;
		this.timer_0.Tick += new System.EventHandler(timer_0_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(255, 192, 255);
		base.ClientSize = new System.Drawing.Size(579, 140);
		base.Controls.Add(this.pnlHeader);
		base.Controls.Add(this.C3AA0);
		base.Controls.Add(this.lblUsrMsg);
		base.Controls.Add(this.panel1);
		this.bunifuTransition_1.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
		this.bunifuTransition_0.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.KeyPreview = true;
		base.MaximizeBox = false;
		this.MinimumSize = new System.Drawing.Size(10, 3);
		base.Name = "frmMain";
		base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
		this.Text = "Hitman";
		base.TopMost = true;
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(frmMain_FormClosing);
		base.Load += new System.EventHandler(frmMain_Load);
		base.KeyDown += new System.Windows.Forms.KeyEventHandler(frmMain_KeyDown);
		this.pnlHeader.ResumeLayout(false);
		this.pnlHeader.PerformLayout();
		this.menuStrip1.ResumeLayout(false);
		this.menuStrip1.PerformLayout();
		this.panel1.ResumeLayout(false);
		this.panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.btnClose).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private void pnlHeader_Paint(object sender, PaintEventArgs e)
	{
	}

	private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
	{
		new frmCombine().ShowDialog();
	}

	private void bunifuFlatButton8_Click_1(object sender, EventArgs e)
	{
		new frmBackup(base.Icon).ShowDialog();
	}

	private void checkBox1_CheckedChanged(object sender, EventArgs e)
	{
		if (checkBox1.Checked)
		{
			StatClass.VideoMode = true;
		}
		else
		{
			StatClass.VideoMode = false;
		}
	}

	private void checkBox2_CheckedChanged(object sender, EventArgs e)
	{
		Program.mySettings_0.CloseOnPnr = false;
		StatClass.CloseOnPnr = Program.mySettings_0.CloseOnPnr;
		checkBox2.Checked = !checkBox2.Checked;
		if (checkBox2.Checked)
		{
			Program.mySettings_0.CloseOnPnr = true;
			StatClass.CloseOnPnr = Program.mySettings_0.CloseOnPnr;
		}
	}

	private void bunifuImageButton1_Click(object sender, EventArgs e)
	{
	}

	private void checkBox3_CheckedChanged(object sender, EventArgs e)
	{
		if (!isUpdating)
		{
			isUpdating = true;
			if (checkBox3.Checked)
			{
				chkADV.Checked = false;
			}
			checkBox5.Checked = false;
			StatClass.operalogin = !checkBox3.Checked;
			isUpdating = false;
		}
	}

	private void checkBox4_CheckedChanged(object sender, EventArgs e)
	{
		if (checkBox4.Checked)
		{
			StatClass.manualclick = true;
		}
		else
		{
			StatClass.manualclick = false;
		}
	}

	private void checkBox5_CheckedChanged(object sender, EventArgs e)
	{
		if (!isUpdating)
		{
			isUpdating = true;
			if (checkBox5.Checked)
			{
				chkADV.Checked = false;
			}
			checkBox3.Checked = false;
			StatClass.operalogin = false;
			StatClass.cometlogin = checkBox5.Checked;
			isUpdating = false;
		}
	}

	private void checkBox6_CheckedChanged(object sender, EventArgs e)
	{
		if (!isUpdating1)
		{
			isUpdating1 = true;
			if (checkBox6.Checked)
			{
				checkBox7.Checked = false;
			}
			StatClass.app1 = checkBox6.Checked;
			isUpdating1 = false;
		}
	}

	private void checkBox7_CheckedChanged(object sender, EventArgs e)
	{
		if (!isUpdating1)
		{
			isUpdating1 = true;
			if (checkBox7.Checked)
			{
				checkBox6.Checked = false;
			}
			StatClass.app1 = checkBox6.Checked;
			isUpdating1 = false;
		}
	}

	private void checkBox8_CheckedChanged(object sender, EventArgs e)
	{
		if (checkBox8.Checked)
		{
			StatClass.directlogin = checkBox8.Checked;
		}
		else
		{
			StatClass.directlogin = false;
		}
	}

	private void checkBox9_CheckedChanged(object sender, EventArgs e)
	{
		if (checkBox9.Checked)
		{
			StatClass.unverifiedbook = true;
		}
		else
		{
			StatClass.unverifiedbook = false;
		}
	}

	public static string smethod_000(string string_1)
	{
		string text = "";
		try
		{
			WebClient webClient = new WebClient();
			webClient.Proxy = null;
			webClient.Headers.Add("user-agent", "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.2.10) Gecko/20100914 Firefox/3.6.10 ( .NET CLR 3.5.30729; .NET4.0C)");
			return webClient.DownloadString(string_1);
		}
		catch (Exception)
		{
			return "";
		}
	}

	private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		string text = "https://hitmanxx.com/Hitman/ResetKey.php?";
		string text2 = "Id=" + Program.clientID + "&Mac=" + Program.mac;
		string text3 = smethod_000(text + text2);
		if (text3.Contains("Success"))
		{
			Application.Exit();
			Environment.Exit(0);
		}
	}

	private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
	}

	private void checkBox10_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void checkBox10_CheckedChanged_1(object sender, EventArgs e)
	{
		if (checkBox10.Checked)
		{
			StatClass.stopipblocknew = checkBox8.Checked;
		}
		else
		{
			StatClass.stopipblocknew = false;
		}
	}
}
