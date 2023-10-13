using Entity.Common.Enums;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using DAL.Context;
using System;
using System.Collections.Generic;

namespace DAL.Repositories;

public interface IEstadoRepository
{
    Estado? GetById(int id);
    ICollection<Estado> GetAll();
}

public class EstadoRepository : IEstadoRepository
{
    private readonly EFContext _context;

    public EstadoRepository(EFContext efContext)
    {
        _context = efContext;
    }

    public ICollection<Estado> GetAll()
    {
        return _context.Estado.ToList();
    }

    public Estado? GetById(int id)
    {
        return _context.Estado.Where(x => x.EstadoId == id).FirstOrDefault();
    }

  
}
