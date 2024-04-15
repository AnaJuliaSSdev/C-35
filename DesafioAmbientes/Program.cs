using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;

class Program
{
    public static void Main(string[] args)
    {
        var appBuilder = WebApplication.CreateBuilder(args);

        appBuilder.Services.AddEndpointsApiExplorer();
        appBuilder.Services.AddSwaggerGen();

        var app = appBuilder.Build();

        app.UseHttpsRedirection();
        app.UseSwagger();
        app.UseSwaggerUI();

        /*
        * A aplica��o n�o pode detalhar o erro em ambiente de produ��o
        * Ao inv�s disso, em produ��o deve fazer "handling" para o endpoint de erro
        */
        var env = app.Environment;

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/error");
        }

        app.MapGet(
        "/error-map",
        (int intent) =>
        {
            throw intent switch
            {
                400 => new Exception("Desenvolvedor: A aplica��o gerou uma exce��o visando o status [400]"),
                404 => new Exception("Desenvolvedor: A aplica��o gerou uma exce��o visando o status [404]"),
                502 => new Exception("Desenvolvedor: A aplica��o gerou uma exce��o visando o status [502]"),
                _ => new Exception("Desenvolvedor: A aplica��o n�o conseguiu mapear a inten��o de status. Ent�o gerou uma exce��o para o status [500]"),
            };
        }
        );

        app.MapGet(
        "/error",
        (HttpContext context) =>
        {
            var contextException = context.Features.Get<IExceptionHandlerFeature>();

            if (contextException == null)
                return Results.Problem(statusCode: 501);

            var exception = contextException.Error;

            var statusCode = exception switch
            {
                Exception _ when exception.Message.Contains("400") => StatusCodes.Status400BadRequest,
                Exception _ when exception.Message.Contains("404") => StatusCodes.Status404NotFound,
                Exception _ when exception.Message.Contains("502") => StatusCodes.Status502BadGateway,
                _ => StatusCodes.Status500InternalServerError,
            };

            return Results.StatusCode(statusCode);
        }
    ).ExcludeFromDescription();

        app.Run();
    }
}