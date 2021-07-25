using System;
using System.Threading.Tasks;
using ShopApi.Entities;

namespace ShopApi.Service
{
    public interface IProductService

    {
        Task<Guid> Add(ProductEntity product);
        ProductEntity Get(Guid id);
        Task<Guid> Update(ProductEntity product);
        Task Delete(Guid id);
    }
}
