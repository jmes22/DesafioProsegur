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
        private int precio;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int Precio
        {
            get { return precio; }
            set { precio = value; }
        }
    }
}
