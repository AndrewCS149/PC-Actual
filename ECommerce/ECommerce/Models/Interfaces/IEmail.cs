using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ECommerce.Pages.Account.RegisterModel;

namespace ECommerce.Models.Interfaces
{
    public interface IEmail
    {
        /// <summary>
        /// Emails a welcome message to a newly registered user
        /// </summary>
        /// <param name="input">Users information</param>
        /// <returns>Successful completion of task</returns>
        Task Email(RegisterViewModel input);
    }
}