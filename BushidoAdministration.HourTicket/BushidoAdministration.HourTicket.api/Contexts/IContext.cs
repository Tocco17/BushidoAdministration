﻿using Dapper;
using System.Data;

namespace BushidoAdministration.HourTicket.api.Contexts
{
	public interface IContext
	{
		public Task<T> CreateAsync<T>(string query);
		public Task<T> CreateAsync<T>(string storedProcedure, DynamicParameters parameters);
		public IDbConnection CreateConnection();
		public Task<IEnumerable<T>> GetAsync<T>(string query);
		public Task<IEnumerable<T>> GetAsync<T>(string storedProcedure, DynamicParameters parameters);
		public Task<T> GetSingleAsync<T>(string query);
		public Task<T> GetSingleAsync<T>(string storedProcedure, DynamicParameters parameters);
		public Task<bool> UpdateAsync(string query);
		public Task<bool> UpdateAsync(string storedProcedure, DynamicParameters parameters);
		public Task<bool> DeleteAsync(string query);
		public Task<bool> DeleteAsync(string storedProcedure, DynamicParameters parameters);

	}
}
