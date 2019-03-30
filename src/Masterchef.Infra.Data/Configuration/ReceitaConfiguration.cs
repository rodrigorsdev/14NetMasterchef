using Microsoft.EntityFrameworkCore;

namespace Masterchef.Infra.Data.Configuration
{
    public static class ReceitaConfiguration
    {
        public static void ConfigureReceita(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Receita.Entity.Receita>()
                .HasKey(a => a.Id);
        }
    }
}