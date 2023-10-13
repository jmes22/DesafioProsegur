using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities.Sistema
{
    public class Accion
    {
        private int id;
        private string nombre;
        private string controller;
        private string accionController;

        public int AccionId
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Controller
        {
            get { return controller; }
            set { controller = value; }
        }

        public string AccionController
        {
            get { return accionController; }
            set { accionController = value; }
        }
    }
}
