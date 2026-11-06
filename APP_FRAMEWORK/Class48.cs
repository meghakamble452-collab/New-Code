using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace APP_FRAMEWORK;

[Browsable(false)]
[DesignTimeVisible(false)]
[EditorBrowsable(EditorBrowsableState.Never)]
internal class Class48
{
	internal string string_0;

	internal string string_0a;

	internal string string_1;

	internal string string_1a;

	internal string string_2;

	internal string string_2a;

	internal string string_3;

	internal string string_4;

	internal string string_5;

	internal string string_6;

	internal string string_7;

	internal string string_8;

	internal string string_9;

	internal bool bool_1;

	internal List<Class38> list_0;

	internal List<Class38> list_1;

	internal bool bool_2;

	internal bool bool_3;

	internal string string_10;

	internal string mobile_num;

	internal string adress_;

	internal string state_;

	internal string pincode_;

	internal string city_;

	internal string postoffice_;

	internal string string_12;

	internal string string_13;

	internal string string_14;

	internal string mob_num;

	internal string string_15;

	internal string string_16;

	internal string string_17;

	internal string string_18;

	internal string string_19;

	internal string string_20;

	internal string string_21;

	internal string string_22;

	internal string string_23;

	internal string string_233;

	internal string string_24;

	internal string string_244;

	internal bool bool_4;

	internal bool bool_5;

	internal int int_0;

	internal string string_25;

	internal string string_40;

	internal Rectangle rectangle_0;

	internal bool bool_6;

	internal bool bool_7;

	internal bool bool_8;

	internal bool bool_9;

	internal string string_26;

	internal string string_27;

	internal string string_28;

	internal string string_29;

	internal string string_30;

	internal string string_31;

	internal string string_32;

	internal string string_33;

	internal string string_34;

	internal string string_35;

	internal string string_36;

	internal string string_37;

	internal string string_38;

	internal string string_39;

	public Class48()
	{
		string text = "E_TICKET";
		string_9 = text;
		string_10 = "";
		string_15 = "";
		string_16 = "";
		string_17 = "";
		string_18 = "";
		string_19 = "";
		string_20 = "";
		string_21 = "";
		string_23 = "";
		string_233 = "";
		string_24 = "";
		string_244 = "";
		string_25 = "";
		string_40 = "";
		list_0 = new List<Class38>();
		list_1 = new List<Class38>();
	}

	public Class48(string string_26)
	{
		string text = "E_TICKET";
		string_9 = text;
		string_10 = "";
		string_15 = "";
		string_16 = "";
		string_17 = "";
		string_18 = "";
		string_19 = "";
		string_20 = "";
		string_21 = "";
		string_23 = "";
		string_233 = "";
		string_24 = "";
		string_244 = "";
		string_25 = "";
		string_40 = "";
		method_0(string_26);
	}

	internal bool method_0(string string_26)
	{
		bool result = false;
		try
		{
			DataTable dataTable = new DataTable();
			string text = "SELECT RID,SRC_STN,DEST_STN,BRD_STN,TRAIN_NO,TKT_DAY,TKT_MONTH,TKT_YEAR,TKT_CLASS,TKT_QUOTA,TKT_TRNTYPE,TKT_TRDAY,TKT_ISADV,TKT_ISCONFIRM,TKT_ISAUTOUPGRD,TKT_ISBEDROLL,TKT_COACH,TKT_MOBILE,TKT_IRCTCID,TKT_PWD,TKT_SLOT,TKT_PAYMENT,TKT_BANKSAVEAS,TKT_BANKDETAILS,TKT_FAREDETAILS,TKT_ISRET,TKT_ISPRI,RSRC_STN,RDEST_STN,RBRD_STN,RTRAIN_NO,RTKT_DAY,RTKT_MONTH,RTKT_YEAR,RTKT_CLASS,RTKT_QUOTA,RTKT_TRNTYPE,RTKT_TRDAY,TR_LIST,RTR_LIST,TKT_STOPPAY FROM TBL_TKT WHERE TKT_NAME = '";
			string text2 = "'";
			new SQLiteDataAdapter(text + string_26 + text2, Class34.string_Database).Fill(dataTable);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				DataRow dataRow = dataTable.Rows[0];
				string columnName = "RID";
				int.Parse(dataRow[columnName].ToString());
				string columnName2 = "SRC_STN";
				string_0 = dataRow[columnName2].ToString();
				string columnName3 = "DEST_STN";
				string_1 = dataRow[columnName3].ToString();
				string columnName4 = "TRAIN_NO";
				string_2 = dataRow[columnName4].ToString();
				string columnName5 = "BRD_STN";
				string_3 = dataRow[columnName5].ToString();
				string columnName6 = "TKT_DAY";
				string_4 = dataRow[columnName6].ToString();
				string columnName7 = "TKT_MONTH";
				string_5 = dataRow[columnName7].ToString();
				string columnName8 = "TKT_YEAR";
				string_6 = dataRow[columnName8].ToString();
				string columnName9 = "TKT_CLASS";
				string_7 = dataRow[columnName9].ToString();
				string columnName10 = "TKT_QUOTA";
				string_8 = dataRow[columnName10].ToString();
				string columnName11 = "TKT_ISBEDROLL";
				bool_1 = bool.Parse(dataRow[columnName11].ToString());
				string columnName12 = "TKT_ISAUTOUPGRD";
				bool_2 = bool.Parse(dataRow[columnName12].ToString());
				string columnName13 = "TKT_ISCONFIRM";
				bool_3 = bool.Parse(dataRow[columnName13].ToString());
				string columnName14 = "TKT_STOPPAY";
				bool_6 = bool.Parse(dataRow[columnName14].ToString());
				string columnName15 = "TKT_ISADV";
				bool_8 = bool.Parse(dataRow[columnName15].ToString());
				string columnName16 = "TKT_COACH";
				string_10 = dataRow[columnName16].ToString();
				if (!string.IsNullOrEmpty(string_10))
				{
					string text3 = string_10;
					string value = ";";
					if (text3.Contains(value))
					{
						string text4 = string_10;
						string oldValue = ";";
						string_10 = text4.Replace(oldValue, "");
						bool_7 = true;
					}
				}
				string columnName17 = "TKT_MOBILE";
				string text5 = dataRow[columnName17].ToString();
				string[] array = new string[1];
				string text6 = "||";
				array[0] = text6;
				string[] array2 = text5.Split(array, StringSplitOptions.None);
				mobile_num = array2[0];
				adress_ = array2[1];
				pincode_ = array2[2];
				state_ = array2[3];
				city_ = array2[4];
				postoffice_ = array2[5];
				string_12 = string_26;
				string columnName18 = "TKT_IRCTCID";
				string_13 = dataRow[columnName18].ToString();
				string columnName19 = "TKT_PWD";
				string_14 = dataRow[columnName19].ToString();
				string columnName20 = "TKT_SLOT";
				string_15 = dataRow[columnName20].ToString();
				string columnName21 = "TKT_PAYMENT";
				string_22 = dataRow[columnName21].ToString();
				string columnName22 = "TKT_TRNTYPE";
				string_16 = dataRow[columnName22].ToString();
				string columnName23 = "TKT_TRDAY";
				string_17 = dataRow[columnName23].ToString();
				string columnName24 = "TKT_BANKSAVEAS";
				string_23 = dataRow[columnName24].ToString();
				string text7 = string_23;
				string value2 = "-+-";
				if (text7.Contains(value2))
				{
					string text8 = string_23;
					string text9 = string_23;
					string value3 = "-+-";
					string_233 = text8.Substring(text9.IndexOf(value3) + 3);
					string text10 = string_23;
					string text11 = string_23;
					string value4 = "-+-";
					string_23 = text10.Substring(0, text11.IndexOf(value4));
				}
				string columnName25 = "TKT_BANKDETAILS";
				string_24 = dataRow[columnName25].ToString();
				string text12 = string_24;
				string value5 = "-+-";
				if (text12.Contains(value5))
				{
					string text13 = string_24;
					string text14 = string_24;
					string value6 = "-+-";
					string_244 = text13.Substring(text14.IndexOf(value6) + 3);
					string text15 = string_24;
					string text16 = string_24;
					string value7 = "-+-";
					string_24 = text15.Substring(0, text16.IndexOf(value7));
				}
				string columnName26 = "TKT_FAREDETAILS";
				string_25 = dataRow[columnName26].ToString();
				string columnName27 = "TKT_ISRET";
				this.string_26 = dataRow[columnName27].ToString();
				string columnName28 = "TKT_ISPRI";
				bool_9 = bool.Parse(dataRow[columnName28].ToString());
				string columnName29 = "RSRC_STN";
				string_27 = dataRow[columnName29].ToString();
				string columnName30 = "RDEST_STN";
				string_28 = dataRow[columnName30].ToString();
				string columnName31 = "RTRAIN_NO";
				string_29 = dataRow[columnName31].ToString();
				string columnName32 = "RBRD_STN";
				string_30 = dataRow[columnName32].ToString();
				string columnName33 = "RTKT_DAY";
				string_31 = dataRow[columnName33].ToString();
				string columnName34 = "RTKT_MONTH";
				string_32 = dataRow[columnName34].ToString();
				string columnName35 = "RTKT_YEAR";
				string_33 = dataRow[columnName35].ToString();
				string columnName36 = "RTKT_CLASS";
				string_34 = dataRow[columnName36].ToString();
				string columnName37 = "RTKT_QUOTA";
				string_35 = dataRow[columnName37].ToString();
				string columnName38 = "RTKT_TRNTYPE";
				string_36 = dataRow[columnName38].ToString();
				string columnName39 = "RTKT_TRDAY";
				string_37 = dataRow[columnName39].ToString();
				string columnName40 = "TR_LIST";
				string_38 = dataRow[columnName40].ToString();
				string columnName41 = "RTR_LIST";
				string_39 = dataRow[columnName41].ToString();
				bool_4 = false;
				string_18 = "";
				string_19 = "";
				list_0 = new List<Class38>();
				list_1 = new List<Class38>();
				dataTable.Dispose();
				DataTable dataTable2 = new DataTable();
				string text17 = "SELECT PAX_NAME,PAX_AGE,PAX_SEX,PAX_BIRTH,PAX_FOOD,PAX_IDTYPE,PAX_IDNO,PAX_CONC FROM TBL_PAX WHERE TKT_ID = '";
				string text18 = "'";
				new SQLiteDataAdapter(text17 + string_26 + text18, Class34.string_Database).Fill(dataTable2);
				foreach (DataRow row in dataTable2.Rows)
				{
					string columnName42 = "PAX_BIRTH";
					if (row[columnName42] != null)
					{
						string columnName43 = "PAX_BIRTH";
						if (row[columnName43].GetType() != typeof(DBNull))
						{
							string columnName44 = "PAX_BIRTH";
							if (!string.IsNullOrEmpty(row[columnName44].ToString()))
							{
								List<Class38> list = list_0;
								Class38 @class = new Class38();
								string columnName45 = "PAX_NAME";
								@class.string_0 = row[columnName45].ToString();
								string columnName46 = "PAX_AGE";
								@class.string_1 = row[columnName46].ToString();
								string columnName47 = "PAX_SEX";
								@class.string_2 = row[columnName47].ToString();
								string columnName48 = "PAX_BIRTH";
								@class.string_3 = row[columnName48].ToString();
								string columnName49 = "PAX_FOOD";
								@class.string_5 = row[columnName49].ToString();
								string columnName50 = "PAX_IDTYPE";
								@class.string_6 = row[columnName50].ToString();
								string columnName51 = "PAX_IDNO";
								@class.string_7 = row[columnName51].ToString();
								string columnName52 = "PAX_CONC";
								@class.string_4 = row[columnName52].ToString();
								list.Add(@class);
								continue;
							}
						}
					}
					List<Class38> list2 = list_1;
					Class38 class2 = new Class38();
					string columnName53 = "PAX_NAME";
					class2.string_0 = row[columnName53].ToString();
					string columnName54 = "PAX_AGE";
					class2.string_1 = row[columnName54].ToString();
					string columnName55 = "PAX_SEX";
					class2.string_2 = row[columnName55].ToString();
					list2.Add(class2);
				}
				result = true;
			}
			else
			{
				string text19 = "Ticket Not Found!";
				MessageBox.Show(text19);
			}
		}
		catch (Exception)
		{
			string text20 = "Ticket Reading Failed!";
			MessageBox.Show(text20);
		}
		return result;
	}

	public bool method_1()
	{
		bool result = false;
		SQLiteConnection sQLiteConnection = new SQLiteConnection(Class34.string_Database);
		SQLiteTransaction sQLiteTransaction = null;
		if (bool_7)
		{
			string text = string_10;
			string text2 = ";";
			string_10 = text + text2;
		}
		string[] array = new string[83];
		string text3 = "INSERT INTO TBL_TKT(TKT_NAME,SRC_STN,DEST_STN,BRD_STN,TRAIN_NO,TKT_DAY,TKT_MONTH,TKT_YEAR,TKT_CLASS,TKT_QUOTA,TKT_TRNTYPE,TKT_TRDAY,TKT_ISADV,TKT_ISCONFIRM,TKT_ISAUTOUPGRD,TKT_ISBEDROLL,TKT_COACH,TKT_MOBILE,TKT_IRCTCID,TKT_PWD,TKT_SLOT,TKT_PAYMENT,TKT_BANKSAVEAS,TKT_BANKDETAILS,TKT_FAREDETAILS,TKT_ISRET,TKT_ISPRI,RSRC_STN,RDEST_STN,RBRD_STN,RTRAIN_NO,RTKT_DAY,RTKT_MONTH,RTKT_YEAR,RTKT_CLASS,RTKT_QUOTA,RTKT_TRNTYPE,RTKT_TRDAY,TR_LIST,RTR_LIST,TKT_STOPPAY,WebLog,AppLog) VALUES('";
		array[0] = text3;
		array[1] = string_12;
		string text4 = "','";
		array[2] = text4;
		array[3] = string_0;
		string text5 = "','";
		array[4] = text5;
		array[5] = string_1;
		string text6 = "','";
		array[6] = text6;
		array[7] = string_3;
		string text7 = "','";
		array[8] = text7;
		array[9] = string_2;
		string text8 = "','";
		array[10] = text8;
		array[11] = string_4;
		string text9 = "', '";
		array[12] = text9;
		array[13] = string_5;
		string text10 = "','";
		array[14] = text10;
		array[15] = string_6;
		string text11 = "','";
		array[16] = text11;
		array[17] = string_7;
		string text12 = "','";
		array[18] = text12;
		array[19] = string_8;
		string text13 = "','";
		array[20] = text13;
		array[21] = string_16;
		string text14 = "','";
		array[22] = text14;
		array[23] = string_17;
		string text15 = "','";
		array[24] = text15;
		array[25] = false.ToString();
		string text16 = "','";
		array[26] = text16;
		bool flag = bool_3;
		array[27] = flag.ToString();
		string text17 = "','";
		array[28] = text17;
		flag = bool_2;
		array[29] = flag.ToString();
		string text18 = "','";
		array[30] = text18;
		flag = bool_1;
		array[31] = flag.ToString();
		string text19 = "','";
		array[32] = text19;
		array[33] = string_10;
		string text20 = "','";
		array[34] = text20;
		array[35] = mobile_num;
		string text21 = "','";
		array[36] = text21;
		array[37] = string_13;
		string text22 = "','";
		array[38] = text22;
		array[39] = string_14;
		string text23 = "','";
		array[40] = text23;
		array[41] = string_15;
		string text24 = "','";
		array[42] = text24;
		array[43] = string_22;
		string text25 = "','";
		array[44] = text25;
		array[45] = string_23;
		string text26 = "','";
		array[46] = text26;
		array[47] = string_24;
		string text27 = "','";
		array[48] = text27;
		array[49] = string_25;
		string text28 = "','";
		array[50] = text28;
		array[51] = string_26;
		string text29 = "','";
		array[52] = text29;
		flag = bool_9;
		array[53] = flag.ToString();
		string text30 = "','";
		array[54] = text30;
		array[55] = string_27;
		string text31 = "','";
		array[56] = text31;
		array[57] = string_28;
		string text32 = "','";
		array[58] = text32;
		array[59] = string_29;
		string text33 = "','";
		array[60] = text33;
		array[61] = string_30;
		string text34 = "','";
		array[62] = text34;
		array[63] = string_31;
		string text35 = "','";
		array[64] = text35;
		array[65] = string_32;
		string text36 = "','";
		array[66] = text36;
		array[67] = string_33;
		string text37 = "','";
		array[68] = text37;
		array[69] = string_34;
		string text38 = "','";
		array[70] = text38;
		array[71] = string_35;
		string text39 = "','";
		array[72] = text39;
		array[73] = string_36;
		string text40 = "','";
		array[74] = text40;
		array[75] = string_37;
		string text41 = "','";
		array[76] = text41;
		array[77] = string_38;
		string text42 = "','";
		array[78] = text42;
		array[79] = string_39;
		string text43 = "','";
		array[80] = text43;
		array[81] = bool_6.ToString();
		string text44 = "','PAX=0|CAP=0|BNK=0','PAX=0|CAP=0|BNK=0')";
		array[82] = text44;
		string commandText = string.Concat(array);
		try
		{
			sQLiteConnection.Open();
			sQLiteTransaction = sQLiteConnection.BeginTransaction();
			SQLiteCommand sQLiteCommand = new SQLiteCommand(commandText, sQLiteConnection, sQLiteTransaction);
			if (sQLiteCommand.ExecuteNonQuery() > 0)
			{
				string text45 = "SELECT RID FROM TBL_TKT WHERE TKT_NAME = '";
				string text46 = string_12;
				string text47 = "' LIMIT 1";
				sQLiteCommand.CommandText = text45 + text46 + text47;
				object obj = sQLiteCommand.ExecuteScalar();
				if (obj != null && obj.GetType() != typeof(DBNull))
				{
					int num = int.Parse(obj.ToString());
					foreach (Class38 item in list_0)
					{
						string[] array2 = new string[19];
						string text48 = "INSERT INTO TBL_PAX (PAX_NAME,PAX_AGE,PAX_SEX,PAX_BIRTH,PAX_FOOD,PAX_IDTYPE,PAX_IDNO,PAX_CONC,TKT_ID) VALUES ('";
						array2[0] = text48;
						array2[1] = item.string_0;
						string text49 = "','";
						array2[2] = text49;
						array2[3] = item.string_1;
						string text50 = "','";
						array2[4] = text50;
						array2[5] = item.string_2;
						string text51 = "','";
						array2[6] = text51;
						array2[7] = item.string_3;
						string text52 = "','";
						array2[8] = text52;
						array2[9] = item.string_5;
						string text53 = "','";
						array2[10] = text53;
						array2[11] = item.string_6;
						string text54 = "','";
						array2[12] = text54;
						array2[13] = item.string_7;
						string text55 = "','";
						array2[14] = text55;
						array2[15] = item.string_4;
						string text56 = "','";
						array2[16] = text56;
						array2[17] = string_12;
						string text57 = "')";
						array2[18] = text57;
						sQLiteCommand.CommandText = string.Concat(array2);
						if (sQLiteCommand.ExecuteNonQuery() <= 0)
						{
							sQLiteTransaction.Rollback();
							string message = "Error While Inserting Passengers";
							throw new Exception(message);
						}
					}
					foreach (Class38 item2 in list_1)
					{
						string[] array3 = new string[9];
						string text58 = "INSERT INTO TBL_PAX (PAX_NAME,PAX_AGE,PAX_SEX,TKT_ID) VALUES ('";
						array3[0] = text58;
						array3[1] = item2.string_0;
						string text59 = "','";
						array3[2] = text59;
						array3[3] = item2.string_1;
						string text60 = "','";
						array3[4] = text60;
						array3[5] = item2.string_2;
						string text61 = "',";
						array3[6] = text61;
						array3[7] = num.ToString();
						string text62 = ")";
						array3[8] = text62;
						sQLiteCommand.CommandText = string.Concat(array3);
						if (sQLiteCommand.ExecuteNonQuery() <= 0)
						{
							sQLiteTransaction.Rollback();
							string message2 = "Error While Inserting Child Passengers";
							throw new Exception(message2);
						}
					}
				}
			}
			sQLiteTransaction.Commit();
			result = true;
		}
		catch (Exception)
		{
			sQLiteTransaction?.Rollback();
			string text63 = "Error Occured while Saving Ticket, You may retry again after some time.";
			string caption = "Saving Error";
			MessageBox.Show(text63, caption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		if (sQLiteConnection.State == ConnectionState.Open)
		{
			sQLiteConnection.Close();
		}
		return result;
	}

	public static bool smethod_0(string string_26)
	{
		bool result = true;
		try
		{
			SQLiteConnection sQLiteConnection = new SQLiteConnection(Class34.string_Database);
			sQLiteConnection.Open();
			string text = "SELECT Count(*) FROM TBL_TKT WHERE TKT_NAME = '";
			string text2 = "'";
			if (int.Parse(new SQLiteCommand(text + string_26 + text2, sQLiteConnection).ExecuteScalar().ToString()) <= 0)
			{
				result = false;
			}
		}
		catch
		{
			result = false;
		}
		return result;
	}

	public static bool smethod_1(string string_26)
	{
		bool result = true;
		try
		{
			SQLiteConnection sQLiteConnection = new SQLiteConnection(Class34.string_Database);
			SQLiteCommand sQLiteCommand = new SQLiteCommand(sQLiteConnection);
			sQLiteConnection.Open();
			string text = "DELETE FROM TBL_PAX WHERE TKT_ID = '";
			string text2 = "'";
			sQLiteCommand.CommandText = text + string_26 + text2;
			sQLiteCommand.ExecuteNonQuery();
			string text3 = "DELETE FROM TBL_TKT WHERE TKT_NAME = '";
			string text4 = "'";
			sQLiteCommand.CommandText = text3 + string_26 + text4;
			sQLiteCommand.ExecuteNonQuery();
			sQLiteConnection.Close();
			sQLiteCommand.Dispose();
		}
		catch
		{
			result = false;
		}
		return result;
	}
}
