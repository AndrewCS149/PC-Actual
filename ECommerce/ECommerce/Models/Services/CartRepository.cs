using AspNetCore;
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

        /// <summary>
        /// Adds a new Cart to the database
        /// </summary>
        /// <param name="email">The email to attach the cart to</param>
        /// <returns>Newly created cart</returns>
        public async Task<Cart> Create(string email)
        {
            Cart cart = new Cart();
            cart.UserEmail = email;
            cart.IsActive = true;
            _context.Entry(cart).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return cart;
        }

        /// <summary>
        /// Gets a specified cart from the database
        /// </summary>
        /// <param name="email">Email of the cart to get</param>
        /// <returns>Specified cart</returns>
        public async Task<Cart> GetCart(string email)
        {
            var result = await _context.Cart.Where(x => x.UserEmail.ToLower() == email.ToLower() && x.IsActive == true).Include(x => x.CartItem).ThenInclude(x => x.Product).FirstOrDefaultAsync();
            return result;
        }

        public async Task<Cart> Update(Cart cart)
        {
            _context.Entry(cart).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}