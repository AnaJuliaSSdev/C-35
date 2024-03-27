namespace SimulacaoEmprestimo.Services;

public interface ICalculadorEmprestimo
{
    (int, decimal) Calcular(decimal valorDesejado);
}
