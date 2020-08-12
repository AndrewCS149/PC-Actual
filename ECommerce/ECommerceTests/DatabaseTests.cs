using ECommerce.Data;
using ECommerce.Models.Interfaces;
using ECommerce.Models.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceTests
{
    public class DatabaseTests : IDisposable
    {
        private readonly SqliteConnection _connection;
        protected readonly IProducts _products;
        protected readonly StoreDbContext _db;

        public DatabaseTests()
        {
            _connection = new SqliteConnection("Filename=:memory");
            _connection.Open();

            _db = new StoreDbContext(
                new DbContextOptionsBuilder<StoreDbContext>()
                .UseSqlite(_connection)
                .Options);

            _db.Database.EnsureCreated();

            _products = new InventoryManagement(_db);
        }

        public void Dispose()
        {
            _db?.Dispose();
            _connection?.Dispose();
        }
    }
}