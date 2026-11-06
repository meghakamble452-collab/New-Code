using System;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace APP_FRAMEWORK;

internal class tabNetBanking : UserControl
{
	private string string_0;

	private IDisposable idisposable_0;

	private Panel panel9;

	private ListBox lstNB;

	private Panel panel1;

	private Button btn_deleteALL;

	internal Button btnNBEdit;

	internal Button btnNBSave;

	private Button btn_Delete;

	private Label lblOTP;

	private TextBox txtOTP;

	private TextBox txtTxnPassword;

	private TextBox txtLoginPassword;

	private TextBox txtUserName;

	private Label lblTxnPassword;

	private Label lblLoginPassword;

	private Label lblUserName;

	private ComboBox comboBox_0;

	private Label lblBankName;

	private Label B1AAA;

	private TextBox txt_SaveAS;

	private ToolTip toolTip_0;

	private IContainer icontainer_0;

	private ComboBox cboGateway0;

	private Label label11;

	private CheckBox checkBox1;

	private Label label1;

	private LinkLabel linkLabel1;

	private LinkLabel linkLabel2;

	private IContainer components;

	private CheckBox cheotp;

	public tabNetBanking()
	{
		InitializeComponent();
	}

	private void tabNetBanking_Load(object sender, EventArgs e)
	{
		string_0 = "";
		method_0();
	}

	private void method_0()
	{
		txtUserName.Text = "";
		txtTxnPassword.Text = "";
		txtLoginPassword.Text = "";
		txtOTP.Text = "";
		txt_SaveAS.Text = "";
		cboGateway0.SelectedIndex = 0;
		method_1();
	}

	private void method_1()
	{
		comboBox_0.Items.Clear();
		ComboBox.ObjectCollection items = comboBox_0.Items;
		string item = "Select Net Banking";
		items.Add(item);
		foreach (string key in Program.dictionary_2.Keys)
		{
			if (cboGateway0.SelectedIndex != 0)
			{
				if (cboGateway0.SelectedIndex == 1)
				{
					string text = "SBI";
					if (key == text)
					{
						comboBox_0.Items.Add(key);
					}
				}
			}
			else
			{
				comboBox_0.Items.Add(key);
			}
		}
		comboBox_0.SelectedIndex = 0;
		method_2();
	}

	private void method_2()
	{
		try
		{
			lstNB.Items.Clear();
			DataTable dataTable = new DataTable();
			string commandText = "SELECT BANK_SAVEAS from TBL_BANK WHERE BANK_ISDEBIT = 0";
			new SQLiteDataAdapter(commandText, Class34.string_Database).Fill(dataTable);
			if (dataTable == null || dataTable.Rows.Count <= 0)
			{
				return;
			}
			foreach (DataRow row in dataTable.Rows)
			{
				lstNB.Items.Add(row[0].ToString());
			}
		}
		catch (Exception)
		{
		}
	}

	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		string text = comboBox_0.SelectedItem.ToString();
		if (!Program.dictionary_2.TryGetValue(text, out var value))
		{
			return;
		}
		lblOTP.Visible = false;
		txtOTP.Visible = false;
		string text2 = value;
		string[] array = new string[1];
		string text3 = "|";
		array[0] = text3;
		string[] array2 = text2.Split(array, StringSplitOptions.RemoveEmptyEntries);
		label1.Visible = false;
		linkLabel1.Visible = false;
		linkLabel2.Visible = false;
		string text4 = "SBI";
		if (text == text4)
		{
			label1.Visible = true;
			linkLabel1.Visible = true;
			linkLabel2.Visible = true;
		}
		string text5 = "iPay-QR";
		if (text == text5)
		{
			TextBox textBox = txtUserName;
			string text6 = "ipay@qr";
			textBox.Text = text6;
			TextBox textBox2 = txtLoginPassword;
			string text7 = "123456";
			textBox2.Text = text7;
		}
		string text8 = "PayTM-QR";
		if (text == text8)
		{
			TextBox textBox3 = txtUserName;
			string text9 = "paytm@qr";
			textBox3.Text = text9;
			TextBox textBox4 = txtLoginPassword;
			string text10 = "123456";
			textBox4.Text = text10;
		}
		string text11 = "PHONEPE-QR";
		if (text == text11)
		{
			TextBox textBox5 = txtUserName;
			string text12 = "PHONEPE@QR";
			textBox5.Text = text12;
			TextBox textBox6 = txtLoginPassword;
			string text13 = "123456";
			textBox6.Text = text13;
		}
		string value2 = "MOBIKWIK";
		if (!text.Contains(value2))
		{
			string value3 = "JIOMONEY";
			if (!text.Contains(value3))
			{
				string value4 = "OLAMONEY";
				if (!text.Contains(value4))
				{
					string value5 = "AIRTELMONEY";
					if (!text.Contains(value5))
					{
						cheotp.Visible = false;
						goto IL_0245;
					}
				}
			}
		}
		cheotp.Visible = true;
		CheckBox checkBox = cheotp;
		string text14 = "Auto Read OTP From NGET Mobile OTP Reader";
		checkBox.Text = text14;
		goto IL_0245;
		IL_0245:
		Label label = lblUserName;
		string text15 = array2[0];
		string text16 = " : ";
		label.Text = text15 + text16;
		if (array2.Length > 2)
		{
			Label label2 = lblTxnPassword;
			string text17 = array2[2];
			string text18 = " : ";
			label2.Text = text17 + text18;
			lblTxnPassword.Visible = true;
			txtTxnPassword.Visible = true;
			if (array2.Length > 3)
			{
				Label label3 = lblOTP;
				string text19 = array2[3];
				string text20 = " : ";
				label3.Text = text19 + text20;
				lblOTP.Visible = true;
				txtOTP.Visible = true;
			}
		}
		else
		{
			lblTxnPassword.Visible = false;
			txtTxnPassword.Visible = false;
		}
	}

	private void btnNBSave_Click(object sender, EventArgs e)
	{
		TextBox textBox = txtUserName;
		if (!string.IsNullOrEmpty(textBox.Text) && textBox.Text.Length >= 3)
		{
			TextBox textBox2 = txtLoginPassword;
			if (!string.IsNullOrEmpty(textBox2.Text) && textBox2.Text.Length >= 3)
			{
				TextBox textBox3 = txtTxnPassword;
				if (textBox3.Visible && (string.IsNullOrEmpty(textBox3.Text) || textBox3.Text.Length < 5))
				{
					string text = "Enter Valid ";
					string text2 = lblTxnPassword.Text;
					string text3 = "!";
					string text4 = text + text2 + text3;
					string caption = "Net Banking";
					MessageBox.Show(text4, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					textBox3.Focus();
					return;
				}
				TextBox textBox4 = txtOTP;
				if (!textBox4.Visible || (!string.IsNullOrEmpty(textBox4.Text) && textBox4.Text.Length >= 3))
				{
					if (comboBox_0.SelectedIndex > 0)
					{
						string text5 = txt_SaveAS.Text.Replace('_', 'A').Replace('-', 'A').Replace('@', 'A')
							.Replace('.', 'A');
						if (!string.IsNullOrEmpty(text5) && Class34.smethod_3(text5))
						{
							string value = "_CC";
							if (text5.IndexOf(value, StringComparison.CurrentCultureIgnoreCase) < 0)
							{
								string value2 = "CC_";
								if (text5.IndexOf(value2, StringComparison.CurrentCultureIgnoreCase) < 0)
								{
									string value3 = "_DC";
									if (text5.IndexOf(value3, StringComparison.CurrentCultureIgnoreCase) < 0)
									{
										string value4 = "DC_";
										if (text5.IndexOf(value4, StringComparison.CurrentCultureIgnoreCase) < 0)
										{
											try
											{
												string text6 = txtUserName.Text;
												string text7 = "||";
												string text8 = text6 + text7 + txtLoginPassword.Text;
												if (txtTxnPassword.Visible)
												{
													string text9 = text8;
													string text10 = "||";
													text8 = text9 + text10 + txtTxnPassword.Text;
												}
												if (txtOTP.Visible)
												{
													string text11 = text8;
													string text12 = "||";
													text8 = text11 + text12 + txtOTP.Text;
												}
												SQLiteConnection sQLiteConnection = new SQLiteConnection(Class34.string_Database);
												sQLiteConnection.Open();
												SQLiteCommand sQLiteCommand = new SQLiteCommand(sQLiteConnection);
												string text13 = "SELECT count(RID) from TBL_BANK where BANK_SAVEAS = '";
												string text14 = txt_SaveAS.Text.Trim();
												string text15 = "' AND BANK_ISDEBIT = 0";
												sQLiteCommand.CommandText = text13 + text14 + text15;
												object obj = sQLiteCommand.ExecuteScalar();
												int result = 0;
												if (obj != null && obj.GetType() != typeof(DBNull))
												{
													int.TryParse(obj.ToString().Trim(), out result);
												}
												if (result > 0)
												{
													string text16 = "Bank Details already exists for mentioned User Name. Do you want to Update?\r\n\r\nIf you need to update existing details, Click 'YES', Otherwise you can Click 'NO'";
													string caption2 = "Details Exists";
													if (MessageBox.Show(text16, caption2, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
													{
														sQLiteConnection.Close();
														sQLiteCommand.Dispose();
														return;
													}
													string text17 = "DELETE from TBL_BANK where BANK_SAVEAS = '";
													string text18 = txt_SaveAS.Text.Trim();
													string text19 = "' AND BANK_ISDEBIT = 0";
													sQLiteCommand.CommandText = text17 + text18 + text19;
													Program.dictionary_00.Remove(txt_SaveAS.Text.Trim());
													sQLiteCommand.ExecuteNonQuery();
												}
												if (string_0 != "")
												{
													Program.dictionary_00.Remove(txt_SaveAS.Text.Trim());
												}
												string text20 = comboBox_0.SelectedItem.ToString();
												string value5 = "MOBIKWIK";
												if (!text20.Contains(value5))
												{
													string value6 = "JIOMONEY";
													if (!text20.Contains(value6))
													{
														string value7 = "OLAMONEY";
														if (!text20.Contains(value7))
														{
															string value8 = "AIRTELMONEY";
															if (!text20.Contains(value8))
															{
																goto IL_04bc;
															}
														}
													}
												}
												if (cheotp.Checked)
												{
													string text21 = text8;
													string text22 = "||";
													text8 = text21 + text22 + cheotp.Checked;
												}
												goto IL_04bc;
												IL_04bc:
												Program.dictionary_00.Add(txt_SaveAS.Text.Trim(), text8);
												string[] array = new string[7];
												string text23 = "INSERT INTO TBL_BANK(BANK_NAME, BANK_SAVEAS, BANK_DETAILS, BANK_ISDEBIT) VALUES ('";
												array[0] = text23;
												array[1] = comboBox_0.SelectedItem.ToString();
												string text24 = "', '";
												array[2] = text24;
												array[3] = txt_SaveAS.Text.Trim();
												string text25 = "', '";
												array[4] = text25;
												array[5] = text8;
												string text26 = "', 0)";
												array[6] = text26;
												sQLiteCommand.CommandText = string.Concat(array);
												sQLiteCommand.ExecuteNonQuery();
												sQLiteConnection.Close();
												sQLiteCommand.Dispose();
												method_1();
												string text27 = "Net-Banking Details Updated Successfully!";
												string caption3 = "Bank Details";
												MessageBox.Show(text27, caption3, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
												return;
											}
											catch
											{
												string text28 = "Error Occured while Saving Bank Details";
												MessageBox.Show(text28);
												return;
											}
										}
									}
								}
							}
							string text29 = "_CC or _Debit words are not allowed in name.";
							string caption4 = "NetBanking Name";
							MessageBox.Show(text29, caption4, MessageBoxButtons.OK, MessageBoxIcon.Hand);
							txt_SaveAS.Focus();
						}
						else
						{
							string text30 = "Please enter valid Bank Name to Save! (Only Alphabets, Numbers and (_) (-) are allowed)";
							string caption5 = "NetBanking Name";
							MessageBox.Show(text30, caption5, MessageBoxButtons.OK, MessageBoxIcon.Hand);
							txt_SaveAS.Focus();
						}
					}
					else
					{
						string text31 = "Select Valid Bank Name";
						string caption6 = "Net Banking";
						MessageBox.Show(text31, caption6, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						comboBox_0.Focus();
					}
				}
				else
				{
					string text32 = "Enter Valid ";
					string text33 = lblOTP.Text;
					string text34 = "!";
					string text35 = text32 + text33 + text34;
					string caption7 = "Net Banking";
					MessageBox.Show(text35, caption7, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					textBox4.Focus();
				}
			}
			else
			{
				string text36 = "Enter Valid Password!";
				string caption8 = "Net Banking";
				MessageBox.Show(text36, caption8, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				textBox2.Focus();
			}
		}
		else
		{
			string text37 = "Enter Valid User Name!";
			string caption9 = "Net Banking";
			MessageBox.Show(text37, caption9, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			textBox.Focus();
		}
	}

	private void txtUserName_TextChanged(object sender, EventArgs e)
	{
		if (comboBox_0.SelectedIndex <= 0)
		{
			txtUserName.Text = "";
			comboBox_0.Focus();
			return;
		}
		TextBox textBox = txt_SaveAS;
		string text = comboBox_0.SelectedItem.ToString();
		string text2 = "_";
		string text3 = txtUserName.Text;
		string oldValue = "_";
		string newValue = "-";
		textBox.Text = text + text2 + text3.Replace(oldValue, newValue).Trim();
	}

	private void btnNBEdit_Click(object sender, EventArgs e)
	{
		if (lstNB.SelectedIndex < 0)
		{
			string text = "Please select Net Banking to Edit";
			string caption = "Edit Net-Banking";
			MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			return;
		}
		DataTable dataTable = new DataTable();
		string text2 = "SELECT BANK_NAME, BANK_DETAILS from TBL_BANK WHERE BANK_ISDEBIT = 0 AND BANK_SAVEAS = '";
		string text3 = lstNB.SelectedItem.ToString();
		string text4 = "'";
		new SQLiteDataAdapter(text2 + text3 + text4, Class34.string_Database).Fill(dataTable);
		try
		{
			if (dataTable.Rows != null && dataTable.Rows.Count > 0)
			{
				string text5 = lstNB.SelectedItem.ToString();
				string value = "_";
				string selectedItem = text5.Substring(0, text5.IndexOf(value));
				cboGateway0.SelectedIndex = 0;
				comboBox_0.SelectedItem = selectedItem;
				string text6 = dataTable.Rows[0][1].ToString();
				string[] array = new string[1];
				string text7 = "||";
				array[0] = text7;
				string[] array2 = text6.Split(array, StringSplitOptions.RemoveEmptyEntries);
				txtUserName.Text = array2[0];
				txtLoginPassword.Text = array2[1];
				if (array2.Length > 2)
				{
					txtTxnPassword.Text = array2[2];
				}
				int num = 2;
				TextBox textBox = txt_SaveAS;
				string value2 = "_";
				textBox.Text = text5.Substring(text5.IndexOf(value2) + 1);
				txt_SaveAS.Text = text5;
				if (txtTxnPassword.Visible)
				{
					num++;
					txtTxnPassword.Text = array2[num];
				}
				if (txtOTP.Visible)
				{
					num++;
					txtOTP.Text = array2[num];
				}
				if (array2.Length > num)
				{
					string text8 = array2[num];
					string text9 = "||";
					string_0 = text6.Substring(text6.IndexOf(text8 + text9));
					string text10 = string_0;
					string text11 = string_0;
					string value3 = "||";
					string_0 = text10.Substring(text11.IndexOf(value3));
				}
			}
		}
		catch
		{
		}
	}

	private void btn_Delete_Click(object sender, EventArgs e)
	{
		if (lstNB.SelectedIndex < 0)
		{
			string text = "Please select Net-Banking to Delete";
			string caption = "Delete Credit";
			MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			return;
		}
		string text2 = lstNB.SelectedItem.ToString();
		string text3 = "Do you really want to delete ";
		string text4 = text3 + text2;
		string caption2 = "Delete";
		if (MessageBox.Show(text4, caption2, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
		{
			SQLiteConnection sQLiteConnection = new SQLiteConnection(Class34.string_Database);
			sQLiteConnection.Open();
			SQLiteCommand sQLiteCommand = new SQLiteCommand(sQLiteConnection);
			string text5 = "DELETE from TBL_BANK where BANK_SAVEAS = '";
			string text6 = "' AND BANK_ISDEBIT = 0";
			sQLiteCommand.CommandText = text5 + text2 + text6;
			sQLiteCommand.ExecuteNonQuery();
			sQLiteConnection.Close();
			sQLiteCommand.Dispose();
			method_0();
			Program.dictionary_00.Remove(text2);
			string value = "@axisbank";
			if (text2.Contains(value))
			{
				string text7 = "91";
				string[] array = new string[1];
				string text8 = "_";
				array[0] = text8;
				string text9 = text2.Split(array, StringSplitOptions.None)[1];
				string[] array2 = new string[1];
				string text10 = "@";
				array2[0] = text10;
				StartSQLforDatabase(text7 + text9.Split(array2, StringSplitOptions.None)[0]);
			}
			string text11 = "Net-Banking Details for ";
			string text12 = " Deleted Successfully!";
			string text13 = text11 + text2 + text12;
			string caption3 = "Deleted";
			MessageBox.Show(text13, caption3, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
	}

	public static bool StartSQLforDatabase(string d)
	{
		bool result = false;
		try
		{
			DataTable dataTable = new DataTable();
			string commandText = "SELECT * FROM [TBL_UPI]";
			new SQLiteDataAdapter(commandText, Class34.string_Database).Fill(dataTable);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				foreach (DataRow row in dataTable.Rows)
				{
					string columnName = "RID";
					string text = row[columnName].ToString();
					string columnName2 = "MobNo";
					string text2 = row[columnName2].ToString();
					if (d == text2)
					{
						string text3 = "DELETE from TBL_UPI where RID = '";
						string text4 = "'";
						BAAAA(text3 + text + text4);
						result = true;
					}
				}
			}
		}
		catch (Exception)
		{
		}
		return result;
	}

	private static void BAAAA(string string_1)
	{
		try
		{
			SQLiteConnection sQLiteConnection = new SQLiteConnection(Class34.string_Database);
			sQLiteConnection.Open();
			SQLiteCommand sQLiteCommand = new SQLiteCommand(sQLiteConnection);
			sQLiteCommand.CommandText = string_1;
			sQLiteCommand.ExecuteNonQuery();
			sQLiteConnection.Close();
			sQLiteCommand.Dispose();
		}
		catch
		{
		}
	}

	private void btn_deleteALL_Click(object sender, EventArgs e)
	{
		string text = "Do you really want to delete All Net-Bankings present in the List";
		string caption = "Delete All";
		if (MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
		{
			return;
		}
		SQLiteConnection sQLiteConnection = new SQLiteConnection(Class34.string_Database);
		sQLiteConnection.Open();
		SQLiteCommand sQLiteCommand = new SQLiteCommand(sQLiteConnection);
		foreach (object item in lstNB.Items)
		{
			string text2 = item.ToString();
			string text3 = "DELETE from TBL_BANK where BANK_SAVEAS = '";
			string text4 = "' AND BANK_ISDEBIT = 0";
			sQLiteCommand.CommandText = text3 + text2 + text4;
			sQLiteCommand.ExecuteNonQuery();
		}
		sQLiteConnection.Close();
		sQLiteCommand.Dispose();
		lstNB.Items.Clear();
		string text5 = "All Net-Bankings Details Deleted Successfully!";
		string caption2 = "Deleted";
		MessageBox.Show(text5, caption2, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
	}

	private void cboGateway0_SelectedIndexChanged(object sender, EventArgs e)
	{
		method_1();
	}

	private void checkBox1_CheckedChanged(object sender, EventArgs e)
	{
		if (checkBox1.Checked)
		{
			txtLoginPassword.PasswordChar = '\0';
			txtTxnPassword.PasswordChar = '\0';
		}
		else
		{
			txtLoginPassword.PasswordChar = '*';
			txtTxnPassword.PasswordChar = '*';
		}
	}

	private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		string fileName = "https://om.olacabs.com/om-app/home";
		Process.Start(fileName);
	}

	private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		string fileName = "https://accounts.olacabs.com/kyc?cnl=email";
		Process.Start(fileName);
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
		this.panel9 = new System.Windows.Forms.Panel();
		this.lstNB = new System.Windows.Forms.ListBox();
		this.btn_Delete = new System.Windows.Forms.Button();
		this.btnNBEdit = new System.Windows.Forms.Button();
		this.btn_deleteALL = new System.Windows.Forms.Button();
		this.panel1 = new System.Windows.Forms.Panel();
		this.cheotp = new System.Windows.Forms.CheckBox();
		this.linkLabel1 = new System.Windows.Forms.LinkLabel();
		this.linkLabel2 = new System.Windows.Forms.LinkLabel();
		this.label1 = new System.Windows.Forms.Label();
		this.checkBox1 = new System.Windows.Forms.CheckBox();
		this.cboGateway0 = new System.Windows.Forms.ComboBox();
		this.label11 = new System.Windows.Forms.Label();
		this.B1AAA = new System.Windows.Forms.Label();
		this.txt_SaveAS = new System.Windows.Forms.TextBox();
		this.lblOTP = new System.Windows.Forms.Label();
		this.txtOTP = new System.Windows.Forms.TextBox();
		this.txtTxnPassword = new System.Windows.Forms.TextBox();
		this.txtLoginPassword = new System.Windows.Forms.TextBox();
		this.txtUserName = new System.Windows.Forms.TextBox();
		this.lblTxnPassword = new System.Windows.Forms.Label();
		this.lblLoginPassword = new System.Windows.Forms.Label();
		this.lblUserName = new System.Windows.Forms.Label();
		this.comboBox_0 = new System.Windows.Forms.ComboBox();
		this.lblBankName = new System.Windows.Forms.Label();
		this.btnNBSave = new System.Windows.Forms.Button();
		this.toolTip_0 = new System.Windows.Forms.ToolTip(this.components);
		this.panel9.SuspendLayout();
		this.panel1.SuspendLayout();
		base.SuspendLayout();
		this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.panel9.Controls.Add(this.lstNB);
		this.panel9.Controls.Add(this.btn_Delete);
		this.panel9.Controls.Add(this.btnNBEdit);
		this.panel9.Controls.Add(this.btn_deleteALL);
		this.panel9.Location = new System.Drawing.Point(581, 3);
		this.panel9.Margin = new System.Windows.Forms.Padding(5);
		this.panel9.Name = "panel9";
		this.panel9.Size = new System.Drawing.Size(595, 490);
		this.panel9.TabIndex = 3;
		this.lstNB.BackColor = System.Drawing.Color.White;
		this.lstNB.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.lstNB.Dock = System.Windows.Forms.DockStyle.Top;
		this.lstNB.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lstNB.FormattingEnabled = true;
		this.lstNB.ItemHeight = 21;
		this.lstNB.Location = new System.Drawing.Point(0, 0);
		this.lstNB.Margin = new System.Windows.Forms.Padding(5);
		this.lstNB.Name = "lstNB";
		this.lstNB.Size = new System.Drawing.Size(593, 399);
		this.lstNB.TabIndex = 0;
		this.btn_Delete.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btn_Delete.BackColor = System.Drawing.Color.FloralWhite;
		this.btn_Delete.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.btn_Delete.ForeColor = System.Drawing.Color.FromArgb(64, 62, 101);
		this.btn_Delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btn_Delete.Location = new System.Drawing.Point(223, 443);
		this.btn_Delete.Margin = new System.Windows.Forms.Padding(5);
		this.btn_Delete.Name = "btn_Delete";
		this.btn_Delete.Size = new System.Drawing.Size(191, 38);
		this.btn_Delete.TabIndex = 17;
		this.btn_Delete.Text = "&Delete";
		this.btn_Delete.UseVisualStyleBackColor = false;
		this.btn_Delete.Click += new System.EventHandler(btn_Delete_Click);
		this.btnNBEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnNBEdit.BackColor = System.Drawing.Color.FloralWhite;
		this.btnNBEdit.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.btnNBEdit.ForeColor = System.Drawing.Color.FromArgb(64, 62, 101);
		this.btnNBEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnNBEdit.Location = new System.Drawing.Point(10, 443);
		this.btnNBEdit.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
		this.btnNBEdit.Name = "btnNBEdit";
		this.btnNBEdit.Size = new System.Drawing.Size(204, 38);
		this.btnNBEdit.TabIndex = 16;
		this.btnNBEdit.Text = "&Edit";
		this.btnNBEdit.UseVisualStyleBackColor = false;
		this.btnNBEdit.Click += new System.EventHandler(btnNBEdit_Click);
		this.btn_deleteALL.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btn_deleteALL.BackColor = System.Drawing.Color.FloralWhite;
		this.btn_deleteALL.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.btn_deleteALL.ForeColor = System.Drawing.Color.FromArgb(64, 62, 101);
		this.btn_deleteALL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btn_deleteALL.Location = new System.Drawing.Point(423, 441);
		this.btn_deleteALL.Margin = new System.Windows.Forms.Padding(5);
		this.btn_deleteALL.Name = "btn_deleteALL";
		this.btn_deleteALL.Size = new System.Drawing.Size(162, 38);
		this.btn_deleteALL.TabIndex = 18;
		this.btn_deleteALL.Text = "&Delete All";
		this.btn_deleteALL.UseVisualStyleBackColor = false;
		this.btn_deleteALL.Click += new System.EventHandler(btn_deleteALL_Click);
		this.panel1.BackColor = System.Drawing.Color.White;
		this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.panel1.Controls.Add(this.cheotp);
		this.panel1.Controls.Add(this.linkLabel1);
		this.panel1.Controls.Add(this.linkLabel2);
		this.panel1.Controls.Add(this.label1);
		this.panel1.Controls.Add(this.checkBox1);
		this.panel1.Controls.Add(this.cboGateway0);
		this.panel1.Controls.Add(this.label11);
		this.panel1.Controls.Add(this.B1AAA);
		this.panel1.Controls.Add(this.txt_SaveAS);
		this.panel1.Controls.Add(this.lblOTP);
		this.panel1.Controls.Add(this.txtOTP);
		this.panel1.Controls.Add(this.txtTxnPassword);
		this.panel1.Controls.Add(this.txtLoginPassword);
		this.panel1.Controls.Add(this.txtUserName);
		this.panel1.Controls.Add(this.lblTxnPassword);
		this.panel1.Controls.Add(this.lblLoginPassword);
		this.panel1.Controls.Add(this.lblUserName);
		this.panel1.Controls.Add(this.comboBox_0);
		this.panel1.Controls.Add(this.lblBankName);
		this.panel1.Controls.Add(this.btnNBSave);
		this.panel1.Location = new System.Drawing.Point(3, 3);
		this.panel1.Margin = new System.Windows.Forms.Padding(5);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(577, 490);
		this.panel1.TabIndex = 2;
		this.cheotp.AutoSize = true;
		this.cheotp.Font = new System.Drawing.Font("Arial", 10.2f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.cheotp.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
		this.cheotp.Location = new System.Drawing.Point(14, 390);
		this.cheotp.Margin = new System.Windows.Forms.Padding(5);
		this.cheotp.Name = "cheotp";
		this.cheotp.Size = new System.Drawing.Size(194, 29);
		this.cheotp.TabIndex = 1210;
		this.cheotp.Text = "Show Password";
		this.cheotp.UseVisualStyleBackColor = true;
		this.linkLabel1.ActiveLinkColor = System.Drawing.Color.Aqua;
		this.linkLabel1.AutoSize = true;
		this.linkLabel1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
		this.linkLabel1.ForeColor = System.Drawing.Color.Cornsilk;
		this.linkLabel1.LinkColor = System.Drawing.Color.Blue;
		this.linkLabel1.Location = new System.Drawing.Point(10, 458);
		this.linkLabel1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
		this.linkLabel1.Name = "linkLabel1";
		this.linkLabel1.Size = new System.Drawing.Size(144, 21);
		this.linkLabel1.TabIndex = 1208;
		this.linkLabel1.TabStop = true;
		this.linkLabel1.Text = "KYC Olamoney";
		this.linkLabel1.Visible = false;
		this.linkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.linkLabel2.ActiveLinkColor = System.Drawing.Color.Aqua;
		this.linkLabel2.AutoSize = true;
		this.linkLabel2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
		this.linkLabel2.ForeColor = System.Drawing.Color.Cornsilk;
		this.linkLabel2.LinkColor = System.Drawing.Color.Blue;
		this.linkLabel2.Location = new System.Drawing.Point(10, 425);
		this.linkLabel2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
		this.linkLabel2.Name = "linkLabel2";
		this.linkLabel2.Size = new System.Drawing.Size(163, 21);
		this.linkLabel2.TabIndex = 1208;
		this.linkLabel2.TabStop = true;
		this.linkLabel2.Text = "Create Olamoney";
		this.linkLabel2.Visible = false;
		this.linkLabel2.VisitedLinkColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.label1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.Location = new System.Drawing.Point(390, 320);
		this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(168, 30);
		this.label1.TabIndex = 1209;
		this.label1.Text = "\r\n\r\nNote:- Every User Ko Olamoney Me Account Jarurar Create Karna \\n h, Aur KYC karna  Jarurar H";
		this.label1.Visible = false;
		this.checkBox1.AutoSize = true;
		this.checkBox1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.checkBox1.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.checkBox1.Location = new System.Drawing.Point(14, 354);
		this.checkBox1.Margin = new System.Windows.Forms.Padding(5);
		this.checkBox1.Name = "checkBox1";
		this.checkBox1.Size = new System.Drawing.Size(176, 25);
		this.checkBox1.TabIndex = 39;
		this.checkBox1.Text = "Show Password";
		this.checkBox1.UseVisualStyleBackColor = true;
		this.cboGateway0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboGateway0.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboGateway0.FormattingEnabled = true;
		System.Windows.Forms.ComboBox.ObjectCollection items = this.cboGateway0.Items;
		items.AddRange(new object[1] { "IRCTC" });
		this.cboGateway0.Location = new System.Drawing.Point(187, 18);
		this.cboGateway0.Margin = new System.Windows.Forms.Padding(5);
		this.cboGateway0.Name = "cboGateway0";
		this.cboGateway0.Size = new System.Drawing.Size(195, 30);
		this.cboGateway0.TabIndex = 25;
		this.label11.AutoSize = true;
		this.label11.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.label11.Location = new System.Drawing.Point(12, 21);
		this.label11.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
		this.label11.Name = "label11";
		this.label11.Size = new System.Drawing.Size(108, 26);
		this.label11.TabIndex = 24;
		this.label11.Text = "Gateway : ";
		this.B1AAA.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.B1AAA.AutoSize = true;
		this.B1AAA.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.B1AAA.ForeColor = System.Drawing.Color.Maroon;
		this.B1AAA.Location = new System.Drawing.Point(12, 281);
		this.B1AAA.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
		this.B1AAA.Name = "B1AAA";
		this.B1AAA.Size = new System.Drawing.Size(152, 26);
		this.B1AAA.TabIndex = 11;
		this.B1AAA.Text = "Name to Save : ";
		this.txt_SaveAS.BackColor = System.Drawing.SystemColors.Control;
		this.txt_SaveAS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txt_SaveAS.Enabled = false;
		this.txt_SaveAS.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txt_SaveAS.Location = new System.Drawing.Point(187, 276);
		this.txt_SaveAS.Margin = new System.Windows.Forms.Padding(5);
		this.txt_SaveAS.MaxLength = 15;
		this.txt_SaveAS.Name = "txt_SaveAS";
		this.txt_SaveAS.Size = new System.Drawing.Size(372, 28);
		this.txt_SaveAS.TabIndex = 12;
		this.lblOTP.AutoSize = true;
		this.lblOTP.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.lblOTP.Location = new System.Drawing.Point(12, 232);
		this.lblOTP.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
		this.lblOTP.Name = "lblOTP";
		this.lblOTP.Size = new System.Drawing.Size(65, 26);
		this.lblOTP.TabIndex = 9;
		this.lblOTP.Text = "OTP : ";
		this.lblOTP.Visible = false;
		this.txtOTP.BackColor = System.Drawing.Color.FromArgb(235, 248, 239);
		this.txtOTP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtOTP.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtOTP.Location = new System.Drawing.Point(187, 234);
		this.txtOTP.Margin = new System.Windows.Forms.Padding(5);
		this.txtOTP.MaxLength = 30;
		this.txtOTP.Name = "txtOTP";
		this.txtOTP.Size = new System.Drawing.Size(123, 28);
		this.txtOTP.TabIndex = 10;
		this.txtOTP.Visible = false;
		this.txtTxnPassword.BackColor = System.Drawing.Color.FromArgb(235, 248, 239);
		this.txtTxnPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtTxnPassword.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtTxnPassword.Location = new System.Drawing.Point(187, 192);
		this.txtTxnPassword.Margin = new System.Windows.Forms.Padding(5);
		this.txtTxnPassword.MaxLength = 30;
		this.txtTxnPassword.Name = "txtTxnPassword";
		this.txtTxnPassword.Size = new System.Drawing.Size(372, 28);
		this.txtTxnPassword.TabIndex = 8;
		this.txtTxnPassword.Visible = false;
		this.txtLoginPassword.BackColor = System.Drawing.Color.FromArgb(235, 248, 239);
		this.txtLoginPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtLoginPassword.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtLoginPassword.Location = new System.Drawing.Point(187, 153);
		this.txtLoginPassword.Margin = new System.Windows.Forms.Padding(5);
		this.txtLoginPassword.MaxLength = 30;
		this.txtLoginPassword.Name = "txtLoginPassword";
		this.txtLoginPassword.Size = new System.Drawing.Size(372, 28);
		this.txtLoginPassword.TabIndex = 6;
		this.txtUserName.BackColor = System.Drawing.Color.FromArgb(235, 248, 239);
		this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtUserName.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtUserName.Location = new System.Drawing.Point(187, 110);
		this.txtUserName.Margin = new System.Windows.Forms.Padding(5);
		this.txtUserName.MaxLength = 30;
		this.txtUserName.Name = "txtUserName";
		this.txtUserName.Size = new System.Drawing.Size(372, 28);
		this.txtUserName.TabIndex = 4;
		this.txtUserName.TextChanged += new System.EventHandler(txtUserName_TextChanged);
		this.lblTxnPassword.AutoSize = true;
		this.lblTxnPassword.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.lblTxnPassword.Location = new System.Drawing.Point(12, 191);
		this.lblTxnPassword.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
		this.lblTxnPassword.Name = "lblTxnPassword";
		this.lblTxnPassword.Size = new System.Drawing.Size(153, 26);
		this.lblTxnPassword.TabIndex = 7;
		this.lblTxnPassword.Text = "Txn Password : ";
		this.lblTxnPassword.Visible = false;
		this.lblLoginPassword.AutoSize = true;
		this.lblLoginPassword.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.lblLoginPassword.Location = new System.Drawing.Point(12, 151);
		this.lblLoginPassword.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
		this.lblLoginPassword.Name = "lblLoginPassword";
		this.lblLoginPassword.Size = new System.Drawing.Size(171, 26);
		this.lblLoginPassword.TabIndex = 5;
		this.lblLoginPassword.Text = "Login Password : ";
		this.lblUserName.AutoSize = true;
		this.lblUserName.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.lblUserName.Location = new System.Drawing.Point(12, 109);
		this.lblUserName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
		this.lblUserName.Name = "lblUserName";
		this.lblUserName.Size = new System.Drawing.Size(127, 26);
		this.lblUserName.TabIndex = 3;
		this.lblUserName.Text = "User Name : ";
		this.comboBox_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboBox_0.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.comboBox_0.FormattingEnabled = true;
		this.comboBox_0.Location = new System.Drawing.Point(187, 64);
		this.comboBox_0.Margin = new System.Windows.Forms.Padding(5);
		this.comboBox_0.Name = "comboBox_0";
		this.comboBox_0.Size = new System.Drawing.Size(370, 30);
		this.comboBox_0.TabIndex = 2;
		this.comboBox_0.SelectedIndexChanged += new System.EventHandler(comboBox_0_SelectedIndexChanged);
		this.lblBankName.AutoSize = true;
		this.lblBankName.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.lblBankName.Location = new System.Drawing.Point(12, 63);
		this.lblBankName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
		this.lblBankName.Name = "lblBankName";
		this.lblBankName.Size = new System.Drawing.Size(132, 26);
		this.lblBankName.TabIndex = 1;
		this.lblBankName.Text = "Bank Name : ";
		this.btnNBSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnNBSave.BackColor = System.Drawing.Color.FloralWhite;
		this.btnNBSave.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.btnNBSave.ForeColor = System.Drawing.Color.FromArgb(64, 62, 101);
		this.btnNBSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnNBSave.Location = new System.Drawing.Point(192, 441);
		this.btnNBSave.Margin = new System.Windows.Forms.Padding(5);
		this.btnNBSave.Name = "btnNBSave";
		this.btnNBSave.Size = new System.Drawing.Size(373, 38);
		this.btnNBSave.TabIndex = 15;
		this.btnNBSave.Text = "&Save";
		this.btnNBSave.UseVisualStyleBackColor = false;
		this.btnNBSave.Click += new System.EventHandler(btnNBSave_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(154f, 154f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.BackColor = System.Drawing.Color.FromArgb(0, 127, 166);
		base.Controls.Add(this.panel9);
		base.Controls.Add(this.panel1);
		base.Margin = new System.Windows.Forms.Padding(5);
		base.Name = "tabNetBanking";
		base.Size = new System.Drawing.Size(1181, 495);
		base.Load += new System.EventHandler(tabNetBanking_Load);
		this.panel9.ResumeLayout(false);
		this.panel1.ResumeLayout(false);
		this.panel1.PerformLayout();
		base.ResumeLayout(false);
	}
}
