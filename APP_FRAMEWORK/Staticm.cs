using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using Ionic.Zip;
using IRCommDLL;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NEXUS;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

namespace APP_FRAMEWORK;

internal class Staticm
{
	public static string blockurl;

	public static string Data;

	private static bool bool_0;

	public static string edata;

	public static string sdata;

	public static string irctcConnectURL;

	[DllImport("kernel32.dll")]
	internal static extern void un(uint uint_0);

	public Staticm()
	{
		ServicePointManager.ServerCertificateValidationCallback = CertificateValidation;
	}

	public static string Method_SerialInp(string A_0, ref string A_1, bool A_2)
	{
		string text = A_0;
		string text2 = A_1;
		string string_ = A_1;
		A_1 = text2;
		if (string.IsNullOrEmpty(text) && string.IsNullOrEmpty(A_1))
		{
			text = smethod_0(A_0, ref string_, A_2);
			A_1 = string_;
		}
		return text;
	}

	private static string smethod_0(string string_0, ref string string_1, bool bool_1)
	{
		string text = "";
		string oldValue = "'";
		string newValue = "\"";
		string text2 = string_0.Replace(oldValue, newValue);
		string value = "action=";
		int num = text2.IndexOf(value, StringComparison.CurrentCultureIgnoreCase);
		if (num <= 0)
		{
			string value2 = "action =";
			num = text2.IndexOf(value2, StringComparison.CurrentCultureIgnoreCase);
		}
		string value3 = "\"";
		int num2 = text2.IndexOf(value3, num) + 1;
		string value4 = "\"";
		int num3 = text2.IndexOf(value4, num2);
		string_1 = text2.Substring(num2, num3 - num2);
		string value5 = "/form";
		int num4 = text2.IndexOf(value5, StringComparison.CurrentCultureIgnoreCase);
		string text3 = "";
		string value6 = "<hidden";
		int num5 = text2.IndexOf(value6, num2, StringComparison.CurrentCultureIgnoreCase);
		string value7 = "<input";
		int num6 = text2.IndexOf(value7, num2, StringComparison.CurrentCultureIgnoreCase);
		string value8 = "<select";
		int num7 = text2.IndexOf(value8, num2, StringComparison.CurrentCultureIgnoreCase);
		bool flag = (num5 < num6 && num5 != -1) || (num5 < num7 && num5 != -1);
		bool flag2 = (num6 < num7 && num6 != -1) || (num6 < num5 && num6 != -1);
		bool flag3 = (num7 < num5 && num7 != -1) || (num7 < num6 && num7 != -1);
		if (flag)
		{
			num2 = num5;
			string text4 = "hidden";
			text3 = text4;
		}
		else if (!flag2)
		{
			if (flag3)
			{
				num2 = num7;
				string text5 = "select";
				text3 = text5;
			}
		}
		else
		{
			num2 = num6;
			string text6 = "input";
			text3 = text6;
		}
		while (num2 > 0 && num2 < num4)
		{
			string text7 = "";
			string value9 = "name=";
			int startIndex = text2.IndexOf(value9, num2, StringComparison.CurrentCultureIgnoreCase);
			string value10 = "\"";
			int num8 = text2.IndexOf(value10, startIndex) + 1;
			string value11 = "\"";
			int num9 = text2.IndexOf(value11, num8);
			string text8 = text2.Substring(num8, num9 - num8);
			string text9 = "=";
			string text10 = text8 + text9;
			string value12 = " value=";
			int num10 = text2.IndexOf(value12, num9, StringComparison.CurrentCultureIgnoreCase);
			string value13 = "<hidden";
			int num11 = text2.IndexOf(value13, num9, StringComparison.CurrentCultureIgnoreCase);
			string value14 = "<input";
			int num12 = text2.IndexOf(value14, num9, StringComparison.CurrentCultureIgnoreCase);
			string value15 = "<select";
			int num13 = text2.IndexOf(value15, num9, StringComparison.CurrentCultureIgnoreCase);
			bool flag4 = true;
			if (num11 > -1)
			{
				flag4 = num10 < num11;
			}
			if (num12 > -1 && flag4)
			{
				flag4 = num10 < num12;
			}
			if (num13 > -1 && flag4)
			{
				flag4 = num10 < num13;
			}
			if (flag4)
			{
				string value16 = "value=";
				int startIndex2 = text2.IndexOf(value16, num8, StringComparison.CurrentCultureIgnoreCase);
				string value17 = "\"";
				num8 = text2.IndexOf(value17, startIndex2) + 1;
				string value18 = "\"";
				int num14 = text2.IndexOf(value18, num8);
				string text11 = text2.Substring(num8, num14 - num8);
				string oldValue2 = "&amp;";
				string newValue2 = "&";
				text7 = HttpUtility.UrlEncode(text11.Replace(oldValue2, newValue2));
			}
			string text12 = text10 + text7;
			string text13;
			if (string.IsNullOrEmpty(text))
			{
				text13 = text12;
			}
			else
			{
				string text14 = text;
				string text15 = "&";
				text13 = text14 + text15 + text12;
			}
			text = text13;
			string value19 = "<hidden";
			int num15 = text2.IndexOf(value19, num8, StringComparison.CurrentCultureIgnoreCase);
			string value20 = "<input";
			int num16 = text2.IndexOf(value20, num8, StringComparison.CurrentCultureIgnoreCase);
			string value21 = "<select";
			int num17 = text2.IndexOf(value21, num8, StringComparison.CurrentCultureIgnoreCase);
			bool flag5 = (num15 < num16 && num15 != -1) || (num15 < num17 && num15 != -1);
			bool flag6 = (num16 < num17 && num16 != -1) || (num16 < num15 && num16 != -1);
			bool flag7 = (num17 < num15 && num17 != -1) || (num17 < num16 && num17 != -1);
			if (!flag5)
			{
				if (!flag6)
				{
					if (flag7)
					{
						num8 = num17;
						string text16 = "select";
						text3 = text16;
					}
				}
				else
				{
					num8 = num16;
					string text17 = "input";
					text3 = text17;
				}
			}
			else
			{
				num8 = num15;
				string text18 = "hidden";
				text3 = text18;
			}
			string text19 = "<";
			num2 = text2.IndexOf(text19 + text3, num8, StringComparison.CurrentCultureIgnoreCase);
		}
		return text;
	}

	public static string GoogleOCR(Bitmap img, string site)
	{
		bool flag = false;
		StatClass.int_31++;
		int num = DateTime.Now.Hour * 10000;
		int num2 = DateTime.Now.Minute * 100;
		int num3 = num + num2;
		int second = DateTime.Now.Second;
		long num4 = num3 + second;
		if (75800 <= num4 && num4 <= 81500)
		{
			flag = false;
		}
		if ((95600 <= num4 && num4 <= 101500) || (105600 <= num4 && num4 <= 111500))
		{
			flag = true;
		}
		int num5 = 0;
		string text = "";
		string text2 = "";
		while (true)
		{
			num5++;
			try
			{
				MemoryStream memoryStream = new MemoryStream();
				img.Save(memoryStream, ImageFormat.Png);
				text2 = Convert.ToBase64String(memoryStream.ToArray());
			}
			catch
			{
				Thread.Sleep(500);
				if (num5 >= 2)
				{
					break;
				}
				continue;
			}
			break;
		}
		if (!(text2 == ""))
		{
			int num6 = 0;
			string text3 = site;
			string text4 = "WEB";
			if (text3 == text4)
			{
				string text5 = "APP";
				site = text5;
			}
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			string path = "Microsoft";
			string path2 = Path.Combine(folderPath, path);
			if (flag)
			{
				string text6 = site;
				string text7 = "fssnet";
				if (!(text6 == text7))
				{
					string text8 = site;
					string text9 = "NGET";
					bool flag2 = text8 == text9;
					string text10 = site;
					string text11 = "APP";
					if (flag2 | (text10 == text11))
					{
						string startupPath = Application.StartupPath;
						string path3 = "Redia.dll";
						if (File.Exists(Path.Combine(startupPath, path3)))
						{
							string path4 = "Recog";
							string text12 = Path.Combine(path2, path4);
							if (!Directory.Exists(text12))
							{
								Directory.CreateDirectory(text12);
							}
							string path5 = "Recog.zip";
							string text13 = Path.Combine(text12, path5);
							if (!File.Exists(text13))
							{
								string sourceFileName = "Redia.dll";
								File.Copy(sourceFileName, text13, overwrite: true);
							}
							while (true)
							{
								num6++;
								string text14 = Path.Combine(text12, num6.ToString());
								if (!Directory.Exists(text14))
								{
									Directory.CreateDirectory(text14);
									try
									{
										using ZipFile zipFile = ZipFile.Read(text13);
										string password = "WRox#$57910";
										zipFile.Password = password;
										zipFile.ExtractAll(text14);
									}
									catch
									{
									}
								}
								try
								{
									string text15 = text2;
									string text16 = "|NGET|";
									string arguments = text15 + text16;
									Process process = new Process();
									ProcessStartInfo startInfo = process.StartInfo;
									string path6 = "CaptchaRecog_CShape.exe";
									startInfo.FileName = Path.Combine(text14, path6);
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
									if (string.IsNullOrEmpty(text) && num6 < 4)
									{
										continue;
									}
								}
								catch (Exception)
								{
									if (num6 < 4)
									{
										continue;
									}
								}
								break;
							}
						}
					}
					goto IL_05c2;
				}
			}
			string startupPath2 = Application.StartupPath;
			string path7 = "Iconic.dll";
			if (File.Exists(Path.Combine(startupPath2, path7)))
			{
				string path8 = "Mecog";
				string text17 = Path.Combine(path2, path8);
				if (!Directory.Exists(text17))
				{
					Directory.CreateDirectory(text17);
				}
				string path9 = "Mecog.zip";
				string text18 = Path.Combine(text17, path9);
				if (!File.Exists(text18))
				{
					string sourceFileName2 = "Iconic.dll";
					File.Copy(sourceFileName2, text18, overwrite: true);
				}
				while (true)
				{
					string text19 = Path.Combine(text17, num6.ToString());
					if (!Directory.Exists(text19))
					{
						Directory.CreateDirectory(text19);
						num6++;
						try
						{
							using ZipFile zipFile2 = ZipFile.Read(text18);
							zipFile2.ExtractAll(text19);
						}
						catch
						{
						}
					}
					try
					{
						string text20 = text2;
						string text21 = "|";
						string text22 = site;
						string text23 = "|";
						string arguments2 = text20 + text21 + text22 + text23;
						Process process2 = new Process();
						ProcessStartInfo startInfo2 = process2.StartInfo;
						string path10 = "OCR.exe";
						startInfo2.FileName = Path.Combine(text19, path10);
						process2.StartInfo.Arguments = arguments2;
						process2.StartInfo.CreateNoWindow = true;
						process2.StartInfo.UseShellExecute = false;
						process2.StartInfo.RedirectStandardOutput = true;
						process2.Start();
						StreamReader standardOutput2 = process2.StandardOutput;
						process2.WaitForExit(3500);
						text = standardOutput2.ReadLine();
						if (!process2.HasExited)
						{
							process2.Kill();
						}
						if (string.IsNullOrEmpty(text) && num6 < 4)
						{
							continue;
						}
					}
					catch (Exception)
					{
						if (num6 < 4)
						{
							continue;
						}
					}
					break;
				}
			}
			goto IL_05c2;
		}
		return "ER";
		IL_05c2:
		StatClass.int_31--;
		return text.ToUpper();
	}

	public static void GoogleOCRExtract(object sender)
	{
		string[] array = new string[1];
		string text = "Recog_CShape.dll";
		array[0] = text;
		string text2 = Path.Combine(array);
		if (File.Exists(text2))
		{
			return;
		}
		Assembly executingAssembly = Assembly.GetExecutingAssembly();
		string name = "^.Booking.include.Recog_CShape.dll";
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

	public static void GoogleOCR_Extract(object sender)
	{
		string[] array = new string[1];
		string text = "Recog_CShape.dll";
		array[0] = text;
		string text2 = Path.Combine(array);
		if (File.Exists(text2))
		{
			return;
		}
		Assembly executingAssembly = Assembly.GetExecutingAssembly();
		string name = "^.Booking.include.Recog_CShape.dll";
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

	public static void TBL_USERUpdate(string Tble, string Fild, string val, string usr)
	{
		SQLiteConnection sQLiteConnection = new SQLiteConnection(Class34.string_Database);
		SQLiteCommand sQLiteCommand = new SQLiteCommand();
		sQLiteConnection.Open();
		sQLiteCommand.Connection = sQLiteConnection;
		string[] array = new string[7];
		string text = "UPDATE [TBL_USER] SET [";
		array[0] = text;
		array[1] = Fild;
		string text2 = "] = '";
		array[2] = text2;
		array[3] = val;
		string text3 = "' WHERE [UserName] = '";
		array[4] = text3;
		array[5] = usr;
		string text4 = "'";
		array[6] = text4;
		sQLiteCommand.CommandText = string.Concat(array);
		sQLiteCommand.ExecuteNonQuery();
		sQLiteCommand.Dispose();
		sQLiteConnection.Close();
		sQLiteConnection.Dispose();
	}

	public static void PrintERS(string SRC_STN, string DEST_STN, string pnr, DateTime dateTime_5, string path)
	{
		try
		{
			string what = "pnrNumber";
			string text = jsonData_Serial(pnr, what);
			string what2 = "trainNo";
			string text2 = jsonData_Serial(pnr, what2);
			string text3 = " / ";
			string what3 = "trainName";
			string newValue = text2 + text3 + jsonData_Serial(pnr, what3);
			string what4 = "quota";
			string newValue2 = jsonData_Serial(pnr, what4);
			string what5 = "ticketID";
			string newValue3 = jsonData_Serial(pnr, what5);
			string what6 = "dateOfBooking";
			string newValue4 = jsonData_Serial(pnr, what6);
			string what7 = "classCode";
			string newValue5 = jsonData_Serial(pnr, what7);
			string what8 = "fromStationName";
			string text4 = jsonData_Serial(pnr, what8);
			string text5 = "(";
			string what9 = "fromStation";
			string text6 = jsonData_Serial(pnr, what9);
			string text7 = ")";
			string newValue6 = text4 + text5 + text6 + text7;
			string what10 = "toStationName";
			string text8 = jsonData_Serial(pnr, what10);
			string text9 = "(";
			string what11 = "toStation";
			string text10 = jsonData_Serial(pnr, what11);
			string text11 = ")";
			string newValue7 = text8 + text9 + text10 + text11;
			string what12 = "boardingAtName";
			string text12 = jsonData_Serial(pnr, what12);
			string text13 = "(";
			string what13 = "boardingAt";
			string text14 = jsonData_Serial(pnr, what13);
			string text15 = ")";
			string newValue8 = text12 + text13 + text14 + text15;
			string what14 = "dateOfJourney";
			string newValue9 = jsonData_Serial(pnr, what14);
			string what15 = "dateOfBoarding";
			string newValue10 = jsonData_Serial(pnr, what15);
			string what16 = "mobileNumber";
			string newValue11 = jsonData_Serial(pnr, what16);
			string what17 = "distance";
			string newValue12 = jsonData_Serial(pnr, what17);
			string what18 = "scheduledDepartureTime";
			string text16 = jsonData_Serial(pnr, what18);
			string what19 = "scheduledArrivalTime";
			string text17 = jsonData_Serial(pnr, what19);
			string what20 = "passengerAddress";
			string newValue13 = jsonData_Serial(pnr, what20);
			string oldValue = "2829688329";
			string text18 = "".Replace(oldValue, text);
			string oldValue2 = "19224 / JAT ADI EXPRESS";
			string text19 = text18.Replace(oldValue2, newValue);
			string oldValue3 = "GENERAL (GN)";
			string text20 = text19.Replace(oldValue3, newValue2);
			string oldValue4 = "100001358714508";
			string text21 = text20.Replace(oldValue4, newValue3);
			string oldValue5 = "17-Jul-2018 08:10:58 HRS";
			string text22 = text21.Replace(oldValue5, newValue4);
			string oldValue6 = "SLEEPER CLASS (SL)";
			string text23 = text22.Replace(oldValue6, newValue5);
			string oldValue7 = "MAKHU(MXH)";
			string text24 = text23.Replace(oldValue7, newValue6);
			string oldValue8 = "13-Nov-2018";
			string text25 = text24.Replace(oldValue8, newValue9);
			string oldValue9 = "14-Nov-2018";
			string text26 = text25.Replace(oldValue9, newValue10);
			string oldValue10 = "AHMEDABAD JN(ADI)";
			string text27 = text26.Replace(oldValue10, newValue7);
			string oldValue11 = "JAKHU(YXH)";
			string text28 = text27.Replace(oldValue11, newValue8);
			string oldValue12 = "9999999995";
			string text29 = text28.Replace(oldValue12, newValue11);
			string oldValue13 = "1186";
			string text30 = text29.Replace(oldValue13, newValue12);
			string oldValue14 = "Scheduled Departure: N.A.";
			string text31 = "Scheduled Departure: ";
			string text32 = text30.Replace(oldValue14, text31 + text16);
			string oldValue15 = "Scheduled Arrival: N.A.";
			string text33 = "Scheduled Arrival: ";
			string text34 = text32.Replace(oldValue15, text33 + text17);
			string oldValue16 = "65 Bapu Nagar~Pune, Pune, MAHARASHTRA - 411015";
			string text35 = text34.Replace(oldValue16, newValue13);
			string value = "fareInfoData";
			string text36 = pnr.Substring(pnr.IndexOf(value));
			string value2 = "]";
			string text37 = text36.Substring(0, text36.IndexOf(value2));
			string what21 = "message";
			string newValue14 = jsonData_Serial(text37, what21);
			string value3 = ",{";
			string text38 = text37.Substring(text37.IndexOf(value3) + 1);
			string newValue15 = "";
			string text39 = "<tr _ngcontent-c1=\"\"><td _ngcontent-c1=\"\" style=\"border-color:black;font-size: .9rem;color:black;\" width=\"30%\"><b _ngcontent-c1=\"\">&nbsp;Ticket Fare **</b></td><td _ngcontent-c1=\"\" style=\"border-color:black;width:60px;font-size: .9rem;color:black;\" width=\"10%\"><b _ngcontent-c1=\"\">₹</b> 1530.0</td><!----><td _ngcontent-c1=\"\" style=\"border-color:black;border-right-color:white;font-size: .9rem;color:black;\" width=\"60%\"> Rupees one thousand five hundred thirty  and Zero paisa</td><!----></tr>";
			string oldValue17 = "1530.0";
			string text40 = text39.Replace(oldValue17, newValue14);
			string oldValue18 = "Rupees one thousand five hundred thirty  and Zero paisa";
			string text41 = text40.Replace(oldValue18, newValue15);
			string text42 = "<tr _ngcontent-c1=\"\"><td _ngcontent-c1=\"\" style=\"border-color:black;font-size: .9rem;color:black;\" width=\"30%\"><b _ngcontent-c1=\"\">&nbsp;IRCTC Service Charge (Incl. of GST) #</b></td><td _ngcontent-c1=\"\" style=\"border-color:black;width:60px;font-size: .9rem;color:black;\" width=\"10%\"><b _ngcontent-c1=\"\">₹</b> 0.0</td><!----><td _ngcontent-c1=\"\" style=\"border-color:black;border-right-color:white;font-size: .9rem;color:black;\" width=\"60%\"> Rupees Zero and Zero paisa</td><!----></tr>";
			string text43 = text42;
			string value4 = ",{";
			string text44 = text38.Substring(text38.IndexOf(value4) + 1);
			string text45 = "<tr _ngcontent-c1=\"\"><td _ngcontent-c1=\"\" style=\"border-color:black;font-size: .9rem;color:black;\" width=\"30%\"><b _ngcontent-c1=\"\">&nbsp;Travel Insurance Premium (Incl. of GST)</b></td><td _ngcontent-c1=\"\" style=\"border-color:black;width:60px;font-size: .9rem;color:black;\" width=\"10%\"><b _ngcontent-c1=\"\">₹</b> 1.36</td><!----><td _ngcontent-c1=\"\" style=\"border-color:black;border-right-color:white;font-size: .9rem;color:black;\" width=\"60%\">  Rupees one  and thirty six  paisa</td><!----></tr>";
			string text46 = text45;
			string what22 = "message";
			string newValue16 = jsonData_Serial(text44, what22);
			string value5 = ",{";
			string str = text44.Substring(text44.IndexOf(value5) + 1);
			string newValue17 = "";
			string oldValue19 = "1.36";
			string text47 = text46.Replace(oldValue19, newValue16);
			string oldValue20 = "Rupees one  and thirty six  paisa";
			string text48 = text47.Replace(oldValue20, newValue17);
			string text49 = "<tr _ngcontent-c1=\"\"><td _ngcontent-c1=\"\" style=\"border-color:black;font-size: .9rem;color:black;\" width=\"30%\"><b _ngcontent-c1=\"\">&nbsp;Total Fare (all inclusive)</b></td><td _ngcontent-c1=\"\" style=\"border-color:black;width:60px;font-size: .9rem;color:black;\" width=\"10%\"><b _ngcontent-c1=\"\">₹</b> 1531.36</td><!----><td _ngcontent-c1=\"\" style=\"border-color:black;border-right-color:white;font-size: .9rem;color:black;\" width=\"60%\"> Rupees one thousand five hundred thirty one  and Zero paisa</td><!----></tr>";
			string what23 = "message";
			string newValue18 = jsonData_Serial(str, what23);
			string newValue19 = "";
			string oldValue21 = "1531.36";
			string text50 = text49.Replace(oldValue21, newValue18);
			string oldValue22 = "Rupees one thousand five hundred thirty one  and Zero paisa";
			string text51 = text50.Replace(oldValue22, newValue19);
			string newValue20 = text41 + text43 + text48 + text51;
			string oldValue23 = "1530.0";
			string text52 = text35.Replace(oldValue23, newValue14);
			string oldValue24 = "FAARE";
			string text53 = text52.Replace(oldValue24, newValue20);
			string what24 = "passengerBarCode";
			string text54 = jsonData_Serial(pnr, what24);
			string oldValue25 = "\r\n";
			string text55 = text54.Replace(oldValue25, "");
			string oldValue26 = "\\r\\n";
			string text56 = text55.Replace(oldValue26, "");
			string value6 = "passengerList";
			string text57 = pnr.Substring(pnr.IndexOf(value6));
			string value7 = "]";
			string text58 = text57.Substring(0, text57.IndexOf(value7));
			string text59 = "";
			int num = 0;
			string text60 = "<tr _ngcontent-c1=\"\"><td _ngcontent-c1=\"\" style=\"font-family: Arial; font-size: .9rem; color: black;\" width=\"5%\"> &nbsp;1</td><td _ngcontent-c1=\"\" style=\"font-family: Arial; font-size: .9rem; color: black;\" width=\"15%\"> &nbsp;MIHIR SINGH</td><td _ngcontent-c1=\"\" style=\"font-family: Arial; font-size: .9rem; color: black;\" width=\"5%\"> &nbsp;34</td><td _ngcontent-c1=\"\" style=\"font-family: Arial; font-size: .9rem; color: black;\" width=\"5%\"> &nbsp;Male</td><!----><!----><!----><!----><!----><td _ngcontent-c1=\"\" style=\"font-family: Arial; font-size: .9rem; color: black;\" width=\"20%\"> &nbsp;CNF/S9/26/MIDDLE </td><!----><!----><!----><!----><!----><td _ngcontent-c1=\"\" style=\"font-family: Arial; font-size: .9rem; color: black;\" width=\"20%\"> &nbsp;CNF/S9/26/MIDDLE </td><!----><!----><!----><!----><!----><!----><!----></tr>";
			string text61 = text60;
			int num2 = 0;
			int num3 = 0;
			for (int i = 1; i <= 7; i++)
			{
				string value8 = ":";
				int num4 = text56.IndexOf(value8, num) + 1;
				if (num4 <= 0)
				{
					break;
				}
				string text62 = text58;
				string text63 = text58;
				string value9 = "bookingBerthCode";
				string text64 = text62.Substring(text63.IndexOf(value9));
				string value10 = ",";
				string newValue21 = text56.Substring(num4, text56.IndexOf(value10, num4) - num4);
				string value11 = ":";
				int num5 = text56.IndexOf(value11, num4) + 1;
				string value12 = ",";
				string newValue22 = text56.Substring(num5, text56.IndexOf(value12, num5) - num5);
				string value13 = ":";
				int num6 = text56.IndexOf(value13, num5) + 1;
				string value14 = ",";
				string text65 = text56.Substring(num6, text56.IndexOf(value14, num6) - num6);
				int result = 0;
				if (int.TryParse(text65, out result))
				{
					if (result > 11)
					{
						num2++;
					}
					else
					{
						num3++;
					}
				}
				string value15 = ":";
				num = text56.IndexOf(value15, num6) + 1;
				int startIndex = num;
				string value16 = ",";
				string text66 = text56.Substring(startIndex, text56.IndexOf(value16, num) - num);
				string what25 = "currentBerthChoice";
				string text67 = jsonData_Serial(text64, what25);
				string value17 = "}";
				text58 = text64.Substring(text64.IndexOf(value17));
				string text68 = text59;
				string oldValue27 = ";1";
				string text69 = ";";
				string text70 = text61.Replace(oldValue27, text69 + i);
				string oldValue28 = "MIHIR SINGH";
				string text71 = text70.Replace(oldValue28, newValue21);
				string oldValue29 = "34";
				string text72 = text71.Replace(oldValue29, text65);
				string oldValue30 = "Male";
				string text73 = text72.Replace(oldValue30, newValue22);
				string oldValue31 = "CNF/S9/26/MIDDLE";
				string text74 = "/";
				text59 = text68 + text73.Replace(oldValue31, text66 + text74 + text67);
			}
			string oldValue32 = "PAXNAMES";
			string text75 = text53.Replace(oldValue32, text59);
			string oldValue33 = "05-Sep-2018 08:06:24";
			DateTime now = DateAndTime.Now;
			string text76 = "dd-MMM-yyyy hh:mm:ss";
			string text77 = text75.Replace(oldValue33, now.ToString(text76));
			string oldValue34 = "Adult: 2 Child: 1";
			string text78 = "Adult: ";
			string text79 = num2.ToString();
			string text80 = " Child: ";
			string s = text77.Replace(oldValue34, text78 + text79 + text80 + num3);
			string[] array = new string[7];
			string text81 = "ERS_";
			array[0] = text81;
			array[1] = text;
			string text82 = "_";
			array[2] = text82;
			array[3] = SRC_STN;
			string text83 = "_";
			array[4] = text83;
			array[5] = DEST_STN;
			string text84 = ".htm";
			array[6] = text84;
			string path2 = string.Concat(array);
			string path3 = Path.Combine(path, path2);
			string @string = Encoding.ASCII.GetString(Encoding.ASCII.GetBytes(s));
			string oldValue35 = "?";
			string text85 = @string.Replace(oldValue35, "");
			string text86 = "https://www.irctc.co.in/eticketing/BankResponse";
			string oldValue36 = text86;
			string oldValue37 = "/eticketing/";
			string newValue23 = "https://www.irctc.co.in/eticketing/";
			string text87 = text85.Replace(oldValue37, newValue23);
			string oldValue38 = "<input id=\"printPageButton\" onclick=\"printTktPage();\" type=\"button\" value=\"Print\"></input>";
			string text88 = text87.Replace(oldValue38, "");
			string oldValue39 = "<input id=\"printPageButton\" type=\"button\" onclick=\"printTktPage();\" value=\"Print\" />";
			string text89 = text88.Replace(oldValue39, "");
			string text90 = ".png";
			string text91 = text89.Replace(oldValue36, pnr + text90);
			string oldValue40 = "<html";
			string newValue24 = "<html moznomarginboxes mozdisallowselectionprint ";
			string text92 = text91.Replace(oldValue40, newValue24);
			string oldValue41 = "text/css\">";
			string newValue25 = "text/css\">\n\n@media print {\n@page { margin: 0px 20px 0px 20px; }\nbody { margin: 1.0cm; }\n}  ";
			string text93 = text92.Replace(oldValue41, newValue25);
			string oldValue42 = "jsfln=images";
			string newValue26 = "jsf?ln=images";
			string contents = text93.Replace(oldValue42, newValue26);
			string name = "windows-1255";
			File.WriteAllText(path3, contents, Encoding.GetEncoding(name));
		}
		catch
		{
		}
	}

	public static string jsonData_Serial(string str, string what)
	{
		string result = "";
		try
		{
			string text = "\"";
			string text2 = str.Substring(str.IndexOf(text + what));
			string text3 = text2.Substring(text2.IndexOf(what) + (what.Length + 3));
			string value = "\"";
			return text3.Substring(0, text3.IndexOf(value));
		}
		catch
		{
			return result;
		}
	}

	public static bool Errochk4_AppReq(string text, ref string What)
	{
		bool flag = false;
		string text2 = null;
		try
		{
			string text3 = "error";
			if (text == text3)
			{
				flag = true;
				string text4 = "session expired";
				text2 = text4;
				string text5 = "GotoStart:";
				text2 = text5 + text2;
			}
			string value = "/eticketing/errors.html";
			bool flag2 = text.IndexOf(value) != 0;
			string value2 = "https://www.irctc.co.in/eticketing/errors.html";
			int num = text.IndexOf(value2);
			if (!flag2 || num == 0)
			{
				flag = true;
				string text6 = "errors.html";
				text2 = text6;
				string text7 = "GotoStart:";
				text2 = text7 + text2;
			}
			string value3 = "invalid_grant";
			if (text.IndexOf(value3) > -1)
			{
				flag = true;
				string text8 = "invalid irctc id";
				text2 = text8;
				string text9 = "GotoFinish:";
				text2 = text9 + text2;
			}
			string value4 = "Invalid Captcha....";
			if (text.IndexOf(value4) > -1)
			{
				flag = true;
				string text10 = "Invalid Captcha....";
				text2 = text10;
				string text11 = "GotoOther:";
				text2 = text11 + text2;
			}
			string value5 = "Full authentication is required to access this resource";
			if (text.IndexOf(value5) > -1)
			{
				flag = true;
				string text12 = "unauthorized to access";
				text2 = text12;
				string text13 = "GotoStart:";
				text2 = text13 + text2;
			}
		}
		catch
		{
		}
		if (flag)
		{
			What = text2;
		}
		return flag;
	}

	public static bool Errochk4_App(string text, ref string What)
	{
		bool flag = false;
		string text2 = null;
		try
		{
			string text3 = "error";
			if (text == text3)
			{
				flag = true;
				string text4 = "session expired";
				text2 = text4;
				string text5 = "GotoStart:";
				text2 = text5 + text2;
			}
			string value = "/eticketing/errors.html";
			bool flag2 = text.IndexOf(value) != 0;
			string value2 = "https://www.irctc.co.in/eticketing/errors.html";
			int num = text.IndexOf(value2);
			if (!flag2 || num == 0)
			{
				flag = true;
				string text6 = "errors.html";
				text2 = text6;
				string text7 = "GotoStart:";
				text2 = text7 + text2;
			}
			string value3 = "invalid_grant";
			int num2 = text.IndexOf(value3);
			if (num2 < 0)
			{
				string value4 = "error\":\"unauthorized\",";
				num2 = text.IndexOf(value4);
			}
			if (num2 > -1)
			{
				flag = true;
				string text8 = "invalid irctc id-pwd";
				text2 = text8;
				string text9 = "GotoFinish:";
				text2 = text9 + text2;
			}
			string value5 = "Invalid Captcha....";
			if (text.IndexOf(value5) > -1)
			{
				flag = true;
				string text10 = "Invalid Captcha....";
				text2 = text10;
				string text11 = "GotoOther:";
				text2 = text11 + text2;
			}
			string value6 = "Full authentication is required to access this resource";
			if (text.IndexOf(value6) > -1)
			{
				flag = true;
				string text12 = "unauthorized to access";
				text2 = text12;
				string text13 = "GotoStart:";
				text2 = text13 + text2;
			}
			string value7 = "<title>MAINTENANCE ACTIVITY</title>";
			if (text.IndexOf(value7) > -1)
			{
				string text14 = "Site Maintenance..";
				text2 = text14;
				flag = true;
				string text15 = "Currently Site Goes Into MAINTENANCE.........Wish to Retry ?";
				string caption = "Metro";
				string text16 = MessageBox.Show(text15, caption, MessageBoxButtons.YesNo).ToString();
				string text17 = "Yes";
				string text19;
				if (text16 == text17)
				{
					string text18 = "GotoStart:";
					text19 = text18 + text2;
				}
				else
				{
					string text20 = "GotoFinish:";
					text19 = text20 + text2;
				}
				text2 = text19;
			}
			string text21 = "";
			string value8 = "errorMessage";
			if (text.IndexOf(value8) > -1)
			{
				string what = "errorMessage";
				text21 = jsonData_Serial(text, what);
			}
			if (text21 == "")
			{
				string value9 = "errorMsg";
				if (text.IndexOf(value9) > -1)
				{
					string what2 = "errorMsg";
					text21 = jsonData_Serial(text, what2);
				}
				else
				{
					string value10 = "error";
					if (text.IndexOf(value10) > -1)
					{
						string what3 = "error";
						text21 = jsonData_Serial(text, what3);
					}
				}
			}
			if (text21 != "")
			{
				text2 = text21;
				flag = true;
				string text22 = text21;
				string value11 = "JWT (claims->";
				if (text22.Contains(value11))
				{
					string value12 = "The JWT is not yet valid as the evaluation time NumericDate";
					bool flag3 = text.Contains(value12);
					string value13 = "Min 8 character & Max 15 character";
					if (!(flag3 | text.Contains(value13)))
					{
						string text23 = "GotoStart:";
						text2 = text23 + text2;
					}
					else
					{
						string text24 = "System Date And Time Is not Vaild or not in vaild format, Please Check DateAndTime";
						text2 = text24;
						MessageBox.Show(text2);
						string text25 = "GotoFinish:";
						text2 = text25 + text2;
					}
				}
				else
				{
					string text26 = text21;
					string value14 = "Unable to process JOSE object";
					if (text26.Contains(value14))
					{
						Thread.Sleep(4000);
						string text27 = "GotoStart:";
						text2 = text27 + text2;
					}
					else
					{
						string text28 = text21;
						string value15 = "Your earlier session has expired";
						bool flag4 = text28.Contains(value15);
						string text29 = text21;
						string value16 = "Transaction expired";
						string text49;
						if (!(flag4 | text29.Contains(value16)))
						{
							string text30 = text21;
							string value17 = "Some parameter are missing or incorrect";
							bool flag5 = text30.Contains(value17);
							string text31 = text21;
							string value18 = "Please enter a valid train number";
							if (!(flag5 | text31.Contains(value18)))
							{
								string text32 = text21;
								string value19 = "Not Authorised for this action";
								bool flag6 = text32.Contains(value19);
								string text33 = text21;
								string value20 = "Booking Not allowed";
								bool flag7 = flag6 | text33.Contains(value20);
								string text34 = text21;
								string value21 = "Invalid Request. Transaction Droped";
								if (!(flag7 | text34.Contains(value21)))
								{
									string text35 = text21;
									string value22 = "You are permitted only 6 transaction";
									bool flag8 = text35.Contains(value22);
									string text36 = text21;
									string value23 = "Your limit for 6 transactions in a month is exhausted";
									bool flag9 = flag8 | text36.Contains(value23);
									string text37 = text21;
									string value24 = "Booking not allowed as Date is Outside Advance Reservation Period";
									if (!(flag9 | text37.Contains(value24)))
									{
										string text38 = text21;
										string value25 = "No seats available  : Transaction dropped";
										bool flag10 = text38.Contains(value25);
										string text39 = text21;
										string value26 = "Bookings not allowed after charting";
										bool flag11 = flag10 | text39.Contains(value26);
										string text40 = text21;
										string value27 = "REGRET/WAITLIST";
										bool flag12 = flag11 | text40.Contains(value27);
										string text41 = text21;
										string value28 = "Train has Departed, Booking not allowed";
										if (!(flag12 | text41.Contains(value28)))
										{
											string text42 = text21;
											string value29 = "Choice of Confirm berths not met";
											bool flag13 = text42.Contains(value29);
											string text43 = text21;
											string value30 = "Tatkal incoming day booking not allowed before";
											bool flag14 = flag13 | text43.Contains(value30);
											string text44 = text21;
											string value31 = "Invalid OTP";
											if (!(flag14 | text44.Contains(value31)))
											{
												string text45 = text21;
												string value32 = "Unable to process current transaction";
												bool flag15 = text45.Contains(value32);
												string text46 = text21;
												string value33 = "Unable to perform Transaction. Please try later";
												if (!(flag15 | text46.Contains(value33)))
												{
													string text47 = text21;
													string value34 = "This site is currently unreachable. Please try after some time";
													if (text47.Contains(value34))
													{
														string text48 = "GotoOther:";
														text49 = text48 + text2;
													}
													else
													{
														string text50 = "GotoOther:";
														text49 = text50 + text2;
													}
												}
												else
												{
													string text51 = "GotoOther:";
													text49 = text51 + text2;
												}
											}
											else
											{
												string text52 = "GotoOther:";
												text49 = text52 + text2;
											}
										}
										else
										{
											string text53 = "GotoFinish:";
											text49 = text53 + text2;
										}
									}
									else
									{
										string text54 = "GotoFinish:";
										text49 = text54 + text2;
									}
								}
								else
								{
									string text55 = "GotoFinish:";
									text49 = text55 + text2;
								}
							}
							else
							{
								string text56 = "GotoFinish:";
								text49 = text56 + text2;
							}
						}
						else
						{
							string text57 = "GotoStart:";
							text49 = text57 + text2;
						}
						text2 = text49;
					}
				}
			}
		}
		catch
		{
		}
		if (flag)
		{
			What = text2;
		}
		return flag;
	}

	internal static Image Base64ToImage(string base64String)
	{
		byte[] array = Convert.FromBase64String(base64String);
		using MemoryStream stream = new MemoryStream(array, 0, array.Length);
		return Image.FromStream(stream, useEmbeddedColorManagement: true);
	}

	public static string smethod_FetchFieldValue(string Query, string FiledName)
	{
		string text = "";
		string delimiter = "#";
		string[] array = Strings.Split(FiledName, delimiter);
		try
		{
			DataTable dataTable = new DataTable();
			new SQLiteDataAdapter(Query, Class34.string_Database).Fill(dataTable);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				foreach (DataRow row in dataTable.Rows)
				{
					for (int i = 0; i < array.Length; i++)
					{
						if (i != 0)
						{
							string text2 = text;
							string text3 = "$";
							text = text2 + text3;
						}
						text += row[array[i]].ToString();
					}
				}
			}
		}
		catch
		{
		}
		return text;
	}

	public static void smethod_UpdateFieldValue(string Query)
	{
		try
		{
			SQLiteConnection sQLiteConnection = new SQLiteConnection(Class34.string_Database);
			SQLiteCommand sQLiteCommand = new SQLiteCommand();
			sQLiteConnection.Open();
			sQLiteCommand.Connection = sQLiteConnection;
			sQLiteCommand.CommandText = Query;
			sQLiteCommand.ExecuteNonQuery();
			sQLiteCommand.Dispose();
			sQLiteConnection.Close();
			sQLiteConnection.Dispose();
		}
		catch
		{
		}
	}

	public static string Debit_Encoding(object obj)
	{
		WebBrowser webBrowser = new WebBrowser();
		string text = "<html><script>var BS=128;var BB=128;var RA=[,,,,[,,,,10,,12,,14],,[,,,,12,,12,,14],,[,,,,14,,14,,14]];var SO=[,,,,[,1,2,3],,[,1,2,3],,[,1,3,4]];var RC=[0x01,0x02,0x04, 0x08,0x10,0x20,0x40,0x80,0x1b,0x36,0x6c,0xd8,0xab,0x4d,0x9a,0x2f,0x5e,0xbc,0x63,0xc6,0x97,0x35,0x6a,0xd4,0xb3,0x7d,0xfa,0xef,0xc5,0x91];var SB=[99,124,119,123,242,107,111,197,48,1,103,43,254,215,171,118,202,130,201,125,250,89,71,240,173,212,162,175,156,164,114,192,183,253,147,38,54,63,247,204,52,165,229,241,113,216,49,21,4,199,35,195,24,150,5,154,7,18,128,226,235,39,178,117,9,131,44,26,27,110,90,160,82,59,214,179,41,227,47,132,83,209,0,237,32,252,177,91,106,203,190,57,74,76,88,207,208,239,170,251,67,77,51,133,69,249,2,127,80,60,159,168,81,163,64,143,146,157,56,245,188,182,218,33,16,255,243,210,205,12,19,236,95,151,68,23,196,167,126,61,100,93,25,115,96,129,79,220,34,42,144,136,70,238,184,20,222,94,11,219,224,50,58,10,73,6,36,92,194,211,172,98,145,149,228,121,231,200,55,109,141,213,78,169,108,86,244,234,101,122,174,8,186,120,37,46,28,166,180,198,232,221,116,31,75,189,139,138,112,62,181,102,72,3,246,14,97,53,87,185,134,193,29,158,225,248,152,17,105,217,142,148,155,30,135,233,206,85,40,223,140,161,137,13,191,230,66,104,65,153,45,15,176,84,187,22];var SBI=[82,9,106,213,48,54,165,56,191,64,163,158,129,243,215,251,124,227,57,130,155,47,255,135,52,142,67,68,196,222,233,203,84,123,148,50,166,194,35,61,238,76,149,11,66,250,195,78,8,46,161,102,40,217,36,178,118,91,162,73,109,139,209,37,114,248,246,100,134,104,152,22,212,164,92,204,93,101,182,146,108,112,72,80,253,237,185,218,94,21,70,87,167,141,157,132,144,216,171,0,140,188,211,10,247,228,88,5,184,179,69,6,208,44,30,143,202,63,15,2,193,175,189,3,1,19,138,107,58,145,17,65,79,103,220,234,151,242,207,206,240,180,230,115,150,172,116,34,231,173,53,133,226,249,55,232,28,117,223,110,71,241,26,113,29,41,197,137,111,183,98,14,170,24,190,27,252,86,62,75,198,210,121,32,154,219,192,254,120,205,90,244,31,221,168,51,136,7,199,49,177,18,16,89,39,128,236,95,96,81,127,169,25,181,74,13,45,229,122,159,147,201,156,239,160,224,59,77,174,42,245,176,200,235,187,60,131,83,153,97,23,43,4,126,186,119,214,38,225,105,20,99,85,33,12,125];function cSL(TA,PO){var T=TA.slice(0,PO);TA=TA.slice(PO).concat(T);return TA;}var Nk=BS/32;var Nb=BB/32;var Nr=RA[Nk][Nb];function XT(P){P<<=1;return((P&0x100)?(P^0x11B):(P));}function GF(x,y){var B,R=0;for(B=1;B<256;B*=2,y=XT(y)){if(x&B)R^=y;}return R;}function bS(SE,DR){var S;if(DR==\"e\")\tS=SB;else \tS=SBI;for(var i=0;i<4;i++)\tfor(var j=0;j<Nb;j++)\t\tSE[i][j]=S[SE[i][j]];}function sR(SE,DR){for(var i=1;i<4;i++)if(DR==\"e\")\tSE[i]=cSL(SE[i],SO[Nb][i]);else \tSE[i]=cSL(SE[i],Nb-SO[Nb][i]);}function mC(SE,DR){\tvar b=[];\tfor(var j=0;j<Nb;j++)\t\t{\t\tfor(var i=0;i<4;i++)\t\t{\t\t\tif(DR==\"e\")\t\t\t\tb[i]=GF(SE[i][j],2)^GF(SE[(i+1)%4][j],3)^SE[(i+2)%4][j]^SE[(i+3)%4][j];\t\t\telse\t\t\t\tb[i]=GF(SE[i][j],0xE)^GF(SE[(i+1)%4][j],0xB)^GF(SE[(i+2)%4][j],0xD)^GF(SE[(i+3)%4][j],9);\t\t}\t\tfor(var i=0;i<4;i++)\t\t\tSE[i][j]=b[i];\t\t}}function aRK(SE,RK){\tfor(var j=0;j<Nb;j++)\t{\t\tSE[0][j]^=(RK[j]&0xFF);\t\tSE[1][j]^=((RK[j]>>8)&0xFF);\t\tSE[2][j]^=((RK[j]>>16)&0xFF);\t\tSE[3][j]^=((RK[j]>>24) & 0xFF);\t}}function YE(Y){var EY=[];var T;Nk=BS/32;Nb=BB/32;Nr=RA[Nk][Nb];for(var j=0;j<Nk;j++)\tEY[j]=(Y[4*j])|(Y[4*j+1]<<8)|(Y[4*j+2]<<16)|(Y[4*j+3]<<24);for(j=Nk;j<Nb*(Nr+1);j++){T=EY[j-1];if(j%Nk==0)\tT=((SB[(T>>8)&0xFF])|(SB[(T>>16)&0xFF]<<8)|(SB[(T>>24)&0xFF]<<16)|(SB[T&0xFF]<<24))^RC[Math.floor(j/Nk)-1];else if(Nk>6&&j%Nk==4)\tT=(SB[(T>>24)&0xFF]<<24)|(SB[(T>>16)&0xFF]<<16)|(SB[(T>>8)&0xFF]<<8)|(SB[T&0xFF]);EY[j]=EY[j-Nk]^T;}return EY;}function Rd(SE,RK){bS(SE,\"e\");sR(SE,\"e\");mC(SE,\"e\");aRK(SE,RK);}function iRd(SE,RK){aRK(SE,RK);mC(SE,\"d\");sR(SE,\"d\");bS(SE, \"d\");}function FRd(SE,RK){bS(SE,\"e\");sR(SE,\"e\");aRK(SE,RK);}function iFRd(SE,RK){aRK(SE,RK);sR(SE,\"d\");bS(SE,\"d\");}function encrypt(bk,EY){\tvar i;\tif(!bk||bk.length*8!=BB)\t\treturn;\tif(!EY)\t\treturn;bk=pB(bk);\taRK(bk,EY);\tfor(i=1;i<Nr;i++)\t\tRd(bk,EY.slice(Nb*i,Nb*(i+1)));\tFRd(bk,EY.slice(Nb*Nr));return uPB(bk);}function decrypt(bk,EY){var i;\tif(!bk||bk.length*8!=BB)\t\treturn;\tif(!EY)\t\treturn;bk=pB(bk);iFRd(bk,EY.slice(Nb*Nr));\t\tfor(i=Nr-1;i>0;i--)\t\t\tiRd(bk,EY.slice(Nb*i,Nb*(i+1)));aRK(bk,EY);\t\t\treturn uPB(bk);}function byteArrayToString(bA){\tvar R=\"\";\tfor(var i=0;i<bA.length; i++)\tif(bA[i]!=0)R+=String.fromCharCode(bA[i]);\treturn R;}function byteArrayToHex(bA){var R=\"\";if(!bA)\treturn;for(var i=0;i<bA.length;i++)\tR+=((bA[i]<16)?\"0\":\"\")+bA[i].toString(16);return R;}function hexToByteArray(hS){var bA=[];if(hS.length%2)return;if(hS.indexOf(\"0x\")==0||hS.indexOf(\"0X\")==0)hS = hS.substring(2);\tfor (var i=0;i<hS.length;i+=2)bA[Math.floor(i/2)]=parseInt(hS.slice(i,i+2),16);return bA;}function pB(OT){var SE = [];if(!OT||OT.length%4)return;SE[0]=[];SE[1]=[];SE[2]=[];SE[3]=[];for(var j=0;j<OT.length;j+=4){SE[0][j/4]=OT[j];SE[1][j/4]=OT[j+1];SE[2][j/4]=OT[j+2];SE[3][j/4]=OT[j+3];}return SE;}function uPB(PK){var R=[];for(var j=0;j<PK[0].length;j++){R[R.length]=PK[0][j];R[R.length]=PK[1][j];R[R.length]=PK[2][j];R[R.length]=PK[3][j];}return R;}function fPT(PT){var bpb=BB/8;var i;if(typeof PT==\"string\"||PT.indexOf){PT=PT.split(\"\");for(i=0;i<PT.length;i++)PT[i]=PT[i].charCodeAt(0)&0xFF;}for(i=bpb-(PT.length%bpb);i>0&&i<bpb;i--) PT[PT.length]=0;return PT;}function gRB(hM){var i;var bt=[];for(i=0;i<hM;i++)bt[i]=Math.round(Math.random()*255);return bt;}function rijndaelEncrypt(PT,Y,M){var EY,i,abk;var bpb=BB/8;var ct;if(!PT||!Y)return;if(Y.length*8!=BS)return;if(M==\"CBC\")ct=gRB(bpb);else {M=\"ECB\";ct=[];}PT=fPT(PT);EY=YE(Y);for (var bk=0; bk<PT.length/bpb;bk++){abk=PT.slice(bk*bpb,(bk+1)*bpb);if(M==\"CBC\")for (var i=0;i<bpb; i++)abk[i] ^= ct[bk*bpb+i];ct=ct.concat(encrypt(abk,EY));}return ct;}function rijndaelDecrypt(CT,Y,M){var EY;var bpb=BB/8;var pt=[];var abk;var bk;if(!CT||!Y||typeof CT==\"string\")return;if(Y.length*8!=BS)return;if(!M)M=\"ECB\";EY=YE(Y);for(bk=(CT.length/bpb)-1;bk>0;bk--){abk=decrypt(CT.slice(bk*bpb,(bk+1)*bpb),EY);if(M==\"CBC\")for(var i=0;i<bpb;i++)pt[(bk-1)*bpb+i]=abk[i]^CT[(bk-1)*bpb+i];else pt=abk.concat(pt);}if(M==\"ECB\") pt=decrypt(CT.slice(0,bpb),EY).concat(pt);return pt;}function stringToByteArray(st){var bA=[];for(var i=0;i<st.length; i++)bA[i]=st.charCodeAt(i);return bA;}function genkey(){\tvar j=\"\";\twhile(1)\t{\t\tvar i=Math.random().toString();\t\tj+=i.substring(i.lastIndexOf(\".\")+1);\t\tif(j.length>31)\t\t\treturn j.substring(0, 32);\t}}function EncCard(fValue, payId, mode){return byteArrayToHex(rijndaelEncrypt(fValue,hexToByteArray(payId), mode))}</script><body></body></html>";
		string text2 = text;
		string urlString = "about:blank";
		webBrowser.Navigate(urlString);
		webBrowser.Document.Write(text2);
		string text3 = obj.ToString();
		string[] array = new string[1];
		string text4 = "||";
		array[0] = text4;
		string[] array2 = text3.Split(array, StringSplitOptions.None);
		string text5 = "";
		if (array2.Length >= 3)
		{
			for (int i = 2; i < array2.Length; i++)
			{
				string text6 = text5;
				string text7 = method_1(webBrowser, array2[i], array2[0], array2[1]);
				string text8 = "||";
				text5 = text6 + text7 + text8;
			}
			text5 = text5.Substring(0, text5.Length - 2);
		}
		webBrowser.Dispose();
		return text5;
	}

	public static string DecryptAES(string encryptedInput, string symmetricKey)
	{
		try
		{
			byte[] key = GenerateAesKey(symmetricKey);
			byte[] iv = new byte[12];
			byte[] input = Convert.FromBase64String(encryptedInput);
			string algorithm = "AES/GCM/NoPadding";
			IBufferedCipher cipher = CipherUtilities.GetCipher(algorithm);
			cipher.Init(forEncryption: false, new ParametersWithIV(new KeyParameter(key), iv));
			byte[] bytes = cipher.DoFinal(input);
			string @string = Encoding.UTF8.GetString(bytes);
			string value = "||";
			if (@string.Contains(value))
			{
				string[] array = new string[1];
				string text = "||";
				array[0] = text;
				return @string.Split(array, StringSplitOptions.None)[1];
			}
			return @string;
		}
		catch (Exception ex)
		{
			string text2 = "Exception while decrypting data: ";
			return text2 + ex.Message;
		}
	}

	public static byte[] GenerateAesKey(string secretKey)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(secretKey);
		Sha256Digest sha256Digest = new Sha256Digest();
		sha256Digest.BlockUpdate(bytes, 0, bytes.Length);
		byte[] array = new byte[32];
		sha256Digest.DoFinal(array, 0);
		byte[] array2 = new byte[16];
		Array.Copy(array, array2, 16);
		return array2;
	}

	public static string EncryptAES(string input, string symmetricKey)
	{
		try
		{
			byte[] key = GenerateAesKey(symmetricKey);
			byte[] iv = new byte[12];
			string algorithm = "AES/GCM/NoPadding";
			IBufferedCipher cipher = CipherUtilities.GetCipher(algorithm);
			cipher.Init(forEncryption: true, new ParametersWithIV(new KeyParameter(key), iv));
			byte[] bytes = Encoding.UTF8.GetBytes(input);
			return Convert.ToBase64String(cipher.DoFinal(bytes));
		}
		catch (Exception ex)
		{
			string text = "Exception while encrypting data: ";
			return text + ex.Message;
		}
	}

	public static string DecryptAES0(string encryptedBase64, string symmetricKey)
	{
		try
		{
			byte[] key = GenerateAesKey(symmetricKey);
			byte[] iv = new byte[12];
			string algorithm = "AES/GCM/NoPadding";
			IBufferedCipher cipher = CipherUtilities.GetCipher(algorithm);
			cipher.Init(forEncryption: false, new ParametersWithIV(new KeyParameter(key), iv));
			byte[] input = Convert.FromBase64String(encryptedBase64);
			byte[] bytes = cipher.DoFinal(input);
			return Encoding.UTF8.GetString(bytes);
		}
		catch (Exception ex)
		{
			string text = "Exception while decrypting data: ";
			return text + ex.Message;
		}
	}

	public static string AkamaiToken(string url, string data_, string tokenCount)
	{
		string empty = string.Empty;
		string result = string.Empty;
		string variable = "clientID";
		Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.Process);
		string[] array = new string[7];
		string text = "{\"User\":\"";
		array[0] = text;
		array[1] = Program.clientID;
		string text2 = "\",\"data\":\"";
		array[2] = text2;
		array[3] = data_;
		string text3 = "\",\"sCount\":\"";
		array[4] = text3;
		array[5] = tokenCount;
		string text4 = "\"}";
		array[6] = text4;
		empty = string.Concat(array);
		try
		{
			string text5 = "UC4Jq21xDBhGl3ZQDpOpAS1vrL/k4wqk1jU8KNxspXEJOhzDmUOszQfEgVQBIQvs";
			string symmetricKey = text5;
			string text6 = "http://localhost:64404/api/get/GP";
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text6 + url);
			httpWebRequest.ServerCertificateValidationCallback = CheckCertificate;
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
			string contentType = "application/json";
			httpWebRequest.ContentType = contentType;
			string method = "POST";
			httpWebRequest.Method = method;
			httpWebRequest.Timeout = 25000;
			httpWebRequest.ReadWriteTimeout = 25000;
			using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
			{
				string value = empty;
				streamWriter.Write(value);
			}
			using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
			ResponseAkamaiList responseAkamaiList = JsonConvert.DeserializeObject<ResponseAkamaiList>(streamReader.ReadToEnd());
			string text7 = string.Empty;
			int num = 0;
			foreach (string item in responseAkamaiList.Token)
			{
				if (num == 0)
				{
					text7 = DecryptAES(item, symmetricKey);
				}
				else
				{
					string text8 = text7;
					string text9 = "|";
					text7 = text8 + text9 + DecryptAES(item, symmetricKey);
				}
				num++;
			}
			result = text7;
		}
		catch (WebException)
		{
			try
			{
				string text10 = "UC4Jq21xDBhGl3ZQDpOpAS1vrL/k4wqk1jU8KNxspXEJOhzDmUOszQfEgVQBIQvs";
				string symmetricKey2 = text10;
				string text11 = "http://localhost:64404/api/get/GP";
				HttpWebRequest httpWebRequest2 = (HttpWebRequest)WebRequest.Create(text11 + url);
				httpWebRequest2.ServerCertificateValidationCallback = CheckCertificate;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				string contentType2 = "application/json";
				httpWebRequest2.ContentType = contentType2;
				string method2 = "POST";
				httpWebRequest2.Method = method2;
				httpWebRequest2.Timeout = 25000;
				httpWebRequest2.ReadWriteTimeout = 25000;
				using (StreamWriter streamWriter2 = new StreamWriter(httpWebRequest2.GetRequestStream()))
				{
					string value2 = empty;
					streamWriter2.Write(value2);
				}
				using StreamReader streamReader2 = new StreamReader(((HttpWebResponse)httpWebRequest2.GetResponse()).GetResponseStream());
				JObject jObject = JObject.Parse(streamReader2.ReadToEnd());
				string propertyName = "Token";
				result = DecryptAES(jObject[propertyName]?.ToString(), symmetricKey2);
			}
			catch (WebException)
			{
				string text12 = "Token No Available";
				result = text12;
			}
		}
		return result;
	}

	private static bool CheckCertificate(object object_18, X509Certificate x509Certificate_0, X509Chain x509Chain_0, SslPolicyErrors sslPolicyErrors_0)
	{
		bool result = true;
		try
		{
			HttpWebRequest httpWebRequest = object_18 as HttpWebRequest;
			int num;
			if (httpWebRequest != null)
			{
				string text = httpWebRequest.Address.ToString().ToLower();
				string value = "https://www.google.co.in";
				if (text.Contains(value))
				{
					string issuer = x509Certificate_0.Issuer;
					string value2 = "CN=Google";
					num = ((!issuer.StartsWith(value2)) ? 1 : 0);
					goto IL_0065;
				}
			}
			num = 0;
			goto IL_0065;
			IL_0065:
			int num2;
			if (httpWebRequest != null)
			{
				string text2 = httpWebRequest.Address.ToString().ToLower();
				string value3 = "irctc.co.in";
				num2 = (text2.Contains(value3) ? 1 : 0);
			}
			else
			{
				num2 = 0;
			}
			bool flag = (byte)num2 != 0;
			if (num2 != 0)
			{
				string issuer2 = x509Certificate_0.Issuer;
				string value4 = "CN=DigiCert";
				bool flag2 = issuer2.StartsWith(value4);
				string issuer3 = x509Certificate_0.Issuer;
				string value5 = "CN=GeoTrust";
				bool flag3 = flag2 | issuer3.StartsWith(value5);
				string issuer4 = x509Certificate_0.Issuer;
				string value6 = "CN=GlobalSign";
				bool flag4 = flag3 | issuer4.StartsWith(value6);
				string issuer5 = x509Certificate_0.Issuer;
				string value7 = "CN=Amazon";
				flag = !(flag4 | issuer5.StartsWith(value7));
			}
			if ((num | ((flag ? true : false) ? 1 : 0)) != 0)
			{
				result = false;
			}
			string text3 = x509Certificate_0.Issuer.ToLower();
			string value8 = "httpanalyze";
			bool flag5 = text3.Contains(value8);
			string text4 = x509Certificate_0.Issuer.ToLower();
			string value9 = "fiddler";
			bool flag6 = flag5 | text4.Contains(value9);
			string text5 = x509Certificate_0.Issuer.ToLower();
			string value10 = "commview";
			bool flag7 = flag6 | text5.Contains(value10);
			string text6 = x509Certificate_0.Issuer.ToLower();
			string value11 = "debugger";
			bool flag8 = flag7 | text6.Contains(value11);
			string text7 = x509Certificate_0.Issuer.ToLower();
			string value12 = "debug";
			bool flag9 = flag8 | text7.Contains(value12);
			string text8 = x509Certificate_0.Issuer.ToLower();
			string value13 = "sniffer";
			bool flag10 = flag9 | text8.Contains(value13);
			string text9 = x509Certificate_0.Issuer.ToUpper();
			string value14 = "IEINSPECTOR";
			if (flag10 | text9.Contains(value14))
			{
				result = false;
			}
			if (httpWebRequest != null)
			{
				string text10 = httpWebRequest.Address.ToString().ToLower();
				string value15 = "https://ngetweb.com";
				if (text10.Contains(value15))
				{
					string issuer6 = x509Certificate_0.Issuer;
					string value16 = "CN=R10";
					if (!issuer6.StartsWith(value16))
					{
						result = false;
					}
				}
			}
		}
		catch (Exception)
		{
			result = true;
		}
		return result;
	}

	internal static string GetProxy(string string_5)
	{
		string text = string.Empty;
		try
		{
			string text2 = "http://ngetweb.com:8080/Secure/NetProxy";
			string requestUriString = text2;
			string[] array = new string[5];
			string text3 = "{\"RequestToken\":\"";
			array[0] = text3;
			array[1] = string_5;
			string text4 = "\",\"data\":\"";
			array[2] = text4;
			array[3] = Program.clientID;
			string text5 = "\",\"Action\":\"true\"}";
			array[4] = text5;
			string text6 = string.Concat(array);
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
			string contentType = "application/json";
			httpWebRequest.ContentType = contentType;
			httpWebRequest.Timeout = 55000;
			httpWebRequest.ReadWriteTimeout = 55000;
			string method = "POST";
			httpWebRequest.Method = method;
			using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
			{
				string value = text6;
				streamWriter.Write(value);
			}
			using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
			string text7 = streamReader.ReadToEnd();
			string value2 = "Token";
			string text8 = text7.Substring(text7.IndexOf(value2) + 8);
			string value3 = "\"";
			string string_6 = text8.Substring(0, text8.IndexOf(value3));
			string string_7 = "GS61L#6AS$NSH67WGG";
			text = Class2.Decrypt(string_6, string_7);
			string text9 = text;
			string value4 = ":";
			if (text9.Contains(value4))
			{
				string text10 = text;
				string[] array2 = new string[1];
				string text11 = ":";
				array2[0] = text11;
				string[] array3 = text10.Split(array2, StringSplitOptions.None);
				string text12 = "b5978d8b0cb1d584.uvb.as.pyproxy.io:16666:";
				string text13 = array3[0];
				string text14 = "-zone-resi-region-in:";
				text = text12 + text13 + text14 + array3[1];
			}
		}
		catch (Exception)
		{
		}
		if (string.IsNullOrEmpty(text))
		{
			try
			{
				string requestUriString2 = "https://nexusupdatefile.s3.ap-south-1.amazonaws.com/AMTg55";
				HttpWebRequest httpWebRequest2 = (HttpWebRequest)WebRequest.Create(requestUriString2);
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				string contentType2 = "application/json";
				httpWebRequest2.ContentType = contentType2;
				httpWebRequest2.Timeout = 55000;
				httpWebRequest2.ReadWriteTimeout = 55000;
				string method2 = "GET";
				httpWebRequest2.Method = method2;
				using StreamReader streamReader2 = new StreamReader(((HttpWebResponse)httpWebRequest2.GetResponse()).GetResponseStream());
				string string_8 = streamReader2.ReadToEnd();
				string string_9 = "VB#3G!bB77K";
				text = Class2.Decrypt(string_8, string_9);
			}
			catch (Exception)
			{
			}
		}
		return text;
	}

	public static string method_1(WebBrowser browser, string string_1, string string_2, string string_3)
	{
		object[] args = new object[3] { string_1, string_2, string_3 };
		HtmlDocument document = browser.Document;
		string scriptName = "EncCard";
		object obj = document.InvokeScript(scriptName, args);
		if (obj == null)
		{
			return "";
		}
		return obj.ToString();
	}

	public static string GetAirtel_Encryption(object str)
	{
		string text = "";
		string[] array = new string[5];
		string text2 = "<script type=\"text/javascript\">";
		array[0] = text2;
		array[1] = Strings.ChrW(10).ToString();
		array[2] = Strings.ChrW(9).ToString();
		array[3] = text;
		string text3 = "</script>";
		array[4] = text3;
		string text4 = string.Concat(array);
		string string_ = Class32.String_31;
		string text5 = string_;
		string text6 = string_;
		string value = "var JSEncryptExports";
		string_ = text5.Substring(text6.IndexOf(value));
		string text7 = string_;
		string text8 = string_;
		string value2 = "var b64map";
		string_ = text7.Substring(0, text8.IndexOf(value2));
		string text9 = "function c() {\r\n        for (var a, c = \"0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz\", d = b.Math, e = 11, f = \"\"; e > 0; )\r\n            a = d.floor(d.random() * c.length),\r\n            f += c.charAt(a),\r\n            e--;\r\n        return appConstants.FE_SESSION_PREFIX + f\r\n    }\r\n    var d = this;\r\n    this.generateRandomString = function() {\r\n        for (var a = 24, b = \"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789\", c = \"\", d = 0; a > d; d++)\r\n            c += b.charAt(Math.floor(Math.random() * b.length));\r\n        return c\r\n    }\r\n    ,\r\n    this.tripleDesEncryption = function(a, b) {\r\n        var c = CryptoJS.enc.Utf8.parse(b)\r\n          , d = CryptoJS.TripleDES.encrypt(a, c, {\r\n            mode: CryptoJS.mode.ECB,\r\n            padding: CryptoJS.pad.Pkcs7\r\n        });\r\n        return d.toString()\r\n    }\r\n    ,\r\n    this.RsaEncryption = function(a, b) {\r\n        var c = new RSAKey;\r\n        c.setPublic(b.modulus, b.exponent);\r\n        var d = linebrk(hex2b64(c.encrypt(a)), 64);\r\n        return d.split(\"\\n\").join(\"\")\r\n    }\r\n    ,\r\n    this.generateEncryptedKey = function(g) {\r\n        var f = new JSEncrypt;\r\n        f.setPublicKey(\"3082 0122 300d 0609 2a86 4886 f70d 0101 0105 0003 8201 0f00 3082 010a 0282 0101 009e c52b 21ed 6908 92e8 8205 695f 0777 1967 a85f e15c eae0 1852 43eb 82b7 b089 787c f7de 6e4c f54a cdf2 40cb 98a8 a859 8e7e 95ca 22e6 8519 de30 4bf0 6b68 b947 c6d3 3efe abc0 92b7 832a 62da 058a a7d2 9dc4 684c 0a50 83d7 c782 c04c 0f54 8a9d d664 c999 d3c4 e81f 0258 f290 a40e a58b c872 6de3 97fa 8f65 8b3f 0a26 e397 be6c eed4 bd4b f596 14b1 5823 6e0f c29b c0fa e1c0 a50e 898e 4f2f e3d2 3204 b232 74d5 38c4 0808 5e57 f094 9117 34dd c1b3 65b3 f2c5 ac3a 813b 18e3 dba4 2f2f 6a28 f486 16b0 296b 7eea 482c 5979 33a7 b1c5 8d90 013a 85f0 49ff 2e70 f87a 2a30 d48e 16b7 cb1c 626b e995 2db6 5296 f06a bb5f ffd3 01d2 0b9f 5eb8 80da f125 f906 81fa 3e3a 3902 0301 0001\");\r\n        var key = f.encrypt(g);\r\n        return key;\r\n    }\r\n";
		string_ = text9 + string_;
		string[] array2 = new string[5];
		string text10 = "<script type=\"text/javascript\">";
		array2[0] = text10;
		array2[1] = Strings.ChrW(10).ToString();
		array2[2] = Strings.ChrW(9).ToString();
		array2[3] = string_;
		string text11 = "</script>";
		array2[4] = text11;
		string text12 = string.Concat(array2);
		string[] array3 = new string[5];
		string text13 = "<html>\n<head>\n";
		array3[0] = text13;
		array3[1] = text4;
		string text14 = "\n";
		array3[2] = text14;
		array3[3] = text12;
		string text15 = "\n</head>\n<body>\n</body>\n</html>";
		array3[4] = text15;
		string text16 = string.Concat(array3);
		WebBrowser webBrowser = new WebBrowser();
		webBrowser.ScriptErrorsSuppressed = false;
		string urlString = "about:blank";
		webBrowser.Navigate(urlString);
		webBrowser.Document.Write(text16);
		HtmlDocument document = webBrowser.Document;
		string scriptName = "generateRandomString";
		string text17 = document.InvokeScript(scriptName, new object[0]).ToString();
		HtmlDocument document2 = webBrowser.Document;
		string scriptName2 = "tripleDesEncryption";
		string str2 = document2.InvokeScript(scriptName2, new object[2] { str, text17 }).ToString();
		HtmlDocument document3 = webBrowser.Document;
		string scriptName3 = "generateEncryptedKey";
		string str3 = document3.InvokeScript(scriptName3, new object[1] { text17 }).ToString();
		string[] array4 = new string[4];
		string text18 = "data=";
		array4[0] = text18;
		array4[1] = HttpUtility.UrlEncode(str2);
		string text19 = "&key=";
		array4[2] = text19;
		array4[3] = HttpUtility.UrlEncode(str3);
		return string.Concat(array4);
	}

	public static string GetAirtel_Encryption0(object str)
	{
		WebClient webClient = new WebClient();
		string text = "";
		string[] array = new string[5];
		string text2 = "<script type=\"text/javascript\">";
		array[0] = text2;
		array[1] = Strings.ChrW(10).ToString();
		array[2] = Strings.ChrW(9).ToString();
		array[3] = text;
		string text3 = "</script>";
		array[4] = text3;
		string text4 = string.Concat(array);
		string text5 = "function printStackTrace(a){var a=a||{guess:!0},b=a.e||null,a=!!a.guess,c=new printStackTrace.implementation,b=c.run(b);return a?c.guessAnonymousFunctions(b):b}";
		string uriString = "https://ecom.airtelbank.com/irctc/scripts/vendors.8e6d41af.js";
		string text6 = text5 + webClient.DownloadString(new Uri(uriString));
		string text7 = text6;
		string text8 = text6;
		string value = "var JSEncryptExports";
		text6 = text7.Substring(text8.IndexOf(value));
		string text9 = text6;
		string text10 = text6;
		string value2 = "b64map";
		text6 = text9.Substring(0, text10.IndexOf(value2));
		string text11 = "function c() {\r\n        for (var a, c = \"0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz\", d = b.Math, e = 11, f = \"\"; e > 0; )\r\n            a = d.floor(d.random() * c.length),\r\n            f += c.charAt(a),\r\n            e--;\r\n        return appConstants.FE_SESSION_PREFIX + f\r\n    }\r\n    var d = this;\r\n    this.generateRandomString = function() {\r\n        for (var a = 24, b = \"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789\", c = \"\", d = 0; a > d; d++)\r\n            c += b.charAt(Math.floor(Math.random() * b.length));\r\n        return c\r\n    }\r\n    ,\r\n    this.tripleDesEncryption = function(a, b) {\r\n        var c = CryptoJS.enc.Utf8.parse(b)\r\n          , d = CryptoJS.TripleDES.encrypt(a, c, {\r\n            mode: CryptoJS.mode.ECB,\r\n            padding: CryptoJS.pad.Pkcs7\r\n        });\r\n        return d.toString()\r\n    }\r\n    ,\r\n    this.RsaEncryption = function(a, b) {\r\n        var c = new RSAKey;\r\n        c.setPublic(b.modulus, b.exponent);\r\n        var d = linebrk(hex2b64(c.encrypt(a)), 64);\r\n        return d.split(\"\\n\").join(\"\")\r\n    }\r\n    ,\r\n    this.generateEncryptedKey = function(g) {\r\n        var f = new JSEncrypt;\r\n        f.setPublicKey(\"3082 0122 300d 0609 2a86 4886 f70d 0101 0105 0003 8201 0f00 3082 010a 0282 0101 009e c52b 21ed 6908 92e8 8205 695f 0777 1967 a85f e15c eae0 1852 43eb 82b7 b089 787c f7de 6e4c f54a cdf2 40cb 98a8 a859 8e7e 95ca 22e6 8519 de30 4bf0 6b68 b947 c6d3 3efe abc0 92b7 832a 62da 058a a7d2 9dc4 684c 0a50 83d7 c782 c04c 0f54 8a9d d664 c999 d3c4 e81f 0258 f290 a40e a58b c872 6de3 97fa 8f65 8b3f 0a26 e397 be6c eed4 bd4b f596 14b1 5823 6e0f c29b c0fa e1c0 a50e 898e 4f2f e3d2 3204 b232 74d5 38c4 0808 5e57 f094 9117 34dd c1b3 65b3 f2c5 ac3a 813b 18e3 dba4 2f2f 6a28 f486 16b0 296b 7eea 482c 5979 33a7 b1c5 8d90 013a 85f0 49ff 2e70 f87a 2a30 d48e 16b7 cb1c 626b e995 2db6 5296 f06a bb5f ffd3 01d2 0b9f 5eb8 80da f125 f906 81fa 3e3a 3902 0301 0001\");\r\n        var key = f.encrypt(g);\r\n        return key;\r\n    }\r\n";
		text6 = text11 + text6;
		string[] array2 = new string[5];
		string text12 = "<script type=\"text/javascript\">";
		array2[0] = text12;
		array2[1] = Strings.ChrW(10).ToString();
		array2[2] = Strings.ChrW(9).ToString();
		array2[3] = text6;
		string text13 = "</script>";
		array2[4] = text13;
		string text14 = string.Concat(array2);
		string[] array3 = new string[5];
		string text15 = "<html>\n<head>\n";
		array3[0] = text15;
		array3[1] = text4;
		string text16 = "\n";
		array3[2] = text16;
		array3[3] = text14;
		string text17 = "\n</head>\n<body>\n</body>\n</html>";
		array3[4] = text17;
		string text18 = string.Concat(array3);
		WebBrowser webBrowser = new WebBrowser();
		webBrowser.ScriptErrorsSuppressed = false;
		string urlString = "about:blank";
		webBrowser.Navigate(urlString);
		webBrowser.Document.Write(text18);
		HtmlDocument document = webBrowser.Document;
		string scriptName = "generateRandomString";
		string text19 = document.InvokeScript(scriptName, new object[0]).ToString();
		HtmlDocument document2 = webBrowser.Document;
		string scriptName2 = "tripleDesEncryption";
		string str2 = document2.InvokeScript(scriptName2, new object[2] { str, text19 }).ToString();
		HtmlDocument document3 = webBrowser.Document;
		string scriptName3 = "generateEncryptedKey";
		string str3 = document3.InvokeScript(scriptName3, new object[1] { text19 }).ToString();
		string[] array4 = new string[4];
		string text20 = "data=";
		array4[0] = text20;
		array4[1] = HttpUtility.UrlEncode(str2);
		string text21 = "&key=";
		array4[2] = text21;
		array4[3] = HttpUtility.UrlEncode(str3);
		return string.Concat(array4);
	}

	public static string GetAirtel_Encryption2(object str)
	{
		string result = "";
		try
		{
			new WebClient();
			string text = "";
			string[] array = new string[5];
			string text2 = "<script type=\"text/javascript\">";
			array[0] = text2;
			array[1] = Strings.ChrW(10).ToString();
			array[2] = Strings.ChrW(9).ToString();
			array[3] = text;
			string text3 = "</script>";
			array[4] = text3;
			string text4 = string.Concat(array);
			string string_ = Class32.String_31;
			string value = "var JSEncryptExports";
			string text5 = string_.Substring(string_.IndexOf(value));
			string text6 = "function c() {\r\n        for (var a, c = \"0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz\", d = b.Math, e = 11, f = \"\"; e > 0; )\r\n            a = d.floor(d.random() * c.length),\r\n            f += c.charAt(a),\r\n            e--;\r\n        return appConstants.FE_SESSION_PREFIX + f\r\n    }\r\n    var d = this;\r\n    this.generateRandomString = function() {\r\n        for (var a = 24, b = \"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789\", c = \"\", d = 0; a > d; d++)\r\n            c += b.charAt(Math.floor(Math.random() * b.length));\r\n        return c\r\n    }\r\n    ,\r\n    this.tripleDesEncryption = function(a, b) {\r\n        var c = CryptoJS.enc.Utf8.parse(b)\r\n          , d = CryptoJS.TripleDES.encrypt(a, c, {\r\n            mode: CryptoJS.mode.ECB,\r\n            padding: CryptoJS.pad.Pkcs7\r\n        });\r\n        return d.toString()\r\n    }\r\n    ,\r\n    this.RsaEncryption = function(a, b) {\r\n        var c = new RSAKey;\r\n        c.setPublic(b.modulus, b.exponent);\r\n        var d = linebrk(hex2b64(c.encrypt(a)), 64);\r\n        return d.split(\"\\n\").join(\"\")\r\n    }\r\n    ,\r\n    this.generateEncryptedKey = function(g) {\r\n        var f = new JSEncrypt;\r\n        f.setPublicKey(\"3082 0122 300d 0609 2a86 4886 f70d 0101 0105 0003 8201 0f00 3082 010a 0282 0101 009e c52b 21ed 6908 92e8 8205 695f 0777 1967 a85f e15c eae0 1852 43eb 82b7 b089 787c f7de 6e4c f54a cdf2 40cb 98a8 a859 8e7e 95ca 22e6 8519 de30 4bf0 6b68 b947 c6d3 3efe abc0 92b7 832a 62da 058a a7d2 9dc4 684c 0a50 83d7 c782 c04c 0f54 8a9d d664 c999 d3c4 e81f 0258 f290 a40e a58b c872 6de3 97fa 8f65 8b3f 0a26 e397 be6c eed4 bd4b f596 14b1 5823 6e0f c29b c0fa e1c0 a50e 898e 4f2f e3d2 3204 b232 74d5 38c4 0808 5e57 f094 9117 34dd c1b3 65b3 f2c5 ac3a 813b 18e3 dba4 2f2f 6a28 f486 16b0 296b 7eea 482c 5979 33a7 b1c5 8d90 013a 85f0 49ff 2e70 f87a 2a30 d48e 16b7 cb1c 626b e995 2db6 5296 f06a bb5f ffd3 01d2 0b9f 5eb8 80da f125 f906 81fa 3e3a 3902 0301 0001\");\r\n        var key = f.encrypt(g);\r\n        return key;\r\n    }\r\n";
			string value2 = "var b64map";
			string text7 = text6 + text5.Substring(0, text5.IndexOf(value2));
			string[] array2 = new string[5];
			string text8 = "<script type=\"text/javascript\">";
			array2[0] = text8;
			array2[1] = Strings.ChrW(10).ToString();
			array2[2] = Strings.ChrW(9).ToString();
			array2[3] = text7;
			string text9 = "</script>";
			array2[4] = text9;
			string text10 = string.Concat(array2);
			string[] array3 = new string[5];
			string text11 = "<html>\n<head>\n";
			array3[0] = text11;
			array3[1] = text4;
			string text12 = "\n";
			array3[2] = text12;
			array3[3] = text10;
			string text13 = "\n</head>\n<body>\n</body>\n</html>";
			array3[4] = text13;
			string text14 = string.Concat(array3);
			WebBrowser webBrowser = new WebBrowser();
			webBrowser.ScriptErrorsSuppressed = false;
			string urlString = "about:blank";
			webBrowser.Navigate(urlString);
			webBrowser.Document.Write(text14);
			HtmlDocument document = webBrowser.Document;
			string scriptName = "generateRandomString";
			string text15 = document.InvokeScript(scriptName, new object[0]).ToString();
			HtmlDocument document2 = webBrowser.Document;
			string scriptName2 = "tripleDesEncryption";
			string value3 = document2.InvokeScript(scriptName2, new object[2] { str, text15 }).ToString();
			HtmlDocument document3 = webBrowser.Document;
			string scriptName3 = "generateEncryptedKey";
			string value4 = document3.InvokeScript(scriptName3, new object[1] { text15 }).ToString();
			string text16 = "data=";
			string text17 = WebUtility.UrlEncode(value3);
			string text18 = "&key=";
			result = text16 + text17 + text18 + WebUtility.UrlEncode(value4);
		}
		catch
		{
		}
		return result;
	}

	public static string IDBI_Encoding(string pass, string Key)
	{
		string[] array = new string[5];
		string text = "<html>\n<head>\n\n<script type=\"text/javascript\">\n\tfunction encryptUsingJS(e, t, n) {\r\nvar e1;\r\nvar e2;\r\nvar i = function(i) {\r\n        var r;\r\n        r ='";
		array[0] = text;
		array[1] = pass;
		string text2 = "';\r\n        e1 = encrypt(\"password=\" + r, i);\r\n        for (var a = r.length, o = 0; a > o; o++) {\r\n            var s = r[o];\r\n                var d = r\r\n                  , u = 'ACCESS_CODE'\r\n                  , l = !0;\r\n                if (-1 != u.indexOf(\"ACCESS_CODE\")) {\r\n                    var p = d.length;\r\n                    p > 128 && (l = !1)\r\n                }\r\n                e2 = encrypt(\"password=\" + d + \"_SALT_COMPONENT_=\" + Math.random(), i);\r\n        }\r\n    }\r\n    ;\r\n    getPublicKeyFromServer(i, e)\r\n   return e1;\r\n}\r\nfunction getPublicKeyFromServer(e, t) {\r\n    var n = function(e, t, n) {\r\n        setMaxDigits(parseInt(n, 10)),\r\n        this.e = biFromHex(e),\r\n        this.m = biFromHex(t),\r\n        this.chunkSize = 2 * biHighIndex(this.m),\r\n        this.radix = 16,\r\n        this.barrett = new BarrettMu(this.m)\r\n    }\r\n      , i = '";
		array[2] = text2;
		array[3] = Key;
		string text3 = "'\r\n      , r = i.split(\",\")[0]\r\n      , a = i.split(\",\")[1]\r\n      , o = i.split(\",\")[2]\r\n      , s = new n(r,a,o);\r\n    e(s)\r\n}\r\n\n\n    jCryption1 = function(t, n) {\r\n        var r = this;\r\n        r.$el = e(t);\r\n        r.el = t;\r\n        r.$el.data(\"jCryption\", r);\r\n        r.init = function() {\r\n            r.options = e.extend({}, e.jCryption.defaultOptions, n);\r\n            $encryptedElement = e(\"<input />\", {\r\n                type: \"hidden\",\r\n                name: r.options.postVariable\r\n            });\r\n            if (r.options.submitElement !== false)\r\n                var t = r.options.submitElement;\r\n            else\r\n                var t = r.$el.find(\":input:submit\");\r\n            t.bind(r.options.submitEvent, function() {\r\n                e(this).attr(\"disabled\", true);\r\n                if (r.options.beforeEncryption())\r\n                    e.jCryption.getKeys(r.options.getKeysURL, function(t) {\r\n                        e.jCryption.encrypt(r.$el.serialize(), t, function(t) {\r\n                            console.log(t);\r\n                            $encryptedElement.val(t);\r\n                            e(r.$el).find(\":input\").attr(\"disabled\", true).end().append($encryptedElement).submit()\r\n                        })\r\n                    });\r\n                return false\r\n            })\r\n        }\r\n        ;\r\n        r.init()\r\n    }\r\n    ;\r\n    getKeys = function(t, n) {\r\n        var r = function(e, t, n) {\r\n            setMaxDigits(parseInt(n, 10));\r\n            this.e = biFromHex(e);\r\n            this.m = biFromHex(t);\r\n            this.chunkSize = 2 * biHighIndex(this.m);\r\n            this.radix = 16;\r\n            this.barrett = new BarrettMu(this.m)\r\n        }\r\n        ;\r\n        e.getJSON(t, function(t) {\r\n            keys = new r(t.e,t.n,t.maxdigits);\r\n            if (e.isFunction(n))\r\n                n.call(this, keys)\r\n        })\r\n    }\r\n    ;\r\n    encrypt = function(t, n) {\r\n        function h(t) {\r\n            function f() {\r\n                u = new BigInt;\r\n                o = 0;\r\n                for (var l = s; l < s + n.chunkSize; ++o) {\r\n                    u.digits[o] = t[l++];\r\n                    u.digits[o] += t[l++] << 8\r\n                }\r\n                var c = n.barrett.powMod(u, n.e);\r\n                var h = n.radix == 16 ? biToHex(c) : biToString(c, n.radix);\r\n            return h;\r\n            }\r\n            var s = 0;\r\n            var o, u;\r\n            var a = \"\";\r\n            var j=f()\r\nreturn j;\r\n        }\r\n        var s = 0;\r\n        for (var o = 0; o < t.length; o++)\r\n            s += t.charCodeAt(o);\r\n        var u = \"0123456789abcdef\";\r\n        var a = \"\";\r\n        a += u.charAt((s & 240) >> 4) + u.charAt(s & 15);\r\n        var f = a + t;\r\n        var l = [];\r\n        var c = 0;\r\n        while (c < f.length) {\r\n            l[c] = f.charCodeAt(c);\r\n            c++\r\n        }\r\n        while (l.length % n.chunkSize !== 0)\r\n            l[c++] = 0;\r\n        var y = h(l)\r\nreturn y;\r\n    }\r\n    ;\r\n    defaultOptions = {\r\n        submitElement: false,\r\n        submitEvent: \"click\",\r\n        getKeysURL: \"/jsp/jc.jsp?generateKeypair=true\",\r\n        beforeEncryption: function() {\r\n            return true\r\n        },\r\n        postVariable: \"jCryption\"\r\n    };\r\n    jCryption2 = function(t) {\r\n        return this.each(function() {\r\n            new jCryption1(this,t)\r\n        })\r\n    }\r\n\n\n\nfunction setMaxDigits(e) {\r\n    maxDigits = e;\r\n    ZERO_ARRAY = new Array(maxDigits);\r\n    for (var t = 0; t < ZERO_ARRAY.length; t++)\r\n        ZERO_ARRAY[t] = 0;\r\n    bigZero = new BigInt;\r\n    bigOne = new BigInt;\r\n    bigOne.digits[0] = 1\r\n}\r\nfunction BigInt(e) {\r\n    if (typeof e == \"boolean\" && e == true)\r\n        this.digits = null ;\r\n    else\r\n        this.digits = ZERO_ARRAY.slice(0);\r\n    this.isNeg = false\r\n}\r\nfunction biFromDecimal(e) {\r\n    var t = e.charAt(0) == \"-\";\r\n    var n = t ? 1 : 0;\r\n    var r;\r\n    while (n < e.length && e.charAt(n) == \"0\")\r\n        ++n;\r\n    if (n == e.length)\r\n        r = new BigInt;\r\n    else {\r\n        var i = e.length - n;\r\n        var s = i % dpl10;\r\n        if (s == 0)\r\n            s = dpl10;\r\n        r = biFromNumber(Number(e.substr(n, s)));\r\n        n += s;\r\n        while (n < e.length) {\r\n            r = biAdd(biMultiply(r, biFromNumber(1e15)), biFromNumber(Number(e.substr(n, dpl10))));\r\n            n += dpl10\r\n        }\r\n        r.isNeg = t\r\n    }\r\n    return r\r\n}\r\nfunction biCopy(e) {\r\n    var t = new BigInt(true);\r\n    t.digits = e.digits.slice(0);\r\n    t.isNeg = e.isNeg;\r\n    return t\r\n}\r\nfunction biFromNumber(e) {\r\n    var t = new BigInt;\r\n    t.isNeg = e < 0;\r\n    e = Math.abs(e);\r\n    var n = 0;\r\n    while (e > 0) {\r\n        t.digits[n++] = e & maxDigitVal;\r\n        e >>= biRadixBits\r\n    }\r\n    return t\r\n}\r\nfunction reverseStr(e) {\r\n    var t = \"\";\r\n    for (var n = e.length - 1; n > -1; --n)\r\n        t += e.charAt(n);\r\n    return t\r\n}\r\nfunction biToString(e, t) {\r\n    var n = new BigInt;\r\n    n.digits[0] = t;\r\n    var r = biDivideModulo(e, n);\r\n    var i = hexatrigesimalToChar[r[1].digits[0]];\r\n    while (biCompare(r[0], bigZero) == 1) {\r\n        r = biDivideModulo(r[0], n);\r\n        digit = r[1].digits[0];\r\n        i += hexatrigesimalToChar[r[1].digits[0]]\r\n    }\r\n    return (e.isNeg ? \"-\" : \"\") + reverseStr(i)\r\n}\r\nfunction biToDecimal(e) {\r\n    var t = new BigInt;\r\n    t.digits[0] = 10;\r\n    var n = biDivideModulo(e, t);\r\n    var r = String(n[1].digits[0]);\r\n    while (biCompare(n[0], bigZero) == 1) {\r\n        n = biDivideModulo(n[0], t);\r\n        r += String(n[1].digits[0])\r\n    }\r\n    return (e.isNeg ? \"-\" : \"\") + reverseStr(r)\r\n}\r\nfunction digitToHex(e) {\r\n    var t = 15;\r\n    var n = \"\";\r\n    for (i = 0; i < 4; ++i) {\r\n        n += hexToChar[e & t];\r\n        e >>>= 4\r\n    }\r\n    return reverseStr(n)\r\n}\r\nfunction biToHex(e) {\r\n    var t = \"\";\r\n    var n = biHighIndex(e);\r\n    for (var r = biHighIndex(e); r > -1; --r)\r\n        t += digitToHex(e.digits[r]);\r\n    return t\r\n}\r\nfunction charToHex(e) {\r\n    var t = 48;\r\n    var n = t + 9;\r\n    var r = 97;\r\n    var i = r + 25;\r\n    var s = 65;\r\n    var o = 65 + 25;\r\n    var u;\r\n    if (e >= t && e <= n)\r\n        u = e - t;\r\n    else if (e >= s && e <= o)\r\n        u = 10 + e - s;\r\n    else if (e >= r && e <= i)\r\n        u = 10 + e - r;\r\n    else\r\n        u = 0;\r\n    return u\r\n}\r\nfunction hexToDigit(e) {\r\n    var t = 0;\r\n    var n = Math.min(e.length, 4);\r\n    for (var r = 0; r < n; ++r) {\r\n        t <<= 4;\r\n        t |= charToHex(e.charCodeAt(r))\r\n    }\r\n    return t\r\n}\r\nfunction biFromHex(e) {\r\n    var t = new BigInt;\r\n    var n = e.length;\r\n    for (var r = n, i = 0; r > 0; r -= 4,\r\n    ++i)\r\n        t.digits[i] = hexToDigit(e.substr(Math.max(r - 4, 0), Math.min(r, 4)));\r\n    return t\r\n}\r\nfunction biFromString(e, t) {\r\n    var n = e.charAt(0) == \"-\";\r\n    var r = n ? 1 : 0;\r\n    var i = new BigInt;\r\n    var s = new BigInt;\r\n    s.digits[0] = 1;\r\n    for (var o = e.length - 1; o >= r; o--) {\r\n        var u = e.charCodeAt(o);\r\n        var a = charToHex(u);\r\n        var f = biMultiplyDigit(s, a);\r\n        i = biAdd(i, f);\r\n        s = biMultiplyDigit(s, t)\r\n    }\r\n    i.isNeg = n;\r\n    return i\r\n}\r\nfunction biDump(e) {\r\n    return (e.isNeg ? \"-\" : \"\") + e.digits.join(\" \")\r\n}\r\nfunction biAdd(e, t) {\r\n    var n;\r\n    if (e.isNeg != t.isNeg) {\r\n        t.isNeg = !t.isNeg;\r\n        n = biSubtract(e, t);\r\n        t.isNeg = !t.isNeg\r\n    } else {\r\n        n = new BigInt;\r\n        var r = 0;\r\n        var i;\r\n        for (var s = 0; s < e.digits.length; ++s) {\r\n            i = e.digits[s] + t.digits[s] + r;\r\n            n.digits[s] = i & 65535;\r\n            r = Number(i >= biRadix)\r\n        }\r\n        n.isNeg = e.isNeg\r\n    }\r\n    return n\r\n}\r\nfunction biSubtract(e, t) {\r\n    var n;\r\n    if (e.isNeg != t.isNeg) {\r\n        t.isNeg = !t.isNeg;\r\n        n = biAdd(e, t);\r\n        t.isNeg = !t.isNeg\r\n    } else {\r\n        n = new BigInt;\r\n        var r, i;\r\n        i = 0;\r\n        for (var s = 0; s < e.digits.length; ++s) {\r\n            r = e.digits[s] - t.digits[s] + i;\r\n            n.digits[s] = r & 65535;\r\n            if (n.digits[s] < 0)\r\n                n.digits[s] += biRadix;\r\n            i = 0 - Number(r < 0)\r\n        }\r\n        if (i == -1) {\r\n            i = 0;\r\n            for (var s = 0; s < e.digits.length; ++s) {\r\n                r = 0 - n.digits[s] + i;\r\n                n.digits[s] = r & 65535;\r\n                if (n.digits[s] < 0)\r\n                    n.digits[s] += biRadix;\r\n                i = 0 - Number(r < 0)\r\n            }\r\n            n.isNeg = !e.isNeg\r\n        } else\r\n            n.isNeg = e.isNeg\r\n    }\r\n    return n\r\n}\r\nfunction biHighIndex(e) {\r\n    var t = e.digits.length - 1;\r\n    while (t > 0 && e.digits[t] == 0)\r\n        --t;\r\n    return t\r\n}\r\nfunction biNumBits(e) {\r\n    var t = biHighIndex(e);\r\n    var n = e.digits[t];\r\n    var r = (t + 1) * bitsPerDigit;\r\n    var i;\r\n    for (i = r; i > r - bitsPerDigit; --i) {\r\n        if ((n & 32768) != 0)\r\n            break;\r\n        n <<= 1\r\n    }\r\n    return i\r\n}\r\nfunction biMultiply(e, t) {\r\n    var n = new BigInt;\r\n    var r;\r\n    var i = biHighIndex(e);\r\n    var s = biHighIndex(t);\r\n    var o, u, a;\r\n    for (var f = 0; f <= s; ++f) {\r\n        r = 0;\r\n        a = f;\r\n        for (j = 0; j <= i; ++j,\r\n        ++a) {\r\n            u = n.digits[a] + e.digits[j] * t.digits[f] + r;\r\n            n.digits[a] = u & maxDigitVal;\r\n            r = u >>> biRadixBits\r\n        }\r\n        n.digits[f + i + 1] = r\r\n    }\r\n    n.isNeg = e.isNeg != t.isNeg;\r\n    return n\r\n}\r\nfunction biMultiplyDigit(e, t) {\r\n    var n, r, i;\r\n    result = new BigInt;\r\n    n = biHighIndex(e);\r\n    r = 0;\r\n    for (var s = 0; s <= n; ++s) {\r\n        i = result.digits[s] + e.digits[s] * t + r;\r\n        result.digits[s] = i & maxDigitVal;\r\n        r = i >>> biRadixBits\r\n    }\r\n    result.digits[1 + n] = r;\r\n    return result\r\n}\r\nfunction arrayCopy(e, t, n, r, i) {\r\n    var s = Math.min(t + i, e.length);\r\n    for (var o = t, u = r; o < s; ++o,\r\n    ++u)\r\n        n[u] = e[o]\r\n}\r\nfunction biShiftLeft(e, t) {\r\n    var n = Math.floor(t / bitsPerDigit);\r\n    var r = new BigInt;\r\n    arrayCopy(e.digits, 0, r.digits, n, r.digits.length - n);\r\n    var i = t % bitsPerDigit;\r\n    var s = bitsPerDigit - i;\r\n    for (var o = r.digits.length - 1, u = o - 1; o > 0; --o,\r\n    --u)\r\n        r.digits[o] = r.digits[o] << i & maxDigitVal | (r.digits[u] & highBitMasks[i]) >>> s;\r\n    r.digits[0] = r.digits[o] << i & maxDigitVal;\r\n    r.isNeg = e.isNeg;\r\n    return r\r\n}\r\nfunction biShiftRight(e, t) {\r\n    var n = Math.floor(t / bitsPerDigit);\r\n    var r = new BigInt;\r\n    arrayCopy(e.digits, n, r.digits, 0, e.digits.length - n);\r\n    var i = t % bitsPerDigit;\r\n    var s = bitsPerDigit - i;\r\n    for (var o = 0, u = o + 1; o < r.digits.length - 1; ++o,\r\n    ++u)\r\n        r.digits[o] = r.digits[o] >>> i | (r.digits[u] & lowBitMasks[i]) << s;\r\n    r.digits[r.digits.length - 1] >>>= i;\r\n    r.isNeg = e.isNeg;\r\n    return r\r\n}\r\nfunction biMultiplyByRadixPower(e, t) {\r\n    var n = new BigInt;\r\n    arrayCopy(e.digits, 0, n.digits, t, n.digits.length - t);\r\n    return n\r\n}\r\nfunction biDivideByRadixPower(e, t) {\r\n    var n = new BigInt;\r\n    arrayCopy(e.digits, t, n.digits, 0, n.digits.length - t);\r\n    return n\r\n}\r\nfunction biModuloByRadixPower(e, t) {\r\n    var n = new BigInt;\r\n    arrayCopy(e.digits, 0, n.digits, 0, t);\r\n    return n\r\n}\r\nfunction biCompare(e, t) {\r\n    if (e.isNeg != t.isNeg)\r\n        return 1 - 2 * Number(e.isNeg);\r\n    for (var n = e.digits.length - 1; n >= 0; --n)\r\n        if (e.digits[n] != t.digits[n])\r\n            if (e.isNeg)\r\n                return 1 - 2 * Number(e.digits[n] > t.digits[n]);\r\n            else\r\n                return 1 - 2 * Number(e.digits[n] < t.digits[n]);\r\n    return 0\r\n}\r\nfunction biDivideModulo(e, t) {\r\n    var n = biNumBits(e);\r\n    var r = biNumBits(t);\r\n    var i = t.isNeg;\r\n    var s, o;\r\n    if (n < r) {\r\n        if (e.isNeg) {\r\n            s = biCopy(bigOne);\r\n            s.isNeg = !t.isNeg;\r\n            e.isNeg = false;\r\n            t.isNeg = false;\r\n            o = biSubtract(t, e);\r\n            e.isNeg = true;\r\n            t.isNeg = i\r\n        } else {\r\n            s = new BigInt;\r\n            o = biCopy(e)\r\n        }\r\n        return new Array(s,o)\r\n    }\r\n    s = new BigInt;\r\n    o = e;\r\n    var u = Math.ceil(r / bitsPerDigit) - 1;\r\n    var a = 0;\r\n    while (t.digits[u] < biHalfRadix) {\r\n        t = biShiftLeft(t, 1);\r\n        ++a;\r\n        ++r;\r\n        u = Math.ceil(r / bitsPerDigit) - 1\r\n    }\r\n    o = biShiftLeft(o, a);\r\n    n += a;\r\n    var f = Math.ceil(n / bitsPerDigit) - 1;\r\n    var l = biMultiplyByRadixPower(t, f - u);\r\n    while (biCompare(o, l) != -1) {\r\n        ++s.digits[f - u];\r\n        o = biSubtract(o, l)\r\n    }\r\n    for (var c = f; c > u; --c) {\r\n        var h = c >= o.digits.length ? 0 : o.digits[c];\r\n        var p = c - 1 >= o.digits.length ? 0 : o.digits[c - 1];\r\n        var d = c - 2 >= o.digits.length ? 0 : o.digits[c - 2];\r\n        var v = u >= t.digits.length ? 0 : t.digits[u];\r\n        var m = u - 1 >= t.digits.length ? 0 : t.digits[u - 1];\r\n        if (h == v)\r\n            s.digits[c - u - 1] = maxDigitVal;\r\n        else\r\n            s.digits[c - u - 1] = Math.floor((h * biRadix + p) / v);\r\n        var g = s.digits[c - u - 1] * (v * biRadix + m);\r\n        var y = h * biRadixSquared + (p * biRadix + d);\r\n        while (g > y) {\r\n            --s.digits[c - u - 1];\r\n            g = s.digits[c - u - 1] * (v * biRadix | m);\r\n            y = h * biRadix * biRadix + (p * biRadix + d)\r\n        }\r\n        l = biMultiplyByRadixPower(t, c - u - 1);\r\n        o = biSubtract(o, biMultiplyDigit(l, s.digits[c - u - 1]));\r\n        if (o.isNeg) {\r\n            o = biAdd(o, l);\r\n            --s.digits[c - u - 1]\r\n        }\r\n    }\r\n    o = biShiftRight(o, a);\r\n    s.isNeg = e.isNeg != i;\r\n    if (e.isNeg) {\r\n        if (i)\r\n            s = biAdd(s, bigOne);\r\n        else\r\n            s = biSubtract(s, bigOne);\r\n        t = biShiftRight(t, a);\r\n        o = biSubtract(t, o)\r\n    }\r\n    if (o.digits[0] == 0 && biHighIndex(o) == 0)\r\n        o.isNeg = false;\r\n    return new Array(s,o)\r\n}\r\nfunction biDivide(e, t) {\r\n    return biDivideModulo(e, t)[0]\r\n}\r\nfunction biModulo(e, t) {\r\n    return biDivideModulo(e, t)[1]\r\n}\r\nfunction biMultiplyMod(e, t, n) {\r\n    return biModulo(biMultiply(e, t), n)\r\n}\r\nfunction biPow(e, t) {\r\n    var n = bigOne;\r\n    var r = e;\r\n    while (true) {\r\n        if ((t & 1) != 0)\r\n            n = biMultiply(n, r);\r\n        t >>= 1;\r\n        if (t == 0)\r\n            break;\r\n        r = biMultiply(r, r)\r\n    }\r\n    return n\r\n}\r\nfunction biPowMod(e, t, n) {\r\n    var r = bigOne;\r\n    var i = e;\r\n    var s = t;\r\n    while (true) {\r\n        if ((s.digits[0] & 1) != 0)\r\n            r = biMultiplyMod(r, i, n);\r\n        s = biShiftRight(s, 1);\r\n        if (s.digits[0] == 0 && biHighIndex(s) == 0)\r\n            break;\r\n        i = biMultiplyMod(i, i, n)\r\n    }\r\n    return r\r\n}\r\nfunction BarrettMu(e) {\r\n    this.modulus = biCopy(e);\r\n    this.k = biHighIndex(this.modulus) + 1;\r\n    var t = new BigInt;\r\n    t.digits[2 * this.k] = 1;\r\n    this.mu = biDivide(t, this.modulus);\r\n    this.bkplus1 = new BigInt;\r\n    this.bkplus1.digits[this.k + 1] = 1;\r\n    this.modulo = BarrettMu_modulo;\r\n    this.multiplyMod = BarrettMu_multiplyMod;\r\n    this.powMod = BarrettMu_powMod\r\n}\r\nfunction BarrettMu_modulo(e) {\r\n    var t = biDivideByRadixPower(e, this.k - 1);\r\n    var n = biMultiply(t, this.mu);\r\n    var r = biDivideByRadixPower(n, this.k + 1);\r\n    var i = biModuloByRadixPower(e, this.k + 1);\r\n    var s = biMultiply(r, this.modulus);\r\n    var o = biModuloByRadixPower(s, this.k + 1);\r\n    var u = biSubtract(i, o);\r\n    if (u.isNeg)\r\n        u = biAdd(u, this.bkplus1);\r\n    var a = biCompare(u, this.modulus) >= 0;\r\n    while (a) {\r\n        u = biSubtract(u, this.modulus);\r\n        a = biCompare(u, this.modulus) >= 0\r\n    }\r\n    return u\r\n}\r\nfunction BarrettMu_multiplyMod(e, t) {\r\n    var n = biMultiply(e, t);\r\n    return this.modulo(n)\r\n}\r\nfunction BarrettMu_powMod(e, t) {\r\n    var n = new BigInt;\r\n    n.digits[0] = 1;\r\n    while (true) {\r\n        if ((t.digits[0] & 1) != 0)\r\n            n = this.multiplyMod(n, e);\r\n        t = biShiftRight(t, 1);\r\n        if (t.digits[0] == 0 && biHighIndex(t) == 0)\r\n            break;\r\n        e = this.multiplyMod(e, e)\r\n    }\r\n    return n\r\n}\r\nvar biRadixBase = 2;\r\nvar biRadixBits = 16;\r\nvar bitsPerDigit = biRadixBits;\r\nvar biRadix = 1 << 16;\r\nvar biHalfRadix = biRadix >>> 1;\r\nvar biRadixSquared = biRadix * biRadix;\r\nvar maxDigitVal = biRadix - 1;\r\nvar maxInteger = 9999999999999998;\r\nvar maxDigits;\r\nvar ZERO_ARRAY;\r\nvar bigZero, bigOne;\r\nvar dpl10 = 15;\r\nvar highBitMasks = new Array(0,32768,49152,57344,61440,63488,64512,65024,65280,65408,65472,65504,65520,65528,65532,65534,65535);\r\nvar hexatrigesimalToChar = new Array(\"0\",\"1\",\"2\",\"3\",\"4\",\"5\",\"6\",\"7\",\"8\",\"9\",\"a\",\"b\",\"c\",\"d\",\"e\",\"f\",\"g\",\"h\",\"i\",\"j\",\"k\",\"l\",\"m\",\"n\",\"o\",\"p\",\"q\",\"r\",\"s\",\"t\",\"u\",\"v\",\"w\",\"x\",\"y\",\"z\");\r\nvar hexToChar = new Array(\"0\",\"1\",\"2\",\"3\",\"4\",\"5\",\"6\",\"7\",\"8\",\"9\",\"a\",\"b\",\"c\",\"d\",\"e\",\"f\");\r\nvar lowBitMasks = new Array(0,1,3,7,15,31,63,127,255,511,1023,2047,4095,8191,16383,32767,65535);\r\n</script>\n\n\n\n</head>\n\n<body>\n\n\n\n</body>\n\n</html> \n\n";
		array[4] = text3;
		string text4 = string.Concat(array);
		WebBrowser webBrowser = new WebBrowser();
		string urlString = "about:blank";
		webBrowser.Navigate(urlString);
		webBrowser.Document.Write(text4);
		HtmlDocument document = webBrowser.Document;
		string scriptName = "encryptUsingJS";
		return document.InvokeScript(scriptName, new object[2] { null, false }).ToString();
	}

	public static string ICICI_Encoding(string pass, string Key)
	{
		string[] array = new string[5];
		string text = "<html>\n<head>\n\n<script type=\"text/javascript\">\n\tfunction encryptUsingJS(e, t, n) {\r\nvar e1\r\n;    var i = function(i) {\r\n        var r;\r\n        r ='";
		array[0] = text;
		array[1] = pass;
		string text2 = "';\r\n        for (var a = r.length, o = 0; a > o; o++) {\r\n            var s = r[o];\r\n                var d = r\r\n                  , u = 'ACCESS_CODE'\r\n                  , l = !0;\r\n                if (-1 != u.indexOf(\"ACCESS_CODE\")) {\r\n                    var p = d.length;\r\n                    p > 128 && (l = !1)\r\n                }\r\n                e1 = encrypt(\"password=\" + d + \"_SALT_COMPONENT_=\" + Math.random(), i);\r\n        }\r\n    }\r\n    ;\r\n    getPublicKeyFromServer(i, e)\r\n   return e1;\r\n}\r\nfunction getPublicKeyFromServer(e, t) {\r\n    var n = function(e, t, n) {\r\n        setMaxDigits(parseInt(n, 10)),\r\n        this.e = biFromHex(e),\r\n        this.m = biFromHex(t),\r\n        this.chunkSize = 2 * biHighIndex(this.m),\r\n        this.radix = 16,\r\n        this.barrett = new BarrettMu(this.m)\r\n    }\r\n      , i = '";
		array[2] = text2;
		array[3] = Key;
		string text3 = "'\r\n      , r = i.split(\",\")[0]\r\n      , a = i.split(\",\")[1]\r\n      , o = i.split(\",\")[2]\r\n      , s = new n(r,a,o);\r\n    e(s)\r\n}\r\n\n\n    jCryption1 = function(t, n) {\r\n        var r = this;\r\n        r.$el = e(t);\r\n        r.el = t;\r\n        r.$el.data(\"jCryption\", r);\r\n        r.init = function() {\r\n            r.options = e.extend({}, e.jCryption.defaultOptions, n);\r\n            $encryptedElement = e(\"<input />\", {\r\n                type: \"hidden\",\r\n                name: r.options.postVariable\r\n            });\r\n            if (r.options.submitElement !== false)\r\n                var t = r.options.submitElement;\r\n            else\r\n                var t = r.$el.find(\":input:submit\");\r\n            t.bind(r.options.submitEvent, function() {\r\n                e(this).attr(\"disabled\", true);\r\n                if (r.options.beforeEncryption())\r\n                    e.jCryption.getKeys(r.options.getKeysURL, function(t) {\r\n                        e.jCryption.encrypt(r.$el.serialize(), t, function(t) {\r\n                            console.log(t);\r\n                            $encryptedElement.val(t);\r\n                            e(r.$el).find(\":input\").attr(\"disabled\", true).end().append($encryptedElement).submit()\r\n                        })\r\n                    });\r\n                return false\r\n            })\r\n        }\r\n        ;\r\n        r.init()\r\n    }\r\n    ;\r\n    getKeys = function(t, n) {\r\n        var r = function(e, t, n) {\r\n            setMaxDigits(parseInt(n, 10));\r\n            this.e = biFromHex(e);\r\n            this.m = biFromHex(t);\r\n            this.chunkSize = 2 * biHighIndex(this.m);\r\n            this.radix = 16;\r\n            this.barrett = new BarrettMu(this.m)\r\n        }\r\n        ;\r\n        e.getJSON(t, function(t) {\r\n            keys = new r(t.e,t.n,t.maxdigits);\r\n            if (e.isFunction(n))\r\n                n.call(this, keys)\r\n        })\r\n    }\r\n    ;\r\n    encrypt = function(t, n) {\r\n        function h(t) {\r\n            function f() {\r\n                u = new BigInt;\r\n                o = 0;\r\n                for (var l = s; l < s + n.chunkSize; ++o) {\r\n                    u.digits[o] = t[l++];\r\n                    u.digits[o] += t[l++] << 8\r\n                }\r\n                var c = n.barrett.powMod(u, n.e);\r\n                var h = n.radix == 16 ? biToHex(c) : biToString(c, n.radix);\r\n            return h;\r\n            }\r\n            var s = 0;\r\n            var o, u;\r\n            var a = \"\";\r\n            var j=f()\r\nreturn j;\r\n        }\r\n        var s = 0;\r\n        for (var o = 0; o < t.length; o++)\r\n            s += t.charCodeAt(o);\r\n        var u = \"0123456789abcdef\";\r\n        var a = \"\";\r\n        a += u.charAt((s & 240) >> 4) + u.charAt(s & 15);\r\n        var f = a + t;\r\n        var l = [];\r\n        var c = 0;\r\n        while (c < f.length) {\r\n            l[c] = f.charCodeAt(c);\r\n            c++\r\n        }\r\n        while (l.length % n.chunkSize !== 0)\r\n            l[c++] = 0;\r\n        var y = h(l)\r\nreturn y;\r\n    }\r\n    ;\r\n    defaultOptions = {\r\n        submitElement: false,\r\n        submitEvent: \"click\",\r\n        getKeysURL: \"/jsp/jc.jsp?generateKeypair=true\",\r\n        beforeEncryption: function() {\r\n            return true\r\n        },\r\n        postVariable: \"jCryption\"\r\n    };\r\n    jCryption2 = function(t) {\r\n        return this.each(function() {\r\n            new jCryption1(this,t)\r\n        })\r\n    }\r\n\n\n\nfunction setMaxDigits(e) {\r\n    maxDigits = e;\r\n    ZERO_ARRAY = new Array(maxDigits);\r\n    for (var t = 0; t < ZERO_ARRAY.length; t++)\r\n        ZERO_ARRAY[t] = 0;\r\n    bigZero = new BigInt;\r\n    bigOne = new BigInt;\r\n    bigOne.digits[0] = 1\r\n}\r\nfunction BigInt(e) {\r\n    if (typeof e == \"boolean\" && e == true)\r\n        this.digits = null ;\r\n    else\r\n        this.digits = ZERO_ARRAY.slice(0);\r\n    this.isNeg = false\r\n}\r\nfunction biFromDecimal(e) {\r\n    var t = e.charAt(0) == \"-\";\r\n    var n = t ? 1 : 0;\r\n    var r;\r\n    while (n < e.length && e.charAt(n) == \"0\")\r\n        ++n;\r\n    if (n == e.length)\r\n        r = new BigInt;\r\n    else {\r\n        var i = e.length - n;\r\n        var s = i % dpl10;\r\n        if (s == 0)\r\n            s = dpl10;\r\n        r = biFromNumber(Number(e.substr(n, s)));\r\n        n += s;\r\n        while (n < e.length) {\r\n            r = biAdd(biMultiply(r, biFromNumber(1e15)), biFromNumber(Number(e.substr(n, dpl10))));\r\n            n += dpl10\r\n        }\r\n        r.isNeg = t\r\n    }\r\n    return r\r\n}\r\nfunction biCopy(e) {\r\n    var t = new BigInt(true);\r\n    t.digits = e.digits.slice(0);\r\n    t.isNeg = e.isNeg;\r\n    return t\r\n}\r\nfunction biFromNumber(e) {\r\n    var t = new BigInt;\r\n    t.isNeg = e < 0;\r\n    e = Math.abs(e);\r\n    var n = 0;\r\n    while (e > 0) {\r\n        t.digits[n++] = e & maxDigitVal;\r\n        e >>= biRadixBits\r\n    }\r\n    return t\r\n}\r\nfunction reverseStr(e) {\r\n    var t = \"\";\r\n    for (var n = e.length - 1; n > -1; --n)\r\n        t += e.charAt(n);\r\n    return t\r\n}\r\nfunction biToString(e, t) {\r\n    var n = new BigInt;\r\n    n.digits[0] = t;\r\n    var r = biDivideModulo(e, n);\r\n    var i = hexatrigesimalToChar[r[1].digits[0]];\r\n    while (biCompare(r[0], bigZero) == 1) {\r\n        r = biDivideModulo(r[0], n);\r\n        digit = r[1].digits[0];\r\n        i += hexatrigesimalToChar[r[1].digits[0]]\r\n    }\r\n    return (e.isNeg ? \"-\" : \"\") + reverseStr(i)\r\n}\r\nfunction biToDecimal(e) {\r\n    var t = new BigInt;\r\n    t.digits[0] = 10;\r\n    var n = biDivideModulo(e, t);\r\n    var r = String(n[1].digits[0]);\r\n    while (biCompare(n[0], bigZero) == 1) {\r\n        n = biDivideModulo(n[0], t);\r\n        r += String(n[1].digits[0])\r\n    }\r\n    return (e.isNeg ? \"-\" : \"\") + reverseStr(r)\r\n}\r\nfunction digitToHex(e) {\r\n    var t = 15;\r\n    var n = \"\";\r\n    for (i = 0; i < 4; ++i) {\r\n        n += hexToChar[e & t];\r\n        e >>>= 4\r\n    }\r\n    return reverseStr(n)\r\n}\r\nfunction biToHex(e) {\r\n    var t = \"\";\r\n    var n = biHighIndex(e);\r\n    for (var r = biHighIndex(e); r > -1; --r)\r\n        t += digitToHex(e.digits[r]);\r\n    return t\r\n}\r\nfunction charToHex(e) {\r\n    var t = 48;\r\n    var n = t + 9;\r\n    var r = 97;\r\n    var i = r + 25;\r\n    var s = 65;\r\n    var o = 65 + 25;\r\n    var u;\r\n    if (e >= t && e <= n)\r\n        u = e - t;\r\n    else if (e >= s && e <= o)\r\n        u = 10 + e - s;\r\n    else if (e >= r && e <= i)\r\n        u = 10 + e - r;\r\n    else\r\n        u = 0;\r\n    return u\r\n}\r\nfunction hexToDigit(e) {\r\n    var t = 0;\r\n    var n = Math.min(e.length, 4);\r\n    for (var r = 0; r < n; ++r) {\r\n        t <<= 4;\r\n        t |= charToHex(e.charCodeAt(r))\r\n    }\r\n    return t\r\n}\r\nfunction biFromHex(e) {\r\n    var t = new BigInt;\r\n    var n = e.length;\r\n    for (var r = n, i = 0; r > 0; r -= 4,\r\n    ++i)\r\n        t.digits[i] = hexToDigit(e.substr(Math.max(r - 4, 0), Math.min(r, 4)));\r\n    return t\r\n}\r\nfunction biFromString(e, t) {\r\n    var n = e.charAt(0) == \"-\";\r\n    var r = n ? 1 : 0;\r\n    var i = new BigInt;\r\n    var s = new BigInt;\r\n    s.digits[0] = 1;\r\n    for (var o = e.length - 1; o >= r; o--) {\r\n        var u = e.charCodeAt(o);\r\n        var a = charToHex(u);\r\n        var f = biMultiplyDigit(s, a);\r\n        i = biAdd(i, f);\r\n        s = biMultiplyDigit(s, t)\r\n    }\r\n    i.isNeg = n;\r\n    return i\r\n}\r\nfunction biDump(e) {\r\n    return (e.isNeg ? \"-\" : \"\") + e.digits.join(\" \")\r\n}\r\nfunction biAdd(e, t) {\r\n    var n;\r\n    if (e.isNeg != t.isNeg) {\r\n        t.isNeg = !t.isNeg;\r\n        n = biSubtract(e, t);\r\n        t.isNeg = !t.isNeg\r\n    } else {\r\n        n = new BigInt;\r\n        var r = 0;\r\n        var i;\r\n        for (var s = 0; s < e.digits.length; ++s) {\r\n            i = e.digits[s] + t.digits[s] + r;\r\n            n.digits[s] = i & 65535;\r\n            r = Number(i >= biRadix)\r\n        }\r\n        n.isNeg = e.isNeg\r\n    }\r\n    return n\r\n}\r\nfunction biSubtract(e, t) {\r\n    var n;\r\n    if (e.isNeg != t.isNeg) {\r\n        t.isNeg = !t.isNeg;\r\n        n = biAdd(e, t);\r\n        t.isNeg = !t.isNeg\r\n    } else {\r\n        n = new BigInt;\r\n        var r, i;\r\n        i = 0;\r\n        for (var s = 0; s < e.digits.length; ++s) {\r\n            r = e.digits[s] - t.digits[s] + i;\r\n            n.digits[s] = r & 65535;\r\n            if (n.digits[s] < 0)\r\n                n.digits[s] += biRadix;\r\n            i = 0 - Number(r < 0)\r\n        }\r\n        if (i == -1) {\r\n            i = 0;\r\n            for (var s = 0; s < e.digits.length; ++s) {\r\n                r = 0 - n.digits[s] + i;\r\n                n.digits[s] = r & 65535;\r\n                if (n.digits[s] < 0)\r\n                    n.digits[s] += biRadix;\r\n                i = 0 - Number(r < 0)\r\n            }\r\n            n.isNeg = !e.isNeg\r\n        } else\r\n            n.isNeg = e.isNeg\r\n    }\r\n    return n\r\n}\r\nfunction biHighIndex(e) {\r\n    var t = e.digits.length - 1;\r\n    while (t > 0 && e.digits[t] == 0)\r\n        --t;\r\n    return t\r\n}\r\nfunction biNumBits(e) {\r\n    var t = biHighIndex(e);\r\n    var n = e.digits[t];\r\n    var r = (t + 1) * bitsPerDigit;\r\n    var i;\r\n    for (i = r; i > r - bitsPerDigit; --i) {\r\n        if ((n & 32768) != 0)\r\n            break;\r\n        n <<= 1\r\n    }\r\n    return i\r\n}\r\nfunction biMultiply(e, t) {\r\n    var n = new BigInt;\r\n    var r;\r\n    var i = biHighIndex(e);\r\n    var s = biHighIndex(t);\r\n    var o, u, a;\r\n    for (var f = 0; f <= s; ++f) {\r\n        r = 0;\r\n        a = f;\r\n        for (j = 0; j <= i; ++j,\r\n        ++a) {\r\n            u = n.digits[a] + e.digits[j] * t.digits[f] + r;\r\n            n.digits[a] = u & maxDigitVal;\r\n            r = u >>> biRadixBits\r\n        }\r\n        n.digits[f + i + 1] = r\r\n    }\r\n    n.isNeg = e.isNeg != t.isNeg;\r\n    return n\r\n}\r\nfunction biMultiplyDigit(e, t) {\r\n    var n, r, i;\r\n    result = new BigInt;\r\n    n = biHighIndex(e);\r\n    r = 0;\r\n    for (var s = 0; s <= n; ++s) {\r\n        i = result.digits[s] + e.digits[s] * t + r;\r\n        result.digits[s] = i & maxDigitVal;\r\n        r = i >>> biRadixBits\r\n    }\r\n    result.digits[1 + n] = r;\r\n    return result\r\n}\r\nfunction arrayCopy(e, t, n, r, i) {\r\n    var s = Math.min(t + i, e.length);\r\n    for (var o = t, u = r; o < s; ++o,\r\n    ++u)\r\n        n[u] = e[o]\r\n}\r\nfunction biShiftLeft(e, t) {\r\n    var n = Math.floor(t / bitsPerDigit);\r\n    var r = new BigInt;\r\n    arrayCopy(e.digits, 0, r.digits, n, r.digits.length - n);\r\n    var i = t % bitsPerDigit;\r\n    var s = bitsPerDigit - i;\r\n    for (var o = r.digits.length - 1, u = o - 1; o > 0; --o,\r\n    --u)\r\n        r.digits[o] = r.digits[o] << i & maxDigitVal | (r.digits[u] & highBitMasks[i]) >>> s;\r\n    r.digits[0] = r.digits[o] << i & maxDigitVal;\r\n    r.isNeg = e.isNeg;\r\n    return r\r\n}\r\nfunction biShiftRight(e, t) {\r\n    var n = Math.floor(t / bitsPerDigit);\r\n    var r = new BigInt;\r\n    arrayCopy(e.digits, n, r.digits, 0, e.digits.length - n);\r\n    var i = t % bitsPerDigit;\r\n    var s = bitsPerDigit - i;\r\n    for (var o = 0, u = o + 1; o < r.digits.length - 1; ++o,\r\n    ++u)\r\n        r.digits[o] = r.digits[o] >>> i | (r.digits[u] & lowBitMasks[i]) << s;\r\n    r.digits[r.digits.length - 1] >>>= i;\r\n    r.isNeg = e.isNeg;\r\n    return r\r\n}\r\nfunction biMultiplyByRadixPower(e, t) {\r\n    var n = new BigInt;\r\n    arrayCopy(e.digits, 0, n.digits, t, n.digits.length - t);\r\n    return n\r\n}\r\nfunction biDivideByRadixPower(e, t) {\r\n    var n = new BigInt;\r\n    arrayCopy(e.digits, t, n.digits, 0, n.digits.length - t);\r\n    return n\r\n}\r\nfunction biModuloByRadixPower(e, t) {\r\n    var n = new BigInt;\r\n    arrayCopy(e.digits, 0, n.digits, 0, t);\r\n    return n\r\n}\r\nfunction biCompare(e, t) {\r\n    if (e.isNeg != t.isNeg)\r\n        return 1 - 2 * Number(e.isNeg);\r\n    for (var n = e.digits.length - 1; n >= 0; --n)\r\n        if (e.digits[n] != t.digits[n])\r\n            if (e.isNeg)\r\n                return 1 - 2 * Number(e.digits[n] > t.digits[n]);\r\n            else\r\n                return 1 - 2 * Number(e.digits[n] < t.digits[n]);\r\n    return 0\r\n}\r\nfunction biDivideModulo(e, t) {\r\n    var n = biNumBits(e);\r\n    var r = biNumBits(t);\r\n    var i = t.isNeg;\r\n    var s, o;\r\n    if (n < r) {\r\n        if (e.isNeg) {\r\n            s = biCopy(bigOne);\r\n            s.isNeg = !t.isNeg;\r\n            e.isNeg = false;\r\n            t.isNeg = false;\r\n            o = biSubtract(t, e);\r\n            e.isNeg = true;\r\n            t.isNeg = i\r\n        } else {\r\n            s = new BigInt;\r\n            o = biCopy(e)\r\n        }\r\n        return new Array(s,o)\r\n    }\r\n    s = new BigInt;\r\n    o = e;\r\n    var u = Math.ceil(r / bitsPerDigit) - 1;\r\n    var a = 0;\r\n    while (t.digits[u] < biHalfRadix) {\r\n        t = biShiftLeft(t, 1);\r\n        ++a;\r\n        ++r;\r\n        u = Math.ceil(r / bitsPerDigit) - 1\r\n    }\r\n    o = biShiftLeft(o, a);\r\n    n += a;\r\n    var f = Math.ceil(n / bitsPerDigit) - 1;\r\n    var l = biMultiplyByRadixPower(t, f - u);\r\n    while (biCompare(o, l) != -1) {\r\n        ++s.digits[f - u];\r\n        o = biSubtract(o, l)\r\n    }\r\n    for (var c = f; c > u; --c) {\r\n        var h = c >= o.digits.length ? 0 : o.digits[c];\r\n        var p = c - 1 >= o.digits.length ? 0 : o.digits[c - 1];\r\n        var d = c - 2 >= o.digits.length ? 0 : o.digits[c - 2];\r\n        var v = u >= t.digits.length ? 0 : t.digits[u];\r\n        var m = u - 1 >= t.digits.length ? 0 : t.digits[u - 1];\r\n        if (h == v)\r\n            s.digits[c - u - 1] = maxDigitVal;\r\n        else\r\n            s.digits[c - u - 1] = Math.floor((h * biRadix + p) / v);\r\n        var g = s.digits[c - u - 1] * (v * biRadix + m);\r\n        var y = h * biRadixSquared + (p * biRadix + d);\r\n        while (g > y) {\r\n            --s.digits[c - u - 1];\r\n            g = s.digits[c - u - 1] * (v * biRadix | m);\r\n            y = h * biRadix * biRadix + (p * biRadix + d)\r\n        }\r\n        l = biMultiplyByRadixPower(t, c - u - 1);\r\n        o = biSubtract(o, biMultiplyDigit(l, s.digits[c - u - 1]));\r\n        if (o.isNeg) {\r\n            o = biAdd(o, l);\r\n            --s.digits[c - u - 1]\r\n        }\r\n    }\r\n    o = biShiftRight(o, a);\r\n    s.isNeg = e.isNeg != i;\r\n    if (e.isNeg) {\r\n        if (i)\r\n            s = biAdd(s, bigOne);\r\n        else\r\n            s = biSubtract(s, bigOne);\r\n        t = biShiftRight(t, a);\r\n        o = biSubtract(t, o)\r\n    }\r\n    if (o.digits[0] == 0 && biHighIndex(o) == 0)\r\n        o.isNeg = false;\r\n    return new Array(s,o)\r\n}\r\nfunction biDivide(e, t) {\r\n    return biDivideModulo(e, t)[0]\r\n}\r\nfunction biModulo(e, t) {\r\n    return biDivideModulo(e, t)[1]\r\n}\r\nfunction biMultiplyMod(e, t, n) {\r\n    return biModulo(biMultiply(e, t), n)\r\n}\r\nfunction biPow(e, t) {\r\n    var n = bigOne;\r\n    var r = e;\r\n    while (true) {\r\n        if ((t & 1) != 0)\r\n            n = biMultiply(n, r);\r\n        t >>= 1;\r\n        if (t == 0)\r\n            break;\r\n        r = biMultiply(r, r)\r\n    }\r\n    return n\r\n}\r\nfunction biPowMod(e, t, n) {\r\n    var r = bigOne;\r\n    var i = e;\r\n    var s = t;\r\n    while (true) {\r\n        if ((s.digits[0] & 1) != 0)\r\n            r = biMultiplyMod(r, i, n);\r\n        s = biShiftRight(s, 1);\r\n        if (s.digits[0] == 0 && biHighIndex(s) == 0)\r\n            break;\r\n        i = biMultiplyMod(i, i, n)\r\n    }\r\n    return r\r\n}\r\nfunction BarrettMu(e) {\r\n    this.modulus = biCopy(e);\r\n    this.k = biHighIndex(this.modulus) + 1;\r\n    var t = new BigInt;\r\n    t.digits[2 * this.k] = 1;\r\n    this.mu = biDivide(t, this.modulus);\r\n    this.bkplus1 = new BigInt;\r\n    this.bkplus1.digits[this.k + 1] = 1;\r\n    this.modulo = BarrettMu_modulo;\r\n    this.multiplyMod = BarrettMu_multiplyMod;\r\n    this.powMod = BarrettMu_powMod\r\n}\r\nfunction BarrettMu_modulo(e) {\r\n    var t = biDivideByRadixPower(e, this.k - 1);\r\n    var n = biMultiply(t, this.mu);\r\n    var r = biDivideByRadixPower(n, this.k + 1);\r\n    var i = biModuloByRadixPower(e, this.k + 1);\r\n    var s = biMultiply(r, this.modulus);\r\n    var o = biModuloByRadixPower(s, this.k + 1);\r\n    var u = biSubtract(i, o);\r\n    if (u.isNeg)\r\n        u = biAdd(u, this.bkplus1);\r\n    var a = biCompare(u, this.modulus) >= 0;\r\n    while (a) {\r\n        u = biSubtract(u, this.modulus);\r\n        a = biCompare(u, this.modulus) >= 0\r\n    }\r\n    return u\r\n}\r\nfunction BarrettMu_multiplyMod(e, t) {\r\n    var n = biMultiply(e, t);\r\n    return this.modulo(n)\r\n}\r\nfunction BarrettMu_powMod(e, t) {\r\n    var n = new BigInt;\r\n    n.digits[0] = 1;\r\n    while (true) {\r\n        if ((t.digits[0] & 1) != 0)\r\n            n = this.multiplyMod(n, e);\r\n        t = biShiftRight(t, 1);\r\n        if (t.digits[0] == 0 && biHighIndex(t) == 0)\r\n            break;\r\n        e = this.multiplyMod(e, e)\r\n    }\r\n    return n\r\n}\r\nvar biRadixBase = 2;\r\nvar biRadixBits = 16;\r\nvar bitsPerDigit = biRadixBits;\r\nvar biRadix = 1 << 16;\r\nvar biHalfRadix = biRadix >>> 1;\r\nvar biRadixSquared = biRadix * biRadix;\r\nvar maxDigitVal = biRadix - 1;\r\nvar maxInteger = 9999999999999998;\r\nvar maxDigits;\r\nvar ZERO_ARRAY;\r\nvar bigZero, bigOne;\r\nvar dpl10 = 15;\r\nvar highBitMasks = new Array(0,32768,49152,57344,61440,63488,64512,65024,65280,65408,65472,65504,65520,65528,65532,65534,65535);\r\nvar hexatrigesimalToChar = new Array(\"0\",\"1\",\"2\",\"3\",\"4\",\"5\",\"6\",\"7\",\"8\",\"9\",\"a\",\"b\",\"c\",\"d\",\"e\",\"f\",\"g\",\"h\",\"i\",\"j\",\"k\",\"l\",\"m\",\"n\",\"o\",\"p\",\"q\",\"r\",\"s\",\"t\",\"u\",\"v\",\"w\",\"x\",\"y\",\"z\");\r\nvar hexToChar = new Array(\"0\",\"1\",\"2\",\"3\",\"4\",\"5\",\"6\",\"7\",\"8\",\"9\",\"a\",\"b\",\"c\",\"d\",\"e\",\"f\");\r\nvar lowBitMasks = new Array(0,1,3,7,15,31,63,127,255,511,1023,2047,4095,8191,16383,32767,65535);\r\n</script>\n\n\n\n</head>\n\n<body>\n\n\n\n</body>\n\n</html> \n\n";
		array[4] = text3;
		string text4 = string.Concat(array);
		WebBrowser webBrowser = new WebBrowser();
		string urlString = "about:blank";
		webBrowser.Navigate(urlString);
		webBrowser.Document.Write(text4);
		HtmlDocument document = webBrowser.Document;
		string scriptName = "encryptUsingJS";
		return document.InvokeScript(scriptName, new object[2] { null, false }).ToString();
	}

	public static string UNION_Encoding(string pass, string Key)
	{
		string[] array = new string[5];
		string text = "<html>\n<head>\n\n<script type=\"text/javascript\">\n\tfunction encryptUsingJS(e, t, n) {\r\nvar e1\r\n;    var i = function(i) {\r\n        var r;\r\n        r ='";
		array[0] = text;
		array[1] = pass;
		string text2 = "';\r\n        for (var a = r.length, o = 0; a > o; o++) {\r\n            var s = r[o];\r\n                var d = r\r\n                  , u = 'ACCESS_CODE'\r\n                  , l = !0;\r\n                if (-1 != u.indexOf(\"ACCESS_CODE\")) {\r\n                    var p = d.length;\r\n                    p > 128 && (l = !1)\r\n                }\r\n                e1 = encrypt(\"password=\" + d + \"_SALT_COMPONENT_=\" + Math.random(), i);\r\n        }\r\n    }\r\n    ;\r\n    getPublicKeyFromServer(i, e)\r\n   return e1;\r\n}\r\nfunction getPublicKeyFromServer(e, t) {\r\n    var n = function(e, t, n) {\r\n        setMaxDigits(parseInt(n, 10)),\r\n        this.e = biFromHex(e),\r\n        this.m = biFromHex(t),\r\n        this.chunkSize = 2 * biHighIndex(this.m),\r\n        this.radix = 16,\r\n        this.barrett = new BarrettMu(this.m)\r\n    }\r\n      , i = '";
		array[2] = text2;
		array[3] = Key;
		string text3 = "'\r\n      , r = i.split(\",\")[0]\r\n      , a = i.split(\",\")[1]\r\n      , o = i.split(\",\")[2]\r\n      , s = new n(r,a,o);\r\n    e(s)\r\n}\r\n\n\n    jCryption1 = function(t, n) {\r\n        var r = this;\r\n        r.$el = e(t);\r\n        r.el = t;\r\n        r.$el.data(\"jCryption\", r);\r\n        r.init = function() {\r\n            r.options = e.extend({}, e.jCryption.defaultOptions, n);\r\n            $encryptedElement = e(\"<input />\", {\r\n                type: \"hidden\",\r\n                name: r.options.postVariable\r\n            });\r\n            if (r.options.submitElement !== false)\r\n                var t = r.options.submitElement;\r\n            else\r\n                var t = r.$el.find(\":input:submit\");\r\n            t.bind(r.options.submitEvent, function() {\r\n                e(this).attr(\"disabled\", true);\r\n                if (r.options.beforeEncryption())\r\n                    e.jCryption.getKeys(r.options.getKeysURL, function(t) {\r\n                        e.jCryption.encrypt(r.$el.serialize(), t, function(t) {\r\n                            console.log(t);\r\n                            $encryptedElement.val(t);\r\n                            e(r.$el).find(\":input\").attr(\"disabled\", true).end().append($encryptedElement).submit()\r\n                        })\r\n                    });\r\n                return false\r\n            })\r\n        }\r\n        ;\r\n        r.init()\r\n    }\r\n    ;\r\n    getKeys = function(t, n) {\r\n        var r = function(e, t, n) {\r\n            setMaxDigits(parseInt(n, 10));\r\n            this.e = biFromHex(e);\r\n            this.m = biFromHex(t);\r\n            this.chunkSize = 2 * biHighIndex(this.m);\r\n            this.radix = 16;\r\n            this.barrett = new BarrettMu(this.m)\r\n        }\r\n        ;\r\n        e.getJSON(t, function(t) {\r\n            keys = new r(t.e,t.n,t.maxdigits);\r\n            if (e.isFunction(n))\r\n                n.call(this, keys)\r\n        })\r\n    }\r\n    ;\r\n    encrypt = function(t, n) {\r\n        function h(t) {\r\n            function f() {\r\n                u = new BigInt;\r\n                o = 0;\r\n                for (var l = s; l < s + n.chunkSize; ++o) {\r\n                    u.digits[o] = t[l++];\r\n                    u.digits[o] += t[l++] << 8\r\n                }\r\n                var c = n.barrett.powMod(u, n.e);\r\n                var h = n.radix == 16 ? biToHex(c) : biToString(c, n.radix);\r\n            return h;\r\n            }\r\n            var s = 0;\r\n            var o, u;\r\n            var a = \"\";\r\n            var j=f()\r\nreturn j;\r\n        }\r\n        var s = 0;\r\n        for (var o = 0; o < t.length; o++)\r\n            s += t.charCodeAt(o);\r\n        var u = \"0123456789abcdef\";\r\n        var a = \"\";\r\n        a += u.charAt((s & 240) >> 4) + u.charAt(s & 15);\r\n        var f = a + t;\r\n        var l = [];\r\n        var c = 0;\r\n        while (c < f.length) {\r\n            l[c] = f.charCodeAt(c);\r\n            c++\r\n        }\r\n        while (l.length % n.chunkSize !== 0)\r\n            l[c++] = 0;\r\n        var y = h(l)\r\nreturn y;\r\n    }\r\n    ;\r\n    defaultOptions = {\r\n        submitElement: false,\r\n        submitEvent: \"click\",\r\n        getKeysURL: \"/jsp/jc.jsp?generateKeypair=true\",\r\n        beforeEncryption: function() {\r\n            return true\r\n        },\r\n        postVariable: \"jCryption\"\r\n    };\r\n    jCryption2 = function(t) {\r\n        return this.each(function() {\r\n            new jCryption1(this,t)\r\n        })\r\n    }\r\n\n\n\nfunction setMaxDigits(e) {\r\n    maxDigits = e;\r\n    ZERO_ARRAY = new Array(maxDigits);\r\n    for (var t = 0; t < ZERO_ARRAY.length; t++)\r\n        ZERO_ARRAY[t] = 0;\r\n    bigZero = new BigInt;\r\n    bigOne = new BigInt;\r\n    bigOne.digits[0] = 1\r\n}\r\nfunction BigInt(e) {\r\n    if (typeof e == \"boolean\" && e == true)\r\n        this.digits = null ;\r\n    else\r\n        this.digits = ZERO_ARRAY.slice(0);\r\n    this.isNeg = false\r\n}\r\nfunction biFromDecimal(e) {\r\n    var t = e.charAt(0) == \"-\";\r\n    var n = t ? 1 : 0;\r\n    var r;\r\n    while (n < e.length && e.charAt(n) == \"0\")\r\n        ++n;\r\n    if (n == e.length)\r\n        r = new BigInt;\r\n    else {\r\n        var i = e.length - n;\r\n        var s = i % dpl10;\r\n        if (s == 0)\r\n            s = dpl10;\r\n        r = biFromNumber(Number(e.substr(n, s)));\r\n        n += s;\r\n        while (n < e.length) {\r\n            r = biAdd(biMultiply(r, biFromNumber(1e15)), biFromNumber(Number(e.substr(n, dpl10))));\r\n            n += dpl10\r\n        }\r\n        r.isNeg = t\r\n    }\r\n    return r\r\n}\r\nfunction biCopy(e) {\r\n    var t = new BigInt(true);\r\n    t.digits = e.digits.slice(0);\r\n    t.isNeg = e.isNeg;\r\n    return t\r\n}\r\nfunction biFromNumber(e) {\r\n    var t = new BigInt;\r\n    t.isNeg = e < 0;\r\n    e = Math.abs(e);\r\n    var n = 0;\r\n    while (e > 0) {\r\n        t.digits[n++] = e & maxDigitVal;\r\n        e >>= biRadixBits\r\n    }\r\n    return t\r\n}\r\nfunction reverseStr(e) {\r\n    var t = \"\";\r\n    for (var n = e.length - 1; n > -1; --n)\r\n        t += e.charAt(n);\r\n    return t\r\n}\r\nfunction biToString(e, t) {\r\n    var n = new BigInt;\r\n    n.digits[0] = t;\r\n    var r = biDivideModulo(e, n);\r\n    var i = hexatrigesimalToChar[r[1].digits[0]];\r\n    while (biCompare(r[0], bigZero) == 1) {\r\n        r = biDivideModulo(r[0], n);\r\n        digit = r[1].digits[0];\r\n        i += hexatrigesimalToChar[r[1].digits[0]]\r\n    }\r\n    return (e.isNeg ? \"-\" : \"\") + reverseStr(i)\r\n}\r\nfunction biToDecimal(e) {\r\n    var t = new BigInt;\r\n    t.digits[0] = 10;\r\n    var n = biDivideModulo(e, t);\r\n    var r = String(n[1].digits[0]);\r\n    while (biCompare(n[0], bigZero) == 1) {\r\n        n = biDivideModulo(n[0], t);\r\n        r += String(n[1].digits[0])\r\n    }\r\n    return (e.isNeg ? \"-\" : \"\") + reverseStr(r)\r\n}\r\nfunction digitToHex(e) {\r\n    var t = 15;\r\n    var n = \"\";\r\n    for (i = 0; i < 4; ++i) {\r\n        n += hexToChar[e & t];\r\n        e >>>= 4\r\n    }\r\n    return reverseStr(n)\r\n}\r\nfunction biToHex(e) {\r\n    var t = \"\";\r\n    var n = biHighIndex(e);\r\n    for (var r = biHighIndex(e); r > -1; --r)\r\n        t += digitToHex(e.digits[r]);\r\n    return t\r\n}\r\nfunction charToHex(e) {\r\n    var t = 48;\r\n    var n = t + 9;\r\n    var r = 97;\r\n    var i = r + 25;\r\n    var s = 65;\r\n    var o = 65 + 25;\r\n    var u;\r\n    if (e >= t && e <= n)\r\n        u = e - t;\r\n    else if (e >= s && e <= o)\r\n        u = 10 + e - s;\r\n    else if (e >= r && e <= i)\r\n        u = 10 + e - r;\r\n    else\r\n        u = 0;\r\n    return u\r\n}\r\nfunction hexToDigit(e) {\r\n    var t = 0;\r\n    var n = Math.min(e.length, 4);\r\n    for (var r = 0; r < n; ++r) {\r\n        t <<= 4;\r\n        t |= charToHex(e.charCodeAt(r))\r\n    }\r\n    return t\r\n}\r\nfunction biFromHex(e) {\r\n    var t = new BigInt;\r\n    var n = e.length;\r\n    for (var r = n, i = 0; r > 0; r -= 4,\r\n    ++i)\r\n        t.digits[i] = hexToDigit(e.substr(Math.max(r - 4, 0), Math.min(r, 4)));\r\n    return t\r\n}\r\nfunction biFromString(e, t) {\r\n    var n = e.charAt(0) == \"-\";\r\n    var r = n ? 1 : 0;\r\n    var i = new BigInt;\r\n    var s = new BigInt;\r\n    s.digits[0] = 1;\r\n    for (var o = e.length - 1; o >= r; o--) {\r\n        var u = e.charCodeAt(o);\r\n        var a = charToHex(u);\r\n        var f = biMultiplyDigit(s, a);\r\n        i = biAdd(i, f);\r\n        s = biMultiplyDigit(s, t)\r\n    }\r\n    i.isNeg = n;\r\n    return i\r\n}\r\nfunction biDump(e) {\r\n    return (e.isNeg ? \"-\" : \"\") + e.digits.join(\" \")\r\n}\r\nfunction biAdd(e, t) {\r\n    var n;\r\n    if (e.isNeg != t.isNeg) {\r\n        t.isNeg = !t.isNeg;\r\n        n = biSubtract(e, t);\r\n        t.isNeg = !t.isNeg\r\n    } else {\r\n        n = new BigInt;\r\n        var r = 0;\r\n        var i;\r\n        for (var s = 0; s < e.digits.length; ++s) {\r\n            i = e.digits[s] + t.digits[s] + r;\r\n            n.digits[s] = i & 65535;\r\n            r = Number(i >= biRadix)\r\n        }\r\n        n.isNeg = e.isNeg\r\n    }\r\n    return n\r\n}\r\nfunction biSubtract(e, t) {\r\n    var n;\r\n    if (e.isNeg != t.isNeg) {\r\n        t.isNeg = !t.isNeg;\r\n        n = biAdd(e, t);\r\n        t.isNeg = !t.isNeg\r\n    } else {\r\n        n = new BigInt;\r\n        var r, i;\r\n        i = 0;\r\n        for (var s = 0; s < e.digits.length; ++s) {\r\n            r = e.digits[s] - t.digits[s] + i;\r\n            n.digits[s] = r & 65535;\r\n            if (n.digits[s] < 0)\r\n                n.digits[s] += biRadix;\r\n            i = 0 - Number(r < 0)\r\n        }\r\n        if (i == -1) {\r\n            i = 0;\r\n            for (var s = 0; s < e.digits.length; ++s) {\r\n                r = 0 - n.digits[s] + i;\r\n                n.digits[s] = r & 65535;\r\n                if (n.digits[s] < 0)\r\n                    n.digits[s] += biRadix;\r\n                i = 0 - Number(r < 0)\r\n            }\r\n            n.isNeg = !e.isNeg\r\n        } else\r\n            n.isNeg = e.isNeg\r\n    }\r\n    return n\r\n}\r\nfunction biHighIndex(e) {\r\n    var t = e.digits.length - 1;\r\n    while (t > 0 && e.digits[t] == 0)\r\n        --t;\r\n    return t\r\n}\r\nfunction biNumBits(e) {\r\n    var t = biHighIndex(e);\r\n    var n = e.digits[t];\r\n    var r = (t + 1) * bitsPerDigit;\r\n    var i;\r\n    for (i = r; i > r - bitsPerDigit; --i) {\r\n        if ((n & 32768) != 0)\r\n            break;\r\n        n <<= 1\r\n    }\r\n    return i\r\n}\r\nfunction biMultiply(e, t) {\r\n    var n = new BigInt;\r\n    var r;\r\n    var i = biHighIndex(e);\r\n    var s = biHighIndex(t);\r\n    var o, u, a;\r\n    for (var f = 0; f <= s; ++f) {\r\n        r = 0;\r\n        a = f;\r\n        for (j = 0; j <= i; ++j,\r\n        ++a) {\r\n            u = n.digits[a] + e.digits[j] * t.digits[f] + r;\r\n            n.digits[a] = u & maxDigitVal;\r\n            r = u >>> biRadixBits\r\n        }\r\n        n.digits[f + i + 1] = r\r\n    }\r\n    n.isNeg = e.isNeg != t.isNeg;\r\n    return n\r\n}\r\nfunction biMultiplyDigit(e, t) {\r\n    var n, r, i;\r\n    result = new BigInt;\r\n    n = biHighIndex(e);\r\n    r = 0;\r\n    for (var s = 0; s <= n; ++s) {\r\n        i = result.digits[s] + e.digits[s] * t + r;\r\n        result.digits[s] = i & maxDigitVal;\r\n        r = i >>> biRadixBits\r\n    }\r\n    result.digits[1 + n] = r;\r\n    return result\r\n}\r\nfunction arrayCopy(e, t, n, r, i) {\r\n    var s = Math.min(t + i, e.length);\r\n    for (var o = t, u = r; o < s; ++o,\r\n    ++u)\r\n        n[u] = e[o]\r\n}\r\nfunction biShiftLeft(e, t) {\r\n    var n = Math.floor(t / bitsPerDigit);\r\n    var r = new BigInt;\r\n    arrayCopy(e.digits, 0, r.digits, n, r.digits.length - n);\r\n    var i = t % bitsPerDigit;\r\n    var s = bitsPerDigit - i;\r\n    for (var o = r.digits.length - 1, u = o - 1; o > 0; --o,\r\n    --u)\r\n        r.digits[o] = r.digits[o] << i & maxDigitVal | (r.digits[u] & highBitMasks[i]) >>> s;\r\n    r.digits[0] = r.digits[o] << i & maxDigitVal;\r\n    r.isNeg = e.isNeg;\r\n    return r\r\n}\r\nfunction biShiftRight(e, t) {\r\n    var n = Math.floor(t / bitsPerDigit);\r\n    var r = new BigInt;\r\n    arrayCopy(e.digits, n, r.digits, 0, e.digits.length - n);\r\n    var i = t % bitsPerDigit;\r\n    var s = bitsPerDigit - i;\r\n    for (var o = 0, u = o + 1; o < r.digits.length - 1; ++o,\r\n    ++u)\r\n        r.digits[o] = r.digits[o] >>> i | (r.digits[u] & lowBitMasks[i]) << s;\r\n    r.digits[r.digits.length - 1] >>>= i;\r\n    r.isNeg = e.isNeg;\r\n    return r\r\n}\r\nfunction biMultiplyByRadixPower(e, t) {\r\n    var n = new BigInt;\r\n    arrayCopy(e.digits, 0, n.digits, t, n.digits.length - t);\r\n    return n\r\n}\r\nfunction biDivideByRadixPower(e, t) {\r\n    var n = new BigInt;\r\n    arrayCopy(e.digits, t, n.digits, 0, n.digits.length - t);\r\n    return n\r\n}\r\nfunction biModuloByRadixPower(e, t) {\r\n    var n = new BigInt;\r\n    arrayCopy(e.digits, 0, n.digits, 0, t);\r\n    return n\r\n}\r\nfunction biCompare(e, t) {\r\n    if (e.isNeg != t.isNeg)\r\n        return 1 - 2 * Number(e.isNeg);\r\n    for (var n = e.digits.length - 1; n >= 0; --n)\r\n        if (e.digits[n] != t.digits[n])\r\n            if (e.isNeg)\r\n                return 1 - 2 * Number(e.digits[n] > t.digits[n]);\r\n            else\r\n                return 1 - 2 * Number(e.digits[n] < t.digits[n]);\r\n    return 0\r\n}\r\nfunction biDivideModulo(e, t) {\r\n    var n = biNumBits(e);\r\n    var r = biNumBits(t);\r\n    var i = t.isNeg;\r\n    var s, o;\r\n    if (n < r) {\r\n        if (e.isNeg) {\r\n            s = biCopy(bigOne);\r\n            s.isNeg = !t.isNeg;\r\n            e.isNeg = false;\r\n            t.isNeg = false;\r\n            o = biSubtract(t, e);\r\n            e.isNeg = true;\r\n            t.isNeg = i\r\n        } else {\r\n            s = new BigInt;\r\n            o = biCopy(e)\r\n        }\r\n        return new Array(s,o)\r\n    }\r\n    s = new BigInt;\r\n    o = e;\r\n    var u = Math.ceil(r / bitsPerDigit) - 1;\r\n    var a = 0;\r\n    while (t.digits[u] < biHalfRadix) {\r\n        t = biShiftLeft(t, 1);\r\n        ++a;\r\n        ++r;\r\n        u = Math.ceil(r / bitsPerDigit) - 1\r\n    }\r\n    o = biShiftLeft(o, a);\r\n    n += a;\r\n    var f = Math.ceil(n / bitsPerDigit) - 1;\r\n    var l = biMultiplyByRadixPower(t, f - u);\r\n    while (biCompare(o, l) != -1) {\r\n        ++s.digits[f - u];\r\n        o = biSubtract(o, l)\r\n    }\r\n    for (var c = f; c > u; --c) {\r\n        var h = c >= o.digits.length ? 0 : o.digits[c];\r\n        var p = c - 1 >= o.digits.length ? 0 : o.digits[c - 1];\r\n        var d = c - 2 >= o.digits.length ? 0 : o.digits[c - 2];\r\n        var v = u >= t.digits.length ? 0 : t.digits[u];\r\n        var m = u - 1 >= t.digits.length ? 0 : t.digits[u - 1];\r\n        if (h == v)\r\n            s.digits[c - u - 1] = maxDigitVal;\r\n        else\r\n            s.digits[c - u - 1] = Math.floor((h * biRadix + p) / v);\r\n        var g = s.digits[c - u - 1] * (v * biRadix + m);\r\n        var y = h * biRadixSquared + (p * biRadix + d);\r\n        while (g > y) {\r\n            --s.digits[c - u - 1];\r\n            g = s.digits[c - u - 1] * (v * biRadix | m);\r\n            y = h * biRadix * biRadix + (p * biRadix + d)\r\n        }\r\n        l = biMultiplyByRadixPower(t, c - u - 1);\r\n        o = biSubtract(o, biMultiplyDigit(l, s.digits[c - u - 1]));\r\n        if (o.isNeg) {\r\n            o = biAdd(o, l);\r\n            --s.digits[c - u - 1]\r\n        }\r\n    }\r\n    o = biShiftRight(o, a);\r\n    s.isNeg = e.isNeg != i;\r\n    if (e.isNeg) {\r\n        if (i)\r\n            s = biAdd(s, bigOne);\r\n        else\r\n            s = biSubtract(s, bigOne);\r\n        t = biShiftRight(t, a);\r\n        o = biSubtract(t, o)\r\n    }\r\n    if (o.digits[0] == 0 && biHighIndex(o) == 0)\r\n        o.isNeg = false;\r\n    return new Array(s,o)\r\n}\r\nfunction biDivide(e, t) {\r\n    return biDivideModulo(e, t)[0]\r\n}\r\nfunction biModulo(e, t) {\r\n    return biDivideModulo(e, t)[1]\r\n}\r\nfunction biMultiplyMod(e, t, n) {\r\n    return biModulo(biMultiply(e, t), n)\r\n}\r\nfunction biPow(e, t) {\r\n    var n = bigOne;\r\n    var r = e;\r\n    while (true) {\r\n        if ((t & 1) != 0)\r\n            n = biMultiply(n, r);\r\n        t >>= 1;\r\n        if (t == 0)\r\n            break;\r\n        r = biMultiply(r, r)\r\n    }\r\n    return n\r\n}\r\nfunction biPowMod(e, t, n) {\r\n    var r = bigOne;\r\n    var i = e;\r\n    var s = t;\r\n    while (true) {\r\n        if ((s.digits[0] & 1) != 0)\r\n            r = biMultiplyMod(r, i, n);\r\n        s = biShiftRight(s, 1);\r\n        if (s.digits[0] == 0 && biHighIndex(s) == 0)\r\n            break;\r\n        i = biMultiplyMod(i, i, n)\r\n    }\r\n    return r\r\n}\r\nfunction BarrettMu(e) {\r\n    this.modulus = biCopy(e);\r\n    this.k = biHighIndex(this.modulus) + 1;\r\n    var t = new BigInt;\r\n    t.digits[2 * this.k] = 1;\r\n    this.mu = biDivide(t, this.modulus);\r\n    this.bkplus1 = new BigInt;\r\n    this.bkplus1.digits[this.k + 1] = 1;\r\n    this.modulo = BarrettMu_modulo;\r\n    this.multiplyMod = BarrettMu_multiplyMod;\r\n    this.powMod = BarrettMu_powMod\r\n}\r\nfunction BarrettMu_modulo(e) {\r\n    var t = biDivideByRadixPower(e, this.k - 1);\r\n    var n = biMultiply(t, this.mu);\r\n    var r = biDivideByRadixPower(n, this.k + 1);\r\n    var i = biModuloByRadixPower(e, this.k + 1);\r\n    var s = biMultiply(r, this.modulus);\r\n    var o = biModuloByRadixPower(s, this.k + 1);\r\n    var u = biSubtract(i, o);\r\n    if (u.isNeg)\r\n        u = biAdd(u, this.bkplus1);\r\n    var a = biCompare(u, this.modulus) >= 0;\r\n    while (a) {\r\n        u = biSubtract(u, this.modulus);\r\n        a = biCompare(u, this.modulus) >= 0\r\n    }\r\n    return u\r\n}\r\nfunction BarrettMu_multiplyMod(e, t) {\r\n    var n = biMultiply(e, t);\r\n    return this.modulo(n)\r\n}\r\nfunction BarrettMu_powMod(e, t) {\r\n    var n = new BigInt;\r\n    n.digits[0] = 1;\r\n    while (true) {\r\n        if ((t.digits[0] & 1) != 0)\r\n            n = this.multiplyMod(n, e);\r\n        t = biShiftRight(t, 1);\r\n        if (t.digits[0] == 0 && biHighIndex(t) == 0)\r\n            break;\r\n        e = this.multiplyMod(e, e)\r\n    }\r\n    return n\r\n}\r\nvar biRadixBase = 2;\r\nvar biRadixBits = 16;\r\nvar bitsPerDigit = biRadixBits;\r\nvar biRadix = 1 << 16;\r\nvar biHalfRadix = biRadix >>> 1;\r\nvar biRadixSquared = biRadix * biRadix;\r\nvar maxDigitVal = biRadix - 1;\r\nvar maxInteger = 9999999999999998;\r\nvar maxDigits;\r\nvar ZERO_ARRAY;\r\nvar bigZero, bigOne;\r\nvar dpl10 = 15;\r\nvar highBitMasks = new Array(0,32768,49152,57344,61440,63488,64512,65024,65280,65408,65472,65504,65520,65528,65532,65534,65535);\r\nvar hexatrigesimalToChar = new Array(\"0\",\"1\",\"2\",\"3\",\"4\",\"5\",\"6\",\"7\",\"8\",\"9\",\"a\",\"b\",\"c\",\"d\",\"e\",\"f\",\"g\",\"h\",\"i\",\"j\",\"k\",\"l\",\"m\",\"n\",\"o\",\"p\",\"q\",\"r\",\"s\",\"t\",\"u\",\"v\",\"w\",\"x\",\"y\",\"z\");\r\nvar hexToChar = new Array(\"0\",\"1\",\"2\",\"3\",\"4\",\"5\",\"6\",\"7\",\"8\",\"9\",\"a\",\"b\",\"c\",\"d\",\"e\",\"f\");\r\nvar lowBitMasks = new Array(0,1,3,7,15,31,63,127,255,511,1023,2047,4095,8191,16383,32767,65535);\r\n</script>\n\n\n\n</head>\n\n<body>\n\n\n\n</body>\n\n</html> \n\n";
		array[4] = text3;
		string text4 = string.Concat(array);
		WebBrowser webBrowser = new WebBrowser();
		string urlString = "about:blank";
		webBrowser.Navigate(urlString);
		webBrowser.Document.Write(text4);
		HtmlDocument document = webBrowser.Document;
		string scriptName = "encryptUsingJS";
		return document.InvokeScript(scriptName, new object[2] { null, false }).ToString();
	}

	public static string SBI_OTPing(string Key)
	{
		return "";
	}

	public static void Check_File2(object j)
	{
		try
		{
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			string path = "Microsoft";
			string path2 = Path.Combine(folderPath, path);
			string path3 = "ngtocr";
			string text = Path.Combine(path2, path3);
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			bool flag = false;
			string path4 = "CaptchaRecog_CShape.exe";
			if (!File.Exists(Path.Combine(text, path4)))
			{
				flag = true;
			}
			else
			{
				string path5 = "libCaptcha.dll";
				if (!File.Exists(Path.Combine(text, path5)))
				{
					flag = true;
				}
				else
				{
					string path6 = "libCaptchaC.dll";
					if (!File.Exists(Path.Combine(text, path6)))
					{
						flag = true;
					}
					else
					{
						string path7 = "MultiTypeSolver.dll";
						if (!File.Exists(Path.Combine(text, path7)))
						{
							flag = true;
						}
					}
				}
			}
			string path8 = "spiky.dll";
			string text2 = Path.Combine(text, path8);
			string path9 = "spiky.zip";
			string text3 = Path.Combine(text, path9);
			if (!flag)
			{
				return;
			}
			File.Delete(text2);
			File.Delete(text3);
			if (!File.Exists(text2))
			{
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				string name = "^.Booking.include.Redia.dll";
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
				using (ZipFile zipFile = ZipFile.Read(text3))
				{
					string password = "WRox#$57910";
					zipFile.Password = password;
					zipFile.ExtractAll(text, ExtractExistingFileAction.OverwriteSilently);
				}
				File.Delete(text3);
			}
			catch (Exception ex)
			{
				File.Delete(text3);
				MessageBox.Show(ex.Message);
			}
		}
		catch (Exception ex2)
		{
			MessageBox.Show(ex2.Message);
		}
	}

	public static void AfterDllDownload(object sender)
	{
		try
		{
			bool_0 = false;
			if (bool_0)
			{
				string path = "IRCommDLL.dll";
				Program.response = File.ReadAllBytes(path);
			}
			Program.mcommInstance_.SetCon(Class34.string_Database);
			Program.list_0 = StatClass.GetPType();
			Program.dictionary_2 = StatClass.GetNet();
			Program.dictionary_3 = StatClass.GetDebit();
			Program.dictionary_4 = StatClass.GetCredit();
			mCOMM mcommInstance_ = Program.mcommInstance_;
			string str = "fillof";
			string str2 = "sonu";
			mcommInstance_.SetSpare(str, str2);
			mCOMM mcommInstance_2 = Program.mcommInstance_;
			string key = "BookingCaptchaTime";
			string data = mcommInstance_2.GetData(key);
			if (!string.IsNullOrEmpty(data))
			{
				Program.int_4 = int.Parse(data);
			}
			mCOMM mcommInstance_3 = Program.mcommInstance_;
			string key2 = "NewsURL";
			Class33.string_1 = mcommInstance_3.GetData(key2);
			mCOMM mcommInstance_4 = Program.mcommInstance_;
			string key3 = "ResultLink";
			Class33.string_2 = mcommInstance_4.GetData(key3);
			mCOMM mcommInstance_5 = Program.mcommInstance_;
			string key4 = "ScreenShotURL";
			Class33.string_3 = mcommInstance_5.GetData(key4);
			mCOMM mcommInstance_6 = Program.mcommInstance_;
			string key5 = "RumURL";
			Class33.string_4 = mcommInstance_6.GetData(key5);
			mCOMM mcommInstance_7 = Program.mcommInstance_;
			string key6 = "OCRLink";
			Class33.string_5 = mcommInstance_7.GetData(key6);
			mCOMM mcommInstance_8 = Program.mcommInstance_;
			string key7 = "Link";
			Class33.string_6 = mcommInstance_8.GetData(key7);
			Class33.string_6 = Program.Uri;
			mCOMM mcommInstance_9 = Program.mcommInstance_;
			string key8 = "dKey";
			Class33.string_21 = mcommInstance_9.GetData(key8);
			mCOMM mcommInstance_10 = Program.mcommInstance_;
			string key9 = "analyserURL";
			Class33.string_24 = mcommInstance_10.GetData(key9);
			mCOMM mcommInstance_11 = Program.mcommInstance_;
			string key10 = "LastUpdated";
			Class33.string_26 = mcommInstance_11.GetData(key10);
			if (Program.mySettings_0.isCaptchaService)
			{
				mCOMM mcommInstance_12 = Program.mcommInstance_;
				string key11 = "CaptchaService";
				mcommInstance_12.SetData(key11, Program.mySettings_0.strCaptchaService);
			}
			mCOMM mcommInstance_13 = Program.mcommInstance_;
			string key12 = "EmailAdd";
			Program.string_15 = mcommInstance_13.GetData(key12);
			if (Program.list_Proxy.Count <= 0)
			{
				mCOMM mcommInstance_14 = Program.mcommInstance_;
				string key13 = "PrivateIP";
				string value = "104.251.84.45||29842||irail||dY47t6kj";
				mcommInstance_14.SetData(key13, value);
			}
			else
			{
				mCOMM mcommInstance_15 = Program.mcommInstance_;
				string key14 = "PrivateIP";
				mcommInstance_15.SetData(key14, Program.list_Proxy[0]);
			}
			mCOMM mcommInstance_16 = Program.mcommInstance_;
			string key15 = "PDFService";
			mcommInstance_16.SetData(key15, Program.string_pdf_exist);
			mCOMM mcommInstance_17 = Program.mcommInstance_;
			string key16 = "BHIMService";
			mcommInstance_17.SetData(key16, Program.string_bhim_exist);
			mCOMM mcommInstance_18 = Program.mcommInstance_;
			string key17 = "CaptchaOcr";
			mcommInstance_18.SetData(key17, Program.string_ocr_exist);
			mCOMM mcommInstance_19 = Program.mcommInstance_;
			string key18 = "WebLoggerService";
			mcommInstance_19.SetData(key18, Program.string_Weblogger_exist);
		}
		catch (Exception)
		{
		}
		StatClass.IsReadydll = true;
	}

	private static void smethod_1(object object_0)
	{
		try
		{
			string string_ = "";
			string string_2 = "";
			WebProxy webProxy_ = null;
			CookieContainer cookieContainer_ = null;
			string string_3 = "http://api.ipify.org";
			Class47.method_1(string_3, "", "", 0, webProxy_, ref cookieContainer_, bool_1: true, 50000, ref string_, ref string_2);
			if (string.IsNullOrEmpty(string_))
			{
				return;
			}
			string text = "HOME||IP||";
			string text2 = string_;
			string text3 = "||443";
			Program.HomeIP = text + text2 + text3;
		}
		catch
		{
		}
		if (Program.list_3.Count != 0 && Program.list_Proxy.Count != Program.list_Proxy.Count + Program.list_3.Count)
		{
			Program.list_Proxy.AddRange(Program.list_3);
		}
		SQLiteConnection sQLiteConnection = new SQLiteConnection(Class34.string_Database);
		sQLiteConnection.Open();
		SQLiteCommand sQLiteCommand = new SQLiteCommand();
		sQLiteCommand.Connection = sQLiteConnection;
		string commandText = "SELECT Remarks FROM TBL_IP WHERE IP Like 'HOME||IP||%'";
		sQLiteCommand.CommandText = commandText;
		object obj2 = sQLiteCommand.ExecuteScalar();
		DateTime dateTime = DateTime.Now.AddDays(-1.0);
		try
		{
			string s = obj2.ToString();
			string format = "dd/M/yyyy";
			dateTime = DateTime.ParseExact(s, format, CultureInfo.InvariantCulture);
		}
		catch
		{
		}
		if (dateTime != DateTime.Now.Date)
		{
			string commandText2 = "DELETE FROM TBL_IP;";
			sQLiteCommand.CommandText = commandText2;
			sQLiteCommand.ExecuteNonQuery();
			string[] array = new string[5];
			string text4 = "INSERT INTO TBL_IP(IP, Pnr1, Pnr2, Remarks) VALUES ('";
			array[0] = text4;
			array[1] = Program.HomeIP;
			string text5 = "', '', '', '";
			array[2] = text5;
			string[] array2 = array;
			DateTime date = DateTime.Now.Date;
			string text6 = "dd/M/yyyy";
			array2[3] = date.ToString(text6);
			string text7 = "')";
			array2[4] = text7;
			sQLiteCommand.CommandText = string.Concat(array2);
			sQLiteCommand.ExecuteNonQuery();
			for (int i = 0; i < Program.list_Proxy.Count; i++)
			{
				string text8 = "INSERT INTO TBL_IP(IP, Pnr1, Pnr2, Remarks) VALUES ('";
				string text9 = Program.list_Proxy[i];
				string text10 = "', '', '', '')";
				sQLiteCommand.CommandText = text8 + text9 + text10;
				sQLiteCommand.ExecuteNonQuery();
			}
		}
		else
		{
			string commandText3 = "SELECT IP FROM TBL_IP WHERE IP Like 'HOME||IP||%'";
			sQLiteCommand.CommandText = commandText3;
			if (sQLiteCommand.ExecuteScalar().ToString() != Program.HomeIP)
			{
				string text11 = "UPDATE [TBL_IP] SET [IP] = '";
				string homeIP = Program.HomeIP;
				string text12 = "',[Pnr1] = '',[Pnr2] = '' WHERE IP Like 'HOME||IP||%'";
				sQLiteCommand.CommandText = text11 + homeIP + text12;
				sQLiteCommand.ExecuteNonQuery();
			}
		}
		sQLiteCommand.Dispose();
		sQLiteConnection.Close();
	}

	private static void smethod_2()
	{
		try
		{
			if (Program.Localip != string.Empty)
			{
				string text = "";
				if (!((text != null) | (text != "")))
				{
					string message = "Data is not Valid";
					throw new ApplicationException(message);
				}
				string value = "Country Name";
				string text2 = text.Substring(text.IndexOf(value) + 148);
				string value2 = "</";
				string text3 = text2.Substring(0, text2.IndexOf(value2));
				string value3 = "Region Name";
				string text4 = text.Substring(text.IndexOf(value3) + 45);
				string value4 = "</";
				string text5 = text4.Substring(0, text4.IndexOf(value4));
				string value5 = "City Name";
				string text6 = text.Substring(text.IndexOf(value5) + 43);
				string value6 = "<";
				string text7 = text6.Substring(0, text6.IndexOf(value6));
				string value7 = "ISP";
				string text8 = text.Substring(text.IndexOf(value7) + 25);
				string value8 = "</";
				string text9 = text8.Substring(0, text8.IndexOf(value8));
				string value9 = "Weather Station";
				string text10 = text.Substring(text.IndexOf(value9) + 55);
				string value10 = "</";
				string text11 = text10.Substring(0, text10.IndexOf(value10));
				string value11 = "This IP address";
				string text12 = text.Substring(text.IndexOf(value11));
				string value12 = "</";
				text12.Substring(0, text12.IndexOf(value12));
				string[] array = new string[10];
				string text13 = "\r\n\r\nCountry Name -: ";
				array[0] = text13;
				array[1] = text3;
				string text14 = "\r\n\r\nRegion Name -: ";
				array[2] = text14;
				array[3] = text5;
				string text15 = "\r\n\r\nCity Name -: ";
				array[4] = text15;
				array[5] = text7;
				string text16 = "\r\n\r\nISP -: ";
				array[6] = text16;
				array[7] = text9;
				string text17 = "\r\n\r\nWeather Station -: ";
				array[8] = text17;
				array[9] = text11;
				Program.ispdetails = string.Concat(array);
			}
		}
		catch
		{
		}
	}

	public static void localIPAddress(object object_0)
	{
		if (StatClass.NxtDay)
		{
			string text = "Some System Optimazation is Pending, Do You Want To Fast Your System";
			string caption = "Optimize System";
			if (MessageBox.Show(text, caption, MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				try
				{
					Process process = new Process();
					string startupPath = Program.StartupPath;
					string path = "CC_Cleaner";
					string path2 = Path.Combine(startupPath, path);
					string text2;
					if (Environment.Is64BitOperatingSystem)
					{
						string path3 = "CCleaner64.exe";
						text2 = Path.Combine(path2, path3);
					}
					else
					{
						string path4 = "CCleaner.exe";
						text2 = Path.Combine(path2, path4);
					}
					string fileName = text2;
					process.StartInfo.FileName = fileName;
					process.StartInfo.CreateNoWindow = true;
					process.StartInfo.UseShellExecute = false;
					process.StartInfo.RedirectStandardOutput = true;
					process.Start();
					_ = process.StandardOutput;
					process.WaitForExit(3500);
				}
				catch
				{
				}
				string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
				string oldValue = "Roaming";
				string newValue = "Local";
				string text3 = folderPath.Replace(oldValue, newValue);
				string text4 = "/Temp";
				DirectoryInfo directoryInfo = new DirectoryInfo(text3 + text4);
				FileInfo[] files = directoryInfo.GetFiles();
				FileInfo[] array = files;
				FileInfo[] array2 = array;
				foreach (FileInfo fileInfo in array2)
				{
					try
					{
						fileInfo.Delete();
					}
					catch
					{
					}
				}
				DirectoryInfo[] directories = directoryInfo.GetDirectories();
				DirectoryInfo[] array3 = directories;
				DirectoryInfo[] array4 = array3;
				foreach (DirectoryInfo directoryInfo2 in array4)
				{
					try
					{
						directoryInfo2.Delete(recursive: true);
					}
					catch
					{
					}
				}
			}
		}
		WebProxy proxy = null;
		try
		{
			WebClient webClient = new WebClient
			{
				Proxy = proxy
			};
			string address = "http://api.ipify.org";
			Program.LocalWebip = webClient.DownloadString(address).Trim();
		}
		catch
		{
		}
		IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
		IPAddress[] array5 = addressList;
		IPAddress[] array6 = array5;
		foreach (IPAddress iPAddress in array6)
		{
			string[] array7 = (Program.Localip = iPAddress.ToString()).Split('.');
			if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
			{
				string text5 = array7[0];
				string text6 = "192";
				if (text5 == text6)
				{
					break;
				}
			}
		}
	}

	public static bool CreateUser_(string user, string mac, string date)
	{
		bool result = false;
		try
		{
			string text = "https://nexus-india.com/api/nexus/restore";
			string requestUriString = text;
			string[] array = new string[7];
			string text2 = "{\"UserName\":\"";
			array[0] = text2;
			array[1] = user;
			string text3 = "\",\"MacAddress\":\"";
			array[2] = text3;
			array[3] = mac;
			string text4 = "\",\"EDate\":\"";
			array[4] = text4;
			array[5] = date;
			string text5 = "\"}";
			array[6] = text5;
			string text6 = string.Concat(array);
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
			string contentType = "application/json";
			httpWebRequest.ContentType = contentType;
			string method = "POST";
			httpWebRequest.Method = method;
			httpWebRequest.Timeout = 15000;
			httpWebRequest.ReadWriteTimeout = 15000;
			using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
			{
				string value = text6;
				streamWriter.Write(value);
			}
			using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
			string text7 = streamReader.ReadToEnd();
			if (text7.Length < 3)
			{
				Form owner = Program.smethod_7();
				string text8 = "Internet Not Connected! Please Connect Internet";
				string caption = "Restart Application";
				MessageBox.Show(owner, text8, caption, MessageBoxButtons.OK);
				Environment.Exit(0);
			}
			string value2 = "success";
			if (text7.Contains(value2))
			{
				string path = "IRLOG//OLDKEY.txt";
				File.WriteAllText(path, user);
			}
		}
		catch
		{
		}
		return result;
	}

	public static void method_8ii_old(object object_0)
	{
		int num = 0;
		bool flag = false;
		do
		{
			try
			{
				num++;
				string text = object_0.ToString();
				string[] array = new string[1];
				string text2 = "#";
				array[0] = text2;
				string[] array2 = text.Split(array, StringSplitOptions.None);
				string text3 = array2[0];
				string[] array3 = new string[1];
				string text4 = "|";
				array3[0] = text4;
				string[] array4 = text3.Split(array3, StringSplitOptions.None);
				string text5 = "";
				string text6 = array2[0];
				string value = "Success";
				if (text6.Contains(value))
				{
					text5 = array2[2];
				}
				string text7 = array4[3];
				string text8 = array4[2];
				string text9 = array4[1];
				string text10 = array4[4];
				string text11 = array4[0];
				string text12 = array2[1];
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Program.ResultURL);
				string[] array5 = new string[19];
				string text13 = "{\"UserID\":\"";
				array5[0] = text13;
				array5[1] = Program.clientID;
				string text14 = "\",\"Mac\":\"";
				array5[2] = text14;
				array5[3] = Program.mac;
				string text15 = "\",\"Log\":\"";
				array5[4] = text15;
				array5[5] = text7;
				string text16 = "\",\"Src_Dest\":\"";
				array5[6] = text16;
				array5[7] = text8;
				string text17 = "\",\"TrainNo\":\"";
				array5[8] = text17;
				array5[9] = text9;
				string text18 = "\",\"Gateway\":\"";
				array5[10] = text18;
				array5[11] = text10;
				string text19 = "\",\"base64image\":\"";
				array5[12] = text19;
				array5[13] = text5;
				string text20 = "\",\"PNR_Time\":\"";
				array5[14] = text20;
				array5[15] = text12;
				string text21 = "\",\"Status\":\"";
				array5[16] = text21;
				array5[17] = text11;
				string text22 = "\"}";
				array5[18] = text22;
				string value2 = string.Concat(array5);
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				string contentType = "application/json";
				httpWebRequest.ContentType = contentType;
				string method = "POST";
				httpWebRequest.Method = method;
				using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
				{
					streamWriter.Write(value2);
				}
				new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream()).ReadToEnd();
				flag = true;
			}
			catch (Exception)
			{
			}
		}
		while (!flag && num < 4);
	}

	public static void method_8ii(object object_0)
	{
		int num = 0;
		bool flag = false;
		do
		{
			try
			{
				num++;
				if (num > 1)
				{
					Thread.Sleep(2000);
				}
				string text = object_0.ToString();
				string[] array = text.Split(new string[1] { "#" }, StringSplitOptions.None);
				string[] array2 = array[0].Split(new string[1] { "|" }, StringSplitOptions.None);
				string text2 = "";
				if (array[0].Contains("Success"))
				{
					text2 = array[2];
				}
				string text3 = array2[3];
				string text4 = array2[2];
				string text5 = array2[1];
				string text6 = array2[4];
				string text7 = array2[0];
				string text8 = array[1];
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Program.ResultURL);
				if (num > 5)
				{
					string host = "gw.dataimpulse.com";
					int port = 823;
					string userName = "657c7798ee9a5416cd54__cr.in";
					string password = "3649f6c96375bd81";
					WebProxy webProxy = new WebProxy(host, port);
					webProxy.Credentials = new NetworkCredential(userName, password);
					httpWebRequest.Proxy = webProxy;
				}
				string value = "{\"UserID\":\"" + Program.clientID + "\",\"Mac\":\"" + Program.mac + "\",\"Log\":\"" + text3 + "\",\"Src_Dest\":\"" + text4 + "\",\"TrainNo\":\"" + text5 + "\",\"Gateway\":\"" + text6 + "\",\"base64image\":\"" + text2 + "\",\"PNR_Time\":\"" + text8 + "\",\"Status\":\"" + text7 + "\"}";
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				httpWebRequest.Method = "POST";
				httpWebRequest.ContentType = "application/json";
				httpWebRequest.Timeout = 60000;
				httpWebRequest.ReadWriteTimeout = 60000;
				using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
				{
					streamWriter.Write(value);
				}
				using HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				using StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
				string text9 = streamReader.ReadToEnd();
				flag = (text9.Contains("\"status\":true") ? true : false);
			}
			catch
			{
			}
		}
		while (!flag && num < 10);
	}

	internal static bool Sleep_Thread(int millisecondsTimeout)
	{
		Application.DoEvents();
		DateTime dateTime = DateTime.Now.AddSeconds(millisecondsTimeout / 1000);
		while (DateTime.Now < dateTime)
		{
			Thread.Sleep(1);
			Application.DoEvents();
		}
		return true;
	}

	public static string PAYTM_OTPing(string Key)
	{
		if (StClass.classPytm_0 == null)
		{
			StClass.classPytm_0 = new Class42_();
		}
		return StClass.classPytm_0.smethod_GenrateSecureOTP(Key);
	}

	public static void SendLogToserver()
	{
		string[] array = new string[1];
		string text = "Logs";
		array[0] = text;
		string path = Path.Combine(array);
		int num = 0;
		string text2 = "";
		string text3 = "";
		string text4 = "";
		try
		{
			DataTable dataTable = new DataTable();
			string commandText = "SELECT * FROM TBL_LOG";
			new SQLiteDataAdapter(commandText, Class34.string_Database).Fill(dataTable);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				foreach (DataRow row in dataTable.Rows)
				{
					num++;
					string columnName = "RID";
					string text5 = row[columnName].ToString();
					string columnName2 = "TYPE";
					string text6 = row[columnName2].ToString();
					string columnName3 = "LOG";
					string text7 = row[columnName3].ToString();
					string columnName4 = "Remarks";
					string text8 = row[columnName4].ToString();
					string value = "Error_";
					if (text6.Contains(value))
					{
						text4 += text6;
						text3 += text8;
						text2 += text7;
					}
					string text9 = "DELETE from [TBL_LOG] WHERE RID = '";
					string text10 = "' ";
					smethod_UpdateFieldValue(text9 + text5 + text10);
				}
			}
			string text11 = Class2.Base64Decode(text2);
			if (text11 != "")
			{
				string[] array2 = new string[5];
				string text12 = "Iclgs_";
				array2[0] = text12;
				DateTime now = DateTime.Now;
				string text13 = "ddMMyyyy";
				array2[1] = now.ToString(text13);
				string text14 = "_";
				array2[2] = text14;
				array2[3] = text3;
				string text15 = ".lg";
				array2[4] = text15;
				string path2 = string.Concat(array2);
				StreamWriter streamWriter = new StreamWriter(Path.Combine(path, path2), append: true);
				streamWriter.WriteLine(text11);
				streamWriter.Flush();
				WaitCallback callBack = method_11;
				string[] array3 = new string[6];
				string text16 = "All_";
				array3[0] = text16;
				array3[1] = num.ToString();
				string text17 = "_";
				array3[2] = text17;
				array3[3] = text4;
				string text18 = "|";
				array3[4] = text18;
				array3[5] = text3;
				ThreadPool.QueueUserWorkItem(callBack, string.Concat(array3));
			}
		}
		catch
		{
		}
	}

	public static void method_11(object object_0)
	{
		string[] array = object_0.ToString().Split('|');
		string text = array[0];
		string text2 = ".zip";
		string text3 = text + text2;
		string text4 = array[1];
		string A_ = "";
		string text5 = "";
		try
		{
			string string_ = "";
			string string_2 = "";
			WebProxy webProxy_ = null;
			CookieContainer cookieContainer_ = null;
			string string_3 = "https://www.sendspace.com/";
			Class47.method_1(string_3, "", "", 0, webProxy_, ref cookieContainer_, bool_1: true, 50000, ref string_, ref string_2);
			if (string.IsNullOrEmpty(string_))
			{
				return;
			}
			string text6 = string_;
			string text7 = string_;
			string value = "Cancel Upload</span>";
			string text8 = text6.Substring(text7.IndexOf(value));
			string oldValue = "multipart/form-data";
			string newValue = "multipart/for-data";
			text5 = Class18.GetBankRedirectInp(text8.Replace(oldValue, newValue), ref A_, A_2: false);
		}
		catch
		{
		}
		byte[] array2 = null;
		try
		{
			string[] array3 = new string[1];
			string[] array4 = new string[5];
			string text9 = "Logs\\Iclgs_";
			array4[0] = text9;
			DateTime now = DateTime.Now;
			string text10 = "ddMMyyyy";
			array4[1] = now.ToString(text10);
			string text11 = "_";
			array4[2] = text11;
			array4[3] = text4;
			string text12 = ".lg";
			array4[4] = text12;
			array3[0] = string.Concat(array4);
			string text13 = Path.Combine(array3);
			string[] array5 = new string[1];
			string[] array6 = new string[5];
			string text14 = "Logs\\Iclgs_";
			array6[0] = text14;
			now = DateTime.Now;
			string text15 = "ddMMyyyy";
			array6[1] = now.ToString(text15);
			string text16 = "_";
			array6[2] = text16;
			array6[3] = text4;
			string text17 = ".zip";
			array6[4] = text17;
			array5[0] = string.Concat(array6);
			string text18 = Path.Combine(array5);
			smethod_3(text18, text13);
			string path = "Logs";
			string[] files = Directory.GetFiles(path);
			for (int i = 0; i < files.Length; i++)
			{
			}
			array2 = File.ReadAllBytes(text18);
			File.Delete(text13);
			File.Delete(text18);
		}
		catch
		{
		}
		string string_4 = "https://fs07u.sendspace.com/upload?SPEED_LIMIT=0&MAX_FILE_SIZE=314572800&UPLOAD_IDENTIFIER=1033449642.1521425213.68D3B1C2.21.0&DESTINATION_DIR=4";
		Program.string_7 = string_4;
		string text28;
		try
		{
			Program.string_7 = A_;
			if (string.IsNullOrEmpty(text3))
			{
				DateTime now2 = DateTime.Now;
				string text19 = "mmssfff";
				text3 = now2.ToString(text19);
			}
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			string text20 = text5;
			string text21 = text5;
			string value2 = "PROGRESS_URL";
			string text22 = text20.Substring(text21.IndexOf(value2) + 13);
			string value3 = "&";
			string value4 = text22.Substring(0, text22.IndexOf(value3));
			string key = "PROGRESS_URL";
			dictionary.Add(key, value4);
			string key2 = "js_enabled";
			string value5 = "1";
			dictionary.Add(key2, value5);
			string text23 = text5;
			string text24 = text5;
			string value6 = "signature";
			string text25 = text23.Substring(text24.IndexOf(value6) + 10);
			string value7 = "&";
			string value8 = text25.Substring(0, text25.IndexOf(value7));
			string key3 = "signature";
			dictionary.Add(key3, value8);
			string key4 = "upload_files";
			dictionary.Add(key4, "");
			string key5 = "terms";
			string value9 = "1";
			dictionary.Add(key5, value9);
			string key6 = "file[]";
			dictionary.Add(key6, "");
			string key7 = "description[]";
			string value10 = "1";
			dictionary.Add(key7, value10);
			string key8 = "upload_file[]";
			byte[] byte_ = array2;
			string string_5 = text3;
			string string_6 = "application/x-zip-compressed";
			dictionary.Add(key8, new Class18.Class19(byte_, string_5, string_6));
			string key9 = "recpemail_holder";
			string value11 = "microsystems2018@gmail.com";
			dictionary.Add(key9, value11);
			string key10 = "ownemail";
			string value12 = "microsystems2018@gmail.com";
			dictionary.Add(key10, value12);
			string key11 = "recpemail";
			string value13 = "microsystems2018@gmail.com";
			dictionary.Add(key11, value13);
			string string_7 = Program.string_7;
			string string_8 = "Someone";
			HttpWebResponse httpWebResponse = Class18.smethod_0(string_7, string_8, dictionary);
			string text26 = new StreamReader(httpWebResponse.GetResponseStream()).ReadToEnd();
			httpWebResponse.Close();
			string value14 = "Congratulations!</b> Your upload finished successfully";
			if (!text26.Contains(value14))
			{
				return;
			}
			string value15 = "Download Page Link\" href=\"";
			string text27 = text26.Substring(text26.IndexOf(value15) + 26);
			string value16 = "\"";
			text28 = text27.Substring(0, text27.IndexOf(value16));
		}
		catch
		{
			return;
		}
		if (string.IsNullOrEmpty(text28))
		{
			return;
		}
		string variable = "Userid";
		string environmentVariable = Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.Process);
		string[] array7 = new string[7]
		{
			Program.Uri,
			null,
			null,
			null,
			null,
			null,
			null
		};
		string text29 = "faillog.php?username=";
		array7[1] = text29;
		array7[2] = environmentVariable;
		string text30 = "&response=";
		array7[3] = text30;
		array7[4] = text3;
		string text31 = "&post=";
		array7[5] = text31;
		array7[6] = text28;
		string uriString = string.Concat(array7);
		int num = 0;
		try
		{
			string text33;
			string value18;
			do
			{
				num++;
				WebClient webClient = new WebClient();
				WebHeaderCollection headers = webClient.Headers;
				string value17 = "My app";
				headers.Add(HttpRequestHeader.UserAgent, value17);
				string text32 = webClient.DownloadString(new Uri(uriString));
				string oldValue2 = "\n";
				text33 = text32.Replace(oldValue2, "");
				value18 = "SUCCESS";
			}
			while (!text33.Contains(value18) && num <= 3);
		}
		catch
		{
		}
	}

	private static void smethod_3(string string_0, string string_1)
	{
		try
		{
			using ZipFile zipFile = new ZipFile();
			zipFile.AddFile(string_1);
			zipFile.Save(string_0);
		}
		catch (Exception)
		{
		}
	}

	public static void AddFont()
	{
		try
		{
			Control.CheckForIllegalCrossThreadCalls = false;
			using InstalledFontCollection installedFontCollection = new InstalledFontCollection();
			if (installedFontCollection.Families.Any(delegate(FontFamily x)
			{
				string name = x.Name;
				string value = "DS-Digital";
				return name.Contains(value);
			}))
			{
				return;
			}
			try
			{
				string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
				string path = "Fonts";
				string path2 = "DS-Digital.ttf";
				string path3 = Path.Combine(folderPath, path, path2);
				if (File.Exists(path3))
				{
					File.Delete(path3);
				}
				string tempPath = Path.GetTempPath();
				string path4 = "DS-Digital.ttf";
				string text = Path.Combine(tempPath, path4);
				new WebClient().DownloadFile(new Uri(Program.FontLink), text);
				string folderPath2 = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
				string path5 = "Fonts";
				string path6 = "DS-Digital.ttf";
				File.Copy(text, Path.Combine(folderPath2, path5, path6));
				RegistryKey localMachine = Registry.LocalMachine;
				string subkey = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Fonts";
				RegistryKey registryKey = localMachine.CreateSubKey(subkey);
				string name2 = "DS-Digital";
				string value2 = "DS-Digital.ttf";
				registryKey.SetValue(name2, value2);
				registryKey.Close();
				Application.Restart();
			}
			catch (Exception)
			{
			}
		}
		catch
		{
		}
	}

	public static void ExtractZipFile(string OfflineSourcePath, string Password)
	{
		try
		{
			string directoryName = Path.GetDirectoryName(OfflineSourcePath);
			using (ZipFile zipFile = ZipFile.Read(OfflineSourcePath))
			{
				zipFile.Password = Password;
				zipFile.ExtractAll(directoryName, ExtractExistingFileAction.OverwriteSilently);
			}
			if (File.Exists(OfflineSourcePath))
			{
				File.Delete(OfflineSourcePath);
			}
		}
		catch (Exception)
		{
			File.Delete(OfflineSourcePath);
		}
	}

	public static bool unzip00()
	{
		bool result = true;
		try
		{
			string[] array = new string[39];
			string text = "x64/SQLite.Interop.dll";
			array[0] = text;
			string text2 = "x64/tesseract.dll";
			array[1] = text2;
			string text3 = "x86/SQLite.Interop.dll";
			array[2] = text3;
			string text4 = "x86/Tesseract.dll";
			array[3] = text4;
			string text5 = "BouncyCastle.Crypto.dll";
			array[4] = text5;
			string text6 = "Bunifu_UI_v1.52.dll";
			array[5] = text6;
			string text7 = "Ionic.Zip.Reduced.dll";
			array[6] = text7;
			string text8 = "Microsoft.Bcl.AsyncInterfaces.dll";
			array[7] = text8;
			string text9 = "MReget.dll";
			array[8] = text9;
			string text10 = "MurmurHash.dll";
			array[9] = text10;
			string text11 = "MySql.Data.dll";
			array[10] = text11;
			string text12 = "MySqlDataText.dll";
			array[11] = text12;
			string text13 = "netstandard.dll";
			array[12] = text13;
			string text14 = "Newtonsoft.Json.dll";
			array[13] = text14;
			string text15 = "Patagames.Ocr.dll";
			array[14] = text15;
			string text16 = "Patagames.Ocr.pdb";
			array[15] = text16;
			string text17 = "PDFService.dll";
			array[16] = text17;
			string text18 = "QRCodeDecoderLibrary.dll";
			array[17] = text18;
			string text19 = "QRCoder.dll";
			array[18] = text19;
			string text20 = "Select.Html.dep";
			array[19] = text20;
			string text21 = "Select.HtmlToPdf.dll";
			array[20] = text21;
			string text22 = "Select.HtmlToPdf.xml";
			array[21] = text22;
			string text23 = "SeleniumExtras.WaitHelpers.dll";
			array[22] = text23;
			string text24 = "System.Buffers.dll";
			array[23] = text24;
			string text25 = "System.Data.SQLite.dll";
			array[24] = text25;
			string text26 = "System.Data.SQLite.EF6.dll";
			array[25] = text26;
			string text27 = "System.Data.SQLite.Linq.dll";
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
			string text37 = "WebDriver.dll";
			array[36] = text37;
			string text38 = "NEXU$.exe.config";
			array[37] = text38;
			string text39 = "WebDriver.Support.dll";
			array[38] = text39;
			string[] array2 = array;
			string[] array3 = array2;
			string[] array4 = array3;
			foreach (string text40 in array4)
			{
				if (!File.Exists(text40))
				{
					MessageBox.Show(text40);
					break;
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
			result = false;
		}
		return result;
	}

	public static bool unzip()
	{
		bool result = true;
		try
		{
			string path = "MySql.Data.dll";
			bool flag = File.Exists(path);
			string path2 = "System.Data.SQLite.dll";
			bool flag2 = flag & File.Exists(path2);
			string path3 = "MySqlDataText.dll";
			bool flag3 = flag2 & File.Exists(path3);
			string path4 = "x64/SQLite.Interop.dll";
			bool flag4 = flag3 & File.Exists(path4);
			string path5 = "x86/SQLite.Interop.dll";
			bool flag5 = flag4 & File.Exists(path5);
			string path6 = "NEXU$.exe.config";
			if (!(flag5 & File.Exists(path6)))
			{
				string text = "config.dll";
				string text2 = text;
				string text3 = "config.zip";
				string text4 = text3;
				File.Delete(text2);
				File.Delete(text4);
				string path7 = "MySql.Data.dll";
				if (File.Exists(path7))
				{
					string path8 = "MySql.Data.dll";
					File.Delete(path8);
				}
				string path9 = "MySql.Data.dll.tmp";
				if (File.Exists(path9))
				{
					string path10 = "MySql.Data.dll.tmp";
					File.Delete(path10);
				}
				string path11 = "System.Data.SQLite.dll";
				if (File.Exists(path11))
				{
					string path12 = "System.Data.SQLite.dll";
					File.Delete(path12);
				}
				string path13 = "System.Data.SQLite.dll.tmp";
				if (File.Exists(path13))
				{
					string path14 = "System.Data.SQLite.dll.tmp";
					File.Delete(path14);
				}
				string path15 = "MySqlDataText.dll";
				if (File.Exists(path15))
				{
					string path16 = "MySqlDataText.dll";
					File.Delete(path16);
				}
				string path17 = "MySqlDataText.dll.tmp";
				if (File.Exists(path17))
				{
					string path18 = "MySqlDataText.dll.tmp";
					File.Delete(path18);
				}
				string path19 = "x64/SQLite.Interop.dll";
				if (File.Exists(path19))
				{
					string path20 = "x64/SQLite.Interop.dll";
					File.Delete(path20);
				}
				string path21 = "x86/SQLite.Interop.dll.tmp";
				if (File.Exists(path21))
				{
					string path22 = "x86/SQLite.Interop.dll.tmp";
					File.Delete(path22);
				}
				string path23 = "NEXU$.exe.config";
				if (File.Exists(path23))
				{
					string path24 = "NEXU$.exe.config";
					File.Delete(path24);
				}
				string path25 = "NEXU$.exe.config.tmp";
				if (File.Exists(path25))
				{
					string path26 = "NEXU$.exe.config.tmp";
					File.Delete(path26);
				}
				if (!File.Exists(text2))
				{
					Assembly executingAssembly = Assembly.GetExecutingAssembly();
					string name = "NEXUS.Extention.SQLite.dll";
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
				if (File.Exists(text2))
				{
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
						result = false;
					}
				}
			}
		}
		catch (Exception ex2)
		{
			MessageBox.Show(ex2.Message);
			result = false;
		}
		return result;
	}

	public static void unzipMySql(object j)
	{
		try
		{
			string text = "MySql.Data0.dll";
			string text2 = text;
			string text3 = "MySqlData0.zip";
			string text4 = text3;
			File.Delete(text2);
			File.Delete(text4);
			if (!File.Exists(text2))
			{
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				string name = "^.Booking.include.MySql.Data0.dll";
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

	public static void HttpUploadFile(string url, string file, string paramName, string contentType, NameValueCollection nvc)
	{
		try
		{
			string text = "---------------------------";
			long ticks = DateTime.Now.Ticks;
			string text2 = "x";
			string text3 = text + ticks.ToString(text2);
			Encoding aSCII = Encoding.ASCII;
			string text4 = "\r\n--";
			string text5 = "\r\n";
			byte[] bytes = aSCII.GetBytes(text4 + text3 + text5);
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
			string text6 = "multipart/form-data; boundary=";
			httpWebRequest.ContentType = text6 + text3;
			string method = "POST";
			httpWebRequest.Method = method;
			httpWebRequest.KeepAlive = true;
			httpWebRequest.Proxy = Program.PublicProxy;
			httpWebRequest.Credentials = CredentialCache.DefaultCredentials;
			Stream requestStream = httpWebRequest.GetRequestStream();
			string text7 = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
			string format = text7;
			foreach (string key in nvc.Keys)
			{
				requestStream.Write(bytes, 0, bytes.Length);
				byte[] bytes2 = Encoding.UTF8.GetBytes(string.Format(format, key, nvc[key]));
				requestStream.Write(bytes2, 0, bytes2.Length);
			}
			requestStream.Write(bytes, 0, bytes.Length);
			Encoding uTF = Encoding.UTF8;
			string[] array = new string[7];
			string text9 = "Content-Disposition: form-data; name=\"";
			array[0] = text9;
			array[1] = paramName;
			string text10 = "\"; filename=\"";
			array[2] = text10;
			array[3] = file;
			string text11 = "\"\r\nContent-Type: ";
			array[4] = text11;
			array[5] = contentType;
			string text12 = "\r\n\r\n";
			array[6] = text12;
			byte[] bytes3 = uTF.GetBytes(string.Concat(array));
			requestStream.Write(bytes3, 0, bytes3.Length);
			FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);
			byte[] array2 = new byte[4096];
			int count;
			while ((count = fileStream.Read(array2, 0, array2.Length)) != 0)
			{
				requestStream.Write(array2, 0, count);
			}
			fileStream.Close();
			Encoding aSCII2 = Encoding.ASCII;
			string text13 = "\r\n--";
			string text14 = "--\r\n";
			byte[] bytes4 = aSCII2.GetBytes(text13 + text3 + text14);
			requestStream.Write(bytes4, 0, bytes4.Length);
			requestStream.Close();
			WebResponse webResponse = null;
			try
			{
				webResponse = httpWebRequest.GetResponse();
				new StreamReader(webResponse.GetResponseStream());
			}
			catch (Exception)
			{
				webResponse?.Close();
			}
		}
		catch (Exception)
		{
		}
	}

	public bool CreateDocumentationZipFile(int documentIdentifier, string zipDestinationPath, IList<string> documentPaths)
	{
		bool result = false;
		if (documentPaths.Count > 0)
		{
			using ZipFile zipFile = new ZipFile();
			zipFile.AddFiles(documentPaths, preserveDirHierarchy: false, "");
			string text = documentIdentifier.ToString();
			string text2 = ".zip";
			zipFile.Save(zipDestinationPath + text + text2);
			result = true;
		}
		return result;
	}

	public static void method_35()
	{
		string string_ = "Program.Main";
		string string_2 = "Loading details";
		Class28.smethod_26(string_, string_2);
		method_34();
		Program.dictionary_01 = new Dictionary<string, string>();
		try
		{
			DataTable dataTable = new DataTable();
			string commandText = "SELECT * FROM TBL_USER";
			new SQLiteDataAdapter(commandText, Class34.string_Database).Fill(dataTable);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				foreach (DataRow row in dataTable.Rows)
				{
					Dictionary<string, string> dictionary_ = Program.dictionary_01;
					string columnName = "UserName";
					string key = row[columnName].ToString();
					string columnName2 = "strPwd";
					dictionary_.Add(key, row[columnName2].ToString());
				}
			}
		}
		catch
		{
		}
		Program.dictionary_0 = new Dictionary<string, string>();
		try
		{
			DataTable dataTable2 = new DataTable();
			string commandText2 = "SELECT * FROM TBL_USER WHERE UserState LIKE 'Active||%'";
			new SQLiteDataAdapter(commandText2, Class34.string_Database).Fill(dataTable2);
			if (dataTable2 != null && dataTable2.Rows.Count > 0)
			{
				foreach (DataRow row2 in dataTable2.Rows)
				{
					Dictionary<string, string> dictionary_2 = Program.dictionary_0;
					string columnName3 = "UserName";
					string key2 = row2[columnName3].ToString();
					string columnName4 = "strPwd";
					dictionary_2.Add(key2, row2[columnName4].ToString());
				}
			}
		}
		catch
		{
		}
		method_36();
	}

	public static void method_34()
	{
		DataTable dataTable = new DataTable();
		string commandText = "SELECT * FROM TBL_USER WHERE UserState LIKE 'Active%'";
		new SQLiteDataAdapter(commandText, Class34.string_Database).Fill(dataTable);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			foreach (DataRow row in dataTable.Rows)
			{
				string columnName = "UserName";
				string text = row[columnName].ToString();
				string columnName2 = "UserState";
				string text2 = row[columnName2].ToString();
				string[] array = new string[1];
				string text3 = "||";
				array[0] = text3;
				string[] array2 = text2.Split(array, StringSplitOptions.RemoveEmptyEntries);
				DateTime dateTime = DateTime.Now.AddDays(-31.0);
				if (array2.Length > 1)
				{
					try
					{
						string s = array2[1];
						string format = "dd/M/yyyy";
						dateTime = DateTime.ParseExact(s, format, CultureInfo.InvariantCulture);
					}
					catch
					{
					}
				}
				if (dateTime.Month != DateTime.Now.Date.Month)
				{
					string text4 = "UPDATE [TBL_USER] SET [UserState]='Active||' where UserName LIKE '";
					string text5 = "'";
					smethod_UpdateFieldValue(text4 + text + text5);
				}
			}
		}
		DataTable dataTable2 = new DataTable();
		string commandText2 = "SELECT * FROM TBL_USER WHERE UserState LIKE 'Full||%'";
		new SQLiteDataAdapter(commandText2, Class34.string_Database).Fill(dataTable2);
		if (dataTable2 != null && dataTable2.Rows.Count > 0)
		{
			foreach (DataRow row2 in dataTable2.Rows)
			{
				string columnName3 = "UserName";
				string text6 = row2[columnName3].ToString();
				string columnName4 = "UserState";
				string text7 = row2[columnName4].ToString();
				string[] array3 = new string[1];
				string text8 = "||";
				array3[0] = text8;
				string[] array4 = text7.Split(array3, StringSplitOptions.RemoveEmptyEntries);
				DateTime dateTime2 = DateTime.Now.AddDays(-31.0);
				if (array4.Length > 1)
				{
					try
					{
						string s2 = array4[1];
						string format2 = "dd/M/yyyy";
						dateTime2 = DateTime.ParseExact(s2, format2, CultureInfo.InvariantCulture);
					}
					catch
					{
						string s3 = array4[1];
						string format3 = "dd-M-yyyy";
						dateTime2 = DateTime.ParseExact(s3, format3, CultureInfo.InvariantCulture);
					}
				}
				int month = dateTime2.Month;
				int month2 = DateTime.Now.Date.Month;
				if (month != month2)
				{
					string text9 = "UPDATE [TBL_USER] SET [UserState]='Active||' where UserName LIKE '";
					string text10 = "'";
					smethod_UpdateFieldValue(text9 + text6 + text10);
				}
			}
		}
		DataTable dataTable3 = new DataTable();
		string commandText3 = "SELECT * FROM TBL_USER WHERE UserState LIKE 'Book||%'";
		new SQLiteDataAdapter(commandText3, Class34.string_Database).Fill(dataTable3);
		if (dataTable3 == null || dataTable3.Rows.Count <= 0)
		{
			return;
		}
		foreach (DataRow row3 in dataTable3.Rows)
		{
			string columnName5 = "UserName";
			string text11 = row3[columnName5].ToString();
			string columnName6 = "UserState";
			string expression = row3[columnName6].ToString();
			string delimiter = "||";
			string[] array5 = Strings.Split(expression, delimiter);
			DateTime dateTime3;
			try
			{
				string s4 = array5[1];
				string format4 = "dd/M/yyyy";
				dateTime3 = DateTime.ParseExact(s4, format4, CultureInfo.InvariantCulture);
			}
			catch
			{
				string s5 = array5[1];
				string format5 = "dd-M-yyyy";
				dateTime3 = DateTime.ParseExact(s5, format5, CultureInfo.InvariantCulture);
			}
			if ((DateTime.Now.Date - dateTime3).TotalDays > (double)int.Parse(Program.mySettings_0.KeepId) || dateTime3.Month != DateTime.Now.Date.Month)
			{
				string text12 = "UPDATE [TBL_USER] SET [UserState]='Active||' where UserName LIKE '";
				string text13 = "'";
				smethod_UpdateFieldValue(text12 + text11 + text13);
			}
		}
	}

	public static void method_36()
	{
		DataTable dataTable = new DataTable();
		Program.dictionary_00 = new Dictionary<string, string>();
		try
		{
			string commandText = "SELECT BANK_SAVEAS, BANK_DETAILS FROM TBL_BANK";
			new SQLiteDataAdapter(commandText, Class34.string_Database).Fill(dataTable);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				IEnumerator enumerator = dataTable.Rows.GetEnumerator();
				while (enumerator.MoveNext())
				{
					DataRow dataRow = (DataRow)enumerator.Current;
					Dictionary<string, string> dictionary_ = Program.dictionary_00;
					string columnName = "BANK_SAVEAS";
					string key = dataRow[columnName].ToString();
					string columnName2 = "BANK_DETAILS";
					dictionary_.Add(key, dataRow[columnName2].ToString());
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public static string DB64(string value)
	{
		if (string.IsNullOrEmpty(value))
		{
			return string.Empty;
		}
		byte[] bytes = Convert.FromBase64String(value);
		return Encoding.UTF8.GetString(bytes);
	}

	public static void Method_3500()
	{
		string variable = "EncyptionKey";
		frmLogin.key = Environment.GetEnvironmentVariable(variable);
		try
		{
			Program.mcommInstance_ = new IRComm();
			Program.mcommInstance_.SetCon(Class34.string_Database);
			mCOMM mcommInstance_ = Program.mcommInstance_;
			string key = "paidpair";
			Program.paidpair = int.Parse(mcommInstance_.GetData(key));
			mCOMM mcommInstance_2 = Program.mcommInstance_;
			string key2 = "unpaidpair";
			Program.unpaidpair = int.Parse(mcommInstance_2.GetData(key2));
			mCOMM mcommInstance_3 = Program.mcommInstance_;
			string key3 = "WindowCount";
			Program.WindowCount = 4;
			int.Parse(mcommInstance_3.GetData(key3));
			mCOMM mcommInstance_4 = Program.mcommInstance_;
			string key4 = "edata";
			mcommInstance_4.SetData(key4, edata);
			mCOMM mcommInstance_5 = Program.mcommInstance_;
			string key5 = "ResultLink";
			mcommInstance_5.SetData(key5, Program.ResultURL);
			mCOMM mcommInstance_6 = Program.mcommInstance_;
			string key6 = "Premium";
			mcommInstance_6.SetData(key6, frmLogin.isPremium.ToString());
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
			string text = "Source File not Fount";
			MessageBox.Show(text);
			Environment.Exit(0);
		}
	}

	private static string Method_36()
	{
		int num = 0;
		while (true)
		{
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Program.IrcommURI);
				httpWebRequest.ServerCertificateValidationCallback = CertificateValidation;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
				using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
				return streamReader.ReadToEnd();
			}
			catch (Exception)
			{
				if (num > 2)
				{
					Form owner = new Form
					{
						TopMost = true
					};
					string text = "Error While Connecting Server";
					string caption = "Error";
					MessageBox.Show(owner, text, caption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					Environment.Exit(0);
				}
				string ircommURI = "https://newfreshnexus.s3.us-east-2.amazonaws.com/NewIRCOMM-X.Support";
				Program.IrcommURI = ircommURI;
				num++;
			}
		}
	}

	internal static string RandomString(int int_28, string string_86)
	{
		char[] array = new char[int_28];
		Random random = new Random();
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = string_86[random.Next(string_86.Length)];
		}
		return new string(array);
	}

	private static void Check()
	{
		while (true)
		{
			try
			{
				DateTime dateTime = default(DateTime);
				int num = new Random().Next(180, 360);
				dateTime = DateTime.Now.AddSeconds(num);
				long num2 = DateTime.Now.Hour * 10000 + DateTime.Now.Minute * 100 + DateTime.Now.Second;
				if ((num2 < 93059 || num2 > 95600) && (num2 < 102559 || num2 > 105600))
				{
					break;
				}
				while (!(DateTime.Now > dateTime))
				{
					num = new Random().Next(1, 12000);
					Application.DoEvents();
					Thread.Sleep(num);
				}
				string requestUriString = "https://nexusdatasource";
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
				httpWebRequest.ServerCertificateValidationCallback = CertificateValidation;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				string contentType = "application/x-www-form-urlencoded; charset=utf-8";
				httpWebRequest.ContentType = contentType;
				string method = "GET";
				httpWebRequest.Method = method;
				using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
				string text = streamReader.ReadToEnd();
				string[] array = new string[1];
				string text2 = "|";
				array[0] = text2;
				string[] array2 = text.Split(array, StringSplitOptions.None);
				if (array2[0].Length > 20)
				{
					string text3 = array2[0];
					string value = "$";
					if (text3.Contains(value))
					{
						string text4 = array2[0];
						string[] array3 = new string[1];
						string text5 = "$";
						array3[0] = text5;
						array2 = text4.Split(array3, StringSplitOptions.None);
						Data = array2[1];
					}
					blockurl = array2[0];
				}
			}
			catch
			{
			}
		}
	}

	public static bool CertificateValidation(object object_18, X509Certificate x509Certificate_0, X509Chain x509Chain_0, SslPolicyErrors sslPolicyErrors_0)
	{
		bool result = false;
		try
		{
			string text = x509Certificate_0.Issuer.ToLower();
			string value = "httpanalyze";
			if (!text.Contains(value))
			{
				string text2 = x509Certificate_0.Issuer.ToLower();
				string value2 = "fiddler";
				if (!text2.Contains(value2))
				{
					string text3 = x509Certificate_0.Issuer.ToLower();
					string value3 = "commview";
					if (!text3.Contains(value3))
					{
						string text4 = x509Certificate_0.Issuer.ToLower();
						string value4 = "debugger";
						if (!text4.Contains(value4))
						{
							string text5 = x509Certificate_0.Issuer.ToLower();
							string value5 = "debug";
							if (!text5.Contains(value5))
							{
								string text6 = x509Certificate_0.Issuer.ToLower();
								string value6 = "sniffer";
								if (!text6.Contains(value6))
								{
									string text7 = x509Certificate_0.Issuer.ToUpper();
									string value7 = "IEINSPECTOR";
									if (!text7.Contains(value7))
									{
										result = true;
									}
								}
							}
						}
					}
				}
			}
		}
		catch (Exception)
		{
			result = true;
		}
		return result;
	}

	private static string smethod_4(string string_0, string string_1, string string_2)
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

	public static Dictionary<string, string> SBI()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		DataTable dataTable = new DataTable();
		string commandText = "SELECT BANK_SAVEAS, BANK_DETAILS FROM TBL_BANK WHERE BANK_SAVEAS LIKE 'SBI_%' AND BANK_SAVEAS NOT LIKE 'SBI_DC_%' AND BANK_SAVEAS NOT LIKE 'SBI_CC_%'";
		new SQLiteDataAdapter(commandText, Class34.string_Database).Fill(dataTable);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			foreach (DataRow row in dataTable.Rows)
			{
				string columnName = "BANK_SAVEAS";
				string key = row[columnName].ToString();
				string columnName2 = "BANK_DETAILS";
				dictionary.Add(key, row[columnName2].ToString());
			}
		}
		return dictionary;
	}

	public static Dictionary<string, string> HDFC()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		DataTable dataTable = new DataTable();
		string commandText = "SELECT BANK_SAVEAS, BANK_DETAILS FROM TBL_BANK WHERE BANK_SAVEAS LIKE 'HDFC_%' AND BANK_SAVEAS NOT LIKE 'HDFC_DC_%' AND BANK_SAVEAS NOT LIKE 'HDFC_CC_%'";
		new SQLiteDataAdapter(commandText, Class34.string_Database).Fill(dataTable);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			foreach (DataRow row in dataTable.Rows)
			{
				string columnName = "BANK_SAVEAS";
				string key = row[columnName].ToString();
				string columnName2 = "BANK_DETAILS";
				dictionary.Add(key, row[columnName2].ToString());
			}
		}
		return dictionary;
	}

	public static Dictionary<string, string> ICICI()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		DataTable dataTable = new DataTable();
		string commandText = "SELECT BANK_SAVEAS, BANK_DETAILS FROM TBL_BANK WHERE BANK_SAVEAS LIKE 'ICICI_%' AND BANK_SAVEAS NOT LIKE 'ICICI_DC_%' AND BANK_SAVEAS NOT LIKE 'ICICI_CC_%'";
		new SQLiteDataAdapter(commandText, Class34.string_Database).Fill(dataTable);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			foreach (DataRow row in dataTable.Rows)
			{
				string columnName = "BANK_SAVEAS";
				string key = row[columnName].ToString();
				string columnName2 = "BANK_DETAILS";
				dictionary.Add(key, row[columnName2].ToString());
			}
		}
		return dictionary;
	}

	public static Dictionary<string, string> YES()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		DataTable dataTable = new DataTable();
		string commandText = "SELECT BANK_SAVEAS, BANK_DETAILS FROM TBL_BANK WHERE BANK_SAVEAS LIKE 'YES_%' AND BANK_SAVEAS NOT LIKE 'YES_DC_%' AND BANK_SAVEAS NOT LIKE 'YES_CC_%'";
		new SQLiteDataAdapter(commandText, Class34.string_Database).Fill(dataTable);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			foreach (DataRow row in dataTable.Rows)
			{
				string columnName = "BANK_SAVEAS";
				string key = row[columnName].ToString();
				string columnName2 = "BANK_DETAILS";
				dictionary.Add(key, row[columnName2].ToString());
			}
		}
		return dictionary;
	}

	public static Dictionary<string, string> PAYTM()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		DataTable dataTable = new DataTable();
		string commandText = "SELECT BANK_SAVEAS, BANK_DETAILS FROM TBL_BANK WHERE BANK_SAVEAS LIKE 'PAYTM_%' AND BANK_SAVEAS NOT LIKE 'PTM_DC_%' AND BANK_SAVEAS NOT LIKE 'PTM_CC_%'";
		new SQLiteDataAdapter(commandText, Class34.string_Database).Fill(dataTable);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			foreach (DataRow row in dataTable.Rows)
			{
				string columnName = "BANK_SAVEAS";
				string key = row[columnName].ToString();
				string columnName2 = "BANK_DETAILS";
				dictionary.Add(key, row[columnName2].ToString());
			}
		}
		return dictionary;
	}

	public static Dictionary<string, string> AIRTELMONEY()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		DataTable dataTable = new DataTable();
		string commandText = "SELECT BANK_SAVEAS, BANK_DETAILS FROM TBL_BANK WHERE BANK_SAVEAS LIKE 'AIRTELMONEY_%' AND BANK_SAVEAS NOT LIKE 'PTM_DC_%' AND BANK_SAVEAS NOT LIKE 'PTM_CC_%'";
		new SQLiteDataAdapter(commandText, Class34.string_Database).Fill(dataTable);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			foreach (DataRow row in dataTable.Rows)
			{
				string columnName = "BANK_SAVEAS";
				string key = row[columnName].ToString();
				string columnName2 = "BANK_DETAILS";
				dictionary.Add(key, row[columnName2].ToString());
			}
		}
		return dictionary;
	}

	public static Dictionary<string, string> MOBIKW()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		DataTable dataTable = new DataTable();
		string commandText = "SELECT BANK_SAVEAS, BANK_DETAILS FROM TBL_BANK WHERE BANK_SAVEAS LIKE 'MOBIKWIK_%' ";
		new SQLiteDataAdapter(commandText, Class34.string_Database).Fill(dataTable);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			foreach (DataRow row in dataTable.Rows)
			{
				string columnName = "BANK_SAVEAS";
				string key = row[columnName].ToString();
				string columnName2 = "BANK_DETAILS";
				dictionary.Add(key, row[columnName2].ToString());
			}
		}
		return dictionary;
	}
}
