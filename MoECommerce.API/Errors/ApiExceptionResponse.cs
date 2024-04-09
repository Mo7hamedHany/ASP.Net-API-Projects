namespace MoECommerce.API.Errors
{
    public class ApiExceptionResponse : ApiResponse
    {
        public ApiExceptionResponse(int statusCode, string? errorMessage = null, string? details = null) : base(statusCode, errorMessage)
        {
            Details = details;
        }

        public string? Details { get; set; }
    }
}
