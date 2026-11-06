using System.Collections.Generic;

public class BookingResponse
{
	public string trainName { get; set; }

	public string distance { get; set; }

	public string boardingStn { get; set; }

	public string boardingDate { get; set; }

	public string journeyDate { get; set; }

	public string transactionId { get; set; }

	public string reservationId { get; set; }

	public string pnrNumber { get; set; }

	public string departureTime { get; set; }

	public string arrivalTime { get; set; }

	public string bookingDate { get; set; }

	public string trainNumber { get; set; }

	public string fromStn { get; set; }

	public string destStn { get; set; }

	public string journeyClass { get; set; }

	public string journeyQuota { get; set; }

	public string totalFare { get; set; }

	public string totalCollectibleAmount { get; set; }

	public string ticketType { get; set; }

	public string reservationStatus { get; set; }

	public string trainChartStatus { get; set; }

	public string insuranceCompany { get; set; }

	public string insuranceOpted { get; set; }

	public List<Passenger123> psgnDtlList { get; set; }

	public List<ReservationDetail> resvDetails { get; set; }
}
