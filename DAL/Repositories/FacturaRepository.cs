using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using DAL.Context;
using System;
using System.Collections.Generic;

namespace DAL.Repositories;

public interface IFacturaRepository
{

}
public class FacturaRepository : IFacturaRepository
{
    private readonly EFContext _context;

    public FacturaRepository(EFContext efContext)
    {
        _context = efContext;
    }
}
