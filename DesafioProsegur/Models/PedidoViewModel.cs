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

        public void ValidarModelo(PedidoViewModel oViewModel, out string msjError)
        { 
            msjError = string.Empty;

            if (oViewModel?.Items == null)
            {
                msjError += "Tiene que seleccionar al menos un producto.</br>";
                return;
            }

            if (oViewModel?.Items.Count == 0) msjError += "Tiene que seleccionar al menos un producto.</br>";
            else
            {
                var itemsCantidadCero = oViewModel?.Items.Where(x => x.Cantidad == 0).ToList();

                if (itemsCantidadCero.Count > 0)
                {
                    foreach (var item in itemsCantidadCero)
                    {
                        msjError += "El item: " + item.Nombre + " tiene que tener una cantidad mayor que 0.</br>";
                    }
                }
            }

           
        }
    }
}