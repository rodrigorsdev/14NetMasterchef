using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Masterchef.Infra.Data.Context
{
    public class MasterchefContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<Domain.Receita.Entity.Receita> Receita { get; set; }
        public DbSet<Domain.Ingrediente.Entity.Ingrediente> Ingrediente { get; set; }

        public MasterchefContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public override int SaveChanges()
        {
            foreach (var entidade in ChangeTracker.Entries().Where(a => a.Entity.GetType().GetProperty("AdditionDate") != null))
            {
                if (entidade.State == EntityState.Added)
                {
                    entidade.Property("AdditionDate").CurrentValue = DateTime.Now;
                }

                if (entidade.State == EntityState.Modified)
                {
                    entidade.Property("AdditionDate").IsModified = false;
                }
            }

            foreach (var entidade in ChangeTracker.Entries().Where(a => a.Entity.GetType().GetProperty("UpdateDate") != null))
            {
                if (entidade.State == EntityState.Added)
                {
                    entidade.Property("UpdateDate").CurrentValue = null;
                }

                if (entidade.State == EntityState.Modified)
                {
                    entidade.Property("UpdateDate").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
}