using Masterchef.Core.Application.Message;
using System;

namespace Masterchef.Core.Application.Event
{
    public abstract class BaseEvent : BaseMessage
    {
        public BaseEvent()
        {
            Timestamp = DateTime.Now;
        }

        public DateTime Timestamp { get; private set; }
    }
}