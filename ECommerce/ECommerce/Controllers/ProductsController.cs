using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32.SafeHandles;
using ECommerce.Models.Interfaces;
using ECommerce.Models.ViewModels;

namespace ECommerce.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProducts _products;

        public ProductsController(IProducts products)
        {
            _products = products;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Cereal> products = _products.GetProducts().Cast<Cereal>().ToList();

            ProductsVM vm = new ProductsVM
            {
                Products = products,
                Term = ""
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(string term)
        {
            List<Cereal> products = _products.GetProducts().Cast<Cereal>().ToList();
            var results = products.Where(x => x.Name.ToUpper().Contains(term.ToUpper()));

            ProductsVM vm = new ProductsVM
            {
                Products = results.Cast<Cereal>().ToList(),
                Term = term
            };

            return View(vm);
        }

        // TODO: not working
        public IActionResult Details(string name)
        {
            Products product = _products.GetProduct(name);
            return View(product);
        }

        [HttpPost]
        public IActionResult GetProducts()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetProduct()
        {
            return View();
        }
    }
}