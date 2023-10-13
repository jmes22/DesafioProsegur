using Entity.Entities;
using Microsoft.VisualBasic;
using DAL.Context;
using System;
using System.Collections.Generic;
using Entity.Entities.Sistema;

namespace DAL.Repositories.Sistema;

public interface IUsuarioRepository
{
}
public class UsuarioRepository : IUsuarioRepository
{
    private readonly EFContext _context;

    public UsuarioRepository(EFContext efContext)
    {
        _context = efContext;
    }
}
