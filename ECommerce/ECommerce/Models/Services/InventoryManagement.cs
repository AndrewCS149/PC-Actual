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
        /// <param name="product">Product to be deleted</param>
        /// <returns>Task of completion for product deletion</returns>
        public Task<Products> Delete(Products product)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates an existing product
        /// </summary>
        /// <param name="product">Product to be updated</param>
        /// <returns>Successful result of product update</returns>
        public Task<Products> Update(Products product)
        {
            throw new NotImplementedException();
        }

        // TODO: not working
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

            //Products product = new Products();
            //foreach (var item in allProducts)
            //{
            //    if (item.Id == id)
            //    {
            //        product.Name = "Andrew";
            //        //product.Calories = item.Calories;
            //        //product.Protein = item.Protein;
            //        //product.Fat = item.Fat;
            //        //product.Carbo = item.Carbo;
            //    }
            //}
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