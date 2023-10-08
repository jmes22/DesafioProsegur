using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    internal class MateriaPrima
    {
        private int id;
        private string nombre;
        private double precio;
        private Provincia provincia;

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

        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public Provincia Provincia
        {
            get { return provincia; }
            set { provincia = value; }
        }
    }
}
