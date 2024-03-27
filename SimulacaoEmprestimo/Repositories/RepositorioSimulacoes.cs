using SimulacaoEmprestimo.Models;

namespace SimulacaoEmprestimo.Repositories;

public class RepositorioSimulacoes
{
    public List<Simulacao> Simulacoes { get; private set; } = new List<Simulacao>();

    public void Salvar(Simulacao simulacao)
    {
        Simulacoes.Add(simulacao);
    }
}
