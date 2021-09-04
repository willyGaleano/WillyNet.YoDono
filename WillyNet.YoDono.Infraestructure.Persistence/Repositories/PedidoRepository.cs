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
        public PedidoRepository(YoDonoDbContext dbContext) : base(dbContext)
        {
        }
    }
}
