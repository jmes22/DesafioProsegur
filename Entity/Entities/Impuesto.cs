using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Impuesto
    {
        private int id;
        private string nombre;
        private double porcentaje;

        public int ImpuestoId
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public double Porcentaje
        {
            get { return porcentaje; }
            set { porcentaje = value; }
        }
    }
}
