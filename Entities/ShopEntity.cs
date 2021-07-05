using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Занятие_3.Entities
{
    public class ShopEntity : IEntity
    {
        //TODO: сделать maper из сущности в модель контроллера
        public string Name { get; set; }
        [Column(TypeName = "uuid")]
        public Guid Id { get; set; }
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
