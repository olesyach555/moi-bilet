using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace УниверсальноеПриложение.Сервисы
{
    public class EmailVerificationService : IEmailVerificationService
    {
        private static readonly Dictionary<string, string> _pendingCodes = new Dictionary<string, string>();

        private readonly string _host;
        private readonly int _port;
        private readonly string _username;
        private readonly string _password;
        private readonly bool _enableSsl;
        private readonly string _fromEmail;

        public EmailVerificationService()
        {
            _host = ConfigurationManager.AppSettings["SmtpHost"];
            _port = int.Parse(ConfigurationManager.AppSettings["SmtpPort"] ?? "587");
            _username = ConfigurationManager.AppSettings["SmtpUsername"];
            _password = ConfigurationManager.AppSettings["SmtpPassword"];
            _enableSsl = bool.Parse(ConfigurationManager.AppSettings["SmtpEnableSsl"] ?? "true");
            _fromEmail = ConfigurationManager.AppSettings["SmtpFromEmail"];
        }

        public string GenerateCode()
        {
            Random random = new Random();
            return random.Next(10000, 100000).ToString();
        }

        public async Task SendVerificationCodeAsync(string email, string code)
        {
            _pendingCodes[email] = code;

            using (var client = new SmtpClient(_host, _port))
            {
                client.Credentials = new NetworkCredential(_username, _password);
                client.EnableSsl = _enableSsl;

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_fromEmail),
                    Subject = "Код подтверждения",
                    Body = $"Ваш код подтверждения: {code}",
                    IsBodyHtml = false
                };
                mailMessage.To.Add(email);

                await client.SendMailAsync(mailMessage);
            }
        }

        public bool VerifyCode(string email, string enteredCode)
        {
            if (_pendingCodes.TryGetValue(email, out string storedCode))
            {
                return storedCode == enteredCode;
            }
            return false;
        }

        public void RemoveCode(string email)
        {
            if (_pendingCodes.ContainsKey(email))
            {
                _pendingCodes.Remove(email);
            }
        }
    }
}
