using ECommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ECommerce.Models.Interfaces;
using Microsoft.AspNetCore.Identity;

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
        public async Task<Order> Create(Order order)
        {
            order.OrderDate = DateTime.Now;
            _context.Entry(order).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return order;
        }

        /// <summary>
        /// Gets a specified order from the database
        /// </summary>
        /// <param name="userId">The GUID of the order to retrieve</param>
        /// <returns>An order object</returns>
        public async Task<Order> GetOrder(string userId)
        {
            var result = await _context.Order.Where(x => x.AppUserId == userId)
                .Include(x => x.Cart)
                .ThenInclude(x => x.CartItem)
                .ThenInclude(x => x.Product)
                .OrderByDescending(x => x.OrderDate)
                .FirstOrDefaultAsync();

            return result;
        }

        /// <summary>
        /// Gets all orders of a specified user
        /// </summary>
        /// <param name="userId">The GUID of the appUsers orders to retrieve</param>
        /// <returns>List of all users orders</returns>
        public async Task<List<Order>> GetOrders(string userId)
        {
            var result = await _context.Order.Where(x => x.AppUserId == userId)
                .Include(x => x.Cart)
                .ThenInclude(x => x.CartItem)
                .ThenInclude(x => x.Product)
                .OrderByDescending(x => x.OrderDate)
                .ToListAsync();

            return result;
        }

        public async Task<Order> GetOrder(string userId, int orderId)
        {
            var result = await _context.Order.Where(x => x.AppUserId == userId && x.Id == orderId)
                .Include(x => x.Cart)
                .ThenInclude(x => x.CartItem)
                .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync();

            return result;
        }
    }
}