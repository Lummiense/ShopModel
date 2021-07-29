using System;
using System.Threading.Tasks;
using ShopApi.Entities;

namespace ShopApi.Service
{
    public interface IShopService
    {
        Task<uint> Add(ShopEntity shop);
        ShopEntity Get(uint id);
        Task<uint> Update(ShopEntity shop);
        Task Delete(uint id);
    }
}
