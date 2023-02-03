using BushidoAdministration.HourTicket.api.Contexts;
using BushidoAdministration.HourTicket.api.Entities;

namespace BushidoAdministration.HourTicket.api.Repositories
{
	public class ExtraAttendencyRepository : IExtraAttendencyRepository
	{
		private readonly IContext _context;

		private readonly string _id = " id as Id ";
		private readonly string _attendenceId = " attendence_id as AttendenceId ";
		private readonly string _motivation = " motivation as Motivation ";
		private readonly string _isJustified = " is_justified as IsJustified ";

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
