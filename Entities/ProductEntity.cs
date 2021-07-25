using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApi.Entities
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
        
        /// <summary>
        /// Наличие товара
        /// </summary>
        public bool Availability { get; set; }
        
        /// <summary>
        /// Поставщик. Будет скрываться от покупателя, но доступно держателю магазина
        /// </summary>
        public string Producer { get; set; }
        
        /// <summary>
        /// Изображение товара.
        /// </summary>
        public string ProductPicture { get; set; }
    }
} 
