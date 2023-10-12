using Microsoft.EntityFrameworkCore;
using DAL.Context;
using System;
using System.Collections.Generic;
using Entity.Entities.Sistema;

namespace DAL.Repositories.Sistema;

public interface IAccionRepository
{
    void Iniciar();
}
public class AccionRepository : IAccionRepository
{
    private readonly EFContext _context;

    public AccionRepository(EFContext efContext)
    {
        _context = efContext;
    }

    public void Iniciar()
    {
        if (_context.Accion.Count() == 0)
        {
            Accion acc1 = new Accion();
            acc1.Nombre = "Item";

            Accion acc2 = new Accion();
            acc2.Nombre = "MateriaPrima";

            Accion acc3 = new Accion();
            acc3.Nombre = "Pedido";

            Accion acc4 = new Accion();
            acc4.Nombre = "OrdenTrabajo";

            Accion acc5 = new Accion();
            acc5.Nombre = "Factura";

            _context.Accion.Add(acc1);
            _context.Accion.Add(acc2);
            _context.Accion.Add(acc3);
            _context.Accion.Add(acc4);
            _context.Accion.Add(acc5);
        }
    }
}
