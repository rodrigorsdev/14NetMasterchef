using Masterchef.Application.Categoria.Interface;
using Masterchef.Domain.Categoria.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef.Application.Categoria.Service
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(
            ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public IEnumerable<SelectListItem> ListDropDown()
        {
            return _categoriaRepository.Consult.Select(a =>
            new SelectListItem() { Text = a.Nome, Value = a.Id.ToString() }).ToList();
        }
    }
}