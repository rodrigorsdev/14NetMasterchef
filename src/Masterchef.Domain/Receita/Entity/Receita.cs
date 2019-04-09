using Masterchef.Core.Domain.Entity;
using System;
using System.Collections.Generic;

namespace Masterchef.Domain.Receita.Entity
{
    public class Receita : BaseEntity<Receita>
    {
        protected Receita()
        { }

        public Receita(
            Guid receitaId,
            string titulo,
            int rendimento,
            string modoPreparo)
        {
            Id = receitaId;
            Titulo = titulo;
            Rendimento = rendimento;
            ModoPreparo = modoPreparo;
        }
        
        public string Titulo { get; private set; }
        public int Rendimento { get; private set; }
        public string ModoPreparo { get; private set; }

        public ICollection<ReceitaIngrediente> ReceitaIngredientes { get; set; }

        public override bool IsValid()
        {
            throw new System.NotImplementedException();
        }
    }
}