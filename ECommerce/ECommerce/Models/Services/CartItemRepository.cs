using ECommerce.Data;
using ECommerce.Migrations;
using ECommerce.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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

        /// <summary>
        /// Retrieves a specified item from a specified cart
        /// </summary>
        /// <param name="cartId">Id of cart</param>
        /// <param name="productId">Id of product</param>
        /// <returns>Cart Item from specified cart</returns>
        public async Task<CartItem> GetCartItem(int cartId, int productId)
        {
            return await _context.CartItem.Where(x => x.CartId == cartId && x.ProductId == productId).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Retrieves all the items within a specified cart
        /// </summary>
        /// <param name="id">Id of cart</param>
        /// <returns>All items within the specified cart</returns>
        public async Task<List<CartItem>> GetCartItems(int id)
        {
            List<CartItem> result = await _context.CartItem.Where(x => x.CartId == id).ToListAsync();

            return result;
        }

        /// <summary>
        /// Updates the quantity of specified item in specified cart
        /// </summary>
        /// <param name="cartId">Id of cart</param>
        /// <param name="productId">Id of product</param>
        /// <returns>Successful completion of task</returns>
        public async Task UpdateQty(int cartId, int productId)
        {
            var cartItem = await GetCartItem(cartId, productId);
            cartItem.Quantity++;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates the quantity of specified item in the current cart
        /// </summary>
        /// <param name="cartId">Id of cart</param>
        /// <param name="productId">Id of product</param>
        /// <returns>Successful completion of task</returns>
        public async Task UpdateCartQty(int count, int cartId, int productId)
        {
            var cartItem = await GetCartItem(cartId, productId);
            cartItem.Quantity = count;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Adds a specified item to a specified cart
        /// </summary>
        /// <param name="cartId">Id of cart</param>
        /// <param name="productId">Id of product</param>
        /// <returns>Successful completion of task</returns>
        public async Task AddToCart(int cartId, int productId)
        {
            Products product = await _context.Products.FirstOrDefaultAsync(x => x.Id == productId);

            CartItem cartItem = new CartItem()
            {
                CartId = cartId,
                ProductId = productId,
                DateAdded = DateTime.Now,
                Quantity = 1
            };

            cartItem.Product = product;

            _context.Entry(cartItem).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Delete a cart item
        /// </summary>
        /// <param name="id">the item to be deleted</param>
        /// <returns>Successful completion of method</returns>
        public async Task Delete(CartItem cartItem)
        {
            //CartItem cartItem = await _context.CartItem.FindAsync(id);
            if (cartItem != null)
            {
                _context.Entry(cartItem).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }
    }
}