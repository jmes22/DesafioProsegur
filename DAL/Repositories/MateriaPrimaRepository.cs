using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using DAL.Context;
using System;
using System.Collections.Generic;

namespace DAL.Repositories;

public interface IMateriaPrimaRepository
{
    void Iniciar();
    ICollection<MateriaPrima> GetAll();
    void Guardar(ICollection<MateriaPrima> materiasPrima);

}
public class MateriaPrimaRepository : IMateriaPrimaRepository
{
    private readonly EFContext _context;

    public MateriaPrimaRepository(EFContext efContext)
    {
        _context = efContext;
    }

    public ICollection<MateriaPrima> GetAll()
    {
        return _context.MateriaPrima.ToList();
    }

    public void Guardar(ICollection<MateriaPrima> materiasPrima)
    {
        var materiasPrimaExistentes = _context.MateriaPrima.ToList();

        foreach (var materiaExistente in materiasPrimaExistentes)
        {
            var mpActualizado = materiasPrima.FirstOrDefault(m => m.MateriaPrimaId == materiaExistente.MateriaPrimaId);

            if (mpActualizado != null)
                _context.Entry(materiaExistente).CurrentValues.SetValues(mpActualizado);
        }
        
    }

    public void Iniciar()
    {
        if (_context.MateriaPrima.Count() == 0)
        {
            MateriaPrima oMateriaPrima1 = new MateriaPrima();
            oMateriaPrima1.Nombre = "Leche";
            oMateriaPrima1.Stock = 0;
            oMateriaPrima1.Precio = 5;

            MateriaPrima oMateriaPrima2 = new MateriaPrima();
            oMateriaPrima2.Nombre = "Cacao";
            oMateriaPrima2.Stock = 0;
            oMateriaPrima2.Precio = 10;

            MateriaPrima oMateriaPrima3 = new MateriaPrima();
            oMateriaPrima3.Nombre = "Azúcar";
            oMateriaPrima3.Stock = 0;
            oMateriaPrima3.Precio = 15;

            MateriaPrima oMateriaPrima4 = new MateriaPrima(); 
            oMateriaPrima4.Nombre = "Jarabe de canela";
            oMateriaPrima4.Stock = 0;
            oMateriaPrima4.Precio = 20;

            _context.MateriaPrima.Add(oMateriaPrima1);
            _context.MateriaPrima.Add(oMateriaPrima2);
            _context.MateriaPrima.Add(oMateriaPrima3);
            _context.MateriaPrima.Add(oMateriaPrima4);
        }
    }
}
