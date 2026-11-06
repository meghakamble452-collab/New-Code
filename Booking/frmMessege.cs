using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

namespace Booking;

public class frmMessege : Form
{
	private IContainer icontainer_0;

	private BunifuElipse bunifuElipse_0;

	private Label label2;

	private Label label1;

	private Label label3;

	private Button OK;

	private Panel panel1;

	private IContainer components;

	public frmMessege()
	{
		InitializeComponent();
	}

	internal void mm()
	{
		base.TopMost = true;
		ShowDialog();
	}

	private void OK_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.OK;
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
		this.components = new System.ComponentModel.Container();
		this.bunifuElipse_0 = new Bunifu.Framework.UI.BunifuElipse(this.components);
		this.label1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.OK = new System.Windows.Forms.Button();
		this.label3 = new System.Windows.Forms.Label();
		this.panel1 = new System.Windows.Forms.Panel();
		this.panel1.SuspendLayout();
		base.SuspendLayout();
		this.bunifuElipse_0.ElipseRadius = 5;
		this.bunifuElipse_0.TargetControl = this;
		this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label1.Location = new System.Drawing.Point(254, 12);
		this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(315, 36);
		this.label1.TabIndex = 1;
		this.label1.Text = "Important information";
		this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.label2.Location = new System.Drawing.Point(15, 65);
		this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(805, 304);
		this.label2.TabIndex = 1;
		this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.OK.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.OK.Location = new System.Drawing.Point(644, 37);
		this.OK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.OK.Name = "OK";
		this.OK.Size = new System.Drawing.Size(182, 50);
		this.OK.TabIndex = 2;
		this.OK.Text = "OK";
		this.OK.UseVisualStyleBackColor = true;
		this.OK.Click += new System.EventHandler(OK_Click);
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(289, 51);
		this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(209, 20);
		this.label3.TabIndex = 3;
		this.label3.Text = "Regard's *** Nget Admin***";
		this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
		this.panel1.Controls.Add(this.OK);
		this.panel1.Controls.Add(this.label3);
		this.panel1.Location = new System.Drawing.Point(-6, 373);
		this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(844, 104);
		this.panel1.TabIndex = 4;
		base.AutoScaleDimensions = new System.Drawing.SizeF(154f, 154f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
		this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
		base.ClientSize = new System.Drawing.Size(835, 476);
		base.Controls.Add(this.panel1);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
		base.Name = "frmMessege";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "frmMessege";
		this.panel1.ResumeLayout(false);
		this.panel1.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
