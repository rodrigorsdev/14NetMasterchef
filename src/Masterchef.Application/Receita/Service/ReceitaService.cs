using Masterchef.Application.Receita.Interface;
using Masterchef.Application.Receita.ViewModel;
using Masterchef.Core.Application.Interface;
using Masterchef.Core.Application.Vo;
using Masterchef.Core.Data.Interface;
using Masterchef.Domain.Receita.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef.Application.Receita.Service
{
    public class ReceitaService : Base.BaseService, IReceitaService
    {
        private readonly IReceitaRepository _receitaRepository;

        public ReceitaService(
            IUnitOfWork uow,
            INotificationHandler<Notification> notification,
            IReceitaRepository receitaRepository) : base(uow, notification)
        {
            _receitaRepository = receitaRepository;
        }

        public void Add(ReceitaAdd vmodel)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ReceitaIndex> Listar(string term)
        {
            IEnumerable<ReceitaIndex> result = new List<ReceitaIndex>();

            if (!string.IsNullOrEmpty(term))
                result = _receitaRepository.Find(term).Select(a => (ReceitaIndex)a).ToList();
            else
                result = _receitaRepository.Consult.Select(a => (ReceitaIndex)a);

            return result;
        }
    }
}
