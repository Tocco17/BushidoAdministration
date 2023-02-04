namespace BushidoAdministration.HourTicket.api.Entities
{
	public class ExtraAttendance
	{
		public int Id { get; set; }
		
		public int AttendanceId { get; set; }
		public Attendance? Attendance { get; set; } = null;

		public string? Motivation { get; set; } = string.Empty;
		public bool IsJustified { get; set; }
	}
}
