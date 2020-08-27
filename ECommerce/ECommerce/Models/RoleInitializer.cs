using ECommerce.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class RoleInitializer
    {
        // Create a list of identity roles
        private static readonly List<IdentityRole> Roles = new List<IdentityRole>()
        {
            new IdentityRole{Name = AppRoles.Admin, NormalizedName = AppRoles.Admin.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString()},
            new IdentityRole{Name = AppRoles.User, NormalizedName = AppRoles.User.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString()},
        };

        public static async Task SeedData(IServiceProvider serviceProvider, UserManager<AppUsers> userManager, IConfiguration _config)
        {
            using (var dbContext = new UserDBContext(serviceProvider.GetRequiredService<DbContextOptions<UserDBContext>>()))
            {
                dbContext.Database.EnsureCreated();
                AddRoles(dbContext);
                await SeedUsers(userManager, _config);
            }
        }

        public static void AddRoles(UserDBContext dbContext)
        {
            if (dbContext.Roles.Any()) return;
            foreach (var role in Roles)
            {
                dbContext.Roles.Add(role);
                dbContext.SaveChanges();
            }
        }

        public static async Task SeedUsers(UserManager<AppUsers> userManager, IConfiguration _config)
        {
            if (userManager.FindByNameAsync(_config["AdminEmail"]).Result == null)
            {
                AppUsers user = new AppUsers()
                {
                    FirstName = "Admin",
                    LastName = _config["AdminEmail"],
                    UserName = _config["AdminEmail"],
                    Email = _config["AdminEmail"]
                };

                IdentityResult result = userManager.CreateAsync(user, _config["AdminPassword"]).Result;
                if (result.Succeeded)
                {
                    Claim claim = new Claim("Fullname", $"{user.FirstName} {user.LastName}");
                    Claim claim2 = new Claim("Email", user.Email);
                    var x = userManager.AddClaimAsync(user, claim2).Result;
                    var y = userManager.AddClaimAsync(user, claim).Result;
                    await userManager.AddToRoleAsync(user, AppRoles.Admin);
                }
            }
        }
    }
}