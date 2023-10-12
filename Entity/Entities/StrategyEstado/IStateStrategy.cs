using Entity.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities.StrategyEstado
{
    public interface IStateStrategy
    {
        Estado ObtenerEstado(ICollection<OrdenTrabajo> ordenes);
        void Ejecutar(OrdenTrabajo orden, ICollection<Estado> estados);
    }
}
