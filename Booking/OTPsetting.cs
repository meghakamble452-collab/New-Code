using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

namespace Booking;

public class OTPsetting : Form
{
	private IContainer icontainer_0;

	private BunifuElipse bunifuElipse_0;

	private BunifuDragControl bunifuDragControl_0;

	public OTPsetting()
	{
		InitializeComponent();
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
		this.bunifuElipse_0 = new Bunifu.Framework.UI.BunifuElipse(this.icontainer_0);
		this.bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(this.icontainer_0);
		base.SuspendLayout();
		this.bunifuElipse_0.ElipseRadius = 5;
		this.bunifuElipse_0.TargetControl = this;
		this.bunifuDragControl_0.Fixed = true;
		this.bunifuDragControl_0.Horizontal = true;
		this.bunifuDragControl_0.TargetControl = null;
		this.bunifuDragControl_0.Vertical = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(391, 308);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "OTPsetting";
		this.Text = "OTPsetting";
		base.ResumeLayout(false);
	}
}
