using ECommerce.Models;
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

        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Products>().HasData(
                new Products
                {
                    Id = 1,
                    Name = "Intel core i9",
                    Price = 430.00M
                },
                new Products
                {
                    Id = 2,
                    Name = "Ryzen 9",
                    Price = 650.00M
                },
                new Products
                {
                    Id = 3,
                    Name = "Ryzen 7",
                    Price = 330.00M,
                },
                new Products
                {
                    Id = 4,
                    Name = "Intel core i5",
                    Price = 200.00M,
                },
                new Products
                {
                    Id = 5,
                    Name = "Intel core i7",
                    Price = 320.00M,
                },
                new Products
                {
                    Id = 6,
                    Name = "Nvidia 1080",
                    Price = 240.00M,
                },
                new Products
                {
                    Id = 7,
                    Name = "AMD Radeon 8940",
                    Price = 198.00M,
                },
                new Products
                {
                    Id = 8,
                    Name = "MSI GTX 1660",
                    Price = 249.00M,
                },
                new Products
                {
                    Id = 9,
                    Name = "Dell ATI",
                    Price = 250.00M

                },
                new Products
                {
                    Id = 10,
                    Name = "Nvidia Quadro GT-100",
                    Price = 650.00M,
                }
            );
        }
    }
}