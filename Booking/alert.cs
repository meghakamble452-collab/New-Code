using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Bunifu.Framework.UI;

namespace Booking;

public class alert : Form
{
	public static string m1;

	public static string m2;

	public static string m3;

	public static bool demo;

	private IContainer icontainer_0;

	private BunifuElipse bunifuElipse_0;

	private Label label1;

	private Panel panel1;

	private Label BAAAA;

	private Label label2;

	private PictureBox pictureBox2;

	private PictureBox pictureBox1;

	private Label label3;

	private BunifuImageButton btnClose;

	private LinkLabel linkLabel1;

	private BackgroundWorker backgroundWorker1;

	private IContainer components;

	public alert()
	{
		InitializeComponent();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
		Close();
	}

	public void show_(object j)
	{
		ShowDialog();
	}

	private void alert_Load(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(m1))
		{
			BAAAA.Text = m1;
		}
	}

	private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		string text = "";
		try
		{
			string requestUriString = "https://raw.githubusercontent.com/hitmants2026-a11y/Hitman/refs/heads/main/Video";
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
			using StreamReader streamReader = new StreamReader(((HttpWebResponse)httpWebRequest.GetResponse()).GetResponseStream());
			text = streamReader.ReadToEnd();
		}
		catch (WebException)
		{
		}
		string text2 = text;
		string value = "storyxpress.co";
		if (text2.Contains(value))
		{
			Process.Start(text);
		}
	}

	private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
	{
		string fileName = "https://whatsapp.com/channel/0029Va8UiR7Bfxo2PHi90f0J";
		Process.Start(fileName);
	}

	private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		string fileName = "https://t.me/NexusOfficialUserChannel";
		Process.Start(fileName);
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Booking.alert));
		this.bunifuElipse_0 = new Bunifu.Framework.UI.BunifuElipse(this.components);
		this.panel1 = new System.Windows.Forms.Panel();
		this.label3 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.pictureBox2 = new System.Windows.Forms.PictureBox();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.label1 = new System.Windows.Forms.Label();
		this.BAAAA = new System.Windows.Forms.Label();
		this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
		this.linkLabel1 = new System.Windows.Forms.LinkLabel();
		this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
		this.panel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.btnClose).BeginInit();
		base.SuspendLayout();
		this.bunifuElipse_0.ElipseRadius = 5;
		this.bunifuElipse_0.TargetControl = this;
		this.panel1.BackColor = System.Drawing.Color.PowderBlue;
		this.panel1.Controls.Add(this.linkLabel1);
		this.panel1.Controls.Add(this.label3);
		this.panel1.Controls.Add(this.label2);
		this.panel1.Controls.Add(this.pictureBox2);
		this.panel1.Controls.Add(this.pictureBox1);
		this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.panel1.Location = new System.Drawing.Point(0, 439);
		this.panel1.Margin = new System.Windows.Forms.Padding(2);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(732, 124);
		this.panel1.TabIndex = 0;
		this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label3.ForeColor = System.Drawing.Color.Navy;
		this.label3.Location = new System.Drawing.Point(395, 39);
		this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(189, 35);
		this.label3.TabIndex = 4;
		this.label3.Text = "Scan Qr For Join Our Official Teligram Chanel";
		this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label2.ForeColor = System.Drawing.Color.Navy;
		this.label2.Location = new System.Drawing.Point(20, 39);
		this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(209, 35);
		this.label2.TabIndex = 3;
		this.label2.Text = "Scan Qr For Join Our Official Whatsapp Chanel";
		this.pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
		this.pictureBox2.Location = new System.Drawing.Point(589, 3);
		this.pictureBox2.Name = "pictureBox2";
		this.pictureBox2.Size = new System.Drawing.Size(140, 121);
		this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pictureBox2.TabIndex = 2;
		this.pictureBox2.TabStop = false;
		this.pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
		this.pictureBox1.Location = new System.Drawing.Point(235, 2);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new System.Drawing.Size(137, 118);
		this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pictureBox1.TabIndex = 1;
		this.pictureBox1.TabStop = false;
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 17.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.ForeColor = System.Drawing.Color.White;
		this.label1.Location = new System.Drawing.Point(205, 5);
		this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(285, 24);
		this.label1.TabIndex = 1;
		this.label1.Text = "Hitman Important Message";
		this.BAAAA.BackColor = System.Drawing.Color.Azure;
		this.BAAAA.Font = new System.Drawing.Font("Microsoft YaHei", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.BAAAA.ForeColor = System.Drawing.Color.Black;
		this.BAAAA.Location = new System.Drawing.Point(0, 32);
		this.BAAAA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.BAAAA.Name = "BAAAA";
		this.BAAAA.Size = new System.Drawing.Size(730, 406);
		this.BAAAA.TabIndex = 3;
		this.BAAAA.Text = "Bhim UPI ke Server me Proble he, Jis ke wajeh se Kabhi Kabhi Reject From Bank ka Error Aata he, Yeh Software ki Problem Nahi he, Aap kisi Other Gatway ka use karen taki booking fail na ho";
		this.BAAAA.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
		this.btnClose.BackColor = System.Drawing.Color.Transparent;
		this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
		this.btnClose.Image = (System.Drawing.Image)resources.GetObject("btnClose.Image");
		this.btnClose.ImageActive = null;
		this.btnClose.Location = new System.Drawing.Point(707, 4);
		this.btnClose.Margin = new System.Windows.Forms.Padding(2);
		this.btnClose.Name = "btnClose";
		this.btnClose.Size = new System.Drawing.Size(23, 23);
		this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.btnClose.TabIndex = 4;
		this.btnClose.TabStop = false;
		this.btnClose.Zoom = 10;
		this.btnClose.Click += new System.EventHandler(btnClose_Click);
		this.linkLabel1.AutoSize = true;
		this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.linkLabel1.LinkColor = System.Drawing.Color.Red;
		this.linkLabel1.Location = new System.Drawing.Point(1, 90);
		this.linkLabel1.Name = "linkLabel1";
		this.linkLabel1.Size = new System.Drawing.Size(230, 25);
		this.linkLabel1.TabIndex = 5;
		this.linkLabel1.TabStop = true;
		this.linkLabel1.Text = "How use Hitman App";
		this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked_2);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(0, 0, 192);
		base.ClientSize = new System.Drawing.Size(732, 563);
		base.Controls.Add(this.btnClose);
		base.Controls.Add(this.panel1);
		base.Controls.Add(this.BAAAA);
		base.Controls.Add(this.label1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(2);
		base.Name = "alert";
		base.ShowIcon = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "alert";
		base.Load += new System.EventHandler(alert_Load);
		this.panel1.ResumeLayout(false);
		this.panel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.btnClose).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private void btnClose_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void linkLabel1_LinkClicked_2(object sender, LinkLabelLinkClickedEventArgs e)
	{
		Process.Start("https://youtu.be/ufhRl8UK7mU");
	}
}
