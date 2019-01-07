using System.Collections.Generic;
using System.Net.Mail;

namespace MessageSender.Contracts
{
    public interface IMail
    {
        MailAddress From { get; }
        string Subject { get; }
        string Body { get; }
        MailAddress[] To { get; }
        MailAddress[] CC { get; }
        List<Attachment> Attachment { get; }
    }
}
