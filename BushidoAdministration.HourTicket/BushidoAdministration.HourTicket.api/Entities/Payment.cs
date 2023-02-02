namespace BushidoAdministration.HourTicket.api.Entities
{
	public class Payment
	{
		public int Id { get; set; }

		public int UserId { get; set; }
		public User? User { get; set; } = null;

		public decimal Pay { get; set; }
		public decimal PerTimeInMinutes { get; set; }
	}
}
