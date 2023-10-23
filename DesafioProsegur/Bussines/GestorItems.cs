using DAL;
using DesafioProsegur.Models;
using Entity.Common;
using Entity.Entities;

namespace DesafioProsegur.Bussines
{
    public class GestorItems
    {
        private IUnitOfWork unitOfWork;

        public GestorItems(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ICollection<Item> ObtenerItemsByIds(ICollection<ItemsViewModel> itemsViewModel)
        {
            var ids = itemsViewModel.Select(i => i.IdItem).ToList();

            var items = unitOfWork.ItemRepository.GetItemsByIds(ids);
            if (items == null) return new List<Item>();

            return items;
        }

        public Item ObtenerItemById(int itemId, ICollection<Item> items)
        {
            return items.Where(i => i.ItemId == itemId).First();
        }
    }
}
