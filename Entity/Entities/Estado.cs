using Entity.Common.Enums;
using Entity.Entities.StrategyEstado;

namespace Entity.Entities
{
    public class Estado
    {
        private int id;
        private string nombre;
        private IStateStrategy stateStrategy;

        public int EstadoId
        {
            get { return id; }
            set 
            { 
                id = value;
                obtenerEstrategia();
            }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private void obtenerEstrategia()
        {
            switch (EstadoId)
            {
                case (int)EstadoEnum.PENDIENTE:
                    stateStrategy = new EstadoEjecucionStrategy();
                    break;
                case (int)EstadoEnum.EJECUCION:
                    stateStrategy = new EstadoFinalizadoStrategy();
                    break;
                case (int)EstadoEnum.FINALIZADO:
                    stateStrategy = new EstadoFinalizadoStrategy();
                    break;
                default:
                    stateStrategy = new EstadoPendienteStrategy();
                    break;
            }
        }

        public void Ejectuar(OrdenTrabajo orden,ICollection<Estado> estados)
        {
            stateStrategy.Ejecutar(orden, estados);
        }
    }
}
