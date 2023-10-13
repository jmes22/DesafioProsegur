using DAL;
using DesafioProsegur.Models;
using Entity.Common;
using Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DesafioProsegur.Controllers
{
    public class ItemController : Controller
    {
        private readonly IUnitOfWork _unitOfwork;

        public ItemController(
            IUnitOfWork unitOfwork
            )
        {
            _unitOfwork = unitOfwork;
        }

        public IActionResult Index()
        {
            if (!SessionManager.TienePermiso(HttpContext, _unitOfwork, this.ControllerContext.ActionDescriptor.ControllerName))
                return RedirectToAction("Index", "Home");

            var items = _unitOfwork.ItemRepository.GetAll();
            PedidoViewModel viewModel = new PedidoViewModel(items);

            return View(viewModel);
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            var items = _unitOfwork.ItemRepository.GetAll();
            List<object> result = new List<object>();

            foreach (var item in items)
            {
                result.Add(new { 
                    id = item.ItemId,
                    nombre = item.Nombre,
                    precio = item.Precio,
                    cantidad = 0
                });
            }

            return Json(JsonReturn.SuccessConRetorno(result));
        }
    }
}