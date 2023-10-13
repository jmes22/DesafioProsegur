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
            if (oViewModel == null)
                return Json(JsonReturn.ErrorConMsjSimple());

            oViewModel.ValidarModelo(oViewModel, out string msjError);
            if (!string.IsNullOrEmpty(msjError))
                return Json(JsonReturn.ErrorConMsjSimple(msjError));

            var estado = _unitOfwork.EstadoRepository.GetById((int)EstadoEnum.PENDIENTE);
            if (estado == null) return Json(JsonReturn.ErrorConMsjSimple());

            ICollection<OrdenTrabajo> ordenesTrabajo = new List<OrdenTrabajo>();

            double precioTotal = 0;

            var pedido = new PedidoBuilder()
           .WithFechaInicio(DateTime.Now)
           .Build();

            foreach (var item in oViewModel.Items)
            {
                var itemBD = _unitOfwork.ItemRepository.GetById(item.IdItem);
                if (itemBD == null) return Json(JsonReturn.ErrorConMsjSimple());

                msjError = validarStockDisponible(itemBD, item.Cantidad);

                if (!string.IsNullOrEmpty(msjError))
                    return Json(JsonReturn.ErrorConMsjSimple(msjError));

                for (int i = 0; i < item.Cantidad; i++)
                {
                    var ordenTrabajo = new OrdenTrabajoBuilder()
                    .WithPrecio(item.Precio)
                    .WithPedido(pedido)
                    .WithEstado(estado)
                    .WithItem(itemBD)
                    .Build();

                    ordenesTrabajo.Add(ordenTrabajo);
                }

                precioTotal += (item.Cantidad * item.Precio);
            }

            pedido.Precio = precioTotal;

            _unitOfwork.PedidoRepository.Guardar(pedido);
            _unitOfwork.OrdenTrabajoRepository.Guardar(ordenesTrabajo);
            actualizarStockMateriaPrima(ordenesTrabajo);

            _unitOfwork.CommitTransaction();

            return Json(JsonReturn.SuccessSinRetorno());
        }

        private string validarStockDisponible(Item item, int cantidad)
        {
            string msjCabecera = $"Stock insuficiente para el item {item.Nombre}.  </br>";
            string msjError = string.Empty;

            var gruposMateriasPrima = item.MateriasPrimaXItem
                                       .Select(mpxi => mpxi.MateriaPrima) 
                                       .GroupBy(mp => mp.MateriaPrimaId); 

            foreach (var grupo in gruposMateriasPrima)
            {
                var mp = grupo.First();
                int cantidadTotalRequerida = grupo.Count() * cantidad;

                if (mp.Stock < cantidadTotalRequerida)
                    msjError += $"Stock actual de {mp.Nombre}: {mp.Stock}. </br> Cantidad requerida: {cantidadTotalRequerida}. </br>";
            }

            return string.IsNullOrEmpty(msjError) ? msjError : msjCabecera + " " + msjError;
        }

        private void actualizarStockMateriaPrima(ICollection<OrdenTrabajo> ordenes)
        {
            ICollection<MateriaPrima> materiasPrima = new List<MateriaPrima>();

            foreach (var orden in ordenes)
            {
                if (orden.Item == null) continue;
                if (orden.Item.MateriasPrimaXItem == null) continue;

                foreach (var mpxi in orden.Item.MateriasPrimaXItem)
                {
                    var mp = materiasPrima.Where(x => x.MateriaPrimaId == mpxi.MateriaPrima.MateriaPrimaId).FirstOrDefault();

                    if (mp != null) mp.Stock = mp.Stock - 1;
                    else
                    {
                        mpxi.MateriaPrima.Stock += -1;
                        materiasPrima.Add(mpxi.MateriaPrima);
                    }
                }
            }

            _unitOfwork.MateriaPrimaRepository.Guardar(materiasPrima);
        }
    }
}