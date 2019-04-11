using Masterchef.Core.Domain.Entity;
using System;
using System.Collections.Generic;

namespace Masterchef.Domain.Receita.Entity
{
    public class Receita : BaseEntity<Receita>
    {
        protected Receita()
        { }

        public Receita(
            Guid receitaId,
            string titulo,
            string descricao,
            string modoPreparo,
            byte[] imagem,
            string tags)
        {
            Id = receitaId;
            Titulo = titulo;
            Descricao = descricao;
            ModoPreparo = modoPreparo;
            Imagem = imagem;
            Tags = tags;
        }

        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public string ModoPreparo { get; private set; }
        public byte[] Imagem { get; private set; }
        public string Tags { get; private set; }
        public Categoria.Entity.Categoria Categoria { get; set; }

        public ICollection<ReceitaIngrediente> ReceitaIngredientes { get; set; }

        public override bool IsValid()
        {
            throw new System.NotImplementedException();
        }
    }
}