using Microsoft.EntityFrameworkCore;
using DAL.Context;
using System;
using System.Collections.Generic;
using Entity.Entities.Sistema;

namespace DAL.Repositories.Sistema;

public interface IRolRepository
{
    Rol? GetByRol(string rolActual);
}
public class RolRepository : IRolRepository
{
    private readonly EFContext _context;

    public RolRepository(EFContext efContext)
    {
        _context = efContext;
    }

    public Rol? GetByRol(string rolActual)
    {
        return _context.Rol
            .Include(x => x.AccionXRol)
                .ThenInclude(a => a.Accion)
            .Where(x => x.Nombre.ToUpper().Equals(rolActual.ToUpper()))
            .FirstOrDefault();
    }
}
