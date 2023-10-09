using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using DAL.Context;
using System;
using System.Collections.Generic;

namespace DAL.Repositories;

public interface IImpuestoRepository
{
    void Iniciar();
}
public class ImpuestoRepository : IImpuestoRepository
{
    private readonly EFContext _context;

    public ImpuestoRepository(EFContext efContext)
    {
        _context = efContext;
    }

    public void Iniciar()
    {
        if (_context.Impuesto.Count() == 0)
        {
            Impuesto oImpuesto1 = new Impuesto();
            oImpuesto1.Nombre = "AI";
            oImpuesto1.Porcentaje = 5;

            Impuesto oImpuesto2 = new Impuesto();
            oImpuesto2.Nombre = "IE";
            oImpuesto2.Porcentaje = 10;

            Impuesto oImpuesto3 = new Impuesto();
            oImpuesto3.Nombre = "IVA";
            oImpuesto3.Porcentaje = 25;

            _context.Impuesto.Add(oImpuesto1);
            _context.Impuesto.Add(oImpuesto2);
            _context.Impuesto.Add(oImpuesto3);
        }
    }
}
