using ECommerce.Models.Interfaces;
using ECommerce.Pages.Account;
using Microsoft.Extensions.Configuration;
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
        private IConfiguration _config;

        public EmailRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task Email(RegisterModel.RegisterViewModel input)
        {
            var apiKey = _config.GetSection("SENDGRID_APIKEY").Value;
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
    }
}