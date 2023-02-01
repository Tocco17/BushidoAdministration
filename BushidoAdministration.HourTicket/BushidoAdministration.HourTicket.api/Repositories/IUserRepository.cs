using BushidoAdministration.HourTicket.api.Entities;
using BushidoAdministration.HourTicket.api.Enum;

namespace BushidoAdministration.HourTicket.api.Repositories
{
	public interface IUserRepository
	{
		public Task<User> LoginFromEmail(string email, string password);
		public Task<User> LoginFromUsername(string username, string password);
		public Task<User> GetUserFromId(int userId);
		public Task<User> GetUserFromEmail(string email);
		public Task<User> GetUserFromUsername(string username);
		public Task<RoleLevelEnum?> GetRoleLevel(int userId);
		public Task<bool> Update(User userUpdated);
		public Task<bool> UpdatePassword(int userId, string oldPassword, string newPassword);
		public Task<bool> UserExistsFromId(int userId);
		public Task<bool> UserExistsFromIdAndPassword(int userId, string password);
		public Task<bool> UserExistsFromUsername(string username);
		public Task<bool> UserExistsFromEmail(string email);
	}
}
