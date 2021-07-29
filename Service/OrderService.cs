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

          public OrderEntity Get(uint id)
        {
            var entity = _dbRepository.Get<OrderEntity>().FirstOrDefault(x => x.Id == id);
            return entity; ;
        }
        public async Task<uint> Add(OrderEntity order)
        {
            #region OrderException
            if (order.ProductCart.Count<=0)
            {
                throw new ArgumentOutOfRangeException("Cart is empty.");
            }
            #endregion
            //Set order status is "Created"
            order.OrderStatus = order.OrderStatusVariation[0];
            var result = await _dbRepository.Add(order);
            await _dbRepository.SaveChangesAsync();
            return result;
        }

        public async Task Delete(uint id)
        {
            var CheckId = _dbRepository.Get<OrderEntity>().FirstOrDefault(x => x.Id == id);
            if (CheckId == null)
            {
                throw new ArgumentNullException("Order with this ID don`t exist");
            }
            
            //Set order status is "Delivered"
            CheckId.OrderStatus = CheckId.OrderStatusVariation[2];
            
            //Increase buyer`s recieved order counter by 1 
            CheckId.User.RecievedOrderCount++;

            //Increase shop`s successful delivered order counter by 1
            CheckId.Shop.DeliveredOrderCount++;
            
            await _dbRepository.Delete<OrderEntity>(id);
            await _dbRepository.SaveChangesAsync();
        }

        


        public async Task<uint> Update(OrderEntity order)
        {
            //Set order status is "Paid"
            order.OrderStatus = order.OrderStatusVariation[1];
            await _dbRepository.Update<OrderEntity>(order);
            await _dbRepository.SaveChangesAsync();

            return order.Id;
        }

        public decimal TotalPrice(OrderEntity order)
        {
            foreach (var c in order.ProductCart)
            {
                order.TotalPrice += c.Price;
            }
            return order.TotalPrice;
        }
    }
}
