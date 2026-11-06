using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Booking;
using Bunifu.Framework.UI;

namespace APP_FRAMEWORK;

internal class frmSerch_Train : Form
{
	internal string string_0;

	internal string string_1;

	internal string string_2;

	internal string string_3;

	internal string string_4;

	internal string string_5;

	internal string string_6;

	internal DateTime dateTime_0;

	private string string_7;

	private string string_8;

	private string string_9;

	private string B0AAA;

	private Color C0AA0;

	private Color color_0;

	private Color color_1;

	private BorderStyle borderStyle_0;

	private string string_10;

	private string string_11;

	private string string_12;

	private bool bool_0;

	private Color color_2;

	public static bool bool_1;

	private static bool C1AA0;

	private IContainer icontainer_0;

	private IDisposable B1AAA;

	private BackgroundWorker backgroundWorker_0;

	private Button btnSelect;

	private Label label20;

	private Label label10;

	private Label label11;

	private Label label12;

	private Label label13;

	private Label label14;

	private Label label15;

	private Label label16;

	private Label B2AAA;

	private Label C2AA0;

	private Label label19;

	private Label label21;

	private Label label22;

	private Label label23;

	private Label label24;

	private Label label25;

	private Label label26;

	private Label label3;

	private Label label4;

	private Label label5;

	private Label B3AAA;

	private Label C3AA0;

	private Label label8;

	private Label label9;

	private Panel pnlHeader;

	private Panel pnlMain;

	private RadioButton rdPT;

	private RadioButton rdCK;

	private RadioButton rdLD;

	private RadioButton rdGN;

	private RadioButton rdPG;

	private CheckBox chkIRCTC;

	public Label whosent;

	private Panel B4AAA;

	private Label C4AA0;

	private Panel pnlloader;

	private PictureBox pictureBox1;

	private BunifuElipse bunifuElipse_0;

	internal GroupBox grpOpen;

	private Label label2;

	private Label label30;

	private PictureBox GetSeatAvlPic;

	private IContainer components;

	private Label lblfare;

	private Label label29;

	private Label label28;

	private BunifuImageButton btnClose;

	private Label label27;

	public frmSerch_Train()
	{
		string_6 = "";
		string_7 = "";
		string_8 = "";
		string_9 = "";
		B0AAA = "";
		string_10 = "";
		string_11 = "";
		string_12 = "";
		InitializeComponent();
		pnlHeader.MouseDown += StatClass.Header_MouseDown;
		pnlHeader.MouseMove += StatClass.Header_MouseMove;
		pnlHeader.MouseUp += StatClass.Header_MouseUp;
		string htmlColor = "#EBF1FF";
		C0AA0 = ColorTranslator.FromHtml(htmlColor);
		string htmlColor2 = "#DCE3FC";
		color_0 = ColorTranslator.FromHtml(htmlColor2);
		string htmlColor3 = "#195AF7";
		color_1 = ColorTranslator.FromHtml(htmlColor3);
		color_2 = Color.Gold;
	}

	private void method_0(string string_14, int int_0, int int_1, int int_2, int int_3)
	{
		Color c0AA = color_0;
		if (int_3 % 2 == 0)
		{
			c0AA = C0AA0;
		}
		if (bool_0 && int_0 < 50)
		{
			c0AA = color_2;
		}
		Label label = new Label();
		label.Text = string_14;
		string text = "label";
		label.Name = text + string_14;
		label.Location = new Point(int_0, int_2 + int_2 * int_3 + (int_3 + int_3 + int_3));
		label.BorderStyle = borderStyle_0;
		string familyName = "Arial";
		label.Font = new Font(familyName, 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
		label.TextAlign = ContentAlignment.MiddleCenter;
		label.Size = new Size(int_1, int_2);
		label.BackColor = c0AA;
		pnlMain.Controls.Add(label);
	}

	private void method_1(string string_14, int int_0, int int_1, int int_2, int int_3)
	{
		Color c0AA = color_0;
		if (int_3 % 2 == 0)
		{
			c0AA = C0AA0;
		}
		Label label = new Label();
		string text = null;
		switch (int_0)
		{
		case 627:
			text = string_14.Substring(2, 1);
			break;
		case 599:
			text = string_14.Substring(1, 1);
			break;
		case 571:
			text = string_14.Substring(0, 1);
			break;
		case 683:
			text = string_14.Substring(4, 1);
			break;
		case 655:
			text = string_14.Substring(3, 1);
			break;
		case 739:
			text = string_14.Substring(6, 1);
			break;
		case 711:
			text = string_14.Substring(5, 1);
			break;
		}
		string text2 = text;
		string text3 = "0";
		if (!(text2 == text3))
		{
			string text4 = "Y";
			label.Text = text4;
			label.ImageAlign = ContentAlignment.MiddleCenter;
		}
		else
		{
			string text5 = "X";
			label.Text = text5;
			label.ImageAlign = ContentAlignment.MiddleCenter;
		}
		string text6 = "label";
		label.Name = text6 + string_14;
		label.Location = new Point(int_0, int_2 + int_2 * int_3 + (int_3 + int_3 + int_3));
		label.BorderStyle = borderStyle_0;
		string familyName = "Arial";
		label.Font = new Font(familyName, 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		label.TextAlign = ContentAlignment.MiddleCenter;
		label.Size = new Size(int_1, int_2);
		label.BackColor = c0AA;
		pnlMain.Controls.Add(label);
	}

	private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
	{
		method_7();
	}

	private void method_3()
	{
		ref DateTime reference = ref dateTime_0;
		string text = "ddd";
		string text2 = reference.ToString(text);
		string text3 = text2;
		switch (PrivateImp.ComputeStringHash(text3))
		{
		case 950479479u:
		{
			string text14 = "Sat";
			if (text3 == text14)
			{
				string text15 = "S";
				text2 = text15;
			}
			break;
		}
		case 644086760u:
		{
			string text6 = "Fri";
			if (text3 == text6)
			{
				string text7 = "F";
				text2 = text7;
			}
			break;
		}
		case 110702732u:
		{
			string text10 = "Thu";
			if (text3 == text10)
			{
				string text11 = "TH";
				text2 = text11;
			}
			break;
		}
		case 1319338721u:
		{
			string text16 = "Mon";
			if (text3 == text16)
			{
				string text17 = "M";
				text2 = text17;
			}
			break;
		}
		case 1121507073u:
		{
			string text12 = "Sun";
			if (text3 == text12)
			{
				string text13 = "SU";
				text2 = text13;
			}
			break;
		}
		case 4206162981u:
		{
			string text8 = "Tue";
			if (text3 == text8)
			{
				string text9 = "T";
				text2 = text9;
			}
			break;
		}
		case 1952733015u:
		{
			string text4 = "Wed";
			if (text3 == text4)
			{
				string text5 = "W";
				text2 = text5;
			}
			break;
		}
		}
		string_9 = text2;
	}

	private void backgroundWorker_0_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
	{
		pnlloader.Visible = false;
		method_3();
		string text = this.string_9;
		string text2 = this.string_7;
		string value = "No direct trains found";
		if (text2.Contains(value))
		{
			string text3 = "No Train Found On Selected Route.\n\nPlease Select Other Route and Try Again later. ";
			string caption = "No Train";
			MessageBox.Show(text3, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		else
		{
			if (Class33.Jrny_Traindata == null)
			{
				return;
			}
			pnlMain.SuspendLayout();
			SuspendLayout();
			int num = 0;
			int num2 = 0;
			while (Class33.Jrny_Traindata[num, 0] != null)
			{
				string text4 = Class33.Jrny_Traindata[num, 7];
				string text5 = "SU";
				if (!(text != text5))
				{
					if (!text4.Contains(text))
					{
						num++;
						continue;
					}
				}
				else
				{
					string text6 = " ";
					if (!text4.Contains(text + text6))
					{
						num++;
						continue;
					}
				}
				bool_0 = false;
				string text7 = Class33.Jrny_Traindata[num, 12];
				string text8 = "10000010000";
				if (text7 == text8)
				{
					bool_0 = true;
				}
				string string_ = Class33.Jrny_Traindata[num, 0];
				int int_ = label4.Location.X;
				int int_2 = num2;
				method_0(string_, int_, 69, 24, int_2);
				string string_2 = Class33.Jrny_Traindata[num, 1];
				int int_3 = label5.Location.X;
				int int_4 = num2;
				method_0(string_2, int_3, 128, 24, int_4);
				string string_3 = Class33.Jrny_Traindata[num, 2];
				int int_5 = B3AAA.Location.X;
				int int_6 = num2;
				method_0(string_3, int_5, 47, 24, int_6);
				string string_4 = Class33.Jrny_Traindata[num, 4];
				int int_7 = C3AA0.Location.X;
				int int_8 = num2;
				method_0(string_4, int_7, 70, 24, int_8);
				string string_5 = Class33.Jrny_Traindata[num, 3];
				int int_9 = label8.Location.X;
				int int_10 = num2;
				method_0(string_5, int_9, 49, 24, int_10);
				string string_6 = Class33.Jrny_Traindata[num, 5];
				int int_11 = label9.Location.X;
				int int_12 = num2;
				method_0(string_6, int_11, 62, 24, int_12);
				string string_7 = Class33.Jrny_Traindata[num, 6];
				int int_13 = label10.Location.X;
				int int_14 = num2;
				method_0(string_7, int_13, 76, 24, int_14);
				string string_8 = Class33.Jrny_Traindata[num, 6];
				int int_15 = label11.Location.X;
				int int_16 = num2;
				method_0(string_8, int_15, 79, 24, int_16);
				string oldValue = "M";
				string newValue = "1";
				string text9 = text4.Replace(oldValue, newValue);
				string oldValue2 = "TH";
				string newValue2 = "1";
				string text10 = text9.Replace(oldValue2, newValue2);
				string oldValue3 = "SU";
				string newValue3 = "1";
				string text11 = text10.Replace(oldValue3, newValue3);
				string oldValue4 = "T";
				string newValue4 = "1";
				string text12 = text11.Replace(oldValue4, newValue4);
				string oldValue5 = "W";
				string newValue5 = "1";
				string text13 = text12.Replace(oldValue5, newValue5);
				string oldValue6 = "F";
				string newValue6 = "1";
				string text14 = text13.Replace(oldValue6, newValue6);
				string oldValue7 = "S";
				string newValue7 = "1";
				string text15 = text14.Replace(oldValue7, newValue7);
				string oldValue8 = "-";
				string newValue8 = "0";
				string string_9;
				string text16 = (string_9 = text15.Replace(oldValue8, newValue8));
				int int_17 = label12.Location.X;
				int int_18 = num2;
				method_1(string_9, int_17, 29, 24, int_18);
				string string_10 = text16;
				int int_19 = label13.Location.X;
				int int_20 = num2;
				method_1(string_10, int_19, 29, 24, int_20);
				string string_11 = text16;
				int int_21 = label14.Location.X;
				int int_22 = num2;
				method_1(string_11, int_21, 29, 24, int_22);
				string string_12 = text16;
				int int_23 = label15.Location.X;
				int int_24 = num2;
				method_1(string_12, int_23, 29, 24, int_24);
				string string_13 = text16;
				int int_25 = label16.Location.X;
				int int_26 = num2;
				method_1(string_13, int_25, 29, 24, int_26);
				string string_14 = text16;
				int int_27 = B2AAA.Location.X;
				int int_28 = num2;
				method_1(string_14, int_27, 29, 24, int_28);
				string string_15 = text16;
				int int_29 = C2AA0.Location.X;
				int int_30 = num2;
				method_1(string_15, int_29, 29, 24, int_30);
				string[] array = new string[9]
				{
					Class33.Jrny_Traindata[num, 0],
					null,
					null,
					null,
					null,
					null,
					null,
					null,
					null
				};
				string text17 = ":";
				array[1] = text17;
				array[2] = Class33.Jrny_Traindata[num, 1];
				string text18 = ":";
				array[3] = text18;
				array[4] = Class33.Jrny_Traindata[num, 2];
				string text19 = ":";
				array[5] = text19;
				array[6] = Class33.Jrny_Traindata[num, 3];
				string text20 = ":";
				array[7] = text20;
				array[8] = Class33.Jrny_Traindata[num, 9];
				string text21 = string.Concat(array);
				string text22 = Class33.Jrny_Traindata[num, 8];
				string value2 = "1A";
				string text24;
				if (text22.Contains(value2))
				{
					string text23 = "1";
					text24 = text23;
				}
				else
				{
					string text25 = "0";
					text24 = text25;
				}
				string text26 = text24;
				string value3 = "2A";
				string text28;
				if (text22.Contains(value3))
				{
					string text27 = "1";
					text28 = text26 + text27;
				}
				else
				{
					string text29 = "0";
					text28 = text26 + text29;
				}
				string text30 = text28;
				string value4 = "3A";
				string text32;
				if (text22.Contains(value4))
				{
					string text31 = "1";
					text32 = text30 + text31;
				}
				else
				{
					string text33 = "0";
					text32 = text30 + text33;
				}
				string text34 = text32;
				string value5 = "CC";
				string text36;
				if (text22.Contains(value5))
				{
					string text35 = "1";
					text36 = text34 + text35;
				}
				else
				{
					string text37 = "0";
					text36 = text34 + text37;
				}
				string text38 = text36;
				string value6 = "FC";
				string text40;
				if (text22.Contains(value6))
				{
					string text39 = "1";
					text40 = text38 + text39;
				}
				else
				{
					string text41 = "0";
					text40 = text38 + text41;
				}
				string text42 = text40;
				string value7 = "SL";
				string text44;
				if (text22.Contains(value7))
				{
					string text43 = "1";
					text44 = text42 + text43;
				}
				else
				{
					string text45 = "0";
					text44 = text42 + text45;
				}
				string text46 = text44;
				string value8 = "2S";
				string text48;
				if (text22.Contains(value8))
				{
					string text47 = "1";
					text48 = text46 + text47;
				}
				else
				{
					string text49 = "0";
					text48 = text46 + text49;
				}
				string text50 = text48;
				string value9 = "3E";
				string text52;
				if (text22.Contains(value9))
				{
					string text51 = "1";
					text52 = text50 + text51;
				}
				else
				{
					string text53 = "0";
					text52 = text50 + text53;
				}
				string text54 = text52;
				string value10 = "EA";
				string text56;
				if (text22.Contains(value10))
				{
					string text55 = "1";
					text56 = text54 + text55;
				}
				else
				{
					string text57 = "0";
					text56 = text54 + text57;
				}
				string text58 = text56;
				string value11 = "EC";
				string text60;
				if (text22.Contains(value11))
				{
					string text59 = "1";
					text60 = text58 + text59;
				}
				else
				{
					string text61 = "0";
					text60 = text58 + text61;
				}
				string text62 = text60;
				string value12 = "EV";
				string text64;
				if (text22.Contains(value12))
				{
					string text63 = "1";
					text64 = text62 + text63;
				}
				else
				{
					string text65 = "0";
					text64 = text62 + text65;
				}
				this.string_11 = Class33.Jrny_Traindata[num, 10];
				string string_16 = text64;
				int int_31 = label19.Location.X;
				int int_32 = num2;
				string string_17 = text21;
				method_2(string_16, int_31, 31, 24, int_32, string_17);
				num++;
				num2++;
			}
		}
	}

	private void method_2(string string_14, int int_0, int int_1, int int_2, int int_3, string string_15)
	{
		try
		{
			Color c0AA = color_0;
			if (int_3 % 2 == 0)
			{
				c0AA = C0AA0;
			}
			int num = 0;
			int num2 = 19;
			for (int i = 0; i <= 10; i++)
			{
				string text = string_14.Substring(i, 1);
				string text2 = "0";
				if (text == text2)
				{
					LinkLabel linkLabel = new LinkLabel();
					string text3 = "label";
					linkLabel.Name = text3 + string_14;
					string text4 = "X";
					linkLabel.Text = text4;
					linkLabel.BackColor = c0AA;
					linkLabel.Location = new Point(int_0, int_2 + int_2 * int_3 + (int_3 + int_3 + int_3));
					linkLabel.BorderStyle = borderStyle_0;
					string familyName = "Arial";
					linkLabel.Font = new Font(familyName, 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
					linkLabel.TextAlign = ContentAlignment.MiddleCenter;
					linkLabel.Size = new Size(int_1, int_2);
					LinkLabel linkLabel2 = linkLabel;
					LinkLabel.LinkCollection links = linkLabel2.Links;
					int length = linkLabel2.Text.Length;
					string text5 = ":";
					links.Add(0, length, string_15 + text5 + linkLabel2.Text);
					linkLabel2.Enabled = false;
					linkLabel2.LinkBehavior = LinkBehavior.NeverUnderline;
					linkLabel2.LinkClicked += method_6;
					pnlMain.Controls.Add(linkLabel2);
					int_0 += int_1;
				}
				LinkLabel linkLabel3 = new LinkLabel();
				string text6 = "1";
				if (text == text6)
				{
					num++;
					switch (i)
					{
					case 0:
					{
						string text17 = "1A";
						linkLabel3.Text = text17;
						break;
					}
					case 1:
					{
						string text16 = "2A";
						linkLabel3.Text = text16;
						break;
					}
					case 2:
					{
						string text15 = "3A";
						linkLabel3.Text = text15;
						break;
					}
					case 3:
					{
						string text14 = "CC";
						linkLabel3.Text = text14;
						break;
					}
					case 4:
					{
						string text13 = "FC";
						linkLabel3.Text = text13;
						break;
					}
					case 5:
					{
						string text12 = "SL";
						linkLabel3.Text = text12;
						break;
					}
					case 6:
					{
						string text11 = "2S";
						linkLabel3.Text = text11;
						break;
					}
					case 7:
					{
						string text10 = "3E";
						linkLabel3.Text = text10;
						break;
					}
					case 8:
					{
						string text9 = "EA";
						linkLabel3.Text = text9;
						break;
					}
					case 9:
					{
						string text8 = "EC";
						linkLabel3.Text = text8;
						break;
					}
					case 10:
					{
						string text7 = "EV";
						linkLabel3.Text = text7;
						break;
					}
					}
					string text18 = string_11;
					string[] array = new string[1];
					string text19 = ":";
					array[0] = text19;
					string[] array2 = text18.Split(array, StringSplitOptions.RemoveEmptyEntries);
					if (array2 != null && array2.Length > 2)
					{
						string[] array3 = new string[5]
						{
							array2[i + 2],
							null,
							null,
							null,
							null
						};
						string text20 = ",";
						array3[1] = text20;
						array3[2] = string_12;
						string text21 = ",";
						array3[3] = text21;
						array3[4] = (bool_0 ? 1 : 0).ToString();
						linkLabel3.Tag = string.Concat(array3);
					}
					string text22 = "label";
					linkLabel3.Name = text22 + string_14;
					linkLabel3.BackColor = c0AA;
					linkLabel3.LinkColor = color_1;
					linkLabel3.Location = new Point(int_0, int_2 + int_2 * int_3 + (int_3 + int_3 + int_3));
					linkLabel3.BorderStyle = borderStyle_0;
					string familyName2 = "Arial";
					linkLabel3.Font = new Font(familyName2, 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
					linkLabel3.TextAlign = ContentAlignment.MiddleCenter;
					linkLabel3.Size = new Size(int_1, int_2);
					LinkLabel.LinkCollection links2 = linkLabel3.Links;
					int length2 = linkLabel3.Text.Length;
					string text23 = ":";
					links2.Add(0, length2, string_15 + text23 + linkLabel3.Text);
					linkLabel3.LinkBehavior = LinkBehavior.NeverUnderline;
					linkLabel3.LinkClicked += method_6;
					pnlMain.Controls.Add(linkLabel3);
					int_0 += int_1;
				}
				num2++;
				Control.ControlCollection controls = base.Controls;
				string text24 = "label";
				int_0 = controls[text24 + num2].Location.X;
			}
		}
		catch (Exception)
		{
		}
	}

	public void RefreshSeats(object object_0)
	{
		try
		{
			string from = string_0;
			string to = string_1;
			string trainNum = string_4;
			string[] array = new string[5]
			{
				dateTime_0.Day.ToString(),
				null,
				null,
				null,
				null
			};
			string text = "/";
			array[1] = text;
			array[2] = dateTime_0.Month.ToString();
			string text2 = "/";
			array[3] = text2;
			array[4] = dateTime_0.Year.ToString();
			string s = string.Concat(array);
			string format = "d/M/yyyy";
			string[] array2 = Class47.method_2A(from, to, trainNum, DateTime.ParseExact(s, format, CultureInfo.InvariantCulture), string_2, string_3).Split('~');
			string_8 = array2[0];
			string_10 = array2[1];
			method_5();
		}
		catch
		{
		}
	}

	private void method_5()
	{
		try
		{
			GetSeatAvlPic.Visible = false;
			string text = string_8;
			string value = "error";
			if (text.Contains(value))
			{
				C1AA0 = false;
				Button button = btnSelect;
				string text2 = "Select Train Details";
				button.Text = text2;
				btnSelect.Visible = true;
				return;
			}
			Button button2 = btnSelect;
			string[] array = new string[5] { string_8, null, null, null, null };
			string text3 = ", ";
			array[1] = text3;
			array[2] = string_3;
			string text4 = ", ";
			array[3] = text4;
			array[4] = string_4;
			button2.Text = string.Concat(array);
			lblfare.Visible = true;
			Label label = lblfare;
			string text5 = "Fare :- ";
			label.Text = text5 + string_10;
			btnSelect.Visible = true;
			C1AA0 = false;
		}
		catch
		{
			string text6 = "Error Occured, try again later.";
			MessageBox.Show(text6);
		}
	}

	private void btnSelect_Click(object sender, EventArgs e)
	{
		string_0 = string_0.ToUpper();
		string_1 = string_1.ToUpper();
		string_3 = string_3.ToUpper();
		string_2 = string_2.ToUpper();
		string[] array = new string[12];
		string text = "Are you sure to proceed with!!! \r\n************************************************\r\n\r\nTrain No. : ";
		array[0] = text;
		array[1] = string_4;
		string text2 = "\r\nJourney Date: ";
		array[2] = text2;
		ref DateTime reference = ref dateTime_0;
		string text3 = "dd-MMM-yyyy";
		array[3] = reference.ToString(text3);
		string text4 = "\r\nFrom: ";
		array[4] = text4;
		array[5] = string_0;
		string text5 = "\r\nTo: ";
		array[6] = text5;
		array[7] = string_1;
		string text6 = "\r\nClass: ";
		array[8] = text6;
		array[9] = string_2;
		string text7 = "\r\nQuota: ";
		array[10] = text7;
		array[11] = string_3;
		string text8 = string.Concat(array);
		string caption = "Confirm Journey Details";
		if (MessageBox.Show(text8, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
		{
			base.DialogResult = DialogResult.OK;
		}
	}

	private void BAAAA(object sender, EventArgs e)
	{
		pnlloader.Visible = true;
		if (new TimeSpan(dateTime_0.Ticks - DateTime.Now.Ticks).TotalDays > 2.0)
		{
			rdCK.Enabled = false;
			rdPT.Enabled = false;
			rdGN.Checked = true;
		}
		if (DateTime.Now.Hour > 12)
		{
			rdGN.Checked = true;
		}
		backgroundWorker_0.RunWorkerAsync();
		base.Width = pnlMain.Width;
	}

	private void method_6(object sender, LinkLabelLinkClickedEventArgs e)
	{
		try
		{
			if (C1AA0 || chkIRCTC.Checked)
			{
				return;
			}
			LinkLabel linkLabel = sender as LinkLabel;
			btnSelect.Visible = true;
			GetSeatAvlPic.Visible = true;
			Control.ControlCollection controls = pnlHeader.Controls;
			string key = "labelbook";
			controls.RemoveByKey(key);
			string text = "";
			try
			{
				if (linkLabel != null && linkLabel.Tag != null)
				{
					string text2 = linkLabel.Tag.ToString();
					string[] array = new string[1];
					string text3 = ",";
					array[0] = text3;
					string[] array2 = text2.Split(array, StringSplitOptions.RemoveEmptyEntries);
					string text4 = array2[0];
					string text5 = "/-";
					string_10 = text4 + text5;
					string_6 = array2[array2.Length - 1];
					string text6 = (int.Parse(array2[0]) + int.Parse(array2[3])).ToString();
					string text7 = "/-";
					text = text6 + text7;
				}
				else
				{
					string_10 = "";
				}
			}
			catch
			{
			}
			string text9;
			if (rdPG.Checked)
			{
				string text8 = "PG";
				text9 = text8;
			}
			else if (rdPT.Checked)
			{
				string text10 = "PT";
				text9 = text10;
				string text11 = "Dynamic Fare (CK: ";
				string text12 = text;
				string text13 = ")";
				string_10 = text11 + text12 + text13;
			}
			else if (!rdCK.Checked)
			{
				if (!rdLD.Checked)
				{
					if (!rdGN.Checked)
					{
						string text14 = "Please select the Quota";
						string caption = "Quota";
						MessageBox.Show(text14, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						return;
					}
					string text15 = "GN";
					text9 = text15;
				}
				else
				{
					string text16 = "LD";
					text9 = text16;
				}
			}
			else
			{
				string text17 = "TQ";
				text9 = text17;
				string_10 = text;
			}
			string text18 = e.Link.LinkData.ToString();
			string text19 = ":";
			string[] array3 = (B0AAA = text18 + text19 + text9).Split(':');
			string_4 = array3[0];
			string_5 = array3[1];
			string_0 = array3[2];
			string_1 = array3[3];
			string_2 = array3[5];
			string_3 = array3[6];
			C1AA0 = true;
			lblfare.Visible = false;
			Thread thread = new Thread(RefreshSeats);
			thread.SetApartmentState(ApartmentState.STA);
			thread.IsBackground = true;
			thread.Start();
		}
		catch
		{
		}
	}

	private void method_7()
	{
		int num = 0;
		string text = "error";
		string text2 = text;
		string text9;
		string text10;
		do
		{
			string text3 = text2;
			string text4 = "retry";
			if (text3 != text4)
			{
				string text5 = text2;
				string text6 = "error";
				if (text5 != text6)
				{
					if (!string.IsNullOrEmpty(text2))
					{
						string text7 = text2;
						string value = "This particular service is unavailable at this time";
						if (!text7.Contains(value))
						{
							string_7 = text2;
							goto IL_0085;
						}
					}
					string text8 = "retry";
					text2 = text8;
				}
			}
			goto IL_0085;
			IL_0085:
			num++;
			text9 = text2;
			text10 = "retry";
		}
		while (!(text9 != text10));
		Class33.Jrny_Traindata = Class47.method_1A(string_0, string_1, "", dateTime_0, string_2, "");
	}

	private void frmSerch_Train_MouseWheel(object sender, MouseEventArgs e)
	{
		pnlMain.Focus();
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		Close();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && B1AAA != null)
		{
			B1AAA.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(APP_FRAMEWORK.frmSerch_Train));
		this.whosent = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.grpOpen = new System.Windows.Forms.GroupBox();
		this.GetSeatAvlPic = new System.Windows.Forms.PictureBox();
		this.lblfare = new System.Windows.Forms.Label();
		this.chkIRCTC = new System.Windows.Forms.CheckBox();
		this.rdGN = new System.Windows.Forms.RadioButton();
		this.rdLD = new System.Windows.Forms.RadioButton();
		this.C4AA0 = new System.Windows.Forms.Label();
		this.rdCK = new System.Windows.Forms.RadioButton();
		this.B4AAA = new System.Windows.Forms.Panel();
		this.rdPT = new System.Windows.Forms.RadioButton();
		this.btnSelect = new System.Windows.Forms.Button();
		this.rdPG = new System.Windows.Forms.RadioButton();
		this.pnlMain = new System.Windows.Forms.Panel();
		this.pnlloader = new System.Windows.Forms.Panel();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.label26 = new System.Windows.Forms.Label();
		this.label25 = new System.Windows.Forms.Label();
		this.label24 = new System.Windows.Forms.Label();
		this.label23 = new System.Windows.Forms.Label();
		this.label22 = new System.Windows.Forms.Label();
		this.label21 = new System.Windows.Forms.Label();
		this.label20 = new System.Windows.Forms.Label();
		this.label19 = new System.Windows.Forms.Label();
		this.C2AA0 = new System.Windows.Forms.Label();
		this.B2AAA = new System.Windows.Forms.Label();
		this.label16 = new System.Windows.Forms.Label();
		this.label15 = new System.Windows.Forms.Label();
		this.label14 = new System.Windows.Forms.Label();
		this.label13 = new System.Windows.Forms.Label();
		this.label12 = new System.Windows.Forms.Label();
		this.label11 = new System.Windows.Forms.Label();
		this.label10 = new System.Windows.Forms.Label();
		this.label9 = new System.Windows.Forms.Label();
		this.label8 = new System.Windows.Forms.Label();
		this.C3AA0 = new System.Windows.Forms.Label();
		this.B3AAA = new System.Windows.Forms.Label();
		this.label5 = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.backgroundWorker_0 = new System.ComponentModel.BackgroundWorker();
		this.bunifuElipse_0 = new Bunifu.Framework.UI.BunifuElipse(this.components);
		this.label30 = new System.Windows.Forms.Label();
		this.pnlHeader = new System.Windows.Forms.Panel();
		this.label2 = new System.Windows.Forms.Label();
		this.label27 = new System.Windows.Forms.Label();
		this.label28 = new System.Windows.Forms.Label();
		this.label29 = new System.Windows.Forms.Label();
		this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
		this.grpOpen.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.GetSeatAvlPic).BeginInit();
		this.pnlMain.SuspendLayout();
		this.pnlloader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		this.pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.btnClose).BeginInit();
		base.SuspendLayout();
		this.whosent.AutoSize = true;
		this.whosent.Location = new System.Drawing.Point(15, 25000);
		this.whosent.Name = "whosent";
		this.whosent.Size = new System.Drawing.Size(13, 13);
		this.whosent.TabIndex = 2;
		this.whosent.Text = "0";
		this.label3.AutoSize = true;
		this.label3.BackColor = System.Drawing.Color.Transparent;
		this.label3.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.label3.ForeColor = System.Drawing.Color.Black;
		this.label3.Location = new System.Drawing.Point(2, 16);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(88, 15);
		this.label3.TabIndex = 5;
		this.label3.Text = "Select Quota :";
		this.grpOpen.BackColor = System.Drawing.Color.Honeydew;
		this.grpOpen.Controls.Add(this.GetSeatAvlPic);
		this.grpOpen.Controls.Add(this.lblfare);
		this.grpOpen.Controls.Add(this.label3);
		this.grpOpen.Controls.Add(this.chkIRCTC);
		this.grpOpen.Controls.Add(this.rdGN);
		this.grpOpen.Controls.Add(this.rdLD);
		this.grpOpen.Controls.Add(this.C4AA0);
		this.grpOpen.Controls.Add(this.rdCK);
		this.grpOpen.Controls.Add(this.B4AAA);
		this.grpOpen.Controls.Add(this.rdPT);
		this.grpOpen.Controls.Add(this.btnSelect);
		this.grpOpen.Controls.Add(this.rdPG);
		this.grpOpen.Location = new System.Drawing.Point(1, 12);
		this.grpOpen.Name = "grpOpen";
		this.grpOpen.Size = new System.Drawing.Size(1119, 36);
		this.grpOpen.TabIndex = 9;
		this.grpOpen.TabStop = false;
		this.GetSeatAvlPic.Location = new System.Drawing.Point(659, 11);
		this.GetSeatAvlPic.Name = "GetSeatAvlPic";
		this.GetSeatAvlPic.Size = new System.Drawing.Size(160, 24);
		this.GetSeatAvlPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
		this.GetSeatAvlPic.TabIndex = 204;
		this.GetSeatAvlPic.TabStop = false;
		this.GetSeatAvlPic.Visible = false;
		this.lblfare.AutoSize = true;
		this.lblfare.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblfare.Location = new System.Drawing.Point(712, 15);
		this.lblfare.Name = "lblfare";
		this.lblfare.Size = new System.Drawing.Size(34, 16);
		this.lblfare.TabIndex = 204;
		this.lblfare.Text = "fare";
		this.chkIRCTC.AutoSize = true;
		this.chkIRCTC.BackColor = System.Drawing.Color.Transparent;
		this.chkIRCTC.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.chkIRCTC.ForeColor = System.Drawing.Color.Black;
		this.chkIRCTC.Location = new System.Drawing.Point(427, 15);
		this.chkIRCTC.Name = "chkIRCTC";
		this.chkIRCTC.Size = new System.Drawing.Size(160, 19);
		this.chkIRCTC.TabIndex = 197;
		this.chkIRCTC.Text = "Availability From IRCTC";
		this.chkIRCTC.UseVisualStyleBackColor = false;
		this.chkIRCTC.Visible = false;
		this.rdGN.AutoSize = true;
		this.rdGN.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.rdGN.ForeColor = System.Drawing.Color.Black;
		this.rdGN.Location = new System.Drawing.Point(193, 14);
		this.rdGN.Name = "rdGN";
		this.rdGN.Size = new System.Drawing.Size(43, 19);
		this.rdGN.TabIndex = 7;
		this.rdGN.Text = "GN";
		this.rdGN.UseVisualStyleBackColor = true;
		this.rdLD.AutoSize = true;
		this.rdLD.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.rdLD.ForeColor = System.Drawing.Color.Black;
		this.rdLD.Location = new System.Drawing.Point(244, 14);
		this.rdLD.Name = "rdLD";
		this.rdLD.Size = new System.Drawing.Size(41, 19);
		this.rdLD.TabIndex = 8;
		this.rdLD.Text = "LD";
		this.rdLD.UseVisualStyleBackColor = true;
		this.C4AA0.AutoSize = true;
		this.C4AA0.BackColor = System.Drawing.Color.Transparent;
		this.C4AA0.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.C4AA0.ForeColor = System.Drawing.Color.Black;
		this.C4AA0.Location = new System.Drawing.Point(427, 16);
		this.C4AA0.Name = "C4AA0";
		this.C4AA0.Size = new System.Drawing.Size(137, 15);
		this.C4AA0.TabIndex = 203;
		this.C4AA0.Text = "Trains having PT Quota";
		this.rdCK.AutoSize = true;
		this.rdCK.Checked = true;
		this.rdCK.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.rdCK.ForeColor = System.Drawing.Color.Black;
		this.rdCK.Location = new System.Drawing.Point(94, 14);
		this.rdCK.Name = "rdCK";
		this.rdCK.Size = new System.Drawing.Size(42, 19);
		this.rdCK.TabIndex = 9;
		this.rdCK.TabStop = true;
		this.rdCK.Text = "TQ";
		this.rdCK.UseVisualStyleBackColor = true;
		this.B4AAA.BackColor = System.Drawing.Color.Gold;
		this.B4AAA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.B4AAA.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.B4AAA.ForeColor = System.Drawing.Color.Black;
		this.B4AAA.Location = new System.Drawing.Point(404, 16);
		this.B4AAA.Name = "B4AAA";
		this.B4AAA.Size = new System.Drawing.Size(17, 16);
		this.B4AAA.TabIndex = 201;
		this.rdPT.AutoSize = true;
		this.rdPT.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.rdPT.ForeColor = System.Drawing.Color.Black;
		this.rdPT.Location = new System.Drawing.Point(145, 14);
		this.rdPT.Name = "rdPT";
		this.rdPT.Size = new System.Drawing.Size(40, 19);
		this.rdPT.TabIndex = 10;
		this.rdPT.Text = "PT";
		this.rdPT.UseVisualStyleBackColor = true;
		this.btnSelect.BackColor = System.Drawing.Color.DarkGray;
		this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnSelect.Location = new System.Drawing.Point(944, 11);
		this.btnSelect.Name = "btnSelect";
		this.btnSelect.Size = new System.Drawing.Size(169, 24);
		this.btnSelect.TabIndex = 195;
		this.btnSelect.Text = "Select Train";
		this.btnSelect.UseVisualStyleBackColor = false;
		this.btnSelect.Visible = false;
		this.btnSelect.Click += new System.EventHandler(btnSelect_Click);
		this.rdPG.AutoSize = true;
		this.rdPG.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.rdPG.ForeColor = System.Drawing.Color.Black;
		this.rdPG.Location = new System.Drawing.Point(293, 14);
		this.rdPG.Name = "rdPG";
		this.rdPG.Size = new System.Drawing.Size(99, 19);
		this.rdPG.TabIndex = 11;
		this.rdPG.Text = "GN-Premium";
		this.rdPG.UseVisualStyleBackColor = true;
		this.pnlMain.AutoScroll = true;
		this.pnlMain.AutoScrollMinSize = new System.Drawing.Size(1000, 1400);
		this.pnlMain.BackColor = System.Drawing.SystemColors.Control;
		this.pnlMain.Controls.Add(this.pnlloader);
		this.pnlMain.Location = new System.Drawing.Point(0, 56);
		this.pnlMain.Margin = new System.Windows.Forms.Padding(2);
		this.pnlMain.Name = "pnlMain";
		this.pnlMain.Size = new System.Drawing.Size(1120, 217);
		this.pnlMain.TabIndex = 8;
		this.pnlloader.Controls.Add(this.pictureBox1);
		this.pnlloader.Location = new System.Drawing.Point(447, 64);
		this.pnlloader.Name = "pnlloader";
		this.pnlloader.Size = new System.Drawing.Size(76, 77);
		this.pnlloader.TabIndex = 38;
		this.pnlloader.Visible = false;
		this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
		this.pictureBox1.Location = new System.Drawing.Point(3, 4);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new System.Drawing.Size(64, 64);
		this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
		this.pictureBox1.TabIndex = 24;
		this.pictureBox1.TabStop = false;
		this.label26.BackColor = System.Drawing.Color.FromArgb(235, 248, 239);
		this.label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f);
		this.label26.ForeColor = System.Drawing.Color.Black;
		this.label26.Location = new System.Drawing.Point(981, 48);
		this.label26.Name = "label26";
		this.label26.Size = new System.Drawing.Size(31, 24);
		this.label26.TabIndex = 13;
		this.label26.Text = "3E";
		this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label25.BackColor = System.Drawing.Color.FromArgb(235, 248, 239);
		this.label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f);
		this.label25.ForeColor = System.Drawing.Color.Black;
		this.label25.Location = new System.Drawing.Point(951, 48);
		this.label25.Name = "label25";
		this.label25.Size = new System.Drawing.Size(31, 24);
		this.label25.TabIndex = 12;
		this.label25.Text = "2S";
		this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label24.BackColor = System.Drawing.Color.FromArgb(235, 248, 239);
		this.label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f);
		this.label24.ForeColor = System.Drawing.Color.Black;
		this.label24.Location = new System.Drawing.Point(921, 48);
		this.label24.Name = "label24";
		this.label24.Size = new System.Drawing.Size(31, 24);
		this.label24.TabIndex = 11;
		this.label24.Text = "SL";
		this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label23.BackColor = System.Drawing.Color.FromArgb(235, 248, 239);
		this.label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f);
		this.label23.ForeColor = System.Drawing.Color.Black;
		this.label23.Location = new System.Drawing.Point(891, 48);
		this.label23.Name = "label23";
		this.label23.Size = new System.Drawing.Size(31, 24);
		this.label23.TabIndex = 10;
		this.label23.Text = "FC";
		this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label22.BackColor = System.Drawing.Color.FromArgb(235, 248, 239);
		this.label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f);
		this.label22.ForeColor = System.Drawing.Color.Black;
		this.label22.Location = new System.Drawing.Point(861, 48);
		this.label22.Name = "label22";
		this.label22.Size = new System.Drawing.Size(31, 24);
		this.label22.TabIndex = 9;
		this.label22.Text = "CC";
		this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label21.BackColor = System.Drawing.Color.FromArgb(235, 248, 239);
		this.label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f);
		this.label21.ForeColor = System.Drawing.Color.Black;
		this.label21.Location = new System.Drawing.Point(831, 48);
		this.label21.Name = "label21";
		this.label21.Size = new System.Drawing.Size(31, 24);
		this.label21.TabIndex = 8;
		this.label21.Text = "3A";
		this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label20.BackColor = System.Drawing.Color.FromArgb(235, 248, 239);
		this.label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f);
		this.label20.ForeColor = System.Drawing.Color.Black;
		this.label20.Location = new System.Drawing.Point(802, 48);
		this.label20.Name = "label20";
		this.label20.Size = new System.Drawing.Size(31, 24);
		this.label20.TabIndex = 7;
		this.label20.Text = "2A";
		this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label19.BackColor = System.Drawing.Color.FromArgb(235, 248, 239);
		this.label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f);
		this.label19.ForeColor = System.Drawing.Color.Black;
		this.label19.Location = new System.Drawing.Point(772, 48);
		this.label19.Name = "label19";
		this.label19.Size = new System.Drawing.Size(31, 24);
		this.label19.TabIndex = 4;
		this.label19.Text = "1A";
		this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.C2AA0.BackColor = System.Drawing.Color.FromArgb(235, 248, 239);
		this.C2AA0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.C2AA0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f);
		this.C2AA0.ForeColor = System.Drawing.Color.Black;
		this.C2AA0.Location = new System.Drawing.Point(744, 48);
		this.C2AA0.Name = "C2AA0";
		this.C2AA0.Size = new System.Drawing.Size(29, 24);
		this.C2AA0.TabIndex = 4;
		this.C2AA0.Text = "S";
		this.C2AA0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.B2AAA.BackColor = System.Drawing.Color.FromArgb(235, 248, 239);
		this.B2AAA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.B2AAA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f);
		this.B2AAA.ForeColor = System.Drawing.Color.Black;
		this.B2AAA.Location = new System.Drawing.Point(716, 48);
		this.B2AAA.Name = "B2AAA";
		this.B2AAA.Size = new System.Drawing.Size(29, 24);
		this.B2AAA.TabIndex = 4;
		this.B2AAA.Text = "S";
		this.B2AAA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label16.BackColor = System.Drawing.Color.FromArgb(235, 248, 239);
		this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f);
		this.label16.ForeColor = System.Drawing.Color.Black;
		this.label16.Location = new System.Drawing.Point(688, 48);
		this.label16.Name = "label16";
		this.label16.Size = new System.Drawing.Size(29, 24);
		this.label16.TabIndex = 4;
		this.label16.Text = "F";
		this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label15.BackColor = System.Drawing.Color.FromArgb(235, 248, 239);
		this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f);
		this.label15.ForeColor = System.Drawing.Color.Black;
		this.label15.Location = new System.Drawing.Point(660, 48);
		this.label15.Name = "label15";
		this.label15.Size = new System.Drawing.Size(29, 24);
		this.label15.TabIndex = 4;
		this.label15.Text = "T";
		this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label14.BackColor = System.Drawing.Color.FromArgb(235, 248, 239);
		this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f);
		this.label14.ForeColor = System.Drawing.Color.Black;
		this.label14.Location = new System.Drawing.Point(632, 48);
		this.label14.Name = "label14";
		this.label14.Size = new System.Drawing.Size(29, 24);
		this.label14.TabIndex = 4;
		this.label14.Text = "W";
		this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label13.BackColor = System.Drawing.Color.FromArgb(235, 248, 239);
		this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f);
		this.label13.ForeColor = System.Drawing.Color.Black;
		this.label13.Location = new System.Drawing.Point(604, 48);
		this.label13.Name = "label13";
		this.label13.Size = new System.Drawing.Size(29, 24);
		this.label13.TabIndex = 4;
		this.label13.Text = "T";
		this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label12.BackColor = System.Drawing.Color.FromArgb(235, 248, 239);
		this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f);
		this.label12.ForeColor = System.Drawing.Color.Black;
		this.label12.Location = new System.Drawing.Point(576, 48);
		this.label12.Name = "label12";
		this.label12.Size = new System.Drawing.Size(29, 24);
		this.label12.TabIndex = 4;
		this.label12.Text = "M";
		this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label11.BackColor = System.Drawing.Color.FromArgb(235, 248, 239);
		this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f);
		this.label11.ForeColor = System.Drawing.Color.Black;
		this.label11.Location = new System.Drawing.Point(498, 48);
		this.label11.Name = "label11";
		this.label11.Size = new System.Drawing.Size(79, 24);
		this.label11.TabIndex = 4;
		this.label11.Text = "Travel";
		this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label10.BackColor = System.Drawing.Color.FromArgb(235, 248, 239);
		this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f);
		this.label10.ForeColor = System.Drawing.Color.Black;
		this.label10.Location = new System.Drawing.Point(423, 48);
		this.label10.Name = "label10";
		this.label10.Size = new System.Drawing.Size(76, 24);
		this.label10.TabIndex = 4;
		this.label10.Text = "Dist.(Km)";
		this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label9.BackColor = System.Drawing.Color.FromArgb(235, 248, 239);
		this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f);
		this.label9.ForeColor = System.Drawing.Color.Black;
		this.label9.Location = new System.Drawing.Point(362, 48);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(62, 24);
		this.label9.TabIndex = 4;
		this.label9.Text = "Arrival";
		this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label8.BackColor = System.Drawing.Color.FromArgb(235, 248, 239);
		this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f);
		this.label8.ForeColor = System.Drawing.Color.Black;
		this.label8.Location = new System.Drawing.Point(314, 48);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(49, 24);
		this.label8.TabIndex = 4;
		this.label8.Text = "To";
		this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.C3AA0.BackColor = System.Drawing.Color.FromArgb(235, 248, 239);
		this.C3AA0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.C3AA0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f);
		this.C3AA0.ForeColor = System.Drawing.Color.Black;
		this.C3AA0.Location = new System.Drawing.Point(245, 48);
		this.C3AA0.Name = "C3AA0";
		this.C3AA0.Size = new System.Drawing.Size(70, 24);
		this.C3AA0.TabIndex = 4;
		this.C3AA0.Text = "Depart";
		this.C3AA0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.B3AAA.BackColor = System.Drawing.Color.FromArgb(235, 248, 239);
		this.B3AAA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.B3AAA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f);
		this.B3AAA.ForeColor = System.Drawing.Color.Black;
		this.B3AAA.Location = new System.Drawing.Point(199, 48);
		this.B3AAA.Name = "B3AAA";
		this.B3AAA.Size = new System.Drawing.Size(47, 24);
		this.B3AAA.TabIndex = 4;
		this.B3AAA.Text = "From";
		this.B3AAA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label5.BackColor = System.Drawing.Color.FromArgb(235, 248, 239);
		this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f);
		this.label5.ForeColor = System.Drawing.Color.Black;
		this.label5.Location = new System.Drawing.Point(73, 48);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(128, 24);
		this.label5.TabIndex = 4;
		this.label5.Text = "Train Name";
		this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label4.BackColor = System.Drawing.Color.FromArgb(235, 248, 239);
		this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f);
		this.label4.ForeColor = System.Drawing.Color.Black;
		this.label4.Location = new System.Drawing.Point(0, 48);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(74, 24);
		this.label4.TabIndex = 4;
		this.label4.Text = "Train No";
		this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.backgroundWorker_0.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorker_0_DoWork);
		this.backgroundWorker_0.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorker_0_RunWorkerCompleted);
		this.bunifuElipse_0.ElipseRadius = 5;
		this.bunifuElipse_0.TargetControl = this;
		this.label30.BackColor = System.Drawing.Color.DarkSlateGray;
		this.label30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.label30.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label30.ForeColor = System.Drawing.Color.White;
		this.label30.Location = new System.Drawing.Point(1183, 49);
		this.label30.Name = "label30";
		this.label30.Size = new System.Drawing.Size(29, 24);
		this.label30.TabIndex = 14;
		this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.pnlHeader.BackColor = System.Drawing.Color.MediumSlateBlue;
		this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pnlHeader.Controls.Add(this.btnClose);
		this.pnlHeader.Controls.Add(this.label2);
		this.pnlHeader.Location = new System.Drawing.Point(0, -2);
		this.pnlHeader.Name = "pnlHeader";
		this.pnlHeader.Size = new System.Drawing.Size(1120, 23);
		this.pnlHeader.TabIndex = 6;
		this.label2.AutoSize = true;
		this.label2.BackColor = System.Drawing.Color.Transparent;
		this.label2.Font = new System.Drawing.Font("Verdana", 9f);
		this.label2.Location = new System.Drawing.Point(3, 4);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(63, 14);
		this.label2.TabIndex = 206;
		this.label2.Text = "Train List";
		this.label27.BackColor = System.Drawing.Color.FromArgb(235, 248, 239);
		this.label27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f);
		this.label27.ForeColor = System.Drawing.Color.Black;
		this.label27.Location = new System.Drawing.Point(1011, 48);
		this.label27.Name = "label27";
		this.label27.Size = new System.Drawing.Size(31, 24);
		this.label27.TabIndex = 15;
		this.label27.Text = "EA";
		this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label28.BackColor = System.Drawing.Color.FromArgb(235, 248, 239);
		this.label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f);
		this.label28.ForeColor = System.Drawing.Color.Black;
		this.label28.Location = new System.Drawing.Point(1041, 48);
		this.label28.Name = "label28";
		this.label28.Size = new System.Drawing.Size(31, 24);
		this.label28.TabIndex = 39;
		this.label28.Text = "EC";
		this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label29.BackColor = System.Drawing.Color.FromArgb(235, 248, 239);
		this.label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f);
		this.label29.ForeColor = System.Drawing.Color.Black;
		this.label29.Location = new System.Drawing.Point(1071, 48);
		this.label29.Name = "label29";
		this.label29.Size = new System.Drawing.Size(31, 24);
		this.label29.TabIndex = 40;
		this.label29.Text = "EV";
		this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.btnClose.BackColor = System.Drawing.Color.Transparent;
		this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
		this.btnClose.Image = (System.Drawing.Image)resources.GetObject("btnClose.Image");
		this.btnClose.ImageActive = null;
		this.btnClose.Location = new System.Drawing.Point(1093, -1);
		this.btnClose.Margin = new System.Windows.Forms.Padding(2);
		this.btnClose.Name = "btnClose";
		this.btnClose.Size = new System.Drawing.Size(23, 23);
		this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.btnClose.TabIndex = 207;
		this.btnClose.TabStop = false;
		this.btnClose.Zoom = 10;
		this.btnClose.Click += new System.EventHandler(btnClose_Click_1);
		base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.BackColor = System.Drawing.Color.Turquoise;
		base.ClientSize = new System.Drawing.Size(1122, 274);
		base.Controls.Add(this.label29);
		base.Controls.Add(this.label28);
		base.Controls.Add(this.pnlHeader);
		base.Controls.Add(this.grpOpen);
		base.Controls.Add(this.label27);
		base.Controls.Add(this.label30);
		base.Controls.Add(this.label26);
		base.Controls.Add(this.label25);
		base.Controls.Add(this.label24);
		base.Controls.Add(this.whosent);
		base.Controls.Add(this.label23);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.label22);
		base.Controls.Add(this.label5);
		base.Controls.Add(this.label21);
		base.Controls.Add(this.B3AAA);
		base.Controls.Add(this.label20);
		base.Controls.Add(this.C3AA0);
		base.Controls.Add(this.label19);
		base.Controls.Add(this.label8);
		base.Controls.Add(this.C2AA0);
		base.Controls.Add(this.label9);
		base.Controls.Add(this.B2AAA);
		base.Controls.Add(this.label10);
		base.Controls.Add(this.label16);
		base.Controls.Add(this.label11);
		base.Controls.Add(this.label15);
		base.Controls.Add(this.label12);
		base.Controls.Add(this.label14);
		base.Controls.Add(this.label13);
		base.Controls.Add(this.pnlMain);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "frmSerch_Train";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Search Trains";
		base.Load += new System.EventHandler(BAAAA);
		base.MouseWheel += new System.Windows.Forms.MouseEventHandler(frmSerch_Train_MouseWheel);
		this.grpOpen.ResumeLayout(false);
		this.grpOpen.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.GetSeatAvlPic).EndInit();
		this.pnlMain.ResumeLayout(false);
		this.pnlloader.ResumeLayout(false);
		this.pnlloader.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		this.pnlHeader.ResumeLayout(false);
		this.pnlHeader.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.btnClose).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private void btnClose_Click_1(object sender, EventArgs e)
	{
		Close();
	}
}
