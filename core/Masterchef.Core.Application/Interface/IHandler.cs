using Masterchef.Core.Application.Message;

namespace Masterchef.Core.Application.Interface
{
    public interface IHandler<in T> where T : BaseMessage
    {
        void Handle(T message);
    }
}