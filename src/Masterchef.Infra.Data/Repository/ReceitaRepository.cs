using System.Linq;
using Masterchef.Domain.Receita.Entity;
using Masterchef.Domain.Receita.Interface;
using Masterchef.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Masterchef.Infra.Data.Repository
{
    public class ReceitaRepository : BaseRepository<Domain.Receita.Entity.Receita>, IReceitaRepository
    {
        public ReceitaRepository(MasterchefContext context) : base(context)
        {
        }

        public override IQueryable<Receita> Consult => base.Consult
            .Include(a => a.ReceitaIngredientes)
            .Include(a => a.Categoria);

        public override void Add(Receita model)
        {
            if (model.Categoria != null)
                _context.Set<Domain.Categoria.Entity.Categoria>().Attach(model.Categoria);

            base.Add(model);
        }
    }
}