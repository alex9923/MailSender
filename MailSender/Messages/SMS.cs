using Twilio;
using Twilio.Rest.Api.V2010.Account;
using MessageSender.Contracts;
namespace MessageSender.Messages
{
    public class SMS : Message<MessageResource>, ISMS
    {
        public string TwilioRestSID { get; }
        public string TwilioRestPassword { get; }
        public string DestinationNumber { get; }
        public string OriginalNumber { get; }
        public string MessageBody { get; set; }

        public SMS(string sid, string password,string originalNumber, string destinationNumber, string message)
        {
            TwilioRestSID = sid;
            TwilioRestPassword = password;
            OriginalNumber = originalNumber;
            DestinationNumber = destinationNumber;
            MessageBody = message;
            TwilioClient.Init(TwilioRestSID, TwilioRestPassword);
        }

        public override MessageResource GenerateMessage()
            => MessageResource.Create(body: MessageBody, from: OriginalNumber, to: DestinationNumber);
    }
}
