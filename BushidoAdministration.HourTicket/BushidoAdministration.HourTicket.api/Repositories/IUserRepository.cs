using BushidoAdministration.HourTicket.api.Entities;
using BushidoAdministration.HourTicket.api.Enum;

namespace BushidoAdministration.HourTicket.api.Repositories
{
	public interface IUserRepository
	{
		public Task<User> LoginFromEmail(string email, string password);
		public Task<User> LoginFromUsername(string username, string password);
		public Task<User> GetFromId(int userId);
		public Task<User> GetFromEmail(string email);
		public Task<User> GetFromUsername(string username);
		public Task<RoleLevel?> GetRoleLevel(int userId);
		public Task<bool> Update(User userUpdated);
		public Task<bool> UpdatePassword(int userId, string oldPassword, string newPassword);
		public Task<bool> ExistsFromId(int userId);
		public Task<bool> ExistsFromIdAndPassword(int userId, string password);
		public Task<bool> ExistsFromUsername(string username);
		public Task<bool> ExistsFromEmail(string email);
	}
}
