using Microsoft.EntityFrameworkCore;
using DAL.Context;
using System;
using System.Collections.Generic;
using Entity.Entities.Sistema;

namespace DAL.Repositories.Sistema;

public interface IAccionRepository
{

}
public class AccionRepository : IAccionRepository
{
    private readonly EFContext _context;

    public AccionRepository(EFContext efContext)
    {
        _context = efContext;
    }
}
