using Entity.Entities;

namespace DesafioProsegur.Models
{
    public class PedidoViewModel
    {
        public ICollection<Item> Items { get; set; }
    }
}