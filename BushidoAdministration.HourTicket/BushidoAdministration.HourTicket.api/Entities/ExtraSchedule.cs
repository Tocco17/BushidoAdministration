namespace BushidoAdministration.HourTicket.api.Entities
{
	public class ExtraSchedule
	{
		public int Id { get; set; }
		
		public int ActivityId { get; set; }
		public Activity? Activity { get; set; } = null;

		public DateTime Date { get; set; }
		public TimeOnly StartHour { get; set; }
		public TimeOnly EndHour { get; set; }
	}
}
