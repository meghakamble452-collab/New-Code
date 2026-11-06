using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace APP_FRAMEWORK;

public class Captchaa : Form
{
	public string CaptchaTxt = "";

	private IContainer icontainer_0;

	public Panel Panel4;

	public Button Button4;

	public PictureBox PictureBox1;

	public TextBox txtCap;

	public Button Button1;

	public Captchaa()
	{
		InitializeComponent();
	}

	public void Captchaa_img(Image image_0)
	{
		PictureBox1.Image = image_0;
		ShowDialog();
	}

	public void Captchaa_imgtxt(Image image_0, string text)
	{
		PictureBox1.Image = image_0;
		txtCap.Text = text;
		ShowDialog();
	}

	private void Button1_Click(object sender, EventArgs e)
	{
		CaptchaTxt = txtCap.Text;
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void Button4_Click(object sender, EventArgs e)
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
		this.Panel4 = new System.Windows.Forms.Panel();
		this.Button4 = new System.Windows.Forms.Button();
		this.PictureBox1 = new System.Windows.Forms.PictureBox();
		this.txtCap = new System.Windows.Forms.TextBox();
		this.Button1 = new System.Windows.Forms.Button();
		this.Panel4.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.PictureBox1).BeginInit();
		base.SuspendLayout();
		this.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.Panel4.Controls.Add(this.Button4);
		this.Panel4.Controls.Add(this.PictureBox1);
		this.Panel4.Controls.Add(this.txtCap);
		this.Panel4.Controls.Add(this.Button1);
		this.Panel4.ForeColor = System.Drawing.Color.Black;
		this.Panel4.Location = new System.Drawing.Point(1, 2);
		this.Panel4.Name = "Panel4";
		this.Panel4.Size = new System.Drawing.Size(346, 187);
		this.Panel4.TabIndex = 96;
		this.Button4.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
		this.Button4.FlatAppearance.BorderColor = System.Drawing.Color.Black;
		this.Button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(255, 255, 128);
		this.Button4.Font = new System.Drawing.Font("Calibri", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.Button4.ForeColor = System.Drawing.Color.Black;
		this.Button4.Location = new System.Drawing.Point(22, 158);
		this.Button4.Name = "Button4";
		this.Button4.Size = new System.Drawing.Size(62, 25);
		this.Button4.TabIndex = 3;
		this.Button4.Text = "Refresh";
		this.Button4.UseVisualStyleBackColor = false;
		this.Button4.Click += new System.EventHandler(Button4_Click);
		this.PictureBox1.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
		this.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.PictureBox1.ForeColor = System.Drawing.Color.Black;
		this.PictureBox1.Location = new System.Drawing.Point(3, 1);
		this.PictureBox1.Name = "PictureBox1";
		this.PictureBox1.Size = new System.Drawing.Size(338, 156);
		this.PictureBox1.TabIndex = 0;
		this.PictureBox1.TabStop = false;
		this.txtCap.BackColor = System.Drawing.Color.White;
		this.txtCap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtCap.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtCap.ForeColor = System.Drawing.Color.Black;
		this.txtCap.Location = new System.Drawing.Point(88, 161);
		this.txtCap.Name = "txtCap";
		this.txtCap.Size = new System.Drawing.Size(110, 22);
		this.txtCap.TabIndex = 1;
		this.txtCap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.Button1.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
		this.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.Button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
		this.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(255, 255, 128);
		this.Button1.Font = new System.Drawing.Font("Calibri", 9.75f, System.Drawing.FontStyle.Bold);
		this.Button1.ForeColor = System.Drawing.Color.Black;
		this.Button1.Location = new System.Drawing.Point(203, 158);
		this.Button1.Name = "Button1";
		this.Button1.Size = new System.Drawing.Size(127, 25);
		this.Button1.TabIndex = 2;
		this.Button1.Text = "Submit-CAP";
		this.Button1.UseVisualStyleBackColor = false;
		this.Button1.Click += new System.EventHandler(Button1_Click);
		this.BackColor = System.Drawing.Color.FromArgb(0, 127, 166);
		base.ClientSize = new System.Drawing.Size(350, 192);
		base.Controls.Add(this.Panel4);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "Captchaa";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Captchaa";
		this.Panel4.ResumeLayout(false);
		this.Panel4.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.PictureBox1).EndInit();
		base.ResumeLayout(false);
	}
}
