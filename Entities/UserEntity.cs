using Microsoft.AspNetCore.Identity;

namespace ShopApi.Entities
{
    public class UserEntity : IdentityUser
    {
        public string Name { get; set; }
        public uint Age { get; set; }    
        
        /// <summary>
        /// Колличество оплаченных заказов пользователя.
        /// </summary>
        public uint OrderCount { get; set; }
        
        /// <summary>
        /// Любимый магазин.
        /// Будет выставлен автоматически по колличеству заказов. Виден и пользователю, и администратору.
        /// </summary>
        public ShopEntity FavoriteShop { get; set; }
    }
}
