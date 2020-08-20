﻿using ECommerce.Data;
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
        public async Task<List<CartItem>> GetCartItems(int id)
        {
            List<CartItem> result = await _context.CartItem.Where(x => x.CartId == id).ToListAsync();

            return result;
        }

        // TODO: summary comment
        public async Task AddToCart(int cartId, int productId)
        {
            CartItem cartItem = new CartItem()
            {
                CartId = cartId,
                ProductId = productId
            };

            //cartItem.Cart.DateAdded = DateTime.Now;
            _context.Entry(cartItem).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        //public async Task AddToCart(Cart cart, Products product)
        //{
        //    CartItem cartItem = new CartItem()
        //    {
        //        CartId = cart.Id,
        //        ProductId = product.Id,
        //        Product = product
        //    };

        //    cartItem.Cart.DateAdded = DateTime.Now;
        //    _context.Entry(cartItem).State = EntityState.Added;
        //    await _context.SaveChangesAsync();
        //}
    }
}