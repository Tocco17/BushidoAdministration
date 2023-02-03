using BushidoAdministration.HourTicket.api.Contexts;
using BushidoAdministration.HourTicket.api.Entities;

namespace BushidoAdministration.HourTicket.api.Repositories
{
	public class AttendenceRepository : IAttendenceRepository
	{
		private readonly IContext _context;

		private readonly string _id = " id as Id ";
		private readonly string _userId = " user_id as UserId ";
		private readonly string _activityId = " activity_id as ActivityId ";
		private readonly string _day = " day as Day ";
		private readonly string _time = " time as Time ";

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
