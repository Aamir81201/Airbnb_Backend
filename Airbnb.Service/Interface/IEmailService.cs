using Airbnb.Model.CustomModels;

namespace Airbnb.Service.Interface
{
    public interface IEmailService
    {
        public Task SendEmailAsync(EmailMessageModel message, EmailConfigurationModel emailConfiguration);
    }
}
