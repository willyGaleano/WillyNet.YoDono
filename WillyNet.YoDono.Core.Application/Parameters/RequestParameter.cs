using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WillyNet.YoDono.Core.Application.Parameters
{
    public class RequestParameter
    {
        public string UserId { get; set; }
        public string EstadoNomb { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public RequestParameter()
        {
            PageNumber = 1;
            PageSize = 6;
            EstadoNomb = "Creado";
        }
        public RequestParameter(int pageNumber, int pageSize, string estadoNomb)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize > 6 ? 6 : pageSize;
            EstadoNomb = estadoNomb;
        }
    }
}
