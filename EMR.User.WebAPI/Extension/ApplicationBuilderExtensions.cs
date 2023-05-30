using EMR.WebAPI.Authorization;
using EMR.WebAPI.ErrorHandling;

namespace EMR.WebAPI.Extension
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder AddGlobalErrorHandler(this IApplicationBuilder applicationBuilder)
            => applicationBuilder.UseMiddleware<ErrorHandlingMiddleware>();

        public static IApplicationBuilder AddJwtMiddleware(this IApplicationBuilder applicationBuilder)
            => applicationBuilder.UseMiddleware<JwtMiddleware>();
    }
}
