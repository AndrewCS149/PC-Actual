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

        /// <summary>
        /// Get a specific character in the database by product name
        /// </summary>
        /// <param name="product">Name of product to search for</param>
        /// <returns>Successful result of specified product</returns>
        public Task<Products> GetProduct(Products product)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get a list of all products
        /// </summary>
        /// <returns>Successful result with list of products</returns>
        public List<Products> GetProducts()
        {
            // declare empty list filled with dictionaries that will hold the
            // CSV data
            List<Dictionary<string, string>> data = new List<Dictionary<string, string>>();

            // read in data
            using (var reader = new StreamReader(@"wwwroot\cereal.csv"))
            {
                // skip first line (column header names)
                var line = reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    var values = line.Split(',');

                    // store key / value pairs with columns names / values
                    Dictionary<string, string> dataList = new Dictionary<string, string>();
                    dataList.Add("name", values[0]);
                    dataList.Add("calories", values[3]);
                    dataList.Add("protein", values[4]);
                    dataList.Add("fat", values[5]);
                    dataList.Add("carbo", values[8]);

                    data.Add(dataList);
                }
            }

            // turn values into product objects and store in list
            List<Products> allProducts = new List<Products>();
            foreach (var item in data)
            {
                Products product = new Products()
                {
                    Name = item["name"],
                    Calories = item["calories"],
                    Protein = item["protein"],
                    Fat = item["fat"],
                    Carbo = item["carbo"]
                };
                allProducts.Add(product);
            }

            return allProducts;
        }
    }
}