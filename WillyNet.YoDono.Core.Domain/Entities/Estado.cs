using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WillyNet.YoDono.Core.Domain.Common;

namespace WillyNet.YoDono.Core.Domain.Entities
{
    public class Estado : AuditableBaseEntity
    {
        public Guid EstadoId { get; set; }
        public string EstadoNomb { get; set; }
        public ICollection<Producto> Productos { get; set; }
    }
}
