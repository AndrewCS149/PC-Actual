using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.Interfaces
{
    public interface IProducts
    {
        Task<Products> Create(Products product);
        Task<List<Products>> GetProducts();
        Task<Products> GetProduct(Products product);
        Task<Products> Delete(Products product);
    }
}
