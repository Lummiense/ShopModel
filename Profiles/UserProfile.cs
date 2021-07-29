using AutoMapper;
using ShopApi.Entities;
using ShopApi.Model;

namespace ShopApi.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserEntity, Buyer>().ReverseMap()
                .ForMember(dest => dest.Id, source => source.MapFrom(src => src.Id));
            CreateMap<RegisterRequest, UserEntity>()
                .ReverseMap();
        }
    }
}
