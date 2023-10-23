using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using DAL.Context;
using System;
using System.Collections.Generic;

namespace DAL.Repositories;

public interface IItemRepository
{
    ICollection<Item> GetAll();
    Item? GetById(int id);
    ICollection<Item> GetItemsByIds(ICollection<int> idsItem);
}
public class ItemRepository : IItemRepository
{
    private readonly EFContext _context;

    public ItemRepository(EFContext efContext)
    {
        _context = efContext;
    }

    public ICollection<Item> GetAll()
    {
        IQueryable<Item> query = _context.Item
                                 .Include(i => i.MateriasPrimaXItem)
                                    .ThenInclude(mp => mp.MateriaPrima)
                                 .Include(i => i.MateriasPrimaXItem)
                                    .ThenInclude(mp => mp.Provincia)
                                    .ThenInclude(imp => imp.Impuesto);

        return query.ToList();
    }

    public ICollection<Item> GetItemsByIds(ICollection<int> idsItems)
    {
        IQueryable<Item> query = _context.Item
                                 .Include(i => i.MateriasPrimaXItem)
                                    .ThenInclude(mp => mp.MateriaPrima)
                                 .Include(i => i.MateriasPrimaXItem)
                                    .ThenInclude(mp => mp.Provincia)
                                    .ThenInclude(imp => imp.Impuesto)
                                 .Where(i => idsItems.Contains(i.ItemId));
        return query.ToList();
    }

    public Item? GetById(int id)
    {
        return _context.Item.Where(x => x.ItemId == id)
                            .Include(i => i.MateriasPrimaXItem)
                            .ThenInclude(mp => mp.MateriaPrima)
                            .FirstOrDefault();
    }
}
