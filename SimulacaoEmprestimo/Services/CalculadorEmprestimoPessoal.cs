namespace SimulacaoEmprestimo.Services;

public class CalculadorEmprestimoPessoal : ICalculadorEmprestimo
{
    public (int, decimal) Calcular(decimal valorDesejado)
    {
        decimal taxa = 0.65m;
        int parcelas = 60;
        decimal valorParcela = Math.Round(valorDesejado * (1 + taxa) / parcelas);

        return (parcelas, valorParcela);
    }
}
