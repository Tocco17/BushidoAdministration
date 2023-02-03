using BushidoAdministration.HourTicket.api.Contexts;
using BushidoAdministration.HourTicket.api.Entities;

namespace BushidoAdministration.HourTicket.api.Repositories
{
	public class RegularScheduleRepository : IRegularScheduleRepository
	{
		private readonly IContext _context;

		private readonly string _id = " id as Id ";
		private readonly string _activityId = " activity_id as ActivityId ";
		private readonly string _weekDay = " week_day as WeekDay ";
		private readonly string _startHour = " start_hour as StartHour ";
		private readonly string _endHour = " end_hour as EndHour ";

		public RegularScheduleRepository(IContext context)
		{
			_context = context;
		}

		public Task<bool> Create(RegularSchedule regularSchedule)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Delete(int id)
		{
			throw new NotImplementedException();
		}

		public Task<RegularSchedule> Get(int id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<RegularSchedule>> GetFromActivity(int activityId)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Update(RegularSchedule regularSchedule)
		{
			throw new NotImplementedException();
		}
	}
}
