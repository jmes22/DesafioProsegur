using DAL;
using DesafioProsegur.Models;
using Entity.Common;
using Entity.Common.Enums;
using Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DesafioProsegur.Controllers
{
    public class FacturaController : Controller
    {
        private readonly IUnitOfWork _unitOfwork;

        public FacturaController(
            IUnitOfWork unitOfwork
            )
        {
            _unitOfwork = unitOfwork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DetalleFactura(int idFactura, int idPedido)
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            var facturas = _unitOfwork.FacturaRepository.GetAll();
            var pedidos = _unitOfwork.PedidoRepository.GetAll().Where(p => p.Estado.EstadoId == (int)EstadoEnum.FINALIZADO).ToList();
            ICollection<FacturaViewModel> viewModel = new List<FacturaViewModel>();

            foreach (var factura in facturas)
            {
                var pedido = factura.DetalleFactura.Select(x => x.Pedido).FirstOrDefault();

                viewModel.Add(new FacturaViewModel
                {
                    Id = factura.FacturaId,
                    IdPedido = pedido?.PedidoId ?? 0,
                    FechaFactura = factura.Fecha.ToString("dd/MM/yyyy:HH:mm:ss"),
                    Precio = pedido?.Precio ?? 0
                });
            }

            var pedidosNoEnModelo = pedidos.Where(pedido => !viewModel.Any(vm => vm.IdPedido == pedido.PedidoId));

            foreach (var pedido in pedidosNoEnModelo)
            {
                viewModel.Add(new FacturaViewModel
                {
                    Id = 0, 
                    IdPedido = pedido.PedidoId,
                    FechaFactura = "", 
                    Precio = pedido.Precio
                });
            }

            return Json(JsonReturn.SuccessConRetorno(viewModel));
        }
    }
}