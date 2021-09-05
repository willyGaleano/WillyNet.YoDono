using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WillyNet.YoDono.Core.Domain.Entities;

namespace WillyNet.YoDono.Core.Application.Interfaces.Repositories
{
    public interface IProductoRepository : IGenericRepository<Producto>
    {
        Task<IEnumerable<Producto>> GetAllProductsHome(string idUser, string estadoNomb, int pageNumber, int pageSize);
        Task<bool> CambiarEstadoProducto(Guid productoId, Guid estadoNuevoId);
    }
}
