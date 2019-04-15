using System;

namespace Masterchef.Application.Ingrediente.ViewModel
{
    public class AddIngrediente
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string UnidadeMedida { get; set; }

        public static implicit operator Domain.Ingrediente.Entity.Ingrediente(AddIngrediente vmodel)
        {
            if (vmodel == null)
                return null;

            return new Domain.Ingrediente.Entity.Ingrediente(
                vmodel.Id,
                vmodel.Nome,
                vmodel.UnidadeMedida);
        }
    }
}