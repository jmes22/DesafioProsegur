using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using DAL.Context;
using System;
using System.Collections.Generic;

namespace DAL.Repositories;

public interface IRolRepository
{

}
public class RolRepository : IRolRepository
{
    private readonly EFContext _context;

    public RolRepository(EFContext efContext)
    {
        _context = efContext;
    }
}
