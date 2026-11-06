using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Booking;

internal class Sizee
{
	public static void relocate(Form fo, int ox, int oy)
	{
		new List<Control>();
		List<Control> list = IdentifyControl.findControls(fo);
		for (int i = 0; i < list.Count; i++)
		{
			reposition(list[i], ox, oy);
		}
	}

	public static void reposition(Control c, int ox, int oy)
	{
		int x = c.Location.X * Screen.PrimaryScreen.Bounds.Width / ox;
		int y = c.Location.Y * Screen.PrimaryScreen.Bounds.Height / oy;
		c.Location = new Point(x, y);
		int width = c.Width * Screen.PrimaryScreen.Bounds.Width / ox;
		int height = c.Height * Screen.PrimaryScreen.Bounds.Height / oy;
		c.Width = width;
		c.Height = height;
		if (c is Label || c is Button)
		{
			resizeText(c, ox, oy);
		}
	}

	public static void resizeText(Control l, int ox, int oy)
	{
		float emSize = (float)((double)l.Font.Size * (double)Screen.PrimaryScreen.Bounds.Width / (double)ox + 1.0);
		l.Font = new Font(l.Font.Name, emSize, l.Font.Style);
	}

	public static void repositionForm(Form f, int ox, int oy)
	{
		int x = f.Location.X * Screen.PrimaryScreen.Bounds.Width / ox;
		int y = f.Location.Y * Screen.PrimaryScreen.Bounds.Width / oy;
		f.Location = new Point(x, y);
	}
}
