using BushidoAdministration.HourTicket.api.Contexts;
using BushidoAdministration.HourTicket.api.Entities;

namespace BushidoAdministration.HourTicket.api.Repositories
{
	public class RegularScheduleRepository : IRegularScheduleRepository
	{
		private readonly IContext _context;

		private readonly string _table = "dbo.regular_schedule";

		private static readonly string _id = " id ";
		private static readonly string _activityId = " activity_id ";
		private static readonly string _weekDay = " week_day ";
		private static readonly string _startHour = " start_hour ";
		private static readonly string _endHour = " end_hour ";

		private static readonly string _idAs = $" {_id} as Id ";
		private static readonly string _activityIdAs = $" {_activityId} as ActivityId ";
		private static readonly string _weekDayAs = $" {_weekDay} as WeekDay ";
		private static readonly string _startHourAs = $" {_startHour} as StartHour ";
		private static readonly string _endHourAs = $" {_endHour} as EndHour ";

		public RegularScheduleRepository(IContext context)
		{
			_context = context;
		}

		public async Task<RegularSchedule> Create(RegularSchedule regularSchedule)
		{
			var query = $"insert into {_table} ({_activityId}, {_weekDay}, {_startHour}, {_endHour}) " +
				$"values ({regularSchedule.ActivityId}, {regularSchedule.WeekDay}, {regularSchedule.StartHour}, {regularSchedule.EndHour}";
			return await _context.CreateAsync<RegularSchedule>(query);
		}

		public async Task<bool> Delete(int id)
		{
			var query = $"delete from {_table} where {_id} = {id}";
			return await _context.DeleteAsync(query);
		}

		public async Task<RegularSchedule> Get(int id)
		{
			var query = $"select top(1) {_idAs}, {_activityIdAs}, {_weekDayAs}, {_startHourAs}, {_endHourAs} " +
				$"from {_table} " +
				$"where {_id} = {id}";

			return await _context.GetSingleAsync<RegularSchedule>(query);
		}

		public async Task<IEnumerable<RegularSchedule>> GetFromActivity(int activityId)
		{
			var query = $"select {_idAs}, {_activityIdAs}, {_weekDayAs}, {_startHourAs}, {_endHourAs} " +
				$"from {_table} " +
				$"where {_activityId} = {activityId}";

			return await _context.GetAsync<RegularSchedule>(query);
		}

		public async Task<bool> Update(RegularSchedule regularSchedule)
		{
			var query = $"update {_table} set " +
				$"{_activityId} = {regularSchedule.ActivityId}, " +
				$"{_weekDay} = {regularSchedule.WeekDay}, " +
				$"{_startHour} = {regularSchedule.StartHour}, " +
				$"{_endHour} = {regularSchedule.EndHour} " +
				$"where {_id} = {regularSchedule.Id}";

			return await _context.UpdateAsync(query);
		}
	}
}
