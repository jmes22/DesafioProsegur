using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class MateriaPrimaXProvincia
    {
        private int id;
        private int idProvincia;
        private int idMateriaPrima;
        private Provincia provincia;
        private MateriaPrima materiaPrima;


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int IdProvincia
        {
            get { return idProvincia; }
            set { idProvincia = value; }
        }

        public int IdMateriaPrima
        {
            get { return idMateriaPrima; }
            set { idMateriaPrima = value; }
        }

        public virtual Provincia Provincia
        {
            get { return provincia; }
            set { provincia = value; }
        }

        public virtual MateriaPrima MateriaPrima
        {
            get { return materiaPrima; }
            set { materiaPrima = value; }
        }

    }
}
