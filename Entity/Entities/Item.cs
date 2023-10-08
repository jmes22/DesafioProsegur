using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    internal class Item
    {
        private int id;
        private string nombre;
        private int tiempoEjecucion;
        private double precio;
        private ICollection<MateriaPrima> materiasPrima;

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

        public int TiempoEjecucion
        {
            get { return tiempoEjecucion; }
            set { tiempoEjecucion = value; }
        }

        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public ICollection<MateriaPrima> MateriasPrima
        {
            get { return materiasPrima; }
            set { materiasPrima = value; }
        }
    }
}
