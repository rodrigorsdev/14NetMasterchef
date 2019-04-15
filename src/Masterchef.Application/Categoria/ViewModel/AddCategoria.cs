using System;

namespace Masterchef.Application.Categoria.ViewModel
{
    public class AddCategoria
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public static implicit operator Domain.Categoria.Entity.Categoria (AddCategoria vmodel)
        {
            if (vmodel == null)
                return null;

            return new Domain.Categoria.Entity.Categoria(
                vmodel.Id,
                vmodel.Nome,
                vmodel.Descricao);
        }
    }
}