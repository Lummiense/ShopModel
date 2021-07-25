using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Занятие_3.Model
{
    public class AuthenticationRequest
    {
        public string Email { get; set; }
        public bool RememberMe { get; set; }
        public string Password { get; set; }
    }
}
