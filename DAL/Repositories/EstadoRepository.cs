using Entity.Common.Enums;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using DAL.Context;
using System;
using System.Collections.Generic;

namespace DAL.Repositories;

public interface IEstadoRepository
{
    void Iniciar();
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

    public void Iniciar()
    {
        if (_context.Estado.Count() == 0)
        {
            Estado oEstado1 = new Estado();
            oEstado1.Nombre = "PENDIENTE";

            Estado oEstado2 = new Estado();
            oEstado2.Nombre = "EJECUCION";

            Estado oEstado3 = new Estado();
            oEstado3.Nombre = "FINALIZADO";

            _context.Estado.Add(oEstado1);
            _context.Estado.Add(oEstado2);
            _context.Estado.Add(oEstado3);
        }
    }
}
