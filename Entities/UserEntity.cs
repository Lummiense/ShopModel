using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;

namespace ShopApi.Entities
{
    public class UserEntity : IdentityUser
    {

        public bool IsActive { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public uint Age { get; set; }

        /// <summary>
        /// Total order count recieved this buyer.
        /// </summary>
        public uint RecievedOrderCount { get; set; }
    }
}
