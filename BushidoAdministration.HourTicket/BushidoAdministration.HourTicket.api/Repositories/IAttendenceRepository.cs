using BushidoAdministration.HourTicket.api.Entities;

namespace BushidoAdministration.HourTicket.api.Repositories
{
	public interface IAttendenceRepository
	{
		public Task<Attendence> Create(Attendence attendence);

		/// <summary>
		/// Get single attendence from its id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Task<Attendence> Get(int id);

		/// <summary>
		/// Get all attendences based on the user and the activity
		/// </summary>
		/// <param name="userId"></param>
		/// <param name="acitivityId"></param>
		/// <returns></returns>
		public Task<IEnumerable<Attendence>> Get(int userId, int activityId);

		/// <summary>
		/// Get all attendences of a user
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		public Task<IEnumerable<Attendence>> GetFromUser(int userId);

		/// <summary>
		/// Get all attendences based on the activity
		/// </summary>
		/// <param name="activityId"></param>
		/// <returns></returns>
		public Task<IEnumerable<Attendence>> GetFromActivity(int activityId);

		/// <summary>
		/// Update one attendence
		/// </summary>
		/// <param name="attendence"></param>
		/// <returns></returns>
		public Task<bool> Update(Attendence attendence);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Task<bool> Delete(int id);
	}
}
