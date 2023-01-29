using BushidoAdministration.HourTicket.api.Contexts;
using BushidoAdministration.HourTicket.api.Entities;

namespace BushidoAdministration.HourTicket.api.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly IContext _context;

		private readonly string _id = "id as Id";
		private readonly string _email = "email as Email";
		private readonly string _username = "username as Username";
		private readonly string _password = "password as Password";
		private readonly string _firstName = "first_name as FirstName";
		private readonly string _lastName = "last_name as LastName";
		private readonly string _roleLevel = "role_level as RoleLevel";

		public UserRepository(IContext context)
		{
			_context = context;
		}

		public async Task<User> LoginFromEmail(string email, string password)
		{
			var query = "select top(1) " +
				$"{_id}, {_email}, {_username}, {_password}, {_firstName}, {_lastName}, {_roleLevel} " +
				"from dbo.users " +
				$"where email = '{email}' and password = '{password}'";

			//var query = "select top(1) * " +
			//	"from dbo.users " +
			//	$"where email = '{email}' and password = '{password}'";

			var user = await _context.GetSingleAsync<User>(query);

			return user;
		}

		public async Task<User> LoginFromUsername(string username, string password)
		{
			var query = "select top(1) " +
				$"{_id}, {_email}, {_username}, {_password}, {_firstName}, {_lastName}, {_roleLevel} " +
				"from dbo.users " +
				$"where email = '{username}' and password = '{password}'";

			var user = await _context.GetSingleAsync<User>(query);

			return user;
		}
	}
}
