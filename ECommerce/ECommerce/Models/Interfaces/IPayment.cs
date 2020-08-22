using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.Interfaces
{
    public interface IPayment
    {
        /// <summary>
        /// Runs the credit card transaction request
        /// </summary>
        /// <returns>Empty string</returns>
        string Run();
    }
}