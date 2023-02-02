using System.ComponentModel.DataAnnotations;
using BushidoAdministration.HourTicket.api.Entities;
using BushidoAdministration.HourTicket.api.Enum;
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

		[HttpGet("rolelevel")]
		public async Task<ActionResult<RoleLevel?>> GetRoleLevel(int userId)
		{
			try
			{
				_logger.LogInformation($"Tentativo di vedere ruolo dell'account con id {userId}: inizio.");

				var roleLevel = await _userService.GetRoleLevel(userId);

				if (roleLevel == null)
				{
					_logger.LogInformation($"Tentativo di vedere ruolo dell'account con id {userId}: livello del ruolo non trovato.");
					return NotFound();
				}

				_logger.LogInformation($"Tentativo di vedere ruolo dell'account con id {userId}: avvenuto con successo.");
				return Ok(roleLevel);
			}
			catch (Exception ex)
			{
				string errorMessage = $"Tentativo di vedere ruolo dell'account con id {userId}: fallito\nMessaggio di errore: " +
					ex.Message;
				_logger.LogError(errorMessage);

				return StatusCode(500);
			}
		}

		[HttpPut("update")]
		public async Task<ActionResult<UserDto>> UpdateUser([FromBody] UserUpdatedDto userUpdate)
		{
			var logMex = $"Tentativo di modifica dell'utente con id {userUpdate.Id}:";
			try
			{
				_logger.LogInformation($"{logMex} Inizio");

				//Check if the user exists
				if (!(await _userService.ExistsFromId(userUpdate.Id)))
				{
					_logger.LogWarning($"{logMex} User not found.");
					return BadRequest("User not found.");
				}

				var res = await _userService.Update(userUpdate);

				if (!res)
				{
					_logger.LogWarning(logMex + "Fallito senza eccezioni");
					return StatusCode(500);
				}
				_logger.LogInformation(logMex + "Successo");

				var userUpdated = await _userService.GetFromId(userUpdate.Id);

				return Ok(userUpdated);
			}
			catch (Exception ex)
			{
				_logger.LogError($"{logMex} fallito\n" +
					$"Messaggio di errore: {ex.Message}");

				return StatusCode(500);
			}
		}

		[HttpPut("update/password")]
		public async Task<ActionResult> UpdatePassword([FromBody] UserUpdatePasswordDto userUpdatePassword)
		{
			var logMex = $"Tentativo di modifica PASSWORD dell'utente con id {userUpdatePassword.Id}:";
			try
			{
				_logger.LogInformation($"{logMex} Inizio");

				//Check if user exists
				if (!(await _userService.ExistsFromId(userUpdatePassword.Id)))
				{
					_logger.LogWarning($"{logMex} User not found.");
					return BadRequest("User not found.");
				}

				//Check if the old password is correct
				if (!(await _userService.ExistsFromIdAndPassword(userUpdatePassword.Id, userUpdatePassword.OldPassword)))
				{
					_logger.LogWarning($"{logMex} Incorrect old password.");
					return BadRequest("Incorrect old password.");
				}

				var res = await _userService.UpdatePassword(userUpdatePassword);

				if (!res)
				{
					_logger.LogWarning(logMex + "Fallito senza eccezioni");
					return StatusCode(500);
				}

				_logger.LogInformation(logMex + "Successo");
				return NoContent();

			}
			catch (AccessViolationException ex)
			{
				_logger.LogError($"{logMex} fallito\n" +
					$"Messaggio di errore: {ex.Message}");

				return BadRequest(ex.Message);
			}
			catch (Exception ex)
			{

				_logger.LogError($"{logMex} fallito\n" +
					$"Messaggio di errore: {ex.Message}");

				return StatusCode(500);
			}

		}
	}
}
