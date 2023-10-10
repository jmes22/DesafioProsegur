using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class DetalleFactura
    {
        private int id;
        private int idFactura;
        private Factura factura;

        public int DetalleFacturaId
        {
            get { return id; }
            set { id = value; }
        }

        public int FacturaId
        {
            get { return idFactura; }
            set { idFactura = value; }
        }

        public virtual Factura Factura
        {
            get { return factura; }
            set { factura = value; }
        }
    }
}
