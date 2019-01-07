using MessageSender.Contracts;
using System.Net.Mail;

namespace MessageSender.Clients
{
    public class MailClient : IMessageClient<MailMessage>
    {
        public int Port { get; }
        public string Host { get; }
        private System.Net.NetworkCredential Credential { get; }
        public bool EnableSSL { get; set; } = true;
        public int Timeout { get; set; } = 10000;
        public bool UseDefaultCredentials { get; set; } = false;

        public MailClient(int port, string host, System.Net.NetworkCredential credential)
        {
            Port = port;
            Host = host;
            Credential = credential;
        }

        public void Send<T>(T message) where T : Message<MailMessage>, IMail
        {
            CreateSMTPClient().Send(message.GenerateMessage());
        }

        private SmtpClient CreateSMTPClient()
            => new SmtpClient
            {
                Port = Port,
                Host = Host,
                EnableSsl = EnableSSL,
                Timeout = Timeout,
                UseDefaultCredentials = UseDefaultCredentials,
                Credentials = Credential
            };
    }
}
