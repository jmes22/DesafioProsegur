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
        private Item item;
        private MateriaPrima materiaPrima;
        private Provincia provincia;

        public int MateriaPrimaXItemId
        {
            get { return id; }
            set { id = value; }
        }

        //public int ItemId
        //{
        //    get { return idItem; }
        //    set { idItem = value; }
        //}

        //public int MateriaPrimaId
        //{
        //    get { return idMateriaPrima; }
        //    set { idMateriaPrima = value; }
        //}
        //public int ProvinciaId
        //{
        //    get { return idProvincia; }
        //    set { idProvincia = value; }
        //}

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

        public virtual Provincia Provincia
        {
            get { return provincia; }
            set { provincia = value; }
        }
    }
}
