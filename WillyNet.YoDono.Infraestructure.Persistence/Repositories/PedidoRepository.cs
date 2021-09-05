using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WillyNet.YoDono.Core.Application.Interfaces.Repositories;
using WillyNet.YoDono.Core.Domain.Entities;
using WillyNet.YoDono.Infraestructure.Persistence.Contexts;

namespace WillyNet.YoDono.Infraestructure.Persistence.Repositories
{
    public class PedidoRepository :GenericRepository<Pedido> ,IPedidoRepository
    {
        private readonly DbSet<Pedido> _pedidosContext;
        public PedidoRepository(YoDonoDbContext dbContext) : base(dbContext)
        {
            _pedidosContext = dbContext.Set<Pedido>();
        }
        public async Task<Pedido> CrearPedido(string userSolicitanteId, Guid productoId)
        {
            var newPedido = new Pedido
            {
                PedidoId = Guid.NewGuid(),
                SolicitanteId = userSolicitanteId,
                ProductoId = productoId
            };

            return await AddAsync(newPedido);
        }

        public async Task<IEnumerable<Pedido>> GetAllPedidos(string idUser, string estadoNomb, int pageNumber, int pageSize)
        {
            var pedidos = await _pedidosContext.Where(x => x.SolicitanteId == idUser && x.Producto.Estado.EstadoNomb  != estadoNomb)
                                        .Include(x => x.Producto).ThenInclude(x => x.Estado)
                                        .Include(x => x.Producto).ThenInclude(x => x.Tipo)
                                        .Include(x => x.UserSolicitante)
                                        .Skip((pageNumber - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToListAsync();
            return pedidos;
        }

        public async Task<IEnumerable<Pedido>> GetAllSolicitudes(string idUser, string estadoNomb, int pageNumber, int pageSize)
        {
            var solicitudes = await _pedidosContext
                            .Where(x => x.Producto.UserId == idUser && x.Producto.Estado.EstadoNomb == estadoNomb)
                                        .Include(x => x.Producto).ThenInclude(x => x.Estado)
                                        .Include(x => x.UserSolicitante)
                                        .Skip((pageNumber - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToListAsync();
            return solicitudes;
        }
    }
}
