using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WillyNet.YoDono.Core.Application.DTOs;
using WillyNet.YoDono.Core.Application.Interfaces.Repositories;
using WillyNet.YoDono.Core.Application.Wrappers;

namespace WillyNet.YoDono.Core.Application.CQRS.Productos.Queries.GetAll
{
    public class GetAllProductos
    {
        public class QueryProductos : IRequest<PagedResponse<IEnumerable<ProductoDto>>>
        {
            public string UserId { get; set; }
            public string EstadoNomb { get; set; }
            public int PageNumber { get; set;}
            public int PageSize { get; set; }
        }

        public class Handler : IRequestHandler<QueryProductos, PagedResponse<IEnumerable<ProductoDto>>>
        {
            private readonly IMapper _mapper;
            private readonly IProductoRepository _productoRepository;

            public Handler(IMapper mapper, IProductoRepository productoRepository)
            {
                _mapper = mapper;
                _productoRepository = productoRepository;
            }
            public async Task<PagedResponse<IEnumerable<ProductoDto>>> Handle(QueryProductos request, CancellationToken cancellationToken)
            {
                var filterValidated = _mapper.Map<GetAllProductoParameters>(request);
                var productos = await _productoRepository.GetAllProductsHome
                                                (filterValidated.UserId, filterValidated.EstadoNomb ,filterValidated.PageNumber, filterValidated.PageSize);
                var productosDto = _mapper.Map<IEnumerable<ProductoDto>>(productos);
                var count = await _productoRepository.CountTotal();

                var result = new PagedResponse<IEnumerable<ProductoDto>>
                              (productosDto, filterValidated.PageNumber, filterValidated.PageSize, count, "¡Consulta exitosa!");
                return result;
            }
        }
    }
}
