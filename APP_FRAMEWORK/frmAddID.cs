using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

namespace APP_FRAMEWORK;

public class frmAddID : Form
{
	private IContainer components;

	private BunifuElipse bunifuElipse1;

	private Panel pnlHeader;

	private BunifuImageButton btnClose;

	internal Label formName;

	private Panel PnlBase;

	internal tabHistory tabHistory;

	internal tabIrctcId tabIrctcId;

	public frmAddID()
	{
		InitializeComponent();
		pnlHeader.MouseDown += StatClass.Header_MouseDown;
		pnlHeader.MouseMove += StatClass.Header_MouseMove;
		pnlHeader.MouseUp += StatClass.Header_MouseUp;
		base.Width = PnlBase.Width;
		base.Height = PnlBase.Height + 24;
	}

	private void BtnClose_Click(object sender, EventArgs e)
	{
		if (tabHistory.Visible)
		{
			labe6_MouseUp2(sender, new EventArgs());
		}
		else
		{
			Close();
		}
	}

	private void FrmAddID_FormClosing(object sender, FormClosingEventArgs e)
	{
	}

	private void method_0()
	{
		tabIrctcId.Visible = false;
		tabHistory.Visible = false;
	}

	private void Label6_MouseUp(object sender, MouseEventArgs e)
	{
		method_0();
		tabHistory.Visible = true;
		tabHistory.BringToFront();
	}

	internal void labe6_MouseUp(object sender, EventArgs eventArgs)
	{
		method_0();
		tabHistory.Visible = true;
		tabHistory.BringToFront();
	}

	internal void labe6_MouseUp2(object sender, EventArgs eventArgs)
	{
		method_0();
		tabIrctcId.Visible = true;
		tabIrctcId.BringToFront();
	}

	private void frmAddID_Load(object sender, EventArgs e)
	{
		tabHistory.Visible = false;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(APP_FRAMEWORK.frmAddID));
		this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
		this.pnlHeader = new System.Windows.Forms.Panel();
		this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
		this.formName = new System.Windows.Forms.Label();
		this.PnlBase = new System.Windows.Forms.Panel();
		this.tabIrctcId = new APP_FRAMEWORK.tabIrctcId();
		this.tabHistory = new APP_FRAMEWORK.tabHistory();
		this.pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.btnClose).BeginInit();
		this.PnlBase.SuspendLayout();
		base.SuspendLayout();
		this.bunifuElipse1.ElipseRadius = 5;
		this.bunifuElipse1.TargetControl = this;
		this.pnlHeader.AutoSize = true;
		this.pnlHeader.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
		this.pnlHeader.BackColor = System.Drawing.Color.MediumSlateBlue;
		this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pnlHeader.Controls.Add(this.btnClose);
		this.pnlHeader.Controls.Add(this.formName);
		this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
		this.pnlHeader.ForeColor = System.Drawing.Color.Yellow;
		this.pnlHeader.Location = new System.Drawing.Point(0, 0);
		this.pnlHeader.Margin = new System.Windows.Forms.Padding(2);
		this.pnlHeader.Name = "pnlHeader";
		this.pnlHeader.Size = new System.Drawing.Size(764, 25);
		this.pnlHeader.TabIndex = 130;
		this.pnlHeader.Paint += new System.Windows.Forms.PaintEventHandler(pnlHeader_Paint);
		this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnClose.BackColor = System.Drawing.Color.Transparent;
		this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
		this.btnClose.Image = (System.Drawing.Image)resources.GetObject("btnClose.Image");
		this.btnClose.ImageActive = null;
		this.btnClose.Location = new System.Drawing.Point(738, -1);
		this.btnClose.Margin = new System.Windows.Forms.Padding(2);
		this.btnClose.Name = "btnClose";
		this.btnClose.Size = new System.Drawing.Size(22, 22);
		this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.btnClose.TabIndex = 25;
		this.btnClose.TabStop = false;
		this.btnClose.Zoom = 10;
		this.btnClose.Click += new System.EventHandler(BtnClose_Click);
		this.formName.AutoSize = true;
		this.formName.BackColor = System.Drawing.Color.Transparent;
		this.formName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.formName.ForeColor = System.Drawing.Color.Black;
		this.formName.Location = new System.Drawing.Point(323, 3);
		this.formName.Name = "formName";
		this.formName.Size = new System.Drawing.Size(107, 16);
		this.formName.TabIndex = 23;
		this.formName.Text = "ADD IRCTC ID";
		this.PnlBase.AutoSize = true;
		this.PnlBase.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
		this.PnlBase.Controls.Add(this.tabIrctcId);
		this.PnlBase.Controls.Add(this.tabHistory);
		this.PnlBase.Location = new System.Drawing.Point(2, 25);
		this.PnlBase.Name = "PnlBase";
		this.PnlBase.Size = new System.Drawing.Size(763, 367);
		this.PnlBase.TabIndex = 131;
		this.tabIrctcId.BackColor = System.Drawing.SystemColors.Control;
		this.tabIrctcId.Location = new System.Drawing.Point(2, 0);
		this.tabIrctcId.Name = "tabIrctcId";
		this.tabIrctcId.Size = new System.Drawing.Size(758, 364);
		this.tabIrctcId.TabIndex = 1;
		this.tabIrctcId.Load += new System.EventHandler(tabIrctcId_Load);
		this.tabHistory.BackColor = System.Drawing.SystemColors.ActiveCaption;
		this.tabHistory.Location = new System.Drawing.Point(2, 0);
		this.tabHistory.Name = "tabHistory";
		this.tabHistory.Size = new System.Drawing.Size(758, 358);
		this.tabHistory.TabIndex = 0;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.AutoSize = true;
		base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
		this.BackColor = System.Drawing.SystemColors.ActiveCaption;
		base.ClientSize = new System.Drawing.Size(764, 393);
		base.Controls.Add(this.PnlBase);
		base.Controls.Add(this.pnlHeader);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "frmAddID";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Add IRCTC ID";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FrmAddID_FormClosing);
		base.Load += new System.EventHandler(frmAddID_Load);
		this.pnlHeader.ResumeLayout(false);
		this.pnlHeader.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.btnClose).EndInit();
		this.PnlBase.ResumeLayout(false);
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private void pnlHeader_Paint(object sender, PaintEventArgs e)
	{
	}

	private void tabIrctcId_Load(object sender, EventArgs e)
	{
	}
}
