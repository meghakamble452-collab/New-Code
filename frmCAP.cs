using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Ionic.Zip;
using Microsoft.VisualBasic;

internal class frmCAP : Form
{
	[CompilerGenerated]
	private sealed class Class33
	{
		public Random random_0;

		internal char method_0(string string_0)
		{
			return string_0[random_0.Next(string_0.Length)];
		}
	}

	private static readonly IntPtr intptr_0 = new IntPtr(-1);

	private IntPtr intptr_1 = IntPtr.Zero;

	private Control control_0;

	private StringBuilder stringBuilder_0 = new StringBuilder(256);

	private object object_0;

	private string string_0;

	private bool bool_0;

	private bool bool_1;

	private Bitmap bitmap_0;

	private clsMain class28_0;

	internal string string_1;

	internal string string_2;

	private string string_3;

	private string string_4;

	private string string_5;

	private string string_6;

	private string string_7 = "t0068MgAAAERBVGbU0doQNALeQNjb4EluWL7F3Z7VIRl1xNDM9N3YJi0ZXpzT68l6lZPPOAyQM6VYKvBzNBAW6e8m7ODgk2s=";

	private Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();

	private IContainer icontainer_0;

	private BunifuElipse bunifuElipse_0;

	private Panel pnlHeader;

	internal Label tktname;

	private BunifuImageButton btnCancel;

	private PictureBox picOriginal;

	public Button btnSubmit;

	internal TextBox txtImageData;

	public Button btnReferesh;

	private Panel panel1;

	private Button btnREF;

	private IContainer components;

	private System.Windows.Forms.Timer timer1;

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	internal static extern bool SetWindowPos(IntPtr intptr_2, IntPtr intptr_3, int int_0, int int_1, int int_2, int int_3, uint uint_0);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern IntPtr GetFocus();

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	private static extern IntPtr GetForegroundWindow();

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	private static extern bool SetForegroundWindow(IntPtr intptr_2);

	[DllImport("user32.dll", SetLastError = true)]
	private static extern IntPtr SetParent(IntPtr intptr_2, IntPtr intptr_3);

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern int GetClassName(IntPtr intptr_2, StringBuilder stringBuilder_1, int int_0);

	internal frmCAP(clsMain class28_1)
	{
		InitializeComponent();
		class28_0 = class28_1;
	}

	private string method_0(Image image_0)
	{
		try
		{
			MemoryStream memoryStream = new MemoryStream();
			image_0.Save(memoryStream, ImageFormat.Bmp);
			memoryStream.Position = 0L;
			return Convert.ToBase64String(memoryStream.ToArray());
		}
		catch (Exception)
		{
			return "Error converting image to base64!";
		}
	}

	private string method_1(int int_0, string string_8)
	{
		Random random_0 = new Random();
		return new string((from string_0 in Enumerable.Repeat(string_8, int_0)
			select string_0[random_0.Next(string_0.Length)]).ToArray());
	}

	internal void method_2(Control control_1, Rectangle rectangle_0)
	{
		_ = control_1.Controls[0];
		Control control = control_1.Parent;
		base.Size = rectangle_0.Size;
		base.StartPosition = FormStartPosition.Manual;
		base.Location = control.Location;
		base.Left += 2;
		base.Height += -6;
		base.TopMost = true;
	}

	internal Bitmap method_3(Bitmap bitmap_1)
	{
		Color white = Color.White;
		Color pixel = bitmap_1.GetPixel(0, 0);
		Bitmap bitmap = new Bitmap(bitmap_1.Width, bitmap_1.Height);
		for (int i = 0; i < bitmap_1.Width; i++)
		{
			for (int j = 0; j < bitmap_1.Height; j++)
			{
				Color pixel2 = bitmap_1.GetPixel(i, j);
				if ((pixel2.R == pixel.R) & (pixel2.G == pixel.G) & (pixel2.B == pixel.B))
				{
					bitmap.SetPixel(i, j, white);
				}
				else
				{
					bitmap.SetPixel(i, j, pixel2);
				}
			}
		}
		return bitmap;
	}

	internal void method_4(Control control_1, Rectangle rectangle_0, Bitmap bitmap_1, string string_8, string string_9, string string_10)
	{
		method_2(control_1, rectangle_0);
		string_1 = string_8;
		string_2 = string_9;
		try
		{
			string_0 = string_10;
			try
			{
				method_5();
				frmCaptcha.SetWindowPos(base.Handle, intptr_0, 0, 0, 0, 0, 3u);
				btnReferesh_Click(null, null);
			}
			catch
			{
			}
			base.TopMost = true;
			ShowDialog();
		}
		catch (Exception)
		{
		}
	}

	private void btnReferesh_Click(object sender, EventArgs e)
	{
		try
		{
			txtImageData.Text = "";
			ThreadPool.QueueUserWorkItem(method_6, null);
		}
		catch
		{
		}
	}

	private void method_5()
	{
		try
		{
			intptr_1 = GetForegroundWindow();
			if (intptr_1 != IntPtr.Zero)
			{
				GetClassName(intptr_1, stringBuilder_0, stringBuilder_0.Capacity);
				control_0 = Control.FromHandle(intptr_1);
			}
		}
		catch
		{
			intptr_1 = IntPtr.Zero;
		}
	}

	private void method_6(object object_1)
	{
		try
		{
			string text = "";
			Bitmap bitmap = new Bitmap(method_11(string_0));
			if (bitmap.Height == 270 && bitmap.Width == 300)
			{
				picOriginal.BackgroundImageLayout = ImageLayout.Stretch;
				picOriginal.SizeMode = PictureBoxSizeMode.AutoSize;
				picOriginal.Location = new Point(0, -160);
				picOriginal.Image = bitmap;
				picOriginal.Refresh();
			}
			else if (bitmap.Height > 265)
			{
				bool_0 = false;
				bool_1 = true;
				picOriginal.Image = bitmap;
				picOriginal.Refresh();
				picOriginal.Location = new Point(-30, -217);
			}
			else if (bitmap.Height < 25)
			{
				int num = bitmap.Width;
				int num2 = bitmap.Height;
				bool_1 = false;
				bool_0 = false;
				picOriginal.Width = num;
				picOriginal.Height = num2;
				picOriginal.Location = new Point(-140, 31);
				picOriginal.Image = bitmap;
				picOriginal.Refresh();
			}
			else
			{
				if ((bitmap.Height > 90) & (bitmap.Height < 100))
				{
					picOriginal.Location = new Point(0, 21);
					picOriginal.Image = bitmap;
					picOriginal.Refresh();
					bool_0 = true;
					base.Height += 20;
				}
				if (bitmap.Height == 150 && bitmap.Width == 308)
				{
					picOriginal.Width = 219;
					picOriginal.Height = 100;
					picOriginal.Image = bitmap;
					picOriginal.BackgroundImageLayout = ImageLayout.Stretch;
					picOriginal.SizeMode = PictureBoxSizeMode.StretchImage;
					picOriginal.Location = new Point(0, -15);
					picOriginal.Refresh();
				}
				else
				{
					bool_0 = true;
					picOriginal.Location = new Point(0, 21);
					picOriginal.Image = bitmap;
					picOriginal.Refresh();
					base.Size = picOriginal.Size;
				}
			}
			if (bool_0)
			{
			}
			if (!(text != ""))
			{
				return;
			}
			txtImageData.Text = text;
			if (!clsMain.bool_17 || (!((text.Length > 3) & (text.Length < 7)) && (bool_1 || !(text != ""))))
			{
				return;
			}
			if (!bool_1 & !bool_0)
			{
				string text2 = text;
				string value = " ";
				if (text2.Contains(value))
				{
					string text3 = text;
					string oldValue = " ";
					text = text3.Replace(oldValue, "");
				}
			}
			btnSubmit_Click(null, null);
		}
		catch (Exception)
		{
		}
	}

	internal string method_7(Bitmap bitmap_1)
	{
		return "";
	}

	internal string method_8(Bitmap bitmap_1)
	{
		string str = Img2Base64(bitmap_1);
		return GetGoogleReCaptcha(1, str);
	}

	public static string Img2Base64(Bitmap bmp2)
	{
		string result = "";
		try
		{
			MemoryStream memoryStream = new MemoryStream();
			bmp2.Save(memoryStream, ImageFormat.Png);
			result = Convert.ToBase64String(memoryStream.ToArray());
		}
		catch
		{
		}
		return result;
	}

	internal string GetGoogleReCaptcha(int Y, string str3)
	{
		WebProxy webProxy_ = null;
		CookieContainer cookieContainer_ = new CookieContainer();
		string text = "2fda665461c9add243d65780be6e1bfb";
		string text2 = text;
		string text3 = "";
		string text4 = "https://2captcha.com/in.php";
		string string_ = text4;
		string string_2 = "";
		string string_3 = "";
		string string_4;
		if (Y != 0 && Y == 1)
		{
			string text5 = "https://2captcha.com/in.php";
			string_4 = text5;
			string text6 = "key=";
			string text7 = "&method=base64&body=";
			string string_5 = text6 + text2 + text7 + HttpUtility.UrlEncode(str3);
			method_SBI(string_4, string_5, string_, "", 1, ref webProxy_, ref cookieContainer_, bool_1: true, 50000, ref string_2, ref string_3);
			string text8 = string_2;
			string text9 = "ERROR_ZERO_BALANCE";
			if (text8 == text9)
			{
				string text10 = "ERROR_ZERO_BALANCE";
				MessageBox.Show(text10);
				return "";
			}
			string text11 = string_2;
			string text12 = string_2;
			string value = "|";
			text3 = text11.Substring(text12.IndexOf(value) + 1);
		}
		string text13 = "https://2captcha.com/res.php?key=";
		string text14 = "&action=get&id=";
		string_4 = text13 + text2 + text14 + text3;
		string text15;
		string value2;
		do
		{
			Thread.Sleep(3000);
			method_SBI(string_4, "", string_, "", 1, ref webProxy_, ref cookieContainer_, bool_1: true, 50000, ref string_2, ref string_3);
			text15 = string_2;
			value2 = "OK";
		}
		while (!text15.Contains(value2));
		string text16 = string_2;
		string text17 = string_2;
		string value3 = "|";
		return text16.Substring(text17.IndexOf(value3) + 1);
	}

	public bool method_SBI(string string_14, string string_15, string string_16, string string_63i, int int_0, ref WebProxy webProxy_0, ref CookieContainer cookieContainer_1, bool bool_1, int int_1, ref string string_17, ref string string_18)
	{
		int num = 0;
		string text = "Tls";
		string text2 = text;
		bool result;
		while (true)
		{
			string_18 = "";
			string_17 = "";
			result = false;
			HttpWebResponse httpWebResponse = null;
			HttpWebRequest httpWebRequest = null;
			string text3 = "";
			try
			{
				num++;
				string text4 = text2;
				string text5 = "Tls";
				bool flag = text4 == text5;
				string text6 = text2;
				string text7 = "Ssl3";
				if (!(flag | (text6 == text7)))
				{
					string text8 = text2;
					string text9 = "Tls12";
					if (text8 == text9)
					{
						ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
					}
				}
				else
				{
					ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
				}
				httpWebRequest = (HttpWebRequest)WebRequest.Create(string_14);
				httpWebRequest.Proxy = webProxy_0;
				httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
				if (int_1 > 0)
				{
					httpWebRequest.Timeout = int_1;
					httpWebRequest.ReadWriteTimeout = int_1;
				}
				ServicePoint servicePoint = ServicePointManager.FindServicePoint(new Uri(string_14));
				servicePoint.ConnectionLimit = 65000;
				servicePoint.Expect100Continue = false;
				servicePoint.UseNagleAlgorithm = false;
				servicePoint.MaxIdleTime = 60000;
				servicePoint.ConnectionLeaseTimeout = 60000;
				ServicePointManager.Expect100Continue = true;
				byte[] bytes = Encoding.UTF8.GetBytes(string_15);
				if (bool_1)
				{
					if (cookieContainer_1 == null)
					{
						cookieContainer_1 = new CookieContainer();
					}
					httpWebRequest.CookieContainer = cookieContainer_1;
				}
				httpWebRequest.Referer = string_16;
				HttpWebRequest httpWebRequest2 = httpWebRequest;
				string method = "POST";
				httpWebRequest2.Method = method;
				httpWebRequest.ContentLength = bytes.Length;
				HttpWebRequest httpWebRequest3 = httpWebRequest;
				string contentType = "application/x-www-form-urlencoded";
				httpWebRequest3.ContentType = contentType;
				string value = "json";
				if (string_16.Contains(value))
				{
					HttpWebRequest httpWebRequest4 = httpWebRequest;
					string contentType2 = "application/json";
					httpWebRequest4.ContentType = contentType2;
				}
				httpWebRequest.KeepAlive = true;
				HttpWebRequest httpWebRequest5 = httpWebRequest;
				string text10 = "Apache-HttpClient/android/";
				httpWebRequest5.UserAgent = text10 + string_16;
				if (!string.IsNullOrEmpty(string_63i))
				{
					string delimiter = "||";
					string[] array = Strings.Split(string_63i, delimiter);
					int num2 = Information.UBound(array);
					for (int i = 0; i <= num2; i++)
					{
						string expression = array[i];
						string delimiter2 = "#";
						string[] array2 = Strings.Split(expression, delimiter2);
						httpWebRequest.Headers.Set(array2[0], array2[1]);
					}
				}
				if (string_15.Length > 0)
				{
					using Stream stream = httpWebRequest.GetRequestStream();
					stream.Write(bytes, 0, bytes.Length);
				}
				else
				{
					HttpWebRequest httpWebRequest6 = httpWebRequest;
					string method2 = "GET";
					httpWebRequest6.Method = method2;
				}
				httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				using (StreamReader textReader_ = smethod_105(httpWebResponse.GetResponseStream()))
				{
					text3 = smethod_106(textReader_);
				}
				string_17 = text3;
				result = true;
			}
			catch (WebException ex)
			{
				result = false;
				string_18 = ex.Message;
				string text11 = string_18.ToUpper();
				string value2 = "CONNECTION WAS CLOSED";
				if (!text11.Contains(value2))
				{
					string text12 = string_18.ToUpper();
					string value3 = "SERVICEUNAVAILABLE";
					text12.Contains(value3);
				}
				string text13 = string_18;
				string value4 = "The underlying connection was closed";
				if (text13.Contains(value4))
				{
					string text14 = "Tls12";
					text2 = text14;
				}
				if (num < 2)
				{
					continue;
				}
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
			break;
		}
		return result;
	}

	public StreamReader smethod_105(Stream stream_0)
	{
		return new StreamReader(stream_0);
	}

	public string smethod_106(TextReader textReader_0)
	{
		return textReader_0.ReadToEnd();
	}

	private void method_9(short short_0)
	{
	}

	internal string method_10(string string_8)
	{
		try
		{
			smethod_0(0);
			string variable = "OCR";
			int.TryParse(Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.Process), out clsMain.int_1);
			_ = DateTime.Now;
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			string path = "Microsoft";
			string path2 = Path.Combine(folderPath, path);
			string path3 = "nlpcap3";
			string path4 = Path.Combine(path2, path3);
			string text = "Nget|";
			string arguments = text + string_8;
			Process process = new Process();
			ProcessStartInfo startInfo = process.StartInfo;
			string path5 = "nlp_OCR.exe";
			startInfo.FileName = Path.Combine(path4, path5);
			process.StartInfo.Arguments = arguments;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardOutput = true;
			process.Start();
			StreamReader standardOutput = process.StandardOutput;
			process.WaitForExit(3500);
			string text2 = standardOutput.ReadLine();
			string text3 = text2;
			string oldValue = " ";
			string text4 = text3.Replace(oldValue, "");
			string oldValue2 = ":";
			string text5 = text4.Replace(oldValue2, "");
			string oldValue3 = ".";
			string text6 = text5.Replace(oldValue3, "");
			string oldValue4 = ";";
			string text7 = text6.Replace(oldValue4, "");
			string oldValue5 = ",";
			string text8 = text7.Replace(oldValue5, "");
			string oldValue6 = "\"";
			string text9 = text8.Replace(oldValue6, "");
			string oldValue7 = "/";
			string text10 = text9.Replace(oldValue7, "");
			string oldValue8 = "|";
			string newValue = "I";
			string text11 = text10.Replace(oldValue8, newValue);
			string oldValue9 = "&";
			string newValue2 = "8";
			text2 = text11.Replace(oldValue9, newValue2);
			if (!process.HasExited)
			{
				process.Kill();
			}
			if (clsMain.int_1 == 0)
			{
				if (text2.Length > 6)
				{
					string text12 = text2;
					string oldValue10 = "S9";
					string newValue3 = "9";
					string text13 = text12.Replace(oldValue10, newValue3);
					string oldValue11 = "9S";
					string newValue4 = "9";
					text2 = text13.Replace(oldValue11, newValue4);
					string text14 = text2;
					string oldValue12 = "S5";
					string newValue5 = "5";
					string text15 = text14.Replace(oldValue12, newValue5);
					string oldValue13 = "5S";
					string newValue6 = "5";
					text2 = text15.Replace(oldValue13, newValue6);
					string text16 = text2;
					string oldValue14 = "0O";
					string newValue7 = "0";
					string text17 = text16.Replace(oldValue14, newValue7);
					string oldValue15 = "O0";
					string newValue8 = "0";
					text2 = text17.Replace(oldValue15, newValue8);
					string text18 = text2;
					string oldValue16 = "86";
					string newValue9 = "5";
					text2 = text18.Replace(oldValue16, newValue9);
					string text19 = text2;
					string oldValue17 = "RAR";
					string newValue10 = "AA";
					text2 = text19.Replace(oldValue17, newValue10);
					string text20 = text2;
					string oldValue18 = "SA";
					string newValue11 = "8";
					text2 = text20.Replace(oldValue18, newValue11);
					string text21 = text2;
					string oldValue19 = "71";
					string newValue12 = "1";
					text2 = text21.Replace(oldValue19, newValue12);
					string text22 = text2;
					string oldValue20 = "S8";
					string newValue13 = "8";
					text2 = text22.Replace(oldValue20, newValue13);
					string text23 = text2;
					string oldValue21 = "S3";
					string newValue14 = "3";
					text2 = text23.Replace(oldValue21, newValue14);
					string text24 = text2;
					string oldValue22 = "B8";
					string newValue15 = "5";
					text2 = text24.Replace(oldValue22, newValue15);
					string text25 = text2;
					string oldValue23 = "6E";
					string newValue16 = "6";
					text2 = text25.Replace(oldValue23, newValue16);
					string text26 = text2;
					string oldValue24 = "1i";
					string newValue17 = "1";
					text2 = text26.Replace(oldValue24, newValue17);
					string text27 = text2;
					string oldValue25 = "jJ";
					string newValue18 = "J";
					text2 = text27.Replace(oldValue25, newValue18);
				}
				string text28 = text2;
				string oldValue26 = "2Z2";
				string newValue19 = "Z";
				text2 = text28.Replace(oldValue26, newValue19);
				string text29 = text2;
				string oldValue27 = "1I";
				string newValue20 = "1";
				text2 = text29.Replace(oldValue27, newValue20);
				string text30 = text2;
				string oldValue28 = "@";
				text2 = text30.Replace(oldValue28, "");
				string text31 = text2;
				string oldValue29 = "(";
				string newValue21 = "L";
				text2 = text31.Replace(oldValue29, newValue21);
				string text32 = text2;
				string oldValue30 = "S9";
				string newValue22 = "9";
				return text32.Replace(oldValue30, newValue22);
			}
			return text2;
		}
		catch (Exception)
		{
			return "";
		}
	}

	internal static void smethod_0(object object_1)
	{
		string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
		string path = folderPath;
		string path2 = "Microsoft";
		folderPath = Path.Combine(path, path2);
		string path3 = folderPath;
		string path4 = "nlpcap3";
		folderPath = Path.Combine(path3, path4);
		if (!Directory.Exists(folderPath))
		{
			Directory.CreateDirectory(folderPath);
		}
		string path5 = folderPath;
		string path6 = "tessdata";
		string path7 = Path.Combine(path5, path6);
		bool flag = true;
		string path8 = folderPath;
		string path9 = "Dynamsoft.ImageCore.dll";
		if (File.Exists(Path.Combine(path8, path9)))
		{
			string path10 = folderPath;
			string path11 = "Dynamsoft.OCR.dll";
			if (!File.Exists(Path.Combine(path10, path11)))
			{
				flag = false;
			}
			else
			{
				string path12 = folderPath;
				string path13 = "nlp_OCR.exe";
				if (!File.Exists(Path.Combine(path12, path13)))
				{
					flag = false;
				}
				else
				{
					string path14 = "eng.traineddata";
					if (!File.Exists(Path.Combine(path7, path14)))
					{
						flag = false;
					}
				}
			}
		}
		else
		{
			flag = false;
		}
		string path15 = folderPath;
		string path16 = "NLP.dll";
		string text = Path.Combine(path15, path16);
		string path17 = folderPath;
		string path18 = "NLP.zip";
		string text2 = Path.Combine(path17, path18);
		if (!flag && !File.Exists(text))
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			string name = "^.Booking.include.NLP.dll";
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
		catch (Exception)
		{
		}
	}

	internal static void smethod_1(object object_1)
	{
		string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
		string path = folderPath;
		string path2 = "Microsoft";
		folderPath = Path.Combine(path, path2);
		string path3 = folderPath;
		string path4 = "nlpcap2";
		folderPath = Path.Combine(path3, path4);
		if (!Directory.Exists(folderPath))
		{
			Directory.CreateDirectory(folderPath);
		}
		string path5 = folderPath;
		string path6 = "x86";
		string path7 = Path.Combine(path5, path6);
		string path8 = folderPath;
		string path9 = "x64";
		string path10 = Path.Combine(path8, path9);
		string path11 = folderPath;
		string path12 = "tessdata";
		string path13 = Path.Combine(path11, path12);
		bool flag = true;
		string path14 = "leptonica-1.78.0.dll";
		if (!File.Exists(Path.Combine(path10, path14)))
		{
			flag = false;
		}
		else
		{
			string path15 = "tesseract41.dll";
			if (!File.Exists(Path.Combine(path10, path15)))
			{
				flag = false;
			}
			else
			{
				string path16 = "leptonica-1.78.0.dll";
				if (File.Exists(Path.Combine(path7, path16)))
				{
					string path17 = "tesseract41.dll";
					if (!File.Exists(Path.Combine(path7, path17)))
					{
						flag = false;
					}
					else
					{
						string path18 = "eng.traineddata";
						if (!File.Exists(Path.Combine(path13, path18)))
						{
							flag = false;
						}
						else
						{
							string path19 = "libcap.dll";
							if (!File.Exists(path19))
							{
								flag = false;
							}
							else
							{
								string path20 = "Tesseract.dll";
								if (!File.Exists(path20))
								{
									flag = false;
								}
							}
						}
					}
				}
				else
				{
					flag = false;
				}
			}
		}
		string path21 = folderPath;
		string path22 = "TMD.dll";
		string text = Path.Combine(path21, path22);
		if (!flag && !File.Exists(text))
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			string name = "^.Booking.include.TMD.dll";
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
		string path23 = folderPath;
		string path24 = "TMD.zip";
		if (!File.Exists(Path.Combine(path23, path24)))
		{
			string destFileName = "TMD.zip";
			File.Copy(text, destFileName, overwrite: true);
		}
		File.Delete(text);
		try
		{
			string fileName = "TMD.zip";
			ZipFile zipFile = ZipFile.Read(fileName);
			try
			{
				zipFile.ExtractAll(folderPath);
			}
			finally
			{
				zipFile?.Dispose();
			}
			string path25 = "TMD.zip";
			File.Delete(path25);
		}
		catch (Exception)
		{
		}
	}

	internal Image method_11(string string_8)
	{
		byte[] array = Convert.FromBase64String(string_8);
		using MemoryStream stream = new MemoryStream(array, 0, array.Length);
		return Image.FromStream(stream, useEmbeddedColorManagement: true);
	}

	private void btnSubmit_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	private void txtImageData_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			btnSubmit_Click(null, null);
		}
	}

	private void btnREF_Click(object sender, EventArgs e)
	{
		try
		{
			btnREF.Visible = false;
			txtImageData.Text = "";
			method_12(0);
		}
		catch
		{
		}
	}

	private void method_12(object object_1)
	{
		btnREF.Visible = true;
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCAP));
		this.bunifuElipse_0 = new Bunifu.Framework.UI.BunifuElipse(this.components);
		this.btnSubmit = new System.Windows.Forms.Button();
		this.txtImageData = new System.Windows.Forms.TextBox();
		this.btnReferesh = new System.Windows.Forms.Button();
		this.panel1 = new System.Windows.Forms.Panel();
		this.btnREF = new System.Windows.Forms.Button();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.pnlHeader = new System.Windows.Forms.Panel();
		this.tktname = new System.Windows.Forms.Label();
		this.btnCancel = new Bunifu.Framework.UI.BunifuImageButton();
		this.picOriginal = new System.Windows.Forms.PictureBox();
		this.panel1.SuspendLayout();
		this.pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.btnCancel).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.picOriginal).BeginInit();
		base.SuspendLayout();
		this.bunifuElipse_0.ElipseRadius = 5;
		this.bunifuElipse_0.TargetControl = this;
		this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(46, 49, 146);
		this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Bold);
		this.btnSubmit.ForeColor = System.Drawing.Color.White;
		this.btnSubmit.Location = new System.Drawing.Point(102, 5);
		this.btnSubmit.Name = "btnSubmit";
		this.btnSubmit.Size = new System.Drawing.Size(76, 21);
		this.btnSubmit.TabIndex = 1196;
		this.btnSubmit.Text = "Submit";
		this.btnSubmit.UseVisualStyleBackColor = false;
		this.btnSubmit.Click += new System.EventHandler(btnSubmit_Click);
		this.txtImageData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtImageData.Font = new System.Drawing.Font("Arial", 10.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtImageData.Location = new System.Drawing.Point(6, 5);
		this.txtImageData.Margin = new System.Windows.Forms.Padding(2);
		this.txtImageData.MaxLength = 20;
		this.txtImageData.Name = "txtImageData";
		this.txtImageData.Size = new System.Drawing.Size(91, 24);
		this.txtImageData.TabIndex = 1197;
		this.txtImageData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.txtImageData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtImageData_KeyPress);
		this.btnReferesh.BackColor = System.Drawing.Color.FromArgb(46, 49, 146);
		this.btnReferesh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnReferesh.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Bold);
		this.btnReferesh.ForeColor = System.Drawing.Color.White;
		this.btnReferesh.Location = new System.Drawing.Point(298, 26);
		this.btnReferesh.Name = "btnReferesh";
		this.btnReferesh.Size = new System.Drawing.Size(74, 21);
		this.btnReferesh.TabIndex = 1196;
		this.btnReferesh.Text = "Submit Payment";
		this.btnReferesh.UseVisualStyleBackColor = false;
		this.btnReferesh.Visible = false;
		this.btnReferesh.Click += new System.EventHandler(btnReferesh_Click);
		this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.panel1.Controls.Add(this.btnREF);
		this.panel1.Controls.Add(this.btnSubmit);
		this.panel1.Controls.Add(this.txtImageData);
		this.panel1.Location = new System.Drawing.Point(0, 45);
		this.panel1.Margin = new System.Windows.Forms.Padding(2);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(219, 29);
		this.panel1.TabIndex = 1198;
		this.btnREF.BackColor = System.Drawing.Color.Yellow;
		this.btnREF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.btnREF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnREF.Location = new System.Drawing.Point(181, 5);
		this.btnREF.Margin = new System.Windows.Forms.Padding(2);
		this.btnREF.Name = "btnREF";
		this.btnREF.Size = new System.Drawing.Size(26, 21);
		this.btnREF.TabIndex = 1198;
		this.btnREF.UseVisualStyleBackColor = false;
		this.btnREF.Click += new System.EventHandler(btnREF_Click);
		this.timer1.Interval = 500;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		this.pnlHeader.BackColor = System.Drawing.Color.MediumSlateBlue;
		this.pnlHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.pnlHeader.Controls.Add(this.tktname);
		this.pnlHeader.Controls.Add(this.btnCancel);
		this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
		this.pnlHeader.Location = new System.Drawing.Point(0, 0);
		this.pnlHeader.Name = "pnlHeader";
		this.pnlHeader.Size = new System.Drawing.Size(220, 15);
		this.pnlHeader.TabIndex = 1190;
		this.tktname.AutoSize = true;
		this.tktname.BackColor = System.Drawing.Color.Transparent;
		this.tktname.ForeColor = System.Drawing.Color.White;
		this.tktname.Location = new System.Drawing.Point(-1, 0);
		this.tktname.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.tktname.Name = "tktname";
		this.tktname.Size = new System.Drawing.Size(45, 13);
		this.tktname.TabIndex = 1189;
		this.tktname.Text = "tktname";
		this.btnCancel.BackColor = System.Drawing.Color.Transparent;
		this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		this.btnCancel.Image = (System.Drawing.Image)resources.GetObject("btnCancel.Image");
		this.btnCancel.ImageActive = null;
		this.btnCancel.Location = new System.Drawing.Point(204, -1);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(15, 15);
		this.btnCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.btnCancel.TabIndex = 1188;
		this.btnCancel.TabStop = false;
		this.btnCancel.Zoom = 10;
		this.btnCancel.Click += new System.EventHandler(btnCancel_Click);
		this.picOriginal.Location = new System.Drawing.Point(-45, 20);
		this.picOriginal.Margin = new System.Windows.Forms.Padding(2);
		this.picOriginal.Name = "picOriginal";
		this.picOriginal.Size = new System.Drawing.Size(246, 16);
		this.picOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.picOriginal.TabIndex = 1191;
		this.picOriginal.TabStop = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(220, 74);
		base.Controls.Add(this.pnlHeader);
		base.Controls.Add(this.panel1);
		base.Controls.Add(this.btnReferesh);
		base.Controls.Add(this.picOriginal);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(2);
		base.Name = "frmCAP";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		this.Text = "frmCAP";
		base.TopMost = true;
		this.panel1.ResumeLayout(false);
		this.panel1.PerformLayout();
		this.pnlHeader.ResumeLayout(false);
		this.pnlHeader.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.btnCancel).EndInit();
		((System.ComponentModel.ISupportInitialize)this.picOriginal).EndInit();
		base.ResumeLayout(false);
	}
}
