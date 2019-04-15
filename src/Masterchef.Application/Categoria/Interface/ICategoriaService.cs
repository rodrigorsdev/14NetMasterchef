using Masterchef.Application.Categoria.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Masterchef.Application.Categoria.Interface
{
    public interface ICategoriaService
    {
        IEnumerable<SelectListItem> ListDropDown();
        void Add(AddCategoria vmodel);
        IEnumerable<ListCategoria> List();
    }
}
