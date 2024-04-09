namespace MoECommerce.API.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string? ErrorMessage { get; set; }

        public ApiResponse(int statusCode, string? errorMessage = null) 
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage ?? GetErrorMessage(statusCode);
        }

        public string GetErrorMessage(int statusCode)
            => statusCode switch
            {
                500 => "Internal Server Error",
                404 => "Not Found",
                401 => "UnAuthorized",
                400 => "Bad Request",
                _ => ""
            };
    }
}
