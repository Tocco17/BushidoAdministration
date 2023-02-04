using BushidoAdministration.HourTicket.api.Contexts;
using BushidoAdministration.HourTicket.api.Entities;

namespace BushidoAdministration.HourTicket.api.Repositories
{
	public class AttendanceRepository : IAttendanceRepository
	{
		private readonly IContext _context;

		private readonly string _table = "dbo.attendences";

		private readonly string _id = " id as Id ";
		private readonly string _userId = " user_id as UserId ";
		private readonly string _activityId = " activity_id as ActivityId ";
		private readonly string _day = " day as Day ";
		private readonly string _time = " time as Time ";

		public AttendanceRepository(IContext context)
		{
			_context = context;
		}

		public async Task<Attendance> Create(Attendance attendence)
		{
			var query = $"insert into {_table} (user_id, activity_id, day, time) " +
				$"values ({attendence.UserId}, {attendence.ActivityId}, {attendence.Day}, {attendence.Time})";
			return await _context.CreateAsync<Attendance>(query);
		}

		public async Task<bool> Delete(int id)
		{
			var query = $"delete from {_table} where id = {id}";
			return await _context.DeleteAsync(query);
		}

		public async Task<Attendance> Get(int id)
		{
			var query = $"select top(1) {_id}, {_userId}, {_activityId}, {_day}, {_time} from {_table} where id = {id}";
			return await _context.GetSingleAsync<Attendance>(query);
		}

		public async Task<IEnumerable<Attendance>> Get(int userId, int activityId)
		{
			var query = $"select {_id}, {_userId}, {_activityId}, {_day}, {_time} from {_table} where user_id = {userId} and activity_id = {activityId}";
			return await _context.GetAsync<Attendance>(query);
		}

		public async Task<IEnumerable<Attendance>> GetFromActivity(int activityId)
		{
			var query = $"select {_id}, {_userId}, {_activityId}, {_day}, {_time} from {_table} where activity_id = {activityId}";
			return await _context.GetAsync<Attendance>(query);
		}

		public async Task<IEnumerable<Attendance>> GetFromUser(int userId)
		{
			var query = $"select {_id}, {_userId}, {_activityId}, {_day}, {_time} from {_table} where user_id = {userId}";
			return await _context.GetAsync<Attendance>(query);
		}

		public async Task<bool> Update(Attendance attendence)
		{
			var query = $"update {_table} set "
				+ $" user_id = {attendence.UserId},"
				+ $" activity_id = {attendence.ActivityId},"
				+ $" day = {attendence.Day},"
				+ $" time = {attendence.Time}"
				+ $" where id = {attendence.Id}";
			return await _context.UpdateAsync(query);
		}
	}
}
