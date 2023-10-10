using Entity.Common.Enums;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using DAL.Context;
using System;
using System.Collections.Generic;

namespace DAL.Repositories;

public interface IDetalleFacturaRepository
{

}

public class DetalleFacturaRepository : IDetalleFacturaRepository
{
    private readonly EFContext _context;

    public DetalleFacturaRepository(EFContext efContext)
    {
        _context = efContext;
    }
}
