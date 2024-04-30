using TratamentoGlobalDeErros.Middlewares;

public class Program
{
    public static void Main(string[] args)
    {
        var appBuilder = WebApplication.CreateBuilder(args);

        appBuilder.Services.AddControllers();

        appBuilder.Services.AddEndpointsApiExplorer();
        appBuilder.Services.AddSwaggerGen();

        var app = appBuilder.Build();

        app.UseHttpsRedirection();

        app.UseSwagger();
        app.UseSwaggerUI();

        //app.UseDeveloperExceptionPage();
        app.UseGlobalErrorMiddleware(); 

        app.MapControllers();

        app.Run();
    }
}