using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace BushidoAdministration.HourTicket.api.Contexts
{
	public class DbContext : IContext
	{
		private readonly IConfiguration _configuration;
		private readonly string _connectionString;

		public DbContext(IConfiguration configuration)
		{
			_configuration = configuration;
			_connectionString = _configuration.GetConnectionString("SqlConnection");
		}

		#region PRIVATE COMMON METHODS
		private async Task<T> SelectSingle<T>(string query)
		{
			using (var conn = CreateConnection())
			{
				return await conn.QuerySingleOrDefaultAsync<T>(query);
			}
		}

		private async Task<T> SelectSingle<T>(string storedProcedure, DynamicParameters parameters)
		{
			using (var conn = CreateConnection())
			{
				return await conn.QuerySingleOrDefaultAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
			}
		}

		private async Task<IEnumerable<T>> Select<T>(string query)
		{
			using (var conn = CreateConnection())
			{
				return await conn.QueryAsync<T>(query);
			}
		}

		private async Task<IEnumerable<T>> Select<T>(string storedProcedure, DynamicParameters parameters)
		{
			using (var conn = CreateConnection())
			{
				return await conn.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
			}
		}

		private async Task<int> Execute(string query)
		{
			using (var conn = CreateConnection())
			{
				return await conn.ExecuteAsync(query);
			}
		}
		#endregion

		public async Task<T> CreateAsync<T>(string query)
		{
			return await SelectSingle<T>(query);
		}

		public async Task<T> CreateAsync<T>(string storedProcedure, DynamicParameters parameters)
		{
			return await SelectSingle<T>(storedProcedure, parameters);
		}

		public IDbConnection CreateConnection() => new SqlConnection(_connectionString);

		public async Task<IEnumerable<T>> GetAsync<T>(string query)
		{
			return await Select<T>(query);
		}

		public async Task<IEnumerable<T>> GetAsync<T>(string storedProcedure, DynamicParameters parameters)
		{
			return await Select<T>(storedProcedure, parameters);
		}

		public async Task<T> GetSingleAsync<T>(string query)
		{
			return await SelectSingle<T>(query);
		}

		public async Task<T> GetSingleAsync<T>(string storedProcedure, DynamicParameters parameters)
		{
			return await SelectSingle<T>(storedProcedure, parameters);
		}

		public async Task<bool> Update(string query)
		{
			var res = await Execute(query);
			return res > 0;
		}

		public Task<bool> Update(string storedProcedure, DynamicParameters parameters)
		{
			throw new NotImplementedException();
		}
	}
}
