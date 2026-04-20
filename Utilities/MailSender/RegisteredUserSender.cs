using Shared;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Utilities.MailSender
{
    public class RegisteredUserSender
    {
        public static async Task<string> SendMail(CustomerDataDto custData) 
        {
            string htmlTemplate = @"
                <html>
                <body >
                    <h2>Congratulations you are registered as a memeber!</h2>
                    <p>Dear <b>{{Name}}</b>,</p>
                    <p>Thank you for being out member.</p>

                    <h3>Member Details:</h3>
                    <ul>
                        <li><b>Member Email:</b> {{Memeber Email}}</li>
                        <li><b>Phone Number:</b> {{PhoneNumber}}</li>
                    </ul>
                    <br/>
                    <p>Regards,<br/>Team</p>
                </body>
                </html>";
            string finalBody = htmlTemplate
              .Replace("{{Name}}", custData.Name)
              .Replace("{{Memeber Email}}", custData.Email)
              .Replace("{{PhoneNumber}}", custData.Phone);
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("anubhav.step2gen@gmail.com");
                mail.To.Add(custData.Email);
                mail.Subject = "Registeration Successfull!";
                mail.Body = finalBody;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("anubhav.step2gen@gmail.com", "blzw knqs jpzs slqi");
                smtp.EnableSsl = true;

                await smtp.SendMailAsync(mail);

                return "Email sent successfully!" ;
            }
            catch (Exception ex)
            {
                return " Error: " + ex.Message;
            }
        }
    }
}
