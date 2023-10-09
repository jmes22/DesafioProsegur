using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class MateriaPrimaXItem
    {
        private int id;
        private int idItem;
        private int idMateriaPrima;
        private Item item;
        private MateriaPrima materiaPrima;


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int IdItem
        {
            get { return idItem; }
            set { idItem = value; }
        }

        public int IdMateriaPrima
        {
            get { return idMateriaPrima; }
            set { idMateriaPrima = value; }
        }

        public virtual Item Item
        {
            get { return item; }
            set { item = value; }
        }

        public virtual MateriaPrima MateriaPrima
        {
            get { return materiaPrima; }
            set { materiaPrima = value; }
        }

    }
}
