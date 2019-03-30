using System;

namespace Masterchef.Core.Application.Message
{
    public abstract class BaseMessage
    {
        protected BaseMessage()
        {
            Type = GetType().Name;
        }

        public string Type { get; protected set; }
        public Guid AggregatedId { get; protected set; }
    }
}