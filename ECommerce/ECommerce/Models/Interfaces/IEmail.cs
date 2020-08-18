using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ECommerce.Pages.Account.RegisterModel;

namespace ECommerce.Models.Interfaces
{
    public interface IEmail
    {
        Task Email(RegisterViewModel input);
    }
}