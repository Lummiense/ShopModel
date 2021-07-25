using System;
using Занятие_3.Entities;
using AutoMapper;
using Занятие_3.Model;

namespace Занятие_3
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<UserEntity, Buyer>().ReverseMap()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id));
            




        }
    }
}
