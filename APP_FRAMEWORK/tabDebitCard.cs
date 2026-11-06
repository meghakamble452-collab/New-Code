using System;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace APP_FRAMEWORK;

internal class tabDebitCard : UserControl
{
	private IDisposable idisposable_0;

	private ToolTip toolTip_0;

	private IContainer icontainer_0;

	private Panel panel4;

	private ListBox lstDebit;

	private Panel panel12;

	private Label label19;

	private TextBox B0AAA;

	private TextBox C0AA0;

	private Label label27;

	private ComboBox cboDebitGateway;

	private Label label29;

	private Label label30;

	private TextBox txtDCSaveName;

	private ComboBox cboDebitCardType;

	private Label label31;

	private Label label32;

	private TextBox txtDebitCVV;

	private Label label33;

	private ComboBox B1AAA;

	private ComboBox C1AA0;

	private TextBox txtDebitVisaPin;

	private TextBox txtDebitNo;

	private Label label34;

	private Label label35;

	private ComboBox cboDebitBank;

	private Label label36;

	private Button btnDebitDeleteAll;

	internal Button btnCreditEdit1;

	internal Button btnCreditSave1;

	private Button btnDebitDelete;

	private CheckBox checkBox2;

	private IContainer components;

	internal Button button1;

	public tabDebitCard()
	{
		InitializeComponent();
	}

	private void method_0()
	{
		txtDebitNo.Text = "";
		txtDebitCVV.Text = "";
		txtDebitVisaPin.Text = "";
		txtDCSaveName.Text = "";
		B0AAA.Text = "";
		C0AA0.Text = "";
		cboDebitGateway.SelectedIndex = 0;
		cboDebitBank.SelectedIndex = 0;
		cboDebitCardType.SelectedIndex = -1;
		C1AA0.SelectedIndex = -1;
		B1AAA.SelectedIndex = -1;
		method_2();
	}

	private void method_1()
	{
		cboDebitBank.Items.Clear();
		ComboBox.ObjectCollection items = cboDebitBank.Items;
		string item = "Select DebitCard Bank";
		items.Add(item);
		foreach (string key in Program.dictionary_3.Keys)
		{
			string value = "_CC";
			if (key.Contains(value))
			{
				continue;
			}
			string text = key;
			if (cboDebitGateway.SelectedIndex != 0)
			{
				if (cboDebitGateway.SelectedIndex == 1)
				{
					string text2 = "HDFC";
					if (text == text2)
					{
						cboDebitBank.Items.Add(text);
					}
				}
				continue;
			}
			string text3 = "SBI";
			bool flag = text == text3;
			string text4 = "NSDL";
			bool flag2 = flag | (text == text4);
			string text5 = "ICICI";
			bool flag3 = flag2 | (text == text5);
			string text6 = "HDFC";
			bool flag4 = flag3 | (text == text6);
			string text7 = "INDIAN";
			bool flag5 = flag4 | (text == text7);
			string text8 = "AXIS";
			bool flag6 = flag5 | (text == text8);
			string text9 = "UNION";
			bool flag7 = flag6 | (text == text9);
			string text10 = "CANARA";
			bool flag8 = flag7 | (text == text10);
			string text11 = "PNB";
			bool flag9 = flag8 | (text == text11);
			string text12 = "ANDHRA";
			bool flag10 = flag9 | (text == text12);
			string text13 = "BOI";
			bool flag11 = flag10 | (text == text13);
			string text14 = "IOB";
			bool flag12 = flag11 | (text == text14);
			string text15 = "CBI";
			bool flag13 = flag12 | (text == text15);
			string text16 = "PAYZAP";
			bool flag14 = flag13 | (text == text16);
			string text17 = "ICICIVERTUAL";
			if (flag14 | (text == text17))
			{
				cboDebitBank.Items.Add(text);
			}
		}
		cboDebitBank.SelectedIndex = 0;
	}

	private void method_2()
	{
		try
		{
			lstDebit.Items.Clear();
			DataTable dataTable = new DataTable();
			string commandText = "SELECT BANK_SAVEAS from TBL_BANK WHERE BANK_ISDEBIT = 1 and (BANK_SAVEAS like '%_CC_%' or BANK_SAVEAS like '%_DC_%')";
			new SQLiteDataAdapter(commandText, Class34.string_Database).Fill(dataTable);
			if (dataTable == null || dataTable.Rows.Count <= 0)
			{
				return;
			}
			foreach (DataRow row in dataTable.Rows)
			{
				string text = row[0].ToString();
				string value = "_DC";
				if (text.Contains(value))
				{
					lstDebit.Items.Add(row[0].ToString());
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private void txtDebitNo_TextChanged(object sender, EventArgs e)
	{
		if (cboDebitBank.SelectedIndex < 1)
		{
			string text = "Please Select Valid Bank!";
			string caption = "Bank";
			MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			txtDebitNo.Text = "";
			cboDebitBank.Focus();
			return;
		}
		if (cboDebitCardType.SelectedIndex < 0)
		{
			string text2 = "Please Select Valid Card Type!";
			string caption2 = "Card Type";
			MessageBox.Show(text2, caption2, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			txtDebitNo.Text = "";
			cboDebitCardType.Focus();
			return;
		}
		string text3 = txtDebitNo.Text.Trim();
		if (text3.Length > 6)
		{
			string text4 = text3.Substring(0, 2);
			string text5 = "xx";
			text3 = text4 + text5 + text3.Substring(text3.Length - 4, 4);
		}
		string text6 = "";
		string text7 = "_DC_";
		string text8 = text7;
		if (cboDebitGateway.SelectedIndex == 1)
		{
			string text9 = "_ICI_";
			text6 = text9;
		}
		txtDCSaveName.Text = cboDebitBank.SelectedItem.ToString() + text8 + text6 + text3;
	}

	private void tabDebitCard_Load_1(object sender, EventArgs e)
	{
		B1AAA.Items.Clear();
		int i = DateTime.Now.Year - 1;
		for (int num = i + 30; i <= num; i++)
		{
			B1AAA.Items.Add(i.ToString());
		}
		method_0();
	}

	private void cboDebitGateway_SelectedIndexChanged(object sender, EventArgs e)
	{
		method_1();
	}

	private void btnCreditSave1_Click(object sender, EventArgs e)
	{
		TextBox textBox = txtDebitNo;
		txtDebitNo_TextChanged(null, null);
		if (!string.IsNullOrEmpty(textBox.Text) && textBox.Text.Length >= 10 && Class34.smethod_5(textBox.Text.Trim()))
		{
			TextBox textBox2 = txtDebitVisaPin;
			if (string.IsNullOrEmpty(textBox2.Text) || textBox2.Text.Length < 4)
			{
				string text = "Enter Valid Visa / Master Pin!";
				string caption = "Debit Card";
				MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				textBox2.Focus();
			}
			else if (C1AA0.SelectedIndex >= 0 && B1AAA.SelectedIndex >= 0)
			{
				TextBox textBox3 = txtDebitCVV;
				if (textBox3.Visible && (string.IsNullOrEmpty(textBox3.Text) || textBox3.Text.Length < 3 || !Class34.smethod_5(textBox3.Text.Trim())))
				{
					string text2 = "Enter Valid CVV!";
					string caption2 = "Debit Card";
					MessageBox.Show(text2, caption2, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					textBox3.Focus();
					return;
				}
				string text3 = txtDCSaveName.Text.Replace('_', 'A').Replace('-', 'A');
				if (string.IsNullOrEmpty(text3) || !Class34.smethod_3(text3))
				{
					string text4 = "Please enter valid CC Name to Save! (Only Alphabets, Numbers and (_) (-) are allowed)";
					string caption3 = "Card Name";
					MessageBox.Show(text4, caption3, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					txtDCSaveName.Focus();
					return;
				}
				string value = "_CC";
				if (text3.IndexOf(value, StringComparison.CurrentCultureIgnoreCase) < 0)
				{
					string value2 = "CC_";
					if (text3.IndexOf(value2, StringComparison.CurrentCultureIgnoreCase) < 0)
					{
						string value3 = "_DC";
						if (text3.IndexOf(value3, StringComparison.CurrentCultureIgnoreCase) < 0)
						{
							string value4 = "DC_";
							if (text3.IndexOf(value4, StringComparison.CurrentCultureIgnoreCase) < 0)
							{
								string value5 = "_ICI";
								if (text3.IndexOf(value5, StringComparison.CurrentCultureIgnoreCase) < 0)
								{
									string value6 = "_AXS";
									if (text3.IndexOf(value6, StringComparison.CurrentCultureIgnoreCase) < 0)
									{
										string value7 = "_PTM";
										if (text3.IndexOf(value7, StringComparison.CurrentCultureIgnoreCase) < 0)
										{
											if (cboDebitBank.SelectedIndex <= 0)
											{
												string text5 = "Select Valid Bank Name";
												string caption4 = "Valid Card";
												MessageBox.Show(text5, caption4, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
												cboDebitBank.Focus();
												return;
											}
											if (cboDebitCardType.SelectedIndex < 0)
											{
												string text6 = "Please Select Valid Card Type!";
												string caption5 = "Card Type";
												MessageBox.Show(text6, caption5, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
												txtDebitNo.Text = "";
												cboDebitCardType.Focus();
												return;
											}
											try
											{
												string[] array = new string[17]
												{
													txtDebitNo.Text.Trim(),
													null,
													null,
													null,
													null,
													null,
													null,
													null,
													null,
													null,
													null,
													null,
													null,
													null,
													null,
													null,
													null
												};
												string text7 = "||";
												array[1] = text7;
												array[2] = C1AA0.SelectedItem.ToString();
												string text8 = "||";
												array[3] = text8;
												array[4] = B1AAA.SelectedItem.ToString();
												string text9 = "||";
												array[5] = text9;
												array[6] = txtDebitVisaPin.Text.Trim();
												string text10 = "||";
												array[7] = text10;
												array[8] = txtDebitCVV.Text.Trim();
												string text11 = "||";
												array[9] = text11;
												array[10] = cboDebitCardType.SelectedItem.ToString();
												string text12 = "||";
												array[11] = text12;
												array[12] = B0AAA.Text.Trim();
												string text13 = "||";
												array[13] = text13;
												array[14] = C0AA0.Text.Trim();
												string text14 = "||";
												array[15] = text14;
												array[16] = cboDebitGateway.SelectedItem.ToString();
												string text15 = string.Concat(array);
												SQLiteConnection sQLiteConnection = new SQLiteConnection(Class34.string_Database);
												sQLiteConnection.Open();
												SQLiteCommand sQLiteCommand = new SQLiteCommand(sQLiteConnection);
												string text16 = "SELECT count(RID) from TBL_BANK where BANK_SAVEAS = '";
												string text17 = txtDCSaveName.Text.Trim();
												string text18 = "' AND BANK_ISDEBIT = 1";
												sQLiteCommand.CommandText = text16 + text17 + text18;
												object obj = sQLiteCommand.ExecuteScalar();
												int result = 0;
												if (obj != null && obj.GetType() != typeof(DBNull))
												{
													int.TryParse(obj.ToString().Trim(), out result);
												}
												if (result > 0)
												{
													string text19 = "Debit Card Details already exists. Do you want to Update?\r\n\r\nIf you need to update existing details, Click 'YES', Otherwise you can Click 'NO'";
													string caption6 = "Details Exists";
													if (MessageBox.Show(text19, caption6, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
													{
														sQLiteConnection.Close();
														sQLiteCommand.Dispose();
														return;
													}
													string text20 = "DELETE from TBL_BANK where BANK_SAVEAS = '";
													string text21 = txtDCSaveName.Text.Trim();
													string text22 = "' AND BANK_ISDEBIT = 1";
													sQLiteCommand.CommandText = text20 + text21 + text22;
													sQLiteCommand.ExecuteNonQuery();
													Program.dictionary_00.Remove(txtDCSaveName.Text.Trim());
												}
												Program.dictionary_00.Add(txtDCSaveName.Text.Trim(), text15);
												string[] array2 = new string[7];
												string text23 = "INSERT INTO TBL_BANK(BANK_NAME, BANK_SAVEAS, BANK_DETAILS, BANK_ISDEBIT) VALUES ('";
												array2[0] = text23;
												array2[1] = cboDebitBank.SelectedItem.ToString();
												string text24 = "', '";
												array2[2] = text24;
												array2[3] = txtDCSaveName.Text.Trim();
												string text25 = "', '";
												array2[4] = text25;
												array2[5] = text15;
												string text26 = "', 1)";
												array2[6] = text26;
												sQLiteCommand.CommandText = string.Concat(array2);
												sQLiteCommand.ExecuteNonQuery();
												sQLiteConnection.Close();
												sQLiteCommand.Dispose();
												method_0();
												string text27 = "Debit Card Details Updated Successfully!";
												string caption7 = "Bank Details";
												MessageBox.Show(text27, caption7, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
												return;
											}
											catch
											{
												string text28 = "Error Occured while Saving Debit Card Details";
												MessageBox.Show(text28);
												return;
											}
										}
									}
								}
							}
						}
					}
				}
				string text29 = "_CC, _ICI, _AXS, _PTM or _DC words are not allowed in name.";
				string caption8 = "Card Name";
				MessageBox.Show(text29, caption8, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				txtDCSaveName.Focus();
			}
			else
			{
				string text30 = "Select Valid Thru/Expiry Date!";
				string caption9 = "Debit Card";
				MessageBox.Show(text30, caption9, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				C1AA0.Focus();
			}
		}
		else
		{
			string text31 = "Enter Valid Card No.!";
			string caption10 = "Debit Card";
			MessageBox.Show(text31, caption10, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			textBox.Focus();
		}
	}

	private void btnCreditEdit1_Click(object sender, EventArgs e)
	{
		if (lstDebit.SelectedIndex < 0)
		{
			string text = "Please select Card to Edit";
			string caption = "Edit Card";
			MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			return;
		}
		string text2 = lstDebit.SelectedItem.ToString();
		DataTable dataTable = new DataTable();
		string text3 = "SELECT BANK_NAME, BANK_DETAILS from TBL_BANK WHERE BANK_ISDEBIT = 1 AND BANK_SAVEAS = '";
		string text4 = "'";
		new SQLiteDataAdapter(text3 + text2 + text4, Class34.string_Database).Fill(dataTable);
		if (dataTable.Rows != null && dataTable.Rows.Count > 0)
		{
			dataTable.Rows[0][0].ToString();
			string value = "_DC";
			if (text2.Contains(value))
			{
				string value2 = "_IRC_";
				if (!text2.Contains(value2))
				{
					string value3 = "_PTM_";
					if (text2.Contains(value3))
					{
						cboDebitGateway.SelectedIndex = 1;
					}
					else
					{
						string value4 = "_ICI_";
						if (text2.Contains(value4))
						{
							cboDebitGateway.SelectedIndex = 1;
						}
					}
				}
				else
				{
					cboDebitGateway.SelectedIndex = 0;
				}
				string value5 = "_";
				string text5 = text2.Substring(text2.IndexOf(value5) + 1).Trim();
				string value6 = "_";
				string text6 = text2.Substring(0, text2.IndexOf(value6)).Trim();
				string value7 = "__";
				if (text5.Contains(value7))
				{
					string value8 = "__";
					text5.Substring(0, text5.IndexOf(value8)).Trim();
					string value9 = "__";
					string text7 = text5.Substring(text5.IndexOf(value9) + 2).Trim();
					string value10 = "_";
					if (text7.Contains(value10))
					{
						string value11 = "_";
						text7.Substring(text7.IndexOf(value11) + 1).Trim();
					}
				}
				else
				{
					string value12 = "_";
					if (text5.Contains(value12))
					{
						string value13 = "_";
						text5.Substring(text5.IndexOf(value13) + 1).Trim();
					}
				}
				cboDebitBank.SelectedItem = text6;
				cboDebitCardType.SelectedIndex = 0;
				string text8 = dataTable.Rows[0][1].ToString();
				string[] array = new string[1];
				string text9 = "||";
				array[0] = text9;
				string[] array2 = text8.Split(array, StringSplitOptions.RemoveEmptyEntries);
				try
				{
					txtDebitNo.Text = array2[0];
					C1AA0.SelectedItem = array2[1];
					B1AAA.SelectedItem = array2[2];
					txtDebitVisaPin.Text = array2[3];
					txtDebitCVV.Text = array2[4];
					cboDebitCardType.SelectedItem = array2[5];
					B0AAA.Text = array2[6];
					C0AA0.Text = array2[7];
					if (array2.Length > 8)
					{
						cboDebitGateway.SelectedItem = array2[8];
						string text10 = "HDFC";
						if (text6 == text10)
						{
							cboDebitBank.SelectedItem = text6;
						}
					}
				}
				catch
				{
				}
				txtDCSaveName.Text = text2;
			}
		}
		txtDebitNo_TextChanged(null, null);
	}

	private void btnDebitDelete_Click(object sender, EventArgs e)
	{
		if (lstDebit.SelectedIndex >= 0)
		{
			string text = lstDebit.SelectedItem.ToString();
			string text2 = "Do you really want to delete ";
			string text3 = text2 + text;
			string caption = "Delete";
			if (MessageBox.Show(text3, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
			{
				return;
			}
			SQLiteConnection sQLiteConnection = new SQLiteConnection(Class34.string_Database);
			sQLiteConnection.Open();
			SQLiteCommand sQLiteCommand = new SQLiteCommand(sQLiteConnection);
			string text4 = "DELETE from TBL_BANK where BANK_SAVEAS = '";
			string text5 = "' AND BANK_ISDEBIT = 1";
			sQLiteCommand.CommandText = text4 + text + text5;
			sQLiteCommand.ExecuteNonQuery();
			sQLiteConnection.Close();
			sQLiteCommand.Dispose();
			Program.dictionary_00.Remove(text);
			string text6 = "Debit Card Details for ";
			string text7 = " Deleted Successfully!";
			string text8 = text6 + text + text7;
			string caption2 = "Deleted";
			MessageBox.Show(text8, caption2, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		else
		{
			string text9 = "Please select Credit card to Delete";
			string caption3 = "Delete Credit";
			MessageBox.Show(text9, caption3, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		method_0();
	}

	private void BAAAA(object sender, EventArgs e)
	{
		string text = "Do you really want to delete All Credit Cards present in the List";
		string caption = "Delete All";
		if (MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
		{
			return;
		}
		SQLiteConnection sQLiteConnection = new SQLiteConnection(Class34.string_Database);
		sQLiteConnection.Open();
		SQLiteCommand sQLiteCommand = new SQLiteCommand(sQLiteConnection);
		foreach (object item in lstDebit.Items)
		{
			string text2 = item.ToString();
			string text3 = "DELETE from TBL_BANK where BANK_SAVEAS = '";
			string text4 = "' AND BANK_ISDEBIT = 1";
			sQLiteCommand.CommandText = text3 + text2 + text4;
			sQLiteCommand.ExecuteNonQuery();
		}
		sQLiteConnection.Close();
		sQLiteCommand.Dispose();
		lstDebit.Items.Clear();
		string text5 = "All Credit Cards Details Deleted Successfully!";
		string caption2 = "Deleted";
		MessageBox.Show(text5, caption2, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
	}

	private void CAAA0(object sender, EventArgs e)
	{
		if (checkBox2.Checked)
		{
			txtDebitVisaPin.PasswordChar = '\0';
			txtDebitCVV.PasswordChar = '\0';
			C0AA0.PasswordChar = '\0';
		}
		else
		{
			txtDebitVisaPin.PasswordChar = '*';
			txtDebitCVV.PasswordChar = '*';
			C0AA0.PasswordChar = '*';
		}
	}

	private void cboDebitBank_SelectedIndexChanged(object sender, EventArgs e)
	{
		object selectedItem = cboDebitBank.SelectedItem;
		string text = "PAYZAP";
		if (selectedItem == text)
		{
			label27.Visible = false;
			C0AA0.Visible = false;
			cboDebitCardType.SelectedIndex = 0;
		}
		else
		{
			label27.Visible = true;
			C0AA0.Visible = true;
		}
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
		this.panel12 = new System.Windows.Forms.Panel();
		this.checkBox2 = new System.Windows.Forms.CheckBox();
		this.label19 = new System.Windows.Forms.Label();
		this.B0AAA = new System.Windows.Forms.TextBox();
		this.C0AA0 = new System.Windows.Forms.TextBox();
		this.label27 = new System.Windows.Forms.Label();
		this.cboDebitGateway = new System.Windows.Forms.ComboBox();
		this.label29 = new System.Windows.Forms.Label();
		this.label30 = new System.Windows.Forms.Label();
		this.txtDCSaveName = new System.Windows.Forms.TextBox();
		this.cboDebitCardType = new System.Windows.Forms.ComboBox();
		this.label31 = new System.Windows.Forms.Label();
		this.label32 = new System.Windows.Forms.Label();
		this.txtDebitCVV = new System.Windows.Forms.TextBox();
		this.label33 = new System.Windows.Forms.Label();
		this.B1AAA = new System.Windows.Forms.ComboBox();
		this.C1AA0 = new System.Windows.Forms.ComboBox();
		this.txtDebitVisaPin = new System.Windows.Forms.TextBox();
		this.txtDebitNo = new System.Windows.Forms.TextBox();
		this.label34 = new System.Windows.Forms.Label();
		this.label35 = new System.Windows.Forms.Label();
		this.cboDebitBank = new System.Windows.Forms.ComboBox();
		this.label36 = new System.Windows.Forms.Label();
		this.btnCreditSave1 = new System.Windows.Forms.Button();
		this.panel4 = new System.Windows.Forms.Panel();
		this.lstDebit = new System.Windows.Forms.ListBox();
		this.btnDebitDelete = new System.Windows.Forms.Button();
		this.btnCreditEdit1 = new System.Windows.Forms.Button();
		this.btnDebitDeleteAll = new System.Windows.Forms.Button();
		this.button1 = new System.Windows.Forms.Button();
		this.toolTip_0 = new System.Windows.Forms.ToolTip(this.components);
		this.panel12.SuspendLayout();
		this.panel4.SuspendLayout();
		base.SuspendLayout();
		this.panel12.BackColor = System.Drawing.Color.White;
		this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.panel12.Controls.Add(this.checkBox2);
		this.panel12.Controls.Add(this.label19);
		this.panel12.Controls.Add(this.B0AAA);
		this.panel12.Controls.Add(this.C0AA0);
		this.panel12.Controls.Add(this.label27);
		this.panel12.Controls.Add(this.cboDebitGateway);
		this.panel12.Controls.Add(this.label29);
		this.panel12.Controls.Add(this.label30);
		this.panel12.Controls.Add(this.txtDCSaveName);
		this.panel12.Controls.Add(this.cboDebitCardType);
		this.panel12.Controls.Add(this.label31);
		this.panel12.Controls.Add(this.label32);
		this.panel12.Controls.Add(this.txtDebitCVV);
		this.panel12.Controls.Add(this.label33);
		this.panel12.Controls.Add(this.B1AAA);
		this.panel12.Controls.Add(this.C1AA0);
		this.panel12.Controls.Add(this.txtDebitVisaPin);
		this.panel12.Controls.Add(this.txtDebitNo);
		this.panel12.Controls.Add(this.label34);
		this.panel12.Controls.Add(this.label35);
		this.panel12.Controls.Add(this.cboDebitBank);
		this.panel12.Controls.Add(this.label36);
		this.panel12.Controls.Add(this.btnCreditSave1);
		this.panel12.Location = new System.Drawing.Point(2, 1);
		this.panel12.Name = "panel12";
		this.panel12.Size = new System.Drawing.Size(360, 306);
		this.panel12.TabIndex = 6;
		this.checkBox2.AutoSize = true;
		this.checkBox2.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.checkBox2.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.checkBox2.Location = new System.Drawing.Point(8, 235);
		this.checkBox2.Name = "checkBox2";
		this.checkBox2.Size = new System.Drawing.Size(117, 19);
		this.checkBox2.TabIndex = 44;
		this.checkBox2.Text = "Show Password";
		this.checkBox2.UseVisualStyleBackColor = true;
		this.label19.AutoSize = true;
		this.label19.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.label19.Location = new System.Drawing.Point(8, 138);
		this.label19.Name = "label19";
		this.label19.Size = new System.Drawing.Size(94, 15);
		this.label19.TabIndex = 43;
		this.label19.Text = "Name on Card: ";
		this.B0AAA.BackColor = System.Drawing.Color.FromArgb(235, 248, 239);
		this.B0AAA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.B0AAA.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.B0AAA.Location = new System.Drawing.Point(155, 136);
		this.B0AAA.MaxLength = 30;
		this.B0AAA.Name = "B0AAA";
		this.B0AAA.Size = new System.Drawing.Size(190, 20);
		this.B0AAA.TabIndex = 42;
		this.C0AA0.BackColor = System.Drawing.Color.FromArgb(235, 248, 239);
		this.C0AA0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.C0AA0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.C0AA0.Location = new System.Drawing.Point(155, 181);
		this.C0AA0.MaxLength = 20;
		this.C0AA0.Name = "C0AA0";
		this.C0AA0.Size = new System.Drawing.Size(190, 20);
		this.C0AA0.TabIndex = 41;
		this.label27.AutoSize = true;
		this.label27.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.label27.Location = new System.Drawing.Point(8, 183);
		this.label27.Name = "label27";
		this.label27.Size = new System.Drawing.Size(121, 15);
		this.label27.TabIndex = 40;
		this.label27.Text = "Card 3D Password : ";
		this.cboDebitGateway.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboDebitGateway.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboDebitGateway.FormattingEnabled = true;
		System.Windows.Forms.ComboBox.ObjectCollection items = this.cboDebitGateway.Items;
		items.AddRange(new object[2] { "IRCTC", "ICICI" });
		this.cboDebitGateway.Location = new System.Drawing.Point(154, 8);
		this.cboDebitGateway.Name = "cboDebitGateway";
		this.cboDebitGateway.Size = new System.Drawing.Size(141, 23);
		this.cboDebitGateway.TabIndex = 23;
		this.cboDebitGateway.SelectedIndexChanged += new System.EventHandler(cboDebitGateway_SelectedIndexChanged);
		this.label29.AutoSize = true;
		this.label29.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.label29.Location = new System.Drawing.Point(8, 13);
		this.label29.Name = "label29";
		this.label29.Size = new System.Drawing.Size(69, 15);
		this.label29.TabIndex = 22;
		this.label29.Text = "Gateway : ";
		this.label30.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.label30.AutoSize = true;
		this.label30.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.label30.ForeColor = System.Drawing.Color.Maroon;
		this.label30.Location = new System.Drawing.Point(8, 208);
		this.label30.Name = "label30";
		this.label30.Size = new System.Drawing.Size(97, 15);
		this.label30.TabIndex = 14;
		this.label30.Text = "Name to Save : ";
		this.txtDCSaveName.BackColor = System.Drawing.SystemColors.Control;
		this.txtDCSaveName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtDCSaveName.Enabled = false;
		this.txtDCSaveName.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtDCSaveName.Location = new System.Drawing.Point(155, 203);
		this.txtDCSaveName.MaxLength = 15;
		this.txtDCSaveName.Name = "txtDCSaveName";
		this.txtDCSaveName.Size = new System.Drawing.Size(190, 20);
		this.txtDCSaveName.TabIndex = 15;
		this.cboDebitCardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboDebitCardType.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboDebitCardType.FormattingEnabled = true;
		System.Windows.Forms.ComboBox.ObjectCollection items2 = this.cboDebitCardType.Items;
		items2.AddRange(new object[3] { "Visa", "Master", "Rupay" });
		this.cboDebitCardType.Location = new System.Drawing.Point(154, 60);
		this.cboDebitCardType.Name = "cboDebitCardType";
		this.cboDebitCardType.Size = new System.Drawing.Size(101, 23);
		this.cboDebitCardType.TabIndex = 4;
		this.label31.AutoSize = true;
		this.label31.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.label31.Location = new System.Drawing.Point(8, 65);
		this.label31.Name = "label31";
		this.label31.Size = new System.Drawing.Size(73, 15);
		this.label31.TabIndex = 3;
		this.label31.Text = "Card Type : ";
		this.label32.AutoSize = true;
		this.label32.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label32.Location = new System.Drawing.Point(248, 162);
		this.label32.Name = "label32";
		this.label32.Size = new System.Drawing.Size(37, 14);
		this.label32.TabIndex = 12;
		this.label32.Text = "CVV :";
		this.txtDebitCVV.BackColor = System.Drawing.Color.FromArgb(235, 248, 239);
		this.txtDebitCVV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtDebitCVV.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtDebitCVV.Location = new System.Drawing.Point(291, 159);
		this.txtDebitCVV.MaxLength = 3;
		this.txtDebitCVV.Name = "txtDebitCVV";
		this.txtDebitCVV.Size = new System.Drawing.Size(53, 20);
		this.txtDebitCVV.TabIndex = 13;
		this.label33.AutoSize = true;
		this.label33.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.label33.Location = new System.Drawing.Point(8, 162);
		this.label33.Name = "label33";
		this.label33.Size = new System.Drawing.Size(113, 15);
		this.label33.TabIndex = 10;
		this.label33.Text = "Visa / Master Pin : ";
		this.B1AAA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.B1AAA.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.B1AAA.FormattingEnabled = true;
		this.B1AAA.Location = new System.Drawing.Point(245, 110);
		this.B1AAA.Name = "B1AAA";
		this.B1AAA.Size = new System.Drawing.Size(99, 23);
		this.B1AAA.TabIndex = 9;
		this.C1AA0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.C1AA0.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.C1AA0.FormattingEnabled = true;
		System.Windows.Forms.ComboBox.ObjectCollection items3 = this.C1AA0.Items;
		items3.AddRange(new object[12]
		{
			"01", "02", "03", "04", "05", "06", "07", "08", "09", "10",
			"11", "12"
		});
		this.C1AA0.Location = new System.Drawing.Point(155, 110);
		this.C1AA0.Name = "C1AA0";
		this.C1AA0.Size = new System.Drawing.Size(64, 23);
		this.C1AA0.TabIndex = 8;
		this.txtDebitVisaPin.BackColor = System.Drawing.Color.FromArgb(235, 248, 239);
		this.txtDebitVisaPin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtDebitVisaPin.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtDebitVisaPin.Location = new System.Drawing.Point(155, 159);
		this.txtDebitVisaPin.MaxLength = 15;
		this.txtDebitVisaPin.Name = "txtDebitVisaPin";
		this.txtDebitVisaPin.Size = new System.Drawing.Size(79, 20);
		this.txtDebitVisaPin.TabIndex = 11;
		this.txtDebitNo.BackColor = System.Drawing.Color.FromArgb(235, 248, 239);
		this.txtDebitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtDebitNo.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtDebitNo.Location = new System.Drawing.Point(154, 87);
		this.txtDebitNo.MaxLength = 20;
		this.txtDebitNo.Name = "txtDebitNo";
		this.txtDebitNo.Size = new System.Drawing.Size(190, 20);
		this.txtDebitNo.TabIndex = 6;
		this.txtDebitNo.TextChanged += new System.EventHandler(txtDebitNo_TextChanged);
		this.label34.AutoSize = true;
		this.label34.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.label34.Location = new System.Drawing.Point(8, 115);
		this.label34.Name = "label34";
		this.label34.Size = new System.Drawing.Size(144, 15);
		this.label34.TabIndex = 7;
		this.label34.Text = "Valid Thru/Expiry Date : ";
		this.label35.AutoSize = true;
		this.label35.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.label35.Location = new System.Drawing.Point(8, 89);
		this.label35.Name = "label35";
		this.label35.Size = new System.Drawing.Size(67, 15);
		this.label35.TabIndex = 5;
		this.label35.Text = "Card No. : ";
		this.cboDebitBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboDebitBank.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboDebitBank.FormattingEnabled = true;
		this.cboDebitBank.Location = new System.Drawing.Point(154, 34);
		this.cboDebitBank.Name = "cboDebitBank";
		this.cboDebitBank.Size = new System.Drawing.Size(141, 23);
		this.cboDebitBank.TabIndex = 2;
		this.cboDebitBank.SelectedIndexChanged += new System.EventHandler(cboDebitBank_SelectedIndexChanged);
		this.label36.AutoSize = true;
		this.label36.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.label36.Location = new System.Drawing.Point(8, 39);
		this.label36.Name = "label36";
		this.label36.Size = new System.Drawing.Size(83, 15);
		this.label36.TabIndex = 1;
		this.label36.Text = "Bank Name : ";
		this.btnCreditSave1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnCreditSave1.BackColor = System.Drawing.Color.FloralWhite;
		this.btnCreditSave1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnCreditSave1.ForeColor = System.Drawing.Color.FromArgb(64, 62, 101);
		this.btnCreditSave1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCreditSave1.Location = new System.Drawing.Point(154, 276);
		this.btnCreditSave1.Name = "btnCreditSave1";
		this.btnCreditSave1.Size = new System.Drawing.Size(191, 25);
		this.btnCreditSave1.TabIndex = 18;
		this.btnCreditSave1.Text = "&Save";
		this.btnCreditSave1.UseVisualStyleBackColor = false;
		this.btnCreditSave1.Click += new System.EventHandler(btnCreditSave1_Click);
		this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.panel4.Controls.Add(this.lstDebit);
		this.panel4.Controls.Add(this.btnDebitDelete);
		this.panel4.Controls.Add(this.btnCreditEdit1);
		this.panel4.Controls.Add(this.btnDebitDeleteAll);
		this.panel4.Controls.Add(this.button1);
		this.panel4.Location = new System.Drawing.Point(363, 1);
		this.panel4.Name = "panel4";
		this.panel4.Size = new System.Drawing.Size(378, 306);
		this.panel4.TabIndex = 5;
		this.lstDebit.BackColor = System.Drawing.Color.GhostWhite;
		this.lstDebit.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.lstDebit.Dock = System.Windows.Forms.DockStyle.Top;
		this.lstDebit.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lstDebit.FormattingEnabled = true;
		this.lstDebit.ItemHeight = 14;
		this.lstDebit.Location = new System.Drawing.Point(0, 0);
		this.lstDebit.Name = "lstDebit";
		this.lstDebit.Size = new System.Drawing.Size(376, 252);
		this.lstDebit.TabIndex = 0;
		this.btnDebitDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnDebitDelete.BackColor = System.Drawing.Color.FloralWhite;
		this.btnDebitDelete.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnDebitDelete.ForeColor = System.Drawing.Color.FromArgb(64, 62, 101);
		this.btnDebitDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnDebitDelete.Location = new System.Drawing.Point(132, 277);
		this.btnDebitDelete.Name = "btnDebitDelete";
		this.btnDebitDelete.Size = new System.Drawing.Size(104, 25);
		this.btnDebitDelete.TabIndex = 20;
		this.btnDebitDelete.Text = "&Delete";
		this.btnDebitDelete.UseVisualStyleBackColor = false;
		this.btnDebitDelete.Click += new System.EventHandler(btnDebitDelete_Click);
		this.btnCreditEdit1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnCreditEdit1.BackColor = System.Drawing.Color.FloralWhite;
		this.btnCreditEdit1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnCreditEdit1.ForeColor = System.Drawing.Color.FromArgb(64, 62, 101);
		this.btnCreditEdit1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCreditEdit1.Location = new System.Drawing.Point(4, 277);
		this.btnCreditEdit1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
		this.btnCreditEdit1.Name = "btnCreditEdit1";
		this.btnCreditEdit1.Size = new System.Drawing.Size(117, 25);
		this.btnCreditEdit1.TabIndex = 19;
		this.btnCreditEdit1.Text = "&Edit";
		this.btnCreditEdit1.UseVisualStyleBackColor = false;
		this.btnCreditEdit1.Click += new System.EventHandler(btnCreditEdit1_Click);
		this.btnDebitDeleteAll.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnDebitDeleteAll.BackColor = System.Drawing.Color.FloralWhite;
		this.btnDebitDeleteAll.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnDebitDeleteAll.ForeColor = System.Drawing.Color.FromArgb(64, 62, 101);
		this.btnDebitDeleteAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnDebitDeleteAll.Location = new System.Drawing.Point(244, 276);
		this.btnDebitDeleteAll.Name = "btnDebitDeleteAll";
		this.btnDebitDeleteAll.Size = new System.Drawing.Size(130, 25);
		this.btnDebitDeleteAll.TabIndex = 21;
		this.btnDebitDeleteAll.Text = " De&lete All";
		this.btnDebitDeleteAll.UseVisualStyleBackColor = false;
		this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
		this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.button1.Location = new System.Drawing.Point(-217, 275);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(191, 25);
		this.button1.TabIndex = 18;
		this.button1.Text = "Save";
		this.button1.UseVisualStyleBackColor = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.BackColor = System.Drawing.Color.FromArgb(0, 127, 166);
		base.Controls.Add(this.panel4);
		base.Controls.Add(this.panel12);
		base.Name = "tabDebitCard";
		base.Size = new System.Drawing.Size(744, 310);
		base.Load += new System.EventHandler(tabDebitCard_Load_1);
		this.panel12.ResumeLayout(false);
		this.panel12.PerformLayout();
		this.panel4.ResumeLayout(false);
		base.ResumeLayout(false);
	}
}
