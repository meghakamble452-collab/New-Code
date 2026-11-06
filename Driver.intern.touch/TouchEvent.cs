namespace Driver.intern.touch;

internal class TouchEvent
{
	public int type;

	public int delay;

	public int pointerCount = 1;

	public int touchType = 1;

	internal TouchEvent(int type, int delay)
	{
		this.type = type;
		this.delay = delay;
	}
}
