using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.Interfaces
{
    public interface ICartItems
    {
        Task<List<CartItem>> GetCartItems(int id);

        Task AddToCart(int cartId, int productId);

        //Task AddToCart(Cart cart, Products product);
    }
}