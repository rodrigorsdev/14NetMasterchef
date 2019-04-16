using System;

namespace Masterchef.Application.Receita.ViewModel
{
    public class ReceitaIndex
    {
        public Guid ReceitaId { get; set; }
        public string Titulo { get;  set; }
        public string Descricao { get;  set; }
        public string ModoPreparo { get;  set; }
        public string ImagemBase64 { get;  set; }
        public string Tags { get;  set; }
        public Guid CategoriaId { get; set; }
        public string CategoriaNome { get; set; }

        public static implicit operator ReceitaIndex(Domain.Receita.Entity.Receita model)
        {
            if (model == null)
                return null;

            return new ReceitaIndex
            {
                ReceitaId = model.Id,
                Titulo = model.Titulo,
                ModoPreparo = model.ModoPreparo,
                Descricao = model.Descricao,
                ImagemBase64 = model.Imagem != null ? $"data:image/jpg;base64,{Convert.ToBase64String(model.Imagem)}" : string.Empty,
                Tags = model.Tags,
                CategoriaId = model.Categoria.Id,
                CategoriaNome = model.Categoria.Nome
            };
        }
    }
}