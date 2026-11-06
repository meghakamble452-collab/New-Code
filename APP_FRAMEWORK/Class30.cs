using System;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace APP_FRAMEWORK;

internal class Class30
{
	public static void StartSQLforDatabase()
	{
		string[] array = new string[14];
		string text = "CREATE TABLE TBL_TKT(RID integer PRIMARY KEY AUTOINCREMENT,TKT_NAME varchar(20),SRC_STN varchar(30),DEST_STN varchar(30),BRD_STN varchar(30),TRAIN_NO varchar(20),TKT_DAY varchar(10),TKT_MONTH varchar(10),TKT_YEAR varchar(10),TKT_CLASS varchar(10),TKT_QUOTA varchar(10),TKT_TRNTYPE varchar(10),TKT_TRDAY varchar(10),TKT_ISADV varchar(10),TKT_ISCONFIRM varchar(10),TKT_ISAUTOUPGRD varchar(10),TKT_ISBEDROLL varchar(10),TKT_COACH varchar(10),TKT_MOBILE varchar(10),TKT_IRCTCID varchar(20),TKT_PWD varchar(20),TKT_SLOT varchar(20),TKT_PAYMENT varchar(50),TKT_BANKSAVEAS varchar(50),TKT_BANKDETAILS varchar(80),TKT_FAREDETAILS varchar(80),TR_LIST varchar(10000),Remarks varchar(50),TKT_ISRET varchar(10),TKT_ISPRI varchar(10),RSRC_STN varchar(30),RDEST_STN varchar(30),RBRD_STN varchar(30),RTRAIN_NO varchar(20),RTKT_DAY varchar(10),RTKT_MONTH varchar(10),RTKT_YEAR varchar(10),RTKT_CLASS varchar(10),RTKT_QUOTA varchar(10),RTKT_TRNTYPE varchar(10),RTKT_TRDAY varchar(10),RTR_LIST varchar(10000),TKT_STOPPAY varchar(10), WebLog varchar(30), AppLog varchar(30), Pnr varchar(15), PairId varchar(15), PairNo varchar(15), Create_Date DATETIME);";
		array[0] = text;
		string text2 = "CREATE TABLE TBL_PAX(RID integer PRIMARY KEY AUTOINCREMENT,PAX_NAME varchar(20),PAX_AGE varchar(5),PAX_SEX varchar(10),PAX_BIRTH varchar(20),PAX_FOOD varchar(20),PAX_IDTYPE varchar(30),PAX_IDNO varchar(40),PAX_CONC varchar(20),TKT_ID varchar(20),Remarks varchar(50),Create_Date varchar(50));";
		array[1] = text2;
		string text3 = "CREATE TABLE TBL_USER(RID integer PRIMARY KEY AUTOINCREMENT,UserName varchar(50) NOT NULL, strPwd varchar(50) NOT NULL, UserState varchar(50), History varchar(1000), Remarks varchar(5000));";
		array[2] = text3;
		string text4 = "CREATE TABLE TBL_BANK(RID integer PRIMARY KEY AUTOINCREMENT,BANK_NAME varchar(50),BANK_SAVEAS varchar(50),BANK_DETAILS varchar(50),BANK_ISDEBIT varchar(20), Remarks varchar(2000));";
		array[3] = text4;
		string text5 = "CREATE TABLE TBL_HISTORY(RID integer PRIMARY KEY AUTOINCREMENT,TCNTRL_NAME varchar(20) NOT NULL, TKT_NAME varchar(50) NOT NULL, IRCTC_ID varchar(20),stnFrom varchar(20),stnTo varchar(20),Journey_Date varchar(20),BANK_NAME varchar(16),PNR varchar(12),AMT varchar(10), Remarks varchar(50),Create_Date varchar(50));";
		array[4] = text5;
		string text6 = "CREATE TABLE TBL_STN(RID integer PRIMARY KEY AUTOINCREMENT,STNCD varchar(50) NOT NULL, STNNAME varchar(50) NOT NULL);";
		array[5] = text6;
		string text7 = "CREATE TABLE tbl_RegUser(UserId varchar(30) PRIMARY KEY NOT NULL, strPwd varchar(50) NOT NULL, strMachine varchar(50) NOT NULL, strMachinePwd varchar(50), OpenedWindo varchar(5), NgetWindo varchar(5), AppWindo varchar(5));";
		array[6] = text7;
		string text8 = "CREATE TABLE TBL_IP(IP varchar(50), Pnr1 varchar(50), Pnr2 varchar(50), Remarks varchar(50));";
		array[7] = text8;
		string text9 = "CREATE TABLE TBL_LOG(RID integer PRIMARY KEY AUTOINCREMENT, TYPE varchar(10), LOG varchar(1000000), Remarks varchar(50));";
		array[8] = text9;
		string text10 = "CREATE TABLE tbl_Train(TrainNo varchar(10), Traintype varchar(20));";
		array[9] = text10;
		string text11 = "CREATE TABLE TBL_UPI(RID integer PRIMARY KEY AUTOINCREMENT, MobNo varchar(15), UPIAdd varchar(15), RegiInfo varchar(50000), LoginInfo varchar(100000), AccInfo varchar(100000), TrnsInfo varchar(100000), SessInfo varchar(100000), TimeStamp varchar(50));";
		array[10] = text11;
		string text12 = "CREATE TABLE TBL_NPCI(RID integer PRIMARY KEY AUTOINCREMENT, MobNo varchar(15), UPIAdd varchar(15), RegiInfo varchar(50000), LoginInfo varchar(100000), AccInfo varchar(100000), TrnsInfo varchar(100000), SessInfo varchar(100000), TimeStamp varchar(50));";
		array[11] = text12;
		string text13 = "CREATE TABLE TBL_SBIUPI(RID integer PRIMARY KEY AUTOINCREMENT, MobNo varchar(15), UPIAdd varchar(15), RegiInfo varchar(50000), LoginInfo varchar(100000), AccInfo varchar(100000), TrnsInfo varchar(100000), SessInfo varchar(100000), TimeStamp varchar(50));";
		array[12] = text13;
		string text14 = "CREATE TABLE TBL_FREECHARGE(RID integer PRIMARY KEY AUTOINCREMENT, MobNo varchar(15), UPIAdd varchar(15), RegiInfo varchar(50000), LoginInfo varchar(100000), AccInfo varchar(100000), TrnsInfo varchar(100000), SessInfo varchar(100000), TimeStamp varchar(50));";
		array[13] = text14;
		string[] array2 = array;
		SQLiteConnection sQLiteConnection = new SQLiteConnection(Class34.string_Database);
		sQLiteConnection.Open();
		SQLiteCommand sQLiteCommand = new SQLiteCommand(sQLiteConnection);
		for (int i = 0; i < array2.Length; i++)
		{
			sQLiteCommand.CommandText = array2[i];
			sQLiteCommand.ExecuteNonQuery();
		}
		sQLiteCommand.Dispose();
		if (sQLiteConnection.State == ConnectionState.Open)
		{
			sQLiteConnection.Close();
		}
	}

	public static void CreateNewTable()
	{
		try
		{
			string text = "CREATE TABLE IF NOT EXISTS AUTH_PASS(Username varchar(30), Password varchar(30));";
			string commandText = text;
			SQLiteConnection sQLiteConnection = new SQLiteConnection(Class34.string_Database);
			sQLiteConnection.Open();
			SQLiteCommand sQLiteCommand = new SQLiteCommand(sQLiteConnection);
			sQLiteCommand.CommandText = commandText;
			sQLiteCommand.ExecuteNonQuery();
			sQLiteCommand.Dispose();
			if (sQLiteConnection.State == ConnectionState.Open)
			{
				sQLiteConnection.Close();
			}
			string text2 = "CREATE TABLE IF NOT EXISTS TBL_PHONEPE(RID integer PRIMARY KEY AUTOINCREMENT, MobNo varchar(15), UPIAdd varchar(15), RegiInfo varchar(900000), LoginInfo varchar(900000), AccInfo varchar(900000), TrnsInfo varchar(900000), SessInfo varchar(900000), TimeStamp varchar(50));";
			commandText = text2;
			sQLiteConnection = new SQLiteConnection(Class34.string_Database);
			sQLiteConnection.Open();
			sQLiteCommand = new SQLiteCommand(sQLiteConnection);
			sQLiteCommand.CommandText = commandText;
			sQLiteCommand.ExecuteNonQuery();
			sQLiteCommand.Dispose();
			if (sQLiteConnection.State == ConnectionState.Open)
			{
				sQLiteConnection.Close();
			}
			if (!string.IsNullOrEmpty(ReadData_checkUser()))
			{
				Program.StrongPassword = ReadDataTable();
				string strongPassword = Program.StrongPassword;
				string text3 = "0";
				if (strongPassword != text3)
				{
					_ = Program.StrongPassword != Program.StrongPassword_text;
				}
				return;
			}
			sQLiteConnection = new SQLiteConnection(Class34.string_Database);
			sQLiteCommand = new SQLiteCommand();
			sQLiteConnection.Open();
			sQLiteCommand.Connection = sQLiteConnection;
			SQLiteCommand sQLiteCommand2 = sQLiteCommand;
			string[] array = new string[5];
			string text4 = "INSERT INTO [AUTH_PASS]([Username],[Password]) VALUES('";
			array[0] = text4;
			array[1] = Program.clientID;
			string text5 = "', '";
			array[2] = text5;
			string text6 = "0";
			array[3] = text6;
			string text7 = "')";
			array[4] = text7;
			sQLiteCommand2.CommandText = string.Concat(array);
			sQLiteCommand.ExecuteNonQuery();
			sQLiteConnection.Close();
			sQLiteCommand.Dispose();
			string strongPassword2 = "0";
			Program.StrongPassword = strongPassword2;
		}
		catch
		{
		}
	}

	public static void UpdateStrongPassword(string pass)
	{
		SQLiteConnection sQLiteConnection = new SQLiteConnection(Class34.string_Database);
		SQLiteCommand sQLiteCommand = new SQLiteCommand();
		sQLiteConnection.Open();
		sQLiteCommand.Connection = sQLiteConnection;
		string[] array = new string[5];
		string text = "UPDATE [AUTH_PASS] SET [Password] = '";
		array[0] = text;
		array[1] = pass;
		string text2 = "' WHERE [Username] = '";
		array[2] = text2;
		array[3] = Program.clientID;
		string text3 = "'";
		array[4] = text3;
		sQLiteCommand.CommandText = string.Concat(array);
		sQLiteCommand.ExecuteNonQuery();
		sQLiteConnection.Close();
		sQLiteCommand.Dispose();
	}

	public static string ReadData_checkUser()
	{
		string result = "";
		DataTable dataTable = new DataTable();
		string commandText = "SELECT * FROM AUTH_PASS";
		new SQLiteDataAdapter(commandText, Class34.string_Database).Fill(dataTable);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			foreach (DataRow row in dataTable.Rows)
			{
				string columnName = "Username";
				result = row[columnName].ToString();
			}
		}
		return result;
	}

	public static string ReadData_checkUser2()
	{
		string result = "";
		DataTable dataTable = new DataTable();
		string commandText = "SELECT * FROM TBL_PHONEPE";
		new SQLiteDataAdapter(commandText, Class34.string_Database).Fill(dataTable);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			foreach (DataRow row in dataTable.Rows)
			{
				string columnName = "Username";
				result = row[columnName].ToString();
			}
		}
		return result;
	}

	public static string ReadDataTable()
	{
		string result = "";
		DataTable dataTable = new DataTable();
		string text = "SELECT * FROM AUTH_PASS WHERE Username LIKE '";
		string clientID = Program.clientID;
		string text2 = "'";
		new SQLiteDataAdapter(text + clientID + text2, Class34.string_Database).Fill(dataTable);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			foreach (DataRow row in dataTable.Rows)
			{
				string columnName = "Password";
				result = row[columnName].ToString();
			}
		}
		return result;
	}

	public static void smethod_11()
	{
		try
		{
			SQLiteConnection sQLiteConnection;
			while (true)
			{
				sQLiteConnection = new SQLiteConnection(Class34.string_Database);
				sQLiteConnection.Open();
				SQLiteCommand sQLiteCommand = new SQLiteCommand(sQLiteConnection);
				try
				{
					string commandText = "SELECT name FROM sqlite_master WHERE type='table' AND name='tbl_RegUser' LIMIT 1;";
					sQLiteCommand.CommandText = commandText;
					object obj = sQLiteCommand.ExecuteScalar();
					if (obj != null && !(obj is DBNull))
					{
						string commandText2 = "SELECT UserId FROM tbl_RegUser LIMIT 1";
						sQLiteCommand.CommandText = commandText2;
						object obj2 = sQLiteCommand.ExecuteScalar();
						if (obj2 == null || obj2 is DBNull)
						{
							string[] array = new string[9];
							string text = "INSERT INTO tbl_RegUser(UserId, strPwd, strMachine, strMachinePwd) VALUES('";
							array[0] = text;
							array[1] = Program.clientID;
							string text2 = "', '";
							array[2] = text2;
							array[3] = Program.string_00;
							string text3 = "', '";
							array[4] = text3;
							array[5] = Program.mac;
							string text4 = "', '";
							array[6] = text4;
							array[7] = Program.string_01;
							string text5 = "')";
							array[8] = text5;
							sQLiteCommand.CommandText = string.Concat(array);
							sQLiteCommand.ExecuteNonQuery();
							break;
						}
						string commandText3 = "SELECT strPwd FROM tbl_RegUser LIMIT 1";
						sQLiteCommand.CommandText = commandText3;
						object obj3 = sQLiteCommand.ExecuteScalar();
						if ((obj2.ToString().ToUpper() != Program.clientID.ToUpper()) & (obj3.ToString().ToUpper() != Program.string_00.ToUpper()))
						{
							string text6 = "This product is Registered with different user!\r\n\r\nIf you was to Register new user, Old data will be lost!\r\n\r\nClick 'YES' to Proceed with new user, Otherwise click 'NO'";
							string caption = "New User Found";
							if (MessageBox.Show(text6, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
							{
								string[] array2 = new string[9];
								string text7 = "DELETE FROM TBL_BANK;DELETE FROM TBL_PAX;DELETE FROM TBL_TKT;DELETE FROM TBL_USER;DELETE FROM tbl_RegUser;INSERT INTO tbl_RegUser(UserId, strPwd, strMachine, strMachinePwd) VALUES('";
								array2[0] = text7;
								array2[1] = Program.clientID;
								string text8 = "', '";
								array2[2] = text8;
								array2[3] = Program.string_00;
								string text9 = "', '";
								array2[4] = text9;
								array2[5] = Program.mac;
								string text10 = "', '";
								array2[6] = text10;
								array2[7] = Program.string_01;
								string text11 = "');";
								array2[8] = text11;
								sQLiteCommand.CommandText = string.Concat(array2);
								sQLiteCommand.ExecuteNonQuery();
								Program.dictionary_0.Clear();
								Class28.smethod_15(clearPwd: true, 0);
								string text12 = "Product successfully Registered with new User.";
								string caption2 = "Registration";
								MessageBox.Show(text12, caption2, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							}
							else
							{
								Application.Exit();
								Process.GetCurrentProcess().Kill();
							}
						}
						break;
					}
					StartSQLforDatabase();
				}
				catch (Exception ex)
				{
					string text13 = ex.Message.ToString();
					string value = "file is encrypted or is not a database";
					text13.Contains(value);
					string text14 = ex.Message.ToString();
					string value2 = "no such table";
					text14.Contains(value2);
					break;
				}
				finally
				{
					sQLiteCommand.Dispose();
				}
			}
			if (sQLiteConnection.State == ConnectionState.Open)
			{
				sQLiteConnection.Close();
			}
		}
		catch (Exception ex2)
		{
			string message = ex2.Message;
			string caption3 = "SQL Lite Error";
			MessageBox.Show(message, caption3);
		}
	}

	private static void updatePWD(string pwd)
	{
		try
		{
			using SQLiteConnection sQLiteConnection = new SQLiteConnection(Class34.string_Database);
			sQLiteConnection.Open();
			string text = "PRAGMA rekey='";
			string text2 = "'";
			using (SQLiteCommand sQLiteCommand = new SQLiteCommand(text + pwd + text2, sQLiteConnection))
			{
				sQLiteCommand.ExecuteNonQuery();
			}
			sQLiteConnection.Close();
		}
		catch (Exception)
		{
		}
	}

	public static void CleanFiles()
	{
		if (!Directory.Exists(Program.StartupPath))
		{
			return;
		}
		FileInfo[] files = new DirectoryInfo(Program.StartupPath).GetFiles();
		FileInfo[] array = files;
		FileInfo[] array2 = array;
		foreach (FileInfo fileInfo in array2)
		{
			string name = fileInfo.Name;
			string text = "Database.db";
			if (name == text && !IsFileLocked(fileInfo))
			{
				fileInfo.Delete();
			}
		}
	}

	public static bool IsFileLocked(FileInfo file)
	{
		FileStream fileStream = null;
		try
		{
			fileStream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
		}
		catch (IOException)
		{
			return true;
		}
		finally
		{
			fileStream?.Close();
		}
		return false;
	}

	public static void smethod_4()
	{
		string startupPath = Program.StartupPath;
		string text = "\\Database.db";
		string text2 = startupPath + text;
		string[] array = new string[5];
		string text3 = "Server=localhost; Data Source = ";
		array[0] = text3;
		array[1] = text2;
		string text4 = "; Version = 3; Password= ";
		array[2] = text4;
		array[3] = Program.string_1A;
		string text5 = "; Compress=True;";
		array[4] = text5;
		Class34.string_Database = string.Concat(array);
		string path = "IRLOG//pwd";
		if (!File.Exists(path))
		{
			try
			{
				string path2 = "Database.db";
				if (File.Exists(path2))
				{
					updatePWD(Program.DBPASS);
				}
				Program.string_1A = Program.DBPASS;
				string path3 = "IRLOG//pwd";
				File.Create(path3);
			}
			catch
			{
				updatePWD(Program.DBPASS);
			}
		}
		string text6 = "Your Id- ";
		string clientID = Program.clientID;
		string text7 = ".inf";
		string path4 = text6 + clientID + text7;
		if (!File.Exists(path4))
		{
			StreamWriter streamWriter = new StreamWriter(path4);
			DateTime today = DateTime.Today;
			string text8 = "M/d/yyyy";
			streamWriter.Write(today.ToString(text8));
			streamWriter.Close();
		}
		string[] array2 = new string[5];
		string text9 = "Server=localhost; Data Source = ";
		array2[0] = text9;
		array2[1] = text2;
		string text10 = "; Version = 3; Password= ";
		array2[2] = text10;
		array2[3] = Program.string_1A;
		string text11 = "; Compress=True;";
		array2[4] = text11;
		Class34.string_Database = string.Concat(array2);
		try
		{
			SQLiteConnection sQLiteConnection = new SQLiteConnection(Class34.string_Database);
			sQLiteConnection.Open();
			string commandText = "PRAGMA schema_version;";
			using (SQLiteCommand sQLiteCommand = new SQLiteCommand(commandText, sQLiteConnection))
			{
				sQLiteCommand.ExecuteScalar();
			}
			sQLiteConnection.Close();
			new FileInfo(Path.Combine(text2)).Attributes = FileAttributes.Hidden;
			EnsureAllTables(sQLiteConnection);
		}
		catch (Exception ex)
		{
			string text12 = ex.Message.ToString();
			string value = "file is encrypted or is not a database";
			if (text12.Contains(value))
			{
				string path5 = "Database.db";
				if (File.Exists(path5))
				{
					string path6 = "Database.db";
					File.Delete(path6);
				}
				Environment.Exit(0);
				return;
			}
			string text13 = ex.Message.ToString();
			string value2 = "is not a database";
			if (!text13.Contains(value2))
			{
				Form owner = new Form
				{
					TopMost = true
				};
				string text14 = "There is Issue With SQL Lite, So Please Install Latest Version of .Net 4.6 Or Visual C++ Redistributable";
				string text15 = ex.Message.ToString();
				string text16 = ",\n\nContact With Seller For Do it Press Ok, \nOtherwise Contact Adminstrator For Solve Your Issue it.";
				string text17 = text14 + text15 + text16;
				string caption = "SQL Lite Error";
				if (MessageBox.Show(owner, text17, caption, MessageBoxButtons.OKCancel) == DialogResult.OK)
				{
					string string_ = "Database.db";
					string string_2 = "DELETE";
					Class28.smethod_29(string_, string_2);
					string path7 = "Database.db";
					if (File.Exists(path7))
					{
						string path8 = "Database.db";
						File.Delete(path8);
					}
				}
				Environment.Exit(0);
				return;
			}
			Form owner2 = new Form
			{
				TopMost = true
			};
			string text18 = "DataBase Exist in Your System is Currepted,\n\nDo You Want to recover it Press Ok, \nOtherwise Adminstrator will proceed to delete it.";
			string caption2 = "Authorization";
			if (MessageBox.Show(owner2, text18, caption2, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
			{
				updatePWD(Program.DBPASS);
				Program.string_1A = Program.DBPASS;
				string path9 = "IRLOG//pwd";
				File.Create(path9);
			}
			else
			{
				Form owner3 = new Form
				{
					TopMost = true
				};
				string text19 = "Do You Want to Delete Database File";
				string caption3 = "Delete Database";
				if (MessageBox.Show(owner3, text19, caption3, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
				{
					string string_3 = "Database.db";
					string string_4 = "DELETE";
					Class28.smethod_29(string_3, string_4);
				}
			}
			Environment.Exit(0);
		}
	}

	public static void EnsureAllTables(SQLiteConnection con)
	{
		string[] array = new string[14];
		string text = "CREATE TABLE TBL_TKT(RID integer PRIMARY KEY AUTOINCREMENT,TKT_NAME varchar(20),SRC_STN varchar(30),DEST_STN varchar(30),BRD_STN varchar(30),TRAIN_NO varchar(20),TKT_DAY varchar(10),TKT_MONTH varchar(10),TKT_YEAR varchar(10),TKT_CLASS varchar(10),TKT_QUOTA varchar(10),TKT_TRNTYPE varchar(10),TKT_TRDAY varchar(10),TKT_ISADV varchar(10),TKT_ISCONFIRM varchar(10),TKT_ISAUTOUPGRD varchar(10),TKT_ISBEDROLL varchar(10),TKT_COACH varchar(10),TKT_MOBILE varchar(10),TKT_IRCTCID varchar(20),TKT_PWD varchar(20),TKT_SLOT varchar(20),TKT_PAYMENT varchar(50),TKT_BANKSAVEAS varchar(50),TKT_BANKDETAILS varchar(80),TKT_FAREDETAILS varchar(80),TR_LIST varchar(10000),Remarks varchar(50),TKT_ISRET varchar(10),TKT_ISPRI varchar(10),RSRC_STN varchar(30),RDEST_STN varchar(30),RBRD_STN varchar(30),RTRAIN_NO varchar(20),RTKT_DAY varchar(10),RTKT_MONTH varchar(10),RTKT_YEAR varchar(10),RTKT_CLASS varchar(10),RTKT_QUOTA varchar(10),RTKT_TRNTYPE varchar(10),RTKT_TRDAY varchar(10),RTR_LIST varchar(10000),TKT_STOPPAY varchar(10),WebLog varchar(30),AppLog varchar(30),Pnr varchar(15),PairId varchar(15),PairNo varchar(15),Create_Date DATETIME);";
		array[0] = text;
		string text2 = "CREATE TABLE TBL_PAX(RID integer PRIMARY KEY AUTOINCREMENT,PAX_NAME varchar(20),PAX_AGE varchar(5),PAX_SEX varchar(10),PAX_BIRTH varchar(20),PAX_FOOD varchar(20),PAX_IDTYPE varchar(30),PAX_IDNO varchar(40),PAX_CONC varchar(20),TKT_ID varchar(20),Remarks varchar(50),Create_Date varchar(50));";
		array[1] = text2;
		string text3 = "CREATE TABLE TBL_USER(RID integer PRIMARY KEY AUTOINCREMENT,UserName varchar(50) NOT NULL,strPwd varchar(50) NOT NULL,UserState varchar(50),History varchar(1000),Remarks varchar(5000));";
		array[2] = text3;
		string text4 = "CREATE TABLE TBL_BANK(RID integer PRIMARY KEY AUTOINCREMENT,BANK_NAME varchar(50),BANK_SAVEAS varchar(50),BANK_DETAILS varchar(50),BANK_ISDEBIT varchar(20),Remarks varchar(2000));";
		array[3] = text4;
		string text5 = "CREATE TABLE TBL_HISTORY(RID integer PRIMARY KEY AUTOINCREMENT,TCNTRL_NAME varchar(20) NOT NULL,TKT_NAME varchar(50) NOT NULL,IRCTC_ID varchar(20),stnFrom varchar(20),stnTo varchar(20),Journey_Date varchar(20),BANK_NAME varchar(16),PNR varchar(12),AMT varchar(10),Remarks varchar(50),Create_Date varchar(50));";
		array[4] = text5;
		string text6 = "CREATE TABLE TBL_STN(RID integer PRIMARY KEY AUTOINCREMENT,STNCD varchar(50) NOT NULL,STNNAME varchar(50) NOT NULL);";
		array[5] = text6;
		string text7 = "CREATE TABLE tbl_RegUser(UserId varchar(30) PRIMARY KEY NOT NULL,strPwd varchar(50) NOT NULL,strMachine varchar(50) NOT NULL,strMachinePwd varchar(50),OpenedWindo varchar(5),NgetWindo varchar(5),AppWindo varchar(5));";
		array[6] = text7;
		string text8 = "CREATE TABLE TBL_IP(IP varchar(50),Pnr1 varchar(50),Pnr2 varchar(50),Remarks varchar(50));";
		array[7] = text8;
		string text9 = "CREATE TABLE TBL_LOG(RID integer PRIMARY KEY AUTOINCREMENT,TYPE varchar(10),LOG varchar(1000000),Remarks varchar(50));";
		array[8] = text9;
		string text10 = "CREATE TABLE tbl_Train(TrainNo varchar(10),Traintype varchar(20));";
		array[9] = text10;
		string text11 = "CREATE TABLE TBL_UPI(RID integer PRIMARY KEY AUTOINCREMENT,MobNo varchar(15),UPIAdd varchar(15),RegiInfo varchar(50000),LoginInfo varchar(100000),AccInfo varchar(100000),TrnsInfo varchar(100000),SessInfo varchar(100000),TimeStamp varchar(50));";
		array[10] = text11;
		string text12 = "CREATE TABLE TBL_NPCI(RID integer PRIMARY KEY AUTOINCREMENT,MobNo varchar(15),UPIAdd varchar(15),RegiInfo varchar(50000),LoginInfo varchar(100000),AccInfo varchar(100000),TrnsInfo varchar(100000),SessInfo varchar(100000),TimeStamp varchar(50));";
		array[11] = text12;
		string text13 = "CREATE TABLE TBL_SBIUPI(RID integer PRIMARY KEY AUTOINCREMENT,MobNo varchar(15),UPIAdd varchar(15),RegiInfo varchar(50000),LoginInfo varchar(100000),AccInfo varchar(100000),TrnsInfo varchar(100000),SessInfo varchar(100000),TimeStamp varchar(50));";
		array[12] = text13;
		string text14 = "CREATE TABLE TBL_FREECHARGE(RID integer PRIMARY KEY AUTOINCREMENT,MobNo varchar(15),UPIAdd varchar(15),RegiInfo varchar(50000),LoginInfo varchar(100000),AccInfo varchar(100000),TrnsInfo varchar(100000),SessInfo varchar(100000),TimeStamp varchar(50));";
		array[13] = text14;
		string[] array2 = array;
		con.Open();
		using SQLiteCommand sQLiteCommand = new SQLiteCommand(con);
		string[] array3 = array2;
		string[] array4 = array3;
		string[] array5 = array4;
		foreach (string text15 in array5)
		{
			string[] array6 = new string[1];
			string text16 = "CREATE TABLE";
			array6[0] = text16;
			string value = text15.Split(array6, StringSplitOptions.None)[1].Trim().Split('(')[0].Trim();
			string commandText = "SELECT name FROM sqlite_master WHERE type='table' AND name=@name";
			sQLiteCommand.CommandText = commandText;
			sQLiteCommand.Parameters.Clear();
			SQLiteParameterCollection parameters = sQLiteCommand.Parameters;
			string parameterName = "@name";
			parameters.AddWithValue(parameterName, value);
			if (sQLiteCommand.ExecuteScalar() == null)
			{
				sQLiteCommand.CommandText = text15;
				sQLiteCommand.Parameters.Clear();
				sQLiteCommand.ExecuteNonQuery();
			}
		}
	}
}
