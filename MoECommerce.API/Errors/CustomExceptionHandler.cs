using System;

namespace MoECommerce.API.Errors
{
    public class CustomExceptionHandler
    {
        private readonly RequestDelegate _next;

        private readonly ILogger<CustomExceptionHandler> _logger;

        private readonly IHostEnvironment _environment;

        public CustomExceptionHandler (RequestDelegate next, ILogger<CustomExceptionHandler> logger , IHostEnvironment environment)
        {
            _next = next;
            _logger = logger;
            _environment = environment;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                context.Response.StatusCode = 500;

                var response = _environment.IsDevelopment() ? new ApiExceptionResponse(500,ex.Message,ex.StackTrace)
                    : new ApiExceptionResponse(500);

                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
