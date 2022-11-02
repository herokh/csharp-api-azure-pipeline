using AutoMapper;
using KhWebApi.WebApi.DTOs.User;

namespace KhWebApi.WebApi.Mappings.User
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, Models.User>();
        }
    }
}
