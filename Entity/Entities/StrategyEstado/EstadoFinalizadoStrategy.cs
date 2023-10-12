using Entity.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities.StrategyEstado
{
    public class EstadoFinalizadoStrategy : IStateStrategy
    {
        public Estado ObtenerEstado(ICollection<OrdenTrabajo> ordenes)
        {
            return ordenes.Select(x => x.Estado).Where(x => x.EstadoId == (int)EstadoEnum.FINALIZADO).First();
        }

        public void Ejecutar(OrdenTrabajo orden, ICollection<Estado> estados)
        {
            orden.Estado = estados.Where(x => x.EstadoId == (int)EstadoEnum.FINALIZADO).First(); 
            orden.FechaFin = DateTime.Now;
        }
    }
}
