using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Masterchef.Application.Ingrediente.Interface
{
    public interface IIngredienteService
    {
        IEnumerable<SelectListItem> ListDropDown();
    }
}
