using AutoMapper;
using NoMoreAlone.Api.Dtos.User;
using NoMoreAlone.Domain.Models;

namespace NoMoreAlone.Api.AutoMapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserCreateDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
        }
    }
}