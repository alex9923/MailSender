using System.Collections.Generic;

namespace MailSender.Contracts
{
    public abstract class Message<T>
    {
        public abstract T GenerateMessage();

        internal void AddElementsToCollection<TElement>(ICollection<TElement> collection, IList<TElement> values)
        {
            for (int i = 0; i < values.Count; i++)
            {
                collection.Add(values[i]);
            }
        }
    }
}