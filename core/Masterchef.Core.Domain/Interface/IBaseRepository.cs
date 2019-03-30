using Masterchef.Core.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef.Core.Domain.Interface
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity<TEntity>
    {
        IQueryable<TEntity> Consult { get; }
        IEnumerable<TEntity> Find(string term);
        TEntity GetById(Guid id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(Guid id);
    }
}