using ECommerce.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.Services
{
    public class ProductsRepository : IProducts
    {
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

        // TODO: not working
        /// <summary>
        /// Get a specific character in the database by product name
        /// </summary>
        /// <param name="product">Name of product to search for</param>
        /// <returns>Successful result of specified product</returns>
        public Products GetProduct(string name)
        {
            List<Products> allProducts = GetProducts();

            Products product = new Products();
            foreach (var item in allProducts)
            {
                if (item.Name.ToLower() == name.ToLower())
                {
                    product.Name = "Andrew";
                    //product.Calories = item.Calories;
                    //product.Protein = item.Protein;
                    //product.Fat = item.Fat;
                    //product.Carbo = item.Carbo;
                }
            }
            return product;
        }

        /// <summary>
        /// Get a list of all products
        /// </summary>
        /// <returns>Successful result with list of products</returns>
        public List<Products> GetProducts()
        {
            List<Products> allProducts = new List<Products>();

            // read in data
            using (var reader = new StreamReader(@"wwwroot\cereal.csv"))
            {
                // skip first line (column header names)
                var line = reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    var values = line.Split(',');

                    allProducts.Add(new Cereal
                    {
                        Name = values[0],
                        Calories = values[3],
                        Protein = values[4],
                        Fat = values[5],
                        Carbo = values[8]
                    });
                }
            }
            return allProducts;
        }
    }
}