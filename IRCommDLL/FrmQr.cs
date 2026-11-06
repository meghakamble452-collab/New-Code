using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace IRCommDLL;

public class FrmQr : Form
{
	private string strin_1;

	private Control control_0;

	private IContainer components;

	private PictureBox pictureBox1;

	private Button button1;

	private Label label1;

	private Label label2;

	public FrmQr()
	{
		InitializeComponent();
		base.StartPosition = FormStartPosition.Manual;
		base.TopMost = true;
		base.Left += 2;
	}

	public Image LoadImage(string strin_1)
	{
		using MemoryStream stream = new MemoryStream(Convert.FromBase64String(strin_1));
		return Image.FromStream(stream);
	}

	public void Form1_Load(string strin_1, string strin_2, string strin_3)
	{
		label2.Visible = false;
		pictureBox1.Image = LoadImage(strin_1);
		Label label = label1;
		string text = "Pay Using QR :- ";
		string text2 = "  Amt=  ";
		label.Text = text + strin_2 + text2 + strin_3;
		ShowDialog();
	}

	public void Form1_Load1(object object_0)
	{
		button1.Visible = false;
		string text = object_0.ToString();
		string[] array = new string[1];
		string text2 = "|||";
		array[0] = text2;
		string[] array2 = text.Split(array, StringSplitOptions.None);
		strin_1 = array2[0];
		string text3 = array2[1];
		string text4 = array2[2];
		pictureBox1.Image = LoadImage(strin_1);
		Label label = label1;
		string text5 = "Pay Using QR :- ";
		string text6 = "  Amt=  ";
		label.Text = text5 + text3 + text6 + text4;
		ShowDialog(base.ParentForm);
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void label1_Click(object sender, EventArgs e)
	{
	}

	private void FrmQr_Load(object sender, EventArgs e)
	{
	}

	private void label2_Click(object sender, EventArgs e)
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
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.button1 = new System.Windows.Forms.Button();
		this.label1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		base.SuspendLayout();
		this.pictureBox1.Location = new System.Drawing.Point(14, 51);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new System.Drawing.Size(300, 300);
		this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pictureBox1.TabIndex = 0;
		this.pictureBox1.TabStop = false;
		this.pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
		this.button1.BackColor = System.Drawing.Color.Yellow;
		this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.button1.Location = new System.Drawing.Point(9, 9);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(302, 32);
		this.button1.TabIndex = 1;
		this.button1.Text = "Paid!! Click here!!!!";
		this.button1.UseVisualStyleBackColor = false;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.Location = new System.Drawing.Point(11, 354);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(59, 20);
		this.label1.TabIndex = 2;
		this.label1.Text = "label1";
		this.label1.Click += new System.EventHandler(label1_Click);
		this.label2.AutoSize = true;
		this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label2.Location = new System.Drawing.Point(12, 9);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(309, 40);
		this.label2.TabIndex = 3;
		this.label2.Text = "Payment Sucess hone par QR auto \r\n                close ho jayega.";
		this.label2.Click += new System.EventHandler(label2_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(323, 380);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.pictureBox1);
		base.Name = "FrmQr";
		this.Text = "Scan and Pay..";
		base.Load += new System.EventHandler(FrmQr_Load);
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
