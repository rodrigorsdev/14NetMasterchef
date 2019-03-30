using Masterchef.Core.Application.Event;
using System;

namespace Masterchef.Core.Application.Vo
{
    public class Notification : BaseEvent
    {
        public Notification(
            string key,
            string value)
        {
            DomainNotificationId = Guid.NewGuid();
            Key = key;
            Value = value;
            Version = 1;
        }

        public Guid DomainNotificationId { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }
        public int Version { get; private set; }
    }
}