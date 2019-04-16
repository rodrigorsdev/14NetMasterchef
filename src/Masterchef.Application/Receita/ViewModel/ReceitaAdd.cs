using System;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef.Application.Receita.ViewModel
{
    public class ReceitaAdd
    {
        public Guid ReceitaId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string ModoPreparo { get; set; }
        public byte[] Imagem { get; set; }
        public string Tags { get; set; }
        public Guid CategoriaId { get; set; }
        public ICollection<ReceitaAddIngrediente> Ingredientes { get; set; }

        public static implicit operator Domain.Receita.Entity.Receita(ReceitaAdd vmodel)
        {
            if (vmodel == null)
                return null;

            var model = new Domain.Receita.Entity.Receita(
                vmodel.ReceitaId,
                vmodel.Titulo,
                vmodel.Descricao,
                vmodel.ModoPreparo,
                vmodel.Imagem,
                vmodel.Tags,
                vmodel.CategoriaId.ToString());

            if (vmodel.Ingredientes.Any())
                foreach (var item in vmodel.Ingredientes)
                    model.AddIngrediente(Guid.Parse(item.IngredienteId), item.Quantidade);

            return model;
        }
    }
}