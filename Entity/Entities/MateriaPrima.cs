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

        public virtual ICollection<MateriaPrimaXProvincia> MateriaPrimaXProvincia { get; set; } = new List<MateriaPrimaXProvincia>();
        public virtual ICollection<MateriaPrimaXItem> MateriaPrimaXItem { get; set; } = new List<MateriaPrimaXItem>();
    }
}
