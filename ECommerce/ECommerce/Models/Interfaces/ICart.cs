using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.Interfaces
{
    public interface ICart
    {
        //Task<List<Products>> GetCartItems();

        //Task AddToCart(int cartId, int productId);
        Task<Cart> GetCart(string email);

        Task<Cart> Create(string email);
    }
}