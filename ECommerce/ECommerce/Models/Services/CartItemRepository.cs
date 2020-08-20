using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.Services
{
    public class CartItemRepository
    {
        public int MyProperty { get; set; }

        public CartItemRepository()
        {
        }

        public async Task GetCartItems()
        {
        }

        public async Task AddToCart(int cartId, int productId)
        {
            CartItem cartItem = new CartItem()
            {
                CartId = cartId,
                ProductId = productId
            };

            cartItem.Cart.DateAdded = DateTime.Now;
        }
    }
}