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
        /// Retrieves all the items within a specified cart
        /// </summary>
        /// <param name="id">Id of cart</param>
        /// <returns>All items within the specified cart</returns>
        public async Task<List<CartItem>> GetCartItems(int id)
        {
            List<CartItem> result = await _context.CartItem.Where(x => x.CartId == id).ToListAsync();
            //result.
            //List<Products> products = await _context.Products.Where(x => x.Id == result.)

            return result;
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
            var result = await _context.Cart.Where(x => x.UserEmail.ToLower() == email.ToLower()).Include(x => x.CartItem).ThenInclude(x => x.Product).FirstOrDefaultAsync();
            return result;
        }
    }
}