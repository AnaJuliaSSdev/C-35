using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test;

public class OfertaViagemConstrutorTest
{
    [Theory]
    [InlineData("", null, "2024-01-01", "2024-01-02", 0, false)]
    [InlineData("OrigemTeste", "DestinoTeste", "2024-02-01", "2024-02-05", 100, true)]
    [InlineData(null, "São Paulo", "2024-01-01", "2024-01-02", -1, false)]
    [InlineData("Vitória", "São Paulo", "2024-01-01", "2024-01-01", 0, false)]
    [InlineData("Rio de Janeiro", "São Paulo", "2024-01-01", "2024-01-02", -500, false)]
    public void RetornaEhValidoDeAcordoComDadosDeEntrada(string origem, string destino, string dataIda, string dataVolta, double preco, bool validacao)
    {
        Rota rota = new(origem, destino);
        Periodo periodo = new(DateTime.Parse(dataIda), DateTime.Parse(dataVolta));

        OfertaViagem oferta = new(rota, periodo, preco);

        Assert.Equal(validacao, oferta.EhValido);
    }

    [Fact]
    public void RetornaMensagemDeErroDeRotaOuPeriodoInvalidosQuandoRotaNula()
    {
        Rota rota = null;
        Periodo periodo = new(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
        double preco = 100.0;

        OfertaViagem oferta = new(rota, periodo, preco);

        Assert.Contains("A oferta de viagem não possui rota ou período válidos.", oferta.Erros.Sumario);
        Assert.False(oferta.EhValido);
    }

    [Fact]
    public void RetornaMensagemDeErroDePrecoInvalidoQuandoPrecoMenorQueZero()
    {
        //arrange
        Rota rota = new("Origem1", "Destino1");
        Periodo periodo = new(new DateTime(2024, 8, 20), new DateTime(2024, 8, 30));
        double preco = -250;

        //act
        OfertaViagem oferta = new(rota, periodo, preco);

        //assert
        Assert.Contains("O preço da oferta de viagem deve ser maior que zero.", oferta.Erros.Sumario);
    }

    [Fact]
    public void RetornaTresErrosDeValidacaoQuandoRotaPeriodoEPrecoSaoInvalidos()
    {
        //arrange
        int quantidadeEsperada = 3; 
        Rota rota = null;
        Periodo periodo = new(new DateTime(2024, 06, 1), new DateTime(2024, 05, 10));
        double preco = -100;

        //act
        OfertaViagem oferta = new(rota, periodo, preco); 

        //assert
        Assert.Equal(quantidadeEsperada, oferta.Erros.Count()); 
    }
}