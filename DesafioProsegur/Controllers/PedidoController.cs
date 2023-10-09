using DAL;
using DesafioProsegur.Models;
using Entity.Common;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DesafioProsegur.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IUnitOfWork _unitOfwork;

        public PedidoController(
            IUnitOfWork unitOfwork
            )
        {
            _unitOfwork = unitOfwork;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Guardar(PedidoViewModel oViewModel)
        {
            return Json(JsonReturn.SuccessSinRetorno());
        }
    }
}