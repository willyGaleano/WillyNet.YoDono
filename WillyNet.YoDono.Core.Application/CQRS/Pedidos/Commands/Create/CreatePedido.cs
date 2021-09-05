using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WillyNet.YoDono.Core.Application.Interfaces.Repositories;
using WillyNet.YoDono.Core.Application.Wrappers;

namespace WillyNet.YoDono.Core.Application.CQRS.Pedidos.Commands.Create
{
    public class CreatePedido
    {
        public class PedidoCommand : IRequest<Response<bool>>
        {
            public string UserSolicitanteId { get; set; }
            public Guid ProductoId { get; set; }
            public string EstadoNomb { get; set; }
        }

        public class Handler : IRequestHandler<PedidoCommand, Response<bool>>
        {
            private readonly IProductoRepository _productoRepository;
            private readonly IEstadoRepository _estadoRepository;
            private readonly IPedidoRepository _pedidoRepository;

            public Handler
                (IProductoRepository productoRepository, IEstadoRepository estadoRepository, IPedidoRepository pedidoRepository)
            {
                _productoRepository = productoRepository;
                _estadoRepository = estadoRepository;
                _pedidoRepository = pedidoRepository;
            }
            public async Task<Response<bool>> Handle(PedidoCommand request, CancellationToken cancellationToken)
            {
                var newEstadoId = await _estadoRepository.GetIdEstado(request.EstadoNomb);

                //if(newEstadoId == null)

                var resultCambioEstadoProducto = await _productoRepository
                                        .CambiarEstadoProducto(request.ProductoId, newEstadoId);
                if (resultCambioEstadoProducto)
                {
                    var result = await _pedidoRepository.CrearPedido(request.UserSolicitanteId, request.ProductoId);
                    if (result != null)
                        return new Response<bool>(true);
                }

                return new Response<bool>("No se pudo solicitar el producto");
                
            }
        }
    }
}
