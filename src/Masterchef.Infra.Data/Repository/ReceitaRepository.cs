using Masterchef.Domain.Receita.Interface;
using Masterchef.Infra.Data.Context;

namespace Masterchef.Infra.Data.Repository
{
    public class ReceitaRepository : BaseRepository<Domain.Receita.Entity.Receita>, IReceitaRepository
    {
        public ReceitaRepository(MasterchefContext context) : base(context)
        {
        }
    }
}