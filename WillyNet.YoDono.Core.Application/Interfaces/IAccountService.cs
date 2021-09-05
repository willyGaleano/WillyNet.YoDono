﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WillyNet.YoDono.Core.Application.DTOs.Account;
using WillyNet.YoDono.Core.Application.Wrappers;

namespace WillyNet.YoDono.Core.Application.Interfaces
{
    public interface IAccountService
    {
        Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress);
        Task<Response<string>> RegisterAsync(RegisterRequest request, string origin);
        //Task<Response<string>> ConfirmEmailAsync(string userId, string code);
        Task ForgotPassword(ForgotPasswordRequest model, string origin);
        //Task<Response<string>> ResetPassword(ResetPasswordRequest model);
    }
}
