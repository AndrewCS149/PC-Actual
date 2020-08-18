using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ECommerce.Models
{
    public class SendGrid
    {
        public SendGridMessage Message { get; set; }
        public EmailAddress Recipient { get; set; }

        public SendGrid(SendGridMessage msg, EmailAddress rec)
        {
            Message = msg;
            Recipient = rec;
        }

        public static void SendEmail(SendGridMessage msg, EmailAddress recipient)
        {
            msg.SetFrom(new EmailAddress("Admin@pcActual.com"));
            msg.AddTo(recipient);
            msg.SetSubject("Thank you note");
            msg.AddContent(MimeType.Text, "Thank you for registering!");
        }
    }
}