using Masterchef.Application.Categoria.Interface;
using Masterchef.Application.Categoria.ViewModel;
using Masterchef.Core.Application.Interface;
using Masterchef.Core.Application.Vo;
using Masterchef.Core.Data.Interface;
using Masterchef.Domain.Categoria.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef.Application.Categoria.Service
{
    public class CategoriaService : Base.BaseService, ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(
            IUnitOfWork uow,
            INotificationHandler<Notification> notification,
            ICategoriaRepository categoriaRepository) : base(uow, notification)
        {
            _categoriaRepository = categoriaRepository;
        }

        public void Add(AddCategoria vmodel)
        {
            Domain.Categoria.Entity.Categoria model = vmodel;

            if (!model.IsValid())
            {
                NotifyValidationError(model.ValidationResult);
                return;
            }

            _categoriaRepository.Add(model);

            Commit();
        }

        public IEnumerable<ListCategoria> List()
        {
            return ConvertList(_categoriaRepository.Consult
                .OrderBy(a => a.Nome));
        }

        public IEnumerable<SelectListItem> ListDropDown()
        {
            return _categoriaRepository.Consult.OrderBy(a => a.Nome).Select(b =>
              new SelectListItem() { Text = b.Nome, Value = b.Id.ToString() }).ToList();
        }

        private IEnumerable<ListCategoria> ConvertList(IEnumerable<Domain.Categoria.Entity.Categoria> list)
        {
            ICollection<ListCategoria> result = new List<ListCategoria>();

            if (list.Any())
            {
                foreach (var item in list)
                    result.Add(item);
            }

            return result;
        }
    }
}