using MimeKit;

namespace AdoptPet.Application.DTOs.Email
{
    public class Message
    {
        public List<MailboxAddress> To { get; set; }

        // tiêu đề
        public string Subject { get; set; }

        // nội dung
        public string Content { get; set; }

        public Message(IEnumerable<string> to, string subject, string content)
        {
            To = new List<MailboxAddress>();
            To.AddRange(to.Select(x => new MailboxAddress(x, x)));
            Subject = subject;
            Content = content;
        }
    }
}
