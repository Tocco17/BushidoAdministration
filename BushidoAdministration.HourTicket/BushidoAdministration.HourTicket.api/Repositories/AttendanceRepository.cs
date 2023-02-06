using BushidoAdministration.HourTicket.api.Contexts;
using BushidoAdministration.HourTicket.api.Entities;

namespace BushidoAdministration.HourTicket.api.Repositories
{
	public class AttendanceRepository : IAttendanceRepository
	{
		private readonly IContext _context;

		private readonly string _table = "dbo.attendences";

		private static readonly string _id = " id ";
		private static readonly string _userId = " user_id ";
		private static readonly string _activityId = " activity_id ";
		private static readonly string _day = " day ";
		private static readonly string _time = " time ";

		private static readonly string _idAs = $" {_id} as Id ";
		private static readonly string _userIdAs = $" {_userId} as UserId ";
		private static readonly string _activityIdAs = $" {_activityId} as ActivityId ";
		private static readonly string _dayAs = $" {_day} as Day ";
		private static readonly string _timeAs = $" {_time} as Time ";

		public AttendanceRepository(IContext context)
		{
			_context = context;
		}

		public async Task<Attendance> Create(Attendance attendence)
		{
			var query = $"insert into {_table} ({_userId}, {_activityId}, {_day}, {_time}) " +
				$"values ({attendence.UserId}, {attendence.ActivityId}, {attendence.Day}, {attendence.Time})";
			return await _context.CreateAsync<Attendance>(query);
		}

		public async Task<bool> Delete(int id)
		{
			var query = $"delete from {_table} where {_id} = {id}";
			return await _context.DeleteAsync(query);
		}

		public async Task<Attendance> Get(int id)
		{
			var query = $"select top(1) {_idAs}, {_userIdAs}, {_activityIdAs}, {_dayAs}, {_timeAs} from {_table} where {_id} = {id}";
			return await _context.GetSingleAsync<Attendance>(query);
		}

		public async Task<IEnumerable<Attendance>> Get(int userId, int activityId)
		{
			var query = $"select {_idAs}, {_userIdAs}, {_activityIdAs}, {_dayAs}, {_timeAs} from {_table} where {_userId} = {userId} and {_activityId} = {activityId}";
			return await _context.GetAsync<Attendance>(query);
		}

		public async Task<IEnumerable<Attendance>> GetFromActivity(int activityId)
		{
			var query = $"select {_idAs}, {_userIdAs}, {_activityIdAs}, {_dayAs}, {_timeAs} from {_table} where {_activityId} = {activityId}";
			return await _context.GetAsync<Attendance>(query);
		}

		public async Task<IEnumerable<Attendance>> GetFromUser(int userId)
		{
			var query = $"select {_idAs}, {_userIdAs}, {_activityIdAs}, {_dayAs}, {_timeAs} from {_table} where {_userId} = {userId}";
			return await _context.GetAsync<Attendance>(query);
		}

		public async Task<bool> Update(Attendance attendence)
		{
			var query = $"update {_table} set "
				+ $" {_userId} = {attendence.UserId},"
				+ $" {_activityId}{_activityId} = {attendence.ActivityId},"
				+ $" {_day} = {attendence.Day},"
				+ $" {_time} = {attendence.Time}"
				+ $" where {_id} = {attendence.Id}";
			return await _context.UpdateAsync(query);
		}
	}
}
