using System;
using AutoMapper;
using ShopApi.Entities;
using ShopApi.Model;

namespace ShopApi.Profiles
{
    public class ShopForBuyersProfile:Profile
    {
       public ShopForBuyersProfile()
        {
            CreateMap<ShopEntity, ShopForBuyers>().ReverseMap();
        }
    }
}
