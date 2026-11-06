using System;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace APP_FRAMEWORK;

internal class tabCreditCard : UserControl
{
	private IDisposable idisposable_0;

	private Panel panel6;

	private ListBox lstCredit;

	private Panel pnlCredit;

	private Button btnCreditDeleteAll;

	internal Button btnCreditEdit;

	internal Button btnCreditSave;

	private Button btnCreditDelete;

	private ComboBox cboCardType;

	private Label label5;

	private Label B0AAA;

	private TextBox C0AA0;

	private Label label7;

	private ComboBox cboCreditYear;

	private ComboBox cboCreditMonth;

	private TextBox txtCreditVisaPin;

	private TextBox txtCreditNo;

	private Label label9;

	private Label label12;

	private Label label13;

	private Label label20;

	private TextBox txtCCSaveName;

	private ComboBox B1AAA;

	private ComboBox C1AA0;

	private Label label22;

	private ToolTip toolTip_0;

	private IContainer icontainer_0;

	private TextBox textCredit3DPin;

	private Label label4;

	private TextBox txtHolderName;

	private Label label10;

	private CheckBox checkBox3;

	private Label label8;

	private ComboBox CboCreditType;

	public tabCreditCard()
	{
		InitializeComponent();
	}

	private void method_0()
	{
		txtCreditNo.Text = "";
		C0AA0.Text = "";
		txtCreditVisaPin.Text = "";
		txtCCSaveName.Text = "";
		txtHolderName.Text = "";
		textCredit3DPin.Text = "";
		CboCreditType.SelectedIndex = 0;
		C1AA0.SelectedIndex = 0;
		B1AAA.SelectedIndex = 0;
		cboCardType.SelectedIndex = -1;
		cboCreditMonth.SelectedIndex = -1;
		cboCreditYear.SelectedIndex = -1;
		method_2();
	}

	private void method_1()
	{
		B1AAA.Items.Clear();
		ComboBox.ObjectCollection items = B1AAA.Items;
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
			if (!((CboCreditType.SelectedIndex == 0) | (CboCreditType.SelectedIndex == 1)))
			{
				if (CboCreditType.SelectedIndex != 2)
				{
					continue;
				}
				string value2 = "_CIT";
				if (key.Contains(value2) && C1AA0.SelectedIndex == 0)
				{
					string value3 = "_CIT";
					if (text.Contains(value3))
					{
						B1AAA.Items.Add(text.Substring(0, text.Length - 4));
					}
				}
			}
			else if (C1AA0.SelectedIndex != 0)
			{
				if (C1AA0.SelectedIndex == 1)
				{
					string value4 = "_ICI";
					if (text.Contains(value4))
					{
						B1AAA.Items.Add(text.Substring(0, text.Length - 4));
					}
				}
				else if (C1AA0.SelectedIndex != 2)
				{
					if (C1AA0.SelectedIndex == 3)
					{
						string value5 = "_PTM";
						if (text.Contains(value5))
						{
							B1AAA.Items.Add(text.Substring(0, text.Length - 4));
						}
					}
				}
				else
				{
					string value6 = "_CIT";
					if (text.Contains(value6))
					{
						B1AAA.Items.Add(text.Substring(0, text.Length - 4));
					}
				}
			}
			else
			{
				string value7 = "_HDF";
				if (text.Contains(value7))
				{
					B1AAA.Items.Add(text.Substring(0, text.Length - 4));
				}
			}
		}
		B1AAA.SelectedIndex = 0;
	}

	private void method_2()
	{
		try
		{
			lstCredit.Items.Clear();
			DataTable dataTable = new DataTable();
			string commandText = "SELECT BANK_SAVEAS from TBL_BANK WHERE BANK_ISDEBIT = 1 and (BANK_SAVEAS like '%_CC_%' or BANK_SAVEAS like '%_DC_%')";
			new SQLiteDataAdapter(commandText, Class34.string_Database).Fill(dataTable);
			if (dataTable != null && dataTable.Rows.Count > 0)
			{
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
			method_1();
		}
		catch (Exception)
		{
		}
	}

	private void txtCreditNo_TextChanged(object sender, EventArgs e)
	{
		if (B1AAA.SelectedIndex < 0)
		{
			string text = "Please Select Valid Bank!";
			string caption = "Bank";
			MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			txtCreditNo.Text = "";
			B1AAA.Focus();
			return;
		}
		if (cboCardType.SelectedIndex < 0)
		{
			string text2 = "Please Select Valid Card Type!";
			string caption2 = "Card Type";
			MessageBox.Show(text2, caption2, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			txtCreditNo.Text = "";
			cboCardType.Focus();
			return;
		}
		string text3 = txtCreditNo.Text.Trim();
		if (text3.Length > 6)
		{
			string text4 = text3.Substring(0, 2);
			string text5 = "xx";
			text3 = text4 + text5 + text3.Substring(text3.Length - 4, 4);
		}
		string text6 = "";
		string text7 = "_CC_";
		string text8 = text7;
		if (C1AA0.SelectedIndex == 0)
		{
			string text9 = "_HDF_";
			text6 = text9;
		}
		else if (C1AA0.SelectedIndex == 1)
		{
			string text10 = "_ICI_";
			text6 = text10;
		}
		else if (C1AA0.SelectedIndex != 2)
		{
			if (C1AA0.SelectedIndex == 3)
			{
				string text11 = "_PTM_";
				text6 = text11;
			}
		}
		else
		{
			string text12 = "_CIT_";
			text6 = text12;
		}
		txtCCSaveName.Text = B1AAA.SelectedItem.ToString() + text8 + text6 + text3;
	}

	private void tabCreditCard_Load(object sender, EventArgs e)
	{
		cboCreditYear.Items.Clear();
		int i = DateTime.Now.Year - 1;
		for (int num = i + 30; i <= num; i++)
		{
			cboCreditYear.Items.Add(i.ToString());
		}
		method_0();
	}

	private void C1AA0_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	private void btnCreditSave_Click(object sender, EventArgs e)
	{
		TextBox textBox = txtCreditNo;
		if (string.IsNullOrEmpty(textBox.Text) || textBox.Text.Length < 10 || !Class34.smethod_5(textBox.Text.Trim()))
		{
			string text = "Enter Valid Card No.!";
			string caption = "Credit Card";
			MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			textBox.Focus();
			return;
		}
		TextBox textBox2 = txtCreditVisaPin;
		if (!string.IsNullOrEmpty(textBox2.Text) && textBox2.Text.Length >= 4)
		{
			if (cboCreditMonth.SelectedIndex >= 0 && cboCreditYear.SelectedIndex >= 0)
			{
				TextBox c0AA = C0AA0;
				if (!c0AA.Visible || (!string.IsNullOrEmpty(c0AA.Text) && c0AA.Text.Length >= 3 && Class34.smethod_5(c0AA.Text.Trim())))
				{
					string text2 = txtCCSaveName.Text.Replace('_', 'A').Replace('-', 'A');
					if (string.IsNullOrEmpty(text2) || !Class34.smethod_3(text2))
					{
						string text3 = "Please enter valid CC Name to Save! (Only Alphabets, Numbers and (_) (-) are allowed)";
						string caption2 = "Card Name";
						MessageBox.Show(text3, caption2, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						txtCCSaveName.Focus();
						return;
					}
					string value = "_CC";
					if (text2.IndexOf(value, StringComparison.CurrentCultureIgnoreCase) < 0)
					{
						string value2 = "CC_";
						if (text2.IndexOf(value2, StringComparison.CurrentCultureIgnoreCase) < 0)
						{
							string value3 = "_DC";
							if (text2.IndexOf(value3, StringComparison.CurrentCultureIgnoreCase) < 0)
							{
								string value4 = "DC_";
								if (text2.IndexOf(value4, StringComparison.CurrentCultureIgnoreCase) < 0)
								{
									string value5 = "_ICI";
									if (text2.IndexOf(value5, StringComparison.CurrentCultureIgnoreCase) < 0)
									{
										string value6 = "_AXS";
										if (text2.IndexOf(value6, StringComparison.CurrentCultureIgnoreCase) < 0)
										{
											string value7 = "_PTM";
											if (text2.IndexOf(value7, StringComparison.CurrentCultureIgnoreCase) < 0)
											{
												if (B1AAA.SelectedIndex > 0)
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
															string text4 = "||";
															array[1] = text4;
															array[2] = cboCreditMonth.SelectedItem.ToString();
															string text5 = "||";
															array[3] = text5;
															array[4] = cboCreditYear.SelectedItem.ToString();
															string text6 = "||";
															array[5] = text6;
															array[6] = txtCreditVisaPin.Text.Trim();
															string text7 = "||";
															array[7] = text7;
															array[8] = C0AA0.Text.Trim();
															string text8 = "||";
															array[9] = text8;
															array[10] = cboCardType.SelectedItem.ToString();
															string text9 = "||";
															array[11] = text9;
															array[12] = txtHolderName.Text.Trim();
															string text10 = "||";
															array[13] = text10;
															array[14] = textCredit3DPin.Text.Trim();
															string text11 = string.Concat(array);
															SQLiteConnection sQLiteConnection = new SQLiteConnection(Class34.string_Database);
															sQLiteConnection.Open();
															SQLiteCommand sQLiteCommand = new SQLiteCommand(sQLiteConnection);
															string text12 = "SELECT count(RID) from TBL_BANK where BANK_SAVEAS = '";
															string text13 = txtCCSaveName.Text.Trim();
															string text14 = "' AND BANK_ISDEBIT = 1";
															sQLiteCommand.CommandText = text12 + text13 + text14;
															object obj = sQLiteCommand.ExecuteScalar();
															int result = 0;
															if (obj != null && obj.GetType() != typeof(DBNull))
															{
																int.TryParse(obj.ToString().Trim(), out result);
															}
															if (result > 0)
															{
																string text15 = "Credit Card Details already exists. Do you want to Update?\r\n\r\nIf you need to update existing details, Click 'YES', Otherwise you can Click 'NO'";
																string caption3 = "Details Exists";
																if (MessageBox.Show(text15, caption3, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
																{
																	sQLiteConnection.Close();
																	sQLiteCommand.Dispose();
																	return;
																}
																string text16 = "DELETE from TBL_BANK where BANK_SAVEAS = '";
																string text17 = txtCCSaveName.Text.Trim();
																string text18 = "' AND BANK_ISDEBIT = 1";
																sQLiteCommand.CommandText = text16 + text17 + text18;
																sQLiteCommand.ExecuteNonQuery();
																Program.dictionary_00.Remove(txtCCSaveName.Text.Trim());
															}
															Program.dictionary_00.Add(txtCCSaveName.Text.Trim(), text11);
															string[] array2 = new string[7];
															string text19 = "INSERT INTO TBL_BANK(BANK_NAME, BANK_SAVEAS, BANK_DETAILS, BANK_ISDEBIT) VALUES ('";
															array2[0] = text19;
															array2[1] = B1AAA.SelectedItem.ToString();
															string text20 = "', '";
															array2[2] = text20;
															array2[3] = txtCCSaveName.Text.Trim();
															string text21 = "', '";
															array2[4] = text21;
															array2[5] = text11;
															string text22 = "', 1)";
															array2[6] = text22;
															sQLiteCommand.CommandText = string.Concat(array2);
															sQLiteCommand.ExecuteNonQuery();
															sQLiteConnection.Close();
															sQLiteCommand.Dispose();
															method_0();
															string text23 = "Credit Card Details Updated Successfully!";
															string caption4 = "Bank Details";
															MessageBox.Show(text23, caption4, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
															return;
														}
														catch
														{
															string text24 = "Error Occured while Saving Credit Card Details";
															MessageBox.Show(text24);
															return;
														}
													}
													string text25 = "Please Select Valid Card Type!";
													string caption5 = "Card Type";
													MessageBox.Show(text25, caption5, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
													txtCreditNo.Text = "";
													cboCardType.Focus();
												}
												else
												{
													string text26 = "Select Valid Bank Name";
													string caption6 = "Valid Card";
													MessageBox.Show(text26, caption6, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
													B1AAA.Focus();
												}
												return;
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
					txtCCSaveName.Focus();
				}
				else
				{
					string text28 = "Enter Valid CVV!";
					string caption8 = "Credit Card";
					MessageBox.Show(text28, caption8, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					c0AA.Focus();
				}
			}
			else
			{
				string text29 = "Select Valid Thru/Expiry Date!";
				string caption9 = "Credit Card";
				MessageBox.Show(text29, caption9, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				cboCreditMonth.Focus();
			}
		}
		else
		{
			string text30 = "Enter Valid Visa / Master Pin!";
			string caption10 = "Credit Card";
			MessageBox.Show(text30, caption10, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			textBox2.Focus();
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
			CboCreditType.SelectedIndex = 0;
			string value2 = "_VIR";
			if (text2.Contains(value2))
			{
				cboCardType.SelectedIndex = 1;
			}
			else
			{
				cboCardType.SelectedIndex = 0;
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
			C1AA0.SelectedIndex = 0;
		}
		else
		{
			string value5 = "_ICI_";
			if (!text2.Contains(value5))
			{
				string value6 = "_CIT_";
				if (text2.Contains(value6))
				{
					C1AA0.SelectedIndex = 2;
				}
				else
				{
					C1AA0.SelectedIndex = 3;
				}
			}
			else
			{
				C1AA0.SelectedIndex = 1;
			}
		}
		string value7 = "_VIR";
		if (text2.Contains(value7))
		{
			C1AA0.SelectedIndex = 0;
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
		B1AAA.SelectedItem = selectedItem;
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
			C0AA0.Text = array2[4];
			cboCardType.SelectedItem = array2[5];
			txtHolderName.Text = array2[6];
			textCredit3DPin.Text = array2[7];
		}
		catch
		{
		}
		txtCCSaveName.Text = text2;
	}

	private void btnCreditDelete_Click(object sender, EventArgs e)
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

	private void CAAA0(object sender, EventArgs e)
	{
		if (checkBox3.Checked)
		{
			txtCreditVisaPin.PasswordChar = '\0';
			C0AA0.PasswordChar = '\0';
			textCredit3DPin.PasswordChar = '\0';
		}
		else
		{
			txtCreditVisaPin.PasswordChar = '*';
			C0AA0.PasswordChar = '*';
			textCredit3DPin.PasswordChar = '*';
		}
	}

	private void CboCreditType_SelectedIndexChanged(object sender, EventArgs e)
	{
		method_1();
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
		this.icontainer_0 = new System.ComponentModel.Container();
		this.panel6 = new System.Windows.Forms.Panel();
		this.lstCredit = new System.Windows.Forms.ListBox();
		this.btnCreditDelete = new System.Windows.Forms.Button();
		this.btnCreditEdit = new System.Windows.Forms.Button();
		this.btnCreditDeleteAll = new System.Windows.Forms.Button();
		this.pnlCredit = new System.Windows.Forms.Panel();
		this.label8 = new System.Windows.Forms.Label();
		this.CboCreditType = new System.Windows.Forms.ComboBox();
		this.checkBox3 = new System.Windows.Forms.CheckBox();
		this.label10 = new System.Windows.Forms.Label();
		this.txtHolderName = new System.Windows.Forms.TextBox();
		this.textCredit3DPin = new System.Windows.Forms.TextBox();
		this.label4 = new System.Windows.Forms.Label();
		this.C1AA0 = new System.Windows.Forms.ComboBox();
		this.label22 = new System.Windows.Forms.Label();
		this.label20 = new System.Windows.Forms.Label();
		this.txtCCSaveName = new System.Windows.Forms.TextBox();
		this.cboCardType = new System.Windows.Forms.ComboBox();
		this.label5 = new System.Windows.Forms.Label();
		this.B0AAA = new System.Windows.Forms.Label();
		this.C0AA0 = new System.Windows.Forms.TextBox();
		this.label7 = new System.Windows.Forms.Label();
		this.cboCreditYear = new System.Windows.Forms.ComboBox();
		this.cboCreditMonth = new System.Windows.Forms.ComboBox();
		this.txtCreditVisaPin = new System.Windows.Forms.TextBox();
		this.txtCreditNo = new System.Windows.Forms.TextBox();
		this.label9 = new System.Windows.Forms.Label();
		this.label12 = new System.Windows.Forms.Label();
		this.B1AAA = new System.Windows.Forms.ComboBox();
		this.label13 = new System.Windows.Forms.Label();
		this.btnCreditSave = new System.Windows.Forms.Button();
		this.toolTip_0 = new System.Windows.Forms.ToolTip(this.icontainer_0);
		this.panel6.SuspendLayout();
		this.pnlCredit.SuspendLayout();
		base.SuspendLayout();
		this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.panel6.Controls.Add(this.lstCredit);
		this.panel6.Controls.Add(this.btnCreditDelete);
		this.panel6.Controls.Add(this.btnCreditEdit);
		this.panel6.Controls.Add(this.btnCreditDeleteAll);
		this.panel6.Location = new System.Drawing.Point(455, 0);
		this.panel6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.panel6.Name = "panel6";
		this.panel6.Size = new System.Drawing.Size(466, 386);
		this.panel6.TabIndex = 2;
		this.lstCredit.BackColor = System.Drawing.Color.GhostWhite;
		this.lstCredit.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.lstCredit.Dock = System.Windows.Forms.DockStyle.Top;
		this.lstCredit.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lstCredit.FormattingEnabled = true;
		this.lstCredit.ItemHeight = 16;
		this.lstCredit.Location = new System.Drawing.Point(0, 0);
		this.lstCredit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.lstCredit.Name = "lstCredit";
		this.lstCredit.Size = new System.Drawing.Size(464, 320);
		this.lstCredit.TabIndex = 0;
		this.btnCreditDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnCreditDelete.BackColor = System.Drawing.Color.FloralWhite;
		this.btnCreditDelete.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.btnCreditDelete.ForeColor = System.Drawing.Color.FromArgb(64, 62, 101);
		this.btnCreditDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCreditDelete.Location = new System.Drawing.Point(176, 349);
		this.btnCreditDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.btnCreditDelete.Name = "btnCreditDelete";
		this.btnCreditDelete.Size = new System.Drawing.Size(132, 31);
		this.btnCreditDelete.TabIndex = 20;
		this.btnCreditDelete.Text = "&Delete";
		this.btnCreditDelete.UseVisualStyleBackColor = false;
		this.btnCreditDelete.Click += new System.EventHandler(btnCreditDelete_Click);
		this.btnCreditEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnCreditEdit.BackColor = System.Drawing.Color.FloralWhite;
		this.btnCreditEdit.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.btnCreditEdit.ForeColor = System.Drawing.Color.FromArgb(64, 62, 101);
		this.btnCreditEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCreditEdit.Location = new System.Drawing.Point(12, 350);
		this.btnCreditEdit.Margin = new System.Windows.Forms.Padding(0, 4, 4, 4);
		this.btnCreditEdit.Name = "btnCreditEdit";
		this.btnCreditEdit.Size = new System.Drawing.Size(129, 31);
		this.btnCreditEdit.TabIndex = 19;
		this.btnCreditEdit.Text = "&Edit";
		this.btnCreditEdit.UseVisualStyleBackColor = false;
		this.btnCreditEdit.Click += new System.EventHandler(btnCreditEdit_Click);
		this.btnCreditDeleteAll.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnCreditDeleteAll.BackColor = System.Drawing.Color.FloralWhite;
		this.btnCreditDeleteAll.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.btnCreditDeleteAll.ForeColor = System.Drawing.Color.FromArgb(64, 62, 101);
		this.btnCreditDeleteAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCreditDeleteAll.Location = new System.Drawing.Point(329, 349);
		this.btnCreditDeleteAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.btnCreditDeleteAll.Name = "btnCreditDeleteAll";
		this.btnCreditDeleteAll.Size = new System.Drawing.Size(130, 31);
		this.btnCreditDeleteAll.TabIndex = 21;
		this.btnCreditDeleteAll.Text = " De&lete All";
		this.btnCreditDeleteAll.UseVisualStyleBackColor = false;
		this.btnCreditDeleteAll.Click += new System.EventHandler(BAAAA);
		this.pnlCredit.BackColor = System.Drawing.Color.White;
		this.pnlCredit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pnlCredit.Controls.Add(this.label8);
		this.pnlCredit.Controls.Add(this.CboCreditType);
		this.pnlCredit.Controls.Add(this.checkBox3);
		this.pnlCredit.Controls.Add(this.label10);
		this.pnlCredit.Controls.Add(this.txtHolderName);
		this.pnlCredit.Controls.Add(this.textCredit3DPin);
		this.pnlCredit.Controls.Add(this.label4);
		this.pnlCredit.Controls.Add(this.C1AA0);
		this.pnlCredit.Controls.Add(this.label22);
		this.pnlCredit.Controls.Add(this.label20);
		this.pnlCredit.Controls.Add(this.txtCCSaveName);
		this.pnlCredit.Controls.Add(this.cboCardType);
		this.pnlCredit.Controls.Add(this.label5);
		this.pnlCredit.Controls.Add(this.B0AAA);
		this.pnlCredit.Controls.Add(this.C0AA0);
		this.pnlCredit.Controls.Add(this.label7);
		this.pnlCredit.Controls.Add(this.cboCreditYear);
		this.pnlCredit.Controls.Add(this.cboCreditMonth);
		this.pnlCredit.Controls.Add(this.txtCreditVisaPin);
		this.pnlCredit.Controls.Add(this.txtCreditNo);
		this.pnlCredit.Controls.Add(this.label9);
		this.pnlCredit.Controls.Add(this.label12);
		this.pnlCredit.Controls.Add(this.B1AAA);
		this.pnlCredit.Controls.Add(this.label13);
		this.pnlCredit.Controls.Add(this.btnCreditSave);
		this.pnlCredit.Location = new System.Drawing.Point(2, 1);
		this.pnlCredit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.pnlCredit.Name = "pnlCredit";
		this.pnlCredit.Size = new System.Drawing.Size(450, 386);
		this.pnlCredit.TabIndex = 1;
		this.label8.AutoSize = true;
		this.label8.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.label8.Location = new System.Drawing.Point(9, 61);
		this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(131, 21);
		this.label8.TabIndex = 47;
		this.label8.Text = "Select Your Type";
		this.CboCreditType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.CboCreditType.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.CboCreditType.FormattingEnabled = true;
		System.Windows.Forms.ComboBox.ObjectCollection items = this.CboCreditType.Items;
		items.AddRange(new object[3] { "Credit_Card", "Debit_Card", "Virtual_Card" });
		this.CboCreditType.Location = new System.Drawing.Point(192, 55);
		this.CboCreditType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.CboCreditType.Name = "CboCreditType";
		this.CboCreditType.Size = new System.Drawing.Size(179, 26);
		this.CboCreditType.TabIndex = 46;
		this.CboCreditType.SelectedIndexChanged += new System.EventHandler(CboCreditType_SelectedIndexChanged);
		this.checkBox3.AutoSize = true;
		this.checkBox3.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.checkBox3.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.checkBox3.Location = new System.Drawing.Point(9, 342);
		this.checkBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.checkBox3.Name = "checkBox3";
		this.checkBox3.Size = new System.Drawing.Size(148, 25);
		this.checkBox3.TabIndex = 45;
		this.checkBox3.Text = "Show Password";
		this.checkBox3.UseVisualStyleBackColor = true;
		this.checkBox3.CheckedChanged += new System.EventHandler(CAAA0);
		this.label10.AutoSize = true;
		this.label10.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.label10.Location = new System.Drawing.Point(9, 221);
		this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label10.Name = "label10";
		this.label10.Size = new System.Drawing.Size(122, 21);
		this.label10.TabIndex = 43;
		this.label10.Text = "Name on Card: ";
		this.txtHolderName.BackColor = System.Drawing.Color.FromArgb(235, 248, 239);
		this.txtHolderName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtHolderName.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtHolderName.Location = new System.Drawing.Point(192, 219);
		this.txtHolderName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.txtHolderName.MaxLength = 30;
		this.txtHolderName.Name = "txtHolderName";
		this.txtHolderName.Size = new System.Drawing.Size(237, 23);
		this.txtHolderName.TabIndex = 42;
		this.textCredit3DPin.BackColor = System.Drawing.Color.FromArgb(235, 248, 239);
		this.textCredit3DPin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textCredit3DPin.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.textCredit3DPin.Location = new System.Drawing.Point(192, 275);
		this.textCredit3DPin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.textCredit3DPin.MaxLength = 20;
		this.textCredit3DPin.Name = "textCredit3DPin";
		this.textCredit3DPin.Size = new System.Drawing.Size(237, 23);
		this.textCredit3DPin.TabIndex = 41;
		this.label4.AutoSize = true;
		this.label4.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.label4.Location = new System.Drawing.Point(9, 278);
		this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(155, 21);
		this.label4.TabIndex = 40;
		this.label4.Text = "Card 3D Password : ";
		this.C1AA0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.C1AA0.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.C1AA0.FormattingEnabled = true;
		System.Windows.Forms.ComboBox.ObjectCollection items2 = this.C1AA0.Items;
		items2.AddRange(new object[1] { "IRCTC" });
		this.C1AA0.Location = new System.Drawing.Point(192, 4);
		this.C1AA0.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.C1AA0.Name = "cboCreditGateway";
		this.C1AA0.Size = new System.Drawing.Size(179, 26);
		this.C1AA0.TabIndex = 23;
		this.C1AA0.SelectedIndexChanged += new System.EventHandler(C1AA0_SelectedIndexChanged);
		this.label22.AutoSize = true;
		this.label22.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.label22.Location = new System.Drawing.Point(9, 10);
		this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label22.Name = "label22";
		this.label22.Size = new System.Drawing.Size(89, 21);
		this.label22.TabIndex = 22;
		this.label22.Text = "Gateway : ";
		this.label20.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.label20.AutoSize = true;
		this.label20.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.label20.ForeColor = System.Drawing.Color.Maroon;
		this.label20.Location = new System.Drawing.Point(9, 308);
		this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label20.Name = "label20";
		this.label20.Size = new System.Drawing.Size(126, 21);
		this.label20.TabIndex = 14;
		this.label20.Text = "Name to Save : ";
		this.txtCCSaveName.BackColor = System.Drawing.SystemColors.Control;
		this.txtCCSaveName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtCCSaveName.Enabled = false;
		this.txtCCSaveName.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtCCSaveName.Location = new System.Drawing.Point(192, 304);
		this.txtCCSaveName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.txtCCSaveName.MaxLength = 15;
		this.txtCCSaveName.Name = "txtCCSaveName";
		this.txtCCSaveName.Size = new System.Drawing.Size(237, 23);
		this.txtCCSaveName.TabIndex = 15;
		this.cboCardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboCardType.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboCardType.FormattingEnabled = true;
		System.Windows.Forms.ComboBox.ObjectCollection items3 = this.cboCardType.Items;
		items3.AddRange(new object[3] { "Visa", "Master", "Rupay" });
		this.cboCardType.Location = new System.Drawing.Point(192, 124);
		this.cboCardType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.cboCardType.Name = "cboCardType";
		this.cboCardType.Size = new System.Drawing.Size(125, 26);
		this.cboCardType.TabIndex = 4;
		this.label5.AutoSize = true;
		this.label5.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.label5.Location = new System.Drawing.Point(9, 130);
		this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(96, 21);
		this.label5.TabIndex = 3;
		this.label5.Text = "Card Type : ";
		this.B0AAA.AutoSize = true;
		this.B0AAA.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.B0AAA.Location = new System.Drawing.Point(310, 251);
		this.B0AAA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.B0AAA.Name = "label6";
		this.B0AAA.Size = new System.Drawing.Size(44, 16);
		this.B0AAA.TabIndex = 12;
		this.B0AAA.Text = "CVV :";
		this.C0AA0.BackColor = System.Drawing.Color.FromArgb(235, 248, 239);
		this.C0AA0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.C0AA0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.C0AA0.Location = new System.Drawing.Point(364, 248);
		this.C0AA0.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.C0AA0.MaxLength = 3;
		this.C0AA0.Name = "txtCreditCVV";
		this.C0AA0.Size = new System.Drawing.Size(66, 23);
		this.C0AA0.TabIndex = 13;
		this.label7.AutoSize = true;
		this.label7.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.label7.Location = new System.Drawing.Point(9, 251);
		this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(121, 21);
		this.label7.TabIndex = 10;
		this.label7.Text = "Card ATM Pin : ";
		this.cboCreditYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboCreditYear.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboCreditYear.FormattingEnabled = true;
		this.cboCreditYear.Location = new System.Drawing.Point(306, 186);
		this.cboCreditYear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.cboCreditYear.Name = "cboCreditYear";
		this.cboCreditYear.Size = new System.Drawing.Size(123, 26);
		this.cboCreditYear.TabIndex = 9;
		this.cboCreditMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboCreditMonth.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cboCreditMonth.FormattingEnabled = true;
		System.Windows.Forms.ComboBox.ObjectCollection items4 = this.cboCreditMonth.Items;
		items4.AddRange(new object[12]
		{
			"01", "02", "03", "04", "05", "06", "07", "08", "09", "10",
			"11", "12"
		});
		this.cboCreditMonth.Location = new System.Drawing.Point(192, 186);
		this.cboCreditMonth.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.cboCreditMonth.Name = "cboCreditMonth";
		this.cboCreditMonth.Size = new System.Drawing.Size(79, 26);
		this.cboCreditMonth.TabIndex = 8;
		this.txtCreditVisaPin.BackColor = System.Drawing.Color.FromArgb(235, 248, 239);
		this.txtCreditVisaPin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtCreditVisaPin.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtCreditVisaPin.Location = new System.Drawing.Point(192, 248);
		this.txtCreditVisaPin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.txtCreditVisaPin.MaxLength = 15;
		this.txtCreditVisaPin.Name = "txtCreditVisaPin";
		this.txtCreditVisaPin.Size = new System.Drawing.Size(98, 23);
		this.txtCreditVisaPin.TabIndex = 11;
		this.txtCreditNo.BackColor = System.Drawing.Color.FromArgb(235, 248, 239);
		this.txtCreditNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtCreditNo.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtCreditNo.Location = new System.Drawing.Point(192, 158);
		this.txtCreditNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.txtCreditNo.MaxLength = 20;
		this.txtCreditNo.Name = "txtCreditNo";
		this.txtCreditNo.Size = new System.Drawing.Size(237, 23);
		this.txtCreditNo.TabIndex = 6;
		this.txtCreditNo.TextChanged += new System.EventHandler(txtCreditNo_TextChanged);
		this.label9.AutoSize = true;
		this.label9.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.label9.Location = new System.Drawing.Point(9, 192);
		this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(190, 21);
		this.label9.TabIndex = 7;
		this.label9.Text = "Valid Thru/Expiry Date : ";
		this.label12.AutoSize = true;
		this.label12.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.label12.Location = new System.Drawing.Point(9, 160);
		this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label12.Name = "label12";
		this.label12.Size = new System.Drawing.Size(87, 21);
		this.label12.TabIndex = 5;
		this.label12.Text = "Card No. : ";
		this.B1AAA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.B1AAA.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.B1AAA.FormattingEnabled = true;
		this.B1AAA.Location = new System.Drawing.Point(192, 91);
		this.B1AAA.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.B1AAA.Name = "cboCreditBank";
		this.B1AAA.Size = new System.Drawing.Size(179, 26);
		this.B1AAA.TabIndex = 2;
		this.label13.AutoSize = true;
		this.label13.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.label13.Location = new System.Drawing.Point(9, 98);
		this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label13.Name = "label13";
		this.label13.Size = new System.Drawing.Size(109, 21);
		this.label13.TabIndex = 1;
		this.label13.Text = "Bank Name : ";
		this.btnCreditSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnCreditSave.BackColor = System.Drawing.Color.FloralWhite;
		this.btnCreditSave.Font = new System.Drawing.Font("Corbel", 9.75f, System.Drawing.FontStyle.Bold);
		this.btnCreditSave.ForeColor = System.Drawing.Color.FromArgb(64, 62, 101);
		this.btnCreditSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnCreditSave.Location = new System.Drawing.Point(190, 349);
		this.btnCreditSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.btnCreditSave.Name = "btnCreditSave";
		this.btnCreditSave.Size = new System.Drawing.Size(240, 31);
		this.btnCreditSave.TabIndex = 18;
		this.btnCreditSave.Text = "&Save";
		this.btnCreditSave.UseVisualStyleBackColor = false;
		this.btnCreditSave.Click += new System.EventHandler(btnCreditSave_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(120f, 120f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.BackColor = System.Drawing.Color.FromArgb(0, 127, 166);
		base.Controls.Add(this.panel6);
		base.Controls.Add(this.pnlCredit);
		base.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		base.Name = "tabCreditCard";
		base.Size = new System.Drawing.Size(925, 391);
		base.Load += new System.EventHandler(tabCreditCard_Load);
		this.panel6.ResumeLayout(false);
		this.pnlCredit.ResumeLayout(false);
		this.pnlCredit.PerformLayout();
		base.ResumeLayout(false);
	}
}
