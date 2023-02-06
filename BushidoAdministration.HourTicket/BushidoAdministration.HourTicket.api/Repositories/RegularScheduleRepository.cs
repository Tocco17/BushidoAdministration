using BushidoAdministration.HourTicket.api.Contexts;
using BushidoAdministration.HourTicket.api.Entities;

namespace BushidoAdministration.HourTicket.api.Repositories
{
	public class RegularScheduleRepository : IRegularScheduleRepository
	{
		private readonly IContext _context;

		private readonly string _table = "dbo.regular_schedule";

		private readonly string _id = " id as Id ";
		private readonly string _activityId = " activity_id as ActivityId ";
		private readonly string _weekDay = " week_day as WeekDay ";
		private readonly string _startHour = " start_hour as StartHour ";
		private readonly string _endHour = " end_hour as EndHour ";

		public RegularScheduleRepository(IContext context)
		{
			_context = context;
		}

		public async Task<RegularSchedule> Create(RegularSchedule regularSchedule)
		{
			var query = $"insert into {_table} (activity_id, week_day, start_hour, end_hour) " +
				$"values ({regularSchedule.ActivityId}, {regularSchedule.WeekDay}, {regularSchedule.StartHour}, {regularSchedule.EndHour}";
			return await _context.CreateAsync<RegularSchedule>(query);
		}

		public async Task<bool> Delete(int id)
		{
			var query = $"delete from {_table} where id = {id}";
			return await _context.DeleteAsync(query);
		}

		public async Task<RegularSchedule> Get(int id)
		{
			var query = $"select top(1) {_id}, {_activityId}, {_weekDay}, {_startHour}, {_endHour} " +
				$"from {_table} " +
				$"where id = {id}";

			return await _context.GetSingleAsync<RegularSchedule>(query);
		}

		public async Task<IEnumerable<RegularSchedule>> GetFromActivity(int activityId)
		{
			var query = $"select {_id}, {_activityId}, {_weekDay}, {_startHour}, {_endHour} " +
				$"from {_table} " +
				$"where activity_id = {activityId}";

			return await _context.GetAsync<RegularSchedule>(query);
		}

		public async Task<bool> Update(RegularSchedule regularSchedule)
		{
			var query = $"update {_table} set " +
				$"activity_id = {regularSchedule.ActivityId}, " +
				$"week_day = {regularSchedule.WeekDay}, " +
				$"start_hour = {regularSchedule.StartHour}, " +
				$"end_hour = {regularSchedule.EndHour} " +
				$"where id = {regularSchedule.Id}";

			return await _context.UpdateAsync(query);
		}
	}
}
