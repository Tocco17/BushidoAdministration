using BushidoAdministration.HourTicket.api.Contexts;
using BushidoAdministration.HourTicket.api.Entities;

namespace BushidoAdministration.HourTicket.api.Repositories
{
	public class ExtraAttendencyRepository : IExtraAttendencyRepository
	{
		private readonly IContext _context;

		public ExtraAttendencyRepository(IContext context)
		{
			_context = context;
		}

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
