using BushidoAdministration.HourTicket.api.Contexts;
using BushidoAdministration.HourTicket.api.Entities;

namespace BushidoAdministration.HourTicket.api.Repositories
{
	public class ExtraScheduleRepository : IExtraScheduleRepository
	{
		private readonly IContext _context;

		private readonly string _table = "dbo.extra_schedule";

		private readonly string _id = " id as Id ";
		private readonly string _activityId = " activity_id as ActivityId ";
		private readonly string _date = " date as Date ";
		private readonly string _startHour = " start_hour as StartHour ";
		private readonly string _endHour = " end_hour as EndHour ";

		public ExtraScheduleRepository(IContext context)
		{
			_context = context;
		}

		public async Task<ExtraSchedule> Create(ExtraSchedule extraSchedule)
		{
			var query = $"insert into {_table} (activity_id, date, start_hour, end_hour) " +
				$"values ({extraSchedule.ActivityId}, {extraSchedule.Date}, {extraSchedule.StartHour}, {extraSchedule.EndHour}";
			return await _context.CreateAsync<ExtraSchedule>(query);
		}

		public async Task<bool> Delete(int id)
		{
			var query = $"delete from {_table} where id = {id}";
			return await _context.DeleteAsync(query);
		}

		public async Task<ExtraSchedule> Get(int id)
		{
			var query = $"select top(1) {_id}, {_activityId}, {_date}, {_startHour}, {_endHour} " +
				$"from {_table} " +
				$"where id = {id}";

			return await _context.GetSingleAsync<ExtraSchedule>(query);
		}

		public async Task<IEnumerable<ExtraSchedule>> GetFromActivity(int activityId)
		{
			var query = $"select {_id}, {_activityId}, {_date}, {_startHour}, {_endHour} " +
				$"from {_table} " +
				$"where activity_id = {activityId}";

			return await _context.GetAsync<ExtraSchedule>(query);
		}

		public async Task<bool> Update(ExtraSchedule extraSchedule)
		{
			var query = $"update {_table} set " +
				$"activity_id = {extraSchedule.ActivityId}, " +
				$"date = {extraSchedule.Date}, " +
				$"start_hour = {extraSchedule.StartHour}, " +
				$"end_hour = {extraSchedule.EndHour} " +
				$"where id = {extraSchedule.Id}";

			return await _context.UpdateAsync(query);
		}
	}
}
