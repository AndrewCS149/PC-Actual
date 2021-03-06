﻿using System;
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
        /// Get a list of all products
        /// </summary>
        /// <returns>Successful result with list of products</returns>
        Task<List<Products>> GetProducts();

        /// <summary>
        /// Get a specific character in the database by product name
        /// </summary>
        /// <param name="id">Specified Id of product</param>
        /// <returns>Successful result of specified product</returns>
        Task<Products> GetProduct(int id);

        /// <summary>
        /// Update a given product in the database
        /// </summary>
        /// <param name="products">product information for update</param>
        /// <returns>Successful result of specified updated product</returns>
        Task<Products> Update(Products products);

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="id">Id of product to be deleted</param>
        /// <returns>Task of completion for product deletion</returns>
        Task Delete(int id);
    }
}