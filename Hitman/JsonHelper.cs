using Newtonsoft.Json;

namespace Hitman;

public class JsonHelper
{
	public static BookingRoot Parse(string json)
	{
		return JsonConvert.DeserializeObject<BookingRoot>(json);
	}
}
