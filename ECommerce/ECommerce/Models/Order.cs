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
        public int Id { get; set; }

        //public int CartId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Zip { get; set; }

        public string State { get; set; }

        public string Email { get; set; }

        public DateTime OrderDate { get; set; }

        public Cart Cart { get; set; }
    }
}