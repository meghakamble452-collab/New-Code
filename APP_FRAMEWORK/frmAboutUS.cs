using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

namespace APP_FRAMEWORK;

public class frmAboutUS : Form
{
	private IContainer icontainer_0;

	private BunifuElipse bunifuElipse_0;

	private Label lblversion;

	private Label lblvalid;

	private Label lblkey;

	private Label CAAA0;

	private Label label2;

	private Label label1;

	private Panel panel1;

	private IContainer components;

	private Button OK;

	private Label label3;

	private Label label4;

	public frmAboutUS()
	{
		InitializeComponent();
	}

	private void frmAboutUS_Load(object sender, EventArgs e)
	{
		lblkey.Text = Program.clientID;
		lblvalid.Text = Program.ExpiryDay.ToString();
		lblversion.Text = frmLogin.appversion;
		string text = Program.KeyType;
		if (frmLogin.isPremium)
		{
			string text2 = "ADVANCE Version";
			text = text2;
		}
		label3.Text = text;
	}

	private void OK_Click(object sender, EventArgs e)
	{
		Close();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		this.bunifuElipse_0 = new Bunifu.Framework.UI.BunifuElipse(this.components);
		this.label1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.CAAA0 = new System.Windows.Forms.Label();
		this.lblkey = new System.Windows.Forms.Label();
		this.lblvalid = new System.Windows.Forms.Label();
		this.lblversion = new System.Windows.Forms.Label();
		this.panel1 = new System.Windows.Forms.Panel();
		this.OK = new System.Windows.Forms.Button();
		this.label3 = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.panel1.SuspendLayout();
		base.SuspendLayout();
		this.bunifuElipse_0.ElipseRadius = 5;
		this.bunifuElipse_0.TargetControl = this;
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(9, 14);
		this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(90, 13);
		this.label1.TabIndex = 0;
		this.label1.Text = "Your License Key";
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(9, 51);
		this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(89, 13);
		this.label2.TabIndex = 1;
		this.label2.Text = "Expiry (Left Days)";
		this.CAAA0.AutoSize = true;
		this.CAAA0.Location = new System.Drawing.Point(9, 91);
		this.CAAA0.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.CAAA0.Name = "CAAA0";
		this.CAAA0.Size = new System.Drawing.Size(97, 13);
		this.CAAA0.TabIndex = 2;
		this.CAAA0.Text = "Application Version";
		this.lblkey.AutoSize = true;
		this.lblkey.Location = new System.Drawing.Point(137, 14);
		this.lblkey.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.lblkey.Name = "lblkey";
		this.lblkey.Size = new System.Drawing.Size(13, 13);
		this.lblkey.TabIndex = 4;
		this.lblkey.Text = "0";
		this.lblvalid.AutoSize = true;
		this.lblvalid.Location = new System.Drawing.Point(137, 51);
		this.lblvalid.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.lblvalid.Name = "lblvalid";
		this.lblvalid.Size = new System.Drawing.Size(13, 13);
		this.lblvalid.TabIndex = 6;
		this.lblvalid.Text = "0";
		this.lblversion.AutoSize = true;
		this.lblversion.Location = new System.Drawing.Point(137, 91);
		this.lblversion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.lblversion.Name = "lblversion";
		this.lblversion.Size = new System.Drawing.Size(13, 13);
		this.lblversion.TabIndex = 7;
		this.lblversion.Text = "0";
		this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
		this.panel1.Controls.Add(this.OK);
		this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.panel1.Location = new System.Drawing.Point(0, 184);
		this.panel1.Margin = new System.Windows.Forms.Padding(2);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(227, 37);
		this.panel1.TabIndex = 8;
		this.OK.Location = new System.Drawing.Point(162, 8);
		this.OK.Margin = new System.Windows.Forms.Padding(2);
		this.OK.Name = "OK";
		this.OK.Size = new System.Drawing.Size(56, 20);
		this.OK.TabIndex = 0;
		this.OK.Text = "OK";
		this.OK.UseVisualStyleBackColor = true;
		this.OK.Click += new System.EventHandler(OK_Click);
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(118, 133);
		this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(13, 13);
		this.label3.TabIndex = 10;
		this.label3.Text = "0";
		this.label4.AutoSize = true;
		this.label4.Location = new System.Drawing.Point(9, 133);
		this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(52, 13);
		this.label4.TabIndex = 9;
		this.label4.Text = "Key Type";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(227, 221);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.panel1);
		base.Controls.Add(this.lblversion);
		base.Controls.Add(this.lblvalid);
		base.Controls.Add(this.lblkey);
		base.Controls.Add(this.CAAA0);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(2);
		base.Name = "frmAboutUS";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "frmAboutUS";
		base.TopMost = true;
		base.Load += new System.EventHandler(frmAboutUS_Load);
		this.panel1.ResumeLayout(false);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
