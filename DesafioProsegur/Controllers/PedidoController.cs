using DAL;
using DesafioProsegur.Models;
using Entity.Common;
using Entity.Common.Enums;
using Entity.Entities;
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
            var estado = _unitOfwork.EstadoRepository.GetById((int)EstadoEnum.PENDIENTE);
            if (estado == null) return Json(JsonReturn.ErrorConMsjSimple("No se encontró el estado"));

            ICollection<OrdenTrabajo> ordenesTrabajo = new List<OrdenTrabajo>();

            double precioTotal = 0;

            var pedido = new PedidoBuilder()
           .WithFechaInicio(DateTime.Now)
           .WithPrecio(precioTotal)
           .Build();

            foreach (var item in oViewModel.Items)
            {
                var itemBD = _unitOfwork.ItemRepository.GetById(item.IdItem);

                var ordenTrabajo = new OrdenTrabajoBuilder()
                 .WithFechaInicio(DateTime.Now)
                 .WithPedido(pedido)
                 .WithEstado(estado)
                 .WithItem(itemBD)
                 .Build();

                ordenesTrabajo.Add(ordenTrabajo);
                precioTotal += (item.Cantidad * item.Precio);
            }

       

            _unitOfwork.PedidoRepository.Guardar(pedido);
            _unitOfwork.OrdenTrabajoRepository.Guardar(ordenesTrabajo);
            _unitOfwork.CommitTransaction();

            return Json(JsonReturn.SuccessSinRetorno());
        }
    }
}