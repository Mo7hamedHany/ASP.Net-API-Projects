namespace MoECommerce.API.Errors
{
    public class ApiValidationError : ApiResponse
    {
        public ApiValidationError() : base(400)
        {
            Errors = new List<string>();
        }
        public IEnumerable<string> Errors { get; set; }
    }
}
