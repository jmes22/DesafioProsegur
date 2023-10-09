using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using DAL.Context;
using System;
using System.Collections.Generic;

namespace DAL.Repositories;

public interface IImpuestoRepository
{

}
public class ImpuestoRepository : IImpuestoRepository
{
    private readonly EFContext _context;

    public ImpuestoRepository(EFContext efContext)
    {
        _context = efContext;
    }

}
