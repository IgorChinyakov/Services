using Presentation.Middlewares;

namespace Presentation.Extensions
{
    public static class ApiExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleWare(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
