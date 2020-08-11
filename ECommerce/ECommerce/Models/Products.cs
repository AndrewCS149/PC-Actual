using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class Products
    {
        public string Name { get; set; }
        public char MFR { get; set; }
        public char Type { get; set; }
        public int Calories { get; set; }
        public int Protein { get; set; }
        public int Fat { get; set; }
        public int Sodium { get; set; }
        public int Carbo { get; set; }
        public int Sugars { get; set; }
        public int Potassium { get; set; }
        public int Vitamins { get; set; }
        public int Shelf { get; set; }
        public decimal Weight { get; set; }
        public decimal Cups { get; set; }
        public decimal Rating { get; set; }
    }
}