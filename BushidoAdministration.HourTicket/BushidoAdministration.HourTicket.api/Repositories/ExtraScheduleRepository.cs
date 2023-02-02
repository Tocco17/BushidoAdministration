using BushidoAdministration.HourTicket.api.Entities;

namespace BushidoAdministration.HourTicket.api.Repositories
{
	public class ExtraScheduleRepository : IExtraScheduleRepository
	{
		public Task<bool> Create(ExtraSchedule extraSchedule)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Delete(int id)
		{
			throw new NotImplementedException();
		}

		public Task<ExtraSchedule> Get(int id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<ExtraSchedule>> GetFromActivity(int activityId)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Update(ExtraSchedule extraSchedule)
		{
			throw new NotImplementedException();
		}
	}
}
