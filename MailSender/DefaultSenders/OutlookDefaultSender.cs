namespace MailSender.DefaultSenders
{
    public class OutlookDefaultSender : Clients.MailClient
    {
        public OutlookDefaultSender(string mailFrom,string passwordFrom) 
            : base(587, "smtp-mail.outlook.com", new System.Net.NetworkCredential(mailFrom,passwordFrom))
        {
        }
    }
}
