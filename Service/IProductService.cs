using System;
using System.Threading.Tasks;
using ShopApi.Entities;

namespace ShopApi.Service
{
    public interface IProductService

    {
        Task<uint> Add(ProductEntity product);
        ProductEntity Get(uint id);
        Task<uint> Update(ProductEntity product);
        Task Delete(uint id);
    }
}
