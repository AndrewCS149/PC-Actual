using ECommerce.Data;
using ECommerce.Migrations;
using ECommerce.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.Services
{
    public class CartItemRepository : ICartItems
    {
        public StoreDbContext _context;

        public CartItemRepository(StoreDbContext context)
        {
            _context = context;
        }

        // TODO: summary comment
        public async Task<CartItem> GetCartItem(int cartId, int productId)
        {
            return await _context.CartItem.Where(x => x.CartId == cartId && x.ProductId == productId).FirstOrDefaultAsync();
        }

        // TODO: summary comment
        public async Task<List<CartItem>> GetCartItems(int id)
        {
            List<CartItem> result = await _context.CartItem.Where(x => x.CartId == id).ToListAsync();

            return result;
        }

        // TODO: summary comment
        public async Task UpdateQty(int cartId, int productId)
        {
            var cartItem = await GetCartItem(cartId, productId);
            cartItem.Quantity++;
            await _context.SaveChangesAsync();
        }

        // TODO: summary comment
        public async Task AddToCart(int cartId, int productId)
        {
            CartItem cartItem = new CartItem()
            {
                CartId = cartId,
                ProductId = productId,
                DateAdded = DateTime.Now,
                Quantity = 1
            };

            _context.Entry(cartItem).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }
    }
}