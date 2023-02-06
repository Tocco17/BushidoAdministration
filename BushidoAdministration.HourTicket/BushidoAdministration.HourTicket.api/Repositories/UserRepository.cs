using System.Net.WebSockets;
using BushidoAdministration.HourTicket.api.Contexts;
using BushidoAdministration.HourTicket.api.Entities;
using BushidoAdministration.HourTicket.api.Enum;

namespace BushidoAdministration.HourTicket.api.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly IContext _context;

		private readonly string _table = "dbo.users";

		private static readonly string _id = " id ";
		private static readonly string _email = " email ";
		private static readonly string _username = " username ";
		private static readonly string _password = " password ";
		private static readonly string _firstName = " first_name ";
		private static readonly string _lastName = " last_name ";
		private static readonly string _roleLevel = " role_level ";

		private static readonly string _idAs = $" {_id} as Id ";
		private static readonly string _emailAs = $" {_email} as Email ";
		private static readonly string _usernameAs = $" {_username} as Username ";
		private static readonly string _passwordAs = $" {_password} as Password ";
		private static readonly string _firstNameAs = $" {_firstName} as FirstName ";
		private static readonly string _lastNameAs = $" {_lastName} as LastName ";
		private static readonly string _roleLevelAs = $" {_roleLevel} as RoleLevel ";

		public UserRepository(IContext context)
		{
			_context = context;
		}

		public async Task<User> LoginFromEmail(string email, string password)
		{
			var query = "select top(1) " +
				$"{_idAs}, {_emailAs}, {_usernameAs}, {_passwordAs}, {_firstNameAs}, {_lastNameAs}, {_roleLevelAs} " +
				$"from {_table} " +
				$"where {_email} = '{email}' and {_password} = '{password}'";

			var user = await _context.GetSingleAsync<User>(query);

			return user;
		}

		public async Task<User> LoginFromUsername(string username, string password)
		{
			var query = "select top(1) " +
				$"{_idAs}, {_emailAs}, {_usernameAs}, {_passwordAs}, {_firstNameAs}, {_lastNameAs}, {_roleLevelAs} " +
				$"from {_table} " +
				$"where {_username} = '{username}' and {_password} = '{password}'";

			var user = await _context.GetSingleAsync<User>(query);

			return user;
		}

		public async Task<RoleLevel?> GetRoleLevel(int userId)
		{
			var query = $"select top(1) {_roleLevelAs} from {_table} where {_id} = {userId}";
			return await _context.GetSingleAsync<RoleLevel?>(query);
		}

		public async Task<User> GetFromId(int userId)
		{
			var query = $"select top(1) " +
				$"{_idAs}, {_emailAs}, {_usernameAs}, {_passwordAs}, {_firstNameAs}, {_lastNameAs}, {_roleLevelAs} " +
				$"from {_table} where {_id} = {userId}";
			var user = await _context.GetSingleAsync<User>(query);
			return user;
		}

		public async Task<User> GetFromEmail(string email)
		{
			var query = $"select top(1) " +
				$"{_idAs}, {_emailAs}, {_usernameAs}, {_passwordAs}, {_firstNameAs}, {_lastNameAs}, {_roleLevelAs} " +
				$"from {_table} where {_email} = '{email}'";
			var user = await _context.GetSingleAsync<User>(query);
			return user;
		}

		public async Task<User> GetFromUsername(string username)
		{
			var query = $"select top(1) " +
				$"{_idAs}, {_emailAs}, {_usernameAs}, {_passwordAs}, {_firstNameAs}, {_lastNameAs}, {_roleLevelAs} " +
				$"from {_table} where {_username} = '{username}'";
			var user = await _context.GetSingleAsync<User>(query);
			return user;
		}

		public async Task<bool> Update(User userUpdated)
		{
			var query = $" update {_table} set";
			if (userUpdated.Username != string.Empty) query += $" {_username} = '{userUpdated.Username}',";
			if (userUpdated.Email != string.Empty) query += $" {_email} = '{userUpdated.Email}',";
			if (userUpdated.FirstName != string.Empty) query += $" {_firstName} = '{userUpdated.FirstName}',";
			if (userUpdated.LastName != string.Empty) query += $" {_lastName} = '{userUpdated.LastName}',";
			query = query.Remove(query.Length - 1); //Per togliere la virgola
			query += $" where {_id} = {userUpdated.Id}";

			return await _context.UpdateAsync(query);
		}

		public async Task<bool> UpdatePassword(int userId, string oldPassword, string newPassword)
		{
			var query = $"update {_table} set {_password} = '{newPassword}' where {_id} = {userId} and {_password} = '{oldPassword}'";
			return await _context.UpdateAsync(query);
		}

		public async Task<bool> ExistsFromId(int userId)
		{
			var user = await GetFromId(userId);
			return user != null;
		}

		public async Task<bool> ExistsFromUsername(string username)
		{
			var user = await GetFromUsername(username);
			return user != null;
		}

		public async Task<bool> ExistsFromEmail(string email)
		{
			var user = await GetFromEmail(email);
			return user != null;
		}

		public async Task<bool> ExistsFromIdAndPassword(int userId, string password)
		{
			var user = await GetFromId(userId);
			return user.Password == password;
		}
	}
}
