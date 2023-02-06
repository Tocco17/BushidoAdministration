using BushidoAdministration.HourTicket.api.Contexts;
using BushidoAdministration.HourTicket.api.Entities;
using Microsoft.VisualBasic;

namespace BushidoAdministration.HourTicket.api.Repositories
{
	public class ExtraAttendanceRepository : IExtraAttendanceRepository
	{
		private readonly IContext _context;

		private readonly string _table = "dbo.extra_attendences";

		private static readonly string _id = " id ";
		private static readonly string _attendanceId = " attendence_id ";
		private static readonly string _motivation = " motivation ";
		private static readonly string _isJustified = " is_justified ";

		private static readonly string _idAs = $" {_id} as Id ";
		private static readonly string _attendanceIdAs = $" {_attendanceId} as AttendanceId ";
		private static readonly string _motivationAs = $" {_motivation} as Motivation ";
		private static readonly string _isJustifiedAs = $" {_isJustified} as IsJustified ";

		public ExtraAttendanceRepository(IContext context)
		{
			_context = context;
		}

		public async Task<bool> ChangeJustified(int id)
		{
			//TODO - Da migliorare la query non mi piace troppo
			var query = $"update {_table} set {_isJustified} = IIF({_isJustified} = 1, 'false', 'true') where {_id} = {id}";
			return await _context.UpdateAsync(query);
		}

		public async Task<ExtraAttendance> Create(ExtraAttendance extraAttendance)
		{
			var query = $"insert into {_table} ({_attendanceId}, {_motivation}, {_isJustified}) " +
				$"values ({extraAttendance.AttendanceId}, '{extraAttendance.Motivation}', {extraAttendance.IsJustified}";

			return await _context.CreateAsync<ExtraAttendance>(query);
		}

		public async Task<bool> Delete(int id)
		{
			var query = $"delete from {_table} where {_id} = {id}";
			return await _context.DeleteAsync(query);
		}

		public async Task<ExtraAttendance> Get(int id)
		{
			var query = $"select top(1) {_idAs}, {_attendanceIdAs}, {_motivationAs}, {_isJustifiedAs} from {_table} where {_id} = {id}";
			return await _context.GetSingleAsync<ExtraAttendance>(query);
		}

		public async Task<ExtraAttendance> GetFromAttendence(int attendanceId)
		{
			var query = $"select top(1) {_idAs}, {_attendanceIdAs}, {_motivationAs}, {_isJustifiedAs} from {_table} where {_attendanceId} = {attendanceId}";
			return await _context.GetSingleAsync<ExtraAttendance>(query);
		}

		public async Task<bool> Update(ExtraAttendance extraAttendance)
		{
			var query = $"update {_table} set " +
				$"{_attendanceId} = {extraAttendance.AttendanceId}, " +
				$"{_motivation} = '{extraAttendance.Motivation}', " +
				$"{_isJustified} = {extraAttendance.IsJustified} " +
				$"where {_id} = {extraAttendance.Id}";
			return await _context.UpdateAsync(query);
		}
	}
}
