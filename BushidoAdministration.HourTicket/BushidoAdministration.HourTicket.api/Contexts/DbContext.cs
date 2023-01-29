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

	//	private T ConvertSingle<T>(dynamic result)
	//	{
	//		T converted;

	//		var type = typeof(T);
	//		var properties = type.GetProperties();
	//		foreach(var property in properties)
	//		{
	//			var columnAttribute = property
	//				.GetCustomAttributes(false)
	//				.OfType<ColumnAttribute>()
	//				.FirstOrDefault();

	//			var name = columnAttribute?.Name;

	//			//converted[name]
	//		}
	//		Dapper.SqlMapper.SetTypeMap(
	//typeof(T),
	//new CustomPropertyTypeMap(
	//	typeof(T),
	//	(type, columnName) =>
	//		type.GetProperties().FirstOrDefault(prop =>
	//			prop.GetCustomAttributes(false)
	//				.OfType<ColumnAttribute>()
	//				.Any(attr => attr.Name == columnName))));

	//		return converted;
	//	}

		private async Task<T> SelectSingle<T>(string query)
		{
			using (var conn = CreateConnection())
			{
				return await conn.QuerySingleOrDefaultAsync(query);
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
	}
}
