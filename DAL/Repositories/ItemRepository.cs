using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using DAL.Context;
using System;
using System.Collections.Generic;

namespace DAL.Repositories;

public interface IItemRepository
{

}
public class ItemRepository : IItemRepository
{
    private readonly EFContext _context;

    public ItemRepository(EFContext efContext)
    {
        _context = efContext;
    }
}
