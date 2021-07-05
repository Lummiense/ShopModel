using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Занятие_3.Entities
{
    public class ProductEntity : IEntity
    {
        //TODO: сделать maper из сущности в модель контроллера
        [Column(TypeName = "uuid")]
        public Guid Id { get; set; }

        public bool IsActive { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }
        /// <summary>
        /// Дата производства товара.
        /// </summary>
        public DateTime ProductionDate { get; set; }
        //Наличие товара
        public bool Availability { get; set; }
        //Поставщик. Будет скрываться от покупателя, но доступно держателю магазина
        public string Producer { get; set; }
        /// <summary>
        /// Изображение товара.
        /// </summary>
        public string ProductPicture { get; set; }


    }
} 
