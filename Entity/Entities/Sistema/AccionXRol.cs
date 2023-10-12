using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities.Sistema
{
    public class AccionXRol
    {
        private int id;
        private Rol rol;
        private Accion accion;

        public int AccionXRolId
        {
            get { return id; }
            set { id = value; }
        }
        public Rol Rol
        {
            get { return rol; }
            set { rol = value; }
        }

        public Accion Accion
        {
            get { return accion; }
            set { accion = value; }
        }
    }
}
