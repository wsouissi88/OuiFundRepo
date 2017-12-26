using System;
using OuiFund.Domain.Model;
using OuiFund.Services.IServices;
using System.Net.Mail;
using System.Net;
using OuiFund.Common;

namespace OuiFund.Services.Services
{
    public class EmailService : IEmailService
    {
        public string SendAcountCredentiel(User user)
        {
            var emailBusiness = new EmailBusiness
            {
                sub = "test",
                body = "test",
                from = new MailAddress("wsouissi88@gmail.com"),
                to = new MailAddress("wa.souissi@gmail.com")
            };
            return emailBusiness.Send();
        }
    }
}
