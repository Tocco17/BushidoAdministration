using BushidoAdministration.HourTicket.api.Entities;

namespace BushidoAdministration.HourTicket.api.Repositories
{
	public interface IExtraScheduleRepository
	{
		public Task<bool> Create(ExtraSchedule extraSchedule);
		public Task<ExtraSchedule> Get(int id);
		public Task<IEnumerable<ExtraSchedule>> GetFromActivity(int activityId);
		public Task<bool> Update(ExtraSchedule extraSchedule);
		public Task<bool> Delete(int id);
	}
}
