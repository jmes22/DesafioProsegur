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

        public virtual Impuesto Impuesto
        {
            get { return impuesto; }
            set { impuesto = value; }
        }

        public virtual ICollection<MateriaPrimaXItem> MateriasPrimaXItem
        {
            get { return materiasPrimaXItem; }
            set { materiasPrimaXItem = value; }
        }
    }
}
