using Entity.Common.Enums;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using DAL.Context;
using System;
using System.Collections.Generic;

namespace DAL.Repositories;

public interface IEstadoRepository
{

}

public class EstadoRepository : IEstadoRepository
{
    private readonly EFContext _context;

    public EstadoRepository(EFContext efContext)
    {
        _context = efContext;
    }
    
}
