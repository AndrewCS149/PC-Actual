using ECommerce.Data;
using ECommerce.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.Services
{
    public class CartRepository : ICart
    {
        private StoreDbContext _context;

        public CartRepository(StoreDbContext context)
        {
            _context = context;
        }

        // TODO: summary comment
        public async Task<Cart> Create(string email)
        {
            Cart cart = new Cart();
            cart.UserEmail = email;
            _context.Entry(cart).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return cart;
        }

        // TODO: summary comment
        public async Task<Cart> GetCart(string email)
        {
            var result = await _context.Cart.Where(x => x.UserEmail.ToLower() == email.ToLower()).Include(x => x.CartItem).FirstOrDefaultAsync();
            return result;
        }
    }
}