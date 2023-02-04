using BushidoAdministration.HourTicket.api.Entities;

namespace BushidoAdministration.HourTicket.api.Repositories
{
	public interface IAttendanceRepository
	{
		public Task<Attendance> Create(Attendance attendence);

		/// <summary>
		/// Get single attendence from its id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Task<Attendance> Get(int id);

		/// <summary>
		/// Get all attendences based on the user and the activity
		/// </summary>
		/// <param name="userId"></param>
		/// <param name="acitivityId"></param>
		/// <returns></returns>
		public Task<IEnumerable<Attendance>> Get(int userId, int activityId);

		/// <summary>
		/// Get all attendences of a user
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		public Task<IEnumerable<Attendance>> GetFromUser(int userId);

		/// <summary>
		/// Get all attendences based on the activity
		/// </summary>
		/// <param name="activityId"></param>
		/// <returns></returns>
		public Task<IEnumerable<Attendance>> GetFromActivity(int activityId);

		/// <summary>
		/// Update one attendence
		/// </summary>
		/// <param name="attendence"></param>
		/// <returns></returns>
		public Task<bool> Update(Attendance attendence);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Task<bool> Delete(int id);
	}
}
