using Masterchef.Core.Domain.Entity;
using System.Collections.Generic;

namespace Masterchef.Domain.Receita.Entity
{
    public class Receita : BaseEntity<Receita>
    {
        protected Receita()
        { }
        
        public string Titulo { get; set; }
        public int Rendimento { get; set; }
        public string ModoPreparo { get; set; }

        public ICollection<ReceitaIngrediente> ReceitaIngredientes { get; set; }

        public override bool IsValid()
        {
            throw new System.NotImplementedException();
        }
    }
}