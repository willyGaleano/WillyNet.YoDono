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
    public class GetAllSolicitudes
    {
        public class QuerySolicitudes : IRequest<PagedResponse<IEnumerable<ProductoSolicitanteDto>>>
        {
            public string UserId { get; set; }
            public string EstadoNomb { get; set; }
            public int PageNumber { get; set; }
            public int PageSize { get; set; }
        }

        public class Handler : IRequestHandler<QuerySolicitudes, PagedResponse<IEnumerable<ProductoSolicitanteDto>>>
        {
            private readonly IMapper _mapper;
            private readonly IPedidoRepository _pedidoRepository;

            public Handler(IMapper mapper, IPedidoRepository pedidoRepository)
            {
                _mapper = mapper;
                _pedidoRepository = pedidoRepository;
            }
            public async Task<PagedResponse<IEnumerable<ProductoSolicitanteDto>>> Handle(QuerySolicitudes request, CancellationToken cancellationToken)
            {
                var filterValidated = _mapper.Map<GetAllPedidoParameters>(request);
                var solicitudes = await _pedidoRepository
                     .GetAllSolicitudes(filterValidated.UserId, filterValidated.EstadoNomb, filterValidated.PageNumber, filterValidated.PageSize);
                var solicitudesDto = _mapper.Map<IEnumerable<ProductoSolicitanteDto>>(solicitudes);
                var count = await _pedidoRepository.CountTotal();

                var result = new PagedResponse<IEnumerable<ProductoSolicitanteDto>>
                               (solicitudesDto, filterValidated.PageNumber, filterValidated.PageSize, count, "¡Consulta exitosa!");
                return result;
            }           
        }
    }
}
