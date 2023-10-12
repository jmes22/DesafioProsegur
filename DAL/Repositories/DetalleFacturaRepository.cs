using Entity.Common.Enums;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using DAL.Context;
using System;
using System.Collections.Generic;

namespace DAL.Repositories;

public interface IDetalleFacturaRepository
{
    void Guardar(DetalleFactura detalle);
}

public class DetalleFacturaRepository : IDetalleFacturaRepository
{
    private readonly EFContext _context;

    public DetalleFacturaRepository(EFContext efContext)
    {
        _context = efContext;
    }

    public void Guardar(DetalleFactura detalle)
    {
        _context.DetalleFactura.Add(detalle);
    }
}
