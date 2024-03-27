using SimulacaoEmprestimo.Models;
using SimulacaoEmprestimo.Services;

namespace SimulacaoEmprestimo.Steps;

public class Etapa1Preparacao
{
    private readonly ServicoSimulacao servicoSimulacao;

    public Etapa1Preparacao(ServicoSimulacao servicoSimulacao)
    {
        this.servicoSimulacao = servicoSimulacao;
    }

    public void Executar(SolicitacaoSimulacao solicitacaoSimulacao)
    {
        servicoSimulacao.ResultadoSimulacao.Nome = solicitacaoSimulacao.Nome;
        servicoSimulacao.ResultadoSimulacao.Idade = solicitacaoSimulacao.Idade;
        servicoSimulacao.ResultadoSimulacao.Emprego = solicitacaoSimulacao.Emprego;
        servicoSimulacao.ResultadoSimulacao.Renda = solicitacaoSimulacao.Renda;
        servicoSimulacao.ResultadoSimulacao.Tipo = solicitacaoSimulacao.Tipo;
        servicoSimulacao.ResultadoSimulacao.ValorDesejado = solicitacaoSimulacao.ValorDesejado;
    }
}