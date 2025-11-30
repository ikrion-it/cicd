namespace ClinicaParaiso.API.Helpers
{
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }

        public ApiResponse(T data, int statusCode = StatusCodes.Status200OK, string message = "Sucesso")
        {
            Data = data;
            StatusCode = statusCode;
            Message = message;
            Success = true;
        }

        public ApiResponse(int statusCode = StatusCodes.Status400BadRequest, string message = "Erro")
        {
            Data = default;
            StatusCode = statusCode;
            Message = message;
            Success = false;
        }
    }
}
