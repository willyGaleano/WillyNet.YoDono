using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WillyNet.YoDono.Core.Domain.Common;

namespace WillyNet.YoDono.Core.Domain.Entities
{
    public class Tipo : AuditableBaseEntity
    {
        public Guid TipoId { get; set; }
        public string TipoNomb { get; set; }
        public string TipoColor { get; set; }
        public ICollection<Producto> Productos { get; set; }
    }
}
