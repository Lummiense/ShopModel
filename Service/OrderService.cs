using System;
using System.Linq;
using System.Threading.Tasks;
using ShopApi.Entities;
using ShopApi.Repository;

namespace ShopApi.Service
{
    public class OrderService : IOrderService
    {
        private readonly IDbRepository _dbRepository;
        public OrderService(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public OrderEntity Get(Guid id)
        {
            var entity = _dbRepository.Get<OrderEntity>().FirstOrDefault(x => x.Id == id);
            return entity;
        }
        public async Task<Guid> Add(OrderEntity order)
        {
            if (order == null)
            {
                throw new ArgumentException("Заказ не создан");
            }
            
            if (order.ProductCart.Count<=0)
            {
                throw new ArgumentOutOfRangeException("Заказ пуст-его нельзя добавить");
            }

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
            await _dbRepository.Update(order);
            await _dbRepository.SaveChangesAsync();

            return order.Id;
        }
    }
}
