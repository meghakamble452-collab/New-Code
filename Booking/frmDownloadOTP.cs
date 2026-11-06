using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

namespace Booking;

public class frmDownloadOTP : Form
{
	private IContainer icontainer_0;

	private BunifuElipse bunifuElipse_0;

	private BunifuDragControl bunifuDragControl_0;

	private Panel panel1;

	private Button OK;

	private PictureBox pictureBox1;

	private Panel panel2;

	private Label BAAAA;

	private LinkLabel CAAA0;

	private Label label1;

	public frmDownloadOTP()
	{
		InitializeComponent();
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
		this.icontainer_0 = new System.ComponentModel.Container();
		this.bunifuElipse_0 = new Bunifu.Framework.UI.BunifuElipse(this.icontainer_0);
		this.bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(this.icontainer_0);
		this.panel1 = new System.Windows.Forms.Panel();
		this.OK = new System.Windows.Forms.Button();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.label1 = new System.Windows.Forms.Label();
		this.CAAA0 = new System.Windows.Forms.LinkLabel();
		this.BAAAA = new System.Windows.Forms.Label();
		this.panel2 = new System.Windows.Forms.Panel();
		this.panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		base.SuspendLayout();
		this.bunifuElipse_0.ElipseRadius = 5;
		this.bunifuElipse_0.TargetControl = this;
		this.bunifuDragControl_0.Fixed = true;
		this.bunifuDragControl_0.Horizontal = true;
		this.bunifuDragControl_0.TargetControl = null;
		this.bunifuDragControl_0.Vertical = true;
		this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
		this.panel1.Controls.Add(this.OK);
		this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.panel1.Location = new System.Drawing.Point(0, 378);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(457, 45);
		this.panel1.TabIndex = 9;
		this.OK.Location = new System.Drawing.Point(370, 8);
		this.OK.Name = "OK";
		this.OK.Size = new System.Drawing.Size(75, 25);
		this.OK.TabIndex = 0;
		this.OK.Text = "Exit";
		this.OK.UseVisualStyleBackColor = true;
		this.OK.Click += new System.EventHandler(OK_Click);
		this.pictureBox1.Location = new System.Drawing.Point(111, 12);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new System.Drawing.Size(200, 200);
		this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
		this.pictureBox1.TabIndex = 10;
		this.pictureBox1.TabStop = false;
		this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.Location = new System.Drawing.Point(37, 215);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(391, 43);
		this.label1.TabIndex = 11;
		this.label1.Text = "OTP App Download Kare ke Liye yeh QR Code Kisi Bhi QR Code Scanner Se Scan Kijiye";
		this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.CAAA0.AutoSize = true;
		this.CAAA0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.CAAA0.Location = new System.Drawing.Point(12, 327);
		this.CAAA0.Name = "linkLabel1";
		this.CAAA0.Size = new System.Drawing.Size(382, 18);
		this.CAAA0.TabIndex = 12;
		this.CAAA0.TabStop = true;
		this.CAAA0.Text = "http://nexus-india.com/secure/downloadotpreader.php";
		this.BAAAA.AutoSize = true;
		this.BAAAA.Location = new System.Drawing.Point(170, 300);
		this.BAAAA.Name = "label2";
		this.BAAAA.Size = new System.Drawing.Size(141, 17);
		this.BAAAA.TabIndex = 13;
		this.BAAAA.Text = "Direct Download Link";
		this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
		this.panel2.Location = new System.Drawing.Point(-6, 282);
		this.panel2.Name = "panel2";
		this.panel2.Size = new System.Drawing.Size(480, 15);
		this.panel2.TabIndex = 14;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(457, 423);
		base.Controls.Add(this.panel2);
		base.Controls.Add(this.BAAAA);
		base.Controls.Add(this.CAAA0);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.pictureBox1);
		base.Controls.Add(this.panel1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "frmDownloadOTP";
		base.ShowIcon = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "frmDownloadOTP";
		this.panel1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
