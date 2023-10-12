using Entity.Entities;

namespace DesafioProsegur.Models
{
    public class ItemsViewModel
    {
        public ItemsViewModel() { }

        public ItemsViewModel(int id, string nombre, double precio, int cantidad, double total)
        {
            IdItem = id;
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;
            Total = total;
        }

        public int IdItem { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        public double Total { get; set; }
    }
}