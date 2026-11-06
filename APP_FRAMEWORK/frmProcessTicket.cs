using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using IRCommDLL;
using Microsoft.VisualBasic;
using NEXUS;

namespace APP_FRAMEWORK;

internal class frmProcessTicket : Form
{
	private class WorkParams
	{
		internal object Payload;

		internal CancellationToken Token;
	}

	private class WorkerHandle
	{
		internal Thread Thread;

		internal CancellationTokenSource Cts;
	}

	private int totalw;

	private int numleft = 5;

	private int numlR;

	private int top;

	private bool line2;

	private bool line3;

	private bool line4;

	private string string_0;

	private string string_1;

	private string string_2;

	private bool bool_0;

	private bool close_;

	private int int_3;

	private int int_0;

	private int int_1;

	private int int_2;

	private static List<string> list_0 = new List<string>(500);

	private static List<string> list_1 = new List<string>(500);

	private List<TCntrl> list_2;

	private IContainer iContainer0;

	private bool drag;

	private int posX;

	private int posY;

	private Color Colour0;

	private kewirctcLogin kewirctcLogin;

	private mCOMM mcommInstance;

	private IDisposable idisposable_0;

	private Panel pnl;

	private Panel PanelHelder;

	internal Label formName;

	private BunifuElipse bunifuElipse_0;

	private IContainer components;

	private Panel panel1;

	private BunifuImageButton btnClose;

	private Panel panel2;

	public frmProcessTicket()
	{
		InitializeComponent();
		list_2 = new List<TCntrl>();
	}

	public frmProcessTicket(string string_2, Color color_1, bool bool_1, int int_2, int int_3)
		: this()
	{
		string variable = "BookWindowSize";
		Environment.SetEnvironmentVariable(variable, base.Width.ToString());
		string_1 = string_2;
		string delimiter = "^#^";
		string[] array = Strings.Split(string_2, delimiter);
		if (array.Length > 4)
		{
			string_0 = array[0];
			int_1 = int.Parse(array[1]);
			this.int_2 = int.Parse(array[2]);
			frmMain.chAuto = bool.Parse(array[3]);
			this.string_2 = array[4];
		}
		if (frmMain.chAuto & !StatClass.firstpair & (int_1 + this.int_2 > 1))
		{
			StatClass.firstpair = true;
			if (int_1 < this.int_2)
			{
				StatClass.WebLogin = false;
				StatClass.DishaLogin = false;
				StatClass.ApptLogin = true;
			}
			else
			{
				StatClass.ApptLogin = false;
				StatClass.DishaLogin = false;
				StatClass.WebLogin = true;
			}
		}
		if (frmMain.chAuto & (int_1 + this.int_2 == 1))
		{
			if (int_1 == 1)
			{
				StatClass.ApptLogin = false;
				StatClass.DishaLogin = false;
				StatClass.WebLogin = true;
			}
			else
			{
				StatClass.WebLogin = false;
				StatClass.DishaLogin = false;
				StatClass.ApptLogin = true;
			}
		}
		Interlocked.Increment(ref StatClass.TotalOpendWindow);
		Colour0 = color_1;
		this.int_3 = int_2;
		int_0 = int_3;
		base.Tag = int_2;
		try
		{
			if (!bool_1)
			{
				Class28.dictionary_0.Add(int_2, 0);
			}
			else
			{
				bool_0 = bool_1;
			}
		}
		catch
		{
		}
		for (int i = 0; i < 3; i++)
		{
			list_2.Add(null);
		}
		AutoSize = true;
		base.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		pnl.AutoSize = true;
		pnl.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		bool bool_2 = bool.Parse(array[3]);
		method_0(bool_1, bool_2);
		if (bool_1)
		{
			return;
		}
		int num = 5;
		int left = 5;
		if (frmMain.int_4 > 0)
		{
			foreach (Form openForm in Application.OpenForms)
			{
				if (openForm.Tag != null && openForm.Tag is int)
				{
					int num2 = openForm.Top + openForm.Height;
					if (num < num2)
					{
						num = num2 + 2;
					}
				}
			}
		}
		if (num > Screen.PrimaryScreen.Bounds.Height - base.Height)
		{
			base.StartPosition = FormStartPosition.CenterScreen;
			return;
		}
		base.StartPosition = FormStartPosition.Manual;
		base.Top = num;
		base.Left = left;
	}

	private void method_0(bool bool_1, bool bool_2)
	{
		new TimeSpan(Convert.ToInt32(Convert.ToInt16(this.string_2.Substring(0, 2))), Convert.ToInt32(Convert.ToInt16(this.string_2.Substring(3, 2))), Convert.ToInt32(Convert.ToInt16(this.string_2.Substring(6, 2))));
		try
		{
			Class48 @class = new Class48();
			if (@class.method_0(string_0))
			{
				TCntrl tCntrl = new TCntrl(@class);
				string text = "tCntrl";
				tCntrl.Name = text + StatClass.TotalOpendWindow;
				tCntrl.ChkAutoLogin = frmMain.chAuto;
				TCntrl tCntrl2 = tCntrl;
				tCntrl2.WindoNo = StatClass.TotalOpendWindow;
				tCntrl2.Event_0 += method_1;
				tCntrl2.Event_2 += method_2;
				tCntrl2.Event_1 += Method_3;
				tCntrl2.Event_3 += method_4;
				tCntrl2.Event_4 += method_6;
				tCntrl2.bool_1 = bool_1;
				tCntrl2.Panel1.BackColor = Colour0;
				tCntrl2.autologin = bool_2;
				tCntrl2.lblTktName.Text = @class.string_12;
				StatClass.IsUsedAllID = false;
				if (bool_1)
				{
					tCntrl2.btnEdit.Enabled = false;
					tCntrl2.BtnOpenPair.Enabled = false;
					tCntrl2.EditlinkLabel.Visible = false;
				}
				_ = pnl.Controls.Count;
				pnl.Controls.Add(tCntrl2);
				if (list_2[0] == null)
				{
					list_2[0] = tCntrl2;
				}
				else if (list_2[1] == null)
				{
					list_2[1] = tCntrl2;
					tCntrl2.Left = list_2[0].Left + list_2[0].Width + 2;
				}
				else if (list_2[2] == null)
				{
					list_2[2] = tCntrl2;
					tCntrl2.Left = list_2[1].Left + list_2[1].Width + 2;
				}
				_ = tCntrl2.Width;
				pnl.Width = tCntrl2.Width;
				pnl.Height = tCntrl2.Height;
				pnl.Left = 2;
				base.Width += 2;
				if (!bool_1)
				{
					Text = string_0;
				}
				else
				{
					string[] array = new string[6] { string_0, null, null, null, null, null };
					string text2 = " [ PairID: ";
					array[1] = text2;
					array[2] = int_3.ToString();
					string text3 = "-";
					array[3] = text3;
					array[4] = int_0.ToString();
					string text4 = " ]";
					array[5] = text4;
					Text = string.Concat(array);
				}
				formName.Text = Text;
				tCntrl2.WithCapchtaInputlogin = true;
				try
				{
					string string_ = @class.string_15;
					string text5 = "Select_Auto Slot";
					if (string_ == text5)
					{
						tCntrl2.cboSlot.SelectedIndex = StatClass.TotalOpendTicket;
					}
					else
					{
						tCntrl2.cboSlot.SelectedItem = @class.string_15;
					}
					string text6 = "";
					foreach (string item in Class28.list_2)
					{
						if (item.Contains(@class.string_12))
						{
							text6 = item.ToString();
						}
					}
					string text7 = text6;
					string[] array2 = new string[1];
					string text8 = "$";
					array2[0] = text8;
					string[] array3 = text7.Split(array2, StringSplitOptions.RemoveEmptyEntries);
					if (array3.Length == 0)
					{
						List<string> list = Class28.list_2;
						string[] array4 = new string[5] { @class.string_12, null, null, null, null };
						string text9 = "$";
						array4[1] = text9;
						array4[2] = tCntrl2.cboID.SelectedItem?.ToString();
						string text10 = "$";
						array4[3] = text10;
						array4[4] = tCntrl2.cboSlot.SelectedItem?.ToString();
						list.Add(string.Concat(array4));
					}
					else
					{
						tCntrl2.cboSlot.SelectedItem = array3[2];
					}
					return;
				}
				catch
				{
					return;
				}
			}
			Form owner = Program.TopMost_();
			string text11 = "Error While Processing Ticket, Please try again later!";
			string caption = "Read Failed";
			MessageBox.Show(owner, text11, caption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		catch (Exception ex)
		{
			string string_2 = "frmProcessTicket LoadTktControl";
			Class28.smethod_26(string_2, ex.Message);
			Form owner2 = Program.TopMost_();
			string text12 = "Error Occured while  Processing Opening the Ticket";
			MessageBox.Show(owner2, text12);
		}
	}

	public void ThreadProcUnsafe(object j)
	{
		bool flag = false;
		bool flag2 = false;
		try
		{
			foreach (Control control3 in base.Controls)
			{
				string name = control3.Name;
				string text = "pnl";
				if (!(name == text))
				{
					continue;
				}
				foreach (Control control4 in control3.Controls)
				{
					TCntrl tCntrl = control4 as TCntrl;
					int num = int_1 + int_2;
					if (int_1 == int_2)
					{
						flag = true;
					}
					for (int i = 1; i < num; i++)
					{
						if (!frmMain.chAuto)
						{
							Application.DoEvents();
							tCntrl.button1.PerformClick();
						}
						else if (!flag)
						{
							if ((int_1 == 0) | (int_2 == 0))
							{
								flag2 = true;
							}
							if (int_1 > 0)
							{
								if (!flag2)
								{
									if (i != 1)
									{
										i++;
									}
									int_1--;
								}
								StatClass.WebLogin = true;
								StatClass.ApptLogin = false;
								StatClass.DishaLogin = false;
								Application.DoEvents();
								tCntrl.button1.PerformClick();
							}
							if (int_2 > 0)
							{
								if (!flag2)
								{
									i++;
									int_2--;
								}
								StatClass.ApptLogin = true;
								StatClass.WebLogin = false;
								StatClass.DishaLogin = false;
								Application.DoEvents();
								tCntrl.button1.PerformClick();
							}
						}
						else
						{
							if (int_2 > 0)
							{
								int_2--;
								StatClass.ApptLogin = true;
								StatClass.WebLogin = false;
								Application.DoEvents();
								tCntrl.button1.PerformClick();
							}
							if (int_1 > 1)
							{
								int_1--;
								StatClass.WebLogin = true;
								StatClass.ApptLogin = false;
								StatClass.DishaLogin = false;
								Application.DoEvents();
								tCntrl.button1.PerformClick();
							}
						}
					}
					StatClass.WebLogin = false;
					StatClass.ApptLogin = false;
					StatClass.DishaLogin = false;
				}
			}
		}
		catch
		{
		}
	}

	private void method_1(object sender, EventArgs e)
	{
		if (sender is TCntrl { class48_0: var class48_ } tCntrl)
		{
			if (!Program.bool_7)
			{
				string text = "Booking Stop Non-Payment.";
				tCntrl.StatusChange(53, text);
				string text2 = "Non Payment ke karan Aapka Booking stop he, aapke seller se contact kijiye.";
				string caption = "Booking Stop";
				MessageBox.Show(text2, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			try
			{
				DateTime dateTime = new DateTime(int.Parse(class48_.string_6), int.Parse(class48_.string_5), int.Parse(class48_.string_4));
				int year = DateTime.Now.Year;
				int month = DateTime.Now.Month;
				int day = DateTime.Now.Day;
				DateTime dateTime2 = new DateTime(year, month, day);
				if (dateTime.Ticks < dateTime2.Ticks)
				{
					string text3 = "Journey date cannot be less than current date.";
					tCntrl.StatusChange(53, text3);
					string text4 = "Journey date cannot be less than current date. Please check Journey Date";
					string caption2 = "Journey Date";
					MessageBox.Show(text4, caption2, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					tCntrl.timer_0.Enabled = false;
					tCntrl.BottomPanel.Visible = false;
					return;
				}
			}
			catch
			{
			}
			string text5 = class48_.string_8.ToUpper();
			string text6 = "TQ";
			if (text5 == text6)
			{
				long ticks = new DateTime(int.Parse(class48_.string_6), int.Parse(class48_.string_5), int.Parse(class48_.string_4)).Ticks;
				int year2 = DateTime.Now.Year;
				int month2 = DateTime.Now.Month;
				int day2 = DateTime.Now.Day;
				long ticks2 = new DateTime(year2, month2, day2).Ticks;
				long ticks3 = ticks - ticks2;
				TimeSpan timeSpan = new TimeSpan(ticks3);
				if (timeSpan.TotalDays >= 2.0 && (timeSpan.TotalDays > 3.0 || DateTime.Now.Hour < 7 || (DateTime.Now.Hour == 7 && DateTime.Now.Minute < 1)))
				{
					string text7 = "Schedule tatkal tickets only after 9:00AM";
					tCntrl.StatusChange(53, text7);
					Form owner = Program.TopMost_();
					string text8 = "Sorry, You can schedule tatkal tickets only after 9:00AM";
					MessageBox.Show(owner, text8);
					tCntrl.timer_0.Enabled = false;
					tCntrl.BottomPanel.Visible = false;
					return;
				}
			}
			class48_.bool_4 = class48_.string_24.Length > 4;
			class48_.bool_5 = tCntrl.chkConfirmation.Checked;
			class48_.int_0 = tCntrl.cboSlot.SelectedIndex;
			class48_.rectangle_0 = new Rectangle(tCntrl.Location, tCntrl.Size);
			if (class48_.string_23 != tCntrl.cboGateway.SelectedItem.ToString())
			{
				class48_.string_23 = tCntrl.cboGateway.SelectedItem.ToString();
				class48_.string_24 = Program.dictionary_00[tCntrl.cboGateway.SelectedItem.ToString()];
			}
			CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
			WorkParams parameter = new WorkParams
			{
				Payload = class48_,
				Token = cancellationTokenSource.Token
			};
			Thread thread = new Thread(method_7);
			thread.IsBackground = true;
			thread.SetApartmentState(ApartmentState.STA);
			thread.Name = tCntrl.Name;
			thread.Start(parameter);
			class48_.string_23.ToUpper();
			string text9 = "Ready: ";
			tCntrl.StatusChange(0, text9 + class48_.string_12);
			tCntrl.EditlinkLabel.Enabled = false;
			tCntrl.BottomPanel.Visible = true;
			tCntrl.WebLogin.Enabled = false;
			tCntrl.AppLogin_.Visible = false;
			tCntrl.button2.Visible = false;
			tCntrl.button2.Enabled = false;
			tCntrl.btnWeb3.Visible = false;
			tCntrl.WebLogin.Visible = false;
			tCntrl.WebLogin.Enabled = false;
			tCntrl.btnDish.Enabled = false;
			tCntrl.btnDish.Visible = false;
			tCntrl.btnSlotNo.Enabled = false;
			tCntrl.cboSlot.Enabled = false;
			tCntrl.cboQuota.Enabled = false;
			tCntrl.cboClass.Enabled = false;
			tCntrl.cboID.Enabled = false;
			tCntrl.btnEdit.Enabled = false;
			tCntrl.cboTrain.Enabled = false;
			tCntrl.timer_0.Enabled = true;
			if (StatClass.VideoMode)
			{
				string[] array = tCntrl.cboGateway.Text.Split('_');
				ComboBox.ObjectCollection items = tCntrl.fake_bank.Items;
				string text10 = array[0];
				string text11 = "_XXXXXXXX";
				items.Add(text10 + text11);
				tCntrl.fake_bank.SelectedIndex = 0;
				tCntrl.fake_bank.Location = tCntrl.cboGateway.Location;
				tCntrl.cboGateway.Visible = false;
				tCntrl.fake_id.SelectedIndex = 0;
				tCntrl.fake_id.Location = tCntrl.cboID.Location;
				tCntrl.cboID.Visible = false;
				tCntrl.fake_id.Visible = true;
				tCntrl.fake_bank.Visible = true;
				tCntrl.fake_id.Enabled = false;
				tCntrl.fake_bank.Enabled = false;
			}
			tCntrl.Tag = thread;
		}
		else
		{
			Form owner2 = Program.TopMost_();
			string text12 = "Couldn't Start the execution of ticket!";
			MessageBox.Show(owner2, text12);
		}
	}

	private void method_2(object sender, EventArgs e)
	{
		if (Class28.dictionary_0[int_3] <= 1)
		{
			if (sender is TCntrl tCntrl)
			{
				frmAddTkt frmAddTkt2 = new frmAddTkt();
				frmAddTkt2.dictionary_1 = Program.dictionary_0;
				string text = "Edit Ticket";
				frmAddTkt2.Text = text;
				frmAddTkt2.bool_0 = true;
				frmAddTkt2.EditLoad(tCntrl.class48_0);
				if (frmAddTkt2.ShowDialog() == DialogResult.OK)
				{
					tCntrl.method_0(frmAddTkt2.method_12());
					Form owner = Program.TopMost_();
					string text2 = "Edited Ticket Loaded Successfully!";
					string caption = "Edit Done";
					MessageBox.Show(owner, text2, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				frmAddTkt2.Dispose();
			}
		}
		else
		{
			string text3 = "Sorry Pairs already Open and This Ticket can't Modify, Please close all pairs to Modify Ticket";
			string caption2 = "Modification";
			MessageBox.Show(text3, caption2, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
	}

	private void Method_33(object sender, EventArgs e)
	{
		if (!(sender is TCntrl tCntrl))
		{
			return;
		}
		try
		{
			if (tCntrl.Tag is WorkerHandle workerHandle)
			{
				try
				{
					workerHandle.Cts?.Cancel();
					workerHandle.Cts?.Dispose();
				}
				catch
				{
				}
				try
				{
					if (workerHandle.Thread != null && workerHandle.Thread.IsAlive)
					{
						workerHandle.Thread.Join(5000);
					}
				}
				catch
				{
				}
			}
			pnl.Controls.Remove(tCntrl);
			Dictionary<string, string> list_SelectedIRCTCid = Program.list_SelectedIRCTCid;
			string key = tCntrl.cboID.Text;
			string value = "free";
			list_SelectedIRCTCid[key] = value;
			tCntrl.Dispose();
			int_0 = Class28.dictionary_9[string_0];
			if (int_0 == 0)
			{
				Class28.dictionary_8.Remove(string_0);
				Class28.dictionary_9.Remove(string_0);
				Interlocked.Decrement(ref StatClass.TotalOpendTicket);
			}
			else
			{
				Interlocked.Decrement(ref int_0);
				Class28.dictionary_9[string_0] = int_0;
			}
			Interlocked.Decrement(ref StatClass.TotalOpendWindow);
			_ = Class28.dictionary_9.Count;
			close_ = true;
			Close();
		}
		catch
		{
		}
	}

	private void Method_3(object sender, EventArgs e)
	{
		if (!(sender is TCntrl tCntrl))
		{
			return;
		}
		Thread thread = null;
		if (tCntrl.Tag != null)
		{
			thread = (Thread)tCntrl.Tag;
		}
		try
		{
			if (thread != null)
			{
				try
				{
					thread?.Abort();
				}
				catch (Exception)
				{
				}
			}
			pnl.Controls.Remove(tCntrl);
			Dictionary<string, string> list_SelectedIRCTCid = Program.list_SelectedIRCTCid;
			string key = tCntrl.cboID.Text;
			string value = "free";
			list_SelectedIRCTCid[key] = value;
			tCntrl.Dispose();
			int_0 = Class28.dictionary_9[string_0];
			if (int_0 != 0)
			{
				Interlocked.Decrement(ref int_0);
				Class28.dictionary_9[string_0] = int_0;
			}
			else
			{
				Class28.dictionary_8.Remove(string_0);
				Class28.dictionary_9.Remove(string_0);
				Interlocked.Decrement(ref StatClass.TotalOpendTicket);
			}
			Interlocked.Decrement(ref StatClass.TotalOpendWindow);
			_ = Class28.dictionary_9.Count;
			close_ = true;
			Close();
		}
		catch (Exception)
		{
			try
			{
				pnl.Controls.Remove(tCntrl);
				Dictionary<string, string> list_SelectedIRCTCid2 = Program.list_SelectedIRCTCid;
				string key2 = tCntrl.cboID.Text;
				string value2 = "free";
				list_SelectedIRCTCid2[key2] = value2;
				tCntrl.Dispose();
				int_0 = Class28.dictionary_9[string_0];
				if (int_0 == 0)
				{
					Class28.dictionary_8.Remove(string_0);
					Class28.dictionary_9.Remove(string_0);
					Interlocked.Decrement(ref StatClass.TotalOpendTicket);
				}
				else
				{
					Interlocked.Decrement(ref int_0);
					Class28.dictionary_9[string_0] = int_0;
				}
				Interlocked.Decrement(ref StatClass.TotalOpendWindow);
				_ = Class28.dictionary_9.Count;
				close_ = true;
				Close();
			}
			catch (Exception)
			{
			}
		}
	}

	private void method_4(object sender, EventArgs e)
	{
		if (WindowCount() < Program.WindowCount)
		{
			int_0 = Class28.dictionary_9[string_0] + 1;
			int num = int_0;
			string keyStatus = Program.KeyStatus;
			string text = "Paid";
			bool flag = keyStatus == text;
			string keyType = Program.KeyType;
			string text2 = "demo";
			if (flag & (keyType != text2))
			{
				StatClass.int_MaxPair = Program.paidpair;
			}
			else
			{
				StatClass.int_MaxPair = Program.unpaidpair;
			}
			if (num < StatClass.int_MaxPair)
			{
				try
				{
					if (Class28.bool_1)
					{
						string[] array = new string[5] { string_0, null, null, null, null };
						string text3 = "^#^0^#^0^#^";
						array[1] = text3;
						array[2] = frmMain.chAuto.ToString();
						string text4 = "^#^";
						array[3] = text4;
						array[4] = string_2;
						string expression = string.Concat(array);
						string delimiter = "^#^";
						string[] array2 = Strings.Split(expression, delimiter);
						if (array2.Length > 4)
						{
							StatClass.lblTktName = array2[0];
							StatClass.int_TotalNoOfPair = int.Parse(array2[1]);
							StatClass.int_NoOfConnect = int.Parse(array2[2]);
							frmMain.chAuto = bool.Parse(array2[3]);
							StatClass.TimeStr = array2[4];
						}
						string[] array3 = new string[5] { string_0, null, null, null, null };
						string text5 = "^#^0^#^0^#^";
						array3[1] = text5;
						array3[2] = frmMain.chAuto.ToString();
						string text6 = "^#^";
						array3[3] = text6;
						array3[4] = string_2;
						string text7 = string.Concat(array3);
						if (Class28.dictionary_9.ContainsKey(StatClass.lblTktName))
						{
							int value = (int_0 = Class28.dictionary_9[StatClass.lblTktName] + 1);
							Class28.dictionary_9[StatClass.lblTktName] = value;
							int_3 = Class28.dictionary_8[StatClass.lblTktName];
						}
						frmProcessTicket frmProcessTicket2 = new frmProcessTicket(text7, Colour0, bool_1: true, int_3, int_0);
						string[] array4 = new string[6] { string_0, null, null, null, null, null };
						string text8 = "[ PairID: ";
						array4[1] = text8;
						array4[2] = int_3.ToString();
						string text9 = "-";
						array4[3] = text9;
						array4[4] = int_0.ToString();
						string text10 = " ]";
						array4[5] = text10;
						frmProcessTicket2.Text = string.Concat(array4);
						frmProcessTicket2.FormClosed += smethod_0;
						foreach (Form openForm in Application.OpenForms)
						{
							if (openForm.Tag != null && openForm.Tag is int && (int)openForm.Tag == int_3)
							{
								frmProcessTicket2.StartPosition = FormStartPosition.Manual;
								frmProcessTicket2.Top = openForm.Top;
								int num2 = openForm.Width * num + openForm.Left;
								if (num2 <= Screen.PrimaryScreen.Bounds.Width - (base.Width - 50))
								{
									frmProcessTicket2.Left = num2 + num * 2;
								}
								else
								{
									if (totalw == 0)
									{
										totalw = num;
										numleft = 5;
										if (!line2)
										{
											line2 = true;
											top = openForm.Top + base.Height;
										}
										else if (line3)
										{
											if (!line4)
											{
												totalw /= 3;
												line4 = true;
												top = openForm.Top + base.Height + base.Height + base.Height;
											}
											else
											{
												totalw /= 4;
												line4 = true;
												top = openForm.Top + base.Height + top;
											}
										}
										else
										{
											totalw /= 2;
											line3 = true;
											top = openForm.Top + base.Height + base.Height;
										}
									}
									frmProcessTicket2.Left = numleft + numlR * 2;
									frmProcessTicket2.Top = top + 2;
									numleft += openForm.Width + 2;
									totalw--;
								}
								break;
							}
						}
						frmProcessTicket2.Show();
					}
					else
					{
						method_0(bool_1: true, bool_2: false);
					}
					return;
				}
				catch
				{
					return;
				}
			}
			if (StatClass.int_MaxPair == 12)
			{
				Form owner = Program.TopMost_();
				string text11 = "You cannot Open more Than ";
				string text12 = StatClass.int_MaxPair.ToString();
				string text13 = " Pairs at a time on UnPaid and Demo ID";
				string text14 = text11 + text12 + text13;
				string caption = "UnPaid Limitation";
				MessageBox.Show(owner, text14, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				Form owner2 = Program.TopMost_();
				string text15 = "You cannot Open more Than ";
				string text16 = StatClass.int_MaxPair.ToString();
				string text17 = " Pairs at a time.";
				string text18 = text15 + text16 + text17;
				string caption2 = "Limitation";
				MessageBox.Show(owner2, text18, caption2, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
		else
		{
			Form owner3 = Program.TopMost_();
			string text19 = "You cannot Open more Than ";
			string text20 = StatClass.int_MaxPair.ToString();
			string text21 = " Window at a time.";
			string text22 = text19 + text20 + text21;
			string caption3 = "Limitation";
			MessageBox.Show(owner3, text22, caption3, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
	}

	private void method_6(object sender, EventArgs e)
	{
		if (sender is TCntrl tCntrl)
		{
			if (tCntrl.Tag != null)
			{
				((Thread)tCntrl.Tag).IsBackground = true;
			}
			tCntrl.TCntrll();
		}
	}

	private void method_7(object object_0)
	{
		try
		{
			WorkParams workParams = object_0 as WorkParams;
			CancellationToken token = workParams?.Token ?? CancellationToken.None;
			object obj;
			if (workParams == null)
			{
				obj = null;
			}
			else
			{
				obj = workParams.Payload;
				if (obj != null)
				{
					goto IL_0044;
				}
			}
			obj = object_0;
			goto IL_0044;
			IL_0044:
			object obj2 = obj;
			token.ThrowIfCancellationRequested();
			if (frmLogin.openDate.Day == DateAndTime.Now.Day)
			{
				Class48 @class = (Class48)obj2;
				if (Program.int_2 > 0)
				{
					method_10(0, Thread.CurrentThread.Name);
					@class.string_40 = Thread.CurrentThread.Name;
					TCntrl tCntrl = pnl.Controls[Thread.CurrentThread.Name] as TCntrl;
					Rectangle rect = new Rectangle(tCntrl.Location, tCntrl.Size);
					UpdateTStatus updtStatus = Status;
					string[] array = new string[8]
					{
						Program.string_3,
						null,
						null,
						null,
						null,
						null,
						null,
						null
					};
					string text = "||";
					array[1] = text;
					array[2] = Program.int_0.ToString();
					string text2 = "||";
					array[3] = text2;
					array[4] = Program.clientID;
					string text3 = "||";
					array[5] = text3;
					array[6] = Program.int_Slot.ToString();
					string text4 = "||";
					array[7] = text4;
					string text5 = string.Concat(array);
					string value = "";
					if (Program.dictionary_1.Count > 0)
					{
						int num = @class.int_0;
						int num2 = ((num == 1 || num == 2) ? 1 : 2);
						int key = num2;
						Program.dictionary_1.TryGetValue(key, out value);
					}
					string userDetails = text5 + value;
					string text6;
					while (true)
					{
						text6 = tCntrl.cboID.SelectedItem.ToString();
						try
						{
							if (list_0.Contains(text6))
							{
								tCntrl.cboID.SelectedIndex++;
								continue;
							}
						}
						catch
						{
						}
						break;
					}
					list_0.Add(text6);
					string text7 = Program.dictionary_0[text6];
					@class.string_13 = text6;
					@class.string_14 = text7;
					string text8 = "||";
					string text9 = text6 + text8 + text7;
					string text11;
					if (tCntrl.cboQuota.SelectedItem.ToString() != @class.string_8)
					{
						string text10 = "||";
						text11 = text9 + text10 + tCntrl.cboQuota.SelectedItem.ToString();
					}
					else
					{
						string text12 = "||";
						text11 = text9 + text12 + @class.string_8;
					}
					string text13 = text11;
					string text15;
					if (tCntrl.cboClass.SelectedItem.ToString() != @class.string_7)
					{
						string text14 = "||";
						text15 = text13 + text14 + tCntrl.cboClass.SelectedItem.ToString();
					}
					else
					{
						string text16 = "||";
						text15 = text13 + text16 + @class.string_7;
					}
					string text17 = text15;
					if (@class.string_2 != @class.string_2a)
					{
						string[] array2 = new string[7] { text17, null, null, null, null, null, null };
						string text18 = "||";
						array2[1] = text18;
						array2[2] = @class.string_0a;
						string text19 = "||";
						array2[3] = text19;
						array2[4] = @class.string_1a;
						string text20 = "||";
						array2[5] = text20;
						array2[6] = @class.string_2a;
						text17 = string.Concat(array2);
					}
					string text21 = int_3.ToString();
					string text22 = tCntrl.cboSlot.SelectedIndex.ToString();
					string string_ = @class.string_12;
					string text23 = "-";
					string text24 = string_ + text23 + text22;
					try
					{
						if (list_1.Contains(text24))
						{
							int startIndex = text24.IndexOf(@class.string_12);
							string value2 = "-";
							int startIndex2 = text24.IndexOf(value2, startIndex) + 1;
							string text25 = text24.Substring(startIndex2);
							string text26 = tCntrl.cboSlot.SelectedIndex.ToString();
							if (text25 != text26)
							{
								tCntrl.cboSlot.SelectedIndex = int.Parse(text25);
							}
						}
					}
					catch
					{
					}
					list_1.Add(text24);
					string text27 = "0";
					string text28 = text27;
					int selectedIndex = tCntrl.cboSlot.SelectedIndex;
					if (Program.list_3.Count != 0 && Program.list_Proxy.Count != Program.list_Proxy.Count + Program.list_3.Count)
					{
						Program.list_Proxy.AddRange(Program.list_3);
					}
					if (Program.list_Proxy.Count > 0)
					{
						text28 = getslotIP(tCntrl.cboSlot.SelectedIndex);
					}
					string[] array3 = new string[5] { text28, null, null, null, null };
					string text29 = "#";
					array3[1] = text29;
					array3[2] = Program.mySettings_0.Ac_avl;
					string text30 = "#";
					array3[3] = text30;
					array3[4] = Program.mySettings_0.Sl_avl;
					text28 = string.Concat(array3);
					string text31 = "";
					string string_2 = @class.string_23;
					string value3 = "IMPS";
					if (string_2.Contains(value3))
					{
						frmOTP frmOTP2 = new frmOTP(bool_2: true, @class.string_23);
						frmOTP2.StartPosition = FormStartPosition.Manual;
						frmOTP2.Location = tCntrl.PointToScreen(Point.Empty);
						frmOTP2.ShowDialog();
						if (frmOTP2.DialogResult != DialogResult.OK)
						{
							string text32 = "OTP Required for Payment";
							tCntrl.StatusChange(53, text32);
							return;
						}
						string text33 = "||";
						text31 = text33 + frmOTP2.string_0;
						frmOTP2.Dispose();
					}
					if (!string.IsNullOrEmpty(@class.string_244))
					{
						string string_3 = @class.string_23;
						string text34 = "-+-";
						@class.string_23 = string_3 + text34 + @class.string_233;
						string string_4 = @class.string_24;
						string text35 = "-+-";
						@class.string_24 = string_4 + text35 + @class.string_244;
					}
					string[] array4 = new string[12]
					{
						text21, null, null, null, null, null, null, null, null, null,
						null, null
					};
					string text36 = "-.-";
					array4[1] = text36;
					array4[2] = @class.string_23;
					string text37 = "-.-";
					array4[3] = text37;
					array4[4] = @class.string_24;
					array4[5] = text31;
					string text38 = "-.-";
					array4[6] = text38;
					int num3 = tCntrl.int_1;
					array4[7] = num3.ToString();
					string text39 = "-.-";
					array4[8] = text39;
					array4[9] = tCntrl.bool_0.ToString();
					string text40 = "-.-";
					array4[10] = text40;
					array4[11] = tCntrl.int_2.ToString();
					string txnID = string.Concat(array4);
					string text41 = text28;
					string text42 = "!";
					int loginType = tCntrl.loginType;
					text28 = text41 + text42 + loginType + text42 + StatClass.stopipblock + text42 + StatClass.operalogin + text42 + StatClass.manualclick + text42 + StatClass.cometlogin + text42 + Program.availtime + text42 + StatClass.app1 + text42 + StatClass.directlogin + text42 + StatClass.unverifiedbook + text42 + StatClass.stopipblocknew;
					int selectedIndex2 = tCntrl.cboID.SelectedIndex;
					int selectedIndex3 = tCntrl.cboSlot.SelectedIndex;
					int selectedIndex4 = tCntrl.cboGateway.SelectedIndex;
					mcommInstance = new IRComm();
					mcommInstance.SetCon(Class34.string_Database);
					bool flag = mcommInstance.PerformB(pnl, rect, @class.string_12, userDetails, text17, @class.string_40, ref txnID, tCntrl.chkConfirmation.Checked, tCntrl.ChkAutoLogin, tCntrl.bool_1, selectedIndex, updtStatus, text28, token);
					try
					{
						mcommInstance?.Dispose();
						list_0.Remove(text6);
						if (flag)
						{
							Interlocked.Decrement(ref Program.int_2);
							Interlocked.Increment(ref Class28.int_0);
							return;
						}
						if (StatClass.VideoMode)
						{
							tCntrl.cboID.SelectedIndex = selectedIndex2;
							tCntrl.cboSlot.SelectedIndex = selectedIndex3;
							tCntrl.cboGateway.SelectedIndex = selectedIndex4;
						}
						string text43 = text28;
						string text44 = "faield";
						bool flag2 = text43 != text44;
						string text45 = text28;
						string text46 = "success";
						if (flag2 | (text45 != text46))
						{
							tCntrl.cboID.Enabled = true;
							tCntrl.cboSlot.Enabled = true;
							tCntrl.cboQuota.Enabled = true;
							tCntrl.cboClass.Enabled = true;
							tCntrl.cboTrain.Enabled = true;
							tCntrl.cboGateway.Enabled = true;
							tCntrl.btnSlotNo.Enabled = true;
							tCntrl.WebLogin.Enabled = true;
							tCntrl.WebLogin.Visible = true;
							tCntrl.AppLogin_.Enabled = true;
							tCntrl.AppLogin_.Visible = true;
							tCntrl.button2.Enabled = true;
							tCntrl.button2.Visible = true;
							tCntrl.btnWeb3.Enabled = true;
							tCntrl.btnWeb3.Visible = true;
							tCntrl.btnDish.Enabled = true;
							tCntrl.btnDish.Visible = true;
							tCntrl.WebLogin.Visible = true;
							tCntrl.BottomPanel.Visible = false;
						}
						return;
					}
					catch
					{
						return;
					}
				}
				Form owner = Program.TopMost_();
				string text47 = "Sorry, you do not have sufficient credits!";
				MessageBox.Show(owner, text47);
			}
			else
			{
				Form owner2 = Program.TopMost_();
				string text48 = "Restart You Application";
				string caption = "Limitation";
				MessageBox.Show(owner2, text48, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
		catch (ThreadAbortException)
		{
			Thread.ResetAbort();
		}
		catch (Exception)
		{
		}
	}

	internal string getslotIP(int SLOT)
	{
		string text = "0";
		string result = text;
		try
		{
			switch (SLOT)
			{
			case 3:
			case 4:
				result = Program.list_Proxy[0];
				break;
			case 5:
			case 6:
				result = Program.list_Proxy[1];
				break;
			case 7:
			case 8:
				result = Program.list_Proxy[2];
				break;
			case 9:
			case 10:
				result = Program.list_Proxy[3];
				break;
			}
		}
		catch
		{
		}
		return result;
	}

	private void Status(int int_3, string string_4, string string_5)
	{
		try
		{
			switch (int_3)
			{
			case 1017:
			{
				int num = WindowCount();
				mcommInstance.SetData(string_4, num.ToString());
				return;
			}
			case 1001:
			{
				string[] array5 = new string[1];
				string text3 = "||";
				array5[0] = text3;
				string[] array6 = string_4.Split(array5, StringSplitOptions.None);
				string value2 = Staticm.Debit_Encoding(string_4);
				if (array6.Length < 3)
				{
					string text4 = "INVALID";
					value2 = text4;
				}
				mcommInstance.SetData(array6[0], value2);
				return;
			}
			case 1002:
			{
				string[] array3 = new string[1];
				string text2 = "||";
				array3[0] = text2;
				string[] array4 = string_4.Split(array3, StringSplitOptions.None);
				string airtel_Encryption = Staticm.GetAirtel_Encryption(array4[1]);
				mcommInstance.SetData(array4[0], airtel_Encryption);
				return;
			}
			case 1003:
			{
				string[] array7 = new string[1];
				string text5 = "||";
				array7[0] = text5;
				string[] array8 = string_4.Split(array7, StringSplitOptions.None);
				string value3 = Staticm.IDBI_Encoding(array8[1], array8[2]);
				mcommInstance.SetData(array8[0], value3);
				return;
			}
			case 1004:
			{
				string[] array = new string[1];
				string text = "||";
				array[0] = text;
				string[] array2 = string_4.Split(array, StringSplitOptions.None);
				string value = Staticm.ICICI_Encoding(array2[1], array2[2]);
				mcommInstance.SetData(array2[0], value);
				return;
			}
			case 1005:
			{
				string[] array17 = new string[1];
				string text10 = "||";
				array17[0] = text10;
				string[] array18 = string_4.Split(array17, StringSplitOptions.None);
				string value8 = Staticm.UNION_Encoding(array18[1], array18[2]);
				mcommInstance.SetData(array18[0], value8);
				return;
			}
			case 1006:
			{
				string[] array15 = new string[1];
				string text9 = "-";
				array15[0] = text9;
				string[] array16 = string_4.Split(array15, StringSplitOptions.None);
				string value7 = Staticm.SBI_OTPing(array16[1]);
				mcommInstance.SetData(array16[0], value7);
				return;
			}
			case 1007:
			{
				string[] array13 = new string[1];
				string text8 = "#-#";
				array13[0] = text8;
				string[] array14 = string_4.Split(array13, StringSplitOptions.None);
				string value6 = Staticm.PAYTM_OTPing(array14[1]);
				mcommInstance.SetData(array14[0], value6);
				return;
			}
			case 2025:
			{
				string[] array11 = new string[1];
				string text7 = "||";
				array11[0] = text7;
				string[] array12 = string_4.Split(array11, StringSplitOptions.None);
				kewirctcLogin = new kewirctcLogin();
				string value5 = kewirctcLogin.ConnectHttpJava(array12[1]);
				mcommInstance.SetData(array12[0], value5);
				return;
			}
			case 1919:
			{
				string proxy = Staticm.GetProxy(string_5);
				mcommInstance.SetData(string_4, proxy);
				return;
			}
			case 1018:
			{
				string[] array9 = new string[1];
				string text6 = "||";
				array9[0] = text6;
				string[] array10 = string_4.Split(array9, StringSplitOptions.None);
				string value4 = Staticm.AkamaiToken(array10[1], array10[2], array10[3]);
				mcommInstance.SetData(array10[0], value4);
				return;
			}
			}
			if (!base.InvokeRequired)
			{
				if (pnl.Controls[string_5] is TCntrl tCntrl)
				{
					if (int_3 != 4)
					{
						tCntrl.StatusChange(int_3, string_4);
					}
					else
					{
						BookingSuccess(string_4, tCntrl);
					}
				}
			}
			else
			{
				Invoke(new UpdateTStatus(Status), int_3, string_4, string_5);
			}
		}
		catch (Exception ex)
		{
			string text11 = "SetUpdatedStatus statusCode: ";
			Class28.smethod_26(text11 + int_3, ex.Message);
		}
	}

	public static int WindowCount()
	{
		int num = 0;
		List<Form> list = new List<Form>();
		foreach (Form openForm in Application.OpenForms)
		{
			list.Add(openForm);
		}
		foreach (Form item in list)
		{
			string name = item.Name;
			string text = "frmProcessTicket";
			if (name == text)
			{
				num++;
			}
		}
		return num;
	}

	private void BookingSuccess(string string_4, TCntrl tcntrl_0)
	{
		DateTime dateTime = default(DateTime);
		try
		{
			string text = "";
			string text2 = "WEB";
			string text3 = text2;
			if (tcntrl_0.Applogin)
			{
				string text4 = "APP";
				text3 = text4;
			}
			_ = tcntrl_0.lblStatus.Text;
			_ = tcntrl_0.lblTime.Text;
			string text5 = "WEB";
			string text6 = text5;
			switch (tcntrl_0.loginType)
			{
			case 1:
			{
				string text10 = "WEB";
				text6 = text10;
				break;
			}
			case 2:
			{
				string text9 = "APP";
				text6 = text9;
				break;
			}
			case 3:
			{
				string text8 = "WEB-2";
				text6 = text8;
				break;
			}
			case 4:
			{
				string text7 = "WEB-3";
				text6 = text7;
				break;
			}
			}
			tcntrl_0.lblLoginType.Text = text6;
			bool flag = false;
			string[] array = string_4.Split('#');
			string[] array2 = array[0].Split('|');
			tcntrl_0.lblBank.Text = array2[4];
			string text11 = array[1];
			string text12 = string_4;
			string value = "#txn";
			if (text12.Contains(value))
			{
				string text13 = array[2];
				string oldValue = "txn";
				string[] array3 = text13.Replace(oldValue, "").Split('|');
				int num = int.Parse(array3[0]);
				int num2 = int.Parse(array3[1]);
				dateTime = DateTime.Parse(array[1]);
				int millisecond = DateTime.Now.Millisecond;
				DateTime dateTime2 = default(DateTime);
				if ((((dateTime.Hour == 10) | (dateTime.Hour == 11)) & (num == dateTime.Minute)) && millisecond > 500)
				{
					dateTime2 = dateTime;
					dateTime2 = dateTime2.AddSeconds(-num2);
					if (millisecond > 900)
					{
						dateTime2 = dateTime2.AddSeconds(1.0);
					}
					else if (millisecond <= 800)
					{
						if (millisecond > 700)
						{
							dateTime2 = dateTime2.AddSeconds(3.0);
						}
						else if (millisecond <= 600)
						{
							if (millisecond > 500)
							{
								dateTime2 = dateTime2.AddSeconds(5.0);
							}
						}
						else
						{
							dateTime2 = dateTime2.AddSeconds(4.0);
						}
					}
					else
					{
						dateTime2 = dateTime2.AddSeconds(2.0);
					}
					string text14 = "hh:mm:ss";
					text11 = dateTime2.ToString(text14);
					Label lblStatus = tcntrl_0.lblStatus;
					string text15 = text3;
					string text16 = ": Success by Hitman : ";
					lblStatus.Text = text15 + text16 + text11;
					tcntrl_0.lblTime.Text = text11;
					flag = true;
				}
				string text17 = array[0];
				string text18 = "#";
				string_4 = text17 + text18 + text11;
			}
			string text19 = "########";
			object value2 = text19;
			string text20 = "########";
			string text21 = text20;
			object selectedItem = tcntrl_0.cboID.SelectedItem;
			string text22 = selectedItem.ToString();
			object selectedItem2 = tcntrl_0.cboGateway.SelectedItem;
			if (StatClass.VideoMode)
			{
				text22 = text21;
			}
			if (!flag)
			{
				tcntrl_0.lblTime.Text = array[1];
				tcntrl_0.lbl_time.Text = array[1];
			}
			string text23 = "Logs\\";
			string clientID = Program.clientID;
			string text24 = string_0;
			string text25 = ".jpg";
			string path = text23 + clientID + text24 + text25;
			string text26 = "Logs\\";
			string clientID2 = Program.clientID;
			string text27 = string_0;
			string text28 = "0.jpg";
			string path2 = text26 + clientID2 + text27 + text28;
			string text29 = GetBankName(tcntrl_0.cboGateway.SelectedItem.ToString());
			try
			{
				string text30 = "Hitman";
				Text = text30;
				string text31 = text29;
				string text32 = "_";
				text29 = text31 + text32 + text21;
				tcntrl_0.pnlBrand.BringToFront();
				tcntrl_0.pnlBrand.Location = new Point(0, 39);
				tcntrl_0.cboID.Visible = false;
				tcntrl_0.cboSlot.Visible = false;
				tcntrl_0.chkConfirmation.Visible = false;
				tcntrl_0.cboGateway.Visible = false;
				tcntrl_0.cboQuota.Visible = false;
				tcntrl_0.btnEdit.Visible = false;
				tcntrl_0.BtnOpenPair.Visible = false;
				tcntrl_0.AppLogin_.Visible = false;
				tcntrl_0.btnDish.Visible = false;
				tcntrl_0.button2.Visible = false;
				tcntrl_0.WebLogin.Visible = false;
				tcntrl_0.btnWeb3.Visible = false;
				tcntrl_0.fake_id.Visible = false;
				tcntrl_0.fake_bank.Visible = false;
				base.TopMost = true;
				Staticm.Sleep_Thread(50);
				try
				{
					string path3 = "\\Logs";
					if (!Directory.Exists(path3))
					{
						string path4 = "\\Logs";
						Directory.CreateDirectory(path4);
					}
					Refresh();
					Bitmap bitmap = new Bitmap(base.Width, base.Height);
					DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
					using MemoryStream memoryStream = new MemoryStream();
					bitmap.Save(memoryStream, ImageFormat.Png);
					text = Convert.ToBase64String(memoryStream.ToArray());
				}
				catch
				{
				}
			}
			finally
			{
				try
				{
					tcntrl_0.cboID.SelectedItem = selectedItem;
					tcntrl_0.cboGateway.SelectedItem = selectedItem2;
					Label lbl_slot = tcntrl_0.lbl_slot;
					string text33 = "User:-";
					string text34 = text33;
					string text35 = text22;
					string text36 = " Slot:-";
					string text37 = text36;
					lbl_slot.Text = text34 + text35 + text37 + tcntrl_0.cboSlot.SelectedItem;
					tcntrl_0.cboGateway.Items.Remove(value2);
					if (text29.Length > 2)
					{
						tcntrl_0.cboGateway.Items.Remove(text29);
					}
				}
				catch
				{
				}
			}
			if (flag)
			{
				string text38 = "hh:mm:ss";
				text11 = dateTime.ToString(text38);
				Label lblStatus2 = tcntrl_0.lblStatus;
				string text39 = text3;
				string text40 = ": Success by Hitman : ";
				lblStatus2.Text = text39 + text40 + text11;
				tcntrl_0.lblTime.Text = text11;
			}
			WaitCallback callBack = Staticm.method_8ii;
			string[] array4 = new string[3] { string_4, null, null };
			string text41 = "#";
			array4[1] = text41;
			array4[2] = text;
			ThreadPool.QueueUserWorkItem(callBack, string.Concat(array4));
			try
			{
				File.Delete(path);
				File.Delete(path2);
			}
			catch
			{
			}
		}
		catch (Exception)
		{
		}
	}

	private void SaveImage(string string_4, Image image_0, int int_3)
	{
		try
		{
			if (int_3 < 0 || int_3 > 100)
			{
				string paramName = "quality must be between 0 and 100.";
				throw new ArgumentOutOfRangeException(paramName);
			}
			EncoderParameter encoderParameter = new EncoderParameter(Encoder.Quality, int_3);
			string string_5 = "image/jpeg";
			ImageCodecInfo encoder = method_9(string_5);
			EncoderParameters encoderParameters = new EncoderParameters(1);
			encoderParameters.Param[0] = encoderParameter;
			image_0.Save(string_4, encoder, encoderParameters);
		}
		catch
		{
		}
	}

	private ImageCodecInfo method_9(string string_4)
	{
		ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
		for (int i = 0; i < imageEncoders.Length; i++)
		{
			if (imageEncoders[i].MimeType == string_4)
			{
				return imageEncoders[i];
			}
		}
		return null;
	}

	private void method_10(int int_3, string string_4)
	{
		if (!base.InvokeRequired)
		{
			string text = string_4;
			string value = "|";
			if (text.Contains(value))
			{
				string text2 = string_4.Split('|')[0];
				_ = string_4.Split('|')[1];
				string_4 = text2;
			}
			_ = pnl.Controls[string_4];
		}
		else
		{
			Invoke(new frmMain.Delegate12(method_10), int_3, string_4);
		}
	}

	private static string GetBankName(string str)
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
					if (!text10.Contains(value7))
					{
						return result;
					}
					string text11 = text2;
					string text12 = "__";
					string text13 = text;
					string text14 = text;
					string value8 = "_";
					text2 = text11 + text12 + text13.Substring(0, text14.IndexOf(value8)).Trim();
					result = text2;
					return result;
				}
				string text15 = text;
				string value9 = "_";
				if (text15.Contains(value9))
				{
					string text16 = text2;
					string text17 = "_";
					string text18 = text;
					string text19 = text;
					string value10 = "_";
					text2 = text16 + text17 + text18.Substring(0, text19.IndexOf(value10)).Trim();
					result = text2;
					return result;
				}
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

	private void method_11(string string_4)
	{
		bool flag = false;
		_ = DateTime.Now;
		int num = DateTime.Now.Hour * 10000;
		int num2 = DateTime.Now.Minute * 100;
		int num3 = num + num2;
		int second = DateTime.Now.Second;
		long num4 = num3 + second;
		if ((75000 <= num4 && num4 <= 82000) || (95000 <= num4 && num4 <= 100500) || (105000 <= num4 && num4 <= 111000))
		{
			flag = true;
		}
		if (flag)
		{
			Class28.ErFound = flag;
		}
		else
		{
			ThreadPool.QueueUserWorkItem(Staticm.method_11, string_4);
		}
	}

	private void frmProcessTicket_FormClosing(object sender, FormClosingEventArgs e)
	{
		string text = formName.Text;
		string value = "PairID";
		if ((!text.Contains(value) & !close_) && Class28.dictionary_9[formName.Text] > 0)
		{
			Form owner = Program.TopMost_();
			string text2 = "You Cant Close Main Window\r\nFirst Close All Pair";
			string caption = "Hitman";
			MessageBox.Show(owner, text2, caption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			e.Cancel = true;
		}
		else
		{
			while (pnl.Controls.Count > 0)
			{
				Method_3(pnl.Controls[0], new EventArgs());
			}
		}
	}

	private void frmProcessTicket_SizeChanged(object sender, EventArgs e)
	{
		if (base.WindowState == FormWindowState.Maximized)
		{
			base.WindowState = FormWindowState.Normal;
		}
	}

	internal static void smethod_0(object sender, EventArgs e)
	{
		try
		{
			frmProcessTicket frmProcessTicket2 = (frmProcessTicket)sender;
			if (frmProcessTicket2.Tag != null)
			{
				int key = (int)frmProcessTicket2.Tag;
				if (Class28.dictionary_0[key] <= 0)
				{
					Interlocked.Decrement(ref Class28.int_4);
					Class28.dictionary_0.Remove(key);
				}
			}
		}
		catch
		{
		}
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		try
		{
			string text = formName.Text;
			string value = "PairID";
			if (!text.Contains(value) && Class28.dictionary_9[formName.Text] > 0)
			{
				Form owner = Program.TopMost_();
				string text2 = "You Cant Close Main Window\r\nFirst Close All Pair";
				string caption = "Hitman";
				MessageBox.Show(owner, text2, caption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				Thread thread = new Thread(close);
				thread.IsBackground = true;
				thread.Start(0);
			}
		}
		catch (Exception)
		{
		}
	}

	private void close(object j)
	{
		Close();
	}

	private void PanelHelder_MouseDown(object sender, MouseEventArgs e)
	{
		Control control = ((Panel)sender).Parent;
		if (e.Button == MouseButtons.Left)
		{
			drag = true;
			posX = Cursor.Position.X - control.Left;
			posY = Cursor.Position.Y - control.Top;
		}
	}

	private void PanelHelder_MouseMove(object sender, MouseEventArgs e)
	{
		Control control = ((Panel)sender).Parent;
		if (drag)
		{
			control.Top = Cursor.Position.Y - posY;
			control.Left = Cursor.Position.X - posX;
		}
		control.Cursor = Cursors.Default;
	}

	private void PanelHelder_MouseUp(object sender, MouseEventArgs e)
	{
		drag = false;
	}

	private void FormName_MouseDown(object sender, MouseEventArgs e)
	{
		Control control = ((Label)sender).Parent.Parent;
		if (e.Button == MouseButtons.Left)
		{
			drag = true;
			posX = Cursor.Position.X - control.Left;
			posY = Cursor.Position.Y - control.Top;
		}
	}

	private void FormName_MouseMove(object sender, MouseEventArgs e)
	{
		Control control = ((Label)sender).Parent.Parent;
		if (drag)
		{
			control.Top = Cursor.Position.Y - posY;
			control.Left = Cursor.Position.X - posX;
		}
		control.Cursor = Cursors.Default;
	}

	private void FormName_MouseUp(object sender, MouseEventArgs e)
	{
		drag = false;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(APP_FRAMEWORK.frmProcessTicket));
		this.pnl = new System.Windows.Forms.Panel();
		this.bunifuElipse_0 = new Bunifu.Framework.UI.BunifuElipse(this.components);
		this.PanelHelder = new System.Windows.Forms.Panel();
		this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
		this.formName = new System.Windows.Forms.Label();
		this.panel1 = new System.Windows.Forms.Panel();
		this.panel2 = new System.Windows.Forms.Panel();
		this.PanelHelder.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.btnClose).BeginInit();
		base.SuspendLayout();
		this.pnl.BackColor = System.Drawing.Color.Transparent;
		this.pnl.ForeColor = System.Drawing.Color.White;
		this.pnl.Location = new System.Drawing.Point(2, 14);
		this.pnl.Margin = new System.Windows.Forms.Padding(0);
		this.pnl.Name = "pnl";
		this.pnl.Size = new System.Drawing.Size(139, 31);
		this.pnl.TabIndex = 0;
		this.bunifuElipse_0.ElipseRadius = 5;
		this.bunifuElipse_0.TargetControl = this;
		this.PanelHelder.BackColor = System.Drawing.Color.MediumSlateBlue;
		this.PanelHelder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.PanelHelder.Controls.Add(this.btnClose);
		this.PanelHelder.Controls.Add(this.formName);
		this.PanelHelder.Dock = System.Windows.Forms.DockStyle.Top;
		this.PanelHelder.ForeColor = System.Drawing.Color.Yellow;
		this.PanelHelder.Location = new System.Drawing.Point(0, 0);
		this.PanelHelder.Margin = new System.Windows.Forms.Padding(2);
		this.PanelHelder.Name = "PanelHelder";
		this.PanelHelder.Size = new System.Drawing.Size(281, 15);
		this.PanelHelder.TabIndex = 128;
		this.PanelHelder.MouseDown += new System.Windows.Forms.MouseEventHandler(PanelHelder_MouseDown);
		this.PanelHelder.MouseMove += new System.Windows.Forms.MouseEventHandler(PanelHelder_MouseMove);
		this.PanelHelder.MouseUp += new System.Windows.Forms.MouseEventHandler(PanelHelder_MouseUp);
		this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.btnClose.BackColor = System.Drawing.Color.Transparent;
		this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
		this.btnClose.Image = (System.Drawing.Image)resources.GetObject("btnClose.Image");
		this.btnClose.ImageActive = null;
		this.btnClose.Location = new System.Drawing.Point(259, -2);
		this.btnClose.Margin = new System.Windows.Forms.Padding(2);
		this.btnClose.Name = "btnClose";
		this.btnClose.Size = new System.Drawing.Size(18, 19);
		this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.btnClose.TabIndex = 24;
		this.btnClose.TabStop = false;
		this.btnClose.Zoom = 10;
		this.btnClose.Click += new System.EventHandler(btnClose_Click_1);
		this.formName.AutoSize = true;
		this.formName.BackColor = System.Drawing.Color.Transparent;
		this.formName.Dock = System.Windows.Forms.DockStyle.Left;
		this.formName.ForeColor = System.Drawing.Color.Black;
		this.formName.Location = new System.Drawing.Point(0, 0);
		this.formName.Name = "formName";
		this.formName.Size = new System.Drawing.Size(56, 13);
		this.formName.TabIndex = 23;
		this.formName.Text = "Tikt Name";
		this.formName.MouseDown += new System.Windows.Forms.MouseEventHandler(FormName_MouseDown);
		this.formName.MouseMove += new System.Windows.Forms.MouseEventHandler(FormName_MouseMove);
		this.formName.MouseUp += new System.Windows.Forms.MouseEventHandler(FormName_MouseUp);
		this.panel1.BackColor = System.Drawing.Color.Transparent;
		this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
		this.panel1.Location = new System.Drawing.Point(278, 15);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(3, 169);
		this.panel1.TabIndex = 129;
		this.panel2.BackColor = System.Drawing.Color.Transparent;
		this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.panel2.Location = new System.Drawing.Point(0, 181);
		this.panel2.Name = "panel2";
		this.panel2.Size = new System.Drawing.Size(278, 3);
		this.panel2.TabIndex = 130;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.Silver;
		this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		base.ClientSize = new System.Drawing.Size(281, 184);
		base.Controls.Add(this.panel2);
		base.Controls.Add(this.panel1);
		base.Controls.Add(this.PanelHelder);
		base.Controls.Add(this.pnl);
		this.DoubleBuffered = true;
		this.ForeColor = System.Drawing.SystemColors.AppWorkspace;
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "frmProcessTicket";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "frmProcessTicket";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(frmProcessTicket_FormClosing);
		base.SizeChanged += new System.EventHandler(frmProcessTicket_SizeChanged);
		this.PanelHelder.ResumeLayout(false);
		this.PanelHelder.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.btnClose).EndInit();
		base.ResumeLayout(false);
	}

	private void btnClose_Click_1(object sender, EventArgs e)
	{
		Close();
	}
}
