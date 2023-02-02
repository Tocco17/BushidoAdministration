using BushidoAdministration.HourTicket.api.Enum;

namespace BushidoAdministration.HourTicket.api.Entities
{
	public class RegularSchedule
	{
		public int Id { get; set; }
		
		public int ActivityId { get; set; }
		public Activity? Activity { get; set; } = null;

		public WeekDay WeekDay { get; set; }
		public TimeOnly StartHour { get; set; }
		public TimeOnly EndHour { get; set; }
	}
}
