using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

namespace APP_FRAMEWORK;

internal class frmOTP : Form
{
	private bool bool_0;

	internal string string_0;

	internal bool bool_1;

	internal int int_0;

	internal int int_1;

	internal int int_2;

	private string string_1;

	private IContainer icontainer_0;

	private IDisposable BAAAA;

	private TextBox CAAA0;

	private Label lblTime;

	internal Button btnOk;

	private ComboBox cboSeconds;

	private Label lblDot;

	private ComboBox cboPartSeconds;

	private Label label1;

	private Label lblOTP;

	private Label lblPTMsg;

	internal Button btnOkkk;

	internal Button btnOkk;

	private Label label2;

	private TextBox txtOTP;

	private Panel B0AAA;

	private BunifuImageButton C0AA0;

	private Label label3;

	public frmOTP(bool bool_2, string string_2)
	{
		string_0 = "";
		bool_1 = true;
		string_1 = "";
		InitializeComponent();
		B0AAA.MouseDown += StatClass.Header_MouseDown;
		B0AAA.MouseMove += StatClass.Header_MouseMove;
		B0AAA.MouseUp += StatClass.Header_MouseUp;
		bool_0 = bool_2;
		string_1 = string_2;
	}

	private void frmOTP_Load(object sender, EventArgs e)
	{
		if (bool_0)
		{
			string text = "OTP for Bank";
			Text = text;
			lblTime.Visible = false;
			cboPartSeconds.Visible = false;
			cboSeconds.Visible = false;
			lblDot.Visible = false;
			label1.Visible = false;
			lblOTP.Visible = true;
			CAAA0.Visible = true;
			string text2 = string_1;
			string value = "IDBI";
			if (text2.Contains(value))
			{
				Label label = lblOTP;
				string text3 = "OSP for IDBI";
				label.Text = text3;
				lblOTP.Left = CAAA0.Left - lblOTP.Width - 5;
			}
			return;
		}
		cboSeconds.Items.Clear();
		for (int i = 1; i <= 28; i++)
		{
			cboSeconds.Items.Add(i.ToString());
		}
		if (int_0 <= 0)
		{
			int_0 = Program.int_4;
		}
		int num = int_0 / 1000;
		int selectedIndex = int_0 % 1000 / 100;
		cboSeconds.SelectedItem = num.ToString();
		cboPartSeconds.SelectedIndex = selectedIndex;
		if (!bool_1)
		{
			CAAA0.Visible = true;
			CAAA0.Text = int_1.ToString();
			CAAA0.Left = cboSeconds.Left;
			lblPTMsg.Visible = true;
		}
		TextBox textBox = txtOTP;
		string variable = "OTP";
		textBox.Text = Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.Process);
		CAAA0.Text = int_2.ToString();
	}

	private void btnOk_Click(object sender, EventArgs e)
	{
		try
		{
			if (!bool_0)
			{
				if (!bool_1)
				{
					int_0 = int.Parse(cboSeconds.SelectedItem.ToString()) * 1000 + int.Parse(cboPartSeconds.SelectedItem.ToString()) * 100;
					int.TryParse(CAAA0.Text.Trim(), out int_1);
					if (int_1 <= 0)
					{
						int_1 = 0;
					}
				}
				else
				{
					string[] array = new string[5];
					string text = "Now Booking captcha will be submitted in ";
					array[0] = text;
					array[1] = cboSeconds.SelectedItem.ToString();
					string text2 = ".";
					array[2] = text2;
					array[3] = cboPartSeconds.SelectedItem.ToString();
					string text3 = " Seconds!";
					array[4] = text3;
					string text4 = string.Concat(array);
					string caption = "Auto Submit Captcha";
					MessageBox.Show(text4, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					Program.int_4 = int.Parse(cboSeconds.SelectedItem.ToString()) * 1000 + int.Parse(cboPartSeconds.SelectedItem.ToString()) * 100;
				}
			}
			else
			{
				TextBox cAAA = CAAA0;
				if (string.IsNullOrEmpty(cAAA.Text) || cAAA.Text.Length < 4 || !Class34.smethod_5(cAAA.Text.Trim()))
				{
					string text5 = "Enter Valid OTP / OSP No.!";
					string caption2 = "OTP";
					MessageBox.Show(text5, caption2, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					cAAA.Focus();
					return;
				}
				string_0 = CAAA0.Text;
			}
		}
		catch
		{
		}
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void btnOkkk_Click(object sender, EventArgs e)
	{
		int_2 = int.Parse(CAAA0.Text);
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void btnOkk_Click(object sender, EventArgs e)
	{
		string variable = "OTP";
		Environment.SetEnvironmentVariable(variable, txtOTP.Text, EnvironmentVariableTarget.Process);
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void method_0(object sender, FormClosingEventArgs e)
	{
	}

	private void C0AA0_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && BAAAA != null)
		{
			BAAAA.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		new System.ComponentModel.ComponentResourceManager(typeof(APP_FRAMEWORK.frmOTP));
		this.CAAA0 = new System.Windows.Forms.TextBox();
		this.lblTime = new System.Windows.Forms.Label();
		this.btnOk = new System.Windows.Forms.Button();
		this.cboSeconds = new System.Windows.Forms.ComboBox();
		this.lblDot = new System.Windows.Forms.Label();
		this.cboPartSeconds = new System.Windows.Forms.ComboBox();
		this.label1 = new System.Windows.Forms.Label();
		this.lblOTP = new System.Windows.Forms.Label();
		this.lblPTMsg = new System.Windows.Forms.Label();
		this.btnOkkk = new System.Windows.Forms.Button();
		this.btnOkk = new System.Windows.Forms.Button();
		this.label2 = new System.Windows.Forms.Label();
		this.txtOTP = new System.Windows.Forms.TextBox();
		this.B0AAA = new System.Windows.Forms.Panel();
		this.C0AA0 = new Bunifu.Framework.UI.BunifuImageButton();
		this.label3 = new System.Windows.Forms.Label();
		this.B0AAA.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.C0AA0).BeginInit();
		base.SuspendLayout();
		this.CAAA0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.CAAA0.Location = new System.Drawing.Point(79, 93);
		this.CAAA0.MaxLength = 20;
		this.CAAA0.Name = "txtFare";
		this.CAAA0.Size = new System.Drawing.Size(80, 20);
		this.CAAA0.TabIndex = 5;
		this.lblTime.AutoSize = true;
		this.lblTime.Font = new System.Drawing.Font("Corbel", 10.25f);
		this.lblTime.Location = new System.Drawing.Point(6, 37);
		this.lblTime.Name = "lblTime";
		this.lblTime.Size = new System.Drawing.Size(83, 17);
		this.lblTime.TabIndex = 4;
		this.lblTime.Text = "Submit Time";
		this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnOk.BackColor = System.Drawing.Color.Transparent;
		this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOk.Location = new System.Drawing.Point(176, 34);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(60, 24);
		this.btnOk.TabIndex = 17;
		this.btnOk.Text = "Save";
		this.btnOk.UseVisualStyleBackColor = false;
		this.btnOk.Click += new System.EventHandler(btnOk_Click);
		this.cboSeconds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboSeconds.FormattingEnabled = true;
		this.cboSeconds.Location = new System.Drawing.Point(79, 34);
		this.cboSeconds.Name = "cboSeconds";
		this.cboSeconds.Size = new System.Drawing.Size(36, 21);
		this.cboSeconds.TabIndex = 19;
		this.lblDot.AutoSize = true;
		this.lblDot.Font = new System.Drawing.Font("Arial Black", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblDot.Location = new System.Drawing.Point(113, 30);
		this.lblDot.Name = "lblDot";
		this.lblDot.Size = new System.Drawing.Size(15, 23);
		this.lblDot.TabIndex = 20;
		this.lblDot.Text = ".";
		this.cboPartSeconds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboPartSeconds.FormattingEnabled = true;
		System.Windows.Forms.ComboBox.ObjectCollection items = this.cboPartSeconds.Items;
		this.cboPartSeconds.Location = new System.Drawing.Point(123, 34);
		this.cboPartSeconds.Name = "cboPartSeconds";
		this.cboPartSeconds.Size = new System.Drawing.Size(36, 21);
		this.cboPartSeconds.TabIndex = 21;
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Corbel", 10.25f);
		this.label1.Location = new System.Drawing.Point(6, 53);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(71, 17);
		this.label1.TabIndex = 22;
		this.label1.Text = "( Seconds )";
		this.lblOTP.AutoSize = true;
		this.lblOTP.Font = new System.Drawing.Font("Corbel", 10.25f);
		this.lblOTP.Location = new System.Drawing.Point(6, 96);
		this.lblOTP.Name = "lblOTP";
		this.lblOTP.Size = new System.Drawing.Size(67, 17);
		this.lblOTP.TabIndex = 23;
		this.lblOTP.Text = "Fare Limit";
		this.lblPTMsg.AutoSize = true;
		this.lblPTMsg.BackColor = System.Drawing.Color.FromArgb(0, 127, 166);
		this.lblPTMsg.Font = new System.Drawing.Font("Book Antiqua", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblPTMsg.ForeColor = System.Drawing.Color.White;
		this.lblPTMsg.Location = new System.Drawing.Point(-1, 116);
		this.lblPTMsg.Name = "lblPTMsg";
		this.lblPTMsg.Size = new System.Drawing.Size(244, 17);
		this.lblPTMsg.TabIndex = 24;
		this.lblPTMsg.Text = "Set Fare limit PT Quota me hi Apply Hoga.";
		this.lblPTMsg.Visible = false;
		this.btnOkkk.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnOkkk.BackColor = System.Drawing.Color.Transparent;
		this.btnOkkk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOkkk.Location = new System.Drawing.Point(176, 92);
		this.btnOkkk.Name = "btnOkkk";
		this.btnOkkk.Size = new System.Drawing.Size(60, 22);
		this.btnOkkk.TabIndex = 1093;
		this.btnOkkk.Text = "Set fare";
		this.btnOkkk.UseVisualStyleBackColor = false;
		this.btnOkkk.Click += new System.EventHandler(btnOkkk_Click);
		this.btnOkk.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnOkk.BackColor = System.Drawing.Color.Transparent;
		this.btnOkk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnOkk.Location = new System.Drawing.Point(176, 64);
		this.btnOkk.Name = "btnOkk";
		this.btnOkk.Size = new System.Drawing.Size(60, 22);
		this.btnOkk.TabIndex = 1096;
		this.btnOkk.Text = "Set otp";
		this.btnOkk.UseVisualStyleBackColor = false;
		this.btnOkk.Click += new System.EventHandler(btnOkk_Click);
		this.label2.AutoSize = true;
		this.label2.Font = new System.Drawing.Font("Corbel", 10.25f);
		this.label2.Location = new System.Drawing.Point(6, 70);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(71, 17);
		this.label2.TabIndex = 1095;
		this.label2.Text = "OTP Setup";
		this.txtOTP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtOTP.Location = new System.Drawing.Point(79, 67);
		this.txtOTP.MaxLength = 20;
		this.txtOTP.Name = "txtOTP";
		this.txtOTP.Size = new System.Drawing.Size(80, 20);
		this.txtOTP.TabIndex = 1094;
		this.B0AAA.BackColor = System.Drawing.Color.FromArgb(0, 127, 166);
		this.B0AAA.Controls.Add(this.C0AA0);
		this.B0AAA.Controls.Add(this.label3);
		this.B0AAA.Dock = System.Windows.Forms.DockStyle.Top;
		this.B0AAA.ForeColor = System.Drawing.Color.FromArgb(17, 17, 18);
		this.B0AAA.Location = new System.Drawing.Point(0, 0);
		this.B0AAA.Name = "pnlHeader";
		this.B0AAA.Size = new System.Drawing.Size(238, 28);
		this.B0AAA.TabIndex = 1209;
		this.C0AA0.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.C0AA0.BackColor = System.Drawing.Color.SeaGreen;
		this.C0AA0.Cursor = System.Windows.Forms.Cursors.Hand;
		this.C0AA0.ImageActive = null;
		this.C0AA0.Location = new System.Drawing.Point(208, 4);
		this.C0AA0.Name = "btnClose";
		this.C0AA0.Size = new System.Drawing.Size(26, 20);
		this.C0AA0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.C0AA0.TabIndex = 1;
		this.C0AA0.TabStop = false;
		this.C0AA0.Zoom = 10;
		this.C0AA0.Click += new System.EventHandler(C0AA0_Click);
		this.label3.AutoSize = true;
		this.label3.Font = new System.Drawing.Font("Corbel", 14.25f);
		this.label3.ForeColor = System.Drawing.Color.White;
		this.label3.Location = new System.Drawing.Point(5, 4);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(79, 23);
		this.label3.TabIndex = 0;
		this.label3.Text = "Set Time";
		base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.BackColor = System.Drawing.Color.FromArgb(0, 127, 166);
		base.ClientSize = new System.Drawing.Size(238, 133);
		base.Controls.Add(this.B0AAA);
		base.Controls.Add(this.btnOkk);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.txtOTP);
		base.Controls.Add(this.btnOkkk);
		base.Controls.Add(this.lblPTMsg);
		base.Controls.Add(this.lblOTP);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.cboPartSeconds);
		base.Controls.Add(this.cboSeconds);
		base.Controls.Add(this.btnOk);
		base.Controls.Add(this.CAAA0);
		base.Controls.Add(this.lblTime);
		base.Controls.Add(this.lblDot);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "frmOTP";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		base.Load += new System.EventHandler(frmOTP_Load);
		this.B0AAA.ResumeLayout(false);
		this.B0AAA.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.C0AA0).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
