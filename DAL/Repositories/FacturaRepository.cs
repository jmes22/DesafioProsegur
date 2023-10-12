using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using DAL.Context;
using System;
using System.Collections.Generic;

namespace DAL.Repositories;

public interface IFacturaRepository
{
    Factura? GetById(int id);
    ICollection<Factura> GetAll();
    void Guardar(Factura factura);
}
public class FacturaRepository : IFacturaRepository
{
    private readonly EFContext _context;

    public FacturaRepository(EFContext efContext)
    {
        _context = efContext;
    }

    public ICollection<Factura> GetAll()
    {
        return _context.Factura
            .Include(f => f.DetalleFactura)
                .ThenInclude(p => p.Pedido)
            .ToList();
    }

    public Factura? GetById(int id)
    {
        return _context.Factura
            .Where(x => x.FacturaId == id)
            .Include(df => df.DetalleFactura)
            .ThenInclude(df => df.Pedido)
            .ThenInclude(p => p.Ordenes)
            .ThenInclude(o => o.Item)
            .FirstOrDefault();
    }

    public void Guardar(Factura factura)
    {
        _context.Factura.Add(factura);
    }
}
