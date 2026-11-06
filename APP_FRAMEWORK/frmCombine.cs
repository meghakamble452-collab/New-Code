using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using BunifuAnimatorNS;

namespace APP_FRAMEWORK;

public class frmCombine : Form
{
	private IContainer components;

	private BunifuTransition bunifuTransition_0;

	private BunifuTransition bunifuTransition_1;

	private BunifuElipse bunifuElipse1;

	private Panel pnlHeader;

	private BunifuImageButton bunifuImageButton1;

	private BunifuImageButton btnClose;

	private Label label5;

	private BunifuThinButton2 bunifuThinButton23;

	private BunifuThinButton2 bunifuThinButton22;

	private BunifuThinButton2 bunifuThinButton21;

	private Panel BAAAA;

	private tabNetBanking CAAA0;

	private tabDebitCard tabDebitCard;

	private tabCreditCard tabCreditCard;

	public frmCombine()
	{
		InitializeComponent();
		pnlHeader.MouseDown += StatClass.Header_MouseDown;
		pnlHeader.MouseMove += StatClass.Header_MouseMove;
		pnlHeader.MouseUp += StatClass.Header_MouseUp;
	}

	private void method_0()
	{
		CAAA0.Visible = false;
		tabDebitCard.Visible = false;
		tabCreditCard.Visible = false;
		BAAAA.Visible = false;
	}

	private void BunifuThinButton21_Click(object sender, EventArgs e)
	{
		method_0();
		CAAA0.Visible = true;
		CAAA0.BringToFront();
		bunifuTransition_1.ShowSync(BAAAA);
	}

	private void BunifuThinButton22_Click(object sender, EventArgs e)
	{
		method_0();
		tabDebitCard.Visible = true;
		tabDebitCard.BringToFront();
		bunifuTransition_1.ShowSync(BAAAA);
	}

	private void BunifuThinButton23_Click(object sender, EventArgs e)
	{
		method_0();
		tabCreditCard.Visible = true;
		tabCreditCard.BringToFront();
		bunifuTransition_1.ShowSync(BAAAA);
	}

	private void FrmCombine_FormClosing(object sender, FormClosingEventArgs e)
	{
		StatClass.method_35();
	}

	private void BtnClose_Click(object sender, EventArgs e)
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
		this.components = new System.ComponentModel.Container();
		BunifuAnimatorNS.Animation animation = new BunifuAnimatorNS.Animation();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(APP_FRAMEWORK.frmCombine));
		BunifuAnimatorNS.Animation animation2 = new BunifuAnimatorNS.Animation();
		this.bunifuTransition_0 = new BunifuAnimatorNS.BunifuTransition(this.components);
		this.BAAAA = new System.Windows.Forms.Panel();
		this.CAAA0 = new APP_FRAMEWORK.tabNetBanking();
		this.tabDebitCard = new APP_FRAMEWORK.tabDebitCard();
		this.tabCreditCard = new APP_FRAMEWORK.tabCreditCard();
		this.bunifuThinButton23 = new Bunifu.Framework.UI.BunifuThinButton2();
		this.bunifuThinButton22 = new Bunifu.Framework.UI.BunifuThinButton2();
		this.bunifuThinButton21 = new Bunifu.Framework.UI.BunifuThinButton2();
		this.pnlHeader = new System.Windows.Forms.Panel();
		this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
		this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
		this.label5 = new System.Windows.Forms.Label();
		this.bunifuTransition_1 = new BunifuAnimatorNS.BunifuTransition(this.components);
		this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
		this.BAAAA.SuspendLayout();
		this.pnlHeader.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.bunifuImageButton1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.btnClose).BeginInit();
		base.SuspendLayout();
		this.bunifuTransition_0.AnimationType = BunifuAnimatorNS.AnimationType.Leaf;
		this.bunifuTransition_0.Cursor = null;
		animation.AnimateOnlyDifferences = true;
		animation.BlindCoeff = (System.Drawing.PointF)resources.GetObject("animation1.BlindCoeff");
		animation.LeafCoeff = 1f;
		animation.MaxTime = 1f;
		animation.MinTime = 0f;
		animation.MosaicCoeff = (System.Drawing.PointF)resources.GetObject("animation1.MosaicCoeff");
		animation.MosaicShift = (System.Drawing.PointF)resources.GetObject("animation1.MosaicShift");
		animation.MosaicSize = 0;
		animation.Padding = new System.Windows.Forms.Padding(0);
		animation.RotateCoeff = 0f;
		animation.RotateLimit = 0f;
		animation.ScaleCoeff = (System.Drawing.PointF)resources.GetObject("animation1.ScaleCoeff");
		animation.SlideCoeff = (System.Drawing.PointF)resources.GetObject("animation1.SlideCoeff");
		animation.TimeCoeff = 0f;
		animation.TransparencyCoeff = 0f;
		this.bunifuTransition_0.DefaultAnimation = animation;
		this.BAAAA.BackColor = System.Drawing.Color.Transparent;
		this.BAAAA.Controls.Add(this.CAAA0);
		this.BAAAA.Controls.Add(this.tabDebitCard);
		this.BAAAA.Controls.Add(this.tabCreditCard);
		this.bunifuTransition_1.SetDecoration(this.BAAAA, BunifuAnimatorNS.DecorationType.None);
		this.bunifuTransition_0.SetDecoration(this.BAAAA, BunifuAnimatorNS.DecorationType.None);
		this.BAAAA.Location = new System.Drawing.Point(9, 88);
		this.BAAAA.Name = "BAAAA";
		this.BAAAA.Size = new System.Drawing.Size(752, 324);
		this.BAAAA.TabIndex = 1217;
		this.CAAA0.BackColor = System.Drawing.Color.Transparent;
		this.bunifuTransition_0.SetDecoration(this.CAAA0, BunifuAnimatorNS.DecorationType.None);
		this.bunifuTransition_1.SetDecoration(this.CAAA0, BunifuAnimatorNS.DecorationType.None);
		this.CAAA0.Location = new System.Drawing.Point(0, 0);
		this.CAAA0.Margin = new System.Windows.Forms.Padding(0);
		this.CAAA0.Name = "CAAA0";
		this.CAAA0.Size = new System.Drawing.Size(742, 310);
		this.CAAA0.TabIndex = 1;
		this.tabDebitCard.BackColor = System.Drawing.Color.Transparent;
		this.bunifuTransition_0.SetDecoration(this.tabDebitCard, BunifuAnimatorNS.DecorationType.None);
		this.bunifuTransition_1.SetDecoration(this.tabDebitCard, BunifuAnimatorNS.DecorationType.None);
		this.tabDebitCard.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tabDebitCard.Location = new System.Drawing.Point(0, 0);
		this.tabDebitCard.Margin = new System.Windows.Forms.Padding(0);
		this.tabDebitCard.Name = "tabDebitCard";
		this.tabDebitCard.Size = new System.Drawing.Size(752, 324);
		this.tabDebitCard.TabIndex = 2;
		this.tabCreditCard.BackColor = System.Drawing.Color.Transparent;
		this.bunifuTransition_0.SetDecoration(this.tabCreditCard, BunifuAnimatorNS.DecorationType.None);
		this.bunifuTransition_1.SetDecoration(this.tabCreditCard, BunifuAnimatorNS.DecorationType.None);
		this.tabCreditCard.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tabCreditCard.Location = new System.Drawing.Point(0, 0);
		this.tabCreditCard.Margin = new System.Windows.Forms.Padding(0);
		this.tabCreditCard.Name = "tabCreditCard";
		this.tabCreditCard.Size = new System.Drawing.Size(752, 324);
		this.tabCreditCard.TabIndex = 3;
		this.bunifuThinButton23.ActiveBorderThickness = 1;
		this.bunifuThinButton23.ActiveCornerRadius = 20;
		this.bunifuThinButton23.ActiveFillColor = System.Drawing.Color.SeaGreen;
		this.bunifuThinButton23.ActiveForecolor = System.Drawing.Color.White;
		this.bunifuThinButton23.ActiveLineColor = System.Drawing.Color.SeaGreen;
		this.bunifuThinButton23.BackColor = System.Drawing.Color.GhostWhite;
		this.bunifuThinButton23.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuThinButton23.BackgroundImage");
		this.bunifuThinButton23.ButtonText = "Credit Card";
		this.bunifuThinButton23.Cursor = System.Windows.Forms.Cursors.Hand;
		this.bunifuTransition_1.SetDecoration(this.bunifuThinButton23, BunifuAnimatorNS.DecorationType.None);
		this.bunifuTransition_0.SetDecoration(this.bunifuThinButton23, BunifuAnimatorNS.DecorationType.None);
		this.bunifuThinButton23.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.bunifuThinButton23.ForeColor = System.Drawing.Color.DimGray;
		this.bunifuThinButton23.IdleBorderThickness = 2;
		this.bunifuThinButton23.IdleCornerRadius = 10;
		this.bunifuThinButton23.IdleFillColor = System.Drawing.Color.White;
		this.bunifuThinButton23.IdleForecolor = System.Drawing.Color.DimGray;
		this.bunifuThinButton23.IdleLineColor = System.Drawing.Color.SeaGreen;
		this.bunifuThinButton23.Location = new System.Drawing.Point(508, 39);
		this.bunifuThinButton23.Margin = new System.Windows.Forms.Padding(5);
		this.bunifuThinButton23.Name = "bunifuThinButton23";
		this.bunifuThinButton23.Size = new System.Drawing.Size(231, 41);
		this.bunifuThinButton23.TabIndex = 1216;
		this.bunifuThinButton23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.bunifuThinButton23.Click += new System.EventHandler(BunifuThinButton23_Click);
		this.bunifuThinButton22.ActiveBorderThickness = 1;
		this.bunifuThinButton22.ActiveCornerRadius = 20;
		this.bunifuThinButton22.ActiveFillColor = System.Drawing.Color.SeaGreen;
		this.bunifuThinButton22.ActiveForecolor = System.Drawing.Color.White;
		this.bunifuThinButton22.ActiveLineColor = System.Drawing.Color.SeaGreen;
		this.bunifuThinButton22.BackColor = System.Drawing.Color.GhostWhite;
		this.bunifuThinButton22.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuThinButton22.BackgroundImage");
		this.bunifuThinButton22.ButtonText = "Debit Card";
		this.bunifuThinButton22.Cursor = System.Windows.Forms.Cursors.Hand;
		this.bunifuTransition_1.SetDecoration(this.bunifuThinButton22, BunifuAnimatorNS.DecorationType.None);
		this.bunifuTransition_0.SetDecoration(this.bunifuThinButton22, BunifuAnimatorNS.DecorationType.None);
		this.bunifuThinButton22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.bunifuThinButton22.ForeColor = System.Drawing.Color.DimGray;
		this.bunifuThinButton22.IdleBorderThickness = 2;
		this.bunifuThinButton22.IdleCornerRadius = 10;
		this.bunifuThinButton22.IdleFillColor = System.Drawing.Color.White;
		this.bunifuThinButton22.IdleForecolor = System.Drawing.Color.DimGray;
		this.bunifuThinButton22.IdleLineColor = System.Drawing.Color.SeaGreen;
		this.bunifuThinButton22.Location = new System.Drawing.Point(263, 39);
		this.bunifuThinButton22.Margin = new System.Windows.Forms.Padding(5);
		this.bunifuThinButton22.Name = "bunifuThinButton22";
		this.bunifuThinButton22.Size = new System.Drawing.Size(231, 41);
		this.bunifuThinButton22.TabIndex = 1215;
		this.bunifuThinButton22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.bunifuThinButton22.Click += new System.EventHandler(BunifuThinButton22_Click);
		this.bunifuThinButton21.ActiveBorderThickness = 1;
		this.bunifuThinButton21.ActiveCornerRadius = 20;
		this.bunifuThinButton21.ActiveFillColor = System.Drawing.Color.SeaGreen;
		this.bunifuThinButton21.ActiveForecolor = System.Drawing.Color.White;
		this.bunifuThinButton21.ActiveLineColor = System.Drawing.Color.SeaGreen;
		this.bunifuThinButton21.BackColor = System.Drawing.Color.GhostWhite;
		this.bunifuThinButton21.BackgroundImage = (System.Drawing.Image)resources.GetObject("bunifuThinButton21.BackgroundImage");
		this.bunifuThinButton21.ButtonText = "Bank";
		this.bunifuThinButton21.Cursor = System.Windows.Forms.Cursors.Hand;
		this.bunifuTransition_1.SetDecoration(this.bunifuThinButton21, BunifuAnimatorNS.DecorationType.None);
		this.bunifuTransition_0.SetDecoration(this.bunifuThinButton21, BunifuAnimatorNS.DecorationType.None);
		this.bunifuThinButton21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.bunifuThinButton21.ForeColor = System.Drawing.Color.DimGray;
		this.bunifuThinButton21.IdleBorderThickness = 2;
		this.bunifuThinButton21.IdleCornerRadius = 10;
		this.bunifuThinButton21.IdleFillColor = System.Drawing.Color.White;
		this.bunifuThinButton21.IdleForecolor = System.Drawing.Color.DimGray;
		this.bunifuThinButton21.IdleLineColor = System.Drawing.Color.SeaGreen;
		this.bunifuThinButton21.Location = new System.Drawing.Point(14, 39);
		this.bunifuThinButton21.Margin = new System.Windows.Forms.Padding(5);
		this.bunifuThinButton21.Name = "bunifuThinButton21";
		this.bunifuThinButton21.Size = new System.Drawing.Size(231, 41);
		this.bunifuThinButton21.TabIndex = 1214;
		this.bunifuThinButton21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.bunifuThinButton21.Click += new System.EventHandler(BunifuThinButton21_Click);
		this.pnlHeader.BackColor = System.Drawing.Color.MediumSlateBlue;
		this.pnlHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.pnlHeader.Controls.Add(this.bunifuImageButton1);
		this.pnlHeader.Controls.Add(this.btnClose);
		this.pnlHeader.Controls.Add(this.label5);
		this.bunifuTransition_1.SetDecoration(this.pnlHeader, BunifuAnimatorNS.DecorationType.None);
		this.bunifuTransition_0.SetDecoration(this.pnlHeader, BunifuAnimatorNS.DecorationType.None);
		this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
		this.pnlHeader.ForeColor = System.Drawing.Color.FromArgb(17, 17, 18);
		this.pnlHeader.Location = new System.Drawing.Point(0, 0);
		this.pnlHeader.Name = "pnlHeader";
		this.pnlHeader.Size = new System.Drawing.Size(753, 31);
		this.pnlHeader.TabIndex = 1210;
		this.bunifuImageButton1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.bunifuImageButton1.BackColor = System.Drawing.Color.SeaGreen;
		this.bunifuImageButton1.Cursor = System.Windows.Forms.Cursors.Hand;
		this.bunifuTransition_1.SetDecoration(this.bunifuImageButton1, BunifuAnimatorNS.DecorationType.None);
		this.bunifuTransition_0.SetDecoration(this.bunifuImageButton1, BunifuAnimatorNS.DecorationType.None);
		this.bunifuImageButton1.Image = (System.Drawing.Image)resources.GetObject("bunifuImageButton1.Image");
		this.bunifuImageButton1.ImageActive = null;
		this.bunifuImageButton1.Location = new System.Drawing.Point(-35, 44);
		this.bunifuImageButton1.Name = "bunifuImageButton1";
		this.bunifuImageButton1.Size = new System.Drawing.Size(26, 20);
		this.bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.bunifuImageButton1.TabIndex = 208;
		this.bunifuImageButton1.TabStop = false;
		this.bunifuImageButton1.Zoom = 10;
		this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnClose.BackColor = System.Drawing.Color.Transparent;
		this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
		this.bunifuTransition_1.SetDecoration(this.btnClose, BunifuAnimatorNS.DecorationType.None);
		this.bunifuTransition_0.SetDecoration(this.btnClose, BunifuAnimatorNS.DecorationType.None);
		this.btnClose.Image = (System.Drawing.Image)resources.GetObject("btnClose.Image");
		this.btnClose.ImageActive = null;
		this.btnClose.Location = new System.Drawing.Point(719, 2);
		this.btnClose.Name = "btnClose";
		this.btnClose.Size = new System.Drawing.Size(31, 26);
		this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.btnClose.TabIndex = 1;
		this.btnClose.TabStop = false;
		this.btnClose.Zoom = 10;
		this.btnClose.Click += new System.EventHandler(BtnClose_Click);
		this.label5.AutoSize = true;
		this.label5.BackColor = System.Drawing.Color.Transparent;
		this.bunifuTransition_0.SetDecoration(this.label5, BunifuAnimatorNS.DecorationType.None);
		this.bunifuTransition_1.SetDecoration(this.label5, BunifuAnimatorNS.DecorationType.None);
		this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 11f, System.Drawing.FontStyle.Bold);
		this.label5.ForeColor = System.Drawing.Color.Black;
		this.label5.Location = new System.Drawing.Point(3, 4);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(43, 20);
		this.label5.TabIndex = 0;
		this.label5.Text = "Bank";
		this.bunifuTransition_1.AnimationType = BunifuAnimatorNS.AnimationType.VertSlide;
		this.bunifuTransition_1.Cursor = null;
		animation2.AnimateOnlyDifferences = true;
		animation2.BlindCoeff = (System.Drawing.PointF)resources.GetObject("animation2.BlindCoeff");
		animation2.LeafCoeff = 0f;
		animation2.MaxTime = 1f;
		animation2.MinTime = 0f;
		animation2.MosaicCoeff = (System.Drawing.PointF)resources.GetObject("animation2.MosaicCoeff");
		animation2.MosaicShift = (System.Drawing.PointF)resources.GetObject("animation2.MosaicShift");
		animation2.MosaicSize = 0;
		animation2.Padding = new System.Windows.Forms.Padding(0);
		animation2.RotateCoeff = 0f;
		animation2.RotateLimit = 0f;
		animation2.ScaleCoeff = (System.Drawing.PointF)resources.GetObject("animation2.ScaleCoeff");
		animation2.SlideCoeff = (System.Drawing.PointF)resources.GetObject("animation2.SlideCoeff");
		animation2.TimeCoeff = 0f;
		animation2.TransparencyCoeff = 0f;
		this.bunifuTransition_1.DefaultAnimation = animation2;
		this.bunifuElipse1.ElipseRadius = 5;
		this.bunifuElipse1.TargetControl = this;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.GhostWhite;
		base.ClientSize = new System.Drawing.Size(753, 406);
		base.Controls.Add(this.BAAAA);
		base.Controls.Add(this.bunifuThinButton23);
		base.Controls.Add(this.bunifuThinButton22);
		base.Controls.Add(this.bunifuThinButton21);
		base.Controls.Add(this.pnlHeader);
		this.bunifuTransition_1.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
		this.bunifuTransition_0.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "frmCombine";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "frmCombine";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FrmCombine_FormClosing);
		this.BAAAA.ResumeLayout(false);
		this.pnlHeader.ResumeLayout(false);
		this.pnlHeader.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.bunifuImageButton1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.btnClose).EndInit();
		base.ResumeLayout(false);
	}
}
