using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace APP_FRAMEWORK;

internal class tabHdfcSetting : UserControl
{
	public delegate void agr1(string st);

	private int int_1;

	private int int_2;

	private Dictionary<string, string> dictionary0;

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

	private static RijndaelManaged rijndaelManaged_0;

	private IDisposable idisposable_0;

	private ProgressBar progressBar1;

	public WebBrowser webBrowser;

	private System.Windows.Forms.Timer timer_0;

	private GroupBox groupBox6;

	private Label label4;

	private GroupBox PassOtpGroupBx2;

	private GroupBox groupBox9;

	private Label label11;

	internal Button btnNew2;

	private Label lblATM;

	private TextBox txtVisaPin;

	private ComboBox cboYear;

	private ComboBox cboMonth;

	private Label label5;

	private Label label7;

	internal Button btnBrowse2;

	private Label label8;

	private Label lbl_Error;

	internal Button btnSubmit2;

	private TextBox txtOTP2;

	private Label label9;

	public Button button6;

	private GroupBox GetOtpGroupBx2;

	private TextBox textShowOtp2;

	private Button btnGenrte2;

	private Label label10;

	private ComboBox cmbBanks2;

	private Label label12;

	private IContainer components;

	private Label lblStatus1;

	public tabHdfcSetting()
	{
		InitializeComponent();
	}

	private void TabHdfcSetting_Load(object sender, EventArgs e)
	{
		method_0();
	}

	private void method_0()
	{
		dictionary0 = new Dictionary<string, string>();
		int_2 = 0;
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
		Brwpath = "";
		int_1 = 1;
		method_1();
	}

	private void method_1()
	{
		cboYear.Items.Clear();
		int i = DateTime.Now.Year - 1;
		for (int num = i + 30; i <= num; i++)
		{
			cboYear.Items.Add(i.ToString());
		}
		cmbBanks2.Items.Clear();
		ComboBox.ObjectCollection items = cmbBanks2.Items;
		string item = "Select Bank Account";
		items.Add(item);
		Dictionary<string, string> dictionary = Staticm.HDFC();
		foreach (string key in dictionary.Keys)
		{
			dictionary0.Add(key, dictionary[key]);
			cmbBanks2.Items.Add(key);
		}
		cmbBanks2.SelectedIndex = 0;
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
			if (text9.Contains(text8 + text10))
			{
				string text11 = string_1;
				string text12 = string_3;
				string text13 = "||";
				if (!text11.Contains(text12 + text13))
				{
					string text14 = "Password Worng Updated, Please select right file.";
					string caption = "User-Password not Match";
					MessageBox.Show(text14, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				SQLiteConnection sQLiteConnection = new SQLiteConnection(Class34.string_Database);
				SQLiteCommand sQLiteCommand = new SQLiteCommand();
				sQLiteConnection.Open();
				sQLiteCommand.Connection = sQLiteConnection;
				string[] array = new string[5];
				string text15 = "UPDATE [TBL_BANK] SET [BANK_DETAILS] = '";
				array[0] = text15;
				array[1] = string_1;
				string text16 = "' WHERE [BANK_SAVEAS] = '";
				array[2] = text16;
				array[3] = string_2;
				string text17 = "'";
				array[4] = text17;
				sQLiteCommand.CommandText = string.Concat(array);
				sQLiteCommand.ExecuteNonQuery();
				sQLiteConnection.Close();
				sQLiteCommand.Dispose();
				string text18 = "By-Pass Updated successfully, You can use now.";
				string caption2 = "By-Passed";
				MessageBox.Show(text18, caption2, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				StatClass.method_36();
			}
			else
			{
				string text19 = "Selected By-Pass file is not belongs to Selected HDFC User, Please select right file.";
				string caption3 = "User not Match";
				MessageBox.Show(text19, caption3, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		catch (Exception)
		{
			string text20 = "Error Found while Restoring Data!";
			string caption4 = "Error";
			MessageBox.Show(text20, caption4, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private static void smethod_0()
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
		smethod_0();
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
		smethod_0();
		ICryptoTransform transform = rijndaelManaged_0.CreateDecryptor();
		stream_0.Position = 0L;
		smethod_2(new CryptoStream(stream_0, transform, CryptoStreamMode.Read), stream_1);
		stream_1.Position = 0L;
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

	private void webBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
	{
		try
		{
			if (webBrowser.Document != null)
			{
				_ = webBrowser.DocumentText;
			}
			string text = e.Url.ToString();
			string value = "=https://www.irctc.co.in/eticketing/BankResponse";
			if (text.IndexOf(value) < 0)
			{
				string text2 = e.Url.ToString();
				string value2 = "https://retail.onlinesbi.com/retail/quicktransferdetails.htm";
				if (text2.IndexOf(value2) >= 0)
				{
					timer_0.Enabled = true;
					timer_0.Interval = 500;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private void webBrowser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
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

	private void cmbBanks2_SelectedIndexChanged(object sender, EventArgs e)
	{
		PassOtpGroupBx2.Visible = false;
		GetOtpGroupBx2.Visible = false;
		if (cmbBanks2.SelectedIndex > 0)
		{
			string_2 = cmbBanks2.SelectedItem.ToString();
			string_3 = dictionary0[string_2];
			string text = string_3;
			string[] array = new string[1];
			string text2 = "||";
			array[0] = text2;
			string[] array2 = text.Split(array, StringSplitOptions.RemoveEmptyEntries);
			if (array2.Length == 2)
			{
				string_4 = array2[0];
				string_5 = array2[1];
			}
			string text3 = "./HDFC";
			string text4 = text3;
			if (!Directory.Exists(text4))
			{
				Directory.CreateDirectory(text4);
			}
			string text5 = "\\";
			string text6 = string_4;
			string text7 = ".rg";
			Brwpath = text4 + text5 + text6 + text7;
			if (array2.Length > 2)
			{
				string text8 = "OTP is already By-Passed for ";
				string text9 = string_2;
				string text10 = "\r\n\r\nIf you want to setup again then Delete the bank and Add again.";
				string text11 = text8 + text9 + text10;
				string caption = "Already By-Passed";
				MessageBox.Show(text11, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				GetOtpGroupBx2.Visible = true;
				textShowOtp2.Text = array2[2];
			}
			else
			{
				PassOtpGroupBx2.Visible = true;
			}
		}
	}

	private void btnBrowse2_Click(object sender, EventArgs e)
	{
		string string_ = "HDFC";
		method_2(string_);
	}

	private void btnNew2_Click(object sender, EventArgs e)
	{
		int_2 = 0;
		string_8 = cboMonth.SelectedItem.ToString();
		string_9 = cboYear.SelectedItem.ToString();
		string_10 = txtVisaPin.Text;
		if (cmbBanks2.SelectedIndex < 0)
		{
			Label label = lbl_Error;
			string text = "Please Select Bank";
			label.Text = text;
		}
		else if (cboMonth.SelectedIndex < 0)
		{
			Label label2 = lbl_Error;
			string text2 = "Month is Required";
			label2.Text = text2;
		}
		else if (cboYear.SelectedIndex < 0)
		{
			Label label3 = lbl_Error;
			string text3 = "Year is Required";
			label3.Text = text3;
		}
		else if (!(txtVisaPin.Text.Trim() == ""))
		{
			string text4 = "./HDFC\\";
			string text5 = string_4;
			string text6 = ".rg";
			string text7 = text4 + text5 + text6;
			if (File.Exists(text7))
			{
				string text8 = "Existing OTP file found! Do you want to use that file?\r\n\r\nClick YES to use found file or Click NO to create New File.";
				string caption = "OTP File Found";
				if (MessageBox.Show(text8, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					method_3(text7);
					return;
				}
				File.Delete(text7);
			}
			lbl_Error.Text = "";
			string[] array = new string[8];
			string text9 = "HDFC||";
			array[0] = text9;
			array[1] = string_3;
			string text10 = "||";
			array[2] = text10;
			array[3] = string_8;
			string text11 = "||";
			array[4] = text11;
			array[5] = string_9;
			string text12 = "||";
			array[6] = text12;
			array[7] = string_10;
			string key = string.Concat(array);
			string data = Program.mcommInstance_.GetData(key);
			string oldValue = "'";
			string newValue = "*";
			string text13 = data.Replace(oldValue, newValue);
			string value = "&&";
			if (text13.Contains(value))
			{
				string_7 = text13;
				smethod_1H();
			}
			else
			{
				smethod_4ThorughNet(0);
			}
		}
		else
		{
			Label label4 = lbl_Error;
			string text14 = "ATM Pin is Required";
			label4.Text = text14;
		}
	}

	public void smethod_4ThorughNet(object object_0)
	{
		string text = "https://netbanking.hdfcbank.com/netbanking/";
		string urlString = text;
		PassOtpGroupBx2.Enabled = false;
		try
		{
			webBrowser.Navigate(urlString);
		}
		catch (Exception)
		{
		}
	}

	private void btnSubmit2_Click(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(txtOTP2.Text))
		{
			string_10 = txtOTP2.Text.Trim();
		}
	}

	public static string smethod_0H()
	{
		List<string> list = new List<string>();
		string item = "INDIA";
		list.Add(item);
		string item2 = "2021";
		list.Add(item2);
		string item3 = "PVR";
		list.Add(item3);
		string item4 = "DELHI";
		list.Add(item4);
		string item5 = "NOKIA";
		list.Add(item5);
		string item6 = "SAMSUNG";
		list.Add(item6);
		string item7 = "NLUDELHI";
		list.Add(item7);
		string item8 = "XIOMI";
		list.Add(item8);
		string item9 = "RAKESH";
		list.Add(item9);
		string item10 = "PALANPUR";
		list.Add(item10);
		string item11 = "BANDRA";
		list.Add(item11);
		string item12 = "2008";
		list.Add(item12);
		string item13 = "BOOKSHOW";
		list.Add(item13);
		string item14 = "INCOMETAX";
		list.Add(item14);
		string item15 = "JDNVL";
		list.Add(item15);
		string item16 = "MOHAN";
		list.Add(item16);
		string item17 = "SURYA";
		list.Add(item17);
		string item18 = "2010";
		list.Add(item18);
		string item19 = "1751";
		list.Add(item19);
		string item20 = "ELEPHANT";
		list.Add(item20);
		string item21 = "TIGER";
		list.Add(item21);
		string item22 = "RABBIT";
		list.Add(item22);
		string item23 = "SURAJ";
		list.Add(item23);
		string item24 = "2000";
		list.Add(item24);
		string item25 = "50000";
		list.Add(item25);
		string item26 = "40001";
		list.Add(item26);
		string item27 = "NDLS";
		list.Add(item27);
		string item28 = "MUNDRA";
		list.Add(item28);
		string item29 = "Number";
		list.Add(item29);
		string item30 = "hashsize";
		list.Add(item30);
		string item31 = "blocks";
		list.Add(item31);
		string item32 = "derivedkey";
		list.Add(item32);
		string item33 = "a9993e3";
		list.Add(item33);
		string item34 = "64706816a";
		list.Add(item34);
		string item35 = "ba3e257178";
		list.Add(item35);
		string item36 = "50c26c94";
		list.Add(item36);
		string item37 = "cd0d89d09";
		list.Add(item37);
		string item38 = "MANGAL";
		list.Add(item38);
		string item39 = "ROCKET";
		list.Add(item39);
		string item40 = "MISSION";
		list.Add(item40);
		string item41 = "ENGLEND";
		list.Add(item41);
		string item42 = "KASHMIR";
		list.Add(item42);
		string item43 = "KALI998";
		list.Add(item43);
		string item44 = "94435655";
		list.Add(item44);
		string item45 = "57435776";
		list.Add(item45);
		string item46 = "34667566";
		list.Add(item46);
		string item47 = "355656";
		list.Add(item47);
		string item48 = "0875564";
		list.Add(item48);
		string item49 = "96577989";
		list.Add(item49);
		string item50 = "0998756";
		list.Add(item50);
		string item51 = "8898678";
		list.Add(item51);
		List<string> list2 = list;
		Random random = new Random();
		List<string> list3 = new List<string>(list2);
		Thread.Sleep(1000);
		return list3[random.Next(0, list2.Count)];
	}

	public void smethod_1H()
	{
		string text = string_3;
		string text2 = "||";
		string_1 = text + text2 + string_7;
		string text3 = "HDFC||";
		string key = text3 + string_1;
		Program.mcommInstance_.GetData(key);
		string string_ = "HDFC";
		method_5(string_);
		Staticm.method_36();
		PassOtpGroupBx2.Visible = false;
		GetOtpGroupBx2.Visible = false;
		cmbBanks2.SelectedIndex = 0;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && idisposable_0 != null)
		{
			idisposable_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		this.groupBox6 = new System.Windows.Forms.GroupBox();
		this.label4 = new System.Windows.Forms.Label();
		this.GetOtpGroupBx2 = new System.Windows.Forms.GroupBox();
		this.textShowOtp2 = new System.Windows.Forms.TextBox();
		this.btnGenrte2 = new System.Windows.Forms.Button();
		this.label10 = new System.Windows.Forms.Label();
		this.cmbBanks2 = new System.Windows.Forms.ComboBox();
		this.label12 = new System.Windows.Forms.Label();
		this.PassOtpGroupBx2 = new System.Windows.Forms.GroupBox();
		this.groupBox9 = new System.Windows.Forms.GroupBox();
		this.label11 = new System.Windows.Forms.Label();
		this.btnNew2 = new System.Windows.Forms.Button();
		this.lblATM = new System.Windows.Forms.Label();
		this.txtVisaPin = new System.Windows.Forms.TextBox();
		this.cboYear = new System.Windows.Forms.ComboBox();
		this.cboMonth = new System.Windows.Forms.ComboBox();
		this.label5 = new System.Windows.Forms.Label();
		this.btnBrowse2 = new System.Windows.Forms.Button();
		this.label8 = new System.Windows.Forms.Label();
		this.lbl_Error = new System.Windows.Forms.Label();
		this.btnSubmit2 = new System.Windows.Forms.Button();
		this.txtOTP2 = new System.Windows.Forms.TextBox();
		this.label9 = new System.Windows.Forms.Label();
		this.lblStatus1 = new System.Windows.Forms.Label();
		this.button6 = new System.Windows.Forms.Button();
		this.label7 = new System.Windows.Forms.Label();
		this.webBrowser = new System.Windows.Forms.WebBrowser();
		this.progressBar1 = new System.Windows.Forms.ProgressBar();
		this.timer_0 = new System.Windows.Forms.Timer(this.components);
		this.groupBox6.SuspendLayout();
		this.GetOtpGroupBx2.SuspendLayout();
		this.PassOtpGroupBx2.SuspendLayout();
		this.groupBox9.SuspendLayout();
		base.SuspendLayout();
		this.groupBox6.Controls.Add(this.label4);
		this.groupBox6.Controls.Add(this.GetOtpGroupBx2);
		this.groupBox6.Controls.Add(this.label10);
		this.groupBox6.Controls.Add(this.cmbBanks2);
		this.groupBox6.Controls.Add(this.label12);
		this.groupBox6.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold);
		this.groupBox6.ForeColor = System.Drawing.Color.Black;
		this.groupBox6.Location = new System.Drawing.Point(7, 2);
		this.groupBox6.Name = "groupBox6";
		this.groupBox6.Size = new System.Drawing.Size(380, 47);
		this.groupBox6.TabIndex = 2;
		this.groupBox6.TabStop = false;
		this.groupBox6.Text = "By-Pass HDFC";
		this.label4.AutoSize = true;
		this.label4.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
		this.label4.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label4.ForeColor = System.Drawing.Color.Black;
		this.label4.Location = new System.Drawing.Point(138, 16);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(0, 16);
		this.label4.TabIndex = 1170;
		this.GetOtpGroupBx2.Controls.Add(this.textShowOtp2);
		this.GetOtpGroupBx2.Controls.Add(this.btnGenrte2);
		this.GetOtpGroupBx2.ForeColor = System.Drawing.Color.Black;
		this.GetOtpGroupBx2.Location = new System.Drawing.Point(16, 47);
		this.GetOtpGroupBx2.Name = "GetOtpGroupBx2";
		this.GetOtpGroupBx2.Size = new System.Drawing.Size(335, 162);
		this.GetOtpGroupBx2.TabIndex = 1173;
		this.GetOtpGroupBx2.TabStop = false;
		this.GetOtpGroupBx2.Text = "Genrate OTP";
		this.textShowOtp2.BackColor = System.Drawing.Color.White;
		this.textShowOtp2.ForeColor = System.Drawing.Color.Black;
		this.textShowOtp2.Location = new System.Drawing.Point(6, 16);
		this.textShowOtp2.Multiline = true;
		this.textShowOtp2.Name = "textShowOtp2";
		this.textShowOtp2.Size = new System.Drawing.Size(220, 140);
		this.textShowOtp2.TabIndex = 8;
		this.btnGenrte2.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
		this.btnGenrte2.ForeColor = System.Drawing.Color.Black;
		this.btnGenrte2.Location = new System.Drawing.Point(232, 108);
		this.btnGenrte2.Name = "btnGenrte2";
		this.btnGenrte2.Size = new System.Drawing.Size(97, 26);
		this.btnGenrte2.TabIndex = 4;
		this.btnGenrte2.Text = "Genrate OTP";
		this.btnGenrte2.UseVisualStyleBackColor = false;
		this.label10.AutoSize = true;
		this.label10.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
		this.label10.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label10.ForeColor = System.Drawing.Color.Black;
		this.label10.Location = new System.Drawing.Point(149, -10);
		this.label10.Name = "label10";
		this.label10.Size = new System.Drawing.Size(0, 16);
		this.label10.TabIndex = 1171;
		this.cmbBanks2.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
		this.cmbBanks2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbBanks2.ForeColor = System.Drawing.Color.Black;
		this.cmbBanks2.FormattingEnabled = true;
		this.cmbBanks2.Location = new System.Drawing.Point(115, 19);
		this.cmbBanks2.Name = "cmbBanks2";
		this.cmbBanks2.Size = new System.Drawing.Size(232, 22);
		this.cmbBanks2.TabIndex = 1169;
		this.cmbBanks2.SelectedIndexChanged += new System.EventHandler(cmbBanks2_SelectedIndexChanged);
		this.label12.AutoSize = true;
		this.label12.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label12.ForeColor = System.Drawing.Color.Black;
		this.label12.Location = new System.Drawing.Point(25, 22);
		this.label12.Name = "label12";
		this.label12.Size = new System.Drawing.Size(80, 14);
		this.label12.TabIndex = 1168;
		this.label12.Text = "Select Bank : ";
		this.PassOtpGroupBx2.Controls.Add(this.groupBox9);
		this.PassOtpGroupBx2.Controls.Add(this.label5);
		this.PassOtpGroupBx2.Controls.Add(this.btnBrowse2);
		this.PassOtpGroupBx2.Controls.Add(this.label8);
		this.PassOtpGroupBx2.Controls.Add(this.lbl_Error);
		this.PassOtpGroupBx2.Controls.Add(this.btnSubmit2);
		this.PassOtpGroupBx2.Controls.Add(this.txtOTP2);
		this.PassOtpGroupBx2.Controls.Add(this.label9);
		this.PassOtpGroupBx2.ForeColor = System.Drawing.Color.Black;
		this.PassOtpGroupBx2.Location = new System.Drawing.Point(7, 49);
		this.PassOtpGroupBx2.Name = "PassOtpGroupBx2";
		this.PassOtpGroupBx2.Size = new System.Drawing.Size(380, 162);
		this.PassOtpGroupBx2.TabIndex = 1174;
		this.PassOtpGroupBx2.TabStop = false;
		this.PassOtpGroupBx2.Text = "By-Pass OTP";
		this.PassOtpGroupBx2.Visible = false;
		this.groupBox9.Controls.Add(this.label11);
		this.groupBox9.Controls.Add(this.btnNew2);
		this.groupBox9.Controls.Add(this.lblATM);
		this.groupBox9.Controls.Add(this.txtVisaPin);
		this.groupBox9.Controls.Add(this.cboYear);
		this.groupBox9.Controls.Add(this.cboMonth);
		this.groupBox9.ForeColor = System.Drawing.Color.Black;
		this.groupBox9.Location = new System.Drawing.Point(4, 55);
		this.groupBox9.Name = "groupBox9";
		this.groupBox9.Size = new System.Drawing.Size(372, 68);
		this.groupBox9.TabIndex = 86;
		this.groupBox9.TabStop = false;
		this.label11.AutoSize = true;
		this.label11.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label11.ForeColor = System.Drawing.Color.Black;
		this.label11.Location = new System.Drawing.Point(65, 19);
		this.label11.Name = "label11";
		this.label11.Size = new System.Drawing.Size(107, 14);
		this.label11.TabIndex = 52;
		this.label11.Text = "Debit/Expiry Date : ";
		this.btnNew2.BackColor = System.Drawing.Color.Transparent;
		this.btnNew2.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnNew2.ForeColor = System.Drawing.Color.Black;
		this.btnNew2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnNew2.Location = new System.Drawing.Point(251, 40);
		this.btnNew2.Name = "btnNew2";
		this.btnNew2.Size = new System.Drawing.Size(119, 24);
		this.btnNew2.TabIndex = 58;
		this.btnNew2.Text = "     Bypass New";
		this.btnNew2.UseVisualStyleBackColor = false;
		this.btnNew2.Click += new System.EventHandler(btnNew2_Click);
		this.lblATM.AutoSize = true;
		this.lblATM.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblATM.ForeColor = System.Drawing.Color.Black;
		this.lblATM.Location = new System.Drawing.Point(112, 46);
		this.lblATM.Name = "lblATM";
		this.lblATM.Size = new System.Drawing.Size(60, 14);
		this.lblATM.TabIndex = 55;
		this.lblATM.Text = "ATM Pin : ";
		this.txtVisaPin.BackColor = System.Drawing.Color.White;
		this.txtVisaPin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtVisaPin.ForeColor = System.Drawing.Color.Black;
		this.txtVisaPin.Location = new System.Drawing.Point(180, 43);
		this.txtVisaPin.MaxLength = 10;
		this.txtVisaPin.Name = "txtVisaPin";
		this.txtVisaPin.Size = new System.Drawing.Size(67, 20);
		this.txtVisaPin.TabIndex = 56;
		this.cboYear.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
		this.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboYear.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.cboYear.ForeColor = System.Drawing.Color.Black;
		this.cboYear.FormattingEnabled = true;
		this.cboYear.Location = new System.Drawing.Point(253, 14);
		this.cboYear.Name = "cboYear";
		this.cboYear.Size = new System.Drawing.Size(116, 23);
		this.cboYear.TabIndex = 54;
		this.cboMonth.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
		this.cboMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboMonth.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.cboMonth.ForeColor = System.Drawing.Color.Black;
		this.cboMonth.FormattingEnabled = true;
		System.Windows.Forms.ComboBox.ObjectCollection items = this.cboMonth.Items;
		items.AddRange(new object[12]
		{
			"01", "02", "03", "04", "05", "06", "07", "08", "09", "10",
			"11", "12"
		});
		this.cboMonth.Location = new System.Drawing.Point(180, 15);
		this.cboMonth.Name = "cboMonth";
		this.cboMonth.Size = new System.Drawing.Size(67, 23);
		this.cboMonth.TabIndex = 53;
		this.label5.AutoSize = true;
		this.label5.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label5.ForeColor = System.Drawing.Color.Black;
		this.label5.Location = new System.Drawing.Point(6, 16);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(191, 16);
		this.label5.TabIndex = 63;
		this.label5.Text = "Select Existing By-Pass File: ";
		this.btnBrowse2.BackColor = System.Drawing.Color.Transparent;
		this.btnBrowse2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnBrowse2.ForeColor = System.Drawing.Color.Black;
		this.btnBrowse2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnBrowse2.Location = new System.Drawing.Point(257, 12);
		this.btnBrowse2.Name = "btnBrowse2";
		this.btnBrowse2.Size = new System.Drawing.Size(118, 25);
		this.btnBrowse2.TabIndex = 64;
		this.btnBrowse2.Text = "      Browse";
		this.btnBrowse2.UseVisualStyleBackColor = false;
		this.btnBrowse2.Click += new System.EventHandler(btnBrowse2_Click);
		this.label8.AutoSize = true;
		this.label8.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label8.ForeColor = System.Drawing.Color.Black;
		this.label8.Location = new System.Drawing.Point(6, 37);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(147, 16);
		this.label8.TabIndex = 57;
		this.label8.Text = "Create New By-Pass : ";
		this.lbl_Error.AutoSize = true;
		this.lbl_Error.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
		this.lbl_Error.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lbl_Error.ForeColor = System.Drawing.Color.Black;
		this.lbl_Error.Location = new System.Drawing.Point(194, 40);
		this.lbl_Error.Name = "lbl_Error";
		this.lbl_Error.Size = new System.Drawing.Size(0, 16);
		this.lbl_Error.TabIndex = 62;
		this.btnSubmit2.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnSubmit2.ForeColor = System.Drawing.Color.Black;
		this.btnSubmit2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnSubmit2.Location = new System.Drawing.Point(255, 124);
		this.btnSubmit2.Name = "btnSubmit2";
		this.btnSubmit2.Size = new System.Drawing.Size(118, 24);
		this.btnSubmit2.TabIndex = 61;
		this.btnSubmit2.Text = "     &Submit";
		this.btnSubmit2.UseVisualStyleBackColor = false;
		this.btnSubmit2.Visible = false;
		this.btnSubmit2.Click += new System.EventHandler(btnSubmit2_Click);
		this.txtOTP2.BackColor = System.Drawing.Color.White;
		this.txtOTP2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtOTP2.ForeColor = System.Drawing.Color.Black;
		this.txtOTP2.Location = new System.Drawing.Point(184, 126);
		this.txtOTP2.MaxLength = 20;
		this.txtOTP2.Name = "txtOTP2";
		this.txtOTP2.Size = new System.Drawing.Size(67, 20);
		this.txtOTP2.TabIndex = 59;
		this.txtOTP2.Visible = false;
		this.label9.AutoSize = true;
		this.label9.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label9.ForeColor = System.Drawing.Color.Black;
		this.label9.Location = new System.Drawing.Point(102, 130);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(70, 14);
		this.label9.TabIndex = 60;
		this.label9.Text = "Enter OTP : ";
		this.lblStatus1.AutoSize = true;
		this.lblStatus1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblStatus1.ForeColor = System.Drawing.Color.Black;
		this.lblStatus1.Location = new System.Drawing.Point(513, 185);
		this.lblStatus1.Name = "lblStatus1";
		this.lblStatus1.Size = new System.Drawing.Size(97, 16);
		this.lblStatus1.TabIndex = 1179;
		this.lblStatus1.Text = "Surfing Status";
		this.button6.BackColor = System.Drawing.Color.Transparent;
		this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.button6.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button6.ForeColor = System.Drawing.Color.Black;
		this.button6.Location = new System.Drawing.Point(516, 20);
		this.button6.Name = "button6";
		this.button6.Size = new System.Drawing.Size(42, 22);
		this.button6.TabIndex = 1175;
		this.button6.UseVisualStyleBackColor = false;
		this.label7.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label7.ForeColor = System.Drawing.Color.Blue;
		this.label7.Location = new System.Drawing.Point(513, 228);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(471, 32);
		this.label7.TabIndex = 65;
		this.label7.Text = "Note : Enter this First OTP into HDFC Website. Please refer steps. On success message click Success Button below.";
		this.label7.Visible = false;
		this.webBrowser.Location = new System.Drawing.Point(2, 314);
		this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
		this.webBrowser.Name = "webBrowser";
		this.webBrowser.ScriptErrorsSuppressed = true;
		this.webBrowser.Size = new System.Drawing.Size(482, 418);
		this.webBrowser.TabIndex = 1179;
		this.webBrowser.Visible = false;
		this.progressBar1.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
		this.progressBar1.ForeColor = System.Drawing.Color.Black;
		this.progressBar1.Location = new System.Drawing.Point(3, 276);
		this.progressBar1.Name = "progressBar1";
		this.progressBar1.Size = new System.Drawing.Size(484, 11);
		this.progressBar1.TabIndex = 1180;
		base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		base.Controls.Add(this.PassOtpGroupBx2);
		base.Controls.Add(this.groupBox6);
		base.Controls.Add(this.lblStatus1);
		base.Controls.Add(this.webBrowser);
		base.Controls.Add(this.progressBar1);
		base.Controls.Add(this.label7);
		base.Controls.Add(this.button6);
		this.DoubleBuffered = true;
		this.ForeColor = System.Drawing.Color.Black;
		base.Name = "tabHdfcSetting";
		base.Size = new System.Drawing.Size(719, 443);
		base.Load += new System.EventHandler(TabHdfcSetting_Load);
		this.groupBox6.ResumeLayout(false);
		this.groupBox6.PerformLayout();
		this.GetOtpGroupBx2.ResumeLayout(false);
		this.GetOtpGroupBx2.PerformLayout();
		this.PassOtpGroupBx2.ResumeLayout(false);
		this.PassOtpGroupBx2.PerformLayout();
		this.groupBox9.ResumeLayout(false);
		this.groupBox9.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
