namespace Driver.util;

internal class SystemClock
{
	private long startMachine = System2.currentTimeMillis() - Random.nextInt(300000, 180000000);

	public long uptimeMillis()
	{
		return System2.currentTimeMillis() - startMachine;
	}
}
