using MimeKit;

namespace Airbnb.Model.CustomModels
{
    public class EmailMessageModel
    {
        public IEnumerable<MailboxAddress> To { get; set; } = Enumerable.Empty<MailboxAddress>();

        public string Subject { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;
    }
}
