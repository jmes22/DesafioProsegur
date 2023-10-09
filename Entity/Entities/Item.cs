using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Item
    {
        private int id;
        private string nombre;
        private int tiempoEjecucion;
        private ICollection<MateriaPrimaXItem> materiasPrimaXItem;

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
            get { return calcularPrecio(); }
        }

        public virtual ICollection<MateriaPrimaXItem> MateriasPrimaXItem
        {
            get { return materiasPrimaXItem; }
            set { materiasPrimaXItem = value; }
        }

        private double calcularPrecio() {
            double precioItem = 0;

            if (this.materiasPrimaXItem != null && this.materiasPrimaXItem.Count > 0)
            {
                foreach (var mpxi in this.materiasPrimaXItem)
                {
                    double precio = mpxi.MateriaPrima.Precio;
                    precioItem = precio * (1 + mpxi.Provincia.Impuesto.Porcentaje);
                }
            }

            return precioItem;
        }
    }
}
