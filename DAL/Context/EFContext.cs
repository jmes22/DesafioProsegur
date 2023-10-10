using System;
using System.Collections.Generic;
using Entity.Entities;
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

    public virtual DbSet<Ususario> Ususario { get; set; }

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

            //entity.HasOne(d => d.Item).WithMany(p => p.MateriasPrimaXItem)
            //  .HasForeignKey(d => d.IdItem);

            //entity.HasOne(d => d.MateriaPrima).WithMany(p => p.MateriaPrimaXItem)
            //   .HasForeignKey(d => d.IdMateriaPrima);

            //entity.HasOne(d => d.Provincia).WithMany(p => p.MateriasPrimaXItem)
            // .HasForeignKey(d => d.IdProvincia);

        });

        modelBuilder.Entity<OrdenTrabajo>(entity =>
        {
            entity.HasKey(e => e.OrdenTrabajoId);

            entity.ToTable("OrdenTrabajo");

            // entity.HasOne(e => e.Estado)
            //.WithMany()
            //.HasForeignKey(e => e.IdEstado);

            // entity.HasOne(e => e.Item)
            //.WithMany()
            //.HasForeignKey(e => e.IdItem);

            //entity.HasOne(e => e.Pedido)
            //  .WithMany()
            //  .HasForeignKey(b => b..IdPedido);

            //entity.Ignore(e => e.Pedido);
            //entity.Ignore(e => e.Estado);
            //entity.Ignore(e => e.Item);
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.PedidoId);

            entity.ToTable("Pedido");

            entity.Ignore(e => e.Ordenes);
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

        modelBuilder.Entity<Ususario>(entity =>
        {
            entity.HasKey(e => e.UsusarioId);

            entity.ToTable("Ususario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
