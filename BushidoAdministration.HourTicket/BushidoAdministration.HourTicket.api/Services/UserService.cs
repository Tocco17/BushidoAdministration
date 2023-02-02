using AutoMapper;
using BushidoAdministration.HourTicket.api.Entities;
using BushidoAdministration.HourTicket.api.Enum;
using BushidoAdministration.HourTicket.api.Models;
using BushidoAdministration.HourTicket.api.Repositories;

namespace BushidoAdministration.HourTicket.api.Services
{
	public class UserService : IUserService
	{
		private readonly IMapper _mapper;
		private readonly IUserRepository _userRepository;

		public UserService(IMapper mapper, IUserRepository userRepository)
		{
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
			_userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
		}

		public async Task<UserDto> LoginFromEmail(string email, string password)
		{
			var userEntity = await _userRepository.LoginFromEmail(email, password);
			var userModel = _mapper.Map<UserDto>(userEntity);
			return userModel;
		}

		public async Task<UserDto> LoginFromUsername(string username, string password)
		{
			var userEntity = await _userRepository.LoginFromUsername(username, password);
			var userModel = _mapper.Map<UserDto>(userEntity);
			return userModel;
		}

		public async Task<RoleLevel?> GetRoleLevel(int userId)
		{
			return await _userRepository.GetRoleLevel(userId);
		}


		public async Task<UserDto> GetFromId(int userId)
		{
			var userEntity = await _userRepository.GetFromId(userId);
			var userDto = _mapper.Map<UserDto>(userEntity);
			return userDto;
		}

		public async Task<UserDto> GetFromEmail(string email)
		{
			var userEntity = await _userRepository.GetFromEmail(email);
			var userDto = _mapper.Map<UserDto>(userEntity);
			return userDto;
		}

		public async Task<UserDto> GetFromUsername(string username)
		{
			var userEntity = await _userRepository.GetFromUsername(username);
			return _mapper.Map<UserDto>(userEntity);
		}

		public async Task<bool> Update(UserUpdatedDto userUpdated)
		{
			var model = _mapper.Map<User>(userUpdated);
			return await _userRepository.Update(model);
		}

		public async Task<bool> UpdatePassword(UserUpdatePasswordDto userUpdatePassword)
		{
			return await _userRepository.UpdatePassword(userUpdatePassword.Id, userUpdatePassword.OldPassword, userUpdatePassword.NewPassword);
		}

		public async Task<bool> ExistsFromId(int userId)
		{
			return await _userRepository.ExistsFromId(userId);
		}

		public async Task<bool> ExistsFromUsername(string username)
		{
			return await _userRepository.ExistsFromUsername(username);
		}

		public async Task<bool> ExistsFromEmail(string email)
		{
			return await _userRepository.ExistsFromEmail(email);
		}

		public async Task<bool> ExistsFromIdAndPassword(int userId, string password)
		{
			return await _userRepository.ExistsFromIdAndPassword(userId, password);
		}
	}
}
