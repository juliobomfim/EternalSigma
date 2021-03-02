namespace jbDEV_Eternal.Domain.Models.Output
{
    public enum ResponseType
    {
        Success,
        Failure,
        Warning
    }
    public class ApiResponse
    {
        private ApiResponse(string message, ResponseType type, object data)
        {
            Message = message;
            Type = type;
            Data = data;
        }

        public string Message { get; set; }
        public ResponseType Type { get; set; }
        public object Data { get; set; }

        public static ApiResponse Success(string message, object data = null) => new ApiResponse(message, ResponseType.Success, data);
        public static ApiResponse Failure(string message, object data = null) => new ApiResponse(message, ResponseType.Failure, data);
        public static ApiResponse Warning(string message, object data = null) => new ApiResponse(message, ResponseType.Warning, data);
    }
}
