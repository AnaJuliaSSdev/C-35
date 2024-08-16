namespace JornadaMilhasV1.Validador;

public abstract class Valida : IValidavel
{
    private readonly Erros erros = new();
    public bool EhValido => !erros.Any();
    public Erros Erros => erros;
    protected abstract void Validar();
}
