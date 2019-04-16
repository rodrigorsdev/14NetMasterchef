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
            string tags,
            string categoriaId)
        {
            Id = receitaId;
            Titulo = titulo;
            Descricao = descricao;
            ModoPreparo = modoPreparo;
            Imagem = imagem;
            Tags = tags;
            Categoria = new Categoria.Entity.Categoria(Guid.Parse(categoriaId));
        }

        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public string ModoPreparo { get; private set; }
        public byte[] Imagem { get; private set; }
        public string Tags { get; private set; }
        public Categoria.Entity.Categoria Categoria { get; set; }

        public ICollection<ReceitaIngrediente> ReceitaIngredientes { get; set; }

        public void AddIngrediente(Guid ingredienteId, int quantidade)
        {
            if (ReceitaIngredientes == null)
                ReceitaIngredientes = new List<ReceitaIngrediente>();

            ReceitaIngredientes.Add(new ReceitaIngrediente
            {
                IngredienteId = ingredienteId,
                Quantidade = quantidade,
                ReceitaId = Id
            });
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}