using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class ApiResponseFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context) { }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception != null)
        {
            var (code, status) = ApiResponseMapper.Map(500);

            var errorResponse = new ApiResponse<string?>(
                code,
                status,
                context.Exception.Message,
                null
            );

            context.Result = new JsonResult(errorResponse) { StatusCode = 500 };
            context.ExceptionHandled = true;
            return;
        }

        if (context.Result is ObjectResult objectResult)
        {
            var httpStatus = objectResult.StatusCode ?? 200;

            // ✅ Case: controller pakai CustomApiResult → override semua
            if (objectResult.Value is CustomApiResult custom)
            {
                var wrappedCustom = new ApiResponse<object>(
                    custom.Code,
                    custom.Status,
                    custom.Message,
                    custom.Data
                );

                context.Result = new JsonResult(wrappedCustom) { StatusCode = httpStatus };
                return;
            }

            // ✅ Default mapping
            var (code, status) = ApiResponseMapper.Map(httpStatus);
            string message = (objectResult.Value is string str) ? str : "Success";

            object? data = (objectResult.Value is string)
                ? null
                : objectResult.Value;

            var wrapped = new ApiResponse<object?>(
                code,
                status,
                message,
                data
            );

            context.Result = new JsonResult(wrapped) { StatusCode = httpStatus };
        }
    }
}
