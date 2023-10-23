using Entity.Entities.BuilderOrdenTrabajo;
using Entity.Entities;
using Entity.Common;
using DAL;
using FakeItEasy;
using DesafioProsegur.Bussines;
using DesafioProsegur.Models;
using Microsoft.EntityFrameworkCore;
using DAL.Context;

namespace TestProject
{
    public class UnitTestPedidoMediator
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PedidoMeadiator_oViewMOdelNull_ErrorConMsjSimple()
        {
            // Arrange
            var result = JsonReturn.ErrorConMsjSimple();

            var unitOfWork = A.Fake<IUnitOfWork>();
            var pedidoMediator = A.Fake<PedidoMediator>(x => x.WithArgumentsForConstructor(new object[] { unitOfWork }));

            // Act
            var resultGuardarPedido = pedidoMediator.GuardarPedido(null);

            // Assert
            Assert.That(result.Success, Is.EqualTo(resultGuardarPedido.Success));
            Assert.That(result.MensajeError, Is.EqualTo(resultGuardarPedido.MensajeError));
        }

        [Test]
        public void PedidoMeadiator_ItemsNull_ErrorConMsjSimple()
        {
            // Arrange
            var result = JsonReturn.ErrorConMsjSimple("Tiene que seleccionar al menos un producto.</br>");

            var unitOfWork = A.Fake<IUnitOfWork>();
            var pedidoMediator = A.Fake<PedidoMediator>(x => x.WithArgumentsForConstructor(new object[] { unitOfWork }));

            var oViewModel = A.Fake<PedidoViewModel>();

            // Act
            var resultGuardarPedido = pedidoMediator.GuardarPedido(oViewModel);

            // Assert
            Assert.That(result.Success, Is.EqualTo(resultGuardarPedido.Success));
            Assert.That(result.MensajeError, Is.EqualTo(resultGuardarPedido.MensajeError));
        }
    }
}