using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities.Sistema
{
    public class Rol
    {
        private int id;
        private string nombre;
        private ICollection<AccionXRol> accionXRol;

        public int RolId
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public ICollection<AccionXRol> AccionXRol
        {
            get { return accionXRol; }
            set { accionXRol = value; }
        }
    }
}
