using ECommerce.Models.Interfaces;
using ECommerce.Pages.Account;
using ECommerce.Pages.Checkout;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.Services
{
    public class EmailRepository : IEmail
    {
        private readonly IConfiguration _config;
        public IWebHostEnvironment WebHostEnvironment { get; }

        public EmailRepository(IConfiguration config, IWebHostEnvironment webHostEnvironment)
        {
            _config = config;
            WebHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// Emails a welcome message to a newly registered user
        /// </summary>
        /// <param name="input">Users information</param>
        /// <returns>Successful completion of task</returns>
        public async Task Email(RegisterModel.RegisterViewModel input)
        {
            var apiKey = WebHostEnvironment.IsDevelopment()
                ? _config["SENDGRID_APIKEY"]
                : Environment.GetEnvironmentVariable("SENDGRID_APIKEY");
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("Admin@pcAcutal.com"),
                Subject = "Welcome",
                HtmlContent = "<p>Thank you for registering with us! We are excited to help" +
                " build your most powerful gaming PC yet.<p>",
            };
            msg.AddTo(input.Email);
            await client.SendEmailAsync(msg);
        }

        /// <summary>
        /// Emails a receipt to a customer
        /// </summary>
        /// <param name="input">Users information</param>
        /// <returns>Successful completion of task</returns>
        public async Task SummaryEmail(Order input)
        {
            var apiKey = _config.GetSection("SENDGRID_APIKEY").Value;
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("Admin@pcAcutal.com"),
                Subject = "Your Order Reciept",
                HtmlContent = "<p>Thank you for your purchase. We expect you to receive your items within 3-5 business days. Please recommend us to your friends and family!.<p>",
            };
            msg.AddTo(input.Email);
            await client.SendEmailAsync(msg);
        }
    }
}