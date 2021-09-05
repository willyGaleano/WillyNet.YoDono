using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillyNet.YoDono.Core.Application.CQRS.Pedidos.Queries.GetAll;
using static WillyNet.YoDono.Core.Application.CQRS.Pedidos.Commands.Create.CreatePedido;

namespace WillyNet.YoDono.Presentation.WebApi.Controllers.v1
{
    public class PedidoController : BaseApiController
    {
        [HttpGet("GetAllPedidosAsync")]
        public async Task<IActionResult> GetAllPedidos([FromQuery] GetAllPedidoParameters parameters)
        {
            return Ok(
                    await Mediator.Send(
                            new GetAllPedidos.QueryPedidos()
                            {
                                UserId = parameters.UserId,
                                PageNumber = parameters.PageNumber,
                                PageSize = parameters.PageSize,
                                EstadoNomb = parameters.EstadoNomb
                            }
                        )
                );
        }
        [HttpGet("GetAllSolicitudesAsync")]
        public async Task<IActionResult> GetAllSolicitudes([FromQuery] GetAllPedidoParameters parameters)
        {
            return Ok(
                    await Mediator.Send(
                            new GetAllSolicitudes.QuerySolicitudes()
                            {
                                UserId = parameters.UserId,
                                PageNumber = parameters.PageNumber,
                                PageSize = parameters.PageSize,
                                EstadoNomb = parameters.EstadoNomb
                            }
                        )
                );
        }

        [HttpPost("SolicitarProducto")]
        public async Task<IActionResult> PatchProduct(PedidoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

    }
}
