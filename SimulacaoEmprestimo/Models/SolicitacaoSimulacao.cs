using SimulacaoEmprestimo.Enums;

namespace SimulacaoEmprestimo.Models;

public class SolicitacaoSimulacao
{
    public string Nome { get; set; } = string.Empty;
    public int Idade { get; set; }
    public string Emprego { get; set; } = string.Empty;
    public decimal Renda { get; set; }
    public TipoEmprestimo Tipo { get; set; } = TipoEmprestimo.Pessoal;
    public decimal ValorDesejado { get; set; }
}