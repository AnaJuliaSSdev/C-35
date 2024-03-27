
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SimulacaoEmprestimo.Enums;
using SimulacaoEmprestimo.Models;
using SimulacaoEmprestimo.Repositories;
using SimulacaoEmprestimo.Services;
using SimulacaoEmprestimo.Steps;

public class Program
{
    public static void Main(string[] args)
    {
        var appBuilder = WebApplication.CreateBuilder(args);

        appBuilder.Services.AddEndpointsApiExplorer();
        appBuilder.Services.AddSwaggerGen();

        #region Serviços injetados cujo ciclo de vida necessita revisão

        appBuilder.Services.AddTransient<Etapa1Preparacao>();
        appBuilder.Services.AddTransient<Etapa2AnalisePreliminar>();
        appBuilder.Services.AddTransient<Etapa3AnaliseDeRisco>();
        appBuilder.Services.AddTransient<Etapa4Conclusao>();
        appBuilder.Services.AddScoped<ServicoSimulacao>();
        appBuilder.Services.AddSingleton<RepositorioSimulacoes>();

        appBuilder.Services.AddTransient<CalculadorEmprestimoAposentado>();
        appBuilder.Services.AddTransient<CalculadorEmprestimoPessoal>();

        appBuilder.Services.AddTransient<Func<TipoEmprestimo, ICalculadorEmprestimo>>(serviceProvider => key =>
        {
            switch (key)
            {
                case TipoEmprestimo.Aposentado:
                    return serviceProvider.GetRequiredService<CalculadorEmprestimoAposentado>();
                case TipoEmprestimo.Pessoal:
                    return serviceProvider.GetRequiredService<CalculadorEmprestimoPessoal>();
                default:
                    throw new NotSupportedException($"Tipo de empréstimo não suportado: {key}");
            }
        });

        #endregion

        var app = appBuilder.Build();

        app.UseHttpsRedirection();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MapPost(
          "/solicitacao-simulacao",
          (
            SolicitacaoSimulacao solicitacaoSimulacao,
            [FromServices] Etapa1Preparacao etapa1,
            [FromServices] Etapa2AnalisePreliminar etapa2,
            [FromServices] Etapa3AnaliseDeRisco etapa3,
            [FromServices] Etapa4Conclusao etapa4,
            [FromServices] ServicoSimulacao servicoSimulacao
          ) =>
          {
              etapa1.Executar(solicitacaoSimulacao);
              etapa2.Executar();
              etapa3.Executar();
              etapa4.Executar();

              return servicoSimulacao.ResultadoSimulacao;
          }
        );

        app.MapGet(
          "/simulacao",
          (
            [FromServices] RepositorioSimulacoes repositorioSimulacoes
          ) => repositorioSimulacoes.Simulacoes
        );

        app.Run();
    }
}