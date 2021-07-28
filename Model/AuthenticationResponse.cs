using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Занятие_3.Entities;

namespace Занятие_3.Model
{
    public class AuthenticationResponse
    {
        
        public uint Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public uint Age { get; set; }
        public int PhoneNumber { get; set; }
        public string Token { get; set; }
        public AuthenticationResponse (UserEntity User, string token)
        {
            Id = User.Id;
            Login = User.Login;
            Name = User.Name;
            Age = User.Age;
            Token = token;
        }
    }
}
