using BushidoAdministration.HourTicket.api.Entities;
using BushidoAdministration.HourTicket.api.Enum;
using BushidoAdministration.HourTicket.api.Models;

namespace BushidoAdministration.HourTicket.api.Services
{
	public interface IUserService
	{
		public Task<UserDto> LoginFromEmail(string email, string password);
		public Task<UserDto> LoginFromUsername(string username, string password);
		public Task<UserDto> GetFromId(int userId);
		public Task<UserDto> GetFromEmail(string email);
		public Task<UserDto> GetFromUsername(string username);
		public Task<RoleLevel?> GetRoleLevel(int userId);
		public Task<bool> Update(UserUpdatedDto userUpdated);
		public Task<bool> UpdatePassword(UserUpdatePasswordDto userUpdatePassword);
		public Task<bool> ExistsFromId(int userId);
		public Task<bool> ExistsFromIdAndPassword(int userId, string password);
		public Task<bool> ExistsFromUsername(string username);
		public Task<bool> ExistsFromEmail(string email);
	}
}
