using BushidoAdministration.HourTicket.api.Contexts;
using BushidoAdministration.HourTicket.api.Entities;

namespace BushidoAdministration.HourTicket.api.Repositories
{
	public class ExtraScheduleRepository : IExtraScheduleRepository
	{
		private readonly IContext _context;

		private readonly string _table = "dbo.extra_schedule";

		private static readonly string _id = " id ";
		private static readonly string _activityId = " activity_id ";
		private static readonly string _date = " date ";
		private static readonly string _startHour = " start_hour ";
		private static readonly string _endHour = " end_hour ";

		private static readonly string _idAs = $" {_id} as Id ";
		private static readonly string _activityIdAs = $" {_activityId} as ActivityId ";
		private static readonly string _dateAs = $" {_date} as Date ";
		private static readonly string _startHourAs = $" {_startHour} as StartHour ";
		private static readonly string _endHourAs = $" {_endHour} as EndHour ";

		public ExtraScheduleRepository(IContext context)
		{
			_context = context;
		}

		public async Task<ExtraSchedule> Create(ExtraSchedule extraSchedule)
		{
			var query = $"insert into {_table} ({_activityId}, {_date}, {_startHour}, {_endHour}) " +
				$"values ({extraSchedule.ActivityId}, {extraSchedule.Date}, {extraSchedule.StartHour}, {extraSchedule.EndHour}";
			return await _context.CreateAsync<ExtraSchedule>(query);
		}

		public async Task<bool> Delete(int id)
		{
			var query = $"delete from {_table} where {_id} = {id}";
			return await _context.DeleteAsync(query);
		}

		public async Task<ExtraSchedule> Get(int id)
		{
			var query = $"select top(1) {_idAs}, {_activityIdAs}, {_dateAs}, {_startHourAs}, {_endHourAs} " +
				$"from {_table} " +
				$"where {_id} = {id}";

			return await _context.GetSingleAsync<ExtraSchedule>(query);
		}

		public async Task<IEnumerable<ExtraSchedule>> GetFromActivity(int activityId)
		{
			var query = $"select {_idAs}, {_activityIdAs}, {_dateAs}, {_startHourAs}, {_endHourAs} " +
				$"from {_table} " +
				$"where {_activityId} = {activityId}";

			return await _context.GetAsync<ExtraSchedule>(query);
		}

		public async Task<bool> Update(ExtraSchedule extraSchedule)
		{
			var query = $"update {_table} set " +
				$"{_activityId} = {extraSchedule.ActivityId}, " +
				$"{_date} = {extraSchedule.Date}, " +
				$"{_startHour} = {extraSchedule.StartHour}, " +
				$"{_endHour} = {extraSchedule.EndHour} " +
				$"where {_id} = {extraSchedule.Id}";

			return await _context.UpdateAsync(query);
		}
	}
}
