using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Factura
    {
        private int id;
        private DateTime fecha;
        ICollection<DetalleFactura> detalleFactura;

        public int FacturaId
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public ICollection<DetalleFactura> DetalleFactura
        {
            get { return detalleFactura; }
            set { detalleFactura = value; }
        }
    }
}
