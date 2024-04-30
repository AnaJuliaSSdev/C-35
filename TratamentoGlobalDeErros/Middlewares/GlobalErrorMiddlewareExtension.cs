namespace TratamentoGlobalDeErros.Middlewares;

public static class GlobalErrorMiddlewareExtension
{
    public static IApplicationBuilder UseGlobalErrorMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<GlobalErrorMiddleware>();
    }
}
