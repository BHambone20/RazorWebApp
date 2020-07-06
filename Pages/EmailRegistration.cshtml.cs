using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace RazorWebApp.Pages
{
    public class EmailRegistrationModel : PageModel
    {
        public void OnGet()
        {

        }
        public async Task OnPostAsync()
        {
            try
            {
                var emailAddress = Request.Form["emailaddress"];
                using (var smtp = new SmtpClient())
                {
                    smtp.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtp.PickupDirectoryLocation = @"c:\sql";
                    var message = new MailMessage
                    {
                        Body = "Thank you for registering your email information.",
                        Subject = "Registration Complete",
                        From = new MailAddress("BrianHammond@usf.edu")
                    };
                    message.To.Add(emailAddress);
                    await smtp.SendMailAsync(message);

                }
            }
            catch (Exception ex)
            {
                //ex.ToString;
            }
        }
    }
}