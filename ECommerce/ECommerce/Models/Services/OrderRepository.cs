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
        public async Task<Order> Create(Order order)
        {            
            _context.Entry(order).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> GetOrder(string userId)
        {
            var result = await _context.Order.Where(x => x.AppUserId == userId)
                .Include(x => x.Cart)
                .ThenInclude(x => x.CartItem)
                .ThenInclude(x => x.Product)
                .OrderBy(x => x.OrderDate)
                .FirstOrDefaultAsync();
            //var result2 = from item in _context.Order
            //              where item.Email.ToLower() == email.ToLower()
            //              orderby item.OrderDate
            //              select item;

            //var result3 = result2.FirstOrDefaultAsync();
            //return await result3;
            return result;
        }
    }
}