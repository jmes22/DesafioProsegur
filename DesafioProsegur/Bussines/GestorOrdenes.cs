using DAL;
using DesafioProsegur.Models;
using Entity.Entities.BuilderPedido;
using Entity.Entities;
using Entity.Common;
using Entity.Entities.BuilderOrdenTrabajo;
using Entity.Common.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DesafioProsegur.Bussines
{
    public class GestorOrdenes
    {
        private IUnitOfWork unitOfWork;
        private GestorItems gestorItems;
        private GestorMateriasPrima gestorMateriasPrima;

        public GestorOrdenes(
            IUnitOfWork unitOfWork, 
            GestorMateriasPrima _gestorMateriasPrima,
            GestorItems _gestorItems)
        {
            this.unitOfWork = unitOfWork;
            this.gestorMateriasPrima = _gestorMateriasPrima;
            this.gestorItems = _gestorItems;
        }

        public JsonReturn GestionarOrdenesTrabajo(PedidoViewModel oViewModel, Pedido pedido, ICollection<Item> items)
        {
            var estado = unitOfWork.EstadoRepository.GetById((int)EstadoEnum.PENDIENTE);
            if (estado == null) return JsonReturn.ErrorConMsjSimple();

            var ordenesTrabajo = crearOrdenesTrabajo(oViewModel, pedido, estado, items);
            unitOfWork.OrdenTrabajoRepository.Guardar(ordenesTrabajo);
            gestorMateriasPrima.ActualizarStockMateriaPrima(ordenesTrabajo);

            return JsonReturn.SuccessSinRetorno();
        }

        private ICollection<OrdenTrabajo> crearOrdenesTrabajo(PedidoViewModel oViewModel, Pedido pedido, Estado estado, ICollection<Item> items)
        {
            ICollection<OrdenTrabajo> ordenesTrabajo = new List<OrdenTrabajo>();

            foreach (var item in oViewModel.Items)
            {
                for (int i = 0; i < item.Cantidad; i++)
                {
                    var ordenTrabajo = crearOrdenTrabajo(pedido, estado, gestorItems.ObtenerItemById(item.IdItem, items));
                    ordenesTrabajo.Add(ordenTrabajo);
                }
            }

            return ordenesTrabajo;
        }

        private OrdenTrabajo crearOrdenTrabajo(
            Pedido pedido,
            Estado estado,
            Item item)
        {
            var ordenTrabajo = new OrdenTrabajoBuilder()
                    .WithPrecio(pedido.Precio)
                    .WithPedido(pedido)
                    .WithEstado(estado)
                    .WithItem(item)
                    .Build();

            return ordenTrabajo;
        }
    }
}
