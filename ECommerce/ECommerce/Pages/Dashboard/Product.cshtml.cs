using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce.Pages.Dashboard
{
    public class ProductModel : PageModel, ISearchTerm
    {
        public string Term { get; set; }
        private IImage _image;

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }

        public ProductModel(IImage image)
        {
            _image = image;
        }

        public void OnGet()
        {
        }

        public async Task OnPostAsync()
        {
            // Goal: send the uploaded image to blob
            // convert image to a stream
            if (Image != null)
            {
                using (var stream = new MemoryStream())
                {
                    await Image.CopyToAsync(stream);
                    await _image.UploadFile("products", Image.FileName, stream);
                }
            }
        }
    }
}