using AutoMapper;
using WebApiCore.DAL.Entities;
using WebApiCore.Dtos;
using WebApiCore.Models;

namespace WebApiCore
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<UserModel, UserDto>()
                .ForMember(um => um.Id, opt => opt.MapFrom(src => src.UserId));

            CreateMap<UserDto, UserEntity>();
            CreateMap<UserEntity, UserDto>();
            CreateMap<UserDto, UserModel>();
            CreateMap<UserDataDto, UserDataEntity>();
            CreateMap<UserDataModel, UserDataDto>();
        }
    }
}
