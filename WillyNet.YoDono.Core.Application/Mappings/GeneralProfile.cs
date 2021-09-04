using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WillyNet.YoDono.Core.Application.CQRS.Productos.Queries.GetAll;
using WillyNet.YoDono.Core.Application.DTOs;
using WillyNet.YoDono.Core.Domain.Entities;
using static WillyNet.YoDono.Core.Application.CQRS.Productos.Queries.GetAll.GetAllProductos;

namespace WillyNet.YoDono.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<QueryProductos, GetAllProductoParameters>();
            CreateMap<Estado, EstadoDto>().ReverseMap();
            CreateMap<Tipo, TipoDto>().ReverseMap();
            CreateMap<AppUser, UserDto>().ReverseMap();
            CreateMap<Producto, ProductoDto>();
            CreateMap<Pedido, ProductoSolicitanteDto>();

        }
    }
}
