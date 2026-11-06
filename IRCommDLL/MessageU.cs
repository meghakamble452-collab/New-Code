using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;

namespace IRCommDLL;

public class MessageU : Form
{
	public static int TL;

	internal CookieContainer ccm;

	private IContainer components;

	private BunifuElipse bunifuElipse_0;

	private Panel panel1;

	private Button button2;

	private Button button1;

	private Button button3;

	private WebBrowser webBrowser1;

	public MessageU()
	{
		InitializeComponent();
	}

	internal void shw(int it)
	{
		ShowDialog();
	}

	private void button2_Click(object sender, EventArgs e)
	{
		TL = 1;
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		TL = 2;
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private async void button3_Click(object sender, EventArgs e)
	{
		ccm = new CookieContainer();
		webBrowser1.ScriptErrorsSuppressed = true;
		WebBrowser webBrowser = webBrowser1;
		string urlString = "https://www.irctc.co.in/nget/train-search";
		webBrowser.Navigate(urlString);
		await PageLoad(40);
		string cookie = webBrowser1.Document.Cookie;
		new Dictionary<string, string>();
		string[] array = cookie.Split(';');
		string[] array2 = array;
		string[] array3 = array2;
		foreach (string text in array3)
		{
			if (!string.IsNullOrEmpty(text))
			{
				string text2 = string.Empty;
				string text4 = string.Empty;
				string value = "_abck=";
				if (text.StartsWith(value))
				{
					string text5 = "_abck";
					text2 = text5;
					string oldValue = "_abck=";
					text4 = text.Replace(oldValue, "");
				}
				string value2 = "bm_sv=";
				if (text.StartsWith(value2))
				{
					string text6 = "bm_sv";
					text2 = text6;
					string oldValue2 = "bm_sv=";
					text4 = text.Replace(oldValue2, "");
				}
				string value3 = "bm_sz=";
				if (text.StartsWith(value3))
				{
					string text7 = "bm_sz";
					text2 = text7;
					string oldValue3 = "bm_sz=";
					text4 = text.Replace(oldValue3, "");
				}
				if (!string.IsNullOrEmpty(text2) && !string.IsNullOrEmpty(text4))
				{
					string obj = text4;
					string oldValue4 = " ";
					string newValue = "+";
					text4 = obj.Replace(oldValue4, newValue);
					Cookie cookie2 = new Cookie(text2, text4);
					string domain = "irctc.co.in";
					cookie2.Domain = domain;
					Cookie cookie3 = cookie2;
					ccm.Add(cookie3);
				}
			}
		}
	}

	private async Task PageLoad(int TimeOut)
	{
		TaskCompletionSource<bool> PageLoaded = null;
		PageLoaded = new TaskCompletionSource<bool>();
		int TimeElapsed = 0;
		webBrowser1.DocumentCompleted += delegate
		{
			if (webBrowser1.ReadyState == WebBrowserReadyState.Complete && !PageLoaded.Task.IsCompleted)
			{
				PageLoaded.SetResult(result: true);
			}
		};
		while (PageLoaded.Task.Status != TaskStatus.RanToCompletion)
		{
			await Task.Delay(10);
			TimeElapsed++;
			if (TimeElapsed >= TimeOut * 100)
			{
				PageLoaded.TrySetResult(result: true);
			}
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IRCommDLL.MessageU));
		this.bunifuElipse_0 = new Bunifu.Framework.UI.BunifuElipse(this.components);
		this.panel1 = new System.Windows.Forms.Panel();
		this.button2 = new System.Windows.Forms.Button();
		this.button1 = new System.Windows.Forms.Button();
		this.button3 = new System.Windows.Forms.Button();
		this.webBrowser1 = new System.Windows.Forms.WebBrowser();
		this.panel1.SuspendLayout();
		base.SuspendLayout();
		this.bunifuElipse_0.ElipseRadius = 5;
		this.bunifuElipse_0.TargetControl = this;
		this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
		this.panel1.Controls.Add(this.button2);
		this.panel1.Controls.Add(this.button1);
		this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.panel1.Location = new System.Drawing.Point(0, 514);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(911, 48);
		this.panel1.TabIndex = 1;
		this.button2.Location = new System.Drawing.Point(12, 10);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(167, 29);
		this.button2.TabIndex = 0;
		this.button2.Text = "Open Google Chrome";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(button2_Click);
		this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button1.Location = new System.Drawing.Point(265, 10);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(93, 29);
		this.button1.TabIndex = 0;
		this.button1.Text = "Proceed";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button3.Location = new System.Drawing.Point(806, 479);
		this.button3.Name = "button3";
		this.button3.Size = new System.Drawing.Size(93, 29);
		this.button3.TabIndex = 2;
		this.button3.Text = "Proceed";
		this.button3.UseVisualStyleBackColor = true;
		this.button3.Click += new System.EventHandler(button3_Click);
		this.webBrowser1.Location = new System.Drawing.Point(22, -4);
		this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
		this.webBrowser1.Name = "webBrowser1";
		this.webBrowser1.Size = new System.Drawing.Size(877, 477);
		this.webBrowser1.TabIndex = 3;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(911, 562);
		base.Controls.Add(this.webBrowser1);
		base.Controls.Add(this.button3);
		base.Controls.Add(this.panel1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "MessageU";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "MessageU";
		base.TopMost = true;
		this.panel1.ResumeLayout(false);
		base.ResumeLayout(false);
	}
}
