using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ECommerce.Models;
using ECommerce.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace ECommerce.Pages.Account.Login
{
    public class LoginModel : PageModel, ISearchTerm
    {
        private readonly UserManager<AppUsers>_userManager;
        [BindProperty]
        public LoginViewModel Input { get; set; }

        public string Term { get; set; }

        private readonly SignInManager<AppUsers> _signInManager;

        public LoginModel(SignInManager<AppUsers> signInManager, UserManager<AppUsers> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, false, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(Input.Email);
                Claim claim = new Claim("Fullname", $"{user.FirstName} {user.LastName}");
                await _userManager.AddClaimAsync(user, claim);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Invalid username or password");
            }
            return Page();

        }

        public class LoginViewModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
    }
}