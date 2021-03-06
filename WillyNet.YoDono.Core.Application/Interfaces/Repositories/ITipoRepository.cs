using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WillyNet.YoDono.Core.Domain.Entities;

namespace WillyNet.YoDono.Core.Application.Interfaces.Repositories
{
    public interface ITipoRepository : IGenericRepository<Tipo>
    {
        Task<bool> IsUniqueAsync(string Nomb);
    }
}
