using DAL;
using DesafioProsegur.Models;
using Entity.Common;

namespace DesafioProsegur.Bussines
{
    public interface IPedidoMediator
    {
        JsonReturn GuardarPedido(PedidoViewModel oViewModel);
    }

    public class PedidoMediator: IPedidoMediator
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly GestorMateriasPrima _gestorMateriasPrima;
        private readonly GestorItems _gestorItems;
        private readonly GestorPedido _gestorPedido;
        private readonly GestorOrdenes _gestorOrdenes;

        public PedidoMediator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _gestorItems = new GestorItems(_unitOfWork);
            _gestorMateriasPrima = new GestorMateriasPrima(_unitOfWork, _gestorItems);
            _gestorOrdenes = new GestorOrdenes(_unitOfWork, _gestorMateriasPrima, _gestorItems);
            _gestorPedido = new GestorPedido(_unitOfWork, _gestorOrdenes, _gestorItems, _gestorMateriasPrima);
        }

        public JsonReturn GuardarPedido(PedidoViewModel oViewModel)
        {
            var resul = _gestorPedido.ValidarPedido(oViewModel);
            if (!resul.Success)
                return resul;

            var items = _gestorItems.ObtenerItemsByIds(oViewModel.Items);

            resul = _gestorMateriasPrima.ValidarStockDisponible(oViewModel.Items, items);
            if (!resul.Success)
                return resul;

            var pedido = _gestorPedido.CrearPedido(oViewModel.Items);
            _gestorPedido.GuardarPedido(_unitOfWork, pedido);

            resul = _gestorOrdenes.GestionarOrdenesTrabajo(oViewModel, pedido, items);
            if (!resul.Success)
                return resul;


            return resul;
        }
    }
}
