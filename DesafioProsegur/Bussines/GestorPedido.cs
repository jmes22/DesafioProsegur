using DAL;
using DesafioProsegur.Models;
using Entity.Common;
using Entity.Entities;
using Entity.Entities.BuilderOrdenTrabajo;
using Entity.Entities.BuilderPedido;

namespace DesafioProsegur.Bussines
{
    public class GestorPedido
    {
        private IUnitOfWork unitOfWork;
        private readonly GestorOrdenes gestorOrdenes;
        private readonly GestorItems gestorItems;
        private readonly GestorMateriasPrima gestorMateriasPrima;

        public GestorPedido(IUnitOfWork unitOfWork, GestorOrdenes _gestorOrdenes, GestorItems _gestorItems,GestorMateriasPrima _gestorMateriasPrima)
        {
            this.unitOfWork = unitOfWork;
            this.gestorOrdenes = _gestorOrdenes;
            this.gestorItems = _gestorItems;
            this.gestorMateriasPrima = _gestorMateriasPrima;
        }

        public Pedido CrearPedido(ICollection<ItemsViewModel> itemsViewModel) {
            var pedido = new PedidoBuilder()
              .WithPrecio(calcularPreciooViewModel(itemsViewModel))
              .WithFechaInicio(DateTime.Now)
              .Build();

            return pedido;
        }

        public void GuardarPedido(IUnitOfWork unitOfWork, Pedido pedido)
        {
            unitOfWork.PedidoRepository.Guardar(pedido);
        }

        private double calcularPreciooViewModel(ICollection<ItemsViewModel> itemsViewModel)
        {
            double precioTotal = 0;

            foreach (var item in itemsViewModel)
            {
                precioTotal += (item.Cantidad * item.Precio);
            }

            return precioTotal;
        }

        public JsonReturn ValidarPedido(PedidoViewModel oViewModel)
        {
            string msjError = string.Empty;

            if (oViewModel == null)
                return JsonReturn.ErrorConMsjSimple();

            if (oViewModel?.Items == null)
            {
                msjError += "Tiene que seleccionar al menos un producto.</br>";
                return JsonReturn.ErrorConMsjSimple(msjError);
            }

            if (oViewModel?.Items.Count == 0) msjError += "Tiene que seleccionar al menos un producto.</br>";
            else
            {
                var itemsCantidadCero = oViewModel?.Items.Where(x => x.Cantidad <= 0).ToList();

                if (itemsCantidadCero?.Count > 0)
                {
                    foreach (var item in itemsCantidadCero)
                    {
                        msjError += "El item: " + item.Nombre + " tiene que tener una cantidad mayor que 0.</br>";
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(msjError))
                return JsonReturn.ErrorConMsjSimple(msjError);

            return JsonReturn.SuccessSinRetorno();
        }
    }
}
