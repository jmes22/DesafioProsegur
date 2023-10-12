using DAL;
using Entity.Entities.Sistema;

namespace DesafioProsegur.Models
{
    public static class SessionManager
    {
        public static void SetRol(HttpContext context, string rol)
        {
            if (!string.IsNullOrEmpty(rol) && (rol == "Usuario" || rol == "Empleado" || rol == "Supervisor" || rol == "Administrador"))
            {
                context.Session.SetString("Rol", rol);
            }
        }

        public static string GetRol(HttpContext context)
        {
            return context.Session.GetString("Rol") ?? "Usuario";
        }

        internal static bool TienePermiso(HttpContext httpContext, IUnitOfWork unitOfwork)
        {
            string rolActual = httpContext.Session.GetString("Rol") ?? "Usuario";
            throw new NotImplementedException();
        }
    }
}
