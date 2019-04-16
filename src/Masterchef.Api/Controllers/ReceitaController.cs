using Masterchef.Application.Receita.Interface;
using Masterchef.Application.Receita.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Masterchef.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitaController : ControllerBase
    {
        private readonly IReceitaService _receitaService;

        public ReceitaController(IReceitaService receitaService)
        {
            _receitaService = receitaService;
        }

        [HttpGet("{termSearch}")]
        public ActionResult<IEnumerable<ReceitaIndex>> Get(string termSearch)
        {
            IEnumerable<ReceitaIndex> result = new List<ReceitaIndex>();

            try
            {
                result = _receitaService.Listar(termSearch);
            }
            catch (Exception e)
            {
                return BadRequest("Erro ao buscar o termo pesquisado!");
            }

            return Ok(result);
        }

        [Authorize, HttpPost]
        public IActionResult Post([FromBody] ReceitaAdd vmodel)
        {
            try
            {
                _receitaService.Add(vmodel);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(vmodel);
        }
    }
}