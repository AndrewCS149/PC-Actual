using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class Order
    {
        [BindProperty]
        public int Id { get; set; }

        //public int CartId { get; set; }

        [Required]
        [BindProperty]
        public string FirstName { get; set; }

        [Required]
        [BindProperty]
        public string LastName { get; set; }

        [Required]
        [BindProperty]
        public string Address { get; set; }

        [Required]
        [BindProperty]
        public string City { get; set; }

        [Required]
        [BindProperty]
        public string Zip { get; set; }

        [Required]
        [BindProperty]
        public string State { get; set; }

        [Required]
        [BindProperty]
        public string Email { get; set; }

        [Required]
        [BindProperty]
        public string PhoneNumber { get; set; }

        public DateTime OrderDate { get; set; }

        [BindProperty]
        public Cart Cart { get; set; }
    }
}