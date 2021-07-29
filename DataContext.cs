using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopApi.Entities;

namespace ShopApi
{
    public class DataContext: IdentityDbContext<UserEntity>
    {
        public DbSet <ShopEntity> Shops { get; set; }
        public DbSet <ProductEntity> Products { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
