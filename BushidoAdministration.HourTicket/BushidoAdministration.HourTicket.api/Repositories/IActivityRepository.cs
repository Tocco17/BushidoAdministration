using BushidoAdministration.HourTicket.api.Entities;

namespace BushidoAdministration.HourTicket.api.Repositories
{
	public interface IActivityRepository
	{
		public Task<bool> Create(Activity activity);
		public Task<Activity> Get(int id);
		public Task<bool> Update(Activity activity);
		public Task<bool> Delete(int id);
	}
}
