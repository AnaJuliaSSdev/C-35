namespace SimulacaoEmprestimo.Services;

public class CalculadorEmprestimoAposentado : ICalculadorEmprestimo
{
    public (int, decimal) Calcular(decimal valorDesejado)
    {
        decimal taxa = 0.15m;
        int parcelas = 120;
        decimal valorParcela = Math.Round(valorDesejado * (1 + taxa) / parcelas);

        return (parcelas, valorParcela);
    }
}
