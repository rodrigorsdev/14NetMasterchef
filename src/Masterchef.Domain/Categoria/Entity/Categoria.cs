using Masterchef.Core.Domain.Entity;
using System;
using System.Collections.Generic;

namespace Masterchef.Domain.Categoria.Entity
{
    public class Categoria : BaseEntity<Categoria>
    {
        protected Categoria()
        { }

        public Categoria(
            Guid categoriaId,
            string nome,
            string descricao)
        {
            Id = categoriaId;
            Nome = nome;
            Descricao = descricao;
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public ICollection<Receita.Entity.Receita> Receitas { get; set; }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
