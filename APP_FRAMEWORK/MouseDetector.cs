using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace APP_FRAMEWORK;

internal class MouseDetector
{
	public delegate void MouseMoveDLG(object sender, Point p);

	public struct POINT
	{
		public int X;

		public int Y;

		public POINT(int x, int y)
		{
			X = x;
			Y = y;
		}
	}

	private Timer timer_0 = new Timer
	{
		Interval = 10
	};

	public event MouseMoveDLG MouseMove;

	[DllImport("gdi32")]
	public static extern uint GetPixel(IntPtr hDC, int XPos, int YPos);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	public static extern bool GetCursorPos(out POINT pt);

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	public static extern IntPtr GetWindowDC(IntPtr hWnd);

	public MouseDetector()
	{
		timer_0.Tick += timer_0_Tick;
		timer_0.Start();
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		GetCursorPos(out var pt);
		if (this.MouseMove != null)
		{
			this.MouseMove(this, new Point(pt.X, pt.Y));
		}
	}
}
