using Newtonsoft.Json;
using ToDoList.Models;
namespace ToDoList.Middlewares;

public class GlobalErrorMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IHostEnvironment _env;

    public GlobalErrorMiddleware(RequestDelegate next, IHostEnvironment env)
    {
        _next = next;
        _env = env;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        string statusCode = context.Response.StatusCode.ToString();

        ErrorResponse errorResponse = _env.IsDevelopment() ? new ErrorResponse(context.Response.StatusCode.ToString(), ex.Message, ex.StackTrace) :
                new ErrorResponse(statusCode.ToString(), ex.Message, "An internal error has ocurred.");

        var result = JsonConvert.SerializeObject(errorResponse);
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsync(result);
    }
}
