using Masterchef.Application.Receita.Interface;
using Masterchef.Application.Receita.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Masterchef.Web.Controllers
{
    [Authorize]
    public class ReceitaController : Controller
    {
        private readonly IReceitaService _receitaService;

        public ReceitaController(IReceitaService receitaService)
        {
            _receitaService = receitaService;
        }

        [AllowAnonymous]
        public IActionResult Index(string term)
        {
            IEnumerable<ReceitaIndex> result = new List<ReceitaIndex>();

            try
            {
                result = _receitaService.Listar(term);
            }
            catch (Exception e)
            {
                TempData["errorMessage"] = "Erro ao processar sua requisição!";
            }

            return View(result);
        }
    }
}