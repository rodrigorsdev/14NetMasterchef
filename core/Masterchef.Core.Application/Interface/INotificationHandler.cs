using Masterchef.Core.Application.Message;
using System.Collections.Generic;

namespace Masterchef.Core.Application.Interface
{
    public interface INotificationHandler<T> : IHandler<T> where T : BaseMessage
    {
        bool HasNotification();
        List<T> ListNotifications();
    }
}