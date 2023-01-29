using AutoMapper;
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

		public async Task<UserLoggedDto> LoginFromEmail(string email, string password)
		{
			var userEntity = await _userRepository.LoginFromEmail(email, password);
			var userModel = _mapper.Map<UserLoggedDto>(userEntity);
			return userModel;
		}

		public async Task<UserLoggedDto> LoginFromUsername(string username, string password)
		{
			var userEntity = await _userRepository.LoginFromUsername(username, password);
			var userModel = _mapper.Map<UserLoggedDto>(userEntity);
			return userModel;
		}
	}
}
