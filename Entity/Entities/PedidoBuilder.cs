using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class PedidoBuilder
    {
        private Pedido pedido = new Pedido();

        public PedidoBuilder WithId(int id)
        {
            pedido.PedidoId = id;
            return this;
        }

        public PedidoBuilder WithFechaInicio(DateTime fechaInicio)
        {
            pedido.FechaInicio = fechaInicio;
            return this;
        }

        public PedidoBuilder WithFechaFin(DateTime? fechaFin)
        {
            pedido.FechaFin = fechaFin;
            return this;
        }

        public PedidoBuilder WithPrecio(double precio)
        {
            pedido.Precio = precio;
            return this;
        }

        public PedidoBuilder WithOrdenes(ICollection<OrdenTrabajo> ordenes)
        {
            pedido.Ordenes = ordenes;
            return this;
        }

        public Pedido Build()
        {
            return pedido;
        }
    }
}
