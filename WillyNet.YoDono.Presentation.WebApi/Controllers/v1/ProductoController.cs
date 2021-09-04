using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillyNet.YoDono.Core.Application.CQRS.Productos.Queries.GetAll;

namespace WillyNet.YoDono.Presentation.WebApi.Controllers.v1
{   
    public class ProductoController : BaseApiController
    {
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProductoParameters parameters)
        {
            return Ok(
                    await Mediator.Send(
                            new GetAllProductos.QueryProductos()
                            {
                                UserId = parameters.UserId,
                                PageNumber = parameters.PageNumber,
                                PageSize = parameters.PageSize
                            }
                        )
                );
        }
    }
}
