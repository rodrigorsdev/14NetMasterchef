using Masterchef.Application.Ingrediente.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Masterchef.Application.Ingrediente.Interface
{
    public interface IIngredienteService
    {
        IEnumerable<SelectListItem> ListDropDown();
        void Add(ViewModel.AddIngrediente vmodel);
        IEnumerable<ListIngrediente> List();
    }
}
