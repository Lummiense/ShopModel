using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Занятие_3.Entities
{
    public class ShopEntity : IEntity
    {
        
        public string Name { get; set; }
        
        public uint Id { get; set; }
        public bool IsActive { get; set; }
        /// <summary>
        /// Total order count delivered to buyers from this shop.
        /// </summary>
        public uint DeliveredOrderCount { get; set; }
    }
}
