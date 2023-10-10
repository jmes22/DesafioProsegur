namespace Entity.Entities
{
    public class Estado
    {
        private int id;
        private string nombre;

        public int EstadoId
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
    }
}
