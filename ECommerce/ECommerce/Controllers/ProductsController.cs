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
        string path = Environment.CurrentDirectory;
        string newPath = Path.GetFullPath(Path.Combine(path, @"wwwroot\cereal.csv"));
        string[] myFile = File.ReadAllLines(newPath);
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(string name, int calories, int protein, int fat, int carbo )
        {
            Products products = new Products()
            {
                Name = name,
                Calories = calories,
                Protein = protein,
                Fat = fat,
                Carbo = carbo

            };
            return View(products);
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
            return RedirectToAction()
        }

        [HttpPost]
        public IActionResult GetProduct()
        {
            return CriticalHandleMinusOneIsInvalid;
        }
    }
}
