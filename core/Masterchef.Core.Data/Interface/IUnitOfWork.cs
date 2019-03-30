using Masterchef.Core.Data.Vo;
using System;

namespace Masterchef.Core.Data.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        CommitResponse Commit();
    }
}