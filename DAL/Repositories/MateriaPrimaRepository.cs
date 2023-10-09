using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using DAL.Context;
using System;
using System.Collections.Generic;

namespace DAL.Repositories;

public interface IMateriaPrimaRepository
{

}
public class MateriaPrimaRepository : IMateriaPrimaRepository
{
    private readonly EFContext _context;

    public MateriaPrimaRepository(EFContext efContext)
    {
        _context = efContext;
    }

}
