using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Newtonsoft.Json.Linq;

namespace APP_FRAMEWORK;

internal class frmBackup : Form
{
	private bool OldFile;

	private IContainer icontainer_0;

	private string postpassword;

	private IDisposable idisposable_0;

	private GroupBox groupBox1;

	private CheckBox chkIRCTC;

	private CheckBox chkHistory;

	private CheckBox chkBank;

	internal Button btnBackup;

	private GroupBox groupBox2;

	private Button btnBrowse;

	private TextBox txtFile;

	private Label C0AA0;

	internal Button btnRestore;

	private Label label4;

	private TextBox textBox_0;

	private Label label7;

	private TextBox txtPwd;

	private Label label6;

	private TextBox txtResPwd;

	private Label label5;

	private CheckBox chkAll;

	private CheckBox chkTicket;

	private GroupBox B1AAA;

	private RadioButton C1AA0;

	private RadioButton radioButton4;

	private RadioButton radioButton3;

	private RadioButton radioButton2;

	private RadioButton radioButton1;

	internal Button button1;

	private TabControl tabControl1;

	private TabPage tabPage1;

	private TabPage tabPage2;

	private TabPage tabPage3;

	private Panel pnlHeader;

	private BunifuImageButton btnClose;

	private Label B2AAA;

	private CheckBox KeepExisting;

	internal Button button3;

	internal Button button2;

	private BunifuDragControl bunifuDragControl_0;

	private IContainer components;

	private BunifuElipse bunifuElipse1;

	public frmBackup(Icon icon_0)
	{
		InitializeComponent();
		pnlHeader.MouseDown += StatClass.Header_MouseDown;
		pnlHeader.MouseMove += StatClass.Header_MouseMove;
		pnlHeader.MouseUp += StatClass.Header_MouseUp;
		base.Icon = icon_0;
	}

	private void frmBackup_Load(object sender, EventArgs e)
	{
		chkAll.Checked = true;
		KeepExisting.Checked = true;
	}

	private void btnBackup_Click(object sender, EventArgs e)
	{
		if (!chkAll.Checked && !chkBank.Checked && !chkHistory.Checked && !chkIRCTC.Checked && !chkTicket.Checked)
		{
			string text = "Please select Atleast one item for Backup.";
			string caption = "Backup";
			MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		if (string.IsNullOrEmpty(txtPwd.Text) || txtPwd.Text.Length < 2)
		{
			string text2 = "Please enter Atleast two character long password.";
			string caption2 = "Backup";
			MessageBox.Show(text2, caption2, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		if (textBox_0.Text != txtPwd.Text)
		{
			string text3 = "Password and Confirm passowrds are not matching.";
			string caption3 = "Backup";
			MessageBox.Show(text3, caption3, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		string startupPath = Program.StartupPath;
		string path = "backup";
		string text4 = Path.Combine(startupPath, path);
		if (!Directory.Exists(text4))
		{
			Directory.CreateDirectory(text4);
		}
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.CheckFileExists = false;
		saveFileDialog.CheckPathExists = true;
		string defaultExt = ".bak";
		saveFileDialog.DefaultExt = defaultExt;
		string appName = Program.AppName;
		string text5 = " File|*.bak";
		saveFileDialog.Filter = appName + text5;
		saveFileDialog.OverwritePrompt = true;
		saveFileDialog.ValidateNames = true;
		saveFileDialog.InitialDirectory = text4;
		string title = "Save Backup File";
		saveFileDialog.Title = title;
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			method_0(saveFileDialog.FileName);
		}
		saveFileDialog.Dispose();
	}

	internal string encrypt_Password(string str)
	{
		string text = string.Empty;
		try
		{
			if (OldFile)
			{
				string[] array = new string[3];
				string text2 = "{\"RequestToken\":\"";
				array[0] = text2;
				array[1] = str;
				string text3 = "\",\"MSG\":\"true\"}";
				array[2] = text3;
				string text4 = string.Concat(array);
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Program.BackUpRestoreURL);
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				string contentType = "application/json";
				httpWebRequest.ContentType = contentType;
				httpWebRequest.Timeout = 15000;
				httpWebRequest.ReadWriteTimeout = 15000;
				string method = "POST";
				httpWebRequest.Method = method;
				using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
				{
					string value = text4;
					streamWriter.Write(value);
				}
				using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
				text = streamReader.ReadToEnd();
				JObject jObject = JObject.Parse(text);
				string propertyName = "Token";
				text = jObject[propertyName]?.ToString();
			}
			else
			{
				string[] array2 = new string[1];
				string text5 = "||";
				array2[0] = text5;
				string[] array3 = str.Split(array2, StringSplitOptions.None);
				string text6 = "hpHOULWzQIbFyJxvPv8T8ePSLvSAh0AFIIVB3bLosLrxgLhTLsgcDpGY1xSZRmGp";
				string symmetricKey = text6;
				text = Staticm.EncryptAES(array3[0], symmetricKey);
			}
		}
		catch (Exception)
		{
		}
		return text;
	}

	private void method_0(string string_0)
	{
		try
		{
			string dataSetName = "RailDS";
			DataSet dataSet = new DataSet(dataSetName);
			string tableName = "pwd";
			DataTable dataTable = new DataTable(tableName);
			DataColumnCollection columns = dataTable.Columns;
			string columnName = "Pwd";
			columns.Add(columnName);
			DataRow dataRow = dataTable.NewRow();
			dataRow[0] = txtPwd.Text;
			dataTable.Rows.Add(dataRow);
			dataTable.AcceptChanges();
			dataSet.Tables.Add(dataTable);
			SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter("", Class34.string_Database);
			try
			{
				SQLiteCommand selectCommand = sQLiteDataAdapter.SelectCommand;
				string commandText = "select * from TBL_TKT";
				selectCommand.CommandText = commandText;
				string srcTable = "TBL_TKT";
				sQLiteDataAdapter.Fill(dataSet, srcTable);
				SQLiteCommand selectCommand2 = sQLiteDataAdapter.SelectCommand;
				string commandText2 = "select * from TBL_PAX";
				selectCommand2.CommandText = commandText2;
				string srcTable2 = "TBL_PAX";
				sQLiteDataAdapter.Fill(dataSet, srcTable2);
				SQLiteCommand selectCommand3 = sQLiteDataAdapter.SelectCommand;
				string commandText3 = "select * from TBL_USER";
				selectCommand3.CommandText = commandText3;
				string srcTable3 = "TBL_USER";
				sQLiteDataAdapter.Fill(dataSet, srcTable3);
				SQLiteCommand selectCommand4 = sQLiteDataAdapter.SelectCommand;
				string commandText4 = "select * from TBL_BANK";
				selectCommand4.CommandText = commandText4;
				string srcTable4 = "TBL_BANK";
				sQLiteDataAdapter.Fill(dataSet, srcTable4);
				SQLiteCommand selectCommand5 = sQLiteDataAdapter.SelectCommand;
				string commandText5 = "select * from TBL_STN";
				selectCommand5.CommandText = commandText5;
				string srcTable5 = "TBL_STN";
				sQLiteDataAdapter.Fill(dataSet, srcTable5);
				SQLiteCommand selectCommand6 = sQLiteDataAdapter.SelectCommand;
				string commandText6 = "select * from tbl_RegUser";
				selectCommand6.CommandText = commandText6;
				string srcTable6 = "tbl_RegUser";
				sQLiteDataAdapter.Fill(dataSet, srcTable6);
				SQLiteCommand selectCommand7 = sQLiteDataAdapter.SelectCommand;
				string commandText7 = "select * from tbl_Train";
				selectCommand7.CommandText = commandText7;
				string srcTable7 = "tbl_Train";
				sQLiteDataAdapter.Fill(dataSet, srcTable7);
				SQLiteCommand selectCommand8 = sQLiteDataAdapter.SelectCommand;
				string commandText8 = "select * from TBL_UPI";
				selectCommand8.CommandText = commandText8;
				string srcTable8 = "TBL_UPI";
				sQLiteDataAdapter.Fill(dataSet, srcTable8);
				SQLiteCommand selectCommand9 = sQLiteDataAdapter.SelectCommand;
				string commandText9 = "select * from TBL_NPCI";
				selectCommand9.CommandText = commandText9;
				string srcTable9 = "TBL_NPCI";
				sQLiteDataAdapter.Fill(dataSet, srcTable9);
				SQLiteCommand selectCommand10 = sQLiteDataAdapter.SelectCommand;
				string commandText10 = "select * from TBL_SBIUPI";
				selectCommand10.CommandText = commandText10;
				string srcTable10 = "TBL_SBIUPI";
				sQLiteDataAdapter.Fill(dataSet, srcTable10);
				SQLiteCommand selectCommand11 = sQLiteDataAdapter.SelectCommand;
				string commandText11 = "select * from TBL_FREECHARGE";
				selectCommand11.CommandText = commandText11;
				string srcTable11 = "TBL_FREECHARGE";
				sQLiteDataAdapter.Fill(dataSet, srcTable11);
				SQLiteCommand selectCommand12 = sQLiteDataAdapter.SelectCommand;
				string commandText12 = "select * from TBL_HISTORY";
				selectCommand12.CommandText = commandText12;
				string srcTable12 = "TBL_HISTORY";
				sQLiteDataAdapter.Fill(dataSet, srcTable12);
			}
			catch
			{
			}
			MemoryStream memoryStream = new MemoryStream();
			new BinaryFormatter().Serialize(memoryStream, dataSet);
			memoryStream.Position = 0L;
			if (chkTicket.Checked)
			{
				string path = "OnlySavedTicket.txt";
				File.WriteAllText(path, Encoding.Default.GetString(memoryStream.ToArray()));
			}
			try
			{
				string text = "6bac5070747a1a1d08104753d2ac831c35702e8e8bd8ab0f9167c2c39937daf5";
				string symmetricKey = text;
				string string_1 = Staticm.EncryptAES(txtPwd.Text.Trim(), symmetricKey);
				File.WriteAllText(string_0, Class2.EncryptText(Encoding.Default.GetString(memoryStream.ToArray()), string_1));
			}
			catch
			{
				string @string = Encoding.Default.GetString(memoryStream.ToArray());
				string string_2 = "(b88dr86&$^";
				File.WriteAllText(string_0, Class2.EncryptText(@string, string_2));
			}
			memoryStream.Close();
			string text2 = "Backup Successful!";
			string caption = "Done";
			MessageBox.Show(text2, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			base.DialogResult = DialogResult.OK;
		}
		catch (Exception ex)
		{
			string string_3 = "frmBackup.ProcessBackup";
			Class28.smethod_26(string_3, ex.Message);
			string text3 = "Backup Failed";
			string caption2 = "Failed";
			MessageBox.Show(text3, caption2, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void method_1()
	{
		string startupPath = Program.StartupPath;
		string text = "\\backup";
		if (!Directory.Exists(startupPath + text))
		{
			string startupPath2 = Program.StartupPath;
			string text2 = "\\backup";
			Directory.CreateDirectory(startupPath2 + text2);
		}
		string startupPath3 = Program.StartupPath;
		string text3 = "\\Database.db";
		string sourceFileName = startupPath3 + text3;
		string startupPath4 = Program.StartupPath;
		string text4 = "\\backup\\Database.db";
		File.Copy(sourceFileName, startupPath4 + text4);
		string[] array = new string[5];
		string text5 = "Server=localhost; Data Source=";
		array[0] = text5;
		array[1] = Program.StartupPath;
		string text6 = "\\backup\\Database.db;Version=3; Password=";
		array[2] = text6;
		array[3] = Program.string_1A;
		string text7 = "; Compress=True;";
		array[4] = text7;
		string string_ = string.Concat(array);
		string pwd = "ABCD23";
		ChangeforDatabase(string_, pwd, 1);
	}

	private void btnBrowse_Click(object sender, EventArgs e)
	{
		try
		{
			string startupPath = Program.StartupPath;
			string path = "backup";
			string text = Path.Combine(startupPath, path);
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.AddExtension = false;
			openFileDialog.CheckFileExists = true;
			openFileDialog.CheckPathExists = true;
			string filter = "Backup File|*.bak";
			openFileDialog.Filter = filter;
			openFileDialog.Multiselect = false;
			openFileDialog.InitialDirectory = text;
			string title = "Select Backup File to Restore.";
			openFileDialog.Title = title;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				string fileName = openFileDialog.FileName;
				openFileDialog.Dispose();
				txtFile.Text = fileName;
			}
		}
		catch (Exception)
		{
		}
	}

	private void btnRestore_Click(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(txtResPwd.Text) && txtResPwd.Text.Length >= 2)
		{
			if (!string.IsNullOrEmpty(txtFile.Text) && File.Exists(txtFile.Text.Trim()))
			{
				method_2(txtFile.Text.Trim());
				Staticm.method_35();
			}
			else
			{
				string text = "Please enter valid Path for Backup File.";
				string caption = "Restore";
				MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		else
		{
			string text2 = "Please enter valid password to restore File.";
			string caption2 = "Restore";
			MessageBox.Show(text2, caption2, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	private void method_2_(string string_0)
	{
		try
		{
			postpassword = txtResPwd.Text;
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			Encoding @default = Encoding.Default;
			string strText = File.ReadAllText(string_0);
			string string_1 = "(gdrt286&$$";
			DataSet dataSet = (DataSet)binaryFormatter.Deserialize(new MemoryStream(@default.GetBytes(Class2.DecryptText(strText, string_1)), writable: true));
			DataTableCollection tables = dataSet.Tables;
			string name = "pwd";
			if (tables[name].Rows[0][0].ToString() != txtResPwd.Text)
			{
				string text = "Please enter valid Password for Backup File.";
				string caption = "Restore";
				MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			string text2 = "Are you sure to Restore all data in backup, This will clear any newly saved data?";
			string caption2 = "Confirm";
			if (MessageBox.Show(text2, caption2, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
			{
				return;
			}
			SQLiteConnection sQLiteConnection = new SQLiteConnection(Class34.string_Database);
			sQLiteConnection.Open();
			string commandText = "select * from tbl_bank";
			SQLiteCommand sQLiteCommand = new SQLiteCommand(commandText, sQLiteConnection);
			try
			{
				DataTableCollection tables2 = dataSet.Tables;
				string name2 = "TBL_BANK";
				if (tables2.Contains(name2))
				{
					if (!KeepExisting.Checked)
					{
						string commandText2 = "DELETE FROM TBL_BANK";
						sQLiteCommand.CommandText = commandText2;
						sQLiteCommand.ExecuteNonQuery();
					}
					DataTableCollection tables3 = dataSet.Tables;
					string name3 = "TBL_BANK";
					foreach (DataRow row in tables3[name3].Rows)
					{
						string[] array = new string[9];
						string text3 = "INSERT INTO [TBL_BANK](BANK_NAME, BANK_SAVEAS, BANK_DETAILS, BANK_ISDEBIT) VALUES ('";
						array[0] = text3;
						string[] array2 = array;
						string columnName = "BANK_NAME";
						array2[1] = row[columnName]?.ToString();
						string text4 = "', '";
						array2[2] = text4;
						string columnName2 = "BANK_SAVEAS";
						array2[3] = row[columnName2]?.ToString();
						string text5 = "', '";
						array2[4] = text5;
						string columnName3 = "BANK_DETAILS";
						array2[5] = row[columnName3]?.ToString();
						string text6 = "', '";
						array2[6] = text6;
						string columnName4 = "BANK_ISDEBIT";
						string text7 = row[columnName4].ToString();
						string text8 = "1";
						array2[7] = ((text7 == text8) ? 1 : 0).ToString();
						string text9 = "')";
						array2[8] = text9;
						sQLiteCommand.CommandText = string.Concat(array2);
						sQLiteCommand.ExecuteNonQuery();
					}
				}
			}
			catch
			{
				string text10 = "Error in Bank Data Restore";
				string caption3 = "Failed";
				MessageBox.Show(text10, caption3, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			try
			{
				DataTableCollection tables4 = dataSet.Tables;
				string name4 = "TBL_UPI";
				if (tables4.Contains(name4))
				{
					if (!KeepExisting.Checked)
					{
						string commandText3 = "DELETE FROM TBL_UPI";
						sQLiteCommand.CommandText = commandText3;
						sQLiteCommand.ExecuteNonQuery();
					}
					DataTableCollection tables5 = dataSet.Tables;
					string name5 = "TBL_UPI";
					foreach (DataRow row2 in tables5[name5].Rows)
					{
						DbCommand dbCommand = sQLiteCommand;
						string[] array3 = new string[17];
						string text11 = "INSERT INTO [TBL_UPI](MobNo, UPIAdd, RegiInfo, LoginInfo, AccInfo, TrnsInfo, SessInfo, TimeStamp) VALUES ('";
						array3[0] = text11;
						string[] array4 = array3;
						string columnName5 = "MobNo";
						array4[1] = row2[columnName5]?.ToString();
						string text12 = "', '";
						array4[2] = text12;
						string columnName6 = "UPIAdd";
						array4[3] = row2[columnName6]?.ToString();
						string text13 = "', '";
						array4[4] = text13;
						string columnName7 = "RegiInfo";
						array4[5] = row2[columnName7]?.ToString();
						string text14 = "', '";
						array4[6] = text14;
						string columnName8 = "LoginInfo";
						array4[7] = row2[columnName8]?.ToString();
						string text15 = "', '";
						array4[8] = text15;
						string columnName9 = "AccInfo";
						array4[9] = row2[columnName9]?.ToString();
						string text16 = "', '";
						array4[10] = text16;
						string columnName10 = "TrnsInfo";
						array4[11] = row2[columnName10]?.ToString();
						string text17 = "', '";
						array4[12] = text17;
						string columnName11 = "SessInfo";
						array4[13] = row2[columnName11]?.ToString();
						string text18 = "', '";
						array4[14] = text18;
						string columnName12 = "TimeStamp";
						array4[15] = row2[columnName12]?.ToString();
						string text19 = "')";
						array4[16] = text19;
						dbCommand.CommandText = string.Concat(array4);
						sQLiteCommand.ExecuteNonQuery();
					}
				}
			}
			catch
			{
				string text20 = "Error in Bank-2 Data Restore";
				string caption4 = "Failed";
				MessageBox.Show(text20, caption4, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			try
			{
				DataTableCollection tables6 = dataSet.Tables;
				string name6 = "TBL_USER";
				if (tables6.Contains(name6))
				{
					if (!KeepExisting.Checked)
					{
						string commandText4 = "DELETE FROM TBL_USER";
						sQLiteCommand.CommandText = commandText4;
						sQLiteCommand.ExecuteNonQuery();
					}
					DataTableCollection tables7 = dataSet.Tables;
					string name7 = "TBL_USER";
					foreach (DataRow row3 in tables7[name7].Rows)
					{
						DbCommand dbCommand2 = sQLiteCommand;
						string[] array5 = new string[11];
						string text21 = "INSERT INTO [TBL_USER](UserName, strPwd, UserState, History, Remarks) VALUES ('";
						array5[0] = text21;
						string[] array6 = array5;
						string columnName13 = "UserName";
						array6[1] = row3[columnName13]?.ToString();
						string text22 = "', '";
						array6[2] = text22;
						string columnName14 = "strPwd";
						array6[3] = row3[columnName14]?.ToString();
						string text23 = "', '";
						array6[4] = text23;
						string columnName15 = "UserState";
						array6[5] = row3[columnName15]?.ToString();
						string text24 = "', '";
						array6[6] = text24;
						string columnName16 = "History";
						array6[7] = row3[columnName16]?.ToString();
						string text25 = "', '";
						array6[8] = text25;
						string columnName17 = "Remarks";
						array6[9] = row3[columnName17]?.ToString();
						string text26 = "')";
						array6[10] = text26;
						dbCommand2.CommandText = string.Concat(array6);
						sQLiteCommand.ExecuteNonQuery();
					}
				}
			}
			catch
			{
				string text27 = "Error in USer Data Restore";
				string caption5 = "Failed";
				MessageBox.Show(text27, caption5, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			try
			{
				DataTableCollection tables8 = dataSet.Tables;
				string name8 = "TBL_HISTORY";
				if (tables8.Contains(name8))
				{
					if (!KeepExisting.Checked)
					{
						string commandText5 = "DELETE FROM TBL_HISTORY";
						sQLiteCommand.CommandText = commandText5;
						sQLiteCommand.ExecuteNonQuery();
					}
					DataTableCollection tables9 = dataSet.Tables;
					string name9 = "TBL_HISTORY";
					foreach (DataRow row4 in tables9[name9].Rows)
					{
						string[] array7 = new string[21];
						string text28 = "INSERT INTO [TBL_HISTORY](TCNTRL_NAME, TKT_NAME, IRCTC_ID, stnFrom,stnTo,BANK_NAME,PNR,AMT,Remarks,Create_Date) VALUES ('";
						array7[0] = text28;
						string columnName18 = "TCNTRL_NAME";
						array7[1] = row4[columnName18]?.ToString();
						string text29 = "', '";
						array7[2] = text29;
						string columnName19 = "TKT_NAME";
						array7[3] = row4[columnName19]?.ToString();
						string text30 = "', '";
						array7[4] = text30;
						string columnName20 = "IRCTC_ID";
						array7[5] = row4[columnName20]?.ToString();
						string text31 = "', '";
						array7[6] = text31;
						string columnName21 = "stnFrom";
						array7[7] = row4[columnName21]?.ToString();
						string text32 = "', '";
						array7[8] = text32;
						string columnName22 = "stnTo";
						array7[9] = row4[columnName22]?.ToString();
						string text33 = "', '";
						array7[10] = text33;
						string columnName23 = "BANK_NAME";
						array7[11] = row4[columnName23]?.ToString();
						string text34 = "', '";
						array7[12] = text34;
						string columnName24 = "PNR";
						array7[13] = row4[columnName24]?.ToString();
						string text35 = "', '";
						array7[14] = text35;
						string columnName25 = "AMT";
						array7[15] = row4[columnName25]?.ToString();
						string text36 = "', '";
						array7[16] = text36;
						string columnName26 = "Remarks";
						array7[17] = row4[columnName26]?.ToString();
						string text37 = "', '";
						array7[18] = text37;
						string columnName27 = "Create_Date";
						array7[19] = row4[columnName27]?.ToString();
						string text38 = "')";
						array7[20] = text38;
						sQLiteCommand.CommandText = string.Concat(array7);
						sQLiteCommand.ExecuteNonQuery();
					}
				}
			}
			catch
			{
				string text39 = "Error in History Data Restore";
				string caption6 = "Failed";
				MessageBox.Show(text39, caption6, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			try
			{
				DataTableCollection tables10 = dataSet.Tables;
				string name10 = "TBL_TKT";
				if (tables10.Contains(name10))
				{
					if (!KeepExisting.Checked)
					{
						string commandText6 = "DELETE FROM TBL_TKT";
						sQLiteCommand.CommandText = commandText6;
						sQLiteCommand.ExecuteNonQuery();
					}
					DataTableCollection tables11 = dataSet.Tables;
					string name11 = "TBL_TKT";
					foreach (DataRow row5 in tables11[name11].Rows)
					{
						string[] array8 = new string[91];
						string text40 = "INSERT INTO TBL_TKT(TKT_NAME, SRC_STN, DEST_STN, BRD_STN, TRAIN_NO, TKT_DAY, TKT_MONTH, TKT_YEAR, TKT_CLASS, TKT_QUOTA, TKT_TRNTYPE, TKT_TRDAY, TKT_ISADV, TKT_ISCONFIRM, TKT_ISAUTOUPGRD, TKT_ISBEDROLL, TKT_COACH, TKT_MOBILE, TKT_IRCTCID, TKT_PWD, TKT_PAYMENT, TKT_BANKSAVEAS, TKT_BANKDETAILS, TKT_FAREDETAILS, TR_LIST, Remarks, TKT_ISRET, TKT_ISPRI, RSRC_STN, RDEST_STN, RBRD_STN, RTRAIN_NO, RTKT_DAY, RTKT_MONTH, RTKT_YEAR, RTKT_CLASS, RTKT_QUOTA, RTKT_TRNTYPE, RTKT_TRDAY, RTR_LIST, TKT_STOPPAY, Pnr, PairId, PairNo, Create_Date) VALUES('";
						array8[0] = text40;
						string columnName28 = "TKT_NAME";
						array8[1] = row5[columnName28]?.ToString();
						string text41 = "', '";
						array8[2] = text41;
						string columnName29 = "SRC_STN";
						array8[3] = row5[columnName29]?.ToString();
						string text42 = "', '";
						array8[4] = text42;
						string columnName30 = "DEST_STN";
						array8[5] = row5[columnName30]?.ToString();
						string text43 = "', '";
						array8[6] = text43;
						string columnName31 = "BRD_STN";
						array8[7] = row5[columnName31]?.ToString();
						string text44 = "', '";
						array8[8] = text44;
						string columnName32 = "TRAIN_NO";
						array8[9] = row5[columnName32]?.ToString();
						string text45 = "', '";
						array8[10] = text45;
						string columnName33 = "TKT_DAY";
						array8[11] = row5[columnName33]?.ToString();
						string text46 = "', '";
						array8[12] = text46;
						string columnName34 = "TKT_MONTH";
						array8[13] = row5[columnName34]?.ToString();
						string text47 = "', '";
						array8[14] = text47;
						string columnName35 = "TKT_YEAR";
						array8[15] = row5[columnName35]?.ToString();
						string text48 = "', '";
						array8[16] = text48;
						string columnName36 = "TKT_CLASS";
						array8[17] = row5[columnName36]?.ToString();
						string text49 = "', '";
						array8[18] = text49;
						string columnName37 = "TKT_QUOTA";
						array8[19] = row5[columnName37]?.ToString();
						string text50 = "', '";
						array8[20] = text50;
						string columnName38 = "TKT_TRNTYPE";
						array8[21] = row5[columnName38]?.ToString();
						string text51 = "', '";
						array8[22] = text51;
						string columnName39 = "TKT_TRDAY";
						array8[23] = row5[columnName39]?.ToString();
						string text52 = "', '";
						array8[24] = text52;
						string columnName40 = "TKT_ISADV";
						array8[25] = row5[columnName40]?.ToString();
						string text53 = "', '";
						array8[26] = text53;
						string columnName41 = "TKT_ISCONFIRM";
						array8[27] = row5[columnName41]?.ToString();
						string text54 = "', '";
						array8[28] = text54;
						string columnName42 = "TKT_ISAUTOUPGRD";
						array8[29] = row5[columnName42]?.ToString();
						string text55 = "', '";
						array8[30] = text55;
						string columnName43 = "TKT_ISBEDROLL";
						array8[31] = row5[columnName43]?.ToString();
						string text56 = "', '";
						array8[32] = text56;
						string columnName44 = "TKT_COACH";
						array8[33] = row5[columnName44]?.ToString();
						string text57 = "', '";
						array8[34] = text57;
						string columnName45 = "TKT_MOBILE";
						array8[35] = row5[columnName45]?.ToString();
						string text58 = "', '";
						array8[36] = text58;
						string columnName46 = "TKT_IRCTCID";
						array8[37] = row5[columnName46]?.ToString();
						string text59 = "', '";
						array8[38] = text59;
						string columnName47 = "TKT_PWD";
						array8[39] = row5[columnName47]?.ToString();
						string text60 = "', '";
						array8[40] = text60;
						string columnName48 = "TKT_PAYMENT";
						array8[41] = row5[columnName48]?.ToString();
						string text61 = "', '";
						array8[42] = text61;
						string columnName49 = "TKT_BANKSAVEAS";
						array8[43] = row5[columnName49]?.ToString();
						string text62 = "', '";
						array8[44] = text62;
						string columnName50 = "TKT_BANKDETAILS";
						array8[45] = row5[columnName50]?.ToString();
						string text63 = "', '";
						array8[46] = text63;
						string columnName51 = "TKT_FAREDETAILS";
						array8[47] = row5[columnName51]?.ToString();
						string text64 = "', '";
						array8[48] = text64;
						string columnName52 = "TR_LIST";
						array8[49] = row5[columnName52]?.ToString();
						string text65 = "', '";
						array8[50] = text65;
						string columnName53 = "Remarks";
						array8[51] = row5[columnName53]?.ToString();
						string text66 = "', '";
						array8[52] = text66;
						string columnName54 = "TKT_ISRET";
						array8[53] = row5[columnName54]?.ToString();
						string text67 = "', '";
						array8[54] = text67;
						string columnName55 = "TKT_ISPRI";
						array8[55] = row5[columnName55]?.ToString();
						string text68 = "', '";
						array8[56] = text68;
						string columnName56 = "RSRC_STN";
						array8[57] = row5[columnName56]?.ToString();
						string text69 = "', '";
						array8[58] = text69;
						string columnName57 = "RDEST_STN";
						array8[59] = row5[columnName57]?.ToString();
						string text70 = "', '";
						array8[60] = text70;
						string columnName58 = "RBRD_STN";
						array8[61] = row5[columnName58]?.ToString();
						string text71 = "', '";
						array8[62] = text71;
						string columnName59 = "RTRAIN_NO";
						array8[63] = row5[columnName59]?.ToString();
						string text72 = "', '";
						array8[64] = text72;
						string columnName60 = "RTKT_DAY";
						array8[65] = row5[columnName60]?.ToString();
						string text73 = "', '";
						array8[66] = text73;
						string columnName61 = "RTKT_MONTH";
						array8[67] = row5[columnName61]?.ToString();
						string text74 = "', '";
						array8[68] = text74;
						string columnName62 = "RTKT_YEAR";
						array8[69] = row5[columnName62]?.ToString();
						string text75 = "', '";
						array8[70] = text75;
						string columnName63 = "RTKT_CLASS";
						array8[71] = row5[columnName63]?.ToString();
						string text76 = "', '";
						array8[72] = text76;
						string columnName64 = "RTKT_QUOTA";
						array8[73] = row5[columnName64]?.ToString();
						string text77 = "', '";
						array8[74] = text77;
						string columnName65 = "RTKT_TRNTYPE";
						array8[75] = row5[columnName65]?.ToString();
						string text78 = "', '";
						array8[76] = text78;
						string columnName66 = "RTKT_TRDAY";
						array8[77] = row5[columnName66]?.ToString();
						string text79 = "', '";
						array8[78] = text79;
						string columnName67 = "RTR_LIST";
						array8[79] = row5[columnName67]?.ToString();
						string text80 = "', '";
						array8[80] = text80;
						string columnName68 = "TKT_STOPPAY";
						array8[81] = row5[columnName68]?.ToString();
						string text81 = "', '";
						array8[82] = text81;
						string columnName69 = "Pnr";
						array8[83] = row5[columnName69]?.ToString();
						string text82 = "', '";
						array8[84] = text82;
						string columnName70 = "PairId";
						array8[85] = row5[columnName70]?.ToString();
						string text83 = "', '";
						array8[86] = text83;
						string columnName71 = "PairNo";
						array8[87] = row5[columnName71]?.ToString();
						string text84 = "', '";
						array8[88] = text84;
						string columnName72 = "Create_Date";
						array8[89] = row5[columnName72]?.ToString();
						string text85 = "')";
						array8[90] = text85;
						sQLiteCommand.CommandText = string.Concat(array8);
						sQLiteCommand.ExecuteNonQuery();
					}
				}
			}
			catch
			{
				string text86 = "Error in Ticket Data Restore";
				string caption7 = "Failed";
				MessageBox.Show(text86, caption7, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			try
			{
				DataTableCollection tables12 = dataSet.Tables;
				string name12 = "TBL_PAX";
				if (tables12.Contains(name12))
				{
					if (!KeepExisting.Checked)
					{
						string commandText7 = "DELETE FROM TBL_PAX";
						sQLiteCommand.CommandText = commandText7;
						sQLiteCommand.ExecuteNonQuery();
					}
					DataTableCollection tables13 = dataSet.Tables;
					string name13 = "TBL_PAX";
					foreach (DataRow row6 in tables13[name13].Rows)
					{
						string[] array9 = new string[23];
						string text87 = "INSERT INTO [TBL_PAX](PAX_NAME, PAX_AGE, PAX_SEX, PAX_BIRTH, PAX_FOOD, PAX_IDTYPE, PAX_IDNO, PAX_CONC, TKT_ID, Remarks, Create_Date) VALUES ('";
						array9[0] = text87;
						string columnName73 = "PAX_NAME";
						array9[1] = row6[columnName73]?.ToString();
						string text88 = "', '";
						array9[2] = text88;
						string columnName74 = "PAX_AGE";
						array9[3] = row6[columnName74]?.ToString();
						string text89 = "', '";
						array9[4] = text89;
						string columnName75 = "PAX_SEX";
						array9[5] = row6[columnName75]?.ToString();
						string text90 = "', '";
						array9[6] = text90;
						string columnName76 = "PAX_BIRTH";
						array9[7] = row6[columnName76]?.ToString();
						string text91 = "', '";
						array9[8] = text91;
						string columnName77 = "PAX_FOOD";
						array9[9] = row6[columnName77]?.ToString();
						string text92 = "', '";
						array9[10] = text92;
						string columnName78 = "PAX_IDTYPE";
						array9[11] = row6[columnName78]?.ToString();
						string text93 = "', '";
						array9[12] = text93;
						string columnName79 = "PAX_IDNO";
						array9[13] = row6[columnName79]?.ToString();
						string text94 = "', '";
						array9[14] = text94;
						string columnName80 = "PAX_CONC";
						array9[15] = row6[columnName80]?.ToString();
						string text95 = "', '";
						array9[16] = text95;
						string columnName81 = "TKT_ID";
						array9[17] = row6[columnName81]?.ToString();
						string text96 = "', '";
						array9[18] = text96;
						string columnName82 = "Remarks";
						array9[19] = row6[columnName82]?.ToString();
						string text97 = "', '";
						array9[20] = text97;
						string columnName83 = "Create_Date";
						array9[21] = row6[columnName83]?.ToString();
						string text98 = "')";
						array9[22] = text98;
						sQLiteCommand.CommandText = string.Concat(array9);
						sQLiteCommand.ExecuteNonQuery();
					}
				}
			}
			catch
			{
				string text99 = "Error in Ticket Data2 Restore";
				string caption8 = "Failed";
				MessageBox.Show(text99, caption8, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			sQLiteCommand.Dispose();
			sQLiteConnection.Close();
			sQLiteConnection.Dispose();
			string text100 = "Data Restored Successful!\r\n\r\nPlease copy Freecharge ,SBI , BHIM_SBI , BHIM_NPCI Folder manually to this folder if you have bypassed these in old system";
			string caption9 = "Done";
			MessageBox.Show(text100, caption9, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			base.DialogResult = DialogResult.OK;
		}
		catch (Exception ex)
		{
			string string_2 = "frmBackup.ProcessRestore";
			Class28.smethod_26(string_2, ex.Message);
			string text101 = "Restore Failed";
			string caption10 = "Failed";
			MessageBox.Show(text101, caption10, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void method_2(string string_0)
	{
		string text = txtResPwd.Text;
		bool flag = false;
		try
		{
			DataSet dataSet = null;
			try
			{
				string text2 = "ahJGlMzygLwCRuR+X6ERfZ0pWNQHPGcqZHT9vFAAr8c3uZsGbhbAnAMshhsoKXz4";
				string symmetricKey = text2;
				string string_1 = Staticm.EncryptAES(text, symmetricKey);
				dataSet = (DataSet)new BinaryFormatter().Deserialize(new MemoryStream(Encoding.Default.GetBytes(Class2.DecryptText(File.ReadAllText(string_0), string_1)), writable: true));
				flag = true;
			}
			catch (Exception)
			{
			}
			if (!flag)
			{
				try
				{
					string text3 = "hpHOULWzQIbFyJxvPv8T8ePSLvSAh0AFIIVB3bLosLrxgLhTLsgcDpGY1xSZRmGp";
					string symmetricKey2 = text3;
					string text4 = "||";
					string string_2 = Staticm.EncryptAES(text + text4 + Program.DBPASS, symmetricKey2);
					dataSet = (DataSet)new BinaryFormatter().Deserialize(new MemoryStream(Encoding.Default.GetBytes(Class2.DecryptText(File.ReadAllText(string_0), string_2)), writable: true));
					flag = true;
				}
				catch (Exception)
				{
				}
			}
			if (!flag)
			{
				try
				{
					string text5 = "hpHOULWzQIbFyJxvPv8T8ePSLvSAh0AFIIVB3bLosLrxgLhTLsgcDpGY1xSZRmGp";
					string symmetricKey3 = text5;
					string string_3 = Staticm.EncryptAES(text, symmetricKey3);
					dataSet = (DataSet)new BinaryFormatter().Deserialize(new MemoryStream(Encoding.Default.GetBytes(Class2.DecryptText(File.ReadAllText(string_0), string_3)), writable: true));
					flag = true;
				}
				catch (Exception)
				{
				}
			}
			if (!flag)
			{
				try
				{
					string text6 = "6bac5070747a1a1d08104753d2ac831c35702e8e8bd8ab0f9167c2c39937daf5";
					string symmetricKey4 = text6;
					string string_4 = Staticm.EncryptAES(text, symmetricKey4);
					dataSet = (DataSet)new BinaryFormatter().Deserialize(new MemoryStream(Encoding.Default.GetBytes(Class2.DecryptText(File.ReadAllText(string_0), string_4)), writable: true));
					flag = true;
				}
				catch (Exception)
				{
				}
			}
			if (!flag)
			{
				try
				{
					string oldValue = "2";
					string newValue = "x";
					string input = text.Replace(oldValue, newValue);
					string text7 = "GBuUegTfkhMmLVLT95Inq86vqWCUvptwO3WK7vgOtZ1a95swrflOWM4cH0U21mzn";
					string symmetricKey5 = text7;
					string string_5 = Staticm.EncryptAES(input, symmetricKey5);
					dataSet = (DataSet)new BinaryFormatter().Deserialize(new MemoryStream(Encoding.Default.GetBytes(Class2.DecryptText(File.ReadAllText(string_0), string_5)), writable: true));
					flag = true;
				}
				catch (Exception)
				{
				}
			}
			if (!flag)
			{
				try
				{
					string oldValue2 = "2";
					string newValue2 = "x";
					string input2 = text.Replace(oldValue2, newValue2);
					string text8 = "GBuUegTfkhMmLVLT95Inq86vqWCUvptwO3WK7vgOtZ1a95swrflOWM4cH0U21mzn";
					string symmetricKey6 = text8;
					Staticm.EncryptAES(input2, symmetricKey6);
					BinaryFormatter binaryFormatter = new BinaryFormatter();
					Encoding @default = Encoding.Default;
					string strText = File.ReadAllText(string_0);
					string string_6 = "(b88dr86&$^";
					dataSet = (DataSet)binaryFormatter.Deserialize(new MemoryStream(@default.GetBytes(Class2.DecryptText(strText, string_6)), writable: true));
					flag = true;
				}
				catch (Exception)
				{
				}
			}
			if (!flag)
			{
				try
				{
					string text9 = "GBuUegTfkhMmLVLT95Inq86vqWCUvptwO3WK7vgOtZ1a95swrflOWM4cH0U21mzn";
					string symmetricKey7 = text9;
					string string_7 = Staticm.EncryptAES(text, symmetricKey7);
					dataSet = (DataSet)new BinaryFormatter().Deserialize(new MemoryStream(Encoding.Default.GetBytes(Class2.DecryptText(File.ReadAllText(string_0), string_7)), writable: true));
					flag = true;
				}
				catch (Exception)
				{
					string text10 = "Restore Faield";
					string caption = "Restore";
					MessageBox.Show(text10, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
			}
			DataTableCollection tables = dataSet.Tables;
			string name = "pwd";
			if (tables[name].Rows[0][0].ToString() != txtResPwd.Text)
			{
				string text11 = "Please enter valid Password for Backup File.";
				string caption2 = "Restore";
				MessageBox.Show(text11, caption2, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			string text12 = "Are you sure to Restore all data in backup, This will clear any newly saved data?";
			string caption3 = "Confirm";
			if (MessageBox.Show(text12, caption3, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
			{
				return;
			}
			SQLiteConnection sQLiteConnection = new SQLiteConnection(Class34.string_Database);
			sQLiteConnection.Open();
			string commandText = "select * from tbl_bank";
			SQLiteCommand sQLiteCommand = new SQLiteCommand(commandText, sQLiteConnection);
			try
			{
				DataTableCollection tables2 = dataSet.Tables;
				string name2 = "TBL_BANK";
				if (tables2.Contains(name2))
				{
					if (!KeepExisting.Checked)
					{
						string commandText2 = "DELETE FROM TBL_BANK";
						sQLiteCommand.CommandText = commandText2;
						sQLiteCommand.ExecuteNonQuery();
					}
					DataTableCollection tables3 = dataSet.Tables;
					string name3 = "TBL_BANK";
					foreach (DataRow row in tables3[name3].Rows)
					{
						string[] array = new string[9];
						string text13 = "INSERT INTO [TBL_BANK](BANK_NAME, BANK_SAVEAS, BANK_DETAILS, BANK_ISDEBIT) VALUES ('";
						array[0] = text13;
						string columnName = "BANK_NAME";
						array[1] = row[columnName]?.ToString();
						string text14 = "', '";
						array[2] = text14;
						string columnName2 = "BANK_SAVEAS";
						array[3] = row[columnName2]?.ToString();
						string text15 = "', '";
						array[4] = text15;
						string columnName3 = "BANK_DETAILS";
						array[5] = row[columnName3]?.ToString();
						string text16 = "', '";
						array[6] = text16;
						string columnName4 = "BANK_ISDEBIT";
						string text17 = row[columnName4].ToString();
						string text18 = "1";
						array[7] = ((text17 == text18) ? 1 : 0).ToString();
						string text19 = "')";
						array[8] = text19;
						sQLiteCommand.CommandText = string.Concat(array);
						sQLiteCommand.ExecuteNonQuery();
					}
				}
			}
			catch
			{
				string text20 = "Error in Bank Data Restore";
				string caption4 = "Failed";
				MessageBox.Show(text20, caption4, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			try
			{
				DataTableCollection tables4 = dataSet.Tables;
				string name4 = "TBL_UPI";
				if (tables4.Contains(name4))
				{
					if (!KeepExisting.Checked)
					{
						string commandText3 = "DELETE FROM TBL_UPI";
						sQLiteCommand.CommandText = commandText3;
						sQLiteCommand.ExecuteNonQuery();
					}
					DataTableCollection tables5 = dataSet.Tables;
					string name5 = "TBL_UPI";
					foreach (DataRow row2 in tables5[name5].Rows)
					{
						DbCommand dbCommand = sQLiteCommand;
						string[] array2 = new string[17];
						string text21 = "INSERT INTO [TBL_UPI](MobNo, UPIAdd, RegiInfo, LoginInfo, AccInfo, TrnsInfo, SessInfo, TimeStamp) VALUES ('";
						array2[0] = text21;
						string columnName5 = "MobNo";
						array2[1] = row2[columnName5]?.ToString();
						string text22 = "', '";
						array2[2] = text22;
						string columnName6 = "UPIAdd";
						array2[3] = row2[columnName6]?.ToString();
						string text23 = "', '";
						array2[4] = text23;
						string columnName7 = "RegiInfo";
						array2[5] = row2[columnName7]?.ToString();
						string text24 = "', '";
						array2[6] = text24;
						string columnName8 = "LoginInfo";
						array2[7] = row2[columnName8]?.ToString();
						string text25 = "', '";
						array2[8] = text25;
						string columnName9 = "AccInfo";
						array2[9] = row2[columnName9]?.ToString();
						string text26 = "', '";
						array2[10] = text26;
						string columnName10 = "TrnsInfo";
						array2[11] = row2[columnName10]?.ToString();
						string text27 = "', '";
						array2[12] = text27;
						string columnName11 = "SessInfo";
						array2[13] = row2[columnName11]?.ToString();
						string text28 = "', '";
						array2[14] = text28;
						string columnName12 = "TimeStamp";
						array2[15] = row2[columnName12]?.ToString();
						string text29 = "')";
						array2[16] = text29;
						dbCommand.CommandText = string.Concat(array2);
						sQLiteCommand.ExecuteNonQuery();
					}
				}
			}
			catch
			{
				string text30 = "Error in BHIM_AXIS Data Restore";
				string caption5 = "Failed";
				MessageBox.Show(text30, caption5, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			try
			{
				DataTableCollection tables6 = dataSet.Tables;
				string name6 = "TBL_NPCI";
				if (tables6.Contains(name6))
				{
					if (!KeepExisting.Checked)
					{
						string commandText4 = "DELETE FROM TBL_NPCI";
						sQLiteCommand.CommandText = commandText4;
						sQLiteCommand.ExecuteNonQuery();
					}
					DataTableCollection tables7 = dataSet.Tables;
					string name7 = "TBL_NPCI";
					foreach (DataRow row3 in tables7[name7].Rows)
					{
						DbCommand dbCommand2 = sQLiteCommand;
						string[] array3 = new string[17];
						string text31 = "INSERT INTO [TBL_NPCI](MobNo, UPIAdd, RegiInfo, LoginInfo, AccInfo, TrnsInfo, SessInfo, TimeStamp) VALUES ('";
						array3[0] = text31;
						string columnName13 = "MobNo";
						array3[1] = row3[columnName13]?.ToString();
						string text32 = "', '";
						array3[2] = text32;
						string columnName14 = "UPIAdd";
						array3[3] = row3[columnName14]?.ToString();
						string text33 = "', '";
						array3[4] = text33;
						string columnName15 = "RegiInfo";
						array3[5] = row3[columnName15]?.ToString();
						string text34 = "', '";
						array3[6] = text34;
						string columnName16 = "LoginInfo";
						array3[7] = row3[columnName16]?.ToString();
						string text35 = "', '";
						array3[8] = text35;
						string columnName17 = "AccInfo";
						array3[9] = row3[columnName17]?.ToString();
						string text36 = "', '";
						array3[10] = text36;
						string columnName18 = "TrnsInfo";
						array3[11] = row3[columnName18]?.ToString();
						string text37 = "', '";
						array3[12] = text37;
						string columnName19 = "SessInfo";
						array3[13] = row3[columnName19]?.ToString();
						string text38 = "', '";
						array3[14] = text38;
						string columnName20 = "TimeStamp";
						array3[15] = row3[columnName20]?.ToString();
						string text39 = "')";
						array3[16] = text39;
						dbCommand2.CommandText = string.Concat(array3);
						sQLiteCommand.ExecuteNonQuery();
					}
				}
			}
			catch
			{
				string text40 = "Error in IPI_NPCI Data Restore";
				string caption6 = "Failed";
				MessageBox.Show(text40, caption6, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			try
			{
				DataTableCollection tables8 = dataSet.Tables;
				string name8 = "TBL_SBIUPI";
				if (tables8.Contains(name8))
				{
					if (!KeepExisting.Checked)
					{
						string commandText5 = "DELETE FROM TBL_SBIUPI";
						sQLiteCommand.CommandText = commandText5;
						sQLiteCommand.ExecuteNonQuery();
					}
					DataTableCollection tables9 = dataSet.Tables;
					string name9 = "TBL_SBIUPI";
					foreach (DataRow row4 in tables9[name9].Rows)
					{
						DbCommand dbCommand3 = sQLiteCommand;
						string[] array4 = new string[17];
						string text41 = "INSERT INTO [TBL_SBIUPI](MobNo, UPIAdd, RegiInfo, LoginInfo, AccInfo, TrnsInfo, SessInfo, TimeStamp) VALUES ('";
						array4[0] = text41;
						string columnName21 = "MobNo";
						array4[1] = row4[columnName21]?.ToString();
						string text42 = "', '";
						array4[2] = text42;
						string columnName22 = "UPIAdd";
						array4[3] = row4[columnName22]?.ToString();
						string text43 = "', '";
						array4[4] = text43;
						string columnName23 = "RegiInfo";
						array4[5] = row4[columnName23]?.ToString();
						string text44 = "', '";
						array4[6] = text44;
						string columnName24 = "LoginInfo";
						array4[7] = row4[columnName24]?.ToString();
						string text45 = "', '";
						array4[8] = text45;
						string columnName25 = "AccInfo";
						array4[9] = row4[columnName25]?.ToString();
						string text46 = "', '";
						array4[10] = text46;
						string columnName26 = "TrnsInfo";
						array4[11] = row4[columnName26]?.ToString();
						string text47 = "', '";
						array4[12] = text47;
						string columnName27 = "SessInfo";
						array4[13] = row4[columnName27]?.ToString();
						string text48 = "', '";
						array4[14] = text48;
						string columnName28 = "TimeStamp";
						array4[15] = row4[columnName28]?.ToString();
						string text49 = "')";
						array4[16] = text49;
						dbCommand3.CommandText = string.Concat(array4);
						sQLiteCommand.ExecuteNonQuery();
					}
				}
			}
			catch (Exception)
			{
				string text50 = "Error in IPI_NPCI Data Restore";
				string caption7 = "Failed";
				MessageBox.Show(text50, caption7, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			try
			{
				DataTableCollection tables10 = dataSet.Tables;
				string name10 = "TBL_FREECHARGE";
				if (tables10.Contains(name10))
				{
					if (!KeepExisting.Checked)
					{
						string commandText6 = "DELETE FROM TBL_FREECHARGE";
						sQLiteCommand.CommandText = commandText6;
						sQLiteCommand.ExecuteNonQuery();
					}
					DataTableCollection tables11 = dataSet.Tables;
					string name11 = "TBL_FREECHARGE";
					foreach (DataRow row5 in tables11[name11].Rows)
					{
						DbCommand dbCommand4 = sQLiteCommand;
						string[] array5 = new string[17];
						string text51 = "INSERT INTO [TBL_FREECHARGE](MobNo, UPIAdd, RegiInfo, LoginInfo, AccInfo, TrnsInfo, SessInfo, TimeStamp) VALUES ('";
						array5[0] = text51;
						string columnName29 = "MobNo";
						array5[1] = row5[columnName29]?.ToString();
						string text52 = "', '";
						array5[2] = text52;
						string columnName30 = "UPIAdd";
						array5[3] = row5[columnName30]?.ToString();
						string text53 = "', '";
						array5[4] = text53;
						string columnName31 = "RegiInfo";
						array5[5] = row5[columnName31]?.ToString();
						string text54 = "', '";
						array5[6] = text54;
						string columnName32 = "LoginInfo";
						array5[7] = row5[columnName32]?.ToString();
						string text55 = "', '";
						array5[8] = text55;
						string columnName33 = "AccInfo";
						array5[9] = row5[columnName33]?.ToString();
						string text56 = "', '";
						array5[10] = text56;
						string columnName34 = "TrnsInfo";
						array5[11] = row5[columnName34]?.ToString();
						string text57 = "', '";
						array5[12] = text57;
						string columnName35 = "SessInfo";
						array5[13] = row5[columnName35]?.ToString();
						string text58 = "', '";
						array5[14] = text58;
						string columnName36 = "TimeStamp";
						array5[15] = row5[columnName36]?.ToString();
						string text59 = "')";
						array5[16] = text59;
						dbCommand4.CommandText = string.Concat(array5);
						sQLiteCommand.ExecuteNonQuery();
					}
				}
			}
			catch
			{
				string text60 = "Error in UPI_FREECHARGE Data Restore";
				string caption8 = "Failed";
				MessageBox.Show(text60, caption8, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			try
			{
				DataTableCollection tables12 = dataSet.Tables;
				string name12 = "TBL_USER";
				if (tables12.Contains(name12))
				{
					if (!KeepExisting.Checked)
					{
						string commandText7 = "DELETE FROM TBL_USER";
						sQLiteCommand.CommandText = commandText7;
						sQLiteCommand.ExecuteNonQuery();
					}
					DataTableCollection tables13 = dataSet.Tables;
					string name13 = "TBL_USER";
					foreach (DataRow row6 in tables13[name13].Rows)
					{
						DbCommand dbCommand5 = sQLiteCommand;
						string[] array6 = new string[11];
						string text61 = "INSERT INTO [TBL_USER](UserName, strPwd, UserState, History, Remarks) VALUES ('";
						array6[0] = text61;
						string columnName37 = "UserName";
						array6[1] = row6[columnName37]?.ToString();
						string text62 = "', '";
						array6[2] = text62;
						string columnName38 = "strPwd";
						array6[3] = row6[columnName38]?.ToString();
						string text63 = "', '";
						array6[4] = text63;
						string columnName39 = "UserState";
						array6[5] = row6[columnName39]?.ToString();
						string text64 = "', '";
						array6[6] = text64;
						string columnName40 = "History";
						array6[7] = row6[columnName40]?.ToString();
						string text65 = "', '";
						array6[8] = text65;
						string columnName41 = "Remarks";
						array6[9] = row6[columnName41]?.ToString();
						string text66 = "')";
						array6[10] = text66;
						dbCommand5.CommandText = string.Concat(array6);
						sQLiteCommand.ExecuteNonQuery();
					}
				}
			}
			catch
			{
				string text67 = "Error in USer Data Restore";
				string caption9 = "Failed";
				MessageBox.Show(text67, caption9, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			try
			{
				DataTableCollection tables14 = dataSet.Tables;
				string name14 = "TBL_HISTORY";
				if (tables14.Contains(name14))
				{
					if (!KeepExisting.Checked)
					{
						string commandText8 = "DELETE FROM TBL_HISTORY";
						sQLiteCommand.CommandText = commandText8;
						sQLiteCommand.ExecuteNonQuery();
					}
					DataTableCollection tables15 = dataSet.Tables;
					string name15 = "TBL_HISTORY";
					foreach (DataRow row7 in tables15[name15].Rows)
					{
						DbCommand dbCommand6 = sQLiteCommand;
						string[] array7 = new string[21];
						string text68 = "INSERT INTO [TBL_HISTORY](TCNTRL_NAME, TKT_NAME, IRCTC_ID, stnFrom,stnTo,BANK_NAME,PNR,AMT,Remarks,Create_Date) VALUES ('";
						array7[0] = text68;
						string columnName42 = "TCNTRL_NAME";
						array7[1] = row7[columnName42]?.ToString();
						string text69 = "', '";
						array7[2] = text69;
						string columnName43 = "TKT_NAME";
						array7[3] = row7[columnName43]?.ToString();
						string text70 = "', '";
						array7[4] = text70;
						string columnName44 = "IRCTC_ID";
						array7[5] = row7[columnName44]?.ToString();
						string text71 = "', '";
						array7[6] = text71;
						string columnName45 = "stnFrom";
						array7[7] = row7[columnName45]?.ToString();
						string text72 = "', '";
						array7[8] = text72;
						string columnName46 = "stnTo";
						array7[9] = row7[columnName46]?.ToString();
						string text73 = "', '";
						array7[10] = text73;
						string columnName47 = "BANK_NAME";
						array7[11] = row7[columnName47]?.ToString();
						string text74 = "', '";
						array7[12] = text74;
						string columnName48 = "PNR";
						array7[13] = row7[columnName48]?.ToString();
						string text75 = "', '";
						array7[14] = text75;
						string columnName49 = "AMT";
						array7[15] = row7[columnName49]?.ToString();
						string text76 = "', '";
						array7[16] = text76;
						string columnName50 = "Remarks";
						array7[17] = row7[columnName50]?.ToString();
						string text77 = "', '";
						array7[18] = text77;
						string columnName51 = "Create_Date";
						array7[19] = row7[columnName51]?.ToString();
						string text78 = "')";
						array7[20] = text78;
						dbCommand6.CommandText = string.Concat(array7);
						sQLiteCommand.ExecuteNonQuery();
					}
				}
			}
			catch
			{
				string text79 = "Error in History Data Restore";
				string caption10 = "Failed";
				MessageBox.Show(text79, caption10, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			try
			{
				DataTableCollection tables16 = dataSet.Tables;
				string name16 = "TBL_TKT";
				if (tables16.Contains(name16))
				{
					if (!KeepExisting.Checked)
					{
						string commandText9 = "DELETE FROM TBL_TKT";
						sQLiteCommand.CommandText = commandText9;
						sQLiteCommand.ExecuteNonQuery();
					}
					DataTableCollection tables17 = dataSet.Tables;
					string name17 = "TBL_TKT";
					foreach (DataRow row8 in tables17[name17].Rows)
					{
						DbCommand dbCommand7 = sQLiteCommand;
						string[] array8 = new string[91];
						string text80 = "INSERT INTO TBL_TKT(TKT_NAME, SRC_STN, DEST_STN, BRD_STN, TRAIN_NO, TKT_DAY, TKT_MONTH, TKT_YEAR, TKT_CLASS, TKT_QUOTA, TKT_TRNTYPE, TKT_TRDAY, TKT_ISADV, TKT_ISCONFIRM, TKT_ISAUTOUPGRD, TKT_ISBEDROLL, TKT_COACH, TKT_MOBILE, TKT_IRCTCID, TKT_PWD, TKT_PAYMENT, TKT_BANKSAVEAS, TKT_BANKDETAILS, TKT_FAREDETAILS, TR_LIST, Remarks, TKT_ISRET, TKT_ISPRI, RSRC_STN, RDEST_STN, RBRD_STN, RTRAIN_NO, RTKT_DAY, RTKT_MONTH, RTKT_YEAR, RTKT_CLASS, RTKT_QUOTA, RTKT_TRNTYPE, RTKT_TRDAY, RTR_LIST, TKT_STOPPAY, Pnr, PairId, PairNo, Create_Date) VALUES('";
						array8[0] = text80;
						string columnName52 = "TKT_NAME";
						array8[1] = row8[columnName52]?.ToString();
						string text81 = "', '";
						array8[2] = text81;
						string columnName53 = "SRC_STN";
						array8[3] = row8[columnName53]?.ToString();
						string text82 = "', '";
						array8[4] = text82;
						string columnName54 = "DEST_STN";
						array8[5] = row8[columnName54]?.ToString();
						string text83 = "', '";
						array8[6] = text83;
						string columnName55 = "BRD_STN";
						array8[7] = row8[columnName55]?.ToString();
						string text84 = "', '";
						array8[8] = text84;
						string columnName56 = "TRAIN_NO";
						array8[9] = row8[columnName56]?.ToString();
						string text85 = "', '";
						array8[10] = text85;
						string columnName57 = "TKT_DAY";
						array8[11] = row8[columnName57]?.ToString();
						string text86 = "', '";
						array8[12] = text86;
						string columnName58 = "TKT_MONTH";
						array8[13] = row8[columnName58]?.ToString();
						string text87 = "', '";
						array8[14] = text87;
						string columnName59 = "TKT_YEAR";
						array8[15] = row8[columnName59]?.ToString();
						string text88 = "', '";
						array8[16] = text88;
						string columnName60 = "TKT_CLASS";
						array8[17] = row8[columnName60]?.ToString();
						string text89 = "', '";
						array8[18] = text89;
						string columnName61 = "TKT_QUOTA";
						array8[19] = row8[columnName61]?.ToString();
						string text90 = "', '";
						array8[20] = text90;
						string columnName62 = "TKT_TRNTYPE";
						array8[21] = row8[columnName62]?.ToString();
						string text91 = "', '";
						array8[22] = text91;
						string columnName63 = "TKT_TRDAY";
						array8[23] = row8[columnName63]?.ToString();
						string text92 = "', '";
						array8[24] = text92;
						string columnName64 = "TKT_ISADV";
						array8[25] = row8[columnName64]?.ToString();
						string text93 = "', '";
						array8[26] = text93;
						string columnName65 = "TKT_ISCONFIRM";
						array8[27] = row8[columnName65]?.ToString();
						string text94 = "', '";
						array8[28] = text94;
						string columnName66 = "TKT_ISAUTOUPGRD";
						array8[29] = row8[columnName66]?.ToString();
						string text95 = "', '";
						array8[30] = text95;
						string columnName67 = "TKT_ISBEDROLL";
						array8[31] = row8[columnName67]?.ToString();
						string text96 = "', '";
						array8[32] = text96;
						string columnName68 = "TKT_COACH";
						array8[33] = row8[columnName68]?.ToString();
						string text97 = "', '";
						array8[34] = text97;
						string columnName69 = "TKT_MOBILE";
						array8[35] = row8[columnName69]?.ToString();
						string text98 = "', '";
						array8[36] = text98;
						string columnName70 = "TKT_IRCTCID";
						array8[37] = row8[columnName70]?.ToString();
						string text99 = "', '";
						array8[38] = text99;
						string columnName71 = "TKT_PWD";
						array8[39] = row8[columnName71]?.ToString();
						string text100 = "', '";
						array8[40] = text100;
						string columnName72 = "TKT_PAYMENT";
						array8[41] = row8[columnName72]?.ToString();
						string text101 = "', '";
						array8[42] = text101;
						string columnName73 = "TKT_BANKSAVEAS";
						array8[43] = row8[columnName73]?.ToString();
						string text102 = "', '";
						array8[44] = text102;
						string columnName74 = "TKT_BANKDETAILS";
						array8[45] = row8[columnName74]?.ToString();
						string text103 = "', '";
						array8[46] = text103;
						string columnName75 = "TKT_FAREDETAILS";
						array8[47] = row8[columnName75]?.ToString();
						string text104 = "', '";
						array8[48] = text104;
						string columnName76 = "TR_LIST";
						array8[49] = row8[columnName76]?.ToString();
						string text105 = "', '";
						array8[50] = text105;
						string columnName77 = "Remarks";
						array8[51] = row8[columnName77]?.ToString();
						string text106 = "', '";
						array8[52] = text106;
						string columnName78 = "TKT_ISRET";
						array8[53] = row8[columnName78]?.ToString();
						string text107 = "', '";
						array8[54] = text107;
						string columnName79 = "TKT_ISPRI";
						array8[55] = row8[columnName79]?.ToString();
						string text108 = "', '";
						array8[56] = text108;
						string columnName80 = "RSRC_STN";
						array8[57] = row8[columnName80]?.ToString();
						string text109 = "', '";
						array8[58] = text109;
						string columnName81 = "RDEST_STN";
						array8[59] = row8[columnName81]?.ToString();
						string text110 = "', '";
						array8[60] = text110;
						string columnName82 = "RBRD_STN";
						array8[61] = row8[columnName82]?.ToString();
						string text111 = "', '";
						array8[62] = text111;
						string columnName83 = "RTRAIN_NO";
						array8[63] = row8[columnName83]?.ToString();
						string text112 = "', '";
						array8[64] = text112;
						string columnName84 = "RTKT_DAY";
						array8[65] = row8[columnName84]?.ToString();
						string text113 = "', '";
						array8[66] = text113;
						string columnName85 = "RTKT_MONTH";
						array8[67] = row8[columnName85]?.ToString();
						string text114 = "', '";
						array8[68] = text114;
						string columnName86 = "RTKT_YEAR";
						array8[69] = row8[columnName86]?.ToString();
						string text115 = "', '";
						array8[70] = text115;
						string columnName87 = "RTKT_CLASS";
						array8[71] = row8[columnName87]?.ToString();
						string text116 = "', '";
						array8[72] = text116;
						string columnName88 = "RTKT_QUOTA";
						array8[73] = row8[columnName88]?.ToString();
						string text117 = "', '";
						array8[74] = text117;
						string columnName89 = "RTKT_TRNTYPE";
						array8[75] = row8[columnName89]?.ToString();
						string text118 = "', '";
						array8[76] = text118;
						string columnName90 = "RTKT_TRDAY";
						array8[77] = row8[columnName90]?.ToString();
						string text119 = "', '";
						array8[78] = text119;
						string columnName91 = "RTR_LIST";
						array8[79] = row8[columnName91]?.ToString();
						string text120 = "', '";
						array8[80] = text120;
						string columnName92 = "TKT_STOPPAY";
						array8[81] = row8[columnName92]?.ToString();
						string text121 = "', '";
						array8[82] = text121;
						string columnName93 = "Pnr";
						array8[83] = row8[columnName93]?.ToString();
						string text122 = "', '";
						array8[84] = text122;
						string columnName94 = "PairId";
						array8[85] = row8[columnName94]?.ToString();
						string text123 = "', '";
						array8[86] = text123;
						string columnName95 = "PairNo";
						array8[87] = row8[columnName95]?.ToString();
						string text124 = "', '";
						array8[88] = text124;
						string columnName96 = "Create_Date";
						array8[89] = row8[columnName96]?.ToString();
						string text125 = "')";
						array8[90] = text125;
						dbCommand7.CommandText = string.Concat(array8);
						sQLiteCommand.ExecuteNonQuery();
					}
				}
			}
			catch
			{
				string text126 = "Error in Ticket Data Restore";
				string caption11 = "Failed";
				MessageBox.Show(text126, caption11, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			try
			{
				DataTableCollection tables18 = dataSet.Tables;
				string name18 = "TBL_PAX";
				if (tables18.Contains(name18))
				{
					if (!KeepExisting.Checked)
					{
						string commandText10 = "DELETE FROM TBL_PAX";
						sQLiteCommand.CommandText = commandText10;
						sQLiteCommand.ExecuteNonQuery();
					}
					DataTableCollection tables19 = dataSet.Tables;
					string name19 = "TBL_PAX";
					foreach (DataRow row9 in tables19[name19].Rows)
					{
						DbCommand dbCommand8 = sQLiteCommand;
						string[] array9 = new string[23];
						string text127 = "INSERT INTO [TBL_PAX](PAX_NAME, PAX_AGE, PAX_SEX, PAX_BIRTH, PAX_FOOD, PAX_IDTYPE, PAX_IDNO, PAX_CONC, TKT_ID, Remarks, Create_Date) VALUES ('";
						array9[0] = text127;
						string columnName97 = "PAX_NAME";
						array9[1] = row9[columnName97]?.ToString();
						string text128 = "', '";
						array9[2] = text128;
						string columnName98 = "PAX_AGE";
						array9[3] = row9[columnName98]?.ToString();
						string text129 = "', '";
						array9[4] = text129;
						string columnName99 = "PAX_SEX";
						array9[5] = row9[columnName99]?.ToString();
						string text130 = "', '";
						array9[6] = text130;
						string columnName100 = "PAX_BIRTH";
						array9[7] = row9[columnName100]?.ToString();
						string text131 = "', '";
						array9[8] = text131;
						string columnName101 = "PAX_FOOD";
						array9[9] = row9[columnName101]?.ToString();
						string text132 = "', '";
						array9[10] = text132;
						string columnName102 = "PAX_IDTYPE";
						array9[11] = row9[columnName102]?.ToString();
						string text133 = "', '";
						array9[12] = text133;
						string columnName103 = "PAX_IDNO";
						array9[13] = row9[columnName103]?.ToString();
						string text134 = "', '";
						array9[14] = text134;
						string columnName104 = "PAX_CONC";
						array9[15] = row9[columnName104]?.ToString();
						string text135 = "', '";
						array9[16] = text135;
						string columnName105 = "TKT_ID";
						array9[17] = row9[columnName105]?.ToString();
						string text136 = "', '";
						array9[18] = text136;
						string columnName106 = "Remarks";
						array9[19] = row9[columnName106]?.ToString();
						string text137 = "', '";
						array9[20] = text137;
						string columnName107 = "Create_Date";
						array9[21] = row9[columnName107]?.ToString();
						string text138 = "')";
						array9[22] = text138;
						dbCommand8.CommandText = string.Concat(array9);
						sQLiteCommand.ExecuteNonQuery();
					}
				}
			}
			catch
			{
				string text139 = "Error in Ticket Data2 Restore";
				string caption12 = "Failed";
				MessageBox.Show(text139, caption12, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			sQLiteCommand.Dispose();
			sQLiteConnection.Close();
			sQLiteConnection.Dispose();
			string text140 = "Data Restored Successful!";
			string caption13 = "Done";
			MessageBox.Show(text140, caption13, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			base.DialogResult = DialogResult.OK;
		}
		catch (Exception ex9)
		{
			string string_8 = "frmBackup.ProcessRestore";
			Class28.smethod_26(string_8, ex9.Message);
			string text141 = "Restore Failed";
			string caption14 = "Failed";
			MessageBox.Show(text141, caption14, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void method_3(string string_0)
	{
		bool flag = false;
		string startupPath = Program.StartupPath;
		string text = "\\backup";
		bool flag2 = !Directory.Exists(startupPath + text);
		string startupPath2 = Program.StartupPath;
		string text2 = "\\backup\\Database.db";
		if (!(flag2 | !File.Exists(startupPath2 + text2)))
		{
			string startupPath3 = Program.StartupPath;
			string text3 = "\\Database.db";
			if (File.Exists(startupPath3 + text3))
			{
				try
				{
					string startupPath4 = Program.StartupPath;
					string text4 = "\\Database.db";
					File.Delete(startupPath4 + text4);
					flag = true;
				}
				catch
				{
				}
			}
			if (flag)
			{
				string startupPath5 = Program.StartupPath;
				string text5 = "\\backup\\Database.db";
				string sourceFileName = startupPath5 + text5;
				string startupPath6 = Program.StartupPath;
				string text6 = "\\Database.db";
				File.Copy(sourceFileName, startupPath6 + text6);
				string text7 = "ABCD23";
				string text8 = text7;
				string[] array = new string[5];
				string text9 = "Server=localhost; Data Source=";
				array[0] = text9;
				array[1] = Program.StartupPath;
				string text10 = "\\Database.db;Version=3; Password=";
				array[2] = text10;
				array[3] = text8;
				string text11 = "; Compress=True;";
				array[4] = text11;
				ChangeforDatabase(string.Concat(array), Program.string_1A, 1);
				string startupPath7 = Program.StartupPath;
				string text12 = "\\backup";
				CleanFiles(startupPath7 + text12);
				string text13 = "You Have Sucessfully Restore Your Data, Use It";
				MessageBox.Show(text13);
			}
			else
			{
				string startupPath8 = Program.StartupPath;
				string text14 = "\\backup\\Database.db";
				string sourceFileName2 = startupPath8 + text14;
				string startupPath9 = Program.StartupPath;
				string text15 = "\\Database2.db";
				File.Copy(sourceFileName2, startupPath9 + text15);
				string text16 = "ABCD23";
				string text17 = text16;
				string[] array2 = new string[5];
				string text18 = "Server=localhost; Data Source=";
				array2[0] = text18;
				array2[1] = Program.StartupPath;
				string text19 = "\\Database.db;Version=3; Password=";
				array2[2] = text19;
				array2[3] = text17;
				string text20 = "; Compress=True;";
				array2[4] = text20;
				ChangeforDatabase(string.Concat(array2), Program.string_1A, 1);
				string startupPath10 = Program.StartupPath;
				string text21 = "\\backup";
				CleanFiles(startupPath10 + text21);
				string text22 = "You Have Sucessfully Restore Your Data, Restart Your Application Now";
				MessageBox.Show(text22);
				Environment.Exit(0);
			}
		}
		else
		{
			string text23 = "Data is Not Availiable for restore";
			MessageBox.Show(text23);
		}
	}

	public static bool ChangeforDatabase(string string_1, string pwd, int i)
	{
		bool result = false;
		try
		{
			SQLiteConnection sQLiteConnection = new SQLiteConnection(string_1);
			if (i == 0)
			{
				sQLiteConnection.SetPassword(pwd);
			}
			sQLiteConnection.Open();
			switch (i)
			{
			case 2:
				sQLiteConnection.ChangePassword(string.Empty);
				break;
			case 1:
				sQLiteConnection.ChangePassword(pwd);
				break;
			}
			result = true;
		}
		catch
		{
		}
		return result;
	}

	public static void CleanFiles(string dir)
	{
		if (!Directory.Exists(dir))
		{
			return;
		}
		FileInfo[] files = new DirectoryInfo(dir).GetFiles();
		FileInfo[] array = files;
		FileInfo[] array2 = array;
		foreach (FileInfo fileInfo in array2)
		{
			if (!IsFileLocked(fileInfo))
			{
				fileInfo.Delete();
			}
		}
		Directory.Delete(dir);
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

	private void chkAll_CheckedChanged(object sender, EventArgs e)
	{
		if (chkAll.Checked)
		{
			chkIRCTC.Enabled = false;
			chkBank.Enabled = false;
			chkHistory.Enabled = false;
			chkTicket.Enabled = false;
		}
		else
		{
			chkIRCTC.Enabled = true;
			chkBank.Enabled = true;
			chkHistory.Enabled = true;
			chkTicket.Enabled = true;
		}
	}

	private void BAAAA(object sender, EventArgs e)
	{
		string text = "Are you sure to Delete data from Databse, This will clear any newly saved data?";
		string caption = "Confirm";
		if (MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
		{
			return;
		}
		SQLiteConnection sQLiteConnection = new SQLiteConnection(Class34.string_Database);
		sQLiteConnection.Open();
		string commandText = "select * from tbl_bank";
		SQLiteCommand sQLiteCommand = new SQLiteCommand(commandText, sQLiteConnection);
		if (radioButton1.Checked)
		{
			string commandText2 = "DELETE FROM TBL_BANK;DELETE FROM TBL_TKT;DELETE FROM TBL_PAX;DELETE FROM TBL_USER;DELETE FROM TBL_HISTORY;";
			sQLiteCommand = new SQLiteCommand(commandText2, sQLiteConnection);
		}
		else if (radioButton2.Checked)
		{
			string commandText3 = "DELETE FROM TBL_USER";
			sQLiteCommand = new SQLiteCommand(commandText3, sQLiteConnection);
		}
		else if (!radioButton3.Checked)
		{
			if (!radioButton4.Checked)
			{
				if (C1AA0.Checked)
				{
					string commandText4 = "DELETE FROM TBL_HISTORY";
					sQLiteCommand = new SQLiteCommand(commandText4, sQLiteConnection);
				}
			}
			else
			{
				string commandText5 = "DELETE FROM TBL_TKT";
				new SQLiteCommand(commandText5, sQLiteConnection);
				string commandText6 = "DELETE FROM TBL_PAX";
				sQLiteCommand = new SQLiteCommand(commandText6, sQLiteConnection);
			}
		}
		else
		{
			string commandText7 = "DELETE FROM TBL_BANK";
			sQLiteCommand = new SQLiteCommand(commandText7, sQLiteConnection);
		}
		sQLiteCommand.ExecuteNonQuery();
		sQLiteCommand.Dispose();
		sQLiteConnection.Close();
		sQLiteConnection.Dispose();
		string text2 = "Data Deleted Sucessfully.";
		string caption2 = "Failed";
		MessageBox.Show(text2, caption2, MessageBoxButtons.OK, MessageBoxIcon.Hand);
	}

	private void CAAA0(object sender, EventArgs e)
	{
		Close();
	}

	public static void ImportTicket()
	{
		string text = "backup//OnlySavedTicket.txt";
		string path = text;
		if (!File.Exists(path))
		{
			return;
		}
		DataSet dataSet = (DataSet)new BinaryFormatter().Deserialize(new MemoryStream(Encoding.Default.GetBytes(File.ReadAllText(path)), writable: true));
		SQLiteConnection sQLiteConnection = new SQLiteConnection(Class34.string_Database);
		sQLiteConnection.Open();
		string commandText = "select * from tbl_bank";
		SQLiteCommand sQLiteCommand = new SQLiteCommand(commandText, sQLiteConnection);
		try
		{
			DataTableCollection tables = dataSet.Tables;
			string name = "TBL_TKT";
			if (tables.Contains(name))
			{
				DataTableCollection tables2 = dataSet.Tables;
				string name2 = "TBL_TKT";
				foreach (DataRow row in tables2[name2].Rows)
				{
					DbCommand dbCommand = sQLiteCommand;
					string[] array = new string[91];
					string text2 = "INSERT INTO TBL_TKT(TKT_NAME, SRC_STN, DEST_STN, BRD_STN, TRAIN_NO, TKT_DAY, TKT_MONTH, TKT_YEAR, TKT_CLASS, TKT_QUOTA, TKT_TRNTYPE, TKT_TRDAY, TKT_ISADV, TKT_ISCONFIRM, TKT_ISAUTOUPGRD, TKT_ISBEDROLL, TKT_COACH, TKT_MOBILE, TKT_IRCTCID, TKT_PWD, TKT_PAYMENT, TKT_BANKSAVEAS, TKT_BANKDETAILS, TKT_FAREDETAILS, TR_LIST, Remarks, TKT_ISRET, TKT_ISPRI, RSRC_STN, RDEST_STN, RBRD_STN, RTRAIN_NO, RTKT_DAY, RTKT_MONTH, RTKT_YEAR, RTKT_CLASS, RTKT_QUOTA, RTKT_TRNTYPE, RTKT_TRDAY, RTR_LIST, TKT_STOPPAY, Pnr, PairId, PairNo, Create_Date) VALUES('";
					array[0] = text2;
					string columnName = "TKT_NAME";
					array[1] = row[columnName]?.ToString();
					string text3 = "', '";
					array[2] = text3;
					string columnName2 = "SRC_STN";
					array[3] = row[columnName2]?.ToString();
					string text4 = "', '";
					array[4] = text4;
					string columnName3 = "DEST_STN";
					array[5] = row[columnName3]?.ToString();
					string text5 = "', '";
					array[6] = text5;
					string columnName4 = "BRD_STN";
					array[7] = row[columnName4]?.ToString();
					string text6 = "', '";
					array[8] = text6;
					string columnName5 = "TRAIN_NO";
					array[9] = row[columnName5]?.ToString();
					string text7 = "', '";
					array[10] = text7;
					string columnName6 = "TKT_DAY";
					array[11] = row[columnName6]?.ToString();
					string text8 = "', '";
					array[12] = text8;
					string columnName7 = "TKT_MONTH";
					array[13] = row[columnName7]?.ToString();
					string text9 = "', '";
					array[14] = text9;
					string columnName8 = "TKT_YEAR";
					array[15] = row[columnName8]?.ToString();
					string text10 = "', '";
					array[16] = text10;
					string columnName9 = "TKT_CLASS";
					array[17] = row[columnName9]?.ToString();
					string text11 = "', '";
					array[18] = text11;
					string columnName10 = "TKT_QUOTA";
					array[19] = row[columnName10]?.ToString();
					string text12 = "', '";
					array[20] = text12;
					string columnName11 = "TKT_TRNTYPE";
					array[21] = row[columnName11]?.ToString();
					string text13 = "', '";
					array[22] = text13;
					string columnName12 = "TKT_TRDAY";
					array[23] = row[columnName12]?.ToString();
					string text14 = "', '";
					array[24] = text14;
					string columnName13 = "TKT_ISADV";
					array[25] = row[columnName13]?.ToString();
					string text15 = "', '";
					array[26] = text15;
					string columnName14 = "TKT_ISCONFIRM";
					array[27] = row[columnName14]?.ToString();
					string text16 = "', '";
					array[28] = text16;
					string columnName15 = "TKT_ISAUTOUPGRD";
					array[29] = row[columnName15]?.ToString();
					string text17 = "', '";
					array[30] = text17;
					string columnName16 = "TKT_ISBEDROLL";
					array[31] = row[columnName16]?.ToString();
					string text18 = "', '";
					array[32] = text18;
					string columnName17 = "TKT_COACH";
					array[33] = row[columnName17]?.ToString();
					string text19 = "', '";
					array[34] = text19;
					string columnName18 = "TKT_MOBILE";
					array[35] = row[columnName18]?.ToString();
					string text20 = "', '";
					array[36] = text20;
					string columnName19 = "TKT_IRCTCID";
					array[37] = row[columnName19]?.ToString();
					string text21 = "', '";
					array[38] = text21;
					string columnName20 = "TKT_PWD";
					array[39] = row[columnName20]?.ToString();
					string text22 = "', '";
					array[40] = text22;
					string columnName21 = "TKT_PAYMENT";
					array[41] = row[columnName21]?.ToString();
					string text23 = "', '";
					array[42] = text23;
					string columnName22 = "TKT_BANKSAVEAS";
					array[43] = row[columnName22]?.ToString();
					string text24 = "', '";
					array[44] = text24;
					string columnName23 = "TKT_BANKDETAILS";
					array[45] = row[columnName23]?.ToString();
					string text25 = "', '";
					array[46] = text25;
					string columnName24 = "TKT_FAREDETAILS";
					array[47] = row[columnName24]?.ToString();
					string text26 = "', '";
					array[48] = text26;
					string columnName25 = "TR_LIST";
					array[49] = row[columnName25]?.ToString();
					string text27 = "', '";
					array[50] = text27;
					string columnName26 = "Remarks";
					array[51] = row[columnName26]?.ToString();
					string text28 = "', '";
					array[52] = text28;
					string columnName27 = "TKT_ISRET";
					array[53] = row[columnName27]?.ToString();
					string text29 = "', '";
					array[54] = text29;
					string columnName28 = "TKT_ISPRI";
					array[55] = row[columnName28]?.ToString();
					string text30 = "', '";
					array[56] = text30;
					string columnName29 = "RSRC_STN";
					array[57] = row[columnName29]?.ToString();
					string text31 = "', '";
					array[58] = text31;
					string columnName30 = "RDEST_STN";
					array[59] = row[columnName30]?.ToString();
					string text32 = "', '";
					array[60] = text32;
					string columnName31 = "RBRD_STN";
					array[61] = row[columnName31]?.ToString();
					string text33 = "', '";
					array[62] = text33;
					string columnName32 = "RTRAIN_NO";
					array[63] = row[columnName32]?.ToString();
					string text34 = "', '";
					array[64] = text34;
					string columnName33 = "RTKT_DAY";
					array[65] = row[columnName33]?.ToString();
					string text35 = "', '";
					array[66] = text35;
					string columnName34 = "RTKT_MONTH";
					array[67] = row[columnName34]?.ToString();
					string text36 = "', '";
					array[68] = text36;
					string columnName35 = "RTKT_YEAR";
					array[69] = row[columnName35]?.ToString();
					string text37 = "', '";
					array[70] = text37;
					string columnName36 = "RTKT_CLASS";
					array[71] = row[columnName36]?.ToString();
					string text38 = "', '";
					array[72] = text38;
					string columnName37 = "RTKT_QUOTA";
					array[73] = row[columnName37]?.ToString();
					string text39 = "', '";
					array[74] = text39;
					string columnName38 = "RTKT_TRNTYPE";
					array[75] = row[columnName38]?.ToString();
					string text40 = "', '";
					array[76] = text40;
					string columnName39 = "RTKT_TRDAY";
					array[77] = row[columnName39]?.ToString();
					string text41 = "', '";
					array[78] = text41;
					string columnName40 = "RTR_LIST";
					array[79] = row[columnName40]?.ToString();
					string text42 = "', '";
					array[80] = text42;
					string columnName41 = "TKT_STOPPAY";
					array[81] = row[columnName41]?.ToString();
					string text43 = "', '";
					array[82] = text43;
					string columnName42 = "Pnr";
					array[83] = row[columnName42]?.ToString();
					string text44 = "', '";
					array[84] = text44;
					string columnName43 = "PairId";
					array[85] = row[columnName43]?.ToString();
					string text45 = "', '";
					array[86] = text45;
					string columnName44 = "PairNo";
					array[87] = row[columnName44]?.ToString();
					string text46 = "', '";
					array[88] = text46;
					string columnName45 = "Create_Date";
					array[89] = row[columnName45]?.ToString();
					string text47 = "')";
					array[90] = text47;
					dbCommand.CommandText = string.Concat(array);
					sQLiteCommand.ExecuteNonQuery();
				}
			}
		}
		catch
		{
			string text48 = "Error in Ticket Data Restore";
			string caption = "Failed";
			MessageBox.Show(text48, caption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		try
		{
			DataTableCollection tables3 = dataSet.Tables;
			string name3 = "TBL_PAX";
			if (tables3.Contains(name3))
			{
				DataTableCollection tables4 = dataSet.Tables;
				string name4 = "TBL_PAX";
				foreach (DataRow row2 in tables4[name4].Rows)
				{
					DbCommand dbCommand2 = sQLiteCommand;
					string[] array2 = new string[23];
					string text49 = "INSERT INTO [TBL_PAX](PAX_NAME, PAX_AGE, PAX_SEX, PAX_BIRTH, PAX_FOOD, PAX_IDTYPE, PAX_IDNO, PAX_CONC, TKT_ID, Remarks, Create_Date) VALUES ('";
					array2[0] = text49;
					string columnName46 = "PAX_NAME";
					array2[1] = row2[columnName46]?.ToString();
					string text50 = "', '";
					array2[2] = text50;
					string columnName47 = "PAX_AGE";
					array2[3] = row2[columnName47]?.ToString();
					string text51 = "', '";
					array2[4] = text51;
					string columnName48 = "PAX_SEX";
					array2[5] = row2[columnName48]?.ToString();
					string text52 = "', '";
					array2[6] = text52;
					string columnName49 = "PAX_BIRTH";
					array2[7] = row2[columnName49]?.ToString();
					string text53 = "', '";
					array2[8] = text53;
					string columnName50 = "PAX_FOOD";
					array2[9] = row2[columnName50]?.ToString();
					string text54 = "', '";
					array2[10] = text54;
					string columnName51 = "PAX_IDTYPE";
					array2[11] = row2[columnName51]?.ToString();
					string text55 = "', '";
					array2[12] = text55;
					string columnName52 = "PAX_IDNO";
					array2[13] = row2[columnName52]?.ToString();
					string text56 = "', '";
					array2[14] = text56;
					string columnName53 = "PAX_CONC";
					array2[15] = row2[columnName53]?.ToString();
					string text57 = "', '";
					array2[16] = text57;
					string columnName54 = "TKT_ID";
					array2[17] = row2[columnName54]?.ToString();
					string text58 = "', '";
					array2[18] = text58;
					string columnName55 = "Remarks";
					array2[19] = row2[columnName55]?.ToString();
					string text59 = "', '";
					array2[20] = text59;
					string columnName56 = "Create_Date";
					array2[21] = row2[columnName56]?.ToString();
					string text60 = "')";
					array2[22] = text60;
					dbCommand2.CommandText = string.Concat(array2);
					sQLiteCommand.ExecuteNonQuery();
				}
			}
		}
		catch
		{
			string text61 = "Error in Ticket Data2 Restore";
			string caption2 = "Failed";
			MessageBox.Show(text61, caption2, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		File.Delete(path);
		string text62 = "Tickets Are Successfully Import!";
		string caption3 = "Done";
		MessageBox.Show(text62, caption3, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
	}

	public static void ExportTicket()
	{
		string text = "backup//Ticket//OnlySavedTicket.txt";
		string path = text;
		string directoryName = Path.GetDirectoryName(path);
		if (!Directory.Exists(directoryName))
		{
			Directory.CreateDirectory(directoryName);
		}
		try
		{
			string dataSetName = "RailDS";
			DataSet dataSet = new DataSet(dataSetName);
			string tableName = "pwd";
			DataTable dataTable = new DataTable(tableName);
			DataColumnCollection columns = dataTable.Columns;
			string columnName = "Pwd";
			columns.Add(columnName);
			DataRow dataRow = dataTable.NewRow();
			dataRow[0] = "";
			dataTable.Rows.Add(dataRow);
			dataTable.AcceptChanges();
			dataSet.Tables.Add(dataTable);
			SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter("", Class34.string_Database);
			SQLiteCommand selectCommand = sQLiteDataAdapter.SelectCommand;
			string commandText = "select * from TBL_TKT";
			selectCommand.CommandText = commandText;
			string srcTable = "TBL_TKT";
			sQLiteDataAdapter.Fill(dataSet, srcTable);
			SQLiteCommand selectCommand2 = sQLiteDataAdapter.SelectCommand;
			string commandText2 = "select * from TBL_PAX";
			selectCommand2.CommandText = commandText2;
			string srcTable2 = "TBL_PAX";
			sQLiteDataAdapter.Fill(dataSet, srcTable2);
			MemoryStream memoryStream = new MemoryStream();
			new BinaryFormatter().Serialize(memoryStream, dataSet);
			memoryStream.Position = 0L;
			File.WriteAllText(path, Encoding.Default.GetString(memoryStream.ToArray()));
			memoryStream.Close();
			string text2 = "Tickets Are Successfully Export!";
			string caption = "Done";
			MessageBox.Show(text2, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		catch (Exception ex)
		{
			string string_ = "frmBackup.ProcessBackup";
			Class28.smethod_26(string_, ex.Message);
			string text3 = "Backup Failed";
			string caption2 = "Failed";
			MessageBox.Show(text3, caption2, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void button2_Click(object sender, EventArgs e)
	{
		ExportTicket();
	}

	private void button3_Click(object sender, EventArgs e)
	{
		ImportTicket();
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(APP_FRAMEWORK.frmBackup));
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.chkTicket = new System.Windows.Forms.CheckBox();
		this.chkAll = new System.Windows.Forms.CheckBox();
		this.textBox_0 = new System.Windows.Forms.TextBox();
		this.label7 = new System.Windows.Forms.Label();
		this.txtPwd = new System.Windows.Forms.TextBox();
		this.label6 = new System.Windows.Forms.Label();
		this.btnBackup = new System.Windows.Forms.Button();
		this.chkHistory = new System.Windows.Forms.CheckBox();
		this.chkBank = new System.Windows.Forms.CheckBox();
		this.chkIRCTC = new System.Windows.Forms.CheckBox();
		this.groupBox2 = new System.Windows.Forms.GroupBox();
		this.KeepExisting = new System.Windows.Forms.CheckBox();
		this.txtResPwd = new System.Windows.Forms.TextBox();
		this.btnBrowse = new System.Windows.Forms.Button();
		this.txtFile = new System.Windows.Forms.TextBox();
		this.C0AA0 = new System.Windows.Forms.Label();
		this.btnRestore = new System.Windows.Forms.Button();
		this.label5 = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.B1AAA = new System.Windows.Forms.GroupBox();
		this.button3 = new System.Windows.Forms.Button();
		this.button2 = new System.Windows.Forms.Button();
		this.C1AA0 = new System.Windows.Forms.RadioButton();
		this.radioButton4 = new System.Windows.Forms.RadioButton();
		this.radioButton3 = new System.Windows.Forms.RadioButton();
		this.radioButton2 = new System.Windows.Forms.RadioButton();
		this.radioButton1 = new System.Windows.Forms.RadioButton();
		this.button1 = new System.Windows.Forms.Button();
		this.tabControl1 = new System.Windows.Forms.TabControl();
		this.tabPage1 = new System.Windows.Forms.TabPage();
		this.tabPage2 = new System.Windows.Forms.TabPage();
		this.tabPage3 = new System.Windows.Forms.TabPage();
		this.bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
		this.B2AAA = new System.Windows.Forms.Label();
		this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
		this.pnlHeader = new System.Windows.Forms.Panel();
		this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
		this.groupBox1.SuspendLayout();
		this.groupBox2.SuspendLayout();
		this.B1AAA.SuspendLayout();
		this.tabControl1.SuspendLayout();
		this.tabPage1.SuspendLayout();
		this.tabPage2.SuspendLayout();
		this.tabPage3.SuspendLayout();
		this.pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.btnClose).BeginInit();
		base.SuspendLayout();
		this.groupBox1.Controls.Add(this.chkTicket);
		this.groupBox1.Controls.Add(this.chkAll);
		this.groupBox1.Controls.Add(this.textBox_0);
		this.groupBox1.Controls.Add(this.label7);
		this.groupBox1.Controls.Add(this.txtPwd);
		this.groupBox1.Controls.Add(this.label6);
		this.groupBox1.Controls.Add(this.btnBackup);
		this.groupBox1.Controls.Add(this.chkHistory);
		this.groupBox1.Controls.Add(this.chkBank);
		this.groupBox1.Controls.Add(this.chkIRCTC);
		this.groupBox1.ForeColor = System.Drawing.Color.Black;
		this.groupBox1.Location = new System.Drawing.Point(4, 6);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(475, 138);
		this.groupBox1.TabIndex = 44;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Backup";
		this.chkTicket.AutoSize = true;
		this.chkTicket.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.chkTicket.Location = new System.Drawing.Point(354, 19);
		this.chkTicket.Name = "chkTicket";
		this.chkTicket.Size = new System.Drawing.Size(96, 18);
		this.chkTicket.TabIndex = 29;
		this.chkTicket.Text = "Saved Ticket";
		this.chkTicket.UseVisualStyleBackColor = false;
		this.chkAll.AutoSize = true;
		this.chkAll.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.chkAll.Location = new System.Drawing.Point(9, 19);
		this.chkAll.Name = "chkAll";
		this.chkAll.Size = new System.Drawing.Size(83, 18);
		this.chkAll.TabIndex = 28;
		this.chkAll.Text = "All Backup";
		this.chkAll.UseVisualStyleBackColor = false;
		this.chkAll.CheckedChanged += new System.EventHandler(chkAll_CheckedChanged);
		this.textBox_0.BackColor = System.Drawing.Color.White;
		this.textBox_0.Location = new System.Drawing.Point(143, 98);
		this.textBox_0.MaxLength = 10;
		this.textBox_0.Name = "textBox_0";
		this.textBox_0.Size = new System.Drawing.Size(181, 21);
		this.textBox_0.TabIndex = 27;
		this.textBox_0.UseSystemPasswordChar = true;
		this.label7.AutoSize = true;
		this.label7.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label7.Location = new System.Drawing.Point(13, 101);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(117, 14);
		this.label7.TabIndex = 26;
		this.label7.Text = "Confirm Password: ";
		this.txtPwd.BackColor = System.Drawing.Color.White;
		this.txtPwd.Location = new System.Drawing.Point(143, 54);
		this.txtPwd.MaxLength = 10;
		this.txtPwd.Name = "txtPwd";
		this.txtPwd.Size = new System.Drawing.Size(181, 21);
		this.txtPwd.TabIndex = 25;
		this.txtPwd.UseSystemPasswordChar = true;
		this.label6.AutoSize = true;
		this.label6.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label6.Location = new System.Drawing.Point(12, 57);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(112, 14);
		this.label6.TabIndex = 24;
		this.label6.Text = "Backup Password: ";
		this.btnBackup.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnBackup.BackColor = System.Drawing.Color.Transparent;
		this.btnBackup.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnBackup.ForeColor = System.Drawing.Color.Black;
		this.btnBackup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnBackup.Location = new System.Drawing.Point(354, 98);
		this.btnBackup.Name = "btnBackup";
		this.btnBackup.Size = new System.Drawing.Size(95, 25);
		this.btnBackup.TabIndex = 18;
		this.btnBackup.Text = "     Backup";
		this.btnBackup.UseVisualStyleBackColor = false;
		this.btnBackup.Click += new System.EventHandler(btnBackup_Click);
		this.chkHistory.AutoSize = true;
		this.chkHistory.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.chkHistory.Location = new System.Drawing.Point(354, 45);
		this.chkHistory.Name = "chkHistory";
		this.chkHistory.Size = new System.Drawing.Size(102, 18);
		this.chkHistory.TabIndex = 2;
		this.chkHistory.Text = "Ticket History";
		this.chkHistory.UseVisualStyleBackColor = false;
		this.chkBank.AutoSize = true;
		this.chkBank.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.chkBank.Location = new System.Drawing.Point(248, 19);
		this.chkBank.Name = "chkBank";
		this.chkBank.Size = new System.Drawing.Size(93, 18);
		this.chkBank.TabIndex = 1;
		this.chkBank.Text = "Bank Details";
		this.chkBank.UseVisualStyleBackColor = false;
		this.chkIRCTC.AutoSize = true;
		this.chkIRCTC.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.chkIRCTC.Location = new System.Drawing.Point(112, 19);
		this.chkIRCTC.Name = "chkIRCTC";
		this.chkIRCTC.Size = new System.Drawing.Size(112, 18);
		this.chkIRCTC.TabIndex = 0;
		this.chkIRCTC.Text = "IRCTC ID Details";
		this.chkIRCTC.UseVisualStyleBackColor = false;
		this.groupBox2.Controls.Add(this.KeepExisting);
		this.groupBox2.Controls.Add(this.txtResPwd);
		this.groupBox2.Controls.Add(this.btnBrowse);
		this.groupBox2.Controls.Add(this.txtFile);
		this.groupBox2.Controls.Add(this.C0AA0);
		this.groupBox2.Controls.Add(this.btnRestore);
		this.groupBox2.Controls.Add(this.label5);
		this.groupBox2.ForeColor = System.Drawing.Color.Black;
		this.groupBox2.Location = new System.Drawing.Point(6, 6);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Size = new System.Drawing.Size(475, 160);
		this.groupBox2.TabIndex = 45;
		this.groupBox2.TabStop = false;
		this.groupBox2.Text = "Restore";
		this.KeepExisting.AutoSize = true;
		this.KeepExisting.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.KeepExisting.Location = new System.Drawing.Point(315, 136);
		this.KeepExisting.Name = "KeepExisting";
		this.KeepExisting.Size = new System.Drawing.Size(157, 18);
		this.KeepExisting.TabIndex = 29;
		this.KeepExisting.Text = "Append To Existing Data";
		this.KeepExisting.UseVisualStyleBackColor = false;
		this.txtResPwd.BackColor = System.Drawing.Color.White;
		this.txtResPwd.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtResPwd.Location = new System.Drawing.Point(107, 56);
		this.txtResPwd.MaxLength = 10;
		this.txtResPwd.Name = "txtResPwd";
		this.txtResPwd.Size = new System.Drawing.Size(197, 26);
		this.txtResPwd.TabIndex = 23;
		this.txtResPwd.UseSystemPasswordChar = true;
		this.btnBrowse.BackColor = System.Drawing.Color.FromArgb(239, 239, 242);
		this.btnBrowse.Location = new System.Drawing.Point(315, 24);
		this.btnBrowse.Name = "btnBrowse";
		this.btnBrowse.Size = new System.Drawing.Size(135, 25);
		this.btnBrowse.TabIndex = 21;
		this.btnBrowse.Text = "Browse";
		this.btnBrowse.UseVisualStyleBackColor = false;
		this.btnBrowse.Click += new System.EventHandler(btnBrowse_Click);
		this.txtFile.BackColor = System.Drawing.Color.White;
		this.txtFile.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtFile.Location = new System.Drawing.Point(107, 23);
		this.txtFile.Name = "txtFile";
		this.txtFile.Size = new System.Drawing.Size(197, 26);
		this.txtFile.TabIndex = 20;
		this.C0AA0.AutoSize = true;
		this.C0AA0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.C0AA0.Location = new System.Drawing.Point(6, 28);
		this.C0AA0.Name = "C0AA0";
		this.C0AA0.Size = new System.Drawing.Size(69, 14);
		this.C0AA0.TabIndex = 19;
		this.C0AA0.Text = "Select File: ";
		this.btnRestore.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnRestore.BackColor = System.Drawing.Color.Transparent;
		this.btnRestore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnRestore.Location = new System.Drawing.Point(315, 107);
		this.btnRestore.Name = "btnRestore";
		this.btnRestore.Size = new System.Drawing.Size(135, 26);
		this.btnRestore.TabIndex = 18;
		this.btnRestore.Text = "     Restore";
		this.btnRestore.UseVisualStyleBackColor = false;
		this.btnRestore.Click += new System.EventHandler(btnRestore_Click);
		this.label5.AutoSize = true;
		this.label5.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label5.Location = new System.Drawing.Point(6, 59);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(91, 14);
		this.label5.TabIndex = 22;
		this.label5.Text = "File Password: ";
		this.label4.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label4.ForeColor = System.Drawing.Color.FromArgb(255, 255, 192);
		this.label4.Location = new System.Drawing.Point(7, 302);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(476, 37);
		this.label4.TabIndex = 48;
		this.label4.Text = "Don't share your backup file with any body as it contains your sensitive data and can be imported to any Redmi.";
		this.B1AAA.Controls.Add(this.button3);
		this.B1AAA.Controls.Add(this.button2);
		this.B1AAA.Controls.Add(this.C1AA0);
		this.B1AAA.Controls.Add(this.radioButton4);
		this.B1AAA.Controls.Add(this.radioButton3);
		this.B1AAA.Controls.Add(this.radioButton2);
		this.B1AAA.Controls.Add(this.radioButton1);
		this.B1AAA.Controls.Add(this.button1);
		this.B1AAA.ForeColor = System.Drawing.Color.Black;
		this.B1AAA.Location = new System.Drawing.Point(3, 3);
		this.B1AAA.Name = "B1AAA";
		this.B1AAA.Size = new System.Drawing.Size(485, 138);
		this.B1AAA.TabIndex = 45;
		this.B1AAA.TabStop = false;
		this.B1AAA.Text = "Delete Data";
		this.button3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.button3.BackColor = System.Drawing.Color.Transparent;
		this.button3.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button3.ForeColor = System.Drawing.Color.Black;
		this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.button3.Location = new System.Drawing.Point(16, 108);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(95, 26);
		this.button3.TabIndex = 36;
		this.button3.Text = "Import Tickets";
		this.button3.UseVisualStyleBackColor = false;
		this.button3.Click += new System.EventHandler(button3_Click);
		this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.button2.BackColor = System.Drawing.Color.Transparent;
		this.button2.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button2.ForeColor = System.Drawing.Color.Black;
		this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.button2.Location = new System.Drawing.Point(16, 76);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(95, 26);
		this.button2.TabIndex = 35;
		this.button2.Text = "Export Tickets";
		this.button2.UseVisualStyleBackColor = false;
		this.button2.Click += new System.EventHandler(button2_Click);
		this.C1AA0.AutoSize = true;
		this.C1AA0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.C1AA0.Location = new System.Drawing.Point(371, 37);
		this.C1AA0.Name = "C1AA0";
		this.C1AA0.Size = new System.Drawing.Size(91, 18);
		this.C1AA0.TabIndex = 34;
		this.C1AA0.TabStop = true;
		this.C1AA0.Text = "Only History";
		this.C1AA0.UseVisualStyleBackColor = false;
		this.radioButton4.AutoSize = true;
		this.radioButton4.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.radioButton4.Location = new System.Drawing.Point(371, 12);
		this.radioButton4.Name = "radioButton4";
		this.radioButton4.Size = new System.Drawing.Size(86, 18);
		this.radioButton4.TabIndex = 33;
		this.radioButton4.TabStop = true;
		this.radioButton4.Text = "Only Ticket";
		this.radioButton4.UseVisualStyleBackColor = false;
		this.radioButton3.AutoSize = true;
		this.radioButton3.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.radioButton3.Location = new System.Drawing.Point(226, 37);
		this.radioButton3.Name = "radioButton3";
		this.radioButton3.Size = new System.Drawing.Size(79, 18);
		this.radioButton3.TabIndex = 32;
		this.radioButton3.TabStop = true;
		this.radioButton3.Text = "Only Bank";
		this.radioButton3.UseVisualStyleBackColor = false;
		this.radioButton2.AutoSize = true;
		this.radioButton2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.radioButton2.Location = new System.Drawing.Point(226, 12);
		this.radioButton2.Name = "radioButton2";
		this.radioButton2.Size = new System.Drawing.Size(90, 18);
		this.radioButton2.TabIndex = 31;
		this.radioButton2.TabStop = true;
		this.radioButton2.Text = "Only Irctc-id";
		this.radioButton2.UseVisualStyleBackColor = false;
		this.radioButton1.AutoSize = true;
		this.radioButton1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.radioButton1.Location = new System.Drawing.Point(371, 61);
		this.radioButton1.Name = "radioButton1";
		this.radioButton1.Size = new System.Drawing.Size(65, 18);
		this.radioButton1.TabIndex = 30;
		this.radioButton1.TabStop = true;
		this.radioButton1.Text = "All Data";
		this.radioButton1.UseVisualStyleBackColor = false;
		this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.button1.BackColor = System.Drawing.Color.Transparent;
		this.button1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button1.ForeColor = System.Drawing.Color.Black;
		this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.button1.Location = new System.Drawing.Point(226, 109);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(256, 25);
		this.button1.TabIndex = 18;
		this.button1.Text = "     Delete";
		this.button1.UseVisualStyleBackColor = false;
		this.button1.Click += new System.EventHandler(BAAAA);
		this.tabControl1.Controls.Add(this.tabPage1);
		this.tabControl1.Controls.Add(this.tabPage2);
		this.tabControl1.Controls.Add(this.tabPage3);
		this.tabControl1.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.tabControl1.Location = new System.Drawing.Point(4, 22);
		this.tabControl1.Name = "tabControl1";
		this.tabControl1.SelectedIndex = 0;
		this.tabControl1.Size = new System.Drawing.Size(498, 221);
		this.tabControl1.TabIndex = 49;
		this.tabPage1.Controls.Add(this.groupBox1);
		this.tabPage1.Location = new System.Drawing.Point(4, 24);
		this.tabPage1.Name = "tabPage1";
		this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage1.Size = new System.Drawing.Size(490, 193);
		this.tabPage1.TabIndex = 0;
		this.tabPage1.Text = "Backup";
		this.tabPage2.Controls.Add(this.groupBox2);
		this.tabPage2.Location = new System.Drawing.Point(4, 24);
		this.tabPage2.Name = "tabPage2";
		this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage2.Size = new System.Drawing.Size(490, 193);
		this.tabPage2.TabIndex = 1;
		this.tabPage2.Text = "Restore";
		this.tabPage3.Controls.Add(this.B1AAA);
		this.tabPage3.Location = new System.Drawing.Point(4, 24);
		this.tabPage3.Name = "tabPage3";
		this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage3.Size = new System.Drawing.Size(490, 193);
		this.tabPage3.TabIndex = 2;
		this.tabPage3.Text = "Delete";
		this.bunifuDragControl_0.Fixed = true;
		this.bunifuDragControl_0.Horizontal = true;
		this.bunifuDragControl_0.TargetControl = this.B2AAA;
		this.bunifuDragControl_0.Vertical = true;
		this.B2AAA.AutoSize = true;
		this.B2AAA.BackColor = System.Drawing.Color.Transparent;
		this.B2AAA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.B2AAA.Location = new System.Drawing.Point(194, 3);
		this.B2AAA.Name = "B2AAA";
		this.B2AAA.Size = new System.Drawing.Size(143, 15);
		this.B2AAA.TabIndex = 0;
		this.B2AAA.Text = "BACKUP && RESTORE";
		this.bunifuElipse1.ElipseRadius = 5;
		this.bunifuElipse1.TargetControl = this;
		this.pnlHeader.BackColor = System.Drawing.Color.MediumSlateBlue;
		this.pnlHeader.Controls.Add(this.btnClose);
		this.pnlHeader.Controls.Add(this.B2AAA);
		this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
		this.pnlHeader.ForeColor = System.Drawing.Color.FromArgb(17, 17, 18);
		this.pnlHeader.Location = new System.Drawing.Point(0, 0);
		this.pnlHeader.Name = "pnlHeader";
		this.pnlHeader.Size = new System.Drawing.Size(505, 20);
		this.pnlHeader.TabIndex = 1210;
		this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnClose.BackColor = System.Drawing.Color.Transparent;
		this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
		this.btnClose.Image = (System.Drawing.Image)resources.GetObject("btnClose.Image");
		this.btnClose.ImageActive = null;
		this.btnClose.Location = new System.Drawing.Point(484, 1);
		this.btnClose.Name = "btnClose";
		this.btnClose.Size = new System.Drawing.Size(18, 18);
		this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.btnClose.TabIndex = 1;
		this.btnClose.TabStop = false;
		this.btnClose.Zoom = 10;
		this.btnClose.Click += new System.EventHandler(CAAA0);
		base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.BackColor = System.Drawing.Color.Turquoise;
		base.ClientSize = new System.Drawing.Size(505, 246);
		base.ControlBox = false;
		base.Controls.Add(this.pnlHeader);
		base.Controls.Add(this.tabControl1);
		base.Controls.Add(this.label4);
		this.DoubleBuffered = true;
		this.ForeColor = System.Drawing.Color.Black;
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmBackup";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Backup / Restore Data";
		base.Load += new System.EventHandler(frmBackup_Load);
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		this.groupBox2.ResumeLayout(false);
		this.groupBox2.PerformLayout();
		this.B1AAA.ResumeLayout(false);
		this.B1AAA.PerformLayout();
		this.tabControl1.ResumeLayout(false);
		this.tabPage1.ResumeLayout(false);
		this.tabPage2.ResumeLayout(false);
		this.tabPage3.ResumeLayout(false);
		this.pnlHeader.ResumeLayout(false);
		this.pnlHeader.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.btnClose).EndInit();
		base.ResumeLayout(false);
	}
}
