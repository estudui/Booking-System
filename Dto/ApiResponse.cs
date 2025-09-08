public class ApiResponse<T>
{
    public string Code { get; set; }
    public string Status { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }

    public ApiResponse(string code, string status, string message, T data)
    {
        Code = code;
        Status = status;
        Message = message;
        Data = data;
    }
}