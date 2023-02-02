using BushidoAdministration.HourTicket.api.Entities;

namespace BushidoAdministration.HourTicket.api.Repositories
{
	public class RegularScheduleRepository : IRegularScheduleRepository
	{
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
