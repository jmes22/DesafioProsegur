using Entity.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities.StrategyEstado
{
    public class EstadoEjecucionStrategy : IStateStrategy
    {
        public Estado ObtenerEstado(ICollection<OrdenTrabajo> ordenes)
        {
            return ordenes.Select(x => x.Estado).Where(x => x.EstadoId == (int)EstadoEnum.EJECUCION).First();
        }

        public void Ejecutar(OrdenTrabajo orden, ICollection<Estado> estados)
        {
            orden.FechaFin = DateTime.Now;
            orden.Estado = estados.Where(x => x.EstadoId == (int)EstadoEnum.EJECUCION).First();
        }
    }
}
