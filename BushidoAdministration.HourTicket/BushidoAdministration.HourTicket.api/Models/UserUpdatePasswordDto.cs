using System.ComponentModel.DataAnnotations;

namespace BushidoAdministration.HourTicket.api.Models
{
	public class UserUpdatePasswordDto
	{
		[Required]
		public int Id { get; set; }

		[Required]
		public string OldPassword { get; set; } = string.Empty;

		[Required]
		public string NewPassword { get; set; } = string.Empty;
	}
}
