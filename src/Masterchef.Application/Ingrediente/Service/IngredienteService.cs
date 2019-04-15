using Masterchef.Application.Ingrediente.Interface;
using Masterchef.Application.Ingrediente.ViewModel;
using Masterchef.Core.Application.Interface;
using Masterchef.Core.Application.Vo;
using Masterchef.Core.Data.Interface;
using Masterchef.Domain.Ingrediente.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef.Application.Ingrediente.Service
{
    public class IngredienteService : Base.BaseService, IIngredienteService
    {
        private readonly IIngredienteRepository _ingredienteRepository;

        public IngredienteService(
            IUnitOfWork uow,
            INotificationHandler<Notification> notification,
            IIngredienteRepository ingredienteRepository) : base(uow, notification)
        {
            _ingredienteRepository = ingredienteRepository;
        }

        public void Add(AddIngrediente vmodel)
        {
            Domain.Ingrediente.Entity.Ingrediente model = vmodel;

            if (!model.IsValid())
            {
                NotifyValidationError(model.ValidationResult);
                return;
            }

            _ingredienteRepository.Add(model);

            Commit();
        }

        public IEnumerable<ListIngrediente> List()
        {
            return ConvertList(_ingredienteRepository.Consult
                .OrderBy(a => a.Nome));
        }
        
        public IEnumerable<SelectListItem> ListDropDown()
        {
            return _ingredienteRepository.Consult.OrderBy(a=>a.Nome).Select(b =>
                new SelectListItem() { Text = $"{b.Nome} - {b.UnidadeMedida}", Value = b.Id.ToString() }).ToList();
        }

        private IEnumerable<ListIngrediente> ConvertList(IOrderedQueryable<Domain.Ingrediente.Entity.Ingrediente> list)
        {
            ICollection<ListIngrediente> result = new List<ListIngrediente>();

            if (list.Any())
            {
                foreach (var item in list)
                    result.Add(item);
            }

            return result;
        }
    }
}
