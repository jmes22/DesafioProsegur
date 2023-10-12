using Entity.Entities;

namespace DesafioProsegur.Models
{
    public class FacturaViewModel
    {
        public FacturaViewModel()
        {
            ItemsViewModel = new List<ItemsViewModel>();
        }

        public FacturaViewModel(Factura factura, Pedido pedido)
        {
            Id = factura.FacturaId;
            IdPedido = pedido?.PedidoId ?? 0;
            FechaFactura = factura.Fecha.ToString("dd/MM/yyyy:HH:mm:ss");
            PrecioTotal = pedido?.Precio ?? 0;
        }

        public FacturaViewModel(Pedido pedido)
        {
            Id = 0;
            IdPedido = pedido.PedidoId;
            FechaFactura = "";
            PrecioTotal = pedido.Precio;
        }

        public int Id { get; set; }
        public int IdPedido { get; set; }
        public string FechaFactura { get; set; }
        public string FechaPedido { get; set; }
        public double PrecioTotal { get; set; }
        public ICollection<ItemsViewModel> ItemsViewModel { get; set; }
    }
}