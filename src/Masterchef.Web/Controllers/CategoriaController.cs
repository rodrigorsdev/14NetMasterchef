using Masterchef.Application.Categoria.Interface;
using Masterchef.Core.Application.Interface;
using Masterchef.Core.Application.Vo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Masterchef.Web.Controllers
{
    [Authorize]
    public class CategoriaController : BaseController
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(
            INotificationHandler<Notification> notifications,
            ICategoriaService categoriaService) : base(notifications)
        {
            _categoriaService = categoriaService;
        }

        [ValidateAntiForgeryToken, HttpPost]
        public JsonResult Add(Application.Categoria.ViewModel.AddCategoria vmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _categoriaService.Add(vmodel);

                    if (ValidOperation())
                        return Json(new { result = true, list = _categoriaService.List(), message = "Inserido com sucesso!" });
                }
            }
            catch (Exception e)
            {
            }

            AddMessages();

            return Json(new { result = false, list = "", message = "Erro ao inserir!" });
        }
    }
}
