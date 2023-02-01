using BushidoAdministration.HourTicket.api.Models;
using BushidoAdministration.HourTicket.api.Services;
using Microsoft.AspNetCore.Mvc;

namespace BushidoAdministration.HourTicket.api.Controllers
{
	[ApiController]
	[Route("api/user")]
	public class UserController : ControllerBase
	{
		private readonly ILogger<UserController> _logger;
		private readonly IUserService _userService;

		public UserController(ILogger<UserController> logger, IUserService userService)
		{
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
			_userService = userService ?? throw new ArgumentNullException(nameof(userService));
		}

		[HttpGet("login")]
		public async Task<ActionResult<UserDto>> Login(string username, string password)
		{
			try
			{
				_logger.LogInformation($"Tentativo di accedere all'account con username {username}: inizio.");

				if (username == null || password == null)
				{
					string message = string.Empty;
					if (username == null) message += "Non è stata inserito nessun username.\n";
					if (password == null) message += "Non è stata inserita nessuna password";

					return BadRequest(message);
				}

				var userLogged = username.Contains('@')
					? await _userService.LoginFromEmail(username, password)
					: await _userService.LoginFromUsername(username, password);

				if (userLogged == null)
				{
					return NotFound();
				}

				_logger.LogInformation($"Tentativo di accedere all'account con username {username}: avvenuto con successo");
				return Ok(userLogged);
			}
			catch (Exception ex)
			{
				string errorMessage = $"Tentativo di accedere all'account con username {username}: fallito\nMessaggio di errore: " +
					ex.Message;
				_logger.LogError(errorMessage);

				return StatusCode(500);
			}
		}
	}
}
