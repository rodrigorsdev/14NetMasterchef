namespace Masterchef.Application.Ingrediente.ViewModel
{
    public class ListIngrediente
    {
        public string IngredienteId { get; set; }
        public string Nome { get; set; }
        public string UnidadeMedida { get; set; }

        public static implicit operator ListIngrediente(Domain.Ingrediente.Entity.Ingrediente model)
        {
            if (model == null)
                return null;

            return new ListIngrediente
            {
                IngredienteId = model.Id.ToString(),
                Nome = model.Nome,
                UnidadeMedida = model.UnidadeMedida
            };
        }
    }
}
