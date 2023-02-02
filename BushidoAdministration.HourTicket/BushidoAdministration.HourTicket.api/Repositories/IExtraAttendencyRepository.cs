using BushidoAdministration.HourTicket.api.Entities;

namespace BushidoAdministration.HourTicket.api.Repositories
{
	public interface IExtraAttendencyRepository
	{
		public Task<bool> Create(ExtraAttendency notJustifiedAttendency);
		public Task<ExtraAttendency> Get(int id);
		public Task<ExtraAttendency> GetFromAttendence(int attendenceId);
		public Task<bool> Update(ExtraAttendency extraAttendency);
		public Task<bool> ChangeJustified(int id);
		public Task<bool> Delete(int id);
	}
}
