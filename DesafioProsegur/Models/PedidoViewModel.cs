using Entity.Entities;

namespace DesafioProsegur.Models
{
    public class PedidoViewModel
    {
        public ICollection<ItemsViewModel> Items { get; set; }

        public PedidoViewModel() 
        {
            this.Items = new List<ItemsViewModel>();
        }

        public PedidoViewModel(ICollection<Item> items)
        {
            this.Items = new List<ItemsViewModel>();

            foreach (var item in items)
            {
                this.Items.Add(
                    new ItemsViewModel(item.ItemId, item.Nombre, item.Precio, 0, 0)
                );
            }
        }
    }
}