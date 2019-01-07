using MailSender.Contracts;
using Twilio.Rest.Api.V2010.Account;

namespace MailSender.Clients
{
    public class SMSClient : IMessageClient<MessageResource>
    {
        public void Send<T>(T message) where T : Message<MessageResource>, IMail
        {
            message.GenerateMessage();
        }
    }
}
