using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Занятие_3.Entities;
using Занятие_3.Model;

namespace Занятие_3.Service
{
    public interface IOrderService
    {
        OrderEntity Get(uint id);
        Task<uint> Add(OrderEntity order);        
        Task<uint> Update(OrderEntity order);
        Task Delete(uint id);
        
        

    }
}
