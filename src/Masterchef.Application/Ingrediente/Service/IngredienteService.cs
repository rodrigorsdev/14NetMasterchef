using Masterchef.Application.Ingrediente.Interface;
using Masterchef.Domain.Ingrediente.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef.Application.Ingrediente.Service
{
    public class IngredienteService : IIngredienteService
    {
        private readonly IIngredienteRepository _ingredienteRepository;

        public IngredienteService(
            IIngredienteRepository ingredienteRepository)
        {
            _ingredienteRepository = ingredienteRepository;
        }

        public IEnumerable<SelectListItem> ListDropDown()
        {
            return _ingredienteRepository.Consult.Select(a =>
           new SelectListItem() { Text = a.Nome, Value = a.Id.ToString() }).ToList();
        }
    }
}
