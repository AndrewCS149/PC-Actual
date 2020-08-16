using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class AppUsers : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public static class AppRoles
    {
        // Define the application's role names
        public const string Admin = "Admin";
        public const string User = "User";
    }
    
}