using Entity.Entities;
using DAL.Context;
using System;
using System.Collections.Generic;

namespace DAL.Repositories;

public interface IProvinciaRepository
{
}
public class ProvinciaRepository : IProvinciaRepository
{
    private readonly EFContext _context;

    public ProvinciaRepository(EFContext efContext)
    {
        _context = efContext;
    }
}
