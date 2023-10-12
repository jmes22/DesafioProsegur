using Entity.Entities;

namespace DesafioProsegur.Models
{
    public class FacturaViewModel
    {
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public string FechaFactura { get; set; }
        public double Precio { get; set; }
    }
}