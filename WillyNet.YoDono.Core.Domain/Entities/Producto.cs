using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WillyNet.YoDono.Core.Domain.Common;

namespace WillyNet.YoDono.Core.Domain.Entities
{
    public class Producto : AuditableBaseEntity
    {
        public Guid ProducId { get; set; }
        public string  ProducNomb { get; set; }
        public string ProducDescrip { get; set; }
        public string ProducImageUrl { get; set; }
        public Guid EstadoId { get; set; }
        public Guid TipoId { get; set; }
        public string UserId { get; set; }        
        public Estado Estado { get; set; }
        public Tipo Tipo { get; set; }        
        public AppUser User { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }

    }
}
