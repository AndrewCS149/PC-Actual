using ECommerce.Data;
using ECommerce.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace ECommerce.Models.Services
{
    public class AppUserRepository : IAppUsers
    {
        private UserDBContext _context;
        public AppUserRepository(UserDBContext context)
        {
            _context = context;
        }

        public async Task<AppUsers> GetUser(string email)
        {
                var result = await _context.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
                return result;
        }

        public async Task<AppUsers> Update(AppUsers user)
        {
            var result = await _context.Users.Where(x => x.Email == user.Email).FirstOrDefaultAsync();
            result = user;
            _context.Entry(result).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return result;
        }
    }
}
