using BushidoAdministration.HourTicket.api.Contexts;
using BushidoAdministration.HourTicket.api.Entities;
using Microsoft.VisualBasic;

namespace BushidoAdministration.HourTicket.api.Repositories
{
	public class ExtraAttendanceRepository : IExtraAttendanceRepository
	{
		private readonly IContext _context;

		private readonly string _table = "dbo.extra_attendences";

		private readonly string _id = " id as Id ";
		private readonly string _attendanceId = " attendence_id as AttendanceId ";
		private readonly string _motivation = " motivation as Motivation ";
		private readonly string _isJustified = " is_justified as IsJustified ";

		public ExtraAttendanceRepository(IContext context)
		{
			_context = context;
		}

		public async Task<bool> ChangeJustified(int id)
		{
			//TODO - Da migliorare la query non mi piace troppo
			var query = $"update {_table} set is_justified = IIF(is_justified = 1, 'false', 'true') where id = {id}";
			return await _context.UpdateAsync(query);
		}

		public async Task<ExtraAttendance> Create(ExtraAttendance extraAttendance)
		{
			var query = $"insert into {_table} (attendence_id, motivation, is_justified) " +
				$"values ({extraAttendance.AttendanceId}, {extraAttendance.Motivation}, {extraAttendance.IsJustified}";

			return await _context.CreateAsync<ExtraAttendance>(query);
		}

		public async Task<bool> Delete(int id)
		{
			var query = $"delete from {_table} where id = {id}";
			return await _context.DeleteAsync(query);
		}

		public async Task<ExtraAttendance> Get(int id)
		{
			var query = $"select top(1) {_id}, {_attendanceId}, {_motivation}, {_isJustified} from {_table} where id = {id}";
			return await _context.GetSingleAsync<ExtraAttendance>(query);
		}

		public async Task<ExtraAttendance> GetFromAttendence(int attendanceId)
		{
			var query = $"select top(1) {_id}, {_attendanceId}, {_motivation}, {_isJustified} from {_table} where attendence_id = {attendanceId}";
			return await _context.GetSingleAsync<ExtraAttendance>(query);
		}

		public async Task<bool> Update(ExtraAttendance extraAttendance)
		{
			var query = $"update {_table} set " +
				$"attendence_id = {extraAttendance.AttendanceId}, " +
				$"motivation = {extraAttendance.Motivation}, " +
				$"is_justified = {extraAttendance.IsJustified} " +
				$"where id = {extraAttendance.Id}";
			return await _context.UpdateAsync(query);
		}
	}
}
