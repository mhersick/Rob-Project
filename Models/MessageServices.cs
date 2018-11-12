using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using E3DBPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;



namespace E3DBPI.Models
{
    public class MessageServices
    {
        public async static Task SendEmailAsync(String Email, string subject, string message)
        {
        try
            {
                var _email = ConfigurationManager.AppSettings["e3EmailUser"];               // get email User from web.config
                var _epass = ConfigurationManager.AppSettings["e3EmailPassword"];           // get email pw from web.config
                var _dispName = "Design Build PlanIt";                                                 // Display name in receiver's mailbox
                MailMessage ThisMessage = new MailMessage();                                // system.net.mail namespace - SmtpClient class
                ThisMessage.To.Add(Email);                                                  // The email address the message is going to (passed)
                ThisMessage.From = new MailAddress(_email, _dispName);                      // The default email sender address from above
                ThisMessage.Subject = subject;                                              // The Subject variable from above
                ThisMessage.Body = message;                                                 // bring in the email body content. Unused
                ThisMessage.IsBodyHtml = true;                                              // format the email body as html

                using (SmtpClient smtp = new SmtpClient())                                  // set up and use SmtpClient to send the emal
                {
                    smtp.EnableSsl = true;                                                 // Turn on/off SSL for outbound email.  Requires address port change.  TURN ON WHEN LIVE!!
                    smtp.Host = "smtp.zoho.com";                                             // SMTP Server Name - Zoho
                    smtp.Port = 587;                                                       // Port number, zoho, with SSL
                    smtp.UseDefaultCredentials = false;                                     // Turn off default credentials (anyone can send an email)
                    smtp.Credentials = new NetworkCredential(_email, _epass);               // set the email address and password
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;                       // set the delivery method (via network)
                    smtp.SendCompleted += (s, w) => { smtp.Dispose(); };                    // quit message to client, end TCP connection and release SmtpClient resources
                    await smtp.SendMailAsync(ThisMessage);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }


    }
}