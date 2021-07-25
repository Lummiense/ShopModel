using System;
using System.Threading.Tasks;
using ShopApi.Entities;

namespace ShopApi.Service
{
    public interface IShopService
    {
        Task<Guid> Add(ShopEntity shop);
        ShopEntity Get(Guid id);
        Task<Guid> Update(ShopEntity shop);
        Task Delete(Guid id);
    }
}
