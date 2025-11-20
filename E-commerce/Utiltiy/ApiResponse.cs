namespace E_commerce.Utiltiy
{
    public class SuccessResponse<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; } 
        public T? Data { get; set; }

        public SuccessResponse( T? data, string? message)
        {
            Success = true;
            Data = data;
            Message = message;
        }

    }

    public class ErrorResponse<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }

        public ErrorResponse(string? message)
        {
            Success = false;
            Message = message;
        }
    }
}
