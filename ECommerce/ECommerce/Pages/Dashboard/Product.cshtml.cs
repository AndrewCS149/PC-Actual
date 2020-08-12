using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce.Pages.Dashboard
{
    public class ProductModel : PageModel
    {
        private IImage _image;

        public ProductModel(IImage image)
        {
            _image = image;
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
        }
    }
}