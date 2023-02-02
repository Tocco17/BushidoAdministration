namespace BushidoAdministration.HourTicket.api.Entities
{
	public class Attendence
	{
		public int Id { get; set; }
		
		public int UserId { get; set; }
		public User? User { get; set; } = null;

		public int ActivityId { get; set; }
		public Activity? Activity { get; set; } = null;

		public DateTime Day { get; set; }
		public TimeSpan Time { get; set; }
	}
}
