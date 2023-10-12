using Entity.Entities;
using DAL.Context;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public interface IPedidoRepository
{
    ICollection<Pedido> GetAll();
    Pedido? GetById(int idPedido);
    void Guardar(Pedido pedido);
}
public class PedidoRepository : IPedidoRepository
{
    private readonly EFContext _context;

    public PedidoRepository(EFContext efContext)
    {
        _context = efContext;
    }

    public ICollection<Pedido> GetAll()
    {
        return _context.Pedido
                .Include(x => x.Ordenes)
                .ThenInclude(o => o.Estado)
                .Include(x => x.Ordenes)
                 .ThenInclude(o => o.Item)
                .ToList();
    }

    public Pedido? GetById(int idPedido)
    {
        return _context.Pedido
                              .Where(x => x.PedidoId == idPedido)
                              .Include(p => p.Ordenes)
                                .ThenInclude(e => e.Estado)
                              .Include(p => p.Ordenes)
                                .ThenInclude(p => p.Item)
                              .FirstOrDefault();
    }

    public void Guardar(Pedido pedido)
    {
       _context.Pedido.Add(pedido);
    }
}
