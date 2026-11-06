using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace APP_FRAMEWORK;

internal class tabSbiSetting : UserControl
{
	public delegate void agr1(string st);

	internal bool Logged_In;

	internal int Bnk;

	internal int onetime;

	private CookieContainer cookieContainer_0;

	private Dictionary<string, string> dictionary_0;

	internal string string_1;

	internal string string_2;

	internal string string_3;

	internal string string_4;

	internal string string_5;

	internal string string_6;

	internal string Brwpath;

	internal string string_7;

	internal string string_8;

	internal string string_9;

	internal string string_10;

	internal string string_12;

	internal string string_13;

	internal string string_14;

	internal string string_15;

	private static RijndaelManaged rijndaelManaged_0;

	public static string string_20;

	public static string string_21;

	public static string string_22;

	public static string string_23;

	public static string string_24;

	private GroupBox groupBox1;

	private ProgressBar progressBar1;

	public WebBrowser webBrowser;

	private GroupBox PassOtpGroupBx1;

	private Label lblSelect;

	private TextBox txtOTP1;

	internal Button btnSubmit1;

	private Label lblOTP;

	internal Button btnNew1;

	private Label lblCreate;

	internal Button btnBrowse1;

	private Label lblTime;

	public Button button1;

	private ComboBox cmbBanks1;

	private GroupBox GetOtpGroupBx1;

	private TextBox RndmNo;

	private Label label1;

	private RadioButton rdLadies;

	private RadioButton rdGeneral;

	private GroupBox groupBox2;

	private Label label3;

	private TextBox textShowOtp4;

	private Button btnDeregs;

	private TextBox textShowOtp1;

	private Button btnGenrte1;

	private System.Windows.Forms.Timer timer_0;

	private Label lblStatus1;

	private Label label7;

	private Button button2;

	private IContainer components;

	private Label label2;

	public tabSbiSetting()
	{
		InitializeComponent();
	}

	private void tabSbiSetting_Load(object sender, EventArgs e)
	{
		dictionary_0 = new Dictionary<string, string>();
		onetime = 0;
		string_1 = "";
		string_2 = "";
		string_3 = "";
		string_4 = "";
		string_5 = "";
		string_6 = "";
		string_7 = "";
		string_8 = "";
		string_9 = "";
		string_10 = "";
		string_14 = "";
		string_15 = "";
		Brwpath = "";
		Bnk = 0;
		method_0();
	}

	private void method_0()
	{
		new DataTable();
		cmbBanks1.Items.Clear();
		ComboBox.ObjectCollection items = cmbBanks1.Items;
		string item = "Select Bank Account";
		items.Add(item);
		cmbBanks1.SelectedIndex = 0;
	}

	private void method_2(string string_0)
	{
		try
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.AddExtension = false;
			openFileDialog.CheckFileExists = true;
			openFileDialog.CheckPathExists = true;
			string filter = "ByPass File|*.rg";
			openFileDialog.Filter = filter;
			string startupPath = Program.StartupPath;
			string text = "\\";
			openFileDialog.InitialDirectory = startupPath + text + string_0;
			openFileDialog.Multiselect = false;
			string title = "Select SBI BY-Pass File.";
			openFileDialog.Title = title;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				string fileName = openFileDialog.FileName;
				openFileDialog.Dispose();
				method_3(fileName);
			}
		}
		catch (Exception ex)
		{
			string text2 = " OTPByPass: btnBrowse_Click";
			Class28.smethod_26(string_0 + text2, ex.Message);
			string text3 = "Error occured while processing request!";
			string caption = "Error";
			MessageBox.Show(text3, caption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void method_3(string string_0)
	{
		try
		{
			using FileStream stream_ = new FileStream(string_0, FileMode.Open, FileAccess.Read);
			using MemoryStream memoryStream = new MemoryStream();
			smethod_3(stream_, memoryStream);
			string @string = Encoding.ASCII.GetString(memoryStream.ToArray());
			string oldValue = "?";
			string text = @string.Replace(oldValue, "");
			string oldValue2 = "\v";
			string text2 = text.Replace(oldValue2, "");
			string oldValue3 = "\0";
			string_1 = text2.Replace(oldValue3, "");
			string text3 = string_1;
			string value = "\0m";
			if (text3.Contains(value))
			{
				string text4 = string_1;
				string text5 = string_1;
				string value2 = "m";
				string_1 = text4.Substring(text5.IndexOf(value2) + 1);
			}
			string text6 = string_2;
			string text7 = string_2;
			string value3 = "_";
			string text8 = text6.Substring(text7.IndexOf(value3) + 1);
			string_1 = string_1.Substring(string_1.IndexOf(text8)).Trim();
			string text9 = string_1;
			string text10 = "||";
			if (!text9.Contains(text8 + text10))
			{
				string text11 = "Selected By-Pass file is not belongs to Selected SBI User, Please select right file.";
				string caption = "User not Match";
				MessageBox.Show(text11, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			string text12 = string_1;
			string text13 = string_3;
			string text14 = "||";
			if (!text12.Contains(text13 + text14))
			{
				string text15 = "Password Worng Updated, Please select right file.";
				string caption2 = "User-Password not Match";
				MessageBox.Show(text15, caption2, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			SQLiteConnection sQLiteConnection = new SQLiteConnection(Class34.string_Database);
			SQLiteCommand sQLiteCommand = new SQLiteCommand();
			sQLiteConnection.Open();
			sQLiteCommand.Connection = sQLiteConnection;
			string[] array = new string[5];
			string text16 = "UPDATE [TBL_BANK] SET [BANK_DETAILS] = '";
			array[0] = text16;
			array[1] = string_1;
			string text17 = "' WHERE [BANK_SAVEAS] = '";
			array[2] = text17;
			array[3] = string_2;
			string text18 = "'";
			array[4] = text18;
			sQLiteCommand.CommandText = string.Concat(array);
			sQLiteCommand.ExecuteNonQuery();
			sQLiteConnection.Close();
			sQLiteCommand.Dispose();
			string text19 = "By-Pass Updated successfully, You can use now.";
			string caption3 = "By-Passed";
			MessageBox.Show(text19, caption3, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			StatClass.method_36();
		}
		catch (Exception)
		{
			string text20 = "Error Found while Restoring Data!";
			string caption4 = "Error";
			MessageBox.Show(text20, caption4, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void method_4(string string_0)
	{
		string text = "./";
		string text2 = text + string_0;
		if (!Directory.Exists(text2))
		{
			Directory.CreateDirectory(text2);
		}
		string text3 = "\\";
		string text4 = string_4;
		string text5 = ".rg";
		using (FileStream fileStream = new FileStream(text2 + text3 + text4 + text5, FileMode.Create, FileAccess.ReadWrite))
		{
			using MemoryStream memoryStream = new MemoryStream();
			new BinaryFormatter().Serialize(memoryStream, string_1);
			memoryStream.Seek(0L, SeekOrigin.Begin);
			smethod_1(memoryStream, fileStream);
			fileStream.Close();
		}
		StatClass.method_36();
	}

	private void method_5(string string_0)
	{
		try
		{
			SQLiteConnection sQLiteConnection = new SQLiteConnection(Class34.string_Database);
			SQLiteCommand sQLiteCommand = new SQLiteCommand();
			sQLiteConnection.Open();
			sQLiteCommand.Connection = sQLiteConnection;
			string[] array = new string[5];
			string text = "UPDATE [TBL_BANK] SET [BANK_DETAILS] = '";
			array[0] = text;
			array[1] = string_1;
			string text2 = "' WHERE [BANK_SAVEAS] = '";
			array[2] = text2;
			array[3] = string_2;
			string text3 = "'";
			array[4] = text3;
			sQLiteCommand.CommandText = string.Concat(array);
			sQLiteCommand.ExecuteNonQuery();
			sQLiteConnection.Close();
			sQLiteCommand.Dispose();
			method_4(string_0);
			string text4 = "BANK BY-PASSED SUCCESFULLY.\r\n\r\nBy-Pass Updated successfully, You can use Now.\r\n\rPlease delete all the Tickets having ";
			string text5 = " Bank A/c.";
			string text6 = text4 + string_0 + text5;
			string text7 = " BY-PASSED";
			MessageBox.Show(text6, string_0 + text7, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		catch (Exception)
		{
			string text8 = "Error occured while processing request!";
			string caption = "Error";
			MessageBox.Show(text8, caption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void cmbBanks1_SelectedIndexChanged(object sender, EventArgs e)
	{
		PassOtpGroupBx1.Visible = false;
		GetOtpGroupBx1.Visible = false;
		if (cmbBanks1.SelectedIndex > 0)
		{
			string_2 = cmbBanks1.SelectedItem.ToString();
			string_3 = dictionary_0[string_2];
			string text = string_3;
			string[] array = new string[1];
			string text2 = "||";
			array[0] = text2;
			string[] array2 = text.Split(array, StringSplitOptions.None);
			string_4 = array2[0].Trim();
			string_5 = array2[1];
			string_6 = array2[2];
			string text3 = "./SBI";
			string text4 = text3;
			if (!Directory.Exists(text4))
			{
				Directory.CreateDirectory(text4);
			}
			string text5 = "\\";
			string text6 = string_4;
			string text7 = ".rg";
			Brwpath = text4 + text5 + text6 + text7;
			if (array2.Length <= 3)
			{
				PassOtpGroupBx1.Visible = true;
				if (File.Exists(Brwpath))
				{
					lblCreate.Visible = true;
					lblSelect.Visible = true;
					btnBrowse1.Visible = true;
				}
				return;
			}
			if (StClass.classSBI_0 == null)
			{
				StClass.classSBI_0 = new SBISecureLogin_OTP_Deregister();
			}
			string text8 = "OTP is already By-Passed for ";
			string text9 = string_2;
			string text10 = "\r\n\r\nIf you want to setup again then Delete the bank and Add again.";
			string text11 = text8 + text9 + text10;
			string caption = "Already By-Passed";
			MessageBox.Show(text11, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			GetOtpGroupBx1.Visible = true;
			string_7 = array2[3];
			string_8 = array2[4];
			string_9 = array2[5];
			string_10 = array2[6];
		}
		else
		{
			string_2 = "";
			string_3 = "";
		}
	}

	private void btnBrowse1_Click(object sender, EventArgs e)
	{
		string string_ = "SBI";
		method_2(string_);
	}

	private void btnNew1_Click(object sender, EventArgs e)
	{
		btnNew1.Enabled = false;
		string text = string_3;
		string[] array = new string[1];
		string text2 = "||";
		array[0] = text2;
		string[] array2 = text.Split(array, StringSplitOptions.None);
		string_4 = array2[0].Trim();
		string_5 = array2[1];
		string_6 = array2[2];
		string text3 = "./SBI\\";
		string text4 = string_4;
		string text5 = ".rg";
		string text6 = text3 + text4 + text5;
		if (File.Exists(text6))
		{
			string text7 = "Existing OTP file found! Do you want to use that file?\r\n\r\nClick YES to use found file or Click NO to create New File.";
			string caption = "OTP File Found";
			if (MessageBox.Show(text7, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				method_3(text6);
				return;
			}
			File.Delete(text6);
		}
		method_Bypass_1();
		btnNew1.Enabled = true;
	}

	private bool method_Bypass_1()
	{
		Application.DoEvents();
		if (!smethod_4LogOut(string_4, string_5, string_6))
		{
			Form owner = new Form
			{
				TopMost = true
			};
			string text = "Apka Profile Password Galat Ho Sakta, Please Manullay Deregistration Karen.";
			string caption = "OTP DeRegistration";
			if (MessageBox.Show(owner, text, caption, MessageBoxButtons.OKCancel) == DialogResult.Cancel)
			{
				return false;
			}
		}
		string_7 = smethod_8(ref string_8);
		WebProxy webProxy_ = null;
		string text2 = "https://midentity.onlinesbi.com/services1/SBISmartOTPCheService0/SecurityService";
		string_13 = text2;
		string text3 = string_8;
		string string_ = "";
		string string_2 = "";
		string text4 = "2.2.9";
		string text5 = text4;
		string text6 = "6.5.QA_v201904231830_r5aa";
		string text7 = text6;
		string userId = "";
		string text8 = "$652@!#*SaWeQ@";
		string text9 = text8;
		string text10 = "$*|@%$B!$E@u^#@A%!";
		string text11 = text10;
		string plnData = "{\"body\":{},\"security\":{\"appkey\":\"\",\"mpin\":\"\",\"token1\":\"\",\"token2\":\"\"}}";
		string text12 = SBISecure2_0_1.EncryptEncData(plnData, userId, text9, text11);
		string plainText = "{\"userName\":\"\",\"bankCode\":\"\",\"token\":\"\"}";
		string value = SBISecure2_0_1.Base64Encode(plainText, isUrlSafe: false);
		string request = SBISecure2_0_1.GetRequest(plnData);
		string[] array = new string[10];
		string text13 = "platform=android&encData=";
		array[0] = text13;
		array[1] = text12;
		string text14 = "&appID=OnlineOTP&requestKey=";
		array[2] = text14;
		array[3] = request;
		string text15 = "&appver=";
		array[4] = text15;
		array[5] = text5;
		string text16 = "&optionalFlagFomUI=false&header=";
		array[6] = text16;
		array[7] = WebUtility.UrlEncode(value);
		string text17 = "&channel=rc&serviceID=SecurityService&cacheid=&platformver=";
		array[8] = text17;
		array[9] = text7;
		string_12 = string.Concat(array);
		string text18 = string_13;
		string text19 = string_12;
		string text20 = "json";
		bool result;
		if (Class47.method_1(text18, text19, text3 + text20, 0, webProxy_, ref cookieContainer_0, bool_1: true, 50000, ref string_, ref string_2))
		{
			string text21 = string_;
			string value2 = "encData";
			int startIndex = text21.IndexOf(value2);
			string text22 = string_;
			string value3 = ":\"";
			int num = text22.IndexOf(value3, startIndex) + 2;
			string text23 = string_;
			string value4 = "\"";
			int length = text23.IndexOf(value4, num) - num;
			string text24 = SBISecure2_0_1.DecryptResponseEncData(string_.Substring(num, length), userId, text9, text11);
			Application.DoEvents();
			string text25 = string_;
			string value5 = "200";
			if (!text25.Contains(value5))
			{
				string value6 = "serviceId";
				if (!text24.Contains(value6))
				{
					string text26 = "CreateOTPBypass:Step1";
					Class28.smethod_26(text26, text24);
					string text27 = "Invalid Response of Step-1";
					MessageBox.Show(text27);
					result = false;
					goto IL_09d3;
				}
			}
			string value7 = "serviceId";
			int startIndex2 = text24.IndexOf(value7);
			string value8 = ":\"";
			int num2 = text24.IndexOf(value8, startIndex2) + 2;
			string value9 = "\"";
			int length2 = text24.IndexOf(value9, num2) - num2;
			string text28 = text24.Substring(num2, length2);
			string value10 = "keyId";
			int startIndex3 = text24.IndexOf(value10);
			string value11 = ":\"";
			int num3 = text24.IndexOf(value11, startIndex3) + 2;
			string value12 = "\"";
			int length3 = text24.IndexOf(value12, num3) - num3;
			string text29 = text24.Substring(num3, length3);
			string text30 = string_4;
			string text31 = "#";
			string text32 = smethod_10(text30 + text31 + string_5);
			string text33 = "#";
			string text34 = smethod_10(text32 + text33 + text29);
			string text35 = string_4;
			string text36 = "#";
			string text37 = smethod_11(text35 + text36 + string_5);
			string text38 = "#";
			string text39 = smethod_11(text37 + text38 + text29);
			string text40 = "https://midentity.onlinesbi.com/services1/SBISmartOTPCheService0/LoginValidate";
			string_13 = text40;
			string userId2 = string_4;
			string[] array2 = new string[11];
			string text41 = "{\"body\":{\"md5Password\":\"";
			array2[0] = text41;
			array2[1] = text34;
			string text42 = "\",\"shaPassword\":\"";
			array2[2] = text42;
			array2[3] = text39;
			string text43 = "\",\"serviceId\":\"";
			array2[4] = text43;
			array2[5] = text28;
			string text44 = "\",\"deviceName\":\"";
			array2[6] = text44;
			array2[7] = string_8;
			string text45 = "\",\"imeiNo\":\"";
			array2[8] = text45;
			array2[9] = string_7;
			string text46 = "\",\"osName\":\"android\"},\"security\":{\"appkey\":\"\",\"mpin\":\"\",\"token1\":\"\",\"token2\":\"\"}}";
			array2[10] = text46;
			string plnData2 = string.Concat(array2);
			string text47 = SBISecure2_0_1.EncryptEncData(plnData2, userId2, text9, text11);
			string text48 = "{\"userName\":\"";
			string text49 = string_4;
			string text50 = "\",\"bankCode\":\"0\",\"token\":\"\"}";
			string str = SBISecure2_0_1.Base64Encode(text48 + text49 + text50, isUrlSafe: false);
			string request2 = SBISecure2_0_1.GetRequest(plnData2);
			string[] array3 = new string[10];
			string text51 = "platform=android&encData=";
			array3[0] = text51;
			array3[1] = text47;
			string text52 = "&appID=OnlineOTP&requestKey=";
			array3[2] = text52;
			array3[3] = request2;
			string text53 = "&appver=";
			array3[4] = text53;
			array3[5] = text5;
			string text54 = "&jSessionId=&header=";
			array3[6] = text54;
			array3[7] = HttpUtility.UrlEncode(str);
			string text55 = "&channel=rc&serviceID=LoginValidate&cacheid=&ipAddress=&platformver=";
			array3[8] = text55;
			array3[9] = text7;
			string_12 = string.Concat(array3);
			string text56 = string_13;
			string text57 = string_12;
			string text58 = "json";
			if (!Class47.method_1(text56, text57, text3 + text58, 1, webProxy_, ref cookieContainer_0, bool_1: true, 50000, ref string_, ref string_2))
			{
				string text59 = "CreateOTPBypass:Step2";
				Class28.smethod_26(text59, string_2);
				string text60 = "Step-2 Failed";
				MessageBox.Show(text60);
				result = false;
			}
			else
			{
				Application.DoEvents();
				string text61 = string_;
				string value13 = "encData";
				int startIndex4 = text61.IndexOf(value13);
				string text62 = string_;
				string value14 = ":\"";
				int num4 = text62.IndexOf(value14, startIndex4) + 2;
				string text63 = string_;
				string value15 = "\"";
				int length4 = text63.IndexOf(value15, num4) - num4;
				string text64 = SBISecure2_0_1.DecryptResponseEncData(string_.Substring(num4, length4), userId2, text9, text11);
				string text65 = string_;
				string value16 = "200";
				if (!text65.Contains(value16))
				{
					string value17 = "true";
					if (!text64.Contains(value17))
					{
						string value18 = "uID";
						if (!text64.Contains(value18))
						{
							string text66 = "CreateOTPBypass:Step2";
							Class28.smethod_26(text66, text64);
							string text67 = "Invalid Login! Please check your User ID and Password and try again later.";
							MessageBox.Show(text67);
							result = false;
							goto IL_09d3;
						}
					}
				}
				string value19 = "jSessionId";
				int startIndex5 = text64.IndexOf(value19);
				string value20 = ":\"";
				int num5 = text64.IndexOf(value20, startIndex5) + 2;
				string value21 = "\"";
				int length5 = text64.IndexOf(value21, num5) - num5;
				string_14 = text64.Substring(num5, length5);
				string value22 = "uId";
				int startIndex6 = text64.IndexOf(value22);
				string value23 = ":\"";
				int num6 = text64.IndexOf(value23, startIndex6) + 2;
				string value24 = "\"";
				int length6 = text64.IndexOf(value24, num6) - num6;
				string_15 = text64.Substring(num6, length6);
				string text68 = "https://midentity.onlinesbi.com/services1/SBISmartOTPCheService0/EnableHighSecurityService";
				string_13 = text68;
				string[] array4 = new string[11];
				string text69 = "{\"body\":{\"ipAddress\":\"";
				array4[0] = text69;
				array4[1] = string_14;
				string text70 = "\"},\"security\":{\"appkey\":\"";
				array4[2] = text70;
				array4[3] = text11;
				string text71 = "\",\"mpin\":\"";
				array4[4] = text71;
				array4[5] = text9;
				string text72 = "\",\"token1\":\"";
				array4[6] = text72;
				array4[7] = string_14;
				string text73 = "\",\"token2\":\"";
				array4[8] = text73;
				array4[9] = string_15;
				string text74 = "\"}}";
				array4[10] = text74;
				string plnData3 = string.Concat(array4);
				string text75 = SBISecure2_0_1.EncryptEncData(plnData3, userId2, text9, text11);
				string text76 = "{\"userName\":\"";
				string text77 = string_4;
				string text78 = "\",\"bankCode\":\"0\",\"token\":\"\"}";
				string str2 = SBISecure2_0_1.Base64Encode(text76 + text77 + text78, isUrlSafe: false);
				string request3 = SBISecure2_0_1.GetRequest(plnData3);
				string[] array5 = new string[10];
				string text79 = "platform=android&encData=";
				array5[0] = text79;
				array5[1] = text75;
				string text80 = "&appID=OnlineOTP&requestKey=";
				array5[2] = text80;
				array5[3] = request3;
				string text81 = "&appver=";
				array5[4] = text81;
				array5[5] = text5;
				string text82 = "&header=";
				array5[6] = text82;
				array5[7] = HttpUtility.UrlEncode(str2);
				string text83 = "&channel=rc&serviceID=EnableHighSecurityService&cacheid=&platformver=";
				array5[8] = text83;
				array5[9] = text7;
				string_12 = string.Concat(array5);
				string text84 = string_13;
				string text85 = string_12;
				string text86 = "json";
				if (Class47.method_1(text84, text85, text3 + text86, 1, webProxy_, ref cookieContainer_0, bool_1: true, 50000, ref string_, ref string_2))
				{
					Application.DoEvents();
					string text87 = string_;
					string value25 = "encData";
					int startIndex7 = text87.IndexOf(value25);
					string text88 = string_;
					string value26 = ":\"";
					int num7 = text88.IndexOf(value26, startIndex7) + 2;
					string text89 = string_;
					string value27 = "\"";
					int length7 = text89.IndexOf(value27, num7) - num7;
					string text90 = SBISecure2_0_1.DecryptResponseEncData(string_.Substring(num7, length7), userId2, text9, text11);
					string text91 = string_;
					string value28 = "200";
					if (!text91.Contains(value28))
					{
						string value29 = "Success";
						if (!text90.Contains(value29))
						{
							string text92 = "CreateOTPBypass:Step3";
							Class28.smethod_26(text92, string_);
							string text93 = "Invalid Step-3!";
							MessageBox.Show(text93);
							result = false;
							goto IL_09d3;
						}
					}
					txtOTP1.Visible = true;
					btnSubmit1.Visible = true;
					txtOTP1.Focus();
					string text94 = "Success! Please provide OTP from your Mobile.\r\n\r\nIf you don't receive OTP in 5 minutes, Then change 'Mode of Authentication through OTP' to SMS in your SBI Profile Section.";
					string caption2 = "OTP";
					MessageBox.Show(text94, caption2, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					result = true;
				}
				else
				{
					string text95 = "CreateOTPBypass:Step3";
					Class28.smethod_26(text95, string_2);
					string text96 = "Step-3 Failed";
					MessageBox.Show(text96);
					result = false;
				}
			}
		}
		else
		{
			string text97 = "CreateOTPBypass:Step1";
			Class28.smethod_26(text97, string_2);
			string text98 = "Step-1 Failed";
			MessageBox.Show(text98);
			result = false;
		}
		goto IL_09d3;
		IL_09d3:
		return result;
	}

	private void BtnSubmit1_Click(object sender, EventArgs e)
	{
		try
		{
			bool bool_ = false;
			btnSubmit1.Enabled = false;
			if (!string.IsNullOrEmpty(txtOTP1.Text))
			{
				string_6 = txtOTP1.Text.Trim();
				if (method_6(ref bool_))
				{
					string_1 = string_3;
					string string_ = "SBI";
					method_5(string_);
					Staticm.method_36();
					cmbBanks1.SelectedIndex = 0;
					PassOtpGroupBx1.Visible = false;
					GetOtpGroupBx1.Visible = false;
				}
				if (bool_)
				{
					txtOTP1.Text = null;
					btnSubmit1.Enabled = true;
					txtOTP1.Focus();
				}
			}
			else
			{
				string text = "Enter OTP Text received on registered Mobile";
				string caption = "OTP";
				MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		catch (Exception ex)
		{
			lblOTP.Visible = false;
			txtOTP1.Visible = false;
			btnSubmit1.Visible = false;
			string text2 = "SBIOTPByPass: btnSubmit_Click";
			Class28.smethod_26(text2, ex.Message);
			string text3 = "Error occured while processing request!";
			string caption2 = "Error";
			MessageBox.Show(text3, caption2, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		finally
		{
			btnSubmit1.Enabled = true;
		}
	}

	public static string Base64Encode(string plainText)
	{
		return Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
	}

	private bool method_6(ref bool bool_0)
	{
		WebProxy webProxy_ = null;
		string text = "https://midentity.onlinesbi.com/services1/SBISmartOTPCheService0/EnableHighSecurityConfirmService";
		string_13 = text;
		string string_ = "";
		string string_2 = "";
		string text2 = "2.2.9";
		string text3 = text2;
		string text4 = "6.5.QA_v201904231830_r5aa";
		string text5 = text4;
		string userId = string_4;
		string text6 = "$652@!#*SaWeQ@";
		string text7 = text6;
		string text8 = "$*|@%$B!$E@u^#@A%!";
		string text9 = text8;
		string[] array = new string[13];
		string text10 = "{\"body\":{\"deviceId\":\"";
		array[0] = text10;
		array[1] = string_7;
		string text11 = "\",\"otp\":\"";
		array[2] = text11;
		array[3] = string_6;
		string text12 = "\"},\"security\":{\"appkey\":\"";
		array[4] = text12;
		array[5] = text9;
		string text13 = "\",\"mpin\":\"";
		array[6] = text13;
		array[7] = text7;
		string text14 = "\",\"token1\":\"";
		array[8] = text14;
		array[9] = string_14;
		string text15 = "\",\"token2\":\"";
		array[10] = text15;
		array[11] = string_15;
		string text16 = "\"}}";
		array[12] = text16;
		string plnData = string.Concat(array);
		string text17 = SBISecure2_0_1.EncryptEncData(plnData, userId, text7, text9);
		string text18 = "{\"userName\":\"";
		string text19 = string_4;
		string text20 = "\",\"bankCode\":\"0\",\"token\":\"\"}";
		string str = Base64Encode(text18 + text19 + text20);
		string request = SBISecure2_0_1.GetRequest(plnData);
		string[] array2 = new string[10];
		string text21 = "platform=android&encData=";
		array2[0] = text21;
		array2[1] = text17;
		string text22 = "&appID=OnlineOTP&requestKey=";
		array2[2] = text22;
		array2[3] = request;
		string text23 = "&appver=";
		array2[4] = text23;
		array2[5] = text3;
		string text24 = "&header=";
		array2[6] = text24;
		array2[7] = HttpUtility.UrlEncode(str);
		string text25 = "&channel=rc&serviceID=EnableHighSecurityConfirmService&cacheid=&platformver=";
		array2[8] = text25;
		array2[9] = text5;
		string_12 = string.Concat(array2);
		string text26 = string_8;
		string text27 = string_13;
		string text28 = string_12;
		string text29 = "json";
		if (!Class47.method_1(text27, text28, text26 + text29, 1, webProxy_, ref cookieContainer_0, bool_1: true, 50000, ref string_, ref string_2))
		{
			string text30 = "OTP Submit Failed";
			MessageBox.Show(text30);
			return false;
		}
		string text31 = string_;
		string value = "encData";
		int startIndex = text31.IndexOf(value);
		string text32 = string_;
		string value2 = ":\"";
		int num = text32.IndexOf(value2, startIndex) + 2;
		string text33 = string_;
		string value3 = "\"";
		int length = text33.IndexOf(value3, num) - num;
		string text34 = SBISecure2_0_1.DecryptResponseEncData(string_.Substring(num, length), userId, text7, text9);
		string value4 = "wrongOTPFlag";
		if (!text34.Contains(value4))
		{
			string value5 = "securityKey";
			int startIndex2 = text34.IndexOf(value5);
			string value6 = ":\"";
			int num2 = text34.IndexOf(value6, startIndex2) + 2;
			string value7 = "\"";
			int length2 = text34.IndexOf(value7, num2) - num2;
			string text35 = text34.Substring(num2, length2);
			string value8 = "mobAppKey";
			int startIndex3 = text34.IndexOf(value8);
			string value9 = ":\"";
			int num3 = text34.IndexOf(value9, startIndex3) + 2;
			string value10 = "\"";
			int length3 = text34.IndexOf(value10, num3) - num3;
			string text36 = text34.Substring(num3, length3);
			string text37 = "What is your pet name?";
			string text38 = text37;
			string text39 = "dog";
			string text40 = text39;
			string text41 = "9413";
			string text42 = text41;
			string text43 = "https://midentity.onlinesbi.com/services1/SBISmartOTPCheService0/QuestionSubmitService";
			string_13 = text43;
			string text44 = string_4;
			string text45 = "~";
			string text46 = smethod_11(text44 + text45 + text42);
			string[] array3 = new string[19];
			string text47 = "{\"body\":{\"deviceId\":\"";
			array3[0] = text47;
			array3[1] = string_7;
			string text48 = "\",\"securityKey\":\"";
			array3[2] = text48;
			array3[3] = text35;
			string text49 = "\",\"question\":\"";
			array3[4] = text49;
			array3[5] = text38;
			string text50 = "\",\"answer\":\"";
			array3[6] = text50;
			array3[7] = text40;
			string text51 = "\",\"shaMpin\":\"";
			array3[8] = text51;
			array3[9] = text46;
			string text52 = "\"},\"security\":{\"appkey\":\"";
			array3[10] = text52;
			array3[11] = text36;
			string text53 = "\",\"mpin\":\"";
			array3[12] = text53;
			array3[13] = string_7;
			string text54 = "\",\"token1\":\"";
			array3[14] = text54;
			array3[15] = string_14;
			string text55 = "\",\"token2\":\"";
			array3[16] = text55;
			array3[17] = string_15;
			string text56 = "\"}}";
			array3[18] = text56;
			string plnData2 = string.Concat(array3);
			string text57 = SBISecure2_0_1.EncryptEncData(plnData2, userId, string_7, text36);
			string text58 = "{\"userName\":\"";
			string text59 = string_4;
			string text60 = "\",\"bankCode\":\"0\",\"token\":\"\"}";
			string str2 = SBISecure2_0_1.Base64Encode(text58 + text59 + text60, isUrlSafe: false);
			string request2 = SBISecure2_0_1.GetRequest(plnData2);
			string[] array4 = new string[10];
			string text61 = "platform=android&encData=";
			array4[0] = text61;
			array4[1] = text57;
			string text62 = "&appID=OnlineOTP&requestKey=";
			array4[2] = text62;
			array4[3] = request2;
			string text63 = "&appver=";
			array4[4] = text63;
			array4[5] = text3;
			string text64 = "&jSessionId=&header=";
			array4[6] = text64;
			array4[7] = HttpUtility.UrlEncode(str2);
			string text65 = "&channel=rc&serviceID=QuestionSubmitService&cacheid=&ipAddress=&platformver=";
			array4[8] = text65;
			array4[9] = text5;
			string_12 = string.Concat(array4);
			string text66 = string_13;
			string text67 = string_12;
			string text68 = "json";
			if (Class47.method_1(text66, text67, text26 + text68, 1, webProxy_, ref cookieContainer_0, bool_1: true, 50000, ref string_, ref string_2))
			{
				string text69 = string_;
				string value11 = "encData";
				int startIndex4 = text69.IndexOf(value11);
				string text70 = string_;
				string value12 = ":\"";
				int num4 = text70.IndexOf(value12, startIndex4) + 2;
				string text71 = string_;
				string value13 = "\"";
				int length4 = text71.IndexOf(value13, num4) - num4;
				string text72 = SBISecure2_0_1.DecryptResponseEncData(string_.Substring(num4, length4), userId, string_7, text36);
				string value14 = "wrongOTPFlag";
				if (text72.Contains(value14))
				{
					string text73 = "Invalid OTP Submit!";
					MessageBox.Show(text73);
				}
				string[] array5 = new string[9] { string_3, null, null, null, null, null, null, null, null };
				string text74 = "||";
				array5[1] = text74;
				array5[2] = string_7;
				string text75 = "||";
				array5[3] = text75;
				array5[4] = string_8;
				string text76 = "||";
				array5[5] = text76;
				array5[6] = text36;
				string text77 = "||";
				array5[7] = text77;
				array5[8] = text35;
				string_3 = string.Concat(array5);
				return true;
			}
			string text78 = "CreateOTPBypass:Step2";
			Class28.smethod_26(text78, string_2);
			string text79 = "Step-2 Failed";
			MessageBox.Show(text79);
			return false;
		}
		string text80 = "Invalid OTP Submit! Please Fill Correct OTP Again";
		MessageBox.Show(text80);
		bool_0 = true;
		return false;
	}

	public bool smethod_4LogOut(string A, string B, string C)
	{
		return true;
	}

	private void method_7(object object_0)
	{
		textShowOtp1.Text = StClass.classSBI_0.smethod_GenrateSecureOTP(string_3);
		btnGenrte1.Enabled = true;
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
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
				if (int_1 > 0)
				{
					httpWebRequest.Timeout = int_1;
					httpWebRequest.ReadWriteTimeout = int_1;
				}
				ServicePointManager.Expect100Continue = false;
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
				string contentType = "application/json";
				httpWebRequest.ContentType = contentType;
				httpWebRequest.KeepAlive = true;
				string text2 = "Apache-HttpClient/android/";
				httpWebRequest.UserAgent = text2 + string_16;
				WebHeaderCollection headers = httpWebRequest.Headers;
				string name = "Accept-Language";
				string value = "en-US,en;q=0.9";
				headers.Set(name, value);
				WebHeaderCollection headers2 = httpWebRequest.Headers;
				string name2 = "Accept-Encoding";
				string value2 = "gzip,deflate,br";
				headers2.Set(name2, value2);
				WebHeaderCollection headers3 = httpWebRequest.Headers;
				string name3 = "X-Kony-App-Key";
				string value3 = "aaee6accb1b00d19ddf0efb0f66a393";
				headers3.Set(name3, value3);
				WebHeaderCollection headers4 = httpWebRequest.Headers;
				string name4 = "X-Kony-App-Secret";
				string value4 = "2f9b36d1f6f5c3e940cd940af1e59d4e";
				headers4.Set(name4, value4);
				WebHeaderCollection headers5 = httpWebRequest.Headers;
				string name5 = "X-Kony-Platform-Type";
				string value5 = "android";
				headers5.Set(name5, value5);
				WebHeaderCollection headers6 = httpWebRequest.Headers;
				string name6 = "X-Kony-SDK-Type";
				string value6 = "js";
				headers6.Set(name6, value6);
				WebHeaderCollection headers7 = httpWebRequest.Headers;
				string name7 = "X-Kony-SDK-Version";
				string value7 = "SDK-GA-7.3.0.38";
				headers7.Set(name7, value7);
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
				using (StreamReader textReader_ = smethod_0(httpWebResponse.GetResponseStream()))
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
				string text3 = "SBIOTPByPass: WebRequestPost";
				Class28.smethod_26(text3, string_18);
				string text4 = string_18.ToUpper();
				string value8 = "CONNECTION WAS CLOSED";
				if (!text4.Contains(value8))
				{
					string text5 = string_18.ToUpper();
					string value9 = "SERVICEUNAVAILABLE";
					text5.Contains(value9);
				}
				string text6 = string_18;
				string value10 = "The underlying connection was closed";
				text6.Contains(value10);
				string text7 = string_18;
				string value11 = "The underlying connection was closed";
				if (text7.Contains(value11) && num >= 1)
				{
					proxy = Program.PrivateProxy;
				}
				if (num < 3)
				{
					num++;
					continue;
				}
				return result = flag;
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
			int[,,] array = new int[2, 5, 1]
			{
				{
					{ -1336710976 },
					{ -1803049274 },
					{ 1013360966 },
					{ -1354973300 },
					{ 0 }
				},
				{
					{ 717744287 },
					{ -1517382199 },
					{ -388970573 },
					{ 665393690 },
					{ 716362583 }
				}
			};
			switch (-(array[1, 4, 0] * 319305625))
			{
			default:
				return result;
			case 1:
				return flag;
			case 2:
				break;
			}
		}
	}

	private static StreamReader smethod_0(Stream stream_0)
	{
		return new StreamReader(stream_0);
	}

	private static string smethod_4(TextReader textReader_0)
	{
		return textReader_0.ReadToEnd();
	}

	private static void smethod_5()
	{
		rijndaelManaged_0 = new RijndaelManaged();
		string password = "/8520*96ASqw";
		Encoding aSCII = Encoding.ASCII;
		string s = "MY*SECRET*KEY+-";
		Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, aSCII.GetBytes(s));
		rijndaelManaged_0.Key = rfc2898DeriveBytes.GetBytes(rijndaelManaged_0.KeySize / 8);
		rijndaelManaged_0.IV = rfc2898DeriveBytes.GetBytes(rijndaelManaged_0.BlockSize / 8);
		rijndaelManaged_0.Padding = PaddingMode.PKCS7;
	}

	public static void smethod_1(Stream stream_0, Stream stream_1)
	{
		smethod_5();
		ICryptoTransform transform = rijndaelManaged_0.CreateEncryptor();
		stream_0.Position = 0L;
		CryptoStream cryptoStream = new CryptoStream(stream_1, transform, CryptoStreamMode.Write);
		smethod_2(stream_0, cryptoStream);
		cryptoStream.FlushFinalBlock();
	}

	public static void smethod_2(Stream stream_0, Stream stream_1)
	{
		byte[] array = new byte[16384];
		int count;
		while ((count = stream_0.Read(array, 0, array.Length)) > 0)
		{
			stream_1.Write(array, 0, count);
		}
	}

	public static void smethod_3(Stream stream_0, Stream stream_1)
	{
		smethod_5();
		ICryptoTransform transform = rijndaelManaged_0.CreateDecryptor();
		stream_0.Position = 0L;
		smethod_2(new CryptoStream(stream_0, transform, CryptoStreamMode.Read), stream_1);
		stream_1.Position = 0L;
	}

	internal static string smethod_6()
	{
		double result = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
		string text = result.ToString();
		string oldValue = ".";
		string text2 = text.Replace(oldValue, "");
		double.TryParse(text2.Substring(0, text2.Length - 2), out result);
		string text3 = "E11";
		string text4 = result.ToString(text3);
		string oldValue2 = "+0";
		return text4.Replace(oldValue2, "");
	}

	internal static string smethod_7(int int_0)
	{
		Random random = new Random((int)DateTime.Now.Ticks);
		byte[] array = new byte[int_0 / 2];
		random.NextBytes(array);
		string text = string.Concat(array.Select(smethod_9).ToArray());
		if (int_0 % 2 == 0)
		{
			return text;
		}
		int num = random.Next(16);
		string text2 = "X";
		return text + num.ToString(text2);
	}

	private static string smethod_9(byte byte_0)
	{
		string text = "X2";
		return byte_0.ToString(text);
	}

	internal static string smethod_8(ref string string_14)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		string key = "99000310";
		string value = "Xiomi_Mi4";
		dictionary.Add(key, value);
		string key2 = "99000311";
		string value2 = "Xiomi_Mi4";
		dictionary.Add(key2, value2);
		string key3 = "91125575";
		string value3 = "Micomax_P600";
		dictionary.Add(key3, value3);
		string key4 = "35578005";
		string value4 = "Samsung_GT-S5303B";
		dictionary.Add(key4, value4);
		string key5 = "35577805";
		string value5 = "Samsung_GT-C3310R";
		dictionary.Add(key5, value5);
		string key6 = "91125680";
		string value6 = "Micromax_A88";
		dictionary.Add(key6, value6);
		string key7 = "91125635";
		string value7 = "Karbonn_A2";
		dictionary.Add(key7, value7);
		string key8 = "91125730";
		string value8 = "MAXX_MSD7Android";
		dictionary.Add(key8, value8);
		string key9 = "86023502";
		string value9 = "ZTE_ZTE_N818";
		dictionary.Add(key9, value9);
		string key10 = "86023602";
		string value10 = "ZTE_ZTE_N909";
		dictionary.Add(key10, value10);
		string key11 = "91125825";
		string value11 = "Lava_Iris351";
		dictionary.Add(key11, value11);
		string key12 = "91125945";
		string value12 = "MAXX_AX8NoteII";
		dictionary.Add(key12, value12);
		string key13 = "91125950";
		string value13 = "MAXX_MSD7Touch35";
		dictionary.Add(key13, value13);
		string key14 = "91130020";
		string value14 = "Karbonn_A3";
		dictionary.Add(key14, value14);
		string key15 = "91130025";
		string value15 = "Micromax_A91";
		dictionary.Add(key15, value15);
		string key16 = "91130050";
		string value16 = "Lava_Iris454";
		dictionary.Add(key16, value16);
		string key17 = "91130045";
		string value17 = "Xolo_X1000";
		dictionary.Add(key17, value17);
		string key18 = "86797002";
		string value18 = "Lenovo_K3 Note";
		dictionary.Add(key18, value18);
		string key19 = "91130030";
		string value19 = "LEMON_B407";
		dictionary.Add(key19, value19);
		string key20 = "91130095";
		string value20 = "iball_Andi4v";
		dictionary.Add(key20, value20);
		string key21 = "91130100";
		string value21 = "iball_Andi5l";
		dictionary.Add(key21, value21);
		string key22 = "91130150";
		string value22 = "Micromax_A112";
		dictionary.Add(key22, value22);
		string key23 = "91130135";
		string value23 = "Karbonn_A4";
		dictionary.Add(key23, value23);
		string key24 = "91130115";
		string value24 = "Spice_MI-530";
		dictionary.Add(key24, value24);
		string key25 = "91130255";
		string value25 = "Micromax_A62";
		dictionary.Add(key25, value25);
		string key26 = "91130260";
		string value26 = "Micromax_A115";
		dictionary.Add(key26, value26);
		string key27 = "35445205";
		string value27 = "LG_P880g";
		dictionary.Add(key27, value27);
		string key28 = "86824701";
		string value28 = "Lenovo_Lenovo_A520";
		dictionary.Add(key28, value28);
		string key29 = "91131045";
		string value29 = "XOLO_Q700";
		dictionary.Add(key29, value29);
		string key30 = "91125715";
		string value30 = "XOLO_B700";
		dictionary.Add(key30, value30);
		string key31 = "91125465";
		string value31 = "Xolo_A500";
		dictionary.Add(key31, value31);
		string key32 = "91125050";
		string value32 = "Xolo_A800";
		dictionary.Add(key32, value32);
		string key33 = "91124675";
		string value33 = "XOLO_A700";
		dictionary.Add(key33, value33);
		string key34 = "91124235";
		string value34 = "Micromax_A90S";
		dictionary.Add(key34, value34);
		Dictionary<string, string> dictionary2 = dictionary;
		Random random = new Random((int)DateTime.Now.Ticks);
		KeyValuePair<string, string> keyValuePair = dictionary2.ElementAt(random.Next(0, dictionary2.Count - 1));
		string text = keyValuePair.Key + random.Next(100000, 980000);
		string_14 = keyValuePair.Value.Substring(keyValuePair.Value.LastIndexOf('_') + 1);
		string_14 = keyValuePair.Value;
		while (text.Length < 14)
		{
			string text2 = text;
			string text3 = "0";
			text = text2 + text3;
		}
		int[] array = new int[14];
		for (int i = 0; i < 14; i++)
		{
			array[i] = Convert.ToInt32(text.Substring(i, 1));
			if (i % 2 != 0)
			{
				array[i] *= 2;
			}
			while (array[i] > 9)
			{
				array[i] = array[i] % 10 + array[i] / 10;
			}
		}
		int num = 0;
		int[] array2 = array;
		int[] array3 = array2;
		int[] array4 = array3;
		foreach (int num2 in array4)
		{
			num += num2;
		}
		return text + (10 - num % 10);
	}

	private void C3AA0_Click(object sender, EventArgs e)
	{
		string fileName = "https://nexus-india.com/secure/API/sbi_help.php";
		Process.Start(fileName);
	}

	private static string smethod_10(string string_0)
	{
		byte[] array = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(string_0));
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.Length; i++)
		{
			ref byte reference = ref array[i];
			string text = "x2";
			stringBuilder.Append(reference.ToString(text));
		}
		return stringBuilder.ToString();
	}

	private static string smethod_11(string string_0)
	{
		byte[] array = new SHA512Managed().ComputeHash(Encoding.UTF8.GetBytes(string_0));
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.Length; i++)
		{
			ref byte reference = ref array[i];
			string text = "x2";
			stringBuilder.Append(reference.ToString(text));
		}
		return stringBuilder.ToString();
	}

	internal static string smethod_9S(string a, string b, string string_0)
	{
		string_21 = a;
		string value = "submitLoginShagc(";
		string_23 = string_0.Substring(string_0.IndexOf(value) + 18);
		string text = string_23;
		string text2 = string_23;
		string value2 = "')";
		string_23 = text.Substring(0, text2.IndexOf(value2));
		string text3 = "<html>\n<head>\n<script type=\"text/javascript\">\n/**\n*\n*  MD5 (Message-Digest Algorithm)\n*  \n*\n**/\n\nvar MD5 = function (string) {\n\n\tfunction RotateLeft(lValue, iShiftBits) {\n\t\treturn (lValue<<iShiftBits) | (lValue>>>(32-iShiftBits));\n\t}\n\n\tfunction AddUnsigned(lX,lY) {\n\t\tvar lX4,lY4,lX8,lY8,lResult;\n\t\tlX8 = (lX & 0x80000000);\n\t\tlY8 = (lY & 0x80000000);\n\t\tlX4 = (lX & 0x40000000);\n\t\tlY4 = (lY & 0x40000000);\n\t\tlResult = (lX & 0x3FFFFFFF)+(lY & 0x3FFFFFFF);\n\t\tif (lX4 & lY4) {\n\t\t\treturn (lResult ^ 0x80000000 ^ lX8 ^ lY8);\n\t\t}\n\t\tif (lX4 | lY4) {\n\t\t\tif (lResult & 0x40000000) {\n\t\t\t\treturn (lResult ^ 0xC0000000 ^ lX8 ^ lY8);\n\t\t\t} else {\n\t\t\t\treturn (lResult ^ 0x40000000 ^ lX8 ^ lY8);\n\t\t\t}\n\t\t} else {\n\t\t\treturn (lResult ^ lX8 ^ lY8);\n\t\t}\n \t}\n\n \tfunction F(x,y,z) { return (x & y) | ((~x) & z); }\n \tfunction G(x,y,z) { return (x & z) | (y & (~z)); }\n \tfunction H(x,y,z) { return (x ^ y ^ z); }\n\tfunction I(x,y,z) { return (y ^ (x | (~z))); }\n\n\tfunction FF(a,b,c,d,x,s,ac) {\n\t\ta = AddUnsigned(a, AddUnsigned(AddUnsigned(F(b, c, d), x), ac));\n\t\treturn AddUnsigned(RotateLeft(a, s), b);\n\t};\n\n\tfunction GG(a,b,c,d,x,s,ac) {\n\t\ta = AddUnsigned(a, AddUnsigned(AddUnsigned(G(b, c, d), x), ac));\n\t\treturn AddUnsigned(RotateLeft(a, s), b);\n\t};\n\n\tfunction HH(a,b,c,d,x,s,ac) {\n\t\ta = AddUnsigned(a, AddUnsigned(AddUnsigned(H(b, c, d), x), ac));\n\t\treturn AddUnsigned(RotateLeft(a, s), b);\n\t};\n\n\tfunction II(a,b,c,d,x,s,ac) {\n\t\ta = AddUnsigned(a, AddUnsigned(AddUnsigned(I(b, c, d), x), ac));\n\t\treturn AddUnsigned(RotateLeft(a, s), b);\n\t};\n\n\tfunction ConvertToWordArray(string) {\n\t\tvar lWordCount;\n\t\tvar lMessageLength = string.length;\n\t\tvar lNumberOfWords_temp1=lMessageLength + 8;\n\t\tvar lNumberOfWords_temp2=(lNumberOfWords_temp1-(lNumberOfWords_temp1 % 64))/64;\n\t\tvar lNumberOfWords = (lNumberOfWords_temp2+1)*16;\n\t\tvar lWordArray=Array(lNumberOfWords-1);\n\t\tvar lBytePosition = 0;\n\t\tvar lByteCount = 0;\n\t\twhile ( lByteCount < lMessageLength ) {\n\t\t\tlWordCount = (lByteCount-(lByteCount % 4))/4;\n\t\t\tlBytePosition = (lByteCount % 4)*8;\n\t\t\tlWordArray[lWordCount] = (lWordArray[lWordCount] | (string.charCodeAt(lByteCount)<<lBytePosition));\n\t\t\tlByteCount++;\n\t\t}\n\t\tlWordCount = (lByteCount-(lByteCount % 4))/4;\n\t\tlBytePosition = (lByteCount % 4)*8;\n\t\tlWordArray[lWordCount] = lWordArray[lWordCount] | (0x80<<lBytePosition);\n\t\tlWordArray[lNumberOfWords-2] = lMessageLength<<3;\n\t\tlWordArray[lNumberOfWords-1] = lMessageLength>>>29;\n\t\treturn lWordArray;\n\t};\n\n\tfunction WordToHex(lValue) {\n\t\tvar WordToHexValue=\"\",WordToHexValue_temp=\"\",lByte,lCount;\n\t\tfor (lCount = 0;lCount<=3;lCount++) {\n\t\t\tlByte = (lValue>>>(lCount*8)) & 255;\n\t\t\tWordToHexValue_temp = \"0\" + lByte.toString(16);\n\t\t\tWordToHexValue = WordToHexValue + WordToHexValue_temp.substr(WordToHexValue_temp.length-2,2);\n\t\t}\n\t\treturn WordToHexValue;\n\t};\n\n\tfunction Utf8Encode(string) {\n\t\tstring = string.replace(/\\r\\n/g,\"\\n\");\n\t\tvar utftext = \"\";\n\n\t\tfor (var n = 0; n < string.length; n++) {\n\n\t\t\tvar c = string.charCodeAt(n);\n\n\t\t\tif (c < 128) {\n\t\t\t\tutftext += String.fromCharCode(c);\n\t\t\t}\n\t\t\telse if((c > 127) && (c < 2048)) {\n\t\t\t\tutftext += String.fromCharCode((c >> 6) | 192);\n\t\t\t\tutftext += String.fromCharCode((c & 63) | 128);\n\t\t\t}\n\t\t\telse {\n\t\t\t\tutftext += String.fromCharCode((c >> 12) | 224);\n\t\t\t\tutftext += String.fromCharCode(((c >> 6) & 63) | 128);\n\t\t\t\tutftext += String.fromCharCode((c & 63) | 128);\n\t\t\t}\n\n\t\t}\n\n\t\treturn utftext;\n\t};\n\n\tvar x=Array();\n\tvar k,AA,BB,CC,DD,a,b,c,d;\n\tvar S11=7, S12=12, S13=17, S14=22;\n\tvar S21=5, S22=9 , S23=14, S24=20;\n\tvar S31=4, S32=11, S33=16, S34=23;\n\tvar S41=6, S42=10, S43=15, S44=21;\n\n\tstring = Utf8Encode(string);\n\n\tx = ConvertToWordArray(string);\n\n\ta = 0x67452301; b = 0xEFCDAB89; c = 0x98BADCFE; d = 0x10325476;\n\n\tfor (k=0;k<x.length;k+=16) {\n\t\tAA=a; BB=b; CC=c; DD=d;\n\t\ta=FF(a,b,c,d,x[k+0], S11,0xD76AA478);\n\t\td=FF(d,a,b,c,x[k+1], S12,0xE8C7B756);\n\t\tc=FF(c,d,a,b,x[k+2], S13,0x242070DB);\n\t\tb=FF(b,c,d,a,x[k+3], S14,0xC1BDCEEE);\n\t\ta=FF(a,b,c,d,x[k+4], S11,0xF57C0FAF);\n\t\td=FF(d,a,b,c,x[k+5], S12,0x4787C62A);\n\t\tc=FF(c,d,a,b,x[k+6], S13,0xA8304613);\n\t\tb=FF(b,c,d,a,x[k+7], S14,0xFD469501);\n\t\ta=FF(a,b,c,d,x[k+8], S11,0x698098D8);\n\t\td=FF(d,a,b,c,x[k+9], S12,0x8B44F7AF);\n\t\tc=FF(c,d,a,b,x[k+10],S13,0xFFFF5BB1);\n\t\tb=FF(b,c,d,a,x[k+11],S14,0x895CD7BE);\n\t\ta=FF(a,b,c,d,x[k+12],S11,0x6B901122);\n\t\td=FF(d,a,b,c,x[k+13],S12,0xFD987193);\n\t\tc=FF(c,d,a,b,x[k+14],S13,0xA679438E);\n\t\tb=FF(b,c,d,a,x[k+15],S14,0x49B40821);\n\t\ta=GG(a,b,c,d,x[k+1], S21,0xF61E2562);\n\t\td=GG(d,a,b,c,x[k+6], S22,0xC040B340);\n\t\tc=GG(c,d,a,b,x[k+11],S23,0x265E5A51);\n\t\tb=GG(b,c,d,a,x[k+0], S24,0xE9B6C7AA);\n\t\ta=GG(a,b,c,d,x[k+5], S21,0xD62F105D);\n\t\td=GG(d,a,b,c,x[k+10],S22,0x2441453);\n\t\tc=GG(c,d,a,b,x[k+15],S23,0xD8A1E681);\n\t\tb=GG(b,c,d,a,x[k+4], S24,0xE7D3FBC8);\n\t\ta=GG(a,b,c,d,x[k+9], S21,0x21E1CDE6);\n\t\td=GG(d,a,b,c,x[k+14],S22,0xC33707D6);\n\t\tc=GG(c,d,a,b,x[k+3], S23,0xF4D50D87);\n\t\tb=GG(b,c,d,a,x[k+8], S24,0x455A14ED);\n\t\ta=GG(a,b,c,d,x[k+13],S21,0xA9E3E905);\n\t\td=GG(d,a,b,c,x[k+2], S22,0xFCEFA3F8);\n\t\tc=GG(c,d,a,b,x[k+7], S23,0x676F02D9);\n\t\tb=GG(b,c,d,a,x[k+12],S24,0x8D2A4C8A);\n\t\ta=HH(a,b,c,d,x[k+5], S31,0xFFFA3942);\n\t\td=HH(d,a,b,c,x[k+8], S32,0x8771F681);\n\t\tc=HH(c,d,a,b,x[k+11],S33,0x6D9D6122);\n\t\tb=HH(b,c,d,a,x[k+14],S34,0xFDE5380C);\n\t\ta=HH(a,b,c,d,x[k+1], S31,0xA4BEEA44);\n\t\td=HH(d,a,b,c,x[k+4], S32,0x4BDECFA9);\n\t\tc=HH(c,d,a,b,x[k+7], S33,0xF6BB4B60);\n\t\tb=HH(b,c,d,a,x[k+10],S34,0xBEBFBC70);\n\t\ta=HH(a,b,c,d,x[k+13],S31,0x289B7EC6);\n\t\td=HH(d,a,b,c,x[k+0], S32,0xEAA127FA);\n\t\tc=HH(c,d,a,b,x[k+3], S33,0xD4EF3085);\n\t\tb=HH(b,c,d,a,x[k+6], S34,0x4881D05);\n\t\ta=HH(a,b,c,d,x[k+9], S31,0xD9D4D039);\n\t\td=HH(d,a,b,c,x[k+12],S32,0xE6DB99E5);\n\t\tc=HH(c,d,a,b,x[k+15],S33,0x1FA27CF8);\n\t\tb=HH(b,c,d,a,x[k+2], S34,0xC4AC5665);\n\t\ta=II(a,b,c,d,x[k+0], S41,0xF4292244);\n\t\td=II(d,a,b,c,x[k+7], S42,0x432AFF97);\n\t\tc=II(c,d,a,b,x[k+14],S43,0xAB9423A7);\n\t\tb=II(b,c,d,a,x[k+5], S44,0xFC93A039);\n\t\ta=II(a,b,c,d,x[k+12],S41,0x655B59C3);\n\t\td=II(d,a,b,c,x[k+3], S42,0x8F0CCC92);\n\t\tc=II(c,d,a,b,x[k+10],S43,0xFFEFF47D);\n\t\tb=II(b,c,d,a,x[k+1], S44,0x85845DD1);\n\t\ta=II(a,b,c,d,x[k+8], S41,0x6FA87E4F);\n\t\td=II(d,a,b,c,x[k+15],S42,0xFE2CE6E0);\n\t\tc=II(c,d,a,b,x[k+6], S43,0xA3014314);\n\t\tb=II(b,c,d,a,x[k+13],S44,0x4E0811A1);\n\t\ta=II(a,b,c,d,x[k+4], S41,0xF7537E82);\n\t\td=II(d,a,b,c,x[k+11],S42,0xBD3AF235);\n\t\tc=II(c,d,a,b,x[k+2], S43,0x2AD7D2BB);\n\t\tb=II(b,c,d,a,x[k+9], S44,0xEB86D391);\n\t\ta=AddUnsigned(a,AA);\n\t\tb=AddUnsigned(b,BB);\n\t\tc=AddUnsigned(c,CC);\n\t\td=AddUnsigned(d,DD);\n\t}\n\n\tvar temp = WordToHex(a)+WordToHex(b)+WordToHex(c)+WordToHex(d);\n\n\treturn temp.toLowerCase();\n}\n\n function encryptPassword(formname,strpwd){\n\ttry{\n\t//alert(\"Hi:\" +formname+\": \"+strpwd);\n\tvar username=eval(\"document.\"+formname+\".username.value\");\n\t//alert(\"username\"+username);\n\tvar profPass=eval(\"document.\"+formname+\".\"+strpwd+\".value\");\n\t//alert(profPass);\n\tvar con =username+\"|\"+profPass;\n\t//alert(con);\n\tvar enc = MD5(con);\n\t//alert(enc);\t\n\tvar ppf=eval(\"document.\"+formname+\".\"+strpwd);\n\tppf.value=enc;\n\t}catch(error){\n\t\t\n\t}\n}\n\n// added for CR 5034 - begin \nfunction encryptLoginPassword(key,struser,strpwd){\n\t\n\t\tvar username=struser;\n\t\tvar password=strpwd;\n\t\tvar enc =MD5(MD5(username+\"#\"+password)+\"#\"+key);\n\t\treturn enc;\n\n}  \n//added for CR 5034 - end \n</script>\n\n</head>\n\n<body>\n\n\n\n</body>\n\n</html> \n\n";
		string text4 = text3;
		WebBrowser webBrowser = new WebBrowser
		{
			ScriptErrorsSuppressed = true
		};
		string urlString = "about:blank";
		webBrowser.Navigate(urlString);
		webBrowser.Document.Write(text4);
		object[] array = new object[1];
		string text5 = string_21;
		string text6 = "#";
		array[0] = text5 + text6 + b;
		object[] array2 = array;
		HtmlDocument document = webBrowser.Document;
		string scriptName = "MD5";
		string text7 = document.InvokeScript(scriptName, array2).ToString();
		string text8 = "#";
		array2[0] = text7 + text8 + string_23;
		HtmlDocument document2 = webBrowser.Document;
		string scriptName2 = "MD5";
		string_22 = document2.InvokeScript(scriptName2, array2).ToString();
		webBrowser.Dispose();
		string[] array3 = new string[7];
		string text9 = "<html>\n<head>\n<script type=\"text/javascript\">\nvar CryptoJS = CryptoJS\n\t\t|| function(a, g) {\n\t\t\tvar m = {}, e = m.lib = {}, q = e.Base = function() {\n\t\t\t\tfunction a() {\n\t\t\t\t}\n\t\t\t\treturn {\n\t\t\t\t\textend : function(b) {\n\t\t\t\t\t\ta.prototype = this;\n\t\t\t\t\t\tvar d = new a;\n\t\t\t\t\t\tb && d.mixIn(b);\n\t\t\t\t\t\td.$super = this;\n\t\t\t\t\t\treturn d\n\t\t\t\t\t},\n\t\t\t\t\tcreate : function() {\n\t\t\t\t\t\tvar a = this.extend();\n\t\t\t\t\t\ta.init.apply(a, arguments);\n\t\t\t\t\t\treturn a\n\t\t\t\t\t},\n\t\t\t\t\tinit : function() {\n\t\t\t\t\t},\n\t\t\t\t\tmixIn : function(a) {\n\t\t\t\t\t\tfor ( var k in a)\n\t\t\t\t\t\t\ta.hasOwnProperty(k) && (this[k] = a[k]);\n\t\t\t\t\t\ta.hasOwnProperty(\"toString\")\n\t\t\t\t\t\t\t\t&& (this.toString = a.toString)\n\t\t\t\t\t},\n\t\t\t\t\tclone : function() {\n\t\t\t\t\t\treturn this.$super.extend(this)\n\t\t\t\t\t}\n\t\t\t\t}\n\t\t\t}(), r = e.WordArray = q\n\t\t\t\t\t.extend( {\n\t\t\t\t\t\tinit : function(a, b) {\n\t\t\t\t\t\t\ta = this.words = a || [];\n\t\t\t\t\t\t\tthis.sigBytes = b != g ? b : 4 * a.length\n\t\t\t\t\t\t},\n\t\t\t\t\t\ttoString : function(a) {\n\t\t\t\t\t\t\treturn (a || n).stringify(this)\n\t\t\t\t\t\t},\n\t\t\t\t\t\tconcat : function(a) {\n\t\t\t\t\t\t\tvar b = this.words, d = a.words, c = this.sigBytes, a = a.sigBytes;\n\t\t\t\t\t\t\tthis.clamp();\n\t\t\t\t\t\t\tif (c % 4)\n\t\t\t\t\t\t\t\tfor ( var i = 0; i < a; i++)\n\t\t\t\t\t\t\t\tb[c + i >>> 2] |= (d[i >>> 2] >>> 24 - 8 * (i % 4) & 255) << 24 - 8 * ((c + i) % 4);\n\t\t\t\t\t\telse if (65535 < d.length)\n\t\t\t\t\t\t\tfor (i = 0; i < a; i += 4)\n\t\t\t\t\t\t\t\tb[c + i >>> 2] = d[i >>> 2];\n\t\t\t\t\t\telse\n\t\t\t\t\t\t\tb.push.apply(b, d);\n\t\t\t\t\t\tthis.sigBytes += a;\n\t\t\t\t\t\treturn this\n\t\t\t\t\t\t},\n\t\t\t\t\t\tclamp : function() {\n\t\t\t\t\t\t\tvar k = this.words, b = this.sigBytes;\n\t\t\t\t\t\t\tk[b >>> 2] &= 4294967295 << 32 - 8 * (b % 4);\n\t\t\t\t\t\t\tk.length = a.ceil(b / 4)\n\t\t\t\t\t\t},\n\t\t\t\t\t\tclone : function() {\n\t\t\t\t\t\t\tvar a = q.clone.call(this);\n\t\t\t\t\t\t\ta.words = this.words.slice(0);\n\t\t\t\t\t\t\treturn a\n\t\t\t\t\t\t},\n\t\t\t\t\t\trandom : function(k) {\n\t\t\t\t\t\t\tfor ( var b = [], d = 0; d < k; d += 4)\n\t\t\t\t\t\t\t\tb.push(4294967296 * a.random() | 0);\n\t\t\t\t\t\t\treturn r.create(b, k)\n\t\t\t\t\t\t}\n\t\t\t\t\t}), y = m.enc = {}, n = y.Hex = {\n\t\t\t\tstringify : function(a) {\n\t\t\t\t\tfor ( var b = a.words, a = a.sigBytes, d = [], c = 0; c < a; c++) {\n\t\t\t\t\t\tvar i = b[c >>> 2] >>> 24 - 8 * (c % 4) & 255;\n\t\t\t\t\t\td.push((i >>> 4).toString(16));\n\t\t\t\t\t\td.push((i & 15).toString(16))\n\t\t\t\t\t\t}\n\t\t\t\t\treturn d.join(\"\")\n\t\t\t\t},\n\t\t\t\tparse : function(a) {\n\t\t\t\t\tfor ( var b = a.length, d = [], c = 0; c < b; c += 2)\n\t\t\t\t\t\td[c >>> 3] |= parseInt(a.substr(c, 2), 16) << 24 - 4 * (c % 8);\n\t\t\t\t\treturn r.create(d, b / 2)\n\t\t\t\t}\n\t\t\t}, l = y.Latin1 = {\n\t\t\t\tstringify : function(a) {\n\t\t\t\t\tfor ( var b = a.words, a = a.sigBytes, d = [], c = 0; c < a; c++)\n\t\t\t\t\t\td\n\t\t\t\t\t\t\t\t.push(String\n\t\t\t\t\t\t\t\t\t.fromCharCode(b[c >>> 2] >>> 24 - 8 * (c % 4) & 255));\n\t\t\t\t\treturn d.join(\"\")\n\t\t\t\t},\n\t\t\t\tparse : function(a) {\n\t\t\t\t\tfor ( var b = a.length, d = [], c = 0; c < b; c++)\n\t\t\t\t\t\td[c >>> 2] |= (a.charCodeAt(c) & 255) << 24 - 8 * (c % 4);\n\t\t\t\t\treturn r.create(d, b)\n\t\t\t\t}\n\t\t\t}, da = y.Utf8 = {\n\t\t\t\tstringify : function(a) {\n\t\t\t\t\ttry {\n\t\t\t\t\t\treturn decodeURIComponent(escape(l.stringify(a)))\n\t\t\t\t\t} catch (b) {\n\t\t\t\t\t\tthrow Error(\"Malformed UTF-8 data\");\n\t\t\t\t\t}\n\t\t\t\t},\n\t\t\t\tparse : function(a) {\n\t\t\t\t\treturn l.parse(unescape(encodeURIComponent(a)))\n\t\t\t\t}\n\t\t\t}, h = e.BufferedBlockAlgorithm = q\n\t\t\t\t\t.extend( {\n\t\t\t\t\t\treset : function() {\n\t\t\t\t\t\t\tthis._data = r.create();\n\t\t\t\t\t\t\tthis._nDataBytes = 0\n\t\t\t\t\t\t},\n\t\t\t\t\t\t_append : function(a) {\n\t\t\t\t\t\t\t\"string\" == typeof a && (a = da.parse(a));\n\t\t\t\t\t\t\tthis._data.concat(a);\n\t\t\t\t\t\t\tthis._nDataBytes += a.sigBytes\n\t\t\t\t\t\t},\n\t\t\t\t\t\t_process : function(k) {\n\t\t\t\t\t\t\tvar b = this._data, d = b.words, c = b.sigBytes, i = this.blockSize, l = c\n\t\t\t\t\t\t\t\t/ (4 * i), l = k ? a.ceil(l) : a.max(\n\t\t\t\t\t\t\t\t(l | 0) - this._minBufferSize, 0), k = l\n\t\t\t\t\t\t\t\t* i, c = a.min(4 * k, c);\n\t\t\t\t\t\tif (k) {\n\t\t\t\t\t\t\tfor ( var h = 0; h < k; h += i)\n\t\t\t\t\t\t\t\tthis._doProcessBlock(d, h);\n\t\t\t\t\t\t\th = d.splice(0, k);\n\t\t\t\t\t\t\tb.sigBytes -= c\n\t\t\t\t\t\t}\n\t\t\t\t\t\treturn r.create(h, c)\n\t\t\t\t\t},\n\t\t\t\t\tclone : function() {\n\t\t\t\t\tvar a = q.clone.call(this);\n\t\t\t\t\ta._data = this._data.clone();\n\t\t\t\t\treturn a\n\t\t\t\t},\n\t\t\t\t_minBufferSize : 0\n\t\t\t});\n\t\te.Hasher = h.extend( {\n\t\t\tinit : function() {\n\t\t\t\tthis.reset()\n\t\t\t},\n\t\t\treset : function() {\n\t\t\t\th.reset.call(this);\n\t\t\t\tthis._doReset()\n\t\t\t},\n\t\t\t\tupdate : function(a) {\n\t\t\t\t\tthis._append(a);\n\t\t\t\t\tthis._process();\n\t\t\t\t\treturn this\n\t\t\t\t},\n\t\t\t\tfinalize : function(a) {\n\t\t\t\t\ta && this._append(a);\n\t\t\t\t\tthis._doFinalize();\n\t\t\t\t\treturn this._hash\n\t\t\t\t},\n\t\t\t\tclone : function() {\n\t\t\t\t\tvar a = h.clone.call(this);\n\t\t\t\t\ta._hash = this._hash.clone();\n\t\t\t\t\treturn a\n\t\t\t\t},\n\t\t\t\tblockSize : 16,\n\t\t\t\t_createHelper : function(a) {\n\t\t\t\t\treturn function(b, d) {\n\t\t\t\t\t\treturn a.create(d).finalize(b)\n\t\t\t\t\t}\n\t\t\t\t},\n\t\t\t\t_createHmacHelper : function(a) {\n\t\t\t\t\treturn function(b, d) {\n\t\t\t\t\t\treturn ea.HMAC.create(a, d).finalize(b)\n\t\t\t\t\t}\n\t\t\t\t}\n\t\t\t});\n\t\t\tvar ea = m.algo = {};\n\t\t\treturn m\n\t\t}(Math);\n( function(a) {\n\tvar g = CryptoJS, m = g.lib, e = m.Base, q = m.WordArray, g = g.x64 = {};\n\tg.Word = e.extend( {\n\t\tinit : function(a, e) {\n\t\t\tthis.high = a;\n\t\t\tthis.low = e\n\t\t}\n\t});\n\tg.WordArray = e\n\t\t\t.extend( {\n\t\t\t\tinit : function(e, y) {\n\t\t\t\t\te = this.words = e || [];\n\t\t\t\t\tthis.sigBytes = y != a ? y : 8 * e.length\n\t\t\t\t},\n\t\t\t\ttoX32 : function() {\n\t\t\t\t\tfor ( var a = this.words, e = a.length, n = [], l = 0; l < e; l++) {\n\t\t\t\t\t\tvar g = a[l];\n\t\t\t\t\t\tn.push(g.high);\n\t\t\t\t\t\tn.push(g.low)\n\t\t\t\t\t\t}\n\t\t\t\t\treturn q.create(n, this.sigBytes)\n\t\t\t\t},\n\t\t\t\tclone : function() {\n\t\t\t\t\tfor ( var a = e.clone.call(this), g = a.words = this.words\n\t\t\t\t\t\t.slice(0), n = g.length, l = 0; l < n; l++)\n\t\t\t\t\tg[l] = g[l].clone();\n\t\t\t\treturn a\n\t\t\t\t}\n\t\t\t})\n})();\n( function() {\n\tfunction a() {\n\t\treturn q.create.apply(q, arguments)\n\t}\n\tvar g = CryptoJS, m = g.lib.Hasher, e = g.x64, q = e.Word, r = e.WordArray, e = g.algo, y = [\n\t\t\ta(1116352408, 3609767458), a(1899447441, 602891725),\n\t\t\ta(3049323471, 3964484399), a(3921009573, 2173295548),\n\t\t\ta(961987163, 4081628472), a(1508970993, 3053834265),\n\t\t\ta(2453635748, 2937671579), a(2870763221, 3664609560),\n\t\t\ta(3624381080, 2734883394), a(310598401, 1164996542),\n\t\t\ta(607225278, 1323610764), a(1426881987, 3590304994),\n\t\t\ta(1925078388, 4068182383), a(2162078206, 991336113),\n\t\t\ta(2614888103, 633803317), a(3248222580, 3479774868),\n\t\t\ta(3835390401, 2666613458), a(4022224774, 944711139),\n\t\t\ta(264347078, 2341262773), a(604807628, 2007800933),\n\t\t\ta(770255983, 1495990901), a(1249150122, 1856431235),\n\t\t\ta(1555081692, 3175218132), a(1996064986, 2198950837),\n\t\t\ta(2554220882, 3999719339), a(2821834349, 766784016),\n\t\t\ta(2952996808, 2566594879), a(3210313671, 3203337956),\n\t\t\ta(3336571891, 1034457026), a(3584528711, 2466948901),\n\t\t\ta(113926993, 3758326383), a(338241895, 168717936),\n\t\t\ta(666307205, 1188179964), a(773529912, 1546045734),\n\t\t\ta(1294757372, 1522805485), a(1396182291, 2643833823),\n\t\t\ta(1695183700, 2343527390), a(1986661051, 1014477480),\n\t\t\ta(2177026350, 1206759142), a(2456956037, 344077627),\n\t\t\ta(2730485921, 1290863460), a(2820302411, 3158454273),\n\t\t\ta(3259730800, 3505952657), a(3345764771, 106217008),\n\t\t\ta(3516065817, 3606008344), a(3600352804, 1432725776),\n\t\t\ta(4094571909, 1467031594), a(275423344, 851169720),\n\t\t\ta(430227734, 3100823752), a(506948616, 1363258195),\n\t\t\ta(659060556, 3750685593), a(883997877, 3785050280),\n\t\t\ta(958139571, 3318307427), a(1322822218, 3812723403),\n\t\t\ta(1537002063, 2003034995), a(1747873779, 3602036899),\n\t\t\ta(1955562222, 1575990012), a(2024104815, 1125592928),\n\t\t\ta(2227730452, 2716904306), a(2361852424, 442776044),\n\t\t\ta(2428436474, 593698344), a(2756734187, 3733110249),\n\t\t\ta(3204031479, 2999351573), a(3329325298, 3815920427),\n\t\t\ta(3391569614, 3928383900), a(3515267271, 566280711),\n\t\t\ta(3940187606, 3454069534), a(4118630271, 4000239992),\n\t\t\ta(116418474, 1914138554), a(174292421, 2731055270),\n\t\t\ta(289380356, 3203993006), a(460393269, 320620315),\n\t\t\ta(685471733, 587496836), a(852142971, 1086792851),\n\t\t\ta(1017036298, 365543100), a(1126000580, 2618297676),\n\t\t\ta(1288033470, 3409855158), a(1501505948, 4234509866),\n\t\t\ta(1607167915, 987167468), a(1816402316, 1246189591) ], n = [];\n\t( function() {\n\t\tfor ( var l = 0; 80 > l; l++)\n\t\t\tn[l] = a()\n\t})();\n\te = e.SHA512 = m\n\t\t\t.extend( {\n\t\t\t\t_doReset : function() {\n\t\t\t\t\tthis._hash = r.create( [ a(1779033703, 4089235720),\n\t\t\t\t\t\t\ta(3144134277, 2227873595),\n\t\t\t\t\t\t\ta(1013904242, 4271175723),\n\t\t\t\t\t\t\ta(2773480762, 1595750129),\n\t\t\t\t\t\t\ta(1359893119, 2917565137),\n\t\t\t\t\t\t\ta(2600822924, 725511199), a(528734635, 4215389547),\n\t\t\t\t\t\t\ta(1541459225, 327033209) ])\n\t\t\t\t},\n\t\t\t\t_doProcessBlock : function(a, e) {\n\t\t\t\t\tfor ( var h = this._hash.words, g = h[0], k = h[1], b = h[2], d = h[3], c = h[4], i = h[5], m = h[6], h = h[7], q = g.high, r = g.low, W = k.high, K = k.low, X = b.high, L = b.low, Y = d.high, M = d.low, Z = c.high, N = c.low, $ = i.high, O = i.low, aa = m.high, P = m.low, ba = h.high, Q = h.low, t = q, o = r, E = W, C = K, F = X, D = L, T = Y, G = M, u = Z, p = N, R = $, H = O, S = aa, I = P, U = ba, J = Q, v = 0; 80 > v; v++) {\n\t\t\t\t\t\tvar z = n[v];\n\t\t\t\t\t\tif (16 > v)\n\t\t\t\t\t\t\tvar s = z.high = a[e + 2 * v] | 0, f = z.low = a[e\n\t\t\t\t\t\t\t\t+ 2 * v + 1] | 0;\n\t\t\t\t\t\telse {\n\t\t\t\t\t\t\tvar s = n[v - 15], f = s.high, w = s.low, s = (w << 31 | f >>> 1)\n\t\t\t\t\t\t\t\t\t^ (w << 24 | f >>> 8) ^ f >>> 7, w = (f << 31 | w >>> 1)\n\t\t\t\t\t\t\t\t\t^ (f << 24 | w >>> 8) ^ (f << 25 | w >>> 7), B = n[v - 2], f = B.high, j = B.low, B = (j << 13 | f >>> 19)\n\t\t\t\t\t\t\t\t\t^ (f << 3 | j >>> 29) ^ f >>> 6, j = (f << 13 | j >>> 19)\n\t\t\t\t\t\t\t\t\t^ (j << 3 | f >>> 29) ^ (f << 26 | j >>> 6), f = n[v - 7], V = f.high, A = n[v - 16], x = A.high, A = A.low, f = w\n\t\t\t\t\t\t\t\t\t+ f.low, s = s + V\n\t\t\t\t\t\t\t\t\t+ (f >>> 0 < w >>> 0 ? 1 : 0), f = f + j, s = s\n\t\t\t\t\t\t\t\t\t+ B + (f >>> 0 < j >>> 0 ? 1 : 0), f = f\n\t\t\t\t\t\t\t\t\t+ A, s = s + x\n\t\t\t\t\t\t\t\t\t+ (f >>> 0 < A >>> 0 ? 1 : 0);\n\t\t\t\t\t\t\tz.high = s;\n\t\t\t\t\t\t\tz.low = f\n\t\t\t\t\t\t}\n\t\t\t\t\t\tvar V = u & R ^ ~u & S, A = p & H ^ ~p & I, z = t & E\n\t\t\t\t\t\t\t\t^ t & F ^ E & F, fa = o & C ^ o & D ^ C & D, w = (o << 4 | t >>> 28)\n\t\t\t\t\t\t\t\t^ (t << 30 | o >>> 2) ^ (t << 25 | o >>> 7), B = (t << 4 | o >>> 28)\n\t\t\t\t\t\t\t\t^ (o << 30 | t >>> 2) ^ (o << 25 | t >>> 7), j = y[v], ga = j.high, ca = j.low, j = J\n\t\t\t\t\t\t\t\t+ ((u << 18 | p >>> 14) ^ (u << 14 | p >>> 18) ^ (p << 23 | u >>> 9)), x = U\n\t\t\t\t\t\t\t\t+ ((p << 18 | u >>> 14) ^ (p << 14 | u >>> 18) ^ (u << 23 | p >>> 9))\n\t\t\t\t\t\t\t\t+ (j >>> 0 < J >>> 0 ? 1 : 0), j = j + A, x = x\n\t\t\t\t\t\t\t\t+ V + (j >>> 0 < A >>> 0 ? 1 : 0), j = j + ca, x = x\n\t\t\t\t\t\t\t\t+ ga + (j >>> 0 < ca >>> 0 ? 1 : 0), j = j + f, x = x\n\t\t\t\t\t\t\t\t+ s + (j >>> 0 < f >>> 0 ? 1 : 0), f = B + fa, z = w\n\t\t\t\t\t\t\t\t+ z + (f >>> 0 < B >>> 0 ? 1 : 0), U = S, J = I, S = R, I = H, R = u, H = p, p = G\n\t\t\t\t\t\t\t\t+ j | 0, u = T + x\n\t\t\t\t\t\t\t\t+ (p >>> 0 < G >>> 0 ? 1 : 0) | 0, T = F, G = D, F = E, D = C, E = t, C = o, o = j\n+ f | 0, t = x + z\n\t\t\t\t\t\t\t\t+ (o >>> 0 < j >>> 0 ? 1 : 0) | 0\n\t\t\t\t\t}\n\t\t\t\t\tr = g.low = r + o | 0;\n\t\t\t\t\tg.high = q + t + (r >>> 0 < o >>> 0 ? 1 : 0) | 0;\n\t\t\t\t\tK = k.low = K + C | 0;\n\t\t\t\t\tk.high = W + E + (K >>> 0 < C >>> 0 ? 1 : 0) | 0;\n\t\t\t\t\tL = b.low = L + D | 0;\n\t\t\t\t\tb.high = X + F + (L >>> 0 < D >>> 0 ? 1 : 0) | 0;\n\t\t\t\t\tM = d.low = M + G | 0;\n\t\t\t\t\td.high = Y + T + (M >>> 0 < G >>> 0 ? 1 : 0) | 0;\n\t\t\t\t\tN = c.low = N + p | 0;\n\t\t\t\t\tc.high = Z + u + (N >>> 0 < p >>> 0 ? 1 : 0) | 0;\n\t\t\t\t\tO = i.low = O + H | 0;\n\t\t\t\t\ti.high = $ + R + (O >>> 0 < H >>> 0 ? 1 : 0) | 0;\n\t\t\t\t\tP = m.low = P + I | 0;\n\t\t\t\t\tm.high = aa + S + (P >>> 0 < I >>> 0 ? 1 : 0) | 0;\n\t\t\t\t\tQ = h.low = Q + J | 0;\n\t\t\t\t\th.high = ba + U + (Q >>> 0 < J >>> 0 ? 1 : 0) | 0\n\t\t\t\t},\n\t\t\t\t_doFinalize : function() {\n\t\t\t\t\tvar a = this._data, e = a.words, h = 8 * this._nDataBytes, g = 8 * a.sigBytes;\n\t\t\t\t\te[g >>> 5] |= 128 << 24 - g % 32;\n\t\t\t\t\te[(g + 128 >>> 10 << 5) + 31] = h;\n\t\t\t\t\ta.sigBytes = 4 * e.length;\n\t\t\t\t\tthis._process();\n\t\t\t\t\tthis._hash = this._hash.toX32()\n\t\t\t\t},\n\t\t\t\tblockSize : 32\n\t\t\t});\n\tg.SHA512 = m._createHelper(e);\n\tg.HmacSHA512 = m._createHmacHelper(e)\n})();\n\n//added for Sha2 - begin\nfunction encryptSha2LoginPassword(key,struser,strpwd){\n\tvar username=struser;\n\tvar password=strpwd;\n\tvar shaHash =CryptoJS.SHA512(struser+\"#\"+strpwd);\n\tvar encString = CryptoJS.SHA512(shaHash +\"#\"+key) ;\n\treturn encString;\n\n}\n\n\nfunction encryptSha2ProfilePassword(formname,strpwd){\n\ttry{\n\tvar username=eval(\"document.\"+formname+\".username.value\");\n\tvar profPass=eval(\"document.\"+formname+\".\"+strpwd+\".value\");\n\tvar shaHash =username+\"|\"+profPass;\n\tvar encString = CryptoJS.SHA512(shaHash)\n\t//var ppf=eval(\"document.\"+formname+\".\"+strpwd);\n\tvar ppf=eval(\"document.\"+formname+\".\"+\"profileSHAPassword\");\n\tppf.value=encString;\n\t}catch(error){\n\t}\n\t}\n\t// end for Sha2 - end\n</script>\n\n\n\n<script>\n\nfunction submitLogin()\n\t{\n\tvar username =\"";
		array3[0] = text9;
		array3[1] = string_21;
		string text10 = "\";\n\tvar password= \"";
		array3[2] = text10;
		array3[3] = b;
		string text11 = "\";\n\tvar md5keystring = \"";
		array3[4] = text11;
		array3[5] = string_23;
		string text12 = "\";\n\t//added for Sha2\n\tvar encSha2SaltPass=encryptSha2LoginPassword(md5keystring,username,password);\n\tdocument.quickLookForm.sha2password.value=encSha2SaltPass;\n\treturn encSha2SaltPass;\n\n}\n\t</script>\n\n<script>\n\nfunction Login()\n\t{\n\tvar Pass=document.quickLookForm.sha2password.value;\n\treturn Pass;\n\n}\n\t</script>\n\n</head>\n\n<body>\n\n\n\n<form name=\"quickLookForm\" method=\"post\" >\n\n<input type=\"hidden\" name=\"sha2password\" value=\"\">\n\n</form>\n\n</body>\n\n</html> \n\n";
		array3[6] = text12;
		string text13 = string.Concat(array3);
		WebBrowser webBrowser2 = new WebBrowser
		{
			ScriptErrorsSuppressed = true
		};
		string urlString2 = "about:blank";
		webBrowser2.Navigate(urlString2);
		webBrowser2.Document.Write(text13);
		HtmlDocument document3 = webBrowser2.Document;
		string scriptName3 = "submitLogin";
		document3.InvokeScript(scriptName3).ToString();
		HtmlDocument document4 = webBrowser2.Document;
		string scriptName4 = "Login";
		string_20 = document4.InvokeScript(scriptName4).ToString();
		return null;
	}

	internal static string smethod_10S(string a, string b, string string_0)
	{
		string_21 = a;
		string value = "profileForm','";
		string_23 = string_0.Substring(string_0.IndexOf(value) + 14);
		string text = string_23;
		string text2 = string_23;
		string value2 = "')";
		string_23 = text.Substring(0, text2.IndexOf(value2));
		string text3 = "<html>\n<head>\n<script type=\"text/javascript\">\n/**\n*\n*  MD5 (Message-Digest Algorithm)\n*  \n*\n**/\n\nvar MD5 = function (string) {\n\n\tfunction RotateLeft(lValue, iShiftBits) {\n\t\treturn (lValue<<iShiftBits) | (lValue>>>(32-iShiftBits));\n\t}\n\n\tfunction AddUnsigned(lX,lY) {\n\t\tvar lX4,lY4,lX8,lY8,lResult;\n\t\tlX8 = (lX & 0x80000000);\n\t\tlY8 = (lY & 0x80000000);\n\t\tlX4 = (lX & 0x40000000);\n\t\tlY4 = (lY & 0x40000000);\n\t\tlResult = (lX & 0x3FFFFFFF)+(lY & 0x3FFFFFFF);\n\t\tif (lX4 & lY4) {\n\t\t\treturn (lResult ^ 0x80000000 ^ lX8 ^ lY8);\n\t\t}\n\t\tif (lX4 | lY4) {\n\t\t\tif (lResult & 0x40000000) {\n\t\t\t\treturn (lResult ^ 0xC0000000 ^ lX8 ^ lY8);\n\t\t\t} else {\n\t\t\t\treturn (lResult ^ 0x40000000 ^ lX8 ^ lY8);\n\t\t\t}\n\t\t} else {\n\t\t\treturn (lResult ^ lX8 ^ lY8);\n\t\t}\n \t}\n\n \tfunction F(x,y,z) { return (x & y) | ((~x) & z); }\n \tfunction G(x,y,z) { return (x & z) | (y & (~z)); }\n \tfunction H(x,y,z) { return (x ^ y ^ z); }\n\tfunction I(x,y,z) { return (y ^ (x | (~z))); }\n\n\tfunction FF(a,b,c,d,x,s,ac) {\n\t\ta = AddUnsigned(a, AddUnsigned(AddUnsigned(F(b, c, d), x), ac));\n\t\treturn AddUnsigned(RotateLeft(a, s), b);\n\t};\n\n\tfunction GG(a,b,c,d,x,s,ac) {\n\t\ta = AddUnsigned(a, AddUnsigned(AddUnsigned(G(b, c, d), x), ac));\n\t\treturn AddUnsigned(RotateLeft(a, s), b);\n\t};\n\n\tfunction HH(a,b,c,d,x,s,ac) {\n\t\ta = AddUnsigned(a, AddUnsigned(AddUnsigned(H(b, c, d), x), ac));\n\t\treturn AddUnsigned(RotateLeft(a, s), b);\n\t};\n\n\tfunction II(a,b,c,d,x,s,ac) {\n\t\ta = AddUnsigned(a, AddUnsigned(AddUnsigned(I(b, c, d), x), ac));\n\t\treturn AddUnsigned(RotateLeft(a, s), b);\n\t};\n\n\tfunction ConvertToWordArray(string) {\n\t\tvar lWordCount;\n\t\tvar lMessageLength = string.length;\n\t\tvar lNumberOfWords_temp1=lMessageLength + 8;\n\t\tvar lNumberOfWords_temp2=(lNumberOfWords_temp1-(lNumberOfWords_temp1 % 64))/64;\n\t\tvar lNumberOfWords = (lNumberOfWords_temp2+1)*16;\n\t\tvar lWordArray=Array(lNumberOfWords-1);\n\t\tvar lBytePosition = 0;\n\t\tvar lByteCount = 0;\n\t\twhile ( lByteCount < lMessageLength ) {\n\t\t\tlWordCount = (lByteCount-(lByteCount % 4))/4;\n\t\t\tlBytePosition = (lByteCount % 4)*8;\n\t\t\tlWordArray[lWordCount] = (lWordArray[lWordCount] | (string.charCodeAt(lByteCount)<<lBytePosition));\n\t\t\tlByteCount++;\n\t\t}\n\t\tlWordCount = (lByteCount-(lByteCount % 4))/4;\n\t\tlBytePosition = (lByteCount % 4)*8;\n\t\tlWordArray[lWordCount] = lWordArray[lWordCount] | (0x80<<lBytePosition);\n\t\tlWordArray[lNumberOfWords-2] = lMessageLength<<3;\n\t\tlWordArray[lNumberOfWords-1] = lMessageLength>>>29;\n\t\treturn lWordArray;\n\t};\n\n\tfunction WordToHex(lValue) {\n\t\tvar WordToHexValue=\"\",WordToHexValue_temp=\"\",lByte,lCount;\n\t\tfor (lCount = 0;lCount<=3;lCount++) {\n\t\t\tlByte = (lValue>>>(lCount*8)) & 255;\n\t\t\tWordToHexValue_temp = \"0\" + lByte.toString(16);\n\t\t\tWordToHexValue = WordToHexValue + WordToHexValue_temp.substr(WordToHexValue_temp.length-2,2);\n\t\t}\n\t\treturn WordToHexValue;\n\t};\n\n\tfunction Utf8Encode(string) {\n\t\tstring = string.replace(/\\r\\n/g,\"\\n\");\n\t\tvar utftext = \"\";\n\n\t\tfor (var n = 0; n < string.length; n++) {\n\n\t\t\tvar c = string.charCodeAt(n);\n\n\t\t\tif (c < 128) {\n\t\t\t\tutftext += String.fromCharCode(c);\n\t\t\t}\n\t\t\telse if((c > 127) && (c < 2048)) {\n\t\t\t\tutftext += String.fromCharCode((c >> 6) | 192);\n\t\t\t\tutftext += String.fromCharCode((c & 63) | 128);\n\t\t\t}\n\t\t\telse {\n\t\t\t\tutftext += String.fromCharCode((c >> 12) | 224);\n\t\t\t\tutftext += String.fromCharCode(((c >> 6) & 63) | 128);\n\t\t\t\tutftext += String.fromCharCode((c & 63) | 128);\n\t\t\t}\n\n\t\t}\n\n\t\treturn utftext;\n\t};\n\n\tvar x=Array();\n\tvar k,AA,BB,CC,DD,a,b,c,d;\n\tvar S11=7, S12=12, S13=17, S14=22;\n\tvar S21=5, S22=9 , S23=14, S24=20;\n\tvar S31=4, S32=11, S33=16, S34=23;\n\tvar S41=6, S42=10, S43=15, S44=21;\n\n\tstring = Utf8Encode(string);\n\n\tx = ConvertToWordArray(string);\n\n\ta = 0x67452301; b = 0xEFCDAB89; c = 0x98BADCFE; d = 0x10325476;\n\n\tfor (k=0;k<x.length;k+=16) {\n\t\tAA=a; BB=b; CC=c; DD=d;\n\t\ta=FF(a,b,c,d,x[k+0], S11,0xD76AA478);\n\t\td=FF(d,a,b,c,x[k+1], S12,0xE8C7B756);\n\t\tc=FF(c,d,a,b,x[k+2], S13,0x242070DB);\n\t\tb=FF(b,c,d,a,x[k+3], S14,0xC1BDCEEE);\n\t\ta=FF(a,b,c,d,x[k+4], S11,0xF57C0FAF);\n\t\td=FF(d,a,b,c,x[k+5], S12,0x4787C62A);\n\t\tc=FF(c,d,a,b,x[k+6], S13,0xA8304613);\n\t\tb=FF(b,c,d,a,x[k+7], S14,0xFD469501);\n\t\ta=FF(a,b,c,d,x[k+8], S11,0x698098D8);\n\t\td=FF(d,a,b,c,x[k+9], S12,0x8B44F7AF);\n\t\tc=FF(c,d,a,b,x[k+10],S13,0xFFFF5BB1);\n\t\tb=FF(b,c,d,a,x[k+11],S14,0x895CD7BE);\n\t\ta=FF(a,b,c,d,x[k+12],S11,0x6B901122);\n\t\td=FF(d,a,b,c,x[k+13],S12,0xFD987193);\n\t\tc=FF(c,d,a,b,x[k+14],S13,0xA679438E);\n\t\tb=FF(b,c,d,a,x[k+15],S14,0x49B40821);\n\t\ta=GG(a,b,c,d,x[k+1], S21,0xF61E2562);\n\t\td=GG(d,a,b,c,x[k+6], S22,0xC040B340);\n\t\tc=GG(c,d,a,b,x[k+11],S23,0x265E5A51);\n\t\tb=GG(b,c,d,a,x[k+0], S24,0xE9B6C7AA);\n\t\ta=GG(a,b,c,d,x[k+5], S21,0xD62F105D);\n\t\td=GG(d,a,b,c,x[k+10],S22,0x2441453);\n\t\tc=GG(c,d,a,b,x[k+15],S23,0xD8A1E681);\n\t\tb=GG(b,c,d,a,x[k+4], S24,0xE7D3FBC8);\n\t\ta=GG(a,b,c,d,x[k+9], S21,0x21E1CDE6);\n\t\td=GG(d,a,b,c,x[k+14],S22,0xC33707D6);\n\t\tc=GG(c,d,a,b,x[k+3], S23,0xF4D50D87);\n\t\tb=GG(b,c,d,a,x[k+8], S24,0x455A14ED);\n\t\ta=GG(a,b,c,d,x[k+13],S21,0xA9E3E905);\n\t\td=GG(d,a,b,c,x[k+2], S22,0xFCEFA3F8);\n\t\tc=GG(c,d,a,b,x[k+7], S23,0x676F02D9);\n\t\tb=GG(b,c,d,a,x[k+12],S24,0x8D2A4C8A);\n\t\ta=HH(a,b,c,d,x[k+5], S31,0xFFFA3942);\n\t\td=HH(d,a,b,c,x[k+8], S32,0x8771F681);\n\t\tc=HH(c,d,a,b,x[k+11],S33,0x6D9D6122);\n\t\tb=HH(b,c,d,a,x[k+14],S34,0xFDE5380C);\n\t\ta=HH(a,b,c,d,x[k+1], S31,0xA4BEEA44);\n\t\td=HH(d,a,b,c,x[k+4], S32,0x4BDECFA9);\n\t\tc=HH(c,d,a,b,x[k+7], S33,0xF6BB4B60);\n\t\tb=HH(b,c,d,a,x[k+10],S34,0xBEBFBC70);\n\t\ta=HH(a,b,c,d,x[k+13],S31,0x289B7EC6);\n\t\td=HH(d,a,b,c,x[k+0], S32,0xEAA127FA);\n\t\tc=HH(c,d,a,b,x[k+3], S33,0xD4EF3085);\n\t\tb=HH(b,c,d,a,x[k+6], S34,0x4881D05);\n\t\ta=HH(a,b,c,d,x[k+9], S31,0xD9D4D039);\n\t\td=HH(d,a,b,c,x[k+12],S32,0xE6DB99E5);\n\t\tc=HH(c,d,a,b,x[k+15],S33,0x1FA27CF8);\n\t\tb=HH(b,c,d,a,x[k+2], S34,0xC4AC5665);\n\t\ta=II(a,b,c,d,x[k+0], S41,0xF4292244);\n\t\td=II(d,a,b,c,x[k+7], S42,0x432AFF97);\n\t\tc=II(c,d,a,b,x[k+14],S43,0xAB9423A7);\n\t\tb=II(b,c,d,a,x[k+5], S44,0xFC93A039);\n\t\ta=II(a,b,c,d,x[k+12],S41,0x655B59C3);\n\t\td=II(d,a,b,c,x[k+3], S42,0x8F0CCC92);\n\t\tc=II(c,d,a,b,x[k+10],S43,0xFFEFF47D);\n\t\tb=II(b,c,d,a,x[k+1], S44,0x85845DD1);\n\t\ta=II(a,b,c,d,x[k+8], S41,0x6FA87E4F);\n\t\td=II(d,a,b,c,x[k+15],S42,0xFE2CE6E0);\n\t\tc=II(c,d,a,b,x[k+6], S43,0xA3014314);\n\t\tb=II(b,c,d,a,x[k+13],S44,0x4E0811A1);\n\t\ta=II(a,b,c,d,x[k+4], S41,0xF7537E82);\n\t\td=II(d,a,b,c,x[k+11],S42,0xBD3AF235);\n\t\tc=II(c,d,a,b,x[k+2], S43,0x2AD7D2BB);\n\t\tb=II(b,c,d,a,x[k+9], S44,0xEB86D391);\n\t\ta=AddUnsigned(a,AA);\n\t\tb=AddUnsigned(b,BB);\n\t\tc=AddUnsigned(c,CC);\n\t\td=AddUnsigned(d,DD);\n\t}\n\n\tvar temp = WordToHex(a)+WordToHex(b)+WordToHex(c)+WordToHex(d);\n\n\treturn temp.toLowerCase();\n}\n\n function encryptPassword(formname,strpwd){\n\ttry{\n\t//alert(\"Hi:\" +formname+\": \"+strpwd);\n\tvar username=eval(\"document.\"+formname+\".username.value\");\n\t//alert(\"username\"+username);\n\tvar profPass=eval(\"document.\"+formname+\".\"+strpwd+\".value\");\n\t//alert(profPass);\n\tvar con =username+\"|\"+profPass;\n\t//alert(con);\n\tvar enc = MD5(con);\n\t//alert(enc);\t\n\tvar ppf=eval(\"document.\"+formname+\".\"+strpwd);\n\tppf.value=enc;\n\t}catch(error){\n\t\t\n\t}\n}\n\n// added for CR 5034 - begin \nfunction encryptLoginPassword(key,struser,strpwd){\n\t\n\t\tvar username=struser;\n\t\tvar password=strpwd;\n\t\tvar enc =MD5(MD5(username+\"#\"+password)+\"#\"+key);\n\t\treturn enc;\n\n}  \n//added for CR 5034 - end \n</script>\n\n</head>\n\n<body>\n\n\n\n</body>\n\n</html> \n\n";
		string text4 = text3;
		WebBrowser webBrowser = new WebBrowser
		{
			ScriptErrorsSuppressed = true
		};
		string urlString = "about:blank";
		webBrowser.Navigate(urlString);
		webBrowser.Document.Write(text4);
		object[] array = new object[1];
		string text5 = string_21;
		string text6 = "|";
		array[0] = text5 + text6 + b;
		object[] array2 = array;
		HtmlDocument document = webBrowser.Document;
		string scriptName = "MD5";
		string text7 = document.InvokeScript(scriptName, array2).ToString();
		string text8 = "|";
		array2[0] = text7 + text8 + string_23;
		HtmlDocument document2 = webBrowser.Document;
		string scriptName2 = "MD5";
		string_22 = document2.InvokeScript(scriptName2, array2).ToString();
		webBrowser.Dispose();
		string[] array3 = new string[7];
		string text9 = "<html>\n<head>\n<script type=\"text/javascript\">\nvar CryptoJS = CryptoJS\n\t\t|| function(a, g) {\n\t\t\tvar m = {}, e = m.lib = {}, q = e.Base = function() {\n\t\t\t\tfunction a() {\n\t\t\t\t}\n\t\t\t\treturn {\n\t\t\t\t\textend : function(b) {\n\t\t\t\t\t\ta.prototype = this;\n\t\t\t\t\t\tvar d = new a;\n\t\t\t\t\t\tb && d.mixIn(b);\n\t\t\t\t\t\td.$super = this;\n\t\t\t\t\t\treturn d\n\t\t\t\t\t},\n\t\t\t\t\tcreate : function() {\n\t\t\t\t\t\tvar a = this.extend();\n\t\t\t\t\t\ta.init.apply(a, arguments);\n\t\t\t\t\t\treturn a\n\t\t\t\t\t},\n\t\t\t\t\tinit : function() {\n\t\t\t\t\t},\n\t\t\t\t\tmixIn : function(a) {\n\t\t\t\t\t\tfor ( var k in a)\n\t\t\t\t\t\t\ta.hasOwnProperty(k) && (this[k] = a[k]);\n\t\t\t\t\t\ta.hasOwnProperty(\"toString\")\n\t\t\t\t\t\t\t\t&& (this.toString = a.toString)\n\t\t\t\t\t},\n\t\t\t\t\tclone : function() {\n\t\t\t\t\t\treturn this.$super.extend(this)\n\t\t\t\t\t}\n\t\t\t\t}\n\t\t\t}(), r = e.WordArray = q\n\t\t\t\t\t.extend( {\n\t\t\t\t\t\tinit : function(a, b) {\n\t\t\t\t\t\t\ta = this.words = a || [];\n\t\t\t\t\t\t\tthis.sigBytes = b != g ? b : 4 * a.length\n\t\t\t\t\t\t},\n\t\t\t\t\t\ttoString : function(a) {\n\t\t\t\t\t\t\treturn (a || n).stringify(this)\n\t\t\t\t\t\t},\n\t\t\t\t\t\tconcat : function(a) {\n\t\t\t\t\t\t\tvar b = this.words, d = a.words, c = this.sigBytes, a = a.sigBytes;\n\t\t\t\t\t\t\tthis.clamp();\n\t\t\t\t\t\t\tif (c % 4)\n\t\t\t\t\t\t\t\tfor ( var i = 0; i < a; i++)\n\t\t\t\t\t\t\t\tb[c + i >>> 2] |= (d[i >>> 2] >>> 24 - 8 * (i % 4) & 255) << 24 - 8 * ((c + i) % 4);\n\t\t\t\t\t\telse if (65535 < d.length)\n\t\t\t\t\t\t\tfor (i = 0; i < a; i += 4)\n\t\t\t\t\t\t\t\tb[c + i >>> 2] = d[i >>> 2];\n\t\t\t\t\t\telse\n\t\t\t\t\t\t\tb.push.apply(b, d);\n\t\t\t\t\t\tthis.sigBytes += a;\n\t\t\t\t\t\treturn this\n\t\t\t\t\t\t},\n\t\t\t\t\t\tclamp : function() {\n\t\t\t\t\t\t\tvar k = this.words, b = this.sigBytes;\n\t\t\t\t\t\t\tk[b >>> 2] &= 4294967295 << 32 - 8 * (b % 4);\n\t\t\t\t\t\t\tk.length = a.ceil(b / 4)\n\t\t\t\t\t\t},\n\t\t\t\t\t\tclone : function() {\n\t\t\t\t\t\t\tvar a = q.clone.call(this);\n\t\t\t\t\t\t\ta.words = this.words.slice(0);\n\t\t\t\t\t\t\treturn a\n\t\t\t\t\t\t},\n\t\t\t\t\t\trandom : function(k) {\n\t\t\t\t\t\t\tfor ( var b = [], d = 0; d < k; d += 4)\n\t\t\t\t\t\t\t\tb.push(4294967296 * a.random() | 0);\n\t\t\t\t\t\t\treturn r.create(b, k)\n\t\t\t\t\t\t}\n\t\t\t\t\t}), y = m.enc = {}, n = y.Hex = {\n\t\t\t\tstringify : function(a) {\n\t\t\t\t\tfor ( var b = a.words, a = a.sigBytes, d = [], c = 0; c < a; c++) {\n\t\t\t\t\t\tvar i = b[c >>> 2] >>> 24 - 8 * (c % 4) & 255;\n\t\t\t\t\t\td.push((i >>> 4).toString(16));\n\t\t\t\t\t\td.push((i & 15).toString(16))\n\t\t\t\t\t\t}\n\t\t\t\t\treturn d.join(\"\")\n\t\t\t\t},\n\t\t\t\tparse : function(a) {\n\t\t\t\t\tfor ( var b = a.length, d = [], c = 0; c < b; c += 2)\n\t\t\t\t\t\td[c >>> 3] |= parseInt(a.substr(c, 2), 16) << 24 - 4 * (c % 8);\n\t\t\t\t\treturn r.create(d, b / 2)\n\t\t\t\t}\n\t\t\t}, l = y.Latin1 = {\n\t\t\t\tstringify : function(a) {\n\t\t\t\t\tfor ( var b = a.words, a = a.sigBytes, d = [], c = 0; c < a; c++)\n\t\t\t\t\t\td\n\t\t\t\t\t\t\t\t.push(String\n\t\t\t\t\t\t\t\t\t.fromCharCode(b[c >>> 2] >>> 24 - 8 * (c % 4) & 255));\n\t\t\t\t\treturn d.join(\"\")\n\t\t\t\t},\n\t\t\t\tparse : function(a) {\n\t\t\t\t\tfor ( var b = a.length, d = [], c = 0; c < b; c++)\n\t\t\t\t\t\td[c >>> 2] |= (a.charCodeAt(c) & 255) << 24 - 8 * (c % 4);\n\t\t\t\t\treturn r.create(d, b)\n\t\t\t\t}\n\t\t\t}, da = y.Utf8 = {\n\t\t\t\tstringify : function(a) {\n\t\t\t\t\ttry {\n\t\t\t\t\t\treturn decodeURIComponent(escape(l.stringify(a)))\n\t\t\t\t\t} catch (b) {\n\t\t\t\t\t\tthrow Error(\"Malformed UTF-8 data\");\n\t\t\t\t\t}\n\t\t\t\t},\n\t\t\t\tparse : function(a) {\n\t\t\t\t\treturn l.parse(unescape(encodeURIComponent(a)))\n\t\t\t\t}\n\t\t\t}, h = e.BufferedBlockAlgorithm = q\n\t\t\t\t\t.extend( {\n\t\t\t\t\t\treset : function() {\n\t\t\t\t\t\t\tthis._data = r.create();\n\t\t\t\t\t\t\tthis._nDataBytes = 0\n\t\t\t\t\t\t},\n\t\t\t\t\t\t_append : function(a) {\n\t\t\t\t\t\t\t\"string\" == typeof a && (a = da.parse(a));\n\t\t\t\t\t\t\tthis._data.concat(a);\n\t\t\t\t\t\t\tthis._nDataBytes += a.sigBytes\n\t\t\t\t\t\t},\n\t\t\t\t\t\t_process : function(k) {\n\t\t\t\t\t\t\tvar b = this._data, d = b.words, c = b.sigBytes, i = this.blockSize, l = c\n\t\t\t\t\t\t\t\t/ (4 * i), l = k ? a.ceil(l) : a.max(\n\t\t\t\t\t\t\t\t(l | 0) - this._minBufferSize, 0), k = l\n\t\t\t\t\t\t\t\t* i, c = a.min(4 * k, c);\n\t\t\t\t\t\tif (k) {\n\t\t\t\t\t\t\tfor ( var h = 0; h < k; h += i)\n\t\t\t\t\t\t\t\tthis._doProcessBlock(d, h);\n\t\t\t\t\t\t\th = d.splice(0, k);\n\t\t\t\t\t\t\tb.sigBytes -= c\n\t\t\t\t\t\t}\n\t\t\t\t\t\treturn r.create(h, c)\n\t\t\t\t\t},\n\t\t\t\t\tclone : function() {\n\t\t\t\t\tvar a = q.clone.call(this);\n\t\t\t\t\ta._data = this._data.clone();\n\t\t\t\t\treturn a\n\t\t\t\t},\n\t\t\t\t_minBufferSize : 0\n\t\t\t});\n\t\te.Hasher = h.extend( {\n\t\t\tinit : function() {\n\t\t\t\tthis.reset()\n\t\t\t},\n\t\t\treset : function() {\n\t\t\t\th.reset.call(this);\n\t\t\t\tthis._doReset()\n\t\t\t},\n\t\t\t\tupdate : function(a) {\n\t\t\t\t\tthis._append(a);\n\t\t\t\t\tthis._process();\n\t\t\t\t\treturn this\n\t\t\t\t},\n\t\t\t\tfinalize : function(a) {\n\t\t\t\t\ta && this._append(a);\n\t\t\t\t\tthis._doFinalize();\n\t\t\t\t\treturn this._hash\n\t\t\t\t},\n\t\t\t\tclone : function() {\n\t\t\t\t\tvar a = h.clone.call(this);\n\t\t\t\t\ta._hash = this._hash.clone();\n\t\t\t\t\treturn a\n\t\t\t\t},\n\t\t\t\tblockSize : 16,\n\t\t\t\t_createHelper : function(a) {\n\t\t\t\t\treturn function(b, d) {\n\t\t\t\t\t\treturn a.create(d).finalize(b)\n\t\t\t\t\t}\n\t\t\t\t},\n\t\t\t\t_createHmacHelper : function(a) {\n\t\t\t\t\treturn function(b, d) {\n\t\t\t\t\t\treturn ea.HMAC.create(a, d).finalize(b)\n\t\t\t\t\t}\n\t\t\t\t}\n\t\t\t});\n\t\t\tvar ea = m.algo = {};\n\t\t\treturn m\n\t\t}(Math);\n( function(a) {\n\tvar g = CryptoJS, m = g.lib, e = m.Base, q = m.WordArray, g = g.x64 = {};\n\tg.Word = e.extend( {\n\t\tinit : function(a, e) {\n\t\t\tthis.high = a;\n\t\t\tthis.low = e\n\t\t}\n\t});\n\tg.WordArray = e\n\t\t\t.extend( {\n\t\t\t\tinit : function(e, y) {\n\t\t\t\t\te = this.words = e || [];\n\t\t\t\t\tthis.sigBytes = y != a ? y : 8 * e.length\n\t\t\t\t},\n\t\t\t\ttoX32 : function() {\n\t\t\t\t\tfor ( var a = this.words, e = a.length, n = [], l = 0; l < e; l++) {\n\t\t\t\t\t\tvar g = a[l];\n\t\t\t\t\t\tn.push(g.high);\n\t\t\t\t\t\tn.push(g.low)\n\t\t\t\t\t\t}\n\t\t\t\t\treturn q.create(n, this.sigBytes)\n\t\t\t\t},\n\t\t\t\tclone : function() {\n\t\t\t\t\tfor ( var a = e.clone.call(this), g = a.words = this.words\n\t\t\t\t\t\t.slice(0), n = g.length, l = 0; l < n; l++)\n\t\t\t\t\tg[l] = g[l].clone();\n\t\t\t\treturn a\n\t\t\t\t}\n\t\t\t})\n})();\n( function() {\n\tfunction a() {\n\t\treturn q.create.apply(q, arguments)\n\t}\n\tvar g = CryptoJS, m = g.lib.Hasher, e = g.x64, q = e.Word, r = e.WordArray, e = g.algo, y = [\n\t\t\ta(1116352408, 3609767458), a(1899447441, 602891725),\n\t\t\ta(3049323471, 3964484399), a(3921009573, 2173295548),\n\t\t\ta(961987163, 4081628472), a(1508970993, 3053834265),\n\t\t\ta(2453635748, 2937671579), a(2870763221, 3664609560),\n\t\t\ta(3624381080, 2734883394), a(310598401, 1164996542),\n\t\t\ta(607225278, 1323610764), a(1426881987, 3590304994),\n\t\t\ta(1925078388, 4068182383), a(2162078206, 991336113),\n\t\t\ta(2614888103, 633803317), a(3248222580, 3479774868),\n\t\t\ta(3835390401, 2666613458), a(4022224774, 944711139),\n\t\t\ta(264347078, 2341262773), a(604807628, 2007800933),\n\t\t\ta(770255983, 1495990901), a(1249150122, 1856431235),\n\t\t\ta(1555081692, 3175218132), a(1996064986, 2198950837),\n\t\t\ta(2554220882, 3999719339), a(2821834349, 766784016),\n\t\t\ta(2952996808, 2566594879), a(3210313671, 3203337956),\n\t\t\ta(3336571891, 1034457026), a(3584528711, 2466948901),\n\t\t\ta(113926993, 3758326383), a(338241895, 168717936),\n\t\t\ta(666307205, 1188179964), a(773529912, 1546045734),\n\t\t\ta(1294757372, 1522805485), a(1396182291, 2643833823),\n\t\t\ta(1695183700, 2343527390), a(1986661051, 1014477480),\n\t\t\ta(2177026350, 1206759142), a(2456956037, 344077627),\n\t\t\ta(2730485921, 1290863460), a(2820302411, 3158454273),\n\t\t\ta(3259730800, 3505952657), a(3345764771, 106217008),\n\t\t\ta(3516065817, 3606008344), a(3600352804, 1432725776),\n\t\t\ta(4094571909, 1467031594), a(275423344, 851169720),\n\t\t\ta(430227734, 3100823752), a(506948616, 1363258195),\n\t\t\ta(659060556, 3750685593), a(883997877, 3785050280),\n\t\t\ta(958139571, 3318307427), a(1322822218, 3812723403),\n\t\t\ta(1537002063, 2003034995), a(1747873779, 3602036899),\n\t\t\ta(1955562222, 1575990012), a(2024104815, 1125592928),\n\t\t\ta(2227730452, 2716904306), a(2361852424, 442776044),\n\t\t\ta(2428436474, 593698344), a(2756734187, 3733110249),\n\t\t\ta(3204031479, 2999351573), a(3329325298, 3815920427),\n\t\t\ta(3391569614, 3928383900), a(3515267271, 566280711),\n\t\t\ta(3940187606, 3454069534), a(4118630271, 4000239992),\n\t\t\ta(116418474, 1914138554), a(174292421, 2731055270),\n\t\t\ta(289380356, 3203993006), a(460393269, 320620315),\n\t\t\ta(685471733, 587496836), a(852142971, 1086792851),\n\t\t\ta(1017036298, 365543100), a(1126000580, 2618297676),\n\t\t\ta(1288033470, 3409855158), a(1501505948, 4234509866),\n\t\t\ta(1607167915, 987167468), a(1816402316, 1246189591) ], n = [];\n\t( function() {\n\t\tfor ( var l = 0; 80 > l; l++)\n\t\t\tn[l] = a()\n\t})();\n\te = e.SHA512 = m\n\t\t\t.extend( {\n\t\t\t\t_doReset : function() {\n\t\t\t\t\tthis._hash = r.create( [ a(1779033703, 4089235720),\n\t\t\t\t\t\t\ta(3144134277, 2227873595),\n\t\t\t\t\t\t\ta(1013904242, 4271175723),\n\t\t\t\t\t\t\ta(2773480762, 1595750129),\n\t\t\t\t\t\t\ta(1359893119, 2917565137),\n\t\t\t\t\t\t\ta(2600822924, 725511199), a(528734635, 4215389547),\n\t\t\t\t\t\t\ta(1541459225, 327033209) ])\n\t\t\t\t},\n\t\t\t\t_doProcessBlock : function(a, e) {\n\t\t\t\t\tfor ( var h = this._hash.words, g = h[0], k = h[1], b = h[2], d = h[3], c = h[4], i = h[5], m = h[6], h = h[7], q = g.high, r = g.low, W = k.high, K = k.low, X = b.high, L = b.low, Y = d.high, M = d.low, Z = c.high, N = c.low, $ = i.high, O = i.low, aa = m.high, P = m.low, ba = h.high, Q = h.low, t = q, o = r, E = W, C = K, F = X, D = L, T = Y, G = M, u = Z, p = N, R = $, H = O, S = aa, I = P, U = ba, J = Q, v = 0; 80 > v; v++) {\n\t\t\t\t\t\tvar z = n[v];\n\t\t\t\t\t\tif (16 > v)\n\t\t\t\t\t\t\tvar s = z.high = a[e + 2 * v] | 0, f = z.low = a[e\n\t\t\t\t\t\t\t\t+ 2 * v + 1] | 0;\n\t\t\t\t\t\telse {\n\t\t\t\t\t\t\tvar s = n[v - 15], f = s.high, w = s.low, s = (w << 31 | f >>> 1)\n\t\t\t\t\t\t\t\t\t^ (w << 24 | f >>> 8) ^ f >>> 7, w = (f << 31 | w >>> 1)\n\t\t\t\t\t\t\t\t\t^ (f << 24 | w >>> 8) ^ (f << 25 | w >>> 7), B = n[v - 2], f = B.high, j = B.low, B = (j << 13 | f >>> 19)\n\t\t\t\t\t\t\t\t\t^ (f << 3 | j >>> 29) ^ f >>> 6, j = (f << 13 | j >>> 19)\n\t\t\t\t\t\t\t\t\t^ (j << 3 | f >>> 29) ^ (f << 26 | j >>> 6), f = n[v - 7], V = f.high, A = n[v - 16], x = A.high, A = A.low, f = w\n\t\t\t\t\t\t\t\t\t+ f.low, s = s + V\n\t\t\t\t\t\t\t\t\t+ (f >>> 0 < w >>> 0 ? 1 : 0), f = f + j, s = s\n\t\t\t\t\t\t\t\t\t+ B + (f >>> 0 < j >>> 0 ? 1 : 0), f = f\n\t\t\t\t\t\t\t\t\t+ A, s = s + x\n\t\t\t\t\t\t\t\t\t+ (f >>> 0 < A >>> 0 ? 1 : 0);\n\t\t\t\t\t\t\tz.high = s;\n\t\t\t\t\t\t\tz.low = f\n\t\t\t\t\t\t}\n\t\t\t\t\t\tvar V = u & R ^ ~u & S, A = p & H ^ ~p & I, z = t & E\n\t\t\t\t\t\t\t\t^ t & F ^ E & F, fa = o & C ^ o & D ^ C & D, w = (o << 4 | t >>> 28)\n\t\t\t\t\t\t\t\t^ (t << 30 | o >>> 2) ^ (t << 25 | o >>> 7), B = (t << 4 | o >>> 28)\n\t\t\t\t\t\t\t\t^ (o << 30 | t >>> 2) ^ (o << 25 | t >>> 7), j = y[v], ga = j.high, ca = j.low, j = J\n\t\t\t\t\t\t\t\t+ ((u << 18 | p >>> 14) ^ (u << 14 | p >>> 18) ^ (p << 23 | u >>> 9)), x = U\n\t\t\t\t\t\t\t\t+ ((p << 18 | u >>> 14) ^ (p << 14 | u >>> 18) ^ (u << 23 | p >>> 9))\n\t\t\t\t\t\t\t\t+ (j >>> 0 < J >>> 0 ? 1 : 0), j = j + A, x = x\n\t\t\t\t\t\t\t\t+ V + (j >>> 0 < A >>> 0 ? 1 : 0), j = j + ca, x = x\n\t\t\t\t\t\t\t\t+ ga + (j >>> 0 < ca >>> 0 ? 1 : 0), j = j + f, x = x\n\t\t\t\t\t\t\t\t+ s + (j >>> 0 < f >>> 0 ? 1 : 0), f = B + fa, z = w\n\t\t\t\t\t\t\t\t+ z + (f >>> 0 < B >>> 0 ? 1 : 0), U = S, J = I, S = R, I = H, R = u, H = p, p = G\n\t\t\t\t\t\t\t\t+ j | 0, u = T + x\n\t\t\t\t\t\t\t\t+ (p >>> 0 < G >>> 0 ? 1 : 0) | 0, T = F, G = D, F = E, D = C, E = t, C = o, o = j\n+ f | 0, t = x + z\n\t\t\t\t\t\t\t\t+ (o >>> 0 < j >>> 0 ? 1 : 0) | 0\n\t\t\t\t\t}\n\t\t\t\t\tr = g.low = r + o | 0;\n\t\t\t\t\tg.high = q + t + (r >>> 0 < o >>> 0 ? 1 : 0) | 0;\n\t\t\t\t\tK = k.low = K + C | 0;\n\t\t\t\t\tk.high = W + E + (K >>> 0 < C >>> 0 ? 1 : 0) | 0;\n\t\t\t\t\tL = b.low = L + D | 0;\n\t\t\t\t\tb.high = X + F + (L >>> 0 < D >>> 0 ? 1 : 0) | 0;\n\t\t\t\t\tM = d.low = M + G | 0;\n\t\t\t\t\td.high = Y + T + (M >>> 0 < G >>> 0 ? 1 : 0) | 0;\n\t\t\t\t\tN = c.low = N + p | 0;\n\t\t\t\t\tc.high = Z + u + (N >>> 0 < p >>> 0 ? 1 : 0) | 0;\n\t\t\t\t\tO = i.low = O + H | 0;\n\t\t\t\t\ti.high = $ + R + (O >>> 0 < H >>> 0 ? 1 : 0) | 0;\n\t\t\t\t\tP = m.low = P + I | 0;\n\t\t\t\t\tm.high = aa + S + (P >>> 0 < I >>> 0 ? 1 : 0) | 0;\n\t\t\t\t\tQ = h.low = Q + J | 0;\n\t\t\t\t\th.high = ba + U + (Q >>> 0 < J >>> 0 ? 1 : 0) | 0\n\t\t\t\t},\n\t\t\t\t_doFinalize : function() {\n\t\t\t\t\tvar a = this._data, e = a.words, h = 8 * this._nDataBytes, g = 8 * a.sigBytes;\n\t\t\t\t\te[g >>> 5] |= 128 << 24 - g % 32;\n\t\t\t\t\te[(g + 128 >>> 10 << 5) + 31] = h;\n\t\t\t\t\ta.sigBytes = 4 * e.length;\n\t\t\t\t\tthis._process();\n\t\t\t\t\tthis._hash = this._hash.toX32()\n\t\t\t\t},\n\t\t\t\tblockSize : 32\n\t\t\t});\n\tg.SHA512 = m._createHelper(e);\n\tg.HmacSHA512 = m._createHmacHelper(e)\n})();\n\n//added for Sha2 - begin\nfunction encryptSha2LoginPassword(key,struser,strpwd){\n\tvar username=struser;\n\tvar password=strpwd;\n\tvar shaHash =CryptoJS.SHA512(struser+\"#\"+strpwd);\n\tvar encString = CryptoJS.SHA512(shaHash +\"#\"+key) ;\n\treturn encString;\n\n}\n\n\nfunction encryptSha2ProfilePassword(key,username,strpwd){\n\ttry{\n\tvar shaHash =CryptoJS.SHA512(username+\"|\"+strpwd); \n\tvar encString =CryptoJS.SHA512(shaHash+\"|\"+key);\nreturn encString; \nvar username=eval(\"document.\"+formname+\".username.value\");\n\tvar profPass=eval(\"document.\"+formname+\".\"+strpwd+\".value\");\n\tvar shaHash =username+\"|\"+profPass;\n\tvar encString = CryptoJS.SHA512(shaHash)\n\t//var ppf=eval(\"document.\"+formname+\".\"+strpwd);\n\tvar ppf=eval(\"document.\"+formname+\".\"+\"profileSHAPassword\");\n\tppf.value=encString;\n\t}catch(error){\n\t}\n\t}\n\t// end for Sha2 - end\n</script>\n\n\n\n<script>\n\nfunction submitLogin()\n\t{\n\tvar username =\"";
		array3[0] = text9;
		array3[1] = string_21;
		string text10 = "\";\n\tvar password= \"";
		array3[2] = text10;
		array3[3] = b;
		string text11 = "\";\n\tvar md5keystring= \"";
		array3[4] = text11;
		array3[5] = string_23;
		string text12 = "\";\n\t//added for Sha2\n\tvar encSha2SaltPass=encryptSha2ProfilePassword(md5keystring,username,password);\n\tdocument.quickLookForm.sha2password.value=encSha2SaltPass;\n\treturn encSha2SaltPass;\n\n}\n\t</script>\n\n<script>\n\nfunction Login()\n\t{\n\tvar Pass=document.quickLookForm.sha2password.value;\n\treturn Pass;\n\n}\n\t</script>\n\n</head>\n\n<body>\n\n\n\n<form name=\"quickLookForm\" method=\"post\" >\n\n<input type=\"hidden\" name=\"sha2password\" value=\"\">\n\n</form>\n\n</body>\n\n</html> \n\n";
		array3[6] = text12;
		string text13 = string.Concat(array3);
		WebBrowser webBrowser2 = new WebBrowser
		{
			ScriptErrorsSuppressed = true
		};
		string urlString2 = "about:blank";
		webBrowser2.Navigate(urlString2);
		webBrowser2.Document.Write(text13);
		HtmlDocument document3 = webBrowser2.Document;
		string scriptName3 = "submitLogin";
		document3.InvokeScript(scriptName3).ToString();
		HtmlDocument document4 = webBrowser2.Document;
		string scriptName4 = "Login";
		string_20 = document4.InvokeScript(scriptName4).ToString();
		return null;
	}

	public static string serial(string formname, string formdata)
	{
		string text = "";
		try
		{
			IEnumerator enumerator = null;
			IEnumerator enumerator2 = null;
			string text2 = formdata;
			string oldValue = "document.forms[0].submit();";
			formdata = text2.Replace(oldValue, "");
			string text3 = formdata;
			string oldValue2 = ".submit();";
			formdata = text3.Replace(oldValue2, "");
			WebBrowser webBrowser = new WebBrowser
			{
				ScriptErrorsSuppressed = true
			};
			string urlString = "about:blank";
			webBrowser.Navigate(urlString);
			webBrowser.Document.Write(formdata);
			HtmlDocument document = webBrowser.Document;
			webBrowser.Dispose();
			HtmlElement htmlElement;
			if (Operators.CompareString(formname, "", TextCompare: true) == 0)
			{
				string tagName = "form";
				htmlElement = document.GetElementsByTagName(tagName)[0];
			}
			else
			{
				htmlElement = document.GetElementById(formname);
			}
			HtmlElement htmlElement2 = htmlElement;
			string tagName2 = "input";
			HtmlElementCollection elementsByTagName = htmlElement2.GetElementsByTagName(tagName2);
			int num = 0;
			try
			{
				foreach (HtmlElement item in elementsByTagName)
				{
					if (Operators.CompareString(item.Name, "", TextCompare: true) != 0)
					{
						string name = item.Name;
						string value = "reset";
						if (!name.Contains(value))
						{
							string name2 = item.Name;
							string value2 = "submit";
							if (!name2.Contains(value2))
							{
								string attributeName = "type";
								string attribute = item.GetAttribute(attributeName);
								string right = "radio";
								if (Operators.CompareString(attribute, right, TextCompare: true) != 0)
								{
									string name3 = item.Name;
									string text4 = "=";
									string attributeName2 = "value";
									string text5 = name3 + text4 + HttpUtility.UrlEncode(item.GetAttribute(attributeName2));
									string text6;
									if (num == 0)
									{
										text6 = text5;
									}
									else
									{
										string text7 = text;
										string text8 = "&";
										text6 = text7 + text8 + text5;
									}
									text = text6;
								}
								else
								{
									string attributeName3 = "checked";
									string attribute2 = item.GetAttribute(attributeName3);
									string right2 = "checked";
									if (Operators.CompareString(attribute2, right2, TextCompare: true) == 0)
									{
										string name4 = item.Name;
										string text9 = "=";
										string attributeName4 = "value";
										string text10 = name4 + text9 + HttpUtility.UrlEncode(item.GetAttribute(attributeName4));
										string text11;
										if (num == 0)
										{
											text11 = text10;
										}
										else
										{
											string text12 = text;
											string text13 = "&";
											text11 = text12 + text13 + text10;
										}
										text = text11;
									}
								}
							}
						}
					}
					num++;
				}
			}
			finally
			{
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
			string tagName3 = "select";
			HtmlElementCollection elementsByTagName2 = htmlElement2.GetElementsByTagName(tagName3);
			try
			{
				foreach (HtmlElement item2 in elementsByTagName2)
				{
					IEnumerator enumerator5 = null;
					HtmlElement htmlElement5 = item2;
					string attributeName5 = "name";
					string attribute3 = htmlElement5.GetAttribute(attributeName5);
					try
					{
						string tagName4 = "option";
						foreach (HtmlElement item3 in htmlElement5.GetElementsByTagName(tagName4))
						{
							string attributeName6 = "selected";
							string attribute4 = item3.GetAttribute(attributeName6);
							string right3 = "True";
							if (Operators.CompareString(attribute4, right3, TextCompare: true) == 0)
							{
								string[] array = new string[5] { text, null, null, null, null };
								string text14 = "&";
								array[1] = text14;
								array[2] = attribute3;
								string text15 = "=";
								array[3] = text15;
								string attributeName7 = "value";
								array[4] = HttpUtility.UrlEncode(item3.GetAttribute(attributeName7));
								text = string.Concat(array);
							}
						}
					}
					finally
					{
						if (enumerator5 is IDisposable)
						{
							(enumerator5 as IDisposable).Dispose();
						}
					}
				}
			}
			finally
			{
				if (enumerator2 is IDisposable)
				{
					(enumerator2 as IDisposable).Dispose();
				}
			}
			return text;
		}
		catch (Exception)
		{
			return text;
		}
	}

	public void ChangeTextBoxcasing(string st)
	{
		try
		{
			Invoke(new agr1(ChangeTextcasingi), st);
		}
		catch (Exception)
		{
		}
	}

	public void ChangeTextcasingi(string st)
	{
		Label label = lblStatus1;
		string text = "Processing Bank Step :";
		label.Text = text + st;
	}

	private void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
	{
	}

	private void B0AAA(object sender, WebBrowserNavigatingEventArgs e)
	{
		try
		{
			string text = "";
			if (webBrowser.Document != null)
			{
				text = webBrowser.DocumentText;
			}
			string text2 = e.Url.ToString();
			string value = "=https://www.irctc.co.in/eticketing/BankResponse";
			if (text2.IndexOf(value) >= 0)
			{
				string_24 = text;
				return;
			}
			string text3 = e.Url.ToString();
			string value2 = "https://retail.onlinesbi.com/retail/quicktransferdetails.htm";
			if (text3.IndexOf(value2) >= 0)
			{
				timer_0.Enabled = true;
				timer_0.Interval = 500;
			}
		}
		catch (Exception)
		{
		}
	}

	private void C0AA0(object sender, WebBrowserProgressChangedEventArgs e)
	{
		try
		{
			int num = (int)e.MaximumProgress;
			int num2 = (int)e.CurrentProgress;
			progressBar1.Maximum = num;
			if (num2 > 0 && num2 <= num)
			{
				progressBar1.Value = num2;
			}
		}
		catch (Exception)
		{
		}
	}

	private void btnGenrte1_Click(object sender, EventArgs e)
	{
		string_2 = cmbBanks1.SelectedItem.ToString();
		string_3 = dictionary_0[string_2];
		if (string_3.Length >= 125)
		{
			string text = string_3;
			string[] array = new string[1];
			string text2 = "||";
			array[0] = text2;
			text.Split(array, StringSplitOptions.None);
			Button button = btnGenrte1;
			string text3 = "Getting OTP..";
			button.Text = text3;
			btnGenrte1.Enabled = false;
			if (!rdGeneral.Checked)
			{
				if (rdLadies.Checked)
				{
					if (RndmNo.Text == "")
					{
						string text4 = "For Offline OTP Insert Random No";
						string caption = "Fetch OTP";
						MessageBox.Show(text4, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
					else
					{
						textShowOtp1.Text = StClass.classSBI_0.getOffline_Token(string_3, RndmNo.Text);
					}
				}
			}
			else
			{
				ThreadPool.QueueUserWorkItem(method_7);
			}
		}
		else
		{
			string text5 = "OTP was not By-Passed for ";
			string text6 = text5 + string_2;
			string caption2 = "Not By-Passed";
			MessageBox.Show(text6, caption2, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			string_2 = "";
			string_3 = "";
			cmbBanks1.SelectedIndex = 0;
		}
	}

	private void btnDeregs_Click(object sender, EventArgs e)
	{
		if (!StClass.classSBI_0.btnDeregs_Click(string_3))
		{
			return;
		}
		string[] array = new string[5] { string_4, null, null, null, null };
		string text = "||";
		array[1] = text;
		array[2] = string_5;
		string text2 = "||";
		array[3] = text2;
		array[4] = string_6;
		string_3 = string.Concat(array);
		string_1 = string_3;
		string string_ = "SBI";
		method_5(string_);
		Staticm.method_36();
		dictionary_0 = new Dictionary<string, string>();
		Dictionary<string, string> dictionary = Staticm.SBI();
		foreach (string key in dictionary.Keys)
		{
			dictionary_0.Add(key, dictionary[key]);
		}
		cmbBanks1.SelectedIndex = 0;
		PassOtpGroupBx1.Visible = false;
		GetOtpGroupBx1.Visible = false;
	}

	private void rdGeneral_CheckedChanged(object sender, EventArgs e)
	{
		RndmNo.Enabled = false;
		if (rdLadies.Checked)
		{
			RndmNo.Enabled = true;
		}
	}

	public void smethod_4ThorughHttp()
	{
		WebProxy webProxy_ = null;
		string string_ = "";
		string string_2 = "";
		string text = "https://retail.onlinesbi.com/retail/login.htm";
		string text2 = "https://www.onlinesbi.com/";
		string string_3 = text2;
		string text3 = "";
		Class47.method_11(text, text3, string_3, 1, webProxy_, ref cookieContainer_0, bool_1: true, 50000, ref string_, ref string_2);
		string string_4 = string_;
		string text4 = "https://retail.onlinesbi.com/retail/loginsubmit.htm";
		string text5 = text4;
		string string_5 = text5;
		smethod_9S(this.string_4, this.string_5, string_4);
		string[] array = new string[7];
		string text6 = "hdnKioskID=&hdnKModeUserName=&errorCode=&isGoogleCaptchaReq=&userType=&lockCount=&captchaDisplayCount=&unknownUserlockCount=&bankCode=0&browserName=Mozilla%2F5.0+%28Windows+NT+6.3%3B+Win64%3B+x64%29+AppleWebKit%2F537.36+%28KHTML%2C+like+Gecko%29+Chrome%2F64.0.3282.140+Safari%2F537.36&shapassword=";
		array[0] = text6;
		array[1] = string_20;
		string text7 = "&language=english&userName=";
		array[2] = text7;
		array[3] = string_21;
		string text8 = "&password0=Dummy%40123&password=";
		array[4] = text8;
		array[5] = string_22;
		string text9 = "&password1=Dummy%40123";
		array[6] = text9;
		string text10 = string.Concat(array);
		Class47.method_11(text5, text10, string_5, 1, webProxy_, ref cookieContainer_0, bool_1: true, 50000, ref string_, ref string_2);
		string text11 = string_;
		string value = "Transaction Accounts";
		if (text11.Contains(value))
		{
			string text12 = "https://retail.onlinesbi.com/retail/mypage.htm";
			string string_6 = text12;
			string text13 = "https://retail.onlinesbi.com/retail/enablehighsecuritylvt.htm";
			text5 = text13;
			string text14 = string_;
			string text15 = string_;
			string value2 = "<form name=\"logoutform";
			string text16 = text14.Substring(text15.IndexOf(value2) - 1);
			string value3 = "</form";
			string text17 = serial("", text16.Substring(0, text16.IndexOf(value3) + 9)) ?? "";
			if (Class47.method_11(text5, text17, string_6, 1, webProxy_, ref cookieContainer_0, bool_1: true, 50000, ref string_, ref string_2))
			{
				string string_7 = text5;
				string text18 = "https://retail.onlinesbi.com/retail/profileverifypasswordconfirm.htm";
				text5 = text18;
				smethod_10S(this.string_4, textShowOtp4.Text, string_);
				string text19 = string_;
				string text20 = string_;
				string value4 = "<form name=\"logoutform";
				string text21 = text19.Substring(text20.IndexOf(value4) - 1);
				string value5 = "</form";
				string formdata = text21.Substring(0, text21.IndexOf(value5) + 9);
				string[] array2 = new string[8];
				string text22 = "mvkbLang=English&language=&profilePasswordenc=&TPTransactionName=&username=";
				array2[0] = text22;
				array2[1] = string_21;
				string text23 = "&shaProfilePasswd=";
				array2[2] = text23;
				array2[3] = string_20;
				string text24 = "&ppSelect=English&profilePassword=";
				array2[4] = text24;
				array2[5] = string_22;
				string text25 = "&virkualKeyHiddenVar=false&";
				array2[6] = text25;
				array2[7] = serial("", formdata);
				string text26 = string.Concat(array2);
				if (Class47.method_11(text5, text26, string_7, 1, webProxy_, ref cookieContainer_0, bool_1: true, 50000, ref string_, ref string_2))
				{
					string text27 = string_;
					string text28 = "error";
					bool flag = text27 == text28;
					string text29 = string_;
					string value6 = "Profile Password is invalid";
					bool flag2 = flag | (text29.IndexOf(value6) > 0);
					string text30 = string_;
					string value7 = "Due to some technical problems we are unable to process your request";
					if (flag2 | (text30.IndexOf(value7) > 0))
					{
						string text31 = "You Got Some Error, Retry Deregister process,Thanks";
						MessageBox.Show(text31);
					}
					else
					{
						string string_8 = text5;
						string text32 = "https://retail.onlinesbi.com/retail/enablehighsecuritylvtconfirm.htm";
						text5 = text32;
						string text33 = "processUrl=enablehighsecuritylvtconfirm.htm&transactionName=&deregsms=deregsms&smartotpflag=Y&sfAuth=SmartOTP&highSecurityLvtStatus=N&highSecurityLvtStatusMerchant=No&highSecurityOtpStatus=1&modesms=modesms";
						string text34 = string_;
						string text35 = string_;
						string value8 = "<form name=\"logoutform";
						string text36 = text34.Substring(text35.IndexOf(value8) - 1);
						string value9 = "</form";
						string formdata2 = text36.Substring(0, text36.IndexOf(value9) + 9);
						string text37 = "&";
						string text38 = text33 + text37 + serial("", formdata2);
						if (Class47.method_11(text5, text38, string_8, 1, webProxy_, ref cookieContainer_0, bool_1: true, 50000, ref string_, ref string_2))
						{
							string text39 = "You Have Sucessfully Deregister from OTP Bypass service, Sucessfully Logout,Thanks";
							MessageBox.Show(text39);
						}
					}
				}
			}
		}
		string text40 = "https://retail.onlinesbi.com/retail/logout.htm";
		Class47.method_11(text40, "", text5, 1, webProxy_, ref cookieContainer_0, bool_1: true, 50000, ref string_, ref string_2);
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.button2 = new System.Windows.Forms.Button();
		this.label2 = new System.Windows.Forms.Label();
		this.PassOtpGroupBx1 = new System.Windows.Forms.GroupBox();
		this.lblSelect = new System.Windows.Forms.Label();
		this.txtOTP1 = new System.Windows.Forms.TextBox();
		this.btnSubmit1 = new System.Windows.Forms.Button();
		this.lblOTP = new System.Windows.Forms.Label();
		this.btnNew1 = new System.Windows.Forms.Button();
		this.lblCreate = new System.Windows.Forms.Label();
		this.btnBrowse1 = new System.Windows.Forms.Button();
		this.GetOtpGroupBx1 = new System.Windows.Forms.GroupBox();
		this.RndmNo = new System.Windows.Forms.TextBox();
		this.label1 = new System.Windows.Forms.Label();
		this.rdLadies = new System.Windows.Forms.RadioButton();
		this.rdGeneral = new System.Windows.Forms.RadioButton();
		this.groupBox2 = new System.Windows.Forms.GroupBox();
		this.label3 = new System.Windows.Forms.Label();
		this.textShowOtp4 = new System.Windows.Forms.TextBox();
		this.btnDeregs = new System.Windows.Forms.Button();
		this.textShowOtp1 = new System.Windows.Forms.TextBox();
		this.btnGenrte1 = new System.Windows.Forms.Button();
		this.lblTime = new System.Windows.Forms.Label();
		this.cmbBanks1 = new System.Windows.Forms.ComboBox();
		this.lblStatus1 = new System.Windows.Forms.Label();
		this.button1 = new System.Windows.Forms.Button();
		this.label7 = new System.Windows.Forms.Label();
		this.webBrowser = new System.Windows.Forms.WebBrowser();
		this.progressBar1 = new System.Windows.Forms.ProgressBar();
		this.timer_0 = new System.Windows.Forms.Timer(this.components);
		this.groupBox1.SuspendLayout();
		this.PassOtpGroupBx1.SuspendLayout();
		this.GetOtpGroupBx1.SuspendLayout();
		this.groupBox2.SuspendLayout();
		base.SuspendLayout();
		this.groupBox1.Controls.Add(this.button2);
		this.groupBox1.Controls.Add(this.label2);
		this.groupBox1.Controls.Add(this.PassOtpGroupBx1);
		this.groupBox1.Controls.Add(this.GetOtpGroupBx1);
		this.groupBox1.Controls.Add(this.lblTime);
		this.groupBox1.Controls.Add(this.cmbBanks1);
		this.groupBox1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.groupBox1.ForeColor = System.Drawing.Color.Black;
		this.groupBox1.Location = new System.Drawing.Point(2, 2);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(461, 226);
		this.groupBox1.TabIndex = 0;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "By-Pass SBI";
		this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
		this.button2.ImageAlign = System.Drawing.ContentAlignment.TopRight;
		this.button2.Location = new System.Drawing.Point(393, 238);
		this.button2.Margin = new System.Windows.Forms.Padding(2);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(82, 24);
		this.button2.TabIndex = 1179;
		this.button2.Text = "Help";
		this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
		this.button2.UseVisualStyleBackColor = true;
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(6, 243);
		this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(262, 14);
		this.label2.TabIndex = 1178;
		this.label2.Text = "For By-Pass Process Help Click On Help Button";
		this.PassOtpGroupBx1.Controls.Add(this.lblSelect);
		this.PassOtpGroupBx1.Controls.Add(this.txtOTP1);
		this.PassOtpGroupBx1.Controls.Add(this.btnSubmit1);
		this.PassOtpGroupBx1.Controls.Add(this.lblOTP);
		this.PassOtpGroupBx1.Controls.Add(this.btnNew1);
		this.PassOtpGroupBx1.Controls.Add(this.lblCreate);
		this.PassOtpGroupBx1.Controls.Add(this.btnBrowse1);
		this.PassOtpGroupBx1.ForeColor = System.Drawing.Color.Black;
		this.PassOtpGroupBx1.Location = new System.Drawing.Point(80, 39);
		this.PassOtpGroupBx1.Name = "PassOtpGroupBx1";
		this.PassOtpGroupBx1.Size = new System.Drawing.Size(380, 175);
		this.PassOtpGroupBx1.TabIndex = 1177;
		this.PassOtpGroupBx1.TabStop = false;
		this.PassOtpGroupBx1.Text = "By-Pass OTP";
		this.PassOtpGroupBx1.Visible = false;
		this.lblSelect.AutoSize = true;
		this.lblSelect.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblSelect.ForeColor = System.Drawing.Color.Black;
		this.lblSelect.Location = new System.Drawing.Point(81, 20);
		this.lblSelect.Name = "lblSelect";
		this.lblSelect.Size = new System.Drawing.Size(191, 16);
		this.lblSelect.TabIndex = 36;
		this.lblSelect.Text = "Select Existing By-Pass File: ";
		this.txtOTP1.BackColor = System.Drawing.Color.White;
		this.txtOTP1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtOTP1.ForeColor = System.Drawing.Color.Black;
		this.txtOTP1.Location = new System.Drawing.Point(278, 116);
		this.txtOTP1.MaxLength = 20;
		this.txtOTP1.Name = "txtOTP1";
		this.txtOTP1.Size = new System.Drawing.Size(95, 20);
		this.txtOTP1.TabIndex = 27;
		this.txtOTP1.Visible = false;
		this.btnSubmit1.BackColor = System.Drawing.Color.Transparent;
		this.btnSubmit1.ForeColor = System.Drawing.Color.Black;
		this.btnSubmit1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnSubmit1.Location = new System.Drawing.Point(277, 142);
		this.btnSubmit1.Name = "btnSubmit1";
		this.btnSubmit1.Size = new System.Drawing.Size(97, 24);
		this.btnSubmit1.TabIndex = 40;
		this.btnSubmit1.Text = "      Submit";
		this.btnSubmit1.UseVisualStyleBackColor = false;
		this.btnSubmit1.Visible = false;
		this.btnSubmit1.Click += new System.EventHandler(BtnSubmit1_Click);
		this.lblOTP.AutoSize = true;
		this.lblOTP.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblOTP.ForeColor = System.Drawing.Color.Black;
		this.lblOTP.Location = new System.Drawing.Point(166, 120);
		this.lblOTP.Name = "lblOTP";
		this.lblOTP.Size = new System.Drawing.Size(84, 16);
		this.lblOTP.TabIndex = 34;
		this.lblOTP.Text = "Enter OTP : ";
		this.btnNew1.BackColor = System.Drawing.Color.Transparent;
		this.btnNew1.ForeColor = System.Drawing.Color.Black;
		this.btnNew1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnNew1.Location = new System.Drawing.Point(278, 66);
		this.btnNew1.Name = "btnNew1";
		this.btnNew1.Size = new System.Drawing.Size(97, 25);
		this.btnNew1.TabIndex = 39;
		this.btnNew1.Text = "     Bypass New";
		this.btnNew1.UseVisualStyleBackColor = false;
		this.btnNew1.Click += new System.EventHandler(btnNew1_Click);
		this.lblCreate.AutoSize = true;
		this.lblCreate.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblCreate.ForeColor = System.Drawing.Color.Black;
		this.lblCreate.Location = new System.Drawing.Point(81, 69);
		this.lblCreate.Name = "lblCreate";
		this.lblCreate.Size = new System.Drawing.Size(171, 16);
		this.lblCreate.TabIndex = 37;
		this.lblCreate.Text = "Create New By-Pass File: ";
		this.btnBrowse1.BackColor = System.Drawing.Color.Transparent;
		this.btnBrowse1.ForeColor = System.Drawing.Color.Black;
		this.btnBrowse1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnBrowse1.Location = new System.Drawing.Point(278, 17);
		this.btnBrowse1.Name = "btnBrowse1";
		this.btnBrowse1.Size = new System.Drawing.Size(97, 25);
		this.btnBrowse1.TabIndex = 38;
		this.btnBrowse1.Text = "      Browse";
		this.btnBrowse1.UseVisualStyleBackColor = false;
		this.btnBrowse1.Click += new System.EventHandler(btnBrowse1_Click);
		this.GetOtpGroupBx1.Controls.Add(this.RndmNo);
		this.GetOtpGroupBx1.Controls.Add(this.label1);
		this.GetOtpGroupBx1.Controls.Add(this.rdLadies);
		this.GetOtpGroupBx1.Controls.Add(this.rdGeneral);
		this.GetOtpGroupBx1.Controls.Add(this.groupBox2);
		this.GetOtpGroupBx1.Controls.Add(this.textShowOtp1);
		this.GetOtpGroupBx1.Controls.Add(this.btnGenrte1);
		this.GetOtpGroupBx1.ForeColor = System.Drawing.Color.Black;
		this.GetOtpGroupBx1.Location = new System.Drawing.Point(93, 39);
		this.GetOtpGroupBx1.Name = "GetOtpGroupBx1";
		this.GetOtpGroupBx1.Size = new System.Drawing.Size(368, 175);
		this.GetOtpGroupBx1.TabIndex = 1174;
		this.GetOtpGroupBx1.TabStop = false;
		this.GetOtpGroupBx1.Text = "Genrate OTP";
		this.RndmNo.BackColor = System.Drawing.Color.White;
		this.RndmNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.RndmNo.ForeColor = System.Drawing.Color.Black;
		this.RndmNo.Location = new System.Drawing.Point(259, 16);
		this.RndmNo.MaxLength = 20;
		this.RndmNo.Name = "RndmNo";
		this.RndmNo.Size = new System.Drawing.Size(101, 20);
		this.RndmNo.TabIndex = 47;
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.ForeColor = System.Drawing.Color.Black;
		this.label1.Location = new System.Drawing.Point(4, 17);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(61, 14);
		this.label1.TabIndex = 46;
		this.label1.Text = "OTP Type:";
		this.rdLadies.AutoSize = true;
		this.rdLadies.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.rdLadies.ForeColor = System.Drawing.Color.Black;
		this.rdLadies.Location = new System.Drawing.Point(159, 15);
		this.rdLadies.Name = "rdLadies";
		this.rdLadies.Size = new System.Drawing.Size(60, 19);
		this.rdLadies.TabIndex = 45;
		this.rdLadies.Tag = "LD";
		this.rdLadies.Text = "&Offline";
		this.rdLadies.UseVisualStyleBackColor = false;
		this.rdGeneral.AutoSize = true;
		this.rdGeneral.Checked = true;
		this.rdGeneral.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.rdGeneral.ForeColor = System.Drawing.Color.Black;
		this.rdGeneral.Location = new System.Drawing.Point(92, 15);
		this.rdGeneral.Name = "rdGeneral";
		this.rdGeneral.Size = new System.Drawing.Size(61, 19);
		this.rdGeneral.TabIndex = 44;
		this.rdGeneral.TabStop = true;
		this.rdGeneral.Tag = "GN";
		this.rdGeneral.Text = "&Online";
		this.rdGeneral.UseVisualStyleBackColor = false;
		this.groupBox2.Controls.Add(this.label3);
		this.groupBox2.Controls.Add(this.textShowOtp4);
		this.groupBox2.Controls.Add(this.btnDeregs);
		this.groupBox2.ForeColor = System.Drawing.Color.Black;
		this.groupBox2.Location = new System.Drawing.Point(3, 118);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Size = new System.Drawing.Size(362, 53);
		this.groupBox2.TabIndex = 43;
		this.groupBox2.TabStop = false;
		this.groupBox2.Text = "DeRegister Service";
		this.label3.AutoSize = true;
		this.label3.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label3.ForeColor = System.Drawing.Color.Black;
		this.label3.Location = new System.Drawing.Point(7, 25);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(105, 15);
		this.label3.TabIndex = 6;
		this.label3.Text = "Profile Password";
		this.textShowOtp4.BackColor = System.Drawing.Color.White;
		this.textShowOtp4.ForeColor = System.Drawing.Color.Black;
		this.textShowOtp4.Location = new System.Drawing.Point(118, 22);
		this.textShowOtp4.Name = "textShowOtp4";
		this.textShowOtp4.Size = new System.Drawing.Size(138, 20);
		this.textShowOtp4.TabIndex = 5;
		this.btnDeregs.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
		this.btnDeregs.ForeColor = System.Drawing.Color.Black;
		this.btnDeregs.Location = new System.Drawing.Point(262, 19);
		this.btnDeregs.Name = "btnDeregs";
		this.btnDeregs.Size = new System.Drawing.Size(92, 26);
		this.btnDeregs.TabIndex = 4;
		this.btnDeregs.Text = "DeRegister";
		this.btnDeregs.UseVisualStyleBackColor = false;
		this.textShowOtp1.BackColor = System.Drawing.Color.White;
		this.textShowOtp1.ForeColor = System.Drawing.Color.Black;
		this.textShowOtp1.Location = new System.Drawing.Point(6, 47);
		this.textShowOtp1.Multiline = true;
		this.textShowOtp1.Name = "textShowOtp1";
		this.textShowOtp1.Size = new System.Drawing.Size(253, 65);
		this.textShowOtp1.TabIndex = 8;
		this.btnGenrte1.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
		this.btnGenrte1.ForeColor = System.Drawing.Color.Black;
		this.btnGenrte1.Location = new System.Drawing.Point(265, 86);
		this.btnGenrte1.Name = "btnGenrte1";
		this.btnGenrte1.Size = new System.Drawing.Size(97, 26);
		this.btnGenrte1.TabIndex = 4;
		this.btnGenrte1.Text = "Genrate OTP";
		this.btnGenrte1.UseVisualStyleBackColor = false;
		this.lblTime.AutoSize = true;
		this.lblTime.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblTime.ForeColor = System.Drawing.Color.Black;
		this.lblTime.Location = new System.Drawing.Point(94, 16);
		this.lblTime.Name = "lblTime";
		this.lblTime.Size = new System.Drawing.Size(96, 16);
		this.lblTime.TabIndex = 1172;
		this.lblTime.Text = "Select Bank : ";
		this.cmbBanks1.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
		this.cmbBanks1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbBanks1.ForeColor = System.Drawing.Color.Black;
		this.cmbBanks1.FormattingEnabled = true;
		this.cmbBanks1.Location = new System.Drawing.Point(193, 13);
		this.cmbBanks1.Name = "cmbBanks1";
		this.cmbBanks1.Size = new System.Drawing.Size(268, 22);
		this.cmbBanks1.TabIndex = 1173;
		this.cmbBanks1.SelectedIndexChanged += new System.EventHandler(cmbBanks1_SelectedIndexChanged);
		this.lblStatus1.AutoSize = true;
		this.lblStatus1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblStatus1.ForeColor = System.Drawing.Color.Black;
		this.lblStatus1.Location = new System.Drawing.Point(566, 233);
		this.lblStatus1.Name = "lblStatus1";
		this.lblStatus1.Size = new System.Drawing.Size(97, 16);
		this.lblStatus1.TabIndex = 1179;
		this.lblStatus1.Text = "Surfing Status";
		this.button1.BackColor = System.Drawing.Color.Transparent;
		this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.button1.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button1.ForeColor = System.Drawing.Color.Black;
		this.button1.Location = new System.Drawing.Point(538, 27);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(42, 22);
		this.button1.TabIndex = 1178;
		this.button1.UseVisualStyleBackColor = false;
		this.label7.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label7.ForeColor = System.Drawing.Color.Blue;
		this.label7.Location = new System.Drawing.Point(535, 187);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(474, 32);
		this.label7.TabIndex = 1169;
		this.label7.Text = "SBI Website. Please refer steps. On success message click Success Button below.";
		this.label7.Visible = false;
		this.webBrowser.Location = new System.Drawing.Point(0, 308);
		this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
		this.webBrowser.Name = "webBrowser";
		this.webBrowser.ScriptErrorsSuppressed = true;
		this.webBrowser.Size = new System.Drawing.Size(482, 418);
		this.webBrowser.TabIndex = 1179;
		this.webBrowser.Visible = false;
		this.progressBar1.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
		this.progressBar1.ForeColor = System.Drawing.Color.Black;
		this.progressBar1.Location = new System.Drawing.Point(0, 275);
		this.progressBar1.Name = "progressBar1";
		this.progressBar1.Size = new System.Drawing.Size(484, 11);
		this.progressBar1.TabIndex = 1180;
		base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		base.Controls.Add(this.groupBox1);
		base.Controls.Add(this.lblStatus1);
		base.Controls.Add(this.webBrowser);
		base.Controls.Add(this.progressBar1);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.label7);
		this.DoubleBuffered = true;
		base.Name = "tabSbiSetting";
		base.Size = new System.Drawing.Size(469, 222);
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		this.PassOtpGroupBx1.ResumeLayout(false);
		this.PassOtpGroupBx1.PerformLayout();
		this.GetOtpGroupBx1.ResumeLayout(false);
		this.GetOtpGroupBx1.PerformLayout();
		this.groupBox2.ResumeLayout(false);
		this.groupBox2.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
