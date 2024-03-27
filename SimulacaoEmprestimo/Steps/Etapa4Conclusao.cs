using SimulacaoEmprestimo.Enums;
using SimulacaoEmprestimo.Repositories;
using SimulacaoEmprestimo.Services;
using System;

public class Etapa4Conclusao
{
    private readonly ServicoSimulacao servicoSimulacao;
    private readonly RepositorioSimulacoes repositorioSimulacoes;
    private readonly Func<TipoEmprestimo, ICalculadorEmprestimo> _service;

    public Etapa4Conclusao(
        ServicoSimulacao servicoSimulacao,
        Func<TipoEmprestimo, ICalculadorEmprestimo> service,
        RepositorioSimulacoes repositorioSimulacoes
    )
    {
        this.servicoSimulacao = servicoSimulacao;
        this._service = service;
        this.repositorioSimulacoes = repositorioSimulacoes;
    }

    public void Executar()
    {
        TipoEmprestimo tipo = servicoSimulacao.ResultadoSimulacao.Tipo;
        int numeroParcelas = 0;
        decimal valorParcela = 0;

        if (servicoSimulacao.ResultadoSimulacao.ResultadoAnaliseDeRisco == SituacaoAnalise.Aprovado)
        {
            var calculador = _service(tipo);
            (numeroParcelas, valorParcela) = calculador.Calcular(servicoSimulacao.ResultadoSimulacao.ValorDesejado);
        }

        servicoSimulacao.ResultadoSimulacao.NumeroParcelas = numeroParcelas;
        servicoSimulacao.ResultadoSimulacao.ValorParcela = valorParcela;

        repositorioSimulacoes.Salvar(servicoSimulacao.ResultadoSimulacao);
    }
}