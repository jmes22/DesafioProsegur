using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using DAL.Context;
using System;
using System.Collections.Generic;

namespace DAL.Repositories;

public interface IItemRepository
{
    void Iniciar();
}
public class ItemRepository : IItemRepository
{
    private readonly EFContext _context;

    public ItemRepository(EFContext efContext)
    {
        _context = efContext;
    }

    public void Iniciar()
    {
        if (_context.Item.Count() == 0)
        {
            Item oItem1 = new Item();
            oItem1.Nombre = "S’MORES FRAPPUCCINO";
            oItem1.TiempoEjecucion = 1;

            Item oItem2 = new Item();
            oItem2.Nombre = "ICED CINNAMON DOLCE LATTE";
            oItem2.TiempoEjecucion = 2;

            _context.Item.Add(oItem1);
            _context.Item.Add(oItem2);
        }
    }
}
