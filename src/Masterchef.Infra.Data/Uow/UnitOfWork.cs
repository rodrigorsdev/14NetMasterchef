using Masterchef.Core.Data.Interface;
using Masterchef.Core.Data.Vo;
using Masterchef.Infra.Data.Context;

namespace Masterchef.Infra.Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MasterchefContext _context;

        public UnitOfWork(MasterchefContext context)
        {
            _context = context;
        }

        public CommitResponse Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommitResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}