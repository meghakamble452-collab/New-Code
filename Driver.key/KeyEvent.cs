namespace Driver.key;

internal class KeyEvent
{
	public string key = "2";

	public long delay;

	public int id;

	public KeyEvent(long delay, int id)
	{
		this.delay = delay;
		this.id = id;
	}
}
