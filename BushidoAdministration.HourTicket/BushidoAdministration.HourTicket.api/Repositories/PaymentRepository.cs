using BushidoAdministration.HourTicket.api.Contexts;
using BushidoAdministration.HourTicket.api.Entities;

namespace BushidoAdministration.HourTicket.api.Repositories
{
	public class PaymentRepository : IPaymentRepository
	{
		private readonly IContext _context;

		private readonly string _table = "dbo.payment";

		private readonly string _id = " id as Id ";
		private readonly string _userId = " user_id as UserId ";
		private readonly string _pay = " pay as Pay ";
		private readonly string _perTimeInMinutes = " per_time_in_minutes as PerTimeInMinutes ";

		public PaymentRepository(IContext context)
		{
			_context = context;
		}

		public async Task<bool> Create(Payment payment)
		{
			var query = $"insert into {_table} (user_id, pay, per_time_in_minutes) " +
				$"values ({payment.UserId}, {payment.Pay}, {payment.PerTimeInMinutes}";
			return await _context.CreateAsync<Payment>(query);
		}

		public async Task<bool> Delete(int id)
		{
			var query = $"delete from {_table} where id = {id}";
			return await _context.DeleteAsync(query);
		}

		public async Task<Payment> Get(int id)
		{
			var query = $"select top(1) {_id}, {_userId}, {_pay}, {_perTimeInMinutes} " +
				$"from {_table} " +
				$"where id = {id}";

			return await _context.GetSingleAsync<Payment>(query);
		}

		public async Task<IEnumerable<Payment>> GetFromUser(int userId)
		{
			var query = $"select {_id}, {_userId}, {_pay}, {_perTimeInMinutes} " +
				$"from {_table} " +
				$"where user_id = {userId}";

			return await _context.GetAsync<Payment>(query);
		}

		public async Task<bool> Update(Payment payment)
		{
			var query = $"update {_table} set " +
				$"user_id = {payment.UserId}, " +
				$"pay = {payment.Pay}, " +
				$"per_time_in_minutes = {payment.PerTimeInMinutes} " +
				$"where id = {payment.Id}";
			return await _context.UpdateAsync(query);
		}
	}
}
