namespace BushidoAdministration.HourTicket.api.Entities
{
	public class NotJustifiedAttendency
	{
		public int Id { get; set; }
		
		public int AttendenceId { get; set; }
		public Attendence? Attendence { get; set; } = null;

		public string? Motivation { get; set; } = string.Empty;
	}
}
