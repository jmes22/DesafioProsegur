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
        private ICollection<Pedido> pedidos;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int IdFactura
        {
            get { return idFactura; }
            set { idFactura = value; }
        }

        public virtual Factura Factura
        {
            get { return factura; }
            set { factura = value; }
        }

        public virtual ICollection<Pedido> Pedidos
        {
            get { return pedidos; }
            set { pedidos = value; }
        }
    }
}
