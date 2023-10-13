using DAL;
using Entity.Entities.Sistema;
using Newtonsoft.Json;

namespace DesafioProsegur.Models
{
    public static class SessionManager
    {
        public static void SetRol(HttpContext context, string rol, IUnitOfWork _unitOfwork)
        {
            if (!string.IsNullOrEmpty(rol) && (rol == "Usuario" || rol == "Empleado" || rol == "Supervisor" || rol == "Administrador"))
                context.Session.SetString("Rol", rol);
            else context.Session.SetString("Rol", "Usuario");

            setAcciones(context, _unitOfwork);
        }

        private static void setAcciones(HttpContext context, IUnitOfWork _unitOfwork)
        {
            var rolActual = GetRol(context);
            var rol = _unitOfwork.RolRepository.GetByRol(rolActual);

            ICollection<Accion> acciones = new List<Accion>();

            if (rol != null)
                acciones = rol.AccionXRol.Select(x => x.Accion).ToList();

            context.Session.SetString("MenuItems", JsonConvert.SerializeObject(acciones));
        }

        public static string GetRol(HttpContext context)
        {
            return context.Session.GetString("Rol") ?? "Usuario";
        }

        internal static bool TienePermiso(HttpContext httpContext, IUnitOfWork _unitOfwork, string controllerName)
        {
            string rolActual = httpContext.Session.GetString("Rol") ?? "Usuario";
            var rol = _unitOfwork.RolRepository.GetByRol(rolActual);

            if (rol == null) return false;

            var acciones = rol.AccionXRol.Select(x => x.Accion);
            
            var accion = acciones.Where(x => x.Controller.ToUpper() == controllerName.ToUpper()).FirstOrDefault();

            if (accion == null) return false;

            return true;
        }
    }
}
