using BushidoAdministration.HourTicket.api.Contexts;
using BushidoAdministration.HourTicket.api.Entities;

namespace BushidoAdministration.HourTicket.api.Repositories
{
	public class ActivityRepository : IActivityRepository
	{
		private readonly IContext _context;

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
