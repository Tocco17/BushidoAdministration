using System.Runtime.InteropServices;
using BushidoAdministration.HourTicket.api.Contexts;
using BushidoAdministration.HourTicket.api.Entities;

namespace BushidoAdministration.HourTicket.api.Repositories
{
	public class ActivityRepository : IActivityRepository
	{
		private readonly IContext _context;

		private readonly string _id = " id as Id ";
		private readonly string _name = " name as Name ";
		private readonly string _description = " description as Description ";
		private readonly string _isRegular = " is_regular as IsRegular ";
		private readonly string _table = "dbo.activities";

		public ActivityRepository(IContext context)
		{
			_context = context;
		}

		public async Task<Activity> Create(Activity activity)
		{
			var query = $"insert into {_table} (name, description, is_regular) " +
				$"values ({activity.Name}, {activity.Description}, {activity.IsRegular})";
			return await _context.CreateAsync<Activity>(query);
		}

		public async Task<bool> Delete(int id)
		{
			var query = $"delete from {_table} where id = {id}";
			return await _context.DeleteAsync(query);
		}

		public async Task<Activity> Get(int id)
		{
			var query = $"select top(1) {_id}, {_name}, {_description}, {_isRegular} from {_table} where id = {id}";
			return await _context.GetSingleAsync<Activity>(query);
		}

		public async Task<bool> Update(Activity activity)
		{
			var query = $" update {_table} set is_regular = {activity.IsRegular},";
			if (activity.Name != string.Empty) query += $" name = '{activity.Name}',";
			if (activity.Description != string.Empty) query += $" description = '{activity.Description}',";
			query = query.Remove(query.Length - 1); //Per togliere la virgola
			query += $" where id = {activity.Id}";

			return await _context.UpdateAsync(query);
		}
	}
}
