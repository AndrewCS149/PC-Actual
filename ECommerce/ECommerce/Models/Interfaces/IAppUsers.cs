using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.Interfaces
{
    public interface IAppUsers
    {
        Task<AppUsers> GetUser(string email);
        Task<AppUsers> Update(AppUsers user);
    }
}
