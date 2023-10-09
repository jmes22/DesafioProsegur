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

    public virtual DbSet<OrdenTrabajo> OrdenTrabajo { get; set; }

    public virtual DbSet<Pedido> Pedido { get; set; }

    public virtual DbSet<Provincia> Provincia { get; set; }

    public virtual DbSet<Rol> Rol { get; set; }

    public virtual DbSet<Ususario> Ususario { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
        modelBuilder.Entity<DetalleFactura>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<Estado>().ToTable("Estado");
        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<Impuesto>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<MateriaPrima>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<OrdenTrabajo>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<Provincia>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<Ususario>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
