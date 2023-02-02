using BushidoAdministration.HourTicket.api.Entities;

namespace BushidoAdministration.HourTicket.api.Repositories
{
	public class ExtraAttendencyRepository : IExtraAttendencyRepository
	{
		public Task<bool> ChangeJustified(int id)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Create(ExtraAttendency notJustifiedAttendency)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Delete(int id)
		{
			throw new NotImplementedException();
		}

		public Task<ExtraAttendency> Get(int id)
		{
			throw new NotImplementedException();
		}

		public Task<ExtraAttendency> GetFromAttendence(int attendenceId)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Update(ExtraAttendency extraAttendency)
		{
			throw new NotImplementedException();
		}
	}
}
