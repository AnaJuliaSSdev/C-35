using SimulacaoEmprestimo.Enums;

namespace SimulacaoEmprestimo.Models;

public class Simulacao : SolicitacaoSimulacao
{
    public SituacaoAnalise ResultadoAnaliseBasica { get; set; } = SituacaoAnalise.Reprovado;
    public int Score { get; set; }
    public SituacaoAnalise ResultadoAnaliseDeRisco { get; set; } = SituacaoAnalise.Reprovado;
    public int NumeroParcelas { get; set; }
    public decimal ValorParcela { get; set; }
    public decimal ValorTotal => NumeroParcelas * ValorParcela;
}
