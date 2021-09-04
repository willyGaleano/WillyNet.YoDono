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
    public class TipoRepository : GenericRepository<Tipo>, ITipoRepository
    {
        private readonly DbSet<Tipo> _tipos;
        public TipoRepository(YoDonoDbContext dbContext) : base(dbContext)
        {
            _tipos = dbContext.Set<Tipo>();
        }
        public async Task<bool> IsUniqueAsync(string Nomb)
        {
            var result = await _tipos.AllAsync(p => p.TipoNomb != Nomb);
            return result;
        }
    }
}
