using System.Collections.Generic;

public class Root
{
	public List<BookingResponse> bookingResponseList { get; set; }

	public string serverId { get; set; }

	public string timeStamp { get; set; }

	public string eligibleForCancel { get; set; }

	public string showLastTxn { get; set; }
}
