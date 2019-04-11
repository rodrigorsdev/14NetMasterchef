using Masterchef.Domain.Ingrediente.Interface;
using Masterchef.Infra.Data.Context;

namespace Masterchef.Infra.Data.Repository
{
    public class IngredienteRepository : BaseRepository<Domain.Ingrediente.Entity.Ingrediente>, IIngredienteRepository
    {
        public IngredienteRepository(MasterchefContext context) : base(context)
        {
        }
    }
}