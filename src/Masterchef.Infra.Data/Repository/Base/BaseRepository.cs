using Masterchef.Core.Data.Interface;
using Masterchef.Core.Domain.Entity;
using Masterchef.Core.Domain.Interface;
using Masterchef.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef.Infra.Data.Repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity<TEntity>
    {
        protected MasterchefContext _context;
        protected DbSet<TEntity> _dbSet;

        protected BaseRepository(MasterchefContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> Consult
        {
            get { return _dbSet; }
        }

        public IEnumerable<TEntity> Find(string term)
        {
            var result = new List<TEntity>();

            var propriedadesTexto = typeof(TEntity).GetProperties()
                .Where(a => a.PropertyType == typeof(string))
                .ToList();

            if (!string.IsNullOrEmpty(term))
            {
                foreach (var e in Consult)
                {
                    foreach (var p in propriedadesTexto)
                    {
                        var valor = (string)p.GetValue(e);

                        if (valor.ToLower().Contains(term.ToLower()))
                            result.Add(e);
                    }
                }
            }

            return result;
        }

        public virtual TEntity GetById(Guid id)
        {
            return _dbSet
                .AsNoTracking()
                .FirstOrDefault(a => a.Id == id);
        }

        public virtual void Add(TEntity model)
        {
            _dbSet.Add(model);
        }

        public virtual void Update(TEntity model)
        {
            _dbSet.Update(model);
        }

        public virtual void Remove(Guid id)
        {
            _dbSet.Remove(_dbSet.Find(id));
        }
    }
}