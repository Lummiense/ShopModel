﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Занятие_3;

namespace Занятие_3.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Занятие_3.Entities.OrderEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("OrderStatus")
                        .HasColumnType("text");

                    b.Property<Guid?>("ShopId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Занятие_3.Entities.ProductEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Availability")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid?>("OrderEntityId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("Producer")
                        .HasColumnType("text");

                    b.Property<string>("ProductPicture")
                        .HasColumnType("text");

                    b.Property<DateTime>("ProductionDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("OrderEntityId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Занятие_3.Entities.ShopEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<long>("DeliveredOrderCount")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<long>("OrderCount")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("Занятие_3.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<long>("Age")
                        .HasColumnType("bigint");

                    b.Property<Guid?>("FavoriteShopId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<long>("OrderCount")
                        .HasColumnType("bigint");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FavoriteShopId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Занятие_3.Entities.OrderEntity", b =>
                {
                    b.HasOne("Занятие_3.Entities.ShopEntity", "Shop")
                        .WithMany()
                        .HasForeignKey("ShopId");

                    b.HasOne("Занятие_3.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Shop");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Занятие_3.Entities.ProductEntity", b =>
                {
                    b.HasOne("Занятие_3.Entities.OrderEntity", null)
                        .WithMany("ProductCart")
                        .HasForeignKey("OrderEntityId");
                });

            modelBuilder.Entity("Занятие_3.Entities.UserEntity", b =>
                {
                    b.HasOne("Занятие_3.Entities.ShopEntity", "FavoriteShop")
                        .WithMany()
                        .HasForeignKey("FavoriteShopId");

                    b.Navigation("FavoriteShop");
                });

            modelBuilder.Entity("Занятие_3.Entities.OrderEntity", b =>
                {
                    b.Navigation("ProductCart");
                });
#pragma warning restore 612, 618
        }
    }
}
