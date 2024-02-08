using Airbnb.Model.Common.Enum;
using MailKit.Net.Smtp;
using MimeKit;
using System.Web;

namespace Airbnb.Web.Services
{
    public class EmailSender
    {
        private readonly EmailConfiguration _emailConfig;
        private IWebHostEnvironment _environment;

        public EmailSender(EmailConfiguration emailConfig, IWebHostEnvironment environment)
        {
            _emailConfig = emailConfig;
            _environment = environment;
        }
        public EmailMessage GenerateEmailMessage(string email, string name, string token, EmailTypeEnum emailType)
        {
            var link = new UriBuilder("http://localhost:4200");
            var subject = "Email from Airbnb";
            var template = "";

            switch (emailType)
            {
                case EmailTypeEnum.EmailVerification:
                    link = new UriBuilder("http://localhost:4200/email-verification");
                    subject = "Please confirm your email address";
                    template = "EmailReminderTemplate.html";
                    break;
                case EmailTypeEnum.PasswordReset:
                    link = new UriBuilder("http://localhost:4200/reset-password");
                    subject = "Reset your password";
                    template = "EmailResetPasswordTemplate.html";
                    break;
                default:
                    break;
            }

            // Set query parameters
            var query = HttpUtility.ParseQueryString(link.Query);
            query["token"] = token;
            query["email"] = email;
            link.Query = query.ToString();
            string wwwPath = _environment.WebRootPath;
            string contentPath = _environment.ContentRootPath;
            var pathToFile = Path.Combine(contentPath, "AppData/EmailTemplates/" + template);

            BodyBuilder builder = new BodyBuilder();

            using (StreamReader sr = new StreamReader(pathToFile))
            {
                builder.HtmlBody = sr.ReadToEnd();
            }

            string content = string.Format(builder.HtmlBody, name, link);

            return new EmailMessage(new string[] { email }, subject, content);
        }

        /// <summary>
        /// Create and send email
        /// </summary>
        /// <param name="message">EmailMessage object</param>
        /// <returns>true if email sent successfully</returns>
        public async Task<bool> SendEmailAsync(EmailMessage message)
        {
            var emailMessage = CreateEmailMessage(message);

            await SendAsync(emailMessage);

            return true;
        }

        /// <summary>
        /// Creates MimeMessage object
        /// </summary>
        /// <param name="message">EmailMessage object</param>
        /// <returns>MimeMessage object</returns>
        private MimeMessage CreateEmailMessage(EmailMessage message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Airbnb Team", _emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message.Content }; ;
            return emailMessage;
        }


        /// <summary>
        /// Send email using smtpClient class.
        /// </summary>
        /// <param name="mailMessage">MimeMessage object returned from CreateEmailMessage method</param>
        private async Task SendAsync(MimeMessage mailMessage)
        {
            using var client = new SmtpClient();
            await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, true);
            await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);
            await client.SendAsync(mailMessage);
            await client.DisconnectAsync(true);
            client.Dispose();
        }

        //public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor,
        //                   ILogger<EmailSender> logger)
        //{
        //    Options = optionsAccessor.Value;
        //    _logger = logger;
        //}

        //public AuthMessageSenderOptions Options { get; } //Set with Secret Manager.

        //public async Task SendEmailAsync(string toEmail, string subject, string message)
        //{
        //    if (string.IsNullOrEmpty(Options.SendGridKey))
        //    {
        //        throw new Exception("Null SendGridKey");
        //    }
        //    await Execute(Options.SendGridKey, subject, message, toEmail);
        //}

        //public async Task Execute(string apiKey, string subject, string message, string toEmail)
        //{
        //    var client = new SendGridClient(apiKey);
        //    var msg = new SendGridMessage()
        //    {
        //        From = new EmailAddress("ciplatformmailservice@gmail.com", "Password Recovery"),
        //        Subject = subject,
        //        PlainTextContent = message,
        //        HtmlContent = message
        //    };
        //    msg.AddTo(new EmailAddress(toEmail));

        //    // Disable click tracking.
        //    // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
        //    msg.SetClickTracking(false, false);
        //    var response = await client.SendEmailAsync(msg);
        //    _logger.LogInformation(response.IsSuccessStatusCode
        //                           ? $"Email to {toEmail} queued successfully!"
        //                           : $"Failure Email to {toEmail}");
        //}
    }
}
