using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using DAL.Context;
using System;
using System.Collections.Generic;

namespace DAL.Repositories;

public interface IMateriaPrimaXItemRepository
{
    void Iniciar();
}
public class MateriaPrimaXItemRepository : IMateriaPrimaXItemRepository
{
    private readonly EFContext _context;

    public MateriaPrimaXItemRepository(EFContext efContext)
    {
        _context = efContext;
    }

    public void Iniciar()
    {
        if (_context.MateriaPrimaXItem.Count() == 0 
            && _context.Item.Local.Count() > 0
            && _context.MateriaPrima.Local.Count() > 0
            && _context.Provincia.Local.Count() > 0
            )
        {
            var items = _context.Item.Local.ToList();
            var materiasPrima = _context.MateriaPrima.Local.ToList();
            var provincias = _context.Provincia.Local.ToList();

            var mPrima = materiasPrima.Where(x => x.Nombre == "Leche").FirstOrDefault();
            var provincia = provincias.Where(p => p.Nombre == "Córdoba").FirstOrDefault();
            var item = items.Where(p => p.Nombre == "S’MORES FRAPPUCCINO").FirstOrDefault();

            MateriaPrimaXItem oNuevo1 = new MateriaPrimaXItem();
            oNuevo1.Item = item;
            oNuevo1.MateriaPrima = mPrima;
            oNuevo1.Provincia = provincia;

            mPrima = materiasPrima.Where(x => x.Nombre == "Cacao").FirstOrDefault();

            MateriaPrimaXItem oNuevo2 = new MateriaPrimaXItem();
            oNuevo2.Item = item;
            oNuevo2.MateriaPrima = mPrima;
            oNuevo2.Provincia = provincia;

            MateriaPrimaXItem oNuevo3 = new MateriaPrimaXItem();
            oNuevo3.Item = item;
            oNuevo3.MateriaPrima = mPrima;
            oNuevo3.Provincia = provincia;

            mPrima = materiasPrima.Where(x => x.Nombre == "Azúcar").FirstOrDefault();

            MateriaPrimaXItem oNuevo4 = new MateriaPrimaXItem();
            oNuevo4.Item = item;
            oNuevo4.MateriaPrima = mPrima;
            oNuevo4.Provincia = provincia;

            mPrima = materiasPrima.Where(x => x.Nombre == "Leche").FirstOrDefault();
            provincia = provincias.Where(p => p.Nombre == "Salta").FirstOrDefault();
            item = items.Where(p => p.Nombre == "ICED CINNAMON DOLCE LATTE").FirstOrDefault();

            MateriaPrimaXItem oNuevo5 = new MateriaPrimaXItem();
            oNuevo5.Item = item;
            oNuevo5.MateriaPrima = mPrima;
            oNuevo5.Provincia = provincia;

            mPrima = materiasPrima.Where(x => x.Nombre == "Jarabe de canela").FirstOrDefault();

            MateriaPrimaXItem oNuevo6 = new MateriaPrimaXItem();
            oNuevo6.Item = item;
            oNuevo6.MateriaPrima = mPrima;
            oNuevo6.Provincia = provincia;

            mPrima = materiasPrima.Where(x => x.Nombre == "Azúcar").FirstOrDefault();

            MateriaPrimaXItem oNuevo7 = new MateriaPrimaXItem();
            oNuevo7.Item = item;
            oNuevo7.MateriaPrima = mPrima;
            oNuevo7.Provincia = provincia;

            MateriaPrimaXItem oNuevo8 = new MateriaPrimaXItem();
            oNuevo8.Item = item;
            oNuevo8.MateriaPrima = mPrima;
            oNuevo8.Provincia = provincia;

            _context.MateriaPrimaXItem.Add(oNuevo1);
            _context.MateriaPrimaXItem.Add(oNuevo2);
            _context.MateriaPrimaXItem.Add(oNuevo3);
            _context.MateriaPrimaXItem.Add(oNuevo4);
            _context.MateriaPrimaXItem.Add(oNuevo5);
            _context.MateriaPrimaXItem.Add(oNuevo6);
            _context.MateriaPrimaXItem.Add(oNuevo7);
            _context.MateriaPrimaXItem.Add(oNuevo8);
        }
    }
}