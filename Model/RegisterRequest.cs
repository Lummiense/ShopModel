namespace ShopApi.Model
{
    public class RegisterRequest
    {
        public string Name { get; set; }
        public uint Age { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}