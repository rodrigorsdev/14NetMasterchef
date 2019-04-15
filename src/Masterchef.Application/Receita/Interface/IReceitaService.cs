using Masterchef.Application.Receita.ViewModel;
using System.Collections.Generic;

namespace Masterchef.Application.Receita.Interface
{
    public interface IReceitaService
    {
        IEnumerable<ReceitaIndex> Listar(string term);
        void Add(ReceitaAdd vmodel);
    }
}
