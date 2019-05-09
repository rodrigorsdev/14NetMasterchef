using Masterchef.Application.Receita.Interface;
using Masterchef.Application.Receita.ViewModel;
using Masterchef.Core.Application.Interface;
using Masterchef.Core.Application.Vo;
using Masterchef.Core.Data.Interface;
using Masterchef.Domain.Receita.Interface;
using System;
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

        public void Add(AddReceita vmodel)
        {
            try
            {
                Domain.Receita.Entity.Receita model = vmodel;

                if (!model.IsValid())
                {
                    NotifyValidationError(model.ValidationResult);
                    return;
                }

                _receitaRepository.Add(model);

                Commit();
            }
            catch (Exception e)
            {
                AddNotification("error", "Erro ao processar a requisição");
            }

        }

        public IEnumerable<ReceitaIndex> Listar(string term)
        {
            IEnumerable<ReceitaIndex> result = new List<ReceitaIndex>();

            try
            {
                if (!string.IsNullOrEmpty(term))
                    result = ConvertList(_receitaRepository.Find(term).Distinct());
                else
                    result = ConvertList(_receitaRepository.Consult);
            }
            catch (Exception e)
            {
                AddNotification("error", "Erro ao processar a requisição");
            }

            return result;
        }

        private IEnumerable<ReceitaIndex> ConvertList(IEnumerable<Domain.Receita.Entity.Receita> list)
        {
            ICollection<ReceitaIndex> result = new List<ReceitaIndex>();

            if (list.Any())
            {
                foreach (var item in list)
                    result.Add(item);
            }

            return result;
        }
    }
}
