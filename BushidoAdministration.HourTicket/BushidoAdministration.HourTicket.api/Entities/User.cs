using System.ComponentModel.DataAnnotations.Schema;

namespace BushidoAdministration.HourTicket.api.Entities
{
	public class User
	{
		[Column(name:"id")]
		public int Id { get; set; }

		[Column(name: "username")]
		public string Username { get; set; } = string.Empty;

		[Column(name: "email")]
		public string Email { get; set; } = string.Empty;

		[Column(name: "password")]
		public string Password { get; set; } = string.Empty;

		[Column(name: "first_name")]
		public string FirstName { get; set; } = string.Empty;

		[Column(name: "last_name")]
		public string LastName { get; set; } = string.Empty;

		[Column(name: "role_level")]
		public int RoleLevel { get; set; }
	}
}
