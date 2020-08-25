using ECommerce.Data;
using ECommerce.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        /// <summary>
        /// Updates a specified cart in the database
        /// </summary>
        /// <param name="cart">Specified cart</param>
        /// <returns>The updated cart</returns>
        public async Task<Cart> Update(Cart cart)
        {
            var result = await _context.Cart.Where(x => x.UserEmail == cart.UserEmail).FirstOrDefaultAsync();
            result = cart;
            _context.Entry(result).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return await _context.Cart.FindAsync(cart.Id);
        }

        /// <summary>
        /// Checks to see if a cart exists in the database
        /// </summary>
        /// <param name="email">The email of the cart to check for</param>
        /// <returns>A boolean determining if the cart exists or not</returns>
        public async Task<bool> Exists(string email)
        {
            var result = await _context.Cart.Where(x => x.UserEmail == email).FirstOrDefaultAsync();

            return result != null ? true : false;
        }

        /// <summary>
        /// Update the total price of the current cart
        /// </summary>
        /// <param name="productId">Specified Id of the product</param>
        /// <param name="cart">Specified cart to update</param>
        /// <param name="newQty">The count of a specified product</param>
        /// <param name="oldQty">The old count of a cart item</param>
        /// <returns>A decimal of the cart total</returns>
        public async Task<decimal> UpdateTotal(int productId, Cart cart, int newQty, int oldQty)
        {
            var product = await _context.Products.FindAsync(productId);
            decimal oldTotal = oldQty * product.Price;
            decimal newTotal = (newQty * product.Price) - oldTotal;
            cart.Total += newTotal;
            await _context.SaveChangesAsync();
            return cart.Total;
        }

        /// <summary>
        /// Update the total price of the current cart
        /// </summary>
        /// <param name="productId">Specified Id of the product</param>
        /// <param name="cart">Specified cart to update</param>
        /// <returns>A decimal of the cart total</returns>
        public async Task<decimal> UpdateTotal(int productId, Cart cart)
        {
            var product = await _context.Products.FindAsync(productId);
            cart.Total += product.Price;
            await _context.SaveChangesAsync();
            return cart.Total;
        }
    }
}