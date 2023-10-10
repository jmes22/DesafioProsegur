using Entity.Entities;

namespace DesafioProsegur.Models
{
    public class ItemsViewModel
    {
        public int IdItem { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        public double Total { get; set; }
    }
}