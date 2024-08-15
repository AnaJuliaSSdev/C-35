using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test;

public class OfertaViagemDescontoTest
{
    [Fact]
    public void RetornaPrecoAtualizadoQuandoAplicadoDesconto()
    {
        //arrange
        Rota rota = new("OrigemA", "OrigemB");
        Periodo periodo = new(new DateTime(2024, 08, 15), new DateTime(2024,08,20));
        double precoOriginal = 100.00;
        double desconto = 20.00;
        double precoComDesconto = precoOriginal - desconto;
        OfertaViagem oferta = new(rota, periodo, precoOriginal); 

        //act
        oferta.Desconto = desconto;

        //assert
        Assert.Equal(precoComDesconto, oferta.Preco); 
    }

    [Theory]
    [InlineData(120, 30)]
    [InlineData(100, 30)]

    public void RetornaDescontoMaximoQuandoValorDescontoMaiorOuIgualQuePreco(double desconto, double precoComDesconto)
    {
        //arrange
        Rota rota = new("OrigemA", "OrigemB");
        Periodo periodo = new(new DateTime(2024, 08, 15), new DateTime(2024, 08, 20));
        double precoOriginal = 100.00;
        OfertaViagem oferta = new(rota, periodo, precoOriginal);

        //act
        oferta.Desconto = desconto;

        //assert
        Assert.Equal(precoComDesconto, oferta.Preco, 0.001);
    }
}
