using System;

namespace ShopApi.Model
{
    public class LoginResponse
    {
        public string Token{get;set;}
        public DateTime Expiration { get; set; }
    }
}