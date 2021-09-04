using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WillyNet.YoDono.Core.Application.DTOs
{
    public class ProductoSolicitanteDto
    {
        public Guid PedidoId { get; set; }
        public UserDto UserSolicitante { get; set; }
        public ProductoDto Producto { get; set; }
    }
}
