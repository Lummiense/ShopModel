using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Занятие_3.Entities
{
    public class UserEntity :IEntity
    {
        //TODO: сделать maper из сущности в модель контроллера
        [Column(TypeName = "uuid")]
        public Guid Id { get; set; }
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
        [JsonIgnore]
        public string Password { get; set; }



    }
}
