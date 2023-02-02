using BushidoAdministration.HourTicket.api.Contexts;
using BushidoAdministration.HourTicket.api.Entities;

namespace BushidoAdministration.HourTicket.api.Repositories
{
	public class PaymentRepository : IPaymentRepository
	{
		private readonly IContext _context;

		public PaymentRepository(IContext context)
		{
			_context = context;
		}

		public Task<bool> Create(Payment payment)
		{
			throw new NotImplementedException();
		}

		public Task Delete(int id)
		{
			throw new NotImplementedException();
		}

		public Task<Payment> Get(int id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Payment>> GetFromUser(int userId)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Update(Payment payment)
		{
			throw new NotImplementedException();
		}
	}
}
