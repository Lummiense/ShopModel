using System.Collections.Generic;


namespace ShopApi.Entities
{
    public class ProductCategoryEntity : IEntity

    {
        public uint Id { get; set; }
        public bool IsActive { get; set; }
        public List<ProductEntity> Products = new List<ProductEntity>();
    }
}