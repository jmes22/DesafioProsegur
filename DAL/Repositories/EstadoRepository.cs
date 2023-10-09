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
}

public class EstadoRepository : IEstadoRepository
{
    private readonly EFContext _context;

    public EstadoRepository(EFContext efContext)
    {
        _context = efContext;
    }

    public void Iniciar()
    {
        if (_context.Estado.Count() == 0)
        {
            Estado oEstado1 = new Estado();
            oEstado1.Nombre = "en espera";

            Estado oEstado2 = new Estado();
            oEstado2.Nombre = "en ejecución";

            Estado oEstado3 = new Estado();
            oEstado3.Nombre = "en pausa";

            Estado oEstado4 = new Estado();
            oEstado4.Nombre = "finalizada";

            _context.Estado.Add(oEstado1);
            _context.Estado.Add(oEstado2);
            _context.Estado.Add(oEstado3);
            _context.Estado.Add(oEstado4);
        }
    }
}
