using System.Net.WebSockets;
using BushidoAdministration.HourTicket.api.Contexts;
using BushidoAdministration.HourTicket.api.Entities;
using BushidoAdministration.HourTicket.api.Enum;

namespace BushidoAdministration.HourTicket.api.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly IContext _context;

		private readonly string _id = " id as Id ";
		private readonly string _email = " email as Email ";
		private readonly string _username = " username as Username ";
		private readonly string _password = " password as Password ";
		private readonly string _firstName = " first_name as FirstName ";
		private readonly string _lastName = " last_name as LastName ";
		private readonly string _roleLevel = " role_level as RoleLevel ";

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

			var user = await _context.GetSingleAsync<User>(query);

			return user;
		}

		public async Task<User> LoginFromUsername(string username, string password)
		{
			var query = "select top(1) " +
				$"{_id}, {_email}, {_username}, {_password}, {_firstName}, {_lastName}, {_roleLevel} " +
				"from dbo.users " +
				$"where username = '{username}' and password = '{password}'";

			var user = await _context.GetSingleAsync<User>(query);

			return user;
		}

		public async Task<RoleLevel?> GetRoleLevel(int userId)
		{
			var query = $"select top(1) {_roleLevel} from dbo.users where id = {userId}";
			return await _context.GetSingleAsync<RoleLevel?>(query);
		}

		public async Task<User> GetUserFromId(int userId)
		{
			var query = $"select top(1) " +
				$"{_id}, {_email}, {_username}, {_password}, {_firstName}, {_lastName}, {_roleLevel} " +
				$"from dbo.users where id = {userId}";
			var user = await _context.GetSingleAsync<User>(query);
			return user;
		}

		public async Task<User> GetUserFromEmail(string email)
		{
			var query = $"select top(1) " +
				$"{_id}, {_email}, {_username}, {_password}, {_firstName}, {_lastName}, {_roleLevel} " +
				$"from dbo.users where email = '{email}'";
			var user = await _context.GetSingleAsync<User>(query);
			return user;
		}

		public async Task<User> GetUserFromUsername(string username)
		{
			var query = $"select top(1) " +
				$"{_id}, {_email}, {_username}, {_password}, {_firstName}, {_lastName}, {_roleLevel} " +
				$"from dbo.users where username = '{username}'";
			var user = await _context.GetSingleAsync<User>(query);
			return user;
		}

		public async Task<bool> Update(User userUpdated)
		{
			var query = " update dbo.users set";
			if (userUpdated.Username != string.Empty) query += $" username = '{userUpdated.Username}',";
			if (userUpdated.Email != string.Empty) query += $" email = '{userUpdated.Email}',";
			if (userUpdated.FirstName != string.Empty) query += $" first_name = '{userUpdated.FirstName}',";
			if (userUpdated.LastName != string.Empty) query += $" last_name = '{userUpdated.LastName}',";
			query = query.Remove(query.Length - 1); //Per togliere la virgola
			query += $" where id = {userUpdated.Id}";

			return await _context.Update(query);
		}

		public async Task<bool> UpdatePassword(int userId, string oldPassword, string newPassword)
		{
			var query = $"update dbo.users set password = '{newPassword}' where id = {userId} and password = '{oldPassword}'";
			return await _context.Update(query);
		}

		public async Task<bool> UserExistsFromId(int userId)
		{
			var user = await GetUserFromId(userId);
			return user != null;
		}

		public async Task<bool> UserExistsFromUsername(string username)
		{
			var user = await GetUserFromUsername(username);
			return user != null;
		}

		public async Task<bool> UserExistsFromEmail(string email)
		{
			var user = await GetUserFromEmail(email);
			return user != null;
		}

		public async Task<bool> UserExistsFromIdAndPassword(int userId, string password)
		{
			var user = await GetUserFromId(userId);
			return user.Password == password;
		}
	}
}
