using ECommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ECommerce.Models.Interfaces;

namespace ECommerce.Models.Services
{
    public class OrderRepository : IOrder
    {
        private StoreDbContext _context;

        public OrderRepository(StoreDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new order to the database
        /// </summary>
        /// <param name="input">The information for the new order</param>
        /// <returns>The new order</returns>
        public async Task<Order> Create(Order input)
        {
            Order order = new Order()
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                Email = input.Email,
                Address = input.Address,
                City = input.City,
                Zip = input.Zip,
                State = input.State,
                OrderDate = DateTime.Now,
                Cart = input.Cart
            };

            _context.Entry(order).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return order;
        }
    }
}