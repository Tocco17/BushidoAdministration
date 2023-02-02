using BushidoAdministration.HourTicket.api.Contexts;
using BushidoAdministration.HourTicket.api.Entities;

namespace BushidoAdministration.HourTicket.api.Repositories
{
	public class AttendenceRepository : IAttendenceRepository
	{
		private readonly IContext _context;

		public AttendenceRepository(IContext context)
		{
			_context = context;
		}

		public Task<bool> Create(Attendence attendence)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Delete(int id)
		{
			throw new NotImplementedException();
		}

		public Task<Attendence> Get(int id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Attendence>> Get(int userID, int acitivityId)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Attendence>> GetFromActivity(int activityId)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Attendence>> GetFromUser(int userId)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Update(Attendence attendence)
		{
			throw new NotImplementedException();
		}
	}
}
