using ECommerce.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.Services
{
    public class ProductsRepository : IProducts
    {
        public Task<Products> Create(Products product)
        {
            throw new NotImplementedException();
        }

        public Task<Products> Delete(Products product)
        {
            throw new NotImplementedException();
        }

        public Task<Products> GetProduct(Products product)
        {
            throw new NotImplementedException();
        }

        public Task<List<Products>> GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
