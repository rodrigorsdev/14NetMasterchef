using Masterchef.Application.Categoria.Interface;
using Masterchef.Application.Ingrediente.Interface;
using Masterchef.Application.Receita.Interface;
using Masterchef.Application.Receita.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace Masterchef.Web.Controllers
{
    [Authorize]
    public class ReceitaController : Controller
    {
        private readonly IReceitaService _receitaService;
        private readonly ICategoriaService _categoriaService;
        private readonly IIngredienteService _ingredienteService;

        public ReceitaController(
            IReceitaService receitaService,
            ICategoriaService categoriaService,
            IIngredienteService ingredienteService)
        {
            _receitaService = receitaService;
            _categoriaService = categoriaService;
            _ingredienteService = ingredienteService;
        }

        [AllowAnonymous]
        public IActionResult Index(string termSearch)
        {
            IEnumerable<ReceitaIndex> result = new List<ReceitaIndex>();

            try
            {
                ViewData["termSearch"] = termSearch;
                result = _receitaService.Listar(termSearch);
            }
            catch (Exception)
            {
                TempData["errorMessage"] = "Erro ao processar sua requisição!";
            }

            return View(result);
        }

        public IActionResult Add()
        {
            ViewBag.Categorias = _categoriaService.ListDropDown();
            ViewBag.Ingredientes = _ingredienteService.ListDropDown();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ReceitaAdd vmodel, IFormFile image)
        {
            try
            {
                vmodel.Imagem = ConvetToByteArray(image);
            }
            catch (Exception e)
            {
                
            }

            return View();
        }

        private byte[] ConvetToByteArray(IFormFile file)
        {
            byte[] result = null;

            if (file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                }
            }

            return result;
        }
    }
}