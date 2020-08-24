﻿// <auto-generated />
using System;
using ECommerce.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ECommerce.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    [Migration("20200824022337_tookoffphonenumber")]
    partial class tookoffphonenumber
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ECommerce.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("ECommerce.Models.CartItem", b =>
                {
                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("CartId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItem");
                });

            modelBuilder.Entity("ECommerce.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CartId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zip")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("ECommerce.Models.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Recommendation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Stock")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "This product came out in 2017 and features anywhere from 6-18 cores.",
                            Image = "https://ecom17.blob.core.windows.net/pictures/i9.jpg",
                            Name = "Intel core i9",
                            Price = 430.00m,
                            Recommendation = "Use for desktop computers (heat issue with laptops).",
                            Stock = "There are currently 38 left in stock"
                        },
                        new
                        {
                            Id = 2,
                            Description = "This product is a high end computer that specializes in heat management.",
                            Image = "https://ecom17.blob.core.windows.net/pictures/Ryzen5.jpg",
                            Name = "Ryzen 5",
                            Price = 650.00m,
                            Recommendation = "Use this with two 1080p monitors for optimal performance.",
                            Stock = "15"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Last gen PC that still has fairly good processing power with decent heat management.",
                            Image = "https://ecom17.blob.core.windows.net/pictures/Ryzen7.jpg",
                            Name = "Ryzen 7",
                            Price = 330.00m,
                            Recommendation = "While not as powerful as the Ryzen 9, it is still a solid investment for a personal computer.",
                            Stock = "21"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Decent product that has 2-8 cores.",
                            Image = "https://ecom17.blob.core.windows.net/pictures/CPU.jpg",
                            Name = "Intel core i5",
                            Price = 200.00m,
                            Recommendation = "If one is on a budget and can't afford the I9, this is a good bet.",
                            Stock = "40"
                        },
                        new
                        {
                            Id = 5,
                            Description = "The middle road processor between i5 and i9, with 6-12 cores.",
                            Image = "https://ecom17.blob.core.windows.net/pictures/i7.jpg",
                            Name = "Intel core i7",
                            Price = 320.00m,
                            Recommendation = "Only a few left, so buy it while you have the chance!",
                            Stock = "5"
                        },
                        new
                        {
                            Id = 6,
                            Description = "High end graphics card that is fit for use in the newest generation pc's.",
                            Image = "https://ecom17.blob.core.windows.net/pictures/GTX1080.jpg",
                            Name = "Nvidia 1080",
                            Price = 240.00m,
                            Recommendation = "Expensive, but a great asset for any high end gaming computer.",
                            Stock = "9"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Radeon's answer to the Nvidia 1080, it is another high end graphics card.",
                            Image = "https://ecom17.blob.core.windows.net/pictures/Radeon8940.jpg",
                            Name = "AMD Radeon 8940",
                            Price = 198.00m,
                            Recommendation = "Slightly less performance but cheaper than the Nvidia 1080. Buy it if you have a budget.",
                            Stock = "16"
                        },
                        new
                        {
                            Id = 8,
                            Description = "A high end graphics card that is used best with overclocked computers.",
                            Image = "https://ecom17.blob.core.windows.net/pictures/GigabyteGPU.jpg",
                            Name = "MSI GTX 1660",
                            Price = 249.00m,
                            Recommendation = "If you want to maximize performance and don't mind system bugs, this is the product for you!",
                            Stock = "3"
                        },
                        new
                        {
                            Id = 9,
                            Description = "A last generation Nvidia graphics card, it still possessess solid performance stats.",
                            Image = "https://ecom17.blob.core.windows.net/pictures/RTX2080.jpg",
                            Name = "RTX 2080",
                            Price = 250.00m,
                            Recommendation = "Buy if you don't mind not playing on ultra graphics settings.",
                            Stock = "11"
                        },
                        new
                        {
                            Id = 10,
                            Description = "The best bargain graphics card in the store!",
                            Image = "https://ecom17.blob.core.windows.net/pictures/gpu.jpg",
                            Name = "ASUS 1060",
                            Price = 300.00m,
                            Recommendation = "Buy if you plan on spending your money on other computer parts. We recommend buying more RAM to offset card shortcomings.",
                            Stock = "18"
                        });
                });

            modelBuilder.Entity("ECommerce.Models.CartItem", b =>
                {
                    b.HasOne("ECommerce.Models.Cart", "Cart")
                        .WithMany("CartItem")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerce.Models.Products", "Product")
                        .WithMany("CartItem")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ECommerce.Models.Order", b =>
                {
                    b.HasOne("ECommerce.Models.Cart", "Cart")
                        .WithMany("Order")
                        .HasForeignKey("CartId");
                });
#pragma warning restore 612, 618
        }
    }
}
