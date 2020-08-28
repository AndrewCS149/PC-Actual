using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.Interfaces
{
    public interface ICartItems
    {
        /// <summary>
        /// Retrieves a specified item from a specified cart
        /// </summary>
        /// <param name="cartId">Id of cart</param>
        /// <param name="productId">Id of product</param>
        /// <returns>Cart Item from specified cart</returns>
        Task<CartItem> GetCartItem(int cartId, int productId);

        /// <summary>
        /// Retrieves all the items within a specified cart
        /// </summary>
        /// <param name="id">Id of cart</param>
        /// <returns>All items within the specified cart</returns>
        Task<List<CartItem>> GetCartItems(int id);

        /// <summary>
        /// Updates the quantity of specified item in specified cart
        /// </summary>
        /// <param name="cartId">Id of cart</param>
        /// <param name="productId">Id of product</param>
        /// <returns>Successful completion of task</returns>
        Task AddToCart(int cartId, int productId);

        /// <summary>
        /// Adds a specified item to a specified cart
        /// </summary>
        /// <param name="cartId">Id of cart</param>
        /// <param name="productId">Id of product</param>
        /// <returns>Successful completion of task</returns>
        Task UpdateQty(int cartId, int productId);

        /// <summary>
        /// Adds a specified item to a populated cart
        /// </summary>
        /// <param name="cartId">Id of cart</param>
        /// <param name="productId">Id of product</param>
        /// <returns>Successful completion of task</returns>
        Task UpdateCartQty(int count, int cartId, int productId);

        /// <summary>
        /// Delete a cart item
        /// </summary>
        /// <param name="cartItem">cartItem to be deleted</param>
        /// <returns>Successful completion of task</returns>
        Task Delete(CartItem cartItem);

        /// <summary>
        /// Decrements the quantity by one of a specific cart item
        /// </summary>
        /// <param name="cartId">Specified cart to update</param>
        /// <param name="productId">Specified product of the cart to update</param>
        /// <returns>Successful completion of task</returns>
        Task DecrementQty(int cartId, int productId);

        /// <summary>
        /// Increments the quantity by one of a specific cart item
        /// </summary>
        /// <param name="cartId">Specified cart to update</param>
        /// <param name="productId">Specified product of the cart to update</param>
        /// <returns>Successful completion of task</returns>
        Task IncrementQty(int cartId, int productId);
    }
}