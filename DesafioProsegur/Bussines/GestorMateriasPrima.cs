using DAL;
using DesafioProsegur.Models;
using Entity.Common;
using Entity.Entities;
using Entity.Entities.BuilderOrdenTrabajo;

namespace DesafioProsegur.Bussines
{
    public class GestorMateriasPrima
    {
        private IUnitOfWork unitOfWork;
        private GestorItems gestorItems;

        public GestorMateriasPrima(IUnitOfWork unitOfWork, GestorItems gestorItems)
        {
            this.unitOfWork = unitOfWork;
            this.gestorItems = gestorItems;
        }

        public JsonReturn ValidarStockDisponible(ICollection<ItemsViewModel> itemsViewModel, ICollection<Item> items)
        {
            string msjError = string.Empty;

            foreach (var itemViewModel in itemsViewModel)
            {
                var item = gestorItems.ObtenerItemById(itemViewModel.IdItem, items);
                msjError += validarStockDisponible(item, itemViewModel.Cantidad);
            }

            if (!string.IsNullOrWhiteSpace(msjError))
                return JsonReturn.ErrorConMsjSimple(msjError);

            return JsonReturn.SuccessSinRetorno();
        }

        private string validarStockDisponible(Item item, int cantidad)
        {
            string msjCabecera = $"Stock insuficiente para el item {item.Nombre}.  </br>";
            string msjError = string.Empty;

            var gruposMateriasPrima = item.MateriasPrimaXItem
                                       .Select(mpxi => mpxi.MateriaPrima)
                                       .GroupBy(mp => mp.MateriaPrimaId);

            foreach (var grupo in gruposMateriasPrima)
            {
                var mp = grupo.First();
                int cantidadTotalRequerida = grupo.Count() * cantidad;

                if (mp.Stock < cantidadTotalRequerida)
                    msjError += $"Stock actual de {mp.Nombre}: {mp.Stock}. </br> Cantidad requerida: {cantidadTotalRequerida}. </br>";
            }

            return string.IsNullOrEmpty(msjError) ? msjError : msjCabecera + " " + msjError;
        }

        public void ActualizarStockMateriaPrima(ICollection<OrdenTrabajo> ordenes)
        {
            ICollection<MateriaPrima> materiasPrima = new List<MateriaPrima>();

            foreach (var orden in ordenes)
            {
                if (orden.Item == null) continue;
                if (orden.Item.MateriasPrimaXItem == null) continue;

                foreach (var mpxi in orden.Item.MateriasPrimaXItem)
                {
                    var mp = materiasPrima.Where(x => x.MateriaPrimaId == mpxi.MateriaPrima.MateriaPrimaId).FirstOrDefault();

                    if (mp != null) mp.Stock = mp.Stock - 1;
                    else
                    {
                        mpxi.MateriaPrima.Stock += -1;
                        materiasPrima.Add(mpxi.MateriaPrima);
                    }
                }
            }

            guardarMateriaPrima(materiasPrima);
        }

        private void guardarMateriaPrima(ICollection<MateriaPrima> materiasPrima)
        {
            unitOfWork.MateriaPrimaRepository.Guardar(materiasPrima);
        }
    }
}
