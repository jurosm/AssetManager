using AssetManager.Application.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;

namespace AssetManager.Api.Middleware
{
    public class ExceptionActionFilter : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            httpContext.Response.ContentType = "application/json";

            switch (exception)
            {
                case BadRequestException ex:
                    httpContext.Response.StatusCode = 400;
                    await httpContext.Response.WriteAsJsonAsync(new { ex.Message, ex.ErrorCode }, cancellationToken);
                    break;

                case ValidationException ex:
                    httpContext.Response.StatusCode = 400;
                    await httpContext.Response.WriteAsJsonAsync(new { ex.Message }, cancellationToken);
                    break;
                default:
                    httpContext.Response.StatusCode = 500;
                    await httpContext.Response.WriteAsJsonAsync(new { Message = "The Server encountered an unexpected error.", ErrorCode = "server.internal.error" }, cancellationToken);
                    break;
            }

            return true;      
        }
    }
}
