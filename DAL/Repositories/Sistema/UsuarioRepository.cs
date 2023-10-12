using Entity.Entities;
using Microsoft.VisualBasic;
using DAL.Context;
using System;
using System.Collections.Generic;
using Entity.Entities.Sistema;

namespace DAL.Repositories.Sistema;

public interface IUsuarioRepository
{
    void Iniciar();
}
public class UsuarioRepository : IUsuarioRepository
{
    private readonly EFContext _context;

    public UsuarioRepository(EFContext efContext)
    {
        _context = efContext;
    }

    public void Iniciar()
    {
        if (_context.Usuario.Count() == 0)
        {
            var roles = _context.Rol.Local.ToList();

            Usuario usu1 = new Usuario();
            usu1.Nombre = "Soy un Usuario";
            usu1.Rol = roles.Where(x => x.Nombre == "Usuario").First();

            Usuario usu2 = new Usuario();
            usu2.Nombre = "Soy un Empelado";
            usu2.Rol = roles.Where(x => x.Nombre == "Empelado").First();

            Usuario usu3 = new Usuario();
            usu3.Nombre = "Soy un Supervisor";
            usu3.Rol = roles.Where(x => x.Nombre == "Supervisor").First();

            Usuario usu4 = new Usuario();
            usu4.Nombre = "Soy un Administrador";
            usu4.Rol = roles.Where(x => x.Nombre == "Administrador").First();

            _context.Usuario.Add(usu1);
            _context.Usuario.Add(usu2);
            _context.Usuario.Add(usu3);
            _context.Usuario.Add(usu4);
        }
    }
}
