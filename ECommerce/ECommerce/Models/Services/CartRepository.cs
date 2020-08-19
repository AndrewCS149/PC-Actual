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
        private IProducts _products;

        public int CartId { get; set; }

        public CartRepository(IProducts products, StoreDbContext context)
        {
            _context = context;
            _products = products;
        }

        public async Task<List<Products>> GetCartItems()
        {
            List<Products> result = await _context.Products.Include(x => x.CartItem)
                .ThenInclude(x => x.Cart).ToListAsync();
            return result;
        }

        // TODO: summary comment
        public async Task AddToCart(int cartId, int productId)
        {
            CartItem cartItem = new CartItem()
            {
                CartId = cartId,
                ProductsId = productId
            };

            cartItem.Cart.DateAdded = DateTime.Now;
            cartItem.Cart.Quantity++;

            _context.Entry(cartItem).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }
    }
}