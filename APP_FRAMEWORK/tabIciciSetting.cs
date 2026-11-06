using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Booking.Properties;

namespace APP_FRAMEWORK;

internal class tabIciciSetting : UserControl
{
	private int int_0;

	private static RijndaelManaged rijndaelManaged_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private CookieContainer cookieContainer_0;

	private Dictionary<string, string> B0AAA;

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

	internal string string_11;

	internal string string_12;

	internal string string_13;

	private IDisposable C0AA0;

	private IContainer icontainer_0;

	private ProgressBar progressBar1;

	private System.Windows.Forms.Timer timer_0;

	private GroupBox groupBox5;

	private GroupBox PassOtpGroupBx3;

	private Label label13;

	private Label label30;

	private Label label15;

	private Label label16;

	private Label label14;

	internal Button btnNew3;

	internal Button btnBrowse3;

	private TextBox B1AAA;

	private Panel C1AA0;

	private Label label41;

	private TextBox textBox45;

	private Label label36;

	private Label label37;

	private Label label38;

	private Label label39;

	private TextBox textBox44;

	private TextBox textBox43;

	private TextBox textBox42;

	private TextBox textBox41;

	private TextBox B2AAA;

	private Label C2AA0;

	private Label label31;

	private Label label32;

	private Label label33;

	private Label label34;

	private TextBox textBox39;

	private TextBox textBox38;

	private TextBox textBox37;

	private TextBox textBox36;

	private TextBox textBox35;

	private Label label35;

	private Label B3AAA;

	private Label C3AA0;

	private Label label27;

	private Label label28;

	private TextBox textBox34;

	private TextBox textBox33;

	private TextBox textBox32;

	private TextBox textBox31;

	private TextBox textBox30;

	private Label label29;

	private Label lblPin;

	private Label lblKey;

	private TextBox B4AAA;

	private GroupBox C4AA0;

	private TextBox textShowOtp3;

	private Button btnGenrte3;

	public Button button9;

	private Label label19;

	private ComboBox cmbBanks3;

	private Label lblStatus1;

	public tabIciciSetting()
	{
		InitializeComponent();
	}

	private void tabIciciSetting_Load(object sender, EventArgs e)
	{
		B0AAA = new Dictionary<string, string>();
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
		int_1 = 2;
		method_0();
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

	private void method_0()
	{
		new DataTable();
		cmbBanks3.Items.Clear();
		ComboBox.ObjectCollection items = cmbBanks3.Items;
		string item = "Select Bank Account";
		items.Add(item);
		Dictionary<string, string> dictionary = Staticm.ICICI();
		foreach (string key in dictionary.Keys)
		{
			B0AAA.Add(key, dictionary[key]);
			cmbBanks3.Items.Add(key);
		}
		cmbBanks3.SelectedIndex = 0;
	}

	private void method_1(string string_0)
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
				method_2(fileName);
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

	private void method_2(string string_0)
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
				string text11 = "Selected By-Pass file is not belongs to Selected ICICI User, Please select right file.";
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

	private void method_3(string string_0)
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

	private void method_4(string string_0)
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
			method_3(string_0);
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

	private void cmbBanks3_SelectedIndexChanged(object sender, EventArgs e)
	{
		PassOtpGroupBx3.Visible = false;
		C4AA0.Visible = false;
		if (cmbBanks3.SelectedIndex > 0)
		{
			string_2 = cmbBanks3.SelectedItem.ToString();
			string_3 = B0AAA[string_2];
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
			string text3 = "./ICICI";
			string text4 = text3;
			if (!Directory.Exists(text4))
			{
				Directory.CreateDirectory(text4);
			}
			string text5 = "\\";
			string text6 = string_4;
			string text7 = ".rg";
			Brwpath = text4 + text5 + text6 + text7;
			if (array2.Length <= 2)
			{
				PassOtpGroupBx3.Visible = true;
				B1AAA.Text = method_6();
				B4AAA.Text = method_5();
				return;
			}
			string text8 = "OTP is already By-Passed for ";
			string text9 = string_2;
			string text10 = "\r\n\r\nIf you want to setup again then Delete the bank and Add again.";
			string text11 = text8 + text9 + text10;
			string caption = "Already By-Passed";
			MessageBox.Show(text11, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			Button button = btnNew3;
			string text12 = "Get OTP";
			button.Text = text12;
			C4AA0.Visible = true;
		}
	}

	private void btnBrowse3_Click(object sender, EventArgs e)
	{
		string string_ = "ICICI";
		method_1(string_);
	}

	private void BAAAA(object sender, EventArgs e)
	{
		if (textBox45.Text.Trim() == "" || B4AAA.Text.Trim() == "" || B1AAA.Text.Trim() == "")
		{
			return;
		}
		string text = "./ICICI\\";
		string text2 = string_4;
		string text3 = ".rg";
		string text4 = text + text2 + text3;
		if (File.Exists(text4))
		{
			string text5 = "Existing OTP file found! Do you want to use that file?\r\n\r\nClick YES to use found file or Click NO to create New File.";
			string caption = "OTP File Found";
			if (MessageBox.Show(text5, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				method_2(text4);
				return;
			}
			File.Delete(text4);
		}
		string[] array = new string[32];
		string text6 = "A=";
		array[0] = text6;
		array[1] = textBox30.Text;
		string text7 = "&&B=";
		array[2] = text7;
		array[3] = textBox31.Text;
		string text8 = "&&C=";
		array[4] = text8;
		array[5] = textBox32.Text;
		string text9 = "&&D=";
		array[6] = text9;
		array[7] = textBox33.Text;
		string text10 = "&&E=";
		array[8] = text10;
		array[9] = textBox34.Text;
		string text11 = "&&F=";
		array[10] = text11;
		array[11] = textBox35.Text;
		string text12 = "&&G=";
		array[12] = text12;
		array[13] = textBox36.Text;
		string text13 = "&&H=";
		array[14] = text13;
		array[15] = textBox37.Text;
		string text14 = "&&I=";
		array[16] = text14;
		array[17] = textBox38.Text;
		string text15 = "&&J=";
		array[18] = text15;
		array[19] = textBox39.Text;
		string text16 = "&&K=";
		array[20] = text16;
		array[21] = B2AAA.Text;
		string text17 = "&&L=";
		array[22] = text17;
		array[23] = textBox41.Text;
		string text18 = "&&M=";
		array[24] = text18;
		array[25] = textBox42.Text;
		string text19 = "&&N=";
		array[26] = text19;
		array[27] = textBox43.Text;
		string text20 = "&&O=";
		array[28] = text20;
		array[29] = textBox44.Text;
		string text21 = "&&P=";
		array[30] = text21;
		array[31] = textBox45.Text;
		string text22 = string.Concat(array);
		TextBox b4AAA = B4AAA;
		string text23 = B4AAA.Text;
		string oldValue = "-";
		b4AAA.Text = text23.Replace(oldValue, "");
		try
		{
			btnNew3.Enabled = false;
			string[] array2 = new string[7] { string_3, null, null, null, null, null, null };
			string text24 = "||";
			array2[1] = text24;
			array2[2] = B1AAA.Text;
			string text25 = "||00000001||";
			array2[3] = text25;
			array2[4] = B4AAA.Text;
			string text26 = "||";
			array2[5] = text26;
			array2[6] = text22;
			string_1 = string.Concat(array2);
			string string_ = "ICICI";
			method_4(string_);
			Staticm.method_36();
			PassOtpGroupBx3.Visible = false;
			C4AA0.Visible = false;
			cmbBanks3.SelectedIndex = 0;
		}
		catch (Exception ex)
		{
			lblPin.Visible = false;
			lblKey.Visible = false;
			B1AAA.Visible = false;
			B4AAA.Visible = false;
			btnNew3.Visible = false;
			string text27 = "ICICIOTPByPass: btnSubmit_Click";
			Class28.smethod_26(text27, ex.Message);
			string text28 = "Error occured while processing request!";
			string caption2 = "Error";
			MessageBox.Show(text28, caption2, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		string text29 = string_1;
		string[] array3 = new string[1];
		string text30 = "||";
		array3[0] = text30;
		text29.Split(array3, StringSplitOptions.RemoveEmptyEntries);
		for (int i = 0; i < 10; i++)
		{
			Thread.Sleep(50);
			Application.DoEvents();
		}
		string text31 = "ICICI||";
		string text32 = B1AAA.Text;
		string text33 = "||00000000||";
		string key = text31 + text32 + text33 + B4AAA.Text;
		_ = Program.mcommInstance_.GetData(key).Length;
	}

	private void CAAA0(object sender, KeyPressEventArgs e)
	{
		if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
		{
			e.Handled = true;
		}
	}

	private string method_5()
	{
		string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
		string text2 = text;
		char[] array = new char[23];
		Random random = new Random();
		for (int i = 0; i < 23; i++)
		{
			array[i] = ((i == 5 || i == 10 || i == 15) ? text2[45] : text2[random.Next(text2.Length)]);
		}
		string result = new string(array);
		Thread.Sleep(2000);
		return result;
	}

	private string method_6()
	{
		string text = "0123456789";
		string text2 = text;
		char[] array = new char[6];
		Random random = new Random();
		for (int i = 0; i < 6; i++)
		{
			array[i] = text2[random.Next(text2.Length)];
		}
		return new string(array);
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
		this.icontainer_0 = new System.ComponentModel.Container();
		this.groupBox5 = new System.Windows.Forms.GroupBox();
		this.cmbBanks3 = new System.Windows.Forms.ComboBox();
		this.PassOtpGroupBx3 = new System.Windows.Forms.GroupBox();
		this.C1AA0 = new System.Windows.Forms.Panel();
		this.label41 = new System.Windows.Forms.Label();
		this.textBox45 = new System.Windows.Forms.TextBox();
		this.label36 = new System.Windows.Forms.Label();
		this.label37 = new System.Windows.Forms.Label();
		this.label38 = new System.Windows.Forms.Label();
		this.label39 = new System.Windows.Forms.Label();
		this.textBox44 = new System.Windows.Forms.TextBox();
		this.textBox43 = new System.Windows.Forms.TextBox();
		this.textBox42 = new System.Windows.Forms.TextBox();
		this.textBox41 = new System.Windows.Forms.TextBox();
		this.B2AAA = new System.Windows.Forms.TextBox();
		this.C2AA0 = new System.Windows.Forms.Label();
		this.label31 = new System.Windows.Forms.Label();
		this.label32 = new System.Windows.Forms.Label();
		this.label33 = new System.Windows.Forms.Label();
		this.label34 = new System.Windows.Forms.Label();
		this.textBox39 = new System.Windows.Forms.TextBox();
		this.textBox38 = new System.Windows.Forms.TextBox();
		this.textBox37 = new System.Windows.Forms.TextBox();
		this.textBox36 = new System.Windows.Forms.TextBox();
		this.textBox35 = new System.Windows.Forms.TextBox();
		this.label35 = new System.Windows.Forms.Label();
		this.B3AAA = new System.Windows.Forms.Label();
		this.C3AA0 = new System.Windows.Forms.Label();
		this.label27 = new System.Windows.Forms.Label();
		this.label28 = new System.Windows.Forms.Label();
		this.textBox34 = new System.Windows.Forms.TextBox();
		this.textBox33 = new System.Windows.Forms.TextBox();
		this.textBox32 = new System.Windows.Forms.TextBox();
		this.textBox31 = new System.Windows.Forms.TextBox();
		this.textBox30 = new System.Windows.Forms.TextBox();
		this.label29 = new System.Windows.Forms.Label();
		this.label13 = new System.Windows.Forms.Label();
		this.label30 = new System.Windows.Forms.Label();
		this.label15 = new System.Windows.Forms.Label();
		this.label14 = new System.Windows.Forms.Label();
		this.btnNew3 = new System.Windows.Forms.Button();
		this.btnBrowse3 = new System.Windows.Forms.Button();
		this.B1AAA = new System.Windows.Forms.TextBox();
		this.lblPin = new System.Windows.Forms.Label();
		this.lblKey = new System.Windows.Forms.Label();
		this.B4AAA = new System.Windows.Forms.TextBox();
		this.C4AA0 = new System.Windows.Forms.GroupBox();
		this.textShowOtp3 = new System.Windows.Forms.TextBox();
		this.btnGenrte3 = new System.Windows.Forms.Button();
		this.label19 = new System.Windows.Forms.Label();
		this.lblStatus1 = new System.Windows.Forms.Label();
		this.button9 = new System.Windows.Forms.Button();
		this.label16 = new System.Windows.Forms.Label();
		this.progressBar1 = new System.Windows.Forms.ProgressBar();
		this.timer_0 = new System.Windows.Forms.Timer(this.icontainer_0);
		this.groupBox5.SuspendLayout();
		this.PassOtpGroupBx3.SuspendLayout();
		this.C1AA0.SuspendLayout();
		this.C4AA0.SuspendLayout();
		base.SuspendLayout();
		this.groupBox5.Controls.Add(this.cmbBanks3);
		this.groupBox5.Controls.Add(this.PassOtpGroupBx3);
		this.groupBox5.Controls.Add(this.C4AA0);
		this.groupBox5.Controls.Add(this.label19);
		this.groupBox5.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold);
		this.groupBox5.ForeColor = System.Drawing.Color.Black;
		this.groupBox5.Location = new System.Drawing.Point(4, 2);
		this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.groupBox5.Name = "groupBox5";
		this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.groupBox5.Size = new System.Drawing.Size(626, 309);
		this.groupBox5.TabIndex = 2;
		this.groupBox5.TabStop = false;
		this.groupBox5.Text = "By-Pass ICICI";
		this.cmbBanks3.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
		this.cmbBanks3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbBanks3.ForeColor = System.Drawing.Color.Black;
		this.cmbBanks3.FormattingEnabled = true;
		this.cmbBanks3.Location = new System.Drawing.Point(236, 18);
		this.cmbBanks3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.cmbBanks3.Name = "cmbBanks3";
		this.cmbBanks3.Size = new System.Drawing.Size(382, 24);
		this.cmbBanks3.TabIndex = 1176;
		this.cmbBanks3.SelectedIndexChanged += new System.EventHandler(cmbBanks3_SelectedIndexChanged);
		this.PassOtpGroupBx3.BackColor = System.Drawing.SystemColors.Control;
		this.PassOtpGroupBx3.Controls.Add(this.C1AA0);
		this.PassOtpGroupBx3.Controls.Add(this.label13);
		this.PassOtpGroupBx3.Controls.Add(this.label30);
		this.PassOtpGroupBx3.Controls.Add(this.label15);
		this.PassOtpGroupBx3.Controls.Add(this.label14);
		this.PassOtpGroupBx3.Controls.Add(this.btnNew3);
		this.PassOtpGroupBx3.Controls.Add(this.btnBrowse3);
		this.PassOtpGroupBx3.Controls.Add(this.B1AAA);
		this.PassOtpGroupBx3.Controls.Add(this.lblPin);
		this.PassOtpGroupBx3.Controls.Add(this.lblKey);
		this.PassOtpGroupBx3.Controls.Add(this.B4AAA);
		this.PassOtpGroupBx3.ForeColor = System.Drawing.Color.Black;
		this.PassOtpGroupBx3.Location = new System.Drawing.Point(8, 50);
		this.PassOtpGroupBx3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.PassOtpGroupBx3.Name = "PassOtpGroupBx3";
		this.PassOtpGroupBx3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.PassOtpGroupBx3.Size = new System.Drawing.Size(612, 251);
		this.PassOtpGroupBx3.TabIndex = 1174;
		this.PassOtpGroupBx3.TabStop = false;
		this.PassOtpGroupBx3.Text = "By-Pass OTP";
		this.PassOtpGroupBx3.Visible = false;
		this.C1AA0.Controls.Add(this.label41);
		this.C1AA0.Controls.Add(this.textBox45);
		this.C1AA0.Controls.Add(this.label36);
		this.C1AA0.Controls.Add(this.label37);
		this.C1AA0.Controls.Add(this.label38);
		this.C1AA0.Controls.Add(this.label39);
		this.C1AA0.Controls.Add(this.textBox44);
		this.C1AA0.Controls.Add(this.textBox43);
		this.C1AA0.Controls.Add(this.textBox42);
		this.C1AA0.Controls.Add(this.textBox41);
		this.C1AA0.Controls.Add(this.B2AAA);
		this.C1AA0.Controls.Add(this.C2AA0);
		this.C1AA0.Controls.Add(this.label31);
		this.C1AA0.Controls.Add(this.label32);
		this.C1AA0.Controls.Add(this.label33);
		this.C1AA0.Controls.Add(this.label34);
		this.C1AA0.Controls.Add(this.textBox39);
		this.C1AA0.Controls.Add(this.textBox38);
		this.C1AA0.Controls.Add(this.textBox37);
		this.C1AA0.Controls.Add(this.textBox36);
		this.C1AA0.Controls.Add(this.textBox35);
		this.C1AA0.Controls.Add(this.label35);
		this.C1AA0.Controls.Add(this.B3AAA);
		this.C1AA0.Controls.Add(this.C3AA0);
		this.C1AA0.Controls.Add(this.label27);
		this.C1AA0.Controls.Add(this.label28);
		this.C1AA0.Controls.Add(this.textBox34);
		this.C1AA0.Controls.Add(this.textBox33);
		this.C1AA0.Controls.Add(this.textBox32);
		this.C1AA0.Controls.Add(this.textBox31);
		this.C1AA0.Controls.Add(this.textBox30);
		this.C1AA0.Controls.Add(this.label29);
		this.C1AA0.ForeColor = System.Drawing.Color.Black;
		this.C1AA0.Location = new System.Drawing.Point(9, 72);
		this.C1AA0.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.C1AA0.Name = "panel5";
		this.C1AA0.Size = new System.Drawing.Size(598, 72);
		this.C1AA0.TabIndex = 128;
		this.label41.AutoSize = true;
		this.label41.ForeColor = System.Drawing.Color.Black;
		this.label41.Location = new System.Drawing.Point(521, 48);
		this.label41.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label41.Name = "label41";
		this.label41.Size = new System.Drawing.Size(17, 16);
		this.label41.TabIndex = 39;
		this.label41.Text = "P";
		this.textBox45.BackColor = System.Drawing.Color.White;
		this.textBox45.ForeColor = System.Drawing.Color.Black;
		this.textBox45.Location = new System.Drawing.Point(546, 40);
		this.textBox45.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.textBox45.MaxLength = 2;
		this.textBox45.Name = "textBox45";
		this.textBox45.Size = new System.Drawing.Size(44, 23);
		this.textBox45.TabIndex = 17;
		this.label36.AutoSize = true;
		this.label36.ForeColor = System.Drawing.Color.Black;
		this.label36.Location = new System.Drawing.Point(446, 48);
		this.label36.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label36.Name = "label36";
		this.label36.Size = new System.Drawing.Size(19, 16);
		this.label36.TabIndex = 37;
		this.label36.Text = "O";
		this.label37.AutoSize = true;
		this.label37.ForeColor = System.Drawing.Color.Black;
		this.label37.Location = new System.Drawing.Point(370, 48);
		this.label37.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label37.Name = "label37";
		this.label37.Size = new System.Drawing.Size(18, 16);
		this.label37.TabIndex = 36;
		this.label37.Text = "N";
		this.label38.AutoSize = true;
		this.label38.ForeColor = System.Drawing.Color.Black;
		this.label38.Location = new System.Drawing.Point(296, 48);
		this.label38.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label38.Name = "label38";
		this.label38.Size = new System.Drawing.Size(21, 16);
		this.label38.TabIndex = 35;
		this.label38.Text = "M";
		this.label39.AutoSize = true;
		this.label39.ForeColor = System.Drawing.Color.Black;
		this.label39.Location = new System.Drawing.Point(225, 48);
		this.label39.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label39.Name = "label39";
		this.label39.Size = new System.Drawing.Size(16, 16);
		this.label39.TabIndex = 34;
		this.label39.Text = "L";
		this.textBox44.BackColor = System.Drawing.Color.White;
		this.textBox44.ForeColor = System.Drawing.Color.Black;
		this.textBox44.Location = new System.Drawing.Point(468, 40);
		this.textBox44.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.textBox44.MaxLength = 2;
		this.textBox44.Name = "textBox44";
		this.textBox44.Size = new System.Drawing.Size(44, 23);
		this.textBox44.TabIndex = 16;
		this.textBox43.BackColor = System.Drawing.Color.White;
		this.textBox43.ForeColor = System.Drawing.Color.Black;
		this.textBox43.Location = new System.Drawing.Point(391, 40);
		this.textBox43.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.textBox43.MaxLength = 2;
		this.textBox43.Name = "textBox43";
		this.textBox43.Size = new System.Drawing.Size(44, 23);
		this.textBox43.TabIndex = 15;
		this.textBox42.BackColor = System.Drawing.Color.White;
		this.textBox42.ForeColor = System.Drawing.Color.Black;
		this.textBox42.Location = new System.Drawing.Point(318, 40);
		this.textBox42.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.textBox42.MaxLength = 2;
		this.textBox42.Name = "textBox42";
		this.textBox42.Size = new System.Drawing.Size(44, 23);
		this.textBox42.TabIndex = 14;
		this.textBox41.BackColor = System.Drawing.Color.White;
		this.textBox41.ForeColor = System.Drawing.Color.Black;
		this.textBox41.Location = new System.Drawing.Point(246, 40);
		this.textBox41.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.textBox41.MaxLength = 2;
		this.textBox41.Name = "textBox41";
		this.textBox41.Size = new System.Drawing.Size(44, 23);
		this.textBox41.TabIndex = 13;
		this.B2AAA.BackColor = System.Drawing.Color.White;
		this.B2AAA.ForeColor = System.Drawing.Color.Black;
		this.B2AAA.Location = new System.Drawing.Point(166, 40);
		this.B2AAA.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.B2AAA.MaxLength = 2;
		this.B2AAA.Name = "textBox40";
		this.B2AAA.Size = new System.Drawing.Size(44, 23);
		this.B2AAA.TabIndex = 12;
		this.C2AA0.AutoSize = true;
		this.C2AA0.ForeColor = System.Drawing.Color.Black;
		this.C2AA0.Location = new System.Drawing.Point(145, 48);
		this.C2AA0.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.C2AA0.Name = "label40";
		this.C2AA0.Size = new System.Drawing.Size(18, 16);
		this.C2AA0.TabIndex = 28;
		this.C2AA0.Text = "K";
		this.label31.AutoSize = true;
		this.label31.ForeColor = System.Drawing.Color.Black;
		this.label31.Location = new System.Drawing.Point(69, 48);
		this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label31.Name = "label31";
		this.label31.Size = new System.Drawing.Size(16, 16);
		this.label31.TabIndex = 27;
		this.label31.Text = "J";
		this.label32.AutoSize = true;
		this.label32.ForeColor = System.Drawing.Color.Black;
		this.label32.Location = new System.Drawing.Point(1, 44);
		this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label32.Name = "label32";
		this.label32.Size = new System.Drawing.Size(12, 16);
		this.label32.TabIndex = 26;
		this.label32.Text = "I";
		this.label33.AutoSize = true;
		this.label33.ForeColor = System.Drawing.Color.Black;
		this.label33.Location = new System.Drawing.Point(525, 14);
		this.label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label33.Name = "label33";
		this.label33.Size = new System.Drawing.Size(18, 16);
		this.label33.TabIndex = 25;
		this.label33.Text = "H";
		this.label34.AutoSize = true;
		this.label34.ForeColor = System.Drawing.Color.Black;
		this.label34.Location = new System.Drawing.Point(446, 14);
		this.label34.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label34.Name = "label34";
		this.label34.Size = new System.Drawing.Size(19, 16);
		this.label34.TabIndex = 24;
		this.label34.Text = "G";
		this.textBox39.BackColor = System.Drawing.Color.White;
		this.textBox39.ForeColor = System.Drawing.Color.Black;
		this.textBox39.Location = new System.Drawing.Point(90, 40);
		this.textBox39.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.textBox39.MaxLength = 2;
		this.textBox39.Name = "textBox39";
		this.textBox39.Size = new System.Drawing.Size(44, 23);
		this.textBox39.TabIndex = 11;
		this.textBox38.BackColor = System.Drawing.Color.White;
		this.textBox38.ForeColor = System.Drawing.Color.Black;
		this.textBox38.Location = new System.Drawing.Point(22, 40);
		this.textBox38.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.textBox38.MaxLength = 2;
		this.textBox38.Name = "textBox38";
		this.textBox38.Size = new System.Drawing.Size(44, 23);
		this.textBox38.TabIndex = 10;
		this.textBox37.BackColor = System.Drawing.Color.White;
		this.textBox37.ForeColor = System.Drawing.Color.Black;
		this.textBox37.Location = new System.Drawing.Point(546, 6);
		this.textBox37.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.textBox37.MaxLength = 2;
		this.textBox37.Name = "textBox37";
		this.textBox37.Size = new System.Drawing.Size(44, 23);
		this.textBox37.TabIndex = 9;
		this.textBox36.BackColor = System.Drawing.Color.White;
		this.textBox36.ForeColor = System.Drawing.Color.Black;
		this.textBox36.Location = new System.Drawing.Point(468, 6);
		this.textBox36.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.textBox36.MaxLength = 2;
		this.textBox36.Name = "textBox36";
		this.textBox36.Size = new System.Drawing.Size(44, 23);
		this.textBox36.TabIndex = 8;
		this.textBox35.BackColor = System.Drawing.Color.White;
		this.textBox35.ForeColor = System.Drawing.Color.Black;
		this.textBox35.Location = new System.Drawing.Point(391, 6);
		this.textBox35.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.textBox35.MaxLength = 2;
		this.textBox35.Name = "textBox35";
		this.textBox35.Size = new System.Drawing.Size(44, 23);
		this.textBox35.TabIndex = 7;
		this.label35.AutoSize = true;
		this.label35.ForeColor = System.Drawing.Color.Black;
		this.label35.Location = new System.Drawing.Point(370, 14);
		this.label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label35.Name = "label35";
		this.label35.Size = new System.Drawing.Size(17, 16);
		this.label35.TabIndex = 18;
		this.label35.Text = "F";
		this.B3AAA.AutoSize = true;
		this.B3AAA.ForeColor = System.Drawing.Color.Black;
		this.B3AAA.Location = new System.Drawing.Point(299, 14);
		this.B3AAA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.B3AAA.Name = "label17";
		this.B3AAA.Size = new System.Drawing.Size(17, 16);
		this.B3AAA.TabIndex = 15;
		this.B3AAA.Text = "E";
		this.C3AA0.AutoSize = true;
		this.C3AA0.ForeColor = System.Drawing.Color.Black;
		this.C3AA0.Location = new System.Drawing.Point(228, 14);
		this.C3AA0.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.C3AA0.Name = "label26";
		this.C3AA0.Size = new System.Drawing.Size(18, 16);
		this.C3AA0.TabIndex = 14;
		this.C3AA0.Text = "D";
		this.label27.AutoSize = true;
		this.label27.ForeColor = System.Drawing.Color.Black;
		this.label27.Location = new System.Drawing.Point(148, 14);
		this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label27.Name = "label27";
		this.label27.Size = new System.Drawing.Size(18, 16);
		this.label27.TabIndex = 13;
		this.label27.Text = "C";
		this.label28.AutoSize = true;
		this.label28.ForeColor = System.Drawing.Color.Black;
		this.label28.Location = new System.Drawing.Point(71, 14);
		this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label28.Name = "label28";
		this.label28.Size = new System.Drawing.Size(18, 16);
		this.label28.TabIndex = 12;
		this.label28.Text = "B";
		this.textBox34.BackColor = System.Drawing.Color.White;
		this.textBox34.ForeColor = System.Drawing.Color.Black;
		this.textBox34.Location = new System.Drawing.Point(318, 6);
		this.textBox34.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.textBox34.MaxLength = 2;
		this.textBox34.Name = "textBox34";
		this.textBox34.Size = new System.Drawing.Size(44, 23);
		this.textBox34.TabIndex = 6;
		this.textBox33.BackColor = System.Drawing.Color.White;
		this.textBox33.ForeColor = System.Drawing.Color.Black;
		this.textBox33.Location = new System.Drawing.Point(246, 6);
		this.textBox33.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.textBox33.MaxLength = 2;
		this.textBox33.Name = "textBox33";
		this.textBox33.Size = new System.Drawing.Size(44, 23);
		this.textBox33.TabIndex = 5;
		this.textBox32.BackColor = System.Drawing.Color.White;
		this.textBox32.ForeColor = System.Drawing.Color.Black;
		this.textBox32.Location = new System.Drawing.Point(166, 6);
		this.textBox32.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.textBox32.MaxLength = 2;
		this.textBox32.Name = "textBox32";
		this.textBox32.Size = new System.Drawing.Size(44, 23);
		this.textBox32.TabIndex = 4;
		this.textBox31.BackColor = System.Drawing.Color.White;
		this.textBox31.ForeColor = System.Drawing.Color.Black;
		this.textBox31.Location = new System.Drawing.Point(90, 6);
		this.textBox31.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.textBox31.MaxLength = 2;
		this.textBox31.Name = "textBox31";
		this.textBox31.Size = new System.Drawing.Size(44, 23);
		this.textBox31.TabIndex = 3;
		this.textBox30.BackColor = System.Drawing.Color.White;
		this.textBox30.ForeColor = System.Drawing.Color.Black;
		this.textBox30.Location = new System.Drawing.Point(22, 6);
		this.textBox30.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.textBox30.MaxLength = 2;
		this.textBox30.Name = "textBox30";
		this.textBox30.Size = new System.Drawing.Size(44, 23);
		this.textBox30.TabIndex = 2;
		this.label29.AutoSize = true;
		this.label29.ForeColor = System.Drawing.Color.Black;
		this.label29.Location = new System.Drawing.Point(4, 14);
		this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label29.Name = "label29";
		this.label29.Size = new System.Drawing.Size(17, 16);
		this.label29.TabIndex = 1;
		this.label29.Text = "A";
		this.label13.AutoSize = true;
		this.label13.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label13.ForeColor = System.Drawing.Color.Black;
		this.label13.Location = new System.Drawing.Point(139, 20);
		this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label13.Name = "label13";
		this.label13.Size = new System.Drawing.Size(238, 19);
		this.label13.TabIndex = 129;
		this.label13.Text = "Select Existing By-Pass File: ";
		this.label30.AutoSize = true;
		this.label30.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold);
		this.label30.ForeColor = System.Drawing.Color.Black;
		this.label30.Location = new System.Drawing.Point(476, 49);
		this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label30.Name = "label30";
		this.label30.Size = new System.Drawing.Size(120, 16);
		this.label30.TabIndex = 0;
		this.label30.Text = "Debit Card Grid ";
		this.label15.AutoSize = true;
		this.label15.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label15.ForeColor = System.Drawing.Color.Black;
		this.label15.Location = new System.Drawing.Point(138, 46);
		this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label15.Name = "label15";
		this.label15.Size = new System.Drawing.Size(186, 19);
		this.label15.TabIndex = 132;
		this.label15.Text = "Create New By-Pass : ";
		this.label14.AutoSize = true;
		this.label14.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
		this.label14.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label14.ForeColor = System.Drawing.Color.Black;
		this.label14.Location = new System.Drawing.Point(335, 50);
		this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label14.Name = "label14";
		this.label14.Size = new System.Drawing.Size(0, 19);
		this.label14.TabIndex = 131;
		this.btnNew3.BackColor = System.Drawing.Color.Transparent;
		this.btnNew3.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnNew3.ForeColor = System.Drawing.Color.Black;
		this.btnNew3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnNew3.Location = new System.Drawing.Point(471, 198);
		this.btnNew3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.btnNew3.Name = "btnNew3";
		this.btnNew3.Size = new System.Drawing.Size(129, 31);
		this.btnNew3.TabIndex = 53;
		this.btnNew3.Text = "      Bypass New";
		this.btnNew3.UseVisualStyleBackColor = false;
		this.btnNew3.Click += new System.EventHandler(BAAAA);
		this.btnBrowse3.BackColor = System.Drawing.Color.Transparent;
		this.btnBrowse3.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnBrowse3.ForeColor = System.Drawing.Color.Black;
		this.btnBrowse3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnBrowse3.Location = new System.Drawing.Point(475, 15);
		this.btnBrowse3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.btnBrowse3.Name = "btnBrowse3";
		this.btnBrowse3.Size = new System.Drawing.Size(121, 31);
		this.btnBrowse3.TabIndex = 130;
		this.btnBrowse3.Text = "      Browse";
		this.btnBrowse3.UseVisualStyleBackColor = false;
		this.btnBrowse3.Click += new System.EventHandler(btnBrowse3_Click);
		this.B1AAA.BackColor = System.Drawing.Color.White;
		this.B1AAA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.B1AAA.ForeColor = System.Drawing.Color.Black;
		this.B1AAA.Location = new System.Drawing.Point(372, 199);
		this.B1AAA.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.B1AAA.MaxLength = 6;
		this.B1AAA.Name = "txtPin";
		this.B1AAA.Size = new System.Drawing.Size(91, 23);
		this.B1AAA.TabIndex = 55;
		this.B1AAA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CAAA0);
		this.lblPin.AutoSize = true;
		this.lblPin.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblPin.ForeColor = System.Drawing.Color.Black;
		this.lblPin.Location = new System.Drawing.Point(178, 198);
		this.lblPin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.lblPin.Name = "lblPin";
		this.lblPin.Size = new System.Drawing.Size(151, 16);
		this.lblPin.TabIndex = 56;
		this.lblPin.Text = "Enter PIN (6 Digits) : ";
		this.lblKey.AutoSize = true;
		this.lblKey.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblKey.ForeColor = System.Drawing.Color.Black;
		this.lblKey.Location = new System.Drawing.Point(139, 169);
		this.lblKey.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.lblKey.Name = "lblKey";
		this.lblKey.Size = new System.Drawing.Size(192, 16);
		this.lblKey.TabIndex = 58;
		this.lblKey.Text = "SMS Key (20 Characters) : ";
		this.B4AAA.BackColor = System.Drawing.Color.White;
		this.B4AAA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.B4AAA.ForeColor = System.Drawing.Color.Black;
		this.B4AAA.Location = new System.Drawing.Point(372, 166);
		this.B4AAA.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.B4AAA.MaxLength = 23;
		this.B4AAA.Name = "txtKey";
		this.B4AAA.Size = new System.Drawing.Size(227, 23);
		this.B4AAA.TabIndex = 57;
		this.C4AA0.Controls.Add(this.textShowOtp3);
		this.C4AA0.Controls.Add(this.btnGenrte3);
		this.C4AA0.ForeColor = System.Drawing.Color.Black;
		this.C4AA0.Location = new System.Drawing.Point(116, 50);
		this.C4AA0.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.C4AA0.Name = "GetOtpGroupBx3";
		this.C4AA0.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.C4AA0.Size = new System.Drawing.Size(419, 106);
		this.C4AA0.TabIndex = 1173;
		this.C4AA0.TabStop = false;
		this.C4AA0.Text = "Genrate OTP";
		this.textShowOtp3.BackColor = System.Drawing.Color.White;
		this.textShowOtp3.ForeColor = System.Drawing.Color.Black;
		this.textShowOtp3.Location = new System.Drawing.Point(8, 28);
		this.textShowOtp3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.textShowOtp3.Multiline = true;
		this.textShowOtp3.Name = "textShowOtp3";
		this.textShowOtp3.Size = new System.Drawing.Size(274, 70);
		this.textShowOtp3.TabIndex = 8;
		this.btnGenrte3.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
		this.btnGenrte3.ForeColor = System.Drawing.Color.Black;
		this.btnGenrte3.Location = new System.Drawing.Point(290, 68);
		this.btnGenrte3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.btnGenrte3.Name = "btnGenrte3";
		this.btnGenrte3.Size = new System.Drawing.Size(121, 32);
		this.btnGenrte3.TabIndex = 4;
		this.btnGenrte3.Text = "Genrate OTP";
		this.btnGenrte3.UseVisualStyleBackColor = false;
		this.label19.AutoSize = true;
		this.label19.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label19.ForeColor = System.Drawing.Color.Black;
		this.label19.Location = new System.Drawing.Point(126, 21);
		this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label19.Name = "label19";
		this.label19.Size = new System.Drawing.Size(103, 16);
		this.label19.TabIndex = 1170;
		this.label19.Text = "Select Bank : ";
		this.lblStatus1.AutoSize = true;
		this.lblStatus1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblStatus1.ForeColor = System.Drawing.Color.Black;
		this.lblStatus1.Location = new System.Drawing.Point(982, 310);
		this.lblStatus1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.lblStatus1.Name = "lblStatus1";
		this.lblStatus1.Size = new System.Drawing.Size(122, 19);
		this.lblStatus1.TabIndex = 1179;
		this.lblStatus1.Text = "Surfing Status";
		this.button9.BackColor = System.Drawing.Color.Transparent;
		this.button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.button9.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button9.ForeColor = System.Drawing.Color.Black;
		this.button9.Image = Booking.Properties.Resources.BullletIcon;
		this.button9.Location = new System.Drawing.Point(986, 39);
		this.button9.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.button9.Name = "button9";
		this.button9.Size = new System.Drawing.Size(52, 28);
		this.button9.TabIndex = 1175;
		this.button9.UseVisualStyleBackColor = false;
		this.label16.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label16.ForeColor = System.Drawing.Color.Blue;
		this.label16.Location = new System.Drawing.Point(982, 256);
		this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label16.Name = "label16";
		this.label16.Size = new System.Drawing.Size(600, 35);
		this.label16.TabIndex = 50;
		this.label16.Text = "Note :";
		this.label16.Visible = false;
		this.progressBar1.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
		this.progressBar1.ForeColor = System.Drawing.Color.Black;
		this.progressBar1.Location = new System.Drawing.Point(2, 346);
		this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.progressBar1.Name = "progressBar1";
		this.progressBar1.Size = new System.Drawing.Size(605, 14);
		this.progressBar1.TabIndex = 1180;
		base.AutoScaleDimensions = new System.Drawing.SizeF(120f, 120f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		base.Controls.Add(this.groupBox5);
		base.Controls.Add(this.lblStatus1);
		base.Controls.Add(this.progressBar1);
		base.Controls.Add(this.button9);
		base.Controls.Add(this.label16);
		this.DoubleBuffered = true;
		base.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		base.Name = "tabIciciSetting";
		base.Size = new System.Drawing.Size(634, 314);
		base.Load += new System.EventHandler(tabIciciSetting_Load);
		this.groupBox5.ResumeLayout(false);
		this.groupBox5.PerformLayout();
		this.PassOtpGroupBx3.ResumeLayout(false);
		this.PassOtpGroupBx3.PerformLayout();
		this.C1AA0.ResumeLayout(false);
		this.C1AA0.PerformLayout();
		this.C4AA0.ResumeLayout(false);
		this.C4AA0.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
