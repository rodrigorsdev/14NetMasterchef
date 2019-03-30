using System;

namespace Masterchef.Domain.Receita.Entity
{
    public class ReceitaIngrediente
    {
        public int Quantidade { get; set; }
        public Guid ReceitaId { get; set; }
        public Receita Receita { get; set; }
        public Guid IngredienteId { get; set; }
        public Ingrediente.Entity.Ingrediente Ingrediente { get; set; }}
}