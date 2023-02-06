using BushidoAdministration.HourTicket.api.Contexts;
using BushidoAdministration.HourTicket.api.Entities;

namespace BushidoAdministration.HourTicket.api.Repositories
{
	public class PaymentRepository : IPaymentRepository
	{
		private readonly IContext _context;

		private readonly string _table = "dbo.payment";

		private static readonly string _id = " id ";
		private static readonly string _userId = " user_id ";
		private static readonly string _pay = " pay ";
		private static readonly string _perTimeInMinutes = " per_time_in_minutes ";

		private static readonly string _idAs = $" {_id} as Id ";
		private static readonly string _userIdAs = $" {_userId} as UserId ";
		private static readonly string _payAs = $" {_pay} as Pay ";
		private static readonly string _perTimeInMinutesAs = $" {_perTimeInMinutes} as PerTimeInMinutes ";

		public PaymentRepository(IContext context)
		{
			_context = context;
		}

		public async Task<Payment> Create(Payment payment)
		{
			var query = $"insert into {_table} ({_userId}, {_pay}, {_perTimeInMinutes}) " +
				$"values ({payment.UserId}, {payment.Pay}, {payment.PerTimeInMinutes}";
			return await _context.CreateAsync<Payment>(query);
		}

		public async Task<bool> Delete(int id)
		{
			var query = $"delete from {_table} where {_id} = {id}";
			return await _context.DeleteAsync(query);
		}

		public async Task<Payment> Get(int id)
		{
			var query = $"select top(1) {_idAs}, {_userIdAs}, {_payAs}, {_perTimeInMinutesAs} " +
				$"from {_table} " +
				$"where {_id} = {id}";

			return await _context.GetSingleAsync<Payment>(query);
		}

		public async Task<IEnumerable<Payment>> GetFromUser(int userId)
		{
			var query = $"select {_idAs}, {_userIdAs}, {_payAs}, {_perTimeInMinutesAs} " +
				$"from {_table} " +
				$"where {_userId} = {userId}";

			return await _context.GetAsync<Payment>(query);
		}

		public async Task<bool> Update(Payment payment)
		{
			var query = $"update {_table} set " +
				$"{_userId} = {payment.UserId}, " +
				$"{_pay} = {payment.Pay}, " +
				$"{_perTimeInMinutes} = {payment.PerTimeInMinutes} " +
				$"where {_id} = {payment.Id}";
			return await _context.UpdateAsync(query);
		}
	}
}
