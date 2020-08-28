using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ECommerce.Models;
using ECommerce.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce.Pages.Account
{
    public class ProfilePageModel : PageModel, ISearchTerm
    {
        public string Term { get; set; }
        private readonly UserManager<AppUsers> _userManager;
        private readonly SignInManager<AppUsers> _signInManager;

        [BindProperty]
        public AppUsers AppUsers { get; set; }

        public ProfilePageModel(UserManager<AppUsers> userManager, SignInManager<AppUsers> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnGet()
        {
            AppUsers = await _userManager.GetUserAsync(User);
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            // remove user claims
            var user = await _userManager.GetUserAsync(User);
            var currentClaims = await _userManager.GetClaimsAsync(user);
            var removeResult = await _userManager.RemoveClaimsAsync(user, currentClaims);
            if (removeResult.Succeeded)
            {
                // update appuser info
                user.FirstName = AppUsers.FirstName;
                user.LastName = AppUsers.LastName;
                user.Email = AppUsers.Email;
                user.Address = AppUsers.Address;
                user.City = AppUsers.City;
                user.State = AppUsers.State;
                user.Zip = AppUsers.Zip;

                // update user claims
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim("Email", AppUsers.Email));
                claims.Add(new Claim("FirstName", AppUsers.FirstName));
                claims.Add(new Claim("LastName", AppUsers.LastName));

                var addClaimsResult = await _userManager.AddClaimsAsync(user, claims);
                if (addClaimsResult.Succeeded)
                {
                    var updateResult = await _userManager.UpdateAsync(user);
                    if (updateResult.Succeeded)
                    {
                        // refresh user (to update the claims)
                        await _signInManager.RefreshSignInAsync(user);
                        return RedirectToPage("/Account/ProfilePage");
                    }
                }
            }
            return Page();
        }
    }
}