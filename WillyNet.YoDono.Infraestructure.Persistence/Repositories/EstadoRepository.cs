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
    public class EstadoRepository : GenericRepository<Estado>, IEstadoRepository
    {
        private readonly DbSet<Estado> _estados;
        public EstadoRepository(YoDonoDbContext dbContext): base(dbContext)
        {
            _estados = dbContext.Set<Estado>();
        }

        public async Task<Guid> GetIdEstado(string Nomb)
        {
            return await _estados
                        .Where(x => x.EstadoNomb.ToUpper() == Nomb.ToUpper())
                        .Select(x => x.EstadoId)
                        .FirstOrDefaultAsync();
        }

        public async Task<bool> IsUniqueAsync(string Nomb)
        {
            var result = await _estados.AllAsync(p => p.EstadoNomb != Nomb);
            return result;
        }
    }
}
