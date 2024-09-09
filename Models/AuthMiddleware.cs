namespace MiddleWare_with_.NetCore.Models
{
    public class AuthMiddleware
    {
        private readonly string _apikey;
        private readonly RequestDelegate _next;

        private const string API = "x-api-key";

        public AuthMiddleware(RequestDelegate next,IConfiguration configuration) 
        {
            _apikey = configuration["apikey"];
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //use HttpContext ถ้าใช้ servicesfilter จะใช้ (AuthorizationFilterContext context)
            var apiKey = context.Request.Headers[API].FirstOrDefault();

            if (apiKey != _apikey)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized");
                return; 
            }

            await _next(context);
        }
    }
}
