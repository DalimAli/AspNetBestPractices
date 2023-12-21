using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LibraryApi.Handler
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {

            var exceptionMessage = exception.Message.ToString();

            await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Type = exception.GetType().Name,
                Title = "An unexpected error occurred",
                Detail = exceptionMessage,
                Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}"
            });

            return false;
        }
    }
}
