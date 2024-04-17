using APIPreferenciasNotificacao.Options;
using APIPreferenciasNotificacao.Services;
using Microsoft.Extensions.Configuration;

class Program
{
    public static void Main(string[] args)
    {
        var appBuilder = WebApplication.CreateBuilder(args);

        appBuilder.Services.AddEndpointsApiExplorer();
        appBuilder.Services.AddSwaggerGen();

        var notificacaoOptions = appBuilder.Configuration.GetSection(NotificacaoOptions.Key);
        appBuilder.Services.Configure<NotificacaoOptions>(notificacaoOptions);

        appBuilder.Services.AddSingleton<ISettingsMap, AppSettingsMap>();

        var app = appBuilder.Build();

        app.UseHttpsRedirection();
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseDeveloperExceptionPage();

        app.MapGet(
          "/configuracoes-notificacao",
          (ISettingsMap settingsMap) =>
          {
              return Results.Ok(settingsMap);
          }
        );

        app.Run();
    }
}