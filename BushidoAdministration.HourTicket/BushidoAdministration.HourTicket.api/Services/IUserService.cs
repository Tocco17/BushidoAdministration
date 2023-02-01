using BushidoAdministration.HourTicket.api.Entities;
using BushidoAdministration.HourTicket.api.Enum;
using BushidoAdministration.HourTicket.api.Models;

namespace BushidoAdministration.HourTicket.api.Services
{
	public interface IUserService
	{
		public Task<UserDto> LoginFromEmail(string email, string password);
		public Task<UserDto> LoginFromUsername(string username, string password);
		public Task<UserDto> GetUserFromId(int userId);
		public Task<UserDto> GetUserFromEmail(string email);
		public Task<UserDto> GetUserFromUsername(string username);
		public Task<RoleLevelEnum?> GetRoleLevel(int userId);
		public Task<bool> Update(UserUpdatedDto userUpdated);
		public Task<bool> UpdatePassword(UserUpdatePasswordDto userUpdatePassword);
		public Task<bool> UserExistsFromId(int userId);
		public Task<bool> UserExistsFromIdAndPassword(int userId, string password);
		public Task<bool> UserExistsFromUsername(string username);
		public Task<bool> UserExistsFromEmail(string email);
	}
}
