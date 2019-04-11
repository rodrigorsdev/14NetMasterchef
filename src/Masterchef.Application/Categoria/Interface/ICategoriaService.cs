using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Masterchef.Application.Categoria.Interface
{
    public interface ICategoriaService
    {
        IEnumerable<SelectListItem> ListDropDown();
    }
}
