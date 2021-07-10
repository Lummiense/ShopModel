using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Занятие_3.Entities
{
    public class OrderEntity
    {
        public Guid Id { get; set; }
        public ProductEntity Product { get; set; }
        public ShopEntity Shop { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
