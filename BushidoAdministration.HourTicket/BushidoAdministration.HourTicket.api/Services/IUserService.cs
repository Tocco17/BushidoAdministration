using BushidoAdministration.HourTicket.api.Models;

namespace BushidoAdministration.HourTicket.api.Services
{
	public interface IUserService
	{
		public Task<UserLoggedDto> LoginFromEmail(string email, string password);
		public Task<UserLoggedDto> LoginFromUsername(string username, string password);
		//public Task<int> RoleLevel
	}
}
