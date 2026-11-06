using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Ionic.Zip;
using Microsoft.Win32;

namespace IRCommDLL;

public class frmDownload : Form
{
	private string BAAAA;

	private string Str1;

	private string string_0;

	private string string_1;

	private int int_0;

	private int int_1;

	private Stopwatch stopwatch_0 = new Stopwatch();

	private IContainer icontainer_0;

	private IContainer components;

	private Label labelDownloaded;

	private Label C0AA0;

	private Label B0AAA;

	private Label lblstatus;

	private Button button1;

	private System.Windows.Forms.Timer timer_0;

	private BunifuProgressBar bunifuProgressBar1;

	private BunifuElipse bunifuElipse1;

	public frmDownload()
	{
		InitializeComponent();
	}

	private void frmDownload_Load(object sender, EventArgs e)
	{
		method_0(BAAAA, Str1);
	}

	public void startDownload(string pUri, string pFile)
	{
		BAAAA = pUri;
		Str1 = pFile;
		ShowDialog();
	}

	private void method_0(string string_2, string string_3)
	{
		BAAAA = string_2;
		string_0 = string_3;
		int_1++;
		try
		{
			new Thread((ThreadStart)delegate
			{
				ServicePointManager.Expect100Continue = true;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
				WebClient webClient = new WebClient();
				webClient.DownloadProgressChanged += method_1;
				webClient.DownloadFileCompleted += method_2;
				webClient.DownloadFileAsync(new Uri(BAAAA), Str1);
				stopwatch_0.Start();
			}).Start();
		}
		catch
		{
		}
	}

	private void method_1(object sender, DownloadProgressChangedEventArgs e)
	{
		try
		{
			BeginInvoke((Action)delegate
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
			});
		}
		catch (Exception)
		{
		}
	}

	public static string GetChromeVersion()
	{
		string result = null;
		try
		{
			RegistryKey currentUser = Registry.CurrentUser;
			string name = "Software\\Google\\Chrome\\BLBeacon";
			using RegistryKey registryKey = currentUser.OpenSubKey(name);
			if (registryKey != null)
			{
				string name2 = "version";
				result = registryKey.GetValue(name2)?.ToString();
			}
			else
			{
				result = null;
			}
		}
		catch (Exception)
		{
		}
		return result;
	}

	private void method_2(object sender, AsyncCompletedEventArgs e)
	{
		if (e.Error == null && !e.Cancelled)
		{
			try
			{
				string str = Str1;
				string text = "chromedriver.zip";
				if (str == text)
				{
					string text2 = "IRLOG\\cd_Version.txt";
					string path = text2;
					if (File.Exists(path))
					{
						File.Delete(path);
					}
					if (!File.Exists(path))
					{
						File.WriteAllText(path, GetChromeVersion());
					}
					string string_ = "chromedriver.exe";
					method_3(string_);
				}
				using (ZipFile zipFile = ZipFile.Read(Str1))
				{
					zipFile.ExtractAll(Directory.GetCurrentDirectory(), ExtractExistingFileAction.OverwriteSilently);
				}
				File.Delete(Str1);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				string text3 = "Could not delete ZIP!";
				MessageBox.Show(text3);
				Environment.Exit(1);
			}
		}
		BeginInvoke((Action)delegate
		{
			button1.PerformClick();
		});
	}

	private bool method_3(string string_2)
	{
		bool result = false;
		try
		{
			if (File.Exists(string_2))
			{
				File.Delete(string_2);
				result = true;
			}
		}
		catch
		{
			result = false;
		}
		return result;
	}

	private bool method_4(string string_2)
	{
		bool result = false;
		try
		{
			if (File.Exists(string_2))
			{
				if (Directory.Exists(string_2))
				{
					DirectoryInfo directoryInfo = new DirectoryInfo(string_2);
					FileInfo[] files = directoryInfo.GetFiles();
					for (int i = 0; i < files.Length; i++)
					{
						files[i].Delete();
					}
					DirectoryInfo[] directories = directoryInfo.GetDirectories();
					for (int j = 0; j < directories.Length; j++)
					{
						directories[j].Delete(recursive: true);
					}
				}
				result = true;
			}
		}
		catch
		{
			result = false;
		}
		return result;
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
	}

	private void button1_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
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
		this.components = new System.ComponentModel.Container();
		this.labelDownloaded = new System.Windows.Forms.Label();
		this.C0AA0 = new System.Windows.Forms.Label();
		this.B0AAA = new System.Windows.Forms.Label();
		this.lblstatus = new System.Windows.Forms.Label();
		this.button1 = new System.Windows.Forms.Button();
		this.timer_0 = new System.Windows.Forms.Timer(this.components);
		this.bunifuProgressBar1 = new Bunifu.Framework.UI.BunifuProgressBar();
		this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
		base.SuspendLayout();
		this.labelDownloaded.AutoSize = true;
		this.labelDownloaded.BackColor = System.Drawing.Color.Transparent;
		this.labelDownloaded.Font = new System.Drawing.Font("DS-Digital", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.labelDownloaded.ForeColor = System.Drawing.Color.Black;
		this.labelDownloaded.Location = new System.Drawing.Point(420, 17);
		this.labelDownloaded.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.labelDownloaded.Name = "labelDownloaded";
		this.labelDownloaded.Size = new System.Drawing.Size(43, 21);
		this.labelDownloaded.TabIndex = 187;
		this.labelDownloaded.Text = "00%";
		this.C0AA0.AutoSize = true;
		this.C0AA0.BackColor = System.Drawing.Color.Transparent;
		this.C0AA0.Font = new System.Drawing.Font("DS-Digital", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.C0AA0.ForeColor = System.Drawing.Color.Black;
		this.C0AA0.Location = new System.Drawing.Point(236, 17);
		this.C0AA0.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.C0AA0.Name = "C0AA0";
		this.C0AA0.Size = new System.Drawing.Size(20, 21);
		this.C0AA0.TabIndex = 186;
		this.C0AA0.Text = "0";
		this.B0AAA.AutoSize = true;
		this.B0AAA.BackColor = System.Drawing.Color.Transparent;
		this.B0AAA.Font = new System.Drawing.Font("DS-Digital", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.B0AAA.ForeColor = System.Drawing.Color.Black;
		this.B0AAA.Location = new System.Drawing.Point(11, 17);
		this.B0AAA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.B0AAA.Name = "B0AAA";
		this.B0AAA.Size = new System.Drawing.Size(20, 21);
		this.B0AAA.TabIndex = 188;
		this.B0AAA.Text = "0";
		this.lblstatus.AutoSize = true;
		this.lblstatus.BackColor = System.Drawing.Color.Transparent;
		this.lblstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblstatus.ForeColor = System.Drawing.Color.DeepSkyBlue;
		this.lblstatus.Location = new System.Drawing.Point(249, 292);
		this.lblstatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
		this.lblstatus.Name = "lblstatus";
		this.lblstatus.Size = new System.Drawing.Size(389, 24);
		this.lblstatus.TabIndex = 189;
		this.lblstatus.Text = "Downloading External File Please Wait...";
		this.button1.Location = new System.Drawing.Point(100, 296);
		this.button1.Margin = new System.Windows.Forms.Padding(2);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(82, 19);
		this.button1.TabIndex = 184;
		this.button1.Text = "button1";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.timer_0.Tick += new System.EventHandler(timer_0_Tick);
		this.bunifuProgressBar1.BackColor = System.Drawing.Color.Silver;
		this.bunifuProgressBar1.BorderRadius = 5;
		this.bunifuProgressBar1.Dock = System.Windows.Forms.DockStyle.Top;
		this.bunifuProgressBar1.Location = new System.Drawing.Point(0, 0);
		this.bunifuProgressBar1.MaximumValue = 100;
		this.bunifuProgressBar1.Name = "bunifuProgressBar1";
		this.bunifuProgressBar1.ProgressColor = System.Drawing.Color.Teal;
		this.bunifuProgressBar1.Size = new System.Drawing.Size(464, 18);
		this.bunifuProgressBar1.TabIndex = 190;
		this.bunifuProgressBar1.Value = 0;
		this.bunifuElipse1.ElipseRadius = 5;
		this.bunifuElipse1.TargetControl = this;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(464, 39);
		base.Controls.Add(this.bunifuProgressBar1);
		base.Controls.Add(this.B0AAA);
		base.Controls.Add(this.labelDownloaded);
		base.Controls.Add(this.C0AA0);
		base.Controls.Add(this.lblstatus);
		base.Controls.Add(this.button1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "frmDownload";
		base.ShowIcon = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "frmDownload";
		base.TopMost = true;
		base.Load += new System.EventHandler(frmDownload_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
