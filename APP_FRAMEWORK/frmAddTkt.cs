using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Booking;
using Bunifu.Framework.UI;
using NEXUS.Booking;

namespace APP_FRAMEWORK;

internal class frmAddTkt : Form
{
	public bool BoolChkTrn;

	public bool stnlist;

	private int int_0;

	public string TrPassingDay;

	public string rTrPassingDay;

	public string Quota = "Genral";

	public string Qt;

	public string StrFareList;

	public string FinalFareString;

	public string FareList;

	public string TrainList;

	public string RTrainList;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private int B4AAA;

	private int C4AA0;

	private int int_5;

	private int int_6;

	private int int_7;

	internal Dictionary<string, string> dictionary_1;

	internal Dictionary<string, string> dictionary_2;

	internal Dictionary<string, string> dictionary_3;

	internal Dictionary<string, string> dictionary_4;

	internal Dictionary<string, string> dictionary_5;

	internal bool bool_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private List<string> list_0;

	private string string_4;

	private string string_5;

	private string B5AAA;

	private string C5AA0;

	private string string_6;

	internal bool bool_1;

	private string string_7;

	private string string_8;

	private string string_9;

	private IDisposable idisposable_0;

	private Label label10;

	private Label label9;

	private Label label6;

	private Label label5;

	private Label label4;

	private Label B6AAA;

	private Label C6AA0;

	private RadioButton rdTatkal;

	private RadioButton rdLadies;

	private RadioButton rdGeneral;

	private TextBox txtBrd;

	private TextBox txtTrainNo;

	private ComboBox cboClass;

	private DateTimePicker dtDate;

	private Label label15;

	private Label label14;

	private Label label13;

	private Label B7AAA;

	private Label C7AA0;

	private Label label7;

	private TextBox txtName1;

	private Panel panel2;

	private Label label21;

	private Label label20;

	private Label label19;

	private Label label18;

	private Label label17;

	private Label label8;

	private CheckBox chk1;

	private ComboBox cboBerth1;

	private ComboBox cboSex1;

	private TextBox txtAge1;

	private CheckBox chk5;

	private ComboBox cboBerth5;

	private ComboBox cboSex5;

	private TextBox txtAge5;

	private TextBox txtName5;

	private CheckBox chk4;

	private ComboBox cboBerth4;

	private ComboBox cboSex4;

	private TextBox txtAge4;

	private TextBox txtName4;

	private CheckBox chk3;

	private ComboBox cboBerth3;

	private ComboBox cboSex3;

	private TextBox txtAge3;

	private TextBox txtName3;

	private CheckBox chk2;

	private ComboBox cboBerth2;

	private ComboBox cboSex2;

	private TextBox txtAge2;

	private TextBox txtName2;

	private CheckBox chk6;

	private ComboBox cboBerth6;

	private ComboBox cboSex6;

	private TextBox txtAge6;

	private TextBox txtName6;

	private ComboBox cboChSex2;

	private TextBox txtChName2;

	private ComboBox cboChSex1;

	private TextBox txtChName1;

	private Panel panel3;

	private Label label22;

	private Label label23;

	private Label label24;

	private Label BCAAA;

	private Label CCAA0;

	private Label label29;

	private Label label16;

	private ComboBox cboAge1;

	private Label label27;

	private CheckBox chkAutoUpgrade;

	private TextBox txtMobNo;

	private ComboBox cboIrctcId;

	private ComboBox cboPayment;

	private Label label30;

	private ComboBox cboAge2;

	private ToolTip BDAAA;

	internal Button btnOk;

	private LinkLabel CDAA0;

	private PictureBox picBrd;

	private Button btnFindTrain;

	private RadioButton rdPtTatkal;

	private ComboBox cboType;

	private Label label39;

	private ComboBox cboFood6;

	private ComboBox cboFood5;

	private ComboBox cboFood4;

	private ComboBox cboFood3;

	private ComboBox cboFood2;

	private ComboBox cboFood1;

	private CheckBox chkBedroll;

	private Label label40;

	private Label label41;

	private TextBox txtID1;

	private Label label3;

	private ComboBox cboID1;

	private ComboBox cboID6;

	private ComboBox cboID5;

	private ComboBox cboID4;

	private ComboBox cboID3;

	private ComboBox cboID2;

	private Panel BFAAA;

	private TextBox CFAA0;

	private TextBox txtID5;

	private TextBox txtID4;

	private TextBox txtID3;

	private TextBox txtID2;

	private TextBox textBox_0;

	private CheckBox checkBox_0;

	private CheckBox chkConfirmOnly;

	private Label label34;

	private TextBox txtTicketName;

	private Label label35;

	private ComboBox cboGateway;

	private GroupBox CGAA0;

	private GroupBox grpPay;

	internal LinkLabel lblAvailability;

	private Label label33;

	private CheckBox chkCH6;

	private CheckBox chkCH5;

	private CheckBox chkCH4;

	private CheckBox chkCH3;

	private CheckBox chkCH2;

	private CheckBox chkCH1;

	private Button btnArrow;

	private CheckBox chkInsurance;

	private TextBox txtTo;

	private TextBox txtFrom;

	private Label label36;

	private CheckBox chkBd6;

	private CheckBox chkBd5;

	private CheckBox chkBd4;

	private CheckBox chkBd3;

	private CheckBox chkBd2;

	private CheckBox chkBd1;

	private CheckBox checkBox1;

	public ComboBox comboBox1;

	private Label label37;

	private Label BA0AA;

	private Label CA0A0;

	private Label setf;

	private Label label28;

	private Panel Panel1;

	private Panel panel11;

	private ComboBox cboGateway_Alt;

	private Label label32;

	internal CheckBox chkConfirmation;

	private ComboBox cboSlotId;

	private Label C20A0;

	private ComboBox cboBdlist;

	private Panel panel5;

	private Panel pnlHeader;

	private BunifuImageButton btnClose;

	private Label label50;

	private Panel panel4;

	internal Button button2;

	private TextBox textBox1;

	private BunifuElipse bunifuElipse_0;

	private IContainer components;

	public ObservableCollection<string> cmbContent { get; set; }

	public frmAddTkt()
	{
		dictionary_2 = new Dictionary<string, string>();
		dictionary_3 = new Dictionary<string, string>();
		dictionary_4 = new Dictionary<string, string>();
		dictionary_5 = new Dictionary<string, string>();
		string_1 = "";
		string_2 = "";
		string_3 = "";
		string_4 = "";
		string_5 = "";
		B5AAA = "";
		stnlist = true;
		InitializeComponent();
		pnlHeader.MouseDown += StatClass.Header_MouseDown;
		pnlHeader.MouseMove += StatClass.Header_MouseMove;
		pnlHeader.MouseUp += StatClass.Header_MouseUp;
		AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
		Control.CheckForIllegalCrossThreadCalls = false;
		dtDate.Value = DateTime.Now;
		DateTime value = dtDate.Value;
		DateTime dateTime = value.AddDays(1.0);
		DateTime dateTime2 = value.AddDays(1.0);
		DateTime dateTime3 = value.AddDays(30.0);
		comboBox1.SelectedIndex = 0;
		string[] array = new string[6];
		string text = "Info: Genral Opening-";
		array[0] = text;
		string text2 = "dd/MM/yyyy";
		array[1] = dateTime.ToString(text2);
		string text3 = ", Suvidha Train Opening-";
		array[2] = text3;
		string text4 = "dd/MM/yyyy";
		array[3] = dateTime3.ToString(text4);
		string text5 = ", Tatkal Opening-";
		array[4] = text5;
		string text6 = "dd/MM/yyyy";
		array[5] = dateTime2.ToString(text6);
		string caption = string.Concat(array);
		string text7 = "Note: Please Fill Journey Details carefully, as we will not validate like whether train running or not between given station / Class of Travel or date etc.";
		string caption2 = text7;
		BDAAA.SetToolTip(dtDate, caption);
		BDAAA.SetToolTip(btnOk, caption2);
		if (DateTime.Now.Hour < 8)
		{
			dtDate.Value = DateTime.Now.AddDays(1.0);
		}
		else if (DateTime.Now.Hour < 12)
		{
			dtDate.Value = DateTime.Now.AddDays(1.0);
		}
		else
		{
			dtDate.Value = DateTime.Now.AddDays(2.0);
		}
		method_0();
		method_2();
		cboPayment.Items.Clear();
		foreach (string item in Program.list_0)
		{
			cboPayment.Items.Add(item);
		}
		dictionary_1 = Program.dictionary_0;
		if (dictionary_1 != null)
		{
			method_4(dictionary_1);
		}
		method_6(bool_2: false);
		BAAAA(bool_2: true);
		try
		{
			if (stnlist)
			{
				txtFrom.AutoCompleteCustomSource = ClassStationData.list_StationCode;
				txtTo.AutoCompleteCustomSource = ClassStationData.list_StationCode;
			}
			else
			{
				smethod_0();
				string commandText = "SELECT STNCD, STNNAME FROM TBL_STN";
				SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter(commandText, Class34.string_Database);
				DataTable dataTable = new DataTable();
				sQLiteDataAdapter.Fill(dataTable);
				sQLiteDataAdapter.Dispose();
				new AutoCompleteStringCollection();
				if (dataTable != null && dataTable.Rows.Count > 5)
				{
					foreach (DataRow row in dataTable.Rows)
					{
						string text8 = row[1].ToString();
						string text9 = row[0].ToString();
						string text10 = " - ";
						string value2 = (text9 + text10 + text8).Trim();
						autoCompleteStringCollection.Add(value2);
						txtFrom.AutoCompleteCustomSource = autoCompleteStringCollection;
						txtTo.AutoCompleteCustomSource = autoCompleteStringCollection;
					}
				}
				dataTable.Dispose();
			}
			DataTable dataTable2 = new DataTable();
			string commandText2 = "SELECT BANK_SAVEAS, BANK_DETAILS from TBL_BANK where BANK_ISDEBIT = 0";
			SQLiteDataAdapter sQLiteDataAdapter2 = new SQLiteDataAdapter(commandText2, Class34.string_Database);
			sQLiteDataAdapter2.Fill(dataTable2);
			sQLiteDataAdapter2.Dispose();
			if (dataTable2 != null && dataTable2.Rows.Count > 0)
			{
				foreach (DataRow row2 in dataTable2.Rows)
				{
					Dictionary<string, string> dictionary = dictionary_2;
					string columnName = "BANK_SAVEAS";
					string key = row2[columnName].ToString();
					string columnName2 = "BANK_DETAILS";
					dictionary.Add(key, row2[columnName2].ToString());
					Dictionary<string, string> dictionary2 = dictionary_5;
					string columnName3 = "BANK_SAVEAS";
					string key2 = row2[columnName3].ToString();
					string columnName4 = "BANK_DETAILS";
					dictionary2.Add(key2, row2[columnName4].ToString());
				}
			}
			dataTable2.Dispose();
			DataTable dataTable3 = new DataTable();
			string commandText3 = "SELECT BANK_SAVEAS, BANK_DETAILS from TBL_BANK where BANK_ISDEBIT = 1";
			SQLiteDataAdapter sQLiteDataAdapter3 = new SQLiteDataAdapter(commandText3, Class34.string_Database);
			sQLiteDataAdapter3.Fill(dataTable3);
			sQLiteDataAdapter3.Dispose();
			if (dataTable3 == null || dataTable3.Rows.Count <= 0)
			{
				return;
			}
			foreach (DataRow row3 in dataTable3.Rows)
			{
				Dictionary<string, string> dictionary3 = dictionary_2;
				string columnName5 = "BANK_SAVEAS";
				string key3 = row3[columnName5].ToString();
				string columnName6 = "BANK_DETAILS";
				dictionary3.Add(key3, row3[columnName6].ToString());
				Dictionary<string, string> dictionary4 = dictionary_3;
				string columnName7 = "BANK_SAVEAS";
				string key4 = row3[columnName7].ToString();
				string columnName8 = "BANK_DETAILS";
				dictionary4.Add(key4, row3[columnName8].ToString());
				Dictionary<string, string> dictionary5 = dictionary_4;
				string columnName9 = "BANK_SAVEAS";
				string key5 = row3[columnName9].ToString();
				string columnName10 = "BANK_DETAILS";
				dictionary5.Add(key5, row3[columnName10].ToString());
				Dictionary<string, string> dictionary6 = dictionary_5;
				string columnName11 = "BANK_SAVEAS";
				string key6 = row3[columnName11].ToString();
				string columnName12 = "BANK_DETAILS";
				dictionary6.Add(key6, row3[columnName12].ToString());
			}
		}
		catch (Exception)
		{
		}
	}

	private static void smethod_0()
	{
		try
		{
			SQLiteConnection sQLiteConnection;
			while (true)
			{
				sQLiteConnection = new SQLiteConnection(Class34.string_Database);
				sQLiteConnection.Open();
				string commandText = "SELECT * FROM [TBL_STN]";
				SQLiteCommand sQLiteCommand = new SQLiteCommand(commandText, sQLiteConnection);
				object obj = sQLiteCommand.ExecuteScalar();
				if (obj != null && !(obj is DBNull))
				{
					string commandText2 = "SELECT [STNCD],[STNNAME] FROM [TBL_STN]";
					SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter(commandText2, Class34.string_Database);
					DataTable dataTable = new DataTable();
					sQLiteDataAdapter.Fill(dataTable);
					if (dataTable == null || dataTable.Rows.Count <= 0)
					{
						break;
					}
					string[] array = ClassStationData.String_24.Split(',');
					if (dataTable.Rows.Count >= array.Length)
					{
						break;
					}
					string commandText3 = "DELETE FROM TBL_STN;";
					sQLiteCommand.CommandText = commandText3;
					sQLiteCommand.ExecuteNonQuery();
					continue;
				}
				string text = "All Station Are Not Listed, Do You Want To One Time Add, It Takes Some Time.";
				string caption = "Add Station";
				if (MessageBox.Show(text, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Hand) == DialogResult.OK)
				{
					string string_ = ClassStationData.String_24;
					char[] separator = new char[1] { ',' };
					string[] array2 = string_.Split(separator);
					string[] array3 = array2;
					string[] array4 = array3;
					foreach (string text2 in array4)
					{
						char[] separator2 = new char[1] { '-' };
						string[] array5 = text2.Split(separator2);
						string text3 = array5[0];
						string[] array6 = new string[5];
						string text4 = "'";
						array6[0] = text4;
						array6[1] = array5[1];
						string text5 = "','";
						array6[2] = text5;
						array6[3] = text3;
						string text6 = "'\r";
						array6[4] = text6;
						string text7 = string.Concat(array6);
						string text8 = "INSERT INTO [TBL_STN](STNCD, STNNAME) VALUES (";
						string text9 = text7.Trim();
						string text10 = ");";
						sQLiteCommand.CommandText = text8 + text9 + text10;
						sQLiteCommand.ExecuteNonQuery();
					}
					string text11 = "All Station Have Added Sucessfully, Thanks";
					string caption2 = "Station Add";
					MessageBox.Show(text11, caption2, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				break;
			}
			sQLiteConnection.Close();
		}
		catch (Exception)
		{
		}
	}

	private void method_0()
	{
		string string_ = Class32.String_22;
		string[] array = new string[1];
		string text = "\r\n";
		array[0] = text;
		string[] array2 = string_.Split(array, StringSplitOptions.RemoveEmptyEntries);
		cboID1.Items.Clear();
		cboID2.Items.Clear();
		cboID3.Items.Clear();
		cboID4.Items.Clear();
		cboID5.Items.Clear();
		cboID6.Items.Clear();
		string[] array3 = array2;
		string[] array4 = array3;
		string[] array5 = array4;
		foreach (string item in array5)
		{
			cboID1.Items.Add(item);
			cboID2.Items.Add(item);
			cboID3.Items.Add(item);
			cboID4.Items.Add(item);
			cboID5.Items.Add(item);
			cboID6.Items.Add(item);
		}
	}

	internal void method_1(Control control_0)
	{
		CGAA0.Visible = false;
		grpPay.Visible = false;
		base.Height = 447;
		btnOk.Visible = false;
		label6.Visible = false;
		rdGeneral.Visible = false;
		rdLadies.Visible = false;
		rdPtTatkal.Visible = false;
		rdTatkal.Visible = false;
		cboType.Visible = false;
		label39.Visible = false;
		chkBedroll.Visible = false;
		string text = "Check Fare";
		Text = text;
		ShowDialog(control_0);
	}

	private void method_2()
	{
		chk1.Tag = txtAge1;
		chk2.Tag = txtAge2;
		chk3.Tag = txtAge3;
		chk4.Tag = txtAge4;
		chk5.Tag = txtAge5;
		chk6.Tag = txtAge6;
		chkCH1.Tag = txtAge1;
		chkCH2.Tag = txtAge2;
		chkCH3.Tag = txtAge3;
		chkCH4.Tag = txtAge4;
		chkCH5.Tag = txtAge5;
		chkCH6.Tag = txtAge6;
		txtAge1.Tag = chk1;
		txtAge2.Tag = chk2;
		txtAge3.Tag = chk3;
		txtAge4.Tag = chk4;
		txtAge5.Tag = chk5;
		txtAge6.Tag = chk6;
		cboID1.Tag = txtID1;
		cboID2.Tag = txtID2;
		cboID3.Tag = txtID3;
		cboID4.Tag = txtID4;
		cboID5.Tag = txtID5;
		cboID6.Tag = CFAA0;
	}

	private void frmAddTkt_Load(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			cboClass.SelectedIndex = 0;
			cboSex1.SelectedIndex = 0;
			cboSex2.SelectedIndex = 0;
			cboSex3.SelectedIndex = 0;
			cboSex4.SelectedIndex = 0;
			cboSex5.SelectedIndex = 0;
			cboSex6.SelectedIndex = 0;
			cboChSex1.SelectedIndex = 0;
			cboChSex2.SelectedIndex = 0;
			cboAge1.SelectedIndex = 0;
			cboAge2.SelectedIndex = 0;
			CAAA0();
			cboType.SelectedIndex = 0;
			try
			{
				cboIrctcId.SelectedIndex = 0;
				cboSlotId.SelectedIndex = 0;
				cboPayment.SelectedIndex = 0;
				cboGateway.SelectedIndex = 0;
				cboGateway_Alt.SelectedIndex = 0;
			}
			catch
			{
			}
			grpPay.Top = CGAA0.Top + CGAA0.Height + panel4.Height + 3;
		}
		txtFrom.Focus();
		if (bool_1)
		{
			foreach (Control control in base.Controls)
			{
				control.Enabled = false;
			}
			btnOk.Visible = false;
		}
		int num = base.Width;
		int num2 = base.Height;
		if (!bool_0)
		{
			base.Height = num2;
			base.Size = new Size(num, num2);
		}
	}

	internal void method_4(Dictionary<string, string> dictionary_5)
	{
		if (dictionary_5 != null)
		{
			cboIrctcId.Items.Clear();
			ComboBox.ObjectCollection items = cboIrctcId.Items;
			string item = "Select_Auto IRCTC-ID";
			items.Add(item);
			foreach (KeyValuePair<string, string> item3 in dictionary_5)
			{
				cboIrctcId.Items.Add(item3.Key);
			}
			dictionary_1 = dictionary_5;
			cboIrctcId.SelectedIndex = 0;
		}
		cboSlotId.Items.Clear();
		ComboBox.ObjectCollection items2 = cboSlotId.Items;
		string item2 = "Select_Auto Slot";
		items2.Add(item2);
		for (int i = 1; i <= Program.int_Slot; i++)
		{
			ComboBox.ObjectCollection items3 = cboSlotId.Items;
			string text = "Slot-";
			items3.Add(text + i);
		}
		cboSlotId.SelectedIndex = 0;
	}

	private void cboType_SelectedIndexChanged(object sender, EventArgs e)
	{
		string text = cboType.SelectedItem.ToString();
		string text2 = text.Substring(text.IndexOf('-') + 1).Trim();
		string_4 = text2.ToUpper();
		method_6(bool_2: false);
		chkBedroll.Enabled = false;
		string text3 = text2.ToUpper();
		string text4 = "R";
		bool flag = text3 == text4;
		string text5 = "D";
		bool flag2 = flag | (text3 == text5);
		string text6 = "T";
		bool flag3 = flag2 | (text3 == text6);
		string text7 = "V";
		bool flag4 = flag3 | (text3 == text7);
		string text8 = "S";
		if (flag4 | (text3 == text8))
		{
			method_6(bool_2: true);
		}
		string text9 = "D";
		if (!(text3 == text9))
		{
			string text10 = "G";
			_ = text3 == text10;
		}
		else
		{
			method_6(bool_2: true);
		}
	}

	private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
	{
		string text = cboClass.SelectedItem.ToString();
		string value = "(";
		string text2 = text.Substring(text.IndexOf(value) + 1, 2);
		this.string_5 = text2.ToUpper();
		if (this.string_4.Length > 0)
		{
			chkBedroll.Checked = false;
			chkBedroll.Enabled = false;
		}
		if (!(text2 != this.string_3))
		{
			return;
		}
		method_5();
		this.string_3 = text2;
		string text3 = text2.ToUpper();
		string text4 = "3A";
		if (!(text3 == text4))
		{
			string text5 = "2A";
			if (!(text3 == text5))
			{
				string text6 = "2S";
				if (!(text3 == text6))
				{
					string text7 = "3E";
					if (!(text3 == text7))
					{
						string text8 = "FC";
						if (text3 == text8)
						{
							string string_ = "No Choice";
							method_7(string_);
							string string_2 = "Lower";
							method_7(string_2);
							string string_3 = "Upper";
							method_7(string_3);
							cboBerth1.SelectedIndex = 1;
							cboBerth2.SelectedIndex = 1;
							cboBerth3.SelectedIndex = 1;
							cboBerth4.SelectedIndex = 1;
							cboBerth5.SelectedIndex = 1;
							cboBerth6.SelectedIndex = 1;
						}
						else
						{
							string text9 = "CC";
							bool flag = text3 == text9;
							string text10 = "EC";
							bool flag2 = flag | (text3 == text10);
							string text11 = "EA";
							bool flag3 = flag2 | (text3 == text11);
							string text12 = "EV";
							if (!(flag3 | (text3 == text12)))
							{
								string text13 = "SL";
								if (!(text3 == text13))
								{
									string text14 = "1A";
									if (!(text3 == text14))
									{
										string text15 = "EC";
										if (!(text3 == text15))
										{
											goto IL_06bb;
										}
									}
									string string_4 = "No Choice";
									method_7(string_4);
									method_9(int_0, Qt, this.string_5);
									return;
								}
								string string_5 = "No Choice";
								method_7(string_5);
								string string_6 = "Lower";
								method_7(string_6);
								string string_7 = "Middle";
								method_7(string_7);
								string string_8 = "Upper";
								method_7(string_8);
								string string_9 = "Side lower";
								method_7(string_9);
								string string_10 = "Side upper";
								method_7(string_10);
								cboBerth1.SelectedIndex = 1;
								cboBerth2.SelectedIndex = 1;
								cboBerth3.SelectedIndex = 1;
								cboBerth4.SelectedIndex = 1;
								cboBerth5.SelectedIndex = 1;
								cboBerth6.SelectedIndex = 1;
								string value2 = "SL";
								if (text2.Contains(value2))
								{
									string text16 = this.string_4;
									string value3 = "D";
									if (text16.Contains(value3))
									{
										chkBedroll.Enabled = true;
									}
								}
							}
							else
							{
								string string_11 = "Window Seat";
								method_7(string_11);
								string string_12 = "No Choice";
								method_7(string_12);
								cboBerth1.SelectedIndex = 2;
								cboBerth2.SelectedIndex = 2;
								cboBerth3.SelectedIndex = 2;
								cboBerth4.SelectedIndex = 2;
								cboBerth5.SelectedIndex = 2;
								cboBerth6.SelectedIndex = 2;
							}
						}
					}
					else
					{
						string string_13 = "No Choice";
						method_7(string_13);
						string string_14 = "Lower";
						method_7(string_14);
						string string_15 = "Middle";
						method_7(string_15);
						string string_16 = "Upper";
						method_7(string_16);
						string string_17 = "Side lower";
						method_7(string_17);
						string string_18 = "Side middle";
						method_7(string_18);
						string string_19 = "Side upper";
						method_7(string_19);
						cboBerth1.SelectedIndex = 1;
						cboBerth2.SelectedIndex = 1;
						cboBerth3.SelectedIndex = 1;
						cboBerth4.SelectedIndex = 1;
						cboBerth5.SelectedIndex = 1;
						cboBerth6.SelectedIndex = 1;
					}
				}
				else
				{
					string string_20 = "Window Seat";
					method_7(string_20);
					string string_21 = "No Choice";
					method_7(string_21);
					cboBerth1.SelectedIndex = 2;
					cboBerth2.SelectedIndex = 2;
					cboBerth3.SelectedIndex = 2;
					cboBerth4.SelectedIndex = 2;
					cboBerth5.SelectedIndex = 2;
					cboBerth6.SelectedIndex = 2;
				}
			}
			else
			{
				string string_22 = "No Choice";
				method_7(string_22);
				string string_23 = "Lower";
				method_7(string_23);
				string string_24 = "Upper";
				method_7(string_24);
				string string_25 = "Side lower";
				method_7(string_25);
				string string_26 = "Side upper";
				method_7(string_26);
				cboBerth1.SelectedIndex = 1;
				cboBerth2.SelectedIndex = 1;
				cboBerth3.SelectedIndex = 1;
				cboBerth4.SelectedIndex = 1;
				cboBerth5.SelectedIndex = 1;
				cboBerth6.SelectedIndex = 1;
			}
		}
		else
		{
			string string_27 = "No Choice";
			method_7(string_27);
			string string_28 = "Lower";
			method_7(string_28);
			string string_29 = "Middle";
			method_7(string_29);
			string string_30 = "Upper";
			method_7(string_30);
			string string_31 = "Side lower";
			method_7(string_31);
			string string_32 = "Side upper";
			method_7(string_32);
			cboBerth1.SelectedIndex = 1;
			cboBerth2.SelectedIndex = 1;
			cboBerth3.SelectedIndex = 1;
			cboBerth4.SelectedIndex = 1;
			cboBerth5.SelectedIndex = 1;
			cboBerth6.SelectedIndex = 1;
			string value4 = "SL";
			if (text2.Contains(value4))
			{
				string text17 = this.string_4;
				string value5 = "D";
				if (text17.Contains(value5))
				{
					chkBedroll.Enabled = true;
				}
			}
		}
		goto IL_06bb;
		IL_06bb:
		method_9(int_0, Qt, this.string_5);
	}

	private void method_5()
	{
		cboBerth1.Items.Clear();
		cboBerth2.Items.Clear();
		cboBerth3.Items.Clear();
		cboBerth4.Items.Clear();
		cboBerth5.Items.Clear();
		cboBerth6.Items.Clear();
		ComboBox.ObjectCollection items = cboBerth1.Items;
		string item = "Choose Berth";
		items.Add(item);
		ComboBox.ObjectCollection items2 = cboBerth2.Items;
		string item2 = "Choose Berth";
		items2.Add(item2);
		ComboBox.ObjectCollection items3 = cboBerth3.Items;
		string item3 = "Choose Berth";
		items3.Add(item3);
		ComboBox.ObjectCollection items4 = cboBerth4.Items;
		string item4 = "Choose Berth";
		items4.Add(item4);
		ComboBox.ObjectCollection items5 = cboBerth5.Items;
		string item5 = "Choose Berth";
		items5.Add(item5);
		ComboBox.ObjectCollection items6 = cboBerth6.Items;
		string item6 = "Choose Berth";
		items6.Add(item6);
	}

	private void method_6(bool bool_2)
	{
		if (bool_2)
		{
			cboFood1.Enabled = true;
			cboFood2.Enabled = true;
			cboFood3.Enabled = true;
			cboFood4.Enabled = true;
			cboFood5.Enabled = true;
			cboFood6.Enabled = true;
			cboFood1.SelectedIndex = 0;
			cboFood2.SelectedIndex = 0;
			cboFood3.SelectedIndex = 0;
			cboFood4.SelectedIndex = 0;
			cboFood5.SelectedIndex = 0;
			cboFood6.SelectedIndex = 0;
		}
		else
		{
			cboFood1.Enabled = false;
			cboFood2.Enabled = false;
			cboFood3.Enabled = false;
			cboFood4.Enabled = false;
			cboFood5.Enabled = false;
			cboFood6.Enabled = false;
			cboFood1.SelectedIndex = -1;
			cboFood2.SelectedIndex = -1;
			cboFood3.SelectedIndex = -1;
			cboFood4.SelectedIndex = -1;
			cboFood5.SelectedIndex = -1;
			cboFood6.SelectedIndex = -1;
		}
	}

	private void BAAAA(bool bool_2)
	{
		if (bool_2)
		{
			cboID1.Enabled = true;
			cboID2.Enabled = true;
			cboID3.Enabled = true;
			cboID4.Enabled = true;
			cboID5.Enabled = true;
			cboID6.Enabled = true;
			txtID1.Enabled = true;
			txtID2.Enabled = true;
			txtID3.Enabled = true;
			txtID4.Enabled = true;
			txtID5.Enabled = true;
			CFAA0.Enabled = true;
			cboID1.SelectedIndex = 0;
			cboID2.SelectedIndex = 0;
			cboID3.SelectedIndex = 0;
			cboID4.SelectedIndex = 0;
			cboID5.SelectedIndex = 0;
			cboID6.SelectedIndex = 0;
		}
		else
		{
			cboID1.Enabled = false;
			cboID2.Enabled = false;
			cboID3.Enabled = false;
			cboID4.Enabled = false;
			cboID5.Enabled = false;
			cboID6.Enabled = false;
			txtID1.Enabled = false;
			txtID2.Enabled = false;
			txtID3.Enabled = false;
			txtID4.Enabled = false;
			txtID5.Enabled = false;
			CFAA0.Enabled = false;
			cboID1.SelectedIndex = -1;
			cboID2.SelectedIndex = -1;
			cboID3.SelectedIndex = -1;
			cboID4.SelectedIndex = -1;
			cboID5.SelectedIndex = -1;
			cboID6.SelectedIndex = -1;
		}
	}

	private void CAAA0()
	{
		cboBerth1.SelectedIndex = 0;
		cboBerth2.SelectedIndex = 0;
		cboBerth3.SelectedIndex = 0;
		cboBerth4.SelectedIndex = 0;
		cboBerth5.SelectedIndex = 0;
		cboBerth6.SelectedIndex = 0;
	}

	private void method_7(string string_10)
	{
		cboBerth1.Items.Add(string_10);
		cboBerth2.Items.Add(string_10);
		cboBerth3.Items.Add(string_10);
		cboBerth4.Items.Add(string_10);
		cboBerth5.Items.Add(string_10);
		cboBerth6.Items.Add(string_10);
	}

	private void method_8(bool bool_2)
	{
		if (bool_2)
		{
			txtName5.Visible = true;
			txtName6.Visible = true;
			txtAge5.Visible = true;
			txtAge6.Visible = true;
			cboSex5.Visible = true;
			cboSex6.Visible = true;
			cboBerth5.Visible = true;
			cboBerth6.Visible = true;
			cboFood5.Visible = true;
			cboFood6.Visible = true;
			chk5.Visible = true;
			chk6.Visible = true;
			chkBd5.Visible = true;
			chkBd6.Visible = true;
			chkCH5.Visible = true;
			chkCH6.Visible = true;
			label17.Visible = true;
			label18.Visible = true;
			cboID5.Visible = true;
			cboID6.Visible = true;
			txtID5.Visible = true;
			CFAA0.Visible = true;
		}
		else
		{
			txtName5.Visible = false;
			txtName6.Visible = false;
			txtAge5.Visible = false;
			txtAge6.Visible = false;
			cboSex5.Visible = false;
			cboSex6.Visible = false;
			cboBerth5.Visible = false;
			cboBerth6.Visible = false;
			cboFood5.Visible = false;
			cboFood6.Visible = false;
			chk5.Visible = false;
			chk6.Visible = false;
			chkBd5.Visible = false;
			chkBd6.Visible = false;
			chkCH5.Visible = false;
			chkCH6.Visible = false;
			label17.Visible = false;
			label18.Visible = false;
			cboID5.Visible = false;
			cboID6.Visible = false;
			txtID5.Visible = false;
			CFAA0.Visible = false;
		}
	}

	private void chk1_CheckedChanged(object sender, EventArgs e)
	{
		CheckBox checkBox = sender as CheckBox;
		if (rdTatkal.Checked || rdPtTatkal.Checked)
		{
			checkBox.Checked = false;
		}
		else
		{
			if (!base.Visible || !base.Created || checkBox == null || !checkBox.Checked)
			{
				return;
			}
			int result = 0;
			TextBox textBox = checkBox.Tag as TextBox;
			Control.ControlCollection controls = CGAA0.Controls;
			string text = "cboSex";
			ComboBox comboBox = (ComboBox)controls[text + checkBox.Name.Substring(checkBox.Name.Length - 1, 1)];
			if (textBox != null)
			{
				if (!int.TryParse(textBox.Text, out result))
				{
					string text2 = "Kindly enter valid age!";
					MessageBox.Show(text2);
					checkBox.Checked = false;
					textBox.Focus();
				}
				else if (comboBox.SelectedIndex <= 0)
				{
					checkBox.Checked = false;
					comboBox.Focus();
				}
				else if ((comboBox.SelectedIndex == 1 && result < 60) || (comboBox.SelectedIndex == 2 && result < 58))
				{
					string text3 = "To click Senior Citizen the Age must be More than or Equal to 60 for Male and 58 for Female";
					string caption = "Conc";
					MessageBox.Show(text3, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					checkBox.Checked = false;
					textBox.Focus();
				}
			}
		}
	}

	private void txtAge1_Leave(object sender, EventArgs e)
	{
		TextBox textBox = (TextBox)sender;
		textBox.BackColor = Color.White;
		textBox.Text = textBox.Text.Trim();
		if (textBox == null)
		{
			return;
		}
		int result = 0;
		if (int.TryParse(textBox.Text, out result))
		{
			string name = textBox.Name;
			string oldValue = "txtAge";
			string text = name.Replace(oldValue, "");
			if (result > 60)
			{
				CheckBox checkBox = (CheckBox)textBox.Tag;
				if (checkBox != null)
				{
					checkBox.Checked = false;
				}
				Control.ControlCollection controls = CGAA0.Controls;
				string text2 = "chk";
				((CheckBox)controls[text2 + text]).Checked = true;
			}
			if (result >= 5 && result <= 11)
			{
				Control.ControlCollection controls2 = CGAA0.Controls;
				string text3 = "chkCH";
				((CheckBox)controls2[text3 + text]).Checked = true;
			}
			_ = textBox.Tag;
			Control.ControlCollection controls3 = CGAA0.Controls;
			string text4 = "cboSex";
			((ListControl)controls3[text4 + text]).SelectedIndex = 1;
		}
		else if (textBox.Text.Length > 0)
		{
			string text5 = "Enter Valid value for Age of Passenger ";
			MessageBox.Show(text5 + textBox.Name.Substring(6));
			textBox.Text = "";
		}
	}

	public void faresetup()
	{
		if (comboBox1.SelectedIndex == 0)
		{
			int_6 = int_5 + int_3;
			setf.Text = int_6.ToString();
		}
		else if (comboBox1.SelectedIndex != 1)
		{
			if (comboBox1.SelectedIndex != 2)
			{
				if (comboBox1.SelectedIndex == 3)
				{
					int_6 = int_5 + int_3 * 100 / 100;
					setf.Text = (int_3 + int_6).ToString();
				}
				else if (comboBox1.SelectedIndex == 4)
				{
					int_6 = int_5 + int_3 * 150 / 100;
					setf.Text = (int_3 + int_6).ToString();
				}
				else if (comboBox1.SelectedIndex == 5)
				{
					int_6 = int_5 + int_3 * 200 / 100;
					setf.Text = (int_3 + int_6).ToString();
				}
			}
			else
			{
				int_6 = int_5 + int_3 * 50 / 100;
				setf.Text = (int_3 + int_6).ToString();
			}
		}
		else
		{
			int_6 = int_5 + int_3 * 25 / 100;
			setf.Text = (int_3 + int_6).ToString();
		}
	}

	private void method_9(int int_8, string string_10, string string_11)
	{
		if (string_10 == "" || string_11 == "")
		{
			return;
		}
		if (FareList != null)
		{
			string fareList = FareList;
			string text = "0";
			if (!(fareList == text))
			{
				goto IL_00a4;
			}
		}
		FareList = StrFareList;
		if (FareList != null)
		{
			string fareList2 = FareList;
			string text2 = "0";
			if (fareList2 == text2)
			{
				return;
			}
			goto IL_00a4;
		}
		return;
		IL_00a4:
		StrFareList = FareList;
		string fareList3 = FareList;
		string[] array = new string[1];
		string text3 = ":";
		array[0] = text3;
		string[] array2 = fareList3.Split(array, StringSplitOptions.RemoveEmptyEntries);
		int num = 7;
		switch (PrivateImp.ComputeStringHash(string_11))
		{
		case 485468421u:
		{
			string text11 = "3E";
			if (string_11 == text11)
			{
				num = 9;
			}
			break;
		}
		case 418357945u:
		{
			string text7 = "3A";
			if (string_11 == text7)
			{
				num = 4;
			}
			break;
		}
		case 1022499324u:
		{
			string text9 = "2A";
			if (string_11 == text9)
			{
				num = 3;
			}
			break;
		}
		case 787612658u:
		{
			string text5 = "2S";
			if (string_11 == text5)
			{
				num = 8;
			}
			break;
		}
		case 1661113898u:
		{
			string text10 = "SL";
			if (string_11 == text10)
			{
				num = 7;
			}
			break;
		}
		case 1290499943u:
		{
			string text8 = "1A";
			if (string_11 == text8)
			{
				num = 2;
			}
			break;
		}
		case 2245226254u:
		{
			string text6 = "FC";
			if (string_11 == text6)
			{
				num = 6;
			}
			break;
		}
		case 1977225635u:
		{
			string text4 = "CC";
			if (string_11 == text4)
			{
				num = 5;
			}
			break;
		}
		}
		string text12 = array2[num].ToString();
		string[] array3 = new string[1];
		string text13 = ",";
		array3[0] = text13;
		string[] array4 = text12.Split(array3, StringSplitOptions.RemoveEmptyEntries);
		try
		{
			int_3 = int.Parse(array4[0]);
			int_4 = int.Parse(array4[1]);
			B4AAA = int.Parse(array4[2]);
			C4AA0 = int.Parse(array4[4]);
			int_5 = int.Parse(array4[3]);
			string text14 = "GN";
			bool flag = string_10 == text14;
			string text15 = "LD";
			if (flag | (string_10 == text15))
			{
				int_7 = int_3;
				BA0AA.Text = int_7.ToString();
			}
			else
			{
				int_7 = int_3 + int_5;
				BA0AA.Text = int_7.ToString();
			}
		}
		catch
		{
			int_3 = 0;
			int_4 = 0;
			B4AAA = 0;
			C4AA0 = 0;
			int_5 = 0;
			string text16 = "GN";
			bool flag2 = string_10 == text16;
			string text17 = "LD";
			if (flag2 | (string_10 == text17))
			{
				int_7 = int_3;
				BA0AA.Text = int_7.ToString();
			}
			else
			{
				int_7 = int_3 + int_5;
				BA0AA.Text = int_7.ToString();
			}
		}
	}

	private void method_10(string string_10, int int_8, bool bool_2, string string_11)
	{
		string text = "GN";
		bool flag = string_11 == text;
		string text2 = "LD";
		if (flag | (string_11 == text2))
		{
			bool flag2 = int_8 >= 60;
			string text3 = "M";
			if (flag2 & (string_10 == text3))
			{
				int_1 += B4AAA;
				return;
			}
			bool flag3 = int_8 >= 58;
			string text4 = "F";
			if (flag3 & (string_10 == text4))
			{
				int_1 += C4AA0;
			}
			else if (int_8 < 12 && !bool_2)
			{
				int_1 += int_4;
			}
			else
			{
				int_1 += int_3;
			}
			return;
		}
		string text5 = "TQ";
		if (!(string_11 == text5))
		{
			string text6 = "TQ";
			bool flag4 = string_11 == text6;
			string text7 = "PT";
			if (flag4 | (string_11 == text7))
			{
				if (int_8 < 12 && !bool_2)
				{
					int_1 += int_4 + int_5;
				}
				else
				{
					int_1 += int_3 + int_5;
				}
				if (comboBox1.SelectedIndex == 0)
				{
					int_6 = int_5;
					setf.Text = int_6.ToString();
				}
				if (int_8 < 12 && !bool_2)
				{
					int_2 += int_4 + int_6;
				}
				else
				{
					int_2 += int_3 + int_6;
				}
			}
		}
		else if (int_8 >= 12 || bool_2)
		{
			int_1 += int_3 + int_5;
		}
		else
		{
			int_1 += int_4 + int_5;
		}
	}

	private void btnOk_Click(object sender, EventArgs e)
	{
		if (!Program.bool_7)
		{
			string text = "Non Payment ke karan Aapka Booking stop he, aapke seller se contact kijiye.";
			string caption = "Booking Stop";
			MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		else
		{
			if (!method_11(bool_2: false))
			{
				return;
			}
			Class48 @class = method_12();
			if (cboGateway_Alt.SelectedIndex > 0)
			{
				string string_ = @class.string_23;
				string text2 = "-+-";
				@class.string_23 = string_ + text2 + cboGateway_Alt.SelectedItem.ToString();
				string string_2 = @class.string_24;
				string text3 = "-+-";
				@class.string_24 = string_2 + text3 + dictionary_5[cboGateway_Alt.SelectedItem.ToString()];
			}
			string finalFareString;
			if (panel5.Visible)
			{
				if (!string.IsNullOrEmpty(textBox1.Text))
				{
					string text4 = textBox1.Text;
					string text5 = "||0||0";
					finalFareString = text4 + text5;
				}
				else
				{
					string text6 = "0||0||0";
					finalFareString = text6;
				}
			}
			else
			{
				string text7 = "0||0||0";
				finalFareString = text7;
			}
			FinalFareString = finalFareString;
			@class.string_25 = FinalFareString;
			if (@class.method_1())
			{
				string text8 = "New Ticket Saved Sucessfully! Your New Ticket Details Are? \r\n\r\nClick 'YES' to Save Your Ticket.";
				string caption2 = "Save Ticket";
				MessageBox.Show(text8, caption2, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				base.DialogResult = DialogResult.OK;
				Close();
			}
		}
	}

	private bool method_11(bool bool_2)
	{
		string text = txtFrom.Text.Trim();
		if (string.IsNullOrEmpty(text))
		{
			string text2 = "Invalid value in 'From' Station.";
			string caption = "Invalid Station";
			MessageBox.Show(text2, caption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			txtFrom.Focus();
			return false;
		}
		string text3 = text;
		string value = "-";
		if (text3.Contains(value))
		{
			string text4 = text;
			string text5 = text;
			string value2 = "-";
			text = text4.Substring(text5.IndexOf(value2) + 1).Trim();
		}
		if (Class34.smethod_6(text))
		{
			string text6 = txtTo.Text.Trim();
			if (!string.IsNullOrEmpty(text6))
			{
				string text7 = text6;
				string value3 = "-";
				if (text7.Contains(value3))
				{
					string text8 = text6;
					string text9 = text6;
					string value4 = "-";
					text6 = text8.Substring(text9.IndexOf(value4) + 1).Trim();
				}
				if (Class34.smethod_6(text6))
				{
					string text10 = txtBrd.Text.Trim();
					if (string.IsNullOrEmpty(text10))
					{
						string text11 = "Invalid value in 'Boarding' Station.";
						string caption2 = "Invalid Station";
						MessageBox.Show(text11, caption2, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						txtBrd.Focus();
						return false;
					}
					string text12 = text10;
					string value5 = "-";
					if (text12.Contains(value5))
					{
						string text13 = text10;
						string text14 = text10;
						string value6 = "-";
						text10 = text13.Substring(text14.IndexOf(value6) + 1).Trim();
					}
					if (!Class34.smethod_6(text10))
					{
						string text15 = "Invalid value in 'Boarding' Station. Only Alphabets are allowed!";
						string caption3 = "Invalid Station";
						MessageBox.Show(text15, caption3, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						txtBrd.Focus();
						return false;
					}
					string text16 = txtTrainNo.Text.Trim();
					if (!string.IsNullOrEmpty(text16))
					{
						if (Class34.smethod_2(text16))
						{
							if (!(dtDate.Value < DateTime.Parse(DateTime.Now.ToShortDateString())))
							{
								if (cboClass.SelectedIndex > 0)
								{
									long ticks = DateTime.Now.AddDays(122.0).Ticks;
									long ticks2 = dtDate.Value.Ticks;
									if (Math.Floor(new TimeSpan(ticks - ticks2).TotalDays) > 122.0)
									{
										string text17 = " Please Check The Journey Date.. \n Reservation is permitted for 120 days in advance with \nrespect to train starting station(journey date not to be counted)";
										string caption4 = "Date of Journey";
										MessageBox.Show(text17, caption4, MessageBoxButtons.OK, MessageBoxIcon.Hand);
										dtDate.Focus();
										return false;
									}
									if (cboType.SelectedIndex < 1)
									{
										string text18 = " Please Select Valid Train Type";
										string caption5 = "Train Type";
										MessageBox.Show(text18, caption5, MessageBoxButtons.OK, MessageBoxIcon.Hand);
										cboType.Focus();
										return false;
									}
									string text19 = string_4;
									string text20 = "R";
									if (!(text19 == text20))
									{
										string text21 = "S";
										if (text19 == text21)
										{
											string text22 = string_5;
											string value7 = "CC";
											if (!text22.Contains(value7))
											{
												string text23 = string_5;
												string value8 = "EC";
												if (!text23.Contains(value8))
												{
													string text24 = string_5;
													string value9 = "2S";
													if (!text24.Contains(value9))
													{
														string text25 = "Invalid class for Shatabdi Train!";
														string caption6 = "Class";
														MessageBox.Show(text25, caption6, MessageBoxButtons.OK, MessageBoxIcon.Hand);
														cboClass.Focus();
														return false;
													}
												}
											}
										}
										goto IL_0644;
									}
									string text26 = string_5;
									string value10 = "SL";
									if (!text26.Contains(value10))
									{
										string text27 = string_5;
										string value11 = "2S";
										if (!text27.Contains(value11))
										{
											string text28 = string_5;
											string value12 = "3E";
											if (!text28.Contains(value12))
											{
												string text29 = string_5;
												string value13 = "CC";
												if (!text29.Contains(value13))
												{
													string text30 = string_5;
													string value14 = "EC";
													if (!text30.Contains(value14))
													{
														goto IL_0644;
													}
												}
											}
										}
									}
									string text31 = "Invalid class for Rajdhani Train!";
									string caption7 = "Class";
									MessageBox.Show(text31, caption7, MessageBoxButtons.OK, MessageBoxIcon.Hand);
									cboClass.Focus();
									return false;
								}
								string text32 = "Select Valid class!";
								string caption8 = "Class";
								MessageBox.Show(text32, caption8, MessageBoxButtons.OK, MessageBoxIcon.Hand);
								cboClass.Focus();
								return false;
							}
							string text33 = " Please Check The Journey Date... \n The Date Of Journey Should not be older than today.";
							string caption9 = "Date of Journey";
							MessageBox.Show(text33, caption9, MessageBoxButtons.OK, MessageBoxIcon.Hand);
							dtDate.Focus();
							return false;
						}
						string text34 = "Invalid value for Train Number. Only AlphaNumerics are allowed!";
						string caption10 = "Invalid TrainNo";
						MessageBox.Show(text34, caption10, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						txtTrainNo.Focus();
						return false;
					}
					string text35 = "Invalid value for Train Number.";
					string caption11 = "Invalid TrainNo";
					MessageBox.Show(text35, caption11, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					txtTrainNo.Focus();
					return false;
				}
				string text36 = "Invalid value in 'To' Station. Only Alphabets are allowed!";
				string caption12 = "Invalid Station";
				MessageBox.Show(text36, caption12, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				txtTo.Focus();
				return false;
			}
			string text37 = "Invalid value in 'To' Station.";
			string caption13 = "Invalid Station";
			MessageBox.Show(text37, caption13, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			txtTo.Focus();
			return false;
		}
		string text38 = "Invalid value in 'From' Station. Only Alphabets are allowed!";
		string caption14 = "Invalid Station";
		MessageBox.Show(text38, caption14, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		txtFrom.Focus();
		return false;
		IL_0644:
		int num = 0;
		for (int i = 1; i <= 6; i++)
		{
			Control.ControlCollection controls = CGAA0.Controls;
			string text39 = "txtName";
			TextBox textBox = (TextBox)controls[text39 + i];
			if (!textBox.Visible)
			{
				continue;
			}
			Control.ControlCollection controls2 = CGAA0.Controls;
			string text40 = "txtAge";
			TextBox textBox2 = (TextBox)controls2[text40 + i];
			Control.ControlCollection controls3 = CGAA0.Controls;
			string text41 = "cboSex";
			ComboBox comboBox = (ComboBox)controls3[text41 + i];
			Control.ControlCollection controls4 = CGAA0.Controls;
			string text42 = "cboBerth";
			ComboBox comboBox2 = (ComboBox)controls4[text42 + i];
			Control.ControlCollection controls5 = CGAA0.Controls;
			string text43 = "chk";
			CheckBox checkBox = (CheckBox)controls5[text43 + i];
			Control.ControlCollection controls6 = CGAA0.Controls;
			string text44 = "cboFood";
			ComboBox comboBox3 = (ComboBox)controls6[text44 + i];
			Control.ControlCollection controls7 = CGAA0.Controls;
			string text45 = "cboID";
			ComboBox comboBox4 = (ComboBox)controls7[text45 + i];
			Control.ControlCollection controls8 = CGAA0.Controls;
			string text46 = "txtID";
			TextBox textBox3 = (TextBox)controls8[text46 + i];
			Control.ControlCollection controls9 = CGAA0.Controls;
			string text47 = "chkCH";
			CheckBox checkBox2 = (CheckBox)controls9[text47 + i];
			string text48 = textBox.Text;
			int result = 0;
			if ((text48.Length == 0) & (textBox2.Text.Length == 0))
			{
				comboBox2.SelectedIndex = 0;
			}
			if (text48.Length <= 0 && textBox2.Text.Length <= 0 && comboBox.SelectedIndex <= 0 && comboBox2.SelectedIndex <= 0 && !checkBox.Checked)
			{
				continue;
			}
			if (!string.IsNullOrEmpty(text48))
			{
				if (text48.Length >= 3)
				{
					if (textBox2.Text.Length > 0 && int.TryParse(textBox2.Text, out result))
					{
						if (result >= 5)
						{
							if (comboBox.SelectedIndex > 0)
							{
								if (comboBox2.SelectedIndex > 0)
								{
									if ((result >= 60 && !checkBox.Checked && checkBox.Enabled && comboBox.SelectedIndex == 1) || (result >= 58 && !checkBox.Checked && checkBox.Enabled && comboBox.SelectedIndex == 2))
									{
										string text49 = "Passenger ";
										string text50 = " is eligible for Senior Citizen Concession. To avail the concession, please click on 'OK' and the box alongside the name. \r\n\r\n if concession is not required, please click on 'Cancel'.";
										string text51 = text49 + text48 + text50;
										string caption15 = "Concession";
										if (MessageBox.Show(text51, caption15, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
										{
											checkBox.Focus();
											return false;
										}
									}
									if ((result >= 60 || !checkBox.Checked || comboBox.SelectedIndex != 0) && (result >= 58 || !checkBox.Checked || comboBox.SelectedIndex != 1))
									{
										if (result >= 5 && result <= 11 && !checkBox2.Checked)
										{
											string text52 = "Do you need seat for ";
											string text53 = textBox.Text;
											string text54 = "?\r\n\r\nIf yes then Opt for Child Seat otherwise Click NO.";
											string text55 = text52 + text53 + text54;
											string caption16 = "Child Fare";
											if (MessageBox.Show(text55, caption16, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
											{
												checkBox2.Focus();
												return false;
											}
										}
										if (rdLadies.Checked)
										{
											string text56 = comboBox.SelectedItem.ToString();
											string text57 = "M";
											if (text56 == text57 && result > 11)
											{
												string text58 = "Male Above 11 Yrs Is Not Eligible For Ladies Quota";
												string caption17 = "Ladies Quota";
												MessageBox.Show(text58, caption17, MessageBoxButtons.OK, MessageBoxIcon.Hand);
												comboBox.Focus();
												return false;
											}
										}
										if (!comboBox3.Enabled || comboBox3.SelectedIndex >= 1)
										{
											if (comboBox4.Enabled && comboBox4.SelectedIndex > 0)
											{
												textBox3.Text = textBox3.Text.Trim();
												if (!Class34.smethod_1(textBox3.Text))
												{
													string text59 = "Please Enter valid ID Card No. It should be Atleast 4 characters.\r\n\r\nCard No. can have alphabets (A to Z), Numbers (0 to 9) or / or - characters only.";
													string caption18 = "ID Card NO.";
													MessageBox.Show(text59, caption18, MessageBoxButtons.OK, MessageBoxIcon.Hand);
													textBox3.Focus();
													return false;
												}
												num++;
											}
											if (comboBox4.SelectedIndex == 1 && textBox3.Text.Trim().Length != 12)
											{
												string text60 = "Please Enter valid 12 Digit AADHAR No.";
												string caption19 = "ID Card NO.";
												MessageBox.Show(text60, caption19, MessageBoxButtons.OK, MessageBoxIcon.Hand);
												textBox3.Focus();
												return false;
											}
											continue;
										}
										string text61 = "Please select valid Food Choice.";
										string caption20 = "Food Choice";
										MessageBox.Show(text61, caption20, MessageBoxButtons.OK, MessageBoxIcon.Hand);
										comboBox3.Focus();
										return false;
									}
									string text62 = "Passenger ";
									string text63 = " is not eligible for Senior Citizen Concession.";
									string text64 = text62 + text48 + text63;
									string caption21 = "Concession";
									MessageBox.Show(text64, caption21, MessageBoxButtons.OK, MessageBoxIcon.Hand);
									checkBox.Focus();
									return false;
								}
								string text65 = "Please select Berth preference of Passenger ";
								string text66 = text65 + i;
								string caption22 = "Passenger Berth";
								MessageBox.Show(text66, caption22, MessageBoxButtons.OK, MessageBoxIcon.Hand);
								comboBox2.Focus();
								return false;
							}
							string text67 = "Please select the Sex of Passenger ";
							string text68 = text67 + i;
							string caption23 = "Passenger Sex";
							MessageBox.Show(text68, caption23, MessageBoxButtons.OK, MessageBoxIcon.Hand);
							comboBox.Focus();
							return false;
						}
						string text69 = "Enter Valid value for Age ";
						string text70 = text69 + i;
						string caption24 = "Passenger Age";
						MessageBox.Show(text70, caption24, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						textBox2.Focus();
						return false;
					}
					string text71 = "Enter Valid value for Age ";
					string text72 = text71 + i;
					string caption25 = "Passenger Age";
					MessageBox.Show(text72, caption25, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					textBox2.Focus();
					return false;
				}
				string text73 = "Passenger Name should be of atleast Three characters ";
				string caption26 = "Passenger Name";
				MessageBox.Show(text73, caption26, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				textBox.Focus();
				return false;
			}
			string text74 = "Enter the Passenger Name. ";
			string caption27 = "Passenger Name";
			MessageBox.Show(text74, caption27, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			textBox.Focus();
			return false;
		}
		for (int j = 1; j <= 2; j++)
		{
			Control.ControlCollection controls10 = BFAAA.Controls;
			string text75 = "txtChName";
			TextBox textBox4 = (TextBox)controls10[text75 + j];
			Control.ControlCollection controls11 = BFAAA.Controls;
			string text76 = "cboAge";
			ComboBox comboBox5 = (ComboBox)controls11[text76 + j];
			Control.ControlCollection controls12 = BFAAA.Controls;
			string text77 = "cboChSex";
			ComboBox comboBox6 = (ComboBox)controls12[text77 + j];
			string text78 = textBox4.Text;
			if (text78.Length > 0 || comboBox5.SelectedIndex > 0 || comboBox6.SelectedIndex > 0)
			{
				if (string.IsNullOrEmpty(text78))
				{
					string text79 = "Enter the Child Passenger Name. ";
					string caption28 = "Passenger Name";
					MessageBox.Show(text79, caption28, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					textBox4.Focus();
					return false;
				}
				if (text78.Length < 3)
				{
					string text80 = "Passenger Name should be of atleast Three characters ";
					string caption29 = "Passenger Name";
					MessageBox.Show(text80, caption29, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					textBox4.Focus();
					return false;
				}
				if (comboBox5.SelectedIndex <= 0)
				{
					string text81 = "Select Valid value for Age ";
					string text82 = text81 + j;
					string caption30 = "Passenger Age";
					MessageBox.Show(text82, caption30, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					comboBox5.Focus();
					return false;
				}
				if (comboBox6.SelectedIndex <= 0)
				{
					string text83 = "Please select the Sex of Passenger ";
					string text84 = text83 + j;
					string caption31 = "Passenger Sex";
					MessageBox.Show(text84, caption31, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					comboBox6.Focus();
					return false;
				}
			}
		}
		if (!string.IsNullOrEmpty(txtMobNo.Text) && Class34.smethod_4(txtMobNo.Text))
		{
			if (cboPayment.SelectedIndex > 0)
			{
				if (cboGateway.SelectedIndex > 0)
				{
					if (cboIrctcId.SelectedIndex < 0)
					{
						string text85 = "Select the IRCTC ID which use to book the ticket!";
						string caption32 = "IRCTC ID";
						MessageBox.Show(text85, caption32, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						cboIrctcId.Focus();
						return false;
					}
					if (checkBox_0.Checked && textBox_0.Text.Trim().Length < 2)
					{
						string text86 = "Please Enter valid Coach ID.";
						string caption33 = "Coach ID";
						MessageBox.Show(text86, caption33, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						txtMobNo.Focus();
						return false;
					}
					if (cboSlotId.SelectedIndex < 0)
					{
						string text87 = "Select the Valid Slot to book the ticket!";
						string caption34 = "Slot Option";
						MessageBox.Show(text87, caption34, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						cboSlotId.Focus();
						return false;
					}
					string text88 = txtTicketName.Text.Replace('_', 'A').Replace('-', 'A').Replace('*', 'A');
					if (!string.IsNullOrEmpty(text88) && Class34.smethod_3(text88))
					{
						if (bool_0 && Class48.smethod_0(txtTicketName.Text.Trim()))
						{
							string text89 = "Ticket Already Exists! Do you want to Update existing or Create New Ticket? \r\n\r\nClick 'YES' to update existing Ticket.\r\nClick 'NO' to Save as New Ticket.\r\nClick 'Cancel' to cancel the Saving.";
							string caption35 = "Update";
							switch (MessageBox.Show(text89, caption35, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
							{
							case DialogResult.Yes:
								Class48.smethod_1(txtTicketName.Text.Trim());
								break;
							case DialogResult.Cancel:
								return false;
							}
						}
						if (Class48.smethod_0(txtTicketName.Text.Trim()))
						{
							string text90 = "Ticket Name Already Exist, Please enter different name";
							string caption36 = "Ticket Name";
							MessageBox.Show(text90, caption36, MessageBoxButtons.OK, MessageBoxIcon.Hand);
							txtTicketName.Focus();
							return false;
						}
						return true;
					}
					string text91 = "Please enter valid Ticket Name! (Only Alphabets, Numbers and (_) (-) are allowed)";
					string caption37 = "Ticket Name";
					MessageBox.Show(text91, caption37, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					txtTicketName.Focus();
					return false;
				}
				string text92 = "Select the payment Gateway option!";
				string caption38 = "Payment Option";
				MessageBox.Show(text92, caption38, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				cboGateway.Focus();
				return false;
			}
			string text93 = "Select the payment method option!";
			string caption39 = "Payment Option";
			MessageBox.Show(text93, caption39, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			cboPayment.Focus();
			return false;
		}
		string text94 = "Please Enter valid mobile number.";
		string caption40 = "Mobile No.";
		MessageBox.Show(text94, caption40, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		txtMobNo.Focus();
		return false;
	}

	internal Class48 method_12()
	{
		Class48 @class = new Class48();
		string text2;
		if (!rdTatkal.Checked)
		{
			if (!rdPtTatkal.Checked)
			{
				if (!rdLadies.Checked)
				{
					string text = "GN";
					text2 = text;
				}
				else
				{
					string text3 = "LD";
					text2 = text3;
				}
			}
			else
			{
				string text4 = "PT";
				text2 = text4;
			}
		}
		else
		{
			string text5 = "TQ";
			text2 = text5;
		}
		@class.string_8 = text2;
		@class.string_4 = dtDate.Value.Day.ToString();
		@class.string_5 = dtDate.Value.Month.ToString();
		@class.string_6 = dtDate.Value.Year.ToString();
		@class.string_3 = txtBrd.Text.Trim();
		@class.string_0 = txtFrom.Text.Trim();
		@class.string_1 = txtTo.Text.Trim();
		string text6 = @class.string_3;
		string value = "-";
		if (text6.Contains(value))
		{
			string text7 = @class.string_3;
			string text8 = @class.string_3;
			string value2 = "-";
			@class.string_3 = text7.Substring(text8.IndexOf(value2) + 1).Trim();
		}
		string string_ = @class.string_0;
		string value3 = "-";
		if (string_.Contains(value3))
		{
			string string_2 = @class.string_0;
			string string_3 = @class.string_0;
			string value4 = "-";
			@class.string_0 = string_2.Substring(string_3.IndexOf(value4) + 1).Trim();
		}
		string text9 = @class.string_1;
		string value5 = "-";
		if (text9.Contains(value5))
		{
			string text10 = @class.string_1;
			string text11 = @class.string_1;
			string value6 = "-";
			@class.string_1 = text10.Substring(text11.IndexOf(value6) + 1).Trim();
		}
		@class.string_22 = cboPayment.SelectedIndex.ToString();
		@class.string_23 = cboGateway.SelectedItem.ToString();
		@class.bool_7 = chkInsurance.Checked;
		switch (cboPayment.SelectedIndex)
		{
		default:
			@class.string_24 = cboGateway.SelectedItem.ToString();
			break;
		case 1:
			@class.string_24 = dictionary_2[cboGateway.SelectedItem.ToString()];
			break;
		case 2:
			@class.string_24 = dictionary_3[cboGateway.SelectedItem.ToString()];
			break;
		case 3:
			@class.string_24 = dictionary_4[cboGateway.SelectedItem.ToString()];
			break;
		}
		if (txtChName1.Text.Length > 0)
		{
			List<Class38> list_ = @class.list_1;
			string text12 = txtChName1.Text;
			string text13 = (cboAge1.SelectedIndex - 1).ToString();
			string string_4 = cboChSex1.SelectedItem.ToString();
			Class38 item = new Class38(text12, text13, string_4, "", bool_0: false);
			list_.Add(item);
		}
		if (txtChName2.Text.Length > 0)
		{
			List<Class38> list_2 = @class.list_1;
			string text14 = txtChName2.Text;
			string text15 = (cboAge2.SelectedIndex - 1).ToString();
			string string_5 = cboChSex2.SelectedItem.ToString();
			Class38 item2 = new Class38(text14, text15, string_5, "", bool_0: false);
			list_2.Add(item2);
		}
		if (rdTatkal.Checked || rdPtTatkal.Checked)
		{
			chk1.Checked = false;
			chk2.Checked = false;
			chk3.Checked = false;
			chk4.Checked = false;
			chk5.Checked = false;
			chk6.Checked = false;
		}
		if (txtName1.Text.Length > 0)
		{
			Class38 class2 = new Class38(txtName1.Text, txtAge1.Text, cboSex1.SelectedItem.ToString(), cboBerth1.SelectedItem.ToString(), chk1.Checked);
			if (cboFood1.Enabled && cboFood1.SelectedIndex > 0)
			{
				class2.string_5 = cboFood1.SelectedItem.ToString();
			}
			if (cboID1.Enabled && cboID1.SelectedIndex > 0)
			{
				class2.string_6 = cboID1.SelectedItem.ToString();
				class2.string_7 = txtID1.Text.Trim();
			}
			if (chkCH1.Enabled && chkCH1.Checked)
			{
				string string_6 = class2.string_0;
				string text16 = "-";
				class2.string_0 = string_6 + text16;
			}
			@class.list_0.Add(class2);
			method_10(cboSex1.Text, int.Parse(txtAge1.Text), chkCH1.Checked, @class.string_8);
		}
		if (txtName2.Text.Length > 0)
		{
			Class38 class3 = new Class38(txtName2.Text, txtAge2.Text, cboSex2.SelectedItem.ToString(), cboBerth2.SelectedItem.ToString(), chk2.Checked);
			if (cboFood2.Enabled && cboFood2.SelectedIndex > 0)
			{
				class3.string_5 = cboFood2.SelectedItem.ToString();
			}
			if (cboID2.Enabled && cboID2.SelectedIndex > 0)
			{
				class3.string_6 = cboID2.SelectedItem.ToString();
				class3.string_7 = txtID2.Text.Trim();
			}
			if (chkCH2.Enabled && chkCH2.Checked)
			{
				string string_7 = class3.string_0;
				string text17 = "-";
				class3.string_0 = string_7 + text17;
			}
			@class.list_0.Add(class3);
			method_10(cboSex2.Text, int.Parse(txtAge2.Text), chkCH2.Checked, @class.string_8);
		}
		if (txtName3.Text.Length > 0)
		{
			Class38 class4 = new Class38(txtName3.Text, txtAge3.Text, cboSex3.SelectedItem.ToString(), cboBerth3.SelectedItem.ToString(), chk3.Checked);
			if (cboFood3.Enabled && cboFood3.SelectedIndex > 0)
			{
				class4.string_5 = cboFood3.SelectedItem.ToString();
			}
			if (cboID3.Enabled && cboID3.SelectedIndex > 0)
			{
				class4.string_6 = cboID3.SelectedItem.ToString();
				class4.string_7 = txtID3.Text.Trim();
			}
			if (chkCH3.Enabled && chkCH3.Checked)
			{
				string string_8 = class4.string_0;
				string text18 = "-";
				class4.string_0 = string_8 + text18;
			}
			@class.list_0.Add(class4);
			method_10(cboSex3.Text, int.Parse(txtAge3.Text), chkCH3.Checked, @class.string_8);
		}
		if (txtName4.Text.Length > 0)
		{
			Class38 class5 = new Class38(txtName4.Text, txtAge4.Text, cboSex4.SelectedItem.ToString(), cboBerth4.SelectedItem.ToString(), chk4.Checked);
			if (cboFood4.Enabled && cboFood4.SelectedIndex > 0)
			{
				class5.string_5 = cboFood4.SelectedItem.ToString();
			}
			if (cboID4.Enabled && cboID4.SelectedIndex > 0)
			{
				class5.string_6 = cboID4.SelectedItem.ToString();
				class5.string_7 = txtID4.Text.Trim();
			}
			if (chkCH4.Enabled && chkCH4.Checked)
			{
				string string_9 = class5.string_0;
				string text19 = "-";
				class5.string_0 = string_9 + text19;
			}
			@class.list_0.Add(class5);
			method_10(cboSex4.Text, int.Parse(txtAge4.Text), chkCH4.Checked, @class.string_8);
		}
		if (rdGeneral.Checked || rdLadies.Checked)
		{
			if (txtName5.Text.Length > 0)
			{
				Class38 class6 = new Class38(txtName5.Text, txtAge5.Text, cboSex5.SelectedItem.ToString(), cboBerth5.SelectedItem.ToString(), chk5.Checked);
				if (cboFood5.Enabled && cboFood5.SelectedIndex > 0)
				{
					class6.string_5 = cboFood5.SelectedItem.ToString();
				}
				if (chkCH5.Enabled && chkCH5.Checked)
				{
					string string_10 = class6.string_0;
					string text20 = "-";
					class6.string_0 = string_10 + text20;
				}
				@class.list_0.Add(class6);
				method_10(cboSex5.Text, int.Parse(txtAge5.Text), chkCH5.Checked, @class.string_8);
			}
			if (txtName6.Text.Length > 0)
			{
				Class38 class7 = new Class38(txtName6.Text, txtAge6.Text, cboSex6.SelectedItem.ToString(), cboBerth6.SelectedItem.ToString(), chk6.Checked);
				if (cboFood6.Enabled && cboFood6.SelectedIndex > 0)
				{
					class7.string_5 = cboFood6.SelectedItem.ToString();
				}
				if (chkCH6.Enabled && chkCH6.Checked)
				{
					string string_11 = class7.string_0;
					string text21 = "-";
					class7.string_0 = string_11 + text21;
				}
				@class.list_0.Add(class7);
				method_10(cboSex6.Text, int.Parse(txtAge6.Text), chkCH6.Checked, @class.string_8);
			}
		}
		@class.string_13 = cboIrctcId.SelectedItem.ToString();
		if (dictionary_1 != null)
		{
			dictionary_1.TryGetValue(@class.string_13, out @class.string_14);
		}
		@class.string_13 = "";
		@class.string_15 = cboSlotId.SelectedItem.ToString();
		@class.string_2 = txtTrainNo.Text.Trim();
		@class.string_7 = cboClass.SelectedItem.ToString();
		string text22 = @class.string_7;
		string text23 = @class.string_7;
		string value7 = "(";
		@class.string_7 = text22.Substring(text23.IndexOf(value7) + 1, 2);
		@class.bool_2 = chkAutoUpgrade.Checked;
		@class.bool_3 = chkConfirmOnly.Checked;
		string text24 = txtMobNo.Text;
		string text25 = "||KARAHI||272002||UTTAR PRADESH||Basti||Karahi B.O";
		@class.mobile_num = text24 + text25;
		if (checkBox_0.Checked)
		{
			@class.string_10 = textBox_0.Text.Trim();
		}
		@class.string_12 = txtTicketName.Text.Trim();
		@class.string_16 = this.string_4;
		@class.string_17 = TrPassingDay;
		if (chkBedroll.Enabled && chkBedroll.Checked)
		{
			@class.bool_1 = true;
		}
		@class.string_25 = FinalFareString;
		@class.string_38 = TrainList;
		@class.string_39 = RTrainList;
		@class.bool_6 = chkConfirmation.Checked;
		return @class;
	}

	internal void EditLoad(Class48 class48_0)
	{
		if (class48_0 == null)
		{
			return;
		}
		try
		{
			dtDate.Value = new DateTime(int.Parse(class48_0.string_6), int.Parse(class48_0.string_5), int.Parse(class48_0.string_4));
			string text = class48_0.string_8;
			string text2 = "TQ";
			if (!(text == text2))
			{
				string text3 = class48_0.string_8;
				string text4 = "PT";
				if (text3 == text4)
				{
					rdPtTatkal.Checked = true;
				}
				else
				{
					string text5 = class48_0.string_8;
					string text6 = "LD";
					if (!(text5 == text6))
					{
						rdGeneral.Checked = true;
					}
					else
					{
						rdLadies.Checked = true;
					}
				}
			}
			else
			{
				rdTatkal.Checked = true;
			}
			foreach (object item in cboClass.Items)
			{
				string text7 = item.ToString();
				string value = "(";
				if (text7.Substring(text7.IndexOf(value) + 1, 2).ToUpper() == class48_0.string_7.ToUpper())
				{
					cboClass.SelectedItem = item;
					break;
				}
			}
			foreach (object item2 in cboType.Items)
			{
				string text8 = item2.ToString();
				string value2 = "Select Train Type";
				if (!text8.Contains(value2))
				{
					string value3 = "-";
					if (text8.Substring(text8.IndexOf(value3) + 1, 1).Trim().ToUpper() == class48_0.string_16.ToUpper())
					{
						cboType.SelectedItem = item2;
						break;
					}
				}
			}
			cboPayment.SelectedIndex = int.Parse(class48_0.string_22.Trim());
			cboGateway.SelectedItem = class48_0.string_23;
			cboGateway_Alt.SelectedItem = class48_0.string_233;
			string string_ = class48_0.string_25;
			string[] array = new string[1];
			string text9 = "||";
			array[0] = text9;
			string[] array2 = string_.Split(array, StringSplitOptions.RemoveEmptyEntries);
			int.Parse(array2[0].Trim());
			int.Parse(array2[1].Trim());
			StrFareList = array2[2].Trim();
			if (class48_0.list_1.Count > 0)
			{
				txtChName1.Text = class48_0.list_1[0].string_0;
				cboAge1.SelectedIndex = int.Parse(class48_0.list_1[0].string_1) + 1;
				cboChSex1.SelectedItem = class48_0.list_1[0].string_2;
			}
			else
			{
				cboAge1.SelectedIndex = 0;
				cboChSex1.SelectedIndex = 0;
			}
			if (class48_0.list_1.Count <= 1)
			{
				cboAge2.SelectedIndex = 0;
				cboChSex2.SelectedIndex = 0;
			}
			else
			{
				txtChName2.Text = class48_0.list_1[1].string_0;
				cboAge2.SelectedIndex = int.Parse(class48_0.list_1[1].string_1) + 1;
				cboChSex2.SelectedItem = class48_0.list_1[1].string_2;
			}
			chkInsurance.Checked = class48_0.bool_7;
			if (class48_0.list_0.Count > 0)
			{
				txtName1.Text = class48_0.list_0[0].string_0;
				txtAge1.Text = class48_0.list_0[0].string_1;
				cboSex1.SelectedItem = class48_0.list_0[0].string_2;
				cboBerth1.SelectedItem = class48_0.list_0[0].string_3;
				chk1.Checked = !(class48_0.list_0[0].string_4 == "");
				if (!string.IsNullOrEmpty(class48_0.list_0[0].string_5))
				{
					cboFood1.SelectedItem = class48_0.list_0[0].string_5;
				}
				if (!string.IsNullOrEmpty(class48_0.list_0[0].string_7))
				{
					cboID1.SelectedItem = class48_0.list_0[0].string_6;
					txtID1.Text = class48_0.list_0[0].string_7;
				}
				string text10 = txtName1.Text;
				string value4 = "-";
				if (text10.Contains(value4))
				{
					TextBox textBox = txtName1;
					string text11 = txtName1.Text;
					string oldValue = "-";
					textBox.Text = text11.Replace(oldValue, "");
					chkCH1.Checked = true;
				}
			}
			if (class48_0.list_0.Count > 1)
			{
				txtName2.Text = class48_0.list_0[1].string_0;
				txtAge2.Text = class48_0.list_0[1].string_1;
				cboSex2.SelectedItem = class48_0.list_0[1].string_2;
				cboBerth2.SelectedItem = class48_0.list_0[1].string_3;
				chk2.Checked = !(class48_0.list_0[1].string_4 == "");
				if (!string.IsNullOrEmpty(class48_0.list_0[1].string_5))
				{
					cboFood2.SelectedItem = class48_0.list_0[1].string_5;
				}
				if (!string.IsNullOrEmpty(class48_0.list_0[1].string_7))
				{
					cboID2.SelectedItem = class48_0.list_0[1].string_6;
					txtID2.Text = class48_0.list_0[1].string_7;
				}
				string text12 = txtName2.Text;
				string value5 = "-";
				if (text12.Contains(value5))
				{
					TextBox textBox2 = txtName2;
					string text13 = txtName2.Text;
					string oldValue2 = "-";
					textBox2.Text = text13.Replace(oldValue2, "");
					chkCH2.Checked = true;
				}
			}
			if (class48_0.list_0.Count > 2)
			{
				txtName3.Text = class48_0.list_0[2].string_0;
				txtAge3.Text = class48_0.list_0[2].string_1;
				cboSex3.SelectedItem = class48_0.list_0[2].string_2;
				cboBerth3.SelectedItem = class48_0.list_0[2].string_3;
				chk3.Checked = !(class48_0.list_0[2].string_4 == "");
				if (!string.IsNullOrEmpty(class48_0.list_0[2].string_5))
				{
					cboFood3.SelectedItem = class48_0.list_0[2].string_5;
				}
				if (!string.IsNullOrEmpty(class48_0.list_0[2].string_7))
				{
					cboID3.SelectedItem = class48_0.list_0[2].string_6;
					txtID3.Text = class48_0.list_0[2].string_7;
				}
				string text14 = txtName3.Text;
				string value6 = "-";
				if (text14.Contains(value6))
				{
					TextBox textBox3 = txtName3;
					string text15 = txtName3.Text;
					string oldValue3 = "-";
					textBox3.Text = text15.Replace(oldValue3, "");
					chkCH3.Checked = true;
				}
			}
			if (class48_0.list_0.Count > 3)
			{
				txtName4.Text = class48_0.list_0[3].string_0;
				txtAge4.Text = class48_0.list_0[3].string_1;
				cboSex4.SelectedItem = class48_0.list_0[3].string_2;
				cboBerth4.SelectedItem = class48_0.list_0[3].string_3;
				chk4.Checked = !(class48_0.list_0[3].string_4 == "");
				if (!string.IsNullOrEmpty(class48_0.list_0[3].string_5))
				{
					cboFood4.SelectedItem = class48_0.list_0[3].string_5;
				}
				if (!string.IsNullOrEmpty(class48_0.list_0[3].string_7))
				{
					cboID4.SelectedItem = class48_0.list_0[3].string_6;
					txtID4.Text = class48_0.list_0[3].string_7;
				}
				string text16 = txtName4.Text;
				string value7 = "-";
				if (text16.Contains(value7))
				{
					TextBox textBox4 = txtName4;
					string text17 = txtName4.Text;
					string oldValue4 = "-";
					textBox4.Text = text17.Replace(oldValue4, "");
					chkCH4.Checked = true;
				}
			}
			if (class48_0.list_0.Count > 4)
			{
				txtName5.Text = class48_0.list_0[4].string_0;
				txtAge5.Text = class48_0.list_0[4].string_1;
				cboSex5.SelectedItem = class48_0.list_0[4].string_2;
				cboBerth5.SelectedItem = class48_0.list_0[4].string_3;
				chk5.Checked = !(class48_0.list_0[4].string_4 == "");
				if (!string.IsNullOrEmpty(class48_0.list_0[4].string_5))
				{
					cboFood5.SelectedItem = class48_0.list_0[4].string_5;
				}
				if (!string.IsNullOrEmpty(class48_0.list_0[4].string_7))
				{
					cboID5.SelectedItem = class48_0.list_0[4].string_6;
					txtID5.Text = class48_0.list_0[4].string_7;
				}
				string text18 = txtName5.Text;
				string value8 = "-";
				if (text18.Contains(value8))
				{
					TextBox textBox5 = txtName5;
					string text19 = txtName5.Text;
					string oldValue5 = "-";
					textBox5.Text = text19.Replace(oldValue5, "");
					chkCH5.Checked = true;
				}
			}
			if (class48_0.list_0.Count > 5)
			{
				txtName6.Text = class48_0.list_0[5].string_0;
				txtAge6.Text = class48_0.list_0[5].string_1;
				cboSex6.SelectedItem = class48_0.list_0[5].string_2;
				cboBerth6.SelectedItem = class48_0.list_0[5].string_3;
				chk6.Checked = !(class48_0.list_0[5].string_4 == "");
				if (!string.IsNullOrEmpty(class48_0.list_0[5].string_5))
				{
					cboFood6.SelectedItem = class48_0.list_0[5].string_5;
				}
				if (!string.IsNullOrEmpty(class48_0.list_0[5].string_7))
				{
					cboID6.SelectedItem = class48_0.list_0[5].string_6;
					CFAA0.Text = class48_0.list_0[5].string_7;
				}
				string text20 = txtName6.Text;
				string value9 = "-";
				if (text20.Contains(value9))
				{
					TextBox textBox6 = txtName6;
					string text21 = txtName6.Text;
					string oldValue6 = "-";
					textBox6.Text = text21.Replace(oldValue6, "");
					chkCH6.Checked = true;
				}
			}
			chkAutoUpgrade.Checked = class48_0.bool_2;
			txtMobNo.Text = class48_0.mobile_num;
			string_7 = class48_0.state_;
			TrPassingDay = class48_0.string_17;
			txtBrd.Text = class48_0.string_3;
			txtFrom.Text = class48_0.string_0;
			txtTo.Text = class48_0.string_1;
			txtTrainNo.Text = class48_0.string_2;
			chkConfirmOnly.Checked = class48_0.bool_3;
			txtTicketName.Text = class48_0.string_12;
			if (!string.IsNullOrEmpty(class48_0.string_10) && class48_0.string_10.Length > 0)
			{
				checkBox_0.Checked = true;
				textBox_0.Text = class48_0.string_10;
			}
			if (class48_0.bool_1)
			{
				chkBedroll.Enabled = true;
				chkBedroll.Checked = true;
			}
			TrainList = class48_0.string_38;
			if (!string.IsNullOrEmpty(class48_0.string_26))
			{
				RTrainList = class48_0.string_39;
				rTrPassingDay = class48_0.string_37;
			}
			cboIrctcId.SelectedItem = class48_0.string_13;
			ComboBox comboBox = cboSlotId;
			string selectedItem = "Ticket No 1";
			comboBox.SelectedItem = selectedItem;
			cboSlotId.SelectedItem = class48_0.string_15;
			cboGateway.SelectedItem = class48_0.string_23;
			cboGateway_Alt.SelectedItem = class48_0.string_233;
			cboType.SelectedItem = class48_0.string_36;
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void txtName1_Leave(object sender, EventArgs e)
	{
		TextBox textBox = (TextBox)sender;
		textBox.BackColor = Color.White;
		if (textBox == null)
		{
			return;
		}
		textBox.Text = textBox.Text.Trim();
		string text = cboClass.SelectedItem.ToString();
		string value = "(";
		string text2 = text.Substring(text.IndexOf(value) + 1, 2);
		string name = textBox.Name;
		string oldValue = "txtName";
		string text3 = name.Replace(oldValue, "");
		Control.ControlCollection controls = CGAA0.Controls;
		string text4 = "cboBerth";
		ComboBox comboBox = (ComboBox)controls[text4 + text3];
		Control.ControlCollection controls2 = CGAA0.Controls;
		string text5 = "cboFood";
		ComboBox comboBox2 = (ComboBox)controls2[text5 + text3];
		if (string.IsNullOrEmpty(textBox.Text) || textBox.Text.Length <= 0)
		{
			return;
		}
		if (comboBox2 != null && comboBox2.Enabled && comboBox2.SelectedIndex <= 0)
		{
			comboBox2.SelectedIndex = 1;
		}
		string empty = string.Empty;
		if (comboBox == null || comboBox.SelectedIndex > 0 || (empty = text2.ToUpper()) == null)
		{
			return;
		}
		if (Program.dictionary_41 == null)
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>(9);
			string key = "3E";
			dictionary.Add(key, 0);
			string key2 = "3A";
			dictionary.Add(key2, 1);
			string key3 = "SL";
			dictionary.Add(key3, 2);
			string key4 = "2A";
			dictionary.Add(key4, 3);
			string key5 = "FC";
			dictionary.Add(key5, 4);
			string key6 = "1A";
			dictionary.Add(key6, 5);
			string key7 = "EC";
			dictionary.Add(key7, 6);
			string key8 = "2S";
			dictionary.Add(key8, 7);
			string key9 = "CC";
			dictionary.Add(key9, 8);
			Program.dictionary_41 = dictionary;
		}
		if (Program.dictionary_41.TryGetValue(empty, out var value2))
		{
			int num = value2;
			if (num <= 6)
			{
				comboBox.SelectedIndex = 1;
			}
			else if (num - 7 <= 1)
			{
				comboBox.SelectedIndex = 2;
			}
		}
	}

	private void CHAA0_Leave(object sender, EventArgs e)
	{
		((Control)sender).BackColor = Color.White;
		string text = txtFrom.Text.Trim();
		string text2 = txtFrom.Text.Trim();
		string text3 = text;
		string value = "-";
		if (text3.Contains(value))
		{
			try
			{
				text = text.Substring(0, text.IndexOf('-')).Trim();
				text2 = text2.Split('-')[0].ToString().Trim();
			}
			catch
			{
			}
		}
		txtFrom.Text = text.Trim();
		if (!bool_0)
		{
			txtBrd.Text = text2;
			if (cboPayment.Items.Count > 2)
			{
				cboPayment.SelectedIndex = 1;
			}
			if (cboGateway.Items.Count > 2)
			{
				cboGateway.SelectedIndex = 1;
				cboGateway_Alt.SelectedIndex = 0;
			}
		}
	}

	private void B0AAA(object sender, EventArgs e)
	{
		RadioButton radioButton = (RadioButton)sender;
		string quota = "Tatkal";
		Quota = quota;
		panel5.Visible = false;
		if (!radioButton.Checked)
		{
			chk1.Enabled = true;
			chk2.Enabled = true;
			chk3.Enabled = true;
			chk4.Enabled = true;
			chk5.Enabled = true;
			chk6.Enabled = true;
			method_8(bool_2: true);
		}
		else
		{
			if (!rdTatkal.Checked)
			{
				if (rdPtTatkal.Checked)
				{
					comboBox1.Enabled = true;
					string qt = "PT";
					Qt = qt;
					panel5.Visible = true;
				}
			}
			else
			{
				comboBox1.Enabled = false;
				string qt2 = "TQ";
				Qt = qt2;
			}
			chk1.Enabled = false;
			chk2.Enabled = false;
			chk3.Enabled = false;
			chk4.Enabled = false;
			chk5.Enabled = false;
			chk6.Enabled = false;
			method_8(bool_2: false);
		}
		method_9(int_0, Qt, string_5);
	}

	private void C0AA0(object sender, LinkLabelLinkClickedEventArgs e)
	{
		string text = txtFrom.Text.Trim();
		if (!string.IsNullOrEmpty(text))
		{
			string text2 = text;
			string value = "-";
			if (text2.Contains(value))
			{
				string text3 = text;
				string text4 = text;
				string value2 = "-";
				text = text3.Substring(text4.IndexOf(value2) + 1).Trim();
			}
			if (Class34.smethod_6(text))
			{
				string text5 = text;
				string text6 = txtTo.Text.Trim();
				if (string.IsNullOrEmpty(text6))
				{
					string text7 = "Invalid value in 'To' Station.";
					string caption = "Invalid Station";
					MessageBox.Show(text7, caption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					txtTo.Focus();
					return;
				}
				string text8 = text6;
				string value3 = "-";
				if (text8.Contains(value3))
				{
					string text9 = text6;
					string text10 = text6;
					string value4 = "-";
					text6 = text9.Substring(text10.IndexOf(value4) + 1).Trim();
				}
				if (Class34.smethod_6(text6))
				{
					string text11 = text6;
					string text12 = txtTrainNo.Text.Trim();
					if (!string.IsNullOrEmpty(text12))
					{
						if (Class34.smethod_2(text12))
						{
							string text13 = text12;
							if (cboClass.SelectedIndex > 0)
							{
								string text14 = cboClass.SelectedItem.ToString();
								string value5 = "(";
								string text15 = text14.Substring(text14.IndexOf(value5) + 1);
								string oldValue = ")";
								string text16 = text15.Replace(oldValue, "").Trim();
								Cursor = Cursors.WaitCursor;
								WaitCallback callBack = method_13;
								string[] array = new string[7] { text5, null, null, null, null, null, null };
								string text17 = "|";
								array[1] = text17;
								array[2] = text11;
								string text18 = "|";
								array[3] = text18;
								array[4] = text13;
								string text19 = "|";
								array[5] = text19;
								array[6] = text16;
								ThreadPool.QueueUserWorkItem(callBack, string.Concat(array));
							}
							else
							{
								string text20 = "Select Valid class!";
								string caption2 = "Class";
								MessageBox.Show(text20, caption2, MessageBoxButtons.OK, MessageBoxIcon.Hand);
								cboClass.Focus();
							}
						}
						else
						{
							string text21 = "Invalid value for Train Number. Only AlphaNumerics are allowed!";
							string caption3 = "Invalid TrainNo";
							MessageBox.Show(text21, caption3, MessageBoxButtons.OK, MessageBoxIcon.Hand);
							txtTrainNo.Focus();
						}
					}
					else
					{
						string text22 = "Invalid value for Train Number.";
						string caption4 = "Invalid TrainNo";
						MessageBox.Show(text22, caption4, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						txtTrainNo.Focus();
					}
				}
				else
				{
					string text23 = "Invalid value in 'To' Station. Only Alphabets are allowed!";
					string caption5 = "Invalid Station";
					MessageBox.Show(text23, caption5, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					txtTo.Focus();
				}
			}
			else
			{
				string text24 = "Invalid value in 'From' Station. Only Alphabets are allowed!";
				string caption6 = "Invalid Station";
				MessageBox.Show(text24, caption6, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				txtFrom.Focus();
			}
		}
		else
		{
			string text25 = "Invalid value in 'From' Station.";
			string caption7 = "Invalid Station";
			MessageBox.Show(text25, caption7, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			txtFrom.Focus();
		}
	}

	private void method_13(object object_0)
	{
		string text = object_0.ToString();
		string[] array = new string[1];
		string text2 = "|";
		array[0] = text2;
		string[] array2 = text.Split(array, StringSplitOptions.RemoveEmptyEntries);
		Cursor = Cursors.Default;
		if (string.IsNullOrEmpty(Program.mcommInstance_.GetF(array2[0], array2[1], array2[2], array2[3])))
		{
			string text3 = "Error Occured while Getting Fare, Please check From, To, Train No. & Class Code";
			string caption = "Fare Error";
			MessageBox.Show(text3, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	private void picBrd_Click(object sender, EventArgs e)
	{
		cboBdlist.Visible = true;
		string text = txtFrom.Text.Trim();
		if (string.IsNullOrEmpty(text))
		{
			string text2 = "Invalid value in 'From' Station.";
			string caption = "Invalid Station";
			MessageBox.Show(text2, caption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			txtFrom.Focus();
			return;
		}
		string text3 = text;
		string value = "(";
		if (text3.Contains(value))
		{
			string text4 = text;
			string text5 = text;
			string value2 = "(";
			string text6 = text4.Substring(text5.IndexOf(value2) + 1);
			string value3 = ")";
			text = text6.Substring(text6.IndexOf(value3));
		}
		if (!Class34.smethod_6(text.Replace('(', 'A').Replace(')', 'A')))
		{
			string text7 = "Invalid value in 'From' Station. Only Alphabets are allowed!";
			string caption2 = "Invalid Station";
			MessageBox.Show(text7, caption2, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			txtFrom.Focus();
			return;
		}
		string text8 = txtTo.Text.Trim();
		if (!string.IsNullOrEmpty(text8))
		{
			string text9 = text8;
			string value4 = "(";
			if (text9.Contains(value4))
			{
				string text10 = text8;
				string text11 = text8;
				string value5 = "(";
				string text12 = text10.Substring(text11.IndexOf(value5) + 1);
				string value6 = ")";
				text8 = text12.Substring(text12.IndexOf(value6));
			}
			if (Class34.smethod_6(text8.Replace('(', 'A').Replace(')', 'A')))
			{
				string text13 = txtBrd.Text.Trim();
				if (!string.IsNullOrEmpty(text13))
				{
					string text14 = text13;
					string value7 = "(";
					if (text14.Contains(value7))
					{
						string text15 = text13;
						string text16 = text13;
						string value8 = "(";
						string text17 = text15.Substring(text16.IndexOf(value8) + 1);
						string value9 = ")";
						text13 = text17.Substring(text17.IndexOf(value9));
					}
					if (Class34.smethod_6(text13))
					{
						string text18 = txtTrainNo.Text.Trim();
						if (string.IsNullOrEmpty(text18))
						{
							string text19 = "Invalid value for Train Number.";
							string caption3 = "Invalid TrainNo";
							MessageBox.Show(text19, caption3, MessageBoxButtons.OK, MessageBoxIcon.Hand);
							txtTrainNo.Focus();
							return;
						}
						if (!Class34.smethod_2(text18))
						{
							string text20 = "Invalid value for Train Number. Only AlphaNumerics are allowed!";
							string caption4 = "Invalid TrainNo";
							MessageBox.Show(text20, caption4, MessageBoxButtons.OK, MessageBoxIcon.Hand);
							txtTrainNo.Focus();
							return;
						}
						if (dtDate.Value < DateTime.Parse(DateTime.Now.ToShortDateString()))
						{
							string text21 = " Please Check The Journey Date... \n The Date Of Journey Should not be older than today.";
							string caption5 = "Date of Journey";
							MessageBox.Show(text21, caption5, MessageBoxButtons.OK, MessageBoxIcon.Hand);
							dtDate.Focus();
							return;
						}
						long ticks = DateTime.Now.AddDays(92.0).Ticks;
						long ticks2 = dtDate.Value.Ticks;
						if (Math.Floor(new TimeSpan(ticks - ticks2).TotalDays) > 92.0)
						{
							string text22 = " Please Check The Journey Date.. \n Reservation is permitted for 90 days in advance with \nrespect to train starting station(journey date not to be counted)";
							string caption6 = "Date of Journey";
							MessageBox.Show(text22, caption6, MessageBoxButtons.OK, MessageBoxIcon.Hand);
							dtDate.Focus();
						}
					}
					else
					{
						string text23 = "Invalid value in 'Boarding' Station. Only Alphabets are allowed!";
						string caption7 = "Invalid Station";
						MessageBox.Show(text23, caption7, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						txtBrd.Focus();
					}
				}
				else
				{
					string text24 = "Invalid value in 'Boarding' Station.";
					string caption8 = "Invalid Station";
					MessageBox.Show(text24, caption8, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					txtBrd.Focus();
				}
			}
			else
			{
				string text25 = "Invalid value in 'To' Station. Only Alphabets are allowed!";
				string caption9 = "Invalid Station";
				MessageBox.Show(text25, caption9, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				txtTo.Focus();
			}
		}
		else
		{
			string text26 = "Invalid value in 'To' Station.";
			string caption10 = "Invalid Station";
			MessageBox.Show(text26, caption10, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			txtTo.Focus();
		}
	}

	private void checkBox_0_CheckedChanged(object sender, EventArgs e)
	{
		if (checkBox_0.Checked)
		{
			textBox_0.Enabled = true;
		}
		else
		{
			textBox_0.Enabled = false;
		}
	}

	private void txtTrainNo_Leave(object sender, EventArgs e)
	{
		((Control)sender).BackColor = Color.White;
		if (string.IsNullOrEmpty(txtTrainNo.Text))
		{
			return;
		}
		try
		{
			string text = txtFrom.Text.Trim();
			if (!string.IsNullOrEmpty(text))
			{
				string text2 = text;
				string value = "-";
				if (text2.Contains(value))
				{
					string text3 = text;
					string text4 = text;
					string value2 = "-";
					text = text3.Substring(text4.IndexOf(value2) + 1).Trim();
				}
				string text5 = txtTo.Text.Trim();
				if (!string.IsNullOrEmpty(text5))
				{
					string text6 = text5;
					string value3 = "-";
					if (text6.Contains(value3))
					{
						string text7 = text5;
						string text8 = text5;
						string value4 = "-";
						text5 = text7.Substring(text8.IndexOf(value4) + 1).Trim();
					}
					SQLiteConnection sQLiteConnection = new SQLiteConnection(Class34.string_Database);
					SQLiteCommand sQLiteCommand = new SQLiteCommand();
					sQLiteConnection.Open();
					sQLiteCommand.Connection = sQLiteConnection;
					string[] array = new string[5];
					string text9 = " select SNO from [TBL_TRAINSTN] where STNCD = '";
					array[0] = text9;
					array[1] = text;
					string text10 = "' and TRAINNO = '";
					array[2] = text10;
					array[3] = txtTrainNo.Text.Trim();
					string text11 = "' LIMIT 1";
					array[4] = text11;
					sQLiteCommand.CommandText = string.Concat(array);
					object obj = sQLiteCommand.ExecuteScalar();
					int result = 0;
					int result2 = 0;
					if (obj != null && obj.GetType() != typeof(DBNull))
					{
						int.TryParse(obj.ToString().Trim(), out result);
					}
					string[] array2 = new string[5];
					string text12 = "select SNO from [TBL_TRAINSTN] where STNCD = '";
					array2[0] = text12;
					array2[1] = text5;
					string text13 = "' and TRAINNO = '";
					array2[2] = text13;
					array2[3] = txtTrainNo.Text.Trim();
					string text14 = "' LIMIT 1";
					array2[4] = text14;
					sQLiteCommand.CommandText = string.Concat(array2);
					object obj2 = sQLiteCommand.ExecuteScalar();
					if (obj2 != null && typeof(object) != typeof(DBNull))
					{
						int.TryParse(obj2.ToString().Trim(), out result2);
					}
					string text15 = "select Traintype from [tbl_Train] where TrainNo = '";
					string text16 = txtTrainNo.Text.Trim();
					string text17 = "'";
					sQLiteCommand.CommandText = text15 + text16 + text17;
					object obj3 = sQLiteCommand.ExecuteScalar();
					string empty = string.Empty;
					if (obj3 == null || !(typeof(object) != typeof(DBNull)) || (empty = obj3.ToString().ToUpper()) == null)
					{
						return;
					}
					string text18 = empty;
					string text19 = "D";
					if (!(text18 == text19))
					{
						string text20 = "J";
						int num;
						if (text18 == text20)
						{
							num = 0;
						}
						else
						{
							string text21 = "E";
							if (text18 == text21)
							{
								num = 0;
							}
							else
							{
								string text22 = "R";
								if (text18 == text22)
								{
									cboType.SelectedIndex = 1;
									return;
								}
								num = 1;
							}
						}
						if (num != 0)
						{
							string text23 = empty;
							string text24 = "S";
							if (text23 == text24)
							{
								cboType.SelectedIndex = 4;
								return;
							}
							string text25 = empty;
							string text26 = "G";
							if (text25 == text26)
							{
								cboType.SelectedIndex = 5;
							}
						}
						else
						{
							cboType.SelectedIndex = 3;
						}
					}
					else
					{
						cboType.SelectedIndex = 2;
					}
				}
				else
				{
					ToolTip bDAAA = BDAAA;
					string text27 = "Invalid value in 'To' Station.";
					bDAAA.Show(text27, this, 500);
					txtTo.Focus();
				}
			}
			else
			{
				ToolTip bDAAA2 = BDAAA;
				string text28 = "Invalid value in 'From' Station.";
				bDAAA2.Show(text28, this, 500);
				txtFrom.Focus();
			}
		}
		catch
		{
		}
	}

	public void Worker1(object object_0)
	{
		try
		{
			if (!BoolChkTrn)
			{
				BoolChkTrn = true;
				string[] array = Class47.method_3A(txtFrom.Text, txtTo.Text, txtTrainNo.Text, dtDate.Value, "", "").Split('~');
				TrPassingDay = array[0];
				string text = array[1];
				string[] array2 = new string[1];
				string text2 = ",";
				array2[0] = text2;
				List<string> list = new List<string>(text.Split(array2, StringSplitOptions.RemoveEmptyEntries));
				int count = list.Count;
				cboBdlist.Items.Clear();
				for (int i = 0; i < count; i++)
				{
					cboBdlist.Items.Add(list[i]);
				}
				BoolChkTrn = false;
			}
		}
		catch
		{
		}
	}

	private void btnFindTrain_Click(object sender, EventArgs e)
	{
		string text = txtFrom.Text.Trim();
		if (string.IsNullOrEmpty(text))
		{
			string text2 = "Invalid value in 'From' Station.";
			MessageBox.Show(text2);
			txtFrom.Focus();
		}
		else
		{
			string text3 = txtTo.Text.Trim();
			if (!string.IsNullOrEmpty(text3))
			{
				string text4 = text;
				string value = "-";
				if (text4.Contains(value))
				{
					string text5 = text;
					string text6 = text;
					string value2 = "-";
					text = text5.Substring(text6.IndexOf(value2) + 1).Trim();
				}
				string text7 = text3;
				string value3 = "-";
				if (text7.Contains(value3))
				{
					string text8 = text3;
					string text9 = text3;
					string value4 = "-";
					text3 = text8.Substring(text9.IndexOf(value4) + 1).Trim();
				}
				frmSerch_Train frmSerch_Train2 = new frmSerch_Train();
				frmSerch_Train2.string_0 = text;
				frmSerch_Train2.string_1 = text3;
				frmSerch_Train2.dateTime_0 = dtDate.Value;
				if (frmSerch_Train2.ShowDialog() == DialogResult.OK)
				{
					txtFrom.Text = frmSerch_Train2.string_0;
					txtTo.Text = frmSerch_Train2.string_1;
					txtBrd.Text = txtFrom.Text;
					string text10;
					if ((text10 = frmSerch_Train2.string_3.ToUpper()) != null)
					{
						B5AAA = text10;
						string text11 = text10;
						string text12 = "GN";
						if (!(text11 == text12))
						{
							string text13 = "LD";
							if (text11 == text13)
							{
								string qt = "LD";
								Qt = qt;
								rdLadies.Checked = true;
							}
							else
							{
								string text14 = "PT";
								if (text11 == text14)
								{
									string qt2 = "PT";
									Qt = qt2;
									rdPtTatkal.Checked = true;
								}
								else
								{
									string text15 = "TQ";
									if (text11 == text15)
									{
										string qt3 = "TQ";
										Qt = qt3;
										rdTatkal.Checked = true;
									}
								}
							}
						}
						else
						{
							string qt4 = "GN";
							Qt = qt4;
							rdGeneral.Checked = true;
						}
					}
					txtTrainNo.Text = frmSerch_Train2.string_4;
					int_0 = 0;
					while (!(txtTrainNo.Text == Class33.Jrny_Traindata[int_0, 0]))
					{
						int_0++;
						if (string.IsNullOrEmpty(Class33.Jrny_Traindata[int_0, 0]))
						{
							break;
						}
					}
					FareList = Class33.Jrny_Traindata[int_0, 10];
					TrainList = "";
					int_0 = 0;
					do
					{
						string text16 = "";
						for (int i = 0; i < 12; i++)
						{
							string text17 = text16;
							string text18 = Class33.Jrny_Traindata[int_0, i];
							string text19 = "~";
							text16 = text17 + text18 + text19;
						}
						string trainList = TrainList;
						string text20 = text16;
						string text21 = "^";
						TrainList = trainList + text20 + text21;
						int_0++;
					}
					while (!string.IsNullOrEmpty(Class33.Jrny_Traindata[int_0, 0]));
					Thread thread = new Thread(Worker1);
					thread.SetApartmentState(ApartmentState.STA);
					thread.Start(1);
					foreach (object item in cboClass.Items)
					{
						string text22 = item.ToString();
						string value5 = "(";
						if (text22.Substring(text22.IndexOf(value5) + 1, 2).ToUpper() == frmSerch_Train2.string_2.ToUpper())
						{
							cboClass.SelectedItem = item;
							break;
						}
					}
					frmSerch_Train2.string_5 = frmSerch_Train2.string_5.ToUpper();
					string text23 = frmSerch_Train2.string_5;
					string value6 = "RAJDHANI";
					bool flag = text23.Contains(value6);
					string text24 = frmSerch_Train2.string_5;
					string value7 = "RAJDHNI";
					if (!(flag | text24.Contains(value7)))
					{
						string text25 = frmSerch_Train2.string_5;
						string value8 = "GARIB";
						if (text25.Contains(value8))
						{
							cboType.SelectedIndex = 5;
						}
						else
						{
							string text26 = frmSerch_Train2.string_5;
							string value9 = "TEJAS";
							if (text26.Contains(value9))
							{
								cboType.SelectedIndex = 6;
							}
							else
							{
								string text27 = frmSerch_Train2.string_5;
								string value10 = "VANDE BHARAT";
								if (text27.Contains(value10))
								{
									cboType.SelectedIndex = 7;
								}
								else
								{
									string text28 = frmSerch_Train2.string_5;
									string value11 = "DURANTO";
									bool flag2 = text28.Contains(value11);
									string text29 = frmSerch_Train2.string_5;
									string value12 = "DURONTO";
									if (flag2 | text29.Contains(value12))
									{
										cboType.SelectedIndex = 2;
									}
									else
									{
										string text30 = frmSerch_Train2.string_5;
										string value13 = "SHATA";
										if (text30.Contains(value13))
										{
											cboType.SelectedIndex = 4;
										}
										else
										{
											cboType.SelectedIndex = 3;
										}
									}
								}
							}
						}
					}
					else
					{
						cboType.SelectedIndex = 1;
					}
					string text31 = frmSerch_Train2.string_6;
					string text32 = "1";
					if (text31 == text32)
					{
						Class34.smethod_15(frmSerch_Train2.string_4);
						txtTrainNo.BackColor = Color.Gold;
					}
					else
					{
						txtTrainNo.BackColor = Color.White;
					}
				}
			}
			else
			{
				string text33 = "Invalid value in 'To' Station.";
				MessageBox.Show(text33);
				txtTo.Focus();
			}
		}
		if (Class33.Jrny_Traindata == null)
		{
			string text34 = "No Response Recive from server Yet Please Go With Manually, Retry";
			string caption = "Safar";
			MessageBox.Show(text34, caption);
		}
	}

	private void cboPayment_SelectedIndexChanged(object sender, EventArgs e)
	{
		cboGateway.Items.Clear();
		cboGateway_Alt.Items.Clear();
		ComboBox.ObjectCollection items = cboGateway.Items;
		string item = "Select Your Bank";
		items.Add(item);
		ComboBox.ObjectCollection items2 = cboGateway_Alt.Items;
		string item2 = "No Alternate Bank";
		items2.Add(item2);
		switch (cboPayment.SelectedIndex)
		{
		case 1:
			foreach (string key in dictionary_2.Keys)
			{
				cboGateway.Items.Add(key);
			}
			break;
		case 2:
			foreach (string key2 in dictionary_3.Keys)
			{
				cboGateway.Items.Add(key2);
			}
			break;
		case 3:
			foreach (string key3 in dictionary_4.Keys)
			{
				cboGateway.Items.Add(key3);
			}
			break;
		}
		cboGateway.SelectedIndex = 0;
		foreach (string key4 in dictionary_5.Keys)
		{
			cboGateway_Alt.Items.Add(key4);
		}
	}

	private void lblAvailability_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		string text = txtFrom.Text.Trim();
		if (string.IsNullOrEmpty(text))
		{
			string text2 = "Invalid value in 'From' Station.";
			string caption = "Invalid Station";
			MessageBox.Show(text2, caption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			txtFrom.Focus();
			return;
		}
		string text3 = text;
		string value = "-";
		if (text3.Contains(value))
		{
			string text4 = text;
			string text5 = text;
			string value2 = "-";
			text = text4.Substring(text5.IndexOf(value2) + 1).Trim();
		}
		if (Class34.smethod_6(text))
		{
			string text6 = txtTo.Text.Trim();
			if (!string.IsNullOrEmpty(text6))
			{
				string text7 = text6;
				string value3 = "-";
				if (text7.Contains(value3))
				{
					string text8 = text6;
					string text9 = text6;
					string value4 = "-";
					text6 = text8.Substring(text9.IndexOf(value4) + 1).Trim();
				}
				if (Class34.smethod_6(text6))
				{
					string text10 = txtBrd.Text.Trim();
					if (!string.IsNullOrEmpty(text10))
					{
						string text11 = text10;
						string value5 = "-";
						if (text11.Contains(value5))
						{
							string text12 = text10;
							string text13 = text10;
							string value6 = "-";
							text10 = text12.Substring(text13.IndexOf(value6) + 1).Trim();
						}
						if (Class34.smethod_6(text10))
						{
							string text14 = txtTrainNo.Text.Trim();
							if (string.IsNullOrEmpty(text14))
							{
								string text15 = "Invalid value for Train Number.";
								string caption2 = "Invalid TrainNo";
								MessageBox.Show(text15, caption2, MessageBoxButtons.OK, MessageBoxIcon.Hand);
								txtTrainNo.Focus();
							}
							else if (Class34.smethod_2(text14))
							{
								if (dtDate.Value < DateTime.Parse(DateTime.Now.ToShortDateString()))
								{
									string text16 = " Please Check The Journey Date... \n The Date Of Journey Should not be older than today.";
									string caption3 = "Date of Journey";
									MessageBox.Show(text16, caption3, MessageBoxButtons.OK, MessageBoxIcon.Hand);
									dtDate.Focus();
									return;
								}
								if (cboClass.SelectedIndex <= 0)
								{
									string text17 = "Select Valid class!";
									string caption4 = "Class";
									MessageBox.Show(text17, caption4, MessageBoxButtons.OK, MessageBoxIcon.Hand);
									cboClass.Focus();
									return;
								}
								if (rdTatkal.Checked)
								{
									string text18 = btnOk.Text;
									string value7 = "Save";
									if (!text18.Contains(value7))
									{
										int year = dtDate.Value.Year;
										int month = dtDate.Value.Month;
										int day = dtDate.Value.Day;
										long ticks = new DateTime(year, month, day).Ticks;
										int year2 = DateTime.Now.Year;
										int month2 = DateTime.Now.Month;
										int day2 = DateTime.Now.Day;
										long ticks2 = new DateTime(year2, month2, day2).Ticks;
										long ticks3 = ticks - ticks2;
										TimeSpan timeSpan = new TimeSpan(ticks3);
										if (timeSpan.TotalDays >= 1.0 && (timeSpan.TotalDays >= 3.0 || DateTime.Now.Hour < 7 || (DateTime.Now.Hour == 7 && DateTime.Now.Minute < 1)))
										{
											string text19 = " Please Check The Journey Date... \n The Date Of Journey Should Be Within Two Days From Today eg., on 1st you can book for journey upto 3rd. ";
											string caption5 = "Date of Journey";
											MessageBox.Show(text19, caption5, MessageBoxButtons.OK, MessageBoxIcon.Hand);
											dtDate.Focus();
											return;
										}
									}
								}
								long ticks4 = DateTime.Now.AddDays(122.0).Ticks;
								long ticks5 = dtDate.Value.Ticks;
								if (Math.Floor(new TimeSpan(ticks4 - ticks5).TotalDays) <= 122.0)
								{
									Thread thread = new Thread(RefreshSeats);
									thread.SetApartmentState(ApartmentState.STA);
									thread.IsBackground = true;
									thread.Start("");
								}
								else
								{
									string text20 = " Please Check The Journey Date.. \n Reservation is permitted for 120 days in advance with \nrespect to train starting station(journey date not to be counted)";
									string caption6 = "Date of Journey";
									MessageBox.Show(text20, caption6, MessageBoxButtons.OK, MessageBoxIcon.Hand);
									dtDate.Focus();
								}
							}
							else
							{
								string text21 = "Invalid value for Train Number. Only AlphaNumerics are allowed!";
								string caption7 = "Invalid TrainNo";
								MessageBox.Show(text21, caption7, MessageBoxButtons.OK, MessageBoxIcon.Hand);
								txtTrainNo.Focus();
							}
						}
						else
						{
							string text22 = "Invalid value in 'Boarding' Station. Only Alphabets are allowed!";
							string caption8 = "Invalid Station";
							MessageBox.Show(text22, caption8, MessageBoxButtons.OK, MessageBoxIcon.Hand);
							txtBrd.Focus();
						}
					}
					else
					{
						string text23 = "Invalid value in 'Boarding' Station.";
						string caption9 = "Invalid Station";
						MessageBox.Show(text23, caption9, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						txtBrd.Focus();
					}
				}
				else
				{
					string text24 = "Invalid value in 'To' Station. Only Alphabets are allowed!";
					string caption10 = "Invalid Station";
					MessageBox.Show(text24, caption10, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					txtTo.Focus();
				}
			}
			else
			{
				string text25 = "Invalid value in 'To' Station.";
				string caption11 = "Invalid Station";
				MessageBox.Show(text25, caption11, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				txtTo.Focus();
			}
		}
		else
		{
			string text26 = "Invalid value in 'From' Station. Only Alphabets are allowed!";
			string caption12 = "Invalid Station";
			MessageBox.Show(text26, caption12, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			txtFrom.Focus();
		}
	}

	public void RefreshSeats(object object_0)
	{
		string text2;
		if (rdTatkal.Checked)
		{
			string text = "TQ";
			text2 = text;
		}
		else if (!rdPtTatkal.Checked)
		{
			if (rdLadies.Checked)
			{
				string text3 = "LD";
				text2 = text3;
			}
			else
			{
				string text4 = "GN";
				text2 = text4;
			}
		}
		else
		{
			string text5 = "PT";
			text2 = text5;
		}
		string text6 = text2;
		string text7 = cboClass.SelectedItem.ToString();
		string value = "(";
		string text8 = text7.Substring(text7.IndexOf(value) + 1, 2);
		string text9 = txtFrom.Text;
		string text10 = txtTo.Text;
		string text11 = text9;
		string value2 = "-";
		if (text11.Contains(value2))
		{
			string text12 = text9;
			string text13 = text9;
			string value3 = "-";
			text9 = text12.Substring(text13.IndexOf(value3) + 1).Trim();
		}
		string text14 = text10;
		string value4 = "-";
		if (text14.Contains(value4))
		{
			string text15 = text10;
			string text16 = text10;
			string value5 = "-";
			text10 = text15.Substring(text16.IndexOf(value5) + 1).Trim();
		}
		LinkLabel linkLabel = lblAvailability;
		string text17 = "Getting..";
		linkLabel.Text = text17;
		string[] array = new string[15]
		{
			text9, null, null, null, null, null, null, null, null, null,
			null, null, null, null, null
		};
		string text18 = "|";
		array[1] = text18;
		array[2] = text10;
		string text19 = "|";
		array[3] = text19;
		array[4] = txtTrainNo.Text;
		string text20 = "|";
		array[5] = text20;
		array[6] = text8;
		string text21 = "|";
		array[7] = text21;
		array[8] = text6;
		string text22 = "|";
		array[9] = text22;
		array[10] = dtDate.Value.Day.ToString();
		string text23 = "|";
		array[11] = text23;
		array[12] = dtDate.Value.Month.ToString();
		string text24 = "|";
		array[13] = text24;
		array[14] = dtDate.Value.Year.ToString();
		string[] array2 = string.Concat(array).ToString().Split('|');
		string from = array2[0];
		string to = array2[1];
		string trainNum = array2[2];
		string @class = array2[3];
		string quota = array2[4];
		string[] array3 = new string[5]
		{
			array2[5],
			null,
			null,
			null,
			null
		};
		string text25 = "/";
		array3[1] = text25;
		array3[2] = array2[6];
		string text26 = "/";
		array3[3] = text26;
		array3[4] = array2[7];
		string s = string.Concat(array3);
		string format = "d/M/yyyy";
		DateTime value6 = DateTime.ParseExact(s, format, CultureInfo.InvariantCulture);
		B1AAA(Class47.method_2A(from, to, trainNum, value6, @class, quota).Split('~')[0]);
	}

	private void B1AAA(object object_0)
	{
		if (base.InvokeRequired)
		{
			Invoke(new ParameterizedThreadStart(B1AAA), object_0);
		}
		else
		{
			lblAvailability.Text = object_0.ToString();
		}
	}

	private void C1AA0(object sender, EventArgs e)
	{
		if (dtDate.Value.Year <= 2016 && dtDate.Value.Month <= 4 && (dtDate.Value.Year != 2016 || dtDate.Value.Month != 4 || dtDate.Value.Day < 21))
		{
			chkCH1.Checked = false;
			chkCH2.Checked = false;
			chkCH3.Checked = false;
			chkCH4.Checked = false;
			chkCH5.Checked = false;
			chkCH6.Checked = false;
			chkCH1.Enabled = false;
			chkCH2.Enabled = false;
			chkCH3.Enabled = false;
			chkCH4.Enabled = false;
			chkCH5.Enabled = false;
			chkCH6.Enabled = false;
		}
		else
		{
			chkCH1.Enabled = true;
			chkCH2.Enabled = true;
			chkCH3.Enabled = true;
			chkCH4.Enabled = true;
			chkCH5.Enabled = true;
			chkCH6.Enabled = true;
		}
	}

	private void chkCH1_CheckedChanged(object sender, EventArgs e)
	{
		CheckBox checkBox = (CheckBox)sender;
		if (checkBox == null)
		{
			return;
		}
		int result = 0;
		if (!(checkBox.Tag is TextBox textBox))
		{
			return;
		}
		if (int.TryParse(textBox.Text, out result))
		{
			if (result >= 5 && result <= 11)
			{
				string text = "You have Opted for Child Seat and Full fare of child will be charged.";
				string caption = "Child Fare.";
				MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				string text2 = "Child fare will be applicable only for child between 5 to 11 years only.";
				string caption2 = "Child Fare.";
				MessageBox.Show(text2, caption2, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				checkBox.Checked = false;
				textBox.Focus();
			}
		}
		else
		{
			string text3 = "Kindly enter valid age!";
			MessageBox.Show(text3);
			checkBox.Checked = false;
			textBox.Focus();
		}
	}

	private void txtName1_TextChanged(object sender, EventArgs e)
	{
		TextBox textBox = txtTicketName;
		string text = txtName1.Text;
		string oldValue = " ";
		string newValue = "_";
		textBox.Text = text.Replace(oldValue, newValue);
		TextBox textBox2 = txtTicketName;
		string text2 = txtFrom.Text;
		string oldValue2 = " ";
		string newValue2 = "_";
		string text3 = text2.Replace(oldValue2, newValue2);
		string text4 = "_";
		string text5 = txtTo.Text;
		string oldValue3 = " ";
		string newValue3 = "_";
		textBox2.Text = text3 + text4 + text5.Replace(oldValue3, newValue3);
		if (sender is TextBox { SelectionStart: var selectionStart } textBox3)
		{
			string input = textBox3.Text;
			string pattern = "[^a-zA-Z0-9 ]+";
			string replacement = " ";
			string text6 = Regex.Replace(input, pattern, replacement);
			string input2 = text6;
			string pattern2 = "\\s+";
			string replacement2 = " ";
			text6 = Regex.Replace(input2, pattern2, replacement2).TrimStart();
			if (textBox3.Text != text6)
			{
				textBox3.Text = text6;
				textBox3.SelectionStart = selectionStart;
			}
		}
	}

	private void PS_Name_TextChanged(object sender, EventArgs e)
	{
		if (sender is TextBox { SelectionStart: var selectionStart } textBox)
		{
			string input = textBox.Text;
			string pattern = "[^a-zA-Z0-9 ]+";
			string replacement = " ";
			string text = Regex.Replace(input, pattern, replacement);
			string input2 = text;
			string pattern2 = "\\s+";
			string replacement2 = " ";
			text = Regex.Replace(input2, pattern2, replacement2).TrimStart();
			if (textBox.Text != text)
			{
				textBox.Text = text;
				textBox.SelectionStart = selectionStart;
			}
		}
	}

	private void btnArrow_Click(object sender, EventArgs e)
	{
		string text = txtFrom.Text;
		txtFrom.Text = txtTo.Text;
		txtTo.Text = text;
	}

	private void txtTrainNo_TextChanged(object sender, EventArgs e)
	{
		if (Class34.list_0.Contains(txtTrainNo.Text.Trim()))
		{
			txtTrainNo.BackColor = Color.Gold;
		}
		else
		{
			txtTrainNo.BackColor = Color.White;
		}
	}

	private void cboID1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (sender is ComboBox comboBox)
		{
			TextBox textBox = comboBox.Tag as TextBox;
			if (comboBox.SelectedIndex > 0)
			{
				textBox.Enabled = true;
				return;
			}
			textBox.Text = "";
			textBox.Enabled = false;
		}
	}

	private void BHAAA_Leave(object sender, EventArgs e)
	{
		((Control)sender).BackColor = Color.White;
		string text = txtTo.Text.Trim();
		string text2 = text;
		string value = "-";
		if (text2.Contains(value))
		{
			try
			{
				text = text.Substring(0, text.IndexOf('-')).Trim();
			}
			catch
			{
			}
		}
		txtTo.Text = text.Trim();
	}

	private void cboSex1_Leave(object sender, EventArgs e)
	{
		if (txtName1.Text == "")
		{
			return;
		}
		int num;
		try
		{
			num = int.Parse(txtAge1.Text);
		}
		catch
		{
			txtAge1.Text = "";
			return;
		}
		chk1.Enabled = false;
		chk1.Checked = false;
		string text = cboSex1.Text;
		string text2 = "M";
		if (!(text == text2) || num < 60)
		{
			string text3 = cboSex1.Text;
			string text4 = "F";
			if (!(text3 == text4) || num < 58)
			{
				goto IL_00ff;
			}
		}
		string quota = Quota;
		string text5 = "Tatkal";
		if (quota != text5)
		{
			chk1.Enabled = true;
			chk1.Checked = true;
		}
		goto IL_00ff;
		IL_00ff:
		chkCH1.Enabled = false;
		chkCH1.Checked = false;
		if (num > 4 && num < 12)
		{
			chkCH1.Enabled = true;
			chkCH1.Checked = true;
		}
	}

	private void cboSex2_Leave(object sender, EventArgs e)
	{
		if (txtName2.Text == "")
		{
			return;
		}
		int num;
		try
		{
			num = int.Parse(txtAge2.Text);
		}
		catch
		{
			txtAge2.Text = "";
			return;
		}
		chk2.Enabled = false;
		chk2.Checked = false;
		string text = cboSex2.Text;
		string text2 = "M";
		if (!(text == text2) || num < 60)
		{
			string text3 = cboSex2.Text;
			string text4 = "F";
			if (!(text3 == text4) || num < 58)
			{
				goto IL_00ff;
			}
		}
		string quota = Quota;
		string text5 = "Tatkal";
		if (quota != text5)
		{
			chk2.Enabled = true;
			chk2.Checked = true;
		}
		goto IL_00ff;
		IL_00ff:
		chkCH2.Enabled = false;
		chkCH2.Checked = false;
		if (num > 4 && num < 12)
		{
			chkCH2.Enabled = true;
			chkCH2.Checked = true;
		}
	}

	private void B2AAA(object sender, EventArgs e)
	{
		if (txtName3.Text == "")
		{
			return;
		}
		int num;
		try
		{
			num = int.Parse(txtAge3.Text);
		}
		catch
		{
			txtAge3.Text = "";
			return;
		}
		chk3.Enabled = false;
		chk3.Checked = false;
		string text = cboSex3.Text;
		string text2 = "M";
		if (!(text == text2) || num < 60)
		{
			string text3 = cboSex3.Text;
			string text4 = "F";
			if (!(text3 == text4) || num < 58)
			{
				goto IL_00ff;
			}
		}
		string quota = Quota;
		string text5 = "Tatkal";
		if (quota != text5)
		{
			chk3.Enabled = true;
			chk3.Checked = true;
		}
		goto IL_00ff;
		IL_00ff:
		chkCH3.Enabled = false;
		chkCH3.Checked = false;
		if (num > 4 && num < 12)
		{
			chkCH3.Enabled = true;
			chkCH3.Checked = true;
		}
	}

	private void C2AA0(object sender, EventArgs e)
	{
		if (txtName4.Text == "")
		{
			return;
		}
		int num;
		try
		{
			num = int.Parse(txtAge4.Text);
		}
		catch
		{
			txtAge4.Text = "";
			return;
		}
		chk4.Enabled = false;
		chk4.Checked = false;
		string text = cboSex4.Text;
		string text2 = "M";
		if (!(text == text2) || num < 60)
		{
			string text3 = cboSex4.Text;
			string text4 = "F";
			if (!(text3 == text4) || num < 58)
			{
				goto IL_00ff;
			}
		}
		string quota = Quota;
		string text5 = "Tatkal";
		if (quota != text5)
		{
			chk4.Enabled = true;
			chk4.Checked = true;
		}
		goto IL_00ff;
		IL_00ff:
		chkCH4.Enabled = false;
		chkCH4.Checked = false;
		if (num > 4 && num < 12)
		{
			chkCH4.Enabled = true;
			chkCH4.Checked = true;
		}
	}

	private void cboSex5_Leave(object sender, EventArgs e)
	{
		if (txtName5.Text == "")
		{
			return;
		}
		int num;
		try
		{
			num = int.Parse(txtAge5.Text);
		}
		catch
		{
			txtAge5.Text = "";
			return;
		}
		chk5.Enabled = false;
		chk5.Checked = false;
		string text = cboSex5.Text;
		string text2 = "M";
		if (!(text == text2) || num < 60)
		{
			string text3 = cboSex5.Text;
			string text4 = "F";
			if (!(text3 == text4) || num < 58)
			{
				goto IL_00ff;
			}
		}
		string quota = Quota;
		string text5 = "Tatkal";
		if (quota != text5)
		{
			chk5.Enabled = true;
			chk5.Checked = true;
		}
		goto IL_00ff;
		IL_00ff:
		chkCH5.Enabled = false;
		chkCH5.Checked = false;
		if (num > 4 && num < 12)
		{
			chkCH5.Enabled = true;
			chkCH5.Checked = true;
		}
	}

	private void CBAA0_Leave(object sender, EventArgs e)
	{
		if (txtName6.Text == "")
		{
			return;
		}
		int num;
		try
		{
			num = int.Parse(txtAge6.Text);
		}
		catch
		{
			txtAge6.Text = "";
			return;
		}
		chk6.Enabled = false;
		chk6.Checked = false;
		string text = cboSex6.Text;
		string text2 = "M";
		if (!(text == text2) || num < 60)
		{
			string text3 = cboSex6.Text;
			string text4 = "F";
			if (!(text3 == text4) || num < 58)
			{
				goto IL_00ff;
			}
		}
		string quota = Quota;
		string text5 = "Tatkal";
		if (quota != text5)
		{
			chk6.Enabled = true;
			chk6.Checked = true;
		}
		goto IL_00ff;
		IL_00ff:
		chkCH6.Enabled = false;
		chkCH6.Checked = false;
		if (num > 4 && num < 12)
		{
			chkCH6.Enabled = true;
			chkCH6.Checked = true;
		}
	}

	private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string text2;
		if (rdTatkal.Checked)
		{
			string text = "TQ";
			text2 = text;
		}
		else if (!rdPtTatkal.Checked)
		{
			if (rdLadies.Checked)
			{
				string text3 = "LD";
				text2 = text3;
			}
			else
			{
				string text4 = "GN";
				text2 = text4;
			}
		}
		else
		{
			string text5 = "PT";
			text2 = text5;
		}
		string text6 = "PT";
		if (!(text2 != text6))
		{
			faresetup();
		}
		else
		{
			comboBox1.SelectedIndex = 0;
		}
	}

	private void rdLadies_CheckedChanged(object sender, EventArgs e)
	{
		comboBox1.Enabled = false;
		if (rdGeneral.Checked)
		{
			string qt = "GN";
			Qt = qt;
		}
		else if (rdLadies.Checked)
		{
			string qt2 = "LD";
			Qt = qt2;
		}
		panel5.Visible = false;
		method_9(int_0, Qt, string_5);
	}

	private void cboBdlist_Leave(object sender, EventArgs e)
	{
		((Control)sender).BackColor = Color.White;
		cboBdlist.Visible = false;
		string value = cboBdlist.Text;
		if (!string.IsNullOrEmpty(value))
		{
			txtBrd.Text = value;
		}
	}

	private void txtMobNo_Leave(object sender, EventArgs e)
	{
		((Control)sender).BackColor = Color.White;
	}

	private void B3AAA(object sender, EventArgs e)
	{
		if (txtMobNo.Text.Length == 10)
		{
			string keys = "{TAB}";
			SendKeys.Send(keys);
		}
	}

	private void C3AA0(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	private void txtName1_Enter(object sender, EventArgs e)
	{
		((Control)sender).BackColor = Color.Silver;
	}

	private void txtID1_Leave(object sender, EventArgs e)
	{
		((Control)sender).BackColor = Color.White;
	}

	private void dtDate_Enter(object sender, EventArgs e)
	{
		dtDate.BackColor = Color.Cyan;
	}

	private void dtDate_Leave(object sender, EventArgs e)
	{
		dtDate.BackColor = Color.White;
	}

	private void TextOnly_KeyPress(object sender, KeyPressEventArgs e)
	{
		e.Handled = !char.IsLetter(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != ' ' && e.KeyChar != '\u0016';
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(APP_FRAMEWORK.frmAddTkt));
		this.chkBedroll = new System.Windows.Forms.CheckBox();
		this.chkInsurance = new System.Windows.Forms.CheckBox();
		this.checkBox1 = new System.Windows.Forms.CheckBox();
		this.checkBox_0 = new System.Windows.Forms.CheckBox();
		this.textBox_0 = new System.Windows.Forms.TextBox();
		this.chkConfirmOnly = new System.Windows.Forms.CheckBox();
		this.chkAutoUpgrade = new System.Windows.Forms.CheckBox();
		this.grpPay = new System.Windows.Forms.GroupBox();
		this.cboSlotId = new System.Windows.Forms.ComboBox();
		this.C20A0 = new System.Windows.Forms.Label();
		this.chkConfirmation = new System.Windows.Forms.CheckBox();
		this.cboGateway_Alt = new System.Windows.Forms.ComboBox();
		this.label32 = new System.Windows.Forms.Label();
		this.txtTicketName = new System.Windows.Forms.TextBox();
		this.btnOk = new System.Windows.Forms.Button();
		this.label35 = new System.Windows.Forms.Label();
		this.cboGateway = new System.Windows.Forms.ComboBox();
		this.label34 = new System.Windows.Forms.Label();
		this.cboIrctcId = new System.Windows.Forms.ComboBox();
		this.cboPayment = new System.Windows.Forms.ComboBox();
		this.label30 = new System.Windows.Forms.Label();
		this.BDAAA = new System.Windows.Forms.ToolTip(this.components);
		this.dtDate = new System.Windows.Forms.DateTimePicker();
		this.cboType = new System.Windows.Forms.ComboBox();
		this.txtBrd = new System.Windows.Forms.TextBox();
		this.cboClass = new System.Windows.Forms.ComboBox();
		this.lblAvailability = new System.Windows.Forms.LinkLabel();
		this.txtTrainNo = new System.Windows.Forms.TextBox();
		this.cboBdlist = new System.Windows.Forms.ComboBox();
		this.btnFindTrain = new System.Windows.Forms.Button();
		this.chkCH6 = new System.Windows.Forms.CheckBox();
		this.chkCH5 = new System.Windows.Forms.CheckBox();
		this.chkCH4 = new System.Windows.Forms.CheckBox();
		this.chkCH3 = new System.Windows.Forms.CheckBox();
		this.chkCH2 = new System.Windows.Forms.CheckBox();
		this.chkCH1 = new System.Windows.Forms.CheckBox();
		this.chk6 = new System.Windows.Forms.CheckBox();
		this.chk5 = new System.Windows.Forms.CheckBox();
		this.chk4 = new System.Windows.Forms.CheckBox();
		this.chk3 = new System.Windows.Forms.CheckBox();
		this.chk2 = new System.Windows.Forms.CheckBox();
		this.chk1 = new System.Windows.Forms.CheckBox();
		this.Panel1 = new System.Windows.Forms.Panel();
		this.C6AA0 = new System.Windows.Forms.Label();
		this.label39 = new System.Windows.Forms.Label();
		this.picBrd = new System.Windows.Forms.PictureBox();
		this.panel11 = new System.Windows.Forms.Panel();
		this.label6 = new System.Windows.Forms.Label();
		this.rdGeneral = new System.Windows.Forms.RadioButton();
		this.rdLadies = new System.Windows.Forms.RadioButton();
		this.rdTatkal = new System.Windows.Forms.RadioButton();
		this.rdPtTatkal = new System.Windows.Forms.RadioButton();
		this.label5 = new System.Windows.Forms.Label();
		this.txtFrom = new System.Windows.Forms.TextBox();
		this.txtTo = new System.Windows.Forms.TextBox();
		this.label9 = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.btnArrow = new System.Windows.Forms.Button();
		this.label10 = new System.Windows.Forms.Label();
		this.B6AAA = new System.Windows.Forms.Label();
		this.panel4 = new System.Windows.Forms.Panel();
		this.button2 = new System.Windows.Forms.Button();
		this.CDAA0 = new System.Windows.Forms.LinkLabel();
		this.panel5 = new System.Windows.Forms.Panel();
		this.label37 = new System.Windows.Forms.Label();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.comboBox1 = new System.Windows.Forms.ComboBox();
		this.txtMobNo = new System.Windows.Forms.TextBox();
		this.label27 = new System.Windows.Forms.Label();
		this.CA0A0 = new System.Windows.Forms.Label();
		this.BA0AA = new System.Windows.Forms.Label();
		this.label28 = new System.Windows.Forms.Label();
		this.setf = new System.Windows.Forms.Label();
		this.bunifuElipse_0 = new Bunifu.Framework.UI.BunifuElipse(this.components);
		this.CGAA0 = new System.Windows.Forms.GroupBox();
		this.label36 = new System.Windows.Forms.Label();
		this.C7AA0 = new System.Windows.Forms.Label();
		this.label33 = new System.Windows.Forms.Label();
		this.CFAA0 = new System.Windows.Forms.TextBox();
		this.txtID5 = new System.Windows.Forms.TextBox();
		this.txtID4 = new System.Windows.Forms.TextBox();
		this.txtID3 = new System.Windows.Forms.TextBox();
		this.txtID2 = new System.Windows.Forms.TextBox();
		this.BFAAA = new System.Windows.Forms.Panel();
		this.label16 = new System.Windows.Forms.Label();
		this.label29 = new System.Windows.Forms.Label();
		this.CCAA0 = new System.Windows.Forms.Label();
		this.BCAAA = new System.Windows.Forms.Label();
		this.label24 = new System.Windows.Forms.Label();
		this.label23 = new System.Windows.Forms.Label();
		this.label22 = new System.Windows.Forms.Label();
		this.panel3 = new System.Windows.Forms.Panel();
		this.txtChName1 = new System.Windows.Forms.TextBox();
		this.cboChSex1 = new System.Windows.Forms.ComboBox();
		this.txtChName2 = new System.Windows.Forms.TextBox();
		this.cboChSex2 = new System.Windows.Forms.ComboBox();
		this.cboAge1 = new System.Windows.Forms.ComboBox();
		this.cboAge2 = new System.Windows.Forms.ComboBox();
		this.cboID6 = new System.Windows.Forms.ComboBox();
		this.cboID5 = new System.Windows.Forms.ComboBox();
		this.cboID4 = new System.Windows.Forms.ComboBox();
		this.cboID3 = new System.Windows.Forms.ComboBox();
		this.cboID2 = new System.Windows.Forms.ComboBox();
		this.label41 = new System.Windows.Forms.Label();
		this.txtID1 = new System.Windows.Forms.TextBox();
		this.label3 = new System.Windows.Forms.Label();
		this.cboID1 = new System.Windows.Forms.ComboBox();
		this.label40 = new System.Windows.Forms.Label();
		this.cboFood6 = new System.Windows.Forms.ComboBox();
		this.cboFood5 = new System.Windows.Forms.ComboBox();
		this.cboFood4 = new System.Windows.Forms.ComboBox();
		this.cboFood3 = new System.Windows.Forms.ComboBox();
		this.cboFood2 = new System.Windows.Forms.ComboBox();
		this.chkBd6 = new System.Windows.Forms.CheckBox();
		this.cboFood1 = new System.Windows.Forms.ComboBox();
		this.cboBerth6 = new System.Windows.Forms.ComboBox();
		this.cboSex6 = new System.Windows.Forms.ComboBox();
		this.txtAge6 = new System.Windows.Forms.TextBox();
		this.chkBd5 = new System.Windows.Forms.CheckBox();
		this.txtName6 = new System.Windows.Forms.TextBox();
		this.cboBerth5 = new System.Windows.Forms.ComboBox();
		this.cboSex5 = new System.Windows.Forms.ComboBox();
		this.txtAge5 = new System.Windows.Forms.TextBox();
		this.chkBd4 = new System.Windows.Forms.CheckBox();
		this.txtName5 = new System.Windows.Forms.TextBox();
		this.cboBerth4 = new System.Windows.Forms.ComboBox();
		this.cboSex4 = new System.Windows.Forms.ComboBox();
		this.txtAge4 = new System.Windows.Forms.TextBox();
		this.chkBd3 = new System.Windows.Forms.CheckBox();
		this.txtName4 = new System.Windows.Forms.TextBox();
		this.cboBerth3 = new System.Windows.Forms.ComboBox();
		this.cboSex3 = new System.Windows.Forms.ComboBox();
		this.txtAge3 = new System.Windows.Forms.TextBox();
		this.chkBd2 = new System.Windows.Forms.CheckBox();
		this.txtName3 = new System.Windows.Forms.TextBox();
		this.cboBerth2 = new System.Windows.Forms.ComboBox();
		this.cboSex2 = new System.Windows.Forms.ComboBox();
		this.txtAge2 = new System.Windows.Forms.TextBox();
		this.chkBd1 = new System.Windows.Forms.CheckBox();
		this.txtName2 = new System.Windows.Forms.TextBox();
		this.cboBerth1 = new System.Windows.Forms.ComboBox();
		this.cboSex1 = new System.Windows.Forms.ComboBox();
		this.txtAge1 = new System.Windows.Forms.TextBox();
		this.txtName1 = new System.Windows.Forms.TextBox();
		this.panel2 = new System.Windows.Forms.Panel();
		this.label21 = new System.Windows.Forms.Label();
		this.label20 = new System.Windows.Forms.Label();
		this.label19 = new System.Windows.Forms.Label();
		this.label18 = new System.Windows.Forms.Label();
		this.label17 = new System.Windows.Forms.Label();
		this.label8 = new System.Windows.Forms.Label();
		this.label15 = new System.Windows.Forms.Label();
		this.label14 = new System.Windows.Forms.Label();
		this.label13 = new System.Windows.Forms.Label();
		this.B7AAA = new System.Windows.Forms.Label();
		this.label7 = new System.Windows.Forms.Label();
		this.pnlHeader = new System.Windows.Forms.Panel();
		this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
		this.label50 = new System.Windows.Forms.Label();
		this.grpPay.SuspendLayout();
		this.Panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.picBrd).BeginInit();
		this.panel11.SuspendLayout();
		this.panel4.SuspendLayout();
		this.panel5.SuspendLayout();
		this.CGAA0.SuspendLayout();
		this.BFAAA.SuspendLayout();
		this.pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.btnClose).BeginInit();
		base.SuspendLayout();
		this.chkBedroll.AutoSize = true;
		this.chkBedroll.Enabled = false;
		this.chkBedroll.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.chkBedroll.ForeColor = System.Drawing.Color.Black;
		this.chkBedroll.Location = new System.Drawing.Point(7, 83);
		this.chkBedroll.Name = "chkBedroll";
		this.chkBedroll.Size = new System.Drawing.Size(220, 18);
		this.chkBedroll.TabIndex = 100;
		this.chkBedroll.Text = "Require Bed Roll in GaribRath/Durantoo?";
		this.chkBedroll.UseVisualStyleBackColor = false;
		this.chkBedroll.Visible = false;
		this.chkInsurance.AutoSize = true;
		this.chkInsurance.Checked = true;
		this.chkInsurance.CheckState = System.Windows.Forms.CheckState.Checked;
		this.chkInsurance.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.chkInsurance.Location = new System.Drawing.Point(157, 503);
		this.chkInsurance.Name = "chkInsurance";
		this.chkInsurance.Size = new System.Drawing.Size(159, 18);
		this.chkInsurance.TabIndex = 97;
		this.chkInsurance.Text = "Avail Insurance /Passenger";
		this.chkInsurance.UseVisualStyleBackColor = false;
		this.checkBox1.AutoSize = true;
		this.checkBox1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.checkBox1.Location = new System.Drawing.Point(228, 194);
		this.checkBox1.Name = "checkBox1";
		this.checkBox1.Size = new System.Drawing.Size(191, 18);
		this.checkBox1.TabIndex = 99;
		this.checkBox1.Text = "Book only if Lower berths allotted.";
		this.checkBox1.UseVisualStyleBackColor = false;
		this.checkBox1.Visible = false;
		this.checkBox_0.AutoSize = true;
		this.checkBox_0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.checkBox_0.Location = new System.Drawing.Point(68, 249);
		this.checkBox_0.Name = "checkBox_0";
		this.checkBox_0.Size = new System.Drawing.Size(121, 18);
		this.checkBox_0.TabIndex = 94;
		this.checkBox_0.Text = "Preferred Coach ID ";
		this.checkBox_0.UseVisualStyleBackColor = false;
		this.checkBox_0.CheckedChanged += new System.EventHandler(checkBox_0_CheckedChanged);
		this.textBox_0.BackColor = System.Drawing.Color.White;
		this.textBox_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox_0.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.textBox_0.Enabled = false;
		this.textBox_0.ForeColor = System.Drawing.Color.Black;
		this.textBox_0.Location = new System.Drawing.Point(132, 194);
		this.textBox_0.MaxLength = 4;
		this.textBox_0.Name = "textBox_0";
		this.textBox_0.Size = new System.Drawing.Size(56, 20);
		this.textBox_0.TabIndex = 95;
		this.chkConfirmOnly.AutoSize = true;
		this.chkConfirmOnly.Checked = true;
		this.chkConfirmOnly.CheckState = System.Windows.Forms.CheckState.Checked;
		this.chkConfirmOnly.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.chkConfirmOnly.ForeColor = System.Drawing.Color.Black;
		this.chkConfirmOnly.Location = new System.Drawing.Point(7, 62);
		this.chkConfirmOnly.Name = "chkConfirmOnly";
		this.chkConfirmOnly.Size = new System.Drawing.Size(195, 18);
		this.chkConfirmOnly.TabIndex = 98;
		this.chkConfirmOnly.Text = "Book only if confirm berths allotted.";
		this.chkConfirmOnly.UseVisualStyleBackColor = false;
		this.chkAutoUpgrade.AutoSize = true;
		this.chkAutoUpgrade.Checked = true;
		this.chkAutoUpgrade.CheckState = System.Windows.Forms.CheckState.Checked;
		this.chkAutoUpgrade.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.chkAutoUpgrade.ForeColor = System.Drawing.Color.Black;
		this.chkAutoUpgrade.Location = new System.Drawing.Point(7, 44);
		this.chkAutoUpgrade.Name = "chkAutoUpgrade";
		this.chkAutoUpgrade.Size = new System.Drawing.Size(178, 18);
		this.chkAutoUpgrade.TabIndex = 96;
		this.chkAutoUpgrade.Text = "Consider for Auto Upgradation. ";
		this.chkAutoUpgrade.UseVisualStyleBackColor = false;
		this.grpPay.BackColor = System.Drawing.Color.Honeydew;
		this.grpPay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.grpPay.Controls.Add(this.cboSlotId);
		this.grpPay.Controls.Add(this.C20A0);
		this.grpPay.Controls.Add(this.chkConfirmation);
		this.grpPay.Controls.Add(this.cboGateway_Alt);
		this.grpPay.Controls.Add(this.label32);
		this.grpPay.Controls.Add(this.checkBox1);
		this.grpPay.Controls.Add(this.txtTicketName);
		this.grpPay.Controls.Add(this.chkBedroll);
		this.grpPay.Controls.Add(this.btnOk);
		this.grpPay.Controls.Add(this.checkBox_0);
		this.grpPay.Controls.Add(this.textBox_0);
		this.grpPay.Controls.Add(this.label35);
		this.grpPay.Controls.Add(this.chkConfirmOnly);
		this.grpPay.Controls.Add(this.cboGateway);
		this.grpPay.Controls.Add(this.chkAutoUpgrade);
		this.grpPay.Controls.Add(this.label34);
		this.grpPay.Controls.Add(this.cboIrctcId);
		this.grpPay.Controls.Add(this.cboPayment);
		this.grpPay.Controls.Add(this.label30);
		this.grpPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.grpPay.ForeColor = System.Drawing.Color.White;
		this.grpPay.Location = new System.Drawing.Point(2, 327);
		this.grpPay.Name = "grpPay";
		this.grpPay.Size = new System.Drawing.Size(638, 102);
		this.grpPay.TabIndex = 90;
		this.grpPay.TabStop = false;
		this.cboSlotId.BackColor = System.Drawing.Color.White;
		this.cboSlotId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboSlotId.Font = new System.Drawing.Font("Arial", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboSlotId.ForeColor = System.Drawing.Color.Black;
		this.cboSlotId.FormattingEnabled = true;
		this.cboSlotId.Location = new System.Drawing.Point(79, 10);
		this.cboSlotId.Name = "cboSlotId";
		this.cboSlotId.Size = new System.Drawing.Size(123, 19);
		this.cboSlotId.TabIndex = 110;
		this.C20A0.AutoSize = true;
		this.C20A0.Font = new System.Drawing.Font("Trebuchet MS", 9f, System.Drawing.FontStyle.Bold);
		this.C20A0.ForeColor = System.Drawing.Color.Black;
		this.C20A0.Location = new System.Drawing.Point(6, 11);
		this.C20A0.Name = "C20A0";
		this.C20A0.Size = new System.Drawing.Size(78, 18);
		this.C20A0.TabIndex = 109;
		this.C20A0.Text = "Ticket Slot: ";
		this.chkConfirmation.AutoSize = true;
		this.chkConfirmation.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.chkConfirmation.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.chkConfirmation.Location = new System.Drawing.Point(42, 186);
		this.chkConfirmation.Name = "chkConfirmation";
		this.chkConfirmation.Size = new System.Drawing.Size(76, 19);
		this.chkConfirmation.TabIndex = 108;
		this.chkConfirmation.Text = "Stop Pay";
		this.chkConfirmation.UseVisualStyleBackColor = false;
		this.cboGateway_Alt.BackColor = System.Drawing.Color.White;
		this.cboGateway_Alt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboGateway_Alt.Font = new System.Drawing.Font("Arial", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboGateway_Alt.ForeColor = System.Drawing.Color.Black;
		this.cboGateway_Alt.FormattingEnabled = true;
		this.cboGateway_Alt.Location = new System.Drawing.Point(495, 34);
		this.cboGateway_Alt.Name = "cboGateway_Alt";
		this.cboGateway_Alt.Size = new System.Drawing.Size(138, 19);
		this.cboGateway_Alt.TabIndex = 107;
		this.label32.AutoSize = true;
		this.label32.Font = new System.Drawing.Font("Trebuchet MS", 9f, System.Drawing.FontStyle.Bold);
		this.label32.ForeColor = System.Drawing.Color.Black;
		this.label32.Location = new System.Drawing.Point(406, 36);
		this.label32.Name = "label32";
		this.label32.Size = new System.Drawing.Size(88, 18);
		this.label32.TabIndex = 106;
		this.label32.Text = "BackUp Bank: ";
		this.txtTicketName.BackColor = System.Drawing.Color.White;
		this.txtTicketName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.txtTicketName.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtTicketName.ForeColor = System.Drawing.Color.Black;
		this.txtTicketName.Location = new System.Drawing.Point(353, 78);
		this.txtTicketName.MaxLength = 20;
		this.txtTicketName.Name = "txtTicketName";
		this.txtTicketName.Size = new System.Drawing.Size(123, 20);
		this.txtTicketName.TabIndex = 101;
		this.txtTicketName.Enter += new System.EventHandler(txtName1_Enter);
		this.txtTicketName.Leave += new System.EventHandler(txtID1_Leave);
		this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.btnOk.BackColor = System.Drawing.Color.DimGray;
		this.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.Red;
		this.btnOk.Font = new System.Drawing.Font("Arial", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnOk.ForeColor = System.Drawing.Color.White;
		this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOk.Location = new System.Drawing.Point(495, 54);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(139, 46);
		this.btnOk.TabIndex = 102;
		this.btnOk.Text = "Save";
		this.btnOk.UseVisualStyleBackColor = false;
		this.btnOk.Click += new System.EventHandler(btnOk_Click);
		this.label35.AutoSize = true;
		this.label35.Font = new System.Drawing.Font("Trebuchet MS", 9f, System.Drawing.FontStyle.Bold);
		this.label35.ForeColor = System.Drawing.Color.Black;
		this.label35.Location = new System.Drawing.Point(282, 80);
		this.label35.Name = "label35";
		this.label35.Size = new System.Drawing.Size(47, 18);
		this.label35.TabIndex = 7;
		this.label35.Text = "Name: ";
		this.cboGateway.BackColor = System.Drawing.Color.White;
		this.cboGateway.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboGateway.Font = new System.Drawing.Font("Arial", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboGateway.ForeColor = System.Drawing.Color.Black;
		this.cboGateway.FormattingEnabled = true;
		this.cboGateway.Location = new System.Drawing.Point(495, 10);
		this.cboGateway.Name = "cboGateway";
		this.cboGateway.Size = new System.Drawing.Size(139, 19);
		this.cboGateway.TabIndex = 93;
		this.label34.AutoSize = true;
		this.label34.Font = new System.Drawing.Font("Trebuchet MS", 9f, System.Drawing.FontStyle.Bold);
		this.label34.ForeColor = System.Drawing.Color.Black;
		this.label34.Location = new System.Drawing.Point(420, 11);
		this.label34.Name = "label34";
		this.label34.Size = new System.Drawing.Size(75, 18);
		this.label34.TabIndex = 14;
		this.label34.Text = "Prior Bank: ";
		this.cboIrctcId.BackColor = System.Drawing.Color.White;
		this.cboIrctcId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboIrctcId.Enabled = false;
		this.cboIrctcId.Font = new System.Drawing.Font("Arial", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboIrctcId.ForeColor = System.Drawing.Color.Black;
		this.cboIrctcId.FormattingEnabled = true;
		this.cboIrctcId.Location = new System.Drawing.Point(119, 151);
		this.cboIrctcId.Name = "cboIrctcId";
		this.cboIrctcId.Size = new System.Drawing.Size(103, 19);
		this.cboIrctcId.TabIndex = 91;
		this.cboIrctcId.Visible = false;
		this.cboPayment.BackColor = System.Drawing.Color.White;
		this.cboPayment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboPayment.Font = new System.Drawing.Font("Arial", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboPayment.ForeColor = System.Drawing.Color.Black;
		this.cboPayment.FormattingEnabled = true;
		this.cboPayment.Location = new System.Drawing.Point(280, 10);
		this.cboPayment.Name = "cboPayment";
		this.cboPayment.Size = new System.Drawing.Size(125, 19);
		this.cboPayment.TabIndex = 92;
		this.cboPayment.SelectedIndexChanged += new System.EventHandler(cboPayment_SelectedIndexChanged);
		this.label30.AutoSize = true;
		this.label30.Font = new System.Drawing.Font("Trebuchet MS", 9f, System.Drawing.FontStyle.Bold);
		this.label30.ForeColor = System.Drawing.Color.Black;
		this.label30.Location = new System.Drawing.Point(217, 11);
		this.label30.Name = "label30";
		this.label30.Size = new System.Drawing.Size(64, 18);
		this.label30.TabIndex = 12;
		this.label30.Text = "Getways: ";
		this.BDAAA.AutoPopDelay = 2000;
		this.BDAAA.InitialDelay = 500;
		this.BDAAA.IsBalloon = true;
		this.BDAAA.ReshowDelay = 100;
		this.BDAAA.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
		this.BDAAA.ToolTipTitle = "Add Ticket";
		this.dtDate.BackColor = System.Drawing.Color.White;
		this.dtDate.CustomFormat = "dd-MMM-yyyy";
		this.dtDate.Font = new System.Drawing.Font("Arial", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.dtDate.ForeColor = System.Drawing.Color.Black;
		this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
		this.dtDate.Location = new System.Drawing.Point(446, 4);
		this.dtDate.MaxDate = new System.DateTime(2026, 12, 31, 0, 0, 0, 0);
		this.dtDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
		this.dtDate.Name = "dtDate";
		this.dtDate.Size = new System.Drawing.Size(107, 19);
		this.dtDate.TabIndex = 3;
		this.dtDate.Value = new System.DateTime(2010, 7, 6, 0, 0, 0, 0);
		this.dtDate.ValueChanged += new System.EventHandler(C1AA0);
		this.dtDate.Enter += new System.EventHandler(dtDate_Enter);
		this.dtDate.Leave += new System.EventHandler(dtDate_Leave);
		this.cboType.BackColor = System.Drawing.Color.White;
		this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboType.Font = new System.Drawing.Font("Arial", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboType.ForeColor = System.Drawing.Color.Black;
		this.cboType.FormattingEnabled = true;
		this.cboType.Items.AddRange(new object[8] { "Select Train Type", "Rajdhani-R", "Duranto-D", "Mail/Express-E", "Shatabdi-S", "GaribRath/Yuva-G", "TEJAS Express-T", "VANDE BHARAT EX-V" });
		this.cboType.Location = new System.Drawing.Point(451, 30);
		this.cboType.Name = "cboType";
		this.cboType.Size = new System.Drawing.Size(102, 19);
		this.cboType.TabIndex = 13;
		this.cboType.SelectedIndexChanged += new System.EventHandler(cboType_SelectedIndexChanged);
		this.txtBrd.BackColor = System.Drawing.Color.White;
		this.txtBrd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.txtBrd.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtBrd.ForeColor = System.Drawing.Color.Black;
		this.txtBrd.Location = new System.Drawing.Point(49, 29);
		this.txtBrd.MaxLength = 5;
		this.txtBrd.Name = "txtBrd";
		this.txtBrd.Size = new System.Drawing.Size(115, 20);
		this.txtBrd.TabIndex = 6;
		this.cboClass.BackColor = System.Drawing.Color.White;
		this.cboClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboClass.Font = new System.Drawing.Font("Arial", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboClass.ForeColor = System.Drawing.Color.Black;
		this.cboClass.FormattingEnabled = true;
		this.cboClass.Items.AddRange(new object[12]
		{
			"Select Class", "First Class AC(1A)", "Executive Car(EC)", "First Class(FC)", "AC 2-tier(2A)", "AC 3-tier(3A)", "AC Chair Car(CC)", "Sleeper(SL)", "Second Sitting(2S)", "AC 3-tier eco(3E)",
			"Vistadome AC (EV)", "Anubhuti Class (EA)"
		});
		this.cboClass.Location = new System.Drawing.Point(49, 58);
		this.cboClass.Name = "cboClass";
		this.cboClass.Size = new System.Drawing.Size(140, 19);
		this.cboClass.TabIndex = 7;
		this.cboClass.SelectedIndexChanged += new System.EventHandler(cboClass_SelectedIndexChanged);
		this.lblAvailability.ActiveLinkColor = System.Drawing.Color.Blue;
		this.lblAvailability.AutoSize = true;
		this.lblAvailability.BackColor = System.Drawing.Color.Transparent;
		this.lblAvailability.DisabledLinkColor = System.Drawing.Color.Blue;
		this.lblAvailability.Font = new System.Drawing.Font("Trebuchet MS", 9f, System.Drawing.FontStyle.Bold);
		this.lblAvailability.ForeColor = System.Drawing.Color.Black;
		this.lblAvailability.LinkColor = System.Drawing.Color.DodgerBlue;
		this.lblAvailability.Location = new System.Drawing.Point(562, 33);
		this.lblAvailability.Name = "lblAvailability";
		this.lblAvailability.Size = new System.Drawing.Size(73, 18);
		this.lblAvailability.TabIndex = 8;
		this.lblAvailability.TabStop = true;
		this.lblAvailability.Text = "Availability";
		this.lblAvailability.VisitedLinkColor = System.Drawing.Color.Blue;
		this.lblAvailability.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(lblAvailability_LinkClicked);
		this.txtTrainNo.BackColor = System.Drawing.Color.White;
		this.txtTrainNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.txtTrainNo.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtTrainNo.ForeColor = System.Drawing.Color.Black;
		this.txtTrainNo.Location = new System.Drawing.Point(257, 28);
		this.txtTrainNo.MaxLength = 5;
		this.txtTrainNo.Name = "txtTrainNo";
		this.txtTrainNo.Size = new System.Drawing.Size(115, 20);
		this.txtTrainNo.TabIndex = 6;
		this.txtTrainNo.TextChanged += new System.EventHandler(txtTrainNo_TextChanged);
		this.txtTrainNo.Enter += new System.EventHandler(txtName1_Enter);
		this.txtTrainNo.Leave += new System.EventHandler(txtTrainNo_Leave);
		this.cboBdlist.BackColor = System.Drawing.Color.White;
		this.cboBdlist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboBdlist.Font = new System.Drawing.Font("Arial", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboBdlist.ForeColor = System.Drawing.Color.Black;
		this.cboBdlist.FormattingEnabled = true;
		this.cboBdlist.Location = new System.Drawing.Point(49, 29);
		this.cboBdlist.Name = "cboBdlist";
		this.cboBdlist.Size = new System.Drawing.Size(139, 19);
		this.cboBdlist.TabIndex = 5;
		this.cboBdlist.Visible = false;
		this.cboBdlist.Leave += new System.EventHandler(cboBdlist_Leave);
		this.btnFindTrain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
		this.btnFindTrain.Cursor = System.Windows.Forms.Cursors.Hand;
		this.btnFindTrain.FlatAppearance.BorderSize = 0;
		this.btnFindTrain.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.btnFindTrain.Font = new System.Drawing.Font("Sitka Text", 8.25f);
		this.btnFindTrain.ForeColor = System.Drawing.Color.Black;
		this.btnFindTrain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnFindTrain.Location = new System.Drawing.Point(559, 3);
		this.btnFindTrain.Name = "btnFindTrain";
		this.btnFindTrain.Size = new System.Drawing.Size(79, 25);
		this.btnFindTrain.TabIndex = 4;
		this.btnFindTrain.Text = "  Find";
		this.btnFindTrain.UseVisualStyleBackColor = false;
		this.btnFindTrain.Click += new System.EventHandler(btnFindTrain_Click);
		this.chkCH6.AutoSize = true;
		this.chkCH6.BackColor = System.Drawing.Color.White;
		this.chkCH6.Enabled = false;
		this.chkCH6.ForeColor = System.Drawing.Color.Black;
		this.chkCH6.Location = new System.Drawing.Point(542, 165);
		this.chkCH6.Name = "chkCH6";
		this.chkCH6.Size = new System.Drawing.Size(15, 14);
		this.chkCH6.TabIndex = 82;
		this.chkCH6.Tag = "";
		this.chkCH6.UseVisualStyleBackColor = false;
		this.chkCH5.AutoSize = true;
		this.chkCH5.BackColor = System.Drawing.Color.White;
		this.chkCH5.Enabled = false;
		this.chkCH5.ForeColor = System.Drawing.Color.Black;
		this.chkCH5.Location = new System.Drawing.Point(542, 139);
		this.chkCH5.Name = "chkCH5";
		this.chkCH5.Size = new System.Drawing.Size(15, 14);
		this.chkCH5.TabIndex = 72;
		this.chkCH5.Tag = "";
		this.chkCH5.UseVisualStyleBackColor = false;
		this.chkCH4.AutoSize = true;
		this.chkCH4.BackColor = System.Drawing.Color.White;
		this.chkCH4.Enabled = false;
		this.chkCH4.ForeColor = System.Drawing.Color.Black;
		this.chkCH4.Location = new System.Drawing.Point(542, 115);
		this.chkCH4.Name = "chkCH4";
		this.chkCH4.Size = new System.Drawing.Size(15, 14);
		this.chkCH4.TabIndex = 62;
		this.chkCH4.Tag = "";
		this.chkCH4.UseVisualStyleBackColor = false;
		this.chkCH3.AutoSize = true;
		this.chkCH3.BackColor = System.Drawing.Color.White;
		this.chkCH3.Enabled = false;
		this.chkCH3.ForeColor = System.Drawing.Color.Black;
		this.chkCH3.Location = new System.Drawing.Point(542, 90);
		this.chkCH3.Name = "chkCH3";
		this.chkCH3.Size = new System.Drawing.Size(15, 14);
		this.chkCH3.TabIndex = 52;
		this.chkCH3.Tag = "";
		this.chkCH3.UseVisualStyleBackColor = false;
		this.chkCH2.AutoSize = true;
		this.chkCH2.BackColor = System.Drawing.Color.White;
		this.chkCH2.Enabled = false;
		this.chkCH2.ForeColor = System.Drawing.Color.Black;
		this.chkCH2.Location = new System.Drawing.Point(542, 66);
		this.chkCH2.Name = "chkCH2";
		this.chkCH2.Size = new System.Drawing.Size(15, 14);
		this.chkCH2.TabIndex = 42;
		this.chkCH2.Tag = "";
		this.chkCH2.UseVisualStyleBackColor = false;
		this.chkCH1.AutoSize = true;
		this.chkCH1.BackColor = System.Drawing.Color.White;
		this.chkCH1.Enabled = false;
		this.chkCH1.ForeColor = System.Drawing.Color.Black;
		this.chkCH1.Location = new System.Drawing.Point(542, 42);
		this.chkCH1.Name = "chkCH1";
		this.chkCH1.Size = new System.Drawing.Size(15, 14);
		this.chkCH1.TabIndex = 32;
		this.chkCH1.Tag = "";
		this.chkCH1.UseVisualStyleBackColor = false;
		this.chkCH1.CheckedChanged += new System.EventHandler(chkCH1_CheckedChanged);
		this.chk6.AutoSize = true;
		this.chk6.BackColor = System.Drawing.Color.White;
		this.chk6.ForeColor = System.Drawing.Color.Black;
		this.chk6.Location = new System.Drawing.Point(574, 165);
		this.chk6.Name = "chk6";
		this.chk6.Size = new System.Drawing.Size(15, 14);
		this.chk6.TabIndex = 82;
		this.chk6.UseVisualStyleBackColor = false;
		this.chk6.CheckedChanged += new System.EventHandler(chk1_CheckedChanged);
		this.chk5.AutoSize = true;
		this.chk5.BackColor = System.Drawing.Color.White;
		this.chk5.ForeColor = System.Drawing.Color.Black;
		this.chk5.Location = new System.Drawing.Point(574, 139);
		this.chk5.Name = "chk5";
		this.chk5.Size = new System.Drawing.Size(15, 14);
		this.chk5.TabIndex = 73;
		this.chk5.UseVisualStyleBackColor = false;
		this.chk5.CheckedChanged += new System.EventHandler(chk1_CheckedChanged);
		this.chk4.AutoSize = true;
		this.chk4.BackColor = System.Drawing.Color.White;
		this.chk4.ForeColor = System.Drawing.Color.Black;
		this.chk4.Location = new System.Drawing.Point(574, 114);
		this.chk4.Name = "chk4";
		this.chk4.Size = new System.Drawing.Size(15, 14);
		this.chk4.TabIndex = 63;
		this.chk4.UseVisualStyleBackColor = false;
		this.chk4.CheckedChanged += new System.EventHandler(chk1_CheckedChanged);
		this.chk3.AutoSize = true;
		this.chk3.BackColor = System.Drawing.Color.White;
		this.chk3.ForeColor = System.Drawing.Color.Black;
		this.chk3.Location = new System.Drawing.Point(574, 90);
		this.chk3.Name = "chk3";
		this.chk3.Size = new System.Drawing.Size(15, 14);
		this.chk3.TabIndex = 53;
		this.chk3.UseVisualStyleBackColor = false;
		this.chk3.CheckedChanged += new System.EventHandler(chk1_CheckedChanged);
		this.chk2.AutoSize = true;
		this.chk2.BackColor = System.Drawing.Color.White;
		this.chk2.ForeColor = System.Drawing.Color.Black;
		this.chk2.Location = new System.Drawing.Point(574, 66);
		this.chk2.Name = "chk2";
		this.chk2.Size = new System.Drawing.Size(15, 14);
		this.chk2.TabIndex = 43;
		this.chk2.UseVisualStyleBackColor = false;
		this.chk2.CheckedChanged += new System.EventHandler(chk1_CheckedChanged);
		this.chk1.AutoSize = true;
		this.chk1.BackColor = System.Drawing.Color.White;
		this.chk1.ForeColor = System.Drawing.Color.Black;
		this.chk1.Location = new System.Drawing.Point(574, 42);
		this.chk1.Name = "chk1";
		this.chk1.Size = new System.Drawing.Size(15, 14);
		this.chk1.TabIndex = 33;
		this.chk1.Tag = "";
		this.chk1.UseVisualStyleBackColor = false;
		this.chk1.CheckedChanged += new System.EventHandler(chk1_CheckedChanged);
		this.Panel1.BackColor = System.Drawing.Color.AliceBlue;
		this.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.Panel1.Controls.Add(this.cboBdlist);
		this.Panel1.Controls.Add(this.C6AA0);
		this.Panel1.Controls.Add(this.label39);
		this.Panel1.Controls.Add(this.cboType);
		this.Panel1.Controls.Add(this.dtDate);
		this.Panel1.Controls.Add(this.picBrd);
		this.Panel1.Controls.Add(this.panel11);
		this.Panel1.Controls.Add(this.btnFindTrain);
		this.Panel1.Controls.Add(this.label5);
		this.Panel1.Controls.Add(this.txtBrd);
		this.Panel1.Controls.Add(this.txtFrom);
		this.Panel1.Controls.Add(this.txtTo);
		this.Panel1.Controls.Add(this.label9);
		this.Panel1.Controls.Add(this.label4);
		this.Panel1.Controls.Add(this.btnArrow);
		this.Panel1.Controls.Add(this.cboClass);
		this.Panel1.Controls.Add(this.lblAvailability);
		this.Panel1.Controls.Add(this.label10);
		this.Panel1.Controls.Add(this.B6AAA);
		this.Panel1.Controls.Add(this.txtTrainNo);
		this.Panel1.ForeColor = System.Drawing.Color.White;
		this.Panel1.Location = new System.Drawing.Point(2, 24);
		this.Panel1.Name = "Panel1";
		this.Panel1.Size = new System.Drawing.Size(638, 81);
		this.Panel1.TabIndex = 0;
		this.C6AA0.AutoSize = true;
		this.C6AA0.BackColor = System.Drawing.Color.Transparent;
		this.C6AA0.Font = new System.Drawing.Font("Trebuchet MS", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.C6AA0.ForeColor = System.Drawing.Color.Black;
		this.C6AA0.Location = new System.Drawing.Point(3, 5);
		this.C6AA0.Name = "C6AA0";
		this.C6AA0.Size = new System.Drawing.Size(45, 18);
		this.C6AA0.TabIndex = 150;
		this.C6AA0.Text = "From: ";
		this.label39.AutoSize = true;
		this.label39.BackColor = System.Drawing.Color.Transparent;
		this.label39.Font = new System.Drawing.Font("Trebuchet MS", 9f, System.Drawing.FontStyle.Bold);
		this.label39.ForeColor = System.Drawing.Color.Black;
		this.label39.Location = new System.Drawing.Point(376, 31);
		this.label39.Name = "label39";
		this.label39.Size = new System.Drawing.Size(75, 18);
		this.label39.TabIndex = 18;
		this.label39.Text = "Train Type: ";
		this.picBrd.BackColor = System.Drawing.Color.White;
		this.picBrd.Cursor = System.Windows.Forms.Cursors.Hand;
		this.picBrd.ForeColor = System.Drawing.Color.Black;
		this.picBrd.Location = new System.Drawing.Point(168, 29);
		this.picBrd.Name = "picBrd";
		this.picBrd.Size = new System.Drawing.Size(19, 19);
		this.picBrd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.picBrd.TabIndex = 20;
		this.picBrd.TabStop = false;
		this.picBrd.Click += new System.EventHandler(picBrd_Click);
		this.panel11.BackColor = System.Drawing.Color.Silver;
		this.panel11.Controls.Add(this.label6);
		this.panel11.Controls.Add(this.rdGeneral);
		this.panel11.Controls.Add(this.rdLadies);
		this.panel11.Controls.Add(this.rdTatkal);
		this.panel11.Controls.Add(this.rdPtTatkal);
		this.panel11.ForeColor = System.Drawing.SystemColors.ButtonFace;
		this.panel11.Location = new System.Drawing.Point(195, 52);
		this.panel11.Name = "panel11";
		this.panel11.Size = new System.Drawing.Size(439, 24);
		this.panel11.TabIndex = 10;
		this.label6.AutoSize = true;
		this.label6.Font = new System.Drawing.Font("Trebuchet MS", 9f, System.Drawing.FontStyle.Bold);
		this.label6.ForeColor = System.Drawing.Color.Blue;
		this.label6.Location = new System.Drawing.Point(2, 4);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(50, 18);
		this.label6.TabIndex = 13;
		this.label6.Text = "Quota: ";
		this.rdGeneral.AutoSize = true;
		this.rdGeneral.Checked = true;
		this.rdGeneral.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.rdGeneral.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.rdGeneral.Location = new System.Drawing.Point(59, 3);
		this.rdGeneral.Name = "rdGeneral";
		this.rdGeneral.Size = new System.Drawing.Size(69, 19);
		this.rdGeneral.TabIndex = 9;
		this.rdGeneral.TabStop = true;
		this.rdGeneral.Tag = "GN";
		this.rdGeneral.Text = "&General";
		this.rdGeneral.UseVisualStyleBackColor = false;
		this.rdGeneral.CheckedChanged += new System.EventHandler(rdLadies_CheckedChanged);
		this.rdLadies.AutoSize = true;
		this.rdLadies.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.rdLadies.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.rdLadies.Location = new System.Drawing.Point(136, 3);
		this.rdLadies.Name = "rdLadies";
		this.rdLadies.Size = new System.Drawing.Size(63, 19);
		this.rdLadies.TabIndex = 10;
		this.rdLadies.Tag = "LD";
		this.rdLadies.Text = "&Ladies";
		this.rdLadies.UseVisualStyleBackColor = false;
		this.rdLadies.CheckedChanged += new System.EventHandler(rdLadies_CheckedChanged);
		this.rdTatkal.AutoSize = true;
		this.rdTatkal.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.rdTatkal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.rdTatkal.Location = new System.Drawing.Point(205, 3);
		this.rdTatkal.Name = "rdTatkal";
		this.rdTatkal.Size = new System.Drawing.Size(59, 19);
		this.rdTatkal.TabIndex = 11;
		this.rdTatkal.Tag = "TQ";
		this.rdTatkal.Text = "&Tatkal";
		this.rdTatkal.UseVisualStyleBackColor = false;
		this.rdTatkal.CheckedChanged += new System.EventHandler(B0AAA);
		this.rdPtTatkal.AutoSize = true;
		this.rdPtTatkal.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.rdPtTatkal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.rdPtTatkal.Location = new System.Drawing.Point(272, 3);
		this.rdPtTatkal.Name = "rdPtTatkal";
		this.rdPtTatkal.Size = new System.Drawing.Size(114, 19);
		this.rdPtTatkal.TabIndex = 12;
		this.rdPtTatkal.Tag = "PT";
		this.rdPtTatkal.Text = "&Premium Tatkal";
		this.rdPtTatkal.UseVisualStyleBackColor = false;
		this.rdPtTatkal.CheckedChanged += new System.EventHandler(B0AAA);
		this.label5.AutoSize = true;
		this.label5.BackColor = System.Drawing.Color.Transparent;
		this.label5.Font = new System.Drawing.Font("Trebuchet MS", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label5.ForeColor = System.Drawing.Color.Black;
		this.label5.Location = new System.Drawing.Point(225, 5);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(28, 18);
		this.label5.TabIndex = 2;
		this.label5.Text = "To: ";
		this.txtFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
		this.txtFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
		this.txtFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.txtFrom.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtFrom.ForeColor = System.Drawing.Color.Black;
		this.txtFrom.Location = new System.Drawing.Point(49, 4);
		this.txtFrom.Name = "txtFrom";
		this.txtFrom.Size = new System.Drawing.Size(140, 20);
		this.txtFrom.TabIndex = 0;
		this.txtFrom.Enter += new System.EventHandler(txtName1_Enter);
		this.txtFrom.Leave += new System.EventHandler(CHAA0_Leave);
		this.txtTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
		this.txtTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
		this.txtTo.BackColor = System.Drawing.Color.White;
		this.txtTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.txtTo.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtTo.ForeColor = System.Drawing.Color.Black;
		this.txtTo.Location = new System.Drawing.Point(257, 4);
		this.txtTo.Name = "txtTo";
		this.txtTo.Size = new System.Drawing.Size(140, 20);
		this.txtTo.TabIndex = 2;
		this.txtTo.Enter += new System.EventHandler(txtName1_Enter);
		this.txtTo.Leave += new System.EventHandler(BHAAA_Leave);
		this.label9.AutoSize = true;
		this.label9.BackColor = System.Drawing.Color.Transparent;
		this.label9.Font = new System.Drawing.Font("Trebuchet MS", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label9.ForeColor = System.Drawing.Color.Black;
		this.label9.Location = new System.Drawing.Point(3, 31);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(52, 18);
		this.label9.TabIndex = 9;
		this.label9.Text = "Bdg Pt: ";
		this.label4.AutoSize = true;
		this.label4.BackColor = System.Drawing.Color.Transparent;
		this.label4.Font = new System.Drawing.Font("Trebuchet MS", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label4.ForeColor = System.Drawing.Color.Black;
		this.label4.Location = new System.Drawing.Point(397, 5);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(42, 18);
		this.label4.TabIndex = 4;
		this.label4.Text = "Date: ";
		this.btnArrow.BackColor = System.Drawing.Color.Silver;
		this.btnArrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.btnArrow.FlatAppearance.BorderColor = System.Drawing.Color.LightCoral;
		this.btnArrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnArrow.Font = new System.Drawing.Font("Arial", 10.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnArrow.ForeColor = System.Drawing.Color.White;
		this.btnArrow.Location = new System.Drawing.Point(197, 4);
		this.btnArrow.Margin = new System.Windows.Forms.Padding(1);
		this.btnArrow.Name = "btnArrow";
		this.btnArrow.Size = new System.Drawing.Size(25, 20);
		this.btnArrow.TabIndex = 5;
		this.btnArrow.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
		this.btnArrow.UseVisualStyleBackColor = false;
		this.btnArrow.Click += new System.EventHandler(btnArrow_Click);
		this.label10.AutoSize = true;
		this.label10.BackColor = System.Drawing.Color.Transparent;
		this.label10.Font = new System.Drawing.Font("Trebuchet MS", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label10.ForeColor = System.Drawing.Color.Black;
		this.label10.Location = new System.Drawing.Point(194, 31);
		this.label10.Name = "label10";
		this.label10.Size = new System.Drawing.Size(63, 18);
		this.label10.TabIndex = 6;
		this.label10.Text = "Train No: ";
		this.B6AAA.AutoSize = true;
		this.B6AAA.BackColor = System.Drawing.Color.Transparent;
		this.B6AAA.Font = new System.Drawing.Font("Trebuchet MS", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.B6AAA.ForeColor = System.Drawing.Color.Black;
		this.B6AAA.Location = new System.Drawing.Point(3, 60);
		this.B6AAA.Name = "B6AAA";
		this.B6AAA.Size = new System.Drawing.Size(43, 18);
		this.B6AAA.TabIndex = 11;
		this.B6AAA.Text = "Class: ";
		this.panel4.BackColor = System.Drawing.Color.Transparent;
		this.panel4.Controls.Add(this.button2);
		this.panel4.Controls.Add(this.CDAA0);
		this.panel4.Controls.Add(this.panel5);
		this.panel4.Controls.Add(this.txtMobNo);
		this.panel4.Controls.Add(this.label27);
		this.panel4.Controls.Add(this.CA0A0);
		this.panel4.Controls.Add(this.BA0AA);
		this.panel4.Location = new System.Drawing.Point(2, 293);
		this.panel4.Name = "panel4";
		this.panel4.Size = new System.Drawing.Size(638, 33);
		this.panel4.TabIndex = 1101;
		this.button2.BackColor = System.Drawing.Color.FromArgb(46, 49, 146);
		this.button2.FlatAppearance.BorderSize = 0;
		this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.button2.ForeColor = System.Drawing.Color.White;
		this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.button2.Location = new System.Drawing.Point(286, 6);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(80, 23);
		this.button2.TabIndex = 1102;
		this.button2.Text = "&Get Fare";
		this.button2.UseVisualStyleBackColor = false;
		this.CDAA0.AutoSize = true;
		this.CDAA0.BackColor = System.Drawing.Color.Transparent;
		this.CDAA0.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.CDAA0.ForeColor = System.Drawing.Color.Black;
		this.CDAA0.LinkColor = System.Drawing.Color.Blue;
		this.CDAA0.Location = new System.Drawing.Point(289, 12);
		this.CDAA0.Name = "CDAA0";
		this.CDAA0.Size = new System.Drawing.Size(71, 15);
		this.CDAA0.TabIndex = 18;
		this.CDAA0.TabStop = true;
		this.CDAA0.Text = "Check Fare";
		this.CDAA0.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(C0AA0);
		this.panel5.BackColor = System.Drawing.Color.Transparent;
		this.panel5.Controls.Add(this.label37);
		this.panel5.Controls.Add(this.textBox1);
		this.panel5.Controls.Add(this.comboBox1);
		this.panel5.Location = new System.Drawing.Point(370, 6);
		this.panel5.Name = "panel5";
		this.panel5.Size = new System.Drawing.Size(261, 23);
		this.panel5.TabIndex = 1100;
		this.panel5.Visible = false;
		this.label37.AutoSize = true;
		this.label37.BackColor = System.Drawing.Color.Transparent;
		this.label37.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label37.ForeColor = System.Drawing.Color.Black;
		this.label37.Location = new System.Drawing.Point(16, 6);
		this.label37.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
		this.label37.Name = "label37";
		this.label37.Size = new System.Drawing.Size(69, 15);
		this.label37.TabIndex = 1070;
		this.label37.Text = "Set PTFare";
		this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox1.Location = new System.Drawing.Point(137, 3);
		this.textBox1.MaxLength = 5;
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(88, 20);
		this.textBox1.TabIndex = 1101;
		this.comboBox1.BackColor = System.Drawing.Color.White;
		this.comboBox1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.comboBox1.ForeColor = System.Drawing.Color.Black;
		this.comboBox1.FormattingEnabled = true;
		this.comboBox1.Items.AddRange(new object[6] { "0%", "25%", "50%", "100%", "150%", "200%" });
		this.comboBox1.Location = new System.Drawing.Point(137, 2);
		this.comboBox1.Name = "comboBox1";
		this.comboBox1.Size = new System.Drawing.Size(88, 22);
		this.comboBox1.TabIndex = 17;
		this.comboBox1.SelectedIndexChanged += new System.EventHandler(comboBox1_SelectedIndexChanged);
		this.txtMobNo.BackColor = System.Drawing.Color.White;
		this.txtMobNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.txtMobNo.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtMobNo.ForeColor = System.Drawing.Color.Black;
		this.txtMobNo.Location = new System.Drawing.Point(74, 7);
		this.txtMobNo.MaxLength = 10;
		this.txtMobNo.Name = "txtMobNo";
		this.txtMobNo.Size = new System.Drawing.Size(112, 20);
		this.txtMobNo.TabIndex = 14;
		this.txtMobNo.Text = "9000000000";
		this.txtMobNo.TextChanged += new System.EventHandler(B3AAA);
		this.txtMobNo.Enter += new System.EventHandler(txtName1_Enter);
		this.txtMobNo.Leave += new System.EventHandler(txtMobNo_Leave);
		this.label27.AutoSize = true;
		this.label27.BackColor = System.Drawing.Color.Transparent;
		this.label27.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label27.ForeColor = System.Drawing.Color.Black;
		this.label27.Location = new System.Drawing.Point(1, 10);
		this.label27.Name = "label27";
		this.label27.Size = new System.Drawing.Size(68, 15);
		this.label27.TabIndex = 4;
		this.label27.Text = "Mobile +91";
		this.CA0A0.AutoSize = true;
		this.CA0A0.BackColor = System.Drawing.Color.Transparent;
		this.CA0A0.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.CA0A0.ForeColor = System.Drawing.Color.Black;
		this.CA0A0.Location = new System.Drawing.Point(191, 10);
		this.CA0A0.Name = "CA0A0";
		this.CA0A0.Size = new System.Drawing.Size(35, 15);
		this.CA0A0.TabIndex = 1073;
		this.CA0A0.Text = "Fare:";
		this.BA0AA.AutoSize = true;
		this.BA0AA.BackColor = System.Drawing.Color.Transparent;
		this.BA0AA.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.BA0AA.ForeColor = System.Drawing.Color.Black;
		this.BA0AA.Location = new System.Drawing.Point(236, 10);
		this.BA0AA.Name = "BA0AA";
		this.BA0AA.Size = new System.Drawing.Size(36, 15);
		this.BA0AA.TabIndex = 1074;
		this.BA0AA.Text = "Base";
		this.label28.AutoSize = true;
		this.label28.BackColor = System.Drawing.Color.Transparent;
		this.label28.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label28.ForeColor = System.Drawing.SystemColors.WindowText;
		this.label28.Location = new System.Drawing.Point(689, 327);
		this.label28.Name = "label28";
		this.label28.Size = new System.Drawing.Size(53, 15);
		this.label28.TabIndex = 1077;
		this.label28.Text = "PT Fare:";
		this.setf.AutoSize = true;
		this.setf.BackColor = System.Drawing.Color.Transparent;
		this.setf.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.setf.ForeColor = System.Drawing.SystemColors.WindowText;
		this.setf.Location = new System.Drawing.Point(689, 305);
		this.setf.Name = "setf";
		this.setf.Size = new System.Drawing.Size(35, 15);
		this.setf.TabIndex = 1076;
		this.setf.Text = " Fare";
		this.bunifuElipse_0.ElipseRadius = 5;
		this.bunifuElipse_0.TargetControl = this;
		this.CGAA0.BackColor = System.Drawing.Color.Transparent;
		this.CGAA0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.CGAA0.Controls.Add(this.chkCH6);
		this.CGAA0.Controls.Add(this.chkCH5);
		this.CGAA0.Controls.Add(this.chkCH4);
		this.CGAA0.Controls.Add(this.chkCH3);
		this.CGAA0.Controls.Add(this.chkCH2);
		this.CGAA0.Controls.Add(this.chkCH1);
		this.CGAA0.Controls.Add(this.label36);
		this.CGAA0.Controls.Add(this.C7AA0);
		this.CGAA0.Controls.Add(this.label33);
		this.CGAA0.Controls.Add(this.CFAA0);
		this.CGAA0.Controls.Add(this.txtID5);
		this.CGAA0.Controls.Add(this.txtID4);
		this.CGAA0.Controls.Add(this.txtID3);
		this.CGAA0.Controls.Add(this.txtID2);
		this.CGAA0.Controls.Add(this.BFAAA);
		this.CGAA0.Controls.Add(this.cboID6);
		this.CGAA0.Controls.Add(this.cboID5);
		this.CGAA0.Controls.Add(this.cboID4);
		this.CGAA0.Controls.Add(this.cboID3);
		this.CGAA0.Controls.Add(this.cboID2);
		this.CGAA0.Controls.Add(this.label41);
		this.CGAA0.Controls.Add(this.txtID1);
		this.CGAA0.Controls.Add(this.label3);
		this.CGAA0.Controls.Add(this.cboID1);
		this.CGAA0.Controls.Add(this.label40);
		this.CGAA0.Controls.Add(this.cboFood6);
		this.CGAA0.Controls.Add(this.cboFood5);
		this.CGAA0.Controls.Add(this.cboFood4);
		this.CGAA0.Controls.Add(this.cboFood3);
		this.CGAA0.Controls.Add(this.cboFood2);
		this.CGAA0.Controls.Add(this.chkBd6);
		this.CGAA0.Controls.Add(this.cboFood1);
		this.CGAA0.Controls.Add(this.chk6);
		this.CGAA0.Controls.Add(this.cboBerth6);
		this.CGAA0.Controls.Add(this.cboSex6);
		this.CGAA0.Controls.Add(this.txtAge6);
		this.CGAA0.Controls.Add(this.chkBd5);
		this.CGAA0.Controls.Add(this.txtName6);
		this.CGAA0.Controls.Add(this.chk5);
		this.CGAA0.Controls.Add(this.cboBerth5);
		this.CGAA0.Controls.Add(this.cboSex5);
		this.CGAA0.Controls.Add(this.txtAge5);
		this.CGAA0.Controls.Add(this.chkBd4);
		this.CGAA0.Controls.Add(this.txtName5);
		this.CGAA0.Controls.Add(this.chk4);
		this.CGAA0.Controls.Add(this.cboBerth4);
		this.CGAA0.Controls.Add(this.cboSex4);
		this.CGAA0.Controls.Add(this.txtAge4);
		this.CGAA0.Controls.Add(this.chkBd3);
		this.CGAA0.Controls.Add(this.txtName4);
		this.CGAA0.Controls.Add(this.chk3);
		this.CGAA0.Controls.Add(this.cboBerth3);
		this.CGAA0.Controls.Add(this.cboSex3);
		this.CGAA0.Controls.Add(this.txtAge3);
		this.CGAA0.Controls.Add(this.chkBd2);
		this.CGAA0.Controls.Add(this.txtName3);
		this.CGAA0.Controls.Add(this.chk2);
		this.CGAA0.Controls.Add(this.cboBerth2);
		this.CGAA0.Controls.Add(this.cboSex2);
		this.CGAA0.Controls.Add(this.txtAge2);
		this.CGAA0.Controls.Add(this.chkBd1);
		this.CGAA0.Controls.Add(this.txtName2);
		this.CGAA0.Controls.Add(this.chk1);
		this.CGAA0.Controls.Add(this.cboBerth1);
		this.CGAA0.Controls.Add(this.cboSex1);
		this.CGAA0.Controls.Add(this.txtAge1);
		this.CGAA0.Controls.Add(this.txtName1);
		this.CGAA0.Controls.Add(this.panel2);
		this.CGAA0.Controls.Add(this.label21);
		this.CGAA0.Controls.Add(this.label20);
		this.CGAA0.Controls.Add(this.label19);
		this.CGAA0.Controls.Add(this.label18);
		this.CGAA0.Controls.Add(this.label17);
		this.CGAA0.Controls.Add(this.label8);
		this.CGAA0.Controls.Add(this.label15);
		this.CGAA0.Controls.Add(this.label14);
		this.CGAA0.Controls.Add(this.label13);
		this.CGAA0.Controls.Add(this.B7AAA);
		this.CGAA0.Controls.Add(this.label7);
		this.CGAA0.ForeColor = System.Drawing.Color.Black;
		this.CGAA0.Location = new System.Drawing.Point(2, 106);
		this.CGAA0.Name = "CGAA0";
		this.CGAA0.Size = new System.Drawing.Size(639, 185);
		this.CGAA0.TabIndex = 19;
		this.CGAA0.TabStop = false;
		this.CGAA0.Text = "Passenger Details";
		this.label36.AutoSize = true;
		this.label36.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label36.ForeColor = System.Drawing.Color.Black;
		this.label36.Location = new System.Drawing.Point(599, 15);
		this.label36.Name = "label36";
		this.label36.Size = new System.Drawing.Size(28, 14);
		this.label36.TabIndex = 8;
		this.label36.Text = "Bed";
		this.C7AA0.AutoSize = true;
		this.C7AA0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.C7AA0.ForeColor = System.Drawing.Color.Black;
		this.C7AA0.Location = new System.Drawing.Point(558, 15);
		this.C7AA0.Name = "C7AA0";
		this.C7AA0.Size = new System.Drawing.Size(43, 14);
		this.C7AA0.TabIndex = 8;
		this.C7AA0.Text = "Senior";
		this.label33.AutoSize = true;
		this.label33.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label33.ForeColor = System.Drawing.Color.Black;
		this.label33.Location = new System.Drawing.Point(523, 15);
		this.label33.Name = "label33";
		this.label33.Size = new System.Drawing.Size(35, 14);
		this.label33.TabIndex = 65;
		this.label33.Text = "Child";
		this.CFAA0.BackColor = System.Drawing.Color.White;
		this.CFAA0.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.CFAA0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.CFAA0.ForeColor = System.Drawing.Color.Black;
		this.CFAA0.Location = new System.Drawing.Point(455, 160);
		this.CFAA0.MaxLength = 16;
		this.CFAA0.Name = "CFAA0";
		this.CFAA0.Size = new System.Drawing.Size(82, 20);
		this.CFAA0.TabIndex = 81;
		this.CFAA0.Enter += new System.EventHandler(txtName1_Enter);
		this.CFAA0.Leave += new System.EventHandler(txtID1_Leave);
		this.txtID5.BackColor = System.Drawing.Color.White;
		this.txtID5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.txtID5.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtID5.ForeColor = System.Drawing.Color.Black;
		this.txtID5.Location = new System.Drawing.Point(455, 135);
		this.txtID5.MaxLength = 16;
		this.txtID5.Name = "txtID5";
		this.txtID5.Size = new System.Drawing.Size(82, 20);
		this.txtID5.TabIndex = 71;
		this.txtID5.Enter += new System.EventHandler(txtName1_Enter);
		this.txtID5.Leave += new System.EventHandler(txtID1_Leave);
		this.txtID4.BackColor = System.Drawing.Color.White;
		this.txtID4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.txtID4.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtID4.ForeColor = System.Drawing.Color.Black;
		this.txtID4.Location = new System.Drawing.Point(455, 111);
		this.txtID4.MaxLength = 16;
		this.txtID4.Name = "txtID4";
		this.txtID4.Size = new System.Drawing.Size(82, 20);
		this.txtID4.TabIndex = 61;
		this.txtID4.Enter += new System.EventHandler(txtName1_Enter);
		this.txtID4.Leave += new System.EventHandler(txtID1_Leave);
		this.txtID3.BackColor = System.Drawing.Color.White;
		this.txtID3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.txtID3.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtID3.ForeColor = System.Drawing.Color.Black;
		this.txtID3.Location = new System.Drawing.Point(455, 87);
		this.txtID3.MaxLength = 16;
		this.txtID3.Name = "txtID3";
		this.txtID3.Size = new System.Drawing.Size(82, 20);
		this.txtID3.TabIndex = 51;
		this.txtID3.Enter += new System.EventHandler(txtName1_Enter);
		this.txtID3.Leave += new System.EventHandler(txtID1_Leave);
		this.txtID2.BackColor = System.Drawing.Color.White;
		this.txtID2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.txtID2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtID2.ForeColor = System.Drawing.Color.Black;
		this.txtID2.Location = new System.Drawing.Point(455, 63);
		this.txtID2.MaxLength = 16;
		this.txtID2.Name = "txtID2";
		this.txtID2.Size = new System.Drawing.Size(82, 20);
		this.txtID2.TabIndex = 41;
		this.txtID2.Enter += new System.EventHandler(txtName1_Enter);
		this.txtID2.Leave += new System.EventHandler(txtID1_Leave);
		this.BFAAA.BackColor = System.Drawing.Color.FromArgb(204, 204, 204);
		this.BFAAA.Controls.Add(this.label16);
		this.BFAAA.Controls.Add(this.label29);
		this.BFAAA.Controls.Add(this.CCAA0);
		this.BFAAA.Controls.Add(this.BCAAA);
		this.BFAAA.Controls.Add(this.label24);
		this.BFAAA.Controls.Add(this.label23);
		this.BFAAA.Controls.Add(this.label22);
		this.BFAAA.Controls.Add(this.panel3);
		this.BFAAA.Controls.Add(this.txtChName1);
		this.BFAAA.Controls.Add(this.cboChSex1);
		this.BFAAA.Controls.Add(this.txtChName2);
		this.BFAAA.Controls.Add(this.cboChSex2);
		this.BFAAA.Controls.Add(this.cboAge1);
		this.BFAAA.Controls.Add(this.cboAge2);
		this.BFAAA.ForeColor = System.Drawing.Color.Black;
		this.BFAAA.Location = new System.Drawing.Point(824, 194);
		this.BFAAA.Name = "BFAAA";
		this.BFAAA.Size = new System.Drawing.Size(798, 88);
		this.BFAAA.TabIndex = 64;
		this.label16.AutoSize = true;
		this.label16.BackColor = System.Drawing.Color.White;
		this.label16.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
		this.label16.ForeColor = System.Drawing.Color.Black;
		this.label16.Location = new System.Drawing.Point(3, 1);
		this.label16.Name = "label16";
		this.label16.Size = new System.Drawing.Size(291, 14);
		this.label16.TabIndex = 150;
		this.label16.Text = "Child Passenger Details (Ticket Is Not To Be Issued)";
		this.label29.AutoSize = true;
		this.label29.BackColor = System.Drawing.Color.White;
		this.label29.ForeColor = System.Drawing.Color.Black;
		this.label29.Location = new System.Drawing.Point(4, 20);
		this.label29.Name = "label29";
		this.label29.Size = new System.Drawing.Size(28, 13);
		this.label29.TabIndex = 1;
		this.label29.Tag = "SNo";
		this.label29.Text = "SNo";
		this.CCAA0.AutoSize = true;
		this.CCAA0.BackColor = System.Drawing.Color.White;
		this.CCAA0.ForeColor = System.Drawing.Color.Black;
		this.CCAA0.Location = new System.Drawing.Point(413, 20);
		this.CCAA0.Name = "CCAA0";
		this.CCAA0.Size = new System.Drawing.Size(25, 13);
		this.CCAA0.TabIndex = 4;
		this.CCAA0.Text = "Sex";
		this.BCAAA.AutoSize = true;
		this.BCAAA.BackColor = System.Drawing.Color.White;
		this.BCAAA.ForeColor = System.Drawing.Color.Black;
		this.BCAAA.Location = new System.Drawing.Point(283, 20);
		this.BCAAA.Name = "BCAAA";
		this.BCAAA.Size = new System.Drawing.Size(26, 13);
		this.BCAAA.TabIndex = 3;
		this.BCAAA.Text = "Age";
		this.label24.AutoSize = true;
		this.label24.BackColor = System.Drawing.Color.White;
		this.label24.ForeColor = System.Drawing.Color.Black;
		this.label24.Location = new System.Drawing.Point(91, 20);
		this.label24.Name = "label24";
		this.label24.Size = new System.Drawing.Size(35, 13);
		this.label24.TabIndex = 2;
		this.label24.Text = "Name";
		this.label23.AutoSize = true;
		this.label23.BackColor = System.Drawing.Color.White;
		this.label23.ForeColor = System.Drawing.Color.Black;
		this.label23.Location = new System.Drawing.Point(7, 45);
		this.label23.Name = "label23";
		this.label23.Size = new System.Drawing.Size(13, 13);
		this.label23.TabIndex = 6;
		this.label23.Text = "1";
		this.label22.AutoSize = true;
		this.label22.BackColor = System.Drawing.Color.White;
		this.label22.ForeColor = System.Drawing.Color.Black;
		this.label22.Location = new System.Drawing.Point(7, 68);
		this.label22.Name = "label22";
		this.label22.Size = new System.Drawing.Size(13, 13);
		this.label22.TabIndex = 10;
		this.label22.Text = "2";
		this.panel3.BackColor = System.Drawing.Color.FromArgb(204, 204, 204);
		this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.panel3.ForeColor = System.Drawing.Color.Black;
		this.panel3.Location = new System.Drawing.Point(2, 36);
		this.panel3.Name = "panel3";
		this.panel3.Size = new System.Drawing.Size(796, 3);
		this.panel3.TabIndex = 5;
		this.txtChName1.BackColor = System.Drawing.Color.White;
		this.txtChName1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.txtChName1.ForeColor = System.Drawing.Color.Black;
		this.txtChName1.Location = new System.Drawing.Point(26, 41);
		this.txtChName1.MaxLength = 16;
		this.txtChName1.Name = "txtChName1";
		this.txtChName1.Size = new System.Drawing.Size(177, 20);
		this.txtChName1.TabIndex = 84;
		this.txtChName1.Leave += new System.EventHandler(txtName1_Leave);
		this.cboChSex1.BackColor = System.Drawing.Color.White;
		this.cboChSex1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboChSex1.ForeColor = System.Drawing.Color.Black;
		this.cboChSex1.FormattingEnabled = true;
		this.cboChSex1.Items.AddRange(new object[3] { "Select", "M", "F" });
		this.cboChSex1.Location = new System.Drawing.Point(400, 41);
		this.cboChSex1.Name = "cboChSex1";
		this.cboChSex1.Size = new System.Drawing.Size(65, 21);
		this.cboChSex1.TabIndex = 86;
		this.txtChName2.BackColor = System.Drawing.Color.White;
		this.txtChName2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.txtChName2.ForeColor = System.Drawing.Color.Black;
		this.txtChName2.Location = new System.Drawing.Point(26, 65);
		this.txtChName2.MaxLength = 16;
		this.txtChName2.Name = "txtChName2";
		this.txtChName2.Size = new System.Drawing.Size(177, 20);
		this.txtChName2.TabIndex = 87;
		this.txtChName2.Leave += new System.EventHandler(txtName1_Leave);
		this.cboChSex2.BackColor = System.Drawing.Color.White;
		this.cboChSex2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboChSex2.ForeColor = System.Drawing.Color.Black;
		this.cboChSex2.FormattingEnabled = true;
		this.cboChSex2.Items.AddRange(new object[3] { "Select", "M", "F" });
		this.cboChSex2.Location = new System.Drawing.Point(400, 65);
		this.cboChSex2.Name = "cboChSex2";
		this.cboChSex2.Size = new System.Drawing.Size(65, 21);
		this.cboChSex2.TabIndex = 89;
		this.cboAge1.BackColor = System.Drawing.Color.White;
		this.cboAge1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboAge1.ForeColor = System.Drawing.Color.Black;
		this.cboAge1.FormattingEnabled = true;
		this.cboAge1.Items.AddRange(new object[6] { "Select", "Below one year", "One year", "Two year", "Three year", "Four year" });
		this.cboAge1.Location = new System.Drawing.Point(228, 40);
		this.cboAge1.Name = "cboAge1";
		this.cboAge1.Size = new System.Drawing.Size(148, 21);
		this.cboAge1.TabIndex = 85;
		this.cboAge2.BackColor = System.Drawing.Color.White;
		this.cboAge2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboAge2.ForeColor = System.Drawing.Color.Black;
		this.cboAge2.FormattingEnabled = true;
		this.cboAge2.Items.AddRange(new object[6] { "Select", "Below one year", "One year", "Two year", "Three year", "Four year" });
		this.cboAge2.Location = new System.Drawing.Point(228, 64);
		this.cboAge2.Name = "cboAge2";
		this.cboAge2.Size = new System.Drawing.Size(148, 21);
		this.cboAge2.TabIndex = 87;
		this.cboID6.BackColor = System.Drawing.Color.White;
		this.cboID6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboID6.DropDownWidth = 200;
		this.cboID6.Font = new System.Drawing.Font("Arial", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboID6.ForeColor = System.Drawing.Color.Black;
		this.cboID6.FormattingEnabled = true;
		this.cboID6.Items.AddRange(new object[10] { "Choose ID", "Aadhaar ID", "Driving Licence", "Passport", "PAN Card", "Voter ID-card", "Govt Issued ID-Card", "Student ID-Card", "Bank Passbook", "Credit card with Photo" });
		this.cboID6.Location = new System.Drawing.Point(377, 160);
		this.cboID6.Name = "cboID6";
		this.cboID6.Size = new System.Drawing.Size(72, 19);
		this.cboID6.TabIndex = 80;
		this.cboID6.SelectedIndexChanged += new System.EventHandler(cboID1_SelectedIndexChanged);
		this.cboID5.BackColor = System.Drawing.Color.White;
		this.cboID5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboID5.DropDownWidth = 200;
		this.cboID5.Font = new System.Drawing.Font("Arial", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboID5.ForeColor = System.Drawing.Color.Black;
		this.cboID5.FormattingEnabled = true;
		this.cboID5.Items.AddRange(new object[10] { "Choose ID", "Aadhaar ID", "Driving Licence", "Passport", "PAN Card", "Voter ID-card", "Govt Issued ID-Card", "Student ID-Card", "Bank Passbook", "Credit card with Photo" });
		this.cboID5.Location = new System.Drawing.Point(377, 135);
		this.cboID5.Name = "cboID5";
		this.cboID5.Size = new System.Drawing.Size(72, 19);
		this.cboID5.TabIndex = 70;
		this.cboID5.SelectedIndexChanged += new System.EventHandler(cboID1_SelectedIndexChanged);
		this.cboID4.BackColor = System.Drawing.Color.White;
		this.cboID4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboID4.DropDownWidth = 200;
		this.cboID4.Font = new System.Drawing.Font("Arial", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboID4.ForeColor = System.Drawing.Color.Black;
		this.cboID4.FormattingEnabled = true;
		this.cboID4.Items.AddRange(new object[10] { "Choose ID", "Aadhaar ID", "Driving Licence", "Passport", "PAN Card", "Voter ID-card", "Govt Issued ID-Card", "Student ID-Card", "Bank Passbook", "Credit card with Photo" });
		this.cboID4.Location = new System.Drawing.Point(377, 111);
		this.cboID4.Name = "cboID4";
		this.cboID4.Size = new System.Drawing.Size(72, 19);
		this.cboID4.TabIndex = 60;
		this.cboID4.SelectedIndexChanged += new System.EventHandler(cboID1_SelectedIndexChanged);
		this.cboID3.BackColor = System.Drawing.Color.White;
		this.cboID3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboID3.DropDownWidth = 200;
		this.cboID3.Font = new System.Drawing.Font("Arial", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboID3.ForeColor = System.Drawing.Color.Black;
		this.cboID3.FormattingEnabled = true;
		this.cboID3.Items.AddRange(new object[10] { "Choose ID", "Aadhaar ID", "Driving Licence", "Passport", "PAN Card", "Voter ID-card", "Govt Issued ID-Card", "Student ID-Card", "Bank Passbook", "Credit card with Photo" });
		this.cboID3.Location = new System.Drawing.Point(377, 87);
		this.cboID3.Name = "cboID3";
		this.cboID3.Size = new System.Drawing.Size(72, 19);
		this.cboID3.TabIndex = 50;
		this.cboID3.SelectedIndexChanged += new System.EventHandler(cboID1_SelectedIndexChanged);
		this.cboID2.BackColor = System.Drawing.Color.White;
		this.cboID2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboID2.DropDownWidth = 200;
		this.cboID2.Font = new System.Drawing.Font("Arial", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboID2.ForeColor = System.Drawing.Color.Black;
		this.cboID2.FormattingEnabled = true;
		this.cboID2.Items.AddRange(new object[10] { "Choose ID", "Aadhaar ID", "Driving Licence", "Passport", "PAN Card", "Voter ID-card", "Govt Issued ID-Card", "Student ID-Card", "Bank Passbook", "Credit card with Photo" });
		this.cboID2.Location = new System.Drawing.Point(377, 63);
		this.cboID2.Name = "cboID2";
		this.cboID2.Size = new System.Drawing.Size(72, 19);
		this.cboID2.TabIndex = 40;
		this.cboID2.SelectedIndexChanged += new System.EventHandler(cboID1_SelectedIndexChanged);
		this.label41.AutoSize = true;
		this.label41.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label41.ForeColor = System.Drawing.Color.Black;
		this.label41.Location = new System.Drawing.Point(455, 15);
		this.label41.Name = "label41";
		this.label41.Size = new System.Drawing.Size(57, 14);
		this.label41.TabIndex = 7;
		this.label41.Text = "Passport";
		this.txtID1.BackColor = System.Drawing.Color.White;
		this.txtID1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.txtID1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtID1.ForeColor = System.Drawing.Color.Black;
		this.txtID1.Location = new System.Drawing.Point(455, 38);
		this.txtID1.MaxLength = 16;
		this.txtID1.Name = "txtID1";
		this.txtID1.Size = new System.Drawing.Size(82, 20);
		this.txtID1.TabIndex = 31;
		this.txtID1.Enter += new System.EventHandler(txtName1_Enter);
		this.txtID1.Leave += new System.EventHandler(txtID1_Leave);
		this.label3.AutoSize = true;
		this.label3.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label3.ForeColor = System.Drawing.Color.Black;
		this.label3.Location = new System.Drawing.Point(377, 15);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(63, 14);
		this.label3.TabIndex = 6;
		this.label3.Text = "Nationality";
		this.cboID1.BackColor = System.Drawing.Color.White;
		this.cboID1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboID1.DropDownWidth = 200;
		this.cboID1.Font = new System.Drawing.Font("Arial", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboID1.ForeColor = System.Drawing.Color.Black;
		this.cboID1.FormattingEnabled = true;
		this.cboID1.Items.AddRange(new object[10] { "Choose ID", "Aadhaar ID", "Driving Licence", "Passport", "PAN Card", "Voter ID-card", "Govt Issued ID-Card", "Student ID-Card", "Bank Passbook", "Credit card with Photo" });
		this.cboID1.Location = new System.Drawing.Point(377, 38);
		this.cboID1.Name = "cboID1";
		this.cboID1.Size = new System.Drawing.Size(72, 19);
		this.cboID1.TabIndex = 30;
		this.cboID1.SelectedIndexChanged += new System.EventHandler(cboID1_SelectedIndexChanged);
		this.label40.AutoSize = true;
		this.label40.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label40.ForeColor = System.Drawing.Color.Black;
		this.label40.Location = new System.Drawing.Point(328, 15);
		this.label40.Name = "label40";
		this.label40.Size = new System.Drawing.Size(34, 14);
		this.label40.TabIndex = 5;
		this.label40.Text = "Food";
		this.cboFood6.BackColor = System.Drawing.Color.White;
		this.cboFood6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboFood6.Font = new System.Drawing.Font("Arial", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboFood6.ForeColor = System.Drawing.Color.Black;
		this.cboFood6.FormattingEnabled = true;
		this.cboFood6.Items.AddRange(new object[4] { "Select", "Veg", "Non-Veg", "No Food" });
		this.cboFood6.Location = new System.Drawing.Point(329, 160);
		this.cboFood6.Name = "cboFood6";
		this.cboFood6.Size = new System.Drawing.Size(43, 19);
		this.cboFood6.TabIndex = 79;
		this.cboFood5.BackColor = System.Drawing.Color.White;
		this.cboFood5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboFood5.Font = new System.Drawing.Font("Arial", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboFood5.ForeColor = System.Drawing.Color.Black;
		this.cboFood5.FormattingEnabled = true;
		this.cboFood5.Items.AddRange(new object[4] { "Select", "Veg", "Non-Veg", "No Food" });
		this.cboFood5.Location = new System.Drawing.Point(329, 135);
		this.cboFood5.Name = "cboFood5";
		this.cboFood5.Size = new System.Drawing.Size(43, 19);
		this.cboFood5.TabIndex = 69;
		this.cboFood4.BackColor = System.Drawing.Color.White;
		this.cboFood4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboFood4.Font = new System.Drawing.Font("Arial", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboFood4.ForeColor = System.Drawing.Color.Black;
		this.cboFood4.FormattingEnabled = true;
		this.cboFood4.Items.AddRange(new object[4] { "Select", "Veg", "Non-Veg", "No Food" });
		this.cboFood4.Location = new System.Drawing.Point(329, 111);
		this.cboFood4.Name = "cboFood4";
		this.cboFood4.Size = new System.Drawing.Size(43, 19);
		this.cboFood4.TabIndex = 59;
		this.cboFood3.BackColor = System.Drawing.Color.White;
		this.cboFood3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboFood3.Font = new System.Drawing.Font("Arial", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboFood3.ForeColor = System.Drawing.Color.Black;
		this.cboFood3.FormattingEnabled = true;
		this.cboFood3.Items.AddRange(new object[4] { "Select", "Veg", "Non-Veg", "No Food" });
		this.cboFood3.Location = new System.Drawing.Point(329, 87);
		this.cboFood3.Name = "cboFood3";
		this.cboFood3.Size = new System.Drawing.Size(43, 19);
		this.cboFood3.TabIndex = 49;
		this.cboFood2.BackColor = System.Drawing.Color.White;
		this.cboFood2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboFood2.Font = new System.Drawing.Font("Arial", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboFood2.ForeColor = System.Drawing.Color.Black;
		this.cboFood2.FormattingEnabled = true;
		this.cboFood2.Items.AddRange(new object[4] { "Select", "Veg", "Non-Veg", "No Food" });
		this.cboFood2.Location = new System.Drawing.Point(329, 63);
		this.cboFood2.Name = "cboFood2";
		this.cboFood2.Size = new System.Drawing.Size(43, 19);
		this.cboFood2.TabIndex = 39;
		this.chkBd6.AutoSize = true;
		this.chkBd6.BackColor = System.Drawing.Color.White;
		this.chkBd6.ForeColor = System.Drawing.Color.Black;
		this.chkBd6.Location = new System.Drawing.Point(607, 165);
		this.chkBd6.Name = "chkBd6";
		this.chkBd6.Size = new System.Drawing.Size(15, 14);
		this.chkBd6.TabIndex = 83;
		this.chkBd6.UseVisualStyleBackColor = false;
		this.chkBd6.CheckedChanged += new System.EventHandler(chk1_CheckedChanged);
		this.cboFood1.BackColor = System.Drawing.Color.White;
		this.cboFood1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboFood1.Font = new System.Drawing.Font("Arial", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboFood1.ForeColor = System.Drawing.Color.Black;
		this.cboFood1.FormattingEnabled = true;
		this.cboFood1.Items.AddRange(new object[4] { "Select", "Veg", "Non-Veg", "No Food" });
		this.cboFood1.Location = new System.Drawing.Point(329, 39);
		this.cboFood1.Name = "cboFood1";
		this.cboFood1.Size = new System.Drawing.Size(43, 19);
		this.cboFood1.TabIndex = 29;
		this.cboBerth6.BackColor = System.Drawing.Color.White;
		this.cboBerth6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboBerth6.Font = new System.Drawing.Font("Arial", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboBerth6.ForeColor = System.Drawing.Color.Black;
		this.cboBerth6.FormattingEnabled = true;
		this.cboBerth6.Items.AddRange(new object[1] { "Choose Berth" });
		this.cboBerth6.Location = new System.Drawing.Point(255, 160);
		this.cboBerth6.Name = "cboBerth6";
		this.cboBerth6.Size = new System.Drawing.Size(71, 19);
		this.cboBerth6.TabIndex = 78;
		this.cboSex6.BackColor = System.Drawing.Color.White;
		this.cboSex6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboSex6.Font = new System.Drawing.Font("Arial", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboSex6.ForeColor = System.Drawing.Color.Black;
		this.cboSex6.FormattingEnabled = true;
		this.cboSex6.Items.AddRange(new object[3] { "Select", "M", "F" });
		this.cboSex6.Location = new System.Drawing.Point(207, 160);
		this.cboSex6.Name = "cboSex6";
		this.cboSex6.Size = new System.Drawing.Size(42, 19);
		this.cboSex6.TabIndex = 77;
		this.cboSex6.Leave += new System.EventHandler(CBAA0_Leave);
		this.txtAge6.BackColor = System.Drawing.Color.White;
		this.txtAge6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.txtAge6.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtAge6.ForeColor = System.Drawing.Color.Black;
		this.txtAge6.Location = new System.Drawing.Point(170, 160);
		this.txtAge6.MaxLength = 3;
		this.txtAge6.Name = "txtAge6";
		this.txtAge6.Size = new System.Drawing.Size(32, 20);
		this.txtAge6.TabIndex = 76;
		this.txtAge6.Enter += new System.EventHandler(txtName1_Enter);
		this.txtAge6.Leave += new System.EventHandler(txtAge1_Leave);
		this.chkBd5.AutoSize = true;
		this.chkBd5.BackColor = System.Drawing.Color.White;
		this.chkBd5.ForeColor = System.Drawing.Color.Black;
		this.chkBd5.Location = new System.Drawing.Point(607, 139);
		this.chkBd5.Name = "chkBd5";
		this.chkBd5.Size = new System.Drawing.Size(15, 14);
		this.chkBd5.TabIndex = 74;
		this.chkBd5.UseVisualStyleBackColor = false;
		this.chkBd5.CheckedChanged += new System.EventHandler(chk1_CheckedChanged);
		this.txtName6.BackColor = System.Drawing.Color.White;
		this.txtName6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.txtName6.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtName6.ForeColor = System.Drawing.Color.Black;
		this.txtName6.Location = new System.Drawing.Point(29, 160);
		this.txtName6.MaxLength = 16;
		this.txtName6.Name = "txtName6";
		this.txtName6.Size = new System.Drawing.Size(134, 20);
		this.txtName6.TabIndex = 75;
		this.txtName6.TextChanged += new System.EventHandler(PS_Name_TextChanged);
		this.txtName6.Enter += new System.EventHandler(txtName1_Enter);
		this.txtName6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(TextOnly_KeyPress);
		this.txtName6.Leave += new System.EventHandler(txtName1_Leave);
		this.cboBerth5.BackColor = System.Drawing.Color.White;
		this.cboBerth5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboBerth5.Font = new System.Drawing.Font("Arial", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboBerth5.ForeColor = System.Drawing.Color.Black;
		this.cboBerth5.FormattingEnabled = true;
		this.cboBerth5.Items.AddRange(new object[1] { "Choose Berth" });
		this.cboBerth5.Location = new System.Drawing.Point(255, 135);
		this.cboBerth5.Name = "cboBerth5";
		this.cboBerth5.Size = new System.Drawing.Size(71, 19);
		this.cboBerth5.TabIndex = 68;
		this.cboSex5.BackColor = System.Drawing.Color.White;
		this.cboSex5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboSex5.Font = new System.Drawing.Font("Arial", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboSex5.ForeColor = System.Drawing.Color.Black;
		this.cboSex5.FormattingEnabled = true;
		this.cboSex5.Items.AddRange(new object[3] { "Select", "M", "F" });
		this.cboSex5.Location = new System.Drawing.Point(207, 136);
		this.cboSex5.Name = "cboSex5";
		this.cboSex5.Size = new System.Drawing.Size(42, 19);
		this.cboSex5.TabIndex = 67;
		this.cboSex5.Leave += new System.EventHandler(cboSex5_Leave);
		this.txtAge5.BackColor = System.Drawing.Color.White;
		this.txtAge5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.txtAge5.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtAge5.ForeColor = System.Drawing.Color.Black;
		this.txtAge5.Location = new System.Drawing.Point(170, 136);
		this.txtAge5.MaxLength = 3;
		this.txtAge5.Name = "txtAge5";
		this.txtAge5.Size = new System.Drawing.Size(32, 20);
		this.txtAge5.TabIndex = 66;
		this.txtAge5.Enter += new System.EventHandler(txtName1_Enter);
		this.txtAge5.Leave += new System.EventHandler(txtAge1_Leave);
		this.chkBd4.AutoSize = true;
		this.chkBd4.BackColor = System.Drawing.Color.White;
		this.chkBd4.ForeColor = System.Drawing.Color.Black;
		this.chkBd4.Location = new System.Drawing.Point(607, 114);
		this.chkBd4.Name = "chkBd4";
		this.chkBd4.Size = new System.Drawing.Size(15, 14);
		this.chkBd4.TabIndex = 64;
		this.chkBd4.UseVisualStyleBackColor = false;
		this.chkBd4.CheckedChanged += new System.EventHandler(chk1_CheckedChanged);
		this.txtName5.BackColor = System.Drawing.Color.White;
		this.txtName5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.txtName5.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtName5.ForeColor = System.Drawing.Color.Black;
		this.txtName5.Location = new System.Drawing.Point(29, 136);
		this.txtName5.MaxLength = 16;
		this.txtName5.Name = "txtName5";
		this.txtName5.Size = new System.Drawing.Size(134, 20);
		this.txtName5.TabIndex = 65;
		this.txtName5.TextChanged += new System.EventHandler(PS_Name_TextChanged);
		this.txtName5.Enter += new System.EventHandler(txtName1_Enter);
		this.txtName5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(TextOnly_KeyPress);
		this.txtName5.Leave += new System.EventHandler(txtName1_Leave);
		this.cboBerth4.BackColor = System.Drawing.Color.White;
		this.cboBerth4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboBerth4.Font = new System.Drawing.Font("Arial", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboBerth4.ForeColor = System.Drawing.Color.Black;
		this.cboBerth4.FormattingEnabled = true;
		this.cboBerth4.Items.AddRange(new object[1] { "Choose Berth" });
		this.cboBerth4.Location = new System.Drawing.Point(255, 111);
		this.cboBerth4.Name = "cboBerth4";
		this.cboBerth4.Size = new System.Drawing.Size(71, 19);
		this.cboBerth4.TabIndex = 58;
		this.cboSex4.BackColor = System.Drawing.Color.White;
		this.cboSex4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboSex4.Font = new System.Drawing.Font("Arial", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboSex4.ForeColor = System.Drawing.Color.Black;
		this.cboSex4.FormattingEnabled = true;
		this.cboSex4.Items.AddRange(new object[3] { "Select", "M", "F" });
		this.cboSex4.Location = new System.Drawing.Point(207, 112);
		this.cboSex4.Name = "cboSex4";
		this.cboSex4.Size = new System.Drawing.Size(42, 19);
		this.cboSex4.TabIndex = 57;
		this.cboSex4.Leave += new System.EventHandler(C2AA0);
		this.txtAge4.BackColor = System.Drawing.Color.White;
		this.txtAge4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.txtAge4.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtAge4.ForeColor = System.Drawing.Color.Black;
		this.txtAge4.Location = new System.Drawing.Point(170, 112);
		this.txtAge4.MaxLength = 3;
		this.txtAge4.Name = "txtAge4";
		this.txtAge4.Size = new System.Drawing.Size(32, 20);
		this.txtAge4.TabIndex = 56;
		this.txtAge4.Enter += new System.EventHandler(txtName1_Enter);
		this.txtAge4.Leave += new System.EventHandler(txtAge1_Leave);
		this.chkBd3.AutoSize = true;
		this.chkBd3.BackColor = System.Drawing.Color.White;
		this.chkBd3.ForeColor = System.Drawing.Color.Black;
		this.chkBd3.Location = new System.Drawing.Point(607, 90);
		this.chkBd3.Name = "chkBd3";
		this.chkBd3.Size = new System.Drawing.Size(15, 14);
		this.chkBd3.TabIndex = 54;
		this.chkBd3.UseVisualStyleBackColor = false;
		this.chkBd3.CheckedChanged += new System.EventHandler(chk1_CheckedChanged);
		this.txtName4.BackColor = System.Drawing.Color.White;
		this.txtName4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.txtName4.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtName4.ForeColor = System.Drawing.Color.Black;
		this.txtName4.Location = new System.Drawing.Point(29, 112);
		this.txtName4.MaxLength = 16;
		this.txtName4.Name = "txtName4";
		this.txtName4.Size = new System.Drawing.Size(134, 20);
		this.txtName4.TabIndex = 55;
		this.txtName4.TextChanged += new System.EventHandler(PS_Name_TextChanged);
		this.txtName4.Enter += new System.EventHandler(txtName1_Enter);
		this.txtName4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(TextOnly_KeyPress);
		this.txtName4.Leave += new System.EventHandler(txtName1_Leave);
		this.cboBerth3.BackColor = System.Drawing.Color.White;
		this.cboBerth3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboBerth3.Font = new System.Drawing.Font("Arial", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboBerth3.ForeColor = System.Drawing.Color.Black;
		this.cboBerth3.FormattingEnabled = true;
		this.cboBerth3.Items.AddRange(new object[1] { "Choose Berth" });
		this.cboBerth3.Location = new System.Drawing.Point(255, 87);
		this.cboBerth3.Name = "cboBerth3";
		this.cboBerth3.Size = new System.Drawing.Size(71, 19);
		this.cboBerth3.TabIndex = 48;
		this.cboSex3.BackColor = System.Drawing.Color.White;
		this.cboSex3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboSex3.Font = new System.Drawing.Font("Arial", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboSex3.ForeColor = System.Drawing.Color.Black;
		this.cboSex3.FormattingEnabled = true;
		this.cboSex3.Items.AddRange(new object[3] { "Select", "M", "F" });
		this.cboSex3.Location = new System.Drawing.Point(207, 88);
		this.cboSex3.Name = "cboSex3";
		this.cboSex3.Size = new System.Drawing.Size(42, 19);
		this.cboSex3.TabIndex = 47;
		this.cboSex3.Leave += new System.EventHandler(B2AAA);
		this.txtAge3.BackColor = System.Drawing.Color.White;
		this.txtAge3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.txtAge3.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtAge3.ForeColor = System.Drawing.Color.Black;
		this.txtAge3.Location = new System.Drawing.Point(170, 88);
		this.txtAge3.MaxLength = 3;
		this.txtAge3.Name = "txtAge3";
		this.txtAge3.Size = new System.Drawing.Size(32, 20);
		this.txtAge3.TabIndex = 46;
		this.txtAge3.Enter += new System.EventHandler(txtName1_Enter);
		this.txtAge3.Leave += new System.EventHandler(txtAge1_Leave);
		this.chkBd2.AutoSize = true;
		this.chkBd2.BackColor = System.Drawing.Color.White;
		this.chkBd2.ForeColor = System.Drawing.Color.Black;
		this.chkBd2.Location = new System.Drawing.Point(607, 66);
		this.chkBd2.Name = "chkBd2";
		this.chkBd2.Size = new System.Drawing.Size(15, 14);
		this.chkBd2.TabIndex = 44;
		this.chkBd2.UseVisualStyleBackColor = false;
		this.chkBd2.CheckedChanged += new System.EventHandler(chk1_CheckedChanged);
		this.txtName3.BackColor = System.Drawing.Color.White;
		this.txtName3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.txtName3.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtName3.ForeColor = System.Drawing.Color.Black;
		this.txtName3.Location = new System.Drawing.Point(29, 88);
		this.txtName3.MaxLength = 16;
		this.txtName3.Name = "txtName3";
		this.txtName3.Size = new System.Drawing.Size(134, 20);
		this.txtName3.TabIndex = 45;
		this.txtName3.TextChanged += new System.EventHandler(PS_Name_TextChanged);
		this.txtName3.Enter += new System.EventHandler(txtName1_Enter);
		this.txtName3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(TextOnly_KeyPress);
		this.txtName3.Leave += new System.EventHandler(txtName1_Leave);
		this.cboBerth2.BackColor = System.Drawing.Color.White;
		this.cboBerth2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboBerth2.Font = new System.Drawing.Font("Arial", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboBerth2.ForeColor = System.Drawing.Color.Black;
		this.cboBerth2.FormattingEnabled = true;
		this.cboBerth2.Items.AddRange(new object[1] { "Choose Berth" });
		this.cboBerth2.Location = new System.Drawing.Point(255, 63);
		this.cboBerth2.Name = "cboBerth2";
		this.cboBerth2.Size = new System.Drawing.Size(71, 19);
		this.cboBerth2.TabIndex = 38;
		this.cboSex2.BackColor = System.Drawing.Color.White;
		this.cboSex2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboSex2.Font = new System.Drawing.Font("Arial", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboSex2.ForeColor = System.Drawing.Color.Black;
		this.cboSex2.FormattingEnabled = true;
		this.cboSex2.Items.AddRange(new object[3] { "Select", "M", "F" });
		this.cboSex2.Location = new System.Drawing.Point(207, 64);
		this.cboSex2.Name = "cboSex2";
		this.cboSex2.Size = new System.Drawing.Size(42, 19);
		this.cboSex2.TabIndex = 37;
		this.cboSex2.Leave += new System.EventHandler(cboSex2_Leave);
		this.txtAge2.BackColor = System.Drawing.Color.White;
		this.txtAge2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.txtAge2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtAge2.ForeColor = System.Drawing.Color.Black;
		this.txtAge2.Location = new System.Drawing.Point(170, 64);
		this.txtAge2.MaxLength = 3;
		this.txtAge2.Name = "txtAge2";
		this.txtAge2.Size = new System.Drawing.Size(32, 20);
		this.txtAge2.TabIndex = 36;
		this.txtAge2.Enter += new System.EventHandler(txtName1_Enter);
		this.txtAge2.Leave += new System.EventHandler(txtAge1_Leave);
		this.chkBd1.AutoSize = true;
		this.chkBd1.BackColor = System.Drawing.Color.White;
		this.chkBd1.ForeColor = System.Drawing.Color.Black;
		this.chkBd1.Location = new System.Drawing.Point(607, 42);
		this.chkBd1.Name = "chkBd1";
		this.chkBd1.Size = new System.Drawing.Size(15, 14);
		this.chkBd1.TabIndex = 34;
		this.chkBd1.Tag = "";
		this.chkBd1.UseVisualStyleBackColor = false;
		this.chkBd1.CheckedChanged += new System.EventHandler(chk1_CheckedChanged);
		this.txtName2.BackColor = System.Drawing.Color.White;
		this.txtName2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.txtName2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtName2.ForeColor = System.Drawing.Color.Black;
		this.txtName2.Location = new System.Drawing.Point(29, 64);
		this.txtName2.MaxLength = 16;
		this.txtName2.Name = "txtName2";
		this.txtName2.Size = new System.Drawing.Size(134, 20);
		this.txtName2.TabIndex = 35;
		this.txtName2.TextChanged += new System.EventHandler(PS_Name_TextChanged);
		this.txtName2.Enter += new System.EventHandler(txtName1_Enter);
		this.txtName2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(TextOnly_KeyPress);
		this.txtName2.Leave += new System.EventHandler(txtName1_Leave);
		this.cboBerth1.BackColor = System.Drawing.Color.White;
		this.cboBerth1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboBerth1.Font = new System.Drawing.Font("Arial", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboBerth1.ForeColor = System.Drawing.Color.Black;
		this.cboBerth1.FormattingEnabled = true;
		this.cboBerth1.Items.AddRange(new object[1] { "Choose Berth" });
		this.cboBerth1.Location = new System.Drawing.Point(255, 39);
		this.cboBerth1.Name = "cboBerth1";
		this.cboBerth1.Size = new System.Drawing.Size(71, 19);
		this.cboBerth1.TabIndex = 28;
		this.cboSex1.BackColor = System.Drawing.Color.White;
		this.cboSex1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboSex1.Font = new System.Drawing.Font("Arial", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboSex1.ForeColor = System.Drawing.Color.Black;
		this.cboSex1.FormattingEnabled = true;
		this.cboSex1.Items.AddRange(new object[3] { "Select", "M", "F" });
		this.cboSex1.Location = new System.Drawing.Point(207, 40);
		this.cboSex1.Name = "cboSex1";
		this.cboSex1.Size = new System.Drawing.Size(42, 19);
		this.cboSex1.TabIndex = 27;
		this.cboSex1.Leave += new System.EventHandler(cboSex1_Leave);
		this.txtAge1.BackColor = System.Drawing.Color.White;
		this.txtAge1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.txtAge1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtAge1.ForeColor = System.Drawing.Color.Black;
		this.txtAge1.Location = new System.Drawing.Point(170, 40);
		this.txtAge1.MaxLength = 3;
		this.txtAge1.Name = "txtAge1";
		this.txtAge1.Size = new System.Drawing.Size(32, 20);
		this.txtAge1.TabIndex = 26;
		this.txtAge1.Enter += new System.EventHandler(txtName1_Enter);
		this.txtAge1.Leave += new System.EventHandler(txtAge1_Leave);
		this.txtName1.BackColor = System.Drawing.Color.White;
		this.txtName1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
		this.txtName1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtName1.ForeColor = System.Drawing.Color.Black;
		this.txtName1.Location = new System.Drawing.Point(29, 40);
		this.txtName1.MaxLength = 16;
		this.txtName1.Name = "txtName1";
		this.txtName1.Size = new System.Drawing.Size(134, 20);
		this.txtName1.TabIndex = 25;
		this.txtName1.TextChanged += new System.EventHandler(txtName1_TextChanged);
		this.txtName1.Enter += new System.EventHandler(txtName1_Enter);
		this.txtName1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(TextOnly_KeyPress);
		this.txtName1.Leave += new System.EventHandler(txtName1_Leave);
		this.panel2.BackColor = System.Drawing.Color.FromArgb(204, 204, 204);
		this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.panel2.ForeColor = System.Drawing.Color.Black;
		this.panel2.Location = new System.Drawing.Point(11, 31);
		this.panel2.Name = "panel2";
		this.panel2.Size = new System.Drawing.Size(608, 2);
		this.panel2.TabIndex = 9;
		this.label21.AutoSize = true;
		this.label21.Font = new System.Drawing.Font("Palatino Linotype", 9f, System.Drawing.FontStyle.Bold);
		this.label21.ForeColor = System.Drawing.Color.Black;
		this.label21.Location = new System.Drawing.Point(10, 67);
		this.label21.Name = "label21";
		this.label21.Size = new System.Drawing.Size(14, 17);
		this.label21.TabIndex = 19;
		this.label21.Text = "2";
		this.label20.AutoSize = true;
		this.label20.Font = new System.Drawing.Font("Palatino Linotype", 9f, System.Drawing.FontStyle.Bold);
		this.label20.ForeColor = System.Drawing.Color.Black;
		this.label20.Location = new System.Drawing.Point(10, 91);
		this.label20.Name = "label20";
		this.label20.Size = new System.Drawing.Size(14, 17);
		this.label20.TabIndex = 28;
		this.label20.Text = "3";
		this.label19.AutoSize = true;
		this.label19.Font = new System.Drawing.Font("Palatino Linotype", 9f, System.Drawing.FontStyle.Bold);
		this.label19.ForeColor = System.Drawing.Color.Black;
		this.label19.Location = new System.Drawing.Point(10, 115);
		this.label19.Name = "label19";
		this.label19.Size = new System.Drawing.Size(14, 17);
		this.label19.TabIndex = 37;
		this.label19.Text = "4";
		this.label18.AutoSize = true;
		this.label18.Font = new System.Drawing.Font("Palatino Linotype", 9f, System.Drawing.FontStyle.Bold);
		this.label18.ForeColor = System.Drawing.Color.Black;
		this.label18.Location = new System.Drawing.Point(10, 139);
		this.label18.Name = "label18";
		this.label18.Size = new System.Drawing.Size(14, 17);
		this.label18.TabIndex = 46;
		this.label18.Text = "5";
		this.label17.AutoSize = true;
		this.label17.Font = new System.Drawing.Font("Palatino Linotype", 9f, System.Drawing.FontStyle.Bold);
		this.label17.ForeColor = System.Drawing.Color.Black;
		this.label17.Location = new System.Drawing.Point(10, 163);
		this.label17.Name = "label17";
		this.label17.Size = new System.Drawing.Size(14, 17);
		this.label17.TabIndex = 55;
		this.label17.Text = "6";
		this.label8.AutoSize = true;
		this.label8.Font = new System.Drawing.Font("Palatino Linotype", 9f, System.Drawing.FontStyle.Bold);
		this.label8.ForeColor = System.Drawing.Color.Black;
		this.label8.Location = new System.Drawing.Point(10, 43);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(14, 17);
		this.label8.TabIndex = 10;
		this.label8.Text = "1";
		this.label15.AutoSize = true;
		this.label15.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label15.ForeColor = System.Drawing.Color.Black;
		this.label15.Location = new System.Drawing.Point(77, 15);
		this.label15.Name = "label15";
		this.label15.Size = new System.Drawing.Size(38, 14);
		this.label15.TabIndex = 1;
		this.label15.Text = "Name";
		this.label14.AutoSize = true;
		this.label14.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label14.ForeColor = System.Drawing.Color.Black;
		this.label14.Location = new System.Drawing.Point(170, 15);
		this.label14.Name = "label14";
		this.label14.Size = new System.Drawing.Size(29, 14);
		this.label14.TabIndex = 2;
		this.label14.Text = "Age";
		this.label13.AutoSize = true;
		this.label13.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label13.ForeColor = System.Drawing.Color.Black;
		this.label13.Location = new System.Drawing.Point(207, 15);
		this.label13.Name = "label13";
		this.label13.Size = new System.Drawing.Size(27, 14);
		this.label13.TabIndex = 3;
		this.label13.Text = "Sex";
		this.B7AAA.AutoSize = true;
		this.B7AAA.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.B7AAA.ForeColor = System.Drawing.Color.Black;
		this.B7AAA.Location = new System.Drawing.Point(255, 15);
		this.B7AAA.Name = "B7AAA";
		this.B7AAA.Size = new System.Drawing.Size(37, 14);
		this.B7AAA.TabIndex = 4;
		this.B7AAA.Text = "Berth";
		this.label7.AutoSize = true;
		this.label7.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label7.ForeColor = System.Drawing.Color.Black;
		this.label7.Location = new System.Drawing.Point(7, 15);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(28, 14);
		this.label7.TabIndex = 150;
		this.label7.Tag = "SNo";
		this.label7.Text = "SNo";
		this.pnlHeader.BackColor = System.Drawing.Color.MediumSlateBlue;
		this.pnlHeader.Controls.Add(this.btnClose);
		this.pnlHeader.Controls.Add(this.label50);
		this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
		this.pnlHeader.ForeColor = System.Drawing.Color.FromArgb(17, 17, 18);
		this.pnlHeader.Location = new System.Drawing.Point(0, 0);
		this.pnlHeader.Name = "pnlHeader";
		this.pnlHeader.Size = new System.Drawing.Size(644, 23);
		this.pnlHeader.TabIndex = 1209;
		this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnClose.BackColor = System.Drawing.Color.Transparent;
		this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.btnClose.Image = (System.Drawing.Image)resources.GetObject("btnClose.Image");
		this.btnClose.ImageActive = null;
		this.btnClose.Location = new System.Drawing.Point(620, 0);
		this.btnClose.Name = "btnClose";
		this.btnClose.Size = new System.Drawing.Size(21, 21);
		this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.btnClose.TabIndex = 1;
		this.btnClose.TabStop = false;
		this.btnClose.Zoom = 10;
		this.btnClose.Click += new System.EventHandler(C3AA0);
		this.label50.AutoSize = true;
		this.label50.BackColor = System.Drawing.Color.Transparent;
		this.label50.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label50.Location = new System.Drawing.Point(6, 1);
		this.label50.Name = "label50";
		this.label50.Size = new System.Drawing.Size(86, 20);
		this.label50.TabIndex = 0;
		this.label50.Text = "New Ticket";
		base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.BackColor = System.Drawing.Color.SeaShell;
		this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		base.ClientSize = new System.Drawing.Size(644, 432);
		base.Controls.Add(this.panel4);
		base.Controls.Add(this.pnlHeader);
		base.Controls.Add(this.label28);
		base.Controls.Add(this.Panel1);
		base.Controls.Add(this.CGAA0);
		base.Controls.Add(this.setf);
		base.Controls.Add(this.grpPay);
		base.Controls.Add(this.chkInsurance);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "frmAddTkt";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		base.Load += new System.EventHandler(frmAddTkt_Load);
		this.grpPay.ResumeLayout(false);
		this.grpPay.PerformLayout();
		this.Panel1.ResumeLayout(false);
		this.Panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.picBrd).EndInit();
		this.panel11.ResumeLayout(false);
		this.panel11.PerformLayout();
		this.panel4.ResumeLayout(false);
		this.panel4.PerformLayout();
		this.panel5.ResumeLayout(false);
		this.panel5.PerformLayout();
		this.CGAA0.ResumeLayout(false);
		this.CGAA0.PerformLayout();
		this.BFAAA.ResumeLayout(false);
		this.BFAAA.PerformLayout();
		this.pnlHeader.ResumeLayout(false);
		this.pnlHeader.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.btnClose).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
