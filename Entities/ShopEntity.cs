using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApi.Entities
{
    public class ShopEntity : IEntity
    {
        //TODO: сделать maper из сущности в модель контроллера
        public string Name { get; set; }
        
        [Column(TypeName = "integer")]
        public uint Id { get; set; }
        
        public bool IsActive { get; set; }
        
        /// <summary>
        /// Колличество заказов у данного продавца.
        /// </summary>
        public uint OrderCount { get; set; }
        
        /// <summary>
        /// Успешно доставленные заказы.
        /// </summary>
        public uint DeliveredOrderCount { get; set; }
    }
}
