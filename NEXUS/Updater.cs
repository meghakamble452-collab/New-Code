using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Bunifu.Framework.UI;

namespace NEXUS;

public class Updater : Form
{
	internal byte[] result;

	private string uRL;

	private Stopwatch stopwatch_0 = new Stopwatch();

	private bool start;

	private IContainer components;

	private BunifuElipse bunifuElipse1;

	private Label B0AAA;

	private Label labelDownloaded;

	private Label C0AA0;

	private Label lblstatus;

	private Button button1;

	private BunifuProgressBar bunifuProgressBar1;

	private Timer timer_0;

	public Updater()
	{
		InitializeComponent();
		ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
	}

	private void Updater_Load(object sender, EventArgs e)
	{
		timer_0.Enabled = true;
	}

	public void startDownload(string pUri)
	{
		uRL = pUri;
		ShowDialog();
	}

	private void method_0()
	{
		try
		{
			new WebClient();
			new WebClient();
			WebClient webClient = new WebClient();
			webClient.Proxy = null;
			webClient.Encoding = Encoding.UTF8;
			UriBuilder uriBuilder = new UriBuilder(uRL);
			webClient.DownloadProgressChanged += webClient_0_DownloadProgressChanged;
			webClient.DownloadDataCompleted += webClient_0_DownloadDataCompleted1;
			webClient.DownloadDataAsync(uriBuilder.Uri);
			stopwatch_0.Start();
		}
		catch (Exception)
		{
		}
	}

	private void webClient_0_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
	{
		try
		{
			Label c0AA = C0AA0;
			string format = "{0} Kbps";
			double num = (double)e.BytesReceived / 1024.0 / stopwatch_0.Elapsed.TotalSeconds;
			string text = "0.00";
			c0AA.Text = string.Format(format, num.ToString(text));
			Label b0AAA = B0AAA;
			string text2 = "File Size _  ";
			num = (double)e.TotalBytesToReceive / 1024.0 / 1024.0;
			string text3 = "0.00";
			string text4 = num.ToString(text3);
			string text5 = " / MB";
			b0AAA.Text = text2 + text4 + text5;
			Label label = labelDownloaded;
			string text6 = e.ProgressPercentage.ToString();
			string text7 = "%";
			label.Text = text6 + text7;
			bunifuProgressBar1.Value = e.ProgressPercentage;
		}
		catch (Exception)
		{
		}
	}

	private void webClient_0_DownloadDataCompleted1(object sender, DownloadDataCompletedEventArgs e)
	{
		if (e.Error == null && !e.Cancelled)
		{
			result = e.Result;
			Close();
		}
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (!start)
		{
			start = true;
			method_0();
		}
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
		this.B0AAA = new System.Windows.Forms.Label();
		this.labelDownloaded = new System.Windows.Forms.Label();
		this.C0AA0 = new System.Windows.Forms.Label();
		this.lblstatus = new System.Windows.Forms.Label();
		this.button1 = new System.Windows.Forms.Button();
		this.timer_0 = new System.Windows.Forms.Timer(this.components);
		this.bunifuProgressBar1 = new Bunifu.Framework.UI.BunifuProgressBar();
		base.SuspendLayout();
		this.bunifuElipse1.ElipseRadius = 5;
		this.bunifuElipse1.TargetControl = this;
		this.B0AAA.AutoSize = true;
		this.B0AAA.BackColor = System.Drawing.Color.Transparent;
		this.B0AAA.Font = new System.Drawing.Font("DS-Digital", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.B0AAA.ForeColor = System.Drawing.Color.Black;
		this.B0AAA.Location = new System.Drawing.Point(3, 19);
		this.B0AAA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.B0AAA.Name = "B0AAA";
		this.B0AAA.Size = new System.Drawing.Size(20, 21);
		this.B0AAA.TabIndex = 194;
		this.B0AAA.Text = "0";
		this.labelDownloaded.AutoSize = true;
		this.labelDownloaded.BackColor = System.Drawing.Color.Transparent;
		this.labelDownloaded.Font = new System.Drawing.Font("DS-Digital", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.labelDownloaded.ForeColor = System.Drawing.Color.Black;
		this.labelDownloaded.Location = new System.Drawing.Point(424, 19);
		this.labelDownloaded.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.labelDownloaded.Name = "labelDownloaded";
		this.labelDownloaded.Size = new System.Drawing.Size(43, 21);
		this.labelDownloaded.TabIndex = 193;
		this.labelDownloaded.Text = "00%";
		this.C0AA0.AutoSize = true;
		this.C0AA0.BackColor = System.Drawing.Color.Transparent;
		this.C0AA0.Font = new System.Drawing.Font("DS-Digital", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.C0AA0.ForeColor = System.Drawing.Color.Black;
		this.C0AA0.Location = new System.Drawing.Point(239, 19);
		this.C0AA0.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.C0AA0.Name = "C0AA0";
		this.C0AA0.Size = new System.Drawing.Size(20, 21);
		this.C0AA0.TabIndex = 192;
		this.C0AA0.Text = "0";
		this.lblstatus.AutoSize = true;
		this.lblstatus.BackColor = System.Drawing.Color.Transparent;
		this.lblstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblstatus.ForeColor = System.Drawing.Color.DeepSkyBlue;
		this.lblstatus.Location = new System.Drawing.Point(249, 359);
		this.lblstatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.lblstatus.Name = "lblstatus";
		this.lblstatus.Size = new System.Drawing.Size(389, 24);
		this.lblstatus.TabIndex = 195;
		this.lblstatus.Text = "Downloading External File Please Wait...";
		this.button1.Location = new System.Drawing.Point(100, 363);
		this.button1.Margin = new System.Windows.Forms.Padding(2);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(82, 19);
		this.button1.TabIndex = 191;
		this.button1.Text = "button1";
		this.button1.UseVisualStyleBackColor = true;
		this.timer_0.Tick += new System.EventHandler(timer_0_Tick);
		this.bunifuProgressBar1.BackColor = System.Drawing.Color.Silver;
		this.bunifuProgressBar1.BorderRadius = 5;
		this.bunifuProgressBar1.Dock = System.Windows.Forms.DockStyle.Top;
		this.bunifuProgressBar1.Location = new System.Drawing.Point(0, 0);
		this.bunifuProgressBar1.MaximumValue = 100;
		this.bunifuProgressBar1.Name = "bunifuProgressBar1";
		this.bunifuProgressBar1.ProgressColor = System.Drawing.Color.Teal;
		this.bunifuProgressBar1.Size = new System.Drawing.Size(481, 18);
		this.bunifuProgressBar1.TabIndex = 196;
		this.bunifuProgressBar1.Value = 0;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(481, 43);
		base.Controls.Add(this.B0AAA);
		base.Controls.Add(this.labelDownloaded);
		base.Controls.Add(this.C0AA0);
		base.Controls.Add(this.lblstatus);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.bunifuProgressBar1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "Updater";
		base.ShowIcon = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Updater";
		base.Load += new System.EventHandler(Updater_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
