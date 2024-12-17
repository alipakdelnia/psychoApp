namespace psychoApp.Models
{
    public class ApiResponse<T>
    {

        public string Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ApiResponse(string status, string message, T data)
        {
            Status = status;
            Message = message;
            Data = data;
        }

    }
}