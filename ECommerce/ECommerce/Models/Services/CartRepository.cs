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

        public async Task AddToCart(int id)
        {
            var product = await _context.Products.SingleOrDefaultAsync(x => x.Id == id);

            //var product = await _context.

            //if (product == null)
            //{
            //    product = new Cart
            //    {
            //        ProductId = id,
            //        DateAdded = DateTime.Now,
            //        Quantity = 1
            //    }
            //}
        }
    }
}