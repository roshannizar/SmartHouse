using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SmartHouse.Shared.Api.Models;
using SmartHouse.Shared.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace SmartHouse.Api.Middleware
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger logger;

        public ErrorMiddleware(RequestDelegate next, ILoggerFactory logger)
        {
            _next = next;
            this.logger = logger.CreateLogger("ErrorLog");
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new ErrorModel { Succeeded = false, Message = ex?.Message };
                logger.LogError(ex.Message);

                switch (ex)
                {
                    case ExpiredTokenException e:
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        responseModel.Errors = e.Message;
                        break;
                    case NotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        responseModel.Errors = e.Message;
                        break;
                    case AccountVerificationFailedException e:
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        responseModel.Errors = e.Message;
                        break;
                    case KeyNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        responseModel.Errors = e.Message;
                        break;
                    case NullReferenceException e:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        responseModel.Errors = e.Message;
                        break;
                    default:
                        if (ex.InnerException == null)
                        {
                            response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            responseModel.Errors = ex.Message;
                        }
                        else
                        {
                            response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            responseModel.Errors = ex.InnerException.Message;
                        }
                        break;
                }

                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }
    }
}
