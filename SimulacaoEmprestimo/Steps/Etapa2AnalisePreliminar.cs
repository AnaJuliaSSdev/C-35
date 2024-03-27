using SimulacaoEmprestimo.Enums;
using SimulacaoEmprestimo.Services;

namespace SimulacaoEmprestimo.Steps;

public class Etapa2AnalisePreliminar
{
    private readonly ServicoSimulacao servicoSimulacao;

    public Etapa2AnalisePreliminar(ServicoSimulacao servicoSimulacao)
    {
        this.servicoSimulacao = servicoSimulacao;
    }

    public void Executar()
    {
        if (servicoSimulacao.ResultadoSimulacao.Idade < 18)
            return;

        if (servicoSimulacao.ResultadoSimulacao.Tipo == TipoEmprestimo.Aposentado && servicoSimulacao.ResultadoSimulacao.Idade < 70)
            return;

        if (servicoSimulacao.ResultadoSimulacao.ValorDesejado > 100000)
            return;

        if (servicoSimulacao.ResultadoSimulacao.Renda < (servicoSimulacao.ResultadoSimulacao.ValorDesejado * 0.05m))
            return;

        servicoSimulacao.ResultadoSimulacao.ResultadoAnaliseBasica = SituacaoAnalise.Aprovado;

    }
}
