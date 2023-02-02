using BushidoAdministration.HourTicket.api.Contexts;
using BushidoAdministration.HourTicket.api.Entities;

namespace BushidoAdministration.HourTicket.api.Repositories
{
	public class RegularScheduleRepository : IRegularScheduleRepository
	{
		private readonly IContext _context;

		public RegularScheduleRepository(IContext context)
		{
			_context = context;
		}

		public Task<bool> Create(RegularSchedule regularSchedule)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Delete(int id)
		{
			throw new NotImplementedException();
		}

		public Task<RegularSchedule> Get(int id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<RegularSchedule>> GetFromActivity(int activityId)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Update(RegularSchedule regularSchedule)
		{
			throw new NotImplementedException();
		}
	}
}
