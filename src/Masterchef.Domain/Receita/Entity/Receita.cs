using System;
using System.Collections.Generic;

namespace Masterchef.Domain.Receita.Entity
{
    public class Receita : Base.Entity.BaseEntity
    {
        protected Receita()
        { }

        public Guid ReceitaId { get; set; }
        public string Titulo { get; set; }
        public int Rendimento { get; set; }
        public string ModoPreparo { get; set; }

        public ICollection<ReceitaIngrediente> Ingredientes { get; set; }
    }
}