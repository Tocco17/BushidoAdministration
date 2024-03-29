﻿using BushidoAdministration.HourTicket.api.Enum;

namespace BushidoAdministration.HourTicket.api.Models
{
	public class UserDto
	{
		public int Id { get; set; }
		public string Username { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public RoleLevel RoleLevel { get; set; }
	}
}
