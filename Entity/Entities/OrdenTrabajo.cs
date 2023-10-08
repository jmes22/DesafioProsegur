using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    internal class OrdenTrabajo
    {
        private int id;
        private int idPedido;
        private DateTime fechaInicio;
        private DateTime? fechaFin;
        private Estado estado;
        private Item item;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int IdPedido
        {
            get { return idPedido; }
            set { idPedido = value; }
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

        public Estado Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public Item Item
        {
            get { return item; }
            set { item = value; }
        }
    }
}
