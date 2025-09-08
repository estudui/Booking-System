public class CustomApiResult
{
    public string Code { get; set; }
    public string Status { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }

    public CustomApiResult(string code, string status, string message, object data)
    {
        Code = code;
        Status = status;
        Message = message;
        Data = data;
    }
}
