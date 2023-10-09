using Entity.Common.Enums;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using DAL.Context;
using System;
using System.Collections.Generic;

namespace DAL.Repositories;

public interface IDetalleFacturaRepository
{
    public int GetCantidad(int id, int idPropiedad);
}

public class DetalleFacturaRepository : IDetalleFacturaRepository
{
    private readonly EFContext _context;

    public DetalleFacturaRepository(EFContext efContext)
    {
        _context = efContext;
    }

    public int GetCantidad(int id, int idPropiedad)
    {
        try
        {
            var ambienteXPropiedad = _context.Estado.ToList();
            if (ambienteXPropiedad == null) return 0;

            return 1;
        }
        catch (Exception ex)
        {
            var a = 0;
            throw;
        }
      
    }
}
