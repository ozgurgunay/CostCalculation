using CostCalculation.OptionsModel;
using CostCalculation.Services.IServices;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;

namespace CostCalculation.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;
        public EmailService(IOptions<EmailSettings> options)
        {
            _emailSettings = options.Value;
        }
        private SmtpClient GetConfiguredSmtpClient()
        {
            var smtpClient = new SmtpClient
            {
                Host = _emailSettings.Host!,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Port = 587,
                Credentials = new NetworkCredential(_emailSettings.Email, _emailSettings.Password),
                EnableSsl = true
            };

            return smtpClient;
        }
        public async Task SendPasswordUpdatedEmail(string toEmail)
        {
            var smtpClient = GetConfiguredSmtpClient();
            var mailMessage = new MailMessage
            {
                From = new MailAddress(_emailSettings.Email!),
                To = { toEmail },
                Subject = "LocalHost | Şifre Güncelleme Bildirimi",
                Body = "Şifreniz başarıyla güncellenmiştir."
            };
            mailMessage.IsBodyHtml = true;

            await smtpClient.SendMailAsync(mailMessage);
        }
        public async Task SendResetPasswordEmail(string resetPasswordEmailLink, string toEmail)
        {
            //var smtpClient = new SmtpClient();
            //smtpClient.Host = _emailSettings.Host!;
            //smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            //smtpClient.UseDefaultCredentials = false;
            //smtpClient.Port = 587;
            //smtpClient.Credentials = new NetworkCredential(_emailSettings.Email, _emailSettings.Password);
            //smtpClient.EnableSsl = true;

            var smtpClient = GetConfiguredSmtpClient();
            var mailMessage = new MailMessage();

            mailMessage.From = new MailAddress(_emailSettings.Email!);
            mailMessage.To.Add(toEmail);

            mailMessage.Subject = "LocalHost | Şifre Yenileme Linki";
            mailMessage.Body = @$"<h4>Şifrenizi yenileme linkinizi tıklayarak işlemlerinize devam edebilirsiniz.</h4>
                                    <p><a href='{resetPasswordEmailLink}'>Şifre yenileme linki</a></p>";
            mailMessage.IsBodyHtml = true;

            await smtpClient.SendMailAsync(mailMessage);
        }

        public async Task SendActivatedInfoEmail(string toEmail, bool approvedStatus)
        {
            var smtpClient = GetConfiguredSmtpClient();
            var loginPageLink = "https://localhost:7275/Home/SignIn";
            var mailMessage = new MailMessage
            {
                From = new MailAddress(_emailSettings.Email!),
                To = { toEmail },
                Subject = "LocalHost | Hesap Aktivasyonu",
                Body = approvedStatus ? @$"Hesabınız başarıyla aktive edilmiştir. Kullanıcı adınız ve şifrenizle giriş yapabilirsiniz. <p><a href='{loginPageLink}'>Giriş Sayfası</a></p>" : "Hesabınız askıya alındı.)"
            };
            mailMessage.IsBodyHtml = true;

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
