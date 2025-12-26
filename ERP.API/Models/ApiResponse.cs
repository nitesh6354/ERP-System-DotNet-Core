namespace ERP.API.Models
{
    // This class defines a STANDARD response format for all APIs
    public class ApiResponse<T>
    {
        // Indicates whether the API call was successful
        public bool Success { get; set; }

        // Message for UI / client (success or error)
        public string Message { get; set; }

        // Actual data returned from API
        public T Data { get; set; }

        // Error details (if any)
        public List<string> Errors { get; set; }

        public ApiResponse()
        {
            Errors = new List<string>();
        }
    }
}
