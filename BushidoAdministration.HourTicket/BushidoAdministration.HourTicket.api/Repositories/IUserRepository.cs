using BushidoAdministration.HourTicket.api.Entities;

namespace BushidoAdministration.HourTicket.api.Repositories
{
	public interface IUserRepository
	{
		public Task<User> LoginFromEmail(string email, string password);
		public Task<User> LoginFromUsername(string username, string password);
	}
}
