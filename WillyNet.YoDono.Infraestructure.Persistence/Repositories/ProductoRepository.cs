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
    public class ProductoRepository : GenericRepository<Producto> , IProductoRepository
    {
        private readonly DbSet<Producto> _productosContext;
        public ProductoRepository(YoDonoDbContext dbContext) : base(dbContext)
        {
            _productosContext = dbContext.Set<Producto>();
        }

        public async Task<IEnumerable<Producto>> GetAllProductsHome(string idUser, string estadoNomb, int pageNumber, int pageSize)
        {
            var productos = await _productosContext.Where(x => x.UserId != idUser && x.Estado.EstadoNomb == estadoNomb)
                                        .Include(x => x.Tipo)
                                        .Include(x => x.Estado)
                                        .Include(x => x.User)
                                        .Skip((pageNumber - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToListAsync();
            return productos;
        }

        public async Task<bool> CambiarEstadoProducto(Guid productoId, Guid estadoNuevoId)
        {
            //Se modificara el estado del producto 
            var producto = await _productosContext.Where(x => x.ProducId == productoId).FirstOrDefaultAsync();
            producto.EstadoId = estadoNuevoId;
            var result = await UpdateAsync(producto);
            
            return result;
        }
    }
}
