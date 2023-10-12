using DAL;
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
    public class OrdenTrabajoController : Controller
    {
        private readonly IUnitOfWork _unitOfwork;

        public OrdenTrabajoController(
            IUnitOfWork unitOfwork
            )
        {
            _unitOfwork = unitOfwork;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetOrdenesTrabajo()
        {
            var pedidos = _unitOfwork.PedidoRepository.GetAll();
            List<object> result = new List<object>();

            if (pedidos == null)
                return Json(JsonReturn.SuccessConRetorno(result));

            foreach (var pedido in pedidos)
            {
                var ordenes = pedido.Ordenes
                                    .Where(x => x.Estado.EstadoId == (int)EstadoEnum.PENDIENTE ||
                                           x.Estado.EstadoId == (int)EstadoEnum.EJECUCION);

                foreach (var orden in ordenes)
                {
                    result.Add(new
                    {
                        id = orden.OrdenTrabajoId,
                        idPedido = pedido.PedidoId,
                        fechaPedido = pedido.FechaInicio.ToString("dd/MM/yyyy:HH:mm:ss"),
                        fechaInicio = orden.FechaInicio.ToString("dd/MM/yyyy:HH:mm:ss"),
                        fechaFin = orden.FechaFin == null ? "" : orden.FechaFin.Value.ToString("dd/MM/yyyy:HH:mm:ss"),
                        estado = orden.Estado.Nombre,
                        tiempoEstimadoFin = orden.Item.TiempoEjecucion
                    });
                }
            }

            return Json(JsonReturn.SuccessConRetorno(result));
        }

        [HttpGet]
        public JsonResult GetOrdenesTrabajoByIdPedido(int idPedido)
        {
                var pedido = _unitOfwork.PedidoRepository.GetById(idPedido);
            List<object> result = new List<object>();
           
            if (pedido == null)
                return Json(JsonReturn.SuccessConRetorno(result));

            foreach (var orden in pedido.Ordenes)
            {
                result.Add(new
                {
                    id = orden.OrdenTrabajoId,
                    idPedido = pedido.PedidoId,
                    fechaPedido = pedido.FechaInicio.ToString("dd/MM/yyyy:HH:mm:ss"),
                    fechaInicio = orden.FechaInicio.ToString("dd/MM/yyyy:HH:mm:ss"),
                    fechaFin = orden.FechaFin == null ? "" : orden.FechaFin.Value.ToString("dd/MM/yyyy:HH:mm:ss"),
                    estado = orden.Estado.Nombre,
                    tiempoEstimadoFin = orden.Item.TiempoEjecucion
                });
            }

            return Json(JsonReturn.SuccessConRetorno(result));
        }

        [HttpPost]
        public JsonResult Ejecutar(int idOrdenTrabajo)
        {
            var orden = _unitOfwork.OrdenTrabajoRepository.GetById(idOrdenTrabajo);
            object result = new object();

            if (orden == null)
                return Json(JsonReturn.SuccessConRetorno(result));

            var estados = _unitOfwork.EstadoRepository.GetAll();
            orden.Estado.Ejectuar(orden, estados);

            _unitOfwork.OrdenTrabajoRepository.Guardar(orden);
            _unitOfwork.CommitTransaction();

            if (estados.Count > 0)
            {
                result = new
                {
                    id = orden.OrdenTrabajoId,
                    fechaInicio = orden.FechaInicio.ToString("dd/MM/yyyy:HH:mm:ss"),
                    fechaFin = orden.FechaFin == null ? "" : orden.FechaFin.Value.ToString("dd/MM/yyyy:HH:mm:ss"),
                    estado = orden.Estado.Nombre,
                    tiempoEstimadoFin = orden.FechaInicio.AddMinutes(orden.Item.TiempoEjecucion) - orden.FechaInicio
                };
            }
       
            return Json(JsonReturn.SuccessConRetorno(result));
        }
    }
}