using System.Collections.Generic;

namespace APP_FRAMEWORK;

public class ResponseAkamaiList
{
	public List<string> Token { get; set; }

	public ResponseAkamaiList()
	{
		Token = new List<string>();
	}
}
