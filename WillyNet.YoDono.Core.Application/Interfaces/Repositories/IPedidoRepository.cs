using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WillyNet.YoDono.Core.Domain.Entities;

namespace WillyNet.YoDono.Core.Application.Interfaces.Repositories
{
    public interface IPedidoRepository : IGenericRepository<Pedido>
    {
        Task<IEnumerable<Pedido>> GetAllPedidos(string idUser, string estadoNomb, int pageNumber, int pageSize);
        Task<IEnumerable<Pedido>> GetAllSolicitudes(string idUser, string estadoNomb, int pageNumber, int pageSize);
        Task<Pedido> CrearPedido(string userSolicitanteId, Guid productoId);
    }
}
