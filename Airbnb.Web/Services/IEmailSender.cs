namespace Airbnb.Web.Services
{
    public interface IEmailSender
    {
        public bool SendEmailAsync(EmailMessage message);
    }
}
