using ECommerce.Data;
using ECommerce.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.Services
{
    public class InventoryManagement : IProducts
    {
        private StoreDbContext _context;

        public InventoryManagement(StoreDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new product
        /// </summary>
        /// <param name="product">Product information for creation </param>
        /// <returns>Successful result of product creation</returns>
        public Task<Products> Create(Products product)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="id">Id of Product to be deleted</param>
        /// <returns>Task of completion for product deletion</returns>
        public async Task Delete(int id)
        {
            Products product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Entry(product).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Updates an existing product
        /// </summary>
        /// <param name="product">Product to be updated</param>
        /// <returns>Successful result of product update</returns>
        public async Task<Products> Update(Products product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return product;
        }

        /// <summary>
        /// Get a specific character in the database by product name
        /// </summary>
        /// <param name="product">Name of product to search for</param>
        /// <returns>Successful result of specified product</returns>
        public async Task<Products> GetProduct(int id)
        {
            var result = await _context.Products
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            return result;
        }

        /// <summary>
        /// Get a list of all products
        /// </summary>
        /// <returns>Successful result with list of products</returns>
        public async Task<List<Products>> GetProducts()
        {
            List<Products> result = await _context.Products.ToListAsync();

            return result;
        }
    }
}