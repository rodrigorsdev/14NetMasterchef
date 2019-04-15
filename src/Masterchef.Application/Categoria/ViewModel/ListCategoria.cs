namespace Masterchef.Application.Categoria.ViewModel
{
    public class ListCategoria
    {
        public string CategoriaId { get; set; }
        public string Nome { get; set; }

        public static implicit operator ListCategoria(Domain.Categoria.Entity.Categoria model)
        {
            if (model == null)
                return null;

            return new ListCategoria
            {
                CategoriaId = model.Id.ToString(),
                Nome = model.Nome
            };
        }
    }
}