using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    internal class DetalleFactura
    {
        private int id;
        private ICollection<Pedido> pedidos;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public ICollection<Pedido> Pedidos
        {
            get { return pedidos; }
            set { pedidos = value; }
        }
    }
}
