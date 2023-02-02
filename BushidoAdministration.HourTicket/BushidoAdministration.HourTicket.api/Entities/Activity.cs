namespace BushidoAdministration.HourTicket.api.Entities
{
	public class Activity
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public bool IsRegular { get; set; }
	}
}
