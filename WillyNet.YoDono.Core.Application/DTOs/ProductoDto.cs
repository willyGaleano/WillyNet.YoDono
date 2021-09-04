using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WillyNet.YoDono.Core.Application.DTOs
{
    public class ProductoDto
    {
        public Guid ProducId { get; set; }
        public string ProducNomb { get; set; }
        public string ProducDescrip { get; set; }
        public string ProducImageUrl { get; set; }
        public EstadoDto Estado { get; set; }
        public TipoDto Tipo { get; set; }
        public string UserId { get; set; }        
    }
}
