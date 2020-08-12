using ECommerce.Data;
using ECommerce.Models.Interfaces;
using ECommerce.Models.Services;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceTests
{
    public class DatabaseTests : IDisposable
    {
        private readonly SqliteConnection _connection;
        private readonly IProducts _products;
        private readonly StoreDbContext _StoreDb;

        public DatabaseTests()
        {
            _connection = new SqliteConnection("Filename=:memory");
            _connection.Open();
            _products = new InventoryManagement()
        }
    }
}