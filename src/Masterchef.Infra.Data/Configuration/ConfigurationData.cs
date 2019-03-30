using Microsoft.EntityFrameworkCore;

namespace Masterchef.Infra.Data.Configuration
{
    public static class ConfigurationData
    {
        public static void ConfigurationDataEntities(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Receita.Entity.Receita>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Domain.Ingrediente.Entity.Ingrediente>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Domain.Receita.Entity.ReceitaIngrediente>()
                .HasKey(a => new { a.ReceitaId, a.IngredienteId });

            modelBuilder.Entity<Domain.Receita.Entity.ReceitaIngrediente>()
                .HasOne(a => a.Receita)
                .WithMany(b => b.ReceitaIngredientes)
                .HasForeignKey(c => c.ReceitaId);

            modelBuilder.Entity<Domain.Receita.Entity.ReceitaIngrediente>()
                .HasOne(a => a.Ingrediente)
                .WithMany(b => b.ReceitaIngredientes)
                .HasForeignKey(c => c.IngredienteId);
        }
    }
}