using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Bunifu.Framework.UI;

namespace IRCommDLL;

public class QrPay : Form
{
	private clsPostData class42_0;

	internal clsMain clsMain;

	internal string string_1;

	internal string string_2;

	internal string string_3;

	internal string string_0;

	internal bool bool_3;

	internal bool bool_0;

	internal static readonly IntPtr intptr_0 = new IntPtr(-1);

	private IContainer components = null;

	private Label label3;

	public PictureBox pictureBox1;

	private Label label2;

	private Panel pnlHeader;

	internal Label tktname;

	private BunifuImageButton btnCancel;

	[DllImport("user32.dll")]
	public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

	public QrPay()
	{
		InitializeComponent();
		base.Name = "frmPayment-" + Thread.CurrentThread.ManagedThreadId;
	}

	public static void EnsureShowsTaskbar(Form form)
	{
		if (form != null && !form.IsDisposed)
		{
			Screen screen = Screen.FromControl(form);
			Rectangle bounds = screen.Bounds;
			Rectangle workingArea = screen.WorkingArea;
			Rectangle bounds2 = form.Bounds;
			int val = bounds2.Left;
			int val2 = bounds2.Top;
			if (bounds2.Left < workingArea.Left)
			{
				val = workingArea.Left;
			}
			if (bounds2.Right > workingArea.Right)
			{
				val = Math.Max(workingArea.Left, bounds2.Left - (bounds2.Right - workingArea.Right));
			}
			if (bounds2.Top < workingArea.Top)
			{
				val2 = workingArea.Top;
			}
			if (bounds2.Bottom > workingArea.Bottom)
			{
				val2 = Math.Max(workingArea.Top, bounds2.Top - (bounds2.Bottom - workingArea.Bottom));
			}
			val = Math.Min(Math.Max(val, bounds.Left), bounds.Right - bounds2.Width);
			val2 = Math.Min(Math.Max(val2, bounds.Top), bounds.Bottom - bounds2.Height);
			if (val != bounds2.Left || val2 != bounds2.Top)
			{
				form.Location = new Point(val, val2);
			}
		}
	}

	internal void method_0QR(Control control_0, Rectangle rectangle_0)
	{
		try
		{
			_ = Screen.PrimaryScreen.WorkingArea;
			_ = control_0.Controls[0];
			Control control = control_0.Parent;
			base.StartPosition = FormStartPosition.Manual;
			base.Location = control.Location;
			EnsureShowsTaskbar(this);
			_ = control.Location.Y;
			SetWindowPos(base.Handle, intptr_0, 0, 0, 0, 0, 3u);
			_ = base.Top;
			_ = base.Height;
			base.TopMost = true;
			Show();
			pictureBox1.BringToFront();
			Activate();
		}
		catch (Exception)
		{
		}
	}

	internal void method_0AA(Control control_0, Rectangle rectangle_0)
	{
		try
		{
			if (control_0 != null && control_0.Parent != null)
			{
				Control control = control_0.Parent;
				base.StartPosition = FormStartPosition.Manual;
				base.Location = control.Location;
				base.TopMost = true;
				base.Left += 2;
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show("method_0 error: " + ex.Message);
		}
	}

	internal void method_0(Control control_0, Rectangle rectangle_0)
	{
		Rectangle workingArea = Screen.GetWorkingArea(this);
		base.Left = 0;
		_ = control_0.Controls[0];
		Control control = control_0.Parent;
		base.StartPosition = FormStartPosition.Manual;
		Control control2 = control_0.Parent;
		int num = control2.Location.X;
		int num2 = control2.Location.Y;
		int num3 = workingArea.Height;
		if (num3 > base.Height)
		{
			base.Location = new Point(num, num2);
		}
		else
		{
			base.Location = new Point(num, num2);
		}
		base.TopMost = true;
		base.Left += 2;
	}

	internal void method_0yy(Control control_0, Rectangle rectangle_0)
	{
		try
		{
			if (control_0 != null && control_0.Parent != null)
			{
				Control control = control_0.Parent;
				Point point = control.PointToScreen(Point.Empty);
				base.StartPosition = FormStartPosition.Manual;
				int num = point.X;
				Rectangle workingArea = Screen.GetWorkingArea(control);
				int num2 = ((point.Y + control.Height + base.Height >= workingArea.Bottom) ? (point.Y - base.Height) : (point.Y + control.Height));
				base.Location = new Point(num, num2);
				base.TopMost = true;
				if (!base.Visible)
				{
					Show();
				}
				BringToFront();
				Activate();
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show("Error: " + ex.Message);
		}
	}

	internal void method_1AA(object string_5)
	{
		string_3 = string_5.ToString();
		string text = string_3;
		string[] array = new string[1];
		string text2 = "|||";
		array[0] = text2;
		string[] array2 = text.Split(array, StringSplitOptions.None);
		pictureBox1.Image = LoadImage(array2[0]);
		string text3 = "Pay Using QR :- ";
		string text4 = array2[1];
		string text5 = "  Amt=  ";
		label3.Text = text3 + text4 + text5 + array2[2];
		tktname.Text = array2[2];
		method_0(clsMain.control_0, clsMain.rectangle_0);
	}

	internal DialogResult method_1(Control control_0, Rectangle rectangle_0, clsPostData class42_1, string state)
	{
		class42_0 = class42_1;
		if (base.InvokeRequired)
		{
			return (DialogResult)Invoke((Func<DialogResult>)(() => method_1(control_0, rectangle_0, class42_1, state)));
		}
		method_0(control_0, rectangle_0);
		try
		{
			SetWindowPos(base.Handle, intptr_0, 0, 0, 0, 0, 3u);
			if (string.IsNullOrEmpty(state))
			{
				MessageBox.Show("State empty hai");
				return DialogResult.Cancel;
			}
			string[] array = state.Split(new string[1] { "|||" }, StringSplitOptions.None);
			if (array.Length < 3)
			{
				MessageBox.Show("Invalid QR data format");
				return DialogResult.Cancel;
			}
			string_0 = array[0];
			string text = array[2];
			string text2 = array[1];
			tktname.Text = text2;
			Image image = LoadImage(string_0);
			if (image == null)
			{
				MessageBox.Show("QR Image load nahi hua");
				return DialogResult.Cancel;
			}
			pictureBox1.Image = image;
			label3.Text = "Pay Using QR :- " + text;
			return ShowDialog();
		}
		catch (Exception ex)
		{
			MessageBox.Show("method_1 error: " + ex.Message);
			return DialogResult.Cancel;
		}
	}

	public Image LoadImage(string base64)
	{
		try
		{
			if (string.IsNullOrEmpty(base64))
			{
				return null;
			}
			byte[] buffer = Convert.FromBase64String(base64);
			using MemoryStream stream = new MemoryStream(buffer);
			return Image.FromStream(stream);
		}
		catch
		{
			return null;
		}
	}

	private void button8_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void QrPay_Load_1(object sender, EventArgs e)
	{
		base.TopMost = true;
		BringToFront();
		Activate();
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IRCommDLL.QrPay));
		this.label3 = new System.Windows.Forms.Label();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.label2 = new System.Windows.Forms.Label();
		this.pnlHeader = new System.Windows.Forms.Panel();
		this.tktname = new System.Windows.Forms.Label();
		this.btnCancel = new Bunifu.Framework.UI.BunifuImageButton();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		this.pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.btnCancel).BeginInit();
		base.SuspendLayout();
		this.label3.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
		this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label3.ForeColor = System.Drawing.Color.Red;
		this.label3.Location = new System.Drawing.Point(1, 274);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(234, 16);
		this.label3.TabIndex = 1211;
		this.label3.Text = "Scan For Token App";
		this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.pictureBox1.Location = new System.Drawing.Point(2, 58);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new System.Drawing.Size(233, 213);
		this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pictureBox1.TabIndex = 1210;
		this.pictureBox1.TabStop = false;
		this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label2.Location = new System.Drawing.Point(-1, 19);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(236, 34);
		this.label2.TabIndex = 1212;
		this.label2.Text = "Payment Sucess hone par QR auto \r\n                close ho jayega.";
		this.pnlHeader.BackColor = System.Drawing.Color.MediumSlateBlue;
		this.pnlHeader.Controls.Add(this.tktname);
		this.pnlHeader.Controls.Add(this.btnCancel);
		this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
		this.pnlHeader.ForeColor = System.Drawing.Color.White;
		this.pnlHeader.Location = new System.Drawing.Point(0, 0);
		this.pnlHeader.Name = "pnlHeader";
		this.pnlHeader.Size = new System.Drawing.Size(239, 15);
		this.pnlHeader.TabIndex = 1215;
		this.tktname.AutoSize = true;
		this.tktname.BackColor = System.Drawing.Color.Transparent;
		this.tktname.ForeColor = System.Drawing.Color.Black;
		this.tktname.Location = new System.Drawing.Point(-1, 2);
		this.tktname.Name = "tktname";
		this.tktname.Size = new System.Drawing.Size(45, 13);
		this.tktname.TabIndex = 23;
		this.tktname.Text = "tktname";
		this.btnCancel.BackColor = System.Drawing.Color.Transparent;
		this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		this.btnCancel.Image = (System.Drawing.Image)resources.GetObject("btnCancel.Image");
		this.btnCancel.ImageActive = null;
		this.btnCancel.Location = new System.Drawing.Point(222, 0);
		this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(15, 15);
		this.btnCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.btnCancel.TabIndex = 1187;
		this.btnCancel.TabStop = false;
		this.btnCancel.Zoom = 10;
		this.btnCancel.Click += new System.EventHandler(btnCancel_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(239, 293);
		base.Controls.Add(this.pnlHeader);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.pictureBox1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "QrPay";
		this.Text = "QrPay";
		base.TopMost = true;
		base.Load += new System.EventHandler(QrPay_Load_1);
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		this.pnlHeader.ResumeLayout(false);
		this.pnlHeader.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.btnCancel).EndInit();
		base.ResumeLayout(false);
	}
}
