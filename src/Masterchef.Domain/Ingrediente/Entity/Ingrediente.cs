using Masterchef.Core.Domain.Entity;
using System;
using System.Collections.Generic;

namespace Masterchef.Domain.Ingrediente.Entity
{
    public class Ingrediente : BaseEntity<Ingrediente>
    {
        protected Ingrediente()
        { }

        public Ingrediente(
            Guid id,
            string nome,
            string unidadeMedida)
        {
            Id = id;
            Nome = nome;
            UnidadeMedida = unidadeMedida;
        }
        
        public string Nome { get; private set; }
        public string UnidadeMedida { get; private set; }
        public ICollection<Receita.Entity.ReceitaIngrediente> ReceitaIngredientes { get; set; }

        public override bool IsValid()
        {
            return true;
        }
    }
}