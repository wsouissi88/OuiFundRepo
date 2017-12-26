using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace OuiFund.Common
{
    public class EmailBusiness
    {
        public MailAddress to { get; set; }
        public MailAddress from { get; set; }
        public string sub { get; set; }
        public string body { get; set; }
        public string Send()
        {
            string feedback = "";
            EmailBusiness me = new EmailBusiness();

            var m = new MailMessage()
            {

                Subject = sub,
                Body = body,
                IsBodyHtml = true
            };
            to = new MailAddress(to.ToString());
            m.To.Add(to);
            m.From = new MailAddress(from.ToString());
            m.Sender = to;


            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            MailAddress adresseMailEnvoyeur = new MailAddress("wsouissi88@gmail.com");
            MailAddress Receveur = new MailAddress("wa.souissi@gmail.com");
            MailMessage ConfigMess = new MailMessage(adresseMailEnvoyeur, Receveur);
            ConfigMess.Body = "Le contenu du mail";
            ConfigMess.Subject = "Sujet";
            ConfigMess.IsBodyHtml = true; // si tu veux activer le html dans ton body
            ConfigMess.Body = body;
            NetworkCredential user = new NetworkCredential("wsouissi88@gmail.com", "Essetoile880*");
            client.Credentials = user;
            client.Send(ConfigMess);

            //SmtpClient smtp = new SmtpClient
            //{
            //    Host = "smtp.gmail.com",
            //    Port = 587,
            //    UseDefaultCredentials = true,
            //    Credentials = new NetworkCredential("wsouissi88@gmail.com", "Essetoile880*"),
            //    EnableSsl = true
            //};

            try
            {
                //smtp.Send(m);
                feedback = "Message sent to insurance";
            }
            catch (Exception e)
            {
                feedback = "Message not sent retry" + e.Message;
            }
            return feedback;
        }

    }

}
