using dotnetTest.Repository;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace dotnetTest.Controllers
{
    [Route("api/[controller]")]
    public class MonstersController : Controller
    {
        private IMonsterRepository monstersRepository;

        public MonstersController(IMonsterRepository monstersRepository)
        {
            this.monstersRepository = monstersRepository;
        }

        [HttpGet]
        public virtual IActionResult Get()
        {
            return this.Ok(monstersRepository.All());
        }

        //TODO: implement MailKit to send a test mail
        [HttpGet]
        [Route("email")]
        public IActionResult SendEmail()
        {
            try
            {
                string FromAddress = "origin address";
                string FromAddressTitle = "Nicolas Serrano";
                string ToAddress = "destination address";
                string ToAddressTitle = "Convidad Account";
                string Subject = "This is a test mail sent using net core and MailKit";
                string BodyContent = "ASP.NET Core was previously called ASP.NET 5. It was renamed in January 2016. It supports cross-platform frameworks ( Windows, Linux, Mac ) for building modern cloud-based internet-connected applications like IOT, web apps, and mobile back-end.";

                string SmtpServer = "smtp.gmail.com";
                int SmtpPortNumber = 587;

                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress(FromAddressTitle, FromAddress));
                mimeMessage.To.Add(new MailboxAddress(ToAddressTitle, ToAddress));
                mimeMessage.Subject = Subject;
                mimeMessage.Body = new TextPart("plain")
                {
                    Text = BodyContent
                };

                using (var client = new SmtpClient())
                {
                    client.Connect(SmtpServer, SmtpPortNumber, false);
                    client.Authenticate("your email", "your password");
                    client.Send(mimeMessage);
                    Console.WriteLine("mail has been sent");
                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {

                return this.NotFound();
            }

            return this.Ok();
        }
    }
}
