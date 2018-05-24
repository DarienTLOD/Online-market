using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using OnlineMarket.Contract.ContractModels;
using OnlineMarket.Contract.Interfaces;

namespace OnlineMarket.BusinessLogic.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailCredentials _options;
        private readonly SmtpSettings _settings;
        public EmailSender(IOptions<EmailCredentials> options, IOptions<SmtpSettings> settings)
        {
            _settings = settings.Value;
            _options = options.Value;
        }

        public void SendEmailAsync(string email, string subject, string message)
        {
            Execute(email, subject, message);
        }

        private void Execute(string email, string subject, string message)
        {
            var client = new SmtpClient(_settings.Host, _settings.Port)
            {
                UseDefaultCredentials = _settings.UseDefaultCredentials,
                Credentials = new NetworkCredential(_options.Email, _options.Password),
                EnableSsl = _settings.EnableSsl
            };

            var mailMessage = new MailMessage { From = new MailAddress(_options.Email) };
            mailMessage.To.Add(email);
            mailMessage.Body = message;
            mailMessage.Subject = subject;
            client.SendMailAsync(mailMessage);
        }
    }
}
