using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace APP_FRAMEWORK;

internal class frmBanks : Form
{
	private string string_0;

	private int B3AAA;

	private bool C3AA0;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private string string_1;

	private DataTable dataTable_0;

	private DataTable dataTable_1;

	private IContainer icontainer_0;

	private DataGridViewTextBoxColumn BDAAA;

	private DataGridViewTextBoxColumn CDAA0;

	private IDisposable idisposable_0;

	private Panel panel6;

	private ListBox lstCredit;

	private Panel pnlCredit;

	private Button B4AAA;

	internal Button btnCreditEdit;

	internal Button btnCreditSave;

	private Button C4AA0;

	private ComboBox cboCardType;

	private Label label5;

	private Label label6;

	private TextBox txtCreditCVV;

	private Label label7;

	private ComboBox cboCreditYear;

	private ComboBox cboCreditMonth;

	private TextBox txtCreditVisaPin;

	private TextBox txtCreditNo;

	private Label label9;

	private Label B5AAA;

	private Label C5AA0;

	private Panel panel9;

	private ListBox lstNB;

	private Panel panel1;

	private Button btnNBDeleteAll;

	internal Button btnNBEdit;

	internal Button btnNBSave;

	private Button btnNBDelete;

	private Label lblOTP;

	private TextBox txtOTP;

	private TextBox txtTxnPassword;

	private TextBox txtLoginPassword;

	private TextBox txtUserName;

	private Label B6AAA;

	private Label C6AA0;

	private Label lblUserName;

	private ComboBox comboBox_0;

	private Label lblBankName;

	private Label label20;

	private TextBox txtCCSaveName;

	private ComboBox cboCreditBank;

	private Label label21;

	private TextBox txtNBSaveName;

	private ComboBox cboCreditGateway;

	private Label label22;

	private GroupBox B7AAA;

	private Label C7AA0;

	private Label lblActive;

	private Label label2;

	private Label label23;

	private Button btnActivate;

	internal TextBox txtPnr;

	private Button btnIDSave;

	internal TextBox txtPassword;

	internal CheckBox chkValidate;

	internal Label lblPassword;

	private DataGridView grdUsers;

	private ToolTip toolTip_0;

	private TextBox textCredit3DPin;

	private Label label4;

	private TextBox B8AAA;

	private Label C8AA0;

	internal CheckBox chkShowPwd;

	private Panel panel4;

	private ListBox lstDebit;

	private ComboBox cboGateway0;

	private Label label11;

	private Panel panel12;

	private Label label19;

	private TextBox txtDebitHolderName;

	private TextBox textDebit3DPin;

	private Label label27;

	private ComboBox cboDebitGateway;

	private Label B9AAA;

	private Label C9AA0;

	private TextBox txtDCSaveName;

	private ComboBox cboDebitCardType;

	private Label label31;

	private Label label32;

	private TextBox txtDebitCVV;

	private Label label33;

	private ComboBox cboDebitYear;

	private ComboBox cboDebitMonth;

	private TextBox txtDebitVisaPin;

	private TextBox txtDebitNo;

	private Label BBAAA;

	private Label CBAA0;

	private ComboBox cboDebitBank;

	private Label label36;

	private Button btnDebitDeleteAll;

	internal Button btnCreditEdit1;

	internal Button btnCreditSave1;

	private Button btnDebitDelete;

	private CheckBox checkBox1;

	private CheckBox checkBox2;

	private CheckBox checkBox3;

	private PictureBox pictureBox1;

	private Label lblMsg;

	private Label label8;

	private ComboBox BCAAA;

	private Button CCAA0;

	private DateTimePicker dtDate2;

	internal TextBox txtLogin;

	internal Label label37;

	private Button button2;

	private RadioButton RadioPnr;

	private RadioButton RadioJdate;

	private RadioButton RadioBdate;

	private DateTimePicker dtDate1;

	private Button button3;

	private DataGridView dgv;

	internal Label label41;

	private Button btnChangeQn;

	private DataGridViewTextBoxColumn clmID;

	private DataGridViewLinkColumn clmCheck;

	private DataGridViewLinkColumn clmAvtive;

	private DataGridViewLinkColumn clmDelete;

	private DataGridViewLinkColumn ClmHis;

	private Button button5;

	private Panel panel2;

	private GroupBox groupBox1;

	private Panel panel13;

	private Label lblCurMonbk;

	private Label lblTobk;

	private Label BEAAA;

	private Label CEAA0;

	private Label lbl7;

	private Label lbl6;

	private Label label17;

	private Label label18;

	private Button btnHideDay;

	private ComboBox CmbDays;

	private Label label14;

	internal Button button1;

	internal Label label44;

	internal Label label25;

	internal Label label38;

	internal Label label24;

	internal Label label28;

	internal Label label16;

	internal Label label26;

	private IContainer components;

	private DataGridViewTextBoxColumn clmPwd;

	private DataGridViewTextBoxColumn clmMTotal;

	private Panel pnlloader;

	public static DataTable GetAccounts()
	{
		try
		{
			DataTable dataTable = new DataTable();
			string commandText = "SELECT BANK_SAVEAS,BANK_DETAILS from TBL_BANK WHERE BANK_ISDEBIT = 0";
			new SQLiteDataAdapter(commandText, Class34.string_Database).Fill(dataTable);
			if (dataTable == null || dataTable.Rows.Count <= 0)
			{
				return null;
			}
			return dataTable;
		}
		catch (Exception)
		{
			return null;
		}
	}

	public frmBanks()
	{
		InitializeComponent();
	}

	private void method_0(object sender, EventArgs e)
	{
	}

	private void method_1()
	{
		txtCreditNo.Text = "";
		txtCreditCVV.Text = "";
		txtCreditVisaPin.Text = "";
		txtCCSaveName.Text = "";
		B8AAA.Text = "";
		textCredit3DPin.Text = "";
		BCAAA.SelectedIndex = 0;
		cboCreditGateway.SelectedIndex = 0;
		cboCreditBank.SelectedIndex = 0;
		cboCardType.SelectedIndex = -1;
		cboCreditMonth.SelectedIndex = -1;
		cboCreditYear.SelectedIndex = -1;
		method_5();
	}

	private void method_2()
	{
		txtDebitNo.Text = "";
		txtDebitCVV.Text = "";
		txtDebitVisaPin.Text = "";
		txtDCSaveName.Text = "";
		txtDebitHolderName.Text = "";
		textDebit3DPin.Text = "";
		cboDebitGateway.SelectedIndex = 0;
		cboDebitBank.SelectedIndex = 0;
		cboDebitCardType.SelectedIndex = -1;
		cboDebitMonth.SelectedIndex = -1;
		cboDebitYear.SelectedIndex = -1;
		method_6();
	}

	private void method_3()
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
					string text2 = "SBI";
					if (text == text2)
					{
						cboDebitBank.Items.Add(text);
					}
				}
				continue;
			}
			string text3 = "SBI";
			bool flag = text == text3;
			string text4 = "ICICI";
			bool flag2 = flag | (text == text4);
			string text5 = "HDFC";
			bool flag3 = flag2 | (text == text5);
			string text6 = "INDIAN";
			bool flag4 = flag3 | (text == text6);
			string text7 = "AXIS";
			bool flag5 = flag4 | (text == text7);
			string text8 = "UNION";
			bool flag6 = flag5 | (text == text8);
			string text9 = "CANARA";
			bool flag7 = flag6 | (text == text9);
			string text10 = "PNB";
			bool flag8 = flag7 | (text == text10);
			string text11 = "ANDHRA";
			bool flag9 = flag8 | (text == text11);
			string text12 = "BOI";
			bool flag10 = flag9 | (text == text12);
			string text13 = "IOB";
			bool flag11 = flag10 | (text == text13);
			string text14 = "CBI";
			if (flag11 | (text == text14))
			{
				cboDebitBank.Items.Add(text);
			}
		}
		cboDebitBank.SelectedIndex = 0;
	}

	private void method_4()
	{
		cboCreditBank.Items.Clear();
		ComboBox.ObjectCollection items = cboCreditBank.Items;
		string item = "Select CreditCard Bank";
		items.Add(item);
		foreach (string key in Program.dictionary_3.Keys)
		{
			string value = "_CC";
			if (!key.Contains(value))
			{
				continue;
			}
			string text = key.Substring(0, key.Length - 3);
			if (!((BCAAA.SelectedIndex == 0) | (BCAAA.SelectedIndex == 1)))
			{
				if (BCAAA.SelectedIndex != 2)
				{
					continue;
				}
				string value2 = "_CIT";
				if (key.Contains(value2) && cboCreditGateway.SelectedIndex == 0)
				{
					string value3 = "_CIT";
					if (text.Contains(value3))
					{
						cboCreditBank.Items.Add(text.Substring(0, text.Length - 4));
					}
				}
			}
			else if (cboCreditGateway.SelectedIndex == 0)
			{
				string value4 = "_HDF";
				if (text.Contains(value4))
				{
					cboCreditBank.Items.Add(text.Substring(0, text.Length - 4));
				}
			}
			else if (cboCreditGateway.SelectedIndex != 1)
			{
				if (cboCreditGateway.SelectedIndex != 2)
				{
					if (cboCreditGateway.SelectedIndex == 3)
					{
						string value5 = "_PTM";
						if (text.Contains(value5))
						{
							cboCreditBank.Items.Add(text.Substring(0, text.Length - 4));
						}
					}
				}
				else
				{
					string value6 = "_CIT";
					if (text.Contains(value6))
					{
						cboCreditBank.Items.Add(text.Substring(0, text.Length - 4));
					}
				}
			}
			else
			{
				string value7 = "_ICI";
				if (text.Contains(value7))
				{
					cboCreditBank.Items.Add(text.Substring(0, text.Length - 4));
				}
			}
		}
		cboCreditBank.SelectedIndex = 0;
	}

	private void method_5()
	{
		try
		{
			lstCredit.Items.Clear();
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
				string value = "_CC";
				if (text.Contains(value))
				{
					lstCredit.Items.Add(row[0].ToString());
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private void method_6()
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

	private void txtCreditNo_TextChanged(object sender, EventArgs e)
	{
		if (cboCreditBank.SelectedIndex < 1)
		{
			string text = "Please Select Valid Bank!";
			string caption = "Bank";
			MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			txtCreditNo.Text = "";
			cboCreditBank.Focus();
		}
		else if (cboCardType.SelectedIndex >= 0)
		{
			string text2 = txtCreditNo.Text.Trim();
			if (text2.Length > 6)
			{
				string text3 = text2.Substring(0, 2);
				string text4 = "xx";
				text2 = text3 + text4 + text2.Substring(text2.Length - 4, 4);
			}
			string text5 = "";
			string text6 = "_CC_";
			string text7 = text6;
			if (cboCreditGateway.SelectedIndex == 0)
			{
				string text8 = "_HDF_";
				text5 = text8;
			}
			else if (cboCreditGateway.SelectedIndex == 1)
			{
				string text9 = "_ICI_";
				text5 = text9;
			}
			else if (cboCreditGateway.SelectedIndex == 2)
			{
				string text10 = "_CIT_";
				text5 = text10;
			}
			else if (cboCreditGateway.SelectedIndex == 3)
			{
				string text11 = "_PTM_";
				text5 = text11;
			}
			txtCCSaveName.Text = cboCreditBank.SelectedItem.ToString() + text7 + text5 + text2;
		}
		else
		{
			string text12 = "Please Select Valid Card Type!";
			string caption2 = "Card Type";
			MessageBox.Show(text12, caption2, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			txtCreditNo.Text = "";
			cboCardType.Focus();
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
		if (cboCreditGateway.SelectedIndex == 1)
		{
			string text9 = "_PTM_";
			text6 = text9;
		}
		txtDCSaveName.Text = cboDebitBank.SelectedItem.ToString() + text8 + text6 + text3;
	}

	private void BAAAA(object sender, EventArgs e)
	{
		cboCreditYear.Items.Clear();
		cboDebitYear.Items.Clear();
		int i = DateTime.Now.Year - 1;
		for (int num = i + 30; i <= num; i++)
		{
			cboCreditYear.Items.Add(i.ToString());
			cboDebitYear.Items.Add(i.ToString());
		}
		B3AAA = base.Height;
	}

	private void CAAA0(object sender, EventArgs e)
	{
	}

	private void btnCreditSave_Click(object sender, EventArgs e)
	{
		TextBox textBox = txtCreditNo;
		if (!string.IsNullOrEmpty(textBox.Text) && textBox.Text.Length >= 10 && Class34.smethod_5(textBox.Text.Trim()))
		{
			TextBox textBox2 = txtCreditVisaPin;
			if (!string.IsNullOrEmpty(textBox2.Text) && textBox2.Text.Length >= 4)
			{
				if (cboCreditMonth.SelectedIndex >= 0 && cboCreditYear.SelectedIndex >= 0)
				{
					TextBox textBox3 = txtCreditCVV;
					if (!textBox3.Visible || (!string.IsNullOrEmpty(textBox3.Text) && textBox3.Text.Length >= 3 && Class34.smethod_5(textBox3.Text.Trim())))
					{
						string text = txtCCSaveName.Text.Replace('_', 'A').Replace('-', 'A');
						if (!string.IsNullOrEmpty(text) && Class34.smethod_3(text))
						{
							string value = "_CC";
							if (text.IndexOf(value, StringComparison.CurrentCultureIgnoreCase) < 0)
							{
								string value2 = "CC_";
								if (text.IndexOf(value2, StringComparison.CurrentCultureIgnoreCase) < 0)
								{
									string value3 = "_DC";
									if (text.IndexOf(value3, StringComparison.CurrentCultureIgnoreCase) < 0)
									{
										string value4 = "DC_";
										if (text.IndexOf(value4, StringComparison.CurrentCultureIgnoreCase) < 0)
										{
											string value5 = "_ICI";
											if (text.IndexOf(value5, StringComparison.CurrentCultureIgnoreCase) < 0)
											{
												string value6 = "_AXS";
												if (text.IndexOf(value6, StringComparison.CurrentCultureIgnoreCase) < 0)
												{
													string value7 = "_PTM";
													if (text.IndexOf(value7, StringComparison.CurrentCultureIgnoreCase) < 0)
													{
														if (cboCreditBank.SelectedIndex > 0)
														{
															if (cboCardType.SelectedIndex >= 0)
															{
																try
																{
																	string[] array = new string[15]
																	{
																		txtCreditNo.Text.Trim(),
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
																	string text2 = "||";
																	array[1] = text2;
																	array[2] = cboCreditMonth.SelectedItem.ToString();
																	string text3 = "||";
																	array[3] = text3;
																	array[4] = cboCreditYear.SelectedItem.ToString();
																	string text4 = "||";
																	array[5] = text4;
																	array[6] = txtCreditVisaPin.Text.Trim();
																	string text5 = "||";
																	array[7] = text5;
																	array[8] = txtCreditCVV.Text.Trim();
																	string text6 = "||";
																	array[9] = text6;
																	array[10] = cboCardType.SelectedItem.ToString();
																	string text7 = "||";
																	array[11] = text7;
																	array[12] = B8AAA.Text.Trim();
																	string text8 = "||";
																	array[13] = text8;
																	array[14] = textCredit3DPin.Text.Trim();
																	string text9 = string.Concat(array);
																	SQLiteConnection sQLiteConnection = new SQLiteConnection(Class34.string_Database);
																	sQLiteConnection.Open();
																	SQLiteCommand sQLiteCommand = new SQLiteCommand(sQLiteConnection);
																	string text10 = "SELECT count(RID) from TBL_BANK where BANK_SAVEAS = '";
																	string text11 = txtCCSaveName.Text.Trim();
																	string text12 = "' AND BANK_ISDEBIT = 1";
																	sQLiteCommand.CommandText = text10 + text11 + text12;
																	object obj = sQLiteCommand.ExecuteScalar();
																	int result = 0;
																	if (obj != null && obj.GetType() != typeof(DBNull))
																	{
																		int.TryParse(obj.ToString().Trim(), out result);
																	}
																	if (result > 0)
																	{
																		string text13 = "Credit Card Details already exists. Do you want to Update?\r\n\r\nIf you need to update existing details, Click 'YES', Otherwise you can Click 'NO'";
																		string caption = "Details Exists";
																		if (MessageBox.Show(text13, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
																		{
																			sQLiteConnection.Close();
																			sQLiteCommand.Dispose();
																			return;
																		}
																		string text14 = "DELETE from TBL_BANK where BANK_SAVEAS = '";
																		string text15 = txtCCSaveName.Text.Trim();
																		string text16 = "' AND BANK_ISDEBIT = 1";
																		sQLiteCommand.CommandText = text14 + text15 + text16;
																		sQLiteCommand.ExecuteNonQuery();
																		Program.dictionary_00.Remove(txtCCSaveName.Text.Trim());
																	}
																	Program.dictionary_00.Add(txtCCSaveName.Text.Trim(), text9);
																	string[] array2 = new string[7];
																	string text17 = "INSERT INTO TBL_BANK(BANK_NAME, BANK_SAVEAS, BANK_DETAILS, BANK_ISDEBIT) VALUES ('";
																	array2[0] = text17;
																	array2[1] = cboCreditBank.SelectedItem.ToString();
																	string text18 = "', '";
																	array2[2] = text18;
																	array2[3] = txtCCSaveName.Text.Trim();
																	string text19 = "', '";
																	array2[4] = text19;
																	array2[5] = text9;
																	string text20 = "', 1)";
																	array2[6] = text20;
																	sQLiteCommand.CommandText = string.Concat(array2);
																	sQLiteCommand.ExecuteNonQuery();
																	sQLiteConnection.Close();
																	sQLiteCommand.Dispose();
																	method_1();
																	bool_2 = true;
																	string text21 = "Credit Card Details Updated Successfully!";
																	string caption2 = "Bank Details";
																	MessageBox.Show(text21, caption2, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
																	return;
																}
																catch
																{
																	string text22 = "Error Occured while Saving Credit Card Details";
																	MessageBox.Show(text22);
																	return;
																}
															}
															string text23 = "Please Select Valid Card Type!";
															string caption3 = "Card Type";
															MessageBox.Show(text23, caption3, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
															txtCreditNo.Text = "";
															cboCardType.Focus();
														}
														else
														{
															string text24 = "Select Valid Bank Name";
															string caption4 = "Valid Card";
															MessageBox.Show(text24, caption4, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
															cboCreditBank.Focus();
														}
														return;
													}
												}
											}
										}
									}
								}
							}
							string text25 = "_CC, _ICI, _AXS, _PTM or _DC words are not allowed in name.";
							string caption5 = "Card Name";
							MessageBox.Show(text25, caption5, MessageBoxButtons.OK, MessageBoxIcon.Hand);
							txtCCSaveName.Focus();
						}
						else
						{
							string text26 = "Please enter valid CC Name to Save! (Only Alphabets, Numbers and (_) (-) are allowed)";
							string caption6 = "Card Name";
							MessageBox.Show(text26, caption6, MessageBoxButtons.OK, MessageBoxIcon.Hand);
							txtCCSaveName.Focus();
						}
					}
					else
					{
						string text27 = "Enter Valid CVV!";
						string caption7 = "Credit Card";
						MessageBox.Show(text27, caption7, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						textBox3.Focus();
					}
				}
				else
				{
					string text28 = "Select Valid Thru/Expiry Date!";
					string caption8 = "Credit Card";
					MessageBox.Show(text28, caption8, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					cboCreditMonth.Focus();
				}
			}
			else
			{
				string text29 = "Enter Valid Visa / Master Pin!";
				string caption9 = "Credit Card";
				MessageBox.Show(text29, caption9, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				textBox2.Focus();
			}
		}
		else
		{
			string text30 = "Enter Valid Card No.!";
			string caption10 = "Credit Card";
			MessageBox.Show(text30, caption10, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			textBox.Focus();
		}
	}

	private void btnCreditEdit_Click(object sender, EventArgs e)
	{
		if (lstCredit.SelectedIndex < 0)
		{
			string text = "Please select Card to Edit";
			string caption = "Edit Card";
			MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			return;
		}
		string text2 = lstCredit.SelectedItem.ToString();
		DataTable dataTable = new DataTable();
		string text3 = "SELECT BANK_NAME, BANK_DETAILS from TBL_BANK WHERE BANK_ISDEBIT = 1 AND BANK_SAVEAS = '";
		string text4 = "'";
		new SQLiteDataAdapter(text3 + text2 + text4, Class34.string_Database).Fill(dataTable);
		if (dataTable.Rows == null || dataTable.Rows.Count <= 0)
		{
			return;
		}
		dataTable.Rows[0][0].ToString();
		string value = "_CC";
		if (text2.Contains(value))
		{
			string value2 = "_VIR";
			if (!text2.Contains(value2))
			{
				cboCardType.SelectedIndex = 0;
			}
			else
			{
				cboCardType.SelectedIndex = 1;
			}
		}
		string value3 = "_CC";
		if (!text2.Contains(value3))
		{
			return;
		}
		string value4 = "_HDF_";
		if (text2.Contains(value4))
		{
			cboCreditGateway.SelectedIndex = 0;
		}
		else
		{
			string value5 = "_ICI_";
			if (text2.Contains(value5))
			{
				cboCreditGateway.SelectedIndex = 1;
			}
			else
			{
				string value6 = "_CIT_";
				if (!text2.Contains(value6))
				{
					cboCreditGateway.SelectedIndex = 3;
				}
				else
				{
					cboCreditGateway.SelectedIndex = 2;
				}
			}
		}
		string value7 = "_VIR";
		if (text2.Contains(value7))
		{
			cboCreditGateway.SelectedIndex = 0;
		}
		string value8 = "_";
		string text5 = text2.Substring(text2.IndexOf(value8) + 1).Trim();
		string value9 = "_";
		string selectedItem = text2.Substring(0, text2.IndexOf(value9)).Trim();
		string value10 = "__";
		if (text5.Contains(value10))
		{
			string value11 = "__";
			text5.Substring(0, text5.IndexOf(value11)).Trim();
			string value12 = "__";
			string text6 = text5.Substring(text5.IndexOf(value12) + 2).Trim();
			string value13 = "_";
			if (text6.Contains(value13))
			{
				string value14 = "_";
				text6.Substring(text6.IndexOf(value14) + 1).Trim();
			}
		}
		else
		{
			string value15 = "_";
			if (text5.Contains(value15))
			{
				string value16 = "_";
				text5.Substring(text5.IndexOf(value16) + 1).Trim();
			}
		}
		cboCreditBank.SelectedItem = selectedItem;
		string text7 = dataTable.Rows[0][1].ToString();
		string[] array = new string[1];
		string text8 = "||";
		array[0] = text8;
		string[] array2 = text7.Split(array, StringSplitOptions.RemoveEmptyEntries);
		try
		{
			txtCreditNo.Text = array2[0];
			cboCreditMonth.SelectedItem = array2[1];
			cboCreditYear.SelectedItem = array2[2];
			txtCreditVisaPin.Text = array2[3];
			txtCreditCVV.Text = array2[4];
			cboCardType.SelectedItem = array2[5];
			B8AAA.Text = array2[6];
			textCredit3DPin.Text = array2[7];
		}
		catch
		{
		}
		txtCCSaveName.Text = text2;
	}

	private void C4AA0_Click(object sender, EventArgs e)
	{
		if (lstCredit.SelectedIndex >= 0)
		{
			string text = lstCredit.SelectedItem.ToString();
			string text2 = "Do you really want to delete ";
			string text3 = text2 + text;
			string caption = "Delete";
			if (MessageBox.Show(text3, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
			{
				return;
			}
			string text4 = "DELETE from TBL_BANK where BANK_SAVEAS = '";
			string text5 = "' AND BANK_ISDEBIT = 1";
			Staticm.smethod_UpdateFieldValue(text4 + text + text5);
			Program.dictionary_00.Remove(text);
			string text6 = "Credit Card Details for ";
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
		method_1();
	}

	private void B4AAA_Click(object sender, EventArgs e)
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
		foreach (object item in lstCredit.Items)
		{
			string text2 = item.ToString();
			string text3 = "DELETE from TBL_BANK where BANK_SAVEAS = '";
			string text4 = "' AND BANK_ISDEBIT = 1";
			sQLiteCommand.CommandText = text3 + text2 + text4;
			sQLiteCommand.ExecuteNonQuery();
		}
		sQLiteConnection.Close();
		sQLiteCommand.Dispose();
		lstCredit.Items.Clear();
		string text5 = "All Credit Cards Details Deleted Successfully!";
		string caption2 = "Deleted";
		MessageBox.Show(text5, caption2, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
	}

	private void cboDebitGateway_SelectedIndexChanged(object sender, EventArgs e)
	{
		method_3();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		TextBox textBox = txtDebitNo;
		if (string.IsNullOrEmpty(textBox.Text) || textBox.Text.Length < 10 || !Class34.smethod_5(textBox.Text.Trim()))
		{
			string text = "Enter Valid Card No.!";
			string caption = "Debit Card";
			MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			textBox.Focus();
			return;
		}
		TextBox textBox2 = txtDebitVisaPin;
		if (!string.IsNullOrEmpty(textBox2.Text) && textBox2.Text.Length >= 4)
		{
			if (cboDebitMonth.SelectedIndex >= 0 && cboDebitYear.SelectedIndex >= 0)
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
				if (!string.IsNullOrEmpty(text3) && Class34.smethod_3(text3))
				{
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
													string text4 = "Select Valid Bank Name";
													string caption3 = "Valid Card";
													MessageBox.Show(text4, caption3, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
													cboDebitBank.Focus();
													return;
												}
												if (cboDebitCardType.SelectedIndex < 0)
												{
													string text5 = "Please Select Valid Card Type!";
													string caption4 = "Card Type";
													MessageBox.Show(text5, caption4, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
													txtDebitNo.Text = "";
													cboDebitCardType.Focus();
													return;
												}
												try
												{
													string[] array = new string[15]
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
														null
													};
													string text6 = "||";
													array[1] = text6;
													array[2] = cboDebitMonth.SelectedItem.ToString();
													string text7 = "||";
													array[3] = text7;
													array[4] = cboDebitYear.SelectedItem.ToString();
													string text8 = "||";
													array[5] = text8;
													array[6] = txtDebitVisaPin.Text.Trim();
													string text9 = "||";
													array[7] = text9;
													array[8] = txtDebitCVV.Text.Trim();
													string text10 = "||";
													array[9] = text10;
													array[10] = cboDebitCardType.SelectedItem.ToString();
													string text11 = "||";
													array[11] = text11;
													array[12] = txtDebitHolderName.Text.Trim();
													string text12 = "||";
													array[13] = text12;
													array[14] = textDebit3DPin.Text.Trim();
													string text13 = string.Concat(array);
													SQLiteConnection sQLiteConnection = new SQLiteConnection(Class34.string_Database);
													sQLiteConnection.Open();
													SQLiteCommand sQLiteCommand = new SQLiteCommand(sQLiteConnection);
													string text14 = "SELECT count(RID) from TBL_BANK where BANK_SAVEAS = '";
													string text15 = txtDCSaveName.Text.Trim();
													string text16 = "' AND BANK_ISDEBIT = 1";
													sQLiteCommand.CommandText = text14 + text15 + text16;
													object obj = sQLiteCommand.ExecuteScalar();
													int result = 0;
													if (obj != null && obj.GetType() != typeof(DBNull))
													{
														int.TryParse(obj.ToString().Trim(), out result);
													}
													if (result > 0)
													{
														string text17 = "Debit Card Details already exists. Do you want to Update?\r\n\r\nIf you need to update existing details, Click 'YES', Otherwise you can Click 'NO'";
														string caption5 = "Details Exists";
														if (MessageBox.Show(text17, caption5, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
														{
															sQLiteConnection.Close();
															sQLiteCommand.Dispose();
															return;
														}
														string text18 = "DELETE from TBL_BANK where BANK_SAVEAS = '";
														string text19 = txtDCSaveName.Text.Trim();
														string text20 = "' AND BANK_ISDEBIT = 1";
														sQLiteCommand.CommandText = text18 + text19 + text20;
														sQLiteCommand.ExecuteNonQuery();
														Program.dictionary_00.Remove(txtDCSaveName.Text.Trim());
													}
													Program.dictionary_00.Add(txtDCSaveName.Text.Trim(), text13);
													string[] array2 = new string[7];
													string text21 = "INSERT INTO TBL_BANK(BANK_NAME, BANK_SAVEAS, BANK_DETAILS, BANK_ISDEBIT) VALUES ('";
													array2[0] = text21;
													array2[1] = cboDebitBank.SelectedItem.ToString();
													string text22 = "', '";
													array2[2] = text22;
													array2[3] = txtDCSaveName.Text.Trim();
													string text23 = "', '";
													array2[4] = text23;
													array2[5] = text13;
													string text24 = "', 1)";
													array2[6] = text24;
													sQLiteCommand.CommandText = string.Concat(array2);
													sQLiteCommand.ExecuteNonQuery();
													sQLiteConnection.Close();
													sQLiteCommand.Dispose();
													method_2();
													bool_1 = true;
													string text25 = "Debit Card Details Updated Successfully!";
													string caption6 = "Bank Details";
													MessageBox.Show(text25, caption6, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
													return;
												}
												catch
												{
													string text26 = "Error Occured while Saving Debit Card Details";
													MessageBox.Show(text26);
													return;
												}
											}
										}
									}
								}
							}
						}
					}
					string text27 = "_CC, _ICI, _AXS, _PTM or _DC words are not allowed in name.";
					string caption7 = "Card Name";
					MessageBox.Show(text27, caption7, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					txtDCSaveName.Focus();
				}
				else
				{
					string text28 = "Please enter valid CC Name to Save! (Only Alphabets, Numbers and (_) (-) are allowed)";
					string caption8 = "Card Name";
					MessageBox.Show(text28, caption8, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					txtDCSaveName.Focus();
				}
			}
			else
			{
				string text29 = "Select Valid Thru/Expiry Date!";
				string caption9 = "Debit Card";
				MessageBox.Show(text29, caption9, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				cboDebitMonth.Focus();
			}
		}
		else
		{
			string text30 = "Enter Valid Visa / Master Pin!";
			string caption10 = "Debit Card";
			MessageBox.Show(text30, caption10, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			textBox2.Focus();
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
		if (dataTable.Rows == null || dataTable.Rows.Count <= 0)
		{
			return;
		}
		dataTable.Rows[0][0].ToString();
		string value = "_DC";
		if (!text2.Contains(value))
		{
			return;
		}
		string value2 = "_IRC_";
		if (!text2.Contains(value2))
		{
			string value3 = "_PTM_";
			if (text2.Contains(value3))
			{
				cboDebitGateway.SelectedIndex = 1;
			}
		}
		else
		{
			cboDebitGateway.SelectedIndex = 0;
		}
		string value4 = "_";
		string text5 = text2.Substring(text2.IndexOf(value4) + 1).Trim();
		string value5 = "_";
		string selectedItem = text2.Substring(0, text2.IndexOf(value5)).Trim();
		string value6 = "__";
		if (text5.Contains(value6))
		{
			string value7 = "__";
			text5.Substring(0, text5.IndexOf(value7)).Trim();
			string value8 = "__";
			string text6 = text5.Substring(text5.IndexOf(value8) + 2).Trim();
			string value9 = "_";
			if (text6.Contains(value9))
			{
				string value10 = "_";
				text6.Substring(text6.IndexOf(value10) + 1).Trim();
			}
		}
		else
		{
			string value11 = "_";
			if (text5.Contains(value11))
			{
				string value12 = "_";
				text5.Substring(text5.IndexOf(value12) + 1).Trim();
			}
		}
		cboDebitBank.SelectedItem = selectedItem;
		cboDebitCardType.SelectedIndex = 0;
		string text7 = dataTable.Rows[0][1].ToString();
		string[] array = new string[1];
		string text8 = "||";
		array[0] = text8;
		string[] array2 = text7.Split(array, StringSplitOptions.RemoveEmptyEntries);
		try
		{
			txtDebitNo.Text = array2[0];
			cboDebitMonth.SelectedItem = array2[1];
			cboDebitYear.SelectedItem = array2[2];
			txtDebitVisaPin.Text = array2[3];
			txtDebitCVV.Text = array2[4];
			cboDebitCardType.SelectedItem = array2[5];
			txtDebitHolderName.Text = array2[6];
			textDebit3DPin.Text = array2[7];
		}
		catch
		{
		}
		txtDCSaveName.Text = text2;
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
		method_2();
	}

	private void btnDebitDeleteAll_Click(object sender, EventArgs e)
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

	private void method_7()
	{
		txtUserName.Text = "";
		txtTxnPassword.Text = "";
		txtLoginPassword.Text = "";
		txtOTP.Text = "";
		txtNBSaveName.Text = "";
		cboGateway0.SelectedIndex = 0;
		B0AAA();
	}

	private void B0AAA()
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
		C0AA0();
	}

	private void C0AA0()
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
		if (!Program.dictionary_2.TryGetValue(comboBox_0.SelectedItem.ToString(), out var value))
		{
			return;
		}
		lblOTP.Visible = false;
		txtOTP.Visible = false;
		string text = value;
		string[] array = new string[1];
		string text2 = "|";
		array[0] = text2;
		string[] array2 = text.Split(array, StringSplitOptions.RemoveEmptyEntries);
		Label label = lblUserName;
		string text3 = array2[0];
		string text4 = " : ";
		label.Text = text3 + text4;
		Label c6AA = C6AA0;
		string text5 = array2[1];
		string text6 = " : ";
		c6AA.Text = text5 + text6;
		if (array2.Length > 2)
		{
			Label b6AAA = B6AAA;
			string text7 = array2[2];
			string text8 = " : ";
			b6AAA.Text = text7 + text8;
			B6AAA.Visible = true;
			txtTxnPassword.Visible = true;
			if (array2.Length > 3)
			{
				Label label2 = lblOTP;
				string text9 = array2[3];
				string text10 = " : ";
				label2.Text = text9 + text10;
				lblOTP.Visible = true;
				txtOTP.Visible = true;
			}
		}
		else
		{
			B6AAA.Visible = false;
			txtTxnPassword.Visible = false;
		}
	}

	private void btnNBSave_Click(object sender, EventArgs e)
	{
		TextBox textBox = txtUserName;
		if (!string.IsNullOrEmpty(textBox.Text) && textBox.Text.Length >= 3)
		{
			TextBox textBox2 = txtLoginPassword;
			if (string.IsNullOrEmpty(textBox2.Text) || textBox2.Text.Length < 3)
			{
				string text = "Enter Valid Password!";
				string caption = "Net Banking";
				MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				textBox2.Focus();
				return;
			}
			TextBox textBox3 = txtTxnPassword;
			if (textBox3.Visible && (string.IsNullOrEmpty(textBox3.Text) || textBox3.Text.Length < 5))
			{
				string text2 = "Enter Valid ";
				string text3 = B6AAA.Text;
				string text4 = "!";
				string text5 = text2 + text3 + text4;
				string caption2 = "Net Banking";
				MessageBox.Show(text5, caption2, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				textBox3.Focus();
				return;
			}
			TextBox textBox4 = txtOTP;
			if (textBox4.Visible && (string.IsNullOrEmpty(textBox4.Text) || textBox4.Text.Length < 3))
			{
				string text6 = "Enter Valid ";
				string text7 = lblOTP.Text;
				string text8 = "!";
				string text9 = text6 + text7 + text8;
				string caption3 = "Net Banking";
				MessageBox.Show(text9, caption3, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				textBox4.Focus();
			}
			else if (comboBox_0.SelectedIndex > 0)
			{
				string text10 = txtNBSaveName.Text.Replace('_', 'A').Replace('-', 'A').Replace('@', 'A')
					.Replace('.', 'A');
				if (string.IsNullOrEmpty(text10) || !Class34.smethod_3(text10))
				{
					string text11 = "Please enter valid Bank Name to Save! (Only Alphabets, Numbers and (_) (-) are allowed)";
					string caption4 = "NetBanking Name";
					MessageBox.Show(text11, caption4, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					txtNBSaveName.Focus();
					return;
				}
				string value = "_CC";
				if (text10.IndexOf(value, StringComparison.CurrentCultureIgnoreCase) < 0)
				{
					string value2 = "CC_";
					if (text10.IndexOf(value2, StringComparison.CurrentCultureIgnoreCase) < 0)
					{
						string value3 = "_DC";
						if (text10.IndexOf(value3, StringComparison.CurrentCultureIgnoreCase) < 0)
						{
							string value4 = "DC_";
							if (text10.IndexOf(value4, StringComparison.CurrentCultureIgnoreCase) < 0)
							{
								try
								{
									string text12 = txtUserName.Text;
									string text13 = "||";
									string text14 = text12 + text13 + txtLoginPassword.Text;
									if (txtTxnPassword.Visible)
									{
										string text15 = text14;
										string text16 = "||";
										text14 = text15 + text16 + txtTxnPassword.Text;
									}
									if (txtOTP.Visible)
									{
										string text17 = text14;
										string text18 = "||";
										text14 = text17 + text18 + txtOTP.Text;
									}
									SQLiteConnection sQLiteConnection = new SQLiteConnection(Class34.string_Database);
									sQLiteConnection.Open();
									SQLiteCommand sQLiteCommand = new SQLiteCommand(sQLiteConnection);
									string text19 = "SELECT count(RID) from TBL_BANK where BANK_SAVEAS = '";
									string text20 = txtNBSaveName.Text.Trim();
									string text21 = "' AND BANK_ISDEBIT = 0";
									sQLiteCommand.CommandText = text19 + text20 + text21;
									object obj = sQLiteCommand.ExecuteScalar();
									int result = 0;
									if (obj != null && obj.GetType() != typeof(DBNull))
									{
										int.TryParse(obj.ToString().Trim(), out result);
									}
									if (result > 0)
									{
										string text22 = "Bank Details already exists for mentioned User Name. Do you want to Update?\r\n\r\nIf you need to update existing details, Click 'YES', Otherwise you can Click 'NO'";
										string caption5 = "Details Exists";
										if (MessageBox.Show(text22, caption5, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
										{
											sQLiteConnection.Close();
											sQLiteCommand.Dispose();
											return;
										}
										string text23 = "DELETE from TBL_BANK where BANK_SAVEAS = '";
										string text24 = txtNBSaveName.Text.Trim();
										string text25 = "' AND BANK_ISDEBIT = 0";
										sQLiteCommand.CommandText = text23 + text24 + text25;
										Program.dictionary_00.Remove(txtNBSaveName.Text.Trim());
										sQLiteCommand.ExecuteNonQuery();
									}
									if (string_0 != "")
									{
										text14 += string_0;
										Program.dictionary_00.Remove(txtNBSaveName.Text.Trim());
									}
									Program.dictionary_00.Add(txtNBSaveName.Text.Trim(), text14);
									string[] array = new string[7];
									string text26 = "INSERT INTO TBL_BANK(BANK_NAME, BANK_SAVEAS, BANK_DETAILS, BANK_ISDEBIT) VALUES ('";
									array[0] = text26;
									array[1] = comboBox_0.SelectedItem.ToString();
									string text27 = "', '";
									array[2] = text27;
									array[3] = txtNBSaveName.Text.Trim();
									string text28 = "', '";
									array[4] = text28;
									array[5] = text14;
									string text29 = "', 0)";
									array[6] = text29;
									sQLiteCommand.CommandText = string.Concat(array);
									sQLiteCommand.ExecuteNonQuery();
									sQLiteConnection.Close();
									sQLiteCommand.Dispose();
									method_7();
									bool_0 = true;
									string text30 = "Net-Banking Details Updated Successfully!";
									string caption6 = "Bank Details";
									MessageBox.Show(text30, caption6, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
									return;
								}
								catch
								{
									string text31 = "Error Occured while Saving Bank Details";
									MessageBox.Show(text31);
									return;
								}
							}
						}
					}
				}
				string text32 = "_CC or _Debit words are not allowed in name.";
				string caption7 = "NetBanking Name";
				MessageBox.Show(text32, caption7, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				txtNBSaveName.Focus();
			}
			else
			{
				string text33 = "Select Valid Bank Name";
				string caption8 = "Net Banking";
				MessageBox.Show(text33, caption8, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				comboBox_0.Focus();
			}
		}
		else
		{
			string text34 = "Enter Valid User Name!";
			string caption9 = "Net Banking";
			MessageBox.Show(text34, caption9, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
		TextBox textBox = txtNBSaveName;
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
				TextBox textBox = txtNBSaveName;
				string value2 = "_";
				textBox.Text = text5.Substring(text5.IndexOf(value2) + 1);
				txtNBSaveName.Text = text5;
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

	private void btnNBDelete_Click(object sender, EventArgs e)
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
			method_7();
			Program.dictionary_00.Remove(text2);
			string text7 = "Net-Banking Details for ";
			string text8 = " Deleted Successfully!";
			string text9 = text7 + text2 + text8;
			string caption3 = "Deleted";
			MessageBox.Show(text9, caption3, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
	}

	private void btnNBDeleteAll_Click(object sender, EventArgs e)
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
		B0AAA();
	}

	private void btnIDSave_Click(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(txtLogin.Text) && !string.IsNullOrEmpty(txtPassword.Text))
		{
			if (Program.dictionary_0.ContainsKey(txtLogin.Text.Trim()))
			{
				string text = "User already exist!";
				MessageBox.Show(text);
				return;
			}
			bool flag;
			if (chkValidate.Checked)
			{
				Cursor = Cursors.WaitCursor;
				flag = true;
				Cursor = Cursors.Default;
			}
			else
			{
				flag = true;
			}
			if (flag)
			{
				DataRow dataRow = dataTable_0.NewRow();
				dataRow[0] = txtLogin.Text.Trim();
				dataRow[1] = txtPassword.Text.Trim();
				string value = "0";
				dataRow[2] = value;
				string value2 = "Check";
				dataRow[3] = value2;
				string value3 = "Active";
				dataRow[4] = value3;
				string value4 = "Delete";
				dataRow[5] = value4;
				string value5 = "View";
				dataRow[6] = value5;
				dataTable_0.Rows.Add(dataRow);
				dataTable_0.AcceptChanges();
				Program.dictionary_0.Add(txtLogin.Text.Trim(), txtPassword.Text.Trim());
				Program.dictionary_01.Add(txtLogin.Text.Trim(), txtPassword.Text.Trim());
				try
				{
					SQLiteConnection sQLiteConnection = new SQLiteConnection(Class34.string_Database);
					SQLiteCommand sQLiteCommand = new SQLiteCommand();
					sQLiteConnection.Open();
					sQLiteCommand.Connection = sQLiteConnection;
					string[] array = new string[5];
					string text2 = "INSERT INTO [TBL_USER]([UserName],[strPwd],[UserState]) VALUES('";
					array[0] = text2;
					array[1] = dataRow[0].ToString();
					string text3 = "', '";
					array[2] = text3;
					array[3] = dataRow[1].ToString();
					string text4 = "', 'Active||')";
					array[4] = text4;
					sQLiteCommand.CommandText = string.Concat(array);
					sQLiteCommand.ExecuteNonQuery();
					sQLiteConnection.Close();
					sQLiteCommand.Dispose();
					C3AA0 = true;
				}
				catch (Exception)
				{
				}
			}
		}
		else
		{
			string text5 = "Invalid User ID or Password. Please try again.";
			string caption = "Invalid Credentials";
			MessageBox.Show(text5, caption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		txtLogin.Focus();
	}

	private void method_8()
	{
		txtPassword.PasswordChar = ((!chkShowPwd.Checked) ? '*' : '\0');
		txtLogin.Focus();
		base.WindowState = FormWindowState.Normal;
		ToolTip toolTip = toolTip_0;
		TextBox control = txtLogin;
		string caption = "Type your IRCTC login name here.";
		toolTip.SetToolTip(control, caption);
		ToolTip toolTip2 = toolTip_0;
		TextBox control2 = txtLoginPassword;
		string caption2 = "Type your IRCTC login password here.";
		toolTip2.SetToolTip(control2, caption2);
		ToolTip toolTip3 = toolTip_0;
		string text = "Don't use this option between 8:00AM to 10:10AM, otherwise leave this option checked.";
		toolTip3.Show(text, chkValidate, 2000, chkValidate.Location.X, chkValidate.Location.Y);
		string query = "SELECT * FROM [TBL_USER]";
		method_IrctcId2(query, "");
	}

	internal void method_IrctcId2(string Query, string His)
	{
		string tableName = "tbl_Ir_Users";
		dataTable_0 = new DataTable(tableName);
		DataColumnCollection columns = dataTable_0.Columns;
		string columnName = "userid";
		columns.Add(new DataColumn(columnName));
		DataColumnCollection columns2 = dataTable_0.Columns;
		string columnName2 = "Pwd";
		columns2.Add(new DataColumn(columnName2));
		DataColumnCollection columns3 = dataTable_0.Columns;
		string columnName3 = "currtotal";
		columns3.Add(new DataColumn(columnName3));
		DataColumnCollection columns4 = dataTable_0.Columns;
		string columnName4 = "sync";
		columns4.Add(new DataColumn(columnName4));
		DataColumnCollection columns5 = dataTable_0.Columns;
		string columnName5 = "state";
		columns5.Add(new DataColumn(columnName5));
		DataColumnCollection columns6 = dataTable_0.Columns;
		string columnName6 = "delete";
		columns6.Add(new DataColumn(columnName6));
		DataColumnCollection columns7 = dataTable_0.Columns;
		string columnName7 = "history";
		columns7.Add(new DataColumn(columnName7));
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		using (SQLiteConnection sQLiteConnection = new SQLiteConnection(Class34.string_Database))
		{
			try
			{
				SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter(Query, Class34.string_Database);
				DataTable dataTable = new DataTable();
				sQLiteDataAdapter.Fill(dataTable);
				if (dataTable != null && dataTable.Rows.Count > 0)
				{
					sQLiteConnection.Open();
					SQLiteCommand sQLiteCommand = new SQLiteCommand();
					sQLiteCommand.Connection = sQLiteConnection;
					foreach (DataRow row in dataTable.Rows)
					{
						DataRow dataRow2 = dataTable_0.NewRow();
						dataRow2[0] = row[1];
						dataRow2[1] = row[2];
						string value = "Check";
						dataRow2[2] = value;
						try
						{
							int num5 = 0;
							string columnName8 = "History";
							string[] array = row[columnName8].ToString().Split(new char[1] { '#' }, StringSplitOptions.RemoveEmptyEntries);
							dataRow2[2] = array.Length.ToString();
							for (int i = 0; i < array.Length; i++)
							{
								if (!(His != ""))
								{
									string[] array2 = array[i].Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries);
									string text = array2[0];
									string text2 = array2[0];
									string value2 = "T";
									string s = text.Substring(0, text2.IndexOf(value2));
									string format = "yyyy-MM-dd";
									double totalDays = (DateTime.ParseExact(s, format, CultureInfo.InvariantCulture) - DateTime.Now.Date).TotalDays;
									if (totalDays == 0.0)
									{
										num++;
									}
									if (totalDays > 0.0)
									{
										num2++;
									}
									string text3 = array2[1];
									string text4 = array2[1];
									string value3 = "T";
									string s2 = text3.Substring(0, text4.IndexOf(value3));
									string format2 = "yyyy-MM-dd";
									if ((DateTime.ParseExact(s2, format2, CultureInfo.InvariantCulture) - DateTime.Now.Date).TotalDays == 0.0)
									{
										num3++;
									}
									string format3 = "yyyy-MM-dd";
									DateTime dateTime = DateTime.ParseExact(s2, format3, CultureInfo.InvariantCulture);
									if (DateTime.Now.Date.Month == dateTime.Month)
									{
										num4++;
									}
									continue;
								}
								if (array[i].Contains(His))
								{
									num5++;
									string value4 = "-";
									if (His.Contains(value4))
									{
										string value5 = "T";
										if (!His.Contains(value5))
										{
											string text5 = array[i];
											string text6 = "T00:00:00";
											if (text5.Contains(His + text6))
											{
												num5--;
											}
										}
									}
								}
								dataRow2[2] = num5.ToString();
							}
						}
						catch
						{
						}
						try
						{
							if (His == "")
							{
								string[] array3 = new string[5];
								string text7 = "SELECT COUNT(RID) FROM TBL_HISTORY WHERE IRCTC_ID = '";
								array3[0] = text7;
								array3[1] = row[0]?.ToString();
								string text8 = "' and length(PNR) > 5 and strftime('%m', Create_Date) = '";
								array3[2] = text8;
								int month = DateTime.Now.Month;
								string text9 = "00";
								array3[3] = month.ToString(text9);
								string text10 = "'";
								array3[4] = text10;
								sQLiteCommand.CommandText = string.Concat(array3);
							}
						}
						catch
						{
						}
						string value6 = "Check";
						dataRow2[3] = value6;
						string columnName9 = "UserState";
						dataRow2[4] = row[columnName9].ToString();
						string value7 = "Delete";
						dataRow2[5] = value7;
						string value8 = "View";
						dataRow2[6] = value8;
						Dictionary<string, string> dictionary_ = Program.dictionary_0;
						string columnName10 = "userid";
						if (!dictionary_.ContainsKey(dataRow2[columnName10].ToString()))
						{
							string columnName11 = "state";
							string text11 = dataRow2[columnName11].ToString();
							string value9 = "Active";
							if (text11.Contains(value9))
							{
								Dictionary<string, string> dictionary_2 = Program.dictionary_0;
								string columnName12 = "userid";
								string key = dataRow2[columnName12].ToString();
								string columnName13 = "Pwd";
								dictionary_2.Add(key, dataRow2[columnName13].ToString());
							}
						}
						if (!chkShowPwd.Checked)
						{
							string value10 = "**********";
							dataRow2[1] = value10;
						}
						dataTable_0.Rows.Add(dataRow2);
					}
					sQLiteConnection.Close();
					C7AA0.Text = dataTable.Rows.Count.ToString();
					lblActive.Text = Program.dictionary_0.Count.ToString();
					lbl6.Text = num.ToString();
					lbl7.Text = num2.ToString();
					lblTobk.Text = num3.ToString();
					lblCurMonbk.Text = num4.ToString();
				}
			}
			catch
			{
			}
		}
		dataTable_0.AcceptChanges();
		grdUsers.DataSource = dataTable_0;
	}

	private void grdUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
		int rowIndex = e.RowIndex;
		int columnIndex = e.ColumnIndex;
		DataRow dataRow = dataTable_0.Rows[rowIndex];
		string columnName = "userid";
		string text = dataRow[columnName].ToString();
		DataRow dataRow2 = dataTable_0.Rows[rowIndex];
		string columnName2 = "pwd";
		string text2 = dataRow2[columnName2].ToString();
		try
		{
			text2 = Program.dictionary_01[text];
		}
		catch
		{
			DataRow dataRow3 = dataTable_0.Rows[rowIndex];
			string columnName3 = "state";
			string text3 = dataRow3[columnName3].ToString();
			string value = "Invalid";
			if (text3.Contains(value))
			{
				string text4 = "The Selected User Id Is Deactivated";
				MessageBox.Show(text4);
			}
		}
		switch (columnIndex)
		{
		case 0:
		case 1:
			switch (columnIndex)
			{
			case 1:
			{
				DataRow dataRow6 = dataTable_0.Rows[rowIndex];
				string columnName6 = "pwd";
				text = dataRow6[columnName6].ToString();
				break;
			}
			case 0:
			{
				DataRow dataRow5 = dataTable_0.Rows[rowIndex];
				string columnName5 = "userid";
				text = dataRow5[columnName5].ToString();
				break;
			}
			}
			Clipboard.SetText(text);
			break;
		case 3:
		{
			string text20 = "ProfileHistory";
			string errMessage = text20;
			pictureBox1.Visible = true;
			Application.DoEvents();
			Thread.Sleep(500);
			try
			{
				string[] array = Program.mcommInstance_.isLV(text.Trim(), text2.Trim(), ref errMessage).Split('#');
				DataRow dataRow10 = dataTable_0.Rows[rowIndex];
				string columnName10 = "currtotal";
				dataRow10[columnName10] = array[1];
			}
			catch
			{
			}
			pictureBox1.Visible = false;
			method_8();
			break;
		}
		case 4:
		{
			DataRow dataRow7 = dataTable_0.Rows[rowIndex];
			string columnName7 = "state";
			string text12 = dataRow7[columnName7].ToString();
			string text13 = "Active||";
			string query;
			if (text12 == text13)
			{
				Program.dictionary_0.Remove(text);
				DataRow dataRow8 = dataTable_0.Rows[rowIndex];
				string columnName8 = "state";
				string value2 = "Deactive||";
				dataRow8[columnName8] = value2;
				string text14 = "UPDATE [TBL_USER] SET [UserState]='Deactive||' where UserName LIKE '";
				string text15 = text;
				string text16 = "'";
				query = text14 + text15 + text16;
			}
			else
			{
				if (!Program.dictionary_0.ContainsKey(text))
				{
					Program.dictionary_0.Add(text, text2);
				}
				DataRow dataRow9 = dataTable_0.Rows[rowIndex];
				string columnName9 = "state";
				string value3 = "Active||";
				dataRow9[columnName9] = value3;
				string text17 = "UPDATE [TBL_USER] SET [UserState]='Active||' where UserName LIKE '";
				string text18 = text;
				string text19 = "'";
				query = text17 + text18 + text19;
			}
			Staticm.smethod_UpdateFieldValue(query);
			break;
		}
		case 5:
		{
			string text8 = "Do you really want to delete user?";
			string caption = "Confirm";
			if (MessageBox.Show(text8, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Dictionary<string, string> dictionary_ = Program.dictionary_0;
				DataRow dataRow4 = dataTable_0.Rows[rowIndex];
				string columnName4 = "userid";
				dictionary_.Remove(dataRow4[columnName4].ToString());
				string text9 = "DELETE FROM [TBL_USER] WHERE [UserName] = '";
				string text10 = text;
				string text11 = "'";
				Staticm.smethod_UpdateFieldValue(text9 + text10 + text11);
				dataTable_0.Rows.RemoveAt(rowIndex);
			}
			break;
		}
		case 6:
		{
			string text5 = "SELECT * FROM [TBL_USER] WHERE [UserName] = '";
			string text6 = text;
			string text7 = "'";
			method_IrctcId3(text5 + text6 + text7);
			break;
		}
		}
		dataTable_0.AcceptChanges();
	}

	internal void method_IrctcId3(string Query)
	{
		string tableName = "Tbl_Trans";
		dataTable_1 = new DataTable(tableName);
		DataColumnCollection columns = dataTable_1.Columns;
		string columnName = "S.NO";
		columns.Add(new DataColumn(columnName));
		DataColumnCollection columns2 = dataTable_1.Columns;
		string columnName2 = "PNR";
		columns2.Add(new DataColumn(columnName2));
		DataColumnCollection columns3 = dataTable_1.Columns;
		string columnName3 = "From";
		columns3.Add(new DataColumn(columnName3));
		DataColumnCollection columns4 = dataTable_1.Columns;
		string columnName4 = "To";
		columns4.Add(new DataColumn(columnName4));
		DataColumnCollection columns5 = dataTable_1.Columns;
		string columnName5 = "Train";
		columns5.Add(new DataColumn(columnName5));
		DataColumnCollection columns6 = dataTable_1.Columns;
		string columnName6 = "Journey Date";
		columns6.Add(new DataColumn(columnName6));
		DataColumnCollection columns7 = dataTable_1.Columns;
		string columnName7 = "Booking Date";
		columns7.Add(new DataColumn(columnName7));
		DataColumnCollection columns8 = dataTable_1.Columns;
		string columnName8 = "Print";
		columns8.Add(new DataColumn(columnName8));
		DataColumnCollection columns9 = dataTable_1.Columns;
		string columnName9 = "SMS";
		columns9.Add(new DataColumn(columnName9));
		string text = "";
		string text2 = "";
		DataTable dataTable = new DataTable();
		new SQLiteDataAdapter(Query, Class34.string_Database).Fill(dataTable);
		if (dataTable != null && dataTable.Rows.Count > 0)
		{
			foreach (DataRow row in dataTable.Rows)
			{
				string columnName10 = "UserName";
				text2 = row[columnName10].ToString();
				string columnName11 = "History";
				text = row[columnName11].ToString();
			}
		}
		Label label = label16;
		string text3 = "User ID :- ";
		label.Text = text3 + text2;
		string[] array = text.Split(new char[1] { '#' }, StringSplitOptions.RemoveEmptyEntries);
		int num = 0;
		Label label2 = label38;
		string text4 = "Total Ticket :-";
		label2.Text = text4 + array.Length;
		for (int i = 0; i < array.Length; i++)
		{
			try
			{
				string[] array2 = array[i].Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries);
				DataRow dataRow2 = dataTable_1.NewRow();
				dataRow2[0] = i + 1;
				dataRow2[1] = array2[4];
				dataRow2[2] = array2[3];
				dataRow2[3] = array2[2];
				dataRow2[4] = array2[5];
				dataRow2[5] = array2[0];
				dataRow2[6] = array2[1];
				string value = "Print";
				dataRow2[7] = value;
				string value2 = "Get SMS";
				dataRow2[8] = value2;
				dataTable_1.Rows.Add(dataRow2);
				string text5 = array2[0];
				string value3 = "T";
				string s = text5.Substring(0, text5.IndexOf(value3));
				string format = "yyyy-MM-dd";
				if ((DateTime.ParseExact(s, format, CultureInfo.InvariantCulture) - DateTime.Now.Date).TotalDays >= 0.0)
				{
					num++;
				}
			}
			catch
			{
			}
		}
		Label label3 = label44;
		string text6 = "Upcoming :- ";
		label3.Text = text6 + num;
		dataTable_1.AcceptChanges();
		dgv.DataSource = dataTable_1;
	}

	private void B1AAA(object sender, FormClosingEventArgs e)
	{
	}

	private void C1AA0(object sender, EventArgs e)
	{
		pictureBox1.Visible = true;
		lblMsg.Visible = true;
		Application.DoEvents();
		Thread.Sleep(300);
		try
		{
			DataTable dataTable = new DataTable();
			string commandText = "SELECT * FROM TBL_USER WHERE UserState LIKE 'Active||%'";
			new SQLiteDataAdapter(commandText, Class34.string_Database).Fill(dataTable);
			int num = 0;
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				foreach (DataRow row in dataTable.Rows)
				{
					num++;
					Label label = lblMsg;
					string text = "Updating Id: ";
					label.Text = text + num;
					Application.DoEvents();
					Thread.Sleep(200);
					string columnName = "UserName";
					string userID = row[columnName].ToString();
					string columnName2 = "strPwd";
					string pwd = row[columnName2].ToString();
					string text2 = "ProfileHistory";
					string errMessage = text2;
					Program.mcommInstance_.isLV(userID, pwd, ref errMessage);
				}
			}
		}
		catch
		{
		}
		pictureBox1.Visible = false;
		lblMsg.Visible = false;
		method_8();
	}

	private void chkShowPwd_CheckedChanged(object sender, EventArgs e)
	{
		method_8();
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

	private void checkBox2_CheckedChanged(object sender, EventArgs e)
	{
		if (checkBox2.Checked)
		{
			txtDebitVisaPin.PasswordChar = '\0';
			txtDebitCVV.PasswordChar = '\0';
			textDebit3DPin.PasswordChar = '\0';
		}
		else
		{
			txtDebitVisaPin.PasswordChar = '*';
			txtDebitCVV.PasswordChar = '*';
			textDebit3DPin.PasswordChar = '*';
		}
	}

	private void checkBox3_CheckedChanged(object sender, EventArgs e)
	{
		if (checkBox3.Checked)
		{
			txtCreditVisaPin.PasswordChar = '\0';
			txtCreditCVV.PasswordChar = '\0';
			textCredit3DPin.PasswordChar = '\0';
		}
		else
		{
			txtCreditVisaPin.PasswordChar = '*';
			txtCreditCVV.PasswordChar = '*';
			textCredit3DPin.PasswordChar = '*';
		}
	}

	private void BCAAA_SelectedIndexChanged(object sender, EventArgs e)
	{
		method_4();
	}

	private void button2_Click(object sender, EventArgs e)
	{
		if (RadioBdate.Checked)
		{
			DateTime value = dtDate1.Value;
			string text = "yyyy-MM-dd";
			string text2 = value.ToString(text);
			string text3 = "SELECT * FROM [TBL_USER] Where History LIKE '%";
			string text4 = "T00:00:00%'";
			string query = text3 + text2 + text4;
			string text5 = "T00:00:00";
			method_IrctcId2(query, text2 + text5);
		}
		if (RadioJdate.Checked)
		{
			DateTime value2 = dtDate2.Value;
			string text6 = "yyyy-MM-dd";
			string text7 = value2.ToString(text6);
			string text8 = "SELECT * FROM [TBL_USER] Where History LIKE '%";
			string text9 = "%'";
			method_IrctcId2(text8 + text7 + text9, text7);
		}
		if (RadioPnr.Checked)
		{
			string text10 = "SELECT * FROM [TBL_USER] Where History LIKE '%";
			string text11 = txtPnr.Text;
			string text12 = "%'";
			string query2 = text10 + text11 + text12;
			string his = "1";
			method_IrctcId2(query2, his);
		}
	}

	private void button3_Click(object sender, EventArgs e)
	{
		dtDate1.Enabled = false;
		dtDate2.Enabled = false;
		txtPnr.Enabled = false;
		method_8();
	}

	private void CCAA0_Click(object sender, EventArgs e)
	{
		pictureBox1.Visible = true;
		lblMsg.Visible = true;
		Application.DoEvents();
		Thread.Sleep(300);
		try
		{
			DataTable dataTable = new DataTable();
			string commandText = "SELECT * FROM TBL_USER WHERE UserState LIKE 'Active||%'";
			new SQLiteDataAdapter(commandText, Class34.string_Database).Fill(dataTable);
			int num = 0;
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				foreach (DataRow row in dataTable.Rows)
				{
					num++;
					Label label = lblMsg;
					string text = "Updating Id: ";
					label.Text = text + num;
					Application.DoEvents();
					Thread.Sleep(200);
					string columnName = "UserName";
					string userID = row[columnName].ToString();
					string columnName2 = "strPwd";
					string pwd = row[columnName2].ToString();
					string prompt = "Enter Your Specific Password";
					string text2 = Interaction.InputBox(prompt);
					if (text2.Length >= 8)
					{
						string text3 = "Password:";
						string errMessage = text3 + text2;
						if (!bool.Parse(Program.mcommInstance_.isLV(userID, pwd, ref errMessage)))
						{
							string text4 = "Please Enter Atleast 1 Lower, 1 Upper, 1 Numeric";
							MessageBox.Show(text4);
							break;
						}
						continue;
					}
					string text5 = "Password Should be Min 8 Character Long";
					MessageBox.Show(text5);
					break;
				}
			}
		}
		catch
		{
		}
		pictureBox1.Visible = false;
		lblMsg.Visible = false;
		method_8();
	}

	private void btnChangeQn_Click(object sender, EventArgs e)
	{
		pictureBox1.Visible = true;
		lblMsg.Visible = true;
		Application.DoEvents();
		Thread.Sleep(300);
		try
		{
			DataTable dataTable = new DataTable();
			string commandText = "SELECT * FROM TBL_USER WHERE UserState LIKE 'Active||%'";
			new SQLiteDataAdapter(commandText, Class34.string_Database).Fill(dataTable);
			int num = 0;
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
				foreach (DataRow row in dataTable.Rows)
				{
					num++;
					Label label = lblMsg;
					string text = "Updating Id: ";
					label.Text = text + num;
					Application.DoEvents();
					Thread.Sleep(200);
					string columnName = "UserName";
					string userID = row[columnName].ToString();
					string columnName2 = "strPwd";
					string pwd = row[columnName2].ToString();
					string text2 = "Answer:";
					string prompt = "Enter Your Specific Password";
					string errMessage = text2 + Interaction.InputBox(prompt);
					string text3 = Program.mcommInstance_.isLV(userID, pwd, ref errMessage);
					string text4 = "Sucess";
					_ = text3 == text4;
				}
			}
		}
		catch
		{
		}
		pictureBox1.Visible = false;
		lblMsg.Visible = false;
		method_8();
	}

	private void button5_Click(object sender, EventArgs e)
	{
		string prompt = "Please Enter Your ManPasand Value, We Appriciate it";
		string text = Interaction.InputBox(prompt);
		string text2 = "your";
		if (!(text == text2))
		{
			string text3 = "We Meet Soon, Hum Apke Leye Layenge Kuch Naya";
			MessageBox.Show(text3);
		}
	}

	private void B2AAA(object sender, EventArgs e)
	{
		dtDate1.Enabled = true;
		dtDate2.Enabled = false;
		txtPnr.Enabled = false;
	}

	private void C2AA0(object sender, EventArgs e)
	{
		dtDate1.Enabled = false;
		dtDate2.Enabled = true;
		txtPnr.Enabled = false;
	}

	private void RadioPnr_CheckedChanged(object sender, EventArgs e)
	{
		dtDate1.Enabled = false;
		dtDate2.Enabled = false;
		txtPnr.Enabled = true;
	}

	private void method_9(object sender, EventArgs e)
	{
		if (base.Height != B3AAA)
		{
			base.Height = B3AAA;
		}
	}

	private void method_10(object sender, EventArgs e)
	{
		if (base.Height != B3AAA)
		{
			base.Height = B3AAA;
		}
	}

	private void method_11(object sender, EventArgs e)
	{
		if (base.Height != B3AAA)
		{
			base.Height = B3AAA;
		}
	}

	private void method_12(object sender, EventArgs e)
	{
		if (base.Height != B3AAA)
		{
			base.Height = B3AAA;
		}
	}

	private void method_13(object sender, EventArgs e)
	{
		dgv.DataSource = null;
		if (base.Height == B3AAA)
		{
			base.Height -= 438;
		}
	}

	private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
		int rowIndex = e.RowIndex;
		switch (e.ColumnIndex)
		{
		case 8:
		{
			string text10 = "This Facility WE LAunch Soon. Tnaks for Support";
			MessageBox.Show(text10);
			break;
		}
		case 7:
		{
			string text = "Print";
			string text2 = text;
			string text3 = label16.Text;
			string text4 = "";
			try
			{
				text4 = Program.dictionary_01[text3];
			}
			catch
			{
				DataRow dataRow = dataTable_0.Rows[rowIndex];
				string columnName = "state";
				string text5 = dataRow[columnName].ToString();
				string value = "Invalid";
				if (text5.Contains(value))
				{
					string text6 = "The Selected User Id Is Deactivated";
					MessageBox.Show(text6);
				}
			}
			DataRow dataRow2 = dataTable_1.Rows[rowIndex];
			string columnName2 = "PNR";
			string text7 = dataRow2[columnName2].ToString();
			string text8 = ":";
			string errMessage = text2 + text8 + text7;
			pictureBox1.Visible = true;
			Application.DoEvents();
			Thread.Sleep(500);
			try
			{
				if (bool.Parse(Program.mcommInstance_.isLV(text3.Trim(), text4.Trim(), ref errMessage)))
				{
					string text9 = "Sucessfully Print Your Ticket, Check on Desktop Nget_Log Folder";
					MessageBox.Show(text9);
				}
			}
			catch
			{
			}
			pictureBox1.Visible = false;
			break;
		}
		}
	}

	private void btnHideDay_Click(object sender, EventArgs e)
	{
		Program.mySettings_0.KeepId = CmbDays.Text;
		string text = "Keep Id Hide After Book Ticket in Days Successfully Saved.";
		MessageBox.Show(text);
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
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
		this.panel6 = new System.Windows.Forms.Panel();
		this.lstCredit = new System.Windows.Forms.ListBox();
		this.C4AA0 = new System.Windows.Forms.Button();
		this.btnCreditEdit = new System.Windows.Forms.Button();
		this.B4AAA = new System.Windows.Forms.Button();
		this.pnlCredit = new System.Windows.Forms.Panel();
		this.label8 = new System.Windows.Forms.Label();
		this.BCAAA = new System.Windows.Forms.ComboBox();
		this.checkBox3 = new System.Windows.Forms.CheckBox();
		this.C8AA0 = new System.Windows.Forms.Label();
		this.B8AAA = new System.Windows.Forms.TextBox();
		this.textCredit3DPin = new System.Windows.Forms.TextBox();
		this.label4 = new System.Windows.Forms.Label();
		this.cboCreditGateway = new System.Windows.Forms.ComboBox();
		this.label22 = new System.Windows.Forms.Label();
		this.label20 = new System.Windows.Forms.Label();
		this.txtCCSaveName = new System.Windows.Forms.TextBox();
		this.cboCardType = new System.Windows.Forms.ComboBox();
		this.label5 = new System.Windows.Forms.Label();
		this.label6 = new System.Windows.Forms.Label();
		this.txtCreditCVV = new System.Windows.Forms.TextBox();
		this.label7 = new System.Windows.Forms.Label();
		this.cboCreditYear = new System.Windows.Forms.ComboBox();
		this.cboCreditMonth = new System.Windows.Forms.ComboBox();
		this.txtCreditVisaPin = new System.Windows.Forms.TextBox();
		this.txtCreditNo = new System.Windows.Forms.TextBox();
		this.label9 = new System.Windows.Forms.Label();
		this.B5AAA = new System.Windows.Forms.Label();
		this.cboCreditBank = new System.Windows.Forms.ComboBox();
		this.C5AA0 = new System.Windows.Forms.Label();
		this.btnCreditSave = new System.Windows.Forms.Button();
		this.panel2 = new System.Windows.Forms.Panel();
		this.label44 = new System.Windows.Forms.Label();
		this.label25 = new System.Windows.Forms.Label();
		this.label38 = new System.Windows.Forms.Label();
		this.label24 = new System.Windows.Forms.Label();
		this.label28 = new System.Windows.Forms.Label();
		this.label16 = new System.Windows.Forms.Label();
		this.label26 = new System.Windows.Forms.Label();
		this.label41 = new System.Windows.Forms.Label();
		this.dgv = new System.Windows.Forms.DataGridView();
		this.RadioBdate = new System.Windows.Forms.RadioButton();
		this.dtDate1 = new System.Windows.Forms.DateTimePicker();
		this.RadioPnr = new System.Windows.Forms.RadioButton();
		this.RadioJdate = new System.Windows.Forms.RadioButton();
		this.button3 = new System.Windows.Forms.Button();
		this.button2 = new System.Windows.Forms.Button();
		this.txtPnr = new System.Windows.Forms.TextBox();
		this.dtDate2 = new System.Windows.Forms.DateTimePicker();
		this.grdUsers = new System.Windows.Forms.DataGridView();
		this.clmID = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.clmPwd = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.clmMTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.clmCheck = new System.Windows.Forms.DataGridViewLinkColumn();
		this.clmAvtive = new System.Windows.Forms.DataGridViewLinkColumn();
		this.clmDelete = new System.Windows.Forms.DataGridViewLinkColumn();
		this.ClmHis = new System.Windows.Forms.DataGridViewLinkColumn();
		this.B7AAA = new System.Windows.Forms.GroupBox();
		this.btnHideDay = new System.Windows.Forms.Button();
		this.CmbDays = new System.Windows.Forms.ComboBox();
		this.label14 = new System.Windows.Forms.Label();
		this.button5 = new System.Windows.Forms.Button();
		this.btnChangeQn = new System.Windows.Forms.Button();
		this.txtLogin = new System.Windows.Forms.TextBox();
		this.label37 = new System.Windows.Forms.Label();
		this.chkShowPwd = new System.Windows.Forms.CheckBox();
		this.btnIDSave = new System.Windows.Forms.Button();
		this.txtPassword = new System.Windows.Forms.TextBox();
		this.CCAA0 = new System.Windows.Forms.Button();
		this.lblPassword = new System.Windows.Forms.Label();
		this.chkValidate = new System.Windows.Forms.CheckBox();
		this.btnActivate = new System.Windows.Forms.Button();
		this.label23 = new System.Windows.Forms.Label();
		this.C7AA0 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.lblActive = new System.Windows.Forms.Label();
		this.panel9 = new System.Windows.Forms.Panel();
		this.lstNB = new System.Windows.Forms.ListBox();
		this.btnNBDelete = new System.Windows.Forms.Button();
		this.btnNBEdit = new System.Windows.Forms.Button();
		this.btnNBDeleteAll = new System.Windows.Forms.Button();
		this.panel1 = new System.Windows.Forms.Panel();
		this.checkBox1 = new System.Windows.Forms.CheckBox();
		this.cboGateway0 = new System.Windows.Forms.ComboBox();
		this.label11 = new System.Windows.Forms.Label();
		this.label21 = new System.Windows.Forms.Label();
		this.txtNBSaveName = new System.Windows.Forms.TextBox();
		this.lblOTP = new System.Windows.Forms.Label();
		this.txtOTP = new System.Windows.Forms.TextBox();
		this.txtTxnPassword = new System.Windows.Forms.TextBox();
		this.txtLoginPassword = new System.Windows.Forms.TextBox();
		this.txtUserName = new System.Windows.Forms.TextBox();
		this.B6AAA = new System.Windows.Forms.Label();
		this.C6AA0 = new System.Windows.Forms.Label();
		this.lblUserName = new System.Windows.Forms.Label();
		this.comboBox_0 = new System.Windows.Forms.ComboBox();
		this.lblBankName = new System.Windows.Forms.Label();
		this.btnNBSave = new System.Windows.Forms.Button();
		this.panel12 = new System.Windows.Forms.Panel();
		this.checkBox2 = new System.Windows.Forms.CheckBox();
		this.label19 = new System.Windows.Forms.Label();
		this.txtDebitHolderName = new System.Windows.Forms.TextBox();
		this.textDebit3DPin = new System.Windows.Forms.TextBox();
		this.label27 = new System.Windows.Forms.Label();
		this.cboDebitGateway = new System.Windows.Forms.ComboBox();
		this.B9AAA = new System.Windows.Forms.Label();
		this.C9AA0 = new System.Windows.Forms.Label();
		this.txtDCSaveName = new System.Windows.Forms.TextBox();
		this.cboDebitCardType = new System.Windows.Forms.ComboBox();
		this.label31 = new System.Windows.Forms.Label();
		this.label32 = new System.Windows.Forms.Label();
		this.txtDebitCVV = new System.Windows.Forms.TextBox();
		this.label33 = new System.Windows.Forms.Label();
		this.cboDebitYear = new System.Windows.Forms.ComboBox();
		this.cboDebitMonth = new System.Windows.Forms.ComboBox();
		this.txtDebitVisaPin = new System.Windows.Forms.TextBox();
		this.txtDebitNo = new System.Windows.Forms.TextBox();
		this.BBAAA = new System.Windows.Forms.Label();
		this.CBAA0 = new System.Windows.Forms.Label();
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
		this.lblMsg = new System.Windows.Forms.Label();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.panel13 = new System.Windows.Forms.Panel();
		this.lbl7 = new System.Windows.Forms.Label();
		this.lbl6 = new System.Windows.Forms.Label();
		this.label17 = new System.Windows.Forms.Label();
		this.label18 = new System.Windows.Forms.Label();
		this.lblCurMonbk = new System.Windows.Forms.Label();
		this.lblTobk = new System.Windows.Forms.Label();
		this.BEAAA = new System.Windows.Forms.Label();
		this.CEAA0 = new System.Windows.Forms.Label();
		this.pnlloader = new System.Windows.Forms.Panel();
		this.panel6.SuspendLayout();
		this.pnlCredit.SuspendLayout();
		this.panel2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dgv).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.grdUsers).BeginInit();
		this.B7AAA.SuspendLayout();
		this.panel9.SuspendLayout();
		this.panel1.SuspendLayout();
		this.panel12.SuspendLayout();
		this.panel4.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		this.groupBox1.SuspendLayout();
		this.panel13.SuspendLayout();
		this.pnlloader.SuspendLayout();
		base.SuspendLayout();
		this.panel6.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
		this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.panel6.Controls.Add(this.lstCredit);
		this.panel6.Controls.Add(this.C4AA0);
		this.panel6.Controls.Add(this.btnCreditEdit);
		this.panel6.Controls.Add(this.B4AAA);
		this.panel6.Location = new System.Drawing.Point(371, 437);
		this.panel6.Name = "panel6";
		this.panel6.Size = new System.Drawing.Size(373, 309);
		this.panel6.TabIndex = 2;
		this.lstCredit.BackColor = System.Drawing.Color.GhostWhite;
		this.lstCredit.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.lstCredit.Dock = System.Windows.Forms.DockStyle.Top;
		this.lstCredit.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lstCredit.FormattingEnabled = true;
		this.lstCredit.ItemHeight = 16;
		this.lstCredit.Location = new System.Drawing.Point(0, 0);
		this.lstCredit.Name = "lstCredit";
		this.lstCredit.Size = new System.Drawing.Size(371, 272);
		this.lstCredit.TabIndex = 0;
		this.C4AA0.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.C4AA0.BackColor = System.Drawing.SystemColors.ButtonFace;
		this.C4AA0.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.C4AA0.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.C4AA0.Location = new System.Drawing.Point(151, 279);
		this.C4AA0.Name = "C4AA0";
		this.C4AA0.Size = new System.Drawing.Size(106, 25);
		this.C4AA0.TabIndex = 20;
		this.C4AA0.Text = "Delete";
		this.C4AA0.UseVisualStyleBackColor = false;
		this.C4AA0.Click += new System.EventHandler(C4AA0_Click);
		this.btnCreditEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnCreditEdit.BackColor = System.Drawing.SystemColors.ButtonFace;
		this.btnCreditEdit.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnCreditEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCreditEdit.Location = new System.Drawing.Point(5, 280);
		this.btnCreditEdit.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
		this.btnCreditEdit.Name = "btnCreditEdit";
		this.btnCreditEdit.Size = new System.Drawing.Size(103, 25);
		this.btnCreditEdit.TabIndex = 19;
		this.btnCreditEdit.Text = "Edit";
		this.btnCreditEdit.UseVisualStyleBackColor = false;
		this.btnCreditEdit.Click += new System.EventHandler(btnCreditEdit_Click);
		this.B4AAA.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.B4AAA.BackColor = System.Drawing.SystemColors.ButtonFace;
		this.B4AAA.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.B4AAA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.B4AAA.Location = new System.Drawing.Point(263, 279);
		this.B4AAA.Name = "B4AAA";
		this.B4AAA.Size = new System.Drawing.Size(104, 25);
		this.B4AAA.TabIndex = 21;
		this.B4AAA.Text = " Delete All";
		this.B4AAA.UseVisualStyleBackColor = false;
		this.B4AAA.Click += new System.EventHandler(B4AAA_Click);
		this.pnlCredit.BackColor = System.Drawing.Color.White;
		this.pnlCredit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pnlCredit.Controls.Add(this.label8);
		this.pnlCredit.Controls.Add(this.BCAAA);
		this.pnlCredit.Controls.Add(this.checkBox3);
		this.pnlCredit.Controls.Add(this.C8AA0);
		this.pnlCredit.Controls.Add(this.B8AAA);
		this.pnlCredit.Controls.Add(this.textCredit3DPin);
		this.pnlCredit.Controls.Add(this.label4);
		this.pnlCredit.Controls.Add(this.cboCreditGateway);
		this.pnlCredit.Controls.Add(this.label22);
		this.pnlCredit.Controls.Add(this.label20);
		this.pnlCredit.Controls.Add(this.txtCCSaveName);
		this.pnlCredit.Controls.Add(this.cboCardType);
		this.pnlCredit.Controls.Add(this.label5);
		this.pnlCredit.Controls.Add(this.label6);
		this.pnlCredit.Controls.Add(this.txtCreditCVV);
		this.pnlCredit.Controls.Add(this.label7);
		this.pnlCredit.Controls.Add(this.cboCreditYear);
		this.pnlCredit.Controls.Add(this.cboCreditMonth);
		this.pnlCredit.Controls.Add(this.txtCreditVisaPin);
		this.pnlCredit.Controls.Add(this.txtCreditNo);
		this.pnlCredit.Controls.Add(this.label9);
		this.pnlCredit.Controls.Add(this.B5AAA);
		this.pnlCredit.Controls.Add(this.cboCreditBank);
		this.pnlCredit.Controls.Add(this.C5AA0);
		this.pnlCredit.Controls.Add(this.btnCreditSave);
		this.pnlCredit.Location = new System.Drawing.Point(0, 437);
		this.pnlCredit.Name = "pnlCredit";
		this.pnlCredit.Size = new System.Drawing.Size(360, 309);
		this.pnlCredit.TabIndex = 1;
		this.label8.AutoSize = true;
		this.label8.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label8.Location = new System.Drawing.Point(7, 49);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(125, 16);
		this.label8.TabIndex = 47;
		this.label8.Text = "Select Your Type";
		this.BCAAA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.BCAAA.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.BCAAA.FormattingEnabled = true;
		this.BCAAA.Items.AddRange(new object[3] { "Credit_Card", "Debit_Card", "Virtual_Card" });
		this.BCAAA.Location = new System.Drawing.Point(154, 44);
		this.BCAAA.Name = "BCAAA";
		this.BCAAA.Size = new System.Drawing.Size(144, 26);
		this.BCAAA.TabIndex = 46;
		this.BCAAA.SelectedIndexChanged += new System.EventHandler(BCAAA_SelectedIndexChanged);
		this.checkBox3.AutoSize = true;
		this.checkBox3.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.checkBox3.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.checkBox3.Location = new System.Drawing.Point(7, 274);
		this.checkBox3.Name = "checkBox3";
		this.checkBox3.Size = new System.Drawing.Size(140, 20);
		this.checkBox3.TabIndex = 45;
		this.checkBox3.Text = "Show Password";
		this.checkBox3.UseVisualStyleBackColor = true;
		this.checkBox3.CheckedChanged += new System.EventHandler(checkBox3_CheckedChanged);
		this.C8AA0.AutoSize = true;
		this.C8AA0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.C8AA0.Location = new System.Drawing.Point(7, 177);
		this.C8AA0.Name = "C8AA0";
		this.C8AA0.Size = new System.Drawing.Size(114, 16);
		this.C8AA0.TabIndex = 43;
		this.C8AA0.Text = "Name on Card: ";
		this.B8AAA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.B8AAA.Location = new System.Drawing.Point(154, 175);
		this.B8AAA.MaxLength = 30;
		this.B8AAA.Name = "B8AAA";
		this.B8AAA.Size = new System.Drawing.Size(190, 22);
		this.B8AAA.TabIndex = 42;
		this.textCredit3DPin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textCredit3DPin.Location = new System.Drawing.Point(154, 220);
		this.textCredit3DPin.MaxLength = 20;
		this.textCredit3DPin.Name = "textCredit3DPin";
		this.textCredit3DPin.PasswordChar = '*';
		this.textCredit3DPin.Size = new System.Drawing.Size(190, 22);
		this.textCredit3DPin.TabIndex = 41;
		this.label4.AutoSize = true;
		this.label4.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label4.Location = new System.Drawing.Point(7, 222);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(147, 16);
		this.label4.TabIndex = 40;
		this.label4.Text = "Card 3D Password : ";
		this.cboCreditGateway.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboCreditGateway.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboCreditGateway.FormattingEnabled = true;
		this.cboCreditGateway.Items.AddRange(new object[1] { "IRCTC" });
		this.cboCreditGateway.Location = new System.Drawing.Point(154, 3);
		this.cboCreditGateway.Name = "cboCreditGateway";
		this.cboCreditGateway.Size = new System.Drawing.Size(144, 26);
		this.cboCreditGateway.TabIndex = 23;
		this.cboCreditGateway.SelectedIndexChanged += new System.EventHandler(CAAA0);
		this.label22.AutoSize = true;
		this.label22.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label22.Location = new System.Drawing.Point(7, 8);
		this.label22.Name = "label22";
		this.label22.Size = new System.Drawing.Size(79, 16);
		this.label22.TabIndex = 22;
		this.label22.Text = "Gateway : ";
		this.label20.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.label20.AutoSize = true;
		this.label20.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label20.ForeColor = System.Drawing.Color.Maroon;
		this.label20.Location = new System.Drawing.Point(7, 246);
		this.label20.Name = "label20";
		this.label20.Size = new System.Drawing.Size(116, 16);
		this.label20.TabIndex = 14;
		this.label20.Text = "Name to Save : ";
		this.txtCCSaveName.BackColor = System.Drawing.SystemColors.Control;
		this.txtCCSaveName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtCCSaveName.Enabled = false;
		this.txtCCSaveName.Location = new System.Drawing.Point(154, 243);
		this.txtCCSaveName.MaxLength = 15;
		this.txtCCSaveName.Name = "txtCCSaveName";
		this.txtCCSaveName.Size = new System.Drawing.Size(190, 22);
		this.txtCCSaveName.TabIndex = 15;
		this.cboCardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboCardType.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboCardType.FormattingEnabled = true;
		this.cboCardType.Items.AddRange(new object[3] { "Visa", "Master", "Rupay" });
		this.cboCardType.Location = new System.Drawing.Point(154, 99);
		this.cboCardType.Name = "cboCardType";
		this.cboCardType.Size = new System.Drawing.Size(101, 26);
		this.cboCardType.TabIndex = 4;
		this.label5.AutoSize = true;
		this.label5.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label5.Location = new System.Drawing.Point(7, 104);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(89, 16);
		this.label5.TabIndex = 3;
		this.label5.Text = "Card Type : ";
		this.label6.AutoSize = true;
		this.label6.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label6.Location = new System.Drawing.Point(248, 201);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(44, 16);
		this.label6.TabIndex = 12;
		this.label6.Text = "CVV :";
		this.txtCreditCVV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtCreditCVV.Location = new System.Drawing.Point(291, 198);
		this.txtCreditCVV.MaxLength = 3;
		this.txtCreditCVV.Name = "txtCreditCVV";
		this.txtCreditCVV.PasswordChar = '*';
		this.txtCreditCVV.Size = new System.Drawing.Size(53, 22);
		this.txtCreditCVV.TabIndex = 13;
		this.label7.AutoSize = true;
		this.label7.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label7.Location = new System.Drawing.Point(7, 201);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(136, 16);
		this.label7.TabIndex = 10;
		this.label7.Text = "Visa / Master Pin : ";
		this.cboCreditYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboCreditYear.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboCreditYear.FormattingEnabled = true;
		this.cboCreditYear.Location = new System.Drawing.Point(245, 149);
		this.cboCreditYear.Name = "cboCreditYear";
		this.cboCreditYear.Size = new System.Drawing.Size(99, 26);
		this.cboCreditYear.TabIndex = 9;
		this.cboCreditMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboCreditMonth.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboCreditMonth.FormattingEnabled = true;
		this.cboCreditMonth.Items.AddRange(new object[12]
		{
			"01", "02", "03", "04", "05", "06", "07", "08", "09", "10",
			"11", "12"
		});
		this.cboCreditMonth.Location = new System.Drawing.Point(154, 149);
		this.cboCreditMonth.Name = "cboCreditMonth";
		this.cboCreditMonth.Size = new System.Drawing.Size(64, 26);
		this.cboCreditMonth.TabIndex = 8;
		this.txtCreditVisaPin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtCreditVisaPin.Location = new System.Drawing.Point(154, 198);
		this.txtCreditVisaPin.MaxLength = 15;
		this.txtCreditVisaPin.Name = "txtCreditVisaPin";
		this.txtCreditVisaPin.PasswordChar = '*';
		this.txtCreditVisaPin.Size = new System.Drawing.Size(79, 22);
		this.txtCreditVisaPin.TabIndex = 11;
		this.txtCreditNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtCreditNo.Location = new System.Drawing.Point(154, 126);
		this.txtCreditNo.MaxLength = 20;
		this.txtCreditNo.Name = "txtCreditNo";
		this.txtCreditNo.Size = new System.Drawing.Size(190, 22);
		this.txtCreditNo.TabIndex = 6;
		this.txtCreditNo.TextChanged += new System.EventHandler(txtCreditNo_TextChanged);
		this.label9.AutoSize = true;
		this.label9.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label9.Location = new System.Drawing.Point(7, 154);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(172, 16);
		this.label9.TabIndex = 7;
		this.label9.Text = "Valid Thru/Expiry Date : ";
		this.B5AAA.AutoSize = true;
		this.B5AAA.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.B5AAA.Location = new System.Drawing.Point(7, 128);
		this.B5AAA.Name = "B5AAA";
		this.B5AAA.Size = new System.Drawing.Size(80, 16);
		this.B5AAA.TabIndex = 5;
		this.B5AAA.Text = "Card No. : ";
		this.cboCreditBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboCreditBank.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboCreditBank.FormattingEnabled = true;
		this.cboCreditBank.Location = new System.Drawing.Point(154, 73);
		this.cboCreditBank.Name = "cboCreditBank";
		this.cboCreditBank.Size = new System.Drawing.Size(144, 26);
		this.cboCreditBank.TabIndex = 2;
		this.C5AA0.AutoSize = true;
		this.C5AA0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.C5AA0.Location = new System.Drawing.Point(7, 78);
		this.C5AA0.Name = "C5AA0";
		this.C5AA0.Size = new System.Drawing.Size(98, 16);
		this.C5AA0.TabIndex = 1;
		this.C5AA0.Text = "Bank Name : ";
		this.btnCreditSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnCreditSave.BackColor = System.Drawing.SystemColors.ButtonFace;
		this.btnCreditSave.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnCreditSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCreditSave.Location = new System.Drawing.Point(152, 279);
		this.btnCreditSave.Name = "btnCreditSave";
		this.btnCreditSave.Size = new System.Drawing.Size(192, 25);
		this.btnCreditSave.TabIndex = 18;
		this.btnCreditSave.Text = "Save";
		this.btnCreditSave.UseVisualStyleBackColor = false;
		this.btnCreditSave.Click += new System.EventHandler(btnCreditSave_Click);
		this.panel2.BackColor = System.Drawing.Color.White;
		this.panel2.Controls.Add(this.label44);
		this.panel2.Controls.Add(this.label25);
		this.panel2.Controls.Add(this.label38);
		this.panel2.Controls.Add(this.label24);
		this.panel2.Controls.Add(this.label28);
		this.panel2.Controls.Add(this.label16);
		this.panel2.Controls.Add(this.label26);
		this.panel2.Controls.Add(this.label41);
		this.panel2.Location = new System.Drawing.Point(772, 12);
		this.panel2.Name = "panel2";
		this.panel2.Size = new System.Drawing.Size(739, 125);
		this.panel2.TabIndex = 19;
		this.label44.BackColor = System.Drawing.Color.Yellow;
		this.label44.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.label44.Font = new System.Drawing.Font("Arial", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label44.Location = new System.Drawing.Point(550, 63);
		this.label44.Name = "label44";
		this.label44.Size = new System.Drawing.Size(180, 57);
		this.label44.TabIndex = 16;
		this.label44.Text = "Upcoming :- ";
		this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.label25.BackColor = System.Drawing.Color.OliveDrab;
		this.label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.label25.Font = new System.Drawing.Font("Arial", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label25.Location = new System.Drawing.Point(550, 3);
		this.label25.Name = "label25";
		this.label25.Size = new System.Drawing.Size(180, 57);
		this.label25.TabIndex = 16;
		this.label25.Text = "User ID is Verfied And Active ";
		this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.label38.BackColor = System.Drawing.Color.Yellow;
		this.label38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.label38.Font = new System.Drawing.Font("Arial", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label38.Location = new System.Drawing.Point(369, 63);
		this.label38.Name = "label38";
		this.label38.Size = new System.Drawing.Size(180, 57);
		this.label38.TabIndex = 16;
		this.label38.Text = "Total Ticket :-";
		this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.label24.BackColor = System.Drawing.Color.Yellow;
		this.label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.label24.Font = new System.Drawing.Font("Arial", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label24.Location = new System.Drawing.Point(368, 3);
		this.label24.Name = "label24";
		this.label24.Size = new System.Drawing.Size(180, 57);
		this.label24.TabIndex = 16;
		this.label24.Text = "Password :- ";
		this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.label28.BackColor = System.Drawing.Color.Yellow;
		this.label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.label28.Font = new System.Drawing.Font("Arial", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label28.Location = new System.Drawing.Point(186, 63);
		this.label28.Name = "label28";
		this.label28.Size = new System.Drawing.Size(180, 57);
		this.label28.TabIndex = 16;
		this.label28.Text = "Mobile :-";
		this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.label16.BackColor = System.Drawing.Color.Yellow;
		this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.label16.Font = new System.Drawing.Font("Arial", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label16.Location = new System.Drawing.Point(186, 3);
		this.label16.Name = "label16";
		this.label16.Size = new System.Drawing.Size(180, 57);
		this.label16.TabIndex = 16;
		this.label16.Text = "User ID :- ";
		this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.label26.BackColor = System.Drawing.Color.Yellow;
		this.label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.label26.Font = new System.Drawing.Font("Arial", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label26.Location = new System.Drawing.Point(4, 63);
		this.label26.Name = "label26";
		this.label26.Size = new System.Drawing.Size(180, 57);
		this.label26.TabIndex = 16;
		this.label26.Text = "Email :-";
		this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.label41.BackColor = System.Drawing.Color.Yellow;
		this.label41.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.label41.Font = new System.Drawing.Font("Arial", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label41.Location = new System.Drawing.Point(4, 3);
		this.label41.Name = "label41";
		this.label41.Size = new System.Drawing.Size(180, 57);
		this.label41.TabIndex = 16;
		this.label41.Text = "Client Name :-";
		this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.dgv.AllowUserToAddRows = false;
		this.dgv.AllowUserToDeleteRows = false;
		this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
		this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = System.Drawing.Color.FromArgb(128, 128, 255);
		dataGridViewCellStyle.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = System.Drawing.Color.White;
		dataGridViewCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(128, 128, 255);
		dataGridViewCellStyle.SelectionForeColor = System.Drawing.Color.White;
		dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		this.dgv.ColumnHeadersHeight = 25;
		this.dgv.EnableHeadersVisualStyles = false;
		this.dgv.GridColor = System.Drawing.Color.GhostWhite;
		this.dgv.Location = new System.Drawing.Point(772, 138);
		this.dgv.MultiSelect = false;
		this.dgv.Name = "dgv";
		this.dgv.ReadOnly = true;
		this.dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
		this.dgv.RowHeadersVisible = false;
		this.dgv.RowHeadersWidth = 51;
		this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
		this.dgv.Size = new System.Drawing.Size(739, 254);
		this.dgv.TabIndex = 2;
		this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(dgv_CellContentClick);
		this.RadioBdate.AutoSize = true;
		this.RadioBdate.Location = new System.Drawing.Point(7, 17);
		this.RadioBdate.Name = "RadioBdate";
		this.RadioBdate.Size = new System.Drawing.Size(111, 21);
		this.RadioBdate.TabIndex = 34;
		this.RadioBdate.TabStop = true;
		this.RadioBdate.Text = "ByBookDate:";
		this.RadioBdate.UseVisualStyleBackColor = true;
		this.RadioBdate.CheckedChanged += new System.EventHandler(B2AAA);
		this.dtDate1.Checked = false;
		this.dtDate1.CustomFormat = "dd-MMM-yyyy";
		this.dtDate1.Enabled = false;
		this.dtDate1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.dtDate1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
		this.dtDate1.Location = new System.Drawing.Point(95, 16);
		this.dtDate1.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
		this.dtDate1.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
		this.dtDate1.Name = "dtDate1";
		this.dtDate1.Size = new System.Drawing.Size(103, 23);
		this.dtDate1.TabIndex = 33;
		((System.Windows.Forms.ToolTip)(object)this).SetToolTip(((APP_FRAMEWORK.frmBanks)(object)this.toolTip_0).dtDate1, "Date of Journey");
		this.dtDate1.Value = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
		this.RadioPnr.AutoSize = true;
		this.RadioPnr.Location = new System.Drawing.Point(420, 18);
		this.RadioPnr.Name = "RadioPnr";
		this.RadioPnr.Size = new System.Drawing.Size(71, 21);
		this.RadioPnr.TabIndex = 32;
		this.RadioPnr.TabStop = true;
		this.RadioPnr.Text = "ByPnr:";
		this.RadioPnr.UseVisualStyleBackColor = true;
		this.RadioPnr.CheckedChanged += new System.EventHandler(RadioPnr_CheckedChanged);
		this.RadioJdate.AutoSize = true;
		this.RadioJdate.Location = new System.Drawing.Point(205, 17);
		this.RadioJdate.Name = "RadioJdate";
		this.RadioJdate.Size = new System.Drawing.Size(134, 21);
		this.RadioJdate.TabIndex = 31;
		this.RadioJdate.TabStop = true;
		this.RadioJdate.Text = "ByJourneyDate: ";
		this.RadioJdate.UseVisualStyleBackColor = true;
		this.RadioJdate.CheckedChanged += new System.EventHandler(C2AA0);
		this.button3.BackColor = System.Drawing.Color.Transparent;
		this.button3.Location = new System.Drawing.Point(674, 13);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(70, 24);
		this.button3.TabIndex = 30;
		this.button3.Text = "Clear";
		this.button3.UseVisualStyleBackColor = false;
		this.button3.Click += new System.EventHandler(button3_Click);
		this.button2.BackColor = System.Drawing.Color.Transparent;
		this.button2.Location = new System.Drawing.Point(593, 13);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(70, 24);
		this.button2.TabIndex = 30;
		this.button2.Text = "Search";
		this.button2.UseVisualStyleBackColor = false;
		this.button2.Click += new System.EventHandler(button2_Click);
		this.txtPnr.Enabled = false;
		this.txtPnr.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtPnr.Location = new System.Drawing.Point(478, 16);
		this.txtPnr.MaxLength = 50;
		this.txtPnr.Name = "txtPnr";
		this.txtPnr.Size = new System.Drawing.Size(109, 25);
		this.txtPnr.TabIndex = 2;
		this.dtDate2.Checked = false;
		this.dtDate2.CustomFormat = "dd-MMM-yyyy";
		this.dtDate2.Enabled = false;
		this.dtDate2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.dtDate2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
		this.dtDate2.Location = new System.Drawing.Point(311, 17);
		this.dtDate2.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
		this.dtDate2.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
		this.dtDate2.Name = "dtDate2";
		this.dtDate2.Size = new System.Drawing.Size(105, 23);
		this.dtDate2.TabIndex = 27;
		((System.Windows.Forms.ToolTip)(object)this).SetToolTip(((APP_FRAMEWORK.frmBanks)(object)this.toolTip_0).dtDate2, "Date of Journey");
		this.dtDate2.Value = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
		this.grdUsers.AllowUserToAddRows = false;
		this.grdUsers.AllowUserToDeleteRows = false;
		this.grdUsers.AllowUserToResizeColumns = false;
		this.grdUsers.AllowUserToResizeRows = false;
		this.grdUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
		this.grdUsers.BackgroundColor = System.Drawing.Color.FromArgb(255, 192, 192);
		dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
		dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold);
		dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
		dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		this.grdUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
		this.grdUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.grdUsers.Columns.AddRange(this.clmID, this.clmPwd, this.clmMTotal, this.clmCheck, this.clmAvtive, this.clmDelete, this.ClmHis);
		dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
		dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
		dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
		this.grdUsers.DefaultCellStyle = dataGridViewCellStyle3;
		this.grdUsers.Location = new System.Drawing.Point(0, 112);
		this.grdUsers.MultiSelect = false;
		this.grdUsers.Name = "grdUsers";
		this.grdUsers.ReadOnly = true;
		this.grdUsers.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
		this.grdUsers.RowHeadersVisible = false;
		this.grdUsers.RowHeadersWidth = 51;
		this.grdUsers.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.grdUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
		this.grdUsers.Size = new System.Drawing.Size(754, 233);
		this.grdUsers.TabIndex = 18;
		this.grdUsers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(grdUsers_CellContentClick);
		this.clmID.DataPropertyName = "userid";
		dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
		dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
		this.clmID.DefaultCellStyle = dataGridViewCellStyle4;
		this.clmID.FillWeight = 125f;
		this.clmID.HeaderText = "User ID";
		this.clmID.MaxInputLength = 20;
		this.clmID.MinimumWidth = 6;
		this.clmID.Name = "clmID";
		this.clmID.ReadOnly = true;
		this.clmID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		this.clmPwd.DataPropertyName = "Pwd";
		this.clmPwd.HeaderText = "Password";
		this.clmPwd.MinimumWidth = 6;
		this.clmPwd.Name = "clmPwd";
		this.clmPwd.ReadOnly = true;
		this.clmMTotal.DataPropertyName = "currtotal";
		this.clmMTotal.HeaderText = "Total Pnr";
		this.clmMTotal.MinimumWidth = 6;
		this.clmMTotal.Name = "clmMTotal";
		this.clmMTotal.ReadOnly = true;
		this.clmMTotal.Resizable = System.Windows.Forms.DataGridViewTriState.True;
		this.clmCheck.DataPropertyName = "sync";
		dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
		this.clmCheck.DefaultCellStyle = dataGridViewCellStyle5;
		this.clmCheck.HeaderText = "Check";
		this.clmCheck.MinimumWidth = 6;
		this.clmCheck.Name = "clmCheck";
		this.clmCheck.ReadOnly = true;
		this.clmCheck.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		this.clmCheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
		this.clmAvtive.DataPropertyName = "state";
		dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
		this.clmAvtive.DefaultCellStyle = dataGridViewCellStyle6;
		this.clmAvtive.HeaderText = "Action";
		this.clmAvtive.MinimumWidth = 6;
		this.clmAvtive.Name = "clmAvtive";
		this.clmAvtive.ReadOnly = true;
		this.clmAvtive.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		this.clmAvtive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
		this.clmAvtive.TrackVisitedState = false;
		this.clmDelete.DataPropertyName = "delete";
		dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
		this.clmDelete.DefaultCellStyle = dataGridViewCellStyle7;
		this.clmDelete.FillWeight = 80f;
		this.clmDelete.HeaderText = "Delete";
		this.clmDelete.MinimumWidth = 6;
		this.clmDelete.Name = "clmDelete";
		this.clmDelete.ReadOnly = true;
		this.clmDelete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		this.clmDelete.Text = "Delete";
		this.clmDelete.TrackVisitedState = false;
		this.ClmHis.DataPropertyName = "history";
		this.ClmHis.HeaderText = "History";
		this.ClmHis.MinimumWidth = 6;
		this.ClmHis.Name = "ClmHis";
		this.ClmHis.ReadOnly = true;
		this.ClmHis.Resizable = System.Windows.Forms.DataGridViewTriState.True;
		this.ClmHis.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
		this.B7AAA.BackColor = System.Drawing.Color.White;
		this.B7AAA.Controls.Add(this.btnHideDay);
		this.B7AAA.Controls.Add(this.CmbDays);
		this.B7AAA.Controls.Add(this.label14);
		this.B7AAA.Controls.Add(this.button5);
		this.B7AAA.Controls.Add(this.btnChangeQn);
		this.B7AAA.Controls.Add(this.txtLogin);
		this.B7AAA.Controls.Add(this.label37);
		this.B7AAA.Controls.Add(this.chkShowPwd);
		this.B7AAA.Controls.Add(this.btnIDSave);
		this.B7AAA.Controls.Add(this.txtPassword);
		this.B7AAA.Controls.Add(this.CCAA0);
		this.B7AAA.Controls.Add(this.lblPassword);
		this.B7AAA.Controls.Add(this.chkValidate);
		this.B7AAA.Controls.Add(this.btnActivate);
		this.B7AAA.Location = new System.Drawing.Point(3, 12);
		this.B7AAA.Name = "B7AAA";
		this.B7AAA.Size = new System.Drawing.Size(749, 99);
		this.B7AAA.TabIndex = 1;
		this.B7AAA.TabStop = false;
		this.B7AAA.Text = "IRCTC ID";
		this.btnHideDay.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnHideDay.Location = new System.Drawing.Point(662, 71);
		this.btnHideDay.Name = "btnHideDay";
		this.btnHideDay.Size = new System.Drawing.Size(79, 21);
		this.btnHideDay.TabIndex = 17;
		this.btnHideDay.Text = "Save Days";
		this.btnHideDay.UseVisualStyleBackColor = true;
		this.btnHideDay.Click += new System.EventHandler(btnHideDay_Click);
		this.CmbDays.FormattingEnabled = true;
		this.CmbDays.Items.AddRange(new object[11]
		{
			"0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
			"10"
		});
		this.CmbDays.Location = new System.Drawing.Point(590, 71);
		this.CmbDays.Name = "CmbDays";
		this.CmbDays.Size = new System.Drawing.Size(63, 24);
		this.CmbDays.TabIndex = 16;
		this.label14.AutoSize = true;
		this.label14.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label14.Location = new System.Drawing.Point(423, 74);
		this.label14.Name = "label14";
		this.label14.Size = new System.Drawing.Size(179, 18);
		this.label14.TabIndex = 1177;
		this.label14.Text = "Hide IRCTC Id for Days :";
		this.button5.BackColor = System.Drawing.Color.Transparent;
		this.button5.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button5.Location = new System.Drawing.Point(590, 40);
		this.button5.Name = "button5";
		this.button5.Size = new System.Drawing.Size(153, 26);
		this.button5.TabIndex = 12;
		this.button5.Text = "Create New Irctc-ID";
		this.button5.UseVisualStyleBackColor = false;
		this.button5.Click += new System.EventHandler(button5_Click);
		this.btnChangeQn.BackColor = System.Drawing.Color.Transparent;
		this.btnChangeQn.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnChangeQn.Location = new System.Drawing.Point(287, 71);
		this.btnChangeQn.Name = "btnChangeQn";
		this.btnChangeQn.Size = new System.Drawing.Size(128, 24);
		this.btnChangeQn.TabIndex = 15;
		this.btnChangeQn.Text = "Change ALL ID Ans";
		this.btnChangeQn.UseVisualStyleBackColor = false;
		this.btnChangeQn.Click += new System.EventHandler(btnChangeQn_Click);
		this.txtLogin.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtLogin.Location = new System.Drawing.Point(87, 14);
		this.txtLogin.MaxLength = 20;
		this.txtLogin.Name = "txtLogin";
		this.txtLogin.Size = new System.Drawing.Size(139, 30);
		this.txtLogin.TabIndex = 7;
		this.label37.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label37.Location = new System.Drawing.Point(4, 13);
		this.label37.Name = "label37";
		this.label37.Size = new System.Drawing.Size(84, 26);
		this.label37.TabIndex = 15;
		this.label37.Text = "User ID: ";
		this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.chkShowPwd.AutoSize = true;
		this.chkShowPwd.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.chkShowPwd.Location = new System.Drawing.Point(641, 13);
		this.chkShowPwd.Name = "chkShowPwd";
		this.chkShowPwd.Size = new System.Drawing.Size(129, 21);
		this.chkShowPwd.TabIndex = 11;
		this.chkShowPwd.Text = "&Show Password";
		this.chkShowPwd.UseVisualStyleBackColor = true;
		this.chkShowPwd.CheckedChanged += new System.EventHandler(chkShowPwd_CheckedChanged);
		this.btnIDSave.BackColor = System.Drawing.Color.Transparent;
		this.btnIDSave.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnIDSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnIDSave.Location = new System.Drawing.Point(475, 13);
		this.btnIDSave.Name = "btnIDSave";
		this.btnIDSave.Size = new System.Drawing.Size(128, 26);
		this.btnIDSave.TabIndex = 9;
		this.btnIDSave.Text = "Add";
		this.btnIDSave.UseVisualStyleBackColor = false;
		this.btnIDSave.Click += new System.EventHandler(btnIDSave_Click);
		this.txtPassword.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtPassword.Location = new System.Drawing.Point(331, 14);
		this.txtPassword.MaxLength = 20;
		this.txtPassword.Name = "txtPassword";
		this.txtPassword.PasswordChar = '*';
		this.txtPassword.Size = new System.Drawing.Size(133, 30);
		this.txtPassword.TabIndex = 8;
		this.CCAA0.BackColor = System.Drawing.Color.Transparent;
		this.CCAA0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.CCAA0.Location = new System.Drawing.Point(153, 71);
		this.CCAA0.Name = "CCAA0";
		this.CCAA0.Size = new System.Drawing.Size(128, 24);
		this.CCAA0.TabIndex = 14;
		this.CCAA0.Text = "Change ALL ID PWD";
		this.CCAA0.UseVisualStyleBackColor = false;
		this.CCAA0.Click += new System.EventHandler(CCAA0_Click);
		this.lblPassword.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblPassword.Location = new System.Drawing.Point(224, 15);
		this.lblPassword.Name = "lblPassword";
		this.lblPassword.Size = new System.Drawing.Size(101, 26);
		this.lblPassword.TabIndex = 3;
		this.lblPassword.Text = "Password: ";
		this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.chkValidate.AutoSize = true;
		this.chkValidate.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.chkValidate.Location = new System.Drawing.Point(87, 46);
		this.chkValidate.Name = "chkValidate";
		this.chkValidate.Size = new System.Drawing.Size(350, 21);
		this.chkValidate.TabIndex = 10;
		this.chkValidate.Text = "&Validate Login from IRCTC (Strongly Recomended)";
		this.chkValidate.UseVisualStyleBackColor = true;
		this.btnActivate.BackColor = System.Drawing.Color.Transparent;
		this.btnActivate.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnActivate.Location = new System.Drawing.Point(8, 71);
		this.btnActivate.Name = "btnActivate";
		this.btnActivate.Size = new System.Drawing.Size(141, 24);
		this.btnActivate.TabIndex = 13;
		this.btnActivate.Text = "Syncronize ALL ID'S";
		this.btnActivate.UseVisualStyleBackColor = false;
		this.btnActivate.Click += new System.EventHandler(C1AA0);
		this.label23.AutoSize = true;
		this.label23.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label23.Location = new System.Drawing.Point(4, 3);
		this.label23.Name = "label23";
		this.label23.Size = new System.Drawing.Size(78, 18);
		this.label23.TabIndex = 9;
		this.label23.Text = "Total IDs: ";
		this.C7AA0.AutoSize = true;
		this.C7AA0.BackColor = System.Drawing.Color.White;
		this.C7AA0.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.C7AA0.ForeColor = System.Drawing.Color.Red;
		this.C7AA0.Location = new System.Drawing.Point(78, 4);
		this.C7AA0.Name = "C7AA0";
		this.C7AA0.Size = new System.Drawing.Size(19, 19);
		this.C7AA0.TabIndex = 13;
		this.C7AA0.Text = "T";
		this.C7AA0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.label2.AutoSize = true;
		this.label2.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label2.Location = new System.Drawing.Point(4, 22);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(121, 18);
		this.label2.TabIndex = 10;
		this.label2.Text = "Total Active IDs:";
		this.lblActive.AutoSize = true;
		this.lblActive.BackColor = System.Drawing.Color.White;
		this.lblActive.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblActive.ForeColor = System.Drawing.Color.Red;
		this.lblActive.Location = new System.Drawing.Point(116, 22);
		this.lblActive.Name = "lblActive";
		this.lblActive.Size = new System.Drawing.Size(19, 19);
		this.lblActive.TabIndex = 12;
		this.lblActive.Text = "T";
		this.lblActive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.panel9.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
		this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.panel9.Controls.Add(this.lstNB);
		this.panel9.Controls.Add(this.btnNBDelete);
		this.panel9.Controls.Add(this.btnNBEdit);
		this.panel9.Controls.Add(this.btnNBDeleteAll);
		this.panel9.Location = new System.Drawing.Point(1144, 405);
		this.panel9.Name = "panel9";
		this.panel9.Size = new System.Drawing.Size(372, 306);
		this.panel9.TabIndex = 3;
		this.lstNB.BackColor = System.Drawing.Color.GhostWhite;
		this.lstNB.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.lstNB.Dock = System.Windows.Forms.DockStyle.Top;
		this.lstNB.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lstNB.FormattingEnabled = true;
		this.lstNB.ItemHeight = 16;
		this.lstNB.Location = new System.Drawing.Point(0, 0);
		this.lstNB.Name = "lstNB";
		this.lstNB.Size = new System.Drawing.Size(370, 256);
		this.lstNB.TabIndex = 0;
		this.btnNBDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnNBDelete.BackColor = System.Drawing.SystemColors.ButtonFace;
		this.btnNBDelete.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnNBDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnNBDelete.Location = new System.Drawing.Point(139, 278);
		this.btnNBDelete.Name = "btnNBDelete";
		this.btnNBDelete.Size = new System.Drawing.Size(119, 24);
		this.btnNBDelete.TabIndex = 17;
		this.btnNBDelete.Text = "&Delete";
		this.btnNBDelete.UseVisualStyleBackColor = false;
		this.btnNBDelete.Click += new System.EventHandler(btnNBDelete_Click);
		this.btnNBEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnNBEdit.BackColor = System.Drawing.SystemColors.ButtonFace;
		this.btnNBEdit.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnNBEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnNBEdit.Location = new System.Drawing.Point(6, 278);
		this.btnNBEdit.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
		this.btnNBEdit.Name = "btnNBEdit";
		this.btnNBEdit.Size = new System.Drawing.Size(127, 24);
		this.btnNBEdit.TabIndex = 16;
		this.btnNBEdit.Text = "Edit";
		this.btnNBEdit.UseVisualStyleBackColor = false;
		this.btnNBEdit.Click += new System.EventHandler(btnNBEdit_Click);
		this.btnNBDeleteAll.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnNBDeleteAll.BackColor = System.Drawing.SystemColors.ButtonFace;
		this.btnNBDeleteAll.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnNBDeleteAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnNBDeleteAll.Location = new System.Drawing.Point(264, 277);
		this.btnNBDeleteAll.Name = "btnNBDeleteAll";
		this.btnNBDeleteAll.Size = new System.Drawing.Size(101, 24);
		this.btnNBDeleteAll.TabIndex = 18;
		this.btnNBDeleteAll.Text = "Delete All";
		this.btnNBDeleteAll.UseVisualStyleBackColor = false;
		this.btnNBDeleteAll.Click += new System.EventHandler(btnNBDeleteAll_Click);
		this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.panel1.Controls.Add(this.checkBox1);
		this.panel1.Controls.Add(this.cboGateway0);
		this.panel1.Controls.Add(this.label11);
		this.panel1.Controls.Add(this.label21);
		this.panel1.Controls.Add(this.txtNBSaveName);
		this.panel1.Controls.Add(this.lblOTP);
		this.panel1.Controls.Add(this.txtOTP);
		this.panel1.Controls.Add(this.txtTxnPassword);
		this.panel1.Controls.Add(this.txtLoginPassword);
		this.panel1.Controls.Add(this.txtUserName);
		this.panel1.Controls.Add(this.B6AAA);
		this.panel1.Controls.Add(this.C6AA0);
		this.panel1.Controls.Add(this.lblUserName);
		this.panel1.Controls.Add(this.comboBox_0);
		this.panel1.Controls.Add(this.lblBankName);
		this.panel1.Controls.Add(this.btnNBSave);
		this.panel1.Location = new System.Drawing.Point(778, 405);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(360, 306);
		this.panel1.TabIndex = 2;
		this.checkBox1.AutoSize = true;
		this.checkBox1.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.checkBox1.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.checkBox1.Location = new System.Drawing.Point(12, 211);
		this.checkBox1.Name = "checkBox1";
		this.checkBox1.Size = new System.Drawing.Size(140, 20);
		this.checkBox1.TabIndex = 39;
		this.checkBox1.Text = "Show Password";
		this.checkBox1.UseVisualStyleBackColor = true;
		this.checkBox1.CheckedChanged += new System.EventHandler(checkBox1_CheckedChanged);
		this.cboGateway0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboGateway0.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboGateway0.FormattingEnabled = true;
		this.cboGateway0.Items.AddRange(new object[1] { "IRCTC" });
		this.cboGateway0.Location = new System.Drawing.Point(121, 11);
		this.cboGateway0.Name = "cboGateway0";
		this.cboGateway0.Size = new System.Drawing.Size(123, 26);
		this.cboGateway0.TabIndex = 25;
		this.cboGateway0.SelectedIndexChanged += new System.EventHandler(cboGateway0_SelectedIndexChanged);
		this.label11.AutoSize = true;
		this.label11.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label11.Location = new System.Drawing.Point(9, 16);
		this.label11.Name = "label11";
		this.label11.Size = new System.Drawing.Size(79, 16);
		this.label11.TabIndex = 24;
		this.label11.Text = "Gateway : ";
		this.label21.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.label21.AutoSize = true;
		this.label21.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label21.ForeColor = System.Drawing.Color.Maroon;
		this.label21.Location = new System.Drawing.Point(9, 174);
		this.label21.Name = "label21";
		this.label21.Size = new System.Drawing.Size(116, 16);
		this.label21.TabIndex = 11;
		this.label21.Text = "Name to Save : ";
		this.txtNBSaveName.BackColor = System.Drawing.SystemColors.Control;
		this.txtNBSaveName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtNBSaveName.Enabled = false;
		this.txtNBSaveName.Location = new System.Drawing.Point(121, 172);
		this.txtNBSaveName.MaxLength = 15;
		this.txtNBSaveName.Name = "txtNBSaveName";
		this.txtNBSaveName.Size = new System.Drawing.Size(232, 22);
		this.txtNBSaveName.TabIndex = 12;
		this.lblOTP.AutoSize = true;
		this.lblOTP.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblOTP.Location = new System.Drawing.Point(9, 148);
		this.lblOTP.Name = "lblOTP";
		this.lblOTP.Size = new System.Drawing.Size(48, 16);
		this.lblOTP.TabIndex = 9;
		this.lblOTP.Text = "OTP : ";
		this.lblOTP.Visible = false;
		this.txtOTP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtOTP.Location = new System.Drawing.Point(121, 146);
		this.txtOTP.MaxLength = 30;
		this.txtOTP.Name = "txtOTP";
		this.txtOTP.Size = new System.Drawing.Size(77, 22);
		this.txtOTP.TabIndex = 10;
		this.txtOTP.Visible = false;
		this.txtTxnPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtTxnPassword.Location = new System.Drawing.Point(121, 120);
		this.txtTxnPassword.MaxLength = 30;
		this.txtTxnPassword.Name = "txtTxnPassword";
		this.txtTxnPassword.PasswordChar = '*';
		this.txtTxnPassword.Size = new System.Drawing.Size(232, 22);
		this.txtTxnPassword.TabIndex = 8;
		this.txtTxnPassword.Visible = false;
		this.txtLoginPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtLoginPassword.Location = new System.Drawing.Point(121, 95);
		this.txtLoginPassword.MaxLength = 30;
		this.txtLoginPassword.Name = "txtLoginPassword";
		this.txtLoginPassword.PasswordChar = '*';
		this.txtLoginPassword.Size = new System.Drawing.Size(232, 22);
		this.txtLoginPassword.TabIndex = 6;
		this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtUserName.Location = new System.Drawing.Point(121, 69);
		this.txtUserName.MaxLength = 30;
		this.txtUserName.Name = "txtUserName";
		this.txtUserName.Size = new System.Drawing.Size(232, 22);
		this.txtUserName.TabIndex = 4;
		this.txtUserName.TextChanged += new System.EventHandler(txtUserName_TextChanged);
		this.B6AAA.AutoSize = true;
		this.B6AAA.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.B6AAA.Location = new System.Drawing.Point(9, 122);
		this.B6AAA.Name = "B6AAA";
		this.B6AAA.Size = new System.Drawing.Size(117, 16);
		this.B6AAA.TabIndex = 7;
		this.B6AAA.Text = "Txn Password : ";
		this.B6AAA.Visible = false;
		this.C6AA0.AutoSize = true;
		this.C6AA0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.C6AA0.Location = new System.Drawing.Point(9, 97);
		this.C6AA0.Name = "C6AA0";
		this.C6AA0.Size = new System.Drawing.Size(131, 16);
		this.C6AA0.TabIndex = 5;
		this.C6AA0.Text = "Login Password : ";
		this.lblUserName.AutoSize = true;
		this.lblUserName.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblUserName.Location = new System.Drawing.Point(9, 71);
		this.lblUserName.Name = "lblUserName";
		this.lblUserName.Size = new System.Drawing.Size(96, 16);
		this.lblUserName.TabIndex = 3;
		this.lblUserName.Text = "User Name : ";
		this.comboBox_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboBox_0.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.comboBox_0.FormattingEnabled = true;
		this.comboBox_0.Location = new System.Drawing.Point(121, 40);
		this.comboBox_0.Name = "comboBox_0";
		this.comboBox_0.Size = new System.Drawing.Size(232, 26);
		this.comboBox_0.TabIndex = 2;
		this.comboBox_0.SelectedIndexChanged += new System.EventHandler(comboBox_0_SelectedIndexChanged);
		this.lblBankName.AutoSize = true;
		this.lblBankName.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblBankName.Location = new System.Drawing.Point(9, 42);
		this.lblBankName.Name = "lblBankName";
		this.lblBankName.Size = new System.Drawing.Size(98, 16);
		this.lblBankName.TabIndex = 1;
		this.lblBankName.Text = "Bank Name : ";
		this.btnNBSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnNBSave.BackColor = System.Drawing.SystemColors.ButtonFace;
		this.btnNBSave.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnNBSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnNBSave.Location = new System.Drawing.Point(120, 277);
		this.btnNBSave.Name = "btnNBSave";
		this.btnNBSave.Size = new System.Drawing.Size(233, 24);
		this.btnNBSave.TabIndex = 15;
		this.btnNBSave.Text = "Save";
		this.btnNBSave.UseVisualStyleBackColor = false;
		this.btnNBSave.Click += new System.EventHandler(btnNBSave_Click);
		this.panel12.BackColor = System.Drawing.Color.White;
		this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.panel12.Controls.Add(this.checkBox2);
		this.panel12.Controls.Add(this.label19);
		this.panel12.Controls.Add(this.txtDebitHolderName);
		this.panel12.Controls.Add(this.textDebit3DPin);
		this.panel12.Controls.Add(this.label27);
		this.panel12.Controls.Add(this.cboDebitGateway);
		this.panel12.Controls.Add(this.B9AAA);
		this.panel12.Controls.Add(this.C9AA0);
		this.panel12.Controls.Add(this.txtDCSaveName);
		this.panel12.Controls.Add(this.cboDebitCardType);
		this.panel12.Controls.Add(this.label31);
		this.panel12.Controls.Add(this.label32);
		this.panel12.Controls.Add(this.txtDebitCVV);
		this.panel12.Controls.Add(this.label33);
		this.panel12.Controls.Add(this.cboDebitYear);
		this.panel12.Controls.Add(this.cboDebitMonth);
		this.panel12.Controls.Add(this.txtDebitVisaPin);
		this.panel12.Controls.Add(this.txtDebitNo);
		this.panel12.Controls.Add(this.BBAAA);
		this.panel12.Controls.Add(this.CBAA0);
		this.panel12.Controls.Add(this.cboDebitBank);
		this.panel12.Controls.Add(this.label36);
		this.panel12.Controls.Add(this.btnCreditSave1);
		this.panel12.Location = new System.Drawing.Point(371, 752);
		this.panel12.Name = "panel12";
		this.panel12.Size = new System.Drawing.Size(360, 306);
		this.panel12.TabIndex = 6;
		this.checkBox2.AutoSize = true;
		this.checkBox2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.checkBox2.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.checkBox2.Location = new System.Drawing.Point(8, 235);
		this.checkBox2.Name = "checkBox2";
		this.checkBox2.Size = new System.Drawing.Size(140, 20);
		this.checkBox2.TabIndex = 44;
		this.checkBox2.Text = "Show Password";
		this.checkBox2.UseVisualStyleBackColor = true;
		this.checkBox2.CheckedChanged += new System.EventHandler(checkBox2_CheckedChanged);
		this.label19.AutoSize = true;
		this.label19.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label19.Location = new System.Drawing.Point(6, 138);
		this.label19.Name = "label19";
		this.label19.Size = new System.Drawing.Size(114, 16);
		this.label19.TabIndex = 43;
		this.label19.Text = "Name on Card: ";
		this.txtDebitHolderName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtDebitHolderName.Location = new System.Drawing.Point(155, 136);
		this.txtDebitHolderName.MaxLength = 30;
		this.txtDebitHolderName.Name = "txtDebitHolderName";
		this.txtDebitHolderName.Size = new System.Drawing.Size(190, 22);
		this.txtDebitHolderName.TabIndex = 42;
		this.textDebit3DPin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textDebit3DPin.Location = new System.Drawing.Point(155, 181);
		this.textDebit3DPin.MaxLength = 20;
		this.textDebit3DPin.Name = "textDebit3DPin";
		this.textDebit3DPin.PasswordChar = '*';
		this.textDebit3DPin.Size = new System.Drawing.Size(190, 22);
		this.textDebit3DPin.TabIndex = 41;
		this.label27.AutoSize = true;
		this.label27.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label27.Location = new System.Drawing.Point(6, 183);
		this.label27.Name = "label27";
		this.label27.Size = new System.Drawing.Size(147, 16);
		this.label27.TabIndex = 40;
		this.label27.Text = "Card 3D Password : ";
		this.cboDebitGateway.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboDebitGateway.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboDebitGateway.FormattingEnabled = true;
		this.cboDebitGateway.Items.AddRange(new object[1] { "IRCTC" });
		this.cboDebitGateway.Location = new System.Drawing.Point(154, 8);
		this.cboDebitGateway.Name = "cboDebitGateway";
		this.cboDebitGateway.Size = new System.Drawing.Size(141, 26);
		this.cboDebitGateway.TabIndex = 23;
		this.cboDebitGateway.SelectedIndexChanged += new System.EventHandler(cboDebitGateway_SelectedIndexChanged);
		this.B9AAA.AutoSize = true;
		this.B9AAA.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.B9AAA.Location = new System.Drawing.Point(6, 13);
		this.B9AAA.Name = "B9AAA";
		this.B9AAA.Size = new System.Drawing.Size(79, 16);
		this.B9AAA.TabIndex = 22;
		this.B9AAA.Text = "Gateway : ";
		this.C9AA0.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.C9AA0.AutoSize = true;
		this.C9AA0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.C9AA0.ForeColor = System.Drawing.Color.Maroon;
		this.C9AA0.Location = new System.Drawing.Point(6, 208);
		this.C9AA0.Name = "C9AA0";
		this.C9AA0.Size = new System.Drawing.Size(116, 16);
		this.C9AA0.TabIndex = 14;
		this.C9AA0.Text = "Name to Save : ";
		this.txtDCSaveName.BackColor = System.Drawing.SystemColors.Control;
		this.txtDCSaveName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtDCSaveName.Enabled = false;
		this.txtDCSaveName.Location = new System.Drawing.Point(155, 204);
		this.txtDCSaveName.MaxLength = 15;
		this.txtDCSaveName.Name = "txtDCSaveName";
		this.txtDCSaveName.Size = new System.Drawing.Size(190, 22);
		this.txtDCSaveName.TabIndex = 15;
		this.cboDebitCardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboDebitCardType.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboDebitCardType.FormattingEnabled = true;
		this.cboDebitCardType.Items.AddRange(new object[3] { "Visa", "Master", "Rupay" });
		this.cboDebitCardType.Location = new System.Drawing.Point(154, 60);
		this.cboDebitCardType.Name = "cboDebitCardType";
		this.cboDebitCardType.Size = new System.Drawing.Size(101, 26);
		this.cboDebitCardType.TabIndex = 4;
		this.label31.AutoSize = true;
		this.label31.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label31.Location = new System.Drawing.Point(6, 65);
		this.label31.Name = "label31";
		this.label31.Size = new System.Drawing.Size(89, 16);
		this.label31.TabIndex = 3;
		this.label31.Text = "Card Type : ";
		this.label32.AutoSize = true;
		this.label32.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label32.Location = new System.Drawing.Point(248, 162);
		this.label32.Name = "label32";
		this.label32.Size = new System.Drawing.Size(44, 16);
		this.label32.TabIndex = 12;
		this.label32.Text = "CVV :";
		this.txtDebitCVV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtDebitCVV.Location = new System.Drawing.Point(291, 159);
		this.txtDebitCVV.MaxLength = 3;
		this.txtDebitCVV.Name = "txtDebitCVV";
		this.txtDebitCVV.PasswordChar = '*';
		this.txtDebitCVV.Size = new System.Drawing.Size(53, 22);
		this.txtDebitCVV.TabIndex = 13;
		this.label33.AutoSize = true;
		this.label33.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label33.Location = new System.Drawing.Point(6, 162);
		this.label33.Name = "label33";
		this.label33.Size = new System.Drawing.Size(136, 16);
		this.label33.TabIndex = 10;
		this.label33.Text = "Visa / Master Pin : ";
		this.cboDebitYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboDebitYear.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboDebitYear.FormattingEnabled = true;
		this.cboDebitYear.Location = new System.Drawing.Point(245, 110);
		this.cboDebitYear.Name = "cboDebitYear";
		this.cboDebitYear.Size = new System.Drawing.Size(99, 26);
		this.cboDebitYear.TabIndex = 9;
		this.cboDebitMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboDebitMonth.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboDebitMonth.FormattingEnabled = true;
		this.cboDebitMonth.Items.AddRange(new object[12]
		{
			"01", "02", "03", "04", "05", "06", "07", "08", "09", "10",
			"11", "12"
		});
		this.cboDebitMonth.Location = new System.Drawing.Point(154, 110);
		this.cboDebitMonth.Name = "cboDebitMonth";
		this.cboDebitMonth.Size = new System.Drawing.Size(64, 26);
		this.cboDebitMonth.TabIndex = 8;
		this.txtDebitVisaPin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtDebitVisaPin.Location = new System.Drawing.Point(155, 159);
		this.txtDebitVisaPin.MaxLength = 15;
		this.txtDebitVisaPin.Name = "txtDebitVisaPin";
		this.txtDebitVisaPin.PasswordChar = '*';
		this.txtDebitVisaPin.Size = new System.Drawing.Size(79, 22);
		this.txtDebitVisaPin.TabIndex = 11;
		this.txtDebitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtDebitNo.Location = new System.Drawing.Point(154, 87);
		this.txtDebitNo.MaxLength = 20;
		this.txtDebitNo.Name = "txtDebitNo";
		this.txtDebitNo.Size = new System.Drawing.Size(190, 22);
		this.txtDebitNo.TabIndex = 6;
		this.txtDebitNo.TextChanged += new System.EventHandler(txtDebitNo_TextChanged);
		this.BBAAA.AutoSize = true;
		this.BBAAA.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.BBAAA.Location = new System.Drawing.Point(6, 115);
		this.BBAAA.Name = "BBAAA";
		this.BBAAA.Size = new System.Drawing.Size(172, 16);
		this.BBAAA.TabIndex = 7;
		this.BBAAA.Text = "Valid Thru/Expiry Date : ";
		this.CBAA0.AutoSize = true;
		this.CBAA0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.CBAA0.Location = new System.Drawing.Point(6, 89);
		this.CBAA0.Name = "CBAA0";
		this.CBAA0.Size = new System.Drawing.Size(80, 16);
		this.CBAA0.TabIndex = 5;
		this.CBAA0.Text = "Card No. : ";
		this.cboDebitBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboDebitBank.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboDebitBank.FormattingEnabled = true;
		this.cboDebitBank.Location = new System.Drawing.Point(154, 34);
		this.cboDebitBank.Name = "cboDebitBank";
		this.cboDebitBank.Size = new System.Drawing.Size(141, 26);
		this.cboDebitBank.TabIndex = 2;
		this.label36.AutoSize = true;
		this.label36.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label36.Location = new System.Drawing.Point(6, 39);
		this.label36.Name = "label36";
		this.label36.Size = new System.Drawing.Size(98, 16);
		this.label36.TabIndex = 1;
		this.label36.Text = "Bank Name : ";
		this.btnCreditSave1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnCreditSave1.BackColor = System.Drawing.SystemColors.ButtonFace;
		this.btnCreditSave1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnCreditSave1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCreditSave1.Location = new System.Drawing.Point(154, 276);
		this.btnCreditSave1.Name = "btnCreditSave1";
		this.btnCreditSave1.Size = new System.Drawing.Size(191, 25);
		this.btnCreditSave1.TabIndex = 18;
		this.btnCreditSave1.Text = "Save";
		this.btnCreditSave1.UseVisualStyleBackColor = false;
		this.btnCreditSave1.Click += new System.EventHandler(button1_Click);
		this.panel4.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
		this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.panel4.Controls.Add(this.lstDebit);
		this.panel4.Controls.Add(this.btnDebitDelete);
		this.panel4.Controls.Add(this.btnCreditEdit1);
		this.panel4.Controls.Add(this.btnDebitDeleteAll);
		this.panel4.Controls.Add(this.button1);
		this.panel4.Location = new System.Drawing.Point(737, 752);
		this.panel4.Name = "panel4";
		this.panel4.Size = new System.Drawing.Size(378, 306);
		this.panel4.TabIndex = 5;
		this.lstDebit.BackColor = System.Drawing.Color.GhostWhite;
		this.lstDebit.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.lstDebit.Dock = System.Windows.Forms.DockStyle.Top;
		this.lstDebit.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lstDebit.FormattingEnabled = true;
		this.lstDebit.ItemHeight = 16;
		this.lstDebit.Location = new System.Drawing.Point(0, 0);
		this.lstDebit.Name = "lstDebit";
		this.lstDebit.Size = new System.Drawing.Size(376, 256);
		this.lstDebit.TabIndex = 0;
		this.btnDebitDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnDebitDelete.BackColor = System.Drawing.SystemColors.ButtonFace;
		this.btnDebitDelete.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnDebitDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnDebitDelete.Location = new System.Drawing.Point(134, 277);
		this.btnDebitDelete.Name = "btnDebitDelete";
		this.btnDebitDelete.Size = new System.Drawing.Size(104, 25);
		this.btnDebitDelete.TabIndex = 20;
		this.btnDebitDelete.Text = "Delete";
		this.btnDebitDelete.UseVisualStyleBackColor = false;
		this.btnDebitDelete.Click += new System.EventHandler(btnDebitDelete_Click);
		this.btnCreditEdit1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnCreditEdit1.BackColor = System.Drawing.SystemColors.ButtonFace;
		this.btnCreditEdit1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnCreditEdit1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCreditEdit1.Location = new System.Drawing.Point(1, 277);
		this.btnCreditEdit1.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
		this.btnCreditEdit1.Name = "btnCreditEdit1";
		this.btnCreditEdit1.Size = new System.Drawing.Size(117, 25);
		this.btnCreditEdit1.TabIndex = 19;
		this.btnCreditEdit1.Text = "Edit";
		this.btnCreditEdit1.UseVisualStyleBackColor = false;
		this.btnCreditEdit1.Click += new System.EventHandler(btnCreditEdit1_Click);
		this.btnDebitDeleteAll.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnDebitDeleteAll.BackColor = System.Drawing.SystemColors.ButtonFace;
		this.btnDebitDeleteAll.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnDebitDeleteAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnDebitDeleteAll.Location = new System.Drawing.Point(244, 276);
		this.btnDebitDeleteAll.Name = "btnDebitDeleteAll";
		this.btnDebitDeleteAll.Size = new System.Drawing.Size(130, 25);
		this.btnDebitDeleteAll.TabIndex = 21;
		this.btnDebitDeleteAll.Text = " Delete All";
		this.btnDebitDeleteAll.UseVisualStyleBackColor = false;
		this.btnDebitDeleteAll.Click += new System.EventHandler(btnDebitDeleteAll_Click);
		this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
		this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.button1.Location = new System.Drawing.Point(-217, 275);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(191, 25);
		this.button1.TabIndex = 18;
		this.button1.Text = "Save";
		this.button1.UseVisualStyleBackColor = false;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.lblMsg.AutoSize = true;
		this.lblMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblMsg.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblMsg.Location = new System.Drawing.Point(280, 42);
		this.lblMsg.Name = "lblMsg";
		this.lblMsg.Size = new System.Drawing.Size(203, 18);
		this.lblMsg.TabIndex = 25;
		this.lblMsg.Text = "Updating Id Records 2 of 10";
		this.lblMsg.Visible = false;
		this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
		this.pictureBox1.Location = new System.Drawing.Point(3, 3);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new System.Drawing.Size(426, 36);
		this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pictureBox1.TabIndex = 24;
		this.pictureBox1.TabStop = false;
		this.pictureBox1.Visible = false;
		this.groupBox1.BackColor = System.Drawing.Color.LightGray;
		this.groupBox1.Controls.Add(this.dtDate2);
		this.groupBox1.Controls.Add(this.button3);
		this.groupBox1.Controls.Add(this.RadioBdate);
		this.groupBox1.Controls.Add(this.button2);
		this.groupBox1.Controls.Add(this.panel13);
		this.groupBox1.Controls.Add(this.txtPnr);
		this.groupBox1.Controls.Add(this.dtDate1);
		this.groupBox1.Controls.Add(this.RadioPnr);
		this.groupBox1.Controls.Add(this.RadioJdate);
		this.groupBox1.Location = new System.Drawing.Point(0, 347);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(754, 84);
		this.groupBox1.TabIndex = 36;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Search PNR";
		this.panel13.BackColor = System.Drawing.Color.Yellow;
		this.panel13.Controls.Add(this.lbl7);
		this.panel13.Controls.Add(this.lbl6);
		this.panel13.Controls.Add(this.label17);
		this.panel13.Controls.Add(this.label18);
		this.panel13.Controls.Add(this.lblCurMonbk);
		this.panel13.Controls.Add(this.lblTobk);
		this.panel13.Controls.Add(this.BEAAA);
		this.panel13.Controls.Add(this.CEAA0);
		this.panel13.Controls.Add(this.label23);
		this.panel13.Controls.Add(this.C7AA0);
		this.panel13.Controls.Add(this.label2);
		this.panel13.Controls.Add(this.lblActive);
		this.panel13.Location = new System.Drawing.Point(2, 42);
		this.panel13.Name = "panel13";
		this.panel13.Size = new System.Drawing.Size(750, 42);
		this.panel13.TabIndex = 24;
		this.lbl7.AutoSize = true;
		this.lbl7.BackColor = System.Drawing.Color.White;
		this.lbl7.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lbl7.ForeColor = System.Drawing.Color.Red;
		this.lbl7.Location = new System.Drawing.Point(723, 23);
		this.lbl7.Name = "lbl7";
		this.lbl7.Size = new System.Drawing.Size(19, 19);
		this.lbl7.TabIndex = 41;
		this.lbl7.Text = "T";
		this.lbl7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lbl6.AutoSize = true;
		this.lbl6.BackColor = System.Drawing.Color.White;
		this.lbl6.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lbl6.ForeColor = System.Drawing.Color.Red;
		this.lbl6.Location = new System.Drawing.Point(663, 6);
		this.lbl6.Name = "lbl6";
		this.lbl6.Size = new System.Drawing.Size(19, 19);
		this.lbl6.TabIndex = 40;
		this.lbl6.Text = "T";
		this.lbl6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.label17.AutoSize = true;
		this.label17.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label17.Location = new System.Drawing.Point(485, 24);
		this.label17.Name = "label17";
		this.label17.Size = new System.Drawing.Size(258, 18);
		this.label17.TabIndex = 38;
		this.label17.Text = "Total Upcoming Journey Bookings: ";
		this.label18.AutoSize = true;
		this.label18.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label18.Location = new System.Drawing.Point(485, 4);
		this.label18.Name = "label18";
		this.label18.Size = new System.Drawing.Size(190, 18);
		this.label18.TabIndex = 39;
		this.label18.Text = "Today Journey Bookings: ";
		this.lblCurMonbk.AutoSize = true;
		this.lblCurMonbk.BackColor = System.Drawing.Color.White;
		this.lblCurMonbk.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblCurMonbk.ForeColor = System.Drawing.Color.Red;
		this.lblCurMonbk.Location = new System.Drawing.Point(413, 22);
		this.lblCurMonbk.Name = "lblCurMonbk";
		this.lblCurMonbk.Size = new System.Drawing.Size(19, 19);
		this.lblCurMonbk.TabIndex = 37;
		this.lblCurMonbk.Text = "T";
		this.lblCurMonbk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblTobk.AutoSize = true;
		this.lblTobk.BackColor = System.Drawing.Color.White;
		this.lblTobk.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblTobk.ForeColor = System.Drawing.Color.Red;
		this.lblTobk.Location = new System.Drawing.Point(361, 5);
		this.lblTobk.Name = "lblTobk";
		this.lblTobk.Size = new System.Drawing.Size(19, 19);
		this.lblTobk.TabIndex = 36;
		this.lblTobk.Text = "T";
		this.lblTobk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.BEAAA.AutoSize = true;
		this.BEAAA.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.BEAAA.Location = new System.Drawing.Point(209, 23);
		this.BEAAA.Name = "BEAAA";
		this.BEAAA.Size = new System.Drawing.Size(230, 18);
		this.BEAAA.TabIndex = 35;
		this.BEAAA.Text = "Total Current Month Bookings: ";
		this.CEAA0.AutoSize = true;
		this.CEAA0.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.CEAA0.Location = new System.Drawing.Point(209, 3);
		this.CEAA0.Name = "CEAA0";
		this.CEAA0.Size = new System.Drawing.Size(168, 18);
		this.CEAA0.TabIndex = 35;
		this.CEAA0.Text = "Total Today Bookings: ";
		this.pnlloader.Controls.Add(this.pictureBox1);
		this.pnlloader.Controls.Add(this.lblMsg);
		this.pnlloader.Location = new System.Drawing.Point(180, 193);
		this.pnlloader.Name = "pnlloader";
		this.pnlloader.Size = new System.Drawing.Size(433, 65);
		this.pnlloader.TabIndex = 37;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(1204, 780);
		base.Controls.Add(this.pnlloader);
		base.Controls.Add(this.panel2);
		base.Controls.Add(this.dgv);
		base.Controls.Add(this.panel6);
		base.Controls.Add(this.pnlCredit);
		base.Controls.Add(this.panel4);
		base.Controls.Add(this.panel12);
		base.Controls.Add(this.panel9);
		base.Controls.Add(this.panel1);
		base.Controls.Add(this.groupBox1);
		base.Controls.Add(this.grdUsers);
		base.Controls.Add(this.B7AAA);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmBanks";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Add IRCTC-ID/ BANK/ Debit Card/ Credit Card Details";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(B1AAA);
		base.Load += new System.EventHandler(BAAAA);
		this.panel6.ResumeLayout(false);
		this.pnlCredit.ResumeLayout(false);
		this.pnlCredit.PerformLayout();
		this.panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dgv).EndInit();
		((System.ComponentModel.ISupportInitialize)this.grdUsers).EndInit();
		this.B7AAA.ResumeLayout(false);
		this.B7AAA.PerformLayout();
		this.panel9.ResumeLayout(false);
		this.panel1.ResumeLayout(false);
		this.panel1.PerformLayout();
		this.panel12.ResumeLayout(false);
		this.panel12.PerformLayout();
		this.panel4.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		this.panel13.ResumeLayout(false);
		this.panel13.PerformLayout();
		this.pnlloader.ResumeLayout(false);
		this.pnlloader.PerformLayout();
		base.ResumeLayout(false);
	}
}
