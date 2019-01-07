namespace MessageSender.Contracts
{
    public interface IMessageClient<TMesssageType>
    {
        void Send<T>(T message) where T : Message<TMesssageType>, IMail;
    }
}
