using Microsoft.EntityFrameworkCore;

namespace Masterchef.Infra.Data.Configuration
{
    public static class CategoriaConfiguration
    {
        public static void ConfigureCategoria(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Categoria.Entity.Categoria>()
               .HasKey(a => a.Id);

            modelBuilder.Entity<Domain.Categoria.Entity.Categoria>()
                .Ignore(a => a.ValidationResult);
        }
    }
}
