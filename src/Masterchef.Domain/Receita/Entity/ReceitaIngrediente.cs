using System;
using System.Collections.Generic;
using System.Text;

namespace Masterchef.Domain.Receita.Entity
{
    public class ReceitaIngrediente
    {
        public Guid ReceitaId { get; set; }
        public Guid IngredienteId { get; set; }
        public int Quantidade { get; set; }
    }
}