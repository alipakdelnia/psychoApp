using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using psychoApp.Models;

namespace psychoApp.Middleware
{
    public class GlobalExceptionHandler : IExceptionHandler
    {

         private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> Logger)
        {
            _logger = Logger;            
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError($"An error occurred: {exception.Message}");

            var errorResponse = new ErrorResponse{
                Message = exception.Message
            };

            switch (exception){
                case BadHttpRequestException:
                errorResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                errorResponse.Title = exception.GetType().Name;
                break;

                default :
                errorResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                errorResponse.Title = "Internal Server Error";
                break;
            }

            httpContext.Response.StatusCode = errorResponse.StatusCode;
            httpContext.Response.ContentType = "application/json";

            var jsonResponse = JsonSerializer.Serialize(errorResponse);
            await httpContext.Response.WriteAsync(jsonResponse,cancellationToken);

            return true;

        }
    }
}