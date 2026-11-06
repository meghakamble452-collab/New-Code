using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Bunifu.Framework.UI;

namespace APP_FRAMEWORK;

internal class frmNotes : Form
{
	private bool bool_0;

	private bool bool_1;

	private string string_0;

	internal bool bool_2;

	internal bool bool_3;

	internal bool bool_4;

	private IContainer icontainer_0;

	private IDisposable BAAAA;

	private WebBrowser CAAA0;

	private Panel pnlHeader;

	private BunifuImageButton btnClose;

	private Label label1;

	private BunifuElipse bunifuElipse_0;

	private IContainer components;

	public frmNotes(int int_0, int int_1)
	{
		string_0 = "";
		InitializeComponent();
		pnlHeader.MouseDown += StatClass.Header_MouseDown;
		pnlHeader.MouseMove += StatClass.Header_MouseMove;
		pnlHeader.MouseUp += StatClass.Header_MouseUp;
		switch (int_0)
		{
		default:
		{
			string text15 = "Message";
			Text = text15;
			break;
		}
		case 1:
			switch (int_1)
			{
			case 1:
			{
				string text13 = "Steps for HDFC OTP ByPass";
				Text = text13;
				WebBrowser cAAA7 = CAAA0;
				string string_5 = Class33.string_6;
				string text14 = "hdfc.htm";
				cAAA7.Url = new Uri(string_5 + text14, UriKind.Absolute);
				break;
			}
			case 2:
			{
				string text11 = "Steps for ICICI OTP ByPass";
				Text = text11;
				WebBrowser cAAA6 = CAAA0;
				string string_4 = Class33.string_6;
				string text12 = "/ici.htm";
				cAAA6.Url = new Uri(string_4 + text12, UriKind.Absolute);
				break;
			}
			case 3:
			{
				string text9 = "Steps for YES OTP ByPass";
				Text = text9;
				WebBrowser cAAA5 = CAAA0;
				string string_3 = Class33.string_6;
				string text10 = "yes.htm";
				cAAA5.Url = new Uri(string_3 + text10, UriKind.Absolute);
				break;
			}
			case 4:
			{
				string text7 = "Steps for SBI OTP ByPass";
				Text = text7;
				WebBrowser cAAA4 = CAAA0;
				string string_2 = Class33.string_6;
				string text8 = "sbi.htm";
				cAAA4.Url = new Uri(string_2 + text8, UriKind.Absolute);
				break;
			}
			case 5:
			{
				string text5 = "Steps for Android OTP Application";
				Text = text5;
				WebBrowser cAAA3 = CAAA0;
				string string_ = Class33.string_6;
				string text6 = "and.htm";
				cAAA3.Url = new Uri(string_ + text6, UriKind.Absolute);
				break;
			}
			}
			break;
		case 2:
		{
			string text3 = "Result";
			Text = text3;
			WebBrowser cAAA2 = CAAA0;
			string uri2 = Program.Uri;
			string text4 = "result.php";
			cAAA2.Url = new Uri(uri2 + text4, UriKind.Absolute);
			break;
		}
		case 3:
		{
			string text = "News";
			Text = text;
			bool_2 = true;
			WebBrowser cAAA = CAAA0;
			string uri = Program.Uri;
			string text2 = "news.php";
			cAAA.Url = new Uri(uri + text2, UriKind.Absolute);
			break;
		}
		}
	}

	public frmNotes(string string_1)
	{
		string_0 = "";
		try
		{
			InitializeComponent();
		}
		catch (Exception ex)
		{
			string text = "Error: ";
			MessageBox.Show(text + ex.Message.ToString());
		}
		CAAA0.Navigated += CAAA0_Navigated;
		if (string_1.Length <= 0)
		{
			return;
		}
		CAAA0.Navigated += CAAA0_Navigated;
		CAAA0.DocumentCompleted += CAAA0_DocumentCompleted;
		string text2 = string_1.ToUpper();
		string text3 = "HDFC";
		if (!(text2 == text3))
		{
			string text4 = "HDFCDEBIT";
			if (text2 == text4)
			{
				CAAA0.DocumentText = Class32.String_18;
			}
		}
		else
		{
			CAAA0.DocumentText = Class32.String_17;
		}
		CAAA0.DocumentText = string_1;
		Thread.Sleep(300);
	}

	private void CAAA0_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
	{
		bool_1 = true;
	}

	internal string method_0(string string_1)
	{
		while (!bool_0 || !bool_1)
		{
			Thread.Sleep(500);
			Application.DoEvents();
		}
		HtmlDocument document = CAAA0.Document;
		string scriptName = "passwordStringDes";
		return document.InvokeScript(scriptName, new object[1] { string_1 }).ToString();
	}

	internal string method_1(string string_1, string string_2, string string_3)
	{
		while (!bool_0 || !bool_1)
		{
			Thread.Sleep(200);
			Application.DoEvents();
		}
		HtmlDocument document = CAAA0.Document;
		string scriptName = "EncCard";
		return document.InvokeScript(scriptName, new object[3] { string_1, string_2, string_3 }).ToString();
	}

	private void frmNotes_Load(object sender, EventArgs e)
	{
		if (Screen.PrimaryScreen.Bounds.Width < base.Width + 50)
		{
			base.Width = Screen.PrimaryScreen.Bounds.Width - 50;
		}
		if (Screen.PrimaryScreen.Bounds.Height < base.Height + 50)
		{
			base.Width = Screen.PrimaryScreen.Bounds.Height - 50;
		}
	}

	private void CAAA0_Navigated(object sender, WebBrowserNavigatedEventArgs e)
	{
		bool_0 = true;
	}

	private void CAAA0_DocumentCompleted_1(object sender, WebBrowserDocumentCompletedEventArgs e)
	{
	}

	private void btnClose_Click(object sender, EventArgs e)
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
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(APP_FRAMEWORK.frmNotes));
		this.CAAA0 = new System.Windows.Forms.WebBrowser();
		this.pnlHeader = new System.Windows.Forms.Panel();
		this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
		this.label1 = new System.Windows.Forms.Label();
		this.bunifuElipse_0 = new Bunifu.Framework.UI.BunifuElipse(this.components);
		this.pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.btnClose).BeginInit();
		base.SuspendLayout();
		this.CAAA0.AllowWebBrowserDrop = false;
		this.CAAA0.IsWebBrowserContextMenuEnabled = false;
		this.CAAA0.Location = new System.Drawing.Point(3, 30);
		this.CAAA0.MinimumSize = new System.Drawing.Size(20, 20);
		this.CAAA0.Name = "CAAA0";
		this.CAAA0.ScriptErrorsSuppressed = true;
		this.CAAA0.Size = new System.Drawing.Size(872, 420);
		this.CAAA0.TabIndex = 0;
		this.CAAA0.WebBrowserShortcutsEnabled = false;
		this.CAAA0.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(CAAA0_DocumentCompleted_1);
		this.pnlHeader.BackColor = System.Drawing.Color.MediumSlateBlue;
		this.pnlHeader.Controls.Add(this.btnClose);
		this.pnlHeader.Controls.Add(this.label1);
		this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
		this.pnlHeader.ForeColor = System.Drawing.Color.FromArgb(17, 17, 18);
		this.pnlHeader.Location = new System.Drawing.Point(0, 0);
		this.pnlHeader.Name = "pnlHeader";
		this.pnlHeader.Size = new System.Drawing.Size(879, 28);
		this.pnlHeader.TabIndex = 1209;
		this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnClose.BackColor = System.Drawing.Color.Transparent;
		this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
		this.btnClose.Image = (System.Drawing.Image)resources.GetObject("btnClose.Image");
		this.btnClose.ImageActive = null;
		this.btnClose.Location = new System.Drawing.Point(849, 4);
		this.btnClose.Name = "btnClose";
		this.btnClose.Size = new System.Drawing.Size(26, 20);
		this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.btnClose.TabIndex = 1;
		this.btnClose.TabStop = false;
		this.btnClose.Zoom = 10;
		this.btnClose.Click += new System.EventHandler(btnClose_Click);
		this.label1.AutoSize = true;
		this.label1.BackColor = System.Drawing.Color.Transparent;
		this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11f, System.Drawing.FontStyle.Bold);
		this.label1.ForeColor = System.Drawing.Color.White;
		this.label1.Location = new System.Drawing.Point(2, 1);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(46, 20);
		this.label1.TabIndex = 0;
		this.label1.Text = "News";
		this.bunifuElipse_0.ElipseRadius = 5;
		this.bunifuElipse_0.TargetControl = this;
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		this.BackColor = System.Drawing.Color.Purple;
		base.ClientSize = new System.Drawing.Size(879, 454);
		base.Controls.Add(this.pnlHeader);
		base.Controls.Add(this.CAAA0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "frmNotes";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Hitman Important Notes...";
		base.Load += new System.EventHandler(frmNotes_Load);
		this.pnlHeader.ResumeLayout(false);
		this.pnlHeader.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.btnClose).EndInit();
		base.ResumeLayout(false);
	}
}
