using DAL.Context;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DAL.Repositories;

public interface IOrdenTrabajoRepository
{
    OrdenTrabajo? GetById(int id);
    void Guardar (OrdenTrabajo ordenTrabajo);
    void Guardar(ICollection<OrdenTrabajo> OrdenesTrabajo);
}
public class OrdenTrabajoRepository : IOrdenTrabajoRepository
{
    private readonly EFContext _context;

    public OrdenTrabajoRepository(EFContext efContext)
    {
        _context = efContext;
    }

    public OrdenTrabajo? GetById(int id)
    {
        return _context.OrdenTrabajo
                       .Where(x => x.OrdenTrabajoId == id)
                       .Include(x => x.Item)
                       .Include(x => x.Estado)
                       .FirstOrDefault();
    }
    public void Guardar(OrdenTrabajo otActualizado)
    {
        var otExistente = _context.OrdenTrabajo.FirstOrDefault(m => m.OrdenTrabajoId == otActualizado.OrdenTrabajoId);

        if (otExistente != null) 
            _context.Entry(otExistente).CurrentValues.SetValues(otActualizado);
        else
            _context.OrdenTrabajo.Add(otActualizado);
    }

    public void Guardar(ICollection<OrdenTrabajo> OrdenesTrabajo)
    {
        foreach (var otActualizado in OrdenesTrabajo)
        {
            Guardar(otActualizado);
        }
    }
}
