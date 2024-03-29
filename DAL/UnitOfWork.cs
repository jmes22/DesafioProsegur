﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using DAL.Context;
using DAL.Repositories;
using DAL.Repositories.Sistema;

namespace DAL
{
    public interface IUnitOfWork : IDisposable
    {
        void CommitTransaction();
        IDetalleFacturaRepository DetalleFacturaRepository { get; }
        IEstadoRepository EstadoRepository { get; }
        IFacturaRepository FacturaRepository { get; }
        IImpuestoRepository ImpuestoRepository { get; }
        IItemRepository ItemRepository { get; }
        IMateriaPrimaXItemRepository MateriaPrimaXItemRepository { get; }
        IMateriaPrimaRepository MateriaPrimaRepository { get; }
        IOrdenTrabajoRepository OrdenTrabajoRepository { get; }
        IPedidoRepository PedidoRepository { get; }
        IProvinciaRepository ProvinciaRepository { get; }
        IUsuarioRepository UsuarioRepository { get; }
        IRolRepository RolRepository { get; }
        IAccionXRolRepository AccionXRolRepository { get; }
        IAccionRepository AccionRepository { get; }
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly EFContext _context;
        private IDbContextTransaction _transaction;
        private bool _disposed = false;

        private readonly DetalleFacturaRepository _detalleFacturaRepository;
        private readonly EstadoRepository _estadoRepository;
        private readonly FacturaRepository _facturaRepository;
        private readonly ImpuestoRepository _impuestoRepository;
        private readonly ItemRepository _itemRepository;
        private readonly MateriaPrimaXItemRepository _materiaPrimaXItemRepository;
        private readonly MateriaPrimaRepository _materiaPrimaRepository;
        private readonly OrdenTrabajoRepository _ordenTrabajoRepository;
        private readonly PedidoRepository _pedidoRepository;
        private readonly ProvinciaRepository _provinciaRepository;
        private readonly UsuarioRepository _usuarioRepository;
        private readonly RolRepository _rolRepository;
        private readonly AccionXRolRepository _accionXRolRepository;
        private readonly AccionRepository _accionRepository;

        public UnitOfWork(DbContextOptions<EFContext> dbContextOptions)
        {
            if (dbContextOptions == null)
                throw new ArgumentNullException(nameof(dbContextOptions));

            _context = new EFContext(dbContextOptions);
            _transaction = _context.Database.BeginTransaction();

            _detalleFacturaRepository = new DetalleFacturaRepository(_context);
            _estadoRepository = new EstadoRepository(_context);
            _facturaRepository = new FacturaRepository(_context);
            _impuestoRepository = new ImpuestoRepository(_context);
            _itemRepository = new ItemRepository(_context);
            _materiaPrimaXItemRepository = new MateriaPrimaXItemRepository(_context);
            _materiaPrimaRepository = new MateriaPrimaRepository(_context);
            _ordenTrabajoRepository = new OrdenTrabajoRepository(_context);
            _pedidoRepository = new PedidoRepository(_context);
            _provinciaRepository = new ProvinciaRepository(_context);
            _usuarioRepository = new UsuarioRepository(_context);
            _rolRepository = new RolRepository(_context);
            _accionRepository = new AccionRepository(_context);
            _accionXRolRepository = new AccionXRolRepository(_context);
        }

        public IDetalleFacturaRepository DetalleFacturaRepository => _detalleFacturaRepository;
        public IEstadoRepository EstadoRepository => _estadoRepository;

        public IFacturaRepository FacturaRepository => _facturaRepository;

        public IImpuestoRepository ImpuestoRepository => _impuestoRepository;

        public IItemRepository ItemRepository => _itemRepository;

        public IMateriaPrimaRepository MateriaPrimaRepository => _materiaPrimaRepository;
        public IMateriaPrimaXItemRepository MateriaPrimaXItemRepository => _materiaPrimaXItemRepository;

        public IOrdenTrabajoRepository OrdenTrabajoRepository => _ordenTrabajoRepository;

        public IPedidoRepository PedidoRepository => _pedidoRepository;

        public IProvinciaRepository ProvinciaRepository => _provinciaRepository;

        public IUsuarioRepository UsuarioRepository => _usuarioRepository;

        public IRolRepository RolRepository => _rolRepository;

        public IAccionXRolRepository AccionXRolRepository => _accionXRolRepository;

        public IAccionRepository AccionRepository => _accionRepository;

        public void CommitTransaction()
        {
            try
            {
                _context.SaveChanges();
                _transaction.Commit();
            }
            catch (Exception)
            {
                RollbackTransaction();
            }
            finally
            {
                Dispose(true);
            }
        }

        private void RollbackTransaction()
        {
            try
            {
                 _transaction.Rollback();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _transaction?.Dispose();
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}