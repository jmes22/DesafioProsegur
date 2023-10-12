using System;
using System.Collections.Generic;
using Entity.Entities;
using Entity.Entities.Sistema;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context;

public partial class EFContext : DbContext
{
    public EFContext()
    {
    }

    public EFContext(DbContextOptions<EFContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Estado> Estado { get; set; }

    public virtual DbSet<DetalleFactura> DetalleFactura { get; set; }

    public virtual DbSet<Factura> Factura { get; set; }

    public virtual DbSet<Impuesto> Impuesto { get; set; }

    public virtual DbSet<Item> Item { get; set; }

    public virtual DbSet<MateriaPrima> MateriaPrima { get; set; }
    public virtual DbSet<MateriaPrimaXItem> MateriaPrimaXItem { get; set; }

    public virtual DbSet<OrdenTrabajo> OrdenTrabajo { get; set; }

    public virtual DbSet<Pedido> Pedido { get; set; }

    public virtual DbSet<Provincia> Provincia { get; set; }

    public virtual DbSet<Rol> Rol { get; set; }
    public virtual DbSet<Accion> Accion { get; set; }
    public virtual DbSet<AccionXRol> AccionXRol { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
        modelBuilder.Entity<DetalleFactura>(entity =>
        {
            entity.HasKey(e => e.DetalleFacturaId);

            entity.ToTable("DetalleFactura");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.EstadoId);

            entity.ToTable("Estado");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.FacturaId);

            entity.ToTable("Factura");
        });

        modelBuilder.Entity<Impuesto>(entity =>
        {
            entity.HasKey(e => e.ImpuestoId);

            entity.ToTable("Impuesto");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemId);
            entity.Ignore(e => e.Precio);
            entity.ToTable("Item");
        });

        modelBuilder.Entity<MateriaPrima>(entity =>
        {
            entity.HasKey(e => e.MateriaPrimaId);
            entity.ToTable("MateriaPrima");
        });

        modelBuilder.Entity<MateriaPrimaXItem>(entity =>
        {
            entity.HasKey(e => e.MateriaPrimaXItemId);

            entity.ToTable("MateriaPrimaXItem");

        });

        modelBuilder.Entity<OrdenTrabajo>(entity =>
        {
            entity.HasKey(e => e.OrdenTrabajoId);

            entity.ToTable("OrdenTrabajo");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.PedidoId);

            entity.ToTable("Pedido");

            entity.Ignore(e => e.Estado);
            //entity.Ignore(e => e.Ordenes);
        });

        modelBuilder.Entity<Provincia>(entity =>
        {
            entity.HasKey(e => e.ProvinciaId);

            entity.ToTable("Provincia");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.RolId);

            entity.ToTable("Rol");
        });

        modelBuilder.Entity<Accion>(entity =>
        {
            entity.HasKey(e => e.AccionId);

            entity.ToTable("Accion");
        });

        modelBuilder.Entity<AccionXRol>(entity =>
        {
            entity.HasKey(e => e.AccionXRolId);

            entity.ToTable("AccionXRol");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId);

            entity.ToTable("Usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
