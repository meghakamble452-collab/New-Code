using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using NEXUS;

namespace APP_FRAMEWORK;

internal class frmComplaint : Form
{
	private string string_0;

	private string BAAAA;

	private string CAAA0;

	private string string_1;

	private string string_2;

	private IContainer icontainer_0;

	private IDisposable idisposable_0;

	private Label label1;

	private ComboBox cboType;

	private Label label2;

	private TextBox txtSubject;

	private Label label3;

	private Label label_0;

	private Label label4;

	private TextBox B0AAA;

	internal Button btnSubmit;

	private CheckBox C0AA0;

	private Label label5;

	private TextBox txtAttach;

	private Button btnBrowse;

	private Label label6;

	private ProgressBar progressBar1;

	internal CheckBox chkAuth;

	private TextBox txtContact;

	private Label label7;

	private Panel panel1;

	private Panel pnlHeader;

	private BunifuImageButton B1AAA;

	private Label C1AA0;

	private BunifuElipse bunifuElipse_0;

	private IContainer components;

	public frmComplaint()
	{
		InitializeComponent();
		pnlHeader.MouseDown += StatClass.Header_MouseDown;
		pnlHeader.MouseMove += StatClass.Header_MouseMove;
		pnlHeader.MouseUp += StatClass.Header_MouseUp;
		Control.CheckForIllegalCrossThreadCalls = false;
	}

	private void frmComplaint_Load(object sender, EventArgs e)
	{
		cboType.SelectedIndex = 0;
		label_0.Text = Program.clientID;
	}

	private void cboType_SelectedIndexChanged(object sender, EventArgs e)
	{
		C0AA0.Visible = false;
		C0AA0.Checked = false;
		if (cboType.SelectedIndex == 1)
		{
			C0AA0.Visible = true;
			C0AA0.Checked = true;
		}
	}

	private void btnSubmit_Click(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(txtSubject.Text))
		{
			string text = "Please enter subject!";
			string caption = "Subject";
			MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		else if (!string.IsNullOrEmpty(B0AAA.Text))
		{
			if (string.IsNullOrEmpty(txtContact.Text))
			{
				string text2 = "Please enter Your Contact Details!";
				string caption2 = "Message";
				MessageBox.Show(text2, caption2, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			string_0 = method_1();
			string[] array = new string[5]
			{
				cboType.SelectedItem.ToString(),
				null,
				null,
				null,
				null
			};
			string text3 = " From ";
			array[1] = text3;
			array[2] = label_0.Text;
			string text4 = " Dated: ";
			array[3] = text4;
			DateTime now = DateTime.Now;
			string text5 = "dd-MMM-yyyy";
			array[4] = now.ToString(text5);
			BAAAA = string.Concat(array);
			ThreadPool.QueueUserWorkItem(method_0);
			Button button = btnSubmit;
			string text6 = "Submitting..";
			button.Text = text6;
			btnSubmit.Enabled = false;
			progressBar1.Visible = true;
			if (C0AA0.Checked && C0AA0.Visible)
			{
				string text7 = "Message with attachment may take some time. please wait...";
				MessageBox.Show(text7);
			}
		}
		else
		{
			string text8 = "Please enter Message!";
			string caption3 = "Message";
			MessageBox.Show(text8, caption3, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
	}

	internal static NetworkCredential smethod_0()
	{
		string[] array = Program.string_13.Split('|');
		return new NetworkCredential(array[0].Trim(), array[1].Trim());
	}

	internal void Reciver_smethod_1()
	{
		_ = new Random((int)DateTime.Now.Ticks).Next(1, 9999) % 2;
		string[] array = Program.string_14.Split('|');
		string_1 = array[0].Trim();
		string_2 = array[1].Trim();
	}

	private void method_0(object object_0)
	{
		string text = "";
		string text2 = "";
		Reciver_smethod_1();
		int num = 0;
		int port = 0;
		string string_ = Program.string_13;
		string value = "@gmail";
		if (!string_.Contains(value))
		{
			string string_2 = Program.string_13;
			string value2 = "@rediffmail";
			if (string_2.Contains(value2))
			{
				string cAAA = "smtp.rediffmail.com";
				CAAA0 = cAAA;
				port = 587;
				num = 2;
			}
		}
		else
		{
			string cAAA2 = "smtp.gmail.com";
			CAAA0 = cAAA2;
			port = 587;
			chkAuth.Checked = true;
			num = 1;
		}
		try
		{
			NetworkCredential networkCredential = smethod_0();
			SmtpClient smtpClient = new SmtpClient(CAAA0, port);
			smtpClient.UseDefaultCredentials = false;
			smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
			smtpClient.Credentials = networkCredential;
			smtpClient.EnableSsl = false;
			if (num == 1)
			{
				string targetName = "STARTTLS/smtp.gmail.com";
				smtpClient.TargetName = targetName;
			}
			if (chkAuth.Checked)
			{
				smtpClient.EnableSsl = true;
			}
			smtpClient.Timeout = 100000;
			MailMessage mailMessage = new MailMessage(networkCredential.UserName, string_1, BAAAA, string_0);
			Attachment attachment = null;
			Attachment attachment2 = null;
			mailMessage.IsBodyHtml = true;
			if (C0AA0.Visible && C0AA0.Checked)
			{
				string startupPath = Program.StartupPath;
				string path = "logs";
				string path2 = Path.Combine(startupPath, path);
				string text3 = "Iclgs_";
				DateTime now = DateTime.Now;
				string text4 = "ddMMyyyy";
				string text5 = now.ToString(text4);
				string text6 = ".lg";
				Path.Combine(path2, text3 + text5 + text6);
				string text7 = "Iclgs_";
				now = DateTime.Now;
				string text8 = "ddMMyyyy";
				string text9 = now.ToString(text8);
				string text10 = ".lgg";
				text = Path.Combine(path2, text7 + text9 + text10);
				try
				{
					mCOMM mcommInstance_ = Program.mcommInstance_;
					string key = "COPYFILE";
					mcommInstance_.GetData(key);
					attachment = new Attachment(text);
				}
				catch
				{
				}
				string text11 = "Exlgs_";
				now = DateTime.Now;
				string text12 = "ddMMyyyy";
				string text13 = now.ToString(text12);
				string text14 = ".lg";
				string sourceFileName = Path.Combine(path2, text11 + text13 + text14);
				string text15 = "Exlgs_";
				now = DateTime.Now;
				string text16 = "ddMMyyyy";
				string text17 = now.ToString(text16);
				string text18 = ".lgg";
				text2 = Path.Combine(path2, text15 + text17 + text18);
				try
				{
					File.Copy(sourceFileName, text2, overwrite: true);
					attachment2 = new Attachment(text2);
				}
				catch
				{
				}
			}
			if (attachment != null)
			{
				mailMessage.Attachments.Add(attachment);
			}
			if (attachment2 != null)
			{
				mailMessage.Attachments.Add(attachment2);
			}
			if (txtAttach.Text.Length > 0 && File.Exists(txtAttach.Text))
			{
				Attachment item = new Attachment(txtAttach.Text);
				mailMessage.Attachments.Add(item);
			}
			smtpClient.Send(mailMessage);
			string text19 = "Message Submitted Successfully!";
			string caption = "Submitted";
			MessageBox.Show(text19, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			btnSubmit.Visible = false;
			progressBar1.Visible = false;
		}
		catch (Exception ex)
		{
			btnSubmit.Enabled = true;
			Button button = btnSubmit;
			string text20 = "Submit";
			button.Text = text20;
			progressBar1.Visible = false;
			string text21 = "Error occured while communicating with server, Please try again later.";
			string text22 = text21 + ex;
			string caption2 = "Error";
			MessageBox.Show(text22, caption2, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		try
		{
			File.Delete(text);
			File.Delete(text2);
		}
		catch
		{
		}
	}

	private string method_1()
	{
		string[] array = new string[11];
		string text = "<html><body> UserID: ";
		array[0] = text;
		array[1] = label_0.Text;
		string text2 = "<br>Type: ";
		array[2] = text2;
		array[3] = cboType.SelectedItem.ToString();
		string text3 = "<br>Subject: ";
		array[4] = text3;
		array[5] = txtSubject.Text.Trim();
		string text4 = "<br>Contact: ";
		array[6] = text4;
		array[7] = txtContact.Text.Trim();
		string text5 = "<br>Message: ";
		array[8] = text5;
		string text6 = B0AAA.Text;
		string oldValue = "\r\n";
		string newValue = "<br>";
		array[9] = text6.Replace(oldValue, newValue);
		string text7 = "<br></body></html>";
		array[10] = text7;
		return string.Concat(array);
	}

	private void btnBrowse_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.CheckFileExists = true;
		openFileDialog.CheckPathExists = true;
		openFileDialog.Multiselect = false;
		string title = "Select File to Send to Admin";
		openFileDialog.Title = title;
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			txtAttach.Text = openFileDialog.FileName;
		}
		openFileDialog.Dispose();
	}

	private void B1AAA_Click(object sender, EventArgs e)
	{
		Close();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && idisposable_0 != null)
		{
			idisposable_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(APP_FRAMEWORK.frmComplaint));
		this.label1 = new System.Windows.Forms.Label();
		this.cboType = new System.Windows.Forms.ComboBox();
		this.label2 = new System.Windows.Forms.Label();
		this.txtSubject = new System.Windows.Forms.TextBox();
		this.label3 = new System.Windows.Forms.Label();
		this.label_0 = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.B0AAA = new System.Windows.Forms.TextBox();
		this.btnSubmit = new System.Windows.Forms.Button();
		this.C0AA0 = new System.Windows.Forms.CheckBox();
		this.label5 = new System.Windows.Forms.Label();
		this.txtAttach = new System.Windows.Forms.TextBox();
		this.btnBrowse = new System.Windows.Forms.Button();
		this.label6 = new System.Windows.Forms.Label();
		this.progressBar1 = new System.Windows.Forms.ProgressBar();
		this.chkAuth = new System.Windows.Forms.CheckBox();
		this.txtContact = new System.Windows.Forms.TextBox();
		this.label7 = new System.Windows.Forms.Label();
		this.panel1 = new System.Windows.Forms.Panel();
		this.pnlHeader = new System.Windows.Forms.Panel();
		this.B1AAA = new Bunifu.Framework.UI.BunifuImageButton();
		this.C1AA0 = new System.Windows.Forms.Label();
		this.bunifuElipse_0 = new Bunifu.Framework.UI.BunifuElipse(this.components);
		this.panel1.SuspendLayout();
		this.pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.B1AAA).BeginInit();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.Location = new System.Drawing.Point(13, 10);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(49, 16);
		this.label1.TabIndex = 0;
		this.label1.Text = "Type : ";
		this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboType.FormattingEnabled = true;
		this.cboType.Items.AddRange(new object[2] { "Suggestion", "Complaint" });
		this.cboType.Location = new System.Drawing.Point(128, 13);
		this.cboType.Name = "cboType";
		this.cboType.Size = new System.Drawing.Size(237, 21);
		this.cboType.TabIndex = 1;
		this.cboType.SelectedIndexChanged += new System.EventHandler(cboType_SelectedIndexChanged);
		this.label2.AutoSize = true;
		this.label2.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label2.Location = new System.Drawing.Point(13, 37);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(67, 16);
		this.label2.TabIndex = 2;
		this.label2.Text = "Subject : ";
		this.txtSubject.Location = new System.Drawing.Point(128, 40);
		this.txtSubject.Name = "txtSubject";
		this.txtSubject.Size = new System.Drawing.Size(459, 20);
		this.txtSubject.TabIndex = 3;
		this.label3.AutoSize = true;
		this.label3.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label3.Location = new System.Drawing.Point(143, 115);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(427, 16);
		this.label3.TabIndex = 4;
		this.label3.Text = "Please Enter Your Mobile No., Or Email id: So We Call Back to You";
		this.label_0.AutoSize = true;
		this.label_0.Font = new System.Drawing.Font("Arial", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label_0.ForeColor = System.Drawing.Color.Black;
		this.label_0.Location = new System.Drawing.Point(589, 132);
		this.label_0.Name = "label_0";
		this.label_0.Size = new System.Drawing.Size(65, 18);
		this.label_0.TabIndex = 5;
		this.label_0.Text = "User_ID";
		this.label4.AutoSize = true;
		this.label4.Font = new System.Drawing.Font("Arial", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label4.Location = new System.Drawing.Point(13, 132);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(84, 18);
		this.label4.TabIndex = 6;
		this.label4.Text = "Message : ";
		this.B0AAA.BackColor = System.Drawing.Color.White;
		this.B0AAA.Location = new System.Drawing.Point(1, 156);
		this.B0AAA.Multiline = true;
		this.B0AAA.Name = "B0AAA";
		this.B0AAA.Size = new System.Drawing.Size(723, 148);
		this.B0AAA.TabIndex = 7;
		this.btnSubmit.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnSubmit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.btnSubmit.Location = new System.Drawing.Point(610, 308);
		this.btnSubmit.Name = "btnSubmit";
		this.btnSubmit.Size = new System.Drawing.Size(97, 21);
		this.btnSubmit.TabIndex = 8;
		this.btnSubmit.Text = "    &Send";
		this.btnSubmit.UseVisualStyleBackColor = true;
		this.btnSubmit.Click += new System.EventHandler(btnSubmit_Click);
		this.C0AA0.AutoSize = true;
		this.C0AA0.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.C0AA0.Location = new System.Drawing.Point(381, 16);
		this.C0AA0.Name = "C0AA0";
		this.C0AA0.Size = new System.Drawing.Size(130, 18);
		this.C0AA0.TabIndex = 52;
		this.C0AA0.Text = "Send Today's Logs";
		this.C0AA0.UseVisualStyleBackColor = true;
		this.C0AA0.Visible = false;
		this.label5.AutoSize = true;
		this.label5.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label5.Location = new System.Drawing.Point(13, 63);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(96, 16);
		this.label5.TabIndex = 53;
		this.label5.Text = "File to Send : ";
		this.txtAttach.Location = new System.Drawing.Point(128, 66);
		this.txtAttach.Name = "txtAttach";
		this.txtAttach.ReadOnly = true;
		this.txtAttach.Size = new System.Drawing.Size(459, 20);
		this.txtAttach.TabIndex = 54;
		this.btnBrowse.Location = new System.Drawing.Point(593, 66);
		this.btnBrowse.Name = "btnBrowse";
		this.btnBrowse.Size = new System.Drawing.Size(126, 23);
		this.btnBrowse.TabIndex = 55;
		this.btnBrowse.Text = "Browse";
		this.btnBrowse.UseVisualStyleBackColor = true;
		this.btnBrowse.Click += new System.EventHandler(btnBrowse_Click);
		this.label6.AutoSize = true;
		this.label6.Font = new System.Drawing.Font("Arial", 8.249999f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label6.ForeColor = System.Drawing.Color.Red;
		this.label6.Location = new System.Drawing.Point(644, 94);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(69, 14);
		this.label6.TabIndex = 59;
		this.label6.Text = "( Max 5MB )";
		this.progressBar1.Location = new System.Drawing.Point(6, 332);
		this.progressBar1.Name = "progressBar1";
		this.progressBar1.Size = new System.Drawing.Size(701, 10);
		this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
		this.progressBar1.TabIndex = 64;
		this.progressBar1.Visible = false;
		this.chkAuth.AutoSize = true;
		this.chkAuth.Checked = true;
		this.chkAuth.CheckState = System.Windows.Forms.CheckState.Checked;
		this.chkAuth.Location = new System.Drawing.Point(8, 311);
		this.chkAuth.Name = "chkAuth";
		this.chkAuth.Size = new System.Drawing.Size(182, 17);
		this.chkAuth.TabIndex = 1092;
		this.chkAuth.Text = "My server requires authentication";
		this.txtContact.Location = new System.Drawing.Point(128, 92);
		this.txtContact.Name = "txtContact";
		this.txtContact.Size = new System.Drawing.Size(459, 20);
		this.txtContact.TabIndex = 1094;
		this.label7.AutoSize = true;
		this.label7.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label7.Location = new System.Drawing.Point(13, 90);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(108, 16);
		this.label7.TabIndex = 1093;
		this.label7.Text = "Contact Detail : ";
		this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
		this.panel1.Controls.Add(this.txtContact);
		this.panel1.Controls.Add(this.label7);
		this.panel1.Controls.Add(this.label6);
		this.panel1.Controls.Add(this.btnSubmit);
		this.panel1.Controls.Add(this.chkAuth);
		this.panel1.Controls.Add(this.btnBrowse);
		this.panel1.Controls.Add(this.progressBar1);
		this.panel1.Controls.Add(this.txtAttach);
		this.panel1.Controls.Add(this.C0AA0);
		this.panel1.Controls.Add(this.label5);
		this.panel1.Controls.Add(this.label_0);
		this.panel1.Controls.Add(this.label3);
		this.panel1.Controls.Add(this.B0AAA);
		this.panel1.Controls.Add(this.txtSubject);
		this.panel1.Controls.Add(this.label4);
		this.panel1.Controls.Add(this.cboType);
		this.panel1.Controls.Add(this.label2);
		this.panel1.Controls.Add(this.label1);
		this.panel1.Location = new System.Drawing.Point(2, 29);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(722, 346);
		this.panel1.TabIndex = 1095;
		this.pnlHeader.BackColor = System.Drawing.Color.MediumSlateBlue;
		this.pnlHeader.Controls.Add(this.B1AAA);
		this.pnlHeader.Controls.Add(this.C1AA0);
		this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
		this.pnlHeader.ForeColor = System.Drawing.Color.FromArgb(17, 17, 18);
		this.pnlHeader.Location = new System.Drawing.Point(0, 0);
		this.pnlHeader.Name = "pnlHeader";
		this.pnlHeader.Size = new System.Drawing.Size(727, 28);
		this.pnlHeader.TabIndex = 1210;
		this.B1AAA.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.B1AAA.BackColor = System.Drawing.Color.Transparent;
		this.B1AAA.Cursor = System.Windows.Forms.Cursors.Hand;
		this.B1AAA.Image = (System.Drawing.Image)resources.GetObject("B1AAA.Image");
		this.B1AAA.ImageActive = null;
		this.B1AAA.Location = new System.Drawing.Point(697, 4);
		this.B1AAA.Name = "B1AAA";
		this.B1AAA.Size = new System.Drawing.Size(26, 20);
		this.B1AAA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.B1AAA.TabIndex = 1;
		this.B1AAA.TabStop = false;
		this.B1AAA.Zoom = 10;
		this.B1AAA.Click += new System.EventHandler(B1AAA_Click);
		this.C1AA0.AutoSize = true;
		this.C1AA0.Font = new System.Drawing.Font("Segoe UI Semibold", 11f, System.Drawing.FontStyle.Bold);
		this.C1AA0.ForeColor = System.Drawing.Color.White;
		this.C1AA0.Location = new System.Drawing.Point(5, 4);
		this.C1AA0.Name = "C1AA0";
		this.C1AA0.Size = new System.Drawing.Size(100, 20);
		this.C1AA0.TabIndex = 0;
		this.C1AA0.Text = "Complaint Us";
		this.bunifuElipse_0.ElipseRadius = 5;
		this.bunifuElipse_0.TargetControl = this;
		base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.BackColor = System.Drawing.SystemColors.Control;
		base.ClientSize = new System.Drawing.Size(727, 378);
		base.Controls.Add(this.pnlHeader);
		base.Controls.Add(this.panel1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "frmComplaint";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Send Complaint / Suggestion";
		base.Load += new System.EventHandler(frmComplaint_Load);
		this.panel1.ResumeLayout(false);
		this.panel1.PerformLayout();
		this.pnlHeader.ResumeLayout(false);
		this.pnlHeader.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.B1AAA).EndInit();
		base.ResumeLayout(false);
	}
}
