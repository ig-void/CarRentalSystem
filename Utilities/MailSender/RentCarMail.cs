using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Utilities.MailSender
{
    public class RentCarMail
    {
        public static async Task<string> SentMail(MyRentalDetailsDto rentData)
        {
            string htmlTemplate = @"
                <html>
                <body >
                    <h2>Congratulations you have rented a car!</h2>
                    <p>Dear <b>{{Name}}</b>,</p>
                    <p>Thank you for renting a car.</p>

                    <h3>Rental Details:</h3>
                    <ul>
                        <li><b>Car name:</b> {{CarName}}</li>
                        <li><b>Car Model:</b> {{Model}}</li>
                        <li><b>Start Date:</b> {{StartDate}}</li>
                        <li><b>End Date:</b> {{EndDate}}</li>
                        <li><b>Total Price:</b> {{TotalPrice}}</li>
                    </ul>
                    <br/>
                    <p>Regards,<br/>Team</p>
                </body>
                </html>";
            string finalBody = htmlTemplate
              .Replace("{{Name}}", rentData.Name)
              .Replace("{{Model}}", rentData.CarName)
              .Replace("{{StartDate}}", rentData.StartDate.ToString())
              .Replace("{{EndDate}}", rentData.EndDate.ToString())
              .Replace("{{TotalPrice}}",rentData.TotalAmount.ToString()) ;

            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("anubhav.step2gen@gmail.com");
                mail.To.Add(rentData.Email);
                mail.Subject = "Registeration Successfull!";
                mail.Body = finalBody;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("anubhav.step2gen@gmail.com", "blzw knqs jpzs slqi");
                smtp.EnableSsl = true;

                await smtp.SendMailAsync(mail);

                return "Email sent successfully!";
            }
            catch (Exception ex)
            {
                return " Error: " + ex.Message;
            }
        }
    }
}
