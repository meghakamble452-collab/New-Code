using System.Collections.Generic;
using System.Windows.Forms;

namespace Booking;

public static class IdentifyControl
{
	public static List<Control> findControls(Control c)
	{
		List<Control> list = new List<Control>();
		foreach (Control control in c.Controls)
		{
			list.Add(control);
		}
		return list;
	}
}
