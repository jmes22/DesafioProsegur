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
            if (!SessionManager.TienePermiso(HttpContext, _unitOfwork, this.ControllerContext.ActionDescriptor.ControllerName))
                return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult DetalleFactura(int idFactura, int idPedido)
        {
            FacturaViewModel viewModel = new FacturaViewModel();
            viewModel.Id = idFactura;

            var factura = idFactura == 0 ? null : _unitOfwork.FacturaRepository.GetById(idFactura);
              
            if (idFactura != 0 && factura == null)
                return RedirectToAction("Index");

            var pedido = idFactura != 0 ? factura?.DetalleFactura.First().Pedido : _unitOfwork.PedidoRepository.GetById(idPedido);

            if (pedido == null)
                return RedirectToAction("Index");

            crearModelo(viewModel, pedido);
            return View(viewModel);
        }

        private void crearModelo(FacturaViewModel viewModel, Pedido pedido) {
            viewModel.IdPedido = pedido.PedidoId;

            var ordenesTrabajo = pedido?.Ordenes?.GroupBy(x => x.Item);
            if (ordenesTrabajo != null)
            {
                foreach (var orden in ordenesTrabajo)
                {
                    var ordenTrabjo = orden.First();

                    var id = ordenTrabjo.Item.ItemId;
                    var nombre = ordenTrabjo.Item.Nombre;
                    var precio = ordenTrabjo.Precio;
                    var cantidad = orden.Count();
                    var total = orden.Sum(x => x.Precio);

                    viewModel.ItemsViewModel.Add(new ItemsViewModel(id, nombre, precio, cantidad, total));
                }
            }

            viewModel.FechaPedido = pedido.FechaInicio.ToString("dd/MM/yyyy:HH:mm:ss");
            viewModel.PrecioTotal = pedido.Precio;
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            var facturas = _unitOfwork.FacturaRepository.GetAll();
            var pedidos = _unitOfwork.PedidoRepository.GetAll();

            ICollection<FacturaViewModel> viewModel = new List<FacturaViewModel>();

            foreach (var factura in facturas)
            {
                var pedido = factura.DetalleFactura.Select(x => x.Pedido).FirstOrDefault();
                if (pedido == null) continue;
                viewModel.Add(new FacturaViewModel(factura, pedido));
            }

            var pedidosNoEnModelo = pedidos.Where(pedido => !viewModel.Any(vm => vm.IdPedido == pedido.PedidoId));

            foreach (var pedido in pedidosNoEnModelo)
            {
                if (pedido.Estado.EstadoId != (int)EstadoEnum.FINALIZADO) continue;

                viewModel.Add(new FacturaViewModel(pedido));
            }

            return Json(JsonReturn.SuccessConRetorno(viewModel));
        }

        [HttpPost]
        public JsonResult Guardar(int idPedido)
        {
            var pedido = _unitOfwork.PedidoRepository.GetById(idPedido);
            if (pedido == null)
                return Json(JsonReturn.ErrorConMsjSimple());

            Factura factura = new Factura();
            factura.Fecha = DateTime.Now;

            DetalleFactura detalle = new DetalleFactura();
            detalle.Factura = factura;
            detalle.Pedido = pedido;

            _unitOfwork.FacturaRepository.Guardar(factura);
            _unitOfwork.DetalleFacturaRepository.Guardar(detalle);
            _unitOfwork.CommitTransaction();

            return Json(JsonReturn.SuccessSinRetorno());
        }
    }
}