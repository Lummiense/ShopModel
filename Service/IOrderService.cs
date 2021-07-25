using System;
using System.Threading.Tasks;
using ShopApi.Entities;

namespace ShopApi.Service
{
    public interface IOrderService
    {
        OrderEntity Get(Guid id);
        Task<Guid> Add(OrderEntity order);        
        Task<Guid> Update(OrderEntity order);
        Task Delete(Guid id);
    }
}
