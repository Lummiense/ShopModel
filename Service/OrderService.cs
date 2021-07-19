using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Занятие_3.Entities;
using Занятие_3.Repository;

namespace Занятие_3.Service
{
    public class OrderService:IOrderService
    {
        private readonly IDbRepository _dbRepository;
        public OrderService(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public OrderEntity Get(Guid id)
        {
            var entity = _dbRepository.Get<OrderEntity>().FirstOrDefault(x => x.Id == id);
            return entity; ;
        }
        public async Task<Guid> Add(OrderEntity order)
        {
            #region OrderException
            if (order == null)
            {
                throw new ArgumentException("Заказ не создан");
            }
            else if (order.ProductCart.Count<=0)
            {
                throw new ArgumentOutOfRangeException("Заказ пуст-его нельзя добавить");
            }
            #endregion
            var result = await _dbRepository.Add(order);            
            await _dbRepository.SaveChangesAsync();
            return result;
        }

        public async Task Delete(Guid id)
        {
            await _dbRepository.Delete<OrderEntity>(id);
            await _dbRepository.SaveChangesAsync();
        }

       

        public async Task<Guid> Update(OrderEntity order)
        {
            await _dbRepository.Update<OrderEntity>(order);
            await _dbRepository.SaveChangesAsync();

            return order.Id;
        }
    }
}
