using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Занятие_3.Entities;

namespace Занятие_3
{
    public class DataContext: IdentityDbContext
    {
        public DbSet <UserEntity> Users { get; set; }
        public DbSet <ShopEntity> Shops { get; set; }
        public DbSet <ProductEntity> Products { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //   // modelBuilder.Property(x=>)
        //}
    }
}
