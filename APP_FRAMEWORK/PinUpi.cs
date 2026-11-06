using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

namespace APP_FRAMEWORK;

public class PinUpi : Form
{
	internal string bvalue;

	private IContainer components;

	private Label label1;

	private TextBox textBox1;

	private Button button1;

	private Panel pnlHeader;

	private Label label5;

	private BunifuImageButton bunifuImageButton1;

	private Label label2;

	public PinUpi()
	{
		InitializeComponent();
	}

	private void label1_Click(object sender, EventArgs e)
	{
	}

	private void button1_Click(object sender, EventArgs e)
	{
		bvalue = textBox1.Text.Trim();
		Close();
	}

	private void label2_Click(object sender, EventArgs e)
	{
	}

	public void Form1_Load(string strin_1, string strin_2)
	{
		label1.Visible = true;
		Label label = label1;
		string text = "Enter Upi Pin For==> ";
		label.Text = text + strin_1;
		Label label2 = this.label2;
		string text2 = "A/C-";
		label2.Text = text2 + strin_2;
		ShowDialog();
	}

	private void textBox1_TextChanged(object sender, EventArgs e)
	{
	}

	private void PinUpi_Load(object sender, EventArgs e)
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(APP_FRAMEWORK.PinUpi));
		this.label1 = new System.Windows.Forms.Label();
		this.textBox1 = new System.Windows.Forms.TextBox();
		this.button1 = new System.Windows.Forms.Button();
		this.label2 = new System.Windows.Forms.Label();
		this.pnlHeader = new System.Windows.Forms.Panel();
		this.label5 = new System.Windows.Forms.Label();
		this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
		this.pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.bunifuImageButton1).BeginInit();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.Location = new System.Drawing.Point(12, 77);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(115, 20);
		this.label1.TabIndex = 0;
		this.label1.Text = "Enter Upi Pin";
		this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label1.Click += new System.EventHandler(label1_Click);
		this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f);
		this.textBox1.Location = new System.Drawing.Point(133, 74);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new System.Drawing.Size(142, 26);
		this.textBox1.TabIndex = 1;
		this.textBox1.TextChanged += new System.EventHandler(textBox1_TextChanged);
		this.button1.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
		this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.button1.Location = new System.Drawing.Point(133, 113);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(142, 40);
		this.button1.TabIndex = 3;
		this.button1.Text = "OK";
		this.button1.UseVisualStyleBackColor = false;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f);
		this.label2.Location = new System.Drawing.Point(137, 37);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(125, 25);
		this.label2.TabIndex = 4;
		this.label2.Text = "Enter Upi Pin";
		this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.pnlHeader.BackColor = System.Drawing.Color.MediumSlateBlue;
		this.pnlHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.pnlHeader.Controls.Add(this.label5);
		this.pnlHeader.Controls.Add(this.bunifuImageButton1);
		this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
		this.pnlHeader.ForeColor = System.Drawing.Color.Black;
		this.pnlHeader.Location = new System.Drawing.Point(0, 0);
		this.pnlHeader.Name = "pnlHeader";
		this.pnlHeader.Size = new System.Drawing.Size(453, 22);
		this.pnlHeader.TabIndex = 1217;
		this.label5.AutoSize = true;
		this.label5.BackColor = System.Drawing.Color.Transparent;
		this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
		this.label5.Location = new System.Drawing.Point(127, 3);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(177, 17);
		this.label5.TabIndex = 1188;
		this.label5.Text = "SBI Upi Bypass_Hitman";
		this.bunifuImageButton1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.bunifuImageButton1.BackColor = System.Drawing.Color.Transparent;
		this.bunifuImageButton1.Cursor = System.Windows.Forms.Cursors.Hand;
		this.bunifuImageButton1.Image = (System.Drawing.Image)resources.GetObject("bunifuImageButton1.Image");
		this.bunifuImageButton1.ImageActive = null;
		this.bunifuImageButton1.Location = new System.Drawing.Point(431, 0);
		this.bunifuImageButton1.Name = "bunifuImageButton1";
		this.bunifuImageButton1.Size = new System.Drawing.Size(22, 22);
		this.bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.bunifuImageButton1.TabIndex = 1;
		this.bunifuImageButton1.TabStop = false;
		this.bunifuImageButton1.Zoom = 10;
		this.bunifuImageButton1.Click += new System.EventHandler(bunifuImageButton1_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
		base.ClientSize = new System.Drawing.Size(453, 164);
		base.Controls.Add(this.pnlHeader);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.textBox1);
		base.Controls.Add(this.label1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "PinUpi";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "PinUpi";
		base.Load += new System.EventHandler(PinUpi_Load);
		this.pnlHeader.ResumeLayout(false);
		this.pnlHeader.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.bunifuImageButton1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private void bunifuImageButton1_Click(object sender, EventArgs e)
	{
		Close();
	}
}
