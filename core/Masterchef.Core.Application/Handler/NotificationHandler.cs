using Masterchef.Core.Application.Interface;
using Masterchef.Core.Application.Vo;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef.Core.Application.Handler
{
    public class NotificationHandler : INotificationHandler<Notification>
    {
        private List<Notification> _notifications;

        public NotificationHandler()
        {
            _notifications = new List<Notification>();
        }

        public void Handle(Notification message)
        {
            _notifications.Add(message);
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }

        public List<Notification> ListNotifications()
        {
            return _notifications;
        }

        public void Dispose()
        {
            _notifications = new List<Notification>();
        }

        public bool HasErrorNotification()
        {
            return _notifications.Any(a => a.Key.Equals("error"));
        }
    }
}