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

namespace WillyNet.YoDono.Core.Application.CQRS.Pedidos.Queries.GetAll
{
    public class GetAllPedidos
    {
        public class QueryPedidos : IRequest<PagedResponse<IEnumerable<ProductoSolicitanteDto>>>
        {
            public string UserId { get; set; }
            public string EstadoNomb { get; set; }
            public int PageNumber { get; set; }
            public int PageSize { get; set; }
        }

        public class Handler : IRequestHandler<QueryPedidos, PagedResponse<IEnumerable<ProductoSolicitanteDto>>>
        {
            private readonly IMapper _mapper;
            private readonly IPedidoRepository _pedidoRepository;

            public Handler(IMapper mapper, IPedidoRepository pedidoRepository)
            {
                _mapper = mapper;
                _pedidoRepository = pedidoRepository;
            }
            public async Task<PagedResponse<IEnumerable<ProductoSolicitanteDto>>> Handle(QueryPedidos request, CancellationToken cancellationToken)
            {
                var filterValidated = _mapper.Map<GetAllPedidoParameters>(request);
                var pedidos = await _pedidoRepository
                     .GetAllPedidos(filterValidated.UserId, filterValidated.EstadoNomb, filterValidated.PageNumber, filterValidated.PageSize);
                var pedidosDto = _mapper.Map<IEnumerable<ProductoSolicitanteDto>>(pedidos);
                var count = await _pedidoRepository.CountTotal();

                var result = new PagedResponse<IEnumerable<ProductoSolicitanteDto>>
                                    (pedidosDto, filterValidated.PageNumber, filterValidated.PageSize, count, "¡Consulta exitosa!");
                return result;
            }
        }
    }
}
