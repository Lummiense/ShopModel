using System;
using AutoMapper;
using Занятие_3.Entities;
using Занятие_3.Model;

namespace Занятие_3.Profiles
{
    public class ProductForBuyerProfile:Profile
    {
        public ProductForBuyerProfile()
        {
            CreateMap<ProductEntity, ProductForBuyer>();
        }
    }
}
