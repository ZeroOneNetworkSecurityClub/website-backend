namespace WebsiteBackend.Utils
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string Message { get; set; }
        
        public ApiResponse(bool success, T? data, string message)
        {
            Success = success;
            Data = data;
            Message = message;
        }
        
        public static ApiResponse<T> SuccessResponse(T data, string message = "请求成功")
        {
            return new ApiResponse<T>(true, data, message);
        }
        
        public static ApiResponse<T> ErrorResponse(string message)
        {
            return new ApiResponse<T>(false, default, message);
        }
    }
}