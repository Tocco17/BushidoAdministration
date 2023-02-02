namespace BushidoAdministration.HourTicket.api.Entities
{
	public class ExtraAttendency
	{
		public int Id { get; set; }
		
		public int AttendenceId { get; set; }
		public Attendence? Attendence { get; set; } = null;

		public string? Motivation { get; set; } = string.Empty;
		public bool IsJustified { get; set; }
	}
}
