using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using MailSender.Contracts;

namespace MailSender.Messages
{
    public class Mail : Message<MailMessage>, IMail
    {
        public MailAddress From { get; }
        public string Subject { get; }
        public string Body { get; }
        public MailAddress[] To { get; }
        public MailAddress[] CC { get; }
        public List<Attachment> Attachment { get; } = new List<Attachment>();

        public Mail(MailAddress from, MailAddress[] to, string subject, string body)
        {
            this.From = from;
            this.Subject = subject;
            this.Body = body;
            this.To = to;
        }
        public Mail(string from, string[] to, string subject, string body)
            : this(new MailAddress(from), to.Select(x => new MailAddress(x)).ToArray(), subject, body)
        {
        }
        public Mail(MailAddress from, MailAddress[] to, MailAddress[] cc, string subject, string body)
            : this(from, to, subject, body)
        {
            this.CC = cc;
        }
        public Mail(string from, string[] to, string[] cc, string subject, string body)
            : this(new MailAddress(from), to.Select(x => new MailAddress(x)).ToArray(),cc.Select(x => new MailAddress(x)).ToArray(), subject, body)
        {
        }

        public override MailMessage GenerateMessage()
        {
            MailMessage mailMessage = new MailMessage
            {
                From = From,
                Subject = Subject,
                Body = Body
            };
            AddElementsToCollection(mailMessage.To, this.To);
            AddElementsToCollection(mailMessage.CC, this.CC);
            AddElementsToCollection(mailMessage.Attachments, this.Attachment);
            return mailMessage;
        }
    }
}
