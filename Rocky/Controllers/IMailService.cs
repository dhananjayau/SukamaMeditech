using Microsoft.Extensions.Options;
using Rocky.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Rocky.Controllers
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }

    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(mailRequest.Email);
            mail.From = new MailAddress("info@sukamameditech.in");
            mail.Subject = (mailRequest.subject ?? string.Empty) + "Sukama Meditech";
           
            
            
            string FilePath = Directory.GetCurrentDirectory() + "\\EmailTemplate.html";
            string EmailTemplateText = File.ReadAllText(FilePath);
            EmailTemplateText = string.Format(EmailTemplateText, mailRequest.Name, mailRequest.Phone, DateTime.Now.Date.ToShortDateString(), mailRequest.service, mailRequest.form_message);

            string Body = EmailTemplateText;
            mail.Body = Body;
            mail.IsBodyHtml = true;

            SmtpClient smtp = new();
            smtp.Host = _mailSettings.Host;
            smtp.Port = _mailSettings.Port;
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new System.Net.NetworkCredential(_mailSettings.Mail, _mailSettings.Password); // Enter seders User name and password       
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(mail);
        }
    }

}
