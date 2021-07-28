using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Занятие_3.Model
{
    public class ShopForBuyers
    {
        public string Name { get; set; }
        /// <summary>
        /// Total order count delivered to buyers from this shop.
        /// </summary>
        public uint DeliveredOrderCount { get; set; }
    }
}
