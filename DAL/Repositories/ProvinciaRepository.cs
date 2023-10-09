using Entity.Entities;
using DAL.Context;
using System;
using System.Collections.Generic;

namespace DAL.Repositories;

public interface IProvinciaRepository
{
    void Iniciar();
}
public class ProvinciaRepository : IProvinciaRepository
{
    private readonly EFContext _context;

    public ProvinciaRepository(EFContext efContext)
    {
        _context = efContext;
    }

    public void Iniciar()
    {
        if (_context.Provincia.Count() == 0)
        {
            var impuesto = _context.Impuesto.Local.Where(x => x.Nombre == "AI").FirstOrDefault();
            
            Provincia oProv1 = new Provincia();
            oProv1.Nombre = "Córdoba";
            oProv1.Impuesto = impuesto;

            impuesto = _context.Impuesto.Local.Where(x => x.Nombre == "IVA").FirstOrDefault();
            Provincia oProv2 = new Provincia();
            oProv2.Nombre = "La Rioja"; 
            oProv2.Impuesto = impuesto;

            impuesto = _context.Impuesto.Local.Where(x => x.Nombre == "IE").FirstOrDefault();
            Provincia oProv3 = new Provincia();
            oProv3.Nombre = "Salta";
            oProv3.Impuesto = impuesto;

            _context.Provincia.Add(oProv1);
            _context.Provincia.Add(oProv2);
            _context.Provincia.Add(oProv3);
        }
    }
}
