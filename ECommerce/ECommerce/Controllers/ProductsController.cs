using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32.SafeHandles;

namespace ECommerce.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            List<string> list = new List<string>();
            string[] strArr = new string[5];
            using (var reader = new StreamReader(@"wwwroot\cereal.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    list.Add(line);
                    strArr[0] = line;
                }
            }

            Products products = new Products()
            {
                Name = strArr[0]
            };

            return View(products);
        }

        public IActionResult Details()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Products products)
        {
            return RedirectToAction("Products", new { products.Name, products.Calories, products.Protein, products.Fat, products.Carbo });
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