using System.Collections.Generic;

namespace Masterchef.Application.Receita.ViewModel
{
    public class ReceitaAdd
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string ModoPreparo { get; set; }
        public byte[] Imagem { get; set; }
        public string Tags { get; set; }
        public ReceitaAddCategoria Categoria { get; set; }
        public ICollection<ReceitaAddIngrediente> Ingredientes { get; set; }
    }
}