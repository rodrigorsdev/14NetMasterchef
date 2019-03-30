using System;

namespace Masterchef.Domain.Ingrediente.Entity
{
    public class Ingrediente : Base.Entity.BaseEntity
    {
        protected Ingrediente()
        { }

        public Ingrediente(
            Guid id,
            string nome,
            string unidadeMedida)
        {
            IngredienteId = id;
            Nome = nome;
            UnidadeMedida = unidadeMedida;
        }

        public Guid IngredienteId { get; private set; }
        public string Nome { get; private set; }
        public string UnidadeMedida { get; private set; }
    }
}