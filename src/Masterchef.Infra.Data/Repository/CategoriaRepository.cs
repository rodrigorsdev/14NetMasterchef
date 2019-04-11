using Masterchef.Domain.Categoria.Interface;
using Masterchef.Infra.Data.Context;

namespace Masterchef.Infra.Data.Repository
{
    public class CategoriaRepository : BaseRepository<Domain.Categoria.Entity.Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(MasterchefContext context) : base(context)
        {
        }
    }
}
