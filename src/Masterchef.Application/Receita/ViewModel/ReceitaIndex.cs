using System;

namespace Masterchef.Application.Receita.ViewModel
{
    public class ReceitaIndex
    {
        public Guid ReceitaId { get; set; }
        public string Titulo { get; set; }
        public int Rendimento { get; set; }
        public string ModoPreparo { get; set; }

        public static implicit operator ReceitaIndex(Domain.Receita.Entity.Receita model)
        {
            if (model == null)
                return null;

            return new ReceitaIndex
            {
                ReceitaId = model.Id,
                Titulo = model.Titulo,
                ModoPreparo = model.ModoPreparo,
                Rendimento = model.Rendimento
            };
        }
    }
}