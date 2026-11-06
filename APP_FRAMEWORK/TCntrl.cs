using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Booking;
using Newtonsoft.Json;
using NEXUS;

namespace APP_FRAMEWORK;

internal class TCntrl : UserControl
{
	private delegate void ChangeTextsSafe(string length);

	public string[,] Traindata = new string[51, 12];

	public int x;

	public int y;

	public Size PairSize;

	public Size lblGatewaySize;

	public Size Panel1Size;

	public Size baseSize;

	public Point A;

	public Point B;

	public Point C;

	public Point D;

	public Point E;

	public Point F;

	public Point G;

	public Point H;

	private string string_1;

	public static bool isok;

	private EventHandler eventHandler_0;

	private EventHandler eventHandler_1;

	private EventHandler eventHandler_2;

	private EventHandler eventHandler_3;

	private EventHandler B2AAA;

	internal Class48 class48_0;

	internal string string_0;

	internal string LoginSite;

	internal string fare_str;

	internal string Actualfare;

	internal bool bool_0;

	internal bool LoginProceed;

	internal int int_1;

	internal int int_2;

	internal int WindoNo;

	internal int int_3;

	internal int TrDayDiff;

	internal long ftime;

	internal long long_3;

	private static List<string> C2AA0 = new List<string>();

	private static object object_0 = new object();

	private string string_2;

	internal bool bool_1;

	private Container container_0;

	internal Label lblJourney;

	private Panel TopPanel;

	internal ComboBox cboID;

	internal ComboBox cboSlot;

	internal Button btnEdit;

	internal Button BtnOpenPair;

	internal ComboBox cboGateway;

	internal CheckBox chkConfirmation;

	internal ComboBox cboQuota;

	public System.Windows.Forms.Timer timer_0;

	private ToolTip toolTip_0;

	private IContainer icontainer_0;

	internal Label lblStatus;

	internal Label lblClass;

	public Label lblTktName;

	internal ComboBox cboTrain;

	private Panel HeaderPanel1;

	internal bool IsOpenningTicket;

	public Button btnCancel;

	private Panel B3AAA;

	private Label lbl_Month;

	private Label lbl_Date;

	private LinkLabel WLlinkLabel;

	public Panel PanelPnr;

	public Panel Panel1;

	internal Label label5;

	internal Label lbl_Detail;

	internal Label lbl_status;

	internal Label lbl_slot;

	public Label lblAvailability;

	public LinkLabel EditlinkLabel;

	public Label lblTime;

	public Label lblPnr;

	public Label label13;

	public Label label11;

	internal Label lblDate;

	internal ComboBox cboClass;

	private Panel panel2;

	public Label lblInfo;

	public bool GNBooking;

	public bool ACBooking;

	public bool SLBooking;

	public bool bool_ISADVV;

	internal bool ChkAutoLogin;

	internal bool MicroWindow;

	internal Button AppLogin_;

	internal bool Applogin;

	internal bool mixlogin;

	internal bool web3;

	internal bool Dishalogin;

	internal bool Betalogin;

	internal int loginType;

	internal bool WithCapchtaInputlogin;

	internal bool WithOtpInputlogin;

	internal bool autologin;

	public Button btnSlotNo;

	public Button btnMinize;

	private Panel Panel5;

	internal Label lblTrainNo;

	internal Panel BottomPanel;

	private System.Windows.Forms.Timer timer_1;

	private IContainer components;

	private Label lbl_brand;

	public Button WebLogin;

	internal Button button1;

	internal CheckBox check_avl;

	private PictureBox pictureBox2;

	internal Label lbl_time;

	private Label lbl_bnk;

	private bool blb;

	private Label lblBrand;

	internal Button btnDish;

	private string CLc;

	internal Button btnWeb3;

	internal Panel pnlBrand;

	internal Label lblBank;

	internal Label lblLoginType;

	internal ComboBox fake_bank;

	internal ComboBox fake_id;

	private ToolTip toolTip1;

	internal Button button2;

	private string eWallet_irctc;

	internal event EventHandler Event_0
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			eventHandler_0 = (EventHandler)Delegate.Combine(eventHandler_0, value);
		}
		remove
		{
			eventHandler_0 = (EventHandler)Delegate.Remove(eventHandler_0, (EventHandler)Delegate.Combine(eventHandler_0, value));
		}
	}

	internal event EventHandler Event_1
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			eventHandler_1 = (EventHandler)Delegate.Combine(eventHandler_1, value);
		}
		remove
		{
			eventHandler_1 = (EventHandler)Delegate.Remove(eventHandler_1, (EventHandler)Delegate.Combine(eventHandler_1, value));
		}
	}

	internal event EventHandler Event_2
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			eventHandler_2 = (EventHandler)Delegate.Combine(eventHandler_2, value);
		}
		remove
		{
			eventHandler_2 = (EventHandler)Delegate.Remove(eventHandler_2, (EventHandler)Delegate.Combine(eventHandler_2, value));
		}
	}

	internal event EventHandler Event_3
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			eventHandler_3 = (EventHandler)Delegate.Combine(eventHandler_3, value);
		}
		remove
		{
			eventHandler_3 = (EventHandler)Delegate.Remove(eventHandler_3, (EventHandler)Delegate.Combine(eventHandler_3, value));
		}
	}

	internal event EventHandler Event_4
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			B2AAA = (EventHandler)Delegate.Combine(B2AAA, value);
		}
		remove
		{
			B2AAA = (EventHandler)Delegate.Remove(B2AAA, (EventHandler)Delegate.Combine(B2AAA, value));
		}
	}

	public TCntrl()
	{
		string_0 = "";
		string_2 = "";
		InitializeComponent();
		A = cboID.Location;
		B = cboSlot.Location;
		C = cboQuota.Location;
		D = cboTrain.Location;
		E = HeaderPanel1.Location;
		F = cboGateway.Location;
		G = chkConfirmation.Location;
		_ = base.Width;
		_ = base.Height;
		_ = Screen.PrimaryScreen.WorkingArea.Width;
		_ = Screen.PrimaryScreen.WorkingArea.Height;
		x = Screen.PrimaryScreen.WorkingArea.Width - 1366;
		y = Screen.PrimaryScreen.WorkingArea.Height - 768;
		y = Screen.PrimaryScreen.WorkingArea.Height - 728;
		MicroWindow = StatClass.MicroWindow;
		string text = "Ready";
		StatusChange(0, text);
		cboGateway.Items.Clear();
		ComboBox.ObjectCollection items = cboGateway.Items;
		string item = "Select-Bank-XXXX";
		items.Add(item);
		Program.dictionary_00.Clear();
		DataTable dataTable = new DataTable();
		string commandText = "SELECT BANK_SAVEAS, BANK_DETAILS from TBL_BANK";
		new SQLiteDataAdapter(commandText, Class34.string_Database).Fill(dataTable);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			foreach (DataRow row in dataTable.Rows)
			{
				string key = row[0].ToString();
				string value = row[1].ToString();
				Program.dictionary_00.Add(key, value);
			}
		}
		foreach (string key2 in Program.dictionary_00.Keys)
		{
			cboGateway.Items.Add(key2);
		}
		cboGateway.SelectedIndex = 0;
		cboID.Items.Clear();
		ComboBox.ObjectCollection items2 = cboID.Items;
		string item2 = "Select-ID-XXXX";
		items2.Add(item2);
		foreach (string key3 in Program.dictionary_0.Keys)
		{
			cboID.Items.Add(key3);
		}
		cboID.SelectedIndex = 0;
		cboSlot.Items.Clear();
		ComboBox.ObjectCollection items3 = cboSlot.Items;
		string item3 = "Select-Slot-XXXX";
		items3.Add(item3);
		for (int i = 1; i <= Program.int_Slot; i++)
		{
			ComboBox.ObjectCollection items4 = cboSlot.Items;
			string text2 = "Slot-";
			items4.Add(text2 + i);
		}
		string loginSite = "1";
		LoginSite = loginSite;
		cboSlot.SelectedIndex = 0;
		PairSize = BtnOpenPair.Size;
		lblGatewaySize = cboGateway.Size;
		Panel1Size = Panel1.Size;
		baseSize = base.Size;
	}

	internal TCntrl(Class48 class48_1)
		: this()
	{
		method_0(class48_1);
	}

	public void TCntrll()
	{
		if (Class45.ManagerDashborad)
		{
			if (MicroWindow)
			{
				method_2();
				MicroWindow = false;
			}
			else
			{
				method_3();
				MicroWindow = true;
			}
		}
		else if (!StatClass.MicroWindow)
		{
			method_3();
			MicroWindow = true;
		}
		else
		{
			method_2();
			MicroWindow = false;
		}
		if (bool_1)
		{
			btnEdit.Visible = false;
			EditlinkLabel.Visible = false;
			BtnOpenPair.Visible = false;
		}
	}

	internal void method_0(Class48 class48_1)
	{
		try
		{
			class48_0 = class48_1;
			DateTime dateTime = new DateTime(int.Parse(class48_1.string_6), int.Parse(class48_1.string_5), int.Parse(class48_1.string_4));
			if (class48_1.string_0 == class48_1.string_3)
			{
				Label label = lblJourney;
				string text = class48_1.string_0;
				string text2 = "-";
				label.Text = text + text2 + class48_1.string_1;
			}
			else
			{
				Label label2 = lblJourney;
				string[] array = new string[5] { class48_1.string_0, null, null, null, null };
				string text3 = "-";
				array[1] = text3;
				array[2] = class48_1.string_3;
				string text4 = "-";
				array[3] = text4;
				array[4] = class48_1.string_1;
				label2.Text = string.Concat(array);
			}
			Label label3 = lblDate;
			string text5 = "dd/MM";
			label3.Text = dateTime.ToString(text5);
			lblClass.Text = class48_1.string_7;
			cboClass.Text = class48_1.string_7;
			string_1 = class48_1.string_12;
			cboQuota.SelectedItem = class48_1.string_8;
			cboTrain.SelectedItem = class48_1.string_2;
			cboGateway.SelectedItem = class48_1.string_23;
			lblTrainNo.Text = class48_1.string_2;
			foreach (KeyValuePair<string, string> item in Program.list_SelectedIRCTCid)
			{
				string value = item.Value;
				string text6 = "free";
				if (value == text6)
				{
					cboID.SelectedItem = item.Key;
					Dictionary<string, string> list_SelectedIRCTCid = Program.list_SelectedIRCTCid;
					string key = item.Key;
					string value2 = "busy";
					list_SelectedIRCTCid[key] = value2;
					break;
				}
			}
			IsOpenningTicket = class48_1.bool_8;
			string string_ = class48_1.string_25;
			string[] array2 = new string[1];
			string text7 = "|";
			array2[0] = text7;
			string[] array3 = string_.Split(array2, StringSplitOptions.RemoveEmptyEntries);
			if (class48_1.bool_6)
			{
				chkConfirmation.Checked = true;
			}
			fare_str = array3[0].Trim();
			Actualfare = array3[0].Trim();
			Label label4 = lblAvailability;
			string text8 = label4.Text;
			string text9 = "|";
			label4.Text = text8 + text9 + fare_str;
			string string_2 = class48_1.string_8;
			string text10 = "PT";
			if (string_2 == text10)
			{
				int_2 = int.Parse(array3[0].Trim());
			}
			Class34.list_0.Contains(class48_1.string_2);
			ToolTip toolTip = toolTip_0;
			string text11 = "Ticket: ";
			toolTip.ToolTipTitle = text11 + class48_1.string_12;
			if (class48_1.bool_3)
			{
				LinkLabel wLlinkLabel = WLlinkLabel;
				string text12 = "WL Stop";
				wLlinkLabel.Text = text12;
				WLlinkLabel.VisitedLinkColor = Color.Red;
			}
			else
			{
				LinkLabel wLlinkLabel2 = WLlinkLabel;
				string text13 = "WL Allow";
				wLlinkLabel2.Text = text13;
				WLlinkLabel.VisitedLinkColor = Color.Blue;
			}
			if (!StatClass.MicroWindow)
			{
				method_2();
			}
			else
			{
				method_3();
			}
			Label label5 = lbl_Detail;
			string text14 = "DEOS --> NDLS 15:30-06:45";
			label5.Text = text14;
			Label label6 = lbl_Detail;
			string[] array4 = new string[10];
			string text15 = "Train: ";
			array4[0] = text15;
			array4[1] = class48_1.string_2;
			string text16 = "\r\nQuota: ";
			array4[2] = text16;
			array4[3] = class48_1.string_8;
			string text17 = "\r\nClass: ";
			array4[4] = text17;
			array4[5] = class48_1.string_7;
			string text18 = "\r\nSrc: ";
			array4[6] = text18;
			array4[7] = class48_1.string_0;
			string text19 = "\r\nDest: ";
			array4[8] = text19;
			array4[9] = class48_1.string_1;
			label6.Text = string.Concat(array4);
			Label label7 = this.label5;
			string text20 = "VAISHALI EXP (18201)";
			label7.Text = text20;
			Label label8 = this.label5;
			string text21 = "Exp Train: (";
			string text22 = class48_1.string_2;
			string text23 = ")_";
			label8.Text = text21 + text22 + text23;
			Label label9 = lbl_Date;
			string text24 = "dd";
			label9.Text = dateTime.ToString(text24);
			Label label10 = lbl_Month;
			string text25 = "MMM yyyy";
			label10.Text = dateTime.ToString(text25);
			Label label11 = lbl_slot;
			string text26 = "SLOT - ";
			label11.Text = text26 + (cboSlot.SelectedIndex + 1);
			lbl_bnk.Text = GetBankName(cboGateway.SelectedItem.ToString());
			Label label12 = lblStatus;
			string text27 = "Ready-{ Bkg Fare Limit: ";
			string text28 = fare_str;
			string text29 = " } ";
			label12.Text = text27 + text28 + text29;
			Refresh();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private string GetBankName(string str)
	{
		string result = "";
		try
		{
			string value = "_";
			if (str.Contains(value))
			{
				string value2 = "_";
				string text = str.Substring(str.IndexOf(value2) + 1).Trim();
				string value3 = "_";
				string text2 = str.Substring(0, str.IndexOf(value3)).Trim();
				string text3 = text;
				string value4 = "__";
				if (text3.Contains(value4))
				{
					string text4 = text2;
					string text5 = "_";
					string text6 = text;
					string text7 = text;
					string value5 = "__";
					text2 = text4 + text5 + text6.Substring(0, text7.IndexOf(value5)).Trim();
					string text8 = text;
					string text9 = text;
					string value6 = "__";
					text = text8.Substring(text9.IndexOf(value6) + 2).Trim();
					string text10 = text;
					string value7 = "_";
					if (text10.Contains(value7))
					{
						string text11 = text2;
						string text12 = "__";
						string text13 = text;
						string text14 = text;
						string value8 = "_";
						text2 = text11 + text12 + text13.Substring(0, text14.IndexOf(value8)).Trim();
						result = text2;
						return result;
					}
					return result;
				}
				string text15 = text;
				string value9 = "_";
				if (!text15.Contains(value9))
				{
					result = text2;
					return result;
				}
				string text16 = text2;
				string text17 = "_";
				string text18 = text;
				string text19 = text;
				string value10 = "_";
				text2 = text16 + text17 + text18.Substring(0, text19.IndexOf(value10)).Trim();
				result = text2;
				return result;
			}
			return result;
		}
		catch
		{
			return result;
		}
	}

	private void method_2()
	{
		cboSlot.Visible = true;
		cboID.Location = A;
		cboSlot.Location = B;
		cboQuota.Location = C;
		cboTrain.Location = D;
		HeaderPanel1.Location = E;
		cboGateway.Size = lblGatewaySize;
		Panel1.Size = Panel1Size;
		base.Size = baseSize;
		_ = class48_0.string_0 == class48_0.string_3;
		Label label = lblJourney;
		string text = class48_0.string_0;
		string text2 = "_";
		label.Text = text + text2 + class48_0.string_1;
	}

	private void method_3()
	{
		Panel1.Size = new Size(Panel1.Width, cboTrain.Height + 5);
		HeaderPanel1.Location = new Point(E.X, Panel1.Location.Y + Panel1.Size.Height + 1);
		_ = HeaderPanel1.Location;
		_ = HeaderPanel1.Size;
		base.Size = new Size(base.Width, TopPanel.Height + Panel1.Height + HeaderPanel1.Height + cboGateway.Height + BottomPanel.Height + 3);
		_ = class48_0.string_0 == class48_0.string_3;
		Label label = lblJourney;
		string text = class48_0.string_0;
		string text2 = "_";
		label.Text = text + text2 + class48_0.string_1;
	}

	internal void StatusChange(int int_4, string string_2)
	{
		try
		{
			if (int_4 != 900)
			{
				switch (int_4)
				{
				case 999:
				{
					string text7 = string_2;
					string value2 = "AVAILABLE";
					if (text7.Contains(value2))
					{
						string text8 = string_2;
						string oldValue2 = "AVAILABLE";
						string newValue2 = "AVL";
						string_2 = text8.Replace(oldValue2, newValue2);
					}
					string text9 = string_2;
					string[] array3 = new string[1];
					string text10 = "$";
					array3[0] = text10;
					string[] array4 = text9.Split(array3, StringSplitOptions.RemoveEmptyEntries);
					string_2 = array4[0].Trim();
					Label label2 = lblAvailability;
					string text11 = array4[2].Trim();
					string text12 = " |  ";
					label2.Text = text11 + text12 + array4[1].Trim();
					lblInfo.Text = lblAvailability.Text;
					break;
				}
				case 959:
				{
					string text = string_2;
					string value = "AVAILABLE";
					if (text.Contains(value))
					{
						string text2 = string_2;
						string oldValue = "AVAILABLE";
						string newValue = "AVL";
						string_2 = text2.Replace(oldValue, newValue);
					}
					string text3 = string_2;
					string[] array = new string[1];
					string text4 = "$";
					array[0] = text4;
					string[] array2 = text3.Split(array, StringSplitOptions.None);
					string_2 = array2[0].Trim();
					Label label = lblAvailability;
					string text5 = array2[1].Trim();
					string text6 = " |  ";
					label.Text = text5 + text6 + fare_str;
					lblInfo.Text = lblAvailability.Text;
					break;
				}
				}
				if (int_4 > 200)
				{
					if (int_4 == 202)
					{
						timer_1.Enabled = true;
					}
					if (int_4 == 203)
					{
						timer_1.Enabled = false;
					}
					if (int_4 == 204)
					{
						timer_1.Enabled = false;
					}
					if (int_4 == 253)
					{
						cboGateway.Enabled = true;
					}
				}
				else if (int_4 == 5)
				{
					lblBrand.Location = new Point(56, 39);
					cboID.Left = 2;
					timer_0.Enabled = false;
					timer_1.Enabled = false;
					string obj = "0";
					CloseAfter(obj);
				}
				if (!string.IsNullOrEmpty(string_2))
				{
					Label label3 = lblStatus;
					string text13 = " ";
					label3.Text = text13 + string_2;
				}
				if ((uint)(int_4 - 2) <= 3u)
				{
					timer_0.Enabled = false;
					timer_1.Enabled = false;
				}
			}
			else
			{
				int_3 = int.Parse(string_2);
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void set_pic(string str)
	{
		try
		{
			string[] array = new string[1];
			string text = "T";
			array[0] = text;
			string[] array2 = str.Split(array, StringSplitOptions.None);
			lbl_time.Text = array2[1];
			BottomPanel.Visible = false;
			pictureBox2.Top = 0;
		}
		catch
		{
		}
	}

	internal void ChnageColour_()
	{
		if (Applogin)
		{
			BackColor = Color.GhostWhite;
			pnlBrand.BackColor = Color.GhostWhite;
			lblBrand.BackColor = Color.GhostWhite;
			lblBank.BackColor = Color.GhostWhite;
			lblLoginType.BackColor = Color.GhostWhite;
			BottomPanel.BackColor = Color.Thistle;
			lblStatus.BackColor = Color.FromArgb(54, 71, 79);
			lblStatus.ForeColor = Color.Yellow;
		}
		else if (web3)
		{
			BackColor = Color.Thistle;
			pnlBrand.BackColor = Color.Thistle;
			lblBrand.BackColor = Color.Thistle;
			lblBank.BackColor = Color.Thistle;
			lblLoginType.BackColor = Color.Thistle;
			BottomPanel.BackColor = Color.Thistle;
			lblStatus.BackColor = Color.FromArgb(54, 71, 79);
			lblStatus.ForeColor = Color.Yellow;
		}
		else
		{
			BackColor = SystemColors.ButtonHighlight;
			pnlBrand.BackColor = SystemColors.ButtonHighlight;
			lblBrand.BackColor = SystemColors.ButtonHighlight;
			lblBank.BackColor = SystemColors.ButtonHighlight;
			lblLoginType.BackColor = SystemColors.ButtonHighlight;
			BottomPanel.BackColor = SystemColors.ButtonHighlight;
			lblStatus.BackColor = Color.FromArgb(12, 78, 66);
			lblStatus.ForeColor = Color.Yellow;
		}
	}

	private void timer_1_Tick(object sender, EventArgs e)
	{
		if (lblStatus.BackColor == Color.Blue)
		{
			lblStatus.BackColor = Color.Yellow;
			lblStatus.ForeColor = Color.Black;
		}
		else
		{
			lblStatus.BackColor = Color.Blue;
			lblStatus.ForeColor = Color.White;
		}
	}

	public void CloseAfter(object obj)
	{
		try
		{
			if (StatClass.CloseOnPnr)
			{
				if (Class45.ManagerDashborad)
				{
					ThreadPool.QueueUserWorkItem(CloseOtherThanPnrBookWindow, null);
					string text = "Nget_PnrFinish-";
					string name = base.Name;
					string text2 = ",";
					string text3 = text2;
					Clipboard.SetText(text + name + text3 + lblTktName);
				}
				else
				{
					ThreadPool.QueueUserWorkItem(CloseOtherThanPnrBookWindow, null);
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void TCntrl_Load_1(object sender, EventArgs e)
	{
		string variable = "S_Window";
		if (Convert.ToBoolean(Environment.GetEnvironmentVariable(variable)))
		{
			base.Height = 60;
			AppLogin_.Top = 36;
			AppLogin_.BringToFront();
			WebLogin.Top = 36;
			WebLogin.BringToFront();
			BottomPanel.BringToFront();
		}
		lbl_time.Parent = pictureBox2;
		lbl_time.BackColor = Color.Transparent;
		lbl_time.Location = new Point(84, 22);
		lbl_status.Parent = pictureBox2;
		lbl_status.BackColor = Color.Transparent;
		lbl_status.Location = new Point(71, 48);
		lbl_brand.Parent = pictureBox2;
		lbl_brand.BackColor = Color.Transparent;
		lbl_brand.Location = new Point(86, 70);
		lbl_bnk.Parent = pictureBox2;
		lbl_bnk.BackColor = Color.Transparent;
		lbl_bnk.Location = new Point(2, 3);
		lbl_Detail.Parent = pictureBox2;
		lbl_Detail.BackColor = Color.Transparent;
		lbl_Detail.Location = new Point(2, 18);
		lbl_slot.Parent = pictureBox2;
		lbl_slot.BackColor = Color.Transparent;
		lbl_slot.Location = new Point(2, 93);
		lbl_Date.Parent = pictureBox2;
		lbl_Date.BackColor = Color.Transparent;
		lbl_Date.Location = new Point(178, 70);
		lbl_Month.Parent = pictureBox2;
		lbl_Month.BackColor = Color.Transparent;
		lbl_Month.Location = new Point(161, 90);
		int_1 = Program.int_4;
		Label label = lblStatus;
		string text = "Ready-{ Bkg Fare Limit: ";
		string text2 = fare_str;
		string text3 = " } ";
		label.Text = text + text2 + text3;
		button2.Text = Program.WEBTEXT;
		AddTRaininCombo();
		cboTrain.SelectedItem = class48_0.string_2;
		if (StatClass.Slot_ > 0)
		{
			cboSlot.SelectedIndex = StatClass.Slot_;
		}
		if (StatClass.BoolIsNgetCust)
		{
			WebLogin.Enabled = true;
		}
		if (StatClass.WebLogin)
		{
			WebLogin.PerformClick();
		}
		if (StatClass.ApptLogin)
		{
			AppLogin_.PerformClick();
		}
	}

	private void WebLogin_Click(object sender, EventArgs e)
	{
		string str = cboGateway.SelectedItem.ToString();
		string app = "WEB";
		if (checkPaymet(str, app))
		{
			Betalogin = true;
			Dishalogin = false;
			Applogin = false;
			loginType = 1;
			Label label = lbl_status;
			string text = "SUCCESS-WEB";
			label.Text = text;
			method_4();
		}
		else
		{
			StatClass.WebLogin = false;
			StatClass.DishaLogin = false;
			string text2 = "Selected Payment Gateway is Not Working\r\nPlease Choose Another Payment Option";
			MessageBox.Show(text2);
		}
	}

	private void AppLogin_Click(object sender, EventArgs e)
	{
		bool flag = false;
		string text = "SensorList.json";
		string path = text;
		if (File.Exists(path))
		{
			new List<string>();
			if ((JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(path)) ?? new List<string>()).Count > 0)
			{
				flag = true;
			}
		}
		if (flag)
		{
			string str = cboGateway.SelectedItem.ToString();
			string app = "APP";
			if (!checkPaymet(str, app))
			{
				StatClass.ApptLogin = false;
				StatClass.DishaLogin = false;
				string text2 = "Selected Payment Gateway is Not Working\r\nPlease Choose Another Payment Option";
				MessageBox.Show(text2);
				return;
			}
			Betalogin = false;
			Dishalogin = false;
			Applogin = true;
			loginType = 2;
			Label label = lbl_status;
			string text3 = "SUCCESS-APP";
			label.Text = text3;
			method_4();
		}
		else
		{
			Form owner = new Form
			{
				TopMost = true
			};
			string text4 = "Sensor Data Not Found! first Check Token";
			string caption = "Hitman";
			MessageBox.Show(owner, text4, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
	}

	private void btnDish_Click(object sender, EventArgs e)
	{
		string str = cboGateway.SelectedItem.ToString();
		string app = "Disha";
		if (checkPaymet(str, app))
		{
			Betalogin = false;
			Applogin = false;
			Dishalogin = true;
			loginType = 3;
			Label label = lbl_status;
			string text = "SUCCESS-Disha";
			label.Text = text;
			method_4();
		}
		else
		{
			StatClass.ApptLogin = false;
			StatClass.WebLogin = false;
			string text2 = "Selected Payment Gateway is Not Working\r\nPlease Choose Another Payment Option";
			MessageBox.Show(text2);
		}
	}

	private void btnWeb3_Click(object sender, EventArgs e)
	{
		string str = cboGateway.SelectedItem.ToString();
		string app = "web3";
		if (!checkPaymet(str, app))
		{
			StatClass.ApptLogin = false;
			StatClass.WebLogin = false;
			string text = "Selected Payment Gateway is Not Working\r\nPlease Choose Another Payment Option";
			MessageBox.Show(text);
			return;
		}
		Betalogin = false;
		Applogin = false;
		Dishalogin = false;
		web3 = true;
		loginType = 4;
		ChnageColour_();
		Label label = lbl_status;
		string text2 = "SUCCESS-APP";
		label.Text = text2;
		method_4();
	}

	private bool checkPaymet(string str, string app)
	{
		if (app == "Mix")
		{
			return true;
		}
		if (app == "APP")
		{
			return true;
		}
		string text = str;
		string[] array = new string[1];
		string text2 = "_";
		array[0] = text2;
		string[] array2 = text.Split(array, StringSplitOptions.None);
		string text3 = array2[1];
		string text4 = "WALLET";
		if (text3 == text4)
		{
			string text5 = cboID.Text;
			if (array2[2] != text5)
			{
				Label label = lblStatus;
				string text6 = "Select Same IRCTC and Wallet";
				label.Text = text6;
				return false;
			}
		}
		str = array2[0];
		if (array2.Length > 2)
		{
			string text7 = array2[0];
			string text8 = "_";
			str = text7 + text8 + array2[1];
		}
		bool result = false;
		try
		{
			string text9 = "APP";
			if (app == text9)
			{
				string text10 = str;
				string text11 = "SBI";
				bool flag = text10 == text11;
				string text12 = str;
				string text13 = "HDFC";
				bool flag2 = flag | (text12 == text13);
				string text14 = str;
				string text15 = "PHONEPE";
				bool flag3 = flag2 | (text14 == text15);
				string text16 = str;
				string text17 = "NPCI";
				bool flag4 = flag3 | (text16 == text17);
				string text18 = str;
				string text19 = "ADVANCE_FAIL";
				bool flag5 = flag4 | (text18 == text19);
				string text20 = str;
				string text21 = "ADVANCE_PAY";
				bool flag6 = flag5 | (text20 == text21);
				string text22 = str;
				string text23 = "FREECHARGE";
				bool flag7 = flag6 | (text22 == text23);
				string text24 = str;
				string text25 = "AUTOPAY_UPI";
				bool flag8 = flag7 | (text24 == text25);
				string text26 = str;
				string text27 = "BHIMUPI";
				bool flag9 = flag8 | (text26 == text27);
				string text28 = str;
				string text29 = "PAYZAP_DC";
				bool flag10 = flag9 | (text28 == text29);
				string text30 = str;
				string text31 = "PAYTM";
				bool flag11 = flag10 | (text30 == text31);
				string text32 = str;
				string text33 = "HDFC_DC";
				bool flag12 = flag11 | (text32 == text33);
				string text34 = str;
				string text35 = "AIRTELMONEY";
				result = flag12 | (text34 == text35);
				string text36 = str;
				string text37 = "NSDL_DC";
				result = flag12 | (text36 == text37);
			}
			else
			{
				string text38 = "WEB";
				if (!(app == text38))
				{
					string text39 = str;
					string text40 = "NSDL_DC";
					bool flag13 = text39 == text40;
					string text41 = str;
					string text42 = "ICICIVERTUAL_DC";
					bool flag14 = flag13 | (text41 == text42);
					string text43 = str;
					string text44 = "PHONEPE-QR";
					bool flag15 = flag14 | (text43 == text44);
					string text45 = str;
					string text46 = "iPay-QR";
					bool flag16 = flag15 | (text45 == text46);
					string text47 = str;
					string text48 = "PayTM-QR";
					bool flag17 = flag16 | (text47 == text48);
					string text49 = str;
					string text50 = "IRCTC_WALLET";
					bool flag18 = flag17 | (text49 == text50);
					string text51 = str;
					string text52 = "SBI";
					bool flag19 = flag18 | (text51 == text52);
					string text53 = str;
					string text54 = "HDFC";
					bool flag20 = flag19 | (text53 == text54);
					string text55 = str;
					string text56 = "IPAYUPI";
					bool flag21 = flag20 | (text55 == text56);
					string text57 = str;
					string text58 = "SBIUPI";
					bool flag22 = flag21 | (text57 == text58);
					string text59 = str;
					string text60 = "PHONEPE";
					bool flag23 = flag22 | (text59 == text60);
					string text61 = str;
					string text62 = "NPCI";
					bool flag24 = flag23 | (text61 == text62);
					string text63 = str;
					string text64 = "ADVANCE_FAIL";
					bool flag25 = flag24 | (text63 == text64);
					string text65 = str;
					string text66 = "ADVANCE_PAY";
					bool flag26 = flag25 | (text65 == text66);
					string text67 = str;
					string text68 = "FREECHARGE";
					bool flag27 = flag26 | (text67 == text68);
					string text69 = str;
					string text70 = "AUTOPAY_UPI";
					bool flag28 = flag27 | (text69 == text70);
					string text71 = str;
					string text72 = "BHIMUPI";
					bool flag29 = flag28 | (text71 == text72);
					string text73 = str;
					string text74 = "PAYZAP_DC";
					bool flag30 = flag29 | (text73 == text74);
					string text75 = str;
					string text76 = "HDFC_DC";
					bool flag31 = flag30 | (text75 == text76);
					string text77 = str;
					string text78 = "PAYTM";
					bool flag32 = flag31 | (text77 == text78);
					string text79 = str;
					string text80 = "AIRTELMONEY";
					result = flag32 | (text79 == text80);
				}
				else
				{
					string text81 = str;
					string text82 = "NSDL_DC";
					bool flag33 = text81 == text82;
					string text83 = str;
					string text84 = "ICICIVERTUAL_DC";
					bool flag34 = flag33 | (text83 == text84);
					string text85 = str;
					string text86 = "PHONEPE-QR";
					bool flag35 = flag34 | (text85 == text86);
					string text87 = str;
					string text88 = "iPay-QR";
					bool flag36 = flag35 | (text87 == text88);
					string text89 = str;
					string text90 = "PayTM-QR";
					bool flag37 = flag36 | (text89 == text90);
					string text91 = str;
					string text92 = "IRCTC_WALLET";
					bool flag38 = flag37 | (text91 == text92);
					string text93 = str;
					string text94 = "SBI";
					bool flag39 = flag38 | (text93 == text94);
					string text95 = str;
					string text96 = "HDFC";
					bool flag40 = flag39 | (text95 == text96);
					string text97 = str;
					string text98 = "IPAYUPI";
					bool flag41 = flag40 | (text97 == text98);
					string text99 = str;
					string text100 = "SBIUPI";
					bool flag42 = flag41 | (text99 == text100);
					string text101 = str;
					string text102 = "PHONEPE";
					bool flag43 = flag42 | (text101 == text102);
					string text103 = str;
					string text104 = "NPCI";
					bool flag44 = flag43 | (text103 == text104);
					string text105 = str;
					string text106 = "ADVANCE_FAIL";
					bool flag45 = flag44 | (text105 == text106);
					string text107 = str;
					string text108 = "ADVANCE_PAY";
					bool flag46 = flag45 | (text107 == text108);
					string text109 = str;
					string text110 = "FREECHARGE";
					bool flag47 = flag46 | (text109 == text110);
					string text111 = str;
					string text112 = "AUTOPAY_UPI";
					bool flag48 = flag47 | (text111 == text112);
					string text113 = str;
					string text114 = "BHIMUPI";
					bool flag49 = flag48 | (text113 == text114);
					string text115 = str;
					string text116 = "PAYZAP_DC";
					bool flag50 = flag49 | (text115 == text116);
					string text117 = str;
					string text118 = "HDFC_DC";
					bool flag51 = flag50 | (text117 == text118);
					string text119 = str;
					string text120 = "PAYTM";
					bool flag52 = flag51 | (text119 == text120);
					string text121 = str;
					string text122 = "AIRTELMONEY";
					result = flag52 | (text121 == text122);
				}
			}
		}
		catch
		{
		}
		return result;
	}

	private void method_4()
	{
		if (Applogin)
		{
			Betalogin = false;
			Applogin = true;
			WithCapchtaInputlogin = true;
			WithOtpInputlogin = false;
		}
		else if (Betalogin)
		{
			Betalogin = true;
			Applogin = false;
			WithCapchtaInputlogin = true;
			WithOtpInputlogin = false;
		}
		else
		{
			Betalogin = false;
			Applogin = false;
			WithCapchtaInputlogin = true;
			WithOtpInputlogin = false;
		}
		lblAvailability.Visible = true;
		method_5();
	}

	private void method_5()
	{
		if (cboSlot.SelectedIndex <= 0)
		{
			cboSlot.SelectedIndex = 1;
		}
		else if (cboID.SelectedIndex <= 0)
		{
			if (StatClass.WebLogin)
			{
				StatClass.WebLogin = false;
			}
			if (StatClass.ApptLogin)
			{
				StatClass.ApptLogin = false;
			}
			string text = "Please select valid IRCTC ID for Booking.";
			string caption = "IRCTC ID";
			MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		else if (cboQuota.SelectedIndex >= 0)
		{
			if (cboGateway.SelectedIndex < 0)
			{
				if (StatClass.WebLogin)
				{
					StatClass.WebLogin = false;
				}
				if (StatClass.ApptLogin)
				{
					StatClass.ApptLogin = false;
				}
				string text2 = "Please select valid Bank for Booking.";
				string caption2 = "Bank";
				MessageBox.Show(text2, caption2, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				bool_0 = Control.ModifierKeys == Keys.Control;
				if (eventHandler_0 != null)
				{
					eventHandler_0(this, null);
				}
			}
		}
		else
		{
			if (StatClass.WebLogin)
			{
				StatClass.WebLogin = false;
			}
			if (StatClass.ApptLogin)
			{
				StatClass.ApptLogin = false;
			}
			string text3 = "Please select valid Quota for Booking.";
			string caption3 = "Quota";
			MessageBox.Show(text3, caption3, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
	}

	private void btnEdit_Click(object sender, EventArgs e)
	{
		string text = btnEdit.Text;
		string text2 = "Info";
		if (text == text2)
		{
			frmAddTkt frmAddTkt2 = new frmAddTkt
			{
				bool_1 = true,
				dictionary_1 = Program.dictionary_0
			};
			string text3 = "Ticket Information";
			frmAddTkt2.Text = text3;
			frmAddTkt2.bool_0 = true;
			frmAddTkt2.EditLoad(class48_0);
			frmAddTkt2.ShowDialog();
		}
		else if (eventHandler_2 != null)
		{
			eventHandler_2(this, e);
		}
	}

	private void BtnCancel_Click_1(object sender, EventArgs e)
	{
		if (eventHandler_1 != null)
		{
			eventHandler_1(this, e);
		}
	}

	private void BAAAA(object sender, EventArgs e)
	{
		string text = lblStatus.Text;
		string value = "Open PNR:";
		if (text.Contains(value))
		{
			try
			{
				string text2 = lblStatus.Text;
				string text3 = lblStatus.Text;
				string value2 = ":";
				text2.Substring(text3.IndexOf(value2) + 1).Trim();
				string text4 = lblPnr.Text;
				string startupPath = Program.StartupPath;
				string path = "PNR";
				string text5 = Path.Combine(startupPath, path);
				string text6 = "\\";
				string path2 = text5 + text6;
				DateTime now = DateTime.Now;
				string text7 = "dd-MMM";
				string text8 = Path.Combine(path2, now.ToString(text7));
				string text9 = "\\";
				string path3 = text8 + text9;
				string[] array = new string[8]
				{
					cboID.SelectedItem.ToString(),
					null,
					null,
					null,
					null,
					null,
					null,
					null
				};
				string text10 = "_";
				array[1] = text10;
				array[2] = text4;
				string text11 = "_";
				array[3] = text11;
				array[4] = class48_0.string_0;
				string text12 = "_";
				array[5] = text12;
				array[6] = class48_0.string_1;
				string text13 = ".htm";
				array[7] = text13;
				Path.Combine(path3, string.Concat(array));
				string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
				string path4 = "Nget_Log";
				string path5 = Path.Combine(folderPath, path4);
				string[] array2 = new string[7];
				string text14 = "ERS_";
				array2[0] = text14;
				array2[1] = text4;
				string text15 = "_";
				array2[2] = text15;
				array2[3] = class48_0.string_0;
				string text16 = "_";
				array2[4] = text16;
				array2[5] = class48_0.string_1;
				string text17 = ".htm";
				array2[6] = text17;
				Process.Start(Path.Combine(path5, string.Concat(array2)));
				return;
			}
			catch
			{
				return;
			}
		}
		string text18 = lblStatus.Text;
		string value3 = "Ready-{ Bkg Cap";
		if (text18.Contains(value3))
		{
			try
			{
				string string_ = class48_0.string_25;
				string[] array3 = new string[1];
				string text19 = "|";
				array3[0] = text19;
				string[] array4 = string_.Split(array3, StringSplitOptions.RemoveEmptyEntries);
				int num = int.Parse(array4[0].Trim());
				int num2 = int.Parse(array4[1].Trim());
				frmOTP frmOTP2 = new frmOTP(bool_2: false, "");
				frmOTP2.StartPosition = FormStartPosition.Manual;
				frmOTP2.Location = PointToScreen(Point.Empty);
				frmOTP2.Location = PointToScreen(base.Location);
				frmOTP2.bool_1 = false;
				frmOTP2.int_0 = int_1;
				string string_2 = class48_0.string_8;
				string text20 = "PT";
				if (string_2 == text20)
				{
					int_2 = num2;
					frmOTP2.int_2 = int_2;
				}
				if (frmOTP2.ShowDialog() == DialogResult.OK)
				{
					int_1 = frmOTP2.int_0;
					string string_3 = class48_0.string_8;
					string text21 = "PT";
					if (string_3 == text21)
					{
						int_2 = frmOTP2.int_2;
						int num3 = int_2;
						Class48 @class = class48_0;
						string text22 = num.ToString();
						string text23 = "|";
						@class.string_25 = text22 + text23 + num3;
						fare_str = class48_0.string_25;
						Label label = lblAvailability;
						string text24 = label.Text;
						string text25 = "|";
						label.Text = text24 + text25 + fare_str;
					}
					Label label2 = lblStatus;
					string[] array5 = new string[5];
					string text26 = "Ready-{ Bkg Cap: ";
					array5[0] = text26;
					array5[1] = (int_1 / 1000).ToString();
					string text27 = ".";
					array5[2] = text27;
					array5[3] = (int_1 % 1000 / 100).ToString();
					string text28 = " } Fare Limit";
					array5[4] = text28;
					label2.Text = string.Concat(array5);
				}
				frmOTP2.Dispose();
				return;
			}
			catch
			{
				return;
			}
		}
		string text29 = lblStatus.Text;
		string caption = "Info";
		MessageBox.Show(text29, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
	}

	public void RefreshSeats(object object_0)
	{
		try
		{
			cboQuota.SelectedItem.ToString();
			string from = class48_0.string_0;
			string to = class48_0.string_1;
			string trainNum = class48_0.string_2;
			string[] array = new string[5] { class48_0.string_4, null, null, null, null };
			string text = "/";
			array[1] = text;
			array[2] = class48_0.string_5;
			string text2 = "/";
			array[3] = text2;
			array[4] = class48_0.string_6;
			string s = string.Concat(array);
			string format = "d/M/yyyy";
			method_6(Class47.method_2A(from, to, trainNum, DateTime.ParseExact(s, format, CultureInfo.InvariantCulture), class48_0.string_7, cboQuota.SelectedItem.ToString()).Split('~')[0]);
		}
		catch
		{
		}
	}

	private void method_6(object object_1)
	{
		if (base.InvokeRequired)
		{
			Invoke(new ParameterizedThreadStart(method_6), object_1);
			return;
		}
		Label label = lblAvailability;
		string text = object_1.ToString();
		string text2 = "|";
		label.Text = text + text2 + fare_str;
	}

	private void lblAvailability_Click(object sender, EventArgs e)
	{
		Label label = lblAvailability;
		string text = "Getting..";
		label.Text = text;
		ThreadPool.QueueUserWorkItem(RefreshSeats);
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		Label label = lblTime;
		DateTime dateTime = DateTime.Now.AddMilliseconds(int_3);
		string text = "hh:mm:ss";
		label.Text = dateTime.ToString(text);
	}

	private void cboID_DrawItem(object sender, DrawItemEventArgs e)
	{
		e.DrawBackground();
		string text = ((ComboBox)sender).Items[e.Index].ToString();
		Brush brush = ((!C2AA0.Contains(text)) ? Brushes.Black : Brushes.Red);
		e.Graphics.DrawString(text, ((Control)sender).Font, brush, e.Bounds.X, e.Bounds.Y);
		e.DrawFocusRectangle();
	}

	private void cboID_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			lock (object_0)
			{
				if (string_2.Length > 1)
				{
					Dictionary<string, string> list_SelectedIRCTCid = Program.list_SelectedIRCTCid;
					string key = string_2;
					string value = "free";
					list_SelectedIRCTCid[key] = value;
					C2AA0.Remove(string_2);
				}
				Dictionary<string, string> list_SelectedIRCTCid2 = Program.list_SelectedIRCTCid;
				string key2 = cboID.SelectedItem.ToString();
				string value2 = "busy";
				list_SelectedIRCTCid2[key2] = value2;
				C2AA0.Add(cboID.SelectedItem.ToString());
				string_2 = cboID.SelectedItem.ToString();
			}
			cboID.Refresh();
		}
		catch
		{
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && container_0 != null)
		{
			container_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		this.cboGateway = new System.Windows.Forms.ComboBox();
		this.cboID = new System.Windows.Forms.ComboBox();
		this.btnEdit = new System.Windows.Forms.Button();
		this.chkConfirmation = new System.Windows.Forms.CheckBox();
		this.cboSlot = new System.Windows.Forms.ComboBox();
		this.BtnOpenPair = new System.Windows.Forms.Button();
		this.lblJourney = new System.Windows.Forms.Label();
		this.cboQuota = new System.Windows.Forms.ComboBox();
		this.lblStatus = new System.Windows.Forms.Label();
		this.TopPanel = new System.Windows.Forms.Panel();
		this.btnCancel = new System.Windows.Forms.Button();
		this.lblTktName = new System.Windows.Forms.Label();
		this.timer_0 = new System.Windows.Forms.Timer(this.components);
		this.toolTip_0 = new System.Windows.Forms.ToolTip(this.components);
		this.panel2 = new System.Windows.Forms.Panel();
		this.lblInfo = new System.Windows.Forms.Label();
		this.check_avl = new System.Windows.Forms.CheckBox();
		this.HeaderPanel1 = new System.Windows.Forms.Panel();
		this.Panel5 = new System.Windows.Forms.Panel();
		this.btnSlotNo = new System.Windows.Forms.Button();
		this.btnMinize = new System.Windows.Forms.Button();
		this.WLlinkLabel = new System.Windows.Forms.LinkLabel();
		this.EditlinkLabel = new System.Windows.Forms.LinkLabel();
		this.lblClass = new System.Windows.Forms.Label();
		this.cboTrain = new System.Windows.Forms.ComboBox();
		this.Panel1 = new System.Windows.Forms.Panel();
		this.cboClass = new System.Windows.Forms.ComboBox();
		this.label13 = new System.Windows.Forms.Label();
		this.label11 = new System.Windows.Forms.Label();
		this.lblDate = new System.Windows.Forms.Label();
		this.PanelPnr = new System.Windows.Forms.Panel();
		this.label5 = new System.Windows.Forms.Label();
		this.lbl_Detail = new System.Windows.Forms.Label();
		this.lbl_Date = new System.Windows.Forms.Label();
		this.lbl_Month = new System.Windows.Forms.Label();
		this.lbl_status = new System.Windows.Forms.Label();
		this.lbl_brand = new System.Windows.Forms.Label();
		this.lbl_time = new System.Windows.Forms.Label();
		this.B3AAA = new System.Windows.Forms.Panel();
		this.lbl_slot = new System.Windows.Forms.Label();
		this.lblPnr = new System.Windows.Forms.Label();
		this.AppLogin_ = new System.Windows.Forms.Button();
		this.lblTrainNo = new System.Windows.Forms.Label();
		this.timer_1 = new System.Windows.Forms.Timer(this.components);
		this.WebLogin = new System.Windows.Forms.Button();
		this.button1 = new System.Windows.Forms.Button();
		this.lbl_bnk = new System.Windows.Forms.Label();
		this.lblBrand = new System.Windows.Forms.Label();
		this.btnDish = new System.Windows.Forms.Button();
		this.btnWeb3 = new System.Windows.Forms.Button();
		this.fake_bank = new System.Windows.Forms.ComboBox();
		this.fake_id = new System.Windows.Forms.ComboBox();
		this.pnlBrand = new System.Windows.Forms.Panel();
		this.lblLoginType = new System.Windows.Forms.Label();
		this.lblBank = new System.Windows.Forms.Label();
		this.BottomPanel = new System.Windows.Forms.Panel();
		this.lblTime = new System.Windows.Forms.Label();
		this.lblAvailability = new System.Windows.Forms.Label();
		this.pictureBox2 = new System.Windows.Forms.PictureBox();
		this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
		this.button2 = new System.Windows.Forms.Button();
		this.TopPanel.SuspendLayout();
		this.HeaderPanel1.SuspendLayout();
		this.Panel1.SuspendLayout();
		this.PanelPnr.SuspendLayout();
		this.pnlBrand.SuspendLayout();
		this.BottomPanel.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
		base.SuspendLayout();
		this.cboGateway.BackColor = System.Drawing.Color.Gainsboro;
		this.cboGateway.DropDownHeight = 250;
		this.cboGateway.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboGateway.DropDownWidth = 200;
		this.cboGateway.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboGateway.ForeColor = System.Drawing.Color.Black;
		this.cboGateway.FormattingEnabled = true;
		this.cboGateway.IntegralHeight = false;
		this.cboGateway.Items.AddRange(new object[5] { "-Select-", "NB BANK NAME - USERNAME", "DC BANK NAME - HOLDERNAME (LAST 4 DIGIT OF CARD)", "CC BANK NAME - HOLDERNAME (LAST 4 DIGIT OF CARD)", "VC BANK NAME - HOLDERNAME (LAST 4 DIGIT OF CARD)" });
		this.cboGateway.Location = new System.Drawing.Point(56, 63);
		this.cboGateway.Margin = new System.Windows.Forms.Padding(2);
		this.cboGateway.Name = "cboGateway";
		this.cboGateway.Size = new System.Drawing.Size(162, 22);
		this.cboGateway.TabIndex = 12;
		this.cboGateway.SelectedIndexChanged += new System.EventHandler(cboGateway_SelectedIndexChanged);
		this.cboGateway.MouseLeave += new System.EventHandler(cboGateway_MouseLeave);
		this.cboGateway.MouseMove += new System.Windows.Forms.MouseEventHandler(cboGateway_MouseMove);
		this.cboID.BackColor = System.Drawing.SystemColors.Window;
		this.cboID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboID.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.cboID.Font = new System.Drawing.Font("Verdana", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.cboID.ForeColor = System.Drawing.Color.Black;
		this.cboID.FormattingEnabled = true;
		this.cboID.Items.AddRange(new object[8] { "-Select-", "A1A2A3", "B1B2B3", "C1C2C3", "D1D2D3", "E1E2E3", "F1F2F3", "G1G2G3" });
		this.cboID.Location = new System.Drawing.Point(0, 39);
		this.cboID.Name = "cboID";
		this.cboID.Size = new System.Drawing.Size(107, 21);
		this.cboID.TabIndex = 10;
		this.cboID.DrawItem += new System.Windows.Forms.DrawItemEventHandler(cboID_DrawItem);
		this.cboID.SelectedIndexChanged += new System.EventHandler(cboID_SelectedIndexChanged);
		this.cboID.MouseLeave += new System.EventHandler(cboID_MouseLeave);
		this.cboID.MouseMove += new System.Windows.Forms.MouseEventHandler(cboID_MouseMove);
		this.btnEdit.BackColor = System.Drawing.SystemColors.Control;
		this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold);
		this.btnEdit.ForeColor = System.Drawing.Color.MidnightBlue;
		this.btnEdit.Location = new System.Drawing.Point(144, 210);
		this.btnEdit.Name = "btnEdit";
		this.btnEdit.Size = new System.Drawing.Size(72, 23);
		this.btnEdit.TabIndex = 7;
		this.btnEdit.Text = "Edit";
		this.btnEdit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.btnEdit.UseVisualStyleBackColor = false;
		this.btnEdit.Click += new System.EventHandler(btnEdit_Click);
		this.chkConfirmation.AutoSize = true;
		this.chkConfirmation.Font = new System.Drawing.Font("Corbel", 9f);
		this.chkConfirmation.ForeColor = System.Drawing.Color.Black;
		this.chkConfirmation.Location = new System.Drawing.Point(3, 65);
		this.chkConfirmation.Name = "chkConfirmation";
		this.chkConfirmation.RightToLeft = System.Windows.Forms.RightToLeft.No;
		this.chkConfirmation.Size = new System.Drawing.Size(49, 18);
		this.chkConfirmation.TabIndex = 22;
		this.chkConfirmation.Text = "Stop";
		this.toolTip1.SetToolTip(this.chkConfirmation, "Agar aapko payment Stop karna he to isse Tick kijiye.");
		this.chkConfirmation.UseVisualStyleBackColor = true;
		this.chkConfirmation.MouseClick += new System.Windows.Forms.MouseEventHandler(chkConfirmation_MouseClick);
		this.cboSlot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboSlot.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.cboSlot.Font = new System.Drawing.Font("Verdana", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.cboSlot.ForeColor = System.Drawing.Color.Black;
		this.cboSlot.FormattingEnabled = true;
		this.cboSlot.Items.AddRange(new object[7] { "-Select-", "Tkt No 1", "Tkt No 2", "Tkt No 3", "Tkt No 4", "Tkt No 5", "Tkt No 6" });
		this.cboSlot.Location = new System.Drawing.Point(112, 39);
		this.cboSlot.Name = "cboSlot";
		this.cboSlot.Size = new System.Drawing.Size(51, 21);
		this.cboSlot.TabIndex = 8;
		this.cboSlot.SelectedIndexChanged += new System.EventHandler(cboSlot_SelectedIndexChanged);
		this.BtnOpenPair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.BtnOpenPair.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold);
		this.BtnOpenPair.ForeColor = System.Drawing.Color.Black;
		this.BtnOpenPair.Location = new System.Drawing.Point(166, 39);
		this.BtnOpenPair.Name = "BtnOpenPair";
		this.BtnOpenPair.Size = new System.Drawing.Size(53, 20);
		this.BtnOpenPair.TabIndex = 5;
		this.BtnOpenPair.Text = "Pair";
		this.BtnOpenPair.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.BtnOpenPair.UseVisualStyleBackColor = false;
		this.BtnOpenPair.Click += new System.EventHandler(BtnOpenPair_Click);
		this.lblJourney.AutoSize = true;
		this.lblJourney.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblJourney.ForeColor = System.Drawing.Color.Black;
		this.lblJourney.Location = new System.Drawing.Point(-1, 22);
		this.lblJourney.Name = "lblJourney";
		this.lblJourney.Size = new System.Drawing.Size(71, 14);
		this.lblJourney.TabIndex = 2;
		this.lblJourney.Text = "NZM_ NDLS";
		this.lblJourney.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.toolTip1.SetToolTip(this.lblJourney, "Click Here For Edit Ticket After Load");
		this.cboQuota.BackColor = System.Drawing.SystemColors.Control;
		this.cboQuota.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboQuota.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.cboQuota.Font = new System.Drawing.Font("Verdana", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.cboQuota.ForeColor = System.Drawing.Color.Black;
		this.cboQuota.FormattingEnabled = true;
		this.cboQuota.Items.AddRange(new object[4] { "GN", "TQ", "PT", "LD" });
		this.cboQuota.Location = new System.Drawing.Point(69, 212);
		this.cboQuota.Name = "cboQuota";
		this.cboQuota.Size = new System.Drawing.Size(67, 21);
		this.cboQuota.TabIndex = 10;
		this.toolTip1.SetToolTip(this.cboQuota, "Quota to Book");
		this.cboQuota.SelectedIndexChanged += new System.EventHandler(CboQuota_SelectedIndexChanged);
		this.lblStatus.BackColor = System.Drawing.Color.FromArgb(12, 78, 66);
		this.lblStatus.Cursor = System.Windows.Forms.Cursors.Hand;
		this.lblStatus.Dock = System.Windows.Forms.DockStyle.Top;
		this.lblStatus.Font = new System.Drawing.Font("MS UI Gothic", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblStatus.ForeColor = System.Drawing.Color.Yellow;
		this.lblStatus.Location = new System.Drawing.Point(0, 0);
		this.lblStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.lblStatus.Name = "lblStatus";
		this.lblStatus.Size = new System.Drawing.Size(220, 19);
		this.lblStatus.TabIndex = 0;
		this.lblStatus.Text = "Status Bar";
		this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblStatus.Click += new System.EventHandler(lblStatus_Click);
		this.TopPanel.Controls.Add(this.lblStatus);
		this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
		this.TopPanel.Location = new System.Drawing.Point(0, 0);
		this.TopPanel.Name = "TopPanel";
		this.TopPanel.Size = new System.Drawing.Size(220, 21);
		this.TopPanel.TabIndex = 28;
		this.btnCancel.AutoSize = true;
		this.btnCancel.BackColor = System.Drawing.Color.LightGray;
		this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.btnCancel.FlatAppearance.BorderSize = 0;
		this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(128, 128, 255);
		this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnCancel.ForeColor = System.Drawing.Color.Black;
		this.btnCancel.Location = new System.Drawing.Point(621, 39);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(105, 23);
		this.btnCancel.TabIndex = 1180;
		this.btnCancel.Text = "Cancel";
		this.btnCancel.UseVisualStyleBackColor = false;
		this.btnCancel.Click += new System.EventHandler(BtnCancel_Click_1);
		this.lblTktName.AutoSize = true;
		this.lblTktName.Font = new System.Drawing.Font("Verdana", 6f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblTktName.ForeColor = System.Drawing.Color.Silver;
		this.lblTktName.Location = new System.Drawing.Point(971, 231);
		this.lblTktName.Name = "lblTktName";
		this.lblTktName.Size = new System.Drawing.Size(35, 10);
		this.lblTktName.TabIndex = 14;
		this.lblTktName.Text = "11012";
		this.timer_0.Interval = 500;
		this.timer_0.Tick += new System.EventHandler(timer_0_Tick);
		this.toolTip_0.AutoPopDelay = 2000;
		this.toolTip_0.InitialDelay = 500;
		this.toolTip_0.IsBalloon = true;
		this.toolTip_0.ReshowDelay = 100;
		this.toolTip_0.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
		this.toolTip_0.ToolTipTitle = "Ticket Window";
		this.panel2.BackColor = System.Drawing.Color.Maroon;
		this.panel2.Cursor = System.Windows.Forms.Cursors.Hand;
		this.panel2.ForeColor = System.Drawing.Color.White;
		this.panel2.Location = new System.Drawing.Point(469, 179);
		this.panel2.Margin = new System.Windows.Forms.Padding(2);
		this.panel2.Name = "panel2";
		this.panel2.Size = new System.Drawing.Size(189, 33);
		this.panel2.TabIndex = 1182;
		this.toolTip1.SetToolTip(this.panel2, "Click Here For Edit Ticket After Load");
		this.lblInfo.AutoSize = true;
		this.lblInfo.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblInfo.ForeColor = System.Drawing.Color.White;
		this.lblInfo.Location = new System.Drawing.Point(410, 245);
		this.lblInfo.Name = "lblInfo";
		this.lblInfo.Size = new System.Drawing.Size(101, 14);
		this.lblInfo.TabIndex = 2;
		this.lblInfo.Text = "SHE -> SRP -> SRP";
		this.toolTip1.SetToolTip(this.lblInfo, "Click Here For Edit Ticket After Load");
		this.check_avl.AutoSize = true;
		this.check_avl.Font = new System.Drawing.Font("Corbel", 7.8f);
		this.check_avl.Location = new System.Drawing.Point(590, 92);
		this.check_avl.Margin = new System.Windows.Forms.Padding(2);
		this.check_avl.Name = "check_avl";
		this.check_avl.Size = new System.Drawing.Size(99, 17);
		this.check_avl.TabIndex = 1192;
		this.check_avl.Text = "Fast Availability";
		this.toolTip1.SetToolTip(this.check_avl, "Fast Availbality Tick Karne se Station From/To Change ho sakta hai");
		this.check_avl.UseVisualStyleBackColor = true;
		this.HeaderPanel1.BackColor = System.Drawing.Color.Thistle;
		this.HeaderPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.HeaderPanel1.Controls.Add(this.Panel5);
		this.HeaderPanel1.Controls.Add(this.btnSlotNo);
		this.HeaderPanel1.Location = new System.Drawing.Point(571, 245);
		this.HeaderPanel1.Margin = new System.Windows.Forms.Padding(2);
		this.HeaderPanel1.Name = "HeaderPanel1";
		this.HeaderPanel1.Size = new System.Drawing.Size(219, 23);
		this.HeaderPanel1.TabIndex = 129;
		this.Panel5.BackColor = System.Drawing.Color.Thistle;
		this.Panel5.Location = new System.Drawing.Point(35, 0);
		this.Panel5.Name = "Panel5";
		this.Panel5.Size = new System.Drawing.Size(145, 21);
		this.Panel5.TabIndex = 1195;
		this.btnSlotNo.BackColor = System.Drawing.Color.MediumTurquoise;
		this.btnSlotNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnSlotNo.ForeColor = System.Drawing.Color.Black;
		this.btnSlotNo.Location = new System.Drawing.Point(181, 0);
		this.btnSlotNo.Name = "btnSlotNo";
		this.btnSlotNo.Size = new System.Drawing.Size(36, 21);
		this.btnSlotNo.TabIndex = 1193;
		this.btnSlotNo.Text = "1";
		this.btnSlotNo.UseVisualStyleBackColor = false;
		this.btnMinize.BackColor = System.Drawing.Color.Lavender;
		this.btnMinize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnMinize.Location = new System.Drawing.Point(179, 1);
		this.btnMinize.Name = "btnMinize";
		this.btnMinize.Size = new System.Drawing.Size(36, 21);
		this.btnMinize.TabIndex = 1193;
		this.btnMinize.Text = "Xx";
		this.btnMinize.UseVisualStyleBackColor = false;
		this.WLlinkLabel.ActiveLinkColor = System.Drawing.Color.Aqua;
		this.WLlinkLabel.AutoSize = true;
		this.WLlinkLabel.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.WLlinkLabel.ForeColor = System.Drawing.Color.Cornsilk;
		this.WLlinkLabel.LinkColor = System.Drawing.Color.DarkGreen;
		this.WLlinkLabel.Location = new System.Drawing.Point(162, 25);
		this.WLlinkLabel.Name = "WLlinkLabel";
		this.WLlinkLabel.Size = new System.Drawing.Size(52, 14);
		this.WLlinkLabel.TabIndex = 1186;
		this.WLlinkLabel.TabStop = true;
		this.WLlinkLabel.Text = "WL Stop";
		this.WLlinkLabel.VisitedLinkColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.EditlinkLabel.ActiveLinkColor = System.Drawing.Color.Aqua;
		this.EditlinkLabel.AutoSize = true;
		this.EditlinkLabel.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.EditlinkLabel.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
		this.EditlinkLabel.LinkColor = System.Drawing.Color.Green;
		this.EditlinkLabel.Location = new System.Drawing.Point(155, 44);
		this.EditlinkLabel.Name = "EditlinkLabel";
		this.EditlinkLabel.Size = new System.Drawing.Size(59, 14);
		this.EditlinkLabel.TabIndex = 1187;
		this.EditlinkLabel.TabStop = true;
		this.EditlinkLabel.Text = "Edit Form";
		this.EditlinkLabel.VisitedLinkColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.lblClass.AutoSize = true;
		this.lblClass.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblClass.ForeColor = System.Drawing.Color.Black;
		this.lblClass.Location = new System.Drawing.Point(131, 22);
		this.lblClass.Name = "lblClass";
		this.lblClass.Size = new System.Drawing.Size(40, 14);
		this.lblClass.TabIndex = 30;
		this.lblClass.Text = "SL:GN";
		this.lblClass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.cboTrain.BackColor = System.Drawing.Color.AntiqueWhite;
		this.cboTrain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboTrain.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cboTrain.Font = new System.Drawing.Font("Arial", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboTrain.ForeColor = System.Drawing.Color.Black;
		this.cboTrain.FormattingEnabled = true;
		this.cboTrain.Items.AddRange(new object[1] { "Train No" });
		this.cboTrain.Location = new System.Drawing.Point(115, 2);
		this.cboTrain.Name = "cboTrain";
		this.cboTrain.Size = new System.Drawing.Size(64, 19);
		this.cboTrain.TabIndex = 31;
		this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.Panel1.Controls.Add(this.cboClass);
		this.Panel1.Controls.Add(this.btnMinize);
		this.Panel1.Controls.Add(this.label13);
		this.Panel1.Controls.Add(this.label11);
		this.Panel1.Controls.Add(this.EditlinkLabel);
		this.Panel1.Controls.Add(this.WLlinkLabel);
		this.Panel1.Controls.Add(this.cboTrain);
		this.Panel1.Location = new System.Drawing.Point(674, 153);
		this.Panel1.Name = "Panel1";
		this.Panel1.Size = new System.Drawing.Size(219, 62);
		this.Panel1.TabIndex = 131;
		this.cboClass.BackColor = System.Drawing.Color.White;
		this.cboClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboClass.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cboClass.Font = new System.Drawing.Font("Arial", 6.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboClass.ForeColor = System.Drawing.Color.Black;
		this.cboClass.FormattingEnabled = true;
		this.cboClass.Items.AddRange(new object[10] { "1A", "2A", "3A", "CC", "SL", "2S", "3E", "EA", "EC", "EV" });
		this.cboClass.Location = new System.Drawing.Point(41, 3);
		this.cboClass.Name = "cboClass";
		this.cboClass.Size = new System.Drawing.Size(39, 19);
		this.cboClass.TabIndex = 10;
		this.label13.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label13.ForeColor = System.Drawing.Color.DarkGreen;
		this.label13.Location = new System.Drawing.Point(2, 24);
		this.label13.Name = "label13";
		this.label13.Size = new System.Drawing.Size(32, 16);
		this.label13.TabIndex = 1183;
		this.label13.Text = "Cls :";
		this.label11.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label11.ForeColor = System.Drawing.Color.DarkGreen;
		this.label11.Location = new System.Drawing.Point(81, 23);
		this.label11.Name = "label11";
		this.label11.Size = new System.Drawing.Size(27, 16);
		this.label11.TabIndex = 1183;
		this.label11.Text = "Qt :";
		this.lblDate.AutoSize = true;
		this.lblDate.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblDate.ForeColor = System.Drawing.Color.Black;
		this.lblDate.Location = new System.Drawing.Point(178, 22);
		this.lblDate.Name = "lblDate";
		this.lblDate.Size = new System.Drawing.Size(40, 14);
		this.lblDate.TabIndex = 36;
		this.lblDate.Text = "00/00";
		this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.PanelPnr.BackColor = System.Drawing.Color.FromArgb(20, 21, 22);
		this.PanelPnr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.PanelPnr.Controls.Add(this.label5);
		this.PanelPnr.Location = new System.Drawing.Point(30, 437);
		this.PanelPnr.Name = "PanelPnr";
		this.PanelPnr.Size = new System.Drawing.Size(241, 113);
		this.PanelPnr.TabIndex = 1181;
		this.label5.AutoSize = true;
		this.label5.BackColor = System.Drawing.Color.Transparent;
		this.label5.Font = new System.Drawing.Font("Calibri", 9f, System.Drawing.FontStyle.Bold);
		this.label5.ForeColor = System.Drawing.Color.White;
		this.label5.Location = new System.Drawing.Point(134, 96);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(104, 14);
		this.label5.TabIndex = 35;
		this.label5.Text = "DEOS_NDLS- 12/22";
		this.lbl_Detail.BackColor = System.Drawing.Color.Black;
		this.lbl_Detail.Font = new System.Drawing.Font("Calibri", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lbl_Detail.ForeColor = System.Drawing.Color.Yellow;
		this.lbl_Detail.Location = new System.Drawing.Point(33, 339);
		this.lbl_Detail.Name = "lbl_Detail";
		this.lbl_Detail.Size = new System.Drawing.Size(83, 76);
		this.lbl_Detail.TabIndex = 34;
		this.lbl_Detail.Text = "Train: 12553\r\nQuota: TQ\r\nClass: SL\r\nSrc: DEOS\r\nDest: NDLS";
		this.lbl_Date.AutoSize = true;
		this.lbl_Date.BackColor = System.Drawing.Color.FromArgb(64, 0, 0);
		this.lbl_Date.Font = new System.Drawing.Font("Calibri", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lbl_Date.ForeColor = System.Drawing.Color.Yellow;
		this.lbl_Date.Location = new System.Drawing.Point(203, 388);
		this.lbl_Date.Name = "lbl_Date";
		this.lbl_Date.Size = new System.Drawing.Size(30, 23);
		this.lbl_Date.TabIndex = 31;
		this.lbl_Date.Text = "05";
		this.lbl_Month.AutoSize = true;
		this.lbl_Month.BackColor = System.Drawing.Color.FromArgb(64, 0, 0);
		this.lbl_Month.Font = new System.Drawing.Font("Calibri", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lbl_Month.ForeColor = System.Drawing.Color.Yellow;
		this.lbl_Month.Location = new System.Drawing.Point(186, 408);
		this.lbl_Month.Name = "lbl_Month";
		this.lbl_Month.Size = new System.Drawing.Size(60, 18);
		this.lbl_Month.TabIndex = 32;
		this.lbl_Month.Text = "Jun 2018";
		this.lbl_status.AutoSize = true;
		this.lbl_status.BackColor = System.Drawing.Color.FromArgb(34, 36, 36);
		this.lbl_status.Font = new System.Drawing.Font("Calibri", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lbl_status.ForeColor = System.Drawing.Color.FromArgb(70, 173, 211);
		this.lbl_status.Location = new System.Drawing.Point(97, 365);
		this.lbl_status.Name = "lbl_status";
		this.lbl_status.Size = new System.Drawing.Size(85, 15);
		this.lbl_status.TabIndex = 33;
		this.lbl_status.Text = "SUCCESS -WEB";
		this.lbl_brand.AutoSize = true;
		this.lbl_brand.BackColor = System.Drawing.Color.FromArgb(42, 44, 44);
		this.lbl_brand.Font = new System.Drawing.Font("Calibri", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lbl_brand.ForeColor = System.Drawing.Color.FromArgb(70, 173, 211);
		this.lbl_brand.Location = new System.Drawing.Point(113, 386);
		this.lbl_brand.Name = "lbl_brand";
		this.lbl_brand.Size = new System.Drawing.Size(59, 19);
		this.lbl_brand.TabIndex = 34;
		this.lbl_brand.Text = "Hitman";
		this.lbl_time.AutoSize = true;
		this.lbl_time.BackColor = System.Drawing.Color.FromArgb(42, 44, 44);
		this.lbl_time.Font = new System.Drawing.Font("Calibri", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lbl_time.ForeColor = System.Drawing.Color.FromArgb(70, 173, 211);
		this.lbl_time.Location = new System.Drawing.Point(112, 340);
		this.lbl_time.Name = "lbl_time";
		this.lbl_time.Size = new System.Drawing.Size(58, 18);
		this.lbl_time.TabIndex = 40;
		this.lbl_time.Text = "10:00:55";
		this.B3AAA.BackColor = System.Drawing.Color.Transparent;
		this.B3AAA.Location = new System.Drawing.Point(774, 421);
		this.B3AAA.Name = "B3AAA";
		this.B3AAA.Size = new System.Drawing.Size(219, 109);
		this.B3AAA.TabIndex = 37;
		this.lbl_slot.AutoSize = true;
		this.lbl_slot.BackColor = System.Drawing.Color.Black;
		this.lbl_slot.Font = new System.Drawing.Font("Calibri", 9.75f, System.Drawing.FontStyle.Bold);
		this.lbl_slot.ForeColor = System.Drawing.Color.Yellow;
		this.lbl_slot.Location = new System.Drawing.Point(33, 416);
		this.lbl_slot.Name = "lbl_slot";
		this.lbl_slot.Size = new System.Drawing.Size(51, 15);
		this.lbl_slot.TabIndex = 38;
		this.lbl_slot.Text = "SLOT - 1";
		this.lblPnr.AutoSize = true;
		this.lblPnr.Font = new System.Drawing.Font("Calibri", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblPnr.ForeColor = System.Drawing.Color.Black;
		this.lblPnr.Location = new System.Drawing.Point(1005, 261);
		this.lblPnr.Name = "lblPnr";
		this.lblPnr.Size = new System.Drawing.Size(67, 14);
		this.lblPnr.TabIndex = 1182;
		this.lblPnr.Text = "6715568899";
		this.AppLogin_.BackColor = System.Drawing.SystemColors.ActiveBorder;
		this.AppLogin_.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.AppLogin_.Cursor = System.Windows.Forms.Cursors.Default;
		this.AppLogin_.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.AppLogin_.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold);
		this.AppLogin_.ForeColor = System.Drawing.Color.Black;
		this.AppLogin_.Location = new System.Drawing.Point(0, 209);
		this.AppLogin_.Margin = new System.Windows.Forms.Padding(2);
		this.AppLogin_.Name = "AppLogin_";
		this.AppLogin_.RightToLeft = System.Windows.Forms.RightToLeft.No;
		this.AppLogin_.Size = new System.Drawing.Size(64, 24);
		this.AppLogin_.TabIndex = 1188;
		this.AppLogin_.Text = "APP";
		this.AppLogin_.UseVisualStyleBackColor = false;
		this.AppLogin_.Click += new System.EventHandler(AppLogin_Click);
		this.lblTrainNo.AutoSize = true;
		this.lblTrainNo.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblTrainNo.ForeColor = System.Drawing.Color.Black;
		this.lblTrainNo.Location = new System.Drawing.Point(79, 22);
		this.lblTrainNo.Name = "lblTrainNo";
		this.lblTrainNo.Size = new System.Drawing.Size(42, 14);
		this.lblTrainNo.TabIndex = 1189;
		this.lblTrainNo.Text = "00234";
		this.lblTrainNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.timer_1.Interval = 500;
		this.timer_1.Tick += new System.EventHandler(timer_1_Tick);
		this.WebLogin.BackColor = System.Drawing.Color.PaleTurquoise;
		this.WebLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.WebLogin.Cursor = System.Windows.Forms.Cursors.Default;
		this.WebLogin.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
		this.WebLogin.FlatAppearance.BorderSize = 0;
		this.WebLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(224, 224, 224);
		this.WebLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
		this.WebLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.WebLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.WebLogin.ForeColor = System.Drawing.Color.Black;
		this.WebLogin.Location = new System.Drawing.Point(2, 87);
		this.WebLogin.Margin = new System.Windows.Forms.Padding(2);
		this.WebLogin.Name = "WebLogin";
		this.WebLogin.RightToLeft = System.Windows.Forms.RightToLeft.No;
		this.WebLogin.Size = new System.Drawing.Size(56, 23);
		this.WebLogin.TabIndex = 1188;
		this.WebLogin.Text = "Web-1";
		this.WebLogin.UseVisualStyleBackColor = false;
		this.WebLogin.Click += new System.EventHandler(WebLogin_Click);
		this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
		this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold);
		this.button1.ForeColor = System.Drawing.Color.Black;
		this.button1.Location = new System.Drawing.Point(774, 59);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(54, 23);
		this.button1.TabIndex = 1193;
		this.button1.Text = "Pair";
		this.button1.UseVisualStyleBackColor = false;
		this.button1.Click += new System.EventHandler(button1_Click_1);
		this.lbl_bnk.AutoSize = true;
		this.lbl_bnk.BackColor = System.Drawing.Color.Transparent;
		this.lbl_bnk.Font = new System.Drawing.Font("Calibri", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lbl_bnk.ForeColor = System.Drawing.Color.Black;
		this.lbl_bnk.Location = new System.Drawing.Point(32, 321);
		this.lbl_bnk.Name = "lbl_bnk";
		this.lbl_bnk.Size = new System.Drawing.Size(105, 19);
		this.lbl_bnk.TabIndex = 39;
		this.lbl_bnk.Text = "Bnk : PHONPE";
		this.lblBrand.BackColor = System.Drawing.Color.Transparent;
		this.lblBrand.Dock = System.Windows.Forms.DockStyle.Top;
		this.lblBrand.Font = new System.Drawing.Font("Verdana", 27.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblBrand.ForeColor = System.Drawing.Color.Gray;
		this.lblBrand.Location = new System.Drawing.Point(0, 0);
		this.lblBrand.Name = "lblBrand";
		this.lblBrand.Size = new System.Drawing.Size(220, 45);
		this.lblBrand.TabIndex = 1195;
		this.lblBrand.Text = "  Hitman  ";
		this.btnDish.BackColor = System.Drawing.SystemColors.ActiveCaption;
		this.btnDish.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.btnDish.Cursor = System.Windows.Forms.Cursors.Default;
		this.btnDish.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.btnDish.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold);
		this.btnDish.ForeColor = System.Drawing.Color.Black;
		this.btnDish.Location = new System.Drawing.Point(60, 87);
		this.btnDish.Margin = new System.Windows.Forms.Padding(2);
		this.btnDish.Name = "btnDish";
		this.btnDish.RightToLeft = System.Windows.Forms.RightToLeft.No;
		this.btnDish.Size = new System.Drawing.Size(56, 23);
		this.btnDish.TabIndex = 1188;
		this.btnDish.Text = "Web-2";
		this.btnDish.UseVisualStyleBackColor = false;
		this.btnDish.Click += new System.EventHandler(btnDish_Click);
		this.btnWeb3.BackColor = System.Drawing.Color.Thistle;
		this.btnWeb3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.btnWeb3.Cursor = System.Windows.Forms.Cursors.Default;
		this.btnWeb3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.btnWeb3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold);
		this.btnWeb3.ForeColor = System.Drawing.Color.Black;
		this.btnWeb3.Location = new System.Drawing.Point(118, 87);
		this.btnWeb3.Margin = new System.Windows.Forms.Padding(2);
		this.btnWeb3.Name = "btnWeb3";
		this.btnWeb3.RightToLeft = System.Windows.Forms.RightToLeft.No;
		this.btnWeb3.Size = new System.Drawing.Size(56, 23);
		this.btnWeb3.TabIndex = 1197;
		this.btnWeb3.Text = "Web-3";
		this.btnWeb3.UseVisualStyleBackColor = false;
		this.btnWeb3.Click += new System.EventHandler(btnWeb3_Click);
		this.fake_bank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.fake_bank.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.fake_bank.Font = new System.Drawing.Font("Verdana", 9f);
		this.fake_bank.FormattingEnabled = true;
		this.fake_bank.IntegralHeight = false;
		this.fake_bank.Location = new System.Drawing.Point(322, 63);
		this.fake_bank.Margin = new System.Windows.Forms.Padding(2);
		this.fake_bank.Name = "fake_bank";
		this.fake_bank.Size = new System.Drawing.Size(216, 22);
		this.fake_bank.TabIndex = 1190;
		this.fake_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.fake_id.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.fake_id.Font = new System.Drawing.Font("Verdana", 9f);
		this.fake_id.FormattingEnabled = true;
		this.fake_id.Items.AddRange(new object[1] { "XXXXXXX" });
		this.fake_id.Location = new System.Drawing.Point(322, 39);
		this.fake_id.Name = "fake_id";
		this.fake_id.Size = new System.Drawing.Size(92, 22);
		this.fake_id.TabIndex = 1191;
		this.pnlBrand.BackColor = System.Drawing.Color.WhiteSmoke;
		this.pnlBrand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.pnlBrand.Controls.Add(this.lblLoginType);
		this.pnlBrand.Controls.Add(this.lblBank);
		this.pnlBrand.Controls.Add(this.lblBrand);
		this.pnlBrand.Location = new System.Drawing.Point(297, 39);
		this.pnlBrand.Name = "pnlBrand";
		this.pnlBrand.Size = new System.Drawing.Size(220, 73);
		this.pnlBrand.TabIndex = 1198;
		this.lblLoginType.AutoSize = true;
		this.lblLoginType.BackColor = System.Drawing.Color.Transparent;
		this.lblLoginType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblLoginType.ForeColor = System.Drawing.Color.Gray;
		this.lblLoginType.Location = new System.Drawing.Point(161, 53);
		this.lblLoginType.Name = "lblLoginType";
		this.lblLoginType.Size = new System.Drawing.Size(54, 16);
		this.lblLoginType.TabIndex = 1197;
		this.lblLoginType.Text = "WEB-2";
		this.lblBank.AutoSize = true;
		this.lblBank.BackColor = System.Drawing.Color.Transparent;
		this.lblBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblBank.ForeColor = System.Drawing.Color.Gray;
		this.lblBank.Location = new System.Drawing.Point(3, 53);
		this.lblBank.Name = "lblBank";
		this.lblBank.Size = new System.Drawing.Size(110, 16);
		this.lblBank.TabIndex = 1196;
		this.lblBank.Text = "FREECHARGE";
		this.BottomPanel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
		this.BottomPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.BottomPanel.Controls.Add(this.lblTime);
		this.BottomPanel.Controls.Add(this.lblAvailability);
		this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.BottomPanel.Font = new System.Drawing.Font("Verdana", 9f, System.Drawing.FontStyle.Bold);
		this.BottomPanel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.BottomPanel.Location = new System.Drawing.Point(0, 90);
		this.BottomPanel.Margin = new System.Windows.Forms.Padding(2);
		this.BottomPanel.Name = "BottomPanel";
		this.BottomPanel.Size = new System.Drawing.Size(220, 22);
		this.BottomPanel.TabIndex = 1188;
		this.BottomPanel.Visible = false;
		this.lblTime.AutoSize = true;
		this.lblTime.BackColor = System.Drawing.Color.Transparent;
		this.lblTime.Dock = System.Windows.Forms.DockStyle.Right;
		this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblTime.ForeColor = System.Drawing.Color.Black;
		this.lblTime.Location = new System.Drawing.Point(124, 0);
		this.lblTime.Margin = new System.Windows.Forms.Padding(0);
		this.lblTime.Name = "lblTime";
		this.lblTime.Size = new System.Drawing.Size(96, 25);
		this.lblTime.TabIndex = 13;
		this.lblTime.Text = "00:00:00";
		this.lblTime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.lblAvailability.AutoSize = true;
		this.lblAvailability.BackColor = System.Drawing.Color.Transparent;
		this.lblAvailability.Cursor = System.Windows.Forms.Cursors.Hand;
		this.lblAvailability.Font = new System.Drawing.Font("MS UI Gothic", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblAvailability.ForeColor = System.Drawing.Color.Black;
		this.lblAvailability.Location = new System.Drawing.Point(0, 2);
		this.lblAvailability.Name = "lblAvailability";
		this.lblAvailability.Size = new System.Drawing.Size(99, 15);
		this.lblAvailability.TabIndex = 1;
		this.lblAvailability.Text = "Get Availability";
		this.lblAvailability.Visible = false;
		this.pictureBox2.Location = new System.Drawing.Point(27, 321);
		this.pictureBox2.Name = "pictureBox2";
		this.pictureBox2.Size = new System.Drawing.Size(223, 110);
		this.pictureBox2.TabIndex = 1194;
		this.pictureBox2.TabStop = false;
		this.button2.BackColor = System.Drawing.Color.GhostWhite;
		this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.button2.Cursor = System.Windows.Forms.Cursors.Default;
		this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold);
		this.button2.ForeColor = System.Drawing.Color.Black;
		this.button2.Location = new System.Drawing.Point(176, 87);
		this.button2.Margin = new System.Windows.Forms.Padding(2);
		this.button2.Name = "button2";
		this.button2.RightToLeft = System.Windows.Forms.RightToLeft.No;
		this.button2.Size = new System.Drawing.Size(44, 23);
		this.button2.TabIndex = 1199;
		this.button2.Text = "App";
		this.button2.UseVisualStyleBackColor = false;
		this.button2.Click += new System.EventHandler(button2_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.BackColor = System.Drawing.Color.FloralWhite;
		base.Controls.Add(this.button2);
		base.Controls.Add(this.pnlBrand);
		base.Controls.Add(this.BottomPanel);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.check_avl);
		base.Controls.Add(this.btnCancel);
		base.Controls.Add(this.TopPanel);
		base.Controls.Add(this.lblTrainNo);
		base.Controls.Add(this.lblClass);
		base.Controls.Add(this.lblJourney);
		base.Controls.Add(this.lblDate);
		base.Controls.Add(this.lbl_bnk);
		base.Controls.Add(this.lbl_slot);
		base.Controls.Add(this.lbl_Month);
		base.Controls.Add(this.lbl_Date);
		base.Controls.Add(this.lbl_Detail);
		base.Controls.Add(this.PanelPnr);
		base.Controls.Add(this.lbl_brand);
		base.Controls.Add(this.lbl_status);
		base.Controls.Add(this.lbl_time);
		base.Controls.Add(this.pictureBox2);
		base.Controls.Add(this.WebLogin);
		base.Controls.Add(this.panel2);
		base.Controls.Add(this.HeaderPanel1);
		base.Controls.Add(this.lblPnr);
		base.Controls.Add(this.Panel1);
		base.Controls.Add(this.lblTktName);
		base.Controls.Add(this.lblInfo);
		base.Controls.Add(this.B3AAA);
		base.Controls.Add(this.fake_bank);
		base.Controls.Add(this.fake_id);
		base.Controls.Add(this.btnEdit);
		base.Controls.Add(this.BtnOpenPair);
		base.Controls.Add(this.btnWeb3);
		base.Controls.Add(this.btnDish);
		base.Controls.Add(this.AppLogin_);
		base.Controls.Add(this.cboQuota);
		base.Controls.Add(this.chkConfirmation);
		base.Controls.Add(this.cboID);
		base.Controls.Add(this.cboSlot);
		base.Controls.Add(this.cboGateway);
		base.Margin = new System.Windows.Forms.Padding(2);
		base.Name = "TCntrl";
		base.Size = new System.Drawing.Size(220, 112);
		base.Load += new System.EventHandler(TCntrl_Load_1);
		this.TopPanel.ResumeLayout(false);
		this.HeaderPanel1.ResumeLayout(false);
		this.Panel1.ResumeLayout(false);
		this.Panel1.PerformLayout();
		this.PanelPnr.ResumeLayout(false);
		this.PanelPnr.PerformLayout();
		this.pnlBrand.ResumeLayout(false);
		this.pnlBrand.PerformLayout();
		this.BottomPanel.ResumeLayout(false);
		this.BottomPanel.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private void cboGateway_MouseMove(object sender, MouseEventArgs e)
	{
		if (StatClass.VideoMode)
		{
			cboGateway.ForeColor = Color.Black;
		}
	}

	public static bool checkDotNet()
	{
		bool result = false;
		try
		{
			string text = string.Empty;
			string text2 = "dotnet --list-runtimes";
			string value = text2;
			ProcessStartInfo processStartInfo = new ProcessStartInfo();
			string fileName = "cmd.exe";
			processStartInfo.FileName = fileName;
			processStartInfo.RedirectStandardInput = true;
			processStartInfo.RedirectStandardOutput = true;
			processStartInfo.RedirectStandardError = true;
			processStartInfo.UseShellExecute = false;
			processStartInfo.CreateNoWindow = true;
			ProcessStartInfo startInfo = processStartInfo;
			using (Process process = new Process
			{
				StartInfo = startInfo
			})
			{
				process.Start();
				process.StandardInput.WriteLine(value);
				process.StandardInput.Flush();
				process.StandardInput.Close();
				text = process.StandardOutput.ReadToEnd();
				process.WaitForExit();
			}
			string text3 = text;
			string value2 = "Microsoft.AspNetCore.App";
			bool flag = text3.Contains(value2);
			string text4 = text;
			string text5 = "Microsoft.NETCore.App";
		}
		catch
		{
			result = true;
		}
		return result;
	}

	private void cboGateway_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (cboGateway.SelectedIndex == 0)
		{
			return;
		}
		string text = cboGateway.SelectedItem.ToString();
		string value = "@freecharge";
		if (text.Contains(value))
		{
			checkDotNet();
		}
		string value2 = "########";
		if (text.Contains(value2))
		{
			return;
		}
		string text2 = Program.dictionary_00[text];
		try
		{
			string value3 = "SBI_";
			if (text.Contains(value3))
			{
				string value4 = "_DC";
				if (!text.Contains(value4))
				{
					goto IL_03c5;
				}
				string value5 = "_CC";
				if (!text.Contains(value5))
				{
					goto IL_03c5;
				}
			}
			else
			{
				string value6 = "HDFC_";
				if (!text.Contains(value6))
				{
					string value7 = "ICICI_";
					if (text.Contains(value7))
					{
						string value8 = "_DC";
						if (!text.Contains(value8))
						{
							goto IL_03f3;
						}
						string value9 = "_CC";
						if (!text.Contains(value9))
						{
							goto IL_03f3;
						}
					}
					else
					{
						string value10 = "IRCTC_WALLET";
						if (text.Contains(value10))
						{
							string[] array = new string[1];
							string text3 = "_";
							array[0] = text3;
							string[] array2 = text.Split(array, StringSplitOptions.None);
							eWallet_irctc = array2[1];
						}
						else
						{
							string value11 = "YES_";
							if (text.Contains(value11))
							{
								string value12 = "_DC";
								if (!text.Contains(value12))
								{
									goto IL_0326;
								}
								string value13 = "_CC";
								if (!text.Contains(value13))
								{
									goto IL_0326;
								}
							}
							else
							{
								string value14 = "PAYTM_";
								if (!text.Contains(value14))
								{
									string value15 = "E-WALLET_";
									if (text.Contains(value15))
									{
										goto IL_02b5;
									}
									string value16 = "LOYALTY_";
									if (text.Contains(value16))
									{
										goto IL_02b5;
									}
								}
								else
								{
									string value17 = "_DC";
									if (!text.Contains(value17))
									{
										goto IL_02f2;
									}
									string value18 = "_CC";
									if (!text.Contains(value18))
									{
										goto IL_02f2;
									}
								}
							}
						}
					}
				}
				else
				{
					string value19 = "_DC";
					if (!text.Contains(value19))
					{
						goto IL_0377;
					}
					string value20 = "_CC";
					if (!text.Contains(value20))
					{
						goto IL_0377;
					}
				}
			}
			goto end_IL_006c;
			IL_02b5:
			if (!text.Contains(this.string_2))
			{
				string text4 = "Please Select Valid Irctc Account for use this Payment Getways.!";
				MessageBox.Show(text4);
				cboGateway.SelectedIndex = 0;
				return;
			}
			goto end_IL_006c;
			IL_02f2:
			string[] array3 = new string[1];
			string text5 = "||";
			array3[0] = text5;
			if (text2.Split(array3, StringSplitOptions.None).Length > 3)
			{
			}
			goto end_IL_006c;
			IL_0326:
			string[] array4 = new string[1];
			string text6 = "||";
			array4[0] = text6;
			if (text2.Split(array4, StringSplitOptions.None).Length < 3)
			{
				string text7 = "Please Bypass YES Bank First Then Use it, Other Wise Your Booking May Fail.!";
				MessageBox.Show(text7);
				cboGateway.SelectedIndex = 0;
				return;
			}
			goto end_IL_006c;
			IL_0377:
			string[] array5 = new string[1];
			string text8 = "||";
			array5[0] = text8;
			if (text2.Split(array5, StringSplitOptions.None).Length < 3)
			{
				string text9 = "Please Bypass HDFC Bank First Then Use it, Other Wise Your Booking May Fail.!";
				MessageBox.Show(text9);
				cboGateway.SelectedIndex = 0;
				return;
			}
			goto end_IL_006c;
			IL_03c5:
			string[] array6 = new string[1];
			string text10 = "||";
			array6[0] = text10;
			if (text2.Split(array6, StringSplitOptions.None).Length >= 4)
			{
			}
			goto end_IL_006c;
			IL_03f3:
			string[] array7 = new string[1];
			string text11 = "||";
			array7[0] = text11;
			if (text2.Split(array7, StringSplitOptions.None).Length < 3)
			{
				string text12 = "Please Bypass ICICI Bank First Then Use it, Other Wise Your Booking May Fail.!";
				MessageBox.Show(text12);
				cboGateway.SelectedIndex = 0;
				return;
			}
			end_IL_006c:;
		}
		catch
		{
		}
		if (class48_0.string_23 != text)
		{
			class48_0.string_23 = text;
			string text13 = class48_0.string_23;
			string string_ = class48_0.string_233;
			if (!string.IsNullOrEmpty(string_))
			{
				string text14 = text13;
				string text15 = "-+-";
				text13 = text14 + text15 + string_;
			}
			class48_0.string_24 = text2;
			string string_2 = class48_0.string_24;
			string string_3 = class48_0.string_244;
			if (!string.IsNullOrEmpty(string_3))
			{
				string text16 = "-+-";
				_ = string_2 + text16 + string_3;
			}
			method_7(text13, string_3, lblTktName.Text);
		}
		Label label = lbl_bnk;
		string text17 = "Bnk: ";
		label.Text = text17 + GetBankName(cboGateway.SelectedItem.ToString());
	}

	private void method_7(string string_3, string string_4, string string_5)
	{
		try
		{
			string[] array = new string[7];
			string text = "UPDATE [TBL_TKT] SET [TKT_BANKSAVEAS] = '";
			array[0] = text;
			array[1] = string_3;
			string text2 = "', [TKT_BANKDETAILS] = '";
			array[2] = text2;
			array[3] = string_4;
			string text3 = "' WHERE [TKT_NAME] = '";
			array[4] = text3;
			array[5] = string_5;
			string text4 = "'";
			array[6] = text4;
			Staticm.smethod_UpdateFieldValue(string.Concat(array));
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void B0AAA(object sender, EventArgs e)
	{
		int num = 0;
		try
		{
			if (string.IsNullOrEmpty(Traindata[0, 0]))
			{
				Invoke(new ChangeTextsSafe(ClearTextinCombo), "");
				Invoke(new ChangeTextsSafe(AddTextinCombo), class48_0.string_2);
				return;
			}
			while (cboTrain.SelectedItem.ToString() != Traindata[num, 0])
			{
				num++;
				if (string.IsNullOrEmpty(Traindata[num, 0]) || Traindata[num, 0] == null)
				{
					break;
				}
			}
			class48_0.string_2a = Traindata[num, 0];
			class48_0.string_0a = Traindata[num, 2];
			class48_0.string_1a = Traindata[num, 3];
			class48_0.string_0 = class48_0.string_0a;
			class48_0.string_1 = class48_0.string_1a;
			class48_0.string_2 = class48_0.string_2a;
			if (class48_0.string_2 != class48_0.string_2a)
			{
				if (class48_0.string_0 != class48_0.string_3)
				{
					class48_0.string_3 = class48_0.string_0a;
				}
				if (class48_0.string_0 == class48_0.string_3)
				{
					Label label = lblJourney;
					string text = class48_0.string_0;
					string text2 = "_";
					label.Text = text + text2 + class48_0.string_1;
				}
				else
				{
					Label label2 = lblJourney;
					string text3 = class48_0.string_0;
					string text4 = "_";
					label2.Text = text3 + text4 + class48_0.string_1;
				}
			}
		}
		catch
		{
		}
	}

	public bool AddTRaininCombo()
	{
		try
		{
			Invoke(new ChangeTextsSafe(ClearTextinCombo), "");
			string[] array = class48_0.string_38.Split('^');
			for (int i = 0; i < array.Length - 1; i++)
			{
				string[] array2 = array[i].Split('~');
				for (int j = 0; j < array2.Length - 1; j++)
				{
					Traindata[i, j] = array2[j];
				}
			}
			if (string.IsNullOrEmpty(Traindata[0, 0]))
			{
				return false;
			}
			int num = 0;
			do
			{
				Invoke(new ChangeTextsSafe(AddTextinCombo), Traindata[num, 0]);
				num++;
			}
			while (!string.IsNullOrEmpty(Traindata[num, 0]) && Traindata[num, 0] != "");
		}
		catch
		{
		}
		return false;
	}

	public void AddTextinCombo(string Trn)
	{
		cboTrain.Items.Add(Trn);
	}

	public void ClearTextinCombo(string Trn)
	{
		cboTrain.Items.Clear();
	}

	private void C0AA0(object sender, MouseEventArgs e)
	{
		if (StatClass.VideoMode)
		{
			cboGateway.ForeColor = Color.Black;
		}
	}

	private void cboID_MouseMove(object sender, MouseEventArgs e)
	{
		if (StatClass.VideoMode)
		{
			cboID.ForeColor = Color.Black;
		}
	}

	private void cboSlot_MouseMove(object sender, MouseEventArgs e)
	{
		if (StatClass.VideoMode)
		{
			cboSlot.ForeColor = Color.Black;
		}
	}

	private void cboID_MouseLeave(object sender, EventArgs e)
	{
		if (StatClass.VideoMode)
		{
			cboID.ForeColor = Color.LightGray;
		}
	}

	private void cboSlot_MouseLeave(object sender, EventArgs e)
	{
		if (StatClass.VideoMode)
		{
			cboID.ForeColor = Color.LightGray;
		}
	}

	private void cboGateway_MouseLeave(object sender, EventArgs e)
	{
		if (StatClass.VideoMode)
		{
			cboID.ForeColor = Color.LightGray;
		}
	}

	public void CloseOtherThanPnrBookWindow(object sender)
	{
		try
		{
			string name = base.Name;
			string text = lblTktName.Text;
			_ = chkConfirmation.Checked;
			List<Form> list = new List<Form>();
			foreach (Form openForm in Application.OpenForms)
			{
				list.Add(openForm);
			}
			foreach (Form item in list)
			{
				try
				{
					string name2 = item.Name;
					string text2 = "frmProcessTicket";
					if (!(name2 == text2))
					{
						continue;
					}
					_ = item.Controls.Count;
					ControlCollection controls = item.Controls;
					string key = "pnl";
					Control control = controls[key];
					int count = control.Controls.Count;
					for (int i = 0; i < count; i++)
					{
						Control control2 = control.Controls[i];
						string name3 = control2.Name;
						ControlCollection controls2 = control2.Controls;
						string key2 = "lblTktName";
						string text3 = ((Label)controls2[key2]).Text;
						_ = control2.Controls.Count;
						if (name != name3 && text == text3)
						{
							ControlCollection controls3 = control2.Controls;
							string key3 = "btnCancel";
							((Button)controls3[key3]).PerformClick();
							Application.DoEvents();
							Thread.Sleep(400);
						}
					}
				}
				catch
				{
				}
			}
		}
		catch
		{
		}
	}

	private void chkConfirmation_MouseClick(object sender, MouseEventArgs e)
	{
		if (BtnOpenPair.Visible)
		{
			if (!Class45.ManagerDashborad)
			{
				method_8(sender);
				string[] array = new string[6];
				string text = "Nget_chkConfirmation-";
				array[0] = text;
				array[1] = base.Name;
				string text2 = ",";
				array[2] = text2;
				array[3] = lblTktName.Text;
				string text3 = ",";
				array[4] = text3;
				array[5] = chkConfirmation.Checked.ToString();
				Clipboard.SetText(string.Concat(array));
			}
			else
			{
				method_8(sender);
			}
		}
	}

	private void chkConfirmation_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (BtnOpenPair.Visible)
		{
			if (!Class45.ManagerDashborad)
			{
				string[] array = new string[6];
				string text = "Nget_chkConfirmation-";
				array[0] = text;
				array[1] = base.Name;
				string text2 = ",";
				array[2] = text2;
				array[3] = lblTktName.Text;
				string text3 = ",";
				array[4] = text3;
				array[5] = chkConfirmation.Checked.ToString();
				Clipboard.SetText(string.Concat(array));
			}
			else
			{
				method_8(sender);
			}
		}
	}

	private void method_8(object object_1)
	{
		string name = base.Name;
		string text = lblTktName.Text;
		bool @checked = chkConfirmation.Checked;
		List<Form> list = new List<Form>();
		foreach (Form openForm in Application.OpenForms)
		{
			list.Add(openForm);
		}
		foreach (Form item in list)
		{
			string name2 = item.Name;
			string text2 = "frmProcessTicket";
			if (!(name2 == text2))
			{
				continue;
			}
			try
			{
				_ = item.Controls.Count;
				ControlCollection controls = item.Controls;
				string key = "pnl";
				Control control = controls[key];
				int count = control.Controls.Count;
				for (int i = 0; i < count; i++)
				{
					Control control2 = control.Controls[i];
					string name3 = control2.Name;
					ControlCollection controls2 = control2.Controls;
					string key2 = "lblTktName";
					string text3 = controls2[key2].Text;
					_ = control2.Controls.Count;
					if (name != name3 && text == text3)
					{
						ControlCollection controls3 = control2.Controls;
						string key3 = "cboGateway";
						((ComboBox)controls3[key3]).SelectedItem.ToString();
						ControlCollection controls4 = control2.Controls;
						string key4 = "chkConfirmation";
						((CheckBox)controls4[key4]).Checked = @checked;
					}
				}
			}
			catch
			{
			}
		}
	}

	private void lblAvailability_MouseClick0(object sender, MouseEventArgs e)
	{
		if (BtnOpenPair.Visible)
		{
			if (!Class45.ManagerDashborad)
			{
				method_9(sender);
				string[] array = new string[6];
				string text = "Nget_check_avl-";
				array[0] = text;
				array[1] = base.Name;
				string text2 = ",";
				array[2] = text2;
				array[3] = lblTktName.Text;
				string text3 = ",";
				array[4] = text3;
				array[5] = check_avl.Checked.ToString();
				Clipboard.SetText(string.Concat(array));
			}
			else
			{
				method_9(sender);
			}
		}
	}

	private void method_9(object object_1)
	{
		string name = base.Name;
		string text = lblTktName.Text;
		bool @checked = check_avl.Checked;
		List<Form> list = new List<Form>();
		foreach (Form openForm in Application.OpenForms)
		{
			list.Add(openForm);
		}
		foreach (Form item in list)
		{
			string name2 = item.Name;
			string text2 = "frmProcessTicket";
			if (!(name2 == text2))
			{
				continue;
			}
			try
			{
				_ = item.Controls.Count;
				ControlCollection controls = item.Controls;
				string key = "pnl";
				Control control = controls[key];
				int count = control.Controls.Count;
				for (int i = 0; i < count; i++)
				{
					Control control2 = control.Controls[i];
					string name3 = control2.Name;
					ControlCollection controls2 = control2.Controls;
					string key2 = "lblTktName";
					string text3 = controls2[key2].Text;
					_ = control2.Controls.Count;
					if (name != name3 && text == text3)
					{
						ControlCollection controls3 = control2.Controls;
						string key3 = "cboGateway";
						((ComboBox)controls3[key3]).SelectedItem.ToString();
						ControlCollection controls4 = control2.Controls;
						string key4 = "check_avl";
						((CheckBox)controls4[key4]).Checked = @checked;
					}
				}
			}
			catch
			{
			}
		}
	}

	private void B1AAA(object sender, EventArgs e)
	{
		btnEdit.PerformClick();
	}

	private void C1AA0(object sender, LinkLabelLinkClickedEventArgs e)
	{
		string text = WLlinkLabel.Text;
		string text2 = "WL Allow";
		bool flag;
		if (text == text2)
		{
			flag = true;
			LinkLabel wLlinkLabel = WLlinkLabel;
			string text3 = "WL Stop";
			wLlinkLabel.Text = text3;
		}
		else
		{
			flag = false;
			LinkLabel wLlinkLabel2 = WLlinkLabel;
			string text4 = "WL Allow";
			wLlinkLabel2.Text = text4;
		}
		string[] array = new string[5];
		string text5 = "UPDATE [TBL_TKT] SET [TKT_ISCONFIRM] = '";
		array[0] = text5;
		array[1] = flag.ToString();
		string text6 = "' WHERE [TKT_NAME] = '";
		array[2] = text6;
		array[3] = base.Name;
		string text7 = "'";
		array[4] = text7;
		Staticm.smethod_UpdateFieldValue(string.Concat(array));
		mCOMM mcommInstance_ = Program.mcommInstance_;
		string name = base.Name;
		string text8 = " WL_Status";
		mcommInstance_.SetData(name + text8, WLlinkLabel.Text);
	}

	private void EditlinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		btnEdit.PerformClick();
	}

	private void btnMinize_Click(object sender, EventArgs e)
	{
		if (B2AAA != null)
		{
			B2AAA(this, e);
		}
	}

	private void cboSlot_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			string text = cboSlot.SelectedItem.ToString();
			string value = "XX";
			if (!text.Contains(value))
			{
				Button button = btnSlotNo;
				string text2 = "T-";
				string value2 = "-";
				button.Text = text2 + text.Substring(text.IndexOf(value2) + 1);
			}
		}
		catch
		{
			cboSlot.SelectedIndex = 1;
		}
	}

	private void btnSlotNo_Click(object sender, EventArgs e)
	{
		try
		{
			string text = btnSlotNo.Text;
			string oldValue = "T-";
			int num = int.Parse(text.Replace(oldValue, ""));
			string text2;
			if (num + 1 <= Program.int_Slot)
			{
				text2 = (num + 1).ToString();
			}
			else
			{
				string text3 = "1";
				text2 = text3;
			}
			string text4 = text2;
			Button button = btnSlotNo;
			string text5 = "T-";
			button.Text = text5 + text4;
			cboSlot.SelectedIndex = int.Parse(text4);
		}
		catch
		{
		}
	}

	private void BtnOpenPair_Click(object sender, EventArgs e)
	{
		blb = true;
		if (eventHandler_3 != null)
		{
			eventHandler_3(this, e);
		}
	}

	private void CboQuota_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(CLc))
		{
			CLc = lblClass.Text;
		}
		Label label = lblClass;
		string cLc = CLc;
		string text = ":";
		label.Text = cLc + text + cboQuota.SelectedItem.ToString();
	}

	private void button1_Click_1(object sender, EventArgs e)
	{
		if (eventHandler_3 != null)
		{
			eventHandler_3(this, e);
		}
	}

	private void lblStatus_Click(object sender, EventArgs e)
	{
		MessageBox.Show(lblStatus.Text);
	}

	private void button2_Click(object sender, EventArgs e)
	{
		string str = cboGateway.SelectedItem.ToString();
		string text = "APP";
		if (button2.Text == "Mix")
		{
			text = "Mix";
		}
		if (!checkPaymet(str, text))
		{
			StatClass.ApptLogin = false;
			StatClass.WebLogin = false;
			string text2 = "Selected Payment Gateway is Not Working\r\nPlease Choose Another Payment Option";
			MessageBox.Show(text2);
			return;
		}
		Betalogin = false;
		Dishalogin = false;
		web3 = false;
		Applogin = true;
		loginType = 5;
		if (text == "Mix")
		{
			Applogin = false;
			mixlogin = true;
			loginType = 6;
		}
		ChnageColour_();
		Label label = lbl_status;
		string text3 = "SUCCESS-APP";
		label.Text = text3;
		method_4();
	}
}
