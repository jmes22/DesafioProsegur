using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Provincia
    {
        private int id;
        private string nombre;
        private Impuesto impuesto;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public Impuesto Impuesto
        {
            get { return impuesto; }
            set { impuesto = value; }
        }
    }
}
