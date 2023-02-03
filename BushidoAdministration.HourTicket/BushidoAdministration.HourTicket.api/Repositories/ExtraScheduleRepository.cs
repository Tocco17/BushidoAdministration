using BushidoAdministration.HourTicket.api.Contexts;
using BushidoAdministration.HourTicket.api.Entities;

namespace BushidoAdministration.HourTicket.api.Repositories
{
	public class ExtraScheduleRepository : IExtraScheduleRepository
	{
		private readonly IContext _context;

		private readonly string _id = " id as Id ";
		private readonly string _activityId = " activity_id as ActivityId ";
		private readonly string _date = " date as Date ";
		private readonly string _startHour = " start_hour as StartHour ";
		private readonly string _endHour = " end_hour as EndHour ";

		public ExtraScheduleRepository(IContext context)
		{
			_context = context;
		}

		public Task<bool> Create(ExtraSchedule extraSchedule)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Delete(int id)
		{
			throw new NotImplementedException();
		}

		public Task<ExtraSchedule> Get(int id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<ExtraSchedule>> GetFromActivity(int activityId)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Update(ExtraSchedule extraSchedule)
		{
			throw new NotImplementedException();
		}
	}
}
