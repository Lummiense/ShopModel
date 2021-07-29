using System;

namespace ShopApi.Model
{
    public class Buyer
    {
        public uint Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public uint Age { get; set; }
        public int PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
