using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    internal class Ususario
    {
        private int id;
        private ICollection<Rol> roles;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public ICollection<Rol> Roles
        {
            get { return roles; }
            set { roles = value; }
        }
    }
}
