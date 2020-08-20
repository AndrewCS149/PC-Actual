using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public DateTime DateAdded { get; set; }
        public List<CartItem> CartItem { get; set; }
    }
}