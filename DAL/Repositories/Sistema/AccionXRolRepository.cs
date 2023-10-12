using Microsoft.EntityFrameworkCore;
using DAL.Context;
using System;
using System.Collections.Generic;
using Entity.Entities.Sistema;

namespace DAL.Repositories.Sistema;

public interface IAccionXRolRepository
{
    void Iniciar();
}
public class AccionXRolRepository : IAccionXRolRepository
{
    private readonly EFContext _context;

    public AccionXRolRepository(EFContext efContext)
    {
        _context = efContext;
    }

    public void Iniciar()
    {
        if (_context.AccionXRol.Count() == 0)
        {
            var acciones = _context.Accion.Local.ToList();

            //USUARIO
            var rol = _context.Rol.Local.Where(x => x.Nombre == "Usuario").First();

            AccionXRol a1 = new AccionXRol();
            a1.Rol = rol;
            a1.Accion = acciones.Where(x => x.Nombre == "Item").First();

            rol = _context.Rol.Local.Where(x => x.Nombre == "Empelado").First();

            //EMPLEADO
            AccionXRol a2 = new AccionXRol();
            a2.Rol = rol;
            a2.Accion = acciones.Where(x => x.Nombre == "OrdenTrabajo").First();

            //Supervisor
            rol = _context.Rol.Local.Where(x => x.Nombre == "Supervisor").First();

            AccionXRol a3 = new AccionXRol();
            a3.Rol = rol;
            a3.Accion = acciones.Where(x => x.Nombre == "MateriaPrima").First();

            AccionXRol a4 = new AccionXRol();
            a4.Rol = rol;
            a4.Accion = acciones.Where(x => x.Nombre == "Pedido").First();

            AccionXRol a5 = new AccionXRol();
            a5.Rol = rol;
            a5.Accion = acciones.Where(x => x.Nombre == "Factura").First();

            //Administrador
            rol = _context.Rol.Local.Where(x => x.Nombre == "Administrador").First();

            AccionXRol a6 = new AccionXRol();
            a6.Accion = acciones.Where(x => x.Nombre == "OrdenTrabajo").First();
            a6.Rol = rol;

            AccionXRol a7 = new AccionXRol();
            a7.Accion = acciones.Where(x => x.Nombre == "Item").First();
            a7.Rol = rol;

            AccionXRol a8 = new AccionXRol();
            a8.Accion = acciones.Where(x => x.Nombre == "Pedido").First();
            a8.Rol = rol;

            AccionXRol a9 = new AccionXRol();
            a9.Accion = acciones.Where(x => x.Nombre == "Factura").First();
            a9.Rol = rol;

            AccionXRol a10 = new AccionXRol();
            a10.Accion = acciones.Where(x => x.Nombre == "MateriaPrima").First();
            a10.Rol = rol;

            _context.AccionXRol.Add(a1);
            _context.AccionXRol.Add(a2);
            _context.AccionXRol.Add(a3);
            _context.AccionXRol.Add(a4);
            _context.AccionXRol.Add(a5);
            _context.AccionXRol.Add(a6);
            _context.AccionXRol.Add(a7);
            _context.AccionXRol.Add(a8);
            _context.AccionXRol.Add(a9);
            _context.AccionXRol.Add(a10);
        }
    }
}
