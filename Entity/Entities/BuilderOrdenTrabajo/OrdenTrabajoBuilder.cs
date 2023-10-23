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
            if (precio < 0)
                throw new ArgumentException("El precio no puede ser un valor negativo.", nameof(precio));

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
            if (item == null)
                throw new ArgumentNullException(nameof(item), "El elemento no puede ser nulo.");

            ordenTrabajo.Item = item;
            return this;
        }

        public OrdenTrabajoBuilder WithPedido(Pedido pedido)
        {
            if (pedido == null)
                throw new ArgumentNullException(nameof(pedido), "El elemento no puede ser nulo.");

            ordenTrabajo.Pedido = pedido;
            return this;
        }

        public OrdenTrabajo Build()
        {
            if (ordenTrabajo.Pedido == null)
                throw new ArgumentNullException(nameof(ordenTrabajo.Pedido), "El elemento no puede ser nulo.");

            if (ordenTrabajo.Item == null)
                throw new ArgumentNullException(nameof(ordenTrabajo.Item), "El elemento no puede ser nulo.");

            if (ordenTrabajo.Precio < 0)
                throw new ArgumentException("El precio no puede ser un valor negativo.", nameof(ordenTrabajo.Precio));

            return ordenTrabajo;
        }
    }
}
