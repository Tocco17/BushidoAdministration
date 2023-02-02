using BushidoAdministration.HourTicket.api.Entities;

namespace BushidoAdministration.HourTicket.api.Repositories
{
	public interface IRegularScheduleRepository
	{
		public Task<bool> Create(RegularSchedule regularSchedule);
		public Task<RegularSchedule> Get(int id);
		public Task<IEnumerable<RegularSchedule>> GetFromActivity(int activityId);
		public Task<bool> Update(RegularSchedule regularSchedule);
		public Task<bool> Delete(int id);
	}
}
