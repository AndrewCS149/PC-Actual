﻿// <auto-generated />
using ECommerce.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ECommerce.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    partial class ProductsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ECommerce.Models.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Image = "https://ecommerce17.blob.core.windows.net/pictures/i9.jpg",
                            Name = "Intel core i9",
                            Price = 430.00m
                        },
                        new
                        {
                            Id = 2,
                            Image = "https://ecommerce17.blob.core.windows.net/pictures/CPU.jpg",
                            Name = "Ryzen 9",
                            Price = 650.00m
                        },
                        new
                        {
                            Id = 3,
                            Image = "https://ecommerce17.blob.core.windows.net/pictures/Ryzen7.jpg",
                            Name = "Ryzen 7",
                            Price = 330.00m
                        },
                        new
                        {
                            Id = 4,
                            Image = "https://ecommerce17.blob.core.windows.net/pictures/CPU-3.jpg",
                            Name = "Intel core i5",
                            Price = 200.00m
                        },
                        new
                        {
                            Id = 5,
                            Image = "https://ecommerce17.blob.core.windows.net/pictures/i7.jpg",
                            Name = "Intel core i7",
                            Price = 320.00m
                        },
                        new
                        {
                            Id = 6,
                            Image = "https://ecommerce17.blob.core.windows.net/pictures/GTX1080.jpg",
                            Name = "Nvidia 1080",
                            Price = 240.00m
                        },
                        new
                        {
                            Id = 7,
                            Image = "https://ecommerce17.blob.core.windows.net/pictures/Radeon.jpg",
                            Name = "AMD Radeon 8940",
                            Price = 198.00m
                        },
                        new
                        {
                            Id = 8,
                            Image = "https://ecommerce17.blob.core.windows.net/pictures/GPU.jpg",
                            Name = "MSI GTX 1660",
                            Price = 249.00m
                        },
                        new
                        {
                            Id = 9,
                            Image = "https://ecommerce17.blob.core.windows.net/pictures/RTX2080.jpg",
                            Name = "RTX 2080",
                            Price = 250.00m
                        },
                        new
                        {
                            Id = 10,
                            Image = "https://ecommerce17.blob.core.windows.net/pictures/Gigabyte.jpg",
                            Name = "Gigabyte RTX 2060",
                            Price = 650.00m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}