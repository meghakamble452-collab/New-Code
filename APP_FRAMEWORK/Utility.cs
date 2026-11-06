using System.Drawing;
using System.Windows.Forms;

namespace APP_FRAMEWORK;

public static class Utility
{
	public static void fitFormToScreen(Form form, int h, int w)
	{
		form.Height = (int)((double)form.Height * ((double)Screen.PrimaryScreen.Bounds.Size.Height / (double)h));
		form.Width = (int)((double)form.Width * ((double)Screen.PrimaryScreen.Bounds.Size.Width / (double)w));
		form.Font = new Font(form.Font.FontFamily, form.Font.Size * ((float)Screen.PrimaryScreen.Bounds.Size.Width / (float)w));
		foreach (Control control in form.Controls)
		{
			smethod_0(control, h, w);
		}
	}

	private static void smethod_0(Control control_0, int int_0, int int_1)
	{
		if (Screen.PrimaryScreen.Bounds.Size.Height != int_0)
		{
			control_0.Height = (int)((double)control_0.Height * ((double)Screen.PrimaryScreen.Bounds.Size.Height / (double)int_0));
			control_0.Top = (int)((double)control_0.Top * ((double)Screen.PrimaryScreen.Bounds.Size.Height / (double)int_0));
		}
		if (Screen.PrimaryScreen.Bounds.Size.Width != int_1)
		{
			control_0.Width = (int)((double)control_0.Width * ((double)Screen.PrimaryScreen.Bounds.Size.Width / (double)int_1));
			control_0.Left = (int)((double)control_0.Left * ((double)Screen.PrimaryScreen.Bounds.Size.Width / (double)int_1));
			control_0.Font = new Font(control_0.Font.FontFamily, control_0.Font.Size * ((float)Screen.PrimaryScreen.Bounds.Size.Width / (float)int_1));
		}
		foreach (Control control in control_0.Controls)
		{
			smethod_0(control, int_0, int_1);
		}
	}
}
