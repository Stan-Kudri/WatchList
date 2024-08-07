using System.Net;
using WatchList.ASP.Net.Controllers.Responses;

namespace WatchList.ASP.Net.Controllers
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
                if (httpContext.Response.StatusCode != StatusCodes.Status400BadRequest)
                {
                    _logger.LogError(ex, "Something went wrong: {Path} {Method}", httpContext.Request.Path, httpContext.Request.Method);
                }
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var (code, errorMessage) = GetResponseDetail(exception);
            context.Response.StatusCode = (int)code;
            await context.Response.WriteAsJsonAsync(
                                                    new MessageResponse { Message = errorMessage, },
                                                    context.RequestAborted);

            static (HttpStatusCode Code, string ErrorMessage) GetResponseDetail(Exception exception)
            {
                return exception switch
                {
                    ArgumentException or InvalidOperationException => (HttpStatusCode.BadRequest, exception.Message),
                    _ => (HttpStatusCode.InternalServerError, "Internal Server Error."),
                };
            }
        }
    }
}
