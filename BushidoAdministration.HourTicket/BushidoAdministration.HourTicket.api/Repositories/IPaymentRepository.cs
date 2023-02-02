using BushidoAdministration.HourTicket.api.Entities;

namespace BushidoAdministration.HourTicket.api.Repositories
{
	public interface IPaymentRepository
	{
		public Task<bool> Create(Payment payment);
		public Task<Payment> Get(int id);
		public Task<IEnumerable<Payment>> GetFromUser(int userId);
		public Task<bool> Update(Payment payment);
		public Task Delete(int id);
	}
}
