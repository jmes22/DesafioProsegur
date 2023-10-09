using Entity.Entities;
using DAL.Context;
using System;
using System.Collections.Generic;

namespace DAL.Repositories;

public interface IPedidoRepository
{

}
public class PedidoRepository : IPedidoRepository
{
    private readonly EFContext _context;

    public PedidoRepository(EFContext efContext)
    {
        _context = efContext;
    }
}
