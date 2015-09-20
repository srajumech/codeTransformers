
namespace Broadcast
{
    using System;
    using System.Threading.Tasks;

    public interface INotificationCenter
    {
     
        ISubscription Subscribe<TMessageType>(Action<TMessageType, ISubscription> callback, Func<TMessageType, bool> condition = null) 
            where TMessageType : class, IMessage;

        void Publish<TMessageType>(TMessageType message) where TMessageType : class, IMessage;

        Task PublishAsync<TMessageType>(TMessageType message) where TMessageType : class, IMessage;
    }
}
