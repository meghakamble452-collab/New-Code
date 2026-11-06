using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using Booking.Properties;

namespace APP_FRAMEWORK;

internal class tabMobikwSetting : UserControl
{
	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private CookieContainer BAAAA;

	private Dictionary<string, string> CAAA0;

	internal string string_1;

	internal string string_2;

	internal string string_3;

	internal string string_4;

	internal string string_5;

	internal string string_6;

	internal string Brwpath;

	internal string string_7;

	internal string string_8;

	internal string string_9;

	internal string string_10;

	internal string string_11;

	internal string string_12;

	internal string string_13;

	private IDisposable idisposable_0;

	private IContainer icontainer_0;

	private ProgressBar progressBar1;

	private Timer timer_0;

	private GroupBox groupBox8;

	internal Button btnNew5;

	public Button button16;

	private ComboBox cmbBanks5;

	private Label label46;

	private Label label2;

	private Label lblStatus1;

	public tabMobikwSetting()
	{
		InitializeComponent();
	}

	private void tabMobikwSetting_Load(object sender, EventArgs e)
	{
		CAAA0 = new Dictionary<string, string>();
		int_2 = 0;
		string_1 = "";
		string_2 = "";
		string_3 = "";
		string_4 = "";
		string_5 = "";
		string_6 = "";
		string_7 = "";
		string_8 = "";
		string_9 = "";
		string_10 = "";
		Brwpath = "";
		int_1 = 4;
		method_0();
	}

	private void method_0()
	{
		new DataTable();
		cmbBanks5.Items.Clear();
		ComboBox.ObjectCollection items = cmbBanks5.Items;
		string item = "Select Bank Account";
		items.Add(item);
		Dictionary<string, string> dictionary = Staticm.MOBIKW();
		foreach (string key in dictionary.Keys)
		{
			CAAA0.Add(key, dictionary[key]);
			cmbBanks5.Items.Add(key);
		}
		cmbBanks5.SelectedIndex = 0;
	}

	private void cmbBanks5_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (cmbBanks5.SelectedIndex > 0)
		{
			string_2 = cmbBanks5.SelectedItem.ToString();
			string_3 = CAAA0[string_2];
			string text = string_3;
			string[] array = new string[1];
			string text2 = "||";
			array[0] = text2;
			string[] array2 = text.Split(array, StringSplitOptions.RemoveEmptyEntries);
			if (array2.Length == 2)
			{
				string_4 = array2[0];
				string_5 = array2[1];
			}
			if (array2.Length > 2)
			{
				string text3 = "OTP is already By-Passed for ";
				string text4 = string_2;
				string text5 = "\r\n\r\nIf you want to setup again then Delete the bank and Add again.";
				string text6 = text3 + text4 + text5;
				string caption = "Already By-Passed";
				MessageBox.Show(text6, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				Button button = btnNew5;
				string text7 = "Get OTP";
				button.Text = text7;
			}
		}
	}

	private void btnNew5_Click(object sender, EventArgs e)
	{
		string text = "MobiKwik||";
		string key = text + string_3;
		Program.mcommInstance_.GetData(key);
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
		this.groupBox8 = new System.Windows.Forms.GroupBox();
		this.btnNew5 = new System.Windows.Forms.Button();
		this.cmbBanks5 = new System.Windows.Forms.ComboBox();
		this.label46 = new System.Windows.Forms.Label();
		this.lblStatus1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.button16 = new System.Windows.Forms.Button();
		this.progressBar1 = new System.Windows.Forms.ProgressBar();
		this.timer_0 = new System.Windows.Forms.Timer(this.icontainer_0);
		this.groupBox8.SuspendLayout();
		base.SuspendLayout();
		this.groupBox8.Controls.Add(this.cmbBanks5);
		this.groupBox8.Controls.Add(this.label46);
		this.groupBox8.Controls.Add(this.btnNew5);
		this.groupBox8.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold);
		this.groupBox8.ForeColor = System.Drawing.Color.Black;
		this.groupBox8.Location = new System.Drawing.Point(2, 2);
		this.groupBox8.Name = "groupBox8";
		this.groupBox8.Size = new System.Drawing.Size(484, 272);
		this.groupBox8.TabIndex = 1;
		this.groupBox8.TabStop = false;
		this.groupBox8.Text = "By-Pass MOBIKWIK";
		this.btnNew5.BackColor = System.Drawing.Color.Transparent;
		this.btnNew5.Font = new System.Drawing.Font("Arial", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnNew5.ForeColor = System.Drawing.Color.Black;
		this.btnNew5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnNew5.Location = new System.Drawing.Point(353, 58);
		this.btnNew5.Name = "btnNew5";
		this.btnNew5.Size = new System.Drawing.Size(108, 25);
		this.btnNew5.TabIndex = 53;
		this.btnNew5.Text = "     Bypass New";
		this.btnNew5.UseVisualStyleBackColor = false;
		this.btnNew5.Click += new System.EventHandler(btnNew5_Click);
		this.cmbBanks5.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
		this.cmbBanks5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbBanks5.ForeColor = System.Drawing.Color.Black;
		this.cmbBanks5.FormattingEnabled = true;
		this.cmbBanks5.Location = new System.Drawing.Point(186, 19);
		this.cmbBanks5.Name = "cmbBanks5";
		this.cmbBanks5.Size = new System.Drawing.Size(275, 22);
		this.cmbBanks5.TabIndex = 1170;
		this.cmbBanks5.SelectedIndexChanged += new System.EventHandler(cmbBanks5_SelectedIndexChanged);
		this.label46.AutoSize = true;
		this.label46.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label46.ForeColor = System.Drawing.Color.Black;
		this.label46.Location = new System.Drawing.Point(100, 22);
		this.label46.Name = "label46";
		this.label46.Size = new System.Drawing.Size(80, 14);
		this.label46.TabIndex = 1169;
		this.label46.Text = "Select Bank : ";
		this.lblStatus1.AutoSize = true;
		this.lblStatus1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblStatus1.ForeColor = System.Drawing.Color.Black;
		this.lblStatus1.Location = new System.Drawing.Point(884, 246);
		this.lblStatus1.Name = "lblStatus1";
		this.lblStatus1.Size = new System.Drawing.Size(97, 16);
		this.lblStatus1.TabIndex = 1179;
		this.lblStatus1.Text = "Surfing Status";
		this.label2.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label2.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.label2.Location = new System.Drawing.Point(504, 230);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(477, 32);
		this.label2.TabIndex = 1176;
		this.label2.Text = "Note : ";
		this.label2.Visible = false;
		this.button16.BackColor = System.Drawing.Color.Transparent;
		this.button16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.button16.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button16.ForeColor = System.Drawing.Color.Black;
		this.button16.Image = Booking.Properties.Resources.BullletIcon;
		this.button16.Location = new System.Drawing.Point(600, 37);
		this.button16.Name = "button16";
		this.button16.Size = new System.Drawing.Size(42, 22);
		this.button16.TabIndex = 1175;
		this.button16.UseVisualStyleBackColor = false;
		this.progressBar1.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
		this.progressBar1.ForeColor = System.Drawing.Color.Black;
		this.progressBar1.Location = new System.Drawing.Point(2, 276);
		this.progressBar1.Name = "progressBar1";
		this.progressBar1.Size = new System.Drawing.Size(484, 11);
		this.progressBar1.TabIndex = 1180;
		base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.BackColor = System.Drawing.Color.FromArgb(0, 127, 166);
		base.Controls.Add(this.lblStatus1);
		base.Controls.Add(this.groupBox8);
		base.Controls.Add(this.button16);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.progressBar1);
		this.DoubleBuffered = true;
		base.Name = "tabMobikwSetting";
		base.Size = new System.Drawing.Size(491, 278);
		base.Load += new System.EventHandler(tabMobikwSetting_Load);
		this.groupBox8.ResumeLayout(false);
		this.groupBox8.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
