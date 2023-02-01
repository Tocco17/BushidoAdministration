using AutoMapper;

namespace BushidoAdministration.HourTicket.api.Profiles
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<Entities.User, Models.UserDto>();
			CreateMap<Models.UserUpdatedDto, Entities.User>();
		}
	}
}
