using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Ususario
    {
        private int id;
        private ICollection<Rol> roles;

        public int UsusarioId
        {
            get { return id; }
            set { id = value; }
        }

        public virtual ICollection<Rol> Roles
        {
            get { return roles; }
            set { roles = value; }
        }
    }
}
