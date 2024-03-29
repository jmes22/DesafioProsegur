using Entity.Entities.BuilderOrdenTrabajo;
using Entity.Entities;

namespace TestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void UnitTestOrdenTrabajoBuilder()
        {
            // Arrange
            double precio = 100.0;
            Pedido pedido = new Pedido(); 
            pedido.FechaInicio = DateTime.Now;

            Estado estado = new Estado();
            estado.EstadoId = 1;
            estado.Nombre = "PENDIENTE";

            Item item = new Item();
            item.ItemId = 1;
            item.Nombre = "S�MORES FRAPPUCCINO";
            item.TiempoEjecucion = 1;

            // Act
            var ordenTrabajo = new OrdenTrabajoBuilder()
                .WithPrecio(precio)
                .WithPedido(pedido)
                .WithEstado(estado)
                .WithItem(item)
                .Build();

            // Assert
            Assert.That(ordenTrabajo.Precio, Is.EqualTo(precio));
            Assert.That(ordenTrabajo.Pedido, Is.EqualTo(pedido));
            Assert.That(ordenTrabajo.Estado, Is.EqualTo(estado));
            Assert.That(ordenTrabajo.Item, Is.EqualTo(item));
        }

        [Test]
        public void OrdenTrabajoBuilder_PrecioInvalido_ThrowsException()
        {
            double precio = -1.0;

            Assert.Throws<ArgumentException>(() =>
            {
                var ordenTrabajo = new OrdenTrabajoBuilder()
                    .WithPrecio(precio)
                    .Build();
            });
        }

        [Test]
        public void OrdenTrabajoBuilder_NullPedido_ThrowsException()
        {
            Pedido pedido = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                var ordenTrabajo = new OrdenTrabajoBuilder()
                    .WithPrecio(100.0)
                    .WithPedido(pedido)
                    .WithEstado(new Estado())
                    .WithItem(new Item())
                    .Build();
            });
        }

        [Test]
        public void OrdenTrabajoBuilder_NullItem_ThrowsException()
        {
            Item item = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                var ordenTrabajo = new OrdenTrabajoBuilder()
                    .WithPrecio(100.0)
                    .WithPedido(new Pedido())
                    .WithEstado(new Estado())
                    .WithItem(item)
                    .Build();
            });
        }
    }
}