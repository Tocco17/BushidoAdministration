using System.Runtime.InteropServices;
using BushidoAdministration.HourTicket.api.Contexts;
using BushidoAdministration.HourTicket.api.Entities;

namespace BushidoAdministration.HourTicket.api.Repositories
{
	public class ActivityRepository : IActivityRepository
	{
		private readonly IContext _context;

		private readonly string _table = "dbo.activities";

		private static readonly string _id = " id ";
		private static readonly string _name = " name ";
		private static readonly string _description = " description ";
		private static readonly string _isRegular = " is_regular ";

		private static readonly string _idAs = $" {_id} as Id ";
		private static readonly string _nameAs = $" {_name} as Name ";
		private static readonly string _descriptionAs = $" {_description} as Description ";
		private static readonly string _isRegularAs = $" {_isRegular} as IsRegular ";

		public ActivityRepository(IContext context)
		{
			_context = context;
		}

		public async Task<Activity> Create(Activity activity)
		{
			var query = $"insert into {_table} ({_name}, {_description}, {_isRegular}) " +
				$"values ('{activity.Name}', '{activity.Description}', {activity.IsRegular})";
			return await _context.CreateAsync<Activity>(query);
		}

		public async Task<bool> Delete(int id)
		{
			var query = $"delete from {_table} where {_id} = {id}";
			return await _context.DeleteAsync(query);
		}

		public async Task<Activity> Get(int id)
		{
			var query = $"select top(1) {_idAs}, {_nameAs}, {_descriptionAs}, {_isRegularAs} from {_table} where {_id} = {id}";
			return await _context.GetSingleAsync<Activity>(query);
		}

		public async Task<bool> Update(Activity activity)
		{
			var query = $" update {_table} set {_isRegular} = {activity.IsRegular},";
			if (activity.Name != string.Empty) query += $" {_name} = '{activity.Name}',";
			if (activity.Description != string.Empty) query += $" {_description} = '{activity.Description}',";
			query = query.Remove(query.Length - 1); //Per togliere la virgola
			query += $" where {_id} = {activity.Id}";

			return await _context.UpdateAsync(query);
		}
	}
}
