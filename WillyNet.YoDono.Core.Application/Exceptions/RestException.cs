using System;
using System.Net;

namespace WillyNet.YoDono.Core.Application.Exceptions
{
    public class RestException : Exception
    {
        public HttpStatusCode _statusCode;
        public object _errors;

        public RestException(HttpStatusCode statusCode, object errors)
        {
            _statusCode = statusCode;
            _errors = errors;
        }
    }
}
