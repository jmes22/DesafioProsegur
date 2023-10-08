﻿namespace Entity.Entities
{
    internal class Pedido
    {
        private int id;
        private DateTime fechaInicio;
        private DateTime? fechaFin;
        private double precio;
        private ICollection<OrdenTrabajo> ordenes;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime FechaInicio
        {
            get { return fechaInicio; }
            set { fechaInicio = value; }
        }

        public DateTime? FechaFin
        {
            get { return fechaFin; }
            set { fechaFin = value; }
        }
        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        public ICollection<OrdenTrabajo> Ordenes
        {
            get { return ordenes; }
            set { ordenes = value; }
        }
    }
}