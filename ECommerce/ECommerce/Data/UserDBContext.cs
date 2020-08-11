using ECommerce.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class UserDBContext : IdentityDbContext<AppUsers>
    {
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {
        }
    }
}