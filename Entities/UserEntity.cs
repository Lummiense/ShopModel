using System;
using Microsoft.AspNetCore.Identity;

namespace Занятие_3.Entities
{
    public class UserEntity : IdentityUser<Guid>, IEntity
    {
        // TODO: сделать maper из сущности в модель контроллера
        public bool IsActive { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public uint Age { get; set; }        
        public int PhoneNumber { get; set; }
        /// <summary>
        /// Колличество оплаченных заказов пользователя.
        /// </summary>
        public uint OrderCount { get; set; }
        /// <summary>
        /// Любимый магазин. 
        /// </summary>
        public ShopEntity FavoriteShop { get; set; }//Будет выставлен автоматически по колличеству заказов. Виден и пользователю, и администратору.
    }
}
