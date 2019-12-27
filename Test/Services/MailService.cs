using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Test.Services
{
    public class MailService
    {

        public string sendMail(string name,string email,string subject,string body,IConfiguration configuration)
        {
            try
            {
                var credential = new NetworkCredential(configuration["Mail:userName"],configuration["Mail:password"]);
                var mail = new MailMessage
                {
                    From = new MailAddress(email),
                    Subject=subject+"-- Form Sysgot website",
                    IsBodyHtml=true,
                    Body="<h2> Sender Mail :<span style='color:blue'>"+email+ "</span></h><br/>" + "<p>"+body+"</p>"
                    
                };
                mail.To.Add(new MailAddress("m.atef9990@gmail.com"));
                mail.CC.Add(new MailAddress("m.atef@elzomororda.com"));
                mail.CC.Add(new MailAddress("alaa.pentester@gmail.com"));
                var client = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = true,
                    Credentials = credential

                };
                client.Send(mail);
                return "success";
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }
    }
}
