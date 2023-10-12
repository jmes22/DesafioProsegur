using Entity.Common.Enums;
using Entity.Entities.StrategyEstado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class OrdenTrabajo
    {
        private int id;
        private DateTime fechaInicio;
        private DateTime? fechaFin;
        private Pedido pedido;
        private Estado estado;
        private Item item;

        public int OrdenTrabajoId
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime FechaInicio
        {
            get { return fechaInicio; }
            set { fechaInicio = value; }
        }

        public DateTime? FechaFin
        {
            get { return fechaFin; }
            set { fechaFin = value; }
        }

        public virtual Pedido Pedido
        {
            get { return pedido; }
            set { pedido = value; }
        }

        public virtual Estado Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public virtual Item Item
        {
            get { return item; }
            set { item = value; }
        }
    }
}
