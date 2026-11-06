using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Booking;

namespace APP_FRAMEWORK;

internal class Form0 : Form
{
	public enum Enum6
	{
		AbortRetryIgnore = 1,
		OK,
		OKCancel,
		RetryCancel,
		YesNo,
		YesNoCancel
	}

	public enum Enum7
	{
		Application = 1,
		Exclamation,
		Error,
		Warning,
		Info,
		Question,
		Shield,
		Search
	}

	public enum Enum8
	{
		SlideDown = 1,
		FadeIn,
		ZoomIn
	}

	private static Form0 form0_0;

	private Panel panel_0;

	private Panel panel_1;

	private Panel panel_2;

	private PictureBox pictureBox_0;

	private FlowLayoutPanel flowLayoutPanel_0;

	private Label B0AAA;

	private Label C0AA0;

	private List<Button> list_0;

	private static DialogResult dialogResult_0;

	private static Timer timer_0;

	private static Point point_0;

	protected override CreateParams CreateParams
	{
		get
		{
			CreateParams createParams = base.CreateParams;
			createParams.ClassStyle |= 131072;
			return createParams;
		}
	}

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	private static extern bool MessageBeep(uint uint_0);

	public Form0()
	{
		panel_0 = new Panel();
		panel_1 = new Panel();
		panel_2 = new Panel();
		pictureBox_0 = new PictureBox();
		flowLayoutPanel_0 = new FlowLayoutPanel();
		list_0 = new List<Button>();
		base.FormBorderStyle = FormBorderStyle.None;
		BackColor = Color.FromArgb(46, 49, 146);
		base.StartPosition = FormStartPosition.CenterScreen;
		base.Padding = new Padding(3);
		base.Width = 400;
		B0AAA = new Label();
		B0AAA.ForeColor = Color.Red;
		Label b0AAA = B0AAA;
		string familyName = "Arial";
		b0AAA.Font = new Font(familyName, 10f);
		B0AAA.Dock = DockStyle.Top;
		B0AAA.Height = 20;
		C0AA0 = new Label();
		C0AA0.ForeColor = Color.Black;
		Label c0AA = C0AA0;
		string familyName2 = "Arial";
		c0AA.Font = new Font(familyName2, 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		C0AA0.Dock = DockStyle.Fill;
		flowLayoutPanel_0.FlowDirection = FlowDirection.RightToLeft;
		flowLayoutPanel_0.Dock = DockStyle.Fill;
		panel_0.Dock = DockStyle.Fill;
		panel_0.Padding = new Padding(20);
		panel_0.Controls.Add(C0AA0);
		panel_0.Controls.Add(B0AAA);
		panel_1.Dock = DockStyle.Bottom;
		panel_1.Padding = new Padding(20);
		panel_1.BackColor = Color.FromArgb(26, 33, 72);
		panel_1.Height = 80;
		panel_1.Controls.Add(flowLayoutPanel_0);
		pictureBox_0.Width = 32;
		pictureBox_0.Height = 32;
		pictureBox_0.Location = new Point(30, 50);
		panel_2.Dock = DockStyle.Left;
		panel_2.Padding = new Padding(20);
		panel_2.Width = 70;
		panel_2.Controls.Add(pictureBox_0);
		foreach (Control item in new List<Control> { this, B0AAA, C0AA0, flowLayoutPanel_0, panel_0, panel_1, panel_2, pictureBox_0 })
		{
			item.MouseDown += smethod_0;
			item.MouseMove += smethod_1;
		}
		base.Controls.Add(panel_0);
		base.Controls.Add(panel_2);
		base.Controls.Add(panel_1);
	}

	private static void smethod_0(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			point_0 = new Point(e.X, e.Y);
		}
	}

	private static void smethod_1(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			form0_0.Left += e.X - point_0.X;
			form0_0.Top += e.Y - point_0.Y;
		}
	}

	public static DialogResult smethod_6(string string_0, string string_1, Enum6 enum6_0, Enum7 enum7_0, Enum8 enum8_0)
	{
		form0_0 = new Form0();
		form0_0.C0AA0.Text = string_0;
		form0_0.B0AAA.Text = string_1;
		form0_0.Height = 0;
		smethod_3(enum6_0);
		smethod_4(enum7_0);
		timer_0 = new Timer();
		Size size = smethod_7(string_0);
		switch (enum8_0)
		{
		case Enum8.SlideDown:
			form0_0.Size = new Size(size.Width, 0);
			timer_0.Interval = 1;
			timer_0.Tag = new Class28(size, enum8_0);
			break;
		case Enum8.FadeIn:
			form0_0.Size = size;
			form0_0.Opacity = 0.0;
			timer_0.Interval = 20;
			timer_0.Tag = new Class28(size, enum8_0);
			break;
		case Enum8.ZoomIn:
			form0_0.Size = new Size(size.Width + 100, size.Height + 100);
			timer_0.Tag = new Class28(size, enum8_0);
			timer_0.Interval = 1;
			break;
		}
		timer_0.Tick += smethod_2;
		timer_0.Start();
		form0_0.ShowDialog();
		MessageBeep(0u);
		return dialogResult_0;
	}

	private static void smethod_2(object sender, EventArgs e)
	{
		Class28 @class = (Class28)((Timer)sender).Tag;
		switch (@class.enum8_0)
		{
		case Enum8.SlideDown:
			if (form0_0.Height < @class.size_0.Height)
			{
				form0_0.Height += 17;
				form0_0.Invalidate();
			}
			else
			{
				timer_0.Stop();
				timer_0.Dispose();
			}
			break;
		case Enum8.FadeIn:
			if (form0_0.Opacity < 1.0)
			{
				form0_0.Opacity += 0.1;
				form0_0.Invalidate();
			}
			else
			{
				timer_0.Stop();
				timer_0.Dispose();
			}
			break;
		case Enum8.ZoomIn:
			if (form0_0.Width > @class.size_0.Width)
			{
				form0_0.Width -= 17;
				form0_0.Invalidate();
			}
			if (form0_0.Height > @class.size_0.Height)
			{
				form0_0.Height -= 17;
				form0_0.Invalidate();
			}
			break;
		}
	}

	private static void smethod_3(Enum6 enum6_0)
	{
		switch (enum6_0)
		{
		case Enum6.AbortRetryIgnore:
			form0_0.method_0();
			break;
		case Enum6.OK:
			form0_0.method_1();
			break;
		case Enum6.OKCancel:
			form0_0.method_2();
			break;
		case Enum6.RetryCancel:
			form0_0.method_3();
			break;
		case Enum6.YesNo:
			form0_0.BAAAA();
			break;
		case Enum6.YesNoCancel:
			form0_0.CAAA0();
			break;
		}
		foreach (Button item in form0_0.list_0)
		{
			item.ForeColor = Color.FromArgb(170, 170, 170);
			string familyName = "Segoe UI";
			item.Font = new Font(familyName, 8f);
			item.Padding = new Padding(3);
			item.FlatStyle = FlatStyle.Flat;
			item.Height = 30;
			item.FlatAppearance.BorderColor = Color.FromArgb(99, 99, 98);
			form0_0.flowLayoutPanel_0.Controls.Add(item);
		}
	}

	private static void smethod_4(Enum7 enum7_0)
	{
		switch (enum7_0)
		{
		case Enum7.Application:
			form0_0.pictureBox_0.Image = SystemIcons.Application.ToBitmap();
			break;
		case Enum7.Exclamation:
			form0_0.pictureBox_0.Image = SystemIcons.Exclamation.ToBitmap();
			break;
		case Enum7.Error:
			form0_0.pictureBox_0.Image = SystemIcons.Error.ToBitmap();
			break;
		case Enum7.Warning:
			form0_0.pictureBox_0.Image = SystemIcons.Warning.ToBitmap();
			break;
		case Enum7.Info:
			form0_0.pictureBox_0.Image = SystemIcons.Information.ToBitmap();
			break;
		case Enum7.Question:
			form0_0.pictureBox_0.Image = SystemIcons.Question.ToBitmap();
			break;
		case Enum7.Shield:
			form0_0.pictureBox_0.Image = SystemIcons.Shield.ToBitmap();
			break;
		}
	}

	private void method_0()
	{
		Button button = new Button();
		string text = "Abort";
		button.Text = text;
		button.Click += smethod_5;
		Button button2 = new Button();
		string text2 = "Retry";
		button2.Text = text2;
		button2.Click += smethod_5;
		Button button3 = new Button();
		string text3 = "Ignore";
		button3.Text = text3;
		button3.Click += smethod_5;
		list_0.Add(button);
		list_0.Add(button2);
		list_0.Add(button3);
	}

	private void method_1()
	{
		Button button = new Button();
		string text = "OK";
		button.Text = text;
		button.Click += smethod_5;
		list_0.Add(button);
	}

	private void method_2()
	{
		Button button = new Button();
		string text = "OK";
		button.Text = text;
		button.Click += smethod_5;
		Button button2 = new Button();
		string text2 = "Cancel";
		button2.Text = text2;
		button2.Click += smethod_5;
		list_0.Add(button);
		list_0.Add(button2);
	}

	private void method_3()
	{
		Button button = new Button();
		string text = "OK";
		button.Text = text;
		button.Click += smethod_5;
		Button button2 = new Button();
		string text2 = "Cancel";
		button2.Text = text2;
		button2.Click += smethod_5;
		list_0.Add(button);
		list_0.Add(button2);
	}

	private void BAAAA()
	{
		Button button = new Button();
		string text = "Yes";
		button.Text = text;
		button.Click += smethod_5;
		Button button2 = new Button();
		string text2 = "No";
		button2.Text = text2;
		button2.Click += smethod_5;
		list_0.Add(button);
		list_0.Add(button2);
	}

	private void CAAA0()
	{
		Button button = new Button();
		string text = "Abort";
		button.Text = text;
		button.Click += smethod_5;
		Button button2 = new Button();
		string text2 = "Retry";
		button2.Text = text2;
		button2.Click += smethod_5;
		Button button3 = new Button();
		string text3 = "Cancel";
		button3.Text = text3;
		button3.Click += smethod_5;
		list_0.Add(button);
		list_0.Add(button2);
		list_0.Add(button3);
	}

	private static void smethod_5(object sender, EventArgs e)
	{
		string text = ((Control)sender).Text;
		switch (PrivateImp.ComputeStringHash(text))
		{
		case 1642511898u:
		{
			string text7 = "No";
			if (text == text7)
			{
				dialogResult_0 = DialogResult.No;
			}
			break;
		}
		case 1256668313u:
		{
			string text3 = "Abort";
			if (text == text3)
			{
				dialogResult_0 = DialogResult.Abort;
			}
			break;
		}
		case 900713019u:
		{
			string text5 = "Cancel";
			if (text == text5)
			{
				dialogResult_0 = DialogResult.Cancel;
			}
			break;
		}
		case 2246359087u:
		{
			string text8 = "OK";
			if (text == text8)
			{
				dialogResult_0 = DialogResult.OK;
			}
			break;
		}
		case 2151067481u:
		{
			string text6 = "Retry";
			if (text == text6)
			{
				dialogResult_0 = DialogResult.Retry;
			}
			break;
		}
		case 3293848931u:
		{
			string text4 = "Ignore";
			if (text == text4)
			{
				dialogResult_0 = DialogResult.Ignore;
			}
			break;
		}
		case 3013883440u:
		{
			string text2 = "Yes";
			if (text == text2)
			{
				dialogResult_0 = DialogResult.Yes;
			}
			break;
		}
		}
		form0_0.Dispose();
	}

	private static Size smethod_7(string string_0)
	{
		Graphics graphics = form0_0.CreateGraphics();
		int num = 350;
		int num2 = 230;
		int num3 = string_0.Split('\r').Length - 1;
		if (num3 > 0)
		{
			num3 /= 2;
			if (num3 > 0)
			{
				num3--;
			}
		}
		string text = string_0;
		string oldValue = "\r\n";
		string_0 = text.Replace(oldValue, "");
		string text2 = string_0;
		string familyName = "Segoe UI";
		SizeF sizeF = graphics.MeasureString(text2, new Font(familyName, 10f));
		if (string_0.Length >= 150)
		{
			string input = string_0;
			string pattern = ".{1,180}";
			int num4 = (from Match capture_0 in Regex.Matches(input, pattern)
				select capture_0.Value).ToArray().Length + 1 + num3;
			num = 700;
			num2 += (int)((double)sizeF.Height + 10.0) * num4;
		}
		else if ((int)sizeF.Width > 350)
		{
			num = (int)sizeF.Width;
		}
		return new Size(num, num2);
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		Graphics graphics = e.Graphics;
		Rectangle rect = new Rectangle(new Point(0, 0), new Size(base.Width - 1, base.Height - 1));
		Pen pen = new Pen(Color.FromArgb(0, 151, 251));
		graphics.DrawRectangle(pen, rect);
	}

	private void method_4()
	{
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form0));
		SuspendLayout();
		base.AutoScaleDimensions = new SizeF(96f, 96f);
		base.AutoScaleMode = AutoScaleMode.Dpi;
		base.ClientSize = new Size(284, 261);
		base.FormBorderStyle = FormBorderStyle.None;
		string name = "$this.Icon";
		base.Icon = (Icon)componentResourceManager.GetObject(name);
		string name2 = "Form0";
		base.Name = name2;
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		ResumeLayout(performLayout: false);
	}

	private void InitializeComponent()
	{
		base.SuspendLayout();
		base.ClientSize = new System.Drawing.Size(948, 542);
		base.Name = "Form0";
		base.ResumeLayout(false);
	}
}
