using DAL.Context;
using System;
using System.Collections.Generic;

namespace DAL.Repositories;

public interface IOrdenTrabajoRepository
{

}
public class OrdenTrabajoRepository : IOrdenTrabajoRepository
{
    private readonly EFContext _context;

    public OrdenTrabajoRepository(EFContext efContext)
    {
        _context = efContext;
    }
}
