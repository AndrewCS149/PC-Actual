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

namespace ECommerce.Pages.Account.Login
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<AppUsers> _signInManager;
        public LoginModel(SignInManager<AppUsers> signInManager)
        {
            _signInManager = signInManager;
        }
        [BindProperty]
        public LoginViewModel Input { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, false, false);

            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Home");                
            }
            return Page();
        }

        public class LoginViewModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}