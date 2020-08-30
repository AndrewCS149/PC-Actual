using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.Interfaces
{
    public interface IOrder
    {
        /// <summary>
        /// Adds a new order to the database
        /// </summary>
        /// <param name="input">The information for the new order</param>
        /// <returns>The new order</returns>
        Task<Order> Create(Order input);

        /// <summary>
        /// Gets a specified order from the database
        /// </summary>
        /// <param name="userId">The GUID of the order to retrieve</param>
        /// <returns>An order object</returns>
        Task<Order> GetOrder(string userId);

        /// <summary>
        /// Gets all orders of a specified user
        /// </summary>
        /// <param name="userId">The GUID of the appUsers orders to retrieve</param>
        /// <returns>List of all users orders</returns>
        Task<List<Order>> GetOrders(string userId);

        Task<Order> GetOrder(string userId, int orderId);
    }
}