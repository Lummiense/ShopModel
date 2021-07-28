using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Занятие_3.Entities
{
    public class OrderEntity : IEntity
    {
        public bool IsActive { get; set;}
        /// <summary>
        /// Order ID.
        /// </summary>
        public uint Id { get; set; }
        /// <summary>
        /// Buyer.
        /// </summary>
        public UserEntity User { get; set; }

        /// <summary>
        /// List of products in buyer cart.
        /// </summary>        
        public List<ProductEntity> ProductCart = new List<ProductEntity>();
        
        /// <summary>
        /// Product dealer.
        /// </summary>
        public ShopEntity Shop { get; set; }
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// Total order amount.
        /// </summary>
        public  uint OrderCount { get; set; }

        public string[] OrderStatusVariation = {"Created", "Paid", "Delivered"};
        public string OrderStatus { get; set; }
       
    }
}
