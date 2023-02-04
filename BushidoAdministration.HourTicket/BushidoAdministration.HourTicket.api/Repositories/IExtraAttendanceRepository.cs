using BushidoAdministration.HourTicket.api.Entities;

namespace BushidoAdministration.HourTicket.api.Repositories
{
	public interface IExtraAttendanceRepository
	{
		public Task<ExtraAttendance> Create(ExtraAttendance extraAttendance);
		public Task<ExtraAttendance> Get(int id);
		public Task<ExtraAttendance> GetFromAttendence(int attendanceId);
		public Task<bool> Update(ExtraAttendance extraAttendance);
		public Task<bool> ChangeJustified(int id);
		public Task<bool> Delete(int id);
	}
}
