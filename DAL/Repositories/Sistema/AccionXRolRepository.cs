using Microsoft.EntityFrameworkCore;
using DAL.Context;
using System;
using System.Collections.Generic;
using Entity.Entities.Sistema;

namespace DAL.Repositories.Sistema;

public interface IAccionXRolRepository
{
}
public class AccionXRolRepository : IAccionXRolRepository
{
    private readonly EFContext _context;

    public AccionXRolRepository(EFContext efContext)
    {
        _context = efContext;
    }
}
