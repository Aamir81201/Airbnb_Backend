using MimeKit;

namespace Airbnb.Web.Services
{
    public class EmailMessage
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public EmailMessage(IEnumerable<string> to, string subject, string content)
        {
            To = new List<MailboxAddress>();

            To.AddRange(to.Select(x => new MailboxAddress("Airbnb User", x)));
            Subject = subject;
            Content = content;
        }
    }
}
