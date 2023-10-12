using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class MateriaPrima
    {
        private int id;
        private string nombre;
        private int stock;
        private double precio;

        public int MateriaPrimaId
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }
    }
}
