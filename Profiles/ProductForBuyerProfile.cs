using System;
using AutoMapper;
using ShopApi.Entities;
using ShopApi.Model;

namespace ShopApi.Profiles
{
    public class ProductForBuyerProfile:Profile
    {
        public ProductForBuyerProfile()
        {
            CreateMap<ProductEntity, ProductForBuyer>();
        }
    }
}
