using Microsoft.EntityFrameworkCore;

namespace Masterchef.Infra.Data.Configuration
{
    public static class IngredienteConfiguration
    {
        public static void ConfigureIngrediente(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Ingrediente.Entity.Ingrediente>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Domain.Ingrediente.Entity.Ingrediente>()
                .Property(a => a.Nome).IsRequired();

            modelBuilder.Entity<Domain.Ingrediente.Entity.Ingrediente>()
                .Property(a => a.UnidadeMedida).IsRequired();

            modelBuilder.Entity<Domain.Ingrediente.Entity.Ingrediente>()
                .Ignore(a => a.ValidationResult);
        }
    }
}