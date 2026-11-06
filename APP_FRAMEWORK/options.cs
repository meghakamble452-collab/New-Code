using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

namespace APP_FRAMEWORK;

public class options : Form
{
	private IContainer components = null;

	private Panel pnlHeader;

	private Label label50;

	private Button btnFindTrain;

	private Button button1;

	private Button button2;

	private Button button3;

	private BunifuImageButton btnClose;

	public options()
	{
		InitializeComponent();
	}

	private void button3_Click(object sender, EventArgs e)
	{
		frmAboutUS frmAboutUS2 = new frmAboutUS();
		frmAboutUS2.Show();
		frmAboutUS2.Activate();
	}

	private void button2_Click(object sender, EventArgs e)
	{
		frmNotes frmNotes2 = new frmNotes(3, 0);
		frmNotes2.Activate();
		frmNotes2.Show();
	}

	private void btnFindTrain_Click(object sender, EventArgs e)
	{
		frmShowHistory frmShowHistory2 = new frmShowHistory();
		frmShowHistory2.Show();
		frmShowHistory2.Activate();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		new frmProxySetting().Show();
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		Close();
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(APP_FRAMEWORK.options));
		this.pnlHeader = new System.Windows.Forms.Panel();
		this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
		this.label50 = new System.Windows.Forms.Label();
		this.btnFindTrain = new System.Windows.Forms.Button();
		this.button1 = new System.Windows.Forms.Button();
		this.button2 = new System.Windows.Forms.Button();
		this.button3 = new System.Windows.Forms.Button();
		this.pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.btnClose).BeginInit();
		base.SuspendLayout();
		this.pnlHeader.BackColor = System.Drawing.Color.MediumSlateBlue;
		this.pnlHeader.Controls.Add(this.btnClose);
		this.pnlHeader.Controls.Add(this.label50);
		this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
		this.pnlHeader.ForeColor = System.Drawing.Color.FromArgb(17, 17, 18);
		this.pnlHeader.Location = new System.Drawing.Point(0, 0);
		this.pnlHeader.Name = "pnlHeader";
		this.pnlHeader.Size = new System.Drawing.Size(421, 23);
		this.pnlHeader.TabIndex = 1212;
		this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.btnClose.BackColor = System.Drawing.Color.Transparent;
		this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
		this.btnClose.Image = (System.Drawing.Image)resources.GetObject("btnClose.Image");
		this.btnClose.ImageActive = null;
		this.btnClose.Location = new System.Drawing.Point(398, 0);
		this.btnClose.Margin = new System.Windows.Forms.Padding(2);
		this.btnClose.Name = "btnClose";
		this.btnClose.Size = new System.Drawing.Size(23, 23);
		this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.btnClose.TabIndex = 2;
		this.btnClose.TabStop = false;
		this.btnClose.Zoom = 10;
		this.btnClose.Click += new System.EventHandler(btnClose_Click);
		this.label50.AutoSize = true;
		this.label50.BackColor = System.Drawing.Color.Transparent;
		this.label50.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label50.Location = new System.Drawing.Point(3, 1);
		this.label50.Name = "label50";
		this.label50.Size = new System.Drawing.Size(220, 20);
		this.label50.TabIndex = 0;
		this.label50.Text = "Sky UPI / OTP Bypass Setting";
		this.btnFindTrain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
		this.btnFindTrain.Cursor = System.Windows.Forms.Cursors.Hand;
		this.btnFindTrain.FlatAppearance.BorderSize = 0;
		this.btnFindTrain.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.btnFindTrain.Font = new System.Drawing.Font("Sitka Text", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.btnFindTrain.ForeColor = System.Drawing.Color.Black;
		this.btnFindTrain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnFindTrain.Location = new System.Drawing.Point(7, 31);
		this.btnFindTrain.Name = "btnFindTrain";
		this.btnFindTrain.Size = new System.Drawing.Size(201, 25);
		this.btnFindTrain.TabIndex = 1213;
		this.btnFindTrain.Text = "Check Booking Histry";
		this.btnFindTrain.UseVisualStyleBackColor = false;
		this.btnFindTrain.Click += new System.EventHandler(btnFindTrain_Click);
		this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
		this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
		this.button1.FlatAppearance.BorderSize = 0;
		this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.button1.Font = new System.Drawing.Font("Sitka Text", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.button1.ForeColor = System.Drawing.Color.Black;
		this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.button1.Location = new System.Drawing.Point(214, 31);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(201, 25);
		this.button1.TabIndex = 1214;
		this.button1.Text = "Manage Proxy";
		this.button1.UseVisualStyleBackColor = false;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
		this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
		this.button2.FlatAppearance.BorderSize = 0;
		this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.button2.Font = new System.Drawing.Font("Sitka Text", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.button2.ForeColor = System.Drawing.Color.Black;
		this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.button2.Location = new System.Drawing.Point(214, 62);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(201, 25);
		this.button2.TabIndex = 1216;
		this.button2.Text = "Read News";
		this.button2.UseVisualStyleBackColor = false;
		this.button2.Click += new System.EventHandler(button2_Click);
		this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
		this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
		this.button3.FlatAppearance.BorderSize = 0;
		this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.button3.Font = new System.Drawing.Font("Sitka Text", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.button3.ForeColor = System.Drawing.Color.Black;
		this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.button3.Location = new System.Drawing.Point(7, 62);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(201, 25);
		this.button3.TabIndex = 1215;
		this.button3.Text = "About Us";
		this.button3.UseVisualStyleBackColor = false;
		this.button3.Click += new System.EventHandler(button3_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.Snow;
		base.ClientSize = new System.Drawing.Size(421, 102);
		base.Controls.Add(this.button2);
		base.Controls.Add(this.button3);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.btnFindTrain);
		base.Controls.Add(this.pnlHeader);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "options";
		this.Text = "options";
		this.pnlHeader.ResumeLayout(false);
		this.pnlHeader.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.btnClose).EndInit();
		base.ResumeLayout(false);
	}
}
