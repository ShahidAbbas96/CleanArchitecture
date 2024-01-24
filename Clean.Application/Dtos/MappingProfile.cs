using AutoMapper;
using Clean.Application.Dtos.Users;
using Clean.Domain.Entities;

namespace Clean.Application.Dtos
{
    public class MappingProfile:Profile
    {
        public MappingProfile() { 
        CreateMap<AddUserDto,User>().ReverseMap();
        }
    }
}
