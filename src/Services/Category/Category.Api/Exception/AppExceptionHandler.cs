using Microsoft.AspNetCore.Diagnostics;
using ErrorOr;


namespace Category.Api.Exception
{
    public class AppExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, System.Exception exception, CancellationToken cancellationToken)
        {
            httpContext.Response.StatusCode = (int)StatusCodes.Status400BadRequest;
            await httpContext.Response.WriteAsJsonAsync(value: exception.Message, cancellationToken);

            return true;
        }
    }
}
