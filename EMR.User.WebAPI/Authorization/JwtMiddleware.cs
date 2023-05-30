using EMR.Services.Interfaces;

namespace EMR.WebAPI.Authorization
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserService userService, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userDetailModel = jwtUtils.ValidateToken(token);

            if (userDetailModel != null)
            {
                context.Items["User"] = userDetailModel;
            }

            await _next(context);
        }
    }
}
