namespace MailSender.DefaultSenders
{
    public class GmailDefaultSender : Clients.MailClient
    {
        public GmailDefaultSender(string mailFrom,string passwordFrom) 
            : base(587, "smtp.gmail.com", new System.Net.NetworkCredential(mailFrom,passwordFrom))
        {

        }


    }
}
