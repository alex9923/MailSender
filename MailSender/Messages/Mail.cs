using MailSender.Contracts;
using System.Collections.Generic;
using System.Net.Mail;

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
            From = from;
            Subject = subject;
            Body = body;
            To = to;
        }

        public Mail(MailAddress from, MailAddress[] to, MailAddress[] cc, string subject, string body)
            : this(from, to, subject, body)
        {
            CC = cc;
        }

        public override MailMessage GenerateMessage()
        {
            MailMessage mailMessage = new MailMessage
            {
                From = From,
                Subject = Subject,
                Body = Body
            };
            AddElementsToCollection(mailMessage.To, To);
            AddElementsToCollection(mailMessage.CC, CC);
            AddElementsToCollection(mailMessage.Attachments, Attachment);
            return mailMessage;
        }
    }
}
