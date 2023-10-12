using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities.BuilderOrdenTrabajo
{
    public class OrdenTrabajoBuilder
    {
        private OrdenTrabajo ordenTrabajo = new OrdenTrabajo();

        public OrdenTrabajoBuilder WithId(int id)
        {
            ordenTrabajo.OrdenTrabajoId = id;
            return this;
        }

        public OrdenTrabajoBuilder WithFechaInicio(DateTime fechaInicio)
        {
            ordenTrabajo.FechaInicio = fechaInicio;
            return this;
        }

        public OrdenTrabajoBuilder WithPrecio(double precio)
        {
            ordenTrabajo.Precio = precio;
            return this;
        }

        public OrdenTrabajoBuilder WithFechaFin(DateTime? fechaFin)
        {
            ordenTrabajo.FechaFin = fechaFin;
            return this;
        }

        public OrdenTrabajoBuilder WithEstado(Estado estado)
        {
            ordenTrabajo.Estado = estado;
            return this;
        }

        public OrdenTrabajoBuilder WithItem(Item item)
        {
            ordenTrabajo.Item = item;
            return this;
        }

        public OrdenTrabajoBuilder WithPedido(Pedido pedido)
        {
            ordenTrabajo.Pedido = pedido;
            return this;
        }

        public OrdenTrabajo Build()
        {
            return ordenTrabajo;
        }
    }
}
