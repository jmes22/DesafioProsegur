using DAL;
using DesafioProsegur.Bussines;
using DesafioProsegur.Models;
using Entity.Common;
using Entity.Common.Enums;
using Entity.Entities;
using Entity.Entities.BuilderOrdenTrabajo;
using Entity.Entities.BuilderPedido;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DesafioProsegur.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly IPedidoMediator _pedidoMediator;

        public PedidoController(
            IUnitOfWork unitOfwork,
            IPedidoMediator pedidoMediator
            )
        {
            _unitOfwork = unitOfwork;
            _pedidoMediator = pedidoMediator;
        }

        public IActionResult Index()
        {
            if (!SessionManager.TienePermiso(HttpContext, _unitOfwork, this.ControllerContext.ActionDescriptor.ControllerName))
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            var pedidos = _unitOfwork.PedidoRepository.GetAll();
            List<object> result = new List<object>();

            foreach (var pedido in pedidos)
            {
                var estado = pedido.Estado;
                if (estado == null) estado = _unitOfwork.EstadoRepository.GetById((int)EstadoEnum.EJECUCION);

                result.Add(new
                {
                    id = pedido.PedidoId,
                    fechaInicio = pedido.FechaInicio.ToString("dd/MM/yyyy:HH:mm:ss"),
                    fechaFin = pedido.FechaFin,
                    precio = pedido.Precio,
                    estado = estado?.Nombre,
                });
            }

            return Json(JsonReturn.SuccessConRetorno(result));
        }

        [HttpPost]
        public JsonResult Guardar(PedidoViewModel oViewModel)
        {
            var resultado = _pedidoMediator.GuardarPedido(oViewModel);

            if (resultado.Success)
                _unitOfwork.CommitTransaction();

            return Json(resultado);
        }
    }
}