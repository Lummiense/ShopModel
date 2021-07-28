using System;
using Microsoft.AspNetCore.Identity;

namespace Занятие_3.Entities
{
    public class UserEntity : IdentityUser<uint>, IEntity
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
