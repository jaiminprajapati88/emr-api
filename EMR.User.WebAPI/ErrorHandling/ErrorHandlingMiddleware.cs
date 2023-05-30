using EMR.Data.Model.Exception;
using System.Net;
using System.Text.Json;

namespace EMR.WebAPI.ErrorHandling
{
    public class ErrorHandlingMiddleware
    {
        #region Properties

        private readonly RequestDelegate _next;

        #endregion Properties

        #region Constuctor

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        #endregion Constuctor

        #region Class Methods

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        #endregion Class Methods

        #region Private Methods

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var exceptionType = ex.GetType();
            ResponseException exception;

            switch (ex)
            {
                case BusinessException business:
                    exception = new ResponseException((BusinessException)ex);
                    break;

                case SecurityException security:
                    exception = new ResponseException((SecurityException)ex);
                    break;

                default:
                    var unhadledException = new UnhandledException(HttpStatusCode.InternalServerError);
                    exception = new ResponseException(unhadledException);
                    break;
            }

            var exceptionResult = JsonSerializer.Serialize(exception, new JsonSerializerOptions() { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault, PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)exception.StatusCode;

            return context.Response.WriteAsync(exceptionResult);
        }

        #endregion Private Methods
    }
}
