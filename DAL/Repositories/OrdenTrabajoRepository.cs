using DAL.Context;
using Entity.Entities;
using System;
using System.Collections.Generic;

namespace DAL.Repositories;

public interface IOrdenTrabajoRepository
{
    void Guardar(ICollection<OrdenTrabajo> OrdenesTrabajo);
}
public class OrdenTrabajoRepository : IOrdenTrabajoRepository
{
    private readonly EFContext _context;

    public OrdenTrabajoRepository(EFContext efContext)
    {
        _context = efContext;
    }

    public void Guardar(ICollection<OrdenTrabajo> OrdenesTrabajo)
    {
        _context.OrdenTrabajo.AddRange(OrdenesTrabajo);
    }
}
