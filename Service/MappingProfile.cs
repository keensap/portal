using System;
using AutoMapper;
using KeenSap.Portal.Data.Entities;
using KeenSap.Portal.Service.Dto.Response;
using KeenSap.Portal.Service.Dto.Request;

namespace KeenSap.Portal.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserGetDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();
        }        
    }
}
