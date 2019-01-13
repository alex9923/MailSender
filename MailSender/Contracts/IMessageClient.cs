namespace MailSender.Contracts
{
    public interface IMessageClient<TMesssageType>
    {
        bool Send<T>(T message) where T : Message<TMesssageType>, IMail;
    }
}
