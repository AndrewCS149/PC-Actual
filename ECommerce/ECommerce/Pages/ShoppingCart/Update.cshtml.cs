using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models;
using ECommerce.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce.Pages.ShoppingCart
{
    public class UpdateModel : PageModel
    {
        private readonly ICartItems _cartItems;

        [BindProperty]
        public int ProductId { get; set; }
        [BindProperty]
        public int CartId { get; set; }
        [BindProperty]
        public int Count { get; set; }
        public UpdateModel(ICartItems cartItems)
        {
            _cartItems = cartItems;
        }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            await _cartItems.UpdateCartQty(Count, CartId, ProductId);
            return RedirectToPage("/ShoppingCart/Index");
        }
    }
}