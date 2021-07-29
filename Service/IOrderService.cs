using System;
using System.Threading.Tasks;
using ShopApi.Entities;

namespace ShopApi.Service
{
    public interface IOrderService
    {
        OrderEntity Get(uint id);
        Task<uint> Add(OrderEntity order);        
        Task<uint> Update(OrderEntity order);
        Task Delete(uint id);
        
        

    }
}
