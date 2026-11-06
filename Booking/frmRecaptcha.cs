using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using APP_FRAMEWORK;
using Bunifu.Framework.UI;
using NEXUS;

namespace Booking;

public class frmRecaptcha : Form
{
	private List<string> list_0 = new List<string>(50);

	private IContainer icontainer_0;

	private BunifuElipse bunifuElipse_0;

	private Label label1;

	private ComboBox BAAAA;

	private Button CAAA0;

	private Panel panel1;

	private Button button2;

	public frmRecaptcha()
	{
		InitializeComponent();
	}

	private void frmRecaptcha_Load(object sender, EventArgs e)
	{
		List<string> list = list_0;
		string item = "https://www.irctc.co.in/nget/assets/images/logo.png";
		list.Add(item);
		List<string> list2 = list_0;
		string item2 = "https://www.irctc.co.in/nget/polyfills-es2015.c0be8f1f2be54dc7cf83.js";
		list2.Add(item2);
		List<string> list3 = list_0;
		string item3 = "https://www.irctc.co.in/nget/runtime-es2015.c8b13e2ad6db097a02d6.js";
		list3.Add(item3);
		List<string> list4 = list_0;
		string item4 = "https://www.irctc.co.in/nget/styles.d4913679e40f1ab09f01.css";
		list4.Add(item4);
		List<string> list5 = list_0;
		string item5 = "https://www.irctc.co.in/nget/checkBox.8cf423073e71167979b5.jpg";
		list5.Add(item5);
		List<string> list6 = list_0;
		string item6 = "https://www.irctc.co.in/nget/css-sprite-combined1.11356089c173c53adec9.png";
		list6.Add(item6);
		List<string> list7 = list_0;
		string item7 = "https://www.irctc.co.in/nget/home_page_banner1.b233d37e7fc8266ecd46.jpg";
		list7.Add(item7);
		int num = list_0.Count();
		BAAAA.Items.Clear();
		ComboBox.ObjectCollection items = BAAAA.Items;
		string item8 = "Select Server";
		items.Add(item8);
		for (int i = 1; i <= num; i++)
		{
			ComboBox.ObjectCollection items2 = BAAAA.Items;
			string text = "Server _ ";
			items2.Add(text + i);
		}
		BAAAA.SelectedIndex = 0;
	}

	private void CAAA0_Click(object sender, EventArgs e)
	{
		if (BAAAA.SelectedIndex <= 0)
		{
			Form owner = Program.smethod_7();
			string text = "Please Select Server";
			string caption = "Hitman";
			MessageBox.Show(owner, text, caption, MessageBoxButtons.OK);
			BAAAA.Focus();
		}
		else
		{
			ThreadPool.QueueUserWorkItem(method_0);
		}
	}

	private void button2_Click(object sender, EventArgs e)
	{
		mCOMM mcommInstance_ = Program.mcommInstance_;
		string key = "Server";
		mcommInstance_.SetData(key, list_0[BAAAA.SelectedIndex - 1]);
	}

	private void method_0(object object_0)
	{
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Booking.frmRecaptcha));
		this.bunifuElipse_0 = new Bunifu.Framework.UI.BunifuElipse(this.icontainer_0);
		this.CAAA0 = new System.Windows.Forms.Button();
		this.BAAAA = new System.Windows.Forms.ComboBox();
		this.label1 = new System.Windows.Forms.Label();
		this.panel1 = new System.Windows.Forms.Panel();
		this.button2 = new System.Windows.Forms.Button();
		this.panel1.SuspendLayout();
		base.SuspendLayout();
		this.bunifuElipse_0.ElipseRadius = 5;
		this.bunifuElipse_0.TargetControl = this;
		this.CAAA0.Location = new System.Drawing.Point(220, 70);
		this.CAAA0.Name = "button1";
		this.CAAA0.Size = new System.Drawing.Size(127, 33);
		this.CAAA0.TabIndex = 0;
		this.CAAA0.Text = "Check Now";
		this.CAAA0.UseVisualStyleBackColor = true;
		this.CAAA0.Click += new System.EventHandler(CAAA0_Click);
		this.BAAAA.FormattingEnabled = true;
		this.BAAAA.Location = new System.Drawing.Point(133, 27);
		this.BAAAA.Name = "comboBox1";
		this.BAAAA.Size = new System.Drawing.Size(214, 24);
		this.BAAAA.TabIndex = 1;
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(12, 30);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(93, 17);
		this.label1.TabIndex = 2;
		this.label1.Text = "Select Server";
		this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
		this.panel1.Controls.Add(this.button2);
		this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
		this.panel1.Location = new System.Drawing.Point(0, 131);
		this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(370, 54);
		this.panel1.TabIndex = 3;
		this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button2.Location = new System.Drawing.Point(248, 12);
		this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(110, 31);
		this.button2.TabIndex = 0;
		this.button2.Text = "OK";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(button2_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(370, 185);
		base.Controls.Add(this.panel1);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.BAAAA);
		base.Controls.Add(this.CAAA0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "frmRecaptcha";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "frmRecaptcha";
		base.Load += new System.EventHandler(frmRecaptcha_Load);
		this.panel1.ResumeLayout(false);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
