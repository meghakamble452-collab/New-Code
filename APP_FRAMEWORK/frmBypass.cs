using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

namespace APP_FRAMEWORK;

public class frmBypass : Form
{
	private IContainer components = null;

	private Panel pnlHeader;

	private BunifuImageButton btnClose;

	private Label label50;

	private Button btnFindTrain;

	private Button button1;

	public frmBypass()
	{
		InitializeComponent();
		pnlHeader.MouseDown += StatClass.Header_MouseDown;
		pnlHeader.MouseMove += StatClass.Header_MouseMove;
		pnlHeader.MouseUp += StatClass.Header_MouseUp;
	}

	private void btnFindTrain_Click(object sender, EventArgs e)
	{
		new Freecharge().ShowDialog();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		new frmSBI().Show();
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void frmBypass_Load(object sender, EventArgs e)
	{
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(APP_FRAMEWORK.frmBypass));
		this.pnlHeader = new System.Windows.Forms.Panel();
		this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
		this.label50 = new System.Windows.Forms.Label();
		this.btnFindTrain = new System.Windows.Forms.Button();
		this.button1 = new System.Windows.Forms.Button();
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
		this.pnlHeader.Size = new System.Drawing.Size(333, 23);
		this.pnlHeader.TabIndex = 1211;
		this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnClose.BackColor = System.Drawing.Color.Transparent;
		this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.btnClose.Image = (System.Drawing.Image)resources.GetObject("btnClose.Image");
		this.btnClose.ImageActive = null;
		this.btnClose.Location = new System.Drawing.Point(309, 0);
		this.btnClose.Name = "btnClose";
		this.btnClose.Size = new System.Drawing.Size(21, 21);
		this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.btnClose.TabIndex = 1;
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
		this.btnFindTrain.Location = new System.Drawing.Point(2, 29);
		this.btnFindTrain.Name = "btnFindTrain";
		this.btnFindTrain.Size = new System.Drawing.Size(324, 25);
		this.btnFindTrain.TabIndex = 1212;
		this.btnFindTrain.Text = "FreeCharge UPI Bypass";
		this.btnFindTrain.UseVisualStyleBackColor = false;
		this.btnFindTrain.Click += new System.EventHandler(btnFindTrain_Click);
		this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
		this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
		this.button1.FlatAppearance.BorderSize = 0;
		this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
		this.button1.Font = new System.Drawing.Font("Sitka Text", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.button1.ForeColor = System.Drawing.Color.Black;
		this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.button1.Location = new System.Drawing.Point(2, 60);
		this.button1.Name = "button1";
		this.button1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
		this.button1.Size = new System.Drawing.Size(324, 25);
		this.button1.TabIndex = 1213;
		this.button1.Text = "SBI Net Banking OTP Bypass";
		this.button1.UseVisualStyleBackColor = false;
		this.button1.Click += new System.EventHandler(button1_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.GhostWhite;
		base.ClientSize = new System.Drawing.Size(333, 100);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.btnFindTrain);
		base.Controls.Add(this.pnlHeader);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "frmBypass";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "frmBypass";
		base.Load += new System.EventHandler(frmBypass_Load);
		this.pnlHeader.ResumeLayout(false);
		this.pnlHeader.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.btnClose).EndInit();
		base.ResumeLayout(false);
	}
}
