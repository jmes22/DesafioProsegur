using DAL.Context;
using Entity.Entities;
using Entity.Entities.Sistema;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataInitializer
    {
        public void InsertarDataInicial(EFContext context)
        {
            context.Database.EnsureCreated();
          
            IniciarEstado(context);
            IniciarMateriaPrima(context);
            IniciarItem(context);
            IniciarImpuesto(context);
            IniciarProvincia(context);
            IniciarMateriaPrimaXItem(context);
            IniciarRol(context);
            IniciarAccion(context);
            IniciarAccionXRol(context);
            IniciarUsuario(context);

            context.SaveChanges();
        }

        private void IniciarEstado(EFContext context)
        {
            if (context.Estado.Count() == 0)
            {
                Estado oEstado1 = new Estado();
                oEstado1.Nombre = "PENDIENTE";

                Estado oEstado2 = new Estado();
                oEstado2.Nombre = "EJECUCION";

                Estado oEstado3 = new Estado();
                oEstado3.Nombre = "FINALIZADO";

                context.Estado.Add(oEstado1);
                context.Estado.Add(oEstado2);
                context.Estado.Add(oEstado3);
            }
        }

        private void IniciarImpuesto(EFContext context)
        {
            if (context.Impuesto.Count() == 0)
            {
                Impuesto oImpuesto1 = new Impuesto();
                oImpuesto1.Nombre = "AI";
                oImpuesto1.Porcentaje = 0.5;

                Impuesto oImpuesto2 = new Impuesto();
                oImpuesto2.Nombre = "IE";
                oImpuesto2.Porcentaje = 0.1;

                Impuesto oImpuesto3 = new Impuesto();
                oImpuesto3.Nombre = "IVA";
                oImpuesto3.Porcentaje = 0.25;

                context.Impuesto.Add(oImpuesto1);
                context.Impuesto.Add(oImpuesto2);
                context.Impuesto.Add(oImpuesto3);
            }
        }

        private void IniciarItem(EFContext context)
        {
            if (context.Item.Count() == 0)
            {
                Item oItem1 = new Item();
                oItem1.Nombre = "S’MORES FRAPPUCCINO";
                oItem1.TiempoEjecucion = 1;

                Item oItem2 = new Item();
                oItem2.Nombre = "ICED CINNAMON DOLCE LATTE";
                oItem2.TiempoEjecucion = 2;

                context.Item.Add(oItem1);
                context.Item.Add(oItem2);
            }
        }

        private void IniciarMateriaPrima(EFContext context)
        {
            if (context.MateriaPrima.Count() == 0)
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

                context.MateriaPrima.Add(oMateriaPrima1);
                context.MateriaPrima.Add(oMateriaPrima2);
                context.MateriaPrima.Add(oMateriaPrima3);
                context.MateriaPrima.Add(oMateriaPrima4);
            }
        }

        private void IniciarMateriaPrimaXItem(EFContext context)
        {
            if (context.MateriaPrimaXItem.Count() == 0
                && context.Item.Local.Count() > 0
                && context.MateriaPrima.Local.Count() > 0
                && context.Provincia.Local.Count() > 0
                )
            {
                var items = context.Item.Local.ToList();
                var materiasPrima = context.MateriaPrima.Local.ToList();
                var provincias = context.Provincia.Local.ToList();

                var mPrima = materiasPrima.Where(x => x.Nombre == "Leche").FirstOrDefault();
                var provincia = provincias.Where(p => p.Nombre == "Córdoba").FirstOrDefault();
                var item = items.Where(p => p.Nombre == "S’MORES FRAPPUCCINO").FirstOrDefault();

                MateriaPrimaXItem oNuevo1 = new MateriaPrimaXItem();
                oNuevo1.Item = item;
                oNuevo1.MateriaPrima = mPrima;
                oNuevo1.Provincia = provincia;

                mPrima = materiasPrima.Where(x => x.Nombre == "Cacao").FirstOrDefault();

                MateriaPrimaXItem oNuevo2 = new MateriaPrimaXItem();
                oNuevo2.Item = item;
                oNuevo2.MateriaPrima = mPrima;
                oNuevo2.Provincia = provincia;

                MateriaPrimaXItem oNuevo3 = new MateriaPrimaXItem();
                oNuevo3.Item = item;
                oNuevo3.MateriaPrima = mPrima;
                oNuevo3.Provincia = provincia;

                mPrima = materiasPrima.Where(x => x.Nombre == "Azúcar").FirstOrDefault();

                MateriaPrimaXItem oNuevo4 = new MateriaPrimaXItem();
                oNuevo4.Item = item;
                oNuevo4.MateriaPrima = mPrima;
                oNuevo4.Provincia = provincia;

                mPrima = materiasPrima.Where(x => x.Nombre == "Leche").FirstOrDefault();
                provincia = provincias.Where(p => p.Nombre == "Salta").FirstOrDefault();
                item = items.Where(p => p.Nombre == "ICED CINNAMON DOLCE LATTE").FirstOrDefault();

                MateriaPrimaXItem oNuevo5 = new MateriaPrimaXItem();
                oNuevo5.Item = item;
                oNuevo5.MateriaPrima = mPrima;
                oNuevo5.Provincia = provincia;

                mPrima = materiasPrima.Where(x => x.Nombre == "Jarabe de canela").FirstOrDefault();

                MateriaPrimaXItem oNuevo6 = new MateriaPrimaXItem();
                oNuevo6.Item = item;
                oNuevo6.MateriaPrima = mPrima;
                oNuevo6.Provincia = provincia;

                mPrima = materiasPrima.Where(x => x.Nombre == "Azúcar").FirstOrDefault();

                MateriaPrimaXItem oNuevo7 = new MateriaPrimaXItem();
                oNuevo7.Item = item;
                oNuevo7.MateriaPrima = mPrima;
                oNuevo7.Provincia = provincia;

                MateriaPrimaXItem oNuevo8 = new MateriaPrimaXItem();
                oNuevo8.Item = item;
                oNuevo8.MateriaPrima = mPrima;
                oNuevo8.Provincia = provincia;

                context.MateriaPrimaXItem.Add(oNuevo1);
                context.MateriaPrimaXItem.Add(oNuevo2);
                context.MateriaPrimaXItem.Add(oNuevo3);
                context.MateriaPrimaXItem.Add(oNuevo4);
                context.MateriaPrimaXItem.Add(oNuevo5);
                context.MateriaPrimaXItem.Add(oNuevo6);
                context.MateriaPrimaXItem.Add(oNuevo7);
                context.MateriaPrimaXItem.Add(oNuevo8);
            }
        }

        private void IniciarProvincia(EFContext context)
        {
            if (context.Provincia.Count() == 0)
            {
                var impuesto = context.Impuesto.Local.Where(x => x.Nombre == "AI").FirstOrDefault();

                Provincia oProv1 = new Provincia();
                oProv1.Nombre = "Córdoba";
                oProv1.Impuesto = impuesto;

                impuesto = context.Impuesto.Local.Where(x => x.Nombre == "IVA").FirstOrDefault();
                Provincia oProv2 = new Provincia();
                oProv2.Nombre = "La Rioja";
                oProv2.Impuesto = impuesto;

                impuesto = context.Impuesto.Local.Where(x => x.Nombre == "IE").FirstOrDefault();
                Provincia oProv3 = new Provincia();
                oProv3.Nombre = "Salta";
                oProv3.Impuesto = impuesto;

                context.Provincia.Add(oProv1);
                context.Provincia.Add(oProv2);
                context.Provincia.Add(oProv3);
            }
        }

        private void IniciarRol(EFContext context)
        {
            if (context.Rol.Count() == 0)
            {
                Rol oRol1 = new Rol();
                oRol1.Nombre = "Usuario";

                Rol oRol2 = new Rol();
                oRol2.Nombre = "Empleado";

                Rol oRol3 = new Rol();
                oRol3.Nombre = "Supervisor";

                Rol oRol4 = new Rol();
                oRol4.Nombre = "Administrador";

                context.Rol.Add(oRol1);
                context.Rol.Add(oRol2);
                context.Rol.Add(oRol3);
                context.Rol.Add(oRol4);
            }
        }

        private void IniciarAccion(EFContext context)
        {
            if (context.Accion.Count() == 0)
            {
                Accion acc1 = new Accion();
                acc1.Nombre = "Hace tu pedido";
                acc1.Controller = "Item";
                acc1.AccionController = "Index";

                Accion acc2 = new Accion();
                acc2.Nombre = "Materia prima";
                acc2.Controller = "MateriaPrima";
                acc2.AccionController = "Index";

                Accion acc3 = new Accion();
                acc3.Nombre = "Pedidos";
                acc3.Controller = "Pedido";
                acc3.AccionController = "Index";

                Accion acc4 = new Accion();
                acc4.Nombre = "Ordenes de trabajo";
                acc4.Controller = "OrdenTrabajo";
                acc4.AccionController = "Index";

                Accion acc5 = new Accion();
                acc5.Nombre = "Facturación";
                acc5.Controller = "Factura";
                acc5.AccionController = "Index";

                context.Accion.Add(acc1);
                context.Accion.Add(acc2);
                context.Accion.Add(acc3);
                context.Accion.Add(acc4);
                context.Accion.Add(acc5);
            }
        }

        private void IniciarAccionXRol(EFContext context)
        {
            if (context.AccionXRol.Count() == 0)
            {
                var acciones = context.Accion.Local.ToList();

                //USUARIO
                var rol = context.Rol.Local.Where(x => x.Nombre == "Usuario").First();

                AccionXRol a1 = new AccionXRol();
                a1.Rol = rol;
                a1.Accion = acciones.Where(x => x.Controller == "Item").First();

                //Empleado
                rol = context.Rol.Local.Where(x => x.Nombre == "Empleado").First();
               
                AccionXRol a2 = new AccionXRol();
                a2.Rol = rol;
                a2.Accion = acciones.Where(x => x.Controller == "OrdenTrabajo").First();

                //Supervisor
                rol = context.Rol.Local.Where(x => x.Nombre == "Supervisor").First();

                AccionXRol a3 = new AccionXRol();
                a3.Rol = rol;
                a3.Accion = acciones.Where(x => x.Controller == "MateriaPrima").First();

                AccionXRol a4 = new AccionXRol();
                a4.Rol = rol;
                a4.Accion = acciones.Where(x => x.Controller == "Pedido").First();

                AccionXRol a5 = new AccionXRol();
                a5.Rol = rol;
                a5.Accion = acciones.Where(x => x.Controller == "Factura").First();

                //Administrador
                rol = context.Rol.Local.Where(x => x.Nombre == "Administrador").First();

                AccionXRol a6 = new AccionXRol();
                a6.Accion = acciones.Where(x => x.Controller == "OrdenTrabajo").First();
                a6.Rol = rol;

                AccionXRol a7 = new AccionXRol();
                a7.Accion = acciones.Where(x => x.Controller == "Item").First();
                a7.Rol = rol;

                AccionXRol a8 = new AccionXRol();
                a8.Accion = acciones.Where(x => x.Controller == "Pedido").First();
                a8.Rol = rol;

                AccionXRol a9 = new AccionXRol();
                a9.Accion = acciones.Where(x => x.Controller == "Factura").First();
                a9.Rol = rol;

                AccionXRol a10 = new AccionXRol();
                a10.Accion = acciones.Where(x => x.Controller == "MateriaPrima").First();
                a10.Rol = rol;

                context.AccionXRol.Add(a1);
                context.AccionXRol.Add(a2);
                context.AccionXRol.Add(a3);
                context.AccionXRol.Add(a4);
                context.AccionXRol.Add(a5);
                context.AccionXRol.Add(a6);
                context.AccionXRol.Add(a7);
                context.AccionXRol.Add(a8);
                context.AccionXRol.Add(a9);
                context.AccionXRol.Add(a10);
            }
        }

        private void IniciarUsuario(EFContext context)
        {
            if (context.Usuario.Count() == 0)
            {
                var roles = context.Rol.Local.ToList();

                Usuario usu1 = new Usuario();
                usu1.Nombre = "Soy un Usuario";
                usu1.Rol = roles.Where(x => x.Nombre == "Usuario").First();

                Usuario usu2 = new Usuario();
                usu2.Nombre = "Soy un Empelado";
                usu2.Rol = roles.Where(x => x.Nombre == "Empleado").First();

                Usuario usu3 = new Usuario();
                usu3.Nombre = "Soy un Supervisor";
                usu3.Rol = roles.Where(x => x.Nombre == "Supervisor").First();

                Usuario usu4 = new Usuario();
                usu4.Nombre = "Soy un Administrador";
                usu4.Rol = roles.Where(x => x.Nombre == "Administrador").First();

                context.Usuario.Add(usu1);
                context.Usuario.Add(usu2);
                context.Usuario.Add(usu3);
                context.Usuario.Add(usu4);
            }
        }
    }
}
