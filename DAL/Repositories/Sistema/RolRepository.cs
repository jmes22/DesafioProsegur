using Microsoft.EntityFrameworkCore;
using DAL.Context;
using System;
using System.Collections.Generic;
using Entity.Entities.Sistema;

namespace DAL.Repositories.Sistema;

public interface IRolRepository
{
    void Iniciar();
}
public class RolRepository : IRolRepository
{
    private readonly EFContext _context;

    public RolRepository(EFContext efContext)
    {
        _context = efContext;
    }

    public void Iniciar()
    {
        if (_context.Rol.Count() == 0)
        {
            Rol oRol1 = new Rol();
            oRol1.Nombre = "Usuario";

            Rol oRol2 = new Rol();
            oRol2.Nombre = "Empelado";

            Rol oRol3 = new Rol();
            oRol3.Nombre = "Supervisor";

            Rol oRol4 = new Rol();
            oRol4.Nombre = "Administrador";

            _context.Rol.Add(oRol1);
            _context.Rol.Add(oRol2);
            _context.Rol.Add(oRol3);
            _context.Rol.Add(oRol4);
        }
    }
}
