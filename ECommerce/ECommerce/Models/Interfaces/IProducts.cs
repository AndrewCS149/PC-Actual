using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.Interfaces
{
    public interface IProducts
    {
        /// <summary>
        /// Creates a new product
        /// </summary>
        /// <param name="product">Product information for creation </param>
        /// <returns>Successful result of product creation</returns>
        Task<Products> Create(Products product);

        /// <summary>
        /// Get a list of all products in the database
        /// </summary>
        /// <returns>Successful result with list of products</returns>
        List<Products> GetProducts();

        /// <summary>
        /// Get a specific character in the database by product name
        /// </summary>
        /// <param name="product">Name of product to search for</param>
        /// <returns>Successful result of specified product</returns>
        Task<Products> GetProduct(Products product);

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="product">Product to be deleted</param>
        /// <returns>Task of completion for product deletion</returns>
        Task<Products> Delete(Products product);
    }
}