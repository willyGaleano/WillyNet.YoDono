using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using WillyNet.YoDono.Core.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace WillyNet.YoDono.Infraestructure.Shared.Services.Security
{
    public class AuthenticatedUserService : IAuthenticatedUserService
    {
        public string UserId { get; }
        public AuthenticatedUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue("Id");
        }
    }
}
