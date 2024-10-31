using AkodoAPI.DTOs;
using AkodoAPI.Models;
using AutoMapper;

namespace AkodoAPI.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegisterDto, User>();
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}
