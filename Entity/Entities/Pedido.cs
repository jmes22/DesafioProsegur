using Entity.Common.Enums;
using Entity.Entities.StrategyEstado;

namespace Entity.Entities
{
    public class Pedido
    {
        private int id;
        private DateTime fechaInicio;
        private DateTime? fechaFin;
        private double precio;
        private ICollection<OrdenTrabajo> ordenes;

        private IStateStrategy stateStrategy;

        public int PedidoId
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime FechaInicio
        {
            get { return fechaInicio; }
            set { fechaInicio = value; }
        }

        public DateTime? FechaFin
        {
            get { return fechaFin; }
            set { fechaFin = value; }
        }
        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        public Estado Estado
        {
            get { return obtenerEstado(); }
        }
        public virtual ICollection<OrdenTrabajo> Ordenes
        {
            get { return ordenes; }
            set { ordenes = value; }
        }

        private Estado obtenerEstado()
        {
            if (this.ordenes.All(x => x.Estado.EstadoId == (int)EstadoEnum.PENDIENTE))
                return ordenes.Select(x => x.Estado).Where(x => x.EstadoId == (int)EstadoEnum.PENDIENTE).First();
            
            if (this.ordenes.All(x => x.Estado.EstadoId == (int)EstadoEnum.FINALIZADO))
                return ordenes.Select(x => x.Estado).Where(x => x.EstadoId == (int)EstadoEnum.FINALIZADO).First();

            return ordenes.Select(x => x.Estado).Where(x => x.EstadoId == (int)EstadoEnum.EJECUCION).First();
        }
    }
}