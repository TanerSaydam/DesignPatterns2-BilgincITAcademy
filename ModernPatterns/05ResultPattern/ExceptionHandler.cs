using Microsoft.AspNetCore.Diagnostics;

namespace _05ResultPattern;

public sealed class ExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var res = Result<string>.Failed(exception.Message);

        httpContext.Response.StatusCode = 500;
        await httpContext.Response.WriteAsJsonAsync(res);

        return true;
    }
}
