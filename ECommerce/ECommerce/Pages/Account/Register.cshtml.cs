using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private UserManager<AppUsers> _userManager;

        public RegisterModel(UserManager<AppUsers> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public RegisterViewModel Input { get; set; }

        // reserved method name for the loading of the page
        public void OnGet()
        {
        }

        // another reserved method name for the post of the page
        public void OnPost()
        {
        }

        public class RegisterViewModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
            public string ConfirmPassword { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}