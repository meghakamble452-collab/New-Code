using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;

namespace APP_FRAMEWORK;

internal class tabPaytmSetting0 : UserControl
{
	internal class Class15
	{
		private AsymmetricCipherKeyPair asymmetricCipherKeyPair_0;

		private string string_0 = "";

		private string string_1 = "";

		public Class15()
		{
			RsaKeyPairGenerator rsaKeyPairGenerator = new RsaKeyPairGenerator();
			rsaKeyPairGenerator.Init(new KeyGenerationParameters(new SecureRandom(), 2048));
			AsymmetricCipherKeyPair asymmetricCipherKeyPair = rsaKeyPairGenerator.GenerateKeyPair();
			string_0 = Convert.ToBase64String(PrivateKeyInfoFactory.CreatePrivateKeyInfo(asymmetricCipherKeyPair.Private).ToAsn1Object().GetDerEncoded());
			string_1 = Convert.ToBase64String(SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(asymmetricCipherKeyPair.Public).ToAsn1Object().GetDerEncoded());
			asymmetricCipherKeyPair_0 = asymmetricCipherKeyPair;
		}

		public string SHA256withRSA(string A_0, string A_1, ref string A_2)
		{
			A_0 = A_0.Replace(A_2, string_1);
			A_0 = A_0.ToLower();
			string pattern = "[^\\x00-\\x7F]|[\\p{Cc}&&[^\n\t]]|\\p{C}|\\s+";
			A_0 = new Regex(pattern, RegexOptions.None).Replace(A_0, string.Empty);
			string result = SignData(A_0, asymmetricCipherKeyPair_0.Private);
			Sha256Digest sha256Digest = new Sha256Digest();
			byte[] bytes = Encoding.UTF8.GetBytes(A_0);
			sha256Digest.BlockUpdate(bytes, 0, bytes.Length);
			RsaDigestSigner rsaDigestSigner = new RsaDigestSigner(sha256Digest);
			rsaDigestSigner.Init(forSigning: true, asymmetricCipherKeyPair_0.Private);
			Convert.ToBase64String(rsaDigestSigner.GenerateSignature());
			A_1 = string_0;
			A_2 = string_1;
			return result;
		}

		public string SignData(string msg, AsymmetricKeyParameter privKey)
		{
			try
			{
				byte[] bytes = Encoding.UTF8.GetBytes(msg);
				string algorithm = "SHA-256withRSA";
				ISigner signer = SignerUtilities.GetSigner(algorithm);
				signer.Init(forSigning: true, privKey);
				signer.BlockUpdate(bytes, 0, bytes.Length);
				return Convert.ToBase64String(signer.GenerateSignature());
			}
			catch (Exception ex)
			{
				string text = "Signing Failed: ";
				Console.WriteLine(text + ex.ToString());
				return null;
			}
		}
	}

	private CookieContainer cookieContainer_0;

	private Dictionary<string, string> dictionary_0;

	internal string string_1;

	internal string string_2;

	internal string string_3;

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

	private static RijndaelManaged rijndaelManaged_0;

	private string string_4 = "";

	internal string str_6;

	internal string str_7;

	internal string str_8;

	private string string_14;

	private string string_15;

	private string string_16;

	private string string_17;

	private string string_18;

	private string str09;

	private string str08;

	private string string_19;

	private string string_20;

	private string string_21;

	private bool bool_0;

	private string string_22;

	internal string UserAgent = "okhttp/3.12.1";

	private IContainer components;

	private ProgressBar progressBar1;

	private GroupBox groupBox8;

	private GroupBox PassOtpGroupBx5;

	internal Button btnSubmit5;

	private Label label23;

	private Label label24;

	private Label label25;

	private Label label42;

	private Label label43;

	internal Button btnNew5;

	internal Button btnBrowse5;

	private TextBox txtOTP5;

	private Label label44;

	private GroupBox GetOtpGroupBx5;

	private TextBox textBox7;

	private Button btnGenrte5;

	public Button button16;

	private ComboBox cmbBanks5;

	private Label label46;

	private Label label2;

	private Label lblStatus1;

	public tabPaytmSetting0()
	{
		InitializeComponent();
	}

	private void tabPaytmSetting_Load(object sender, EventArgs e)
	{
		dictionary_0 = new Dictionary<string, string>();
		string_1 = "";
		string_2 = "";
		string_3 = "";
		string_15 = "";
		string_5 = "";
		string_6 = "";
		string_7 = "";
		string_8 = "";
		string_9 = "";
		string_10 = "";
		Brwpath = "";
		method_0();
	}

	private void method_0()
	{
		new DataTable();
		cmbBanks5.Items.Clear();
		ComboBox.ObjectCollection items = cmbBanks5.Items;
		string item = "Select Bank Account";
		items.Add(item);
		Dictionary<string, string> dictionary = Staticm.PAYTM();
		foreach (string key in dictionary.Keys)
		{
			dictionary_0.Add(key, dictionary[key]);
			cmbBanks5.Items.Add(key);
		}
		cmbBanks5.SelectedIndex = 0;
	}

	private void method_2(string string_23)
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
			openFileDialog.InitialDirectory = startupPath + text + string_23;
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
			Class28.smethod_26(string_23 + text2, ex.Message);
			string text3 = "Error occured while processing request!";
			string caption = "Error";
			MessageBox.Show(text3, caption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void method_3(string string_23)
	{
		try
		{
			using FileStream stream_ = new FileStream(string_23, FileMode.Open, FileAccess.Read);
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
				string text11 = "Selected By-Pass file is not belongs to Selected PAYTM User, Please select right file.";
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

	private void method_4(string string_23)
	{
		string text = "./";
		string text2 = text + string_23;
		if (!Directory.Exists(text2))
		{
			Directory.CreateDirectory(text2);
		}
		string text3 = "\\";
		string text4 = string_15;
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

	private void method_5(string string_23)
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
			method_4(string_23);
			string text4 = "BANK BY-PASSED SUCCESFULLY.\r\n\r\nBy-Pass Updated successfully, You can use Now.\r\n\rPlease delete all the Tickets having ";
			string text5 = " Bank A/c.";
			string text6 = text4 + string_23 + text5;
			string text7 = " BY-PASSED";
			MessageBox.Show(text6, string_23 + text7, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		catch (Exception)
		{
			string text8 = "Error occured while processing request!";
			string caption = "Error";
			MessageBox.Show(text8, caption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
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

	private void cmbBanks5_SelectedIndexChanged(object sender, EventArgs e)
	{
		PassOtpGroupBx5.Visible = false;
		GetOtpGroupBx5.Visible = false;
		if (cmbBanks5.SelectedIndex > 0)
		{
			string_2 = cmbBanks5.SelectedItem.ToString();
			string_3 = dictionary_0[string_2];
			string text = string_3;
			string[] array = new string[1];
			string text2 = "||";
			array[0] = text2;
			string[] array2 = text.Split(array, StringSplitOptions.RemoveEmptyEntries);
			if (array2.Length == 2)
			{
				string_15 = array2[0];
				string_21 = array2[1];
			}
			string startupPath = Application.StartupPath;
			string path = "PAYTM";
			string text3 = Path.Combine(startupPath, path);
			if (!Directory.Exists(text3))
			{
				Directory.CreateDirectory(text3);
			}
			string text4 = "\\";
			string text5 = string_15;
			string text6 = ".rg";
			Brwpath = text3 + text4 + text5 + text6;
			if (array2.Length <= 2)
			{
				PassOtpGroupBx5.Visible = true;
				return;
			}
			string text7 = "OTP is already By-Passed for ";
			string text8 = string_2;
			string text9 = "\r\n\r\nIf you want to setup again then Delete the bank and Add again.";
			string text10 = text7 + text8 + text9;
			string caption = "Already By-Passed";
			MessageBox.Show(text10, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			Button button = btnNew5;
			string text11 = "Get OTP";
			button.Text = text11;
			GetOtpGroupBx5.Visible = true;
		}
	}

	private void btnBrowse5_Click(object sender, EventArgs e)
	{
		string string_ = "PAYTM";
		method_2(string_);
	}

	private void BtnNew5_Click(object sender, EventArgs e)
	{
		string startupPath = Application.StartupPath;
		string path = "PAYTM";
		string text = Path.Combine(startupPath, path);
		string text2 = "\\";
		string text3 = string_15;
		string text4 = ".rg";
		string path2 = text + text2 + text3 + text4;
		if (File.Exists(path2))
		{
			File.Delete(path2);
		}
		if (method_7())
		{
			txtOTP5.Visible = true;
			btnSubmit5.Visible = true;
			txtOTP5.Focus();
		}
	}

	private bool method_7()
	{
		bool result = true;
		WebProxy webProxy_ = null;
		string text = "samsung";
		string_7 = text;
		string text2 = "SM-J320F";
		string_8 = text2;
		string text3 = "samsung-SM-J320F-860d588d64558aa";
		string_6 = text3;
		string_6 = smethod_8(ref string_7, ref string_8);
		string text4 = string_6;
		string[] array = new string[1];
		string text5 = "-";
		array[0] = text5;
		string[] array2 = text4.Split(array, StringSplitOptions.None);
		str_7 = array2[0];
		str_8 = array2[1];
		str_6 = array2[2];
		string text6 = "8.14.0";
		string_9 = text6;
		string text7 = "5.1.1";
		string_10 = text7;
		string_11 = "";
		string_14 = string_15;
		long num = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds / 1000;
		int num2 = 1;
		string text8 = "860d588d64558aa:1602774768259:16:16";
		string_16 = text8;
		string[] array3 = new string[7] { str_6, null, null, null, null, null, null };
		string text9 = ":";
		array3[1] = text9;
		array3[2] = num.ToString();
		string text10 = ":";
		array3[3] = text10;
		array3[4] = num2.ToString();
		string text11 = ":";
		array3[5] = text11;
		array3[6] = num2.ToString();
		string_16 = string.Concat(array3);
		string text12 = "89300500203268030312";
		string_17 = text12;
		string text13 = "Basic bWFya2V0LWFwcDo5YTA3MTc2Mi1hNDk5LTRiZDktOTE0YS00MzYxZTdjM2Y0YmM=";
		string_18 = text13;
		DateTimeOffset.Now.ToUnixTimeSeconds();
		double totalSeconds = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
		string text14 = "1602774768";
		str09 = text14;
		str09 = totalSeconds.ToString();
		string text15 = "";
		string[] array4 = new string[18];
		string text16 = "x-phone-number#";
		array4[0] = text16;
		array4[1] = string_14;
		string text17 = "||x-app-rid#";
		array4[2] = text17;
		array4[3] = string_16;
		string text18 = "||x-device-name#";
		array4[4] = text18;
		array4[5] = string_8;
		string text19 = "||x-app-version#";
		array4[6] = text19;
		array4[7] = string_9;
		string text20 = "||x-device-manufacturer#";
		array4[8] = text20;
		array4[9] = string_7;
		string text21 = "||x-iccid#";
		array4[10] = text21;
		array4[11] = string_17;
		string text22 = "||x-device-identifier#";
		array4[12] = text22;
		array4[13] = string_6;
		string text23 = "||x-epoch#";
		array4[14] = text23;
		array4[15] = str09;
		string text24 = "||Authorization#";
		array4[16] = text24;
		array4[17] = string_18;
		str08 = string.Concat(array4);
		string[] array5 = new string[11];
		string text25 = "https://accounts.paytm.com/devicebinding/config/sv1?deviceIdentifier=";
		array5[0] = text25;
		array5[1] = string_6;
		string text26 = "&deviceManufacturer=";
		array5[2] = text26;
		array5[3] = string_7;
		string text27 = "&deviceName=";
		array5[4] = text27;
		array5[5] = string_8;
		string text28 = "&client=androidapp&version=";
		array5[6] = text28;
		array5[7] = string_9;
		string text29 = "&playStore=false&lat=0.0&long=0.0&language=en&networkType=WIFI&osVersion=";
		array5[8] = text29;
		array5[9] = string_10;
		string text30 = "&locale=en-IN&flow=LOGIN_REGISTER";
		array5[10] = text30;
		if (method_1(string.Concat(array5), "", text15, 2, webProxy_, ref cookieContainer_0, bool_1: true, 50000, ref string_19, ref string_4))
		{
			string text31 = string_19;
			string value = "NO_MAPPING_FOUND";
			if (text31.IndexOf(value) >= 0)
			{
				Class15 @class = new Class15();
				long num3 = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds / 1000;
				int num4 = num2 + 1;
				string[] array6 = new string[7] { str_6, null, null, null, null, null, null };
				string text32 = ":";
				array6[1] = text32;
				array6[2] = num3.ToString();
				string text33 = ":";
				array6[3] = text33;
				array6[4] = num4.ToString();
				string text34 = ":";
				array6[5] = text34;
				array6[6] = num4.ToString();
				string_16 = string.Concat(array6);
				str09 = num3.ToString();
				string text35 = "";
				string[] array7 = new string[11];
				string text36 = "https://accounts.paytm.com/v2/simple/login/init/sv1?deviceIdentifier=";
				array7[0] = text36;
				array7[1] = string_6;
				string text37 = "&deviceManufacturer=";
				array7[2] = text37;
				array7[3] = string_7;
				string text38 = "&deviceName=";
				array7[4] = text38;
				array7[5] = string_8;
				string text39 = "&client=androidapp&version=";
				array7[6] = text39;
				array7[7] = string_9;
				string text40 = "&playStore=false&lat=0.0&long=0.0&language=en&networkType=WIFI&osVersion=";
				array7[8] = text40;
				array7[9] = string_10;
				string text41 = "&locale=en-IN";
				array7[10] = text41;
				string text42 = string.Concat(array7);
				string text43 = "{\"loginId\":\"";
				string text44 = string_15;
				string text45 = "\"}";
				string text46 = text43 + text44 + text45;
				string text47 = "java_rsa_256hmac";
				string_12 = text47;
				string[] array8 = new string[24];
				string text48 = "/v2/simple/login/init/sv1|post|client=androidapp&deviceidentifier=";
				array8[0] = text48;
				array8[1] = string_6;
				string text49 = "&devicemanufacturer=";
				array8[2] = text49;
				array8[3] = string_7;
				string text50 = "&devicename=";
				array8[4] = text50;
				array8[5] = string_8;
				string text51 = "&language=en&lat=0.0&locale=en-in&long=0.0&networktype=wifi&osversion=";
				array8[6] = text51;
				array8[7] = string_10;
				string text52 = "&playstore=false&version=";
				array8[8] = text52;
				array8[9] = string_9;
				string text53 = "|authorization=";
				array8[10] = text53;
				array8[11] = string_18;
				string text54 = "&autoreadhash=asask/gtt2i&x-device-identifier=";
				array8[12] = text54;
				array8[13] = string_6;
				string text55 = "&x-device-manufacturer=";
				array8[14] = text55;
				array8[15] = string_7;
				string text56 = "&x-device-name=";
				array8[16] = text56;
				array8[17] = string_8.ToLower();
				string text57 = "&x-epoch=";
				array8[18] = text57;
				array8[19] = str09;
				string text58 = "&x-public-key=";
				array8[20] = text58;
				array8[21] = string_12;
				string text59 = "|";
				array8[22] = text59;
				array8[23] = text46;
				string a_ = string.Concat(array8);
				string_13 = @class.SHA256withRSA(a_, "", ref string_12);
				string[] array9 = new string[18];
				string text60 = "x-client-signature#";
				array9[0] = text60;
				array9[1] = string_13;
				string text61 = "||autoReadHash#asasK/GTt2i||x-app-rid#";
				array9[2] = text61;
				array9[3] = string_16;
				string text62 = "||x-device-name#";
				array9[4] = text62;
				array9[5] = string_8;
				string text63 = "||x-app-version#";
				array9[6] = text63;
				array9[7] = string_9;
				string text64 = "||x-device-manufacturer#";
				array9[8] = text64;
				array9[9] = string_7;
				string text65 = "||x-public-key#";
				array9[10] = text65;
				array9[11] = string_12;
				string text66 = "||x-device-identifier#";
				array9[12] = text66;
				array9[13] = string_6;
				string text67 = "||x-epoch#";
				array9[14] = text67;
				array9[15] = str09;
				string text68 = "||Authorization#";
				array9[16] = text68;
				array9[17] = string_18;
				str08 = string.Concat(array9);
				if (!method_1(text42, text46, text35, 2, webProxy_, ref cookieContainer_0, bool_1: true, 50000, ref string_19, ref string_4))
				{
					string text69 = "PAYTM Registration Failed-2";
					MessageBox.Show(text69);
				}
				string text70 = string_19;
				string value2 = "Please enter OTP to continue login";
				if (text70.IndexOf(value2) <= 0)
				{
					string text71 = string_19;
					string value3 = "Please enter password to continue.";
					if (text71.IndexOf(value3) < 0)
					{
						string text72 = "Some Thing Worng With PAYTM Registration Failed-1";
						MessageBox.Show(text72);
					}
					string text73 = string_19;
					string text74 = string_19;
					string value4 = "stateToken";
					string text75 = text73.Substring(text74.IndexOf(value4) + 13);
					string value5 = "\",";
					string_20 = text75.Substring(0, text75.IndexOf(value5));
					long num5 = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds / 1000;
					num4++;
					string[] array10 = new string[7] { str_6, null, null, null, null, null, null };
					string text76 = ":";
					array10[1] = text76;
					array10[2] = num5.ToString();
					string text77 = ":";
					array10[3] = text77;
					array10[4] = num4.ToString();
					string text78 = ":";
					array10[5] = text78;
					array10[6] = num4.ToString();
					string_16 = string.Concat(array10);
					str09 = num5.ToString();
					text35 = "";
					string[] array11 = new string[11];
					string text79 = "https://accounts.paytm.com/v2/simple/login/validate/password/sv1?deviceIdentifier=";
					array11[0] = text79;
					array11[1] = string_6;
					string text80 = "&deviceManufacturer=";
					array11[2] = text80;
					array11[3] = string_7;
					string text81 = "&deviceName=";
					array11[4] = text81;
					array11[5] = string_8;
					string text82 = "&client=androidapp&version=";
					array11[6] = text82;
					array11[7] = string_9;
					string text83 = "&playStore=false&lat=0.0&long=0.0&language=en&networkType=WIFI&osVersion=";
					array11[8] = text83;
					array11[9] = string_10;
					string text84 = "&locale=en-IN";
					array11[10] = text84;
					string text85 = string.Concat(array11);
					string[] array12 = new string[5];
					string text86 = "{\"password\":\"";
					array12[0] = text86;
					array12[1] = string_21;
					string text87 = "\",\"stateToken\":\"";
					array12[2] = text87;
					array12[3] = string_20;
					string text88 = "\"}";
					array12[4] = text88;
					string text89 = string.Concat(array12);
					string text90 = "java_rsa_256hmac";
					string_12 = text90;
					string[] array13 = new string[22];
					string text91 = "/v2/simple/login/validate/password/sv1|post|client=androidapp&deviceidentifier=";
					array13[0] = text91;
					array13[1] = string_6;
					string text92 = "&devicemanufacturer=";
					array13[2] = text92;
					array13[3] = string_7;
					string text93 = "&devicename=";
					array13[4] = text93;
					array13[5] = string_8;
					string text94 = "&language=en&lat=0.0&locale=en-in&long=0.0&networktype=wifi&osversion=";
					array13[6] = text94;
					array13[7] = string_10;
					string text95 = "&playstore=false&version=";
					array13[8] = text95;
					array13[9] = string_9;
					string text96 = "|authorization=";
					array13[10] = text96;
					array13[11] = string_18;
					string text97 = "&x-device-identifier=";
					array13[12] = text97;
					array13[13] = string_6;
					string text98 = "&x-device-manufacturer=";
					array13[14] = text98;
					array13[15] = string_7;
					string text99 = "&x-device-name=";
					array13[16] = text99;
					array13[17] = string_8.ToLower();
					string text100 = "&x-epoch=";
					array13[18] = text100;
					array13[19] = str09;
					string text101 = "|";
					array13[20] = text101;
					array13[21] = text89;
					string a_2 = string.Concat(array13);
					string_13 = @class.SHA256withRSA(a_2, "", ref string_12);
					string[] array14 = new string[16];
					string text102 = "x-client-signature#";
					array14[0] = text102;
					array14[1] = string_13;
					string text103 = "||x-app-rid#";
					array14[2] = text103;
					array14[3] = string_16;
					string text104 = "||x-device-name#";
					array14[4] = text104;
					array14[5] = string_8;
					string text105 = "||x-app-version#";
					array14[6] = text105;
					array14[7] = string_9;
					string text106 = "||x-device-manufacturer#";
					array14[8] = text106;
					array14[9] = string_7;
					string text107 = "||x-device-identifier#";
					array14[10] = text107;
					array14[11] = string_6;
					string text108 = "||x-epoch#";
					array14[12] = text108;
					array14[13] = str09;
					string text109 = "||Authorization#";
					array14[14] = text109;
					array14[15] = string_18;
					str08 = string.Concat(array14);
					if (!method_1(text85, text89, text35, 2, webProxy_, ref cookieContainer_0, bool_1: true, 50000, ref string_19, ref string_4))
					{
						string text110 = "PAYTM Registration Failed-2";
						MessageBox.Show(text110);
					}
				}
				string text111 = string_19;
				string value6 = "Please enter OTP to continue login.";
				if (text111.IndexOf(value6) >= 0)
				{
					txtOTP5.Visible = true;
					btnSubmit5.Visible = true;
					txtOTP5.Focus();
					do
					{
						Application.DoEvents();
						Thread.Sleep(1000);
					}
					while (!bool_0);
					string text112 = string_19;
					string text113 = string_19;
					string value7 = "stateToken";
					string text114 = text112.Substring(text113.IndexOf(value7) + 13);
					string value8 = "\",";
					string_20 = text114.Substring(0, text114.IndexOf(value8));
					long num6 = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
					num6 /= 1000;
					num4++;
					string[] array15 = new string[7] { str_6, null, null, null, null, null, null };
					string text115 = ":";
					array15[1] = text115;
					array15[2] = num6.ToString();
					string text116 = ":";
					array15[3] = text116;
					array15[4] = num4.ToString();
					string text117 = ":";
					array15[5] = text117;
					array15[6] = num4.ToString();
					string_16 = string.Concat(array15);
					str09 = num6.ToString();
					string[] array16 = new string[11];
					string text118 = "https://accounts.paytm.com/v2/simple/login/validate/otp/sv1?deviceIdentifier=";
					array16[0] = text118;
					array16[1] = string_6;
					string text119 = "&deviceManufacturer=";
					array16[2] = text119;
					array16[3] = string_7;
					string text120 = "&deviceName=";
					array16[4] = text120;
					array16[5] = string_8;
					string text121 = "&client=androidapp&version=";
					array16[6] = text121;
					array16[7] = string_9;
					string text122 = "&playStore=false&lat=0.0&long=0.0&language=en&networkType=WIFI&osVersion=";
					array16[8] = text122;
					array16[9] = string_10;
					string text123 = "&locale=en-IN";
					array16[10] = text123;
					string text124 = string.Concat(array16);
					string[] array17 = new string[5];
					string text125 = "{\"otp\":\"";
					array17[0] = text125;
					array17[1] = txtOTP5.Text;
					string text126 = "\",\"stateToken\":\"";
					array17[2] = text126;
					array17[3] = string_20;
					string text127 = "\"}";
					array17[4] = text127;
					string text128 = string.Concat(array17);
					string text129 = "java_rsa_256hmac";
					string_12 = text129;
					string[] array18 = new string[22];
					string text130 = "/v2/simple/login/validate/otp/sv1|post|client=androidapp&deviceidentifier=";
					array18[0] = text130;
					array18[1] = string_6;
					string text131 = "&devicemanufacturer=";
					array18[2] = text131;
					array18[3] = string_7;
					string text132 = "&devicename=";
					array18[4] = text132;
					array18[5] = string_8;
					string text133 = "&language=en&lat=0.0&locale=en-in&long=0.0&networktype=wifi&osversion=";
					array18[6] = text133;
					array18[7] = string_10;
					string text134 = "&playstore=false&version=";
					array18[8] = text134;
					array18[9] = string_9;
					string text135 = "|authorization=";
					array18[10] = text135;
					array18[11] = string_18;
					string text136 = "&x-device-identifier=";
					array18[12] = text136;
					array18[13] = string_6;
					string text137 = "&x-device-manufacturer=";
					array18[14] = text137;
					array18[15] = string_7;
					string text138 = "&x-device-name=";
					array18[16] = text138;
					array18[17] = string_8.ToLower();
					string text139 = "&x-epoch=";
					array18[18] = text139;
					array18[19] = str09;
					string text140 = "|";
					array18[20] = text140;
					array18[21] = text128;
					string a_3 = string.Concat(array18);
					string_13 = @class.SHA256withRSA(a_3, "", ref string_12);
					string[] array19 = new string[16];
					string text141 = "x-client-signature#";
					array19[0] = text141;
					array19[1] = string_13;
					string text142 = "||x-app-rid#";
					array19[2] = text142;
					array19[3] = string_16;
					string text143 = "||x-device-name#";
					array19[4] = text143;
					array19[5] = string_8;
					string text144 = "||x-app-version#";
					array19[6] = text144;
					array19[7] = string_9;
					string text145 = "||x-device-manufacturer#";
					array19[8] = text145;
					array19[9] = string_7;
					string text146 = "||x-device-identifier#";
					array19[10] = text146;
					array19[11] = string_6;
					string text147 = "||x-epoch#";
					array19[12] = text147;
					array19[13] = str09;
					string text148 = "||Authorization#";
					array19[14] = text148;
					array19[15] = string_18;
					str08 = string.Concat(array19);
					if (method_1(text124, text128, text35, 2, webProxy_, ref cookieContainer_0, bool_1: true, 50000, ref string_19, ref string_4))
					{
						string text149 = string_19;
						string value9 = "status\":\"success";
						if (text149.IndexOf(value9) < 0)
						{
							string text150 = "Some Thing Worng With PAYTM Registration Failed-3";
							MessageBox.Show(text150);
							return false;
						}
						string text151 = string_19;
						string text152 = string_19;
						string value10 = "oauthCode";
						string text153 = text151.Substring(text152.IndexOf(value10) + 12);
						string value11 = "\"";
						string text154 = text153.Substring(0, text153.IndexOf(value11));
						num6 = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
						num6 /= 1000;
						num4++;
						string[] array20 = new string[7] { str_6, null, null, null, null, null, null };
						string text155 = ":";
						array20[1] = text155;
						array20[2] = num6.ToString();
						string text156 = ":";
						array20[3] = text156;
						array20[4] = num4.ToString();
						string text157 = ":";
						array20[5] = text157;
						array20[6] = num4.ToString();
						string_16 = string.Concat(array20);
						str09 = num6.ToString();
						string text158 = "";
						string[] array21 = new string[11];
						string text159 = "https://accounts.paytm.com/oauth2/v3/token/sv1?deviceIdentifier=";
						array21[0] = text159;
						array21[1] = string_6;
						string text160 = "&deviceManufacturer=";
						array21[2] = text160;
						array21[3] = string_7;
						string text161 = "&deviceName=";
						array21[4] = text161;
						array21[5] = string_8;
						string text162 = "&client=androidapp&version=";
						array21[6] = text162;
						array21[7] = string_9;
						string text163 = "&playStore=false&lat=0.0&long=0.0&language=en&networkType=WIFI&osVersion=";
						array21[8] = text163;
						array21[9] = string_10;
						string text164 = "&locale=en-IN";
						array21[10] = text164;
						string text165 = string.Concat(array21);
						string[] array22 = new string[5];
						string text166 = "{\"code\":\"";
						array22[0] = text166;
						array22[1] = text154;
						string text167 = "\",\"deviceId\":\"";
						array22[2] = text167;
						array22[3] = string_6;
						string text168 = "\",\"grantType\":\"authorization_code\"}";
						array22[4] = text168;
						string text169 = string.Concat(array22);
						string[] array23 = new string[14];
						string text170 = "x-app-rid#";
						array23[0] = text170;
						array23[1] = string_16;
						string text171 = "||x-device-name#";
						array23[2] = text171;
						array23[3] = string_8;
						string text172 = "||x-app-version#";
						array23[4] = text172;
						array23[5] = string_9;
						string text173 = "||x-device-manufacturer#";
						array23[6] = text173;
						array23[7] = string_7;
						string text174 = "||x-device-identifier#";
						array23[8] = text174;
						array23[9] = string_6;
						string text175 = "||x-epoch#";
						array23[10] = text175;
						array23[11] = str09;
						string text176 = "||Authorization#";
						array23[12] = text176;
						array23[13] = string_18;
						str08 = string.Concat(array23);
						if (method_1(text165, text169, text158, 2, webProxy_, ref cookieContainer_0, bool_1: true, 50000, ref string_19, ref string_4))
						{
							string text177 = string_19;
							string value12 = "tokens";
							if (text177.IndexOf(value12) < 0)
							{
								string text178 = "Some Thing Worng With PAYTM Registration Failed-4";
								MessageBox.Show(text178);
								return false;
							}
							string text179 = string_19;
							string text180 = string_19;
							string value13 = "{\"accessToken";
							string text181 = text179.Substring(text180.IndexOf(value13));
							string value14 = "},";
							string text182 = text181.Substring(0, text181.IndexOf(value14) + 1);
							string_19 = string_19.Substring(string_19.IndexOf(text182) + 20);
							string text183 = string_19;
							string text184 = string_19;
							string value15 = "{\"accessToken";
							string text185 = text183.Substring(text184.IndexOf(value15));
							string value16 = "},";
							string text186 = text185.Substring(0, text185.IndexOf(value16) + 1);
							string_19 = string_19.Substring(string_19.IndexOf(text186) + 20);
							string text187 = string_19;
							string text188 = string_19;
							string value17 = "{\"accessToken";
							string text189 = text187.Substring(text188.IndexOf(value17));
							string value18 = "},";
							string text190 = text189.Substring(0, text189.IndexOf(value18) + 1);
							string_19 = string_19.Substring(string_19.IndexOf(text190) + 20);
							string text191 = string_19;
							string text192 = string_19;
							string value19 = "{\"accessToken";
							string text193 = text191.Substring(text192.IndexOf(value19));
							string value20 = "}";
							string text194 = text193.Substring(0, text193.IndexOf(value20));
							string oldValue = "\"";
							string text195 = text182.Replace(oldValue, "");
							string oldValue2 = "\"";
							string text196 = text186.Replace(oldValue2, "");
							string oldValue3 = "\"";
							string text197 = text190.Replace(oldValue3, "");
							string oldValue4 = "\"";
							string text198 = text194.Replace(oldValue4, "");
							string value21 = ":";
							string text199 = text197.Substring(text197.IndexOf(value21) + 1);
							string value22 = ",";
							string text200 = text199.Substring(0, text199.IndexOf(value22));
							num6 = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
							num6 /= 1000;
							num4++;
							string[] array24 = new string[7] { str_6, null, null, null, null, null, null };
							string text201 = ":";
							array24[1] = text201;
							array24[2] = num6.ToString();
							string text202 = ":";
							array24[3] = text202;
							array24[4] = num4.ToString();
							string text203 = ":";
							array24[5] = text203;
							array24[6] = num4.ToString();
							string_16 = string.Concat(array24);
							string text204 = "";
							string[] array25 = new string[11];
							string text205 = "https://paytm.com/v1/user/token/enc/generate?deviceIdentifier=";
							array25[0] = text205;
							array25[1] = string_6;
							string text206 = "&deviceManufacturer=";
							array25[2] = text206;
							array25[3] = string_7;
							string text207 = "&deviceName=";
							array25[4] = text207;
							array25[5] = string_8;
							string text208 = "&client=androidapp&version=";
							array25[6] = text208;
							array25[7] = string_9;
							string text209 = "&playStore=false&lat=0.0&long=0.0&language=en&networkType=WIFI&osVersion=";
							array25[8] = text209;
							array25[9] = string_10;
							string text210 = "&locale=en-IN";
							array25[10] = text210;
							string text211 = string.Concat(array25);
							string text212 = "";
							string text213 = "sso_token#";
							string text214 = "||x-app-rid#";
							str08 = text213 + text200 + text214 + string_16;
							if (method_1(text211, text212, text204, 2, webProxy_, ref cookieContainer_0, bool_1: true, 50000, ref string_19, ref string_4))
							{
								string text215 = string_19;
								string value23 = "sso_token_enc";
								if (text215.IndexOf(value23) >= 0)
								{
									string text216 = "3549194";
									string text217 = new Random((int)DateTime.Now.Ticks).Next(300000, 900000).ToString();
									string text218 = "76";
									string text219 = text216 + text217 + text218;
									try
									{
										btnNew5.Enabled = false;
										string[] array26 = new string[13]
										{
											string_3, null, null, null, null, null, null, null, null, null,
											null, null, null
										};
										string text220 = "||";
										array26[1] = text220;
										array26[2] = text195;
										string text221 = "||";
										array26[3] = text221;
										array26[4] = text196;
										string text222 = "||";
										array26[5] = text222;
										array26[6] = text197;
										string text223 = "||";
										array26[7] = text223;
										array26[8] = text198;
										string text224 = "||";
										array26[9] = text224;
										array26[10] = string_6;
										string text225 = "||";
										array26[11] = text225;
										array26[12] = text219;
										string_1 = string.Concat(array26);
										string string_ = "PAYTM";
										method_5(string_);
										Staticm.method_36();
										PassOtpGroupBx5.Visible = false;
										GetOtpGroupBx5.Visible = false;
										cmbBanks5.SelectedIndex = 0;
									}
									catch (Exception ex)
									{
										btnNew5.Visible = false;
										string text226 = "PAYTMOTPByPass: btnSubmit_Click";
										Class28.smethod_26(text226, ex.Message);
										string text227 = "Error occured while processing request!";
										string caption = "Error";
										MessageBox.Show(text227, caption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
									}
									return result;
								}
								string text228 = "Some Thing Worng With PAYTM Registration Failed-5";
								MessageBox.Show(text228);
								return false;
							}
							string text229 = "Some Thing Error With PAYTM OTP Bypass,\n\r\nPlease Retry After Some Time.";
							string caption2 = "By-Passed";
							MessageBox.Show(text229, caption2, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							return false;
						}
						string text230 = "PAYTM Registration Device Register Failed-4";
						MessageBox.Show(text230);
						return false;
					}
					string text231 = "PAYTM Registration OTP Verfiy Failed-3";
					MessageBox.Show(text231);
					return false;
				}
				string text232 = "Some Thing Worng With PAYTM Registration Failed-2";
				MessageBox.Show(text232);
				return false;
			}
			string text233 = "Some Thing Worng With PAYTM Registration Failed-1";
			MessageBox.Show(text233);
			return false;
		}
		string text234 = "PAYTM Registration Failed-2";
		MessageBox.Show(text234);
		return false;
	}

	internal static string smethod_8(ref string string_14, ref string string_15)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		string key = "Mi3";
		string value = "Xiomi";
		dictionary.Add(key, value);
		string key2 = "Mi4";
		string value2 = "Xiomi";
		dictionary.Add(key2, value2);
		string key3 = "P600";
		string value3 = "Micomax";
		dictionary.Add(key3, value3);
		string key4 = "GT_S5303B";
		string value4 = "Samsung";
		dictionary.Add(key4, value4);
		string key5 = "GT_C3310R";
		string value5 = "Samsung";
		dictionary.Add(key5, value5);
		string key6 = "A88_3i";
		string value6 = "Micromax";
		dictionary.Add(key6, value6);
		string key7 = "Note_A2";
		string value7 = "Karbonn";
		dictionary.Add(key7, value7);
		string key8 = "MSD7Android";
		string value8 = "MAXX";
		dictionary.Add(key8, value8);
		string key9 = "N818";
		string value9 = "ZTE";
		dictionary.Add(key9, value9);
		string key10 = "N909";
		string value10 = "ZTE";
		dictionary.Add(key10, value10);
		string key11 = "Iris351";
		string value11 = "Lava";
		dictionary.Add(key11, value11);
		string key12 = "AX8NoteII";
		string value12 = "MAXX";
		dictionary.Add(key12, value12);
		string key13 = "MSD7Touch35";
		string value13 = "MAXX";
		dictionary.Add(key13, value13);
		string key14 = "91_A3";
		string value14 = "Karbonn";
		dictionary.Add(key14, value14);
		string key15 = "911_A91";
		string value15 = "Micromax";
		dictionary.Add(key15, value15);
		string key16 = "Iris454";
		string value16 = "Lava";
		dictionary.Add(key16, value16);
		string key17 = "X1000";
		string value17 = "Xolo";
		dictionary.Add(key17, value17);
		string key18 = "K3_Note";
		string value18 = "Lenovo";
		dictionary.Add(key18, value18);
		string key19 = "B407";
		string value19 = "LEMON";
		dictionary.Add(key19, value19);
		string key20 = "Andi4v";
		string value20 = "iball";
		dictionary.Add(key20, value20);
		string key21 = "Andi5l";
		string value21 = "iball";
		dictionary.Add(key21, value21);
		string key22 = "A112";
		string value22 = "Micromax";
		dictionary.Add(key22, value22);
		string key23 = "9_A4";
		string value23 = "Karbonn";
		dictionary.Add(key23, value23);
		string key24 = "MI_530";
		string value24 = "Spice";
		dictionary.Add(key24, value24);
		string key25 = "55_A62";
		string value25 = "Micromax";
		dictionary.Add(key25, value25);
		string key26 = "60_A115";
		string value26 = "Micromax";
		dictionary.Add(key26, value26);
		string key27 = "P880g";
		string value27 = "LG";
		dictionary.Add(key27, value27);
		string key28 = "8_A520";
		string value28 = "Lenovo";
		dictionary.Add(key28, value28);
		string key29 = "9_Q700";
		string value29 = "XOLO";
		dictionary.Add(key29, value29);
		string key30 = "5_B700";
		string value30 = "XOLO";
		dictionary.Add(key30, value30);
		string key31 = "6_A500";
		string value31 = "Xolo";
		dictionary.Add(key31, value31);
		string key32 = "1_A800";
		string value32 = "Xolo";
		dictionary.Add(key32, value32);
		string key33 = "2_A700";
		string value33 = "XOLO";
		dictionary.Add(key33, value33);
		string key34 = "35_A90S";
		string value34 = "Micromax";
		dictionary.Add(key34, value34);
		Dictionary<string, string> dictionary2 = dictionary;
		Random random = new Random((int)DateTime.Now.Ticks);
		KeyValuePair<string, string> keyValuePair = dictionary2.ElementAt(random.Next(0, dictionary2.Count - 1));
		string_15 = keyValuePair.Key;
		string_14 = keyValuePair.Value;
		string[] array = new string[6] { string_14, null, null, null, null, null };
		string text = "-";
		array[1] = text;
		array[2] = string_15;
		string text2 = "-1449194";
		array[3] = text2;
		array[4] = random.Next(300000, 900000).ToString();
		string text3 = "760180f";
		array[5] = text3;
		return string.Concat(array);
	}

	internal bool method_1(string string_14, string string_15, string string_16, int int_0, WebProxy webProxy_0, ref CookieContainer cookieContainer_1, bool bool_1, int int_1, ref string string_17, ref string string_18)
	{
		int num = 0;
		if (!string.IsNullOrEmpty(str08))
		{
			string_22 = str08;
		}
		string text = "Tls";
		string text2 = text;
		WebProxy proxy = null;
		bool result = false;
		bool flag;
		do
		{
			string_18 = "";
			string_17 = "";
			flag = false;
			HttpWebResponse httpWebResponse = null;
			string text3 = "";
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string_14);
				ServicePointManager.ServerCertificateValidationCallback = smethod_01;
				httpWebRequest.Proxy = webProxy_0;
				httpWebRequest.Proxy = proxy;
				httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip;
				string text4 = text2;
				string text5 = "Tls";
				bool flag2 = text4 == text5;
				string text6 = text2;
				string text7 = "Ssl3";
				if (flag2 | (text6 == text7))
				{
					ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				}
				if (int_1 > 0)
				{
					httpWebRequest.Timeout = int_1;
					httpWebRequest.ReadWriteTimeout = int_1;
				}
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
				string contentType = "application/x-www-form-urlencoded";
				httpWebRequest.ContentType = contentType;
				string value = "{\"";
				if (string_15.Contains(value) || int_0 == 2)
				{
					string contentType2 = "application/json";
					httpWebRequest.ContentType = contentType2;
				}
				httpWebRequest.UserAgent = UserAgent;
				if (!string.IsNullOrEmpty(string_22))
				{
					string expression = string_22;
					string delimiter = "||";
					string[] array = Strings.Split(expression, delimiter);
					int num2 = Information.UBound(array);
					for (int i = 0; i <= num2; i++)
					{
						string expression2 = array[i];
						string delimiter2 = "#";
						string[] array2 = Strings.Split(expression2, delimiter2);
						httpWebRequest.Headers.Set(array2[0], array2[1]);
					}
					str08 = "";
				}
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
				using (StreamReader textReader_ = smethod_5(httpWebResponse.GetResponseStream()))
				{
					text3 = smethod_4(textReader_);
				}
				string_17 = text3;
				flag = true;
			}
			catch (Exception ex)
			{
				flag = false;
				string_18 = ex.Message;
				string text8 = "SBIOTPByPass: WebRequestPost";
				Class28.smethod_26(text8, string_18);
				string text9 = string_18.ToUpper();
				string value2 = "CONNECTION WAS CLOSED";
				if (!text9.Contains(value2))
				{
					string text10 = string_18.ToUpper();
					string value3 = "SERVICEUNAVAILABLE";
					text10.Contains(value3);
				}
				string text11 = string_18;
				string value4 = "The underlying connection was closed";
				if (text11.Contains(value4))
				{
					string text12 = "Tls12";
					text2 = text12;
				}
				string text13 = string_18;
				string value5 = "The underlying connection was closed";
				if (text13.Contains(value5) && num >= 1)
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
			int[,] array3 = new int[1, 6] { { 31609625, 1025238546, 388491046, 2144024754, 369799219, 1025238545 } };
			switch (array3[0, 1])
			{
			default:
				return result;
			case 1025238546:
				return flag;
			case 1025238544:
				break;
			}
		}
	}

	private static string smethod_4(TextReader textReader_0)
	{
		return textReader_0.ReadToEnd();
	}

	public static bool smethod_01(object A_0, System.Security.Cryptography.X509Certificates.X509Certificate A_1, X509Chain A_2, SslPolicyErrors A_3)
	{
		try
		{
			string text = A_1.Issuer.ToLower();
			string value = "httpanalyze";
			if (!text.Contains(value))
			{
				string text2 = A_1.Issuer.ToLower();
				string value2 = "fiddler";
				if (!text2.Contains(value2))
				{
					string text3 = A_1.Issuer.ToLower();
					string value3 = "commview";
					if (!text3.Contains(value3))
					{
						string text4 = A_1.Issuer.ToLower();
						string value4 = "debugger";
						if (!text4.Contains(value4))
						{
							string text5 = A_1.Issuer.ToLower();
							string value5 = "debug";
							if (!text5.Contains(value5))
							{
								string text6 = A_1.Issuer.ToLower();
								string value6 = "sniffer";
								if (!text6.Contains(value6))
								{
									string text7 = A_1.Issuer.ToUpper();
									string value7 = "IEINSPECTOR";
									if (!text7.Contains(value7))
									{
										return true;
									}
								}
							}
						}
					}
				}
			}
			Form owner = new Form
			{
				TopMost = true
			};
			string text8 = "Security Failed for S/w. Your ID has been logged.\r\n\r\nPlease contact Your Admin.";
			string caption = "Security";
			MessageBox.Show(owner, text8, caption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			Application.Exit();
			return false;
		}
		catch (Exception)
		{
			return true;
		}
	}

	private static StreamReader smethod_5(Stream stream_0)
	{
		return new StreamReader(stream_0);
	}

	private static string smethod_6(TextReader textReader_0)
	{
		return textReader_0.ReadToEnd();
	}

	private void btnSubmit5_Click(object sender, EventArgs e)
	{
		bool_0 = true;
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.groupBox8 = new System.Windows.Forms.GroupBox();
		this.PassOtpGroupBx5 = new System.Windows.Forms.GroupBox();
		this.btnSubmit5 = new System.Windows.Forms.Button();
		this.label23 = new System.Windows.Forms.Label();
		this.label24 = new System.Windows.Forms.Label();
		this.label25 = new System.Windows.Forms.Label();
		this.label42 = new System.Windows.Forms.Label();
		this.label43 = new System.Windows.Forms.Label();
		this.btnNew5 = new System.Windows.Forms.Button();
		this.btnBrowse5 = new System.Windows.Forms.Button();
		this.txtOTP5 = new System.Windows.Forms.TextBox();
		this.label44 = new System.Windows.Forms.Label();
		this.GetOtpGroupBx5 = new System.Windows.Forms.GroupBox();
		this.textBox7 = new System.Windows.Forms.TextBox();
		this.btnGenrte5 = new System.Windows.Forms.Button();
		this.cmbBanks5 = new System.Windows.Forms.ComboBox();
		this.label46 = new System.Windows.Forms.Label();
		this.lblStatus1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.button16 = new System.Windows.Forms.Button();
		this.progressBar1 = new System.Windows.Forms.ProgressBar();
		this.groupBox8.SuspendLayout();
		this.PassOtpGroupBx5.SuspendLayout();
		this.GetOtpGroupBx5.SuspendLayout();
		base.SuspendLayout();
		this.groupBox8.Controls.Add(this.PassOtpGroupBx5);
		this.groupBox8.Controls.Add(this.GetOtpGroupBx5);
		this.groupBox8.Controls.Add(this.cmbBanks5);
		this.groupBox8.Controls.Add(this.label46);
		this.groupBox8.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold);
		this.groupBox8.ForeColor = System.Drawing.Color.Black;
		this.groupBox8.Location = new System.Drawing.Point(2, 2);
		this.groupBox8.Name = "groupBox8";
		this.groupBox8.Size = new System.Drawing.Size(384, 222);
		this.groupBox8.TabIndex = 1;
		this.groupBox8.TabStop = false;
		this.groupBox8.Text = "By-Pass PAYTM";
		this.PassOtpGroupBx5.Controls.Add(this.btnSubmit5);
		this.PassOtpGroupBx5.Controls.Add(this.label23);
		this.PassOtpGroupBx5.Controls.Add(this.label24);
		this.PassOtpGroupBx5.Controls.Add(this.label25);
		this.PassOtpGroupBx5.Controls.Add(this.label42);
		this.PassOtpGroupBx5.Controls.Add(this.label43);
		this.PassOtpGroupBx5.Controls.Add(this.btnNew5);
		this.PassOtpGroupBx5.Controls.Add(this.btnBrowse5);
		this.PassOtpGroupBx5.Controls.Add(this.txtOTP5);
		this.PassOtpGroupBx5.Controls.Add(this.label44);
		this.PassOtpGroupBx5.ForeColor = System.Drawing.Color.Black;
		this.PassOtpGroupBx5.Location = new System.Drawing.Point(6, 47);
		this.PassOtpGroupBx5.Name = "PassOtpGroupBx5";
		this.PassOtpGroupBx5.Size = new System.Drawing.Size(378, 170);
		this.PassOtpGroupBx5.TabIndex = 1174;
		this.PassOtpGroupBx5.TabStop = false;
		this.PassOtpGroupBx5.Text = "By-Pass OTP";
		this.PassOtpGroupBx5.Visible = false;
		this.btnSubmit5.BackColor = System.Drawing.Color.Transparent;
		this.btnSubmit5.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnSubmit5.ForeColor = System.Drawing.Color.Black;
		this.btnSubmit5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnSubmit5.Location = new System.Drawing.Point(262, 138);
		this.btnSubmit5.Name = "btnSubmit5";
		this.btnSubmit5.Size = new System.Drawing.Size(108, 24);
		this.btnSubmit5.TabIndex = 134;
		this.btnSubmit5.Text = "      Submit";
		this.btnSubmit5.UseVisualStyleBackColor = false;
		this.btnSubmit5.Visible = false;
		this.btnSubmit5.Click += new System.EventHandler(btnSubmit5_Click);
		this.label23.AutoSize = true;
		this.label23.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label23.ForeColor = System.Drawing.Color.Black;
		this.label23.Location = new System.Drawing.Point(17, 141);
		this.label23.Name = "label23";
		this.label23.Size = new System.Drawing.Size(149, 16);
		this.label23.TabIndex = 133;
		this.label23.Text = "(OTP Vaild For 6 Days)";
		this.label24.AutoSize = true;
		this.label24.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label24.ForeColor = System.Drawing.Color.Black;
		this.label24.Location = new System.Drawing.Point(65, 15);
		this.label24.Name = "label24";
		this.label24.Size = new System.Drawing.Size(191, 16);
		this.label24.TabIndex = 129;
		this.label24.Text = "Select Existing By-Pass File: ";
		this.label25.AutoSize = true;
		this.label25.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label25.ForeColor = System.Drawing.Color.Black;
		this.label25.Location = new System.Drawing.Point(93, 76);
		this.label25.Name = "label25";
		this.label25.Size = new System.Drawing.Size(147, 16);
		this.label25.TabIndex = 132;
		this.label25.Text = "Create New By-Pass : ";
		this.label42.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
		this.label42.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label42.ForeColor = System.Drawing.Color.Black;
		this.label42.Location = new System.Drawing.Point(2, 262);
		this.label42.Name = "label42";
		this.label42.Size = new System.Drawing.Size(372, 32);
		this.label42.TabIndex = 50;
		this.label42.Text = "Enter this First OTP into ICICI Website. Please refer steps. On success message click Success Button below.";
		this.label42.Visible = false;
		this.label43.AutoSize = true;
		this.label43.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
		this.label43.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label43.ForeColor = System.Drawing.Color.Black;
		this.label43.Location = new System.Drawing.Point(166, 40);
		this.label43.Name = "label43";
		this.label43.Size = new System.Drawing.Size(0, 16);
		this.label43.TabIndex = 131;
		this.btnNew5.BackColor = System.Drawing.Color.Transparent;
		this.btnNew5.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnNew5.ForeColor = System.Drawing.Color.Black;
		this.btnNew5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnNew5.Location = new System.Drawing.Point(262, 72);
		this.btnNew5.Name = "btnNew5";
		this.btnNew5.Size = new System.Drawing.Size(108, 25);
		this.btnNew5.TabIndex = 53;
		this.btnNew5.Text = "     Bypass New";
		this.btnNew5.UseVisualStyleBackColor = false;
		this.btnNew5.Click += new System.EventHandler(BtnNew5_Click);
		this.btnBrowse5.BackColor = System.Drawing.Color.Transparent;
		this.btnBrowse5.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnBrowse5.ForeColor = System.Drawing.Color.Black;
		this.btnBrowse5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnBrowse5.Location = new System.Drawing.Point(277, 12);
		this.btnBrowse5.Name = "btnBrowse5";
		this.btnBrowse5.Size = new System.Drawing.Size(93, 25);
		this.btnBrowse5.TabIndex = 130;
		this.btnBrowse5.Text = "      Browse";
		this.btnBrowse5.UseVisualStyleBackColor = false;
		this.btnBrowse5.Click += new System.EventHandler(btnBrowse5_Click);
		this.txtOTP5.BackColor = System.Drawing.Color.White;
		this.txtOTP5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtOTP5.ForeColor = System.Drawing.Color.Black;
		this.txtOTP5.Location = new System.Drawing.Point(262, 107);
		this.txtOTP5.MaxLength = 6;
		this.txtOTP5.Name = "txtOTP5";
		this.txtOTP5.Size = new System.Drawing.Size(108, 20);
		this.txtOTP5.TabIndex = 55;
		this.txtOTP5.Visible = false;
		this.label44.AutoSize = true;
		this.label44.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label44.ForeColor = System.Drawing.Color.Black;
		this.label44.Location = new System.Drawing.Point(166, 112);
		this.label44.Name = "label44";
		this.label44.Size = new System.Drawing.Size(70, 14);
		this.label44.TabIndex = 56;
		this.label44.Text = "Enter OTP : ";
		this.GetOtpGroupBx5.Controls.Add(this.textBox7);
		this.GetOtpGroupBx5.Controls.Add(this.btnGenrte5);
		this.GetOtpGroupBx5.ForeColor = System.Drawing.Color.Black;
		this.GetOtpGroupBx5.Location = new System.Drawing.Point(10, 47);
		this.GetOtpGroupBx5.Name = "GetOtpGroupBx5";
		this.GetOtpGroupBx5.Size = new System.Drawing.Size(335, 118);
		this.GetOtpGroupBx5.TabIndex = 1173;
		this.GetOtpGroupBx5.TabStop = false;
		this.GetOtpGroupBx5.Text = "Genrate OTP";
		this.textBox7.BackColor = System.Drawing.Color.White;
		this.textBox7.ForeColor = System.Drawing.Color.Black;
		this.textBox7.Location = new System.Drawing.Point(6, 22);
		this.textBox7.Multiline = true;
		this.textBox7.Name = "textBox7";
		this.textBox7.Size = new System.Drawing.Size(247, 57);
		this.textBox7.TabIndex = 8;
		this.btnGenrte5.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
		this.btnGenrte5.ForeColor = System.Drawing.Color.Black;
		this.btnGenrte5.Location = new System.Drawing.Point(232, 83);
		this.btnGenrte5.Name = "btnGenrte5";
		this.btnGenrte5.Size = new System.Drawing.Size(97, 26);
		this.btnGenrte5.TabIndex = 4;
		this.btnGenrte5.Text = "Genrate OTP";
		this.btnGenrte5.UseVisualStyleBackColor = false;
		this.btnGenrte5.Click += new System.EventHandler(btnGenrte5_Click);
		this.cmbBanks5.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
		this.cmbBanks5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbBanks5.ForeColor = System.Drawing.Color.Black;
		this.cmbBanks5.FormattingEnabled = true;
		this.cmbBanks5.Location = new System.Drawing.Point(102, 19);
		this.cmbBanks5.Name = "cmbBanks5";
		this.cmbBanks5.Size = new System.Drawing.Size(232, 22);
		this.cmbBanks5.TabIndex = 1170;
		this.cmbBanks5.SelectedIndexChanged += new System.EventHandler(cmbBanks5_SelectedIndexChanged);
		this.label46.AutoSize = true;
		this.label46.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label46.ForeColor = System.Drawing.Color.Black;
		this.label46.Location = new System.Drawing.Point(17, 22);
		this.label46.Name = "label46";
		this.label46.Size = new System.Drawing.Size(80, 14);
		this.label46.TabIndex = 1169;
		this.label46.Text = "Select Bank : ";
		this.lblStatus1.AutoSize = true;
		this.lblStatus1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblStatus1.ForeColor = System.Drawing.Color.Black;
		this.lblStatus1.Location = new System.Drawing.Point(884, 246);
		this.lblStatus1.Name = "lblStatus1";
		this.lblStatus1.Size = new System.Drawing.Size(97, 16);
		this.lblStatus1.TabIndex = 1179;
		this.lblStatus1.Text = "Surfing Status";
		this.label2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label2.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.label2.Location = new System.Drawing.Point(504, 230);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(477, 32);
		this.label2.TabIndex = 1176;
		this.label2.Text = "Note : ";
		this.label2.Visible = false;
		this.button16.BackColor = System.Drawing.Color.Transparent;
		this.button16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.button16.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button16.ForeColor = System.Drawing.Color.Black;
		this.button16.Location = new System.Drawing.Point(600, 37);
		this.button16.Name = "button16";
		this.button16.Size = new System.Drawing.Size(42, 22);
		this.button16.TabIndex = 1175;
		this.button16.UseVisualStyleBackColor = false;
		this.progressBar1.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
		this.progressBar1.ForeColor = System.Drawing.Color.Black;
		this.progressBar1.Location = new System.Drawing.Point(2, 276);
		this.progressBar1.Name = "progressBar1";
		this.progressBar1.Size = new System.Drawing.Size(484, 11);
		this.progressBar1.TabIndex = 1180;
		base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		base.Controls.Add(this.lblStatus1);
		base.Controls.Add(this.groupBox8);
		base.Controls.Add(this.button16);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.progressBar1);
		this.DoubleBuffered = true;
		base.Name = "tabPaytmSetting0";
		base.Size = new System.Drawing.Size(420, 257);
		base.Load += new System.EventHandler(tabPaytmSetting_Load);
		this.groupBox8.ResumeLayout(false);
		this.groupBox8.PerformLayout();
		this.PassOtpGroupBx5.ResumeLayout(false);
		this.PassOtpGroupBx5.PerformLayout();
		this.GetOtpGroupBx5.ResumeLayout(false);
		this.GetOtpGroupBx5.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private void btnGenrte5_Click(object sender, EventArgs e)
	{
	}
}
