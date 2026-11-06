using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Bunifu.Framework.UI;

internal class frmPayment : Form
{
	private clsPostData class42_0;

	private const uint uint_0 = 1u;

	private const uint uint_1 = 2u;

	internal const uint uint_2 = 3u;

	internal static readonly IntPtr intptr_0 = new IntPtr(-1);

	private Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();

	internal string string_0 = "";

	internal string string_1 = "";

	internal string string_2 = "";

	private string string_3;

	internal bool bool_0;

	internal bool bool_2;

	internal bool bool_3;

	internal bool bool_4;

	internal bool bool_7;

	internal bool bool_Passenger;

	internal bool bool_Alert;

	private string tktname_0;

	private IContainer icontainer_0;

	internal Label lblError;

	internal Label tktname;

	private BunifuImageButton btnCancel;

	private Panel pnlHeader;

	public Button btnSubmit;

	public Button btnNxt;

	private BunifuElipse bunifuElipse_0;

	private IContainer components;

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetWindowPos(IntPtr intptr_1, IntPtr intptr_2, int int_0, int int_1, int int_2, int int_3, uint uint_3);

	public frmPayment()
	{
		InitializeComponent();
		string text = "frmPayment-";
		base.Name = text + Thread.CurrentThread.Name;
		btnNxt.Visible = false;
	}

	internal void method_0(Control control_0, Rectangle rectangle_0)
	{
		_ = control_0.Controls[0];
		Control control = control_0.Parent;
		base.StartPosition = FormStartPosition.Manual;
		base.Location = control.Location;
		base.TopMost = true;
		base.Left += 2;
	}

	internal void method_1_0(Control control_0, Rectangle rectangle_0, clsPostData class42_1, string string_5, string Tkt_Name_)
	{
		tktname_0 = Tkt_Name_;
		class42_0 = class42_1;
		string_3 = string_5;
		method_0(control_0, rectangle_0);
		lblError.Text = string_1;
		lblError.Visible = true;
		try
		{
			SetWindowPos(base.Handle, intptr_0, 0, 0, 0, 0, 3u);
			ThreadPool.QueueUserWorkItem(Loop);
			ShowDialog();
		}
		catch (ThreadAbortException)
		{
			Thread.ResetAbort();
		}
		catch (Exception)
		{
		}
	}

	private void Loop(object j)
	{
		try
		{
			while (true)
			{
				if (clsMain.list_BookingFail.Contains(tktname_0))
				{
					clsMain.list_BookingFail.Remove(tktname_0);
					base.DialogResult = DialogResult.OK;
					Close();
				}
				else
				{
					Application.DoEvents();
					Thread.Sleep(333);
				}
			}
		}
		catch
		{
		}
	}

	internal void method_1(Control control_0, Rectangle rectangle_0, clsPostData class42_1, string string_5)
	{
		class42_0 = class42_1;
		string_3 = string_5;
		method_0(control_0, rectangle_0);
		lblError.Text = string_1;
		lblError.Visible = true;
		try
		{
			SetWindowPos(base.Handle, intptr_0, 0, 0, 0, 0, 3u);
			ShowDialog();
		}
		catch (ThreadAbortException)
		{
			Thread.ResetAbort();
		}
		catch (Exception)
		{
		}
	}

	private void frmPayment_Load(object sender, EventArgs e)
	{
		if (bool_Passenger)
		{
			Button button = btnSubmit;
			string text = "Submit Passenger";
			button.Text = text;
		}
		if (bool_Alert)
		{
			base.Height = 125;
			btnSubmit.Location = new Point(11, 95);
			lblError.Height = 77;
			Button button2 = btnSubmit;
			string text2 = "Close";
			button2.Text = text2;
		}
	}

	private void btnNxt_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	private void lblError_Click(object sender, EventArgs e)
	{
		string text = lblError.Text;
		string caption = "Info";
		MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
	}

	protected new virtual void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayment));
		this.lblError = new System.Windows.Forms.Label();
		this.tktname = new System.Windows.Forms.Label();
		this.btnSubmit = new System.Windows.Forms.Button();
		this.pnlHeader = new System.Windows.Forms.Panel();
		this.btnNxt = new System.Windows.Forms.Button();
		this.btnCancel = new Bunifu.Framework.UI.BunifuImageButton();
		this.bunifuElipse_0 = new Bunifu.Framework.UI.BunifuElipse(this.components);
		this.pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.btnCancel).BeginInit();
		base.SuspendLayout();
		this.lblError.Cursor = System.Windows.Forms.Cursors.Hand;
		this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
		this.lblError.ForeColor = System.Drawing.Color.Black;
		this.lblError.Location = new System.Drawing.Point(-1, 16);
		this.lblError.Name = "lblError";
		this.lblError.Size = new System.Drawing.Size(222, 28);
		this.lblError.TabIndex = 18;
		this.lblError.Text = "Select another Payment";
		this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.lblError.Visible = false;
		this.lblError.Click += new System.EventHandler(lblError_Click);
		this.tktname.AutoSize = true;
		this.tktname.BackColor = System.Drawing.Color.Transparent;
		this.tktname.ForeColor = System.Drawing.Color.Black;
		this.tktname.Location = new System.Drawing.Point(-1, 2);
		this.tktname.Name = "tktname";
		this.tktname.Size = new System.Drawing.Size(45, 13);
		this.tktname.TabIndex = 23;
		this.tktname.Text = "tktname";
		this.btnSubmit.BackColor = System.Drawing.Color.DarkGreen;
		this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Bold);
		this.btnSubmit.ForeColor = System.Drawing.Color.White;
		this.btnSubmit.Location = new System.Drawing.Point(10, 46);
		this.btnSubmit.Margin = new System.Windows.Forms.Padding(2);
		this.btnSubmit.Name = "btnSubmit";
		this.btnSubmit.Size = new System.Drawing.Size(200, 23);
		this.btnSubmit.TabIndex = 1194;
		this.btnSubmit.Text = "Process Payment";
		this.btnSubmit.UseVisualStyleBackColor = false;
		this.btnSubmit.Click += new System.EventHandler(btnNxt_Click);
		this.pnlHeader.BackColor = System.Drawing.Color.MediumSlateBlue;
		this.pnlHeader.Controls.Add(this.tktname);
		this.pnlHeader.Controls.Add(this.btnNxt);
		this.pnlHeader.Controls.Add(this.btnCancel);
		this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
		this.pnlHeader.ForeColor = System.Drawing.Color.White;
		this.pnlHeader.Location = new System.Drawing.Point(0, 0);
		this.pnlHeader.Name = "pnlHeader";
		this.pnlHeader.Size = new System.Drawing.Size(221, 15);
		this.pnlHeader.TabIndex = 1188;
		this.btnNxt.BackColor = System.Drawing.Color.Coral;
		this.btnNxt.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.btnNxt.Location = new System.Drawing.Point(248, 0);
		this.btnNxt.Name = "btnNxt";
		this.btnNxt.Size = new System.Drawing.Size(41, 21);
		this.btnNxt.TabIndex = 1195;
		this.btnNxt.Text = "Next";
		this.btnNxt.UseVisualStyleBackColor = false;
		this.btnNxt.Click += new System.EventHandler(btnNxt_Click);
		this.btnCancel.BackColor = System.Drawing.Color.Transparent;
		this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		this.btnCancel.Image = (System.Drawing.Image)resources.GetObject("btnCancel.Image");
		this.btnCancel.ImageActive = null;
		this.btnCancel.Location = new System.Drawing.Point(204, -1);
		this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(15, 15);
		this.btnCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.btnCancel.TabIndex = 1187;
		this.btnCancel.TabStop = false;
		this.btnCancel.Zoom = 10;
		this.btnCancel.Click += new System.EventHandler(btnCancel_Click);
		this.bunifuElipse_0.ElipseRadius = 5;
		this.bunifuElipse_0.TargetControl = this;
		base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(221, 81);
		base.Controls.Add(this.btnSubmit);
		base.Controls.Add(this.pnlHeader);
		base.Controls.Add(this.lblError);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "frmPayment";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		this.Text = "frmPayment";
		base.TopMost = true;
		base.Load += new System.EventHandler(frmPayment_Load);
		this.pnlHeader.ResumeLayout(false);
		this.pnlHeader.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.btnCancel).EndInit();
		base.ResumeLayout(false);
	}
}
