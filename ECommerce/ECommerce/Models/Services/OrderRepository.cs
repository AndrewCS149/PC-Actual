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

        // TODO: summary comment
        public async Task<Order> Create(Order order)
        {
            _context.Entry(order).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return order;
        }
    }
}