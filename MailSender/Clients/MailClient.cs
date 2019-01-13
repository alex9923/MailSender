using System.Net.Mail;
using System.Windows.Forms;
using MailSender.Contracts;

namespace MailSender.Clients
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

        public bool Send<T>(T message) where T : Message<MailMessage>, IMail
        {
            bool isSendedOK = false;
            try
            {
                if (message.Subject != string.Empty
                    || message.Subject == string.Empty
                    && MessageBox.Show("Mail sin asunto, enviar igualmente?",
                                       "Alerta",
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    CreateSMTPClient().Send(message.GenerateMessage());
                    isSendedOK = true;
                }
            }
            catch
            {
            }
            return isSendedOK;
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
