using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WillyNet.YoDono.Core.Domain.Common;

namespace WillyNet.YoDono.Core.Domain.Entities
{
    public class Pedido : AuditableBaseEntity
    {
        public Guid PedidoId { get; set; }
        public string SolicitanteId { get; set; }
        public Guid ProductoId { get; set; }
        public AppUser UserSolicitante { get; set; }
        public Producto Producto { get; set; }
    }
}
