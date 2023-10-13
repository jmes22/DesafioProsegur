using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using DAL.Context;
using System;
using System.Collections.Generic;

namespace DAL.Repositories;

public interface IMateriaPrimaXItemRepository
{
}
public class MateriaPrimaXItemRepository : IMateriaPrimaXItemRepository
{
    private readonly EFContext _context;

    public MateriaPrimaXItemRepository(EFContext efContext)
    {
        _context = efContext;
    }
}