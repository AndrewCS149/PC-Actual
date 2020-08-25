using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.Interfaces
{
    public interface ICart
    {
        /// <summary>
        /// Gets a specified cart from the database
        /// </summary>
        /// <param name="email">Email of the cart to get</param>
        /// <returns>Specified cart</returns>
        Task<Cart> GetCart(string email);

        /// <summary>
        /// Adds a new Cart to the database
        /// </summary>
        /// <param name="email">The email to attach the cart to</param>
        /// <returns>Newly created cart</returns>
        Task<Cart> Create(string email);

        /// <summary>
        /// Updates a specified cart in the database
        /// </summary>
        /// <param name="cart">Specified cart</param>
        /// <returns>The updated cart</returns>
        Task<Cart> Update(Cart cart);

        /// <summary>
        /// Checks to see if a cart exists in the database
        /// </summary>
        /// <param name="email">The email of the cart to check for</param>
        /// <returns>A boolean determining if the cart exists or not</returns>
        Task<bool> Exists(string email);

        /// <summary>
        /// Update the total price of the current cart
        /// </summary>
        /// <param name="productId">Specified Id of the product</param>
        /// <param name="cart">Specified cart to update</param>
        /// <param name="newCount">The new count of a cart item</param>
        /// <param name="oldCount">The old count of a cart item</param>
        /// <returns>A decimal of the cart total</returns>
        Task<decimal> UpdateTotal(int productId, Cart cart, int newCount, int oldCount);

        /// <summary>
        /// Update the total price of the current cart
        /// </summary>
        /// <param name="productId">Specified Id of the product</param>
        /// <param name="cart">Specified cart to update</param>
        /// <returns>A decimal of the cart total</returns>
        Task<decimal> UpdateTotal(int productId, Cart cart);
    }
}