using Entity.Entities;

namespace DesafioProsegur.Models
{
    public class PedidoViewModel
    {
        public ICollection<ItemsViewModel> Items { get; set; }

        public PedidoViewModel() { }

        public PedidoViewModel(ICollection<Item> items)
        {
            this.Items = new List<ItemsViewModel>();

            foreach (var item in items)
            {
                this.Items.Add(
                    new ItemsViewModel 
                    { 
                        IdItem = item.ItemId,
                        Nombre = item.Nombre, 
                        Precio = item.Precio,
                        Cantidad = 0 ,
                        Total = 0
                    });
            }
        }

    }
}