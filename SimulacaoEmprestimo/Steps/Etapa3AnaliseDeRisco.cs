using SimulacaoEmprestimo.Enums;
using SimulacaoEmprestimo.Services;

namespace SimulacaoEmprestimo.Steps;

public class Etapa3AnaliseDeRisco
{
    private readonly ServicoSimulacao servicoSimulacao;

    public Etapa3AnaliseDeRisco(ServicoSimulacao servicoSimulacao)
    {
        this.servicoSimulacao = servicoSimulacao;
    }

    public void Executar()
    {
        if (servicoSimulacao.ResultadoSimulacao.ResultadoAnaliseBasica == SituacaoAnalise.Aprovado)
        {
            servicoSimulacao.ResultadoSimulacao.Score = new Random().Next(0, 101);

            if (servicoSimulacao.ResultadoSimulacao.Score >= 60)
                servicoSimulacao.ResultadoSimulacao.ResultadoAnaliseDeRisco = SituacaoAnalise.Aprovado;
        }
    }
}