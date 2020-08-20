using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.Interfaces
{
    public interface ICartItems
    {
        // TODO: summary comment
        Task<List<CartItem>> GetCartItems(int id);

        // TODO: summary comment
        Task AddToCart(int cartId, int productId);

        // TODO: summary comment
        Task<CartItem> GetCartItem(int cartId, int productId);

        // TODO: summary comment
        Task UpdateQty(int cartId, int productId);
    }
}