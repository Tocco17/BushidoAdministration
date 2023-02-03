using BushidoAdministration.HourTicket.api.Contexts;
using BushidoAdministration.HourTicket.api.Entities;

namespace BushidoAdministration.HourTicket.api.Repositories
{
	public class ActivityRepository : IActivityRepository
	{
		private readonly IContext _context;

		private readonly string _id = " id as Id ";
		private readonly string _name = " name as Name ";
		private readonly string _description = " description as Description ";
		private readonly string _isRegular = " is_regular as IsRegular ";

		public ActivityRepository(IContext context)
		{
			_context = context;
		}

		public Task<bool> Create(Activity activity)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Delete(int id)
		{
			throw new NotImplementedException();
		}

		public Task<Activity> Get(int id)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Update(Activity activity)
		{
			throw new NotImplementedException();
		}
	}
}
