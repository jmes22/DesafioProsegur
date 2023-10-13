using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using DAL.Context;
using System;
using System.Collections.Generic;

namespace DAL.Repositories;

public interface IMateriaPrimaRepository
{
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
}
