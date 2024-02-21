using Airbnb.Model.Common.Enum;
using Airbnb.Model.CustomModels;
using Airbnb.Service.Interface;
using MailKit.Net.Smtp;
using MimeKit;
using System.Web;

namespace Airbnb.Service.Implementation
{
    public class EmailService : IEmailService
    {

        /// <summary>
        /// Create and send email
        /// </summary>
        /// <param name="emailMessage">EmailMessageModel object</param>
        /// <returns>true if email sent successfully</returns>
        public async Task SendEmailAsync(EmailMessageModel emailMessage, EmailConfigurationModel emailConfiguration)
        {
            MimeMessage mimeMessage = new();
            mimeMessage.From.Add(new MailboxAddress(emailConfiguration.UserName, emailConfiguration.From));
            mimeMessage.To.AddRange(emailMessage.To);
            mimeMessage.Subject = emailMessage.Subject;
            mimeMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = emailMessage.Content };

            using SmtpClient client = new();
            await client.ConnectAsync(emailConfiguration.SmtpServer, emailConfiguration.Port, true);
            await client.AuthenticateAsync(emailConfiguration.UserName, emailConfiguration.Password);
            await client.SendAsync(mimeMessage);
            await client.DisconnectAsync(true);
            client.Dispose();
        }
    }
}
