﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities.Sistema
{
    public class Usuario
    {
        private int id;
        private string nombre;
        private Rol rol;

        public int UsuarioId
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public virtual Rol Rol
        {
            get { return rol; }
            set { rol = value; }
        }
    }
}
