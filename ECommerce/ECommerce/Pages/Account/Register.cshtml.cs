using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace ECommerce.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private UserManager<AppUsers> _userManager;
        private readonly IConfiguration _config;

        public RegisterModel(UserManager<AppUsers> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _config = configuration;
        }

        [BindProperty]
        public RegisterViewModel Input { get; set; }

        // reserved method name for the loading of this page
        public void OnGet()
        {
        }

        // another reserved method name for the post of the page
        public async Task<IActionResult> OnPost(RegisterViewModel input)
        {
            AppUsers user = new AppUsers()
            { 
                UserName = input.Email,
                FirstName = input.FirstName,
                LastName = input.LastName,
                Email = input.Email
            };

            var result = await _userManager.CreateAsync(user, input.Password);

            return RedirectToAction("Index", "Home");


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