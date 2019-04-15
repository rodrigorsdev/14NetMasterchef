using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Masterchef.Infra.Data.Context
{
    public static class Seed
    {
        public static void ExecuteSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Categoria.Entity.Categoria>()
                .HasData(
                    new Domain.Categoria.Entity.Categoria(Guid.Parse("57e7515e-8285-43e6-b6c0-ec7b9890a879"), "Bolos", "Bolos"),
                    new Domain.Categoria.Entity.Categoria(Guid.Parse("ef659695-a1f8-4740-a974-8e563a9e12bd"), "Tortas", "Tortas"),
                    new Domain.Categoria.Entity.Categoria(Guid.Parse("c7985033-24b1-4cca-84d9-0face1199031"), "Carnes", "Carnes"),
                    new Domain.Categoria.Entity.Categoria(Guid.Parse("4f31f332-5a04-4bde-a999-ad0f8ac728e2"), "Aves", "Aves"),
                    new Domain.Categoria.Entity.Categoria(Guid.Parse("34890e59-8e05-4628-9060-478cd9d98193"), "Massas", "Massas"),
                    new Domain.Categoria.Entity.Categoria(Guid.Parse("1bf37d85-67d2-4c5f-9438-b78e67f0b678"), "Sopas e caldos", "Sopas e caldos"),
                    new Domain.Categoria.Entity.Categoria(Guid.Parse("d163b2d8-8ec0-4f03-8c66-0344d8a10910"), "Doces", "Doces"));

            modelBuilder.Entity<Domain.Ingrediente.Entity.Ingrediente>()
                .HasData(
                    new Domain.Ingrediente.Entity.Ingrediente(Guid.Parse("eb33f88a-9cf3-4d0b-b762-70f0457ad356"), "Farinha de trigo", "kg"),
                    new Domain.Ingrediente.Entity.Ingrediente(Guid.Parse("250b697b-18cb-4c4b-987a-53ce663b7fb5"), "Ovo", "un"),
                    new Domain.Ingrediente.Entity.Ingrediente(Guid.Parse("27166bba-148f-4082-91ee-bcec547390ed"), "Leite", "ml"),
                    new Domain.Ingrediente.Entity.Ingrediente(Guid.Parse("f994d309-212f-4f9c-8672-6c964ab7b516"), "Sal", "colher chá"),
                    new Domain.Ingrediente.Entity.Ingrediente(Guid.Parse("56e6d958-cb88-4315-8356-73a1f831f872"), "Açucar", "colher sopa"),
                    new Domain.Ingrediente.Entity.Ingrediente(Guid.Parse("8369d249-dcdd-4ba6-85b4-8d0955580163"), "Óleo", "Xicara"),
                    new Domain.Ingrediente.Entity.Ingrediente(Guid.Parse("8974aefa-e989-4027-9e04-d1e1a96a206c"), "Água", "ml"),
                    new Domain.Ingrediente.Entity.Ingrediente(Guid.Parse("df6badb5-159d-42c7-925b-6508c8cecaea"), "Leite em pó", "colher sopa"),
                    new Domain.Ingrediente.Entity.Ingrediente(Guid.Parse("07fa9f48-adbc-47e1-97dc-b6883b300471"), "Amido de milho", "colher sopa"));
        }
    }
}
