using AutoMapper;
using WillyNet.YoDono.Core.Application.CQRS.Pedidos.Queries.GetAll;
using WillyNet.YoDono.Core.Application.CQRS.Productos.Queries.GetAll;
using WillyNet.YoDono.Core.Application.DTOs;
using WillyNet.YoDono.Core.Domain.Entities;
using static WillyNet.YoDono.Core.Application.CQRS.Pedidos.Queries.GetAll.GetAllPedidos;
using static WillyNet.YoDono.Core.Application.CQRS.Pedidos.Queries.GetAll.GetAllSolicitudes;
using static WillyNet.YoDono.Core.Application.CQRS.Productos.Queries.GetAll.GetAllProductos;

namespace WillyNet.YoDono.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<QueryProductos, GetAllProductoParameters>();
            CreateMap<QueryPedidos, GetAllPedidoParameters>();
            CreateMap<QuerySolicitudes, GetAllPedidoParameters>();
            CreateMap<Estado, EstadoDto>().ReverseMap();
            CreateMap<Tipo, TipoDto>().ReverseMap();
            CreateMap<AppUser, UserDto>().ReverseMap();
            CreateMap<Producto, ProductoDto>();
            CreateMap<Pedido, ProductoSolicitanteDto>();

        }
    }
}
