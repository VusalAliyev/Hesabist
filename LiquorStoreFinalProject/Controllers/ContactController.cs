using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace LiquorStoreFinalProject.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SendEmail(string name, string email, string subject, string message)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("vusalia@code.edu.az", "Vusalcode278!"),
                EnableSsl = true,
            };
            var mailMessage = new MailMessage
            {
                From = new MailAddress("vusalia@code.edu.az"),
                Subject = subject,
                Body = $"Name: {name}\nEmail: {email}\nMessage: {message}",
                IsBodyHtml = false,
            };

            mailMessage.To.Add("vusalaliev02@gmail.com");

            await smtpClient.SendMailAsync(mailMessage);

            return RedirectToAction("Index", "Home");
        }
    }
}
