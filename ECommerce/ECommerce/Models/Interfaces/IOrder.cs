using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.Interfaces
{
    public interface IOrder
    {
        // TODO: summary comment
        Task<Order> Create(Order order);
    }
}