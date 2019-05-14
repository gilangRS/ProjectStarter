using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common
{
    public class Common 
    {
        public ResultStatus composeEmail(string from, List<string> to, string Body)
        {
            ResultStatus rs = new ResultStatus();
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new System.Net.Mail.MailAddress(from);

                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(from, "metalmorph")

                };

                smtp.Host = "smtp.gmail.com";

                smtp.EnableSsl = true;

                //recipient address
                foreach (string o in to)
                {
                    mail.To.Add(new MailAddress(o));
                }


                //Formatted mail body
                mail.IsBodyHtml = true;
                string st = Body.ToString();

                mail.Body = st;
                smtp.Send(mail);

                rs.SetSuccess("Reset password link has been sent!");
            }
            catch (Exception e)
            {
                rs.SetUnsuccess(e.Message);
            }
            return rs;
        }
    }
}
