public static class ApiResponseMapper
{
    public static (string code, string status) Map(int httpStatusCode)
    {
        return httpStatusCode switch
        {
            200 => ("00", "Ok"),
            201 => ("00", "Created"),
            204 => ("00", "No Content"),
            400 => ("01", "Validasi Error"),
            401 => ("02", "Unauthorized"),
            403 => ("03", "Forbidden"),
            404 => ("04", "Not Found"),
            500 => ("99", "Internal Error"),
            _   => ("98", "Unknown Error")
        };
    }
}
