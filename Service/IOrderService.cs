using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Занятие_3.Entities;

namespace Занятие_3.Service
{
    public interface IOrderService
    {
        OrderEntity Get(Guid id);
        Task<Guid> Add(OrderEntity order);        
        Task<Guid> Update(OrderEntity order);
        Task Delete(Guid id);
    }
}
