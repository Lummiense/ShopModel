using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace ShopApi.Entities
{
    public class ProductEntity : IEntity
    {
        
        [Column(TypeName = "integer")]
        public uint Id { get; set; }

        public bool IsActive { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }
        /// <summary>
        /// Production date.
        /// </summary>
        public DateTime ProductionDate { get; set; }
        /// <summary>
        /// Is product available for order now or not?
        /// </summary>
        public bool Availability { get; set; }
        /// <summary>
        /// Product manufacturer.
        /// </summary>
        public string Manufacturer { get; set; }
       
        // public ProductCategoryEntity ProductCategory { get; set; }
        
        /// <summary>
        /// Product picture.
        /// </summary>
        public string ProductPicture { get; set; }
    }
} 
