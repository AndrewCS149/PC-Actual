﻿using ECommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class StoreDbContext : DbContext
    {
        public DbSet<Products> Products { get; set; }
        public DbSet<CartItem> CartItem { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Order> Order { get; set; }

        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CartItem>().HasKey(x => new { x.CartId, x.ProductId });

            modelBuilder.Entity<Products>().HasData(
                new Products
                {
                    Id = 1,
                    Name = "Intel core i9",
                    Price = 430.00M,
                    Image = "I9.jpg",
                    Description = "This product came out in 2017 and features anywhere from 6-18 cores.",
                    Stock = "38",
                    Recommendation = "Use for desktop computers (heat issue with laptops)."
                },
                new Products
                {
                    Id = 2,
                    Name = "AMD Ryzen 5",
                    Price = 650.00M,
                    Image = "Ryzen5.jpg",
                    Description = "This product is a high end computer that specializes in heat management.",
                    Stock = "15",
                    Recommendation = "Use this with two 1080p monitors for optimal performance."
                },
                new Products
                {
                    Id = 3,
                    Name = "AMD Ryzen 7",
                    Price = 330.00M,
                    Image = "Ryzen7.jpg",
                    Description = "Last gen PC that still has fairly good processing power with decent heat management.",
                    Stock = "21",
                    Recommendation = "While not as powerful as the Ryzen 9, it is still a solid investment for a personal computer."
                },
                new Products
                {
                    Id = 4,
                    Name = "Intel core i5",
                    Price = 200.00M,
                    Image = "I5.jpg",
                    Description = "Decent product that has 2-8 cores.",
                    Stock = "40",
                    Recommendation = "If one is on a budget and can't afford the I9, this is a good bet."
                },
                new Products
                {
                    Id = 5,
                    Name = "Intel core i7",
                    Price = 320.00M,
                    Image = "I7.jpg",
                    Description = "The middle road processor between i5 and i9, with 6-12 cores.",
                    Stock = "5",
                    Recommendation = "Only a few left, so buy it while you have the chance!"
                },
                new Products
                {
                    Id = 6,
                    Name = "Nvidia GTX 1080",
                    Price = 240.00M,
                    Image = "NvidiaGTX1080.jpg",
                    Description = "High end graphics card that is fit for use in the newest generation pc's.",
                    Stock = "9",
                    Recommendation = "Expensive, but a great asset for any high end gaming computer."
                },
                new Products
                {
                    Id = 7,
                    Name = "AMD Radeon 8940",
                    Price = 198.00M,
                    Image = "AMDRaedon8940.jpg",
                    Description = "Radeon's answer to the Nvidia 1080, it is another high end graphics card.",
                    Stock = "16",
                    Recommendation = "Slightly less performance but cheaper than the Nvidia 1080. Buy it if you have a budget."
                },
                new Products
                {
                    Id = 8,
                    Name = "MSI GTX 1660",
                    Price = 249.00M,
                    Image = "MSIGTX1660.jpg",
                    Description = "A high end graphics card that is used best with overclocked computers.",
                    Stock = "3",
                    Recommendation = "If you want to maximize performance and don't mind system bugs, this is the product for you!"
                },
                new Products
                {
                    Id = 9,
                    Name = "Nvidia RTX 2080",
                    Price = 250.00M,
                    Image = "NvidiaRTX2080.jpg",
                    Description = "A last generation Nvidia graphics card, it still possessess solid performance stats.",
                    Stock = "11",
                    Recommendation = "Buy if you don't mind not playing on ultra graphics settings."
                },
                new Products
                {
                    Id = 10,
                    Name = "ASUS GTX 1060",
                    Price = 300.00M,
                    Image = "AsusGTX1060.jpg",
                    Description = "The best bargain graphics card in the store!",
                    Stock = "18",
                    Recommendation = "Buy if you plan on spending your money on other computer parts. We recommend buying more RAM to offset card shortcomings."
                }
            );
        }
    }
}