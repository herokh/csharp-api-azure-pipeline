using AutoMapper;
using HeroKh.Api.Web.DTOs.User;

namespace HeroKh.Api.Web.Mappings.User
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, Models.User>();
            CreateMap<Models.User, ReadonlyUserDto>();
        }
    }
}
