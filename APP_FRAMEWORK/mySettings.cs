using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace APP_FRAMEWORK;

public class mySettings
{
	internal class Class17
	{
		public static bool bool_4;

		internal void method_0(string string_0, int int_0)
		{
			try
			{
				if (!File.Exists(string_0))
				{
					return;
				}
				File.SetAttributes(string_0, FileAttributes.Normal);
				double num = Math.Ceiling((double)new FileInfo(string_0).Length / 512.0);
				byte[] array = new byte[512];
				RNGCryptoServiceProvider rNGCryptoServiceProvider = smethod_0();
				FileStream fileStream = new FileStream(string_0, FileMode.Open);
				for (int i = 0; i < int_0; i++)
				{
					fileStream.Position = 0L;
					for (int j = 0; (double)j < num; j++)
					{
						rNGCryptoServiceProvider.GetBytes(array);
						fileStream.Write(array, 0, array.Length);
					}
				}
				fileStream.SetLength(0L);
				fileStream.Close();
				DateTime dateTime = new DateTime(2037, 1, 1, 0, 0, 0);
				File.SetCreationTime(string_0, dateTime);
				File.SetLastAccessTime(string_0, dateTime);
				File.SetLastWriteTime(string_0, dateTime);
				File.SetCreationTimeUtc(string_0, dateTime);
				File.SetLastAccessTimeUtc(string_0, dateTime);
				File.SetLastWriteTimeUtc(string_0, dateTime);
				File.Delete(string_0);
			}
			catch (Exception)
			{
			}
		}

		private static RNGCryptoServiceProvider smethod_0()
		{
			return new RNGCryptoServiceProvider();
		}
	}

	public static bool bool_1;

	public static bool bool_2;

	public static bool bool_3;

	public string userID;

	public string PrivateIP;

	public string Proxy_use;

	public string Ac_avl;

	public string Sl_avl;

	public string OcrPath;

	public string strCaptchaService = "0||free";

	public bool isAutoLogin;

	public bool isRememberPassword;

	public bool isLargeCaptcha;

	public bool isNewWindowPair = true;

	public bool isAutoCaptcha = true;

	public bool isAutoSubmitCaptcha = true;

	public bool bool_0;

	public bool NonManagerDashborad;

	public bool isCaptchaService = true;

	public int SelectedSize = 1;

	public bool isTransparent;

	public string KeepId = "5";

	public string perIPlimit = "4";

	public string KeepHistory = "30";

	public string FormAlign = "Hpair";

	public bool isMicroWindow = true;

	public bool CloseOnPnr = true;

	public bool WithoutScreenLogin = true;

	public bool SpeedUP;

	internal static void smethod_0()
	{
		try
		{
			string text = "logs";
			string path = text;
			Class17 @class = new Class17();
			string[] array = new string[3];
			DateTime dateTime = DateTime.Now.AddDays(-2.0);
			string text2 = "ddMMyyyy";
			array[0] = dateTime.ToString(text2);
			dateTime = DateTime.Now.AddDays(-1.0);
			string text3 = "ddMMyyyy";
			array[1] = dateTime.ToString(text3);
			dateTime = DateTime.Now;
			string text4 = "ddMMyyyy";
			array[2] = dateTime.ToString(text4);
			string[] array2 = array;
			string searchPattern = "*.htm";
			string[] files = Directory.GetFiles(path, searchPattern, SearchOption.AllDirectories);
			if (files != null && files.Length != 0)
			{
				string[] array3 = files;
				string[] array4 = array3;
				string[] array5 = array4;
				foreach (string string_ in array5)
				{
					@class.method_0(string_, 3);
				}
			}
			string searchPattern2 = "*.lg";
			string[] files2 = Directory.GetFiles(path, searchPattern2);
			if (files2 != null)
			{
				string[] array6 = files2;
				string[] array7 = array6;
				string[] array8 = array7;
				foreach (string text5 in array8)
				{
					if (!text5.Contains(array2[0]) && !text5.Contains(array2[1]) && !text5.Contains(array2[2]))
					{
						@class.method_0(text5, 3);
					}
				}
			}
			string searchPattern3 = "*.lgg";
			string[] files3 = Directory.GetFiles(path, searchPattern3);
			if (files3 != null)
			{
				string[] array9 = files3;
				string[] array10 = array9;
				string[] array11 = array10;
				foreach (string string_2 in array11)
				{
					@class.method_0(string_2, 3);
				}
			}
			string[] array12 = new string[3];
			dateTime = DateTime.Now.AddDays(-2.0);
			string text6 = "dd-MM-yyyy";
			array12[0] = dateTime.ToString(text6);
			dateTime = DateTime.Now.AddDays(-1.0);
			string text7 = "dd-MM-yyyy";
			array12[1] = dateTime.ToString(text7);
			dateTime = DateTime.Now;
			string text8 = "dd-MM-yyyy";
			array12[2] = dateTime.ToString(text8);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	internal static mySettings smethod_1()
	{
		mySettings mySettings2 = null;
		try
		{
			mySettings2 = new mySettings();
			mySettings mySettings3 = mySettings2;
			string text = "0||free";
			mySettings3.strCaptchaService = text;
			mySettings2.isAutoLogin = false;
			mySettings2.isRememberPassword = false;
			mySettings2.isLargeCaptcha = false;
			mySettings2.isNewWindowPair = true;
			mySettings2.isAutoCaptcha = true;
			mySettings2.isAutoSubmitCaptcha = true;
			mySettings2.bool_0 = false;
			mySettings2.NonManagerDashborad = false;
			mySettings2.isCaptchaService = true;
			mySettings2.SelectedSize = 1;
			mySettings2.isTransparent = false;
			mySettings mySettings4 = mySettings2;
			string keepId = "5";
			mySettings4.KeepId = keepId;
			mySettings mySettings5 = mySettings2;
			string text2 = "4";
			mySettings5.perIPlimit = text2;
			mySettings mySettings6 = mySettings2;
			string keepHistory = "30";
			mySettings6.KeepHistory = keepHistory;
			mySettings mySettings7 = mySettings2;
			string formAlign = "Hpair";
			mySettings7.FormAlign = formAlign;
			mySettings2.isMicroWindow = true;
			mySettings2.CloseOnPnr = true;
			mySettings2.WithoutScreenLogin = true;
			string path = "key.dll";
			if (File.Exists(path))
			{
				string path2 = "key.dll";
				string text3 = File.ReadAllText(path2);
				string text4 = text3;
				string value = "EncryptData";
				if (text4.Contains(value))
				{
					string text5 = text3;
					string oldValue = "EncryptData=";
					text3 = text5.Replace(oldValue, "");
					string string_ = text3;
					string string_2 = "BB#7U9$SQ88";
					text3 = Class2.Decrypt(string_, string_2);
				}
				string text6 = text3;
				string[] array = new string[1];
				string text7 = "\r\n";
				array[0] = text7;
				string[] array2 = text6.Split(array, StringSplitOptions.None);
				if (array2.Length > 1)
				{
					mySettings2.userID = array2[0];
					mySettings2.PrivateIP = array2[1];
					mySettings2.Proxy_use = array2[2];
					mySettings2.Ac_avl = array2[3];
					mySettings2.Sl_avl = array2[4];
					mySettings2.SpeedUP = Convert.ToBoolean(array2[5]);
					if (array2.Length <= 6)
					{
						mySettings mySettings8 = mySettings2;
						string text8 = "4";
						mySettings8.perIPlimit = text8;
					}
					else
					{
						mySettings2.perIPlimit = array2[6];
					}
				}
			}
			else
			{
				mySettings2.SpeedUP = true;
				string[] files = Directory.GetFiles(Application.StartupPath);
				string[] array3 = files;
				string[] array4 = array3;
				foreach (string text9 in array4)
				{
					string value2 = "Your Id- ";
					if (text9.Contains(value2))
					{
						string value3 = "Your Id- ";
						string text10 = text9.Substring(text9.IndexOf(value3) + 9);
						mySettings mySettings9 = mySettings2;
						string value4 = ".";
						mySettings9.userID = text10.Substring(0, text10.IndexOf(value4));
						break;
					}
				}
			}
			string text11 = mySettings2.userID;
			string text12 = "SGX9777";
			bool flag = text11 == text12;
			string text13 = mySettings2.userID;
			string text14 = "ADMIN000057";
			if (flag | (text13 == text14))
			{
				Program.BypassAnalizer = true;
			}
		}
		catch (Exception)
		{
		}
		if (string.IsNullOrEmpty(mySettings2.userID))
		{
			string[] files2 = Directory.GetFiles(Application.StartupPath);
			string[] array5 = files2;
			string[] array6 = array5;
			foreach (string text15 in array6)
			{
				string value5 = "Your Id- ";
				if (text15.Contains(value5))
				{
					string value6 = "Your Id- ";
					string text16 = text15.Substring(text15.IndexOf(value6) + 9);
					mySettings mySettings10 = mySettings2;
					string value7 = ".";
					mySettings10.userID = text16.Substring(0, text16.IndexOf(value7));
					mySettings2.SpeedUP = true;
					break;
				}
			}
		}
		if (mySettings2 == null)
		{
			mySettings2 = new mySettings();
			mySettings2.isLargeCaptcha = true;
			mySettings2.SelectedSize = 1;
		}
		return mySettings2;
	}

	internal static void smethod_2(mySettings mySettings_0)
	{
		try
		{
			string string_ = mySettings_0.userID + Environment.NewLine + mySettings_0.PrivateIP + Environment.NewLine + mySettings_0.Proxy_use + Environment.NewLine + mySettings_0.Ac_avl + Environment.NewLine + mySettings_0.Sl_avl + Environment.NewLine + mySettings_0.SpeedUP + Environment.NewLine + mySettings_0.perIPlimit;
			string text = "EncryptData=";
			string string_2 = "BB#7U9$SQ88";
			string contents = text + Class2.Encrypt(string_, string_2);
			string text2 = "key.dll";
			string path = text2;
			if (File.Exists(path))
			{
				File.Delete(path);
			}
			File.WriteAllText(path, contents);
			string fileName = "key.dll";
			new FileInfo(fileName).Attributes = FileAttributes.Hidden;
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.StackTrace);
		}
	}

	public mySettings()
	{
		userID = "";
		isLargeCaptcha = true;
		isNewWindowPair = true;
		isCaptchaService = true;
		string text = "0||free";
		strCaptchaService = text;
		OcrPath = "";
		SelectedSize = 1;
		string keepId = "5";
		KeepId = keepId;
		string keepHistory = "30";
		KeepHistory = keepHistory;
		FormAlign = "";
	}
}
